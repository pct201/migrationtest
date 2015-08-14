using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class DashBoard_ACIEventCountByLocation : System.Web.UI.Page
{
    #region ViewState
    private decimal Fk_LU_Location
    {
        get { return Convert.ToDecimal(ViewState["Fk_LU_Location"]); }
        set { ViewState["Fk_LU_Location"] = value; }
    }

    private int Month
    {
        get { return Convert.ToInt32(ViewState["Month"]); }
        set { ViewState["Month"] = value; }
    }

    private int Year
    {
        get { return Convert.ToInt32(ViewState["Year"]); }
        set { ViewState["Year"] = value; }
    }
    #endregion

    #region PageLoad
    /// <summary>
    /// Handles page load Event of Sonic Location Dealership
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Fk_LU_Location"]))
            {
                Fk_LU_Location = Convert.ToDecimal(Request.QueryString["Fk_LU_Location"]);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["Month"]))
            {
                Month = Convert.ToInt32(Request.QueryString["Month"]);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["Year"]))
            {
                Year = Convert.ToInt32(Request.QueryString["Year"]);
            }

            BindEventDataGrid();
        }
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// bind Grid For Event Data
    /// </summary>
    private void BindEventDataGrid()
    {
        DataSet dsEvent = clsEvent.GetDashboardDataACIEventCounts(Fk_LU_Location, Month, Year);

        DataTable dtEventData = dsEvent.Tables[0];
        dtEventData.DefaultView.Sort = "Event_Number ASC";
        gvEventData.DataSource = dtEventData.DefaultView;
        gvEventData.DataBind();

        DataTable dtLocation = dsEvent.Tables[1];

        if (dtLocation.Rows.Count > 0)
        {
            lblLocation.Text = "<b>Location : </b>" + Convert.ToString(dtLocation.Rows[0]["Location"]);

            lblYear.Text = "<b>Year : </b>" + Convert.ToString(dtLocation.Rows[0]["Year"]);

            if (Convert.ToString(dtLocation.Rows[0]["Month"]) != string.Empty)
                lblMonth.Text = "<b>Month : </b>" + Convert.ToString(dtLocation.Rows[0]["Month"]);
        }
    }
    #endregion

    #region Grid Events
    /// <summary>
    /// handles row data bound event of grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEventData_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblEvent_Number = (Label)e.Row.FindControl("lblEvent_Number");

            if (lblEvent_Number.Text == "ZZZ Total")
            {
                lblEvent_Number.Text = "Total";
                e.Row.Font.Bold = true;
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#507CD1");
                e.Row.ForeColor = System.Drawing.Color.White;
            }
        }
    }
    #endregion
}