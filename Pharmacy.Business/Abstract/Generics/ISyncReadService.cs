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
    public interface ISyncReadService<TEntity> where TEntity : class
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
