using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.BusinessLayer
{
    public class GameGrid
    {
        public WordSearchCell[,] grid;
        public int rows;
        public int columns;

        /// <summary>
        /// The function defines a grid using
        /// the number of columns and rows in it.
        /// <param name="row">number of rows in the grid</param>
        /// <param name="col">number of columns in the grid</param>
        /// </summary>
        public GameGrid(int row, int col)
        {
            this.rows = row;
            this.columns = col;
            this.grid = new WordSearchCell[rows, columns];
        }

        /// <summary>
        /// The function returns the WordSearchCell in the given position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public WordSearchCell getCellByPosition(Point pos)
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    if (grid[i, j] != null && this.grid[i, j].gridPosition.equal(pos))
                        return this.grid[i, j];
                }
            }
            return null;
        }

        /// <summary>
        /// The function inserts the given word in the game grid
        /// starting from the given position and continue in the
        /// given direction.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="direction"></param>
        /// <param name="position"></param>
        public void insertWord(string word, int direction, Point position)
        {
            // print confirmation message to the console
            Console.WriteLine(word + " is in: " + position.printPoint());

            if (direction == 0) // horizontal
            {
                // for every letter in the word
                for (int i = 0; i < word.Length; i++)
                {
                    Point newPosition = new Point(position.x, position.y + i);
                    WordSearchCell newCell = new WordSearchCell(newPosition, word[i], true);
                    newCell.fullWord = word; // for every new cell define the current word as the full word of the cell
                    newCell.direction = direction;
                    if (i == 0) // if it's the start of the word
                        newCell.isStartOfWord = true;
                    else // otherwise
                        newCell.isStartOfWord = false;
                    grid[position.x, position.y + i] = newCell;
                }
            }
            else // vertical
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

        /// <summary>
        /// The function
        /// </summary>
        public void fillIn()
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            Random r = new Random();
            int charRandIndex;

            //for every cell in the grid
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    if (grid[i, j] == null) // if the cell is empty
                    {
                        // put a random letter in the empty cell
                        Point cellPos = new Point(i, j);
                        charRandIndex = r.Next(chars.Length);
                        grid[i, j] = new WordSearchCell(cellPos, chars[charRandIndex], false);
                    }
                }
            }
        }
    }
}