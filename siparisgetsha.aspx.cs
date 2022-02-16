using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class siparisgetsha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if(Request.QueryString["id"] != null)
        {
            string sipSha = pwdHash.passwordHash.Sifrele2(Request.QueryString["id"]);
            //lblSHA.Text = sipSha;

            Response.Write(sipSha);
        }


    }
}