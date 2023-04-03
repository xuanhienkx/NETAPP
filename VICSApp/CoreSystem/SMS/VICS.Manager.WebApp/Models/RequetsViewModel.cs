using System.Collections.Generic;
using SMS.DataAccess.Models;
using VicsManageWeb.Common.UI.Models;

namespace VICS.Manager.WebApp.Models
{
    public class RequetsViewModel : PagedList<SmsRequest>
    {
        public RequetsViewModel()
        {
            
        }
        public RequetsViewModel(IEnumerable<SmsRequest> item, int page):base(item,page)
        {

        }
        public string CustomerId { get; set; } 
        public bool IsSend { get; set; }
        public SmsType Type { get; set; }
    }
}