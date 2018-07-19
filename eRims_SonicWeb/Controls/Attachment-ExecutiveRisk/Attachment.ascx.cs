using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ERIMS.DAL;
/// <summary>
/// Date : 29 MAY 2008
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// To upload document on the server which will then be used to view or for mailing
/// 
/// Functionality:
/// Gives user to select attachment type like document, image, or note and description
/// Uses File browser to select the document and uploads the document to server
/// </summary>
public partial class Controls_Attachments_Attachment : System.Web.UI.UserControl
{

    #region "Public Properties"
    /// <summary>
    /// get RequiredAttachTypeID
    /// </summary>
    public string RequiredAttachTypeID
    {
        get { return reqAttachType.ClientID; }
    }

    /// <summary>
    /// get RequiredAttachFileID
    /// </summary>
    public string RequiredAttachFileID
    {
        get { return reqFile.ClientID; }
    }

    public string AttachmentSkinID
    {
        set { drpAttachType.SkinID = value; }
    }

    public bool ShowAttachmentType
    {
        set
        {
            if (value == true)
            {
                trAttachmentType.Style["display"] = "block";
                reqAttachType.Enabled = true;
            }
            else
            {
                trAttachmentType.Style["display"] = "none";
                reqAttachType.Enabled = false;
            }
        }
    }

    public bool EnableValidationSummary
    {
        set
        {
            if (value == true)
                valSummayAttachment.Enabled = true;
            else
                valSummayAttachment.Enabled = false;
        }
    }

    public bool ShowAttachmentButton
    {
        set
        {
            if (value == true)
            {
                btnAddAttachment.Visible = true;
            }
            else
            {
                btnAddAttachment.Visible = false;
            }
        }
    }
    #endregion

    # region " Page Events "

    // Delegate declaration
    public delegate void OnButtonClick(string strValue);

    // Event declaration
    public event OnButtonClick btnHandler;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    # endregion

    # region " Public Methods "

    /// <summary>
    /// Add Attachment.
    /// saves attachment at physical path depending on table used.
    /// also inser record in database.
    /// </summary>
    /// <param name="AttachemtnTable"></param>
    /// <param name="AttachmentPK"></param>
    public void Add(clsGeneral.Tables AttachemtnTable, int AttachmentPK)
    {
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile1);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile2);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile3);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile4);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile5);

        txtAttachDesc.Text = "";
        drpAttachType.SelectedIndex = 0;
    }

    private void SaveAttachmentDetails(clsGeneral.Tables AttachemtnTable, int AttachmentPK, FileUpload fpFile)
    {
        // PK and table must be specified, also attachment type must be selected and file must be uploaded.        
        if (IsValidAttachmentType(fpFile) && AttachmentPK != 0 && !clsGeneral.IsNull(AttachemtnTable) && !clsGeneral.IsNull(fpFile.PostedFile.FileName))
        {
            //set values to store in database
            ERIMSAttachment objAttachment = new ERIMSAttachment();
            objAttachment.Attachment_Table = clsGeneral.TableNames[(int)AttachemtnTable];

            objAttachment.Foreign_Key = AttachmentPK;
            objAttachment.FK_Attachment_Type = 1;
            objAttachment.Attachment_Description = txtAttachDesc.Text.Trim();
            objAttachment.Updated_By = "";
            objAttachment.Update_Date = DateTime.Today;

            // upload the document
            string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)AttachemtnTable]);
            string DocPath = string.Concat(strUploadPath, "\\");

            // upload and set the filename.
            objAttachment.Attachment_Name = clsGeneral.UploadFile(fpFile, DocPath, false, false);
            //objAttachment.Attachment_Name = GetCustomFileName() + objAttachment.Attachment_Name;
            //Insert the attachment record
            objAttachment.Insert();

            drpAttachType.SelectedIndex = 0;
        }
    }

    public void Add(clsGeneral.Tables AttachemtnTable, int AttachmentPK, string AttachmentFor)
    {
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile1, AttachmentFor);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile2, AttachmentFor);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile3, AttachmentFor);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile4, AttachmentFor);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile5, AttachmentFor);

        txtAttachDesc.Text = "";
        drpAttachType.SelectedIndex = 0;
    }

    private void SaveAttachmentDetails(clsGeneral.Tables AttachemtnTable, int AttachmentPK, FileUpload fpFile, string AttachmentFor)
    {
        // PK and table must be specified, also attachment type must be selected and file must be uploaded.        
        if (IsValidAttachmentType(fpFile) && AttachmentPK != 0 && !clsGeneral.IsNull(AttachemtnTable) && !clsGeneral.IsNull(fpFile.PostedFile.FileName) && !clsGeneral.IsNull(AttachmentFor))
        {
            //set values to store in database
            ERIMSAttachment objAttachment = new ERIMSAttachment();
            objAttachment.Attachment_Table = clsGeneral.TableNames[(int)AttachemtnTable];

            objAttachment.Foreign_Key = AttachmentPK;
            objAttachment.FK_Attachment_Type = 1;
            objAttachment.Attachment_Description = txtAttachDesc.Text.Trim();
            objAttachment.Updated_By = "";
            objAttachment.Update_Date = DateTime.Today;
            objAttachment.Attachment_For = AttachmentFor;

            // upload the document
            string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)AttachemtnTable]);
            string DocPath = string.Concat(strUploadPath, "\\");

            // upload and set the filename.
            objAttachment.Attachment_Name = clsGeneral.UploadFile(fpFile, DocPath, false, false);
            //objAttachment.Attachment_Name = GetCustomFileName() + objAttachment.Attachment_Name;
            //Insert the attachment record
            objAttachment.Insert();

            drpAttachType.SelectedIndex = 0;
        }
    }

    /// <summary>
    /// check if attachment type is valid or not. 
    /// mainly used when some file is selected but instead of add attachment save and close button is clicked
    /// in that case no javascript validation will be fired. so server side validation is necesaary.
    /// </summary>
    /// <returns></returns>
    private bool IsValidAttachmentType(FileUpload fpFile)
    {
        if (drpAttachType.SelectedValue == "2")
        {
            string ext = clsGeneral.GetExtension(fpFile.PostedFile.FileName);
            bool retVal = false;
            switch (ext.ToLower())
            {
                case ".gif":
                case ".jpg":
                case ".bmp":
                case ".jpeg":
                case ".tif":
                case ".png":
                    retVal = true;
                    break;
            }
            return retVal;
        }
        else
        {
            return true;
        }
    }

    # endregion

    /// <summary>
    /// btnHdn click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnHdn_Click(object sender, EventArgs e)
    {
        //check null value
        if (btnHandler != null)
            btnHandler(string.Empty);

    }

    /// <summary>
    /// Event For add attachment Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        btnHdn_Click(null, null);
    }

    public void changeNavHeader(string txt)
    {
        tdAttachment.InnerText = txt;
    }
}
