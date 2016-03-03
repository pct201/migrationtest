using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.IO;

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

        String strPath = String.Empty, data = String.Empty, outputFiles = String.Empty;
        strPath = AppConfig.SitePath + @"temp\" + DateTime.Now.ToString("ddMMyyyyhhmmss");
        if (!File.Exists(strPath))
        {
            if (!Directory.Exists(AppConfig.SitePath + @"temp\"))
                Directory.CreateDirectory(AppConfig.SitePath + @"temp\");
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(strPath))
            {
                sw.Write(stringWrite.ToString());
            }
        }

        data = File.ReadAllText(strPath);
        data = data.Trim();
        HTML2Excel objHtml2Excel = new HTML2Excel(data);
        outputFiles = Path.GetFullPath(strPath) + ".xlsx";
        bool blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);

        if (blnHTML2Excel)
        {
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"Worksheet Template Export.xlsx\""));
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                HttpContext.Current.Response.TransmitFile(outputFiles);
                HttpContext.Current.Response.Flush();
            }
            finally
            {
                if (File.Exists(outputFiles))
                    File.Delete(outputFiles);
                if (File.Exists(strPath))
                    File.Delete(strPath);

                HttpContext.Current.Response.End();
            }
        }

    }
}