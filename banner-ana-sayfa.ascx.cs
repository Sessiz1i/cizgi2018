using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class banner_ana_sayfa : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string randomSayi()
    {
        Random rastgele = new Random();

        int sayi = rastgele.Next(1, 4);


        return sayi.ToString();


    }
}