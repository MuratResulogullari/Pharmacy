using Pharmacy.Business.Abstract.Generics;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.Entities.Users;

namespace Pharmacy.Business.Abstract
{
    public interface IRoleService : ISyncService<Role>, IAsyncService<Role>,ISyncReadService<Role>,IAsyncReadService<Role>
    {
        RequestResult GetByName(string name);
    }
}