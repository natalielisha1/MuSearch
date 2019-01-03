namespace MuSearch.BusinessLayer
{
    using MuSearch.DB;
    using System.Collections.Generic;
    using WpfApp2.General;

    public class Users
    {
        public List<int> games;

        private DBusers conn = new DBusers();

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
        /// The function returns a list of the
        /// top games of the given user
        /// </summary>
        /// <param name="userID">the ID of the user</param>
        /// <returns>list of games</returns>
        public List<Game> getTopGames(int userID)
        {
            return this.conn.getTopGames(userID);
        }

<<<<<<< HEAD
        public List<Game> getTopAllGames()
=======
        /// <summary>
        /// The function returns a list of the
        /// top games of all users in the system
        /// </summary>
        /// <returns>list of games</returns>
        public List<GameAll> getTopAllGames()
>>>>>>> aa49b8b113fc671e45555589ad925544bf113b80
        {
            return this.conn.getAllTopGames();
        }

    }
}