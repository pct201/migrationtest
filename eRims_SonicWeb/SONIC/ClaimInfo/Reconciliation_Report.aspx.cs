using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using ERIMS.DAL;

public partial class Claim_Reconciliation_Report : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strPath = string.Empty;
        //strPath = AppConfig.strGeneralDocument;
    }

    protected void btnUpload_click(object sender, EventArgs e)
    {
        string strFilePath= string.Empty;
        try
        {
             if (ValidateExtension())
            {
                // upload the file using session id and get the uploaded file name
                string strUploadedFile = clsGeneral.UploadFile(fpFile, AppConfig.strGeneralDocument + "\\" + "JURIS Sheets", Session.SessionID, false, false);
                strFilePath = AppConfig.strGeneralDocument + "\\" + "JURIS Sheets" + "\\" + strUploadedFile;
                //string strFilePath = string.Empty;  
                DataSet ds = new DataSet();
                ds = clsClaimReports.GetReconciliationReport(strFilePath);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ExportToExcel(ds);                    
                    ds = null;
                }
            }
            else { Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Please upload valid excel file.');", true); }
        }
        catch (Exception ex)
        {            
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Error occurred please try again.');", true);
        }
        finally
        {
            if (System.IO.File.Exists(strFilePath))
                System.IO.File.Delete(strFilePath);     
        }
    }

    private bool ValidateExtension()
    {
        string strFileExtention = System.IO.Path.GetExtension(fpFile.FileName);
        if (strFileExtention.ToLower() == ".xls" || strFileExtention.ToLower() == ".xlsx")
        {
            return true;
        }
        return false;
    }
    
    private void ExportToExcel(DataSet ds)
    {
        string strXml = string.Empty;
        string strGeneralXml = string.Empty;
        strGeneralXml = clsGeneral.GetGeneralXmlForExcel();

        strXml = XmlFileForWorkSheet(ds);        
        string excelXml = string.Format(strGeneralXml, strXml);
        DownloadFile(excelXml, "Reconciliation Report");
    }

    private string XmlFileForWorkSheet(DataSet Ds)
    {
        StringBuilder strHTML = new StringBuilder();
        string strColumnWidthTag = string.Empty;
        //strColumnWidthTag = clsGeneral.GetColumnWidth(gv, 120);


        strHTML.Append("<Worksheet ss:Name='Reconciliation Report Summary'>");
        strHTML.Append("<Table>");
        strColumnWidthTag = clsGeneral.GetColumnWidth(Ds.Tables[3], 120);
        if (strColumnWidthTag != string.Empty)
            strHTML.Append(strColumnWidthTag);

        //Header Logic
        strHTML.Append("<Row>");

        // in loop there is count -2 there is one extra column that not need to print
        for (int i = 0; i <= Ds.Tables[3].Columns.Count - 2; i++)
        {
            strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">" + Ds.Tables[3].Columns[i].ToString() + "</Data></Cell>");
        }
        strHTML.Append("</Row>");


        for (int i = 0; i <= Ds.Tables[3].Rows.Count - 1; i++)
        {
            strHTML.Append("<Row>");
            for (int k = 0; k <= Ds.Tables[3].Columns.Count - 2; k++)
            {
                if (Ds.Tables[3].Rows[i][5].ToString() == "1")
                {
                    if (k == 2)
                    {
                        strHTML.Append("<Cell ss:StyleID=\"s63\"><Data ss:Type=\"String\">" + string.Format("{0:N2}", Convert.ToDecimal(Ds.Tables[3].Rows[i][k])) + "</Data></Cell>");
                    }
                    else
                    {
                        strHTML.Append("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + Ds.Tables[3].Rows[i][k].ToString() + "</Data></Cell>");
                    }

                }
                else if (Ds.Tables[3].Rows[i][5].ToString() == "2")
                {
                    if (k == 2)
                    {
                        strHTML.Append("<Cell ss:StyleID=\"NumberBoldColumn\"><Data ss:Type=\"String\">" + string.Format("{0:N2}", Convert.ToDecimal(Ds.Tables[3].Rows[i][k])) + "</Data></Cell>");
                    }
                    else
                    {
                        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">" + Ds.Tables[3].Rows[i][k].ToString() + "</Data></Cell>");
                    }
                }
                else
                {
                    if (Ds.Tables[3].Rows[i][k].ToString() == "Z")
                    {
                        strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\"></Data></Cell>");
                    }
                    else
                    {
                        if (k == 2)
                        {
                            strHTML.Append("<Cell ss:StyleID=\"NumberBoldColumn\"><Data ss:Type=\"String\">" + string.Format("{0:N2}", Convert.ToDecimal(Ds.Tables[3].Rows[i][k])) + "</Data></Cell>");
                        }
                        else
                        {
                            strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">" + Ds.Tables[3].Rows[i][k].ToString() + "</Data></Cell>");
                        }
                    }
                }
            }
            strHTML.Append("</Row>");
        }

        strHTML.Append("</Table>");
        strHTML.Append("</Worksheet>");

        strColumnWidthTag = clsGeneral.GetColumnWidth(Ds.Tables[0], 120);
        strHTML.Append("<Worksheet ss:Name='Claim Paid Month Total Amount Differs'>");
        strHTML.Append("<Table>");

        if (strColumnWidthTag != string.Empty)
            strHTML.Append(strColumnWidthTag);

        //Header Logic
        strHTML.Append("<Row>");
        for (int i = 0; i <= Ds.Tables[0].Columns.Count - 1; i++)
        {
            strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">" + Ds.Tables[0].Columns[i].ToString() + "</Data></Cell>");
        }
        strHTML.Append("</Row>");

            for (int i = 0; i <= Ds.Tables[0].Rows.Count - 1; i++)
            {
                strHTML.Append("<Row>");
                for (int k = 0; k <= Ds.Tables[0].Columns.Count - 1; k++)
                {
                    if (k == 6 || k == 7)
                    {
                        if (Convert.ToString(Ds.Tables[0].Rows[i][k]) == string.Empty)
                        {
                            strHTML.Append("<Cell ss:StyleID=\"s63\"><Data ss:Type=\"String\">" +  Convert.ToString(Ds.Tables[0].Rows[i][k]) + "</Data></Cell>");
                        }
                        else
                        {
                            strHTML.Append("<Cell ss:StyleID=\"s63\"><Data ss:Type=\"String\">" + string.Format("{0:N2}", Convert.ToDecimal(Ds.Tables[0].Rows[i][k])) + "</Data></Cell>");
                        }
                    }
                    else { strHTML.Append("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + Ds.Tables[0].Rows[i][k].ToString() + "</Data></Cell>"); }

                }
                strHTML.Append("</Row>");
            }
        
        strHTML.Append("</Table>");
        strHTML.Append("</Worksheet>");

        strColumnWidthTag = clsGeneral.GetColumnWidth(Ds.Tables[1], 120);
        strHTML.Append("<Worksheet ss:Name='Non-Matches'>");
        strHTML.Append("<Table>");

        if (strColumnWidthTag != string.Empty)
            strHTML.Append(strColumnWidthTag);

        //Header Logic
        strHTML.Append("<Row>");
        for (int i = 0; i <= Ds.Tables[1].Columns.Count - 2; i++)// here count -2 becuase last column should be removed from report.
        {
            strHTML.Append("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">" + Ds.Tables[1].Columns[i].ToString() + "</Data></Cell>");
        }
        strHTML.Append("</Row>");


        for (int cnt = 1; cnt <= Ds.Tables.Count - 2; cnt++)
        {
            for (int i = 0; i <= Ds.Tables[cnt].Rows.Count - 1; i++)
            {
                strHTML.Append("<Row>");
                for (int k = 0; k <= Ds.Tables[cnt].Columns.Count - 2; k++) // here count -2 becuase last column should be removed from report.
                {
                    if (k == 7 || k == 10 || k == 11)
                    {
                        strHTML.Append("<Cell ss:StyleID=\"s63\"><Data ss:Type=\"String\">" + string.Format("{0:N2}", Convert.ToDecimal(Ds.Tables[cnt].Rows[i][k])) + "</Data></Cell>");
                    }
                    else { strHTML.Append("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + Ds.Tables[cnt].Rows[i][k].ToString() + "</Data></Cell>"); }
                }
                strHTML.Append("</Row>");
            }
        }
        strHTML.Append("</Table>");
        strHTML.Append("</Worksheet>");
        
        return strHTML.ToString();
    }

        
    private void DownloadFile(string strHTML, string sectionName)
    {
        //try
        //{
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.AppendHeader("Content-Type", "application/vnd.ms-excel");
            context.Response.AppendHeader("Content-disposition", "attachment; filename=" + sectionName + ".xls");
            context.Response.Write(strHTML);            
            context.Response.Flush();
            context.Response.End();
            context = null;
        //}
        //catch(Exception e)
        //{
        //    throw e;
        //}        
    }
}
