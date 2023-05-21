using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Business.Abstract;
using Pharmacy.Business.Concrete;
using Pharmacy.DataAccess.Abstract;
using Pharmacy.DataAccess.Concrete.AdoNet;

namespace Pharmacy.Business
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            #region Repositories

            services.AddScoped<IUserRepository, AdoNetUserRepository>();
            services.AddScoped<IUserRoleRepository, AdoNetUserRoleRepository>();
            services.AddScoped<IRoleRepository, AdoNetRoleRepository>();
            services.AddScoped<IPharmacyRepository, AdoNetPharmacyRepository>();

            #endregion Repositories

            #region Services

            services.AddScoped<IUserSevice, UserManager>();
            services.AddScoped<IUserRoleService, UserRoleManager>();
            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<IPharmacyService, PharmacyManager>();

            #endregion Services
        }
    }
}