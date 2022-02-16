using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string selectedLang = languageSwicher.languageSW.langCookieVal();

        string redirectUrl = "/";

        try
        {

            if (Request.Cookies["assc"] != null)
            {
                HttpContext.Current.Response.Cookies["assc"].Expires = DateTime.Now.AddDays(-350);
            }

        }
        catch (Exception)
        {

            Response.Redirect(redirectUrl);
        }

        Response.Redirect(redirectUrl);
    }
}
