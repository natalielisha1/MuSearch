namespace WpfApp2.BusinessLayer.Interfaces
{
    using System.Collections.Generic;

    public interface ICategories
    {
        /// <summary>
        /// checkCategories
        /// </summary>
        /// <param name="input">the searching word of the user</param>
        /// <returns> a list of categories that are relevant to the input </returns>
        List<Category> checkCategories(string input);

        /// <summary>
        /// gets a random category for the surprise word search
        /// </summary>
        /// <param name="tableName">that the category is coming from</param>
        /// <returns>the category that we got</returns>
        Category randomCategory(string tableName);
    }
}