using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class SONIC_ClaimInfo_ScheduleRiskManagementWorksheet : System.Web.UI.Page
{
    #region "Page Events"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindListBoxes();
        }
    }

    #endregion

    #region "Events"

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Tatva_RptRiskManagementWorksheetSchedule objSchedule = new Tatva_RptRiskManagementWorksheetSchedule();

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
            foreach (ListItem itmdba in lstDBAs.Items)
            {
                if (itmdba.Selected)
                    strDBA = strDBA + itmdba.Value + ",";
            }
            strDBA = strDBA.TrimEnd(',');

            string strDBAView = "";
            // get selected regions
            foreach (ListItem itmdba in lstDBAs.Items)
            {
                if (itmdba.Selected)
                    strDBAView = strDBAView + itmdba.Text + ",";
            }
            strDBAView = strDBAView.TrimEnd(',');

            string strBodyParts = "";
            // get selected regions
            foreach (ListItem itm in lstPartofBody.Items)
            {
                if (itm.Selected)
                    strBodyParts = strBodyParts +"'"+ itm.Value + "',";
            }
            strBodyParts = strBodyParts.TrimEnd(',');

            string strBodyPartsView = "";
            // get selected regions
            foreach (ListItem itm in lstPartofBody.Items)
            {
                if (itm.Selected)
                    strBodyPartsView = strBodyPartsView +  itm.Text + ",";
            }
            strBodyPartsView = strBodyPartsView.TrimEnd(',');

            string strClaimStatus = "";
            int intCount = 0;
            if (lstClaimStatus.Items[0].Selected == true)
            {
                strClaimStatus = "WC.FK_Claim_Status > 19";
                intCount++;
            }
            if (lstClaimStatus.Items[1].Selected == true)
            {
                if (strClaimStatus != "")
                    strClaimStatus += " OR ";
                strClaimStatus += "WC.FK_Claim_Status IN (10,11,14,15,16,17,18,19)";
                intCount++;
            }

            if (lstClaimStatus.Items[2].Selected == true)
            {
                if (strClaimStatus != "")
                    strClaimStatus += " OR ";
                strClaimStatus += "WC.FK_Claim_Status IN (12,13)";
                intCount++;
            }
            if (intCount == 3)
                strClaimStatus = "";
            else if (strClaimStatus != "")
                strClaimStatus = " (" + strClaimStatus + ")";

            string strCaimStatusSelected = "";
            // get selected regions
            foreach (ListItem itmcs in lstClaimStatus.Items)
            {
                if (itmcs.Selected)
                    strCaimStatusSelected = strCaimStatusSelected  + itmcs.Text + ",";
            }
            strCaimStatusSelected = strCaimStatusSelected.TrimEnd(',');

            objSchedule.Region = strRegion;
            objSchedule.DBA = strDBA;
            objSchedule.FK_Part_of_Body = strBodyParts;
            objSchedule.Claim_Status = strClaimStatus;
            objSchedule.Date_of_Incident_From = clsGeneral.FormatNullDateToStore(txtLossFromDate.Text);
            objSchedule.Date_of_Incident_To = clsGeneral.FormatNullDateToStore(txtLossToDate.Text);
            objSchedule.Claim_StatusSelected = strCaimStatusSelected;
            objSchedule.Part_of_Body = strBodyPartsView;
            objSchedule.DBAList = strDBAView;

            //Report Schedule Details
            objSchedule.FK_Report = Convert.ToDecimal(Request.QueryString["PK_ReportID"]);
            objSchedule.Scheduled_Date = Convert.ToDateTime(txtScheduleDate.Text);
            objSchedule.Created_Date = DateTime.Now;
            objSchedule.Schedule_End_Date = Convert.ToDateTime(txtScheduleEndDate.Text);
            objSchedule.Recurring_Type = Convert.ToDecimal(drpRecurringPeriod.SelectedValue);
            objSchedule.FK_Security_ID = Convert.ToDecimal(clsSession.UserID);
            objSchedule.Fk_RecipientList = Convert.ToDecimal(drpRecipientList.SelectedValue);

            //Insert Report Schedule
            int intID = objSchedule.Insert();

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

    #region "Methods"

    /// <summary>
    /// Bind Drop Down
    /// </summary>
    private void BindListBoxes()
    {
        DataTable dtRegions = clsClaimReports.SelectRegions().Tables[0];
        lstRegions.DataSource = dtRegions;
        lstRegions.DataTextField = "region";
        lstRegions.DataValueField = "region";
        lstRegions.DataBind();

        ComboHelper.FillLocationdbaOnlyListBox(new ListBox[] { lstDBAs }, 0, false,true);

        lstClaimStatus.Items.Add("Closed");
        lstClaimStatus.Items.Add("Open");
        lstClaimStatus.Items.Add("Reopened");

        DataTable dtData = LU_Part_Of_Body.SelectAll().Tables[0];
        dtData.DefaultView.Sort = "Description";
        dtData = dtData.DefaultView.ToTable();
        lstPartofBody.DataTextField = "Description";
        lstPartofBody.DataValueField = "Code";
        lstPartofBody.DataSource = dtData;
        lstPartofBody.DataBind();

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
}