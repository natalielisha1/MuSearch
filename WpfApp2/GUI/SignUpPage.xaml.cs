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
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Window
    {
        private DBusers BDUsers;

        /// <summary>
        /// Constructor for the SignUpPage object
        /// </summary>
        public SignUpPage()
        {
            this.InitializeComponent();
            this.BDUsers = new DBusers();
        }

        /// <summary>
        /// clicking on the sign In button
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void btnSignUpClick(object sender, RoutedEventArgs e)
        {
            try
            {
                // if the passwords aren't matching
                if (this.txtPassword.Password != this.txtPassword2.Password)
                    MessageBox.Show("The passwords are'nt matching, try again.");
                
                // if this username already exist
                else if (this.BDUsers.isUsernameExists(this.txtUsername.Text))
                    MessageBox.Show("Username already exists, try a diffrent username.");
                
                // if everything is OK - add the new user to the DataBase
                else
                {
                    int userID = this.BDUsers.insertNewUser(this.txtUsername.Text, this.txtPassword.Password);
                    Menu gameMainWindow = new Menu(userID);
                    gameMainWindow.Show();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("System Error. \r\nTry again later.");
                this.Close();
            }
        }
    }
}
