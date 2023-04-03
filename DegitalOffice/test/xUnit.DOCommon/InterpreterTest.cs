using DO.Common;
using System.Text;
using Xunit.Abstractions;

namespace xUnit.DO.CommonTest;

public class InterpreterTest : TestBase<CommonFixtureSetup>
{
    public InterpreterTest(CommonFixtureSetup fixtureSetup, ITestOutputHelper output) : base(fixtureSetup, output)
    {
    }

    [Fact]
    //  [InlineData("SECURITY.DAT")]
    public void ParseMessageBlocks()
    {
        var file = @"D:\Projects\DegitalOffice\PRS\BACKUP07\DELIST.DAT";
        var files = ObjectLoader.LoadFromFile(file);
        Logger.WriteLine(files);
        // var listData = new List<DeList>();
        // var readFiles = new Reader<DeList>(file);
        // int count = 1;
        // readFiles.Open();
        // Logger.WriteLine($"------------File Length: {readFiles.Length}-------------");
        // while (readFiles.Read())
        // {
        //     var delist = readFiles.Data;
        //     Logger.WriteLine($"------------Begin {count}-------------");
        //     Logger.WriteLine($"1.StockNo: {delist.StockNo}");
        //     Logger.WriteLine($"2.StockSymbol: {delist.StockSymbol}");
        //     Logger.WriteLine($"3.StockName : {delist.StockName}");
        //     Logger.WriteLine($"4.StockType: {delist.StockType}");
        //     // Logger.WriteLine($"5.Floor: {delist.Floor}");
        //     // Logger.WriteLine($"6.Ceiling : {delist.Ceiling}");
        //     // Logger.WriteLine($"7.StockType: {delist.AveragePrice}");
        //     Logger.WriteLine($"-------------End {count}-------------");
        //     listData.Add(delist);
        //     count++;
        // }
        // readFiles.Close();


        Assert.Equal("expectedBlock", "expectedBlock");
        // Read the file and display it line by line. .


    }
    [Fact]
    public void DeListTest()
    {
        var path = @"D:\Projects\DegitalOffice\PRS\BACKUP07\SECURITY.DAT";
        using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        using var sr = new StreamReader(fs, Encoding.UTF8);
        string content = sr.ReadToEnd();
        Logger.WriteLine(content);
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