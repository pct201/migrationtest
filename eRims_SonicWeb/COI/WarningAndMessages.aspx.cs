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
public partial class Admin_WarningAndMessages : clsBasePage 
{
    #region "Properties"
    private decimal PK_COIs
    {
        get { return Convert.ToDecimal(ViewState["COI"]); }
        set { ViewState["COI"] = value; }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["coi"] != null)
            {
                PK_COIs = Convert.ToDecimal(Request.QueryString["coi"]);
                hdnCOIID.Value = PK_COIs.ToString();
                BindDetails();
            }
        }
    }

    private void BindDetails()
    {
        COIs objCOIs = new COIs(PK_COIs);
        rdoCancellation.Checked = (objCOIs.Cancellation_Notice < 30) ? true : false;
        rdoPrimary.Checked = (objCOIs.Primary_Provided == "N") ? true : false;
        rdoAllLocations.Checked = (objCOIs.All_Locations == "N") ? true : false;
        rdoCertificate.Checked = (objCOIs.Signed_Certificate_Received == "N") ? true : false;
        rdoInsuredName.Checked = (objCOIs.Insured_Name_Same == "N") ? true : false;

        DataTable dtNonCompliance = clsGenerateLetter.CheckForNonCompliance(PK_COIs).Tables[0];
        if (dtNonCompliance.Rows.Count > 0)//if rows found
        {
            DataRow dr = dtNonCompliance.Rows[0];
            rdoCancellation.Checked = (dr["Cancellation_Notice"].ToString() == "N") ? true : false;
            rdoPrimary.Checked = (dr["Primary_Provided"].ToString() == "N") ? true : false;
            rdoAllLocations.Checked = (dr["All_Locations"].ToString() == "N") ? true : false;
            rdoCertificate.Checked = (dr["Signed_Certificate_Received"].ToString() == "N") ? true : false;
            rdoInsuredName.Checked = (dr["Insured_Name_Same"].ToString() == "N") ? true : false;
            rdoAMBestRating.Checked = (dr["AM_Best"].ToString() == "N") ? true : false;
            rdoOrdinance.Checked = (dr["Ordinance_Law"].ToString() == "N") ? true : false;
            rdoWaiver.Checked = (dr["Subrogation_Waiver"].ToString() == "N") ? true : false;
            rdoInsuredPerils.Checked = (dr["Perils_Insured_Form"].ToString() == "N") ? true : false;
            rdoReplcament.Checked = (dr["Replacement_Costs"].ToString() == "N") ? true : false;
            rdoPropertyOnAcord.Checked = (dr["Property_On_Acord"].ToString() == "N") ? true : false;
            rdoAdditionalInsured.Checked = (dr["Additional_Insured"].ToString() == "N") ? true : false;
        }

    }

    protected void btnAccept_Click(object sender, EventArgs e)
    {

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
    }

}
