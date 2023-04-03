namespace DSoft.Common.Shared.Interfaces;

public interface ITargetTask
{
    int Priority { get; }
    string Name { get; }
    Task Start(CancellationToken token);
    bool Stop();
}
public struct TaskConfig
{
    public int MaxFailAttemps { get; set; }
    public TimeSpan Timeout { get; set; }
    public TimeSpan CircuitBreakerResetTimeout { get; set; }
}
