using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuSearch.DB;
using WpfApp2.BusinessLayer;

namespace MuSearch.BusinessLayer
{
    using WpfApp2.General;

    public class Program
    {
        /// <summary>
        /// The function returns a WordSearch object
        /// </summary>
        /// <param name="rows">number of rows in the grid</param>
        /// <param name="cols">number of columns in the grid</param>
        /// <param name="categories">list of the categories in the grid</param>
        /// <returns>a word search</returns>
        public static WordSearch getWordSearch(int rows, int cols, List<Category> categories)
        {
            try
            {
                // get the words in the given categories, those words will be in the word search
                List<string> words = songs.GetWords(categories);
                WordSearch search = new WordSearch(rows, cols, categories);
                search.createWordSearch(words);
                return search;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}