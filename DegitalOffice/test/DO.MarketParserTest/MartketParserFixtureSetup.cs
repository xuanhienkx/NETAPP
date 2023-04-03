using DO.Common;
using DO.MarketParser.Configuration;
using xUnit.DO.CommonTest;

namespace xUnit.DO.MarketParserTest;

public class MartketParserFixtureSetup : FixtureSetup
{
    protected override void Initialize()
    {
        var configFile = Path.Combine(Configuration["settingPath"], "PrsSetting.json");
        var swiftConfig = ObjectLoader.FromFile<PrsSetting>(configFile);
        if (swiftConfig == null)
            throw new ArgumentNullException($"PrsSetting", $"Cannot load PrsSetting from path: {configFile}");

    }

    protected override void TearDown()
    {
    }
    public bool CsBagObjectComparison(object obj1, object obj2)
    {
        return obj1.ToString().Equals(obj2.ToString());
    }

    public string LoadTestData(string fileName)
    {
        var samplePath = Configuration["samplePath"];
        var file = Path.Combine(samplePath, fileName);
        using var sr = File.OpenText(file);
        return sr.ReadToEnd();
    }
}