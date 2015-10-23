using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;
using Winnovative.WnvHtmlConvert;
using Aspose;
using Aspose.Words;
using Aspose.Words.Drawing;
using System.Data;

public partial class Event_AbstractLetterMail : System.Web.UI.Page
{
    #region " Properties "

    /// <summary>
    /// Denotes claim ID
    /// </summary>
    public decimal FK_Event
    {
        get { return Convert.ToDecimal(ViewState["AbstractLetter"]); }
        set { ViewState["AbstractLetter"] = value; }
    }

    /// <summary>
    /// Denotes major coverage for claim
    /// </summary>
    public string Major_Coverage
    {
        get { return clsGeneral.IsNull(ViewState["AbstractLetterMajorCoverage"]) ? string.Empty : Convert.ToString(ViewState["AbstractLetterMajorCoverage"]); }
        set { ViewState["AbstractLetterMajorCoverage"] = value; }
    }

    /// <summary>
    /// Denotes comma seperated letter types
    /// </summary>
    public string _strAbstractLetterTypes
    {
        get { return Convert.ToString(ViewState["AbstractLetterTypes"]); }
        set { ViewState["AbstractLetterTypes"] = value; }
    }

    public string _strClaimType
    {
        get { return Convert.ToString(Request.QueryString["claimType"]); }
    }

    public string _DocType
    {
        set { ViewState["DocType"] = value; }
        get { return clsGeneral.IsNull(ViewState["DocType"]) ? string.Empty : Convert.ToString(Request.QueryString["DocType"]); }
    }

    public string _CoiWcOccType
    {
        get { return clsGeneral.IsNull(ViewState["CoiWcOccType"]) ? "0" : Convert.ToString(ViewState["CoiWcOccType"]); }
        set { ViewState["CoiWcOccType"] = value; }
    }

    public bool ShowDiaries
    {
        get { return (Convert.ToString(Request.QueryString["bDiary"]) == true.ToString() ? true : false); }
    }

    public bool ShowAdjusterNote
    {
        get { return (Convert.ToString(Request.QueryString["bShowAdjusterNote"]) == true.ToString() ? true : false); }
    }

    public bool ShowAttachments
    {
        get { return (Convert.ToString(Request.QueryString["bAttach"]) == true.ToString() ? true : false); }
    }

    public bool ShowTransactions
    {
        get { return (Convert.ToString(Request.QueryString["bTran"]) == true.ToString() ? true : false); }
    }

    #endregion

    #region " Page Events "

    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!IsPostBack)
        {
            // check if the claim ID and document types are passed in querystring 
            if (Request.QueryString["docs"] != null && Request.QueryString["claimID"] != null)
            {
                // set PK for claim
                decimal decPK;
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["claimID"]), out decPK))
                {
                    FK_Event = decPK;
                }

                // set letter types
                _strAbstractLetterTypes = Encryption.Decrypt(Request.QueryString["docs"]);

                if (!String.IsNullOrEmpty(Request.QueryString["DocType"]))
                    _DocType = Convert.ToString(Request.QueryString["DocType"]);

                if (!String.IsNullOrEmpty(Request.QueryString["CoiPolicyType"]))
                    _CoiWcOccType = Convert.ToString(Request.QueryString["CoiPolicyType"]);

                if (!String.IsNullOrEmpty(Request.QueryString["claimType"]))
                    Major_Coverage = Convert.ToString(Request.QueryString["claimType"]);
                else
                    Major_Coverage = "Auto";

                string[] strLetterTypes = _strAbstractLetterTypes.Split(',');
                string strAttachmentDocs = "";

                // loop through each type and rename the type as filename to be sent in attachment 
                for (int i = 0; i < strLetterTypes.Length; i++)
                {
                    strLetterTypes[i] = strLetterTypes[i].Replace(" ", "_");
                    strLetterTypes[i] = strLetterTypes[i] + ".doc";
                    strAttachmentDocs = strAttachmentDocs + strLetterTypes[i] + ",";

                }
                strAttachmentDocs = strAttachmentDocs.TrimEnd(',');

                // set attachment list for attachment field
                if (_DocType != "PDF")
                    lblAttachment.Text = strAttachmentDocs.Replace(",", ", ");
                else
                    lblAttachment.Text = _strAbstractLetterTypes + ".pdf";
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "window.close()", true);
            }
        }
    }
    #endregion

    #region " Control Events "

    /// <summary>
    /// Handles Send button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            string[] strLetterTypes = _strAbstractLetterTypes.Split(',');
            string strAttachmentFileNames = "";
            string strDocumentPath = "";
            // get all letter types in array

            if (_DocType != "PDF")
            {
                // loop through each letter type 
                foreach (string strLetterType in strLetterTypes)
                {
                    //Create string object to set letter text
                    StringBuilder strHTML = new StringBuilder();

                    // create object for attachment
                    ERIMS.DAL.clsAttachment_Event objAttachment = new ERIMS.DAL.clsAttachment_Event();

                    // set claim ID and other attachment values
                    objAttachment.FK_Attachment_Type = 1;
                    objAttachment.Attachment_Description = strLetterType + ".doc";
                    objAttachment.FK_Table = FK_Event;
                    objAttachment.Attachment_Table = _strClaimType;
                    strDocumentPath = clsGeneral.GetAttachmentDocPath(_strClaimType);

                    // set filename
                    string strFilename = strLetterType.Replace(" ", "_");
                    strFilename = strFilename + ".doc";

                    // save the file and set the filename to be saved in DB.
                    objAttachment.Attachment_Name = clsGeneral.SaveFile(strHTML.ToString(), strDocumentPath, strFilename);
                    objAttachment.Updated_By = clsSession.UserID;
                    objAttachment.Update_Date = DateTime.Now;
                    objAttachment.Attach_Date = DateTime.Now;
                    //Insert the attachment record
                    objAttachment.Insert();

                    // append the saved file name with comma separation
                    strAttachmentFileNames = strAttachmentFileNames + objAttachment.Attachment_Name + ",";
                }
            }
            strAttachmentFileNames = strAttachmentFileNames.TrimEnd(',');

            // create array for files to be sent in attachment
            string[] strAttachments = strAttachmentFileNames.Split(',');
            for (int i = 0; i < strAttachments.Length; i++)
            {
                strAttachments[i] = strDocumentPath + strAttachments[i];
            }
            byte[] bPDF = null;

            if (_DocType.ToUpper() == "PDF")
            {
                string Attachmentname = _strAbstractLetterTypes + ".pdf";
                bPDF = GetBytypesFromString(_strAbstractLetterTypes);
                // send mail with attachments
                SendMailMessage(AppConfig.MailFrom, txtToEmail.Text.Trim(), string.Empty, string.Empty, txtSubject.Text.Trim(), txtBody.Text.Trim().Replace("\r\n", "<br/>"), true, Attachmentname, bPDF);
            }
            else
            {
                clsGeneral.SendMailMessage(AppConfig.MailFrom, txtToEmail.Text.Trim(), string.Empty, string.Empty, txtSubject.Text.Trim(), txtBody.Text.Trim().Replace("\r\n", "<br/>"), true, strAttachments);
            }
        }
        catch { }
        finally
        {
            if (Request.QueryString["btnID"] != null)
                lblScript.Text = "<script type='text/javascript'>alert('Mail Sent Successfully!');window.opener.document.getElementById('" + Request.QueryString["btnID"] + "').click();Close();</script>";
            else
                lblScript.Text = "<script type='text/javascript'>alert('Mail Sent Successfully!');Close();</script>";

        }
    }

    public bool SendMailMessage(string strFrom, string strTo, string strBCC, string strCC, string strSubject, string strBody, bool boolIsHTML, string Attachmentname, byte[] pdfByte)
    {
        // Instantiate a new instance of MailMessage
        MailMessage mMailMessage = new MailMessage();

        if (!clsGeneral.IsNull(strFrom))
        {
            // Set the sender address of the mail message
            mMailMessage.From = new MailAddress(strFrom);
        }

        char[] arrSplitChar = { ',' };
        if (!clsGeneral.IsNull(strTo))
        {
            string[] arrTo = strTo.Split(arrSplitChar);
            foreach (string strTOID in arrTo)
            {
                // Set the recipient address of the mail message
                mMailMessage.To.Add(new MailAddress(strTOID));
            }
        }


        // Check if the bcc value is nothing or an empty string
        if (!clsGeneral.IsNull(strBCC))
        {
            string[] arrBCC = strBCC.Split(arrSplitChar);
            foreach (string strBCCID in arrBCC)
            {
                // Set the recipient address of the mail message
                mMailMessage.Bcc.Add(new MailAddress(strBCCID));
            }
        }

        // Check if the cc value is nothing or an empty value
        if (!string.IsNullOrEmpty(strCC))
        {
            string[] arrCC = strCC.Split(arrSplitChar);
            foreach (string strCCID in arrCC)
            {
                // Set the recipient address of the mail message
                mMailMessage.CC.Add(new MailAddress(strCCID));
            }
        }

        if (pdfByte.Length > 0)
        {
            mMailMessage.Attachments.Add(new System.Net.Mail.Attachment(new MemoryStream(pdfByte), Attachmentname));
        }

        // Set the subject of the mail message
        mMailMessage.Subject = strSubject;
        // Set the body of the mail message
        mMailMessage.Body = strBody;

        // Set the format of the mail message body as HTML
        mMailMessage.IsBodyHtml = boolIsHTML;
        // Set the priority of the mail message to normal
        mMailMessage.Priority = MailPriority.Normal;

        // Instantiate a new instance of SmtpClient
        SmtpClient mSmtpClient = new SmtpClient(AppConfig.SMTPServer, Convert.ToInt32(AppConfig.Port));

        mSmtpClient.Credentials = new NetworkCredential(strFrom, AppConfig.SMTPpwd);

        try
        {
            // Send the mail message
            mSmtpClient.Send(mMailMessage);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        finally
        {
            mMailMessage.Dispose();
            mMailMessage = null;
            mSmtpClient = null;
            //CommonHelper.DisposeOf(mMailMessage);
            //CommonHelper.DisposeOf(mSmtpClient);
        }

    }

    public byte[] GetBytypesFromString(string _strAbstractLetterTypes)
    {
        string strFileName = string.Empty;
        PdfConverter objPdf = new PdfConverter();
        StringBuilder sbHtml = new StringBuilder();
        Byte[] pdfByte = null;
        objPdf.LicenseKey = AppConfig._strHtmltoPDFConverterKey;
        objPdf.PdfDocumentOptions.TopMargin = 20;
        objPdf.PdfDocumentOptions.LeftMargin = 20;
        objPdf.PdfDocumentOptions.RightMargin = 20;
        objPdf.PdfDocumentOptions.BottomMargin = 20;
        objPdf.PdfDocumentOptions.ShowHeader = false;
        objPdf.PdfDocumentOptions.ShowFooter = false;
        objPdf.PdfDocumentOptions.EmbedFonts = false;

        objPdf.PdfDocumentOptions.LiveUrlsEnabled = false;
        objPdf.RightToLeftEnabled = false;
        objPdf.PdfSecurityOptions.CanPrint = true;
        objPdf.PdfSecurityOptions.CanEditContent = true;
        objPdf.PdfSecurityOptions.UserPassword = "";
        objPdf.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Landscape;
        objPdf.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;
        objPdf.PdfDocumentInfo.AuthorName = "eRIMS2";

        string _strMajor_Coverage = clsGeneral.GetIntMajorCoverage(Major_Coverage).ToString();

        if (Major_Coverage == clsGeneral.Major_Coverage.Event.ToString())
        {
            sbHtml = AbstractLetters.Event_AbstactReport(FK_Event, ShowAttachments, clsGeneral.Major_Coverage.Event);
            strFileName = "Cargo Liability Claim Abstract.pdf";
        }
        
        pdfByte = objPdf.GetPdfBytesFromHtmlString(sbHtml.ToString());

        return pdfByte;
    }

    #endregion
}