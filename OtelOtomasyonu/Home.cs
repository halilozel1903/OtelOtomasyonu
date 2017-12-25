using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OtelOtomasyonu
{
    class Home
    {
        Database database = new Database();
        public string kullaniciAdi_tut { get; set; }
        public string kullaniciSifre_tut { get; set; }

        public string girisDurumu { get; set; }

        public void Login(string kullaniciAdi,string kullaniciSifre,DateTime tarih)
        {

            if(database.baglanti.State == System.Data.ConnectionState.Open)
            {
                database.baglanti.Close();
            }

            try
            {
                database.baglanti.Open();

                SqlCommand loginName = new SqlCommand("select kullaniciAdi from kullaniciBilgileri where kullaniciAdi=@kulAdi", database.baglanti);
                loginName.Parameters.AddWithValue("@kulAdi", kullaniciAdi);
                SqlDataReader kulAdi_Oku = loginName.ExecuteReader();
                if (kulAdi_Oku.Read())
                {
                    kullaniciAdi_tut = kulAdi_Oku["kullaniciAdi"].ToString();
                    SqlCommand loginPw = new SqlCommand("select kullaniciSifre from kullaniciBilgileri where kullaniciSifre = @sifre", database.baglanti);
                    loginPw.Parameters.AddWithValue("@sifre", kullaniciSifre);
                    SqlDataReader loginPw_Oku = loginPw.ExecuteReader();
                    if (loginPw_Oku.Read())
                    {
                        kullaniciSifre_tut = loginPw_Oku["kullaniciSifre"].ToString();
                        girisDurumu = kullaniciAdi_tut + " " + kullaniciSifre_tut; 
                        SqlCommand dateUpdate = new SqlCommand("update kullaniciBilgileri set girisTarihi=@tarih where kullaniciAdi = @kuladi AND kullaniciSifre = @kulsifre", database.baglanti);
                        dateUpdate.Parameters.AddWithValue("@tarih", tarih);
                        dateUpdate.Parameters.AddWithValue("@kuladi", kullaniciAdi_tut);
                        dateUpdate.Parameters.AddWithValue("@kulsifre", kullaniciSifre_tut);
                        dateUpdate.ExecuteNonQuery();
                        dateUpdate.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı şifreni yanlış girdin!", "Hata | Otel Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    loginPw.Dispose();
                    loginPw_Oku.Close();

                }
                else
                {
                    MessageBox.Show("Kullanıcı adını yanlış girdin!", "Hata | Otel otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loginName.Dispose();
                kulAdi_Oku.Close();
                database.baglanti.Close();


            }
            catch
            {

            }
            finally
            {
                database.baglanti.Close();
            }
        }
    }
}
