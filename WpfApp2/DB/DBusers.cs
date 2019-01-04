namespace MuSearch.DB
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.CompilerServices;

    using MuSearch.DB.Interfaces;

    using MySql.Data.MySqlClient;

    using WpfApp2.BusinessLayer;

    public class DBusers : IDBusers
    {
        /// <summary>
        /// checking if the user exist and if he's password is correct
        /// </summary>
        /// <param name="username">the typed username</param>
        /// <param name="password">the typed password</param>
        /// <returns>the user ID of the user or -1 if the user does not exist</returns>
        public int checkUser(string username, string password)
        {
            var dbCon = DBConnection.Instance();
            int userId = -1;
            dbCon.DatabaseName = "musearchdb";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearchdb.checkUser", dbCon.Connection);
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

        /// <summary>
        /// checking if the username exist
        /// </summary>
        /// <param name="username">the typed username</param>
        /// <returns>true if he exist, false otherwise</returns>
        public bool isUsernameExists(string username)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "musearchdb";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearchdb.isUsernameExists", dbCon.Connection);
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

        /// <summary>
        /// inserting a new user to the users table
        /// </summary>
        /// <param name="userName">the new user's username</param>
        /// <param name="password">the new user's password</param>
        /// <returns>the new user's ID</returns>
        public int insertNewUser(string userName, string password)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "musearchdb";
            int userId = -1;
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearchdb.addNewUser", dbCon.Connection);
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

        /// <summary>
        /// insert the new game to the games table
        /// </summary>
        /// <param name="userID">the user that played the new game</param>
        /// <param name="score">the score from the new game</param>
        public void insertNewGame(int userID, int score)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "musearchdb";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearchdb.addGameToUser", dbCon.Connection);
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

        /// <summary>
        /// getting the top 5 games of a user
        /// </summary>
        /// <param name="userID">the ID of the user we want the top 5 games of</param>
        /// <returns>a list of he's top games (limited to 5)</returns>
        public List<Game> getTopGames(int userID)
        {
            List<Game> games = new List<Game>();
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "musearchdb";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearchdb.getTopGames", dbCon.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("userID1", userID));
                cmd.Connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    games.Add(new Game((int)reader["gameId"], reader["userName"].ToString(), (int)reader["points"], reader["date"].ToString()));
                }
                dbCon.Close();
            }
            else
                throw new Exception();
            return games;
        }

        /// <summary>
        /// get the top games of all the users
        /// </summary>
        /// <returns>a list of the top games. limited to 5 games</returns>
        public List<Game> getAllTopGames()
        {
            List<Game> games = new List<Game>();
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "musearchdb";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearchdb.getTopAllGames", dbCon.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter());
                cmd.Connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    games.Add(new Game((int)reader["gameID"], reader["userName"].ToString(), (int)reader["points"], reader["date"].ToString()));
                }
                dbCon.Close();
            }
            else
                throw new Exception();
            return games;
        }
    }
}