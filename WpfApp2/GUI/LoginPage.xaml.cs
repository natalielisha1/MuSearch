namespace WpfApp2.GUI
{
    using System;
    using System.Windows;
    using MuSearch.BusinessLayer;
    using MuSearch.DB;
    using MuSearch.DB.Interfaces;
    using WpfApp2.BusinessLayer;
    using WpfApp2.BusinessLayer.Interfaces;

    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private IUsers usersBL;
        private ISongs songsBL;
        private ICategories categoriesBL;

        /// <summary>
        /// Constructor for the LoginPage page
        /// </summary>
        public LoginPage()
        {
            this.InitializeComponent();

            IDBusers usersDBConn = new DBusers();
            IDBsongs songsDBConn = new DBsongs();
            IDBcategories categoriesDBConn = new DBcategories();

            this.usersBL = new Users(usersDBConn);
            this.songsBL = new Songs(songsDBConn);
            this.categoriesBL = new Categories(categoriesDBConn);
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
                    Menu menuWindow = new Menu(this.usersBL, this.songsBL, this.categoriesBL, userId);
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
            SignUpPage signIn = new SignUpPage(this.usersBL, this.songsBL, this.categoriesBL);
            signIn.Show();
            this.Close();
        }
    }
}