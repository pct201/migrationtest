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
public partial class ERReports_Bordereau : clsBasePage
{
    #region "Variables"

    DataTable dtRegion, dtClaimData, dtTotal, dtPAInfo;
    string STR_Region;

    #endregion

    #region "Properties"
    /// <summary>
    /// Denotes the start date filter criteria for report
    /// </summary>
    private DateTime Start_Date
    {
        get { return Convert.ToDateTime(ViewState["SDate"]); }
        set { ViewState["SDate"] = value; }
    }

    /// <summary>
    /// Denotes the end date filter criteria for report
    /// </summary>
    private DateTime End_Date
    {
        get { return Convert.ToDateTime(ViewState["EDate"]); }
        set { ViewState["EDate"] = value; }
    }

    private string strTime
    {
        get { return Convert.ToString(ViewState["strTime"]); }
        set { ViewState["strTime"] = value; }
    }

    #endregion

    #region "Page Events"

    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // when page is loaded first time
        if (!IsPostBack)
        {
            // Get regions from database and bind region dropdown
            DataTable dtRegion = LU_Location.GetRegionList().Tables[0];
            drpRegion.DataSource = dtRegion;
            drpRegion.DataTextField = "region";
            drpRegion.DataValueField = "region";
            drpRegion.DataBind();
            drpRegion.Items.Insert(0, new ListItem("--All--", ""));

            //Fill Market
            ComboHelper.FillMarket(new DropDownList[] { ddlMarket }, true);

            // hide the export link
            lnkExport.Visible = false;
        }
    }
    #endregion

    #region "Other Controls Events"
    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    /// <summary>
    /// Handles Generate Report button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        strTime = "";
        // get start date
        Start_Date = clsGeneral.FormatDateToStore(txtStartDate);
        // get end date
        End_Date = clsGeneral.FormatDateToStore(txtEndDate);
        
        decimal? decMarket = null;
        if (ddlMarket.SelectedIndex > 0)
            decMarket = Convert.ToDecimal(ddlMarket.SelectedValue);

        // get result records from database for the report
        DataSet dsReport = ERReports.Get_Bordereau_Report(Start_Date, End_Date, drpRegion.SelectedValue, decMarket);

        // get data tables from result dataset
        dtClaimData = dsReport.Tables[0];
        dtRegion = dsReport.Tables[1];
        dtTotal = dsReport.Tables[2];
        dtPAInfo = dsReport.Tables[3];

        // bind the main grid having list of regions and total in footer
        gvReport.DataSource = dtRegion;
        gvReport.DataBind();

        // make visible the export link if data available
        lnkExport.Visible = (dtRegion.Rows.Count > 0);

        // set design settings according to the data availability
        if (dtRegion.Rows.Count > 0)
            divReport_Grid.Attributes.Add("style", "width:995px;overflow-x: scroll;overflow-y:hidden;");
        else
            divReport_Grid.Attributes.Add("style", "width:995px;height: 50px;overflow: hidden;");

        divReport_Grid.Style["display"] = "block";


    }

    /// <summary>
    /// Handles Export button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExport_Click(object sender, EventArgs e)
    {
        // set borders for tables and gridlines in grids to be displayed in excel file
        gvReport.GridLines = GridLines.Both;
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).FindControl("tblPAInfo")).Border = 1;
        ((HtmlTable)gvReport.FooterRow.FindControl("tblFooter")).Border = 1;
        foreach (GridViewRow gRow in gvReport.Rows)
        {
            GridView gvClaim = (GridView)gRow.FindControl("gvClaimData");
            gvClaim.GridLines = GridLines.Both;

            if (gvClaim != null)
            {
                foreach (GridViewRow gvRow in gvClaim.Rows)
                {
                    GridView gvInner = (GridView)gvRow.FindControl("grdDetail");

                    if (gvInner != null)
                    {
                        gvInner.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("");
                        gvInner.RowStyle.Font.Name = "";
                        gvInner.RowStyle.Font.Size = FontUnit.Empty;
                        gvInner.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("");
                        gvInner.AlternatingRowStyle.Font.Name = "";
                        gvInner.AlternatingRowStyle.Font.Size = FontUnit.Empty;
                        gvInner.GridLines = GridLines.Both;
                    }
                }
            }

        }

        // export data to excel from gridview
        GridViewExportUtil.ExportGrid("Bordereau_Report.xlsx", gvReport);

        // reset the settings
        gvReport.GridLines = GridLines.None;
        foreach (GridViewRow gRow in gvReport.Rows)
        {
            GridView gvClaim = (GridView)gRow.FindControl("gvClaimData");
            gvClaim.GridLines = GridLines.None;
        }
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvReport.FooterRow.FindControl("tblFooter")).Border = 0;
    }
    #endregion

    #region "GridView Events"

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

            // set text for the cell
            if (strTime == "") strTime = string.Format("{0:t}", DateTime.Now);
            string strCellText = "FINPRO Bordereau Report<br />" + DateTime.Now.ToLongDateString() + " " + strTime + "<br/>";
            string strFromDate = clsGeneral.FormatDateToDisplay(Start_Date);
            string strToDate = clsGeneral.FormatDateToDisplay(End_Date);
            Cell.Text = strCellText + "Date Claim Opened Between " + strFromDate + " and " + strToDate;

            // add cell in row
            gRow.Cells.Add(Cell);

            // add row in gridview header
            ((Table)gvReport.Controls[0]).Rows.AddAt(0, gRow);

        }
    }

    /// <summary>
    /// Handles rowdatabound event for main grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check if the row is datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the subgrid
            GridView gvClaimData = (GridView)e.Row.FindControl("gvClaimData");

            // get region of the row
            string strRegion = DataBinder.Eval(e.Row.DataItem, "Region").ToString();
            STR_Region = strRegion;

            // create a dataview from datatable for claim data
            DataView dvDetail = new DataView();
            dvDetail = dtClaimData.DefaultView;

            // get filtered data for the region
            dvDetail.RowFilter = "Region='" + strRegion + "'";

            // bind the subgrid
            DataTable dtReport = dvDetail.ToTable();
            gvClaimData.DataSource = dtReport;
            gvClaimData.DataBind();
        }
        else if (e.Row.RowType == DataControlRowType.Footer) // if the row is footer row
        {
            // get labels for total and total estimated exposure
            Label lblTotal = (Label)e.Row.FindControl("lblFTotal");
            Label lblTotalExposure = (Label)e.Row.FindControl("lblFTotalExposure");

            // get the datarow from datatable for total and set values in labels
            DataRow dr = dtTotal.Rows[0];
            lblTotal.Text = dr["Total"].ToString();
            lblTotalExposure.Text = "$ " + clsGeneral.GetStringValue(dr["Total_Exposure"]);
        }
    }

    /// <summary>
    /// Handles row data bound for subgrid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Int32 PK_Exe = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PK_Executive_Risk"));

            // get the subgrid
            GridView grdDetail = (GridView)e.Row.FindControl("grdDetail");

            // create a dataview from datatable for claim data
            DataView dvDetail = new DataView();
            dvDetail = dtPAInfo.DefaultView;

            // get filtered data for the region
            dvDetail.RowFilter = " FK_Executive_Risk = " + PK_Exe.ToString() + " ";

            // bind the subgrid
            DataTable dtReport = dvDetail.ToTable();
            grdDetail.DataSource = dtReport;
            grdDetail.DataBind();
        }

        // if row is footer row
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            // get the labels for total and total estimated exposure
            Label lblTotal = (Label)e.Row.FindControl("lblTotal");
            Label lblTotalExposure = (Label)e.Row.FindControl("lblTotalExposure");

            // get the total from datatable for regions and set values in labels
            DataRow[] dr = dtRegion.Select("Region='" + STR_Region + "'");
            lblTotal.Text = dr[0]["Total"].ToString();
            lblTotalExposure.Text = "$ " + clsGeneral.GetStringValue(dr[0]["Total_Exposure"]);
        }
    }
    #endregion
}
