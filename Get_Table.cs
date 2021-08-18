using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace sql_db
{
    class Get_Table
    {
        public DataTable InitTable(string tableName)
        {
            string dbconnect = "Database=damir;Data Source=localhost;User Id=root;Password=wsk2020;";
            MySqlConnection connect = new MySqlConnection(dbconnect);

            string query = "SELECT * FROM damir." + tableName + ";";
            MySqlCommand command = new MySqlCommand(query, connect);
            DataTable data = new DataTable();
            
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                data.Load(reader);
                reader.Close();
            }
            catch (MySqlException ex)
            {
              MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
            return data;
        }


         public DataTable InitTable(string query, bool status)
        {
            string dbconnect = "Database=damir;Data Source=localhost;User Id=root;Password=wsk2020;";
            MySqlConnection connect = new MySqlConnection(dbconnect);

            //string query = "SELECT * FROM damir." + tableName + ";";
            MySqlCommand command = new MySqlCommand(query, connect);
            DataTable data = new DataTable();
            
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                data.Load(reader);
                reader.Close();
            }
            catch (MySqlException ex)
            {
              MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
            return data;
        }
    }
}
