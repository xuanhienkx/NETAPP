using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Console.App;

namespace HoseStockTrader
{
    class Program
    {
        static void Main(string[] args)
        {
            // load config
            var config = HoseConfiguration.LoadConfig();

            // execute the task
            new Executor<HosePriceTask>(new HosePriceTask(config)).Execute(); 
        }
    } 
}
