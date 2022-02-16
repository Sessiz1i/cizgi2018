using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Çizgi Albüm - Ana Sayfa";

        //if (!Page.IsPostBack)
        //{
         //   this.Controls.Add(new LiteralControl("<script type='text/javascript'>CallFunction();</script>"));
        //}
    }
}