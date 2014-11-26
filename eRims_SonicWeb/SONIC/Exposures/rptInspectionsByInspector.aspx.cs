using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.Web.UI.HtmlControls;

public partial class SONIC_Exposures_rptInspectionsByInspector : clsBasePage
{
    #region "Page Event"

    /// <summary>
    /// handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindListBoxes();
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind List Box
    /// </summary>
    private void BindListBoxes()
    {
        // get regions for user having access to and bind the regions list box
        DataTable dtRegions = clsClaimReports.SelectRegions().Tables[0];
        lstRegions.DataSource = dtRegions;
        lstRegions.DataTextField = "region";
        lstRegions.DataValueField = "region";
        lstRegions.DataBind();

        ComboHelper.FillLocationdbaOnlyListBox(new ListBox[] { lstLocationDBA }, 0, false,false);

        DataTable dt_Inspection_Area = clsLU_Inspection_Area.SelectAll().Tables[0];
        dt_Inspection_Area.DefaultView.RowFilter = "Active = 'Y'";
        lstInspectionArea.DataSource = dt_Inspection_Area.DefaultView;
        lstInspectionArea.DataTextField = "Fld_Desc";
        lstInspectionArea.DataValueField = "PK_LU_Inspection_Area";
        lstInspectionArea.DataBind();
    }

    /// <summary>
    /// Get Comma saperated List items
    /// </summary>
    /// <param name="lst"></param>
    /// <returns></returns>
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

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    #endregion

    #region "Events"
    /// <summary>
    /// Handles Show Report button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        trSearch.Visible = false;
        trResult.Visible = true;

        string strRegion = "";
        string strDba = "";
        string strInspectorName = "";
        string strInspectionArea = "";
        // get selected regions
        strRegion = GetCommaSeparatedValues(lstRegions);
        strDba = GetCommaSeparatedValues(lstLocationDBA);
        strInspectionArea = GetCommaSeparatedValues(lstInspectionArea);
        strInspectorName = txtInspectorName.Text.Trim().Replace("'", "''");

        // get report data for selected values
        DataSet dsReport = clsExposuresReports.GetInspectionsByInspector(strRegion, strDba, strInspectionArea, strInspectorName, clsGeneral.FormatNullDateToStore(txtInspectionDateFrom.Text), clsGeneral.FormatNullDateToStore(txtInspectionDateTo.Text));

        // get data tables from dataset
        DataTable dtRegions = dsReport.Tables[0];

        // bind the main grid which lists regions
        gvInspection.DataSource = dtRegions;
        gvInspection.DataBind();
        if (gvInspection.Rows.Count > 0)
            lbtExportToExcel.Visible = true;
        else
            lbtExportToExcel.Visible = false;
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
        lstLocationDBA.ClearSelection();
        lstInspectionArea.ClearSelection();
        txtInspectionDateFrom.Text = "";
        txtInspectionDateTo.Text = "";
        txtInspectorName.Text = "";

    }

    /// <summary>
    /// Back hrom report to Criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        trSearch.Visible = true;
        trResult.Visible = false;
    }

    /// <summary>
    /// Handles Export to Excel link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        //gvDescription.ShowHeader = true;       

        gvInspection.GridLines = GridLines.Both;       

        // export data to excel from gridview
        GridViewExportUtil.ExportGrid("Inspections By Inspectors.xls", gvInspection);
       
        // gvDescription.ShowHeader = false;
        gvInspection.GridLines = GridLines.None;
       
    }

    #endregion
}