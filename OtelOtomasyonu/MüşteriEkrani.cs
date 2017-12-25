using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelOtomasyonu
{
    public partial class MüşteriEkrani : Form
    {
        public MüşteriEkrani()
        {
            InitializeComponent();
        }

        private void MüşteriEkrani_Load(object sender, EventArgs e)
        {
            MüşteriEkranı müşteriEkrani = new MüşteriEkranı();
            dataGridView1.DataSource=müşteriEkrani.tablolar();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblId.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
            txtAdi.Text = dataGridView1.Rows[e.RowIndex].Cells["ad"].Value.ToString();
            txtSoyadi.Text = dataGridView1.Rows[e.RowIndex].Cells["soyad"].Value.ToString();
            cbCinsiyeti.Text = dataGridView1.Rows[e.RowIndex].Cells["cinsiyet"].Value.ToString();
            txtTcsi.Text = dataGridView1.Rows[e.RowIndex].Cells["tcNo"].Value.ToString();
            txtOdasi.Text = dataGridView1.Rows[e.RowIndex].Cells["odaNo"].Value.ToString();
            txtUcreti.Text = dataGridView1.Rows[e.RowIndex].Cells["ucret"].Value.ToString();
            dateGirisi.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["girisTarih"].Value.ToString());
            dateCikisi.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["cikisTarih"].Value.ToString());
        }

        private void btnVeriGetir_Click(object sender, EventArgs e)
        {
            MüşteriEkranı müşteriEkranı = new MüşteriEkranı();
            dataGridView1.DataSource = müşteriEkranı.tablolar();
        }

        private void btnAlanTemizle_Click(object sender, EventArgs e)
        {
            txtAdi.Text = "";
            txtSoyadi.Text = "";
            cbCinsiyeti.Text = "";
            txtTcsi.Text = "";
            txtOdasi.Text = "";
            txtUcreti.Text = "";
            dateGirisi.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            dateCikisi.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DateTime girisTarih = Convert.ToDateTime(dateGirisi.Value);
            DateTime cikisTarih = Convert.ToDateTime(dateCikisi.Value);
            int id = Convert.ToInt16(lblId.Text);
            MüşteriEkranı me = new MüşteriEkranı();
            me.musterileriGuncelle(id,txtAdi.Text,txtSoyadi.Text, cbCinsiyeti.Text, txtTcsi.Text, txtOdasi.Text, txtUcreti.Text, girisTarih,cikisTarih);
            dataGridView1.DataSource = me.tablolar();


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(lblId.Text);
            String oda_adi = txtOdasi.Text;
            Console.WriteLine(oda_adi);

            MüşteriEkranı me = new MüşteriEkranı();
            me.musterilerSil(id, oda_adi);
            dataGridView1.DataSource = me.tablolar();
        }

        private void btnArama_Click(object sender, EventArgs e)
        {
            MüşteriEkranı me = new MüşteriEkranı();
            dataGridView1.DataSource= me.musterilerAra(txtAra.Text);
        }
    }
}
