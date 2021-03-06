﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data;
using ERIMS.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

public partial class AttachmentDetails_Pollution : System.Web.UI.UserControl
{

    # region " Private Property That Needed To be Set Before Binding the Grid "

    /// <summary>
    /// Table to be used to fetch attachment data.
    /// </summary>
    private clsGeneral.Pollution_Tables AttachmentTable
    {
        get { return (clsGeneral.Pollution_Tables)ViewState["AttachmentTable"]; }
        set { ViewState["AttachmentTable"] = value; }
    }

    /// <summary>
    /// Gets or sets the FK field value
    /// </summary>
    private int AttachmentFK
    {
        get { return clsGeneral.GetInt(ViewState["AttachmentFK"]); }
        set { ViewState["AttachmentFK"] = value; }
    }

    /// <summary>
    /// Gets or sets the FK field name
    /// </summary>
    private string AttachmentFKName
    {
        get { return Convert.ToString(ViewState["AttachmentFKName"]); }
        set { ViewState["AttachmentFKName"] = value; }
    }

    /// <summary>
    /// Gets or sets the PK field name
    /// </summary>
    private string PK_Field_Name
    {
        get { return Convert.ToString(ViewState["PK_Field_Name"]); }
        set { ViewState["PK_Field_Name"] = value; }
    }

    /// <summary>
    /// if true, remove button and check box column will be visible else not.
    /// </summary>
    private bool AllowRemove
    {
        get
        {
            if (ViewState["AllowRemove"] == null)
                return false;
            else
                return Convert.ToBoolean(ViewState["AllowRemove"]);
        }
        set { ViewState["AllowRemove"] = value; }
    }

    /// <summary>
    /// Denotes the Panel number for attachment in page 
    /// which can be set after the remove or mail button click
    /// </summary>
    public int IntAttachmentPanel
    {
        get { return Convert.ToInt32(ViewState["IntAttachmentPanel"]); }
        set { ViewState["IntAttachmentPanel"] = value; }
    }

    public string Equipment_Table_Name
    {
        get { return Convert.ToString(ViewState["Equipment_Table_Name"]); }
        set { ViewState["Equipment_Table_Name"] = value; }
    }

    public string Table_Name
    {
        get { return Convert.ToString(ViewState["Table_Name"]); }
        set { ViewState["Table_Name"] = value; }
    }

    # endregion

    # region " Page Events "

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Table_Name == "PM_Attachments")
            gvAttachment.Columns[3].Visible = true;
        else
            gvAttachment.Columns[3].Visible = false;

        if (Table_Name != "PM_Compliance_Reporting_OSHA_Attachments")
        {
            gvAttachment.Columns[1].Visible = false;
        }
        else
        {
            gvAttachment.Columns[1].Visible = true;
        }
    }

    # endregion

    # region " Control Events "

    protected void btnRemoveAttachment_Click(object sender, EventArgs e)
    {
        try
        {
            // generate comma seperated string of ids of records in Attachment Tables,
            // use those id to delete selected records.
            string strIDs = "0"; //will have the comma seperated IDs 

            //loop through all the records in grid
            for (int i = 0; i < gvAttachment.Rows.Count; i++)
            {
                // if check box is checked for this item. append id to remove.
                CheckBox chkSelect = (CheckBox)gvAttachment.Rows[i].FindControl("chkSelect");
                if (chkSelect.Checked)
                {

                    HtmlInputHidden hdnID = (HtmlInputHidden)gvAttachment.Rows[i].FindControl("hdnID");
                    HtmlInputHidden hdnFileName = (HtmlInputHidden)gvAttachment.Rows[i].FindControl("hdnFileName");

                    if (strIDs == "0")
                        strIDs = hdnID.Value;
                    else
                        strIDs = strIDs + "," + hdnID.Value;


                    // delete the uploaded document
                    string strDocPath = clsGeneral.GetAttachmentDocPath(clsGeneral.PollutionTableName[(int)AttachmentTable]) + @"\" + hdnFileName.Value;
                    if (File.Exists(strDocPath))
                        File.Delete(strDocPath);
                }
            }

            //// delete record from database
            string strSQL = "";
            strSQL = strSQL + "DELETE FROM " + clsGeneral.PollutionTableName[(int)AttachmentTable];
            strSQL = strSQL + " WHERE " + PK_Field_Name + " IN (" + strIDs + ")";

            Database db = DatabaseFactory.CreateDatabase();
            db.ExecuteNonQuery(System.Data.CommandType.Text, strSQL);

            Bind();

            if (IntAttachmentPanel > 0)
            { Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + IntAttachmentPanel + ");", true); }
        }
        catch
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + IntAttachmentPanel + ");alert('The file cannot be deleted at this time, it in use by another process.');", true);
        }
    }

    # endregion

    #region "Attachment Grid Events"

    protected void gvAttachment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row is datarow, set icon as per attachment type.
        // if attachemetn is an image,show image else show icon.
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlGenericControl dvDocIcon = (HtmlGenericControl)e.Row.FindControl("dvDocIcon");
            HtmlGenericControl dvImage = (HtmlGenericControl)e.Row.FindControl("dvImage");

            // get the imagebutton for view and set the javascript function on its onClientClick event 
            // which displays the attached document
            ImageButton imgDownloadImg = (ImageButton)e.Row.FindControl("imgDownloadDoc");
            string strFileName = DataBinder.Eval(e.Row.DataItem, "Attachment_Path1").ToString();
          //  string Encoded_FileName = Encode_Url(strFileName);
          //  strFileName = clsGeneral.GetAttachmentImageURL(clsGeneral.PollutionTableName[(int)AttachmentTable]) + Encoded_FileName;
            //imgDownloadImg.OnClientClick = "javascript:return openWindow('" + strFileName + "');";

            // set the file path and call the JS function
            string strFilePath = clsGeneral.GetAttachmentDocPath(clsGeneral.PollutionTableName[(int)AttachmentTable]) + strFileName;
            strFilePath = Encryption.Encrypt(strFilePath).Replace("'", "\\'");
            imgDownloadImg.OnClientClick = "javascript:return openWindow('" + AppConfig.SiteURL + "/Download.aspx?attachfile=" + strFilePath + "');";

        }
    }

    #endregion

    # region " Public Methods "

    /// <summary>
    /// before using this user control's bind method,3 properties must be initialized using this methods.
    /// 1) table to be used
    /// 2) FK
    /// 3) Allow Remove operation or not.
    /// </summary>
    /// <param name="tbl"></param>
    /// <param name="FK"></param>
    /// <param name="AllowRemove"></param>
    public void InitializeAttachmentDetails(clsGeneral.Pollution_Tables tbl, int FK, string FK_Field_Name, string pK_Field_Name, bool AllowRemove, int intAttachmentPanelNumber)
    {
        this.AttachmentTable = tbl;
        this.AttachmentFK = FK;
        this.AllowRemove = AllowRemove;
        this.IntAttachmentPanel = intAttachmentPanelNumber;
        this.AttachmentFKName = FK_Field_Name;
        this.AttachmentFK = FK;
        this.PK_Field_Name = pK_Field_Name;

        if (!AppConfig.AllowMailSending)
            btnMail.OnClientClick = "javascript:alert('Attachment cannot be sent as mailing option is disabled');return false;";
        else
            btnMail.OnClientClick = "javascript:ShowMailPage('" + tbl.ToString() + "','" + this.PK_Field_Name.ToString() + "');return false;";
    }

    /// <summary>
    /// Bind the Grid with the Attachment details.
    /// </summary>
    public void Bind()
    {
        if (AttachmentFK != 0)
        {
            //DataTable dtAttachment = COI_Attachment.SelectByTableName(clsGeneral.TableNames[(int)AttachmentTable], AttachmentFK).Tables[0];
            //gvAttachment.DataSource = dtAttachment;
            //gvAttachment.DataBind();

            string strSQL = "";
            strSQL = strSQL + "SELECT " + PK_Field_Name + " AS PK_Attachment_Id,";
            if (clsGeneral.PollutionTableName[(int)AttachmentTable] != "PM_Compliance_Reporting_OSHA_Attachments")
                strSQL = strSQL + "ISNULL(LU_EPM_Attachment_Type.FLD_desc,'General') AS Attachment_Type,";
            else
                strSQL = strSQL + "'1' AS Attachment_Type,";
            strSQL = strSQL + "Description,";
            strSQL = strSQL + "Attachment_Path AS Attachment_Path1,";
            strSQL = strSQL + "SUBSTRING(Attachment_Path,13,LEN(Attachment_Path)-12) AS Attachment_Path,";
            strSQL = strSQL + "Update_Date";
            strSQL = strSQL + " FROM " + clsGeneral.PollutionTableName[(int)AttachmentTable] + Environment.NewLine;
            if (clsGeneral.PollutionTableName[(int)AttachmentTable] != "PM_Compliance_Reporting_OSHA_Attachments")
                strSQL = strSQL + "LEFT JOIN LU_EPM_Attachment_Type ON LU_EPM_Attachment_Type.PK_LU_EPM_Attachment_Type = " + clsGeneral.PollutionTableName[(int)AttachmentTable] + ".FK_Attachment_Type";
            strSQL = strSQL + " WHERE " + AttachmentFKName + " = " + AttachmentFK;
            if (!string.IsNullOrEmpty(Equipment_Table_Name))
            {
                strSQL = strSQL + " AND  Table_Name = '" + Equipment_Table_Name + "'";
            }
            strSQL = strSQL + " ORDER BY Update_Date DESC";

            Database db = DatabaseFactory.CreateDatabase();
            DataSet ds = db.ExecuteDataSet(System.Data.CommandType.Text, strSQL);

            gvAttachment.DataSource = ds.Tables[0];
            gvAttachment.DataBind();

            btnRemoveAttachment.Visible = (AllowRemove && ds.Tables[0].Rows.Count > 0) ? true : false;
            btnMail.Visible = (AllowRemove && ds.Tables[0].Rows.Count > 0) ? true : false;
            gvAttachment.Columns[0].Visible = AllowRemove;

        }
    }

    ///<summary>
    ///method for encoding url in attachment grid
    ///</summary>
    protected string Encode_Url(string StrFilename)
    {
        string Result;
        Result = StrFilename;
        Result = Result.Replace("<", "%3C");
        Result = Result.Replace(">", "%3E");
        Result = Result.Replace("#", "%23");
        // Result = Result.Replace("%", "%25") ;
        Result = Result.Replace("{", "%7B");
        Result = Result.Replace("}", "%7D");
        Result = Result.Replace("|", "%7C");
        //Result = Result.Replace("\\","%5C") ;     
        Result = Result.Replace("^", "%5E");
        Result = Result.Replace("~", "%7E");
        Result = Result.Replace("[", "%5B");
        Result = Result.Replace("]", "%5D");
        Result = Result.Replace("`", "%60");
        Result = Result.Replace(";", "%3B");
        Result = Result.Replace("/", "%2F");
        Result = Result.Replace("?", "%3F");
        Result = Result.Replace(":", "%3A");
        Result = Result.Replace("@", "%40");
        Result = Result.Replace("=", "%3D");
        Result = Result.Replace("&", "%26");
        Result = Result.Replace("$", "%24");
        Result = Result.Replace("-", "%2D");
        Result = Result.Replace("+", "%2B");
        return Result;

    }
    #endregion
}
