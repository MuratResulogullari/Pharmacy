using Pharmacy.Business.Abstract.Generics;
using Pharmacy.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Business.Abstract
{
    public interface IUserSevice: ISyncService<User>, IAsyncService<User>, ISyncReadService<User>, IAsyncReadService<User>
    {
    }
}
