using MySql.Data.MySqlClient;
//using MySQLClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Tic_Tac_Toe
{

    class MySQLClient
    {
  
       
        public void Insert( string column, string value)
        {
            //Insert values into the database.
            DB_Connector db = new DB_Connector("localhost", "tic", "root", "root", 3306);

            string query = "INSERT INTO score (" + column + ") VALUES ('" + value + "')";

            try
            {
                if (db.Open())
                {
                    //Opens a connection, if succefull; run the query and then close the connection.
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(query, db.conn);
                        cmd.ExecuteNonQuery();

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception eef)
                    {

                    }
                   db.Close();
                    return;

                }
            }
            catch (Exception e) { }
            return;
        }

        public void Update( string SET, int value, string name)
        {
            DB_Connector db = new DB_Connector("localhost", "tic", "root", "root", 3306);
            //Update existing values in the database.

            string query = "UPDATE score SET " + SET + " " + value + " WHERE name= '" + name + "'";

            if (db.Open())
            {
                try
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, db.conn);
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
                catch { db.Close(); }
            }
            return;
        }

        public void Delete( string WHERE)
        {
            DB_Connector db = new DB_Connector("localhost", "tic", "root", "root", 3306);
            //Removes an entry from the database.

            //Example: DELETE FROM names WHERE name='John Smith'
            //Code: MySQLClient.Delete("names", "name='John Smith'");
            string query = "DELETE FROM score WHERE " + WHERE + "";

            if (db.Open())
            {
                try
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, db.conn);
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
                catch {db.Close(); }
            }
            return;
        }


        public int getScour( string name, string col)
        {
            DB_Connector db = new DB_Connector("localhost", "tic", "root", "root", 3306);
            int score = 0;
            string query = "SELECT * FROM score WHERE name='" + name + "'";
            if (db.Open())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, db.conn);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        score = int.Parse(dataReader[col].ToString());
                        db.Close();
                        return score;
                    }
                    dataReader.Close();
                }
                catch (Exception ee)
                { }
                db.Close();

                return score;
            }
            else
            {
                return score;
            }
        }


        //check a name exist in the database
        public Boolean Exist( string name)
        {
            DB_Connector db = new DB_Connector("localhost", "tic", "root", "root", 3306);
            string query = " SELECT name FROM score WHERE name='" + name + "'";
            bool ext = false;

            if (db.Open())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, db.conn);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        string sc = dataReader["name"].ToString();
                        db.Close();
                        if ((sc == name) || (sc.ToLower() == name.ToLower()))
                        {
                            ext = true;
                        } else {
                        }
                        dataReader.Close();
                        db.Close();
                        return ext;
                    }
                    dataReader.Close();

                }
                catch (Exception e) { }
                db.Close();
                return false;
            }
            else
            {
                return false;
            }
        }


        // For get HighScore
        public string[] Max( string col)
        {
            DB_Connector db = new DB_Connector("localhost", "tic", "root", "root", 3306);
            string[] arry = new string[2];
            string query = "SELECT * FROM score WHERE " + col + " = ( SELECT MAX(" + col + ") FROM score )";

            if (db.Open())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, db.conn);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        arry[0] = dataReader["name"].ToString();
                        arry[1] = dataReader[col].ToString();
                        db.Close();
                        return arry;
                    }
                    dataReader.Close();
                }
                catch (Exception ee)
                {                }
                db.Close();
                return arry;
            }
            else
            {
                return arry;
            }
        }






        //get player scores to an array
        public int[] Get( string name)
        {
            DB_Connector db = new DB_Connector("localhost", "tic", "root", "root", 3306);
            int[] score = new int[4];
            string query = " SELECT * FROM score WHERE name='" + name + "'";
            if (db.Open())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, db.conn);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        score[0] = int.Parse(dataReader["won1"].ToString());
                        score[1] = int.Parse(dataReader["won2"].ToString());
                        score[2] = int.Parse(dataReader["defeat1"].ToString());
                        score[3] = int.Parse(dataReader["defeat2"].ToString());

                        dataReader.Close();
                        db.Close();
                        return score;
                    }
                    dataReader.Close();

                }
                catch (Exception e) { }
                db.Close();
                return score;
            }
            else
            {
                return score;
            }
        }


    }
}
