using Pharmacy.Business.Abstract.Generics;

namespace Pharmacy.Business.Abstract
{
    public interface IPharmacyService : ISyncService<Pharmacy.Core.Entities.Pharmacies.Pharmacy>, IAsyncService<Pharmacy.Core.Entities.Pharmacies.Pharmacy>
    {
    }
}