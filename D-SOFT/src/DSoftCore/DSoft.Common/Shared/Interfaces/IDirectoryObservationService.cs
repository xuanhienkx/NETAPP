namespace DSoft.Common.Shared.Interfaces;

public interface IDirectoryObservationService
{
    Task Start(string path, Func<string, byte[], Task<bool>> fileProcess,
        CancellationToken cancellationToken,
        bool keepWatching,
        DateTime dateProcess);
    bool Stop();
}
