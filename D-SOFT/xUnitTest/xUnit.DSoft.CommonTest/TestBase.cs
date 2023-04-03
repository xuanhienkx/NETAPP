using System.Diagnostics;
using Xunit.Abstractions;

namespace xUnit.DSoft.CommonTest;

public abstract class TestBase<T> : IClassFixture<T> where T : FixtureSetup
{
    protected readonly ITestOutputHelper Logger;
    protected readonly T Fixture;
    protected readonly string SettingPath;
    protected readonly string DataPath;

    protected TestBase(T fixtureSetup, ITestOutputHelper output)
    {
        Logger = output ?? throw new ArgumentNullException(nameof(output));
        Fixture = fixtureSetup ?? throw new ArgumentNullException(nameof(fixtureSetup));
        SettingPath = Fixture.Configuration["gateway:settingPath"];
        DataPath = Fixture.Configuration["gateway:dataPath"];

        Fixture.Logger = output;
    }

    protected void Execute(Action action)
    {
        var timer = new Stopwatch();
        timer.Start();
        Logger.WriteLine("Begin Executed ");
        action();

        timer.Stop();
        Logger.WriteLine("End Executed in: {0:N0}ms", timer.ElapsedMilliseconds);
    }
}
