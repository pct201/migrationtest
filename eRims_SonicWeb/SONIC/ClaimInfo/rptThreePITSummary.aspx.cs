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
public partial class SONIC_ClaimInfo_rptThreePITSummary : clsBasePage
{
    #region Private Variables

    string STR_REGION;
    DataTable dtRegionTotals, dtDetails, dtGrandTotal;

    #endregion

    #region "Variables"

    private string dtAsOf1
    {
        get { return Convert.ToString(ViewState["dtAsOf1"]); }
        set { ViewState["dtAsOf1"] = value; }
    }

    private string dtAsOf2
    {
        get { return Convert.ToString(ViewState["dtAsOf2"]); }
        set { ViewState["dtAsOf2"] = value; }
    }

    private string dtAsOf3
    {
        get { return Convert.ToString(ViewState["dtAsOf3"]); }
        set { ViewState["dtAsOf3"] = value; }
    }

    private string dtLossFrom1
    {
        get { return Convert.ToString(ViewState["dtLossFrom1"]); }
        set { ViewState["dtLossFrom1"] = value; }
    }

    private string dtLossFrom2
    {
        get { return Convert.ToString(ViewState["dtLossFrom2"]); }
        set { ViewState["dtLossFrom2"] = value; }
    }
    private string dtLossFrom3
    {
        get { return Convert.ToString(ViewState["dtLossFrom3"]); }
        set { ViewState["dtLossFrom3"] = value; }
    }
    private string dtLossTo1
    {
        get { return Convert.ToString(ViewState["dtLossTo1"]); }
        set { ViewState["dtLossTo1"] = value; }
    }
    private string dtLossTo2
    {
        get { return Convert.ToString(ViewState["dtLossTo2"]); }
        set { ViewState["dtLossTo2"] = value; }
    }
    private string dtLossTo3
    {
        get { return Convert.ToString(ViewState["dtLossTo3"]); }
        set { ViewState["dtLossTo3"] = value; }
    }


    #endregion

    #region Page Events

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
            this.pnlReport.Visible = false;
        }
    }

    /// <summary>
    /// This method is used to create one extra header in Gridview with the colspan in one or more columns
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow row;
            row = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
            row.Font.Bold = true;

            TableCell Cell = new TableCell();
            Cell.Text = "<table width='100%' cellspacing=0 cellpadding=0><tr><td width='100%'>" +
                                "<table width='100%' style='font-weight: bold;' cellspacing=0 cellpadding=0><tr>" +
                                "<td width='14%'>&nbsp;</td>" +
                                "<td colspan='2' align='center' width='18%'>Period 1 <br/> " + dtLossFrom1 + " To " + dtLossTo1 + " <br/> As Of " + dtAsOf1 + "</td>" +
                                "<td colspan='4' align='center' width='34%'>Period 2 <br/> " + dtLossFrom2 + " To " + dtLossTo2 + " <br/> As Of " + dtAsOf2 + "</td>" +
                                "<td colspan='4' align='center'>Period 3 <br/> " + dtLossFrom3 + " To " + dtLossTo3 + " <br/> As Of " + dtAsOf3 + "</td>" +
                            "</tr></table></td></tr></table>";

            row.Cells.Add(Cell);
            ((Table)gvRegion.Controls[0]).Rows.AddAt(0, row);
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
        this.pnlReport.Visible = true;
    }

    /// <summary>
    /// Clears All the selected filters value
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        Response.Redirect("rptThreePITSummary.aspx", false);
    }

    /// <summary>
    /// Use to Export the Report GridView in to the Excel Sheet.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        // set borders for tables and gridlines in grids to be displayed in excel file
        gvRegion.GridLines = GridLines.Both;
        //((Table)gvRegion.Controls[0]).Rows[0].Controls[0]

        ((HtmlTable)gvRegion.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvRegion.FooterRow.FindControl("tblFooter")).Border = 1;
        foreach (GridViewRow gRow in gvRegion.Rows)
        {
            GridView gvDetail = (GridView)gRow.FindControl("gvReport");
            gvDetail.GridLines = GridLines.Both;
        }

        //Export Grid
        GridViewExportUtil.ExportGrid("ThreePITSummaryReport.xls", gvRegion);

        //Hide the Grid lines
        gvRegion.GridLines = GridLines.None;
        ((HtmlTable)gvRegion.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvRegion.FooterRow.FindControl("tblFooter")).Border = 0;
        foreach (GridViewRow gRow in gvRegion.Rows)
        {
            GridView gvDetail = (GridView)gRow.FindControl("gvReport");
            gvDetail.GridLines = GridLines.None;
        }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Binds the report gridview with the data as per filter selection
    /// </summary>
    private void BindReport()
    {
        string _strClaimType = string.Empty;
        //Prepare the comma seprated list of selected claim type
        foreach (ListItem li in lsbClaimType.Items)
        {
            if (li.Selected == true)
                _strClaimType = (_strClaimType == "") ? li.Value.ToString() : _strClaimType + "," + li.Value.ToString();
        }

        dtAsOf1 = txtasOf1.Value;
        dtAsOf2 = txtasOf2.Value;
        dtAsOf3 = txtasOf3.Value;

        dtLossFrom1 = txtLossFromDate1.Text;
        dtLossFrom2 = txtLossFromDate2.Text;
        dtLossFrom3 = txtLossFromDate3.Text;

        dtLossTo1 = txtLossToDate1.Text;
        dtLossTo2 = txtLossToDate2.Text;
        dtLossTo3 = txtLossToDate3.Text;

        //Get the Report Data
        DataSet dsReport = clsClaimReports.GetThreePITSummaryData(GetDate(txtasOf1.Value), Convert.ToDateTime(txtLossFromDate1.Text), Convert.ToDateTime(txtLossToDate1.Text),
                    GetDate(txtasOf2.Value), Convert.ToDateTime(txtLossFromDate2.Text), Convert.ToDateTime(txtLossToDate2.Text),
                    GetDate(txtasOf3.Value), Convert.ToDateTime(txtLossFromDate3.Text), Convert.ToDateTime(txtLossToDate3.Text)
                    , _strClaimType);


        dtDetails = dsReport.Tables[0];
        dtRegionTotals = dsReport.Tables[1];
        dtGrandTotal = dsReport.Tables[2];

        gvRegion.DataSource = dtRegionTotals;
        gvRegion.DataBind();

        //Make the Grand Toal of report and display it
        if (dtDetails.Rows.Count > 0)
        {
            tblUtility.Visible = true;
            if (dtGrandTotal.Rows.Count > 0)
            {
                DataRow drTotal = dtGrandTotal.Rows[0];
                ((Label)gvRegion.FooterRow.FindControl("lblTotalIncurred1")).Text = String.Format("{0:C2}", drTotal["Incurred_1"]);
                ((Label)gvRegion.FooterRow.FindControl("lblClaims1")).Text = String.Format("{0:N0}", drTotal["ClaimCount_1"]);
                ((Label)gvRegion.FooterRow.FindControl("lblTotalIncurred2")).Text = String.Format("{0:C2}", drTotal["Incurred_2"]);
                ((Label)gvRegion.FooterRow.FindControl("lblFinChgPd21")).Text = String.Format("{0:f}", drTotal["FinChgPd2Inc_2"]);
                ((Label)gvRegion.FooterRow.FindControl("lblClaims2")).Text = String.Format("{0:N0}", drTotal["ClaimCount_2"]);
                ((Label)gvRegion.FooterRow.FindControl("lblClaimsPercent12")).Text = String.Format("{0:f}", drTotal["FinChgPd2Cnt_2"]);
                ((Label)gvRegion.FooterRow.FindControl("lblTotalIncurred3")).Text = String.Format("{0:C2}", drTotal["Incurred_3"]);
                ((Label)gvRegion.FooterRow.FindControl("lblFinChgPd23")).Text = String.Format("{0:f}", drTotal["FinChgPd2Inc_3"]);
                ((Label)gvRegion.FooterRow.FindControl("lblClaims3")).Text = String.Format("{0:N0}", drTotal["ClaimCount_3"]);
                ((Label)gvRegion.FooterRow.FindControl("lblClaimsPercentchg23")).Text = String.Format("{0:f}", drTotal["FinChgPd2Cnt_3"]);
            }
        }
        else
            tblUtility.Visible = false;

        pnlReport.Visible = true;
    }

    //Get the Date for As_Of_Date selection with the defualt date 01 and month and year selected in the control.
    private DateTime GetDate(String strDate)
    {
        //Insert default day 01 in the month/year string and return
        strDate = strDate.Insert(strDate.IndexOf('/'), "/01");
        return Convert.ToDateTime(strDate);
    }

    protected void gvRegion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvReport = (GridView)e.Row.FindControl("gvReport");

            DataView dvReport = dtDetails.DefaultView;
            STR_REGION = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Region"));
            dvReport.RowFilter = "Region = '" + STR_REGION + "'";

            //Bind Report Data
            gvReport.DataSource = dvReport.ToTable();
            gvReport.DataBind();

            DataRow[] dr = dtRegionTotals.Select("Region= '" + STR_REGION + "'");

            if (dr.Length > 0)
            {
                DataRow drTotal = dr[0];

                //gvReport.FooterRow.Cells[0].Text = "Report Grand Total ";
                gvReport.FooterRow.Cells[1].Text = String.Format("{0:C2}", drTotal["Incurred_1"]);
                gvReport.FooterRow.Cells[2].Text = String.Format("{0:N0}", drTotal["ClaimCount_1"]);
                gvReport.FooterRow.Cells[3].Text = String.Format("{0:C2}", drTotal["Incurred_2"]);
                gvReport.FooterRow.Cells[4].Text = String.Format("{0:f}", drTotal["FinChgPd2Inc_2"]);

                gvReport.FooterRow.Cells[5].Text = String.Format("{0:N0}", drTotal["ClaimCount_2"]);
                gvReport.FooterRow.Cells[6].Text = String.Format("{0:f}", drTotal["FinChgPd2Cnt_2"]);
                gvReport.FooterRow.Cells[7].Text = String.Format("{0:C2}", drTotal["Incurred_3"]);
                gvReport.FooterRow.Cells[8].Text = String.Format("{0:f}", drTotal["FinChgPd2Inc_3"]);
                gvReport.FooterRow.Cells[9].Text = String.Format("{0:N0}", drTotal["ClaimCount_3"]);
                gvReport.FooterRow.Cells[10].Text = String.Format("{0:f}", drTotal["FinChgPd2Cnt_3"]);
            }
        }
    }

    #endregion
}
