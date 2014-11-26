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
/// Date : 30 MAY 2008
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// Displays Executive Risk identification information on each page of
/// Executive Risk module 
/// 
/// Functionality:
/// Checks for the ID availability
/// and gets the information from DB and sets values in controls
/// </summary>
public partial class CtrlExecutiveRiskInfo : System.Web.UI.UserControl
{
    //Enum is used to set the active tab and inactive tabs.
    public enum Tab
    {
        Executive_Risk = 1,
        Diary = 2,
        Adjustor_Notes = 3
    }
    
    public void SetSelectedTab(Tab tabIndex)
    {
        //used to set Tab style using SetTabStyle Function of Javascruipt
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "SetTab", "javascript:SetTabStyle(" + (int)tabIndex + ");", true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            if (clsSession.Current_Executive_Risk_ID > 0)
            {
                // bind the property identification information
                BindIdentificationInformation();
            }
        }
    }

    private void BindIdentificationInformation()
    {
        // create a new executive risk identification object.            
        Executive_Risk objExecRisk = new Executive_Risk(clsSession.Current_Executive_Risk_ID);

        // set executive risk identification values.
        lblClaimNumber.Text = objExecRisk.Claim_Number;

        LU_Location objLocation = new LU_Location(objExecRisk.FK_Entity);
        lblEntity.Text = "SLC:" + objLocation.Sonic_Location_Code.ToString().Trim() + "|RMLC:" + objLocation.RM_Location_Number;

        //lblEntity.Text = new Entity(objExecRisk.FK_Entity).Description;
        lblDateOfLoss.Text = clsGeneral.FormatDateToDisplay(objExecRisk.Claim_Open_Date);
        lblClaimType.Text = new Type_Of_ER_Claim(objExecRisk.FK_Type_Of_ER_Claim).Fld_Desc;
        
    }
}
