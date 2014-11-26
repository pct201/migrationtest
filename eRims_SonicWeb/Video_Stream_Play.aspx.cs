using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Video_Stream_Play : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = Encryption.Decrypt(Request.QueryString["path"]);
        if (!string.IsNullOrEmpty(url))
        {
            Response.Redirect(url + "?DateTime=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            ////Initialize the input stream
            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //req.Timeout = -1;
            //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            //int bufferSize = 1;

            ////Initialize the output stream
            //Response.Clear();
            //Response.AppendHeader("Content-Disposition:", "attachment; filename=" + clsGeneral.GetFileName(url));
            //Response.AppendHeader("Content-Length", resp.ContentLength.ToString());
            //Response.ContentType = "application/download";

            ////Populate the output stream
            //byte[] ByteBuffer = new byte[bufferSize + 1];
            //MemoryStream ms = new MemoryStream(ByteBuffer, true);
            //Stream rs = req.GetResponse().GetResponseStream();
            //byte[] bytes = new byte[bufferSize + 1];
            //while (rs.Read(ByteBuffer, 0, ByteBuffer.Length) > 0)
            //{
            //    Response.BinaryWrite(ms.ToArray());
            //    Response.Flush();
            //}

            ////Cleanup
            //Response.End();
            //ms.Close();
            //ms.Dispose();
            //rs.Dispose();
            //ByteBuffer = null;
        }
    }
}