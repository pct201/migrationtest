using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using ERIMS.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;


public partial class SONIC_Exposures_PremiumAllocation_AnnualReport_New : clsBasePage
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
        decimal _retVal;
        int? year = null;

        if (txtYear.Text != string.Empty) year = Convert.ToInt32(txtYear.Text);
        //_retVal = clsPA_Screen_Fields.GetStatusOfDuplicateAnnualReport(year);

        //if (_retVal == 1)
        //{
        //    string strArgs = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];
        //    if (strArgs == "UpdateDetails")
        //    {
        //        lblReport.Text = GenerageMonthlyReport().ToString();
        //    }
        //    else
        //        ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:valueSave(" + txtYear.Text + ");", true);
        //}
        //else
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
        //string strcols = "border: #7f7f7f 1px solid;vertical-align: top;font-size: 8pt;border-collapse: collapse;";
        //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        ////PrepareControlForExport(gvReportGrid.HeaderRow);
        //lblReport.RenderControl(htmlWrite);
        //// gvReportGrid.RenderControl(htmlWrite);

        //MemoryStream memorystream = new MemoryStream();
        //byte[] _bytes = Encoding.UTF8.GetBytes(stringWrite.ToString().Replace("border-top:#EAEAEA", "border-top:#000000").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>"));
        //memorystream.Write(_bytes, 0, _bytes.Length);
        //memorystream.Seek(0, SeekOrigin.Begin);

        //HttpContext.Current.Response.Clear();
        //HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Sonic Premium Allocation Annual Report.xls"));
        //HttpContext.Current.Response.ContentType = "application/ms-excel";
        //HttpContext.Current.Response.Write(stringWrite.ToString().Replace("#EAEAEA", "White").Replace("#eaeaea", "White").Replace("background-color:#C0C0C0", "background-color:White;").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>").Replace("background-color:#7f7f7f;color:White", "background-color:White;color:Black"));
        //HttpContext.Current.Response.End();

        ExcelPackage PremiumAllocation = new ExcelPackage();
        ExcelWorksheet PremiumAllocation_WS = PremiumAllocation.Workbook.Worksheets.Add("Annual Report");

        //PremiumAllocation_WS.Cells.Style.Font.Size = 12;
        //PremiumAllocation_WS.Cells.Style.Font.Name = "Calibri";

        #region Set Headers
        using (ExcelRange range = PremiumAllocation_WS.Cells[4, 1, 4, 9])
        {
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.Black);
            range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            range.Style.Font.Color.SetColor(Color.White);
            range.Style.Font.Size = 8;
            range.Style.Font.Bold = true;
            range.Style.Font.Name = "Tahoma";
            range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.WrapText = true;
        }

        using (ExcelRange range = PremiumAllocation_WS.Cells[4, 10, 4, 19])
        {
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(31, 73, 125));
            range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            range.Style.Font.Color.SetColor(Color.White);
            range.Style.Font.Size = 8;
            range.Style.Font.Bold = true;
            range.Style.Font.Name = "Tahoma";
            range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.WrapText = true;
        }

        using (ExcelRange range = PremiumAllocation_WS.Cells[4, 20, 4, 20])
        {
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.Black);
            range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            range.Style.Font.Color.SetColor(Color.White);
            range.Style.Font.Size = 8;
            range.Style.Font.Bold = true;
            range.Style.Font.Name = "Tahoma";
            range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.WrapText = true;
        }

        PremiumAllocation_WS.Cells["A2"].Value = "INSURANCE PREMIUM ANNUAL REPORT";
        PremiumAllocation_WS.Cells["A2"].Style.Font.Bold = true;
        PremiumAllocation_WS.Cells["A2"].Style.Font.Size = 12;
        PremiumAllocation_WS.Cells["A2:D2"].Merge = true;

        PremiumAllocation_WS.Cells["E2"].Value = "YEAR : " + txtYear.Text;
        PremiumAllocation_WS.Cells["E2"].Style.Font.Bold = true;
        PremiumAllocation_WS.Cells["E2:F2"].Merge = true;

        PremiumAllocation_WS.Cells["R2"].Value = "Date Report Generated: " + DateTime.Now.ToShortDateString();
        PremiumAllocation_WS.Cells["R2"].Style.Font.Bold = true;
        PremiumAllocation_WS.Cells["R2:T2"].Merge = true;

        PremiumAllocation_WS.Cells["A4"].Value = "Region";
        PremiumAllocation_WS.Cells["B4"].Value = "Market";
        PremiumAllocation_WS.Cells["C4"].Value = "Location Code";
        PremiumAllocation_WS.Cells["D4"].Value = "Location Name";
        PremiumAllocation_WS.Cells["E4"].Value = "Non-Texas Payroll";
        PremiumAllocation_WS.Cells["F4"].Value = "Texas Payroll";
        PremiumAllocation_WS.Cells["G4"].Value = "Total Payroll";
        PremiumAllocation_WS.Cells["H4"].Value = "Total Headcount";
        PremiumAllocation_WS.Cells["I4"].Value = "Property Values";

        PremiumAllocation_WS.Cells["J4"].Value = "WC Premium";
        PremiumAllocation_WS.Cells["K4"].Value = "Garage Liability Premium";
        PremiumAllocation_WS.Cells["L4"].Value = "Property Premium";
        PremiumAllocation_WS.Cells["M4"].Value = "Earthquake Premium";
        PremiumAllocation_WS.Cells["N4"].Value = "Crime Premium";
        PremiumAllocation_WS.Cells["O4"].Value = " Excess Umbrella Premium";
        PremiumAllocation_WS.Cells["P4"].Value = " EPLI Premium";
        PremiumAllocation_WS.Cells["Q4"].Value = " Cyber Premium";
        PremiumAllocation_WS.Cells["R4"].Value = " Pollution Premium";
        PremiumAllocation_WS.Cells["S4"].Value = " Risk Management Fee";
        PremiumAllocation_WS.Cells["T4"].Value = " Total";
        #endregion

        int? year = null;

        if (txtYear.Text != string.Empty) year = Convert.ToInt32(txtYear.Text);

        DataSet dsReport = clsPA_Screen_Fields.Generate_PremiumAllocation_Annual_Report_New(year);
        dsReport.Tables[0].DefaultView.RowFilter = "dba <> 'Total'";
        DataTable dtReport = dsReport.Tables[0].DefaultView.ToTable();

        for (int iCurrRow = 0; iCurrRow < dtReport.Rows.Count; iCurrRow++)
        {

            PremiumAllocation_WS.Cells["A" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Region"];
            PremiumAllocation_WS.Cells["B" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Market"];
            PremiumAllocation_WS.Cells["C" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Sonic_Location_Code"];
            PremiumAllocation_WS.Cells["D" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["dba"];
            PremiumAllocation_WS.Cells["E" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Non_Texas_Payroll"];
            PremiumAllocation_WS.Cells["F" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Texas_Payroll"];
            PremiumAllocation_WS.Cells["G" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Total_Payroll"];
            PremiumAllocation_WS.Cells["H" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Total_Headcount"];
            PremiumAllocation_WS.Cells["I" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Property_Total_Insurables"];

            PremiumAllocation_WS.Cells["J" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["WC_Annual"];
            PremiumAllocation_WS.Cells["K" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Garage_Annual"];
            PremiumAllocation_WS.Cells["L" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Property_Annual"];
            PremiumAllocation_WS.Cells["M" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Earthquake_Annual"];
            PremiumAllocation_WS.Cells["N" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Crime_Annual"];
            PremiumAllocation_WS.Cells["O" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Excess_Umbrella_Annual"];
            PremiumAllocation_WS.Cells["P" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["EPL_Annual"];
            PremiumAllocation_WS.Cells["Q" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Cyber_Annual"];
            PremiumAllocation_WS.Cells["R" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Pollution_Annual"];
            PremiumAllocation_WS.Cells["S" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Risk_Annual"];
            PremiumAllocation_WS.Cells["T" + (iCurrRow + 5)].Value = dtReport.Rows[iCurrRow]["Total"];
        }

        DataRow[] drRecords1 = dsReport.Tables[0].Select("dba = 'Total'");
        if (drRecords1 != null && drRecords1.Length > 0)
        {
            PremiumAllocation_WS.Cells["A" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Region"];
            PremiumAllocation_WS.Cells["B" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Market"];
            PremiumAllocation_WS.Cells["C" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Sonic_Location_Code"];
            PremiumAllocation_WS.Cells["D" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["dba"];
            PremiumAllocation_WS.Cells["E" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Non_Texas_Payroll"];
            PremiumAllocation_WS.Cells["F" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Texas_Payroll"];
            PremiumAllocation_WS.Cells["G" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Total_Payroll"];
            PremiumAllocation_WS.Cells["H" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Total_Headcount"];
            PremiumAllocation_WS.Cells["I" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Property_Total_Insurables"];

            PremiumAllocation_WS.Cells["J" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["WC_Annual"];
            PremiumAllocation_WS.Cells["K" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Garage_Annual"];
            PremiumAllocation_WS.Cells["L" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Property_Annual"];
            PremiumAllocation_WS.Cells["M" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Earthquake_Annual"];
            PremiumAllocation_WS.Cells["N" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Crime_Annual"];
            PremiumAllocation_WS.Cells["O" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Excess_Umbrella_Annual"];
            PremiumAllocation_WS.Cells["P" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["EPL_Annual"];
            PremiumAllocation_WS.Cells["Q" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Cyber_Annual"];
            PremiumAllocation_WS.Cells["R" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Pollution_Annual"];
            PremiumAllocation_WS.Cells["S" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Risk_Annual"];
            PremiumAllocation_WS.Cells["T" + (dtReport.Rows.Count + 5)].Value = drRecords1[0]["Total"];
        }

        #region set style
        PremiumAllocation_WS.Column(1).Width = (double)12.7;
        PremiumAllocation_WS.Column(2).Width = (double)12.7;
        PremiumAllocation_WS.Column(3).Width = (double)12.7;
        //PremiumAllocation_WS.Column(4).Width = (double)25;
        PremiumAllocation_WS.Column(4).AutoFit();
        PremiumAllocation_WS.Column(5).Width = (double)12.7;
        PremiumAllocation_WS.Column(6).Width = (double)12.7;
        PremiumAllocation_WS.Column(7).Width = (double)12.7;
        PremiumAllocation_WS.Column(8).Width = (double)12.7;
        PremiumAllocation_WS.Column(9).Width = (double)12.7;
        PremiumAllocation_WS.Column(10).Width = (double)12.7;
        PremiumAllocation_WS.Column(11).Width = (double)12.7;
        PremiumAllocation_WS.Column(12).Width = (double)12.7;
        PremiumAllocation_WS.Column(13).Width = (double)12.7;
        PremiumAllocation_WS.Column(14).Width = (double)12.7;
        PremiumAllocation_WS.Column(15).Width = (double)12.7;
        PremiumAllocation_WS.Column(16).Width = (double)12.7;
        PremiumAllocation_WS.Column(17).Width = (double)12.7;
        PremiumAllocation_WS.Column(18).Width = (double)12.7;
        PremiumAllocation_WS.Column(19).Width = (double)12.7;
        PremiumAllocation_WS.Column(20).Width = (double)12.7;


        using (ExcelRange range = PremiumAllocation_WS.Cells[4, 1, 4 + dtReport.Rows.Count, 20])
        {
            range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            Border border = range.Style.Border;
            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

        }

        using (ExcelRange range = PremiumAllocation_WS.Cells[4, 5, 4 + dtReport.Rows.Count + 1, 7])
        {
            range.Style.Numberformat.Format = "$ #,##0";
        }

        using (ExcelRange range = PremiumAllocation_WS.Cells[4, 9, 4 + dtReport.Rows.Count + 1, 20])
        {
            range.Style.Numberformat.Format = "$ #,##0";
        }

        using (ExcelRange range = PremiumAllocation_WS.Cells[dtReport.Rows.Count + 5, 4, dtReport.Rows.Count + 5, 20])
        {
            //range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            range.Style.Font.Italic = true;
            range.Style.Font.Bold = true;
            Border border = range.Style.Border;
            border.Bottom.Style = ExcelBorderStyle.Double;

        }
        #endregion
        //PremiumAllocation_WS.Cells.AutoFitColumns();

        

        string strDir = string.Format(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"temp\Premium_Allocation");
        string strfile = string.Empty;

        if (!Directory.Exists(strDir))
            Directory.CreateDirectory(strDir);

        strfile = string.Format(strDir + "\\Annual Report.xlsx");

        System.IO.FileInfo file = new System.IO.FileInfo(strfile);

        Byte[] bin = PremiumAllocation.GetAsByteArray();
        File.WriteAllBytes(strfile, bin);

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("Content-Type", "binary/octet-stream");
        HttpContext.Current.Response.AddHeader("Content-Disposition", ("attachment; filename=Annual Report.xlsx; size=") + file.Length.ToString());
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.WriteFile(file.FullName);
        HttpContext.Current.Response.Flush();
        System.IO.File.Delete(strfile);
        HttpContext.Current.Response.End();

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

        if (txtYear.Text != string.Empty) year = Convert.ToInt32(txtYear.Text);

        DataSet dsReport = clsPA_Screen_Fields.Generate_PremiumAllocation_Annual_Report_New(year);
        dsReport.Tables[0].DefaultView.RowFilter = "dba <> 'Total'";
        DataTable dtReport = dsReport.Tables[0].DefaultView.ToTable();

        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
        trCriteria.Visible = false;
        tblReport.Visible = true;
        lbtExportToExcel.Visible = dtReport.Rows.Count > 0;
        btnBack.Visible = true;

        int intColspan = dtReport.Columns.Count;

        // Check if record found or not.
        if (dtReport.Rows.Count > 0)
        {
            sbRecorords.Append("<style type='text/css'></style><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td class='cols_' >");
            //sbRecorords.Append("<div style='overflow: hidden; width: 995px;'>");
            sbRecorords.Append("<div style='overflow-x: scroll;overflow-y:hidden; width: 994px; height: 100%;'>");
            sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='3120px'>");//Sub Table
            sbRecorords.Append("<tr style='height:25'><td>&nbsp;</td></tr>"); //blank row
            sbRecorords.Append("<tr style='font-weight: bold;font-size:12pt;height:25'>"); //Title
            sbRecorords.Append("<td align='left' style='font-size:9pt;' colspan='2'><b>INSURANCE PREMIUM ANNUAL REPORT</b></td>");
            sbRecorords.Append("<td align='center' style='font-size:9pt;' colspan='3' ><b> Year :" + txtYear.Text + " </b></td>");
            sbRecorords.Append("<td style='font-size:9pt' align='right' colspan='15'><b>Date Report Generated: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</b></td></tr>");
            sbRecorords.Append("<tr style='height:25'><td>&nbsp;</td></tr>"); //blank row
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td class='cols_' width='200px' align='left'><b>Region</b></td>");
            sbRecorords.Append("<td class='cols_' width='200px' align='left'><b>Market</b></td>");
            sbRecorords.Append("<td class='cols_' width='200px' align='left'><b>Location Code</b></td>");
            sbRecorords.Append("<td class='cols_' width='250px' align='left'><b>Location Name</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Non-Texas Payroll</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Texas Payroll</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Total Payroll</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Total Headcount</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Property Values</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>WC Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Garage Liability Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Property Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Earthquake Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='140px' align='right'><b>Crime Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Excess Umbrella Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='150px' align='right'><b>EPLI Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='180px' align='right'><b>Cyber Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Pollution Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Risk Management Fee</b></td>");
            sbRecorords.Append("<td class='cols_' width='180px' align='right'><b>TOTAL</b></td>");
            sbRecorords.Append("</tr>");


            for (int i = 0; i < dtReport.Rows.Count; i++)
            {
                int intRes;
                int intDiv = System.Math.DivRem(i, 2, out intRes);
                if (intRes == 0)
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;font-family:Tahoma;'>");
                else
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;font-family:Tahoma;'>");

                DataRow drRecords = dtReport.Rows[i];

                if (Convert.ToString(drRecords["dba"]) != "Total")
                {
                    sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["Region"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["Market"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["Sonic_Location_Code"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["dba"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Non_Texas_Payroll"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Texas_Payroll"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Total_PayRoll"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Total_Headcount"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Property_Total_Insurables"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["WC_Annual"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Garage_Annual"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Property_Annual"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N0}", drRecords["Earthquake_Annual"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Crime_Annual"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Excess_Umbrella_Annual"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["EPL_Annual"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Cyber_Annual"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Pollution_Annual"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Risk_Annual"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Total"]) + "</td>");
                }




            }

            DataRow[] drRecords1 = dsReport.Tables[0].Select("dba = 'Total'");
            sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
            if (drRecords1 != null && drRecords1.Length > 0)
            {
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords1[0]["Region"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords1[0]["Market"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords1[0]["Sonic_Location_Code"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'><B>" + Convert.ToString(drRecords1[0]["dba"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords1[0]["Non_Texas_Payroll"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords1[0]["Texas_Payroll"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords1[0]["Total_PayRoll"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords1[0]["Total_Headcount"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords1[0]["Property_Total_Insurables"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords1[0]["WC_Annual"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords1[0]["Garage_Annual"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords1[0]["Property_Annual"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N0}", drRecords1[0]["Earthquake_Annual"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords1[0]["Crime_Annual"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords1[0]["Excess_Umbrella_Annual"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords1[0]["EPL_Annual"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords1[0]["Cyber_Annual"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords1[0]["Pollution_Annual"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords1[0]["Risk_Annual"]) + "</B></td>");
                sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords1[0]["Total"]) + "</B></td>");
            }
            sbRecorords.Append("</tr>");
            sbRecorords.Append("</table>");
            sbRecorords.Append("</div>");
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