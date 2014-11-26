using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class SONIC_CRM_ScheduleRptNonCustomerInquiry : System.Web.UI.Page
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

            ComboHelper.FillLocationDBA_All(new ListBox[] { lstDBA }, 0, false);
            lstDBA.Style.Remove("font-size");

            //Display Recipient List..
            DataSet ds = Report.GetRecipientList();
            drpRecipientList.DataTextField = "ListName";
            drpRecipientList.DataValueField = "pk_RecipientList_ID";
            drpRecipientList.DataSource = ds;
            drpRecipientList.DataBind();
            drpRecipientList.Items.Insert(0, new ListItem("--Select--", "0"));
            ds.Dispose();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Tatva_RptNonCustomerInquirySchedule obj = new Tatva_RptNonCustomerInquirySchedule();

            //Report Filters
            obj.Year = Convert.ToInt32(drpYear.SelectedValue);

            string strDBA = "";

            foreach (ListItem lst in lstDBA.Items)
            {
                if (lst.Selected)
                    strDBA = strDBA + lst.Value + ",";
            }
            strDBA = strDBA.TrimEnd(',');

            obj.FK_LU_LocationIDs = strDBA;

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