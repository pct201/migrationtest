using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS_DAL;

public partial class OutlookAddIn_FileUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // if query string is passed to save the mail from outlook
        if (Request.QueryString["mailGUID"] != null)
        {
            string strDirName = Encryption.Decrypt(Request.QueryString["mailGUID"]);
            string strMailAttachPath = AppConfig.DocumentsPath + "OutlookAttachments";

            // create directory if not exists
            if (!System.IO.Directory.Exists(strMailAttachPath))
            {
                System.IO.Directory.CreateDirectory(strMailAttachPath);
            }

            // get the path to save the mails
            string strDirPath = strMailAttachPath + "\\" + strDirName;

            // create directory if not exists
            if (!System.IO.Directory.Exists(strDirPath))
            {
                System.IO.Directory.CreateDirectory(strDirPath);
            }

            // copy the files 
            for (int i = 0; i < Request.Files.Count; i++)
            {
                Request.Files[i].SaveAs(strDirPath + "\\" + Request.Files[i].FileName);
            }


            clsGeneral.OutlookAttachmentsInsert(DateTime.Today, strDirName);  // track in DB for created directory so it can be removed using nightly job
        }
        else if (Request.QueryString["ctyp"] != null && Convert.ToString(Request.QueryString["ctyp"])!=string.Empty)
        {

            int AttachmentPK = 0;
            int.TryParse(Request.QueryString["pkid"], out AttachmentPK);
            string strClaimType = Convert.ToString(Request.QueryString["ctyp"]);

            //set values to store in database
            //clsAttachment objAttachment = new clsAttachment();
            //objAttachment.Attachment_Table = strClaimType;
            //objAttachment.FK_Table = AttachmentPK;
            //objAttachment.FK_Attachment_Type = 0;
            //objAttachment.Updated_By = clsSession.UserID;
            //objAttachment.Update_Date = DateTime.Now;
            //objAttachment.Attach_Date = DateTime.Now;
                       
            for (int i = 0; i < Request.Files.Count; i++)
            {   // upload the document
                string strUploadPath = AppConfig.DocumentsPath + strClaimType + "\\";
                string strFilePath = System.IO.Path.GetFileName(Request.Files[i].FileName);
                string strFulleName = string.Concat(strUploadPath, strFilePath);

                if (System.IO.Directory.Exists(strUploadPath) == false)
                {
                    System.IO.Directory.CreateDirectory(strUploadPath);
                }

                Request.Files[i].SaveAs(strFulleName);

                //objAttachment.Attachment_Name = Request.Files[i].FileName;
                //objAttachment.Attachment_Description = "";

                //int intAttachID = objAttachment.Insert();
            }
        }
    }
}