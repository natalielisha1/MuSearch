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

namespace MuSearch.GUI
{
    //using MuSearch.BusinessLayer;

    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public string Username { get; set; }
        public string Password { get; set; }

        //private Users usersBL;
        public LoginPage()
        {
            InitializeComponent();
            //this.usersBL = new Users();
        }

        private void btnSubmitClick(object sender, RoutedEventArgs e)
        {
            //bool valid = this.usersBL.checkUser(this.txtUsername.Text, this.txtPassword.Password);
            //if (valid)
            //{
                //go to next page
                MainWindow gameMainWindow = new MainWindow();
                gameMainWindow.Show();
                this.Close();

            //}
            //else
            //{
                // pop up error
            //    MessageBox.Show("Sorry, username or password is incorrect!");
            //}
        }
    }
}
