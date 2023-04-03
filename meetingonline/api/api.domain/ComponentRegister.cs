using api.common.Shared;
using api.common.Shared.Interfaces;
using api.domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using IdentityUser = api.common.Models.Identity.IdentityUser;

namespace api.domain
{
    public static class ComponentRegister
    {
        public static void Register(IServiceCollection services)
        {
            // configuration
            services.AddScoped<IPersistentService<DomainPersistentService>, DomainPersistentService>();

            // register other components
            services.TryAddScoped<IUserStore<IdentityUser>, IdentityService>();
            services.TryAddScoped<ICurrentUser, CurrentUserAccessor>();

            // mediatR
            services.AddMediatR(typeof(ComponentRegister).Assembly);

            services.AddIdentity<IdentityUser>(opt =>
            {
                opt.ClaimsIdentity.RoleClaimType = JwtTokenIssuer.UserRoleClaimType;
                opt.ClaimsIdentity.UserNameClaimType = JwtTokenIssuer.UserNameClaimType;
                opt.ClaimsIdentity.UserIdClaimType = JwtTokenIssuer.UserIdClaimType;
            }).AddDefaultTokenProviders();
        }
    }
}
