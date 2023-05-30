using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.Entities.Users;
using Pharmacy.DataAccess.Abstract.Generics;

namespace Pharmacy.DataAccess.Abstract
{
    public interface IUserRepository : ISyncRepository<User>, IAsyncRepository<User>
        , ISyncReadRepository<User>
        , IAsyncReadRepository<User>
    {
        RequestResult<User> GetByTCKN(string tckn);
    }
}