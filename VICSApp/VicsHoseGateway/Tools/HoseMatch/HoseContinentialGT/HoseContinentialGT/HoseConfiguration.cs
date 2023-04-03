using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoseContinentialGT
{
    public class HoseConfiguration
    {
        public string SbsConnectionString { get; set; }
        public string CTCIPath { get; set; }
        public string PRSPath { get; set; }
        public int Firm { get; set; }
        public string CtciFilePrefix { get; set; }
        public int Interval { get; set; }
        public int IntervalPrice { get; set; }
        public TimeSpan? TimeUp { get; set; }

        internal static HoseConfiguration LoadConfig()
        {
            var config = new HoseConfiguration
            {
                SbsConnectionString = ConfigurationManager.ConnectionStrings["SBSConnectionString"].ConnectionString,
                CTCIPath = ConfigurationManager.AppSettings["ctciPath"],
                PRSPath = ConfigurationManager.AppSettings["prsPath"],
                Firm = Convert.ToInt32(ConfigurationManager.AppSettings["firm"]),
                Interval = Convert.ToInt32(ConfigurationManager.AppSettings["interval"]),
                IntervalPrice = Convert.ToInt32(ConfigurationManager.AppSettings["intervalPrice"]),
                CtciFilePrefix = ConfigurationManager.AppSettings["ctciFilePrefix"] ?? DateTime.Today.ToString("yyyyMMdd")
            };

            TimeSpan time;
            if (TimeSpan.TryParse(ConfigurationManager.AppSettings["timeUp"], out time))
                config.TimeUp = time;

            return config;
        }
    }
}
