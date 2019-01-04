using MuSearch.BusinessLayer;
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

    using WpfApp2.BusinessLayer;
    using WpfApp2.BusinessLayer.Interfaces;

    /// <summary>
    /// Interaction logic for Bonus.xaml
    /// </summary>
    public partial class Bonus : Window
    {
        private WordSearch wordSearch;
        private int userID;
        private int userScore;

        private ICategories categoriesBL;

        private IUsers usersBL;

        /// <summary>
        /// Constructor for the Bonus object
        /// </summary>
        /// <param name="wordSearchInput"> the word search that the bonus question is about</param>
        /// <param name="id"> the current user ID </param>
        /// <param name="score">the current score of the current user</param>
        public Bonus(WordSearch wordSearchInput, int id, int score)
        {
            this.InitializeComponent();
            this.userID = id;
            this.userScore = score;
            this.wordSearch = wordSearchInput;
            this.categoriesBL = new Categories();
            this.usersBL = new Users();
            this.showOptions();
        }

        /// <summary>
        /// showing a list of options for the answer on the list box
        /// </summary>
        private void showOptions()
        {
            // choosing randomly the position of the right answer
            Random rand = new Random();
            int answerPos = rand.Next(1, 5);
            for (int i = 0; i < 4; i++)
            {
                // if that is the position of the right answer, insert it
                if (answerPos == i)
                {
                    this.options.Items.Add(this.wordSearch.categories[0].CategoryName);
                }
                else
                {
                    // else, get another random category for the other answers
                    Category newCat = this.categoriesBL.randomCategory(this.wordSearch.categories[0].Categories + "s");
                    this.options.Items.Add(newCat.CategoryName);
                }
            }
        }

        /// <summary>
        /// what happens when a double click event is happening
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void Options_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // if this is the right answer
            if (this.options.SelectedValue.ToString() == this.wordSearch.categories[0].CategoryName)
            {
                // give the user the bonus and let him know
                this.userScore += 5;
                MessageBox.Show("You are correct, extra 5 points for you!. \r\nGreatWork!");
            }
            else
            {
                // else, let him know he didn't choose the right one
                MessageBox.Show("You didn't get it right this time. Don't worry, you still have the points from the game!\r\n" + "The category was: " + this.wordSearch.categories[0].CategoryName + "\r\nTry again next time!");
            }

            // insert this game to the user's games
            this.usersBL.insertNewGame(this.userID, this.userScore);
            
            // send him back to the menu
            Menu menu = new Menu(this.userID);
            menu.Show();
            this.Close();
        }

        /// <summary>
        /// clicking on the "don't want bonus" button
        /// get to the next page with the current score with no bonus
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void ExitNoBonus_Click(object sender, RoutedEventArgs e)
        {
            // insert this game to the user's games
            this.usersBL.insertNewGame(this.userID, this.userScore);
            
            // send him back to the menu
            Menu menu = new Menu(this.userID);
            menu.Show();
            this.Close();
        }
    }
}