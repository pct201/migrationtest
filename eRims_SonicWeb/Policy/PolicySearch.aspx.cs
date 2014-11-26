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
using System.Collections.Generic;
using RIMS_Base;
using RIMS_Base.Biz;
using ERIMS.DAL;

public partial class Policy_PolicySearch : clsBasePage
{
    /// <summary>
    /// PAge Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Session["PolicyId"] = null;
            Session["PolicyPageSize"] = null;
            Session["SortExp"] = null;
            Session["sortDirection"] = null;
            Session["PolicyCurrentPage"] = null;
            BindCombos();
        }
    }

    #region Event
    /// <summary>
    /// DropDown Selected Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboHelper.FillPolicyType(new DropDownList[] { ddlPolicyType }, Convert.ToDecimal(ddlProgram.SelectedValue), false);
        ddlPolicyType.Items.Insert(0, "--Select Policy Type--");
    }
    /// <summary>
    /// Handle Search Button Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindSearchDetails();
        Response.Redirect("PolicySearchResult.aspx");

    }
    /// <summary>
    /// Bind Search Detail 
    /// </summary>
    protected void BindSearchDetails()
    {

        DataTable dtSearchCriteria = new DataTable();
        DataColumn dcSearch;

        dcSearch = new DataColumn("FK_Policy_Type", typeof(decimal));
        dtSearchCriteria.Columns.Add(dcSearch);

        dcSearch = new DataColumn("Carrier", typeof(string));
        dtSearchCriteria.Columns.Add(dcSearch);

        dcSearch = new DataColumn("Policy_Year", typeof(int));
        dtSearchCriteria.Columns.Add(dcSearch);

        dcSearch = new DataColumn("PK_Security_Id", typeof(decimal));
        dtSearchCriteria.Columns.Add(dcSearch);

        dcSearch = new DataColumn("ProgramID", typeof(decimal));
        dtSearchCriteria.Columns.Add(dcSearch);

        dcSearch = new DataColumn("LocationID", typeof(decimal));
        dtSearchCriteria.Columns.Add(dcSearch);

        DataRow drSearch = dtSearchCriteria.NewRow();
        drSearch["FK_Policy_Type"] = (ddlPolicyType.SelectedIndex > 0) ? Convert.ToDecimal(ddlPolicyType.SelectedItem.Value) : -1;
        drSearch["Carrier"] = txtCarrier.Text.Trim();
        drSearch["Policy_Year"] = (txtPolicyYear.Text != String.Empty ? Convert.ToInt32(txtPolicyYear.Text) : -1);
        drSearch["ProgramID"] = ddlProgram.SelectedIndex > 0 ? Convert.ToDecimal(ddlProgram.SelectedValue) : 0;
        drSearch["LocationID"] = ddlLocation.SelectedIndex > 0 ? Convert.ToDecimal(ddlLocation.SelectedValue) : 0;
        dtSearchCriteria.Rows.Add(drSearch);

        Session["PolicySearch"] = dtSearchCriteria;

    }
    /// <summary>
    /// Bind DropDown List
    /// </summary>
    private void BindCombos()
    {
        try
        {

            ddlPolicyType.Items.Insert(0, "--Select Policy Type--");

            ComboHelper.FillProgram(new DropDownList[] { ddlProgram }, true);
            ComboHelper.FillLocationdbaOnly(new DropDownList[] { ddlLocation }, 0, true);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion



}
