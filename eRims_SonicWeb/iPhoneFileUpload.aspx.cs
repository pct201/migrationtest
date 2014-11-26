using System;
using System.IO;
using System.Web;
using System.Web.UI;
using ERIMS.DAL;

public partial class iPhoneFileUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strType = "Picture";
            if (Request.QueryString["InspectionID"] != null)
            {//Inspection Attachment              

                int FK_Inspection_ID = Convert.ToInt32(Request.QueryString["InspectionID"].ToString());
                //set values to store in database
                Inspection_Attachments objAttachment = new Inspection_Attachments();
                objAttachment.FK_Inspection_ID = FK_Inspection_ID;
                objAttachment.Type = strType;

                for (int i = 0; i < Request.Files.Count; i++)
                {   // upload the document
                    string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.ExposureTableNames[(int)clsGeneral.Exposure_Tables.Inspection]).Replace("/", "\\");
                    string strSaveFilePathTemp = string.Concat(strUploadPath, "\\");
                    string strFilePath = System.IO.Path.GetFileName(Request.Files[i].FileName);
                    string strFulleName = string.Concat(strSaveFilePathTemp, strFilePath);
                    
                    if (System.IO.Directory.Exists(strSaveFilePathTemp) == false)
                    {
                        System.IO.Directory.CreateDirectory(strSaveFilePathTemp);
                    }

                    String strSaveFilePath = clsGeneral.GetFileNameToSave(strFulleName);
                    Request.Files[i].SaveAs(strSaveFilePath);

                    objAttachment.path = clsGeneral.GetFileName(strSaveFilePath);
                    objAttachment.Filename = clsGeneral.GetFileName(strSaveFilePath);

                    //Insert the attachment record
                    objAttachment.Insert();
                }
            }
            else if (Request.QueryString["Inspection_ID"] != null && Request.QueryString["Question_ID"] != null)
            {//Focus Area Attachment               

                Inspection_Responses objInspectionresponse = new Inspection_Responses(Convert.ToInt32(Request.QueryString["Question_ID"].ToString()), Convert.ToInt32(Request.QueryString["Inspection_ID"].ToString()));
                int FK_Inspection_Responses_ID = Convert.ToInt32(objInspectionresponse.PK_Inspection_Responses_ID);

                //set values to store in database
                Inspection_Responses_Attachments objAttachment = new Inspection_Responses_Attachments();
                objAttachment.FK_Inspection_Responses_ID = FK_Inspection_Responses_ID;
                objAttachment.Type = strType;

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    // upload the document
                    string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.ExposureTableNames[(int)clsGeneral.Exposure_Tables.Inspection_Responses]).Replace("/", "\\");
                    string strSaveFilePathTemp = string.Concat(strUploadPath, "\\");
                    string strFilePath = System.IO.Path.GetFileName(Request.Files[i].FileName);
                    string strFulleName = string.Concat(strSaveFilePathTemp, strFilePath);

                    if (System.IO.Directory.Exists(strSaveFilePathTemp) == false)
                    {
                        System.IO.Directory.CreateDirectory(strSaveFilePathTemp);
                    }

                    String strSaveFilePath = clsGeneral.GetFileNameToSave(strFulleName);
                    Request.Files[i].SaveAs(strSaveFilePath);

                    objAttachment.Path = clsGeneral.GetFileName(strSaveFilePath);
                    objAttachment.Filename = clsGeneral.GetFileName(strSaveFilePath);

                    //Insert the attachment record
                    objAttachment.Insert();
                }
            }

        }
        catch (Exception ex)
        {
            EmailHelper objEmail = new EmailHelper();
            objEmail.SendMailMessage(AppConfig.MailFrom, "iPhone Test", new string[] { "erims@tatvasoft.com" }, "Test iPhone Attachment", "Test iPhone Attachment : " + ex.Message.ToString() + " - " + ex.StackTrace.ToString(), true, null, "");
        }
    }
}
