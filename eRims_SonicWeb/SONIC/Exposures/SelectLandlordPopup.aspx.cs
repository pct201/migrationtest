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

/// <summary>
/// Date : 06 JUNE 09
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// To list the Building and Ownership information records for selection
/// 
/// Functionality:
/// Binds the grid with the Building records for location id passed in querystring
/// When clicking or selecting the record a javascript function is called to store 
/// all necessary information in hidden control of Lease page and calls click event 
/// of hidden button on lease page to set the values on that page
/// </summary>
public partial class SONIC_Exposures_SelectLandlordPopup : System.Web.UI.Page
{
    #region "Page Events"

    /// <summary>
    /// Handles page load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!IsPostBack)
        {
            // binds the grid
            BindGrid();
        }
    }
    #endregion

    #region "Methods"

    /// <summary>
    /// Binds the grid
    /// </summary>
    private void BindGrid()
    {
        // get the location ID from the querystring
        int Fk_Loc_Id = Convert.ToInt32(Encryption.Decrypt(Request.QueryString["loc"]));

        // get the building and building_ownership records by the location id 
        DataTable dtOwnership = Building.SelectBuildingOwnerships(Fk_Loc_Id).Tables[0];

        // bind the grid
        gvOwnership.DataSource = dtOwnership;
        gvOwnership.DataBind();
    }
    #endregion

    #region " Gridview Events"

    /// <summary>
    /// Handles event when Ownership grid row data is bound 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvOwnership_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if rowtype is data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the link contols in grid
            HtmlAnchor lnkBuildingNumber = (HtmlAnchor)e.Row.FindControl("lnkBuildingNumber");
            HtmlAnchor lnkLandlord = (HtmlAnchor)e.Row.FindControl("lnkLandlord");
            HtmlAnchor lnkCommencementDate = (HtmlAnchor)e.Row.FindControl("lnkCommencementDate");
            HtmlAnchor lnkExpirationDate = (HtmlAnchor)e.Row.FindControl("lnkExpirationDate");

            // get all data for row
            string strLandlord = Convert.ToString(DataBinder.Eval(e.Row.DataItem,"Landlord_Name"));
            string strAddress1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Landlord_Address_1"));
            string strAddress2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Landlord_Address_2"));
            string strCity = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Landlord_City"));
            string strState = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Landlord_State"));
            string strZipcode = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Landlord_Zip"));
            string strLeaseID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Lease_Id"));
            string strCommenceDate = clsGeneral.FormatDBNullDateToDisplay(DataBinder.Eval(e.Row.DataItem, "Commencement_Date"));
            string strExpDate = clsGeneral.FormatDBNullDateToDisplay(DataBinder.Eval(e.Row.DataItem, "Expiration_Date"));
            string strSubLease = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sublease"));
            string strSubLandlord = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sublandlord"));
            string strYear = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Year_Built"));
            string strLandlordLegalEntity = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Landlord_Legal_Entity"));

            // prepare the string to call JS function along with the above data as parameter
            string strFunction = "SelectValue('" + strLandlord + "','" + strAddress1 + "','" + strAddress2 + "','" + strCity + "','" + strState + "','" +
                strZipcode + "','" + strLeaseID + "','" + strCommenceDate + "','" + strExpDate + "','" + strSubLease + "','" + strSubLandlord + "','" + strYear + "','" + strLandlordLegalEntity + "');";

            // add attribute for each link in grid to call the JS function
            lnkBuildingNumber.Attributes.Add("onclick", strFunction);
            lnkLandlord.Attributes.Add("onclick", strFunction);
            lnkCommencementDate.Attributes.Add("onclick", strFunction);
            lnkExpirationDate.Attributes.Add("onclick", strFunction);
        }

    }
    #endregion
}
