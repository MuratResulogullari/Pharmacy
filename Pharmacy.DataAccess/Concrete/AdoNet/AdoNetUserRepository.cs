using Npgsql;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.Entities.Users;
using Pharmacy.DataAccess.Abstract;
using Pharmacy.DataAccess.Abstract.Generics;
using Pharmacy.DataAccess.Configuration;
using Pharmacy.DataAccess.Loggers;

namespace Pharmacy.DataAccess.Concrete.AdoNet
{
    public class AdoNetUserRepository : AdoNetGenericRepository<User>, IUserRepository
        , ISyncReadRepository<User>
        , IAsyncReadRepository<User>
    {
        private readonly string PostgreSQLString = ConfigurationConnectionDatabase.GetConnecxtionString();
        private readonly string Code = DateTime.UtcNow.ToString("G").Replace(".", "").Replace(" ", "").Replace(":", "");

        public override async Task<RequestResult> CreateAsync(User entity)
        {
            var resultUser = await base.CreateAsync(entity);
            if (!resultUser.Success)
            {
                return resultUser;
            }
            else
            {
                using (NpgsqlConnection _con = new NpgsqlConnection(PostgreSQLString))
                {
                    RequestResult result = new RequestResult();
                    int rowsAffected = 0;
                    try
                    {
                        result.Result = entity;
                        string query = $"";
                        _con.Open();
                        foreach (var role in entity.UserRoles)
                        {
                            query = $"Insert INTO userroles (userid, roleid, languageid, ENABLE, sortorder, createdby, createdon) VALUES ({(int)resultUser.Result} ,{role.Id},{role.LanguageId},{role.Enable},{role.SortOrder},{role.CreatedBy},'{role.CreatedOn}');";
                            var cmd = new NpgsqlCommand(query, _con);

                            rowsAffected = await cmd.ExecuteNonQueryAsync();
                            if (rowsAffected > 0)
                            {
                                result.Success = true;
                            }
                            else
                            {
                                result.Result = (string)result.Result + "," + role.RoleId;
                                result.Message = "Kayıt yapılamayan roller var";
                            }
                            cmd.Dispose();
                            rowsAffected = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Message = $"Kayıt işlemi yapılamadı. Code = {Code} - C1010";
                        Console.WriteLine($"Code= {Code} - StackTrace = {ex.StackTrace} - Message = {ex.Message}");
                        Logger.LogExceptionFile(ex, result.Message);
                    }
                    finally { _con.Close(); }

                    return result;
                }
            }
        }
    }
}