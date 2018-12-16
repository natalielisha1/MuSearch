using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.BusinessLayer;

namespace MuSearch.BusinessLayer
{
    class WordSearch
    {
        public GameGrid gameGrid;
        public List<string> words;

        public WordSearch(int rows, int columns)
        {
            this.gameGrid = new GameGrid(rows, columns);
        }

        private bool haveRoom(string word, int direction, Point position)
        {
            if (direction == 0)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    Point newPosition = new Point(position.x, position.y + i);
                    if (gameGrid.getCellByPosition(newPosition) != null)
                        return false;
                }
            }
            else
                for (int i = 0; i < word.Length; i++)
                {
                    Point newPosition = new Point(position.x + i, position.y);
                    if (gameGrid.getCellByPosition(newPosition) != null)
                        return false;
                }
            return true;
        }

        /*public void printTable()
        {
            Console.WriteLine("  0 1 2 3 4 5 6 7 8 9 0 1 2 3 4");
            for(int i = 0; i < this.rows; i++)
            {
                Console.Write(i%10);
                for (int j = 0; j < this.columns; j++)
                {
                    Console.Write(" " + this.gameTable[i, j]);
                }
                Console.WriteLine();
            }
        }*/

        public void createWordSearch(List<string> words)
        {
            this.words = words;
            Random rnd = new Random();
            int direction;
            Point position;

            foreach (string word in words)
            {
                direction = rnd.Next(0, 2);
                do
                {
                    if (direction == 0)
                    {
                        position = new Point(rnd.Next(0, gameGrid.rows), rnd.Next(0, gameGrid.columns - word.Length));
                    }
                    else
                    {
                        position = new Point(rnd.Next(0, gameGrid.rows - word.Length), rnd.Next(0,gameGrid.columns));
                    }
                } while (!this.haveRoom(word, direction, position));
                gameGrid.insertWord(word, direction, position);
            }
            gameGrid.fillIn();
        }


        public List<string> fixWords(List<string> words)
        {
            for (int i = 0; i < words.Count; i++)
            {
                words[i] = words[i].ToLower();
                words[i] = words[i].Replace(" ", String.Empty);
            }
            return words;
        }
    }
}