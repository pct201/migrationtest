using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
public partial class Attachment_Pollution : System.Web.UI.UserControl
{

    #region Private variables used to hold the property values

    private string _FK_Field_Name;
    private decimal? _FK_Field_Value;
    private string _Table_Name;
    #endregion

    #region "Public Properties"

    /// <summary>
    /// Gets or sets the FK_Field_Name value.
    /// </summary>
    public string FK_Field_Name
    {
        get { return _FK_Field_Name; }
        set { _FK_Field_Name = value; }
    }

    /// <summary>
    /// Gets or sets the FK_Field_Value value.
    /// </summary>
    public decimal? FK_Field_Value
    {
        get { return _FK_Field_Value; }
        set { _FK_Field_Value = value; }
    }
    /// <summary>
    /// Gets or sets the FK_Field_Value value.
    /// </summary>
    public string Table_Name
    {
        get { return _Table_Name; }
        set { _Table_Name = value; }
    }
    //public string RequiredAttachTypeID
    //{
    //    get { return reqAttachType.ClientID; }
    //}

    public string RequiredAttachFileID
    {
        get { return reqFile.ClientID; }
    }

    /// <summary>
    /// denotes Primary Key of EPM_Attchments table
    /// </summary>
    public decimal PK_EPM_Attchments
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Attchments"]); }
        set { ViewState["PK_EPM_Attchments"] = value; }
    }

    /// <summary>
    /// denotes Primary Key of Building table
    /// </summary>
    public decimal Building_ID
    {
        get { return Convert.ToDecimal(ViewState["Building_ID"]); }
        set { ViewState["Building_ID"] = value; }
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
            if (Table_Name == "PM_Attachments")
            {
                trAttachment_Type.Visible = true;
                BindAttachmentType();
            }
        }
    }

    # endregion

    # region " Public Methods "

    public void BindAttachmentType()
    {
        ComboHelper.FillLU_EPM_Attachment_TypeForEnvironmental(new DropDownList[] { drpAttachType }, true);
    }

    /// <summary>
    /// Add Attachment.
    /// saves attachment at physical path depending on table used.
    /// also inser record in database.
    /// </summary>
    /// <param name="AttachemtnTable"></param>
    /// <param name="AttachmentPK"></param>
    public void Add(clsGeneral.Pollution_Tables AttachmentTable)
    {
        if (FK_Field_Value != 0)
        {
            SaveAttachmentDetails(AttachmentTable, fpFile1);
            SaveAttachmentDetails(AttachmentTable, fpFile2);
            SaveAttachmentDetails(AttachmentTable, fpFile3);
            SaveAttachmentDetails(AttachmentTable, fpFile4);
            SaveAttachmentDetails(AttachmentTable, fpFile5);
            SaveAttachmentDetails(AttachmentTable, fpFile6);
            SaveAttachmentDetails(AttachmentTable, fpFile7);
            SaveAttachmentDetails(AttachmentTable, fpFile8);
            SaveAttachmentDetails(AttachmentTable, fpFile9);
            SaveAttachmentDetails(AttachmentTable, fpFile10);

            txtAttachDesc.Text = "";
            drpAttachType.SelectedIndex = 0;

            // PK and table must be specified, also attachment type must be selected and file must be uploaded.        
            //if (IsValidAttachmentType() && FK_Field_Value != 0 && !clsGeneral.IsNull(AttachmentTable) && drpAttachType.SelectedIndex != 0 && !clsGeneral.IsNull(fpFile.PostedFile.FileName))
            //{
            //    string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.PollutionTableName[(int)AttachmentTable]);
            //    string DocPath = string.Concat(strUploadPath, "\\");
            //    string name = clsGeneral.UploadFile(fpFile, DocPath, false, false);

            //    string strSQL = "";
            //    strSQL = strSQL + "INSERT INTO " + clsGeneral.PollutionTableName[(int)AttachmentTable] + Environment.NewLine;
            //    strSQL = strSQL + "(" + FK_Field_Name + "," + Environment.NewLine;
            //    strSQL = strSQL + "FK_Attachment_Type" + "," + Environment.NewLine;
            //    strSQL = strSQL + "Description" + "," + Environment.NewLine;
            //    strSQL = strSQL + "Attachment_Path" + "," + Environment.NewLine;
            //    strSQL = strSQL + "Updated_By" + "," + Environment.NewLine;
            //    strSQL = strSQL + "Update_Date)" + Environment.NewLine;
            //    strSQL = strSQL + "VALUES(" + Convert.ToString(FK_Field_Value) + "," + Environment.NewLine;
            //    strSQL = strSQL + "NULL," + Environment.NewLine;
            //    //strSQL = strSQL + Convert.ToString(drpAttachType.SelectedValue) + "," + Environment.NewLine;
            //    strSQL = strSQL + "'" + txtAttachDesc.Text.Trim() + "'," + Environment.NewLine;
            //    //strSQL = strSQL + "'" + name.Trim() + "'," + Environment.NewLine;                
            //    strSQL = strSQL + (string.IsNullOrEmpty(clsSession.UserID) ? "''" : clsSession.UserID) + "," + Environment.NewLine;
            //    strSQL = strSQL + "'" + string.Format("{0:MM/dd/yyyy}",DateTime.Now) + "')";

            //    Database db = DatabaseFactory.CreateDatabase();
            //    db.ExecuteNonQuery(System.Data.CommandType.Text, strSQL);

            //    txtAttachDesc.Text = "";
            //    drpAttachType.SelectedIndex = 0;
            //}
            //strSQL = strSQL + "VALUES(" + FK_Field_Name + " = " + FK_Field_Value + "," + Environment.NewLine;
            //strSQL = strSQL + "FK_Attachment_Type = " + Convert.ToString(drpAttachType.SelectedValue) +"," + Environment.NewLine;
            //strSQL = strSQL + "Attachment_Description = '" + txtAttachDesc.Text.Trim().Replace("'","''") + "'," + Environment.NewLine;
            //strSQL = strSQL + "Updated_By = ''," + Environment.NewLine;
            //strSQL = strSQL + "Update_Date = " + DateTime.Now + Environment.NewLine;
        }
    }

    private void SaveAttachmentDetails(clsGeneral.Pollution_Tables AttachmentTable, FileUpload fpFile)
    {
        //if (FK_Field_Value != 0 && Table_Name == "PM_Attachments" && !clsGeneral.IsNull(fpFile.PostedFile.FileName))
        //{
        //    DataTable dtEPM_Identification = PM_Site_Information.GetPK_EPM_Identification(Building_ID).Tables[0];
        //    if (dtEPM_Identification != null && dtEPM_Identification.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dtEPM_Identification.Rows.Count; i++)
        //        {
        //            string strUploadPath = AppConfig.strEPMDocumentPath;
        //            string Attachment_Filename = clsGeneral.UploadFile(fpFile, strUploadPath, false, false);

        //            string strSQL_EPM = "";
        //            strSQL_EPM = strSQL_EPM + "INSERT INTO " + "EPM_Attachments" + Environment.NewLine;
        //            strSQL_EPM = strSQL_EPM + "(" + "FK_EPM_Identification" + "," + Environment.NewLine;
        //            strSQL_EPM = strSQL_EPM + "Attachment_Type" + "," + Environment.NewLine;
        //            strSQL_EPM = strSQL_EPM + "Attachment_Description" + "," + Environment.NewLine;
        //            strSQL_EPM = strSQL_EPM + "Attachment_Filename" + "," + Environment.NewLine;
        //            strSQL_EPM = strSQL_EPM + "Attach_Date" + "," + Environment.NewLine;
        //            strSQL_EPM = strSQL_EPM + "Updated_By" + "," + Environment.NewLine;
        //            strSQL_EPM = strSQL_EPM + "Update_Date)" + Environment.NewLine;
        //            strSQL_EPM = strSQL_EPM + "VALUES(" + Convert.ToString(dtEPM_Identification.Rows[i]["PK_EPM_Identification"]) + "," + Environment.NewLine;
        //            strSQL_EPM = strSQL_EPM + Convert.ToString(drpAttachType.SelectedValue) + "," + Environment.NewLine;
        //            strSQL_EPM = strSQL_EPM + "'" + fpFile.PostedFile.FileName.Substring(fpFile.PostedFile.FileName.LastIndexOf("\\") + 1).Replace("'", "''") + "'," + Environment.NewLine;
        //            strSQL_EPM = strSQL_EPM + "'" + Attachment_Filename.Trim().Replace("'","''") + "'," + Environment.NewLine;
        //            strSQL_EPM = strSQL_EPM + "'" + Convert.ToString(DateTime.Now) + "'," + Environment.NewLine;
        //            strSQL_EPM = strSQL_EPM + (string.IsNullOrEmpty(clsSession.UserID) ? "''" : clsSession.UserID) + "," + Environment.NewLine;
        //            strSQL_EPM = strSQL_EPM + "'" + Convert.ToString(DateTime.Now) + "')";

        //            Database db = DatabaseFactory.CreateDatabase();
        //            db.ExecuteNonQuery(System.Data.CommandType.Text, strSQL_EPM);
        //        }
        //    }
        //}

        // PK and table must be specified, also attachment type must be selected and file must be uploaded.        
        if (FK_Field_Value != 0 && !clsGeneral.IsNull(AttachmentTable) && !clsGeneral.IsNull(fpFile.PostedFile.FileName))
        {
            string strUploadPath = clsGeneral.GetAttachmentDocPath(clsGeneral.PollutionTableName[(int)AttachmentTable]);
            string DocPath = string.Concat(strUploadPath, "\\");
            string name = clsGeneral.UploadFile(fpFile, DocPath, false, false);

            string strSQL = "";
            strSQL = strSQL + "INSERT INTO " + clsGeneral.PollutionTableName[(int)AttachmentTable] + Environment.NewLine;
            strSQL = strSQL + "(" + FK_Field_Name + "," + Environment.NewLine;

            if (Table_Name == "PM_Equipment_Tank" || Table_Name == "PM_Equipment_Spray_Booth" || Table_Name == "PM_Equipment_OWS" || Table_Name == "PM_Equipment_Hydraulic_Lift" || Table_Name == "PM_Equipment_PGCC")
                strSQL = strSQL + "Table_Name" + "," + Environment.NewLine;

            if (clsGeneral.PollutionTableName[(int)AttachmentTable] != "PM_Compliance_Reporting_OSHA_Attachments")
                strSQL = strSQL + "FK_Attachment_Type" + "," + Environment.NewLine;
            strSQL = strSQL + "Description" + "," + Environment.NewLine;
            strSQL = strSQL + "Attachment_Path" + "," + Environment.NewLine;
            strSQL = strSQL + "Updated_By" + "," + Environment.NewLine;
            strSQL = strSQL + "Update_Date)" + Environment.NewLine;
            strSQL = strSQL + "VALUES(" + Convert.ToString(FK_Field_Value) + "," + Environment.NewLine;
            if (Table_Name == "PM_Equipment_Tank" || Table_Name == "PM_Equipment_Spray_Booth" || Table_Name == "PM_Equipment_OWS" || Table_Name == "PM_Equipment_Hydraulic_Lift" || Table_Name == "PM_Equipment_PGCC")
                strSQL = strSQL + "'" + Convert.ToString(Table_Name) + "'," + Environment.NewLine;
            if (clsGeneral.PollutionTableName[(int)AttachmentTable] != "PM_Compliance_Reporting_OSHA_Attachments")
                strSQL = strSQL + Convert.ToString(drpAttachType.SelectedValue) + "," + Environment.NewLine;
            strSQL = strSQL + "'" + txtAttachDesc.Text.Trim().Replace("'", "''") + "'," + Environment.NewLine;
            strSQL = strSQL + "'" + name.Trim().Replace("'", "''") + "'," + Environment.NewLine;
            strSQL = strSQL + (string.IsNullOrEmpty(clsSession.UserID) ? "''" : clsSession.UserID) + "," + Environment.NewLine;
            strSQL = strSQL + "'" + Convert.ToString(DateTime.Now) + "')";

            Database db = DatabaseFactory.CreateDatabase();
            db.ExecuteNonQuery(System.Data.CommandType.Text, strSQL);
        }
    }

    /// <summary>
    /// check if attachment type is valid or not. 
    /// mainly used when some file is selected but instead of add attachment save and close button is clicked
    /// in that case no javascript validation will be fired. so server side validation is necesaary.
    /// </summary>
    /// <returns></returns>
    //private bool IsValidAttachmentType()
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
