namespace WpfApp2.BusinessLayer
{
    using System.Collections.Generic;

    using MuSearch.DB;
    using MuSearch.DB.Interfaces;

    using WpfApp2.BusinessLayer.Interfaces;

    public class Songs : ISongs
    {
        private IDBsongs conn;// = new DBsongs();

        public Songs(IDBsongs dbConn)
        {
            this.conn = dbConn;
        }

        /// <summary>
        /// getting the words to the word search
        /// </summary>
        /// <param name="categories">the categories we want to build the game according it</param>
        /// <returns>a list of the relevant words</returns>
        public List<string> GetWords(List<Category> categories)
        {
            return this.conn.GetWords(categories);
        }

        /// <summary>
        /// creating the appropriate query
        /// </summary>
        /// <param name="categories">the categories for the query</param>
        /// <returns>the appropriate query</returns>
        public string CreateQuery(List<Category> categories)
        {
            return this.conn.CreateQuery(categories);
        }
    }
}