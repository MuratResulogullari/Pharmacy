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
    public interface ISyncService<TEntity> where TEntity : class
    {
        RequestResult Create(TEntity entity);

        RequestResult<PagedResult> Select(Expression<Func<TEntity, object>> selector, Expression<Func<TEntity, bool>> predicate, PagedCriteriaObject criteria);

        RequestResult Update(TEntity entity);

        RequestResult Delete(TEntity entity);

        RequestResult Find(Expression<Func<TEntity, bool>> predicate, FindCriteriaObject criteria);
    }
}
