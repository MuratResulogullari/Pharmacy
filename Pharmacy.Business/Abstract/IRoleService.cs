using Pharmacy.Business.Abstract.Generics;
using Pharmacy.Core.Entities.Users;

namespace Pharmacy.Business.Abstract
{
    public interface IRoleService : ISyncService<Role>, IAsyncService<Role>
    {
    }
}