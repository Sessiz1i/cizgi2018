using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class languageBar : System.Web.UI.UserControl
{
    public string selectedLang { get; set; }
    public string languageUrl { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

        lblLangKisaltma.Text = (string)GetGlobalResourceObject("strings", "languageKisa");

        try
        {       

        connectionStr.DBIslem z = new connectionStr.DBIslem();

        SqlConnection baglan = z.Baglanti();

        string sql = "Select * from language where not language_short=@language_short and language_active=1";

        SqlCommand con = new SqlCommand(sql, baglan);
        con.Parameters.AddWithValue("@language_short", selectedLang);

        SqlDataReader rdr = con.ExecuteReader();

        rpt.DataSource = rdr;
        rpt.DataBind();

        rdr.Close();
        con.Dispose();

        string sqlSelected = "Select * from language where language_short=@language_short2";

        SqlCommand con2 = new SqlCommand(sqlSelected, baglan);
        con2.Parameters.AddWithValue("@language_short2", selectedLang);

        SqlDataReader rdr2 = con2.ExecuteReader();

        rdr2.Read();

        lblSelectedLangName.Text = rdr2["language_name"].ToString();
        

        baglan.Close();

        }
        catch (Exception)
        {

           
        }



    }
}