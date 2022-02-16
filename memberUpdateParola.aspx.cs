using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Threading;

public partial class memberUpdateParola : System.Web.UI.Page
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

        Page.Title = (string)(GetGlobalResourceObject("strings", "memberPassUpdateTitle"));

        if (IsPostBack)
        {
            if (!(String.IsNullOrEmpty(txtOldPass.Text.Trim())))
            {
                txtOldPass.Attributes["value"] = txtOldPass.Text;
            }

            if (!(String.IsNullOrEmpty(txtNewPass.Text.Trim())))
            {
                txtNewPass.Attributes["value"] = txtNewPass.Text;
            }

            if (!(String.IsNullOrEmpty(txtNewPass2.Text.Trim())))
            {
                txtNewPass2.Attributes["value"] = txtNewPass2.Text;
            }
        }

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {

        string oldPass = txtOldPass.Text;
        string newPass = txtNewPass.Text;
        string newPass2 = txtNewPass2.Text;
        string registerErr = "";
        bool passErr = false;

        if (string.IsNullOrEmpty(oldPass))
        {
            passErr = true;
            registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "memberPassUpdateSifreBos")) + "</p>";
        }

        if (passErr == false)
        {
            if (string.IsNullOrEmpty(newPass))
            {
                passErr = true;
                registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "memberPassUpdateSifreYeniBos")) + "</p>";
            }
        }

        if (passErr == false)
        {
            if (string.IsNullOrEmpty(newPass2))
            {
                passErr = true;
                registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "memberPassUpdateSifreYeniBosTekrar")) + "</p>";
            }
        }

        if (passErr == false)
        {
            if (newPass != newPass2)
            {
                passErr = true;
                registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckSifreNotMatch")) + "</p>";
            }
        }

        if (passErr == false)
        {
            if (newPass.Length <= 5)
            {
                passErr = true;
                registerErr += "<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckSifreNot6")) + "</p>";
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

            //pwdHash.passwordHash x = new pwdHash.passwordHash();

            //string MD5OldPass = x.Encrypt(oldPass.Trim());
            //string MD5NewPass = x.Encrypt(newPass.Trim())

            pwdHash.passwordHash x = new pwdHash.passwordHash();

            string MD5OldPass = x.getMD5(oldPass.Trim());
            string MD5NewPass = x.getMD5(newPass.Trim());


            connectionStr.DBIslem b = new connectionStr.DBIslem();

            SqlConnection bag = b.Baglanti();

            string sql = "Select mid, M_PASSWORD from member where mid=@mid";

            SqlCommand c = new SqlCommand(sql, bag);
            c.Parameters.AddWithValue("@mid", musteriID);

            SqlDataReader r = c.ExecuteReader();

            r.Read();

            if (r["M_PASSWORD"].ToString() == MD5OldPass) // eski şifre uyuşuyor
            {
                litHataTitle.Text = (string)(GetGlobalResourceObject("strings", "memberPassUpdateOkey"));
                regFormErrList.Text = (string)(GetGlobalResourceObject("strings", "memberPassUpdateOkey2"));


                string sqlUpl = "update member set M_PASSWORD=@M_PASSWORD where mid=@mid";

                SqlCommand z = new SqlCommand(sqlUpl, bag);
                z.Parameters.AddWithValue("@mid", musteriID);
                z.Parameters.AddWithValue("@M_PASSWORD", MD5NewPass);
                z.ExecuteNonQuery();

            }

            else // eski şifre uyuşmuyor !!!
            {
                litHataTitle.Text = (string)(GetGlobalResourceObject("strings", "memberPassUpdateFail"));
                regFormErrList.Text = (string)(GetGlobalResourceObject("strings", "memberPassUpdateFail2"));
            }


            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "openModal();", true);

            r.Close();
            bag.Dispose();
        }








    }

}