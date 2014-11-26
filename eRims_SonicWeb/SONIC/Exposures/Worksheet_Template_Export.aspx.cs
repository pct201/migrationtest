using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class Reports_Worksheet_Template_Export : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }


    /// <summary>
    /// Template of COI spreadsheet
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        //Create HTML for the report and wirte into HTML Write object
        StringBuilder strHTML = new StringBuilder();
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        //Add Header HTML
        strHTML.Append("<table  cellpadding='0' cellspacing='0' width='100%' border='1'>");
        strHTML.Append("<tr align='right' valign='bottom' style='font-weight: bold;'>");
        strHTML.Append("<td align='left'>Sonic_Location_Code</td>");
        strHTML.Append("<td align='left'>Year</td>");
        strHTML.Append("<td align='left'>Non_Texas_Payroll</td>");
        strHTML.Append("<td align='left'>Texas_Payroll</td>");
        strHTML.Append("<td align='left'>Number_Of_Employees</td>");
        strHTML.Append("</tr>");

        DataTable dtLocation = ERIMS.DAL.LU_Location.SelectAllActiveLocation().Tables[0];

        if (dtLocation.Rows.Count == 0)  //add blank row
        {
            DataRow drBlankRow = dtLocation.NewRow();
            dtLocation.Rows.Add(drBlankRow);
        }

        string strColumn = string.Empty;
        foreach (DataRow drLocation in dtLocation.Rows)
        {
            strColumn = "<td align='left'>" + Convert.ToString(drLocation["Sonic_Location_Code"]) + "</td>";//Dynamic Column

            strHTML.Append("<tr align='right' valign='bottom' >");
            strHTML.Append(strColumn);
            strHTML.Append("<td align='left'></td>");
            strHTML.Append("<td align='left'></td>");
            strHTML.Append("<td align='left'></td>");
            strHTML.Append("<td align='left'></td>");
            strHTML.Append("</tr>");
        }
        
        strHTML.Append("</table>");

        //Write HTML in to HtmlWriter
        htmlWrite.WriteLine(strHTML.ToString());

        HttpContext context = HttpContext.Current;
        context.Response.Clear();

        context.Response.Write(stringWrite);
        context.Response.ContentType = "application/ms-excel";
        context.Response.AppendHeader("Content-Disposition", "attachment; filename=Worksheet Template Export.xls");
        context.Response.End();
    }
}