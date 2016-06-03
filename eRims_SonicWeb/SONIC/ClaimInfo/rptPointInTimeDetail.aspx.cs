using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ERIMS.DAL;

public partial class SONIC_ClaimInfo_rptPointInTimeDetail : clsBasePage
{
    #region Properties

    private string strAccidentDateFrom
    {
        get { return Convert.ToString(ViewState["strAccidentDateFrom"]); }
        set { ViewState["strAccidentDateFrom"] = value; }
    }

    private string strAccidentDateTo
    {
        get { return Convert.ToString(ViewState["strAccidentDateTo"]); }
        set { ViewState["strAccidentDateTo"] = value; }
    }

    #endregion

    #region Events

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Clear All previous messaged.
        lblMessage.Text = "";
        if (!IsPostBack)
        {
          
        }
    }

    /// <summary>
    /// Bind the report gid with data using selected filters and display report
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        BindReport();
        pnlReport.Visible = true;        
    }

    /// <summary>
    /// Use to Export the Report GridView in to the Excel Sheet.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        gvReport.GridLines = GridLines.Both;
        GridViewExportUtil.ExportGrid("DetailPITComparisonReport.xlsx", gvReport, true);
        gvReport.GridLines = GridLines.None;
    }

    /// <summary>
    /// Clears All the selected filters value
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        Response.Redirect("rptPointInTimeDetail.aspx", false);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Binds the report gridview with the data as per filter selection
    /// </summary>
    private void BindReport()
    {
        string _strClaimType = string.Empty;
        //Prepare comma seprated list of selected claim type
        foreach (ListItem li in lsbClaimType.Items)
        {
            if (li.Selected == true)
                _strClaimType = (_strClaimType == "") ? li.Value.ToString() : _strClaimType + "," + li.Value.ToString();
        }

        strAccidentDateFrom = txtLossFromDate.Text;
        strAccidentDateTo = txtLossToDate.Text;
        //get the data for the report
        DataSet dsReport = clsClaimReports.GetPointInTimeDetailData(Convert.ToDateTime(txtCompDate1.Text),
                                                    Convert.ToDateTime(txtCompDate2.Text),
                                                    Convert.ToDateTime(txtLossFromDate.Text),
                                                    Convert.ToDateTime(txtLossToDate.Text),
                                                    _strClaimType);

        //Bind the report grid
        gvReport.DataSource = dsReport.Tables[0];
        gvReport.DataBind();
        if (gvReport.Rows.Count > 0)
        {
            //Set the selected first and second date in the Grid header.
            ((Label)gvReport.HeaderRow.FindControl("lblDate1")).Text = txtCompDate1.Text;
            ((Label)gvReport.HeaderRow.FindControl("lblDate2")).Text = txtCompDate2.Text;
            tblUtility.Visible = true;
        }
        else
            tblUtility.Visible = false;
    }

    protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // create a new gridview row in header row
            GridViewRow gRow = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
            gRow.Font.Bold = true;
            // create a table cell to be added in row
            TableCell Cell1 = new TableCell();
            Cell1.ColumnSpan = 3;
            Cell1.HorizontalAlign = HorizontalAlign.Left;
            Cell1.Text = "<b>Historical Detail Changes Report</b>";
                
            // add cell in row
            gRow.Cells.Add(Cell1);

            TableCell Cell2 = new TableCell();
            Cell2.ColumnSpan = 3;
            Cell2.HorizontalAlign = HorizontalAlign.Right;
            Cell2.Text = "<b>Losses from " + strAccidentDateFrom + " To " + strAccidentDateTo + "</b>";
            // add cell in row
            gRow.Cells.Add(Cell2);

            // add row in gridview header
            ((Table)gvReport.Controls[0]).Rows.AddAt(0, gRow);
        }
    }
    #endregion
}
