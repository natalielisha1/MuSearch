﻿namespace MuSearch.DB
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.CompilerServices;

    using MySql.Data.MySqlClient;

    using WpfApp2.General;

    public class DBcategories
    {
        public List<Category> checkCategories(string input)
        {
            var dbCon = DBConnection.Instance();
            List<Category> categories = new List<Category>();
            dbCon.DatabaseName = "musearch";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearch.categoryGenerator", dbCon.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("input", input));
                cmd.Connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category(reader["CategoryName"].ToString(), reader["Input"].ToString(), reader["Categories"].ToString()));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                dbCon.Close();
            }
            return categories;
        }

        //decate, album, artist
        public Category randomeCategory(string tableName)
        {
            Category category = null;
            var dbCon = DBConnection.Instance();
            List<Category> categories = new List<Category>();
            dbCon.DatabaseName = "musearch";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearch.getRandom_" + tableName, dbCon.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("table_name1", tableName));
                cmd.Connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (tableName == "artists")
                    {
                        while (reader.Read())
                        {
                            category = new Category(reader["artistName"].ToString(), "suprise               Category", "artists");
                        }
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            category = new Category(reader["albumName"].ToString(), "suprise               Category", "albums");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                dbCon.Close();
            }
            return category;
        }
    }
}