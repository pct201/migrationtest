using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.Web.UI.HtmlControls;

public partial class DashBoard_SafetyFirstAwardReport : clsBasePage
{
    #region "Page Events"

    /// <summary>
    /// Handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // get regions for user having access to and bind the regions list box
            ComboHelper.FillRegionListBox(new ListBox[] { lstLocation }, false);
            ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);
            FillYear();
            lstLocation.Focus();
        }
    }

    #endregion

    #region "Events"
    /// <summary>
    /// Click to Generate report
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        BindReportGrid();
    }

    /// <summary>
    /// Click to Clear Criteria and Report
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        trGrid.Visible = false;
        lstLocation.ClearSelection();
        lstMarket.ClearSelection();
        ddlYear.SelectedIndex = 0;
    }

    /// <summary>
    /// Handles ExportToExcel Button click event - Opens Report in Excel sheet
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        gvSafetyFirstAwardReport.GridLines = GridLines.Both;
        // export data to excel from grid view
        GridViewExportUtil.ExportGrid("Safety First Award Report.xls", gvSafetyFirstAwardReport);
        gvSafetyFirstAwardReport.GridLines = GridLines.None;
    }

    /// <summary>
    /// GridView -Data Row Bound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSafetyFirstAwardReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Check for Item Row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblResultingScore = (Label)e.Row.FindControl("lblResultingScore");
            Label lblFinal_ScoreCard = (Label)e.Row.FindControl("lblFinal_ScoreCard");
            HtmlTableCell tdResult = (HtmlTableCell)e.Row.FindControl("tdResult");
            HtmlTableCell tdScoreCard = (HtmlTableCell)e.Row.FindControl("tdScoreCard");
            double decTotalScore = 0;
            double.TryParse(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ResultingScore")), out decTotalScore);

            int Is_Total = 0;
            int.TryParse(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Is_Total")), out Is_Total);


            if (decTotalScore > 189 && decTotalScore <= 200)
            {
                lblResultingScore.Text = decTotalScore.ToString() + " (All Pro)";
                lblFinal_ScoreCard.Text = (decTotalScore / 200) * 100 + " (All Pro)";
                tdResult.BgColor = "green";
                tdScoreCard.BgColor = "green";
            }
            else if (decTotalScore > 179 && decTotalScore <= 189)
            {
                lblResultingScore.Text = decTotalScore.ToString() + " (Starter)";
                lblFinal_ScoreCard.Text = (decTotalScore / 200) * 100 + " (Starter)";
                tdResult.BgColor = "blue";
                tdScoreCard.BgColor = "blue";
            }
            else if (decTotalScore > 159 && decTotalScore <= 179)
            {
                lblResultingScore.Text = decTotalScore.ToString() + " (Second String)";
                lblFinal_ScoreCard.Text = (decTotalScore / 200) * 100 + " (Second String)";
                tdResult.BgColor = "yellow";
                tdScoreCard.BgColor = "Yellow";
            }
            else if (decTotalScore > 139 && decTotalScore <= 159)
            {
                lblResultingScore.Text = decTotalScore.ToString() + " (Water boy)";
                lblFinal_ScoreCard.Text = (decTotalScore / 200) * 100 + " (Water boy)";
                tdResult.BgColor = "orange";
                tdScoreCard.BgColor = "orange";
            }
            else if (decTotalScore >= 0 && decTotalScore <= 139)
            {
                lblResultingScore.Text = decTotalScore.ToString() + " (Spectator)";
                lblFinal_ScoreCard.Text = (decTotalScore / 200) * 100 + " (Spectator)";
                tdResult.BgColor = "red";
                tdScoreCard.BgColor = "red";
            }

            if (Is_Total == 1)
            {
                tdResult.BgColor = "blue";
                tdScoreCard.BgColor = "blue";
                //e.Row.Cells[0].BackColor = System.Drawing.Color.Blue;
                e.Row.Cells[0].Style.Add("background-color", "blue");
                e.Row.Cells[0].Style.Add("color", "white");
            }
        }
    }
    #endregion

    #region "Methods"
    /// <summary>
    /// This method is added for export Gird view To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    /// <summary>
    /// BindGrid with Data
    /// </summary>
    private void BindReportGrid()
    {
        string strRegion = "";
        // get selected regions
        foreach (ListItem li in lstLocation.Items)
        {
            if (li.Selected)
                strRegion = strRegion + "'" + li.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        string strMarket = "";

        foreach (ListItem li in lstMarket.Items)
        {
            if (li.Selected)
                strMarket = strMarket + "" + li.Value + ",";
        }
        strMarket = strMarket.TrimEnd(',');

        gvSafetyFirstAwardReport.DataSource = Report.GetSafertyFirstAwardReport(strRegion, strMarket, Convert.ToInt32(ddlYear.SelectedValue));
        gvSafetyFirstAwardReport.DataBind();

        trGrid.Visible = true;

        if (gvSafetyFirstAwardReport.Rows.Count == 0)
            lbtExportToExcel.Visible = false;
    }

    /// <summary>
    /// Fill Year Drop Down
    /// </summary>
    private void FillYear()
    {
        int _Year;
        // Fill Year Starting with 2007 to current Year
        for (_Year = 2007; _Year <= System.DateTime.Now.Year; _Year++)
            ddlYear.Items.Add(new ListItem(_Year.ToString(), _Year.ToString()));
        ddlYear.SelectedValue = System.DateTime.Now.Year.ToString();
    }
    #endregion
}