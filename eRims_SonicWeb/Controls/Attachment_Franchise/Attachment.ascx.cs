using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
public partial class Ctrl_Franchise_Attachment : System.Web.UI.UserControl
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

    # region " Page Events "


    protected void Page_Load(object sender, EventArgs e)
    {
        fpFile.Attributes.Add("onchange", "javascript:UpdloadFile('" + fpFile.ClientID + "','" + btnHdn.ClientID + "','" + txtType.ClientID + "');");
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
    public void Add(decimal FK_Franchise)
    {
        // PK and table must be specified, also attachment type must be selected and file must be uploaded.        
        //IsValidAttachmentType() && drpAttachType.SelectedIndex != 0 && 
        if (!clsGeneral.IsNull(fpFile.PostedFile.FileName))
        {
            //set values to store in database
            Franchise_Attachments objAttachment = new Franchise_Attachments();
            objAttachment.FK_Franchise = FK_Franchise;
            objAttachment.Type = txtType.Text.Trim();
            // upload the document
            string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)clsGeneral.Tables.Franchise]);
            string DocPath = string.Concat(strUploadPath, "\\");
            objAttachment.Path = clsGeneral.UploadFile(fpFile, DocPath, false, false);
            objAttachment.FileName = objAttachment.Path.Substring(objAttachment.Path.LastIndexOf("\\") + 1);
            //Insert the attachment record
            objAttachment.Insert();

            txtType.Text = "";
            //txtAttachDesc.Text = "";
            //drpAttachType.SelectedIndex = 0;
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
