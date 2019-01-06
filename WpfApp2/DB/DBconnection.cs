using MySql.Data.MySqlClient;

namespace MuSearch.DB
{
    using System;
    using System.Configuration;

    using MuSearch.DB.Interfaces;

    public class DBConnection : IDBconnection
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

        /// <summary>
        /// Instance
        /// </summary>
        /// <returns>unstance of the connection to the data base</returns>
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        /// <summary>
        /// see if the connection is connected
        /// </summary>
        /// <returns>true if it is cinnected and false otherwise</returns>
        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server=localhost; database=" + ConfigurationManager.AppSettings["SchemeName"] + "; UID=" + ConfigurationManager.AppSettings["DBUsername"] + "; password =" + ConfigurationManager.AppSettings["DBPassword"], this.databaseName);
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

        /// <summary>
        /// close the connection
        /// </summary>
        public void Close()
        {
            connection.Close();
        }
    }
}