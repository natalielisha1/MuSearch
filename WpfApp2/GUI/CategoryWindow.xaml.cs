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
        private int userId;
        public CategoryWindow(int userId, string categories)
        {
            InitializeComponent();
            this.categories = categories;
            this.userId = userId;
        }

        private void btnSubmitClick(object sender, RoutedEventArgs e)
        {
            //go to next page
            MainWindow gameMainWindow = new MainWindow(this.userId);
            gameMainWindow.Show();
            this.Close();
        }
    }
}
