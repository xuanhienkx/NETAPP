
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console.App
{
    public class Executor<T> where T : ITask
    {
        private readonly T task;
        private bool isRunning;
        public Executor(T task)
        {
            this.task = task;
        }

        public void Execute()
        {
            isRunning = true;
            var taskRuning = RunTask(task);
            var isWaiting = false;
            Logger.ConsoleLog("Status {0}", taskRuning.Status);
            while (taskRuning.Status != TaskStatus.RanToCompletion)
            {
                if (isWaiting) continue;

                if (System.Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    System.Console.WriteLine();
                    System.Console.Write("Are you sure to quite? [Y/N]: ");

                    if (System.Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        isRunning = false;

                        if (taskRuning.IsCompleted == false)
                        {
                            isWaiting = true;

                            System.Console.WriteLine();
                            Logger.ConsoleLog("Please waiting until the executedTask complete...");
                        }
                    }
                }
            }

            System.Console.WriteLine();
            Logger.ConsoleLog("Successully quit!. Enter any key to colse the console.");
            System.Console.Read();
        }

        private Task RunTask(ITask executedTask)
        { 
            return  Task.Factory.StartNew(() =>
            {
                try
                {
                    while (isRunning)
                    {
                        // ok run all
                        executedTask.Run();

                        // sleep now
                        executedTask.Sleep();
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message);
                    throw;
                }
            });
        }
    }
}
