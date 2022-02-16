<%@ WebHandler Language="C#" Class="Upload" %>

using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Collections.Generic;

public class Upload : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        try
        {


            int chunk = context.Request["chunk"] != null ? int.Parse(context.Request["chunk"]) : 0;
            int chunks = context.Request["chunks"] != null ? int.Parse(context.Request["chunks"]) : 0;
            string fileName = context.Request["name"] != null ? context.Request["name"] : string.Empty;

            HttpPostedFile fileUpload = context.Request.Files[0];

            var uploadPath = @"C:\siparisler";
            using (var fs = new FileStream(Path.Combine(uploadPath, fileName), chunk == 0 ? FileMode.Create : FileMode.Append))
            {
                var buffer = new byte[fileUpload.InputStream.Length];
                fileUpload.InputStream.Read(buffer, 0, buffer.Length);

                fs.Write(buffer, 0, buffer.Length);



            }



            if ((chunks == 0) || ((chunks > 0) && (chunk == (chunks - 1))))
            {

                //context.Session["fileN"] = fileName;

                //string cevap = fileName + "Code : " + context.Request["Code"];

                //context.Response.ContentType = "text/plain";
                //context.Response.Write(cevap);


                string json = "{\"dosya\":\""+ fileName +"\", \"code\":\""+ context.Request["Code"] +"\"}";
                context.Response.Clear();
                context.Response.ContentType = "application/json; charset=utf-8";
                context.Response.Write(json);
                context.Response.End();


            }





            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Success");
        }
        catch (System.Exception ex)
        {

            string hata = xmlError.errLog.hataKayit(ex.ToString());
        }


    }

    public bool IsReusable
    {
        get { return false; }
    }
}