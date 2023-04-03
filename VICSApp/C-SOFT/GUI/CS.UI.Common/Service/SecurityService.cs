using CS.UI.Common.Localization;
using CS.UI.Common.Service.Interface;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Std;
using CS.UI.Common.Interfaces;

namespace CS.UI.Common.Service
{
    public class SecurityService : ISecurityService
    {
        private readonly INotificator notificator;
        private readonly ITranslator translator;
        private readonly IDataProvider dataProvider;
        private readonly ILogger logger;

        public SecurityService(INotificator notificator, ILogger logger, ITranslator translator, IDataProvider dataProvider)
        {
            this.notificator = notificator ?? throw new ArgumentNullException(nameof(notificator));
            this.translator = translator ?? throw new ArgumentNullException(nameof(translator));
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public async Task<IList<string>> Authenticate(CredentialLoginModel credential)
        {
            CurrentPrincipal.Instance.Reset();

            var response = await dataProvider.Post<CredentialLoginModel, string>("security/token", credential);
            if (!response.IsSuccess)
                return response.ErrorMessages;

            //bind the token to service
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(response.Value);
            if (jwtToken.Claims.All(x => x.Type != ClaimTypes.Role))
            {
                logger.Error($"Claim types does not contain {ClaimTypes.Role}");
                return new List<string> { translator.Translate("LoginView_CannotIdentifyTheLoginUser") };
            }

            var principal = new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims, JwtRegisteredClaimNames.Sid, JwtRegisteredClaimNames.GivenName, ClaimTypes.Role));
            if (!principal.IsInRole(UserRoleType.User, UserRoleType.Admin))
            {
                logger.Error("Limit access to role. Token: {0}", response.Value);
                return new List<string> { translator.Translate("LoginView_CannotIdentifyTheLoginUser") };
            }

            //set the authentication token
            ApiProvider.Instance.SetToken(response.Value);
            CurrentPrincipal.Instance.Principal = principal;

            return null;
        }

        public async Task<IUserLogin> GetLoginUser()
        {
            var response = await dataProvider.Get<UserModel>("security/login");
            if (!response.HasResult)
            {
                await SignOut();
                return null;
            }

            return response.Value;
        }

        public async Task SignOut()
        {
            // reset the current principal
            CurrentPrincipal.Instance.Reset();
            ApplicationServiceLocator.Instance.Shell.User = null;

            // close the dialog if any
            if (ApplicationServiceLocator.Instance.Shell.IsDialogOpened)
                ApplicationServiceLocator.Instance.Shell.IsDialogOpened = false;

            // stop the hub
            await notificator.Stop();

            // let the api the signout 
            await ApiProvider.Instance.GetAsync(api => api.GetAsync<bool>("security/logout"), exception => logger.Error(exception, "logout"));

            // remove the token
            ApiProvider.Instance.SetToken(null);
        }

        public async void StartNotificator()
        {
            // connect to hub
            await notificator.Start();
            notificator.RecievedMessageEvent += ApplicationServiceLocator.Instance.Shell.ShowMessage;
            notificator.ConnectionClosedEvent += exception =>
            {
                ApplicationServiceLocator.Instance.Shell.ShowMessage(new NotificationMessage
                {
                    Type = NotificationType.Alert,
                    Content = exception.Message
                });
                ApplicationServiceLocator.Instance.Shell.SignOutCommand.Execute(null);
            };
        }

        public async Task<RequestResult<bool>> Register(CredentialRegisterModel credential)
        {
            var response = await ApiProvider.Instance.GetAsync(api => api.PostAsync<CredentialRegisterModel, bool>("security/register", credential), exception => logger.Error(exception, "register"));
            return response;
        }
    }
}
