
using Npgsql;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.DataTransferObjects.Users;
using Pharmacy.Core.Entities.Users;
using Pharmacy.Core.Enums;
using Pharmacy.DataAccess.Abstract;
using Pharmacy.DataAccess.Concrete.Utilities;
using Pharmacy.DataAccess.Configuration;
using Pharmacy.DataAccess.Loggers;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacy.DataAccess.Concrete.AdoNet
{
    public class AdoNetRoleRepository : AdoNetGenericRepository<Role>, IRoleRepository
    {
        private readonly string PostgreSQLString = ConfigurationConnectionDatabase.GetConnecxtionString();
        private readonly string Code = DateTime.UtcNow.ToString("G").Replace(".", "").Replace(" ", "").Replace(":", "");
        public override async Task<RequestResult> CreateAsync(Role entity)
        {
            RequestResult result = new();

            using (NpgsqlConnection _con = new NpgsqlConnection(PostgreSQLString))
            {
                NpgsqlCommand _cmd = new NpgsqlCommand();
                _cmd.Connection = _con;
                _cmd.CommandText = $"INSERT INTO roles (name,normalizedName,concurrencyStamp, language_id, enable, sort_order, created_by, created_on, modified_by, modified_on, deleted_by, deleted_on) VALUES (@Name,@NormalizedName,@ConcurrencyStamp,@LanguageId,@Enable,@SortOrder,@CreatedBy,@CreatedOn,@ModifiedBy,@ModifiedOn,@DeletedBy,@DeletedOn);";
             
                _cmd.Parameters.AddWithValue("@Name", entity.Name);
                _cmd.Parameters.AddWithValue("@NormalizedName", entity.NormalizedName);
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

        public override RequestResult Create(Role entity)
        {
            RequestResult result = new();
            int rowsAffected = 0;

            string commandText = @"INSERT INTO roles (NAME, normalizedname, concurrencystamp, languageid, ENABLE, sortorder, createdby, createdon)
                                   VALUES (";
            commandText += entity.Name + ",";
            commandText += entity.Name.Normalize().ToString() + ",";
            commandText += entity.LanguageId + ",";
            commandText += entity.Enable + ",";
            commandText += entity.SortOrder + ",";
            commandText += entity.CreatedBy + ",";
            commandText += DateTime.UtcNow + ");";

            using (SqlConnection _con = new SqlConnection(PostgreSQLString))
            {
                try
                {
                    var cmd = new SqlCommand(commandText, _con);
                    _con.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        result.Success = true;
                        result.Message = "Kayıt işlemi yapıldı.";
                    }
                    else
                    {
                        result.Message = $"Kayıt işlemi yapılamadı. Code = {Code} - C1010";
                    }
                    result.Result = entity;
                }
                catch (Exception ex)
                {
                    result.Message = $"Kayıt işlemi yapılamadı. Code = {Code} - C1010";
                    Console.WriteLine($"Code= {Code} - StackTrace = {ex.StackTrace} - Message = {ex.Message}");
                }
                return result;
            }
        }

        public RequestResult GetByName(string name)
        {
            RequestResult result = new();

            using (NpgsqlConnection con = new NpgsqlConnection(PostgreSQLString))
            {
                string commandText = $"SELECT  * FROM  Roles r  LEFT JOIN userroles ur ON r.id=ur.roleid WHERE  r.deleted_on='' AND r.name='{name}'";
                var command = new NpgsqlCommand(commandText, con);
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
                DataTable dataTable = new DataTable();
                try
                {
                    con.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();
                    List<RoleDTO> list = new List<RoleDTO>();
                    if (reader.HasRows)
                    {
                        list.AddRange(MapToEntity.DataReaderMapToList<RoleDTO>(reader,new string[] {"UserRoles"}));
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

                return result;
            }
        }
    }
}