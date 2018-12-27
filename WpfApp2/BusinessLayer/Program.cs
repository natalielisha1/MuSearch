using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuSearch.DB;
using WpfApp2.BusinessLayer;

namespace MuSearch.BusinessLayer
{

    class Program
    {

        public static WordSearch getWordSearch(int rows, int cols)
        {
            try
            {
                List<string> words = songs.GetWords("ifat");
                WordSearch search = new WordSearch(rows, cols);
                search.fixWords(words);
                search.createWordSearch(words);
                //search.printTable();
                Console.ReadLine();
                return search;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
