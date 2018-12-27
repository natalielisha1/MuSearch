namespace MuSearch.BusinessLayer
{
    using MuSearch.DB;
    using System.Collections.Generic;
    using WpfApp2.General;

    public class Users
    {
        public List<int> games;

        private DBusers conn = new DBusers();

        public int checkUser(string username, string password)
        {
            return this.conn.checkUser(username, password);
        }

        public List<Game> getTopGames(int userID)
        {
            return this.conn.getTopGames(userID);
        }

        public List<Game> getTopAllGames()
        {
            return this.conn.getAllTopGames();
        }

    }
}