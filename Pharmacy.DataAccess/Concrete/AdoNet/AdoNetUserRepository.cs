using Npgsql;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.Entities.Users;
using Pharmacy.Core.Enums;
using Pharmacy.DataAccess.Abstract;
using Pharmacy.DataAccess.Abstract.Generics;
using Pharmacy.DataAccess.Concrete.Utilities;
using Pharmacy.DataAccess.Configuration;
using Pharmacy.DataAccess.Loggers;
using System.Data;

namespace Pharmacy.DataAccess.Concrete.AdoNet
{
    public class AdoNetUserRepository : AdoNetGenericRepository<User>, IUserRepository
        , ISyncReadRepository<User>
        , IAsyncReadRepository<User>
    {
        private readonly string PostgreSQLString = ConfigurationConnectionDatabase.GetConnecxtionString();
        private readonly string Code = DateTime.UtcNow.ToString("G").Replace(".", "").Replace(" ", "").Replace(":", "");

        public RequestResult<User> GetByTCKN(string tckn)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(PostgreSQLString))
            {
                RequestResult<User> result = new();
                string commandText = $"SELECT  * FROM  Users u  WHERE  r.deleted_on='' AND r.TCKN='{tckn}'";
                var command = new NpgsqlCommand(commandText, con);
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
                DataTable dataTable = new DataTable();
                try
                {
                    con.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();
                    List<User> list = new List<User>();
                    if (reader.HasRows)
                    {
                        list.AddRange(MapToEntity.DataReaderMapToList<User>(reader, new string[] { "UserRoles" }));
                        result.Success = true;
                        result.Message = "Kayıt var";
                        result.Result = list.First();
                        List<UserRole> userRoles = new List<UserRole>()
                        {
                            new UserRole() {Id=1,UserId=1,RoleId=1,Role=new Role {Id=1,Name="Admin"}},
                            new UserRole() {Id=1,UserId=1,RoleId=2,Role=new Role {Id=1,Name="User"} }
                        };
                        result.Result.UserRoles = userRoles.ToList();
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

        public override async Task<RequestResult> CreateAsync(User entity)
        {
            RequestResult result = new();

            using (NpgsqlConnection _con = new NpgsqlConnection(PostgreSQLString))
            {
                NpgsqlCommand _cmd = new NpgsqlCommand();
                _cmd.Connection = _con;
                _cmd.CommandText = $"INSERT INTO users (name,tckn,concurrencyStamp, language_id, enable, sort_order, created_by, created_on, modified_by, modified_on, deleted_by, deleted_on) VALUES (@Name,@TCKN,@ConcurrencyStamp,@LanguageId,@Enable,@SortOrder,@CreatedBy,@CreatedOn,@ModifiedBy,@ModifiedOn,@DeletedBy,@DeletedOn);";

                _cmd.Parameters.AddWithValue("@Name", entity.Name);
                _cmd.Parameters.AddWithValue("@TCKN", entity.TCKN);
                _cmd.Parameters.AddWithValue("@ConcurrencyStamp", entity.ConcurrencyStamp);
                _cmd.Parameters.AddWithValue("@Enable", entity.Enable);
                _cmd.Parameters.AddWithValue("@SortOrder", entity.SortOrder);
                _cmd.Parameters.AddWithValue("@CreatedBy", entity.CreatedBy);
                _cmd.Parameters.AddWithValue("@CreatedOn", entity.CreatedOn);
                _cmd.Parameters.AddWithValue("@ModifiedBy", entity.ModifiedBy ?? default);
                _cmd.Parameters.AddWithValue("@ModifiedOn", entity.ModifiedOn ?? string.Empty);
                _cmd.Parameters.AddWithValue("@DeletedBy", entity.DeletedBy ?? default);
                _cmd.Parameters.AddWithValue("@DeletedOn", entity.DeletedOn ?? string.Empty);

                _con.Open();
                try
                {
                    int rowsAffected = await _cmd.ExecuteNonQueryAsync();
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
                    Logger.LogToDatabase(result.Message, result.Success ? (int)ELogType.Info : (int)ELogType.Error, "", Code, entity.CreatedBy);
                }
                catch (Exception ex)
                {
                    result.Message = $"Kayıt işlemi yapılamadı. Code = {Code} - C1010";
                    Console.WriteLine($"Code= {Code} - StackTrace = {ex.StackTrace} - Message = {ex.Message}");
                    Logger.LogExceptionToDatabase(ex, Code, 1);
                }
                finally
                {
                    _con.Close();
                    _con.Open();
                }
            }

            return result;
        }
    }
}