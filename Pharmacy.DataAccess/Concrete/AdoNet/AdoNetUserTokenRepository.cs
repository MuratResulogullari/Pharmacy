using Npgsql;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.Entities.Users;
using Pharmacy.DataAccess.Abstract;
using Pharmacy.DataAccess.Concrete.Utilities;
using Pharmacy.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DataAccess.Concrete.AdoNet
{
    public class AdoNetUserTokenRepository : AdoNetGenericRepository<UserToken>, IUserTokenRepository
    {
        private readonly string PostgreSQLString = ConfigurationConnectionDatabase.GetConnecxtionString();
        private readonly string Code = DateTime.UtcNow.ToString("G").Replace(".", "").Replace(" ", "").Replace(":", "");

        RequestResult<UserToken> IUserTokenRepository.GetByUserId(int userId)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(PostgreSQLString))
            {
                RequestResult<UserToken> result = new();
                string commandText = $"SELECT  * FROM  UserTokens u  WHERE   r.user_id='{userId}'";
                var command = new NpgsqlCommand(commandText, con);
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
                DataTable dataTable = new DataTable();
                try
                {
                    con.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();
                    List<UserToken> list = new List<UserToken>();
                    if (reader.HasRows)
                    {
                        list.AddRange(MapToEntity.DataReaderMapToListWithCaseMap<UserToken>(reader));
                        result.Success = true;
                        result.Message = "Kayıt var";
                        result.Result =list.First();

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
