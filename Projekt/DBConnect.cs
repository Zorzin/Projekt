using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Projekt
{
    internal class DbConnect
    {
        private readonly MySqlConnection _mySqlConnection;

        public DbConnect()
        {
            var connectionString = new MySqlConnectionStringBuilder();
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
            cmd.CommandText = "delete from projekt." + table + " where id" + table + "=" + id + ";";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            _mySqlConnection.Close();
        }

        public void UpdateFromString(string command)
        {
            _mySqlConnection.Open();
            var cmd = _mySqlConnection.CreateCommand();
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            _mySqlConnection.Close();
        }

        public void UpdateBusStop(string id, string name)
        {
            _mySqlConnection.Open();
            var cmd = _mySqlConnection.CreateCommand();
            cmd.CommandText = "update projekt.busstop set BusStopName='" + name + "' where idBusStop='" + id + "';";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            _mySqlConnection.Close();
        }

        public void UpdateBus(string id, string type, string mileage, string busbrand, string techcondition)
        {
            _mySqlConnection.Open();
            var cmd = _mySqlConnection.CreateCommand();
            cmd.CommandText = "update projekt.bus set type='" + type + "', mileage='" + mileage + "', busbrand='" +
                              busbrand + "', techcondition='" + techcondition + "' where idbus='" + id + "';";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            _mySqlConnection.Close();
        }

        public void UpdateDriver(string id, string name, string secondname, string status, string driverlicenseid,
            string city, string zipcode, string address, string salary, string hoursworked, string photopath)
        {
            _mySqlConnection.Open();
            var cmd = _mySqlConnection.CreateCommand();
            cmd.CommandText = "update projekt.driver set name='" + name + "', secondname='" + secondname + "', status='" +
                              status + "', driverlicenceid='" + driverlicenseid + "', city='" + city + "', zipcode='" +
                              zipcode + "', address ='" + address + "', salary='" + salary + "', hoursworked='" +
                              hoursworked + "', photopath='" + photopath + "' where iddriver='" + id + "';";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            _mySqlConnection.Close();
        }

        public void UpdateLine(string id, string lenght, string firststop, string laststop)
        {
            _mySqlConnection.Open();
            var cmd = _mySqlConnection.CreateCommand();
            cmd.CommandText = "update projekt.line set lenght='" + lenght + "', firststop='" + firststop + "', laststop='" +
                              laststop + "' where idline='" + id + "';";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            _mySqlConnection.Close();
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
                busstop.Id = int.Parse(cmd.LastInsertedId.ToString());
                _mySqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    var mbb = MessageBoxButton.OK;
                    var dr = MessageBox.Show("Przystanek o podanym numerze już istnieje", "Błąd", mbb);
                }
                else
                {
                    var mbb = MessageBoxButton.OK;
                    var dr = MessageBox.Show("Błąd podczas dodawania rekordu", "Błąd", mbb);
                }
                _mySqlConnection.Close();
                return false;
            }
        }

        public bool AddBus(string id, string type, string busbrand, string techcondition, Bus bus)
        {
            try
            {
                _mySqlConnection.Open();
                var cmd = _mySqlConnection.CreateCommand();
                cmd.CommandText = "insert into projekt.bus values(" + id + ",'" + type + "','"+
                                  busbrand + "','" + techcondition + "');";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                bus.Busid = int.Parse(cmd.LastInsertedId.ToString());
                _mySqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    var mbb = MessageBoxButton.OK;
                    var dr = MessageBox.Show("Autobus o podanym numerze już istnieje", "Błąd", mbb);
                }
                else
                {
                    var mbb = MessageBoxButton.OK;
                    var dr = MessageBox.Show("Błąd podczas dodawania rekordu", "Błąd", mbb);
                }
                _mySqlConnection.Close();
                return false;
            }
        }

        public bool AddLine(string id, string lenght, string firststop, string laststop, Line line)
        {
            try
            {
                _mySqlConnection.Open();
                var cmd = _mySqlConnection.CreateCommand();
                cmd.CommandText = "insert into projekt.line values(" + id + ",'" + lenght + "','" + firststop + "','" +
                                  laststop + "');";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                line.Number = int.Parse(cmd.LastInsertedId.ToString());
                _mySqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    var mbb = MessageBoxButton.OK;
                    var dr = MessageBox.Show("Linia o podanym numerze już istnieje", "Błąd", mbb);
                }
                else
                {
                    var mbb = MessageBoxButton.OK;
                    var dr = MessageBox.Show("Błąd podczas dodawania rekordu", "Błąd", mbb);
                }
                _mySqlConnection.Close();
                return false;
            }
        }

        public bool AddDriver(string id, string name, string secondname, string status, string driverlicenceid,
            string city, string zipcode, string address, string salary, string hoursworked, string photopath,
            Driver driver)
        {
            try
            {
                _mySqlConnection.Open();
                var cmd = _mySqlConnection.CreateCommand();
                cmd.CommandText = "insert into projekt.driver values(" + id + ",'" + name + "','" + secondname + "','" +
                                  status + "','" + driverlicenceid + "','" + city + "','" + zipcode + "','" + address +
                                  "','" + salary + "','" + hoursworked + "','" + photopath + "');";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                driver.Id = int.Parse(cmd.LastInsertedId.ToString());
                _mySqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    var mbb = MessageBoxButton.OK;
                    var dr = MessageBox.Show("Kierowca o podanym numerze już istnieje", "Błąd", mbb);
                }
                else
                {
                    var mbb = MessageBoxButton.OK;
                    var dr = MessageBox.Show("Błąd podczas dodawania rekordu", "Błąd", mbb);
                }
                _mySqlConnection.Close();
                return false;
            }
        }
    }
}