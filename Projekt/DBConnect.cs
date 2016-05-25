using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class DbConnect
    {
        private SQLiteConnection _sqlite;

        public DbConnect()
        {
            _sqlite = new SQLiteConnection("Data Source=WPFDB.db;New=False;Compress=True;");

        }

        public DataTable SelectQuery(string query)
        {
            var dt = new DataTable();
            _sqlite.Open(); //Initiate connection to the db
            var cmd = _sqlite.CreateCommand();
            cmd.CommandText = query; //set the passed query
            var ad = new SQLiteDataAdapter(cmd);
            ad.Fill(dt); //fill the datasource
            _sqlite.Close();
            return dt;
        }
    }
}

