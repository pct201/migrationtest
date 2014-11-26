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

    // Delegate declaration
    public delegate void OnButtonClick(string strValue);

    // Event declaration
    public event OnButtonClick btnHandler;

    #region "Public Properties"

    public string RequiredAttachTypeID
    {
        get { return reqAttachType.ClientID; }
    }

    public string RequiredAttachFileID
    {
        get { return reqFile.ClientID; }
    }
    #endregion

    # region " Page Events "

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
    public void Add(clsGeneral.Claim_Tables AttachemtnTable, int AttachmentPK)
    {
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile1);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile2);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile3);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile4);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile5);
        txtAttachDesc.Text = "";
        drpAttachType.SelectedIndex = 0;
    }


    private void SaveAttachmentDetails(clsGeneral.Claim_Tables AttachemtnTable, int AttachmentPK, FileUpload fpFile)
    {
        // PK and table must be specified, also attachment type must be selected and file must be uploaded.        
        if (AttachmentPK != 0 && !clsGeneral.IsNull(AttachemtnTable) && !clsGeneral.IsNull(fpFile.PostedFile.FileName))
        {
            //set values to store in database
            Tatvasoft_Attachment objAttachment = new Tatvasoft_Attachment();
            objAttachment.Attachment_Table = clsGeneral.ClaimTableName[(int)AttachemtnTable];

            objAttachment.Foreign_Key = AttachmentPK;
            objAttachment.FK_Attachment_Type = Convert.ToDecimal(1);
            objAttachment.Attachment_Description = txtAttachDesc.Text.Trim();
            objAttachment.Updated_By = "";
            objAttachment.Update_Date = DateTime.Today;

            // upload the document
            string strUploadPath = clsGeneral.GetClaimAttachmentDocPath(clsGeneral.ClaimTableName[(int)AttachemtnTable]);
            string DocPath = string.Concat(strUploadPath, "\\");

            // upload and set the filename.
            objAttachment.Attachment_Name = clsGeneral.UploadFile(fpFile, DocPath, false, false);
            //Insert the attachment record
            objAttachment.Insert();

           
          
        }

        
    }
   

    /// <summary>
    /// btnAddAttachment click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        //check null value
        if (btnHandler != null)
            btnHandler(string.Empty);

    }
    # endregion
}
