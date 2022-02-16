using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using connectionStr;
using System.Data.SqlClient;

namespace mailUsrChk
{ 
/// <summary>
/// Mail veya kullanıcı adı daha önce kayıtlı mı kontrol eder !
/// </summary>
public class mailusernamechecker
{
        /// <summary>
        /// Kullanıcının yazdığı email adresini db ' de kayıtlı olup olmadığını kontrol eder
        /// </summary>
        /// <param name="email">Kayıt olacak email adresi</param>
        /// <returns></returns>
        public bool mailCheck(string email)
        {
            bool donus = false;

            connectionStr.DBIslem baglan = new connectionStr.DBIslem();
            SqlConnection bag = baglan.Baglanti();

            string sql = "Select M_EMAIL from member where M_EMAIL=@email";


            SqlCommand conn = new SqlCommand(sql, bag);
            conn.Parameters.AddWithValue("@email", email);

            SqlDataReader rdrMailCheck = conn.ExecuteReader();

            if (rdrMailCheck.HasRows != true)
            {
                donus = true;
            }

            rdrMailCheck.Close();
            conn.Dispose();
            bag.Close();

            return donus;
        }

        /// <summary>
        /// Kullanıcının yazdığı kullanıcı adını db ' de kayıtlı olup olmadığını kontrol eder
        /// </summary>
        /// <param name="username">Kayıt olacak kullanıcı adı</param>
        /// <returns></returns>
        public bool usernameCheck(string username)
        {
            bool donus = false;

            connectionStr.DBIslem baglan = new connectionStr.DBIslem();
            SqlConnection bag = baglan.Baglanti();

            string sql = "Select M_NAME from member where M_NAME=@M_NAME";


            SqlCommand conn = new SqlCommand(sql, bag);
            conn.Parameters.AddWithValue("@M_NAME", username);

            SqlDataReader rdrUsernameCheck = conn.ExecuteReader();

            if (rdrUsernameCheck.HasRows != true)
            {
                donus = true;
            }

            rdrUsernameCheck.Close();
            conn.Dispose();
            bag.Close();

            return donus;
        }
    }
}