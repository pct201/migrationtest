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

    public static void ExportGrid(string fileNameToSave, GridView gvReportGrid)
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

    public static void ExportGrid(string fileNameToSave, GridView gvReportGrid,string css)
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

        HttpContext.Current.Response.Write("<html><head><style type='text/css'>" + css + "</style></head><body>" + stringWrite.ToString() + "</body></html>");
        //HttpContext.Current.Response.Write(stringWrite.ToString());
        HttpContext.Current.Response.End();
    }
}
