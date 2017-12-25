using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace OtelOtomasyonu
{
    class MüşteriEkranı
    {

        Database db = new Database();

        public string state { get; set; }

        public string deleteState { get; set; }

        public DataTable tablolar()
        {
            if (db.baglanti.State==ConnectionState.Open)
            {
                db.baglanti.Close();
            }

            try
            {
                db.baglanti.Open();
                SqlCommand verileriAl = new SqlCommand("select * from musteriler", db.baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(verileriAl); // tablodaki verileri saklama yapıyor
                DataTable dataTable = new DataTable(); // tabloda verileri eşleme yapıyor
                adapter.Fill(dataTable); // datatable adapter eklendi
                return dataTable; // datatable döndürme işlemi yapılıyor
                
            }
            catch
            {
                return null;
            }
            finally
            {
                db.baglanti.Close();
            }
        }

        public void musterileriGuncelle(int id,string ad, string soyad, string cinsiyet, string tc, string oda, string ucret, DateTime giris, DateTime cikis)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }

            try
            {
                db.baglanti.Open();

                SqlCommand update = new SqlCommand("update musteriler set ad=@ad,soyad=@soyad,cinsiyet=@cinsiyet,tcNo=@tcNo,odaNo=@odaNo,ucret=@ucret,girisTarih=@girisTarih,cikisTarih=@cikisTarih where id=@id", db.baglanti);
                update.Parameters.AddWithValue("@ad", ad);
                update.Parameters.AddWithValue("@soyad", soyad);
                update.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                update.Parameters.AddWithValue("@tcNo", tc);
                update.Parameters.AddWithValue("@odaNo", oda);
                update.Parameters.AddWithValue("@ucret", ucret);
                update.Parameters.AddWithValue("@girisTarih", giris);
                update.Parameters.AddWithValue("@cikisTarih", cikis);
                update.Parameters.AddWithValue("@id", id);
                update.ExecuteNonQuery();
                state = ad + " " + soyad + "isim ve soyisimli kişilerinin verileri güncellendi";


            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }
            finally
            {
                db.baglanti.Close();
            }

        }

        public void musterilerSil(int id, String oda_adi)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }

            try
            {
                db.baglanti.Open();
                SqlCommand delete = new SqlCommand("delete musteriler where id=@id", db.baglanti);
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
                deleteState = "Silme işlemi başarılı bir şekilde gerçekleşti.";

                
                SqlCommand oda_delete = new SqlCommand("delete odalar where odaAdi=@ad", db.baglanti);
                oda_delete.Parameters.AddWithValue("@ad", oda_adi);
                oda_delete.ExecuteNonQuery();
               

            }
            catch
            {

            }
            finally
            {
                db.baglanti.Close();
            }
        }

        public DataTable musterilerAra(string ad)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }

            try
            {
                db.baglanti.Open();
                SqlCommand search = new SqlCommand("select * from musteriler where ad LIKE'%'+@ad+'%'", db.baglanti);
                search.Parameters.AddWithValue("@ad", ad);
                SqlDataAdapter adapter = new SqlDataAdapter(search);
                DataTable tablo = new DataTable();
                adapter.Fill(tablo);
                return tablo;

              



            }
            catch
            {
                return null;
            }
            finally
            {
                db.baglanti.Close();
            }
        }

    }
}
