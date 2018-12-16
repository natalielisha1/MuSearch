using MuSearch.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
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
using WpfApp2.BusinessLayer;

namespace WpfApp2.GUI
{
    /// <summary>
    /// Interaction logic for WordSearchPage.xaml
    /// </summary>
    public partial class WordSearchPage : Window
    {
        private GameGrid gameGrid;
        private Button[,] buttons;

        public WordSearchPage()
        {
            this.gameGrid = Program.getWordSearch(30, 30);
            InitializeComponent();
            drawWordSearch();
        }

        public void drawWordSearch()
        {
            var rows = gameGrid.rows;
            var columns = gameGrid.columns;
            buttons = new Button[rows, columns];
            DataGrid WPFGrid = new DataGrid();
            List<Button> bbbb = new List<Button>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Button b = new Button();
                    b.Content = gameGrid.getCellByPosition(new BusinessLayer.Point(i, j)).value;
                    bbbb.Add(b);
                }
                WPFGrid.ItemsSource = bbbb;
            }
            //WPFGrid.ItemsSource = buttons;
        }
    }
}