using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.BusinessLayer.Interfaces
{
    using WpfApp2.General;

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
