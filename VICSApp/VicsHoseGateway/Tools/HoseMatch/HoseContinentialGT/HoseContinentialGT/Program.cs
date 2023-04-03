using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Console.App;

namespace HoseContinentialGT
{
    class Program
    {
        static void Main(string[] args)
        {
            // load config
            var config = HoseConfiguration.LoadConfig();

            // execute the task
            new Executor<HoseMatchTask>(new HoseMatchTask(config)).Execute(); 
        }
    }
}
