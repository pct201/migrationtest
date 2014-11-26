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
/// <summary>
/// Date           : 18-07-08
/// 
/// Developer Name : Ravi Gupta
/// 
/// Description    : Used to search the First Reports by passing the desire criteria.
/// 
/// </summary>
public partial class SONIC_FirstReportSearch : clsBasePage
{
    #region Page Load Events
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check Page Post Back or not
        if (!IsPostBack)
        {
            //FIll Sonic Locaition Number Dropdown
            ComboHelper.FillLocationdba(new DropDownList[] { ddlRMLocationNumber }, 0, true);
            ddlRMLocationNumber.Style.Remove("font-size");
            //fill Location dba Dropdown
            ComboHelper.FillLocationdbaOnly(new DropDownList[] { ddlLocationdba }, 0, true);
            ddlLocationdba.Style.Remove("font-size");
            //fill Location Legal Entity Dropdown
            ComboHelper.FillDistinctLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, true);
            //Fill Locaiton FKA Dropdown
            ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);
            //Fill Associate Name Dropdown
            //ComboHelper.FillAssociateName(new DropDownList[] { ddlAssociateName }, 0, true);
            //check User Access Type if it View Only than display Add Button
            if (Module_Access_Mode == AccessType.View_Only)
            //if (UserAccessType == AccessType.View_Only)
            {
                btnAdd.Visible = false;
            }
        }
    }
    #endregion
    #region Search Button Click Event
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //check page is valid or not
        if (IsValid)
        {
            // create an object for datatable
            DataTable dtSearch = new DataTable();

            // columns for search values
            DataColumn dcLocationNumber = new DataColumn("LocationNumber", typeof(decimal));
            DataColumn dcEmployeeID = new DataColumn("EmployeeID", typeof(decimal));
            DataColumn dcDateOfIncident = new DataColumn("DateOfIncident", typeof(DateTime));
            DataColumn dcIncidentStartDate = new DataColumn("IncidentStartDate", typeof(string));
            DataColumn dcIncidentEndDate = new DataColumn("IncidentEndDate", typeof(string));
            DataColumn dcFirstReportNumber = new DataColumn("FirstReportNumber", typeof(decimal));
            DataColumn dcClaimNumber = new DataColumn("ClaimNumber", typeof(decimal));
            DataColumn dcClaimType = new DataColumn("ClaimType", typeof(string));

            // add columns in datatable
            dtSearch.Columns.Add(dcLocationNumber);
            dtSearch.Columns.Add(dcEmployeeID);
            dtSearch.Columns.Add(dcDateOfIncident);
            dtSearch.Columns.Add(dcIncidentStartDate);
            dtSearch.Columns.Add(dcIncidentEndDate);
            dtSearch.Columns.Add(dcFirstReportNumber);
            dtSearch.Columns.Add(dcClaimNumber);
            dtSearch.Columns.Add(dcClaimType);
            //create a row with all search values 
            DataRow drSearch = dtSearch.NewRow();
            drSearch["LocationNumber"] = (ddlRMLocationNumber.SelectedIndex > 0) ? Convert.ToDecimal(ddlRMLocationNumber.SelectedValue) : 0;
            drSearch["EmployeeID"] = (HdnEmployeeID.Value.ToString() != string.Empty) ? Convert.ToDecimal(HdnEmployeeID.Value) : 0;
            drSearch["DateOfIncident"] = clsGeneral.FormatDateToStore(txtIncidentDate);
            drSearch["IncidentStartDate"] = txtIncidentStartDate.Text;
            drSearch["IncidentEndDate"] = txtIncidentEndDate.Text;
            drSearch["FirstReportNumber"] = (txtFirstReportNumber.Text != "") ? Convert.ToDecimal(txtFirstReportNumber.Text) : 0;
            drSearch["ClaimNumber"] = (ddlClaimNumber.SelectedIndex > 0) ? Convert.ToDecimal(ddlClaimNumber.SelectedValue) : 0;
            drSearch["ClaimType"] = (ddlCategory.SelectedIndex > 0) ? ddlCategory.SelectedValue : "";

            // add the row in datatable
            dtSearch.Rows.Add(drSearch);

            // store the table in session and redirect to search result page
            Session["dtReportSearch"] = dtSearch;
            Response.Redirect("FirstReportSearchGrid.aspx", true);
        }
    }
    #endregion
    #region Add Button Click Event
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("FirstReportAddWizard.aspx", true);
    }
    #endregion
    #region Dropdown's Selcted Value change Events
    protected void ddlRMLocationNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Check dropdown's value is selected or not
        if (ddlRMLocationNumber.SelectedValue != "0")
        {
            //// fill Location dba DropDown
            //ComboHelper.FillLocationdba(new DropDownList[] { ddlLocationdba }, (ddlRMLocationNumber.SelectedIndex > 0) ? Convert.ToInt32(ddlRMLocationNumber.SelectedValue) : 0, true);
            ////fill Location Legal Entity Dropdown
            //ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, (ddlRMLocationNumber.SelectedIndex > 0) ? Convert.ToInt32(ddlRMLocationNumber.SelectedValue) : 0, true);
            ////fill Location FKA dropdown
            //ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, (ddlRMLocationNumber.SelectedIndex > 0) ? Convert.ToInt32(ddlRMLocationNumber.SelectedValue) : 0, true);
            ListItem lstLegalEntity = ddlLegalEntity.Items.FindByText(new LU_Location(Convert.ToDecimal(ddlRMLocationNumber.SelectedValue)).legal_entity);
            ddlLegalEntity.ClearSelection();
            if(lstLegalEntity != null)
                lstLegalEntity.Selected = true;
            ddlLocationdba.SelectedValue = ddlRMLocationNumber.SelectedValue;
            ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlRMLocationNumber.SelectedValue);
            if (lstItm != null)
                ddlLocationfka.SelectedValue = ddlRMLocationNumber.SelectedValue;
            else
                ddlLocationfka.SelectedValue = "0";
        }
        else
        {
            ddlLocationdba.SelectedValue = "0";
            ddlLegalEntity.SelectedValue = "0";
            ddlLocationfka.SelectedValue = "0";
        }
    }
    protected void ddlLocationdba_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Check dropdown's value is selected or not
        if (ddlLocationdba.SelectedValue != "0")
        {
            ////fill Sonic Location Number Dropdown
            //ComboHelper.FillSonicLocationNumber(new DropDownList[] { ddlRMLocationNumber }, (ddlLocationdba.SelectedIndex > 0) ? Convert.ToInt32(ddlLocationdba.SelectedValue) : 0, true);
            ////fill Location Legal Entity Dropdown
            //ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, (ddlLocationdba.SelectedIndex > 0) ? Convert.ToInt32(ddlLocationdba.SelectedValue) : 0, true);
            ////fill Location FKA dropdown
            //ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, (ddlLocationdba.SelectedIndex > 0) ? Convert.ToInt32(ddlLocationdba.SelectedValue) : 0, true);
            ddlRMLocationNumber.SelectedValue = ddlLocationdba.SelectedValue;
            //ddlLegalEntity.SelectedValue = ddlLocationdba.SelectedValue;
            ListItem lstLegalEntity = ddlLegalEntity.Items.FindByText(new LU_Location(Convert.ToDecimal(ddlRMLocationNumber.SelectedValue)).legal_entity);
            ddlLegalEntity.ClearSelection();
            if (lstLegalEntity != null)
                lstLegalEntity.Selected = true;
            ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlLocationdba.SelectedValue);
            if (lstItm != null)
                ddlLocationfka.SelectedValue = ddlLocationdba.SelectedValue;
            else
                ddlLocationfka.SelectedValue = "0";
        }
        else
        {
            ddlRMLocationNumber.SelectedValue = "0";
            ddlLegalEntity.SelectedValue = "0";
            ddlLocationfka.SelectedValue = "0";
        }
    }
    protected void ddlLegalEntity_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Check dropdown's value is selected or not
        if (ddlLegalEntity.SelectedValue != "0")
        {
            //// fill Location dba DropDown
            //ComboHelper.FillLocationdba(new DropDownList[] { ddlLocationdba }, (ddlLegalEntity.SelectedIndex > 0) ? Convert.ToInt32(ddlLegalEntity.SelectedValue) : 0, true);
            ////fill Sonic Location Number Dropdown
            //ComboHelper.FillSonicLocationNumber(new DropDownList[] { ddlRMLocationNumber }, (ddlLegalEntity.SelectedIndex > 0) ? Convert.ToInt32(ddlLegalEntity.SelectedValue) : 0, true);
            ////fill Location FKA dropdown
            //ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, (ddlLegalEntity.SelectedIndex > 0) ? Convert.ToInt32(ddlLegalEntity.SelectedValue) : 0, true);
            //ddlRMLocationNumber.SelectedValue = ddlLegalEntity.SelectedValue;
            //ddlLocationdba.SelectedValue = ddlLegalEntity.SelectedValue;
            //ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlLegalEntity.SelectedValue);
            //if (lstItm != null)
            //    ddlLocationfka.SelectedValue = ddlLegalEntity.SelectedValue;
            //else
            //    ddlLocationfka.SelectedValue = "0";
        }
        else
        {
            ddlLocationdba.SelectedValue = "0";
            ddlRMLocationNumber.SelectedValue = "0";
            ddlLocationfka.SelectedValue = "0";
        }
    }
    protected void ddlLocationfka_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Check dropdown's value is selected or not
        if (ddlLocationfka.SelectedValue != "0")
        {
            //// fill Location dba DropDown
            //ComboHelper.FillLocationdba(new DropDownList[] { ddlLocationdba }, (ddlLocationfka.SelectedIndex > 0) ? Convert.ToInt32(ddlLocationfka.SelectedValue) : 0, true);
            ////fill Location Legal Entity Dropdown
            //ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, (ddlLocationfka.SelectedIndex > 0) ? Convert.ToInt32(ddlLocationfka.SelectedValue) : 0, true);
            ////fill Sonic Location Number Dropdown
            //ComboHelper.FillSonicLocationNumber(new DropDownList[] { ddlRMLocationNumber }, (ddlLocationfka.SelectedIndex > 0) ? Convert.ToInt32(ddlLocationfka.SelectedValue) : 0, true);

            //ddlRMLocationNumber.SelectedValue = ddlLocationfka.SelectedValue;
            ////ddlLegalEntity.SelectedValue = ddlLocationfka.SelectedValue;
            //ListItem lstLegalEntity = ddlLegalEntity.Items.FindByText(new LU_Location(Convert.ToDecimal(ddlRMLocationNumber.SelectedValue)).legal_entity);
            //ddlLegalEntity.ClearSelection();
            //if (lstLegalEntity != null)
            //    lstLegalEntity.Selected = true;
            //ddlLocationdba.SelectedValue = ddlLocationfka.SelectedValue;
        }
        else
        {
            ddlLocationdba.SelectedValue = "0";
            ddlLegalEntity.SelectedValue = "0";
            ddlRMLocationNumber.SelectedValue = "0";
        }
    }
    /// <summary>
    /// Handles changes of Location Lists when Employee name changes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAssName_OnClick(object sender, EventArgs e)
    {
        if (HdnEmployeeName.Value != "")
            lnkAssName.InnerText = HdnEmployeeName.Value;
        else
            lnkAssName.InnerText = "Associate Name";
    }

    #endregion
}
