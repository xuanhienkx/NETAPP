using CS.Common;
using CS.SwiftParser.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using CS.Common.Std;
using CS.Common.Std.Configuration;
using xUnit.CSCommon;
using Xunit;
using Xunit.Abstractions;

namespace xUnit.CS.SwiftParser
{
    public class SwiftParserTest : TestBase<SwiftParserFixtureSetup>
    {
        public SwiftParserTest(SwiftParserFixtureSetup fixture, ITestOutputHelper output)
            : base(fixture, output)
        {
            
        }

        [Fact]
        public void LoadSwiftSettingConfiguration_Successfully()
        {
            var file = Path.Combine(VsdSettingPath, "SwiftSettings.json");

            var config = ObjectLoader.FromFile<SwiftSetting>(file);

            Assert.Equal(3, config.Messages.Count);
            Logger.WriteLine("{0}---BLOCKID---{1}---BLOCK SAMPLE---{2}", config.BlockStart, config.BlockDelimiter, config.BlockEnd);

            Logger.WriteLine("---------------MESSAGES----------------");
            foreach (var message in config.Messages)
            {
                Logger.WriteLine(JsonConvert.SerializeObject(message));
            }
        }

        [Theory]
        //[InlineData("55B446A3-E311-4BB0-B1DE-2795B57FB9AA/MT548_Response")]
        //[InlineData("156CF623-438B-40EA-94BA-91F6D4845145/MT548_Response")]
        //[InlineData("EE7F42B3-9C22-419B-AB15-2B5B03179BC8/MT548_Response")]
        //[InlineData("F7D2FB50-2D2B-4C43-AA7D-855A131E9445/MT548_Response")]
        [InlineData("94C96257-0F80-46A8-ACAF-5EBF2ABE8A88/MT508_Response")] 
        [InlineData("6DB9D872-0028-4AAC-B358-8748147E47E6/MT508_Response")] 
        //[InlineData("036D051D-C61E-47FF-889E-C5E8C60889BE/MT548_Response")] 
        //[InlineData("C86C5BCB-793A-4497-99EB-2DBB16B16D8A/MT564_Response")] 
        public void LoadMTConfig_Successfully(string folder)
        {
            var file = Path.Combine(this.Fixture.Configuration["vsdSettingPath"], "Messages", $"{folder}.json");
            var config = ObjectLoader.FromFile<IList<Field>>(file);

            var fieldReader = new ItemReader<Field>(config);
            var list = new List<string>();
            var isFieldOption = "M";
            while (fieldReader.MoveNext())
            {
                var field = fieldReader.Current;
                if (field.IsOpenField || field.IsEndField)
                    continue;
                foreach (var part in field.Parts)
                {
                    // Logger.WriteLine(part.Name);
                    var isOption = field.IsOptional || part.IsOptional ? "O" : "M";
                    if (field.IsOptional && field.IsOpenField)
                        isFieldOption = "O";
                    Logger.WriteLine($"{field.Tag}\t{field.Qualifier}\t{part.Name}\t{part.Type}\t{isFieldOption}\t{isOption}\t{part.Length}\t\t{part.Format}");
                    if (field.IsEndField && isFieldOption == "O")
                        isFieldOption = "M";
                }
            }
        }
    }
}
