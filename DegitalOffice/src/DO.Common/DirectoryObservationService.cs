using DO.Common.Extensions;
using DO.Common.Std.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DO.Common;

public interface IDirectoryObservationService
{
    Task Start(string path, Func<string, Stream, Task<bool>> fileProcess, CancellationToken cancellationToken, bool keepWatching);
    bool Stop();
}
public class DirectoryObservationService : IDirectoryObservationService
{
    private readonly IConfigurationRoot config;
    private readonly ILogger<DirectoryObservationService> logger;

    private readonly IList<string> blackList;
    private readonly IList<FileSystemWatcher> fileWatchers;
    private readonly Stack<string> inprocessList;

    private bool inProcess;
    private Func<string, Stream, Task<bool>> action;
    private static readonly object LockObj = new object();

    public DirectoryObservationService(
        IConfigurationRoot config,
        ILogger<DirectoryObservationService> logger)
    {
        this.config = config ?? throw new ArgumentNullException(nameof(config));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;

        blackList = new List<string>();
        inprocessList = new Stack<string>();
        fileWatchers = new List<FileSystemWatcher>();
    }
    private async void FileWatcherOnChanged(object sender, FileSystemEventArgs e)
    {
        var fileName = e.FullPath.ToLowerInvariant();
        if (inprocessList.Contains(fileName))
            return;

        if (fileName.EndsWith(".fin") || fileName.EndsWith(".par") || fileName.EndsWith(".DAT") || fileName.EndsWith(".MAP"))
        {
            logger.LogDebug("{0}: {1}", fileName, e.ChangeType);

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
            if (!inProcess)
                break;

            // assert if file can readable
            if (!Executor.Try(() => File.OpenRead(fileName), out var fileStream))
            {
                lock (LockObj)
                {
                    inprocessList.Push(fileName);
                }
                continue;
            }

            // process the file
            var name = fileName;
            await ProcessFile(fileName, () => action.Invoke(name, fileStream));
        }
    }
    public string Name { get; private set; }

    public async Task Start(string path, Func<string, Stream, Task<bool>> fileProcess, CancellationToken cancellationToken, bool keepWatching)
    {
        if (fileProcess == null)
            throw new ArgumentNullException(nameof(fileProcess));

        if (!Path.IsPathRooted(path))
            throw new NetMQ.InvalidException("Path to observe requires the local directory.");

        await ReadAllFile(cancellationToken, path, fileProcess);
        logger.LogInformation("Read all files for the fist time: DONE");

        if (keepWatching)
        {
            if (fileWatchers.Any(x => x.Path == path))
                return;

            action = fileProcess;
            var fileWatcher = new FileSystemWatcher()
            {
                Path = path,
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess,
                IncludeSubdirectories = true,
                Filter = "*.*"
            };

            Name = $"Observer on: [{path}]";

            fileWatcher.Changed += FileWatcherOnChanged;
            fileWatcher.EnableRaisingEvents = true;

            fileWatchers.Add(fileWatcher);

            logger.LogInformation("Observing on path {0}", path);
        }
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
    private async Task ReadAllFile(CancellationToken cancellationToken, string path, Func<string, Stream, Task<bool>> processFileAction)
    {
        var files = new List<string>(Directory.GetFiles(path));

        logger.LogInformation("Start process {0} file(s) in folder {1}", files.Count, path);
        foreach (var file in files)
        {
            if (cancellationToken.IsCancellationRequested)
                break;

            lock (LockObj)
            {
                if (blackList.Contains(file))
                    continue;
            }
            if (file.EndsWith(".fin", StringComparison.OrdinalIgnoreCase) ||
                file.EndsWith(".dat", StringComparison.OrdinalIgnoreCase) ||
                file.EndsWith(".tmp", StringComparison.OrdinalIgnoreCase) ||
                file.EndsWith(".par", StringComparison.OrdinalIgnoreCase))
            {
                if (Executor.Try(() => File.OpenRead(file), out var fileStream))
                    await ProcessFile(file, () => processFileAction.Invoke(file, fileStream));
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
            opt.BreakerOpened = e => logger.LogWarning("Attempt: {0}. {1}", opt.Attempt, e.Message);
            opt.BreakerTimeout = e => logger.LogWarning("Attempt: {0}. {1}", opt.Attempt, e.Message);
            opt.UnkownException = e =>
            {
                logger.LogError("Attempt: {0}. {1}", opt.Attempt, e);
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