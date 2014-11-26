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

public partial class Controls_Attachments_SLT_Safety_Walk_Attachment : System.Web.UI.UserControl
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

    public int FK_SLT_Safety_Walk_Responses
    {
        get { return Convert.ToInt32(ViewState["FK_SLT_Safety_Walk_Responses"]); }
        set { ViewState["FK_SLT_Safety_Walk_Responses"] = value; }
    }

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
        try
        {
            // PK and table must be specified, also attachment type must be selected and file must be uploaded.        
            //IsValidAttachmentType() && drpAttachType.SelectedIndex != 0 && 
            if (!clsGeneral.IsNull(AttachmentTbl) && !clsGeneral.IsNull(fpFile.PostedFile.FileName))
            {
                //used to check Attchment Table Type. according to that Data is added to related table
                if (AttachmentTbl == clsGeneral.Exposure_Tables.SLT_Safety_Walk_Attachments)
                {
                    //set values to store in database
                    SLT_Safety_Walk_Attachments objAttachment = new SLT_Safety_Walk_Attachments();
                    objAttachment.FK_SLT_Safety_Walk_Responses = FK_SLT_Safety_Walk_Responses;
                    objAttachment.Attachment_Description = txtType.Text.Trim();
                    // upload the document
                    string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.ExposureTableNames[(int)AttachmentTbl]);
                    string DocPath = string.Concat(strUploadPath, "\\");
                    objAttachment.Attachment_Filename = clsGeneral.UploadFile(fpFile, DocPath, false, false);
                    objAttachment.Updated_By = clsSession.UserID;
                    objAttachment.Updated_Date = DateTime.Today;
                    //Insert the attachment record
                    objAttachment.Insert();
                }

                txtType.Text = "";
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }        
    }

    /// <summary>
    /// check if attachment type is valid or not. 
    /// mainly used when some file is selected but instead of add attachment save and close button is clicked
    /// in that case no javascript validation will be fired. so server side validation is necesaary.
    /// </summary>
    /// <returns></returns>
    private bool IsValidAttachmentType()
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