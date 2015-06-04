using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Exposures_NationalPremiumAllocation : clsBasePage
{
    
    #region Properties

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PA_National_Allocation
    {
        get { return (!clsGeneral.IsNull(ViewState["PK_PA_National_Allocation"]) ? Convert.ToDecimal(ViewState["PK_PA_National_Allocation"]) : -1); }
        set { ViewState["PK_PA_National_Allocation"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return ViewState["StrOperation"] != null ? Convert.ToString(ViewState["StrOperation"]) : "view"; }
        set { ViewState["StrOperation"] = value; }
    }

    decimal TotalActualCost = 0, TotalStoreCost = 0, TotalSurcharge = 0, TotalRiskManagementFee = 0, TotalRiskManagementRate = 0;

    private int pK_PA_National_Allocation_Service_Grid;

    public int PK_PA_National_Allocation_Service_Grid
    {
        get { return pK_PA_National_Allocation_Service_Grid; }
        set { pK_PA_National_Allocation_Service_Grid = value; }
    }
    
    #endregion

    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            trStatusAdd.Style.Add("display", "none");
            ViewState["TotalRiskManagementFee"] = null;
            TotalRiskManagementFee = 0;
            setEmpty();
            BindRiskManagementGrid();

            // Check whether Parameter ID is passed or not.
            if (Request.QueryString["id"] != null)
            {
                decimal _id;

                StrOperation = Convert.ToString(Request.QueryString["mode"]);

                // Encrypt Employee ID
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"].ToString()), out _id))
                {
                    PK_PA_National_Allocation = _id;

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
            BindServiceDropdown();
            CalculateTotalRiskFields();
            ShowTotalRiskValues();
        //
        }
    }    
    #endregion

    #region "Events"

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (PK_PA_National_Allocation < 0)
        {
            int? strYear = null;
            if (txtYear.Text.Trim() != "")
                strYear = Convert.ToInt32(txtYear.Text.Trim().Replace("'", "''"));

            if (clsPA_National_Allocation.CheckAllocationYearExists(PK_PA_National_Allocation, strYear))
            {
                lblError.Text = "Allocation Fields For this Year is already Exists. Please enter another Year.";
                lblError.Visible = true;
                return;
            }
        }

        CalculateTotalRiskFields();
    

        DataSet ds = clsPA_National_Allocation.SelectByFieldsCriteria(Convert.ToInt32(txtYear.Text), clsGeneral.FormatDateToStore(txtProperty_Valuation_Date.Text),
            clsGeneral.GetDecimalNullableValue(txtWC_Premium), clsGeneral.GetDecimalNullableValue(txtTexasNonSubscriptionPremium),
            clsGeneral.GetDecimalNullableValue(txtExcessUmbrellaPremium), clsGeneral.GetDecimalNullableValue(txtEPLIPremium),
            clsGeneral.GetDecimalNullableValue(txtGarageLiabilityPremium), clsGeneral.GetDecimalNullableValue(txtCrimePremium),
            clsGeneral.GetDecimalNullableValue(txtCyberPremium), clsGeneral.GetDecimalNullableValue(txtPollutionPremium),
            clsGeneral.GetDecimalNullableValue(txtProperty_Premium), clsGeneral.GetDecimalNullableValue(txtEarthquakePremium),
            TotalRiskManagementFee, TotalRiskManagementRate,TotalStoreCost,TotalSurcharge,System.DateTime.Now, clsSession.UserID, PK_PA_National_Allocation);

        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {

                //txtWCTotal_Payroll.Text = Convert.ToString(dt.Rows[0]["WorkersCompensationPremiumTotalPayroll"]);
                //txtWCTotalHeadcount.Text = Convert.ToString(dt.Rows[0]["WorkersCompensationPremiumTotal_Headcount"]);

                //txtTXTotalPayroll.Text = Convert.ToString(dt.Rows[0]["TexasNonSubscriptionPremiumTotalPayroll"]);
                //txtTXTotalHeadcount.Text = Convert.ToString(dt.Rows[0]["TexasNonSubscriptionPremiumTotal_Headcount"]);

                //txtEarthquakeTotalRSMeans.Text = Convert.ToString(dt.Rows[0]["EarthquakePremiumTotalRSMeans"]);
                //txtEarthquakeTotalBusinessInterruption.Text = Convert.ToString(dt.Rows[0]["EarthquakePremiumTotalBusinessInterruption"]);
                //txtEarthquakeTotalContents.Text = Convert.ToString(dt.Rows[0]["EarthquakePremiumTotalContents"]);
                //txtEarthquakeTotalParts.Text = Convert.ToString(dt.Rows[0]["EarthquakePremiumTotalParts"]);

                //txtPropertyRS_Means.Text = Convert.ToString(dt.Rows[0]["PropertyPremiumTotalRSMeans"]);
                //txtPropertyTotalBusinessInterruption.Text = Convert.ToString(dt.Rows[0]["PropertyPremiumTotalBusinessInterruption"]);
                //txtPropertyTotalContents.Text = Convert.ToString(dt.Rows[0]["PropertyPremiumTotalContents"]);
                //txtPropertyTotalParts.Text = Convert.ToString(dt.Rows[0]["PropertyPremiumTotalParts"]);
            }

            DataTable dt1 = ds.Tables[0];
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                PK_PA_National_Allocation = Convert.ToDecimal(dt1.Rows[0][0]);
                //if(PK_PA_National_Allocation > 0)
                //    BindControlForEdit();
            }
            

            Response.Redirect("NationalPremiumAllocation.aspx?id=" + Encryption.Encrypt(PK_PA_National_Allocation.ToString()) + "&mode=edit");        

        }
    }

    protected void btnBackToEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("NationalPremiumAllocation.aspx?id=" + Encryption.Encrypt(PK_PA_National_Allocation.ToString()) + "&mode=edit");
    }

    protected void btnBackToSearch_Click(object sender, EventArgs e)
    {
        // redirect to Search Page
        Response.Redirect("NationalPremiumAllocationSearch.aspx");
    }


    protected void lnkAddRiskServiceNew_Click(object sender, EventArgs e)
    {
        ViewState["PK_PA_National_Allocation_Service_Grid"] = null;
        lnkAddRiskServiceNew.Visible = false;
        btnSaveGrid.Text = " Add ";

        txtServiceAmount.Text = string.Empty;
        ddlService.SelectedIndex = -1;
        trStatusAdd.Style.Add("display", "inline");
        //trStatusGrid.Style.Add("display", "none");
    }

    protected void btnStoreAdd_Click(object sender, EventArgs e)
    {

    }
    protected void btnSaveGrid_Click(object sender, EventArgs e)
    {
        clsPA_National_Allocation_Service_Grid objPA_National_Allocation_Service_Grid = new clsPA_National_Allocation_Service_Grid();
        objPA_National_Allocation_Service_Grid.PK_PA_National_Allocation_Service_Grid = clsGeneral.GetDecimal(ViewState["PK_PA_National_Allocation_Service_Grid"]);
        objPA_National_Allocation_Service_Grid.FK_PA_National_Allocation = PK_PA_National_Allocation;
        
        if (ddlService.SelectedIndex > 0)
            objPA_National_Allocation_Service_Grid.FK_LU_NPA_Service = Convert.ToInt32(ddlService.SelectedValue);        
        objPA_National_Allocation_Service_Grid.Service_Amount = clsGeneral.GetDecimalValue(txtServiceAmount);
        objPA_National_Allocation_Service_Grid.Update_Date = System.DateTime.Now;
        objPA_National_Allocation_Service_Grid.Updated_By = clsSession.UserID;

        if (PK_PA_National_Allocation > 0)
        {
            if (objPA_National_Allocation_Service_Grid.PK_PA_National_Allocation_Service_Grid > 0)
            {
                objPA_National_Allocation_Service_Grid.Update();
            }
            else
            {
                PK_PA_National_Allocation_Service_Grid = objPA_National_Allocation_Service_Grid.Insert();
            }
        }
        BindRiskManagementGrid();
        trStatusAdd.Style.Add("display", "none");
        //trStatusGrid.Style.Add("display", "inline");
        lnkAddRiskServiceNew.Visible = true;

        SetRiskManagementFields();
        
        CalculateTotalRiskFields();

        ShowTotalRiskValues();

    }
   
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        trStatusAdd.Style.Add("display", "none");
        trStatusGrid.Style.Add("display", "inline");
        lnkAddRiskServiceNew.Visible = true;
    }



    protected void txtProperty_Valuation_Date_TextChanged(object sender, EventArgs e)
    {
        //String sDate = txtProperty_Valuation_Date.Text;
        //DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

        //String yy = datevalue.Year.ToString();

        //DataSet ds = clsPA_National_Allocation.SelectByPropertyValuationYear(Convert.ToInt32(yy));

        //if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        //{
        //    DataTable dt = ds.Tables[0];

        //    //txtPropertyTotalInsurableValues.Text = Convert.ToString(Convert.ToDecimal(txtPropertyRS_Means.Text) + Convert.ToDecimal(txtPropertyTotalBusinessInterruption.Text) + Convert.ToDecimal(txtPropertyTotalContents.Text) + Convert.ToDecimal(txtPropertyTotalParts.Text));
        //}
    }
    
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("NationalPremiumAllocation.aspx?id=" + Encryption.Encrypt(PK_PA_National_Allocation.ToString()) + "&mode=edit");
    }
    

    #endregion

    #region "Grid Events"

    protected void gvRiskManagementServiceGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkServiceAmount = (LinkButton)e.Row.FindControl("lnkServiceAmount");
            if (!string.IsNullOrEmpty(lnkServiceAmount.Text))
                TotalRiskManagementFee = TotalRiskManagementFee + Convert.ToDecimal(lnkServiceAmount.Text);
            ViewState["TotalRiskManagementFee"] = TotalRiskManagementFee;
        }
    }

    protected void gvRiskManagementServiceGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveDetails")
        {
            clsPA_National_Allocation_Service_Grid.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindRiskManagementGrid();
            SetRiskManagementFields();
        }
        else if (e.CommandName == "EditDetails")
        {
            ViewState["PK_PA_National_Allocation_Service_Grid"] = Convert.ToInt32(e.CommandArgument);
            clsPA_National_Allocation_Service_Grid objPA_National_Allocation_Service_Grid = new clsPA_National_Allocation_Service_Grid(Convert.ToDecimal(e.CommandArgument));
            txtServiceAmount.Text = Convert.ToString(objPA_National_Allocation_Service_Grid.Service_Amount);

            if (ddlService.Items.Contains(ddlService.Items.FindByValue(objPA_National_Allocation_Service_Grid.FK_LU_NPA_Service.ToString())) == true)
            {
                ddlService.SelectedValue = Convert.ToString(objPA_National_Allocation_Service_Grid.FK_LU_NPA_Service);
            }
            else
            {
                ddlService.SelectedValue = "0";
            }
            //ddlService.SelectedValue = Convert.ToString(objPA_National_Allocation_Service_Grid.FK_LU_NPA_Service);
            lnkAddRiskServiceNew.Visible = false;
            trStatusAdd.Style.Add("display", "inline");
            //trStatusGrid.Style.Add("display", "none");
            btnSaveGrid.Text = " Update ";
            SetRiskManagementFields();
        }
    }

    #endregion

    #region Methods

    private void BindControlForView()
    {
        pnlEdit.Visible = false;
        pnlView.Visible = true;

        BindRiskManagementGrid();

        if (PK_PA_National_Allocation > 0)
        {
            clsPA_National_Allocation objPA_National_Allocation = new clsPA_National_Allocation(PK_PA_National_Allocation);

            lblYear.Text = Convert.ToString(objPA_National_Allocation.Year);
            lblPropertyValuationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPA_National_Allocation.Property_Valuation_Date);
            lblTotalNumberofLocations.Text = Convert.ToString(objPA_National_Allocation.Total_Locations);
            lblTotalHeadcount.Text = Convert.ToString(objPA_National_Allocation.Total_Headcount);
            lblWorkerCompensationPremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.WC_Premium);
            lblWorkersCompensationRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.WC_Rate);
            lblTexasNonSubscriptionPremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Texas_WC_Premium);
            lblTexasNonSubscriptionRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Texas_WC_Rate);
            lblCrimeRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Crime_Rate);
            lblCrimePremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Crime_Premium);
            lblCyberPremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Cyber_Premium);
            lblCyberRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Cyber_Rate);
            lblEarthquakePremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Earthquake_Premium);
            lblEarthquakeRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Earthquake_Rate);
            lblEPLIPremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.EPL_Premium);
            lblEPLIRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.EPL_Rate);
            lblExcessUmbrellaRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Excess_Umbrella_Rate);
            lblExcessUmbrellaPremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Excess_Umbrella_Premium);
            lblGarageLiabilityPremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Garage_Liability_Premium);
            lblGarageLiabilityRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Garage_Liability_Rate);
            lblPollutionPremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Pollution_Premium);
            lblPollutionRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Pollution_Rate);
            lblPropertyPremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Property_Premium);
            lblPropertyRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Property_Rate);

            lblTotalRiskManagementFee.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Total_Risk_Management_Fee);
            lblTotalRiskManagementRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Total_Risk_Management_Rate);
            lblTotalActualCost.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Total_Actual_Cost);
            lblTotalStoreCost.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Total_Store_Cost);
            lblTotalSurchargeAmount.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Total_Surcharge_Amount);

             String sDate = txtProperty_Valuation_Date.Text;
            string yy = null;

            if (!string.IsNullOrEmpty(sDate))
            {
                DateTime datevalue = (Convert.ToDateTime(Convert.ToString(sDate)));
                yy = datevalue.Year.ToString();
            }

            DataSet ds = clsPA_National_Allocation.SelectByPropertyValuationYear(Convert.ToInt32(yy), Convert.ToInt32(objPA_National_Allocation.Year));

            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                lblWCTotalPayroll.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["WorkersCompensationPremiumTotalPayroll"]);
                lblWCTotalHeadcount.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["WorkersCompensationPremiumTotal_Headcount"]);
                lblTXTotalPayroll.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["TexasNonSubscriptionPremiumTotalPayroll"]);
                lblWCTotalHeadcount.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["TexasNonSubscriptionPremiumTotal_Headcount"]);
                lblEarthquakeTotalRSMeans.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["EarthquakePremiumTotalRSMeans"]);
                lblEarthquakeTotalBusinessInterruption.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["EarthquakePremiumTotalBusinessInterruption"]);
                lblEarthquakeTotalContents.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["EarthquakePremiumTotalContents"]);
                lblEarthquakeTotalParts.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["EarthquakePremiumTotalParts"]);
                lblPropertyTotalRSMeans.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["PropertyPremiumTotalRSMeans"]);
                lblPropertyTotalBusinessInterruption.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["PropertyPremiumTotalBusinessInterruption"]);
                lblPropertyTotalContent.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["PropertyPremiumTotalContents"]);
                lblPropertyTotalParts.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["PropertyPremiumTotalParts"]);

                lblPropertyTotalInsurableValues.Text = clsGeneral.FormatCommaSeperatorCurrency(clsGeneral.GetDecimalValue(txtPropertyRS_Means) + clsGeneral.GetDecimalValue(txtPropertyTotalBusinessInterruption) +
                    clsGeneral.GetDecimalValue(txtPropertyTotalContents) + clsGeneral.GetDecimalValue(txtPropertyTotalParts));
            }          

        }       
    }

    private void BindControlForEdit()
    {
        pnlEdit.Visible = true;
        pnlView.Visible = false;
        txtYear.Enabled = false;
        //txtProperty_Valuation_Date.Enabled = false;

        if (PK_PA_National_Allocation > 0)
        {
            clsPA_National_Allocation objPA_National_Allocation = new clsPA_National_Allocation(PK_PA_National_Allocation);
            txtYear.Text = Convert.ToString(objPA_National_Allocation.Year);
            txtProperty_Valuation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPA_National_Allocation.Property_Valuation_Date);
            txtTotal_Locations.Text = Convert.ToString(objPA_National_Allocation.Total_Locations);
            txtTotal_Headcount.Text = Convert.ToString(objPA_National_Allocation.Total_Headcount);
            txtWC_Premium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.WC_Premium);            
            txtWorkersCompensationRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.WC_Rate);
            txtTexasNonSubscriptionPremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Texas_WC_Premium);
            txtTexasNonSubscriptionRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Texas_WC_Rate);
            txtCrimeRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Crime_Rate);
            txtCrimePremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Crime_Premium); 
            txtCyberPremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Cyber_Premium); 
            txtCyberRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Cyber_Rate); 
            txtEarthquakePremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Earthquake_Premium); 
            txtEarthquakeRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Earthquake_Rate); 
            txtEPLIPremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.EPL_Premium); 
            txtEPLIRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.EPL_Rate); 
            txtExcessUmbrellaRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Excess_Umbrella_Rate); 
            txtExcessUmbrellaPremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Excess_Umbrella_Premium); 
            txtGarageLiabilityPremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Garage_Liability_Premium); 
            txtGarageLiabilityRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Garage_Liability_Rate); 
            txtPollutionPremium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Pollution_Premium); 
            txtPollutionRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Pollution_Rate); 
            txtProperty_Premium.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Property_Premium); 
            txtPropertyRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Property_Rate);

            txtTotalRiskManagementFee.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Total_Risk_Management_Fee);
            txtTotalRiskManagementRate.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Total_Risk_Management_Rate);
            txtTotal_Store_Cost.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Total_Store_Cost);
            txtTotal_Surcharge_Amount.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Total_Surcharge_Amount);
            txtTotal_Actual_Cost.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_National_Allocation.Total_Actual_Cost);

         
            String sDate = txtProperty_Valuation_Date.Text;
            string yy = null;

            if (!string.IsNullOrEmpty(sDate))
            {
                DateTime datevalue = (Convert.ToDateTime(Convert.ToString(sDate)));
                yy = datevalue.Year.ToString();
            }

            DataSet ds = clsPA_National_Allocation.SelectByPropertyValuationYear(Convert.ToInt32(yy), Convert.ToInt32(objPA_National_Allocation.Year));

            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                txtWCTotal_Payroll.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["WorkersCompensationPremiumTotalPayroll"]);
                txtWCTotalHeadcount.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["WorkersCompensationPremiumTotal_Headcount"]);

                txtTXTotalPayroll.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["TexasNonSubscriptionPremiumTotalPayroll"]);
                txtTXTotalHeadcount.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["TexasNonSubscriptionPremiumTotal_Headcount"]);

                txtEarthquakeTotalRSMeans.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["EarthquakePremiumTotalRSMeans"]);
                txtEarthquakeTotalBusinessInterruption.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["EarthquakePremiumTotalBusinessInterruption"]);
                txtEarthquakeTotalContents.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["EarthquakePremiumTotalContents"]);
                txtEarthquakeTotalParts.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["EarthquakePremiumTotalParts"]);

                txtPropertyRS_Means.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["PropertyPremiumTotalRSMeans"]);
                txtPropertyTotalBusinessInterruption.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["PropertyPremiumTotalBusinessInterruption"]);
                txtPropertyTotalContents.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["PropertyPremiumTotalContents"]);
                txtPropertyTotalParts.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["PropertyPremiumTotalParts"]);

                txtPropertyTotalInsurableValues.Text = clsGeneral.FormatCommaSeperatorCurrency(clsGeneral.GetDecimalValue(txtPropertyRS_Means) + clsGeneral.GetDecimalValue(txtPropertyTotalBusinessInterruption) +
                    clsGeneral.GetDecimalValue(txtPropertyTotalContents) + clsGeneral.GetDecimalValue(txtPropertyTotalParts));

                txtEarthquakeTotalInsurableValues.Text = clsGeneral.FormatCommaSeperatorCurrency(clsGeneral.GetDecimalValue(txtEarthquakeTotalRSMeans) + clsGeneral.GetDecimalValue(txtEarthquakeTotalBusinessInterruption) +
                    clsGeneral.GetDecimalValue(txtEarthquakeTotalContents) + clsGeneral.GetDecimalValue(txtEarthquakeTotalParts));


                //txtTotal_Actual_Cost.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["Total_Actual_Cost"]);
            }

        }
        BindRiskManagementGrid();        
    }

    private void CalculateTotalRiskFields()
    {

        if (Convert.ToDecimal(ViewState["TotalRiskManagementFee"]) > 0)
        {
            TotalRiskManagementFee = Convert.ToDecimal(ViewState["TotalRiskManagementFee"]);

            if (clsGeneral.GetDecimalValue(txtTotal_Locations) != 0)
                TotalRiskManagementRate = Convert.ToDecimal(ViewState["TotalRiskManagementFee"]) / clsGeneral.GetDecimalValue(txtTotal_Locations);
            else
                TotalRiskManagementRate = 0;

        }

        TotalActualCost = (clsGeneral.GetDecimalValue(txtTotal_Actual_Cost));
        

        TotalStoreCost = (Convert.ToDecimal(ViewState["TotalRiskManagementFee"]) + clsGeneral.GetDecimalValue(txtWC_Premium) + clsGeneral.GetDecimalValue(txtTexasNonSubscriptionPremium)+
        clsGeneral.GetDecimalValue(txtExcessUmbrellaPremium) + clsGeneral.GetDecimalValue(txtEPLIPremium)+
        clsGeneral.GetDecimalValue(txtGarageLiabilityPremium) + clsGeneral.GetDecimalValue(txtCrimePremium)+
        clsGeneral.GetDecimalValue(txtCyberPremium) + clsGeneral.GetDecimalValue(txtProperty_Premium)+
        clsGeneral.GetDecimalValue(txtEarthquakePremium) + clsGeneral.GetDecimalValue(txtPollutionPremium));

        TotalSurcharge = TotalActualCost - TotalStoreCost;
    }

    private void ShowTotalRiskValues()
    {
        txtTotalRiskManagementFee.Text = clsGeneral.FormatCommaSeperatorCurrency(TotalRiskManagementFee);
        txtTotalRiskManagementRate.Text = clsGeneral.FormatCommaSeperatorCurrency(TotalRiskManagementRate);
        txtTotal_Store_Cost.Text = clsGeneral.FormatCommaSeperatorCurrency(TotalStoreCost);
        txtTotal_Surcharge_Amount.Text = clsGeneral.FormatCommaSeperatorCurrency(TotalSurcharge);
        //txtTotal_Actual_Cost.Text = clsGeneral.FormatCommaSeperatorCurrency(TotalActualCost);
    }

    private void BindRiskManagementGrid()
    {
        if (PK_PA_National_Allocation > 0)
        {
            DataSet ds = clsPA_National_Allocation.SelectAllRiskManagementGrid(PK_PA_National_Allocation);            
            DataTable dttemp = ds.Tables[0];
            if (dttemp != null && dttemp.Rows.Count > 0)
            {
                gvRiskManagementServiceGrid.DataSource = gvRiskManagementServiceGridView.DataSource = dttemp;
            }
            gvRiskManagementServiceGrid.DataBind();
            gvRiskManagementServiceGridView.DataBind();
            lnkAddRiskServiceNew.Visible = true;            
        }
        else
        {            
            gvRiskManagementServiceGrid.DataBind();
            gvRiskManagementServiceGridView.DataBind();
            lnkAddRiskServiceNew.Visible = false;
        }
    }

    private void setEmpty()
    {
        txtYear.Text = "";
        txtProperty_Valuation_Date.Text = "";
        txtTotal_Locations.Text = "";
        txtTotal_Headcount.Text = "";
        txtWC_Premium.Text = "";
        txtWorkersCompensationRate.Text = "";
        txtTexasNonSubscriptionPremium.Text = "";
        txtTexasNonSubscriptionRate.Text = "";
        txtCrimeRate.Text = "";
        txtCrimePremium.Text = "";
        txtCyberPremium.Text = "";
        txtCyberRate.Text = "";
        txtEarthquakePremium.Text = "";
        txtEarthquakeRate.Text = "";
        txtEPLIPremium.Text = "";
        txtEPLIRate.Text = "";
        txtExcessUmbrellaRate.Text = "";
        txtExcessUmbrellaPremium.Text = "";
        txtGarageLiabilityPremium.Text = "";
        txtGarageLiabilityRate.Text = "";
        txtPollutionPremium.Text = "";
        txtPollutionRate.Text = "";
        txtProperty_Premium.Text = "";
        txtPropertyRate.Text = "";
        txtWCTotal_Payroll.Text = "";
        txtWCTotalHeadcount.Text = "";
        txtTXTotalPayroll.Text = "";
        txtTXTotalHeadcount.Text = "";
        txtEarthquakeTotalRSMeans.Text = "";
        txtEarthquakeTotalBusinessInterruption.Text = "";
        txtEarthquakeTotalContents.Text = "";
        txtEarthquakeTotalParts.Text = "";
        txtPropertyRS_Means.Text = "";
        txtPropertyTotalBusinessInterruption.Text = "";
        txtPropertyTotalContents.Text = "";
        txtPropertyTotalParts.Text = "";
        txtPropertyTotalInsurableValues.Text = "";
        txtTotal_Actual_Cost.Text = "";
        txtTotal_Surcharge_Amount.Text = "";
        txtTotalRiskManagementFee.Text = "";
        txtTotalRiskManagementRate.Text = "";
        txtTotal_Store_Cost.Text = "";
    }

    private void BindServiceDropdown()
    {
        ddlService.DataSource = clsPA_National_Allocation_Service_Grid.LU_NPA_Service();
        ddlService.DataTextField = "Field_Description";
        ddlService.DataValueField = "PK_LU_NPA_Service";
        ddlService.DataBind();
        ddlService.Items.Insert(0, new ListItem("--SELECT--", "0"));
    }

    private void SetRiskManagementFields()
    {
        clsPA_National_Allocation objPA_National_Allocation = new clsPA_National_Allocation();
        objPA_National_Allocation.PK_PA_National_Allocation = PK_PA_National_Allocation;
        objPA_National_Allocation.Total_Locations = Convert.ToInt32(txtTotal_Locations.Text);
        objPA_National_Allocation.Year = Convert.ToInt32(txtYear.Text);
        

        if (PK_PA_National_Allocation > 0)
        {
            DataSet ds = objPA_National_Allocation.UpdateTotalRiskValues(objPA_National_Allocation.Year, objPA_National_Allocation.Total_Locations, objPA_National_Allocation.PK_PA_National_Allocation);

            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                txtTotalRiskManagementFee.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["Total_Risk_Management_Fee"]);
                txtTotalRiskManagementRate.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["Total_Risk_Management_Rate"]);
                txtTotal_Store_Cost.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["Total_Store_Cost"]);
                txtTotal_Surcharge_Amount.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["Total_Store_Cost"]);
                txtTotal_Actual_Cost.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["Total_Actual_Cost"]);
            }
        }

    }

    #endregion
        
}