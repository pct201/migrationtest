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
 * Developer Name : Ravi Patel
 * 
 * File Name      :	RealEstateInfo.ascx
 *
 * Description    :	This User control display Real Estate Information bar for Real Estate Module.
 *
 *************************************************************************************************************************************/

public partial class RealEstateInfo : System.Web.UI.UserControl
{
    #region "Properties"

    /// <summary>
    /// Primary key for RE_Information Table
    /// </summary>
    public decimal PK_RE_Information
    {
        get { return Convert.ToInt32(ViewState["PK_RE_Information"]); }
        set { ViewState["PK_RE_Information"] = value; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// method used for Bind Real Estate Information 
    /// </summary>
    public void BindrRealEstateInfo()
    {        
        if (PK_RE_Information > 0)
        {
            // Get Information from databse
            RE_Information objRE_Information = new RE_Information(PK_RE_Information);
            LU_Location objLocation = new LU_Location(Convert.ToDecimal(objRE_Information.FK_LU_Location));
            lblDealership.Text = objLocation.dba + " - " + objLocation.City + ", " + objLocation.State;
            lblLandlord.Text = Convert.ToString(objRE_Information.Landlord);
            lblLCD.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Commencement_Date);
            lblLED.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Expiration_Date);
            lblDateAcquired.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Date_Acquired);

            if (objRE_Information.FK_LU_Lease_Type != null)
                lblLeaseType.Text = new LU_Lease_Type(Convert.ToDecimal(objRE_Information.FK_LU_Lease_Type)).Fld_Desc;
            if (objRE_Information.FK_LU_Project_Type != null)
                lblProjectType.Text = new LU_Project_Type(Convert.ToDecimal(objRE_Information.FK_LU_Project_Type)).Fld_Desc;
        }
    }
}
