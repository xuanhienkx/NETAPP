using System;
using SMS.Common;

namespace SMS.Tools.ConsoleExcutor
{
    public class ConsoleLogger : ILogger
    {
        private readonly ILogger decorator;

        public ConsoleLogger(ILogger decorator)
        {
            if (decorator == null) 
                throw new ArgumentNullException("decorator");

            this.decorator = decorator;
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
            decorator.Log(message);
        }

        public void Log(string messageFormat, params object[] args)
        {
            Console.WriteLine(messageFormat, args);
            decorator.Log(messageFormat, args);
        }

        public void LogDebug(string message)
        {
            decorator.LogDebug(message);
        }

        public void LogDebug(string messageFormat, params object[] args)
        {
            decorator.LogDebug(messageFormat, args);
        }

        public void LogError(System.Exception exception)
        {
            Console.WriteLine(exception.Message);
            decorator.LogError(exception);
        }

        public void LogError(string message)
        {
            Console.WriteLine(message);
            decorator.LogError(message);
        }

        public void LogError(string messageFormat, params object[] args)
        {
            Console.WriteLine(messageFormat, args);
            decorator.LogError(messageFormat, args);
        }
    }
}
