using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sql_db
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        

        void table_get()
        {
            string dbconnect = "Database=damir;Data Source=localhost;User Id=root;Password=wsk2020;";
            MySqlConnection connect = new MySqlConnection(dbconnect);

            MySqlCommand command = new MySqlCommand();
            string query = "SELECT * FROM damir.students;";
            command.CommandText = query;
            command.Connection = connect;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                dataGridView1.Columns.Add("idField", "ID");
                dataGridView1.Columns["idField"].Width = 100;
                dataGridView1.Columns["idField"].Visible = false;
                dataGridView1.Columns.Add("nameField", "Name");
                dataGridView1.Columns["nameField"].Width = 200;
                dataGridView1.Columns.Add("ageField", "Age");
                dataGridView1.Columns["ageField"].Width = 200;

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Age"].ToString());
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table_get();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            string dbconnect = "server=localhost;user=root;database=damir;Password=wsk2020;";
            MySqlConnection connect = new MySqlConnection(dbconnect);

            try
            {
                string query = "INSERT INTO students (Name, Age) VALUES ('" + textBox2.Text + "', '" + textBox1.Text + "')";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                connect.Open();
                cmd.ExecuteNonQuery();
                
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                connect.Close();
                textBox2.Clear();
                textBox1.Clear();
                dataGridView1.Rows.Clear();
                table_get();
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            string idField = dataGridView1[0, rowIndex].Value.ToString();
            string dbconnect = "server=localhost;user=root;database=damir;Password=wsk2020;";
            MySqlConnection connect = new MySqlConnection(dbconnect);
            string query = "DELETE FROM students WHERE (`Id` = '" + idField + "');";
            try
            {
                MySqlCommand command = new MySqlCommand(query, connect);
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                dataGridView1.Rows.Clear();
                table_get();
                connect.Close();
            }
            
        }
    }
}
