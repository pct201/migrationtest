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
 * 
 * Developer Name : Mrunal Parekh
 * 
 * File Name      :	COIInfo.ascx
 *
 * Description    :	This User control display COI Information bar for COI Module.
 *
 *************************************************************************************************************************************/

public partial class COIInfo : System.Web.UI.UserControl
{
    #region "Properties"

    /// <summary>
    /// Primary key for COI_Information Table
    /// </summary>
    public decimal PK_COIs
    {
        get { return Convert.ToInt32(ViewState["PK_COIs"]); }
        set { ViewState["PK_COIs"] = value; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// method used for Bind COI Information 
    /// </summary>
    public void BindrCOIInfo()
    {
            // Get Information from databse
            COIs objCOI = new COIs(PK_COIs);
            LU_Location objLocation = new LU_Location(Convert.ToDecimal(objCOI.FK_LU_Location_ID));
            COI_Insureds objInsured = new COI_Insureds(objCOI.FK_COI_Insureds);

            lblDBALocationName.Text = Convert.ToString(objLocation.dba);
            if (objLocation.Sonic_Location_Code < 0)
            {
                lblSonicLocationNo.Text = "";
            }
            else
                lblSonicLocationNo.Text = Convert.ToString(objLocation.Sonic_Location_Code);
            lblInsuredName.Text = Convert.ToString(objInsured.Insured_Name);
            lblIssueDate.Text = clsGeneral.FormatDate(objCOI.Issue_Date);
            lblEffectiveDate.Text = clsGeneral.FormatDate(objInsured.Date_Closed);
      }
}
