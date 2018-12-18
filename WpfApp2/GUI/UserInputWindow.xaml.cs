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
using System.Windows.Shapes;

namespace WpfApp2.GUI
{

    using MuSearch.BusinessLayer;

    /// <summary>
    /// Interaction logic for UserInput.xaml
    /// </summary>
    public partial class UserInputWindow : Window
    {
        public string categoryInput { get; set; }
        private int userId;
        private UserInput userInputBL;
        MainWindow gameMainWindow;
        List<CheckBox> CategoryBoxes;

        public UserInputWindow(int userId)
        {
            InitializeComponent();
            this.userInputBL = new UserInput();
            this.userId = userId;
            CategoryBoxes = new List<CheckBox>();
            gameMainWindow = new MainWindow(0, ""); //for compilation
        }

        private void btnSubmitClick(object sender, RoutedEventArgs e)
        {
            string valid = this.userInputBL.generateCategories(this.txtUserInput.Text);
            if (valid != null)
            {
                gameMainWindow = new MainWindow(userId, valid);
                //creating the check boxes
                CheckBox box;
                //getting here a list of all the categories
                List<string> Categories = new List<string>();
                //categories = getCategories()...
                //creating a list of checkboxes of categories
                for (int i = 0; i < Categories.Count; i++)
                {
                    box = new CheckBox();
                    /*box.Tag = i.ToString();
                    //the name of the category
                    box.Text = Categories[i];
                    //the box isn't checked yet so:
                    box.IsChecked = false;
                    box.AutoSize = true;
                    box.Location = new Point(10, i * 50); //vertical
                                                          //box.Location = new Point(i * 50, 10); //horizontal
                    this.Controls.Add(box);*/
                    this.CategoryBoxes.Add(box);
                }
            }
            else
            {
                // pop up error
                MessageBox.Show("Sorry, this song doesn't exist in our database!");
            }
        }

        private void btnSubmitClick2(object sender, RoutedEventArgs e)
        {
            List<string> checkedCategories = new List<string>();
            //check which categories were checked and add them the list
            for (int i = 0; i < CategoryBoxes.Count; i++) {
                if (CategoryBoxes[i].IsChecked == true)
                {
                    //checkedCategories.Add(CategoryBoxes[i].Text);
                }
            }
            //TODO: do something with the checkedCategories
            //go to next page
            gameMainWindow.Show();
            this.Close();
        }
    }
}
