
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private Users usersBL;
        public LoginPage()
        {
            InitializeComponent();
            this.usersBL = new Users();
        }

        private void btnSubmitClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int userId = this.usersBL.checkUser(this.txtUsername.Text, this.txtPassword.Password);
                if (userId != -1)
                {
                    //go to next page
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

        private void btnSignInClick(object sender, RoutedEventArgs e)
        {
            SignUpPage signIn = new SignUpPage();
            signIn.Show();
            this.Close();
        }
    }
}