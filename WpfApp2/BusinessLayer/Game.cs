namespace WpfApp2.BusinessLayer
{
    public class Game
    {
        #region Properties
        public int GameID { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        public string Date { get; set; }
        #endregion
        /// <summary>
        /// Constructor for Game object
        /// </summary>
        /// <param name="id">game id</param>
        /// <param name="score">the score of the game</param>
        /// <param name="date">the date of the game</param>
        public Game(int id, string username, int score, string date)
        {
            this.GameID = id;
            this.Username = username;
            this.Score = score;
            this.Date = date;
        }
    }
}