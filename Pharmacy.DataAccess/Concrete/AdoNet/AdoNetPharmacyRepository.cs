using Microsoft.AspNetCore.Identity;
using Npgsql;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.DataTransferObjects.Pharmacies;
using Pharmacy.Core.Enums;
using Pharmacy.DataAccess.Abstract;
using Pharmacy.DataAccess.Concrete.Utilities;
using Pharmacy.DataAccess.Configuration;
using Pharmacy.DataAccess.Loggers;

namespace Pharmacy.DataAccess.Concrete.AdoNet
{
    public class AdoNetPharmacyRepository : AdoNetGenericRepository<Pharmacy.Core.Entities.Pharmacies.Pharmacy>, IPharmacyRepository
    {
        private readonly string PostgreSQLString = ConfigurationConnectionDatabase.GetConnecxtionString();
        private readonly string Code = DateTime.UtcNow.ToString("G").Replace(".", "").Replace(" ", "").Replace(":", "");

        public override async Task<RequestResult> CreateAsync(Core.Entities.Pharmacies.Pharmacy entity)
        {
            RequestResult result = new();

            using (NpgsqlConnection _con = new NpgsqlConnection(PostgreSQLString))
            {
                NpgsqlCommand _cmd = new NpgsqlCommand();
                _cmd.Connection = _con;
                _cmd.CommandText = $"INSERT INTO pharmacies (name, address, phone_number, email, status, language_id, enable, sort_order, created_by, created_on, modified_by, modified_on, deleted_by, deleted_on) VALUES (@Name,@Address,@PhoneNumber,@Email,@Status,@LanguageId,@Enable,@SortOrder,@CreatedBy,@CreatedOn,@ModifiedBy,@ModifiedOn,@DeletedBy,@DeletedOn);";

                _cmd.Parameters.AddWithValue("@Name", entity.Name);
                _cmd.Parameters.AddWithValue("@Address", entity.Address);
                _cmd.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
                _cmd.Parameters.AddWithValue("@Email", entity.Email);
                _cmd.Parameters.AddWithValue("@Status", (int)entity.Status);
                _cmd.Parameters.AddWithValue("@LanguageId", entity.LanguageId);
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

        public override async Task<RequestResult> UpdateAsync(Core.Entities.Pharmacies.Pharmacy entity)
        {
            RequestResult result = new();

            using (NpgsqlConnection _con = new NpgsqlConnection(PostgreSQLString))
            {
                NpgsqlCommand _cmd = new NpgsqlCommand();
                _cmd.Connection = _con;
                _cmd.CommandText = $"UPDATE pharmacies SET name=@Name, address=@Address, phone_number=@PhoneNumber, email=@Email, status=@Status, language_id=@LanguageId, enable=@Enable, sort_order=@SortOrder, modified_by=@ModifiedBy, modified_on=@ModifiedOn WHERE id=@Id";

                _cmd.Parameters.AddWithValue("@Id", entity.Id);
                _cmd.Parameters.AddWithValue("@Name", entity.Name);
                _cmd.Parameters.AddWithValue("@Address", entity.Address);
                _cmd.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
                _cmd.Parameters.AddWithValue("@Email", entity.Email);
                _cmd.Parameters.AddWithValue("@Status", (int)entity.Status);
                _cmd.Parameters.AddWithValue("@LanguageId", entity.LanguageId);
                _cmd.Parameters.AddWithValue("@Enable", entity.Enable);
                _cmd.Parameters.AddWithValue("@SortOrder", entity.SortOrder);
                _cmd.Parameters.AddWithValue("@ModifiedBy", entity.ModifiedBy ?? default);
                _cmd.Parameters.AddWithValue("@ModifiedOn", entity.ModifiedOn ?? DateTime.UtcNow.ToString("G"));

                _con.Open();
                try
                {
                    int rowsAffected = await _cmd.ExecuteNonQueryAsync();
                    if (rowsAffected > 0)
                    {
                        result.Result = rowsAffected;
                        result.Success = true;
                        result.Message = "Guncelleme işlemi yapıldı.";
                    }
                    else
                    {
                        result.Message = $"Guncelleme işlemi yapılamadı. Code = {Code} - U010";
                    }
                    Logger.LogToDatabase(result.Message, result.Success ? (int)ELogType.Info : (int)ELogType.Error, "", Code, entity.CreatedBy);
                }
                catch (Exception ex)
                {
                    result.Message = $"Guncelleme işlemi yapılamadı. Code = {Code} - U010";
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

        public override async Task<RequestResult> DeleteAsync(Core.Entities.Pharmacies.Pharmacy entity)
        {
            RequestResult result = new();

            using (NpgsqlConnection _con = new NpgsqlConnection(PostgreSQLString))
            {
                NpgsqlCommand _cmd = new NpgsqlCommand();
                _cmd.Connection = _con;
                _cmd.CommandText = $"Select * FROM pharmacies WHERE id=@Id";
                _cmd.Parameters.AddWithValue("@Id", entity.Id);
                _con.Open();
                try
                {
                    NpgsqlDataReader reader = await _cmd.ExecuteReaderAsync();
                    List<Core.Entities.Pharmacies.Pharmacy> list = new List<Core.Entities.Pharmacies.Pharmacy>();
                    if (reader.HasRows)
                    {
                        list.AddRange(MapToEntity.DataReaderMapToListWithCaseMap<Core.Entities.Pharmacies.Pharmacy>(reader));
                        result.Success = true;
                        result.Message = "Silme işlemi yapıldı.";
                        var savedPharmacy = list.FirstOrDefault();
                        savedPharmacy.DeletedBy = entity.DeletedBy ?? 1;
                        savedPharmacy.DeletedOn = DateTime.UtcNow.ToString("G");
                        var resultUpdated = await UpdateAsync(savedPharmacy);
                    }
                    else
                    {
                        result.Message = $"Silme işlemi yapılamadı. Code = {Code} - D2345";
                    }
                    Logger.LogToDatabase(result.Message, result.Success ? (int)ELogType.Info : (int)ELogType.Error, "", Code, entity.CreatedBy);
                }
                catch (Exception ex)
                {
                    result.Message = $"Silme işlemi yapılamadı. Code = {Code} - D2345";
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

        public override async Task<RequestResult> GetByIdsAsync(int[] Ids)
        {
            RequestResult result = new();

            using (NpgsqlConnection _con = new NpgsqlConnection(PostgreSQLString))
            {
                bool _emptyIds = Ids == null && Ids.Length == 0;
                NpgsqlCommand _cmd = new NpgsqlCommand();
                _cmd.Connection = _con;
                _cmd.CommandText = $"SELECT * FROM pharmacies p WHERE (p.id IN ({string.Join(',', Ids.Select(x => x).ToArray())})) AND (p.Enable AND p.Deleted_By = {default(int)}) ";

                _con.Open();
                try
                {
                    NpgsqlDataReader reader = await _cmd.ExecuteReaderAsync();
                    List<PharmacyDTO> list = new List<PharmacyDTO>();
                    if (reader.HasRows)
                    {
                        list.AddRange(MapToEntity.DataReaderMapToListWithCaseMap<PharmacyDTO>(reader));
                        result.Success = true;
                        result.Message = "Kayıt var";
                        result.Result = Ids.Length == 1 ? list.FirstOrDefault() : list.ToList();
                    }
                    else
                    {
                        result.Message = $"Kayıt mevcut değil. Code = {Code} - GBIA2";
                    }
                    Logger.LogToDatabase(result.Message, result.Success ? (int)ELogType.Info : (int)ELogType.Warn, "", Code, 0);
                }
                catch (Exception ex)
                {
                    result.Message = $"Kayıt mevcut değil. Code = {Code} - D2345";
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