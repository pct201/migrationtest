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
/// Date : 14 NOV 2008
/// 
/// By : Amit Makwana
/// 
/// Purpose: 
/// To perform search in Claim information
/// 
/// Functionality:
/// Gets the values from page controls and validates that
/// Stores the values in session and redirects to search result page
/// </summary>
public partial class SONIC_ClaimInformationSearch : clsBasePage
{
    #region Page Load Events
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!clsSession.UserAllowToViewClaimInformation)
        //{
        //    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
        //}

        //check Page is Postback or not
        if (!IsPostBack)
        {
            //FIll Sonic Locaition Number Dropdown
            ComboHelper.FillLocationdba(new DropDownList[] { ddlRMLocationNumber }, 0, true);
            ddlRMLocationNumber.Style.Remove("font-size");
            //fill Location dba Dropdown
            ComboHelper.FIllLocationdba_LegalEntity(new DropDownList[] { ddlLocationdba }, 0, true);
            //fill Location Legal Entity Dropdown
            //ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, 0, true);
            //Fill Locaiton FKA Dropdown
            ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);
            //Fill Associate Name Dropdown
            //ComboHelper.FillAssociateName_ClaimInfo(new DropDownList[] { ddlAssociateName }, 0, true);
            //Fill TPA Claim Number Dropdown
            //ComboHelper.FillTPA_Claim_Number(new DropDownList[] { ddlClaimNumber }, 0, true);

            //ComboHelper.FillClaimantName(new DropDownList[] { ddlClaimantName }, true);
            //ComboHelper.FilterEmployeeClientNamebyLocationNumber(new DropDownList[] { ddlAssociateName}, true, -1);
        }
    }
    #endregion

    #region Dropdown's Selcted Value change Events

    protected void ddlRMLocationNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        /// update all other dropdown according to RM location number selected
        //ddlLegalEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
        ddlLocationdba.SelectedValue = ddlRMLocationNumber.SelectedValue;

        //ComboHelper.FilterEmployeeClientNamebyLocationNumber(new DropDownList[] { ddlAssociateName}, true, Convert.ToDecimal(ddlRMLocationNumber.SelectedValue));

        ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlRMLocationNumber.SelectedValue);
        if (lstItm != null)
            ddlLocationfka.SelectedValue = ddlRMLocationNumber.SelectedValue;
        else
            ddlLocationfka.SelectedValue = "0";
    }
    protected void ddlLocationdba_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to dba selected
        ddlRMLocationNumber.SelectedValue = ddlLocationdba.SelectedValue;
        //ddlLegalEntity.SelectedValue = ddlLocationdba.SelectedValue;
        //ComboHelper.FilterEmployeeClientNamebyLocationNumber(new DropDownList[] { ddlAssociateName}, true, Convert.ToDecimal(ddlRMLocationNumber.SelectedValue));
        ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlLocationdba.SelectedValue);
        if (lstItm != null)
            ddlLocationfka.SelectedValue = ddlLocationdba.SelectedValue;
        else
            ddlLocationfka.SelectedValue = "0";
    }
    protected void ddlLegalEntity_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to entity selected
        //ddlRMLocationNumber.SelectedValue = ddlLegalEntity.SelectedValue;
        //ddlLocationdba.SelectedValue = ddlLegalEntity.SelectedValue;
        ////ComboHelper.FilterEmployeeClientNamebyLocationNumber(new DropDownList[] { ddlAssociateName}, true, Convert.ToDecimal(ddlRMLocationNumber.SelectedValue));
        //ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlLegalEntity.SelectedValue);
        //if (lstItm != null)
        //    ddlLocationfka.SelectedValue = ddlLegalEntity.SelectedValue;
        //else
        //    ddlLocationfka.SelectedValue = "0";
    }
    protected void ddlLocationfka_SelectedIndexChanged(object sender, EventArgs e)
    {
        //// update all other dropdown according to fka selected
        if (ddlLocationfka.SelectedValue != "0")
        {
            ListItem lstItm;
            lstItm = ddlRMLocationNumber.Items.FindByValue(ddlLocationfka.SelectedValue);
            ddlRMLocationNumber.SelectedValue = (lstItm != null) ? ddlLocationfka.SelectedValue : "0";
            //lstItm = ddlLegalEntity.Items.FindByValue(ddlLocationfka.SelectedValue);
            //ddlLegalEntity.SelectedValue = (lstItm != null) ? ddlLocationfka.SelectedValue : "0";
            lstItm = ddlLocationdba.Items.FindByValue(ddlLocationfka.SelectedValue);
            ddlLocationdba.SelectedValue = (lstItm != null) ? ddlLocationfka.SelectedValue : "0";
        }
        else
        {
            ddlLocationdba.SelectedValue = "0";
            //ddlLegalEntity.SelectedValue = "0";
            ddlRMLocationNumber.SelectedValue = "0";
        }
    }

    #endregion

    #region Search Button Click Event
    protected void btnSearch_Click(object sender, EventArgs e)
    {      
        
            // create an object for datatable
            DataTable dtSearch = new DataTable();

            // columns for search values
            DataColumn dcLocationNumber = new DataColumn("LocationNumber", typeof(decimal));
            DataColumn dcEmployeeName = new DataColumn("EmployeeName", typeof(string));
            DataColumn dcDateOfAccident = new DataColumn("DateOfAccident", typeof(DateTime));
            DataColumn dcAssociatedFirstReport = new DataColumn("AssociatedFirstReport", typeof(int));
            DataColumn dcTPAClaimNumber = new DataColumn("TPAClaimNumber", typeof(string));
            DataColumn dcClaimType = new DataColumn("ClaimType", typeof(string));
            DataColumn dcClaimStatus = new DataColumn("ClaimStatus", typeof(string));
            DataColumn dcClaimantName = new DataColumn("ClaimantName", typeof(string));

            // add columns in datatable
            dtSearch.Columns.Add(dcLocationNumber);
            dtSearch.Columns.Add(dcEmployeeName);
            dtSearch.Columns.Add(dcDateOfAccident);
            dtSearch.Columns.Add(dcAssociatedFirstReport);
            dtSearch.Columns.Add(dcTPAClaimNumber);
            dtSearch.Columns.Add(dcClaimType);
            dtSearch.Columns.Add(dcClaimStatus);
            dtSearch.Columns.Add(dcClaimantName);
            //create a row with all search values 
            DataRow drSearch = dtSearch.NewRow();
            drSearch["LocationNumber"] = (ddlRMLocationNumber.SelectedIndex > 0) ? Convert.ToDecimal(ddlRMLocationNumber.SelectedValue) : 0;
            drSearch["EmployeeName"] = txtAssociateName.Text.Trim();
            drSearch["DateOfAccident"] = clsGeneral.FormatDateToStore(txtIncidentDate);
            drSearch["AssociatedFirstReport"] = Convert.ToInt32((txtFirstReportNumber.Text != "") ? txtFirstReportNumber.Text : "0");
            drSearch["TPAClaimNumber"] = txtClaimNumber.Text.Trim();
            drSearch["ClaimType"] = (ddlClaimType.SelectedIndex > 0) ? ddlClaimType.SelectedValue : "";
            drSearch["ClaimStatus"] = rdoClaim.SelectedValue;
            drSearch["ClaimantName"] = txtClaimantName.Text.Trim();
            // add the row in datatable
            dtSearch.Rows.Add(drSearch);

            // store the table in session and redirect to search result page
            Session["dtClaimInfoSearch"] = dtSearch;
            Response.Redirect("ClaimInformationSearchGrid.aspx", true);
       
    }
    #endregion
}
