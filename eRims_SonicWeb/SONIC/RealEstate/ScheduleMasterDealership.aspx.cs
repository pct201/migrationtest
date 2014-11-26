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

public partial class SONIC_RealEstate_ScheduleMasterDealership : clsBasePage
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
        Tatva_RptRealEstateSchedule obj = new Tatva_RptRealEstateSchedule();
        string strRegion = string.Empty, strLeaseType = string.Empty;

        // set values
        if (txtLCDateFrom.Text.Trim() != string.Empty)
            obj.LCDFrom_Date = Convert.ToDateTime(txtLCDateFrom.Text);

        if (txtLCDateTo.Text.Trim() != string.Empty)
            obj.LCDTo_Date = Convert.ToDateTime(txtLCDateTo.Text);

        if (txtLEDateFrom.Text.Trim() != string.Empty)
            obj.LEDFrom_Date = Convert.ToDateTime(txtLEDateFrom.Text);

        if (txtLEDateTo.Text.Trim() != string.Empty)
            obj.LEDTo_Date = Convert.ToDateTime(txtLEDateTo.Text);

        // get selected regions
        foreach (ListItem li in ddlRegion.Items)
        {
            if (li.Selected)
                strRegion = strRegion + "'" + li.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

    

        // set region
        if (!string.IsNullOrEmpty(strRegion))
            obj.Region = strRegion;

        // set lease type
        if (!string.IsNullOrEmpty(strLeaseType))
            obj.LeaseType = strLeaseType;

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
        //Region
        ComboHelper.FillRegionListBox(new ListBox[] { ddlRegion }, false);

        //Display Recipient List 
        Report.BindRecipientList(ref drpRecipientList);

    }
}
