using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_Exposures_ScheduleRptVOCEmissions : clsBasePage
{
    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (!IsPostBack)
        {
            //Display Location..
            ComboHelper.FillLocationDBA_All(new ListBox[] { lstLocation }, 0, false);

            //Display Recipient List..
            DataSet ds = Report.GetRecipientList();
            drpRecipientList.DataTextField = "ListName";
            drpRecipientList.DataValueField = "pk_RecipientList_ID";
            drpRecipientList.DataSource = ds;
            drpRecipientList.DataBind();
            drpRecipientList.Items.Insert(0, new ListItem("--Select--", "0"));
            ds.Dispose();

            DateTime today = DateTime.Today.Date;
            DateTime month = new DateTime(today.Year, today.Month, 1);
            DateTime first = month.AddMonths(-1);
            string strfirst = first.ToString("MM/dd/yyyy");

            //set start date as first date of previous month
            txtStartDate.Text = strfirst;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Tatva_RptVOCEmissionsSchedule obj = new Tatva_RptVOCEmissionsSchedule();
            string strLocation = GetCommaSeparatedValues(lstLocation);

            //Report Filters
            obj.Location = strLocation;
            obj.Start_Date = Convert.ToDateTime(txtStartDate.Text);
            obj.End_Date = Convert.ToDateTime(txtEndDate.Text);

            //Report Schedule Details
            if (rdbOutputType.SelectedValue == "1")
            {
                obj.Format_Type = 1;
            }
            else if (rdbOutputType.SelectedValue == "2")
            {
                obj.Format_Type = 2;
            }

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

    #endregion

    #region Private Methods

    private string GetCommaSeparatedValues(ListBox lst)
    {
        string strRegion = string.Empty;
        foreach (ListItem itmRegion in lst.Items)
        {
            if (itmRegion.Selected)
                strRegion = strRegion + itmRegion.Value + ",";
        }
        strRegion = strRegion.TrimEnd(',');
        return strRegion;
    }

    #endregion
}