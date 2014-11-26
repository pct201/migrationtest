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
/// Date : 10 OCT 2008
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// To open the PDF for the selected Business Interruption type on the property page
/// 
/// Functionality:
/// Lists the Years matching to the Location and Business Interruption type 
/// 
/// By clicking on the year it opens the PDF if available
/// </summary>
public partial class SONIC_Exposures_PropetySelectYear : System.Web.UI.Page
{

    #region "Properties"

    /// <summary>
    /// Denotes FK for location
    /// </summary>
    private int FK_LU_Location_ID
    {
        get
        {
            if (Request.QueryString["loc"] != null)
            {
                int index;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out index))
                {
                    return index;
                }
            }
            return 0;
        }
    }

    /// <summary>
    /// Denotes type of the property (Salaries, Benefits, Expenses, Net profit)
    /// </summary>
    private string PropertyType
    {
        get { return Convert.ToString(Request.QueryString["type"]); }
    }

    #endregion

    #region "Page Events"
    /// <summary>
    /// Handles an event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // get COI data for all years of a location and bind the grid
            DataTable dtYears = Property_COI.SelectYears(FK_LU_Location_ID, PropertyType).Tables[0];
            gvYears.DataSource = dtYears;
            gvYears.DataBind();
        }
    }
    #endregion
}
