using CS.Common;
using CS.Common.Std;
using System.Threading.Tasks;

namespace CS.VSD.Service.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    public class WithdrawOffBoardSecuritiesActionHandler : BaseOnlyResponseActionHandler
    {
        public override string BussinessId => BusinessIdProviderConstant.WithdrawOffBoardSecurities;

        public override Task<bool> ProcessMessageReceived(CsBag bag)
        {
            return Task.FromResult(false);
        }
 
    }
}
