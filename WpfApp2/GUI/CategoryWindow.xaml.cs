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
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {

        public string categories { get; set; }

        public CategoryWindow(string categories)
        {
            InitializeComponent();
            this.categories = categories;
        }

        private void btnSubmitClick(object sender, RoutedEventArgs e)
        {
            //go to next page
            MainWindow gameMainWindow = new MainWindow();
            gameMainWindow.Show();
            this.Close();
        }
    }
}
