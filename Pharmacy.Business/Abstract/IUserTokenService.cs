using Pharmacy.Business.Abstract.Generics;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Business.Abstract
{
    public interface IUserTokenService: ISyncService<UserToken>, IAsyncService<UserToken>, ISyncReadService<UserToken>, IAsyncReadService<UserToken>
    {
        RequestResult<UserToken> GetByUserId(int userId);

    }
}
