using Pharmacy.Business.Abstract;
using Pharmacy.Business.Abstract.Generics;
using Pharmacy.Core.CriteriaObjects.Bases;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.Entities.Users;
using Pharmacy.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Business.Concrete
{
    public class UserTokenManager:IUserTokenService
    {
        private readonly IUserTokenRepository _userTokenRepository;
        public UserTokenManager(IUserTokenRepository userTokenRepository)
        {
            _userTokenRepository = userTokenRepository;
        }
        RequestResult<UserToken> IUserTokenService.GetByUserId(int userId)
        {
            return _userTokenRepository.GetByUserId(userId);
        }
        public RequestResult<bool> Any(Expression<Func<UserToken, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<bool>> AnyAsync(Expression<Func<UserToken, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public RequestResult<int> Count(Expression<Func<UserToken, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<int>> CountAsync(Expression<Func<UserToken, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public RequestResult Create(UserToken entity)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> CreateAsync(UserToken entity)
        {
           return _userTokenRepository.CreateAsync(entity); 
        }

        public RequestResult Delete(UserToken entity)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> DeleteAsync(UserToken entity)
        {
            throw new NotImplementedException();
        }

        public RequestResult Find(Expression<Func<UserToken, bool>> predicate, FindCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<UserToken>> FindAsync(Expression<Func<UserToken, bool>> predicate, FindCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public RequestResult FirstOrDefault(Expression<Func<UserToken, bool>> predicate, CriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> FirstOrDefaultAsync(Expression<Func<UserToken, bool>> predicate, CriteriaObject criteria)
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

        public RequestResult<int> Max(Expression<Func<UserToken, int>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PagedResult>> PagedListAsync(Expression<Func<UserToken, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public RequestResult<PagedResult> Select(Expression<Func<UserToken, object>> selector, Expression<Func<UserToken, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PagedResult>> SelectAsync(Expression<Func<UserToken, object>> selector, Expression<Func<UserToken, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public RequestResult<List<UserToken>> ToList(Expression<Func<UserToken, bool>> predicate, ToListCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<List<UserToken>>> ToListAsync(Expression<Func<UserToken, bool>> predicate, ToListCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public RequestResult Update(UserToken entity)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> UpdateAsync(UserToken entity)
        {
            return _userTokenRepository.UpdateAsync(entity);
        }

        public Task<RequestResult<PagedResult>> WhereAsync(Expression<Func<UserToken, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        RequestResult<bool> ISyncReadService<UserToken>.Any(Expression<Func<UserToken, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult<bool>> IAsyncReadService<UserToken>.AnyAsync(Expression<Func<UserToken, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        RequestResult<int> ISyncReadService<UserToken>.Count(Expression<Func<UserToken, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult<int>> IAsyncReadService<UserToken>.CountAsync(Expression<Func<UserToken, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        RequestResult ISyncService<UserToken>.Create(UserToken entity)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult> IAsyncService<UserToken>.CreateAsync(UserToken entity)
        {
            throw new NotImplementedException();
        }

        RequestResult ISyncService<UserToken>.Delete(UserToken entity)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult> IAsyncService<UserToken>.DeleteAsync(UserToken entity)
        {
            throw new NotImplementedException();
        }

        RequestResult ISyncService<UserToken>.Find(Expression<Func<UserToken, bool>> predicate, FindCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult<UserToken>> IAsyncService<UserToken>.FindAsync(Expression<Func<UserToken, bool>> predicate, FindCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        RequestResult ISyncReadService<UserToken>.FirstOrDefault(Expression<Func<UserToken, bool>> predicate, CriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult> IAsyncReadService<UserToken>.FirstOrDefaultAsync(Expression<Func<UserToken, bool>> predicate, CriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        RequestResult<PagedResult> ISyncReadService<UserToken>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<RequestResult<PagedResult>> IAsyncReadService<UserToken>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        RequestResult ISyncReadService<UserToken>.GetByIds(int[] Ids)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult> IAsyncReadService<UserToken>.GetByIdsAsync(int[] Ids)
        {
            throw new NotImplementedException();
        }

        

        RequestResult<int> ISyncReadService<UserToken>.Max(Expression<Func<UserToken, int>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult<PagedResult>> IAsyncReadService<UserToken>.PagedListAsync(Expression<Func<UserToken, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        RequestResult<PagedResult> ISyncService<UserToken>.Select(Expression<Func<UserToken, object>> selector, Expression<Func<UserToken, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult<PagedResult>> IAsyncService<UserToken>.SelectAsync(Expression<Func<UserToken, object>> selector, Expression<Func<UserToken, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        RequestResult<List<UserToken>> ISyncReadService<UserToken>.ToList(Expression<Func<UserToken, bool>> predicate, ToListCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult<List<UserToken>>> IAsyncReadService<UserToken>.ToListAsync(Expression<Func<UserToken, bool>> predicate, ToListCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        RequestResult ISyncService<UserToken>.Update(UserToken entity)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult> IAsyncService<UserToken>.UpdateAsync(UserToken entity)
        {
            throw new NotImplementedException();
        }

        Task<RequestResult<PagedResult>> IAsyncReadService<UserToken>.WhereAsync(Expression<Func<UserToken, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
