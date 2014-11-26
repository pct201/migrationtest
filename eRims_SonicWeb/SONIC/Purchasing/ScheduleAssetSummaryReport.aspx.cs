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
/// <summary>
/// Date           : 23-03-09
/// 
/// Developer Name : Ravi Gupta
/// 
/// Description    : Schedule Asset Report as per passed criteria
/// 
/// </summary>
public partial class SONIC_Purchasing_ScheduleAssetSummaryReport : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // when page is loaded first time
        if (!IsPostBack)
        {
            DataTable dtRegion = Purchasing_Asset.GetRegionList().Tables[0];
            lstRegions.DataSource = dtRegion;
            lstRegions.DataTextField = "Region";
            lstRegions.DataValueField = "Region";
            lstRegions.DataBind();

            DataTable dtLocation = Purchasing_Asset.GetLocationList().Tables[0];
            lstLocation.DataSource = dtLocation;
            lstLocation.DataTextField = "dba";
            lstLocation.DataValueField = "PK_LU_Location_Id";
            lstLocation.DataBind();

            DataTable dtType = Purchasing_Asset.GetTypeList().Tables[0];
            lstType.DataSource = dtType;
            lstType.DataTextField = "Type";
            lstType.DataValueField = "Type";
            lstType.DataBind();

            DataTable dtManufacturer = Purchasing_Asset.GetManufacturerList().Tables[0];
            lstManufacturer.DataSource = dtManufacturer;
            lstManufacturer.DataTextField = "Fld_Desc";
            lstManufacturer.DataValueField = "FK_LU_Manufacturer";
            lstManufacturer.DataBind();

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
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Tatva_RptAssestDetailSchedule obj = new Tatva_RptAssestDetailSchedule();

            //Report Filters
            string strRegion = "";
            string strLocation = "";
            string strType = "";
            string strManufacturer = "";


            // get selected claim types

            foreach (ListItem itmRegion in lstRegions.Items)
            {
                if (itmRegion.Selected)
                    strRegion = strRegion + "'" + itmRegion.Value + "',";
            }
            strRegion = strRegion.TrimEnd(',');

            foreach (ListItem itmLocation in lstLocation.Items)
            {
                if (itmLocation.Selected)
                    strLocation = strLocation + "'" + itmLocation.Value + "',";
            }
            strLocation = strLocation.TrimEnd(',');

            foreach (ListItem itmType in lstType.Items)
            {
                if (itmType.Selected)
                    strType = strType + "'" + itmType.Value + "',";
            }
            strType = strType.TrimEnd(',');

            foreach (ListItem itmManufacturer in lstManufacturer.Items)
            {
                if (itmManufacturer.Selected)
                    strManufacturer = strManufacturer + "'" + itmManufacturer.Value + "',";
            }
            strManufacturer = strManufacturer.TrimEnd(',');

            obj.Region = strRegion;
            obj.Location = strLocation;
            obj.Type = strType;
            obj.Manufacutrer = strManufacturer;

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
