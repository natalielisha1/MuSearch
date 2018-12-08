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
namespace MuSearch
{
    using System.Data;
    using System.Windows.Controls.Primitives;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public char[,] Table { get; set; }
        char[,] _dataArray;

        public DataView DataView { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Table = Create_Table();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Table = Program.showWordSearch();
            this._dataArray = Table;

            var array = this._dataArray;
            var rows = array.GetLength(0);
            var columns = array.GetLength(1);
            var t = new DataTable();

            // Add columns with name "0", "1", "2", ...
            for (var c = 0; c < columns; c++)
            {
                t.Columns.Add(new DataColumn(c.ToString()));
            }

            // Add data to DataTable
            for (var r = 0; r < rows; r++)
            {
                var newRow = t.NewRow();
                for (var c = 0; c < columns; c++)
                {
                    newRow[c] = array[r, c];
                }
                t.Rows.Add(newRow);
            } 
            DataView = t.DefaultView;
            //creating the binding between the grid and the DataView object
            grid.ItemsSource = DataView;
        }

        //the function creates a random 10X10 table with chars
        public char[,] Create_Table()
        {
            char[,] table = new char[10,10];
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int  j = 0; j < table.GetLength(1); j++)
                {
                    //getting random chars for the cells in the table
                    table[i,j] = GetLetter();
                }
            }
            return table;
        }

        // the function generates random chars
        static Random _random = new Random();
        public static char GetLetter()
        {
            // This method returns a random lowercase letter.
            // ... Between 'a' and 'z' inclusize.
            int num = _random.Next(0, 26); // Zero to 25
            char let = (char)('a' + num);
            return let;
        }
    }
}
