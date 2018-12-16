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
namespace WpfApp2
{
    using System.Data;
    using System.Windows.Controls.Primitives;
    using WpfApp2.BusinessLayer;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public char[,] Table { get; set; }
        char[,] _dataArray;

        public DataView DataView { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void fillingDataGrid()
        {
            GameGrid dataGrid = Program.getWordSearch(30,30);
            var rows = dataGrid.rows;
            var columns = dataGrid.columns;

            DataTable dt = new DataTable();
            for (int i = 0; i < columns; i++)
            {
                dt.Columns.Add(new DataColumn());
            }

            for (int i = 0; i < rows; i++)
            {
                DataRow row = dt.NewRow();
                for (int j = 0; j < columns; j++)
                {
                    row[j] = dataGrid.getCellByPosition(new BusinessLayer.Point(i, j)).value;
                }
                dt.Rows.Add(row);
            }

            this.dataGrid.ItemsSource = dt.DefaultView;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.fillingDataGrid();
        }





      
    }
}