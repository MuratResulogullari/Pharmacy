using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.Entities.Users;
using Pharmacy.DataAccess.Abstract.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DataAccess.Abstract
{
    public interface IUserTokenRepository: IAsyncRepository<UserToken>
    {
        RequestResult<UserToken> GetByUserId(int userId);
    }
}
