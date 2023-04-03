using DO.Common.Converter;
using DO.Common.Extensions;
using DO.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace xUnit.DO.CommonTest;

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
            services.AddScoped<IValueConverter, NullValueConverter>();
            services.Decorate<IValueConverter>(inner => new DateValueConverter(inner));
            services.Decorate<IValueConverter>(inner => new TimeValueConverter(inner));
            services.Decorate<IValueConverter>((inner, p) => new StringValueConverter(inner, p.GetService<IStringEncoder>()));
            services.Decorate<IValueConverter>(inner => new NumberValueConverter(inner));

        });

        var registrations = Fixture.Resolve<IValueConverter>();
        Assert.Equal(typeof(NumberValueConverter), registrations.GetType());
    }
}
