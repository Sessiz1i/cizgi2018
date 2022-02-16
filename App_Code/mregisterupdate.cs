using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using connectionStr;
using pwdHash;
using System.Data.SqlClient;


namespace register2
{ 
/// <summary>
/// Üye kayıt ve güncelleme işlemlerini yapar
/// </summary>
public class mregisterupdate
{
        /// <summary>
        /// Login sayfasından gelen verileri işleyerek üye kayıt işlemlerini yapar.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="isim"></param>
        /// <param name="soyisim"></param>
        /// <param name="eposta"></param>
        /// <param name="website"></param>
        /// <param name="ulke"></param>
        /// <param name="sehir"></param>
        /// <param name="adres"></param>
        /// <param name="funvan"></param>
        /// <param name="fFaturaIsim"></param>
        /// <param name="vergiDaire"></param>
        /// <param name="vergiNo"></param>
        /// <param name="fTel"></param>
        /// <param name="fAdres"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
    public int mregister(string username, string password, string isim, string soyisim, string eposta, string website, int ulke, int sehir, string adres, string funvan, string fFaturaIsim, string vergiDaire, string vergiNo, string fTel, string fAdres, string tel)
    {

        pwdHash.passwordHash m = new pwdHash.passwordHash();

            string MD5 = m.getMD5(password);

            //string MD5 = m.Encrypt(password);

            int donus = 1; // 0 Sorun oluştu 1- Kayıt Başarılı

        connectionStr.DBIslem baglan = new connectionStr.DBIslem();

        SqlConnection bag = baglan.Baglanti();

        string sql = "insert into member (M_NAME, M_PASSWORD, M_FIRSTNAME, M_LASTNAME, M_EMAIL, M_LINK, ulke, iltr, M_ADRESS, M_COMPANY, mf_isim, mf_vergidairesi, mf_vergino, mf_tel, mf_adres, M_TEL, uyeliktarihi) values(@M_NAME, @M_PASSWORD, @M_FIRSTNAME, @M_LASTNAME, @M_EMAIL, @M_LINK, @ulke, @iltr, @M_ADRESS, @M_COMPANY, @mf_isim, @mf_vergidairesi, @mf_vergino, @mf_tel, @mf_adres, @M_TEL, @uyeliktarihi) ;SELECT SCOPE_IDENTITY();";

        SqlCommand conn = new SqlCommand(sql, bag);
        conn.Parameters.AddWithValue("@M_NAME", username);
        conn.Parameters.AddWithValue("@M_PASSWORD", MD5);
        conn.Parameters.AddWithValue("@M_FIRSTNAME", isim);
        conn.Parameters.AddWithValue("@M_LASTNAME", soyisim);
        conn.Parameters.AddWithValue("@M_EMAIL", eposta);
        conn.Parameters.AddWithValue("@M_LINK", String.IsNullOrEmpty(website) ? (object)DBNull.Value : website);
        conn.Parameters.AddWithValue("@ulke", ulke);
        conn.Parameters.AddWithValue("@iltr", sehir);
        conn.Parameters.AddWithValue("@M_ADRESS", adres);
        conn.Parameters.AddWithValue("@M_COMPANY", String.IsNullOrEmpty(funvan) ? (object)DBNull.Value : funvan);
        conn.Parameters.AddWithValue("@mf_isim", String.IsNullOrEmpty(fFaturaIsim) ? (object)DBNull.Value : fFaturaIsim);
        conn.Parameters.AddWithValue("@mf_vergidairesi", String.IsNullOrEmpty(vergiDaire) ? (object)DBNull.Value : vergiDaire);
        conn.Parameters.AddWithValue("@mf_vergino", String.IsNullOrEmpty(vergiNo) ? (object)DBNull.Value : vergiNo);
        conn.Parameters.AddWithValue("@mf_tel", String.IsNullOrEmpty(fTel) ? (object)DBNull.Value : fTel);
        conn.Parameters.AddWithValue("@mf_adres", String.IsNullOrEmpty(fAdres) ? (object)DBNull.Value : fAdres);
        conn.Parameters.AddWithValue("@M_TEL", tel);
        conn.Parameters.AddWithValue("@uyeliktarihi", DateTime.Now);

            try // kayıt girmeyi dene !
            {
                int insertID = Convert.ToInt32(conn.ExecuteScalar());

            // logo için kayıt otomatik id ve kayıt oluşturmaca !

            //logo.logoXml x = new logo.logoXml();

            //bool logoCariSonuc = x.cariHesapAc(insertID, String.IsNullOrEmpty(funvan) ? isim + " " + soyisim : funvan, String.IsNullOrEmpty(fAdres) ? adres : fAdres, ulke, sehir, tel, fTel, vergiDaire, vergiNo, eposta);

            // logo için kayıt oluşturmaca bitiş !

            donus = 1;

            }
            catch (Exception)
            {
                donus = 0;
            }


        return donus;
    }

    public int mUpdate(string isim, string soyisim, string website, int ulke, int sehir, string adres, string funvan, string fFaturaIsim, string vergiDaire, string vergiNo, string fTel, string fAdres, string tel, int mid)
        {

            int donus = 1; // 0 Sorun oluştu 1- Kayıt Başarılı

            connectionStr.DBIslem baglan = new connectionStr.DBIslem();

            SqlConnection bag = baglan.Baglanti();

            string sql = "update member set M_FIRSTNAME=@M_FIRSTNAME, M_LASTNAME=@M_LASTNAME, M_LINK=@M_LINK, ulke=@ulke, iltr=@iltr, M_ADRESS=@M_ADRESS, M_COMPANY=@M_COMPANY, mf_isim=@mf_isim, mf_vergidairesi=@mf_vergidairesi, mf_vergino=@mf_vergino, mf_tel=@mf_tel, mf_adres=@mf_adres, M_TEL=@M_TEL where mid=@mid";

            SqlCommand conn = new SqlCommand(sql, bag);
            conn.Parameters.AddWithValue("@M_FIRSTNAME", isim);
            conn.Parameters.AddWithValue("@M_LASTNAME", soyisim);           
            conn.Parameters.AddWithValue("@M_LINK", String.IsNullOrEmpty(website) ? (object)DBNull.Value : website);
            conn.Parameters.AddWithValue("@ulke", ulke);
            conn.Parameters.AddWithValue("@iltr", sehir);
            conn.Parameters.AddWithValue("@M_ADRESS", adres);
            conn.Parameters.AddWithValue("@M_COMPANY", String.IsNullOrEmpty(funvan) ? (object)DBNull.Value : funvan);
            conn.Parameters.AddWithValue("@mf_isim", String.IsNullOrEmpty(fFaturaIsim) ? (object)DBNull.Value : fFaturaIsim);
            conn.Parameters.AddWithValue("@mf_vergidairesi", String.IsNullOrEmpty(vergiDaire) ? (object)DBNull.Value : vergiDaire);
            conn.Parameters.AddWithValue("@mf_vergino", String.IsNullOrEmpty(vergiNo) ? (object)DBNull.Value : vergiNo);
            conn.Parameters.AddWithValue("@mf_tel", String.IsNullOrEmpty(fTel) ? (object)DBNull.Value : fTel);
            conn.Parameters.AddWithValue("@mf_adres", String.IsNullOrEmpty(fAdres) ? (object)DBNull.Value : fAdres);
            conn.Parameters.AddWithValue("@M_TEL", tel);
            conn.Parameters.AddWithValue("@mid", mid);

            try
            {
                conn.ExecuteNonQuery();
                donus = 1;
            }
            catch (Exception)
            {

                donus = 0;
            }

            return donus;
        }



}
}
