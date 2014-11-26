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

/*********************************************************************************************************************************
 * 
 * Developer Name : Ravi Patel
 * 
 * Description : This page allow user to generate Monthly Expense By Location. User can see report result into grid and also export 
 *               output to Excel(.xls) files. user can filter this reprot By Region, Lease Type ,Lease Commencement Date and Lease
 *               Expiration Date.
 * 
 ********************************************************************************************************************************/
public partial class SONIC_RealEstate_rptMonthlyExpenseByLocation : clsBasePage
{
    #region "Variable"

    DataTable dtDetails = null, dtLocationDtl = null;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Bind Drop down
            BindDropDownList();
            // set focus to first field
            ddlRegion.Focus();
        }
    }

    #region "Events"

    /// <summary>
    /// Handle Button Show Report click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;
        string strRegion = string.Empty, strLeaseType = string.Empty;
        DataSet dsResult;

        if (txtLCDateFrom.Text.Trim() != string.Empty)
            dtLCDFrom = Convert.ToDateTime(txtLCDateFrom.Text);

        if (txtLCDateTo.Text.Trim() != string.Empty)
            dtLCDTo = Convert.ToDateTime(txtLCDateTo.Text);

        if (txtLEDateFrom.Text.Trim() != string.Empty)
            dtLEDFrom = Convert.ToDateTime(txtLEDateFrom.Text);

        if (txtLEDateTo.Text.Trim() != string.Empty)
            dtLEDTo = Convert.ToDateTime(txtLEDateTo.Text);

        // get selected regions
        foreach (ListItem li in ddlRegion.Items)
        {
            if (li.Selected)
                strRegion = strRegion + "'" + li.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        // get selected regions
        foreach (ListItem li in ddlLeaseType.Items)
        {
            if (li.Selected)
                strLeaseType = strLeaseType + li.Value + ",";
        }
        strLeaseType = strLeaseType.TrimEnd(',');

        // get report result from database
        dsResult = Report.GetMonthlyExpenseByLocation(strRegion, strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo);
        dtDetails = dsResult.Tables[0];
        dtLocationDtl = dsResult.Tables[1];

        // set scrollbar propery
        dvReport.Style[HtmlTextWriterStyle.OverflowX] = (dsResult.Tables[0].Rows.Count > 0) ? "scroll;" : "hidden;";

        // bind grid view
        gvReport.DataSource = dsResult.Tables[2];
        gvReport.DataBind();
        dvGrid.Visible = true;

        // check any row is found or not.
        if (gvReport.Rows.Count > 0)
        {
            // set total for Lease Area and Count 
            ((Label)gvReport.FooterRow.FindControl("lblGrandTotalRentableArea")).Text = string.Format("{0:N0}", dsResult.Tables[3].Rows[0]["Leaseable_Area"]);
            ((Label)gvReport.FooterRow.FindControl("lblTotalClaimCount")).Text = string.Format("{0:N0}", dsResult.Tables[3].Rows[0]["LeaseCount"]);
            
            // display Monthly rent for next 12 month included Current Month
            for (int i = 1; i <= 12; i++)
                ((Label)gvReport.FooterRow.FindControl("lblGTotalMonth" + i.ToString())).Text = string.Format("{0:C2}", dsResult.Tables[3].Rows[0]["Month_" + i.ToString()]);
            lnkExportToExcel.Visible = true;
        }

    }

    /// <summary>
    /// handle Export To Excel Link button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {

        gvReport.GridLines = GridLines.Both;

        // set border to Header and footer table
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvReport.FooterRow.FindControl("tblFooter")).Border = 1;

        // set Border to Inner grid
        foreach (GridViewRow gRow in gvReport.Rows)
        {
            GridView gvDetail = (GridView)gRow.FindControl("gvDetail");
            gvDetail.GridLines = GridLines.Both;
        }

        // export gridview to excel
        GridViewExportUtil.ExportGrid("MonthlyExpenseByLocation.xls", gvReport);
        gvReport.GridLines = GridLines.None;
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

    /// <summary>
    /// Handles RowDataBound event when row is generated in Region grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get details for specific region from datatable having details data
            DataView dvDetails = dtDetails.DefaultView;
            string str_Location = string.Empty;
            str_Location = DataBinder.Eval(e.Row.DataItem, "PK_LU_Location_ID").ToString();
            dvDetails.RowFilter = "PK_LU_Location_ID = " + str_Location;

            //bind the sub grid for Region grid 
            GridView gvDetail = e.Row.FindControl("gvDetail") as GridView;
            gvDetail.DataSource = dvDetails.ToTable();
            gvDetail.DataBind();

            if (gvDetail.Rows.Count > 0)
            {
                // filter Location Detail Record
                DataRow[] dr = dtLocationDtl.Select("PK_LU_Location_ID = " + str_Location);

                if (dr.Length > 0)
                {
                    // set total for Lease Area and Count 
                    ((Label)gvDetail.FooterRow.FindControl("lblLeaseable_Area")).Text = string.Format("{0:N0}", dr[0]["Leaseable_Area"]);
                    ((Label)gvDetail.FooterRow.FindControl("lblCount")).Text = string.Format("{0:N0}", dr[0]["LeaseCount"]);
                    // display Monthly rent for next 12 month included Current Month
                    for (int i = 1; i <= 12; i++)
                        ((Label)gvDetail.FooterRow.FindControl("lblTotalMonth" + i.ToString())).Text = string.Format("{0:C2}", dr[0]["Month_" + i.ToString()]);
                }
            }
        }
    }

    /// <summary>
    /// Handle gvDetail Gridview row data bound event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((Label)e.Row.FindControl("lblAddress")).Text = DataBinder.Eval(e.Row.DataItem, "Address_1".ToString().Trim()) + "<br style='mso-data-placement:same-cell;'>" + DataBinder.Eval(e.Row.DataItem, "City".ToString().Trim()) +
                                                                                    "<br style='mso-data-placement:same-cell;'>" + DataBinder.Eval(e.Row.DataItem, "State".ToString().Trim()) +
                                                                                    "<br style='mso-data-placement:same-cell;'>" + DataBinder.Eval(e.Row.DataItem, "ZIP_Code".ToString().Trim());
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

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind Drop Down List
    /// </summary>    
    private void BindDropDownList()
    {
        //Region
        ComboHelper.FillRegionListBox(new ListBox[] { ddlRegion }, false);

        //Lease Type
        ComboHelper.FillLeaseTypeListBox(new ListBox[] { ddlLeaseType }, false);
    }

    #endregion
}
