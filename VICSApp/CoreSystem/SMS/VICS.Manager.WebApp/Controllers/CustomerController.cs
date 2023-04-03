using System; 
using System.Linq; 
using System.Web.Mvc;
using System.Web.UI;
using SMS.Common.Models;
using SMS.Data.Services.EF.UnitsOfWork;
using SMS.DataAccess.Models;
using VICS.Manager.WebApp.Models;
using VicsManageWeb.Common.UI.Grid;

namespace VICS.Manager.WebApp.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ISmsUnitOfWork _smsUnitOfWork;
        private readonly ISbsUnitOfWork _sbsUnitOfWork;

        public CustomerController(ISmsUnitOfWork unitOfWork, ISbsUnitOfWork sbsUnitOfWork)
        {
            this._smsUnitOfWork = unitOfWork;
            this._sbsUnitOfWork = sbsUnitOfWork;
        }

        // GET: Customer
        public ActionResult Index()
        {
            var model = new CustomersViewModel();
            return View(model);
        }
      //  [OutputCache(Duration = 60, Location = OutputCacheLocation.Client, NoStore = true, VaryByParam = "*")]
        public ActionResult List(CustomersViewModel model, int page = 1)
        {
           var grid = PagedGrid.GetCurrent(HttpContext.ApplicationInstance.Context);

            var customerQuery =
                _smsUnitOfWork.CustomerRepository.GetQuery()
                     .WithFilter(grid.FilterColumnCollection);
            customerQuery =
                customerQuery.Where(x => (string.IsNullOrEmpty(model.CustomerId) || x.Id.EndsWith(model.CustomerId))
                && (string.IsNullOrEmpty(model.Mobile) || x.Mobile.Contains(model.Mobile))
                && (string.IsNullOrEmpty(model.Email) || x.Email.Contains(model.Email))
                && (x.IsClose == model.IsClose));

            var q = string.IsNullOrEmpty(grid.SortField.FieldName)
                ? customerQuery.OrderBy(x => x.Id)
                : customerQuery.OrderBy(grid.SortField);
            const int pageSize = 15;
            var models = q.GetPage(page, pageSize);

            var viewModel = new CustomersViewModel(models, pageSize)
            {
                TotalItemsCount = customerQuery.Count(),
                CurrentPage = page
            };

            return PartialView("_ListView", viewModel);
        }

        public ActionResult Create()
        {
            var model = new CustomerViewModel();
            return View(model);
        }
       // [OutputCache(Duration = 60, Location = OutputCacheLocation.Client, NoStore = true, VaryByParam = "*")]
        public ActionResult GetCustomerSbs(string id)
        {
            var cus = _sbsUnitOfWork.CustomerReporsitory.GetById(id);
            if (cus == null)
                return JsonResult(false, "Không tìm thấy khách hàng:" + id+" trên SBS", true);
            var cusview = new CustomerViewModel
            {
                Id = cus.Id,
                CustomerName = cus.CustomerName,
                BranchCode = cus.BranchCode,
                Mobile = cus.Mobile,
                CustomerType = cus.CustomerType,
                DomesticForeign = cus.DomesticForeign,
                Email = cus.Email,
                Sex = cus.Sex,
                CloseDate = cus.CloseDate,
                IsClose = cus.IsClose
            };
            return PartialView("_CustomerTemplate", cusview);
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var exist = _smsUnitOfWork.CustomerRepository.Find(model.Id);
            if (exist != null)
                return RedirectToAction("Edit", new { id = exist.Id });
            var cus = new SmsCustomer
            {
                Id = model.Id,
                BranchCode = model.BranchCode,
                CloseDate = DateTime.Now.AddYears(100),
                CustomerType = model.CustomerType,
                CustomerName = model.CustomerName,
                DomesticForeign = model.DomesticForeign,
                Mobile = model.Mobile,
                Sex = model.Sex,
                Email = model.Email,
                IsClose = model.IsClose,
                OpenDate = DateTime.Now,
                IsAccountStatus = true,
                IsInfo = true,
                IsOrder = true,
                IsResult = true
            };
            _smsUnitOfWork.CustomerRepository.Insert(cus);
            _smsUnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(string id)
        {

            var cus = _smsUnitOfWork.CustomerRepository.Find(id);
            if (cus == null)
                return JsonResult(false, "Không tìm thấy khách hàng:" + id , true);
            var cusview = new CustomerViewModel
            {
                Id = cus.Id,
                CustomerName = cus.CustomerName,
                BranchCode = cus.BranchCode,
                Mobile = cus.Mobile,
                CustomerType = cus.CustomerType,
                DomesticForeign = cus.DomesticForeign,
                Email = cus.Email,
                Sex = cus.Sex,
                CloseDate = cus.CloseDate,
                IsClose = cus.IsClose
            };
            return View(cusview);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var cus = _smsUnitOfWork.CustomerRepository.Find(model.Id);
            if (cus == null)
                return JsonResult(false, "Không tìm thấy khách hàng:" + model.Id, true);

            cus.Mobile = model.Mobile;
            cus.BranchCode = model.BranchCode;
            cus.Mobile = model.Mobile;
            cus.CustomerType = model.CustomerType;
            cus.DomesticForeign = model.DomesticForeign;
            cus.Email = model.Email;
            cus.Sex = model.Sex;
            cus.CloseDate = model.CloseDate;
            cus.IsClose = model.IsClose;
            _smsUnitOfWork.CustomerRepository.Update(cus);
            _smsUnitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}