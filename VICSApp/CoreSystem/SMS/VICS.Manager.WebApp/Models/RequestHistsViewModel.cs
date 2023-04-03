using System.Collections.Generic;
using SMS.Data.Services.EF.Models;
using SMS.DataAccess.Models;
using VicsManageWeb.Common.UI.Models;

namespace VICS.Manager.WebApp.Models
{
    public class RequestHistsViewModel : PagedList<SmsRequestHist>
    {
        public RequestHistsViewModel()
        {
            
        }
        public RequestHistsViewModel(IEnumerable<SmsRequestHist> items, int pageSize)
            : base(items, pageSize)
        {
            
        }

        public DoiSoatModel DoiSoat { get; set; }
        public IList<SmsSummary> Summaries { get; set; }
    }
}