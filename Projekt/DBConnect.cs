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

        public void Update()
        {
            
        }

        public bool AddBusStop(string number, string name, BusStop busstop)
        {
            try
            {
                _mySqlConnection.Open();
                var cmd = _mySqlConnection.CreateCommand();
                cmd.CommandText = "insert into projekt.busstop values (" + number + ",'" + name + "')";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                busstop.Id = Int32.Parse(cmd.LastInsertedId.ToString());
                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException !=null)
                {
                    MessageBoxButton mbb = MessageBoxButton.OK;
                    MessageBoxResult dr = MessageBox.Show("Przystanek o podanym numerze już istnieje", "Błąd", mbb);
                }
                else
                {
                    MessageBoxButton mbb = MessageBoxButton.OK;
                    MessageBoxResult dr = MessageBox.Show("Błąd podczas dodawania rekordu", "Błąd", mbb);
                }
                return false;
            }
            
        }

        public bool AddBus(string id, string type, string mileage, string busbrand, string techcondition, Bus bus)
        {
            try
            {
                _mySqlConnection.Open();
                var cmd = _mySqlConnection.CreateCommand();
                cmd.CommandText = "insert into projekt.bus values(" + id + ",'" + type + "'," + mileage + ",'" + busbrand + "','" + techcondition + "');";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                bus.Busid = Int32.Parse(cmd.LastInsertedId.ToString());
                return true;
            }
            catch (Exception ex)
            {

                if (ex.InnerException != null)
                {
                    MessageBoxButton mbb = MessageBoxButton.OK;
                    MessageBoxResult dr = MessageBox.Show("Autobus o podanym numerze już istnieje", "Błąd", mbb);
                }
                else
                {
                    MessageBoxButton mbb = MessageBoxButton.OK;
                    MessageBoxResult dr = MessageBox.Show("Błąd podczas dodawania rekordu", "Błąd", mbb);
                }
                return false;
            }
            
        }

        public bool AddLine(string id, string lenght, string firststop, string laststop, Line line)
        {
            try
            {
                _mySqlConnection.Open();
                var cmd = _mySqlConnection.CreateCommand();
                cmd.CommandText = "insert into projekt.line values(" + id + ",'" + lenght + "','" + firststop + "','" + laststop + "');";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                line.Number = Int32.Parse(cmd.LastInsertedId.ToString());
                return true;
            }
            catch (Exception ex)
            {

                if (ex.InnerException != null)
                {
                    MessageBoxButton mbb = MessageBoxButton.OK;
                    MessageBoxResult dr = MessageBox.Show("Linia o podanym numerze już istnieje", "Błąd", mbb);
                }
                else
                {
                    MessageBoxButton mbb = MessageBoxButton.OK;
                    MessageBoxResult dr = MessageBox.Show("Błąd podczas dodawania rekordu", "Błąd", mbb);
                }
                return false;
            }
            
        }

        public bool AddDriver(string id, string name, string secondname, string status, string driverlicenceid, string city, string zipcode, string address, string salary, string hoursworked, string photopath, Driver driver)
        {
            try
            {
                _mySqlConnection.Open();
                var cmd = _mySqlConnection.CreateCommand();
                cmd.CommandText = "insert into projekt.driver values(" + id + ",'" + name + "','" + secondname + "','" + status + "','" + driverlicenceid + "','" + city + "','" + zipcode + "','" + address + "','" + salary + "','" + hoursworked + "','" + photopath + "');";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                driver.Id = Int32.Parse(cmd.LastInsertedId.ToString());
                return true;
            }
            catch (Exception ex)
            {

                if (ex.InnerException != null)
                {
                    MessageBoxButton mbb = MessageBoxButton.OK;
                    MessageBoxResult dr = MessageBox.Show("Kierowca o podanym numerze już istnieje", "Błąd", mbb);
                }
                else
                {
                    MessageBoxButton mbb = MessageBoxButton.OK;
                    MessageBoxResult dr = MessageBox.Show("Błąd podczas dodawania rekordu", "Błąd", mbb);
                }
                return false;
            }
            
        }
    }
}

