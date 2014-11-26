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
using System.IO;
using System.Text;

/// <summary>
/// Date : 8-Oct-2008
/// 
/// By : Ravi Patel
/// 
/// Purpose: 
/// To upload document on the server which will then be used to view or for mailing
/// 
/// Functionality:
/// Gives user to select attachment type , Folder Name  and description
/// Uses File browser to select the document and uploads the document to server
/// </summary>

public partial class Controls_Attchment_Environment_Attachment_Old : System.Web.UI.UserControl
{
    #region "Public Properties"

    public string FileUploadHtml
    {
        get { return (this.ViewState["FileUploadHtml"] == null ? "" : this.ViewState["FileUploadHtml"].ToString()); }
        set { this.ViewState["FileUploadHtml"] = value; }
    }

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

    /// <summary>
    /// Define validation group for Control
    /// if control is used more than one time in same page then 
    /// its define validation group for all control
    /// </summary>
    public string UniqueControlID
    {
        get { return this.ViewState["ValidationGroup"].ToString(); }
        set { this.ViewState["ValidationGroup"] = value; }
    }

    /// <summary>
    /// Set Environment Attachment Folder Name
    /// </summary>
    public clsGeneral.Exposure_Enviroment_Table AttachmetnTable
    {
        get { return (clsGeneral.Exposure_Enviroment_Table)this.ViewState["AttachmetnTable"]; }
        set { this.ViewState["AttachmetnTable"] = value; }
    }
    #endregion

    # region " Page Events "

    // Delegate declaration
    public delegate void OnButtonClick(string strValue);

    // Event declaration
    public event OnButtonClick btnHandler;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            // Add Post back to Hidden button from javascript
            PostBackOptions pbo = new PostBackOptions(btnHdn);
            pbo.AutoPostBack = true;
            pbo.AutoPostBack = true;
            ComboHelper.FillFolderName(new DropDownList[] { drpFolderName }, true);

            // set Dynamic Validation group for more than one Control on same page.
            // ControlValidationGroup is must be uniquie

            this.reqAttachType.ValidationGroup = this.UniqueControlID;
            this.reqFile.ValidationGroup = this.UniqueControlID;
            this.cstFile.ValidationGroup = this.UniqueControlID;
            this.valSummary.ValidationGroup = this.UniqueControlID;
            this.rfvFolder.ValidationGroup = this.UniqueControlID;

            this.btnSaveFolder.ValidationGroup = "AddFolder" + this.UniqueControlID;
            this.rfvFolderName.ValidationGroup = "AddFolder" + this.UniqueControlID;
            this.valSummaryFolder.ValidationGroup = "AddFolder" + this.UniqueControlID;

            // Set Javascript Function name Dyanmically 
            this.cstFile.ClientValidationFunction = "ValidateAttachmentType" + this.UniqueControlID;
            this.fpFile.Attributes.Add("onChange", "return UpdloadFile" + this.UniqueControlID + "();");

        }

    }

    /// <summary>
    /// btnHdn click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnHdn_Click(object sender, EventArgs e)
    {
        //check null value
        if (btnHandler != null)
            btnHandler(UniqueControlID);

    }

    protected void btnSaveFolder_Click(object sender, EventArgs e)
    {
        Enviro_Attachments_Folder objAttachemtnFolder = new Enviro_Attachments_Folder();

        try
        {
            if (!clsGeneral.IsValidFilename(this.txtFolderName.Text.Trim()))
            {
                clsGeneral.ShowAlert("Folder Name is contains invalid characher.Plase Enter another name.", this.Page);
                // Show ModulPop
                this.mpeFolder.Show();
                this.txtFolderName.Focus();
                this.txtFolderName.Text = "";
                return;
            }

            // Check if Folder Name is Exist or not.
            if (Enviro_Attachments_Folder.CheckFileName(this.txtFolderName.Text.Trim()))
            {
                clsGeneral.ShowAlert("Folder Name is already Exists.Plase Enter another name.", this.Page);
                this.txtFolderName.Text = "";
                this.txtFolderName.Focus();
                // Show ModulPop
                this.mpeFolder.Show();
                return;
            }

            // Assign Value and insert Folder Record
            objAttachemtnFolder.Folder_Name = this.txtFolderName.Text.Trim();
            objAttachemtnFolder.Insert();

            // Create physical Directory(Folder) with new Name
            clsGeneral.CreateDirectory(clsGeneral.GetEnvironment_AttachmentDocPath(objAttachemtnFolder.Folder_Name.Trim()));

            ComboHelper.FillFolderName(new DropDownList[] { drpFolderName }, true);

            this.txtFolderName.Text = "";
            this.mpeFolder.Hide();
        }
        catch (Exception ex)
        {
            throw ex;
        }

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
    public void Add(int FK_AttachmetnTable)
    {
        // PK and table must be specified, also attachment type must be selected and file must be uploaded.        
        if (IsValidAttachmentType() && FK_AttachmetnTable <= 0 && !clsGeneral.IsNull(AttachmetnTable) && drpAttachType.SelectedIndex != 0 && !clsGeneral.IsNull(fpFile.PostedFile.FileName) && !clsGeneral.IsNull(drpFolderName)) ;
        {
            //set values to store in database
            Enviro_Attachments objAttachment = new Enviro_Attachments();
            objAttachment.Type = drpAttachType.SelectedItem.Text.ToString();
            objAttachment.description = txtAttachDesc.Text.Trim();
            objAttachment.FK_Enviro_Attachments_Folder_ID = Convert.ToInt32(this.drpFolderName.SelectedItem.Value);
            objAttachment.Foreign_Table = AttachmetnTable.ToString();
            objAttachment.Foreign_Key = FK_AttachmetnTable;

            // upload the document
            string strUploadPath = clsGeneral.GetEnvironment_AttachmentDocPath(this.drpFolderName.SelectedItem.Text);

            if ((strUploadPath + fpFile.FileName).Length > 230)
            {
                HttpContext.Current.Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=File name is much larger, Please select file with small name.");
            }
            // upload and set the filename.
            objAttachment.Filename = clsGeneral.UploadFile(fpFile, strUploadPath, false, false);
            objAttachment.path = this.drpFolderName.SelectedItem.Text + "/" + objAttachment.Filename;

            //Insert the attachment record
            objAttachment.Insert();

            // reset field
            txtAttachDesc.Text = "";
            drpAttachType.SelectedIndex = 0;
            drpFolderName.SelectedIndex = 0;
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

}
