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
}
