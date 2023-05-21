using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.Entities.Users;
using Pharmacy.DataAccess.Abstract;
using System.Configuration;
using System.Data.SqlClient;

namespace Pharmacy.DataAccess.Concrete.AdoNet
{
    public class AdoNetRoleRepository : AdoNetGenericRepository<Role>,IRoleRepository
    {
        private readonly string PostgreSQLString = ConfigurationManager.ConnectionStrings["PostgreSQL"].ConnectionString;

        public override RequestResult Create(Role entity)
        {
            RequestResult result = new();
            int rowsAffected = 0;
            DateTime now = DateTime.UtcNow;
            string commandText = @"INSERT INTO ROLES() VALUES()";
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
                        result.Message = $"Kayıt işlemi yapılamadı. Code = {now.ToLongTimeString()} - C1010";
                    }
                    result.Result = entity;
                }
                catch (Exception ex)
                {
                    result.Message = $"Kayıt işlemi yapılamadı. Code = {now.ToLongTimeString()} - C1010";
                    Console.WriteLine($"Code= {now.ToLongTimeString()} - StackTrace = {ex.StackTrace} - Message = {ex.Message}");
                }
                return result;
            }
        }
    }
}