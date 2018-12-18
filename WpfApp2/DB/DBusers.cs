namespace MuSearch.DB
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.CompilerServices;

    using MySql.Data.MySqlClient;
    using WpfApp2.General;

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

        public List<Game> getTopGames(int userID)
        {
            List<Game> games = new List<Game>();
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "musearch";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearch.getTopGames", dbCon.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("userID1", userID));
                cmd.Connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    games.Add(new Game((int)reader["gameId"], (int)reader["points"], reader["date"].ToString()));
                }
                dbCon.Close();
            }
            return games;
        }

        public List<Game> getAllTopGames()
        {
            List<Game> games = new List<Game>();
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "musearch";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearch.getTopAllGames", dbCon.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter());
                cmd.Connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    games.Add(new Game((int)reader["gameId"], (int)reader["points"], reader["date"].ToString()));
                }
                dbCon.Close();
            }
            return games;
        }
    }
}