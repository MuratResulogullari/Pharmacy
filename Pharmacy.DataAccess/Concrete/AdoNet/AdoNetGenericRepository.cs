using Npgsql;
using Pharmacy.Core.CriteriaObjects.Bases;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.DataAccess.Abstract.Generics;
using Pharmacy.DataAccess.Concrete.Utilities;
using Pharmacy.DataAccess.Configuration;
using Pharmacy.DataAccess.Loggers;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;

namespace Pharmacy.DataAccess.Concrete.AdoNet
{
    public class AdoNetGenericRepository<TEntity> : ISyncRepository<TEntity>
        , IAsyncRepository<TEntity>
        , ISyncReadRepository<TEntity>
        , IAsyncReadRepository<TEntity>
        where TEntity : class
    {
        private readonly string PostgreSQLString = ConfigurationConnectionDatabase.GetConnecxtionString();
        private readonly string Code = DateTime.UtcNow.ToString("G").Replace(".", "").Replace(" ", "").Replace(":", "");

        public RequestResult<bool> Any(Expression<Func<TEntity, bool>> predicate)
        {
            RequestResult<bool> result = new();

            using (NpgsqlConnection con = new NpgsqlConnection(PostgreSQLString))
            {
                string expBody = ((LambdaExpression)predicate).Body.ToString();

                var paramName = predicate.Parameters[0].Name;
                var paramTypeName = predicate.Parameters[0].Type.Name;

                expBody = expBody.Replace(paramName + ".", paramTypeName + ".")
                                 .Replace("AndAlso", "AND");
                Console.WriteLine(expBody);
                string commandText = $"SELECT * FROM {paramTypeName}s WHERE {expBody}";
                var command = new NpgsqlCommand(commandText, con);
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
                DataTable dataTable = new DataTable();
                try
                {
                    con.Open();
                    NpgsqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        result.Success = true;
                        result.Result = true;
                        result.Message = "Kayıt var";
                    }
                    else
                    {
                        result.Message = "Kayıt bulunamadı.";
                    }
                }
                catch (Exception ex)
                {
                    result.Message = $"Mevcut kayıt bulunamadı. Code = {Code} - A3456";
                    Console.WriteLine($"Code= {Code} - StackTrace = {ex.StackTrace} - Message = {ex.Message}");
                }
                finally
                {
                    command.Dispose();
                    con.Close();
                }

                return result;
            }
        }

        public Task<RequestResult<bool>> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public RequestResult<int> Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<int>> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

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
                    result.Success = false;
                    result.Message = $"Kayıt işlemi yapılamadı. Code = {Code} - C1010";
                    Console.WriteLine($"Code= {Code} - StackTrace = {ex.StackTrace} - Message = {ex.Message}");
                }
                return result;
            }
        }

        public virtual async Task<RequestResult> CreateAsync(TEntity entity)
        {
            using (NpgsqlConnection _con = new NpgsqlConnection(PostgreSQLString))
            {
                RequestResult result = new RequestResult();
                int rowsAffected = 0;
                string query = $"INSERT INTO {entity.GetType().Name}s (";
                string values = "";
                var properties = typeof(TEntity).GetProperties();
                properties.Where(x => x.GetValue(entity) != null);
                var cmd = new NpgsqlCommand();
                cmd.Connection = _con;
                foreach (var prop in properties)
                {
                    if (prop.GetValue(entity) == "" || prop.GetValue(entity) == null || prop.Name == "Id" || prop.PropertyType.IsGenericType)
                        continue;

                    query += prop.Name + " ,";

                    if (prop.PropertyType == typeof(string))
                    {
                        values += $"'{prop.GetValue(entity)}'" + " ,";
                    }
                    else if (prop.Name == "CretedOn")
                    {
                        values += $"{DateTime.UtcNow}" + " ,";
                    }
                    else
                    {
                        values += prop.GetValue(entity) + " ,";
                    }
                }
                query = query.Substring(0, query.Length - 1);
                values = values.Substring(0, values.Length - 1);
                query += $") VALUES ({values});";
                try
                {
                    result.Result = entity;
                    cmd.CommandText = query;
                    _con.Open();
                    rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected > 0)
                    {
                        result.Result = rowsAffected;
                        result.Success = true;
                        result.Message = "Kayıt işlemi yapıldı.";
                    }
                    else
                    {
                        result.Message = $"Kayıt işlemi yapılamadı. Code = {Code} - C1010";
                    }
                }
                catch (Exception ex)
                {
                    result.Message = $"Kayıt işlemi yapılamadı. Code = {Code} - C1010";
                    Console.WriteLine($"Code= {Code} - StackTrace = {ex.StackTrace} - Message = {ex.Message}");
                    Logger.LogExceptionToDatabase(ex, Code, 1);
                }
                finally { _con.Close(); }

                return result;
            }
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

        public RequestResult FirstOrDefault(Expression<Func<TEntity, bool>> predicate, CriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public async Task<RequestResult> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CriteriaObject criteria)
        {
            RequestResult result = new RequestResult();
            using (NpgsqlConnection con = new NpgsqlConnection(PostgreSQLString))
            {
                
                string commandText = AddWhereToSelectCommand(predicate);
                var command = new NpgsqlCommand(commandText, con);
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
                DataTable dataTable = new DataTable();
                try
                {
                    con.Open();
                    NpgsqlDataReader reader =await command.ExecuteReaderAsync();
                    List<object> list = new List<object>();
                    if (reader.HasRows)
                    {
                        list.AddRange(MapToEntity.DataReaderMapToList<object>(reader, criteria.Includes));
                        result.Success = true;
                        result.Message = "Kayıt var";
                        result.Result = list.FirstOrDefault();
                    }
                    else
                    {
                        result.Message = "Kayıt bulunamadı.";
                    }
                }
                catch (Exception ex)
                {
                    result.Message = $"Mevcut kayıt bulunamadı. Code = {Code} - A3456";
                    Console.WriteLine($"Code= {Code} - StackTrace = {ex.StackTrace} - Message = {ex.Message}");
                }
                finally
                {
                    command.Dispose();
                    con.Close();
                }
            }
            return result;
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

        public RequestResult<int> Max(Expression<Func<TEntity, int>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<PagedResult>> PagedListAsync(Expression<Func<TEntity, bool>> predicate, PagedCriteriaObject criteria)
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

        public RequestResult<List<TEntity>> ToList(Expression<Func<TEntity, bool>> predicate, ToListCriteriaObject criteria)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult<List<TEntity>>> ToListAsync(Expression<Func<TEntity, bool>> predicate, ToListCriteriaObject criteria)
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

        public Task<RequestResult<PagedResult>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        private string CreateWhereClause(Expression<Func<TEntity, bool>> predicate)
        {
            StringBuilder p = new StringBuilder(predicate.Body.ToString());
            var pName = predicate.Parameters.First();
            p.Replace(pName.Name + ".", "");
            p.Replace("==", "=");
            p.Replace("AndAlso", "and");
            p.Replace("OrElse", "or");
            p.Replace("\"", "\'");
            return p.ToString();
        }
        private string AddWhereToSelectCommand(Expression<Func<TEntity, bool>> predicate, int maxCount = 0)
        {
            string expBody = ((LambdaExpression)predicate).Body.ToString();

            var paramName = predicate.Parameters[0].Name;
            var tableName =predicate.Parameters[0].Type.Name+"s";
            string command = string.Format("{0} where {1}", CreateSelectCommand(maxCount, tableName), CreateWhereClause(predicate));
            return command;
        }

        private string CreateSelectCommand(int maxCount = 0, string tableName="")
        {
            string selectMax = maxCount > 0 ? "TOP " + maxCount.ToString() + " * " : "*";
            string command = string.Format("Select {0} from {1}", selectMax, tableName);
            return command;
        }

    }
}