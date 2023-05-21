using Pharmacy.Core.Entities.Users;
using Pharmacy.DataAccess.Abstract.Generics;

namespace Pharmacy.DataAccess.Abstract
{
    public interface IUserRoleRepository : ISyncRepository<UserRole>, IAsyncRepository<UserRole>
    {
    }
}