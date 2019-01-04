namespace MuSearch.BusinessLayer
{
    using MuSearch.DB;
    using System.Collections.Generic;

    using MuSearch.DB.Interfaces;

    using WpfApp2.BusinessLayer;
    using WpfApp2.BusinessLayer.Interfaces;

    public class Users : IUsers
    {
        public List<int> games;

        private IDBusers conn = new DBusers();

        /// <summary>
        /// The function returns 0 if the user is valid,
        /// and 1 otherwise.
        /// </summary>
        /// <param name="username">a string</param>
        /// <param name="password">a string</param>
        /// <returns></returns>
        public int checkUser(string username, string password)
        {
            return this.conn.checkUser(username, password);
        }

        /// <summary>
        /// checking if the username exist
        /// </summary>
        /// <param name="username">the typed username</param>
        /// <returns>true if he exist, false otherwise</returns>
        public bool isUsernameExists(string username)
        {
            return this.conn.isUsernameExists(username);
        }

        /// <summary>
        /// inserting a new user to the users table
        /// </summary>
        /// <param name="userName">the new user's username</param>
        /// <param name="password">the new user's password</param>
        /// <returns>the new user's ID</returns>
        public int insertNewUser(string userName, string password)
        {
            return this.conn.insertNewUser(userName,password);
        }

        /// <summary>
        /// insert the new game to the games table
        /// </summary>
        /// <param name="userID">the user that played the new game</param>
        /// <param name="score">the score from the new game</param>
        public void insertNewGame(int userID, int score)
        {
            this.conn.insertNewGame(userID, score);
        }

        /// <summary>
            /// The function returns a list of the
            /// top games of the given user
            /// </summary>
            /// <param name="userID">the ID of the user</param>
            /// <returns>list of games</returns>
            public List<Game> getTopGames(int userID)
        {
            return this.conn.getTopGames(userID);
        }

        /// <summary>
        /// The function returns a list of the
        /// top games of all users in the system
        /// </summary>
        /// <returns>list of games</returns>
        public List<Game> getTopAllGames()
        {
            return this.conn.getAllTopGames();
        }

    }
}