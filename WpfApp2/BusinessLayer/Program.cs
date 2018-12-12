using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuSearch.DB;
namespace MuSearch.BusinessLayer
{

    class Program
    {
        public static char[,] getWordSearch(int size)
        {
            List<string> words = songs.GetWords();
            WordSearch search = new WordSearch(size, size);
            search.fixWords(words);
            search.createWordSearch(words);
            search.printTable();
            Console.ReadLine();
            return search.GetGameTable();
        }
    }
}
