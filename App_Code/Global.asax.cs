using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.Web.UI;
using System.Globalization;
using System.Threading;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Global
/// </summary>
public class Global : System.Web.HttpApplication
{
	public Global()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void registerUrl(RouteCollection seolink)
    {
        //seolink.MapPageRoute("AnaSayfa", "AnaSayfa", "~/default.aspx");
        //seolink.MapPageRoute("Hakkimizda", "Hakkimizda", "~/hakkimizda.aspx");
        //seolink.MapPageRoute("PWT-Giris", "PWT-Giris", "~/login.aspx");
        //seolink.MapPageRoute("Kayit", "Kayit", "~/register.aspx");
        //seolink.MapPageRoute("PWT-Cikis", "PWT-Cikis", "~/pwt-cikis.aspx");
        //seolink.MapPageRoute("Etkinlik", "Etkinlik/{id1}/{id2}", "~/etkinlik.aspx");
        //seolink.MapPageRoute("Etkinlik-Fotograf", "Etkinlik-Fotograf/{id1}/{id2}/", "~/etkinlikfoto.aspx");
        //seolink.MapPageRoute("Etkinlikler1", "Etkinlikler", "~/etkinlikler.aspx");
        //seolink.MapPageRoute("Etkinlikler2", "Etkinlikler/{id1}", "~/etkinlikler.aspx");
        //seolink.MapPageRoute("PWT-Uye-Sayfam", "PWT-Uye-Sayfam", "~/member.aspx");
        //seolink.MapPageRoute("Sifre-Guncelle", "Sifre-Guncelle", "~/passwordupdate.aspx");
        //seolink.MapPageRoute("Profil-Guncelle" , "Profil-Guncelle", "~/profilupdate.aspx");
        //seolink.MapPageRoute("Uyelik-Durumum", "Uyelik-Durumum", "~/uyelikdurumu.aspx");
        //seolink.MapPageRoute("Profilim", "Profilim", "~/memberProfileOveriew.aspx");
        //seolink.MapPageRoute("Profilim2", "Profilim/{id1}", "~/memberProfileOveriew.aspx");
        //seolink.MapPageRoute("Profil-Fotografim", "Profil-Fotografim", "~/memberProfileFotoUplo.aspx");
        //seolink.MapPageRoute("Profil-Iletisim-Adresi-Ekle", "Profil-Iletisim-Adresi-Ekle", "~/profililetisimadresiekle.aspx");
        //seolink.MapPageRoute("SSS", "SSS", "~/sss.aspx");
        //seolink.MapPageRoute("Sifremi-unuttum", "Sifremi-unuttum", "~/sifreunuttu.aspx");
        //seolink.MapPageRoute("Irtibat" , "Irtibat" , "~/pwtiletisim.aspx");
        //seolink.MapPageRoute("PWT-Galeri", "PWT-Galeri", "~/pwtuyegaleri.aspx");
        //seolink.MapPageRoute("PWT-Galeri2", "PWT-Galeri/{id1}", "~/pwtuyegaleri.aspx");
        //seolink.MapPageRoute("PWT-Galeri-Fotograflar", "PWT-Galeri-Fotograflar/{id1}/{id2}", "~/pwtuyegalerifotograflar.aspx");
        //seolink.MapPageRoute("Fuar-Kayit", "Fuar-Kayit", "~/fuarkayitform.aspx");
        //seolink.MapPageRoute("Fuar-Odeme-Tamam", "Fuar-Odeme-Tamam", "~/fuarodemetamamkontrol.aspx");
        //seolink.MapPageRoute("Fotograf-Yukle", "Fotograf-Yukle", "~/galerifotoyukle.aspx");
        //seolink.MapPageRoute("Fotograf-Kutuphanem", "Fotograf-Kutuphanem", "~/galerifotografkutuphanem.aspx");
        //seolink.MapPageRoute("Fotograf-Kutuphanem2", "Fotograf-Kutuphanem/{id1}", "~/galerifotografkutuphanem.aspx");
        //seolink.MapPageRoute("Egitimler-Hakkinda", "Egitimler-Hakkinda", "~/egitimlerhakkinda.aspx");
        //seolink.MapPageRoute("Kategoriler", "Kategoriler/{id1}/{id2}", "~/etkinlikkategoriler.aspx");
        //seolink.MapPageRoute("Kategoriler2", "Kategoriler/{id1}/{id2}/{id3}", "~/etkinlikkategoriler.aspx");
        //seolink.MapPageRoute("Odeme-Islemleri", "Odeme-Islemleri", "~/memberodemelistesi.aspx");
        //seolink.MapPageRoute("Uyelik-Odeme-Tamam", "Uyelik-Odeme-Tamam", "~/uyelikodemeokey.aspx");
        //seolink.MapPageRoute("Videolar", "Videolar", "~/pwtvideolar.aspx");
        //seolink.MapPageRoute("PWT-Uye-Profil", "PWT-Uye-Profil/{id1}/{id2}", "~/pwtmemberprofile.aspx");
        //seolink.MapPageRoute("PWT-Uye-Profil2", "PWT-Uye-Profil/{id1}/{id2}/{id3}", "~/pwtmemberprofile.aspx");
        //seolink.MapPageRoute("Fuar-Kayit-Kontrol", "Fuar-Kayit-Kontrol", "~/fuarkayitkontrolsayfa.aspx");
        //seolink.MapPageRoute("Fuar-Katilimcilari", "Fuar-Katilimcilari", "~/fuarkatilimciliste.aspx");
        //seolink.MapPageRoute("Mailing-List", "Mailing-List", "~/mailinglistpwt.aspx");
        //seolink.MapPageRoute(HttpContext.GetGlobalResourceObject("strings", "languagekisaltma").ToString(), HttpContext.GetGlobalResourceObject("strings", "languagekisaltma").ToString(), "~/test.aspx");

        // çizgi albüm !

        //// Ana Sayfa 
        //seolink.MapPageRoute(HttpContext.GetGlobalResourceObject("strings", "languagekisaltma").ToString(), HttpContext.GetGlobalResourceObject("strings", "languagekisaltma").ToString(), "~/default.aspx");

        //// üye giriş ve kayıt sayfa linki
        //seolink.MapPageRoute(HttpContext.GetGlobalResourceObject("strings", "loginPageName").ToString(), HttpContext.GetGlobalResourceObject("strings", "languagekisaltma").ToString() + "/" + HttpContext.GetGlobalResourceObject("strings", "loginPageName").ToString(), "~/login.aspx");

        //seolink.MapPageRoute(HttpContext.GetGlobalResourceObject("strings", "loginPageName").ToString() +"12", "tr/uye-giris", "~/login.aspx");

        //// üye sayfası linki !
        //seolink.MapPageRoute(HttpContext.GetGlobalResourceObject("strings", "memberPageName").ToString(), HttpContext.GetGlobalResourceObject("strings", "languagekisaltma").ToString() + "/" + HttpContext.GetGlobalResourceObject("strings", "memberPageName").ToString(), "~/member.aspx");

        //// logout page  logoutPageName
        //seolink.MapPageRoute(HttpContext.GetGlobalResourceObject("strings", "logoutPageName").ToString(), HttpContext.GetGlobalResourceObject("strings", "languagekisaltma").ToString() + "/" + HttpContext.GetGlobalResourceObject("strings", "logoutPageName").ToString(), "~/logout.aspx");

        //// Dil Seçimi
        //seolink.MapPageRoute(HttpContext.GetGlobalResourceObject("strings", "languagePageUrl").ToString(), HttpContext.GetGlobalResourceObject("strings", "languagePageUrl").ToString() + "/{lang}", "~/changeLanguage.aspx");

        //connectionStr.DBIslem z = new connectionStr.DBIslem();

        //SqlConnection bag = z.Baglanti();

        //// string sql = "select language_id, language_short, language_active, route_id, route_rule, route_path, route_file, route_lang, route_order from language, route where  route_lang=language_id and language_active=1 order by route_order ASC";

        //string sql = "select route_id, route_rule, route_path, route_file, route_lang, route_order from route order by route_order ASC";

        //SqlCommand con = new SqlCommand(sql, bag);

        //SqlDataReader rdr = con.ExecuteReader();

        //while (rdr.Read())
        //{
        //    seolink.MapPageRoute(rdr["route_rule"].ToString() + rdr["route_id"].ToString(), rdr["route_path"].ToString(), rdr["route_file"].ToString());

        ////    seolink.MapPageRoute(rdr["route_rule"].ToString() + rdr["route_id"].ToString(), rdr["language_short"].ToString() + rdr["route_path"].ToString(), rdr["route_file"].ToString());
        //}Iletisim
        seolink.MapPageRoute("vitrinlikler", "uye-sayfam/vitrinlik-siparisi", "~/vitrinlikler.aspx");
        seolink.MapPageRoute("siparisler33", "uye-sayfam/siparis-gonder/Result", "~/siparisnew.aspx/YeniBitis");
//        seolink.MapPageRoute("siparisler22", "uye-sayfam/siparis-gonder", "~/siparisnew.aspx");
        seolink.MapPageRoute("uyeSMSSistem", "uye-sayfam/SMS-Sistem-Bilgilerim", "~/membersmspage.aspx");
        seolink.MapPageRoute("uyesiparisBilgi", "uye-sayfam/siparislerim/{id1}", "~/membersipariskontrol.aspx");
        seolink.MapPageRoute("siparisyuklemesonucu", "uye-sayfasi/yukleme-sonucu", "~/dosyayuklemesonuc.aspx");

        seolink.MapPageRoute("siparisyukle", "uye-sayfam/siparisyukle", "~/dosyayukle.aspx");
        seolink.MapPageRoute("sayfaIletisim", "Iletisim", "~/sayfaIletisim.aspx");
        seolink.MapPageRoute("sayfaHakkimizda", "Hakkimizda", "~/sayfaHakkimizda.aspx");
        seolink.MapPageRoute("urunTanitim1", "Urunler/{id1}/{id2}", "~/urunTanit.aspx");
        seolink.MapPageRoute("siparisler11", "uye-sayfam/siparisyolla", "~/siparis.aspx");
        seolink.MapPageRoute("sayfaGiziliG", "gizlilik-ve-guvenlik", "~/sayfaGizliGuvenli.aspx");
        seolink.MapPageRoute("sayfaiadegaranti", "iade-ve-garanti", "~/sayfaiadegaranti.aspx");
        seolink.MapPageRoute("sayfaMesafeliSatis", "mesafeli-satis-sozlesmesi", "~/sayfaMesafeliSatis.aspx");
        seolink.MapPageRoute("sayfaOdemeTeslimat", "odeme-ve-teslimat", "~/sayfaOdemeTeslimat.aspx");
        seolink.MapPageRoute("sayfaUyelikSozlesme", "uyelik-sozlesmesi", "~/sayfaUyelikSozlesme.aspx");
        seolink.MapPageRoute("sayfaCerezPol", "Cerez-Politamiz", "~/sayfaCerezler.aspx");
        seolink.MapPageRoute("sayfa3d", "3d-secure", "~/sayfa3dsecure.aspx");
        seolink.MapPageRoute("uye-giris1", "uye-giris", "~/register.aspx");
        seolink.MapPageRoute("uye-sayfam1", "uye-sayfam", "~/member.aspx");
        seolink.MapPageRoute("cikis-yap1", "uye-cikis", "~/logout.aspx");
        seolink.MapPageRoute("Sifremi-Unuttum11", "Sifremi-Unuttum", "~/sifremiunuttum.aspx");
        seolink.MapPageRoute("dil-secimi1", "dil-secimi/{lang}", "~/changeLanguage.aspx");
        seolink.MapPageRoute("bilgilerimiDuzenle", "uye-sayfasi/bilgi-guncelle", "~/memberupdate.aspx");
        seolink.MapPageRoute("sifremiDuzenle", "uye-sayfasi/sifre-guncelle", "~/memberUpdateParola.aspx");
        seolink.MapPageRoute("epostaDuzenle", "uye-sayfasi/mail-guncelle", "~/memberUpdateMail.aspx");
        seolink.MapPageRoute("uyelik-sozlesmesi1234", "uyelik-sozlesmesi", "~/sayfauyeliksozlesme.aspx");
        seolink.MapPageRoute("mesafeli-satis", "mesafeli-satis", "~/sayfamesafeli.aspx");
        seolink.MapPageRoute("odeme-ve-teslimat1234", "odeme-ve-teslimat", "~/sayfaodemeteslimat.aspx");
        seolink.MapPageRoute("iade-politikasi1234", "iade-politikasi", "~/sayfaiade.aspx");
        seolink.MapPageRoute("cerez-politikasi1234", "cerez-politikasi", "~/sayfacerez.aspx");
        seolink.MapPageRoute("ssl-nedir1234", "ssl-nedir", "~/sayfassl.aspx");
        seolink.MapPageRoute("3dsecure-nedir", "3dsecure-nedir", "~/sayfa3dsecure.aspx");
        seolink.MapPageRoute("sayfaggg", "gizlilik-guvenlik", "~/sayfagg.aspx");
        seolink.MapPageRoute("siparis-odeme", "siparis-odeme", "~/cardtest.aspx");
        seolink.MapPageRoute("bank-poster", "bank-poster", "~/ccposter.aspx");
        seolink.MapPageRoute("sifre-yenile", "sifre-yenile", "~/sifreunutma.aspx");
        seolink.MapPageRoute("bakimda", "bakimda", "~/bakimsayfasi.aspx");
        seolink.MapPageRoute("order", "order", "~/order.aspx");








        //rdr.Close();
        //con.Dispose();
        //bag.Close();


    }

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

        try
        {
            registerUrl(RouteTable.Routes);
        }
        catch (Exception)
        {

            
        }

        

        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
        {
            Path = "~/js/jquery-2.1.3.min.js",
            DebugPath = "~/js/jquery-2.1.3.min.js",
            CdnPath = "http://code.jquery.com/jquery-2.1.3.min.js",
            CdnDebugPath = "http://code.jquery.com/jquery-2.1.3.min.js"
        });

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["CultureInfo"];

        

        if (cookie != null && cookie.Value != null)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cookie.Value);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cookie.Value);
        }
        else
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
        }

    }
}