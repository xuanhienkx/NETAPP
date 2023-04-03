using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using SMS.Common;
using SMS.Common.Configuration;

namespace VICS.Manager.WebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        // GET: Base
        [OutputCache(Duration = 60, Location = OutputCacheLocation.Client, NoStore = true, VaryByParam = "*")]
        public JsonResult JsonResult(bool success, object dataView = null, bool dialog = false)
        {

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    success = success,
                    value = dataView,
                    dialog = dialog
                },
            };
        }
        [OutputCache(Duration = 60, Location = OutputCacheLocation.Client, NoStore = true, VaryByParam = "*")]
        public void ExportClientsListToExcel<T>(List<T> dataSource) where T : class
        {
            var grid = new System.Web.UI.WebControls.GridView();
            grid.DataSource = dataSource;
            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Exported_Diners.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Write(sw.ToString());

            Response.End();

        }
      
        public virtual bool IsBrandName(string mobile)
        {
            var telecomeOfBrand = ApiEmsConfiguration.Current.Telecome;
            if (telecomeOfBrand.Equals("All", StringComparison.CurrentCultureIgnoreCase))
                return true;
            if (telecomeOfBrand.Equals("None", StringComparison.CurrentCultureIgnoreCase))
                return true;
            var telecoms = telecomeOfBrand.Split(':');
            var mobiType = mobile.GePhoneType().ToString();
            return telecoms.Contains(mobiType);
        }
    }
}