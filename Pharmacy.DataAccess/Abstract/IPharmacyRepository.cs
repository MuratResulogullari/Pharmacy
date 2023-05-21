using Pharmacy.DataAccess.Abstract.Generics;

namespace Pharmacy.DataAccess.Abstract
{
    public interface IPharmacyRepository : ISyncRepository<Pharmacy.Core.Entities.Pharmacies.Pharmacy>, IAsyncRepository<Pharmacy.Core.Entities.Pharmacies.Pharmacy>
    {
    }
}