using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class sifreunutma : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = GetGlobalResourceObject("strings", "registerPageTitle").ToString();
        Page.MetaDescription = GetGlobalResourceObject("strings", "registerPageDesc").ToString();
        Page.MetaKeywords = GetGlobalResourceObject("strings", "headerdefaultkeywords").ToString();

        string selectedLanguage = languageSwicher.languageSW.langCookieVal();

        //hypPasswordForgetten.NavigateUrl = "/" + selectedLanguage + "/" + (string)(GetGlobalResourceObject("strings", "loginForgettenUrl"));
        //hyperBroadHome.NavigateUrl = "/" + selectedLanguage;
    }

    protected void btnRetrievePass_Click(object sender, EventArgs e)
    {
        string userName = usrUsername.Text.Trim();
        string ePosta = usrEposta.Text.Trim();

        string epostaPattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        string donus = "";

        if (string.IsNullOrEmpty(userName))
        {
            donus += "<p>" + (string)GetGlobalResourceObject("strings", "registerCheckUsr") + "</p>";
        }

        else
        {
            if (userName.Length <= 2)
            {
                donus += "<p>" + (string)GetGlobalResourceObject("strings", "registerCheckUsrNot3") + "</p>";
            }
        }


        if (string.IsNullOrEmpty(ePosta))
        {
            donus += "<p>" + (string)GetGlobalResourceObject("strings", "registerCheckEposta") + "</p>";
        }

        else
        {
            if (Regex.IsMatch(ePosta, epostaPattern) == false) // mail adresi yanlış
            {
                donus += string.Format("<p>" + (string)(GetGlobalResourceObject("strings", "registerCheckEpostaHatali")) + "</p>", ePosta);
            }
        }



        if (donus.Length > 0) // herhangi bir hata var mı ?
        {

            loginErrDesc.Text = donus;
            loginErrTitle.Text = (string)(GetGlobalResourceObject("strings", "regFormErrorTitle"));
            //formdaEksik.Text = registerErr.Length.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "openModal2();", true);
        }

        else
        {

            try
            {

                connectionStr.DBIslem x = new connectionStr.DBIslem();

                SqlConnection bag = x.Baglanti();

                string sql = "select mid, M_NAME, M_FIRSTNAME, M_LASTNAME, M_PASSWORD, M_EMAIL from member where M_NAME=@mname";

                SqlCommand con = new SqlCommand(sql, bag);
                con.Parameters.AddWithValue("@mname", userName);

                SqlDataReader rdr = con.ExecuteReader();

                rdr.Read();

                pwdHash.passwordHash y = new pwdHash.passwordHash();


                if (rdr.HasRows == true)
                {
                    if (rdr["M_EMAIL"].ToString() == ePosta) // username and mail match !!
                    {

                        string newPass = y.rndPassGenerator(8, 0);
                        //string shaPass = y.Encrypt(newPass);

                        string shaPass = y.getMD5(newPass);

                        string sqlUp = "update member set M_PASSWORD=@M_PASSWORD where mid=@mid";
                        SqlCommand upd = new SqlCommand(sqlUp, bag);
                        upd.Parameters.AddWithValue("@M_PASSWORD", shaPass);
                        upd.Parameters.AddWithValue("@mid", rdr["mid"]);

                        upd.ExecuteNonQuery();

                        mailer.mailSender m = new mailer.mailSender();

                        bool recoveryMail = m.passRecovery(rdr["M_FIRSTNAME"].ToString(), rdr["M_LASTNAME"].ToString(), rdr["M_EMAIL"].ToString(), newPass, rdr["M_NAME"].ToString());

                        if (recoveryMail == true)
                        {
                            loginErrDesc.Text = (string)(GetGlobalResourceObject("strings", "passForgetDone"));
                            loginErrTitle.Text = (string)(GetGlobalResourceObject("strings", "passForgetDoneTitle"));
                            //formdaEksik.Text = registerErr.Length.ToString();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "openModal2();", true);
                        }

                        else
                        {
                            loginErrDesc.Text = (string)(GetGlobalResourceObject("strings", "passForgetDoneNoEmail"));
                            loginErrTitle.Text = (string)(GetGlobalResourceObject("strings", "passForgetDoneTitle"));
                            //formdaEksik.Text = registerErr.Length.ToString();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "openModal2();", true);
                        }


                        upd.Dispose();

                    }

                    else // Mail adresiniz hatalı
                    {
                        loginErrDesc.Text = (string)(GetGlobalResourceObject("strings", "passForgetMailUyusmuyor"));
                        loginErrTitle.Text = (string)(GetGlobalResourceObject("strings", "passForgetHataTitle"));
                        //formdaEksik.Text = registerErr.Length.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "openModal2();", true);
                    }
                }

                else // kullanıcı adı db de bulunamadı !
                {
                    loginErrDesc.Text = (string)(GetGlobalResourceObject("strings", "passForgetMailUyusmuyor"));
                    loginErrTitle.Text = (string)(GetGlobalResourceObject("strings", "passForgetHataTitle"));
                    //formdaEksik.Text = registerErr.Length.ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "openModal2();", true);
                }

                rdr.Close();
                con.Dispose();
                bag.Close();

            }
            catch (Exception)
            {

                loginErrDesc.Text = (string)(GetGlobalResourceObject("strings", "passForgetMailUyusmuyor"));
                loginErrTitle.Text = (string)(GetGlobalResourceObject("strings", "passForgetHataSorun"));
                //formdaEksik.Text = registerErr.Length.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "openModal2();", true);
            }

        }


    }
}