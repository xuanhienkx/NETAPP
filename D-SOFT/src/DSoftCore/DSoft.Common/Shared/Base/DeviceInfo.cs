using System.Reflection;

namespace DSoft.Common.Shared.Base;

public class DeviceInfo
{
    public static Lazy<DeviceInfo> Instance = new Lazy<DeviceInfo>(InitDeviceInfo);

    private static DeviceInfo InitDeviceInfo()
    {
        var system64 = Environment.Is64BitOperatingSystem ? "x64" : "x86";
        var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        return new DeviceInfo()
        {
            Version = version,
            Copyright = GetCopyright(),
            DeviceDetail = $"D-SOFT {version}_{Environment.OSVersion}.{Environment.OSVersion.Platform}.{system64}_{Environment.MachineName}_{Environment.ProcessorCount}cpus"
        };
    }

    DeviceInfo() { }

    public string DeviceDetail { get; private set; }
    public string Version { get; private set; }
    public string Copyright { get; private set; }

    private static string GetCopyright()
    {
        var asm = Assembly.GetExecutingAssembly();
        var obj = asm.GetCustomAttributes(false);
        foreach (var o in obj)
        {
            if (o is AssemblyCopyrightAttribute attribute)
            {
                var aca = attribute;
                return aca.Copyright;
            }
        }
        return string.Empty;
    }
}
