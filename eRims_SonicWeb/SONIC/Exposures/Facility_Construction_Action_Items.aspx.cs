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

public partial class SONIC_Exposures_Facility_Construction_Action_Items : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Page is Postback or not
        if (!IsPostBack)
        {
            

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

        // get values from page controls
        string strLocationIDs = string.Empty;
       
        // store table in session to be used in search result page
        Session["dtExposureSearchTable"] = dtSearch;

        // redirect to search result page
        Response.Redirect("ExposureSearchResult.aspx");

    }

   
    #endregion
}