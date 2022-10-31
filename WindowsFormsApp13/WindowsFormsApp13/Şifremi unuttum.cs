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
using System.Data.Sql;
using System.Net;
using System.Net.Mail;


namespace WindowsFormsApp13
{
    public partial class Şifremi_unuttum : Form
    {
        public Şifremi_unuttum()
        {
            InitializeComponent();
        }

        private void Şifremi_unuttum_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlbaglanitisi bgln = new sqlbaglanitisi();
            SqlCommand komut = new SqlCommand("select * from bilgi where kullanici_adi='" + textBox1.Text.ToString() + "'and e_posta'" + textBox2.Text.ToString() + "'", bgln.baglanti());

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                try
                {
                    if (bgln.baglanti().State== ConnectionState.Closed)
                        {
                        bgln.baglanti().Open();
                    }
                    SmtpClient smtpserver = new SmtpClient();
                    MailMessage mail = new MailMessage();
                    string mailadresin = ("phontomolrd@gmail.com");
                    string sifre = ("Asking09");
                    string smptsrvr = "smtp.gmail.com";
                    string kime = (oku["eposta"].ToString());
                    string konu = ("şifre hatırlatma");
                    string yaz = ("Şifreniz:" + oku["sifre"]);
                    smtpserver.Credentials = new NetworkCredential(mailadresin, sifre);
                    smtpserver.Port = 587;
                    smtpserver.Host = smptsrvr;
                    smtpserver.EnableSsl = true;
                    mail.From = new MailAddress(mailadresin);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body = yaz;
                    smtpserver.Send(mail);
                }
                catch(Exception Hata)
                {
                    MessageBox.Show("hata31", Hata.Message);
                }
            }
        }
    }
}
