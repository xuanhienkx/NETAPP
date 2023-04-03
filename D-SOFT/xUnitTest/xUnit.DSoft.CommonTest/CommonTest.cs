using DSoft.Common.Extensions;
using DSoft.Common.Settings;
using DSoft.Common.Shared;
using DSoft.Common.Shared.Interfaces;
using DSoft.MarketParser;
using DSoft.MarketParser.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit.Abstractions;

namespace xUnit.DSoft.CommonTest;

public class CommonTest : TestBase<CommonFixtureSetup>
{
    public CommonTest(CommonFixtureSetup fixtureSetup, ITestOutputHelper output) : base(fixtureSetup, output)
    {
    }
    [Fact]
    public void CircuitThrowsException()
    {
        // setup
        var exceptionMethod = new Func<bool>(() => throw new Exception("Testing"));

        // exercise
        var attempt = 0;
        exceptionMethod.CircuitBreakerExecute(options =>
        {
            options.MaxAttemptFailure = 2;
            options.BreakerOpened = exception =>
            {
                Logger.WriteLine("BreakerOpened");
                attempt = options.Attempt;
            };
            options.UnkownException = exception => Logger.WriteLine("UnkownException");
        });

        // assert
        Assert.Equal(2, attempt);
    }

    [Fact]
    public void CircuitTimeout()
    {
        // setup
        var exceptionMethod = new Func<bool>(() =>
        {
            Thread.Sleep(20);
            return true;
        });

        // exercise
        var attempt = 0;
        exceptionMethod.CircuitBreakerExecute(options =>
        {
            options.MaxAttemptFailure = 2;
            options.ExecuteTimeOut = TimeSpan.FromMilliseconds(10);
            options.BreakerOpened = exception =>
            {
                Logger.WriteLine("BreakerOpened");
                attempt = options.Attempt;
            };
            options.UnkownException = exception => Logger.WriteLine("UnkownException");
            options.BreakerTimeout = exception => Logger.WriteLine("BreakerTimeout");
        });

        // assert
        Assert.Equal(2, attempt);
    }

    [Fact]
    public void CircuitFullTest()
    {
        var attempt = 0;

        // setup
        var exceptionMethod = new Func<string>(() =>
        {
            if (attempt < 2)
                throw new Exception($"Testing {attempt}");

            Logger.WriteLine($"...attempt: {attempt}");
            if (attempt < 4)
                Thread.Sleep(TimeSpan.FromMilliseconds(500));

            Logger.WriteLine($"oop! return at: {attempt}");
            return "Testing";
        });

        // exercise
        var result = exceptionMethod.CircuitBreakerExecute(options =>
        {
            options.MaxAttemptFailure = 5;
            options.ExecuteTimeOut = TimeSpan.FromMilliseconds(200);
            options.ResetTimeOut = TimeSpan.FromMilliseconds(300);
            options.BreakerOpened = exception =>
            {
                Logger.WriteLine($"BreakerOpened: {options.Attempt} - {exception.Message}");
                attempt = options.Attempt;
            };
            options.BreakerTimeout = exception =>
            {
                Logger.WriteLine($"BreakerTimeout: {options.Attempt} - {exception.Message}");
                attempt = options.Attempt;
            };
            options.UnkownException = exception =>
            {
                Logger.WriteLine($"UnkownException: {options.Attempt} - {exception.Message}");
                attempt = options.Attempt;
            };
        });
        Logger.WriteLine("-------");
        Logger.WriteLine($"Result with {attempt} attempt: {result}");

        // assert
        Assert.Equal("Testing", result);
        Assert.Equal(4, attempt);
    }
    [Fact]
    public void TestLookup()
    {
        // Create an array of strings.
        string[] array = { "cat", "dog", "horse", "abc", "cat" };

        // Generate a lookup structure,
        // ... where the lookup is based on the key length.
        var lookup = array.ToLookup(item => item.Length);

        // Enumerate strings of length 3.
        foreach (string item in lookup[3])
        {
            Logger.WriteLine("3 = " + item);
        }

        // Enumerate strings of length 5.
        foreach (string item in lookup[5])
        {
            Logger.WriteLine("5 = " + item);
        }

        // Enumerate groupings.
        foreach (var grouping in lookup)
        {
            Logger.WriteLine("Grouping: " + grouping.Key);
            foreach (var item in grouping)
            {
                Logger.WriteLine(item);
            }
        }

    }

    [Fact]
    public void RegisterTest()
    {
        Fixture.Register(services =>
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IPersistentDataProvider, PersistentDataProvider>();
            // configuration
            services.Configure<ApplicationSettings>(Fixture.Configuration.GetSection(nameof(ApplicationSettings)));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<ApplicationSettings>>().Value);
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<ICipherService, AesCipherService>();



            services.AddScoped<IHoseMessageConverter, PrsMessageConverter>();
        });

        var registrations = Fixture.Resolve<IPersistentDataProvider>();
        Assert.Equal(typeof(PersistentDataProvider), registrations.GetType());
    }

}

