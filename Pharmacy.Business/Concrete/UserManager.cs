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
            throw new NotImplementedException();
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
    }
}