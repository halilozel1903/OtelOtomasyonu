using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtelOtomasyonu
{
    class Odalar
    {
        public string buyPerson { get; set; }
        public string state { get; set; }
        public string buttonAdi { get; set; }

        Database database = new Database();

        public void odaDeger(string odaAdi,string durum) // metod tanımı
        {
            if (database.baglanti.State == System.Data.ConnectionState.Open)
            {
                database.baglanti.Close();
            }

            try
            {
                database.baglanti.Open();
                SqlCommand odalariAl = new SqlCommand("select * from odalar where odaAdi=@odaAdi and odaDurumu=@odaDurumu", database.baglanti);
                odalariAl.Parameters.AddWithValue("@odaAdi",odaAdi);
                odalariAl.Parameters.AddWithValue("@odaDurumu", durum);
                SqlDataReader odalari_Oku = odalariAl.ExecuteReader();

                if (odalari_Oku.Read())
                {
                    buyPerson = odalari_Oku["odaSahibi"].ToString();
                    state = odalari_Oku["odaDurumu"].ToString();
                    buttonAdi = odalari_Oku["buttonName"].ToString();

                }

                odalariAl.Dispose();
                odalari_Oku.Close();

            }
            catch(Exception hata)
            {
                System.Windows.Forms.MessageBox.Show(""+hata);
            }
            finally
            {
                database.baglanti.Close();
            }
        }


        public void oda_kayitAl(string odaAdi, string odaSahibi, string odaDurumu, string buttonName)
        {
            if (database.baglanti.State == System.Data.ConnectionState.Open)
            {
                database.baglanti.Close(); // bağlantı açıksa bağlantıyı kapat
            }
            try
            {
                database.baglanti.Open(); // bağlantıyı aç
                SqlCommand oda_kayitEkle = new SqlCommand("insert into odalar values(@odaAdi,@odaSahibi,@odaDurumu,@buttonName)",
                database.baglanti); // insert ifadesi yazılacak
                oda_kayitEkle.Parameters.AddWithValue("@odaAdi", odaAdi); // parametreler üzerinde işlem yapılacak
                oda_kayitEkle.Parameters.AddWithValue("@odaSahibi", odaSahibi);
                oda_kayitEkle.Parameters.AddWithValue("@odaDurumu", odaDurumu);
                oda_kayitEkle.Parameters.AddWithValue("@buttonName", buttonName);
                oda_kayitEkle.ExecuteNonQuery(); // eklemeleri yap
                oda_kayitEkle.Dispose(); // ram bellekten boşaltmaya yarar.

               
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }

            finally
            {
                database.baglanti.Close(); // bağlantıyı kapat
            }

        }
    }
}
