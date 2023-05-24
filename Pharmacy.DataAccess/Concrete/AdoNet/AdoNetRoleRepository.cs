using Npgsql;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.DataTransferObjects.Users;
using Pharmacy.Core.Entities.Users;
using Pharmacy.DataAccess.Abstract;
using Pharmacy.DataAccess.Concrete.Utilities;
using Pharmacy.DataAccess.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacy.DataAccess.Concrete.AdoNet
{
    public class AdoNetRoleRepository : AdoNetGenericRepository<Role>, IRoleRepository
    {
        private readonly string PostgreSQLString = ConfigurationConnectionDatabase.GetConnecxtionString();
        private readonly string Code = DateTime.UtcNow.ToString("G").Replace(".", "").Replace(" ", "").Replace(":", "");

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
                string commandText = $"SELECT  * FROM  Roles r  LEFT JOIN userroles ur ON r.id=ur.roleid WHERE  r.deletedon IS NULL AND r.name='{name}'";
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