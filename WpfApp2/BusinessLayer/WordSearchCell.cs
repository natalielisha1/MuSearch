using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.BusinessLayer
{
    class WordSearchCell
    {
        public Point gridPosition;
        public char value;
        public bool partOfTheGame;
        public bool isStartOfWord;
        public string fullWord;
        public int direction;
        
        public WordSearchCell(Point pos, char value, bool partOfGame)
        {
            this.gridPosition = pos;
            this.value = value;
            this.partOfTheGame = partOfGame;
            this.fullWord = "\0";
        }

        /*public Point GetPositionOnGrid()
        {
            return this.gridPosition;
        }*/

        

    }
}
