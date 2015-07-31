using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
public partial class SONIC_SLT_SLT_Meeting : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal PK_SLT_Meeting
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SLT_Meeting"]);
        }
        set { ViewState["PK_SLT_Meeting"] = value; }
    }

    /// <summary>
    /// Denotes the PK_SLT_Member
    /// </summary>
    public decimal PK_SLT_Member
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SLT_Member"]);
        }
        set { ViewState["PK_SLT_Member"] = value; }
    }

    /// <summary>
    /// Denotes the PK_SLT_Member
    /// </summary>
    public decimal PK_SLT_Members_Locations
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SLT_Members_Locations"]);
        }
        set { ViewState["PK_SLT_Members_Locations"] = value; }
    }

    /// <summary>
    /// Denotes the FK_LU_Location
    /// </summary>
    public decimal FK_LU_Location_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_LU_Location_ID"]);
        }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }

    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal PK_SLT_Meeting_Attendees
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SLT_Meeting_Attendees"]);
        }
        set { ViewState["PK_SLT_Meeting_Attendees"] = value; }
    }

    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal PK_SLT_Meeting_Schedule
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SLT_Meeting_Schedule"]);
        }
        set { ViewState["PK_SLT_Meeting_Schedule"] = value; }
    }

    public decimal PK_SLT_New_Procedure
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SLT_New_Procedure"]);
        }
        set { ViewState["PK_SLT_New_Procedure"] = value; }
    }

    public decimal PK_SLT_Safety_Walk
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SLT_Safety_Walk"]);
        }
        set { ViewState["PK_SLT_Safety_Walk"] = value; }
    }

    public decimal PK_SLT_Suggestion
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SLT_Suggestion"]);
        }
        set { ViewState["PK_SLT_Suggestion"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_SLT_Quarterly_Inspections
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SLT_Quarterly_Inspections"]);
        }
        set { ViewState["PK_SLT_Quarterly_Inspections"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_SLT_Training
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SLT_Training"]);
        }
        set { ViewState["PK_SLT_Training"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_SLT_Claims_Mangement
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SLT_Claims_Mangement"]);
        }
        set { ViewState["PK_SLT_Claims_Mangement"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_SLT_Safety_Walk_Members
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SLT_Safety_Walk_Members"]);
        }
        set { ViewState["PK_SLT_Safety_Walk_Members"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Inspection_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Inspection_ID"]);
        }
        set { ViewState["PK_Inspection_ID"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal FK_Inspection_Responses_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_Inspection_Responses_ID"]);
        }
        set { ViewState["FK_Inspection_Responses_ID"] = value; }
    }

    /// <summary>
    /// Denotes the FK_Claim
    /// </summary>
    public decimal FK_Claim
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_Claim"]);
        }
        set { ViewState["FK_Claim"] = value; }
    }

    /// <summary>
    /// Denotes the UniqueVal whether edit or view
    /// </summary>
    public string UniqueVal
    {
        get { return Convert.ToString(ViewState["UniqueVal"]); }
        set { ViewState["UniqueVal"] = value; }
    }
    public bool UserIsRegional
    {
        get { return Convert.ToBoolean(ViewState["UserIsRegional"]); }
        set { ViewState["UserIsRegional"] = value; }
    }
    public bool meetingIsEditable
    {
        get { return Convert.ToBoolean(ViewState["meetingIsEditable"]); }
        set { ViewState["meetingIsEditable"] = value; }
    }

    /// <summary>
    /// Denotes the Temporary schedule id
    /// </summary>
    public decimal PK_Temp_Schedule_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Temp_Schedule_ID"]);
        }
        set { ViewState["PK_Temp_Schedule_ID"] = value; }
    }

    private DateTime Actual_Meeting_Date
    {
        get
        {
            return clsGeneral.FormatDBNullDateToDate(ViewState["Actual_Meeting_Date"]);
        }
        set { ViewState["Actual_Meeting_Date"] = value; }
    }

    private bool IsUserInAdministrativeGroup
    {
        get { if (ViewState["UserGroup"] != null)return Convert.ToBoolean(ViewState["UserGroup"]); else return false; }
        set { ViewState["UserGroup"] = value; }
    }

    #region Incident Review
    public string Year
    {
        get { return ViewState["_Year"].ToString(); }
        set { ViewState["_Year"] = value; }
    }
    public string Month
    {
        get { return ViewState["_Month"].ToString(); }
        set { ViewState["_Month"] = value; }
    }
    public DataTable dt_YearlyTotal
    {
        get { return (DataTable)ViewState["_dt_YearlyTotal"]; }
        set { ViewState["_dt_YearlyTotal"] = value; }
    }
    #endregion
    #endregion

    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt_Y = new DataTable();
            dt_Y.Columns.Add("S1", typeof(string));
            dt_Y.Columns.Add("S2", typeof(string));
            dt_Y.Columns.Add("S3", typeof(string));
            dt_Y.Columns.Add("S4", typeof(string));
            dt_Y.Columns.Add("S5", typeof(string));
            dt_Y.Columns.Add("Monthly_Total", typeof(string));
            dt_YearlyTotal = dt_Y;
            PK_SLT_Meeting = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_LU_Location_ID = clsGeneral.GetQueryStringID(Request.QueryString["LID"]);
            if (Request.QueryString["op"] != null) { StrOperation = Convert.ToString(Request.QueryString["op"]); }
            LU_Location objLU_Location = new LU_Location(FK_LU_Location_ID);
            if ((objLU_Location.FK_Employee_Id != null && objLU_Location.FK_Employee_Id == clsSession.CurrentLoginEmployeeId) || IsUserSystemAdmin)
            {
                UserIsRegional = true;
            }
            else
            {
                UserIsRegional = false;
            }
            meetingIsEditable = true;
            #region Incident Review
            Year = DateTime.Now.Year.ToString();
            Month = DateTime.Now.Month.ToString();

            #endregion
            InvestigationInfo.LocationID = FK_LU_Location_ID;
            InvestigationInfo.ShowSLT_Meeting = true;
            InvestigationInfo.FillGird();
            //GetSLT_Score();

            //Menu5.Attributes.Add("onclick", "javascript:ShowPanel(5);");
            lblSLTWalk.Text = "Monthly SLT Safety Walk Grid for " + DateTime.Now.Year.ToString();
            if (PK_SLT_Meeting_Schedule > 0)
            {
                gvSLTSafetyWalk.Enabled = true;
                //btnSave_SLTSafety.Visible = true;
            }
            else
            {
                gvSLTSafetyWalk.Enabled = false;
                //btnSave_SLTSafety.Visible = false;
            }
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            if (StrOperation != string.Empty)
            {
                //PK_Executive_Risk_Contacts = Convert.ToInt32(Request.QueryString["id"]);
                if (StrOperation == "view")
                {
                    FillIncident_Review();
                    // Bind Controls
                    BindDropDownsForView();
                    if (App_Access == AccessType.View_Only) btnEdit.Visible = false;
                    else btnEdit.Visible = false;
                    BindDetailsForView();

                }
                else
                {
                    FillIncident_Review();
                    IncidentReview_WC.BindIncidentReviewGrid += new SLT_IncidentReview_Info.dlgIncidentReview(BindIncidentReviewGrid);
                    btnEdit.Visible = false;
                    BindDropDowns();
                    BindSLTMemberGrid();
                    BindSLTMemberYearGrid();
                    //BindAttendeesGrid();
                    BindMeetingScheduleGrid();
                    BindGridNewProcedures();
                    BindGridSuggestions();
                    // Bind Controls
                    BindDetailsForEdit();
                    SetValidations();
                    //if (App_Access != AccessType.Administrative_Access && UserAccessType != AccessType.Administrative_Access)
                    //{
                    //    gvMeeting.Columns[gvMeeting.Columns.Count - 1].Visible = false;
                    //}
                    DataSet dtTemp = Security.SelectGroupByUserID(Convert.ToDecimal(clsSession.UserID));
                    if (dtTemp != null && dtTemp.Tables.Count > 0 && dtTemp.Tables[0].Rows.Count > 0)
                    {
                        DataRow[] drTmpRows = dtTemp.Tables[0].Select(" Group_Name = 'Administrative' ");
                        if (drTmpRows.Length > 0)
                            IsUserInAdministrativeGroup = true;
                        else
                            IsUserInAdministrativeGroup = false;
                    }
                }
                if (meetingIsEditable != true)
                {
                    BindDropDownsForView();
                }

                pnl15.Style["Display"] = "";
                pnl16.Style["Display"] = "none";
                pnl15View.Style["Display"] = "";
                pnl16View.Style["Display"] = "none";
            }
            txtCurrent_Date.Text = DateTime.Now.ToShortDateString();
        }

        //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    #endregion

    #region "methods"
    #region Incident Review
    /// <summary>
    /// Fill Month Name In ddl
    /// </summary>
    public void FillMonth(DropDownList ddl)
    {
        ddl.Items.Add(new ListItem("January", "1"));
        ddl.Items.Add(new ListItem("February", "2"));
        ddl.Items.Add(new ListItem("March", "3"));
        ddl.Items.Add(new ListItem("April", "4"));
        ddl.Items.Add(new ListItem("May", "5"));
        ddl.Items.Add(new ListItem("June", "6"));
        ddl.Items.Add(new ListItem("July", "7"));
        ddl.Items.Add(new ListItem("August", "8"));
        ddl.Items.Add(new ListItem("September", "9"));
        ddl.Items.Add(new ListItem("October", "10"));
        ddl.Items.Add(new ListItem("November", "11"));
        ddl.Items.Add(new ListItem("December", "12"));

        ddl.SelectedValue = DateTime.Now.Month.ToString();
    }
    private void FillDashBoardScore()
    {
        LU_Location objLu_Location = new LU_Location(FK_LU_Location_ID);
        string dba = objLu_Location.dba;
        string SonicLocationCode = objLu_Location.Sonic_Location_Code.ToString();
        DataTable dtDetail = Charts.GetIncidentInvestigationDetail(Convert.ToInt16(Year), dba, SonicLocationCode).Tables[0];
        string strDealerShip = "";
        if (dtDetail.Rows.Count > 0)
            strDealerShip = string.Format("{0:N1}", dtDetail.Rows[0]["Performance_Level"]);
        else
            strDealerShip = "All Pro";
        if (StrOperation == "view")
            lblDealerShip_View.Text = strDealerShip; // view mode
        else
            lblDealerShip.Text = strDealerShip; // edit mode
    }
    public void FillIncident_ReviewGrid()
    {
        DataSet ds = SLT_Incident_Review.GetIncident_Review(Year, FK_LU_Location_ID);
        // fill Grid - to show count for month and YTD
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = ds.Tables[0];
            if (dt_YearlyTotal.Columns.Count > 0)
            {
                dt_YearlyTotal.Clear();
                DataRow dr = dt_YearlyTotal.NewRow();
                dr[0] = dt.Compute("Sum(S1)", "");
                dr[1] = dt.Compute("Sum(S2)", "");
                dr[2] = dt.Compute("Sum(S3)", "");
                dr[3] = dt.Compute("Sum(S4)", "");
                dr[4] = dt.Compute("Sum(S5)", "");
                dr[5] = dt.Compute("Sum(Monthly_Total)", "");
                dt_YearlyTotal.Rows.Add(dr);
            }
            if (StrOperation != "view" && meetingIsEditable == false)
            {
                #region edit mode and non editable
                gvIncidentGrid_View.DataSource = dt;
                gvIncidentGrid_View.DataBind();
                #endregion
            }
            else if (StrOperation == "view")
            {
                gvIncidentGrid_View.DataSource = dt;
                gvIncidentGrid_View.DataBind();
            }
            else
            {
                #region Edit mode
                gvIncidentGrid.DataSource = dt;
                gvIncidentGrid.DataBind();
                #endregion
            }
        }

        FillDashBoardScore();
    }
    public void FillIncident_Review()
    {
        FillIncident_ReviewGrid();
        //if (StrOperation == "view")
        //{
        #region
        IncidentReview_WC.Year = Year;//IncidentReview_AL.Year = IncidentReview_PL.Year = IncidentReview_DPD.Year = IncidentReview_Property.Year =
        IncidentReview_WC.Month = Month;//IncidentReview_AL.Month = IncidentReview_PL.Month = IncidentReview_DPD.Month = IncidentReview_Property.Month = 
        IncidentReview_WC.FK_LU_Location_ID = FK_LU_Location_ID;
        IncidentReview_WC.FK_SLT_Meeting = PK_SLT_Meeting;
        if (meetingIsEditable == false)
            IncidentReview_WC.StrOperation = "view";
        else
            IncidentReview_WC.StrOperation = StrOperation;
        IncidentReview_WC.FillAllIncident_Grid();
        #endregion
        #region View Mode
        IncidentReview_WC_View.Year = Year;
        IncidentReview_WC_View.Month = Month;
        IncidentReview_WC_View.FK_LU_Location_ID = FK_LU_Location_ID;
        IncidentReview_WC_View.FK_SLT_Meeting = PK_SLT_Meeting;
        IncidentReview_WC_View.StrOperation = "view";
        IncidentReview_WC_View.FillAllIncident_Grid();
        #endregion
        //}
        //else
        //{

        //}
    }
    /// <summary>
    /// Set Year and Month for All Incident Types
    /// </summary>
    /// <param name="IncidentType"></param>
    public void SetYearMonth_IncidentType(string IncidentType)
    {
        if (StrOperation == "view")
        {
            IncidentReview_WC_View.Year = Year;
            IncidentReview_WC_View.Month = Month;
            if (IncidentType == "wc_fr")
                IncidentReview_WC_View.FillWC_FR_Grid(false);
            else if (string.IsNullOrEmpty(IncidentType))
            {
                IncidentReview_WC_View.FillWC_FR_Grid(false);

            }
        }
        else
        {

            IncidentReview_WC.Year = Year;
            IncidentReview_WC.Month = Month;
            if (IncidentType == "wc_fr")
                IncidentReview_WC.FillWC_FR_Grid(false);
            else if (string.IsNullOrEmpty(IncidentType))
            {
                IncidentReview_WC.FillWC_FR_Grid(false);

            }
        }
    }
    #endregion
    #region "SLT_Meeting"
    private void SaveMeeting()
    {
        UniqueVal = System.Guid.NewGuid().ToString();
        SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
        objSLT_Meeting_Schedule.PK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;
        objSLT_Meeting_Schedule.Meeting_Start_Time = txtMeeting_Start_Time.Text.Trim() == "" ? "" : txtMeeting_Start_Time.Text.Trim() + " " + ddlMeeting_Start_Time_AM.SelectedValue.ToString();
        objSLT_Meeting_Schedule.Meeting_End_Time = txtMeeting_End_Time.Text.Trim() == "" ? "" : txtMeeting_End_Time.Text.Trim() + " " + ddlMeeting_End_Time_AM.SelectedValue.ToString();
        objSLT_Meeting_Schedule.Prev_Meeting_Review = rdoPrev_Meeting_Review.SelectedValue == "Y";
        objSLT_Meeting_Schedule.Safety_Board_Updated = rdoSafety_Board_Updated.SelectedValue;
        objSLT_Meeting_Schedule.Update_Date = System.DateTime.Now;
        objSLT_Meeting_Schedule.Updated_By = clsSession.UserID;
        objSLT_Meeting_Schedule.SLT_Meeting_CutOff_Day = AppConfig.SLT_Meeting_CutOff_Day;

        //objSLT_Meeting_Schedule.UniqueVal = UniqueVal;
        if (PK_SLT_Meeting > 0)
            objSLT_Meeting_Schedule.Update();
        else
            PK_SLT_Meeting = objSLT_Meeting_Schedule.Insert();
        //btnSendMeeting_Members.Enabled = true;
    }
    #endregion
    #region "SLTMEmbers"
    /// <summary>
    /// Bind SLT_Member Grid With Edit And delete Button
    /// </summary>
    private void BindSLTMemberGrid()
    {
        DataTable dtSlt_members = SLT_Members.SLT_MembersSelectByFk(PK_SLT_Meeting, 0, 0).Tables[0];
        if (StrOperation != "view")
        {
            gvSLT_Members.DataSource = dtSlt_members;
            gvSLT_Members.DataBind();
        }
        else
        {
            gvSLT_membersView.DataSource = dtSlt_members;
            gvSLT_membersView.DataBind();
        }
    }
    /// <summary>
    /// Bind SLT_Member Grid With Year filter
    /// </summary>
    private void BindSLTMemberYearGrid()
    {
        int Year;
        if (StrOperation != "view")
            Year = Convert.ToInt32(ddlYear.SelectedItem.Text);
        else
            Year = Convert.ToInt32(drpMemberYearView.SelectedItem.Text);
        DataTable dtSlt_membersBYYear = SLT_Members.SLT_MembersSelectByFk(PK_SLT_Meeting, Year, 0).Tables[0];
        if (StrOperation != "view")
        {
            gvSLT_MembersBYYear.DataSource = dtSlt_membersBYYear;
            gvSLT_MembersBYYear.DataBind();
        }
        else
        {
            gvSlt_Membersbyyearview.DataSource = dtSlt_membersBYYear;
            gvSlt_Membersbyyearview.DataBind();
        }
    }

    private void SaveSLT_Members(string Panel_Number)
    {
        SLT_Members objSLT_Members = new SLT_Members(PK_SLT_Member);
        objSLT_Members.FK_SLT_Meeting = PK_SLT_Meeting;
        objSLT_Members.PK_SLT_Members = PK_SLT_Member;
        if (txtMembersStart_Date.Text != "")
            objSLT_Members.Start_Date = Convert.ToDateTime(txtMembersStart_Date.Text);
        if (txtmemberEnd_date.Text != "")
            objSLT_Members.End_Date = Convert.ToDateTime(txtmemberEnd_date.Text);
        if (drpDepartment.SelectedIndex > 0)
            objSLT_Members.FK_LU_Department = Convert.ToDecimal(drpDepartment.SelectedValue);
        if (drpSLT_Role.SelectedIndex > 0)
            objSLT_Members.FK_LU_SLT_Role = Convert.ToDecimal(drpSLT_Role.SelectedValue);

        if (hdnSLTMember_ISNew.Value == "1")
        {
            objSLT_Members.FK_Employee = Convert.ToDecimal(drpFK_Employee.SelectedValue);
        }
        else
        {
            objSLT_Members.First_Name = txtMembersFirst_Name.Text;
            objSLT_Members.Middle_Name = txtMembersMiddle_Name.Text;
            objSLT_Members.Last_Name = txtMemberLast_Name.Text;
        }
        objSLT_Members.Email = txtMember_Email.Text;
        if (txtMembersStart_Date.Text != "" && txtmemberEnd_date.Text != "")
        {
            if (Convert.ToDateTime(txtMembersStart_Date.Text) < System.DateTime.Now && Convert.ToDateTime(txtmemberEnd_date.Text) > System.DateTime.Now)
                objSLT_Members.Current_Member = "Y";
            else
                objSLT_Members.Current_Member = "N";

        }
        else
            objSLT_Members.Current_Member = "N";
        objSLT_Members.Updated_By = clsSession.UserID;
        objSLT_Members.Update_Date = System.DateTime.Now;
        objSLT_Members.FK_LU_Location_ID = FK_LU_Location_ID;
        int intReturn = objSLT_Members.InsertUpdate();

        if (intReturn > 0)
        {
            tr_Sltmembers.Style["display"] = "";
            tr_SltmembersADD.Style["display"] = "none";
            BindSLTMemberGrid();
            BindSLTMemberYearGrid();
            BindSaftyWalkGrid();
            BindSaftyWalkGridNew();
            if (PK_SLT_Meeting_Schedule > 0 || PK_SLT_Meeting_Schedule == -1)
            {
                BindAttendeesGrid();
            }
            BindAssignedToDropDowns();
            //tr_Sltmembers.Visible = true;
            //tr_SltmembersADD.Visible = false;

            //PK_SLT_Member = 0;
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + Panel_Number + ");", true);
        }
        else if (intReturn == -1)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('SLT Member already exists for the location within the same date interval');", true);
        }
        else if (intReturn == -2)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('Only one Chairman is allowed to be added for a location');", true);
        }
        else if (intReturn == -3)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('A maximum of seven SLT members can be added to one location within the same date interval');", true);
        }
        else if (intReturn == -4)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('Only two Co-Chairmans are allowed to be added for a location');", true);
        }
    }

    private void BindActiveEmployeesByLocation()
    {
        //FK_LU_Location_ID
        drpFK_Employee.Items.Clear();
        DataSet dsEmployee = Employee.SelectActiveEmployessByLocation(Convert.ToInt32(FK_LU_Location_ID));
        if (dsEmployee.Tables.Count > 0)
        {
            drpFK_Employee.DataSource = dsEmployee.Tables[0];
            drpFK_Employee.DataTextField = "EmployeeName";
            drpFK_Employee.DataValueField = "PK_Employee_ID";
            drpFK_Employee.DataBind();
        }
        drpFK_Employee.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    private void BindEmployeesByLocation()
    {
        //FK_LU_Location_ID
        drpFK_Employee.Items.Clear();
        DataSet dsEmployee = Employee.SelectEmployessByLocation(Convert.ToInt32(FK_LU_Location_ID));
        if (dsEmployee.Tables.Count > 0)
        {
            drpFK_Employee.DataSource = dsEmployee.Tables[0];
            drpFK_Employee.DataTextField = "EmployeeName";
            drpFK_Employee.DataValueField = "PK_Employee_ID";
            drpFK_Employee.DataBind();
        }
        drpFK_Employee.Items.Insert(0, new ListItem("-- Select --", "0"));
    }
    #endregion
    #region "MeetingSchehule"
    private void BindAttendeesGrid()
    {
        DataTable dtAttendees = SLT_Members.SLT_MembersSelectByFk(PK_SLT_Meeting, 0, PK_SLT_Meeting_Schedule).Tables[0];
        if (StrOperation != "view" && meetingIsEditable == true)
        {
            gv_MeetingAttendees.DataSource = dtAttendees;
            gv_MeetingAttendees.DataBind();
        }
        else
        {
            gvMeetingAttendeesView.DataSource = dtAttendees;
            gvMeetingAttendeesView.DataBind();
        }
    }

    private void BindMeetingScheduleGrid()
    {
        DateTime? FromDate = null, TOdate = null;
        int Year = 0, Month = 0;
        if (StrOperation != "view")
        {
            if (rdbagendaFrom.Checked == true)
            {
                if (txtMeeting_Agenda_DateFrom.Text != "") FromDate = Convert.ToDateTime(txtMeeting_Agenda_DateFrom.Text);
                if (txtMeeting_Agenda_DateTo.Text != "") TOdate = Convert.ToDateTime(txtMeeting_Agenda_DateTo.Text);
            }
            else if (rdbMeeting_AgendaYear.Checked == true)
            {
                Year = Convert.ToInt32(drpMeeting_AgendaYear.SelectedValue);
                Month = Convert.ToInt32(drpMeeting_AgendaMonth.SelectedValue);
            }
            DataTable Dtmeeting_ScheduleEdit = SLT_Meeting_Schedule.SelectBYFK(PK_SLT_Meeting, FromDate, TOdate, Year, Month).Tables[0];
            gvMeeting.DataSource = Dtmeeting_ScheduleEdit;
            gvMeeting.DataBind();
        }
        else
        {
            if (rdoFromView.Checked == true)
            {
                if (txtFromView.Text != "") FromDate = Convert.ToDateTime(txtFromView.Text);
                if (txtToView.Text != "") TOdate = Convert.ToDateTime(txtToView.Text);
            }
            else if (rdbAgendaYearView.Checked == true)
            {
                Year = Convert.ToInt32(drpMeeting_AgendaYearView.SelectedValue);
                Month = Convert.ToInt32(drpMeeting_AgendaMonthView.SelectedValue);
            }
            DataTable Dtmeeting_ScheduleView = SLT_Meeting_Schedule.SelectBYFK(PK_SLT_Meeting, FromDate, TOdate, Year, Month).Tables[0];
            gvMeetingView.DataSource = Dtmeeting_ScheduleView;
            gvMeetingView.DataBind();
        }
    }

    private void SaveMeetingSchedule()
    {
        #region "SLT_MEETING_Schedule"
        int ret_Val;
        if (txtScheduled_Meeting_Date.Text != "" && txtScheduled_Meeting_Time.Text.Trim() != "" && txtMeeting_Place.Text.Trim() != "")
        {
            SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule();

            objSLT_Meeting_Schedule.FK_SLT_Meeting = PK_SLT_Meeting;
            objSLT_Meeting_Schedule.Scheduled_Meeting_Date = clsGeneral.FormatNullDateToStore(txtScheduled_Meeting_Date.Text);
            objSLT_Meeting_Schedule.Scheduled_Meeting_Time = txtScheduled_Meeting_Time.Text.Trim() == "" ? "" : (txtScheduled_Meeting_Time.Text.Trim() + " " + ddlScheduled_Meeting_Time_AM.SelectedValue.ToString());
            objSLT_Meeting_Schedule.Meeting_Place = txtMeeting_Place.Text.Trim();
            objSLT_Meeting_Schedule.SLT_Meeting_CutOff_Day = AppConfig.SLT_Meeting_CutOff_Day;

            if (drpTime_Zone.SelectedIndex > 0)
                objSLT_Meeting_Schedule.Time_Zone = drpTime_Zone.SelectedValue.ToString();

            //objSLT_Meeting_Schedule.Email_Members = rdoEmail_Members.SelectedValue == "Y";
            objSLT_Meeting_Schedule.Update_Date = System.DateTime.Now;
            objSLT_Meeting_Schedule.Updated_By = clsSession.UserID;

            ret_Val = objSLT_Meeting_Schedule.Insert();
            if (ret_Val == -2)
            {
                //checks for scheduled meeting date if there is another meeting scheduled for the month and year
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(13);alert('SLT Meeting Schedule already exists for the location for same month and Year');", true);
            }
            else if (ret_Val == -1)
            {
                //if current date is greater than 5 of current month then will not allow to enter meeting for previous month
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('You are not allowed to enter data for previous month after 5th of current month.');ShowPanel(13);", true);
            }
            else
            {
                //btnSendMeeting_Members.Enabled = true;
                //btnSendTO_RLCM.Enabled = true;
            }
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(13);", true);
        #endregion
    }

    private void Save_meetingAttendees(string Pnl)
    {
        decimal _retVal = 0;
        SLT_Meeting_Schedule objSchedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
        objSchedule.PK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;
        objSchedule.FK_SLT_Meeting = PK_SLT_Meeting;
        if (txtActual_Meeting_Date.Text != "")
            objSchedule.Actual_Meeting_Date = Convert.ToDateTime(txtActual_Meeting_Date.Text);
        objSchedule.RLCM_Attended = rdoRLCM_Attendance.SelectedValue.ToString();
        objSchedule.Update_Date = System.DateTime.Now;
        objSchedule.Updated_By = clsSession.UserID;
        objSchedule.SLT_Meeting_CutOff_Day = AppConfig.SLT_Meeting_CutOff_Day;

        if (objSchedule.Scheduled_Meeting_Date != null && txtActual_Meeting_Date.Text != "")
        {
            if (Convert.ToDateTime(objSchedule.Scheduled_Meeting_Date).Month != Convert.ToDateTime(txtActual_Meeting_Date.Text).Month || Convert.ToDateTime(objSchedule.Scheduled_Meeting_Date).Year != Convert.ToDateTime(txtActual_Meeting_Date.Text).Year)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Actual Meeting date and Scheduled meeting date should be in same month and year');ShowPanel(" + Pnl + ");", true);
            }
            else
            {
                if (PK_SLT_Meeting_Schedule > 0)
                {
                    objSchedule.Update();
                    _retVal = PK_SLT_Meeting_Schedule;
                }
                else
                    _retVal = objSchedule.Insert();
            }
        }
        else
        {
            if (PK_SLT_Meeting_Schedule > 0)
            {
                objSchedule.Update();
                _retVal = PK_SLT_Meeting_Schedule;
            }
            else
                _retVal = objSchedule.Insert();
        }
        if (_retVal == -1)
        {
            //if current date is greater than 5 of current month then will not allow to enter meeting for previous month
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('You are not allowed to enter data for previous month after " + Convert.ToString(AppConfig.SLT_Meeting_CutOff_Day) + " of current month.');ShowPanel(3);", true);
        }
        else if (_retVal == -2)
        {
            //checks for actual meeting date if there is another meeting scheduled for the month and year
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);alert('SLT Meeting Schedule already exists for the location for same month and Year');", true);
        }
        else if (_retVal > 0)
        {
            PK_SLT_Meeting_Schedule = _retVal;
            //btnSendTO_RLCM.Enabled = true;
            IncidentReview_WC.FK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;


            //PK_SLT_Meeting_Schedule = _retVal;
            //SLT_Meeting_Attendees.DeleteByFK(PK_SLT_Meeting_Schedule);
            foreach (GridViewRow gRow1 in gv_MeetingAttendees.Rows)
            {
                if (((HiddenField)gRow1.FindControl("hdnPK_SLT_Members")).Value != "")
                    PK_SLT_Member = Convert.ToDecimal(((HiddenField)gRow1.FindControl("hdnPK_SLT_Members")).Value);
                SLT_Meeting_Attendees objMeeting_Attendees = new SLT_Meeting_Attendees(PK_SLT_Member, PK_SLT_Meeting_Schedule);
                // objMeeting_Attendees.PK_SLT_Meeting_Attendees = PK_SLT_Meeting_Attendees;
                objMeeting_Attendees.FK_SLT_Members = PK_SLT_Member;
                objMeeting_Attendees.FK_SLT_Meeting = PK_SLT_Meeting;
                objMeeting_Attendees.FK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;
                objMeeting_Attendees.Present = ((RadioButtonList)(gRow1.FindControl("rdbPresent"))).SelectedValue == "Y";

                //if (!(bool)objMeeting_Attendees.Present)
                //{
                //    if (((DropDownList)(gRow1.FindControl("drpExplain"))).SelectedIndex > 0)
                //        objMeeting_Attendees.FK_LU_Explain = Convert.ToDecimal(((DropDownList)(gRow1.FindControl("drpExplain"))).SelectedValue);

                //    if (((DropDownList)(gRow1.FindControl("drpExplain"))).SelectedItem.Text == "Other")
                //        objMeeting_Attendees.Explain = ((TextBox)(gRow1.FindControl("txtExplain"))).Text;
                //    else
                //        objMeeting_Attendees.Explain = null;
                //}
                //else
                //{
                //    objMeeting_Attendees.FK_LU_Explain = null;
                //    objMeeting_Attendees.Explain = null;
                //}
                objMeeting_Attendees.Update_Date = System.DateTime.Now;
                objMeeting_Attendees.Updated_By = clsSession.UserID;
                if (objMeeting_Attendees.PK_SLT_Meeting_Attendees > 0)
                    objMeeting_Attendees.Update();
                else
                    objMeeting_Attendees.Insert();

            }
            //btnSendMeeting_Members.Enabled = true;
            //gv_MeetingAttendees.DataBind();
            //PK_SLT_Meeting_Schedule = 0;
            if (PK_SLT_Meeting_Schedule > 0)
            {
                gvSLTSafetyWalk.Enabled = true;
                //btnSave_SLTSafety.Visible = true;
            }
            else
            {
                gvSLTSafetyWalk.Enabled = false;
                //btnSave_SLTSafety.Visible = false;
            }
            BindSafetyWalkDetails();
            BindSaftyWalkGridNew();
            BindSaftyWalkGrid();
            BindSafetyWalkAttachment();
            btnView_auditSafetyWalk.Visible = false;
            GetSLT_Score();
            BindMeetingScheduleGrid();
            InvestigationInfo.ShowSLT_Meeting = true;
            GridView gvLocation = ((GridView)(InvestigationInfo.FindControl("gvLocation")));
            if (gvLocation.Rows.Count > 0)
                ((Label)(gvLocation.Rows[0].FindControl("lblMeeting_Date"))).Text = clsGeneral.FormatDBNullDateToDisplay(objSchedule.Actual_Meeting_Date);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + Pnl + ");", true);
        }

    }
    /// <summary>
    /// Clears fieids for next meeting schedule when another meeting is selected from agenda grid
    /// </summary>
    private void ClearMeetingSchedule()
    {
        txtScheduled_Meeting_Date.Text = "";
        txtScheduled_Meeting_Time.Text = "";
        txtMeeting_Place.Text = "";
        ddlScheduled_Meeting_Time_AM.SelectedValue = "AM";
        drpTime_Zone.SelectedIndex = 0;
    }
    /// <summary>
    /// Bind Next Meeting Scheduled For 
    /// </summary>
    private void BindNextMeetingSchedule()
    {
        DataTable dtNextMeeting = SLT_Meeting_Schedule.SelectNextMeeting(PK_SLT_Meeting_Schedule, PK_SLT_Meeting).Tables[0];
        if (dtNextMeeting.Rows.Count > 0)
        {
            lblSchedule_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dtNextMeeting.Rows[0]["Scheduled_Meeting_Date"]);
            lblMeeting_Place.Text = Convert.ToString(dtNextMeeting.Rows[0]["Meeting_Place"]);
            lblScheduled_Meeting_Time.Text = Convert.ToString(dtNextMeeting.Rows[0]["Scheduled_Meeting_Time"]);
            //lblRLCM_Attendance.Text = dtNextMeeting.Rows[0]["RLCM_Attended"].ToString() == "Y" ? "Yes" : dtNextMeeting.Rows[0]["RLCM_Attended"].ToString() == "N" ? "No" : "";
            lblTime_Zone.Text = Convert.ToString(dtNextMeeting.Rows[0]["Time_Zone"]);
        }
    }
    #endregion
    #region "Common methods"
    /// <summary>
    /// Bind  Year filter
    /// </summary>
    private void BindDropDowns()
    {
        ddlYear.Items.Clear();
        drpProcedureYear.Items.Clear();
        ddlYearIncident.Items.Clear();
        drpYearInspection.Items.Clear();
        drpMeeting_AgendaYear.Items.Clear();

        for (int i = DateTime.Now.Year; i >= 2007; i--)
        {
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            drpProcedureYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            ddlYearIncident.Items.Add(new ListItem(i.ToString(), i.ToString())); // fill Year In ddl fro Incident Review Grid
            drpYearInspection.Items.Add(new ListItem(i.ToString(), i.ToString()));
            drpMeeting_AgendaYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            //ddlYear_Claim_Management.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        ddlYearIncident.SelectedValue = DateTime.Now.Year.ToString();
        //ddlYear_Claim_Management.SelectedValue = DateTime.Now.Year.ToString();
        FillMonth(ddlMonth);
        FillMonth(drpMeeting_AgendaMonth);


        DataTable dtDepartment = LU_Department.SelectAll().Tables[0];
        dtDepartment.DefaultView.RowFilter = " Description not in ('Roof', 'Service Drive')";
        dtDepartment = dtDepartment.DefaultView.ToTable();
        drpDepartment.DataSource = dtDepartment;
        drpDepartment.DataTextField = "Description";
        drpDepartment.DataValueField = "PK_LU_Department_ID";
        drpDepartment.DataBind();
        drpDepartment.Items.Insert(0, new ListItem("-- Select --", "0"));

        ComboHelper.FillSLT_Role(new DropDownList[] { drpSLT_Role }, true);
        //ComboHelper.FillLocationdbaList(new ListBox[] { lstMember_Location }, 0);
        ComboHelper.FillImportance(new DropDownList[] { drpFK_LU_Importance, drpFK_LU_Importance_Sugg }, true);
        ComboHelper.FillItem_status(new DropDownList[] { drpFK_LU_Item_Status, drpFK_LU_Item_Status_Sugg }, true);
        ComboHelper.FillProcedure_Source(new DropDownList[] { drpFK_LU_Procedure_Source }, true);
        ComboHelper.FillSuggetion_Source(new DropDownList[] { drpFK_LU_Suggestion_Source }, true);
        BindAssignedToDropDowns();
        if (StrOperation != "view")
        {
            for (int intYear = DateTime.Now.Year; intYear >= 2007; intYear--)
                drpTrainingYear.Items.Add(new ListItem(intYear.ToString(), intYear.ToString()));

            //ComboHelper.FillRegion(new DropDownList[] { drpLocationStatus }, true);
        }
        ComboHelper.FillWork_Status(new DropDownList[] { drpAssociates_Status }, true);
        BindActiveEmployeesByLocation();
    }

    private void BindAssignedToDropDowns()
    {
        DataTable dtMembers = SLT_Members.SLT_MembersSelectByFk(PK_SLT_Meeting, 0, PK_SLT_Meeting_Schedule).Tables[0];
        drpFK_SLT_Members.Items.Clear();
        drpFK_SLT_Members.DataSource = dtMembers;
        drpFK_SLT_Members.DataTextField = "FullName";
        drpFK_SLT_Members.DataValueField = "PK_SLT_Members";
        drpFK_SLT_Members.DataBind();
        drpFK_SLT_Members.Items.Insert(0, new ListItem("--Select--", "0"));

        drpProcedureAssignet_to.Items.Clear();
        drpProcedureAssignet_to.DataSource = dtMembers;
        drpProcedureAssignet_to.DataTextField = "FullName";
        drpProcedureAssignet_to.DataValueField = "PK_SLT_Members";
        drpProcedureAssignet_to.DataBind();
        drpProcedureAssignet_to.Items.Insert(0, new ListItem("--Select--", "0"));

        DrpAssigned_To_Sugg.Items.Clear();
        DrpAssigned_To_Sugg.DataSource = dtMembers;
        DrpAssigned_To_Sugg.DataTextField = "FullName";
        DrpAssigned_To_Sugg.DataValueField = "PK_SLT_Members";
        DrpAssigned_To_Sugg.DataBind();
        DrpAssigned_To_Sugg.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    private void BindDropDownsForView()
    {
        drpTrainingYearView.Items.Clear();
        drpMemberYearView.Items.Clear();
        drpProcedureYearView.Items.Clear();
        drpYearInspectionView.Items.Clear();
        ddlYearIncident_View.Items.Clear();
        drpMeeting_AgendaYearView.Items.Clear();

        for (int intYear = DateTime.Now.Year; intYear >= 2007; intYear--)
        {
            drpTrainingYearView.Items.Add(new ListItem(intYear.ToString(), intYear.ToString()));
            drpMemberYearView.Items.Add(new ListItem(intYear.ToString(), intYear.ToString()));
            drpProcedureYearView.Items.Add(new ListItem(intYear.ToString(), intYear.ToString()));
            drpYearInspectionView.Items.Add(new ListItem(intYear.ToString(), intYear.ToString()));
            ddlYearIncident_View.Items.Add(new ListItem(intYear.ToString(), intYear.ToString()));
            drpMeeting_AgendaYearView.Items.Add(new ListItem(intYear.ToString(), intYear.ToString()));
            //ddlYear_Claim_ManagementView.Items.Add(new ListItem(intYear.ToString(), intYear.ToString()));
        }

        ddlYearIncident_View.SelectedValue = DateTime.Now.Year.ToString();
        FillMonth(ddlMonth_View);
        FillMonth(drpMeeting_AgendaMonthView);
    }
    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Style["display"] = "none";
        dvEdit.Style["display"] = "block";
        //if (clsSession.IsUserRegionalOfficer)
        //{
        //    pnl14.Style.Add("display", "block");
        //    pnl14View.Style.Add("display", "none");
        //}
        //else
        //{
        //    pnl14.Style.Add("display", "none");
        //    pnl14View.Style.Add("display", "block");
        //}
        #region"SLT_Meeting_Schedule"
        SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
        //PK_SLT_Meeting_Schedule = Convert.ToDecimal(objSLT_Meeting_Schedule.PK_SLT_Meeting_Schedule);
        txtScheduled_Meeting_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Scheduled_Meeting_Date);
        if (!string.IsNullOrEmpty(objSLT_Meeting_Schedule.Scheduled_Meeting_Time) && objSLT_Meeting_Schedule.Scheduled_Meeting_Time.ToString().Length == 8)
        {
            string[] strMeeting_Schedule = objSLT_Meeting_Schedule.Scheduled_Meeting_Time.Split(' ');
            txtScheduled_Meeting_Time.Text = strMeeting_Schedule[0].ToString();
            ddlScheduled_Meeting_Time_AM.SelectedValue = strMeeting_Schedule[1].ToString();
        }
        else
            txtScheduled_Meeting_Time.Text = objSLT_Meeting_Schedule.Scheduled_Meeting_Time;
        txtMeeting_Place.Text = objSLT_Meeting_Schedule.Meeting_Place;
        clsGeneral.SetDropdownValue(drpTime_Zone, objSLT_Meeting_Schedule.Time_Zone, true);
        //if (objSLT_Meeting_Schedule.Email_Members != null) rdoEmail_Members.SelectedValue = objSLT_Meeting_Schedule.Email_Members.ToString();
        #endregion
        #region "SLT_Quarterly_Inspections"
        LU_Location objLU_Location = new LU_Location(FK_LU_Location_ID);
        string Sonic_Location_Code = Convert.ToString(objLU_Location.Sonic_Location_Code);
        string DBA = objLU_Location.dba;
        int Year = Convert.ToInt32(DateTime.Now.Year);
        DataSet dsDetail = Charts.GetFacilityInspectionDetail(Year, DBA, Sonic_Location_Code);
        if (dsDetail.Tables[0].Rows.Count > 0)
        {
            lblInspectionScore.Text = Convert.ToString(dsDetail.Tables[0].Rows[0]["Score"]);
        }
        else
            lblInspectionScore.Text = "";

        #endregion
        #region "Slt_training"
        SLT_Training objSLT_Training = new SLT_Training(PK_SLT_Training);
        txtTraining_Description.Text = objSLT_Training.Training_Description;
        txtDesired_Comp_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Training.Desired_Comp_Date);
        rdoCompleted.SelectedValue = Convert.ToBoolean(objSLT_Training.Completed) == true ? "Y" : "N";
        txtDate_Completed_Training.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Training.Date_Completed);
        txtComments_Training.Text = objSLT_Training.Comments;

        #endregion
        gv_MeetingAttendees.DataBind();
        BindTrainingConducted_ByRLCM();
        BindGridTrainingSuggstions();
        BindSaftyWalkGridNew();
        BindSaftyWalkGrid();
        BindGridInspection();
        BindClaimManagementGrid();
        BindInspection_ResponseGrid();
        gvSafetywalkAttachmentDetails.DataBind();
        BindTrainingAttachment();
        ShowTraining_QuarterResults();
    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Style["display"] = "block";
        dvnonEditable.Style["display"] = "block";
        dvEdit.Style["display"] = "none";
        btnSaveNnextCall.Visible = false;
        btnSave.Visible = false;
        btnSaveNSend.Visible = false;
        //dvSave.Visible = false;

        #region "Slt_meeting_Schedule"
        SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
        lblSchedule_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Scheduled_Meeting_Date);
        lblScheduled_Meeting_Time.Text = objSLT_Meeting_Schedule.Scheduled_Meeting_Time;
        lblMeeting_Place.Text = objSLT_Meeting_Schedule.Meeting_Place;
        //lblEmail_Members.Text = Convert.ToBoolean(objSLT_Meeting_Schedule.Email_Members) == true ? "Yes" : "No";
        lblTime_Zone.Text = objSLT_Meeting_Schedule.Time_Zone;
        #endregion
        #region "SLT_Quarterly_Inspections"
        LU_Location objLU_Location = new LU_Location(FK_LU_Location_ID);
        string Sonic_Location_Code = Convert.ToString(objLU_Location.Sonic_Location_Code);
        string DBA = objLU_Location.dba;
        int Year = Convert.ToInt32(DateTime.Now.Year);
        DataSet dsDetail = Charts.GetFacilityInspectionDetail(Year, DBA, Sonic_Location_Code);
        if (dsDetail.Tables[0].Rows.Count > 0)
        {
            lblInspectionScoreView.Text = Convert.ToString(dsDetail.Tables[0].Rows[0]["Score"]);
        }
        else
            lblInspectionScoreView.Text = "";
        #endregion
        #region "SLT_training"
        if (PK_SLT_Training > 0)
        {
            SLT_Training objSLT_Training = new SLT_Training(PK_SLT_Training);
            lblTraining_Description.Text = objSLT_Training.Training_Description;
            lblDesired_Comp_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Training.Desired_Comp_Date);
            lblCompleted.Text = Convert.ToBoolean(objSLT_Training.Completed) == true ? "Yes" : "No";
            lblDate_Completed_Training.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Training.Date_Completed);
            lblComments_Training.Text = objSLT_Training.Comments;
        }
        #endregion

        BindSLTMemberGrid();
        BindSLTMemberYearGrid();
        BindMeetingScheduleGrid();
        gvMeetingAttendeesView.DataBind();
        BindSaftyWalkGridNew();
        BindSaftyWalkGrid();
        BindGridNewProcedures();
        BindGridSuggestions();
        BindGridInspection();
        BindClaimManagementGrid();
        BindTrainingConducted_ByRLCM();
        BindGridTrainingSuggstions();
        gvSafetywalkAttachmentView.DataBind();
        BindTrainingAttachment();
        ShowTraining_QuarterResults();
    }
    #endregion
    #region "SLT_Safty_Walk"
    private void BindSaftyWalkGrid()
    {
        DataTable dtSlt_members = SLT_Members.SLT_MembersSelectByFk(PK_SLT_Meeting, 0, PK_SLT_Meeting_Schedule).Tables[0];
        if (StrOperation != "view" && meetingIsEditable == true)
        {
            gvSafetyWalk.DataSource = dtSlt_members;
            gvSafetyWalk.DataBind();
        }
        else
        {
            gvSafetyWalkView.DataSource = dtSlt_members;
            gvSafetyWalkView.DataBind();
        }
    }

    private void BindSaftyWalkGridNew()
    {
        string month;
        int Year;
        //if (drpMeeting_AgendaMonth.SelectedValue != "")
        //    month = drpMeeting_AgendaMonth.SelectedValue;
        //else
        //    month = Month;
        month = Convert.ToString(Actual_Meeting_Date.Month);
        Year = Actual_Meeting_Date.Year;
        DataTable dtSlt_members = LU_SLT_Safety_Walk_Focus_Area.GetMonthlySLTSafetyWalkGrid(PK_SLT_Meeting, Convert.ToInt32(month), PK_SLT_Meeting_Schedule, Year).Tables[0]; //SLT_Members.SLT_MembersSelectByFk(PK_SLT_Meeting, 0).Tables[0];
        if (StrOperation != "view" && meetingIsEditable == true)
        {
            gvSLTSafetyWalk.DataSource = dtSlt_members;
            gvSLTSafetyWalk.DataBind();
        }
        else
        {
            gvSLTSafetyWalkView.DataSource = dtSlt_members;
            gvSLTSafetyWalkView.DataBind();
        }
    }

    private void BindSafetyWalkAttachment()
    {
        DataTable dtAttachment = ERIMSAttachment.SelectByTableName("SLT_Safety_Walk", Convert.ToInt32(PK_SLT_Safety_Walk)).Tables[0];
        if (StrOperation != "view" && meetingIsEditable == true)
        {
            gvSafetywalkAttachmentDetails.DataSource = dtAttachment;
            gvSafetywalkAttachmentDetails.DataBind();
        }
        else
        {
            gvSafetywalkAttachmentView.DataSource = dtAttachment;
            gvSafetywalkAttachmentView.DataBind();
        }
    }
    protected void Upload_SaftyWalk_Attachment()
    {
        if (PK_SLT_Meeting_Schedule > 0)
        {
            SaveSafetyWalk();
            //add attachment
            SafetywalkAttachment.AddSLTAttachment(clsGeneral.SLT_Tables.SLT_Safety_Walk, PK_SLT_Safety_Walk);
            trSafetyWalkAttachment.Style.Add("display", "none");
            BindSafetyWalkAttachment();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);alert('Please add or select meeting agenda record');", true);
        }
    }

    private void SaveSafetyWalk()
    {
        #region "SLT_Safty_Walk"
        if (PK_SLT_Meeting_Schedule > 0)
        {
            SLT_Safety_Walk objSLT_Safety_Walk = new SLT_Safety_Walk(PK_SLT_Meeting_Schedule, true);
            objSLT_Safety_Walk.PK_SLT_Safety_Walk = PK_SLT_Safety_Walk;
            objSLT_Safety_Walk.FK_SLT_Meeting = PK_SLT_Meeting;
            objSLT_Safety_Walk.FK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;
            objSLT_Safety_Walk.Safety_Walk_Comp = rdoSafety_Walk_Comp.SelectedValue == "Y";
            objSLT_Safety_Walk.Safety_Walk_Comp_Date = clsGeneral.FormatNullDateToStore(txtSafety_Walk_Comp_Date.Text);
            objSLT_Safety_Walk.Sales_Reviewed = rdoSales_Reviewed.SelectedValue;
            objSLT_Safety_Walk.Sales_Deficiencies = rdoSales_Deficiencies.SelectedValue;
            objSLT_Safety_Walk.Sales_Comments = txtSales_Comments.Text.Trim();
            objSLT_Safety_Walk.Parts_Reviewed = rdoParts_Reviewed.SelectedValue;
            objSLT_Safety_Walk.Parts_Deficiencies = rdoParts_Deficiencies.SelectedValue;
            objSLT_Safety_Walk.Parts_Comments = txtParts_Comments.Text.Trim();
            objSLT_Safety_Walk.Service_Facility_Reviewed = rdoService_Facility_Reviewed.SelectedValue;
            objSLT_Safety_Walk.Service_Deficiencies = rdoService_Deficiencies.SelectedValue;
            objSLT_Safety_Walk.Service_Comments = txtService_Comments.Text.Trim();
            objSLT_Safety_Walk.Body_Shop_Reviewed = rdoBody_Shop_Reviewed.SelectedValue;
            objSLT_Safety_Walk.Body_Shop_Deficiencies = rdoBody_Shop_Deficiencies.SelectedValue;
            objSLT_Safety_Walk.Body_Shop_Comments = txtBody_Shop_Comments.Text.Trim();
            objSLT_Safety_Walk.Bus_Off_Reviewed = rdoBus_Off_Reviewed.SelectedValue;
            objSLT_Safety_Walk.Bus_Off_Deficiencies = rdoBus_Off_Deficiencies.SelectedValue;
            objSLT_Safety_Walk.Bus_Off_Comments = txtBus_Off_Comments.Text.Trim();
            objSLT_Safety_Walk.Detail_Area_Reviewed = rdoDetail_Area_Reviewed.SelectedValue;
            objSLT_Safety_Walk.Detail_Deficiencies = rdoDetail_Deficiencies.SelectedValue;
            objSLT_Safety_Walk.Detail_Comments = txtDetail_Comments.Text.Trim();
            objSLT_Safety_Walk.Car_Wash_Reviewed = rdoCar_Wash_Reviewed.SelectedValue;
            objSLT_Safety_Walk.Car_Wash_Deficiencies = rdoCar_Wash_Deficiencies.SelectedValue;
            objSLT_Safety_Walk.Car_Wash_Comments = txtCar_Wash_Comments.Text.Trim();
            objSLT_Safety_Walk.Parking_Lot_Reviewed = rdoParking_Lot_Reviewed.SelectedValue;
            objSLT_Safety_Walk.Parking_Deficiencies = rdoParking_Deficiencies.SelectedValue;
            objSLT_Safety_Walk.Parking_Comments = txtParking_Comments.Text.Trim();
            objSLT_Safety_Walk.Update_Date = System.DateTime.Now;
            objSLT_Safety_Walk.Updated_By = clsSession.UserID;
            //objSLT_Safety_Walk.UniqueVal = UniqueVal;
            if (PK_SLT_Safety_Walk > 0)
                objSLT_Safety_Walk.Update();
            else
                PK_SLT_Safety_Walk = objSLT_Safety_Walk.Insert();
            //SLT_Safety_Walk_Members.DeleteByFK(PK_SLT_Safety_Walk);
            foreach (GridViewRow gRow1 in gvSafetyWalk.Rows)
            {
                if (((HiddenField)(gRow1.FindControl("hdnFK_SLT_Member"))).Value != "")
                    PK_SLT_Member = Convert.ToDecimal(((HiddenField)(gRow1.FindControl("hdnFK_SLT_Member"))).Value);
                SLT_Safety_Walk_Members objSLT_Safety_Walk_Members = new SLT_Safety_Walk_Members(PK_SLT_Member, true, PK_SLT_Safety_Walk);
                objSLT_Safety_Walk_Members.FK_SLT_Safety_Walk = PK_SLT_Safety_Walk;
                objSLT_Safety_Walk_Members.FK_SLT_Members = PK_SLT_Member;
                objSLT_Safety_Walk_Members.Participated = ((RadioButtonList)(gRow1.FindControl("rdoParticipated"))).SelectedValue == "Y";
                if (objSLT_Safety_Walk_Members.PK_SLT_Safety_Walk_Members > 0)
                    objSLT_Safety_Walk_Members.Update();
                else
                    objSLT_Safety_Walk_Members.Insert();
            }

            GetSLT_Score();
            BindMeetingScheduleGrid();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);alert('Please add or select meeting agenda record');", true);
        }
        #endregion
    }

    private string SetYesNoNone(string Value)
    {
        string strYesNo = "";
        if (Value == "2")
            strYesNo = "None";
        else if (Value == "1")
            strYesNo = "Yes";
        else if (Value == "0")
            strYesNo = "No";
        else if (Value == "Y")
            strYesNo = "Yes";
        else if (Value == "N")
            strYesNo = "No";
        return strYesNo;
    }
    private void BindSafetyWalkDetails()
    {
        if (StrOperation.ToLower() != "view" && meetingIsEditable == true)
        {
            #region "SLT_Safety_Walk"
            SLT_Safety_Walk objSLT_Safety_Walk = new SLT_Safety_Walk(PK_SLT_Meeting_Schedule, true);
            PK_SLT_Safety_Walk = Convert.ToDecimal(objSLT_Safety_Walk.PK_SLT_Safety_Walk);
            if (objSLT_Safety_Walk.Safety_Walk_Comp != null) rdoSafety_Walk_Comp.SelectedValue = Convert.ToBoolean(objSLT_Safety_Walk.Safety_Walk_Comp) == true ? "Y" : "N";
            txtSafety_Walk_Comp_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Safety_Walk.Safety_Walk_Comp_Date);
            rdoSales_Reviewed.SelectedValue = objSLT_Safety_Walk.Sales_Reviewed == null ? "N" : objSLT_Safety_Walk.Sales_Reviewed;
            if (objSLT_Safety_Walk.Sales_Reviewed == "Y")
                trSales.Style.Add("display", "");
            else
                trSales.Style.Add("display", "none");

            rdoSales_Deficiencies.SelectedValue = objSLT_Safety_Walk.Sales_Deficiencies == null ? "2" : objSLT_Safety_Walk.Sales_Deficiencies;
            txtSales_Comments.Text = objSLT_Safety_Walk.Sales_Comments;
            rdoParts_Reviewed.SelectedValue = objSLT_Safety_Walk.Parts_Reviewed == null ? "N" : objSLT_Safety_Walk.Parts_Reviewed;
            if (objSLT_Safety_Walk.Parts_Reviewed == "Y")
                trParts.Style.Add("display", "");
            else
                trParts.Style.Add("display", "none");
            rdoParts_Deficiencies.SelectedValue = objSLT_Safety_Walk.Parts_Deficiencies == null ? "2" : objSLT_Safety_Walk.Parts_Deficiencies;
            txtParts_Comments.Text = objSLT_Safety_Walk.Parts_Comments;
            rdoService_Facility_Reviewed.SelectedValue = objSLT_Safety_Walk.Service_Facility_Reviewed == null ? "N" : objSLT_Safety_Walk.Service_Facility_Reviewed;
            if (objSLT_Safety_Walk.Service_Facility_Reviewed == "Y")
                trService.Style.Add("display", "");
            else
                trService.Style.Add("display", "none");
            rdoService_Deficiencies.SelectedValue = objSLT_Safety_Walk.Service_Deficiencies == null ? "2" : objSLT_Safety_Walk.Service_Deficiencies;
            txtService_Comments.Text = objSLT_Safety_Walk.Service_Comments;
            rdoBody_Shop_Reviewed.SelectedValue = objSLT_Safety_Walk.Body_Shop_Reviewed == null ? "N" : objSLT_Safety_Walk.Body_Shop_Reviewed;
            if (objSLT_Safety_Walk.Body_Shop_Reviewed == "Y")
                trBody_Shop.Style.Add("display", "");
            else
                trBody_Shop.Style.Add("display", "none");
            rdoBody_Shop_Deficiencies.SelectedValue = objSLT_Safety_Walk.Body_Shop_Deficiencies == null ? "2" : objSLT_Safety_Walk.Body_Shop_Deficiencies;
            txtBody_Shop_Comments.Text = objSLT_Safety_Walk.Body_Shop_Comments;
            rdoBus_Off_Reviewed.SelectedValue = objSLT_Safety_Walk.Bus_Off_Reviewed == null ? "N" : objSLT_Safety_Walk.Bus_Off_Reviewed;
            if (objSLT_Safety_Walk.Bus_Off_Reviewed == "Y")
                trBusiness.Style.Add("display", "");
            else
                trBusiness.Style.Add("display", "none");
            rdoBus_Off_Deficiencies.SelectedValue = objSLT_Safety_Walk.Bus_Off_Deficiencies == null ? "2" : objSLT_Safety_Walk.Bus_Off_Deficiencies;
            txtBus_Off_Comments.Text = objSLT_Safety_Walk.Bus_Off_Comments;
            rdoDetail_Area_Reviewed.SelectedValue = objSLT_Safety_Walk.Detail_Area_Reviewed == null ? "N" : objSLT_Safety_Walk.Detail_Area_Reviewed;
            if (objSLT_Safety_Walk.Detail_Area_Reviewed == "Y")
                trDetailArea.Style.Add("display", "");
            else
                trDetailArea.Style.Add("display", "none");
            rdoDetail_Deficiencies.SelectedValue = objSLT_Safety_Walk.Detail_Deficiencies == null ? "2" : objSLT_Safety_Walk.Detail_Deficiencies;
            txtDetail_Comments.Text = objSLT_Safety_Walk.Detail_Comments;
            rdoCar_Wash_Reviewed.SelectedValue = objSLT_Safety_Walk.Car_Wash_Reviewed == null ? "N" : objSLT_Safety_Walk.Car_Wash_Reviewed;
            if (objSLT_Safety_Walk.Car_Wash_Reviewed == "Y")
                trCarWash.Style.Add("display", "");
            else
                trCarWash.Style.Add("display", "none");
            rdoCar_Wash_Deficiencies.SelectedValue = objSLT_Safety_Walk.Car_Wash_Deficiencies == null ? "2" : objSLT_Safety_Walk.Car_Wash_Deficiencies;
            txtCar_Wash_Comments.Text = objSLT_Safety_Walk.Car_Wash_Comments;
            rdoParking_Lot_Reviewed.SelectedValue = objSLT_Safety_Walk.Parking_Lot_Reviewed == null ? "N" : objSLT_Safety_Walk.Parking_Lot_Reviewed;
            if (objSLT_Safety_Walk.Parking_Lot_Reviewed == "Y")
                trParking.Style.Add("display", "");
            else
                trParking.Style.Add("display", "none");
            rdoParking_Deficiencies.SelectedValue = objSLT_Safety_Walk.Parking_Deficiencies == null ? "2" : objSLT_Safety_Walk.Parking_Deficiencies;
            txtParking_Comments.Text = objSLT_Safety_Walk.Parking_Comments;

            #endregion
        }
        else
        {
            #region "Slt_saftyWalk"
            SLT_Safety_Walk objSLT_Safety_Walk = new SLT_Safety_Walk(PK_SLT_Meeting_Schedule, true);
            PK_SLT_Safety_Walk = Convert.ToDecimal(objSLT_Safety_Walk.PK_SLT_Safety_Walk);
            lblSafety_Walk_Comp.Text = Convert.ToBoolean(objSLT_Safety_Walk.Safety_Walk_Comp) == true ? "Yes" : "No";
            lblSafety_Walk_Comp_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Safety_Walk.Safety_Walk_Comp_Date);
            lblSales_Reviewed.Text = objSLT_Safety_Walk.Sales_Reviewed == "Y" ? "Yes" : "No";
            if (objSLT_Safety_Walk.Sales_Reviewed == "Y")
                trSalesView.Style.Add("display", "");
            else
                trSalesView.Style.Add("display", "none");
            lblSales_Deficiencies.Text = objSLT_Safety_Walk.Sales_Deficiencies == null ? " " : SetYesNoNone(objSLT_Safety_Walk.Sales_Deficiencies);
            lblSales_Comments.Text = objSLT_Safety_Walk.Sales_Comments;
            lblParts_Reviewed.Text = objSLT_Safety_Walk.Parts_Reviewed == "Y" ? "Yes" : "No";
            if (objSLT_Safety_Walk.Parts_Reviewed == "Y")
                trPartsView.Style.Add("display", "");
            else
                trPartsView.Style.Add("display", "none");
            lblParts_Deficiencies.Text = objSLT_Safety_Walk.Parts_Deficiencies == null ? " " : SetYesNoNone(objSLT_Safety_Walk.Parts_Deficiencies);
            lblParts_Comments.Text = objSLT_Safety_Walk.Parts_Comments;
            lblService_Facility_Reviewed.Text = objSLT_Safety_Walk.Service_Facility_Reviewed == "Y" ? "Yes" : "No";
            if (objSLT_Safety_Walk.Service_Facility_Reviewed == "Y")
                trServiceView.Style.Add("display", "");
            else
                trServiceView.Style.Add("display", "none");
            lblService_Deficiencies.Text = objSLT_Safety_Walk.Service_Deficiencies == null ? " " : SetYesNoNone(objSLT_Safety_Walk.Service_Deficiencies);
            lblService_Comments.Text = objSLT_Safety_Walk.Service_Comments;
            lblBody_Shop_Reviewed.Text = objSLT_Safety_Walk.Body_Shop_Reviewed == "Y" ? "Yes" : "No";
            if (objSLT_Safety_Walk.Body_Shop_Reviewed == "Y")
                trBody_ShopView.Style.Add("display", "");
            else
                trBody_ShopView.Style.Add("display", "none");
            lblBody_Shop_Deficiencies.Text = objSLT_Safety_Walk.Body_Shop_Deficiencies == null ? " " : SetYesNoNone(objSLT_Safety_Walk.Body_Shop_Deficiencies);
            lblBody_Shop_Comments.Text = objSLT_Safety_Walk.Body_Shop_Comments;
            lblBus_Off_Reviewed.Text = objSLT_Safety_Walk.Bus_Off_Reviewed == "Y" ? "Yes" : "No";
            if (objSLT_Safety_Walk.Bus_Off_Reviewed == "Y")
                trBusinessView.Style.Add("display", "");
            else
                trBusinessView.Style.Add("display", "none");
            lblBus_Off_Deficiencies.Text = objSLT_Safety_Walk.Bus_Off_Deficiencies == null ? " " : SetYesNoNone(objSLT_Safety_Walk.Bus_Off_Deficiencies);
            lblBus_Off_Comments.Text = objSLT_Safety_Walk.Bus_Off_Comments;
            lblDetail_Area_Reviewed.Text = objSLT_Safety_Walk.Detail_Area_Reviewed == "Y" ? "Yes" : "No";
            if (objSLT_Safety_Walk.Detail_Area_Reviewed == "Y")
                trDetailAreaView.Style.Add("display", "");
            else
                trDetailAreaView.Style.Add("display", "none");
            lblDetail_Deficiencies.Text = objSLT_Safety_Walk.Detail_Deficiencies == null ? " " : SetYesNoNone(objSLT_Safety_Walk.Detail_Deficiencies);
            lblDetail_Comments.Text = objSLT_Safety_Walk.Detail_Comments;
            lblCar_Wash_Reviewed.Text = objSLT_Safety_Walk.Car_Wash_Reviewed == "Y" ? "Yes" : "No";
            if (objSLT_Safety_Walk.Car_Wash_Reviewed == "Y")
                trCarWashView.Style.Add("display", "");
            else
                trCarWashView.Style.Add("display", "none");
            lblCar_Wash_Deficiencies.Text = objSLT_Safety_Walk.Car_Wash_Deficiencies == null ? " " : SetYesNoNone(objSLT_Safety_Walk.Car_Wash_Deficiencies);
            lblCar_Wash_Comments.Text = objSLT_Safety_Walk.Car_Wash_Comments;
            lblParking_Lot_Reviewed.Text = objSLT_Safety_Walk.Parking_Lot_Reviewed == "Y" ? "Yes" : "No";
            if (objSLT_Safety_Walk.Parking_Lot_Reviewed == "Y")
                trParkingView.Style.Add("display", "");
            else
                trParkingView.Style.Add("display", "none");
            lblParking_Deficiencies.Text = objSLT_Safety_Walk.Parking_Deficiencies == null ? " " : SetYesNoNone(objSLT_Safety_Walk.Parking_Deficiencies);
            lblParking_Comments.Text = objSLT_Safety_Walk.Parking_Comments;

            #endregion
        }
        BindSafetyWalkAttachment();
    }
    #endregion
    #region "NewProcedures"
    private void BindGridNewProcedures()
    {
        if (StrOperation != "view" && meetingIsEditable == true)
        {
            DataTable dtProcedure = SLT_New_Procedure.SelectByFK(PK_SLT_Meeting_Schedule, Convert.ToInt32(drpProcedureYear.SelectedValue)).Tables[0];
            gvNewProcedures.DataSource = dtProcedure;
            gvNewProcedures.DataBind();
            btnNewProcedureAudit_Edit.Visible = false;
            btnNewProcedureAudit_View.Visible = true;
        }
        else
        {
            BindDropDownsForView();
            DataTable dtProcedure = SLT_New_Procedure.SelectByFK(PK_SLT_Meeting_Schedule, Convert.ToInt32(drpProcedureYearView.SelectedValue)).Tables[0];
            gvNewProceduresView.DataSource = dtProcedure;
            gvNewProceduresView.DataBind();
            btnNewProcedureAudit_Edit.Visible = true;
            btnNewProcedureAudit_View.Visible = false;
        }
    }
    private void SaveProcedure(string Pnl)
    {
        #region "SLT_New_Procedure"
        if (tr_procedureAdd.Style["display"] == "")
        {
            SLT_New_Procedure objSLT_New_Procedure = new SLT_New_Procedure(PK_SLT_New_Procedure);
            objSLT_New_Procedure.PK_SLT_New_Procedure = PK_SLT_New_Procedure;
            objSLT_New_Procedure.FK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;
            objSLT_New_Procedure.FK_SLT_Meeting = PK_SLT_Meeting;
            if (drpFK_LU_Importance.SelectedIndex > 0) objSLT_New_Procedure.FK_LU_Importance = Convert.ToDecimal(drpFK_LU_Importance.SelectedValue);
            else objSLT_New_Procedure.FK_LU_Importance = null;
            if (drpFK_LU_Procedure_Source.SelectedIndex > 0) objSLT_New_Procedure.FK_LU_Procedure_Source = Convert.ToDecimal(drpFK_LU_Procedure_Source.SelectedValue);
            else objSLT_New_Procedure.FK_LU_Procedure_Source = null;
            objSLT_New_Procedure.Procedure_Description = txtProcedure_Description.Text.Trim();
            objSLT_New_Procedure.Action_Item = txtAction_Item.Text.Trim();
            if (drpProcedureAssignet_to.SelectedIndex > 0)
                objSLT_New_Procedure.Assigned_To = Convert.ToDecimal(drpProcedureAssignet_to.SelectedValue);
            else objSLT_New_Procedure.Assigned_To = null;
            objSLT_New_Procedure.Target_Completion_Date = clsGeneral.FormatNullDateToStore(txtTarget_Completion_Date.Text);
            objSLT_New_Procedure.Date_Completed = clsGeneral.FormatNullDateToStore(txtDate_Completed.Text);
            if (drpFK_LU_Item_Status.SelectedIndex > 0) objSLT_New_Procedure.FK_LU_Item_Status = Convert.ToDecimal(drpFK_LU_Item_Status.SelectedValue);
            else objSLT_New_Procedure.FK_LU_Item_Status = null;
            if (PK_SLT_New_Procedure == 0) objSLT_New_Procedure.Year = Convert.ToInt32(DateTime.Now.Year);
            objSLT_New_Procedure.Update_Date = System.DateTime.Now;
            objSLT_New_Procedure.Updated_By = clsSession.UserID;
            if (PK_SLT_New_Procedure > 0)
                objSLT_New_Procedure.Update();
            else
                PK_SLT_New_Procedure = objSLT_New_Procedure.Insert();
            btnNewProcedureAudit_Edit.Visible = true;
        }
        tr_procedureAdd.Style.Add("display", "none");
        BindGridNewProcedures();
        #endregion

        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + Pnl + ");", true);
    }
    private void ClearNewProcedure()
    {
        PK_SLT_New_Procedure = 0;
        drpFK_LU_Importance.SelectedIndex = -1;
        drpFK_LU_Procedure_Source.SelectedIndex = -1;
        txtAction_Item.Text = "";
        txtTarget_Completion_Date.Text = "";
        txtDate_Completed.Text = "";
        drpProcedureAssignet_to.SelectedIndex = -1;
        drpFK_LU_Item_Status.SelectedIndex = -1;
        txtProcedure_Description.Text = "";
    }
    #endregion
    #region "Suggestions"
    private void BindGridSuggestions()
    {
        DataTable dtSuggestion = SLT_Suggestion.SelectByFK(PK_SLT_Meeting_Schedule).Tables[0];
        if (StrOperation != "view" && meetingIsEditable == true)
        {
            gvSuggestions.DataSource = dtSuggestion;
            gvSuggestions.DataBind();
            btnSuggestionAudit_Edit.Visible = false;
            btnSuggestionAudit_View.Visible = true;
        }
        else
        {
            gvSuggestionsView.DataSource = dtSuggestion;
            gvSuggestionsView.DataBind();
            btnSuggestionAudit_Edit.Visible = true;
            btnSuggestionAudit_View.Visible = false;
        }
    }
    private void SaveSuggestion(string Pnl)
    {
        #region "SLT_Suggestion"
        if (tr_suggestionadd.Style["display"] == "")
        {
            SLT_Suggestion objSLT_Suggestion = new SLT_Suggestion(PK_SLT_Suggestion);
            objSLT_Suggestion.PK_SLT_Suggestion = PK_SLT_Suggestion;
            objSLT_Suggestion.FK_SLT_Meeting = PK_SLT_Meeting;
            objSLT_Suggestion.FK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;
            if (DrpAssigned_To_Sugg.SelectedIndex > 0)
                objSLT_Suggestion.Assigned_To = Convert.ToDecimal(DrpAssigned_To_Sugg.SelectedValue);
            else
                objSLT_Suggestion.Assigned_To = null;
            if (drpFK_LU_Suggestion_Source.SelectedIndex > 0) objSLT_Suggestion.FK_LU_Suggestion_Source = Convert.ToDecimal(drpFK_LU_Suggestion_Source.SelectedValue);
            else objSLT_Suggestion.FK_LU_Suggestion_Source = null;
            if (drpFK_LU_Importance_Sugg.SelectedIndex > 0) objSLT_Suggestion.FK_LU_Importance = Convert.ToDecimal(drpFK_LU_Importance_Sugg.SelectedValue);
            else objSLT_Suggestion.FK_LU_Importance = null;
            objSLT_Suggestion.Target_Completion_Date = clsGeneral.FormatNullDateToStore(txtTarget_Completion_Date_Sugg.Text);
            objSLT_Suggestion.Suggestion_Description = txtSuggestion_Description.Text.Trim();
            objSLT_Suggestion.Action_Item = txtAction_Item_Sugg.Text.Trim();
            objSLT_Suggestion.Date_Completed = clsGeneral.FormatNullDateToStore(txtDate_Completed_Sugg.Text);
            if (drpFK_LU_Item_Status_Sugg.SelectedIndex > 0) objSLT_Suggestion.FK_LU_Item_Status = Convert.ToDecimal(drpFK_LU_Item_Status_Sugg.SelectedValue);
            else objSLT_Suggestion.FK_LU_Item_Status = null;
            objSLT_Suggestion.Update_Date = System.DateTime.Now;
            objSLT_Suggestion.Updated_By = clsSession.UserID;
            if (PK_SLT_Suggestion > 0)
                objSLT_Suggestion.Update();
            else
                PK_SLT_Suggestion = objSLT_Suggestion.Insert();
            btnSuggestionAudit_Edit.Visible = true;
        }
        BindGridSuggestions();
        tr_suggestionadd.Style.Add("display", "none");
        #endregion

        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + Pnl + ");", true);
    }
    private void ClearSuggestionControls()
    {
        PK_SLT_Suggestion = 0;
        DrpAssigned_To_Sugg.SelectedIndex = -1;
        drpFK_LU_Suggestion_Source.SelectedIndex = -1;
        drpFK_LU_Importance_Sugg.SelectedIndex = -1;
        txtTarget_Completion_Date_Sugg.Text = "";
        txtSuggestion_Description.Text = "";
        txtAction_Item_Sugg.Text = "";
        txtDate_Completed_Sugg.Text = "";
        drpFK_LU_Item_Status_Sugg.SelectedIndex = -1;
    }
    #endregion
    #region "Inspection"
    private void BindGridInspection()
    {
        int intQuarter = 0;
        int intYear = (StrOperation != "view" && meetingIsEditable == true) ? Convert.ToInt32(drpYearInspection.SelectedItem.Text) : Convert.ToInt32(drpYearInspectionView.SelectedItem.Text);
        DataTable dtInspection = SLT_Quarterly_Inspections.SelectQuarterlyInspections(FK_LU_Location_ID, intQuarter, intYear, null).Tables[0];
        if (StrOperation != "view" && meetingIsEditable == true)
        {
            gvInspection.DataSource = dtInspection;
            gvInspection.DataBind();

            lblInspectorName.Text = lblInspectionDate.Text = lblDeficiencies.Text = lblDeficienciesNotCompleted.Text = "";
        }
        else
        {
            gvInspectionView.DataSource = dtInspection;
            gvInspectionView.DataBind();

            lblInspectorNameView.Text = lblInspectionDateView.Text = lblDeficienciesView.Text = lblDeficienciesNotCompletedView.Text = "";
        }


    }
    private void BindInspection_ResponseGrid()
    {
        DataTable dtResponse = SLT_Quarterly_Inspections.SelectQuarterlyInspection_Responses(PK_Inspection_ID).Tables[0];
        if (StrOperation.ToLower() != "view" && meetingIsEditable == true)
        {
            gvInspection_responses.DataSource = dtResponse;
            gvInspection_responses.DataBind();
            DataTable dtDepartment = LU_Department.SelectAll().Tables[0];
            dtDepartment.DefaultView.RowFilter = " Description not in ('General Manager', 'Controller')";
            dtDepartment = dtDepartment.DefaultView.ToTable();
            rptDepartment.DataSource = dtDepartment;
            rptDepartment.DataBind();
            lblResponse_Deficiency.Text = lblRepeated_Deficiency.Text = lblResponse_Date_Opned.Text = lblAction.Text = lblTargetCompletion_date.Text = lblActual_completion_Date.Text = lblNotes.Text = "";
            lblResponse_FocusArea.Text = lblDays_Open.Text = "";
            if (dtResponse.Rows.Count > 0)
            {
                //btnInspection_Save.Enabled = true;
                btnInspectionAudit_view.Visible = true;
                #region "Bind FirstRecord"
                #endregion
            }
            else
            {
                // btnInspection_Save.Enabled = false;
                btnInspectionAudit_view.Visible = false;
                foreach (DataListItem rptItm in rptDepartment.Items)
                {
                    HtmlInputHidden hdnDeptID = (HtmlInputHidden)rptItm.FindControl("hdnDeptID");
                    Label lblValue = (Label)rptItm.FindControl("lblValue");
                    lblValue.Text = "No";

                }
            }
        }
        else
        {
            gvInspection_responsesView.DataSource = dtResponse;
            gvInspection_responsesView.DataBind();
            DataTable dtDepartment = LU_Department.SelectAll().Tables[0];
            dtDepartment.DefaultView.RowFilter = " Description not in ('General Manager', 'Controller')";
            dtDepartment = dtDepartment.DefaultView.ToTable();
            rptdepartmentview.DataSource = dtDepartment;
            rptdepartmentview.DataBind();
            lblresponse_Deficiencyview.Text = lblRepeat_Deficiencyview.Text = lblDate_openedview.Text = lblRecc_Action_View.Text = lblTar_comp_dateview.Text = lblAct_com_dateview.Text = lblnotesview.Text = "";
            lblResponseFocus_AreaView.Text = lblDaysopenView.Text = "";
            if (dtResponse.Rows.Count > 0)
            {
                #region "Bind First Record"
                #endregion
            }
            else
            {
                foreach (DataListItem rptItm in rptdepartmentview.Items)
                {
                    HtmlInputHidden hdnDeptID = (HtmlInputHidden)rptItm.FindControl("hdnDeptID");
                    Label lblValue = (Label)rptItm.FindControl("lblValue");
                    lblValue.Text = "No";


                }
            }
        }
    }
    private void BindInspectionEditDetails()
    {
        BindAssignedToDropDowns();
        if (PK_Inspection_ID > 0 && FK_Inspection_Responses_ID > 0)
        {
            SLT_Quarterly_Inspections objSLT_Quarterly_Inspections = new SLT_Quarterly_Inspections(PK_Inspection_ID, FK_Inspection_Responses_ID, PK_SLT_Meeting_Schedule);
            if (objSLT_Quarterly_Inspections.PK_SLT_Quarterly_Inspections > 0)
                PK_SLT_Quarterly_Inspections = Convert.ToDecimal(objSLT_Quarterly_Inspections.PK_SLT_Quarterly_Inspections);
            if (objSLT_Quarterly_Inspections.FK_SLT_Members != null)
            {
                ListItem lst = drpFK_SLT_Members.Items.FindByValue(objSLT_Quarterly_Inspections.FK_SLT_Members.ToString());
                if (lst != null)
                    lst.Selected = true;
            }
            else
                drpFK_SLT_Members.SelectedIndex = 0;
            txtDate_Completed_Inspection.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Quarterly_Inspections.Date_Completed);
            txtComments_Inspection.Text = objSLT_Quarterly_Inspections.Comments;
            rdoRLCM_Notified.SelectedValue = Convert.ToBoolean(objSLT_Quarterly_Inspections.RLCM_Notified) == true ? "Y" : "N";
            if (objSLT_Quarterly_Inspections.PK_SLT_Quarterly_Inspections > 0)
                btnInspectionAudit_Edit.Visible = true;
            else
                btnInspectionAudit_Edit.Visible = false;
        }
        else
        {
            drpFK_SLT_Members.SelectedIndex = 0;
            txtDate_Completed_Inspection.Text = "";
            txtComments_Inspection.Text = "";
            rdoRLCM_Notified.SelectedValue = "N";
            PK_SLT_Quarterly_Inspections = 0;
        }

    }
    private void BindInspectionView()
    {
        if (PK_Inspection_ID > 0 && FK_Inspection_Responses_ID > 0)
        {
            SLT_Quarterly_Inspections objSLT_Quarterly_Inspections = new SLT_Quarterly_Inspections(PK_Inspection_ID, FK_Inspection_Responses_ID, PK_SLT_Meeting_Schedule);
            if (objSLT_Quarterly_Inspections.FK_SLT_Members != null)
            {
                SLT_Members objSLT_Members = new SLT_Members(Convert.ToDecimal(objSLT_Quarterly_Inspections.FK_SLT_Members));
                lblFK_SLT_Members.Text = objSLT_Members.First_Name + " " + objSLT_Members.Last_Name;

            }
            else
                lblFK_SLT_Members.Text = "";

            lblDate_Completed_Inspection.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Quarterly_Inspections.Date_Completed);
            lblComments_Inspection.Text = objSLT_Quarterly_Inspections.Comments;
            lblRLCM_Notified.Text = Convert.ToBoolean(objSLT_Quarterly_Inspections.RLCM_Notified) == true ? "Yes" : "No";
            if (objSLT_Quarterly_Inspections.PK_SLT_Quarterly_Inspections > 0)
                btnInspectionAudit_view.Visible = true;
            else
                btnInspectionAudit_view.Visible = false;
        }
        else
        {
            lblFK_SLT_Members.Text = "";
            lblDate_Completed_Inspection.Text = "";
            lblComments_Inspection.Text = "";
            lblRLCM_Notified.Text = "";
            PK_SLT_Quarterly_Inspections = 0;
        }
    }
    private void ClearInspectionControls()
    {
        if (StrOperation.ToLower() != "view")
        {
            gvInspection_responses.DataBind();
            foreach (Control ctrl in pnl6.Controls)
            {
                if (ctrl.GetType() == typeof(Label))
                    ((Label)ctrl).Text = "";
            }
            foreach (DataListItem rptItm in rptDepartment.Items)
            {
                Label lblValue = (Label)rptItm.FindControl("lblValue");
                lblValue.Text = "No";
            }
            PK_Inspection_ID = 0;
            FK_Inspection_Responses_ID = 0;
            drpFK_SLT_Members.SelectedIndex = 0;
            txtDate_Completed_Inspection.Text = "";
            txtComments_Inspection.Text = "";
            rdoRLCM_Notified.SelectedValue = "N";
            btnInspectionAudit_Edit.Visible = false;
        }
        else
        {
            gvInspection_responsesView.DataBind();
            PK_Inspection_ID = 0;
            FK_Inspection_Responses_ID = 0;
            foreach (Control ctrl in pnl6View.Controls)
            {
                if (ctrl.GetType() == typeof(Label))
                    ((Label)ctrl).Text = "";
            }
            foreach (DataListItem rptItm in rptdepartmentview.Items)
            {
                Label lblValue = (Label)rptItm.FindControl("lblValue");
                lblValue.Text = "No";
            }
            lblFK_SLT_Members.Text = "";
            lblDate_Completed_Inspection.Text = "";
            lblComments_Inspection.Text = "";
            lblRLCM_Notified.Text = "";
            btnInspectionAudit_view.Visible = false;
        }
    }

    private void SaveInspection(string Pnl)
    {
        #region "SLT_Quaterly_inspection"
        if (PK_Inspection_ID > 0 && FK_Inspection_Responses_ID > 0)
        {
            SLT_Quarterly_Inspections objSLT_Quarterly_Inspections = new SLT_Quarterly_Inspections(PK_Inspection_ID, FK_Inspection_Responses_ID, PK_SLT_Meeting_Schedule);
            objSLT_Quarterly_Inspections.FK_SLT_Meeting = PK_SLT_Meeting;
            objSLT_Quarterly_Inspections.FK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;
            objSLT_Quarterly_Inspections.FK_Inspection_ID = PK_Inspection_ID;
            objSLT_Quarterly_Inspections.FK_Inspection_Responses_ID = FK_Inspection_Responses_ID;
            // objSLT_Quarterly_Inspections.PK_SLT_Quarterly_Inspections = PK_SLT_Quarterly_Inspections;
            if (drpFK_SLT_Members.SelectedIndex > 0) objSLT_Quarterly_Inspections.FK_SLT_Members = Convert.ToDecimal(drpFK_SLT_Members.SelectedValue);
            objSLT_Quarterly_Inspections.Date_Completed = clsGeneral.FormatNullDateToStore(txtDate_Completed_Inspection.Text);
            objSLT_Quarterly_Inspections.Comments = txtComments_Inspection.Text.Trim();
            objSLT_Quarterly_Inspections.RLCM_Notified = rdoRLCM_Notified.SelectedValue == "Y";
            objSLT_Quarterly_Inspections.Update_Date = System.DateTime.Now;
            objSLT_Quarterly_Inspections.Updated_By = clsSession.UserID;
            if (objSLT_Quarterly_Inspections.PK_SLT_Quarterly_Inspections > 0)
            {
                objSLT_Quarterly_Inspections.Update();
            }
            else
                PK_SLT_Quarterly_Inspections = objSLT_Quarterly_Inspections.Insert();
            BindInspectionEditDetails();
            btnInspectionAudit_Edit.Visible = true;
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + Pnl + ");", true);
        }
        else
        {
            if (Pnl == "7")
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + Pnl + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(6);alert('Please select inspection and focus area');", true);
        }

        #endregion
    }
    #endregion
    #region "Claim Management"
    private void BindClaimManagementGrid()
    {

        if (StrOperation != "view" && meetingIsEditable == true)
        {
            DataTable DtClaim_Management = SLT_Claims_Management.SelectWCClaims(Convert.ToInt32(FK_LU_Location_ID)).Tables[0];
            gvClaim_management.DataSource = DtClaim_Management;
            gvClaim_management.DataBind();
            FK_Claim = 0;
            lblClaim_Number.Text = lblClaimant_name.Text = lblDate_of_incident.Text = lblDate_reported.Text = lblLagtime.Text = lblClaim_Status.Text = lblCause_injury_desc.Text = "";
        }
        else
        {
            DataTable DtClaim_ManagementView = SLT_Claims_Management.SelectWCClaims(Convert.ToInt32(FK_LU_Location_ID)).Tables[0];
            gvClaim_managemetview.DataSource = DtClaim_ManagementView;
            gvClaim_managemetview.DataBind();
            lblCliam_numberview.Text = lblclaimant_view.Text = lblIncident_date_view.Text = lblDate_reportedview.Text = lbllagtimeview.Text = lblClaim_statusView.Text = lblCause_InjuryView.Text = "";

        }
        ClearClaimManagementControls();
    }

    private void SaveClaimManagement(string pnl)
    {
        #region"SLT_Claims_Management"
        if (FK_Claim > 0)
        {
            SLT_Claims_Management objSLT_Claims_Management = new SLT_Claims_Management(PK_SLT_Meeting, FK_Claim, true);
            objSLT_Claims_Management.PK_SLT_Claims_Mangement = PK_SLT_Claims_Mangement;
            objSLT_Claims_Management.FK_Claim = FK_Claim;
            objSLT_Claims_Management.FK_SLT_Meeting = PK_SLT_Meeting;
            objSLT_Claims_Management.FK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;
            objSLT_Claims_Management.Lag_Explaination = txtLag_explaination.Text;
            if (drpAssociates_Status.SelectedIndex > 0)
                objSLT_Claims_Management.FK_LU_Work_Status = Convert.ToDecimal(drpAssociates_Status.SelectedValue);
            objSLT_Claims_Management.Light_Duty_Explaination = txtLight_Duty.Text;
            objSLT_Claims_Management.Comments = txtComments.Text;
            objSLT_Claims_Management.Update_Date = System.DateTime.Now;
            objSLT_Claims_Management.Updated_By = clsSession.UserID;
            objSLT_Claims_Management.UniqueVal = UniqueVal;
            if (PK_SLT_Claims_Mangement > 0)
                objSLT_Claims_Management.Update();
            else
                PK_SLT_Claims_Mangement = objSLT_Claims_Management.Insert();
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + pnl + ");", true);


        #endregion
    }
    private void BindClaimManagementDetails()
    {
        #region "SLT_Claim_management"
        LU_Location objLU_Location = new LU_Location(FK_LU_Location_ID);
        int Year = Convert.ToInt32(DateTime.Now.Year);
        string Region = objLU_Location.Region;
        SLT_Claims_Management objSLT_Claims_Management = new SLT_Claims_Management(PK_SLT_Meeting, FK_Claim, true);
        PK_SLT_Claims_Mangement = Convert.ToDecimal(objSLT_Claims_Management.PK_SLT_Claims_Mangement);
        if (StrOperation.ToLower() != "view" && meetingIsEditable == true)
        {
            #region "SLT_Claim_management edit"

            txtLag_explaination.Text = objSLT_Claims_Management.Lag_Explaination;
            if (objSLT_Claims_Management.FK_LU_Work_Status != null)
                drpAssociates_Status.SelectedValue = objSLT_Claims_Management.FK_LU_Work_Status.ToString();
            else
                drpAssociates_Status.SelectedIndex = -1;
            txtLight_Duty.Text = objSLT_Claims_Management.Light_Duty_Explaination;
            txtComments.Text = objSLT_Claims_Management.Comments;

            DataSet dsReport = Charts.GetWCClaimMgmtByLocation(Year, Region);
            DataTable dtReport = dsReport.Tables[0];
            if (dtReport.Rows.Count > 0)
            {
                int Score = Convert.ToInt32(dtReport.Rows[0]["Score"]);
                switch (Score)
                {
                    case 4: lblDealershipScore.Text = "Spectator"; break;
                    case 10: lblDealershipScore.Text = "Water boy"; break;
                    case 16: lblDealershipScore.Text = "Second String"; break;
                    case 22: lblDealershipScore.Text = "Starter"; break;
                    case 28: lblDealershipScore.Text = "All Pro"; break;
                }
            }
            else
                lblDealershipScore.Text = "";
            #endregion
        }
        else
        {
            #region "SLT_Claim_management view"

            lblLagExplainationView.Text = objSLT_Claims_Management.Lag_Explaination;
            if (objSLT_Claims_Management.FK_LU_Work_Status != null)
                lblAssociates_Status.Text = new LU_Work_Status((decimal)objSLT_Claims_Management.FK_LU_Work_Status).Fld_Desc;
            else
                lblAssociates_Status.Text = "";
            lblLight_duty.Text = objSLT_Claims_Management.Light_Duty_Explaination;
            lblComments.Text = objSLT_Claims_Management.Comments;

            DataSet dsReport = Charts.GetWCClaimMgmtByLocation(Year, Region);
            DataTable dtReport = dsReport.Tables[0];
            if (dtReport != null)
            {
                int Score = Convert.ToInt32(dtReport.Rows[0]["Score"]);
                switch (Score)
                {
                    case 4: lblDealershipview.Text = "Spectator"; break;
                    case 10: lblDealershipview.Text = "Water boy"; break;
                    case 16: lblDealershipview.Text = "Second String"; break;
                    case 22: lblDealershipview.Text = "Starter"; break;
                    case 28: lblDealershipview.Text = "All Pro"; break;
                }
            }
            else
                lblDealershipview.Text = "";
            #endregion
        }
        #endregion
    }
    private void ClearClaimManagementControls()
    {
        PK_SLT_Claims_Mangement = 0;
        if (StrOperation.ToLower() != "view")
        {
            txtLag_explaination.Text = "";
            txtLight_Duty.Text = "";
            txtComments.Text = "";
            drpAssociates_Status.SelectedIndex = -1;
        }
        else
        {
            lblLagExplainationView.Text = "";
            lblLight_duty.Text = "";
            lblComments.Text = "";
            lblAssociates_Status.Text = "";
        }
    }
    #endregion
    #region "Slt Training"
    private void ShowTraining_QuarterResults()
    {
        string strRegion = "";
        int intYear = 0;
        BindDropDownsForView();
        LU_Location objLU_Location = new LU_Location(FK_LU_Location_ID);
        string Sonic_Location_Code = Convert.ToString(objLU_Location.Sonic_Location_Code);
        string DBA = objLU_Location.dba;
        if (StrOperation != "view" && meetingIsEditable == true)
        {
            strRegion = ""; // drpLocationStatus.SelectedIndex > 0 ? drpLocationStatus.SelectedValue : "";
            intYear = Convert.ToInt32(drpTrainingYear.SelectedValue);
            DataSet dsDetailTraining = Charts.GetSabaTrainingDetail(intYear, DBA, Sonic_Location_Code);
            if (dsDetailTraining.Tables[0].Rows.Count > 0)
            {
                lblTrainingScore.Text = Convert.ToString(dsDetailTraining.Tables[0].Rows[0]["Score"]);
            }
            else
                lblTrainingScore.Text = "All Pro";
        }
        else
        {
            strRegion = ""; // drpLocationStatusView.SelectedIndex > 0 ? drpLocationStatusView.SelectedValue : "";
            intYear = Convert.ToInt32(drpTrainingYearView.SelectedValue);
            DataSet dsDetailTraining = Charts.GetSabaTrainingDetail(intYear, DBA, Sonic_Location_Code);
            if (dsDetailTraining.Tables[0].Rows.Count > 0)
            {
                lblTrainingScoreView.Text = Convert.ToString(dsDetailTraining.Tables[0].Rows[0]["Score"]);
            }
            else
                lblTrainingScoreView.Text = "All Pro";
        }

        DataTable dtResult = SLT_Training.SelectQuarterResults(FK_LU_Location_ID, intYear).Tables[0];
        DataRow[] drQ1 = dtResult.Select("Quarter = 'Q1'");
        DataRow[] drQ2 = dtResult.Select("Quarter = 'Q2'");
        DataRow[] drQ3 = dtResult.Select("Quarter = 'Q3'");
        DataRow[] drQ4 = dtResult.Select("Quarter = 'Q4'");
        if (StrOperation != "view" && meetingIsEditable == true)
        {
            lblTrainingQ1.Text = Convert.ToString(drQ1[0][1]) + "%";
            lblTrainingQ2.Text = Convert.ToString(drQ2[0][1]) + "%";
            lblTrainingQ3.Text = Convert.ToString(drQ3[0][1]) + "%";
            lblTrainingQ4.Text = Convert.ToString(drQ4[0][1]) + "%";
        }
        else
        {
            lblTrainingQ1View.Text = Convert.ToString(drQ1[0][1]) + "%";
            lblTrainingQ2View.Text = Convert.ToString(drQ2[0][1]) + "%";
            lblTrainingQ3View.Text = Convert.ToString(drQ3[0][1]) + "%";
            lblTrainingQ4View.Text = Convert.ToString(drQ4[0][1]) + "%";
        }
    }

    private void BindTrainingConducted_ByRLCM()
    {
        if (StrOperation != "view" && meetingIsEditable == true)
        {
            DataTable dtRLCMTraining = clsSLT_Training_RLCM.SelectRLCMTrainingByLocationAndYear(FK_LU_Location_ID, Convert.ToInt32(drpTrainingYear.SelectedItem.Text)).Tables[0];

            gvQuarterly_TrainingConducted_ByRLCM.DataSource = dtRLCMTraining;
            gvQuarterly_TrainingConducted_ByRLCM.DataBind();
        }
        else
        {
            DataTable dtRLCMTraining = clsSLT_Training_RLCM.SelectRLCMTrainingByLocationAndYear(FK_LU_Location_ID, Convert.ToInt32(drpTrainingYearView.SelectedItem.Text)).Tables[0];
            gvQuarterly_TrainingConducted_ByRLCMView.DataSource = dtRLCMTraining;
            gvQuarterly_TrainingConducted_ByRLCMView.DataBind();
        }
    }

    private void BindGridTrainingSuggstions()
    {
        DataTable dtTrainSugg = SLT_Training.SelectByFK(PK_SLT_Meeting_Schedule).Tables[0];

        if (StrOperation != "view" && meetingIsEditable == true)
        {
            gvTrainingSuggestions.DataSource = dtTrainSugg;
            gvTrainingSuggestions.DataBind();
        }
        else
        {
            gvTrainingSuggestionsView.DataSource = dtTrainSugg;
            gvTrainingSuggestionsView.DataBind();
        }
    }

    private void ClearTrainingSuggstionFields()
    {
        txtTraining_Description.Text = "";
        txtDesired_Comp_Date.Text = "";
        rdoCompleted.SelectedValue = "N";
        txtDate_Completed_Training.Text = "";
        txtComments_Training.Text = "";
        PK_SLT_Training = 0;
    }

    private void BindTrainingAttachment()
    {
        DataTable dtAttachment = ERIMSAttachment.SelectByTableName("SLT_Training", Convert.ToInt32(PK_SLT_Training)).Tables[0];
        if (StrOperation != "view" && meetingIsEditable == true)
        {
            gvSLT_TrainingAttachment.DataSource = dtAttachment;
            gvSLT_TrainingAttachment.DataBind();
        }
        else
        {
            gvSLT_TrainingAttachmentView.DataSource = dtAttachment;
            gvSLT_TrainingAttachmentView.DataBind();
        }
    }
    protected void Upload_Training_Attachment()
    {
        //add attachment
        SLT_TrainingAttachmentADD.AddSLTAttachment(clsGeneral.SLT_Tables.SLT_Training, PK_SLT_Training);
        tr_training_Attachment.Style.Add("display", "none");
        BindTrainingAttachment();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(10);", true);
    }

    private void SaveTrainging(string Pnl)
    {
        SLT_Training objSLT_Training = new SLT_Training(PK_SLT_Training);
        objSLT_Training.PK_SLT_Training = PK_SLT_Training;
        objSLT_Training.FK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;
        objSLT_Training.FK_SLT_Meeting = PK_SLT_Meeting;
        objSLT_Training.Training_Description = txtTraining_Description.Text.Trim();
        objSLT_Training.Desired_Comp_Date = clsGeneral.FormatNullDateToStore(txtDesired_Comp_Date.Text);
        objSLT_Training.Completed = rdoCompleted.SelectedValue == "Y";
        objSLT_Training.Date_Completed = clsGeneral.FormatNullDateToStore(txtDate_Completed_Training.Text);
        objSLT_Training.Comments = txtComments_Training.Text.Trim();
        objSLT_Training.Updated_By = clsSession.UserID;
        objSLT_Training.Update_Date = DateTime.Now;

        if (PK_SLT_Training > 0)
            objSLT_Training.Update();
        else
            PK_SLT_Training = objSLT_Training.Insert();

        //PK_SLT_Training = 0;
        BindGridTrainingSuggstions();
        //ClearTrainingSuggstionFields();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + Pnl + ");", true);
    }
    #endregion
    #region SLT Score
    public void GetSLT_Score()
    {
        DataTable dtScore = new DataTable();
        dtScore = SLT_Meeting.Get_SLT_Meeting_Scores(FK_LU_Location_ID, PK_SLT_Meeting_Schedule).Tables[0];
        if (dtScore.Rows.Count > 0)
        {
            if (StrOperation.ToLower() == "view")
            {
                lbl_Meeting_Participated_View.Text = dtScore.Rows[0]["Meeting_Points"].ToString();
                lblSaftey_walk_Participated_View.Text = dtScore.Rows[0]["Safety_Walk_Points"].ToString();
                lblIncident_Review_Conducted_View.Text = dtScore.Rows[0]["Incidents_Review_Points"].ToString();
                lbl_Quality_Review_View.Text = dtScore.Rows[0]["Quality_Review"].ToString();
            }
            else
            {
                if (UserIsRegional == true)
                {
                    lblMeeting_Participation.Text = dtScore.Rows[0]["Meeting_Points"].ToString();
                    lblSaftey_Walk_Participated.Text = dtScore.Rows[0]["Safety_Walk_Points"].ToString();
                    lblIncident_Review_Conducted.Text = dtScore.Rows[0]["Incidents_Review_Points"].ToString();
                    lblQuality_Review.Text = dtScore.Rows[0]["Quality_Review"].ToString();
                }
                else
                {
                    lbl_Meeting_Participated_View.Text = dtScore.Rows[0]["Meeting_Points"].ToString();
                    lblSaftey_walk_Participated_View.Text = dtScore.Rows[0]["Safety_Walk_Points"].ToString();
                    lblIncident_Review_Conducted_View.Text = dtScore.Rows[0]["Incidents_Review_Points"].ToString();
                    lbl_Quality_Review_View.Text = dtScore.Rows[0]["Quality_Review"].ToString();
                }
            }
        }
    }
    private void ClearSLT_Score()
    {
        if (StrOperation.ToLower() == "view")
        {
            lbl_Meeting_Participated_View.Text = "";
            lblSaftey_walk_Participated_View.Text = "";
            lblIncident_Review_Conducted_View.Text = "";
            lbl_Quality_Review_View.Text = "";
        }
        else
        {
            if (UserIsRegional == true)
            {
                lblMeeting_Participation.Text = "";
                lblSaftey_Walk_Participated.Text = "";
                lblIncident_Review_Conducted.Text = "";
                lblQuality_Review.Text = "";
            }
            else if (meetingIsEditable == false)
            {
                lbl_Meeting_Participated_View.Text = "";
                lblSaftey_walk_Participated_View.Text = "";
                lblIncident_Review_Conducted_View.Text = "";
                lbl_Quality_Review_View.Text = "";
            }
            else
            {
                lbl_Meeting_Participated_View.Text = "";
                lblSaftey_walk_Participated_View.Text = "";
                lblIncident_Review_Conducted_View.Text = "";
                lbl_Quality_Review_View.Text = "";
            }
        }
    }
    #endregion
    #region "CallTOOrder and meeting review"
    /// <summary>
    /// Bind Call to Order And Meeting Review Details from view and edit mode
    /// </summary>
    private void BindCallToOrderDetails()
    {
        if (StrOperation.ToLower() != "view" && meetingIsEditable == true)
        {
            #region "SLT_MEETING"
            SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
            if (!string.IsNullOrEmpty(objSLT_Meeting_Schedule.Meeting_Start_Time) && objSLT_Meeting_Schedule.Meeting_Start_Time.ToString().Length == 8)
            {
                if (objSLT_Meeting_Schedule.Meeting_Start_Time.ToString().Length == 8)
                {
                    string[] strStart_Time = objSLT_Meeting_Schedule.Meeting_Start_Time.Split(' ');
                    txtMeeting_Start_Time.Text = strStart_Time[0].ToString();
                    ddlMeeting_Start_Time_AM.SelectedValue = strStart_Time[1].ToString();
                }
            }
            else
                txtMeeting_Start_Time.Text = objSLT_Meeting_Schedule.Meeting_Start_Time;
            if (!string.IsNullOrEmpty(objSLT_Meeting_Schedule.Meeting_End_Time) && objSLT_Meeting_Schedule.Meeting_End_Time.ToString().Length == 8)
            {
                string[] strEnd_Time = objSLT_Meeting_Schedule.Meeting_End_Time.Split(' ');
                txtMeeting_End_Time.Text = strEnd_Time[0].ToString();
                ddlMeeting_End_Time_AM.SelectedValue = strEnd_Time[1].ToString();
            }
            else
                txtMeeting_End_Time.Text = objSLT_Meeting_Schedule.Meeting_End_Time;


            #endregion
        }
        else
        {
            #region "Slt_meeting"
            SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
            lblMeeting_Start_Time.Text = objSLT_Meeting_Schedule.Meeting_Start_Time;
            lblMeeting_End_Time.Text = objSLT_Meeting_Schedule.Meeting_End_Time;
            lblPrev_Meeting_Review.Text = Convert.ToBoolean(objSLT_Meeting_Schedule.Prev_Meeting_Review) == true ? "Yes" : "No";
            //lblSafety_Board_Updated.Text = Convert.ToString(objSLT_Meeting_Schedule.Safety_Board_Updated) == "Y" ? "Yes" : "No";
            lblSafety_Board_Updated.Text = !string.IsNullOrEmpty(objSLT_Meeting_Schedule.Safety_Board_Updated) ? (Convert.ToString(objSLT_Meeting_Schedule.Safety_Board_Updated) == "Y" ? "Yes" : "No") : "";


            #endregion
        }

    }
    private void BindMeetingReview()
    {
        if (PK_SLT_Meeting_Schedule > 0)
        {
            SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
            if (StrOperation.ToLower() != "view")
            {
                if (UserIsRegional == true)
                {
                    if (objSLT_Meeting_Schedule.Prev_Meeting_Review != null)
                        rdoPrev_Meeting_Review.SelectedValue = Convert.ToBoolean(objSLT_Meeting_Schedule.Prev_Meeting_Review) == true ? "Y" : "N";
                    else
                        rdoPrev_Meeting_Review.SelectedValue = "N";
                    if (objSLT_Meeting_Schedule.Safety_Board_Updated != null)
                        rdoSafety_Board_Updated.SelectedValue = Convert.ToString(objSLT_Meeting_Schedule.Safety_Board_Updated);
                    else
                        rdoSafety_Board_Updated.SelectedValue = "N";
                    txtMeeting_Approved_date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Meeting_Approved_date);
                    if (objSLT_Meeting_Schedule.FK_LU_Meeting_Quality != null) drpFK_LU_Meeting_Quality.SelectedValue = objSLT_Meeting_Schedule.FK_LU_Meeting_Quality.ToString();
                    else
                        drpFK_LU_Meeting_Quality.SelectedIndex = 0;
                    //UniqueVal = objSLT_Meeting_Schedule.UniqueVal;
                    txtMeeting_Comment.Text = objSLT_Meeting_Schedule.Meeting_Comments;
                    txtDate_Scored.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Date_Scored);
                    txtLag_Time.Text = objSLT_Meeting_Schedule.Lag_Time.ToString();
                }
                else
                {
                    lblPrev_Meeting_Review.Text = Convert.ToBoolean(objSLT_Meeting_Schedule.Prev_Meeting_Review) == true ? "Yes" : "No";
                    lblSafety_Board_Updated.Text = Convert.ToString(objSLT_Meeting_Schedule.Safety_Board_Updated) == "Y" ? "Yes" : "No";
                    lblMeeting_Approved_date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Meeting_Approved_date);
                    lblMeeting_Comments.Text = objSLT_Meeting_Schedule.Meeting_Comments;
                    lblDate_Scored.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Date_Scored);
                    lblLag_Time.Text = objSLT_Meeting_Schedule.Lag_Time.ToString();
                    if (objSLT_Meeting_Schedule.FK_LU_Meeting_Quality != null)
                    {
                        switch (Convert.ToInt32(objSLT_Meeting_Schedule.FK_LU_Meeting_Quality))
                        {
                            case 1: lblFK_LU_Meeting_Quality.Text = "Spectator"; break;
                            case 2: lblFK_LU_Meeting_Quality.Text = "Water boy"; break;
                            case 3: lblFK_LU_Meeting_Quality.Text = "Second String"; break;
                            case 4: lblFK_LU_Meeting_Quality.Text = "Starter"; break;
                            case 5: lblFK_LU_Meeting_Quality.Text = "All Pro"; break;
                        }
                    }
                    else
                        lblFK_LU_Meeting_Quality.Text = "";
                }
            }
            else
            {
                lblMeeting_Approved_date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Meeting_Approved_date);
                lblMeeting_Comments.Text = objSLT_Meeting_Schedule.Meeting_Comments;
                lblDate_Scored.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Date_Scored);
                lblLag_Time.Text = objSLT_Meeting_Schedule.Lag_Time.ToString();
                if (objSLT_Meeting_Schedule.FK_LU_Meeting_Quality != null)
                {
                    switch (Convert.ToInt32(objSLT_Meeting_Schedule.FK_LU_Meeting_Quality))
                    {
                        case 1: lblFK_LU_Meeting_Quality.Text = "Spectator"; break;
                        case 2: lblFK_LU_Meeting_Quality.Text = "Water boy"; break;
                        case 3: lblFK_LU_Meeting_Quality.Text = "Second String"; break;
                        case 4: lblFK_LU_Meeting_Quality.Text = "Starter"; break;
                        case 5: lblFK_LU_Meeting_Quality.Text = "All Pro"; break;
                    }
                }
                else
                    lblFK_LU_Meeting_Quality.Text = "";
            }
        }
        else
        {
            txtMeeting_Approved_date.Text = "";
            drpFK_LU_Meeting_Quality.SelectedIndex = 0;
            txtMeeting_Comment.Text = "";
            lblMeeting_Approved_date.Text = "";
            lblFK_LU_Meeting_Quality.Text = "";
            lblMeeting_Comments.Text = "";
            lblDate_Scored.Text = "";
            lblLag_Time.Text = "";
            txtDate_Scored.Text = "";
            txtLag_Time.Text = "";
        }
    }

    private void BindEditableMeeting()
    {
        #region "Meeting Editable"
        SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
        lblScheduled_Meeting_Date.Text = lblMeeting_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Scheduled_Meeting_Date);
        if (!string.IsNullOrEmpty(objSLT_Meeting_Schedule.Actual_Meeting_Date.ToString()))
            Actual_Meeting_Date = clsGeneral.FormatDBNullDateToDate(objSLT_Meeting_Schedule.Actual_Meeting_Date);
        else
            Actual_Meeting_Date = clsGeneral.FormatDBNullDateToDate(objSLT_Meeting_Schedule.Scheduled_Meeting_Date);
        txtActual_Meeting_Date.Text = lblAttendeesActual_meeting_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Actual_Meeting_Date);
        if (objSLT_Meeting_Schedule.RLCM_Attended != null)
        {
            rdoRLCM_Attendance.SelectedValue = objSLT_Meeting_Schedule.RLCM_Attended.ToString();
            lblRLCM_Attendance.Text = objSLT_Meeting_Schedule.RLCM_Attended == "Y" ? "Yes" : objSLT_Meeting_Schedule.RLCM_Attended == "N" ? "No" : "";
        }
        else
        {
            lblRLCM_Attendance.Text = "";
        }

        btnMeetingAttendees.Visible = true;
        if (PK_SLT_Safety_Walk > 0)
            btnView_auditSafetyWalk.Visible = true;
        else
            btnView_auditSafetyWalk.Visible = false;
        tr_procedureAdd.Style.Add("display", "none");
        tr_suggestionadd.Style.Add("display", "none");
        tr_procedureview.Style.Add("display", "none");
        tr_suggview.Style.Add("display", "none");
        //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
        #endregion
        ShowTraining_QuarterResults();
        BindAttendeesGrid();
        BindSafetyWalkDetails();
        BindSaftyWalkGridNew();
        BindSaftyWalkGrid();
        BindCallToOrderDetails();
        BindMeetingReview();

        BindSLTMemberGrid();
        if (gvSLT_Members.Rows.Count > 0)
            //PK_SLT_Member = Convert.ToDecimal(DataBinder.Eval(gvSLT_Members.Rows[0].DataItem, "PK_SLT_Member"));
            PK_SLT_Member = Convert.ToDecimal(((HiddenField)gvSLT_Members.Rows[0].FindControl("hdnPK_SLT_Members")).Value);
        else
            PK_SLT_Member = 0;
        BindGridNewProcedures();
        BindGridSuggestions();
        BindTrainingConducted_ByRLCM();
        BindGridTrainingSuggstions();
        //ClearNewProcedure();
        //ClearSuggestionControls();
        //ClearTrainingSuggstionFields();
        FillIncident_ReviewGrid();
        FillIncident_Review();
        BindTrainingAttachment();
        BindGridInspection();
        //ClearInspectionControls();
        BindClaimManagementGrid();
    }
    #endregion

    #region Send To RLCM
    protected void SendTO_RLCM(string RLCMmsg)
    {
        string strRLCMMsg = string.Empty;
        SLT_Reports objSLT_Report = new SLT_Reports();
        objSLT_Report.PK_SLT_Meeting = PK_SLT_Meeting;
        objSLT_Report.PK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;
        objSLT_Report.FK_LU_Location_ID = FK_LU_Location_ID;
        string DocPath = clsGeneral.GetAttachmentDocPath("SLT_Safety_Walk");
        SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);

        //string Attachment_name = clsGeneral.SaveFile(objSLT_Report.GeneratePrintReport("Email"), DocPath, "Sonic_SLT_Meeting_Agenda.doc");
        string Attachment_name;
        if ((!string.IsNullOrEmpty(Convert.ToString(objSLT_Meeting_Schedule.Scheduled_Meeting_Date))) && string.IsNullOrEmpty(Convert.ToString(objSLT_Meeting_Schedule.Actual_Meeting_Date)))
            Attachment_name = clsGeneral.SaveFile(objSLT_Report.GeneratePrintScheduleMeetingReport("Email"), DocPath, "Sonic_SLT_Meeting_Agenda.doc");
        //Attachment_name = clsGeneral.GenerateWordFromFileAndReplaceText(strFilePath,,"Sonic_SLT_Meeting_Agenda.doc",objSLT_Report.)

        //clsGeneral.GenerateWordDoc("SLT Meeting Information.doc", objSLT_Report.GeneratePrintScheduleMeetingReport("Print"), Response);
        else
        {
            DateTime startOfMonth = new DateTime(AppConfig.New_SLT_Safety_Walk_Date.Year, AppConfig.New_SLT_Safety_Walk_Date.Month, 1);
            TimeSpan tsTmp;
            if (objSLT_Meeting_Schedule.Actual_Meeting_Date != null)
                tsTmp = objSLT_Meeting_Schedule.Actual_Meeting_Date.Value.Subtract(startOfMonth); //AppConfig.New_SLT_Safety_Walk_Date);
            else tsTmp = Actual_Meeting_Date.Subtract(startOfMonth);
            if (tsTmp.Days < 0)
            {
                Attachment_name = clsGeneral.SaveFile(objSLT_Report.GeneratePrintReport("Email"), DocPath, "Sonic_SLT_Meeting_Agenda.doc");
            }
            else
            {
                Attachment_name = clsGeneral.SaveFile(objSLT_Report.GeneratePrintReport_New("Email"), DocPath, "Sonic_SLT_Meeting_Agenda.doc");
            }
        }

        string[] Attachment = new string[1];
        Attachment[0] = DocPath + Attachment_name;
        string Email = "";
        LU_Location objLU_Location = new LU_Location(FK_LU_Location_ID);
        if (objLU_Location.FK_Employee_Id != null)
        {
            DataTable dtEmail = Security.GetSecurityByEmployee_ID(Convert.ToDecimal(objLU_Location.FK_Employee_Id)).Tables[0];
            if (dtEmail.Rows.Count > 0)
            {
                Email = dtEmail.Rows[0]["Email"] != DBNull.Value ? dtEmail.Rows[0]["Email"].ToString() : "";
            }
            if (!String.IsNullOrEmpty(Email))
            {
                clsGeneral.SendMailMessage(AppConfig.MailFrom, Email, string.Empty, string.Empty, "Sonic SLT Meeting Agenda", string.Empty, true, Attachment);
                SLT_Meeting_Schedule ObjSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
                ObjSLT_Meeting_Schedule.Date_Meeting_Minutes_Sent = clsGeneral.FormatDateToStore(DateTime.Today.ToString());
                ObjSLT_Meeting_Schedule.SLT_Meeting_CutOff_Day = AppConfig.SLT_Meeting_CutOff_Day;

                if (PK_SLT_Meeting_Schedule > 0)
                    ObjSLT_Meeting_Schedule.Update();
                else
                    PK_SLT_Meeting_Schedule = ObjSLT_Meeting_Schedule.Insert();
                BindMeetingScheduleGrid();
                if (RLCMmsg.ToString().ToLower() == "Next Meeting Schedule sent successfully.".ToLower())
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel2.Value + ");alert('Mail for Next Meeting Schedule and Meeting Minutes sent successfully.');", true);
                }
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel2.Value + ");alert('" + RLCMmsg.ToString() + "'); alert('Meeting Minutes to the RLCM sent successfully.');", true);
            }
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel2.Value + ");alert('" + RLCMmsg.ToString() + "');alert('No email id for RLCM is available to send Meeting Minutes.');", true);
        }
        else
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel2.Value + ");alert('" + RLCMmsg.ToString() + "');alert('No RLCM exist for the Location " + objLU_Location.dba + " to send Meeting Minutes.');", true);

        if (File.Exists(DocPath + Attachment_name))
            File.Delete(DocPath + Attachment_name);

    }
    #endregion
    #endregion

    #region "Control Events"
    #region Incident Review
    /// <summary>
    /// Handles Selected Index Change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlYearIncident_SelectedIndexChanged(object sender, EventArgs e)
    {
        Year = ddlYearIncident.SelectedValue;
        Month = ddlMonth.SelectedValue;
        FillIncident_ReviewGrid();
        SetYearMonth_IncidentType(null);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(7);", true);
    }
    protected void ddlYearIncident_View_SelectedIndexChanged(object sender, EventArgs e)
    {
        Year = ddlYearIncident_View.SelectedValue;
        Month = ddlMonth_View.SelectedValue;
        FillIncident_ReviewGrid();
        SetYearMonth_IncidentType(null);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(7);", true);
    }
    /// <summary>
    /// Handles Selected Index Change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        Year = ddlYearIncident.SelectedValue;
        Month = ddlMonth.SelectedValue;
        FillIncident_ReviewGrid();
        SetYearMonth_IncidentType(null);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(7);", true);
    }
    protected void ddlMonth_View_SelectedIndexChanged(object sender, EventArgs e)
    {
        Year = ddlYearIncident_View.SelectedValue;
        Month = ddlMonth_View.SelectedValue;
        FillIncident_ReviewGrid();
        SetYearMonth_IncidentType(null);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(7);", true);
    }
    /// <summary>
    /// Handles Click Event
    /// Show Records for WC_Fr 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lblViewAll_WC_Click(object sender, EventArgs e)
    {
        SetYearMonth_IncidentType("wc_fr");
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(8);", true);
    }
    /// <summary>
    /// Handles Click Event
    /// Show Records for AL_Fr 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAL_FRViewAll_Click(object sender, EventArgs e)
    {
        SetYearMonth_IncidentType("al_fr");
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(9);", true);
    }
    /// <summary>
    /// Handles Click Event
    /// Show Records for PL_Fr 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkPl_FR_ViewAll_Click(object sender, EventArgs e)
    {
        SetYearMonth_IncidentType("pl_fr");
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(10);", true);
    }
    /// <summary>
    /// Handles Click Event
    /// Show Records for DPD_Fr 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkDPD_Fr_ViewAll_Click(object sender, EventArgs e)
    {
        SetYearMonth_IncidentType("dpd_fr");
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(11);", true);
    }
    /// <summary>
    /// Handles Click Event
    /// Show Records for PC_Fr 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkPC_FR_ViewAll_Click(object sender, EventArgs e)
    {
        SetYearMonth_IncidentType("property_fr");
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(12);", true);
    }
    protected void BindIncidentReviewGrid()
    {
        if (((DropDownList)IncidentReview_WC.FindControl("ddlYear")).SelectedValue == ddlYearIncident.SelectedValue)
            FillIncident_ReviewGrid();
        //GetSLT_Score();
    }

    public void UpdateSLTScore()
    {
        GetSLT_Score();
    }
    #endregion
    #region "SLT Members"
    /// <summary>
    /// Save SLT Members
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_member_Click(object sender, EventArgs e)
    {
        SaveSLT_Members("1");
    }
    /// <summary>
    /// Add New Slt Member
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkSLT_MemberAdd_New_Click(object sender, EventArgs e)
    {
        BindActiveEmployeesByLocation();
        btnSLTMembers_AuditEdit.Visible = false;
        tr_Sltmembers.Style.Add("display", "none");
        tr_SltmembersADD.Style.Add("display", "");
        PK_SLT_Member = 0;
        txtMembersStart_Date.Text = "";
        txtmemberEnd_date.Text = "";
        txtMemberLast_Name.Text = "";
        txtMembersFirst_Name.Text = "";
        txtMembersMiddle_Name.Text = "";
        txtMember_Email.Text = "";
        //hdnPK_Employee.Value = "";
        drpDepartment.SelectedIndex = 0;
        drpSLT_Role.SelectedIndex = 0;
        drpFK_Employee.SelectedIndex = 0;
        //lstMember_Location.SelectedIndex = -1;
        txtMembersStart_Date.Focus();
        trMemberName_New.Visible = true;
        trMemberName_Old.Visible = false;
        Span3_New.Style["display"] = "inline-block";
        Span3.Style["display"] = "none";
        hdnSLTMember_ISNew.Value = "1";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

        hdnControlIDsMembers.Value = hdnControlIDsMembers.Value.Replace(txtMemberLast_Name.ClientID, drpFK_Employee.ClientID);
        hdnErrorMsgsMembers.Value = hdnErrorMsgsMembers.Value.Replace("Please enter [SLT Members]/Member Name", "Please select [SLT Members]/Member Name");
    }
    /// <summary>
    /// Redirects to Slt_members grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnMember_Cancel_Click(object sender, EventArgs e)
    {
        PK_SLT_Member = 0;
        hdnSLTMember_ISNew.Value = "0";
        if (StrOperation.ToLower() != "view")
        {
            tr_Sltmembers.Style.Add("display", "");
            tr_SltmembersADD.Style.Add("display", "none");
            txtMembersStart_Date.Text = "";
            txtmemberEnd_date.Text = "";
            txtMemberLast_Name.Text = "";
            txtMembersFirst_Name.Text = "";
            txtMembersMiddle_Name.Text = "";
            //hdnPK_Employee.Value = "";
            drpDepartment.SelectedIndex = 0;
            drpSLT_Role.SelectedIndex = 0;
            //lstMember_Location.SelectedIndex = -1;
        }
        else
        {
            tr_Sltmembers_View.Visible = true;
            tr_SltmembersBYYear_View.Visible = false;
            lblMambers_Start_Date.Text = "";
            lblMambers_End_Date.Text = "";
            lblEmployee_Name.Text = "";
            lblDepartment.Text = "";
            lblSLT_Role.Text = "";
            //lstMembers_ListboxView.SelectedIndex = -1;
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    /// <summary>
    /// Binds Slt members grid according to year selected
    /// </summary>
    /// <param name="senders"></param>
    /// <param name="e"></param>
    protected void ddlYear_SelectedIndexChanged(object senders, EventArgs e)
    {
        BindSLTMemberYearGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    #endregion
    #region "Common Events"
    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region "SLT_MEETING"



        //UniqueVal = System.Guid.NewGuid().ToString();
        meetingIsEditable = true;
        SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
        objSLT_Meeting_Schedule.PK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;
        objSLT_Meeting_Schedule.Meeting_Approved_date = clsGeneral.FormatNullDateToStore(txtMeeting_Approved_date.Text);
        if (drpFK_LU_Meeting_Quality.SelectedIndex > 0)
            objSLT_Meeting_Schedule.FK_LU_Meeting_Quality = Convert.ToDecimal(drpFK_LU_Meeting_Quality.SelectedValue);
        else
            objSLT_Meeting_Schedule.FK_LU_Meeting_Quality = null;

        objSLT_Meeting_Schedule.Update_Date = System.DateTime.Now;
        objSLT_Meeting_Schedule.Updated_By = clsSession.UserID;
        //objSLT_Meeting_Schedule.UniqueVal = UniqueVal;
        objSLT_Meeting_Schedule.Meeting_Comments = txtMeeting_Comment.Text;
        objSLT_Meeting_Schedule.Update();

        // if points enterd to overwrite then recalculate the scores
        //if (txtMeetingPoints.Text != "" && txtSafetyWalkPoints.Text != "" && txtIncidentReviewPoints.Text != "" && txtQualityReviewPoints.Text != "")
        //{
        //    SLT_Meeting.RecalculateScores(PK_SLT_Meeting, PK_SLT_Meeting_Schedule, Convert.ToInt32(txtMeetingPoints.Text), Convert.ToInt32(txtSafetyWalkPoints.Text),
        //        Convert.ToInt32(txtIncidentReviewPoints.Text), Convert.ToInt32(txtQualityReviewPoints.Text));
        //    lblMeeting_Participation.Text = txtMeetingPoints.Text;
        //    lblSaftey_Walk_Participated.Text = txtSafetyWalkPoints.Text;
        //    lblIncident_Review_Conducted.Text = txtIncidentReviewPoints.Text;
        //    lblQuality_Review.Text = txtQualityReviewPoints.Text;

        //    txtMeetingPoints.Text = ""; txtSafetyWalkPoints.Text = ""; txtIncidentReviewPoints.Text = ""; txtQualityReviewPoints.Text = "";
        //}
        //else
        //    GetSLT_Score();



        int? intMeetingPoints = null, intSafetyWalkPoints = null, intIncidentReviewPoints = null, intQualityReviewPoints = null;

        if (!string.IsNullOrEmpty(txtMeetingPoints.Text.Trim())) intMeetingPoints = Convert.ToInt32(txtMeetingPoints.Text);
        if (!string.IsNullOrEmpty(txtSafetyWalkPoints.Text.Trim())) intSafetyWalkPoints = Convert.ToInt32(txtSafetyWalkPoints.Text);
        if (!string.IsNullOrEmpty(txtIncidentReviewPoints.Text.Trim())) intIncidentReviewPoints = Convert.ToInt32(txtIncidentReviewPoints.Text);
        if (!string.IsNullOrEmpty(txtQualityReviewPoints.Text.Trim())) intQualityReviewPoints = Convert.ToInt32(txtQualityReviewPoints.Text);
        if (txtMeetingPoints.Text != "" || txtSafetyWalkPoints.Text != "" || txtIncidentReviewPoints.Text != "" || txtQualityReviewPoints.Text != "")
        {
            SLT_Meeting.RecalculateScores(PK_SLT_Meeting, PK_SLT_Meeting_Schedule, intMeetingPoints, intSafetyWalkPoints, intIncidentReviewPoints, intQualityReviewPoints);
            if (!string.IsNullOrEmpty(txtMeetingPoints.Text.Trim())) lblMeeting_Participation.Text = txtMeetingPoints.Text;
            if (!string.IsNullOrEmpty(txtSafetyWalkPoints.Text.Trim())) lblSaftey_Walk_Participated.Text = txtSafetyWalkPoints.Text;
            if (!string.IsNullOrEmpty(txtIncidentReviewPoints.Text.Trim())) lblIncident_Review_Conducted.Text = txtIncidentReviewPoints.Text;
            if (!string.IsNullOrEmpty(txtQualityReviewPoints.Text.Trim())) lblQuality_Review.Text = txtQualityReviewPoints.Text;
        }
        GetSLT_Score();

        txtMeetingPoints.Text = ""; txtSafetyWalkPoints.Text = ""; txtIncidentReviewPoints.Text = ""; txtQualityReviewPoints.Text = "";


        BindMeetingScheduleGrid();
        if (objSLT_Meeting_Schedule.FK_LU_Meeting_Quality != null) meetingIsEditable = false;
        if (meetingIsEditable == false)//if meeting scheduled is reviewd by RLCM get Meeting Review in vew mode
        { BindNextMeetingSchedule(); }
        BindEditableMeeting();

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(14);", true);

        #endregion

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("SLT_Meeting.aspx?id=" + Encryption.Encrypt(PK_SLT_Meeting.ToString()) + "&LID=" + Encryption.Encrypt(FK_LU_Location_ID.ToString()) + "&op=edit");
    }
    /// <summary>
    /// Send Email To all The members added in scheduled meeting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSend_Click(object sender, EventArgs e)
    {
        UniqueVal = System.Guid.NewGuid().ToString();

        if (PK_SLT_Meeting_Schedule > 0)
        {
            SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
            //objSLT_Meeting.PK_SLT_Meeting = PK_SLT_Meeting;
            objSLT_Meeting_Schedule.Meeting_Approved_date = clsGeneral.FormatNullDateToStore(txtMeeting_Approved_date.Text);
            if (drpFK_LU_Meeting_Quality.SelectedIndex > 0) objSLT_Meeting_Schedule.FK_LU_Meeting_Quality = Convert.ToDecimal(drpFK_LU_Meeting_Quality.SelectedValue);
            else objSLT_Meeting_Schedule.FK_LU_Meeting_Quality = null;
            if (drpFK_LU_Meeting_Quality.SelectedIndex > 0)
                objSLT_Meeting_Schedule.Date_Scored = clsGeneral.FormatDateToStore(DateTime.Today.ToString());
            else
                objSLT_Meeting_Schedule.Date_Scored = null;
            objSLT_Meeting_Schedule.Update_Date = System.DateTime.Now;
            objSLT_Meeting_Schedule.Updated_By = clsSession.UserID;
            // objSLT_Meeting.UniqueVal = UniqueVal;
            objSLT_Meeting_Schedule.Meeting_Comments = txtMeeting_Comment.Text;
            //if (PK_SLT_Meeting > 0)
            objSLT_Meeting_Schedule.Update();

            // if points enterd to overwrite then recalculate the scores
            if (txtMeetingPoints.Text != "" && txtSafetyWalkPoints.Text != "" && txtIncidentReviewPoints.Text != "" && txtQualityReviewPoints.Text != "")
            {
                SLT_Meeting.RecalculateScores(PK_SLT_Meeting, PK_SLT_Meeting_Schedule, Convert.ToInt32(txtMeetingPoints.Text), Convert.ToInt32(txtSafetyWalkPoints.Text),
                    Convert.ToInt32(txtIncidentReviewPoints.Text), Convert.ToInt32(txtQualityReviewPoints.Text));
                lblMeeting_Participation.Text = txtMeetingPoints.Text;
                lblSaftey_Walk_Participated.Text = txtSafetyWalkPoints.Text;
                lblIncident_Review_Conducted.Text = txtIncidentReviewPoints.Text;
                lblQuality_Review.Text = txtQualityReviewPoints.Text;

                txtMeetingPoints.Text = ""; txtSafetyWalkPoints.Text = ""; txtIncidentReviewPoints.Text = ""; txtQualityReviewPoints.Text = "";
            }
            else
                GetSLT_Score();

            //else
            //    PK_SLT_Meeting = objSLT_Meeting_Schedule.Insert();
            SLT_Reports objSLT_Report = new SLT_Reports();
            objSLT_Report.PK_SLT_Meeting = PK_SLT_Meeting;
            objSLT_Report.PK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;
            objSLT_Report.FK_LU_Location_ID = FK_LU_Location_ID;
            string DocPath = clsGeneral.GetAttachmentDocPath("SLT_Safety_Walk");
            string Attachment_name = clsGeneral.SaveFile(objSLT_Report.GenerateReviewDoc(), DocPath, "Sonic_SLT_Meeting_Review.doc");
            string[] Attachment = new string[1];
            string[] Email_Address = hdnEmail_Address.Value.Split(',');
            Attachment[0] = DocPath + Attachment_name;
            for (int I2 = 0; I2 < Email_Address.Length; I2++)
            {
                string Email = Email_Address[I2];
                if (!string.IsNullOrEmpty(Email))
                    clsGeneral.SendMailMessage(AppConfig.MailFrom, Email, string.Empty, string.Empty, "Sonic SLT Meeting Review", string.Empty, true, Attachment);
            }

            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(14);alert('Mail sent successfully');", true);
            if (File.Exists(DocPath + Attachment_name))
                File.Delete(DocPath + Attachment_name);
            BindMeetingScheduleGrid();
            //slt_meeting_schedule will not be editable after rlcm approves meeting
            if (objSLT_Meeting_Schedule.FK_LU_Meeting_Quality != null) meetingIsEditable = false;
            if (meetingIsEditable == false)//if meeting scheduled is reviewd by RLCM get Meeting Review in vew mode
            { BindNextMeetingSchedule(); }
            BindEditableMeeting();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(14);alert('Please select meeting schedule record');", true);
        }

    }
    /// <summary>
    /// Save and redirects to next panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveNnextCall_Click(object sender, EventArgs e)
    {
        string btnControlSave = "";
        if (hdnPanel2.Value == "1")
        {
            if (tr_Sltmembers.Style["display"] == "none")
            {
                SaveSLT_Members("2");
            }
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else if (hdnPanel2.Value == "2")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);

        }
        else if (hdnPanel2.Value == "3")
        {
            if (meetingIsEditable == true)
            {
                Save_meetingAttendees("4");
            }
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);

        }
        else if (hdnPanel2.Value == "4")
        {
            if (meetingIsEditable == true)
            {
                SaveMeeting();
            }
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);

        }
        else if (hdnPanel2.Value == "5")
        {
            if (meetingIsEditable == true)
            {
                TimeSpan tsTmp;
                DateTime startOfMonth = new DateTime(AppConfig.New_SLT_Safety_Walk_Date.Year, AppConfig.New_SLT_Safety_Walk_Date.Month, 1);
                SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
                if (objSLT_Meeting_Schedule.Actual_Meeting_Date != null)
                    tsTmp = objSLT_Meeting_Schedule.Actual_Meeting_Date.Value.Subtract(startOfMonth); //AppConfig.New_SLT_Safety_Walk_Date);
                else tsTmp = Actual_Meeting_Date.Subtract(startOfMonth);

                objSLT_Meeting_Schedule = null;

                if (tsTmp.Days < 0)
                {
                    SaveSafetyWalk();
                }
                else
                {
                    SaveNewSafetyWalk(true);
                }
            }
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
        }
        else if (hdnPanel2.Value == "6")
        {
            if (meetingIsEditable == true)
            {
                SaveInspection("7");
            }
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(7);", true);
        }
        else if (hdnPanel2.Value == "7")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(8);", true);
        }
        else if (hdnPanel2.Value == "8")
        {
            if (meetingIsEditable == true)
            {
                btnControlSave = "ctl00_ContentPlaceHolder1_IncidentReview_WC_btnSavennextHide";
                //GetSLT_Score();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:CallControlSave('" + btnControlSave + "');ShowPanel(9);", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(9);", true);
            }
        }

        else if (hdnPanel2.Value == "9")
        {
            if (meetingIsEditable == true)
            {
                SaveClaimManagement("10");
            }
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(10);", true);
        }
        else if (hdnPanel2.Value == "10")
        {
            if (meetingIsEditable == true)
            {
                SaveTrainging("11");
            }

        }
        else if (hdnPanel2.Value == "11")
        {
            if (meetingIsEditable == true)
            {
                SaveProcedure("12");
            }
        }
        else if (hdnPanel2.Value == "12")
        {
            if (meetingIsEditable == true)
            {
                SaveSuggestion("13");
            }
        }

    }

    protected void btnRecalculate_Click(object sender, EventArgs e)
    {
        if (PK_SLT_Meeting > 0)
        {
            SLT_Meeting.RecalculateAllScoreByYear(PK_SLT_Meeting, DateTime.Now.Year);
            BindMeetingScheduleGrid();
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
        }
    }

    #endregion
    #region "Meeting Schedule"
    /// <summary>
    /// Save SLT_Meeting Attendees record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAttendeesSave_Click(object sender, EventArgs e)
    {
        if (meetingIsEditable == false)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('You cannot edit data once SLT meeting is reviewed by RLCM.');ShowPanel(3);", true);
        }
        else
        {
            bool bValid = true;
            bool btxtValid = true;
            foreach (GridViewRow gRow in gv_MeetingAttendees.Rows)
            {
                bool bPresent = ((RadioButtonList)(gRow.FindControl("rdbPresent"))).SelectedValue == "Y";
                //if (!bPresent)
                //{
                //    if (((DropDownList)(gRow.FindControl("drpExplain"))).SelectedIndex <= 0)
                //        bValid = false;
                //    else if (((DropDownList)(gRow.FindControl("drpExplain"))).SelectedIndex > 0)
                //    {
                //        if (((DropDownList)(gRow.FindControl("drpExplain"))).SelectedItem.Text == "Other")
                //        {
                //            if (string.IsNullOrEmpty(((TextBox)(gRow.FindControl("txtExplain"))).Text))
                //            {
                //                btxtValid = false; bValid = false;
                //            }
                //        }
                //    }
                //}
            }

            if (bValid)
            {
                Save_meetingAttendees("3");
                //GetSLT_Score();
            }
            else
            {
                if (!btxtValid)
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(3);alert('Please enter other reason for member who is not present');", true);
                else
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(3);alert('Please select explain for member who is not present');", true);
            }
        }
    }
    /// <summary>
    /// Add New meeting Schedule record goes to meeitng Attendees panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddMeeting_Click(object sender, EventArgs e)
    {
        btnMeetingAttendees.Visible = false;
        tr_Agenda_Search.Visible = false;
        tr_Agenda_grid.Visible = true;
        txtActual_Meeting_Date.Text = "";
        lblScheduled_Meeting_Date.Text = "";
        PK_SLT_Meeting_Schedule = -1;
        meetingIsEditable = true;
        BindSLTMemberGrid();
        BindAttendeesGrid();
        txtScheduled_Meeting_Date.Text = "";
        txtScheduled_Meeting_Time.Text = "";
        txtMeeting_Place.Text = "";
        drpTime_Zone.SelectedIndex = 0;
        rdoRLCM_Attendance.SelectedValue = "N";
        //rdoEmail_Members.SelectedValue = "N";
        if (gvSLT_Members.Rows.Count > 0)
            //PK_SLT_Member = Convert.ToDecimal(DataBinder.Eval(gvSLT_Members.Rows[0].DataItem, "PK_SLT_Member"));
            PK_SLT_Member = Convert.ToDecimal(((HiddenField)gvSLT_Members.Rows[0].FindControl("hdnPK_SLT_Members")).Value);
        else
            PK_SLT_Member = 0;
        #region "Rebind Controls"
        PK_SLT_Safety_Walk = 0;
        BindSaftyWalkGridNew();
        BindSaftyWalkGrid();
        BindCallToOrderDetails();
        BindMeetingReview();
        tr_procedureAdd.Style.Add("display", "none");
        tr_suggestionadd.Style.Add("display", "none");
        BindGridNewProcedures();
        BindGridSuggestions();
        BindGridTrainingSuggstions();
        ClearNewProcedure();
        ClearSuggestionControls();
        ClearTrainingSuggstionFields();
        BindTrainingAttachment();
        BindGridInspection();
        ClearInspectionControls();
        ClearSLT_Score();
        #endregion
        InvestigationInfo.ShowSLT_Meeting = true;
        GridView gvLocation = ((GridView)(InvestigationInfo.FindControl("gvLocation")));
        if (gvLocation.Rows.Count > 0)
            ((Label)(gvLocation.Rows[0].FindControl("lblMeeting_Date"))).Text = "";
        meetingIsEditable = true;
        PK_Temp_Schedule_ID = 0;
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }
    /// <summary>
    /// Clears meeting Attendees panel and go back to meeting agenda
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelAttendees_Click(object sender, EventArgs e)
    {
        PK_SLT_Meeting_Schedule = 0;
        PK_Temp_Schedule_ID = 0;
        BindSafetyWalkDetails();
        BindSaftyWalkGridNew();
        BindSaftyWalkGrid();
        BindSafetyWalkAttachment();
        if (StrOperation.ToLower() != "view")
        {
            btnView_auditSafetyWalk.Visible = false;
            txtActual_Meeting_Date.Text = "";
            lblScheduled_Meeting_Date.Text = "";
            txtScheduled_Meeting_Date.Text = "";
            txtScheduled_Meeting_Time.Text = "";
            txtMeeting_Place.Text = "";
            drpTime_Zone.SelectedIndex = 0;
            lblMeeting_Approved_date.Text = "";
            lblFK_LU_Meeting_Quality.Text = "";
            lblMeeting_Comments.Text = "";
            rdoRLCM_Attendance.SelectedValue = "N";
            //rdoEmail_Members.SelectedValue = "N";
            BindMeetingScheduleGrid();
            gv_MeetingAttendees.DataBind();
            gvNewProcedures.DataBind();
            gvSuggestions.DataBind();
            tr_procedureAdd.Style.Add("display", "none");
            tr_suggestionadd.Style.Add("display", "none");
        }
        if (StrOperation.ToLower() == "view")
        {
            btnsaftety_walkAudit_view.Visible = false;
            lblMeeting_Date.Text = "";
            lblAttendeesActual_meeting_Date.Text = "";
            lblSchedule_Date.Text = "";
            lblScheduled_Meeting_Time.Text = "";
            lblMeeting_Place.Text = "";
            lblRLCM_Attendance.Text = "";
            lblTime_Zone.Text = "";
            //lblEmail_Members.Text = "No";
            BindMeetingScheduleGrid();
            gvMeetingAttendeesView.DataBind();
            gvNewProceduresView.DataBind();
            gvSuggestionsView.DataBind();
            tr_procedureview.Style.Add("display", "none");
            tr_suggview.Style.Add("display", "none");

        }
        BindCallToOrderDetails();
        BindMeetingReview();
        ClearNewProcedure();
        ClearSuggestionControls();
        ClearTrainingSuggstionFields();
        BindTrainingAttachment();
        BindGridInspection();
        ClearInspectionControls();
        ClearSLT_Score();
        //btnSendTO_RLCM.Enabled = false;
        meetingIsEditable = true;
        //btnSendMeeting_Members.Enabled = false;
        //((GridView)(InvestigationInfo.FindControl("gvLocation"))).ClientID;
        InvestigationInfo.ShowSLT_Meeting = true;
        GridView gvLocation = ((GridView)(InvestigationInfo.FindControl("gvLocation")));
        if (gvLocation.Rows.Count > 0)
            ((Label)(gvLocation.Rows[0].FindControl("lblMeeting_Date"))).Text = "";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }
    protected void btnSaveCommonMeeting_Click(object sender, EventArgs e)
    {
        SaveMeetingSchedule();
        BindMeetingScheduleGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(13);", true);
    }
    /// <summary>
    /// Meeting Schedule Search
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAgendaSearch_Click(object sender, EventArgs e)
    {
        if (StrOperation.ToLower() != "view")
        {
            tr_Agenda_grid.Visible = true;
            tr_Agenda_Search.Visible = false;
            btnAgendaSearch.Visible = false;
            btnAgenda_Cancel.Visible = true;
            btnAdd_NewAgenda.Visible = false;
        }
        else
        {
            tr_AgendaGridview.Visible = true;
            Tr_AgendaSearchView.Visible = false;
            btnAgendaSearchView.Visible = false;
            btnAgendaCancelview.Visible = true;
        }
        BindMeetingScheduleGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }
    /// <summary>
    /// goes Back to meeting agenda search
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAgenda_Cancel_Click(object sender, EventArgs e)
    {
        if (StrOperation.ToLower() != "view")
        {
            tr_Agenda_grid.Visible = false;
            tr_Agenda_Search.Visible = true;
            gvMeeting.DataBind();
            txtMeeting_Agenda_DateFrom.Text = "";
            txtMeeting_Agenda_DateTo.Text = "";
            drpMeeting_AgendaMonth.SelectedValue = DateTime.Now.Month.ToString();
            drpMeeting_AgendaYear.SelectedValue = DateTime.Now.Year.ToString();
            rdbagendaFrom.Checked = true;
            btnAgenda_Cancel.Visible = false;
            btnAgendaSearch.Visible = true;
            btnAdd_NewAgenda.Visible = true;
        }
        else
        {
            tr_AgendaGridview.Visible = false;
            Tr_AgendaSearchView.Visible = true;
            gvMeetingView.DataBind();
            txtFromView.Text = "";
            txtToView.Text = "";
            drpMeeting_AgendaMonthView.SelectedValue = DateTime.Now.Month.ToString();
            drpMeeting_AgendaYearView.SelectedValue = DateTime.Now.Year.ToString();
            rdoFromView.Checked = true;
            btnAgendaCancelview.Visible = false;
            btnAgendaSearchView.Visible = true;
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }
    /// <summary>
    /// SAVE Schedule Record And Send Email to Chairman of the meeting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveNSend_Click(object sender, EventArgs e)
    {
        #region "Save and send"
        decimal _ret_Val = 0;
        if (txtScheduled_Meeting_Date.Text != "" && txtScheduled_Meeting_Time.Text.Trim() != "" && txtMeeting_Place.Text.Trim() != "")
        {
            SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule();

            objSLT_Meeting_Schedule.FK_SLT_Meeting = PK_SLT_Meeting;
            objSLT_Meeting_Schedule.Scheduled_Meeting_Date = clsGeneral.FormatNullDateToStore(txtScheduled_Meeting_Date.Text);
            objSLT_Meeting_Schedule.Scheduled_Meeting_Time = txtScheduled_Meeting_Time.Text.Trim() == "" ? "" : (txtScheduled_Meeting_Time.Text.Trim() + " " + ddlScheduled_Meeting_Time_AM.SelectedValue.ToString());
            objSLT_Meeting_Schedule.Meeting_Place = txtMeeting_Place.Text.Trim();
            //objSLT_Meeting_Schedule.Email_Members = rdoEmail_Members.SelectedValue == "Y";
            objSLT_Meeting_Schedule.Update_Date = System.DateTime.Now;
            objSLT_Meeting_Schedule.Updated_By = clsSession.UserID;
            objSLT_Meeting_Schedule.SLT_Meeting_CutOff_Day = AppConfig.SLT_Meeting_CutOff_Day;

            if (drpTime_Zone.SelectedIndex > 0)
                objSLT_Meeting_Schedule.Time_Zone = drpTime_Zone.SelectedValue.ToString();

            _ret_Val = objSLT_Meeting_Schedule.Insert();
            if (_ret_Val == -1)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('You are not allowed to enter data for previous month after 5th of current month.');ShowPanel(13);", true);
            }
            else if (_ret_Val == -2)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(13);alert('SLT Meeting Schedule already exists for the location for same month and Year');", true);
            }
            else if (_ret_Val > 0)
            {
                BindMeetingScheduleGrid();
                //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(13);OpenPopupEmailSchedule('Next_Schedule');", true);
                //btnSendTO_RLCM.Enabled = true;
            }
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(13);", true);
        #endregion
    }
    /// <summary>
    /// Send Next Meeting Scheduled for non editable meeting in view mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSendMeetingView_Click(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// Send Meeting Minutes information to RLCM of That Location
    /// </summary>
    /// <param name="senders"></param>
    /// <param name="e"></param>
    //protected void btnSendTO_RLCM_Click(object senders, EventArgs e)
    //{
    //    SLT_Reports objSLT_Report = new SLT_Reports();
    //    objSLT_Report.PK_SLT_Meeting = PK_SLT_Meeting;
    //    objSLT_Report.PK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;
    //    objSLT_Report.FK_LU_Location_ID = FK_LU_Location_ID;
    //    string DocPath = clsGeneral.GetAttachmentDocPath("SLT_Safety_Walk");
    //    string Attachment_name = clsGeneral.SaveFile(objSLT_Report.GeneratePrintReport("Email"), DocPath, "Sonic_SLT_Meeting_Agenda.doc");
    //    string[] Attachment = new string[1];
    //    Attachment[0] = DocPath + Attachment_name;
    //    string Email = "";
    //    LU_Location objLU_Location = new LU_Location(FK_LU_Location_ID);
    //    if (objLU_Location.FK_Employee_Id != null)
    //    {
    //        DataTable dtEmail = Security.GetSecurityByEmployee_ID(Convert.ToDecimal(objLU_Location.FK_Employee_Id)).Tables[0];
    //        if (dtEmail.Rows.Count > 0)
    //        {
    //            Email = dtEmail.Rows[0]["Email"] != DBNull.Value ? dtEmail.Rows[0]["Email"].ToString() : "";
    //        }
    //        if (!String.IsNullOrEmpty(Email))
    //        {
    //            clsGeneral.SendMailMessage(AppConfig.MailFrom, Email, string.Empty, string.Empty, "Sonic SLT Meeting Agenda", string.Empty, true, Attachment);
    //            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel2.Value + ");alert('Mail sent successfully');", true);
    //        }
    //        else
    //        {
    //            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel2.Value + ");", true);
    //        }
    //    }
    //    else
    //    {
    //        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel2.Value + ");alert('No RLCM exist for the Location " + objLU_Location.dba + ".');", true);
    //    }
    //    if (File.Exists(DocPath + Attachment_name))
    //        File.Delete(DocPath + Attachment_name);
    //}
    /// <summary>
    /// Send Mail for next meeting schedule to all Active slt_members and Additional recipients
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSendMeeting_Members_Click(object sender, EventArgs e)
    {
        string DBA = new LU_Location((decimal)FK_LU_Location_ID).dba;
        string[] Email_Address = hdnEmail_Address.Value.Split(',');
        string Meeting_Date = "", Meeting_Time = "", Meeting_Place = "";
        string strTimeZone = "";
        //if (meetingIsEditable == false)
        //{
        //    DataTable dtNextMeeting = SLT_Meeting_Schedule.SelectNextMeeting(PK_SLT_Meeting_Schedule, PK_SLT_Meeting).Tables[0];
        //    if (dtNextMeeting.Rows.Count > 0)
        //    {
        //        Meeting_Date = clsGeneral.FormatDBNullDateToDisplay(dtNextMeeting.Rows[0]["Scheduled_Meeting_Date"]);
        //        Meeting_Time = dtNextMeeting.Rows[0]["Scheduled_Meeting_Time"].ToString();
        //        Meeting_Place = dtNextMeeting.Rows[0]["Meeting_Place"].ToString();
        //    }
        //}
        //else
        //{
        //    Meeting_Date = txtScheduled_Meeting_Date.Text;
        //    Meeting_Time = txtScheduled_Meeting_Time.Text.Trim() == "" ? DateTime.Now.AddMonths(1).ToString() : (txtScheduled_Meeting_Time.Text.Trim() + " " + ddlScheduled_Meeting_Time_AM.SelectedValue.ToString());
        //    Meeting_Place = txtMeeting_Place.Text.Trim();
        //}
        string RLCMmsg = string.Empty;
        DataTable dtNextMeeting = SLT_Meeting_Schedule.SelectNextMeeting(PK_SLT_Meeting_Schedule, PK_SLT_Meeting).Tables[0];
        if (dtNextMeeting.Rows.Count > 0)
        {
            Meeting_Date = clsGeneral.FormatDBNullDateToDisplay(dtNextMeeting.Rows[0]["Scheduled_Meeting_Date"]);
            Meeting_Time = Convert.ToString(dtNextMeeting.Rows[0]["Scheduled_Meeting_Time"]);
            Meeting_Place = Convert.ToString(dtNextMeeting.Rows[0]["Meeting_Place"]);
            strTimeZone = Convert.ToString(dtNextMeeting.Rows[0]["Time_Zone"]);

            List<string> lstEmails = new List<string>();

            for (int i = 0; i < Email_Address.Length; i++)
            {
                lstEmails.Add(Email_Address[i]);
            }

            LU_Location objLU_Location = new LU_Location(FK_LU_Location_ID);
            if (objLU_Location.FK_Employee_Id != null)
            {
                DataTable dtEmail = Security.GetSecurityByEmployee_ID(Convert.ToDecimal(objLU_Location.FK_Employee_Id)).Tables[0];
                if (dtEmail.Rows.Count > 0)
                {
                    Email_Address = new string[Email_Address.Length + 1];

                    if (dtEmail.Rows[0]["Email"] != DBNull.Value)
                    {
                        // check if e-mail address is already added in the recipient list or not
                        if (!lstEmails.Exists(delegate(string strMailID) { return strMailID.Equals(dtEmail.Rows[0]["Email"].ToString()); }))
                        {
                            lstEmails.Add(dtEmail.Rows[0]["Email"].ToString());
                        }
                    }
                }
            }

            Email_Address = lstEmails.ToArray();

            for (int I2 = 0; I2 < Email_Address.Length; I2++)
            {
                string Email = Email_Address[I2];
                if (!string.IsNullOrEmpty(Email))
                {
                    try
                    {
                        // clsGeneral.SendMailMessage(AppConfig.MailFrom, Email, string.Empty, string.Empty, subject, Mail_Text.Trim().Replace("\r\n", "<br/>"), true);
                        string attendees = Email;
                        string organizerName = ""; //Organizer Name
                        string organizerEmail = AppConfig.MailFrom;


                        //string description = "<br/> Date : " + Meeting_Date + "<br/> Time : " + Meeting_Time + "<br/> Meeting Place : " + Meeting_Place;
                        string description = "";
                        string location = Meeting_Place;
                        string subject = DBA + " - SLT Monthly Meeting";
                        string UID = Guid.NewGuid().ToString();
                        DateTime start = Convert.ToDateTime(Meeting_Date + " " + Meeting_Time);


                        //string strStart = start.ToString("s");
                        //string strEnd = end.ToString("s");

                        //string strStart = start.ToString("yyyyMMddThhmmssZ");
                        //int diff = Convert.ToInt32(strStart.Substring(9, 6)) + 063000;
                        //strStart = string.Concat(strStart.Substring(0, 9), diff.ToString().PadLeft(6, '0'), "Z");
                        //string strEnd = end.ToString("yyyyMMddThhmmssZ");
                        //diff = Convert.ToInt32(strEnd.Substring(9, 6)) + 063000;
                        //strEnd = string.Concat(strEnd.Substring(0, 9), diff.ToString().PadLeft(6, '0'), "Z");

                        //Convert Current Time to EST Time 

                        if (strTimeZone == "Central")
                        {
                            start = start.AddHours(1);
                        }
                        else if (strTimeZone == "Mountain")
                        {
                            start = start.AddHours(2);
                        }
                        else if (strTimeZone == "Pacific")
                        {
                            start = start.AddHours(3);
                        }
                        else if (strTimeZone == "Alaska")
                        {
                            start = start.AddHours(4);
                        }
                        else if (strTimeZone == "Hawaii")
                        {
                            start = start.AddHours(6);
                        }

                        //Convert Local Time Zone to EST Time Zone 

                        TimeZone localZone = TimeZone.CurrentTimeZone;
                        string strlocalZone = localZone.StandardName.ToString();

                        if (strlocalZone == "Central Standard Time")
                        {
                            start = start.AddHours(-1);
                        }
                        else if (strlocalZone == "Mountain Standard Time")
                        {
                            start = start.AddHours(-2);
                        }
                        else if (strlocalZone == "Pacific Standard Time")
                        {
                            start = start.AddHours(-3);
                        }
                        else if (strlocalZone == "Alaskan Standard Time")
                        {
                            start = start.AddHours(-4);
                        }
                        else if (strlocalZone == "Hawaiian Standard Time")
                        {
                            start = start.AddHours(-6);
                        }


                        DateTime end = start.AddHours(2);

                        string strStart = string.Format("{0:yyyyMMddTHHmm00}Z", start.ToUniversalTime());
                        string strEnd = string.Format("{0:yyyyMMddTHHmm00}Z", end.ToUniversalTime());

                        System.Text.StringBuilder sw = new System.Text.StringBuilder();
                        sw.AppendLine("BEGIN:VCALENDAR");
                        sw.AppendLine("VERSION:2.0");
                        sw.AppendLine("METHOD:REQUEST");
                        sw.AppendLine("BEGIN:VEVENT");
                        sw.AppendLine(attendees);
                        sw.AppendLine("CLASS:PUBLIC");
                        sw.AppendLine("DESCRIPTION:" + description);
                        sw.AppendLine("CREATED:" + start.ToString() + Environment.NewLine);
                        sw.AppendLine("DTSTAMP:" + strStart + Environment.NewLine);
                        sw.AppendLine("DTSTART:" + strStart + Environment.NewLine);
                        sw.AppendLine("DTEND:" + strEnd + Environment.NewLine);
                        sw.AppendLine("ORGANIZER;CN=\"" + organizerName + "\":mailto:" + organizerEmail);
                        sw.AppendLine("SEQUENCE:0");
                        sw.AppendLine("UID:" + UID);
                        sw.AppendLine("LOCATION:" + location);
                        sw.AppendLine("SUMMARY;LANGUAGE=en-us:" + subject);
                        sw.AppendLine("BEGIN:VALARM");
                        sw.AppendLine("TRIGGER:-PT720M");
                        sw.AppendLine("ACTION:DISPLAY");
                        sw.AppendLine("DESCRIPTION:Reminder");
                        sw.AppendLine("END:VALARM");
                        sw.AppendLine("END:VEVENT");
                        sw.AppendLine("END:VCALENDAR");

                        System.Net.Mime.ContentType mimeType = new System.Net.Mime.ContentType("text/calendar; method=REQUEST");
                        System.Net.Mail.AlternateView ICSview = System.Net.Mail.AlternateView.CreateAlternateViewFromString(sw.ToString(), mimeType);
                        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

                        message.To.Add(attendees);
                        message.From = new System.Net.Mail.MailAddress(AppConfig.MailFrom);
                        message.AlternateViews.Add(ICSview);

                        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                        client.Host = AppConfig.SMTPServer;
                        client.Credentials = new System.Net.NetworkCredential(AppConfig.MailFrom, AppConfig.SMTPpwd);
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            ClearMeetingSchedule();
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(13);alert('Mail sent successfully');", true);
            RLCMmsg = "Next Meeting Schedule sent successfully.";
        }
        else
            RLCMmsg = "No data available for Next Meeting Schedule.";
        //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(13);alert('No data available for Next Meeting Schedule');", true);
        SendTO_RLCM(RLCMmsg);
    }
    #endregion
    #region "Inspection"
    //protected void rdoInspectionQuarters_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BindGridInspection();
    //    ClearInspectionControls();
    //    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
    //}

    protected void btnInspection_Save_Click(object sender, EventArgs e)
    {
        if (meetingIsEditable == false)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('You cannot edit data once SLT meeting is reviewed by RLCM.');ShowPanel(6);", true);
        }
        else
        {
            if (PK_SLT_Meeting_Schedule > 0)
            {
                SaveInspection("6");
            }
            else
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('Please select meeting agenda record');ShowPanel(6);", true);

        }
    }

    protected void drpYearInspection_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGridInspection();
        ClearInspectionControls();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
    }
    #endregion
    #region "New Procedure"
    /// <summary>
    /// ADD new Procedure and clear Controls
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNewProcedure_Click(object sender, EventArgs e)
    {
        //tr_proceduregrid.Style.Add("display", "none");
        tr_procedureAdd.Style.Add("display", "");
        BindDropDowns();
        btnNewProcedureAudit_Edit.Visible = false;
        ClearNewProcedure();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(11);", true);

    }
    /// <summary>
    /// Save SLT_New_Procedure Records
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveProcedure_Click(object sender, EventArgs e)
    {
        if (meetingIsEditable == false)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('You cannot edit data once SLT meeting is reviewed by RLCM.');ShowPanel(11);", true);
        }
        else
        {
            if (PK_SLT_Meeting_Schedule > 0)
            {
                SaveProcedure("11");
            }
            else
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('Please select meeting agenda record');ShowPanel(11);", true);
        }
    }

    /// <summary>
    /// Handles Cancel event when Adding new procedure
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelProcedure_Click(object sender, EventArgs e)
    {
        //tr_proceduregrid.Style.Add("display", "block");
        tr_procedureAdd.Style.Add("display", "none");
        tr_procedureview.Style.Add("display", "none");
        ClearNewProcedure();
        BindGridNewProcedures();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(11);", true);
    }

    protected void drpProcedureYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGridNewProcedures();
        tr_procedureAdd.Style.Add("display", "none");
        tr_procedureview.Style.Add("display", "none");
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(11);", true);
    }
    #endregion
    #region "New Suggestion"
    /// <summary>
    /// Add New SLT_Suggetion
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAdd_NewSuggestion_Click(object sender, EventArgs e)
    {
        //tr_suggestiongrid.Style.Add("display", "none");
        tr_suggestionadd.Style.Add("display", "");
        BindDropDowns();
        btnSuggestionAudit_Edit.Visible = false;
        ClearSuggestionControls();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(12);", true);
    }
    /// <summary>
    /// Handles Save Button Click Event For Adding new Suggetion
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveSuggestion_Click(object sender, EventArgs e)
    {
        if (meetingIsEditable == false)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('You cannot edit data once SLT meeting is reviewed by RLCM.');ShowPanel(12);", true);
        }
        else
        {
            if (PK_SLT_Meeting_Schedule > 0)
            {
                SaveSuggestion("12");
            }
            else
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('Please select meeting agenda record');ShowPanel(12);", true);
        }
    }
    /// <summary>
    /// Handles Cancel Button Click Event For Suggetion
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelSuggestion_Click(object sender, EventArgs e)
    {
        //tr_suggestiongrid.Style.Add("display", "block");
        tr_suggestionadd.Style.Add("display", "none");
        tr_suggview.Style.Add("display", "none");
        ClearSuggestionControls();
        BindGridSuggestions();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(12);", true);
    }
    #endregion
    #region SLT training
    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveTrainingSuggestion_Click(object sender, EventArgs e)
    {
        if (meetingIsEditable == false)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('You cannot edit data once SLT meeting is reviewed by RLCM.');ShowPanel(10);", true);
        }
        else
        {
            if (PK_SLT_Meeting_Schedule > 0)
            {
                SaveTrainging("10");
            }
            else
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('Please select meeting agenda record');ShowPanel(10);", true);
        }
    }

    protected void lnkAddNewTrainingSuggestion_Click(object sender, EventArgs e)
    {
        btnTrainigAudit_Edit.Visible = false;
        PK_SLT_Training = 0;
        ClearTrainingSuggstionFields();
        BindTrainingAttachment();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(10);", true);
    }

    protected void drpTrainingYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowTraining_QuarterResults();
        BindTrainingConducted_ByRLCM();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(10);", true);
    }

    protected void drpLocationStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowTraining_QuarterResults();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(10);", true);
    }

    protected void btnhdnBindRLCM_Training_Click(object sender, EventArgs e)
    {
        BindTrainingConducted_ByRLCM();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(10);", true);
    }


    //protected void btnCancel_Sonic_Training_Click(object sender, EventArgs e)
    //{
    //    PK_SLT_Training = 0;
    //    ClearTrainingSuggstionFields();
    //    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(14);", true);
    //}
    #endregion
    #region "SafetyWalk"
    protected void btnSaveNnextSafety_Click(object sender, EventArgs e)
    {
        if (meetingIsEditable == false)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('You cannot edit data once SLT meeting is reviewed by RLCM.');ShowPanel(5);", true);
        }
        else
        {
            SaveSafetyWalk();
            if (PK_SLT_Safety_Walk > 0)
                btnView_auditSafetyWalk.Visible = true;
            else
                btnView_auditSafetyWalk.Visible = false;
            BindSafetyWalkDetails();
            GetSLT_Score();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
        }
    }
    #endregion
    #region "ClaimManagment"
    protected void btnSaveClaimmanagement_Click(object sender, EventArgs e)
    {
        if (meetingIsEditable == false)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('You cannot edit data once SLT meeting is reviewed by RLCM.');ShowPanel(9);", true);
        }
        else
        {
            if (FK_Claim > 0)
            {
                SaveClaimManagement("9");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please select WC claim record.');ShowPanel('9');", true);
            }
        }
    }
    protected void ddlYear_Claim_Management_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindClaimManagementGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(9);", true);
    }
    protected void ddlMonth_Claim_Management_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindClaimManagementGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(9);", true);
    }

    #endregion
    #region "SLT Meeting Agenda"
    protected void btnSendMailAgenda_Click(object sender, EventArgs e)
    {
        SLT_Reports objSLT_Report = new SLT_Reports();
        objSLT_Report.PK_SLT_Meeting = PK_SLT_Meeting;
        objSLT_Report.PK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;
        objSLT_Report.FK_LU_Location_ID = FK_LU_Location_ID;

        SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);

        string DocPath = clsGeneral.GetAttachmentDocPath("SLT_Safety_Walk");
        //string Attachment_name = clsGeneral.SaveFile(objSLT_Report.GeneratePrintReport("Email"), DocPath, "Sonic_SLT_Meeting_Agenda.doc");
        string Attachment_name;
        if ((!string.IsNullOrEmpty(Convert.ToString(objSLT_Meeting_Schedule.Scheduled_Meeting_Date))) && string.IsNullOrEmpty(Convert.ToString(objSLT_Meeting_Schedule.Actual_Meeting_Date)))
            Attachment_name = clsGeneral.SaveFile(objSLT_Report.GeneratePrintScheduleMeetingReport("Email"), DocPath, "Sonic_SLT_Meeting_Agenda.doc");
        //clsGeneral.GenerateWordDoc("SLT Meeting Information.doc", objSLT_Report.GeneratePrintScheduleMeetingReport("Print"), Response);
        else
        {
            DateTime startOfMonth = new DateTime(AppConfig.New_SLT_Safety_Walk_Date.Year, AppConfig.New_SLT_Safety_Walk_Date.Month, 1);
            TimeSpan tsTmp;
            if (objSLT_Meeting_Schedule.Actual_Meeting_Date != null)
                tsTmp = objSLT_Meeting_Schedule.Actual_Meeting_Date.Value.Subtract(startOfMonth); //AppConfig.New_SLT_Safety_Walk_Date);
            else tsTmp = Actual_Meeting_Date.Subtract(startOfMonth);
            if (tsTmp.Days < 0)
                Attachment_name = clsGeneral.SaveFile(objSLT_Report.GeneratePrintReport("Email"), DocPath, "Sonic_SLT_Meeting_Agenda.doc");
            else
                Attachment_name = clsGeneral.SaveFile(objSLT_Report.GeneratePrintReport_New("Email"), DocPath, "Sonic_SLT_Meeting_Agenda.doc");

        }
        string[] Attachment = new string[1];
        string[] Email_Address = hdnEmail_Address.Value.Split(',');
        Attachment[0] = DocPath + Attachment_name;
        for (int I2 = 0; I2 < Email_Address.Length; I2++)
        {
            string Email = Email_Address[I2];
            if (!string.IsNullOrEmpty(Email))
                clsGeneral.SendMailMessage(AppConfig.MailFrom, Email, string.Empty, string.Empty, "Sonic SLT Meeting Agenda", string.Empty, true, Attachment);
        }

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);alert('Mail sent successfully');", true);
        if (File.Exists(DocPath + Attachment_name))
            File.Delete(DocPath + Attachment_name);
    }
    #endregion
    #endregion

    #region "Grid Events"
    #region Incident Review
    protected void gvIncidentGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            // Fill Footer for Grid
            if (dt_YearlyTotal.Rows.Count > 0)
            {
                ((Label)e.Row.FindControl("lblS1")).Text = dt_YearlyTotal.Rows[0][0].ToString();
                ((Label)e.Row.FindControl("lblS2")).Text = dt_YearlyTotal.Rows[0][1].ToString();
                ((Label)e.Row.FindControl("lblS3")).Text = dt_YearlyTotal.Rows[0][2].ToString();
                ((Label)e.Row.FindControl("lblS4")).Text = dt_YearlyTotal.Rows[0][3].ToString();
                ((Label)e.Row.FindControl("lblS5")).Text = dt_YearlyTotal.Rows[0][4].ToString();
                ((Label)e.Row.FindControl("lblMonthly_Total")).Text = dt_YearlyTotal.Rows[0][5].ToString();
            }
        }
    }

    protected void gvIncidentGrid_View_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            // Fill Footer for Grid
            if (dt_YearlyTotal.Rows.Count > 0)
            {
                ((Label)e.Row.FindControl("lblS1")).Text = dt_YearlyTotal.Rows[0][0].ToString();
                ((Label)e.Row.FindControl("lblS2")).Text = dt_YearlyTotal.Rows[0][1].ToString();
                ((Label)e.Row.FindControl("lblS3")).Text = dt_YearlyTotal.Rows[0][2].ToString();
                ((Label)e.Row.FindControl("lblS4")).Text = dt_YearlyTotal.Rows[0][3].ToString();
                ((Label)e.Row.FindControl("lblS5")).Text = dt_YearlyTotal.Rows[0][4].ToString();
                ((Label)e.Row.FindControl("lblMonthly_Total")).Text = dt_YearlyTotal.Rows[0][5].ToString();
            }
        }
    }
    #endregion
    #region "SLT_Members"
    /// <summary>
    /// gvSLT_Members on Edit Or Delete
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSLT_Members_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditMembers")
        {
            #region

            //Get Employees by Locations :
            BindEmployeesByLocation();

            btnSLTMembers_AuditEdit.Visible = true;
            //tr_Sltmembers.Visible = false;
            //tr_SltmembersADD.Visible = true;
            tr_Sltmembers.Style.Add("display", "none");
            tr_SltmembersADD.Style.Add("display", "");
            SLT_Members objSLT_Members = new SLT_Members(Convert.ToDecimal(e.CommandArgument));
            PK_SLT_Member = Convert.ToDecimal(e.CommandArgument);
            txtMembersStart_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Members.Start_Date);
            txtmemberEnd_date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Members.End_Date);
            txtMembersFirst_Name.Text = objSLT_Members.First_Name;
            txtMembersMiddle_Name.Text = objSLT_Members.Middle_Name;
            txtMemberLast_Name.Text = objSLT_Members.Last_Name;
            txtMember_Email.Text = objSLT_Members.Email;
            //if (objSLT_Members.FK_Employee != null)
            //{
            //hdnPK_Employee.Value = objSLT_Members.FK_Employee.ToString();
            //Employee objEmployee = new Employee(Convert.ToDecimal(hdnPK_Employee.Value));
            //}


            // For #2964 Change on 11/03/2014
            if (objSLT_Members.FK_Employee != null)
            {
                trMemberName_New.Visible = true;
                trMemberName_Old.Visible = false;
                Span3_New.Style["display"] = "inline-block";
                Span3.Style["display"] = "none";
                if (drpFK_Employee.Items.FindByValue(objSLT_Members.FK_Employee.ToString()) != null)
                {
                    drpFK_Employee.ClearSelection();
                    drpFK_Employee.Items.FindByValue(objSLT_Members.FK_Employee.ToString()).Selected = true;
                }

                hdnSLTMember_ISNew.Value = "1";
                hdnControlIDsMembers.Value = hdnControlIDsMembers.Value.Replace(txtMemberLast_Name.ClientID, drpFK_Employee.ClientID);
                hdnErrorMsgsMembers.Value = hdnErrorMsgsMembers.Value.Replace("Please enter [SLT Members]/Member Name", "Please select [SLT Members]/Member Name");
            }
            else
            {
                trMemberName_New.Visible = false;
                trMemberName_Old.Visible = true;
                Span3.Style["display"] = "inline-block";
                Span3_New.Style["display"] = "none";
                hdnSLTMember_ISNew.Value = "0";
                //hdnControlIDsMembers.Value = hdnControlIDsMembers.Value.Replace("", "");
                hdnControlIDsMembers.Value = hdnControlIDsMembers.Value.Replace(drpFK_Employee.ClientID, txtMemberLast_Name.ClientID);
                hdnErrorMsgsMembers.Value = hdnErrorMsgsMembers.Value.Replace("Please select [SLT Members]/Member Name", "Please enter [SLT Members]/Member Name");

            }

            if (objSLT_Members.FK_LU_Department != null)
                drpDepartment.SelectedValue = objSLT_Members.FK_LU_Department.ToString();
            else
                drpDepartment.SelectedIndex = 0;
            if (objSLT_Members.FK_LU_SLT_Role != null)
                drpSLT_Role.SelectedValue = objSLT_Members.FK_LU_SLT_Role.ToString();
            else
                drpSLT_Role.SelectedIndex = 0;

            #endregion
        }
        else if (e.CommandName == "RemoveMembers")
        {
            #region
            SLT_Members.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            //SLT_Members_Locations.DeleteByFK(PK_SLT_Member);
            BindSLTMemberGrid();
            BindSLTMemberYearGrid();
            BindAttendeesGrid();
            BindAssignedToDropDowns();
            if (gvSLT_Members.Rows.Count < 1)
                PK_SLT_Member = 0;
            #endregion
        }
        else if (e.CommandName == "ViewMembers")
        {
            #region
            btnSLTMemberAudit_View.Visible = true;
            tr_Sltmembers_View.Visible = false;
            tr_SltmembersBYYear_View.Visible = true;
            SLT_Members objSLT_Members = new SLT_Members(Convert.ToDecimal(e.CommandArgument));
            PK_SLT_Member = Convert.ToDecimal(e.CommandArgument);
            lblMambers_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Members.Start_Date);
            lblMambers_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Members.End_Date);
            lblEmployee_Name.Text = string.Format("{0} {1} {2}", objSLT_Members.First_Name, objSLT_Members.Middle_Name, objSLT_Members.Last_Name);
            lblMemberEmail_Address.Text = objSLT_Members.Email;
            if (objSLT_Members.FK_LU_Department != null)
                lblDepartment.Text = new LU_Department((decimal)objSLT_Members.FK_LU_Department).Description;
            else
                lblDepartment.Text = "";
            if (objSLT_Members.FK_LU_SLT_Role != null)
                lblSLT_Role.Text = new LU_SLT_Role((decimal)objSLT_Members.FK_LU_SLT_Role).Fld_Desc;
            else
                lblSLT_Role.Text = "";

            if (gvSLT_membersView.Rows.Count > 0)
                //PK_SLT_Member = Convert.ToDecimal(DataBinder.Eval(gvSLT_Members.Rows[0].DataItem, "PK_SLT_Member"));
                PK_SLT_Member = Convert.ToDecimal(((HiddenField)gvSLT_membersView.Rows[0].FindControl("hdnPK_SLT_Members")).Value);
            else
                PK_SLT_Member = 0;
            #endregion

        }

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    /// <summary>
    /// Paging event of gvSLT_Members
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSLT_Members_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSLT_Members.PageIndex = e.NewPageIndex; //Page new index call
        BindSLTMemberGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    /// <summary>
    /// Paging event of gvSLT_MembersBYYear
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSLT_MembersBYYear_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSLT_MembersBYYear.PageIndex = e.NewPageIndex; //Page new index call
        BindSLTMemberYearGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    protected void gvSLT_membersView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSLT_membersView.PageIndex = e.NewPageIndex; //Page new index call
        BindSLTMemberGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    protected void gvSlt_Membersbyyearview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSlt_Membersbyyearview.PageIndex = e.NewPageIndex; //Page new index call
        BindSLTMemberYearGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    #endregion
    #region "SLT_Meeting_Attendees"
    protected void gv_MeetingAttendees_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_MeetingAttendees.PageIndex = e.NewPageIndex; //Page new index call
        BindAttendeesGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }
    protected void gvMeetingAttendeesView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMeetingAttendeesView.PageIndex = e.NewPageIndex; //Page new index call
        BindAttendeesGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }
    /// <summary>
    /// ROWDataBound Event of gv_MeetingAttendees
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_MeetingAttendees_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //ComboHelper.FillExplain(new DropDownList[] { ((DropDownList)(e.Row.FindControl("drpExplain"))) }, true);
            decimal FK_LU_Explain = 0, Present = 1;
            string Explain = "";

            if ((DataBinder.Eval(e.Row.DataItem, "PK_SLT_Members") != DBNull.Value))
            {
                PK_SLT_Member = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PK_SLT_Members"));
                DataTable dtSLTMeeting_Attendees = SLT_Meeting_Attendees.SelectBYSLT_Members(PK_SLT_Member, PK_SLT_Meeting_Schedule).Tables[0];
                if (dtSLTMeeting_Attendees.Rows.Count > 0)
                {
                    if (dtSLTMeeting_Attendees.Rows[0]["Present"] != DBNull.Value)
                    {
                        Present = Convert.ToDecimal(dtSLTMeeting_Attendees.Rows[0]["Present"]);
                    }
                    //if (dtSLTMeeting_Attendees.Rows[0]["FK_LU_Explain"] != DBNull.Value)
                    //{
                    //    FK_LU_Explain = Convert.ToDecimal(dtSLTMeeting_Attendees.Rows[0]["FK_LU_Explain"]);
                    //}
                    //Explain = Convert.ToString(dtSLTMeeting_Attendees.Rows[0]["Explain"]);
                }
            }

            ((RadioButtonList)(e.Row.FindControl("rdbPresent"))).SelectedValue = Convert.ToBoolean(Present) == true ? "Y" : "N";

            //((DropDownList)(e.Row.FindControl("drpExplain"))).SelectedValue = FK_LU_Explain.ToString();
            //((TextBox)(e.Row.FindControl("txtExplain"))).Text = Explain;
            //if (((DropDownList)(e.Row.FindControl("drpExplain"))).SelectedItem.Text == "Other")
            //{
            //    ((TextBox)(e.Row.FindControl("txtExplain"))).Style.Add("display", "block");
            //    ((Label)(e.Row.FindControl("lblExplain"))).Style.Add("display", "block");
            //}
            //else
            //{
            //    ((TextBox)(e.Row.FindControl("txtExplain"))).Style.Add("display", "none");
            //    ((Label)(e.Row.FindControl("lblExplain"))).Style.Add("display", "none");
            //}

        }
    }

    protected void gvMeetingAttendeesView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal FK_LU_Explain = 0, Present = 0;
            string Explain = "";
            if ((DataBinder.Eval(e.Row.DataItem, "PK_SLT_Members") != DBNull.Value))
            {
                PK_SLT_Member = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PK_SLT_Members"));
                DataTable dtSLTMeeting_Attendees = SLT_Meeting_Attendees.SelectBYSLT_Members(PK_SLT_Member, PK_SLT_Meeting_Schedule).Tables[0];
                if (dtSLTMeeting_Attendees.Rows.Count > 0)
                {
                    if (dtSLTMeeting_Attendees.Rows[0]["Present"] != DBNull.Value)
                    {
                        Present = Convert.ToDecimal(dtSLTMeeting_Attendees.Rows[0]["Present"]);
                    }
                    //if (dtSLTMeeting_Attendees.Rows[0]["FK_LU_Explain"] != DBNull.Value)
                    //{
                    //    FK_LU_Explain = Convert.ToDecimal(dtSLTMeeting_Attendees.Rows[0]["FK_LU_Explain"]);
                    //}
                    //Explain = Convert.ToString(dtSLTMeeting_Attendees.Rows[0]["Explain"]);
                }
            }
            ((Label)(e.Row.FindControl("lblPresent"))).Text = Convert.ToBoolean(Present) == true ? "Yes" : "No";
            //if (FK_LU_Explain > 0)
            //    ((Label)(e.Row.FindControl("lblLU_Explain"))).Text = new LU_Explain((decimal)FK_LU_Explain).Fld_Desc;
            //((Label)(e.Row.FindControl("lblExplainView"))).Text = Explain;
            //if (((Label)(e.Row.FindControl("lblLU_Explain"))).Text == "Other")
            //{
            //    ((Label)(e.Row.FindControl("lblExplain"))).Style.Add("display", "block");
            //    ((Label)(e.Row.FindControl("lblExplainView"))).Style.Add("display", "block");
            //}
            //else
            //{
            //    ((Label)(e.Row.FindControl("lblExplain"))).Style.Add("display", "none");
            //    ((Label)(e.Row.FindControl("lblExplainView"))).Style.Add("display", "none");
            //}

        }

    }
    #endregion
    #region "SLT_Meeting_Schedule"
    protected void gvMeeting_RowCommand(object senders, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "Page")
        {
            PK_SLT_Meeting_Schedule = 0;
            string[] arg = new string[2];
            //decimal Schedule_id = 0;
            arg = e.CommandArgument.ToString().Split(';');
            PK_SLT_Meeting = Convert.ToDecimal(arg[0]);
            PK_Temp_Schedule_ID = Convert.ToDecimal(arg[1]);
            SLT_Reports objSLT_Report = new SLT_Reports();
            objSLT_Report.PK_SLT_Meeting = PK_SLT_Meeting;
            objSLT_Report.PK_SLT_Meeting_Schedule = PK_Temp_Schedule_ID;
            objSLT_Report.FK_LU_Location_ID = FK_LU_Location_ID;
            SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_Temp_Schedule_ID);
            if (objSLT_Meeting_Schedule.FK_LU_Meeting_Quality != null) meetingIsEditable = false;
            else
                meetingIsEditable = true;

            //btnSendTO_RLCM.Enabled = true;
            IncidentReview_WC.FK_SLT_Meeting_Schedule = PK_Temp_Schedule_ID;
            //btnSendMeeting_Members.Enabled = true;
            PK_SLT_Meeting_Schedule = PK_Temp_Schedule_ID;
            if (PK_SLT_Meeting_Schedule > 0)
            {
                gvSLTSafetyWalk.Enabled = true;
                //btnSave_SLTSafety.Visible = true;
            }
            else
            {
                gvSLTSafetyWalk.Enabled = false;
                //btnSave_SLTSafety.Visible = false;
            }

            #region"Edit"
            if (e.CommandName == "EditMeeting")
            {
                ClearSLT_Score();
                if (meetingIsEditable == false)//if meeting scheduled is reviewd by RLCM get Meeting Review in vew mode
                { BindNextMeetingSchedule(); }
                BindEditableMeeting();
                BindSaftyWalkGridNew();
                #region "BindScores"
                //lblMeeting_Participation.Text = lbl_Meeting_Participated_View.Text = objSLT_Meeting_Schedule.Full_Participation != null ? objSLT_Meeting_Schedule.Full_Participation.ToString() : "";
                //lblSaftey_Walk_Participated.Text = lblSaftey_walk_Participated_View.Text = objSLT_Meeting_Schedule.Full_SW_Participation != null ? objSLT_Meeting_Schedule.Full_SW_Participation.ToString() : "";
                //lblIncident_Review_Conducted.Text = lblIncident_Review_Conducted_View.Text = objSLT_Meeting_Schedule.Incident_Review != null ? objSLT_Meeting_Schedule.Incident_Review.ToString() : "";
                //lblQuality_Review.Text = lbl_Quality_Review_View.Text = objSLT_Meeting_Schedule.RLCM_Score != null ? objSLT_Meeting_Schedule.RLCM_Score.ToString() : "";
                //txtMeetingPoints.Text = ""; txtSafetyWalkPoints.Text = ""; txtIncidentReviewPoints.Text = ""; txtQualityReviewPoints.Text = "";
                GetSLT_Score();
                #endregion
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
            }
            #endregion

            #region"view"
            else if (e.CommandName == "ViewMeeting")
            {
                ClearSLT_Score();
                //BindDetailsForView();
                lblMeeting_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Scheduled_Meeting_Date);
                lblAttendeesActual_meeting_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Actual_Meeting_Date);
                if (!string.IsNullOrEmpty(objSLT_Meeting_Schedule.Actual_Meeting_Date.ToString()))
                    Actual_Meeting_Date = clsGeneral.FormatDBNullDateToDate(objSLT_Meeting_Schedule.Actual_Meeting_Date);
                else
                    Actual_Meeting_Date = clsGeneral.FormatDBNullDateToDate(objSLT_Meeting_Schedule.Scheduled_Meeting_Date);
                lblRLCM_Attendance.Text = objSLT_Meeting_Schedule.RLCM_Attended == "Y" ? "Yes" : objSLT_Meeting_Schedule.RLCM_Attended == "N" ? "No" : "";
                btnMeetingAttendees.Visible = true;
                BindNextMeetingSchedule();
                BindAttendeesGrid();
                BindSafetyWalkDetails();
                if (PK_SLT_Safety_Walk > 0)
                    btnsaftety_walkAudit_view.Visible = true;
                else
                    btnsaftety_walkAudit_view.Visible = false;
                BindSaftyWalkGridNew();
                //BindSaftyWalkGrid();
                BindCallToOrderDetails();
                BindMeetingReview();
                //lbl_Meeting_Participated_View.Text = objSLT_Meeting_Schedule.Full_Participation != null ? objSLT_Meeting_Schedule.Full_Participation.ToString() : "";
                //lblSaftey_walk_Participated_View.Text = objSLT_Meeting_Schedule.Full_SW_Participation != null ? objSLT_Meeting_Schedule.Full_SW_Participation.ToString() : "";
                //lblIncident_Review_Conducted_View.Text = objSLT_Meeting_Schedule.Incident_Review != null ? objSLT_Meeting_Schedule.Incident_Review.ToString() : "";
                //lbl_Quality_Review_View.Text = objSLT_Meeting_Schedule.RLCM_Score != null ? objSLT_Meeting_Schedule.RLCM_Score.ToString() : "";
                GetSLT_Score();
                tr_procedureview.Style.Add("display", "none");
                tr_suggview.Style.Add("display", "none");
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
            }
            #endregion

            #region "Remove"
            else if (e.CommandName == "RemoveRecord")
            {
                ClearSLT_Score();
                SLT_Meeting_Schedule.DeleteByPK(PK_SLT_Meeting_Schedule);
                SLT_Safety_Walk.DeleteByFK(PK_SLT_Meeting_Schedule);
                SLT_Meeting_Attendees.DeleteByFK(PK_SLT_Meeting_Schedule);
                PK_SLT_Meeting_Schedule = 0;
                gvSLTSafetyWalk.Enabled = false;
                BindMeetingScheduleGrid();
                BindDetailsForEdit();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
            }
            #endregion


            #region "Print_Email"

            else if (e.CommandName == "Print")
            {
                BindAttendeesGrid();
                if ((!string.IsNullOrEmpty(Convert.ToString(objSLT_Meeting_Schedule.Scheduled_Meeting_Date))) && string.IsNullOrEmpty(Convert.ToString(objSLT_Meeting_Schedule.Actual_Meeting_Date)))
                    clsGeneral.GenerateWordDoc("SLT Meeting Information.doc", objSLT_Report.GeneratePrintScheduleMeetingReport("Print"), Response);
                else
                {
                    DateTime startOfMonth = new DateTime(AppConfig.New_SLT_Safety_Walk_Date.Year, AppConfig.New_SLT_Safety_Walk_Date.Month, 1);
                    TimeSpan tsTmp;
                    if (objSLT_Meeting_Schedule.Actual_Meeting_Date != null)
                        tsTmp = objSLT_Meeting_Schedule.Actual_Meeting_Date.Value.Subtract(startOfMonth); //AppConfig.New_SLT_Safety_Walk_Date);
                    else
                        tsTmp = Actual_Meeting_Date.Subtract(startOfMonth); //Actual_Meeting_Date.Subtract(AppConfig.New_SLT_Safety_Walk_Date);
                    //TimeSpan tsTmp = Actual_Meeting_Date.Subtract(AppConfig.New_SLT_Safety_Walk_Date);
                    if (tsTmp.Days < 0)
                    {
                        clsGeneral.GenerateWordDoc("SLT Meeting Information.doc", objSLT_Report.GeneratePrintReport("Print"), Response);
                    }
                    else
                    {
                        clsGeneral.GenerateWordDoc("SLT Meeting Information.doc", objSLT_Report.GeneratePrintReport_New("Print"), Response);
                    }
                }
            }
            else if (e.CommandName == "Mail")
            {
                BindAttendeesGrid();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:OpenPopupEmail('Agenda');ShowPanel(2);", true);
                //clsGeneral.GenerateWordDoc("SLT Meeting Information.doc", objSLT_Report.GeneratePrintReport("Email"), Response);
            }
            #endregion
            InvestigationInfo.ShowSLT_Meeting = true;
            GridView gvLocation = ((GridView)(InvestigationInfo.FindControl("gvLocation")));
            if (gvLocation.Rows.Count > 0)
                ((Label)(gvLocation.Rows[0].FindControl("lblMeeting_Date"))).Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Actual_Meeting_Date);
            BindGridNewProcedures();
            BindGridSuggestions();
            BindTrainingConducted_ByRLCM();
            BindGridTrainingSuggstions();
            ClearNewProcedure();
            ClearSuggestionControls();
            ClearTrainingSuggstionFields();
            FillIncident_ReviewGrid();
            FillIncident_Review();
            BindTrainingAttachment();
            BindGridInspection();
            ClearInspectionControls();
            BindClaimManagementGrid();
            //ClearClaimManagementControls();

            //Hide/Show New/Old SLT Safety Screens
            DateTime startOfMonthDate = new DateTime(AppConfig.New_SLT_Safety_Walk_Date.Year, AppConfig.New_SLT_Safety_Walk_Date.Month, 1);
            TimeSpan ts = Actual_Meeting_Date.Subtract(startOfMonthDate);
            if (ts.Days < 0)
            {
                pnl15.Style["Display"] = "none";
                pnl16.Style["Display"] = "";
                pnl15View.Style["Display"] = "none";
                pnl16View.Style["Display"] = "";
            }
            else
            {
                pnl15.Style["Display"] = "";
                pnl16.Style["Display"] = "none";
                pnl15View.Style["Display"] = "";
                pnl16View.Style["Display"] = "none";
            }

        }

    }
    protected void gvMeeting_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMeeting.PageIndex = e.NewPageIndex; //Page new index call
        BindMeetingScheduleGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }
    protected void gvMeetingView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMeeting.PageIndex = e.NewPageIndex; //Page new index call
        BindMeetingScheduleGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }

    protected void gvMeeting_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //string Total_Points = "", SLT_Score = "";
            //decimal Schedule_id = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PK_SLT_Meeting_Schedule"));
            //DataTable dtScore = SLT_Meeting.Get_SLT_Meeting_Scores(FK_LU_Location_ID, Schedule_id).Tables[0];
            //if (dtScore.Rows.Count > 0)
            //{
            //    Total_Points = dtScore.Rows[0]["Score"].ToString();
            //    SLT_Score = dtScore.Rows[0]["Score_Desc"].ToString();
            //    ((Label)(e.Row.FindControl("lblSLT_RLCM_SCORE"))).Text = Total_Points + " (" + SLT_Score + ")";
            //}
            //else
            //{
            //    ((Label)(e.Row.FindControl("lblSLT_RLCM_SCORE"))).Text = "";
            //}

            if (IsUserInAdministrativeGroup || UserAccessType == AccessType.Administrative_Access)
            {
                e.Row.Cells[gvMeeting.Columns.Count - 1].Visible = true;
            }
            else
            { e.Row.Cells[gvMeeting.Columns.Count - 1].Visible = false; }
        }
        else if (e.Row.RowType == DataControlRowType.Header)
        {
            if (IsUserInAdministrativeGroup || UserAccessType == AccessType.Administrative_Access)
            {
                e.Row.Cells[gvMeeting.Columns.Count - 1].Visible = true;
            }
            else
            { e.Row.Cells[gvMeeting.Columns.Count - 1].Visible = false; }
        }
    }
    //protected void gvMeetingView_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        string Total_Points = "", SLT_Score = "";
    //        decimal Schedule_id = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PK_SLT_Meeting_Schedule"));
    //        DataTable dtScore = SLT_Meeting.Get_SLT_Meeting_Scores(FK_LU_Location_ID, Schedule_id).Tables[0];
    //        if (dtScore.Rows.Count > 0)
    //        {
    //            Total_Points = dtScore.Rows[0]["Score"].ToString();
    //            SLT_Score = dtScore.Rows[0]["Score_Desc"].ToString();
    //            ((Label)(e.Row.FindControl("lblSLT_RLCM_SCORE"))).Text = Total_Points + " (" + SLT_Score + ")";
    //        }
    //        else
    //        {
    //            ((Label)(e.Row.FindControl("lblSLT_RLCM_SCORE"))).Text = "";
    //        }
    //    }
    //}
    #endregion
    #region "SLT_new_Procedure"
    protected void gvNewProcedures_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvNewProcedures.PageIndex = e.NewPageIndex; //Page new index call
        BindGridNewProcedures();
        tr_procedureAdd.Style.Add("display", "none");
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(11);", true);
    }

    protected void gvNewProcedures_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BindAssignedToDropDowns();
        if (e.CommandName == "EditDetails")
        {
            //tr_proceduregrid.Style.Add("display", "none");
            tr_procedureAdd.Style.Add("display", "");
            SLT_New_Procedure objNew_Procedure = new SLT_New_Procedure(Convert.ToDecimal(e.CommandArgument));
            PK_SLT_New_Procedure = Convert.ToDecimal(objNew_Procedure.PK_SLT_New_Procedure);
            if (objNew_Procedure.FK_LU_Importance != null)
                drpFK_LU_Importance.SelectedValue = objNew_Procedure.FK_LU_Importance.ToString();
            else
                drpFK_LU_Importance.SelectedIndex = 0;
            if (objNew_Procedure.FK_LU_Procedure_Source != null)
                drpFK_LU_Procedure_Source.SelectedValue = objNew_Procedure.FK_LU_Procedure_Source.ToString();
            else
                drpFK_LU_Procedure_Source.SelectedIndex = 0;
            txtProcedure_Description.Text = string.IsNullOrEmpty(objNew_Procedure.Procedure_Description) ? "" : objNew_Procedure.Procedure_Description;
            txtAction_Item.Text = string.IsNullOrEmpty(objNew_Procedure.Action_Item) ? "" : objNew_Procedure.Action_Item;
            if (objNew_Procedure.Assigned_To != null)
            {
                ListItem lst = drpProcedureAssignet_to.Items.FindByValue(objNew_Procedure.Assigned_To.ToString());
                if (lst != null)
                    lst.Selected = true;
            }
            else
                drpProcedureAssignet_to.SelectedIndex = 0;
            txtTarget_Completion_Date.Text = objNew_Procedure.Target_Completion_Date != null ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objNew_Procedure.Target_Completion_Date)) : "";
            txtDate_Completed.Text = objNew_Procedure.Date_Completed != null ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objNew_Procedure.Date_Completed)) : "";
            if (objNew_Procedure.FK_LU_Item_Status != null)
                drpFK_LU_Item_Status.SelectedValue = objNew_Procedure.FK_LU_Item_Status.ToString();
            else
                drpFK_LU_Item_Status.SelectedIndex = 0;
            btnNewProcedureAudit_Edit.Visible = true;
        }
        else if (e.CommandName == "DeleteDetails")
        {
            PK_SLT_New_Procedure = Convert.ToDecimal(e.CommandArgument);
            SLT_New_Procedure.DeleteByPK(PK_SLT_New_Procedure);
            BindGridNewProcedures();
        }
        else if (e.CommandName == "ViewDetails")
        {
            tr_procedureview.Style.Add("display", "");
            PK_SLT_New_Procedure = Convert.ToDecimal(e.CommandArgument);
            SLT_New_Procedure objSLT_New_Procedure = new SLT_New_Procedure(Convert.ToDecimal(e.CommandArgument));
            objSLT_New_Procedure.PK_SLT_New_Procedure = PK_SLT_New_Procedure;
            if (objSLT_New_Procedure.FK_LU_Importance != null)
                lblFK_LU_Importance.Text = new LU_Importance((decimal)objSLT_New_Procedure.FK_LU_Importance).Fld_Desc;
            if (objSLT_New_Procedure.FK_LU_Procedure_Source != null)
                lblFK_LU_Procedure_Source.Text = new LU_Procedure_Source((decimal)objSLT_New_Procedure.FK_LU_Procedure_Source).Fld_Desc;
            lblProcedure_Description.Text = objSLT_New_Procedure.Procedure_Description;
            lblAction_Item.Text = objSLT_New_Procedure.Action_Item;
            if (objSLT_New_Procedure.Assigned_To != null)
            {
                SLT_Members objMember = new SLT_Members((decimal)objSLT_New_Procedure.Assigned_To);
                if (objMember.FK_Employee != null)
                {
                    Employee objEmp = new Employee((decimal)objMember.FK_Employee);
                    lblAssigned_To.Text = objEmp.First_Name + " " + objEmp.Last_Name;
                }
                else
                    lblAssigned_To.Text = "";
            }
            else
                lblAssigned_To.Text = "";
            lblTarget_Completion_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_New_Procedure.Target_Completion_Date);
            lblDate_Completed.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_New_Procedure.Date_Completed);
            if (objSLT_New_Procedure.FK_LU_Item_Status != null)
                lblFK_LU_Item_Status.Text = new LU_Item_Status((decimal)objSLT_New_Procedure.FK_LU_Item_Status).Fld_Desc;
            btnNewProcedureAudit_View.Visible = true;
        }
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(11);", true);
    }
    protected void gvNewProceduresView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvNewProceduresView.PageIndex = e.NewPageIndex; //Page new index call
        BindGridNewProcedures();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(11);", true);
    }
    #endregion
    #region "SLT_Suggetions"
    protected void gvSuggestions_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSuggestions.PageIndex = e.NewPageIndex; //Page new index call
        BindGridSuggestions();
        tr_suggestionadd.Style.Add("display", "none");
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(12);", true);
    }

    protected void gvSuggestions_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BindAssignedToDropDowns();
        if (e.CommandName == "EditDetails")
        {
            //tr_suggestiongrid.Style.Add("display", "none");
            tr_suggestionadd.Style.Add("display", "");
            SLT_Suggestion objSLT_Suggestion = new SLT_Suggestion(Convert.ToDecimal(e.CommandArgument));
            PK_SLT_Suggestion = Convert.ToDecimal(objSLT_Suggestion.PK_SLT_Suggestion);
            if (objSLT_Suggestion.FK_LU_Importance != null)
                drpFK_LU_Importance_Sugg.SelectedValue = objSLT_Suggestion.FK_LU_Importance.ToString();
            else
                drpFK_LU_Importance_Sugg.SelectedIndex = 0;
            if (objSLT_Suggestion.FK_LU_Suggestion_Source != null)
                drpFK_LU_Suggestion_Source.SelectedValue = objSLT_Suggestion.FK_LU_Suggestion_Source.ToString();
            else
                drpFK_LU_Suggestion_Source.SelectedIndex = 0;
            txtSuggestion_Description.Text = string.IsNullOrEmpty(objSLT_Suggestion.Suggestion_Description) ? "" : objSLT_Suggestion.Suggestion_Description;
            txtAction_Item_Sugg.Text = string.IsNullOrEmpty(objSLT_Suggestion.Action_Item) ? "" : objSLT_Suggestion.Action_Item;
            if (objSLT_Suggestion.Assigned_To != null)
            {
                ListItem lst = DrpAssigned_To_Sugg.Items.FindByValue(objSLT_Suggestion.Assigned_To.ToString());
                if (lst != null)
                    lst.Selected = true;
            }
            else
                DrpAssigned_To_Sugg.SelectedIndex = 0;
            txtTarget_Completion_Date_Sugg.Text = objSLT_Suggestion.Target_Completion_Date != null ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objSLT_Suggestion.Target_Completion_Date)) : "";
            txtDate_Completed_Sugg.Text = objSLT_Suggestion.Date_Completed != null ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objSLT_Suggestion.Date_Completed)) : "";
            if (objSLT_Suggestion.FK_LU_Item_Status != null)
                drpFK_LU_Item_Status_Sugg.SelectedValue = objSLT_Suggestion.FK_LU_Item_Status.ToString();
            else
                drpFK_LU_Item_Status_Sugg.SelectedIndex = 0;
            btnSuggestionAudit_Edit.Visible = true;
        }
        else if (e.CommandName == "DeleteDetails")
        {
            PK_SLT_Suggestion = Convert.ToDecimal(e.CommandArgument);
            SLT_Suggestion.DeleteByPK(PK_SLT_Suggestion);
            BindGridSuggestions();
        }
        else if (e.CommandName == "ViewDetails")
        {
            tr_suggview.Style.Add("display", "");
            PK_SLT_Suggestion = Convert.ToDecimal(e.CommandArgument);
            SLT_Suggestion objSLT_Suggestion = new SLT_Suggestion(PK_SLT_Suggestion);
            if (objSLT_Suggestion.Assigned_To != null)
            {
                SLT_Members objMember = new SLT_Members((decimal)objSLT_Suggestion.Assigned_To);
                if (objMember.FK_Employee != null)
                {
                    Employee objEmp = new Employee((decimal)objMember.FK_Employee);
                    lblAssigned_To_Sugg.Text = objEmp.First_Name + " " + objEmp.Last_Name;
                }
                else
                    lblAssigned_To_Sugg.Text = "";
            }
            else
                lblAssigned_To_Sugg.Text = "";
            if (objSLT_Suggestion.FK_LU_Suggestion_Source != null)
                lblFK_LU_Suggestion_Source.Text = new LU_Suggetion_Source((decimal)objSLT_Suggestion.FK_LU_Suggestion_Source).Fld_Desc;
            if (objSLT_Suggestion.FK_LU_Importance != null)
                lblFK_LU_Importance_Sugg.Text = new LU_Importance((decimal)objSLT_Suggestion.FK_LU_Importance).Fld_Desc;
            lblTarget_Completion_Date_Sugg.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Suggestion.Target_Completion_Date);
            lblSuggestion_Description.Text = objSLT_Suggestion.Suggestion_Description;
            lblAction_Item_Sugg.Text = objSLT_Suggestion.Action_Item;
            lblDate_Completed_Sugg.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Suggestion.Date_Completed);
            if (objSLT_Suggestion.FK_LU_Item_Status != null)
                lblFK_LU_Item_Status_Sugg.Text = new LU_Item_Status((decimal)objSLT_Suggestion.FK_LU_Item_Status).Fld_Desc;

            btnSuggestionAudit_View.Visible = true;
        }
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(12);", true);
    }

    protected void gvSuggestionsView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSuggestionsView.PageIndex = e.NewPageIndex; //Page new index call
        BindGridSuggestions();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(12);", true);
    }
    #endregion
    #region "SLT_Inspection"
    protected void gvInspection_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewDetails")
        {
            string[] arg = new string[2];
            arg = e.CommandArgument.ToString().Split(',');
            int rowIndex = Convert.ToInt32(arg[0]);
            PK_Inspection_ID = Convert.ToDecimal(arg[1]);
            lblInspectorName.Text = ((Label)gvInspection.Rows[rowIndex].FindControl("lblInspectorName")).Text;
            lblInspectionDate.Text = ((Label)gvInspection.Rows[rowIndex].FindControl("lblInspectionDate")).Text;
            lblDeficiencies.Text = ((HtmlInputHidden)gvInspection.Rows[rowIndex].FindControl("hdnDeficiencies")).Value;
            lblDeficienciesNotCompleted.Text = ((HtmlInputHidden)gvInspection.Rows[rowIndex].FindControl("hdnDeficienciesNotCompleted")).Value;
            BindInspection_ResponseGrid();
            FK_Inspection_Responses_ID = 0;
            btnInspectionAudit_Edit.Visible = false;
            drpFK_SLT_Members.SelectedIndex = 0;
            txtDate_Completed_Inspection.Text = "";
            txtComments_Inspection.Text = "";
            rdoRLCM_Notified.SelectedValue = "N";
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
        }
    }
    protected void gvInspectionView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewDetails")
        {
            string[] arg = new string[2];
            arg = e.CommandArgument.ToString().Split(',');
            int rowIndex = Convert.ToInt32(arg[0]);
            PK_Inspection_ID = Convert.ToDecimal(arg[1]);
            lblInspectorNameView.Text = ((Label)gvInspectionView.Rows[rowIndex].FindControl("lblInspectorName")).Text;
            lblInspectionDateView.Text = ((Label)gvInspectionView.Rows[rowIndex].FindControl("lblInspectionDate")).Text;
            lblDeficienciesView.Text = ((HtmlInputHidden)gvInspectionView.Rows[rowIndex].FindControl("hdnDeficiencies")).Value;
            lblDeficienciesNotCompletedView.Text = ((HtmlInputHidden)gvInspectionView.Rows[rowIndex].FindControl("hdnDeficienciesNotCompleted")).Value;
            BindInspection_ResponseGrid();
            FK_Inspection_Responses_ID = 0;
            btnInspectionAudit_view.Visible = false;
            lblFK_SLT_Members.Text = "";
            lblDate_Completed_Inspection.Text = "";
            lblComments_Inspection.Text = "";
            lblRLCM_Notified.Text = "";
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
        }
    }
    protected void gvInspection_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTrainingSuggestions.PageIndex = e.NewPageIndex;
        BindGridInspection();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
    }
    protected void gvInspection_responses_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataTable dtDepartment = LU_Department.SelectAll().Tables[0];//PK_SLT_Quarterly_Inspections
        dtDepartment.DefaultView.RowFilter = " Description not in ('General Manager', 'Controller')";
        dtDepartment = dtDepartment.DefaultView.ToTable();
        rptDepartment.DataSource = dtDepartment;
        rptDepartment.DataBind();
        FK_Inspection_Responses_ID = Convert.ToDecimal(e.CommandArgument);
        Inspection_Responses objInspection_Responses = new Inspection_Responses(Convert.ToInt32(FK_Inspection_Responses_ID));
        string[] strDepartment = objInspection_Responses.Department.ToString().Split(',');
        lblResponse_Deficiency.Text = objInspection_Responses.Deficiency_Noted == "Y" ? "YES" : "NO";
        lblRepeated_Deficiency.Text = objInspection_Responses.Repeat_Deficiency == "Y" ? "YES" : "NO";
        lblResponse_Date_Opned.Text = clsGeneral.FormatDBNullDateToDisplay(objInspection_Responses.Date_Opened);
        lblAction.Text = objInspection_Responses.Recommended_Action;
        lblTargetCompletion_date.Text = clsGeneral.FormatDBNullDateToDisplay(objInspection_Responses.Target_Completion_Date);
        lblActual_completion_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objInspection_Responses.Actual_Completion_Date);
        if (lblActual_completion_Date.Text == "01/01/1753") lblActual_completion_Date.Text = "";
        lblNotes.Text = objInspection_Responses.Notes;

        Inspection_Questions objInspection_Questions = new Inspection_Questions(Convert.ToInt32(objInspection_Responses.FK_Inspection_Question_ID));
        lblResponse_FocusArea.Text = objInspection_Questions.Item_Number_Focus_Area;
        lblQuestionTextEdit.Text = objInspection_Questions.Question_Text;
        lblGuidance_Text.Text = objInspection_Questions.Guidance_Text;
        lblQuestion_NumberEdit.Text = objInspection_Questions.Question_Number;
        foreach (string str in strDepartment)
        {
            foreach (DataListItem rptItm in rptDepartment.Items)
            {
                HtmlInputHidden hdnDeptID = (HtmlInputHidden)rptItm.FindControl("hdnDeptID");
                Label lblValue = (Label)rptItm.FindControl("lblValue");
                if (str == hdnDeptID.Value)
                {
                    lblValue.Text = "Yes";
                    //((Label)rptItm.FindControl("lblDepartment")).Text = new LU_Department((decimal)Convert.ToDecimal(str)).Description;
                }

            }
        }
        TimeSpan ts;
        if (objInspection_Responses.Actual_Completion_Date != null && objInspection_Responses.Date_Opened != null)
        {
            //ts = Convert.ToDateTime(objInspection_Responses.Actual_Completion_Date) - Convert.ToDateTime(objInspection_Responses.Date_Opened);
            if (Convert.ToDateTime(objInspection_Responses.Actual_Completion_Date) == Convert.ToDateTime("01-JAN-1753"))
            {
                ts = DateTime.Now - Convert.ToDateTime(objInspection_Responses.Date_Opened);
            }
            else
            {
                ts = Convert.ToDateTime(objInspection_Responses.Actual_Completion_Date) - Convert.ToDateTime(objInspection_Responses.Date_Opened);
            }

            lblDays_Open.Text = ts.Days.ToString();
        }
        else
            lblDays_Open.Text = "";
        BindInspectionEditDetails();
        if (PK_SLT_Meeting_Schedule > 0)
            btnInspection_Save.Enabled = true;
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
    }
    protected void gvInspection_responses_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInspection_responses.PageIndex = e.NewPageIndex;
        BindInspection_ResponseGrid();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
    }
    protected void gvInspection_responsesView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInspection_responsesView.PageIndex = e.NewPageIndex;
        BindInspection_ResponseGrid();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
    }
    protected void gvInspection_responsesView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataTable dtDepartment = LU_Department.SelectAll().Tables[0];
        dtDepartment.DefaultView.RowFilter = " Description not in ('General Manager', 'Controller')";
        dtDepartment = dtDepartment.DefaultView.ToTable();
        rptdepartmentview.DataSource = dtDepartment;
        rptdepartmentview.DataBind();
        FK_Inspection_Responses_ID = Convert.ToDecimal(e.CommandArgument);
        Inspection_Responses objInspection_Responses = new Inspection_Responses(Convert.ToInt32(FK_Inspection_Responses_ID));
        string[] strDepartment = objInspection_Responses.Department.ToString().Split(',');
        lblresponse_Deficiencyview.Text = objInspection_Responses.Deficiency_Noted == "Y" ? "YES" : "NO";
        lblRepeat_Deficiencyview.Text = objInspection_Responses.Repeat_Deficiency == "Y" ? "YES" : "NO";
        lblDate_openedview.Text = clsGeneral.FormatDBNullDateToDisplay(objInspection_Responses.Date_Opened);
        lblRecc_Action_View.Text = objInspection_Responses.Recommended_Action;
        lblTar_comp_dateview.Text = clsGeneral.FormatDBNullDateToDisplay(objInspection_Responses.Target_Completion_Date);
        lblAct_com_dateview.Text = clsGeneral.FormatDBNullDateToDisplay(objInspection_Responses.Actual_Completion_Date);
        if (lblAct_com_dateview.Text == "01/01/1753") lblAct_com_dateview.Text = "";
        lblnotesview.Text = objInspection_Responses.Notes;
        Inspection_Questions objInspection_Questions = new Inspection_Questions(Convert.ToInt32(objInspection_Responses.FK_Inspection_Question_ID));
        lblResponseFocus_AreaView.Text = objInspection_Questions.Item_Number_Focus_Area;
        lblQuestionTextView.Text = objInspection_Questions.Question_Text;
        lblGuidancetextview.Text = objInspection_Questions.Guidance_Text;
        lblQuestionNumberview.Text = objInspection_Questions.Question_Number;
        foreach (string str in strDepartment)
        {
            foreach (DataListItem rptItm in rptdepartmentview.Items)
            {
                HtmlInputHidden hdnDeptID = (HtmlInputHidden)rptItm.FindControl("hdnDeptID");
                Label lblValue = (Label)rptItm.FindControl("lblValue");
                if (str == hdnDeptID.Value)
                {
                    lblValue.Text = "Yes";
                    //((Label)rptItm.FindControl("lblDepartment")).Text = new LU_Department((decimal)Convert.ToDecimal(str)).Description;
                }

            }
        }
        TimeSpan ts;
        if (objInspection_Responses.Actual_Completion_Date != null && objInspection_Responses.Date_Opened != null)
        {
            ts = Convert.ToDateTime(objInspection_Responses.Actual_Completion_Date) - Convert.ToDateTime(objInspection_Responses.Date_Opened);
            lblDaysopenView.Text = ts.Days.ToString();
        }
        else
            lblDaysopenView.Text = "";
        BindInspectionView();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
    }
    #endregion
    #region "SLT_Training"

    protected void gvTrainingSuggestions_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditDetails")
        {
            PK_SLT_Training = Convert.ToDecimal(e.CommandArgument);
            SLT_Training objSLT_Training = new SLT_Training(PK_SLT_Training);
            txtTraining_Description.Text = objSLT_Training.Training_Description;
            txtDesired_Comp_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Training.Desired_Comp_Date);
            rdoCompleted.SelectedValue = Convert.ToBoolean(objSLT_Training.Completed) == true ? "Y" : "N";
            txtDate_Completed_Training.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Training.Date_Completed);
            txtComments_Training.Text = objSLT_Training.Comments;
            BindTrainingAttachment();
            btnTrainigAudit_Edit.Visible = true;
        }
        else if (e.CommandName == "ViewDetails")
        {
            PK_SLT_Training = Convert.ToDecimal(e.CommandArgument);
            if (PK_SLT_Training > 0)
            {
                SLT_Training objSLT_Training = new SLT_Training(PK_SLT_Training);
                lblTraining_Description.Text = objSLT_Training.Training_Description;
                lblDesired_Comp_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Training.Desired_Comp_Date);
                lblCompleted.Text = Convert.ToBoolean(objSLT_Training.Completed) == true ? "Yes" : "No";
                lblDate_Completed_Training.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Training.Date_Completed);
                lblComments_Training.Text = objSLT_Training.Comments;
                BindTrainingAttachment();
                btnTrainingAudit_View.Visible = true;
            }
        }
        else if (e.CommandName == "DeleteDetails")
        {
            PK_SLT_Training = Convert.ToDecimal(e.CommandArgument);
            SLT_Training.DeleteByPK(PK_SLT_Training);
            BindGridTrainingSuggstions();
        }
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(10);", true);
    }

    protected void gvTrainingSuggestions_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTrainingSuggestions.PageIndex = e.NewPageIndex;
        BindGridTrainingSuggstions();
        BindTrainingAttachment();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(10);", true);
    }

    protected void gvTrainingSuggestionsView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTrainingSuggestionsView.PageIndex = e.NewPageIndex;
        BindGridTrainingSuggstions();
        BindTrainingAttachment();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(10);", true);
    }

    protected void gvQuarterly_TrainingConducted_ByRLCM_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int Quater, PK_SLT_Training_RLCM = 0;
            LinkButton lnkQuater = (LinkButton)e.Row.FindControl("lnkQualityTraining");
            LinkButton lnkFocus = (LinkButton)e.Row.FindControl("lnkFocus");
            LinkButton lnkTopic = (LinkButton)e.Row.FindControl("lnkTopic");
            LinkButton lnkDate_Scheduled = (LinkButton)e.Row.FindControl("lnkDate_Scheduled");
            LinkButton lnkDate_Completed = (LinkButton)e.Row.FindControl("lnkDate_Completed");
            LinkButton lnkReason_Not_Completed = (LinkButton)e.Row.FindControl("lnkReason_Not_Completed");
            HiddenField hdnPK_SLT_Training_RLCM = (HiddenField)e.Row.FindControl("hdnPK_SLT_Training_RLCM");

            Quater = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quarter"));
            PK_SLT_Training_RLCM = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PK_SLT_Training_RLCM"));

            lnkQuater.Attributes.Add("onclick", "javascript:return OpenRLCM_Training('" + Encryption.Encrypt(Quater.ToString()) + "','" + Encryption.Encrypt(drpTrainingYear.SelectedItem.Text.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Training_RLCM.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Meeting.ToString()) + "','" + Encryption.Encrypt(FK_LU_Location_ID.ToString()) + "','" + StrOperation + "');");
            lnkFocus.Attributes.Add("onclick", "javascript:return OpenRLCM_Training('" + Encryption.Encrypt(Quater.ToString()) + "','" + Encryption.Encrypt(drpTrainingYear.SelectedItem.Text.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Training_RLCM.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Meeting.ToString()) + "','" + Encryption.Encrypt(FK_LU_Location_ID.ToString()) + "','" + StrOperation + "');");
            lnkTopic.Attributes.Add("onclick", "javascript:return OpenRLCM_Training('" + Encryption.Encrypt(Quater.ToString()) + "','" + Encryption.Encrypt(drpTrainingYear.SelectedItem.Text.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Training_RLCM.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Meeting.ToString()) + "','" + Encryption.Encrypt(FK_LU_Location_ID.ToString()) + "','" + StrOperation + "');");
            lnkDate_Scheduled.Attributes.Add("onclick", "javascript:return OpenRLCM_Training('" + Encryption.Encrypt(Quater.ToString()) + "','" + Encryption.Encrypt(drpTrainingYear.SelectedItem.Text.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Training_RLCM.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Meeting.ToString()) + "','" + Encryption.Encrypt(FK_LU_Location_ID.ToString()) + "','" + StrOperation + "');");
            lnkDate_Completed.Attributes.Add("onclick", "javascript:return OpenRLCM_Training('" + Encryption.Encrypt(Quater.ToString()) + "','" + Encryption.Encrypt(drpTrainingYear.SelectedItem.Text.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Training_RLCM.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Meeting.ToString()) + "','" + Encryption.Encrypt(FK_LU_Location_ID.ToString()) + "','" + StrOperation + "');");
            lnkReason_Not_Completed.Attributes.Add("onclick", "javascript:return OpenRLCM_Training('" + Encryption.Encrypt(Quater.ToString()) + "','" + Encryption.Encrypt(drpTrainingYear.SelectedItem.Text.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Training_RLCM.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Meeting.ToString()) + "','" + Encryption.Encrypt(FK_LU_Location_ID.ToString()) + "','" + StrOperation + "');");
        }
    }

    protected void gvQuarterly_TrainingConducted_ByRLCMView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int Quater, PK_SLT_Training_RLCM = 0;
            LinkButton lnkQuaterView = (LinkButton)e.Row.FindControl("lnkQuarterView");
            LinkButton lnkFocusView = (LinkButton)e.Row.FindControl("lnkFocusView");
            LinkButton lnkTopicView = (LinkButton)e.Row.FindControl("lnkTopicView");
            LinkButton lnkDate_ScheduledView = (LinkButton)e.Row.FindControl("lnkDate_ScheduledView");
            LinkButton lnkDate_CompletedView = (LinkButton)e.Row.FindControl("lnkDate_CompletedView");
            LinkButton lnkReason_Not_CompletedView = (LinkButton)e.Row.FindControl("lnkReason_Not_CompletedView");
            HiddenField hdnPK_SLT_Training_RLCMView = (HiddenField)e.Row.FindControl("hdnPK_SLT_Training_RLCM");

            Quater = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quarter"));
            PK_SLT_Training_RLCM = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PK_SLT_Training_RLCM"));


            lnkQuaterView.Attributes.Add("onclick", "javascript:return OpenRLCM_Training('" + Encryption.Encrypt(Quater.ToString()) + "','" + Encryption.Encrypt(drpTrainingYearView.SelectedItem.Text.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Training_RLCM.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Meeting.ToString()) + "','" + Encryption.Encrypt(FK_LU_Location_ID.ToString()) + "','" + StrOperation + "');");
            lnkFocusView.Attributes.Add("onclick", "javascript:return OpenRLCM_Training('" + Encryption.Encrypt(Quater.ToString()) + "','" + Encryption.Encrypt(drpTrainingYearView.SelectedItem.Text.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Training_RLCM.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Meeting.ToString()) + "','" + Encryption.Encrypt(FK_LU_Location_ID.ToString()) + "','" + StrOperation + "');");
            lnkTopicView.Attributes.Add("onclick", "javascript:return OpenRLCM_Training('" + Encryption.Encrypt(Quater.ToString()) + "','" + Encryption.Encrypt(drpTrainingYearView.SelectedItem.Text.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Training_RLCM.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Meeting.ToString()) + "','" + Encryption.Encrypt(FK_LU_Location_ID.ToString()) + "','" + StrOperation + "');");
            lnkDate_ScheduledView.Attributes.Add("onclick", "javascript:return OpenRLCM_Training('" + Encryption.Encrypt(Quater.ToString()) + "','" + Encryption.Encrypt(drpTrainingYearView.SelectedItem.Text.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Training_RLCM.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Meeting.ToString()) + "','" + Encryption.Encrypt(FK_LU_Location_ID.ToString()) + "','" + StrOperation + "');");
            lnkDate_CompletedView.Attributes.Add("onclick", "javascript:return OpenRLCM_Training('" + Encryption.Encrypt(Quater.ToString()) + "','" + Encryption.Encrypt(drpTrainingYearView.SelectedItem.Text.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Training_RLCM.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Meeting.ToString()) + "','" + Encryption.Encrypt(FK_LU_Location_ID.ToString()) + "','" + StrOperation + "');");
            lnkReason_Not_CompletedView.Attributes.Add("onclick", "javascript:return OpenRLCM_Training('" + Encryption.Encrypt(Quater.ToString()) + "','" + Encryption.Encrypt(drpTrainingYearView.SelectedItem.Text.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Training_RLCM.ToString()) + "','" + Encryption.Encrypt(PK_SLT_Meeting.ToString()) + "','" + Encryption.Encrypt(FK_LU_Location_ID.ToString()) + "','" + StrOperation + "');");

        }
    }


    #endregion
    #region "SLTClaim_Management"
    protected void gvClaim_managemetview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvClaim_managemetview.PageIndex = e.NewPageIndex; //Page new index call
        BindClaimManagementGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(9);", true);
    }
    protected void gvClaim_management_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvClaim_management.PageIndex = e.NewPageIndex; //Page new index call
        BindClaimManagementGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(9);", true);
    }

    protected void gvClaim_management_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataTable dtClaim = WC_ClaimInfo.SelectByPK(Convert.ToInt32(e.CommandArgument)).Tables[0];
        if (e.CommandName == "editClaim")
        {
            if (dtClaim != null)
            {
                FK_Claim = Convert.ToDecimal(dtClaim.Rows[0]["PK_Workers_Comp_Claims_ID"]);
                lblClaim_Number.Text = string.IsNullOrEmpty(Convert.ToString(dtClaim.Rows[0]["Origin_Claim_Number"])) ? "" : Convert.ToString(dtClaim.Rows[0]["Origin_Claim_Number"]);
                lblClaimant_name.Text = string.IsNullOrEmpty(Convert.ToString(dtClaim.Rows[0]["Claimant"])) ? "" : Convert.ToString(dtClaim.Rows[0]["Claimant"]);
                lblDate_of_incident.Text = clsGeneral.FormatDBNullDateToDisplay(dtClaim.Rows[0]["Date_of_Accident"]);
                lblDate_reported.Text = clsGeneral.FormatDBNullDateToDisplay(dtClaim.Rows[0]["Date_Reported_To_Insurer"]);
                lblLagtime.Text = string.IsNullOrEmpty(Convert.ToString(dtClaim.Rows[0]["Lag_Time"])) ? "" : Convert.ToString(dtClaim.Rows[0]["Lag_Time"]) + " Days";
                lblClaim_Status.Text = string.IsNullOrEmpty(Convert.ToString(dtClaim.Rows[0]["Claim_Status"])) ? "" : Convert.ToString(dtClaim.Rows[0]["Claim_Status"]);
                lblCause_injury_desc.Text = string.IsNullOrEmpty(Convert.ToString(dtClaim.Rows[0]["Cause_Injury_Body_Part_Description"])) ? "" : Convert.ToString(dtClaim.Rows[0]["Cause_Injury_Body_Part_Description"]);
                BindClaimManagementDetails();
                btnSaveClaimmanagement.Enabled = true;
            }

        }
        else if (e.CommandName == "viewClaim")
        {
            {
                FK_Claim = Convert.ToDecimal(dtClaim.Rows[0]["PK_Workers_Comp_Claims_ID"]);
                lblCliam_numberview.Text = string.IsNullOrEmpty(Convert.ToString(dtClaim.Rows[0]["Origin_Claim_Number"])) ? "" : Convert.ToString(dtClaim.Rows[0]["Origin_Claim_Number"]);
                lblclaimant_view.Text = string.IsNullOrEmpty(Convert.ToString(dtClaim.Rows[0]["Claimant"])) ? "" : Convert.ToString(dtClaim.Rows[0]["Claimant"]);
                lblIncident_date_view.Text = clsGeneral.FormatDBNullDateToDisplay(dtClaim.Rows[0]["Date_of_Accident"]);
                lblDate_reportedview.Text = clsGeneral.FormatDBNullDateToDisplay(dtClaim.Rows[0]["Date_Reported_To_Insurer"]);
                lbllagtimeview.Text = string.IsNullOrEmpty(Convert.ToString(dtClaim.Rows[0]["Lag_Time"])) ? "" : Convert.ToString(dtClaim.Rows[0]["Lag_Time"]) + " Days";
                lblClaim_statusView.Text = string.IsNullOrEmpty(Convert.ToString(dtClaim.Rows[0]["Claim_Status"])) ? "" : Convert.ToString(dtClaim.Rows[0]["Claim_Status"]);
                lblCause_InjuryView.Text = string.IsNullOrEmpty(Convert.ToString(dtClaim.Rows[0]["Cause_Injury_Body_Part_Description"])) ? "" : Convert.ToString(dtClaim.Rows[0]["Cause_Injury_Body_Part_Description"]);
                BindClaimManagementDetails();
            }
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(9);", true);

    }
    #endregion
    #region "SLT_Safety_Walk"
    protected void gvSafetyWalk_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSafetyWalk.PageIndex = e.NewPageIndex; //Page new index call
        BindSaftyWalkGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }
    protected void gvSafetyWalkView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSafetyWalkView.PageIndex = e.NewPageIndex; //Page new index call
        BindSaftyWalkGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }
    protected void gvSafetyWalk_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((DataBinder.Eval(e.Row.DataItem, "PK_SLT_Members") != DBNull.Value))
            {
                PK_SLT_Member = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PK_SLT_Members"));
                DataTable dtSLTSafety_Walk_Members = SLT_Safety_Walk_Members.SelectByFk(PK_SLT_Member, PK_SLT_Safety_Walk).Tables[0];
                bool Participated = false;
                if (dtSLTSafety_Walk_Members.Rows.Count > 0)
                {
                    if (dtSLTSafety_Walk_Members.Rows[0]["Participated"] != DBNull.Value)
                        Participated = Convert.ToBoolean(dtSLTSafety_Walk_Members.Rows[0]["Participated"]);
                }
                ((RadioButtonList)(e.Row.FindControl("rdoParticipated"))).SelectedValue = Participated == true ? "Y" : "N";
            }
        }
    }
    protected void gvSafetyWalkView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((DataBinder.Eval(e.Row.DataItem, "PK_SLT_Members") != DBNull.Value))
            {
                PK_SLT_Member = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PK_SLT_Members"));
                DataTable dtSLTSafety_Walk_Members = SLT_Safety_Walk_Members.SelectByFk(PK_SLT_Member, PK_SLT_Safety_Walk).Tables[0];
                bool Participated = false;
                if (dtSLTSafety_Walk_Members.Rows.Count > 0)
                {
                    if (dtSLTSafety_Walk_Members.Rows[0]["Participated"] != DBNull.Value)
                        Participated = Convert.ToBoolean(dtSLTSafety_Walk_Members.Rows[0]["Participated"]);
                }
                ((Label)(e.Row.FindControl("lblparticipated"))).Text = Participated == true ? "Yes" : "No";
            }
        }
    }
    #endregion
    #endregion

    #region"Attachment Grid"
    #region "Safty_Walk"
    /// <summary>
    /// Handles building Attachment grid rowcommand event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSafetywalkAttachmentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for removing attachment then
        // delete the attachment record by PK passed in command argument and
        // bind the grid
        if (e.CommandName == "RemoveAttachment")
        {
            string[] strArgs = e.CommandArgument.ToString().Split(':');
            int intPK = Convert.ToInt32(strArgs[0]);
            string strFileName = strArgs[1];
            ERIMSAttachment.DeleteByPK(intPK);
            BindSafetyWalkAttachment();

            // delete file
            string strPath = clsGeneral.GetAttachmentDocPath(clsGeneral.SLT_TablesNames[(int)clsGeneral.SLT_Tables.SLT_Safety_Walk]) + strFileName;
            if (File.Exists(strPath))
                File.Delete(strPath);
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Handles afty walk grid row data bound event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSafetywalkAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for the datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the filename link control
            HtmlAnchor lnkSaftywalkAttachFile = (HtmlAnchor)e.Row.FindControl("lnkSaftywalkAttachFile");

            // get the file name value from binder
            string strFileName = DataBinder.Eval(e.Row.DataItem, "Attachment_Name").ToString();
            // strFileName = AppConfig.strSLT_SafetyWalkDocPath + strFileName;

            // set click attribute to open file on clicking the link
            lnkSaftywalkAttachFile.Attributes.Add("onclick", "javascript:openWindowAbstract('../../Download.aspx?fname=" + Encryption.Encrypt(strFileName) + "&SLT=safetywalk');");
        }
    }
    /// <summary>
    /// Handles Safty walk grid row data bound event in view mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSafetywalkAttachmentView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for the datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the filename link control
            HtmlAnchor lnkSaftywalkAttachFile = (HtmlAnchor)e.Row.FindControl("lnkSaftywalkAttachFile");

            // get the file name value from binder
            string strFileName = DataBinder.Eval(e.Row.DataItem, "Attachment_Name").ToString();
            //strFileName = AppConfig.strSLT_SafetyWalkDocPath + strFileName;

            // set click attribute to open file on clicking the link
            lnkSaftywalkAttachFile.Attributes.Add("onclick", "javascript:window.open('../../Download.aspx?fname=" + Encryption.Encrypt(strFileName) + "&SLT=safetywalk');");
        }
    }
    #endregion
    #region "SLT_Training"
    protected void gvSLT_TrainingAttachment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for removing attachment then
        // delete the attachment record by PK passed in command argument and
        // bind the grid
        if (e.CommandName == "RemoveAttachment")
        {
            string[] strArgs = e.CommandArgument.ToString().Split(':');
            int intPK = Convert.ToInt32(strArgs[0]);
            string strFileName = strArgs[1];
            ERIMSAttachment.DeleteByPK(intPK);
            BindTrainingAttachment();

            // delete file
            string strPath = clsGeneral.GetAttachmentDocPath(clsGeneral.SLT_TablesNames[(int)clsGeneral.SLT_Tables.SLT_Training]) + strFileName;
            if (File.Exists(strPath))
                File.Delete(strPath);
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(10);", true);
    }

    /// <summary>
    /// Handles SLT_TrainingAttachment grid row data bound event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSLT_TrainingAttachment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for the datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the filename link control
            HtmlAnchor lnkTrainingAttachFile = (HtmlAnchor)e.Row.FindControl("lnkTrainingAttachFile");

            // get the file name value from binder
            string strFileName = DataBinder.Eval(e.Row.DataItem, "Attachment_Name").ToString();
            //strFileName = AppConfig.strSLT_TrainingDocsPath + strFileName;

            // set click attribute to open file on clicking the link
            lnkTrainingAttachFile.Attributes.Add("onclick", "javascript:openWindowAbstract('../../Download.aspx?fname=" + Encryption.Encrypt(strFileName) + "&SLT=training');");
        }
    }
    /// <summary>
    /// Handles SLT_TrainingAttachment grid row data bound event for view mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSLT_TrainingAttachmentView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for the datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the filename link control
            HtmlAnchor lnkTrainingAttachFile = (HtmlAnchor)e.Row.FindControl("lnkTrainingAttachFile");

            // get the file name value from binder
            string strFileName = DataBinder.Eval(e.Row.DataItem, "Attachment_Name").ToString();
            // strFileName = AppConfig.strSLT_TrainingDocsPath + strFileName;

            // set click attribute to open file on clicking the link
            lnkTrainingAttachFile.Attributes.Add("onclick", "javascript:openWindowAbstract('../../Download.aspx?fname=" + Encryption.Encrypt(strFileName) + "&SLT=training');");
        }
    }
    #endregion
    #endregion

    #region " Validations "

    private void SetValidations()
    {
        #region " SLT Members "

        string strCtrlsIDs = "";
        string strMessages = "";
        DataTable dtFields = clsScreen_Validators.SelectByScreen(177).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Member Start Date": strCtrlsIDs += txtMembersStart_Date.ClientID + ","; strMessages += "Please enter [SLT Members]/Member Start Date" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Member End Date": strCtrlsIDs += txtmemberEnd_date.ClientID + ","; strMessages += "Please enter [SLT Members]/Member End Date" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Member Name": strCtrlsIDs += txtMemberLast_Name.ClientID + ","; strMessages += "Please enter [SLT Members]/Member Name" + ","; Span3.Style["display"] = "inline-block";
                    //}
                    //else
                    //{
                    //    strCtrlsIDs += drpFK_Employee.ClientID + ",";
                    //    strMessages += "Please select [SLT Members]/Member Name" + ",";
                    //    Span3_New.Style["display"] = "inline-block";
                    //}
                    break;
                case "Department": strCtrlsIDs += drpDepartment.ClientID + ","; strMessages += "Please select [SLT Members]/Department" + ","; Span4.Style["display"] = "inline-block"; break;
                case "SLT Role": strCtrlsIDs += drpSLT_Role.ClientID + ","; strMessages += "Please select [SLT Members]/SLT Role" + ","; Span5.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsMembers.Value = strCtrlsIDs;
        hdnErrorMsgsMembers.Value = strMessages;

        #endregion

        #region " Meeting Attendees "

        strCtrlsIDs = "";
        strMessages = "";
        dtFields = clsScreen_Validators.SelectByScreen(178).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Actual Meeting Date": strCtrlsIDs += txtActual_Meeting_Date.ClientID + ","; strMessages += "Please enter [Meeting Attendees]/Actual Meeting Date" + ","; Span6.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsAttendees.Value = strCtrlsIDs;
        hdnErrorMsgsAttendees.Value = strMessages;

        #endregion

        #region " Call to Order "

        strCtrlsIDs = "";
        strMessages = "";
        dtFields = clsScreen_Validators.SelectByScreen(179).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Meeting Start Time": strCtrlsIDs += txtMeeting_Start_Time.ClientID + ","; strMessages += "Please enter [Call to Order]/Meeting Start Time" + ","; Span7.Style["display"] = "inline-block"; break;
                case "Meeting End Time": strCtrlsIDs += txtMeeting_End_Time.ClientID + ","; strMessages += "Please enter [Call to Order]/Meeting End Time" + ","; Span8.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDscallToOrder.Value = strCtrlsIDs;
        hdnErrorMsgscallToOrder.Value = strMessages;

        #endregion

        #region " Safety Walk "
        DateTime startOfMonth = new DateTime(AppConfig.New_SLT_Safety_Walk_Date.Year, AppConfig.New_SLT_Safety_Walk_Date.Month, 1);
        TimeSpan ts = Actual_Meeting_Date.Subtract(startOfMonth);
        if (ts.Days < 0)
        {
            strCtrlsIDs = "";
            strMessages = "";
            //dtFields = clsScreen_Validators.SelectByScreen(180).Tables[0];
            //dtFields.DefaultView.RowFilter = "IsRequired = '1'";
            //dtFields = dtFields.DefaultView.ToTable();
            //foreach (DataRow drField in dtFields.Rows)
            //{
            //    #region " set validation control IDs and messages "
            //    switch (Convert.ToString(drField["Field_Name"]))
            //    {
            //        case "Date Completed": strCtrlsIDs += txtSafety_Walk_Comp_Date.ClientID + ","; strMessages += "Please enter [Safety Walk]/Date Completed" + ","; Span9.Style["display"] = "inline-block"; break;
            //    }
            //    #endregion
            //}

            strCtrlsIDs += txtSafety_Walk_Comp_Date.ClientID + ","; strMessages += "Please enter [Safety Walk]/Date Completed" + ",";
            strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
            strMessages = strMessages.TrimEnd(',');

            hdnControlIDsSafety.Value = strCtrlsIDs;
            hdnErrorMsgsSafety.Value = strMessages;
        }
        #endregion

        #region " Quarterly Facility Inspection "

        strCtrlsIDs = "";
        strMessages = "";
        dtFields = clsScreen_Validators.SelectByScreen(181).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Assigned To": strCtrlsIDs += drpFK_SLT_Members.ClientID + ","; strMessages += "Please select [Quarterly Facility Inspection]/Assigned To" + ","; Span10.Style["display"] = "inline-block"; break;
                case "Date Completed": strCtrlsIDs += txtDate_Completed_Inspection.ClientID + ","; strMessages += "Please enter [Quarterly Facility Inspection]/Date Completed" + ","; Span11.Style["display"] = "inline-block"; break;
                case "Comments": strCtrlsIDs += txtComments_Inspection.ClientID + ","; strMessages += "Please enter [Quarterly Facility Inspection]/Comments" + ","; Span12.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsInspection.Value = strCtrlsIDs;
        hdnErrorMsgsInspection.Value = strMessages;

        #endregion

        #region " Claim Management "

        strCtrlsIDs = "";
        strMessages = "";
        dtFields = clsScreen_Validators.SelectByScreen(187).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Lag Explaination": strCtrlsIDs += txtLag_explaination.ClientID + ","; strMessages += "Please enter [Claim Management]/Lag Explaination" + ","; Span13.Style["display"] = "inline-block"; break;
                case "What is the associates current Status": strCtrlsIDs += drpAssociates_Status.ClientID + ","; strMessages += "Please select [Claim Management]/What is the associates current Status" + ","; Span14.Style["display"] = "inline-block"; break;
                case "If in a modified Light Duty Position Explain": strCtrlsIDs += txtLight_Duty.ClientID + ","; strMessages += "Please enter [Claim Management]/If in a modified Light Duty Position Explain" + ","; Span15.Style["display"] = "inline-block"; break;
                case "Comments": strCtrlsIDs += txtComments.ClientID + ","; strMessages += "Please enter [Claim Management]/Comments" + ","; Span16.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsClaim.Value = strCtrlsIDs;
        hdnErrorMsgsClaim.Value = strMessages;

        #endregion

        #region " Sonic Univresity Training Suggestions "

        strCtrlsIDs = "";
        strMessages = "";
        dtFields = clsScreen_Validators.SelectByScreen(188).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Type/Description of Training": strCtrlsIDs += txtTraining_Description.ClientID + ","; strMessages += "Please enter [Training Suggestions]/Type/Description of Training" + ","; Span17.Style["display"] = "inline-block"; break;
                case "Desired Date to Have Training Completed": strCtrlsIDs += txtDesired_Comp_Date.ClientID + ","; strMessages += "Please enter [Training Suggestions]/Desired Date to Have Training Completed" + ","; Span18.Style["display"] = "inline-block"; break;
                case "Date Completed": strCtrlsIDs += txtDate_Completed_Training.ClientID + ","; strMessages += "Please enter [Training Suggestions]/Date Completed" + ","; Span19.Style["display"] = "inline-block"; break;
                case "Comments": strCtrlsIDs += txtComments_Training.ClientID + ","; strMessages += "Please enter [Training Suggestions]/Comments" + ","; Span20.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsTraining.Value = strCtrlsIDs;
        hdnErrorMsgsTraining.Value = strMessages;

        #endregion

        #region " New Procedures "

        strCtrlsIDs = "";
        strMessages = "";
        dtFields = clsScreen_Validators.SelectByScreen(189).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Importance": strCtrlsIDs += drpFK_LU_Importance.ClientID + ","; strMessages += "Please select [New Procedures]/Importance" + ","; Span21.Style["display"] = "inline-block"; break;
                case "Procedure Source": strCtrlsIDs += drpFK_LU_Procedure_Source.ClientID + ","; strMessages += "Please select [New Procedures]/Procedure Source" + ","; Span22.Style["display"] = "inline-block"; break;
                case "Procedure Description": strCtrlsIDs += txtProcedure_Description.ClientID + ","; strMessages += "Please enter [New Procedures]/Procedure Description" + ","; Span23.Style["display"] = "inline-block"; break;
                case "Action Item": strCtrlsIDs += txtAction_Item.ClientID + ","; strMessages += "Please enter [New Procedures]/Action Item" + ","; Span24.Style["display"] = "inline-block"; break;
                case "Assigned To": strCtrlsIDs += drpProcedureAssignet_to.ClientID + ","; strMessages += "Please select [New Procedures]/Assigned To" + ","; Span25.Style["display"] = "inline-block"; break;
                case "Target Completion Date": strCtrlsIDs += txtTarget_Completion_Date.ClientID + ","; strMessages += "Please enter [New Procedures]/Target Completion Date" + ","; Span26.Style["display"] = "inline-block"; break;
                case "Date Completed": strCtrlsIDs += txtDate_Completed.ClientID + ","; strMessages += "Please enter [New Procedures]/Date Completed" + ","; Span27.Style["display"] = "inline-block"; break;
                case "Status": strCtrlsIDs += drpFK_LU_Item_Status.ClientID + ","; strMessages += "Please select [New Procedures]/Status" + ","; Span28.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsProcedure.Value = strCtrlsIDs;
        hdnErrorMsgsProcedure.Value = strMessages;

        #endregion

        #region " Suggestions "

        strCtrlsIDs = "";
        strMessages = "";
        dtFields = clsScreen_Validators.SelectByScreen(190).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Assigned To": strCtrlsIDs += DrpAssigned_To_Sugg.ClientID + ","; strMessages += "Please select [Suggestions]/Assigned To" + ","; Span29.Style["display"] = "inline-block"; break;
                case "Suggestion Source": strCtrlsIDs += drpFK_LU_Suggestion_Source.ClientID + ","; strMessages += "Please select [Suggestions]/Suggestion Source" + ","; Span30.Style["display"] = "inline-block"; break;
                case "Importance": strCtrlsIDs += drpFK_LU_Importance_Sugg.ClientID + ","; strMessages += "Please select [Suggestions]/Importance" + ","; Span31.Style["display"] = "inline-block"; break;
                case "Target Completion Date": strCtrlsIDs += txtTarget_Completion_Date_Sugg.ClientID + ","; strMessages += "Please enter [Suggestions]/Target Completion Date" + ","; Span32.Style["display"] = "inline-block"; break;
                case "Suggestion": strCtrlsIDs += txtSuggestion_Description.ClientID + ","; strMessages += "Please enter [Suggestions]/Suggestion" + ","; Span33.Style["display"] = "inline-block"; break;
                case "Action Item": strCtrlsIDs += txtAction_Item_Sugg.ClientID + ","; strMessages += "Please enter [Suggestions]/Action Item" + ","; Span34.Style["display"] = "inline-block"; break;
                case "Date Completed": strCtrlsIDs += txtDate_Completed_Sugg.ClientID + ","; strMessages += "Please enter [Suggestions]/Date Completed" + ","; Span35.Style["display"] = "inline-block"; break;
                case "Status": strCtrlsIDs += drpFK_LU_Item_Status_Sugg.ClientID + ","; strMessages += "Please select [Suggestions]/Status" + ","; Span36.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsSuggestion.Value = strCtrlsIDs;
        hdnErrorMsgsSuggestion.Value = strMessages;

        #endregion

        #region " Meeting Schedule "

        strCtrlsIDs = "";
        strMessages = "";
        dtFields = clsScreen_Validators.SelectByScreen(191).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date": strCtrlsIDs += txtScheduled_Meeting_Date.ClientID + ","; strMessages += "Please enter [Meeting Schedule]/Date" + ","; Span37.Style["display"] = "inline-block"; break;
                case "Time": strCtrlsIDs += txtScheduled_Meeting_Time.ClientID + ","; strMessages += "Please enter [Meeting Schedule]/Time" + ","; Span38.Style["display"] = "inline-block"; break;
                case "Meeting Place": strCtrlsIDs += txtMeeting_Place.ClientID + ","; strMessages += "Please enter [Meeting Schedule]/Meeting Place" + ","; Span39.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDs += drpTime_Zone.ClientID + ","; strMessages += "Please Select [Meeting Schedule]/Time Zone" + ","; Span43.Style["display"] = "inline-block";

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsSchedule.Value = strCtrlsIDs;
        hdnErrorMsgsSchedule.Value = strMessages;

        #endregion

        #region " Meeting Review "

        strCtrlsIDs = "";
        strMessages = "";
        dtFields = clsScreen_Validators.SelectByScreen(192).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "SLT Meeting Reviewed/Approved": strCtrlsIDs += txtMeeting_Approved_date.ClientID + ","; strMessages += "Please enter [Meeting Review]/SLT Meeting Reviewed/Approved" + ","; Span40.Style["display"] = "inline-block"; break;
                case "Review Quality": strCtrlsIDs += drpFK_LU_Meeting_Quality.ClientID + ","; strMessages += "Please select [Meeting Review]/Review Quality" + ","; Span41.Style["display"] = "inline-block"; break;
                case "Comments": strCtrlsIDs += txtMeeting_Comment.ClientID + ","; strMessages += "Please enter [Meeting Review]/Comments" + ","; Span42.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsReview.Value = strCtrlsIDs;
        hdnErrorMsgsReview.Value = strMessages;

        #endregion
    }

    #endregion

    protected void gvSLTSafetyWalk_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "Page")
        {
            string[] strArgs = e.CommandArgument.ToString().Split(':');
            #region "If Record is not added then first save and then open observation open popup"
            string strMonthName = strArgs[0].ToString(); //e.CommandArgument.ToString();
            string strYear = Convert.ToString(Actual_Meeting_Date.Year);
            decimal FK_SLTID = 0;

            //if (strArgs[1] == "") //needs to update the record.
            //{
            GridViewRow gRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            TextBox txtCompletedDate = (TextBox)gRow.FindControl("txtCompletedDate");
            RadioButtonList rdoParticipated = (RadioButtonList)gRow.FindControl("rdoParticipated");
            HiddenField hdnMonthNumber = (HiddenField)gRow.FindControl("hdnMonthNumber");
            HiddenField hdnPK_SLT_Safety_Walk = (HiddenField)gRow.FindControl("hdnPK_SLT_Safety_Walk");
            HiddenField hdnPK_SLT_Meeting_Schedule = (HiddenField)gRow.FindControl("hdnPK_SLT_Meeting_Schedule");

            if (txtCompletedDate != null && txtCompletedDate.Enabled)
            {
                if (PK_SLT_Meeting_Schedule > 0)
                {
                    decimal temp_PK_SLT_Meeting_Schedule = 0;
                    temp_PK_SLT_Meeting_Schedule = Convert.ToDecimal(hdnPK_SLT_Meeting_Schedule.Value);
                    if (temp_PK_SLT_Meeting_Schedule > 0)
                    {
                        SLT_Safety_Walk objSLT_Safety_Walk = new SLT_Safety_Walk(temp_PK_SLT_Meeting_Schedule, true);

                        objSLT_Safety_Walk.FK_SLT_Meeting = PK_SLT_Meeting;

                        if (!string.IsNullOrEmpty(hdnPK_SLT_Safety_Walk.Value))
                            objSLT_Safety_Walk.PK_SLT_Safety_Walk = Convert.ToDecimal(hdnPK_SLT_Safety_Walk.Value);

                        objSLT_Safety_Walk.FK_SLT_Meeting_Schedule = temp_PK_SLT_Meeting_Schedule;
                        objSLT_Safety_Walk.Safety_Walk_Comp = rdoParticipated.SelectedValue == "Y";
                        objSLT_Safety_Walk.Safety_Walk_Comp_Date = clsGeneral.FormatNullDateToStore(txtCompletedDate.Text);
                        objSLT_Safety_Walk.Update_Date = System.DateTime.Now;
                        objSLT_Safety_Walk.Updated_By = clsSession.UserID;

                        if (!string.IsNullOrEmpty(objSLT_Safety_Walk.PK_SLT_Safety_Walk.ToString()))
                        {
                            if (objSLT_Safety_Walk.PK_SLT_Safety_Walk > 0)
                            {
                                objSLT_Safety_Walk.Update();
                                if (!string.IsNullOrEmpty(hdnPK_SLT_Safety_Walk.Value))
                                {
                                    FK_SLTID = Convert.ToDecimal(hdnPK_SLT_Safety_Walk.Value);
                                }
                                else
                                {
                                    FK_SLTID = Convert.ToDecimal(objSLT_Safety_Walk.PK_SLT_Safety_Walk);
                                }
                            }
                            else
                            {
                                FK_SLTID = objSLT_Safety_Walk.Insert();
                                BindSaftyWalkGridNew();
                            }
                        }
                        else
                        {
                            FK_SLTID = objSLT_Safety_Walk.Insert();
                            BindSaftyWalkGridNew();
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);alert('Please add or select meeting agenda record');", true);
                }
            }
            //}
            //else
            //    FK_SLTID = Convert.ToInt32(strArgs[1].ToString());

            #endregion
            string openMode = "";
            if (StrOperation != "view" && meetingIsEditable == true)
                openMode = "edit";
            else
                openMode = "view";

            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            HiddenField hdnTmpPK_SLT_Meeting_Schedule = (HiddenField)gvRow.FindControl("hdnPK_SLT_Meeting_Schedule");
            HiddenField hdnActualMeetingDate = (HiddenField)gvRow.FindControl("hdnActualMeetingDate");
            decimal tmp_PK_SLT_Meeting_Schedule = 0;
            if (Convert.ToDecimal(hdnTmpPK_SLT_Meeting_Schedule.Value) > 0)
                tmp_PK_SLT_Meeting_Schedule = Convert.ToDecimal(hdnTmpPK_SLT_Meeting_Schedule.Value);
            else
                tmp_PK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;
            if (e.CommandName == "ObservationOpen")
            {
                DataSet dsQuestions = LU_SLT_Safety_Walk_Focus_Area.SelectByMonthAndYear(clsGeneral.GetInt(strYear), strMonthName, 0, PK_SLT_Meeting_Schedule);
                if (dsQuestions != null)
                {
                    if (dsQuestions.Tables.Count > 0)
                    {
                        DataTable dtMonthlyQuestions = dsQuestions.Tables[0];
                        dtMonthlyQuestions.DefaultView.RowFilter = " Complete_Status = 'Open'";
                        dtMonthlyQuestions = dtMonthlyQuestions.DefaultView.ToTable();
                        //string[] arg = new string[2];

                        //arg = e.CommandArgument.ToString().Split(':');
                        //if (dsQuestions.Tables[0].Rows.Count > 0)
                        if (dtMonthlyQuestions.Rows.Count > 0)
                            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:window.open('../SLTSafetyWalk/SLT_SafetyWalk_Questions_Popup.aspx?id=" + Encryption.Encrypt(dtMonthlyQuestions.Rows[0]["PK_LU_SLT_Safety_Walk_Focus_Area"].ToString()) + "&Month=" + Encryption.Encrypt(strMonthName) + "&Year=" + Encryption.Encrypt(strYear) + "&FK_SLTID=" + FK_SLTID.ToString() + "&PK_SLT_Meeting=" + PK_SLT_Meeting.ToString() + "&PK_MSID=" + tmp_PK_SLT_Meeting_Schedule + "&AM_date=" + hdnActualMeetingDate.Value + "&op=" + openMode + "','Erims','location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=900,height=750');", true);
                        else
                            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:window.open('../SLTSafetyWalk/SLT_SafetyWalk_Questions_Popup.aspx?id=" + Encryption.Encrypt(dsQuestions.Tables[0].Rows[0]["PK_LU_SLT_Safety_Walk_Focus_Area"].ToString()) + "&Month=" + Encryption.Encrypt(strMonthName) + "&Year=" + Encryption.Encrypt(strYear) + "&FK_SLTID=" + FK_SLTID.ToString() + "&PK_SLT_Meeting=" + PK_SLT_Meeting.ToString() + "&PK_MSID=" + tmp_PK_SLT_Meeting_Schedule + "&AM_date=" + hdnActualMeetingDate.Value + "&op=" + openMode + "','Erims','location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=900,height=750');", true);
                    }
                }
            }
            else if (e.CommandName == "Participation")
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:window.open('../SLT/Safety_Walk_Participant_Popup.aspx?PK_SLT_Meeting=" + PK_SLT_Meeting.ToString() + "&FK_SLTID=" + FK_SLTID.ToString() + "&month=" + strMonthName.ToString() + "&year=" + strYear + "&op=" + openMode + "&AM_date=" + hdnActualMeetingDate.Value + "','Erims','location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=350');", true);
            }
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
        }
    }
    protected void btnSave_SLTSafety_Click(object sender, EventArgs e)
    {
        SaveNewSafetyWalk(false);
    }

    /// <summary>
    /// saving value for new safety walk
    /// </summary>
    private void SaveNewSafetyWalk(bool isSaveandNext)
    {
        foreach (GridViewRow row in gvSLTSafetyWalk.Rows)
        {
            TextBox txtCompletedDate = (TextBox)row.FindControl("txtCompletedDate");
            RadioButtonList rdoParticipated = (RadioButtonList)row.FindControl("rdoParticipated");
            HiddenField hdnMonthNumber = (HiddenField)row.FindControl("hdnMonthNumber");
            HiddenField hdnPK_SLT_Safety_Walk = (HiddenField)row.FindControl("hdnPK_SLT_Safety_Walk");
            HiddenField hdnPK_SLT_Meeting_Schedule = (HiddenField)row.FindControl("hdnPK_SLT_Meeting_Schedule");
            HiddenField hdnActualMeetingDate = (HiddenField)row.FindControl("hdnActualMeetingDate");

            if (txtCompletedDate.Enabled)
            {
                if (PK_SLT_Meeting_Schedule > 0)
                {
                    if (hdnActualMeetingDate.Value != "")
                    {
                        //DataTable Dtmeeting_ScheduleEdit = SLT_Meeting_Schedule.SelectBYFK(PK_SLT_Meeting, null, null,Convert.ToInt16(Year), Convert.ToInt16(hdnMonthNumber.Value)).Tables[0];
                        decimal temp_PK_SLT_Meeting_Schedule = 0;
                        //if (!string.IsNullOrEmpty(Dtmeeting_ScheduleEdit.Rows[0]["PK_SLT_Meeting_Schedule"].ToString()))
                        //{
                        //    temp_PK_SLT_Meeting_Schedule = Convert.ToDecimal(Dtmeeting_ScheduleEdit.Rows[0]["PK_SLT_Meeting_Schedule"]);
                        //}
                        if (Convert.ToDecimal(hdnPK_SLT_Meeting_Schedule.Value) > 0)
                            temp_PK_SLT_Meeting_Schedule = Convert.ToDecimal(hdnPK_SLT_Meeting_Schedule.Value);
                        else
                            temp_PK_SLT_Meeting_Schedule = PK_SLT_Meeting_Schedule;

                        if (temp_PK_SLT_Meeting_Schedule > 0)
                        {
                            SLT_Safety_Walk objSLT_Safety_Walk = new SLT_Safety_Walk(temp_PK_SLT_Meeting_Schedule, true);

                            //objSLT_Safety_Walk.PK_SLT_Safety_Walk = PK_SLT_Safety_Walk;
                            objSLT_Safety_Walk.FK_SLT_Meeting = PK_SLT_Meeting;
                            objSLT_Safety_Walk.FK_SLT_Meeting_Schedule = temp_PK_SLT_Meeting_Schedule;
                            objSLT_Safety_Walk.Safety_Walk_Comp = rdoParticipated.SelectedValue == "Y";
                            objSLT_Safety_Walk.Safety_Walk_Comp_Date = clsGeneral.FormatNullDateToStore(txtCompletedDate.Text);

                            objSLT_Safety_Walk.Update_Date = System.DateTime.Now;
                            objSLT_Safety_Walk.Updated_By = clsSession.UserID;
                            if ((rdoParticipated.SelectedValue == "Y" && txtCompletedDate.Text != "") || rdoParticipated.SelectedValue == "N")
                            {
                                if (!string.IsNullOrEmpty(objSLT_Safety_Walk.PK_SLT_Safety_Walk.ToString()))
                                {
                                    if (objSLT_Safety_Walk.PK_SLT_Safety_Walk > 0)
                                    {
                                        objSLT_Safety_Walk.Update();
                                        GetSLT_Score();
                                    }
                                    else
                                    {
                                        try
                                        {
                                            PK_SLT_Safety_Walk = objSLT_Safety_Walk.Insert();
                                            GetSLT_Score();
                                        }
                                        catch (Exception ex)
                                        {
                                            if (ex.Message.Contains("Duplicate Safety Walk"))
                                            {
                                                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);alert('There is already safety walk available for this month.Please try again.');", true);
                                            }
                                            else
                                            {
                                                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);alert('Error occured while saving your data.');", true);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        PK_SLT_Safety_Walk = objSLT_Safety_Walk.Insert();
                                        GetSLT_Score();
                                    }
                                    catch (Exception ex)
                                    {
                                        if (ex.Message.Contains("Duplicate Safety Walk"))
                                        {
                                            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);alert('There is already safety walk available for this month.');", true);
                                        }
                                        else
                                        {
                                            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);alert('Error occured while saving your data.');", true);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);alert('Please enter [Safety Walk]/Date Completed');", true);
                            }
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);alert('Please enter the Actual Meeting Date on the Meeting Attendees screen before proceeding.');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);alert('Please add or select meeting agenda record');", true);
                }

            }
        }

        if (!isSaveandNext)
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    protected void gvSLTSafetyWalk_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdnSafety_Walk_Comp = (HiddenField)e.Row.FindControl("hdnSafety_Walk_Comp");
            ((RadioButtonList)(e.Row.FindControl("rdoParticipated"))).SelectedValue = hdnSafety_Walk_Comp.Value == "True" ? "Y" : "N";
        }
    }
    protected void btnhdnReload_Click(object sender, EventArgs e)
    {
        BindSaftyWalkGridNew();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    protected void btnReload_Participant_Click(object sender, EventArgs e)
    {
        GetSLT_Score();
        BindMeetingScheduleGrid();
        //gvMeeting_RowCommand("EditMeeting");        
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }
    protected void drpFK_Employee_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpFK_Employee.SelectedValue != "0")
        {
            Employee objEmployee = new Employee(Convert.ToDecimal(drpFK_Employee.SelectedValue));
            if (!string.IsNullOrEmpty(objEmployee.Email))
                txtMember_Email.Text = objEmployee.Email.Trim();
        }
        else
            txtMember_Email.Text = string.Empty;
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
}
