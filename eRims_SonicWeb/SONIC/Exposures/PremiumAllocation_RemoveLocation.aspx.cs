using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using ERIMS_DAL;
using ERIMS.DAL;

public partial class SONIC_Exposures_PremiumAllocation_RemoveLocation : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillYear();
            ComboHelper.FillNewLocationForPremiumAllocation(new DropDownList[] { drpLocation }, 0, true, Convert.ToInt32(ddlYear.SelectedValue), "Remove");
        }
    }

    #region "Controls Events"

    /// <summary>
    /// Handles Remove button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        int? year = null;
        decimal location = 0;
        int? month = null;

        year = Convert.ToInt32(ddlYear.SelectedValue);
        if (drpLocation.SelectedIndex > 0)
            location = Convert.ToDecimal(drpLocation.SelectedValue);
        if (ddlMonth.SelectedIndex > 0)
            month = Convert.ToInt32(ddlMonth.SelectedValue);

        clsPA_Screen_Fields.PremiumAllocation_Removelocation(year, month, location);
        ComboHelper.FillNewLocationForPremiumAllocation(new DropDownList[] { drpLocation }, 0, true, Convert.ToInt32(ddlYear.SelectedValue), "Remove");
       
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('Location record removed successfully for selected year and month.');", true);
    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        ddlYear.SelectedIndex = 0;
        drpLocation.SelectedIndex = 0;
        ddlMonth.SelectedIndex = 0;
    }

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    /// <summary>
    /// Back hrom report to Criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        trCriteria.Visible = true;
    }

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboHelper.FillNewLocationForPremiumAllocation(new DropDownList[] { drpLocation }, 0, true, Convert.ToInt32(ddlYear.SelectedValue), "Remove");
    }
    #endregion

    #region Methods

    /// <summary>
    /// Fill Year Drop Down
    /// </summary>
    private void FillYear()
    {
        ComboHelper.FillYearPremiumAllocation(new DropDownList[] { ddlYear }, true);
    }


    #endregion
}