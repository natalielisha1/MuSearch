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

        public UserInputWindow(int userId)
        {
            InitializeComponent();
            this.userInputBL = new UserInput();
            this.userId = userId;
        }

        private void btnSubmitClick(object sender, RoutedEventArgs e)
        {
            string valid = this.userInputBL.generateCategories(this.txtUserInput.Text);
            if (valid != null)
            {
                MainWindow gameMainWindow = new MainWindow(userId, valid);
                //creating the check boxes
                CheckBox box;
                for (int i = 0; i < 10; i++)
                {
                    box = new CheckBox();
                    /*box.Tag = i.ToString();
                    box.Text = "a";
                    box.AutoSize = true;
                    box.Location = new Point(10, i * 50); //vertical
                                                          //box.Location = new Point(i * 50, 10); //horizontal
                    this.Controls.Add(box);*/
                }
            }
            else
            {
                // pop up error
                MessageBox.Show("Sorry, song's not exist in our database!");
            }
        }

        private void btnSubmitClick2(object sender, RoutedEventArgs e)
        {
            //go to next page
            gameMainWindow.Show();
            this.Close();
        }
    }
}
