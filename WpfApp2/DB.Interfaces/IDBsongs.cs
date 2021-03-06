﻿namespace MuSearch.DB.Interfaces
{
    using System.Collections.Generic;
    using WpfApp2.BusinessLayer;

    public interface IDBsongs
    {
        /// <summary>
        /// getting the words to the word search
        /// </summary>
        /// <param name="categories">the categories we want to build the game according it</param>
        /// <returns>a list of the relevant words</returns>
        List<string> GetWords(List<Category> categories);

        /// <summary>
        /// creating the appropriate query
        /// </summary>
        /// <param name="categories">the categories for the query</param>
        /// <returns>the appropriate query</returns>
        string CreateQuery(List<Category> categories);
    }
}