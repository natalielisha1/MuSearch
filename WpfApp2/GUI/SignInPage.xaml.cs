using MuSearch.DB;
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
    /// <summary>
    /// Interaction logic for SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Window
    {
        private DBusers BDUsers;

        public SignInPage()
        {
            InitializeComponent();
            this.BDUsers = new DBusers();
        }

        private void btnSignInClick(object sender, RoutedEventArgs e)
        {
            if (this.txtPassword.Password != this.txtPassword2.Password)
                MessageBox.Show("The passwords are'nt matching, try again.");
            else if(this.BDUsers.isUsernameExists(this.txtUsername.Text))
                MessageBox.Show("Username already exists, try a diffrent username.");
            else
            {
                int userID = this.BDUsers.insertNewUser(this.txtUsername.Text, this.txtPassword.Password);
                MainWindow gameMainWindow = new MainWindow(userID,"ifat");
                gameMainWindow.Show();
                this.Close();
            }
        }
    }
}
