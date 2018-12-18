namespace MuSearch.BusinessLayer
{
    using MuSearch.DB;
    using System.Collections.Generic;

    public class UserInput
    {
        private DBcategories conn = new DBcategories();

        public string generateCategories(string input)
        {
            return conn.checkCategories(input);
        }
    }
}
