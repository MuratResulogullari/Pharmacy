using Npgsql;
using Pharmacy.DataAccess.Configuration;
using System.Data;

namespace Pharmacy.DataAccess.Loggers
{
    public static class Logger
    {
        private static string PostgreSQLString => ConfigurationConnectionDatabase.GetConnecxtionString();
        private static string Code => DateTime.UtcNow.ToString("G").Replace(".", "").Replace(" ", "").Replace(":", "");

        public static void LogExceptionDatabase(Exception ex, string code, int createdBy)
        {
            using (NpgsqlConnection _con = new NpgsqlConnection(PostgreSQLString))
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = _con;
                cmd.CommandText = $"";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Message", ex.Message.ToString());
                cmd.Parameters.AddWithValue("@Type", ex.GetType().Name.ToString());
                cmd.Parameters.AddWithValue("@StackTrace", ex.StackTrace ?? string.Empty);
                cmd.Parameters.AddWithValue("@ErrorCode", code.ToString());
                cmd.Parameters.AddWithValue("@CreatedBy", createdBy);
                cmd.Parameters.AddWithValue("@CreatedOn", DateTime.UtcNow.ToString("G"));
                _con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                _con.Close();
            }
        }

        public static void LogExceptionFile(Exception exc, string msg)
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