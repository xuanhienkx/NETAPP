using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Tools.ConsoleExcutor;

namespace SMS.Tools.App.Process
{
    public interface IProcess
    {
        string Name { get; }
        /// <summary>
        /// Interval
        /// </summary>
        TimeSpan TimeInterval { get; }
        bool CanRun();
        bool Run(out string errorMessage);
    }
}
