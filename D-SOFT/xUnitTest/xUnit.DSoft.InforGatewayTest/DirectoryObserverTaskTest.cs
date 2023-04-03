using DSoft.Common.Shared;
using DSoft.Common.Shared.Interfaces;
using DSoft.InforGateway;
using DSoft.MarketParser;
using DSoft.MarketParser.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using xUnit.DSoft.CommonTest;
using Xunit.Abstractions;

namespace xUnit.DSoft.InforGatewayTest
{
    public class DirectoryObserverTaskTest : TestBase<InforGatewayParserFixtureSetup>
    {
        public DirectoryObserverTaskTest(InforGatewayParserFixtureSetup fixtureSetup, ITestOutputHelper output) : base(fixtureSetup, output)
        {
        }

        [Fact]
        public void GWProcessMessage()
        {
            // RegisterComponents
            // fixture 
            Fixture.Register(RegisterComponents);
            // setup
            var sut = Fixture.Resolve<ITargetTask>();
            // start up api provider      
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            Execute(() =>
            {
                try
                {
                    sut.Start(token);
                }
                catch (Exception ex)
                {
                    sut.Stop();
                    throw ex;
                }
                // print bag

            });
        }
        private void RegisterComponents(IServiceCollection services)
        {
            services.AddSingleton<IHoseMessageConverter, PrsMessageConverter>();
            services.AddDistributedMemoryCache();
            services.AddSession();
            //  register all services  
            services.AddSingleton<IDirectoryObservationService, DirectoryObservationService>();
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IFileTransformerProvider, PhysicalFileTransformerProvider>();
            services.AddSingleton<IHoseMessageConverter, PrsMessageConverter>();
            // register all execution task                               
            services.AddSingleton<ITargetTask, HsxMarketObserverTask>();
        }
    }
}