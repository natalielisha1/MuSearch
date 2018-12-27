using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.General
{
    public class Game
    {
        #region Properties
        public int GameID {get; set;}
        public int Score { get; set; }
        public string Date { get; set; }
        #endregion

        public Game(int id, int score, string date)
        {
            this.GameID = id;
            this.Score = score;
            this.Date = date;
        }
    }
    public class Category
    {
        #region Properties
        public string CategoryName { get; set; }
        public string Input { get; set; }
        public string Categories { get; set; }
        #endregion

        public Category(string categoryName, string input, string categories)
        {
            this.CategoryName = categoryName;
            this.Input = input;
            this.Categories = categories;
        }
    }

}
