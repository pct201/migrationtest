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
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

    /// <summary>
    /// Back from report to Criteria
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

    private System.Text.StringBuilder GenerateVOCReport()
    {
        int startYear, endYear, startMonth, endMonth,countSelected;
        // decimal location = Convert.ToDecimal(lstLocation.SelectedValue);
        startYear = Convert.ToDateTime(txtStartDate.Text).Year;
        endYear = Convert.ToDateTime(txtEndDate.Text).Year;
        startMonth = Convert.ToDateTime(txtStartDate.Text).Month;
        endMonth = Convert.ToDateTime(txtEndDate.Text).Month;
        countSelected = 0;

        string strlocation = string.Empty;
        string strLocationFilter = string.Empty;

        // get selected location
        foreach (ListItem li in lstLocation.Items)
        {
            if (li.Selected)
            { 
                strlocation = strlocation + "" + li.Value + ",";
                strLocationFilter = strLocationFilter + " " + li.Text + ",";
                countSelected++;
            }
        }
        strlocation = strlocation.TrimEnd(',');
        strLocationFilter = strLocationFilter.TrimEnd(',');

        Convert.ToDecimal(lstLocation.SelectedValue);

        if(lstLocation.Items.Count == countSelected)
        {
            strLocationFilter = "All Locations";
        }

        DataSet dsReport = clsNewUserApprovedDeniedReport.GetVOCReport(startYear, endYear, startMonth, endMonth, strlocation);

        // get data tables from dataset
        DataTable dtCategory = dsReport.Tables[0];
        DataTable dtRegions = dsReport.Tables[1];
        DataTable dtGrand_Total = dsReport.Tables[2];
        DataTable dtYearData = dsReport.Tables[3];
        DataTable dtYearAllCategory = dsReport.Tables[4];

        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");

        lbtExportToExcel.Visible = dtRegions.Rows.Count > 0;

        if (dtCategory != null && dtCategory.Rows.Count > 0)
        {
            sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>");
            sbRecorords.Append("<td align='left' style='font-size:9pt'  colspan='5'>VOC Report: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td colspan='5'></td>");
            sbRecorords.Append("</tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='5'><b> Filter Conditions :  </b></td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='5'><b>Start Date: </b>" + txtStartDate.Text + "</td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='5'><b>End Date: </b>" + txtEndDate.Text + "</td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='5'><b>Locations: </b>" + strLocationFilter + "</td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='5'><b> Report Columns :  </b></td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td class='cols_' width='12.5%'>Product Part Number</td>");
            sbRecorords.Append("<td class='cols_' width='12.5%'>Unit Volume</td>");
            sbRecorords.Append("<td class='cols_' width='12.5%'align='left'>Quantity Purchased</td>");
            sbRecorords.Append("<td class='cols_' width='12.5%'align='left'>Gallons</td>");
            sbRecorords.Append("<td class='cols_' width='12.5%'align='left'>VOC total</td>");
            sbRecorords.Append("</tr>");

            //now category 
            foreach (DataRow drCategory in dtCategory.Rows)
            {
                string category = Convert.ToString(drCategory["Category"]);
               
                DataRow[] drVOCEmissions = dtRegions.Select("Category = '" + category + "'");
                this.FillVocReportRows(sbRecorords, category, drVOCEmissions, false);

                DataRow[] drYearVOCEmissions = dtYearData.Select("Category = '" + category + "'");

                if (drYearVOCEmissions != null && drYearVOCEmissions.Length > 0)
                {
                    int intRes = 0;
                    foreach (DataRow drYearVOCEmission in drYearVOCEmissions)
                    {
                        intRes += 1;
                        if (intRes % 2 == 0)
                            sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                        else
                            sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>");

                        sbRecorords.Append("<td  class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drYearVOCEmission["Part_Number"]) + "</td>");
                        sbRecorords.Append("<td class='cols_' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drYearVOCEmission["Unit"]) + "</td>");
                        sbRecorords.Append("<td class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drYearVOCEmission["Quantity"]) + "</td>");
                        sbRecorords.Append("<td class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drYearVOCEmission["Gallons"]) + "</td>");
                        sbRecorords.Append("<td class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drYearVOCEmission["VOC_Emissions"]) + "</td>");
                        sbRecorords.Append("</tr>");
                    }
                }
            }

            if (dtYearAllCategory != null && dtYearAllCategory.Rows.Count > 0)
            {
                DataRow[] drAllCategoryRows = dtYearAllCategory.Select();
                this.FillVocReportRows(sbRecorords, "All Paint Categories", drAllCategoryRows, true);
            }

            //add grand by category
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:blue;color:White;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='3'> Grand Totals :</td>");
            sbRecorords.Append("<td align='left' style='font-size:9pt' ><b>" + string.Format("{0:N2}", dtGrand_Total.Rows[0]["Total_Gallons"]) + " </b></td>");
            sbRecorords.Append("<td align='left' style='font-size:9pt' ><b>" + string.Format("{0:N2}", dtGrand_Total.Rows[0]["VOC_Emissions"]) + " </b></td></tr>");

            sbRecorords.Append("</table>");
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

    private void BindDropdowns()
    {
        //ComboHelper.FillLocationDBA_All( new DropDownList[] { ddlLocation }, 0, true);
        //ComboHelper.FillLocationDBA_All(new ListBox[] { lstLocation }, 0, false);
        ComboHelper.Fill_VOC_Location(new ListBox[] { lstLocation }, 0, false);
    }

    
    private void FillVocReportRows(StringBuilder sbRecorords, string category, DataRow[] drVOCEmissions, bool isAllCategories)
    {
        decimal totalGallons = 0, totalVOC_Emissions = 0;
        string SubTotalText = string.Empty;

        if (drVOCEmissions != null && drVOCEmissions.Length > 0)
        {
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:white; color:#ff9c09;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='5'><b>Category : " + category + "</b></td></tr>");  
            int intRes = 0;
            foreach (DataRow drVOCEmission in drVOCEmissions)
            {
                totalGallons += clsGeneral.GetDecimal(drVOCEmission["Gallons"]);
                totalVOC_Emissions += clsGeneral.GetDecimal(drVOCEmission["VOC_Emissions"]);
                SubTotalText = Convert.ToString(drVOCEmission["Subtotal_Text"]);

                intRes += 1;
                if (intRes % 2 == 0)
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                else
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>");

                sbRecorords.Append("<td  class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drVOCEmission["Part_Number"]) + "</td>");
                sbRecorords.Append("<td class='cols_' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drVOCEmission["Unit"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drVOCEmission["Quantity"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drVOCEmission["Gallons"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drVOCEmission["VOC_Emissions"]) + "</td>");
                sbRecorords.Append("</tr>");
            }

            if (!isAllCategories)
            {
                //add subtotal by category
                sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:yellow;color:black;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='3'>Sub Total For " + category + " : </td>");
                sbRecorords.Append("<td align='left' style='font-size:9pt' ><b>" + string.Format("{0:N2}", totalGallons) + " </b></td>");
                sbRecorords.Append("<td align='left' style='font-size:9pt' ><b>" + string.Format("{0:N2}", totalVOC_Emissions) + " </b></td></tr>");
            }
        }
    }


    #endregion
}