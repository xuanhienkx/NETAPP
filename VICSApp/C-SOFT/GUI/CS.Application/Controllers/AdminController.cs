using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS.Application.Views.Admin;
using CS.UI.Common;

namespace CS.Application.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View("Admin", new AdminViewModel());
        }
    }
}
