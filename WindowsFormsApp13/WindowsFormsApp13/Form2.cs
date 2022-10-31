using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=DESKTOP-H8NKVL1;Initial Catalog=kisiler;Integrated Security=True";
        SqlConnection connect = new SqlConnection(constring);

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                string kayit = "insert into bilgi (kullanici_adi,sifre,e_posta)values(@kullanici_adi,@sifre,@e_posta)";
                SqlCommand komut = new SqlCommand(kayit, connect);

                komut.Parameters.AddWithValue("@kullanici_adi", txt_kad.Text);

                komut.Parameters.AddWithValue("@sifre", txt_sif.Text);

                komut.Parameters.AddWithValue("@e_posta", txt_pos.Text);

                komut.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Kayıt eklendi");
            }
            catch(Exception hata)
            {
                MessageBox.Show("hata meydana geldi" + hata.Message);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
