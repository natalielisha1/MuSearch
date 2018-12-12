namespace MuSearch.DB
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    using MySql.Data.MySqlClient;

    public class DBusers
    {
        public int checkUser(string username, string password)
        {
            var dbCon = DBConnection.Instance();
            int userId = -1;
            dbCon.DatabaseName = "musearch";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearch.checkUser", dbCon.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("username1", username));
                cmd.Parameters.Add(new MySqlParameter("password1", password));
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    userId = (int)result;
                }
                dbCon.Close();
            }
            return userId;
        }
    }
}