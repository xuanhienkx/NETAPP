using CS.Common.Contract;
using CS.Common.Std;

namespace CS.Application.Views
{
    public class SplashScreenWindowViewModel : ModelBase
    {
        public string Production => "C-Soft Trading Application";
        public string Version => $"Version: {DeviceInfo.Instance.Value.Version}";
        public string Copyright => DeviceInfo.Instance.Value.Copyright;
    }
}
