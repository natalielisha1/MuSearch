
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
using MuSearch.BusinessLayer;
using WpfApp2.BusinessLayer.Interfaces;

namespace WpfApp2.GUI
{

    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private IUsers usersBL;

        /// <summary>
        /// Constructor for the LoginPage page
        /// </summary>
        public LoginPage()
        {
            this.InitializeComponent();
            this.usersBL = new Users();
        }

        /// <summary>
        /// When "submit" button is clicked, the function is activated.
        /// If the username and password are valid, the user enters the menu
        /// window, otherwise - an error message pops up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int userId = this.usersBL.checkUser(this.txtUsername.Text, this.txtPassword.Password);
                if (userId != -1)
                {
                    // go to next page
                    Menu menuWindow = new Menu(userId);
                    menuWindow.Show();
                    this.Close();
                }
                else
                {
                    // pop up error
                    MessageBox.Show("Sorry, username or password is incorrect!");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("System Error. \r\nTry again later.");
                this.Close();
            }
        }

        /// <summary>
        /// When "sign in" button is clicked, the function
        /// is activated. It opens the Sign In Page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignInClick(object sender, RoutedEventArgs e)
        {
            SignUpPage signIn = new SignUpPage();
            signIn.Show();
            this.Close();
        }
    }
}