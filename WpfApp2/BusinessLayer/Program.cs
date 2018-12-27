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

    class Program
    {

        public static WordSearch getWordSearch(int rows, int cols, List<Category> categories)
        {
            try { 
                List<string> words = songs.GetWords(categories);
                WordSearch search = new WordSearch(rows, cols);
                search.fixWords(words);
                search.createWordSearch(words);
                //search.printTable();
                Console.ReadLine();
                return search;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
