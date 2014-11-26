using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ERIMS.DAL;

public partial class Policy_ScheduleInsurance : System.Web.UI.Page
{
    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (!IsPostBack)
        {
            // -- Bind Policy Years
            DataTable dtPolicyYears = Report.GetInsurancePolicyYears().Tables[0];
            drpPolicyYear.DataSource = dtPolicyYears;
            drpPolicyYear.DataTextField = "PolicyYear";
            drpPolicyYear.DataValueField = "PolicyYear";
            drpPolicyYear.DataBind();
            drpPolicyYear.Items.Insert(0, new ListItem("--Select--", "0"));

            //-- Bind Programs list
            DataTable dtProgram = Tatva_Program.SelectAll().Tables[0];
            lstProgram.DataSource = dtProgram;
            lstProgram.DataTextField = "Fld_Desc";
            lstProgram.DataValueField = "PK_ID";
            lstProgram.DataBind();

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

    protected void lstProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strPrograms = "";

        foreach (ListItem lst in lstProgram.Items)
        {
            if (lst.Selected)
                strPrograms = strPrograms + lst.Value + ",";
        }
        strPrograms = strPrograms.TrimEnd(',');
        //-- Bind Policy Type list
        DataTable dtPolicyType = Report.GetPolicyTypesByProgramIDs(strPrograms).Tables[0];
        lstPolicyType.DataSource = dtPolicyType;
        lstPolicyType.DataTextField = "FLD_desc";
        lstPolicyType.DataValueField = "PK_ID";
        lstPolicyType.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Tatva_RptPolicyInsuranceSchedule obj = new Tatva_RptPolicyInsuranceSchedule();
            
            //Report Filters
            if (drpPolicyYear.SelectedIndex > 0)
                obj.Policy_Year = Convert.ToInt32(drpPolicyYear.SelectedValue);
            obj.ProgramID = GetCommaSeparatedValues(lstProgram);
            obj.PolicyType = GetCommaSeparatedValues(lstPolicyType);

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
