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

/**********************************************************************************************
    * File Name:		ScheduleLossStratification.aspx
    *								  
    * Developer Name:	Amit Makwana	  
    *								  
    * Description:		This Page provide interface for Generate Loss Stratification Schedule 
    *                  for Selected Year and Claim Type ,  
    *                  Schedule Date and Recipient List.
    * 
    **************************************************************************************************/

public partial class ClaimDetailReport_ScheduleLossStratification : clsBasePage
{
    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (!IsPostBack)
        {
            //Display Recipient List..
            DataSet ds = Report.GetRecipientList();
            drpRecipientList.DataTextField = "ListName";
            drpRecipientList.DataValueField = "pk_RecipientList_ID";
            drpRecipientList.DataSource = ds;
            drpRecipientList.DataBind();
            drpRecipientList.Items.Insert(0, new ListItem("--Select--", "0"));
            ds.Dispose();

            // get claim years available in DB
            DataTable dtYears = clsClaimReports.GetClaimReportYears().Tables[0];
            lsbPolicyYear.DataSource = dtYears;
            lsbPolicyYear.DataTextField = "AccidentYear";
            lsbPolicyYear.DataValueField = "AccidentYear";
            lsbPolicyYear.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Tatva_RptLossStratificationSchedule obj = new Tatva_RptLossStratificationSchedule();

            string _strClaimType = string.Empty;
            string _strPolicyYear = string.Empty;

            // Get Total Selected Claim Type In Comma Seperated String like ",1,2,"
            foreach (ListItem li in lsbClaimType.Items)
            {
                if (li.Selected)
                    _strClaimType += (_strClaimType == "") ? "," + li.Value.ToString() + "," : li.Value.ToString() + ",";
            }
            _strClaimType = _strClaimType.TrimStart(',');
            _strClaimType = _strClaimType.TrimEnd(',');
            // Get Total Selected Policy Year In Comma Seperated String like "2002,2003"
            foreach (ListItem li in lsbPolicyYear.Items)
            {
                if (li.Selected)
                    _strPolicyYear += (_strPolicyYear == "") ? "," + li.Value.ToString() + "," : li.Value.ToString() + ",";
            }
            _strPolicyYear = _strPolicyYear.TrimStart(',');
            _strPolicyYear = _strPolicyYear.TrimEnd(',');

            //Report Filters
            obj.Policy_Year = _strPolicyYear;
            obj.Claim_Type = _strClaimType;

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

    #endregion

    #region Methods

    #endregion
}
