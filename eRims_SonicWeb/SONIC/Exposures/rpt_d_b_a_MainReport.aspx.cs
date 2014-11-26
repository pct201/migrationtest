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

public partial class SONIC_Exposures_rpt_d_b_a_MainReport : clsBasePage
{

    #region "Page Events"

    /// <summary>
    /// handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rblActive.SelectedIndex = 0;
            rblShowOnDashboard.SelectedIndex = 0;
            // Bind Drop down
            BindDropDownList();
            // set focus to first field
            ddlRegion.Focus();
        }
    }
    #endregion

    #region "Events"

    /// <summary>
    /// handle Export To Excel Link button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        // show gridlines to be shown in excel
        gvMainReport.GridLines = GridLines.Both;
        ((HtmlTable)gvMainReport.HeaderRow.FindControl("tblHeader")).Border = 1;

        foreach (GridViewRow gRow in gvMainReport.Rows)
        {
            ((HtmlTable)gRow.FindControl("tblDetails")).Border = 1;

        }


        // export gridview to excel
        GridViewExportUtil.ExportGrid("d/b/a Main Report.xls", gvMainReport);

        // hide gridlines
        gvMainReport.GridLines = GridLines.None;
        ((HtmlTable)gvMainReport.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvMainReport.HeaderRow.FindControl("tblDetails")).Border = 0;


        foreach (GridViewRow gRow in gvMainReport.Rows)
        {
            ((HtmlTable)gRow.FindControl("tblDetails")).Border = 0;
        }
    }

    /// <summary>
    /// Handle Button Show Report click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        string strRegion = "";
        string strState = "";
        string strLocationCode = "";
        string strRLCM = "";
        string strActive = "";
        string strShowOnDashboard = "";

        // get selected regions
        if (ddlRegion.SelectedIndex != 0)
            strRegion = ddlRegion.SelectedValue;
        if (ddlState.SelectedIndex != 0)
            strState = ddlState.SelectedValue;
        if (ddlSonicLocationCode.SelectedIndex != 0)
            strLocationCode = ddlSonicLocationCode.SelectedValue;
        if (ddlRLCM.SelectedIndex != 0)
            strRLCM = ddlRLCM.SelectedValue;
        strActive = rblActive.SelectedValue;
        strShowOnDashboard = rblShowOnDashboard.SelectedValue;

        //get report data for selected values
        DataSet dsReport = clsExposuresReports.Getrpt_d_b_a_Main_Report(strRegion, strState, strRLCM, strLocationCode, strActive, strShowOnDashboard);

        // get data tables from dataset
        DataTable dtRegions = dsReport.Tables[0];

        // set scrollbar propery
        dvReport.Style[HtmlTextWriterStyle.OverflowX] = (dsReport.Tables[0].Rows.Count > 0) ? "scroll;" : "hidden;";

        // bind the main grid which lists regions
        gvMainReport.DataSource = dtRegions;
        gvMainReport.DataBind();

        dvGrid.Visible = true;

        // if datarows are available
        if (gvMainReport.Rows.Count > 0)
        {
            lnkExportToExcel.Visible = true;
            gvMainReport.Width = new Unit("1675px");
        }
        else
        {
            lnkExportToExcel.Visible = false;
            gvMainReport.Width = new Unit("950px");
        }
    }

    /// <summary>
    /// handle Clear Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        // reload the page
        Response.Redirect(Request.AppRelativeCurrentExecutionFilePath);
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind Drop Down List
    /// </summary>    
    private void BindDropDownList()
    {
        // Fill Region
        ComboHelper.FillRegion(new DropDownList[] { ddlRegion }, true);
        ComboHelper.FillStateFromLU_Location(new DropDownList[] { ddlState }, 0, true);

        DataTable dtRLCM = Employee.SelectRLCM_Emp().Tables[1];
        ddlRLCM.DataSource = dtRLCM;
        ddlRLCM.DataTextField = "Employee";
        ddlRLCM.DataValueField = "PK_Employee_Id";
        ddlRLCM.DataBind();
        ddlRLCM.Items.Insert(0, new ListItem("--Select--", "0"));

        //used to fill Sonic Location Dropdown
        ComboHelper.FillLocationdba(new DropDownList[] { ddlSonicLocationCode }, 0, true, true);
        ddlSonicLocationCode.Style.Remove("font-size");
    }

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    #endregion
}