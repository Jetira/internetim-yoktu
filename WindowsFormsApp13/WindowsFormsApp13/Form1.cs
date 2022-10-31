using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace WindowsFormsApp13
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            con = new SqlConnection("Data Source=DESKTOP-H8NKVL1;Initial Catalog=kisiler;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select*from bilgi where kullanici_adi='" + textBox1.Text +
                "'And sifre='" + textBox2.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş başarılı");
            }
            else
            {
                MessageBox.Show("Yanlış şifre");
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 gecis = new Form1();
            gecis.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Şifremi_unuttum gecis = new Şifremi_unuttum();
            gecis.Show();
        }
    }
}
