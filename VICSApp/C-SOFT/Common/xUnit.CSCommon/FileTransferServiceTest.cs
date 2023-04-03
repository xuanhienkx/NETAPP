using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CS.Common;
using CS.Common.Converter;
using CS.Common.Extensions;
using CS.Common.FileTransfer;
using CS.Common.Interfaces;
using CS.SwiftParser;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace xUnit.CSCommon
{
    public class FileTransferServiceTest : TestBase<CommonFixtureSetup>
    {
        public FileTransferServiceTest(CommonFixtureSetup fixtureSetup, ITestOutputHelper output)
            : base(fixtureSetup, output)
        {

        }

        [Theory]
        [InlineData("archive", "ftp://10.10.5.230/VSDGateway/", "vics", "v|cs")]
        [InlineData("test/archive/abc", "ftp://10.10.5.230/VSDGateway/", "vics", "v|cs")]
        [InlineData("archive/test/", "C:\\Test", "", "")]
        [InlineData("archive/test/", "Z:\\", "", "")]
        public void EnsurePathTest(string path, string root, string username, string password)
        {
            // fixture 
            Fixture.Register(services =>
            {
                // register all services 
                if (root.ToLowerInvariant().StartsWith("ftp://"))
                    services.AddTransient<IFileTransformerProvider, FtpFileTransformerProvider>();
                else
                    services.AddTransient<IFileTransformerProvider, PhysicalFileTransformerProvider>();
            });
            // setup
            Fixture.Configuration["gateway:root:path"] = root;
            Fixture.Configuration["gateway:root:userName"] = username;
            Fixture.Configuration["gateway:root:password"] = password;

            var sut = Fixture.Resolve<IFileTransformerProvider>();

            // exercise
            sut.EnsurePath(path);

            // assert
            //Assert.True();
        }

        //[Theory]
        //[InlineData("ftp://10.10.5.230/VSDGateway/archive", "vics", "v|cs")]
        //public async Task TransferTest(string archivePath, string username, string password)
        //{
        //    // fixture 
        //    Fixture.Register(services =>
        //    {
        //        services.AddTransient<IFileTransformerProvider, FtpFileTransformerProvider>();
        //        services.AddTransient<IFileTransformerProvider, PhysicalFileTransformerProvider>();
        //        services.AddSingleton<IFileService, FileService>();
        //    });
        //    // setup
        //    var sut = Fixture.Resolve<IFileTransformerProvider>();

        //    // exercise
        //    //var result = await sut.(from, toPath, false);

        //    //// assert
        //    //Logger.WriteLine("Result: {0}", result);
        //    //Assert.True(result);
        //}
    }
}
