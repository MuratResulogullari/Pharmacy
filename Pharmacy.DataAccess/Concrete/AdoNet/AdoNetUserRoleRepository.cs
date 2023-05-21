using Pharmacy.Core.Entities.Users;
using Pharmacy.DataAccess.Abstract;

namespace Pharmacy.DataAccess.Concrete.AdoNet
{
    public class AdoNetUserRoleRepository : AdoNetGenericRepository<UserRole>, IUserRoleRepository
    {
    }
}