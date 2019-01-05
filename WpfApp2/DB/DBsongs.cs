using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace MuSearch.DB
{
    using MuSearch.DB.Interfaces;

    using WpfApp2.BusinessLayer;

    class DBsongs : IDBsongs
    {
        /// <summary>
        /// getting the words to the word search
        /// </summary>
        /// <param name="categories">the categories we want to build the game according it</param>
        /// <returns>a list of the relevant words</returns>
        public List<string> GetWords(List<Category> categories)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "musearchdb";
            List<string> songs = new List<string>();
            if (dbCon.IsConnect())
            {
                string query = CreateQuery(categories);
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

        /// <summary>
        /// creating the appropriate query
        /// </summary>
        /// <param name="categories">the categories for the query</param>
        /// <returns>the appropriate query</returns>
        public string CreateQuery(List<Category> categories)
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
                    query += "SELECT songs.songName FROM musearchdb.songs JOIN musearchdb.albums ON songs.AlbumId = albums.albumId "
                            + "JOIN musearchdb.artists ON albums.artistId = artists.id WHERE artists.artistName LIKE " + '"'
                            + categories[i].CategoryName + '"' + " AND length(replace(songs.songName,' ',''))<21 ";
                }
                else if (categories[i].Categories.Equals("album"))
                {
                    query += "SELECT songs.songName FROM musearchdb.songs JOIN musearchdb.albums ON songs.AlbumId = albums.albumId "
                            + "WHERE albums.albumName LIKE " + '"' + categories[i].CategoryName + '"' + " AND length(replace(songs.songName,' ',''))<21 ";
                }
                else if (categories[i].Categories.Equals("decade"))
                {
                    query += "SELECT songs.songName, songs.yearReleased FROM musearchdb.songs where(songs.yearReleased -" + 
                        categories[i].CategoryName + ") < 10 AND (songs.yearReleased - " + categories[i].CategoryName + ") > 0" + " AND length(replace(songs.songName,' ',''))<21 ";
                }
                else
                {
                    continue;
                }
            }
            query = query + " ORDER BY RAND() LIMIT 10";
            return query;
        }
    }
}
