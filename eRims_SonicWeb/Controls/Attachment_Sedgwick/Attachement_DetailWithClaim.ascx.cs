using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class Controls_Attachment_Sedgwick_Attachement_DetailWithClaim : System.Web.UI.UserControl
{
    # region " Private Property That Needed To be Set Before Binding the Grid "

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

    /// <summary>
    /// Gets or sets the Year field value
    /// </summary>
    private int Year
    {
        get { return clsGeneral.GetInt(ViewState["Year"]); }
        set { ViewState["Year"] = value; }
    }

    /// <summary>
    /// Gets or sets the Quarter field value
    /// </summary>
    private int Quarter
    {
        get { return clsGeneral.GetInt(ViewState["Quarter"]); }
        set { ViewState["Quarter"] = value; }
    }

    /// <summary>
    /// Gets or sets the FK_LU_Sedgwick_Field_Office field value
    /// </summary>
    private decimal FK_LU_Sedgwick_Field_Office
    {
        get { return clsGeneral.GetInt(ViewState["FK_LU_Sedgwick_Field_Office"]); }
        set { ViewState["FK_LU_Sedgwick_Field_Office"] = value; }
    }

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : string.Empty); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : string.Empty); }
        set { ViewState["SortOrder"] = value; }
    }

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

    # endregion

    # region " Page Events "

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (isViewOnly)
            {
                btnRemoveAttachment.Visible = false;
            }
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
            string strIDs = "<Attachments>"; //will have the xml seperated IDs 

            //loop through all the records in grid
            for (int i = 0; i < gvAttachment.Rows.Count; i++)
            {
                // if check box is checked for this item. append id to remove.
                CheckBox chkSelect = (CheckBox)gvAttachment.Rows[i].FindControl("chkSelect");
                if (chkSelect.Checked)
                {

                    HtmlInputHidden hdnID = (HtmlInputHidden)gvAttachment.Rows[i].FindControl("hdnID");
                    HtmlInputHidden hdnFileName = (HtmlInputHidden)gvAttachment.Rows[i].FindControl("hdnFileName");

                    strIDs += "<ID>" + hdnID.Value + "</ID>";

                    //if (strIDs == "0")
                    //    strIDs = hdnID.Value;
                    //else
                    //    strIDs = strIDs + "," + hdnID.Value;


                    //// delete the uploaded document
                    //string strDocPath = AppConfig.strAPDocumentURL + @"\" + hdnFileName.Value;
                    //if (File.Exists(strDocPath))
                    //    File.Delete(strDocPath);
                }
            }
            strIDs += "</Attachments>";


            // delete record from database
            //string strSQL = "";
            //strSQL = strSQL + "DELETE FROM " + "Sedgwick_Attachments";
            //strSQL = strSQL + " WHERE " + PK_Field_Name + " IN (" + strIDs + ")";

            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbcommand = db.GetStoredProcCommand("Attachement_DetailWithClaimDelete");
            db.AddInParameter(dbcommand, "strPK_Sedgwick_Attachments", DbType.String, strIDs);

            DataSet objDs = new DataSet();
            objDs = db.ExecuteDataSet(dbcommand);

            if (objDs != null && objDs.Tables.Count > 0 && objDs.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                {
                    // delete the uploaded document
                    string strDocPath = AppConfig.strAPDocumentPath + @"\" + objDs.Tables[0].Rows[i]["Atachment_Name_On_Disk"].ToString();
                    if (File.Exists(strDocPath))
                        File.Delete(strDocPath);
                }
            }

            BindGroupAttachements();

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
        // if attachemetn is an image,show image else show icon.z
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlGenericControl dvDocIcon = (HtmlGenericControl)e.Row.FindControl("dvDocIcon");
            HtmlGenericControl dvImage = (HtmlGenericControl)e.Row.FindControl("dvImage");

            // get the imagebutton for view and set the javascript function on its onClientClick event 
            // which displays the attached document
            ImageButton imgDownloadImg = (ImageButton)e.Row.FindControl("imgDownloadDoc");
            string strFileName = DataBinder.Eval(e.Row.DataItem, "Attachment_Path1").ToString();
            //string Encoded_FileName = Encode_Url(strFileName);
            strFileName = AppConfig.strAPDocumentPath + strFileName;


            // set the file path and call the JS function

            string strFilePath = Encryption.Encrypt(strFileName).Replace("'", "\\'");
            imgDownloadImg.OnClientClick = "javascript:return openWindow('" + AppConfig.SiteURL + "/Download.aspx?attachfile=" + strFilePath + "');";

        }
    }
    /// <summary>
    /// GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAttachment_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGroupAttachements();
    }
    /// <summary>
    /// GridView Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAttachment_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {

            // if sort field already available
            if (String.Empty != SortBy)
            {
                // update sort image beside the column header 
                AddSortImage(e.Row);
            }
            else
            {
                // add sort image beside the column header 
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[3].Controls.Add(sortImage);
            }
        }
    }
    #endregion

    # region " Public Methods "
    /// <summary>
    /// Returns the index of the column which contains perticular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 1;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvAttachment.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvAttachment.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage(GridViewRow headerRow)
    {
        Int32 iCol = GetSortColumnIndex(SortBy);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder = SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

        // check for the order and
        // set the images accordingly 
        if (SortDirection.Ascending.ToString() == strSortOrder)
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }

        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);
    }
    /// <summary>
    /// before using this user control's bind method,3 properties must be initialized using this methods.
    /// 1) table to be used
    /// 2) FK
    /// 3) Allow Remove operation or not.
    /// </summary>
    /// <param name="tbl"></param>
    /// <param name="FK"></param>
    /// <param name="AllowRemove"></param>
    public void InitializeAttachmentDetails(int FK, string FK_Field_Name, string pK_Field_Name, bool AllowRemove, int intAttachmentPanelNumber, int Year, int Quarter, decimal FK_LU_Sedgwick_Field_Office)
    {
        this.AllowRemove = AllowRemove;
        this.IntAttachmentPanel = intAttachmentPanelNumber;
        this.AttachmentFK = FK;
        this.AttachmentFKName = FK_Field_Name;
        this.PK_Field_Name = pK_Field_Name;
        this.Year = Year;
        this.Quarter = Quarter;
        this.FK_LU_Sedgwick_Field_Office = FK_LU_Sedgwick_Field_Office;

        SortBy = "WCC.Origin_Claim_Number,CAST(SA.Attachment_Description AS NVARCHAR(4000)),Attachment_Path";
        SortOrder = "ASC";

        if (!AppConfig.AllowMailSending)
            btnMail.OnClientClick = "javascript:alert('Attachment cannot be sent as mailing option is disabled');return false;";
        else
            btnMail.OnClientClick = "javascript:ShowMailPage('" + this.PK_Field_Name.ToString() + "');return false;";
    }

    /// <summary>
    /// Bind the Grid with the Attachment details.
    /// </summary>
    public void BindGroupAttachements()
    {
        if (FK_LU_Sedgwick_Field_Office != 0)
        {
            string strSQL = "";
            strSQL = strSQL + "SELECT WCC.Origin_Claim_Number,SA.PK_Sedgwick_Attachments , ";
            strSQL = strSQL + "SA.Attachment_Description,";
            strSQL = strSQL + "SA.Atachment_Name_On_Disk AS Attachment_Path1,";
            strSQL = strSQL + "SUBSTRING(SA.Atachment_Name_On_Disk,13,LEN(SA.Atachment_Name_On_Disk)-12) AS Attachment_Path,";
            strSQL = strSQL + "SA.Update_Date";
            strSQL = strSQL + " FROM " + "Sedgwick_Attachments SA" + Environment.NewLine;
            strSQL = strSQL + " INNER JOIN Sedgwick_Claim_Review SCR ON SA.FK_Sedgwick_Claim_Review = SCR.PK_Sedgwick_Claim_Review" + Environment.NewLine;
            strSQL = strSQL + " INNER JOIN Sedgwick_Claim_Group SCG ON SCR.FK_Sedgwick_Claim_Group = SCG.PK_Sedgwick_Claim_Group" + Environment.NewLine;
            strSQL = strSQL + " INNER JOIN Workers_Comp_Claims WCC ON SCR.FK_Workers_Comp_Claims = WCC.PK_Workers_Comp_Claims_ID" + Environment.NewLine;
            strSQL = strSQL + " WHERE SCG.Year = " + Year + " AND SCG.Quarter = " + Quarter + " AND SCG.FK_LU_Sedgwick_Field_Office =" + FK_LU_Sedgwick_Field_Office;

            if (SortBy == "Attachment_Description")
                SortBy = "CAST(SA.Attachment_Description AS NVARCHAR(4000))";

            strSQL = strSQL + " ORDER BY " + SortBy + " " + SortOrder;
            //strSQL = strSQL + " ORDER BY WCC.Origin_Claim_Number,CAST(SA.Attachment_Description AS NVARCHAR(4000)),Attachment_Path";

            Database db = DatabaseFactory.CreateDatabase();
            DataSet ds = db.ExecuteDataSet(System.Data.CommandType.Text, strSQL);
            if (ds != null)
            {
                gvAttachment.DataSource = ds.Tables[0];
                gvAttachment.DataBind();

                if (isViewOnly)
                {
                    btnRemoveAttachment.Visible = false;
                }
                else
                {
                    btnRemoveAttachment.Visible = (AllowRemove && ds.Tables[0].Rows.Count > 0) ? true : false;
                }
                
                btnMail.Visible = (AllowRemove && ds.Tables[0].Rows.Count > 0) ? true : false;
                gvAttachment.Columns[0].Visible = AllowRemove;
            }
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