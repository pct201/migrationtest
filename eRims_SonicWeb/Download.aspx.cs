using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.IO;
using System.Text;
using System.Data;

public partial class Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if Attachment ID is passed or not and Session is not expire.

           
            if (!string.IsNullOrEmpty(Request.QueryString["fname"]))
            {

                string strFileName = Encryption.Decrypt(Request.QueryString["fname"]);
                string strFilePath = "";
                #region "SafetyWalk"
                if (!string.IsNullOrEmpty(Request.QueryString["SLT"]))
                {
                    if (Request.QueryString["SLT"] == "safetywalk")
                    {
                        strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.SLT_TablesNames[(int)clsGeneral.SLT_Tables.SLT_Safety_Walk]) + strFileName;
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", strFileName.Substring(12)));
                        HttpContext.Current.Response.ContentType = "application/ms-word";
                        HttpContext.Current.Response.TransmitFile(strFilePath);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                    else if (Request.QueryString["SLT"] == "BTSecuritywalk")
                    {
                        strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.SLT_TablesNames[(int)clsGeneral.SLT_Tables.SLT_BT_Security_Walk]) + strFileName;
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", strFileName.Substring(12)));
                        HttpContext.Current.Response.ContentType = "application/ms-word";
                        HttpContext.Current.Response.TransmitFile(strFilePath);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();

                    }
                    else if (Request.QueryString["SLT"] == "training")
                    {
                        strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.SLT_TablesNames[(int)clsGeneral.SLT_Tables.SLT_Training]) + strFileName;
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", strFileName.Substring(12)));
                        HttpContext.Current.Response.ContentType = "application/ms-word";
                        HttpContext.Current.Response.TransmitFile(strFilePath);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();

                    }
                    else if (Request.QueryString["SLT"] == "EPM_Docs")
                    {
                        string strEPMFileName = Encryption.Decrypt(Request.QueryString["fname"]);
                        string strEPMFilePath = AppConfig.strEPMDocumentPath + strFileName;
                        // Transfer File
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", strFileName.Substring(12)));
                        HttpContext.Current.Response.ContentType = "application/octet-stream";
                        HttpContext.Current.Response.TransmitFile(strEPMFilePath);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();                        
                    }
                    else if (Request.QueryString["SLT"] == "FCP_Docs")
                    {
                        string strFCPFileName = Encryption.Decrypt(Request.QueryString["fname"]);
                        string strFCPFilePath = AppConfig.strFCPDocumentPath + strFileName;
                        // Transfer File
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", strFileName.Substring(12)));
                        HttpContext.Current.Response.ContentType = "application/octet-stream";
                        HttpContext.Current.Response.TransmitFile(strFCPFilePath);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                    else if (Request.QueryString["SLT"] == "AP_Docs")
                    {
                        string strEPMFileName = Encryption.Decrypt(Request.QueryString["fname"]);
                        string strEPMFilePath = AppConfig.strAPDocumentPath + strFileName;
                        // Transfer File
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", strFileName.Substring(12)));
                        HttpContext.Current.Response.ContentType = "application/octet-stream";
                        HttpContext.Current.Response.TransmitFile(strEPMFilePath);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                   
                }
                #endregion
                else
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Certificate_Of_Insurance.doc"));
                    HttpContext.Current.Response.ContentType = "application/ms-word";
                    HttpContext.Current.Response.TransmitFile(strFileName);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.End();
                }
                //Transfer File
            }
            else if (Request.QueryString["tbl"] == "PM_Respiratory_Protection_Attachments")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OC_Attch_Id"]))
                {
                    DataTable dtAttachments = clsPM_Respiratory_Protection_Attachments.SelectAttachmentByPK(clsGeneral.GetDecimal
                                                (Encryption.Decrypt(Request.QueryString["OC_Attch_Id"]).ToString())).Tables[0];

                    if (dtAttachments.Rows.Count > 0)
                    {
                        string strRpFileName = Convert.ToString(dtAttachments.Rows[0]["NewAttachment_Name"]);
                        string strOriginalFileName = Convert.ToString(dtAttachments.Rows[0]["File_Name"]);
                        string strRpFilePath = AppConfig.PM_Respiratory_Protection_AttachmentsDocPath + strOriginalFileName;
                        // Transfer File
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", strRpFileName));
                        HttpContext.Current.Response.ContentType = "application/octet-stream";
                        HttpContext.Current.Response.TransmitFile(strRpFilePath);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["attachfile"]))
            {
                string strFilePath = Encryption.Decrypt(Request.QueryString["attachfile"]);
                //string strFileName = strFilePath.Substring(strFilePath.LastIndexOf("/") + 1);
                string strFileName = Path.GetFileName(strFilePath);
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", strFileName));
                HttpContext.Current.Response.ContentType = "application/ms-word";
                HttpContext.Current.Response.TransmitFile(strFilePath);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["outlook"]))
            {
                string strFileName = AppConfig.DocumentsPath + "OutlookAttachments\\" + clsSession.AttachFilePath + "\\" + Encryption.Decrypt(Request.QueryString["fpath"]);
                string strUserFileName = strFileName.Substring(strFileName.LastIndexOf('\\') + 1).Substring(12);
                System.IO.FileInfo file = new System.IO.FileInfo(strFileName);
                // Transfer File
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", strUserFileName));
                HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
                HttpContext.Current.Response.ContentType = "application/octet-stream";//ReturnExtension(clsGeneral.GetExtension(objAttachment.Attachment_Name));
                HttpContext.Current.Response.TransmitFile(strFileName);
                HttpContext.Current.Response.Flush();
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
                HttpContext.Current.Response.End();
            }
            else if (!string.IsNullOrEmpty(clsSession.UserID) && !string.IsNullOrEmpty(Request.QueryString["ID"]))//For event
            {
                decimal _Pk_ID;
                string strFilePath = string.Empty, strFileName = string.Empty, strUserFileName = string.Empty;

                if (decimal.TryParse(Encryption.Decrypt(Convert.ToString(Request.QueryString["ID"])), out _Pk_ID))
                {
                    try
                    {
                        // Create Attachment objects
                        clsAttachment_Event objAttachment = new clsAttachment_Event(_Pk_ID);

                        if (!string.IsNullOrEmpty(Request.QueryString["claimtbl"]))
                        {
                            strFilePath = AppConfig.DocumentsPath + "Attach";
                            strUserFileName = objAttachment.Attachment_Description;
                        }
                        //else if (!string.IsNullOrEmpty(Request.QueryString["tbl"]))
                        //{
                        //    foreach (clsGeneral.Tables tbl in Enum.GetValues(typeof(clsGeneral.Tables)))
                        //    {
                        //        if (tbl.ToString() == Request.QueryString["tbl"].ToString())
                        //        {
                        //            strFilePath = clsGeneral.GetAttachmentDocPath(tbl.ToString());
                        //            break;
                        //        }
                        //    }
                        //    strUserFileName = objAttachment.Attachment_Name.Substring(12);
                        //}

                        // Append "\" if not 
                        if (!strFilePath.EndsWith("\\"))
                            strFilePath = strFilePath + "\\";

                        strFileName = strFilePath + objAttachment.Attachment_Name;
                        System.IO.FileInfo file = new System.IO.FileInfo(strFileName);
                        if (file.Exists)
                        {
                            // Transfer File
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", strUserFileName));
                            HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
                            HttpContext.Current.Response.ContentType = "application/octet-stream";//ReturnExtension(clsGeneral.GetExtension(objAttachment.Attachment_Name));
                            HttpContext.Current.Response.TransmitFile(strFileName);
                            HttpContext.Current.Response.Flush();
                            //HttpContext.Current.ApplicationInstance.CompleteRequest();
                            HttpContext.Current.Response.End();
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('Selected attachment(s) are not found.','false');close();", true);
                        }

                    }
                    catch (Exception ex)
                    {
                        string str = ex.Message;
                        //throw ex;
                    }
                    finally
                    {
                    }
                }
            }
            else if (!string.IsNullOrEmpty(clsSession.UserID) && !string.IsNullOrEmpty(Request.QueryString["Property_Claims_ID"]))//For event
            {
                decimal _Pk_ID;
                string strFilePath = string.Empty, strFileName = string.Empty, strUserFileName = string.Empty;

                if (decimal.TryParse(Encryption.Decrypt(Convert.ToString(Request.QueryString["Property_Claims_ID"])), out _Pk_ID))
                {
                    try
                    {
                        // Create Attachment objects
                        Property_Claims_Attachments objAttachment = new Property_Claims_Attachments(_Pk_ID);

                        if (!string.IsNullOrEmpty(Request.QueryString["Property_Claims_ID"]))
                        {
                            strFilePath = string.Concat(clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)clsGeneral.Tables.Property_Claims]), "\\");
                            strUserFileName = objAttachment.Attachment_Path;
                        }
                        //else if (!string.IsNullOrEmpty(Request.QueryString["tbl"]))
                        //{
                        //    foreach (clsGeneral.Tables tbl in Enum.GetValues(typeof(clsGeneral.Tables)))
                        //    {
                        //        if (tbl.ToString() == Request.QueryString["tbl"].ToString())
                        //        {
                        //            strFilePath = clsGeneral.GetAttachmentDocPath(tbl.ToString());
                        //            break;
                        //        }
                        //    }
                        //    strUserFileName = objAttachment.Attachment_Name.Substring(12);
                        //}

                        // Append "\" if not 
                        if (!strFilePath.EndsWith("\\"))
                            strFilePath = strFilePath + "\\";

                        strFileName = strFilePath + objAttachment.Attachment_Path;
                        System.IO.FileInfo file = new System.IO.FileInfo(strFileName);
                        if (file.Exists)
                        {
                            // Transfer File
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", strUserFileName));
                            HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
                            HttpContext.Current.Response.ContentType = "application/octet-stream";//ReturnExtension(clsGeneral.GetExtension(objAttachment.Attachment_Name));
                            HttpContext.Current.Response.TransmitFile(strFileName);
                            HttpContext.Current.Response.Flush();
                            //HttpContext.Current.ApplicationInstance.CompleteRequest();
                            HttpContext.Current.Response.End();
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('Selected attachment(s) are not found.','false');close();", true);
                        }

                    }
                    catch (Exception ex)
                    {
                        string str = ex.Message;
                        //throw ex;
                    }
                    finally
                    {
                    }
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["outlookattachment"]))
            {
                try
                {
                    string fileName = Convert.ToString(Request.QueryString["fileName"]);
                    string orgName = Convert.ToString(Request.QueryString["orgName"]).Replace(",", "");

                    string strFilePath = AppConfig.strFCPDocumentPath + "\\" + fileName;
                    string strFileName = Path.GetFileName(strFilePath);
                    bool isExist = File.Exists(strFilePath);
                    if (isExist)
                    {
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", orgName));
                        HttpContext.Current.Response.ContentType = "application/ms-word";
                        HttpContext.Current.Response.TransmitFile(strFilePath);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "errormessage", "javascript: alert('No file found.');", true);
                    }
                }
                catch(Exception ex)
                {
                    ClientScript.RegisterStartupScript(GetType(), "errormessage", "javascript: alert(No file found.);", true);
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["buildingattachment"]))
            {
                try
                {
                    string fileName = Convert.ToString(Request.QueryString["fileName"]);
                    string orgName = Convert.ToString(Request.QueryString["orgName"]).Replace(",", "");

                    string strFilePath = AppConfig.BuildingAttachDocPath + "\\" + fileName;
                    string strFileName = Path.GetFileName(strFilePath);
                    bool isExist = File.Exists(strFilePath);
                    if (isExist)
                    {
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", orgName));
                        HttpContext.Current.Response.ContentType = "application/ms-word";
                        HttpContext.Current.Response.TransmitFile(strFilePath);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "errormessage", "javascript: alert('No file found.');", true);
                    }
                }
                catch
                {
                    ClientScript.RegisterStartupScript(GetType(), "errormessage", "javascript: alert(No file found.);", true);
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["maintenanceattachment"]))
            {
                try
                {
                    string fileName = Convert.ToString(Request.QueryString["fileName"]);
                    string orgName = Convert.ToString(Request.QueryString["orgName"]).Replace(",", "");

                    string strFilePath = AppConfig.MaintenanceDocPath + "\\" + fileName;
                    string strFileName = Path.GetFileName(strFilePath);
                    bool isExist = File.Exists(strFilePath);
                    if (isExist)
                    {
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", orgName));
                        HttpContext.Current.Response.ContentType = "application/ms-word";
                        HttpContext.Current.Response.TransmitFile(strFilePath);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "errormessage", "javascript: alert('No file found.');", true);
                    }
                }
                catch
                {
                    ClientScript.RegisterStartupScript(GetType(), "errormessage", "javascript: alert(No file found.);", true);
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["sublease"]))
            {
                try
                {
                    string fileName = Convert.ToString(Request.QueryString["fileName"]);

                    string strFilePath = AppConfig.LeaseSubleaseDocPath + "\\" + fileName;
                    string orgName = Convert.ToString(Request.QueryString["orgName"]).Replace(",", "");
                    string strFileName = Path.GetFileName(strFilePath);
                    bool isExist = File.Exists(strFilePath);
                    if (isExist)
                    {
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", orgName));
                        HttpContext.Current.Response.ContentType = "application/ms-word";
                        HttpContext.Current.Response.TransmitFile(strFilePath);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "errormessage", "javascript: alert('No file found.');", true);
                    }
                }
                catch
                {
                    ClientScript.RegisterStartupScript(GetType(), "errormessage", "javascript: alert(No file found.);", true);
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["insurance"]))
            {
                try
                {
                    string fileName = Convert.ToString(Request.QueryString["fileName"]);

                    string strFilePath = AppConfig.PropertyCOIDocPath + "\\" + fileName;
                    string orgName = Convert.ToString(Request.QueryString["orgName"]).Replace(",", "");
                    string strFileName = Path.GetFileName(strFilePath);
                    bool isExist = File.Exists(strFilePath);
                    if (isExist)
                    {
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", orgName));
                        HttpContext.Current.Response.ContentType = "application/ms-word";
                        HttpContext.Current.Response.TransmitFile(strFilePath);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "errormessage", "javascript: alert('No file found.');", true);
                    }
                }
                catch
                {
                    ClientScript.RegisterStartupScript(GetType(), "errormessage", "javascript: alert(No file found.);", true);
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["inspection"]))
            {
                try
                {
                    string fileName = Convert.ToString(Request.QueryString["fileName"]);

                    string strFilePath = AppConfig.InspectionDocPath + "\\" + fileName;
                    string orgName = Convert.ToString(Request.QueryString["orgName"]).Replace(",", "");
                    string strFileName = Path.GetFileName(strFilePath);
                    bool isExist = File.Exists(strFilePath);
                    if (isExist)
                    {
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", orgName));
                        HttpContext.Current.Response.ContentType = "application/ms-word";
                        HttpContext.Current.Response.TransmitFile(strFilePath);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "errormessage", "javascript: alert('No file found.');", true);
                    }
                }
                catch
                {
                    ClientScript.RegisterStartupScript(GetType(), "errormessage", "javascript: alert(No file found.);", true);
                }
            }
        }
    }

    //protected void lnkPrint_Click(object sender, EventArgs e)
    //{
    //    string strFileName = Encryption.Decrypt(Request.QueryString["fname"]);
    //    string strFilePath;
    //    if (!string.IsNullOrEmpty(Request.QueryString["OSHA_DOC"]))
    //        strFilePath = AppConfig.DocumentsPath + strFileName;
    //    else
    //        strFilePath = AppConfig.DocumentsPath + strFileName;
    //    // Transfer File
    //    HttpContext.Current.Response.Clear();
    //    if (!string.IsNullOrEmpty(Request.QueryString["OSHA_DOC"]))
    //        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=Abstract_Letter.Doc"));
    //    else
    //        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=WorkerInjury.Doc"));
    //    HttpContext.Current.Response.ContentType = "application/octet-stream";
    //    HttpContext.Current.Response.TransmitFile(strFilePath);
    //    HttpContext.Current.Response.Flush();
    //    try
    //    {
    //        if (File.Exists(strFilePath))
    //            File.Delete(strFilePath);
    //    }
    //    catch (Exception ex)
    //    {

    //    }

    //        HttpContext.Current.Response.End();



    //}

    /// <summary>
    /// Get Response.ContentType from passed File Extension.
    /// </summary>
    /// <param name="fileExtension"> Extension of File</param>
    /// <returns> Response.ContentType </returns>
    private string ReturnExtension(string fileExtension)
    {
        switch (fileExtension.ToLower())
        {
            case ".htm":
            case ".html":
            case ".log":
                return "text/HTML";
            case ".txt":
                return "text/plain";
            case ".doc":
                return "application/ms-word";
            case ".tiff":
            case ".tif":
                return "image/tiff";
            case ".asf":
                return "video/x-ms-asf";
            case ".avi":
                return "video/avi";
            case ".zip":
                return "application/zip";
            case ".xls":
            case ".csv":
                return "application/vnd.ms-excel";
            case ".gif":
                return "image/gif";
            case ".jpg":
            case "jpeg":
                return "image/jpeg";
            case ".bmp":
                return "image/bmp";
            case ".wav":
                return "audio/wav";
            case ".mp3":
                return "audio/mpeg3";
            case ".mpg":
            case "mpeg":
                return "video/mpeg";
            case ".rtf":
                return "application/rtf";
            case ".asp":
                return "text/asp";
            case ".pdf":
                return "application/pdf";
            case ".fdf":
                return "application/vnd.fdf";
            case ".ppt":
                return "application/mspowerpoint";
            case ".dwg":
                return "image/vnd.dwg";
            case ".msg":
                return "application/msoutlook";
            case ".xml":
            case ".sdxl":
                return "application/xml";
            case ".xdp":
                return "application/vnd.adobe.xdp+xml";
            default:
                return "application/octet-stream";
        }
    }
}
