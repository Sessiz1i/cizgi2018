using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Threading;
using System.Text.RegularExpressions;

public partial class memberUpdateMail : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Cookies["assc"] == null)
        {
            Response.Redirect("/uye-giris");
        }

    }

    public int musteriID { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        int userID = Convert.ToInt32(HttpContext.Current.Request.Cookies["assc"]["mid"]);

        musteriID = userID;

        Page.Title = (string)(GetGlobalResourceObject("strings", "memberMailUpdateTitle"));

        if (IsPostBack)
        {
            if (!(String.IsNullOrEmpty(txtPass.Text.Trim())))
            {
                txtPass.Attributes["value"] = txtPass.Text;
            }

            if (!(String.IsNullOrEmpty(txtOldMail.Text.Trim())))
            {
                txtOldMail.Attributes["value"] = txtOldMail.Text;
            }

            if (!(String.IsNullOrEmpty(txtNewMail.Text.Trim())))
            {
                txtNewMail.Attributes["value"] = txtNewMail.Text;
            }
        }

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {

        string pass = txtPass.Text;
        string oldMail = txtOldMail.Text;
        string NewMail = txtNewMail.Text;
        string registerErr = "";
        string epostaPattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        bool mailErr = false;

        if (string.IsNullOrEmpty(pass))
        {
            mailErr = true;
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "memberPassUpdateSifreBos")) + "</p>";
        }

        if (mailErr == false)
        {
            if (string.IsNullOrEmpty(oldMail))
            {
                mailErr = true;
                registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "memberMailUpdateMevcutMailBos")) + "</p>";
            }
        }

        if (mailErr == false)
        {
            if (string.IsNullOrEmpty(NewMail))
            {
                mailErr = true;
                registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "memberMailUpdateYeniMailBos")) + "</p>";
            }
        }

        if (mailErr == false)
        {
            if (Regex.IsMatch(oldMail, epostaPattern) == false) // mail adresi yanlış
            {
                mailErr = true;
                registerErr += string.Format("<p>" + (string)(GetGlobalResourceObject("strings", "memberMailUpdateMevcutFail")) + "</p>", oldMail);
            }
        }

        if (mailErr == false)
        {
            if (Regex.IsMatch(NewMail, epostaPattern) == false) // mail adresi yanlış
            {
                mailErr = true;
                registerErr += string.Format("<p>" + (string)(GetGlobalResourceObject("strings", "memberMailUpdateYeniFail")) + "</p>", oldMail);
            }
        }



        if (registerErr.Length > 0) // herhangi bir hata var mı ?
        {
            regFormErrList.Text = registerErr;
            litHataTitle.Text = (string)(GetGlobalResourceObject("strings", "regFormErrorTitle"));
            //formdaEksik.Text = registerErr.Length.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "openModal();", true);
        }

        else // hata yok kayıt işlemlerine geç !
        {
            Thread.Sleep(2000);

            pwdHash.passwordHash x = new pwdHash.passwordHash();

            string MD5Pass = x.Encrypt(pass.ToString().Trim());

            connectionStr.DBIslem b = new connectionStr.DBIslem();

            SqlConnection bag = b.Baglanti();

            string sql = "Select mid, M_PASSWORD, M_EMAIL from member where mid=@mid";

            SqlCommand c = new SqlCommand(sql, bag);
            c.Parameters.AddWithValue("@mid", musteriID);

            SqlDataReader r = c.ExecuteReader();

            r.Read();

            if (r["M_PASSWORD"].ToString() == MD5Pass) // eski şifre uyuşuyor
            {
                if (r["M_EMAIL"].ToString() == oldMail)
                {
                    litHataTitle.Text = (string)(GetGlobalResourceObject("strings", "memberMailUpdateOkey"));
                    regFormErrList.Text = (string)(GetGlobalResourceObject("strings", "memberMailUpdateOkey2"));


                    string sqlUpl = "update member set M_EMAIL=@M_EMAIL where mid=@mid";

                    SqlCommand z = new SqlCommand(sqlUpl, bag);
                    z.Parameters.AddWithValue("@mid", musteriID);
                    z.Parameters.AddWithValue("@M_EMAIL", NewMail);
                    z.ExecuteNonQuery();
                }

                else
                {
                    litHataTitle.Text = (string)(GetGlobalResourceObject("strings", "memberMailUpdateEskiMailHatali"));
                    regFormErrList.Text = (string)(GetGlobalResourceObject("strings", "memberMailUpdateEskiMailHatali2"));
                }

            }

            else // eski şifre uyuşmuyor !!!
            {
                litHataTitle.Text = (string)(GetGlobalResourceObject("strings", "memberMailUpdateSifreHatali"));
                regFormErrList.Text = (string)(GetGlobalResourceObject("strings", "memberMailUpdateSifreHatali2"));
            }


            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "openModal();", true);

            r.Close();
            bag.Dispose();
        }

    }

}