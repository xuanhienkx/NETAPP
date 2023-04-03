using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.Ajax.Utilities;
using SMS.Business.Service.Services;
using SMS.Common;
using SMS.Common.Configuration;
using SMS.Common.Models;
using SMS.Data.Services.EF.Models;
using SMS.Data.Services.EF.UnitsOfWork;
using SMS.DataAccess.Models;
using VICS.Manager.WebApp.Models;
using VicsManageWeb.Common.UI;
using VicsManageWeb.Common.UI.Grid;

namespace VICS.Manager.WebApp.Controllers
{
    public class SmsReportController : Controller
    {
        private readonly ISmsUnitOfWork _smsUnitOfWork;
        private readonly ISbsUnitOfWork _sbsUnitOfWork;
        private readonly IGetStatusProcessDataService _getStatusProcessDataService;
        private DoiSoatModel doiSoat;

        public SmsReportController(ISmsUnitOfWork smsUnitOfWork, ISbsUnitOfWork sbsUnitOfWork,IGetStatusProcessDataService getStatusProcessDataService)
        {
            _smsUnitOfWork = smsUnitOfWork;
            _sbsUnitOfWork = sbsUnitOfWork;
            _getStatusProcessDataService = getStatusProcessDataService;
        }

        // GET: SmsReport
        public ActionResult Index()
        {
            var model = new RequetsViewModel();
            return View(model);
        }
        public ActionResult SmsDoiSoat()
        {
            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);
            var last = month.AddDays(-1);
            ViewBag.fromDate = first.ToString("MM/dd/yyyy");
            ViewBag.toDate = last.ToString("MM/dd/yyyy");

            return View();
        }

        private List<SmsSummary> _summaries = new List<SmsSummary>();
     //   [OutputCache(Duration = 60, Location = OutputCacheLocation.Client, NoStore = true, VaryByParam = "*")]
        public ActionResult ListDoiSoat(string fromDate, string toDate, int page = 1)
        {
            DateTime first = DateTime.Parse(fromDate);
            DateTime last = DateTime.Parse(toDate).AddHours(23).AddMinutes(59).AddSeconds(59);
            //_getStatusProcessDataService.GetMissReceiverAndInsert(first, last);
            var grid = PagedGrid.GetCurrent(HttpContext.ApplicationInstance.Context);
            var query = _smsUnitOfWork.RequestHistRepository.GetQuery().WithFilter(grid.FilterColumnCollection);
            if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
               
                query = query.Where(x => x.CreatedTime >= first && x.CreatedTime <= last);
                if (!_summaries.Any())
                    _summaries = _smsUnitOfWork.StatusResultRepository.GeSummaries(first, last);
            }
            var q = string.IsNullOrEmpty(grid.SortField.FieldName)
              ? query.OrderBy(x => x.CreatedTime)
              : query.OrderBy(grid.SortField);

            const int pageSize = 15;
            var models = q.GetPage(page, pageSize);
            var viewModel = new RequestHistsViewModel(models, pageSize)
            {
                CurrentPage = page,
                TotalItemsCount = q.Count(),
                Summaries = _summaries,
                DoiSoat = new DoiSoatModel
                {
                    From = fromDate,
                    To = toDate
                } 
            };
            ViewBag.fromDate = fromDate;
            ViewBag.toDate = toDate;
            return PartialView("_ListDoiSoat", viewModel);
        }
     //   [OutputCache(Duration = 60, Location = OutputCacheLocation.Client, NoStore = true, VaryByParam = "*")]
        public ActionResult GetSumamry(string fromDate, string toDate)
        {
            DateTime first = DateTime.Parse(fromDate);
            DateTime last = DateTime.Parse(toDate).AddHours(23).AddMinutes(59).AddSeconds(59);
            var doisoat = new DoiSoatModel
            {
                From = fromDate,
                To = toDate
            };
            this.doiSoat = doisoat;
            if (!_summaries.Any())
                _summaries = _smsUnitOfWork.RequestHistRepository.Summary(first, last);
            return PartialView("_Summary", _summaries);
        }

    //    [OutputCache(Duration = 60, Location = OutputCacheLocation.Client, NoStore = true, VaryByParam = "*")]
        public ActionResult SmsDetail(string smsId, bool isBrandName = false)
        {
            SmsClient smsClient = ApiEmsConfiguration.Current.SmsClient;
            SmsReceiver status = ESmsServices.GetReceiverMessage(ESmsServices.OnGetStatusBrandName, new
            {
                SmsId = isBrandName ? string.Format(" <REFID>{0}</REFID> ", smsId) : string.Format("<SMSID>{0}</SMSID>", smsId),
                Apikey = smsClient.Apikey,
                Secretkey = smsClient.Secretkey


            });
            ViewBag.SmsId = smsId;
            return PartialView("_SmsReceiver", status);
        }
      //  [OutputCache(Duration = 60, Location = OutputCacheLocation.Client, NoStore = true, VaryByParam = "*")]
        public ActionResult List(RequetsViewModel requets, int page = 1)
        {

            var grid = PagedGrid.GetCurrent(HttpContext.ApplicationInstance.Context);

            var requestquery =
                _smsUnitOfWork.RequestRepository.GetQuery()
                     .WithFilter(grid.FilterColumnCollection);
            requestquery =
                requestquery.Where(x => (string.IsNullOrEmpty(requets.CustomerId) || x.Message.Contains(requets.CustomerId))
                && (requets.Type == SmsType.All || x.Type == (byte)requets.Type));

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

            return PartialView("_ListView", viewModel);
        }
    }

}