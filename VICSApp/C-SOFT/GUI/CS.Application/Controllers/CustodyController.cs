using CS.Application.Framework;
using CS.Application.Services.Interfaces;
using CS.Application.Views.Custody;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Std;
using CS.Common.Std.Extensions;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using CS.UI.Common.Localization;
using CS.UI.Common.Service.Interface;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExecuteType = CS.UI.Common.Interfaces.ExecuteType;

namespace CS.Application.Controllers
{
    public class CustodyController : Controller
    {
        private readonly IDialogService dialogService;
        private readonly ITranslator translator;
        private readonly ICustodyBusinessHandler businessHandler;
        private readonly IDataProvider dataProvider;

        public CustodyController(ICustodyBusinessHandler businessHandler,
                                 IDataProvider dataProvider,
                                 ITranslator translator,
                                 IDialogService dialogService)
        {
            this.dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            this.translator = translator ?? throw new ArgumentNullException(nameof(translator));
            this.businessHandler = businessHandler ?? throw new ArgumentNullException(nameof(businessHandler));
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        }

        public ActionResult Index()
        {
            return IndexFilter(BusinessIdProviderConstant.OpenOrCloseAccount);
        }
        public ActionResult IndexFilter(string businessId)
        {
            return View("RequestList", new RequestListViewModel(businessId, businessHandler));
        }
        public async Task<Result<IList<CustodyRequestModel>>> GetByBusiness(string businessId)
        {
            if (string.IsNullOrEmpty(businessId))
                businessId = BusinessIdProviderConstant.OpenOrCloseAccount;
            var result = await dataProvider.GetList<CustodyRequestModel>($"vsd?business={businessId}");

            return !result.HasResult ? new Result<IList<CustodyRequestModel>>() : Result(result.Value);
        }
        public async Task<Result<IList<CustodyRequestModel>>> ConfirmRequest()
        {
            var result = await dataProvider.GetList<CustodyRequestModel>($"vsd/ConfirmRequests");
            return !result.HasResult ? new Result<IList<CustodyRequestModel>>() : Result(result.Value);
        }

        public ActionResult DeleteRequest(CustodyRequestModel model)
        {
            return End();
        }
        public async Task<Result<State<bool>>> Delete(CustodyRequestModel model)
        {
            var message = string.Format(translator.Translate("ViewModel_Confirm_MessageDelete"), $" {model.BusinessId}");
            var dialogResult = await dialogService.ShowConfirmDialog(Shell, translator.Translate("Confirm_Title"), message);
            if (dialogResult == MessageDialogResult.Negative)
                return Result(new State<bool>(false));

            var result = await dataProvider.Delete($"vsd/{model.Id}/{model.BusinessId}");
            return Result(new State<bool>(result.IsSuccess, StateType.Executed));
        }

        public async Task<ActionResult> ShowRequestPublishDialog(string businessId, CustodyRequestModel requestModel, ExecuteType viewType)
        {
            if (viewType == ExecuteType.New)
            {
                requestModel = new CustodyRequestModel(businessId);
            }

            var viewModel = businessHandler.CreateViewModel(businessId, requestModel);
            viewModel.ErrorMessage = null; 
            await viewModel.LoadData(); 
            viewModel.ViewType = viewType;
            return Dialog(viewModel.GetViewName(), viewModel);
        }

        public async Task<Result<RequestResult<CustodyRequestModel>>> PublishCustomer(CustodyRequestModel requestModel, object contenModel)
        {
            requestModel.Content = requestModel.ContentModel.Base64ProtoBufSerialize();
            var data = await dataProvider.Post<CustodyRequestModel, CustodyRequestModel>($"vsd", requestModel);
            return Result(data);
        }

        public ActionResult IndexRightInfo()
        {
            return View("RightInformationList", new RightInformationListViewModel());
        }
        public ActionResult IndexReportInfo()
        {   //vsd/FileActs     
            return View("VsdReportResponseList", new VsdReportResponseListViewModel());
        }

        public async Task<Result<IList<RightInformationModel>>> GetList()
        {
            var data = await dataProvider.GetList<RightInformationModel>($"vsd/Informations");
            return data.IsSuccess ? Result(data.Value) : Result<IList<RightInformationModel>>();
        }
        public async Task<Result<IList<FileActModel>>> GetReportList(string reportCode = null)
        {
            var data = await dataProvider.GetList<FileActModel>($"vsd/reports?reportCode={reportCode}");
            return data.IsSuccess ? Result(data.Value) : Result<IList<FileActModel>>();
        }

        public ActionResult ShowRightInfoDialog(RightInformationModel viewModel)
        {
            return ChildView("VSD_2_1_TBQuyen", new VSD_2_1_TBQuyenViewModel(viewModel));
        }

        public async Task<Result<DataTable>> GetFileCsvData(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return Result<DataTable>();

            var tempPath = System.IO.Path.GetTempPath();
            var tempPathFile = System.IO.Path.Combine(tempPath, fileName);
            if (!File.Exists(tempPathFile))
            {
                await ApiProvider.Instance.Download($"vsd/reports/{fileName}", tempPathFile, x =>
                {
                    if (x.Error != null)
                        File.Delete(tempPathFile);
                });
            }

            var table = tempPathFile.ToCsvDataTable();
            return Result(table);

        }
        public ActionResult ViewConfirmList()
        {
            return ChildView("RequestConfirmList", new RequestConfirmListViewModel());
        }

    }
}