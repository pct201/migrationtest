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
 * File Name      :	PromoteCauseCode.aspx
 *
 * Description    :	 This screen will allow the user to change the Sonic Cause Code on any investigation that has S0 for the 
 *                   Investigation.Sonic_Cause_Code.User selects Location (Region), then, based on the location selected, 
 *                   populate a pulldown with the WC First Report Number and the Investigation Number where left(Sonic_Cause_Code,2) = S0
 *                   User selects new Sonic Cause Code S1 through S5 ans save record.
 *
 *************************************************************************************************************************************/

public partial class Administrator_PromoteCauseCode : clsBasePage
{
    #region
    public decimal Pk_Investigation
    {
        get { return clsGeneral.IsNull(ViewState["Pk_Investigation"]) ? 0 : Convert.ToDecimal(ViewState["Pk_Investigation"]); }
        set { ViewState["Pk_Investigation"] = value; }
    }

    public decimal PK_WC_FR_ID
    {
        get { return clsGeneral.IsNull(ViewState["PK_WC_FR_ID"]) ? 0 : Convert.ToDecimal(ViewState["PK_WC_FR_ID"]); }
        set { ViewState["PK_WC_FR_ID"] = value; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtRegion = clsClaimReports.SelectRegions().Tables[0];

            // Fill Region Dropdown
            drpRegion.DataSource = dtRegion;
            drpRegion.DataTextField = "Region";
            drpRegion.DataValueField = "Region";
            drpRegion.DataBind();

            //clean up memory
            clsGeneral.DisposeOf(dtRegion);
        }
    }

    protected void drpRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtInvestigation = Investigation.GetAllInvestigationByRegion(drpRegion.SelectedItem.Value);

        // Fill First Report Number DropDown
        drpFirstReportNumber.DataSource = dtInvestigation;
        drpFirstReportNumber.DataTextField = "WC_FR_Number";
        drpFirstReportNumber.DataValueField = "PK_WC_FR_ID";
        drpFirstReportNumber.DataBind();
        drpFirstReportNumber.Items.Insert(0, new ListItem("---Select---", "0"));

        // Fill Investigation DropDown
        drpInvestigation.DataSource = dtInvestigation;
        drpInvestigation.DataTextField = "PK_Investigation_ID";
        drpInvestigation.DataValueField = "PK_WC_FR_ID";
        drpInvestigation.DataBind();
        drpInvestigation.Items.Insert(0, new ListItem("---Select---", "0"));

        //clean up memory
        clsGeneral.DisposeOf(dtInvestigation);
    }

    /// <summary>
    /// Handle First Report Dropdown selected index change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpFirstReportNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListItem li = drpInvestigation.Items.FindByValue(drpFirstReportNumber.SelectedValue);
        drpInvestigation.ClearSelection();

        // Check if selected item is not null
        if (li != null)
            li.Selected = true;
        else
            drpInvestigation.SelectedValue = "0";
    }

    /// <summary>
    /// Handle investigation Dropdown selected index change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpInvestigation_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListItem li = drpFirstReportNumber.Items.FindByValue(drpInvestigation.SelectedValue);

        drpFirstReportNumber.ClearSelection();

        // Check if selected item is not null
        if (li != null)
            li.Selected = true;
        else
            drpFirstReportNumber.SelectedValue = "0";
    }

    /// <summary>
    /// Handle Edit Cause button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEditCuase_Click(object sender, EventArgs e)
    {
        Pk_Investigation = Convert.ToDecimal(drpInvestigation.SelectedItem.Text);
        PK_WC_FR_ID = Convert.ToDecimal(drpFirstReportNumber.SelectedValue);
        Investigation objInvestigation = new Investigation(Convert.ToInt32(Pk_Investigation));
        if (objInvestigation.Sonic_Cause_Code.Substring(0, 2).ToUpper() == "S0")
        {
            lblInvestigationID.Text = Pk_Investigation.ToString();
            lblFirst_Report_Number.Text = drpFirstReportNumber.SelectedItem.Text;
            lblRegion.Text = drpRegion.SelectedItem.Text;
            drpSonic_Cause_Code.SelectedIndex = 0;
            HideSearch();
        }
        else
            ShowSeach();
    }

    /// <summary>
    /// Handle Save Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Investigation.UpdateSonicCauseCode(Convert.ToDecimal(lblInvestigationID.Text), drpSonic_Cause_Code.SelectedItem.Text);
        WC_Allocation_Charges.Promote_CauseCode(PK_WC_FR_ID, clsSession.UserID);
        ShowSeach();
    }

    /// <summary>
    /// Handle Cancel Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ShowSeach();
    }

    #region "Methods"

    /// <summary>
    ///  show investigation Seach Panel
    /// </summary>
    private void ShowSeach()
    {
        pnlSearchInvestigation.Visible = true;
        pnlEditInvestigation.Visible = false;

        drpRegion.SelectedIndex = 0;

        drpFirstReportNumber.Items.Clear();
        drpFirstReportNumber.Items.Insert(0, new ListItem("---Select---", "0"));
        drpFirstReportNumber.SelectedIndex = 0;
        
        drpInvestigation.Items.Clear();
        drpInvestigation.Items.Insert(0, new ListItem("---Select---", "0"));
        drpInvestigation.SelectedIndex = 0;

    }

    /// <summary>
    ///  show investigation edit panel and Hide Seach Panel
    /// </summary>
    private void HideSearch()
    {
        pnlSearchInvestigation.Visible = false;
        pnlEditInvestigation.Visible = true;
    }

    #endregion
}
