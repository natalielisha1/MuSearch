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
            else
                throw new Exception();
            return userId;
        }

        public bool isUsernameExists(string username)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "musearch";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearch.isUsernamExists", dbCon.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("username1", username));
                if (cmd.Connection.State.ToString() != "Open")
                    cmd.Connection.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    dbCon.Close();
                    return true;
                }
                dbCon.Close();
            }
            else
                throw new Exception();
            return false;
        }

        public int insertNewUser(string userName, string password)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "musearch";
            int userId = -1;
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearch.addNewUser", dbCon.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("username1", userName));
                cmd.Parameters.Add(new MySqlParameter("password1", password));
                if (cmd.Connection.State.ToString() != "Open")
                    cmd.Connection.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    userId = (int)result;
                }
                dbCon.Close();
            }
            else
                throw new Exception();
            return userId;

        }

        public void insertNewGame(int userID, int score)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "musearch";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearch.addGameToUser", dbCon.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("userID1", userID));
                cmd.Parameters.Add(new MySqlParameter("score1", score));
                if (cmd.Connection.State.ToString() != "Open")
                    cmd.Connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dbCon.Close();
            }
            else
                throw new Exception();
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
            else
                throw new Exception();
            return games;
        }

        public List<GameAll> getAllTopGames()
        {
            List<GameAll> games = new List<GameAll>();
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
                    games.Add(new GameAll(reader["userName"].ToString(), (int)reader["points"], reader["date"].ToString()));
                }
                dbCon.Close();
            }
            else
                throw new Exception();
            return games;
        }
    }
}