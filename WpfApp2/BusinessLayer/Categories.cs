namespace WpfApp2.BusinessLayer
{
    using System.Collections.Generic;
    using Musearch;
    using WpfApp2.BusinessLayer.Interfaces;

    public class Categories : ICategories
    {

        /// <summary>
        /// checkCategories
        /// </summary>
        /// <param name="input">the searching word of the user</param>
        /// <returns> a list of categories that are relevant to the input </returns>
        public List<Category> checkCategories(string input)
        {
            return Container.Instance.categoriesDB.checkCategories(input);
        }

        /// <summary>
        /// gets a random category for the surprise word search
        /// </summary>
        /// <param name="tableName">that the category is coming from</param>
        /// <returns>the category that we got</returns>
        public Category randomCategory(string tableName)
        {
            return Container.Instance.categoriesDB.randomCategory(tableName);
        }
    }
}