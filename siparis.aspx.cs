using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using paketAlt;
using fiyatlar;
using SqlConnections;

public partial class siparis : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Cookies["assc"] == null)
        {
            Response.Redirect("/uye-giris");
        }

    }
    public string musteriID { get; set; }
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
        //int userID = 805;
        int userID = Convert.ToInt32(HttpContext.Current.Request.Cookies["assc"]["mid"]);

        musteriID = userID.ToString();

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
            lineSeri();
            loftSeri();
            standarSerii();
            legendNaylaSeri();
            BebekSeri();
			marioLuigi();
            //TrendSeri();
   //         yp19Seri();
   //         jumboSeri();
   //         yeniKampanyaliSeri();
			//ekoKampanyaliSeri();
   //         saveTheDateSeri();
   //         vintageSeri();
   //         tekAlbumKampanyaliSeri();
   //         babyKidsSeri();
   //         //masterSeri();
   //              //       premiumPlusSeri();
   //         premiumSeri();
   //         //            kristalPlusSeri();
   //         //kristalSeri();
   //         //standartSeri();
   //         kampanyaliSeri();

            Page.Title = (string)(GetGlobalResourceObject("strings", "siparisPageTitle"));



            if (Session["fileN"] != null)
            {
                //Label1.Text = Session["fileN"].ToString();

                string filePath = @"c:\siparisler\";
                string fileName = filePath + Session["fileN"].ToString();

                if (File.Exists(fileName))
                {


                    try
                    {



                        pnlDone.Visible = true;


                        string fileSHA = fileHasher.GetMD5Hash(fileName);

                        //sess.Text = Session["siparis"].ToString() + "</br>" + Session["siparisBilgiler"].ToString() + "</br>" + Session["siparisBuyukEbatYazi"].ToString() + "</br>" + Session["siparisKapakYazi"].ToString() + "</br>" + Session["siparisMusteriNot"].ToString() + "</br> FileSHA : " + fileSHA.ToString();





                        //


                        connectionStr.DBIslem x = new connectionStr.DBIslem();
                        SqlConnection bag = x.Baglanti();

                        bool siparisTekrar = false;
                        Int64 sessionIDS = Convert.ToInt64(fileHasher.rndPassGenerator(18, 0));



                        string secKey = fileHasher.rndPassGenerator2(40, 0);

                        string[] siparisBilgi = Session["siparisBilgiler"].ToString().Split('$');
                        string[] siparisFiyatlar = Session["siparis"].ToString().Split('$');


                        string sql = "insert into siparis(m_id, m_paket, session_id, m_tem, sayfa_tipi, m_yaprak, m_fsayi, m_tasarim, m_not, m_tarih, m_tarih2, m_calismasekli, p_album, m_canta, m_kristal, m_saat, m_buyuk, m_cep, m_aile, siparis_kagit, yazBuyuk, sdownloaded, sipuplfrom, siparis_md5, filehash, m_onay, sipuplrealfilename, sipKapakYazi, m_sipKapak, sipSecilenAhsap)values(@m_id, @m_paket, @session_id, @m_tem, @sayfa_tipi, @m_yaprak, @m_fsayi, @m_tasarim, @m_not, @m_tarih, @m_tarih2, @m_calismasekli, @p_album, @m_canta, @m_kristal, @m_saat, @m_buyuk, @m_cep, @m_aile, @siparis_kagit, @yazBuyuk, @sdownloaded, @sipuplfrom, @siparis_md5, @filehash, @m_onay, @sipuplrealfilename, @sipKapakYazi, @m_sipKapak, @sipSecilenAhsap) ;SELECT SCOPE_IDENTITY();";
                        SqlCommand c = new SqlCommand(sql, bag);
                        c.Parameters.AddWithValue("@m_id", siparisBilgi[0]);
                        c.Parameters.AddWithValue("@m_paket", siparisBilgi[1]);//hdnPaket.Value
                        c.Parameters.AddWithValue("@session_id", sessionIDS);
                        c.Parameters.AddWithValue("@m_tem", 8);
                        c.Parameters.AddWithValue("@sayfa_tipi", siparisBilgi[9]);//hdnSayfaTipi.Value
                        c.Parameters.AddWithValue("@m_yaprak", siparisBilgi[10]); //hdnYaprakSayisi.Value
                        c.Parameters.AddWithValue("@m_fsayi", 20);
                        c.Parameters.AddWithValue("@m_tasarim", "");//Request.Cookies["siparis"]["tasarimSekli"] // hdnTasarimSekli.Value 
                        c.Parameters.AddWithValue("@m_not", Session["siparisMusteriNot"]);
                        c.Parameters.AddWithValue("@m_tarih", DateTime.Now.ToString());
                        c.Parameters.AddWithValue("@m_tarih2", DateTime.Now);
                        c.Parameters.AddWithValue("@m_calismasekli", siparisBilgi[11]);//hdnCalisma.Value
                        c.Parameters.AddWithValue("@p_album", siparisBilgi[11]);//hdnPAlbum.Value
                        c.Parameters.AddWithValue("@m_canta", siparisBilgi[4]);// hdnCanta.Value
                        c.Parameters.AddWithValue("@m_kristal", 0);
                        c.Parameters.AddWithValue("@m_saat", siparisBilgi[5]); //hdnSaat.Value
                        c.Parameters.AddWithValue("@m_buyuk", siparisBilgi[8]);//hdnBuyuk.Value
                        c.Parameters.AddWithValue("@m_cep", siparisBilgi[7]);//hdnCep.Value
                        c.Parameters.AddWithValue("@m_aile", siparisBilgi[6]);//hdnAile.Value
                        c.Parameters.AddWithValue("@siparis_kagit", siparisBilgi[12]);//hdnKagit.Value
                        c.Parameters.AddWithValue("@sdownloaded", 0);
                        c.Parameters.AddWithValue("@sipuplfrom", 1);
                        c.Parameters.AddWithValue("@siparis_md5", secKey);
                        c.Parameters.AddWithValue("@filehash", fileSHA);
                        c.Parameters.AddWithValue("@m_onay", 1);
                        c.Parameters.AddWithValue("@sipuplrealfilename", Session["fileN"]);
                        c.Parameters.AddWithValue("@yazBuyuk", Session["siparisBuyukEbatYazi"]);//hdnBuyukEbatText.Value
                        c.Parameters.AddWithValue("@sipKapakYazi", Session["siparisKapakYazi"]);//hdnBuyukEbatText.Value
                        c.Parameters.AddWithValue("@m_sipKapak", siparisBilgi[2]);//hdnBuyukEbatText.Value
                        c.Parameters.AddWithValue("@sipSecilenAhsap", Session["ahsap"]);//seçilen ahşap


                        int insertID = Convert.ToInt32(c.ExecuteScalar());
                        c.Dispose();

                        //hdnSipNumber.Value = insertID.ToString();

                        string yeniFileName = insertID.ToString() + Path.GetExtension(fileName).ToString();

                        fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[0]), Convert.ToDouble(siparisFiyatlar[1]), Convert.ToDouble(siparisFiyatlar[2]), 1); // genelToplam
                        fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[3]), Convert.ToDouble(siparisFiyatlar[4]), Convert.ToDouble(siparisFiyatlar[5]), 2); // çalışmalı fiyat
                        fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[6]), Convert.ToDouble(siparisFiyatlar[7]), Convert.ToDouble(siparisFiyatlar[8]), 3); // paket ücreti
                        fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[9]), Convert.ToDouble(siparisFiyatlar[10]), Convert.ToDouble(siparisFiyatlar[11]), 4); // saat fiyat
                        fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[12]), Convert.ToDouble(siparisFiyatlar[13]), Convert.ToDouble(siparisFiyatlar[14]), 5); // kutufiyat
                        fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[15]), Convert.ToDouble(siparisFiyatlar[16]), Convert.ToDouble(siparisFiyatlar[17]), 6); // aile fiyat
                        fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[18]), Convert.ToDouble(siparisFiyatlar[19]), Convert.ToDouble(siparisFiyatlar[20]), 7); // cep fiyat
                        fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[21]), Convert.ToDouble(siparisFiyatlar[22]), Convert.ToDouble(siparisFiyatlar[23]), 8); // büyük fiyat
                        fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[24]), Convert.ToDouble(siparisFiyatlar[25]), Convert.ToDouble(siparisFiyatlar[26]), 9); // çalışmalı fiyat
                        fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[27]), Convert.ToDouble(siparisFiyatlar[28]), Convert.ToDouble(siparisFiyatlar[29]), 10); // kağıt silk vb. fiyat


                        //Session["siparis"] = genelToplam + "$" + genelToplamTam + "$" + genelToplamIskonto + "$"; // 1
                        //Session["siparis"] += calismaliFiyat + "$" + calismaliFiyatTam + "$" + calismaliFiyatIskonto + "$"; // 2
                        //Session["siparis"] += paketFiyat + "$" + paketFiyatTam + "$" + paketFiyatIskonto + "$"; // 3
                        //Session["siparis"] += saatFiyat + "$" + saatFiyatTam + "$" + saatFiyatIskonto + "$"; // 4
                        //Session["siparis"] += kutuFiyat + "$" + kutuFiyatTam + "$" + kutuFiyatIskonto + "$"; // 5
                        //Session["siparis"] += aileFiyat + "$" + aileFiyatTam + "$" + aileFiyatIskonto + "$"; // 6
                        //Session["siparis"] += cepFiyat + "$" + cepFiyatTam + "$" + cepFiyatIskonto + "$"; // 7
                        //Session["siparis"] += buyukFiyat + "$" + buyukFiyatTam + "$" + buyukFiyatIskonto + "$"; // 8
                        //Session["siparis"] += yaprakFiyat + "$" + yaprakFiyatTam + "$" + yaprakFiyatIskonto; // 9

                        // Thread.Sleep(1500);



                        SqlCommand s = new SqlCommand("update siparis set m_filename=@m_filename where id=@id", bag);
                        s.Parameters.AddWithValue("@m_filename", yeniFileName);
                        s.Parameters.AddWithValue("@id", insertID);
                        s.ExecuteNonQuery();

                        s.Dispose();


                        SqlCommand sep = new SqlCommand("insert into sepet(session_id, urun_id, sepet_mid, p_type) values(@session_id, @urun_id, @sepet_mid, @p_type)", bag);
                        sep.Parameters.AddWithValue("@session_id", sessionIDS);
                        sep.Parameters.AddWithValue("@urun_id", siparisBilgi[2]);
                        sep.Parameters.AddWithValue("@sepet_mid", userID);
                        sep.Parameters.AddWithValue("@p_type", 2);

                        sep.ExecuteNonQuery();

                        sep.Dispose();

                        string sqlD = "Select * from siparis where m_id=@_mid and filehash=@_hash and not id=@_id";
                        SqlCommand d = new SqlCommand(sqlD, bag);
                        d.Parameters.AddWithValue("@_mid", userID);
                        d.Parameters.AddWithValue("@_hash", fileSHA);
                        d.Parameters.AddWithValue("@_id", insertID);

                        SqlDataReader rdrD = d.ExecuteReader();
                        rdrD.Read();

                        if (rdrD.HasRows)
                        {
                            SqlCommand dt = new SqlCommand("update siparis set hashprob=@_hashprob, hasprobid=@_hasprobid where id=@nid", bag);
                            dt.Parameters.AddWithValue("@_hashprob", 1);
                            dt.Parameters.AddWithValue("@_hasprobid", rdrD["id"]);
                            dt.Parameters.AddWithValue("@nid", insertID);
                            dt.ExecuteNonQuery();
                            dt.Dispose();

                            siparisTekrar = true;

                        }




                        File.Move(Path.Combine(filePath, fileName), Path.Combine(filePath, yeniFileName));

                        //File.Move(fileName, filePath + "111" + Path.GetExtension(fileName)); // dosya adı değiştirmece

                        if (siparisTekrar == false)
                        {
                            //ltsiparisDoneYazi1.Text = (string)(GetGlobalResourceObject("strings", "siparisDoneYazi1"));
                            ltsiparisDoneYazi2.Text = (string)(GetGlobalResourceObject("strings", "siparisDoneYazi2"));
                            ltsiparisDoneYazi3.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisDoneYazi3")), insertID.ToString());
                            ltsiparisDoneYazi4.Text = (string)(GetGlobalResourceObject("strings", "siparisDoneYazi4"));
                            ltsiparisDoneYazi5.Text = (string)(GetGlobalResourceObject("strings", "siparisDoneYazi5"));

                            //Literal16.Text = Session["fileN"].ToString();

                            //sipDataEnc.Text = Session["siparis"].ToString();
                        }

                        else if (siparisTekrar == true)
                        {
                            //ltsiparisDoneYazi1.Text = (string)(GetGlobalResourceObject("strings", "siparisDoneYazi1"));
                            ltsiparisDoneYazi2.Text = (string)(GetGlobalResourceObject("strings", "siparisDoneYazi2"));
                            ltsiparisDoneYazi3.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisDoneYazi3")), insertID.ToString());
                            ltsiparisDoneYazi4.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisDoneYazi8")), rdrD["m_tarih"].ToString(), rdrD["id"].ToString());
                            ltsiparisDoneYazi5.Text = (string)(GetGlobalResourceObject("strings", "siparisDoneYazi9"));

                            //Literal16.Text = Session["fileN"].ToString();

                            //sipDataEnc.Text = Session["siparis"].ToString();
                        }

                        litKKOdeme.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKKOdeme")), insertID.ToString());
                        sipKKOdeme.HRef = "https://eski.mertalbum.com/paypal_pay.asp?panoramik_odeme=" + secKey;

                        rdrD.Close();
                        d.Dispose();

                        bag.Close();

                    }
                    catch (Exception ex)
                    {

                        Literal18.Text = (string)(GetGlobalResourceObject("strings", "siparisErrYazi1"));
                        Literal19.Text = (string)(GetGlobalResourceObject("strings", "siparisErrYazi2"));
                        Literal20.Text = (string)(GetGlobalResourceObject("strings", "siparisErrYazi3"));
                        Literal20.Text += "</br>" + string.Format((string)(GetGlobalResourceObject("strings", "sistemHataMesaj2")), xmlError.errLog.hataKayit(ex.ToString()));
                        Literal20.Text += "</br>" + (string)(GetGlobalResourceObject("strings", "sistemHataMesaj3"));





                        pnlDone.Visible = false;
                        pnlError.Visible = true;
                        //sipDataEnc.Text = ex.ToString();
                    }


                    ///

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

                Session.Abandon();
            }

        }

    }

    public void BebekSeri()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=7 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptBebek.DataSource = rdr;
                    rptBebek.DataBind();
                }
            }
        }
    }


    public void marioLuigi()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=8 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptMario.DataSource = rdr;
                    rptMario.DataBind();
                }
            }
        }
    }

    public void TrendSeri()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=6 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptTrend.DataSource = rdr;
                    rptTrend.DataBind();
                }
            }
        }
    }
    public void legendNaylaSeri()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=2 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptLegendNayla.DataSource = rdr;
                    rptLegendNayla.DataBind();
                }
            }
        }
    }

    public void standarSerii()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=3 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptStandart.DataSource = rdr;
                    rptStandart.DataBind();
                }
            }
        }
    }

    public void lineSeri()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=4 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptLine.DataSource = rdr;
                    rptLine.DataBind();
                }
            }
        }
    }

    public void loftSeri()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=5 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptLoft.DataSource = rdr;
                    rptLoft.DataBind();
                }
            }
        }
    }


    public void goldSeri()
    {
        using (SqlConnection x = new SqlConnection())
        {
            x.ConnectionString = cstring.ConnStr();
            x.Open();

            using (SqlCommand c = new SqlCommand("Select * from paketolcu where paketolcu_active=1 and paketolcu_tip=1 order by paketolcu_sira ASC", x))
            {
                using (SqlDataReader rdr = c.ExecuteReader())
                {
                    rptGoldSeri.DataSource = rdr;
                    rptGoldSeri.DataBind();
                }
            }
        }
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

        string sql = "SELECT     dbo.currency.currency_id, dbo.currency.currency_simge, dbo.paket.paket_id, dbo.paket.paket_adi_tr, dbo.paket.paket_languageStr, dbo.member.mid, dbo.paket.paket_active, dbo.paket.paket_fotonew, dbo.paket.paket_fiyat, dbo.bolge.bolge_id FROM         dbo.sehir INNER JOIN dbo.member ON dbo.sehir.sehir_id = dbo.member.iltr INNER JOIN                     dbo.ulke ON dbo.sehir.sehir_ulkeid = dbo.ulke.ulke_id INNER JOIN                      dbo.bolge INNER JOIN                      dbo.currency ON dbo.bolge.bolge_currency = dbo.currency.currency_id INNER JOIN                      dbo.paket ON dbo.bolge.bolge_id = dbo.paket.paket_bolge ON dbo.ulke.ulke_bolge = dbo.bolge.bolge_id INNER JOIN                      dbo.paketolcu ON dbo.paket.paket_olcu = dbo.paketolcu.paketolcu_id WHERE(dbo.paket.paket_active = 1) and mid=@musteriID and paket_olcu=@olcuID order by paket_sira_no ASC";

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

            ScriptManager.RegisterStartupScript(this, GetType(), "musteriEkstraSecimler", "moveTo('musteriEkstraSecimler');", true);

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
            regFormErrList.Text = "<p>" + string.Format(GetGlobalResourceObject("strings", "siparisformkapakzorunlu1").ToString(), kapakAdi) + "</p>";

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

                if (secilenSaat != 17)
                {
                    saatOzet.Visible = true;
                    lblOzetSaatAdi.Text = y.extraAdiDon(secilenSaat);
                    lblOzetSaatFiyat.Text = fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenSaat, Convert.ToInt32(musteriID), paraBirimi.ToString(), 1);

                    saatFiyat = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenSaat, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                    saatFiyatTam = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenSaat, Convert.ToInt32(musteriID), paraBirimi.ToString(), 22));
                    saatFiyatIskonto = saatFiyatTam - saatFiyat;

                    genelToplam += Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenSaat, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                    genelToplamTam += saatFiyatTam;

                }

                else
                {
                    saatOzet.Visible = false;
                }

                if (secilenCanta != 16)
                {
                    cantaOzet.Visible = true;
                    lblOzetCantaAdi.Text = y.extraAdiDon(secilenCanta);
                    lblOzetCantaFiyat.Text = fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCanta, Convert.ToInt32(musteriID), paraBirimi.ToString(), 1);


                    kutuFiyat = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCanta, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                    kutuFiyatTam = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCanta, Convert.ToInt32(musteriID), paraBirimi.ToString(), 22));
                    kutuFiyatIskonto = kutuFiyatTam - kutuFiyat;

                    genelToplam += Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenCanta, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                    genelToplamTam += kutuFiyatTam;


                }

                else
                {
                    cantaOzet.Visible = false;
                }

                if (secilenAile != 36)
                {
                    aileOzet.Visible = true;
                    lblOzetAileAdi.Text = y.extraAdiDon(secilenAile);

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
                    aileOzet.Visible = false;
                }

                if (secilenCep != 22)
                {
                    cepOzet.Visible = true;
                    lblOzetCepAdi.Text = y.extraAdiDon(secilenCep);

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
                    cepOzet.Visible = false;
                }

                if (secilenBuyuk != 21)
                {
                    buyukOzet.Visible = true;
                    lblOzetBuyukAdi.Text = y.extraAdiDon(secilenBuyuk);
                    lblOzetBuyukFiyat.Text = fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenBuyuk, Convert.ToInt32(musteriID), paraBirimi.ToString(), 1);

                    buyukFiyat = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenBuyuk, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                    buyukFiyatTam = Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenBuyuk, Convert.ToInt32(musteriID), paraBirimi.ToString(), 22));
                    buyukFiyatIskonto = buyukFiyatTam - buyukFiyat;


                    genelToplam += Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(paketNo, secilenBuyuk, Convert.ToInt32(musteriID), paraBirimi.ToString(), 2));
                    genelToplamTam += buyukFiyatTam;
                }

                else
                {
                    buyukOzet.Visible = false;
                }

                if (calisma1.Checked)
                {
                    calismaOzet.Visible = true;
                    lblOzetCalismaAdi.Text = (string)GetGlobalResourceObject("strings", "siparisCalismaSekliSecim1").ToString();
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
                    lblOzetCalismaFiyat.Text = "<strong class='text-info'>" + calismaFiyat.ToString("N") + " " + paraBirimi + " </strong>";
                }



                sayfaTipiOzet.Visible = true;

                lblOzetSayfaTipi.Text = y.sayfaTipiDon(Convert.ToInt32(drpSayfaTipi.SelectedValue));
                lblOzetSayfaTipiFiyat.Text = "<strong class='text-info'>0,00 " + paraBirimi + "</strong>";


                secilenKapakModeli.Visible = true;

                string[] urunL = paketAlt.paketAlt.kapakModelAdi(secilenKapak).Split('$');

                lblKapakModelAdi.Text = "<a class='gallery-images' rel='fancybox1' href='/images/urunler/" + imageBigger(urunL[1]).ToString() + "'><img src='/images/urunler/" + urunL[1] + "'>" + urunL[0] + "</a>";


                lblKapakModelFiyat.Text = "<strong class='text-info'>0,00 " + paraBirimi + "</strong>";

                buyukEbatYazisi.Visible = true;
                kapakYazisi.Visible = true;
                musteriNotu.Visible = true;
                //siparisBuyukEbatlariniz

                double kagitYuzdesi = 0;
                double kagitYuzdesiTam = 0;

                if (kagit1.Checked)
                {
                    kagitYuzdesi = 0;
                    kagitYuzdesiTam = 0;
                    kagitFiyat = 0;
                    kagitFiyatTam = 0;
                    kagitFiyatIskonto = 0;
                    secilenKagit = 1;
                    lblKagitYazi.Text = (string)GetGlobalResourceObject("strings", "siparisKagitMatYazi");
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
                }

                else if (kagit3.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 3, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 3, 2);
                    secilenKagit = 3;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitSedefYazi"), kagitYuzdesi);
                }

                else if (kagit5.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 5, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 5, 2);
                    secilenKagit = 5;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitKristalYazi"), kagitYuzdesi);
                }

                else if (kagit6.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 6, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 6, 2);
                    secilenKagit = 6;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitMetalikYazi"), kagitYuzdesi);
                }

                else if (kagit7.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 7, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 7, 2);
                    secilenKagit = 7;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitProKristalYazi"), kagitYuzdesi);
                }

                else if (kagit8.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 8, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 8, 2);
                    secilenKagit = 8;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitXMattYazi"), kagitYuzdesi);
                }

                else if (kagit9.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 9, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 9, 2);
                    secilenKagit = 9;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfart270gbrightwhite"), kagitYuzdesi);
                }

                else if (kagit10.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 10, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 10, 2);
                    secilenKagit = 10;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartsatin270gbrightwhite"), kagitYuzdesi);
                }

                else if (kagit11.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 11, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 11, 2);
                    secilenKagit = 11;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartradiant270gwhite"), kagitYuzdesi);
                }

                else if (kagit12.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 12, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 12, 2);
                    secilenKagit = 12;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfarttoscana210gnaturalwhite"), kagitYuzdesi);
                }

                else if (kagit13.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 13, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 13, 2);
                    secilenKagit = 13;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartwatercolour240gnaturalwhite"), kagitYuzdesi);
                }

                else if (kagit14.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 14, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 14, 2);
                    secilenKagit = 14;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartwhitevelvet270gwhite"), kagitYuzdesi);
                }

                else if (kagit15.Checked)
                {
                    kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 15, 1);
                    kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 15, 2);
                    secilenKagit = 15;
                    lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitsofttouch"), kagitYuzdesi);
                }



                kagitFiyat = (paketFiyat + aileFiyat + cepFiyat + yaprakFiyat) / 100 * kagitYuzdesi;
                kagitFiyatTam = (paketFiyatTam + aileFiyatTam + cepFiyatTam + yaprakFiyatTam) / 100 * kagitYuzdesiTam;
                kagitFiyatIskonto = kagitFiyatTam - kagitFiyat;

                genelToplam += kagitFiyat;
                genelToplamTam += kagitFiyatTam;


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


                //Session["siparisBilgiler"] = musteriID + "$" + paketNo + "$" + secilenKapak + "$";
                //Session["siparisBilgiler"] += seciliBolge + "$" + secilenCanta + "$" + secilenSaat + "$";
                //Session["siparisBilgiler"] += secilenAile + "$" + secilenCep + "$" + secilenBuyuk + "$";
                //Session["siparisBilgiler"] += drpSayfaTipi.SelectedValue + "$" + drpYaprakSayisi.SelectedValue + "$" + calismaTyp + "$" + secilenKagit;

                //Session["siparisBuyukEbatYazi"] = txtBuyukEbat.Text;
                //Session["siparisKapakYazi"] = txtKapakYazisi.Text;
                //Session["siparisMusteriNot"] = txtMusteriNotu.Text;

                //Session["ahsap"] = secilenAhsap;


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
        pnlSepet.Visible = false;


        //ScriptManager.RegisterStartupScript(this, GetType(), "outTi1211232", "fade('dosyaGonder');", true);

        //ScriptManager.RegisterStartupScript(this, GetType(), "showT44125123545", "fade('uplForm');", true);

        //uplFormLast.Style["display"] = "block";

        //dosyaFormGoster();
        //ScriptManager.RegisterStartupScript(this, GetType(), "dGonder2222", "moveTo('dosyaGonder');", true);

        try
        {



            pnlDone.Visible = true;


            //sess.Text = Session["siparis"].ToString() + "</br>" + Session["siparisBilgiler"].ToString() + "</br>" + Session["siparisBuyukEbatYazi"].ToString() + "</br>" + Session["siparisKapakYazi"].ToString() + "</br>" + Session["siparisMusteriNot"].ToString() + "</br> FileSHA : " + fileSHA.ToString();

            int calismaTyp = 1;

            if (calisma1.Checked)
            {
                calismaTyp = 1;
            }

            if (calisma2.Checked)
            {
                calismaTyp = 2;
            }



            //


            connectionStr.DBIslem x = new connectionStr.DBIslem();
            SqlConnection bag = x.Baglanti();

            bool siparisTekrar = false;
            Int64 sessionIDS = Convert.ToInt64(fileHasher.rndPassGenerator(18, 0));



            string secKey = fileHasher.rndPassGenerator2(40, 0);

            //string[] siparisBilgi = Session["siparisBilgiler"].ToString().Split('$');
            //string[] siparisFiyatlar = Session["siparis"].ToString().Split('$');


            string sql = "insert into siparis2(m_id, m_paket, session_id, m_tem, sayfa_tipi, m_yaprak, m_fsayi, m_tasarim, m_not, m_tarih, m_tarih2, m_calismasekli, p_album, m_canta, m_kristal, m_saat, m_buyuk, m_cep, m_aile, siparis_kagit, yazBuyuk, sdownloaded, sipuplfrom, siparis_md5, filehash, m_onay, sipuplrealfilename, sipKapakYazi, m_sipKapak, sipSecilenAhsap)values(@m_id, @m_paket, @session_id, @m_tem, @sayfa_tipi, @m_yaprak, @m_fsayi, @m_tasarim, @m_not, @m_tarih, @m_tarih2, @m_calismasekli, @p_album, @m_canta, @m_kristal, @m_saat, @m_buyuk, @m_cep, @m_aile, @siparis_kagit, @yazBuyuk, @sdownloaded, @sipuplfrom, @siparis_md5, @filehash, @m_onay, @sipuplrealfilename, @sipKapakYazi, @m_sipKapak, @sipSecilenAhsap) ;SELECT SCOPE_IDENTITY();";
            SqlCommand c = new SqlCommand(sql, bag);
            c.Parameters.AddWithValue("@m_id", musteriID);
            c.Parameters.AddWithValue("@m_paket", paketNo);//hdnPaket.Value
            c.Parameters.AddWithValue("@session_id", sessionIDS);
            c.Parameters.AddWithValue("@m_tem", 8);
            c.Parameters.AddWithValue("@sayfa_tipi", drpSayfaTipi.SelectedValue);//hdnSayfaTipi.Value
            c.Parameters.AddWithValue("@m_yaprak", drpYaprakSayisi.SelectedValue); //hdnYaprakSayisi.Value
            c.Parameters.AddWithValue("@m_fsayi", 20);
            c.Parameters.AddWithValue("@m_tasarim", "");//Request.Cookies["siparis"]["tasarimSekli"] // hdnTasarimSekli.Value 
            c.Parameters.AddWithValue("@m_not", txtMusteriNotu.Text);
            c.Parameters.AddWithValue("@m_tarih", DateTime.Now.ToString());
            c.Parameters.AddWithValue("@m_tarih2", DateTime.Now);
            c.Parameters.AddWithValue("@m_calismasekli", calismaTyp);//hdnCalisma.Value
            c.Parameters.AddWithValue("@p_album", calismaTyp);//hdnPAlbum.Value
            c.Parameters.AddWithValue("@m_canta", secilenCanta);// hdnCanta.Value
            c.Parameters.AddWithValue("@m_kristal", 0);
            c.Parameters.AddWithValue("@m_saat", secilenSaat); //hdnSaat.Value
            c.Parameters.AddWithValue("@m_buyuk", secilenBuyuk);//hdnBuyuk.Value
            c.Parameters.AddWithValue("@m_cep", secilenCep);//hdnCep.Value
            c.Parameters.AddWithValue("@m_aile", secilenAile);//hdnAile.Value
            c.Parameters.AddWithValue("@siparis_kagit", secilenKagit);//hdnKagit.Value
            c.Parameters.AddWithValue("@sdownloaded", 0);
            c.Parameters.AddWithValue("@sipuplfrom", 1);
            c.Parameters.AddWithValue("@siparis_md5", secKey);
            c.Parameters.AddWithValue("@filehash", "");
            c.Parameters.AddWithValue("@m_onay", 1);
            c.Parameters.AddWithValue("@sipuplrealfilename", "");
            c.Parameters.AddWithValue("@yazBuyuk", txtBuyukEbat.Text);//hdnBuyukEbatText.Value
            c.Parameters.AddWithValue("@sipKapakYazi", txtKapakYazisi.Text);//hdnBuyukEbatText.Value
            c.Parameters.AddWithValue("@m_sipKapak", secilenKapak);//hdnBuyukEbatText.Value
            c.Parameters.AddWithValue("@sipSecilenAhsap", 0);//seçilen ahşap


            int insertID = Convert.ToInt32(c.ExecuteScalar());
            c.Dispose();

            //hdnSipNumber.Value = insertID.ToString();


            //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[0]), Convert.ToDouble(siparisFiyatlar[1]), Convert.ToDouble(siparisFiyatlar[2]), 1); // genelToplam
            //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[3]), Convert.ToDouble(siparisFiyatlar[4]), Convert.ToDouble(siparisFiyatlar[5]), 2); // çalışmalı fiyat
            //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[6]), Convert.ToDouble(siparisFiyatlar[7]), Convert.ToDouble(siparisFiyatlar[8]), 3); // paket ücreti
            //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[9]), Convert.ToDouble(siparisFiyatlar[10]), Convert.ToDouble(siparisFiyatlar[11]), 4); // saat fiyat
            //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[12]), Convert.ToDouble(siparisFiyatlar[13]), Convert.ToDouble(siparisFiyatlar[14]), 5); // kutufiyat
            //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[15]), Convert.ToDouble(siparisFiyatlar[16]), Convert.ToDouble(siparisFiyatlar[17]), 6); // aile fiyat
            //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[18]), Convert.ToDouble(siparisFiyatlar[19]), Convert.ToDouble(siparisFiyatlar[20]), 7); // cep fiyat
            //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[21]), Convert.ToDouble(siparisFiyatlar[22]), Convert.ToDouble(siparisFiyatlar[23]), 8); // büyük fiyat
            //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[24]), Convert.ToDouble(siparisFiyatlar[25]), Convert.ToDouble(siparisFiyatlar[26]), 9); // çalışmalı fiyat
            //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(siparisFiyatlar[27]), Convert.ToDouble(siparisFiyatlar[28]), Convert.ToDouble(siparisFiyatlar[29]), 10); // kağıt silk vb. fiyat


            //Session["siparis"] = genelToplam + "$" + genelToplamTam + "$" + genelToplamIskonto + "$"; // 1
            //Session["siparis"] += calismaliFiyat + "$" + calismaliFiyatTam + "$" + calismaliFiyatIskonto + "$"; // 2
            //Session["siparis"] += paketFiyat + "$" + paketFiyatTam + "$" + paketFiyatIskonto + "$"; // 3
            //Session["siparis"] += saatFiyat + "$" + saatFiyatTam + "$" + saatFiyatIskonto + "$"; // 4
            //Session["siparis"] += kutuFiyat + "$" + kutuFiyatTam + "$" + kutuFiyatIskonto + "$"; // 5
            //Session["siparis"] += aileFiyat + "$" + aileFiyatTam + "$" + aileFiyatIskonto + "$"; // 6
            //Session["siparis"] += cepFiyat + "$" + cepFiyatTam + "$" + cepFiyatIskonto + "$"; // 7
            //Session["siparis"] += buyukFiyat + "$" + buyukFiyatTam + "$" + buyukFiyatIskonto + "$"; // 8
            //Session["siparis"] += yaprakFiyat + "$" + yaprakFiyatTam + "$" + yaprakFiyatIskonto; // 9

            // Thread.Sleep(1500);




            //File.Move(fileName, filePath + "111" + Path.GetExtension(fileName)); // dosya adı değiştirmece


                //ltsiparisDoneYazi1.Text = (string)(GetGlobalResourceObject("strings", "siparisDoneYazi1"));
                ltsiparisDoneYazi2.Text = "<h4>" + (string)(GetGlobalResourceObject("strings", "siparisDoneYazi2")) + "</h4>";
                ltsiparisDoneYazi3.Text = "<h4>" + string.Format((string)(GetGlobalResourceObject("strings", "siparisDoneYazi3")), insertID.ToString()) + "</h4>";
                ltsiparisDoneYazi4.Text = "<h4>" + (string)(GetGlobalResourceObject("strings", "siparisDoneYazi4")) + "</h4>";
                ltsiparisDoneYazi5.Text = "<h4>" + (string)(GetGlobalResourceObject("strings", "siparisDoneYazi5")) + "</h4>";

                Literal8.Text = "<h2>Dosyanızı Yüklemek İçin Buraya Tıklayın</h2>";
                A1.HRef = "/uye-sayfam/siparisyukle?yukle=" + pwdHash.passwordHash.Sifrele(insertID.ToString());

                //Literal16.Text = Session["fileN"].ToString();

            //sipDataEnc.Text = Session["siparis"].ToString();




            litKKOdeme.Text = string.Format((string)(GetGlobalResourceObject("strings", "siparisKKOdeme")), insertID.ToString());
            sipKKOdeme.HRef = "https://www.cizgialbum.com/paypal_pay.asp?panoramik_odeme=" + secKey;



            bag.Close();

        }
        catch (Exception ex)
        {

            Literal18.Text = (string)(GetGlobalResourceObject("strings", "siparisErrYazi1"));
            Literal19.Text = (string)(GetGlobalResourceObject("strings", "siparisErrYazi2"));
            Literal20.Text = (string)(GetGlobalResourceObject("strings", "siparisErrYazi3"));
            Literal20.Text += "</br>" + string.Format((string)(GetGlobalResourceObject("strings", "sistemHataMesaj2")), xmlError.errLog.hataKayit(ex.ToString()));
            Literal20.Text += "</br>" + (string)(GetGlobalResourceObject("strings", "sistemHataMesaj3"));





            pnlDone.Visible = false;
            pnlError.Visible = true;
            //sipDataEnc.Text = ex.ToString();
        }



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

        if (id == 278)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/magazinnew.jpg' /></div><br/> ";
        }

        if (id == 17 || id == 34 || id == 464)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/legendnew.jpg' /></div><br/> ";
        }

        if (id == 1 || id == 18 || id == 472)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/naylanew.jpg' /></div><br/> ";
        }

        if (id == 194 || id == 1339 || id == 1341 || id == 1343 || id == 1345 || id == 1347)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/bellanew.jpg' /></div><br/> ";
        }

        if (id == 660 || id == 780 || id == 834 || id == 479 || id == 988)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/beltnicenew.jpg' /></div><br/> ";
        }

        if (id == 46 || id == 668 || id == 842 || id == 487 || id == 996)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/borredn.jpg' /></div><br/> ";
        }

        if (id == 112 || id == 494 || id == 675 || id == 788 || id == 849 || id == 1003)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/branchnew.jpg' /></div><br/> ";
        }

        if (id == 504 || id == 685 || id == 859 || id == 1013)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/camilanew.jpg' /></div><br/> ";
        }

        if (id == 148 || id == 511 || id == 692 || id == 1335 || id == 866 || id == 1020)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/casvalnew.jpg' /></div><br/> ";
        }

        if (id == 516 || id == 871 || id == 1025)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/diananew.jpg' /></div><br/> ";
        }

        if (id == 208 || id == 1326 || id == 524 || id == 1033)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/dorenew.jpg' /></div><br/> ";
        }

        if (id == 105 || id == 539 || id == 701 || id == 801 || id == 882 || id == 1048)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/flayernew.jpg' /></div><br/> ";
        }

        if (id == 162 || id == 544 || id == 887 || id == 1053)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/lenanew.jpg' /></div><br/> ";
        }

        if (id == 549 || id == 1058 || id == 1629 || id == 1640)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/lifenew.jpg' /></div><br/> ";
        }

        if (id == 556 || id == 705 || id == 892 || id == 1065)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/likapanew.jpg' /></div><br/> ";
        }

        if (id == 1384 || id == 1391 || id == 1398 || id == 1405 || id == 1412)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/lotusnew.jpg' /></div><br/> ";
        }

        if (id == 1369 || id == 1373 || id == 1377 || id == 1381)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/milenanew.jpg' /></div><br/> ";
        }

        if (id == 1743 || id == 1746 || id == 1749 || id == 1752 || id == 1755)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/nirvananew.jpg' /></div><br/> ";
        }

        if (id == 590 || id == 739 || id == 805 || id == 926 || id == 1099)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/polonew.jpg' /></div><br/> ";
        }

        if (id == 613 || id == 754 || id == 941 || id == 1122 || id == 1614)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/rivernew.jpg' /></div><br/> ";
        }

        if (id == 620 || id == 948 || id == 1129)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/tinanew.jpg' /></div><br/> ";
        }

        //if (id == 182)
        //{
        //    donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/tina.jpg' /></div><br/> ";
        //}

        if (id == 129 || id == 629 || id == 761 || id == 820 || id == 957 || id == 1138)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/treenew.jpg' /></div><br/> ";
        }

        if (id == 1464 || id == 1471 || id == 1478 || id == 1485)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/violetnew.jpg' /></div><br/> ";
        }

        if (id == 1304 || id == 1308 || id == 1312 || id == 1316)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/viyolanew.jpg' /></div><br/> ";
        }

        if (id == 173)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/violet.jpg' /></div><br/> ";
        }

        if (id == 1420 || id == 1427 || id == 1452 || id == 1434 || id == 1441 )
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/wickernew.jpg' /></div><br/> ";
        }

        if (id == 528 || id == 1037)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/elenornew.jpg' /></div><br/> ";
        }

        if (id == 605 || id == 1114)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/ridaknew.jpg' /></div><br/> ";
        }

        if (id == 263)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/summer.jpg' /></div><br/> ";
        }

        if (id == 1694 || id == 1696 || id == 1698 || id == 1700)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/lorinnew.jpg' /></div><br/> ";
        }

        if (id == 279)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/loftnew.jpg' /></div><br/> ";
        }

		        if (id == 330)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/pulley.jpg' /></div><br/> ";
        }

		        if (id == 337 || id == 598 || id == 747 || id == 813 || id == 934 || id == 1107)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/retronew.jpg' /></div><br/> ";
        }

		        if (id == 317)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/bondigo.jpg' /></div><br/> ";
        }

		        if (id == 324)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/tanny.jpg' /></div><br/> ";
        }

		        if (id == 345)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/aresnew.jpg' /></div><br/> ";
        }

		        if (id == 351)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/bianca-beyaz.jpg' /></div><br/> ";
        }

		        if (id == 394)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/bianca-ceviz.jpg' /></div><br/> ";
        }
		
		        if (id == 405)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/bianca-siyah.jpg' /></div><br/> ";
        }

		        if (id == 362)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/perla-beyaz.jpg' /></div><br/> ";
        }

		        if (id == 416)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/perla-ceviz.jpg' /></div><br/> ";
        }

				if (id == 427)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/perla-siyah.jpg' /></div><br/> ";
        }

				if (id == 373)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/queennew.jpg' /></div><br/> ";
        }

				if (id == 384)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/summernew.jpg' /></div><br/> ";
        }

				if (id == 439 || id == 1688)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/bostonnew.jpg' /></div><br/> ";
        }

				if (id == 441)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/pulleyn.jpg' /></div><br/> ";
        }

				if (id == 448)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/bondigonew.jpg' /></div><br/> ";
        }

				if (id == 456)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/tannynew.jpg' /></div><br/> ";
        }

				if (id == 1163)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/marionew.jpg' /></div><br/> ";
        }

				if (id == 1172)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/luiginew.jpg' /></div><br/> ";
        }

		if (id == 1211 || id == 1218 || id == 1225 || id == 1232)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/elissenew.jpg' /></div><br/> ";
        }

		if (id == 1181 || id == 1188 || id == 1195 || id == 1202)
        {
            donus = "<div class='clearfix'></div><div style='clear:left'; margin:0px 7px 12px 14px' class='text-center'><img src='/images/uruns/oteosnew.jpg' /></div><br/> ";
        }


        return donus;

        // 
    }

        public string imageYol (string dosyaAdi)
    {
        return "/images/urunler/" + dosyaAdi;
    }
}