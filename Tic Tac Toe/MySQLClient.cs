using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySQLClass
{

    class MySQLClient
    {
        MySqlConnection conn = null;


        #region Constructors
        public MySQLClient(string hostname, string database, string username, string password)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database + ";username=" + username + ";password=" + password + ";");
        }

        public MySQLClient(string hostname, string database, string username, string password, int portNumber)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database + ";username=" + username + ";password=" + password + ";port=" + portNumber.ToString() + ";");
        }

        public MySQLClient(string hostname, string database, string username, string password, int portNumber, int connectionTimeout)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database + ";username=" + username + ";password=" + password + ";port=" + portNumber.ToString() + ";Connection Timeout=" + connectionTimeout.ToString() + ";");
        }
        #endregion

        #region Open/Close Connection
        private bool Open()
        {
            //This opens temporary connection
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                //Here you could add a message box or something like that so you know if there were an error.
                return false;
            }
        }

        private bool Close()
        {
            //This method closes the open connection
            try
            {
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public void Insert(string table, string column, string value)
        {
            //Insert values into the database.


            string query = "INSERT INTO " + table + " (" + column + ") VALUES ('" + value + "')";

            try
            {
                if (this.Open())
                {
                    //Opens a connection, if succefull; run the query and then close the connection.
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.ExecuteNonQuery();

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception eef)
                    {

                    }
                    this.Close();
                    return;

                }
            }
            catch (Exception e) { }
            return;
        }

        public void Update(string table, string SET, int value, string name)
        {
            //Update existing values in the database.

            string query = "UPDATE " + table + " SET " + SET + " " + value + " WHERE name= '" + name + "'";

            if (this.Open())
            {
                try
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                catch { this.Close(); }
            }
            return;
        }

        public void Delete(string table, string WHERE)
        {
            //Removes an entry from the database.

            //Example: DELETE FROM names WHERE name='John Smith'
            //Code: MySQLClient.Delete("names", "name='John Smith'");
            string query = "DELETE FROM " + table + " WHERE " + WHERE + "";

            if (this.Open())
            {
                try
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                catch { this.Close(); }
            }
            return;
        }


        public int getScour(string table, string name, string col)
        {

            int score = 0;
            string query = "SELECT * FROM " + table + " WHERE name='" + name + "'";
            if (this.Open())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        score = int.Parse(dataReader[col].ToString());
                        this.Close();
                        return score;
                    }
                    dataReader.Close();
                }
                catch (Exception ee)
                { }
                this.Close();

                return score;
            }
            else
            {
                return score;
            }
        }


        //check a name exist in the database
        public Boolean Exist(string table, string name)
        {
            string query = " SELECT name FROM " + table + " WHERE name='" + name + "'";
            bool ext = false;

            if (this.Open())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        string sc = dataReader["name"].ToString();
                        this.Close();
                        if ((sc == name) || (sc.ToLower() == name.ToLower()))
                        {
                            ext = true;
                        } else {
                        }
                        dataReader.Close();
                        this.Close();
                        return ext;
                    }
                    dataReader.Close();

                }
                catch (Exception e) { }
                this.Close();
                return false;
            }
            else
            {
                return false;
            }
        }


        // For get HighScore
        public string[] Max(string table, string col)
        {
            string[] arry = new string[2];
            string query = "SELECT * FROM " + table + " WHERE " + col + " = ( SELECT MAX(" + col + ") FROM " + table + ")";

            if (this.Open())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        arry[0] = dataReader["name"].ToString();
                        arry[1] = dataReader[col].ToString();
                        this.Close();
                        return arry;
                    }
                    dataReader.Close();
                }
                catch (Exception ee)
                {                }
                this.Close();
                return arry;
            }
            else
            {
                return arry;
            }
        }






        //get player scores to an array
        public int[] Get(string table, string name)
        {
            int[] score = new int[4];
            string query = " SELECT * FROM " + table + " WHERE name='" + name + "'";
            if (this.Open())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        score[0] = int.Parse(dataReader["won1"].ToString());
                        score[1] = int.Parse(dataReader["won2"].ToString());
                        score[2] = int.Parse(dataReader["defeat1"].ToString());
                        score[3] = int.Parse(dataReader["defeat2"].ToString());

                        dataReader.Close();
                        this.Close();
                        return score;
                    }
                    dataReader.Close();

                }
                catch (Exception e) { }
                this.Close();
                return score;
            }
            else
            {
                return score;
            }
        }


    }
}
