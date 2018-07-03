using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_SLT_Safety_Walk_Participant_Popup : clsBasePage
{

    #region "Properties"
    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal PK_SLT_Meeting
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["PK_SLT_Meeting"]))
            {
                return clsGeneral.GetDecimal(Request.QueryString["PK_SLT_Meeting"]);
            }
            else
                return 0;
        }

    }

    /// <summary>
    /// FK_SLT_Safety_Walk for SLT Safety
    /// </summary>
    private decimal FK_SLT_Safety_Walk
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["FK_SLTID"]))
            {
                return Convert.ToDecimal(Request.QueryString["FK_SLTID"]);
                //return Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["FK_SLTID"]));
            }
            else
            {
                return 0;
            }
        }
    }
    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public int Month
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["month"]))
            {
                return clsGeneral.GetInt(Request.QueryString["month"]);
            }
            else
                return 0;
        }

    }
    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public int Year
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["year"]))
            {
                return clsGeneral.GetInt(Request.QueryString["year"]);
            }
            else
                return 0;
        }

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
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }
    private DateTime? Actual_Meeting_Date
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["AM_date"]))
                return Convert.ToDateTime(Request.QueryString["AM_date"]);
            else
                return null;
        }
    }
    
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["op"] != null) { StrOperation = Convert.ToString(Request.QueryString["op"]); }

            BindAttendeesGrid();
        }
    }

    private void BindAttendeesGrid()
    {
        DataTable dtSlt_members = SLT_Members.SLT_Safety_Walk_MembersSelectByPK_SLT_Meeting(PK_SLT_Meeting, FK_SLT_Safety_Walk, 0).Tables[0];
        if (StrOperation != string.Empty)
        {
            if (StrOperation == "view")
            {
                pnl1View.Visible = true;
                pnl1.Visible = false;
                if (dtSlt_members != null && dtSlt_members.Rows.Count > 0)
                {
                    gv_MeetingAttendeesView.DataSource = dtSlt_members;
                    gv_MeetingAttendeesView.DataBind();
                }
                else
                {
                    gv_MeetingAttendeesView.DataSource = null;
                    gv_MeetingAttendeesView.DataBind();
                }
            }
            else
            {
                pnl1View.Visible = false;
                pnl1.Visible = true;
                if (dtSlt_members != null && dtSlt_members.Rows.Count > 0)
                {
                    gv_MeetingAttendees.DataSource = dtSlt_members;
                    gv_MeetingAttendees.DataBind();
                }
                else
                {
                    gv_MeetingAttendees.DataSource = null;
                    gv_MeetingAttendees.DataBind();
                }
            }
        }
    }

    /// <summary>
    /// Save SLT_Meeting Attendees record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAttendeesSave_Click(object sender, EventArgs e)
    {
        if (Actual_Meeting_Date != null)
        {
            bool bParticipated = Validate_SafetyWalkMembers_Participated();
            if (bParticipated)
            {
                foreach (GridViewRow gRow1 in gv_MeetingAttendees.Rows)
                {
                    if (((HiddenField)(gRow1.FindControl("hdnPK_SLT_Members"))).Value != "")
                        PK_SLT_Member = Convert.ToDecimal(((HiddenField)(gRow1.FindControl("hdnPK_SLT_Members"))).Value);
                    SLT_Safety_Walk_Members objSLT_Safety_Walk_Members = new SLT_Safety_Walk_Members(PK_SLT_Member, true, FK_SLT_Safety_Walk);
                    objSLT_Safety_Walk_Members.FK_SLT_Safety_Walk = FK_SLT_Safety_Walk;
                    objSLT_Safety_Walk_Members.FK_SLT_Members = PK_SLT_Member;
                    objSLT_Safety_Walk_Members.Participated = ((RadioButtonList)(gRow1.FindControl("rdoParticipated"))).SelectedValue == "Y" ? true : ((RadioButtonList)(gRow1.FindControl("rdoParticipated"))).SelectedValue == "N" ? false : (bool?)null;
                    if (objSLT_Safety_Walk_Members.PK_SLT_Safety_Walk_Members > 0)
                        objSLT_Safety_Walk_Members.Update();
                    else
                        objSLT_Safety_Walk_Members.Insert();
                }
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:Save_Record();", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Please Check Participated');", true);
            }
            //foreach (GridViewRow gRow1 in gv_MeetingAttendees.Rows)
            //{
            //    DataTable Dtmeeting_ScheduleEdit = SLT_Meeting_Schedule.SelectBYFK(PK_SLT_Meeting, null, null, Year, Month).Tables[0];
            //    decimal PK_SLT_Meeting_Schedule = 0;

            //    if (((HiddenField)gRow1.FindControl("hdnPK_SLT_Members")).Value != "")
            //        PK_SLT_Member = Convert.ToDecimal(((HiddenField)gRow1.FindControl("hdnPK_SLT_Members")).Value);

            //    if(!string.IsNullOrEmpty(Dtmeeting_ScheduleEdit.Rows[0]["PK_SLT_Meeting_Schedule"].ToString()))
            //    {
            //        PK_SLT_Meeting_Schedule = Convert.ToDecimal(Dtmeeting_ScheduleEdit.Rows[0]["PK_SLT_Meeting_Schedule"]);
            //    }

            //    SLT_Meeting_Attendees objMeeting_Attendees = new SLT_Meeting_Attendees(PK_SLT_Member, PK_SLT_Meeting_Schedule);
            //    objMeeting_Attendees.Present = ((RadioButtonList)(gRow1.FindControl("rdbPresent"))).SelectedValue == "Y";

            //    objMeeting_Attendees.Update_Date = System.DateTime.Now;
            //    objMeeting_Attendees.Updated_By = clsSession.UserID;
            //    if (objMeeting_Attendees.PK_SLT_Meeting_Attendees > 0)
            //        objMeeting_Attendees.Update();
            //    else
            //        objMeeting_Attendees.Insert();

            //}
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please enter the Actual Meeting Date on the Meeting Attendees screen before proceeding.');", true);
        }
    }
    protected void gv_MeetingAttendees_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdnParticipated = (HiddenField)e.Row.FindControl("hdnParticipated");
            ((RadioButtonList)(e.Row.FindControl("rdoParticipated"))).SelectedValue = hdnParticipated.Value == "True" ? "Y" : hdnParticipated.Value == "False" ? "N" : (string)null;
        }
    }

    public bool Validate_SafetyWalkMembers_Participated()
    {
        bool bParticipated = true;
        foreach (GridViewRow gRow in gv_MeetingAttendees.Rows)
        {
            if (((RadioButtonList)(gRow.FindControl("rdoParticipated"))).SelectedIndex == -1)
            {
                bParticipated = false;
            }
        }
        return bParticipated;
    }
}