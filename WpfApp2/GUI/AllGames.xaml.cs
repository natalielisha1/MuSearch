using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Data;
using MuSearch.BusinessLayer;
using WpfApp2.General;

namespace WpfApp2.GUI
{
    /// <summary>
    /// Interaction logic for AllGames.xaml
    /// </summary>
    public partial class AllGames : Window
    {
        #region Properties
        private Users _users;
        private int userId;
        #endregion

        /// <summary>
        /// Constructor for the AllGames object
        /// </summary>
        /// <param name="userId">not used here</param>
        public AllGames(int userId)
        {
            InitializeComponent();
            this._users = new Users();
            this.userId = userId;
            this.ShowTopAllGames();
        }

        /// <summary>
        /// The function show's all top games of all users in the view
        /// </summary>
        public void ShowTopAllGames()
        {
            try
            {
                List<Game> games = this._users.getTopAllGames();
                var rows = games.Count;
                DataTable dt = new DataTable();

                // creating Data Column for username
                DataColumn columnUsername = new DataColumn();
                columnUsername.Caption = "Username";
                columnUsername.ColumnName = "Username";
                columnUsername.DataType = System.Type.GetType("System.String");
                dt.Columns.Add(columnUsername);

                // creating Data Column for score
                DataColumn columnScore = new DataColumn();
                columnScore.Caption = "Score";
                columnScore.ColumnName = "Score";
                columnUsername.DataType = System.Type.GetType("System.Int32");
                dt.Columns.Add(columnScore);

                // creating Data Column for date
                DataColumn columnDate = new DataColumn();
                columnDate.Caption = "Date";
                columnDate.ColumnName = "Date";
                columnUsername.DataType = System.Type.GetType("System.String");
                dt.Columns.Add(columnDate);

                // for every game, fill it's row
                for (int i = 0; i < rows; i++)
                {
                    DataRow row = dt.NewRow();
                    row["Username"] = games[i].Username;
                    row["Score"] = games[i].Score;
                    games[i].Date = games[i].Date.Replace("00:00:00", "");
                    row["Date"] = games[i].Date;
                    dt.Rows.Add(row);
                }

                this.dataGrid.ItemsSource = dt.DefaultView;
            }
            // in case on an exception
            catch(Exception e)
            {
                MessageBox.Show("System Error. \r\nTry again later.");
                this.Close();
            }
        }

        /// <summary>
        /// The function shows the client the menu window
        /// and closes the current window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //go to home page
            Menu menuWindow = new Menu(this.userId);
            menuWindow.Show();
            this.Close();
        }
    }
}
