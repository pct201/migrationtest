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
public partial class ExecutiveRisk_ScheduleBordereau : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // when page is loaded first time
        if (!IsPostBack)
        {

            // Get regions from database and bind region dropdown
            DataTable dtRegion = LU_Location.GetRegionList().Tables[0];
            drpRegion.DataSource = dtRegion;
            drpRegion.DataTextField = "region";
            drpRegion.DataValueField = "region";
            drpRegion.DataBind();
            drpRegion.Items.Insert(0, new ListItem("--All--", ""));

            //Fill Market
            ComboHelper.FillMarket(new DropDownList[] { ddlMarket }, true);

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
            Tatva_RptBordereauSchedule obj = new Tatva_RptBordereauSchedule();

            //Report Filters
            obj.Start_Date = Convert.ToDateTime(txtStartDate.Text);
            obj.End_Date = Convert.ToDateTime(txtEndDate.Text);
            obj.Region = drpRegion.SelectedValue;
            obj.Market = Convert.ToDecimal(ddlMarket.SelectedValue);

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
