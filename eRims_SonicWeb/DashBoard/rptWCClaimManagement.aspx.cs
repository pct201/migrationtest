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
using System.Text;
using System.IO;
using ERIMS.DAL;
public partial class rptWCClaimManagement : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindRegion();
            BindYear();

            //Bind Market Dropdown
            ComboHelper.FillMarket(new DropDownList[] { ddlMarket }, true);

            drpReportInterval.Focus();

        }
    }
    #region "Controls Events"

    /// <summary>
    /// Handles Show Report button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        string strReportInterval = "";
        strReportInterval = drpReportInterval.SelectedValue;
        string strRegion = "";
        // get selected regions
        strRegion = Convert.ToString(drpRegions.SelectedValue);
        if (strReportInterval.ToLower().ToString() == "monthly")
        {
            lblReport.Text = GenerageMonthlyReport().ToString();
        }
        else if (strReportInterval.ToLower().ToString() == "quarterly")
        {
            lblReport.Text = GenerageQuarterlyReport().ToString();
        }
        else if (strReportInterval.ToLower().ToString() == "annually")
        {

            lblReport.Text = GenerageAnnaulyReport().ToString();
        }
    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        // load the page again to clear selection
        drpRegions.SelectedIndex = 0;
        ddlMarket.SelectedIndex = 0;
        drpYear.SelectedIndex = 0;
        drpReportInterval.SelectedIndex = 0;
    }

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    /// <summary>
    /// Handles Export to Excel link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.ExportGrid("WCClaimsManagement.xlsx", lblReport);
    }
    /// <summary>
    /// Back hrom report to Criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        trCriteria.Visible = true;
        tblReport.Visible = false;
    }
    #endregion

    #region Mehods
    private void BindYear()
    {
        drpYear.Items.Clear();
        int intMinYear, intMaxYear;
        intMinYear = 2000;
        intMaxYear = DateTime.Now.Year;
        for (int i = intMaxYear; i >= intMinYear; i--)
        {
            drpYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }
    private void BindRegion()
    {
        // get regions for user having access to and bind the regions list box
        DataTable dtRegions = clsExposuresReports.GetRegionList().Tables[0];
        drpRegions.DataSource = dtRegions;
        drpRegions.DataTextField = "region";
        drpRegions.DataValueField = "region";
        drpRegions.DataBind();
        drpRegions.Items.Insert(0, new ListItem("--All Regions--", ""));
    }

    /// <summary>
    /// Generate Report HTML based on Report Criteria
    /// </summary>
    /// <returns>return stringbuilder objects contans report in HTML format</returns>
    private System.Text.StringBuilder GenerageMonthlyReport()
    {
        string strReportInterval = "";
        strReportInterval = drpReportInterval.SelectedValue;
        string strRegion = null;
        // get selected regions
        strRegion = Convert.ToString(drpRegions.SelectedValue);

        string strMarket = null;
        // get selected Markets
        if (ddlMarket.SelectedValue != "0")
            strMarket = Convert.ToString(ddlMarket.SelectedValue);

        DataSet dsReport = Report.GetWCClaimManagementReport(strRegion, strMarket, Convert.ToInt32(drpYear.SelectedValue), strReportInterval);

        // get data tables from dataset
        DataTable dtRegions = dsReport.Tables[0];

        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
        trCriteria.Visible = false;
        tblReport.Visible = true;
        lbtExportToExcel.Visible = dtRegions.Rows.Count > 0;
        btnBack.Visible = true;
        // Check if record found or not.
        if (dtRegions.Rows.Count > 0)
        {
            sbRecorords.Append("<style type='text/css'></style><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td class='cols_' >");
            //sbRecorords.Append("<div style='overflow: hidden; width: 995px;'>");
            sbRecorords.Append("<div style='overflow-x: scroll;overflow-y:hidden; width: 994px; height: 100%;'>");
            sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='1980px'>");//Sub Table
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>"); //Title
            sbRecorords.Append("<td align='left' style='font-size:9pt;' colspan='2'><b>Sonic Automotive</b></td>");
            sbRecorords.Append("<td align='center' style='font-size:9pt;' colspan='9' ><b> Worker's Compensation Claims Management - MONTHLY REPORT FOR " + drpYear.SelectedValue + " </b></td>");
            sbRecorords.Append("<td style='font-size:9pt' align='right' colspan='4'>Valuation Date: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</td></tr>");

            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td class='cols_' width='180px'>REGION</td>");
            sbRecorords.Append("<td class='cols_' width='230px'>STORE</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>JANUARY</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>FEBRUARY</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>MARCH</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>APRIL</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>MAY</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>JUNE</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>JULY</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>AUGUST</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>SEPTEMBER</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>OCTOBER</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>NOVEMBER</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>DECEMBER</td>");
            sbRecorords.Append("<td class='cols_' width='130px'>AVERAGE SCORE</td>");
            sbRecorords.Append("</tr>");
            for (int intI3 = 0; intI3 < dtRegions.Rows.Count; intI3++)
            {
                DataRow drRecords = dtRegions.Rows[intI3];
                int intRes;
                int intDiv = System.Math.DivRem(intI3, 2, out intRes);
                if (intRes == 0)
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                else
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>");

                sbRecorords.Append("<td  class='cols_' align='left' >" + Convert.ToString(drRecords["Region"]) + "</td>");
                sbRecorords.Append("<td class='cols_' >" + Convert.ToString(drRecords["DBA"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["JANUARY"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["FEBRUARY"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["MARCH"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["APRIL"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["MAY"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["JUNE"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["JULY"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["AUGUST"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["SEPTEMBER"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["OCTOBER"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["NOVEMBER"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["DECEMBER"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["Average"]) + "</td>");
                sbRecorords.Append("</tr>");
            }

            //sbRecorords.Append("<tr><td colspan='15' class='cols_'>&nbsp;</td></tr>");
            sbRecorords.Append("</table>");
            sbRecorords.Append("</div>");
            sbRecorords.Append("</table>");
            trGrid.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.            
            trGrid.Visible = false;
            sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
            sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
            sbRecorords.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
        }
        return sbRecorords;
    }

    /// <summary>
    /// Generate Report HTML based on Report Criteria
    /// </summary>
    /// <returns>return string-builder objects contains report in HTML format</returns>
    private System.Text.StringBuilder GenerageQuarterlyReport()
    {
        string strReportInterval = "";
        strReportInterval = drpReportInterval.SelectedValue;
        string strRegion = "";
        // get selected regions
        strRegion = Convert.ToString(drpRegions.SelectedValue);

        string strMarket = null;
        // get selected Markets
        if (ddlMarket.SelectedValue != "0")
            strMarket = Convert.ToString(ddlMarket.SelectedValue);


        DataSet dsReport = Report.GetWCClaimManagementReport(strRegion, strMarket, Convert.ToInt32(drpYear.SelectedValue), strReportInterval);

        // get data tables from dataset
        DataTable dtRegions = dsReport.Tables[0];
        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
        trCriteria.Visible = false;
        tblReport.Visible = true;
        lbtExportToExcel.Visible = dtRegions.Rows.Count > 0;
        btnBack.Visible = true;
        // Check if record found or not.
        if (dtRegions.Rows.Count > 0)
        {
            sbRecorords.Append("<style type='text/css'></style><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td class='cols_' >");

            // sbRecorords.Append("<div style='overflow: scroll; width: 985px; height: 100%;'>");
            sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='995px'>");//Sub Table
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>"); //Title
            sbRecorords.Append("<td align='left' style='font-size:9pt;' colspan='1'><b>Sonic Automotive</b></td>");
            sbRecorords.Append("<td align='center' style='font-size:9pt;' colspan='3' ><b> Worker's Compensation Claims Management - QUARTERLY REPORT FOR " + drpYear.SelectedValue + " </b></td>");
            sbRecorords.Append("<td style='font-size:9pt' align='right' colspan='3'>Valuation Date: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</td></tr>");

            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td class='cols_' width='185px'>REGION</td>");
            sbRecorords.Append("<td class='cols_' width='220px'>STORE</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>Q1</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>Q2</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>Q3</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>Q4</td>");
            sbRecorords.Append("<td class='cols_' width='110px'>AVERAGE SCORE</td>");
            sbRecorords.Append("</tr>");
            for (int intI3 = 0; intI3 < dtRegions.Rows.Count; intI3++)
            {
                DataRow drRecords = dtRegions.Rows[intI3];
                int intRes;
                int intDiv = System.Math.DivRem(intI3, 2, out intRes);
                if (intRes == 0)
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                else
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>");

                sbRecorords.Append("<td  class='cols_' align='left' >" + Convert.ToString(drRecords["Region"]) + "</td>");
                sbRecorords.Append("<td class='cols_' >" + Convert.ToString(drRecords["DBA"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["Q1"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["Q2"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["Q3"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["Q4"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["Average"]) + "</td>");
                sbRecorords.Append("</tr>");
            }
            //  sbRecorords.Append("<tr><td colspan='7' class='cols_'>&nbsp;</td></tr>");
            sbRecorords.Append("</table>");
            //  sbRecorords.Append("</div>");
            sbRecorords.Append("</table>");
            trGrid.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.            
            trGrid.Visible = false;
            sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
            sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
            sbRecorords.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
        }
        return sbRecorords;
    }

    /// <summary>
    /// Generate Report HTML based on Report Criteria
    /// </summary>
    /// <returns>return string-builder objects contains report in HTML format</returns>
    private System.Text.StringBuilder GenerageAnnaulyReport()
    {
        string strReportInterval = "";
        strReportInterval = drpReportInterval.SelectedValue;
        string strRegion = "";
        // get selected regions
        strRegion = Convert.ToString(drpRegions.SelectedValue);

        string strMarket = null;
        // get selected Markets
        if (ddlMarket.SelectedValue != "0")
            strMarket = Convert.ToString(ddlMarket.SelectedValue);


        DataSet dsReport = Report.GetWCClaimManagementReport(strRegion, strMarket, Convert.ToInt32(drpYear.SelectedValue), strReportInterval);

        // get data tables from dataset
        DataTable dtRegions = dsReport.Tables[0];
        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
        trCriteria.Visible = false;
        tblReport.Visible = true;
        lbtExportToExcel.Visible = dtRegions.Rows.Count > 0;
        btnBack.Visible = true;
        int intSelectYear = Convert.ToInt32(drpYear.SelectedValue);
        // Check if record found or not.
        if (dtRegions.Rows.Count > 0)
        {
            sbRecorords.Append("<style type='text/css'></style><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td class='cols_' >");

            //sbRecorords.Append("<div style='overflow: scroll; width: 995px; height: 100%;'>");
            sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");//Sub Table
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>"); //Title
            sbRecorords.Append("<td align='left' style='font-size:9pt;' colspan='1'><b>Sonic Automotive</b></td>");
            sbRecorords.Append("<td align='center' style='font-size:9pt;' colspan='4' ><b> Worker's Compensation Claims Management - ANNAUL REPORT FOR " + drpYear.SelectedValue + " </b></td>");
            sbRecorords.Append("<td style='font-size:9pt' align='right' colspan='3'>Valuation Date: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</td></tr>");

            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td class='cols_' width='180px'>REGION</td>");
            sbRecorords.Append("<td class='cols_' width='230px'>STORE</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>" + Convert.ToString(intSelectYear - 4) + "</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>" + Convert.ToString(intSelectYear - 3) + "</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>" + Convert.ToString(intSelectYear - 2) + "</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>" + Convert.ToString(intSelectYear - 1) + "</td>");
            sbRecorords.Append("<td class='cols_' width='120px'>" + Convert.ToString(intSelectYear) + "</td>");
            sbRecorords.Append("<td class='cols_' width='110px'>AVERAGE SCORE</td>");
            sbRecorords.Append("</tr>");
            for (int intI3 = 0; intI3 < dtRegions.Rows.Count; intI3++)
            {
                DataRow drRecords = dtRegions.Rows[intI3];
                int intRes;
                int intDiv = System.Math.DivRem(intI3, 2, out intRes);
                if (intRes == 0)
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                else
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>");

                sbRecorords.Append("<td  class='cols_' align='left' >" + Convert.ToString(drRecords["Region"]) + "</td>");
                sbRecorords.Append("<td class='cols_' >" + Convert.ToString(drRecords["DBA"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["Year1"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["Year2"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["Year3"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["Year4"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["Year5"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + GetScoreName(drRecords["Average"]) + "</td>");
                sbRecorords.Append("</tr>");
            }
            // sbRecorords.Append("<tr><td colspan='7' class='cols_'>&nbsp;</td></tr>");
            sbRecorords.Append("</table>");
            // sbRecorords.Append("</div>");
            sbRecorords.Append("</table>");
            trGrid.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.            
            trGrid.Visible = false;
            sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
            sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
            sbRecorords.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
        }
        return sbRecorords;
    }

    /// <summary>
    /// Function to return Get Score Name
    /// </summary>
    /// <param name="objValue"></param>
    /// <returns></returns>
    public string GetScoreName(object objValue)
    {
        if (objValue != null)
        {
            if (objValue.ToString() == "1")
            {
                return Charts.Tin_Label;
            }
            else if (objValue.ToString() == "2")
            {
                return Charts.Bronze_Label;
            }
            else if (objValue.ToString() == "3")
            {
                return Charts.Silver_Label;
            }
            else if (objValue.ToString() == "4")
            {
                return Charts.Gold_Label;
            }
            else if (objValue.ToString() == "5")
            {
                return Charts.Platinum_Label;
            }
            else
                return "";
        }
        else
        {
            return "";
        }
    }
    #endregion

}
