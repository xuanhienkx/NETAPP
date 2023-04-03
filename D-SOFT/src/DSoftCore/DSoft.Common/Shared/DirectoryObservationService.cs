using DSoft.Common.Extensions;
using DSoft.Common.Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DSoft.Common.Shared;

public class DirectoryObservationService : IDirectoryObservationService
{
    private readonly IConfigurationRoot config;
    private readonly ILogger<DirectoryObservationService> logger;
    private readonly IList<string> blackList;
    private readonly IList<string> lockList;
    private readonly IList<string> fileExtentionFilters;
    private readonly IList<string> fileIgnoreFilters;
    private readonly IList<FileSystemWatcher> fileWatchers;
    private readonly Stack<string> inprocessList;
    private bool inProcess;
    private Func<string, byte[], Task<bool>> action;
    private static readonly object LockObj = new object();

    public DirectoryObservationService(IConfigurationRoot config, ILogger<DirectoryObservationService> logger)
    {
        this.config = config ?? throw new ArgumentNullException(nameof(config));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        blackList = new List<string>();
        lockList = new List<string>();
        inprocessList = new Stack<string>();
        fileWatchers = new List<FileSystemWatcher>();
        fileExtentionFilters = config.GetSection("gateway:fileFilter").Get<IList<string>>();
        fileIgnoreFilters = config.GetSection("gateway:fileIgnore").Get<IList<string>>();
    }
    private async void FileWatcherOnChanged(object sender, FileSystemEventArgs e)
    {

        var fileName = e.FullPath.ToLowerInvariant();
        if (lockList.Any(i => i.ToLowerInvariant().Contains(fileName, StringComparison.OrdinalIgnoreCase)))
            return;

        if (fileIgnoreFilters.Any(i => fileName.EndsWith(i.ToLowerInvariant(), StringComparison.OrdinalIgnoreCase)))
            return;

        if (inprocessList.Any(i => i.ToLowerInvariant().Contains(fileName, StringComparison.OrdinalIgnoreCase)))
            return;

        if (fileExtentionFilters.Any(x => fileName.EndsWith(x.ToLowerInvariant(), StringComparison.OrdinalIgnoreCase)))
        {
            logger.LogDebug("LockObj {0}: {1}", fileName, e.ChangeType);

            lock (LockObj)
            {
                inprocessList.Push(fileName);
            }

            // arise the method to process the list files
            await ReadoutAllFiles();
        }

    }
    private async Task ReadoutAllFiles()
    {
        if (inProcess)
            return;

        while (true)
        {
            inProcess = inprocessList.TryPop(out var fileName);
            if (!inProcess || fileName == null)
                break;

            // assert if file can readable
            if (!Executor.Try(() => File.ReadAllBytesAsync(fileName), out var fileStream))
            {
                lock (LockObj)
                {
                    inprocessList.Push(fileName);
                }
                continue;
            }

            var fileLenght = fileStream.Result.Length;
            logger.LogDebug("Notification change Site read of file {0}: [{1:N0}]", fileName, fileLenght);

            // process the file
            await ExecutorProcess(fileName, fileStream.Result);

        }
    }
    public async Task<bool> ExecutorProcess(string fileName, byte[] fileStream)
    {
        return await Executor.TryAsync(async
                 () => await ProcessFile(fileName, () => action.Invoke(fileName, fileStream)),
                 e =>
                 {
                     logger.LogError("Error: {0} File [{1}] is blocked!", e.Message, fileName);

                     lock (LockObj)
                     {
                         lockList.Add(fileName.ToLowerInvariant());
                     }
                 });

    }
    public string Name { get; private set; }
    public DateTime DateProcess { get; private set; }


    public async Task Start(string path, Func<string, byte[], Task<bool>> fileProcess, CancellationToken cancellationToken, bool keepWatching, DateTime dateProcess)
    {
        if (fileProcess == null)
            throw new ArgumentNullException(nameof(fileProcess));

        if (!Path.IsPathRooted(path))
            throw new NetMQ.InvalidException("Path to observe requires the local directory.");

        action = fileProcess;
        DateProcess = dateProcess;
        await ReadAllFile(cancellationToken, path, fileProcess);
        logger.LogInformation("Read all files for the fist time: DONE at path: {0}", path);

        if (keepWatching)
        {
            if (fileWatchers.Any(x => x.Path == path))
                return;
            var fileWatcher = new FileSystemWatcher()
            {
                Path = path,
                NotifyFilter = NotifyFilters.LastWrite,
                IncludeSubdirectories = true,
                EnableRaisingEvents = true,
                Filter = "*.*"
            };

            Name = $"Observer on path: [{path}]";
            fileWatcher.Changed += FileWatcherOnChanged;

            fileWatchers.Add(fileWatcher);

            logger.LogInformation(Name);
        }
    }

    public IEnumerable<FileInfo> GetCurrentdayFiles(string path)
    {
        DirectoryInfo dirs = new DirectoryInfo(path);
        var files = dirs.GetFiles()
                      .Where(f =>
                                fileExtentionFilters.Any(x => f.Name.ToLowerInvariant().EndsWith(x.ToLowerInvariant(), StringComparison.OrdinalIgnoreCase))
                             && !fileIgnoreFilters.Any(x => f.Name.ToLowerInvariant().Contains(x.ToLowerInvariant(), StringComparison.OrdinalIgnoreCase))
                              );
        return files.Where(f => f.LastWriteTime >= DateProcess);
    }
    public bool Stop()
    {
        lock (LockObj)
        {
            blackList.Clear();
        }

        foreach (var fileWatcher in fileWatchers)
        {
            fileWatcher.Changed -= FileWatcherOnChanged;
            fileWatcher.EnableRaisingEvents = false;
        }
        fileWatchers.Clear();
        return true;
    }

    private async Task ReadAllFile(CancellationToken cancellationToken, string path, Func<string, byte[], Task<bool>> processFileAction)
    {
        var files = GetCurrentdayFiles(path);

        logger.LogInformation("Start process read {0} file(s) in folder {1}", files?.Count(), path);

        foreach (var file in files)
        {
            var fileName = file.FullName.ToLowerInvariant();
            if (cancellationToken.IsCancellationRequested)
                break;

            lock (LockObj)
            {
                if (blackList.Contains(fileName))
                    continue;
            }

            if (Executor.Try(async () => await File.ReadAllBytesAsync(file.FullName), out var fileStream))
            {
                logger.LogDebug("First size of file {0}: [{1:N0}]",
                    file.FullName.ToLowerInvariant(), file.Length);
                // process the file
                await ExecutorProcess(fileName, fileStream.Result);

            }
        }
    }

    private async Task ProcessFile(string fileName, Func<Task<bool>> processFileAction)
    {
        if (string.IsNullOrEmpty(fileName))
            return;

        int.TryParse(config["gateway:maxFailureAttempt"], out var maxFailureAttempt);
        int.TryParse(config["gateway:executeTimeout"], out var executeTimeout);
        int.TryParse(config["gateway:fileAccessDelay"], out var fileAccessDelay);

        var result = await processFileAction.CircuitBreakerExecuteAsync(opt =>
        {
            opt.MaxAttemptFailure = maxFailureAttempt;
            opt.ExecuteTimeOut = TimeSpan.FromMilliseconds(executeTimeout);
            opt.ResetTimeOut = TimeSpan.FromMilliseconds(executeTimeout * 2);
            opt.BreakerOpened = e => logger.LogWarning("Attempt BreakerOpened:[{0}]. [{1}]--{2}", opt.Attempt, fileName, e.Message);
            opt.BreakerTimeout = e => logger.LogWarning("Attempt BreakerTimeout:[{0}]. [{1}]--{2}", opt.Attempt, fileName, e.Message);
            opt.UnkownException = e =>
            {
                logger.LogError("Attempt: [{0}]. [{0}]-{1}", opt.Attempt, fileName, e);
                if (e is IOException)
                    Thread.Sleep(fileAccessDelay);
            };
        });

        if (!result)
        {
            // circuit open, keep file in blacklist
            logger.LogInformation("File {0} is blocked!", fileName);

            lock (LockObj)
            {
                blackList.Add(fileName.ToLowerInvariant());
            }
        }
    }
}
