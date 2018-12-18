using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace MuSearch.DB
{

    class songs
    {
        public static List<string> GetWords()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "musearch";
            List<string> songs = new List<string>();
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearch.getSongs", dbCon.Connection)
                              {
                                  CommandType = CommandType.StoredProcedure
                              };

                cmd.Connection.Open();
                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        songs.Add(reader["AlbumName"].ToString());
                    }
                } catch(Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                dbCon.Close();
            }
            return songs;
        }
    }
}
