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

public partial class SONIC_RealEstate_ScheduleWCAllocationYTDCharge : clsBasePage
{
    #region "Property"

    /// <summary>
    /// Primary key for Tatva_Report
    /// </summary>
    public decimal PK_ReportID
    {
        get { return clsGeneral.IsNull(ViewState["PK_ReportID"]) ? 0 : Convert.ToDecimal(ViewState["PK_ReportID"]); }
        set { ViewState["PK_ReportID"] = value; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            decimal _Pk;

            //  Check if Parameter report-Id is passed or not.
            if (Request.QueryString["PK_ReportID"] != null)
            {
                // Check report ID paramaeter is valid or not
                if (decimal.TryParse(Request.QueryString[0], out _Pk))
                {
                    PK_ReportID = _Pk;
                    BindDropDownList();
                }
                else
                {
                    // hide report and show error message
                    lblError.Text = "Parameter Report Type is Invalid.";
                    tblReport.Visible = false;
                }
            }
            else
            {
                // hide report and show error message
                lblError.Text = "Parameter Report Type is Invalid.";
                tblReport.Visible = false;
            }
        }
    }

    /// <summary>
    /// Handle Save Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tatva_ReportWCAllocationYTDChargeSchedule obj = new Tatva_ReportWCAllocationYTDChargeSchedule();
        string strRegion = string.Empty, strLocation = string.Empty, strYear = string.Empty, strMarket = string.Empty;

        // get selected regions
        foreach (ListItem li in lstRegion.Items)
        {
            if (li.Selected)
                strRegion = strRegion + "'" + li.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        //get selected Market
        foreach (ListItem li in lstMarket.Items)
        {
            if (li.Selected)
                strMarket = strMarket + "" + li.Value + ",";
        }
        strMarket = strMarket.TrimEnd(',');

        // get selected regions
        foreach (ListItem li in lstLocation.Items)
        {
            if (li.Selected)
                strLocation = strLocation + li.Value + ",";
        }
        strLocation = strLocation.TrimEnd(',');

        // get selected Lease Type
        foreach (ListItem li in lstYear.Items)
        {
            if (li.Selected)
                strYear = strYear + li.Value + ",";
        }
        strYear = strYear.TrimEnd(',');

        // set region
        if (!string.IsNullOrEmpty(strRegion))
            obj.Region = strRegion;

        // set region
        if (!string.IsNullOrEmpty(strMarket))
            obj.Market = strMarket;


        // set lease type
        if (!string.IsNullOrEmpty(strLocation))
            obj.Location = strLocation;

        if (!string.IsNullOrEmpty(strYear))
            obj.Year = strYear;

        obj.Run_report_by = rdoRunBy.SelectedValue;
        obj.FK_Report = PK_ReportID;
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

    #region "Methods"

    /// <summary>
    /// Bind Dropdown for report
    /// </summary>
    private void BindDropDownList()
    {
        // Fill Location by Employee        
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;

        // select region as per login user
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));

        // Append region in comma seperated string value
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
                Regional += drRegion["Region"].ToString() + ",";
        }
        else
            Regional = string.Empty;

        //Fill Location
        DataSet dsLocation = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(",")));
        lstLocation.Items.Clear();

        dsLocation.Tables[0].DefaultView.Sort = "dba";
        lstLocation.DataTextField = "dba";
        lstLocation.DataValueField = Convert.ToString(dsLocation.Tables[0].Columns["PK_LU_Location_ID"]);
        lstLocation.DataSource = dsLocation.Tables[0].DefaultView.ToTable();
        lstLocation.DataBind();
        clsGeneral.DisposeOf(dsLocation);
        clsGeneral.DisposeOf(dsRegion);

        //Region
        lstRegion.DataSource = LU_Location.GetRegionList();
        lstRegion.DataTextField = "region";
        lstRegion.DataValueField = "region";
        lstRegion.DataBind();

        //Fill Market
        ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);

        lstYear.DataSource = WC_FR.SelectDistinctIncidentYear().Tables[0];
        lstYear.DataTextField = "WCYear";
        lstYear.DataValueField = "WCYear";
        lstYear.DataBind();

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
