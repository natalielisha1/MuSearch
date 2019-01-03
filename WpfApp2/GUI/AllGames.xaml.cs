﻿using System;
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

        public AllGames(int userId)
        {
            InitializeComponent();
            this._users = new Users();
            this.userId = userId;
            this.ShowTopAllGames();
        }

        public void ShowTopAllGames()
        {
            try
            {
                List<Game> games = this._users.getTopAllGames();
                var rows = games.Count;
                DataTable dt = new DataTable();

                DataColumn columnUsername = new DataColumn();
                columnUsername.Caption = "Username";
                columnUsername.ColumnName = "Username";
                columnUsername.DataType = System.Type.GetType("System.String");
                dt.Columns.Add(columnUsername);

                DataColumn columnScore = new DataColumn();
                columnScore.Caption = "Score";
                columnScore.ColumnName = "Score";
                columnUsername.DataType = System.Type.GetType("System.Int32");
                dt.Columns.Add(columnScore);

                DataColumn columnDate = new DataColumn();
                columnDate.Caption = "Date";
                columnDate.ColumnName = "Date";
                columnUsername.DataType = System.Type.GetType("System.String");
                dt.Columns.Add(columnDate);

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
            catch(Exception e)
            {
                MessageBox.Show("System Error. \r\nTry again later.");
                this.Close();
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //go to home page
            Menu gameMainWindow = new Menu(this.userId);
            gameMainWindow.Show();
            this.Close();
        }
    }
}
