using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ccposter : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
       // lblhata.Text = Session["cv2"].ToString();
        RedirectAndPOST(this.Page);
    }

    public void RedirectAndPOST(Page page)
    {
        NameValueCollection data = new NameValueCollection();
        //data.Add("cmd", "_xclick");
        //data.Add("business", "mail@msn.com");
        data.Add("clientId", Session["clientId"].ToString());
        data.Add("amount", Session["amount"].ToString());
        data.Add("oid", Session["oid"].ToString());
        data.Add("okUrl", Session["okUrl"].ToString());
        data.Add("failUrl", Session["failUrl"].ToString());
        data.Add("rnd", Session["rnd"].ToString());
        data.Add("hash", Session["hash"].ToString());
        data.Add("islemtipi", Session["islemtipi"].ToString());
        data.Add("taksit", Session["taksit"].ToString());
        data.Add("storetype", Session["storetype"].ToString());
        data.Add("lang", Session["lang"].ToString());
        data.Add("currency", Session["currency"].ToString());
        data.Add("pan", Session["pan"].ToString());
        data.Add("Ecom_Payment_Card_ExpDate_Month", Session["Ecom_Payment_Card_ExpDate_Month"].ToString());
        data.Add("Ecom_Payment_Card_ExpDate_Year", Session["Ecom_Payment_Card_ExpDate_Year"].ToString());
        data.Add("cv2", Session["cv2"].ToString());
        data.Add("cardType", Session["cardType"].ToString());
        data.Add("ccisim", Session["ccisim"].ToString());
        data.Add("sipNumber", Session["sipNumber"].ToString());
        //Session["amount"] = amount;
        //Session["oid"] = oid;
        //Session["okUrl"] = okUrl;
        //Session["failUrl"] = failUrl;
        //Session["rnd"] = rnd;
        //Session["hash"] = hash;
        //Session["islemtipi"] = islemtipi;
        //Session["taksit"] = taksit;
        //Session["storetype"] = storetype;
        //Session["lang"] = lang;
        //Session["currency"] = currency;
        //Session["pan"] = pan;
        //Session["Ecom_Payment_Card_ExpDate_Month"] = Ecom_Payment_Card_ExpDate_Month;
        //Session["Ecom_Payment_Card_ExpDate_Year"] = Ecom_Payment_Card_ExpDate_Year;




        //Prepare the Posting form
        //string strForm = PreparePOSTForm("https://entegrasyon.asseco-see.com.tr/fim/est3Dgate", data);

        string strForm = PreparePOSTForm("https://sanalpos.isbank.com.tr/fim/est3Dgate", data);


        //ure için https://sanalpos.halkbank.com.tr/fim/est3Dgate

        //Add a literal control the specified page holding the Post Form, this is to submit the Posting form with the request.
        page.Controls.Add(new LiteralControl(strForm));
    }

    private static String PreparePOSTForm(string url, NameValueCollection data)
    {
        //Set a name for the form
        string formID = "PostForm";

        //Build the form using the specified data to be posted.
        StringBuilder strForm = new StringBuilder();
        strForm.Append("<form id=\"" + formID + "\" name=\"" + formID + "\" action=\"" + url + "\" method=\"POST\">");
        foreach (string key in data)
        {
            strForm.Append("<input type=\"hidden\" name=\"" + key + "\" value=\"" + data[key] + "\">");
        }
        strForm.Append("</form>");

        //Build the JavaScript which will do the Posting operation.
        StringBuilder strScript = new StringBuilder();
        strScript.Append("<script language='javascript'>");
        strScript.Append("var v" + formID + " = document." + formID + ";");
        strScript.Append("v" + formID + ".submit();");
        strScript.Append("</script>");

        //Return the form and the script concatenated. (The order is important, Form then JavaScript)
        return strForm.ToString() + strScript.ToString();
    }
}