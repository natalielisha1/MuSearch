using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace MuSearch.DB
{
    using WpfApp2.General;

    class songs
    {
        public static List<string> GetWords(List<Category> categories)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "musearch";
            List<string> songs = new List<string>();
            if (dbCon.IsConnect())
            {
                string query = CreateQuery(categories);
                /*var cmd = new MySqlCommand("musearch.getSongsShort", dbCon.Connection)
                              {
                                  CommandType = CommandType.StoredProcedure
                              };
                cmd.Parameters.Add(new MySqlParameter("artistName", artistName));*/


                var cmd = new MySqlCommand(query, dbCon.Connection);

                cmd.Connection.Open();
                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        songs.Add(reader["songName"].ToString());
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

        public static string CreateQuery(List<Category> categories)
        {
            string query;
            if (categories[0].Categories.Equals("artist"))
            {
                query = "SELECT songs.songName FROM musearch.songs where songs.artistId LIKE " + '"'
                               + categories[0].CategoryName + '"';
            }
            else if (categories[0].Categories.Equals("album"))
            {
                query = "SELECT songs.songName FROM musearch.songs where songs.albumId LIKE " + '"'
                               + categories[0].CategoryName + '"';
            }
            else if (categories[0].Categories.Equals("decade"))
            {
                query = "SELECT songs.songName,songs.year FROM musearch.songs where(songs.year -" + categories[0].CategoryName +
                               ") < 10 AND(songs.year - " + categories[0].CategoryName + ") > 0";
            }
            else
            {
                query = "ifat";
            }
            for (int i = 1; i < categories.Count; i++)
            {
                if (categories[i].Categories.Equals("artist"))
                {
                    query = query+ " UNION SELECT songs.songName FROM musearch.songs where songs.artistId LIKE " + '"'
                            + categories[i].CategoryName + '"';
                }
                else if (categories[i].Categories.Equals("album"))
                {
                    query = query + " UNION SELECT songs.songName FROM musearch.songs where songs.albumId LIKE " + '"'
                            + categories[i].CategoryName + '"';
                }
                else if (categories[i].Categories.Equals("decade"))
                {
                    query = query + " UNION SELECT songs.songName,songs.year FROM musearch.songs where(songs.year -" + categories[i].CategoryName +
                            ") < 10 AND(songs.year - " + categories[i].CategoryName + ") > 0";
                }
                else
                {
                    query = "ifat";
                }
            }
            query = query + " LIMIT 10";
            return query;
        }
    }
}
