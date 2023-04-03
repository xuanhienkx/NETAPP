using CS.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CS.CoreApi.Configurations
{
    public class DataContextInitilizer
    {
        public static async Task Init(IServiceProvider serviceProvider, IEnumerable<IDbInitializer> initializers)
        {
            foreach (var initializer in initializers)
            {
                try
                {
                    Console.WriteLine("START INITIALIZE DATACONTEXT: {0}", initializer.Name);

                    await initializer.Initialize(serviceProvider);
                }
                catch (Exception exception)
                {

                    var currentColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FAILED");
                    Console.ForegroundColor = currentColor;

                    Console.WriteLine(exception);
                }
            }
        }
    }
}
