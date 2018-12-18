using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    using System.Data;

    using MuSearch.BusinessLayer;

    using WpfApp2.General;

    /// <summary>
    /// Interaction logic for AllGames.xaml
    /// </summary>
    public partial class AllGames : Window, INotifyPropertyChanged
    {
        #region Properties
        //public DelegateCommand<object> GoToSettings { get; set; }
        private Users _users;

        private int userId;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public AllGames(int userId)
        {
            InitializeComponent();
            this._users = new Users();
            this.userId = userId;
        }

        public void NotifyPropertyChanged(string prop)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //go to home page
            MainWindow gameMainWindow = new MainWindow(this.userId);
            gameMainWindow.Show();
            this.Close();
        }
    }
}
