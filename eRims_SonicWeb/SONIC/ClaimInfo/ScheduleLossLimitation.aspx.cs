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
using System.Text;
using ERIMS.DAL;

/**********************************************************************************************
    * File Name:		ScheduleLossLimitation.aspx
    *								  
    * Developer Name:	Amit Makwana	  
    *								  
    * Description:		This Page provide User interface for generate  Loss Limitation Schedule for a perticual time period 
    *                  with Limit. Selection Criteria for this report is enter loss limits for up to five date ranges and
    *                  then compare those limits to selected claims.User can enter maximum five and minimum One Loss limit 
    *                  Schedule Date and Recipient List.
    * 
    **************************************************************************************************/

public partial class ClaimDetailReport_ScheduleLossLimitation : clsBasePage
{
    #region Event

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (!IsPostBack)
        {
            //Display Recipient List 
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
            Tatva_RptLossLimitationSchedule obj = new Tatva_RptLossLimitationSchedule();
            string _strClaimType = string.Empty;
            // get Selected Claim Type in Comm seperated value like ",1,2,"
            foreach (ListItem li in lsbClaimType.Items)
            {
                if (li.Selected == true)
                    _strClaimType = (_strClaimType == "") ? "," + li.Value.ToString() + "," : _strClaimType + li.Value.ToString() + ",";
            }
            _strClaimType = _strClaimType.TrimStart(',');
            _strClaimType = _strClaimType.TrimEnd(',');
            //Report Filters
            obj.Claim_Type = _strClaimType;
            obj.From_Date_Of_Loss1 = Convert.ToDateTime(txtLossFromDate1.Text);
            obj.To_Date_Of_Loss1 = Convert.ToDateTime(txtLossToDate1.Text);
            obj.Limit1 = Convert.ToDecimal(txtLimit1.Text);

            if (txtLossFromDate2.Text.Trim() != "")
                obj.From_Date_Of_Loss2 = Convert.ToDateTime(txtLossFromDate2.Text);

            if (txtLossToDate2.Text.Trim() != "")
                obj.To_Date_Of_Loss2 = Convert.ToDateTime(txtLossToDate2.Text);

            if (txtLossFromDate3.Text.Trim() != "")
                obj.From_Date_Of_Loss3 = Convert.ToDateTime(txtLossFromDate3.Text);

            if (txtLossToDate3.Text.Trim() != "")
                obj.To_Date_Of_Loss3 = Convert.ToDateTime(txtLossToDate3.Text);

            if (txtLimit2.Text.Trim() != "")
                obj.Limit2 = Convert.ToDecimal(txtLimit2.Text);

            if (txtLimit3.Text.Trim() != "")
                obj.Limit3 = Convert.ToDecimal(txtLimit3.Text);

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
