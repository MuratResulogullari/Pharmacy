using Pharmacy.Business.Abstract;
using Pharmacy.Core.CriteriaObjects.Bases;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.Entities.Users;
using Pharmacy.DataAccess.Abstract;
using System.Linq.Expressions;

namespace Pharmacy.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleManager(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public RequestResult<bool> Any(Expression<Func<Role, bool>> predicate)
        {
            return _roleRepository.Any(predicate);
        }

        public Task<RequestResult<bool>> AnyAsync(Expression<Func<Role, bool>> predicate)
        {
            return _roleRepository.AnyAsync(predicate);
        }

        public RequestResult<int> Count(Expression<Func<Role, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<int>> CountAsync(Expression<Func<Role, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public RequestResult Create(Role entity)
        {
            return _roleRepository.Create(entity);
        }

        public Task<RequestResult> CreateAsync(Role entity)
        {
            return _roleRepository.CreateAsync(entity);
        }

        public RequestResult Delete(Role entity)
        {
            return _roleRepository.Delete(entity);
        }

        public Task<RequestResult> DeleteAsync(Role entity)
        {
            return _roleRepository.DeleteAsync(entity);
        }

        public RequestResult Find(Expression<Func<Role, bool>> predicate, FindCriteriaObject criteria)
        {
            return _roleRepository.Find(predicate, criteria);
        }

        public Task<RequestResult<Role>> FindAsync(Expression<Func<Role, bool>> predicate, FindCriteriaObject criteria)
        {
            return _roleRepository.FindAsync(predicate, criteria);
        }

        public RequestResult FirstOrDefault(Expression<Func<Role, bool>> predicate, CriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> FirstOrDefaultAsync(Expression<Func<Role, bool>> predicate, CriteriaObject criteria)
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

        public Task<RequestResult> GetByIdsAsync(int[] Ids, string tableName)
        {
            throw new NotImplementedException();
        }

        public RequestResult GetByName(string name)
        {
            return _roleRepository.GetByName(name); 
        }

        public RequestResult<int> Max(Expression<Func<Role, int>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PagedResult>> PagedListAsync(Expression<Func<Role, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public RequestResult<PagedResult> Select(Expression<Func<Role, object>> selector, Expression<Func<Role, bool>> predicate, PagedCriteriaObject criteria)
        {
            return _roleRepository.Select(selector, predicate, criteria);
        }

        public Task<RequestResult<PagedResult>> SelectAsync(Expression<Func<Role, object>> selector, Expression<Func<Role, bool>> predicate, PagedCriteriaObject criteria)
        {
            return _roleRepository.SelectAsync(selector, predicate, criteria);
        }

        public RequestResult<List<Role>> ToList(Expression<Func<Role, bool>> predicate, ToListCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<List<Role>>> ToListAsync(Expression<Func<Role, bool>> predicate, ToListCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public RequestResult Update(Role entity)
        {
            return _roleRepository.Update(entity);
        }

        public Task<RequestResult> UpdateAsync(Role entity)
        {
            return _roleRepository.UpdateAsync(entity);
        }

        public Task<RequestResult<PagedResult>> WhereAsync(Expression<Func<Role, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}