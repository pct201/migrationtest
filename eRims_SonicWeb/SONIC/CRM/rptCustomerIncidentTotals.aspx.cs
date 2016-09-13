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
            sbRecorords.Append("<table border='0' style='font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");//Sub Table
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25;border:thin'>"); //Title
            sbRecorords.Append("<td align='center' style='font-size:9pt;' colspan='" + intColspan.ToString() + "' ><b> Customer Relationship Incident Totals by Dealership Report for " + txtBeginDate.Text + " To " + txtEndDate.Text + " </b></td>");
            sbRecorords.Append("</tr>");

            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt;border:thin'>");
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
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;border:thin'>");
                else
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;border:thin'>");

                DataRow drRecords = dtReport.Rows[i];

                for (int j = 0; j < dtReport.Columns.Count; j++)
                {
                    if (j == 0)
                        sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["DBA"]) + "</td>");
                    else
                        sbRecorords.Append("<td class='cols_' align='left'>" + string.Format("{0:N0}", drRecords[j]) + "</td>");                    
                }
                sbRecorords.Append("</tr>");
            }

            //sbRecorords.Append("<tr><td colspan='14' class='cols_'>&nbsp;</td></tr>");
            sbRecorords.Append("</table>");
            sbRecorords.Append("</td></tr></table>");
            trGrid.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.            
            trGrid.Visible = false;
            sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
            sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;border:thin'>");
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
        GridViewExportUtil.ExportGrid("Customer Relationship Incident Totals by Dealership.xlsx", lblReport);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        trCriteria.Visible = true;
        tblReport.Visible = false;
    }
}