using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CS.Common;
using CS.Common.Extensions;
using CS.SwiftParser.Configuration;
using Microsoft.Extensions.Configuration;
using xUnit.CSCommon;

namespace xUnit.CS.SwiftParser
{
    public class SwiftParserFixtureSetup : FixtureSetup
    {
        protected override void Initialize()
        {
            var configFile = Path.Combine(Configuration["gateway:settingPath"], "SwiftSettings.json");
            var swiftConfig = ObjectLoader.FromFile<SwiftSetting>(configFile);
            if (swiftConfig == null)
                throw new ArgumentNullException($"swiftConfig", $"Cannot load swiftsetting from path: {configFile}");
        }

        protected override void TearDown()
        {
        }

        public bool CsBagObjectComparison(object obj1, object obj2)
        {
            return obj1.ToString().Equals(obj2.ToString());
        } 
       
        public string LoadTestData(string fileName, bool isTestData)
        {
            var samplePath = Configuration["samplePath"];
            var file = Path.Combine(samplePath, isTestData ? "TestData" : string.Empty, fileName);

            using (var sr = File.OpenText(file))
                return sr.ReadToEnd();
        }
    }
}
