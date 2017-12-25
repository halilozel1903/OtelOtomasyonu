using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace OtelOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home grs = new Home();
            AnaEkran main = new AnaEkran();
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show("Lütfen kullanıcı adınızı ve şifrenizi doğru giriniz.", "HATA - Otel Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                grs.Login(textBox1.Text, textBox2.Text, DateTime.Now);
                string bilgiTut = textBox1.Text + " " + textBox2.Text.ToString();
                if (grs.girisDurumu == bilgiTut)
                {
                    main.Show();
                    this.Hide();
                }

                System.Media.SoundPlayer ses = new System.Media.SoundPlayer();
                ses.SoundLocation = "kartalsesi.wav";
                ses.Play();


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.Substring(1) + textBox3.Text.Substring(0, 1);
        }


    }
}
