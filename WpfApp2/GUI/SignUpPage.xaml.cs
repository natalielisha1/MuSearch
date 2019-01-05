namespace WpfApp2.GUI
{
    using System;
    using System.Windows;
    using WpfApp2.BusinessLayer.Interfaces;
    using MuSearch.BusinessLayer;

    /// <summary>
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Window
    {
        private IUsers usersBL;

        /// <summary>
        /// Constructor for the SignUpPage object
        /// </summary>
        public SignUpPage()
        {
            this.InitializeComponent();
            this.usersBL = new Users();
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
                    MessageBox.Show("The passwords aren't matching, try again.");
                
                // if this username already exist
                else if (this.usersBL.isUsernameExists(this.txtUsername.Text))
                    MessageBox.Show("Username already exists, try a different username.");
                
                // if everything is OK - add the new user to the DataBase
                else
                {
                    int userID = this.usersBL.insertNewUser(this.txtUsername.Text, this.txtPassword.Password);
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

        /// <summary>
        /// The function shows the client the menu window
        /// and closes the current window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            // go to login page
            LoginPage login = new LoginPage();
            login.Show();
            this.Close();
        }
    }
}
