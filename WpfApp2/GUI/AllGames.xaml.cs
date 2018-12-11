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
    /// <summary>
    /// Interaction logic for AllGames.xaml
    /// </summary>
    public partial class AllGames : Window, INotifyPropertyChanged
    {
        #region Properties
        //public DelegateCommand<object> GoToSettings { get; set; }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public AllGames()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public void NotifyPropertyChanged(string prop)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


    }
}
