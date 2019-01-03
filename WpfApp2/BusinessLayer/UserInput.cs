namespace MuSearch.BusinessLayer
{
    using MuSearch.DB;
    using System.Collections.Generic;

    using WpfApp2.General;

    public class UserInput
    {
        private DBcategories conn = new DBcategories();

        /// <summary>
        /// The function returns a list of categories
        /// related to the given input.
        /// </summary>
        /// <param name="input">a keyword</param>
        /// <returns>list of categories</returns>
        public List<Category> generateCategories(string input)
        {
            return conn.checkCategories(input);
        }
    }
}