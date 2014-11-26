using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using ERIMS.DAL;
using System.IO;
using System.Text;
public partial class COIReports_PoliciesExpirationDates : clsBasePage
{
    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtType = COI_Type.SelectAll().Tables[0];
            drpCOIType.DataSource = dtType;
            drpCOIType.DataTextField = "Fld_Desc";
            drpCOIType.DataValueField = "PK_COI_Type";
            drpCOIType.DataBind();
            drpCOIType.Items.Insert(0, new ListItem("--All Types--", "0"));
        }
    }
    #endregion

    #region Event
    /// <summary>
    /// Event to Generate Report according to specific criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        // get the report data
        DataSet dsReport = clsCOIReports.PoliciesExpirationDates(Convert.ToInt32(drpCOIType.SelectedValue));
        //DataTable dtReport = MergeData(dsReport, dsReport.Tables[0]);
        DataTable dtReport = dsReport.Tables[0];
        btnExport.Visible = dtReport.Rows.Count > 0;
        //// add total in the footer if records are available      
        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
        if (dtReport.Rows.Count > 0)
        {
            sbRecorords.Append("<style type='text/css'></style><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  width='2300px'><tr><td class='cols_' style='width:100%'>");
            sbRecorords.Append("<table style='font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' width='2300px'>");//Sub Table
            //Title
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25;width:100%'>");
            sbRecorords.Append("<td align='left' style='font-size:9pt;' colspan='13' ><b> Policy Expiration Dates (By Entity Name)</b></td><td align='right' style='font-size:9pt;' colspan='9' ><b> " + DateTime.Now + " </b></td>");
            sbRecorords.Append("</tr>");
            //Record
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            for (int j = 1; j <= 10; j++)
            {
                sbRecorords.Append("<td class='cols_' width='130px' align='left' valign='top'><div style='width:130px;'>" + dtReport.Columns[j].ColumnName + "</div></td>");
            }
            for (int j = 11; j <= 22; j++)
            {
                sbRecorords.Append("<td class='cols_' width='130px' align='left' valign='top'><div style='width:120px;'>" + dtReport.Columns[j].ColumnName + "</div></td>");
            } 
            sbRecorords.Append("</tr>");
            //Records
            for (int i = 0; i < dtReport.Rows.Count; i++)
            {
                int intRes;
                int intDiv = System.Math.DivRem(i, 2, out intRes);
                if (intRes == 0)
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>");
                else
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                DataRow drRecords = dtReport.Rows[i];
                for (int j = 1; j <= dtReport.Columns.Count; j++)
                {
                    if (j != 23)
                    {
                        if (Convert.ToString(drRecords[j]) == string.Empty)
                            sbRecorords.Append("<td class='cols_' align='left' valign='top'>&nbsp;</td>");
                        else
                            sbRecorords.Append("<td class='cols_' align='left' valign='top'>" + Convert.ToString(drRecords[j]) + "</td>");
                    }
                }
            }
            //Footer
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#507cd1;color:White;font-size:11pt;height:25'>");
            sbRecorords.Append("<td align='left' style='font-size:9pt;' colspan='1' ><b> Total </b></td><td align='left' style='font-size:9pt;' colspan='21' ><b> " + dtReport.Rows.Count.ToString() + " </b></td>");
            sbRecorords.Append("</tr>");
            sbRecorords.Append("</table>");
            sbRecorords.Append("</td></tr>");
            sbRecorords.Append("</table>");
            divReportData.Style["overflow-x"] = "scroll";
          
        }
        else
        {
            divReportData.Style["overflow-x"] = "none";
            sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' width='100%'>");
            sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
            sbRecorords.Append("<td align='center' style='font-size:9pt;'>No Records found</td></tr></table>");
           
        }
        lblReport.Text = sbRecorords.ToString();
        dvGrid.Style["display"] = "block";      
    }
    /// <summary>
    /// Event to Export Gridview data to Excel file
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        // Export the data into excel spreadsheet  
        string strcols = "border-right: black 1px solid;border-top: black 1px solid; border-left: black 1px solid;border-bottom: black 1px solid;vertical-align: top;padding-right: 2px;padding-left: 4px;font-size: 8pt;border-collapse: collapse;";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        htmlWrite.WriteLine(@"<style>.cols_ {mso-number-format:'\@';} </style>");
        lblReport.RenderControl(htmlWrite);

        MemoryStream memorystream = new MemoryStream();
        byte[] _bytes = Encoding.UTF8.GetBytes(stringWrite.ToString().Replace("border-top:#EAEAEA", "border-top:#000000").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>"));
        memorystream.Write(_bytes, 0, _bytes.Length);
        memorystream.Seek(0, SeekOrigin.Begin);

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Policy Expiration Dates (By Entity Name).xls"));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Write(stringWrite.ToString().Replace("#EAEAEA", "White").Replace("#eaeaea", "White").Replace("background-color:#C0C0C0", "background-color:White;").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>").Replace("background-color:#7f7f7f;color:White", "background-color:White;color:Black"));       
        HttpContext.Current.Response.End();
    }
    #endregion

    #region Method
    // <summary>
    // This method is added for export Girdview To Excel which contains SubGridview.
    // </summary>
    // <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    /// <summary>
    /// Event to Mergedata to display in Report
    /// </summary>
    /// <param name="ds"></param>
    /// <param name="dtReport"></param>
    /// <returns></returns>
    private DataTable MergeData(DataSet ds, DataTable dtReport)
    {
        int intColsAdded = 0;

        DataTable dtDest = dtReport.Copy();


        int intPolicyCol = 0;
        for (int intTab = 1; intTab < ds.Tables.Count - 1; intTab++)
        {
            int intRowIndex = 0;
            DataTable dt = ds.Tables[intTab];
            for (int intCol = 1; intCol < dt.Columns.Count; intCol++)
            {
                dtDest.Columns.Add(dt.Columns[intCol].ColumnName);
            }

            for (int i = 0; i < dtReport.Rows.Count; i++)
            {

                DataRow[] drPolicy = dt.Select(dt.Columns[0].ColumnName + " = " + dtReport.Rows[i][0].ToString());
                DataRow[] drCOIs = dtDest.Select("PK_COIs=" + dtReport.Rows[i][0].ToString());
                int intPolicyRowsAdded = 0;
                int intColumn = 0;
                foreach (DataRow dr in drPolicy)
                {
                    intColumn = (intTab == 1) ? dtReport.Columns.Count : intPolicyCol + dtReport.Columns.Count;

                    if (drPolicy.Length > drCOIs.Length && intPolicyRowsAdded > 0)
                    {
                        DataRow drNew = dtDest.NewRow();
                        for (int j = 1; j < dt.Columns.Count; j++)
                        {
                            drNew[0] = dtReport.Rows[i][0].ToString();
                            drNew[intColumn] = dr[j].ToString();
                            intColumn++;
                        }
                        dtDest.Rows.InsertAt(drNew, intRowIndex + intPolicyRowsAdded);
                    }
                    else
                    {
                        for (int j = 1; j < dt.Columns.Count; j++)
                        {
                            dtDest.Rows[intRowIndex + intPolicyRowsAdded][intColumn] = dr[j].ToString();
                            intColumn++;
                        }
                    }
                    intPolicyRowsAdded++;
                }
                if (drPolicy.Length > drCOIs.Length)
                    intRowIndex += intPolicyRowsAdded;
                else
                    intRowIndex += drCOIs.Length;

            }
            intPolicyCol += dt.Columns.Count - 1;

        }
        return dtDest;
    }
    #endregion



}
