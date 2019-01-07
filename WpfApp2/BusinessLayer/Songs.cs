namespace WpfApp2.BusinessLayer
{
    using System.Collections.Generic;
    using Musearch;
    using WpfApp2.BusinessLayer.Interfaces;

    public class Songs : ISongs
    {

        /// <summary>
        /// getting the words to the word search
        /// </summary>
        /// <param name="categories">the categories we want to build the game according it</param>
        /// <returns>a list of the relevant words</returns>
        public List<string> GetWords(List<Category> categories)
        {
            return Container.Instance.songsDB.GetWords(categories);
        }

        /// <summary>
        /// creating the appropriate query
        /// </summary>
        /// <param name="categories">the categories for the query</param>
        /// <returns>the appropriate query</returns>
        public string CreateQuery(List<Category> categories)
        {
            return Container.Instance.songsDB.CreateQuery(categories);
        }
    }
}