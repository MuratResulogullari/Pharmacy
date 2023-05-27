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

        public RequestResult<bool> Any(Expression<Func<UserRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<bool>> AnyAsync(Expression<Func<UserRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public RequestResult<int> Count(Expression<Func<UserRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<int>> CountAsync(Expression<Func<UserRole, bool>> predicate)
        {
            throw new NotImplementedException();
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

        public RequestResult FirstOrDefault(Expression<Func<UserRole, bool>> predicate, CriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> FirstOrDefaultAsync(Expression<Func<UserRole, bool>> predicate, CriteriaObject criteria)
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

        public RequestResult<int> Max(Expression<Func<UserRole, int>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PagedResult>> PagedListAsync(Expression<Func<UserRole, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public RequestResult<PagedResult> Select(Expression<Func<UserRole, object>> selector, Expression<Func<UserRole, bool>> predicate, PagedCriteriaObject criteria)
        {
            return _userRoleRepository.Select(selector, predicate, criteria);
        }

        public Task<RequestResult<PagedResult>> SelectAsync(Expression<Func<UserRole, object>> selector, Expression<Func<UserRole, bool>> predicate, PagedCriteriaObject criteria)
        {
            return _userRoleRepository.SelectAsync(selector, predicate, criteria);
        }

        public RequestResult<List<UserRole>> ToList(Expression<Func<UserRole, bool>> predicate, ToListCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<List<UserRole>>> ToListAsync(Expression<Func<UserRole, bool>> predicate, ToListCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public RequestResult Update(UserRole entity)
        {
            return _userRoleRepository.Update(entity);
        }

        public Task<RequestResult> UpdateAsync(UserRole entity)
        {
            return _userRoleRepository.UpdateAsync(entity);
        }

        public Task<RequestResult<PagedResult>> WhereAsync(Expression<Func<UserRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}