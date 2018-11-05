using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using ERIMS.DAL;

public partial class ReplaceAttachment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnReplace_Click(object sender, EventArgs e)
    {
        string strFilePath = Encryption.Decrypt(Request.QueryString["filename"]);
        //string strFileName = strFilePath.Substring(strFilePath.LastIndexOf("\\") + 1);
        //string strExtension = strFileName.Substring(strFileName.LastIndexOf("."));
        //strFileName = strFileName.Replace(strExtension, "");
        //string strDocPath = strFilePath.Substring(0, strFilePath.LastIndexOf("\\"));

        //// upload and set the filename.
        //clsGeneral.UploadFile(fpFile,strDocPath,strFileName, false, true);
        //Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "window.close();", true);


        //set values to store in database
        ERIMSAttachment objAttachment = new ERIMSAttachment(Convert.ToDecimal(Request.QueryString["pk"]));
        objAttachment.Updated_By = clsSession.UserID;
        objAttachment.Update_Date = DateTime.Today;

        // upload the document
        string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[Convert.ToInt32(Request.QueryString["tbl"])]);
        string DocPath = string.Concat(strUploadPath, "\\");

        // upload and set the filename.
        objAttachment.Attachment_Name = clsGeneral.UploadFile(fpFile, DocPath, false, false);
        //objAttachment.Attachment_Name = GetCustomFileName() + objAttachment.Attachment_Name;
        //Insert the attachment record
        objAttachment.Update();
        if (File.Exists(strFilePath))
            File.Delete(strFilePath);
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "window.opener.document.getElementById('" + Request.QueryString["btnID"] + "').click();window.close();", true);
    }
}
