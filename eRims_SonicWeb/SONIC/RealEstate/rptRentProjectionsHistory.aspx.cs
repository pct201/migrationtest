using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class SONIC_RealEstate_rptRentProjectionsHistory : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Bind Drop down
            BindDropDownList();
            // set focus to first field
            lstLocation.Focus();
        }
    }

    #region "Events"

    /// <summary>
    /// handle grid view row created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gRow = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
            gRow.Font.Bold = true;

            // create a table cell to be added in row
            TableCell Cell = new TableCell();
            Cell.Text = "Sonic Automotive";
            Cell.ColumnSpan = 2;
            Cell.HorizontalAlign = HorizontalAlign.Left;
            // add cell in row
            gRow.Cells.AddAt(0, Cell);

            Cell = new TableCell();
            Cell.HorizontalAlign = HorizontalAlign.Center;
            Cell.Text = "Rent Projections/History";
            Cell.ColumnSpan = 3;
            // add cell in row
            gRow.Cells.AddAt(1, Cell);

            Cell = new TableCell();
            Cell.HorizontalAlign = HorizontalAlign.Right;
            Cell.Text = DateTime.Now.ToString();
            Cell.ColumnSpan = 3;
            // add cell in row
            gRow.Cells.AddAt(2, Cell);

            // add row in gridview header
            ((Table)gvReport.Controls[0]).Rows.AddAt(0, gRow);
        }
    }

    /// <summary>
    /// handle Export To Excel Link button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        //btnShowReport_Click(sender, e);
        gvReport.GridLines = GridLines.Both;

        // set fore color and back color
        foreach (TableCell tc in gvReport.FooterRow.Cells)
        {
            tc.ForeColor = System.Drawing.Color.White;
            tc.BackColor = System.Drawing.ColorTranslator.FromHtml("#507cd1");
        }
        // export gridview to excel
        GridViewExportUtil.ExportGrid("LeaseTerm.xls", gvReport);
        gvReport.GridLines = GridLines.None;
    }

    /// <summary>
    /// Handle Button Show Report click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        Int16? intRentYearFrom = null, intRentYearTo = null;
        string strLocation = string.Empty, strLeaseType = string.Empty, strEscalation = string.Empty;
        DataSet dsResult;

        // get selected Location DBA
        foreach (ListItem li in lstLocation.Items)
        {
            if (li.Selected)
                strLocation = strLocation + "'" + li.Value + "',";
        }
        strLocation = strLocation.TrimEnd(',');

        // get selected Lease Type
        foreach (ListItem li in ddlLeaseType.Items)
        {
            if (li.Selected)
                strLeaseType = strLeaseType + li.Value + ",";
        }
        strLeaseType = strLeaseType.TrimEnd(',');

        // get selected Lease Type
        foreach (ListItem li in lstEscalationType.Items)
        {
            if (li.Selected)
                strEscalation = strEscalation + li.Value + ",";
        }
        strEscalation = strEscalation.TrimEnd(',');

        if (!string.IsNullOrEmpty(txtRentYearFrom.Text.Trim()))
            intRentYearFrom = Convert.ToInt16(txtRentYearFrom.Text);

        if (!string.IsNullOrEmpty(txtRentYearTo.Text.Trim()))
            intRentYearTo = Convert.ToInt16(txtRentYearTo.Text);

        // get report result from database
        dsResult = Report.GetRentProjectionsHistory(strLocation, strLeaseType, intRentYearFrom, intRentYearTo, strEscalation);

        // bind grid view
        gvReport.DataSource = dsResult;
        gvReport.DataBind();
        dvGrid.Visible = true;

        // check any row is found or not.
        lnkExportToExcel.Visible = (gvReport.Rows.Count > 0);

    }

    /// <summary>
    /// handle Clear Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        // reload the page
        Response.Redirect(Request.AppRelativeCurrentExecutionFilePath);
    }

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind Drop Down List
    /// </summary>    
    private void BindDropDownList()
    {
        // Fill Location by Employee        
        ComboHelper.FillLocationdbaOnlyListBox(new ListBox[] { lstLocation },0, false,false);
        lstLocation.Style.Remove("font-size");

        //Lease Type
        ComboHelper.FillLeaseTypeListBox(new ListBox[] { ddlLeaseType }, false);

        //Escalation Type 
        DataTable dtData = LU_Escalation.SelectAll().Tables[0];
        lstEscalationType.DataSource = dtData;
        lstEscalationType.DataTextField = "Fld_Desc";
        lstEscalationType.DataValueField = "PK_LU_Escalation";
        lstEscalationType.DataBind();
        clsGeneral.DisposeOf(dtData);
    }

    #endregion
}
