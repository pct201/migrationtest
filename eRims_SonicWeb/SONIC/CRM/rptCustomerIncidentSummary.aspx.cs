using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using ERIMS.DAL;

public partial class SONIC_CRM_rptCustomerIncidentSummary : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpYear.Items.Clear();
            int intMinYear, intMaxYear;
            intMinYear = 2000;
            intMaxYear = DateTime.Now.Year;
            for (int i = intMaxYear; i >= intMinYear; i--)
            {
                drpYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            ComboHelper.FillLocationDBA_All(new ListBox[] { lstDBA }, 0, false);
            //lstDBA.Style.Remove("font-size");
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {

        int intYear = Convert.ToInt32(drpYear.SelectedValue);
        string strDBA = "";

        foreach (ListItem lst in lstDBA.Items)
        {
            if (lst.Selected)
                strDBA = strDBA + lst.Value + ",";
        }
        strDBA = strDBA.TrimEnd(',');

        DataSet dsReport = clsCRMReports.GetCustomerIncidentSummary(intYear, strDBA);

        DataTable dtRecordType = dsReport.Tables[0];
        DataTable dtReport = dsReport.Tables[1];

        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
        trCriteria.Visible = false;
        tblReport.Visible = true;
        lbtExportToExcel.Visible = dtReport.Rows.Count > 0;
        btnBack.Visible = true;
        // Check if record found or not.
        if (dtReport.Rows.Count > 0)
        {
            sbRecorords.Append("<style type='text/css'></style><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td class='cols_' >");
            sbRecorords.Append("<table style='font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");//Sub Table
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>"); //Title
            sbRecorords.Append("<td align='center' style='font-size:9pt;' colspan='14' ><b> Customer Relations Incident Summary Report for " + drpYear.SelectedValue + " </b></td>");
            sbRecorords.Append("</tr>");

            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td class='cols_' width='130px'>&nbsp;</td>");
            sbRecorords.Append("<td class='cols_' width='56px' align='left'>JAN</td>");
            sbRecorords.Append("<td class='cols_' width='56px' align='left'>FEB</td>");
            sbRecorords.Append("<td class='cols_' width='56px' align='left'>MAR</td>");
            sbRecorords.Append("<td class='cols_' width='56px' align='left'>APR</td>");
            sbRecorords.Append("<td class='cols_' width='56px' align='left'>MAY</td>");
            sbRecorords.Append("<td class='cols_' width='56px' align='left'>JUN</td>");
            sbRecorords.Append("<td class='cols_' width='56px' align='left'>JUL</td>");
            sbRecorords.Append("<td class='cols_' width='56px' align='left'>AUG</td>");
            sbRecorords.Append("<td class='cols_' width='56px' align='left'>SEP</td>");
            sbRecorords.Append("<td class='cols_' width='56px' align='left'>OCT</td>");
            sbRecorords.Append("<td class='cols_' width='56px' align='left'>NOV</td>");
            sbRecorords.Append("<td class='cols_' width='56px' align='left'>DEC</td>");
            sbRecorords.Append("<td class='cols_' width='56px' align='left'>Total</td>");
            sbRecorords.Append("</tr>");

            sbRecorords.Append("<tr style='font-weight: bold; color: #FF6600;font-size:9pt'><td style='border-bottom: #EAEAEA 1px solid' class='cols_'  style='color: #FF9C09;font-weight: bold;font-size:9pt' colspan='14'>Analysis by Incident</td></tr>");

            for (int i = 0; i < dtRecordType.Rows.Count; i++)
            {
                string strRecordType = Convert.ToString(dtRecordType.Rows[i]["Type"]);
                DataRow[] drReport = dtReport.Select("Type = '" + strRecordType + "'");

                if (strRecordType == "Number of Dealerships with a Reported Incident")
                    sbRecorords.Append("<tr style='font-weight: bold; color: #FF6600;font-size:9pt'><td style='border-bottom: #EAEAEA 1px solid' class='cols_'  style='color: #FF9C09;font-weight: bold;font-size:9pt' colspan='14'>Analysis by Dealership</td></tr>");

                sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");

                if (strRecordType == "Method of Contact")
                {
                    sbRecorords.Append("<td  class='cols_' align='left' colspan='13'><b>" + strRecordType + "</b></td>");
                    sbRecorords.Append("<td  class='cols_' align='left'><b>TOTAL</b></td>");
                }
                else
                    sbRecorords.Append("<td  class='cols_' align='left' " + ((drReport.Length > 1) ? "colspan='14'" : "") + "><b>" + strRecordType + "</b></td>");

                if (drReport.Length > 1) sbRecorords.Append("</tr>");

                for (int j = 0; j < drReport.Length; j++)
                {
                    DataRow drRecords = drReport[j];
                    if (drReport.Length > 1)
                    {   
                        int intRes;
                        int intDiv = System.Math.DivRem(j, 2, out intRes);
                        if (intRes == 0)
                            sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>");                            
                        else
                            sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");

                        sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["Description"]) + "</td>");
                    }

                    sbRecorords.Append("<td class='cols_' align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["JAN"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["FEB"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["MAR"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["APR"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["MAY"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["JUN"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["JUL"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["AUG"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["SEP"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["OCT"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["NOV"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["DEC"]) + "</td>");

                    if(strRecordType == "Incidents Closed in Month Received")
                        sbRecorords.Append("<td class='cols_' align='left'><b>AVG</b></td>");
                    else
                        sbRecorords.Append("<td class='cols_' align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["Total"]) + "</td>");
                    
                    if (drReport.Length > 1) sbRecorords.Append("</tr>");
                }
                if (i < dtRecordType.Rows.Count - 1)
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'><td colspan='14'>&nbsp;</td>");
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
        drpYear.SelectedIndex = 0;
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
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customer Relations Incident Summary Report.xls"));
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