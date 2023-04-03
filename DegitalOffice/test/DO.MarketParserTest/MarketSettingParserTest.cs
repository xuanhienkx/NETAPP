using DO.Common;
using DO.Common.Interfaces;
using DO.MarketParser;
using DO.MarketParser.Configuration;
using DO.MarketParser.MessageBuilder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using xUnit.DO.CommonTest;
using Xunit;
using Xunit.Abstractions;

namespace xUnit.DO.MarketParserTest;

public class MarketSettingParserTest : TestBase<MartketParserFixtureSetup>
{
    public MarketSettingParserTest(MartketParserFixtureSetup fixtureSetup, ITestOutputHelper output)
        : base(fixtureSetup, output)
    {
    }
    public object DeserializeFromStream(MemoryStream stream)
    {
        IFormatter formatter = new BinaryFormatter();
        stream.Seek(0, SeekOrigin.Begin);
        object o = formatter.Deserialize(stream);
        return o;
    }
    // that are found, and process the files they contain.
    public void ProcessDirectory(string targetDirectory)
    {
        // Process the list of files found in the directory.
        string[] fileEntries = Directory.GetFiles(targetDirectory);
        foreach (string fileName in fileEntries)
            Logger.WriteLine(fileName);

        // Recurse into subdirectories of this directory.
        string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foreach (string subdirectory in subdirectoryEntries)
            ProcessDirectory(subdirectory);
    }
    [Fact]
    //  [InlineData("SECURITY.DAT")]
    public async void ParseMessageBlocks()
    {
        DateTime date = DateTime.Today;
        string folderBakup = $"Backup{date:dd}";
        var path = Path.Combine(DataPath);
        if (Directory.Exists(path))
        {
            // This path is a directory
            string[] fileEntries = Directory.GetFiles(path);
            if (fileEntries.Any(x => x.EndsWith("Datapath.MAP")))
            {
                var mapfile = fileEntries.FirstOrDefault(x => x.EndsWith("Datapath.MAP"));
                var fd = ObjectLoader.LoadFromFile(mapfile);
                if (!string.IsNullOrEmpty(fd))
                {
                    folderBakup = fd.Substring(fd.Length - 8, 8);
                    Logger.WriteLine($"-------folderBakup :{folderBakup}-------");
                    var strDate = fd.Substring(fd.Length - 18, 10);
                    Logger.WriteLine($"-------strDate :{strDate}-------");
                    date = DateTime.ParseExact(strDate, "dd/MM/yyyy", CultureInfo.CurrentUICulture);

                    Logger.WriteLine($"-------date :{date.ToString()}-------");
                }



            }
        }



        Assert.Equal("expectedBlock", "expectedBlock");


    }


    [Theory]
    [InlineData("PUT_EXEC")]
    [InlineData("DELIST")]
    [InlineData("FROOM")]
    [InlineData("LS")]
    [InlineData("LE")]
    [InlineData("MARKET_STAT")]
    [InlineData("OFFSET")]
    [InlineData("OS")]
    [InlineData("PO")]
    [InlineData("PUT_AD")]
    [InlineData("SECURITY")]
    public void ParsePrsMessage(string message)
    {
        var pasthfile = Path.Combine(DataPath, "Backup07", $"{message.ToUpperInvariant()}.dat");
        var st = File.Open(pasthfile, FileMode.Open, FileAccess.Read, FileShare.Read);
        ReadMessage(st, message);
    }


    private void ReadMessage(Stream st, string message)
    {
        // fixture 
        Fixture.Register(RegisterComponents);
        // setup
        var sut = Fixture.Resolve<IMarketMessageConverter>();

        // excercise
        CsBag result = new CsBag();

        Execute(async () =>
        {
            try
            {
                result = await sut.Read<PrsBag>(st, message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // print bag
            PrintBag(result);
            Assert.IsType<PrsBag>(result);
        });
        //
        // Assert.True(true);
    }

    private void PrintBag(CsBag bag, string fileName = "")
    {


        IDictionary<string, object> bagToJson = bag.GetDictionary();
        var data = bagToJson.GroupBy(item => item.Key.Substring(0, item.Key.IndexOf(".")))
         .Select(group => group.Aggregate(new Dictionary<string, object>(), (obj, item) =>
         {
             obj[item.Key.Substring(item.Key.IndexOf(".") + 1)] = item.Value;
             return obj;
         })).ToList();
        var str = JsonConvert.SerializeObject(data);
        Logger.WriteLine(str);
    }

    private void RegisterComponents(IServiceCollection services)
    {
        var configFile = Path.Combine(Fixture.Configuration["settingPath"], "PrsSetting.json");
        var marketSettings = ObjectLoader.FromFile<PrsSetting>(configFile);
        if (marketSettings == null)
            throw new ArgumentNullException($"MarketSetting", $"Cannot load MarketSetting from path: {configFile}");


        // register all services
        services.AddSingleton(marketSettings);

        services.AddSingleton<IMarketMessageConverter, PrsMessageConverter>();
    }

    public static byte[] ConvertToByteArray(string value)
    {
        byte[] bytes = null;
        if (string.IsNullOrEmpty(value))
            return bytes;

        int string_length = value.Length;
        int character_index = value.StartsWith("0x", StringComparison.Ordinal) ? 2 : 0; // Does the string define leading HEX indicator '0x'. Adjust starting index accordingly.               
        int number_of_characters = string_length - character_index;

        bool add_leading_zero = false;
        if (0 != number_of_characters % 2)
        {
            add_leading_zero = true;

            number_of_characters += 1;  // Leading '0' has been striped from the string presentation.
        }

        bytes = new byte[number_of_characters / 2]; // Initialize our byte array to hold the converted string.

        int write_index = 0;
        if (add_leading_zero)
        {
            bytes[write_index++] = FromCharacterToByte(value[character_index], character_index);
            character_index += 1;
        }

        for (int read_index = character_index; read_index < value.Length; read_index += 2)
        {
            byte upper = FromCharacterToByte(value[read_index], read_index, 4);
            byte lower = FromCharacterToByte(value[read_index + 1], read_index + 1);

            bytes[write_index++] = (byte)(upper | lower);
        }


        return bytes;
    }
    private static byte FromCharacterToByte(char character, int index, int shift = 0)
    {
        byte value = (byte)character;
        if (0x40 < value && 0x47 > value || 0x60 < value && 0x67 > value)
        {
            if (0x40 == (0x40 & value))
            {
                if (0x20 == (0x20 & value))
                    value = (byte)(value + 0xA - 0x61 << shift);
                else
                    value = (byte)(value + 0xA - 0x41 << shift);
            }
        }
        else if (0x29 < value && 0x40 > value)
            value = (byte)(value - 0x30 << shift);
        else
            throw new InvalidOperationException($"Character '{character}' at index '{index}' is not valid alphanumeric character.");

        return value;
    }

}