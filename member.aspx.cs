using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sipDetay;
using musteriSorumluList;
using SqlConnections;

public partial class member : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Cookies["assc"] == null)
        {
            Response.Redirect("/uye-giris");
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Çizgi Albüm Üye Sayfanız";

        int userID = Convert.ToInt32(HttpContext.Current.Request.Cookies["assc"]["mid"]);



        siparisSil();
        siparisList(userID);
        siparisListYuklemeBekleyen(userID);
        musteriBilgileri(userID);



        //DateTime tarih1 = DateTime.Now.AddYears(-2);
        //DateTime tarih2 = DateTime.Now.AddDays(-20);

        //string sql = "Select * from siparis2 where m_id=@mid and (m_tarih between convert(datetime, '" + tarih1 +
        //             "', 103) and convert(datetime, '" + tarih2 + "', 103))";

        //Page.Title = sql;

        if (!Page.IsPostBack)
        {
            this.Controls.Add(new LiteralControl("<script type='text/javascript'>CallFunction();</script>"));
        }

        
    }

    public void siparisSil()
    {

    DateTime tarih1 = DateTime.Now.AddYears(-2);
    DateTime tarih2 = DateTime.Now.AddDays(-21);

    try
    {
        using (SqlConnection x = new SqlConnection())
        {
            int userID = Convert.ToInt32(HttpContext.Current.Request.Cookies["assc"]["mid"]);

            x.ConnectionString = cstring.ConnStr();
            x.Open();

            string sql = "Delete from siparis2 where m_id=@mid and (m_tarih2 between convert(datetime, '" + tarih1 +
                         "', 103) and convert(datetime, '" + tarih2 + "', 103))";

            using (SqlCommand c = new SqlCommand(sql,x))
            {
                c.Parameters.AddWithValue("@mid", userID);

                c.ExecuteNonQuery();
            }



        }



    }
    catch (Exception )
    {

    }




    }








    public void musteriBilgileri(int _userID)
    {
        try
        {
            using (SqlConnection x = new SqlConnection())
            {
                x.ConnectionString = cstring.ConnStr();
                x.Open();

                using (SqlCommand c = new SqlCommand("SELECT     M_FIRSTNAME, M_LASTNAME, M_NAME, M_COMPANY, mid FROM         dbo.member WHERE(mid = @mid)", x))
                {
                    c.Parameters.AddWithValue("@mid", _userID);

                        using (SqlDataReader rdr = c.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                rdr.Read();
                                litMusteriAdi.Text = "HOŞGELDİN " + rdr["M_NAME"];
                                litFirmaBilgileri.Text = rdr["M_COMPANY"] + " - " + rdr["M_FIRSTNAME"] + " " + rdr["M_LASTNAME"];
                            }
                        }
                }
            }




        }
        catch (Exception )
        {
            litMusteriAdi.Text = "İsim alınırken bir sorun oluştu!";
            litFirmaBilgileri.Text = "Firma bilgileri alınırken bir sorun oluştu!";

        }




    }

    public void siparisList(int _userID)
    {

        connectionStr.DBIslem x = new connectionStr.DBIslem();

        SqlConnection bag = x.Baglanti();

        string sql = "Select top 25 siparis.id, siparis.m_id, siparis.m_tem, siparis.m_tarih, siparis.coban_onay, siparis.m_paket, siparis.sipKapakYazi, paket.paket_id, paket.paket_adi_tr from siparis, paket where siparis.m_onay=1 and siparis.m_id=@memberID and  siparis.m_onay=1 and siparis.m_id=@memberID and paket.paket_id=siparis.m_paket order by siparis.id desc";

        SqlCommand c = new SqlCommand(sql, bag);
        c.Parameters.AddWithValue("@memberID", _userID);

        SqlDataReader rdr = c.ExecuteReader();

        if (rdr.HasRows)
        {
            rptSiparislerim.DataSource = rdr;
            rptSiparislerim.DataBind();
        }

        else
        {
            siparisYok.Visible = true;
        }

        rdr.Close();
        c.Dispose();
        bag.Close();

    }

    public void siparisListYuklemeBekleyen(int _userID)
    {

        connectionStr.DBIslem x = new connectionStr.DBIslem();

        SqlConnection bag = x.Baglanti();

        string sql = "Select top 25 siparis2.id, siparis2.m_id, siparis2.m_tem, siparis2.m_tarih, siparis2.coban_onay, siparis2.m_paket, siparis2.sipKapakYazi, paket.paket_id, paket.paket_adi_tr from siparis2, paket where siparis2.m_onay=1 and siparis2.m_id=@memberID and  siparis2.m_onay=1 and siparis2.m_id=@memberID and paket.paket_id=siparis2.m_paket order by siparis2.id desc";

        SqlCommand c = new SqlCommand(sql, bag);
        c.Parameters.AddWithValue("@memberID", _userID);

        SqlDataReader rdr = c.ExecuteReader();

        if (rdr.HasRows)
        {
            rptYuklenecekSiparisler.DataSource = rdr;
            rptYuklenecekSiparisler.DataBind();
        }

        else
        {
            yuklemeBekleyenYok.Visible = true;
        }

        rdr.Close();
        c.Dispose();
        bag.Close();

    }

    public string siparisDurumu(int _id)
    {

        sipDetay.siparisDurum x = new sipDetay.siparisDurum();

        return x.sipDurum(_id);



    }

    protected void rptYuklenecekSiparisler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {

            if (e.CommandName=="Sil")
            {
                int silID = Convert.ToInt32(e.CommandArgument);

                using (SqlConnection x = new SqlConnection())
                {
                    x.ConnectionString = cstring.ConnStr();
                    x.Open();

                    using (SqlCommand s = new SqlCommand("delete from siparis2 where id=@id", x))
                    {
                        s.Parameters.AddWithValue("@id", silID);
                        s.ExecuteNonQuery();

                    }
                }
            }


            Response.Redirect("/uye-sayfam");
        }
        catch (Exception)
        {

        }
    }

    public string odemeKontrol(int sipNo)
    {
        string donus = "";

        try
        {
            using (SqlConnection xx = new SqlConnection())
            {
                xx.ConnectionString = cstring.ConnStr();
                xx.Open();

                using (SqlCommand s = new SqlCommand("Select ppipn_id, ppipn_siparis_id, ppipn_mid, ppipn_payment_status, ppipn_shipping, ppipn_payment_amount, ppipn_payment_currency, ppipn_paytype, ppipn_taksit, ppipn_odenenbanka, coban_onay, siparisSHA from ppipn, siparis where ppipn_siparis_id=@id and ppipn_active=1 and siparis.id=ppipn_siparis_id", xx))
                {
                    s.Parameters.AddWithValue("@id", sipNo);

                    SqlDataReader r = s.ExecuteReader();

                    if (r.HasRows)
                    {
                        r.Read();

                        if (r["ppipn_payment_status"].ToString() == "Completed")
                        {
                            donus = "<div><img src='/images/icons/valid.png' title='Ödeme Yapılmış "+ r["ppipn_payment_amount"].ToString() + " " + r["ppipn_payment_currency"].ToString() + "'/></div>";
                        }

                        else if (r["ppipn_payment_status"].ToString() != "Completed" && Convert.ToInt32(r["coban_onay"]) == 1)
                        {
                            if (string.IsNullOrEmpty(r["siparisSHA"].ToString()) || r["siparisSHA"] == DBNull.Value)
                            {
                                donus = "<div><img src='/images/icons/attention.png' alt='Bu siparişe henüz ödeme yapamazsınız!' title='Bu siparişe henüz ödeme yapamazsınız!'></div>";
                            }

                            else
                            {
                                donus = "  <div class='btn-group'><a href='/siparis-odeme?odeme=" + r["siparisSHA"].ToString() + "' class='btn btn-sm btn-danger'>Ödeme Yap</a</div>";
                            }
                        }

                        else if (r["ppipn_payment_status"].ToString() != "Completed" && Convert.ToInt32(r["coban_onay"]) == 2)
                        {
                            if (string.IsNullOrEmpty(r["siparisSHA"].ToString()) || r["siparisSHA"] == DBNull.Value)
                            {
                                donus = "<div><img src='/images/icons/attention.png' alt='Bu siparişe henüz ödeme yapamazsınız!' title='Bu siparişe henüz ödeme yapamazsınız!'></div>";
                            }

                            else
                            {
                                donus = "  <div class='btn-group'><a href='/siparis-odeme?odeme=" + r["siparisSHA"].ToString() + "' class='btn btn-sm btn-danger'>Ödeme Yap</a</div>";
                            }
                        }

                        else if (r["ppipn_payment_status"].ToString() != "Completed" && Convert.ToInt32(r["coban_onay"]) == 3)
                        {
                            if (string.IsNullOrEmpty(r["siparisSHA"].ToString()) || r["siparisSHA"] == DBNull.Value)
                            {
                                donus = "<div><img src='/images/icons/attention.png' alt='Bu siparişe ödeme yapamazsınız!' title='Bu siparişe ödeme yapamazsınız!'></div>";
                            }

                            else
                            {
                                donus = "<div><img src='/images/icons/error.png' alt='Tamamlanan siparişlere direkt ödeme yapamazsanız!' title='Tamamlanan siparişlere direkt ödeme yapamazsanız!'></div>";
                            }
                        }

                        else if (r["ppipn_payment_status"].ToString() != "Completed" && Convert.ToInt32(r["coban_onay"]) == 4)
                        {
                            if (string.IsNullOrEmpty(r["siparisSHA"].ToString()) || r["siparisSHA"] == DBNull.Value)
                            {
                                donus = "<div><img src='/images/icons/attention.png' alt='Bu siparişe ödeme yapamazsınız!' title='Bu siparişe ödeme yapamazsınız!'></div>";
                            }

                            else
                            {
                                donus = "<div><img src='/images/icons/error.png' alt='İptal edilen siparişlere ödeme yapamazsanız!' title='İptal edilen siparişlere ödeme yapamazsanız!'></div>";
                            }
                        }
                    }

                    else
                    {
                        using (SqlCommand sy = new SqlCommand("Select coban_onay, siparisSHA from siparis where id=@id", xx))
                        {
                            sy.Parameters.AddWithValue("@id", sipNo);

                            SqlDataReader rr = sy.ExecuteReader();

                            rr.Read();


                            if (Convert.ToInt32(rr["coban_onay"]) == 1)
                            {
                                if (string.IsNullOrEmpty(rr["siparisSHA"].ToString()) || rr["siparisSHA"] == DBNull.Value)
                                {
                                    donus = "<div><img src='/images/icons/attention.png' alt='Bu siparişe henüz ödeme yapamazsınız!'></div>";
                                }

                                else
                                {
                                    donus = "  <div class='btn-group'><a href='/siparis-odeme?odeme=" + rr["siparisSHA"].ToString() + "' class='btn btn-sm btn-danger'>Ödeme Yap</a</div>";
                                }
                            }

                            else if (Convert.ToInt32(rr["coban_onay"]) == 2)
                            {
                                if (string.IsNullOrEmpty(rr["siparisSHA"].ToString()) || rr["siparisSHA"] == DBNull.Value)
                                {
                                    donus = "<div><img src='/images/icons/attention.png' alt='Bu siparişe henüz ödeme yapamazsınız!' title='Bu siparişe henüz ödeme yapamazsınız!'></div>";
                                }

                                else
                                {
                                    donus = "  <div class='btn-group'><a href='/siparis-odeme?odeme=" + rr["siparisSHA"].ToString() + "' class='btn btn-sm btn-danger'>Ödeme Yap</a</div>";
                                }
                            }

                            else if (Convert.ToInt32(rr["coban_onay"]) == 3)
                            {
                                if (string.IsNullOrEmpty(rr["siparisSHA"].ToString()) || rr["siparisSHA"] == DBNull.Value)
                                {
                                    donus = "<div><img src='/images/icons/attention.png' alt='Bu siparişe ödeme yapamazsınız!' title='Bu siparişe ödeme yapamazsınız!'></div>";
                                }

                                else
                                {
                                    donus = "<div><img src='/images/icons/error.png' alt='Tamamlanan siparişlere direkt ödeme yapamazsanız!'></div>";
                                }
                            }

                            else if (Convert.ToInt32(rr["coban_onay"]) == 4)
                            {
                                if (string.IsNullOrEmpty(rr["siparisSHA"].ToString()) || rr["siparisSHA"] == DBNull.Value)
                                {
                                    donus = "<div><img src='/images/icons/attention.png' alt='Bu siparişe ödeme yapamazsınız!' title='Bu siparişe ödeme yapamazsınız!'></div>";
                                }

                                else
                                {
                                    donus = "<div><img src='/images/icons/error.png' alt='İptal edilen siparişlere ödeme yapamazsanız!' title='İptal edilen siparişlere ödeme yapamazsanız!'></div>";
                                }
                            }


                        }

                    }
                }

            }
        }
        catch (Exception)
        {
            donus = "<div><img src='/images/icons/attention.png'/ alt='' title='Bir sorun oluştu!'></div>";
        }


        return donus;
    }
}