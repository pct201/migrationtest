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

public partial class ACI_Custom_Report : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
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
        lblReport.Text = GenerageACI_Custom_Report().ToString();
    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        // load the page again to clear selection
        txtFrom_Date_Of_Event.Text = "";
        txtTo_Date_Of_Event.Text = "";
    }

    /// <summary>
    /// This method is added for export Gridview To Excel which contains SubGridview.
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
        GridViewExportUtil.ExportGrid("ACI Event Report.xlsx", lblReport);
    }
    /// <summary>
    /// Back from report to Criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        trCriteria.Visible = true;
        tblReport.Visible = false;
        lblHeading.Text = "ACI Custom Report";
    }
    #endregion

    #region Methods

    /// <summary>
    /// Generate Report HTML based on Report Criteria
    /// </summary>
    /// <returns>return string builder objects contains report in HTML format</returns>
    private System.Text.StringBuilder GenerageACI_Custom_Report()
    {
        DateTime? dtFromDate = null;
        DateTime? dtToDate = null;


        if (txtFrom_Date_Of_Event.Text != "")
            dtFromDate = Convert.ToDateTime(txtFrom_Date_Of_Event.Text);

        if (txtTo_Date_Of_Event.Text != "")
            dtToDate = Convert.ToDateTime(txtTo_Date_Of_Event.Text);

        DataSet dsReport = clsEvent.GetACI_Custom_Report(dtFromDate, dtToDate);

        // get data tables from dataset
        DataTable dtReport = dsReport.Tables[0];
        DataTable dtReportTotal = dsReport.Tables[1];
        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
        trCriteria.Visible = false;
        tblReport.Visible = true;
        lbtExportToExcel.Visible = dtReport.Rows.Count > 0;
        btnBack.Visible = true;
        // Check if record found or not.
        if (dtReport.Rows.Count > 0)
        {
            sbRecorords.Append("<style type='text/css'></style><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td class='cols_' >");

            sbRecorords.Append("<table style='border: black 0.5px;padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='995px'>");//Sub Table
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>"); //Title
            sbRecorords.Append("<td align='center' class='cols_' style='font-size:9pt;' colspan='14'><b>ACI Event Custom Report</b></td></tr>");
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>");
            sbRecorords.Append("<td align='left' style='font-size:9pt;' colspan='14'>Date From: " + clsGeneral.FormatDBNullDateToDisplay(txtFrom_Date_Of_Event.Text) + "</td></tr>");
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>"); //Title
            sbRecorords.Append("<td align='left' style='font-size:9pt;' colspan='14'>Date To: " + clsGeneral.FormatDBNullDateToDisplay(txtTo_Date_Of_Event.Text) + "</td></tr>");

            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td class='cols_' width='120px'>Region</td>");
            sbRecorords.Append("<td class='cols_' width='220px'>Location</td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'>FVD Event Count</td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'>SVD Event Count</td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'>SP/V Event Count</td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'>PD Event Count</td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'>Disturbance Event Count</td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'>UVE Event Count</td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'>DP Event Count</td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'>Theft Event Count</td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'>ARE Event Count</td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'>SRE Event Count</td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'>ACI Event% Results</td>");
            //sbRecorords.Append("<td class='cols_' width='10px' align='right'>&nbsp;</td>");
            sbRecorords.Append("<td class='cols_' width='220px'>&nbsp;&nbsp;&nbsp;Resulting Score</td>");
      
            sbRecorords.Append("</tr>");
            for (int intI3 = 0; intI3 < dtReport.Rows.Count; intI3++)
            {
                DataRow drRecords = dtReport.Rows[intI3];
                int intRes;
                int intDiv = System.Math.DivRem(intI3, 2, out intRes);
                if (intRes == 0)
                    sbRecorords.Append("<tr  style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                else
                    sbRecorords.Append("<tr  style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>");

                sbRecorords.Append("<td  class='cols_' align='left' >" + Convert.ToString(drRecords["Region"]) + "</td>");
                sbRecorords.Append("<td  class='cols_' align='left' >" + Convert.ToString(drRecords["Location"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N0}", drRecords["FVD Event COUNT"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N0}", drRecords["SVD Event COUNT"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N0}", drRecords["SP/V Event COUNT"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N0}", drRecords["PD Event COUNT"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N0}", drRecords["Disturbance Event COUNT"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N0}", drRecords["UVE Event COUNT"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N0}", drRecords["DP Event COUNT"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N0}", drRecords["Theft Event COUNT"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N0}", drRecords["ACI_Event"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N0}", drRecords["Sonic_Event"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["ACI_Event_Percent"]) + "</td>");
                //sbRecorords.Append("<td class='cols_' align='right'>" + string.Empty + "</td>");
                sbRecorords.Append("<td  class='cols_' align='left' >&nbsp;&nbsp;&nbsp;" + Convert.ToString(drRecords["Resulting_Score"]) + "</td>");
                sbRecorords.Append("</tr>");
            }
            sbRecorords.Append("<tr style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>");
            
            sbRecorords.Append("<td  class='cols_' align='left' ><b>Total</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Empty + "</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Format("{0:N0}", dtReportTotal.Rows[0]["FVD_Total"]) + "</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Format("{0:N0}", dtReportTotal.Rows[0]["SVD_Total"]) + "</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Format("{0:N0}", dtReportTotal.Rows[0]["SPV_Total"]) + "</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Format("{0:N0}", dtReportTotal.Rows[0]["PD_Total"]) + "</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Format("{0:N0}", dtReportTotal.Rows[0]["Disturbance_Total"]) + "</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Format("{0:N0}", dtReportTotal.Rows[0]["UVE_Total"]) + "</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Format("{0:N0}", dtReportTotal.Rows[0]["DP_Total"]) + "</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Format("{0:N0}", dtReportTotal.Rows[0]["Theft_Total"]) + "</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Format("{0:N0}", dtReportTotal.Rows[0]["ACI_Total_Event"]) + "</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Format("{0:N0}", dtReportTotal.Rows[0]["Sonic_Event_Total"]) + "</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Format("{0:N2}", dtReportTotal.Rows[0]["Total_Percent"]) + "</b></td>");//string.Format("{0:N1}", dtReport.Compute("(SUM(ACI_Event) * 100)/(SUM([Sonic_Event])+SUM([ACI_Event]))", ""))
            //sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Empty + "</b></td>");
            sbRecorords.Append("<td class='cols_'><b>&nbsp;&nbsp;&nbsp;" + string.Format("{0:N0}", dtReportTotal.Rows[0]["Resulting_Score"]) + "</b></td>"); 

            sbRecorords.Append("</tr>");
            
            //  sbRecorords.Append("<tr><td colspan='7' class='cols_'>&nbsp;</td></tr>");
            sbRecorords.Append("</table></td></tr>");
            //  sbRecorords.Append("</div>");
            sbRecorords.Append("</table>");
            trGrid.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.            
            //trGrid.Visible = false;
            sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
            sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
            sbRecorords.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
        }
        return sbRecorords;
    }

    #endregion
}