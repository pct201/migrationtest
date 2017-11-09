using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
public partial class SONIC_SLT_Popup_SLT_ReviewMail : clsBasePage
{
    #region "Properties"
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
    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal FK_SLT_Meeting
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_SLT_Meeting"]);
        }
        set { ViewState["FK_SLT_Meeting"] = value; }
    }

    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public string Doctype
    {
        get
        {
            return ViewState["Doctype"].ToString();
        }
        set { ViewState["Doctype"] = value; }
    }
    #endregion

    #region "Page events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Sid"]))
                PK_SLT_Meeting_Schedule = Convert.ToDecimal(Request.QueryString["Sid"]);
            if (PK_SLT_Meeting_Schedule > 0)
            {
                SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
                FK_SLT_Meeting = Convert.ToDecimal(objSLT_Meeting_Schedule.FK_SLT_Meeting);
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    FK_SLT_Meeting = Convert.ToDecimal(Request.QueryString["id"]);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["Doctype"])) Doctype = Request.QueryString["Doctype"].ToString();
            BindGridAttendees();
            BindGridAdditionalRecipients();
            //BindEmail();

        }
    }
    #endregion

    #region "Methods"
    /// <summary>
    /// Bind meeting Attendees grid
    /// </summary>
    private void BindGridAttendees()
    {
        SLT_Meeting_Schedule objSLT = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);

        if (Doctype == "Next_Schedule" || (Doctype == "Agenda" ))
        {
            DataTable dtMembers = SLT_Members.SLT_MembersSelectByFk(FK_SLT_Meeting, 0, PK_SLT_Meeting_Schedule).Tables[0];
            gvEmail.DataSource = dtMembers;
            gvEmail.DataBind();
        }
        else
        {
            DataTable DtAttendees = SLT_Meeting_Attendees.SelectBYFK(PK_SLT_Meeting_Schedule).Tables[0];
            gvEmail.DataSource = DtAttendees;
            gvEmail.DataBind();
        }
        //BindEmail();
    }
    /// <summary>
    /// Bind Additional recipient grid
    /// </summary>
    private void BindGridAdditionalRecipients()
    {
        DataTable DtRecipients = SLT_Additional_Recipients.SelectByFK(FK_SLT_Meeting).Tables[0];
        gvAdditional_Recipients.DataSource = DtRecipients;
        gvAdditional_Recipients.DataBind();
        // BindEmail();
    }
    /// <summary>
    /// Set email address of recipient in hidden field 
    /// </summary>
    private void BindEmail()
    {
        string Email = "";
        hdnEmail.Value = "";
        if (gvEmail.Rows.Count > 0)
        {
            foreach (GridViewRow gr in gvEmail.Rows)
            {
                if (((CheckBox)(gr.FindControl("chkSelected"))).Checked == true)
                {

                    Email = ((Label)(gr.FindControl("lblEmail"))).Text;
                    hdnEmail.Value = Email + "," + hdnEmail.Value;
                }
            }
        }
        if (gvAdditional_Recipients.Rows.Count > 0)
        {
            foreach (GridViewRow gr in gvAdditional_Recipients.Rows)
            {
                if (((CheckBox)(gr.FindControl("chkSelectedAdditional"))).Checked == true)
                {

                    Email = ((Label)(gr.FindControl("lblEmail"))).Text;
                    hdnEmail.Value = Email + "," + hdnEmail.Value;
                }
            }
        }

    }
    #endregion

    #region "Control Events"
    /// <summary>
    /// Add New Recipient
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAdd_new_Click(object sender, EventArgs e)
    {
        tr_Email.Visible = true;
        tr_send.Visible = false;
        txtEmail_Address.Text = "";
    }
    /// <summary>
    /// Cancel adding new recipient
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        tr_Email.Visible = false;
        tr_send.Visible = true;
        txtEmail_Address.Text = "";
    }
    /// <summary>
    /// Save additional recipients data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SLT_Additional_Recipients objRecipients = new SLT_Additional_Recipients();
        objRecipients.FK_SLT_Meeting = FK_SLT_Meeting;
        objRecipients.First_Name = txtFirst_Name.Text;
        objRecipients.Last_Name = txtLast_Name.Text;
        objRecipients.Email = txtEmail_Address.Text;
        objRecipients.Insert();
        BindGridAdditionalRecipients();
        //BindEmail();
        tr_Email.Visible = false;
        tr_send.Visible = true;

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        BindEmail();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:SendMail();", true);
    }
    #endregion

    #region "Grid Events"
    /// <summary>
    /// deletes record from gvAdditional_Recipients by PK
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAdditional_Recipients_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "RemoveRecipient")
        {
            decimal PK_SLT_Additional_Recipients = Convert.ToDecimal(e.CommandArgument);
            SLT_Additional_Recipients.DeleteByPK(PK_SLT_Additional_Recipients);

        }
        BindGridAdditionalRecipients();
    }
    #endregion
}