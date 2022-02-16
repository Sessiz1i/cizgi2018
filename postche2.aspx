<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="connectionStr" %>
<%@ Import Namespace="mailer" %>

<html xmlns="http://www.w3.org/1999/xhtml" 
> <head runat="server">
    <title>3d Pay Payment 
        Page</title> </head>
<body>
<h1>3D Payment Page</h1>
<h3> Payment Response</h3> 
<table border="1">
<tr>
    <td><b>Parameter Name</b></td> 
    <td><b>Parameter Value</b></td>
</tr>
<%




    String[] odemeparametreleri = new String[] { "AuthCode", "Response", "HostRefNum", "ProcReturnCode", "TransId", "ErrMsg" };

    IEnumerator e = Request.Form.GetEnumerator();
    while (e.MoveNext())
    {
        String xkey = (String)e.Current;
        String xval = Request.Form.Get(xkey);
        bool ok = true;
        for (int i = 0; i < odemeparametreleri.Length; i++)
        {
            if (xkey.Equals(odemeparametreleri[i]))
            {
                ok = false;
                break;
            }
        }
        if(ok)
            Response.Write("<tr><td>" +xkey +"</td><td>"+ xval+"</td></tr>");
    }
    Response.Write("</table>");
    String hashparams = Request.Form.Get("HASHPARAMS");
    String hashparamsval = Request.Form.Get("HASHPARAMSVAL");
    String storekey = "42OvKfKU1FD0Q4Sd5hhJ4a";
    String paramsval = "";
    int index1 = 0, index2 = 0;
    do
    {
        index2 = hashparams.IndexOf(":", index1);
        String val = Request.Form.Get(hashparams.Substring(index1, index2-index1)) == null ? "" : Request.Form.Get(hashparams.Substring(index1, index2-index1));
        paramsval += val;
        index1 = index2 + 1;
    }
    while (index1 < hashparams.Length);
    //out.println("hashparams="+hashparams+"<br/>");
    //out.println("hashparamsval="+hashparamsval+"<br/>");
    //out.println("paramsval="+paramsval+"<br/>"); 
    String hashval = paramsval + storekey;
    String hashparam = Request.Form.Get("HASH");
    System.Security.Cryptography.SHA1 sha = new
    System.Security.Cryptography.SHA1CryptoServiceProvider();
    byte[] hashbytes = System.Text.Encoding.GetEncoding("ISO-8859-9").GetBytes(hashval);
    byte[] inputbytes = sha.ComputeHash(hashbytes);
    String hash = Convert.ToBase64String(inputbytes);
    if (!paramsval.Equals(hashparamsval) || !hash.Equals(hashparam))
    {
        Response.Write("<h4>Security Alert. The digital signature is not valid.</h4>");
    }
    String mdStatus = Request.Form.Get("mdStatus");

    string isim = "";
    string maskedPans = "";
    string paymentDate = "";

    String ReturnOid = Request.Form.Get("sipNumber");

    string mailBoddy = "";
    string mailBoddyOn = "";

    try
    {
        if (!string.IsNullOrEmpty(Request.Form.Get("EXTRA.TRXDATE")))
        {
            paymentDate = Request.Form.Get("EXTRA.TRXDATE");
        }

        else
        {
            paymentDate = "";
        }

    }
    catch (Exception)
    {
        paymentDate = "";
    }


    try
    {
        if (!string.IsNullOrEmpty(Request.Form.Get("MaskedPan")))
        {
            maskedPans = Request.Form.Get("MaskedPan");
        }

        else
        {
            maskedPans = "";
        }
    }
    catch (Exception)
    {
        maskedPans = "";
    }

    try
    {
        if (!string.IsNullOrEmpty(Request.Form.Get("ccisim")))
        {
            isim = Request.Form.Get("ccisim");
        }

        else
        {
            isim = "";
        }
    }
    catch (Exception)
    {
        isim = "";
    }

    string siparisSHAVeri = "";

    try
    {
        connectionStr.DBIslem xy = new connectionStr.DBIslem();

        SqlConnection bag2 = xy.Baglanti();

        string sipSql2 = "select siparisSHA from siparis where id=@id";

        SqlCommand sd2 = new SqlCommand(sipSql2, bag2);
        sd2.Parameters.AddWithValue("@id", Request.Form.Get("sipNumber").Replace("CIZGIPAN", ""));

        SqlDataReader rr = sd2.ExecuteReader();

        rr.Read();

        siparisSHAVeri = rr["siparisSHA"].ToString();

        rr.Close();
        rr.Dispose();
        sd2.Dispose();
        bag2.Close();
        bag2.Dispose();
    }
    catch (Exception ee)
    {
        Response.Write(ee);
        siparisSHAVeri = "";
    }



    if(mdStatus.Equals("1") || mdStatus.Equals("2") || mdStatus.Equals("3") || mdStatus.Equals("4"))
    {



        // mailBoddy += "<h5>3D Transaction is Success</h5><br/>";
        mailBoddy += "<h3> Payment Response</h3>";
        mailBoddy += "<table border='1'>";
        mailBoddy += "<tr>";
        mailBoddy += "<td><b>Parameter Name</b></td>";
        mailBoddy += "<td><b>Parameter Value</b></td>";
        mailBoddy += "</tr>";


        Response.Write("<h2>3D Transaction is Success</h2><br/> ");
        Response.Write("<h3> Payment Response</h3>");
        Response.Write("<table border='1'>");
        Response.Write("<tr>");
        Response.Write("<td><b>Parameter Name</b></td> ");
        Response.Write("<td><b>Parameter Value</b></td>");
        Response.Write("</tr>");
        for(int i=0;i<odemeparametreleri.Length;i++)
        {
            String paramname = odemeparametreleri[i]; String
                paramval = Request.Form.Get(paramname);
            Response.Write("<tr><td>"+paramname+"</td><td>"+paramval+"</td></tr>");

            mailBoddy += "<tr><td>" + paramname + "</td><td>" + paramval + "</td></tr>";
        }
        Response.Write("</table>");





        if("Approved".Equals(Request.Form.Get("Response")))
        {
            Response.Write(" <h6>Transaction is Success</h6>");





            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();

            string sipSql = "insert into ppipn(ppipn_item_number, ppipn_payment_status, ppipn_payment_amount, ppipn_payment_currency, ppipn_shipping, ppipn_payer_email, ppipn_payment_date_tr, ppipn_first_name, ppipn_last_name, ppipn_siparis_id, ppipn_kargo_id, ppipn_mid, ppipn_paketgram, ppipn_security_key, ppipn_member_ip, ppipn_active, ppipn_paytype, ppipn_taksit, ppipn_odenenbanka, ppipn_payment_mpan) values(@ppipn_item_number, @ppipn_payment_status, @ppipn_payment_amount, @ppipn_payment_currency, @ppipn_shipping, @ppipn_payer_email, @ppipn_payment_date_tr, @ppipn_first_name, @ppipn_last_name, @ppipn_siparis_id, @ppipn_kargo_id, @ppipn_mid, @ppipn_paketgram, @ppipn_security_key, @ppipn_member_ip, @ppipn_active, @ppipn_paytype, @ppipn_taksit, @ppipn_odenenbanka, @ppipn_payment_mpan)";

            SqlCommand sd = new SqlCommand(sipSql, bag);
            sd.Parameters.AddWithValue("@ppipn_item_number", Request.Form.Get("sipNumber").Replace("CIZGIPAN", ""));
            sd.Parameters.AddWithValue("@ppipn_payment_status", "Completed");
            sd.Parameters.AddWithValue("@ppipn_payment_amount", Convert.ToDouble(Request.Form.Get("amount")));
            sd.Parameters.AddWithValue("@ppipn_payment_currency", "TRY");
            sd.Parameters.AddWithValue("@ppipn_shipping", "0");
            sd.Parameters.AddWithValue("@ppipn_payer_email", "");
            sd.Parameters.AddWithValue("@ppipn_payment_date_tr", DateTime.Now);
            sd.Parameters.AddWithValue("@ppipn_first_name", isim);
            sd.Parameters.AddWithValue("@ppipn_last_name", "");
            sd.Parameters.AddWithValue("@ppipn_siparis_id", Request.Form.Get("sipNumber").Replace("CIZGIPAN", ""));
            sd.Parameters.AddWithValue("@ppipn_kargo_id", "0");
            sd.Parameters.AddWithValue("@ppipn_mid", "0"); // müşteri id girilecek
            sd.Parameters.AddWithValue("@ppipn_paketgram", "0");
            sd.Parameters.AddWithValue("@ppipn_security_key", "");
            sd.Parameters.AddWithValue("@ppipn_member_ip", Request.Form.Get("clientIp"));
            sd.Parameters.AddWithValue("@ppipn_active", "1");
            sd.Parameters.AddWithValue("@ppipn_paytype", "2");
            sd.Parameters.AddWithValue("@ppipn_taksit", "");
            sd.Parameters.AddWithValue("@ppipn_odenenbanka", "HALKBANK");
            sd.Parameters.AddWithValue("@ppipn_payment_mpan", maskedPans);


            sd.ExecuteNonQuery();

            sd.Dispose();
            bag.Close();
            bag.Dispose();

            mailBoddyOn = "<br><br><br><h1 style='color:blue'>" + isim + " tarafından " + paymentDate + " tarihinde " + maskedPans + " numaralı kart ile " + Request.Form.Get("amount") + " tutarında ödeme yapıldı.</h1>";

            mailer.mailSender xx = new mailer.mailSender();

            xx.cardDurumMail(Request.Form.Get("sipNumber").Replace("CIZGIPAN", ""), "Sipariş " + Request.Form.Get("sipNumber").Replace("CIZGIPAN", "") + " Başarılı Ödeme", mailBoddyOn + mailBoddy);
            //clientIp

            //HttpContext contexts = HttpContext.Current;
            //contexts.Items.Add("siparisID", Request.Form.Get("sipNumber").Replace("CIZGIPAN", ""));
            //contexts.Items.Add("tutar", Request.Form.Get("amount"));
            //contexts.Items.Add("durum", "0");
            //contexts.Items.Add("isim", isim);

            string s = pwdHash.passwordHash.Sifrele2(Request.Form.Get("sipNumber").Replace("CIZGIPAN", "") + "&" + Request.Form.Get("amount") + "&" + "&durum=0");

            //Response.Redirect("/siparis-odeme?odeme=" + siparisSHAVeri + "&s=" + s);


        }else
        {
            Response.Write("<h6>Transaction is not Success</h6>");

            mailBoddyOn = "<br><br><br><h1 style='color:red'>" + isim + " tarafından " + paymentDate + " tarihinde " + maskedPans + " numaralı kart ile " + Request.Form.Get("amount") + " tutarında ödeme denendi.</h1>";

            mailer.mailSender xx = new mailer.mailSender();

            xx.cardDurumMail(Request.Form.Get("sipNumber").Replace("CIZGIPAN", ""), "Sipariş " + Request.Form.Get("sipNumber").Replace("CIZGIPAN", "") + " Hatalı Deneme", mailBoddyOn + mailBoddy);

            //HttpContext contexts = HttpContext.Current;
            //contexts.Items.Add("siparisID", Request.Form.Get("sipNumber").Replace("CIZGIPAN", ""));
            //contexts.Items.Add("tutar", Request.Form.Get("amount"));
            //contexts.Items.Add("durum", "1");
            //contexts.Items.Add("isim", isim);

            string s = pwdHash.passwordHash.Sifrele2(Request.Form.Get("sipNumber").Replace("CIZGIPAN", "") + "&" + Request.Form.Get("amount") + "&" + "&durum=1");

            //Response.Redirect("/siparis-odeme?odeme=" + siparisSHAVeri + "&s=" + s);
        }
    }

    else {
        Response.Write("<h5>3D Transaction is not Success</h5>");

        mailBoddyOn = "<br><br><br><h1 style='color:red'>" + isim + " tarafından " + paymentDate + " tarihinde " + maskedPans + " numaralı kart ile " + Request.Form.Get("amount") + " tutarında ödeme denendi.</h1>";

        mailer.mailSender xx = new mailer.mailSender();

        xx.cardDurumMail(Request.Form.Get("sipNumber").Replace("CIZGIPAN", ""), "Sipariş " + Request.Form.Get("sipNumber").Replace("CIZGIPAN", "") + " Hatalı Deneme", mailBoddyOn + mailBoddy);

        //HttpContext contexts = HttpContext.Current;
        //contexts.Items.Add("siparisID", Request.Form.Get("sipNumber").Replace("CIZGIPAN", ""));
        //contexts.Items.Add("tutar", Request.Form.Get("amount"));
        //contexts.Items.Add("durum", "1");
        //contexts.Items.Add("isim", isim);

        string s = pwdHash.passwordHash.Sifrele2(Request.Form.Get("sipNumber").Replace("CIZGIPAN", "") + "&" + Request.Form.Get("amount") + "&" + "&durum=1");

        //Response.Redirect("/siparis-odeme?odeme=" + siparisSHAVeri + "&s=" + s);

    }

%>
</body>
</html>
