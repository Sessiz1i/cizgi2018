using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using fiyatlar;
using pwdHash;
using System.Text;
using System.Collections.Specialized;
using SqlConnections;

public partial class cardtest2 : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Cookies["assc"] == null)
        {
            //Response.Redirect("/uye-giris");
            if (Request.QueryString["odeme"] != null)
            {
                Response.Redirect("/uye-giris" + "?r=/siparis-odeme?odeme=" + Request.QueryString["odeme"]);
            }

            else
            {
                Response.Redirect("/uye-giris");
            }
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

    public int dbSiparisNo
    {
        get
        {
            if (this.ViewState["dbSiparisNo"] == null)
                return 0;

            return (int)this.ViewState["dbSiparisNo"];
        }
        set { this.ViewState["dbSiparisNo"] = value; }
    }

    public int webSiparisOdeme
    {
        get
        {
            if (this.ViewState["webSiparisOdeme"] == null)
                return 0;

            return (int)this.ViewState["webSiparisOdeme"];
        }
        set { this.ViewState["webSiparisOdeme"] = value; }
    }

    public int indirimliOdeme
    {
        get
        {
            if (this.ViewState["indirimliOdeme"] == null)
                return 0;

            return (int)this.ViewState["indirimliOdeme"];
        }
        set { this.ViewState["indirimliOdeme"] = value; }
    }

    public string toplamFiyat
    {
        get
        {
            if (this.ViewState["toplamFiyat"] == null)
                return "0";

            return (string)this.ViewState["toplamFiyat"];
        }
        set { this.ViewState["toplamFiyat"] = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Kredi Kartı Ödeme Sayfası";

        if (!Page.IsPostBack)
        {

            if (Request.QueryString["odeme"] != null)
            {

                string sifreli  ;

                try
                {
                    sifreli = pwdHash.passwordHash.SifreCoz2(Request.QueryString["odeme"]);
                }
                catch (Exception)
                {
                    sifreli = "hata";

                    pnlAna.Visible = false;
                    pnlHata.Visible = true;

                    lblHataSayfa.Text =
                        "<h3 class='text-danger'>Adres satırına müdahale ettiniz veya tıkladığınız sipariş numarası bulunamadı.</h3>";
                }
                

                

                int errCode = 0;



                try
                {
                    int.TryParse(sifreli, out errCode);
                }
                catch (Exception)
                {
                    errCode = 0;
                }

                litsiparisozetii.Text = sifreli + " " + errCode;

                if (errCode > 0)
                {
                    try
                    {
                        pnlAna.Visible = true;
                        pnlHata.Visible = false;

                        dbSiparisNo = errCode;

                        siparisBilgileriGetir();
                        mesafeliSozlesme();


                        HttpContext contexts = HttpContext.Current;

                        //if (!string.IsNullOrEmpty(contexts.Items["siparisID"].ToString()) && !string.IsNullOrEmpty(contexts.Items["tutar"].ToString()) && !string.IsNullOrEmpty(contexts.Items["durum"].ToString()) && !string.IsNullOrEmpty(contexts.Items["isim"].ToString()))

                        if (Request.QueryString["s"] != null)
                        {

                            using (SqlConnection x = new SqlConnection())
                            {
                                x.ConnectionString = cstring.ConnStr();
                                x.Open();

                                //string sipSql = "Select * from ppipn where ppipn_siparis_id=@ppipn_siparis_id";

                                //SqlCommand sd = new SqlCommand(sipSql, bag);
                                //sd.Parameters.AddWithValue("@ppipn_siparis_id", dbSiparisNo);



                                using (SqlCommand c = new SqlCommand("Select * from ppipn where ppipn_siparis_id=@ppipn_siparis_id", x))
                                {
                                    c.Parameters.AddWithValue("@ppipn_siparis_id", dbSiparisNo);

                                    using (SqlDataReader rdr = c.ExecuteReader())
                                    {
                                        

                                        if (rdr.HasRows)
                                        {
                                            rdr.Read();

                                            cardCekildi.Visible = true;
                                            cardBasarisiz.Visible = false;

                                            lblBasarili.Text = "Sayın " + rdr["ppipn_first_name"].ToString() + ", " + rdr["ppipn_siparis_id"] + " numaralı siparişiniz için kartınızdan " +
                                                               rdr["ppipn_payment_amount"] + " TL tutarında çekim başarılı olmuştur.";
                                            lblBasarisiz.Text = "";

                                            litHataTitle.Text = "Başarılı";

                                            regFormErrList.Text = "<p><strong class='text-info'>Sayın " + rdr["ppipn_first_name"].ToString() + ", " + rdr["ppipn_siparis_id"] + " numaralı siparişiniz için kartınızdan " + rdr["ppipn_payment_amount"] + " TL tutarında çekim başarılı olmuştur.</strong></p>";
                                            //regFormErrList.Text += "<p class='text-danger'><strong>Genel Toplam = " + toplamFiyat + "</strong></p>";
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp1512351235", "openModal();", true);
                                        }

                                        else
                                        {
                                            cardCekildi.Visible = false;
                                            cardBasarisiz.Visible = true;
                                            lblBasarisiz.Text = "Kartınızdan çekim yapılamadı, lütfen bilgilerinizi kontrol ederek tekrar deneyiniz.";
                                            lblBasarili.Text = "";

                                            litHataTitle.Text = "Hata";
                                            regFormErrList.Text = "<p class='text-danger'><strong>Kartınızdan çekim yapılamadı, lütfen bilgilerinizi kontrol ederek tekrar deneyiniz.</strong></p>";
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp151262131235", "openModal();", true);
                                        }

                                        this.Controls.Add(new LiteralControl("<script type='text/javascript'>openModal();</script>"));
                                    }
                                }
                            }
                        }

                        else
                        {
                            
                        }
                        //Response.Write(cntx.Items["name"]);
                        //Response.Write(cntx.Items["password"]);

                        litsiparisozetii.Text = dbSiparisNo.ToString() + " Numaralı Siparişinizin Bilgileri";

                        for (int i = 1; i < 13; i++)
                        {
                            string z = "";

                            if (i.ToString().Length != 2)
                            {
                                z = "0" + i.ToString();
                            }

                            else
                            {
                                z = i.ToString();
                            }



                            drpCardAy.Items.Insert(-1 + i, new ListItem(z, z));
                        }

                        int ilkyil = DateTime.Now.Year;
                        int yil = Convert.ToInt32(ilkyil.ToString().Substring(2, 2));
                        int yil2 = Convert.ToInt32(ilkyil.ToString().Substring(2,2)) + 21;
                     //   lblhata.Text = yil.ToString();
                        int yindex = 0;

                        for (int i = yil; i < yil2; i++)
                        {
                            drpCardYil.Items.Insert(yindex, new ListItem(i.ToString(), i.ToString()));
                            yindex++;
                        }

                        DropCardBank.Items.Insert(0, new ListItem("Bankanızı seçin", "0"));
                        DropCardBank.Items.Insert(1, new ListItem("Halbank A.Ş", "1"));
                        DropCardBank.Items.Insert(2, new ListItem("Diğer banka", "2"));
                    }
                    catch (Exception hata)
                    {
                        pnlHata.Visible = true;
                        pnlAna.Visible = false;

                        lblHataSayfa.Text =
                            "<h3 class='text-danger'>Adres satırına müdahale ettiniz veya tıkladığınız sipariş numarası bulunamadı.</h3>" + hata;

                    //    litsiparisozetii.Text = hata.ToString();
                    }

               }
            }
        }
    }

    //protected void btnFormuGonder_Click(object sender, EventArgs e)
    //{
    //    Label1.Text = txtCardNumber.Text.Replace(" ","");

    //    litHataTitle.Text = "Bilgilendirme";
    //    regFormErrList.Text = "<p class='text-danger'><strong>Kredi kartı ödeme sayfası test aşamasında olduğu için henüz aktif edilmemiştir.</strong></p>";
    //    regFormErrList.Text += "<p class='text-danger'><strong>Kredi kartı ile ödeme ileriki günlerde aktif olacaktır.</strong></p>";
    //    regFormErrList.Text += "<p class='text-danger'><strong>Ödeme sayfamız aktif olduğunda buradan kredi kartı ile ödeme yapabilirsiniz.</strong></p>";


    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp151235", "openModal();", true);
    //}

    protected void DropCardBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(DropCardBank.SelectedValue) == 0)
        {
            halkbankSecimler.Visible = false;
            digerBankaSecimler.Visible = false;
            rdnHalkbankTekCekim.Checked = false;
            //rdnHalkbankTaksit3.Checked = false;
            //rdnHalkbankTaksit6.Checked = false;
            rdnDigerBankaTekCekim.Checked = false;

        }

        else if (Convert.ToInt32(DropCardBank.SelectedValue) == 1)
        {
            halkbankSecimler.Visible = true;
            digerBankaSecimler.Visible = false;
            rdnDigerBankaTekCekim.Checked = false;
        }

        else if (Convert.ToInt32(DropCardBank.SelectedValue) == 2)
        {
            halkbankSecimler.Visible = false;
            digerBankaSecimler.Visible = true;
            rdnHalkbankTekCekim.Checked = false;
            //rdnHalkbankTaksit3.Checked = false;
            //rdnHalkbankTaksit6.Checked = false;
        }
    }

    protected void btnFormuGonder_Click(object sender, EventArgs e)
    {
        regFormErrList.Text = "";

        bool hataVar = false;

        string cardStr = txtCardNumber.Text.Replace(" ", "");
        cardStr = cardStr.Replace("e", "");

        string cvcNumarasi = CVC.Text.Replace(" ", "");
        cvcNumarasi = cvcNumarasi.Replace("e", "");

        Int64 kartNo = 0;

        int cvcNo = 0;

        try
        {
            Int64.TryParse(cardStr.ToString(), out kartNo);
        }
        catch (Exception)
        {
            kartNo = 0;
        }


        try
        {
            int.TryParse(cvcNumarasi.ToString(), out cvcNo);
        }
        catch (Exception)
        {
            cvcNo = 0;
        }

        if (txtCardHolder.Text.Length < 1)
        {
            regFormErrList.Text += "<p class='text-danger'><strong>Lütfen kredi kartınızın üzerinde yazan adınızı ve soyadınızı girin.</strong></p>";
            hataVar = true;
        }


        if (kartNo == 0)
        {
            regFormErrList.Text += "<p class='text-danger'><strong>Kredi kartı numarası sadece sayılardan oluşabilir.</strong></p>";
            hataVar = true;
        }

        if (kartNo.ToString().Length < 15)
        {
            regFormErrList.Text += "<p class='text-danger'><strong>Kredi kartı numarası en az 15 rakam olmalıdır.</strong></p>";
            hataVar = true;
        }

        if (!visa.Checked && !masterCard.Checked)
        {
            regFormErrList.Text += "<p class='text-danger'><strong>Kart tipini seçmediniz.</strong></p>";
            hataVar = true;
        }

        if (cvcNo == 0)
        {
            regFormErrList.Text += "<p class='text-danger'><strong>CVC numarası sadece sayılardan oluşabilir.</strong></p>";
            hataVar = true;
        }

        //if (cvcNo.ToString().Length < 3)
        //{
        //    regFormErrList.Text += "<p class='text-danger'><strong>CVC numarası en az 3 rakam olmalıdır.</strong></p>";
        //    hataVar = true;
        //}

        if (Convert.ToInt32(DropCardBank.SelectedValue) == 0)
        {
            regFormErrList.Text += "<p class='text-danger'><strong>Lütfen bankanızı seçiniz.</strong></p>";
            hataVar = true;
        }

        if (!rdnHalkbankTekCekim.Checked && !rdnDigerBankaTekCekim.Checked)
        {
            regFormErrList.Text += "<p class='text-danger'><strong>Tek çekim veya taksitli ödeme tipini seçmediniz.</strong></p>";
            hataVar = true;
        }

        if (!chkMesafeliSatisSozlesme.Checked)
        {
            regFormErrList.Text += "<p class='text-danger'><strong>Mesafeli satış sözleşmesini okuyup kabul etmelisiniz.</strong></p>";
            hataVar = true;
        }

        //   Label1.Text = txtCardNumber.Text.Replace(" ", "");



        connectionStr.DBIslem x = new connectionStr.DBIslem();

        SqlConnection bag = x.Baglanti();

        string sipSql = "Select * from ppipn where ppipn_siparis_id=@ppipn_siparis_id";

        SqlCommand sd = new SqlCommand(sipSql, bag);
        sd.Parameters.AddWithValue("@ppipn_siparis_id", dbSiparisNo);

        SqlDataReader sr = sd.ExecuteReader();


        if (sr.HasRows)
        {
            sr.Read();
            regFormErrList.Text = "<p class='text-danger'><strong>Sayın "+  sr["ppipn_first_name"] + ",</strong></p>";
            regFormErrList.Text += "<p class='text-danger'><strong>" + sr["ppipn_siparis_id"] + " numaralı siparişiniz ödemesi daha önce, " + sr["ppipn_payment_date_tr"] + " tarihinde " + sr["ppipn_payment_amount"] + " TL olarak yapılmıştır. </strong></p>"; 

            hataVar = true;
        }

        sr.Close();
        sr.Dispose();
        sd.Dispose();
        bag.Close();
        bag.Dispose();


        if (regFormErrList.Text.Length > 0) // herhangi bir hata var mı ?
        {
            litHataTitle.Text = "Hata";
            //regFormErrList.Text += "<p class='text-danger'><strong>Genel Toplam = " + toplamFiyat + "</strong></p>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp151235", "openModal();", true);

            // regFormErrList.Text = "";
            //lblhata.Text = "Hata : " + regFormErrList.Text;
        }

        else
        {
         //   lblhata.Text = "Hata : " +  regFormErrList.Text;
            try
            {

                //Response.Redirect("/test.aspx");
                string pan = txtCardNumber.Text;
                string Ecom_Payment_Card_ExpDate_Month = drpCardAy.SelectedValue;
                string Ecom_Payment_Card_ExpDate_Year = drpCardYil.SelectedValue;
                string lang = "tr";
                string currency = "949";
                string storetype = "3d_pay";
                string cv2 = CVC.Text;

                //                string postUrl = "https://entegrasyon.asseco-see.com.tr/fim/est3Dgate";
                //                string clientId = "500200000";

                string postUrl = "https://sanalpos.halkbank.com.tr/fim/est3Dgate";
                string clientId = "500383489";
                string amount = "1,29";
                string oid = "CIZGIPAN" + dbSiparisNo;
                string okUrl = "https://www.cizgialbum.com/postche2.aspx";
                string failUrl = "https://www.cizgialbum.com/postche2.aspx";
                string rnd = DateTime.Now.ToString();
                string taksit = "";
                string islemtipi = "Auth";
                string storekey = "42OvKfKU1FD0Q4Sd5hhJ4a";
                string hashstr = clientId + oid + amount + okUrl + failUrl + islemtipi
                                 + taksit + rnd + storekey;
                System.Security.Cryptography.SHA1 sha = new
                    System.Security.Cryptography.SHA1CryptoServiceProvider();
                byte[] hashbytes = System.Text.Encoding.GetEncoding("ISO-8859-9").GetBytes(hashstr);
                byte[] inputbytes = sha.ComputeHash(hashbytes);
                string hash = Convert.ToBase64String(inputbytes);

                Session["clientId"] = clientId;
                Session["amount"] = amount;
                Session["oid"] = oid;
                Session["okUrl"] = okUrl;
                Session["failUrl"] = failUrl;
                Session["rnd"] = rnd;
                Session["hash"] = hash;
                Session["islemtipi"] = islemtipi;
                Session["taksit"] = taksit;
                Session["storetype"] = storetype;
                Session["lang"] = lang;
                Session["currency"] = currency;
                Session["pan"] = pan;
                Session["Ecom_Payment_Card_ExpDate_Month"] = Ecom_Payment_Card_ExpDate_Month;
                Session["Ecom_Payment_Card_ExpDate_Year"] = Ecom_Payment_Card_ExpDate_Year;
                Session["cv2"] = cv2;
                Session["ccisim"] = txtCardHolder.Text;
                Session["sipNumber"] = dbSiparisNo;


                try
                {
                    using (SqlConnection ccbag = new SqlConnection())
                    {
                        ccbag.ConnectionString = cstring.ConnStr();
                        ccbag.Open();

                        using (SqlCommand ng = new SqlCommand("select * from cardapi where cardapi_sipno=@sipno", ccbag))
                        {
                            ng.Parameters.AddWithValue("@sipno", dbSiparisNo);

                            SqlDataReader rd = ng.ExecuteReader();

                            if (rd.HasRows)
                            {
                                rd.Read();

                                if (Convert.ToInt32(rd["cardapi_cekildi"]) == 0)
                                {
                                    using (SqlCommand ng1 = new SqlCommand("update cardapi set cardapi_tarih=@cardapi_tarih, cardapi_isim=@cardapi_isim, cardapi_ipadr=@cardapi_ipadr, cardapi_tutar=@cardapi_tutar, cardapi_deneme=@cardapi_deneme where cardapi_sipno=@cardapi_sipno", ccbag))
                                    {
                                        ng1.Parameters.AddWithValue("@cardapi_tarih", DateTime.Now);
                                        ng1.Parameters.AddWithValue("@cardapi_isim", txtCardHolder.Text);
                                        ng1.Parameters.AddWithValue("@cardapi_ipadr", GetIp());
                                        ng1.Parameters.AddWithValue("@cardapi_tutar", amount);
                                        ng1.Parameters.AddWithValue("@cardapi_sipno", dbSiparisNo);
                                        ng1.Parameters.AddWithValue("@cardapi_deneme", 0);
                                        ng1.ExecuteNonQuery();
                                    }
                                }
                            }

                            else
                            {
                                using (SqlCommand ng1 = new SqlCommand("insert into cardapi (cardapi_sipno, cardapi_banksipno, cardapi_tarih, cardapi_isim, cardapi_ipadr, cardapi_tutar) values(@cardapi_sipno, @cardapi_banksipno, @cardapi_tarih, @cardapi_isim, @cardapi_ipadr, @cardapi_tutar)", ccbag))
                                {
                                    ng1.Parameters.AddWithValue("@cardapi_sipno", dbSiparisNo);
                                    ng1.Parameters.AddWithValue("@cardapi_banksipno", oid);
                                    ng1.Parameters.AddWithValue("@cardapi_tarih", DateTime.Now);
                                    ng1.Parameters.AddWithValue("@cardapi_isim", txtCardHolder.Text);
                                    ng1.Parameters.AddWithValue("@cardapi_ipadr", GetIp());
                                    ng1.Parameters.AddWithValue("@cardapi_tutar", amount);
                                    ng1.ExecuteNonQuery();
                                }
                            }
                        }

                        using (SqlCommand ng2 = new SqlCommand("update siparis set siparisindirimliodeme=@siparisindirimliodeme where id=@id", ccbag))
                        {
                            ng2.Parameters.AddWithValue("@siparisindirimliodeme", 1);
                            ng2.Parameters.AddWithValue("@id", dbSiparisNo);
                            ng2.ExecuteNonQuery();
                        }

                    }
                }
                catch (Exception)
                {




                    
                }



                if (visa.Checked)
                {
                    Session["cardType"] = "1";
                }

                if (masterCard.Checked)
                {
                    Session["cardType"] = "2";
                }
                else
                {
                    Session["cardType"] = "1";
                }


                Response.Redirect("/bank-poster");
                //NameValueCollection collections = new NameValueCollection();
                //collections.Add("clientId", clientId.Trim());
                //collections.Add("amount", amount.Trim());
                //collections.Add("oid", oid.Trim());
                //collections.Add("okUrl", okUrl.Trim());
                //collections.Add("failUrl", failUrl.Trim());
                //collections.Add("rnd", rnd.Trim());
                //collections.Add("hash", hash);
                //collections.Add("islemtipi", islemtipi.Trim());
                //collections.Add("taksit", taksit.Trim());
                //collections.Add("storetype", storetype.Trim());
                //collections.Add("lang", lang.Trim());
                //collections.Add("currency", currency.Trim());
                //string remoteUrl = postUrl;

                //string html = "<html><head>";
                //html += "</head><body onload='document.forms[1].submit()'>";
                //html += string.Format("<form name='formhb' method='POST' action='{0}'>", postUrl);
                //foreach (string key in collections.Keys)
                //{
                //    html += string.Format("<input type='hidden' name='{0}' value='{1}'>", key, collections[key]);
                //}
                //html += string.Format("<input type='text' name='{0}' value='{1}'>", "pan", pan);
                //html += string.Format("<input type='text' name='{0}' value='{1}'>", "Ecom_Payment_Card_ExpDate_Month", Ecom_Payment_Card_ExpDate_Month);
                //html += string.Format("<input type='text' name='{0}' value='{1}'>", "Ecom_Payment_Card_ExpDate_Year", Ecom_Payment_Card_ExpDate_Year);
                //html += "</form></body></html>";
                //Response.Clear();
                //Response.ContentEncoding = Encoding.GetEncoding("utf-8");
                //Response.HeaderEncoding = Encoding.GetEncoding("utf-8");
                //Response.Charset = "utf-8";
                //Response.Write(html);
                //Response.End();

                //lblhata.Text = html;
                //this.Controls.Add(new LiteralControl(html));
                //RemotePost myremotepost = new RemotePost();
                //myremotepost.Url = "http://localhost/post.aspx";
                //myremotepost.Add("field1", "Huckleberry");
                //myremotepost.Add("field2", "Finn");
                //myremotepost.Post();

                //RedirectAndPOST(this.Page);

            }
            catch (Exception exception)
            {
                litHataTitle.Text = "Hata";
                regFormErrList.Text += "<p class='text-danger'><strong>Genel Toplam = " + exception.ToString() + "</strong></p>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp1512354", "openModal();", true);
            }
        }

        

        //litHataTitle.Text = "Bilgilendirme";
        //regFormErrList.Text += "<p class='text-info'><strong>Kredi kartı ödeme sayfası test aşamasında olduğu için henüz aktif edilmemiştir.</strong></p>";
        //regFormErrList.Text += "<p class='text-info'><strong>Kredi kartı ile ödeme ileriki günlerde aktif olacaktır.</strong></p>";
        //regFormErrList.Text += "<p class='text-info'><strong>Ödeme sayfamız aktif olduğunda buradan kredi kartı ile ödeme yapabilirsiniz.</strong></p>";




    }

    //public static void RedirectAndPOST(Page page)
    //{
    //    NameValueCollection data = new NameValueCollection();
    //    data.Add("cmd", "_xclick");
    //    data.Add("business", "mail@msn.com");

    //    //Prepare the Posting form
    //    string strForm = PreparePOSTForm("https://localhost/sontest", data);

    //    //Add a literal control the specified page holding the Post Form, this is to submit the Posting form with the request.
    //    page.Controls.Add(new LiteralControl(strForm));
    //}

    //private static String PreparePOSTForm(string url, NameValueCollection data)
    //{
    //    //Set a name for the form
    //    string formID = "PostForm";

    //    //Build the form using the specified data to be posted.
    //    StringBuilder strForm = new StringBuilder();
    //    strForm.Append("<form id=\"" + formID + "\" name=\"" + formID + "\" action=\"" + url + "\" method=\"POST\">");
    //    foreach (string key in data)
    //    {
    //        strForm.Append("<input type=\"hidden\" name=\"" + key + "\" value=\"" + data[key] + "\">");
    //    }
    //    strForm.Append("</form>");

    //    //Build the JavaScript which will do the Posting operation.
    //    StringBuilder strScript = new StringBuilder();
    //    strScript.Append("<script language='javascript'>");
    //    strScript.Append("var v" + formID + " = document." + formID + ";");
    //    strScript.Append("v" + formID + ".submit();");
    //    strScript.Append("</script>");

    //    //Return the form and the script concatenated. (The order is important, Form then JavaScript)
    //    return strForm.ToString() + strScript.ToString();
    //}

    public void siparisBilgileriGetir()
    {


            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();

            string sipSql = "Select * from siparis where id=@id";

            SqlCommand sd = new SqlCommand(sipSql, bag);
            sd.Parameters.AddWithValue("@id", dbSiparisNo);

            SqlDataReader sr = sd.ExecuteReader();

            sr.Read();




            string sqlPkt = "Select paket_id, paket_languageStr, paket_smin, paket_smax from paket where paket_id=@paket_id";

            SqlCommand cPaket = new SqlCommand(sqlPkt, bag);
            cPaket.Parameters.AddWithValue("@paket_id", Convert.ToInt32(sr["m_paket"]));

            SqlDataReader rdrPaket = cPaket.ExecuteReader();

            rdrPaket.Read();

            sMin = Convert.ToInt32(rdrPaket["paket_smin"]);
            sMax = Convert.ToInt32(rdrPaket["paket_smax"]);

            paketNo = Convert.ToInt32(sr["m_paket"]);
            int secilenAhsap = Convert.ToInt32(sr["sipSecilenAhsap"]);
            musteriID = sr["m_id"].ToString();

            int sayfaSayisi = Convert.ToInt32(sr["m_yaprak"]);



            secilenSaat = Convert.ToInt32(sr["m_saat"]);
            secilenCanta = Convert.ToInt32(sr["m_canta"]);
            secilenAile = Convert.ToInt32(sr["m_aile"]);
            secilenCep = Convert.ToInt32(sr["m_cep"]);
            secilenBuyuk = Convert.ToInt32(sr["m_buyuk"]);
            webSiparisOdeme = Convert.ToInt32(sr["siparisWebGonderi"]);


            int calismaSekli = Convert.ToInt32(sr["p_album"]); // 1 normal çalışmalı 2 çizgi albüm çalışmalı

            secilenKapak = Convert.ToInt32(sr["m_sipKapak"]);

            int kagitTipi = Convert.ToInt32(sr["siparis_kagit"]);

            string musteriNot = sr["m_not"].ToString();
            string buyukEbatYazi = sr["yazBuyuk"].ToString();
            string kapakYazi = sr["sipKapakYazi"].ToString();

            double yazBuyukFiyati = 0;
            double yazBuyukFiyatiCikart = 0;

            indirimTutari.Visible = false;

            if (Convert.ToDouble(sr["yazbuyukfiyat"]) > 0)
            {
            buyukEkstra.Visible = true;
            lblBuyukEkstra.Text = "<strong>Ekstra Büyük Ebatlar : </strong>" + sr["yazBuyuk"].ToString();
            lblBuyukEkstraFiyat.Text = "<strong class='text-info'>"+ Convert.ToDouble(sr["yazbuyukfiyat"]).ToString("N") + " " +  paraBirimi + "</strong>";

            yazBuyukFiyati = Convert.ToDouble(sr["yazbuyukfiyat"]);
            }

            else if (sr["yazbuyukfiyat"].ToString().Contains("-"))
            {
            indirimTutari.Visible = true;
            lblindirimTutari.Text = "<strong class='text-danger'>Tanımlanan İndirimler : </strong>" + sr["yazBuyuk"].ToString();
            lblindirimTutariToplam.Text = "<strong class='text-danger'>" + Convert.ToDouble(sr["yazbuyukfiyat"]).ToString("N") + " " + paraBirimi + "</strong>";

            yazBuyukFiyatiCikart = Convert.ToDouble(sr["yazbuyukfiyat"].ToString().Replace("-",""));
            }
            else
            {
            buyukEkstra.Visible = false;
            indirimTutari.Visible = false;
            lblBuyukEkstra.Text = "";
            lblBuyukEkstraFiyat.Text = "";
            yazBuyukFiyati = 0;
            }


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

            if (sMin == sayfaSayisi)
            {

                lblOzetYaprakSayisi.Text = "<strong>" + sayfaSayisi.ToString() + "</strong>";
                lblOzetYaprakSayisiFiyat.Text = "<strong class='text-info'>0,00 " + paraBirimi + "</strong>";
            }

            else if (sMin < sayfaSayisi)
            {
                extraYaprak = true;
                extraSayfa = sayfaSayisi - sMin;
                extraSayfaFiyat = paketFiyat / 100 * (extraSayfa * fiyatlar.fiyatBul.sayfaFiyat(paketNo, musteriID));
                yaprakFiyat = extraSayfaFiyat;
                yaprakFiyatTam = paketFiyat / 100 * (extraSayfa * fiyatlar.fiyatBul.sayfaFiyatTam(paketNo));
                yaprakFiyatIskonto = yaprakFiyatTam - yaprakFiyat;
                lblOzetYaprakSayisi.Text = "<strong>" + sayfaSayisi.ToString() + "</strong>";
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
                    genelToplamTam += cepFiyatTam;
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

            if (calismaSekli == 1)
            {
                calismaOzet.Visible = true;
                lblOzetCalismaAdi.Text = (string)GetGlobalResourceObject("strings", "siparisCalismaSekliSecim1").ToString();
                lblOzetCalismaFiyat.Text = "<strong class='text-info'>0,00 " + paraBirimi + "</strong>";

                calismaTyp = 1;
            }
            else if (calismaSekli == 2)
            {
                calismaTyp = 2;


                if (sMin == sayfaSayisi)
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

                else if (sMin < sayfaSayisi)
                {
                    extraYaprakSayi = sayfaSayisi - sMin;

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

            lblOzetSayfaTipi.Text = y.sayfaTipiDon(Convert.ToInt32(sr["sayfa_tipi"]));
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

            if (kagitTipi == 1)
            {
                kagitYuzdesi = 0;
                kagitYuzdesiTam = 0;
                kagitFiyat = 0;
                kagitFiyatTam = 0;
                kagitFiyatIskonto = 0;
                secilenKagit = 1;
                lblKagitYazi.Text = (string)GetGlobalResourceObject("strings", "siparisKagitMatYazi");
            }

            else if (kagitTipi == 16)
            {
                kagitYuzdesi = 0;
                kagitYuzdesiTam = 0;
                kagitFiyat = 0;
                kagitFiyatTam = 0;
                kagitFiyatIskonto = 0;
                secilenKagit = 16;
                lblKagitYazi.Text = (string)GetGlobalResourceObject("strings", "siparisKagitKristalBedavaYazi");
            }

            else if (kagitTipi == 2)
            {
                kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 2, 1);
                kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 2, 2);
                secilenKagit = 2;
                lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitSilkYazi"), kagitYuzdesi);
            }

            else if (kagitTipi == 3)
            {
                kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 3, 1);
                kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 3, 2);
                secilenKagit = 3;
                lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitSedefYazi"), kagitYuzdesi);
            }

            else if (kagitTipi == 5)
            {
                kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 5, 1);
                kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 5, 2);
                secilenKagit = 5;
                lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitKristalYazi"), kagitYuzdesi);
            }

            else if (kagitTipi == 6)
            {
                kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 6, 1);
                kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 6, 2);
                secilenKagit = 6;
                lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitMetalikYazi"), kagitYuzdesi);
            }

            else if (kagitTipi == 7)
            {
                kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 7, 1);
                kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 7, 2);
                secilenKagit = 7;
                lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitProKristalYazi"), kagitYuzdesi);
            }

            else if (kagitTipi == 8)
            {
                kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 8, 1);
                kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 8, 2);
                secilenKagit = 8;
                lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitXMattYazi"), kagitYuzdesi);
            }

            else if (kagitTipi == 9)
            {
                kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 9, 1);
                kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 9, 2);
                secilenKagit = 9;
                lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfart270gbrightwhite"), kagitYuzdesi);
            }

            else if (kagitTipi == 10)
            {
                kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 10, 1);
                kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 10, 2);
                secilenKagit = 10;
                lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartsatin270gbrightwhite"), kagitYuzdesi);
            }

            else if (kagitTipi == 11)
            {
                kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 11, 1);
                kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 11, 2);
                secilenKagit = 11;
                lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartradiant270gwhite"), kagitYuzdesi);
            }

            else if (kagitTipi == 12)
            {
                kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 12, 1);
                kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 12, 2);
                secilenKagit = 12;
                lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfarttoscana210gnaturalwhite"), kagitYuzdesi);
            }

            else if (kagitTipi == 13)
            {
                kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 13, 1);
                kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 13, 2);
                secilenKagit = 13;
                lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartwatercolour240gnaturalwhite"), kagitYuzdesi);
            }

            else if (kagitTipi == 14)
            {
                kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 14, 1);
                kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 14, 2);
                secilenKagit = 14;
                lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartwhitevelvet270gwhite"), kagitYuzdesi);
            }

            else if (kagitTipi == 15)
            {
                kagitYuzdesi = fiyatBul.kagitYuzde(musteriID, paketNo, 15, 1);
                kagitYuzdesiTam = fiyatBul.kagitYuzde(musteriID, paketNo, 15, 2);
                secilenKagit = 15;
                lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitsofttouch"), kagitYuzdesi);
            }




            kagitFiyat = (paketFiyat + aileFiyat + cepFiyat + yaprakFiyat) / 100 * kagitYuzdesi;
            kagitFiyatTam = (paketFiyatTam + aileFiyatTam + cepFiyatTam + yaprakFiyatTam) / 100 * kagitYuzdesiTam;
            kagitFiyatIskonto = kagitFiyatTam - kagitFiyat;


            genelToplam -= yazBuyukFiyatiCikart;
            genelToplamTam -= yazBuyukFiyatiCikart;

            genelToplam += yazBuyukFiyati;
            genelToplamTam += yazBuyukFiyati;


            genelToplam += kagitFiyat;
            genelToplamTam += kagitFiyatTam;


            lblBuyukEbatYazisi.Text = "<strong>" + (string)GetGlobalResourceObject("strings", "siparisBuyukEbatlariniz").ToString() + "</strong>" + buyukEbatYazi;
            lblkapakYazisi.Text = "<strong>" + (string)GetGlobalResourceObject("strings", "siparisKapakYaziniz").ToString() + "</strong>" + kapakYazi;
            lblmusteriNotu.Text = "<strong>" + (string)GetGlobalResourceObject("strings", "siparisMusteriNotunuz").ToString() + "</strong>" + musteriNot;

            bool krediKartiIndirim = false;
            double krediKartiIndirimTutari = 0;
            double krediKartiIndirimliSonFiyat = 0;

            if (webSiparisOdeme == 1)
            {

                krediKartiIndirimTutari = (genelToplam / 100 * 3);

                webccIndirim.Visible = true;
                lblwebccIndirimName.Text = "<strong class='text-danger'>Kredi kartı ile ödeme indirimi 3%</strong><br/><strong>Bu indirim sadece web sitesi üzerinden yapılan gönderilerde geçerlidir. Diğer kanallardan (wetransfer, usb vb.) yapılan gönderilere indirim uygulanmamaktadır.</strong>";
                lblwebccIndirimTutar.Text = "<strong class='text-danger'>" + krediKartiIndirimTutari.ToString("N") + " " + paraBirimi.ToString() + "</strong>";

                krediKartiIndirim = true;

                krediKartiIndirimliSonFiyat = genelToplam - krediKartiIndirimTutari;

                calismaGenelToplam.Visible = true;
                lblGenelToplam.Text = "<strong>" + (string)GetGlobalResourceObject("strings", "siparisGenelToplam").ToString() + "</strong>";
                lblGenelToplamFiyat.Text = "<strong><del class='text-warning'>" + genelToplam.ToString("N") + " " + paraBirimi.ToString() + "</del></strong> <strong class='text-info'>" + krediKartiIndirimliSonFiyat.ToString("N") + " " + paraBirimi.ToString() + " </strong>";

                genelToplam = krediKartiIndirimliSonFiyat;

                indirimliOdeme = 1; 
            }

            else
            {
                calismaGenelToplam.Visible = true;
                lblGenelToplam.Text = "<strong>" + (string)GetGlobalResourceObject("strings", "siparisGenelToplam").ToString() + "</strong>";
                lblGenelToplamFiyat.Text = "<strong class='text-info'>" + genelToplam.ToString("N") + " " + paraBirimi.ToString() + "</strong>";

                indirimliOdeme = 0;
            }


            genelToplamIskonto = genelToplamTam - genelToplamTam;







            lblHalkTek.Text = "<br/><strong class='text-info'>Toplam :" + genelToplam.ToString("N") + " " + paraBirimi.ToString() +
                              "</strong>";

            //double taksit3 = genelToplam / 3;
            
            //lblHalk3.Text = "<br/><strong class='text-info'>Taksitle : 3x" + taksit3.ToString("N") + " " + paraBirimi.ToString() +
            //                " Toplam : " + genelToplam.ToString("N") + " " + paraBirimi.ToString() + "</strong>";

            //double taksit6 = genelToplam / 6;

            //lblHalk6.Text = "<br/><strong class='text-info'>Taksitle : 6x" + taksit6.ToString("N") + " " + paraBirimi.ToString() +
            //                " Toplam : " + genelToplam.ToString("N") + " " + paraBirimi.ToString() + "</strong>";

            lblDigerBankaTek.Text = "<br/><strong class='text-info'>Toplam :" + genelToplam.ToString("N") + " " + paraBirimi.ToString() +
                                    "</strong>";

            toplamFiyat = genelToplam.ToString();


        sr.Close();
            sr.Dispose();
            rdrPaket.Close();
            bag.Dispose();





            kagitSayisiOzet.Visible = true;

            lblKagitFiyat.Text = "<strong class='text-info'>" + kagitFiyat.ToString("N") + " " + paraBirimi.ToString() + "</strong>";

            System.Threading.Thread.Sleep(1000);

            //pnlForm.Visible = false;
            //pnlKapaklar.Visible = false;
            //pnlOlculer.Visible = false;
            //pnlPaketler.Visible = false;

            pnlSepet.Visible = true;

            //ScriptManager.RegisterStartupScript(this, GetType(), "siparisOzetleriiii", "moveTo('siparisOzet');", true);




    }


    public string imageBigger(string imageName)
    {
        string newimageName = "";
        string[] imageN = imageName.Split('.');

        newimageName = imageN[0].ToString() + "_big." + imageN[1].ToString();


        return newimageName;
    }

    public string GetIp()
    {
        try
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }
        catch (Exception)
        {

            return "";
        }

        return "";

    }
    public void mesafeliSozlesme()
    {

        txtMesafeliSatisSozlesme.Text = "    **U Y A R I**\r\n\r\nİlgili yasa gereği lütfen aşağıdaki sözleşme metnimizi 12 punto ve koyu fontta yazdırarak okuyunuz. ( Bu şekilde yaptığınız varsayılır ) Ayrıca; internet sitemize kayıt olan ve alışveriş yapan tüm müşterilerimiz, tarafımızdan düzenlenmiş olan aşağıdaki site kuralları ve garanti hükümlerini de içeren satış sözleşmemizin tüm maddelerini başka bir ihbara gerek kalmaksızın okumuş ve kabul etmiş sayılırlar.www.cizgialbum.com ALIŞVERİŞ SİTESİ MESAFELİ SATIŞ SÖZLEŞMESİ\r\n\r\nİşbu sözleşme 13.06.2003 tarih ve 25137 sayılı Resmi Gazetede yayınlanan Mesafeli Sözleşmeler Uygulama Usul ve Esasları Hakkında Yönetmelik gereği internet üzerinden gerçekleştiren satışlar için sözleşme yapılması zorunluluğuna istinaden yönetmelik hükümlerine uygun olarak düzenlenmiş olup, maddeler halinde aşağıdaki gibidir.\r\n\r\nMADDE 1 - KONU\r\n\r\nİşbu sözleşmenin konusu, SATICI'nın, ALICI'ya satışını yaptığı, aşağıda nitelikleri ve satış fiyatı belirtilen ürünün satışı ve teslimi ile ilgili olarak 4077 sayılı Tüketicilerin Korunması Hakkındaki Kanun-Mesafeli Sözleşmeleri Uygulama Esas ve Usulleri Hakkında Yönetmelik hükümleri gereğince tarafların hak ve yükümlülüklerini kapsamaktadır.\r\n\r\nMADDE 2 - TARAFLAR ( Tarafların Tanımı )MADDE 2.1 - SATICI BİLGİLERİ ( Satıcının Tanımı )\r\n\r\nÜnvan : ÇİZGİ ALBUM FOTOGRAFCILIK KIRTASİYE INŞAAT GIDA VE SAN TIC LTD ŞTI ( Bundan sonra SATICI olarak anılacaktır )\r\n\r\nAdres : Gaziosmanpaşa İstanbul Türkiye\r\n\r\nWebSite: http://www.cizgialbum.com\r\n\r\nTelefon : 0212 538 7994\r\n\r\nFaks : 0212 538 7994\r\n\r\nEmail: cizgialbum@gmail.com\r\n\r\nMADDE 2.2 - ALICI BİLGİLERİ ( Alıcının Tanımı )\r\n\r\nBu sözleşmeyi onaylayarak http://www.cizgialbum.com sitesine kayıt olan kişi / kurum / kuruluş. (Sözleşmeyi onaylamadan sistem tarafından kayıt işlemi yapılmamaktadır.) Bundan sonra ALICI olarak anılacaktır ve kayıt olurken kullanılan adres ve iletişim bilgileri esas alınacaktır.\r\n\r\nMADDE 3 - SÖZLEŞME KONUSU ÜRÜN / HİZMET BİLGİLERİ\r\n\r\nALICI site üzerinden gönderdiği fotoğrafları, SATICI basarak albüm haline getirir. Ürün bundan sonra PANORAMİK ALBÜM olarak anılacaktır.\r\n\r\nMADDE 4 - GENEL HÜKÜMLER\r\n\r\n4.1 - ALICI, Madde 3'te belirtilen sözleşme konusu ürün veya ürünlerin temel nitelikleri, satış fiyatı ve ödeme şekli ile teslimata ilişkin tüm ön bilgileri okuyup bilgi sahibi olduğunu ve elektronik ortamda gerekli teyidi verdiğini beyan eder.\r\n\r\n4.2 - Sarf malzemeleri, fikir ve sanat eserleri ve promosyon, eşantiyon kapsamına giren ürünler hariç olmak üzere, tüm ürünlerimizin garanti belgelerinde aksi belirtilmediği sürece 1 yıl garantisi vardır, ve bu garanti belgesinde adı geçen üretici ve / veya ithalatçı firma sorumluluğunda en iyi biçimde verilmektedir.\r\n\r\n4.3 - Alıcı şahıs ve/veya firmalar - ilk yedi günlük süre hariç - tüm bu garanti süreçlerinde oluşabilecek her türlü taşıma / nakliye / posta vb. ücretlerini yüklenmeyi kabul ve taahhüt ederler.\r\n\r\n4.4 - Üretici / ithalatçı firmalar ürünlerin onarımının yapılması, ya da gerekli - zorunlu hallerde yenisi ile değiştirilmesi yoluna gidebilirler. Bu işlemlerin tümü Tüketici Koruma Kanunu çerçevesinde üretici / ithalatçı firmaların tasarrufundadır.\r\n\r\n4.5 - Garanti ve iade işlemlerinde yasal süre en fazla 30 gün olarak belirlenmiştir.\r\n\r\n4.6 - Mümkün olan en kısa süre içerisinde ürününüz ya kusuru giderilmiş olarak, ya da yenisi ile değiştirilmiş olarak size gönderilecek, her ikisi de mümkün olamıyorsa ürün için ödemiş olduğunuz tutar 10 iş günü içerisinde size iade edilecektir. Ücret iadesi, ödeme yaparken kullandığınız yöntem ile gerçekleştirilecektir.\r\n\r\n4.7 - http://www.cizgialbum.com SATICI olarak satılan hiçbir ürün için tavsiye, rehberlik, teknik bilgi ve yeterlilik aşılama, kullanma kılavuzluğu görevi ve öğretme sorumluluğu olmadığını alenen beyan eder.\r\n\r\n4.8 - http://www.cizgialbum.com sitesinde satılan cihazların / ürünlerin hatalı kullanımından, uyumsuz cihazlarla birlikte kullanımından, kullanım alanı dışında yapılan kullanımlardan, cihazın teknik bilgileri ve yeterliliklerinin üzerinde ve/veya dışında kullanımlardan dolayı oluşacak arızalar vb. sorunlarda SATICI sorumlu tutulamaz ve herhangi bir tazmin talebinde bulunulamaz.\r\n\r\n4.9- Sözleşme konusu ürün veya ürünler, 30 günlük yasal süreyi aşmamak koşulu ile her bir ürün için ALICI'nın yerleşim yerinin uzaklığına bağlı olarak ön bilgiler içinde açıklanan süre içinde ALICI veya gösterdiği adresteki kişi/kuruluşa teslim edilir. Bu süre ALICI'ya daha önce bildirilmek kaydıyla en fazla 10 gün daha uzatılabilir.\r\n\r\n4.10 - Sözleşme konusu ürün, ALICI'dan başka bir kişi/kuruluşa teslim edilecek ise, teslim edilecek kişi/kuruluşun teslimatı kabul etmemesinden, ve bundan doğan sorunlardan SATICI sorumlu tutulamaz.\r\n\r\n4.11 - SATICI, sözleşme konusu ürünün sağlam, eksiksiz, siparişte belirtilen niteliklere uygun ve varsa garanti belgeleri ve kullanım kılavuzları ile teslim edilmesinden sorumludur.\r\n\r\n4.12 - Sözleşme konusu ürünün teslimatı için sipariş bedelinin ALICI'nın mevcut seçenekler arasından tercih ettiği ödeme şekillerinden biri ile gerçekleştirilmiş olması şarttır. Herhangi bir nedenle ürün bedeli ödenmez veya banka kayıtlarında iptal edilir ise, SATICI ürünün teslimi yükümlülüğünden kurtulmuş kabul edilir.\r\n\r\n4.13 - Ürünün tesliminden sonra ALICI'ya ait kredi kartının ALICI'nın kusurundan kaynaklanmayan bir şekilde yetkisiz kişilerce haksız veya hukuka aykırı olarak kullanılması nedeni ile ilgili banka veya finans kuruluşun ürün bedelini SATICI'ya ödememesi halinde, ALICI'nın kendisine teslim edilmiş olması kaydıyla ürünün 3 gün içinde SATICI'ya gönderilmesi zorunludur. Bu takdirde nakliye giderleri ALICI'ya aittir.\r\n\r\n4.14 - SATICI mücbir sebepler veya nakliyeyi engelleyen hava muhalefeti, ulaşımın kesilmesi gibi olağanüstü durumlar nedeni ile sözleşme konusu ürünü süresi içinde teslim edemez ise, durumu ALICI'ya bildirmekle yükümlüdür. Bu takdirde ALICI siparişin iptal edilmesini, sözleşme konusu ürünün varsa emsali ile değiştirilmesini ve/veya teslimat süresinin engelleyici durumun ortadan kalkmasına kadar ertelenmesi haklarından birini kullanabilir. ALICI'nın siparişi iptal etmesi halinde ödediği tutar 10 iş günü içinde kendisine nakden ve defaten ödenir.\r\n\r\n4.15 - http://www.cizgialbum.com' un neden göstermeksizin, müşteriye ödemiş olduğu ücret tutarını iade etmek suretiyle yapılan işlemlerin tümünü ya da bir kısmını iptal etme hakkı saklıdır. Siteye üye olan bir şahıs ve/veya firmanın üyeliği üzerindeki her türlü tasarruf http://www.cizgialbum.com' a aittir. http://www.cizgialbum.com gerekli gördüğü takdirde site üzerinden gerçekleştirilen üye olma işlemini ve üyelik kayıtlarını tek taraflı olarak feshetme hakkına sahiptir.\r\n\r\n4.16 - İşbu sözleşme tüm maddeleri ile ALICI tarafından okunmuş kabul edilir, ve sanal ortamda siteye kayıt olma esnasında sözleşme onay kutucuğunun işaretlenmesi ile birlikte kabul edilmiş ve imzalanmış sayılmaktadır.\r\n\r\nMADDE 5 - CAYMA HAKKI\r\n\r\nALICI, sözleşme konusu ürünün kendisine veya gösterdiği adresteki kişi/kuruluşa tesliminden itibaren yedi (7) gün içinde cayma hakkına sahiptir. Cayma hakkının kullanılması için bu süre içinde SATICI'ya faks, email veya telefon ile bildirimde bulunulması ve ürünün ilgili madde hükümleri çerçevesinde kullanılmamış ve herhangi bir zarar görmemiş olması şarttır. Bu hakkın kullanılması halinde, 3. kişiye veya ALICI'ya teslim edilen ürünün SATICI'ya gönderildiğine ilişkin kargo teslim tutanağı örneği ile siparişe ilişkin fatura aslının iadesi zorunludur. Bu belgelerin ulaşmasını takip eden yedi (7) gün içinde ürün bedeli ALICI'ya iade edilir. Fatura aslının gönderilememesi durumunda KDV ve varsa sair yasal yükümlülükler iade edilemez. Cayma hakkı nedeni ile iade edilen ürünün kargo bedeli SATICI tarafından karşılanır.\r\n\r\n5.1 - Niteliği itibariyle iade edilemeyecek ürünler :\r\n\r\nTek kullanımlık ürünler, tüketim malzemeleri, kopyalanabilir yazılım ve programlar, hızlı bozulan veya son kullanım tarihi geçen ürünler için cayma hakkı kullanılamaz. Her türlü yazılım ve programlar, DVD, VCD, CD ve kasetler, piller, sarf malzemeleri (toner, kartuş, şerit v.b) için cayma hakkının kullanılması, ürünün orjinal ambalajının açılmamış, bozulmamış ve ürünün kullanılmamış olması şartına bağlıdır.\r\n\r\nAyrıca, tüketicinin özel istek ve talepleri uyarınca üretilen veya üzerinde değişiklik ya da ilaveler yapılarak kişiye özel hale getirilen ürün ve hizmetlerde tüketici cayma hakkını kullanamaz. PANORAMİK ALBÜM 'ler bu kategoriye girmektedir.\r\n\r\nÖdemenin kredi kartı veya benzeri bir ödeme kartı ile yapılması halinde tüketici, kartın kendi rızası dışında ve hukuka aykırı biçimde kullanıldığı gerekçesiyle ödeme işleminin iptal edilmesini talep edebilir. Bu halde, kartı çıkaran kuruluş itirazın kendisine bildirilmesinden itibaren 10 gün içinde ödeme tutarını tüketiciye iade eder.\r\n\r\nMADDE 6 – İHTİLAF HALİ VE YETKİLİ MAHKEMELER\r\n\r\nİşbu sözleşme tüm maddeleri ile, ALICI tarafından okunmuş kabul edilir ve sanal ortamda siteye kayıt olma esnasında sözleşme onay kutucuğunun işaretlenmesi ile birlikte kabul edilmiş ve imzalanmış sayılmaktadır.\r\n\r\nİşbu sözleşmenin uygulanmasında, Sanayi ve Ticaret Bakanlığınca ilan edilen değere kadar Tüketici Hakem Heyetleri, bu değerin üzerindeki bedeller için İstanbul Tüketici Mahkemeleri yetkilidir.";


    }
}