using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for paketAlt
/// </summary>
/// 
namespace paketAlt { 
public class paketAlt
{
    public string paketAltDon(int paketID, int donusTipi)
    {
            string donus = "";

            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();

            string sqlTip = "";


                sqlTip = "SELECT paketalt_adi_tr, paketalt_iliski, paketalt_sira FROM dbo.paketalt where paketalt_iliski=@paket_iliski order by paketalt_sira ASC";


            string sql = sqlTip;

            SqlCommand c = new SqlCommand(sql, bag);
            c.Parameters.AddWithValue("@paket_iliski", paketID);

            SqlDataReader rdr = c.ExecuteReader();

           // rdr.Read();

            if (rdr.HasRows)
            {
                if (donusTipi==0)
                {


                donus += "<ul>";

                while (rdr.Read())
                {
                    donus += "<li><strong>" + rdr["paketalt_adi_tr"].ToString() + "</strong></li>";
                }                           

                donus += "</ul>";

                }

                else if (donusTipi == 1)
                {
                    while (rdr.Read())
                    {
                        donus += "</br>" + rdr["paketalt_adi_tr"].ToString() + "";
                    }
                }
            }

            else
            {
                donus = "";
            }


            rdr.Close();
            c.Dispose();
            bag.Close();

            return donus;

    }

    public string extraAdiDon(int paketExtraID)
        {

            string donus = "";

            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();

            string sql = "Select paketextra_id, paketextra_adi from paketextra where paketextra_id=@paketextra_id";

            SqlCommand c = new SqlCommand(sql, bag);
            c.Parameters.AddWithValue("@paketextra_id", paketExtraID);

            SqlDataReader r = c.ExecuteReader();

            r.Read();

            if (r.HasRows)
            {
                donus = r["paketextra_adi"].ToString();
            }

            else
            {
                donus = "Sorun ID : " + paketExtraID.ToString();
            }

            r.Close();
            bag.Dispose();

            return donus;
        }

        public string sayfaTipiDon(int sayfaTipiID)
        {
            string donus = "";

            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();

            string sql = "Select sayfatipi_id, sayfatipi_tur from sayfatipi where sayfatipi_id=@sayfatipi_id";

            SqlCommand c = new SqlCommand(sql, bag);
            c.Parameters.AddWithValue("@sayfatipi_id", sayfaTipiID);

            SqlDataReader r = c.ExecuteReader();

            r.Read();

            if (r.HasRows)
            {
                donus = r["sayfatipi_tur"].ToString();
            }

            else
            {
                donus = "Sorun ID : " + sayfaTipiID.ToString();
            }

            r.Close();
            bag.Dispose();

            return donus;





        }

        public static string kapakModelAdi(int kapakID)
        {

            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();

            string sql = "Select id, ad, image_path from urun where id=@urunID";

            SqlCommand c = new SqlCommand(sql, bag);
            c.Parameters.AddWithValue("@urunID", kapakID);

            SqlDataReader r = c.ExecuteReader();

            r.Read();


            return r["ad"].ToString() + "$" + r["image_path"].ToString();
        }

        public static string kapakModelAdi2(int siparisNo)
        {

            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();

            string sql = "SELECT dbo.siparis.id, dbo.urun.ad, dbo.urun.image_path, dbo.siparis.sipKapak FROM dbo.siparis INNER JOIN dbo.urun ON dbo.siparis.m_sipKapak = dbo.urun.id WHERE(dbo.siparis.id =@sipNo)";

            SqlCommand c = new SqlCommand(sql, bag);
            c.Parameters.AddWithValue("@sipNo", siparisNo);

            SqlDataReader r = c.ExecuteReader();

            r.Read();

            if (string.IsNullOrEmpty(r["sipKapak"].ToString()))
            {
                return r["ad"].ToString() + "$" + r["image_path"].ToString();
            }

            else
            {
                return r["sipKapak"].ToString() + "$blank.jpg";
            }

            
        }

    }
}