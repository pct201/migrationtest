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

public partial class DashBoard_rptSafetyTrainingByRegionLocation : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //BindRegion();
            BindYear();
            ComboHelper.FillRegionListBox(new ListBox[] { lstRegion }, false);
            //ComboHelper.FillMarket(new DropDownList[] { ddlMarket }, true);
            //drpReportInterval.Focus();

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

        lblReport.Text = GenerageAnnaulyReportByRegionLocation().ToString();
    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        // load the page again to clear selection        
        drpYear.SelectedIndex = 0;
        lstRegion.ClearSelection();
        //drpReportInterval.SelectedIndex = 0;
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
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        //PrepareControlForExport(gvReportGrid.HeaderRow);
        lblReport.RenderControl(htmlWrite);
        // gvReportGrid.RenderControl(htmlWrite);

        MemoryStream memorystream = new MemoryStream();
        byte[] _bytes = Encoding.UTF8.GetBytes(stringWrite.ToString().Replace("border-top:#EAEAEA", "border-top:#000000").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>"));
        memorystream.Write(_bytes, 0, _bytes.Length);
        memorystream.Seek(0, SeekOrigin.Begin);

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Safety Training by Region and Location Report.xls"));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Write(stringWrite.ToString().Replace("#EAEAEA", "White").Replace("#eaeaea", "White").Replace("background-color:#C0C0C0", "background-color:White;").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>").Replace("background-color:#7f7f7f;color:White", "background-color:White;color:Black"));
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
        lblHeading.Text = "Safety Training by Region and Location Report";
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
    //private void BindRegion()
    //{
    //    // get regions for user having access to and bind the regions list box
    //    DataTable dtRegions = clsExposuresReports.GetRegionList().Tables[0];
    //    drpRegions.DataSource = dtRegions;
    //    drpRegions.DataTextField = "region";
    //    drpRegions.DataValueField = "region";
    //    drpRegions.DataBind();
    //    drpRegions.Items.Insert(0, new ListItem("--All Regions--", ""));
    //}



    private System.Text.StringBuilder GenerageAnnaulyReportByRegionLocation()
    {
        string strRegion = "";
        // get selected regions
        foreach (ListItem li in lstRegion.Items)
        {
            if (li.Selected)
                strRegion = strRegion + "" + li.Value + ",";
        }
        strRegion = strRegion.TrimEnd(',');

        if (string.IsNullOrEmpty(strRegion))
        {
            foreach (ListItem li in lstRegion.Items)
            {                
                strRegion = strRegion + "" + li.Value + ",";
            }
        }



        DataSet dsReport = clsExposuresReports.GetSafetyTrainingReportByRegionLocation(Convert.ToInt32(drpYear.SelectedValue), strRegion);

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
            sbRecorords.Append("<td width='140px' align='left' style='font-size:9pt;' colspan='1'><b>Sonic Automotive</b></td>");
            sbRecorords.Append("<td width='500px' align='center' style='font-size:9pt;' colspan='1' ><b> Safety Training - ANNAUL REPORT by Region and Location FOR " + drpYear.SelectedValue + " </b></td>");
            sbRecorords.Append("<td width='300px' style='font-size:9pt'  colspan='1'>Valuation Date: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#FFFFFF;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td ></td>");
            sbRecorords.Append("<td ></td>");
            sbRecorords.Append("<td ></td>");
            sbRecorords.Append("</tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#FFFFFF;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td ></td>");
            sbRecorords.Append("<td ></td>");
            sbRecorords.Append("<td ></td>");
            sbRecorords.Append("</tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td class='cols_' width='300px'>Region</td>");
            sbRecorords.Append("<td class='cols_' width='140px'>Location</td>");
            sbRecorords.Append("<td class='cols_' width='200px'align='left'>Percentage Completed Training(%)</td>");
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
                sbRecorords.Append("<td class='cols_' >" + Convert.ToString(drRecords["dba"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["PercentageCompleted"]) + "</td>");
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

    #endregion

}