using Pharmacy.Core.CriteriaObjects.Bases;
using Pharmacy.Core.DataTransferObjects;
using System.Linq.Expressions;

namespace Pharmacy.Business.Abstract.Generics
{
    public interface IAsyncService<TEntity> where TEntity : class
    {
        Task<RequestResult> CreateAsync(TEntity entity);

        Task<RequestResult<PagedResult>> SelectAsync(Expression<Func<TEntity, object>> selector, Expression<Func<TEntity, bool>> predicate, PagedCriteriaObject criteria);

        Task<RequestResult> UpdateAsync(TEntity entity);

        Task<RequestResult> DeleteAsync(TEntity entity);

        Task<RequestResult<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, FindCriteriaObject criteria);
    }
}