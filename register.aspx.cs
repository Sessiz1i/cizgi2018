using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Text.RegularExpressions;
using connectionStr;
using mailUsrChk;
using mailer;

public partial class register : System.Web.UI.Page
{
    public string urlReferer
    {
        get
        {
            if (this.ViewState["urlReferer"] == null)
                return "";

            return (string)this.ViewState["urlReferer"];
        }
        set { this.ViewState["urlReferer"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        Page.Title = GetGlobalResourceObject("strings", "registerPageTitle").ToString();
        Page.MetaDescription = GetGlobalResourceObject("strings", "registerPageDesc").ToString();
        Page.MetaKeywords = GetGlobalResourceObject("strings", "headerdefaultkeywords").ToString();

        //string selectedLanguage = languageSwicher.languageSW.langCookieVal();

        //hypPasswordForgetten.NavigateUrl = "/" + (string)(GetGlobalResourceObject("strings", "loginForgettenUrl"));
        //hyperBroadHome.NavigateUrl = "/";

        uyelikSozlesmeGetir(); // üyelik sözleşmesini getir !

        getUlkeList();

        if (Request.QueryString["r"] != null)
        {
            urlReferer = Request.QueryString["r"].ToString();
        }

        else
        {
            urlReferer = "";
        }

        //lblRef.Text = urlReferer;


        if (IsPostBack)
        {
            if (!(String.IsNullOrEmpty(txtRegisterSifre.Text.Trim())))
            {
                txtRegisterSifre.Attributes["value"] = txtRegisterSifre.Text;
            }

            if (!(String.IsNullOrEmpty(txtRegisterSifre2.Text.Trim())))
            {
                txtRegisterSifre2.Attributes["value"] = txtRegisterSifre2.Text;
            }
        }

    }

    public void getUlkeList()
    {
        connectionStr.DBIslem baglan = new connectionStr.DBIslem();

        SqlConnection baglantiNesnesi = baglan.Baglanti();

        SqlCommand connUlke = new SqlCommand("SELECT ulke_id, ulke_adi from ulke order by ulke_adi ASC", baglantiNesnesi);
        SqlDataReader rdrUlke;

        rdrUlke = connUlke.ExecuteReader();
        drpUlke.DataSource = rdrUlke;
        drpUlke.DataTextField = "ulke_adi";
        drpUlke.DataValueField = "ulke_id";
        drpUlke.DataBind();

        rdrUlke.Close();
        connUlke.Dispose();
        baglantiNesnesi.Close();


    }

    protected void MyListDataBound(object sender, EventArgs e)
    {
        drpSehir.Items.Insert(0, new ListItem((string)(GetGlobalResourceObject("strings", "registerFormSehirSecin")), "0"));
    }

    protected void drpUlke_SelectedIndexChanged(object sender, EventArgs e)
    {


        Thread.Sleep(1000);

        connectionStr.DBIslem baglan = new connectionStr.DBIslem();

        SqlConnection baglantiNesnesi = baglan.Baglanti();

        SqlCommand connSehir = new SqlCommand("SELECT sehir_id, sehir_ulkeid, sehir_adi from sehir where sehir_ulkeid=@sehir_ulkeid order by sehir_adi ASC", baglantiNesnesi);
        //SqlDataReader nesneni oluşturuyorum
        connSehir.Parameters.AddWithValue("@sehir_ulkeid", drpUlke.SelectedValue);
        SqlDataReader rdrSehir;

        rdrSehir = connSehir.ExecuteReader();
        drpSehir.DataSource = rdrSehir;
        drpSehir.DataTextField = "sehir_adi";
        drpSehir.DataValueField = "sehir_id";
        drpSehir.DataBind();

        rdrSehir.Close();
        connSehir.Dispose();
        baglantiNesnesi.Dispose();

    }

    public void uyelikSozlesmeGetir()
    {
        try // üyelik sözleşmesi için try
        {
            txtUyelikSozlesmesi.Text = (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi1")) + "\r\n\r\n" + (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi2")) + "\r\n\r\n" + (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi3")) + "\r\n\r\n" + (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi4")) + "\r\n\r\n" + (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi5")) + "\r\n\r\n" + (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi6")) + "\r\n\r\n" + (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi7")) + "\r\n\r\n" + (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi8")) + "\r\n\r\n" + (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi9")) + "\r\n\r\n" + (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi10")) + "\r\n\r\n" + (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi11")) + "\r\n\r\n" + (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi12")) + "\r\n\r\n" + (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi13")) + "\r\n\r\n" + (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi14")) + "\r\n\r\n" + (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi15")) + "\r\n\r\n" + (string)(GetGlobalResourceObject("strings", "registerFormUyelikSozlesmesi16"));
        }
        catch (Exception)
        {
            txtUyelikSozlesmesi.Text = "Hata - Üyelik sözleşmesi getirilemedi !";
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string username = txtRegisterUsername.Text;
        string sifre = txtRegisterSifre.Text;
        string sifre2 = txtRegisterSifre2.Text;
        string isim = txtRegisterIsim.Text;
        string soyisim = txtRegisterSoyisim.Text;
        string eposta = txtRegisterEposta.Text;
        string epostaPattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        string website = txtRegisterWeb.Text;
        int ulke = Convert.ToInt32(drpUlke.SelectedValue);
        int sehir = Convert.ToInt32(drpSehir.SelectedValue);
        string tel = txtRegisterTel.Text;
        string adres = txtRegisterAdres.Text;
        string fUnvan = txtRegisterFirmaUnvan.Text;
        string fFaturaIsim = txtRegisterFirmaIsım.Text;
        string vergiDaire = txtRegisterFirmaVergiDaire.Text;
        string vergiNo = txtRegisterFirmaVergiNo.Text;
        string fTel = txtRegisterFirmaTel.Text;
        string fAdres = txtRegisterFirmaAdres.Text;
        bool uyelikSozlesme = false;
        string registerErr = "";
        bool mailErr = false;
        bool usernameErr = false;
        bool passErr = false;

        mailUsrChk.mailusernamechecker duplicateChk = new mailUsrChk.mailusernamechecker();


        if (chkUyelikSozlesmesi.Checked != true)
        {
            uyelikSozlesme = false;
        }

        else
        {
            uyelikSozlesme = true;
        }

        if (string.IsNullOrEmpty(username))
        {
            usernameErr = true;
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckUsr")) + "</p>";
        }

        if (usernameErr == false)
        {
            if (username.Length <= 2)
            {
                usernameErr = true;
                registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckUsrNot3")) + "</p>";
            }
        }

        if (usernameErr == false)
        {
            if (duplicateChk.usernameCheck(username) == false)
            {
                usernameErr = true;
                registerErr += string.Format("<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckUsernameRegistered")) + "</p>", username);
            }
        }

        if (string.IsNullOrEmpty(sifre))
        {
            passErr = true;
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckSifre")) + "</p>";
        }

        if (passErr == false)
        {
            if (string.IsNullOrEmpty(sifre2))
            {
                passErr = true;
                registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckSifre2")) + "</p>";
            }
        }

        if (passErr == false)
        {
            if (sifre != sifre2)
            {
                passErr = true;
                registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckSifreNotMatch")) + "</p>";
            }
        }

        if (passErr == false)
        {
            if (sifre.Length <= 5)
            {
                passErr = true;
                registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckSifreNot6")) + "</p>";
            }
        }

        if (string.IsNullOrEmpty(isim))
        {
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckIsim")) + "</p>";
        }

        if (string.IsNullOrEmpty(soyisim))
        {
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckSoyIsim")) + "</p>";
        }

        if (string.IsNullOrEmpty(eposta))
        {
            mailErr = true;
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckEposta")) + "</p>";
        }

        if (mailErr == false)
        {
            if (Regex.IsMatch(eposta, epostaPattern) == false) // mail adresi yanlış
            {
                mailErr = true;
                registerErr += string.Format("<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckEpostaHatali")) + "</p>", eposta);
            }
        }

        // mail adresi kayıtlı mı kontrol !
        if (mailErr == false)
        {
            if (duplicateChk.mailCheck(eposta) == false)
            {
                registerErr += string.Format("<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckMailRegistered")) + "</p>", eposta);
            }
        }

        if (ulke == 0)
        {
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckUlke")) + "</p>";
        }

        if (sehir == 0)
        {
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckSehir")) + "</p>";
        }

        if (string.IsNullOrEmpty(tel))
        {
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckTel")) + "</p>";
        }

        if (string.IsNullOrEmpty(adres))
        {
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckAdres")) + "</p>";
        }

        if (string.IsNullOrEmpty(fUnvan))
        {
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckUnvan")) + "</p>";
        }

        if (uyelikSozlesme == false)
        {
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckUyelikSzlmes")) + "</p>";
        }



        if (registerErr.Length > 0) // herhangi bir hata var mı ?
        {
            regFormErrList.Text = registerErr;
            litHataTitle.Text = (string)(GetGlobalResourceObject("strings", "regFormErrorTitle"));
            //formdaEksik.Text = registerErr.Length.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "openModal();", true);
        }

        else // hata yok kayıt işlemlerine geç !
        {
            register2.mregisterupdate x = new register2.mregisterupdate();

            int sonuc = x.mregister(username, sifre, isim, soyisim, eposta, website, ulke, sehir, adres, fUnvan, fFaturaIsim, vergiDaire, vergiNo, fTel, fAdres, tel);

            if (sonuc == 1)
            {

                mailer.mailSender z = new mailer.mailSender();

                bool mailGonderildi = false; // z.registerMail(isim, soyisim, eposta);

                litHataTitle.Text = (string)(GetGlobalResourceObject("strings", "regFormCompleteTitle"));
                regFormErrList.Text = string.Format((string)(GetGlobalResourceObject("strings", "regFormComplete")), isim.ToUpper() + " " + soyisim.ToUpper());

                if (mailGonderildi == false)
                {
                    regFormErrList.Text += string.Format((string)(GetGlobalResourceObject("strings", "regFormMailError")), eposta);
                    regFormErrList.Text += "<p>Şifrenizle alakalı bir sorun oluşması durumunda bizi arayarak yeni şifre talep edebilirsiniz.</p>";
                }


                ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp256", "openModal();", true);

            }




        }


    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Thread.Sleep(1000);

        string userName = usrUsername.Text;
        string passWord = usrPassword.Text;

        string loginDonus = "";
        bool loginSonuc = false;
        bool firstCheck = true;

        if (string.IsNullOrEmpty(userName))
        {
            firstCheck = false;
            loginDonus += (string)(GetGlobalResourceObject("strings", "loginHataUsername"));
        }

        if (string.IsNullOrEmpty(passWord))
        {
            firstCheck = false;
            loginDonus += (string)(GetGlobalResourceObject("strings", "loginHataSifre"));
        }

        if (passWord.Length <= 5)
        {
            firstCheck = false;
            loginDonus += (string)(GetGlobalResourceObject("strings", "loginHataSifre6"));
        }

        if (firstCheck == true)
        {

            connectionStr.DBIslem baglan = new connectionStr.DBIslem();

            SqlConnection bag = baglan.Baglanti();

            string sql = "select mid, M_NAME, M_PASSWORD, M_ACTIVE from member where M_NAME=@M_NAME";

            SqlCommand c = new SqlCommand(sql, bag);
            c.Parameters.AddWithValue("@M_NAME", userName);

            SqlDataReader rdr = c.ExecuteReader();

            rdr.Read();

            if (rdr.HasRows == true)
            {
                pwdHash.passwordHash x = new pwdHash.passwordHash();

                string MD5 = x.getMD5(passWord.Trim());
                //string MD5 = x.Encrypt(passWord.Trim());

                if (Convert.ToInt32(rdr["M_ACTIVE"]) == 1) // üyelik aktif 
                {
                    if (rdr["M_PASSWORD"].ToString() == MD5) // username ve password olumlu giriş yapabilir !!!
                    {
                        loginSonuc = true;

                        HttpContext.Current.Response.Cookies["assc"]["M_NAME"] = rdr["M_NAME"].ToString();
                        HttpContext.Current.Response.Cookies["assc"]["M_PASSWORD"] = rdr["M_PASSWORD"].ToString();
                        HttpContext.Current.Response.Cookies["assc"]["mid"] = rdr["mid"].ToString();
                        HttpContext.Current.Response.Cookies["assc"].Expires = DateTime.Now.AddDays(365);
                    }

                    else // şifre hatalı ??¿
                    {

                        loginDonus += (string)(GetGlobalResourceObject("strings", "loginHataMesaj1"));
                        loginDonus += (string)(GetGlobalResourceObject("strings", "loginHataMesaj2"));
                        //loginDonus += "<p>AES : <strong>" + MD5 + "</strong></p>";
                        //loginDonus += "<p>AES Yeni : <strong>" + x.Decrypt(MD5) + "</strong></p>";
                        loginSonuc = false;
                    }

                }

                else // üyelik aktif edilmemiş !!!!
                {
                    loginDonus += (string)(GetGlobalResourceObject("strings", "loginHataMesaj3"));
                    //loginDonus += "<p><strong>" + MD5 + "</strong></p>";
                    loginSonuc = false;
                }


            }

            else
            {
                loginDonus += (string)(GetGlobalResourceObject("strings", "loginHataMesaj1"));
                loginDonus += (string)(GetGlobalResourceObject("strings", "loginHataMesaj2"));
                loginSonuc = false;
            }

            rdr.Close();
            c.Dispose();
            bag.Close();

            if (loginSonuc == false)
            {
                loginErrDesc.Text = loginDonus;
                loginErrTitle.Text = (string)(GetGlobalResourceObject("strings", "loginHataTitle"));
                //formdaEksik.Text = registerErr.Length.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "openModal2();", true);

            }

            else
            {
                if (string.IsNullOrEmpty(urlReferer))
                {
                    Response.Redirect("/" + (string)(GetGlobalResourceObject("strings", "memberPageName")));
                }

                else
                {
                    if (urlReferer.Contains("/uye-sayfam/") || urlReferer.Contains("/siparis-odeme?odeme="))
                    {
                        Response.Redirect(urlReferer);
                    }

                    else
                    {
                        Response.Redirect("/" + (string)(GetGlobalResourceObject("strings", "memberPageName")));
                    }
                    
                }

            }

        }

        else // firstcheck false boş bıraktı !
        {
            loginDonus += (string)(GetGlobalResourceObject("strings", "loginHataMesaj2"));
            loginErrDesc.Text = loginDonus;
            loginErrTitle.Text = (string)(GetGlobalResourceObject("strings", "loginHataTitle"));
            //formdaEksik.Text = registerErr.Length.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "openModal2();", true);
        }




    }
}