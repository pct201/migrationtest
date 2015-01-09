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

public partial class SONIC_RealEstate_rptSubleaseReport : System.Web.UI.Page
{
    #region "Variables"

    DataTable dtDBA, dtReport;

    #endregion

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
            BindDropDownList();
            lstLocation.Focus();
        }
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstLocation });
        
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

        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;
        string strRegion = string.Empty, strLocationStatus = string.Empty, strMarket = string.Empty; 
        DataSet dsReport;

        if (txtLCDateFrom.Text.Trim() != string.Empty)
            dtLCDFrom = Convert.ToDateTime(txtLCDateFrom.Text);

        if (txtLCDateTo.Text.Trim() != string.Empty)
            dtLCDTo = Convert.ToDateTime(txtLCDateTo.Text);

        if (txtLEDateFrom.Text.Trim() != string.Empty)
            dtLEDFrom = Convert.ToDateTime(txtLEDateFrom.Text);

        if (txtLEDateTo.Text.Trim() != string.Empty)
            dtLEDTo = Convert.ToDateTime(txtLEDateTo.Text);

        // get selected regions
        foreach (ListItem li in lstLocation.Items)
        {
            if (li.Selected)
                strRegion = strRegion + "'" + li.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        // get selected Market
        foreach (ListItem li in lstMarket.Items)
        {
            if (li.Selected)
                strMarket = strMarket + "" + li.Value + ",";
        }
        strMarket = strMarket.TrimEnd(',');

        string strStatus = "";
        foreach (ListItem li in lstBuildingStatus.Items)
        {
            if (li.Selected)
                strStatus = strStatus + "'" + li.Value + "',";
        }
        strStatus = strStatus.TrimEnd(',');

        // get report result from database
        dsReport = Report.GetSubLeaseReport(strRegion, strMarket, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo, strStatus);

                
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
        GridViewExportUtil.ExportGrid("SubLeaseReport.xls", gvDescription);

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
        lstLocation.ClearSelection();
        lstMarket.ClearSelection();
        txtLCDateFrom.Text = "";
        txtLCDateTo.Text = "";
        txtLEDateFrom.Text = "";
        txtLEDateTo.Text = "";
        lstBuildingStatus.ClearSelection();
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

    ///// <summary>
    ///// Bind Drop Down List
    ///// </summary>    
    private void BindDropDownList()
    {
        ComboHelper.FillRegionListBox(new ListBox[] { lstLocation }, false);
       
        //Bind Market Dropdown
        ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);
    }

    #endregion
}