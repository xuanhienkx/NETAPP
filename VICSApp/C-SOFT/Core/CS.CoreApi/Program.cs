using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CS.CoreApi
{
    public class Program
    {
        static void Main(string[] args)
        {
            var process = Process.GetCurrentProcess();
            Console.Title = $"API service - PID: {process.Id}";

            try
            {
                BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var url = ParseArgument("-url", args, "http://+");
            var port = ParseArgument("-port", args, "8888");
            var hostUrl = $"{url}:{port}";

            Console.WriteLine($"Arguments: {args}");

            var host = WebHost.CreateDefaultBuilder()
                .UseUrls(hostUrl)
                .PreferHostingUrls(true)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            return host;
        }

        private static string ParseArgument(string argument, string[] args, string @default)
        {
            int idx;
            for (idx = 0; idx < args.Length; idx++)
            {
                if (args[idx].Equals(argument, StringComparison.OrdinalIgnoreCase))
                    break;
            }
            return idx < args.Length ? args[++idx] : @default;
        }
    }
}
