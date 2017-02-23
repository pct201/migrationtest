using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Controls_EventInfo_EventInfo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Fill Claim Information Bar as per Claim Type and Primary Key
    /// </summary>
    /// <param name="PK_Claim"></param>
    /// <param name="ClaimType"></param>
    public void FillEventInformation(decimal PK_Event)
    {
        // if PK_Event is greater than 0 then display information Bar
        if (PK_Event > 0)
        {
            // Get Event information    
            DataSet dsFR = clsEvent.GetFR_NumberByEvent(PK_Event);
            if (dsFR.Tables.Count > 0 && dsFR.Tables[0].Rows.Count > 0)
            {
                lblEventNumber.Text = dsFR.Tables[0].Rows[0]["Event_Number"].ToString();
                
                if (!string.IsNullOrEmpty(Convert.ToString(dsFR.Tables[0].Rows[0]["AL_FR_Number"])))
                    lnkALFirstReport_No.Text = "AL-" + Convert.ToString(dsFR.Tables[0].Rows[0]["AL_FR_Number"]);

                if (!string.IsNullOrEmpty(Convert.ToString(dsFR.Tables[0].Rows[0]["DPD_FR_Number"])))
                    lnkDPDFirstReport_No.Text = "DPD-" + Convert.ToString(dsFR.Tables[0].Rows[0]["DPD_FR_Number"]);

                if (!string.IsNullOrEmpty(Convert.ToString(dsFR.Tables[0].Rows[0]["PL_FR_Number"])))
                    lnkPDFirstReport_No.Text = "PL-" + Convert.ToString(dsFR.Tables[0].Rows[0]["PL_FR_Number"]);

                if (!string.IsNullOrEmpty(Convert.ToString(dsFR.Tables[0].Rows[0]["Prop_FR_Number"])))
                    lnkPLFirstReport_No.Text = "Prop-" + dsFR.Tables[0].Rows[0]["Prop_FR_Number"].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(dsFR.Tables[0].Rows[0]["Asset_Pro_Location"])))
                    lnkAssetProtection.Text = dsFR.Tables[0].Rows[0]["Asset_Pro_Location"].ToString();


                lnkALFirstReport_No.PostBackUrl = AppConfig.SiteURL + "SONIC/FirstReport/ALFirstReport.aspx?id=" + Encryption.Encrypt(Convert.ToString(dsFR.Tables[0].Rows[0]["PK_AL_FR_ID"])) +
                                                    "&WZ_ID=" + Encryption.Encrypt(Convert.ToString(dsFR.Tables[0].Rows[0]["AL_Wizard_ID"]));
                lnkDPDFirstReport_No.PostBackUrl = AppConfig.SiteURL + "SONIC/FirstReport/DPDFirstReport.aspx?id=" + Encryption.Encrypt(Convert.ToString(dsFR.Tables[0].Rows[0]["PK_DPD_FR_ID"])) +
                                                    "&WZ_ID=" + Encryption.Encrypt(Convert.ToString(dsFR.Tables[0].Rows[0]["DPD_Wizard_ID"]));
                lnkPDFirstReport_No.PostBackUrl = AppConfig.SiteURL + "SONIC/FirstReport/PLFirstReport.aspx?id=" + Encryption.Encrypt(Convert.ToString(dsFR.Tables[0].Rows[0]["PK_PL_FR_ID"])) +
                                                    "&WZ_ID=" + Encryption.Encrypt(Convert.ToString(dsFR.Tables[0].Rows[0]["PL_Wizard_ID"]));
                lnkPLFirstReport_No.PostBackUrl = AppConfig.SiteURL + "SONIC/FirstReport/PropertyFirstReport.aspx?id=" + Encryption.Encrypt(Convert.ToString(dsFR.Tables[0].Rows[0]["PK_Property_FR_ID"])) +
                                                    "&WZ_ID=" + Encryption.Encrypt(Convert.ToString(dsFR.Tables[0].Rows[0]["Property_Wizard_ID"]));

                lnkAssetProtection.PostBackUrl = AppConfig.SiteURL + "SONIC/Exposures/Asset_Protection.aspx?loc=" + Encryption.Encrypt(Convert.ToString(dsFR.Tables[0].Rows[0]["FK_LU_Location"]));
                
                
            }
        }
    }
}