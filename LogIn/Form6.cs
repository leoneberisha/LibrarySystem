using MySql.Data.MySqlClient;
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
    public partial class Form6 : Form
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
        public Form6()
        {
            InitializeComponent();
        }

        private void libratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void studentetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void huazimetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void autoretToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void kategoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();  
            form6.ShowDialog();
        }

        private void libraAktiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO kategori(id_kategoris) VALUES (@id_kategoris)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_kategoris",textBox1.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Loadbibloteka();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
