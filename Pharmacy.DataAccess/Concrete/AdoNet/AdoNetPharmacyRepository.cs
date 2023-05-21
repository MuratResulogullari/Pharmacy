using Pharmacy.DataAccess.Abstract;

namespace Pharmacy.DataAccess.Concrete.AdoNet
{
    public class AdoNetPharmacyRepository : AdoNetGenericRepository<Pharmacy.Core.Entities.Pharmacies.Pharmacy>, IPharmacyRepository
    {
    }
}