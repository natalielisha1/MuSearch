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
            this.gameGrid = Program.getWordSearch(30, 30);
            InitializeComponent();
            createWordSearch();
        }

        public void createWordSearch()
        {
            var rows = this.gameGrid.rows;
            var columns = this.gameGrid.columns;

            Button[,] buttons = new Button[rows, columns];
            
        }
    }
}
