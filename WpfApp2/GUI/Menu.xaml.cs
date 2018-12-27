using MuSearch.GUI;
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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private int userId;

        public Menu(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void OnMyGames(object sender, RoutedEventArgs e)
        {
            MyGames window = new MyGames(this.userId);
            window.Show();
            this.Close();
        }

        private void OnAllGames(object sender, RoutedEventArgs e)
        {
            AllGames window = new AllGames(this.userId);
            window.Show();
            this.Close();
        }

        private void OnStartGame(object sender, RoutedEventArgs e)
        {
            UserInputWindow userInputWindow = new UserInputWindow(this.userId);
            userInputWindow.Show();
            this.Close();
        }
    }
}
