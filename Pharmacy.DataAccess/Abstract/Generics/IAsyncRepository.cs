using Pharmacy.Core.CriteriaObjects.Bases;
using Pharmacy.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DataAccess.Abstract.Generics
{
    public interface IAsyncRepository<TEntity>
         where TEntity : class
    {
        Task<RequestResult> CreateAsync(TEntity entity);

        Task<RequestResult<PagedResult>> SelectAsync(Expression<Func<TEntity, object>> selector, Expression<Func<TEntity, bool>> predicate, PagedCriteriaObject criteria);

        Task<RequestResult> UpdateAsync(TEntity entity);

        Task<RequestResult> DeleteAsync(TEntity entity);

        Task<RequestResult<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, FindCriteriaObject criteria);
    }
}
