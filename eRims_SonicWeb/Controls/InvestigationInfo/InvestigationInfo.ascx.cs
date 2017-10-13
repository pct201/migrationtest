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
public partial class Controls_InvestigationInfo_InvestigationInfo : System.Web.UI.UserControl
{
    #region "Properties"

    public decimal PK_LU_Location
    {
        get { return Convert.ToInt32(ViewState["PK_LU_Location"]); }
        set { ViewState["PK_LU_Location"] = value; }
    }

    public decimal PK_Investigation_ID
    {
        get { return Convert.ToInt32(ViewState["PK_Inv"]); }
        set { ViewState["PK_Inv"] = value; }
    }

    public decimal FK_WC_ID
    {
        get { return Convert.ToInt32(ViewState["FK_WC_ID"]); }
        set { ViewState["FK_WC_ID"] = value; }
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
            lblInvestigationID.Text = PK_Investigation_ID.ToString();
            State objstate = new State(Convert.ToInt16(objLocation.State));
            if (objstate.FLD_state.ToLower() == "texas")
            {
                if (FK_WC_ID > 0)
                {
                    WC_FR objWC_FR = new WC_FR(FK_WC_ID);
                    if (objWC_FR.Date_Of_Incident != null && !String.IsNullOrEmpty(objWC_FR.Date_Of_Incident))
                    {
                        if (Convert.ToDateTime(objWC_FR.Date_Of_Incident) > Convert.ToDateTime("11/30/2011"))
                            lnkWCFrNumber.Text = "NS-" + new WC_FR(FK_WC_ID).WC_FR_Number.ToString();
                        else
                            lnkWCFrNumber.Text = "WC-" + new WC_FR(FK_WC_ID).WC_FR_Number.ToString();
                    }
                    else
                        lnkWCFrNumber.Text = "WC-" + new WC_FR(FK_WC_ID).WC_FR_Number.ToString();
                }
                else
                    lnkWCFrNumber.Text = "WC-" + new WC_FR(FK_WC_ID).WC_FR_Number.ToString();
            }
            else
                lnkWCFrNumber.Text = "WC-" + new WC_FR(FK_WC_ID).WC_FR_Number.ToString();


            DataSet dsWCFirstReport = WC_FR.SelectByWC_FR_Number(new WC_FR(FK_WC_ID).WC_FR_Number);

            //Check First report found or not
            if (dsWCFirstReport != null && dsWCFirstReport.Tables.Count > 0 && dsWCFirstReport.Tables[0].Rows.Count > 0)
            {
                //set the wizard id in session
                clsSession.First_Report_Wizard_ID = Convert.ToInt32(dsWCFirstReport.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);
            }
            //clsSession.AllowedTab =
            lnkWCFrNumber.PostBackUrl = AppConfig.SiteURL + "SONIC/FirstReport/WCFirstReport.aspx?id=" + Encryption.Encrypt(FK_WC_ID.ToString());
            lblRMLocationNumber.Text = objLocation.RM_Location_Number;
            lblLocationdba.Text = objLocation.dba;
            lblCity.Text = objLocation.City;
            lblState.Text = objLocation.State != "" ? new State(Convert.ToDecimal(objLocation.State)).FLD_state : string.Empty;
            lblZip.Text = objLocation.Zip_Code;

            DataTable dtClaimInfo = WC_ClaimInfo.Select_Claim_Number(Convert.ToInt32(FK_WC_ID), "WC");
            if (dtClaimInfo.Rows.Count > 0)
            {
                lbtnClaimNumber.Text = Convert.ToString(dtClaimInfo.Rows[0]["Origin_Claim_Number"]);
                lbtnClaimNumber.PostBackUrl = AppConfig.SiteURL + "SONIC/ClaimInfo/WCClaimInfo.aspx?id=" + Encryption.Encrypt(Convert.ToString(dtClaimInfo.Rows[0]["ClaimID"]));
            }

        }
    }
}
