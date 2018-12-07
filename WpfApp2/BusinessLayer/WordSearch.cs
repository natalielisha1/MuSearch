using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuSearch.BusinessLayer
{
    class WordSearch
    {
        private char[,] gameTable;
        private int rows;
        private int columms;

        public WordSearch(int rows, int columms)
        {
            this.rows = rows;
            this.columms = columms;
            this.gameTable = new char[rows, columms];
        }

        public char[,] GetGameTable()
        {
            return this.gameTable;
        }
        private bool haveRoom(string word, int direction, int posiRow, int posiCol)
        {
            if (direction == 0)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (this.gameTable[posiRow, posiCol + i] != '\0')
                        return false;
                }
            }
            else
                for (int i = 0; i < word.Length; i++)
                {
                    if (this.gameTable[posiRow + i, posiCol] != '\0')
                        return false;
                }
            return true;
        }

        private void insertWord(string word, int direction, int posiRow, int posiCol)
        {
            Console.WriteLine(word + " is in (" + posiRow + ", " + posiCol + ")");
            if (direction == 0)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    this.gameTable[posiRow, posiCol + i] = word[i];
                }
            }
            else
                for (int i = 0; i < word.Length; i++)
                {
                    this.gameTable[posiRow + i, posiCol] = word[i];
                }
        }

        private void fillIn()
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            Random r = new Random();
            int charRandIndex;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columms; j++)
                {
                    if (this.gameTable[i, j] == '\0')
                    {
                        charRandIndex = r.Next(chars.Length);
                        this.gameTable[i, j] = chars[charRandIndex];
                    }
                }
            }
        }

        public void printTable()
        {
            Console.WriteLine("  0 1 2 3 4 5 6 7 8 9 0 1 2 3 4");
            for(int i = 0; i < this.rows; i++)
            {
                Console.Write(i%10);
                for (int j = 0; j < this.columms; j++)
                {
                    Console.Write(" " + this.gameTable[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void createWordSearch(List<string> words)
        {
            Random rnd = new Random();
            int positionRow, positionCol, direction;

            foreach (string word in words)
            {
                direction = rnd.Next(0, 2);
                do
                {
                    if (direction == 0)
                    {
                        positionRow = rnd.Next(0, this.rows);
                        positionCol = rnd.Next(0, this.columms - word.Length);
                    }
                    else
                    {
                        positionRow = rnd.Next(0, this.rows - word.Length);
                        positionCol = rnd.Next(0, this.columms);
                    }
                } while (!this.haveRoom(word, direction, positionRow, positionCol));
                this.insertWord(word, direction, positionRow, positionCol);
            }
            this.fillIn();
        }
    }
}