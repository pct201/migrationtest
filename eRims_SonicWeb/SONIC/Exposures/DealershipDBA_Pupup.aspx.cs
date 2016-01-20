using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class SONIC_RealEstate_DealershipDBA_Pupup : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Primary Key -Lu Location
    /// </summary>
    public decimal _PK_LU_Location
    {
        get { return (!clsGeneral.IsNull(ViewState["PK_LU_Location"]) ? Convert.ToDecimal(ViewState["PK_LU_Location"]) : 0); }
        set
        {
            ViewState["PK_LU_Location"] = value;
        }
    }

    #endregion

    #region "Page Load"
    /// <summary>
    /// Handle Page Load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _PK_LU_Location = 0;
            rdbActive.SelectedIndex = 0;
            BinDropDownList();
            lblHeader.Text = "Add Location";
            if (Request.QueryString["id"] != null)
            {
                decimal index;
                if (decimal.TryParse(Request.QueryString["id"], out index))
                {
                    _PK_LU_Location = index;
                    hdLocationID.Value = index.ToString();
                    if (App_RealEstateAccess == AccessType.Administrative_Access)
                    {
                        BindDealershipDetail();
                        lblHeader.Text = "Edit Location";
                    }
                    else
                    {
                        BindDealershipDetailView();
                        lblHeader.Text = "View Location";
                        pnlView.Visible = true;
                        pnlEdit.Visible = false;
                    }
                }
            }
            else
            {
                btnViewAudit.Visible = false;
            }
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind Drop Down List
    /// </summary>
    private void BinDropDownList()
    {
        ComboHelper.FillState(new DropDownList[] { drpState }, 0, true);
        drpCounty.Items.Insert(0, new ListItem("--Select--", "0"));

        ComboHelper.FillRegion(new DropDownList[] { drpRegion }, true);
        ComboHelper.FillMarket(new DropDownList[] { drpLU_Market }, true,false);
        ComboHelper.FillPayrollCodesListbox(new ListBox[] { lstPayrollCodes }, false);
        DataTable dtRLCM = Employee.SelectRLCM_Emp().Tables[0];
        drpRLCM.DataSource = dtRLCM;
        drpRLCM.DataTextField = "Employee";
        drpRLCM.DataValueField = "PK_Employee_Id";
        drpRLCM.DataBind();
        drpRLCM.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    /// <summary>
    /// Bund dealership details for edit
    /// </summary>
    private void BindDealershipDetail()
    {
        if (_PK_LU_Location > 0)
        {
            LU_Location objLocation = new LU_Location(_PK_LU_Location);

            txtDba.Text = objLocation.dba;
            //txtLegalEntity.Text = objLocation.legal_entity;
            txtAddress1.Text = objLocation.Address_1;
            txtAddress2.Text = objLocation.Address_2;
            txtCity.Text = objLocation.City;
            drpState.SelectedValue = objLocation.State;
            txtZipCode.Text = objLocation.Zip_Code;
            BindCounty(drpState.SelectedItem.Text);
            drpCounty.SelectedValue = objLocation.County == string.Empty ? "0" : objLocation.County;
            txtTelePhone.Text = objLocation.Dealership_Telephone;
            txtYearofAquisition.Text = objLocation.Year_of_Acquisition;
            txtWebSite.Text = objLocation.Web_site;
            txtRIMNumber.Text = objLocation.RM_Location_Number;
            drpRegion.SelectedValue = objLocation.Region;
            //txtAdpDms.Text = objLocation.ADP_DMS;
            txtLocationDesc.Text = objLocation.Location_Description;
            txtSonicLocationCode.Text = Convert.ToString(objLocation.Sonic_Location_Code);
            rdbActive.SelectedValue = objLocation.Active;
            rdoShowOnDashboard.SelectedValue = objLocation.Show_On_Dashboard;
            if (objLocation.FK_Employee_Id != null) drpRLCM.SelectedValue = objLocation.FK_Employee_Id.ToString();
            if (objLocation.FK_LU_Market != null) drpLU_Market.SelectedValue = objLocation.FK_LU_Market.ToString();
            txtParentCompanyLegalEntity.Text = objLocation.Parent_Company_LE;
            txtParentCompanyLegalEntityFEIN.Text = objLocation.Parent_Company_LE_FEIN;
            txtLegalEntityOperations.Text = objLocation.LE_Operations;
            txtLegalEntityOperationsFEIN.Text = objLocation.LE_Operations_FEIN;
            txtLegalEntityProperties.Text = objLocation.LE_Properties;
            txtLegalEntityPropertiesFEIN.Text = objLocation.LE_Properties_FEIN;

            DataSet dsPayroll = LU_Location.SelectPayrollByLocation(_PK_LU_Location);
            if (dsPayroll != null && dsPayroll.Tables.Count > 0 && dsPayroll.Tables[0].Rows.Count > 0)
            {
                lstPayrollCodes.ClearSelection();
                foreach (DataRow dr in dsPayroll.Tables[0].Rows)
                {
                    if (lstPayrollCodes.Items.FindByValue(dr["Payroll_Code"].ToString()) != null)
                        lstPayrollCodes.Items.FindByValue(dr["Payroll_Code"].ToString()).Selected = true;
                }
            }
        }
        else
        {
            btnViewAudit.Visible = false;
        }
    }

    /// <summary>
    /// Bund dealership details for View
    /// </summary>
    private void BindDealershipDetailView()
    {
        if (_PK_LU_Location > 0)
        {
            LU_Location objLocation = new LU_Location(_PK_LU_Location);

            lblDBA.Text = objLocation.dba;
            //lblLegalEntity.Text = objLocation.legal_entity;
            lblAddress1.Text = objLocation.Address_1;
            lblAddress2.Text = objLocation.Address_2;
            lblCity.Text = objLocation.City;
            lblState.Text = (objLocation.State != null || objLocation.State != string.Empty) ? new State(Convert.ToDecimal(objLocation.State)).FLD_state : "";
            lblZipCode.Text = objLocation.Zip_Code;
            lblCounty.Text = (objLocation.County != null || objLocation.County != string.Empty) ? new County(Convert.ToDecimal(objLocation.County)).FLD_county : "";
            lblTelephone.Text = objLocation.Dealership_Telephone;
            lblYear.Text = objLocation.Year_of_Acquisition;
            lblWebsite.Text = objLocation.Web_site;
            lblRIMNumber.Text = objLocation.RM_Location_Number;
            lblRegion.Text = objLocation.Region;
            lblADPDMS.Text = objLocation.ADP_DMS;
            lblLocationDescription.Text = objLocation.Location_Description;
            lblSonicCode.Text = Convert.ToString(objLocation.Sonic_Location_Code);
            lblActive.Text = objLocation.Active;
            lblShowOnDashboard.Text = objLocation.Show_On_Dashboard == "Y" ? "Yes" : "No";
            if (objLocation.FK_Employee_Id != null)
            {
                Employee objEmp = new Employee((decimal)objLocation.FK_Employee_Id);
                lblRLCM.Text = objEmp.Last_Name + ", " + objEmp.First_Name;
            }
            if (objLocation.FK_LU_Market != null)
            {
                clsLU_Market objEmp = new clsLU_Market((decimal)objLocation.FK_LU_Market);
                lblLU_Market.Text = objEmp.Market;
            }
            lblParentCompanyLegalEntity.Text = objLocation.Parent_Company_LE;
            lblParentCompanyLegalEntityFEIN.Text = objLocation.Parent_Company_LE_FEIN;
            lblLegalEntityOperations.Text = objLocation.LE_Operations;
            lblLegalEntityOperationsFEIN.Text = objLocation.LE_Operations_FEIN;
            lblLegalEntityProperties.Text = objLocation.LE_Properties;
            lblLegalEntityPropertiesFEIN.Text = objLocation.LE_Properties_FEIN;
        }
        else
        {
            btnViewAudit.Visible = false;
        }
    }

    /// <summary>
    /// Bind count - on selection of state
    /// </summary>
    /// <param name="strState"></param>
    private void BindCounty(string strState)
    {
        drpCounty.DataSource = County.SelectAllByState(strState);
        drpCounty.DataValueField = "PK_ID";
        drpCounty.DataTextField = "FLD_county";
        drpCounty.DataBind();

        drpCounty.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    /// <summary>
    /// set Properties for save data
    /// </summary>
    /// <param name="objLocation"></param>
    private void setProperties(LU_Location objLocation)
    {
        objLocation.PK_LU_Location_ID = _PK_LU_Location;
        objLocation.dba = Convert.ToString(txtDba.Text);
        //objLocation.legal_entity = Convert.ToString(txtLegalEntity.Text);
        objLocation.Address_1 = Convert.ToString(txtAddress1.Text);
        objLocation.Address_2 = Convert.ToString(txtAddress2.Text);
        objLocation.City = Convert.ToString(txtCity.Text);
        objLocation.State = drpState.SelectedValue;
        objLocation.Zip_Code = Convert.ToString(txtZipCode.Text);
        objLocation.County = drpCounty.SelectedValue;
        objLocation.Dealership_Telephone = Convert.ToString(txtTelePhone.Text);
        objLocation.Year_of_Acquisition = Convert.ToString(txtYearofAquisition.Text);
        objLocation.Web_site = Convert.ToString(txtWebSite.Text);
        objLocation.RM_Location_Number = Convert.ToString(txtRIMNumber.Text);
        //objLocation.ADP_DMS = Convert.ToString(txtAdpDms.Text.Replace(",", ""));
        objLocation.Location_Description = Convert.ToString(txtLocationDesc.Text);
        objLocation.Sonic_Location_Code = Convert.ToInt32(txtSonicLocationCode.Text);
        objLocation.Active = rdbActive.SelectedValue;
        objLocation.Region = Convert.ToString(drpRegion.SelectedValue);
        objLocation.Show_On_Dashboard = rdoShowOnDashboard.SelectedValue;
        if (drpRLCM.SelectedIndex > 0) objLocation.FK_Employee_Id = Convert.ToDecimal(drpRLCM.SelectedValue);
        objLocation.FK_LU_Market = Convert.ToDecimal(drpLU_Market.SelectedValue);
        objLocation.Parent_Company_LE = Convert.ToString(txtParentCompanyLegalEntity.Text);
        objLocation.Parent_Company_LE_FEIN = Convert.ToString(txtParentCompanyLegalEntityFEIN.Text);
        objLocation.LE_Operations = Convert.ToString(txtLegalEntityOperations.Text);
        objLocation.LE_Operations_FEIN = Convert.ToString(txtLegalEntityOperationsFEIN.Text);
        objLocation.LE_Properties = Convert.ToString(txtLegalEntityProperties.Text);
        objLocation.LE_Properties_FEIN = Convert.ToString(txtLegalEntityPropertiesFEIN.Text);
    }

    private void InsertPayroll()
    {
        string _PayrollCodes = string.Empty;
        int[] payrollIndices = lstPayrollCodes.GetSelectedIndices();
        if (payrollIndices != null && payrollIndices.Length > 0)
        {
            foreach (int currentIndex in payrollIndices)
                _PayrollCodes += lstPayrollCodes.Items[currentIndex].Value + ",";
        }
        _PayrollCodes = _PayrollCodes.TrimEnd(',');
        LU_Location objLU_Location = new LU_Location();
        objLU_Location.PK_LU_Location_ID = _PK_LU_Location;
        objLU_Location.Payroll_Codes = _PayrollCodes;
        objLU_Location.InsertUpdatePayrollByLocation();
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Handle Save button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (App_RealEstateAccess == AccessType.View_Only)
        {
            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            return;
        }

        LU_Location objLocation = new LU_Location();
        setProperties(objLocation);



        if (_PK_LU_Location > 0)
        {
            objLocation.Update();
        }
        else
        {
            _PK_LU_Location = objLocation.Insert();
        }
        InsertPayroll();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:parent.parent.location.href=parent.parent.location.href", true);
    }

    /// <summary>
    /// Handle state dropdown selected index changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpState.SelectedIndex > 0)
        {
            BindCounty(drpState.SelectedItem.Text);
        }
        else
        {
            drpCounty.Items.Clear();
            drpCounty.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    #endregion


}
