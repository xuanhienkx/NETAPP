using xUnit.DSoft.CommonTest;

namespace xUnit.DSoft.Core.MarketParserTest;

public class MartketParserFixtureSetup : FixtureSetup
{
    protected override void Initialize()
    {
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