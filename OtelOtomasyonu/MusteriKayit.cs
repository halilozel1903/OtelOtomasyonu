using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtelOtomasyonu
{
    class MusteriKayit
    {
        public string kisi_Adi_Soyadi_Getir { get; set; }

        Database database = new Database(); // Database nesnesi oluşturuldu.

        public static void odaKayitAl(string odaAdi, string odaSahibi)
        {
            Database database = new Database();

            if (database.baglanti.State == System.Data.ConnectionState.Open)
            {
                database.baglanti.Close(); // bağlantı açıksa bağlantıyı kapat
               
            }

            try
            {
                database.baglanti.Open(); // bağlantı aç
                SqlCommand kayitGuncelle = new SqlCommand("update odalar set odaSahibi=@alan_kisi,odaDurumu=@durum where odaAdi=@oda_adi", database.baglanti);
                kayitGuncelle.Parameters.AddWithValue("@alan_kisi", odaSahibi);
                kayitGuncelle.Parameters.AddWithValue("@durum", "Dolu");
                kayitGuncelle.Parameters.AddWithValue("@oda_adi", odaAdi);
                kayitGuncelle.ExecuteNonQuery();
                kayitGuncelle.Dispose();
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }
            finally
            {
                database.baglanti.Close(); //  bağlantıyı kapat
            }
        }

        
        public void kayitAl(string ad, string soyad,string cinsiyet,string tc,string oda,string ucret,DateTime giris,DateTime cikis)
        {
            if (database.baglanti.State == System.Data.ConnectionState.Open)
            {
                database.baglanti.Close(); // bağlantı açıksa bağlantıyı kapat
            }
            try
            {
                database.baglanti.Open(); // bağlantıyı aç
                SqlCommand kayitEkle = new SqlCommand("insert into musteriler values(@ad,@soyad,@cinsiyet,@tcNo,@odaNo,@ucret,@girisTarih,@cikisTarih)",
                database.baglanti); // insert ifadesi yazılacak
                kayitEkle.Parameters.AddWithValue("@ad",ad); // parametreler üzerinde işlem yapılacak
                kayitEkle.Parameters.AddWithValue("@soyad",soyad);
                kayitEkle.Parameters.AddWithValue("@cinsiyet",cinsiyet);
                kayitEkle.Parameters.AddWithValue("@tcNo",tc);
                kayitEkle.Parameters.AddWithValue("@odaNo",oda);
                kayitEkle.Parameters.AddWithValue("@ucret",ucret);
                kayitEkle.Parameters.AddWithValue("@girisTarih",giris);
                kayitEkle.Parameters.AddWithValue("@cikisTarih",cikis);
                kayitEkle.ExecuteNonQuery(); // eklemeleri yap
                System.Windows.Forms.MessageBox.Show("Müşteri kaydınız tamamlandı : "+oda+" adlı oda "+ad+"  "+soyad+" adlı kişiye verilmiştir.","Bilgilendirme Mesajı",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
                kayitEkle.Dispose(); // ram bellekten boşaltmaya yarar.

                kisi_Adi_Soyadi_Getir = ad + " " + soyad;
                odaKayitAl(oda, kisi_Adi_Soyadi_Getir);
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }

            finally
            {
                database.baglanti.Close(); // bağlantıyı kapat
            }

        }


    }
}
