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

public partial class Sonic_Attachment_DPD : System.Web.UI.UserControl
{

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

    //public string AttachmentSkinID
    //{
    //    set { drpAttachType.SkinID = value; }
    //}

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
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile1, drpAttachType1);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile2, drpAttachType2);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile3, drpAttachType3);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile4, drpAttachType4);
        SaveAttachmentDetails(AttachemtnTable, AttachmentPK, fpFile5, drpAttachType5);

        txtAttachDesc.Text = "";
        drpAttachType1.SelectedIndex = 0;
        drpAttachType2.SelectedIndex = 0;
        drpAttachType3.SelectedIndex = 0;
        drpAttachType4.SelectedIndex = 0;
        drpAttachType5.SelectedIndex = 0;
    }

    private void SaveAttachmentDetails(clsGeneral.Tables AttachemtnTable, int AttachmentPK, FileUpload fpFile, DropDownList drpAttachType)
    {
        // PK and table must be specified, also attachment type must be selected and file must be uploaded.        
        if (AttachmentPK != 0 && !clsGeneral.IsNull(AttachemtnTable) && !clsGeneral.IsNull(fpFile.PostedFile.FileName) && drpAttachType.SelectedIndex > 0)
        {
                ////set values to store in database
                DPD_FR_Attacments objAttachment = new DPD_FR_Attacments();
                objAttachment.Attachment_Type = drpAttachType.SelectedValue;
                objAttachment.Description = txtAttachDesc.Text.Trim();
                objAttachment.FK_DPD_FROL_ID = AttachmentPK;
                // upload the document
                string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)AttachemtnTable]);
                string DocPath = string.Concat(strUploadPath, "\\");

                // upload and set the filename.
                objAttachment.Attachment_Path = clsGeneral.UploadFile(fpFile, DocPath, false, false);
                //Insert the attachment record
                objAttachment.Insert();

            
            drpAttachType.SelectedIndex = 0;
        }

    }

    ///// <summary>
    ///// check if attachment type is valid or not. 
    ///// mainly used when some file is selected but instead of add attachment save and close button is clicked
    ///// in that case no javascript validation will be fired. so server side validation is necesaary.
    ///// </summary>
    ///// <returns></returns>
    //private bool IsValidAttachmentType(FileUpload fpFile)
    //{
    //    if (drpAttachType.SelectedValue == "2")
    //    {
    //        string ext = clsGeneral.GetExtension(fpFile.PostedFile.FileName);
    //        bool retVal = false;
    //        switch (ext.ToLower())
    //        {
    //            case ".gif":
    //            case ".jpg":
    //            case ".bmp":
    //            case ".jpeg":
    //            case ".tif":
    //            case ".png":
    //                retVal = true;
    //                break;
    //        }
    //        return retVal;
    //    }
    //    else
    //    {
    //        return true;
    //    }
    //}

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
}
