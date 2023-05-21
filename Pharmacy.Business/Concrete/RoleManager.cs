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

        public RequestResult<PagedResult> Select(Expression<Func<Role, object>> selector, Expression<Func<Role, bool>> predicate, PagedCriteriaObject criteria)
        {
            return _roleRepository.Select(selector, predicate, criteria);
        }

        public Task<RequestResult<PagedResult>> SelectAsync(Expression<Func<Role, object>> selector, Expression<Func<Role, bool>> predicate, PagedCriteriaObject criteria)
        {
            return _roleRepository.SelectAsync(selector, predicate, criteria);
        }

        public RequestResult Update(Role entity)
        {
            return _roleRepository.Update(entity);
        }

        public Task<RequestResult> UpdateAsync(Role entity)
        {
            return _roleRepository.UpdateAsync(entity);
        }
    }
}