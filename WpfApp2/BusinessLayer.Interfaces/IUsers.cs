using System.Collections.Generic;

namespace WpfApp2.BusinessLayer.Interfaces
{
    interface IUsers
    {
        int checkUser(string username, string password);

        bool isUsernameExists(string username);

        int insertNewUser(string userName, string password);

        void insertNewGame(int userID, int score);

        List<Game> getTopGames(int userID);

        List<Game> getTopAllGames();
    }
}
