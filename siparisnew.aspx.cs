using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;
using paketAlt;
using fiyatlar;
using pwdHash;
using Resources;
using SqlConnections;

public partial class siparisnew : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Cookies["assc"] == null)
        {
            Response.Redirect("/uye-giris");
        }

    }
    public string musteriID { get; set; }

    //public string siparisOzelID { get; set; }

    public string siparisOzelID
    {
        get
        {
            if (this.ViewState["siparisOzelID"] == null)
                return "";

            return (string)this.ViewState["siparisOzelID"];
        }
        set { this.ViewState["siparisOzelID"] = value; }
    }

    public string siparisOzelCode
    {
        get
        {
            if (this.ViewState["siparisOzelCode"] == null)
                return "";

            return (string)this.ViewState["siparisOzelCode"];
        }
        set { this.ViewState["siparisOzelCode"] = value; }
    }


    public int paketNo
    {
        get
        {
            if (this.ViewState["paketNo"] == null)
                return 0;

            return (int)this.ViewState["paketNo"];
        }
        set { this.ViewState["paketNo"] = value; }
    }

    public int secilenKapak
    {
        get
        {
            if (this.ViewState["secilenKapak"] == null)
                return 0;

            return (int)this.ViewState["secilenKapak"];
        }
        set { this.ViewState["secilenKapak"] = value; }
    }

    public int zorunluKapak
    {
        get
        {
            if (this.ViewState["zorunluKapak"] == null)
                return 0;

            return (int)this.ViewState["zorunluKapak"];
        }
        set { this.ViewState["zorunluKapak"] = value; }
    }

    public int zorunluAhsap
    {
        get
        {
            if (this.ViewState["zorunluAhsap"] == null)
                return 0;

            return (int)this.ViewState["zorunluAhsap"];
        }
        set { this.ViewState["zorunluAhsap"] = value; }
    }

    public string kapakAdi
    {
        get
        {
            if (this.ViewState["kapakAdi"] == null)
                return "Model Bilinmiyor";

            return (string)this.ViewState["kapakAdi"];
        }
        set { this.ViewState["kapakAdi"] = value; }
    }

    public int sMin
    {
        get
        {
            if (this.ViewState["sMin"] == null)
                return 0;

            return (int)this.ViewState["sMin"];
        }
        set { this.ViewState["sMin"] = value; }
    }

    public int sMax
    {
        get
        {
            if (this.ViewState["sMax"] == null)
                return 0;

            return (int)this.ViewState["sMax"];
        }
        set { this.ViewState["sMax"] = value; }
    }

    public string paraBirimi
    {
        get
        {
            if (this.ViewState["paraBirimi"] == null)
                return "TL";

            return (string)this.ViewState["paraBirimi"];
        }
        set { this.ViewState["paraBirimi"] = value; }
    }

    public int seciliBolge
    {
        get
        {
            if (this.ViewState["seciliBolge"] == null)
                return 1;

            return (int)this.ViewState["seciliBolge"];
        }
        set { this.ViewState["seciliBolge"] = value; }
    }

    public int secilenCanta
    {
        get
        {
            if (this.ViewState["secilenCanta"] == null)
                return 16;

            return (int)this.ViewState["secilenCanta"];
        }
        set { this.ViewState["secilenCanta"] = value; }
    }

    public int secilenSaat
    {
        get
        {
            if (this.ViewState["secilenSaat"] == null)
                return 17;

            return (int)this.ViewState["secilenSaat"];
        }
        set { this.ViewState["secilenSaat"] = value; }
    }

    public int secilenAile
    {
        get
        {
            if (this.ViewState["secilenAile"] == null)
                return 36;

            return (int)this.ViewState["secilenAile"];
        }
        set { this.ViewState["secilenAile"] = value; }
    }

    public int secilenCep
    {
        get
        {
            if (this.ViewState["secilenCep"] == null)
                return 22;

            return (int)this.ViewState["secilenCep"];
        }
        set { this.ViewState["secilenCep"] = value; }
    }

    public int secilenBuyuk
    {
        get
        {
            if (this.ViewState["secilenBuyuk"] == null)
                return 21;

            return (int)this.ViewState["secilenBuyuk"];
        }
        set { this.ViewState["secilenBuyuk"] = value; }
    }

    public int secilenKagit
    {
        get
        {
            if (this.ViewState["secilenKagit"] == null)
                return 1;

            return (int)this.ViewState["secilenKagit"];
        }
        set { this.ViewState["secilenKagit"] = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        int userID = Convert.ToInt32(HttpContext.Current.Request.Cookies["assc"]["mid"]);

        musteriID = userID.ToString();

        if (siparisOzelID == "")
        {
            //siparisOzelID = musteriID + "-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" +
            //DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" +
            //DateTime.Now.Minute + "-" + DateTime.Now.Millisecond;

            siparisOzelID = musteriID + "/" + musteriID + "-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + "-" + DateTime.Now.Millisecond;

            pwdHash.passwordHash ency = new passwordHash();

            siparisOzelCode = ency.Encrypt(siparisOzelID);
        }



        //if (Session["fileN"] != null)
        //{
        //    Label1.Text = Session["fileN"].ToString();
        //}
        //else
        //{
        //    Label1.Text = "Session boş";
        //}


        if (!Page.IsPostBack)
        {
            goldSeri();
            yp19Seri();
            jumboSeri();
            yeniKampanyaliSeri();
			ekoKampanyaliSeri();
            saveTheDateSeri();
            vintageSeri();
            tekAlbumKampanyaliSeri();
            babyKidsSeri();
            //masterSeri();
                  //      premiumPlusSeri();
            premiumSeri();
            //            kristalPlusSeri();
            //kristalSeri();
            //standartSeri();
            kampanyaliSeri();

            Page.Title = (string)(GetGlobalResourceObject("strings", "siparisPageTitle"));



            if (Request.QueryString["err"] != null)
            {
                //Label1.Text = Session["fileN"].ToString();



                int errCode = 0;

                try
                {
                    int.TryParse(Request.QueryString["err"], out errCode);
                }
                catch (Exception)
                {
                    errCode = 0;
                }




                if (errCode == 1)
                {
                    try
                    {

                        pnlDone.Visible = true;

                        using (SqlConnection con = new SqlConnection())
                        {
                            con.ConnectionString = cstring.ConnStr();
                            con.Open();


                            int sipNumber = Convert.ToInt32(passwordHash.SifreCoz(Request.QueryString["siparis"]));

                            using (SqlCommand c = new SqlCommand("Select id, siparis_md5, hashprob, hasprobid from siparis where id=@sip", con))
                            {
                                c.Parameters.AddWithValue("@sip", sipNumber);

                                using (SqlDataReader r = c.ExecuteReader())
                                {
                                    r.Read();

                                    if (r.HasRows)
                                    {
                                        if (r["hashprob"] == DBNull.Value) // sipariş tekrar yok
                                        {
                                            ltsiparisDoneYazi1.Text = (string)(GetGlobalResourceObject("strings", "siparisDoneYazi1"));
                                            ltsiparisDoneYazi2.Text = (string)(GetGlobalResourceObject("strings", "siparisDoneYazi2"));
                                            ltsiparisDoneYazi3.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisDoneYazi3")), r["id"]);
                                            ltsiparisDoneYazi4.Text = (string)(GetGlobalResourceObject("strings", "siparisDoneYazi4"));
                                            ltsiparisDoneYazi5.Text = (string)(GetGlobalResourceObject("strings", "siparisDoneYazi5"));
                                        }

                                        else // sipariş tekrarı var önceki siparişin tarihi alınacak
                                        {
                                            using (SqlCommand t = new SqlCommand("Select id, m_tarih from siparis where id=@tid", con))
                                            {
                                                t.Parameters.AddWithValue("@tid", r["hasprobid"]);

                                                using (SqlDataReader tr = t.ExecuteReader())
                                                {
                                                    tr.Read();

                                                    if (tr.HasRows)
                                                    {
                                                        ltsiparisDoneYazi1.Text = (string)(GetGlobalResourceObject("strings", "siparisDoneYazi1"));
                                                        ltsiparisDoneYazi2.Text = (string)(GetGlobalResourceObject("strings", "siparisDoneYazi2"));
                                                        ltsiparisDoneYazi3.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisDoneYazi3")), r["id"]);
                                                        ltsiparisDoneYazi4.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisDoneYazi8")), tr["m_tarih"], tr["id"].ToString());
                                                        ltsiparisDoneYazi5.Text = (string)(GetGlobalResourceObject("strings", "siparisDoneYazi9"));
                                                        //ltsiparisDoneYazi5.Text += "</br>" + errCode;
                                                    }

                                                }
                                            }
                                        }

                                        litKKOdeme.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKKOdeme")), r["id"]);
                                        sipKKOdeme.HRef = "https://eski.mertalbum.com/paypal_pay.asp?panoramik_odeme=" + r["siparis_md5"];

                                        File.Delete(HttpContext.Current.Server.MapPath(@"~/siparisXml/" + passwordHash.SifreCoz(Request.QueryString["Code"]) + ".xml"));



                                    }

                                    else // row yok?
                                    {
                                        pnlDone.Visible = false;
                                        pnlError.Visible = true;


                                        Literal18.Text = (string)(GetGlobalResourceObject("strings", "siparisErrYazi1"));
                                        Literal19.Text = (string)(GetGlobalResourceObject("strings", "siparisErrYazi4"));
                                        Literal20.Text = (string)(GetGlobalResourceObject("strings", "siparisErrYazi5"));
                                        Literal20.Text += "</br>" + string.Format((string)(GetGlobalResourceObject("strings", "sistemHataMesaj2")), xmlError.errLog.hataKayit("Sipariş numarası karşılığı bulunamadı."));
                                        Literal20.Text += "</br>" + (string)(GetGlobalResourceObject("strings", "sistemHataMesaj3"));
                                    }


                                }


                            }








                        }





                    }
                    catch (Exception ex)
                    {

                        Literal18.Text = (string)(GetGlobalResourceObject("strings", "siparisErrYazi1"));
                        Literal19.Text = (string)(GetGlobalResourceObject("strings", "siparisErrYazi2"));
                        Literal20.Text = (string)(GetGlobalResourceObject("strings", "siparisErrYazi3"));
                        Literal20.Text += "</br>" + string.Format((string)(GetGlobalResourceObject("strings", "sistemHataMesaj2")), xmlError.errLog.hataKayit(ex.ToString()));
                        Literal20.Text += "</br>" + (string)(GetGlobalResourceObject("strings", "sistemHataMesaj3"));
                        //Literal20.Text += "</br>" + pwdHash.passwordHash.SifreCoz(Request.QueryString["siparis"]);




                        pnlDone.Visible = false;
                        pnlError.Visible = true;
                        //sipDataEnc.Text = ex.ToString();
                    }


                }

                else
                {
                    pnlDone.Visible = false;
                    pnlError.Visible = true;


                    Literal18.Text = (string)(GetGlobalResourceObject("strings", "siparisErrYazi1"));
                    Literal19.Text = (string)(GetGlobalResourceObject("strings", "siparisErrYazi4"));
                    Literal20.Text = (string)(GetGlobalResourceObject("strings", "siparisErrYazi5"));
                    Literal20.Text += "</br>" + string.Format((string)(GetGlobalResourceObject("strings", "sistemHataMesaj2")), xmlError.errLog.hataKayit("Yüklenen dosya dizinde bulunamadı."));
                    Literal20.Text += "</br>" + (string)(GetGlobalResourceObject("strings", "sistemHataMesaj3"));
                }




                pnlForm.Visible = false;
                pnlKapaklar.Visible = false;
                pnlOlculer.Visible = false;
                pnlPaketler.Visible = false;
                pnlSepet.Visible = false;
                pnlUpload.Visible = false;

                //Session.Abandon();
            }

        }

    }

    public void masterSeri()

    {
        connectionStr.DBIslem x = new connectionStr.DBIslem();
        SqlConnection bag = x.Baglanti();

        string sql = "Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=1 order by paketolcu_sira ASC";

        SqlCommand c = new SqlCommand(sql, bag);
        SqlDataReader rdr = c.ExecuteReader();

        rptMasterSeri.DataSource = rdr;
        rptMasterSeri.DataBind();

        rdr.Close();
        c.Dispose();
        bag.Close();
    }

    public void goldSeri()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=14 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptGoldSeri.DataSource = rdr;
                    rptGoldSeri.DataBind();
                }
            }
        }
    }

    public void yp19Seri()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=16 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rpyp19Seri.DataSource = rdr;
                    rpyp19Seri.DataBind();
                }
            }
        }
    }

    public void jumboSeri()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=15 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptJumbo.DataSource = rdr;
                    rptJumbo.DataBind();
                }
            }
        }
    }

    public void yeniKampanyaliSeri()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=8 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptYeniKampanyali.DataSource = rdr;
                    rptYeniKampanyali.DataBind();
                }
            }
        }
    }

    public void ekoKampanyaliSeri()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=13 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptEkoKampanyali.DataSource = rdr;
                    rptEkoKampanyali.DataBind();
                }
            }
        }
    }

    public void saveTheDateSeri()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=10 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptSTDSeries.DataSource = rdr;
                    rptSTDSeries.DataBind();
                }
            }
        }
    }

    public void vintageSeri()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=9 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptVintageSeri.DataSource = rdr;
                    rptVintageSeri.DataBind();
                }
            }
        }
    }

    public void tekAlbumKampanyaliSeri()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=11 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptTekAlbumKampanyali.DataSource = rdr;
                    rptTekAlbumKampanyali.DataBind();
                }
            }
        }
    }

    public void babyKidsSeri()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=12 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptBabyKidsSerisi.DataSource = rdr;
                    rptBabyKidsSerisi.DataBind();
                }
            }
        }
    }

    public void premiumPlusSeri()

    {
        connectionStr.DBIslem x = new connectionStr.DBIslem();
        SqlConnection bag = x.Baglanti();

        string sql = "Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=2 order by paketolcu_sira ASC";

        SqlCommand c = new SqlCommand(sql, bag);
        SqlDataReader rdr = c.ExecuteReader();

        rptPremiumPlusSeri.DataSource = rdr;
        rptPremiumPlusSeri.DataBind();

        rdr.Close();
        c.Dispose();
        bag.Close();
    }

    public void premiumSeri()

    {
        connectionStr.DBIslem x = new connectionStr.DBIslem();
        SqlConnection bag = x.Baglanti();

        string sql = "Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=3 order by paketolcu_sira ASC";

        SqlCommand c = new SqlCommand(sql, bag);
        SqlDataReader rdr = c.ExecuteReader();

        rptPremiumSeri.DataSource = rdr;
        rptPremiumSeri.DataBind();

        rdr.Close();
        c.Dispose();
        bag.Close();
    }

    public void kristalSeri()

    {
        connectionStr.DBIslem x = new connectionStr.DBIslem();
        SqlConnection bag = x.Baglanti();

        string sql = "Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=4 order by paketolcu_sira ASC";

        SqlCommand c = new SqlCommand(sql, bag);
        SqlDataReader rdr = c.ExecuteReader();

        rptKristalSeri.DataSource = rdr;
        rptKristalSeri.DataBind();

        rdr.Close();
        c.Dispose();
        bag.Close();
    }

    public void kristalPlusSeri()

    {
        connectionStr.DBIslem x = new connectionStr.DBIslem();
        SqlConnection bag = x.Baglanti();

        string sql = "Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=7 order by paketolcu_sira ASC";

        SqlCommand c = new SqlCommand(sql, bag);
        SqlDataReader rdr = c.ExecuteReader();

        rptKristalPlusSeri.DataSource = rdr;
        rptKristalPlusSeri.DataBind();

        rdr.Close();
        c.Dispose();
        bag.Close();
    }

    public void standartSeri()

    {
        connectionStr.DBIslem x = new connectionStr.DBIslem();
        SqlConnection bag = x.Baglanti();

        string sql = "Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=5 order by paketolcu_sira ASC";

        SqlCommand c = new SqlCommand(sql, bag);
        SqlDataReader rdr = c.ExecuteReader();

        rptStandartSeri.DataSource = rdr;
        rptStandartSeri.DataBind();

        rdr.Close();
        c.Dispose();
        bag.Close();
    }

    public void kampanyaliSeri()

    {
        connectionStr.DBIslem x = new connectionStr.DBIslem();
        SqlConnection bag = x.Baglanti();

        string sql = "Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=6 order by paketolcu_sira ASC";

        SqlCommand c = new SqlCommand(sql, bag);
        SqlDataReader rdr = c.ExecuteReader();

        rptKampanyaliSeri.DataSource = rdr;
        rptKampanyaliSeri.DataBind();

        rdr.Close();
        c.Dispose();
        bag.Close();
    }



    public void paketGetir(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "paketGoster")
        {
            //pnlPaketler.Visible = true;

            //pnlCalisma.Visible = false;
            //pnlKapaklar.Visible = false;
            //pnlForm.Visible = false;

            //ScriptManager.RegisterStartupScript(this, GetType(), "outTime4444125", "fadeOUT('uplFormDis');", true);

            //hdnOlcu.Value = e.CommandArgument.ToString();

            rptPaketler.DataSource = null;
            rptPaketler.DataBind();

            rptKapakDikey.DataSource = null;
            rptKapakDikey.DataBind();

            rptKapakNormal.DataSource = null;
            rptKapakNormal.DataBind();

            rptKapakYatay.DataSource = null;
            rptKapakYatay.DataBind();

            rptSaatler.DataSource = null;
            rptSaatler.DataBind();

            rptCantalar.DataSource = null;
            rptCantalar.DataBind();

            rptAile.DataSource = null;
            rptAile.DataBind();

            rptCep.DataSource = null;
            rptCep.DataBind();

            rptBuyuk.DataSource = null;
            rptBuyuk.DataBind();

            pnlForm.Visible = false;
            pnlSepet.Visible = false;


            secilenCanta = 16;
            secilenSaat = 17;
            secilenAile = 36;
            secilenCep = 22;
            secilenBuyuk = 21;


            paketler(Convert.ToInt32(e.CommandArgument));

            ScriptManager.RegisterStartupScript(this, GetType(), "moveToo", "moveTo('paketler');", true);


            System.Threading.Thread.Sleep(1000);

            dosyaFormGizle();
        }
    }

    public void paketler(int olcuID)
    {

        connectionStr.DBIslem x = new connectionStr.DBIslem();
        SqlConnection bag = x.Baglanti();

        string sql = "SELECT     dbo.currency.currency_id, dbo.currency.currency_simge, dbo.paket.paket_id, dbo.paket.paket_adi_tr, dbo.paket.paket_languageStr, dbo.member.mid, dbo.paket.paket_active, dbo.paket.paket_fotonew, dbo.paket.paket_fiyat, dbo.bolge.bolge_id FROM         dbo.sehir INNER JOIN dbo.member ON dbo.sehir.sehir_id = dbo.member.iltr INNER JOIN                     dbo.ulke ON dbo.sehir.sehir_ulkeid = dbo.ulke.ulke_id INNER JOIN                      dbo.bolge INNER JOIN                      dbo.currency ON dbo.bolge.bolge_currency = dbo.currency.currency_id INNER JOIN                      dbo.paket ON dbo.bolge.bolge_id = dbo.paket.paket_bolge ON dbo.ulke.ulke_bolge = dbo.bolge.bolge_id INNER JOIN                      dbo.paketolcu ON dbo.paket.paket_olcu = dbo.paketolcu.paketolcu_id WHERE(dbo.paket.paket_active = 1) and mid=@musteriID and paket_olcu=@olcuID  order by paket_sira_no ASC";

        SqlCommand c = new SqlCommand(sql, bag);
        c.Parameters.AddWithValue("@olcuID", olcuID);
        c.Parameters.AddWithValue("@musteriID", musteriID);
        SqlDataReader rdr = c.ExecuteReader();

        rptPaketler.DataSource = rdr;
        rptPaketler.DataBind();

        rdr.Close();
        c.Dispose();
        bag.Close();

        //ScriptManager.RegisterStartupScript(this, GetType(), "showTime21312", "fade('olculer');", true);


    }

    public string paketAltGetir(int paketID)
    {
        paketAlt.paketAlt x = new paketAlt.paketAlt();

        return x.paketAltDon(paketID, 0);

    }

    public void paketSec(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "paketSec")
        {

            rptKapakDikey.DataSource = null;
            rptKapakDikey.DataBind();

            rptKapakNormal.DataSource = null;
            rptKapakNormal.DataBind();

            rptKapakYatay.DataSource = null;
            rptKapakYatay.DataBind();

            rptSaatler.DataSource = null;
            rptSaatler.DataBind();

            rptCantalar.DataSource = null;
            rptCantalar.DataBind();

            rptAile.DataSource = null;
            rptAile.DataBind();

            rptCep.DataSource = null;
            rptCep.DataBind();

            rptBuyuk.DataSource = null;
            rptBuyuk.DataBind();

            pnlForm.Visible = false;
            pnlSepet.Visible = false;


            connectionStr.DBIslem x = new connectionStr.DBIslem();
            SqlConnection bag = x.Baglanti();

            string sql = "SELECT paket_id, paket_urun, paket_fotoDiz, paket_smin, paket_smax from paket where paket_id=@paketID";

            SqlCommand c = new SqlCommand(sql, bag);
            c.Parameters.AddWithValue("@paketID", Convert.ToInt32(e.CommandArgument));
            SqlDataReader rdr = c.ExecuteReader();

            paketNo = Convert.ToInt32(e.CommandArgument);

            if (rdr.HasRows)
            {
                rdr.Read();

                sMin = Convert.ToInt32(rdr["paket_smin"]);
                sMax = Convert.ToInt32(rdr["paket_smax"]);


                string sql2 = "Select urun.id, urun.ad, urun.image_path, urun.kategori, urun.siparis_aktif, urun.u_goster, urun.kapakSablon from urun where urun.kategori=@urunKat and urun.siparis_aktif=1 order by ad asc";
                SqlCommand ce = new SqlCommand(sql2, bag);
                ce.Parameters.AddWithValue("@urunKat", Convert.ToInt32(rdr["paket_urun"]));

                SqlDataReader re = ce.ExecuteReader();



                if (Convert.ToInt32(rdr["paket_fotoDiz"]) == 0)
                {
                    rptKapakNormal.DataSource = re;
                    rptKapakNormal.DataBind();
                    ScriptManager.RegisterStartupScript(this, GetType(), "kapakNormal", "moveTo('kapakNormal');", true);
                }

                else if (Convert.ToInt32(rdr["paket_fotoDiz"]) == 1)
                {
                    rptKapakYatay.DataSource = re;
                    rptKapakYatay.DataBind();
                    ScriptManager.RegisterStartupScript(this, GetType(), "kapakYatay", "moveTo('kapakYatay');", true);
                }

                else if (Convert.ToInt32(rdr["paket_fotoDiz"]) == 2)
                {
                    rptKapakDikey.DataSource = re;
                    rptKapakDikey.DataBind();
                    ScriptManager.RegisterStartupScript(this, GetType(), "kapakDikey", "moveTo('kapakDikey');", true);

                }
            }

            //paketler(Convert.ToInt32(e.CommandArgument));


            dosyaFormGizle();
        }
    }

    public string imageBigger(string imageName)
    {
        string newimageName = "";
        string[] imageN = imageName.Split('.');

        newimageName = imageN[0].ToString() + "_big." + imageN[1].ToString();


        return newimageName;
    }

    public string kapakDownload(int urunID)
    {
        string donus = "";

        connectionStr.DBIslem x = new connectionStr.DBIslem();
        SqlConnection bag = x.Baglanti();

        string sqlCat = "select id, ad, kapakSablon from urun where id=@urnID";

        SqlCommand y = new SqlCommand(sqlCat, bag);
        y.Parameters.AddWithValue("@urnID", urunID);

        SqlDataReader r = y.ExecuteReader();

        r.Read();

        if (!DBNull.Value.Equals(r["kapakSablon"]))
        {
            string duzelt = string.Format((string)(GetGlobalResourceObject("strings", "siparisKapakDlYazi")), r["ad"].ToString());

            donus = "<a href='http://www.mertalbum.com/mertKapaksbl.asp?kid=" + r["id"].ToString() + "' title='" + duzelt + " '><img src='/images/dl-icon.png' width='25' height='25' /></a>";
        }



        return donus;
    }

    public void kapakSec(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "kapakSec")
        {
            //pnlPaketler.Visible = true;

            //pnlCalisma.Visible = false;
            //pnlKapaklar.Visible = false;
            //pnlForm.Visible = false;

            //ScriptManager.RegisterStartupScript(this, GetType(), "outTime4444125", "fadeOUT('uplFormDis');", true);

            //hdnOlcu.Value = e.CommandArgument.ToString();

            //paketler(Convert.ToInt32(e.CommandArgument));

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = cstring.ConnStr();
                    con.Open();

                    using (SqlCommand c = new SqlCommand("Select id, ad, kapakZorunlu, ahsapZorunlu from urun where id=@id", con))
                    {
                        c.Parameters.AddWithValue("@id", Convert.ToInt32(e.CommandArgument));

                        using (SqlDataReader r = c.ExecuteReader())
                        {
                            if (r.HasRows)
                            {
                                r.Read();

                                zorunluKapak = Convert.ToInt32(r["kapakZorunlu"]);
                                zorunluAhsap = Convert.ToInt32(r["ahsapZorunlu"]);
                                kapakAdi = r["ad"].ToString();
                            }

                            else
                            {
                                zorunluAhsap = 0;
                                zorunluKapak = 0;
                                kapakAdi = "Model Bilinmiyor";
                            }

                        }
                    }
                }

            }
            catch (Exception)
            {
                zorunluAhsap = 0;
                zorunluKapak = 0;
                kapakAdi = "Model Bilinmiyor";
            }

            ahsap0.Checked = true;
            ahsap1.Checked = false;
            ahsap2.Checked = false;
            ahsap3.Checked = false;
            ahsap1.Enabled = false;
            ahsap2.Enabled = false;
            ahsap3.Enabled = false;


            secilenKapak = Convert.ToInt32(e.CommandArgument);

            pnlForm.Visible = true;
            siparisFormBilgileri();
            musteriForm.Visible = true;
            pnlSepet.Visible = false;

            ScriptManager.RegisterStartupScript(this, GetType(), "musteriFormSecimler", "moveTo('musteriFormSecimler');", true);

            dosyaFormGizle();
        }
    }

    public void siparisFormBilgileri()
    {
        // sayfa tipi çekim
        connectionStr.DBIslem x = new connectionStr.DBIslem();

        SqlConnection bag = x.Baglanti();

        SqlCommand cSayfaTipi = new SqlCommand("Select sayfatipi_id, sayfatipi_tur, paketsayfa_id, paketsayfa_paketid, paketsayfa_sayfatipi from sayfatipi, paketsayfa where paketsayfa.paketsayfa_paketid=@pktIDS and sayfatipi.sayfatipi_id=paketsayfa.paketsayfa_sayfatipi order by sayfatipi_id ASC", bag);
        cSayfaTipi.Parameters.AddWithValue("@pktIDS", paketNo);
        //SqlDataReader nesneni oluşturuyorum
        SqlDataReader rdrSayfaTipi;

        rdrSayfaTipi = cSayfaTipi.ExecuteReader();

        drpSayfaTipi.Items.Clear();

        drpSayfaTipi.DataSource = rdrSayfaTipi;
        drpSayfaTipi.DataTextField = "sayfatipi_tur";
        drpSayfaTipi.DataValueField = "sayfatipi_id";
        drpSayfaTipi.DataBind();
        //drpUlke.SelectedIndex = 215;
        rdrSayfaTipi.Close();
        cSayfaTipi.Dispose();

        drpYaprakSayisi.Items.Clear();

        // Ahşap Renkleri

        ahsap0.Text = (string)(GetGlobalResourceObject("strings", "siparisAhsap0"));
        ahsap1.Text = (string)(GetGlobalResourceObject("strings", "siparisAhsap1"));
        ahsap2.Text = (string)(GetGlobalResourceObject("strings", "siparisAhsap2"));
        ahsap3.Text = (string)(GetGlobalResourceObject("strings", "siparisAhsap3"));


        // Ahşap Renkleri bitiş

        // Kapak Zorunlu Sistem Başla

        if (zorunluKapak == 1)
        {
            regFormErrList.Text ="<p>" + string.Format(GetGlobalResourceObject("strings", "siparisformkapakzorunlu1").ToString(), kapakAdi) + "</p>";

            if (zorunluAhsap == 1)
            {
                regFormErrList.Text += "<p>" + string.Format(GetGlobalResourceObject("strings", "siparisformahsapzorunlu1").ToString(), kapakAdi) + "</p>";
                ahsap1.Enabled = true;
                ahsap2.Enabled = true;
                ahsap3.Enabled = true;
            }


            litHataTitle.Text = (string)(GetGlobalResourceObject("strings", "siparisformkapakzorunluTitle"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "openModal();", true);
        }

        // Kapak Zorunlu Sistem Bitiş


        for (int i = sMax; i >= sMin; i--)
        {
            drpYaprakSayisi.Items.Insert(0, new ListItem("Sayfa " + i, i.ToString()));
        }

        SqlCommand pKagitC = new SqlCommand("Select * from paket where paket_id=@paket_id", bag);
        pKagitC.Parameters.AddWithValue("@paket_id", paketNo);

        SqlDataReader rdrK = pKagitC.ExecuteReader();

        rdrK.Read();


        if (Convert.ToInt32(rdrK["paket_yarimat"]) == 1)
        {
            kagit1.Visible = true;
            kagit1.Text = (string)(GetGlobalResourceObject("strings", "siparisKagitMatYazi"));
            kagit1.Checked = true;
        }



        if (Convert.ToInt32(rdrK["paket_silk"]) == 1)
        {
            kagit2.Visible = true;
            kagit2.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKagitSilkYazi")), "<strong>" + rdrK["paket_silkYuzde"].ToString() + "</strong>");
        }

        if (Convert.ToInt32(rdrK["paket_sedef"]) == 1)
        {
            kagit3.Visible = true;
            kagit3.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKagitSedefYazi")), "<strong>" + rdrK["paket_sedefYuzde"].ToString() + "</strong>");
        }

        if (Convert.ToInt32(rdrK["paket_kristal"]) == 1)
        {
            kagit5.Visible = true;
            kagit5.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKagitKristalYazi")), "<strong>" + rdrK["paket_kristalYuzde"].ToString() + "</strong>");
        }

        if (Convert.ToInt32(rdrK["paket_metalik"]) == 1)
        {
            kagit6.Visible = true;
            kagit6.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKagitMetalikYazi")), "<strong>" + rdrK["paket_metalikYuzde"].ToString() + "</strong>");
        }

        if (Convert.ToInt32(rdrK["paket_prokristal"]) == 1)
        {
            kagit7.Visible = true;
            kagit7.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKagitProKristalYazi")), "<strong>" + rdrK["paket_prokristalYuzde"].ToString() + "</strong>");
        }

        if (Convert.ToInt32(rdrK["paket_mattprint"]) == 1)
        {
            kagit8.Visible = true;
            kagit8.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKagitXMattYazi")), "<strong>" + rdrK["paket_mattprintYuzde"].ToString() + "</strong>");
        }

        if (Convert.ToInt32(rdrK["paket_fart270gbrightwhite"]) == 1)
        {
            kagit9.Visible = true;
            kagit9.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKagitfart270gbrightwhite")), "<strong>" + rdrK["paket_fart270gbrightwhiteYuzde"].ToString() + "</strong>");
        }

        if (Convert.ToInt32(rdrK["paket_fartsatin270gbrightwhite"]) == 1)
        {
            kagit10.Visible = true;
            kagit10.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKagitfartsatin270gbrightwhite")), "<strong>" + rdrK["paket_fartsatin270gbirhgtwhiteYuzde"].ToString() + "</strong>");
        }

        if (Convert.ToInt32(rdrK["paket_fartradiant270gwhite"]) == 1)
        {
            kagit11.Visible = true;
            kagit11.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKagitfartradiant270gwhite")), "<strong>" + rdrK["paket_fartradiant270gwhiteYuzde"].ToString() + "</strong>");
        }

        if (Convert.ToInt32(rdrK["paket_farttoscana210gnaturalwhite"]) == 1)
        {
            kagit12.Visible = true;
            kagit12.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKagitfarttoscana210gnaturalwhite")), "<strong>" + rdrK["paket_farttoscana210gnaturalwhiteYuzde"].ToString() + "</strong>");
        }

        if (Convert.ToInt32(rdrK["paket_fartwatercolour240gnaturalwhite"]) == 1)
        {
            kagit13.Visible = true;
            kagit13.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKagitfartwatercolour240gnaturalwhite")), "<strong>" + rdrK["paket_fartwatercolour240gnaturalwhiteYuzde"].ToString() + "</strong>");
        }

        if (Convert.ToInt32(rdrK["paket_fartwhitevelvet270gwhite"]) == 1)
        {
            kagit14.Visible = true;
            kagit14.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKagitfartwhitevelvet270gwhite")), "<strong>" + rdrK["paket_fartwhitevelvet270gwhiteYuzde"].ToString() + "</strong>");
        }

        if (Convert.ToInt32(rdrK["paket_softtouch"]) == 1)
        {
            kagit15.Visible = true;
            kagit15.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKagitsofttouch")), "<strong>" + rdrK["paket_softtouchYuzde"].ToString() + "</strong>");
        }

        if (Convert.ToInt32(rdrK["paket_kristalbedava"]) == 1)
        {
            kagit16.Visible = true;
            kagit16.Text = (string)(GetGlobalResourceObject("strings", "siparisKagitKristalBedavaYazi"));
            kagit16.Checked = true;
        }




        pnlSepet.Visible = false;

        cantalar();
        saatler();
        aileler();
        cepler();
        buyukler();

        dosyaFormGizle();

    }

    public void cantalar()
    {
        connectionStr.DBIslem x = new connectionStr.DBIslem();

        SqlConnection bag = x.Baglanti();

        // rdnRadioCanta.DataSource = null;
        //rdnRadioCanta.DataBind();

        //rdnRadioCanta.Items.Clear();

        string sqlCanta = "Select paketextraalt.paketextraalt_id, paketextraalt_paket, paketextraalt_iliski, paketextra.paketextra_id, paketextra.paketextra_adi, paketextra.paketextra_image, paketextra.paketextra_fiyat, paketextra.paketextra_form, paketextra.paketextra_grup, paketextra.paketextra_sira,  paketextra.paketextra_aciklama, paketextra.paketextra_active from paketextraalt, paketextra where paketextraalt.paketextraalt_paket=@pktID and paketextra.paketextra_id=paketextraalt_iliski and paketextra.paketextra_active=1 and paketextra_grup=2 order by paketextra.paketextra_sira ASC";

        SqlCommand cCanta = new SqlCommand(sqlCanta, bag);
        cCanta.Parameters.AddWithValue("@pktID", paketNo);

        SqlDataReader rdrCanta = cCanta.ExecuteReader();

        if (rdrCanta.HasRows)
        {

            rptCantalar.DataSource = rdrCanta;
            rptCantalar.DataBind();
        }

        else
        {
            //cantaSec.Visible = false;
            //cantaSec2.Visible = false;
        }

        pnlSepet.Visible = false;

        rdrCanta.Close();
        cCanta.Dispose();

        // çantalar bitiş !
    }

    public void cantaSec(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "cantaEkle")
        {

            cantalar();

            secilenCanta = Convert.ToInt32(e.CommandArgument);

            foreach (RepeaterItem item in rptCantalar.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton lb = (LinkButton)item.FindControl("linkBtnCantaEkle");

                    if (Convert.ToInt32(lb.CommandArgument) == secilenCanta)
                    {
                        lb.Text = (string)(GetGlobalResourceObject("strings", "siparisCikartBtnGenel"));
                        lb.CssClass = "text-danger";
                        lb.CommandName = "cantaCikart";
                    }

                }
            }

        }

        else if (e.CommandName == "cantaCikart")
        {
            secilenCanta = 16;
            cantalar();
        }

        dosyaFormGizle();

    }

    public void saatler()
    {
        connectionStr.DBIslem x = new connectionStr.DBIslem();

        SqlConnection bag = x.Baglanti();

        // rdnRadioCanta.DataSource = null;
        //rdnRadioCanta.DataBind();

        //rdnRadioCanta.Items.Clear();

        string sqlSaat = "Select paketextraalt.paketextraalt_id, paketextraalt_paket, paketextraalt_iliski, paketextra.paketextra_id, paketextra.paketextra_adi, paketextra.paketextra_image, paketextra.paketextra_fiyat, paketextra.paketextra_form, paketextra.paketextra_grup, paketextra.paketextra_sira,  paketextra.paketextra_aciklama, paketextra.paketextra_active from paketextraalt, paketextra where paketextraalt.paketextraalt_paket=@pktID and paketextra.paketextra_id=paketextraalt_iliski and paketextra.paketextra_active=1 and paketextra_grup=3 order by paketextra.paketextra_sira ASC";

        SqlCommand cSaat = new SqlCommand(sqlSaat, bag);
        cSaat.Parameters.AddWithValue("@pktID", paketNo);

        SqlDataReader rdrSaat = cSaat.ExecuteReader();

        if (rdrSaat.HasRows)
        {

            rptSaatler.DataSource = rdrSaat;
            rptSaatler.DataBind();
        }

        else
        {
            //cantaSec.Visible = false;
            //cantaSec2.Visible = false;
        }

        pnlSepet.Visible = false;

        rdrSaat.Close();
        cSaat.Dispose();

        // çantalar bitiş !
    }

    public void saatSec(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "saatEkle")
        {

            saatler();

            secilenSaat = Convert.ToInt32(e.CommandArgument);

            foreach (RepeaterItem item in rptSaatler.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton lb = (LinkButton)item.FindControl("linkBtnSaatEkle");

                    if (Convert.ToInt32(lb.CommandArgument) == secilenSaat)
                    {
                        lb.Text = (string)(GetGlobalResourceObject("strings", "siparisCikartBtnGenel"));
                        lb.CssClass = "text-danger";
                        lb.CommandName = "saatCikart";
                    }

                }
            }

        }

        else if (e.CommandName == "saatCikart")
        {
            secilenSaat = 17;
            saatler();
        }

        dosyaFormGizle();

    }


    public void aileler()
    {
        connectionStr.DBIslem x = new connectionStr.DBIslem();

        SqlConnection bag = x.Baglanti();

        // rdnRadioCanta.DataSource = null;
        //rdnRadioCanta.DataBind();

        //rdnRadioCanta.Items.Clear();

        string sqlSaat = "Select paketextraalt.paketextraalt_id, paketextraalt_paket, paketextraalt_iliski, paketextra.paketextra_id, paketextra.paketextra_adi, paketextra.paketextra_image, paketextra.paketextra_fiyat, paketextra.paketextra_form, paketextra.paketextra_grup, paketextra.paketextra_sira,  paketextra.paketextra_aciklama, paketextra.paketextra_active from paketextraalt, paketextra where paketextraalt.paketextraalt_paket=@pktID and paketextra.paketextra_id=paketextraalt_iliski and paketextra.paketextra_active=1 and paketextra_grup=6 order by paketextra.paketextra_sira ASC";

        SqlCommand cAile = new SqlCommand(sqlSaat, bag);
        cAile.Parameters.AddWithValue("@pktID", paketNo);

        SqlDataReader rdrAile = cAile.ExecuteReader();

        if (rdrAile.HasRows)
        {

            rptAile.DataSource = rdrAile;
            rptAile.DataBind();
        }

        else
        {
            //cantaSec.Visible = false;
            //cantaSec2.Visible = false;
        }

        pnlSepet.Visible = false;

        rdrAile.Close();
        cAile.Dispose();

        // çantalar bitiş !
    }

    public void aileSec(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "aileEkle")
        {

            aileler();

            secilenAile = Convert.ToInt32(e.CommandArgument);

            foreach (RepeaterItem item in rptAile.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton lb = (LinkButton)item.FindControl("linkBtnAileEkle");

                    if (Convert.ToInt32(lb.CommandArgument) == secilenAile)
                    {
                        lb.Text = (string)(GetGlobalResourceObject("strings", "siparisCikartBtnGenel"));
                        lb.CssClass = "text-danger";
                        lb.CommandName = "aileCikart";
                    }

                }
            }

        }

        else if (e.CommandName == "aileCikart")
        {
            secilenSaat = 36;
            aileler();
        }

        dosyaFormGizle();

    }

    public void cepler()
    {
        connectionStr.DBIslem x = new connectionStr.DBIslem();

        SqlConnection bag = x.Baglanti();

        string sqlCep = "Select paketextraalt.paketextraalt_id, paketextraalt_paket, paketextraalt_iliski, paketextra.paketextra_id, paketextra.paketextra_adi, paketextra.paketextra_image, paketextra.paketextra_fiyat, paketextra.paketextra_form, paketextra.paketextra_grup, paketextra.paketextra_sira,  paketextra.paketextra_aciklama, paketextra.paketextra_active from paketextraalt, paketextra where paketextraalt.paketextraalt_paket=@pktID and paketextra.paketextra_id=paketextraalt_iliski and paketextra.paketextra_active=1 and paketextra_grup=5 order by paketextra.paketextra_sira ASC";

        SqlCommand cCep = new SqlCommand(sqlCep, bag);
        cCep.Parameters.AddWithValue("@pktID", paketNo);

        SqlDataReader rdrCep = cCep.ExecuteReader();

        if (rdrCep.HasRows)
        {

            rptCep.DataSource = rdrCep;
            rptCep.DataBind();
        }

        else
        {

        }

        pnlSepet.Visible = false;

        rdrCep.Close();
        cCep.Dispose();

        // cepler bitiş !
    }

    public void cepSec(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "cepEkle")
        {

            cepler();

            secilenCep = Convert.ToInt32(e.CommandArgument);

            foreach (RepeaterItem item in rptCep.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton lb = (LinkButton)item.FindControl("linkBtnCepEkle");

                    if (Convert.ToInt32(lb.CommandArgument) == secilenCep)
                    {
                        lb.Text = (string)(GetGlobalResourceObject("strings", "siparisCikartBtnGenel"));
                        lb.CssClass = "text-danger";
                        lb.CommandName = "cepCikart";
                    }

                }
            }

        }

        else if (e.CommandName == "cepCikart")
        {
            secilenCep = 22;
            cepler();
        }

        dosyaFormGizle();

    }

    public void buyukler()
    {
        connectionStr.DBIslem x = new connectionStr.DBIslem();

        SqlConnection bag = x.Baglanti();

        string sqlBuyuk = "Select paketextraalt.paketextraalt_id, paketextraalt_paket, paketextraalt_iliski, paketextra.paketextra_id, paketextra.paketextra_adi, paketextra.paketextra_image, paketextra.paketextra_fiyat, paketextra.paketextra_form, paketextra.paketextra_grup, paketextra.paketextra_sira,  paketextra.paketextra_aciklama, paketextra.paketextra_active from paketextraalt, paketextra where paketextraalt.paketextraalt_paket=@pktID and paketextra.paketextra_id=paketextraalt_iliski and paketextra.paketextra_active=1 and paketextra_grup=4 order by paketextra.paketextra_sira ASC";

        SqlCommand cBuyuk = new SqlCommand(sqlBuyuk, bag);
        cBuyuk.Parameters.AddWithValue("@pktID", paketNo);

        SqlDataReader rdrBuyuk = cBuyuk.ExecuteReader();

        if (rdrBuyuk.HasRows)
        {

            rptBuyuk.DataSource = rdrBuyuk;
            rptBuyuk.DataBind();
        }

        else
        {

        }

        pnlSepet.Visible = false;

        rdrBuyuk.Close();
        cBuyuk.Dispose();

        // Buyuk bitiş !
    }

    public void buyukSec(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "buyukEkle")
        {

            buyukler();

            secilenBuyuk = Convert.ToInt32(e.CommandArgument);

            foreach (RepeaterItem item in rptBuyuk.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton lb = (LinkButton)item.FindControl("linkBtnBuyukEkle");

                    if (Convert.ToInt32(lb.CommandArgument) == secilenBuyuk)
                    {
                        lb.Text = (string)(GetGlobalResourceObject("strings", "siparisCikartBtnGenel"));
                        lb.CssClass = "text-danger";
                        lb.CommandName = "buyukCikart";
                    }

                }
            }

        }

        else if (e.CommandName == "buyukCikart")
        {
            secilenBuyuk = 21;
            buyukler();
        }

        dosyaFormGizle();

    }




    protected void btnFormuGonder_Click(object sender, EventArgs e)
    {

        string registerErr = "";

        Session["siparis"] = null;
        Session["siparisBilgiler"] = null;
        Session["siparisBuyukEbatYazi"] = null;
        Session["siparisKapakYazi"] = null;
        Session["siparisMusteriNot"] = null;


        dosyaFormGizle();

        if (string.IsNullOrEmpty(txtBuyukEbat.Text))
        {
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "siparisBuyukEbatYaziEksik")) + "</p>";
        }

        if (zorunluKapak == 1 && string.IsNullOrEmpty(txtKapakYazisi.Text))
        {
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "siparisKapakYaziEksik")) + "</p>";           
        }

        if (zorunluAhsap == 1 && ahsap0.Checked)
        {
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "sipAhsapRenkEksik")) + "</p>";
        }



        if (calisma1.Checked || calisma2.Checked)
        {

        }

        else
        {
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "siparisCalismaSekliSecilmemis")) + "</p>";
        }

        //if (kagit1.Checked || kagit2.Checked || kagit3.Checked || kagit5.Checked || kagit6.Checked || kagit7.Checked || kagit8.Checked || kagit9.Checked || kagit10.Checked || kagit11.Checked || kagit12.Checked || kagit13.Checked || kagit14.Checked || kagit15.Checked )
        //{

        //}

        //else
        //{
        //    registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "siparisKagitSecilmedi")) + "</p>";
        //}


        if (registerErr.Length > 0) // herhangi bir hata var mı ?
        {
            regFormErrList.Text = registerErr;
            litHataTitle.Text = (string)(GetGlobalResourceObject("strings", "regFormErrorTitle"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "openModal();", true);

            ScriptManager.RegisterStartupScript(this, GetType(), "musteriFormSecimler2err", "moveTo('musteriFormSecimler');", true);
        }

        else
        {


            try
            {




                connectionStr.DBIslem x = new connectionStr.DBIslem();

                SqlConnection bag = x.Baglanti();

                string sqlPkt = "Select paket_id, paket_languageStr from paket where paket_id=@paket_id";

                SqlCommand cPaket = new SqlCommand(sqlPkt, bag);
                cPaket.Parameters.AddWithValue("@paket_id", paketNo);

                SqlDataReader rdrPaket = cPaket.ExecuteReader();

                rdrPaket.Read();

                // Ahşap başla

                int secilenAhsap = 0;

                if (ahsap0.Checked)
                {
                    secilenAhsap = 0;
                }

                else if (ahsap1.Checked)
                {
                    secilenAhsap = 1;
                }

                else if (ahsap2.Checked)
                {
                    secilenAhsap = 2;
                }

                else if (ahsap3.Checked)
                {
                    secilenAhsap = 3;
                }

                else
                {
                    secilenAhsap = 0;
                }

                // Ahşap bitiş


                double genelToplam = 0;
                double genelToplamTam = 0;
                double genelToplamIskonto = 0;

                double calismaFiyat = 0;
                double extraSayfaFiyat = 0;
                int extraSayfa = 0;

                double paketFiyat = Convert.ToDouble(fiyatlar.fiyatBul.paketFiyat(Convert.ToInt32(paketNo), Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                double paketFiyatTam = Convert.ToDouble(fiyatlar.fiyatBul.paketFiyat(Convert.ToInt32(paketNo), Convert.ToInt32(musteriID), paraBirimi.ToString(), 22));
                double paketFiyatIskonto = paketFiyatTam - paketFiyat;

                double saatFiyat = 0;
                double saatFiyatTam = 0;
                double saatFiyatIskonto = 0;

                double kutuFiyat = 0;
                double kutuFiyatTam = 0;
                double kutuFiyatIskonto = 0;

                double aileFiyat = 0;
                double aileFiyatTam = 0;
                double aileFiyatIskonto = 0;

                double cepFiyat = 0;
                double cepFiyatTam = 0;
                double cepFiyatIskonto = 0;

                double buyukFiyat = 0;
                double buyukFiyatTam = 0;
                double buyukFiyatIskonto = 0;

                double calismaliFiyat = 0;
                double calismaliFiyatTam = 0;
                double calismaliFiyatIskonto = 0;

                double yaprakFiyat = 0;
                double yaprakFiyatTam = 0;
                double yaprakFiyatIskonto = 0;

                double kagitFiyat = 0;
                double kagitFiyatTam = 0;
                double kagitFiyatIskonto = 0;

                int calismaTyp = 1;

                //Session["toplamFiyat"] = genelToplam + "$" + genelToplamTam + "$" + genelToplamIskonto;
                //Session["calismaliFiyat"] = calismaliFiyat + "$" + calismaliFiyatTam + "$" + calismaliFiyatIskonto;
                //Session["paketFiyati"] = paketFiyat + "$" + paketFiyatTam + "$" + paketFiyatIskonto;
                //Session["saatFiyati"] = saatFiyat + "$" + saatFiyatTam + "$" + saatFiyatIskonto;
                //Session["kutuFiyat"] = kutuFiyat + "$" + kutuFiyatTam + "$" + kutuFiyatIskonto;
                //Session["aileFiyat"] = aileFiyat + "$" + aileFiyatTam + "$" + aileFiyatIskonto;
                //Session["cepFiyat"] = cepFiyat + "$" + cepFiyatTam + "$" + cepFiyatIskonto;
                //Session["buyukFiyat"] = cepFiyat + "$" + buyukFiyatTam + "$" + buyukFiyatIskonto;
                //Session["yaprakFiyat"] = yaprakFiyat + "$" + yaprakFiyatTam + "$" + yaprakFiyatIskonto;







                bool extraYaprak = false;

                genelToplam += paketFiyat;
                genelToplamTam += paketFiyatTam;





                int extraYaprakSayi = 0;







                lblOzetPaketAdi.Text = "<strong>" + (string)GetGlobalResourceObject("strings", rdrPaket["paket_languageStr"].ToString()) + "</strong>";

                paketAlt.paketAlt y = new paketAlt.paketAlt();

                lblOzetPaketAdi.Text += y.paketAltDon(paketNo, 1);

                lblOzetPaketFiyati.Text = fiyatlar.fiyatBul.paketFiyat(Convert.ToInt32(paketNo), Convert.ToInt32(musteriID), paraBirimi.ToString(), 1);


                // yaprak sayısı hesapları
                yaprakSayisiOzet.Visible = true;

                if (sMin == Convert.ToInt32(drpYaprakSayisi.SelectedValue))
                {

                    lblOzetYaprakSayisi.Text = "<strong>" + drpYaprakSayisi.SelectedValue.ToString() + "</strong>";
                    lblOzetYaprakSayisiFiyat.Text = "<strong class='text-info'>0,00 " + paraBirimi + "</strong>";
                }

                else if (sMin < Convert.ToInt32(drpYaprakSayisi.SelectedValue))
                {
                    extraYaprak = true;
                    extraSayfa = Convert.ToInt32(drpYaprakSayisi.SelectedValue) - sMin;
                    extraSayfaFiyat = paketFiyat / 100 * (extraSayfa * fiyatlar.fiyatBul.sayfaFiyat(paketNo, musteriID));
                    yaprakFiyat = extraSayfaFiyat;
                    yaprakFiyatTam = paketFiyat / 100 * (extraSayfa * fiyatlar.fiyatBul.sayfaFiyatTam(paketNo));
                    yaprakFiyatIskonto = yaprakFiyatTam - yaprakFiyat;
                    lblOzetYaprakSayisi.Text = "<strong>" + drpYaprakSayisi.SelectedValue.ToString() + "</strong>";
                    lblOzetYaprakSayisiFiyat.Text = "<strong class='text-info'>" + extraSayfaFiyat.ToString("N") + " " + paraBirimi + "</strong>";

                    genelToplam += extraSayfaFiyat;
                    genelToplamTam += yaprakFiyatTam;

                }

                // yaprak sayısı hesapları

                string saatxmladi = "";

                if (secilenSaat != 17)
                {
                    saatOzet.Visible = true;
                    lblOzetSaatAdi.Text = y.extraAdiDon(secilenSaat);
                    saatxmladi = lblOzetSaatAdi.Text;
                    lblOzetSaatFiyat.Text = fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenSaat, Convert.ToInt32(musteriID), paraBirimi.ToString(), 1);

                    saatFiyat = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenSaat, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                    saatFiyatTam = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenSaat, Convert.ToInt32(musteriID), paraBirimi.ToString(), 22));
                    saatFiyatIskonto = saatFiyatTam - saatFiyat;

                    genelToplam += Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenSaat, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                    genelToplamTam += saatFiyatTam;

                }

                else
                {
                    saatxmladi = "Saat Seçilmemiş";
                    saatOzet.Visible = false;
                }

                string cantaxmladi = "";


                if (secilenCanta != 16)
                {
                    cantaOzet.Visible = true;
                    lblOzetCantaAdi.Text = y.extraAdiDon(secilenCanta);
                    cantaxmladi = lblOzetCantaAdi.Text;
                    lblOzetCantaFiyat.Text = fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCanta, Convert.ToInt32(musteriID), paraBirimi.ToString(), 1);


                    kutuFiyat = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCanta, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                    kutuFiyatTam = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCanta, Convert.ToInt32(musteriID), paraBirimi.ToString(), 22));
                    kutuFiyatIskonto = kutuFiyatTam - kutuFiyat;

                    genelToplam += Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCanta, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                    genelToplamTam += kutuFiyatTam;


                }

                else
                {
                    cantaxmladi = "Çanta Seçilmemiş";
                    cantaOzet.Visible = false;
                }

                string ailexmladi = "";

                if (secilenAile != 36)
                {
                    aileOzet.Visible = true;
                    lblOzetAileAdi.Text = y.extraAdiDon(secilenAile);
                    ailexmladi = lblOzetAileAdi.Text;

                    if (extraYaprak == true)
                    {
                        double extraYapAile = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenAile, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2)) / 100 * (extraSayfa * fiyatlar.fiyatBul.sayfaFiyat(paketNo, musteriID));
                        lblOzetAileFiyat.Text = fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenAile, Convert.ToInt32(musteriID), paraBirimi.ToString(), 1) + "<strong class='text-warning'> + </strong><strong class='text-danger'>" + extraYapAile.ToString("N") + " " + paraBirimi.ToString() + "</strong>";
                        lblOzetAileAdi.Text += "</br><span class='text-danger'>" + (string)(GetGlobalResourceObject("strings", "siparisEkstraYaprakFiyatlandirma")) + "</span>";

                        aileFiyat = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenAile, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2)) / 100 * (extraSayfa * fiyatlar.fiyatBul.sayfaFiyat(paketNo, musteriID)) + Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenAile, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                        aileFiyatTam = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenAile, Convert.ToInt32(musteriID), paraBirimi.ToString(), 22)) / 100 * (extraSayfa * fiyatlar.fiyatBul.sayfaFiyatTam(paketNo)) + Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenAile, Convert.ToInt32(musteriID), paraBirimi.ToString(), 22));
                        aileFiyatIskonto = aileFiyatTam - aileFiyat;


                        genelToplam += Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenAile, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2)) + extraYapAile;
                        genelToplamTam += aileFiyatTam;

                    }
                    else
                    {
                        lblOzetAileFiyat.Text = fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenAile, Convert.ToInt32(musteriID), paraBirimi.ToString(), 1);

                        aileFiyat = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenAile, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                        aileFiyatTam = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenAile, Convert.ToInt32(musteriID), paraBirimi.ToString(), 22));
                        aileFiyatIskonto = aileFiyatTam - aileFiyat;


                        genelToplam += Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenAile, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                        genelToplamTam += aileFiyatTam;

                    }

                }

                else
                {
                    ailexmladi = "Aile Seçilmemiş";
                    aileOzet.Visible = false;
                }

                string cepxmladi = "";

                if (secilenCep != 22)
                {
                    cepOzet.Visible = true;
                    lblOzetCepAdi.Text = y.extraAdiDon(secilenCep);
                    cepxmladi = lblOzetCepAdi.Text;
                    if (extraYaprak == true)
                    {
                        double extraCep = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCep, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2)) / 100 * (extraSayfa * fiyatlar.fiyatBul.sayfaFiyat(paketNo, musteriID));
                        lblOzetCepFiyat.Text = fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCep, Convert.ToInt32(musteriID), paraBirimi.ToString(), 1) + "<strong class='text-warning'> + </strong><strong class='text-danger'>" + extraCep.ToString("N") + " " + paraBirimi.ToString() + "</strong>";
                        lblOzetCepAdi.Text += "</br><span class='text-danger'>" + (string)(GetGlobalResourceObject("strings", "siparisEkstraYaprakFiyatlandirma")) + "</span>";

                        cepFiyat = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCep, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2)) / 100 * (extraSayfa * fiyatlar.fiyatBul.sayfaFiyat(paketNo, musteriID)) + Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCep, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                        cepFiyatTam = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCep, Convert.ToInt32(musteriID), paraBirimi.ToString(), 22)) / 100 * (extraSayfa * fiyatlar.fiyatBul.sayfaFiyatTam(paketNo)) + Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCep, Convert.ToInt32(musteriID), paraBirimi.ToString(), 22));
                        cepFiyatIskonto = cepFiyatTam - cepFiyat;


                        genelToplam += Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCep, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2)) + extraCep;
                        genelToplamTam += cepFiyatTam;
                    }
                    else
                    {
                        lblOzetCepFiyat.Text = fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCep, Convert.ToInt32(musteriID), paraBirimi.ToString(), 1);

                        cepFiyat = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCep, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                        cepFiyatTam = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCep, Convert.ToInt32(musteriID), paraBirimi.ToString(), 22));
                        cepFiyatIskonto = cepFiyatTam - cepFiyat;


                        genelToplam += Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCep, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                        genelToplam += cepFiyatTam;
                    }


                }

                else
                {
                    cepxmladi = "Cep Seçilmemiş";
                    cepOzet.Visible = false;
                }

                string buyukxmladi = "";

                if (secilenBuyuk != 21)
                {
                    buyukOzet.Visible = true;
                    lblOzetBuyukAdi.Text = y.extraAdiDon(secilenBuyuk);
                    buyukxmladi = lblOzetBuyukAdi.Text;
                    lblOzetBuyukFiyat.Text = fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenBuyuk, Convert.ToInt32(musteriID), paraBirimi.ToString(), 1);

                    buyukFiyat = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenBuyuk, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                    buyukFiyatTam = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenBuyuk, Convert.ToInt32(musteriID), paraBirimi.ToString(), 22));
                    buyukFiyatIskonto = buyukFiyatTam - buyukFiyat;


                    genelToplam += Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenBuyuk, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                    genelToplamTam += buyukFiyatTam;
                }

                else
                {
                    buyukxmladi = "Büyük Ebat Seçilmemiş";
                    buyukOzet.Visible = false;
                }

                string calismaxmladi = "";

                if (calisma1.Checked)
                {
                    calismaOzet.Visible = true;
                    lblOzetCalismaAdi.Text = (string)GetGlobalResourceObject("strings", "siparisCalismaSekliSecim1").ToString();
                    calismaxmladi = lblOzetCalismaAdi.Text;
                    lblOzetCalismaFiyat.Text = "<strong class='text-info'>0,00 " + paraBirimi + "</strong>";

                    calismaTyp = 1;
                }
                else if (calisma2.Checked)
                {
                    calismaTyp = 2;


                    if (sMin == Convert.ToInt32(drpYaprakSayisi.SelectedValue))
                    {
                        if (sMin == 5)
                        {
                            calismaFiyat = fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 5, 1);

                            calismaliFiyat = fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 5, 1);
                            calismaliFiyatTam = fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 5, 2);
                            calismaliFiyatIskonto = calismaliFiyatTam - calismaliFiyat;
                        }

                        else if (sMin == 10)
                        {
                            calismaFiyat = fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 10, 1);

                            calismaliFiyat = fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 10, 1);
                            calismaliFiyatTam = fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 10, 2);
                            calismaliFiyatIskonto = calismaliFiyatTam - calismaliFiyat;

                        }
                    }

                    else if (sMin < Convert.ToInt32(drpYaprakSayisi.SelectedValue))
                    {
                        extraYaprakSayi = Convert.ToInt32(drpYaprakSayisi.SelectedValue) - sMin;

                        if (sMin == 5)
                        {
                            calismaFiyat = fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 5, 1) + (extraYaprakSayi * fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 1, 1));

                            calismaliFiyat = fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 5, 1) + (extraYaprakSayi * fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 1, 1));
                            calismaliFiyatTam = fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 5, 2) + (extraYaprakSayi * fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 1, 2));
                            calismaliFiyatIskonto = calismaliFiyatTam - calismaliFiyat;

                        }

                        else if (sMin == 10)
                        {
                            calismaFiyat = fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 10, 1) + (extraYaprakSayi * fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 1, 1));

                            calismaliFiyat = fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 10, 1) + (extraYaprakSayi * fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 1, 1));
                            calismaliFiyatTam = fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 10, 2) + (extraYaprakSayi * fiyatlar.fiyatBul.calismaUCR(paketNo, musteriID, seciliBolge, 1, 2));
                            calismaliFiyatIskonto = calismaliFiyatTam - calismaliFiyat;

                        }
                    }

                    genelToplam += calismaFiyat;
                    genelToplamTam += calismaliFiyatTam;

                    calismaOzet.Visible = true;
                    lblOzetCalismaAdi.Text = (string)GetGlobalResourceObject("strings", "siparisCalismaSekliSecim2").ToString();
                    calismaxmladi = lblOzetCalismaAdi.Text;
                    lblOzetCalismaFiyat.Text = "<strong class='text-info'>" + calismaFiyat.ToString("N") + " " + paraBirimi + " </strong>";
                }



                sayfaTipiOzet.Visible = true;

                lblOzetSayfaTipi.Text = y.sayfaTipiDon(Convert.ToInt32(drpSayfaTipi.SelectedValue));
                lblOzetSayfaTipiFiyat.Text = "<strong class='text-info'>0,00 " + paraBirimi + "</strong>";


                secilenKapakModeli.Visible = true;

                string[] urunL = paketAlt.paketAlt.kapakModelAdi(secilenKapak).Split('$');

                string kapakxmladi = urunL[0];
                string kapakfotoxmlkucuk = urunL[1];
                string kapakfotoxmlbuyuk = imageBigger(urunL[1]);

                lblKapakModelAdi.Text = "<a class='gallery-images' rel='fancybox1' href='http://www.mertalbum.com/urunler/" + imageBigger(urunL[1]).ToString() + "'><img src='http://www.mertalbum.com/urunler/" + urunL[1] + "'>" + urunL[0] + "</a>";


                lblKapakModelFiyat.Text = "<strong class='text-info'>0,00 " + paraBirimi + "</strong>";

                buyukEbatYazisi.Visible = true;
                kapakYazisi.Visible = true;
                musteriNotu.Visible = true;
                //siparisBuyukEbatlariniz

                double kagitYuzdesi = 0;
                double kagitYuzdesiTam = 0;

                string kagitxmlyazisi = "";

                if (kagit1.Checked)
                {
                    kagitYuzdesi = 0;
                    kagitYuzdesiTam = 0;
                    kagitFiyat = 0;
                    kagitFiyatTam = 0;
                    kagitFiyatIskonto = 0;
                    secilenKagit = 1;
                    lblKagitYazi.Text = (string)GetGlobalResourceObject("strings", "siparisKagitMatYazi");
                    kagitxmlyazisi = (string)GetGlobalResourceObject("strings", "siparisKagitMatYazi");
                }

                else if (kagit16.Checked)
                {
                    kagitYuzdesi = 0;
                    kagitYuzdesiTam = 0;
                    kagitFiyat = 0;
                    kagitFiyatTam = 0;
                    kagitFiyatIskonto = 0;
                    secilenKagit = 16;
                    lblKagitYazi.Text = (string)GetGlobalResourceObject("strings", "siparisKagitKristalBedavaYazi");
                }

                else if (kagit2.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 2, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 2, 2);
                    secilenKagit = 2;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitSilkYazi"), kagitYuzdesi);
                    kagitxmlyazisi = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitSilkYazi"), kagitYuzdesi);
                }

                else if (kagit3.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 3, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 3, 2);
                    secilenKagit = 3;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitSedefYazi"), kagitYuzdesi);
                    kagitxmlyazisi = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitSedefYazi"), kagitYuzdesi);
                }

                else if (kagit5.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 5, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 5, 2);
                    secilenKagit = 5;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitKristalYazi"), kagitYuzdesi);
                    kagitxmlyazisi = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitKristalYazi"), kagitYuzdesi);
                }

                else if (kagit6.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 6, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 6, 2);
                    secilenKagit = 6;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitMetalikYazi"), kagitYuzdesi);
                    kagitxmlyazisi = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitMetalikYazi"), kagitYuzdesi);
                }

                else if (kagit7.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 7, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 7, 2);
                    secilenKagit = 7;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitProKristalYazi"), kagitYuzdesi);
                    kagitxmlyazisi = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitProKristalYazi"), kagitYuzdesi);
                }

                else if (kagit8.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 8, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 8, 2);
                    secilenKagit = 8;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitXMattYazi"), kagitYuzdesi);
                    kagitxmlyazisi = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitXMattYazi"), kagitYuzdesi);
                }

                else if (kagit9.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 9, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 9, 2);
                    secilenKagit = 9;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfart270gbrightwhite"), kagitYuzdesi);
                    kagitxmlyazisi = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfart270gbrightwhite"), kagitYuzdesi);
                }

                else if (kagit10.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 10, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 10, 2);
                    secilenKagit = 10;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartsatin270gbrightwhite"), kagitYuzdesi);
                    kagitxmlyazisi = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartsatin270gbrightwhite"), kagitYuzdesi);
                }

                else if (kagit11.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 11, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 11, 2);
                    secilenKagit = 11;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartradiant270gwhite"), kagitYuzdesi);
                    kagitxmlyazisi = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartradiant270gwhite"), kagitYuzdesi);
                }

                else if (kagit12.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 12, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 12, 2);
                    secilenKagit = 12;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfarttoscana210gnaturalwhite"), kagitYuzdesi);
                    kagitxmlyazisi = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfarttoscana210gnaturalwhite"), kagitYuzdesi);
                }

                else if (kagit13.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 13, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 13, 2);
                    secilenKagit = 13;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartwatercolour240gnaturalwhite"), kagitYuzdesi);
                    kagitxmlyazisi = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartwatercolour240gnaturalwhite"), kagitYuzdesi);
                }

                else if (kagit14.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 14, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 14, 2);
                    secilenKagit = 14;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartwhitevelvet270gwhite"), kagitYuzdesi);
                    kagitxmlyazisi = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartwhitevelvet270gwhite"), kagitYuzdesi);
                }

                else if (kagit15.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 15, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 15, 2);
                    secilenKagit = 15;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitsofttouch"), kagitYuzdesi);
                    kagitxmlyazisi = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitsofttouch"), kagitYuzdesi);
                }



                kagitFiyat = (paketFiyat + aileFiyat + cepFiyat + yaprakFiyat) / 100 * kagitYuzdesi;
                kagitFiyatTam = (paketFiyatTam + aileFiyatTam + cepFiyatTam + yaprakFiyatTam) / 100 * kagitYuzdesiTam;
                kagitFiyatIskonto = kagitFiyatTam - kagitFiyat;

                genelToplam += kagitFiyat;
                genelToplamTam += kagitFiyatTam;

                //lblKagitYazi.Text += kagitFiyat.ToString();

                lblBuyukEbatYazisi.Text = "<strong>" + (string)GetGlobalResourceObject("strings", "siparisBuyukEbatlariniz").ToString() + "</strong>" + txtBuyukEbat.Text;
                lblkapakYazisi.Text = "<strong>" + (string)GetGlobalResourceObject("strings", "siparisKapakYaziniz").ToString() + "</strong>" + txtKapakYazisi.Text;
                lblmusteriNotu.Text = "<strong>" + (string)GetGlobalResourceObject("strings", "siparisMusteriNotunuz").ToString() + "</strong>" + txtMusteriNotu.Text;


                calismaGenelToplam.Visible = true;
                lblGenelToplam.Text = "<strong>" + (string)GetGlobalResourceObject("strings", "siparisGenelToplam").ToString() + "</strong>";
                lblGenelToplamFiyat.Text = "<strong class='text-info'>" + genelToplam.ToString("N") + " " + paraBirimi.ToString() + "</strong>";

                genelToplamIskonto = genelToplamTam - genelToplamTam;


                rdrPaket.Close();
                bag.Dispose();





                kagitSayisiOzet.Visible = true;

                lblKagitFiyat.Text = "<strong class='text-info'>" + kagitFiyat.ToString("N") + " " + paraBirimi.ToString() + "</strong>";

                System.Threading.Thread.Sleep(1000);

                pnlForm.Visible = false;
                pnlKapaklar.Visible = false;
                pnlOlculer.Visible = false;
                pnlPaketler.Visible = false;

                pnlSepet.Visible = true;

                ScriptManager.RegisterStartupScript(this, GetType(), "siparisOzetleriiii", "moveTo('siparisOzet');", true);

                //Session["siparis"] = genelToplam + "$" + genelToplamTam + "$" + genelToplamIskonto + "$"; // 1
                //Session["siparis"] += calismaliFiyat + "$" + calismaliFiyatTam + "$" + calismaliFiyatIskonto + "$"; // 2
                //Session["siparis"] += paketFiyat + "$" + paketFiyatTam + "$" + paketFiyatIskonto + "$"; // 3
                //Session["siparis"] += saatFiyat + "$" + saatFiyatTam + "$" + saatFiyatIskonto + "$"; // 4
                //Session["siparis"] += kutuFiyat + "$" + kutuFiyatTam + "$" + kutuFiyatIskonto + "$"; // 5
                //Session["siparis"] += aileFiyat + "$" + aileFiyatTam + "$" + aileFiyatIskonto + "$"; // 6
                //Session["siparis"] += cepFiyat + "$" + cepFiyatTam + "$" + cepFiyatIskonto + "$"; // 7
                //Session["siparis"] += buyukFiyat + "$" + buyukFiyatTam + "$" + buyukFiyatIskonto + "$"; // 8
                //Session["siparis"] += yaprakFiyat + "$" + yaprakFiyatTam + "$" + yaprakFiyatIskonto + "$"; // 9
                //Session["siparis"] += kagitFiyat + "$" + kagitFiyatTam + "$" + kagitFiyatIskonto; // 10


                //Session["siparisBilgiler"] = musteriID + "$" + paketNo + "$" + secilenKapak+ "$";
                //Session["siparisBilgiler"] += seciliBolge + "$" + secilenCanta + "$" + secilenSaat + "$";
                //Session["siparisBilgiler"] += secilenAile + "$" + secilenCep + "$" + secilenBuyuk + "$";
                //Session["siparisBilgiler"] += drpSayfaTipi.SelectedValue + "$" + drpYaprakSayisi.SelectedValue + "$" + calismaTyp + "$" + secilenKagit;

                //Session["siparisBuyukEbatYazi"] = txtBuyukEbat.Text;
                //Session["siparisKapakYazi"] = txtKapakYazisi.Text;
                //Session["siparisMusteriNot"] = txtMusteriNotu.Text;

                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~/siparisXml/" + musteriID));


                XDocument doc = new XDocument(new XElement("siparisler",
                    new XElement("sip",
                        new XElement("musteriID", musteriID),
                        new XElement("paketNo", paketNo),
                        new XElement("kapak", secilenKapak),
                        new XElement("bolge", seciliBolge),
                        new XElement("canta", secilenCanta),
                        new XElement("saat", secilenSaat),
                        new XElement("aile", secilenAile),
                        new XElement("cep", secilenCep),
                        new XElement("buyuk", secilenBuyuk),
                        new XElement("sayfatip", drpSayfaTipi.SelectedValue),
                        new XElement("yaprak", drpYaprakSayisi.SelectedValue),
                        new XElement("calismatip", calismaTyp),
                        new XElement("kagit", secilenKagit),
                        new XElement("kagityazisi", kagitxmlyazisi),
                        new XElement("buyukebatyazi", txtBuyukEbat.Text),
                        new XElement("kapakyazi", txtKapakYazisi.Text),
                        new XElement("musterinot", txtMusteriNotu.Text),
                        new XElement("geneltoplam", genelToplam.ToString("0.00")),
                        new XElement("geneltoplamtam", genelToplamTam.ToString("0.00")),
                        new XElement("geneltoplamiskonto", genelToplamIskonto.ToString("0.00")),
                        new XElement("calismalifiyat", calismaliFiyat.ToString("0.00")),
                        new XElement("calismalifiyattam", calismaliFiyatTam.ToString("0.00")),
                        new XElement("calismalifiyatiskonto", calismaliFiyatIskonto.ToString("0.00")),
                        new XElement("paketfiyat", paketFiyat.ToString("0.00")),
                        new XElement("paketfiyattam", paketFiyatTam.ToString("0.00")),
                        new XElement("paketfiyatiskonto", paketFiyatIskonto.ToString("0.00")),
                        new XElement("saatfiyat", saatFiyat.ToString("0.00")),
                        new XElement("saatfiyattam", saatFiyatTam.ToString("0.00")),
                        new XElement("saatfiyatiskonto", saatFiyatIskonto.ToString("0.00")),
                        new XElement("kutufiyat", kutuFiyat.ToString("0.00")),
                        new XElement("kutufiyattam", kutuFiyatTam.ToString("0.00")),
                        new XElement("kutufiyatiskonto", kutuFiyatIskonto.ToString("0.00")),
                        new XElement("ailefiyat", aileFiyat.ToString("0.00")),
                        new XElement("ailefiyattam", aileFiyatTam.ToString("0.00")),
                        new XElement("ailefiyatiskonto", aileFiyatIskonto.ToString("0.00")),
                        new XElement("cepfiyat", cepFiyat.ToString("0.00")),
                        new XElement("cepfiyattam", cepFiyatTam.ToString("0.00")),
                        new XElement("cepfiyatiskonto", cepFiyatIskonto.ToString("0.00")),
                        new XElement("buyukfiyat", buyukFiyat.ToString("0.00")),
                        new XElement("buyukfiyattam", buyukFiyatTam.ToString("0.00")),
                        new XElement("buyukfiyatiskonto", buyukFiyatIskonto.ToString("0.00")),
                        new XElement("yaprakfiyat", yaprakFiyat.ToString("0.00")),
                        new XElement("yaprakfiyattam", yaprakFiyatTam.ToString("0.00")),
                        new XElement("yaprakfiyatiskonto", yaprakFiyatIskonto.ToString("0.00")),
                        new XElement("kagitfiyat", kagitFiyat.ToString("0.00")),
                        new XElement("kagitfiyattam", kagitFiyatTam.ToString("0.00")),
                        new XElement("kagitfiyatiskonto", kagitFiyatIskonto.ToString("0.00")),
                        new XElement("saatyazisi", saatxmladi),
                        new XElement("kutuyazisi", cantaxmladi),
                        new XElement("aileyazisi", ailexmladi),
                        new XElement("cepyazisi", cepxmladi),
                        new XElement("buyukyazisi", buyukxmladi),
                        new XElement("calismayazisi", calismaxmladi),
                        new XElement("kapakadi", kapakxmladi),
                        new XElement("kapakfotokucuk", kapakfotoxmlkucuk),
                        new XElement("kapakfotobuyuk", kapakfotoxmlbuyuk),
                        new XElement("secilenahsap", secilenAhsap)
                        )));

                doc.Save(HttpContext.Current.Server.MapPath(@"~/siparisXml/" + siparisOzelID + ".xml"));



            }
            catch (Exception ex)
            {
                litHataTitle.Text = (string)(GetGlobalResourceObject("strings", "sistemHataTitle")); ;
                regFormErrList.Text = "<p>" + (string)(GetGlobalResourceObject("strings", "sistemHataMesaj")) + "</p>";
                regFormErrList.Text += "<p>" + string.Format((string)(GetGlobalResourceObject("strings", "sistemHataMesaj2")), xmlError.errLog.hataKayit(ex.ToString())) + "</p>";
                regFormErrList.Text += "<p>" + (string)(GetGlobalResourceObject("strings", "sistemHataMesaj3")) + "</p>";
                regFormErrList.Text += "<p>" + (string)(GetGlobalResourceObject("strings", "sistemHataMesaj4")) + "</p>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp1245", "openModal();", true);

                ScriptManager.RegisterStartupScript(this, GetType(), "musteriFormSecimler2err", "moveTo('musteriFormSecimler');", true);
            }

        }


    }

    protected void btnSiparisDuzelt_Click(object sender, EventArgs e)
    {
        pnlForm.Visible = true;
        pnlKapaklar.Visible = true;
        pnlOlculer.Visible = true;
        pnlPaketler.Visible = true;
        pnlSepet.Visible = false;

        ScriptManager.RegisterStartupScript(this, GetType(), "musteriFormSecimler2222", "moveTo('musteriFormSecimler');", true);

        dosyaFormGizle();

    }

    protected void btnSiparisDevam_Click(object sender, EventArgs e)
    {

        pnlForm.Visible = false;
        pnlKapaklar.Visible = false;
        pnlOlculer.Visible = false;
        pnlPaketler.Visible = false;
        pnlSepet.Visible = true;

        ScriptManager.RegisterStartupScript(this, GetType(), "outTi1211232", "fade('dosyaGonder');", true);

        //ScriptManager.RegisterStartupScript(this, GetType(), "showT44125123545", "fade('uplForm');", true);

        //uplFormLast.Style["display"] = "block";

        dosyaFormGoster();
        ScriptManager.RegisterStartupScript(this, GetType(), "dGonder2222", "moveTo('dosyaGonder');", true);

    }

    public void dosyaFormGizle()
    {
        //ScriptManager.RegisterStartupScript(this, GetType(), "outTime4Af255", "hideDiv();", true);
        //pnlUpload.Visible = false;

        ScriptManager.RegisterStartupScript(this, GetType(), "outTime444234", "fadeOUT('dosyaGonder');", true);
    }

    public void dosyaFormGoster()
    {
        //pnlUpload.Visible = true;
        //ScriptManager.RegisterStartupScript(this, GetType(), "outTite2323", "showDiv();", true);
        ScriptManager.RegisterStartupScript(this, GetType(), "outTi1212", "fade('dosyaGonder');", true);
    }

    public string premiumPlusFoto(int id)
    {
        string donus = "";

        if (id == 5212 || id == 5314 || id == 5263 || id == 5840 || id == 5900 || id == 6343)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/carmen-foto.jpg' /></div> ";
        }

        else if (id == 5221 || id == 5323 || id == 5272 || id == 5849 || id == 5909 || id == 6352)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/clara.jpg' /></div> ";
        }

        else if (id == 5222 || id == 5324 || id == 5273 || id == 5910 || id == 5850 || id == 6353)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/country.jpg' /></div> ";
        }

        else if (id == 5230 || id == 5332 || id == 5281 || id == 5918 || id == 5858 || id == 6361)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/delta-yat.jpg' /></div> ";
        }

        else if (id == 5234 || id == 5336 || id == 5285 || id == 5862 || id == 5922)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/diamond.jpg' /></div> ";
        }

        else if (id == 5235 || id == 5337 || id == 5286 || id == 5923 || id == 5863)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/glass.jpg' /></div> ";
        }

        else if (id == 5239 || id == 5341 || id == 5290 || id == 5867 || id == 5927)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/lima.jpg' /></div> ";
        }

        else if (id == 5241 || id == 5343 || id == 5292 || id == 5929 || id == 5869)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/metal.jpg' /></div> ";
        }

        else if (id == 5246 || id == 5348 || id == 5297 || id == 5874 || id == 5934)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/motto.jpg' /></div> ";
        }

        else if (id == 5248 || id == 5350 || id == 5299 || id == 5936 || id == 5876)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/noble.jpg' /></div> ";
        }

        else if (id == 5253 || id == 5355 || id == 5304 || id == 5881 || id == 5941)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/queen.jpg' /></div> ";
        }

        else if (id == 5259 || id == 5361 || id == 5310 || id == 5947 || id == 5887 || id == 6390)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/siena.jpg' /></div> ";
        }

        else if (id == 5515 || id == 5629 || id == 5572 || id == 5743 || id == 5802)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/leinen-pure.jpg' /></div> ";
        }

        else if (id == 5516 || id == 5630 || id == 5573 || id == 5803 || id == 5744 || id == 6395)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/liona-series.jpg' /></div> ";
        }

        else if (id == 5522 || id == 5636 || id == 5579 || id == 5750 || id == 5809 || id == 6401)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/melisa-series.jpg' /></div> ";
        }

        else if (id == 5527 || id == 5641 || id == 5584 || id == 5814 || id == 5755)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/nevada-series.jpg' /></div> ";
        }

        else if (id == 5537 || id == 5651 || id == 5594 || id == 5765 || id == 5824)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/plexi-glass-plus-seri.jpg' /></div> ";
        }

        else if (id == 5542 || id == 5656 || id == 5599 || id == 5772 || id == 5713)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/samenta-series.jpg' /></div> ";
        }

        else if (id == 5548 || id == 5662 || id == 5605 || id == 5719 || id == 5778)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/satin-series.jpg' /></div> ";
        }

        else if (id == 5549 || id == 5663 || id == 5606 || id == 5779 || id == 5720 || id == 6428)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/stamp-series.jpg' /></div> ";
        }

        else if (id == 5551 || id == 5665 || id == 5608 || id == 5722 || id == 5781)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/valdes-series.jpg' /></div> ";
        }

        else if (id == 5561 || id == 5675 || id == 5618 || id == 5791 || id == 5732 || id == 6445)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/wood-nature-series.jpg' /></div> ";
        }

        else if (id == 5564 || id == 5678 || id == 5621 || id == 5735 || id == 5794 || id == 6447)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/woodart-nature-metal.jpg' /></div> ";
        }

        else if (id == 5567 || id == 5681 || id == 5624 || id == 5797 || id == 5738 || id == 6440)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/woodart-series.jpg' /></div> ";
        }

        else if (id == 5686 || id == 5695 || id == 5704 || id == 5831 || id == 5891 || id == 6334)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/koton-series.jpg' /></div> ";
        }

        else if (id == 6060 || id == 6039 || id == 6018 || id == 5997)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/yk-dilara.jpg' /></div> ";
        }

        else if (id == 6069 || id == 6048 || id == 6027 || id == 6006)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/yk-misra.jpg' /></div> ";
        }

        else if (id == 6072 || id == 6051 || id == 6030 || id == 6009)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/yk-pure.jpg' /></div> ";
        }

        else if (id == 6073 || id == 6052 || id == 6031 || id == 6010)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/yk-side.jpg' /></div> ";
        }

        else if (id == 6078 || id == 6057 || id == 6036 || id == 6015)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/yk-viga.jpg' /></div> ";
        }

        else if (id == 6081 || id == 6102)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/alacati-vintage.jpg' /></div> ";
        }

        else if (id == 6087 || id == 6108)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/leron-vintage.jpg' /></div> ";
        }

        else if (id == 6088 || id == 6109)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/lisa-vintage.jpg' /></div> ";
        }

        else if (id == 6095 || id == 6116)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/lucas-vintage.jpg' /></div> ";
        }

        else if (id == 6120 || id == 6099)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/olivia-vintage.jpg' /></div> ";
        }

        else if (id == 6123 || id == 6127)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/STD-Model-1.jpg' /></div> ";
        }

        else if (id == 6124 || id == 6128)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/STD-Model-2.jpg' /></div> ";
        }

        else if (id == 6125 || id == 6129)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/STD-Model-3.jpg' /></div> ";
        }

        else if (id == 6126 || id == 6130)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/STD-Model-4.jpg' /></div> ";
        }

        else if (id == 6132 || id == 6135 || id == 6138 || id == 6141 || id == 6144 || id == 6147 || id == 6456 || id == 6459)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/TA-luka-gul-kurusu.jpg' /></div> ";
        }

        else if (id == 6131 || id == 6134 || id == 6137 || id == 6140 || id == 6143 || id == 6146 || id == 6454 || id == 6457)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/TA-luka-krem.jpg' /></div> ";
        }

        else if (id == 6133 || id == 6136 || id == 6139 || id == 6142 || id == 6145 || id == 6148 || id == 6455 || id == 6458)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/TA-luka-turkuaz.jpg' /></div> ";
        }


        else if (id == 6270 || id == 6286 || id == 6302 || id == 6318)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/BA-Markiz.jpg' /></div> ";
        }

        else if (id == 6274 || id == 6290 || id == 6306 || id == 6322)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/BA-Melon.jpg' /></div> ";
        }

        else if (id == 6282 || id == 6298 || id == 6314 || id == 6330)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/Ba-Mia.jpg' /></div> ";
        }

        else if (id == 6278 || id == 6294 || id == 6310 || id == 6326)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/BA-Softy.jpg' /></div> ";
        }

        else if (id == 6520 || id == 6526 || id == 6527 || id == 6528)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/Foto-Kapak-Hazirlaniyor.jpg' /></div> ";
        }

        else if (id == 6521 || id == 6522 || id == 6523 || id == 6451 || id == 6452 || id == 6453 || id == 6523 || id == 6524 || id == 6525)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/Foto-Kapak-Hazirlaniyor-Tek-Album.jpg' /></div> ";
        }

        else if (id == 6529 || id == 6535 || id == 6541 || id == 6547)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2016/YK-Era-Fotograf.jpg' /></div> ";
        }


       else if (id == 6705 || id == 6633 || id == 6777 || id == 6849)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/Albatros-gorsel.JPG' /></div> ";
        }

        else if (id == 6991 || id == 6977 || id == 7005 || id == 7019)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/Angel-gorsel.JPG' /></div> ";
        }

        else if (id == 6717 || id == 6645 || id == 6789 || id == 6861)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/BOLERO-gorsel.JPG' /></div> ";
        }

        else if (id == 6723 || id == 6651 || id == 6795 || id == 6867)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/Diamond-gorsel.JPG' /></div> ";
        }

        else if (id == 6729 || id == 6657 || id == 6801 || id == 6873)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/Dolce-gorsel.JPG' /></div> ";
        }

        else if (id == 6879 || id == 6807 || id == 6663 || id == 6735)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/Elena-gorsel.JPG' /></div> ";
        }

        else if (id == 6996 || id == 6982 || id == 7010 || id == 7024)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/Jasmin-gorsel.JPG' /></div> ";
        }

        else if (id == 6891 || id == 6819 || id == 6675 || id == 6747)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/Marcos-gorsel.JPG' /></div> ";
        }

        else if (id == 6903 || id == 6759 || id == 6687 || id == 6831)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/Merlin-gorsel.JPG' /></div> ";
        }

        else if (id == 6765 || id == 6693 || id == 6837 || id == 6909)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/Orlando-gorsel.JPG' /></div> ";
        }

        else if (id == 6771 || id == 6699 || id == 6843 || id == 6915)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/Simena-gorsel.JPG' /></div> ";
        }

        else if (id == 7001 || id == 6987 || id == 7015 || id == 7029)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/MAYA-1.JPG' /></div> ";
        }

        else if (id == 6988 || id == 7002 || id == 7016 || id == 7030)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/MAYA-2.JPG' /></div> ";
        }

        else if (id == 6989 || id == 7003 || id == 7017 || id == 7031)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/MAYA-3.JPG' /></div> ";
        }

        else if (id == 6990 || id == 7004 || id == 7018 || id == 7032)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/MAYA-4.JPG' /></div> ";
        }


        else if (id == 7041 || id == 7060)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/garsiya.JPG' /></div> ";
        }

        else if (id == 7044 || id == 7063)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/lima.JPG' /></div> ";
        }

        else if (id == 7047 || id == 7066)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/marquez.JPG' /></div> ";
        }

        else if (id == 7050 || id == 7069)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/model-1.JPG' /></div> ";
        }

        else if (id == 7051 || id == 7070)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/model-2.JPG' /></div> ";
        }

        else if (id == 7052 || id == 7071)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/model-3.JPG' /></div> ";
        }

        else if (id == 7053 || id == 7072)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/model-4.JPG' /></div> ";
        }

        else if (id == 7054 || id == 7073)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/oslo.JPG' /></div> ";
        }

        else if (id == 7057 || id == 7076)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='http://www.mertalbum.com/images/2019/venedik.JPG' /></div> ";
        }

        return donus;

        // 
    }

    public static void testM()
    {

        Page page = (Page)HttpContext.Current.Handler;
        Panel pnl1 = (Panel)page.FindControl("pnlOlculer");

        pnl1.Visible = false;

    }


    [WebMethod()]
    public static string YeniBitis(string dosya, string code)
    {
        string filePath = @"c:\siparisler\";
        string fileName = filePath + dosya;
        bool siparisTekrar = false;
        int insertID = 0;
        int hata = 0;


        string dosyaVar = "Bilmiyor";

        if (File.Exists(fileName))
        {
            try
            {
                dosyaVar = "Dosya Var";

                string fileSHA = fileHasher.GetMD5Hash(fileName);

                pwdHash.passwordHash dcry = new passwordHash();


                Int64 sessionIds = Convert.ToInt64(fileHasher.rndPassGenerator(18, 0));

                string secKey = fileHasher.rndPassGenerator2(40, 0);




                XmlDocument x = new XmlDocument();
                //x.Load(HttpContext.Current.Server.MapPath(@"~/siparisXml/805/805-20-12-2017-18-13-344.xml"));
                x.Load(HttpContext.Current.Server.MapPath(@"~/siparisXml/" + dcry.Decrypt(code) + ".xml"));

                string musteriID = x.SelectSingleNode("siparisler/sip/musteriID").InnerText;
                string paketNo = x.SelectSingleNode("siparisler/sip/paketNo").InnerText;
                string kapak = x.SelectSingleNode("siparisler/sip/kapak").InnerText;
                string bolge = x.SelectSingleNode("siparisler/sip/bolge").InnerText;
                string canta = x.SelectSingleNode("siparisler/sip/canta").InnerText;
                string saat = x.SelectSingleNode("siparisler/sip/saat").InnerText;
                string aile = x.SelectSingleNode("siparisler/sip/aile").InnerText;
                string cep = x.SelectSingleNode("siparisler/sip/cep").InnerText;
                string buyuk = x.SelectSingleNode("siparisler/sip/buyuk").InnerText;
                string sayfatip = x.SelectSingleNode("siparisler/sip/sayfatip").InnerText;
                string yaprak = x.SelectSingleNode("siparisler/sip/yaprak").InnerText;
                string calismatip = x.SelectSingleNode("siparisler/sip/calismatip").InnerText;
                string kagit = x.SelectSingleNode("siparisler/sip/kagit").InnerText;
                string buyukebatyazi = x.SelectSingleNode("siparisler/sip/buyukebatyazi").InnerText;
                string kapakyazi = x.SelectSingleNode("siparisler/sip/kapakyazi").InnerText;
                string musterinot = x.SelectSingleNode("siparisler/sip/musterinot").InnerText;
                string geneltoplam = x.SelectSingleNode("siparisler/sip/geneltoplam").InnerText;
                string geneltoplamtam = x.SelectSingleNode("siparisler/sip/geneltoplamtam").InnerText;
                string geneltoplamiskonto = x.SelectSingleNode("siparisler/sip/geneltoplamiskonto").InnerText;
                string calismalifiyat = x.SelectSingleNode("siparisler/sip/calismalifiyat").InnerText;
                string calismalifiyattam = x.SelectSingleNode("siparisler/sip/calismalifiyattam").InnerText;
                string calismalifiyatiskonto = x.SelectSingleNode("siparisler/sip/calismalifiyatiskonto").InnerText;
                string paketfiyat = x.SelectSingleNode("siparisler/sip/paketfiyat").InnerText;
                string paketfiyattam = x.SelectSingleNode("siparisler/sip/paketfiyattam").InnerText;
                string paketfiyatiskonto = x.SelectSingleNode("siparisler/sip/paketfiyatiskonto").InnerText;
                string saatfiyat = x.SelectSingleNode("siparisler/sip/saatfiyat").InnerText;
                string saatfiyattam = x.SelectSingleNode("siparisler/sip/saatfiyattam").InnerText;
                string saatfiyatiskonto = x.SelectSingleNode("siparisler/sip/saatfiyatiskonto").InnerText;
                string kutufiyat = x.SelectSingleNode("siparisler/sip/kutufiyat").InnerText;
                string kutufiyattam = x.SelectSingleNode("siparisler/sip/kutufiyattam").InnerText;
                string kutufiyatiskonto = x.SelectSingleNode("siparisler/sip/kutufiyatiskonto").InnerText;
                string ailefiyat = x.SelectSingleNode("siparisler/sip/ailefiyat").InnerText;
                string ailefiyattam = x.SelectSingleNode("siparisler/sip/ailefiyattam").InnerText;
                string ailefiyatiskonto = x.SelectSingleNode("siparisler/sip/ailefiyatiskonto").InnerText;
                string cepfiyat = x.SelectSingleNode("siparisler/sip/cepfiyat").InnerText;
                string cepfiyattam = x.SelectSingleNode("siparisler/sip/cepfiyattam").InnerText;
                string cepfiyatiskonto = x.SelectSingleNode("siparisler/sip/cepfiyatiskonto").InnerText;
                string buyukfiyat = x.SelectSingleNode("siparisler/sip/buyukfiyat").InnerText;
                string buyukfiyattam = x.SelectSingleNode("siparisler/sip/buyukfiyattam").InnerText;
                string buyukfiyatiskonto = x.SelectSingleNode("siparisler/sip/buyukfiyatiskonto").InnerText;
                string yaprakfiyat = x.SelectSingleNode("siparisler/sip/yaprakfiyat").InnerText;
                string yaprakfiyattam = x.SelectSingleNode("siparisler/sip/yaprakfiyattam").InnerText;
                string yaprakfiyatiskonto = x.SelectSingleNode("siparisler/sip/yaprakfiyatiskonto").InnerText;
                string kagitfiyat = x.SelectSingleNode("siparisler/sip/kagitfiyat").InnerText;
                string kagitfiyattam = x.SelectSingleNode("siparisler/sip/kagitfiyattam").InnerText;
                string kagitfiyatiskonto = x.SelectSingleNode("siparisler/sip/kagitfiyatiskonto").InnerText;
                string secilenahsap = x.SelectSingleNode("siparisler/sip/secilenahsap").InnerText;


                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = cstring.ConnStr();
                    conn.Open();

                    SqlCommand sc = new SqlCommand("insert into siparis(m_id, m_paket, session_id, m_tem, sayfa_tipi, m_yaprak, m_fsayi, m_tasarim, m_not, m_tarih, m_tarih2, m_calismasekli, p_album, m_canta, m_kristal, m_saat, m_buyuk, m_cep, m_aile, siparis_kagit, yazBuyuk, sdownloaded, sipuplfrom, siparis_md5, filehash, m_onay, sipuplrealfilename, sipKapakYazi, m_sipKapak, sipSecilenAhsap)values(@m_id, @m_paket, @session_id, @m_tem, @sayfa_tipi, @m_yaprak, @m_fsayi, @m_tasarim, @m_not, @m_tarih, @m_tarih2, @m_calismasekli, @p_album, @m_canta, @m_kristal, @m_saat, @m_buyuk, @m_cep, @m_aile, @siparis_kagit, @yazBuyuk, @sdownloaded, @sipuplfrom, @siparis_md5, @filehash, @m_onay, @sipuplrealfilename, @sipKapakYazi, @m_sipKapak, @sipSecilenAhsap) ;SELECT SCOPE_IDENTITY();", conn);
                    sc.Parameters.AddWithValue("@m_id", musteriID);
                    sc.Parameters.AddWithValue("@m_paket", paketNo);//hdnPaket.Value
                    sc.Parameters.AddWithValue("@session_id", sessionIds);
                    sc.Parameters.AddWithValue("@m_tem", 8);
                    sc.Parameters.AddWithValue("@sayfa_tipi", sayfatip);//hdnSayfaTipi.Value
                    sc.Parameters.AddWithValue("@m_yaprak", yaprak); //hdnYaprakSayisi.Value
                    sc.Parameters.AddWithValue("@m_fsayi", 20);
                    sc.Parameters.AddWithValue("@m_tasarim", "");//Request.Cookies["siparis"]["tasarimSekli"] // hdnTasarimSekli.Value 
                    sc.Parameters.AddWithValue("@m_not", musterinot);
                    sc.Parameters.AddWithValue("@m_tarih", DateTime.Now.ToString());
                    sc.Parameters.AddWithValue("@m_tarih2", DateTime.Now);
                    sc.Parameters.AddWithValue("@m_calismasekli", calismatip);//hdnCalisma.Value
                    sc.Parameters.AddWithValue("@p_album", calismatip);//hdnPAlbum.Value
                    sc.Parameters.AddWithValue("@m_canta", canta);// hdnCanta.Value
                    sc.Parameters.AddWithValue("@m_kristal", 0);
                    sc.Parameters.AddWithValue("@m_saat", saat); //hdnSaat.Value
                    sc.Parameters.AddWithValue("@m_buyuk", buyuk);//hdnBuyuk.Value
                    sc.Parameters.AddWithValue("@m_cep", cep);//hdnCep.Value
                    sc.Parameters.AddWithValue("@m_aile", aile);//hdnAile.Value
                    sc.Parameters.AddWithValue("@siparis_kagit", kagit);//hdnKagit.Value
                    sc.Parameters.AddWithValue("@sdownloaded", 0);
                    sc.Parameters.AddWithValue("@sipuplfrom", 1);
                    sc.Parameters.AddWithValue("@siparis_md5", secKey);
                    sc.Parameters.AddWithValue("@filehash", fileSHA);
                    sc.Parameters.AddWithValue("@m_onay", 1);
                    sc.Parameters.AddWithValue("@sipuplrealfilename", dosya);
                    sc.Parameters.AddWithValue("@yazBuyuk", buyukebatyazi);//hdnBuyukEbatText.Value
                    sc.Parameters.AddWithValue("@sipKapakYazi", kapakyazi);//hdnBuyukEbatText.Value
                    sc.Parameters.AddWithValue("@m_sipKapak", kapak);//hdnBuyukEbatText.Value
                    sc.Parameters.AddWithValue("@sipSecilenAhsap", secilenahsap);//seçilen ahşap
                    

                    insertID = Convert.ToInt32(sc.ExecuteScalar());

                    string yeniFileName = insertID + Path.GetExtension(fileName);


                    fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(geneltoplam), Convert.ToDouble(geneltoplamtam), Convert.ToDouble(geneltoplamiskonto), 1); // genelToplam
                    fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(calismalifiyat), Convert.ToDouble(calismalifiyattam), Convert.ToDouble(calismalifiyatiskonto), 2); // çalışmalı fiyat
                    fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(paketfiyat), Convert.ToDouble(paketfiyattam), Convert.ToDouble(paketfiyatiskonto), 3); // paket ücreti
                    fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(saatfiyat), Convert.ToDouble(saatfiyattam), Convert.ToDouble(saatfiyatiskonto), 4); // saat fiyat
                    fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(kutufiyat), Convert.ToDouble(kutufiyattam), Convert.ToDouble(kutufiyatiskonto), 5); // kutufiyat
                    fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(ailefiyat), Convert.ToDouble(ailefiyattam), Convert.ToDouble(ailefiyatiskonto), 6); // aile fiyat
                    fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(cepfiyat), Convert.ToDouble(cepfiyattam), Convert.ToDouble(cepfiyatiskonto), 7); // cep fiyat
                    fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(buyukfiyat), Convert.ToDouble(buyukfiyattam), Convert.ToDouble(buyukfiyatiskonto), 8); // büyük fiyat
                    fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(yaprakfiyat), Convert.ToDouble(yaprakfiyattam), Convert.ToDouble(yaprakfiyatiskonto), 9); // çalışmalı fiyat
                    fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(kagitfiyat), Convert.ToDouble(kagitfiyattam), Convert.ToDouble(kagitfiyatiskonto), 10); // kağıt silk vb. 


                    using (SqlCommand sx = new SqlCommand("update siparis set m_filename=@m_filename where id=@id", conn))
                    {
                        sx.Parameters.AddWithValue("@m_filename", yeniFileName);
                        sx.Parameters.AddWithValue("@id", insertID);
                        sx.ExecuteNonQuery();
                    }

                    using (SqlCommand sep = new SqlCommand("insert into sepet(session_id, urun_id, sepet_mid, p_type) values(@session_id, @urun_id, @sepet_mid, @p_type)", conn))
                    {
                        sep.Parameters.AddWithValue("@session_id", sessionIds);
                        sep.Parameters.AddWithValue("@urun_id", kapak);
                        sep.Parameters.AddWithValue("@sepet_mid", musteriID);
                        sep.Parameters.AddWithValue("@p_type", 2);
                        sep.ExecuteNonQuery();
                    }

                    using (SqlCommand d = new SqlCommand("Select * from siparis where m_id=@_mid and filehash=@_hash and not id=@_id", conn))
                    {
                        d.Parameters.AddWithValue("@_mid", musteriID);
                        d.Parameters.AddWithValue("@_hash", fileSHA);
                        d.Parameters.AddWithValue("@_id", insertID);

                        using (SqlDataReader rdrD = d.ExecuteReader())
                        {
                            rdrD.Read();

                            if (rdrD.HasRows)
                            {
                                using (SqlCommand dt = new SqlCommand("update siparis set hashprob=@_hashprob, hasprobid=@_hasprobid where id=@nid", conn))
                                {
                                    dt.Parameters.AddWithValue("@_hashprob", 1);
                                    dt.Parameters.AddWithValue("@_hasprobid", rdrD["id"]);
                                    dt.Parameters.AddWithValue("@nid", insertID);
                                    dt.ExecuteNonQuery();
                                }
                                siparisTekrar = true;
                            }

                            else
                            {
                                siparisTekrar = false;
                            }
                        }



                    }



                    File.Move(Path.Combine(filePath, fileName), Path.Combine(filePath, yeniFileName));

                }


            }
            catch (Exception e)
            {
                hata = 1;
                xmlError.errLog.hataKayit(e.ToString());
            }

        }

        else
        {
            dosyaVar = "Dosya Yok";
        }



        var data = new { Code = code, siparis = passwordHash.Sifrele(insertID.ToString()), tekrar = siparisTekrar, Hata = hata };

        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();

        return js.Serialize(data);

        //var json = "{\"code\":\"" + code + "\", \"siparis\":\"" + pwdHash.passwordHash.Sifrele(insertID.ToString()) + "\", \"tekrar\":\"" + siparisTekrar + "\", \"hata\":\"" + hata + "\"}";

        ////System.Threading.Thread.Sleep(5000);   
        ////testM();
        //return json;


    }
}