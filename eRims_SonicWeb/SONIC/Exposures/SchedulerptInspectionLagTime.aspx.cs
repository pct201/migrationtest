using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class SONIC_Exposures_SchedulerptInspectionLagTime : System.Web.UI.Page
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
            Tatva_rptInspectionLagTimeSchedule obj = new Tatva_rptInspectionLagTimeSchedule();
            
            //Report Filters
            obj.Region = GetCommaSeparatedValues(lstRegions);
            obj.Market = GetCommaSeparatedValues(lstMarket);
            obj.DBA = GetCommaSeparatedValues(lstLocationDBA);
            obj.InspectionArea = GetCommaSeparatedValues(lstInspectionArea);
            obj.LagDayOption = GetCommaSeparatedValues(lstLagTimeDays);
            obj.Inspector_Name = txtInspectorName.Text.Trim().Replace("'", "''");
            obj.Inspection_Date_From = clsGeneral.FormatNullDateToStore(txtInspectionDateFrom.Text);
            obj.Inspection_Date_To = clsGeneral.FormatNullDateToStore(txtInspectionDateTo.Text);
            

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
        // get regions for user having access to and bind the regions list box
        DataTable dtRegions = clsClaimReports.SelectRegions().Tables[0];
        lstRegions.DataSource = dtRegions;
        lstRegions.DataTextField = "region";
        lstRegions.DataValueField = "region";
        lstRegions.DataBind();

        ComboHelper.FillLocationdbaOnlyListBox(new ListBox[] { lstLocationDBA }, 0, false,false);

        //Display Recipient List..
        DataSet ds = Report.GetRecipientList();
        drpRecipientList.DataTextField = "ListName";
        drpRecipientList.DataValueField = "pk_RecipientList_ID";
        drpRecipientList.DataSource = ds;
        drpRecipientList.DataBind();
        drpRecipientList.Items.Insert(0, new ListItem("--Select--", "0"));
        ds.Dispose();

        DataTable dt_Inspection_Area = clsLU_Inspection_Area.SelectAll().Tables[0];
        dt_Inspection_Area.DefaultView.RowFilter = "Active = 'Y'";
        lstInspectionArea.DataSource = dt_Inspection_Area.DefaultView;
        lstInspectionArea.DataTextField = "Fld_Desc";
        lstInspectionArea.DataValueField = "PK_LU_Inspection_Area";
        lstInspectionArea.DataBind();

        //Display Market..
        ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);

    }

    /// <summary>
    /// Get Comma saperated List items
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
