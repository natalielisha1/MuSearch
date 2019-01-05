namespace MuSearch.DB
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using MuSearch.DB.Interfaces;

    using MySql.Data.MySqlClient;

    using WpfApp2.BusinessLayer;

    /// <summary>
    /// DBcategories
    /// connection to the database for category information
    /// </summary>
    public class DBcategories : IDBcategories
    {
        /// <summary>
        /// checkCategories
        /// </summary>
        /// <param name="input">the searching word of the user</param>
        /// <returns> a list of categories that are relevant to the input </returns>
        public List<Category> checkCategories(string input)
        {
            var dbCon = DBConnection.Instance();
            List<Category> categories = new List<Category>();
            dbCon.DatabaseName = "musearchdb";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearchdb.categoryGenerator", dbCon.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("input", input));
                cmd.Connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category(reader["CategoryName"].ToString(), reader["Input"].ToString(), 
                                    reader["Categories"].ToString(), Convert.ToInt32(reader["NumberOfSongs"].ToString())));
                    }
                    List<int> bad_indexes = new List<int>();
                    for (int i = 0; i < categories.Count; i++)
                    {
                        if (categories[i].Count == 0)
                        {
                            bad_indexes.Add(i);
                        }
                    }
                    for (int i = bad_indexes.Count - 1; i >= 0 ; i--)
                    {
                        categories.RemoveAt(bad_indexes[i]);
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

        /// <summary>
        /// gets a random category for the surprise word search
        /// </summary>
        /// <param name="tableName">that the category is coming from</param>
        /// <returns>the category that we got</returns>
        public Category randomCategory(string tableName)
        {
            Category category = null;
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "musearchdb";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearchdb.getRandom_" + tableName, dbCon.Connection);
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
                            category = new Category(reader["artistName"].ToString(), "surprise Category", "artist", 0);
                        }
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            category = new Category(reader["albumName"].ToString(), "surprise Category", "album", 0);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                dbCon.Close();
            }
            else
                throw new Exception();
            return category;
        }
    }
}