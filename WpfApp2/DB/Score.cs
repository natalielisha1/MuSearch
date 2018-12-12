using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuSearch.DB
{
    class Score
    {
        string date;
        int score;

        public Score(string d, int s)
        {
            this.date = d;
            this.score = s;
        }

        public int getScore()
        {
            return this.score;
        }

        public string getDate()
        {
            return this.date;
        }
    }
}
