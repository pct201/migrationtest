using System;
using System.IO;
using System.Web;
using System.Web.UI;
using ERIMS.DAL;
using iTextSharp.text.pdf;

public partial class ACIFileUpload : System.Web.UI.Page
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
                    case "OUTLOOK":
                        #region Construction Module
                        if (Request.QueryString["PrjID"] != null)
                        {
                            string strUploadPath = AppConfig.strFCPDocumentPath;
                            string strSaveFilePathTemp = string.Concat(strUploadPath, "\\");
                            string strFilePath = Convert.ToString(Request.QueryString["FileName"]);
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
                    case "MAINTENANCE":
                        #region Construction Module
                        if (Request.QueryString["PrjID"] != null)
                        {
                            string strUploadPath = AppConfig.MaintenanceDocPath;
                            string strSaveFilePathTemp = string.Concat(strUploadPath, "\\");
                            string strFilePath = Convert.ToString(Request.QueryString["FileName"]);
                            string strFulleName = string.Concat(strSaveFilePathTemp, strFilePath);

                            if (System.IO.Directory.Exists(strSaveFilePathTemp) == false)
                            {
                                System.IO.Directory.CreateDirectory(strSaveFilePathTemp);
                            }

                            //String strSaveFilePath = clsGeneral.GetFileNameToSave(strFulleName);
                            Request.Files[0].SaveAs(strFulleName);
                        }
                        else
                        { Response.Write("Project ID Not found"); }
                        #endregion
                        break;
                    case "BUILDINGATTACHMENTS":
                        string uploadPath = string.Concat(AppConfig.BuildingAttachDocPath, "\\");
                        string strattachFilePath = System.IO.Path.GetFileName(Request.Files[0].FileName);
                        string strAttachFullName = string.Concat(uploadPath, strattachFilePath);

                        if (System.IO.Directory.Exists(uploadPath) == false)
                        {
                            System.IO.Directory.CreateDirectory(uploadPath);
                        }

                        Request.Files[0].SaveAs(strAttachFullName);
                        break;
                    case "SUBLEASE":
                        string uploadSubleasePath = string.Concat(AppConfig.LeaseSubleaseDocPath, "\\");
                        string strSubleaseFilePath = System.IO.Path.GetFileName(Request.Files[0].FileName);
                        string strSubLeaseAttachFullName = string.Concat(uploadSubleasePath, strSubleaseFilePath);

                        if (System.IO.Directory.Exists(uploadSubleasePath) == false)
                        {
                            System.IO.Directory.CreateDirectory(uploadSubleasePath);
                        }

                        Request.Files[0].SaveAs(strSubLeaseAttachFullName);
                        break;
                    case "INSURANCE":
                        string uploadInsurancePath = string.Concat(AppConfig.PropertyCOIDocPath, "\\");
                        string strInsuranceFilePath = System.IO.Path.GetFileName(Request.Files[0].FileName);
                        string strInsuranceAttachFullName = string.Concat(uploadInsurancePath, strInsuranceFilePath);

                        if (System.IO.Directory.Exists(uploadInsurancePath) == false)
                        {
                            System.IO.Directory.CreateDirectory(uploadInsurancePath);
                        }

                        Request.Files[0].SaveAs(strInsuranceAttachFullName);
                        break;
                    case "DELETEBUILDINGATTACHMENTS":
                        string deleteAttachmentPath = string.Concat(AppConfig.BuildingAttachDocPath, "\\");
                        string deleteFileName = Convert.ToString(Request.QueryString["fileName"]); // System.IO.Path.GetFileName(Request.Files[0].FileName);

                        string[] files = Directory.GetFiles(deleteAttachmentPath, deleteFileName);
                        if (files != null && files.Length > 0)
                        {
                            System.IO.File.Delete(files[0]);
                        }
                        break;
                    case "DELETESUBLEASE":
                        string deleteSubLeaseAttachmentPath = string.Concat(AppConfig.LeaseSubleaseDocPath, "\\");
                        string deleteSubLeaseFileName = Convert.ToString(Request.QueryString["fileName"]); // System.IO.Path.GetFileName(Request.Files[0].FileName);

                        string[] subleasefiles = Directory.GetFiles(deleteSubLeaseAttachmentPath, deleteSubLeaseFileName);
                        if (subleasefiles != null && subleasefiles.Length > 0)
                        {
                            System.IO.File.Delete(subleasefiles[0]);
                        }
                        break;
                    case "DELETEINSURANCE":
                        string deleteInsuranceAttachmentPath = string.Concat(AppConfig.PropertyCOIDocPath, "\\");
                        string deleteInsuranceFileName = Convert.ToString(Request.QueryString["fileName"]); // System.IO.Path.GetFileName(Request.Files[0].FileName);

                        string[] insurancefiles = Directory.GetFiles(deleteInsuranceAttachmentPath, deleteInsuranceFileName);
                        if (insurancefiles != null && insurancefiles.Length > 0)
                        {
                            System.IO.File.Delete(insurancefiles[0]);
                        }
                        break;
                    case "DELETEOUTLOOK":
                        string deleteOutlookAttachmentPath = string.Concat(AppConfig.strFCPDocumentPath, "\\");
                        string deleteOutlookFileName = Convert.ToString(Request.QueryString["fileName"]); // System.IO.Path.GetFileName(Request.Files[0].FileName);

                        string[] outlookFiles = Directory.GetFiles(deleteOutlookAttachmentPath, deleteOutlookFileName);
                        if (outlookFiles != null && outlookFiles.Length > 0)
                        {
                            if (File.Exists(outlookFiles[0]))
                            {
                                System.IO.File.Delete(outlookFiles[0]);
                            }
                        }
                        break;
                    case "DELETEMAINTENANCE":
                        string deleteMaintenanceAttachmentPath = string.Concat(AppConfig.MaintenanceDocPath, "\\");
                        string deleteMaintenanceFileName = Convert.ToString(Request.QueryString["fileName"]); // System.IO.Path.GetFileName(Request.Files[0].FileName);

                        string[] maintenanceFiles = Directory.GetFiles(deleteMaintenanceAttachmentPath, deleteMaintenanceFileName);
                        if (maintenanceFiles != null && maintenanceFiles.Length > 0)
                        {
                            if (File.Exists(maintenanceFiles[0]))
                            {
                                System.IO.File.Delete(maintenanceFiles[0]);
                            }
                        }
                        break;
                    case "MANAGEMENT":
                        try
                        {
                            string strACIUploadPath = AppConfig.DocumentsPath + "Attach";
                            string strACISaveFilePathTemp = string.Concat(strACIUploadPath, "\\");
                            string strACIFilePath = System.IO.Path.GetFileName(Request.Files[0].FileName);
                            string strACIFulleName = string.Concat(strACISaveFilePathTemp, strACIFilePath);

                            if (System.IO.Directory.Exists(strACISaveFilePathTemp) == false)
                            {
                                System.IO.Directory.CreateDirectory(strACISaveFilePathTemp);
                            }

                            Request.Files[0].SaveAs(strACIFulleName);
                            Response.Clear();
                            Response.Write("Success");
                            Response.Flush();
                        }
                        catch (Exception ex)
                        {
                            Response.Clear();
                            Response.Write("Fail");
                            Response.Flush();
                        }
                        break;
                    case "DELETEMANAGEMENT":
                        string deleteManagementAttachmentPath = string.Concat(AppConfig.DocumentsPath + "Attach", "\\");
                        string deleteManagementFileName = Encryption.Decrypt(Convert.ToString(Request.QueryString["fileName"]));

                        string[] managementFiles = Directory.GetFiles(deleteManagementAttachmentPath, deleteManagementFileName);
                        if (managementFiles != null && managementFiles.Length > 0)
                        {
                            if (File.Exists(managementFiles[0]))
                            {
                                System.IO.File.Delete(managementFiles[0]);
                            }
                        }
                        break;

                    default: break;
                }

            }
        }
        catch (Exception ex)
        {
            EmailHelper objEmail = new EmailHelper();
            objEmail.SendMailMessage(AppConfig.MailFrom, "ACI File Upload", new string[] { "erims@tatvasoft.com" }, "ACI File Upload", "ACI File Upload : " + ex.Message.ToString() + " - " + ex.StackTrace.ToString(), true, null, "");
        }
    }

    /// <summary>
    /// Used to generate the thumbnail image of PDF
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    private string GetThumbnailImagePath(string filepath)
    {
        // get extension of a file
        string strFileName = "";
        string extension = System.IO.Path.GetExtension(filepath);

        // if extension is .pdf
        if (extension == ".PDF" || extension == ".pdf")
        {
            // generate thumbnail file name
            strFileName = filepath.Substring(filepath.LastIndexOf("\\") + 1);
            strFileName = strFileName.Replace(".pdf", "").Replace(".PDF", "");
            strFileName = strFileName + "_Thumb.jpg";

            // get the bytes of pdf
            FileStream fs = new FileStream(filepath, FileMode.Open);
            byte[] pdf = new byte[fs.Length];
            fs.Read(pdf, 0, (int)fs.Length);

            // save the thumbnail image
            //PDFParser.Parse parser = new PDFParser.Parse();
            //List<System.Drawing.Image> images = parser.Split(pdf);
            //if (images.Count > 0)
            //{
            //    images[0].Save(AppConfig.DocumentsPath + "Attach\\" + strFileName);
            //    images[0].Dispose();
            //}
            fs.Close();
            fs.Dispose();
        }
        return strFileName;
    }

    /// <summary>
    /// Used to get count of pages in a PDF
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    private int? GetPDFPageCount(string filepath)
    {
        int? page_count = null;
        //check for the extension                 
        string extension = System.IO.Path.GetExtension(filepath);
        if (extension == ".PDF" || extension == ".pdf")
        {
            try
            {
                //Create instance for the PDF reader                    
                PdfReader pdf_fie = new PdfReader(filepath);
                //read it's pagecount                    
                page_count = pdf_fie.NumberOfPages;
                //close the file                    
                pdf_fie.Close();
            }
            catch (Exception e)
            {
                page_count = 0;
            }
        }
        return page_count;
    }
}