using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class topLoginPanel : System.Web.UI.UserControl
{
    public string kayitVal { get; set; }
    public string loginVal { get; set; }
    public string memberPageVal { get; set; }
    public string uyesayfaVal { get; set; }
    public string userIsimSoyisim { get; set; }
    public bool userLogin { get; set; }
    public string cikisYap { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        //string selectedLanguage = languageSwicher.languageSW.langCookieVal();
        hyperKayit.NavigateUrl = kayitVal;
        hyperLogin.NavigateUrl = loginVal;
        hyperUyeSayfam.NavigateUrl = memberPageVal;
        hyperLogout.NavigateUrl = cikisYap;

        lblUyeSayfam.Text = (string)HttpContext.GetGlobalResourceObject("strings", "headeruyesayfam") + " " + userIsimSoyisim;

        if (userLogin == true)
        {
            pnlNotLogin.Visible = false;
            pnlLoggedIn.Visible = true;
        }

        else
        {
            pnlNotLogin.Visible = true;
            pnlLoggedIn.Visible = false;
        }
    }
}