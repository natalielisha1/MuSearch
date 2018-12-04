using MuSearch.BusinessLayer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MuSearch.GUI
{

    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Page
    {
        private SettingsLogic vm;

        public SettingsView()
        {
            InitializeComponent();
            SettingsModel m = new SettingsModel();
            vm = new SettingsLogic(m);
            this.DataContext = this.vm;
        }
    }
}
