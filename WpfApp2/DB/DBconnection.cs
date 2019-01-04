using MySql.Data;
using MySql.Data.MySqlClient;

namespace MuSearch.DB
{
    using System;
    using System.Configuration;

    public class DBConnection
    {
        private DBConnection()
        {
        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server=localhost; database=musearchdb; UID=root; password =" + ConfigurationManager.AppSettings["DBPassword"], this.databaseName);
                connection = new MySqlConnection(connstring);
                try
                {
                    connection.Open();
                }catch (Exception e)
                {
                    return false;
                }
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}