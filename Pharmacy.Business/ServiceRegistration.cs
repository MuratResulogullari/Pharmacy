using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Business.Abstract;
using Pharmacy.Business.Concrete;
using Pharmacy.Business.Mvc.CurrentUser;
using Pharmacy.DataAccess.Abstract;
using Pharmacy.DataAccess.Concrete.AdoNet;

namespace Pharmacy.Business
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {

            #region Trasients
            services.AddTransient<ICurrentUser, CurrentUser>();
            #endregion
            #region Repositories

            services.AddScoped<IUserRepository, AdoNetUserRepository>();
            services.AddScoped<IUserRoleRepository, AdoNetUserRoleRepository>();
            services.AddScoped<IRoleRepository, AdoNetRoleRepository>();
            services.AddScoped<IPharmacyRepository, AdoNetPharmacyRepository>();
            services.AddScoped<ILogRepository, AdoNetLogRepository>();
            services.AddScoped<IUserTokenRepository, AdoNetUserTokenRepository>();

            #endregion Repositories

            #region Services

            services.AddScoped<IUserSevice, UserManager>();
            services.AddScoped<IUserRoleService, UserRoleManager>();
            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<IPharmacyService, PharmacyManager>();
            services.AddScoped<ILogService,LogManager>();
            services.AddScoped<IUserTokenService,UserTokenManager>();
            #endregion Services


        }
    }
}