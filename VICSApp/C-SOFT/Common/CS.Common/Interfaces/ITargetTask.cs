using System;
using System.Threading;
using System.Threading.Tasks;

namespace CS.Common.Interfaces
{
    public struct TaskConfig
    {
        public int MaxFailAttemps { get; set; }
        public TimeSpan Timeout { get; set; }
        public TimeSpan CircuitBreakerResetTimeout { get; set; }
    }

    public interface ITargetTask
    {
        int Priority { get; }
        string Name { get; }
        Task Start(CancellationToken token);
        bool Stop();
    }
}
