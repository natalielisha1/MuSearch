using MuSearch.BusinessLayer;
using MuSearch.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using WpfApp2;
using WpfApp2.General;

namespace WpfApp2.GUI
{
    /// <summary>
    /// Interaction logic for Bonus.xaml
    /// </summary>
    public partial class Bonus : Window
    {
        private WordSearch wordSearch;
        private int userID;
        private int userScore;

        public Bonus(WordSearch wordSearchInput, int id, int score)
        {
            InitializeComponent();
            this.userID = id;
            this.userScore = score;
            this.wordSearch = wordSearchInput;
            this.showOptions();
        }

        private void showOptions()
        {
            Random rand = new Random();
            int answerPos = rand.Next(1, 5);
            DBcategories dBcategories = new DBcategories();
            for (int i = 0; i < 4; i++)
            {
                if (answerPos == i)
                    this.options.Items.Add(this.wordSearch.categories[0].CategoryName);
                else
                {
                    Category newCat = dBcategories.randomeCategory(this.wordSearch.categories[0].Categories + "s");
                    this.options.Items.Add(newCat.CategoryName);
                }
            }
        }   

        private void CheckBoxZone_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkZone = (CheckBox)sender;
            int i = Int32.Parse(chkZone.Tag.ToString());
            if (chkZone.Content == this.wordSearch.categories[0].CategoryName)
            {
                this.userScore += 5;
                MessageBox.Show("You are correct, extra 5 points for you!. \r\nGreatWork!");
            }
            else
            {
                MessageBox.Show("You didn't get it right this time, don't worry you still have the points from the game!.\r\n" + "The category was: " + this.wordSearch.categories[0].CategoryName + "\r\nTry again next time");
            }
            // insert this game to the user's games
            DBusers usersDB = new DBusers();
            usersDB.insertNewGame(this.userID, this.userScore);
            //send him back to the menu
            Menu menu = new Menu(userID);
            menu.Show();
            this.Close();
        }

        private void Options_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.options.SelectedValue.ToString() == this.wordSearch.categories[0].CategoryName)
            {
                this.userScore += 5;
                MessageBox.Show("You are correct, extra 5 points for you!. \r\nGreatWork!");
            }
            else
            {
                MessageBox.Show("You didn't get it right this time, don't worry you still have the points from the game!.\r\n" + "The category was: " + this.wordSearch.categories[0].CategoryName + "\r\nTry again next time");
            }
            // insert this game to the user's games
            DBusers usersDB = new DBusers();
            usersDB.insertNewGame(this.userID, this.userScore);
            //send him back to the menu
            Menu menu = new Menu(userID);
            menu.Show();
            this.Close();
        }

        private void ExitNoBunos_Click(object sender, RoutedEventArgs e)
        {
            // insert this game to the user's games
            DBusers usersDB = new DBusers();
            usersDB.insertNewGame(this.userID, this.userScore);
            //send him back to the menu
            Menu menu = new Menu(userID);
            menu.Show();
            this.Close();
        }
    }
}