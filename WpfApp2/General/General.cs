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
        public int GameID { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        public string Date { get; set; }
        #endregion
        /// <summary>
        /// Constructor for Game object
        /// </summary>
        /// <param name="id">game id</param>
        /// <param name="score">the score of the game</param>
        /// <param name="date">the date of the game</param>
        public Game(int id, string username, int score, string date)
        {
            this.GameID = id;
            this.Username = username;
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
        public int Count { get; set; }
        #endregion

        /// <summary>
        /// Constructor for the Category object
        /// </summary>
        /// <param name="categoryName">the name of the category</param>
        /// <param name="input">the original searching word</param>
        /// <param name="categories"> the category type</param>
        public Category(string categoryName, string input, string categories, int count)
        {
            this.CategoryName = categoryName;
            this.Input = input;
            this.Categories = categories;
            this.Count = count;
        }
    }
}