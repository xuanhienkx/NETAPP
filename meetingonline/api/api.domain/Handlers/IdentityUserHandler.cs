using api.common;
using api.common.Commands;
using api.common.Events;
using api.common.Models;
using api.common.Models.Identity;
using api.common.Shared;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;
using api.domain.Commands;
using api.domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IdentityUser = api.common.Models.Identity.IdentityUser;

namespace api.domain.Handlers
{
    public class IdentityUserHandler : PersistentHandler<IdentityUser, DomainPersistentService>,
        IRequestHandler<AccountAuthenticateCommand, Result<IdentityPrincipal>>,
        IRequestHandler<OAuthAuthenticationCommand, Result<IdentityPrincipal>>,
        IRequestHandler<AccountRegisterCommand, Result<bool>>,
        IRequestHandler<AccountVerifyCommand, Result<bool>>,
        IRequestHandler<AccountResetPasswordCommand, Result<bool>>,
        IRequestHandler<AccountChangePasswordCommand, Result<bool>>,
        IRequestHandler<IdentityRequestCommand, Result<bool>>,
        IRequestHandler<AccountCreateCommand<AccountInfo>, Result<AccountInfo>>,
        IRequestHandler<UpdateByIdCommand<IdentityUser>, Result<bool>>
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IJwtTokenIssuer tokenIssuer;
        private readonly ICurrentUser currentUser;
        private readonly IContentProviderService contentProvider;
        private readonly IPersistentDataProvider dataProvider;
        private readonly ILookupNormalizer normalizer;

        public IdentityUserHandler(
            IMediator mediator,
            UserManager<IdentityUser> userManager,
            IJwtTokenIssuer tokenIssuer,
            ICurrentUser currentUser,
            IContentProviderService contentProvider,
            IPersistentDataProvider dataProvider,
            ILookupNormalizer normalizer,
            ILocalizer localizer,
            IPersistentService<DomainPersistentService> persistentService
            )
            : base(mediator, persistentService, localizer)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.tokenIssuer = tokenIssuer ?? throw new ArgumentNullException(nameof(tokenIssuer));
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            this.contentProvider = contentProvider ?? throw new ArgumentNullException(nameof(contentProvider));
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            this.normalizer = normalizer ?? throw new ArgumentNullException(nameof(normalizer));
        }

        public async Task<Result<bool>> Handle(UpdateByIdCommand<IdentityUser> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var rs = await Update(request.Id, o => o.Set(request.Field, request.Value), cancellationToken);
            return Result(rs.ModifiedCount != 0);
        }

        public async Task<Result<IdentityPrincipal>> Handle(AccountAuthenticateCommand request, CancellationToken cancellation)
        {
            cancellation.ThrowIfCancellationRequested();
            return await SignIn(request, cancellation);
        }

        public async Task<Result<IdentityPrincipal>> Handle(OAuthAuthenticationCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await OAuthSignIn(request, cancellationToken);
        }

        public async Task<Result<bool>> Handle(AccountRegisterCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await Register(new IdentityUser(request.Email, request.DisplayName), cancellationToken);
            return new Result<bool>(result.Succeeded)
            {
                Errors = result.Errors
            };
        }

        public Task<Result<AccountInfo>> Handle(AccountCreateCommand<AccountInfo> command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var user = new IdentityUser(command.Email, command.Name)
            {
                Address = command.Address,
                DisplayName = command.Name,
                Email = string.IsNullOrEmpty(command.Email) ? null : new IdentityUserEmail(command.Email),
                PhoneNumber = string.IsNullOrEmpty(command.PhoneNumber) ? null : new IdentityUserPhoneNumber(command.PhoneNumber),
                IdentityIssuedDate = command.IdentityDate,
                IdentityIssuer = command.IdentityIssuer,
                IdentityNumber = command.IdentityNumber,
                NormalizeIdentityNumber = normalizer.NormalizeName(command.IdentityNumber),
                IdentityType = command.IdentityType,
                Nationality = command.Nationality
            };
            return Register(user, cancellationToken);
        }

        public async Task<Result<bool>> Handle(AccountVerifyCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await Verify(request, cancellationToken);
        }

        public async Task<Result<bool>> Handle(AccountResetPasswordCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ResetPassword(request);
        }

        public async Task<Result<bool>> Handle(AccountChangePasswordCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await ChangePassword(request);
        }

        public async Task<Result<bool>> Handle(IdentityRequestCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            switch (request.Type)
            {
                case IdentityRequestType.RESET_LOGINCODE:
                    var user = await userManager.FindByNameAsync(request.IdentityID) ??
                               await userManager.FindByEmailAsync(request.IdentityID);
                    if (user == null)
                        return Error<bool>(Text("user.notFound"));

                    if (await userManager.IsInRoleAsync(user, AccountRole.MODERATOR.ToString()))
                        return Error<bool>(Text("user.roleIsInvalid"));

                    return await ResetLoginCode(user, cancellationToken);

                case IdentityRequestType.LOGOUT:
                    return await SignOut(cancellationToken);
                default:
                    return Error<bool>(Text("user.notSupport"));
            }
        }

        #region Private Helpers
        protected override ProjectionDefinition<IdentityUser> ExcludeGetProjection { get; }

        private async Task<Result<AccountInfo>> Register(IdentityUser user, CancellationToken cancellationToken)
        {
            var result = await userManager.CreateAsync(user);
            if (!result.Succeeded)
                return Error<AccountInfo>(Text("user.createFailed", result.Errors));
            
            result = await userManager.AddToRoleAsync(user, AccountRole.USER.ToString());
            if (result.Succeeded)
            {
                await ResetLoginCode(user, cancellationToken);
                return Result(user as AccountInfo);
            }

            return Error<AccountInfo>(Text("user.addRoleFailed", result.Errors));
        }

        private async Task<Result<bool>> ResetLoginCode(IdentityUser user, CancellationToken cancellationToken)
        {
            // send confirmation email
            var passwordToken = await userManager.GeneratePasswordResetTokenAsync(user);
            var loginCode = await userManager.GenerateTwoFactorTokenAsync(user, userManager.Options.Tokens.ChangePhoneNumberTokenProvider);
            var emailContent = contentProvider.GenerateEmailForSignUp(user, loginCode, passwordToken);

            // publish event to send verification email
            await Mediator.Publish(new SendEmailEvent(user.Email.Value, user.DisplayName, emailContent), cancellationToken);

            return Result(true);
        }

        private async Task<Result<IdentityPrincipal>> SignIn(AccountAuthenticateCommand request, CancellationToken cancellation)
        {
            // find user
            var user = await userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                user = await userManager.FindByEmailAsync(request.Username);
                if (user == null)
                {
                    await Mediator.Publish(UserLoginEvent.LoginEvent(request.Username, Text("user.notFound")), cancellation);
                    return Error<IdentityPrincipal>(Text("user.notFound"));
                }
            }

            if (user.DeletedDate != null || user.LockedDate != null)
            {
                await Mediator.Publish(UserLoginEvent.LoginEvent(request.Username, Text("user.notFound")), cancellation);
                return Error<IdentityPrincipal>(Text("user.notFound"));
            }

            // check user lockout
            var userLocked = await userManager.IsLockedOutAsync(user);
            if (userLocked)
            {
                // send audit
                await Mediator.Publish(UserLoginEvent.LoginEvent(request.Username, $"UserLocked: {user.AccessFailedCount}", user), cancellation);
                return Error<IdentityPrincipal>(Text("user.hasBeenLocked"));
            }

            // password check
            var passwordValidated = await userManager.CheckPasswordAsync(user, request.Password);
            if (!passwordValidated)
            {
                // try with login code
                var isValid = await userManager.VerifyTwoFactorTokenAsync(user, userManager.Options.Tokens.ChangePhoneNumberTokenProvider, request.Password);
                if (isValid)
                {
                    var isEmailConfirm = await userManager.IsEmailConfirmedAsync(user);
                    if (!isEmailConfirm)
                    {
                        // set email confirmed
                        user.Email.SetConfirmed(new Occurrence());
                        await userManager.UpdateAsync(user);
                    }
                }
                else
                {
                    await userManager.AccessFailedAsync(user);
                    // send audit
                    await Mediator.Publish(
                        UserLoginEvent.LoginEvent(request.Username, $"AccessFailedCount: {user.AccessFailedCount}",
                            user), cancellation);

                    return Error<IdentityPrincipal>(Text("user.tokenInvalid"));
                }
            }

            await userManager.ResetAccessFailedCountAsync(user);
            await userManager.AddLoginAsync(user, new UserLoginInfo(ProviderConstants.LoginProvider, ProviderConstants.AuthenticatorKeyTokenName, user.UserName));

            // set the login status
            var loginTimeStamp = DateTime.UtcNow.Ticks.ToString();

            dataProvider.Reset(user.Id);
            dataProvider.Set(user.Id, new Message(loginTimeStamp));

            // authenticate and return token
            var token = tokenIssuer.CreateJwtToken(user, loginTimeStamp);

            // send audit
            await Mediator.Publish(UserLoginEvent.LoginEvent(user.UserName, user: user), cancellation);

            // inform client via hub for maintain single login session
            await currentUser.SendLoginState(user.Id, loginTimeStamp, cancellation);

            var userRoles = await userManager.GetRolesAsync(user);
            return Result(new IdentityPrincipal(token, userRoles.SingleOrDefault(), user, loginTimeStamp));
        }

        private async Task<Result<IdentityPrincipal>> OAuthSignIn(OAuthAuthenticationCommand request, CancellationToken cancellationToken)
        {
            // find user by email
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                // create new login for this user
                var displayName = string.IsNullOrEmpty(request.Name)
                    ? $"{request.FirstName} {request.LastName}"
                    : request.Name;
                user = new IdentityUser(request.Email, displayName)
                {
                    Avatar = new MediaResource
                    {
                        Provider = ProviderConstants.MediaResourceLinkProvider,
                        FileId = request.PhotoUrl
                    }
                };
                var result = await Register(user, cancellationToken);
                if (!result.Succeeded)
                    return Error<IdentityPrincipal>(result.Errors);
            }
            await userManager.AddLoginAsync(user, new UserLoginInfo(request.Provider, request.Id, user.UserName));

            // set the login status
            var loginTimeStamp = DateTime.UtcNow.Ticks.ToString();

            // authenticate and return token
            var token = tokenIssuer.CreateJwtToken(user, loginTimeStamp);

            // send audit
            await Mediator.Publish(UserLoginEvent.LoginEvent(user.UserName, user: user), cancellationToken);

            // inform client via hub for maintain single login session
            await currentUser.SendLoginState(user.Id, loginTimeStamp, cancellationToken);

            var userRoles = await userManager.GetRolesAsync(user);
            return Result(new IdentityPrincipal(token, userRoles.SingleOrDefault(), user, loginTimeStamp));
        }


        private async Task<Result<bool>> SignOut(CancellationToken cancellation)
        {
            if (currentUser.User == null)
                return Error<bool>(Text("user.notFound"));

            // clear cache
            dataProvider.Reset(currentUser.UserId);
            // notifying
            await Mediator.Publish(UserLoginEvent.LogoutEvent(currentUser.User.UserName, user: currentUser.User), cancellation);

            return Result(true);
        }

        private async Task<Result<bool>> Verify(AccountVerifyCommand request, CancellationToken cancellationToken)
        {
            switch (request.Type)
            {
                case VerifyType.EMAIL:
                    var user = await userManager.FindByIdAsync(request.UserId);
                    if (user == null)
                        return Error<bool>(Text("user.notFound"));

                    var result = await userManager.ConfirmEmailAsync(user, request.Token);
                    if (result.Succeeded)
                    {
                        // audit confirmation
                        var auditEvent = new TokenVerifyEvent(user, request.Token, request.Type.ToString());
                        await Mediator.Publish(auditEvent, cancellationToken);

                        return Result(true);
                    }

                    return Error<bool>(Text("user.tokenInvalid"));

                case VerifyType.MOBILE:
                default:
                    return Error<bool>(Text("user.notSupport"));
            }
        }

        private async Task<Result<bool>> ResetPassword(AccountResetPasswordCommand request)
        {
            var user = await userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return Error<bool>(Text("user.notFound"));

            var result = await userManager.ResetPasswordAsync(user, request.Token, request.Password);
            if (result.Succeeded)
                return Result(true);

            var msg = result.Errors.Select(x => x.Description);
            return Error<bool>(Text("user.resetPasswordFailed", string.Join(". ", msg)));
        }

        private async Task<Result<bool>> ChangePassword(AccountChangePasswordCommand request)
        {
            var result = await userManager.ChangePasswordAsync(currentUser.User, request.Password, request.NewPassword);
            if (result.Succeeded)
                return Result(true);

            return Error<bool>(Text("user.changePasswordFailed", result.Errors));
        }

        #endregion


       
    }
}
