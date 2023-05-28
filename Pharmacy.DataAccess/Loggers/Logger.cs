using Npgsql;
using NpgsqlTypes;
using Pharmacy.Core.Enums;
using Pharmacy.DataAccess.Configuration;
using System.Data;

namespace Pharmacy.DataAccess.Loggers
{
    public static class Logger
    {
        private static string PostgreSQLString => ConfigurationConnectionDatabase.GetConnecxtionString();
        private static string Code => DateTime.UtcNow.ToString("G").Replace(".", "").Replace(" ", "").Replace(":", "");

        public static void LogToDatabase(string message, int type, string stackTrace, string code, int createdBy)
        {
            using (NpgsqlConnection _con = new NpgsqlConnection(PostgreSQLString))
            {
                //NpgsqlCommand cmd = new NpgsqlCommand();
                //cmd.Connection = _con;
                //cmd.CommandText = $"INSERT INTO logs (message,type, stack_trace, error_code,created_by, created_on) VALUES (@message, @type, @stack_trace, @error_code, @created_by, @created_on)";
                NpgsqlCommand cmd = new NpgsqlCommand("public.sp_log", _con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@message", NpgsqlDbType.Varchar).Value = message.ToString();
                cmd.Parameters.AddWithValue("@type", NpgsqlDbType.Integer).Value = type;
                cmd.Parameters.AddWithValue("@stack_trace", NpgsqlDbType.Varchar).Value = stackTrace ?? string.Empty;
                cmd.Parameters.AddWithValue("@error_code", NpgsqlDbType.Varchar).Value = code.ToString();
                cmd.Parameters.AddWithValue("@created_by", NpgsqlDbType.Integer).Value = createdBy;
                cmd.Parameters.AddWithValue("@created_on", NpgsqlDbType.Varchar).Value = DateTime.UtcNow.ToString("G");
                _con.Open();

                // int i = cmd.ExecuteNonQuery();
                cmd.ExecuteReader();
                cmd.Dispose();
                _con.Close();
            }
        }

        public static void LogExceptionToDatabase(Exception ex, string code, int createdBy)
        {
            using (NpgsqlConnection _con = new NpgsqlConnection(PostgreSQLString))
            {
                NpgsqlCommand cmd = new NpgsqlCommand("public.sp_log", _con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@message", NpgsqlDbType.Varchar).Value = ex.Message.ToString();
                cmd.Parameters.AddWithValue("@type", NpgsqlDbType.Integer).Value = (int)ELogType.Error;
                cmd.Parameters.AddWithValue("@stack_trace", NpgsqlDbType.Text).Value = ex.StackTrace;
                cmd.Parameters.AddWithValue("@error_code", NpgsqlDbType.Varchar).Value = code.ToString();
                cmd.Parameters.AddWithValue("@created_by", NpgsqlDbType.Integer).Value = createdBy;
                cmd.Parameters.AddWithValue("@created_on", NpgsqlDbType.Varchar).Value = DateTime.UtcNow.ToString("G");
                _con.Open();
                cmd.ExecuteReader();
                cmd.Dispose();
                _con.Close();
            }
        }

        public static void LogExceptionToFile(Exception exc, string msg)
        {
            string logFile = ConfigurationLog.GetFilePath();
            StreamWriter sw = new StreamWriter(logFile, true);
            sw.WriteLine("********** {0} **********", Code);
            if (exc.InnerException != null)
            {
                sw.Write("Inner Exception Type: ");
                sw.WriteLine(exc.InnerException.GetType().ToString());
                sw.Write("Inner Exception: ");
                sw.WriteLine(exc.InnerException.Message);
                sw.Write("Inner Source: ");
                sw.WriteLine(exc.InnerException.Source);
                if (exc.InnerException.StackTrace != null)
                {
                    sw.WriteLine("Inner Stack Trace: ");
                    sw.WriteLine(exc.InnerException.StackTrace);
                }
            }
            sw.Write("Exception ID:");
            sw.WriteLine(((System.Data.SqlClient.SqlException)(exc)).Number);
            sw.Write("Exception Type: ");
            sw.WriteLine(exc.GetType().ToString());
            sw.WriteLine("Exception: " + exc.Message);
            sw.WriteLine("Stack Trace: " + exc.StackTrace ?? string.Empty);
            sw.WriteLine("Message : " + msg);
        }
    }
}