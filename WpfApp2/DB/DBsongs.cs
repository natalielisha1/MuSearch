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
            string query = string.Empty;

            for (int i = 0; i < categories.Count; i++)
            {

                query = query + "UNION ";
                if (i == 0)
                {
                    query = string.Empty;
                }
                if (categories[i].Categories.Equals("artist"))
                {
                    query = "SELECT songs.songName FROM musearch.songs JOIN musearch.albums ON songs.AlbumId = albums.albumId "
                            + "JOIN musearch.artists ON albums.artistId = artists.id WHERE artists.artistName LIKE " + '"'
                            + categories[i].CategoryName + '"';
                }
                else if (categories[i].Categories.Equals("album"))
                {
                    query = "SELECT songs.songName FROM musearch.songs JOIN musearch.albums ON songs.AlbumId = albums.albumId "
                            + "WHERE albums.albumName LIKE " + '"' + categories[i].CategoryName + '"';
                }
                else if (categories[i].Categories.Equals("decade"))
                {
                    query = "SELECT songs.songName, songs.yearReleased FROM musearch.songs where(songs.yearReleased -" + 
                        categories[i].CategoryName + ") < 10 AND(songs.yearReleased - " + categories[i].CategoryName + ") > 0";
                }
                else
                {
                    continue;
                }
            }
            query = query + " LIMIT 10";
            return query;
        }
    }
}
