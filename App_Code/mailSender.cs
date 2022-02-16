using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using configurations;
using System.Net.Mail;
using System.Net;

namespace mailer
{ 

/// <summary>
/// Mail Gönderir
/// </summary>
public class mailSender
{
        public bool registerMail(string adi, string soyadi, string emailAdresi)
        {
            try
            {          

            configurations.conf x = new configurations.conf();

            string body = string.Empty;
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/content/mailtemplate/registerMail.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{registerMailTitle}", (string)HttpContext.GetGlobalResourceObject("strings", "registerMailTitle"));
            body = body.Replace("{sosyalMedya}", (string)HttpContext.GetGlobalResourceObject("strings", "registerMailSocial"));
            body = body.Replace("{headerCong}", (string)HttpContext.GetGlobalResourceObject("strings", "registerHeaderCong"));
            body = body.Replace("{sayin}", (string)HttpContext.GetGlobalResourceObject("strings", "registerSayin"));
            body = body.Replace("{adiSoyadi}", adi.ToUpper() + " " + soyadi.ToUpper());
            body = body.Replace("{registerTesekkur1}", (string)HttpContext.GetGlobalResourceObject("strings", "registerTesekkur1"));
            body = body.Replace("{registerTesekkur2}", (string)HttpContext.GetGlobalResourceObject("strings", "registerTesekkur2"));
            body = body.Replace("{registerTesekkur3}", (string)HttpContext.GetGlobalResourceObject("strings", "registerTesekkur3"));
            body = body.Replace("{headerYapabilecekleri}", (string)HttpContext.GetGlobalResourceObject("strings", "registerHeaderYapabilecekleri"));
            body = body.Replace("{onlineSiparis}", (string)HttpContext.GetGlobalResourceObject("strings", "registerOnlineSip"));
            body = body.Replace("{onlineSiparisText}", (string)HttpContext.GetGlobalResourceObject("strings", "registerOnlineSipText"));
            body = body.Replace("{OnlineTakip}", (string)HttpContext.GetGlobalResourceObject("strings", "registerOnlineTakip"));
            body = body.Replace("{OnlineTakipText}", (string)HttpContext.GetGlobalResourceObject("strings", "registerOnlineTakipText"));
            body = body.Replace("{onlineOdeme}", (string)HttpContext.GetGlobalResourceObject("strings", "registerOnlineOdeme"));
            body = body.Replace("{onlineOdemeText}", (string)HttpContext.GetGlobalResourceObject("strings", "registerOnlineOdemeText"));
            body = body.Replace("{firmaAdi}", (string)HttpContext.GetGlobalResourceObject("strings", "registerFirmaAdi"));
            body = body.Replace("{firmaAdres}", (string)HttpContext.GetGlobalResourceObject("strings", "registerFirmaAdres"));
            body = body.Replace("{firmaTel1}", (string)HttpContext.GetGlobalResourceObject("strings", "registerFirmaTel1"));
            body = body.Replace("{firmaTel2}", (string)HttpContext.GetGlobalResourceObject("strings", "registerFirmaTel2"));
            body = body.Replace("{firmaFax}", (string)HttpContext.GetGlobalResourceObject("strings", "registerFirmaFax"));
            body = body.Replace("{firmaEposta}", (string)HttpContext.GetGlobalResourceObject("strings", "registerFirmaEposta"));
            body = body.Replace("{copyright}", (string)HttpContext.GetGlobalResourceObject("strings", "registerFooterCopyright"));
            body = body.Replace("{siteurl}", x.siteUrl);

            
            MailMessage eposta = new MailMessage();

            eposta.From = new MailAddress(x.webEmailAdr, x.senderName);
            eposta.To.Add(emailAdresi);
            eposta.Subject = (string)HttpContext.GetGlobalResourceObject("strings", "registerMailTitle2");
            eposta.Body = body; 


            eposta.IsBodyHtml = true;


            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(x.webEmailAdr, x.webEmailPass);
            smtp.Port = x.webEmailPort;
            smtp.Host = x.webEmailSmtp;

            smtp.Send(eposta);

            smtp.Dispose();

            }
            catch (Exception)
            {

                return false;
            }


            return true;

        }

        public bool cardDurumMail(string siparisNo, string mailSubject, string mailBodys)
        {
            try
            {

                configurations.conf x = new configurations.conf();


                MailMessage eposta = new MailMessage();

                eposta.From = new MailAddress(x.webEmailAdr2, x.senderName2);
                eposta.To.Add("card@cizgialbum.com");
                eposta.Subject = mailSubject;
                eposta.Body = mailBodys;


                eposta.IsBodyHtml = true;


                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(x.webEmailAdr2, x.webEmailPass2);
                smtp.Port = x.webEmailPort2;
                smtp.Host = x.webEmailSmtp2;

                smtp.Send(eposta);

                smtp.Dispose();

            }
            catch (Exception)
            {

                return false;
            }


            return true;

        }

        public bool passRecovery(string adi, string soyadi, string emailAdresi, string sifre, string userName)
        {
            try
            {
                string _userName = (string)HttpContext.GetGlobalResourceObject("strings", "passForgetMail2") + "<strong>" + userName + "</strong>";
                string _passWord = (string)HttpContext.GetGlobalResourceObject("strings", "passForgetMail3") + "<strong>" + sifre + "</strong>";


                configurations.conf x = new configurations.conf();

                string body = string.Empty;

                body += "<p>Sayın<strong> " + adi + " " + soyadi + "</strong></p>";
                body += "<p>Şifreniz yenilenmiştir.</p>";
                body += "<p>Yeni şifreniz <strong style='color:blue'> : " + sifre + "</strong></p>";
                body += "<p>Lütfen websitesine giriş yaparak en kısa sürede şifrenizi değiştiriniz.</p>";
                body += "<p>İyi çalışmalar dileriz.</p>";
                body += "<p><strong>Çizgi Albüm</strong></p>";



                MailMessage eposta = new MailMessage();

                eposta.From = new MailAddress(x.webEmailAdr2, x.senderName2);
                eposta.To.Add(emailAdresi);
                eposta.Subject = "Çizgi Albüm Şifre Yenileme";
                eposta.Body = body;


                eposta.IsBodyHtml = true;


                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(x.webEmailAdr2, x.webEmailPass2);
                smtp.Port = x.webEmailPort2;
                smtp.Host = x.webEmailSmtp2;

                smtp.Send(eposta);

                smtp.Dispose();

            }
            catch (Exception)
            {

                return false;
            }


            return true;





        }




    }

}