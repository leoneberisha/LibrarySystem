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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace LogIn
{
    public partial class Form2 : Form
    {
        string connectionString = "server=localhost;database=biblotek;uid=root;pwd='';";
        private void LoadBibloteka()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, id_kategori AS 'Kategoria', id_autor AS 'Autori librit', titulli AS 'Titulli i librit', numri_libres AS 'Numri librit', stoku AS 'Stoku', cmimi AS 'Cmimi', aktiv AS 'Aktiv' FROM librat";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void button_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO librat(id_kategori,id_autor,titulli,numri_libres,stoku,cmimi,aktiv) VALUES(@id_kategori,@id_autor,@titulli,@numri_libres,@stoku,@cmimi,@aktiv) ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_kategori", comboBox1.Text);
                cmd.Parameters.AddWithValue("@id_autor", comboBox2.Text);
                cmd.Parameters.AddWithValue("@titulli", textBox1.Text);
                cmd.Parameters.AddWithValue("@numri_libres", textBox2.Text);
                cmd.Parameters.AddWithValue("@stoku", textBox3.Text);
                string cmimiValue = checkBox1.Checked ? "Falas" : textBox4.Text;
                cmd.Parameters.AddWithValue("@cmimi", cmimiValue);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadBibloteka();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "UPDATE librat SET id_kategori=@id_kategori,id_autor=@id_autor,titulli=@titulli,numri_libres=@numri_libres,stoku=@stoku,cmimi=@cmimi,aktiv=@aktiv WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@id_kategori", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@id_autor", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@titulli", textBox1.Text);
                    cmd.Parameters.AddWithValue("@numri_libres", textBox2.Text);
                    cmd.Parameters.AddWithValue("@stoku", textBox3.Text);
                    string cmimiValue = checkBox1.Checked ? "Falas" : textBox4.Text;
                    cmd.Parameters.AddWithValue("@cmimi", cmimiValue);
                    cmd.Parameters.AddWithValue("@aktiv", radioButton1.Checked ? "po" : "jo");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LoadBibloteka();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                using (MySqlConnection conn = new MySqlConnection(connectionString))

                {
                    string query = "DELETE FROM librat WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LoadBibloteka();

                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, id_kategori AS 'Kategoria', id_autor AS 'Autori librit', titulli AS 'Titulli i librit', numri_libres AS 'Numri librit', stoku AS 'Stoku', cmimi AS 'Cmimi', aktiv AS 'Aktiv' FROM librat where titulli LIKE @kerko";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kerko", "%" + textBox5.Text + "%");
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;



            }
        }
    }
}
