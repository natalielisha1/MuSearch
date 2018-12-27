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
        public static List<string> GetWords(string artistName)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "musearch";
            List<string> songs = new List<string>();
            if (dbCon.IsConnect())
            {

                var cmd = new MySqlCommand("musearch.getSongsShort", dbCon.Connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //cmd.Parameters.Add(new MySqlParameter("artistName", artistName));

                //string queryString = "SELECT songName FROM musearch.songs where songs.artistId = " +  '"' + artistName + '"';
                //var cmd = new MySqlCommand(queryString, dbCon.Connection);
                cmd.Connection.Open();
                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        songs.Add(reader["AlbumName"].ToString());
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
            return songs;
        }
    }
}
