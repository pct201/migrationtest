using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ERIMS.DAL;
/*********************************************************************************************************************************
 * 
 * Developer Name : Ravi Patel
 * 
 * Description : This page allow user to Schedule Schedule Rent Projections/History report.
 * 
 ********************************************************************************************************************************/
public partial class SONIC_RealEstate_ScheduleRentProjectionsHistory : clsBasePage
{
    public decimal PK_ReportID
    {
        get { return clsGeneral.IsNull(ViewState["PK_ReportID"]) ? 0 : Convert.ToDecimal(ViewState["PK_ReportID"]); }
        set { ViewState["PK_ReportID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            decimal _Pk;

            //  Check if Parameter report-Id is passed or not.
            if (Request.QueryString["PK_ReportID"] != null)
            {
                // Check report ID paramaeter is valid or not
                if (decimal.TryParse(Request.QueryString[0], out _Pk))
                {
                    PK_ReportID = _Pk;

                    BindDropDownList();
                    if (!string.IsNullOrEmpty(Request.QueryString["rptTitle"]))
                        lblReportHeader.Text = Request.QueryString["rptTitle"].ToString();
                }
                else
                {
                    // hide report and show error message
                    lblError.Text = "Parameter Report Type is Invalid.";
                    tblReport.Visible = false;
                }
            }
            else
            {
                // hide report and show error message
                lblError.Text = "Parameter Report Type is Invalid.";
                tblReport.Visible = false;
            }
        }
    }

    /// <summary>
    /// Hanlde Save Button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tatva_RptRentProjectionsSchedule obj = new Tatva_RptRentProjectionsSchedule();
        string strRegion = string.Empty, strLeaseType = string.Empty, strEscalation = string.Empty;

        // set values
        if (!string.IsNullOrEmpty(txtRentYearFrom.Text))
            obj.RentYear_From = Convert.ToInt32(txtRentYearFrom.Text.Trim());

        if (!string.IsNullOrEmpty(txtRentYearTo.Text))
            obj.RentYear_To = Convert.ToInt32(txtRentYearTo.Text.Trim());

        // get selected regions
        foreach (ListItem li in ddlRegion.Items)
        {
            if (li.Selected)
                strRegion = strRegion + "'" + li.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        // get selected regions
        foreach (ListItem li in lstLeaseType.Items)
        {
            if (li.Selected)
                strLeaseType = strLeaseType + li.Value + ",";
        }
        strLeaseType = strLeaseType.TrimEnd(',');

        // get selected Lease Type
        foreach (ListItem li in lstEscalationType.Items)
        {
            if (li.Selected)
                strEscalation = strEscalation + li.Value + ",";
        }
        strEscalation = strEscalation.TrimEnd(',');

        // set region
        if (!string.IsNullOrEmpty(strRegion))
            obj.Region = strRegion;

        // set lease type
        if (!string.IsNullOrEmpty(strLeaseType))
            obj.LeaseType = strLeaseType;

        if (!string.IsNullOrEmpty(strEscalation))
            obj.EscalationType = strEscalation;

        obj.FK_Report = PK_ReportID;
        obj.Scheduled_Date = Convert.ToDateTime(txtScheduleDate.Text);
        obj.Created_Date = DateTime.Now;
        obj.Schedule_End_Date = Convert.ToDateTime(txtScheduleEndDate.Text);
        obj.Recurring_Type = Convert.ToDecimal(drpRecurringPeriod.SelectedValue);
        obj.FK_Security_ID = Convert.ToDecimal(clsSession.UserID);
        obj.Fk_RecipientList = Convert.ToDecimal(drpRecipientList.SelectedValue);

        //Insert Report Schedule
        int intID = obj.Insert();

        if (intID > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SaveConfirm", "ScheduleSavedConfirm();", true);
        }
    }

    /// <summary>
    /// Bind Drop Down List
    /// </summary>    
    private void BindDropDownList()
    {
        // Fill Location by Employee        
        ComboHelper.FillLocationdbaOnlyListBox(new ListBox[] { ddlRegion }, 0, false,false);
        ddlRegion.Style.Remove("font-size");

        //Lease Type
        ComboHelper.FillLeaseTypeListBox(new ListBox[] { lstLeaseType }, false);

        //Recipient List
        Report.BindRecipientList(ref drpRecipientList);

        //Escalation Type         
        lstEscalationType.DataSource = LU_Escalation.SelectAll().Tables[0];
        lstEscalationType.DataTextField = "Fld_Desc";
        lstEscalationType.DataValueField = "PK_LU_Escalation";
        lstEscalationType.DataBind();

    }
}
