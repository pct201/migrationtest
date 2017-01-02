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
/// Date : 7 OCT 2008
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// To perform search
/// 
/// Functionality:
/// Gets the values from page controls and validates that
/// Stores the values in session and redirects to search result page
/// </summary>
public partial class Exposures_ExposureSearch : clsBasePage
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Page is Postback or not
        if (!IsPostBack)
        {
            //used to fill RM Location Number Dropdown
            ComboHelper.FillLocationdba(new DropDownList[] { ddlRMLocationNumber }, 0, true, true);
            ddlRMLocationNumber.Style.Remove("font-size");
            //used to fill Legal Entity Dropdown
            //ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, 0, true, true);
            //used to fill dba Dropdown
            ComboHelper.FillLocationdbaOnly(new DropDownList[] { ddlLocationdba }, 0, true, true);
            //used to fill fka dropdown
            ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);

            //// binds State dropdown in Property COPE panel
            DataTable dtState = State.SelectAll().Tables[0];
            drpMainState.DataSource = dtState;
            drpMainState.DataValueField = "FLD_state";
            drpMainState.DataTextField = "FLD_state";
            drpMainState.DataBind();
            drpMainState.Items.Insert(0, new ListItem("--Select--", ""));

            drpBuildingState.DataSource = dtState;
            drpBuildingState.DataValueField = "FLD_state";
            drpBuildingState.DataTextField = "FLD_state";
            drpBuildingState.DataBind();
            drpBuildingState.Items.Insert(0, new ListItem("--Select--", ""));

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
       
        dtSearch.Columns.Add(new DataColumn("LocationIDs", typeof(string)));
        dtSearch.Columns.Add(new DataColumn("FromDate", typeof(string)));
        dtSearch.Columns.Add(new DataColumn("ToDate", typeof(string)));
        dtSearch.Columns.Add(new DataColumn("Main_Address", typeof(string)));
        dtSearch.Columns.Add(new DataColumn("Main_City", typeof(string)));
        dtSearch.Columns.Add(new DataColumn("Main_State", typeof(string)));
        dtSearch.Columns.Add(new DataColumn("Main_Zip", typeof(string)));
        dtSearch.Columns.Add(new DataColumn("Building_Address", typeof(string)));
        dtSearch.Columns.Add(new DataColumn("Building_City", typeof(string)));
        dtSearch.Columns.Add(new DataColumn("Building_State", typeof(string)));
         dtSearch.Columns.Add(new DataColumn("Building_Zip", typeof(string)));
       dtSearch.Columns.Add(new DataColumn("Project_Number", typeof(string)));
    
        // get values from page controls
        string strLocationIDs = string.Empty;
        if (ddlRMLocationNumber.SelectedIndex > 0) strLocationIDs = ddlRMLocationNumber.SelectedValue;
        //if (ddlLegalEntity.SelectedIndex > 0) strLocationIDs = strLocationIDs != "" ? strLocationIDs + "," + ddlLegalEntity.SelectedValue : ddlLegalEntity.SelectedValue;
        if (ddlLocationdba.SelectedIndex > 0) strLocationIDs = strLocationIDs != "" ? strLocationIDs + "," + ddlLocationdba.SelectedValue : ddlLocationdba.SelectedValue;
        if (ddlLocationfka.SelectedIndex > 0) strLocationIDs = strLocationIDs != "" ? strLocationIDs + "," + ddlLocationfka.SelectedValue : ddlLocationfka.SelectedValue;

        // add values in datatable
        DataRow drSearch = dtSearch.NewRow();
        drSearch[0] = strLocationIDs;
        drSearch[1] = txtStartRangeDate.Text;
        drSearch[2] = txtEndRangeDate.Text;
        drSearch[3] = txtMainAddress.Text;
        drSearch[4] = txtMainCity.Text;
        drSearch[5] = drpMainState.Text;
        drSearch[6] = txtMainZip.Text;
        drSearch[7] = txtBuildingAddress.Text;
        drSearch[8] = txtBuildingCity.Text;
        drSearch[9] = drpBuildingState.Text;
        drSearch[10] = txtBuildingZip.Text;
        drSearch[11] = txtConstructionProjectNumber.Text;
        dtSearch.Rows.Add(drSearch);

        // store table in session to be used in search result page
        Session["dtExposureSearchTable"] = dtSearch;

        // redirect to search result page
        Response.Redirect("ExposureSearchResult.aspx");

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
    protected void ddlLegalEntity_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to entity selected
        //ddlRMLocationNumber.SelectedValue = ddlLegalEntity.SelectedValue;
        //ddlLocationdba.SelectedValue = ddlLegalEntity.SelectedValue;
        //ListItem lstItm = ddlLocationfka.Items.FindByValue(ddlLegalEntity.SelectedValue);
        //if (lstItm != null)
        //    ddlLocationfka.SelectedValue = ddlLegalEntity.SelectedValue;
        //else
        //    ddlLocationfka.SelectedValue = "0";
    }

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
}
