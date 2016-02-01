using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ERIMS.DAL;

/**************** PAGE IS NOT IN USE ******************************/


public partial class SONIC_RealEstate_RealEstateAddEdit : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key for RE_Information
    /// </summary>
    public decimal _PK_RE_Information
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_RE_Information"]);
        }
        set { ViewState["PK_RE_Information"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key for RE_Notices
    /// </summary>
    public decimal _PK_RE_Notices
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_RE_Notices"]);
        }
        set { ViewState["PK_RE_Notices"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key for RE_Rent_Projections
    /// </summary>
    public decimal _PK_RE_Rent
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_RE_Rent"]);
        }
        set { ViewState["PK_RE_Rent"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key for RE_Rent_Projections
    /// </summary>
    public decimal _PK_RE_Rent_Projections
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_RE_Rent_Projections"]);
        }
        set { ViewState["PK_RE_Rent_Projections"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key for RE_Security_Deposit
    /// </summary>
    public decimal _PK_RE_Security_Deposit
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_RE_Security_Deposit"]);
        }
        set { ViewState["PK_RE_Security_Deposit"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_RE_Subtenant
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_RE_Subtenant"]);
        }
        set { ViewState["PK_RE_Subtenant"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_RE_Surrender_Obligations
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_RE_Surrender_Obligations"]);
        }
        set { ViewState["PK_RE_Surrender_Obligations"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string _StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }

    /// <summary>
    /// Denotes whether user has access rights for edit or not
    /// </summary>
    public bool _bAllowEdit
    {
        get { return ViewState["bAllowEdit"] != null ? Convert.ToBoolean(ViewState["bAllowEdit"]) : false; }
        set { ViewState["bAllowEdit"] = value; }
    }

    #endregion

    #region Page Events

    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        /**************** PAGE IS NOT IN USE ******************************/


        RE_Tab.SetSelectedTab(RealEstate.Tab.RealEstate);

        if (!Page.IsPostBack)
        {
            // check if page is in "Add" mode.
            if (!string.IsNullOrEmpty(Request.QueryString["mode"]))
            {
                clsSession.Str_RE_Operation = "";
                clsSession.Current_RE_Information_ID = 0;
            }

            // Check if page in edit mode and User has only View rights
            if (App_Access == AccessType.View_Only && clsSession.Str_RE_Operation.ToUpper() == "Edit".ToUpper() && string.IsNullOrEmpty(clsSession.Str_RE_Operation))
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                return;
            }
            SetUserRights();

            # region " Javascript Settings "

            txtLease_Term_Months.Attributes.Add("onchange", "document.getElementById('" + lblRentLeaseTerm.ClientID + "').innerHTML = this.value;" +
                                                            "document.getElementById('" + lblSubTenantLeaseTerm.ClientID + "').innerHTML = this.value;" +
                                                            "document.getElementById('" + lblRentProjectionsLeaseTerm.ClientID + "').innerHTML = this.value;");
            txtLease_Expiration_Date.Attributes.Add("onchange", "document.getElementById('" + lblRentLeaseExpDate.ClientID + "').innerHTML = this.value;" +
                                                                "document.getElementById('" + lblSubTenantLeaseExpDate.ClientID + "').innerHTML = this.value;" +
                                                                "document.getElementById('" + lblRentProjectionsLeaseExpDate.ClientID + "').innerHTML = this.value;");
            txtPrior_Lease_Commencement_Date.Attributes.Add("onchange", "document.getElementById('" + lblRentPriorLeaseDate.ClientID + "').innerHTML = this.value;" +
                                                                        "document.getElementById('" + lblSubTenantPriorLeaseDate.ClientID + "').innerHTML = this.value;" +
                                                                        "document.getElementById('" + lblRentProjectionsPriorLeaseDate.ClientID + "').innerHTML = this.value;");

            txtLease_Term_Months.Attributes.Add("onblur", "document.getElementById('" + lblRentLeaseTerm.ClientID + "').innerHTML = this.value;" +
                                                            "document.getElementById('" + lblSubTenantLeaseTerm.ClientID + "').innerHTML = this.value;" +
                                                            "document.getElementById('" + lblRentProjectionsLeaseTerm.ClientID + "').innerHTML = this.value;");
            txtLease_Expiration_Date.Attributes.Add("onblur", "document.getElementById('" + lblRentLeaseExpDate.ClientID + "').innerHTML = this.value;" +
                                                                "document.getElementById('" + lblSubTenantLeaseExpDate.ClientID + "').innerHTML = this.value;" +
                                                                "document.getElementById('" + lblRentProjectionsLeaseExpDate.ClientID + "').innerHTML = this.value;");
            txtPrior_Lease_Commencement_Date.Attributes.Add("onblur", "document.getElementById('" + lblRentPriorLeaseDate.ClientID + "').innerHTML = this.value;" +
                                                                        "document.getElementById('" + lblSubTenantPriorLeaseDate.ClientID + "').innerHTML = this.value;" +
                                                                        "document.getElementById('" + lblRentProjectionsPriorLeaseDate.ClientID + "').innerHTML = this.value;");



            drpFK_LU_EscalationRent.Attributes.Add("onclick", "return CheckLeaseDate();");
            drpFK_LU_EscalationRent.Attributes.Add("onchange", "MakeEditableRateRent(this);");

            drpFK_LU_EscalationSubtenant.Attributes.Add("onclick", "return CheckLeaseDate();");
            drpFK_LU_EscalationSubtenant.Attributes.Add("onchange", "MakeEditableRateSubtenant(this);");

            drpFK_LU_Escalation.Attributes.Add("onclick", "return CheckLeaseDate();");
            drpFK_LU_Escalation.Attributes.Add("onchange", "MakeEditableRateRentProjection(this);");

            #endregion

            int intPanel = 1;
            if (Request.QueryString["pnl"] != null)
            {
                int index;
                if (int.TryParse(Request.QueryString["pnl"], out index))
                {
                    intPanel = index;
                    ShowPanel(intPanel);
                }
            }
            else
                ShowPanel(1);

            _StrOperation = clsSession.Str_RE_Operation;
            if (_StrOperation != string.Empty)
            {
                // get PK from session
                _PK_RE_Information = clsSession.Current_RE_Information_ID;

                // bind the information on top of the page
                RealEstate_Info.PK_RE_Information = _PK_RE_Information;
                RealEstate_Info.BindrRealEstateInfo();

                // set all PKs
                DataTable dtPKs = RE_Information.GetPKofAllChildTables(_PK_RE_Information).Tables[0];
                if (dtPKs.Rows.Count > 0)
                {
                    _PK_RE_Subtenant = Convert.ToDecimal(dtPKs.Rows[0]["RE_Subtenant"]);
                    _PK_RE_Rent_Projections = Convert.ToDecimal(dtPKs.Rows[0]["RE_Rent_Projections"]);
                    _PK_RE_Security_Deposit = Convert.ToDecimal(dtPKs.Rows[0]["RE_Security_Deposit"]);
                    _PK_RE_Surrender_Obligations = Convert.ToDecimal(dtPKs.Rows[0]["RE_Surrender_Obligations"]);
                    _PK_RE_Notices = Convert.ToDecimal(dtPKs.Rows[0]["RE_Notices"]);
                }

                if (_StrOperation == "view")
                {
                    // Bind Controls
                    BindDetailsForView();
                    // set attachment details control in readonly mode.
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.RE_Information, (int)_PK_RE_Information, false, 9);

                    if (App_Access == AccessType.View_Only)
                        btnBack.Visible = false;
                }
                else
                {
                    BindDropDowns();
                    // Bind Controls
                    BindDetailsForEdit();
                    // set attachment details control in read/write mode. so user can add or remove attachment as well.
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.RE_Information, (int)_PK_RE_Information, true, 9);
                    ((Button)AttachDetails.FindControl("btnRemoveAttachment")).Visible = App_Access == AccessType.Administrative_Access;
                }
                // bind attachment details to show attachment for current risk profile.
                BindAttachmentDetails();
            }
            else
            {
                if (_bAllowEdit)
                {
                    tblREInfo.Visible = false;
                    BindDropDowns();
                    // disable Add Attachment button
                    btnAddAttachment.Enabled = false;
                    BindAttachmentDetails();
                    // don't show div for view mode
                    dvSave.Style["display"] = "block";
                    dvView.Style["display"] = "none";
                }
                else
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }
            BindGrids();
        }
        else
        {
            # region " Perform Operations when Lease Date Changed or Monthly Rents changed "
            // get Event arguments sent from javascript
            string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];

            // if Lease date is changed
            if (eventTarget == "LeaseDateChanged")
            {
                SetLeaseInformation();

                bool bValid = IsValidORSFromDate(gvRentRRS);
                if (bValid)
                {
                    bValid = IsValidORSFromDate(gvSubtenantORS);
                    if (bValid)
                    {
                        bValid = IsValidORSFromDate(gvRentProjectionORS);
                        if (bValid)
                        {
                            if (drpFK_LU_EscalationRent.SelectedIndex > 0 && (gvRentTRS.Rows.Count > 0 || gvRentRRS.Rows.Count > 0))
                            {
                                CalculateMonthlyRent_Rent();
                            }
                            if (drpFK_LU_EscalationSubtenant.SelectedIndex > 0 && (gvSubtenantTRS.Rows.Count > 0 || gvSubtenantORS.Rows.Count > 0))
                            {
                                CalculateMonthlyRent_Subtenant();
                            }
                            if (drpFK_LU_Escalation.SelectedIndex > 0 && (gvRentProjectionTRS.Rows.Count > 0 || gvRentProjectionORS.Rows.Count > 0))
                            {
                                CalculateMonthlyRent_RentProjection();
                            }
                            ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
                        }
                        else
                            ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowMessageLeaseDateError('Subtenant');", true);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowMessageLeaseDateError('RentProjection');", true);                
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowMessageLeaseDateError('RentProjection');", true);                
                }
                
            }
            else if (eventTarget == "RentMonthlyRentChanged")
            {
                SetLeaseInformation();

                if ((gvRentTRS.Rows.Count > 0 || gvRentRRS.Rows.Count > 0) && txtLease_Commencement_Date.Text != "")
                {
                    CalculateMonthlyRent_Rent();
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
            }
            else if (eventTarget == "SubtenantMonthlyRentChanged")
            {
                SetLeaseInformation();

                if ((gvSubtenantTRS.Rows.Count > 0 || gvSubtenantORS.Rows.Count > 0) && txtLease_Commencement_Date.Text != "")
                {
                    CalculateMonthlyRent_Subtenant();
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
            }
            else if (eventTarget == "RentProjectionMonthlyRentChanged")
            {
                SetLeaseInformation();

                if ((gvRentProjectionTRS.Rows.Count > 0 || gvRentProjectionORS.Rows.Count > 0) && txtLease_Commencement_Date.Text != "")
                {
                    CalculateMonthlyRent_RentProjection();
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
            }

            #endregion
        }

    }
    #endregion

    #region Methods
    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        // show hide div conrols for edit mode
        dvEdit.Style["display"] = "block";
        dvSave.Style["display"] = "block";
        dvView.Style["display"] = "none";
        dvBack.Style["display"] = "none";

        btnAbstractReport.Visible = true;
        btnAbstractReportView.Visible = false; 

        #region " Bind Real Estate Information "
        // create objects for RE_Information table
        RE_Information objRE_Information = new RE_Information(_PK_RE_Information);

        // set values in page controls
        //hdnLU_location.Value = objRE_Information.FK_LU_Location.ToString();
        //btnDBASelectionChange_Click(null, null);
        drpLU_Location.SelectedValue = objRE_Information.FK_LU_Location.ToString();
        drpLU_Location_SelectedIndexChanged(null, null);
        txtFederal_Id.Text = objRE_Information.Federal_Id;
        if (objRE_Information.FK_LU_Status != null) drpFK_LU_Status.SelectedValue = objRE_Information.FK_LU_Status.ToString();
        txtTax_Parcel_Number.Text = objRE_Information.Tax_Parcel_Number;
        if (objRE_Information.FK_LU_Lease_Type != null) drpFK_LU_Lease_Type.SelectedValue = objRE_Information.FK_LU_Lease_Type.ToString();
        txtLandlord.Text = objRE_Information.Landlord;
        txtLandlord_Location_Address1.Text = objRE_Information.Landlord_Location_Address1;
        txtLandlord_Location_Address2.Text = objRE_Information.Landlord_Location_Address2;
        txtLandlord_Location_City.Text = objRE_Information.Landlord_Location_City;
        if (objRE_Information.PK_Landlord_Location_State != null) drpLandlord_Location_State.SelectedValue = objRE_Information.PK_Landlord_Location_State.ToString();
        txtLandlord_Location_Zip_Code.Text = objRE_Information.Landlord_Location_Zip_Code;
        txtLandlord_Mailing_Address1.Text = objRE_Information.Landlord_Mailing_Address1;
        txtLandlord_Mailing_Address2.Text = objRE_Information.Landlord_Mailing_Address2;
        txtLandlord_Mailing_City.Text = objRE_Information.Landlord_Mailing_City;
        if (objRE_Information.PK_Landlord_Mailing_State != null) drpLandlordMailingState.SelectedValue = objRE_Information.PK_Landlord_Mailing_State.ToString();
        txtLandlord_Mailing_Zip_Code.Text = objRE_Information.Landlord_Mailing_Zip_Code;
        txtLandlord_Telephone.Text = objRE_Information.Landlord_Telephone;
        txtLandlord_Email.Text = objRE_Information.Landlord_Email;
        rdoSublease.SelectedValue = objRE_Information.Sublease.ToString();
        txtSubtenant.Text = objRE_Information.Subtenant;
        txtLease_Id.Text = objRE_Information.Lease_Id;
        txtLease_Commencement_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Commencement_Date);
        if (objRE_Information.FK_LU_Project_Type != null) drpFK_LU_Project_Type.SelectedValue = objRE_Information.FK_LU_Project_Type.ToString();
        txtLease_Expiration_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Expiration_Date);
        txtDate_Acquired.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Date_Acquired);
        txtLease_Term_Months.Text = clsGeneral.GetStringValue(objRE_Information.Lease_Term_Months).Replace(".00", "");
        txtDate_Sold.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Date_Sold);
        txtPrior_Lease_Commencement_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Prior_Lease_Commencement_Date);
        txtRenewals.Text = objRE_Information.Renewals;
        txtYear_Built.Text = objRE_Information.Year_Built.ToString();
        txtReminder_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Reminder_Date);
        txtYear_Remodeled.Text = objRE_Information.Year_Remodeled.ToString();
        txtLandlord_Notification_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Landlord_Notification_Date);
        txtRegional_Vice_President.Text = objRE_Information.Regional_Vice_President;
        txtVacate_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Vacate_Date);
        txtGeneral_Manager.Text = objRE_Information.General_Manager;
        txtPrimary_Use.Text = objRE_Information.Primary_Use;
        txtController.Text = objRE_Information.Controller;
        txtLease_Codes.Text = objRE_Information.Lease_Codes;
        txtLoss_Control_Manager.Text = objRE_Information.Loss_Control_Manager;
        txtTotal_Acres.Text = clsGeneral.GetStringValue(objRE_Information.Total_Acres).Replace(".00", "");
        txtNumber_of_Buildings.Text = clsGeneral.GetStringValue(objRE_Information.Number_of_Buildings).Replace(".00", "");
        txtTotal_Gross_Leaseable_Area.Text = clsGeneral.GetStringValue(objRE_Information.Total_Gross_Leaseable_Area).Replace(".00", "");
        txtLand_Value.Text = clsGeneral.GetStringValue(objRE_Information.Land_Value).Replace(".00", "");

        #endregion

        #region " Bind Rent Information "
        // check if PK for RE_Rent_Projections record is available
        if (_PK_RE_Rent > 0)
        {
            // create object for RE_Rent_Projections
            RE_Rent objRE_Rent = new RE_Rent(_PK_RE_Rent);

            // set values in page controls
            txtResponsible_PartyRent.Text = objRE_Rent.Responsible_Party;
            lblRentLeaseCommencementDate.Text = txtLease_Commencement_Date.Text;
            lblRentLeaseTerm.Text = txtLease_Term_Months.Text;
            lblRentLeaseExpDate.Text = txtLease_Expiration_Date.Text;
            lblRentPriorLeaseDate.Text = txtPrior_Lease_Commencement_Date.Text;
            txtCancel_OptionsRent.Text = objRE_Rent.Cancel_Options;
            txtRenew_OptionsRent.Text = objRE_Rent.Renew_Options;            
            txtNotification_Due_DateRent.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Rent.Notification_Due_Date);
            txtRentSubtenant_Base_Rent.Text = clsGeneral.GetStringValue(objRE_Rent.Subtenant_Base_Rent);
            txtRentSubtenant_Monthly_Rent.Text = clsGeneral.GetStringValue(objRE_Rent.Subtenant_Monthly_Rent);
            if (objRE_Rent.FK_LU_Escalation != null) drpFK_LU_EscalationRent.SelectedValue = objRE_Rent.FK_LU_Escalation.ToString();
            if (drpFK_LU_EscalationRent.SelectedItem.Text == "LIBOR Rate Schedule")
            {
                txtPercentage_RateRent.Text = clsGeneral.GetStringValue(objRE_Rent.Percentage_Rate);
                txtPercentage_RateRent.Enabled = true;
            }
            txtIncreaseRent.Text = clsGeneral.GetStringValue(objRE_Rent.Increase);
        }
        #endregion

        #region " Bind Subtenant Information "

        // check if PK for RE_Subtenant record is available
        if (_PK_RE_Subtenant > 0)
        {
            // create object for RE_Subtenant record
            RE_Subtenant objRE_Subtenant = new RE_Subtenant(_PK_RE_Subtenant);

            //set values in page controls
            txtSubtenant_DBA.Text = objRE_Subtenant.Subtenant_DBA;
            txtSubtenant_Mailing_Address1.Text = objRE_Subtenant.Subtenant_Mailing_Address1;
            txtSubtenant_Mailing_Address2.Text = objRE_Subtenant.Subtenant_Mailing_Address2;
            txtSubtenant_Mailing_City.Text = objRE_Subtenant.Subtenant_Mailing_City;
            txtSubtenant_Mailing_Zip_Code.Text = objRE_Subtenant.Subtenant_Mailing_Zip_Code;
            if (objRE_Subtenant.PK_Subtenant_Mailing_State != null) drpSubtenantMailingState.SelectedValue = objRE_Subtenant.PK_Subtenant_Mailing_State.ToString();
            txtSubtenantTelephone.Text = objRE_Subtenant.Subtenant_Telephone;
            lblSubTenantLeaseCommencementDate.Text = txtLease_Commencement_Date.Text;
            lblSubTenantLeaseTerm.Text = txtLease_Term_Months.Text;
            lblSubTenantLeaseExpDate.Text = txtLease_Expiration_Date.Text;
            lblSubTenantPriorLeaseDate.Text = txtPrior_Lease_Commencement_Date.Text;
            txtCancel_OptionsSubtenant.Text = objRE_Subtenant.Cancel_Options;
            txtRenew_OptionsSubtenant.Text = objRE_Subtenant.Renew_Options;
            txtOpen_NotificationSubtenant.Text = objRE_Subtenant.Option_Notification;
            txtNotification_Due_DateSubtenant.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Subtenant.Notification_Due_Date);
            txtSubtenant_Base_RentSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Subtenant_Base_Rent);
            txtSubtenant_Monthly_RentSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Subtenant_Monthly_Rent);
            if (objRE_Subtenant.FK_LU_Escalation != null) drpFK_LU_EscalationSubtenant.SelectedValue = objRE_Subtenant.FK_LU_Escalation.ToString();
            if (drpFK_LU_EscalationSubtenant.SelectedItem.Text == "LIBOR Rate Schedule")
            {
                txtPercentage_RateSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Percentage_Rate);
                txtPercentage_RateSubtenant.Enabled = true;
            }
            txtIncreaseSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Increase);
        }
        #endregion

        #region " Bind Rent Projections Information "
        // check if PK for RE_Rent_Projections record is available
        if (_PK_RE_Rent_Projections > 0)
        {
            // create object for RE_Rent_Projections
            RE_Rent_Projections objRE_Rent_Projections = new RE_Rent_Projections(_PK_RE_Rent_Projections);

            // set values in page controls
            txtResponsible_Party.Text = objRE_Rent_Projections.Responsible_Party;
            lblRentProjectionsLeaseCommencementDate.Text = txtLease_Commencement_Date.Text;
            lblRentProjectionsLeaseTerm.Text = txtLease_Term_Months.Text;
            lblRentProjectionsLeaseExpDate.Text = txtLease_Expiration_Date.Text;
            lblRentProjectionsPriorLeaseDate.Text = txtPrior_Lease_Commencement_Date.Text;
            txtCancel_Options.Text = objRE_Rent_Projections.Cancel_Options;
            txtRenew_Options.Text = objRE_Rent_Projections.Renew_Options;
            txtOpen_Notification.Text = objRE_Rent_Projections.Option_Notification;
            txtNotification_Due_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Rent_Projections.Notification_Due_Date);
            txtSubtenant_Base_Rent.Text = clsGeneral.GetStringValue(objRE_Rent_Projections.Subtenant_Base_Rent);
            txtSubtenant_Monthly_Rent.Text = clsGeneral.GetStringValue(objRE_Rent_Projections.Subtenant_Monthly_Rent);
            if (objRE_Rent_Projections.FK_LU_Escalation != null) drpFK_LU_Escalation.SelectedValue = objRE_Rent_Projections.FK_LU_Escalation.ToString();
            if (drpFK_LU_Escalation.SelectedItem.Text == "LIBOR Rate Schedule")
            {
                txtPercentage_Rate.Text = clsGeneral.GetStringValue(objRE_Rent_Projections.Percentage_Rate);
                txtPercentage_Rate.Enabled = true;
            }
            txtIncrease.Text = clsGeneral.GetStringValue(objRE_Rent_Projections.Increase);
        }
        #endregion

        #region " Bind Security Deposit Information "
        // check if PK for RE_Security_Deposit record is available
        if (_PK_RE_Security_Deposit > 0)
        {
            // create object for RE_Security_Deposit record
            RE_Security_Deposit objRE_Security_Deposit = new RE_Security_Deposit(_PK_RE_Security_Deposit);

            // set values in page controls
            txtAmount.Text = clsGeneral.GetStringValue(objRE_Security_Deposit.Amount);
            txtDate_Of_Security_Deposit.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Security_Deposit.Date_Of_Security_Deposit);
            if (objRE_Security_Deposit.FK_LU_Tender_Type != null) drpFK_LU_Tender_Type.SelectedValue = objRE_Security_Deposit.FK_LU_Tender_Type.ToString();
            txtReceived_By.Text = objRE_Security_Deposit.Received_By;
            txtBank_Name.Text = objRE_Security_Deposit.Bank_Name;
            txtCheck_Number.Text = Convert.ToString(objRE_Security_Deposit.Check_Number);
            txtName_On_Check.Text = objRE_Security_Deposit.Name_On_Check;
            txtAccount_Number.Text = Convert.ToString(objRE_Security_Deposit.Account_Number);
            if (objRE_Security_Deposit.FK_LU_Security_Deposit_Held != null) drpFK_LU_Security_Deposit_Held.SelectedValue = objRE_Security_Deposit.FK_LU_Security_Deposit_Held.ToString();
            rdoSecurity_Deposit_Returned.SelectedValue = objRE_Security_Deposit.Security_Deposit_Returned;
            txtDate_Security_Deposit_Returned.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Security_Deposit.Date_Security_Deposit_Returned);
            rdoSecurity_Deposit_Reduced.SelectedValue = objRE_Security_Deposit.Security_Deposit_Reduced;
            txtSecurity_Deposit_Reduction_Reason.Text = objRE_Security_Deposit.Security_Deposit_Reduction_Reason;
            rdoInterest_On_Security_Deposit.SelectedValue = objRE_Security_Deposit.Interest_On_Security_Deposit;
            txtInterest_Amount.Text = clsGeneral.GetStringValue(objRE_Security_Deposit.Interest_Amount);
            txtAmount_Security_Deposit_Returned.Text = clsGeneral.GetStringValue(objRE_Security_Deposit.Amount_Security_Deposit_Returned);
        }
        #endregion

        #region " Bind Surrender Obligations Information "

        // check if PK for RE_Surrender_Obligations record is available
        if (_PK_RE_Surrender_Obligations > 0)
        {
            // create object for RE_Surrender_Obligations record
            RE_Surrender_Obligations objRE_Surrender_Obligations = new RE_Surrender_Obligations(_PK_RE_Surrender_Obligations);

            // set values in page cotnrols
            txtCondition_At_Commencement.Text = objRE_Surrender_Obligations.Condition_At_Commencement;
            txtPermitted_Use.Text = objRE_Surrender_Obligations.Permitted_Use;
            txtAlterations.Text = objRE_Surrender_Obligations.Alterations;
            txtTenants_Obligations.Text = objRE_Surrender_Obligations.Tenants_Obligations;
            txtEnvironmental_Matters.Text = objRE_Surrender_Obligations.Environmental_Matters;
            txtLandlords_Obligations.Text = objRE_Surrender_Obligations.Landlords_Obligations;
        }
        #endregion

        #region " Notices Information "

        // check if PK for RE_Notices record is available
        if (_PK_RE_Notices > 0)
        {
            // create object for RE_Notices record
            RE_Notices objRE_Notices = new RE_Notices(_PK_RE_Notices);

            // set values in page controls
            txtLandlord_Company.Text = objRE_Notices.Landlord_Company;
            txtLandlord_Contact.Text = objRE_Notices.Landlord_Contact;
            txtLandlord_Address1.Text = objRE_Notices.Landlord_Address1;
            txtLandlord_Address2.Text = objRE_Notices.Landlord_Address2;
            txtLandlord_City.Text = objRE_Notices.Landlord_City;
            if (objRE_Notices.FK_State_Landlord != null) drpFK_State_Landlord.SelectedValue = objRE_Notices.FK_State_Landlord.ToString();
            txtLandlord_Zip_Code.Text = objRE_Notices.Landlord_Zip_Code;
            txtLandlord_TelephoneNotices.Text = objRE_Notices.Landlord_Telephone;
            txtLandlord_Facsimile.Text = objRE_Notices.Landlord_Facsimile;
            txtLandlord_EmailNotices.Text = objRE_Notices.Landlord_Email;
            txtLandlord_Copy_Company.Text = objRE_Notices.Landlord_Copy_Company;
            txtLandlord_Copy_Contact.Text = objRE_Notices.Landlord_Copy_Contact;
            txtLandlord_Copy_Address1.Text = objRE_Notices.Landlord_Copy_Address1;
            txtLandlord_Copy_Address2.Text = objRE_Notices.Landlord_Copy_Address2;
            txtLandlord_Copy_City.Text = objRE_Notices.Landlord_Copy_City;
            if (objRE_Notices.FK_State_Landlord_Copy != null) drpFK_State_Landlord_Copy.SelectedValue = objRE_Notices.FK_State_Landlord_Copy.ToString();
            txtLandlord_Copy_Zip_Code.Text = objRE_Notices.Landlord_Copy_Zip_Code;
            txtLandlord_Copy_Telephone.Text = objRE_Notices.Landlord_Copy_Telephone;
            txtLandlord_Copy_Facsimile.Text = objRE_Notices.Landlord_Copy_Facsimile;
            txtLandlord_Copy_Email.Text = objRE_Notices.Landlord_Copy_Email;
            txtTenant_Company.Text = objRE_Notices.Tenant_Company;
            txtTenant_Contact.Text = objRE_Notices.Tenant_Contact;
            txtTenant_Address1.Text = objRE_Notices.Tenant_Address1;
            txtTenant_Address2.Text = objRE_Notices.Tenant_Address2;
            txtTenant_City.Text = objRE_Notices.Tenant_City;
            if (objRE_Notices.FK_State_Tenant != null) drpFK_State_Tenant.SelectedValue = objRE_Notices.FK_State_Tenant.ToString();
            txtTenant_Zip_Code.Text = objRE_Notices.Tenant_Zip_Code;
            txtTenant_Telephone.Text = objRE_Notices.Tenant_Telephone;
            txtTenant_Facsimile.Text = objRE_Notices.Tenant_Facsimile;
            txtTenant_Email.Text = objRE_Notices.Tenant_Email;
            txtTenant_Copy_Company.Text = objRE_Notices.Tenant_Copy_Company;
            txtTenant_Copy_Contact.Text = objRE_Notices.Tenant_Copy_Contact;
            txtTenant_Copy_Address1.Text = objRE_Notices.Tenant_Copy_Address1;
            txtTenant_Copy_Address2.Text = objRE_Notices.Tenant_Copy_Address2;
            txtTenant_Copy_City.Text = objRE_Notices.Tenant_Copy_City;
            if (objRE_Notices.FK_State_Tenant_Copy != null) drpFK_State_Tenant_Copy.SelectedValue = objRE_Notices.FK_State_Tenant_Copy.ToString();
            txtTenant_Copy_Zip_Code.Text = objRE_Notices.Tenant_Copy_Zip_Code;
            txtTenant_Copy_Telephone.Text = objRE_Notices.Tenant_Copy_Telephone;
            txtTenant_Copy_Facsimile.Text = objRE_Notices.Tenant_Copy_Facsimile;
            txtTenant_Copy_Email.Text = objRE_Notices.Tenant_Copy_Email;
            txtSubtenant_Company.Text = objRE_Notices.Subtenant_Company;
            txtSubtenant_Contact.Text = objRE_Notices.Subtenant_Contact;
            txtSubtenant_Address1.Text = objRE_Notices.Subtenant_Address1;
            txtSubtenant_Address2.Text = objRE_Notices.Subtenant_Address2;
            txtSubtenant_City.Text = objRE_Notices.Subtenant_City;
            if (objRE_Notices.FK_State_Subtenant != null) drpFK_State_Subtenant.SelectedValue = objRE_Notices.FK_State_Subtenant.ToString();
            txtSubtenant_Zip_Code.Text = objRE_Notices.Subtenant_Zip_Code;
            txtSubtenant_Telephone.Text = objRE_Notices.Subtenant_Telephone;
            txtSubtenant_Facsimile.Text = objRE_Notices.Subtenant_Facsimile;
            txtSubtenant_Email.Text = objRE_Notices.Subtenant_Email;
            txtSubtenant_Copy_Company.Text = objRE_Notices.Subtenant_Copy_Company;
            txtSubtenant_Copy_Contact.Text = objRE_Notices.Subtenant_Copy_Contact;
            txtSubtenant_Copy_Address1.Text = objRE_Notices.Subtenant_Copy_Address1;
            txtSubtenant_Copy_Address2.Text = objRE_Notices.Subtenant_Copy_Address2;
            txtSubtenant_Copy_City.Text = objRE_Notices.Subtenant_Copy_City;
            if (objRE_Notices.FK_State_Subtenant_Copy != null) drpFK_State_Subtenant_Copy.SelectedValue = objRE_Notices.FK_State_Subtenant_Copy.ToString();
            txtSubtenant_Copy_Zip_Code.Text = objRE_Notices.Subtenant_Copy_Zip_Code;
            txtSubtenant_Copy_Telephone.Text = objRE_Notices.Subtenant_Copy_Telephone;
            txtSubtenant_Copy_Facsimile.Text = objRE_Notices.Subtenant_Copy_Facsimile;
            txtSubtenant_Copy_Email.Text = objRE_Notices.Subtenant_Copy_Email;
        }
        #endregion

    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        // show hide div conrols for edit mode
        dvView.Style["display"] = "block";
        dvBack.Style["display"] = "block";
        dvEdit.Style["display"] = "none";
        dvSave.Style["display"] = "none";

        btnAbstractReport.Visible = false;
        btnAbstractReportView.Visible = true; 

        #region " Bind Real Estate Information "

        // create object for RE_Information record
        RE_Information objRE_Information = new RE_Information(_PK_RE_Information);

        // set values in page controls
        LU_Location objLU_Location = new LU_Location((decimal)objRE_Information.FK_LU_Location);
        lblFK_LU_Location.Text = objLU_Location.dba;
        //lblLegalEntity.Text = objLU_Location.legal_entity;
        lblAddress1.Text = objLU_Location.Address_1;
        lblAddress2.Text = objLU_Location.Address_2;
        lblCity.Text = objLU_Location.City;
        lblState.Text = new State(Convert.ToDecimal(objLU_Location.State)).FLD_state;
        lblZipCode.Text = objLU_Location.Zip_Code;
        lblTelephone.Text = objLU_Location.Dealership_Telephone;
        lblCounty.Text = objLU_Location.County;
        lblRegion.Text = objLU_Location.Region;
        lblFederal_Id.Text = objRE_Information.Federal_Id;
        if (objRE_Information.FK_LU_Status != null) lblFK_LU_Status.Text = new LU_Status((decimal)objRE_Information.FK_LU_Status).Fld_Desc;
        lblTax_Parcel_Number.Text = objRE_Information.Tax_Parcel_Number;
        if (objRE_Information.FK_LU_Lease_Type != null) lblFK_LU_Lease_Type.Text = new LU_Lease_Type((decimal)objRE_Information.FK_LU_Lease_Type).Fld_Desc;
        lblLandlord.Text = objRE_Information.Landlord;
        lblLandlord_Location_Address1.Text = objRE_Information.Landlord_Location_Address1;
        lblLandlord_Location_Address2.Text = objRE_Information.Landlord_Location_Address2;
        lblLandlord_Location_City.Text = objRE_Information.Landlord_Location_City;
        if (objRE_Information.PK_Landlord_Location_State != null) lblLandlordLocationState.Text = new State((decimal)objRE_Information.PK_Landlord_Location_State).FLD_state;
        lblLandlord_Location_Zip_Code.Text = objRE_Information.Landlord_Location_Zip_Code;
        lblLandlord_Mailing_Address1.Text = objRE_Information.Landlord_Mailing_Address1;
        lblLandlord_Mailing_Address2.Text = objRE_Information.Landlord_Mailing_Address2;
        lblLandlord_Mailing_City.Text = objRE_Information.Landlord_Mailing_City;
        if (objRE_Information.PK_Landlord_Mailing_State != null) lblLandlordMailingState.Text = new State((decimal)objRE_Information.PK_Landlord_Mailing_State).FLD_state;
        lblLandlord_Mailing_Zip_Code.Text = objRE_Information.Landlord_Mailing_Zip_Code;
        lblLandlord_Telephone.Text = objRE_Information.Landlord_Telephone;
        lblLandlord_Email.Text = objRE_Information.Landlord_Email;
        lblSublease.Text = objRE_Information.Sublease == "Y" ? "Yes" : "No";
        lblSubtenant.Text = objRE_Information.Subtenant;
        lblLease_Id.Text = objRE_Information.Lease_Id;
        lblLease_Commencement_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Commencement_Date);
        if (objRE_Information.FK_LU_Project_Type != null) lblFK_LU_Project_Type.Text = new LU_Project_Type((decimal)objRE_Information.FK_LU_Project_Type).Fld_Desc;
        lblLease_Expiration_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Expiration_Date);
        lblDate_Acquired.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Date_Acquired);
        lblLease_Term_Months.Text = clsGeneral.GetStringValue(objRE_Information.Lease_Term_Months).Replace(".00", "");
        lblDate_Sold.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Date_Sold);
        lblPrior_Lease_Commencement_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Prior_Lease_Commencement_Date);
        lblRenewals.Text = objRE_Information.Renewals;
        lblYear_Built.Text = Convert.ToString(objRE_Information.Year_Built);
        lblReminder_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Reminder_Date);
        lblYear_Remodeled.Text = Convert.ToString(objRE_Information.Year_Remodeled);
        lblLandlord_Notification_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Landlord_Notification_Date);
        lblRegional_Vice_President.Text = objRE_Information.Regional_Vice_President;
        lblVacate_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Vacate_Date);
        lblGeneral_Manager.Text = objRE_Information.General_Manager;
        lblPrimary_Use.Text = objRE_Information.Primary_Use;
        lblController.Text = objRE_Information.Controller;
        lblLease_Codes.Text = objRE_Information.Lease_Codes;
        lblLoss_Control_Manager.Text = objRE_Information.Loss_Control_Manager;
        lblTotal_Acres.Text = clsGeneral.GetStringValue(objRE_Information.Total_Acres).Replace(".00", "");
        lblNumber_of_Buildings.Text = clsGeneral.GetStringValue(objRE_Information.Number_of_Buildings).Replace(".00", "");
        lblTotal_Gross_Leaseable_Area.Text = clsGeneral.GetStringValue(objRE_Information.Total_Gross_Leaseable_Area).Replace(".00", "");
        lblLand_Value.Text = clsGeneral.GetStringValue(objRE_Information.Land_Value).Replace(".00", "");
        #endregion

        #region " Bind Rent Information "

        // check if PK for RE_Rent_Projections record is available
        if (_PK_RE_Rent > 0)
        {
            // create object for RE_Rent_Projections record
            RE_Rent objRE_Rent_Projections = new RE_Rent(_PK_RE_Rent);

            // set values in page controls
            lblResponsible_PartyRent.Text = objRE_Rent_Projections.Responsible_Party;
            lblRentLeaseCommencementDateView.Text = lblLease_Commencement_Date.Text;
            lblRentLeaseTermView.Text = lblLease_Term_Months.Text;
            lblRentLeaseExpDateView.Text = lblLease_Expiration_Date.Text;
            lblRentPriorLeaseDateView.Text = lblPrior_Lease_Commencement_Date.Text;
            lblCancel_OptionsRent.Text = objRE_Rent_Projections.Cancel_Options;
            lblRenew_OptionsRent.Text = objRE_Rent_Projections.Renew_Options;
            lblNotification_Due_DateRent.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Rent_Projections.Notification_Due_Date);
            lblRentSubtenant_Base_Rent.Text = clsGeneral.GetStringValue(objRE_Rent_Projections.Subtenant_Base_Rent);
            lblRentSubtenant_Monthly_Rent.Text = clsGeneral.GetStringValue(objRE_Rent_Projections.Subtenant_Monthly_Rent);
            if (objRE_Rent_Projections.FK_LU_Escalation != null) lblFK_LU_EscalationRent.Text = new LU_Escalation((decimal)objRE_Rent_Projections.FK_LU_Escalation).Fld_Desc;
            lblPercentage_RateRent.Text = clsGeneral.GetStringValue(objRE_Rent_Projections.Percentage_Rate);
            lblIncreaseRent.Text = clsGeneral.GetStringValue(objRE_Rent_Projections.Increase);
        }
        #endregion

        #region " Bind Subtenant Information "

        // check if PK for RE_Subtenant record is available
        if (_PK_RE_Subtenant > 0)
        {
            // create object for RE_Subtenant record
            RE_Subtenant objRE_Subtenant = new RE_Subtenant(_PK_RE_Subtenant);

            // set values in page controls
            lblSubtenant_DBA.Text = objRE_Subtenant.Subtenant_DBA;
            lblSubtenant_Mailing_Address1.Text = objRE_Subtenant.Subtenant_Mailing_Address1;
            lblSubtenant_Mailing_Address2.Text = objRE_Subtenant.Subtenant_Mailing_Address2;
            lblSubtenant_Mailing_City.Text = objRE_Subtenant.Subtenant_Mailing_City;
            lblSubtenant_Mailing_Zip_Code.Text = objRE_Subtenant.Subtenant_Mailing_Zip_Code;
            if (objRE_Subtenant.PK_Subtenant_Mailing_State != null) lblSubtenantMailingState.Text = new State((decimal)objRE_Subtenant.PK_Subtenant_Mailing_State).FLD_state;
            lblSubtenantTelephone.Text = objRE_Subtenant.Subtenant_Telephone;
            lblSubtenantLeaseCommencementDateView.Text = lblLease_Commencement_Date.Text;
            lblSubtenantLeaseTermView.Text = lblLease_Term_Months.Text;
            lblSubtenantLeaseExpDateView.Text = lblLease_Expiration_Date.Text;
            lblSubtenantPriorLeaseDateView.Text = lblPrior_Lease_Commencement_Date.Text;
            lblCancel_OptionsSubtenant.Text = objRE_Subtenant.Cancel_Options;
            lblRenew_OptionsSubtenant.Text = objRE_Subtenant.Renew_Options;
            lblOpen_NotificationSubtenant.Text = objRE_Subtenant.Option_Notification;
            lblNotification_Due_DateSubtenant.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Subtenant.Notification_Due_Date);
            lblSubtenant_Base_RentSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Subtenant_Base_Rent);
            lblSubtenant_Monthly_RentSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Subtenant_Monthly_Rent);
            if (objRE_Subtenant.FK_LU_Escalation != null) lblFK_LU_EscalationSubtenant.Text = new LU_Escalation((decimal)objRE_Subtenant.FK_LU_Escalation).Fld_Desc;
            lblPercentage_RateSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Percentage_Rate);
            lblIncreaseSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Increase);
        }
        #endregion

        #region " Bind Rent Projections Information "

        // check if PK for RE_Rent_Projections record is available
        if (_PK_RE_Rent_Projections > 0)
        {
            // create object for RE_Rent_Projections record
            RE_Rent_Projections objRE_Rent_Projections = new RE_Rent_Projections(_PK_RE_Rent_Projections);

            // set values in page controls
            lblResponsible_Party.Text = objRE_Rent_Projections.Responsible_Party;
            lblRentProjectionsLeaseCommencementDateView.Text = lblLease_Commencement_Date.Text;
            lblRentProjectionsLeaseTermView.Text = lblLease_Term_Months.Text;
            lblRentProjectionsLeaseExpDateView.Text = lblLease_Expiration_Date.Text;
            lblRentProjectionsPriorLeaseDateView.Text = lblPrior_Lease_Commencement_Date.Text;
            lblCancel_Options.Text = objRE_Rent_Projections.Cancel_Options;
            lblRenew_Options.Text = objRE_Rent_Projections.Renew_Options;
            lblOpen_Notification.Text = objRE_Rent_Projections.Option_Notification;
            lblNotification_Due_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Rent_Projections.Notification_Due_Date);
            lblSubtenant_Base_Rent.Text = clsGeneral.GetStringValue(objRE_Rent_Projections.Subtenant_Base_Rent);
            lblSubtenant_Monthly_Rent.Text = clsGeneral.GetStringValue(objRE_Rent_Projections.Subtenant_Monthly_Rent);
            if (objRE_Rent_Projections.FK_LU_Escalation != null) lblFK_LU_Escalation.Text = new LU_Escalation((decimal)objRE_Rent_Projections.FK_LU_Escalation).Fld_Desc;
            lblPercentage_Rate.Text = clsGeneral.GetStringValue(objRE_Rent_Projections.Percentage_Rate);
            lblIncrease.Text = clsGeneral.GetStringValue(objRE_Rent_Projections.Increase);
        }
        #endregion

        #region " Bind Security Deposit Information "

        // check if PK for RE_Security_Deposit record is available
        if (_PK_RE_Security_Deposit > 0)
        {
            // create object for RE_Security_Deposit record
            RE_Security_Deposit objRE_Security_Deposit = new RE_Security_Deposit(_PK_RE_Security_Deposit);
            // set values in page controls
            lblAmount.Text = clsGeneral.GetStringValue(objRE_Security_Deposit.Amount);
            lblDate_Of_Security_Deposit.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Security_Deposit.Date_Of_Security_Deposit);
            if (objRE_Security_Deposit.FK_LU_Tender_Type != null) lblFK_LU_Tender_Type.Text = new LU_Tender_Type((decimal)objRE_Security_Deposit.FK_LU_Tender_Type).Fld_Desc;
            lblReceived_By.Text = objRE_Security_Deposit.Received_By;
            lblBank_Name.Text = objRE_Security_Deposit.Bank_Name;
            lblCheck_Number.Text = Convert.ToString(objRE_Security_Deposit.Check_Number);
            lblName_On_Check.Text = objRE_Security_Deposit.Name_On_Check;
            lblAccount_Number.Text = Convert.ToString(objRE_Security_Deposit.Account_Number);
            if (objRE_Security_Deposit.FK_LU_Security_Deposit_Held != null) lblFK_LU_Security_Deposit_Held.Text = new LU_Security_Deposit_Held((decimal)objRE_Security_Deposit.FK_LU_Security_Deposit_Held).Fld_Desc;
            lblSecurity_Deposit_Returned.Text = objRE_Security_Deposit.Security_Deposit_Returned == "Y" ? "Yes" : "No";
            lblDate_Security_Deposit_Returned.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Security_Deposit.Date_Security_Deposit_Returned);
            lblSecurity_Deposit_Reduced.Text = objRE_Security_Deposit.Security_Deposit_Reduced == "Y" ? "Yes" : "No";
            lblSecurity_Deposit_Reduction_Reason.Text = objRE_Security_Deposit.Security_Deposit_Reduction_Reason;
            lblInterest_On_Security_Deposit.Text = objRE_Security_Deposit.Interest_On_Security_Deposit == "Y" ? "Yes" : "No";
            lblInterest_Amount.Text = clsGeneral.GetStringValue(objRE_Security_Deposit.Interest_Amount);
            lblAmount_Security_Deposit_Returned.Text = clsGeneral.GetStringValue(objRE_Security_Deposit.Amount_Security_Deposit_Returned);
        }
        #endregion

        #region " Bind Surrender Obligations Information "
        // check if PK for RE_Surrender_Obligations record is available
        if (_PK_RE_Surrender_Obligations > 0)
        {
            // create object for RE_Surrender_Obligations record
            RE_Surrender_Obligations objRE_Surrender_Obligations = new RE_Surrender_Obligations(_PK_RE_Surrender_Obligations);

            // set values in page controls
            lblCondition_At_Commencement.Text = objRE_Surrender_Obligations.Condition_At_Commencement;
            lblPermitted_Use.Text = objRE_Surrender_Obligations.Permitted_Use;
            lblAlterations.Text = objRE_Surrender_Obligations.Alterations;
            lblTenants_Obligations.Text = objRE_Surrender_Obligations.Tenants_Obligations;
            lblEnvironmental_Matters.Text = objRE_Surrender_Obligations.Environmental_Matters;
            lblLandlords_Obligations.Text = objRE_Surrender_Obligations.Landlords_Obligations;
        }
        #endregion

        #region " Notices Information "

        // check if PK for RE_Notices record is available
        if (_PK_RE_Notices > 0)
        {
            // create object for RE_Notices record
            RE_Notices objRE_Notices = new RE_Notices(_PK_RE_Notices);
            // set values in page controls
            lblLandlord_Company.Text = objRE_Notices.Landlord_Company;
            lblLandlord_Contact.Text = objRE_Notices.Landlord_Contact;
            lblLandlord_Address1.Text = objRE_Notices.Landlord_Address1;
            lblLandlord_Address2.Text = objRE_Notices.Landlord_Address2;
            lblLandlord_City.Text = objRE_Notices.Landlord_City;
            if (objRE_Notices.FK_State_Landlord != null) lblFK_State_Landlord.Text = new State((decimal)objRE_Notices.FK_State_Landlord).FLD_state;
            lblLandlord_Zip_Code.Text = objRE_Notices.Landlord_Zip_Code;
            lblLandlord_TelephoneNotices.Text = objRE_Notices.Landlord_Telephone;
            lblLandlord_Facsimile.Text = objRE_Notices.Landlord_Facsimile;
            lblLandlord_EmailNotices.Text = objRE_Notices.Landlord_Email;
            lblLandlord_Copy_Company.Text = objRE_Notices.Landlord_Copy_Company;
            lblLandlord_Copy_Contact.Text = objRE_Notices.Landlord_Copy_Contact;
            lblLandlord_Copy_Address1.Text = objRE_Notices.Landlord_Copy_Address1;
            lblLandlord_Copy_Address2.Text = objRE_Notices.Landlord_Copy_Address2;
            lblLandlord_Copy_City.Text = objRE_Notices.Landlord_Copy_City;
            if (objRE_Notices.FK_State_Landlord_Copy != null) lblFK_State_Landlord_Copy.Text = new State((decimal)objRE_Notices.FK_State_Landlord_Copy).FLD_state;
            lblLandlord_Copy_Zip_Code.Text = objRE_Notices.Landlord_Copy_Zip_Code;
            lblLandlord_Copy_Telephone.Text = objRE_Notices.Landlord_Copy_Telephone;
            lblLandlord_Copy_Facsimile.Text = objRE_Notices.Landlord_Copy_Facsimile;
            lblLandlord_Copy_Email.Text = objRE_Notices.Landlord_Copy_Email;
            lblTenant_Company.Text = objRE_Notices.Tenant_Company;
            lblTenant_Contact.Text = objRE_Notices.Tenant_Contact;
            lblTenant_Address1.Text = objRE_Notices.Tenant_Address1;
            lblTenant_Address2.Text = objRE_Notices.Tenant_Address2;
            lblTenant_City.Text = objRE_Notices.Tenant_City;
            if (objRE_Notices.FK_State_Tenant != null) lblFK_State_Tenant.Text = new State((decimal)objRE_Notices.FK_State_Tenant).FLD_state;
            lblTenant_Zip_Code.Text = objRE_Notices.Tenant_Zip_Code;
            lblTenant_Telephone.Text = objRE_Notices.Tenant_Telephone;
            lblTenant_Facsimile.Text = objRE_Notices.Tenant_Facsimile;
            lblTenant_Email.Text = objRE_Notices.Tenant_Email;
            lblTenant_Copy_Company.Text = objRE_Notices.Tenant_Copy_Company;
            lblTenant_Copy_Contact.Text = objRE_Notices.Tenant_Copy_Contact;
            lblTenant_Copy_Address1.Text = objRE_Notices.Tenant_Copy_Address1;
            lblTenant_Copy_Address2.Text = objRE_Notices.Tenant_Copy_Address2;
            lblTenant_Copy_City.Text = objRE_Notices.Tenant_Copy_City;
            if (objRE_Notices.FK_State_Tenant_Copy != null) lblFK_State_Tenant_Copy.Text = new State((decimal)objRE_Notices.FK_State_Tenant_Copy).FLD_state;
            lblTenant_Copy_Zip_Code.Text = objRE_Notices.Tenant_Copy_Zip_Code;
            lblTenant_Copy_Telephone.Text = objRE_Notices.Tenant_Copy_Telephone;
            lblTenant_Copy_Facsimile.Text = objRE_Notices.Tenant_Copy_Facsimile;
            lblTenant_Copy_Email.Text = objRE_Notices.Tenant_Copy_Email;
            lblSubtenant_Company.Text = objRE_Notices.Subtenant_Company;
            lblSubtenant_Contact.Text = objRE_Notices.Subtenant_Contact;
            lblSubtenant_Address1.Text = objRE_Notices.Subtenant_Address1;
            lblSubtenant_Address2.Text = objRE_Notices.Subtenant_Address2;
            lblSubtenant_City.Text = objRE_Notices.Subtenant_City;
            if (objRE_Notices.FK_State_Subtenant != null) lblFK_State_Subtenant.Text = new State((decimal)objRE_Notices.FK_State_Subtenant).FLD_state;
            lblSubtenant_Zip_Code.Text = objRE_Notices.Subtenant_Zip_Code;
            lblSubtenant_Telephone.Text = objRE_Notices.Subtenant_Telephone;
            lblSubtenant_Facsimile.Text = objRE_Notices.Subtenant_Facsimile;
            lblSubtenant_Email.Text = objRE_Notices.Subtenant_Email;
            lblSubtenant_Copy_Company.Text = objRE_Notices.Subtenant_Copy_Company;
            lblSubtenant_Copy_Contact.Text = objRE_Notices.Subtenant_Copy_Contact;
            lblSubtenant_Copy_Address1.Text = objRE_Notices.Subtenant_Copy_Address1;
            lblSubtenant_Copy_Address2.Text = objRE_Notices.Subtenant_Copy_Address2;
            lblSubtenant_Copy_City.Text = objRE_Notices.Subtenant_Copy_City;
            if (objRE_Notices.FK_State_Subtenant_Copy != null) lblFK_State_Subtenant_Copy.Text = new State((decimal)objRE_Notices.FK_State_Subtenant_Copy).FLD_state;
            lblSubtenant_Copy_Zip_Code.Text = objRE_Notices.Subtenant_Copy_Zip_Code;
            lblSubtenant_Copy_Telephone.Text = objRE_Notices.Subtenant_Copy_Telephone;
            lblSubtenant_Copy_Facsimile.Text = objRE_Notices.Subtenant_Copy_Facsimile;
            lblSubtenant_Copy_Email.Text = objRE_Notices.Subtenant_Copy_Email;
        }
        #endregion

    }

    /// <summary>
    /// Binds the dropdown controls on page 
    /// </summary>
    private void BindDropDowns()
    {
        //// lu location dropdown
        //DataTable dtLocation = LU_Location.SelectAll().Tables[0];
        //dtLocation.DefaultView.RowFilter = "Active='Y'";
        //dtLocation = dtLocation.DefaultView.ToTable();
        //drpLU_Location.DataSource = dtLocation;
        //drpLU_Location.DataTextField = "dba";
        //drpLU_Location.DataValueField = "PK_LU_Location_ID";
        //drpLU_Location.DataBind();
        //drpLU_Location.Items.Insert(0, new ListItem("--Select--", "0"));

        ComboHelper.FillLocationdbaOnly(new DropDownList[] { drpLU_Location }, -1, true);
        drpLU_Location.Style.Remove("font-size");

        //bind status dropdown
        DataTable dtStatus = LU_Status.SelectAll().Tables[0];
        dtStatus.DefaultView.RowFilter = "Active = 'Y'";
        dtStatus = dtStatus.DefaultView.ToTable();
        drpFK_LU_Status.DataSource = dtStatus;
        drpFK_LU_Status.DataTextField = "Fld_Desc";
        drpFK_LU_Status.DataValueField = "PK_LU_Status";
        drpFK_LU_Status.DataBind();
        drpFK_LU_Status.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind lease type dropdown
        DataTable dtLeaseType = LU_Lease_Type.SelectAll().Tables[0];
        dtLeaseType.DefaultView.RowFilter = "Active = 'Y'";
        dtLeaseType = dtLeaseType.DefaultView.ToTable();
        drpFK_LU_Lease_Type.DataSource = dtLeaseType;
        drpFK_LU_Lease_Type.DataTextField = "Fld_Desc";
        drpFK_LU_Lease_Type.DataValueField = "PK_LU_Lease_Type";
        drpFK_LU_Lease_Type.DataBind();
        drpFK_LU_Lease_Type.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind landlord location state dropdown
        DataTable dtState = State.SelectAll().Tables[0];
        drpLandlord_Location_State.DataSource = dtState;
        drpLandlord_Location_State.DataTextField = "FLD_state";
        drpLandlord_Location_State.DataValueField = "PK_ID";
        drpLandlord_Location_State.DataBind();
        drpLandlord_Location_State.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind landlord mailing state dropdown
        drpLandlordMailingState.DataSource = dtState;
        drpLandlordMailingState.DataValueField = "PK_ID";
        drpLandlordMailingState.DataTextField = "FLD_state";
        drpLandlordMailingState.DataBind();
        drpLandlordMailingState.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind project type dropdown
        DataTable dtProjectType = LU_Project_Type.SelectAll().Tables[0];
        dtProjectType.DefaultView.RowFilter = "Active = 'Y'";
        dtProjectType = dtProjectType.DefaultView.ToTable();
        drpFK_LU_Project_Type.DataSource = dtProjectType;
        drpFK_LU_Project_Type.DataTextField = "Fld_Desc";
        drpFK_LU_Project_Type.DataValueField = "PK_LU_Project_Type";
        drpFK_LU_Project_Type.DataBind();
        drpFK_LU_Project_Type.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind Subtenant Mailing  State dropdown
        drpSubtenantMailingState.DataSource = dtState;
        drpSubtenantMailingState.DataValueField = "PK_ID";
        drpSubtenantMailingState.DataTextField = "FLD_state";
        drpSubtenantMailingState.DataBind();
        drpSubtenantMailingState.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind subtenant Escalation dropdown
        DataTable dtEscalation = LU_Escalation.SelectAll().Tables[0];
        drpFK_LU_EscalationSubtenant.DataSource = dtEscalation;
        drpFK_LU_EscalationSubtenant.DataValueField = "PK_LU_Escalation";
        drpFK_LU_EscalationSubtenant.DataTextField = "Fld_Desc";
        drpFK_LU_EscalationSubtenant.DataBind();
        drpFK_LU_EscalationSubtenant.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind rent projection Escalation dropdown
        drpFK_LU_Escalation.DataSource = dtEscalation;
        drpFK_LU_Escalation.DataValueField = "PK_LU_Escalation";
        drpFK_LU_Escalation.DataTextField = "Fld_Desc";
        drpFK_LU_Escalation.DataBind();
        drpFK_LU_Escalation.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind tender type dropdown
        DataTable dtTenderType = LU_Tender_Type.SelectAll().Tables[0];
        drpFK_LU_Tender_Type.DataSource = dtTenderType;
        drpFK_LU_Tender_Type.DataTextField = "Fld_Desc";
        drpFK_LU_Tender_Type.DataValueField = "PK_LU_Tender_Type";
        drpFK_LU_Tender_Type.DataBind();
        drpFK_LU_Tender_Type.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind security deposit dropdown
        DataTable dtSecurityDeposit = LU_Security_Deposit_Held.SelectAll().Tables[0];
        dtSecurityDeposit.DefaultView.RowFilter = "Active = 'Y'";
        dtSecurityDeposit = dtSecurityDeposit.DefaultView.ToTable();
        drpFK_LU_Security_Deposit_Held.DataSource = dtSecurityDeposit;
        drpFK_LU_Security_Deposit_Held.DataTextField = "Fld_Desc";
        drpFK_LU_Security_Deposit_Held.DataValueField = "PK_LU_Security_Deposit_Held";
        drpFK_LU_Security_Deposit_Held.DataBind();
        drpFK_LU_Security_Deposit_Held.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind landlord state dropdown
        drpFK_State_Landlord.DataSource = dtState;
        drpFK_State_Landlord.DataValueField = "PK_ID";
        drpFK_State_Landlord.DataTextField = "FLD_state";
        drpFK_State_Landlord.DataBind();
        drpFK_State_Landlord.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind Landlord copy to state dropdown
        drpFK_State_Landlord_Copy.DataSource = dtState;
        drpFK_State_Landlord_Copy.DataValueField = "PK_ID";
        drpFK_State_Landlord_Copy.DataTextField = "FLD_state";
        drpFK_State_Landlord_Copy.DataBind();
        drpFK_State_Landlord_Copy.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind tenant state dropdown
        drpFK_State_Tenant.DataSource = dtState;
        drpFK_State_Tenant.DataValueField = "PK_ID";
        drpFK_State_Tenant.DataTextField = "FLD_state";
        drpFK_State_Tenant.DataBind();
        drpFK_State_Tenant.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind tenant copy state dropdown
        drpFK_State_Tenant_Copy.DataSource = dtState;
        drpFK_State_Tenant_Copy.DataValueField = "PK_ID";
        drpFK_State_Tenant_Copy.DataTextField = "FLD_state";
        drpFK_State_Tenant_Copy.DataBind();
        drpFK_State_Tenant_Copy.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind subtenant state dropdown
        drpFK_State_Subtenant.DataSource = dtState;
        drpFK_State_Subtenant.DataValueField = "PK_ID";
        drpFK_State_Subtenant.DataTextField = "FLD_state";
        drpFK_State_Subtenant.DataBind();
        drpFK_State_Subtenant.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind subtenant copy state dropdown
        drpFK_State_Subtenant_Copy.DataSource = dtState;
        drpFK_State_Subtenant_Copy.DataValueField = "PK_ID";
        drpFK_State_Subtenant_Copy.DataTextField = "FLD_state";
        drpFK_State_Subtenant_Copy.DataBind();
        drpFK_State_Subtenant_Copy.Items.Insert(0, new ListItem("--Select--", "0"));


    }

    /// <summary>
    /// Binds all the grids on page
    /// </summary>
    private void BindGrids()
    {
        BindTRSRentGrid();
        BindRRSRentGrid();
        BindTRSSubtenantGrid();
        BindORSSubtenantGrid();
        BindTRSRentProjectionGrid();
        BindORSRentProjectionGrid();
        BindRepairMaintenanceGrid();
        BindNotesGrid();
    }

    private void BindTRSRentGrid()
    {
        // get datatable for RE_Rent_Projctions_TRS records
        DataTable dtRentTRS = RE_Rent_TRS.SelectByFK(_PK_RE_Rent).Tables[0];

        // bind the grid as per the page opertation either edit or view 
        if (_StrOperation == "view")
        {
            gvRentTRSView.DataSource = dtRentTRS;
            gvRentTRSView.DataBind();
        }
        else
        {
            gvRentTRS.DataSource = dtRentTRS;
            gvRentTRS.DataBind();

            // show the remove link in the last row only
            if (gvRentTRS.Rows.Count > 0 && App_Access == AccessType.Administrative_Access)
                gvRentTRS.Rows[gvRentTRS.Rows.Count - 1].FindControl("lnkRemove").Visible = true;

            // Check User has not admin right then hide Delete column.
            if (App_Access != AccessType.Administrative_Access)
                gvRentTRS.Columns[gvRentTRS.Columns.Count - 1].Visible = false;
        }
    }

    private void BindRRSRentGrid()
    {
        // get datatable for RE_Rent_Projections_ORS records
        DataTable dtRentRRS = RE_Rent_RRS.SelectByFK(_PK_RE_Rent).Tables[0];

        // bind the grid as per the page opertation either edit or view 
        if (_StrOperation == "view")
        {
            gvRentRRSView.DataSource = dtRentRRS;
            gvRentRRSView.DataBind();
        }
        else
        {
            gvRentRRS.DataSource = dtRentRRS;
            gvRentRRS.DataBind();

            // show the remove link in the last row only
            if (gvRentRRS.Rows.Count > 0 && App_Access == AccessType.Administrative_Access)
                gvRentRRS.Rows[gvRentRRS.Rows.Count - 1].FindControl("lnkRemove").Visible = true;

            // Check User has not admin right then hide Delete column.
            if (App_Access != AccessType.Administrative_Access)
                gvRentRRS.Columns[gvRentRRS.Columns.Count - 1].Visible = false;
        }
    }

    /// <summary>
    /// Binds Term Rent Schedule Grid on Subtenant Information panel
    /// </summary>
    private void BindTRSSubtenantGrid()
    {
        // get datatable for RE_Subtenant_TRS records
        DataTable dtSubtenantTRS = RE_Subtenant_TRS.SelectByFK(_PK_RE_Subtenant).Tables[0];

        // bind the grid as per the page opertation either edit or view 
        if (_StrOperation == "view")
        {
            gvSubtenantTRSView.DataSource = dtSubtenantTRS;
            gvSubtenantTRSView.DataBind();
        }
        else
        {
            gvSubtenantTRS.DataSource = dtSubtenantTRS;
            gvSubtenantTRS.DataBind();

            // show the remove link in the last row only
            if (gvSubtenantTRS.Rows.Count > 0)
                gvSubtenantTRS.Rows[gvSubtenantTRS.Rows.Count - 1].FindControl("lnkRemove").Visible = true;

            // Check User has not admin right then hide Delete column.
            if (App_Access != AccessType.Administrative_Access)
                gvSubtenantTRS.Columns[gvSubtenantTRS.Columns.Count - 1].Visible = false;
        }
    }

    /// <summary>
    /// Binds Option Rent Schedule Grid on Subtenant Information panel
    /// </summary>
    private void BindORSSubtenantGrid()
    {
        // get datatable for RE_SubTenant_ORS records
        DataTable dtSubtenantORS = RE_SubTenant_ORS.SelectByFK(_PK_RE_Subtenant).Tables[0];

        // bind the grid as per the page opertation either edit or view 
        if (_StrOperation == "view")
        {
            gvSubtenantORSView.DataSource = dtSubtenantORS;
            gvSubtenantORSView.DataBind();
        }
        else
        {
            gvSubtenantORS.DataSource = dtSubtenantORS;
            gvSubtenantORS.DataBind();

            // show the remove link in the last row only
            if (gvSubtenantORS.Rows.Count > 0 && App_Access == AccessType.Administrative_Access)
                gvSubtenantORS.Rows[gvSubtenantORS.Rows.Count - 1].FindControl("lnkRemove").Visible = true;

            // Check User has not admin right then hide Delete column.
            if (App_Access != AccessType.Administrative_Access)
                gvSubtenantORS.Columns[gvSubtenantORS.Columns.Count - 1].Visible = false;
        }
    }

    /// <summary>
    /// Binds Term Rent Schedule Grid on Rent Projections panel
    /// </summary>
    private void BindTRSRentProjectionGrid()
    {
        // get datatable for RE_Rent_Projctions_TRS records
        DataTable dtRentProjTRS = RE_Rent_Projctions_TRS.SelectByFK(_PK_RE_Rent_Projections).Tables[0];

        // bind the grid as per the page opertation either edit or view 
        if (_StrOperation == "view")
        {
            gvRentProjectionTRSView.DataSource = dtRentProjTRS;
            gvRentProjectionTRSView.DataBind();
        }
        else
        {
            gvRentProjectionTRS.DataSource = dtRentProjTRS;
            gvRentProjectionTRS.DataBind();

            // show the remove link in the last row only
            if (gvRentProjectionTRS.Rows.Count > 0 && App_Access == AccessType.Administrative_Access)
                gvRentProjectionTRS.Rows[gvRentProjectionTRS.Rows.Count - 1].FindControl("lnkRemove").Visible = true;

            // Check User has not admin right then hide Delete column.
            if (App_Access != AccessType.Administrative_Access)
                gvRentProjectionTRS.Columns[gvRentProjectionTRS.Columns.Count - 1].Visible = false;
        }
    }

    /// <summary>
    /// Binds Option Rent Schedule Grid on Rent Projections panel
    /// </summary>  
    private void BindORSRentProjectionGrid()
    {
        // get datatable for RE_Rent_Projections_ORS records
        DataTable dtRentProjORS = RE_Rent_Projections_ORS.SelectByFK(_PK_RE_Rent_Projections).Tables[0];

        // bind the grid as per the page opertation either edit or view 
        if (_StrOperation == "view")
        {
            gvRentProjectionORSView.DataSource = dtRentProjORS;
            gvRentProjectionORSView.DataBind();
        }
        else
        {
            gvRentProjectionORS.DataSource = dtRentProjORS;
            gvRentProjectionORS.DataBind();

            // show the remove link in the last row only
            if (gvRentProjectionORS.Rows.Count > 0 && App_Access == AccessType.Administrative_Access)
                gvRentProjectionORS.Rows[gvRentProjectionORS.Rows.Count - 1].FindControl("lnkRemove").Visible = true;

            // Check User has not admin right then hide Delete column.
            if (App_Access != AccessType.Administrative_Access)
                gvRentProjectionORS.Columns[gvRentProjectionORS.Columns.Count - 1].Visible = false;
        }
    }

    /// <summary>
    /// Bind the Repair Maintenance grid
    /// </summary>
    private void BindRepairMaintenanceGrid()
    {
        // get datatable for RE_Repair_Maintenance records
        DataTable dtRepairMaint = RE_Repair_Maintenance.SelectByFK(_PK_RE_Information).Tables[0];

        // bind the grid as per the page operation either edit or view
        if (_StrOperation == "view")
        {
            gvRepairMaintenanceView.DataSource = dtRepairMaint;
            gvRepairMaintenanceView.DataBind();
            if (dtRepairMaint.Rows.Count == 0)
                gvRepairMaintenanceView.Width = new Unit(600);
        }
        else
        {
            gvRepairMaintenance.DataSource = dtRepairMaint;
            gvRepairMaintenance.DataBind();
            if (dtRepairMaint.Rows.Count == 0)
                gvRepairMaintenance.Width = new Unit(600);

            // Check User has not admin right then hide Delete column.
            if (App_Access != AccessType.Administrative_Access)
                gvRepairMaintenance.Columns[gvRepairMaintenance.Columns.Count - 1].Visible = false;
        }
    }

    /// <summary>
    /// Bind the Notes grid
    /// </summary>
    private void BindNotesGrid()
    {
        // get datatble for RE_Notes record
        DataTable dtNotes = RE_Notes.SeleteByFK(_PK_RE_Information).Tables[0];

        // bind the grid as per the page operation either edit or view
        if (_StrOperation == "view")
        {
            gvNotesView.DataSource = dtNotes;
            gvNotesView.DataBind();
        }
        else
        {
            gvNotes.DataSource = dtNotes;
            gvNotes.DataBind();

            // Check User has not admin right then hide Delete column.
            if (App_Access != AccessType.Administrative_Access)
                gvNotes.Columns[gvNotes.Columns.Count - 1].Visible = false;
        }
    }

    /// <summary>
    /// Calls javasript function to display perticular panel
    /// </summary>
    /// <param name="intPanelNumber"></param>
    private void ShowPanel(int intPanelNumber)
    {
        if (!Page.IsPostBack)
            ScriptManager.RegisterStartupScript(Page, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + intPanelNumber + ");", true);
        else
            ScriptManager.RegisterClientScriptBlock(Page, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + intPanelNumber + ");", true);
    }

    /// <summary>
    /// Saves the page data
    /// </summary>
    private void SaveData(int intControlEvent,string strRedirectToAfterSave)
    {
        if ((gvSubtenantORS.Rows.Count > 0 || gvSubtenantTRS.Rows.Count > 0 || gvRentProjectionORS.Rows.Count > 0 || gvRentProjectionTRS.Rows.Count > 0) && txtLease_Commencement_Date.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "alert('Please enter the [Real Estate Information]/Lease Commencement Date in order to manage the Rent schedule grid records.');ShowPanel(1);", true);
        }
        else
        {
            #region " Save Real Estate Information "
            // create object for the RE_Information
            RE_Information objRE_Information = new RE_Information();

            // get values from page controls
            objRE_Information.PK_RE_Information = _PK_RE_Information;
            objRE_Information.FK_LU_Location = Convert.ToDecimal(drpLU_Location.SelectedValue);
            //objRE_Information.FK_LU_Location = Convert.ToDecimal(hdnLU_location.Value);
            objRE_Information.Federal_Id = txtFederal_Id.Text.Trim();
            if (drpFK_LU_Status.SelectedIndex > 0) objRE_Information.FK_LU_Status = Convert.ToDecimal(drpFK_LU_Status.SelectedValue);
            objRE_Information.Tax_Parcel_Number = txtTax_Parcel_Number.Text.Trim();
            if (drpFK_LU_Lease_Type.SelectedIndex > 0) objRE_Information.FK_LU_Lease_Type = Convert.ToDecimal(drpFK_LU_Lease_Type.SelectedValue);
            objRE_Information.Landlord = txtLandlord.Text.Trim();
            objRE_Information.Landlord_Location_Address1 = txtLandlord_Location_Address1.Text.Trim();
            objRE_Information.Landlord_Location_Address2 = txtLandlord_Location_Address2.Text.Trim();
            objRE_Information.Landlord_Location_City = txtLandlord_Location_City.Text.Trim();
            if (drpLandlord_Location_State.SelectedIndex > 0) objRE_Information.PK_Landlord_Location_State = Convert.ToDecimal(drpLandlord_Location_State.SelectedValue);
            objRE_Information.Landlord_Location_Zip_Code = txtLandlord_Location_Zip_Code.Text.Trim();
            objRE_Information.Landlord_Mailing_Address1 = txtLandlord_Mailing_Address1.Text.Trim();
            objRE_Information.Landlord_Mailing_Address2 = txtLandlord_Mailing_Address2.Text.Trim();
            objRE_Information.Landlord_Mailing_City = txtLandlord_Mailing_City.Text.Trim();
            if (drpLandlordMailingState.SelectedIndex > 0) objRE_Information.PK_Landlord_Mailing_State = Convert.ToDecimal(drpLandlordMailingState.SelectedValue);
            objRE_Information.Landlord_Mailing_Zip_Code = txtLandlord_Mailing_Zip_Code.Text.Trim();
            objRE_Information.Landlord_Telephone = txtLandlord_Telephone.Text.Trim();
            objRE_Information.Landlord_Email = txtLandlord_Email.Text.Trim();
            objRE_Information.Sublease = rdoSublease.SelectedValue;
            objRE_Information.Subtenant = txtSubtenant.Text.Trim();
            objRE_Information.Lease_Id = txtLease_Id.Text.Trim();
            objRE_Information.Lease_Commencement_Date = clsGeneral.FormatNullDateToStore(txtLease_Commencement_Date.Text);
            if (drpFK_LU_Project_Type.SelectedIndex > 0) objRE_Information.FK_LU_Project_Type = Convert.ToDecimal(drpFK_LU_Project_Type.SelectedValue);
            objRE_Information.Lease_Expiration_Date = clsGeneral.FormatNullDateToStore(txtLease_Expiration_Date.Text);
            objRE_Information.Date_Acquired = clsGeneral.FormatNullDateToStore(txtDate_Acquired.Text);
            if (txtLease_Term_Months.Text != "") objRE_Information.Lease_Term_Months = clsGeneral.GetDecimalValue(txtLease_Term_Months);
            objRE_Information.Date_Sold = clsGeneral.FormatNullDateToStore(txtDate_Sold.Text);
            objRE_Information.Prior_Lease_Commencement_Date = clsGeneral.FormatNullDateToStore(txtPrior_Lease_Commencement_Date.Text);
            objRE_Information.Renewals = txtRenewals.Text.Trim();
            if (txtYear_Built.Text != "") objRE_Information.Year_Built = clsGeneral.GetDecimalValue(txtYear_Built);
            objRE_Information.Reminder_Date = clsGeneral.FormatNullDateToStore(txtReminder_Date.Text);
            if (txtYear_Remodeled.Text != string.Empty) objRE_Information.Year_Remodeled = clsGeneral.GetDecimalValue(txtYear_Remodeled);
            objRE_Information.Landlord_Notification_Date = clsGeneral.FormatNullDateToStore(txtLandlord_Notification_Date.Text);
            objRE_Information.Regional_Vice_President = txtRegional_Vice_President.Text.Trim();
            objRE_Information.Vacate_Date = clsGeneral.FormatNullDateToStore(txtVacate_Date.Text);
            objRE_Information.General_Manager = txtGeneral_Manager.Text.Trim();
            objRE_Information.Primary_Use = txtPrimary_Use.Text.Trim();
            objRE_Information.Controller = txtController.Text.Trim();
            objRE_Information.Lease_Codes = txtLease_Codes.Text.Trim();
            objRE_Information.Loss_Control_Manager = txtLoss_Control_Manager.Text.Trim();
            if (txtTotal_Acres.Text != "") objRE_Information.Total_Acres = clsGeneral.GetDecimalValue(txtTotal_Acres);
            if (txtNumber_of_Buildings.Text != "") objRE_Information.Number_of_Buildings = clsGeneral.GetDecimalValue(txtNumber_of_Buildings);
            if (txtTotal_Gross_Leaseable_Area.Text != "") objRE_Information.Total_Gross_Leaseable_Area = clsGeneral.GetDecimalValue(txtTotal_Gross_Leaseable_Area);
            if (txtLand_Value.Text != "") objRE_Information.Land_Value = clsGeneral.GetDecimalValue(txtLand_Value);
            objRE_Information.Update_Date = DateTime.Now;
            objRE_Information.Updated_By = clsSession.UserID;

            // save the information as per the PK availability
            if (_PK_RE_Information > 0)
                objRE_Information.Update();
            else
                _PK_RE_Information = objRE_Information.Insert();

            #endregion

            #region " Save Rent Information "

            // create object for RE_Rent record
            RE_Rent objRE_Rent = new RE_Rent();

            // set PK and FK
            objRE_Rent.PK_RE_Rent = _PK_RE_Rent;
            objRE_Rent.FK_RE_Information = _PK_RE_Information;

            // get values from page controls
            objRE_Rent.Responsible_Party = txtResponsible_PartyRent.Text.Trim();
            objRE_Rent.Cancel_Options = txtCancel_OptionsRent.Text.Trim();
            objRE_Rent.Renew_Options = txtRenew_OptionsRent.Text.Trim();
            objRE_Rent.Notification_Due_Date = clsGeneral.FormatNullDateToStore(txtNotification_Due_DateRent.Text);
            if (txtSubtenant_Base_Rent.Text != "") objRE_Rent.Subtenant_Base_Rent = clsGeneral.GetDecimalValue(txtRentSubtenant_Base_Rent);
            if (txtSubtenant_Monthly_Rent.Text != "") objRE_Rent.Subtenant_Monthly_Rent = clsGeneral.GetDecimalValue(txtRentSubtenant_Monthly_Rent);
            if (drpFK_LU_Escalation.SelectedIndex > 0) objRE_Rent.FK_LU_Escalation = Convert.ToDecimal(drpFK_LU_EscalationRent.SelectedValue);
            if (txtPercentage_Rate.Text != "") objRE_Rent.Percentage_Rate = clsGeneral.GetDecimalValue(txtPercentage_RateRent);
            if (txtIncrease.Text != "") objRE_Rent.Increase = clsGeneral.GetDecimalValue(txtIncreaseRent);
            objRE_Rent.Update_Date = DateTime.Now;
            objRE_Rent.Updated_By = clsSession.UserID;

            // save record as per the PK availability
            if (_PK_RE_Rent > 0)
                objRE_Rent.Update();
            else
                _PK_RE_Rent = objRE_Rent.Insert();

            // update the Rent Schedule inforamtion from grids
            bool bRentSuccess = UpdateRentScheduleInfo_Rent();

            #endregion

            #region " Save Subtenant Information "

            // create object for RE_Subtenant record
            RE_Subtenant objRE_Subtenant = new RE_Subtenant();

            // set FK and PK
            objRE_Subtenant.PK_RE_Subtenant = _PK_RE_Subtenant;
            objRE_Subtenant.FK_RE_Information = _PK_RE_Information;

            // get values from page controls
            objRE_Subtenant.Subtenant_DBA = txtSubtenant_DBA.Text.Trim();
            objRE_Subtenant.Subtenant_Mailing_Address1 = txtSubtenant_Mailing_Address1.Text.Trim();
            objRE_Subtenant.Subtenant_Mailing_Address2 = txtSubtenant_Mailing_Address2.Text.Trim();
            objRE_Subtenant.Subtenant_Mailing_City = txtSubtenant_Mailing_City.Text.Trim();
            if (drpSubtenantMailingState.SelectedIndex > 0) objRE_Subtenant.PK_Subtenant_Mailing_State = Convert.ToDecimal(drpSubtenantMailingState.SelectedValue);
            objRE_Subtenant.Subtenant_Mailing_Zip_Code = txtSubtenant_Mailing_Zip_Code.Text.Trim();
            objRE_Subtenant.Subtenant_Telephone = txtSubtenantTelephone.Text.Trim();
            objRE_Subtenant.Cancel_Options = txtCancel_OptionsSubtenant.Text.Trim();
            objRE_Subtenant.Renew_Options = txtRenew_OptionsSubtenant.Text.Trim();
            objRE_Subtenant.Option_Notification = txtOpen_NotificationSubtenant.Text.Trim();
            objRE_Subtenant.Notification_Due_Date = clsGeneral.FormatNullDateToStore(txtNotification_Due_DateSubtenant.Text);
            if (txtSubtenant_Base_RentSubtenant.Text != "") objRE_Subtenant.Subtenant_Base_Rent = clsGeneral.GetDecimalValue(txtSubtenant_Base_RentSubtenant);
            if (txtSubtenant_Monthly_RentSubtenant.Text != "") objRE_Subtenant.Subtenant_Monthly_Rent = clsGeneral.GetDecimalValue(txtSubtenant_Monthly_RentSubtenant);
            if (drpFK_LU_EscalationSubtenant.SelectedIndex > 0) objRE_Subtenant.FK_LU_Escalation = Convert.ToDecimal(drpFK_LU_EscalationSubtenant.SelectedValue);
            if (txtPercentage_RateSubtenant.Text != "") objRE_Subtenant.Percentage_Rate = clsGeneral.GetDecimalValue(txtPercentage_RateSubtenant);
            if (txtIncreaseSubtenant.Text != "") objRE_Subtenant.Increase = clsGeneral.GetDecimalValue(txtIncreaseSubtenant);
            objRE_Subtenant.Update_Date = DateTime.Now;
            objRE_Subtenant.Updated_By = clsSession.UserID;

            // save record as per the PK availability
            if (_PK_RE_Subtenant > 0)
                objRE_Subtenant.Update();
            else
                _PK_RE_Subtenant = objRE_Subtenant.Insert();

            // update the Rent Schedule information from the grids
            bool bRentSubtenantSuccess = UpdateRentScheduleInfo_Subtenant();

            #endregion

            #region " Save Rent Projections Information "

            // create object for RE_Rent_Projections record
            RE_Rent_Projections objRE_Rent_Projections = new RE_Rent_Projections();

            // set PK and FK
            objRE_Rent_Projections.PK_RE_Rent_Projections = _PK_RE_Rent_Projections;
            objRE_Rent_Projections.FK_RE_Information = _PK_RE_Information;

            // get values from page controls
            objRE_Rent_Projections.Responsible_Party = txtResponsible_Party.Text.Trim();
            objRE_Rent_Projections.Cancel_Options = txtCancel_Options.Text.Trim();
            objRE_Rent_Projections.Renew_Options = txtRenew_Options.Text.Trim();
            objRE_Rent_Projections.Option_Notification = txtOpen_Notification.Text.Trim();
            objRE_Rent_Projections.Notification_Due_Date = clsGeneral.FormatNullDateToStore(txtNotification_Due_Date.Text);
            if (txtSubtenant_Base_Rent.Text != "") objRE_Rent_Projections.Subtenant_Base_Rent = clsGeneral.GetDecimalValue(txtSubtenant_Base_Rent);
            if (txtSubtenant_Monthly_Rent.Text != "") objRE_Rent_Projections.Subtenant_Monthly_Rent = clsGeneral.GetDecimalValue(txtSubtenant_Monthly_Rent);
            if (drpFK_LU_Escalation.SelectedIndex > 0) objRE_Rent_Projections.FK_LU_Escalation = Convert.ToDecimal(drpFK_LU_Escalation.SelectedValue);
            if (txtPercentage_Rate.Text != "") objRE_Rent_Projections.Percentage_Rate = clsGeneral.GetDecimalValue(txtPercentage_Rate);
            if (txtIncrease.Text != "") objRE_Rent_Projections.Increase = clsGeneral.GetDecimalValue(txtIncrease);
            objRE_Rent_Projections.Update_Date = DateTime.Now;
            objRE_Rent_Projections.Updated_By = clsSession.UserID;

            // save record as per the PK availability
            if (_PK_RE_Rent_Projections > 0)
                objRE_Rent_Projections.Update();
            else
                _PK_RE_Rent_Projections = objRE_Rent_Projections.Insert();

            // update the Rent Schedule inforamtion from grids
            bool bRentProjectionSuccess = UpdateRentScheduleInfo_RentProjection();

            #endregion

            #region " Save Security Deposit Information "

            // create object for RE_Security_Deposit record "
            RE_Security_Deposit objRE_Security_Deposit = new RE_Security_Deposit();

            // set PK and FK
            objRE_Security_Deposit.PK_RE_Security_Deposit = _PK_RE_Security_Deposit;
            objRE_Security_Deposit.FK_RE_Information = _PK_RE_Information;

            // get values from page controls
            if (txtAmount.Text != "") objRE_Security_Deposit.Amount = clsGeneral.GetDecimalValue(txtAmount);
            objRE_Security_Deposit.Date_Of_Security_Deposit = clsGeneral.FormatNullDateToStore(txtDate_Of_Security_Deposit.Text);
            if (drpFK_LU_Tender_Type.SelectedIndex > 0) objRE_Security_Deposit.FK_LU_Tender_Type = Convert.ToDecimal(drpFK_LU_Tender_Type.SelectedValue);
            objRE_Security_Deposit.Received_By = txtReceived_By.Text.Trim();
            objRE_Security_Deposit.Bank_Name = txtBank_Name.Text.Trim();
            if (txtCheck_Number.Text != "") objRE_Security_Deposit.Check_Number = clsGeneral.GetDecimalValue(txtCheck_Number);
            objRE_Security_Deposit.Name_On_Check = txtName_On_Check.Text.Trim();
            if (txtAccount_Number.Text != "") objRE_Security_Deposit.Account_Number = clsGeneral.GetDecimalValue(txtAccount_Number);
            if (drpFK_LU_Security_Deposit_Held.SelectedIndex > 0) objRE_Security_Deposit.FK_LU_Security_Deposit_Held = Convert.ToDecimal(drpFK_LU_Security_Deposit_Held.SelectedValue);
            objRE_Security_Deposit.Security_Deposit_Returned = rdoSecurity_Deposit_Returned.SelectedValue;
            objRE_Security_Deposit.Date_Security_Deposit_Returned = clsGeneral.FormatNullDateToStore(txtDate_Security_Deposit_Returned.Text);
            objRE_Security_Deposit.Security_Deposit_Reduced = rdoSecurity_Deposit_Reduced.SelectedValue;
            objRE_Security_Deposit.Security_Deposit_Reduction_Reason = txtSecurity_Deposit_Reduction_Reason.Text.Trim();
            objRE_Security_Deposit.Interest_On_Security_Deposit = rdoInterest_On_Security_Deposit.SelectedValue;
            if (txtInterest_Amount.Text != "") objRE_Security_Deposit.Interest_Amount = clsGeneral.GetDecimalValue(txtInterest_Amount);
            if (txtAmount_Security_Deposit_Returned.Text != "") objRE_Security_Deposit.Amount_Security_Deposit_Returned = clsGeneral.GetDecimalValue(txtAmount_Security_Deposit_Returned);
            objRE_Security_Deposit.Update_Date = DateTime.Now;
            objRE_Security_Deposit.Updated_By = clsSession.UserID;

            // update the record as per the PK availabilty
            if (_PK_RE_Security_Deposit > 0)
                objRE_Security_Deposit.Update();
            else
                _PK_RE_Security_Deposit = objRE_Security_Deposit.Insert();

            #endregion

            #region " Save Surrender Obligations Information "

            // create object for RE_Surrender_Obligations record
            RE_Surrender_Obligations objRE_Surrender_Obligations = new RE_Surrender_Obligations();

            // set PK and FK
            objRE_Surrender_Obligations.PK_RE_Surrender_Obligations = _PK_RE_Surrender_Obligations;
            objRE_Surrender_Obligations.FK_RE_Information = _PK_RE_Information;

            // get values from page controls
            objRE_Surrender_Obligations.Condition_At_Commencement = txtCondition_At_Commencement.Text.Trim();
            objRE_Surrender_Obligations.Permitted_Use = txtPermitted_Use.Text.Trim();
            objRE_Surrender_Obligations.Alterations = txtAlterations.Text.Trim();
            objRE_Surrender_Obligations.Tenants_Obligations = txtTenants_Obligations.Text.Trim();
            objRE_Surrender_Obligations.Environmental_Matters = txtEnvironmental_Matters.Text.Trim();
            objRE_Surrender_Obligations.Landlords_Obligations = txtLandlords_Obligations.Text.Trim();
            objRE_Surrender_Obligations.Update_Date = DateTime.Now;
            objRE_Surrender_Obligations.Updated_By = clsSession.UserID;

            // save the record as per the PK availability
            if (_PK_RE_Surrender_Obligations > 0)
                objRE_Surrender_Obligations.Update();
            else
                _PK_RE_Surrender_Obligations = objRE_Surrender_Obligations.Insert();

            #endregion

            #region " Save Notices Information "

            // create object for the RE_Notices record
            RE_Notices objRE_Notices = new RE_Notices();

            // set PK and FK
            objRE_Notices.PK_RE_Notices = _PK_RE_Notices;
            objRE_Notices.FK_RE_Information = _PK_RE_Information;

            // get values from page controls
            objRE_Notices.Landlord_Company = txtLandlord_Company.Text.Trim();
            objRE_Notices.Landlord_Contact = txtLandlord_Contact.Text.Trim();
            objRE_Notices.Landlord_Address1 = txtLandlord_Address1.Text.Trim();
            objRE_Notices.Landlord_Address2 = txtLandlord_Address2.Text.Trim();
            objRE_Notices.Landlord_City = txtLandlord_City.Text.Trim();
            if (drpFK_State_Landlord.SelectedIndex > 0) objRE_Notices.FK_State_Landlord = Convert.ToDecimal(drpFK_State_Landlord.SelectedValue);
            objRE_Notices.Landlord_Zip_Code = txtLandlord_Zip_Code.Text.Trim();
            objRE_Notices.Landlord_Telephone = txtLandlord_TelephoneNotices.Text.Trim();
            objRE_Notices.Landlord_Facsimile = txtLandlord_Facsimile.Text.Trim();
            objRE_Notices.Landlord_Email = txtLandlord_EmailNotices.Text.Trim();
            objRE_Notices.Landlord_Copy_Company = txtLandlord_Copy_Company.Text.Trim();
            objRE_Notices.Landlord_Copy_Contact = txtLandlord_Copy_Contact.Text.Trim();
            objRE_Notices.Landlord_Copy_Address1 = txtLandlord_Copy_Address1.Text.Trim();
            objRE_Notices.Landlord_Copy_Address2 = txtLandlord_Copy_Address2.Text.Trim();
            objRE_Notices.Landlord_Copy_City = txtLandlord_Copy_City.Text.Trim();
            if (drpFK_State_Landlord_Copy.SelectedIndex > 0) objRE_Notices.FK_State_Landlord_Copy = Convert.ToDecimal(drpFK_State_Landlord_Copy.SelectedValue);
            objRE_Notices.Landlord_Copy_Zip_Code = txtLandlord_Copy_Zip_Code.Text.Trim();
            objRE_Notices.Landlord_Copy_Telephone = txtLandlord_Copy_Telephone.Text.Trim();
            objRE_Notices.Landlord_Copy_Facsimile = txtLandlord_Copy_Facsimile.Text.Trim();
            objRE_Notices.Landlord_Copy_Email = txtLandlord_Copy_Email.Text.Trim();
            objRE_Notices.Tenant_Company = txtTenant_Company.Text.Trim();
            objRE_Notices.Tenant_Contact = txtTenant_Contact.Text.Trim();
            objRE_Notices.Tenant_Address1 = txtTenant_Address1.Text.Trim();
            objRE_Notices.Tenant_Address2 = txtTenant_Address2.Text.Trim();
            objRE_Notices.Tenant_City = txtTenant_City.Text.Trim();
            if (drpFK_State_Tenant.SelectedIndex > 0) objRE_Notices.FK_State_Tenant = Convert.ToDecimal(drpFK_State_Tenant.SelectedValue);
            objRE_Notices.Tenant_Zip_Code = txtTenant_Zip_Code.Text.Trim();
            objRE_Notices.Tenant_Telephone = txtTenant_Telephone.Text.Trim();
            objRE_Notices.Tenant_Facsimile = txtTenant_Facsimile.Text.Trim();
            objRE_Notices.Tenant_Email = txtTenant_Email.Text.Trim();
            objRE_Notices.Tenant_Copy_Company = txtTenant_Copy_Company.Text.Trim();
            objRE_Notices.Tenant_Copy_Contact = txtTenant_Copy_Contact.Text.Trim();
            objRE_Notices.Tenant_Copy_Address1 = txtTenant_Copy_Address1.Text.Trim();
            objRE_Notices.Tenant_Copy_Address2 = txtTenant_Copy_Address2.Text.Trim();
            objRE_Notices.Tenant_Copy_City = txtTenant_Copy_City.Text.Trim();
            if (drpFK_State_Tenant_Copy.SelectedIndex > 0) objRE_Notices.FK_State_Tenant_Copy = Convert.ToDecimal(drpFK_State_Tenant_Copy.SelectedValue);
            objRE_Notices.Tenant_Copy_Zip_Code = txtTenant_Copy_Zip_Code.Text.Trim();
            objRE_Notices.Tenant_Copy_Telephone = txtTenant_Copy_Telephone.Text.Trim();
            objRE_Notices.Tenant_Copy_Facsimile = txtTenant_Copy_Facsimile.Text.Trim();
            objRE_Notices.Tenant_Copy_Email = txtTenant_Copy_Email.Text.Trim();
            objRE_Notices.Subtenant_Company = txtSubtenant_Company.Text.Trim();
            objRE_Notices.Subtenant_Contact = txtSubtenant_Contact.Text.Trim();
            objRE_Notices.Subtenant_Address1 = txtSubtenant_Address1.Text.Trim();
            objRE_Notices.Subtenant_Address2 = txtSubtenant_Address2.Text.Trim();
            objRE_Notices.Subtenant_City = txtSubtenant_City.Text.Trim();
            if (drpFK_State_Subtenant.SelectedIndex > 0) objRE_Notices.FK_State_Subtenant = Convert.ToDecimal(drpFK_State_Subtenant.SelectedValue);
            objRE_Notices.Subtenant_Zip_Code = txtSubtenant_Zip_Code.Text.Trim();
            objRE_Notices.Subtenant_Telephone = txtSubtenant_Telephone.Text.Trim();
            objRE_Notices.Subtenant_Facsimile = txtSubtenant_Facsimile.Text.Trim();
            objRE_Notices.Subtenant_Email = txtSubtenant_Email.Text.Trim();
            objRE_Notices.Subtenant_Copy_Company = txtSubtenant_Copy_Company.Text.Trim();
            objRE_Notices.Subtenant_Copy_Contact = txtSubtenant_Copy_Contact.Text.Trim();
            objRE_Notices.Subtenant_Copy_Address1 = txtSubtenant_Copy_Address1.Text.Trim();
            objRE_Notices.Subtenant_Copy_Address2 = txtSubtenant_Copy_Address2.Text.Trim();
            objRE_Notices.Subtenant_Copy_City = txtSubtenant_Copy_City.Text.Trim();
            if (drpFK_State_Subtenant_Copy.SelectedIndex > 0) objRE_Notices.FK_State_Subtenant_Copy = Convert.ToDecimal(drpFK_State_Subtenant_Copy.SelectedValue);
            objRE_Notices.Subtenant_Copy_Zip_Code = txtSubtenant_Copy_Zip_Code.Text.Trim();
            objRE_Notices.Subtenant_Copy_Telephone = txtSubtenant_Copy_Telephone.Text.Trim();
            objRE_Notices.Subtenant_Copy_Facsimile = txtSubtenant_Copy_Facsimile.Text.Trim();
            objRE_Notices.Subtenant_Copy_Email = txtSubtenant_Copy_Email.Text.Trim();
            objRE_Notices.Update_Date = DateTime.Now;
            objRE_Notices.Updated_By = clsSession.UserID;

            // save the record as per the PK availability
            if (_PK_RE_Notices > 0)
                objRE_Notices.Update();
            else
                _PK_RE_Notices = objRE_Notices.Insert();

            #endregion

            // add attachment if any.
            Attachment.Add(clsGeneral.Tables.RE_Information, (int)_PK_RE_Information);

            // set PK value in session
            clsSession.Current_RE_Information_ID = _PK_RE_Information;

            string strError = "";

            if (!bRentSuccess) strError = "RentError";
            if (!bRentSubtenantSuccess) strError = "SubtenantError";
            if (!bRentProjectionSuccess) strError = "RentProjectionError";            

            // save data and reload the page with view mode
            if (strError == "")
            {
                if (intControlEvent == 1)
                    clsSession.Str_RE_Operation = "view";
                else
                    clsSession.Str_RE_Operation = "edit";

                Response.Redirect(strRedirectToAfterSave);
            }
            else
            {
                if (strError == "RentError")
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "alert('The Rent Schedule Grids records for Rent Information could not be saved. Please provide proper data.');ShowPanel();", true);
                else if (strError == "SubtenantError")
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "alert('The Rent Schedule Grids records for Subtenant Information could not be saved. Please provide proper data.');ShowPanel();", true);
                else
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "alert('The Rent Schedule Grids records for Rent Projections could not be saved. Please provide proper data.');ShowPanel();", true);
            }

        }
    }

    /// <summary>
    /// Calulates monthly rent for Term Rent Schedule Grid and Option Rent Schedule Grid on Rent Projections panel
    /// </summary>
    private void CalculateMonthlyRent_Rent()
    {
        // get Subtenant Monthly Rent 
        decimal decMonthlyRent = txtRentSubtenant_Monthly_Rent.Text != "" ? Convert.ToDecimal(txtRentSubtenant_Monthly_Rent.Text.Replace(",", "")) : 0;
        // get Lease Commencement Date 
        int intLeaseCommenseYear = txtLease_Commencement_Date.Text != "" ? Convert.ToDateTime(txtLease_Commencement_Date.Text).Year : 0;

        // check the selected Escalation value
        if (drpFK_LU_EscalationRent.SelectedItem.Text == "US Retail Price Inflation")
        {
            #region " Term Rent Shedule "

            decimal decMonthRentPrev = decMonthlyRent;

            // loop through each row in Term Rent Schedule Grid and calculate the rent and addition
            foreach (GridViewRow gRow in gvRentTRS.Rows)
            {
                if (gRow.RowIndex == 0)
                {
                    ((LinkButton)gRow.FindControl("lnkAdditions")).Text = "0";
                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRent);
                    ((HtmlInputHidden)gRow.FindControl("hdnPercentage")).Value = "0";
                }
                else
                {
                    int intRowYear = Convert.ToInt32(((LinkButton)gRow.FindControl("lnkYear")).Text);
                    int intYear = intLeaseCommenseYear + (intRowYear - 2);
                    decimal decInflationPercent = RE_Subtenant.GetInflation_RateByYear(intYear);
                    decimal decMonthlyRentTRS = decMonthRentPrev + (decMonthRentPrev * decInflationPercent);
                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRentTRS);
                    decimal decDiff = decMonthlyRentTRS - decMonthRentPrev;
                    ((LinkButton)gRow.FindControl("lnkAdditions")).Text = clsGeneral.GetStringValue(decDiff);
                    decMonthRentPrev = decMonthlyRentTRS;
                    ((HtmlInputHidden)gRow.FindControl("hdnPercentage")).Value = decInflationPercent.ToString();
                }
            }

            #endregion

            #region " Option Rent Schedule "

            // loop through each row in Option Rent Schedule Grid and calculate the rent 
            foreach (GridViewRow gRow in gvRentRRS.Rows)
            {
                int intRowYear = Convert.ToDateTime(((LinkButton)gRow.FindControl("lnkFromDate")).Text).Year;
                int intLoop = intRowYear - intLeaseCommenseYear;
                if (intLoop > 0)
                {
                    decimal[] decMonthlyRentORS = new decimal[intLoop];
                    decimal decMonthRentPrevORS = decMonthlyRent;
                    for (int i = 1; i <= intLoop; i++)
                    {
                        int intLoopYear = intLeaseCommenseYear + (i - 1);
                        decimal decInflationPercent = RE_Subtenant.GetInflation_RateByYear(intLoopYear);

                        decMonthlyRentORS[i - 1] = decMonthRentPrevORS + (decMonthRentPrevORS * decInflationPercent);
                        decMonthRentPrevORS = decMonthlyRentORS[i - 1];
                    }

                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRentORS[intLoop - 1]);
                }
            }

            #endregion
        }
        else if (drpFK_LU_EscalationRent.SelectedItem.Text == "LIBOR Rate Schedule")
        {
            #region " Term Rent Shedule "

            decimal decMonthRentPrev = decMonthlyRent;

            // loop through each row in Term Rent Schedule Grid and calculate the rent and addition as per the percentage rate
            foreach (GridViewRow gRow in gvRentTRS.Rows)
            {

                if (gRow.RowIndex == 0)
                {
                    ((LinkButton)gRow.FindControl("lnkAdditions")).Text = "0";
                    ((HtmlInputHidden)gRow.FindControl("hdnPercentage")).Value = "0";
                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRent);
                }
                else
                {
                    int intRowYear = Convert.ToInt32(((LinkButton)gRow.FindControl("lnkYear")).Text);
                    int intYear = intLeaseCommenseYear + (intRowYear - 2);
                    decimal decInflationPercent = txtPercentage_Rate.Text != "" ? Convert.ToDecimal(txtPercentage_Rate.Text) : 0;
                    decimal decMonthlyRentTRS = decMonthRentPrev + (decMonthRentPrev * decInflationPercent);
                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRentTRS);
                    decimal decDiff = decMonthlyRentTRS - decMonthRentPrev;
                    ((LinkButton)gRow.FindControl("lnkAdditions")).Text = clsGeneral.GetStringValue(decDiff);
                    decMonthRentPrev = decMonthlyRentTRS;
                    ((HtmlInputHidden)gRow.FindControl("hdnPercentage")).Value = decInflationPercent.ToString();
                }
            }

            #endregion

            #region " Option Rent Schedule "

            // loop through each row in Term Rent Schedule Grid and calculate the rent as per the percentage rate
            foreach (GridViewRow gRow in gvRentRRS.Rows)
            {
                int intRowYear = Convert.ToDateTime(((LinkButton)gRow.FindControl("lnkFromDate")).Text).Year;
                int intLoop = intRowYear - intLeaseCommenseYear;
                if (intLoop > 0)
                {
                    decimal[] decMonthlyRentORS = new decimal[intLoop];
                    decimal decMonthRentPrevORS = decMonthlyRent;
                    for (int i = 1; i <= intLoop; i++)
                    {
                        int intLoopYear = intLeaseCommenseYear + (i - 1);
                        decimal decInflationPercent = txtPercentage_Rate.Text != "" ? Convert.ToDecimal(txtPercentage_Rate.Text) : 0;

                        decMonthlyRentORS[i - 1] = decMonthRentPrevORS + (decMonthRentPrevORS * decInflationPercent);
                        decMonthRentPrevORS = decMonthlyRentORS[i - 1];
                    }

                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRentORS[intLoop - 1]);
                }
            }

            #endregion
        }
    }

    /// <summary>
    /// Updates the calulated monthly rent in DB for Term Rent Schedule Grid and Option Rent Schedule Grid on Rent Projections panel
    /// </summary>
    private bool UpdateRentScheduleInfo_Rent()
    {
        try
        {
            // if rows available in Term rent scedule grid
            if (gvRentTRS.Rows.Count > 0)
            {
                // loop through each row 
                foreach (GridViewRow gRow in gvRentTRS.Rows)
                {
                    // get values for monthly rent and additions 
                    HtmlInputHidden hdnPK = (HtmlInputHidden)gRow.FindControl("hdnPK_Rent_TRS");
                    LinkButton lnkMonthlyRent = (LinkButton)gRow.FindControl("lnkMonthlyRent");
                    LinkButton lnkAdditions = (LinkButton)gRow.FindControl("lnkAdditions");
                    HtmlInputHidden hdnPercentage = (HtmlInputHidden)gRow.FindControl("hdnPercentage");
                    // update the records with these values 
                    RE_Rent_Projctions_TRS.UpdateRents(Convert.ToDecimal(hdnPK.Value), Convert.ToDecimal(lnkMonthlyRent.Text), Convert.ToDecimal(lnkAdditions.Text), Convert.ToDecimal(hdnPercentage.Value));
                }
            }

            // if rows available in Option rent schedule grid
            if (gvRentRRS.Rows.Count > 0)
            {
                // loop through each row
                foreach (GridViewRow gRow in gvRentRRS.Rows)
                {
                    // get monthly rent value 
                    HtmlInputHidden hdnPK = (HtmlInputHidden)gRow.FindControl("hdnPK_Rent_RRS");
                    LinkButton lnkMonthlyRent = (LinkButton)gRow.FindControl("lnkMonthlyRent");

                    // update record in DB with the value
                    RE_Rent_Projections_ORS.UpdateRents(Convert.ToDecimal(hdnPK.Value), Convert.ToDecimal(lnkMonthlyRent.Text));
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Calulates monthly rent for Term Rent Schedule Grid and Option Rent Schedule Grid on Subtenant Information panel
    /// </summary>
    private void CalculateMonthlyRent_Subtenant()
    {

        // get Subtenant Monthly Rent 
        decimal decMonthlyRent = txtSubtenant_Monthly_RentSubtenant.Text != "" ? Convert.ToDecimal(txtSubtenant_Monthly_RentSubtenant.Text.Replace(",", "")) : 0;

        // get Lease Commencement Date 
        int intLeaseCommenseYear = txtLease_Commencement_Date.Text != "" ? Convert.ToDateTime(txtLease_Commencement_Date.Text).Year : 0;

        // check the selected Escalation value
        if (drpFK_LU_EscalationSubtenant.SelectedItem.Text == "US Retail Price Inflation")
        {
            #region " Term Rent Shedule "

            decimal decMonthRentPrev = decMonthlyRent;

            // loop through each row in Term Rent Schedule Grid and calculate the rent and addition
            foreach (GridViewRow gRow in gvSubtenantTRS.Rows)
            {
                if (gRow.RowIndex == 0)
                {
                    ((LinkButton)gRow.FindControl("lnkAdditions")).Text = "0";
                    ((HtmlInputHidden)gRow.FindControl("hdnPercentage")).Value = "0";
                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRent);
                }
                else
                {
                    int intRowYear = Convert.ToInt32(((LinkButton)gRow.FindControl("lnkYear")).Text);
                    int intYear = intLeaseCommenseYear + (intRowYear - 2);
                    decimal decInflationPercent = RE_Subtenant.GetInflation_RateByYear(intYear);
                    decimal decMonthlyRentTRS = decMonthRentPrev + (decMonthRentPrev * decInflationPercent);
                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRentTRS);
                    decimal decDiff = decMonthlyRentTRS - decMonthRentPrev;
                    ((LinkButton)gRow.FindControl("lnkAdditions")).Text = clsGeneral.GetStringValue(decDiff);
                    decMonthRentPrev = decMonthlyRentTRS;
                    ((HtmlInputHidden)gRow.FindControl("hdnPercentage")).Value = decInflationPercent.ToString();
                }
            }

            #endregion

            #region " Option Rent Schedule "

            // loop through each row in Option Rent Schedule Grid and calculate the rent
            foreach (GridViewRow gRow in gvSubtenantORS.Rows)
            {
                int intRowYear = Convert.ToDateTime(((LinkButton)gRow.FindControl("lnkFromDate")).Text).Year;
                int intLoop = intRowYear - intLeaseCommenseYear;
                if (intLoop > 0)
                {
                    decimal[] decMonthlyRentORS = new decimal[intLoop];
                    decimal decMonthRentPrevORS = decMonthlyRent;
                    for (int i = 1; i <= intLoop; i++)
                    {
                        int intLoopYear = intLeaseCommenseYear + (i - 1);
                        decimal decInflationPercent = RE_Subtenant.GetInflation_RateByYear(intLoopYear);

                        decMonthlyRentORS[i - 1] = decMonthRentPrevORS + (decMonthRentPrevORS * decInflationPercent);
                        decMonthRentPrevORS = decMonthlyRentORS[i - 1];
                    }

                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRentORS[intLoop - 1]);
                }
            }

            #endregion
        }
        else if (drpFK_LU_EscalationSubtenant.SelectedItem.Text == "LIBOR Rate Schedule")
        {
            #region " Term Rent Shedule "

            decimal decMonthRentPrev = decMonthlyRent;
            // loop through each row in Term Rent Schedule Grid and calculate the rent as per the percentage added
            foreach (GridViewRow gRow in gvSubtenantTRS.Rows)
            {

                if (gRow.RowIndex == 0)
                {
                    ((LinkButton)gRow.FindControl("lnkAdditions")).Text = "0";
                    ((HtmlInputHidden)gRow.FindControl("hdnPercentage")).Value = "0";
                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRent);
                }
                else
                {
                    int intRowYear = Convert.ToInt32(((LinkButton)gRow.FindControl("lnkYear")).Text);
                    int intYear = intLeaseCommenseYear + (intRowYear - 2);
                    decimal decInflationPercent = txtPercentage_RateSubtenant.Text != "" ? Convert.ToDecimal(txtPercentage_RateSubtenant.Text) : 0;
                    decimal decMonthlyRentTRS = decMonthRentPrev + (decMonthRentPrev * decInflationPercent);
                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRentTRS);
                    decimal decDiff = decMonthlyRentTRS - decMonthRentPrev;
                    ((LinkButton)gRow.FindControl("lnkAdditions")).Text = clsGeneral.GetStringValue(decDiff);
                    decMonthRentPrev = decMonthlyRentTRS;
                    ((HtmlInputHidden)gRow.FindControl("hdnPercentage")).Value = decInflationPercent.ToString();
                }
            }

            #endregion

            #region " Option Rent Schedule "
            // loop through each row in Option Rent Schedule Grid and calculate the rent as per the percentage added
            foreach (GridViewRow gRow in gvSubtenantORS.Rows)
            {
                int intRowYear = Convert.ToDateTime(((LinkButton)gRow.FindControl("lnkFromDate")).Text).Year;
                int intLoop = intRowYear - intLeaseCommenseYear;
                if (intLoop > 0)
                {
                    decimal[] decMonthlyRentORS = new decimal[intLoop];
                    decimal decMonthRentPrevORS = decMonthlyRent;
                    for (int i = 1; i <= intLoop; i++)
                    {
                        int intLoopYear = intLeaseCommenseYear + (i - 1);
                        decimal decInflationPercent = txtPercentage_RateSubtenant.Text != "" ? Convert.ToDecimal(txtPercentage_RateSubtenant.Text) : 0;

                        decMonthlyRentORS[i - 1] = decMonthRentPrevORS + (decMonthRentPrevORS * decInflationPercent);
                        decMonthRentPrevORS = decMonthlyRentORS[i - 1];
                    }

                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRentORS[intLoop - 1]);
                }
            }

            #endregion
        }

    }

    /// <summary>
    /// Updates the calulated monthly rent in DB for Term Rent Schedule Grid and Option Rent Schedule Grid on Subtenant Information panel
    /// </summary>
    private bool UpdateRentScheduleInfo_Subtenant()
    {
        try
        {
            // if records are available in Term Rent Schedule Grid 
            if (gvSubtenantTRS.Rows.Count > 0)
            {
                // loop through each row 
                foreach (GridViewRow gRow in gvSubtenantTRS.Rows)
                {
                    // get values for monthly rent and addition
                    HtmlInputHidden hdnPK = (HtmlInputHidden)gRow.FindControl("hdnPK_subtenant_TRS");
                    LinkButton lnkMonthlyRent = (LinkButton)gRow.FindControl("lnkMonthlyRent");
                    LinkButton lnkAdditions = (LinkButton)gRow.FindControl("lnkAdditions");
                    HtmlInputHidden hdnPercentage = (HtmlInputHidden)gRow.FindControl("hdnPercentage");
                    // update record with the values
                    RE_Subtenant_TRS.UpdateRents(Convert.ToDecimal(hdnPK.Value), Convert.ToDecimal(lnkMonthlyRent.Text), Convert.ToDecimal(lnkAdditions.Text), Convert.ToDecimal(hdnPercentage.Value));
                }
            }

            // if records are available in Option Rent Schedule Grid 
            if (gvSubtenantORS.Rows.Count > 0)
            {
                // loop through each row
                foreach (GridViewRow gRow in gvSubtenantORS.Rows)
                {
                    // get value of monthly rent 
                    HtmlInputHidden hdnPK = (HtmlInputHidden)gRow.FindControl("hdnPK_subtenant_ORS");
                    LinkButton lnkMonthlyRent = (LinkButton)gRow.FindControl("lnkMonthlyRent");

                    // update the value in DB
                    RE_SubTenant_ORS.UpdateRents(Convert.ToDecimal(hdnPK.Value), Convert.ToDecimal(lnkMonthlyRent.Text));
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Calulates monthly rent for Term Rent Schedule Grid and Option Rent Schedule Grid on Rent Projections panel
    /// </summary>
    private void CalculateMonthlyRent_RentProjection()
    {
        // get Subtenant Monthly Rent 
        decimal decMonthlyRent = txtSubtenant_Monthly_Rent.Text != "" ? Convert.ToDecimal(txtSubtenant_Monthly_Rent.Text.Replace(",", "")) : 0;
        // get Lease Commencement Date 
        int intLeaseCommenseYear = txtLease_Commencement_Date.Text != "" ? Convert.ToDateTime(txtLease_Commencement_Date.Text).Year : 0;

        // check the selected Escalation value
        if (drpFK_LU_Escalation.SelectedItem.Text == "US Retail Price Inflation")
        {
            #region " Term Rent Shedule "

            decimal decMonthRentPrev = decMonthlyRent;

            // loop through each row in Term Rent Schedule Grid and calculate the rent and addition
            foreach (GridViewRow gRow in gvRentProjectionTRS.Rows)
            {
                if (gRow.RowIndex == 0)
                {
                    ((LinkButton)gRow.FindControl("lnkAdditions")).Text = "0";
                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRent);
                    ((HtmlInputHidden)gRow.FindControl("hdnPercentage")).Value = "0";
                }
                else
                {
                    int intRowYear = Convert.ToInt32(((LinkButton)gRow.FindControl("lnkYear")).Text);
                    int intYear = intLeaseCommenseYear + (intRowYear - 2);
                    decimal decInflationPercent = RE_Subtenant.GetInflation_RateByYear(intYear);
                    decimal decMonthlyRentTRS = decMonthRentPrev + (decMonthRentPrev * decInflationPercent);
                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRentTRS);
                    decimal decDiff = decMonthlyRentTRS - decMonthRentPrev;
                    ((LinkButton)gRow.FindControl("lnkAdditions")).Text = clsGeneral.GetStringValue(decDiff);
                    decMonthRentPrev = decMonthlyRentTRS;
                    ((HtmlInputHidden)gRow.FindControl("hdnPercentage")).Value = decInflationPercent.ToString();
                }
            }

            #endregion

            #region " Option Rent Schedule "

            // loop through each row in Option Rent Schedule Grid and calculate the rent 
            foreach (GridViewRow gRow in gvRentProjectionORS.Rows)
            {
                int intRowYear = Convert.ToDateTime(((LinkButton)gRow.FindControl("lnkFromDate")).Text).Year;
                int intLoop = intRowYear - intLeaseCommenseYear;
                if (intLoop > 0)
                {
                    decimal[] decMonthlyRentORS = new decimal[intLoop];
                    decimal decMonthRentPrevORS = decMonthlyRent;
                    for (int i = 1; i <= intLoop; i++)
                    {
                        int intLoopYear = intLeaseCommenseYear + (i - 1);
                        decimal decInflationPercent = RE_Subtenant.GetInflation_RateByYear(intLoopYear);

                        decMonthlyRentORS[i - 1] = decMonthRentPrevORS + (decMonthRentPrevORS * decInflationPercent);
                        decMonthRentPrevORS = decMonthlyRentORS[i - 1];
                    }

                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRentORS[intLoop - 1]);
                }
            }

            #endregion
        }
        else if (drpFK_LU_Escalation.SelectedItem.Text == "LIBOR Rate Schedule")
        {
            #region " Term Rent Shedule "

            decimal decMonthRentPrev = decMonthlyRent;

            // loop through each row in Term Rent Schedule Grid and calculate the rent and addition as per the percentage rate
            foreach (GridViewRow gRow in gvRentProjectionTRS.Rows)
            {

                if (gRow.RowIndex == 0)
                {
                    ((LinkButton)gRow.FindControl("lnkAdditions")).Text = "0";
                    ((HtmlInputHidden)gRow.FindControl("hdnPercentage")).Value = "0";
                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRent);
                }
                else
                {
                    int intRowYear = Convert.ToInt32(((LinkButton)gRow.FindControl("lnkYear")).Text);
                    int intYear = intLeaseCommenseYear + (intRowYear - 2);
                    decimal decInflationPercent = txtPercentage_Rate.Text != "" ? Convert.ToDecimal(txtPercentage_Rate.Text) : 0;
                    decimal decMonthlyRentTRS = decMonthRentPrev + (decMonthRentPrev * decInflationPercent);
                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRentTRS);
                    decimal decDiff = decMonthlyRentTRS - decMonthRentPrev;
                    ((LinkButton)gRow.FindControl("lnkAdditions")).Text = clsGeneral.GetStringValue(decDiff);
                    decMonthRentPrev = decMonthlyRentTRS;
                    ((HtmlInputHidden)gRow.FindControl("hdnPercentage")).Value = decInflationPercent.ToString();
                }
            }

            #endregion

            #region " Option Rent Schedule "

            // loop through each row in Term Rent Schedule Grid and calculate the rent as per the percentage rate
            foreach (GridViewRow gRow in gvRentProjectionORS.Rows)
            {
                int intRowYear = Convert.ToDateTime(((LinkButton)gRow.FindControl("lnkFromDate")).Text).Year;
                int intLoop = intRowYear - intLeaseCommenseYear;
                if (intLoop > 0)
                {
                    decimal[] decMonthlyRentORS = new decimal[intLoop];
                    decimal decMonthRentPrevORS = decMonthlyRent;
                    for (int i = 1; i <= intLoop; i++)
                    {
                        int intLoopYear = intLeaseCommenseYear + (i - 1);
                        decimal decInflationPercent = txtPercentage_Rate.Text != "" ? Convert.ToDecimal(txtPercentage_Rate.Text) : 0;

                        decMonthlyRentORS[i - 1] = decMonthRentPrevORS + (decMonthRentPrevORS * decInflationPercent);
                        decMonthRentPrevORS = decMonthlyRentORS[i - 1];
                    }

                    ((LinkButton)gRow.FindControl("lnkMonthlyRent")).Text = clsGeneral.GetStringValue(decMonthlyRentORS[intLoop - 1]);
                }
            }

            #endregion
        }
    }

    /// <summary>
    /// Updates the calulated monthly rent in DB for Term Rent Schedule Grid and Option Rent Schedule Grid on Rent Projections panel
    /// </summary>
    private bool UpdateRentScheduleInfo_RentProjection()
    {
        try
        {
            // if rows available in Term rent scedule grid
            if (gvRentProjectionTRS.Rows.Count > 0)
            {
                // loop through each row 
                foreach (GridViewRow gRow in gvRentProjectionTRS.Rows)
                {
                    // get values for monthly rent and additions 
                    HtmlInputHidden hdnPK = (HtmlInputHidden)gRow.FindControl("hdnPK_RentProjection_TRS");
                    LinkButton lnkMonthlyRent = (LinkButton)gRow.FindControl("lnkMonthlyRent");
                    LinkButton lnkAdditions = (LinkButton)gRow.FindControl("lnkAdditions");
                    HtmlInputHidden hdnPercentage = (HtmlInputHidden)gRow.FindControl("hdnPercentage");
                    // update the records with these values 
                    RE_Rent_Projctions_TRS.UpdateRents(Convert.ToDecimal(hdnPK.Value), Convert.ToDecimal(lnkMonthlyRent.Text), Convert.ToDecimal(lnkAdditions.Text), Convert.ToDecimal(hdnPercentage.Value));
                }
            }

            // if rows available in Option rent schedule grid
            if (gvRentProjectionORS.Rows.Count > 0)
            {
                // loop through each row
                foreach (GridViewRow gRow in gvRentProjectionORS.Rows)
                {
                    // get monthly rent value 
                    HtmlInputHidden hdnPK = (HtmlInputHidden)gRow.FindControl("hdnPK_RentProjection_ORS");
                    LinkButton lnkMonthlyRent = (LinkButton)gRow.FindControl("lnkMonthlyRent");

                    // update record in DB with the value
                    RE_Rent_Projections_ORS.UpdateRents(Convert.ToDecimal(hdnPK.Value), Convert.ToDecimal(lnkMonthlyRent.Text));
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Sets user access for the page
    /// </summary>
    private void SetUserRights()
    {
        // check the user access type and set the flag indicating the page is editable or not
        switch (App_Access)
        {
            case AccessType.View_Only:
                if (clsSession.Str_RE_Operation.ToUpper() == "Edit".ToUpper())
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                _bAllowEdit = false;
                break;
            case AccessType.Administrative_Access:
                _bAllowEdit = true;
                break;
            case AccessType.NotAssigned:
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                break;
            default:
                _bAllowEdit = false;
                break;
        }
    }

    private void SetLeaseInformation()
    {
        // set labels for lease information 
        lblRentLeaseCommencementDate.Text = txtLease_Commencement_Date.Text;
        lblRentLeaseTerm.Text = txtLease_Term_Months.Text;
        lblRentLeaseExpDate.Text = txtLease_Expiration_Date.Text;
        lblRentPriorLeaseDate.Text = txtPrior_Lease_Commencement_Date.Text;

        lblSubTenantLeaseCommencementDate.Text = txtLease_Commencement_Date.Text;
        lblSubTenantLeaseTerm.Text = txtLease_Term_Months.Text;
        lblSubTenantLeaseExpDate.Text = txtLease_Expiration_Date.Text;
        lblSubTenantPriorLeaseDate.Text = txtPrior_Lease_Commencement_Date.Text;

        lblRentProjectionsLeaseCommencementDate.Text = txtLease_Commencement_Date.Text;
        lblRentProjectionsLeaseTerm.Text = txtLease_Term_Months.Text;
        lblRentProjectionsLeaseExpDate.Text = txtLease_Expiration_Date.Text;
        lblRentProjectionsPriorLeaseDate.Text = txtPrior_Lease_Commencement_Date.Text;
    }

    private bool IsValidORSFromDate(GridView gvORS)
    {
        bool bValid = true;
        foreach (GridViewRow gRow in gvORS.Rows)
        {
            DateTime dt1 = Convert.ToDateTime(txtLease_Commencement_Date.Text);
            DateTime dt2 = Convert.ToDateTime(((LinkButton)gRow.FindControl("lnkFromDate")).Text);
            if (dt1 >= dt2)
            {
                if (bValid == true) bValid = false;
            }
        }
        return bValid;
    }
    #endregion

    #region Control Events

    ///// <summary>
    ///// Handles event when DBA selection is changed from popup
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void btnDBASelectionChange_Click(object sender, EventArgs e)
    //{
    //    // create object for LU_location by getting value from hidden field
    //    LU_Location objLU_Location = new LU_Location(Convert.ToDecimal(hdnLU_location.Value));

    //    // set values in fields for LU_Location
    //    txtLU_Location.Text = objLU_Location.dba;
    //    txtLegalEntity.Text = objLU_Location.legal_entity;
    //    txtAddress1.Text = objLU_Location.Address_1;
    //    txtAddress2.Text = objLU_Location.Address_2;
    //    txtCity.Text = objLU_Location.City;
    //    txtState.Text = new State(Convert.ToDecimal(objLU_Location.State)).FLD_state;
    //    txtZipCode.Text = objLU_Location.Zip_Code;
    //    txtTelephone.Text = objLU_Location.Dealership_Telephone;
    //    txtRegion.Text = objLU_Location.Region;
    //    txtCounty.Text = objLU_Location.County;
    //    ShowPanel(1);

    //}

    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveData(1, "RealEstateAddEdit.aspx");
    }

    /// <summary>
    /// Handles Back button click in view mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // set PK and operation (edit) in session and reload the page
        clsSession.Current_RE_Information_ID = _PK_RE_Information;
        clsSession.Str_RE_Operation = "edit";
        Response.Redirect("RealEstateAddEdit.aspx");
    }

    protected void drpLU_Location_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpLU_Location.SelectedIndex > 0)
        {
            // create object for LU_location by getting value from hidden field
            LU_Location objLU_Location = new LU_Location(Convert.ToDecimal(drpLU_Location.SelectedValue));

            // set values in fields for LU_Location
            //txtLU_Location.Text = objLU_Location.dba;
            //txtLegalEntity.Text = objLU_Location.legal_entity;
            txtAddress1.Text = objLU_Location.Address_1;
            txtAddress2.Text = objLU_Location.Address_2;
            txtCity.Text = objLU_Location.City;
            txtState.Text = new State(Convert.ToDecimal(objLU_Location.State)).FLD_state;
            txtZipCode.Text = objLU_Location.Zip_Code;
            txtTelephone.Text = objLU_Location.Dealership_Telephone;
            txtRegion.Text = objLU_Location.Region;
            txtCounty.Text = objLU_Location.County;
        }
        else
        {
            // set values in fields for LU_Location
            //txtLU_Location.Text = "";
            //txtLegalEntity.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipCode.Text = "";
            txtTelephone.Text = "";
            txtRegion.Text = "";
            txtCounty.Text = "";
        }
        SetLeaseInformation();
        ShowPanel(1);
    }

    /// <summary>
    /// Handles event on Escalation dropdown selection change in Subtenant information panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpFK_LU_EscalationRent_SelectedIndexChanged(object sender, EventArgs e)
    {
        // calculate the monthly rent and addition in term rent schedule grid and option rent schedule grid
        CalculateMonthlyRent_Rent();

        // make editable the percentage rate textbox if escalation = LIBOR Rate Schedule
        if (drpFK_LU_EscalationRent.SelectedItem.Text == "LIBOR Rate Schedule")
            txtPercentage_RateRent.Enabled = true;
        else
            txtPercentage_RateRent.Enabled = false;

        SetLeaseInformation();
        ShowPanel(2);
    }

    /// <summary>
    /// Handles event on Escalation dropdown selection change in Subtenant information panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpFK_LU_EscalationSubtenant_SelectedIndexChanged(object sender, EventArgs e)
    {
        // calculate the monthly rent and addition in term rent schedule grid and option rent schedule grid
        CalculateMonthlyRent_Subtenant();

        // make editable the percentage rate textbox if escalation = LIBOR Rate Schedule
        if (drpFK_LU_EscalationSubtenant.SelectedItem.Text == "LIBOR Rate Schedule")
            txtPercentage_RateSubtenant.Enabled = true;
        else
            txtPercentage_RateSubtenant.Enabled = false;

        SetLeaseInformation();
        ShowPanel(3);
    }

    /// <summary>
    /// Handles event on Escalation dropdown selection change in Rent Projections panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpFK_LU_Escalation_SelectedIndexChanged(object sender, EventArgs e)
    {
        // calculate the monthly rent and addition in term rent schedule grid and option rent schedule grid
        CalculateMonthlyRent_RentProjection();

        // make editable the percentage rate textbox if escalation = LIBOR Rate Schedule
        if (drpFK_LU_Escalation.SelectedItem.Text == "LIBOR Rate Schedule")
            txtPercentage_Rate.Enabled = true;
        else
            txtPercentage_Rate.Enabled = false;

        SetLeaseInformation();

        ShowPanel(3);
    }

    /// <summary>
    /// Handles Add link click for Term Rent Schedule Grid on Subtenant Information panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddTRSSubTenant_Click(object sender, EventArgs e)
    {
        // save data and redirect to Subtenant Term Rent Schedule page with edit mode
        SaveData(2, "SubtenantTRS.aspx");
        
    }

    /// <summary>
    /// Handles Add link click for Option Rent Schedule Grid on Subtenant Information panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddORSSubTenant_Click(object sender, EventArgs e)
    {
        // save data and redirect to Subtenant Option Rent Schedule page with edit mode
        SaveData(2, "SubtenantORS.aspx");
        
    }

    /// <summary>
    /// Handles Add link click for Term Rent Schedule Grid on Rent Projections page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddTRSRentProjection_Click(object sender, EventArgs e)
    {
        // save data and redirect to Subtenant Term Rent Schedule page with edit mode
        SaveData(2, "RentProjectionTRS.aspx");
        
    }

    /// <summary>
    /// Handles Add link click for option Rent Schedule Grid on Rent Projections page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddORSRentProjection_Click(object sender, EventArgs e)
    {
        // save data and redirect to Subtenant Option Rent Schedule page with edit mode
        SaveData(2, "RentProjectionORS.aspx");
       
    }

    protected void btnUpdateRent_Rent_Click(object sender, EventArgs e)
    {
        // calculate the monthly rent for rent schedule grid on subtenant information panel
        CalculateMonthlyRent_Rent();
        SetLeaseInformation();

        ShowPanel(2);

    }

    protected void lnkAddTRSRent_Click(object sender, EventArgs e)
    {
        // save data and redirect to Subtenant Term Rent Schedule page with edit mode
        SaveData(2, "RentTRS.aspx");
    }

    protected void lnkAddRRSRent_Click(object sender, EventArgs e)
    {
        // save data and redirect to Subtenant Option Rent Schedule page with edit mode
        SaveData(2, "RentRRS.aspx");
    }

    /// <summary>
    /// Handles hidden button click event when percentage rent is changed on Subtenant Information 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdateRentSubtenant_Click(object sender, EventArgs e)
    {
        // calculate the monthly rent for rent schedule grid on subtenant information panel
        CalculateMonthlyRent_Subtenant();
        SetLeaseInformation();

        ShowPanel(3);

    }

    /// <summary>
    /// Handles hidden button click event when percentage rent is changed on Rent Projection panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdateRent_RentProj_Click(object sender, EventArgs e)
    {
        // calculate the monthly rent for rent schedule grid on Rent Projection panel
        CalculateMonthlyRent_RentProjection();

        SetLeaseInformation();
        ShowPanel(3);
    }

    /// <summary>
    /// Handles Add link click event for Notes grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNotes_Click(object sender, EventArgs e)
    {
        // save data and redirect to Notes page with edit mode
        SaveData(2, "RE_InformationNotes.aspx");
        
    }

    /// <summary>
    /// Handles Add link click event for Repair Maintenance grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddRepairMaint_Click(object sender, EventArgs e)
    {
        // save data and redirect to Repair Maintenance page with edit mode
        SaveData(2, "RepairMantenance.aspx");
        
    }
    #endregion

    #region Attachments Management
    /// <summary>
    /// Binds the attachment details
    /// </summary>
    private void BindAttachmentDetails()
    {
        // show attachment div
        dvAttachment.Style["display"] = "block";
        // bind attachment records
        AttachDetails.Bind();
    }
    /// <summary>
    /// handles Add Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        SetLeaseInformation();
        if (_PK_RE_Information > 0)
        {
            // add attachment if any.
            Attachment.Add(clsGeneral.Tables.RE_Information, (int)_PK_RE_Information);
            // Bind the attachment detail to view the added attachment
            BindAttachmentDetails();
            // show attachment panel as the page is loaded again
            ScriptManager.RegisterStartupScript(Page, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(10);", true);
        }
    }
    #endregion

    #region "Gridview Events"

    /// <summary>
    /// Handles Term Rent Schedule Grid command event on Rent Projections panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRentTRS_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if command is "ShowDetails" then open the Term rent schedule page with the PK encrypted
        if (e.CommandName == "ShowDetails")
        {
            if (_StrOperation == "edit")
                SaveData(2, "RentTRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
            else
                Response.Redirect("RentTRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
        }
        else if (e.CommandName == "RemoveTRS") // if command is for removing the record
        {
            // delete the record by PK passed in commandargument
            RE_Rent_TRS.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            // bind the grid again
            BindTRSRentGrid();
            ShowPanel(2);
        }
    }

    /// <summary>
    /// Handles Option Rent Schedule Grid command event on Rent Projections panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRentRRS_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if command is "ShowDetails" then open the Term rent schedule page with the PK encrypted
        if (e.CommandName == "ShowDetails")
        {
            if (_StrOperation == "edit")
                SaveData(2, "RentRRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
            else
                Response.Redirect("RentRRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
        }
        else if (e.CommandName == "RemoveORS") // if command is for removing the record
        {
            // delete the record by PK passed in commandargument
            RE_Rent_RRS.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            // bind the grid again
            BindRRSRentGrid();
            ShowPanel(2);
        }
    }

    /// <summary>
    /// Handles Term Rent Schedule Grid command event on Subtenant Information panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSubtenantTRS_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if command is "ShowDetails" then open the Term rent schedule page with the PK encrypted
        if (e.CommandName == "ShowDetails")
        {
            if (_StrOperation == "edit")
                SaveData(2, "SubtenantTRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
            else
                Response.Redirect("SubtenantTRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
        }
        else if (e.CommandName == "RemoveTRS") // if command is for removing the record
        {
            // delete the record by PK passed in commandargument
            RE_Subtenant_TRS.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            // bind the grid again
            BindTRSSubtenantGrid();
            ShowPanel(3);
        }

    }

    /// <summary>
    /// Handles Option Rent Schedule Grid command event on Subtenant Information panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSubtenantORS_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if command is "ShowDetails" then open the Option rent schedule page with the PK encrypted
        if (e.CommandName == "ShowDetails")
        {
            if (_StrOperation == "edit")
                SaveData(2, "SubtenantORS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
            else
                Response.Redirect("SubtenantORS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
        }
        else if (e.CommandName == "RemoveORS") // if command is for removing the record
        {
            // delete the record by PK passed in commandargument
            RE_SubTenant_ORS.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            // bind the grid again
            BindORSSubtenantGrid();
            ShowPanel(3);
        }
    }

    /// <summary>
    /// Handles Term Rent Schedule Grid command event on Rent Projections panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRentProjectionTRS_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if command is "ShowDetails" then open the Term rent schedule page with the PK encrypted
        if (e.CommandName == "ShowDetails")
        {
            if (_StrOperation == "edit")
                SaveData(2, "RentProjectionTRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
            else
                Response.Redirect("RentProjectionTRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
        }
        else if (e.CommandName == "RemoveTRS") // if command is for removing the record
        {
            // delete the record by PK passed in commandargument
            RE_Rent_Projctions_TRS.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            // bind the grid again
            BindTRSRentProjectionGrid();
            ShowPanel(4);
        }
    }

    /// <summary>
    /// Handles Option Rent Schedule Grid command event on Rent Projections panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRentProjectionORS_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if command is "ShowDetails" then open the Term rent schedule page with the PK encrypted
        if (e.CommandName == "ShowDetails")
        {
            if (_StrOperation == "edit")
                SaveData(2, "RentProjectionORS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
            else
                Response.Redirect("RentProjectionORS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
        }
        else if (e.CommandName == "RemoveORS") // if command is for removing the record
        {
            // delete the record by PK passed in commandargument
            RE_Rent_Projections_ORS.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            // bind the grid again
            BindORSRentProjectionGrid();
            ShowPanel(4);
        }
    }

    /// <summary>
    /// Handles Repair Maintenance gridview commad event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRepairMaintenance_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if command is "ShowDetails" then open the Repair Mantenance page with the PK encrypted
        if (e.CommandName == "ShowDetails")
        {
            if (_StrOperation == "edit")
                SaveData(2, "RepairMantenance.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
            else
                Response.Redirect("RepairMantenance.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));

        }
        else if (e.CommandName == "RemoveDetails") // if command is for removing the record
        {
            // delete the record by PK passed in commandargument
            RE_Repair_Maintenance.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            // bind the grid again
            BindRepairMaintenanceGrid();
            ShowPanel(6);
        }
    }

    /// <summary>
    /// Handles Notes gridview commad event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if command is "ShowDetails" then open the Repair Mantenance page with the PK encrypted
        if (e.CommandName == "ShowDetails")
        {
            if (_StrOperation == "edit")
                SaveData(2, "RE_InformationNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
            else
                Response.Redirect("RE_InformationNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
        }
        else if (e.CommandName == "RemoveDetails")  // if command is for removing the record
        {
            // delete the record by PK passed in commandargument
            RE_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            // bind the grid again
            BindNotesGrid();
            ShowPanel(9);
        }
    }

    #endregion
}
