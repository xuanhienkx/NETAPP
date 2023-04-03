//using BenchmarkDotNet.Attributes;
//using BenchmarkDotNet.Running;
//using DSoft.Common.Shared.Base;
//using DSoft.Common.Shared.Interfaces;
//using DSoft.MarketParser.Common;
//using System.Runtime.CompilerServices;
//using System.Text;
//using Xunit.Abstractions;

//namespace xUnit.DSoft.Core.MarketParserTest;
//public class ConvertHelper
//{
//    public static void ProcessFile(string path, PrsMessage msgSetting, ITestOutputHelper Logger)
//    {
//        var fsSource = File.ReadAllBytes(path);

//        // Read the source file into a byte array.
//        //byte[] bytes = new byte[fsSource.Length];
//        int numBytesToRead = (int)fsSource.Length;
//        var maxCharBytesSize = numBytesToRead;
//        int numBytesRead = 0;
//        // string s = null;
//        //     var buffer = new char[fsSource.Length];

//        while (numBytesToRead > 0)
//        {
//            // Read may return anything from 0 to numBytesToRead.   
//            var fieldReader = new ItemReader<Part>(msgSetting?.Parts);

//            while (fieldReader.MoveNext() && numBytesToRead > 0)
//            {
//                var part = fieldReader.Current;
//                if (string.IsNullOrEmpty(part.Name))
//                    continue;
//                var bytes = reader.ReadBytes(part.Length);
//                // Break when the end of the file is reached.
//                if (numBytesToRead < part.Length)
//                    continue;

//                object partValue = default;
//                switch (part.Type)
//                {
//                    case CSValueType.Integer:
//                        partValue = reader.ReadUInt32();
//                        break;
//                    case CSValueType.Long:
//                        partValue = reader.ReadUInt64();
//                        break;
//                    case CSValueType.Decimal:
//                        partValue = reader.ReadDecimal();
//                        break;
//                    case CSValueType.Double:
//                        partValue = reader.ReadDouble();
//                        break;
//                    default:
//                        //byte[] buffer = new byte[part.Length];
//                        //reader.Read(buffer, 0, part.Length);
//                        partValue = Encoding.UTF8.GetString(bytes).Trim();
//                        break;
//                }
//                Logger.WriteLine($"Convert {msgSetting.Name} [{part.Name} : {partValue}]");
//                numBytesRead += part.Length;
//                numBytesToRead -= part.Length;
//            }
//        }
//    }
//}
