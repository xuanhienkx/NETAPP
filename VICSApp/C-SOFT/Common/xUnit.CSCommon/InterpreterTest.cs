using CS.Common;
using CS.Common.Contract.Models;
using CS.Common.Std.Extensions;
using Newtonsoft.Json;
using ProtoBuf.Meta;
using SemanticComparison.Fluent;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace xUnit.CSCommon
{
    public class InterpreterTest : TestBase<CommonFixtureSetup>
    {
        public InterpreterTest(CommonFixtureSetup fixture, ITestOutputHelper output) 
            : base(fixture, output)
        {
        }

        [Theory]
        [InlineData("MT544-Chuyen nhuong quyen mua.fin", 4)]
        [InlineData("ACK_sample.fin", 6)]
        [InlineData("NAK_sample.fin", 6)]
        [InlineData("NAK_sample2.fin", 6)]
        public void ParseMessageBlocks(string fileName, int expectedBlock)
        {
            // fixture
            var interpreter = new Interpreter('{', ':', '}');

            // setup
            var data = ObjectLoader.LoadFromFile($"../../../Samples/{fileName}");
            IList<KeyValuePair<string, string>> result = null;

            Execute(() => result = interpreter.Parse(data));

            // assert
            Assert.Equal(expectedBlock, result.Count);

            foreach (var message in result)
            {
                Logger.WriteLine("{0}: {1}", message.Key, message.Value);
            }
        }

        [Theory]
        [InlineData("F01VSDSVNXXAXXX2222123456", "", "F01VSDSVNXXAXXX2222123456")]
        [InlineData("NEWM<BrLine>:98A:PREP//20160518", "", "")]
        public void TrimAllEndTest(string value, string trimText, string expected)
        {
            var result = value.TrimEndAll(trimText);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("F01VSDSVNXXAXXX2222123456", "F01", "", "VSDSVNXXAXXX2222123456")]
        [InlineData("F01VSDSVNXXAXXX2222123456", "F01", "2222", "VSDSVNXXAXXX")]
        [InlineData("F01VSDSVNXXAXXX2222123456", "XX", "A", "")]
        [InlineData("<BrLine>:16R:GENL<BrLine>:20C::SEME//0167673516<BrLine>:23G:NEWM<BrLine>:98A::PREP//20161202<BrLine>:16R:LINK<BrLine>:13A::LINK//<BrLine>:20C::RELA//NONREF<BrLine>:16S:LINK<BrLine>:16R:LINK <BrLine>:20C::CORP//12345678<BrLine>:16S:LINK<BrLine>:16S:GENL<BrLine>:16R:TRADDET<BrLine>:98A::ESET//20161202<BrLine>:35B:/VN//RHTS/XYZ<BrLine>:16R:FIA<BrLine>:12A::CLAS//CORP/1<BrLine>:16S:FIA<BrLine>:70E::SPRO//DENC<BrLine>:16S:TRADDET<BrLine>:16R:FIAC<BrLine>:36B::ESTT//UNIT/15<BrLine>:95P::ACOW//VSDFPTSX<BrLine>:97A::SAFE//058C613846<BrLine>:16S:FIAC<BrLine>:16R:SETDET<BrLine>:22F::SETR//ISSU <BrLine>:16R:SETPRTY<BrLine>:95P::PSET//VSDSVN02<BrLine>:16S:SETPRTY<BrLine>:16R:SETPRTY<BrLine>:95P::DEAG//VSDFPTSX <BrLine>:16S:SETPRTY<BrLine>:16S:SETDET<BrLine>",
            ":13A::LINK//", "<BrLine>", "")]
        public void BetweenTest(string value, string start, string end, string expected)
        {
            int index;
            var result = value.Between(start, end, 0, out index);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("/UNIT/19780", "/", 4, "UNIT")]
        [InlineData("NEWM<BrLine>:98A:PREP//20160518", "/", 8, "20160518")]
        public void SubstringWithTrim(string data, string trimed, int length, string expected)
        {
            var result = data.SubStringWithTrimStart(trimed, 0, length);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SerializedCsBagWithJson()
        {
            var data = "  [{\"Key\":\"Id\",\"Value\":\"cb53eb16-c19e-44ff-e253-08d527115e52\"},{\"Key\":\"CustomerNumber\",\"Value\":\"2222222222\"},{\"Key\":\"FullNameLocal\",\"Value\":\"A Test\"},{\"Key\":\"Type\",\"Value\":2},{\"Key\":\"BirthDay\",\"Value\":\"1977-11-06T00:00:00\"},{\"Key\":\"Genere\",\"Value\":1},{\"Key\":\"CardType\",\"Value\":\"CCPT\"},{\"Key\":\"CardIdentity\",\"Value\":\"25\"},{\"Key\":\"CardIssuedDate\",\"Value\":\"2015-01-01T00:00:00\"},{\"Key\":\"CardIssuer\",\"Value\":\"sdf\"},{\"Key\":\"NationalityCode\",\"Value\":\"DZ\"},{\"Key\":\"TaxCode\",\"Value\":null},{\"Key\":\"Level\",\"Value\":0},{\"Key\":\"Status\",\"Value\":3},{\"Key\":\"Address\",\"Value\":\"Test\"},{\"Key\":\"City\",\"Value\":\"Hcm\"},{\"Key\":\"CountryCode\",\"Value\":\"VN\"},{\"Key\":\"Notes\",\"Value\":null},{\"Key\":\"BrokerId\",\"Value\":null},{\"Key\":\"Email\",\"Value\":\"adfs@sdfsd.ds\"},{\"Key\":\"PhoneNumber\",\"Value\":\"09852222\"},{\"Key\":\"UserName\",\"Value\":\"2222222222\"},{\"Key\":\"Password\",\"Value\":null},{\"Key\":\"PinCode\",\"Value\":\"ZWNmOTU5\"},{\"Key\":\"FullName\",\"Value\":\"A Test\"},{\"Key\":\"BranchId\",\"Value\":1},{\"Key\":\"IsActive\",\"Value\":false},{\"Key\":\"CreatedDate\",\"Value\":\"2017-11-09T08:30:07.4592931\"},{\"Key\":\"ModifiedDate\",\"Value\":null},{\"Key\":\"CreatedById\",\"Value\":null},{\"Key\":\"ModefiledById\",\"Value\":null},{\"Key\":\"Version\",\"Value\":0},{\"Key\":\"LanguageCode\",\"Value\":\"en\"},{\"Key\":\"Role\",\"Value\":4},{\"Key\":\"UserType\",\"Value\":0},{\"Key\":\"Broker\",\"Value\":null},{\"Key\":\"Branch\",\"Value\":null},{\"Key\":\"RequestDate\",\"Value\":\"2017-11-11T00:00:00+07:00\"},{\"Key\":\"AccountProcessInstruction\",\"Value\":\"AOPN\"},{\"Key\":\"BusinessId\",\"Value\":\"VSD_1_1_DongMoTK\"},{\"Key\":\"OutReferenceNumber\",\"Value\":10},{\"Key\":\"Proprietary\",\"Value\":\"NORMAL\"},{\"Key\":\"MessageFunction\",\"Value\":\"NEWM\"},{\"Key\":\"MessagePriority\",\"Value\":\"N\"},{\"Key\":\"DeliveryMonitor\",\"Value\":\"2\"},{\"Key\":\"ReceiverBicode\",\"Value\":\"VSDSVN01XXXX\"}]";
            var items = JsonConvert.DeserializeObject<List<CsBagItem>>(data);
            var bag = new CsBag(items);
            foreach (var item in bag)
            {
                Logger.WriteLine("[{0}] = {1}", item.Key, item.Value);
            }

            var deserialized = JsonConvert.SerializeObject(bag);
            Logger.WriteLine("JSON: {0}", deserialized);
            var dBag = JsonConvert.DeserializeObject<IList<CsBagItem>>(deserialized);
            foreach (var item in dBag)
            {
                Logger.WriteLine("[{0}] = {1}", item.Key, item.Value);
            }
        }

        [Fact]
        public void SerializedWithProtoBuf()
        {
            var customer = new CustomerModel
            {
                FullName = "Nguyen Thanh Vinh",
                UserName = "vinh",
                Email = "abc@adf.com",
                Address = "Đà Nẵng - Việt Nam"
            };

            Logger.WriteLine($"Model: {JsonConvert.SerializeObject(customer)}");
            

            var content = customer.Base64ProtoBufSerialize();
            Logger.WriteLine($"Content: {content}");
           

            var type = Type.GetType(customer.GetType().AssemblyQualifiedName);
            Logger.WriteLine($"Type: {type.FullName}");

            var deserialized = content.Base64ProtoBufDeserialize(type);
            Logger.WriteLine($"Deserialized: {JsonConvert.SerializeObject(deserialized)}");

            //deserialized.AsSource().OfLikeness<CustomerModel>().ShouldEqual(customer);

            deserialized = content.Base64ProtoBufDeserialize<CustomerModel>();
            Logger.WriteLine($"Deserialized 2: {JsonConvert.SerializeObject(deserialized)}");

            deserialized.AsSource().OfLikeness<CustomerModel>().ShouldEqual(customer);
        }

        [Theory] 
        [InlineData("CgVhZG1pbhIFY3NvZnQ=", typeof(CredentialLoginModel))]
        public void Deserialized(string content, Type type)
        {
            var obj = content.Base64ProtoBufDeserialize(type);
            Logger.WriteLine(content + ": " + JsonConvert.SerializeObject(obj));

            var typeModel = TypeModel.Create();
            byte[] byteAfter64 = Convert.FromBase64String(content);
            using (var st = new MemoryStream(byteAfter64))
            {
                typeModel.UseImplicitZeroDefaults = false;
                object result = typeModel.Deserialize(st, null, type);

                Logger.WriteLine(content + ": " + JsonConvert.SerializeObject(obj));
            }
        }
    }
}
