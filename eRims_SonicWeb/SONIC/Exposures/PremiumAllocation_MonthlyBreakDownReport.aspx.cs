using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using ERIMS.DAL;


public partial class SONIC_Exposures_PremiumAllocation_MonthlyBreakDownReport : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
        lblReport.Text = GenerageMonthlyReport().ToString();
    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        txtYear.Text = "";
        ddlMonth.SelectedIndex = 0;
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
        string strcols = "border: #7f7f7f 1px solid;vertical-align: top;font-size: 8pt;border-collapse: collapse;";
        //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        //String strHTML, strFilePath, outputFiles = string.Empty;

        //strHTML = lblReport.Text;

        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        String strFilePath = String.Empty, outputFiles = String.Empty;
        StringBuilder sbRecord = new StringBuilder();

        MemoryStream memorystream = new MemoryStream();
        byte[] _bytes = Encoding.UTF8.GetBytes(stringWrite.ToString());
        memorystream.Write(_bytes, 0, _bytes.Length);
        memorystream.Seek(0, SeekOrigin.Begin);

        bool blnHTML2Excel = false;

        strFilePath = AppConfig.SitePath + @"temp\" + DateTime.Now.ToString("ddMMyyyyhhmmss");

        if (!File.Exists(strFilePath))
        {
            if (!Directory.Exists(AppConfig.SitePath + @"temp\"))
                Directory.CreateDirectory(AppConfig.SitePath + @"temp\");

            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(strFilePath))
            {
                sw.Write(lblReport.Text.ToString().Replace("#EAEAEA", "White").Replace("#eaeaea", "White").Replace("background-color:#C0C0C0", "background-color:White;").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>").Replace("background-color:#7f7f7f;color:White", "background-color:White;color:Black"));
                //lblReport.Text = string.Empty;
            }
        }
        List<System.Collections.Generic.KeyValuePair<int, double>> columnWidth = new List<System.Collections.Generic.KeyValuePair<int, double>>();
        columnWidth.Add(new KeyValuePair<int, double>(1, 35));
        columnWidth.Add(new KeyValuePair<int, double>(2, 35));
        columnWidth.Add(new KeyValuePair<int, double>(3, 35));
        columnWidth.Add(new KeyValuePair<int, double>(4, 35));

        if (File.Exists(strFilePath))
        {
            string data = File.ReadAllText(strFilePath);
            data = data.Trim();
            HTML2Excel objHtml2Excel = new HTML2Excel(data);
            objHtml2Excel.isGrid = true;
            objHtml2Excel.isUseCSS = false;
            objHtml2Excel.columnWidth = columnWidth;
            outputFiles = Path.GetFullPath(strFilePath) + ".xlsx";
            GC.Collect(0);
            blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);
        }

        //If records found
        if (blnHTML2Excel)
        {
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"" + "Sonic Monthly Premium Allocation Report Breakdown.xlsx" + "\""));
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                HttpContext.Current.Response.TransmitFile(outputFiles);
                HttpContext.Current.Response.Flush();
            }
            finally
            {
                if (File.Exists(outputFiles))
                    File.Delete(outputFiles);
                if (File.Exists(strFilePath))
                    File.Delete(strFilePath);
                HttpContext.Current.Response.End();
            }
        }
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

    #region Methods

    /// <summary>
    /// Generate Report HTML based on Report Criteria
    /// </summary>
    /// <returns>return stringbuilder objects contans report in HTML format</returns>
    private System.Text.StringBuilder GenerageMonthlyReport()
    {
        int? year = null;
        int? month = null;
        int current = 0;
        int previous = 0;
         
        if (txtYear.Text != string.Empty) year = Convert.ToInt32(txtYear.Text);
        if (ddlMonth.SelectedIndex > 0)
            month = Convert.ToInt32(ddlMonth.SelectedValue);

        DataSet dsReport = clsPA_Screen_Fields.Generate_Monthly_Premium_Allocation_Report(year,month,"BreakDown");

        DataTable dtReport = dsReport.Tables[0];

        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
        trCriteria.Visible = false;
        tblReport.Visible = true;
        lbtExportToExcel.Visible = dtReport.Rows.Count > 1;
        btnBack.Visible = true;

        int intColspan = dtReport.Columns.Count;

        string strMonth = "";

        switch(month)
        {
            case 1: strMonth = "January"; break;
            case 2: strMonth = "February"; break;
            case 3: strMonth = "March"; break;
            case 4: strMonth = "April"; break;
            case 5: strMonth = "May"; break;
            case 6: strMonth = "June"; break;
            case 7: strMonth = "July"; break;
            case 8: strMonth = "August"; break;
            case 9: strMonth = "September"; break;
            case 10: strMonth = "October"; break;
            case 11: strMonth = "November"; break;
            case 12: strMonth = "December"; break;
        }



        // Check if record found or not.
        if (dtReport.Rows.Count > 1)
        {
            sbRecorords.Append("<style type='text/css'></style><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td class='cols_' >");
            //sbRecorords.Append("<div style='overflow: hidden; width: 995px;'>");
            sbRecorords.Append("<div style='overflow-x: scroll;overflow-y:hidden; width: 994px; height: 100%;'>");
            sbRecorords.Append("<table style='border: black 0.5px solid;padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='990px'>");//Sub Table
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:40px'>"); //Title
            sbRecorords.Append("<td align='left' style='font-size:9pt;' colspan='2'><b>Sonic Monthly Premium Allocation Report - Breakdown&nbsp;&nbsp;&nbsp;&nbsp;Year :" + txtYear.Text + "</b></td>");
            //sbRecorords.Append("<td align='center' style='font-size:9pt;' colspan='1' ><b> Year :" + txtYear.Text + " </b></td>");
            sbRecorords.Append("<td style='font-size:9pt' align='right' colspan='2'><b>Date Report Generated: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</b></td></tr>");
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>"); //Title
            sbRecorords.Append("<td style='font-size:9pt;' class='cols_' align='center' colspan='4'><b>Dollars</b></td></tr>");
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td class='cols_' width='250px' align='left'><b>Sonic Location Code</b></td>");
            sbRecorords.Append("<td class='cols_' width='250px' align='left'><b>Location d/b/a</b></td>");
            sbRecorords.Append("<td class='cols_' width='250px' align='left'><b>Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='250px' align='right'><b>"+strMonth+"</b></td>");
            //sbRecorords.Append("<td class='cols_' width='80px' align='right'><b>February</b></td>");
            //sbRecorords.Append("<td class='cols_' width='80px' align='right'><b>March</b></td>");
            //sbRecorords.Append("<td class='cols_' width='80px' align='right'><b>April</b></td>");
            //sbRecorords.Append("<td class='cols_' width='80px' align='right'><b>May</b></td>");
            //sbRecorords.Append("<td class='cols_' width='80px' align='right'><b>June</b></td>");
            //sbRecorords.Append("<td class='cols_' width='80px' align='right'><b>July</b></td>");
            //sbRecorords.Append("<td class='cols_' width='80px' align='right'><b>August</b></td>");
            //sbRecorords.Append("<td class='cols_' width='80px' align='right'><b>September</b></td>");
            //sbRecorords.Append("<td class='cols_' width='80px' align='right'><b>October</b></td>");
            //sbRecorords.Append("<td class='cols_' width='80px' align='right'><b>November</b></td>");
            //sbRecorords.Append("<td class='cols_' width='80px' align='right'><b>December</b></td>");
            sbRecorords.Append("</tr>");

            for (int i = 0; i < dtReport.Rows.Count; i++)
            {
                int intRes;
                int intDiv = System.Math.DivRem(i, 2, out intRes);
                if (intRes == 0)
                    sbRecorords.Append("<tr style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>");
                else
                    sbRecorords.Append("<tr style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");

                DataRow drRecords = dtReport.Rows[i];

                if (Convert.ToString(drRecords["Premium"]) == "Total_All_Locations")
                {
                    sbRecorords.Append("<td class='cols_' align='left'></td>");
                    sbRecorords.Append("<td class='cols_' align='left'></td>");
                    sbRecorords.Append("<td class='cols_' align='left'><B>" + Convert.ToString(drRecords["Premium"]).Replace("_", " ").Replace("Total All Locations", "Total All Locations on Report") + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords[strMonth]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["February"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["March"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["April"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["May"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["June"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["July"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["August"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["September"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["October"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["November"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["December"]) + "</B></td>");
                }
                else if (Convert.ToString(drRecords["Premium"]) == "Z_Location_Total")
                {
                    sbRecorords.Append("<td class='cols_' align='left'></td>");
                    sbRecorords.Append("<td class='cols_' align='left'></td>");
                    sbRecorords.Append("<td class='cols_' align='left'><B>" + Convert.ToString(drRecords["Premium"]).Replace("_", " ").Replace("Z Location Total", "Location Total") + "<B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords[strMonth]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["February"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["March"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["April"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["May"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["June"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["July"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["August"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["September"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["October"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["November"]) + "</B></td>");
                    //sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:f2}", drRecords["December"]) + "</B></td>");
                }
                else
                {
                    current = Convert.ToInt32(drRecords["Sonic_Location_Code"]);

                    if (current != previous)
                    {
                        sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["Sonic_Location_Code"]) + "</td>");
                        sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["Location_DBA"]) + "</td>");
                        previous = current;
                    }
                    else
                    {
                        sbRecorords.Append("<td class='cols_' align='left'></td>");
                        sbRecorords.Append("<td class='cols_' align='left'></td>");
                    }

                    sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["Premium"]).Replace("_"," ") + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords[strMonth]) + "</td>");
                    //sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:f2}", drRecords["February"]) + "</td>");
                    //sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:f2}", drRecords["March"]) + "</td>");
                    //sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:f2}", drRecords["April"]) + "</td>");
                    //sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:f2}", drRecords["May"]) + "</td>");
                    //sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:f2}", drRecords["June"]) + "</td>");
                    //sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:f2}", drRecords["July"]) + "</td>");
                    //sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:f2}", drRecords["August"]) + "</td>");
                    //sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:f2}", drRecords["September"]) + "</td>");
                    //sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:f2}", drRecords["October"]) + "</td>");
                    //sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:f2}", drRecords["November"]) + "</td>");
                    //sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:f2}", drRecords["December"]) + "</td>");

                    
                }
                sbRecorords.Append("</tr>");
            }
            sbRecorords.Append("</table>");
            sbRecorords.Append("</div>");
            sbRecorords.Append("</td>");
            sbRecorords.Append("</tr>");
            sbRecorords.Append("</table>");
            trGrid.Visible = true;

        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.  
            trGrid.Visible = true;
            sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
            sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
            sbRecorords.Append("<td align='center' style='font-size:8pt;'>No Records found.</td></tr></table>");
        }

        return sbRecorords;
    }
    #endregion

}