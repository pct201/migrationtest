using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using ERIMS.DAL;

public partial class Event_Event_VideoRequestSearch : clsBasePage
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
    public decimal PK_Event_Video_Tracking_Request
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Event_Video_Tracking_Request"]);
        }
        set { ViewState["PK_Event_Video_Tracking_Request"] = value; }
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
            PK_Event_Video_Tracking_Request = clsGeneral.GetQueryStringID(Request.QueryString["iid"]);
            BindDropDownList();
            // Check User Rights
            txtRequest_Number.Focus();
            ctrlPageProperty.PageSize = clsSession.NumberOfSearchRows;
            _SortBy = "Date_of_Event";
            _SortOrder = "desc";

            if (!string.IsNullOrEmpty(Request["Event"]))
            {
                if (Session["VideoCriteria"] != null)
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
        txtRequest_Number.Focus();
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
        _SortBy = "Date_of_Event";
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
        drpRequestType.SelectedIndex = 0;
        drpStatus.SelectedIndex = 0;
        // show search filter panel
        pnlSearchResult.Visible = false;
        pnlSearchFilter.Visible = true;
        
        txtRequest_Number.Focus();
    }

    /// <summary>
    /// Save Excel file for Case Search record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveToExcel_Click(object sender, EventArgs e)
    {
        #region "Variable"

        DataTable dtcriteria = (DataTable)Session["VideoCriteria"];
        DataRow drCriteria = dtcriteria.Rows[0];

        decimal? decLocation = 0, decStatus = 0;

        string strRequestNumber = null, strRequest_Type = null;
        DateTime? EventDateFrom = null, EventDateTo = null;

        if (Convert.ToDecimal(drCriteria["decLocation"]) != 0) decLocation = Convert.ToDecimal(drCriteria["decLocation"]);
        strRequestNumber = Convert.ToString(drCriteria["strRequestNumber"]);
        strRequest_Type = Convert.ToString(drCriteria["strRequest_Type"]);
        if (Convert.ToDecimal(drCriteria["decStatus"]) != 0) decStatus = Convert.ToDecimal(drCriteria["strStatus"]);
        EventDateFrom = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["EventDateFrom"]));
        EventDateTo = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["EventDateTo"]));

        #endregion

        // selects records depending on paging criteria and search values.
        DataSet dsVideo = clsEvent_Video_Tracking_Request.Event_Video_Tracking_RequestSearch(strRequestNumber, strRequest_Type, decLocation, decStatus, EventDateFrom, EventDateTo, _SortBy, _SortOrder, 1, ctrlPageProperty.TotalRecords);
        DataTable dtVideo = dsVideo.Tables[0];

        ExportToSpreadsheet(dtVideo, "VideoSearch.xls");

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
            Session.Remove("VideoCriteria");
        }
        Response.Redirect("ACI_Video_Request.aspx?mode=add&rtype=3rd");

    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind DropDownList
    /// </summary>
    private void BindDropDownList()
    {
        ComboHelper.FillLocationByACIUser_New((new DropDownList[] { drpLocation }), Convert.ToDecimal(clsSession.UserID), true);
        ComboHelper.FillVideoRequestType((new DropDownList[] { drpRequestType }), true);
        ComboHelper.FillVideoRequestStatus((new DropDownList[] { drpStatus }), true);
    }

    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        #region "Variable"

        decimal? decLocation = 0, decStatus = 0;

        string strRequestNumber = null, strRequest_Type = null;
        DateTime? EventDateFrom = null, EventDateTo = null;

        if (drpLocation.SelectedIndex > 0) decLocation = Convert.ToDecimal(drpLocation.SelectedValue);
        if (!string.IsNullOrEmpty(txtRequest_Number.Text)) strRequestNumber = txtRequest_Number.Text.Trim().Replace("'", "''");
        if (drpRequestType.SelectedIndex > 0) strRequest_Type = drpRequestType.SelectedValue.ToString();
        if (drpStatus.SelectedIndex > 0) decStatus =  Convert.ToDecimal(drpStatus.SelectedValue);
        if (!string.IsNullOrEmpty(txtEvent_Date_From.Text)) EventDateFrom = Convert.ToDateTime(txtEvent_Date_From.Text);
        if (!string.IsNullOrEmpty(txtEvent_Date_To.Text)) EventDateTo = Convert.ToDateTime(txtEvent_Date_To.Text);

        #endregion

        // selects records depending on paging criteria and search values.
        DataSet dsVideo = clsEvent_Video_Tracking_Request.Event_Video_Tracking_RequestSearch(strRequestNumber, strRequest_Type, decLocation, decStatus, EventDateFrom, EventDateTo, _SortBy, _SortOrder, PageNumber, PageSize);
        DataTable dtVideo = dsVideo.Tables[0];

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (dsVideo.Tables.Count >= 2) ? Convert.ToInt32(dsVideo.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (dsVideo.Tables.Count >= 2) ? Convert.ToInt32(dsVideo.Tables[1].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dsVideo.Tables[0].Rows.Count;
        ctrlPageProperty.SetPageNumbers();

        if (dsVideo.Tables[0] == null || dsVideo.Tables[0].Rows.Count == 0)
        {
            gvVideo.Width = 999;
            dvSearchResult.Style["overflow-x"] = "none";
            btnSaveToExcel.Visible = false;
        }
        else
        {
            gvVideo.Width = 1130;
            dvSearchResult.Style["overflow-x"] = "scroll";
            btnSaveToExcel.Visible = true;
        }

        // bind the grid.
        gvVideo.DataSource = dtVideo;
        gvVideo.DataBind();

        // set record numbers retrieved
        lblNumber.Text = (dsVideo.Tables.Count >= 2) ? Convert.ToString(dsVideo.Tables[1].Rows[0][0]) : "0";

        #region "Save Criteria"

        DataTable dtCriteria = new DataTable();
        dtCriteria.Columns.Add("strRequestNumber", typeof(string));
        dtCriteria.Columns.Add("strRequest_Type", typeof(string));
        
        dtCriteria.Columns.Add("decStatus", typeof(decimal));
        dtCriteria.Columns.Add("decLocation", typeof(decimal));

        dtCriteria.Columns.Add("EventDateFrom", typeof(string));
        dtCriteria.Columns.Add("EventDateTo", typeof(string));

        DataRow drCriteria = dtCriteria.NewRow();
        drCriteria["strRequestNumber"] = strRequestNumber;
        drCriteria["strRequest_Type"] = strRequest_Type;
        drCriteria["decStatus"] = decStatus;
        drCriteria["decLocation"] = decLocation;
        drCriteria["EventDateFrom"] = EventDateFrom;
        drCriteria["EventDateTo"] = EventDateTo;
        dtCriteria.Rows.Add(drCriteria);
        Session["VideoCriteria"] = dtCriteria;

        #endregion
    }

    /// <summary>
    /// Bind Grid By Criteria
    /// </summary>
    /// <param name="PageNumber"></param>
    /// <param name="PageSize"></param>
    private void BindGridByCriteria(int PageNumber, int PageSize)
    {
        DataTable dtcriteria = (DataTable)Session["VideoCriteria"];
        DataRow drCriteria = dtcriteria.Rows[0];

        #region "Variable"

        decimal? decLocation = 0, decStatus = 0;

        string strRequestNumber = null, strRequest_Type = null;
        DateTime? EventDateFrom = null, EventDateTo = null;

        if (Convert.ToDecimal(drCriteria["decLocation"]) != 0) decLocation = Convert.ToDecimal(drCriteria["decLocation"]);
        strRequestNumber = Convert.ToString(drCriteria["strRequestNumber"]);
        strRequest_Type = Convert.ToString(drCriteria["strRequest_Type"]);
        if (Convert.ToDecimal(drCriteria["decStatus"]) != 0) decStatus = Convert.ToDecimal(drCriteria["decStatus"]);
        EventDateFrom = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["EventDateFrom"]));
        EventDateTo = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["EventDateTo"]));

        #endregion

        #region "Bind Grid"

        DataSet dsVideo = clsEvent_Video_Tracking_Request.Event_Video_Tracking_RequestSearch(strRequestNumber, strRequest_Type, decLocation, decStatus, EventDateFrom, EventDateTo, _SortBy, _SortOrder, PageNumber, PageSize);

        DataTable dtVideo = dsVideo.Tables[0];

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (dsVideo.Tables.Count >= 2) ? Convert.ToInt32(dsVideo.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (dsVideo.Tables.Count >= 2) ? Convert.ToInt32(dsVideo.Tables[1].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dsVideo.Tables[0].Rows.Count;
        ctrlPageProperty.SetPageNumbers();
        if (dsVideo.Tables[0] == null || dsVideo.Tables[0].Rows.Count == 0)
        {
            gvVideo.Width = 999;
            dvSearchResult.Style["overflow-x"] = "none";
            btnSaveToExcel.Visible = false;
        }
        else
        {
            gvVideo.Width = 1600;
            dvSearchResult.Style["overflow-x"] = "scroll";
            btnSaveToExcel.Visible = true;
        }
        // bind the grid.
        gvVideo.DataSource = dtVideo;
        gvVideo.DataBind();
        // set record numbers retrieved
        lblNumber.Text = (dsVideo.Tables.Count >= 2) ? Convert.ToString(dsVideo.Tables[1].Rows[0][0]) : "0";

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
        foreach (DataControlField field in gvVideo.Columns)
        {
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvVideo.Columns.IndexOf(field);
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
    private void ExportToSpreadsheet(DataTable dtVideo, string name)
    {
        //Create HTML for the report and write into HTML Write object
        StringBuilder strHTML = new StringBuilder();
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        //Add Header HTML
        strHTML.Append("<table  cellpadding='0' cellspacing='0' width='100%' border='1'>");
        strHTML.Append("<tr align='right' valign='bottom' style='font-weight: bold;'>");

        strHTML.Append("<td align='left'>Request Number</td>");
        strHTML.Append("<td align='left'>Request Type</td>");
        strHTML.Append("<td align='left'>Event Date</td>");
        strHTML.Append("<td align='left'>DBA</td>");
        strHTML.Append("<td align='left'>Location Code</td>");
        strHTML.Append("<td align='left'>Reported By</td>");
        strHTML.Append("<td align='left'>Status</td>");

        strHTML.Append("</tr>");

        if (dtVideo.Rows.Count > 0)
        {
            for (int i = 0; i < dtVideo.Rows.Count; i++)
            {
                strHTML.Append("<tr align='left'>");
                strHTML.Append("<td>" + Convert.ToString(dtVideo.Rows[i]["Request_Number"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtVideo.Rows[i]["Request_Type"]) + "</td>");
                strHTML.Append("<td>" + clsGeneral.FormatDBNullDateToDisplay(dtVideo.Rows[i]["Date_of_Event"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtVideo.Rows[i]["FK_LU_Location"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtVideo.Rows[i]["Location_Code"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtVideo.Rows[i]["Requsted_By"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtVideo.Rows[i]["Status"]) + "</td>");
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

    #endregion

    #region "Grid Events"

    /// <summary>
    /// Handles event when row is created for Case grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvVideo_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void gvVideo_Sorting(object sender, GridViewSortEventArgs e)
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
    protected void gvVideo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnOpen = (LinkButton)e.Row.Cells[0].FindControl("btnOpen");
            LinkButton btnDelete = (LinkButton)e.Row.Cells[0].FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Row.Cells[0].FindControl("btnEdit");
            LinkButton btnApprove = (LinkButton)e.Row.Cells[0].FindControl("btnApporve");
            LinkButton btnDeny = (LinkButton)e.Row.Cells[0].FindControl("btnDeny");

            Label lblStatus = (Label)e.Row.Cells[7].FindControl("lblStatus");
            Label lblIS_Legal = (Label)e.Row.Cells[7].FindControl("lblIs_Legal");

            btnApprove.Visible = btnDeny.Visible = lblStatus.Text == "Pending" && lblIS_Legal.Text == "1" ? true : false;

            btnOpen.Visible = true;
            //btnDelete.Visible = btnEdit.Visible = (clsSession.IsACIUser && (Sonic_Event != "Y") || !clsSession.IsACIUser && (Sonic_Event == "Y"));
            btnEdit.Visible = false;
            btnDelete.Visible = false;
        }
    }

    /// <summary>
    /// Handles event when links are clicked in the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvVideo_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "OpenVideo")
        {
            string[] strCommandArgument = e.CommandArgument.ToString().Split(',');
            decimal PK_Event = Convert.ToDecimal(strCommandArgument[1]);
            decimal PK_Event_Video_Tracking_Request = Convert.ToDecimal(strCommandArgument[0]);
            Response.Redirect("ACI_Video_Request.aspx?tid=" + Encryption.Encrypt(Convert.ToString(PK_Event_Video_Tracking_Request)) + "&eid=" + Encryption.Encrypt(Convert.ToString(PK_Event)), true);
        }
        else if (e.CommandName == "EditVideo")
        {
            string[] strCommandArgument = e.CommandArgument.ToString().Split(',');
            decimal PK_Event = Convert.ToDecimal(strCommandArgument[1]);
            decimal PK_Event_Video_Tracking_Request = Convert.ToDecimal(strCommandArgument[0]);
            Response.Redirect("ACI_Video_Request.aspx?tid=" + Encryption.Encrypt(Convert.ToString(PK_Event_Video_Tracking_Request)) + "&eid=" + Encryption.Encrypt(Convert.ToString(PK_Event)), true);
        }
        else if (e.CommandName == "DeleteVideo")
        {
            string[] strCommandArgument = e.CommandArgument.ToString().Split(',');
            decimal PK_Event_Video_Tracking_Request = Convert.ToDecimal(strCommandArgument[0]);
            clsEvent_Video_Tracking_Request.DeleteByPK(PK_Event_Video_Tracking_Request);
            BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        }
        else if (e.CommandName == "ApproveVideo")
        {
            string[] strCommandArgument = e.CommandArgument.ToString().Split(',');
            decimal PK_Event_Video_Tracking_Request = Convert.ToDecimal(strCommandArgument[0]);
            clsEvent_Video_Tracking_Request.Event_Video_Tracking_RequestUpdateStatus(PK_Event_Video_Tracking_Request, "Approved", Convert.ToInt32(clsSession.UserID));
            BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        }
        else if (e.CommandName == "DenyVideo")
        {
            string[] strCommandArgument = e.CommandArgument.ToString().Split(',');
            decimal PK_Event_Video_Tracking_Request = Convert.ToDecimal(strCommandArgument[0]);
            clsEvent_Video_Tracking_Request.Event_Video_Tracking_RequestUpdateStatus(PK_Event_Video_Tracking_Request, "Denied", Convert.ToInt32(clsSession.UserID));
            BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        }
    }

    #endregion
}