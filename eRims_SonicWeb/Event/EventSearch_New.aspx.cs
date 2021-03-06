﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using ERIMS.DAL;

public partial class Event_EventSearch_New : clsBasePage
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

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Incident
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Incident"]);
        }
        set { ViewState["PK_Incident"] = value; }
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
            PK_Incident = clsGeneral.GetQueryStringID(Request.QueryString["iid"]);
            BindDropDownList();
            // Check User Rights
            txtEventNumber.Focus();
            ctrlPageProperty.PageSize = clsSession.NumberOfSearchRows;
            _SortBy = "Event_Start_Date";
            _SortOrder = "desc";

            if (!string.IsNullOrEmpty(Request["Event"]))
            {
                if (Session["EventCriteria"] != null)
                {
                    _IsCriteria = true;
                    BindGridByCriteria(1, clsSession.NumberOfSearchRows);
                }
            }

            if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["loc"])))//Any events added from Exposure link will set Event.[Sonic_Event] =’Yes’ Issue Mail Sub: ACI - Sonic bugs
            {
                clsGeneral.SetDropdownValue(drpLocation, Encryption.Decrypt(Convert.ToString(Request.QueryString["loc"])), true);
                //rdoStatus_Sonic.SelectedValue = "A";
                btnSearch_Click(null, null);
            }

            //if (clsSession.IsACIUser)
            //    btnAdd.Visible = false;
        }

        //btnAdd.Visible = (App_Access != AccessType.View);
        txtEventNumber.Focus();
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        _IsCriteria = false;
        //Set Soryby,Sortorder and Page size filed
        _SortBy = "Event_Start_Date";
        _SortOrder = "desc";
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
        drpEventType.SelectedIndex = 0;
        //drpAlarmType.SelectedIndex = 0;
        //drpCameraType.SelectedIndex = 0;

        // show search filter panel
        pnlSearchResult.Visible = false;
        pnlSearchFilter.Visible = true;

        // Check User Rights
        //btnAdd.Visible = App_Access == AccessType.Administrative_Access;
        if (!clsSession.IsACIUser)
            rdoSonic_Event.SelectedValue = "A";
        //rdoIs_Actionable.SelectedValue = "Y";
        //rdoStatus_Sonic.SelectedValue = "O";
        txtEventNumber.Focus();
    }

    /// <summary>
    /// Save Excel file for Case Search record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveToExcel_Click(object sender, EventArgs e)
    {
        #region "Variable"

        DataTable dtcriteria = (DataTable)Session["EventCriteria"];
        DataRow drCriteria = dtcriteria.Rows[0];

        decimal? decLocation = 0, decEventType = 0;

        string strEventNumber = null, strCameraNumber = null, strCameraName = null, strStatus = null, strACIEventID = null, strSonic_Event = null, strIs_Actionable = null;
        DateTime? EventDateFrom = null, EventDateTo = null;

        strEventNumber = Convert.ToString(drCriteria["strEventNumber"]);
        strCameraNumber = Convert.ToString(drCriteria["strCameraNumber"]);
        strCameraName = Convert.ToString(drCriteria["strCameraName"]);
        strStatus = Convert.ToString(drCriteria["strStatus"]);

        if (Convert.ToDecimal(drCriteria["decLocation"]) != 0) decLocation = Convert.ToDecimal(drCriteria["decLocation"]);
        if (Convert.ToDecimal(drCriteria["decEventType"]) != 0) decEventType = Convert.ToDecimal(drCriteria["decEventType"]);
        
        strACIEventID = Convert.ToString(drCriteria["strACIEventID"]);
        EventDateFrom = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["EventDateFrom"]));
        EventDateTo = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["EventDateTo"]));
        strSonic_Event = Convert.ToString(drCriteria["strSonic_Event"]);
        strIs_Actionable = Convert.ToString(drCriteria["strIs_Actionable"]);


        #endregion

        // selects records depending on paging criteria and search values.
        DataSet dsEvent = clsEvent.EventSearch_New(strEventNumber, strCameraNumber, decLocation, decEventType, strCameraName, strStatus, strACIEventID, EventDateFrom, EventDateTo, strSonic_Event, strIs_Actionable, _SortBy, _SortOrder, 1, ctrlPageProperty.TotalRecords);
        DataTable dtEvent = dsEvent.Tables[0];

        ExportToSpreadsheet(dtEvent, "EventSearch.xls");

    }

    /// <summary>
    /// Handle Add new Event Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (pnlSearchFilter.Visible)
        {
            Session.Remove("EventCriteria");
        }
        Response.Redirect("Event_New.aspx?mode=add");

    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind DropDownList
    /// </summary>
    private void BindDropDownList()
    {
        //ComboHelper.FillState(new DropDownList[] { drpState }, true);
        //ComboHelper.FillEventType(new DropDownList[] { drpEventType }, true);
        FillEventType(new DropDownList[] { drpEventType }, true, "ALL");
        //ComboHelper.FillLU_Camera_Type(new DropDownList[] { drpCameraType }, true);
        //ComboHelper.FillLU_Alarm_Type(new DropDownList[] { drpAlarmType }, true);
        //ComboHelper.FillLocation(new DropDownList[] { drpLocation }, true);
        ComboHelper.FillLocationByACIUser_New((new DropDownList[] { drpLocation }), Convert.ToDecimal(clsSession.UserID), true);

        //if (clsSession.IsACIUser)
        //{
        //    rdoSonic_Event.Items.Remove(rdoSonic_Event.Items.FindByValue("Y"));
        //    rdoSonic_Event.Items.Remove(rdoSonic_Event.Items.FindByValue("A"));
        //    rdoSonic_Event.SelectedValue = "N";
        //}
        
    }

    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        #region "Variable"

        decimal? decLocation = 0, decEventType = 0;

        string strEventNumber = null, strCameraNumber = null, strCameraName = null, strStatus = null, strACIEventID = null, strSonic_Event = null, strIs_Actionable = null;
        DateTime? EventDateFrom = null, EventDateTo = null;

        if (drpLocation.SelectedIndex > 0) decLocation = Convert.ToDecimal(drpLocation.SelectedValue);
        if (drpEventType.SelectedIndex > 0) decEventType = Convert.ToDecimal(drpEventType.SelectedValue);
        if (!string.IsNullOrEmpty(txtEventNumber.Text)) strEventNumber = txtEventNumber.Text.Trim().Replace("'", "''");
        //if (!string.IsNullOrEmpty(txtCameraNumber.Text)) strCameraNumber = txtCameraNumber.Text.Trim().Replace("'", "''");
        //if (!string.IsNullOrEmpty(txtCameraName.Text)) strCameraName = txtCameraName.Text.Trim().Replace("'", "''");
        //strStatus = rdoStatus_Sonic.SelectedValue;
        if (!string.IsNullOrEmpty(txtACI_EventID.Text)) strACIEventID = txtACI_EventID.Text.Trim().Replace("'", "''");
        if (!string.IsNullOrEmpty(txtEvent_Date_From.Text)) EventDateFrom = Convert.ToDateTime(txtEvent_Date_From.Text);
        if (!string.IsNullOrEmpty(txtEvent_Date_To.Text)) EventDateTo = Convert.ToDateTime(txtEvent_Date_To.Text);
        strSonic_Event = rdoSonic_Event.SelectedValue;
        //strIs_Actionable = rdoIs_Actionable.SelectedValue;

        #endregion

        // selects records depending on paging criteria and search values.
        DataSet dsEvent = clsEvent.EventSearch_New(strEventNumber, strCameraNumber, decLocation, decEventType, strCameraName, strStatus, strACIEventID, EventDateFrom, EventDateTo, strSonic_Event, strIs_Actionable, _SortBy, _SortOrder, PageNumber, PageSize);
        DataTable dtEvent = dsEvent.Tables[0];

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (dsEvent.Tables.Count >= 2) ? Convert.ToInt32(dsEvent.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (dsEvent.Tables.Count >= 2) ? Convert.ToInt32(dsEvent.Tables[1].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dsEvent.Tables[0].Rows.Count;
        ctrlPageProperty.SetPageNumbers();

        if (dsEvent.Tables[0] == null || dsEvent.Tables[0].Rows.Count == 0)
        {
            gvEvent.Width = 999;
            dvSearchResult.Style["overflow-x"] = "none";
            btnSaveToExcel.Visible = false;
        }
        else
        {
            gvEvent.Width = 1130;
            dvSearchResult.Style["overflow-x"] = "scroll";
            btnSaveToExcel.Visible = true;
        }

        // bind the grid.
        gvEvent.DataSource = dtEvent;
        gvEvent.DataBind();

        // set record numbers retrieved
        lblNumber.Text = (dsEvent.Tables.Count >= 2) ? Convert.ToString(dsEvent.Tables[1].Rows[0][0]) : "0";

        #region "Save Criteria"

        DataTable dtCriteria = new DataTable();
        dtCriteria.Columns.Add("strEventNumber", typeof(string));
        dtCriteria.Columns.Add("strCameraNumber", typeof(string));
        dtCriteria.Columns.Add("strCameraName", typeof(string));

        dtCriteria.Columns.Add("decLocation", typeof(decimal));
        dtCriteria.Columns.Add("decEventType", typeof(decimal));
        dtCriteria.Columns.Add("strStatus", typeof(string));

        dtCriteria.Columns.Add("strACIEventID", typeof(string));
        dtCriteria.Columns.Add("EventDateFrom", typeof(string));
        dtCriteria.Columns.Add("EventDateTo", typeof(string));
        dtCriteria.Columns.Add("strSonic_Event", typeof(string));
        dtCriteria.Columns.Add("strIs_Actionable", typeof(string));
       
        DataRow drCriteria = dtCriteria.NewRow();
        drCriteria["strEventNumber"] = strEventNumber;
        drCriteria["strCameraNumber"] = strCameraNumber;
        
        drCriteria["decLocation"] = decLocation;
        drCriteria["decEventType"] = decEventType;
        drCriteria["strCameraName"] = strCameraName;
        drCriteria["strStatus"] = strStatus;
        drCriteria["strACIEventID"] = strACIEventID;
        drCriteria["EventDateFrom"] = EventDateFrom;
        drCriteria["EventDateTo"] = EventDateTo;
        drCriteria["strSonic_Event"] = strSonic_Event;
        drCriteria["strIs_Actionable"] = strIs_Actionable;
        dtCriteria.Rows.Add(drCriteria);
        Session["EventCriteria"] = dtCriteria;

        #endregion
    }

    /// <summary>
    /// Bind Grid By Criteria
    /// </summary>
    /// <param name="PageNumber"></param>
    /// <param name="PageSize"></param>
    private void BindGridByCriteria(int PageNumber, int PageSize)
    {
        DataTable dtcriteria = (DataTable)Session["EventCriteria"];
        DataRow drCriteria = dtcriteria.Rows[0];

        #region "Variable"

       decimal? decLocation = 0, decEventType = 0;

       string strEventNumber = null, strCameraNumber = null, strCameraName = null, strStatus = null, strACIEventID = null, strSonic_Event = null, strIs_Actionable = null;
       DateTime? EventDateFrom = null, EventDateTo = null;

        strEventNumber = Convert.ToString(drCriteria["strEventNumber"]);
        strCameraNumber = Convert.ToString(drCriteria["strCameraNumber"]);
        strCameraName = Convert.ToString(drCriteria["strCameraName"]);
        strStatus = Convert.ToString(drCriteria["strStatus"]);

        if (Convert.ToDecimal(drCriteria["decLocation"]) != 0) decLocation = Convert.ToDecimal(drCriteria["decLocation"]);
        if (Convert.ToDecimal(drCriteria["decEventType"]) != 0) decEventType = Convert.ToDecimal(drCriteria["decEventType"]);

        strACIEventID = Convert.ToString(drCriteria["strACIEventID"]);
        EventDateFrom = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["EventDateFrom"]));
        EventDateTo = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["EventDateTo"]));
        strSonic_Event = Convert.ToString(drCriteria["strSonic_Event"]);
        strIs_Actionable = Convert.ToString(drCriteria["strIs_Actionable"]);
        
        #endregion

        #region "Bind Grid"

        DataSet dsEvent = clsEvent.EventSearch_New(strEventNumber, strCameraNumber, decLocation, decEventType, strCameraName, strStatus, strACIEventID, EventDateFrom, EventDateTo, strSonic_Event, strIs_Actionable, _SortBy, _SortOrder, PageNumber, PageSize);
        
        DataTable dtEvent = dsEvent.Tables[0];

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (dsEvent.Tables.Count >= 2) ? Convert.ToInt32(dsEvent.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (dsEvent.Tables.Count >= 2) ? Convert.ToInt32(dsEvent.Tables[1].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dsEvent.Tables[0].Rows.Count;
        ctrlPageProperty.SetPageNumbers();
        if (dsEvent.Tables[0] == null || dsEvent.Tables[0].Rows.Count == 0)
        {
            gvEvent.Width = 999;
            dvSearchResult.Style["overflow-x"] = "none";
            btnSaveToExcel.Visible = false;
        }
        else
        {
            gvEvent.Width = 1600;
            dvSearchResult.Style["overflow-x"] = "scroll";
            btnSaveToExcel.Visible = true;
        }
        // bind the grid.
        gvEvent.DataSource = dtEvent;
        gvEvent.DataBind();
        // set record numbers retrieved
        lblNumber.Text = (dsEvent.Tables.Count >= 2) ? Convert.ToString(dsEvent.Tables[1].Rows[0][0]) : "0";

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
        foreach (DataControlField field in gvEvent.Columns)
        {
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvEvent.Columns.IndexOf(field);
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
    /// 
    /// </summary>
    /// <param name="dtEvent"></param>
    /// <param name="name"></param>
    private void ExportToSpreadsheet(DataTable dtEvent, string name)
    {
        //Create HTML for the report and write into HTML Write object
        StringBuilder strHTML = new StringBuilder();
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        //Add Header HTML
        strHTML.Append("<table  cellpadding='0' cellspacing='0' width='100%' border='1'>");
        strHTML.Append("<tr align='right' valign='bottom' style='font-weight: bold;'>");

        strHTML.Append("<td align='left'>Event Number</td>");
        strHTML.Append("<td align='left'>ACI Event ID</td>");
        strHTML.Append("<td align='left'>Event Start Date</td>");
        strHTML.Append("<td align='left'>DBA</td>");
        strHTML.Append("<td align='left'>Location Code</td>");
        strHTML.Append("<td align='left'>Event Status</td>");
        strHTML.Append("<td align='left'>Event Type</td>");

        strHTML.Append("</tr>");

        if (dtEvent.Rows.Count > 0)
        {
            for (int i = 0; i < dtEvent.Rows.Count; i++)
            {
                strHTML.Append("<tr align='left'>");
                strHTML.Append("<td>" + Convert.ToString(dtEvent.Rows[i]["Event_Number"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtEvent.Rows[i]["ACI_EventID"]) + "</td>");
                strHTML.Append("<td>" + clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[i]["Event_Start_Date"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtEvent.Rows[i]["FK_LU_Location"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtEvent.Rows[i]["Location_Code"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtEvent.Rows[i]["Event_Status"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtEvent.Rows[i]["Event_Type"]) + "</td>");
                strHTML.Append("</td></tr>");
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


    /// <summary>
    /// Fill Event Type
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillEventType(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, string ReportedBy)
    {
        DataSet dsData = clsLU_Event_Type.SelectAll();

        if (ReportedBy == "ACI")
        {
            dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y' AND Is_Actionable = 'Y' AND Fld_Desc <> 'FROI Event/Other' AND Fld_Desc <> 'Vehicle Damage' AND Fld_Desc <> 'Slip and Fall'";
        }
        else if (ReportedBy == "Sonic")
        {
            dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y' AND Is_Actionable = 'Y' AND Fld_Desc <> 'FROI Event/Other' AND Fld_Desc <> 'Friendly Voice Down' AND Fld_Desc <> 'Stern voice Down' AND Fld_Desc <> ' Cleaning Crew Not Wearing Vests' AND Fld_Desc <> 'Staff Not Calling In'";
        }
        else
        {
            dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y' AND Fld_Desc <> 'Staff/Cleaner/Delivery on site'";
        }

        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Event_Type";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
        }
    }

    #endregion

    #region "Grid Events"

    /// <summary>
    /// Handles event when row is created for Case grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEvent_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void gvEvent_Sorting(object sender, GridViewSortEventArgs e)
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
    protected void gvEvent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnOpen = (LinkButton)e.Row.Cells[0].FindControl("btnOpen");
            LinkButton btnDelete = (LinkButton)e.Row.Cells[0].FindControl("btnDelete");
            LinkButton btnSelect = (LinkButton)e.Row.Cells[0].FindControl("btnSelect");
            LinkButton btnEdit = (LinkButton)e.Row.Cells[0].FindControl("btnEdit");
            //if (PK_Incident > 0)
            //{
            //    btnOpen.Visible = false;
            //    btnDelete.Visible = false;
            //    btnSelect.Visible = true;
            //}
            //else
            //{
            //    btnOpen.Visible = (App_Access != AccessType.View);
            //    btnDelete.Visible = (App_Access == AccessType.Delete || App_Access == AccessType.Administrative_Access);
            //    btnSelect.Visible = false;
            //}

            string Sonic_Event = DataBinder.Eval(e.Row.DataItem, "Sonic_Event").ToString();

            btnOpen.Visible = true;
            //btnDelete.Visible = true;
            //btnEdit.Visible 
            btnDelete.Visible =  (clsSession.IsACIUser && (Sonic_Event != "Y") || !clsSession.IsACIUser && (Sonic_Event == "Y"));
            btnSelect.Visible = false;
        }
    }

    /// <summary>
    /// Handles event when links are clicked in the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEvent_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "OpenEvent")
        {
            string[] strCommandArgument = e.CommandArgument.ToString().Split(',');
            decimal FK_Incident = Convert.ToDecimal(strCommandArgument[1]);
            decimal PK_Event = Convert.ToDecimal(strCommandArgument[0]);
            Response.Redirect("Event_New.aspx?iid=" + Encryption.Encrypt(Convert.ToString(FK_Incident)) + "&eid=" + Encryption.Encrypt(Convert.ToString(PK_Event)) + "&mode=viewonly", true);
        }
        else if (e.CommandName == "EditEvent")
        {
            string[] strCommandArgument = e.CommandArgument.ToString().Split(',');
            decimal FK_Incident = Convert.ToDecimal(strCommandArgument[1]);
            decimal PK_Event = Convert.ToDecimal(strCommandArgument[0]);
            Response.Redirect("Event_New.aspx?iid=" + Encryption.Encrypt(Convert.ToString(FK_Incident)) + "&eid=" + Encryption.Encrypt(Convert.ToString(PK_Event)) + "&mode=edit", true);
        }
       else if (e.CommandName == "SelectEvent")
       {
            string[] strCommandArgument = e.CommandArgument.ToString().Split(',');
            decimal FK_Incident = Convert.ToDecimal(strCommandArgument[1]);
            decimal PK_Event = Convert.ToDecimal(strCommandArgument[0]);
            if (PK_Incident > 0)
            {
                clsEvent objEvent = new clsEvent(PK_Event);
                objEvent.FK_Incident = PK_Incident;
                objEvent.Update_Date = DateTime.Now;
                objEvent.Updated_By = clsSession.UserID;
                objEvent.Update();
                Response.Redirect("../Event/Event_Initial.aspx?iid=" + Encryption.Encrypt(PK_Incident.ToString()));
            }
        }
        else if (e.CommandName == "DeleteEvent")
        {
            string[] strCommandArgument = e.CommandArgument.ToString().Split(',');
            //decimal FK_Incident = Convert.ToDecimal(strCommandArgument[1]);
            decimal PK_Event = Convert.ToDecimal(strCommandArgument[0]);
            clsEvent.IsValidToDelete(Convert.ToDecimal(PK_Event));
            BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        }
    }

    #endregion
    protected void rdoSonic_Event_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoSonic_Event.SelectedValue == "Y")
        {
            FillEventType(new DropDownList[] { drpEventType }, true, "Sonic");
        }
        else if (rdoSonic_Event.SelectedValue == "N")
        {
            FillEventType(new DropDownList[] { drpEventType }, true, "ACI");
        }
        else
        {
            FillEventType(new DropDownList[] { drpEventType }, true, "ALL");
        }
    }
}