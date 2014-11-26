using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Management_ManagementSearch : clsBasePage
{
    #region Properties

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string _SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : string.Empty); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string _SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : string.Empty); }
        set { ViewState["SortOrder"] = value; }
    }

    /// <summary>
    /// Denotes IsCriteria
    /// </summary>
    private bool _IsCriteria
    {
        get { return (!clsGeneral.IsNull(ViewState["IsCriteria"]) ? Convert.ToBoolean(ViewState["IsCriteria"]) : false); }
        set { ViewState["IsCriteria"] = value; }
    }


    #endregion

    #region "Page Event"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownList();

            // Check User Rights
            //txtCompany.Focus();
            drpLocation.Focus();
            ctrlPageProperty.PageSize = clsSession.NumberOfSearchRows;
            _SortBy = "Camera_Number";
            _SortOrder = "asc";

            if (!string.IsNullOrEmpty(Request["criteria"]))
            {
                if (Session["ManagementCriteria"] != null)
                {
                    _IsCriteria = true;
                    BindGridByCriteria(1, clsSession.NumberOfSearchRows);
                }
            }
        }

        //btnAdd.Visible = (App_Access != AccessType.View);
        // btnAddNew.Visible = (App_Access != AccessType.View);
        drpLocation.Focus();
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind DropDownList
    /// </summary>
    private void BindDropDownList()
    {
        //ComboHelper.FillLocation(new DropDownList[] { drpLocation }, true);
        //ComboHelper.FillState(new DropDownList[] { drpState }, true);
        //ComboHelper.FillLU_Region(new DropDownList[] { drpRegion }, true);
        ComboHelper.FillLocationByACIUser((new DropDownList[] { drpLocation }), Convert.ToDecimal(clsSession.UserID), true);
        ComboHelper.FillLU_Camera_Type(new DropDownList[] { drpCamera_Type }, true);
        ComboHelper.FillStatus(drpClient_Issue, true);
        ComboHelper.FillStatus(drpFacilities_Issue, true);
    }

    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {

        #region "Variable"

        decimal? decState = 0, decLocation = 0, decRegion = 0, decCameraType = 0, decCost = 0, decLocation_Code = null;
        DateTime? Date_Scheduled_From = null, Date_Scheduled_To = null, Date_Complete_From = null, Date_Complete_To = null, CR_Approved_From = null, CR_Approved_To = null;
        string strCompany = null, strCity = null, strCounty = null, strCameraNumber = null, strClientIssue = null, strFacilitiesIssue = null;

        //if (drpState.SelectedIndex > 0) decState = Convert.ToDecimal(drpState.SelectedValue);
        if (drpLocation.SelectedIndex > 0) decLocation = Convert.ToDecimal(drpLocation.SelectedValue);
        //if (drpRegion.SelectedIndex > 0) decRegion = Convert.ToDecimal(drpRegion.SelectedValue);
        if (drpCamera_Type.SelectedIndex > 0) decCameraType = Convert.ToDecimal(drpCamera_Type.SelectedValue);
        if (drpClient_Issue.SelectedIndex > 0) strClientIssue = Convert.ToString(drpClient_Issue.SelectedValue);
        if (drpFacilities_Issue.SelectedIndex > 0) strFacilitiesIssue = Convert.ToString(drpFacilities_Issue.SelectedValue);

        if (!string.IsNullOrEmpty(txtDate_Scheduled.Text)) Date_Scheduled_From = Convert.ToDateTime(txtDate_Scheduled.Text);
        if (!string.IsNullOrEmpty(txtTo_Date_Scheduled.Text)) Date_Scheduled_To = Convert.ToDateTime(txtTo_Date_Scheduled.Text);
        if (!string.IsNullOrEmpty(txtDate_Complete.Text)) Date_Complete_From = Convert.ToDateTime(txtDate_Complete.Text);
        if (!string.IsNullOrEmpty(txtTo_Date_Complete.Text)) Date_Complete_To = Convert.ToDateTime(txtTo_Date_Complete.Text);
        if (!string.IsNullOrEmpty(txtCR_Approved.Text)) CR_Approved_From = Convert.ToDateTime(txtCR_Approved.Text);
        if (!string.IsNullOrEmpty(txtTo_CR_Approved.Text)) CR_Approved_To = Convert.ToDateTime(txtTo_CR_Approved.Text);

        //if (!string.IsNullOrEmpty(txtCompany.Text)) strCompany = txtCompany.Text.Trim().Replace("'", "''");
        //if (!string.IsNullOrEmpty(txtCity.Text)) strCity = txtCity.Text.Trim().Replace("'", "''");
        //if (!string.IsNullOrEmpty(txtCounty.Text)) strCounty = txtCounty.Text.Trim().Replace("'", "''");
        if (!string.IsNullOrEmpty(txtCamera_Number.Text)) strCameraNumber = txtCamera_Number.Text.Trim().Replace("'", "''");
        if (!string.IsNullOrEmpty(txtCost.Text)) decCost = Convert.ToDecimal(txtCost.Text);

        if (!string.IsNullOrEmpty(txtLocation_Code.Text)) decLocation_Code = Convert.ToDecimal(txtLocation_Code.Text);

        bool? Task_Complete = null;

        if (!string.IsNullOrEmpty(rdbTaskComplete.SelectedValue))
        {
            Task_Complete = Convert.ToBoolean(Convert.ToInt32(rdbTaskComplete.SelectedValue));
        }

        #endregion

        #region "Bind Grid"

        // selects records depending on paging criteria and search values.
        DataSet dsManagement = ERIMS.DAL.clsManagement.ManagementSearch(strCompany, strCity, strCounty, strCameraNumber, decCost, decLocation, decState, decRegion, decCameraType, strClientIssue,
            strFacilitiesIssue, Date_Scheduled_From, Date_Scheduled_To, Date_Complete_From, Date_Complete_To, CR_Approved_From, CR_Approved_To, decLocation_Code, _SortBy, _SortOrder, PageNumber, PageSize, Task_Complete);
        DataTable dtManagement = dsManagement.Tables[0];

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (dsManagement.Tables.Count >= 2) ? Convert.ToInt32(dsManagement.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (dsManagement.Tables.Count >= 2) ? Convert.ToInt32(dsManagement.Tables[1].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dsManagement.Tables[0].Rows.Count;
        ctrlPageProperty.SetPageNumbers();

        if (dsManagement.Tables[0] == null || dsManagement.Tables[0].Rows.Count == 0)
        {
            gvManagement.Width = 999;
            dvSearchResult.Style["overflow-x"] = "none";
            btnSaveToExcel.Visible = false;
        }
        else
        {
            gvManagement.Width = 999;
            dvSearchResult.Style["overflow-x"] = "none";
            btnSaveToExcel.Visible = true;
        }

        // bind the grid.
        gvManagement.DataSource = dtManagement;
        gvManagement.DataBind();

        // set record numbers retrieved
        lblNumber.Text = (dsManagement.Tables.Count >= 2) ? Convert.ToString(dsManagement.Tables[1].Rows[0][0]) : "0";

        #endregion

        #region "Save Criteria"

        DataTable dtCriteria = new DataTable();
        dtCriteria.Columns.Add("strCompany", typeof(string));
        dtCriteria.Columns.Add("strCity", typeof(string));
        dtCriteria.Columns.Add("strCounty", typeof(string));
        dtCriteria.Columns.Add("strCameraNumber", typeof(string));
        dtCriteria.Columns.Add("strClientIssue", typeof(string));
        dtCriteria.Columns.Add("strFacilitiesIssue", typeof(string));
        dtCriteria.Columns.Add("Date_Scheduled_From", typeof(string));
        dtCriteria.Columns.Add("Date_Scheduled_To", typeof(string));
        dtCriteria.Columns.Add("Date_Complete_From", typeof(string));
        dtCriteria.Columns.Add("Date_Complete_To", typeof(string));
        dtCriteria.Columns.Add("CR_Approved_From", typeof(string));
        dtCriteria.Columns.Add("CR_Approved_To", typeof(string));

        dtCriteria.Columns.Add("decState", typeof(decimal));
        dtCriteria.Columns.Add("decLocation", typeof(decimal));
        dtCriteria.Columns.Add("decRegion", typeof(decimal));
        dtCriteria.Columns.Add("decCameraType", typeof(decimal));
        dtCriteria.Columns.Add("decCost", typeof(decimal));
        dtCriteria.Columns.Add("decLocation_Code", typeof(decimal));
        dtCriteria.Columns.Add("Task_Complete", typeof(bool));

        DataRow drCriteria = dtCriteria.NewRow();
        drCriteria["strCompany"] = strCompany;
        drCriteria["strCity"] = strCity;
        drCriteria["strCounty"] = strCounty;
        drCriteria["strCameraNumber"] = strCameraNumber;
        drCriteria["strCameraNumber"] = strCameraNumber;
        drCriteria["strClientIssue"] = strClientIssue;
        drCriteria["strFacilitiesIssue"] = strFacilitiesIssue;
        drCriteria["Date_Scheduled_From"] = Date_Scheduled_From;
        drCriteria["Date_Scheduled_To"] = Date_Scheduled_To;
        drCriteria["Date_Complete_From"] = Date_Complete_From;
        drCriteria["Date_Complete_To"] = Date_Complete_To;
        drCriteria["CR_Approved_From"] = CR_Approved_From;
        drCriteria["CR_Approved_To"] = CR_Approved_To;

        drCriteria["decState"] = decState;
        drCriteria["decLocation"] = decLocation;
        drCriteria["decRegion"] = decRegion;
        drCriteria["decCameraType"] = decCameraType;
        drCriteria["decCost"] = decCost;
        if (decLocation_Code != null)
            drCriteria["decLocation_Code"] = decLocation_Code;
        if (Task_Complete != null)
            drCriteria["Task_Complete"] = Task_Complete;

        dtCriteria.Rows.Add(drCriteria);
        Session["ManagementCriteria"] = dtCriteria;

        #endregion

    }

    /// <summary>
    /// Bind Grid By Criteria
    /// </summary>
    /// <param name="PageNumber"></param>
    /// <param name="PageSize"></param>
    private void BindGridByCriteria(int PageNumber, int PageSize)
    {
        DataTable dtcriteria = (DataTable)Session["ManagementCriteria"];
        DataRow drCriteria = dtcriteria.Rows[0];

        #region "Declaration"

        decimal? decState = Convert.ToDecimal(drCriteria["decState"]);
        decimal? decLocation = Convert.ToDecimal(drCriteria["decLocation"]);
        decimal? decRegion = Convert.ToDecimal(drCriteria["decRegion"]);
        decimal? decCameraType = Convert.ToDecimal(drCriteria["decCameraType"]);
        decimal? decCost = Convert.ToDecimal(drCriteria["decCost"]);
        decimal? decLocation_Code = null;
        if (drCriteria["decLocation_Code"] != DBNull.Value)
            decLocation_Code = Convert.ToDecimal(drCriteria["decLocation_Code"]);
        DateTime? Date_Scheduled_From = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Date_Scheduled_From"]));
        DateTime? Date_Scheduled_To = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Date_Scheduled_To"]));
        DateTime? Date_Complete_From = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Date_Complete_From"]));
        DateTime? Date_Complete_To = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Date_Complete_To"]));
        DateTime? CR_Approved_From = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["CR_Approved_From"]));
        DateTime? CR_Approved_To = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["CR_Approved_To"]));

        string strCompany = Convert.ToString(drCriteria["strCompany"]);
        string strCity = Convert.ToString(drCriteria["strCity"]);
        string strCounty = Convert.ToString(drCriteria["strCounty"]);
        string strCameraNumber = Convert.ToString(drCriteria["strCameraNumber"]);
        string strClientIssue = Convert.ToString(drCriteria["strClientIssue"]);
        string strFacilitiesIssue = Convert.ToString(drCriteria["strFacilitiesIssue"]);
        bool? Task_Complete = null;
        if (drCriteria["Task_Complete"] != DBNull.Value)
            Task_Complete = Convert.ToBoolean(drCriteria["Task_Complete"]);

        #endregion

        #region "Bind Grid"

        DataSet dsManagement = ERIMS.DAL.clsManagement.ManagementSearch(strCompany, strCity, strCounty, strCameraNumber, decCost, decLocation, decState, decRegion, decCameraType, strClientIssue,
            strFacilitiesIssue, Date_Scheduled_From, Date_Scheduled_To, Date_Complete_From, Date_Complete_To, CR_Approved_From, CR_Approved_To, decLocation_Code, _SortBy, _SortOrder, PageNumber, PageSize, Task_Complete);

        // set values for paging control,so it shows values as needed.
        DataTable dtManagement = dsManagement.Tables[0];
        ctrlPageProperty.TotalRecords = (dsManagement.Tables.Count >= 2) ? Convert.ToInt32(dsManagement.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (dsManagement.Tables.Count >= 2) ? Convert.ToInt32(dsManagement.Tables[1].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dsManagement.Tables[0].Rows.Count;
        ctrlPageProperty.SetPageNumbers();
        if (dsManagement.Tables[0] == null || dsManagement.Tables[0].Rows.Count == 0)
        {
            gvManagement.Width = 999;
            dvSearchResult.Style["overflow-x"] = "none";
            btnSaveToExcel.Visible = false;
        }
        else
        {
            gvManagement.Width = 999;
            dvSearchResult.Style["overflow-x"] = "none";
            btnSaveToExcel.Visible = true;
        }
        // bind the grid.
        gvManagement.DataSource = dtManagement;
        gvManagement.DataBind();
        // set record numbers retrieved
        lblNumber.Text = (dsManagement.Tables.Count >= 2) ? Convert.ToString(dsManagement.Tables[1].Rows[0][0]) : "0";

        pnlSearchFilter.Visible = false;
        pnlSearchResult.Visible = true;
        ctrlPageProperty.FindControl("drpRecords").Focus();
        #endregion
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        if (_IsCriteria == true)
            BindGridByCriteria(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        else
            BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }

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
        foreach (DataControlField field in gvManagement.Columns)
        {
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvManagement.Columns.IndexOf(field);
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
        Int32 iCol = GetSortColumnIndex(_SortBy);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder = _SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

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
    /// SAVE FILE
    /// </summary>
    /// <param name="dtManagement"></param>
    /// <param name="name"></param>
    private void ExportToSpreadsheet(DataTable dtManagement, string name)
    {
        //Create HTML for the report and wirte into HTML Write object
        StringBuilder strHTML = new StringBuilder();
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        //Add Header HTML
        strHTML.Append("<table  cellpadding='0' cellspacing='0' width='100%' border='1'>");
        strHTML.Append("<tr align='right' valign='bottom' style='font-weight: bold;'>");

        strHTML.Append("<td align='left'>Company</td>");
        strHTML.Append("<td align='left'>Camera Number</td>'");
        strHTML.Append("<td align='left'>Camera Type</td>");
        strHTML.Append("<td align='left'>Date Scheduled</td>");
        strHTML.Append("<td align='left'>Date Complete</td>");
        strHTML.Append("<td align='left'>Task Complete</td>");

        strHTML.Append("</tr>");

        if (dtManagement.Rows.Count > 0)
        {
            for (int i = 0; i < dtManagement.Rows.Count; i++)
            {
                strHTML.Append("<tr align='left'>");
                strHTML.Append("<td>" + Convert.ToString(dtManagement.Rows[i]["Company"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtManagement.Rows[i]["Camera_Number"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtManagement.Rows[i]["FK_LU_Camera_Type"]) + "</td>");
                strHTML.Append("<td>" + clsGeneral.FormatDBNullDateToDisplay(dtManagement.Rows[i]["Date_Scheduled"]) + "</td>");
                strHTML.Append("<td>" + clsGeneral.FormatDBNullDateToDisplay(dtManagement.Rows[i]["Date_Complete"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtManagement.Rows[i]["Task_Complete"]) + "</td>");
                strHTML.Append("</tr>");
            }
        }
        else
        {
            //Add No record found line for year
            strHTML.Append("<tr><td colspan='6' align='center'>No Record Found</td></tr>");
        }
        strHTML.Append("</table>");

        //Write HTML in to HtmlWriter
        htmlWrite.WriteLine(strHTML.ToString());

        HttpContext context = HttpContext.Current;
        context.Response.Clear();

        context.Response.Write(stringWrite);

        context.Response.ContentType = "application/ms-excel";
        context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name);
        context.Response.End();
    }

    #endregion

    #region "Grid Events"

    /// <summary>
    /// Handles event when row is created for Incident grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManagement_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != _SortBy)
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
                e.Row.Cells[1].Controls.Add(sortImage);
            }
        }
    }

    /// <summary>
    /// Handles event when row header link is clicked for sorting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManagement_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        _SortOrder = (_SortBy == e.SortExpression) ? (_SortOrder == "asc" ? "desc" : "asc") : "asc";
        _SortBy = e.SortExpression;
        GetPage();
    }

    /// <summary>
    /// Handle gvCargoClaim Row Data Bound events
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManagement_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //((LinkButton)e.Row.Cells[0].FindControl("btnEdit")).Visible = (App_Access != AccessType.View);
            //((LinkButton)e.Row.Cells[0].FindControl("btnDelete")).Visible = (App_Access == AccessType.Delete || App_Access == AccessType.Administrative_Access);
            //((LinkButton)e.Row.Cells[0].FindControl("lnkAddTo")).Visible = (App_Access != AccessType.View);
        }
    }

    /// <summary>
    /// Handles event when links are clicked in the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManagement_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditManagement")
        {
            decimal PK_Incident_ID = Convert.ToDecimal(e.CommandArgument);
            /////When Edit Record in User then Insert in Incident_Edit Table Record and Incident is locked
            //clsClaim_Edit objEdit = new clsClaim_Edit();
            //objEdit.FK_Claim = PK_Claim_ID;
            //objEdit.FK_Security_ID = Convert.ToDecimal(clsSession.UserID);
            //objEdit.Insert();    
            Response.Redirect("Management.aspx?id=" + Encryption.Encrypt(Convert.ToString(e.CommandArgument)) + "&mode=edit", true);
        }
        else if (e.CommandName == "ViewManagement")
        {
            Response.Redirect("Management.aspx?id=" + Encryption.Encrypt(Convert.ToString(e.CommandArgument)) + "&mode=view", true);
        }
        else if (e.CommandName == "DeleteManagement")
        {
            ERIMS.DAL.clsManagement.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        }

    }

    #endregion

    #region "Events"
    /// <summary>
    /// search record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        _IsCriteria = false;
        //Set Soryby,Sortorder and Page size filed
        _SortBy = "Camera_Number";
        _SortOrder = "asc";
        ctrlPageProperty.PageSize = 25;

        BindGrid(1, ctrlPageProperty.PageSize);
        pnlSearchFilter.Visible = false;
        pnlSearchResult.Visible = true;
        ctrlPageProperty.FindControl("drpRecords").Focus();
    }

    /// <summary>
    /// Handles Search Again button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchAgain_Click(object sender, EventArgs e)
    {
        _IsCriteria = false;
        foreach (Control ctrl in pnlSearchFilter.Controls)
        {
            if (ctrl.GetType() == typeof(TextBox))
            {
                ((TextBox)ctrl).Text = "";
            }
        }


        drpLocation.SelectedIndex = 0;
        //drpState.SelectedIndex = 0;
        //drpRegion.SelectedIndex = 0;
        drpCamera_Type.SelectedIndex = 0;
        drpClient_Issue.SelectedIndex = 0;
        drpFacilities_Issue.SelectedIndex = 0;
        // show search filter panel
        pnlSearchResult.Visible = false;
        pnlSearchFilter.Visible = true;
        rdbTaskComplete.ClearSelection();
        // Check User Rights
        drpLocation.Focus();

    }

    /// <summary>
    /// Handle Add new Incident Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (pnlSearchFilter.Visible)
        {
            Session.Remove("ManagementCriteria");
        }
        Response.Redirect("Management.aspx?mode=add");

    }

    /// <summary>
    /// Save Excel file for Incident Search record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveToExcel_Click(object sender, EventArgs e)
    {

        DataTable dtcriteria = (DataTable)Session["ManagementCriteria"];
        DataRow drCriteria = dtcriteria.Rows[0];

        #region "Declaration"

        decimal? decState = Convert.ToDecimal(drCriteria["decState"]);
        decimal? decLocation = Convert.ToDecimal(drCriteria["decLocation"]);
        decimal? decRegion = Convert.ToDecimal(drCriteria["decRegion"]);
        decimal? decCameraType = Convert.ToDecimal(drCriteria["decCameraType"]);
        decimal? decCost = Convert.ToDecimal(drCriteria["decCost"]);
        decimal? decLocation_Code = null;
        if (drCriteria["decLocation_Code"] != DBNull.Value)
            decLocation_Code = Convert.ToDecimal(drCriteria["decLocation_Code"]);
        DateTime? Date_Scheduled_From = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Date_Scheduled_From"]));
        DateTime? Date_Scheduled_To = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Date_Scheduled_To"]));
        DateTime? Date_Complete_From = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Date_Complete_From"]));
        DateTime? Date_Complete_To = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Date_Complete_To"]));
        DateTime? CR_Approved_From = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["CR_Approved_From"]));
        DateTime? CR_Approved_To = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["CR_Approved_To"]));

        string strCompany = Convert.ToString(drCriteria["strCompany"]);
        string strCity = Convert.ToString(drCriteria["strCity"]);
        string strCounty = Convert.ToString(drCriteria["strCounty"]);
        string strCameraNumber = Convert.ToString(drCriteria["strCameraNumber"]);
        string strClientIssue = Convert.ToString(drCriteria["strClientIssue"]);
        string strFacilitiesIssue = Convert.ToString(drCriteria["strFacilitiesIssue"]);
        bool? Task_Complete = null;
        if (drCriteria["Task_Complete"] != DBNull.Value)
            Task_Complete = Convert.ToBoolean(drCriteria["Task_Complete"]);

        #endregion

        // selects records depending on paging criteria and search values.
        DataSet dsManagement = ERIMS.DAL.clsManagement.ManagementSearch(strCompany, strCity, strCounty, strCameraNumber, decCost, decLocation, decState, decRegion, decCameraType, strClientIssue,
            strFacilitiesIssue, Date_Scheduled_From, Date_Scheduled_To, Date_Complete_From, Date_Complete_To, CR_Approved_From, CR_Approved_To, decLocation_Code, _SortBy, _SortOrder, 1, ctrlPageProperty.TotalRecords, Task_Complete);
        DataTable dtManagement = dsManagement.Tables[0];
        ExportToSpreadsheet(dtManagement, "ManagementSearch.xls");

    }

    #endregion
}