using DO.Common;
using DO.Common.Std.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace xUnit.DO.CommonTest;

public abstract class FixtureSetup : IDisposable
{
    public readonly IConfigurationRoot Configuration;
    private IServiceProvider serviceProvider;
    protected FixtureSetup()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();


        Configuration = builder.Build();
    }

    public ITestOutputHelper Logger { get; set; }

    private bool isRegistered;
    public void Register(Action<IServiceCollection> register, bool guard = false)
    {
        if (guard && isRegistered)
            return;

        Initialize();

        var services = new ServiceCollection();
        services.AddLogging(builder =>
        {
            builder.AddProvider(new XunitLoggerProvider(Logger));
            builder.SetMinimumLevel(LogLevel.Trace);
        });
        services.AddSingleton(Configuration);
        register(services);
        serviceProvider = services.BuildServiceProvider();
        isRegistered = true;
    }

    public T Resolve<T>()
    {
        return serviceProvider.GetService<T>();
    }

    public T LoadTestData<T>(string fileName)
        where T : class
    {
        var samplePath = Configuration["samplePath"];
        var file = Path.Combine(samplePath, "TestData", fileName);

        if (typeof(T) == typeof(CsBag))
            return ConvertToCsBag(file) as T;
        return ObjectLoader.FromFile<T>(file);
    }

    private CsBag ConvertToCsBag(string file)
    {
        var data = ObjectLoader.FromFile<IDictionary<string, string>>(file);
        var result = new CsBag();
        foreach (var it in data)
        {
            if (it.Value.StartsWith("Date#", StringComparison.OrdinalIgnoreCase))
            {
                DateTime date;
                if (DateTime.TryParse(it.Value.TrimStartAll("Date#"), out date))
                {
                    result[it.Key] = date;
                    continue;
                }
            }

            if (it.Value.StartsWith("Time#", StringComparison.OrdinalIgnoreCase))
            {
                TimeSpan time;
                if (TimeSpan.TryParse(it.Value.TrimStartAll("Time#"), out time))
                {
                    result[it.Key] = time;
                    continue;
                }
            }

            if (it.Value.StartsWith("Number#", StringComparison.OrdinalIgnoreCase))
            {
                result[it.Key] = long.Parse(it.Value.TrimStartAll("Number#"));
                continue;
            }

            result[it.Key] = it.Value;
        }

        return result;
    }

    protected abstract void Initialize();
    protected abstract void TearDown();
    public void Dispose()
    {
        TearDown();
    }
}
