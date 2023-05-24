using Pharmacy.Business.Abstract;
using Pharmacy.Business.Abstract.Generics;
using Pharmacy.Core.CriteriaObjects.Bases;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.DataAccess.Abstract;
using System.Linq.Expressions;

namespace Pharmacy.Business.Concrete
{
    public class PharmacyManager : IPharmacyService
    {
        private readonly IPharmacyRepository _pharmacyRepository;

        public PharmacyManager(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        public RequestResult<bool> Any(Expression<Func<Core.Entities.Pharmacies.Pharmacy, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<bool>> AnyAsync(Expression<Func<Core.Entities.Pharmacies.Pharmacy, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public RequestResult<int> Count(Expression<Func<Core.Entities.Pharmacies.Pharmacy, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<int>> CountAsync(Expression<Func<Core.Entities.Pharmacies.Pharmacy, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public RequestResult FirstOrDefault(Expression<Func<Core.Entities.Pharmacies.Pharmacy, bool>> predicate, CriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> FirstOrDefaultAsync(Expression<Func<Core.Entities.Pharmacies.Pharmacy, bool>> predicate, CriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public RequestResult<PagedResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PagedResult>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public RequestResult GetByIds(int[] Ids)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> GetByIdsAsync(int[] Ids)
        {
            throw new NotImplementedException();
        }

        public RequestResult<int> Max(Expression<Func<Core.Entities.Pharmacies.Pharmacy, int>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PagedResult>> PagedListAsync(Expression<Func<Core.Entities.Pharmacies.Pharmacy, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public RequestResult<List<Core.Entities.Pharmacies.Pharmacy>> ToList(Expression<Func<Core.Entities.Pharmacies.Pharmacy, bool>> predicate, ToListCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<List<Core.Entities.Pharmacies.Pharmacy>>> ToListAsync(Expression<Func<Core.Entities.Pharmacies.Pharmacy, bool>> predicate, ToListCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PagedResult>> WhereAsync(Expression<Func<Core.Entities.Pharmacies.Pharmacy, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        RequestResult ISyncService<Core.Entities.Pharmacies.Pharmacy>.Create(Core.Entities.Pharmacies.Pharmacy entity)
        {
            return _pharmacyRepository.Create(entity);
        }

        Task<RequestResult> IAsyncService<Core.Entities.Pharmacies.Pharmacy>.CreateAsync(Core.Entities.Pharmacies.Pharmacy entity)
        {
            return _pharmacyRepository.CreateAsync(entity);
        }

        RequestResult ISyncService<Core.Entities.Pharmacies.Pharmacy>.Delete(Core.Entities.Pharmacies.Pharmacy entity)
        {
            return _pharmacyRepository.Delete(entity);
        }

        Task<RequestResult> IAsyncService<Core.Entities.Pharmacies.Pharmacy>.DeleteAsync(Core.Entities.Pharmacies.Pharmacy entity)
        {
            return _pharmacyRepository.DeleteAsync(entity);
        }

        RequestResult ISyncService<Core.Entities.Pharmacies.Pharmacy>.Find(Expression<Func<Core.Entities.Pharmacies.Pharmacy, bool>> predicate, FindCriteriaObject criteria)
        {
            return _pharmacyRepository.Find(predicate, criteria);
        }

        Task<RequestResult<Core.Entities.Pharmacies.Pharmacy>> IAsyncService<Core.Entities.Pharmacies.Pharmacy>.FindAsync(Expression<Func<Core.Entities.Pharmacies.Pharmacy, bool>> predicate, FindCriteriaObject criteria)
        {
            return _pharmacyRepository.FindAsync(predicate, criteria);
        }

        RequestResult<PagedResult> ISyncService<Core.Entities.Pharmacies.Pharmacy>.Select(Expression<Func<Core.Entities.Pharmacies.Pharmacy, object>> selector, Expression<Func<Core.Entities.Pharmacies.Pharmacy, bool>> predicate, PagedCriteriaObject criteria)
        {
            return _pharmacyRepository.Select(selector, predicate, criteria);
        }

        Task<RequestResult<PagedResult>> IAsyncService<Core.Entities.Pharmacies.Pharmacy>.SelectAsync(Expression<Func<Core.Entities.Pharmacies.Pharmacy, object>> selector, Expression<Func<Core.Entities.Pharmacies.Pharmacy, bool>> predicate, PagedCriteriaObject criteria)
        {
            return _pharmacyRepository.SelectAsync(selector, predicate, criteria);
        }

        RequestResult ISyncService<Core.Entities.Pharmacies.Pharmacy>.Update(Core.Entities.Pharmacies.Pharmacy entity)
        {
            return _pharmacyRepository.Update(entity);
        }

        Task<RequestResult> IAsyncService<Core.Entities.Pharmacies.Pharmacy>.UpdateAsync(Core.Entities.Pharmacies.Pharmacy entity)
        {
            return _pharmacyRepository.UpdateAsync(entity);
        }
    }
}