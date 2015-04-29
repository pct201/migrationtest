using System;
using System.IO;
using System.Web;
using System.Web.UI;
using ERIMS.DAL;

public partial class PortalFileUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strType = string.Empty, moduleName = string.Empty;

            if (Request.QueryString["module"] != null)
            {
                moduleName = Request.QueryString["module"].ToUpper();
                switch (moduleName)
                {
                    case "CONSTRUCTION":
                        #region Construction Module
                        if (Request.QueryString["PrjID"] != null)
                        {

                            string strUploadPath = AppConfig.strFCPDocumentPath;
                            string strSaveFilePathTemp = string.Concat(strUploadPath, "\\");
                            string strFilePath = System.IO.Path.GetFileName(Request.Files[0].FileName);
                            string strFulleName = string.Concat(strSaveFilePathTemp, strFilePath);

                            if (System.IO.Directory.Exists(strSaveFilePathTemp) == false)
                            {
                                System.IO.Directory.CreateDirectory(strSaveFilePathTemp);
                            }

                            //String strSaveFilePath = clsGeneral.GetFileNameToSave(strFulleName);
                            Request.Files[0].SaveAs(strFulleName);
                            int FK_FCP_Identification = Convert.ToInt32(Request.QueryString["PrjID"].ToString());
                            int PK_LU_FC_Document_Folder = Convert.ToInt32(Request.QueryString["FldID"].ToString());
                            string Updated_By = Request.QueryString["UID"].ToString();
                            FCP_Attachments objFCP_Attachments = new FCP_Attachments(); objFCP_Attachments.FK_FCP_Identification = FK_FCP_Identification;
                            objFCP_Attachments.PK_LU_FC_Document_Folder = PK_LU_FC_Document_Folder;
                            objFCP_Attachments.Attachment_Filename = clsGeneral.GetFileName(strFulleName);
                            objFCP_Attachments.Attachment_Description = objFCP_Attachments.Attachment_Filename.Substring(12, objFCP_Attachments.Attachment_Filename.Length - 12);
                            //objFCP_Attachments.Filename = clsGeneral.GetFileName(strSaveFilePath);

                            objFCP_Attachments.Updated_By = Updated_By;
                            objFCP_Attachments.Update_Date = DateTime.Now;
                            objFCP_Attachments.Attach_Date = DateTime.Now;
                            objFCP_Attachments.Updated_By_Table = "Contractor_Security";
                            //Insert the attachment record
                            objFCP_Attachments.Insert();

                        }
                        else
                        { Response.Write("Project ID Not found"); }
                        #endregion
                        break;
                    default: break;
                }

            }
        }
        catch (Exception ex)
        {
            EmailHelper objEmail = new EmailHelper();
            objEmail.SendMailMessage(AppConfig.MailFrom, "Portal File Upload", new string[] { "erims@tatvasoft.com" }, "Portal File Upload", "Portal File Upload : " + ex.Message.ToString() + " - " + ex.StackTrace.ToString(), true, null, "");
        }
    }
}
