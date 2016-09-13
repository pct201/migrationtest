using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using Winnovative.WnvHtmlConvert;
using System.Web.UI.HtmlControls;

public partial class SONIC_Sedgwick_rptActionPlansNotCompleted : clsBasePage
{
    #region "Page Events"
    /// <summary>
    /// Page load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindListControls();
            drpGroupBy1.Focus();
        }

    }

    #endregion
    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string strGUID
    {
        get { return Convert.ToString(ViewState["strGUID"]); }
        set { ViewState["strGUID"] = value; }
    }
    #region "Methods"

    /// <summary>
    /// Generate the Claim Financial Summary Report based on selected search criteria
    /// </summary>
    private StringBuilder Generatereport()
    {

        string strYear = string.Empty;
        string strSedgwick_Field_Office = string.Empty;
        string strQuarter = string.Empty;

        // get selected strSedgwick_Field_Office
        foreach (ListItem li in lstSedgwick_Field_Office.Items)
        {
            if (li.Selected)
                strSedgwick_Field_Office = strSedgwick_Field_Office + "'" + li.Value + "',";
        }
        strSedgwick_Field_Office = strSedgwick_Field_Office.TrimEnd(',');

        // get selected lstYear
        foreach (ListItem li in lstYear.Items)
        {
            if (li.Selected)
                strYear = strYear + "'" + li.Value + "',";
        }
        strYear = strYear.TrimEnd(',');

        // get selected lstQuarter
        //foreach (ListItem li in lstQuarter.Items)
        //{
        //    if (li.Selected)
        //        strQuarter = strQuarter + "'" + li.Value + "',";
        //}
        //strQuarter = strQuarter.TrimEnd(',');
        if (lstQuarter.SelectedValue != "0")
            strQuarter = lstQuarter.SelectedValue;

        string strSecondGroup = null;
        if (drpGroupBy2.SelectedIndex > 0)
            strSecondGroup = Convert.ToString(drpGroupBy2.SelectedItem.Value);


        strGUID = Guid.NewGuid().ToString();

        DataSet dsReport = Report.GetActionPlansNotCompletedReport(drpGroupBy1.SelectedValue, strSecondGroup, rdbSort1.SelectedValue, rdbSort2.SelectedValue, strSedgwick_Field_Office, strYear, strQuarter, txtLocation_Number.Text.Trim(), rblClaimReviewStatus.SelectedValue);

        StringBuilder sbRecorords = new StringBuilder("");

        sbRecorords.Append(GenerateFilterCriteria());

        //IF records found
        if (dsReport.Tables[0].Rows.Count > 0 && dsReport.Tables[1].Rows.Count > 0)
        {
            sbRecorords.Append("<style type='text/css'></style><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%'><tr><td class='cols_' >");//Main Table
            sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");//Sub Table

            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;height:25;font-size:11pt'>"); //Title
            sbRecorords.Append("<td>&nbsp;</td>");
            sbRecorords.Append("<td align='left' colspan='13'>&nbsp;</td></tr>");
            //sbRecorords.Append("<td style='font-size:9pt;' colspan='3' align='right'>Valued as of: " + clsGeneral.FormatDBNullDateToDisplay(txtPriorValuationDate.Text) + "</td></tr>");


            // Report Header Start
            sbRecorords.Append("<tr align='left' style='font-weight: bold;background-color:#7f7f7f;color:White;border:thin'>");
            sbRecorords.Append("<td class='cols_' width='10%'>Sedgwick Field Office </td>");
            sbRecorords.Append("<td class='cols_' width='5%'>Year </td>");
            sbRecorords.Append("<td class='cols_' width='2%'>Quarter </td>");
            sbRecorords.Append("<td class='cols_' width='10%'>Claim Number </td>");
            sbRecorords.Append("<td class='cols_' width='18%'>d/b/a </td>");
            sbRecorords.Append("<td class='cols_' width='5%'>Location Number </td>");
            sbRecorords.Append("<td class='cols_' width='10%'>Associate Name </td>");
            sbRecorords.Append("<td class='cols_' width='5%'>Date of Loss </td>");
            sbRecorords.Append("<td class='cols_' width='8%'>Claim Indicator </td>");
            sbRecorords.Append("<td class='cols_' width='2%'>Review Complete? </td>");
            sbRecorords.Append("<td class='cols_' width='10%'>Management Section </td>");
            sbRecorords.Append("<td class='cols_' width='5%'>RLCM/Sedgwick </td>");
            sbRecorords.Append("<td class='cols_' width='5%'>Action Item </td>");
            sbRecorords.Append("<td class='cols_' width='5%'>Target Date </td>");
            sbRecorords.Append("</tr>");
            // Report Header End

            #region "records"

            DataTable dtFirstGroupBy = dsReport.Tables[1];
            DataTable dtRecords = dsReport.Tables[0];
            DataTable dtSecondGroupBy = null;
            if (!string.IsNullOrEmpty(strSecondGroup))
                dtSecondGroupBy = dsReport.Tables[2];


            for (int intCount = 0; intCount < dtFirstGroupBy.Rows.Count; intCount++)
            {
                sbRecorords.Append("<tr style='background-color:'#EAEAEA';font-weight: bold; color: #FF9C09;font-size:8pt;border:thin'><td class='cols_'  style='color: #FF9C09;border:thin;font-weight: bold;font-size:9pt' border-top:#EAEAEA 1px solid; colspan='14'>" + Convert.ToString(drpGroupBy1.SelectedItem.Text) + " : " + Convert.ToString(dtFirstGroupBy.Rows[intCount]["FirstGroupBy"]) + "</td></tr>");

                string strFirstGroupBy = Convert.ToString(dtFirstGroupBy.Rows[intCount]["FirstGroupBy"]);
                strFirstGroupBy = strFirstGroupBy.Replace("'", "''");


                if (!string.IsNullOrEmpty(strSecondGroup))
                {
                    DataRow[] drRecordsSec = dtSecondGroupBy.Select(string.Format("FirstGroupBy = '{0}'", strFirstGroupBy));
                    for (int intI3 = 0; intI3 < drRecordsSec.Length; intI3++)
                    {
                        sbRecorords.Append("<tr style='border:thin'>");
                        sbRecorords.Append("<td colspan='14' style='background-color: #FFFFFF; font-weight: bold;border:thin' align='left'>" + Convert.ToString(drpGroupBy2.SelectedItem.Text) + " : " + Convert.ToString(drRecordsSec[intI3]["SecondGroupBy"]) + "</td>");
                        sbRecorords.Append("</tr>");
                        string strSecondGroupBy = Convert.ToString(drRecordsSec[intI3]["SecondGroupBy"]);
                        strSecondGroupBy = strSecondGroupBy.Replace("'", "''");
                        sbRecorords = GenerateReportRows(sbRecorords, dtRecords, strFirstGroupBy, strSecondGroupBy);
                    }
                }
                else
                {
                    sbRecorords = GenerateReportRows(sbRecorords, dtRecords, strFirstGroupBy, string.Empty);
                }

            }

            sbRecorords.Append("</table>");//Sub Table End
            sbRecorords.Append("</td></tr></table>");//Main Table End
            tr_Data.Visible = (sbRecorords.Length > 0);//Display record

            #endregion
        }
        else
        {
            ///When records are not found.
            sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
            sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;border:thin'>");
            sbRecorords.Append("<td align='center' style='font-size:9pt;'>No Record found.</td></tr></table>");
            tr_Data.Visible = false;
        }
        return sbRecorords;
    }

    /// <summary>
    /// Generates HTML text for report rows
    /// </summary>
    /// <param name="sbRecorords"></param>
    /// <param name="dtRecords"></param>
    /// <param name="strFirstGroupBy"></param>
    /// <param name="strSecondGroupBy"></param>
    /// <returns></returns>
    private StringBuilder GenerateReportRows(StringBuilder sbRecorords, DataTable dtRecords, string strFirstGroupBy, string strSecondGroupBy)
    {
        string strFilter = "";
        if (!string.IsNullOrEmpty(strSecondGroupBy))
            strFilter = string.Format("FirstGroupBy = '{0}' and  SecondGroupBy = '{1}' ", strFirstGroupBy, strSecondGroupBy);
        else
            strFilter = string.Format("FirstGroupBy = '{0}'", strFirstGroupBy);

        DataRow[] drRecords = dtRecords.Select(strFilter);

        if (drRecords.Length > 0)
        {
            for (int intI3 = 0; intI3 < drRecords.Length; intI3++)
            {
                int intRes;
                int intDiv = System.Math.DivRem(intI3, 2, out intRes);
                if (intRes == 0)
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;border:thin'>");
                else
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;border:thin'>");

                sbRecorords.Append("<td align='left' valign='Top' class='cols_' >" + Convert.ToString(drRecords[intI3]["Sedgwick_Field_Office"]) + "</td>");
                sbRecorords.Append("<td align='left' valign='Top' class='cols_' >" + Convert.ToString(drRecords[intI3]["Year"]) + "</td>");
                sbRecorords.Append("<td align='left' valign='Top' class='cols_' >" + Convert.ToString(drRecords[intI3]["Quarter"]) + "</td>");
                sbRecorords.Append("<td align='left' valign='Top' class='cols_' >" + Convert.ToString(drRecords[intI3]["claim_Number"]) + "</td>");
                sbRecorords.Append("<td align='left' valign='Top' class='cols_' >" + Convert.ToString(drRecords[intI3]["dba"]) + "</td>");
                sbRecorords.Append("<td align='left' valign='Top' class='cols_' >" + Convert.ToString(drRecords[intI3]["Location_Number"]) + "</td>");
                sbRecorords.Append("<td align='left' valign='Top' class='cols_' >" + Convert.ToString(drRecords[intI3]["Associate_Name"]) + "</td>");
                sbRecorords.Append("<td align='left' valign='Top' class='cols_' >" + clsGeneral.FormatDBNullDateToDisplay(drRecords[intI3]["Date_of_loss"]) + "</td>");
                sbRecorords.Append("<td align='left' valign='Top' class='cols_' >" + Convert.ToString(drRecords[intI3]["Claim_Indicator"]) + "</td>");
                sbRecorords.Append("<td align='left' valign='Top' class='cols_' >" + Convert.ToString(drRecords[intI3]["Review_Complete?"]) + "</td>");
                sbRecorords.Append("<td align='left' valign='Top' class='cols_' >" + Convert.ToString(drRecords[intI3]["Management_Section"]) + "</td>");
                sbRecorords.Append("<td align='left' valign='Top' class='cols_' >" + Convert.ToString(drRecords[intI3]["RLCM_Sedgwick"]) + "</td>");
                sbRecorords.Append("<td align='left' valign='Top' class='cols_' >" + Convert.ToString(drRecords[intI3]["Action_Item"]) + "</td>");
                sbRecorords.Append("<td align='left' valign='Top' class='cols_' >" + clsGeneral.FormatDBNullDateToDisplay(drRecords[intI3]["Target_Date"]) + "</td>");
                sbRecorords.Append("</tr>");

            }
        }

        return sbRecorords;
    }

    /// <summary>
    /// Bind Listbox and dropdownlist from Database 
    /// </summary>
    private void BindListControls()
    {
        ComboHelper.FillSedgwick_Claim_Office(new ListBox[] { lstSedgwick_Field_Office });
        ComboHelper.FillSedgwickYear(new ListBox[] { lstYear });
    }

    /// <summary>
    /// Generate Filter Criteria
    /// </summary>
    /// <returns></returns>
    private string GenerateFilterCriteria()
    {
        StringBuilder strExport = new StringBuilder();

        strExport.Append("<table style='font-size:8.5pt;font-family:Tahoma' width='99%'>");
        strExport.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
        strExport.Append("<tr>");
        strExport.Append("<td colspan='2'><b>Report Title :  Action Plans Not Completed Report</b></td>");
        strExport.Append("</tr>");
        strExport.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
        //strExport.Append("<tr><td width='35%'><b> First Group By : </b>" + clsGeneral.GetGroupByFilter(Convert.ToString(drpGroupBy1.SelectedValue)) + "</td> <td> <b>Sorting :</b> " + Convert.ToString(rdbSort1.SelectedItem.Text) + " </td></tr>");
        //strExport.Append("<tr><td ><b> Second Group By : </b>" + clsGeneral.GetGroupByFilter(Convert.ToString(drpGroupBy2.SelectedValue)) + "</td><td> <b>Sorting :</b> " + Convert.ToString(rdbSort2.SelectedItem.Text) + " </td></tr>");
        strExport.Append(GetClaimSummaryFiltersDetails());
        strExport.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
        strExport.Append("</table>");

        return strExport.ToString();
    }

    /// <summary>
    /// Get Claim Summary Filters
    /// </summary>
    /// <returns></returns>
    private string GetClaimSummaryFiltersDetails()
    {
        StringBuilder strWhere = new StringBuilder();

        return strWhere.ToString();
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Export Report Data to Excel spread sheet
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExportExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.ExportGrid("Action Plans Not Completed Report.xlsx", lblClaimRecords);
    }

    /// <summary>
    /// Exports Data into the PDF format
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExportPDF_Click(object sender, EventArgs e)
    {
        string strFileName = "Action Plans Not Completed Report.pdf";
        PdfConverter objPdf = new PdfConverter();
        objPdf.LicenseKey = AppConfig._strHtmltoPDFConverterKey;

        objPdf.PdfDocumentOptions.TopMargin = 20;
        objPdf.PdfDocumentOptions.LeftMargin = 20;
        objPdf.PdfDocumentOptions.RightMargin = 20;
        objPdf.PdfDocumentOptions.BottomMargin = 20;
        objPdf.PdfDocumentOptions.ShowHeader = false;
        objPdf.PdfDocumentOptions.ShowFooter = false;
        objPdf.PdfDocumentOptions.EmbedFonts = false;

        objPdf.PdfDocumentOptions.LiveUrlsEnabled = false;
        objPdf.RightToLeftEnabled = false;
        objPdf.PdfSecurityOptions.CanPrint = true;
        objPdf.PdfSecurityOptions.CanEditContent = true;
        objPdf.PdfSecurityOptions.UserPassword = "";
        objPdf.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Landscape;
        objPdf.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;

        objPdf.PdfDocumentInfo.AuthorName = "eRIMS2";
        Byte[] pdfByte = null;
        pdfByte = objPdf.GetPdfBytesFromHtmlString(lblClaimRecords.Text);
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("Content-Type", "binary/octet-stream");
        HttpContext.Current.Response.AddHeader("Content-Disposition", ("attachment; filename=" + strFileName + "; size=") + pdfByte.Length.ToString());
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.BinaryWrite(pdfByte);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }

    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        trResult.Visible = true;
        trReportHeader.Visible = false;
        trReportbalnk.Visible = false;
        trReportfilter.Visible = false;
        trReportbutton.Visible = false;
        trReportspace.Visible = false;
        lblClaimRecords.Text = Generatereport().ToString();
        lblClaimRecords.Visible = true;
        btnCancelExecution.Visible = true;
    }

    /// <summary>
    /// Event to Clear serach criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        rdbSort1.SelectedIndex = 0;
        rdbSort2.SelectedIndex = 0;
        lblClaimRecords.Text = "";
        drpGroupBy1.SelectedIndex = 0;
        drpGroupBy2.SelectedIndex = 0;
        lstQuarter.ClearSelection();
        lstYear.ClearSelection();
        lstSedgwick_Field_Office.ClearSelection();
        txtLocation_Number.Text = "";
        tr_Data.Visible = false;
        drpGroupBy1.Focus();

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        trResult.Visible = false;
        tr_Data.Visible = false;
        trReportHeader.Visible = true;
        trReportbalnk.Visible = true;
        trReportfilter.Visible = true;
        trReportbutton.Visible = true;
        trReportspace.Visible = true;
        rdbSort1.SelectedValue = rdbSort1.SelectedValue;
        btnCancelExecution.Visible = false;
        lblClaimRecords.Visible = false;
    }

    #endregion

}