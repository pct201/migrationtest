using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;

public partial class Controls_Attachment_SLT_Attachment : System.Web.UI.UserControl
{

    #region "Public Properties"

    /// <summary>
    /// denotes Primary Key of LU_Location table
    /// </summary>
    public decimal FK_Sedgwick_Claim_Review
    {
        get { return Convert.ToDecimal(ViewState["FK_Sedgwick_Claim_Review"]); }
        set { ViewState["FK_Sedgwick_Claim_Review"] = value; }
    }

    // Delegate declaration
    public delegate void OnButtonClick(string strValue);

    // Event declaration
    public event OnButtonClick btnHandler;

    public Boolean isViewOnly
    {
        get
        {
            if (ViewState["isView"] != null)
            {
                return Convert.ToBoolean(ViewState["isView"]);
            }
            else
            {
                return false;
            }
        }
        set
        {
            ViewState["isView"] = value;
        }
    }


    #endregion

    # region " Page Events "

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (isViewOnly)
            {
                btnAddAttachment.Visible = false;
            }
        }
    }

    # endregion

    # region " Public Methods "

    /// <summary>
    /// Add Attachment.
    /// saves attachment at physical path depending on table used.
    /// also insert record in database.
    /// </summary>
    /// <param name="AttachemtnTable"></param>
    /// <param name="AttachmentPK"></param>
    public void AddSLTAttachment(clsGeneral.SLT_Tables AttachmentTbl, decimal Foreign_Key)
    {
        SaveAttachmentDetails(fpFile1, AttachmentTbl, Foreign_Key);
        SaveAttachmentDetails(fpFile2, AttachmentTbl, Foreign_Key);
        SaveAttachmentDetails(fpFile3, AttachmentTbl, Foreign_Key);
        SaveAttachmentDetails(fpFile4, AttachmentTbl, Foreign_Key);
        SaveAttachmentDetails(fpFile5, AttachmentTbl, Foreign_Key);
        SaveAttachmentDetails(fpFile6, AttachmentTbl, Foreign_Key);
        SaveAttachmentDetails(fpFile7, AttachmentTbl, Foreign_Key);
        SaveAttachmentDetails(fpFile8, AttachmentTbl, Foreign_Key);
        SaveAttachmentDetails(fpFile9, AttachmentTbl, Foreign_Key);
        SaveAttachmentDetails(fpFile10, AttachmentTbl, Foreign_Key);
    }

    private void SaveAttachmentDetails(FileUpload fpFile, clsGeneral.SLT_Tables AttachmentTbl, decimal Foreign_Key)
    {
        if (fpFile.PostedFile != null && !clsGeneral.IsNull(fpFile.PostedFile.FileName))
        {
            if (AttachmentTbl == clsGeneral.SLT_Tables.SLT_Meeting_Review)
            {
                ERIMSAttachment objAttachment = new ERIMSAttachment();
                objAttachment.Attachment_Table = clsGeneral.SLT_TablesNames[(int)AttachmentTbl];
                objAttachment.Foreign_Key = Foreign_Key;
                objAttachment.FK_Attachment_Type = 0;
                objAttachment.Attachment_Description = txtAttachDesc.Text.Trim().Replace("'", "''");
                objAttachment.Updated_By = clsSession.UserID;
                objAttachment.Update_Date = DateTime.Today;

                // upload the document
                string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.SLT_TablesNames[(int)AttachmentTbl]);
                string DocPath = string.Concat(strUploadPath, "\\");

                // upload and set the filename.
                objAttachment.Attachment_Name = clsGeneral.UploadFile(fpFile, DocPath, false, false);
                //objAttachment.Attachment_Name = GetCustomFileName() + objAttachment.Attachment_Name;
                objAttachment.Insert();
            }
           
        }
    }
    # endregion

    /// <summary>
    /// Event For add attachment Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        //check null value
        if (btnHandler != null)
            btnHandler(string.Empty);
    }

}