using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace SettingUp_Database_Splash_Screen
{
    class ClassConnection
    {
        public static MySqlConnection connect()
        {

            MySqlConnection conn = new MySqlConnection();

            String strConn = "server = localhost;";
            strConn += "user= root;";
            strConn += "sslmode=none";

            conn.ConnectionString = strConn;

            String sql = "CREATE DATABASE IF NOT EXISTS mydatabases";

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception er)
            {
                MessageBox.Show("" + er);
            }


            return conn;
        }
        public void OpenDatabase()
        {
            MySqlConnection conn = ClassConnection.connect();
            if (conn.State == System.Data.ConnectionState.Closed) return;
            conn.Close();
        }
        public void table()
        {

            MySqlConnection conn = ClassConnection.connect();
            if (conn.State == System.Data.ConnectionState.Closed) return;
            String sql = "CREATE TABLE IF NOT EXISTS mydatabases.mytbl (id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, firstname VARCHAR(30) NOT NULL ,lastname VARCHAR(50) NOT NULL, username VARCHAR(100) NOT NULL, password VARCHAR(100) NOT NULL)";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();





        }

    }
}
