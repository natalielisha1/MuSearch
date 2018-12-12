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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MuSearch.BusinessLayer;
using MuSearch.DB;
using WpfApp2.General;

namespace MuSearch.GUI
{
    /// <summary>
    /// Interaction logic for MyGames.xaml
    /// </summary>
    public partial class MyGames : Window
    {
        private Users usersBL;
        public MyGames()
        {
            InitializeComponent();
            usersBL = new Users();
            List<Game> games = this.usersBL.getTopThreeGames(4);
        }
    }
}
