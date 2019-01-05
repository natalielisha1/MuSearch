using System.Collections.Generic;

namespace WpfApp2.BusinessLayer.Interfaces
{
    interface IUsers
    {
        /// <summary>
        /// The function returns 0 if the user is valid,
        /// and 1 otherwise.
        /// </summary>
        /// <param name="username">a string</param>
        /// <param name="password">a string</param>
        /// <returns></returns>
        int checkUser(string username, string password);

        /// <summary>
        /// checking if the username exist
        /// </summary>
        /// <param name="username">the typed username</param>
        /// <returns>true if he exist, false otherwise</returns>
        bool isUsernameExists(string username);

        /// <summary>
        /// inserting a new user to the users table
        /// </summary>
        /// <param name="userName">the new user's username</param>
        /// <param name="password">the new user's password</param>
        /// <returns>the new user's ID</returns>
        int insertNewUser(string userName, string password);

        /// <summary>
        /// insert the new game to the games table
        /// </summary>
        /// <param name="userID">the user that played the new game</param>
        /// <param name="score">the score from the new game</param>
        void insertNewGame(int userID, int score);

        /// <summary>
        /// The function returns a list of the
        /// top games of the given user
        /// </summary>
        /// <param name="userID">the ID of the user</param>
        /// <returns>list of games</returns>
        List<Game> getTopGames(int userID);

        /// <summary>
        /// The function returns a list of the
        /// top games of all users in the system
        /// </summary>
        /// <returns>list of games</returns>
        List<Game> getTopAllGames();
    }
}
