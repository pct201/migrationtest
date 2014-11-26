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
    * File Name:		ScheduleThreePIT.aspx
    *								  
    * Developer Name:	Amit Makwana	  
    *								  
    * Description:		This Page provide interface to user select filters for report Three Point-In-Time.
    * 
    **************************************************************************************************/

public partial class ClaimDetailReport_ScheduleThreePIT : clsBasePage
{
    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (!IsPostBack)
        {
            //Set Validation message for various date controls
            //this.txtScheduleDate.EmptyErrorMessage = "Schedule Date must not be Blank.";
            //this.txtScheduleEndDate.EmptyErrorMessage = "Schedule End Date must not be Blank.";

            //this.txtScheduleDate.EndDateClientId = txtScheduleEndDate.TxtClientID;
            //this.txtScheduleDate.MsgEndDate = "Report Schedule Date must be less than Schedule End Date.";

            //this.txtScheduleEndDate.StartDateClientId = txtScheduleDate.TxtClientID;
            //this.txtScheduleEndDate.MsgStartDate = "Report Schedule Date must be less than Schedule End Date.";

            //Display Reccipient List.
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
            Tatva_RptThreePITSchedule obj = new Tatva_RptThreePITSchedule();
            string _strClaimType = string.Empty;

            //Prepare the comma seprated list of selected claim type
            foreach (ListItem li in lsbClaimType.Items)
            {
                if (li.Selected == true)
                    _strClaimType = (_strClaimType == "") ? li.Value.ToString() : _strClaimType + "," + li.Value.ToString();
            }

            //Report Filters
            obj.Claim_Type = _strClaimType;
            obj.As_Of_Date1 = Convert.ToDateTime(txtasOf1.Value);
            obj.As_Of_Date2 = Convert.ToDateTime(txtasOf2.Value);
            obj.As_Of_Date3 = Convert.ToDateTime(txtasOf3.Value);
            obj.Compare_First_Date1 = Convert.ToDateTime(txtLossFromDate1.Text);
            obj.Compare_Second_Date1 = Convert.ToDateTime(txtLossToDate1.Text);
            obj.Compare_First_Date2 = Convert.ToDateTime(txtLossFromDate2.Text);
            obj.Compare_Second_Date2 = Convert.ToDateTime(txtLossToDate2.Text);
            obj.Compare_First_Date3 = Convert.ToDateTime(txtLossFromDate3.Text);
            obj.Compare_Second_Date3 = Convert.ToDateTime(txtLossToDate3.Text);

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
