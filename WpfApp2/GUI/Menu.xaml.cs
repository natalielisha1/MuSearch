namespace WpfApp2.GUI
{
    using System.Windows;
    using MuSearch.GUI;
    using WpfApp2.BusinessLayer.Interfaces;

    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private int userId;
        private IUsers usersBL;
        private ISongs songsBL;
        private ICategories categoriesBL;

        /// <summary>
        /// Constructor function for Menu window
        /// </summary>
        public Menu(IUsers usersbl, ISongs songsbl, ICategories categoriesbl, int userId)
        {
            this.InitializeComponent();
            this.usersBL = usersbl;
            this.songsBL = songsbl;
            this.categoriesBL = categoriesbl;
            this.userId = userId;
        }

        /// <summary>
        /// OnClick function. when MY GAMES button pressed the function
        /// is activated and the My Games window opens.
        /// </summary>
        private void OnMyGames(object sender, RoutedEventArgs e)
        {
            MyGames window = new MyGames(this.usersBL, this.songsBL, this.categoriesBL, this.userId);
            window.Show();
            this.Close();
        }

        /// <summary>
        /// OnClick function. when ALL GAMES button pressed the function
        /// is activated and the All Games window opens.
        /// </summary>
        private void OnAllGames(object sender, RoutedEventArgs e)
        {
            AllGames window = new AllGames(this.usersBL, this.songsBL, this.categoriesBL, this.userId);
            window.Show();
            this.Close();
        }

        /// <summary>
        /// OnClick function. when Start button pressed the function
        /// is activated and the GameAll screen shows.
        /// </summary>
        private void OnStartGame(object sender, RoutedEventArgs e)
        {
            UserInputWindow userInputWindow = new UserInputWindow(this.usersBL, this.songsBL, this.categoriesBL,  this.userId);
            userInputWindow.Show();
            this.Close();
        }

        /// <summary>
        /// OnClick function. when EXIT button pressed the function
        /// is activated and the program shuts safely.
        /// </summary>
        private void OnExit(object sender, RoutedEventArgs e)
        {
            this.Close();
            return;
        }
    }
}
