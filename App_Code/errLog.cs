using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace xmlError { 
public class errLog
{
    public static string hataKayit(string exHata)
        {

            string filePath = @"~/errXml/";
            string templatePath = @"~/errXml/template/";

            string tarih = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
            string fileName = HttpContext.Current.Server.MapPath(filePath + tarih + ".xml");

            string hataNo = pwdHash.passwordHash.rndErrIdGenerator(7) + tarih;

            //string hataKodlari = "test";

            if (!File.Exists(fileName))
            {
                File.Copy(HttpContext.Current.Server.MapPath(templatePath + "templ.xml"), fileName);
            }


            XDocument xDoc = XDocument.Load(fileName);

            XElement rootElement = xDoc.Root;

            XElement newEle = new XElement("hata");

            XElement hataNumara = new XElement("errID", hataNo);

            XElement hataTarih = new XElement("errTarih", DateTime.Now.ToString());

            XElement hataKod = new XElement("errKod", exHata);

            newEle.Add(hataNumara, hataTarih, hataKod);
            rootElement.Add(newEle);

            xDoc.Save(fileName);


            return hataNo;
        }
}

}