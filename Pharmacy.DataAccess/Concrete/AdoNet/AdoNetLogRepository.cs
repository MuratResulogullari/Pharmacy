﻿using Npgsql;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.DataTransferObjects.Pharmacies;
using Pharmacy.Core.Entities.Logs;
using Pharmacy.Core.Enums;
using Pharmacy.DataAccess.Abstract;
using Pharmacy.DataAccess.Concrete.Utilities;
using Pharmacy.DataAccess.Configuration;
using Pharmacy.DataAccess.Loggers;

namespace Pharmacy.DataAccess.Concrete.AdoNet
{
    public class AdoNetLogRepository : AdoNetGenericRepository<Log>, ILogRepository
    {
        private readonly string PostgreSQLString = ConfigurationConnectionDatabase.GetConnecxtionString();
        private readonly string Code = DateTime.UtcNow.ToString("G").Replace(".", "").Replace(" ", "").Replace(":", "");

        public override async Task<RequestResult> GetByIdsAsync(int[] Ids)
        {
            RequestResult result = new();

            using (NpgsqlConnection _con = new NpgsqlConnection(PostgreSQLString))
            {
                bool _emptyIds = Ids == null && Ids.Length == 0;
                NpgsqlCommand _cmd = new NpgsqlCommand();
                _cmd.Connection = _con;
                _cmd.CommandText = $"SELECT * FROM logs l WHERE (l.id IN ({string.Join(',', Ids.Select(x => x).ToArray())}))";

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
                    Logger.LogToDatabase(result.Message, result.Success ? (int)ELogType.Info : (int)ELogType.Error, "", Code, 0);
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