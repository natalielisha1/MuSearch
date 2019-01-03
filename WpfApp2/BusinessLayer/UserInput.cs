namespace MuSearch.BusinessLayer
{
    using MuSearch.DB;
    using System.Collections.Generic;

    using WpfApp2.General;

    public class UserInput
    {
        private DBcategories conn = new DBcategories();

        public List<Category> generateCategories(string input)
        {
            return conn.checkCategories(input);
        }
    }
}
