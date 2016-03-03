using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using ERIMS.DAL;
public partial class SONIC_SLT_rptSLTScoring : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindRegion();
            BindYear();
            ComboHelper.FillMarket(new DropDownList[] { ddlMarket }, true);
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
        string strRegion = "";
        // get selected regions
        strRegion = Convert.ToString(drpRegions.SelectedValue);
        lblReport.Text = GenerageMonthlyReport().ToString();
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
        GridViewExportUtil.ExportGrid("SLT Scoring Report.xlsx", lblReport);
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
        intMinYear = 2012;
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
        string strRegion ;
        // get selected regions
        strRegion = Convert.ToString(drpRegions.SelectedValue);
        string strMarket = string.Empty;
        if (Convert.ToInt32(ddlMarket.SelectedValue) > 0)
            strMarket = Convert.ToString(ddlMarket.SelectedValue);
        else
            strMarket = null;

        DataSet dsReport = SLT_Meeting.GetSLT_ScoringReport(strRegion, strMarket, Convert.ToInt32(drpYear.SelectedValue));

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
            sbRecorords.Append("<style type='text/css'></style><div style='overflow-x: scroll;overflow-y:hidden; width: 994px; height: 100%;'><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td class='cols_' >");
            //sbRecorords.Append("<div style='overflow: hidden; width: 995px;'>");
            //sbRecorords.Append("<div style='overflow-x: scroll;overflow-y:hidden; width: 994px; height: 100%;'>");
            sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='1980px'>");//Sub Table
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>"); //Title
            sbRecorords.Append("<td align='left' style='font-size:9pt;' colspan='2'><b>Sonic Automotive</b></td>");
            sbRecorords.Append("<td align='center' style='font-size:9pt;' colspan='9' ><b> SLT SCORING REPORT - MONTHLY " + drpYear.SelectedValue + " </b></td>");
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
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["JANUARY"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["FEBRUARY"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["MARCH"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["APRIL"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["MAY"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["JUNE"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["JULY"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["AUGUST"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["SEPTEMBER"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["OCTOBER"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["NOVEMBER"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["DECEMBER"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + (drRecords["Average"] != DBNull.Value ? Convert.ToString(drRecords["Average"]) :"N/A") + "</td>");
                sbRecorords.Append("</tr>");
            }

            //sbRecorords.Append("<tr><td colspan='15' class='cols_'>&nbsp;</td></tr>");
            sbRecorords.Append("</table>");
            //sbRecorords.Append("</div>");
            sbRecorords.Append("</table></div>");
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

    
    #endregion
}