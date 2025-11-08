using System.Data.SqlClient;

namespace HeathEd
{
    public static class DatabaseHelper
    {
        // Connection string - Sử dụng Data Source từ SQL Server Management Studio của bạn
        // Data Source: su (tên server của bạn)
        // Database: HeathEdDB
        public static string ConnectionString = "Data Source=NHAN;User Id=sa;Password=nhandz123;Initial Catalog=HeathEdDB;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
      
        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}