using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class Controls_RelativeDate_RelativeDate_Business_Rule : System.Web.UI.UserControl
{
    #region "Properties"

    public Business_RuleHelper.RaltiveDates RelativeDate
    {
        get
        {
            if (ViewState["RelativeDate" + this.ID] == null || (Business_RuleHelper.RaltiveDates)ViewState["RelativeDate" + this.ID] == Business_RuleHelper.RaltiveDates.NotSet)
                lbtn_Cancel.Visible = false;
            else
                lbtn_Cancel.Visible = true;

            if (ViewState["RelativeDate" + this.ID] != null)
                return (Business_RuleHelper.RaltiveDates)ViewState["RelativeDate" + this.ID];
            else
                return Business_RuleHelper.RaltiveDates.NotSet;
        }
        set 
        { 
            ViewState["RelativeDate" + this.ID] = value;
            if (value == Business_RuleHelper.RaltiveDates.NotSet)
                lbtn_Cancel.Visible = false;
        }
    }

    public string strDateClientID
    {
        set { ViewState["Contrl" + this.ID] = value; }
    }

    public clsBasePage.AccessType App_Access
    {
        get
        {
            if (ViewState["App_Access"] != null)
                return (clsBasePage.AccessType)ViewState["App_Access"];
            else
                return clsBasePage.AccessType.NotAssigned;
        }
        set { ViewState["App_Access"] = value; }
    }


    #endregion

    #region "Page Events"

    // delegates and events for Save button click
    public delegate void dlgSetDate(string senderID);
    public event dlgSetDate SetDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Parent.Page.MaintainScrollPositionOnPostBack = true;
        if (!IsPostBack)
        {
            if (RelativeDate == Business_RuleHelper.RaltiveDates.NotSet)
                lbtn_Cancel.Visible = false;
            else
                lbtn_Cancel.Visible = true;
        }
    }
    #endregion

    #region "Events"


    #endregion

    #region "Controls Events"

    /// <summary>
    /// Handles Save button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime dtDate = new DateTime();
            if (dblRelativeDates.SelectedIndex >= 0)
                RelativeDate = (Business_RuleHelper.RaltiveDates)Enum.Parse(typeof(Business_RuleHelper.RaltiveDates), dblRelativeDates.SelectedItem.Value);
            else RelativeDate = Business_RuleHelper.RaltiveDates.NotSet;
            dtDate = Business_RuleHelper.GetRelativeDate(RelativeDate);

            string obj = Convert.ToString(ViewState["Contrl" + this.ID]);

            if (RelativeDate == Business_RuleHelper.RaltiveDates.NotSet)
                lbtn_Cancel.Visible = false;
            else
                lbtn_Cancel.Visible = true;

            // Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:SetDateValue('" + obj + "'  ,'" + dtDate.ToString("MM/dd/yyyy") + "');", true);
            if (SetDate != null)
                SetDate(this.ID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Undo Relative Date Setting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtn_Cancel_Click(object sender, EventArgs e)
    {
        RelativeDate = Business_RuleHelper.RaltiveDates.NotSet;
        lbtn_Cancel.Visible = false;
        //Enabel Disable Control
        if (SetDate != null)
            SetDate(this.ID);
        /// Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:SetEnable();", true);
    }

    public void lnkRelativeDate_Click(object sender, EventArgs e)
    {
        //Manage Previously selected Date
        if (RelativeDate == Business_RuleHelper.RaltiveDates.NotSet)
            dblRelativeDates.SelectedValue = Business_RuleHelper.RaltiveDates.FirstDayPrevMonth.ToString();
        else dblRelativeDates.SelectedValue = RelativeDate.ToString();
        mpeRelativeDate.Show();
    }

    #endregion
}
