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

public partial class ExposureInfo : System.Web.UI.UserControl
{
    #region "Properties"

    public decimal PK_LU_Location
    {
        get { return Convert.ToInt32(ViewState["PK_LU_Location"]); }
        set { ViewState["PK_LU_Location"] = value; }
    }

    public int Int_Location_Code
    {
        get { return Convert.ToInt32(ViewState["Int_Location_Code"]); }
        set { ViewState["Int_Location_Code"] = value; }
    }

    public string SetLocationCode
    {
        set
        {
            //lblRMLocationNumber.Text = value;            
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void BindExposureInfo()
    {
        if (PK_LU_Location > 0)
        {
            LU_Location objLocation = new LU_Location(PK_LU_Location);
            //lblRMLocationNumber.Text = objLocation.RM_Location_Number;
            Int_Location_Code = objLocation.Sonic_Location_Code;
            lblRMLocationNumber.Text = objLocation.Sonic_Location_Code.ToString();
            lblLocationdba.Text = objLocation.dba;
            lblAddress.Text = objLocation.Address_1;  
            lblCity.Text = objLocation.City;
            lblState.Text = objLocation.State != "" ? new State(Convert.ToDecimal(objLocation.State)).FLD_state : string.Empty;
            lblZip.Text = objLocation.Zip_Code;
        }
    }

    public void SetRMLocationCode(int FK_Building_ID)
    {
        string strLocationCode = Int_Location_Code > 0 ? Int_Location_Code.ToString() : "";
        if (FK_Building_ID > 0)
        {
            Building objBuilding = new Building(FK_Building_ID);
            if (!string.IsNullOrEmpty(objBuilding.Building_Number))
                strLocationCode = strLocationCode + ", Building Number " + objBuilding.Building_Number;
        }
        lblRMLocationNumber.Text = strLocationCode; 
    }

    public void SetRMLocationCodewithBuilding(string strBuilding)
    {
        string strLocationCode = Int_Location_Code > 0 ? Int_Location_Code.ToString() : "";
     
        if (strBuilding.Length > 0)
        {
            strLocationCode = strLocationCode + " : " + strBuilding;
        }
        lblRMLocationNumber.Text = strLocationCode;
    }
}
