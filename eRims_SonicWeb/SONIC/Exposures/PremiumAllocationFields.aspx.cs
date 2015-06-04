using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Exposures_PremiumAllocationFields : clsBasePage
{
    #region Properties

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PA_Screen_Fields
    {
        get { return (!clsGeneral.IsNull(ViewState["PK_PA_Screen_Fields"]) ? Convert.ToDecimal(ViewState["PK_PA_Screen_Fields"]) : -1); }
        set { ViewState["PK_PA_Screen_Fields"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return ViewState["StrOperation"] != null ? Convert.ToString(ViewState["StrOperation"]) : "view"; }
        set { ViewState["StrOperation"] = value; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check whether Parameter ID is passed or not.
            if (Request.QueryString["id"] != null)
            {
                decimal _id;

                StrOperation = Convert.ToString(Request.QueryString["mode"]);

                // Encrypt Employee ID
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"].ToString()), out _id))
                {
                    PK_PA_Screen_Fields = _id;

                    // Check Page Mode
                    if (StrOperation == "edit")
                    {
                        BindControlForEdit();
                    }
                    else
                    {
                        BindControlForView();
                    }

                }
                else
                {
                    // redirect to Search Page
                    Response.Redirect("PremiumAllocationSearch.aspx");
                }
            }
            else
            {
                // Page in Add Mode
                pnlEdit.Visible = true;
                pnlView.Visible = false;
            }


        }
    }

    #region "Events"

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int? strYear = null;
        if (txtYear.Text.Trim() != "")
            strYear = Convert.ToInt32(txtYear.Text.Trim().Replace("'", "''"));

        if (clsPA_Screen_Fields.CheckAllocationYearExists(PK_PA_Screen_Fields, strYear))
        {
            lblError.Text = "Allocation Fields For this Year is already Exists. Please enter another Year.";
            lblError.Visible = true;
            return;
        }

        clsPA_Screen_Fields objPA_Screen = new clsPA_Screen_Fields();
        objPA_Screen.Year = strYear;
        if (!string.IsNullOrEmpty(txtWC_Premium.Text))
            objPA_Screen.WC_Premium = Convert.ToDecimal(txtWC_Premium.Text);
        if (!string.IsNullOrEmpty(txtTexas_WC_Premium.Text))
            objPA_Screen.Texas_WC_Premium = Convert.ToDecimal(txtTexas_WC_Premium.Text);
        //if (!string.IsNullOrEmpty(txtLoss_Fund_Premium.Text))
        //    objPA_Screen.Loss_Fund_Premium = Convert.ToDecimal(txtLoss_Fund_Premium.Text);
        if (!string.IsNullOrEmpty(txtGarage_Liability_Premium.Text))
            objPA_Screen.Garage_Liability_Premium = Convert.ToDecimal(txtGarage_Liability_Premium.Text);
        if (!string.IsNullOrEmpty(txtProperty_Premium.Text))
            objPA_Screen.Property_Premium = Convert.ToDecimal(txtProperty_Premium.Text);
        if (!string.IsNullOrEmpty(txtCrime_Premium.Text))
            objPA_Screen.Crime_Premium = Convert.ToDecimal(txtCrime_Premium.Text);
        //if (!string.IsNullOrEmpty(txtUmbrella_Premium.Text))
        //    objPA_Screen.Umbrella_Premium = Convert.ToDecimal(txtUmbrella_Premium.Text);
        if (!string.IsNullOrEmpty(txtExcess_Umbrella_Premium.Text))
            objPA_Screen.Excess_Umbrella_Premium = Convert.ToDecimal(txtExcess_Umbrella_Premium.Text);
        //if (!string.IsNullOrEmpty(txtSecond_Layer_Umbrella_Premium.Text))
        //    objPA_Screen.Second_Layer_Umbrella_Premium = Convert.ToDecimal(txtSecond_Layer_Umbrella_Premium.Text);
        if (!string.IsNullOrEmpty(txtEPL_Premium.Text))
            objPA_Screen.EPL_Premium = Convert.ToDecimal(txtEPL_Premium.Text);
        if (!string.IsNullOrEmpty(txtCyber_Premium.Text))
            objPA_Screen.Cyber_Premium = Convert.ToDecimal(txtCyber_Premium.Text);
        //if (!string.IsNullOrEmpty(txtTotal_Risk_Management_Fee.Text))
        //    objPA_Screen.Total_Risk_Management_Fee = Convert.ToDecimal(txtTotal_Risk_Management_Fee.Text);
        if (!string.IsNullOrEmpty(txtPollution_Premium.Text))
            objPA_Screen.Pollution_Premium = Convert.ToDecimal(txtPollution_Premium.Text);
        if (!string.IsNullOrEmpty(txtDirectors_Officers_Premium.Text))
            objPA_Screen.Directors_Officers_Premium = Convert.ToDecimal(txtDirectors_Officers_Premium.Text);
        if (!string.IsNullOrEmpty(txtFiduciary_Premium.Text))
            objPA_Screen.Fiduciary_Premium = Convert.ToDecimal(txtFiduciary_Premium.Text);
        if (!string.IsNullOrEmpty(txtKidnap_Ransom_Premium.Text))
            objPA_Screen.Kidnap_Ransom_Premium = Convert.ToDecimal(txtKidnap_Ransom_Premium.Text);
        if (!string.IsNullOrEmpty(txtEarthquake_Premium.Text))
            objPA_Screen.Earthquake_Premium = Convert.ToDecimal(txtEarthquake_Premium.Text);
        if (!string.IsNullOrEmpty(txtDealers_Physical_Damage_Premium.Text))
            objPA_Screen.Dealers_Physical_Damage_Premium = Convert.ToDecimal(txtDealers_Physical_Damage_Premium.Text);
        if (!string.IsNullOrEmpty(txtTotal_Locations.Text))
            objPA_Screen.Total_Locations = Convert.ToInt32(txtTotal_Locations.Text);
        if (!string.IsNullOrEmpty(txtProperty_Valuation_Date.Text))
            objPA_Screen.Property_Valuation_Date = Convert.ToDateTime(txtProperty_Valuation_Date.Text);

        objPA_Screen.Updated_By = clsSession.UserID;
        objPA_Screen.Update_Date = System.DateTime.Now;

        if (PK_PA_Screen_Fields > 0)
        {
            objPA_Screen.PK_PA_Screen_Fields = PK_PA_Screen_Fields;
            objPA_Screen.Update();
        }
        else
        {
            PK_PA_Screen_Fields = objPA_Screen.Insert();
        }

        //clsSession.Str_Employee_Operation = "view";
        Response.Redirect("PremiumAllocationFields.aspx?id=" + Encryption.Encrypt(PK_PA_Screen_Fields.ToString()) + "&mode=edit");
    }

    protected void btnBackToEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("PremiumAllocationFields.aspx?id=" + Encryption.Encrypt(PK_PA_Screen_Fields.ToString()) + "&mode=edit");
    }

    protected void btnBackToSearch_Click(object sender, EventArgs e)
    {
        // redirect to Search Page
        Response.Redirect("PremiumAllocationSearch.aspx");
    }

    protected void txtYear_TextChanged(object sender, EventArgs e)
    {

        if (clsPA_Screen_Fields.CheckAllocationYearExists(PK_PA_Screen_Fields, Convert.ToInt32(txtYear.Text)))
        {
            lblError.Text = "Allocation Fields For this Year is already Exists. Please enter another Year.";
            lblError.Visible = true;
            return;
        }

    }


    #endregion

    #region Methods

    private void BindControlForView()
    {
        pnlEdit.Visible = false;
        pnlView.Visible = true;

        decimal TotalPPInsurableValues = 0;
        decimal TotalEpInsurableValues = 0;

        clsPA_Screen_Fields objPA_Screen = new clsPA_Screen_Fields(PK_PA_Screen_Fields);

        lblYear.Text = Convert.ToString(objPA_Screen.Year);
        if (objPA_Screen.WC_Premium != null)
            lblWC_Premium.Text = string.Format("{0:N2}", objPA_Screen.WC_Premium);
        if (objPA_Screen.Texas_WC_Premium != null)
            lblTexas_WC_Premium.Text = string.Format("{0:N2}", objPA_Screen.Texas_WC_Premium);
        //if (objPA_Screen.Loss_Fund_Premium != null)
        //    lblLoss_Fund_Premium.Text = string.Format("{0:N2}", objPA_Screen.Loss_Fund_Premium);
        if (objPA_Screen.Garage_Liability_Premium != null)
            lblGarage_Liability_Premium.Text = string.Format("{0:N2}", objPA_Screen.Garage_Liability_Premium);
        if (objPA_Screen.Property_Premium != null)
            lblProperty_Premium.Text = string.Format("{0:N2}", objPA_Screen.Property_Premium);
        if (objPA_Screen.Crime_Premium != null)
            lblCrime_Premium.Text = string.Format("{0:N2}", objPA_Screen.Crime_Premium);
        //if (objPA_Screen.Umbrella_Premium != null)
        //    lblUmbrella_Premium.Text = string.Format("{0:N2}", objPA_Screen.Umbrella_Premium);
        if (objPA_Screen.Excess_Umbrella_Premium != null)
            lblExcess_Umbrella_Premium.Text = string.Format("{0:N2}", objPA_Screen.Excess_Umbrella_Premium);
        //if (objPA_Screen.Second_Layer_Umbrella_Premium != null)
        //    lblSecond_Layer_Umbrella_Premium.Text = string.Format("{0:N2}", objPA_Screen.Second_Layer_Umbrella_Premium);
        if (objPA_Screen.EPL_Premium != null)
            lblEPL_Premium.Text = string.Format("{0:N2}", objPA_Screen.EPL_Premium);
        if (objPA_Screen.Cyber_Premium != null)
            lblCyber_Premium.Text = string.Format("{0:N2}", objPA_Screen.Cyber_Premium);
        //if (objPA_Screen.Total_Risk_Management_Fee != null)
        //    lblTotal_Risk_Management_Fee.Text = string.Format("{0:N2}", objPA_Screen.Total_Risk_Management_Fee);
        if (objPA_Screen.Pollution_Premium != null)
            lblPollution_Premium.Text = string.Format("{0:N2}", objPA_Screen.Pollution_Premium);

        if (objPA_Screen.Property_Valuation_Date != null)
            lblProperty_Valuation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPA_Screen.Property_Valuation_Date);

        if (objPA_Screen.WC_Headcount != null)
            lblWC_Total_Headcount.Text = string.Format("{0:0}", objPA_Screen.WC_Headcount);
        if (objPA_Screen.WC_Payroll != null)
            lblWC_Total_Payroll.Text = string.Format("{0:N2}", objPA_Screen.WC_Payroll);
        if (objPA_Screen.Texas_WC_Headcount != null)
            lblTexas_NSP_Total_Headcount.Text = string.Format("{0:0}", objPA_Screen.Texas_WC_Headcount);
        if (objPA_Screen.Texas_WC_Payroll != null)
        {
            lblTexas_WC_Payroll.Text = string.Format("{0:N2}", objPA_Screen.Texas_WC_Payroll);

        }
        if (objPA_Screen.PP_Total_RS_Means != null)
        {
            lblPP_Total_RS_Means.Text = string.Format("{0:N2}", objPA_Screen.PP_Total_RS_Means);
            TotalPPInsurableValues = TotalPPInsurableValues + Convert.ToDecimal(objPA_Screen.PP_Total_RS_Means);
        }
        if (objPA_Screen.PP_Total_Business_Interruption != null)
        {
            lblPP_Total_Business_Interruption.Text = string.Format("{0:N2}", objPA_Screen.PP_Total_Business_Interruption);
            TotalPPInsurableValues = TotalPPInsurableValues + Convert.ToDecimal(objPA_Screen.PP_Total_Business_Interruption);
        }
        if (objPA_Screen.PP_Total_Contents != null)
        {
            lblPP_Total_Contents.Text = string.Format("{0:N2}", objPA_Screen.PP_Total_Contents);
            TotalPPInsurableValues = TotalPPInsurableValues + Convert.ToDecimal(objPA_Screen.PP_Total_Contents);
        }
        if (objPA_Screen.PP_Total_Parts != null)
        {
            lblPP_Total_Parts.Text = string.Format("{0:N2}", objPA_Screen.PP_Total_Parts);
            TotalPPInsurableValues = TotalPPInsurableValues + Convert.ToDecimal(objPA_Screen.PP_Total_Parts);
        }
        if (objPA_Screen.EP_Total_RS_Means != null)
        {
            lblEP_Total_RS_Means.Text = string.Format("{0:N2}", objPA_Screen.EP_Total_RS_Means);
            TotalEpInsurableValues = TotalEpInsurableValues + Convert.ToDecimal(objPA_Screen.EP_Total_RS_Means);
        }
        if (objPA_Screen.EP_Total_Business_Interruption != null)
        {
            lblEP_Total_Business_Interruption.Text = string.Format("{0:N2}", objPA_Screen.EP_Total_Business_Interruption);
            TotalEpInsurableValues = TotalEpInsurableValues + Convert.ToDecimal(objPA_Screen.EP_Total_Business_Interruption);
        }
        if (objPA_Screen.EP_Total_Contents != null)
        {
            lblEP_Total_Contents.Text = string.Format("{0:N2}", objPA_Screen.EP_Total_Contents);
            TotalEpInsurableValues = TotalEpInsurableValues + Convert.ToDecimal(objPA_Screen.EP_Total_Contents);

        }
        if (objPA_Screen.EP_Total_Parts != null)
        {
            lblEP_Total_Parts.Text = string.Format("{0:N2}", objPA_Screen.EP_Total_Parts);
            TotalEpInsurableValues = TotalEpInsurableValues + Convert.ToDecimal(objPA_Screen.EP_Total_Parts);
        }

        if (objPA_Screen.Fiduciary_Premium != null)
            lblFiduciary_Premium.Text = string.Format("{0:N2}", objPA_Screen.Fiduciary_Premium);
        if (objPA_Screen.Directors_Officers_Premium != null)
            lblDirectors_Officers_Premium.Text = string.Format("{0:N2}", objPA_Screen.Directors_Officers_Premium);
        if (objPA_Screen.Kidnap_Ransom_Premium != null)
            lblKidnap_Ransom_Premium.Text = string.Format("{0:N2}", objPA_Screen.Kidnap_Ransom_Premium);
        if (objPA_Screen.Earthquake_Premium != null)
            lblEarthquake_Premium.Text = string.Format("{0:N2}", objPA_Screen.Earthquake_Premium);
        if (objPA_Screen.Dealers_Physical_Damage_Premium != null)
            lblDealers_Physical_Damage_Premium.Text = string.Format("{0:N2}", objPA_Screen.Dealers_Physical_Damage_Premium);
        if (objPA_Screen.Total_Locations != null)
            lblTotal_Locations.Text = string.Format("{0:0}", objPA_Screen.Total_Locations);
        lblPP_Total_Insurable_Values.Text = string.Format("{0:N2}", TotalPPInsurableValues);
        lblEP_Total_Insurable_Values.Text = string.Format("{0:N2}", TotalEpInsurableValues);
    }

    private void BindControlForEdit()
    {
        pnlEdit.Visible = true;
        pnlView.Visible = false;

        decimal TotalPPInsurableValues = 0;
        decimal TotalEpInsurableValues = 0;
        clsPA_Screen_Fields objPA_Screen = new clsPA_Screen_Fields(PK_PA_Screen_Fields);

        txtYear.Enabled = false;
        txtYear.Text = Convert.ToString(objPA_Screen.Year);
        if (objPA_Screen.WC_Premium != null)
            txtWC_Premium.Text = string.Format("{0:N2}", objPA_Screen.WC_Premium);
        if (objPA_Screen.Property_Valuation_Date != null)
            txtProperty_Valuation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPA_Screen.Property_Valuation_Date);
        
        if (objPA_Screen.Texas_WC_Premium != null)
            txtTexas_WC_Premium.Text = string.Format("{0:N2}", objPA_Screen.Texas_WC_Premium);
        //if (objPA_Screen.Loss_Fund_Premium != null)
        //    txtLoss_Fund_Premium.Text = string.Format("{0:N2}", objPA_Screen.Loss_Fund_Premium);
        if (objPA_Screen.Garage_Liability_Premium != null)
            txtGarage_Liability_Premium.Text = string.Format("{0:N2}", objPA_Screen.Garage_Liability_Premium);
        if (objPA_Screen.Property_Premium != null)
            txtProperty_Premium.Text = string.Format("{0:N2}", objPA_Screen.Property_Premium);
        if (objPA_Screen.Crime_Premium != null)
            txtCrime_Premium.Text = string.Format("{0:N2}", objPA_Screen.Crime_Premium);
        //if (objPA_Screen.Umbrella_Premium != null)
        //    txtUmbrella_Premium.Text = string.Format("{0:N2}", objPA_Screen.Umbrella_Premium);
        if (objPA_Screen.Excess_Umbrella_Premium != null)
            txtExcess_Umbrella_Premium.Text = string.Format("{0:N2}", objPA_Screen.Excess_Umbrella_Premium);
        //if (objPA_Screen.Second_Layer_Umbrella_Premium != null)
        //    txtSecond_Layer_Umbrella_Premium.Text = string.Format("{0:N2}", objPA_Screen.Second_Layer_Umbrella_Premium);
        if (objPA_Screen.EPL_Premium != null)
            txtEPL_Premium.Text = string.Format("{0:N2}", objPA_Screen.EPL_Premium);
        if (objPA_Screen.Cyber_Premium != null)
            txtCyber_Premium.Text = string.Format("{0:N2}", objPA_Screen.Cyber_Premium);
        //if (objPA_Screen.Total_Risk_Management_Fee != null)
        //    txtTotal_Risk_Management_Fee.Text = string.Format("{0:N2}", objPA_Screen.Total_Risk_Management_Fee);
        if (objPA_Screen.Pollution_Premium != null)
            txtPollution_Premium.Text = string.Format("{0:N2}", objPA_Screen.Pollution_Premium);
        if (objPA_Screen.WC_Headcount != null)
            txtWC_Total_Headcount.Text = string.Format("{0:0}", objPA_Screen.WC_Headcount);
        if (objPA_Screen.WC_Payroll != null)
            txtWC_Total_Payroll.Text = string.Format("{0:N2}", objPA_Screen.WC_Payroll);
        if (objPA_Screen.Texas_WC_Headcount != null)
            txtTexas_NSP_Total_Headcount.Text = string.Format("{0:0}", objPA_Screen.Texas_WC_Headcount);
        if (objPA_Screen.Texas_WC_Payroll != null)
        {
            txtTexas_WC_Payroll.Text = string.Format("{0:N2}", objPA_Screen.Texas_WC_Payroll);

        }
        if (objPA_Screen.PP_Total_RS_Means != null)
        {
            txtPP_Total_RS_Means.Text = string.Format("{0:N2}", objPA_Screen.PP_Total_RS_Means);
            TotalPPInsurableValues = TotalPPInsurableValues + Convert.ToDecimal(objPA_Screen.PP_Total_RS_Means);
        }
        if (objPA_Screen.PP_Total_Business_Interruption != null)
        {
            txtPP_Total_Business_Interruption.Text = string.Format("{0:N2}", objPA_Screen.PP_Total_Business_Interruption);
            TotalPPInsurableValues = TotalPPInsurableValues + Convert.ToDecimal(objPA_Screen.PP_Total_Business_Interruption);
        }
        if (objPA_Screen.PP_Total_Contents != null)
        {
            txtPP_Total_Contents.Text = string.Format("{0:N2}", objPA_Screen.PP_Total_Contents);
            TotalPPInsurableValues = TotalPPInsurableValues + Convert.ToDecimal(objPA_Screen.PP_Total_Contents);
        }
        if (objPA_Screen.PP_Total_Parts != null)
        {
            txtPP_Total_Parts.Text = string.Format("{0:N2}", objPA_Screen.PP_Total_Parts);
            TotalPPInsurableValues = TotalPPInsurableValues + Convert.ToDecimal(objPA_Screen.PP_Total_Parts);
        }
        if (objPA_Screen.EP_Total_RS_Means != null)
        {
            txtEP_Total_RS_Means.Text = string.Format("{0:N2}", objPA_Screen.EP_Total_RS_Means);
            TotalEpInsurableValues = TotalEpInsurableValues + Convert.ToDecimal(objPA_Screen.EP_Total_RS_Means);
        }
        if (objPA_Screen.EP_Total_Business_Interruption != null)
        {
            txtEP_Total_Business_Interruption.Text = string.Format("{0:N2}", objPA_Screen.EP_Total_Business_Interruption);
            TotalEpInsurableValues = TotalEpInsurableValues + Convert.ToDecimal(objPA_Screen.EP_Total_Business_Interruption);
        }
        if (objPA_Screen.EP_Total_Contents != null)
        {
            txtEP_Total_Contents.Text = string.Format("{0:N2}", objPA_Screen.EP_Total_Contents);
            TotalEpInsurableValues = TotalEpInsurableValues + Convert.ToDecimal(objPA_Screen.EP_Total_Contents);

        }
        if (objPA_Screen.EP_Total_Parts != null)
        {
            txtEP_Total_Parts.Text = string.Format("{0:N2}", objPA_Screen.EP_Total_Parts);
            TotalEpInsurableValues = TotalEpInsurableValues + Convert.ToDecimal(objPA_Screen.EP_Total_Parts);
        }

        if (objPA_Screen.Fiduciary_Premium != null)
            txtFiduciary_Premium.Text = string.Format("{0:N2}", objPA_Screen.Fiduciary_Premium);
        if (objPA_Screen.Directors_Officers_Premium != null)
            txtDirectors_Officers_Premium.Text = string.Format("{0:N2}", objPA_Screen.Directors_Officers_Premium);
        if (objPA_Screen.Kidnap_Ransom_Premium != null)
            txtKidnap_Ransom_Premium.Text = string.Format("{0:N2}", objPA_Screen.Kidnap_Ransom_Premium);
        if (objPA_Screen.Earthquake_Premium != null)
            txtEarthquake_Premium.Text = string.Format("{0:N2}", objPA_Screen.Earthquake_Premium);
        if (objPA_Screen.Dealers_Physical_Damage_Premium != null)
            txtDealers_Physical_Damage_Premium.Text = string.Format("{0:N2}", objPA_Screen.Dealers_Physical_Damage_Premium);
        if (objPA_Screen.Total_Locations != null)
            txtTotal_Locations.Text = string.Format("{0:0}", objPA_Screen.Total_Locations);
        txtPPTotalInsurableValues.Text = string.Format("{0:N2}", TotalPPInsurableValues);
        txtEPTotalInsurableValues.Text = string.Format("{0:N2}", TotalEpInsurableValues);
    }

  
    #endregion


}