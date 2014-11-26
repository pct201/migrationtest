using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using ERIMS.DAL;

public partial class Event_EventSearch : clsBasePage
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
            _SortBy = "Event_Number";
            _SortOrder = "asc";

            if (!string.IsNullOrEmpty(Request["Event"]))
            {
                if (Session["EventCriteria"] != null)
                {
                    _IsCriteria = true;
                    BindGridByCriteria(1, ctrlPageProperty.PageSize);
                }
            }

            if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["loc"])))//Any events added from Exposure link will set Event.[Sonic_Event] =’Yes’ Issue Mail Sub: ACI - Sonic bugs
            {
                clsGeneral.SetDropdownValue(drpLocation, Encryption.Decrypt(Convert.ToString(Request.QueryString["loc"])), true);
                btnSearch_Click(null, null);
            }
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
        //Set Sort by,Sort order and Page size filed
        _SortBy = "Event_Number";
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
        drpEventType.SelectedIndex = 0;
        //drpAlarmType.SelectedIndex = 0;
        //drpCameraType.SelectedIndex = 0;

        // show search filter panel
        pnlSearchResult.Visible = false;
        pnlSearchFilter.Visible = true;

        // Check User Rights
        //btnAdd.Visible = App_Access == AccessType.Administrative_Access;
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

        decimal? decState = 0, decLocation = 0, decEventType = 0, decAlarmType = 0, decCameraType = 0;
        DateTime? Photo_Date_From = null, Photo_Date_To = null, Alarm_Time_From = null, Alarm_Time_To = null, Investigation_Report_Date_From = null, Investigation_Report_Date_To = null,
            Event_Report_Date_From = null, Event_Report_Date_To = null, Date_Opened = null, Event_Occurance_Date = null;
        string strCompany = null, strCity = null, strCountry = null, strEventNumber = null, strCameraNumber = null, strAlarmNumber = null, strOperator = null, strCameraName = null;

        //if (drpState.SelectedIndex > 0) decState = Convert.ToDecimal(drpState.SelectedValue);
        if (drpLocation.SelectedIndex > 0) decLocation = Convert.ToDecimal(drpLocation.SelectedValue);
        if (drpEventType.SelectedIndex > 0) decEventType = Convert.ToDecimal(drpEventType.SelectedValue);
        //if (drpAlarmType.SelectedIndex > 0) decAlarmType = Convert.ToDecimal(drpAlarmType.SelectedValue);
        //if (drpCameraType.SelectedIndex > 0) decCameraType = Convert.ToDecimal(drpCameraType.SelectedValue);

        //if (!string.IsNullOrEmpty(txtPhotoDate.Text)) Photo_Date_From = Convert.ToDateTime(txtPhotoDate.Text);
        //if (!string.IsNullOrEmpty(txtToPhotoDate.Text)) Photo_Date_To = Convert.ToDateTime(txtToPhotoDate.Text);
        //if (!string.IsNullOrEmpty(txtAlarmTime.Text)) Alarm_Time_From = Convert.ToDateTime(txtAlarmTime.Text);
        //if (!string.IsNullOrEmpty(txtToAlarmTime.Text)) Alarm_Time_To = Convert.ToDateTime(txtToAlarmTime.Text);
        if (!string.IsNullOrEmpty(txtInvestigationReportDate.Text)) Investigation_Report_Date_From = Convert.ToDateTime(txtInvestigationReportDate.Text);
        if (!string.IsNullOrEmpty(txtToInvestigationReportDate.Text)) Investigation_Report_Date_To = Convert.ToDateTime(txtToInvestigationReportDate.Text);
        if (!string.IsNullOrEmpty(txtEventReportDate.Text)) Event_Report_Date_From = Convert.ToDateTime(txtEventReportDate.Text);
        if (!string.IsNullOrEmpty(txtToEventReportDate.Text)) Event_Report_Date_To = Convert.ToDateTime(txtToEventReportDate.Text);

        //if (!string.IsNullOrEmpty(txtCompany.Text)) strCompany = txtCompany.Text.Trim().Replace("'", "''");
        //if (!string.IsNullOrEmpty(txtCity.Text)) strCity = txtCity.Text.Trim().Replace("'", "''");
        //if (!string.IsNullOrEmpty(txtCountry.Text)) strCountry = txtCountry.Text.Trim().Replace("'", "''");
        if (!string.IsNullOrEmpty(txtEventNumber.Text)) strEventNumber = txtEventNumber.Text.Trim().Replace("'", "''");
        if (!string.IsNullOrEmpty(txtCameraNumber.Text)) strCameraNumber = txtCameraNumber.Text.Trim().Replace("'", "''");
        //if (!string.IsNullOrEmpty(txtAlarmNumber.Text)) strAlarmNumber = txtAlarmNumber.Text.Trim().Replace("'", "''");
        //if (!string.IsNullOrEmpty(txtOperator.Text)) strOperator = txtOperator.Text.Trim().Replace("'", "''");

        if (!string.IsNullOrEmpty(txtDate_Opened.Text)) Date_Opened = Convert.ToDateTime(txtDate_Opened.Text);
        if (!string.IsNullOrEmpty(txtEvent_Occurance_Date.Text)) Event_Occurance_Date = Convert.ToDateTime(txtEvent_Occurance_Date.Text);

        if (!string.IsNullOrEmpty(txtCameraName.Text)) strCameraName = txtCameraName.Text.Trim().Replace("'", "''");

        #endregion

        // selects records depending on paging criteria and search values.
        DataSet dsEvent = clsEvent.EventSearch(strCompany, strCity, strCountry, strEventNumber, strCameraNumber, strAlarmNumber, strOperator, decState, decLocation, decEventType,
            decCameraType, decAlarmType, Photo_Date_From, Photo_Date_To, Alarm_Time_From, Alarm_Time_To, Investigation_Report_Date_From, Investigation_Report_Date_To, Event_Report_Date_From,
            Event_Report_Date_To, _SortBy, _SortOrder, 1, ctrlPageProperty.TotalRecords, 0, 0, Date_Opened, Event_Occurance_Date, strCameraName);
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
        Response.Redirect("Event.aspx?mode=add&loc=0");

    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind DropDownList
    /// </summary>
    private void BindDropDownList()
    {
        //ComboHelper.FillState(new DropDownList[] { drpState }, true);
        ComboHelper.FillEventType(new DropDownList[] { drpEventType }, true);
        //ComboHelper.FillLU_Camera_Type(new DropDownList[] { drpCameraType }, true);
        //ComboHelper.FillLU_Alarm_Type(new DropDownList[] { drpAlarmType }, true);
        //ComboHelper.FillLocation(new DropDownList[] { drpLocation }, true);
        ComboHelper.FillLocationByACIUser((new DropDownList[] { drpLocation }),Convert.ToDecimal(clsSession.UserID), true);
    } 

    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        #region "Variable"

        decimal? decState = 0, decLocation = 0, decEventType = 0, decAlarmType = 0, decCameraType = 0;
        DateTime? Photo_Date_From = null, Photo_Date_To = null, Alarm_Time_From = null, Alarm_Time_To = null, Investigation_Report_Date_From = null, Investigation_Report_Date_To = null,
            Event_Report_Date_From = null, Event_Report_Date_To = null, Date_Opened = null, Event_Occurance_Date = null;
        string strCompany = null, strCity = null, strCountry = null, strEventNumber = null, strCameraNumber = null, strAlarmNumber = null, strOperator = null, strCameraName = null;

        //if (drpState.SelectedIndex > 0) decState = Convert.ToDecimal(drpState.SelectedValue);
        if (drpLocation.SelectedIndex > 0)
            if (!string.IsNullOrEmpty(Convert.ToString(drpLocation.SelectedValue)))
            decLocation = Convert.ToDecimal(drpLocation.SelectedValue);
        if (drpEventType.SelectedIndex > 0) decEventType = Convert.ToDecimal(drpEventType.SelectedValue);
        //if (drpAlarmType.SelectedIndex > 0) decAlarmType = Convert.ToDecimal(drpAlarmType.SelectedValue);
        //if (drpCameraType.SelectedIndex > 0) decCameraType = Convert.ToDecimal(drpCameraType.SelectedValue);

        //if (!string.IsNullOrEmpty(txtPhotoDate.Text)) Photo_Date_From = Convert.ToDateTime(txtPhotoDate.Text);
        //if (!string.IsNullOrEmpty(txtToPhotoDate.Text)) Photo_Date_To = Convert.ToDateTime(txtToPhotoDate.Text);
        //if (!string.IsNullOrEmpty(txtAlarmTime.Text)) Alarm_Time_From = Convert.ToDateTime(txtAlarmTime.Text);
        //if (!string.IsNullOrEmpty(txtToAlarmTime.Text)) Alarm_Time_To = Convert.ToDateTime(txtToAlarmTime.Text);
        if (!string.IsNullOrEmpty(txtInvestigationReportDate.Text)) Investigation_Report_Date_From = Convert.ToDateTime(txtInvestigationReportDate.Text);
        if (!string.IsNullOrEmpty(txtToInvestigationReportDate.Text)) Investigation_Report_Date_To = Convert.ToDateTime(txtToInvestigationReportDate.Text);
        if (!string.IsNullOrEmpty(txtEventReportDate.Text)) Event_Report_Date_From = Convert.ToDateTime(txtEventReportDate.Text);
        if (!string.IsNullOrEmpty(txtToEventReportDate.Text)) Event_Report_Date_To = Convert.ToDateTime(txtToEventReportDate.Text);

        //if (!string.IsNullOrEmpty(txtCompany.Text)) strCompany = txtCompany.Text.Trim().Replace("'", "''");
        //if (!string.IsNullOrEmpty(txtCity.Text)) strCity = txtCity.Text.Trim().Replace("'", "''");
        //if (!string.IsNullOrEmpty(txtCountry.Text)) strCountry = txtCountry.Text.Trim().Replace("'", "''");
        if (!string.IsNullOrEmpty(txtEventNumber.Text)) strEventNumber = txtEventNumber.Text.Trim().Replace("'", "''");
        if (!string.IsNullOrEmpty(txtCameraNumber.Text)) strCameraNumber = txtCameraNumber.Text.Trim().Replace("'", "''");
        //if (!string.IsNullOrEmpty(txtAlarmNumber.Text)) strAlarmNumber = txtAlarmNumber.Text.Trim().Replace("'", "''");
        //if (!string.IsNullOrEmpty(txtOperator.Text)) strOperator = txtOperator.Text.Trim().Replace("'", "''");

        if (!string.IsNullOrEmpty(txtDate_Opened.Text)) Date_Opened = Convert.ToDateTime(txtDate_Opened.Text);
        if (!string.IsNullOrEmpty(txtEvent_Occurance_Date.Text)) Event_Occurance_Date = Convert.ToDateTime(txtEvent_Occurance_Date.Text);

        if (!string.IsNullOrEmpty(txtCameraName.Text)) strCameraName = txtCameraName.Text.Trim().Replace("'", "''");

        #endregion

        // selects records depending on paging criteria and search values.
        DataSet dsEvent = clsEvent.EventSearch(strCompany, strCity, strCountry, strEventNumber, strCameraNumber, strAlarmNumber, strOperator, decState, decLocation, decEventType,
            decCameraType, decAlarmType, Photo_Date_From, Photo_Date_To, Alarm_Time_From, Alarm_Time_To, Investigation_Report_Date_From, Investigation_Report_Date_To, Event_Report_Date_From,
            Event_Report_Date_To, _SortBy, _SortOrder, PageNumber, PageSize, 0, 0, Date_Opened, Event_Occurance_Date, strCameraName);
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
        dtCriteria.Columns.Add("strCompany", typeof(string));
        dtCriteria.Columns.Add("strCity", typeof(string));
        dtCriteria.Columns.Add("strCountry", typeof(string));
        dtCriteria.Columns.Add("strEventNumber", typeof(string));
        dtCriteria.Columns.Add("strCameraNumber", typeof(string));
        dtCriteria.Columns.Add("strAlarmNumber", typeof(string));
        dtCriteria.Columns.Add("strOperator", typeof(string));
        dtCriteria.Columns.Add("Photo_Date_From", typeof(string));
        dtCriteria.Columns.Add("Photo_Date_To", typeof(string));
        dtCriteria.Columns.Add("Alarm_Time_From", typeof(string));
        dtCriteria.Columns.Add("Alarm_Time_To", typeof(string));
        dtCriteria.Columns.Add("Investigation_Report_Date_From", typeof(string));
        dtCriteria.Columns.Add("Investigation_Report_Date_To", typeof(string));
        dtCriteria.Columns.Add("Event_Report_Date_From", typeof(string));
        dtCriteria.Columns.Add("strCameraName", typeof(string));

        dtCriteria.Columns.Add("decState", typeof(decimal));
        dtCriteria.Columns.Add("decLocation", typeof(decimal));
        dtCriteria.Columns.Add("decEventType", typeof(decimal));
        dtCriteria.Columns.Add("decAlarmType", typeof(decimal));
        dtCriteria.Columns.Add("decCameraType", typeof(decimal));
        dtCriteria.Columns.Add("Date_Opened", typeof(string));
        dtCriteria.Columns.Add("Event_Occurance_Date", typeof(string));
        dtCriteria.Columns.Add("Event_Report_Date_To", typeof(string));


        DataRow drCriteria = dtCriteria.NewRow();
        drCriteria["strCompany"] = strCompany;
        drCriteria["strCity"] = strCity;
        drCriteria["strCountry"] = strCountry;
        drCriteria["strEventNumber"] = strEventNumber;
        drCriteria["strCameraNumber"] = strCameraNumber;
        drCriteria["strAlarmNumber"] = strAlarmNumber;
        drCriteria["strOperator"] = strOperator;
        drCriteria["Photo_Date_From"] = Photo_Date_From;
        drCriteria["Photo_Date_To"] = Photo_Date_To;
        drCriteria["Alarm_Time_From"] = Alarm_Time_From;
        drCriteria["Alarm_Time_To"] = Alarm_Time_To;
        drCriteria["Investigation_Report_Date_From"] = Investigation_Report_Date_From;
        drCriteria["Investigation_Report_Date_To"] = Investigation_Report_Date_To;
        drCriteria["Event_Report_Date_From"] = Event_Report_Date_From;
        drCriteria["Event_Report_Date_To"] = Event_Report_Date_To;

        drCriteria["decState"] = decState;
        drCriteria["decLocation"] = decLocation;
        drCriteria["decEventType"] = decEventType;
        drCriteria["decAlarmType"] = decAlarmType;
        drCriteria["decCameraType"] = decCameraType;
        drCriteria["Date_Opened"] = Date_Opened;
        drCriteria["Event_Occurance_Date"] = Event_Occurance_Date;
        drCriteria["strCameraName"] = strCameraName;
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

        decimal? decState = null, decLocation = null, decEventType = null, decAlarmType = null, decCameraType = null;
        DateTime? Photo_Date_From = null, Photo_Date_To = null, Alarm_Time_From = null, Alarm_Time_To = null, Investigation_Report_Date_From = null, Investigation_Report_Date_To = null,
            Event_Report_Date_From = null, Event_Report_Date_To = null, Date_Opened = null, Event_Occurance_Date = null;
        string strCompany = null, strCity = null, strCountry = null, strEventNumber = null, strCameraNumber = null, strAlarmNumber = null, strOperator = null, strCameraName = null;

        strCompany = Convert.ToString(drCriteria["strCompany"]);
        strCity = Convert.ToString(drCriteria["strCity"]);
        strCountry = Convert.ToString(drCriteria["strCountry"]);
        strEventNumber = Convert.ToString(drCriteria["strEventNumber"]);
        strCameraNumber = Convert.ToString(drCriteria["strCameraNumber"]);
        strAlarmNumber = Convert.ToString(drCriteria["strAlarmNumber"]);
        strOperator = Convert.ToString(drCriteria["strOperator"]);
        strCameraName = Convert.ToString(drCriteria["strCameraName"]);

        if (Convert.ToDecimal(drCriteria["decState"]) != 0) decState = Convert.ToDecimal(drCriteria["decState"]);
        if (Convert.ToDecimal(drCriteria["decLocation"]) != 0) decLocation = Convert.ToDecimal(drCriteria["decLocation"]);
        if (Convert.ToDecimal(drCriteria["decEventType"]) != 0) decEventType = Convert.ToDecimal(drCriteria["decEventType"]);
        if (Convert.ToDecimal(drCriteria["decAlarmType"]) != 0) decAlarmType = Convert.ToDecimal(drCriteria["decAlarmType"]);
        if (Convert.ToDecimal(drCriteria["decCameraType"]) != 0) decCameraType = Convert.ToDecimal(drCriteria["decCameraType"]);

        Photo_Date_From = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Photo_Date_From"]));
        Photo_Date_To = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Photo_Date_To"]));
        Alarm_Time_From = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Alarm_Time_From"]));
        Alarm_Time_To = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Alarm_Time_To"]));
        Investigation_Report_Date_From = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Investigation_Report_Date_From"]));
        Investigation_Report_Date_To = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Investigation_Report_Date_To"]));
        Event_Report_Date_From = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Event_Report_Date_From"]));
        Event_Report_Date_To = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Event_Report_Date_To"]));

        Date_Opened = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Date_Opened"]));
        Event_Occurance_Date = clsGeneral.FormatNullDateToStore(Convert.ToString(drCriteria["Event_Occurance_Date"]));
        

        #endregion

        #region "Bind Grid"

        DataSet dsEvent = clsEvent.EventSearch(strCompany, strCity, strCountry, strEventNumber, strCameraNumber, strAlarmNumber, strOperator, decState, decLocation, decEventType,
            decCameraType, decAlarmType, Photo_Date_From, Photo_Date_To, Alarm_Time_From, Alarm_Time_To, Investigation_Report_Date_From, Investigation_Report_Date_To, Event_Report_Date_From,
            Event_Report_Date_To, _SortBy, _SortOrder, PageNumber, PageSize, 0, 0, Date_Opened, Event_Occurance_Date, strCameraName);
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
        strHTML.Append("<td align='left'>Event Description</td>");
        strHTML.Append("<td align='left'>DBA</td>");
        strHTML.Append("<td align='left'>Location Code</td>");
        strHTML.Append("<td align='left'>Company</td>");
        strHTML.Append("<td align='left'>Investigation report date</td>");
        strHTML.Append("<td align='left'>Event date </td>");

        strHTML.Append("</tr>");

        if (dtEvent.Rows.Count > 0)
        {
            for (int i = 0; i < dtEvent.Rows.Count; i++)
            {
                strHTML.Append("<tr align='left'>");
                strHTML.Append("<td>" + Convert.ToString(dtEvent.Rows[i]["Event_Number"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtEvent.Rows[i]["Event_Desc"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtEvent.Rows[i]["FK_LU_Location"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtEvent.Rows[i]["Location_Code"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtEvent.Rows[i]["Company"]) + "</td>");
                strHTML.Append("<td>" + clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[i]["Investigation_Report_Date"]) + "</td>");
                strHTML.Append("<td>" + clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[i]["Event_Report_Date"]) + "</td>");
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
            LinkButton btnEdit = (LinkButton)e.Row.Cells[0].FindControl("btnEdit");
            LinkButton btnView = (LinkButton)e.Row.Cells[0].FindControl("btnView");
            LinkButton btnDelete = (LinkButton)e.Row.Cells[0].FindControl("btnDelete");
            LinkButton btnSelect = (LinkButton)e.Row.Cells[0].FindControl("btnSelect");
            if (PK_Incident > 0)
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnView.Visible = false;
                btnSelect.Visible = true;
            }
            else
            {
                btnEdit.Visible = (App_Access != AccessType.View_Only);
                btnDelete.Visible = (App_Access == AccessType.Delete || App_Access == AccessType.Administrative_Access);
                btnView.Visible = true;
                btnSelect.Visible = false;
            }
        }
    }

    /// <summary>
    /// Handles event when links are clicked in the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEvent_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditEvent")
        {
            string[] strCommandArgument = e.CommandArgument.ToString().Split(',');
            decimal FK_Incident = Convert.ToDecimal(strCommandArgument[1]);
            decimal PK_Event = Convert.ToDecimal(strCommandArgument[0]);
            Response.Redirect("Event.aspx?iid=" + Encryption.Encrypt(Convert.ToString(FK_Incident)) + "&eid=" + Encryption.Encrypt(Convert.ToString(PK_Event)) + "&mode=edit", true);
        }
        if (e.CommandName == "SelectEvent")
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

        else if (e.CommandName == "ViewEvent")
        {
            string[] strCommandArgument = e.CommandArgument.ToString().Split(',');
            decimal FK_Incident = Convert.ToDecimal(strCommandArgument[1]);
            decimal PK_Event = Convert.ToDecimal(strCommandArgument[0]);
            Response.Redirect("Event.aspx?iid=" + Encryption.Encrypt(Convert.ToString(FK_Incident)) + "&eid=" + Encryption.Encrypt(Convert.ToString(PK_Event)) + "&mode=view", true);
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

}