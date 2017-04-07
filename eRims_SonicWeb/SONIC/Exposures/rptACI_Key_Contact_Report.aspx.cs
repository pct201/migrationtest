using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using OfficeOpenXml;

public partial class SONIC_Exposures_rptACI_Key_Contact_Report : clsBasePage
{
    #region "Page Event"

    /// <summary>
    /// handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindListBoxes();
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind List Box
    /// </summary>
    private void BindListBoxes()
    {
        // get regions for user having access to and bind the regions list box
        //DataTable dtRegions = clsClaimReports.SelectRegions().Tables[0];
        //lstRegions.DataSource = dtRegions;
        //lstRegions.DataTextField = "region";
        //lstRegions.DataValueField = "region";
        //lstRegions.DataBind();

        ComboHelper.FillLocationdbaOnlyListBox(new ListBox[] { lstLocationDBA }, 0, false,false);

    }

    /// <summary>
    /// Get Comma separated List items
    /// </summary>
    /// <param name="lst"></param>
    /// <returns></returns>
    private string GetCommaSeparatedValues(ListBox lst)
    {
        string strRegion = string.Empty;
        foreach (ListItem itmRegion in lst.Items)
        {
            if (itmRegion.Selected)
                strRegion = strRegion + itmRegion.Value + ",";
        }
        strRegion = strRegion.TrimEnd(',');
        return strRegion;
    }

    /// <summary>
    /// This method is added for export Gird view To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    #endregion

    #region "Events"
    /// <summary>
    /// Handles Show Report button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        trSearch.Visible = false;
        trResult.Visible = true;

        //string strRegion = "";
        string strJob_Titles, strDba = string.Empty;

        //strRegion = GetCommaSeparatedValues(lstRegions);// get selected regions
        strDba = GetCommaSeparatedValues(lstLocationDBA);
        strJob_Titles = GetCommaSeparatedValues(lstJob_Titles);

        DataSet dsReport = clsExposuresReports.GetACI_Key_Contact_Report(strDba, strJob_Titles);
        DataTable dtContact_Report = dsReport.Tables[0];

        gvKey_Contact.DataSource = dtContact_Report;
        gvKey_Contact.DataBind();
        if (gvKey_Contact.Rows.Count > 0)
        {
            lbtExportToExcel.Visible = true;
            gvKey_Contact.Width = 1600;
        }
        else
        {
            lbtExportToExcel.Visible = false;
            gvKey_Contact.Width = 997;
        }
    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        // load the page again to clear selection
        //lstRegions.ClearSelection();
        lstJob_Titles.ClearSelection();
        lstLocationDBA.ClearSelection();
    }

    /// <summary>
    /// Back from report to Criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        trSearch.Visible = true;
        trResult.Visible = false;
    }

    /// <summary>
    /// Handles Export to Excel link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        //gvDescription.ShowHeader = true;       
        //gvKey_Contact.GridLines = GridLines.Both;       
        // export data to excel from grid view
       // GridViewExportUtil.ExportGrid("ACI Key Contact Report.xls", gvKey_Contact);
        // gvDescription.ShowHeader = false;
        //gvKey_Contact.GridLines = GridLines.None;

        string strJob_Titles, strDba = string.Empty;
        strDba = GetCommaSeparatedValues(lstLocationDBA);
        strJob_Titles = GetCommaSeparatedValues(lstJob_Titles);

        DataSet dsReport = clsExposuresReports.GetACI_Key_Contact_Report(strDba, strJob_Titles);
        DataTable dtContact_Report = dsReport.Tables[0];

        dtContact_Report.Columns["dba"].ColumnName = "DBA";
        dtContact_Report.Columns["address_1"].ColumnName = "Store Address 1";
        dtContact_Report.Columns["address_2"].ColumnName = "Store Address 2";
        dtContact_Report.Columns["city"].ColumnName = "Store City";
        dtContact_Report.Columns["State"].ColumnName = "Store State";
        dtContact_Report.Columns["zip_code"].ColumnName = "Store Zip";
        dtContact_Report.Columns["Sonic_Location_Code"].ColumnName = "Location Code";
        dtContact_Report.Columns["job_title"].ColumnName = "Job Title";
        dtContact_Report.Columns["first_name"].ColumnName = "First Name";
        dtContact_Report.Columns["last_name"].ColumnName = "Last Name";
        dtContact_Report.Columns["email"].ColumnName = "Email Address";
        dtContact_Report.Columns["employee_cell_Phone"].ColumnName = "Cell Phone";
        dtContact_Report.Columns["work_Phone"].ColumnName = "Work Phone";
        //dtContact_Report.Columns["Secondary_Cost_Center"].ColumnName = "Secondary Cost Center";
        //dtContact_Report.Columns["FK_Cost_Center"].ColumnName = "Cost Center";
        ToExcel(dtContact_Report, "ACI Key Contact Report.xlsx");
    }

    public void ToExcel(DataTable dt, string Filename)
    {
        MemoryStream ms = DataTableToExcelXlsx(dt, "Sheet1");
        HttpContext.Current.Response.Clear();
        ms.WriteTo(HttpContext.Current.Response.OutputStream);
        HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + Filename);
        HttpContext.Current.Response.StatusCode = 200;
        HttpContext.Current.Response.End();
    }

    public static MemoryStream DataTableToExcelXlsx(DataTable table, string sheetName)
    {
        MemoryStream Result = new MemoryStream();
        ExcelPackage pack = new ExcelPackage();
        ExcelWorksheet ws = pack.Workbook.Worksheets.Add(sheetName);
        int col = 1;
        int row = 1;

        ws.Column(1).Width = 32;
        ws.Column(2).Width = 22;
        ws.Column(3).Width = 22;
        ws.Column(4).Width = 15;
        ws.Column(5).Width = 10;
        ws.Column(7).Width = 20;
        ws.Column(8).Width = 20;
        ws.Column(9).Width = 18;
        ws.Column(10).Width = 18;
        ws.Column(11).Width = 30;
        ws.Column(12).Width = 15;
        ws.Column(13).Width = 15;

        ws.Column(6).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
        ws.Column(7).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
        

        foreach (DataColumn column in table.Columns)
        {
            ws.Cells[row, col].Value = column.ColumnName.ToString();
            ws.Cells[row, col].Style.Font.Bold = true;
            col++;
        }
        col = 1;
        row = 2;
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
                }

                col++;
            }
            row++;
            col = 1;
        }
        pack.SaveAs(Result);
        return Result;
    }
    #endregion
}