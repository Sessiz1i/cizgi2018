using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace sipDetay { 
/// <summary>
/// Summary description for siparisDurum
/// </summary>
public class siparisDurum
{
    public string sipDurum(int _sipID)
    {
        string donus = "";

        connectionStr.DBIslem x = new connectionStr.DBIslem();

        SqlConnection bag = x.Baglanti();

        string sql = "select siparisdurumana_sip, siparisdurumana_durum from siparisdurumana where siparisdurumana_sip=@sipIDS";
        SqlCommand c = new SqlCommand(sql, bag);
        c.Parameters.AddWithValue("@sipIDS", _sipID);

        SqlDataReader rdr = c.ExecuteReader();

        rdr.Read();

        if (rdr.HasRows)
        {
           donus = sipDurumSon(Convert.ToInt32(rdr["siparisdurumana_durum"]));
        }

        else
        {
            donus = "Onay Bekliyor";
        }

        rdr.Close();
        c.Dispose();
        bag.Close();


        return donus;

    }

    public string sipDurumSon(int _id)
    {
        if (_id == 1)
        {
            return "<em class='text-primary'>Kontrol Bekliyor</em>";
        }

        else if (_id == 2)
               
        {
            return "<em class='text-warning'>Photoshopta</em>";
        }

        else if (_id == 3)
        {
            return "<em class='text-warning'>Baskıda</em>";
        }

        else if (_id == 4)
        {
            return "<em class='text-inverse'>İmalatta</em>";
        }

        else if (_id == 5)
        {
            return "<em class='text-muted'>Paketleniyor</em>";
        }

        else if (_id == 6)
        {
            return "<em class='text-muted'>Kargo Bekliyor</em>";
        }

        else if (_id == 7)
        {
            return "<em class='text-success'>Gönderildi</em>";
        }

        else if (_id == 8)
        {
            return "<em class='text-danger'>İptal Edildi</em>";
        }

        else
        {
            return "";
        }
       


    }


}
}