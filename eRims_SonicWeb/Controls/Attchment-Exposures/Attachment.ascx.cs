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
public partial class Controls_Attchment_Exposures_Attachment : System.Web.UI.UserControl
{
    #region "Enums"
    public enum PulldownOrTextbox
    {
        Dropdown = 0,
        Textbox = 1
    }
    #endregion

    #region "Events"

    // Delegate declaration
    public delegate void dlgOnFileSelection();

    // Event declaration
    public event dlgOnFileSelection FileSelection;

    #endregion

    #region "Public Properties"
    ///// <summary>
    ///// get RequiredAttachTypeID
    ///// </summary>
    //public string RequiredAttachTypeID
    //{
    //    get { return reqAttachType.ClientID; }
    //}
    /// <summary>
    /// get RequiredAttachFileID
    /// </summary>
    public string RequiredAttachFileID
    {
        get { return reqFile.ClientID; }
    }

    public int FK_Building_ID
    {
        get { return Convert.ToInt32(ViewState["Building_Attachment_FK"]); }
        set { ViewState["Building_Attachment_FK"] = value; }
    }

    public int FK_Inspection_ID
    {
        get { return Convert.ToInt32(ViewState["Inspection_Attachment_FK"]); }
        set { ViewState["Inspection_Attachment_FK"] = value; }
    }

    public int FK_Inspection_Responses_ID_Attachment
    {
        get { return Convert.ToInt32(ViewState["FK_Inspection_Responses_ID_Attachment"]); }
        set { ViewState["FK_Inspection_Responses_ID_Attachment"] = value; }
    }

   
    //public PulldownOrTextbox TypeIsDropdownOrTextBox
    //{
    //    set
    //    {
    //        if (value == PulldownOrTextbox.Dropdown)
    //        {
    //            tdTypeDropdown.Style.Add("display", "block");
    //            tdTypeTextBox.Style.Add("display", "none");
    //            reqAttachType.Enabled = true;
    //        }
    //        else
    //        {
    //            tdTypeDropdown.Style.Add("display", "none");
    //            tdTypeTextBox.Style.Add("display", "block");
    //            reqAttachType.Enabled = false;
    //        }
    //    }
    //}
    #endregion

    # region " Page Events "


    protected void Page_Load(object sender, EventArgs e)
    {
        fpFile.Attributes.Add("onchange", "javascript:UpdloadFile('" + fpFile.ClientID + "','" + btnHdn.ClientID + "','" + txtType.ClientID + "');");
        txtType.Attributes.Add("onblur", "javascript:UpdloadFile_txt('" + fpFile.ClientID + "','" + btnHdn.ClientID + "','" + txtType.ClientID + "');");
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
    public void Add(clsGeneral.Exposure_Tables AttachmentTbl)
    {
        // PK and table must be specified, also attachment type must be selected and file must be uploaded.        
        //IsValidAttachmentType() && drpAttachType.SelectedIndex != 0 && 
        if (!clsGeneral.IsNull(AttachmentTbl) && !clsGeneral.IsNull(fpFile.PostedFile.FileName))
        {
            //used to check Attchment Table Type. according to that Data is added to related table
            if (AttachmentTbl == clsGeneral.Exposure_Tables.Property_Building)
            {
                //set values to store in database
                Building_Attachments objAttachment = new Building_Attachments();
                objAttachment.FK_Building_ID = FK_Building_ID;
                objAttachment.Type = txtType.Text.Trim();
                // upload the document
                string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.ExposureTableNames[(int)AttachmentTbl]);
                string DocPath = string.Concat(strUploadPath, "\\");
                objAttachment.path = clsGeneral.UploadFile(fpFile, DocPath, false, false);
                objAttachment.Filename = objAttachment.path.Substring(objAttachment.path.LastIndexOf("\\") + 1);
                //Insert the attachment record
                objAttachment.Insert();

                //txtAttachDesc.Text = "";
                //drpAttachType.SelectedIndex = 0;
            }
            else if (AttachmentTbl == clsGeneral.Exposure_Tables.Property_Ownership_SubLease)
            {
                //set values to store in database
                Lease_SubLease_Attachments objAttachment = new Lease_SubLease_Attachments();
                objAttachment.FK_Building_ID = FK_Building_ID;
                objAttachment.Type = txtType.Text.Trim();
                // upload the document
                string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.ExposureTableNames[(int)AttachmentTbl]);
                string DocPath = string.Concat(strUploadPath, "\\");
                objAttachment.path = clsGeneral.UploadFile(fpFile, DocPath, false, false);
                objAttachment.Filename = objAttachment.path.Substring(objAttachment.path.LastIndexOf("\\") + 1);
                //Insert the attachment record
                objAttachment.Insert();
            }
            else if (AttachmentTbl == clsGeneral.Exposure_Tables.Property_Assessment)
            {
                //set values to store in database
                Assessment_Attachments objAttachment = new Assessment_Attachments();
                objAttachment.FK_Building_ID = FK_Building_ID;
                objAttachment.Type = txtType.Text.Trim();
                // upload the document
                string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.ExposureTableNames[(int)AttachmentTbl]);
                string DocPath = string.Concat(strUploadPath, "\\");
                objAttachment.path = clsGeneral.UploadFile(fpFile, DocPath, false, false);
                objAttachment.Filename = objAttachment.path.Substring(objAttachment.path.LastIndexOf("\\") + 1);
                //Insert the attachment record
                objAttachment.Insert();
            }
            else if (AttachmentTbl == clsGeneral.Exposure_Tables.Inspection)
            {
                //set values to store in database
                Inspection_Attachments objAttachment = new Inspection_Attachments();
                objAttachment.FK_Inspection_ID = FK_Inspection_ID;
                objAttachment.Type = txtType.Text.Trim();
                // upload the document
                string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.ExposureTableNames[(int)AttachmentTbl]);
                string DocPath = string.Concat(strUploadPath, "\\");
                objAttachment.path = clsGeneral.UploadFile(fpFile, DocPath, false, false);
                objAttachment.Filename = objAttachment.path.Substring(objAttachment.path.LastIndexOf("\\") + 1);
                //Insert the attachment record
                objAttachment.Insert();
            }
            else if (AttachmentTbl == clsGeneral.Exposure_Tables.Inspection_Responses)
            {
                //set values to store in database
                Inspection_Responses_Attachments objAttachment = new Inspection_Responses_Attachments();
                objAttachment.FK_Inspection_Responses_ID = FK_Inspection_Responses_ID_Attachment;
                objAttachment.Type = txtType.Text.Trim();
                // upload the document
                string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.ExposureTableNames[(int)AttachmentTbl]);
                string DocPath = string.Concat(strUploadPath, "\\");
                objAttachment.Path = clsGeneral.UploadFile(fpFile, DocPath, false, false);
                objAttachment.Filename = objAttachment.Path.Substring(objAttachment.Path.LastIndexOf("\\") + 1);
                //Insert the attachment record
                objAttachment.Insert();
            }
           
             txtType.Text = "";
        }
    }

    public void AddSLTAttachment(clsGeneral.SLT_Tables AttachmentTbl, decimal Foreign_Key)
    {
        if (AttachmentTbl == clsGeneral.SLT_Tables.SLT_Safety_Walk || AttachmentTbl == clsGeneral.SLT_Tables.SLT_Training)
        {
            //set values to store in database
            ERIMSAttachment objAttachment = new ERIMSAttachment();
            objAttachment.Attachment_Table = clsGeneral.SLT_TablesNames[(int)AttachmentTbl];
            objAttachment.Foreign_Key = Foreign_Key;
            objAttachment.FK_Attachment_Type =0;
            objAttachment.Attachment_Description = txtType.Text.Trim();
            objAttachment.Updated_By = clsSession.UserID;
            objAttachment.Update_Date = DateTime.Today;

            // upload the document
            string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.SLT_TablesNames[(int)AttachmentTbl]);
            string DocPath = string.Concat(strUploadPath, "\\");

            // upload and set the filename.
            objAttachment.Attachment_Name = clsGeneral.UploadFile(fpFile, DocPath, false, false);
            //objAttachment.Attachment_Name = GetCustomFileName() + objAttachment.Attachment_Name;
            //Insert the attachment record
            objAttachment.Insert();
        }
        else if (AttachmentTbl == clsGeneral.SLT_Tables.SLT_BT_Security_Walk)
        {
            ERIMSAttachment objAttachment = new ERIMSAttachment();
            objAttachment.Attachment_Table = clsGeneral.SLT_TablesNames[(int)AttachmentTbl];
            objAttachment.Foreign_Key = Foreign_Key;
            objAttachment.FK_Attachment_Type = 0;
            objAttachment.Attachment_Description = txtType.Text.Trim();
            objAttachment.Updated_By = clsSession.UserID;
            objAttachment.Update_Date = DateTime.Today;
            string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.SLT_TablesNames[(int)AttachmentTbl]);
            string DocPath = string.Concat(strUploadPath, "\\");
            objAttachment.Attachment_Name = clsGeneral.UploadFile(fpFile, DocPath, false, false);
            objAttachment.Insert();
        }
    }
    /// <summary>
    /// check if attachment type is valid or not. 
    /// mainly used when some file is selected but instead of add attachment save and close button is clicked
    /// in that case no javascript validation will be fired. so server side validation is necessary.
    /// </summary>
    /// <returns></returns>
    private bool IsValidAttachmentType()
    {
        //if (drpAttachType.SelectedValue == "2")
        //{
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
        //}
        //else
        //{
        //    return true;
        //}
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
        if (FileSelection != null)
            FileSelection();

    }
}
