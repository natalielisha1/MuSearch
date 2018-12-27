using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.BusinessLayer
{
    class GameGrid
    {
        public WordSearchCell[,] grid;
        public int rows;
        public int columns;

        public GameGrid(int row, int col)
        {
            this.rows = row;
            this.columns = col;
            this.grid = new WordSearchCell[rows, columns];
        }


        public WordSearchCell getCellByPosition(Point pos)
        {
            for(int i = 0; i < this.rows; i++)
            {
                for(int j = 0; j < this.columns; j++)
                {
                    if (grid[i, j] != null && this.grid[i, j].gridPosition.equal(pos))
                        return this.grid[i, j];
                }
            }
            return null;
        }

        public void insertWord(string word, int direction, Point position)
        {
            Console.WriteLine(word + " is in: " + position.printPoint());

            if (direction == 0) //hurizantel
            {
                for (int i = 0; i < word.Length; i++)
                {
                    Point newPosition = new Point(position.x, position.y + i);
                    WordSearchCell newCell = new WordSearchCell(newPosition, word[i], true);
                    newCell.fullWord = word;
                    newCell.direction = direction;
                    if (i == 0)
                        newCell.isStartOfWord = true;
                    else
                        newCell.isStartOfWord = false;
                    grid[position.x, position.y + i] = newCell;
                }
            }
            else
                for (int i = 0; i < word.Length; i++)
                {
                    Point newPosition = new Point(position.x + i, position.y);
                    WordSearchCell newCell = new WordSearchCell(newPosition, word[i], true);
                    newCell.fullWord = word;
                    newCell.direction = direction;
                    if (i == 0)
                        newCell.isStartOfWord = true;
                    else
                        newCell.isStartOfWord = false;
                    grid[position.x + i, position.y] = newCell;
                }
        }

        public void fillIn()
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            Random r = new Random();
            int charRandIndex;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    if (grid[i, j] == null)
                    {
                        Point cellPos = new Point(i, j);
                        charRandIndex = r.Next(chars.Length);
                        grid[i, j] = new WordSearchCell(cellPos, chars[charRandIndex], false);
                    }
                }
            }
        }
    }
}
