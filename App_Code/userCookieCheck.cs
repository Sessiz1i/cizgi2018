using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using connectionStr;
using System.Data.SqlClient;
using pwdHash;

namespace cookiCheck
{ 
/// <summary>
/// Cookie verilerinin doğruluğunu kontrol ederek login olup olunmadığını bulur !
/// </summary>
    public class userCookieCheck
    {
        /// <summary>
        /// Kullanıcının bilgisayarındaki cookileri kontrol ederek giriş yapılıp yapılmadığını bulur.
        /// </summary>
        /// <param name="id">kullanıcının id numarası</param>
        /// <param name="userName">kullanıcı adı</param>
        /// <param name="pass">şifre</param>
        /// <returns></returns>
        public string usrControl(int id, string userName, string pass)
        {
            string donus ="";

            try
            {           

            connectionStr.DBIslem bagla = new connectionStr.DBIslem();

            SqlConnection bag = bagla.Baglanti();

            string sql = "Select mid, M_NAME, M_PASSWORD, M_FIRSTNAME, M_LASTNAME from member where M_NAME=@_M_NAME";

            SqlCommand conn = new SqlCommand(sql, bag);
            conn.Parameters.AddWithValue("@_M_NAME", userName);

            SqlDataReader rdr = conn.ExecuteReader();

            rdr.Read();

            if (rdr.HasRows == true)
            {
                //pwdHash.passwordHash MD5 = new pwdHash.passwordHash();

                //string passMD5 = MD5.Encrypt(pass);

               

                if (pass != rdr["M_PASSWORD"].ToString()) // şifreler uyuşuyor mu
                {
                    donus = ""; // uyuşmuyor ise false
                    HttpContext.Current.Response.Cookies["assc"].Expires = DateTime.Now.AddDays(-1);
                }

                else if (id != Convert.ToInt32(rdr["mid"])) // id ler uyuşuyor mu
                {
                    donus = ""; // uyuşmuyor ise false
                    HttpContext.Current.Response.Cookies["assc"].Expires = DateTime.Now.AddDays(-1);
                }

                else
                {
                    donus = rdr["M_FIRSTNAME"].ToString() + " " + rdr["M_LASTNAME"].ToString();
                }

            }

            else
            {
                donus = "";
                HttpContext.Current.Response.Cookies["assc"].Expires = DateTime.Now.AddDays(-1);
            }

            rdr.Close();
            conn.Dispose();
            bag.Close();

            }
            catch (Exception)
            {

                donus = "";
            }

            return donus;
        }
    }
}