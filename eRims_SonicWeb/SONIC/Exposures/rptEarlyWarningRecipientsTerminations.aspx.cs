using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class COIReports_rptEarlyWarningRecipientsTerminations : clsBasePage
{
    #region " Page Events "

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownList();
            trCriteria.Visible = true;
            tblReport.Visible = false;
        }
    } 
    #endregion

    #region " Control Events "

    /// <summary>
    /// Show report button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {

        trCriteria.Visible = false;
        tblReport.Visible = true;

        lblReport.Text = GenerateReport().ToString();
    }

    /// <summary>
    /// Clear all filter criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        lstRegion.ClearSelection();
        lstMarket.ClearSelection();
        lstLocation.ClearSelection();
        //ComboHelper.FillLocationdba(new ListBox[] { lstLocation }, 0, false);
    }

    /// <summary>
    /// Export Report click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        HTML2Excel objHtml2Excel = new HTML2Excel(lblReport.Text);
        string strPath = AppConfig.SitePath + @"temp\";
        string fileName = "Early_Alert_Recipients_Report.xlsx";
        string outputFiles = Path.GetFullPath(strPath + fileName);
        bool blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);
        if ((blnHTML2Excel == true) && File.Exists(outputFiles))
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
        //((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 1;
        //gvReport.GridLines = GridLines.Both;
        //gvReport.FooterRow.Visible = false;
        //foreach (GridViewRow gvRow in gvReport.Rows)
        //{
        //    HtmlTable tbl = (HtmlTable)gvRow.FindControl("tblRow");
        //    tbl.Visible = true;
        //    tbl.Border = 1;
        //}

        //GridViewExportUtil.ExportGrid("EarlyWarningRecipientsReport.xlsx", gvReport);// export data to excel from grid view

        //// reset the settings
        //foreach (GridViewRow gvRow in gvReport.Rows)
        //{
        //    HtmlTable tbl = (HtmlTable)gvRow.FindControl("tblRow");
        //    tbl.Border = 0;
        //}
        //// gvReport.ShowHeader = false;
        //gvReport.GridLines = GridLines.None;
        //((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 0;
    }

    /// <summary>
    /// Back show report to Criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        trCriteria.Visible = true;
        tblReport.Visible = false;
    }

    /// <summary>
    /// Region List Box selectedIndexchange event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lstRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strRegion = GetCommaSeparatedValues(lstRegion,true);
        string strMarkertPKs = GetCommaSeparatedValues(lstMarket,true);

        ComboHelper.FillMarketByRegion(new ListBox[] { lstMarket }, 0, false, strRegion);
        ComboHelper.FillActiveLocationByRegionMarket(new ListBox[] { lstLocation }, 0, false, strRegion, strMarkertPKs);
        //ComboHelper.FillLocationdbaByRegion(new ListBox[] { lstLocation }, 0, false, strRegion);
    }

    /// <summary>
    /// Market List Box selectedIndexchange event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lstMarket_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strRegion = GetCommaSeparatedValues(lstRegion,true);
        string strMarkertPKs = GetCommaSeparatedValues(lstMarket,true);

        ComboHelper.FillActiveLocationByRegionMarket(new ListBox[] { lstLocation }, 0, false, strRegion, strMarkertPKs);
        //ComboHelper.FillLocationdbaByRegion(new ListBox[] { lstLocation }, 0, false, strRegion);
    } 

    #endregion

    #region " Methods "

    /// <summary>
    /// Report method 
    /// </summary>
    /// <returns></returns>
    private System.Text.StringBuilder GenerateReport()
    {
        string strRegion, strLocation, strMarket, strLocationText, strMaketText;
        strRegion = strLocation = strMarket = strLocationText = strMaketText = string.Empty;

        strLocation = GetCommaSeparatedValues(lstLocation,true);
        strRegion = GetCommaSeparatedValues(lstRegion,true);
        strMarket = GetCommaSeparatedValues(lstMarket,true);

        strLocationText = GetCommaSeparatedValues(lstLocation, false);
        strMaketText = GetCommaSeparatedValues(lstMarket, false);

        //if (string.IsNullOrEmpty(strRegion))
        //{
        //    Page.RegisterStartupScript(DateTime.Now.ToString(), "<script language=javascript> alert('Please select atleast one region.');</script>");
        //}

        //if(string.IsNullOrEmpty(strLocation))


        DataSet Ds = new DataSet();
        Ds = Report.getrptEarlyAlertRecipientsTerminations(strRegion, strMarket, strLocation);

        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");

        if (Ds != null && Ds.Tables[0].Rows.Count > 0)
        {
            lbtExportToExcel.Visible = true;
            sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>");
            sbRecorords.Append("<td align='left' style='font-size:9pt'  colspan='6'>Early Alert Recipients Terminations Report (Terminations in the Past 7 Days) : " + DateTime.Now.ToString("MMMM dd, yyyy") + "</td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td colspan='6'></td>");
            sbRecorords.Append("</tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='6'><b> Filter(s) :  </b></td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='6'><b>Regions(s): " + strRegion + "</b></td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='6'><b>Market(s): " + strMaketText + "</b></td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='6'><b>Location(s): " + strLocationText + "</b></td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'><td align='left' style='font-size:9pt'  colspan='6'><b> Report Columns :  </b></td></tr>");
            #region " Header TR "
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td class='cols_' width='25%'>Region/Location</td>");
            sbRecorords.Append("<td class='cols_' width='15%'>Job Title</td>");
            sbRecorords.Append("<td class='cols_' width='15%'align='left'>Name - New</td>");
            sbRecorords.Append("<td class='cols_' width='15%'align='left'>E-Mail - New</td>");
            sbRecorords.Append("<td class='cols_' width='15%'align='left'>Name - Terminated</td>");
            sbRecorords.Append("<td class='cols_' width='15%'align='left'>E-Mail - Terminated</td>");
            sbRecorords.Append("</tr>"); 
            #endregion
            //now data

            string strTempRegion, strTempLocation, strTempTR;
            strTempRegion = strTempLocation = strTempTR = string.Empty;

            for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
            {
                
                if (i % 2 == 0)
                    strTempTR= "<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>";
                else
                    strTempTR = "<tr align='left' style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>";

                if (i == 0 || Convert.ToString(Ds.Tables[0].Rows[i]["Region"]) != strTempRegion)
                {
                    strTempRegion = Convert.ToString(Ds.Tables[0].Rows[i]["Region"]);
                    #region " Region TR "
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                    sbRecorords.Append("<td colspan='6' align='left' style='font-size:9pt' ><b>Region:</b>" + strTempRegion + "</td></tr>"); 
                    #endregion
                }

                if (i == 0 || Convert.ToString(Ds.Tables[0].Rows[i]["Location"]) != strTempLocation)
                {
                    strTempLocation = Convert.ToString(Ds.Tables[0].Rows[i]["Location"]);
                    #region " Location TR "
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                    sbRecorords.Append("<td colspan='6' align='left' style='font-size:9pt' ><b>Location:</b>" + strTempLocation + "</td></tr>"); 
                    #endregion
                }

                #region " Data TR "
                sbRecorords.Append(strTempTR);
                sbRecorords.Append("<td></td><td align='left' style='font-size:9pt' >" + Convert.ToString(Ds.Tables[0].Rows[i]["Job_Title"]) + "</td>");
                sbRecorords.Append("<td align='left' style='font-size:9pt' >" + Convert.ToString(Ds.Tables[0].Rows[i]["NAME"]) + "</td>");
                sbRecorords.Append("<td align='left' style='font-size:9pt' >" + Convert.ToString(Ds.Tables[0].Rows[i]["Email"]) + "</td>");
                sbRecorords.Append("<td align='left' style='font-size:9pt' >" + Convert.ToString(Ds.Tables[0].Rows[i]["Name_Terminated"]) + "</td>");
                sbRecorords.Append("<td align='left' style='font-size:9pt' >" + Convert.ToString(Ds.Tables[0].Rows[i]["Email_Terminated"]) + "</td></tr>"); 
                #endregion
                
            }
        }
        else
        {
            sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
            sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
            sbRecorords.Append("<td align='center' style='font-size:9pt;'>No Records Found.</td></tr></table>");
            lbtExportToExcel.Visible = false;
        }

        if (Ds != null)
            Ds = null;
        return sbRecorords;
    }

    /// <summary>
    /// Generates the string having selected values of List box in comma separated format
    /// </summary>
    /// <param name="lst"></param>
    /// <param name="bValue">comma separated value or items</param>
    /// <returns></returns>
    private string GetCommaSeparatedValues(ListBox lst,bool bValue)
    {
        string strTemp = string.Empty;
        foreach (ListItem itm in lst.Items)
        {
            if (itm.Selected && bValue)
                strTemp = strTemp + itm.Value + ",";
            else if(itm.Selected)
                strTemp = strTemp + itm.Text + ",";
        }
        strTemp = strTemp.TrimEnd(',');
        return strTemp;
    }

    ///// <summary>
    ///// Bind Drop Down List
    ///// </summary>    
    private void BindDropDownList()
    {
        ComboHelper.FillActiveRegionListBox(new ListBox[] { lstRegion }, false);
        //ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);
        ComboHelper.FillMarketByRegion(new ListBox[] { lstMarket }, 0, false, string.Empty);//first time bind all markets
        //ComboHelper.FillLocationdba(new ListBox[] { lstLocation }, 0, false);
        ComboHelper.FillActiveLocationByRegionMarket(new ListBox[] { lstLocation }, 0, false, string.Empty, string.Empty);//first time bind all markets
    }

    //public override void VerifyRenderingInServerForm(Control control)
    //{

    //}
    #endregion
}