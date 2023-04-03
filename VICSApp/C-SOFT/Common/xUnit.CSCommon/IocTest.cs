using System.Linq;
using CS.Common;
using CS.Common.Converter;
using CS.Common.Extensions;
using CS.Common.Interfaces;
using CS.SwiftParser;
using CS.SwiftParser.Configuration;
using CS.SwiftParser.MessageBuilder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace xUnit.CSCommon
{
    public class IocTest : TestBase<CommonFixtureSetup>
    {
        public IocTest(CommonFixtureSetup fixtureSetup, ITestOutputHelper output) 
            : base(fixtureSetup, output)
        {
        }

        [Fact]
        public void RegisterTest() 
        { 
            Fixture.Register(services =>
            {
                services.AddScoped<IStringEncoder, LatinStringEncode>();
                services.AddScoped<IValueConverter, NullValueConverter>();
                services.Decorate<IValueConverter>(inner => new DateValueConverter(inner));
                services.Decorate<IValueConverter>(inner => new TimeValueConverter(inner));
                services.Decorate<IValueConverter>((inner,p) => new StringValueConverter(inner, p.GetService<IStringEncoder>()));
                services.Decorate<IValueConverter>(inner => new NumberValueConverter(inner));

                services.AddScoped<IMessageConverter, MTMessageConverter>();
                services.AddScoped<IMessageBuilder, SwiftMessageBuilder>();
                services.AddScoped<SwiftSetting>();
            });

            var registrations = Fixture.Resolve<IMessageConverter>();
            Assert.Equal(typeof(MTMessageConverter), registrations.GetType()); 
        }
    }
}
