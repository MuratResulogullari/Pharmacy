using Pharmacy.Core.Entities.Users;
using Pharmacy.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DataAccess.Concrete.AdoNet
{
    public class AdoNetUserRepository : AdoNetGenericRepository<User>, IUserRepository
    {
    }
}
