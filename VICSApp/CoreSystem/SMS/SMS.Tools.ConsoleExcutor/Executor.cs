using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using SMS.Common;
using SMS.Common.Configuration;

namespace SMS.Tools.ConsoleExcutor
{
    public class Executor<T> where T : ITask
    {
        private readonly T task;
        private readonly ILogger logger;
        private bool isRunning;
        private readonly object lockObj = new object();
        public Executor(T task, ILogger logger)
        {
            if (task == null)
                throw new ArgumentNullException("task");
            if (logger == null)
                throw new ArgumentNullException("logger");

            this.task = task;
            this.logger = logger;
        }

        public void Execute()
        {
            isRunning = true;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            logger.Log("Starting...");
            var taskRuning = RunTask(task);

            logger.Log("Status {0}", taskRuning.Status);
            var isWaiting = false;
            while (taskRuning.Status != TaskStatus.RanToCompletion)
            {
                if (isWaiting) continue;

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    Console.Write("Are you sure to quite? [Y/N]: ");

                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        isRunning = false;

                        if (taskRuning.IsCompleted == false)
                        {
                            isWaiting = true;
                            Console.WriteLine();
                            logger.Log("Please waiting until the executedTask complete...");
                        }
                    }
                }
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            logger.Log("RunTime " + elapsedTime);
            taskRuning.RunSynchronously();
            taskRuning.Wait();
            Console.WriteLine();
            logger.Log("Successfully quit!. Enter any key to close the console.");
            Console.Read();
        }

        private Task RunTask(ITask executedTask)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var tProcess = Task.Run(() =>
            {
                try
                {
                    while (executedTask.Runable)
                    {
                        // ok run all
                        executedTask.Run();
                    }
                    logger.LogDebug("Exit Execute task!!!");
                    if (executedTask.Runable == false)
                        Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                    isRunning = false;
                }
            }, token).ContinueWith(t => t.RunSynchronously(), tokenSource.Token);
            return tProcess;
        }
    }
}
