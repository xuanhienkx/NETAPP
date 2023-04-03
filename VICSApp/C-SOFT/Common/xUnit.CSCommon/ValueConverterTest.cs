using CS.Common.Converter;
using CS.Common.Extensions;
using CS.Common.Interfaces;
using CS.Common.Std.Configuration;
using CS.Common.Std.Extensions;
using CS.SwiftParser;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace xUnit.CSCommon
{
    public class ValueConverterTest : TestBase<CommonFixtureSetup>
    {

        public ValueConverterTest(CommonFixtureSetup commonFixtureSetup, ITestOutputHelper output)
            : base(commonFixtureSetup, output)
        {
        }

        [Theory]
        [InlineData("B?ar?o Talas hi?eej?n c?as?ch b?owf? bi?eer?n Thanh H?os?a - H?af? T?ix?nh 160 km, c?as?c ph?uw??ow?ng ?as?n ?uws?ng ph?os? ?dd??ar? ho?af?n th?af?nh tr?uw??ows?c 17h h?oo?m nay", "Bảo Talas hiện cách bờ biển Thanh Hóa - Hà Tĩnh 160 km, các phương án ứng phó đả hoàn thành trước 17h hôm nay")]
        // [InlineData("M?aas?t c?ar? ?dd??oos?ng th?owf?i gian ng?oof?i search, ch?awr?ng t?if?m ?dd??uw??owj?c c?as?ch n?af?o cho ra h?oof?n, ?dd??af?nh ph?ar? l?af?m c?as?ch m?if? ?aw?n li?eef?n","")]
        [InlineData("?DD??OWF?I L?AF? TH?EES?", "ĐỜI LÀ THẾ")]
        public void StringValueConvertTest(string data, string expected)
        {
            // fixture 
            Fixture.Register(services =>
            {
                // register all services 
                services.AddSingleton<IStringEncoder, LatinStringEncode>();
                services.AddSingleton<IValueConverter, NullValueConverter>();
                services.Decorate<IValueConverter>((inner, p) => new StringValueConverter(inner, p.GetService<IStringEncoder>()));

            });
            // setup
            var sut = Fixture.Resolve<IValueConverter>();
            var result = sut.Parse(data, CSValueType.String, string.Empty);
            Logger.WriteLine($"{result}");
            Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData("05/06/2017", "dd/MM/yyyy")]
        [InlineData("20170605", "yyyyMMdd")]
        [InlineData("010515", "yyMMdd")]
        [InlineData("010515", "ddMMyy")]
        [InlineData("1511010606", "yyMMddHHmm")]
        [InlineData("20140314 17:28:37", "yyyyMMdd HH:mm:ss")]
        [InlineData("17:28:00", "HH:mm:ss")]
        public void DateValueConvertTest(string data, string format)
        {
            // fixture 
            Fixture.Register(services =>
            {
                // register all services   
                services.AddSingleton<IValueConverter, NullValueConverter>();
                services.Decorate<IValueConverter>(inner => new DateValueConverter(inner));

            });
            // setup
            var sut = Fixture.Resolve<IValueConverter>();
            var result = sut.Parse(data, CSValueType.Date, format);
            Logger.WriteLine($"{result}");
            Assert.IsType<DateTime>(result);
        }
        [Theory]
        [InlineData("13:15", "HH:mm")]
        [InlineData("0615", "HHmm")]
        [InlineData("15.15.12", "HH.mm.ss")]

        public void TimeValueConvertTest(string data, string format)
        {
            // fixture 
            Fixture.Register(services =>
                {
                    // register all services   
                    services.AddSingleton<IValueConverter, NullValueConverter>();
                    services.Decorate<IValueConverter>(inner => new TimeValueConverter(inner));

                });

            // setup

            var sut = Fixture.Resolve<IValueConverter>();
            var result = sut.Parse(data, CSValueType.Time, format);
            Logger.WriteLine($"{result}");
            Assert.IsType<TimeSpan>(result);
            var result2 = sut.ToString(result, CSValueType.Time, format);
            Logger.WriteLine(result2);
            Assert.Equal(data, result2);

        }
        public static IEnumerable<object[]> AllTestToStringConvert => new List<object[]>
        {
            new object[]{ 3, CSValueType.Date },
            new object[]{ DateTime.Now, CSValueType.String },
            new object[]{ 4.5F, CSValueType.Integer },
            new object[]{ "TestDecimal", CSValueType.Decimal },
            new object[]{ "As time", CSValueType.Time }
        };

        public static IEnumerable<object[]> AllTestInvalidCast => new List<object[]>
        {
            new object[]{ 3, CSValueType.Date },
            new object[]{ DateTime.Now, CSValueType.String },
            new object[]{ 4.5F, CSValueType.Integer },
            new object[]{ "TestDecimal", CSValueType.Decimal },
            new object[]{ "As time", CSValueType.Time }
        };


        [Theory]
        [MemberData(nameof(AllTestInvalidCast))]
        public void InvalidCastValueConverterTest(object value, CSValueType type)
        {
            // fixture 
            Fixture.Register(services =>
            {
                // register all services   
                services.AddSingleton<IStringEncoder, LatinStringEncode>();
                services.AddScoped<IValueConverter, NullValueConverter>();
                services.Decorate<IValueConverter>(inner => new TimeValueConverter(inner));
                services.Decorate<IValueConverter>(inner => new DateValueConverter(inner));
                services.Decorate<IValueConverter>(inner => new NumberValueConverter(inner));
                services.Decorate<IValueConverter>(inner => new DecimalValueConverter(inner));
                services.Decorate<IValueConverter>((inner, p) => new StringValueConverter(inner, p.GetService<IStringEncoder>()));

            });

            // setup
            var sut = Fixture.Resolve<IValueConverter>();

            Assert.Throws<InvalidCastException>(() => sut.ToString(value, type, string.Empty));

        }
        [Theory]
        [InlineData("4294967296")]
        public void NumberValueConvertTest(string data)
        {
            // fixture 
            Fixture.Register(services =>
            {
                // register all services   
                services.AddSingleton<IValueConverter, NullValueConverter>();
                services.Decorate<IValueConverter>(inner => new NumberValueConverter(inner));

            });
            // setup

            var sut = Fixture.Resolve<IValueConverter>();
            var result = sut.Parse(data, CSValueType.Integer, string.Empty);
            Assert.Equal(0x100000000, result);

        }
        [Theory]
        [InlineData("123456.15")]
        public void DecimalValueConvertTest(string data)
        {
            // fixture 
            Fixture.Register(services =>
            {
                // register all services   
                services.AddSingleton<IValueConverter, NullValueConverter>();
                services.Decorate<IValueConverter>(inner => new DecimalValueConverter(inner));

            });
            // setup
            decimal t = (decimal)123456.15;
            var sut = Fixture.Resolve<IValueConverter>();
            var result = sut.Parse(data, CSValueType.Decimal, string.Empty);
            Assert.Equal(t, result);
        }
        [Fact]
        public void NullValueConvertTest()
        {
            // fixture 
            Fixture.Register(services =>
            { // register all services   
                services.AddSingleton<IValueConverter, NullValueConverter>();
            });
            // setup
            var sut = Fixture.Resolve<IValueConverter>();
            //var result = sut.Parse("", CSValueType.Testnull, string.Empty);
            //Assert.Null(result);
        }

        [Fact]
        public void ReleaceStringTest()
        {
            var stringTest =
                "Khi tàu đang thả trôi, bất ngờ tàu nước ngoài áp sát phía sau, với khoảng 30 người mặc quân phục la lối."; 
            var result = stringTest.ReplaceWithString(" ", Environment.NewLine, 20); 
            Logger.WriteLine(result);
        }
    }
}