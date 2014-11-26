using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ERIMS.DAL;
public partial class SONIC_ClaimInfo_ScheduleFinancialSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // when page is loaded first time
        if (!IsPostBack)
        {
            // get available years for claims from DB and bind Accident year list box
            DataTable dtYears = clsClaimReports.GetClaimReportYears().Tables[0];
            lstAccidentYear.DataSource = dtYears;
            lstAccidentYear.DataTextField = "AccidentYear";
            lstAccidentYear.DataValueField = "AccidentYear";
            lstAccidentYear.DataBind();

            // get regions for user having access to and bind the regions list box
            DataTable dtRegions = clsClaimReports.SelectRegions().Tables[0];
            lstRegions.DataSource = dtRegions;
            lstRegions.DataTextField = "region";
            lstRegions.DataValueField = "region";
            lstRegions.DataBind();

            //Display Recipient List 
            DataSet ds = Report.GetRecipientList();
            ds.Tables[0].DefaultView.Sort = "ListName";
            drpRecipientList.DataTextField = "ListName";
            drpRecipientList.DataValueField = "pk_RecipientList_ID";
            drpRecipientList.DataSource = ds.Tables[0].DefaultView;
            drpRecipientList.DataBind();
            drpRecipientList.Items.Insert(0, new ListItem("--Select--", "0"));
            ds.Dispose();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Tatva_RptFinancialSummarySchedule obj = new Tatva_RptFinancialSummarySchedule();
            string strYear = "";
            string strClaimType = "";
            string strRegion = "";
            

            // get selected years
            foreach (ListItem itmYear in lstAccidentYear.Items)
            {
                if (itmYear.Selected)
                    strYear = strYear + itmYear.Value + ",";
            }
            strYear = strYear.TrimEnd(',');

            // get selected claim types
            foreach (ListItem itmClaimType in lstClaimType.Items)
            {
                if (itmClaimType.Selected)
                    strClaimType = strClaimType + itmClaimType.Value + ",";
            }
            strClaimType = strClaimType.TrimEnd(',');

            // get selected regions
            foreach (ListItem itmRegion in lstRegions.Items)
            {
                if (itmRegion.Selected)
                    strRegion = strRegion + "'" + itmRegion.Value + "',";
            }
            strRegion = strRegion.TrimEnd(',');

            //Report Filters
            obj.Accident_Year = strYear;
            obj.Claim_Type = strClaimType;
            obj.Region = strRegion;
            obj.Prior_Valuation_Date = Convert.ToDateTime(txtValuationDate.Text);

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
