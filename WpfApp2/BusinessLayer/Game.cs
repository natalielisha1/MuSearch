namespace WpfApp2.BusinessLayer
{
    public class Game
    {
        #region Properties
        public string Username { get; set; }
        public int Score { get; set; }
        public string Date { get; set; }
        #endregion
        /// <summary>
        /// Constructor for Game object
        /// </summary>
        /// <param name="username">player's username</param>
        /// <param name="score">the score of the game</param>
        /// <param name="date">the date of the game</param>
        public Game(string username, int score, string date)
        {
            this.Username = username;
            this.Score = score;
            this.Date = date;
        }
    }
}