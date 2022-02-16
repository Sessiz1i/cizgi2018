using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


namespace connectionStr
{ 
    //Bağlantı Sınıfım
    public class DBIslem
    {
        //Veritabanı bağlantım
        public SqlConnection Baglanti()
        {
            //Bağlantımı ConfigurationManager ile web config dosyasından çekiyorum
            string ConnectionString = ConfigurationManager.ConnectionStrings["mrtAlb1"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;


        }

    }


    public class tarihDuzenleIleri 
    {
        public string tarihDuzelenen1()
        {
            string getTodayTarih = DateTime.Now.ToShortDateString().ToString() + " 00:00:01";
            return getTodayTarih;
        }

        public string tarihDuzenlenen2()
        {
            string getTodayTarih = DateTime.Now.ToShortDateString().ToString() + " 23:59:59";
            return getTodayTarih;
        }

    }
}
