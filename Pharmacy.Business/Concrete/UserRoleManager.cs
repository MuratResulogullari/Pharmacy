using Pharmacy.Business.Abstract;
using Pharmacy.Core.CriteriaObjects.Bases;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.Entities.Users;
using Pharmacy.DataAccess.Abstract;
using System.Linq.Expressions;

namespace Pharmacy.Business.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleManager(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public RequestResult Create(UserRole entity)
        {
            return _userRoleRepository.Create(entity);
        }

        public Task<RequestResult> CreateAsync(UserRole entity)
        {
            return _userRoleRepository.CreateAsync(entity);
        }

        public RequestResult Delete(UserRole entity)
        {
            return _userRoleRepository.Delete(entity);
        }

        public Task<RequestResult> DeleteAsync(UserRole entity)
        {
            return _userRoleRepository.DeleteAsync(entity);
        }

        public RequestResult Find(Expression<Func<UserRole, bool>> predicate, FindCriteriaObject criteria)
        {
            return _userRoleRepository.Find(predicate, criteria);
        }

        public Task<RequestResult<UserRole>> FindAsync(Expression<Func<UserRole, bool>> predicate, FindCriteriaObject criteria)
        {
            return _userRoleRepository.FindAsync(predicate, criteria);
        }

        public RequestResult<PagedResult> Select(Expression<Func<UserRole, object>> selector, Expression<Func<UserRole, bool>> predicate, PagedCriteriaObject criteria)
        {
            return _userRoleRepository.Select(selector, predicate, criteria);
        }

        public Task<RequestResult<PagedResult>> SelectAsync(Expression<Func<UserRole, object>> selector, Expression<Func<UserRole, bool>> predicate, PagedCriteriaObject criteria)
        {
            return _userRoleRepository.SelectAsync(selector, predicate, criteria);
        }

        public RequestResult Update(UserRole entity)
        {
            return _userRoleRepository.Update(entity);
        }

        public Task<RequestResult> UpdateAsync(UserRole entity)
        {
            return _userRoleRepository.UpdateAsync(entity);
        }
    }
}