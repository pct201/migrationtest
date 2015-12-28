using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_SLT_BT_Security_Walk_Participant_Popup : clsBasePage
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
    /// FK_SLT_BT_Security_Walk for SLT Safety
    /// </summary>
    private decimal FK_SLT_BT_Security_Walk
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
        DataTable dtSlt_members = SLT_Members.SLT_BT_Security_Walk_MembersSelectByPK_SLT_Meeting(PK_SLT_Meeting, FK_SLT_BT_Security_Walk, 0).Tables[0];
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
            foreach (GridViewRow gRow1 in gv_MeetingAttendees.Rows)
            {
                if (((HiddenField)(gRow1.FindControl("hdnPK_SLT_Members"))).Value != "")
                    PK_SLT_Member = Convert.ToDecimal(((HiddenField)(gRow1.FindControl("hdnPK_SLT_Members"))).Value);
                clsSLT_BT_Security_Walk_Members objSBSWM = new clsSLT_BT_Security_Walk_Members(PK_SLT_Member, true, FK_SLT_BT_Security_Walk);
                objSBSWM.FK_SLT_BT_Security_Walk = FK_SLT_BT_Security_Walk;
                objSBSWM.FK_SLT_Members = PK_SLT_Member;
                objSBSWM.Participated = ((RadioButtonList)(gRow1.FindControl("rdoParticipated"))).SelectedValue == "Y";
                if (objSBSWM.PK_SLT_BT_Security_Walk_Members > 0)
                    objSBSWM.Update();
                else
                    objSBSWM.Insert();
            }
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:Save_Record();", true);
           
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
            ((RadioButtonList)(e.Row.FindControl("rdoParticipated"))).SelectedValue = hdnParticipated.Value == "True" ? "Y" : "N";
        }
    }
}