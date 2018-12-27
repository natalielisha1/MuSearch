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

        public WordSearchPage()
        {
            //this.gameGrid = Program.getWordSearch(30, 30, );
            //InitializeComponent();
            //drawWordSearch();
        }

        public void drawWordSearch()
        {
            var rows = gameGrid.rows;
            var columns = gameGrid.columns;
            //DataGrid WPFGrid = new DataGrid();

            for(int i = 0; i < columns; i++)
            {
                xmlGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for(int i = 0; i < rows; i++)
            {
                //TODO
            }
        }
    }
}