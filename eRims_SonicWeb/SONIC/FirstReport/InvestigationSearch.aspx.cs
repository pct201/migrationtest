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
public partial class SONIC_FirstReport_InvestigationSearch : clsBasePage
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Page is Postback or not
        if (!IsPostBack)
        {
            //used to fill RM Location Number Dropdown
            ComboHelper.FillLocationdba(new DropDownList[] { ddlRMLocationNumber }, 0, true);
            ddlRMLocationNumber.Style.Remove("font-size");
            //used to fill Legal Entity Dropdown
            //ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, 0, true);
            //used to fill dba Dropdown
            ComboHelper.FillLocationdbaOnly(new DropDownList[] { ddlLocationdba }, 0, true);
            //used to fill fka dropdown
            ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);
        }
    }

    /// <summary>
    /// Handles Search button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // create datatable to keep search values
        DataTable dtSearch = new DataTable();
        DataColumn dcLocationIDs = new DataColumn("LocationIDs", typeof(string));
        DataColumn dcFromDate = new DataColumn("FromDate", typeof(string));
        DataColumn dcToDate = new DataColumn("ToDate", typeof(string));
        DataColumn dcFirstReportNum = new DataColumn("FR_Number", typeof(decimal));
        DataColumn dcIncidentDate = new DataColumn("IncidentDate", typeof(string));

        dtSearch.Columns.Add(dcLocationIDs);
        dtSearch.Columns.Add(dcFromDate);
        dtSearch.Columns.Add(dcToDate);
        dtSearch.Columns.Add(dcFirstReportNum);
        dtSearch.Columns.Add(dcIncidentDate);

        // get values from page controls
        string strLocationIDs = string.Empty;
        if (ddlRMLocationNumber.SelectedIndex > 0) strLocationIDs = ddlRMLocationNumber.SelectedValue.ToString();
        //if (ddlLegalEntity.SelectedIndex > 0) strLocationIDs = strLocationIDs != "" ? strLocationIDs + "," + ddlLegalEntity.SelectedValue.ToString() : ddlLegalEntity.SelectedValue.ToString();
        if (ddlLocationdba.SelectedIndex > 0) strLocationIDs = strLocationIDs != "" ? strLocationIDs + "," + ddlLocationdba.SelectedValue.ToString() : ddlLocationdba.SelectedValue.ToString();
        if (ddlLocationfka.SelectedIndex > 0) strLocationIDs = strLocationIDs != "" ? strLocationIDs + "," + ddlLocationfka.SelectedValue.ToString() : ddlLocationfka.SelectedValue.ToString();

        // add values in datatable
        DataRow drSearch = dtSearch.NewRow();
        drSearch[0] = strLocationIDs;
        drSearch[1] = txtStartRangeDate.Text;
        drSearch[2] = txtEndRangeDate.Text;
        drSearch[3] = txtFirstReportNumber.Text.Trim() != "" ? Convert.ToDecimal(txtFirstReportNumber.Text.Trim()) : 0;
        drSearch[4] = txtDateofIncident.Text;
        dtSearch.Rows.Add(drSearch);

        // store table in session to be used in search result page
        Session["dtInvSearchTable"] = dtSearch;

        // redirect to search result page
        Response.Redirect("InvestigationSearchResult.aspx");

    }

    /// <summary>
    /// Handles event when RM location number dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRMLocationNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to RM location number selected
        //ddlLegalEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
        ddlLocationdba.SelectedValue = ddlRMLocationNumber.SelectedValue;
        ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlRMLocationNumber.SelectedValue);
        if (lstItm != null)
            ddlLocationfka.SelectedValue = ddlRMLocationNumber.SelectedValue;
        else
            ddlLocationfka.SelectedValue = "0";
    }

    /// <summary>
    /// Handles event when Leagal entity dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void ddlLegalEntity_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // update all other dropdown according to entity selected
    //    ddlRMLocationNumber.SelectedValue = ddlLegalEntity.SelectedValue;
    //    ddlLocationdba.SelectedValue = ddlLegalEntity.SelectedValue;
    //    ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlLegalEntity.SelectedValue);
    //    if (lstItm != null)
    //        ddlLocationfka.SelectedValue = ddlLegalEntity.SelectedValue;
    //    else
    //        ddlLocationfka.SelectedValue = "0";
    //}

    /// <summary>
    /// Handles event when dba dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlLocationdba_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to dba selected
        ddlRMLocationNumber.SelectedValue = ddlLocationdba.SelectedValue;
        //ddlLegalEntity.SelectedValue = ddlLocationdba.SelectedValue;
        ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlLocationdba.SelectedValue);
        if (lstItm != null)
            ddlLocationfka.SelectedValue = ddlLocationdba.SelectedValue;
        else
            ddlLocationfka.SelectedValue = "0";
    }

    /// <summary>
    /// Handles event when fka dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlLocationfka_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to fka selected
        ddlRMLocationNumber.SelectedValue = ddlLocationfka.SelectedValue;
        //ddlLegalEntity.SelectedValue = ddlLocationfka.SelectedValue;
        ddlLocationdba.SelectedValue = ddlLocationfka.SelectedValue;
    }
    #endregion
}
