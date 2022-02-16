using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class memberRightBar : System.Web.UI.UserControl
{
    public int aktifSekme { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        //string selectedLang = languageSwicher.languageSW.langCookieVal();

        //memberPage.HRef = "/" + selectedLang + "/" + HttpContext.GetGlobalResourceObject("strings", "memberPageName");
        //memberBilgiDuz.HRef = "/" + selectedLang + "/" + HttpContext.GetGlobalResourceObject("strings", "memberBilgileriDuzenleLnk");
        //memberSifreDuz.HRef = "/" + selectedLang + "/" + HttpContext.GetGlobalResourceObject("strings", "memberSifreDuzenleLnk");
        //memberMailDuz.HRef = "/" + selectedLang + "/" + HttpContext.GetGlobalResourceObject("strings", "memberMailDuzenleLnk");
        //memberAdresDefter.HRef = "/" + selectedLang + "/" + HttpContext.GetGlobalResourceObject("strings", "memberAdresDefteriLnk");

        //if (aktifSekme == 1)
        //{
        //    uyesayfam.Attributes.Add("class", "active");
        //}

        //else if (aktifSekme == 2)
        //{
        //    siparisler1.Attributes.Add("class", "active");
        //}

        //else if (aktifSekme == 22)
        //{
        //    siparisler2.Attributes.Add("class", "active");
        //}

        //else if (aktifSekme == 23)
        //{
        //    vitrinlikSiparisi.Attributes.Add("class", "active");
        //}

        //else if (aktifSekme == 3)
        //{
        //    memberBilgiler.Attributes.Add("class", "active");
        //}

        //else if (aktifSekme == 4)
        //{
        //    memberSifre.Attributes.Add("class", "active");
        //}

        //else if (aktifSekme == 5)
        //{
        //    memberMail.Attributes.Add("class", "active");
        //}

        //else if (aktifSekme == 6)
        //{
        //    smsSayfa.Attributes.Add("class", "active");
        //}
    }
}
