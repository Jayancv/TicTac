
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using MySql.Data.MySqlClient;


namespace Tic_Tac_Toe
{
    class DB_Connector
    {     
         public MySqlConnection conn = null;
        
            #region Constructors
        public DB_Connector(string hostname, string database, string username, string password)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database + ";username=" + username + ";password=" + password + ";");
        }

        public  DB_Connector(string hostname, string database, string username, string password, int portNumber)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database + ";username=" + username + ";password=" + password + ";port=" + portNumber.ToString() + ";");
           // MySQLClient sqlClient = new MySQLClient(conn);
        }

        public DB_Connector(string hostname, string database, string username, string password, int portNumber, int connectionTimeout)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database + ";username=" + username + ";password=" + password + ";port=" + portNumber.ToString() + ";Connection Timeout=" + connectionTimeout.ToString() + ";");
        }
        #endregion

        #region Open/Close Connection
        public bool Open()
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

        public bool Close()
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
    }
}
