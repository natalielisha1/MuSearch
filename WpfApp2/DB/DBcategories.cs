namespace MuSearch.DB
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.CompilerServices;

    using MySql.Data.MySqlClient;

    public class DBcategories
    {
        public string checkCategories(string input)
        {
            var dbCon = DBConnection.Instance();

            dbCon.DatabaseName = "musearch";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearch.categoryGenerator", dbCon.Connection);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("input", input));
                try
                {
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        dbCon.Close();
                        return result.ToString();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                dbCon.Close();
            }
            return null;
        }
    }
}