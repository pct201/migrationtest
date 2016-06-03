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
public partial class SONIC_ClaimInfo_rptLossLimitation : clsBasePage
{
    #region "Variables"

    // data tables that will be used for report
    DataTable dtRegion, dtDetails, dtRegionTotal, dtGrandTotal;
    string STR_Region;
    #endregion

    #region "Page Events"

    /// <summary>
    /// Handles page load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //Clear All previous messaged.
        lblMessage.Text = "";

        // if page is loaded first time
        if (!IsPostBack)
        {
            this.txtLimit1.Focus();
            this.pnlReport.Visible = false;
            this.tblUtility.Visible = false;
        }
    }
    #endregion

    #region "Control Events"
    /// <summary>
    /// Handles Clear Criteria button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        // redirect to same page to clear all selections
        Response.Redirect("rptLossLimitation.aspx", false);
    }

    /// <summary>
    /// Handles Export To Excel link button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        // set grid lines and table borders to be displayed in excel sheet
        ((HtmlTable)gvRegion.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvRegion.FooterRow.FindControl("tblFooter")).Border = 1;
        gvRegion.GridLines = GridLines.Both;
        foreach (GridViewRow gRow in gvRegion.Rows)
        {
            ((GridView)gRow.FindControl("gvLossLimitation")).GridLines = GridLines.Both;
        }

        // export grid into excel document
        GridViewExportUtil.ExportGrid("LossLimitationReport.xlsx", gvRegion, true);

        // remove grid lines and table borders
        gvRegion.GridLines = GridLines.None;
        foreach (GridViewRow gRow in gvRegion.Rows)
        {
            ((GridView)gRow.FindControl("gvLossLimitation")).GridLines = GridLines.None;
        }
        ((HtmlTable)gvRegion.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvRegion.FooterRow.FindControl("tblFooter")).Border = 0;
    }

    /// <summary>
    /// Handles Show Report button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        string _strClaimType = string.Empty;

        // get Selected Claim Type in Comm seperated value like ",1,2,"
        foreach (ListItem li in lsbClaimType.Items)
        {
            if (li.Selected == true)
            {
                _strClaimType = _strClaimType + li.Text + ", ";
            }
        }

        int i = 1;

        lblHeader.Text = "Accident Date Range " + i.ToString() + " : " + txtLossFromDate1.Text + " &nbsp;&nbsp;&nbsp;&nbsp; TO : " + txtLossToDate1.Text + " &nbsp;&nbsp;&nbsp;&nbsp; Limit : " + txtLimit1.Text;

        // if all theee value for Date of loss range is enter then print it.
        if (txtLimit2.Text.Trim() != "" && txtLossFromDate2.Text != "" && txtLossToDate2.Text != "")
        {
            i++;
            lblHeader.Text = lblHeader.Text + " <br> Accident Date Range " + i.ToString() + " : " + txtLossFromDate2.Text + " &nbsp;&nbsp;&nbsp;&nbsp; TO : " + txtLossToDate2.Text + "  &nbsp;&nbsp;&nbsp;&nbsp; Limit : " + txtLimit2.Text.Trim();
        }

        if (txtLimit3.Text.Trim() != "" && txtLossFromDate3.Text != "" && txtLossToDate3.Text != "")
        {
            i++;
            lblHeader.Text = lblHeader.Text + " <br> Accident Date Range " + i.ToString() + " : " + txtLossFromDate3.Text + " &nbsp;&nbsp;&nbsp;&nbsp; TO : " + txtLossToDate3.Text + " &nbsp;&nbsp;&nbsp;&nbsp; Limit : " + txtLimit3.Text.Trim();
        }

        lblHeader.Text = lblHeader.Text + " <br> Claim Type : " + _strClaimType.TrimEnd(' ').TrimEnd(',');

        // Bind the report grid
        FillGrid();

        this.pnlReport.Visible = true;

    }
    #endregion

    #region "Methods"
    /// <summary>
    /// Binds the report grid
    /// </summary>
    private void FillGrid()
    {
        // dataset that will hold the report data
        DataSet dsLossLimitation;
        string _strClaimType = string.Empty;

        // get Selected Claim Type in Comm seperated value like ",1,2,"
        foreach (ListItem li in lsbClaimType.Items)
        {
            if (li.Selected == true)
            {
                _strClaimType = (_strClaimType == "") ? "," + li.Value.ToString() + "," : _strClaimType + li.Value.ToString() + ",";
            }
        }

        // If Date range is not enter for any of the Loss limit then Pass SQL Max Date value as loss From Date 
        //  and SQL Min Date as Loss To Date
        dsLossLimitation = clsClaimReports.GetLossLimitationData(Convert.ToDateTime(txtLossFromDate1.Text), Convert.ToDateTime(txtLossToDate1.Text), decimal.Parse(txtLimit1.Text),
                                    DateTime.Parse((txtLossFromDate2.Text != "") ? txtLossFromDate2.Text : System.Data.SqlTypes.SqlDateTime.MaxValue.ToString()), DateTime.Parse((txtLossToDate2.Text != "") ? txtLossToDate2.Text : System.Data.SqlTypes.SqlDateTime.MinValue.ToString()), ((txtLimit2.Text != "") ? decimal.Parse(txtLimit2.Text) : 0),
                                    DateTime.Parse((txtLossFromDate3.Text != "") ? txtLossFromDate3.Text : System.Data.SqlTypes.SqlDateTime.MaxValue.ToString()), DateTime.Parse((txtLossToDate3.Text != "") ? txtLossToDate3.Text : System.Data.SqlTypes.SqlDateTime.MinValue.ToString()), ((txtLimit3.Text != "") ? decimal.Parse(txtLimit3.Text) : 0),
                                    _strClaimType);

        // get data tables from dataset
        dtRegion = dsLossLimitation.Tables[0];
        dtDetails = dsLossLimitation.Tables[1];
        dtRegionTotal = dsLossLimitation.Tables[2];
        dtGrandTotal = dsLossLimitation.Tables[3];

        // bind the region grid
        gvRegion.DataSource = dtRegion;
        gvRegion.DataBind();

        // if record found for Selected Criteria then display Total in footer
        if (dsLossLimitation.Tables[0].Rows.Count > 0)
        {
            this.lbtExportToExcel.Visible = true;
            tblUtility.Visible = true;
        }
        else
        {
            tblUtility.Visible = false;
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

    #endregion

    #region "Grid Events"

    /// <summary>
    /// Handles event when Region grid row is created
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRegion_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // set main header to be displayed in excel sheet
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((HtmlTableCell)e.Row.FindControl("tdHeader1")).InnerHtml = lblHeader.Text;
        }
    }

    /// <summary>
    /// Handles RowDataBound event when row is generated in Region grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRegion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get details for specific region from datatable having details data
            DataView dvDetails = dtDetails.DefaultView;
            STR_Region = DataBinder.Eval(e.Row.DataItem, "Region").ToString();
            dvDetails.RowFilter = "Region='" + STR_Region + "'";

            //bind the sub grid for Region grid 
            GridView gvLossLimitation = e.Row.FindControl("gvLossLimitation") as GridView;
            gvLossLimitation.DataSource = dvDetails.ToTable();
            gvLossLimitation.DataBind();
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            // set totals in footer
            ((Label)e.Row.FindControl("lblTotalClaimCount")).Text = string.Format("{0:#,0}", dtGrandTotal.Rows[0][0]);
            ((Label)e.Row.FindControl("lblTotalIncurred")).Text = string.Format("{0:C}", dtGrandTotal.Rows[0][1]);
            ((Label)e.Row.FindControl("lblLimitedIncurred")).Text = string.Format("{0:C}", dtGrandTotal.Rows[0][2]);
            ((Label)e.Row.FindControl("lblExcess")).Text = string.Format("{0:C}", dtGrandTotal.Rows[0][3]);
        }
    }

    /// <summary>
    /// Handles RowDataBound Event for gvLossLimitation grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLossLimitation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row is footer row
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            // get datarow for Total for specific region
            DataRow[] dr = dtRegionTotal.Select("Region='" + STR_Region + "'");
            if (dr.Length > 0)
            {
                // set totals from datatable to the labels in footer
                DataRow drTotal = dr[0];
                ((Label)e.Row.FindControl("lblTotalClaimCount")).Text = string.Format("{0:#,0}", drTotal[1]);
                ((Label)e.Row.FindControl("lblTotalIncurred")).Text = string.Format("{0:C}", drTotal[2]);
                ((Label)e.Row.FindControl("lblTotalLimitedIncurred")).Text = string.Format("{0:C}", drTotal[3]);
                ((Label)e.Row.FindControl("lblExcess")).Text = string.Format("{0:C}", drTotal[4]);
            }
        }
    }
    #endregion
}
