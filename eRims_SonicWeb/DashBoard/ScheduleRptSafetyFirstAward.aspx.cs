﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class DashBoard_ScheduleRptSafetyFirstAward : System.Web.UI.Page
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

            //Display Region..
            DataTable dtRegions = clsExposuresReports.GetRegionList().Tables[0];
            drpRegion.DataSource = dtRegions;
            drpRegion.DataTextField = "region";
            drpRegion.DataValueField = "region";
            drpRegion.DataBind();
            drpRegion.Items.Insert(0, new ListItem("--All Regions--", ""));

            //Display Recipient List..
            DataSet ds = Report.GetRecipientList();
            drpRecipientList.DataTextField = "ListName";
            drpRecipientList.DataValueField = "pk_RecipientList_ID";
            drpRecipientList.DataSource = ds;
            drpRecipientList.DataBind();
            drpRecipientList.Items.Insert(0, new ListItem("--Select--", "0"));
            ds.Dispose();

            //display Market
            ComboHelper.FillMarket(new DropDownList[] { ddlMarket }, true);
            
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Tatva_RptSafetyFirstAwardReportSchedule obj = new Tatva_RptSafetyFirstAwardReportSchedule();

            //Report Filters

            string strRegion = "";
            // get selected regions          
            strRegion = "'" + drpRegion.SelectedValue + "'";            
            obj.Region = strRegion.Replace("''","");
            obj.Year = Convert.ToInt32(drpYear.SelectedValue);  
            //Report Schedule Details
            obj.FK_Report = Convert.ToDecimal(Request.QueryString["PK_ReportID"]);
            obj.Scheduled_Date = Convert.ToDateTime(txtScheduleDate.Text);
            obj.Created_Date = DateTime.Now;
            obj.Schedule_End_Date = Convert.ToDateTime(txtScheduleEndDate.Text);
            obj.Recurring_Type = Convert.ToDecimal(drpRecurringPeriod.SelectedValue);
            obj.FK_Security_ID = Convert.ToDecimal(clsSession.UserID);
            obj.Fk_RecipientList = Convert.ToDecimal(drpRecipientList.SelectedValue);

            if (Convert.ToDecimal(ddlMarket.SelectedValue) == 0)
                obj.Market = null;
            else
                obj.Market = Convert.ToDecimal(ddlMarket.SelectedValue); 

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