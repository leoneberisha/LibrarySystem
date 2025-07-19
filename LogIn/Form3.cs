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

namespace LogIn
{
    public partial class Form3 : Form
    {
        string connectionString = "server=localhost; database=biblotek;uid=root;pwd=''";

        private void Loadbibloteka()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id,emri AS Emri, nr_student AS NrStudentit, telefon AS Telefoni, drejtim AS Drejtimi, email AS Emaili, gjini AS Gjinia FROM student";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

            }
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString)) 
                {
                    string query= "INSERT INTO student(emri, nr_student, telefon, drejtim, email, gjini) VALUES(@emri,@nr_student,@telefon,@drejtim,@email,@gjini)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@emri", textBox1.Text);
                    cmd.Parameters.AddWithValue("@nr_student", textBox2.Text);
                    cmd.Parameters.AddWithValue("@telefon", textBox3.Text);
                    cmd.Parameters.AddWithValue("@drejtim", textBox4.Text);
                    cmd.Parameters.AddWithValue("@email", textBox5.Text);
                    cmd.Parameters.AddWithValue("@gjini", radioButton1.Checked ? "M" : "F'");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Loadbibloteka();
                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                using (MySqlConnection conn = new MySqlConnection(connectionString)) 
                {
                    string query = "UPDATE student SET emri=@emri,nr_student=@nr_student,telefon=@telefon,drejtim=@drejtim,email=@email,gjini=@gjini Where id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@emri", textBox1.Text);
                    cmd.Parameters.AddWithValue("@nr_student", textBox2.Text);
                    cmd.Parameters.AddWithValue("@telefon", textBox3.Text);
                    cmd.Parameters.AddWithValue("@drejtim", textBox4.Text);
                    cmd.Parameters.AddWithValue("@email", textBox5.Text);
                    cmd.Parameters.AddWithValue("@gjini", radioButton1.Checked ? "M" : "F");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Loadbibloteka();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "DELETE FROM student Where id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Loadbibloteka();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, emri AS Emri, nr_student AS NrStudentit, telefon AS Telefoni, drejtim AS Drejtimi, email AS Emaili, gjini AS Gjinia FROM student where emri LIKE @kerko";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kerko", "%" + textBox6.Text + "%");
                MySqlDataAdapter adapter = new MySqlDataAdapter();
               DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }
    }
    } 

