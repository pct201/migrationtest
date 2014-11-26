using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_ClaimInfo_ScheduleRptFROIRecap : System.Web.UI.Page
{

    #region " Page Events "

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDown();
            
        }

    }

    #endregion

    #region " Methods "

    private void BindDropDown()
    {
        ComboHelper.FillRegionListBox(new ListBox[] { lstRegions }, false);
        ComboHelper.FillLocationdba(new ListBox[] { lstRMLocationNumber }, 0, false);

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

    #endregion

    #region " Events "

    protected void lstRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strRegion = string.Empty;
        foreach (ListItem li in lstRegions.Items)
        {
            if (li.Selected)
                strRegion = strRegion + li.Value + ",";
        }
        strRegion = strRegion.TrimEnd(',');
        ComboHelper.FillLocationdbaByRegion(new ListBox[] { lstRMLocationNumber }, 0, false, strRegion);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsTatva_rptFROIRecapSchedule objFROIRecapSchedule = new clsTatva_rptFROIRecapSchedule();
        string strRegion = "";
        // get selected regions
        foreach (ListItem itmRegion in lstRegions.Items)
        {
            if (itmRegion.Selected)
                strRegion = strRegion + "'" + itmRegion.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        string strDBA = "";
        // get selected regions
        foreach (ListItem itmdba in lstRMLocationNumber.Items)
        {
            if (itmdba.Selected)
                strDBA = strDBA + "'" + itmdba.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[0] + "',";
        }
        strDBA = strDBA.TrimEnd(',');

        string strCategory = "";
        // get selected regions
        foreach (ListItem itmCat in lstCategory.Items)
        {
            if (itmCat.Selected)
                strCategory = strCategory + itmCat.Value + ",";
        }
        strCategory = strCategory.TrimEnd(',');

        if (string.IsNullOrEmpty(strCategory))
            strCategory = "AL,DPD,NS,PL,Property,WC";

        DateTime? IncidentBeginDate = null, IncidentEndDate = null;
        if (txtIncidentBeginDate.Text != string.Empty && txtIncidentEndDate.Text != string.Empty)
        {
            IncidentBeginDate = clsGeneral.FormatNullDateToStore(txtIncidentBeginDate.Text);
            IncidentEndDate = clsGeneral.FormatNullDateToStore(txtIncidentEndDate.Text);
        }

        //Report Filters
        objFROIRecapSchedule.Region = strRegion;
        objFROIRecapSchedule.DBA = strDBA;
        objFROIRecapSchedule.First_Report_Category = strCategory;
        objFROIRecapSchedule.Inspection_Date_From = IncidentBeginDate;
        objFROIRecapSchedule.Inspection_Date_To = IncidentEndDate;


        //Report Schedule Details
        objFROIRecapSchedule.FK_Report = Convert.ToDecimal(Request.QueryString["PK_ReportID"]);
        objFROIRecapSchedule.Scheduled_Date = Convert.ToDateTime(txtScheduleDate.Text);
        objFROIRecapSchedule.Created_Date = DateTime.Now;
        objFROIRecapSchedule.Schedule_End_Date = Convert.ToDateTime(txtScheduleEndDate.Text);
        objFROIRecapSchedule.Recurring_Type = Convert.ToDecimal(drpRecurringPeriod.SelectedValue);
        objFROIRecapSchedule.FK_Security_ID = Convert.ToDecimal(clsSession.UserID);
        objFROIRecapSchedule.Fk_RecipientList = Convert.ToDecimal(drpRecipientList.SelectedValue);

        //Insert Report Schedule
        int intID = objFROIRecapSchedule.Insert();

        if (intID > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SaveConfirm", "ScheduleSavedConfirm();", true);
        }
        
        
        
    }

    #endregion
}