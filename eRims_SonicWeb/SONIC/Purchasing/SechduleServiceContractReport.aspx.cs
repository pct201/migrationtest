﻿using System;
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
/// <summary>
/// Date           : 23-03-09
/// 
/// Developer Name : Ravi Gupta
/// 
/// Description    : Schedule Service Contract Report as per passed criteria.
/// 
/// </summary>
public partial class SONIC_Purchasing_SechduleServiceContractReport : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // when page is loaded first time
        if (!IsPostBack)
        {
            // get regions for user having access to and bind the regions list box
            DataTable dtRegions = clsClaimReports.SelectRegions().Tables[0];
            lstRegions.DataSource = dtRegions;
            lstRegions.DataTextField = "region";
            lstRegions.DataValueField = "region";
            lstRegions.DataBind();

            // get regions for user having access to and bind the Location list box
            DataTable dtLocation = LU_Location.SelectAll(0, string.Empty).Tables[0];
            dtLocation.DefaultView.Sort = "DBA";
            lstLocation.DataSource = dtLocation.DefaultView;
            lstLocation.DataTextField = "dba";
            lstLocation.DataValueField = "PK_LU_Location_ID";
            lstLocation.DataBind();

            // get regions for user having access to and bind the Service Contract list box
            DataTable dtServiceContract = LU_Service_Contract.selectAll();
            lstServiceContract.DataSource = dtServiceContract;
            lstServiceContract.DataTextField = "FLD_DESC";
            lstServiceContract.DataValueField = "FLD_DESC";
            lstServiceContract.DataBind();

            // get regions for user having access to and bind the Service Type list box
            DataTable dtServiceType = PurchasingServiceContract.SelectAllServiceType().Tables[0];
            lstServiceType.DataSource = dtServiceType;
            lstServiceType.DataTextField = "service_type";
            lstServiceType.DataValueField = "service_type";
            lstServiceType.DataBind();

            //Display Recipient List 
            DataSet ds = Report.GetRecipientList();
            ds.Tables[0].DefaultView.Sort = "ListName";
            drpRecipientList.DataTextField = "ListName";
            drpRecipientList.DataValueField = "pk_RecipientList_ID";
            drpRecipientList.DataSource = ds.Tables[0].DefaultView;
            drpRecipientList.DataBind();
            drpRecipientList.Items.Insert(0, new ListItem("--Select--", "0"));
            ds.Dispose();

            //Display Market..
            ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Tatva_RptPurchaseContractDetailSchedule obj = new Tatva_RptPurchaseContractDetailSchedule();

            //Report Filters
            string strRegion = "";
            string strMarket = string.Empty;
            string strLocaiton = "";
            string strServiceContract = "";
            string strServiceType = "";


            // get selected regions
            foreach (ListItem itmRegion in lstRegions.Items)
            {
                if (itmRegion.Selected)
                    strRegion = strRegion + "'" + itmRegion.Value + "',";
            }
            strRegion = strRegion.TrimEnd(',');

            // get selected Markets
            foreach (ListItem itmMarket in lstMarket.Items)
            {
                if (itmMarket.Selected)
                    strMarket = strMarket + itmMarket.Value + ",";
            }
            strMarket = strMarket.TrimEnd(',');

            // get selected Locations
            foreach (ListItem itmLocation in lstLocation.Items)
            {
                if (itmLocation.Selected)
                    strLocaiton = strLocaiton + itmLocation.Value + ",";
            }
            strLocaiton = strLocaiton.TrimEnd(',');

            // get selected Service Contract
            foreach (ListItem itmSC in lstServiceContract.Items)
            {
                if (itmSC.Selected)
                    strServiceContract = strServiceContract + "'" + itmSC.Value + "',";
            }
            strServiceContract = strServiceContract.TrimEnd(',');

            // get selected service Type
            foreach (ListItem itmST in lstServiceType.Items)
            {
                if (itmST.Selected)
                    strServiceType = strServiceType + "'" + itmST.Value + "',";
            }
            strServiceType = strServiceType.TrimEnd(',');

            // get start date
            Nullable<DateTime> Start_To_Date = clsGeneral.FormatNullDateToStore(txtStartDateToDate.Text);
            Nullable<DateTime> Start_From_Date = clsGeneral.FormatNullDateToStore(txtStartDateFromDate.Text);
            // get end date
            Nullable<DateTime> End_To_Date = clsGeneral.FormatNullDateToStore(txtEndDateToDate.Text);
            Nullable<DateTime> End_From_Date = clsGeneral.FormatNullDateToStore(txtEndDateFromDate.Text);

            obj.Region = strRegion;
            obj.Market = strMarket;
            obj.Location = strLocaiton;
            obj.ServiceContract = strServiceContract;
            obj.ServiceType = strServiceType;
            obj.StartToDate = Start_To_Date;
            obj.StartFromDate = Start_From_Date;
            obj.EndToDate = End_To_Date;
            obj.EndFromDate = End_From_Date;

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
}
