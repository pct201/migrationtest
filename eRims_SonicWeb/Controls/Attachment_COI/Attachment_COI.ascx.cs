using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
public partial class Attachment_COI : System.Web.UI.UserControl
{
    #region "Public Properties"

    public string RequiredAttachTypeID
    {
        get { return reqAttachType.ClientID; }
    }

    public string RequiredAttachFileID
    {
        get { return reqFile.ClientID; }
    }

    // Delegate declaration
    public delegate void OnButtonClick(string strValue);

    // Event declaration
    public event OnButtonClick btnHandler;

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
    public void Add(clsGeneral.Tables AttachemtnTable, int AttachmentPK)
    {
        // PK and table must be specified, also attachment type must be selected and file must be uploaded.        
        if (IsValidAttachmentType() && AttachmentPK != 0 && !clsGeneral.IsNull(AttachemtnTable) && drpAttachType.SelectedIndex != 0 && !clsGeneral.IsNull(fpFile.PostedFile.FileName))
        {
            //set values to store in database
            COI_Attachment objAttachment = new COI_Attachment();
            objAttachment.Attachment_Table = clsGeneral.TableNames[(int)AttachemtnTable];

            objAttachment.Foreign_Key = AttachmentPK;
            objAttachment.FK_Attachment_Type = Convert.ToInt32(drpAttachType.SelectedValue);
            objAttachment.Attachment_Description = txtAttachDesc.Text.Trim();
            objAttachment.Updated_By = "";
            objAttachment.Update_Date = DateTime.Today;

            // upload the document
            string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)AttachemtnTable]);
            string DocPath = string.Concat(strUploadPath, "\\");

            // upload and set the filename.
            objAttachment.Attachment_Name = clsGeneral.UploadFile(fpFile, DocPath, false, false);
            //objAttachment.Attachment_Name = GetCustomsg1ileName() + objAttachment.Attachment_Name;
            //Insert the attachment record
            objAttachment.Insert();

            txtAttachDesc.Text = "";
            drpAttachType.SelectedIndex = 0;
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
