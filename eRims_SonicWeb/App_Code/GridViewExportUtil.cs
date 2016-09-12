using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Generic;
/// <summary>
/// 
/// </summary>
public class GridViewExportUtil
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="gv"></param>
    public static void Export(string fileName, GridView gv)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader(
            "content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                //  Create a table to contain the grid
                Table table = new Table();

                //  include the gridline settings
                table.GridLines = gv.GridLines;

                //  add the header row to the table
                if (gv.HeaderRow != null)
                {
                    gv.HeaderRow.Controls.RemoveAt(0);
                    GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }

                //  add each of the data rows to the table
                foreach (GridViewRow row in gv.Rows)
                {
                    row.Controls.RemoveAt(0);
                    GridViewExportUtil.PrepareControlForExport(row);
                    table.Rows.Add(row);
                }

                //  add the footer row to the table
                if (gv.FooterRow != null)
                {

                    GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                //  render the table into the htmlwriter
                table.RenderControl(htw);

                //  render the htmlwriter into the response
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }

    /// <summary>
    /// Replace any of the contained controls with literals
    /// </summary>
    /// <param name="control"></param>
    private static void PrepareControlForExport(Control control)
    {

        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }

            if (current.HasControls())
            {
                GridViewExportUtil.PrepareControlForExport(current);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="gv"></param>
    public static void ExportAdHoc(string fileName, GridView gv)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader(
            "content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                //  Create a table to contain the grid
                Table table = new Table();

                //  include the gridline settings
                table.GridLines = gv.GridLines;

                //  add the header row to the table
                if (gv.HeaderRow != null)
                {
                    //gv.HeaderRow.Controls.RemoveAt(0);
                    GridViewExportUtil.PrepareControlForExportAdHoc(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }

                //  add each of the data rows to the table
                foreach (GridViewRow row in gv.Rows)
                {
                    //row.Controls.RemoveAt(0);
                    GridViewExportUtil.PrepareControlForExportAdHoc(row);
                    table.Rows.Add(row);
                }

                //  add the footer row to the table
                if (gv.FooterRow != null)
                {

                    GridViewExportUtil.PrepareControlForExportAdHoc(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                //  render the table into the htmlwriter
                table.RenderControl(htw);

                //  render the htmlwriter into the response
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="gv"></param>
    public static string ExportAdHoc_New(GridView gv)
    {

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                //  Create a table to contain the grid
                Table table = new Table();

                //  include the gridline settings
                table.GridLines = gv.GridLines;

                //  add the header row to the table
                if (gv.HeaderRow != null)
                {
                    //gv.HeaderRow.Controls.RemoveAt(0);
                    GridViewExportUtil.PrepareControlForExportAdHoc(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }

                //  add each of the data rows to the table
                foreach (GridViewRow row in gv.Rows)
                {
                    //row.Controls.RemoveAt(0);
                    GridViewExportUtil.PrepareControlForExportAdHoc(row);
                    table.Rows.Add(row);
                }

                //  add the footer row to the table
                if (gv.FooterRow != null)
                {

                    GridViewExportUtil.PrepareControlForExportAdHoc(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                //  render the table into the htmlwriter
                table.RenderControl(htw);

                string data = sw.ToString();
                HttpContext.Current.Response.Write(sw.ToString());
                return data;
                //HttpContext.Current.Response.End();
            }
        }
    }

    /// <summary>
    /// Replace any of the contained controls with literals
    /// </summary>
    /// <param name="control"></param>
    private static void PrepareControlForExportAdHoc(Control control)
    {

        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is LinkButton)
            {
                //control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                //control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                //control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                //control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                //control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }
            else if (current is HtmlImage)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HtmlImage).Alt));
            }

            if (current.HasControls())
            {
                GridViewExportUtil.PrepareControlForExportAdHoc(current);
            }
        }
    }

    public static void ExportGrid_Old(string fileNameToSave, GridView gvReportGrid)
    {
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        gvReportGrid.RenderControl(htmlWrite);

        MemoryStream memorystream = new MemoryStream();
        byte[] _bytes = Encoding.UTF8.GetBytes(stringWrite.ToString());
        memorystream.Write(_bytes, 0, _bytes.Length);
        memorystream.Seek(0, SeekOrigin.Begin);

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader(
            "content-disposition", string.Format("attachment; filename={0}", fileNameToSave));
        HttpContext.Current.Response.ContentType = "application/ms-excel";

        HttpContext.Current.Response.Write(stringWrite.ToString());
        HttpContext.Current.Response.End();
    }

    public static void ExportGrid(string fileNameToSave, GridView gvReportGrid,bool isGrid)
    {
        try
        {
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            MemoryStream memorystream = new MemoryStream();
            String strPath = String.Empty, data = String.Empty, outputFiles = String.Empty;

            gvReportGrid.RenderControl(htmlWrite);

            byte[] _bytes = Encoding.UTF8.GetBytes(stringWrite.ToString());
            memorystream.Write(_bytes, 0, _bytes.Length);
            memorystream.Seek(0, SeekOrigin.Begin);

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
            objHtml2Excel.isGrid = isGrid;
            objHtml2Excel.isUseCSS = false;
            outputFiles = Path.GetFullPath(strPath) + ".xlsx";
            bool blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);

            if (blnHTML2Excel)
            {
                try
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"" + fileNameToSave + "\""));
                    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
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
            else
            {
                try
                {
                    fileNameToSave.Replace(".xlsx", ".xls");
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"" + fileNameToSave + "\""));
                    HttpContext.Current.Response.ContentType = "application/ms-excel";
                    HttpContext.Current.Response.TransmitFile(strPath);
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
        catch (Exception ex)
        {

        }
    }

    public static void ExportGrid(string fileNameToSave, GridView gvReportGrid, bool isGrid, List<System.Collections.Generic.KeyValuePair<int, double>> columnWidth)
    {
        try
        {
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            MemoryStream memorystream = new MemoryStream();
            String strPath = String.Empty, data = String.Empty, outputFiles = String.Empty;

            gvReportGrid.RenderControl(htmlWrite);

            byte[] _bytes = Encoding.UTF8.GetBytes(stringWrite.ToString());
            memorystream.Write(_bytes, 0, _bytes.Length);
            memorystream.Seek(0, SeekOrigin.Begin);

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
            objHtml2Excel.isGrid = isGrid;
            objHtml2Excel.isUseCSS = false;
            objHtml2Excel.columnWidth = columnWidth;
            outputFiles = Path.GetFullPath(strPath) + ".xlsx";
            bool blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);

            if (blnHTML2Excel)
            {
                try
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"" + fileNameToSave + "\""));
                    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
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
            else
            {
                try
                {
                    fileNameToSave.Replace(".xlsx", ".xls");
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"" + fileNameToSave + "\""));
                    HttpContext.Current.Response.ContentType = "application/ms-excel";
                    HttpContext.Current.Response.TransmitFile(strPath);
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
        catch (Exception ex)
        {

        }
    }

    public static void ExportGrid(string fileNameToSave, Label lblReport)
    {
        try
        {
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            lblReport.RenderControl(htmlWrite);
            String strPath = String.Empty, data = String.Empty, outputFiles = String.Empty;
            string strcols = "border: #7f7f7f 1px solid;vertical-align: top;font-size: 8pt;border-collapse: collapse;";

            MemoryStream memorystream = new MemoryStream();
            byte[] _bytes = Encoding.UTF8.GetBytes(stringWrite.ToString().Replace("border-top:#EAEAEA", "border-top:#000000").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>"));
            memorystream.Write(_bytes, 0, _bytes.Length);
            memorystream.Seek(0, SeekOrigin.Begin);

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
            objHtml2Excel.isGrid = false;
            objHtml2Excel.isUseCSS = false;
            outputFiles = Path.GetFullPath(strPath) + ".xlsx";
            bool blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);

            if (blnHTML2Excel)
            {
                try
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"" + fileNameToSave + "\""));
                    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
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
        catch (Exception ex) { }
    }

    public static void ExportGrid(string fileNameToSave, GridView gvReportGrid, string css)
    {
        try
        {
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            String strPath = String.Empty, data = String.Empty, outputFiles = String.Empty;

            gvReportGrid.RenderControl(htmlWrite);

            MemoryStream memorystream = new MemoryStream();
            byte[] _bytes = Encoding.UTF8.GetBytes("<html><head><style type='text/css'>" + css + "</style></head><body>" + stringWrite.ToString() + "</body></html>");
            memorystream.Write(_bytes, 0, _bytes.Length);
            memorystream.Seek(0, SeekOrigin.Begin);

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
            objHtml2Excel.isGrid = true;
            objHtml2Excel.isUseCSS = false;
            outputFiles = Path.GetFullPath(strPath) + ".xlsx";
            bool blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);

            if (blnHTML2Excel)
            {
                try
                {
                    HttpContext.Current.Response.Clear();
                    //HttpContext.Current.Response.AddHeader("content-disposition", "attachment;  filename=products.xlsx");
                    HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"" + fileNameToSave + "\""));
                    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
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
        catch (Exception ex) { }

    }
}
