using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ERIMS.DAL;

public partial class SONIC_Exposures_rptNewExposures : clsBasePage
{
    #region "Page Load"
    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!IsPostBack)
        {
            // get regions for user having access to and bind the regions list box
            DataTable dtRegions = clsClaimReports.SelectRegions().Tables[0];
            lstRegions.DataSource = dtRegions;
            lstRegions.DataTextField = "region";
            lstRegions.DataValueField = "region";
            lstRegions.DataBind();

            //Bind Market Dropdown
            ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);
        }
    }
    #endregion

    #region "Controls Events"

    /// <summary>
    /// Back hrom report to Criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        trCriteria.Visible = true;
        tblReport.Visible = false;

    }
    /// <summary>
    /// Handles Show Report button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        string strRegion = "";
        string strStatus = "";
        string strMarket = "";
        // get selected regions
        strRegion = GetCommaSeparatedValues(lstRegions);
        strStatus = GetCommaSeparatedValues(ddlStatus);
        strMarket = GetCommaSeparatedValues(lstMarket);
        // get report data for selected values
        DataSet dsReport = clsExposuresReports.GetNewExposuresreport(strRegion, strStatus, strMarket);

        // get data tables from dataset
        DataTable dtRegions = dsReport.Tables[0];

        // bind the main grid which lists regions
        gvDescription.DataSource = dtRegions;
        gvDescription.DataBind();

        // show grid and export link 
        tblReport.Visible = true;
        trCriteria.Visible = false;
        lbtExportToExcel.Visible = dtRegions.Rows.Count > 0;
        btnBack.Visible = true;

        // Check if record found or not.
        if (dtRegions.Rows.Count > 0)
        {
            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            dvGrid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + dvHeader.ClientID + ");");
            dvHeader.Visible = true;

            trMessage.Visible = false;
            trGrid.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            trMessage.Visible = true;
            trGrid.Visible = false;
        }
    }

    /// <summary>
    /// Handles Export to Excel link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        //gvDescription.ShowHeader = true;
        // set borders for tables and gridlines in grids to be displayed in excel file
        ((HtmlTable)gvDescription.HeaderRow.FindControl("tblHeader")).Border = 1;

        gvDescription.GridLines = GridLines.Both;
        gvDescription.FooterRow.Visible = false;
        foreach (GridViewRow gvRow in gvDescription.Rows)
        {
            HtmlTable tbl = (HtmlTable)gvRow.FindControl("tblHeader");
            tbl.Visible = true;
            tbl.Border = 1;
        }

        // export data to excel from gridview
        GridViewExportUtil.ExportGrid("Third Party Owned and Sonic Leased and Subleased to Third Party.xls", gvDescription);

        // reset the settings
        foreach (GridViewRow gvRow in gvDescription.Rows)
        {
            HtmlTable tbl = (HtmlTable)gvRow.FindControl("tblHeader");
            tbl.Border = 0;

        }
        // gvDescription.ShowHeader = false;
        gvDescription.GridLines = GridLines.None;
        ((HtmlTable)gvDescription.HeaderRow.FindControl("tblHeader")).Border = 0;
    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        // load the page again to clear selection
        lstRegions.ClearSelection();
        lstMarket.ClearSelection();
        ddlStatus.ClearSelection();
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

    #region "Private Methods"
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
    #endregion
}
