using BO.Core.DataCommon.Shared.Interfaces;
using BO.Core.DataDomain.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BO.Core.DataDomain
{
    public static class ComponentRegister
    {
        public static void Register(IServiceCollection services)
        {
            // configuration
            services.AddScoped<IPersistentService<DomainPersistentService>, DomainPersistentService>();

            // register other components
            // services.TryAddScoped<IUserStore<IdentityUser>, IdentityService>();
            services.TryAddScoped<ICurrentUser, CurrentUserAccessor>();

            // mediatR
            services.AddMediatR(typeof(ComponentRegister).Assembly);

            //services.AddIdentity<IdentityUser>(opt =>
            //{
            //    opt.ClaimsIdentity.RoleClaimType = JwtTokenIssuer.UserRoleClaimType;
            //    opt.ClaimsIdentity.UserNameClaimType = JwtTokenIssuer.UserNameClaimType;
            //    opt.ClaimsIdentity.UserIdClaimType = JwtTokenIssuer.UserIdClaimType;
            //}).AddDefaultTokenProviders();
        }
    }
}
