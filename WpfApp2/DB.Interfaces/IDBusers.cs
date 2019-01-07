namespace MuSearch.DB.Interfaces
{
    using System.Collections.Generic;
    using WpfApp2.BusinessLayer;

    public interface IDBusers
    {
        /// <summary>
        /// checking if the user exist and if he's password is correct
        /// </summary>
        /// <param name="username">the typed username</param>
        /// <param name="password">the typed password</param>
        /// <returns>the user ID of the user or -1 if the user does not exist</returns>
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
        /// getting the top 5 games of a user
        /// </summary>
        /// <param name="userID">the ID of the user we want the top 5 games of</param>
        /// <returns>a list of he's top games (limited to 5)</returns>
        List<Game> getTopGames(int userID);

        /// <summary>
        /// get the top games of all the users
        /// </summary>
        /// <returns>a list of the top games. limited to 5 games</returns>
        List<Game> getAllTopGames();
    }
}