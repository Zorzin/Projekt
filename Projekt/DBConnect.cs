using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace Projekt
{
    class DbConnect
    {
        private MySqlConnection _mySqlConnection;

        public DbConnect()
        {
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = "127.0.0.1";
            connectionString.UserID = "root";
            connectionString.Password = "admin";
            connectionString.Database = "Projekt";
            _mySqlConnection = new MySqlConnection(connectionString.ToString());

        }

        public DataTable SelectQuery(string query)
        {
            var dt = new DataTable();
            _mySqlConnection.Open(); //Initiate connection to the db
            var cmd = _mySqlConnection.CreateCommand();
            cmd.CommandText = query; //set the passed query
            var ad = new MySqlDataAdapter(cmd);
            ad.Fill(dt); //fill the datasource
            _mySqlConnection.Close();
            return dt;
        }

        public void Delete(string table, string id)
        {
            _mySqlConnection.Open();
            var cmd = _mySqlConnection.CreateCommand();
            cmd.CommandText = "delete from projekt."+table+" where id"+table+"=" + id + ";";
            cmd.CommandType= CommandType.Text;
            cmd.ExecuteNonQuery();
        }
    }
}

