using System;
using System.Diagnostics;
using System.IO;
using CS.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace xUnit.CSCommon
{
    public abstract class TestBase<T> : IClassFixture<T> where T : FixtureSetup
    {
        protected readonly ITestOutputHelper Logger;
        protected readonly T Fixture;
        protected readonly string VsdSettingPath;
        protected readonly string SamplePath;

        protected TestBase(T fixtureSetup, ITestOutputHelper output)
        {
            this.Logger = output ?? throw new ArgumentNullException(nameof(output));
            this.Fixture = fixtureSetup ?? throw new ArgumentNullException(nameof(fixtureSetup));
            this.VsdSettingPath = this.Fixture.Configuration["vsdSettingPath"];
            this.SamplePath = this.Fixture.Configuration["samplePath"];

            Fixture.Logger = output;
        }

        protected void Execute(Action action)
        {
            var timer = new Stopwatch();
            timer.Start();

            action();

            timer.Stop();
            Logger.WriteLine("Executed in: {0:N0}ms", timer.ElapsedMilliseconds);
        }
    }
}
