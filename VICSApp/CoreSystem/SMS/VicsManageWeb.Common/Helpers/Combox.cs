using System.Collections.Generic;
using System.Web.Mvc;

namespace VicsManageWeb.Common.Helpers
{
    public static class Combox
    { 
        public static List<SelectListItem> CustomerTypes = new List<SelectListItem>()
        {
            new SelectListItem{Value = "I", Text = "Cá Nhân"},
            new SelectListItem{Value = "E", Text = "Doanh Nghiệp"},
        };

        public static List<SelectListItem> DomesticForeign = new List<SelectListItem>()
        {
            new SelectListItem{Value = "D", Text = "Trong Nước"},
            new SelectListItem{Value = "F", Text = "Nước ngoài"},
        };

        public static List<SelectListItem> BranchCode = new List<SelectListItem>()
        {
            new SelectListItem{Value = "100", Text = "Hà Nội"},
            new SelectListItem{Value = "200", Text = "Hồ Chí Minh"},
        };

        public static List<SelectListItem> Sex = new List<SelectListItem>()
        {
            new SelectListItem{Value = "False", Text = "Nữ"},
            new SelectListItem{Value = "True", Text = "Nam"},
        };

        public static List<SelectListItem> Status = new List<SelectListItem>()
        {
            new SelectListItem{Value = "False", Text = "Mở"},
            new SelectListItem{Value = "True", Text = "Đóng"},
        };

    }
}