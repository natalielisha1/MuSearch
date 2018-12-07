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
        public static char[,] showWordSearch()
        {
            List<string> names = songs.GetSongs();
            WordSearch search = new WordSearch(30, 30);
            search.createWordSearch(names);
            search.printTable();
            Console.ReadLine();
            return search.GetGameTable();
        }
    }
}
