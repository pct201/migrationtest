using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using FusionCharts;

public partial class UserAccessRequest_rptVOCEmissions : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDropdowns();
        }
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstLocation });
    }

    #region "Controls Events"

    /// <summary>
    /// Handles Show Report button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        trCriteria.Visible = false;
        tblReport.Visible = true;
        btnBack.Visible = true;
        //BindVOCGrid();
        lblReport.Text = GenerateVOCReport().ToString();
    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        txtStartDate.Text = string.Empty;
        txtEndDate.Text = string.Empty;
        lstLocation.ClearSelection();
    }

    protected void btnReload_Click(object sender, EventArgs e)
    {
        int startYear, endYear, startMonth, endMonth;
        string strlocation = string.Empty;

        // get selected location
        foreach (ListItem li in lstLocation.Items)
        {
            if (li.Selected)
                strlocation = strlocation + "" + li.Value + ",";
        }
        strlocation = strlocation.TrimEnd(',');

        Convert.ToDecimal(lstLocation.SelectedValue);
        startYear = Convert.ToDateTime(txtStartDate.Text).Year;
        endYear = Convert.ToDateTime(txtEndDate.Text).Year;
        startMonth = Convert.ToDateTime(txtStartDate.Text).Month;
        endMonth = Convert.ToDateTime(txtEndDate.Text).Month;

        DataSet dsReport = clsPM_Permits_VOC_Emissions.GetVOCGraphReport(startYear, endYear, startMonth, endMonth, strlocation);

        string xml = this.GenerateVOCGraphReport(dsReport, startYear, endYear, true).ToString();

        string strDir = AppConfig.SitePath + @"temp\";
        if (!Directory.Exists(strDir))
        {
            Directory.CreateDirectory(strDir);
        }
        string imageName = "../temp/VOCEmissionGraph.png";
        ServerSideImageHandler ssh = new ServerSideImageHandler(Server.MapPath("../FusionCharts/MSColumn2D.swf"), 867, 300, xml, string.Empty, Server.MapPath(imageName));
        ssh.BeginCapture();

        iTextSharp.text.Rectangle pgSize;
        string strPdfpath = Server.MapPath("../temp/VOCEmissionGraph.pdf");
        pgSize = new iTextSharp.text.Rectangle(867, 300);
        iTextSharp.text.Document doc = new iTextSharp.text.Document(pgSize, 0, 0, 0, 0);
        iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(strPdfpath, FileMode.Create));

        doc.Open();
        string imagepath = Server.MapPath("../temp/VOCEmissionGraph.png");
        try
        {
            iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(imagepath);
            //Resize image depend upon your need
            gif.ScaleToFit(867, 300);
            gif.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            doc.Add(gif);
        }
        catch (iTextSharp.text.DocumentException dex)
        {
            Response.Write(dex.Message);
        }
        catch (IOException ioex)
        {
            Response.Write(ioex.Message);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        doc.Close();

        string[] strFusionChart = new string[1]; ;
        strFusionChart[0] = strDir + "VOCEmissionGraph.pdf";

        clsGeneral.SendMailMessage(AppConfig.MailFrom,hdnto.Value , string.Empty, string.Empty, hdnSubject.Value, hdnBody.Value, true, strFusionChart);

        if (File.Exists(strDir + "VOCEmissionGraph.pdf"))
            File.Delete(strDir + "VOCEmissionGraph.pdf");
        if (File.Exists(strDir + "VOCEmissionGraph.png"))
            File.Delete(strDir + "VOCEmissionGraph.png");

        ClientScript.RegisterStartupScript(typeof(string), "keyclosewindow", "CloseMailPopup();", true);

    }

    /// <summary>
    /// Handles Send VOC Graph button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShow_VOC_Graph_Click(object sender, EventArgs e)
    {

        tblGraph.Visible = true;
        trCriteria.Visible = false;

        int startYear, endYear, startMonth, endMonth;
        string strlocation = string.Empty;

        // get selected location
        foreach (ListItem li in lstLocation.Items)
        {
            if (li.Selected)
                strlocation = strlocation + "" + li.Value + ",";
        }
        strlocation = strlocation.TrimEnd(',');

        Convert.ToDecimal(lstLocation.SelectedValue);
        startYear = Convert.ToDateTime(txtStartDate.Text).Year;
        endYear = Convert.ToDateTime(txtEndDate.Text).Year;
        startMonth = Convert.ToDateTime(txtStartDate.Text).Month;
        endMonth = Convert.ToDateTime(txtEndDate.Text).Month;

        DataSet dsReport = clsPM_Permits_VOC_Emissions.GetVOCGraphReport(startYear, endYear, startMonth, endMonth, strlocation);
        string xml;
        if(dsReport.Tables[1].Rows.Count > 0)
            xml = this.GenerateVOCGraphReport(dsReport,startYear, endYear,false).ToString();
        else
        {
            divchart1.InnerHtml = "<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>"+
                                    "<tr style='background-color:#F2F2F2;color:Black;'>"+
                                    "<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>";
            lnkExportToPDF.Visible = lnkSendMail.Visible= false;
        }
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
        HTML2Excel objHtml2Excel = new HTML2Excel(lblReport.Text);
        string strPath = AppConfig.SitePath + @"temp\";
        string fileName = "VOCEmisson.xlsx";
        string outputFiles = Path.GetFullPath(strPath + fileName);
        bool blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);
        if ((blnHTML2Excel==true) && File.Exists(outputFiles))
        {
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                HttpContext.Current.Response.TransmitFile(outputFiles);
                HttpContext.Current.Response.Flush();
            }
            finally
            {
                if (File.Exists(outputFiles))
                    File.Delete(outputFiles);
                HttpContext.Current.Response.End();
            }
        }

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
        //HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "VOC Report.xls"));
        //HttpContext.Current.Response.ContentType = "application/ms-excel";
        //HttpContext.Current.Response.Write(stringWrite.ToString().Replace("#EAEAEA", "White").Replace("#eaeaea", "White").Replace("background-color:#C0C0C0", "background-color:White;").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>").Replace("background-color:#7f7f7f;color:White", "background-color:White;color:Black"));
        //HttpContext.Current.Response.End();
    }

    protected void lnkExportToPDF_Click(object sender, EventArgs e)
    {
        int startYear, endYear, startMonth, endMonth;
        string strlocation = string.Empty;

        // get selected location
        foreach (ListItem li in lstLocation.Items)
        {
            if (li.Selected)
                strlocation = strlocation + "" + li.Value + ",";
        }
        strlocation = strlocation.TrimEnd(',');

        Convert.ToDecimal(lstLocation.SelectedValue);
        startYear = Convert.ToDateTime(txtStartDate.Text).Year;
        endYear = Convert.ToDateTime(txtEndDate.Text).Year;
        startMonth = Convert.ToDateTime(txtStartDate.Text).Month;
        endMonth = Convert.ToDateTime(txtEndDate.Text).Month;

        DataSet dsReport = clsPM_Permits_VOC_Emissions.GetVOCGraphReport(startYear, endYear, startMonth, endMonth, strlocation);

        string xml = this.GenerateVOCGraphReport(dsReport,startYear, endYear, true).ToString();

        string strDir = AppConfig.SitePath + @"temp\";
        if (!Directory.Exists(strDir))
        {
            Directory.CreateDirectory(strDir);
        }
        string imageName = "../temp/VOCEmissionGraph.png";
        ServerSideImageHandler ssh = new ServerSideImageHandler(Server.MapPath("../FusionCharts/MSColumn2D.swf"), 867, 300, xml, string.Empty, Server.MapPath(imageName));
        ssh.BeginCapture();

        iTextSharp.text.Rectangle pgSize;
        string strPdfpath = Server.MapPath("../temp/VOCEmissionGraph.pdf");
        pgSize = new iTextSharp.text.Rectangle(867, 300);
        iTextSharp.text.Document doc = new iTextSharp.text.Document(pgSize, 0, 0, 0, 0);
        iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(strPdfpath, FileMode.Create));

        doc.Open();
        string imagepath = Server.MapPath("../temp/VOCEmissionGraph.png");
        try
        {
            iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(imagepath);
            //Resize image depend upon your need
            gif.ScaleToFit(867, 300);
            gif.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            doc.Add(gif);
        }
        catch (iTextSharp.text.DocumentException dex)
        {
            Response.Write(dex.Message);
        }
        catch (IOException ioex)
        {
            Response.Write(ioex.Message);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        doc.Close();

        HttpContext context = HttpContext.Current;
        context.Response.Clear();
        context.Response.AppendHeader("Content-Type", "application/pdf");
        context.Response.AppendHeader("Content-disposition", "attachment; filename=" + "VOCEmissionGraph.pdf");
        context.Response.WriteFile("../temp/VOCEmissionGraph.pdf");
        context.Response.Flush();
        if (File.Exists(strDir + "VOCEmissionGraph.pdf"))
            File.Delete(strDir + "VOCEmissionGraph.pdf");
        if (File.Exists(strDir + "VOCEmissionGraph.png"))
            File.Delete(strDir + "VOCEmissionGraph.png");

        context.Response.End();
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
        //lblHeading.Text = "New User Approved/Denied Report";
    }

    /// <summary>
    /// Back from report to Criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBackGraph_Click(object sender, EventArgs e)
    {
        trCriteria.Visible = true;
        tblGraph.Visible = false;
        //lblHeading.Text = "New User Approved/Denied Report";
    }
    
    #endregion

    #region Methods

    /// <summary>
    /// Bind VOC Grid
    /// </summary>
    //public void BindVOCGrid()
    //{
    //    DataSet dsVOCEmmission = clsPM_Permits_VOC_Emissions.SelectByFKPermit(PK_PM_Permits, CurrentMonth, CurrentYear);
    //    DataTable dtVOCEmission = dsVOCEmmission.Tables[0];
    //    DataTable dtCategoryGrandTotal = dsVOCEmmission.Tables[1];
    //    DataTable dtGrandTotal = dsVOCEmmission.Tables[2];
    //    DataTable dtVOC = dtVOCEmission.Clone();
    //    DataTable dtCategory = clsLU_VOC_Category.SelectAll().Tables[0];

    //    if (dtCategory != null && dtCategory.Rows.Count > 0)
    //    {
    //        foreach (DataRow drCategory in dtCategory.Rows)
    //        {
    //            string category = Convert.ToString(drCategory["Category"]);
    //            DataRow[] drVOCEmissions = dtVOCEmission.Select("Category = '" + category + "'");
    //            decimal totalGallons = 0, totalVOC_Emissions = 0;
    //            string SubTotalText = string.Empty;

    //            if (drVOCEmissions != null && drVOCEmissions.Length > 0)
    //            {
    //                foreach (DataRow drVOCEmission in drVOCEmissions)
    //                {
    //                    totalGallons += clsGeneral.GetDecimal(drVOCEmission["Gallons"]);
    //                    totalVOC_Emissions += clsGeneral.GetDecimal(drVOCEmission["VOC_Emissions"]);
    //                    SubTotalText = Convert.ToString(drVOCEmission["Subtotal_Text"]);
    //                    dtVOC.Rows.Add(drVOCEmission.ItemArray);
    //                }

    //                // dtVOC.Rows.Add("0", "0", category + " Sub Total", CurrentYear, GetMonthString(CurrentMonth), totalGallons, totalVOC_Emissions, SubTotalText, totalGallons + totalVOC_Emissions, 0);
    //                dtVOC.Rows.Add("0", "0", category + " Sub Total", CurrentYear, GetMonthString(CurrentMonth), totalGallons, totalVOC_Emissions, SubTotalText, "", 0);

    //                if (dtCategoryGrandTotal != null && dtCategoryGrandTotal.Rows.Count > 0)
    //                {
    //                    DataRow[] drCategoryGrandTotal = dtCategoryGrandTotal.Select("Category = '" + category + "'");
    //                    dtVOC.Rows.Add("0", "0", category + " Grand Total", CurrentYear, "", clsGeneral.GetDecimal(drCategoryGrandTotal[0]["Gallons"]), clsGeneral.GetDecimal(drCategoryGrandTotal[0]["VOC_Emmisions"]), "", "", 0);
    //                }
    //            }
    //        }

    //        if (dtVOCEmission != null && dtVOCEmission.Rows.Count > 0)
    //        {
    //            dtVOC.Rows.Add("0", "0", " Grand Total", CurrentYear, "", clsGeneral.GetDecimal(dtGrandTotal.Rows[0]["Gallons"]), clsGeneral.GetDecimal(dtGrandTotal.Rows[0]["VOC_Emmisions"]), "", "", 0);
    //        }
    //    }

    //    gvVOCEmission.DataSource = dtVOC;

    //    if (dtVOCEmission == null || dtVOCEmission.Rows.Count <= 0)
    //        //Assign text when no record found
    //        gvVOCEmission.EmptyDataText = "No Other VOC Records Found for Month&nbsp;" + GetMonthString(CurrentMonth) + " and Year " + CurrentYear;

    //    gvVOCEmission.DataBind();

    //}

    private System.Text.StringBuilder GenerateVOCReport()
    {
        int startYear, endYear, startMonth, endMonth;
        decimal location = Convert.ToDecimal(lstLocation.SelectedValue);
        startYear = Convert.ToDateTime(txtStartDate.Text).Year;
        endYear = Convert.ToDateTime(txtEndDate.Text).Year;
        startMonth = Convert.ToDateTime(txtStartDate.Text).Month;
        endMonth = Convert.ToDateTime(txtEndDate.Text).Month;
        
        DataSet dsReport = clsNewUserApprovedDeniedReport.GetVOCReport(startYear, endYear, startMonth, endMonth, location);

        // get data tables from dataset
        DataTable dtCategory = dsReport.Tables[0];
        DataTable dtRegions = dsReport.Tables[1];
        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
        
        lbtExportToExcel.Visible = dtRegions.Rows.Count > 0;
        
        // Check if record found or not.
        if (dtRegions.Rows.Count > 0)
        {
            //sbRecorords.Append("<style type='text/css'></style><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td class='cols_' >");
            sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>");
            sbRecorords.Append("<td align='left' style='font-size:9pt'  colspan='5'>VOC Report: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td colspan='5'></td>");
            sbRecorords.Append("</tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='5'><b> Filter Conditions :  </b></td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='5'><b>Start Date: </b>" + txtStartDate.Text + "</td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='5'><b>End Date: </b>" + txtEndDate.Text + "</td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='5'><b> Report Columns :  </b></td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td class='cols_' width='12.5%'>Product Part Number</td>");
            sbRecorords.Append("<td class='cols_' width='12.5%'>Unit Volume</td>");
            sbRecorords.Append("<td class='cols_' width='12.5%'align='left'>Quantity Purchased</td>");
            sbRecorords.Append("<td class='cols_' width='12.5%'align='left'>Gallons</td>");
            sbRecorords.Append("<td class='cols_' width='12.5%'align='left'>VOC total</td>");
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

                sbRecorords.Append("<td  class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drRecords["Part_Number"]) + "</td>");
                sbRecorords.Append("<td class='cols_' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drRecords["Unit"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drRecords["Quantity"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drRecords["Gallons"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drRecords["VOC_Emissions"]) + "</td>");
                sbRecorords.Append("</tr>");
            }
            sbRecorords.Append("</table>");
            //sbRecorords.Append("</table>");
            trGrid.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.            
            sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
            sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
            sbRecorords.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
        }
        return sbRecorords;
    }

    private StringBuilder GenerateVOCGraphReport(DataSet ds,int startYear,int endYear, bool blnNumber)
    {
        StringBuilder strChartXML = new StringBuilder();

        strChartXML.Append("<chart caption='SAI Collision Center " + startYear.ToString() + "-" + endYear.ToString() + " VOC Emissions' xAxisName='Year-Month' yAxisName='Gallons' showValues='0' >");
        
        strChartXML.Append("<categories>");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            strChartXML.Append("<category label='" + ds.Tables[0].Rows[i]["dba"].ToString() + "' />");
        }
        strChartXML.Append("</categories>");

        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        {
            strChartXML.Append("<dataset seriesname='" + Convert.ToString(ds.Tables[1].Rows[i]["Year_Month"]) + "' >");//color='ff914c'

            DataView dv = new DataView(ds.Tables[2]);
            dv.RowFilter = "Year_Month = '" + Convert.ToString(ds.Tables[1].Rows[i]["Year_Month"])+"'";
            DataTable dt_Temp = dv.ToTable();
         
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                DataRow[] dr =  dt_Temp.Select("dba = '" + Convert.ToString(ds.Tables[0].Rows[j]["dba"]) +"'");
                if (dr.Length > 0)
                    strChartXML.Append("<set value='" + clsGeneral.GetDecimal(dr[0]["Total_Gallons"]).ToString() + "'  link='" + string.Empty + "' toolText='" + clsGeneral.GetDecimal(dr[0]["Total_Gallons"]).ToString() + "' />");
                else
                    strChartXML.Append("<set value='" + clsGeneral.GetDecimal(0).ToString() + "'  link='" + string.Empty + "' toolText='" + clsGeneral.GetDecimal(0).ToString() + "' />");
            }
            strChartXML.Append("</dataset>");
        }

        strChartXML.Append("</chart>");

        StringBuilder sbChart = new StringBuilder();
        sbChart.Append(InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/MSColumn2D.swf?ChartNoDataText=No data to display for: SAI Collision Center VOC Emissions", "", strChartXML.ToString(), "divchart1", "98%", "300", false, true));
        divchart1.InnerHtml = sbChart.ToString();//here in div we are display chart
        
        if (blnNumber)
            return strChartXML;
        else
            return sbChart;
    }

    private void BindDropdowns()
    {
        //ComboHelper.FillLocationDBA_All( new DropDownList[] { ddlLocation }, 0, true);
        ComboHelper.FillLocationDBA_All(new ListBox[] { lstLocation }, 0, false);
    }

    #endregion
}