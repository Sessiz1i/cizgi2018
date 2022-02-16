using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Xml;


namespace SqlConnections
{
    


/// <summary>
/// Summary description for cstring
/// </summary>
    public class cstring
    {
        public static string ConnStr()
        {
            return ConfigurationManager.ConnectionStrings["mrtAlb1"].ConnectionString;
        }

        public static string ConnStrEu()
        {
            return ConfigurationManager.ConnectionStrings["mrtAlb2"].ConnectionString;
        }

        public static bool KeyKontrol(string yazi)
        {
            if (yazi == "46F2F50C7EFE4E6FB74CEA03962F948B5CA7EDF5")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string XmlOku(string xmlNodePath, string xmlPath)
        {
            var xml = new XmlDocument();
            xml.Load(xmlPath);
            //xml.Load("config.xml");

            return xml.DocumentElement.SelectSingleNode(xmlNodePath).InnerText;
        }


        public static string FirmaAdiRep(string text)
        {
            text = text.Replace("İ", "I");
            text = text.Replace("ı", "i");
            text = text.Replace("Ğ", "G");
            text = text.Replace("ğ", "g");
            text = text.Replace("Ö", "O");
            text = text.Replace("ö", "o");
            text = text.Replace("Ü", "U");
            text = text.Replace("ü", "u");
            text = text.Replace("Ş", "S");
            text = text.Replace("ş", "s");
            text = text.Replace("Ç", "C");
            text = text.Replace("ç", "c");
            text = text.Replace("(", "");
            text = text.Replace(")", "");
            text = text.Replace("[", "");
            text = text.Replace("&", "");
            text = text.Replace("&#108&#59;", "");
            text = text.Replace(".", "");
            text = text.Replace("/", "");
            text = text.Replace("\\", "");
            text = text.Replace("é", "");
            text = text.Replace(";", "");
            text = text.Replace("?", "");
            text = text.Replace(" ", "");

            if (text.Length >= 15)
            {
                text = text.Substring(0, 14);
            }




            return text;
        }

    }

}