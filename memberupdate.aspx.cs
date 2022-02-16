using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Threading;
using register2;

public partial class memberUpdate : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Cookies["assc"] == null)
        {
            Response.Redirect("/uye-giris");
        }
    }
    public int musteriID { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {

        int userID = Convert.ToInt32(HttpContext.Current.Request.Cookies["assc"]["mid"]);

        musteriID = userID;

        Page.Title = (string)(GetGlobalResourceObject("strings", "memberUpdateTitle"));

        if (!IsPostBack)
        {
            getUlkeList();
            musteriBilgileri();
            Page.Title = (string)(GetGlobalResourceObject("strings", "memberUpdateTitle22"));

        }



    }

    public void musteriBilgileri()
    {
        connectionStr.DBIslem b = new connectionStr.DBIslem();

        SqlConnection bag = b.Baglanti();

        string sql = "Select * from member where mid=@mid";

        SqlCommand c = new SqlCommand(sql, bag);
        c.Parameters.AddWithValue("@mid", musteriID);

        SqlDataReader r = c.ExecuteReader();

        r.Read();



        txtRegisterIsim.Text = r["M_FIRSTNAME"].ToString();
        txtRegisterSoyisim.Text = r["M_LASTNAME"].ToString();
        txtRegisterWeb.Text = r["M_LINK"].ToString();
        txtRegisterTel.Text = r["M_TEL"].ToString();
        txtRegisterAdres.Text = r["M_ADRESS"].ToString();
        drpUlke.SelectedValue = r["ulke"].ToString();
        txtRegisterFirmaUnvan.Text = r["M_COMPANY"].ToString();
        txtRegisterFirmaIsım.Text = r["mf_isim"].ToString();
        txtRegisterFirmaVergiDaire.Text = r["mf_vergidairesi"].ToString();
        txtRegisterFirmaVergiNo.Text = r["mf_vergino"].ToString();
        txtRegisterFirmaTel.Text = r["mf_tel"].ToString();
        txtRegisterFirmaAdres.Text = r["mf_adres"].ToString();

        SqlCommand connSehir = new SqlCommand("SELECT sehir_id, sehir_ulkeid, sehir_adi from sehir where sehir_ulkeid=@sehir_ulkeid order by sehir_adi ASC", bag);
        //SqlDataReader nesneni oluşturuyorum
        connSehir.Parameters.AddWithValue("@sehir_ulkeid", r["ulke"]);
        SqlDataReader rdrSehir;

        rdrSehir = connSehir.ExecuteReader();
        drpSehir.DataSource = rdrSehir;
        drpSehir.DataTextField = "sehir_adi";
        drpSehir.DataValueField = "sehir_id";
        drpSehir.DataBind();

        rdrSehir.Close();
        connSehir.Dispose();

        drpSehir.SelectedValue = r["iltr"].ToString();

        r.Close();
        bag.Dispose();


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

    protected void btnRegister_Click(object sender, EventArgs e)
    {

        string isim = txtRegisterIsim.Text;
        string soyisim = txtRegisterSoyisim.Text;
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
        string registerErr = "";


        if (string.IsNullOrEmpty(isim))
        {
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckIsim")) + "</p>";
        }

        if (string.IsNullOrEmpty(soyisim))
        {
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckSoyIsim")) + "</p>";
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
            int sonuc = x.mUpdate(isim, soyisim, website, ulke, sehir, adres, fUnvan, fFaturaIsim, vergiDaire, vergiNo, fTel, fAdres, tel, musteriID);


            if (sonuc == 1) // güncelleme başarılı
            {
                litHataTitle.Text = (string)(GetGlobalResourceObject("strings", "memberUpdateComplete"));
                //regFormErrList.Text = string.Format((string)(GetGlobalResourceObject("strings", "regFormComplete")), isim.ToUpper() + " " + soyisim.ToUpper());
                getUlkeList();
                musteriBilgileri();
            }

            else // güncelleme başarısız
            {
                litHataTitle.Text = (string)(GetGlobalResourceObject("strings", "memberUpdateError"));
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "openModal();", true);


        }


    }
}