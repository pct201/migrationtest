using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

public partial class Controls_Attachment_AssetProtection_Attachment : System.Web.UI.UserControl
{

    #region "Public Properties"

    /// <summary>
    /// denotes Primary Key of LU_Location table
    /// </summary>
    public decimal Location_ID
    {
        get { return Convert.ToDecimal(ViewState["Location_ID"]); }
        set { ViewState["Location_ID"] = value; }
    }

    // Delegate declaration
    public delegate void OnButtonClick(string strValue);

    // Event declaration
    public event OnButtonClick btnHandler;

    #endregion

    # region " Page Events "

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

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
    public void Add()
    {
        SaveAttachmentDetails(fpFile1);
        SaveAttachmentDetails(fpFile2);
        SaveAttachmentDetails(fpFile3);
        SaveAttachmentDetails(fpFile4);
        SaveAttachmentDetails(fpFile5);
        SaveAttachmentDetails(fpFile6);
        SaveAttachmentDetails(fpFile7);
        SaveAttachmentDetails(fpFile8);
        SaveAttachmentDetails(fpFile9);
        SaveAttachmentDetails(fpFile10);

        txtAttachDesc.Text = "";

    }

    private void SaveAttachmentDetails(FileUpload fpFile)
    {
        if (!clsGeneral.IsNull(fpFile.PostedFile.FileName))
        {
            string strUploadPath = AppConfig.strAPDocumentPath;
            string Attachment_Filename = clsGeneral.UploadFile(fpFile, strUploadPath, false, false);

            string strSQL = "";
            strSQL = strSQL + "INSERT INTO " + "AP_Attachments" + Environment.NewLine;
            strSQL = strSQL + "(" + "FK_LU_Location" + "," + Environment.NewLine;
            strSQL = strSQL + "Attachment_Description" + "," + Environment.NewLine;
            strSQL = strSQL + "Attachment_Filename" + "," + Environment.NewLine;
            strSQL = strSQL + "Atachment_Name_On_Disk" + "," + Environment.NewLine;
            strSQL = strSQL + "Updated_By" + "," + Environment.NewLine;
            strSQL = strSQL + "Update_Date)" + Environment.NewLine;
            strSQL = strSQL + "VALUES(" + Convert.ToString(Location_ID) + "," + Environment.NewLine;
            strSQL = strSQL + "'" + txtAttachDesc.Text.Trim().Replace("'", "''") + "'," + Environment.NewLine;
            strSQL = strSQL + "'" + fpFile.PostedFile.FileName.Substring(fpFile.PostedFile.FileName.LastIndexOf("\\") + 1).Replace("'", "''") + "'," + Environment.NewLine;
            strSQL = strSQL + "'" + Attachment_Filename.Trim().Replace("'", "''") + "'," + Environment.NewLine;
            strSQL = strSQL + "'" + clsSession.UserName + "'," + Environment.NewLine;
            strSQL = strSQL + "'" + clsGeneral.FormatDateToStore(DateTime.Now) + "')";

            Database db = DatabaseFactory.CreateDatabase();
            db.ExecuteNonQuery(System.Data.CommandType.Text, strSQL);
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