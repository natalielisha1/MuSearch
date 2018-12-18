using MuSearch.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
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
            //drawWordSearch();
        }

        public void drawWordSearch()
        {
            var rows = gameGrid.rows;
            var columns = gameGrid.columns;

            string[] labels = new string[] { "Column 0", "Column 1", "Column 2" };

            foreach (string label in labels)
            {
                DataGridTextColumn column = new DataGridTextColumn();
                column.Header = label;
                column.Binding = new Binding(label.Replace(' ', '_'));

                this.dataGrid.Columns.Add(column);
            }

            int[] values = new int[] { 0, 1, 2 };

            dynamic row = new ExpandoObject();

            for (int i = 0; i < labels.Length; i++)
                ((IDictionary<String, Object>)row)[labels[i].Replace(' ', '_')] = values[i];

            dataGrid.Items.Add(row);
        }
    }
}