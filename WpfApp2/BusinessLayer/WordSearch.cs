using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.BusinessLayer;

namespace MuSearch.BusinessLayer
{
    public class WordSearch
    {
        public GameGrid gameGrid;
        public Dictionary<string, Point> words;
        public List<Category> categories;

        /// <summary>
        /// Construction function of the WordSearch object
        /// </summary>
        /// <param name="rows">number of row in the grid</param>
        /// <param name="columns">number of columns int the grid</param>
        /// <param name="categoryLst">list of categories that will be represented in the grid</param>
        public WordSearch(int rows, int columns, List<Category> categoryLst)
        {
            this.gameGrid = new GameGrid(rows, columns);
            this.words = new Dictionary<string, Point>();
            this.categories = categoryLst;
        }

        /// <summary>
        /// The function checks if a given word can fit in the grid
        /// of the word search in the given direction, starting from
        /// the given position. returns true if can be fitted, and false
        /// otherwise.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="direction"></param>
        /// <param name="position"></param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// The function checks if a given word already exists
        /// in the grid, if so returns true, otherwise false.
        /// </summary>
        /// <param name="word"></param>
        /// <returns>true or false</returns>
        public bool WordExists(string word)
        {
            if (this.words.ContainsKey(word))
                return true;
            return false;
        }

        /// <summary>
        /// The function returns the position the given
        /// word start at.
        /// </summary>
        /// <param name="word"></param>
        /// <returns>a point</returns>
        public Point getPosition(string word)
        {
            if (!this.words.ContainsKey(word))
                return null;
            return this.words[word];
        }

        /// <summary>
        /// The function saves the position of a word in
        /// the word search grid.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="pos">the word's position, a point</param>
        private void savePosition(string word, Point pos)
        {
            this.words.Add(word, pos);
        }

        /// <summary>
        /// The function creates a word search with the given
        /// words.
        /// </summary>
        /// <param name="words">list of strings</param>
        public void createWordSearch(List<string> words)
        {
            // sort the words by length
            List<string> sortedWords = words.OrderBy(x => x.Length).ToList();

            // fix the words so they would fit the convention
            sortedWords = fixWords(sortedWords);
            Random rnd = new Random();
            int direction;
            Point position;

            // put every word in the word search
            foreach (string word in sortedWords)
            {
                direction = rnd.Next(0, 2);
                int i = 0;

                // while the word can be fitted to the place given be the direction and the start position
                // insert the word and save the position of the start of the word
                do
                {
                    i++;
                    if (direction == 0)
                    {
                        position = new Point(rnd.Next(0, gameGrid.rows), rnd.Next(0, gameGrid.columns - word.Length));
                    }
                    else
                    {
                        position = new Point(rnd.Next(0, gameGrid.rows - word.Length), rnd.Next(0, gameGrid.columns));
                    }
                } while (!this.haveRoom(word, direction, position));
                                                                     
                this.gameGrid.insertWord(word, direction, position);
                this.savePosition(word, position);
            }

            // fill the empty spaces in the grid
            this.gameGrid.fillIn();
        }

        /// <summary>
        /// The function fixes the words in the list
        /// so they would fit the convention, and returns them.
        /// </summary>
        /// <param name="words"></param>
        /// <returns>list of strings</returns>
        private List<string> fixWords(List<string> words)
        {
            for (int i = 0; i < words.Count; i++)
            {
                words[i] = words[i].Trim('"');
                words[i] = words[i].ToLower();
                words[i] = words[i].Replace(" ", String.Empty);
            }
            return words;
        }
    }
}