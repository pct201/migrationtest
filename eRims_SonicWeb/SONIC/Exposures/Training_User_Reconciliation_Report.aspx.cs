using ERIMS.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class SONIC_Exposures_Training_User_Reconciliation_Report : System.Web.UI.Page
{

    private string strTime
    {
        get { return Convert.ToString(ViewState["strTime"]); }
        set { ViewState["strTime"] = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    /// <summary>
    /// Bind Grid
    /// </summary>
    private void BindGrid()
    {
        DataTable dtEmployeeData = Employee.GetEmployeeTrainingUserReconciliation().Tables[0];
        gvReport.DataSource = dtEmployeeData;
        gvReport.DataBind();

        if (dtEmployeeData.Rows.Count > 0)
            dvReport.Attributes.Add("style", "width:995px;overflow-x:scroll;overflow-y:hidden;");
        else
            dvReport.Attributes.Add("style", "width:995px;height:50px;overflow:hidden;");

        lnkExportToExcel.Visible = (dtEmployeeData.Rows.Count > 0);
    }

    /// <summary>
    /// handle Export To Excel Link button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        // show gridlines to be shown in excel
        gvReport.GridLines = GridLines.Both;
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 1;

        foreach (GridViewRow gRow in gvReport.Rows)
        {
            ((HtmlTable)gRow.FindControl("tblDetails")).Border = 1;
        }

        // export gridview to excel
        GridViewExportUtil.ExportGrid("TrainingUserReconciliationreport.xlsx", gvReport, false);

        // hide gridlines
        gvReport.GridLines = GridLines.None;
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 0;

        foreach (GridViewRow gRow in gvReport.Rows)
        {
            ((HtmlTable)gRow.FindControl("tblDetails")).Border = 0;
        }
    }

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    /// <summary>
    /// Handles an event when row is created in main grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // if the row is header
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // create a new gridview row in header row
            GridViewRow gRow = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
            gRow.Font.Bold = true;
           
            // create a table cell to be added in row
            TableCell Cell = new TableCell();
            Cell.ColumnSpan = 9;
            // set text for the cell
            if (strTime == "") strTime = string.Format("{0:t}", DateTime.Now);
            string strCellText = "<br />Training User Reconciliation Report<br />" + DateTime.Now.ToShortDateString() + " " + strTime + "<br/><br/>";
            Cell.Text = strCellText;

            // add cell in row
            gRow.Cells.Add(Cell);

            // add row in gridview header
            ((Table)gvReport.Controls[0]).Rows.AddAt(0, gRow);
        }
    }
}