using System.Collections.Generic;
using SMS.DataAccess.Models;
using VicsManageWeb.Common.UI.Models;

namespace VICS.Manager.WebApp.Models
{
    public class CustomersViewModel : PagedList<SmsCustomer>
    {
        public CustomersViewModel()
        {
            
        }
        public CustomersViewModel(IEnumerable<SmsCustomer> itme ,int pageSize):base(itme,pageSize)
        {
            
        }

        public string CustomerId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool IsClose { get; set; }
    }

    public class CustomerSendList : PagedList<CustomerViewModel>
    {
        public CustomerSendList()
        {
            
        }

        public CustomerSendList(IEnumerable<CustomerViewModel> item, int pageSize ): base(item, pageSize)
        {
            
        }
    }
}