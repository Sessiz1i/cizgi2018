using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using fiyatlar;
using pwdHash;
using SqlConnections;

public partial class dosyayukle : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Cookies["assc"] == null)
        {
            Response.Redirect("/uye-giris");
        }

    }
    public string musteriID { get; set; }
    public static string musteriID2 { get; set; }
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

    public string musID
    {
        get
        {
            if (this.ViewState["musID"] == null)
                return "0";

            return (string)this.ViewState["musID"];
        }
        set { this.ViewState["musID"] = value; }
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
    protected void Page_Load(object sender, EventArgs e)
    {

        int userID = Convert.ToInt32(HttpContext.Current.Request.Cookies["assc"]["mid"]);
        string yukle = Convert.ToString(Request.QueryString["yukle"]);

        musteriID2 = userID.ToString();

        Page.Title = "Dosyanızı Yükleyin";

        bool err = false;


        try
        {


            


            if (yukle =="")
            {
                err = true;
            }


            string dogrula = pwdHash.passwordHash.SifreCoz(yukle);


        }
        catch (Exception exception)
        {
            err = true;
        }

        if (err == true)
        {
            Response.Redirect("/uye-sayfam");
        }

        else
        {
            



        siparisOzelCode = yukle;


//        Literal1.Text = "<strong class='txt-warning' style='color:red'>YUK" +pwdHash.passwordHash.SifreCoz(yukle) + "</strong> yükleme numaralı gönderiniz için lütfen aşağıdaki formu kullanarak dosyanızı yükleyiniz";


        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = cstring.ConnStr();
            conn.Open();
            
            SqlCommand x = new SqlCommand("Select id, m_id from siparis2 where id=@yukID", conn);
            x.Parameters.AddWithValue("@yukID", pwdHash.passwordHash.SifreCoz(yukle));

            SqlDataReader r = x.ExecuteReader();

            if (r.HasRows == false)
            {
                Literal1.Text = "<strong class='txt-danger'>Yükleme numaranız bulunamadı lütfen adres satırına müdahale etmeden üye sayfanızdaki yükleme bağlantısına tıklayarak bu sayfaya ulaşın!</strong>";
            }

            else
            {
                Literal1.Text = "<strong class='txt-warning' style='color:red'>YUK" + pwdHash.passwordHash.SifreCoz(yukle) + "</strong> yükleme numaralı gönderiniz için lütfen aşağıdaki formu kullanarak dosyanızı yükleyiniz";

                r.Read();
                musID = r["m_id"].ToString();

            }

        }

        }



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

               // pwdHash.passwordHash dcry = new passwordHash();


                Int64 sessionIds = Convert.ToInt64(fileHasher.rndPassGenerator(18, 0));

                string secKey = fileHasher.rndPassGenerator2(40, 0);




                //XmlDocument x = new XmlDocument();
                ////x.Load(HttpContext.Current.Server.MapPath(@"~/siparisXml/805/805-20-12-2017-18-13-344.xml"));
                //x.Load(HttpContext.Current.Server.MapPath(@"~/siparisXml/" + dcry.Decrypt(code) + ".xml"));

                //string musteriID = x.SelectSingleNode("siparisler/sip/musteriID").InnerText;
                //string paketNo = x.SelectSingleNode("siparisler/sip/paketNo").InnerText;
                //string kapak = x.SelectSingleNode("siparisler/sip/kapak").InnerText;
                //string bolge = x.SelectSingleNode("siparisler/sip/bolge").InnerText;
                //string canta = x.SelectSingleNode("siparisler/sip/canta").InnerText;
                //string saat = x.SelectSingleNode("siparisler/sip/saat").InnerText;
                //string aile = x.SelectSingleNode("siparisler/sip/aile").InnerText;
                //string cep = x.SelectSingleNode("siparisler/sip/cep").InnerText;
                //string buyuk = x.SelectSingleNode("siparisler/sip/buyuk").InnerText;
                //string sayfatip = x.SelectSingleNode("siparisler/sip/sayfatip").InnerText;
                //string yaprak = x.SelectSingleNode("siparisler/sip/yaprak").InnerText;
                //string calismatip = x.SelectSingleNode("siparisler/sip/calismatip").InnerText;
                //string kagit = x.SelectSingleNode("siparisler/sip/kagit").InnerText;
                //string buyukebatyazi = x.SelectSingleNode("siparisler/sip/buyukebatyazi").InnerText;
                //string kapakyazi = x.SelectSingleNode("siparisler/sip/kapakyazi").InnerText;
                //string musterinot = x.SelectSingleNode("siparisler/sip/musterinot").InnerText;
                //string geneltoplam = x.SelectSingleNode("siparisler/sip/geneltoplam").InnerText;
                //string geneltoplamtam = x.SelectSingleNode("siparisler/sip/geneltoplamtam").InnerText;
                //string geneltoplamiskonto = x.SelectSingleNode("siparisler/sip/geneltoplamiskonto").InnerText;
                //string calismalifiyat = x.SelectSingleNode("siparisler/sip/calismalifiyat").InnerText;
                //string calismalifiyattam = x.SelectSingleNode("siparisler/sip/calismalifiyattam").InnerText;
                //string calismalifiyatiskonto = x.SelectSingleNode("siparisler/sip/calismalifiyatiskonto").InnerText;
                //string paketfiyat = x.SelectSingleNode("siparisler/sip/paketfiyat").InnerText;
                //string paketfiyattam = x.SelectSingleNode("siparisler/sip/paketfiyattam").InnerText;
                //string paketfiyatiskonto = x.SelectSingleNode("siparisler/sip/paketfiyatiskonto").InnerText;
                //string saatfiyat = x.SelectSingleNode("siparisler/sip/saatfiyat").InnerText;
                //string saatfiyattam = x.SelectSingleNode("siparisler/sip/saatfiyattam").InnerText;
                //string saatfiyatiskonto = x.SelectSingleNode("siparisler/sip/saatfiyatiskonto").InnerText;
                //string kutufiyat = x.SelectSingleNode("siparisler/sip/kutufiyat").InnerText;
                //string kutufiyattam = x.SelectSingleNode("siparisler/sip/kutufiyattam").InnerText;
                //string kutufiyatiskonto = x.SelectSingleNode("siparisler/sip/kutufiyatiskonto").InnerText;
                //string ailefiyat = x.SelectSingleNode("siparisler/sip/ailefiyat").InnerText;
                //string ailefiyattam = x.SelectSingleNode("siparisler/sip/ailefiyattam").InnerText;
                //string ailefiyatiskonto = x.SelectSingleNode("siparisler/sip/ailefiyatiskonto").InnerText;
                //string cepfiyat = x.SelectSingleNode("siparisler/sip/cepfiyat").InnerText;
                //string cepfiyattam = x.SelectSingleNode("siparisler/sip/cepfiyattam").InnerText;
                //string cepfiyatiskonto = x.SelectSingleNode("siparisler/sip/cepfiyatiskonto").InnerText;
                //string buyukfiyat = x.SelectSingleNode("siparisler/sip/buyukfiyat").InnerText;
                //string buyukfiyattam = x.SelectSingleNode("siparisler/sip/buyukfiyattam").InnerText;
                //string buyukfiyatiskonto = x.SelectSingleNode("siparisler/sip/buyukfiyatiskonto").InnerText;
                //string yaprakfiyat = x.SelectSingleNode("siparisler/sip/yaprakfiyat").InnerText;
                //string yaprakfiyattam = x.SelectSingleNode("siparisler/sip/yaprakfiyattam").InnerText;
                //string yaprakfiyatiskonto = x.SelectSingleNode("siparisler/sip/yaprakfiyatiskonto").InnerText;
                //string kagitfiyat = x.SelectSingleNode("siparisler/sip/kagitfiyat").InnerText;
                //string kagitfiyattam = x.SelectSingleNode("siparisler/sip/kagitfiyattam").InnerText;
                //string kagitfiyatiskonto = x.SelectSingleNode("siparisler/sip/kagitfiyatiskonto").InnerText;
                //string secilenahsap = x.SelectSingleNode("siparisler/sip/secilenahsap").InnerText;


                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = cstring.ConnStr();
                    conn.Open();

                    SqlCommand sct = new SqlCommand("Select * from siparis2 where id=@yukID", conn);
                    sct.Parameters.AddWithValue("@yukID", Convert.ToInt32(passwordHash.SifreCoz(code)));

                    SqlDataReader sctr = sct.ExecuteReader();

                    sctr.Read();


                    SqlCommand sc = new SqlCommand("insert into siparis(m_id, m_paket, session_id, m_tem, sayfa_tipi, m_yaprak, m_fsayi, m_tasarim, m_not, m_tarih, m_tarih2, m_calismasekli, p_album, m_canta, m_kristal, m_saat, m_buyuk, m_cep, m_aile, siparis_kagit, yazBuyuk, sdownloaded, sipuplfrom, siparis_md5, filehash, m_onay, sipuplrealfilename, sipKapakYazi, m_sipKapak, sipSecilenAhsap, siparisWebGonderi)values(@m_id, @m_paket, @session_id, @m_tem, @sayfa_tipi, @m_yaprak, @m_fsayi, @m_tasarim, @m_not, @m_tarih, @m_tarih2, @m_calismasekli, @p_album, @m_canta, @m_kristal, @m_saat, @m_buyuk, @m_cep, @m_aile, @siparis_kagit, @yazBuyuk, @sdownloaded, @sipuplfrom, @siparis_md5, @filehash, @m_onay, @sipuplrealfilename, @sipKapakYazi, @m_sipKapak, @sipSecilenAhsap, @siparisWebGonderi) ;SELECT SCOPE_IDENTITY();", conn);
                    sc.Parameters.AddWithValue("@m_id", sctr["m_id"]);
                    sc.Parameters.AddWithValue("@m_paket", sctr["m_paket"]);//hdnPaket.Value
                    sc.Parameters.AddWithValue("@session_id", sessionIds);
                    sc.Parameters.AddWithValue("@m_tem", 8);
                    sc.Parameters.AddWithValue("@sayfa_tipi", sctr["sayfa_tipi"]);//hdnSayfaTipi.Value
                    sc.Parameters.AddWithValue("@m_yaprak", sctr["m_yaprak"]); //hdnYaprakSayisi.Value
                    sc.Parameters.AddWithValue("@m_fsayi", 20);
                    sc.Parameters.AddWithValue("@m_tasarim", "");//Request.Cookies["siparis"]["tasarimSekli"] // hdnTasarimSekli.Value 
                    sc.Parameters.AddWithValue("@m_not", sctr["m_not"]);
                    sc.Parameters.AddWithValue("@m_tarih", DateTime.Now.ToString());
                    sc.Parameters.AddWithValue("@m_tarih2", DateTime.Now);
                    sc.Parameters.AddWithValue("@m_calismasekli", sctr["m_calismasekli"]);//hdnCalisma.Value
                    sc.Parameters.AddWithValue("@p_album", sctr["p_album"]);//hdnPAlbum.Value
                    sc.Parameters.AddWithValue("@m_canta", sctr["m_canta"]);// hdnCanta.Value
                    sc.Parameters.AddWithValue("@m_kristal", 0);
                    sc.Parameters.AddWithValue("@m_saat", sctr["m_saat"]); //hdnSaat.Value
                    sc.Parameters.AddWithValue("@m_buyuk", sctr["m_buyuk"]);//hdnBuyuk.Value
                    sc.Parameters.AddWithValue("@m_cep", sctr["m_cep"]);//hdnCep.Value
                    sc.Parameters.AddWithValue("@m_aile", sctr["m_aile"]);//hdnAile.Value
                    sc.Parameters.AddWithValue("@siparis_kagit", sctr["siparis_kagit"]);//hdnKagit.Value
                    sc.Parameters.AddWithValue("@sdownloaded", 0);
                    sc.Parameters.AddWithValue("@sipuplfrom", 1);
                    sc.Parameters.AddWithValue("@siparis_md5", secKey);
                    sc.Parameters.AddWithValue("@filehash", fileSHA);
                    sc.Parameters.AddWithValue("@m_onay", 1);
                    sc.Parameters.AddWithValue("@sipuplrealfilename", dosya);
                    sc.Parameters.AddWithValue("@yazBuyuk", sctr["yazBuyuk"]);//hdnBuyukEbatText.Value
                    sc.Parameters.AddWithValue("@sipKapakYazi", sctr["sipKapakYazi"]);//hdnBuyukEbatText.Value
                    sc.Parameters.AddWithValue("@m_sipKapak", sctr["m_sipKapak"]);//hdnBuyukEbatText.Value
                    sc.Parameters.AddWithValue("@sipSecilenAhsap", sctr["sipSecilenAhsap"]);//seçilen ahşap
                    sc.Parameters.AddWithValue("@siparisWebGonderi", 1);//seçilen ahşap


                    //SqlCommand sc = new SqlCommand("INSERT siparis SELECT * FROM siparis2 WHERE ids=@yukID;SELECT SCOPE_IDENTITY();", conn);



                    insertID = Convert.ToInt32(sc.ExecuteScalar());



                    string yeniFileName = insertID + Path.GetExtension(fileName);


                    //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(geneltoplam), Convert.ToDouble(geneltoplamtam), Convert.ToDouble(geneltoplamiskonto), 1); // genelToplam
                    //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(calismalifiyat), Convert.ToDouble(calismalifiyattam), Convert.ToDouble(calismalifiyatiskonto), 2); // çalışmalı fiyat
                    //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(paketfiyat), Convert.ToDouble(paketfiyattam), Convert.ToDouble(paketfiyatiskonto), 3); // paket ücreti
                    //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(saatfiyat), Convert.ToDouble(saatfiyattam), Convert.ToDouble(saatfiyatiskonto), 4); // saat fiyat
                    //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(kutufiyat), Convert.ToDouble(kutufiyattam), Convert.ToDouble(kutufiyatiskonto), 5); // kutufiyat
                    //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(ailefiyat), Convert.ToDouble(ailefiyattam), Convert.ToDouble(ailefiyatiskonto), 6); // aile fiyat
                    //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(cepfiyat), Convert.ToDouble(cepfiyattam), Convert.ToDouble(cepfiyatiskonto), 7); // cep fiyat
                    //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(buyukfiyat), Convert.ToDouble(buyukfiyattam), Convert.ToDouble(buyukfiyatiskonto), 8); // büyük fiyat
                    //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(yaprakfiyat), Convert.ToDouble(yaprakfiyattam), Convert.ToDouble(yaprakfiyatiskonto), 9); // çalışmalı fiyat
                    //fiyatBul.siparisFiyatDetay(insertID, Convert.ToDouble(kagitfiyat), Convert.ToDouble(kagitfiyattam), Convert.ToDouble(kagitfiyatiskonto), 10); // kağıt silk vb. 


                    using (SqlCommand sx = new SqlCommand("update siparis set m_filename=@m_filename where id=@id", conn))
                    {
                        sx.Parameters.AddWithValue("@m_filename", yeniFileName);
                        sx.Parameters.AddWithValue("@id", insertID);
                        sx.ExecuteNonQuery();
                    }

                    //using (SqlCommand sep = new SqlCommand("insert into sepet(session_id, urun_id, sepet_mid, p_type) values(@session_id, @urun_id, @sepet_mid, @p_type)", conn))
                    //{
                    //    sep.Parameters.AddWithValue("@session_id", sessionIds);
                    //    sep.Parameters.AddWithValue("@urun_id", kapak);
                    //    sep.Parameters.AddWithValue("@sepet_mid", musteriID);
                    //    sep.Parameters.AddWithValue("@p_type", 2);
                    //    sep.ExecuteNonQuery();
                    //}

                    using (SqlCommand d = new SqlCommand("Select * from siparis where m_id=@_mid and filehash=@_hash and not id=@_id", conn))
                    {
                        d.Parameters.AddWithValue("@_mid", sctr["m_id"]);
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

                    sctr.Dispose();
                    sctr.Close();


                    using (SqlCommand ysil = new SqlCommand("Delete from siparis2 where id=@yukID", conn))
                    {
                        ysil.Parameters.AddWithValue("@yukID", Convert.ToInt32(passwordHash.SifreCoz(code)));
                        ysil.ExecuteNonQuery();
                    }



                    File.Move(Path.Combine(filePath, fileName), Path.Combine(filePath, yeniFileName));

                }


            }
            catch (Exception e)
            {
                hata = 1;
                xmlError.errLog.hataKayit(e.ToString() + "Code : " + code + " Code Sip : " + pwdHash.passwordHash.SifreCoz(code));
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