

using Pharmacy.Business.Abstract;
using Pharmacy.Core.CriteriaObjects.Bases;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.Entities.Logs;
using Pharmacy.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Business.Concrete
{
    public class LogManager : ILogService
    {
        private readonly ILogRepository _logRepository;
        public LogManager(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public RequestResult<bool> Any(Expression<Func<Log, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<bool>> AnyAsync(Expression<Func<Log, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public RequestResult<int> Count(Expression<Func<Log, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<int>> CountAsync(Expression<Func<Log, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public RequestResult Create(Log entity)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> CreateAsync(Log entity)
        {
            throw new NotImplementedException();
        }

        public RequestResult Delete(Log entity)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> DeleteAsync(Log entity)
        {
            throw new NotImplementedException();
        }

        public RequestResult Find(Expression<Func<Log, bool>> predicate, FindCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<Log>> FindAsync(Expression<Func<Log, bool>> predicate, FindCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public RequestResult FirstOrDefault(Expression<Func<Log, bool>> predicate, CriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> FirstOrDefaultAsync(Expression<Func<Log, bool>> predicate, CriteriaObject criteria)
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

        public RequestResult<int> Max(Expression<Func<Log, int>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PagedResult>> PagedListAsync(Expression<Func<Log, bool>> predicate, PagedCriteriaObject criteria)
        {
            return _logRepository.PagedListAsync(predicate, criteria);
        }

        public RequestResult<PagedResult> Select(Expression<Func<Log, object>> selector, Expression<Func<Log, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PagedResult>> SelectAsync(Expression<Func<Log, object>> selector, Expression<Func<Log, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public RequestResult<List<Log>> ToList(Expression<Func<Log, bool>> predicate, ToListCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<List<Log>>> ToListAsync(Expression<Func<Log, bool>> predicate, ToListCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public RequestResult Update(Log entity)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> UpdateAsync(Log entity)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PagedResult>> WhereAsync(Expression<Func<Log, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
