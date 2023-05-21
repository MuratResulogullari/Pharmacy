using Pharmacy.Core.Entities.Users;
using Pharmacy.DataAccess.Abstract.Generics;

namespace Pharmacy.DataAccess.Abstract
{
    public interface IUserRepository : ISyncRepository<User>, IAsyncRepository<User>
    {
    }
}