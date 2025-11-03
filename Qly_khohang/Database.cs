using MySql.Data.MySqlClient;

namespace Qly_Khohang
{
    public static class Database
    {
        private static string connectionString =
    "Server=localhost;Database=quanlykho;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
