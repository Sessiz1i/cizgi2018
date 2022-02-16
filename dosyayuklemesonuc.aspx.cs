using pwdHash;
using SqlConnections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dosyayuklemesonuc : System.Web.UI.Page
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

        //lityuklemesonuc.Text = Request.QueryString["err"];

        Page.Title = "Yükleme Sonucu";


        if (Request.QueryString["err"] != null)
        {

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
                                    if (r["hashprob"] == DBNull.Value || Convert.ToInt32(r["hashprob"]) == 0) // sipariş tekrar yok
                                    {
                                        lityuklemesonuc.Text =
                                            "<h2><strong class='text-danger'> YUK" + pwdHash.passwordHash.SifreCoz(Request.QueryString["code"]) +
                                            "</strong> numaralı yüklemeniz tarafımıza ulaşmış olup <strong class='text-info'>PAN" + sipNumber +
                                            "</strong> sipariş numarasıyla işleme alınmıştır.</h2>";
                                        lityuklemesonuc.Text += "<br><h2 class='text-danger'><a href='/siparis-odeme?odeme="+ pwdHash.passwordHash.Sifrele2(sipNumber.ToString()) + "' class='text-danger'><img src='/images/troy.png'/><br><br>Siparişinizi Kredi Kartı İle Ödemek İçin Tıklayın</a></h2>";

                                        try
                                        {
                                            siparisKartLink(sipNumber, pwdHash.passwordHash.Sifrele2(sipNumber.ToString()));
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        
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
                                                    lityuklemesonuc.Text =
                                                    "<h2><strong class='text-danger'> YUK" + pwdHash.passwordHash.SifreCoz(Request.QueryString["code"]) +
                                                        "</strong> numaralı yüklemeniz tarafımıza ulaşmış olup <strong class='text-info'>PAN" + sipNumber +
                                                        "</strong> sipariş numarasıyla işleme alınmıştır.</h2>";
                                                    lityuklemesonuc.Text +=
                                                        "<h2>Lakin sitenin yaptığı kontrol sonucunda daha önce gönderdiğiniz <strong class='text-warning'>PAN" +
                                                        tr["id"] + "</strong> ile aynı dosyayı içerdiği tespit edilmiştir.</h2>";
                                                    lityuklemesonuc.Text +=
                                                        "<h2>Gönderdiğiniz siparişlerinin içeriği aynıysa aynı olan ikinci gönderiniz tarafımızdan iptal edilecektir.</h2>";
                                                    lityuklemesonuc.Text +=
                                                        "<h2>Farklı bir işlem yapılmasını istiyorsanız lütfen telefon ile tarafımıza bilgi verin.</h2>";
                                                    lityuklemesonuc.Text += "<br><h2 class='text-danger'><a href='/siparis-odeme?odeme=" + pwdHash.passwordHash.Sifrele2(sipNumber.ToString()) + "' class='text-danger'><img src='/images/troy.png'/><br><br>Siparişinizi Kredi Kartı İle Ödemek İçin Tıklayın</a></h2>";

                                                    //ltsiparisDoneYazi5.Text += "</br>" + errCode;

                                                    try
                                                    {
                                                        siparisKartLink(sipNumber, pwdHash.passwordHash.Sifrele2(sipNumber.ToString()));
                                                    }
                                                    catch (Exception)
                                                    {
                                                    }
                                                }

                                            }
                                        }
                                    }

                                



                                }

                                else // row yok?
                                {
                                    lityuklemesonuc.Text =
                                        "<h2 class='text-danger'> Dosyanız gönderilirken bir sorun oluştu.</h2>";
                                    lityuklemesonuc.Text +=
                                        "<h2 class='text-danger'> Lütfen üye panelinden dosyanızı tekrar yükleyiniz.</h2>";
                                }


                            }


                        }








                    }





                }
                catch (Exception ex)
                {

                    lityuklemesonuc.Text =
                        "<h2 class='text-danger'> Dosyanız gönderilirken bir sorun oluştu.</h2>";
                    lityuklemesonuc.Text +=
                        "<h2 class='text-danger'> Lütfen üye panelinden dosyanızı tekrar yükleyiniz.</h2>";
                }


            }

            else
            {
                lityuklemesonuc.Text =
                    "<h2 class='text-danger'> Dosyanız gönderilirken bir sorun oluştu.</h2>";
                lityuklemesonuc.Text +=
                    "<h2 class='text-danger'> Lütfen üye panelinden dosyanızı tekrar yükleyiniz.</h2>";
            }






           // lityuklemesonuc.Text = "";







        }

        else
        {
            lityuklemesonuc.Text =
                "<h2 class='text-danger'> Bu sayfaya bu şekilde erişemezsiniz.</h2>";
            lityuklemesonuc.Text +=
                "<h2 class='text-danger'> Lütfen üye panelinden dosyanızı tekrar yükleyiniz.</h2>";
        }




    }

    public void siparisKartLink(int siparisNo, string siparisSHA)
    {

        using (SqlConnection con = new SqlConnection())
        {
            con.ConnectionString = cstring.ConnStr();
            con.Open();

            using (SqlCommand c = new SqlCommand("update siparis set siparisSHA=@siparisSHA where id=@sip", con))
            {
                c.Parameters.AddWithValue("@sip", siparisNo);
                c.Parameters.AddWithValue("@siparisSHA", siparisSHA);
                c.ExecuteNonQuery();
            }

        }
    }
}