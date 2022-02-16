using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using connectionStr;
using System.Data.SqlClient;
using fiyatlar;
using arasKargoRef;
using System.Xml;

public partial class memberSiparisKontrol : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Cookies["assc"] == null)
        {
            //Response.Redirect("/uye-giris");
            Response.Redirect("/uye-giris" + "?r=" + HttpContext.Current.Request.Url.AbsolutePath);
        }

    }
    public int musteriID { get; set; }
    public string mok { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        int siparisID = 0;

        if (RouteData.Values["id1"] != null)
        {
            try
            {
                int.TryParse(RouteData.Values["id1"].ToString(), out siparisID);
            }
            catch (Exception)
            {
                siparisID = 0;
            }
        }

        else
        {
            Response.Redirect("/uye-sayfam");
        }

        int userID = Convert.ToInt32(HttpContext.Current.Request.Cookies["assc"]["mid"]);

        musteriID = userID;

        connectionStr.DBIslem x = new connectionStr.DBIslem();

        SqlConnection bag = x.Baglanti();



        string sql = "SELECT  siparis.id, siparis.m_id from siparis where siparis.id=@sipID";

        SqlCommand c = new SqlCommand(sql, bag);
        c.Parameters.AddWithValue("@sipID", siparisID);

        SqlDataReader rdr = c.ExecuteReader();

        if (rdr.HasRows)
        {
            rdr.Read();

            if (musteriID == Convert.ToInt32(rdr["m_id"]))
            {
                siparisGetir(siparisID);
            }

            else
            {
                Response.Redirect("/uye-sayfam");
            }
        }

        else
        {
            Response.Redirect("/uye-sayfam");
        }
        





    }

    public void siparisGetir(int siparisNo)
    {

        connectionStr.DBIslem x = new connectionStr.DBIslem();

        SqlConnection bag = x.Baglanti();



        string sql = "SELECT     dbo.siparis.id, dbo.siparis.m_id, dbo.siparis.m_yaprak, dbo.siparis.m_not, dbo.siparis.m_tarih, dbo.siparis.m_tarih2, dbo.siparis.m_onay, dbo.siparis.coban_onay, dbo.siparis.m_paket, dbo.siparis.sayfa_tipi, dbo.siparis.m_canta, dbo.siparis.m_kristal, dbo.siparis.m_buyuk, dbo.siparis.m_saat, dbo.siparis.m_cep,  dbo.siparis.m_aile, dbo.siparis.m_sipKapak, dbo.siparis.siparis_kagit, dbo.siparis.p_album, dbo.siparis.yazBuyuk, dbo.siparis.sipKapakYazi,  dbo.siparis.siparisKargo,  dbo.siparis.siparisMok,  dbo.siparis.siparisKargoSekli, dbo.siparis.siparisKargoTarih, dbo.siparis.coban_onay, dbo.member.mid, dbo.member.ulke, dbo.member.iltr, dbo.sayfatipi.sayfatipi_id, dbo.sayfatipi.sayfatipi_tur, dbo.paket.paket_id, dbo.paket.paket_adi_tr FROM         dbo.siparis INNER JOIN    dbo.member ON dbo.siparis.m_id = dbo.member.mid INNER JOIN  dbo.sayfatipi ON dbo.siparis.sayfa_tipi = dbo.sayfatipi.sayfatipi_id INNER JOIN dbo.paket ON dbo.siparis.m_paket = dbo.paket.paket_id where id=@sipIDGetir ";

        SqlCommand c = new SqlCommand(sql, bag);
        c.Parameters.AddWithValue("@sipIDGetir", siparisNo);

        SqlDataReader rdr = c.ExecuteReader();
        rdr.Read();


        if (Convert.ToInt32(rdr["coban_onay"]) == 3 && Convert.ToInt32(rdr["siparisKargo"]) == 1 && Convert.ToInt32(rdr["siparisKargoSekli"]) == 1)
        {
            mok = rdr["id"].ToString();

            kargoBilgilerAras();

            pnlKargoDetayYurtdisi.Visible = false;
            pnlKargoDetayYurtici.Visible = false;
            kargoBekliyor.Visible = false;
            pnlKargoEski.Visible = false;
        }

        else if (Convert.ToInt32(rdr["coban_onay"]) == 3 && Convert.ToInt32(rdr["siparisKargo"]) == 1 && Convert.ToInt32(rdr["siparisKargoSekli"]) == 2)
        {
            pnlKargoDetayYurtdisi.Visible = true;
            pnlKargoDetay.Visible = false;
            pnlKargoDetayYurtici.Visible = false;
            kargoBekliyor.Visible = false;
            pnlKargoEski.Visible = false;
            lblKargoYurtdisi.Text = string.Format((string)GetGlobalResourceObject("strings", "memberDtKargoYurtdisi"), rdr["siparisKargoTarih"].ToString());

        }

        else if (Convert.ToInt32(rdr["coban_onay"]) == 3 && Convert.ToInt32(rdr["siparisKargo"]) == 1 && Convert.ToInt32(rdr["siparisKargoSekli"]) == 3)
        {
            pnlKargoDetayYurtici.Visible = true;
            pnlKargoDetay.Visible = false;
            pnlKargoDetayYurtdisi.Visible = false;
            kargoBekliyor.Visible = false;
            pnlKargoEski.Visible = false;
            lblKargoYurtici.Text = string.Format((string)GetGlobalResourceObject("strings", "memberDtKargoPazarlamaci"), rdr["siparisKargoTarih"].ToString());

        }

        else if (Convert.ToInt32(rdr["coban_onay"]) == 3 && Convert.ToInt32(rdr["siparisKargo"]) == 1 && Convert.ToInt32(rdr["siparisKargoSekli"]) == 4)
        {
            pnlKargoDetayYurtici.Visible = false;
            pnlKargoDetay.Visible = false;
            pnlKargoDetayYurtdisi.Visible = false;
            kargoBekliyor.Visible = false;
            pnlKargoEski.Visible = true;
            lblKargoEski.Text = (string)GetGlobalResourceObject("strings", "memberDTKargoEski");

        }

        else if (Convert.ToInt32(rdr["coban_onay"]) == 3 && Convert.ToInt32(rdr["siparisKargo"]) == 0)
        {
            pnlKargoDetayYurtici.Visible = false;
            pnlKargoDetay.Visible = false;
            pnlKargoDetayYurtdisi.Visible = false;
            kargoBekliyor.Visible = true;
            pnlKargoEski.Visible = false;
            lblKargoBekliyor.Text = (string)GetGlobalResourceObject("strings", "memberDTKargoBekliyor");

        }



        lblOzetPaketAdi.Text = rdr["paket_adi_tr"].ToString();

        lblOzetPaketAdi.Text += paketAltGetir(Convert.ToInt32(rdr["paket_id"]));
        lblOzetSayfaTipi.Text = rdr["sayfatipi_tur"].ToString();
        lblOzetYaprakSayisi.Text = rdr["m_yaprak"].ToString();
        //lblKagitYazi.Text = rdr["m_yaprak"].ToString();

        double kagitYuzdesi = 0;

        int secilenKagit = Convert.ToInt32(rdr["siparis_kagit"]);

        if (secilenKagit == 1)
        {            
            lblKagitYazi.Text = (string)GetGlobalResourceObject("strings", "siparisKagitMatYazi");
        }

        else if (secilenKagit == 2)
        {
            kagitYuzdesi = fiyatBul.kagitYuzde(rdr["mid"].ToString(), Convert.ToInt32(rdr["paket_id"]), 2, 1);
            lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitSilkYazi"), kagitYuzdesi);
        }

        else if (secilenKagit == 3)
        {
            kagitYuzdesi = fiyatBul.kagitYuzde(rdr["mid"].ToString(), Convert.ToInt32(rdr["paket_id"]), 3, 1);
            lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitSedefYazi"), kagitYuzdesi);
        }

        else if (secilenKagit == 5)
        {
            kagitYuzdesi = fiyatBul.kagitYuzde(rdr["mid"].ToString(), Convert.ToInt32(rdr["paket_id"]), 5, 1);
            lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitKristalYazi"), kagitYuzdesi);
        }

        else if (secilenKagit == 6)
        {
            kagitYuzdesi = fiyatBul.kagitYuzde(rdr["mid"].ToString(), Convert.ToInt32(rdr["paket_id"]), 6, 1);
            lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitMetalikYazi"), kagitYuzdesi);
        }

        else if (secilenKagit == 7)
        {
            kagitYuzdesi = fiyatBul.kagitYuzde(rdr["mid"].ToString(), Convert.ToInt32(rdr["paket_id"]), 7, 1);
            lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitProKristalYazi"), kagitYuzdesi);
        }

        else if (secilenKagit == 8)
        {
            kagitYuzdesi = fiyatBul.kagitYuzde(rdr["mid"].ToString(), Convert.ToInt32(rdr["paket_id"]), 8, 1);
            lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitXMattYazi"), kagitYuzdesi);
        }

        else if (secilenKagit == 9)
        {
            kagitYuzdesi = fiyatBul.kagitYuzde(rdr["mid"].ToString(), Convert.ToInt32(rdr["paket_id"]), 9, 1);
            lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfart270gbrightwhite"), kagitYuzdesi);
        }

        else if (secilenKagit == 10)
        {
            kagitYuzdesi = fiyatBul.kagitYuzde(rdr["mid"].ToString(), Convert.ToInt32(rdr["paket_id"]), 10, 1);
            lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartsatin270gbrightwhite"), kagitYuzdesi);
        }

        else if (secilenKagit == 11)
        {
            kagitYuzdesi = fiyatBul.kagitYuzde(rdr["mid"].ToString(), Convert.ToInt32(rdr["paket_id"]), 11, 1);
            lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartradiant270gwhite"), kagitYuzdesi);
        }

        else if (secilenKagit == 12)
        {
            kagitYuzdesi = fiyatBul.kagitYuzde(rdr["mid"].ToString(), Convert.ToInt32(rdr["paket_id"]), 12, 1);
            lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfarttoscana210gnaturalwhite"), kagitYuzdesi);
        }

        else if (secilenKagit == 13)
        {
            kagitYuzdesi = fiyatBul.kagitYuzde(rdr["mid"].ToString(), Convert.ToInt32(rdr["paket_id"]), 13, 1);
            lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartwatercolour240gnaturalwhite"), kagitYuzdesi);
        }

        else if (secilenKagit == 14)
        {
            kagitYuzdesi = fiyatBul.kagitYuzde(rdr["mid"].ToString(), Convert.ToInt32(rdr["paket_id"]), 14, 1);
            lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitfartwhitevelvet270gwhite"), kagitYuzdesi);
        }

        else if (secilenKagit == 15)
        {
            kagitYuzdesi = fiyatBul.kagitYuzde(rdr["mid"].ToString(), Convert.ToInt32(rdr["paket_id"]), 15, 1);
            lblKagitYazi.Text = string.Format((string)GetGlobalResourceObject("strings", "siparisKagitsofttouch"), kagitYuzdesi);
        }



        paketAlt.paketAlt y = new paketAlt.paketAlt();

        int secilenSaat = Convert.ToInt32(rdr["m_saat"]);
        int secilenCanta = Convert.ToInt32(rdr["m_canta"]);
        int secilenAile = Convert.ToInt32(rdr["m_aile"]);
        int secilenCep = Convert.ToInt32(rdr["m_cep"]);
        int secilenBuyuk = Convert.ToInt32(rdr["m_buyuk"]);
        int calismaSekli = Convert.ToInt32(rdr["p_album"]);

        if (secilenSaat != 17)
        {
            saatOzet.Visible = true;
            lblOzetSaatAdi.Text = y.extraAdiDon(secilenSaat);           
        }

        else
        {
            saatOzet.Visible = false;
        }

        if (secilenCanta != 16)
        {
            cantaOzet.Visible = true;
            lblOzetCantaAdi.Text = y.extraAdiDon(secilenCanta);

        }

        else
        {
            cantaOzet.Visible = false;
        }

        if (secilenAile != 36)
        {
            aileOzet.Visible = true;
            lblOzetAileAdi.Text = y.extraAdiDon(secilenAile);

        }

        else
        {
            aileOzet.Visible = false;
        }

        if (secilenCep != 22)
        {
            cepOzet.Visible = true;
            lblOzetCepAdi.Text = y.extraAdiDon(secilenCep);          
        }

        else
        {
            cepOzet.Visible = false;
        }


        if (secilenBuyuk != 21)
        {
            buyukOzet.Visible = true;
            lblOzetBuyukAdi.Text = y.extraAdiDon(secilenBuyuk);
        }

        else
        {
            buyukOzet.Visible = false;
        }


        if (calismaSekli == 1)
        {
            calismaOzet.Visible = true;
            lblOzetCalismaAdi.Text = (string)GetGlobalResourceObject("strings", "siparisCalismaSekliSecim1").ToString();

        }
        else if (calismaSekli == 2)
        {
            calismaOzet.Visible = true;
            lblOzetCalismaAdi.Text = (string)GetGlobalResourceObject("strings", "siparisCalismaSekliSecim2").ToString();
        }

        else
        {
            calismaOzet.Visible = false;
        }

        buyukEbatYazisi.Visible = true;
        kapakYazisi.Visible = true;
        musteriNotu.Visible = true;

        lblBuyukEbatYazisi.Text = "<strong>" + (string)GetGlobalResourceObject("strings", "siparisBuyukEbatlariniz").ToString() + "</strong>" + rdr["yazBuyuk"].ToString();
        lblkapakYazisi.Text = "<strong>" + (string)GetGlobalResourceObject("strings", "siparisKapakYaziniz").ToString() + "</strong>" + rdr["sipKapakYazi"].ToString();
        lblmusteriNotu.Text = "<strong>" + (string)GetGlobalResourceObject("strings", "siparisMusteriNotunuz").ToString() + "</strong>" + rdr["m_not"].ToString();


        int secilenKapak = Convert.ToInt32(rdr["m_sipKapak"]);

        secilenKapakModeli.Visible = true;

        try
        {


        string[] urunL = paketAlt.paketAlt.kapakModelAdi2(siparisNo).Split('$');

        lblKapakModelAdi.Text = "<img src='/images/urunler/" + urunL[1] + "'>" + urunL[0] ;

        }
        catch (Exception)
        {

        }

        rdr.Close();
        c.Dispose();
        bag.Close();


        litsiparisozetii.Text = string.Format((string)GetGlobalResourceObject("strings", "sipDetaytitle"), siparisNo);
        Page.Title = string.Format((string)GetGlobalResourceObject("strings", "sipDetaytitle"), siparisNo);

        siparisDurum(siparisNo);

        //
    }

    public string paketAltGetir(int paketID)
    {
        paketAlt.paketAlt x = new paketAlt.paketAlt();

        return x.paketAltDon(paketID, 1);

    }

    public string imageBigger(string imageName)
    {
        string newimageName = "";
        string[] imageN = imageName.Split('.');

        newimageName = imageN[0].ToString() + "_big." + imageN[1].ToString();


        return newimageName;
    }

    public void siparisDurum(int siparisNo)
    {

        connectionStr.DBIslem x = new connectionStr.DBIslem();

        SqlConnection bag = x.Baglanti();



        string sql = " Select * from siparisdurumana where siparisdurumana_sip=@siparisdurumana_sip ";

        SqlCommand c = new SqlCommand(sql, bag);
        c.Parameters.AddWithValue("@siparisdurumana_sip", siparisNo);

        SqlDataReader rdr = c.ExecuteReader();

        int siparisDurumu = 0;

        if (rdr.HasRows)
        {
            rdr.Read();

            siparisDurumu = Convert.ToInt32(rdr["siparisdurumana_durum"]);

        }


        rdr.Close();
        c.Dispose();
        bag.Close();

        siparisBar(siparisDurumu);

    }

    public void siparisBar(int durum)
    {
        if (durum == 0)
        {
            divIptal.Visible = false;
            divOnayBekliyor.Visible = true;
            divOnaylandi.Visible = false;
            divPhotoshopBolumu.Visible = false;
            divBaskiBolumu.Visible = false;
            divImalatta.Visible = false;
            divPaketlemede.Visible = false;
            divGonderiBekliyor.Visible = false;
            divGonderildi.Visible = false;
        }

        else if (durum == 1)
        {
            divIptal.Visible = false;
            divOnayBekliyor.Visible = false;
            divOnaylandi.Visible = true;
            divPhotoshopBolumu.Visible = false;
            divBaskiBolumu.Visible = false;
            divImalatta.Visible = false;
            divPaketlemede.Visible = false;
            divGonderiBekliyor.Visible = false;
            divGonderildi.Visible = false;
        }

        else if (durum == 2)
        {
            divIptal.Visible = false;
            divOnayBekliyor.Visible = false;
            divOnaylandi.Visible = false;
            divPhotoshopBolumu.Visible = true;
            divBaskiBolumu.Visible = false;
            divImalatta.Visible = false;
            divPaketlemede.Visible = false;
            divGonderiBekliyor.Visible = false;
            divGonderildi.Visible = false;
        }

        else if (durum == 3)
        {
            divIptal.Visible = false;
            divOnayBekliyor.Visible = false;
            divOnaylandi.Visible = false;
            divPhotoshopBolumu.Visible = false;
            divBaskiBolumu.Visible = true;
            divImalatta.Visible = false;
            divPaketlemede.Visible = false;
            divGonderiBekliyor.Visible = false;
            divGonderildi.Visible = false;
        }

        else if (durum == 4)
        {
            divIptal.Visible = false;
            divOnayBekliyor.Visible = false;
            divOnaylandi.Visible = false;
            divPhotoshopBolumu.Visible = false;
            divBaskiBolumu.Visible = false;
            divImalatta.Visible = true;
            divPaketlemede.Visible = false;
            divGonderiBekliyor.Visible = false;
            divGonderildi.Visible = false;
        }

        else if (durum == 5)
        {
            divIptal.Visible = false;
            divOnayBekliyor.Visible = false;
            divOnaylandi.Visible = false;
            divPhotoshopBolumu.Visible = false;
            divBaskiBolumu.Visible = false;
            divImalatta.Visible = false;
            divPaketlemede.Visible = true;
            divGonderiBekliyor.Visible = false;
            divGonderildi.Visible = false;
        }

        else if (durum == 6)
        {
            divIptal.Visible = false;
            divOnayBekliyor.Visible = false;
            divOnaylandi.Visible = false;
            divPhotoshopBolumu.Visible = false;
            divBaskiBolumu.Visible = false;
            divImalatta.Visible = false;
            divPaketlemede.Visible = false;
            divGonderiBekliyor.Visible = true;
            divGonderildi.Visible = false;
        }

        else if (durum == 7)
        {
            divIptal.Visible = false;
            divOnayBekliyor.Visible = false;
            divOnaylandi.Visible = false;
            divPhotoshopBolumu.Visible = false;
            divBaskiBolumu.Visible = false;
            divImalatta.Visible = false;
            divPaketlemede.Visible = false;
            divGonderiBekliyor.Visible = false;
            divGonderildi.Visible = true;
        }

        else if (durum == 8)
        {
            divIptal.Visible = true;
            divOnayBekliyor.Visible = false;
            divOnaylandi.Visible = false;
            divPhotoshopBolumu.Visible = false;
            divBaskiBolumu.Visible = false;
            divImalatta.Visible = false;
            divPaketlemede.Visible = false;
            divGonderiBekliyor.Visible = false;
            divGonderildi.Visible = false;
        }

    }

    public void kargoBilgilerAras()
    {
                pnlKargoDetay.Visible = true;

        try
        {



            string loginInfo = @"<LoginInfo>  
                                    <UserName>cizgialbum</UserName> 
                                    <Password>TT554103AsNb19Z</Password>  
                                    <CustomerCode>1801644311907</CustomerCode> 
                                        </LoginInfo>";

            string queryInfo = @"<QueryInfo>
                                    <QueryType>1</QueryType>                  
                                    <IntegrationCode>" + mok + "</IntegrationCode>    </QueryInfo>";

            ArasCargoIntegrationServiceClient service = new ArasCargoIntegrationServiceClient();

            string xml = service.GetQueryXML(loginInfo, queryInfo);




            //foreach (var x in xml)
            //{
            //    lblTest.Text += x.ToString();
            //}

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);



            XmlNode mokNo = xmlDoc.SelectSingleNode("QueryResult/Cargo/MUSTERI_OZEL_KODU");
            XmlNode irsaliyeNo = xmlDoc.SelectSingleNode("QueryResult/Cargo/IRSALIYE_NUMARA");
            XmlNode kargoLinkNo = xmlDoc.SelectSingleNode("QueryResult/Cargo/KARGO_TAKIP_NO");
            XmlNode gonderen = xmlDoc.SelectSingleNode("QueryResult/Cargo/GONDERICI");
            XmlNode alici = xmlDoc.SelectSingleNode("QueryResult/Cargo/ALICI");
            XmlNode cikisSube = xmlDoc.SelectSingleNode("QueryResult/Cargo/CIKIS_SUBE");
            XmlNode varisSube = xmlDoc.SelectSingleNode("QueryResult/Cargo/VARIS_SUBE");
            XmlNode kargoTarih = xmlDoc.SelectSingleNode("QueryResult/Cargo/CIKIS_TARIH");
            XmlNode kargoAdet = xmlDoc.SelectSingleNode("QueryResult/Cargo/ADET");
            XmlNode kargoDesi = xmlDoc.SelectSingleNode("QueryResult/Cargo/DESI");
            XmlNode odemeTipi = xmlDoc.SelectSingleNode("QueryResult/Cargo/ODEME_TIPI");
            XmlNode durumKodu = xmlDoc.SelectSingleNode("QueryResult/Cargo/DURUM_KODU");
            XmlNode durumu = xmlDoc.SelectSingleNode("QueryResult/Cargo/DURUMU");
            XmlNode teslimSubeKodu = xmlDoc.SelectSingleNode("QueryResult/Cargo/VARIS_KODU");


            //lblTest.Text = mokNo.InnerText.ToString();

            lblirsaliyeNo.Text = irsaliyeNo.InnerText.ToString();
            lblKargoLinkNo.Text = kargoLinkNo.InnerText.ToString();
            lblGonderen.Text = gonderen.InnerText.ToString();
            lblAlici.Text = alici.InnerText.ToString();
            lblCikisSube.Text = cikisSube.InnerText.ToString();
            lblVarisSubesi.Text = varisSube.InnerText.ToString();
            lblKargoTarih.Text = kargoTarih.InnerText.ToString();
            lblAdet.Text = kargoAdet.InnerText.ToString();
            lblDesi.Text = kargoDesi.InnerText.ToString();
            hypArasLink.NavigateUrl = "http://kargotakip.araskargo.com.tr/mainpage.aspx?accountid=AF4198601E29C74888DB3B68ED900607&sifre=cizgitakip&alici_kod=" + mokNo.InnerText.ToString();

            if (odemeTipi.InnerText.ToString() == "ÜG")
            {
                lblOdemeTipi.Text = "Gönderici Ödemeli";
            }
            else if (odemeTipi.InnerText.ToString() == "ÜA")
            {
                lblOdemeTipi.Text = "Alıcı Ödemeli";
            }
            else
            {
                lblOdemeTipi.Text = "Bilinmiyor";
            }

            int durumKod = Convert.ToInt32(durumKodu.InnerText);
            string renklendir = "text-warning";


            if (durumKod == 1 || durumKod == 2)
            {
                renklendir = "text-info";
            }

            else if (durumKod == 3 || durumKod == 4 || durumKod == 5)
            {
                renklendir = "text-primary";
            }

            else if (durumKod == 6)
            {
                renklendir = "text-success";

                teslimBolumu.Visible = true;

                XmlNode teslimAlan = xmlDoc.SelectSingleNode("QueryResult/Cargo/TESLIM_ALAN");
                XmlNode teslimTarih = xmlDoc.SelectSingleNode("QueryResult/Cargo/TESLIM_TARIHI");
                XmlNode teslimSaat = xmlDoc.SelectSingleNode("QueryResult/Cargo/TESLIM_SAATI");

                lblTeslimAlan.Text = teslimAlan.InnerText.ToString();
                lblTeslimTarihi.Text = teslimTarih.InnerText.ToString() + " " + teslimSaat.InnerText.ToString();




            }

            else if (durumKod == 7)
            {
                renklendir = "text-danger";

                teslimBolumu.Visible = true;

                XmlNode teslimAlan = xmlDoc.SelectSingleNode("QueryResult/Cargo/TESLIM_ALAN");
                XmlNode teslimTarih = xmlDoc.SelectSingleNode("QueryResult/Cargo/TESLIM_TARIHI");
                XmlNode teslimSaat = xmlDoc.SelectSingleNode("QueryResult/Cargo/TESLIM_SAATI");

                lblTeslimAlan.Text = teslimAlan.InnerText.ToString();
                lblTeslimTarihi.Text = teslimTarih.InnerText.ToString() + " " + teslimSaat.InnerText.ToString();
            }

            lblKargoDurumu.Text = "<strong class='" + renklendir + "'>" + durumu.InnerText.ToString() + "</strong>";
            lblTeslimSubeKodu.Text = teslimSubeKodu.InnerText.ToString();



            //lblTest.Text = HttpUtility.HtmlEncode(xml.ToString());

            arasKargoTakip.Visible = true;


        }
        catch (Exception ex)
        {
            arasKargoTakip.Visible = false;

            lblTest.Text = "<strong class='text-danger'>" + (string)GetGlobalResourceObject("strings", "memberDTKargoHata") + "</strong>";
        }
    }

    


}
