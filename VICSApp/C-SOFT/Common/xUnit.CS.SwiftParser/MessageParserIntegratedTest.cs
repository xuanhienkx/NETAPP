using CS.Common;
using CS.Common.Converter;
using CS.Common.Extensions;
using CS.Common.Interfaces;
using CS.SwiftParser;
using CS.SwiftParser.Configuration;
using CS.SwiftParser.MessageBuilder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using CS.Common.Std;
using xUnit.CSCommon;
using Xunit;
using Xunit.Abstractions;

namespace xUnit.CS.SwiftParser
{
    public class MessageParserIntegratedTest : TestBase<SwiftParserFixtureSetup>
    {
        public MessageParserIntegratedTest(SwiftParserFixtureSetup fixture, ITestOutputHelper output)
            : base(fixture, output)
        {
        }

        #region Read Message 

        [Theory]
/*        [InlineData("ActSample.fin", "ActSample.json")]
        [InlineData("NakSample.fin", "NakSample.json")]
        [InlineData("NakSample1.fin", "NakSample1.json")]
        [InlineData("NakSample2.fin", "NakSample2.json")]*/
        [InlineData("20171102-101747378-3.fin", "NakSample2.json")]
        public void ReadAckNak(string fileName, string expectedFile)
        {
            ReadFinMessage(fileName, expectedFile);
        }

        [Theory]
        [InlineData("MT598_Thong bao huy ma ck.fin", "MT598_Thong bao huy ma ck.json")]
        [InlineData("MT598_Thong bao dang ky ma ck moi 2081.fin", "MT598_Thong bao dang ky ma ck moi 2081.json")]
        [InlineData("MT598_Thong bao dang ky ma ck moi 2081ISIN.fin", "MT598_Thong bao dang ky ma ck moi 2081ISIN.json")]
        [InlineData("MT598_Thong bao Dang ky luu ky ck moi 2001.fin", "MT598_Thong bao Dang ky luu ky ck moi 2001.json")]
        [InlineData("MT598_Thong bao Dang ky ck bo sung 2001.fin", "MT598_Thong bao Dang ky ck bo sung 2001.json")]
        [InlineData("MT598_Thong bao Dang ky luu ky ck moi 2001ISIN.fin", "MT598_Thong bao Dang ky luu ky ck moi 2001ISIN.json")]
        [InlineData("MT598_Thong bao ck chuyen san.fin", "MT598_Thong bao ck chuyen san.json")]
        public void MT598_ReadMessage(string fileName, string expectedFile)
        {
            ReadFinMessage(fileName, expectedFile);
        }

        [Theory]
        [InlineData("MT544-Chuyen nhuong quyen mua.fin", "MT544-Chuyen nhuong quyen mua.json")]
        [InlineData("MT544-Thong bao hach toan tang tai khoan(P).fin", "MT544-Thong bao hach toan tang tai khoan(P).json")]
        [InlineData("MT544-Thong bao hach toan tang tai khoan(Q).fin", "MT544-Thong bao hach toan tang tai khoan(Q).json")]
        [InlineData("MT544-Chuyen nhuong quyen mua khac TVLK.fin", "MT544-Chuyen nhuong quyen mua khac TVLK.json")]
        [InlineData("MT544-Xac nhan yeu cau ky gui chung khoan thanh cong.fin", "MT544-Xac nhan yeu cau ky gui chung khoan thanh cong.json")]
        [InlineData("MT544--Thong bao hach toan tang tai khoan doi voi ben nhan.fin", "MT544--Thong bao hach toan tang tai khoan doi voi ben nhan.json")]
        public void MT544_ReadMessage(string fileName, string expectedFile)
        {
            ReadFinMessage(fileName, expectedFile);
        }

        [Theory]
        //Chuyển nhượng quyền mua
        //[InlineData("MT546-Chuyen nhuong quyen mua.fin", "MT546-Chuyen nhuong quyen mua.json", "036D051D-C61E-47FF-889E-C5E8C60889BE")]
        //[InlineData("MT546_xac nhan yeu cau chuyen khoan tat toan.fin", "MT546_xac nhan yeu cau chuyen khoan tat toan.json", "F7D2FB50-2D2B-4C43-AA7D-855A131E9445")]//MT546 - Xác nhận yêu cầu chuyển khoản tất toán thành công
        //[InlineData("MT546_xac nhan chuyen chung khoan thanh cong.fin", "MT546_xac nhan chuyen chung khoan thanh cong.json", "EE7F42B3-9C22-419B-AB15-2B5B03179BC8")]//MT546 - Xác nhận yêu cầu Chuyển khoản chứng khoán thành công
        //[InlineData("MT546_Rut chung khoan do huy dang ky.fin", "MT546_Rut chung khoan do huy dang ky.json", "0896E1CF-5A5B-4861-822B-B544DD569E86")]//MT546 – Thông báo hạch toán giảm tài khoản do hủy đăng ký
        [InlineData("MT546_xac nhan rut chung khoan thanh cong.fin", "MT546_xac nhan rut chung khoan thanh cong.json")]//, "156CF623-438B-40EA-94BA-91F6D4845145")]//Ký gửi chứng khoán thông thường (có yêu cầu  từ TVLK)
        public void MT546_ReadMessage(string fileName, string expectedFile)
        {
            ReadFinMessage(fileName, expectedFile);
        }
        //[Theory]
        //[InlineData("MT548_Tu choi chuyen nhuong quyen mua.fin", "MT548_Tu choi chuyen nhuong quyen mua.json", "036D051D-C61E-47FF-889E-C5E8C60889BE")]//Chuyển nhượng quyền mua
        //[InlineData("MT548_Tu choi giai toa chung khoan.fin", "MT548_Tu choi giai toa chung khoan.json", "94C96257-0F80-46A8-ACAF-5EBF2ABE8A88")]//Phong tỏa và giải tỏa chứng khoán
        //[InlineData("MT548_Tu choi tat toan tai khoan.fin", "MT548_Tu choi tat toan tai khoan.json", "55B446A3-E311-4BB0-B1DE-2795B57FB9AA")]//Tất toán tài khoản giao dịch/Chuyển khoản toàn bộ chứng khoán
        //[InlineData("MT548_Tu choi chuyen chung khoan.fin", "MT548_Tu choi chuyen chung khoan.json", "EE7F42B3-9C22-419B-AB15-2B5B03179BC8")]//MT548  - Từ chối yêu cầu chuyển khoản chứng khoán
        //[InlineData("MT548_Tu choi rut chung khoan.fin", "MT548_Tu choi rut chung khoan.json", "156CF623-438B-40EA-94BA-91F6D4845145")]//Rút chứng khoán thông thường (có yêu cầu từ TVLK)
        //[InlineData("MT548_Tu choi yeu cau ky gui chung khoan.fin", "MT548_Tu choi yeu cau ky gui chung khoan.json", "55B446A3-E311-4BB0-B1DE-2795B57FB9AA")]//Ký gửi chứng khoán thông thường (có yêu cầu 
        //public void MT548_ReadMessage(string fileName, string expectedFile, string businessId)
        //{
        //    ReadFinMessage(fileName, expectedFile);
        //}

        [Theory]
        [InlineData("MT508_Thong bao thay doi trang thai chung khoan.fin", "MT508_Thong bao thay doi trang thai chung khoan.json")]
        [InlineData("MT508_xac nhan phong toa giai toa.fin", "MT508_xac nhan phong toa giai toa.json")]
        public void MT508_ReadMessage(string fileName, string expectedFile)
        {
            ReadFinMessage(fileName, expectedFile);
        }

        [Theory]
        //[InlineData("20171106-033358586-16.fin", "MT564_CAEVMEET-Dai hoi co đong thuong nien.json")]
        [InlineData("20171106-033408024-17.fin", "MT564_CAEVMEET-Dai hoi co đong thuong nien.json")]
        [InlineData("20171107-094203752-19.fin", "MT564_CAEVMEET-Dai hoi co đong thuong nien.json")]
        [InlineData("20171107-094335979-20.fin", "MT564_CAEVMEET-Dai hoi co đong thuong nien.json")]
        //[InlineData("MT564-CAEVDVCA-Quyen Chia co tuc bang tien.fin", "MT564-CAEVDVCA-Quyen Chia co tuc bang tien.json")]
        //[InlineData("MT564-CAEVDVSE-Quyen Chia co tuc bang co phieu.fin", "MT564-CAEVDVSE-Quyen Chia co tuc bang co phieu.json")]
        //[InlineData("MT564-CAEVRHTS-Quyen Mua ck.fin", "MT564-CAEVRHTS-Quyen Mua ck.json")]
        public void MT564_ReadMessage(string fileName, string expectedFile)
        {
            ReadFinMessage(fileName, expectedFile);
        }

        [Theory]
        [InlineData("MT566_xac nhan dat mua thanh cong.fin", "MT566_xac nhan dat mua thanh cong.json")]//MT566 - Xác nhận yêu cầu đặt mua thành công
        public void MT66_ReadMessage(string fileName, string expectedFile)
        {
            ReadFinMessage(fileName, expectedFile);
        }
        [Theory]
        [InlineData("MT567_Tu choi yeu cau dat mua.fin", "MT567_Tu choi yeu cau dat mua.json")]//MT566 - Xác nhận yêu cầu đặt mua thành công
        public void MT67_ReadMessage(string fileName, string expectedFile)
        {
            ReadFinMessage(fileName, expectedFile);
        }
        [Theory]
        [InlineData("MT540_Luu ky chung khoan cho giao dich.json", "MT540 - Luu ky ck cho GD.fin")]
        [InlineData("MT540_Luu ky chung khoan.json", "MT540_Luu ky chung khoan.fin")]
        public void MT540_BuildMessage(string fileName, string expectedFile)
        {
            BuildFinMessage(fileName, expectedFile);
        }

        #endregion

        #region Build Message 

        [Theory]
        [InlineData("MT542_Rutluukychungkhoan.json", "MT542_rut luu ky ck.fin")]
        [InlineData("MT542_Rutluukychungkhoan_full.json", "MT542_rut luu ky ck fullTag.fin")]
        [InlineData("MT542_Chuyen khoan chung khoan.json", "MT542_Chuyen khoan chung khoan.fin")]
        [InlineData("MT542_Yeu cau chuyen nhuong quyen mua.json", "MT542_Chuyen nhuong quyen mua.fin")]
        public void MT542_BuildMessage(string fileName, string expectedFile)
        {
            BuildFinMessage(fileName, expectedFile);
        }

        [Theory]
        [InlineData("MT565_Dang ky dat mua.json", "MT565_Dang ky dat mua.fin")]
        public void MT565_BuildMessage(string fileName, string expectedFile)
        {
            BuildFinMessage(fileName, expectedFile);
        }
        [Theory]
        [InlineData("MT524_Cam co chung khoan.json", "MT524_Cam co chung khoan.fin")]
        [InlineData("MT524-Giai toa cam co.json", "MT524-Giai toa cam co.fin")]
        public void MT524_BuildMessage(string fileName, string expectedFile)
        {
            BuildFinMessage(fileName, expectedFile);
        }


        [Theory]
        [InlineData("MT598_Mo tai khoan.json", "MT598_Mo tai khoan.fin")]
        [InlineData("MT598_Dong tai khoan.json", "MT598_Dong tai khoan.fin")]
        [InlineData("MT598_Yeu cau tat toan tai khoan.json", "MT598_Tat toan tai khoan.fin")]
        [InlineData("MT598_Yeu cau bao cao DE084.json", "MT598_Yeu cau bao cao DE084.fin")]
        [InlineData("MT598_Xac nhan danh sach phan bo quyen.json", "MT598_xac nhan bao cao THQ.fin")]
        [InlineData("MT598_Xac nhan so du chung khoan.json", "MT598_XacNhanThongBaoSDCK.fin")]
        [InlineData("MT598_Xac nhan ket qua giao dich.json", "MT598_XacNhanThongBaoKQGD.fin")]
        public void MT598_BuildMessage(string fileName, string expectedFile)
        {
            BuildFinMessage(fileName, expectedFile);
        }
        #endregion

        #region Read FileACT


        [Theory]
        //[InlineData("FileAct/tvg'DE164'01+0154777376-02+13042016-04+0002-'15042016'183754'152795.par", "DE164.json")]
        //[InlineData("FileAct/tvg'CA001'01+0155703165-03+GMD-03+GMD-04+28042016-09+037-09+037-'06052016'151450'160886.par", "CA001.json")]
        //[InlineData("FileAct/tvg'CA005'01+0151013692-03+IDI-03+IDI-04+28012016-12+037-12+037-'10052016'170044'162145.par", "CA005.json")]
        //[InlineData("FileAct/tvg'CA009'01+0155948128-03+VCA-03+VCA-04+05052016-09+037-09+037-'06052016'092059'160524.par", "CA009.json")]
        //[InlineData("FileAct/bidv'CA012'01+0121272595-03+A11-03+A11-04+12022016-09+201-09+201-'16012017'110904'30965.par", "CA012.json")]
        //[InlineData("FileAct/bidv'CA014'01+0121272593-03+A11-03+A11-04+12022016-09+201-09+201-'13012017'150753'30902.par", "CA014.json")]
        [InlineData("FileAct/kls'CS078'01+019-03+07062017-'08062017'085343'523260.par", "CS078.json")]
        public void ReadFileAct(string fileName, string expectedFile)
        {
            ReadFinMessage(fileName, expectedFile);
        }

        #endregion

        #region Helpers

        private void RegisterComponents(IServiceCollection services)
        {
            var configFile = Path.Combine(this.Fixture.Configuration["gateway:settingPath"], "SwiftSettings.json");
            var swiftSetting = ObjectLoader.FromFile<SwiftSetting>(configFile);
            if (swiftSetting == null)
                throw new ArgumentNullException($"swiftConfig", $"Cannot load swiftsetting from path: {configFile}");

            // register all services
            services.AddSingleton(swiftSetting);
            services.AddSingleton<IStringEncoder, LatinStringEncode>();
            services.AddSingleton<IFieldConfigurator, FieldConfigurator>();
            services.AddScoped<IValueConverter, NullValueConverter>();
            services.Decorate<IValueConverter>(inner => new TimeValueConverter(inner));
            services.Decorate<IValueConverter>(inner => new DateValueConverter(inner));
            services.Decorate<IValueConverter>(inner => new NumberValueConverter(inner));
            services.Decorate<IValueConverter>(inner => new DecimalValueConverter(inner));
            services.Decorate<IValueConverter>((inner, p) => new StringValueConverter(inner, p.GetService<IStringEncoder>()));

            services.AddSingleton<IMessageConverter, MTMessageConverter>();
            services.AddSingleton<IMessageConverter, ACKNAKMessageConverter>();
            services.AddSingleton<IMessageConverter, FileActMessageConverter>();
            services.AddSingleton<IMessageBuilder, SwiftMessageBuilder>();
        }

        private void ReadFinMessage(string fileName, string expectedFile)
        {
            // fixture 
            Fixture.Register(RegisterComponents);
            // setup
            var sut = Fixture.Resolve<IMessageBuilder>();

            // excercise
            CsBag result = null;
            var file = Path.Combine(SamplePath, fileName);
            Execute(async () => result = await sut.Read<SwiftBag>(file, File.OpenRead(file)));

            // assertion
            PrintBag(result, expectedFile);
           // var expected = Fixture.LoadTestData<IDictionary<string, object>>(expectedFile);

            Assert.IsType<SwiftBag>(result);
           // CSAssert.DictionaryEquals(expected, result.GetDictionary(), Fixture.CsBagObjectComparison);
        }

        private void BuildFinMessage(string fileData, string expectedFile)
        {
            // fixture 
            Fixture.Register(RegisterComponents);

            // setup
            var bagValue = Fixture.LoadTestData<CsBag>(fileData);
            //PrintBag(bagValue);

            var sut = Fixture.Resolve<IMessageBuilder>();
            
            var memStream = new MemoryStream();
            Execute(() =>
            {
                sut.Write(memStream, bagValue);
            });

            var message = new StreamReader(memStream).ReadToEnd();
            Logger.WriteLine("Message: {0}{1}", Environment.NewLine, message);

            // excercise
            var expected = Fixture.LoadTestData(expectedFile, false);
            Assert.Equal(expected, message);
        }

        private void PrintBag(CsBag bag, string fileName = "")
        {
            IDictionary<string, object> bagToJson = new Dictionary<string, object>();
            foreach (var key in bag.Keys)
            {
                if (!key.Equals(BusinessIdProviderConstant.CsvData) || bag[key] == null)
                {
                    bagToJson.Add(key, bag[key]);
                    Logger.WriteLine("[{0}]: {1} - type: {2}", key, bag[key], bag[key].GetType().Name);
                }
                else
                {
                    var listBagCsvs = (List<CsBag>)bag[key];
                    foreach (var csBag in listBagCsvs)
                    {
                        Logger.WriteLine("[{0}]: [", BusinessIdProviderConstant.CsvData);
                        Logger.WriteLine("====================");
                        PrintBag(csBag, fileName);
                        Logger.WriteLine("====================]");
                        Logger.WriteLine("]");
                    }
                }

            }

            if (!string.IsNullOrEmpty(fileName))
            {
                string json = JsonConvert.SerializeObject(bagToJson, Formatting.Indented);
                var fileJsonResult = Path.Combine(SamplePath, "TestData", fileName);
                File.WriteAllText(fileJsonResult, json);
            }
        }

        #endregion
    }
}