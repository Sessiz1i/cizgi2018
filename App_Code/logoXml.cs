using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using connectionStr;
using System.Data.SqlClient;

namespace logo
{ 

    /// <summary>
    /// Logo için kayıt oluşturur ! (cari hesap, açık fatura, kapalı fatura, toplu fatura vb.)
    /// </summary>
    public class logoXml
    {

        string cariXmlPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/xmlx"), "otoCari.xml");


        /// <summary>
        /// Gelen verileri kullanarak Logo için müşteri kartı açar register sayfasından veya admin panelinden işlem yapılabilir.
        /// </summary>
        /// <param name="musteriID">Müşteri ID Numarası mid</param>
        /// <param name="firmaAdi">Firma Adı</param>
        /// <param name="firmaAdres">Firma Adresi</param>
        /// <param name="ulkeID"></param>
        /// <param name="sehirID"></param>
        /// <param name="telNo"></param>
        /// <param name="telNo2"></param>
        /// <param name="vergiDaire"></param>
        /// <param name="vergiNo"></param>
        /// <param name="ePosta"></param>
        /// <returns></returns>
        public bool cariHesapAc(int musteriID, string firmaAdi, string firmaAdres, int ulkeID, int sehirID, string telNo, string telNo2, string vergiDaire, string vergiNo, string ePosta)
        {
            bool donus = true;
            string cariKodu = "";
            string[] cariKodBol;
            int newCariKod = 0;
            string finalCariKod ="";
            int bolgeID = 0;

            string sqlUpdate = "";

            connectionStr.DBIslem baglan = new connectionStr.DBIslem();

            SqlConnection bag = baglan.Baglanti();


            string sqlCari = "Select sehir_id, sehir_adi, sehir_logoKod, ulke_id, ulke_adi, ulke_logoKod from sehir, ulke where sehir_id=@sehir_id and ulke_id=@ulke_id";

            SqlCommand connCari = new SqlCommand(sqlCari, bag);
            connCari.Parameters.AddWithValue("@sehir_id", sehirID );
            connCari.Parameters.AddWithValue("@ulke_id", ulkeID);

            SqlDataReader rdrCari = connCari.ExecuteReader();

            rdrCari.Read();

            if (rdrCari.HasRows == true)
            {
                if (ulkeID == 225) // ülke türkiye ise cari kodlarını şehirlerine göre veriyoruz
                {
                    cariKodu = rdrCari["sehir_logoKod"].ToString();
                    cariKodBol = cariKodu.Split('.');

                    sqlUpdate = "update sehir set sehir_logoKod=@kodupdate where sehir_id=@bolgeUpdateID ";
                    bolgeID = Convert.ToInt32(rdrCari["sehir_id"]);
                }

                else // türkiye dışındaki ülkeler için cari kodları ülke id lerine göre verilecek
                {
                    cariKodu = rdrCari["ulke_logoKod"].ToString();
                    cariKodBol = cariKodu.Split('.');

                    sqlUpdate = "update ulke set ulke_logoKod=@kodupdate where ulke_id=@bolgeUpdateID ";
                    bolgeID = Convert.ToInt32(rdrCari["ulke_id"]);
                }

                newCariKod = Convert.ToInt32(cariKodBol[2]);

                newCariKod += 1;

                finalCariKod = cariKodBol[0] + "." + cariKodBol[1] + "." + newCariKod.ToString();

            }



            XDocument xDoc = XDocument.Load(cariXmlPath);

            XElement rootElement = xDoc.Root;

            XElement newEle = new XElement("AR_AP");
            XAttribute newAtt = new XAttribute("DBOP", "INS");

            XElement accType = new XElement("ACCOUNT_TYPE", "3");

            XElement code = new XElement("CODE", cariKodu); // müşteri cari kodu

            XElement firma = new XElement("TITLE", firmaAdi); // firma adı

            XElement adres = new XElement("ADDRESS1", firmaAdres); // adres

            XElement sokak = new XElement("DISTRICT", ""); // sokak ?

            XElement ilce = new XElement("TOWN", ""); // ilçe

            XElement sehir = new XElement("CITY", rdrCari["sehir_adi"].ToString()); // şehir

            XElement ulke = new XElement("COUNTRY", rdrCari["ulke_adi"].ToString()); // ülke

            XElement tel = new XElement("TELEPHONE1", telNo); // telefon 1

            XElement telCode = new XElement("TELEPHONE1_CODE", ""); // telefon kodu ?

            XElement tel2 = new XElement("TELEPHONE2", telNo2); // telefon 2 Firma Tel 

            XElement tel2Code = new XElement("TELEPHONE2_CODE", ""); // telefon kodu 2 ?

            XElement taxID = new XElement("TAX_ID", vergiNo); // vergi no !

            XElement taxOffice = new XElement("TAX_OFFICE", vergiDaire); // vergi dairesi 

            XElement eposta = new XElement("E_MAIL", ePosta); // mail adresi

            XElement correspLang = new XElement("CORRESP_LANG", "1"); // dil ?

            XElement createdBy = new XElement("CREATED_BY", "1"); // oluşturan ?

            XElement dateCreated = new XElement("DATE_CREATED", DateTime.Now.ToString("dd.MM.yyyy")); // gün ay yıl

            XElement hourCreated = new XElement("HOUR_CREATED", DateTime.Now.Hour.ToString()); // saat

            XElement minCreated = new XElement("MIN_CREATED", DateTime.Now.Minute.ToString()); // dakika 

            XElement secCreated = new XElement("SEC_CREATED", DateTime.Now.Second.ToString()); // saniye

            XElement notes = new XElement("NOTES", ""); // notlar 

            XElement clFreq = new XElement("CL_ORD_FREQ", "1"); // ?

            XElement invoicePrnt = new XElement("INVOICE_PRNT_CNT", "1"); // invoice print count ???

            XElement genius = new XElement("GENIUSFLDSLIST", ""); // ?

            XElement defn = new XElement("DEFNFLDSLIST", ""); // ?

            XElement orgLogo = new XElement("ORGLOGOID", ""); // ?

            XElement purchBrawls = new XElement("PURCHBRWS", "1");// ?

            XElement salesBrawls = new XElement("SALESBRWS", "1");// ?

            XElement impBrawls = new XElement("IMPBRWS", "1");// ?

            XElement expBrawls = new XElement("EXPBRWS", "1");// ?

            XElement finBrawls = new XElement("FINBRWS", "1"); // ?

            XElement risk1 = new XElement("RISK_TYPE1", "1"); // Risk tipi ?

            XElement risk2 = new XElement("RISK_TYPE2", "1"); // Risk tipi ?

            XElement risk3 = new XElement("RISK_TYPE3", "1"); // Risk tipi ?



            try
            {
            
            newEle.Add(newAtt, accType, code, firma, adres, sokak, ilce, sehir, ulke, tel, telCode, tel2, tel2Code, taxID, taxOffice, eposta, correspLang, createdBy, dateCreated, hourCreated, minCreated, secCreated, notes, clFreq, invoicePrnt, genius, defn, orgLogo, purchBrawls, salesBrawls, impBrawls, expBrawls, finBrawls, risk1, risk2, risk3);

            rootElement.Add(newEle);

            xDoc.Save(cariXmlPath);

                // xml oluşturma başarılı oldu ise cari kod sayacını 1 arttırıyoruz !!!
                SqlCommand connUpd = new SqlCommand(sqlUpdate, bag);
                connUpd.Parameters.AddWithValue("@kodupdate", finalCariKod);
                connUpd.Parameters.AddWithValue("@bolgeUpdateID", bolgeID);

                connUpd.ExecuteNonQuery();

                connUpd.Dispose();

                // müşterinin cari kodunu db ye giriyoruz ve cari yapıldı diye işaretliyoruz

                string sqlMember = "update member set M_COMPANY_ID=@M_COMPANY_ID, xmlCari=@xmlCari where mid=@mid";

                SqlCommand connMem = new SqlCommand(sqlMember, bag);
                connMem.Parameters.AddWithValue("@M_COMPANY_ID", cariKodu);
                connMem.Parameters.AddWithValue("@xmlCari", 1);
                connMem.Parameters.AddWithValue("@mid", musteriID);

                connMem.ExecuteNonQuery();

                connMem.Dispose();


                donus = true;

            }
            catch (Exception)
            {

                donus = false;
            }

            rdrCari.Close();
            connCari.Dispose();
            bag.Close();

            return donus;

        }



    }

}