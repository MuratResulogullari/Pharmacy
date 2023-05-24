using Pharmacy.Core.CriteriaObjects.Bases;
using Pharmacy.Core.DataTransferObjects;
using System.Linq.Expressions;

namespace Pharmacy.DataAccess.Abstract.Generics
{
    public interface ISyncReadRepository<TEntity> where TEntity : class
    {
        RequestResult GetByIds(int[] Ids);

        RequestResult FirstOrDefault(Expression<Func<TEntity, bool>> predicate, CriteriaObject criteria);

        RequestResult<bool> Any(Expression<Func<TEntity, bool>> predicate);

        RequestResult<int> Count(Expression<Func<TEntity, bool>> predicate);

        RequestResult<PagedResult> GetAll();

        RequestResult<int> Max(Expression<Func<TEntity, int>> predicate);

        RequestResult<List<TEntity>> ToList(Expression<Func<TEntity, bool>> predicate, ToListCriteriaObject criteria);
    }
}