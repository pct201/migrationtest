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

public partial class SONIC_FirstReport_RptSonicCauseCodeReclassification : clsBasePage
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
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstLocation, lstRegion });
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

        DateTime? dtInjuryDateFrom = null, dtInjuryDateEnd = null;
        string strRegion = string.Empty, strMarket = string.Empty, strLocationStatus = string.Empty, strDBA = string.Empty, strClaimnumber = string.Empty;
        decimal? decFirsrRepot = null, decIncidentNumber = null;
        if (txtFirstReportNumber.Text != "")
            decFirsrRepot = Convert.ToDecimal(txtFirstReportNumber.Text);
        if (txtIncidentNumber.Text != "")
            decIncidentNumber = Convert.ToDecimal(txtIncidentNumber.Text);


        if (txtInjuryDateFrom.Text.Trim() != string.Empty)
            dtInjuryDateFrom = Convert.ToDateTime(txtInjuryDateFrom.Text);

        if (txtInjuryDateEnd.Text.Trim() != string.Empty)
            dtInjuryDateEnd = Convert.ToDateTime(txtInjuryDateEnd.Text);
        if (txtClaimNumber.Text != "")
            strClaimnumber = txtClaimNumber.Text;

        // get selected Location
        foreach (ListItem li in lstLocation.Items)
        {
            if (li.Selected)
                strDBA = strDBA + "'" + li.Value + "',";
        }
        strDBA = strDBA.TrimEnd(',');

        // get selected regions
        foreach (ListItem li in lstRegion.Items)
        {
            if (li.Selected)
                strRegion = strRegion + "'" + li.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        // get selected Markets
        foreach (ListItem li in lstMarket.Items)
        {
            if (li.Selected)
                strMarket = strMarket + "" + li.Value + ",";
        }
        strMarket = strMarket.TrimEnd(',');


        DataSet dsReport = WC_ClaimInfo.GetSonicCauseCodeReclassification_Report(strRegion, strMarket, strDBA, dtInjuryDateFrom, dtInjuryDateEnd, decFirsrRepot, decIncidentNumber, strClaimnumber);


        // get data tables from dataset
        DataTable dtReport = dsReport.Tables[0];

        // set scrollbar propery
        dvGrid.Style[HtmlTextWriterStyle.OverflowX] = (dsReport.Tables[0].Rows.Count > 0) ? "scroll;" : "hidden;";

        // bind the main grid which lists regions
        gvDescription.DataSource = dtReport;
        gvDescription.DataBind();

        // show grid and export link 
        tblReport.Visible = true;
        trCriteria.Visible = false;
        lbtExportToExcel.Visible = dtReport.Rows.Count > 0;
        btnBack.Visible = true;

        // Check if record found or not.
        if (dtReport.Rows.Count > 0)
        {
            // count and display the grand total in the footer row
            ((Label)gvDescription.FooterRow.FindControl("lblTotal")).Text = dtReport.Rows.Count.ToString();
            ((Label)gvDescription.FooterRow.FindControl("lblTotalIncurred")).Text = string.Format("{0:C2}", dtReport.Compute("sum(TotalIncurred)", ""));
            ((Label)gvDescription.FooterRow.FindControl("lblTotalPaid")).Text = string.Format("{0:C2}", dtReport.Compute("sum(TotalPaid)", ""));
            ((Label)gvDescription.FooterRow.FindControl("lblTotalOutstanding")).Text = string.Format("{0:C2}", dtReport.Compute("sum(TotalOutstanding)", ""));



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
        // gvDescription.ShowHeader = false;
        gvDescription.GridLines = GridLines.None;


        if (((HtmlTable)gvDescription.HeaderRow.FindControl("tblHeader")) != null)
        {
            ((HtmlTable)gvDescription.HeaderRow.FindControl("tblHeader")).Border = 0;
            ((HtmlTable)gvDescription.HeaderRow.FindControl("tblHeader")).Border = 1;
            ((HtmlTable)gvDescription.FooterRow.FindControl("tblFooter")).Border = 1;
        }

        // show gridlines to be shown in excel
        gvDescription.GridLines = GridLines.Both;


        foreach (GridViewRow gRow in gvDescription.Rows)
        {
            if (((HtmlTable)gRow.FindControl("tblDetails")) != null)
                ((HtmlTable)gRow.FindControl("tblDetails")).Border = 1;
        }

        // export gridview to excel
        GridViewExportUtil.ExportGrid("SonicCauseCodeReclassification.xlsx", gvDescription, true);

        // hide gridlines
        gvDescription.GridLines = GridLines.None;
        if (((HtmlTable)gvDescription.HeaderRow.FindControl("tblHeader")) != null)
        {
            ((HtmlTable)gvDescription.HeaderRow.FindControl("tblHeader")).Border = 0;
            ((HtmlTable)gvDescription.HeaderRow.FindControl("tblDetails")).Border = 0;
            ((HtmlTable)gvDescription.FooterRow.FindControl("tblFooter")).Border = 0;
        }
        foreach (GridViewRow gRow in gvDescription.Rows)
        {
            if (((HtmlTable)gRow.FindControl("tblDetails")) != null)
                ((HtmlTable)gRow.FindControl("tblDetails")).Border = 0;
        }
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
        lstRegion.ClearSelection();
        lstMarket.ClearSelection();
        txtInjuryDateFrom.Text = "";
        txtInjuryDateEnd.Text = "";
        txtFirstReportNumber.Text = "";
        txtIncidentNumber.Text = "";
        txtClaimNumber.Text = "";
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
        // Fill Region
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;

        // select region as per login user
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));

        // Append region in comma seperated string value
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
                Regional += drRegion["Region"].ToString() + ",";
        }
        else
            Regional = string.Empty;

        //Fill Location
        DataSet dsLocation = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(",")));
        lstLocation.Items.Clear();

        dsLocation.Tables[0].DefaultView.RowFilter = " Active = 'Y' and Show_On_Dashboard = 'Y' ";
        dsLocation.Tables[0].DefaultView.Sort = "dba";
        lstLocation.DataTextField = "dba";
        lstLocation.DataValueField = Convert.ToString(dsLocation.Tables[0].Columns["PK_LU_Location_ID"]);
        lstLocation.DataSource = dsLocation.Tables[0].DefaultView.ToTable();
        lstLocation.DataBind();
        clsGeneral.DisposeOf(dsLocation);

        //Region
        lstRegion.DataSource = LU_Location.GetRegionList();
        lstRegion.DataTextField = "region";
        lstRegion.DataValueField = "region";
        lstRegion.DataBind();

        //Fill Market
        ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);
    }

    #endregion

}