using Pharmacy.Core.Entities.Users;
using Pharmacy.DataAccess.Abstract.Generics;

namespace Pharmacy.DataAccess.Abstract
{
    public interface IRoleRepository : ISyncRepository<Role>, IAsyncRepository<Role>
    {
    }
}