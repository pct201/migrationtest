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
    * File Name:	   ScheduleDetailPITReport.aspx
    *								  
    * Developer Name:  Amit Makwana	  
    *								  
    * Description:	   This Page provide interface to user select filters for  Detail Point-In-Time.
    *                   
    **************************************************************************************************/

public partial class ClaimDetailReport_ScheduleDetailPITReport : clsBasePage
{
    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (!IsPostBack)
        {
            // Display Recipient List.
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
            Tatva_RptDetailPITSchedule obj = new Tatva_RptDetailPITSchedule();
            string _strClaimType = string.Empty;

            //Prepare comma seprated list of selected claim type
            foreach (ListItem li in lsbClaimType.Items)
            {
                if (li.Selected == true)
                    _strClaimType = (_strClaimType == "") ? li.Value.ToString() : _strClaimType + "," + li.Value.ToString();
            }

            //Report Filters
            obj.Claim_Type = _strClaimType;
            obj.Compare_First_Date = Convert.ToDateTime(txtCompDate1.Text);
            obj.Compare_Second_Date = Convert.ToDateTime(txtCompDate2.Text);
            obj.From_Date_Of_Loss = Convert.ToDateTime(txtLossFromDate.Text);
            obj.To_Date_Of_Loss = Convert.ToDateTime(txtLossToDate.Text);

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
