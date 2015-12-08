using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class SONIC_Exposures_RLCM_QA_QC : clsBasePage
{
    #region "Page Events"

    /// <summary>
    /// Handles Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownList();
        }
    }

    #endregion

    #region "Method"

    /// <summary>
    /// Bind Drop Downs
    /// </summary>
    private void BindDropDownList()
    {
        ComboHelper.BindMonth(ddlMonth);
        ddlMonth.Items.Insert(0, new ListItem("-- Select --", "0"));
        ComboHelper.FillYear(new DropDownList[] { ddlYear }, true);
        ComboHelper.FillRlcmDropDownList(new DropDownList[] { ddlRLCM }, true);
    }

    /// <summary>
    /// Bind Search Result
    /// </summary>
    private void BindSearchResult()
    {
        decimal rlcm = 0, year = 0, month = 0;
        string strOrderBy = string.Empty, strOrder = string.Empty;

        if (ddlRLCM.SelectedIndex > 0) rlcm = Convert.ToDecimal(ddlRLCM.SelectedValue);
        if (ddlMonth.SelectedIndex > 0) month = Convert.ToDecimal(ddlMonth.SelectedValue);
        if (ddlYear.SelectedIndex > 0) year = Convert.ToDecimal(ddlYear.SelectedValue);
        strOrderBy = "PK_RLCM";
        strOrder = "asc";
        lblMonth.Text = Convert.ToString(month);
        lblYear.Text = Convert.ToString(year);
        lblRLCM.Text = Convert.ToString(rlcm);

        DataSet dsSearchResult = clsRLCM_QA_QC.RLCM_Search(rlcm, year, month, strOrderBy, strOrder, string.Empty);
        gvRLCM.DataSource = dsSearchResult.Tables[0];
        gvRLCM.DataBind();

        pnlSearch.Visible = false;
        pnlGrid.Visible = true;
    }

    #endregion

    #region"Grid View Events"

    /// <summary>
    /// Grid View RLCM Data RowBound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRLCM_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal rlcm = 0, year = 0, month = 0;
            string strOrderBy = string.Empty, strOrder = string.Empty;
            if (ddlRLCM.SelectedIndex > 0) rlcm = Convert.ToDecimal(ddlRLCM.SelectedValue);
            if (ddlMonth.SelectedIndex > 0) month = Convert.ToDecimal(ddlMonth.SelectedValue);
            if (ddlYear.SelectedIndex > 0) year = Convert.ToDecimal(ddlYear.SelectedValue);
            strOrderBy = "PK_RLCM";
            strOrder = "asc";

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvChild = (GridView)e.Row.FindControl("gvChildGrid");

                Label lblTask;
                lblTask = (Label)e.Row.FindControl("lblTask");
                string strTask = lblTask.Text;

                gvChild.DataSource = clsRLCM_QA_QC.RLCM_Search(rlcm, year, month, strOrderBy, strOrder, strTask);
                gvChild.DataBind();
            }
        }
    }

    /// <summary>
    /// Child Grid Data RowBound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvChildGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkStatus = (CheckBox)e.Row.FindControl("chkStatus");
            chkStatus.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Status"));
        }
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Button Submit Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BindSearchResult();
        pnlSearch.Visible = false;
        pnlGrid.Visible = true;
    }

    #endregion
}