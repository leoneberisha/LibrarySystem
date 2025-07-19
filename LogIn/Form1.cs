using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LogIn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string connStr = "server=localhost;uid=root;database=biblotek;pwd='';";
            string username = textBox1.Text;
            string password = textBox2.Text;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "Select * FROM login WHERE user=@username AND pass=@password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Form3 form3 = new Form3();
                        form3.ShowDialog();
                        //  MessageBox.Show("Login me sukses");
                    }
                    else
                    {
                        MessageBox.Show("Perdoruesi ose paswoed gabim");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gabim" + ex.Message);
            }
        
        }
    }
}
