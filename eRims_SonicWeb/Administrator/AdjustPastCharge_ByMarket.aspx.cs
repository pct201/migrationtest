using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ERIMS.DAL;

/************************************************************************************************************************************
 * File Name      :	AdjustPastCharge.aspx
 *
 * Description    :	This page provide facility to Adjust Past Charges which is come from wc_allocation_charges table.
 *                  User can edit any charges only one time. Then User can not change or alter any charges. 
 *
 *************************************************************************************************************************************/

public partial class Administrator_AdjustPastCharge_ByMarket : clsBasePage
{
    #region "Declaration"

    public decimal Pk_Investigation
    {
        get { return clsGeneral.IsNull(ViewState["Pk_Investigation"]) ? 0 : Convert.ToDecimal(ViewState["Pk_Investigation"]); }
        set { ViewState["Pk_Investigation"] = value; }
    }

    public decimal FK_WC_FR_ID
    {
        get { return clsGeneral.IsNull(ViewState["WC_FR_Number"]) ? 0 : Convert.ToDecimal(ViewState["WC_FR_Number"]); }
        set { ViewState["WC_FR_Number"] = value; }
    }

    public string SearchMode
    {
        get { return string.IsNullOrEmpty(Request.QueryString["mode"]) ? "" : Request.QueryString["mode"].ToString(); }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (SearchMode.ToUpper() == "RESULT")
            {
                FK_WC_FR_ID = clsSession.FK_WC_FR_ID;
                FillSearchResult();
            }
            else
            {
                ComboHelper.FillMarket(new DropDownList[] { drpMarket }, true, false);
            }
        }
    }

    /// <summary>
    /// Handle Region Dropdown Selected index Change events
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpMarket_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtWc_fr = WC_FR.SelectByMarket(Convert.ToDecimal(drpMarket.SelectedItem.Value));

        // Fill First Report Number DropDown
        drpFirstReportNumber.DataSource = dtWc_fr;
        drpFirstReportNumber.DataTextField = "WC_FR_Number";
        drpFirstReportNumber.DataValueField = "PK_WC_FR_ID";
        drpFirstReportNumber.DataBind();
        drpFirstReportNumber.Items.Insert(0, new ListItem("---Select---", "0"));

        //clean up memory
        clsGeneral.DisposeOf(dtWc_fr);
    }

    /// <summary>
    /// Handle Edit Cause button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEditCuase_Click(object sender, EventArgs e)
    {
        // wc_fr_number is fk_wc_fr_id 
        FK_WC_FR_ID = Convert.ToDecimal(drpFirstReportNumber.SelectedItem.Value);
        clsSession.FK_WC_FR_ID = FK_WC_FR_ID;
        FillSearchResult();
    }

    public void FillSearchResult()
    {
        gvWC_Allocation.DataSource = WC_Allocation_Charges_ByMarket.SearchByFR_Number(FK_WC_FR_ID);
        gvWC_Allocation.DataBind();
        HideSearch();
    }

    /// <summary>
    /// Handle Save Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {

        ShowSeach();
    }

    /// <summary>
    /// Handle Cancel Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdjustPastCharge_ByMarket.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        clsSession.FK_WC_FR_ID = FK_WC_FR_ID;
        Response.Redirect("WC_AllocationCharges_ByMarket.aspx");
    }

    #region "Methods"

    /// <summary>
    ///  show investigation Seach Panel
    /// </summary>
    private void ShowSeach()
    {
        pnlSearchWC_FR.Visible = true;
        pnlEditWC_Allocation.Visible = false;
        drpMarket.SelectedIndex = 0;
        drpFirstReportNumber.SelectedIndex = 0;
        drpFirstReportNumber.Items.Clear();
        drpFirstReportNumber.Items.Insert(0, new ListItem("---Select---", "0"));
    }

    /// <summary>
    ///  show investigation edit panel and Hide Seach Panel
    /// </summary>
    private void HideSearch()
    {
        pnlSearchWC_FR.Visible = false;
        pnlEditWC_Allocation.Visible = true;
    }

    #endregion

    /// <summary>
    /// Handle Gridview Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWC_Allocation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Decimal Pk_Wc_Allocation = Convert.ToDecimal(e.CommandArgument.ToString());

        if (e.CommandName == "EditRecord")
            Response.Redirect("WC_AllocationCharges_ByMarket.aspx?mode=edit&id=" + Encryption.Encrypt(Pk_Wc_Allocation.ToString()));
        else if (e.CommandName == "View")
            Response.Redirect("WC_AllocationCharges_ByMarket.aspx?mode=view&id=" + Encryption.Encrypt(Pk_Wc_Allocation.ToString()));
    }
}
