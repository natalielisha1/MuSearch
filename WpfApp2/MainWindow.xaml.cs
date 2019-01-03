using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MuSearch.BusinessLayer;
using System.ComponentModel;
using System.Windows.Threading;
using System.Timers;

namespace WpfApp2
{
    using MuSearch.DB;
    using MuSearch.GUI;
    using System.Data;
    using System.Diagnostics;
    using System.Windows.Controls.Primitives;
    using WpfApp2.BusinessLayer;
    using WpfApp2.General;
    using WpfApp2.GUI;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string currentTime;
        private Stopwatch stopWatch;
        private List<Category> categories;
        private WordSearch wordSearch; // The current wordSearch
        private int userId; // The current users's ID
        private List<string> userFind; // The list of words the user already found
        private int _UserScore;
        private DispatcherTimer dispatcherTimer;
        public int UserScore
        {
            get { return _UserScore; }
            set
            {
                _UserScore = value;
                OnPropertyChanged("UserScore");
            }
        }// The score of the current user
        private DBusers DBUsers; // A Way To Connect to the DB

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="userId">the ID of the current user</param>
        /// <param name="categories">the categories for this game</param>
        public MainWindow(int userId, List<Category> categories)
        {
            InitializeComponent();
            this.userId = userId;
            this.userFind = new List<string>();
            this.DBUsers = new DBusers();
            this.DataContext = this;
            this.categories = categories;
            dispatcherTimer = new DispatcherTimer();
            stopWatch = new Stopwatch();
            currentTime = string.Empty;
            dispatcherTimer.Tick += new EventHandler(dt_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            lblStopWatch.Content = "00:00:00";
        }

        /// <summary>
        /// clock event
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        void dt_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = stopWatch.Elapsed;
            currentTime = String.Format("{0:00}:{1:00}:{2:00}",
            ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            lblStopWatch.Content = currentTime;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        ///  filling the data grid with the word search we created
        /// </summary>
        private void fillingDataGrid()
        {
            // Make the word search grid and the "show words" button visible
            this.ShowWords.Visibility = Visibility.Visible;
            this.dataGrid.Visibility = Visibility.Visible;

            try
            {
                // Create a new word serch with the wanted size
                this.wordSearch = Program.getWordSearch(20, 20, this.categories);

                // Saving the grid
                GameGrid gameGrid = wordSearch.gameGrid;
                var rows = gameGrid.rows;
                var columns = gameGrid.columns;

                // Filling the word box (that helps the user)
                foreach (string word in this.wordSearch.words.Keys)
                { this.wordBox.Items.Add(word); }

                // Creating a new data table and filling it with the word search
                DataTable dt = new DataTable();
                for (int i = 0; i < columns; i++)
                { dt.Columns.Add(new DataColumn()); }

                for (int i = 0; i < rows; i++)
                {
                    DataRow row = dt.NewRow();
                    for (int j = 0; j < columns; j++)
                    {
                        row[j] = gameGrid.getCellByPosition(new BusinessLayer.Point(i, j)).value;
                    }
                    dt.Rows.Add(row);
                    Console.WriteLine("adding row number " + i);
                }
                Console.WriteLine(dt.Rows.Count);
                // Convert the data table in to data grid
                this.dataGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Error. \r\nTry again later.");
                this.Close();
            }
        }

        /// <summary>
        /// When the button is clicked creat the game
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void startTheGameButton(object sender, RoutedEventArgs e)
        {
            this.fillingDataGrid();
            this.help2.Visibility = Visibility.Visible;
            stopWatch.Start();
            dispatcherTimer.Start();
        }

        /// <summary>
        /// Click on the "my games" buttons. show the "my games" page
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void OnMyGames(object sender, RoutedEventArgs e)
        {
            MyGames window = new MyGames(this.userId);
            window.Show();
            this.Close();
        }

        /// <summary>
        /// Click on the "all games" buttons. show the "all games" page
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void OnAllGames(object sender, RoutedEventArgs e)
        {
            Menu window = new Menu(this.userId);
            window.Show();
            this.Close();
        }

        /// <summary>
        /// When the user clicks on one of the cells in the data grid (that is our word search)
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void DataGrid_MouseCapture(object sender, SelectedCellsChangedEventArgs e)
        {
            //save the location that the user clicks on
            int cellRow = dataGrid.Items.IndexOf(dataGrid.CurrentItem);
            int cellCol = dataGrid.CurrentCell.Column.DisplayIndex;

            //save the cell from the WordSearch in this location
            WordSearchCell choosenCell = this.wordSearch.gameGrid.getCellByPosition(new Point(cellRow, cellCol));

            //if this cell is part of a word and it is the first char of the word
            //then this word is found
            if (choosenCell.partOfTheGame && choosenCell.isStartOfWord)
                //did the user already found it?
                if (this.userFind.Contains(choosenCell.fullWord))
                    MessageBox.Show("You already found: " + choosenCell.fullWord + "! Try a diffrent word.");

                //if it's the first time:
                else
                {
                    //add the word to the list of what the user found and add to his score
                    this.userFind.Add(choosenCell.fullWord);
                    this.UserScore += 2;
                    //color the word he found
                    for (int i = 0; i < choosenCell.fullWord.Length; i++)
                    {
                        if (choosenCell.direction == 0) //horizantle
                            this.colorCell(cellRow, cellCol + i);
                        else
                            this.colorCell(cellRow + i, cellCol);
                    }
                    this.removeFromListBox(choosenCell.fullWord);
                }

            // if the user finished the game
            if (this.userFind.Count() == this.wordSearch.words.Count())
            {
                try
                {
                    //let the user know the game ended
                    MessageBox.Show("The game is over. You found all the words. \r\nGreatWork!");
                    if (this.categories[0].Input == "suprise Category")
                    {
                        Bonus bonusWin = new Bonus(this.wordSearch, this.userId, this.UserScore);
                        bonusWin.Show();
                        this.Close();
                    }
                    else
                    {
                        // insert this game to the user's games
                        this.DBUsers.insertNewGame(this.userId, this.UserScore);
                        //send him back to the menu
                        Menu menu = new Menu(userId);
                        menu.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("System Error. \r\nTry again later.");
                    this.Close();
                }
            }
        }

        /// <summary>
        /// when a word was found it shoud be out the list box of the words
        /// </summary>
        /// <param name="word">the sord we want to remove</param>
        private void removeFromListBox(string word)
        {
            for (int i = 0; i < this.wordBox.Items.Count; i++)
            {
                if (this.wordBox.Items[i].ToString() == word)
                {
                    this.wordBox.Items.Remove(word);
                    break;
                }
            }
        }

        /// <summary>
        /// coloring the cell in the position given
        /// </summary>
        /// <param name="cellRow">the row of the cell</param>
        /// <param name="cellCol">the colunm of the cell</param>
        private void colorCell(int cellRow, int cellCol)
        {
            DataGridCellInfo dataGridCellInfo = new DataGridCellInfo(
                dataGrid.Items[cellRow], dataGrid.Columns[cellCol]);
            DataGridCell dataGridCell = this.GetDataGridCell(dataGridCellInfo);
            dataGridCell.Background = Brushes.Maroon;
            dataGridCellInfo = new DataGridCellInfo(dataGridCell);

            dataGrid.CurrentCell = dataGridCellInfo;
        }

        /// <summary>
        /// return the grid cell given the info
        /// </summary>
        /// <param name="cellInfo">the cell info</param>
        /// <returns></returns>
        private DataGridCell GetDataGridCell(DataGridCellInfo cellInfo)
        {
            var cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
            if (cellContent != null)
                return (DataGridCell)cellContent.Parent;

            return null;
        }

        /// <summary>
        /// clicking on the show words button. show the list box
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void ShowWordsClick(object sender, RoutedEventArgs e)
        {
            this.wordBox.Visibility = Visibility.Visible;
            this.help1.Visibility = Visibility.Visible;
            this.ShowWords.Visibility = Visibility.Hidden;
            this.HideWords.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// clicking on the hide words button. hide the list box
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void HideWordsClick(object sender, RoutedEventArgs e)
        {
            this.wordBox.Visibility = Visibility.Hidden;
            this.help1.Visibility = Visibility.Hidden;
            this.HideWords.Visibility = Visibility.Hidden;
            this.ShowWords.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// double cliding on a word in the list box, showing the word position
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void WordBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.UserScore--;
            string currentWord = wordBox.SelectedValue.ToString();
            Point wordsPos = this.wordSearch.getPosition(currentWord);
            this.colorCell(wordsPos.x, wordsPos.y);
        }

        /// <summary>
        /// clicking on the back button
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void OnBackToMenu(object sender, RoutedEventArgs e)
        {
            Menu window = new Menu(this.userId);
            window.Show();
            this.Close();
        }
        
    }
}