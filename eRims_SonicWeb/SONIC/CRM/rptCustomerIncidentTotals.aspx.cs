using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using ERIMS.DAL;

public partial class SONIC_CRM_rptCustomerIncidentTotals : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ComboHelper.FillLocationDBA_All(new ListBox[] { lstDBA }, 0, false);
            lstDBA.Style.Remove("font-size");
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        DateTime? dtBegin, dtEnd;
        dtBegin = dtEnd = null;

        if (txtBeginDate.Text != string.Empty) dtBegin = Convert.ToDateTime(txtBeginDate.Text);
        if (txtEndDate.Text != string.Empty) dtEnd = Convert.ToDateTime(txtEndDate.Text);

        string strDBA = "";

        foreach (ListItem lst in lstDBA.Items)
        {
            if (lst.Selected)
                strDBA = strDBA + lst.Value + ",";
        }
        strDBA = strDBA.TrimEnd(',');

        DataSet dsReport = clsCRMReports.GetIncidentTotalsByDealership(dtBegin, dtEnd, strDBA);

        DataTable dtReport = dsReport.Tables[0];
        dtReport.Columns.Add(new DataColumn("Total", typeof(int)));

        for (int i = 0; i < dtReport.Rows.Count; i++)
        {
            decimal? decTotal = 0;

            for (int j = 1; j < dtReport.Columns.Count - 1; j++)
            {
                decTotal = decTotal + Convert.ToDecimal(dtReport.Rows[i][j]);
            }
            dtReport.Rows[i]["Total"] = decTotal;
        }
        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
        trCriteria.Visible = false;
        tblReport.Visible = true;
        lbtExportToExcel.Visible = dtReport.Rows.Count > 0;

        int intColspan = dtReport.Columns.Count;

        // Check if record found or not.
        if (dtReport.Rows.Count > 0)
        {
            sbRecorords.Append("<style type='text/css'></style><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td class='cols_' >");
            sbRecorords.Append("<table style='font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");//Sub Table
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>"); //Title
            sbRecorords.Append("<td align='center' style='font-size:9pt;' colspan='" + intColspan.ToString() + "' ><b> Customer Relationship Incident Totals by Dealership Report for " + txtBeginDate.Text + " To " + txtEndDate.Text + " </b></td>");
            sbRecorords.Append("</tr>");

            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td class='cols_' width='230px'>Location D/B/A</td>");
            for (int j = 1; j < dtReport.Columns.Count; j++)
            {
                sbRecorords.Append("<td class='cols_' width='120px' align='left'>" + dtReport.Columns[j].ColumnName + "</td>");
            }
            sbRecorords.Append("</tr>");


            for (int i = 0; i < dtReport.Rows.Count; i++)
            {
                int intRes;
                int intDiv = System.Math.DivRem(i, 2, out intRes);
                if (intRes == 0)
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>");
                else
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");

                DataRow drRecords = dtReport.Rows[i];

                for (int j = 0; j < dtReport.Columns.Count; j++)
                {
                    if (j == 0)
                        sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["DBA"]) + "</td>");
                    else
                        sbRecorords.Append("<td class='cols_' align='left'>" + string.Format("{0:N0}", drRecords[j]) + "</td>");                    
                }
            }

            //sbRecorords.Append("<tr><td colspan='14' class='cols_'>&nbsp;</td></tr>");
            sbRecorords.Append("</table>");
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

        lblReport.Text = sbRecorords.ToString();
    }

    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        txtBeginDate.Text = "";
        txtEndDate.Text = "";
        lstDBA.ClearSelection();
    }

    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        //string strcols = "border: #7f7f7f 1px solid;vertical-align: top;font-size: 8pt;border-collapse: collapse;";
        string strcols = "border-right: black 1px solid;border-top: black 1px solid; border-left: black 1px solid;border-bottom: black 1px solid;vertical-align: top;padding-right: 2px;padding-left: 4px;font-size: 8pt;border-collapse: collapse;";
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
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customer Relationship Incident Totals by Dealership.xls"));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Write(stringWrite.ToString().Replace("#EAEAEA", "White").Replace("#eaeaea", "White").Replace("background-color:#C0C0C0", "background-color:White;").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>").Replace("background-color:#7f7f7f;color:White", "background-color:White;color:Black"));
        HttpContext.Current.Response.End();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        trCriteria.Visible = true;
        tblReport.Visible = false;
    }
}