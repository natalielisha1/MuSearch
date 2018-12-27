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
namespace WpfApp2
{
    using MuSearch.DB;
    using MuSearch.GUI;
    using System.Data;
    using System.Windows.Controls.Primitives;
    using WpfApp2.BusinessLayer;
    using WpfApp2.GUI;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WordSearch wordSearch;
        private int userId;
        private List<string> userFind;
        private int userScore;
        public DataView DataView { get; set; }
        private DBusers DBUsers;
        private bool gameEnd;

        public MainWindow(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.userFind = new List<string>();
            this.DBUsers = new DBusers();
            this.gameEnd = false;
        }

        private void fillingDataGrid()
        {
            this.ShowWords.Visibility = Visibility.Visible;
            this.dataGrid.Visibility = Visibility.Visible;
            this.wordSearch = Program.getWordSearch(20, 20);
            GameGrid gameGrid = wordSearch.gameGrid;
            foreach (string word in this.wordSearch.words.Keys)
            {
                this.wordBox.Items.Add(word);
            }
            var rows = gameGrid.rows;
            var columns = gameGrid.columns;

            DataTable dt = new DataTable();
            for (int i = 0; i < columns; i++)
            {
                dt.Columns.Add(new DataColumn());
            }

            for (int i = 0; i < rows; i++)
            {
                DataRow row = dt.NewRow();
                for (int j = 0; j < columns; j++)
                {
                    row[j] = gameGrid.getCellByPosition(new BusinessLayer.Point(i, j)).value;
                }
                dt.Rows.Add(row);
            }
            Console.WriteLine(dt.Rows.Count);
            this.dataGrid.ItemsSource = dt.DefaultView;
            //this.dataGrid.Items.RemoveAt(20);


            //Console.WriteLine(this.dataGrid.Items.Count);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.fillingDataGrid();
        }
        private void OnMyGames(object sender, RoutedEventArgs e)
        {
            MyGames window = new MyGames(this.userId);
            window.Show();
            this.Close();
        }

        private void OnAllGames(object sender, RoutedEventArgs e)
        {
            AllGames window = new AllGames(this.userId);
            window.Show();
            this.Close();
        }

        private void DataGrid_MouseCapture(object sender, SelectedCellsChangedEventArgs e)
        {
            //save the location that the user clicks on
            int cellRow = dataGrid.Items.IndexOf(dataGrid.CurrentItem);
            int cellCol = dataGrid.CurrentCell.Column.DisplayIndex;
            //Console.WriteLine(cellRow + ", " + cellCol);
            //save the cell from the WordSearch from this location
            WordSearchCell choosenCell = this.wordSearch.gameGrid.getCellByPosition(new Point(cellRow, cellCol));
            //if this cell is part of a word and it is the beggining of tha word
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
                    this.userScore++;
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
            if (this.userFind.Count() == this.wordSearch.words.Count())
            {
                this.DBUsers.insertNewGame(this.userId, this.userScore);
                //this.gameEnd = true;
                MessageBox.Show("The game is over. You found all the words. \r\nGreatWork!");
                this.dataGrid.Visibility = Visibility.Hidden;
                this.wordBox.Visibility = Visibility.Hidden;
                this.ShowWords.Visibility = Visibility.Hidden;
                this.HideWords.Visibility = Visibility.Hidden;
                this.start.Visibility = Visibility.Hidden;
                this.myGames.Visibility = Visibility.Visible;
                this.allGames.Visibility = Visibility.Visible;
            }
        }

        private void removeFromListBox(string word)
        {
           for(int i = 0; i < this.wordBox.Items.Count; i++)
            {
                if(this.wordBox.Items[i].ToString() == word)
                {
                    this.wordBox.Items.Remove(word);
                    break;
                }
            }
        }

        private void colorCell(int cellRow, int cellCol) 
        {

            DataGridCellInfo dataGridCellInfo = new DataGridCellInfo(
                dataGrid.Items[cellRow], dataGrid.Columns[cellCol]);
            DataGridCell dataGridCell = this.GetDataGridCell(dataGridCellInfo);
            dataGridCell.Background = Brushes.Pink;
            dataGridCellInfo = new DataGridCellInfo(dataGridCell);

            dataGrid.CurrentCell = dataGridCellInfo;
        }

        private DataGridCell GetDataGridCell(DataGridCellInfo cellInfo)
        {
            var cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
            if (cellContent != null)
                return (DataGridCell)cellContent.Parent;

            return null;
        }

        private void ShowWordsClick(object sender, RoutedEventArgs e)
        {
            this.wordBox.Visibility = Visibility.Visible;
            
            this.ShowWords.Visibility = Visibility.Hidden;
            this.HideWords.Visibility = Visibility.Visible;
        }

        private void HideWordsClick(object sender, RoutedEventArgs e)
        {
            this.wordBox.Visibility = Visibility.Hidden;
            this.HideWords.Visibility = Visibility.Hidden;
            this.ShowWords.Visibility = Visibility.Visible;
        }

        private void WordBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string currentWord = wordBox.SelectedValue.ToString();
            Point wordsPos = this.wordSearch.getPosition(currentWord);
            this.colorCell(wordsPos.x, wordsPos.y);
        }
    }
}