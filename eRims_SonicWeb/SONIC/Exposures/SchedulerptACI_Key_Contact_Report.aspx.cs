using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class SONIC_Exposures_SchedulerptACI_Key_Contact_Report : System.Web.UI.Page
{
    #region "Page Events"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (!IsPostBack)
        {
            BindListBoxes();
        }
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Button Save click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            clsTatva_rptACIKeyContactSchedule obj = new clsTatva_rptACIKeyContactSchedule();
            
            //Report Filters
            obj.DBA = GetCommaSeparatedValues(lstLocationDBA);
            obj.Job_Title = GetCommaSeparatedValues(lstJob_Titles);
            
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

    #region "methods"

    /// <summary>
    /// Bind List Box
    /// </summary>
    private void BindListBoxes()
    {
        
        ComboHelper.FillLocationdbaOnlyListBox(new ListBox[] { lstLocationDBA }, 0, false,false);

        //Display Recipient List..
        DataSet ds = Report.GetRecipientList();
        drpRecipientList.DataTextField = "ListName";
        drpRecipientList.DataValueField = "pk_RecipientList_ID";
        drpRecipientList.DataSource = ds;
        drpRecipientList.DataBind();
        drpRecipientList.Items.Insert(0, new ListItem("--Select--", "0"));
        ds.Dispose();
        
    }

    /// <summary>
    /// Get Comma seperated List items
    /// </summary>
    /// <param name="lst"></param>
    /// <returns></returns>
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
