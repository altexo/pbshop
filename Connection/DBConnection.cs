using System;
using MySql.Data.MySqlClient;

namespace pbshop_web.Connection
{
    public class DBConnection : IDisposable
    {
        private MySqlConnection connection;

        public DBConnection(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection Connection { get => connection; set => connection = value; }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}