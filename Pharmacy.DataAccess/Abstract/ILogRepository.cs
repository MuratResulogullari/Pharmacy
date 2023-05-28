using Pharmacy.Core.Entities.Logs;
using Pharmacy.DataAccess.Abstract.Generics;

namespace Pharmacy.DataAccess.Abstract
{
    public interface ILogRepository : ISyncRepository<Log>
        , IAsyncRepository<Log>
        , ISyncReadRepository<Log>
        , IAsyncReadRepository<Log>
    {
    }
}