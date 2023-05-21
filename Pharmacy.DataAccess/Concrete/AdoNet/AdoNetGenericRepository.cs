using Pharmacy.Core.CriteriaObjects.Bases;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.DataAccess.Abstract.Generics;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DataAccess.Concrete.AdoNet
{
    public  class AdoNetGenericRepository<TEntity> : ISyncRepository<TEntity>, IAsyncRepository<TEntity> where TEntity : class
    {
        private readonly string PostgreSQLString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ConnectionString;
        public virtual RequestResult Create(TEntity entity)
        {
            
            using (SqlConnection con = new SqlConnection(PostgreSQLString))
            {

                RequestResult result = new();
                try
                {
                    
                    var cmd = new SqlCommand("spAddNew", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@Name", entity.GetType().Name);
                    cmd.ExecuteNonQuery();
                    result.Success = true;
                    result.Message = "Kayıt işlemi yapıldı.";
                    result.Result = entity;
                  
               
                }
                catch (Exception ex)
                {
                    DateTime now = DateTime.UtcNow;
                    result.Success = false;
                    result.Message = $"Kayıt işlemi yapılamadı. Code = {now.ToLongTimeString()} - C1010";
                    Console.WriteLine($"Code= {now.ToLongTimeString()} - StackTrace = {ex.StackTrace} - Message = {ex.Message}");
                }
                return result;
            }
        }

        public virtual Task<RequestResult> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual RequestResult Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<RequestResult> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual RequestResult Find(Expression<Func<TEntity, bool>> predicate, FindCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public virtual Task<RequestResult<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, FindCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public virtual RequestResult<PagedResult> Select(Expression<Func<TEntity, object>> selector, Expression<Func<TEntity, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public virtual Task<RequestResult<PagedResult>> SelectAsync(Expression<Func<TEntity, object>> selector, Expression<Func<TEntity, bool>> predicate, PagedCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public virtual RequestResult Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<RequestResult> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
