using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.Text;

public partial class SONIC_Exposures_EPM_Scheduler : clsBasePage
{
    #region " Variables "

    int _Monthvalue;
    int _Year;

    #endregion

    #region " Properties "

    /// <summary>
    /// DataTable for Data of Selected month for Schedule
    /// </summary>
    private DataSet DsScheduleData
    {
        get
        {
            return (ViewState["DsScheduleData"] != null ? (DataSet)(ViewState["DsScheduleData"]) : null);
        }
        set { ViewState["DsScheduleData"] = value; }
    }

    /// <summary>
    /// Denote Location ID for Environmental Project Management Data
    /// </summary>
    public int LocationID
    {
        get { return Convert.ToInt32(ViewState["LocationID"]); }
        set { ViewState["LocationID"] = value; }
    }

    /// <summary>
    /// denotes Foreign Key of EPM_Identification table
    /// </summary>
    public decimal PK_EPM_Identification
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Identification"]); }
        set { ViewState["PK_EPM_Identification"] = value; }
    }

    /// <summary>
    /// Denote PanelNum 
    /// </summary>
    public string PanelNum
    {
        get { return Convert.ToString(ViewState["PanelNum"]); }
        set { ViewState["PanelNum"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }
    #endregion

    #region " Page Load "
    /// <summary>
    ///  Handles Page Load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.ProjectManagement);

        if (!IsPostBack)
        {
            LocationID = Convert.ToInt32(Encryption.Decrypt(Request.QueryString["loc"].ToString()));
            PK_EPM_Identification = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["id"].ToString()));
            PanelNum = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();
            StrOperation = Request.QueryString["op"].ToString();

            calMonth.SelectedDate = DateTime.Now;
            calMonth.VisibleDate = DateTime.Now;
            _Monthvalue = calMonth.SelectedDate.Month;
            _Year = calMonth.SelectedDate.Year;
            FillYearDropDown();

            ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString();


            ComboHelper.FillLocationdbaOnly(new DropDownList[] { drpLocationFilter }, 0, true, true);
            drpLocationFilter.Style.Add("font-size", "");

            string strLocationIDs = "";
            for (int i = 1; i < drpLocationFilter.Items.Count; i++)
            {
                strLocationIDs += drpLocationFilter.Items[i].Value + ",";
            }
            strLocationIDs = strLocationIDs.TrimEnd(',');
            ComboHelper.FillRegionByLocationID(new DropDownList[] { drpRegion }, true, strLocationIDs);

            ListItem lst = null;
            lst = drpLocationFilter.Items.FindByValue(LocationID.ToString());
            if (lst != null)
                lst.Selected = true;

            //bind current month data(class details)
            if (drpLocationFilter.SelectedIndex > 0)
                BindMonthData();

            lblMonth.Text = ddlMonth.SelectedItem.Text + " " + ddlYear.SelectedValue;

            Session["ExposureLocation"] = LocationID;
        }
        else
        {
            _Monthvalue = Convert.ToInt32(ddlMonth.SelectedValue);
            _Year = Convert.ToInt32(ddlYear.SelectedValue);
        }
    }
    #endregion

    #region " Controls Events "
    /// <summary>
    /// handles Previous button's click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgPrevious_Click(object sender, ImageClickEventArgs e)
    {
        ///click to set previous month schedule
        _Monthvalue -= 1;
        if (_Monthvalue < 1)
        {
            _Monthvalue = 12;
            _Year = _Year - 1;

            //set Dropdown controls -Month and year
            ddlYear.SelectedValue = _Year.ToString();
            ddlMonth.SelectedValue = _Monthvalue.ToString();
        }
        else
        {
            //set Dropdown controls -Month and year
            ddlYear.SelectedValue = _Year.ToString();
            ddlMonth.SelectedValue = _Monthvalue.ToString();
        }
        //rebind the class details schedule for seleted Month
        if (drpLocationFilter.SelectedIndex > 0)
            BindMonthData();
        else
            BindCalenderByLocationID();
        calMonth.VisibleDate = calMonth.VisibleDate.AddMonths(-1);
        lblMonth.Text = ddlMonth.SelectedItem.Text + " " + ddlYear.SelectedValue;
    }

    /// <summary>
    /// handles Next Button's click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgNext_Click(object sender, ImageClickEventArgs e)
    {
        ///click to set next month schedule
        _Monthvalue += 1;
        if (_Monthvalue > 12)
        {
            _Monthvalue = 1;
            _Year = _Year + 1;
            //set Dropdown controls -Month and year
            ddlYear.SelectedValue = _Year.ToString();
            ddlMonth.SelectedValue = _Monthvalue.ToString();
        }
        else
        {
            //set Dropdown controls -Month and year
            ddlYear.SelectedValue = _Year.ToString();
            ddlMonth.SelectedValue = _Monthvalue.ToString();
        }
        //rebind the class details schedule for seleted Month
        if (drpLocationFilter.SelectedIndex > 0)
            BindMonthData();
        else
            BindCalenderByLocationID();
        calMonth.VisibleDate = calMonth.VisibleDate.AddMonths(1);
        lblMonth.Text = ddlMonth.SelectedItem.Text + " " + ddlYear.SelectedValue;
    }

    /// <summary>
    /// Handles Selected Index change of Month Dropdown 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        //change the month and rebind the calander schedule
        int Difference = Convert.ToInt32(ddlMonth.SelectedValue) - calMonth.VisibleDate.Month;
        calMonth.VisibleDate = calMonth.VisibleDate.AddMonths(Difference);
        if (drpLocationFilter.SelectedIndex > 0)
            BindMonthData();
        else
            BindCalenderByLocationID();
        lblMonth.Text = ddlMonth.SelectedItem.Text + " " + ddlYear.SelectedValue;
    }

    /// <summary>
    /// Handles Selected Index change of Year Dropdown 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //change the year and rebind the calander schedule
        int Difference = Convert.ToInt32(ddlYear.SelectedValue) - calMonth.VisibleDate.Year;
        calMonth.VisibleDate = calMonth.VisibleDate.AddYears(Difference);
        if (drpLocationFilter.SelectedIndex > 0)
            BindMonthData();
        else
            BindCalenderByLocationID();
        lblMonth.Text = ddlMonth.SelectedItem.Text + " " + ddlYear.SelectedValue;
    }

    /// <summary>
    /// Handles Day render event of Calendar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void calMonth_DayRender(object sender, DayRenderEventArgs e)
    {
        //check Month
        if (e.Day.Date.Month == Convert.ToInt32(ddlMonth.SelectedValue))
        {
            //initialize the string
            StringBuilder strDayRender = new StringBuilder();
            strDayRender.Append("");
            //check Data in dataset exist or not
            if (DsScheduleData != null)
            {
                //select the class details data for current day from dataset
                if (drpLocationFilter.SelectedIndex > 0 && DsScheduleData.Tables.Count == 1)
                {
                    DataRow[] drDay = DsScheduleData.Tables[0].Select(" intDay=" + e.Day.Date.Day);

                    if (drDay.Length > 0)
                    {
                        //set the class detail for current day and render into the calader day
                        string strIdentificationID = "";
                        string strPreviousProjectNumber = "";
                        string strCurrentProjectNumber = "";

                        string strEstimated_Start = "";
                        string strActual_Start = "";
                        string strEstimated_End = "";
                        string strActual_End = "";
                        string strMilestone = "";

                        strDayRender.Append("<table width='100%' cellpadding='2' cellspacing='1' border='0'>");
                        foreach (DataRow dr in drDay)
                        {
                            //display all the class details in current day in clander
                            strIdentificationID = Convert.ToString(dr["FK_EPM_Identification"]);
                            strCurrentProjectNumber = Convert.ToString(dr["Project_Number"]);
                            if (strCurrentProjectNumber != strPreviousProjectNumber)
                            {
                                if (dr.ItemArray[3].ToString() == "Estimated_Start")
                                {
                                    strEstimated_Start = "Estimated Project Start Date";

                                    string strDay = "<tr><td align='left'><a href='javascript:void(0);' onclick=\"RedirectToProject('" + Encryption.Encrypt(strIdentificationID.ToString()) + "','" + Encryption.Encrypt(LocationID.ToString()) + "')\">"
                                    + strCurrentProjectNumber + "</a><br/>" + strEstimated_Start + "";
                                    strDayRender.Append(strDay);
                                }
                                if (dr.ItemArray[3].ToString() == "Actual_Start")
                                {
                                    strActual_Start = "Actual Project Start Date";
                                    string strDay = "<tr><td align='left'><a href='javascript:void(0);' onclick=\"RedirectToProject('" + Encryption.Encrypt(strIdentificationID.ToString()) + "','" + Encryption.Encrypt(LocationID.ToString()) + "')\">"
                                    + strCurrentProjectNumber + "</a><br/>" + strActual_Start + "";
                                    strDayRender.Append(strDay);
                                }
                                if (dr.ItemArray[3].ToString() == "Estimated_End")
                                {
                                    strEstimated_End = "Estimated Project Completion Date";
                                    string strDay = "<tr><td align='left'><a href='javascript:void(0);' onclick=\"RedirectToProject('" + Encryption.Encrypt(strIdentificationID.ToString()) + "','" + Encryption.Encrypt(LocationID.ToString()) + "')\">"
                                    + strCurrentProjectNumber + "</a><br/>" + strEstimated_End + "";
                                    strDayRender.Append(strDay);
                                }
                                if (dr.ItemArray[3].ToString() == "Actual_End")
                                {
                                    strActual_End = "Actual Project Completion Date";
                                    string strDay = "<tr><td align='left'><a href='javascript:void(0);' onclick=\"RedirectToProject('" + Encryption.Encrypt(strIdentificationID.ToString()) + "','" + Encryption.Encrypt(LocationID.ToString()) + "')\">"
                                    + strCurrentProjectNumber + "</a><br/>" + strActual_End + "";
                                    strDayRender.Append(strDay);
                                }
                                if (dr.ItemArray[3].ToString() == "Milestone")
                                {
                                    strMilestone = "Milestone - " + Convert.ToString(dr["Mileston_Description"]);
                                    string strDay = "<tr><td align='left'><a href='javascript:void(0);' onclick=\"RedirectToProject('" + Encryption.Encrypt(strIdentificationID.ToString()) + "','" + Encryption.Encrypt(LocationID.ToString()) + "')\">"
                                    + strCurrentProjectNumber + "</a><br/>" + strMilestone + "";
                                    strDayRender.Append(strDay);
                                }
                            }
                            else
                            {
                                if (dr.ItemArray[3].ToString() == "Estimated_Start")
                                {
                                    strEstimated_Start = "Estimated Project Start Date";

                                    string strDay = "<tr><td align='left'>" + strEstimated_Start + "";
                                    strDayRender.Append(strDay);
                                }
                                if (dr.ItemArray[3].ToString() == "Actual_Start")
                                {
                                    strActual_Start = "Actual Project Start Date";
                                    string strDay = "<tr><td align='left'>" + strActual_Start + "";
                                    strDayRender.Append(strDay);
                                }
                                if (dr.ItemArray[3].ToString() == "Estimated_End")
                                {
                                    strEstimated_End = "Estimated Project Completion Date";
                                    string strDay = "<tr><td align='left'>" + strEstimated_End + "";
                                    strDayRender.Append(strDay);
                                }
                                if (dr.ItemArray[3].ToString() == "Actual_End")
                                {
                                    strActual_End = "Actual Project Completion Date";
                                    string strDay = "<tr><td align='left'>" + strActual_End + "";
                                    strDayRender.Append(strDay);
                                }
                                if (dr.ItemArray[3].ToString() == "Milestone")
                                {
                                    strMilestone = "Milestone - " + Convert.ToString(dr["Mileston_Description"]);
                                    string strDay = "<tr><td align='left'>" + strMilestone + "";
                                    strDayRender.Append(strDay);
                                }
                            }
                            strPreviousProjectNumber = strCurrentProjectNumber;
                        }
                        strDayRender.Append("</table>");
                    }
                }
                else
                {
                    for (int i = 0; i < DsScheduleData.Tables.Count; i++)
                    {
                        DataRow[] drDay = DsScheduleData.Tables[i].Select(" intDay=" + e.Day.Date.Day);
                        if (drDay.Length > 0)
                        {
                            //set the class detail for current day and render into the calader day
                            string strIdentificationID = "";
                            string strPreviousProjectNumber = "";
                            string strCurrentProjectNumber = "";

                            string strEstimated_Start = "";
                            string strActual_Start = "";
                            string strEstimated_End = "";
                            string strActual_End = "";
                            string strMilestone = "";

                            strDayRender.Append("<table width='100%' cellpadding='2' cellspacing='1' border='0'>");
                            foreach (DataRow dr in drDay)
                            {
                                //display all the class details in current day in clander
                                strIdentificationID = Convert.ToString(dr["FK_EPM_Identification"]);
                                strCurrentProjectNumber = Convert.ToString(dr["Project_Number"]);
                                if (strCurrentProjectNumber != strPreviousProjectNumber)
                                {
                                    if (dr.ItemArray[3].ToString() == "Estimated_Start")
                                    {
                                        strEstimated_Start = "Estimated Project Start Date";

                                        string strDay = "<tr><td align='left'><a href='javascript:void(0);' onclick=\"RedirectToProject('" + Encryption.Encrypt(strIdentificationID.ToString()) + "','" + Encryption.Encrypt(LocationID.ToString()) + "')\">"
                                        + strCurrentProjectNumber + "</a><br/>" + strEstimated_Start + "";
                                        strDayRender.Append(strDay);
                                    }
                                    if (dr.ItemArray[3].ToString() == "Actual_Start")
                                    {
                                        strActual_Start = "Actual Project Start Date";
                                        string strDay = "<tr><td align='left'><a href='javascript:void(0);' onclick=\"RedirectToProject('" + Encryption.Encrypt(strIdentificationID.ToString()) + "','" + Encryption.Encrypt(LocationID.ToString()) + "')\">"
                                        + strCurrentProjectNumber + "</a><br/>" + strActual_Start + "";
                                        strDayRender.Append(strDay);
                                    }
                                    if (dr.ItemArray[3].ToString() == "Estimated_End")
                                    {
                                        strEstimated_End = "Estimated Project Completion Date";
                                        string strDay = "<tr><td align='left'><a href='javascript:void(0);' onclick=\"RedirectToProject('" + Encryption.Encrypt(strIdentificationID.ToString()) + "','" + Encryption.Encrypt(LocationID.ToString()) + "')\">"
                                        + strCurrentProjectNumber + "</a><br/>" + strEstimated_End + "";
                                        strDayRender.Append(strDay);
                                    }
                                    if (dr.ItemArray[3].ToString() == "Actual_End")
                                    {
                                        strActual_End = "Actual Project Completion Date";
                                        string strDay = "<tr><td align='left'><a href='javascript:void(0);' onclick=\"RedirectToProject('" + Encryption.Encrypt(strIdentificationID.ToString()) + "','" + Encryption.Encrypt(LocationID.ToString()) + "')\">"
                                        + strCurrentProjectNumber + "</a><br/>" + strActual_End + "";
                                        strDayRender.Append(strDay);
                                    }
                                    if (dr.ItemArray[3].ToString() == "Milestone")
                                    {
                                        strMilestone = "Milestone - " + Convert.ToString(dr["Mileston_Description"]);
                                        string strDay = "<tr><td align='left'><a href='javascript:void(0);' onclick=\"RedirectToProject('" + Encryption.Encrypt(strIdentificationID.ToString()) + "','" + Encryption.Encrypt(LocationID.ToString()) + "')\">"
                                        + strCurrentProjectNumber + "</a><br/>" + strMilestone + "";
                                        strDayRender.Append(strDay);
                                    }
                                }
                                else
                                {
                                    if (dr.ItemArray[3].ToString() == "Estimated_Start")
                                    {
                                        strEstimated_Start = "Estimated Project Start Date";

                                        string strDay = "<tr><td align='left'>" + strEstimated_Start + "";
                                        strDayRender.Append(strDay);
                                    }
                                    if (dr.ItemArray[3].ToString() == "Actual_Start")
                                    {
                                        strActual_Start = "Actual Project Start Date";
                                        string strDay = "<tr><td align='left'>" + strActual_Start + "";
                                        strDayRender.Append(strDay);
                                    }
                                    if (dr.ItemArray[3].ToString() == "Estimated_End")
                                    {
                                        strEstimated_End = "Estimated Project Completion Date";
                                        string strDay = "<tr><td align='left'>" + strEstimated_End + "";
                                        strDayRender.Append(strDay);
                                    }
                                    if (dr.ItemArray[3].ToString() == "Actual_End")
                                    {
                                        strActual_End = "Actual Project Completion Date";
                                        string strDay = "<tr><td align='left'>" + strActual_End + "";
                                        strDayRender.Append(strDay);
                                    }
                                    if (dr.ItemArray[3].ToString() == "Milestone")
                                    {
                                        strMilestone = "Milestone - " + Convert.ToString(dr["Mileston_Description"]);
                                        string strDay = "<tr><td align='left'>" + strMilestone + "";
                                        strDayRender.Append(strDay);
                                    }
                                }
                                strPreviousProjectNumber = strCurrentProjectNumber;
                            }
                            strDayRender.Append("</table>");

                        }
                    }
                }

                //render the day content as html and display in calander schedule
                e.Cell.Text = @"<table cellpadding=0 cellspacing=1 class= 'borderc' width=100% border=0 >
                            <tr><td valign = 'top' class ='monboxbg' align='right'><div align='right'  valign='top' class='calPnum' >" + e.Day.DayNumberText + @"</div>
                           </td></tr><tr><td valign = 'top'></td></tr><tr><td style='height:90px;' valign='top' align='left'>" + strDayRender + "</td></tr></table>";

            }
        }
        else
        {
            //if class details not exist then put blank content for that day
            DateTime dtFirstDay = new DateTime(_Year, _Monthvalue, 1);
            //hide the day from calander based on condition
            if (dtFirstDay.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Cell.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            else
            {
                e.Cell.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            }
        }
    }

    /// <summary>
    /// handles Click event of back button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("Project_Management.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&id=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&pnl=" + PanelNum + "&op=" + StrOperation, true);
    }

    /// <summary>
    /// Handles Selected Index change of Location Dropdown
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpLocationFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intMonth = Convert.ToInt32(ddlMonth.SelectedValue);
        int intYear = Convert.ToInt32(ddlYear.SelectedValue);

        if (drpLocationFilter.SelectedIndex > 0)
        {
            chkAllLocation.Checked = false;
        }
        else
        {
            drpLocationFilter.ClearSelection();
            ListItem lst = null;
            lst = drpLocationFilter.Items.FindByValue(LocationID.ToString());
            if (lst != null)
                lst.Selected = true;
        }
        DsScheduleData = clsEPM_Identification.GetEPMScheduleByLocation(intMonth, intYear, drpLocationFilter.SelectedValue.ToString());
    }

    /// <summary>
    /// handles Check change event of All Location Checkbox
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkAllLocation_OnCheckedChanged(object sender, EventArgs e)
    {
        if (chkAllLocation.Checked)
        {
            ComboHelper.FillLocationdbaOnly(new DropDownList[] { drpLocationFilter }, 0, true, true);
            drpLocationFilter.Style.Add("font-size", "");
            drpLocationFilter.SelectedIndex = 0;
            drpRegion.SelectedIndex = 0;
            BindCalenderByLocationID();
        }
        else
        {
            drpLocationFilter.ClearSelection();
            ListItem lst = null;
            lst = drpLocationFilter.Items.FindByValue(LocationID.ToString());
            if (lst != null)
                lst.Selected = true;
            BindMonthData();
        }
    }

    /// <summary>
    /// handles Selected index changed event of region Dropdown
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpRegion.SelectedIndex > 0)
        {
            ComboHelper.FilldbaByRegion(new DropDownList[] { drpLocationFilter }, true, drpRegion.SelectedItem.Text, Convert.ToDecimal(clsSession.UserID));
            drpLocationFilter.SelectedIndex = 0;
            chkAllLocation.Checked = false;
            BindCalenderByLocationID();
        }
        else
        {
            drpLocationFilter.ClearSelection();
            ListItem lst = null;
            lst = drpLocationFilter.Items.FindByValue(LocationID.ToString());
            if (lst != null)
                lst.Selected = true;
        }
    }

    #endregion

    #region " Page Methods "
    /// <summary>
    /// Bind Year Dropdown
    /// </summary>
    private void FillYearDropDown()
    {
        //fill year dropdown list for 10 years
        for (int i = _Year - 5; i <= _Year + 5; i++)
        {
            ddlYear.Items.Add(new ListItem(Convert.ToString(i), Convert.ToString(i)));
        }
    }

    /// <summary>
    /// Bind Calendar By passed Month and Location
    /// </summary>
    private void BindMonthData()
    {
        //bind or select the data for current month from database
        int intMonth = Convert.ToInt32(ddlMonth.SelectedValue);
        int intYear = Convert.ToInt32(ddlYear.SelectedValue);
        DsScheduleData = clsEPM_Identification.GetEPMSchedule(intMonth, intYear, LocationID, PK_EPM_Identification);
    }

    /// <summary>
    /// Bind Calendar for passed location
    /// </summary>
    private void BindCalenderByLocationID()
    {
        int intMonth = Convert.ToInt32(ddlMonth.SelectedValue);
        int intYear = Convert.ToInt32(ddlYear.SelectedValue);

        string strLocationIDs = "";
        for (int i = 1; i < drpLocationFilter.Items.Count; i++)
        {
            strLocationIDs += drpLocationFilter.Items[i].Value + ",";
        }
        strLocationIDs = strLocationIDs.TrimEnd(',');

        DsScheduleData = clsEPM_Identification.GetEPMScheduleByLocation(intMonth, intYear, strLocationIDs);
    }
    #endregion
}