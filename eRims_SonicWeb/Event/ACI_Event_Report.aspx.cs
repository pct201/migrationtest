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
using ERIMS_DAL;

public partial class ACI_Event_Report : clsBasePage
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
        lblReport.Text = GenerageACIReport().ToString();
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
        lblHeading.Text = "ACI Event Report";
    }
    #endregion

    #region Methods

    /// <summary>
    /// Generate Report HTML based on Report Criteria
    /// </summary>
    /// <returns>return string builder objects contains report in HTML format</returns>
    private System.Text.StringBuilder GenerageACIReport()
    {
        DateTime? dtFromDate = null;
        DateTime? dtToDate = null;


        if (txtFrom_Date_Of_Event.Text != "")
            dtFromDate = Convert.ToDateTime(txtFrom_Date_Of_Event.Text);

        if (txtTo_Date_Of_Event.Text != "")
            dtToDate = Convert.ToDateTime(txtTo_Date_Of_Event.Text);

        DataSet dsReport = ERIMS.DAL.clsEvent.GetACI_Report(dtFromDate, dtToDate);

        // get data tables from dataset
        DataTable dtReport = dsReport.Tables[0];
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
            sbRecorords.Append("<td align='center' class='cols_' style='font-size:9pt;' colspan='5'><b>ACI Event Report</b></td></tr>");
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>");
            sbRecorords.Append("<td align='left' style='font-size:9pt;' colspan='5'>Date From: " + clsGeneral.FormatDBNullDateToDisplay(txtFrom_Date_Of_Event.Text) + "</td></tr>");
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>"); //Title
            sbRecorords.Append("<td align='left' style='font-size:9pt;' colspan='5'>Date To: " + clsGeneral.FormatDBNullDateToDisplay(txtTo_Date_Of_Event.Text) + "</td></tr>");

            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td class='cols_' width='185px'>Location</td>");
            sbRecorords.Append("<td class='cols_' width='220px' align='right'>ACI Event Count</td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'>Sonic Event Count</td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'>Total Count</td>");
            sbRecorords.Append("<td class='cols_' width='220px' align='right'>Missed Event Percentage</td>");
      
            sbRecorords.Append("</tr>");
            for (int intI3 = 0; intI3 < dtReport.Rows.Count; intI3++)
            {
                DataRow drRecords = dtReport.Rows[intI3];
                int intRes;
                int intDiv = System.Math.DivRem(intI3, 2, out intRes);
                if (intRes == 0)
                    sbRecorords.Append("<tr style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                else
                    sbRecorords.Append("<tr style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>");

                sbRecorords.Append("<td  class='cols_' align='left' >" + Convert.ToString(drRecords["Location"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N0}", drRecords["Sonic_Event"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N0}", drRecords["ACI_Event"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N0}", drRecords["Total_Count"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N1}", drRecords["Missed_Event_Percent"]) + "</td>");
                
                sbRecorords.Append("</tr>");
            }
            sbRecorords.Append("<tr style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>");

            sbRecorords.Append("<td  class='cols_' align='left' ><b>Total</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Format("{0:N0}", dtReport.Compute("SUM(Sonic_Event)", "")) + "</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Format("{0:N0}", dtReport.Compute("SUM(ACI_Event)", "")) + "</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Format("{0:N0}", dtReport.Compute("SUM(Total_Count)", "")) + "</b></td>");
            sbRecorords.Append("<td class='cols_' align='right'><b>" + string.Format("{0:N1}", dtReport.Compute("(SUM(ACI_Event) * 100)/SUM(Total_Count)", "")) + "</b></td>");

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