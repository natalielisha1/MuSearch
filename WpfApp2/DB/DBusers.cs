﻿namespace MuSearch.DB
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    using MySql.Data.MySqlClient;

    public class DBusers
    {
        public bool checkUser(string username, string password)
        {
            var dbCon = DBConnection.Instance();
            bool userExist = false;
            int count;
            dbCon.DatabaseName = "musearch";
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand("musearch.checkUser", dbCon.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@username", SqlDbType.Text);
                //cmd.Parameters["@username"].Value = username;
                //cmd.Parameters.Add("@password", SqlDbType.Text);
                //cmd.Parameters["@password"].Value = password;
                cmd.Parameters.Add(new MySqlParameter("username", username));

                cmd.Parameters.Add(new MySqlParameter("password", password));
                var result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    userExist = true;
                }
                dbCon.Close();
            }
            return userExist;
        }
    }
}