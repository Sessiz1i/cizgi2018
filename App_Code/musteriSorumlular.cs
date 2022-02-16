using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for musteriSorumlular
/// </summary>

    namespace musteriSorumluList { 
public class musteriSorumlular
{
    public string musteriSorumluDonus(int musteriid, int tip) // 1 pazarlama 2 müşter tem 3 muhasebe
    {
        string sonuc = "";

        connectionStr.DBIslem x = new connectionStr.DBIslem();

        SqlConnection bag = x.Baglanti();

            string sqlTip = "";

            if (tip == 1)
            {
                sqlTip = "SELECT dbo.member.iltr, dbo.member.mid, dbo.s_coban.scid, dbo.s_coban.A_NAME, dbo.s_coban.A_LASTNAME, dbo.s_coban.scid_telefon FROM dbo.member INNER JOIN dbo.sehir ON dbo.member.iltr = dbo.sehir.sehir_id INNER JOIN dbo.s_coban ON dbo.sehir.sehir_pazarlama = dbo.s_coban.scid where mid=@memberID";
            }

            else if (tip == 2)
            {
                sqlTip = "SELECT dbo.member.iltr, dbo.member.mid, dbo.s_coban.scid, dbo.s_coban.A_NAME, dbo.s_coban.A_LASTNAME, dbo.s_coban.scid_telefon FROM dbo.member INNER JOIN dbo.sehir ON dbo.member.iltr = dbo.sehir.sehir_id INNER JOIN dbo.s_coban ON dbo.sehir.sehir_musteritem = dbo.s_coban.scid where mid=@memberID";
            }

            else if (tip == 3)
            {
                sqlTip = "SELECT dbo.member.iltr, dbo.member.mid, dbo.s_coban.scid, dbo.s_coban.A_NAME, dbo.s_coban.A_LASTNAME, dbo.s_coban.scid_telefon FROM dbo.member INNER JOIN dbo.sehir ON dbo.member.iltr = dbo.sehir.sehir_id INNER JOIN dbo.s_coban ON dbo.sehir.sehir_muhasebe = dbo.s_coban.scid where mid=@memberID";
            }

            string sql = sqlTip;

        SqlCommand c = new SqlCommand(sql, bag);
        c.Parameters.AddWithValue("@memberID", musteriid);

        SqlDataReader rdr = c.ExecuteReader();

        if (rdr.HasRows)
        {
            rdr.Read();

            sonuc = rdr["A_NAME"].ToString() + " " + rdr["A_LASTNAME"].ToString() + " " + rdr["scid_telefon"].ToString();
        }
        else
        {
            sonuc = "Bulunamadı!";
        }

        rdr.Close();
        c.Dispose();
        bag.Close();

        return sonuc;


    }
}
}