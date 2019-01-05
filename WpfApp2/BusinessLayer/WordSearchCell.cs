namespace WpfApp2.BusinessLayer
{
    public class WordSearchCell
    {
        public Point gridPosition;
        public char value;
        public bool partOfTheGame;
        public bool isStartOfWord;
        public string fullWord;
        public int direction;

        /// <summary>
        /// Constructor function for the WordSearchCell object.
        /// </summary>
        /// <param name="pos">the position of the character in the grid</param>
        /// <param name="value">the character, a string</param>
        /// <param name="partOfGame">boolean value, true if the cell is still active
        ///                          in the game, otherwise false</param>
        public WordSearchCell(Point pos, char value, bool partOfGame)
        {
            this.gridPosition = pos;
            this.value = value;
            this.partOfTheGame = partOfGame;
            this.fullWord = "\0";
        }
    }
}
