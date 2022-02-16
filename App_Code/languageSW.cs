using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;


namespace languageSwicher
{ 
/// <summary>
/// languageSW Dil Ayarlarını yapan class dosyası !
/// </summary>
public class languageSW
{
    /// <summary>
    /// Cookie check ederek sayfadaki linklerin hangi dilde olacağını ayarlar !
    /// </summary>
    /// <returns></returns>
    public static string langCookieVal()
    {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["CultureInfo"];
            //
            // TODO: Add constructor logic here
            //

            string langReturn = "";

            if (cookie != null && cookie.Value != null) // boş dğeilse işlem yap !
            {
                if (cookie.Value == "tr-TR") // cookie val tr-TR ise türkçe 
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(cookie.Value);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(cookie.Value);

                    langReturn = "tr";
                }

                else if (cookie.Value == "en-US") // cookie val en-US ise English 
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(cookie.Value);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(cookie.Value);
                    langReturn = "en";
                }               
            }

            else // boşşa türkçe geri dön !
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");
                Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
                langReturn = "tr";
            }

            return langReturn;
    }
}

}