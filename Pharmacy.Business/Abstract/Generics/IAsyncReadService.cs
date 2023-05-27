using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pharmacy.Core.CriteriaObjects.Bases;
using Pharmacy.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Business.Abstract.Generics
{
    public interface IAsyncReadService<TEntity> where TEntity : class
    {
      
        Task<RequestResult> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CriteriaObject criteria);

        Task<RequestResult<bool>> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        Task<RequestResult<int>> CountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<RequestResult<PagedResult>> GetAllAsync();

        Task<RequestResult<List<TEntity>>> ToListAsync(Expression<Func<TEntity, bool>> predicate, ToListCriteriaObject criteria);

        Task<RequestResult<PagedResult>> WhereAsync(Expression<Func<TEntity, bool>> predicate);
        Task<RequestResult<PagedResult>> PagedListAsync(Expression<Func<TEntity, bool>> predicate, PagedCriteriaObject criteria);

    }
}
