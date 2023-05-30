using Pharmacy.Business.Abstract;
using Pharmacy.Business.Abstract.Generics;
using Pharmacy.Core.CriteriaObjects.Bases;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.Entities.Users;
using Pharmacy.DataAccess.Abstract;
using System.Linq.Expressions;

namespace Pharmacy.Business.Concrete
{
    public class UserManager : IUserSevice
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public RequestResult<User> GetByTCKN(string tckn)
        {
            return _userRepository.GetByTCKN(tckn);
        }
        RequestResult ISyncService<User>.Create(User entity)
        {
          return _userRepository.Create(entity);
        }

        RequestResult<PagedResult> ISyncService<User>.Select(Expression<Func<User, object>> selector, Expression<Func<User, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        RequestResult ISyncService<User>.Update(User entity)
        {
            throw new NotImplementedException();
        }

        RequestResult ISyncService<User>.Delete(User entity)
        {
            throw new NotImplementedException();
        }

        RequestResult ISyncService<User>.Find(Expression<Func<User, bool>> predicate, FindCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult> IAsyncService<User>.CreateAsync(User entity)
        {
           return _userRepository.CreateAsync(entity);
        }

        Task<RequestResult<PagedResult>> IAsyncService<User>.SelectAsync(Expression<Func<User, object>> selector, Expression<Func<User, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult> IAsyncService<User>.UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult> IAsyncService<User>.DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult<User>> IAsyncService<User>.FindAsync(Expression<Func<User, bool>> predicate, FindCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public RequestResult GetByIds(int[] Ids)
        {
            throw new NotImplementedException();
        }

        public RequestResult FirstOrDefault(Expression<Func<User, bool>> predicate, CriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public RequestResult<bool> Any(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public RequestResult<int> Count(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public RequestResult<PagedResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public RequestResult<int> Max(Expression<Func<User, int>> predicate)
        {
            throw new NotImplementedException();
        }

        public RequestResult<List<User>> ToList(Expression<Func<User, bool>> predicate, ToListCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> GetByIdsAsync(int[] Ids)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> FirstOrDefaultAsync(Expression<Func<User, bool>> predicate, CriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<bool>> AnyAsync(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<int>> CountAsync(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PagedResult>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<List<User>>> ToListAsync(Expression<Func<User, bool>> predicate, ToListCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PagedResult>> WhereAsync(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PagedResult>> PagedListAsync(Expression<Func<User, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

       
    }
}