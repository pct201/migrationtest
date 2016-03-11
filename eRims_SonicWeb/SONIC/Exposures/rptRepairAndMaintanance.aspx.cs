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
using System.Collections.Generic;

public partial class SONIC_Exposures_rptRepairAndMaintanance : clsBasePage
{ 

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


    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

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
        string strRegion = string.Empty;
        string strMarket = string.Empty;
        string strStatus = string.Empty;
        string strOwnership = string.Empty;
        string strBuildingStatus = string.Empty;
        // get selected regions
        strRegion = GetCommaSeparatedValues(lstRegions);
        strMarket = GetCommaSeparatedValues(lstMarket);
        strStatus = GetCommaSeparatedValues(ddlStatus);
        strBuildingStatus = GetCommaSeparatedValues(ddlBuildingStatus);
        strOwnership = GetCommaSeparatedValues(drpOwnership);

        // get report data for selected values
        DataSet dsReport = clsExposuresReports.GetPropertyStatementofValues(strRegion, strMarket, strStatus, strBuildingStatus, strOwnership, clsGeneral.FormatNullDateToStore(txtPropertyValuationDateFrom.Text), clsGeneral.FormatNullDateToStore(txtPropertyValuationDateTo.Text));

        // get data tables from dataset
        DataTable dtRegions = dsReport.Tables[0];
    
        tblReport.Visible = true;
        trCriteria.Visible = false;
        lbtExportToExcel.Visible = dtRegions.Rows.Count > 0;
        btnBack.Visible = true;


        DataSet dsReport_NEW = clsExposuresReports.GetPropertyRepairAndMaintenance(strRegion, strMarket, strStatus, strBuildingStatus, strOwnership, clsGeneral.FormatNullDateToStore(txtPropertyValuationDateFrom.Text), clsGeneral.FormatNullDateToStore(txtPropertyValuationDateTo.Text));


        if (dsReport_NEW.Tables[1] != null)
            ViewState["dtHeader"] = dsReport_NEW.Tables[1];


        gvDescription_New.DataSource = dsReport_NEW.Tables[0];
        gvDescription_New.DataBind();        
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

        System.Web.UI.WebControls.GridView gvDescription1 = new GridView();
        gvDescription1 = gvDescription_New;
        gvDescription1.AllowPaging = false;
        if (ViewState["dtHeader"] != null)
        {
            DataTable dtHeader = (DataTable)ViewState["dtHeader"];

            if (dtHeader != null && dtHeader.Rows.Count > 0)
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                int totalColumns = 0;
                foreach (DataRow dr in dtHeader.Rows)
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = dr["Header"].ToString();
                    cell.ColumnSpan = Convert.ToInt32(dr["ColSpan"].ToString());
                    totalColumns += Convert.ToInt32(dr["ColSpan"].ToString());
                    cell.BackColor = System.Drawing.ColorTranslator.FromHtml(dr["BackgroungColor"].ToString());
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.VerticalAlign = VerticalAlign.Middle;
                    if (!string.IsNullOrEmpty(dr["Color"].ToString()))
                    {
                        //cell.ControlStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(dr["Color"].ToString());
                        cell.ForeColor = System.Drawing.ColorTranslator.FromHtml(dr["Color"].ToString());
                        //cell.Style.Add("color", dr["Color"].ToString());
                    }
                    cell.CssClass = "";
                    row.Controls.Add(cell);
                }
                row.CssClass = "";
                //row.BackColor = System.Drawing.ColorTranslator.FromHtml("#29658F");
                gvDescription1.HeaderRow.Parent.Controls.AddAt(0, row);

                GridViewRow row1 = new GridViewRow(0, 1, DataControlRowType.Header, DataControlRowState.Normal);
                TableHeaderCell cell1 = new TableHeaderCell();
                cell1.ColumnSpan = 2;
                cell1.Text = "Sonic Automotive";
                cell1.HorizontalAlign = HorizontalAlign.Left;

                TableHeaderCell cell2 = new TableHeaderCell();
                cell2.ColumnSpan = totalColumns - 4;
                cell2.Text = "Property Repair & Maintenance";
                cell2.HorizontalAlign = HorizontalAlign.Center;


                TableHeaderCell cell3 = new TableHeaderCell();
                cell3.ColumnSpan = 2;
                cell3.Text = DateTime.Now.ToString();
                cell3.HorizontalAlign = HorizontalAlign.Left;


                row1.Controls.Add(cell1);
                row1.Controls.Add(cell2);
                row1.Controls.Add(cell3);
                row1.CssClass = "";
                gvDescription1.HeaderRow.Parent.Controls.AddAt(0, row1);
                gvDescription1.HeaderRow.Parent.Controls.RemoveAt(3);         

            }

        }
       
        // export data to excel from gridview
        string css = " #ctl00_ContentPlaceHolder1_gvDescription_New th {height: 22px;}.HeaderStyle th {vertical-align: bottom;text-align: left;padding-bottom: 3px;padding-left: 3px;height: 22px;}";
        GridViewExportUtil.ExportGrid("RepairAndMaintenance.xls", gvDescription1, css);
       
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
        drpOwnership.ClearSelection();
        txtPropertyValuationDateFrom.Text = "";
        txtPropertyValuationDateTo.Text = "";
    }

    #endregion

    #region Private Methods
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



    protected void gvDescription_New_DataBound(object sender, EventArgs e)
    {
        if (ViewState["dtHeader"] != null)
        {
            DataTable dtHeader = (DataTable)ViewState["dtHeader"];

            if (dtHeader != null && dtHeader.Rows.Count > 0)
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

                foreach (DataRow dr in dtHeader.Rows)
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = dr["Header"].ToString();
                    cell.ColumnSpan = Convert.ToInt32(dr["ColSpan"].ToString());
                    cell.BackColor = System.Drawing.ColorTranslator.FromHtml(dr["BackgroungColor"].ToString());
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.VerticalAlign = VerticalAlign.Middle;
                    if (!string.IsNullOrEmpty(dr["Color"].ToString()))
                    {
                        //cell.ControlStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(dr["Color"].ToString());
                        cell.ForeColor = System.Drawing.ColorTranslator.FromHtml(dr["Color"].ToString());
                        //cell.Style.Add("color", dr["Color"].ToString());
                    }
                    cell.CssClass = "";
                    row.Controls.Add(cell);
                }
                row.CssClass = "";
                //row.BackColor = System.Drawing.ColorTranslator.FromHtml("#29658F");
                if (gvDescription_New != null && gvDescription_New.HeaderRow != null)
                    gvDescription_New.HeaderRow.Parent.Controls.AddAt(0, row);
            }

        }
       

    }

}