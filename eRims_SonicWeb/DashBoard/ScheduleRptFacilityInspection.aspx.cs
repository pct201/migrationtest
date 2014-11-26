using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class SONIC_Exposures_ScheduleRptFacilityInspection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (!IsPostBack)
        {
            // years
            int intMinYear, intMaxYear;
            intMinYear = 2000;
            intMaxYear = DateTime.Now.Year;
            for (int i = intMaxYear; i >= intMinYear; i--)
            {
                drpYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            //Display Region..
            DataTable dtRegions = clsExposuresReports.GetRegionList().Tables[0];
            drpRegion.DataSource = dtRegions;
            drpRegion.DataTextField = "region";
            drpRegion.DataValueField = "region";
            drpRegion.DataBind();
            drpRegion.Items.Insert(0, new ListItem("--All Regions--", ""));

            //Display Recipient List..
            DataSet ds = Report.GetRecipientList();
            drpRecipientList.DataTextField = "ListName";
            drpRecipientList.DataValueField = "pk_RecipientList_ID";
            drpRecipientList.DataSource = ds;
            drpRecipientList.DataBind();
            drpRecipientList.Items.Insert(0, new ListItem("--Select--", "0"));
            ds.Dispose();

            drpReportInterval.Focus();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Tatva_RptFacilityInspectionSchedule obj = new Tatva_RptFacilityInspectionSchedule();
            
            //Report Filters
            obj.Region = drpRegion.SelectedValue;
            obj.Year = Convert.ToInt32(drpYear.SelectedValue);
            obj.Report_Interval = drpReportInterval.SelectedValue;

            //Report Schedule Details
            obj.FK_Report = Convert.ToDecimal(Request.QueryString["PK_ReportID"]);
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
        catch (Exception ex)
        {
            throw ex;
        }
    }

    
}
