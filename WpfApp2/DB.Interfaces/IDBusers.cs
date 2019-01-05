namespace MuSearch.DB.Interfaces
{
    using System.Collections.Generic;

    using WpfApp2.BusinessLayer;

    public interface IDBusers
    {
        int checkUser(string username, string password);

        bool isUsernameExists(string username);

        int insertNewUser(string userName, string password);

        void insertNewGame(int userID, int score);

        List<Game> getTopGames(int userID);

        List<Game> getAllTopGames();
    }
}