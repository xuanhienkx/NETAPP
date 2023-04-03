using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SMS.Common;
using SMS.Common.Configuration;
using SMS.Common.Models;
using SMS.Data.Services.EF.UnitsOfWork;
using SMS.DataAccess.Models;
using VICS.Manager.WebApp.Models;
using VicsManageWeb.Common.UI;
using VicsManageWeb.Common.UI.Grid;

namespace VICS.Manager.WebApp.Controllers
{
    public class SendSmsController : BaseController
    {
        private readonly ISmsUnitOfWork _smsUnitOfWork;
        private readonly ISbsUnitOfWork _sbsUnitOfWork;

        public SendSmsController(ISmsUnitOfWork smsUnitOfWork, ISbsUnitOfWork sbsUnitOfWork)
        {
            _smsUnitOfWork = smsUnitOfWork;
            this._sbsUnitOfWork = sbsUnitOfWork;
        }

        // GET: SendSMS
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken()]
        [HttpPost()]
        public ActionResult GetFileInput(UploadFile uploadFile)
        {

            try
            {
                var model = new CustomerSendList();
                HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;
                if (hpf == null || hpf.ContentLength == 0)
                    throw new ArgumentNullException("uploadFile");

                string savedFileName = Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName); // Save the file 

                var readInData = new ReadExcelData(savedFileName);
                IEnumerable<CustomerViewModel> customers = readInData.GetData();
                List<CustomerViewModel> customerViews = new List<CustomerViewModel>();
                 foreach (var customer in customers)
                {
                    var cus = _smsUnitOfWork.CustomerRepository.Find(customer.Id);
                    if (cus == null)
                    {
                        cus = _sbsUnitOfWork.CustomerReporsitory.GetById(customer.Id);
                        if (cus == null)
                        { 
                            continue;
                        }
                        _smsUnitOfWork.CustomerRepository.Insert(cus);
                    }
                    customer.CustomerName = cus.CustomerName;
                    customerViews.Add(customer);

                }
                Session.SetDataToSession<List<CustomerViewModel>>("excelData", customerViews);
                model = new CustomerSendList(customers, 20)
                {
                    CurrentPage = 1,
                    ActionName = "GetFileInput",
                    ControllerName = "SendSms",
                    TotalItemsCount = customers.Count() 
                }; 
                return PartialView("_ListView", model);

            }
            catch (Exception ex)
            {
                // Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return JsonResult(false, ex.Message, true);
            }

        }

        public ActionResult CreateMessage(List<string> ids, string message, bool isNomalinfo)
        {
            var currenData = Session.GetDataFromSession<List<CustomerViewModel>>("excelData");
            if (isNomalinfo)
            {
                var listId = currenData.Select(x => x.Id).ToList();
                var customersDb = _smsUnitOfWork.CustomerRepository.GetCustomers(x=> listId.Contains(x.Id)); 
                //var listBrand = customersDb.Where(x => IsBrandName(x.Mobile)).ToList();
                //var listNormal = customersDb.Where(x => !IsBrandName(x.Mobile)).ToList();
                var smsRequest = new SmsRequest
                {
                    Id = Guid.NewGuid(),
                    Message = message,
                    CreatedTime = DateTime.Now,
                    Customers = customersDb,
                    IsSent = false,
                    OrderDate = OrderDate,
                    Type = (short)SmsType.ThongBao,
                    IsBrandName = true
                };
                _smsUnitOfWork.RequestRepository.InsertRequest(smsRequest);
               /* if (listBrand.Any())
                {
                    var smsRequest = new SmsRequest
                    {
                        Id = Guid.NewGuid(),
                        Message = message,
                        CreatedTime = DateTime.Now,
                        Customers = listBrand,
                        IsSent = false,
                        OrderDate = OrderDate,
                        Type = (short) SmsType.ThongBao,
                        IsBrandName = true
                    };
                    _smsUnitOfWork.RequestRepository.InsertRequest(smsRequest);
                }

                if (listNormal.Any())
                {
                    var smsRequest = new SmsRequest
                    {
                        Id = Guid.NewGuid(),
                        Message = message,
                        CreatedTime = DateTime.Now,
                        Customers = listNormal,
                        IsSent = false,
                        OrderDate = OrderDate,
                        Type = (short) SmsType.ThongBao,
                        IsBrandName = false
                    };
                    _smsUnitOfWork.RequestRepository.InsertRequest(smsRequest);
                }*/
                _smsUnitOfWork.SaveChanges();

            }
            else
            {
               
                foreach (var model in currenData.ToList())
                {
                    var cu = _smsUnitOfWork.CustomerRepository.Find(model.Id);
                    if(cu==null)continue;
                    var list = new List<SmsCustomer>();
                    list.Add(cu);
                    var smsRequest = new SmsRequest
                    {
                        Id = Guid.NewGuid(),
                        Message = model.MessageContent,
                        CreatedTime = DateTime.Now,
                        Customers = list,
                        IsSent = false,
                        OrderDate = OrderDate,
                        Type = (short)SmsType.ThongBao,
                        IsBrandName = IsBrandName(model.Mobile)
                    };
                    _smsUnitOfWork.RequestRepository.InsertRequest(smsRequest);
                }
                _smsUnitOfWork.SaveChanges();
            }
           
            var dir = new DirectoryInfo(Server.MapPath("~/App_Data"));
            foreach (var f in dir.GetFiles()) f.Delete();
            return List(); 
        }
        public ActionResult List(int page = 1)
        {
            var grid = PagedGrid.GetCurrent(HttpContext.ApplicationInstance.Context);

            var requestquery =
                _smsUnitOfWork.RequestRepository.GetQuery()
                     .WithFilter(grid.FilterColumnCollection);
            requestquery =
                requestquery.Where(x => (x.Type == (byte)SmsType.ThongBao));

            var q = string.IsNullOrEmpty(grid.SortField.FieldName)
                ? requestquery.OrderByDescending(x => x.CreatedTime)
                : requestquery.OrderBy(grid.SortField);
            const int pageSize = 15;
            var models = q.GetPage(page, pageSize);

            var viewModel = new RequetsViewModel(models, pageSize)
            {
                TotalItemsCount = requestquery.Count(),
                CurrentPage = page
            };

            return PartialView("_ListSmsInfo", viewModel);
        } 
        public virtual string OrderDate
        {
            get { return SmsConfiguration.Current.TimeExecuteConfig.TransactionDate.ToString("dd/MM/yyyy"); }
        }

    }
}