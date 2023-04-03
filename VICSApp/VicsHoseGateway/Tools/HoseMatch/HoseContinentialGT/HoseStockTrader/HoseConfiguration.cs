using System;
using System.Configuration;

namespace HoseStockTrader
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
        /// <summary>
        /// truoc 9:00
        /// </summary>
        public TimeSpan Start { get; set; }
        /// <summary>
        /// Truoc 9:15
        /// </summary>
        public TimeSpan PreOpen { get; set; }
        /// <summary>
        /// Truoc 11:30
        /// </summary>
        public TimeSpan OpenI { get; set; }
        /// <summary>
        /// truoc 13:00
        /// </summary>
        public TimeSpan Intermission { get; set; }
        /// <summary>
        /// truoc 14:30
        /// </summary>
        public TimeSpan OpenII { get; set; }
        /// <summary>
        /// truoc 14:45
        /// </summary>
        public TimeSpan PreClose { get; set; }
        /// <summary>
        /// truoc 15:00
        /// </summary>
        public TimeSpan Close { get; set; }

        internal static HoseConfiguration LoadConfig()
        {
            var config = new HoseConfiguration
            {
                SbsConnectionString = ConfigurationManager.ConnectionStrings["WebStock"].ConnectionString,
                CTCIPath = ConfigurationManager.AppSettings["ctciPath"],
                PRSPath = ConfigurationManager.AppSettings["prsPath"],
                Firm = Convert.ToInt32(ConfigurationManager.AppSettings["firm"]),
                Interval = Convert.ToInt32(ConfigurationManager.AppSettings["interval"]),
                IntervalPrice = Convert.ToInt32(ConfigurationManager.AppSettings["intervalPrice"]),
                CtciFilePrefix = ConfigurationManager.AppSettings["ctciFilePrefix"] ?? DateTime.Today.ToString("yyyyMMdd"),
                Start = new TimeSpan(8, 45, 0),
                PreOpen = string.IsNullOrEmpty(ConfigurationManager.AppSettings["T1"]) ? new TimeSpan(9, 15, 0) : TimeSpan.Parse(ConfigurationManager.AppSettings["T1"]),
                OpenI = string.IsNullOrEmpty(ConfigurationManager.AppSettings["T2"]) ? new TimeSpan(11, 30, 0) : TimeSpan.Parse(ConfigurationManager.AppSettings["T2"]),
                Intermission = string.IsNullOrEmpty(ConfigurationManager.AppSettings["T3"]) ? new TimeSpan(13, 00, 0) : TimeSpan.Parse(ConfigurationManager.AppSettings["T3"]),
                OpenII = string.IsNullOrEmpty(ConfigurationManager.AppSettings["T4"]) ? new TimeSpan(14, 30, 0) : TimeSpan.Parse(ConfigurationManager.AppSettings["T4"]),
                PreClose = string.IsNullOrEmpty(ConfigurationManager.AppSettings["T6"]) ? new TimeSpan(14, 45, 0) : TimeSpan.Parse(ConfigurationManager.AppSettings["T5"]),
                Close = string.IsNullOrEmpty(ConfigurationManager.AppSettings["T6"]) ? new TimeSpan(15, 00, 0) : TimeSpan.Parse(ConfigurationManager.AppSettings["T6"]),

            };

            TimeSpan time;
            if (TimeSpan.TryParse(ConfigurationManager.AppSettings["timeUp"], out time))
                config.TimeUp = time;

            return config;
            //C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.Configuration.dll
            // C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.Configuration.dll
        }
    }
}
