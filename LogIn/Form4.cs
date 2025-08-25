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
    public partial class Form4 : Form
    {
        string connectionString = "server=localhost; database=biblotek;uid=root;pwd=''";

        private void Loadbibloteka()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = " SELECT id,id_libri as NumriLibrit,id_student as Studenti, data_marrje, data_kthimi FROM huazimet";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO huazimet (id_libri,id_student,data_marrje,data_kthimi)VALUES(@id_libri,@id_student,@data_marrje,@data_kthimi)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_libri", textBox1.Text);
                cmd.Parameters.AddWithValue("@id_student", textBox2.Text);
                cmd.Parameters.AddWithValue("@data_marrje", dateTimePicker1);
                cmd.Parameters.AddWithValue("@data_kthimi", dateTimePicker2);
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
                     
                }
            }
        }
    }
}
