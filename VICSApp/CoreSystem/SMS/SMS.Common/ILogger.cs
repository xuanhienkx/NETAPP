using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Common
{
    public interface ILogger
    {
        void Log(string message);
        void Log(string messageFormat, params object[] args);
        void LogDebug(string message);
        void LogDebug(string messageFormat, params object[] args);
        void LogError(Exception exception);
        void LogError(string message);
        void LogError(string messageFormat, params object[] args);
    }
}
