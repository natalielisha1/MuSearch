using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.BusinessLayer;

namespace MuSearch.BusinessLayer
{
    using WpfApp2.General;

    class WordSearch
    {
        public GameGrid gameGrid;
        public Dictionary<string, Point> words;
        public List<Category> categories;

        public WordSearch(int rows, int columns, List<Category> categoryLst)
        {
            this.gameGrid = new GameGrid(rows, columns);
            this.words = new Dictionary<string, Point>();
            this.categories = categoryLst;
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

        public bool WordExists(string word)
        {
            if (this.words.ContainsKey(word))
                return true;
            return false;
        }

        public Point getPosition(string word)
        {
            if (!this.words.ContainsKey(word))
                return null;
            return this.words[word];
        }
        
        private void savePosition(string word, Point pos)
        {
            this.words.Add(word, pos);
        }

        public void createWordSearch(List<string> words)
        {
            List<string> sortedWords = words.OrderBy(x => x.Length).ToList();
            sortedWords = fixWords(sortedWords);
            Random rnd = new Random();
            int direction;
            Point position;

            foreach (string word in sortedWords)
            {
                if (word.Length > 20)
                {
                    continue;
                }
                direction = rnd.Next(0, 2);
                int i = 0;
                do
                {
                    i++;
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
                this.savePosition(word, position);
            }
            gameGrid.fillIn();
        }


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