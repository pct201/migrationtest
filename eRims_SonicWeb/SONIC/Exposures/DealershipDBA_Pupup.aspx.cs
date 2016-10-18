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

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Location_2_Organization_Id
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Location_2_Organization_Id"]);
        }
        set { ViewState["PK_LU_Location_2_Organization_Id"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_PayrollCodes
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PayrollCodes"]);
        }
        set { ViewState["PK_PayrollCodes"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_Location
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Location"]);
        }
        set { ViewState["PK_LU_Location"] = value; }
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
            //bind Payroll Grid
            BindGrid();
            lblHeader.Text = "Add Location";
            dvPayroll.Visible = false;
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
            txtActivation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objLocation.Activation_Date);

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
            lblActivation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objLocation.Activation_Date);
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
        if (!string.IsNullOrEmpty(txtActivation_Date.Text))
            objLocation.Activation_Date = Convert.ToDateTime(txtActivation_Date.Text);
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

        //Save the new added Payroll into database
        DataTable dtPayroll = (DataTable)ViewState["PayrollCodes"];
        LU_Location_2_Organization objLU_Location_2_Organization = new LU_Location_2_Organization();

          if (dtPayroll != null && dtPayroll.Rows.Count > 0)
            {
                foreach (DataRow dr in dtPayroll.Rows)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(dr["PK_LU_Location_2_Organization_Id"])))
                    {
                        objLU_Location_2_Organization.ADP_DMS=Convert.ToString(dr["ADP_DMS"]);
                        objLU_Location_2_Organization.Organization_Code = Convert.ToString(dr["Organization_Code"]);
                        objLU_Location_2_Organization.Organization_Name = Convert.ToString(dr["Organization_Name"]);
                        if (string.IsNullOrEmpty(Convert.ToString(dr["Sonic_Location_Code"])) || Convert.ToInt32(dr["Sonic_Location_Code"])==0)
                            objLU_Location_2_Organization.Sonic_Location_Code = Convert.ToInt32(txtSonicLocationCode.Text);
                        else
                            objLU_Location_2_Organization.Sonic_Location_Code = Convert.ToInt32(dr["Sonic_Location_Code"]);
                        objLU_Location_2_Organization.Insert();
                    }
                }
            }

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

    /// <summary>
    /// Add new button link event   
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add";
        _PK_LU_Location_2_Organization_Id = 0;
        _PK_PayrollCodes = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtADP.Text = "";
        txtOrganization_Code.Text = "";
        txtOrganization_Name.Text = "";

        if (Request.QueryString["id"] != null)
            PK_LU_Location = Convert.ToInt32(Request.QueryString["id"]);
        DataTable dt = LU_Location.SelectByPK(PK_LU_Location).Tables[0];

        if (dt!=null && dt.Rows.Count>0)
        lblSonicLocationCode.Text = Convert.ToString(dt.Rows[0]["Sonic_Location_Code"]);
        //((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtADP);
        //((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtOrganization_Code);
        //((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtOrganization_Name);
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        trStatusAdd.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "none");
        txtADP.Text = "";
        txtOrganization_Code.Text = "";
        txtOrganization_Name.Text = "";
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (_PK_PayrollCodes > 0)
        {
            DataTable dt = (DataTable)ViewState["PayrollCodes"];
            DataRow[] dr = dt.Select(" Organization_Code = '" + Convert.ToString(txtOrganization_Code.Text) + "' AND PK_PayrollCodes NOT IN (" + _PK_PayrollCodes + ")");
            //DataRow[] dr = dt.Select(" Organization_Code = '" + Convert.ToString(txtOrganization_Code.Text) + "'");
            if (dr.Length > 0)
            {
                lblError.Text = "The Payroll Code that you are trying to add already exists.";
                //btnAdd.Text = "Add";
                return;
            }
            else
            {
                DataRow[] drTemp =  dt.Select(" PK_PayrollCodes = '" + _PK_PayrollCodes + "'");
                drTemp[0]["ADP_DMS"] = txtADP.Text;
                drTemp[0]["Organization_Code"] = Convert.ToString(txtOrganization_Code.Text);
                drTemp[0]["Organization_Name"] = Convert.ToString(txtOrganization_Name.Text);
                drTemp[0]["Sonic_Location_Code"] = !string.IsNullOrEmpty(Convert.ToString(lblSonicLocationCode.Text)) ? Convert.ToInt32(lblSonicLocationCode.Text) : 0;
                gvPayrollCode.DataSource = dt;
                gvPayrollCode.DataBind();

                //update records which are in db
                if (_PK_LU_Location_2_Organization_Id > 0)
                {
                    LU_Location_2_Organization objLU_Location_2_Organization = new LU_Location_2_Organization();
                    objLU_Location_2_Organization.ADP_DMS = txtADP.Text.Trim();
                    objLU_Location_2_Organization.PK_LU_Location_2_Organization_Id = _PK_LU_Location_2_Organization_Id;
                    objLU_Location_2_Organization.Organization_Code = txtOrganization_Code.Text;
                    objLU_Location_2_Organization.Organization_Name = txtOrganization_Name.Text;
                    objLU_Location_2_Organization.Sonic_Location_Code = Convert.ToInt32(lblSonicLocationCode.Text);
                    objLU_Location_2_Organization.Update();
                }

            }
        }
        else
        {
            DataTable dtPayrollcodes = (DataTable)ViewState["PayrollCodes"];
            DataRow[] dr = dtPayrollcodes.Select(" Organization_Code = '" + Convert.ToString(txtOrganization_Code.Text) + "'");

            if (dr.Length > 0)
            {
                lblError.Text = "The Payroll Code that you are trying to add already exists.";
                //((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtOrganization_Code);
                btnAdd.Text = "Add";
                return;
            }
            else
            {
                dtPayrollcodes.Rows.Add(null, !string.IsNullOrEmpty(lblSonicLocationCode.Text) ? Convert.ToInt32(lblSonicLocationCode.Text) : 0, txtADP.Text, txtOrganization_Code.Text, txtOrganization_Name.Text, null);

                //saving databale into viewstate   
                ViewState["PayrollCodes"] = dtPayrollcodes;

                //bind Gridview  
                gvPayrollCode.DataSource = dtPayrollcodes;
                gvPayrollCode.DataBind();
            }
        }

        //claer Control
        ClearControls();
        //Cancel CLick
        lnkCancel_Click(null, null);
    }

    #endregion

    #region "Grid Event"

    protected void gvPayrollCode_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPayrollCode.PageIndex = e.NewPageIndex; //Page new index call
        DataTable dtPayrollcodes = (DataTable)ViewState["PayrollCodes"];
        //saving databale into viewstate   
        ViewState["PayrollCodes"] = dtPayrollcodes;
        //bind Gridview  
        gvPayrollCode.DataSource = dtPayrollcodes;
        gvPayrollCode.DataBind();
    }
    protected void gvPayrollCode_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_PayrollCodes = Convert.ToDecimal(e.CommandArgument);

            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";

            DataTable dtPayrollcodes = (DataTable)ViewState["PayrollCodes"];
            DataRow[] drPayroll = dtPayrollcodes.Select(" PK_PayrollCodes = '" + _PK_PayrollCodes + "'");
            if (!string.IsNullOrEmpty(Convert.ToString(drPayroll[0]["PK_LU_Location_2_Organization_Id"])))
                _PK_LU_Location_2_Organization_Id = Convert.ToInt32(drPayroll[0]["PK_LU_Location_2_Organization_Id"]);
            txtADP.Text = Convert.ToString(drPayroll[0]["ADP_DMS"]);
            txtOrganization_Code.Text = Convert.ToString(drPayroll[0]["Organization_Code"]);
            txtOrganization_Name.Text = Convert.ToString(drPayroll[0]["Organization_Name"]);
            lblSonicLocationCode.Text = Convert.ToString(drPayroll[0]["Sonic_Location_Code"]);
        }
        else if (e.CommandName == "DeleteRecord")
        {
            _PK_PayrollCodes = Convert.ToDecimal(e.CommandArgument);

            DataTable dtPayrollcodes = (DataTable)ViewState["PayrollCodes"];
            DataRow[] drr = dtPayrollcodes.Select(" PK_PayrollCodes = '" + _PK_PayrollCodes + "'");

            //delete for the old Records
            if (!string.IsNullOrEmpty(Convert.ToString(drr[0]["PK_LU_Location_2_Organization_Id"])) && Convert.ToInt32(drr[0]["PK_LU_Location_2_Organization_Id"]) > 0)
            {
                LU_Location_2_Organization.DeleteByPK(Convert.ToInt32(drr[0]["PK_LU_Location_2_Organization_Id"]));
            }

            for (int i = 0; i < drr.Length; i++)
                drr[i].Delete();

            gvPayrollCode.DataSource = dtPayrollcodes;
            gvPayrollCode.DataBind();
            ViewState["PayrollCodes"] = dtPayrollcodes;
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind PayRoll Grid
    /// </summary>
    private void BindGrid()
    {

        DataTable dtPayroll = LU_Location_2_Organization.SelectAll().Tables[0];
        DataTable dtPayrollcodes = new DataTable();
        dtPayrollcodes = dtPayroll.Clone();

        //add new Primary key column
        dtPayrollcodes.PrimaryKey = new DataColumn[] { dtPayrollcodes.Columns["PK_PayrollCodes"] };
        dtPayrollcodes.Columns.Add(new DataColumn("PK_PayrollCodes", typeof(decimal)));
        dtPayrollcodes.Columns["PK_PayrollCodes"].AutoIncrement = true;
        dtPayrollcodes.Columns["PK_PayrollCodes"].AutoIncrementSeed = 1;
        dtPayrollcodes.Columns["PK_PayrollCodes"].AutoIncrementStep = 1;

        for (int i = 0; i < dtPayroll.Rows.Count; i++)
        {
            string PK_LU_Location_2_Organization_Id = Convert.ToString(dtPayroll.Rows[i]["PK_LU_Location_2_Organization_Id"]);
            Int32 Sonic_Location_Code = !string.IsNullOrEmpty(Convert.ToString(dtPayroll.Rows[i]["Sonic_Location_Code"])) ? Convert.ToInt32(dtPayroll.Rows[i]["Sonic_Location_Code"]) : 0;
            string ADP_DMS = Convert.ToString(dtPayroll.Rows[i]["ADP_DMS"]);
            string Organization_Code = Convert.ToString(dtPayroll.Rows[i]["Organization_Code"]);
            string Organization_Name = Convert.ToString(dtPayroll.Rows[i]["Organization_Name"]);
            dtPayrollcodes.Rows.Add(PK_LU_Location_2_Organization_Id, Sonic_Location_Code, ADP_DMS, Organization_Code, Organization_Name, null);
        }

        //Apply Datatable to Grid
        gvPayrollCode.DataSource = dtPayrollcodes;
        gvPayrollCode.DataBind();

        //save datatable in the view state
        ViewState["PayrollCodes"] = dtPayrollcodes;
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Location_2_Organization_Id = 0;
        _PK_PayrollCodes = 0;
    }
    #endregion

    protected void btnManage_Click(object sender, EventArgs e)
    {
        dvPayroll.Visible = true;
        dvLocation.Visible = false;
        //ViewState["PayrollCodes"] = null;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        dvLocation.Visible = true;
        dvPayroll.Visible = false;

        DataTable dtPayroll = LU_Location.SelectPayrollByLocation(_PK_LU_Location).Tables[0];
        //DataSet dsPayroll = LU_Location.SelectPayrollByLocation(_PK_LU_Location);
        if (dtPayroll != null && dtPayroll.Rows.Count > 0 )
        {
            lstPayrollCodes.ClearSelection();
            foreach (DataRow dr in dtPayroll.Rows)
            {
                if (lstPayrollCodes.Items.FindByValue(dr["Payroll_Code"].ToString()) != null)
                    lstPayrollCodes.Items.FindByValue(dr["Payroll_Code"].ToString()).Selected = true;
            }
        }

        //Rebind the Payroll Data
       
        DataTable dtPay = (DataTable)ViewState["PayrollCodes"];
        
        if (dtPay != null && dtPay.Rows.Count > 0)
        {
            foreach (DataRow dr in dtPay.Rows)
            {
                if (string.IsNullOrEmpty(Convert.ToString(dr["PK_LU_Location_2_Organization_Id"])))
                {
                    lstPayrollCodes.Items.Add(dr["Organization_Code"].ToString());
                }
            }
        }
    }
}
