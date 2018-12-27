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
using WpfApp2.BusinessLayer;
using MuSearch.DB;
using WpfApp2.General;
using MuSearch.BusinessLayer;
using System.Data;
using WpfApp2;

namespace MuSearch.GUI
{
   /// <summary>
    /// Interaction logic for MyGames.xaml
    /// </summary>
    public partial class MyGames : Window
    {
        private Users usersBL;
        private int userId;
        List<Game> games { get; set; }

        /// <summary>
        /// Constructor function for My Games window.
        /// </summary>
        public MyGames(int userId)
        {
            InitializeComponent();
            usersBL = new Users();
            this.userId = userId;
            this.ShowTopGames();
        }


        public void ShowTopGames()
        {
            List<Game> games = this.usersBL.getTopGames(this.userId);
            var rows = games.Count;
            DataTable dt = new DataTable();

            DataColumn columnId = new DataColumn();
            columnId.Caption = "Id";
            columnId.ColumnName = "Id";
            columnId.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(columnId);

            DataColumn columnScore = new DataColumn();
            columnScore.Caption = "Score";
            columnScore.ColumnName = "Score";
            columnId.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(columnScore);

            DataColumn columnDate = new DataColumn();
            columnDate.Caption = "Date";
            columnDate.ColumnName = "Date";
            columnId.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(columnDate);

            for (int i = 0; i < rows; i++)
            {
                DataRow row = dt.NewRow();
                row["Id"] = games[i].GameID;
                row["Score"] = games[i].Score;
                row["Date"] = games[i].Date;
                dt.Rows.Add(row);
            }

            this.dataGrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //go to home page
            WpfApp2.GUI.Menu gameMainWindow = new WpfApp2.GUI.Menu(userId);
            gameMainWindow.Show();
            this.Close();
        }
    }
}
