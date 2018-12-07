namespace MuSearch.BusinessLayer
{
    using MuSearch.DB;

    public class Users
    {
        private DBusers conn = new DBusers();

        public bool checkUser(string username, string password)
        {
            return conn.checkUser(username, password);
        }

    }
}