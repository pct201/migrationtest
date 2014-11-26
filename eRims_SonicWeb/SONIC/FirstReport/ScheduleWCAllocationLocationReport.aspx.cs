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

public partial class SONIC_FirstReport_ScheduleWCAllocationLocationReport : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // when page is loaded first time
        if (!IsPostBack)
        {
            ComboHelper.FillDistinctYear_Worker_Comp_Charge(new DropDownList[] { ddlYear } , true);
            ComboHelper.FillLocationdba(new DropDownList[] { ddlLocation }, 0, true);

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
            Tatva_RptWCAllocationLocationSchedule obj = new Tatva_RptWCAllocationLocationSchedule();

            //Report Filters
            obj.Year = ddlYear.SelectedIndex > 0 ? Convert.ToDecimal(ddlYear.SelectedValue) : 0;
            obj.Month = ddlMonth.SelectedIndex > 0 ? Convert.ToDecimal(ddlMonth.SelectedValue) : 0;
            obj.Location = ddlLocation.SelectedIndex > 0 ? Convert.ToDecimal(ddlLocation.SelectedValue) : 0;

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
