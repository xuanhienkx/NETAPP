using System;

namespace SMS.Tools.ConsoleExcutor
{
    public interface ITask
    {
        bool Runable { get; }
        void Run();
    }
}
