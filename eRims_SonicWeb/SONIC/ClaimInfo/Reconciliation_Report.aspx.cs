using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using ERIMS.DAL;
using System.IO;
using OfficeOpenXml;

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
                    string strReconciliationReport = ExportToExcel(ds);

                    //int trantablecount = ds.Tables.Count - 1; //Last table

                    string strTransactionReport = string.Empty;
                    if (ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
                    {
                        strTransactionReport = GetTransactionReport(ds.Tables[4], "Transaction_Report");
                    }

                    string[] strAttachments = new string[2];

                    strAttachments[0] = strReconciliationReport;
                    if (strTransactionReport.Length > 0)
                    {
                        strAttachments[1] = strTransactionReport;
                    }
                    string strzipDir = AppConfig.DocumentsPath + "\\Reconciliation";

                    clsGeneral.SetZipDirectory(strAttachments, strzipDir);

                    int TotalfileCount = Directory.GetFiles(strzipDir, "*.*", SearchOption.AllDirectories).Length;
                    if (TotalfileCount == 1)
                    {
                        string[] filePaths = Directory.GetFiles(AppConfig.DocumentsPath + "\\Reconciliation");

                        System.IO.FileInfo file = new System.IO.FileInfo(filePaths[0]);

                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", file.Name));
                        HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
                        HttpContext.Current.Response.ContentType = "application/octet-stream";//ReturnExtension(clsGeneral.GetExtension(objAttachment.Attachment_Name));
                        HttpContext.Current.Response.TransmitFile(filePaths[0]);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                    else
                    {
                        clsGeneral.ConvertZIP(strzipDir);
                        System.IO.FileInfo file = new System.IO.FileInfo(strzipDir + ".Zip");
                        clsGeneral.DownloadZIP(AppConfig.DocumentsPath + "Reconciliation");
                    }

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
    
    private string ExportToExcel(DataSet ds)
    {
        string strXml = string.Empty;
        string strGeneralXml = string.Empty;
        strGeneralXml = clsGeneral.GetGeneralXmlForExcel();

        strXml = XmlFileForWorkSheet(ds);        
        string excelXml = string.Format(strGeneralXml, strXml);

        string strReconciliationReport = SaveTempFile(excelXml, "Reconciliation Report");

        return strReconciliationReport;

        //DownloadFile(excelXml, "Reconciliation Report");
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


        for (int cnt = 1; cnt <= Ds.Tables.Count - 3; cnt++)
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

    private string SaveTempFile(string strHTML, string sectionName)
    {
        //try
        //{

        string strPath = string.Empty;
        strPath = AppConfig.SitePath + @"temp\" + "Reconciliation_Report.xls";

        StringBuilder sbRecord = new StringBuilder();
        sbRecord.Append(strHTML);

        if (!Directory.Exists(AppConfig.SitePath + @"temp\"))
            Directory.CreateDirectory(AppConfig.SitePath + @"temp\");

        if (File.Exists(strPath))
            File.Delete(strPath);

        File.SetAttributes(AppDomain.CurrentDomain.BaseDirectory, FileAttributes.Normal);
        using (StreamWriter sw = File.CreateText(strPath))
        {
            sw.Write(sbRecord.ToString());
            sbRecord = new StringBuilder(string.Empty);
        }

        return strPath;
    }

    public string GetTransactionReport(DataTable dt, string Filename)
    {
        MemoryStream ms = DataTableToExcelXlsx(dt, "Sheet1");

        string strPath = string.Empty;
        strPath = AppConfig.SitePath + @"temp\" + "Transaction_Report.xlsx";

        if (!Directory.Exists(AppConfig.SitePath + @"temp\"))
            Directory.CreateDirectory(AppConfig.SitePath + @"temp\");

        if (File.Exists(strPath))
            File.Delete(strPath);
        
        ms.Seek(0, SeekOrigin.Begin);
        FileStream outStream = File.OpenWrite(strPath);
        ms.WriteTo(outStream);
        outStream.Flush();
        outStream.Close();

        return strPath;
        //HttpContext.Current.Response.Clear();
        //ms.WriteTo(HttpContext.Current.Response.OutputStream);
        //HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + Filename);
        //HttpContext.Current.Response.StatusCode = 200;
        //HttpContext.Current.Response.End();
    }

    public static MemoryStream DataTableToExcelXlsx(DataTable table, string sheetName)
    {
        MemoryStream Result = new MemoryStream();
        ExcelPackage pack = new ExcelPackage();
        ExcelWorksheet ws = pack.Workbook.Worksheets.Add(sheetName);

        ws.Cells[1, 1].Value = "Transaction Report";
        ws.Cells[1, 1].Style.Font.Bold = true;
        ws.Cells[2, 1].Value = "From Sedgwick Spreadsheet";
        ws.Cells[2, 1].Style.Font.Bold = true;

        int col = 1;
        int row = 4;
        foreach (DataColumn column in table.Columns)
        {
            ws.Cells[row, col].Value = column.ColumnName.ToString();
            ws.Cells[row, col].Style.Font.Bold = true;
            col++;
            ws.Cells[row, col - 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
        }
        col = 1;
        row = 5;
        foreach (DataRow rw in table.Rows)
        {
            foreach (DataColumn cl in table.Columns)
            {
                if (rw[cl.ColumnName] != DBNull.Value)
                {
                    double num;
                    if (double.TryParse(rw[cl.ColumnName].ToString(), out num))
                    {
                        ws.Cells[row, col].Value = Convert.ToDecimal(rw[cl.ColumnName]);
                    }
                    else
                        ws.Cells[row, col].Value = rw[cl.ColumnName].ToString();

                    if (cl.ColumnName.ToString().ToLower() == "claim number" && rw[0].ToString().ToLower() == "zzz total - match")
                    {
                        ws.Cells[row, col].Style.Font.Bold = true;
                        ws.Cells[row, col].Value = ws.Cells[row, col].Value.ToString().Replace("zzz ", "");
                        ws.Cells[row, 2].Style.Font.Bold = true;
                        ws.Cells[row, 3].Style.Font.Bold = true;
                    }

                    if (cl.ColumnName.ToString().ToLower() == "claim number" && rw[0].ToString().ToLower() == "zzzz total - no match")
                    {
                        ws.Cells[row, col].Style.Font.Bold = true;
                        ws.Cells[row, col].Value = ws.Cells[row, col].Value.ToString().Replace("zzzz ", "");
                        ws.Cells[row, 2].Style.Font.Bold = true;
                        ws.Cells[row, 3].Style.Font.Bold = true;
                    } 
                    
                    if (cl.ColumnName.ToString().ToLower() == "transaction amount")
                    {
                        ws.Cells[row, col].Style.Numberformat.Format = "0.00";
                    }
                }
                
                col++;
                ws.Cells[row, col - 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            }
            row++;
            col = 1;
        }

        ws.Cells.Style.Font.Name = "Arial";
        ws.Cells.AutoFitColumns();
        ws.Column(1).Width = 30;
        ws.Cells.Style.Font.Size = 10;

        pack.SaveAs(Result);
        return Result;
    }
}
