using CS.Application.Framework;
using CS.Application.Views.Home;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using CS.UI.Common.Localization;
using CS.UI.Common.Service.Interface;
using Serilog;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CS.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationService applicationService;
        private readonly ILogger logger;
        private readonly IDataProvider dataProvider;
        private readonly ISecurityService securityService;
        private readonly ITranslator translator;

        public HomeController(ITranslator translator, ISecurityService securityService,
            IDataProvider dataProvider, IApplicationService applicationService, ILogger logger)
        {
            this.applicationService = applicationService ?? throw new ArgumentNullException(nameof(applicationService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            this.securityService = securityService ?? throw new ArgumentNullException(nameof(securityService));
            this.translator = translator ?? throw new ArgumentNullException(nameof(translator));
        }

        public Task<ActionResult> Index()
        {
            return Task.FromResult(View("Home", new HomeViewModel()));
        }

        public ActionResult Navigate(NavigationItem navigationItem)
        {
            //TODO: for limit access it must be shown the notification
            if (navigationItem.Roles.Any() && navigationItem.Roles.All(r => !CurrentPrincipal.Instance.IsInRole(r)))
                return End();

            return Path(navigationItem.Path);
        }

        public ActionResult Login(string returnUri)
        {
            return View("Login", new LoginViewModel { ReturnUri = returnUri });
        }

        public ActionResult SignOut(string currentUrl)
        {
            // close all open dialog
            Shell.IsDialogOpened = false;

            // reset
            dataProvider.Reset();
            securityService.SignOut();
            //set currentUrl khi logoff
            currentUrl = null;
            return Login(currentUrl);
        }

        public async Task<ActionResult> SignIn(LoginViewModel viewModel)
        {
            var errorMessages = await securityService.Authenticate(viewModel.Model);
            if (!CurrentPrincipal.Instance.IsAuthenticated)
            {
                viewModel.ErrorMessage = string.Join(". ", errorMessages);
                return End();
            }

            var loginUser = await securityService.GetLoginUser();
            if (loginUser == null)
            {
                viewModel.ErrorMessage = translator.Translate("LoginView_CannotFoundIdentifyTheLoginUser");
                await securityService.SignOut();
                return End();
            }

            securityService.StartNotificator();

            Shell.User = loginUser;

            // reset the navigation items
            NavigationManager.Instance.Reset();
            ApplicationCoordinator.ViewAsChild = false;

            if (!string.IsNullOrEmpty(Shell.User.LanguageCode))
            {
                var userCulture = CultureInfo.GetCultureInfo(Shell.User.LanguageCode);
                LocalizationManager.Instance.CurrentLanguage = userCulture;
            }

            if (CurrentPrincipal.Instance.Principal.IsInRole(UserRoleType.Admin))
            {
                logger.Debug("Supper admin must go to admin for setting up");

                applicationService.Invoke<AdminController>(c => c.Index());
                ApplicationCoordinator.ViewAsChild = true;
                return End();
            } 

            // redirect to Home
            if (string.IsNullOrEmpty(viewModel.ReturnUri))
            {
                logger.Debug("Open home view");
                applicationService.Invoke<HomeController>(c => c.Index());
            }
            else
            {
                logger.Debug("Redirect to {0}", viewModel.ReturnUri);
                applicationService.Invoke<HomeController>(c => c.Navigate(new NavigationItem() { Path = viewModel.ReturnUri }));
            }

            return End();
        }

        public async Task<ActionResult> SendMessage(string message)
        {
            await dataProvider.Get<string>($"hubs/{message}");
            return End();
        }

        public ActionResult SaveSettings(SettingModel model)
        {
            var result = ApplicationSettings.Instance.Update(model);
            if (result)
                ShowMessage(translator.Translate("ViewModel_SaveSuccessfully"));
            else
                ShowMessage(translator.Translate("ViewModel_SaveFailed"), NotificationType.Error);
            return End();
        }
    }
}
