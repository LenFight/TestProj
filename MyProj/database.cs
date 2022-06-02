using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace MyProj
{
    internal class database
    {

        private database()
        {
        }
        private string Server = "127.0.0.1";
        private string DatabaseName = "administration";
        private string UserName = "root";
        private string Password = "";

        public MySqlConnection Connection { get; set; }

        private static database _instance = null;
        public static database Instance()
        {
            if (_instance == null)
                _instance = new database();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                try
                {

                    string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", Server, DatabaseName, UserName, Password);
                    Connection = new MySqlConnection(connstring);
                    Connection.Open();
                }
                catch (Exception e) 
                {
                    return false;
                }
            }
            if (Connection.State == System.Data.ConnectionState.Closed) 
            {
                Connection.Open();
            }
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }



        public void Close()
        {
            Connection.Close();
        }
        
    }
}
