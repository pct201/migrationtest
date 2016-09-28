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

public partial class SONIC_ClaimInfo_rptPointInTimeSummary : clsBasePage
{
    #region Private Varables

    DataTable dtYears, dtDetails, dtYearTotals, dtGrandTotals;

    string STR_ACCIDENT_YEAR, STR_CLAIM_TYPE;

    //Public variable to store report data for filtering data of sub report.
    public DataSet dsReport = new DataSet();

    #endregion

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
            DataTable dtYears = clsClaimReports.GetClaimReportYears().Tables[0];
            lsbPolicyYear.DataSource = dtYears;
            lsbPolicyYear.DataTextField = "AccidentYear";
            lsbPolicyYear.DataValueField = "AccidentYear";
            lsbPolicyYear.DataBind();
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
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvReport.FooterRow.FindControl("tblFooter")).Border = 1;
        gvReport.GridLines = GridLines.Both;
        foreach (GridViewRow gvRow in gvReport.Rows)
        {
            GridView gv = (GridView)gvRow.FindControl("gvSubReport");
            gv.GridLines = GridLines.Both;
            if (gv.Rows.Count > 0)
            {
                ((HtmlTable)gv.FooterRow.FindControl("tblFooter")).Border = 1;
                foreach (GridViewRow gRowDtl in gv.Rows)
                {
                    ((HtmlTable)gRowDtl.FindControl("tblDetails")).Border = 1;
                }
            }
        }

        GridViewExportUtil.ExportGrid("SummaryPITComparisonReport.xlsx", gvReport, true);

        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvReport.FooterRow.FindControl("tblFooter")).Border = 0;
        gvReport.GridLines = GridLines.None;
        foreach (GridViewRow gvRow in gvReport.Rows)
        {
            GridView gv = (GridView)gvRow.FindControl("gvSubReport");
            gv.GridLines = GridLines.None;
            if (gv.Rows.Count > 0)
            {
                ((HtmlTable)gv.FooterRow.FindControl("tblFooter")).Border = 0;
                foreach (GridViewRow gRowDtl in gv.Rows)
                {
                    ((HtmlTable)gRowDtl.FindControl("tblDetails")).Border = 0;
                }
            }
        }
    }

    /// <summary>
    /// Clears All the selected filters value
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        Response.Redirect("rptPointInTimeSummary.aspx", false);
    }

    /// <summary>
    /// This event is used to bind the data to innser grid(Sub Report)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check Rowtype
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Get the year to filter the data
            Label lblPolicyYear = (Label)e.Row.FindControl("lblPolicyYear");

            //Check the Policy year value is not null
            if (DataBinder.Eval(e.Row.DataItem, "AccidentYear") != DBNull.Value)
            {
                STR_ACCIDENT_YEAR = DataBinder.Eval(e.Row.DataItem, "AccidentYear").ToString();

                //Create View of second table from dataset and filter with the current policy year
                DataView dv = dsReport.Tables[1].DefaultView;
                DataTable dt = new DataTable();
                dv.RowFilter = "AccidentYear = '" + STR_ACCIDENT_YEAR + "'";
                dt = dv.ToTable();

                //Find the subreport grid and bind the data
                GridView gv = (GridView)e.Row.FindControl("gvSubReport");
                gv.DataSource = dv;
                gv.DataBind();

                //Set the Sub Total for Policy Year in the Footer
                if (gv.Rows.Count > 0)
                {
                    
                    DataRow[] dr = dtYearTotals.Select("AccidentYear = '" + STR_ACCIDENT_YEAR + "'");
                    DataRow drTotal = dr[0];

                    ((Label)gv.FooterRow.FindControl("lblClaimType")).Text = "Sub Totals for Accident Year : " + DataBinder.Eval(e.Row.DataItem, "AccidentYear");
                    ((Label)gv.FooterRow.FindControl("lblSubInc1")).Text = String.Format("{0:C2}", drTotal["Total_Incurred_1"]);
                    ((Label)gv.FooterRow.FindControl("lblSubInc2")).Text = String.Format("{0:C2}", drTotal["Total_Incurred_2"]);
                    ((Label)gv.FooterRow.FindControl("lblSubIncD")).Text = String.Format("{0:C2}", drTotal["Total_Incurred_D"]);
                    ((Label)gv.FooterRow.FindControl("lblSubPaid1")).Text = String.Format("{0:C2}", drTotal["Total_Paid_1"]);
                    ((Label)gv.FooterRow.FindControl("lblSubPaid2")).Text = String.Format("{0:C2}", drTotal["Total_Paid_2"]);
                    ((Label)gv.FooterRow.FindControl("lblSubPaidD")).Text = String.Format("{0:C2}", drTotal["Total_Paid_D"]);
                    ((Label)gv.FooterRow.FindControl("lblSubOut1")).Text = String.Format("{0:C2}", drTotal["Total_Outstanding_1"]);
                    ((Label)gv.FooterRow.FindControl("lblSubOut2")).Text = String.Format("{0:C2}", drTotal["Total_Outstanding_2"]);
                    ((Label)gv.FooterRow.FindControl("lblSubOutD")).Text = String.Format("{0:C2}", drTotal["Total_Out_D"]);
                    ((Label)gv.FooterRow.FindControl("lblSubClaimCount")).Text = String.Format("{0:N0}", drTotal["Total_Claims"]);
                }
            }
        }
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
            //Cell1.ColumnSpan = 6;
            Cell1.HorizontalAlign = HorizontalAlign.Left;
            Cell1.Text = "<table width='100%' cellspacing=0 cellpadding=0><tr><td width='100%'>" +
                            "<table width='100%' cellspacing=0 cellpadding=0><tr><td width='100%'>" +
                                "<table border='1' width='100%' style='font-weight: bold;' cellspacing=0 cellpadding=0><tr style='font-weight: bold;'>" +
                                     "<td width='50%' align='left' colspan=3>Summary Changes Report</td><td align='right' colspan=3>Losses from " + strAccidentDateFrom + " To " + strAccidentDateTo + "</td></tr></table>" +
                            "</td></tr></table></td></tr></table>";
            // add cell in row
            gRow.Cells.Add(Cell1);

            // add row in gridview header
            ((Table)gvReport.Controls[0]).Rows.AddAt(0, gRow);
        }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Binds the report gridview with the data as per filter selection
    /// </summary>
    private void BindReport()
    {
        string _strClaimType = string.Empty;
        string _strPolicyYear = string.Empty;

        //Prepare comma seprated list of selected claim type
        foreach (ListItem li in lsbClaimType.Items)
        {
            if (li.Selected == true)
                _strClaimType = (_strClaimType == "") ? li.Value.ToString() : _strClaimType + "," + li.Value.ToString();
        }

        //Prepare the comma seprate list of selected policy year
        foreach (ListItem li in lsbPolicyYear.Items)
        {
            if (li.Selected == true)
                _strPolicyYear = (_strPolicyYear == "") ? li.Value.ToString() : _strPolicyYear + "," + li.Value.ToString();
        }

        strAccidentDateFrom = txtCompDate1.Text;
        strAccidentDateTo = txtCompDate2.Text;

        //get the data for the report
        dsReport = clsClaimReports.GetPointInTimeSummaryData(Convert.ToDateTime(txtCompDate1.Text), Convert.ToDateTime(txtCompDate2.Text), _strPolicyYear, _strClaimType);

        dtYears = dsReport.Tables[0];
        dtDetails = dsReport.Tables[1];
        dtYearTotals = dsReport.Tables[2];
        dtGrandTotals = dsReport.Tables[3];

        //Here dataset has two table 
        //First contains the list of year to bind and second has data of for all year.

        //Bind the outer grid(Years selected)
        gvReport.DataSource = dtYears;
        gvReport.DataBind();

        //Calculate the Report Grand Toatal and display in footer
        if (dtYears.Rows.Count > 0)
        {
            //Set the selected first and second date in the Grid header.
            ((Label)gvReport.HeaderRow.FindControl("lblDate1")).Text = txtCompDate1.Text;
            ((Label)gvReport.HeaderRow.FindControl("lblDate2")).Text = txtCompDate2.Text;

            DataRow drTotal = dtGrandTotals.Rows[0];

            ((Label)gvReport.FooterRow.FindControl("lblGTInc1")).Text = String.Format("{0:C2}", drTotal["Total_Incurred_1"]);
            ((Label)gvReport.FooterRow.FindControl("lblGTInc2")).Text = String.Format("{0:C2}", drTotal["Total_Incurred_2"]);
            ((Label)gvReport.FooterRow.FindControl("lblGTIncD")).Text = String.Format("{0:C2}", drTotal["Total_Incurred_D"]);
            ((Label)gvReport.FooterRow.FindControl("lblGTPaid1")).Text = String.Format("{0:C2}", drTotal["Total_Paid_1"]);
            ((Label)gvReport.FooterRow.FindControl("lblGTPaid2")).Text = String.Format("{0:C2}", drTotal["Total_Paid_2"]);
            ((Label)gvReport.FooterRow.FindControl("lblGTPaidD")).Text = String.Format("{0:C2}", drTotal["Total_Paid_D"]);
            ((Label)gvReport.FooterRow.FindControl("lblGTOut1")).Text = String.Format("{0:C2}", drTotal["Total_Outstanding_1"]);
            ((Label)gvReport.FooterRow.FindControl("lblGTOut2")).Text = String.Format("{0:C2}", drTotal["Total_Outstanding_2"]);
            ((Label)gvReport.FooterRow.FindControl("lblGTOutD")).Text = String.Format("{0:C2}", drTotal["Total_Out_D"]);
            ((Label)gvReport.FooterRow.FindControl("lblGTClaimCount")).Text = String.Format("{0:N0}", drTotal["Total_Claims"]);

            tblUtility.Visible = true;
        }
        else
            tblUtility.Visible = false;
    }

    #endregion
}
