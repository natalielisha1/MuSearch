namespace MuSearch.BusinessLayer
{
    using MuSearch.DB;

    public class Users
    {
        private DBusers conn = new DBusers();

        public int checkUser(string username, string password)
        {
            return this.conn.checkUser(username, password);
        }

    }
}