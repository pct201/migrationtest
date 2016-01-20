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

/// <summary>
/// Date : 06 JUNE 2009
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// To add, edit and view the Lease record
/// 
/// Functionality:
/// Checks for the location passed in querystring
/// and sets the page controls in view or edit or add mode depending on
/// the records availability
/// Also performs attachments adding, listing and removing
/// </summary>
public partial class SONIC_Exposures_Lease : clsBasePage
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
        set { ViewState["PK_RE_Information"] = value; hdnREInfoID.Value = value.ToString(); }
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
        set { ViewState["PK_RE_Rent"] = value; hdnRentID.Value = value.ToString(); }
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
        set { ViewState["PK_RE_Notices"] = value; hdnNotices.Value = value.ToString(); }
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
        set { ViewState["PK_RE_Rent_Projections"] = value; hdnRentProjID.Value = value.ToString(); }
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
        set { ViewState["PK_RE_Security_Deposit"] = value; hdnSecurityDepositID.Value = value.ToString(); }
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
        set { ViewState["PK_RE_Subtenant"] = value; hdnSubtenantID.Value = value.ToString(); }
    }

    public decimal _PK_RE_Building
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_RE_Building"]);
        }
        set { ViewState["PK_RE_Building"] = value; }
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
        set { ViewState["PK_RE_Surrender_Obligations"] = value; hdnSurrenderID.Value = value.ToString(); }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string _StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; hdnOperation.Value = value; }
    }

    /// <summary>
    /// Denotes whether user has access rights for edit or not
    /// </summary>
    public bool _bAllowEdit
    {
        get { return ViewState["bAllowEdit"] != null ? Convert.ToBoolean(ViewState["bAllowEdit"]) : false; }
        set { ViewState["bAllowEdit"] = value; }
    }

    /// <summary>
    /// Denotes whether selected Location is active or not
    /// </summary>
    public string LocationActive
    {
        get
        {
            return clsGeneral.IsNull(ViewState["LocationActive"]) ? "Y" : ViewState["LocationActive"].ToString();
        }
        set { ViewState["LocationActive"] = value; }
    }

    /// <summary>
    /// Denotes foriegn key for Location record
    /// </summary>
    public int FK_LU_Location_ID
    {
        get { return Convert.ToInt32(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
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
        // set Lease tab selected
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Lease);
        Attachment.btnHandler += new Controls_Attachments_Attachment.OnButtonClick(Upload_File);
        if (!Page.IsPostBack)
        {
            // Check if page in edit mode and User has only View rights
            if (App_Access == AccessType.View_Only && clsSession.Str_RE_Operation.ToUpper() == "Edit".ToUpper() && string.IsNullOrEmpty(clsSession.Str_RE_Operation))
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                return;
            }
            SetUserRights();

            // if location ID is passed in querystring
            // else redirect to search page
            if (Request.QueryString["loc"] != null)
            {
                // check for valid ID and redirect to search page if it is not valid
                int loc;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out loc))
                {
                    FK_LU_Location_ID = loc;
                }
                else
                    Response.Redirect(AppConfig.SiteURL + "SONIC/Exposures/ExposureSearch.aspx");

                // store the location id in session
                Session["ExposureLocation"] = FK_LU_Location_ID;

                _PK_RE_Information = RE_Information.SelectPKByFKLoc(FK_LU_Location_ID);
                LocationActive = new LU_Location(Convert.ToDecimal(FK_LU_Location_ID)).Active;

                // set operation flag to view if record is available and location is inactive
                if (_PK_RE_Information > 0 || LocationActive == "N")
                    _StrOperation = "view";
            }
            else
                Response.Redirect(AppConfig.SiteURL + "SONIC/Exposures/ExposureSearch.aspx");

            // set operation flag if passed in querystring 
            if (Request.QueryString["op"] != null)
            {
                _StrOperation = Request.QueryString["op"].ToString();
            }
            clsSession.Str_RE_Operation = _StrOperation;

            // Bind location information
            ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
            ucCtrlExposureInfo.BindExposureInfo();


            // set javascript validations or attributes
            txtLease_Term_Months.Attributes.Add("onchange", "document.getElementById('" + lblRentLeaseTerm.ClientID + "').innerHTML = this.value;" +
                                                            "document.getElementById('" + lblSubTenantLeaseTerm.ClientID + "').innerHTML = this.value;" +
                                                            "document.getElementById('" + lblRentProjectionsLeaseTerm.ClientID + "').innerHTML = this.value;");
            txtLease_Expiration_Date.Attributes.Add("onchange", "document.getElementById('" + lblRentLeaseExpDate.ClientID + "').innerHTML = this.value;" +
                                                                "document.getElementById('" + lblSubTenantLeaseExpDate.ClientID + "').innerHTML = this.value;" +
                                                                "document.getElementById('" + lblRentProjectionsLeaseExpDate.ClientID + "').innerHTML = this.value;");
            txtPrior_Lease_Commencement_Date.Attributes.Add("onchange", "document.getElementById('" + lblRentPriorLeaseDate.ClientID + "').innerHTML = this.value;" +
                                                                        "document.getElementById('" + lblSubTenantPriorLeaseDate.ClientID + "').innerHTML = this.value;" +
                                                                        "document.getElementById('" + lblRentProjectionsPriorLeaseDate.ClientID + "').innerHTML = this.value;");
            txtPrior_Lease_Commencement_Date.Attributes.Add("onblur", "document.getElementById('" + lblRentPriorLeaseDate.ClientID + "').innerHTML = this.value;" +
                                                                      "document.getElementById('" + lblSubTenantPriorLeaseDate.ClientID + "').innerHTML = this.value;" +
                                                                      "document.getElementById('" + lblRentProjectionsPriorLeaseDate.ClientID + "').innerHTML = this.value;");

            drpFK_LU_EscalationRent.Attributes.Add("onclick", "return CheckLeaseDate();");
            drpFK_LU_EscalationRent.Attributes.Add("onchange", "MakeEditableRateRent(this);");

            drpFK_LU_EscalationSubtenant.Attributes.Add("onclick", "return CheckLeaseDate();");
            drpFK_LU_EscalationSubtenant.Attributes.Add("onchange", "MakeEditableRateSubtenant(this);");

            drpFK_LU_Escalation.Attributes.Add("onchange", "MakeEditableRateRentProjection(this);");
            drpFK_LU_Escalation.Attributes.Add("onclick", "return CheckLeaseDate();");

            int intPanel = 1;

            // if panel number is passed in querystring
            if (Request.QueryString["pnl"] != null)
            {
                // check if valid number is there and show the panel 
                // else show first panel
                int index;
                if (int.TryParse(Request.QueryString["pnl"], out index))
                {
                    intPanel = index;
                    ShowPanel(intPanel);
                }
                else
                    ShowPanel(1);

                // check and set PK from session and vice verca
                if (clsSession.Current_RE_Information_ID > 0)
                {
                    _PK_RE_Information = clsSession.Current_RE_Information_ID;
                }
                else
                {
                    clsSession.Current_RE_Information_ID = _PK_RE_Information;
                }
            }
            else
            {
                ShowPanel(1);
                clsSession.Current_RE_Information_ID = _PK_RE_Information;
            }

            // if operation flag is set
            if (_StrOperation != string.Empty)
            {
                // bind page controls in either view or edit mode depending on the operation flag
                if (_StrOperation == "view")
                    BindDetailsForView();
                else
                    BindDetailsForEdit();
            }
            else // if page in add mode
            {
                // check for the access for edit
                if (_bAllowEdit)
                {
                    // bind necessary information on the page to add the record
                    BindDropDowns();
                    BindPropertyInfo();

                    // disable Add Attachment button
                    Attachment.ShowAttachmentButton = false;
                    BindAttachmentDetails();

                    // don't show div for view mode
                    dvSave.Style["display"] = "block";
                    dvView.Style["display"] = "none";
                    BindGrids();
                    ShowHideAuditButtons(false);
                }
                else
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }
            if (_StrOperation != "view")
            {
                SetValidations();
                SetVadidationForSubLease();
            }
            if (Request.QueryString["Subtenant"] != null)
            {
                _PK_RE_Subtenant = Convert.ToInt32(Encryption.Decrypt(Request.QueryString["Subtenant"]));
                BindSubtenantForEdit();
            }
        }
        else
        {
            // get Event arguments sent from javascript
            string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];

            // if Lease date is changed
            if (eventTarget == "LeaseDateChanged")
            {
                // set lease information labels
                SetLeaseInformation();

                // calculate the rents in all rent schedule grids
                CalculateRentsOnLeaseDateChanged();
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
            else if (eventTarget == "SubtenantMonthlyRentChanged")   // if Monthly Rent field changed on Subtenat Information panel
            {
                // set lease information labels
                SetLeaseInformation();

                // if rent schedule grid records are avaialble for subtenant panel and lease commencement date is not blank
                if ((gvSubtenantTRS.Rows.Count > 0 || gvSubtenantORS.Rows.Count > 0) && txtLease_Commencement_Date.Text != "")
                {
                    // calculate rents for both grids
                    CalculateMonthlyRent_Subtenant();
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
            }
            else if (eventTarget == "RentProjectionMonthlyRentChanged")  // if Monthly Rent field changed on Rent Projections panel
            {
                // set lease information labels
                SetLeaseInformation();

                // if rent schedule grid records are avaialble for Rent projections panel and lease commencement date is not blank
                if ((gvRentProjectionTRS.Rows.Count > 0 || gvRentProjectionORS.Rows.Count > 0) && txtLease_Commencement_Date.Text != "")
                {
                    // calculate rents for both grids
                    CalculateMonthlyRent_RentProjection();
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
            }
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        ShowHideAuditButtons(true);
        // show hide div conrols for edit mode
        dvEdit.Style["display"] = "block";
        dvSave.Style["display"] = "block";
        dvView.Style["display"] = "none";
        dvBack.Style["display"] = "none";
        lnkAddNew.Visible = true;

        ((Button)Attachment.FindControl("btnAddAttachment")).Visible = false;

        btnAbstractReport.Visible = true;
        btnAbstractReportView.Visible = false;

        BindDropDowns();

        // set all PKs
        DataTable dtPKs = RE_Information.GetPKofAllChildTables(_PK_RE_Information).Tables[0];
        if (dtPKs.Rows.Count > 0)
        {
            _PK_RE_Rent = Convert.ToDecimal(dtPKs.Rows[0]["PK_RE_Rent"]);
            _PK_RE_Subtenant = Convert.ToDecimal(dtPKs.Rows[0]["RE_Subtenant"]);
            _PK_RE_Rent_Projections = Convert.ToDecimal(dtPKs.Rows[0]["RE_Rent_Projections"]);
            _PK_RE_Security_Deposit = Convert.ToDecimal(dtPKs.Rows[0]["RE_Security_Deposit"]);
            _PK_RE_Surrender_Obligations = Convert.ToDecimal(dtPKs.Rows[0]["RE_Surrender_Obligations"]);
            _PK_RE_Notices = Convert.ToDecimal(dtPKs.Rows[0]["RE_Notices"]);
        }

        #region " Bind Real Estate Information "
        // create objects for RE_Information table
        RE_Information objRE_Information = new RE_Information(_PK_RE_Information);

        // set values in page controls
        BindPropertyInfo();

        //txtFederal_Id.Text = objRE_Information.Federal_Id;


        txtTax_Parcel_Number.Text = objRE_Information.Tax_Parcel_Number;
        //if (objRE_Information.FK_LU_Lease_Type != null) drpFK_LU_Lease_Type.SelectedValue = objRE_Information.FK_LU_Lease_Type.ToString();
        txtLandlord.Text = objRE_Information.Landlord;
        txtLandlord_Location_Address1.Text = objRE_Information.Landlord_Location_Address1;
        txtLandlord_Location_Address2.Text = objRE_Information.Landlord_Location_Address2;
        txtLandlord_Location_City.Text = objRE_Information.Landlord_Location_City;
        if (objRE_Information.PK_Landlord_Location_State != null)
            drpLandlord_Location_State.SelectedValue = objRE_Information.PK_Landlord_Location_State.ToString();
        else
            drpLandlord_Location_State.SelectedIndex = 0;
        txtLandlord_Location_Zip_Code.Text = objRE_Information.Landlord_Location_Zip_Code;
        txtLandlord_Mailing_Address1.Text = objRE_Information.Landlord_Mailing_Address1;
        txtLandlord_Mailing_Address2.Text = objRE_Information.Landlord_Mailing_Address2;
        txtLandlord_Mailing_City.Text = objRE_Information.Landlord_Mailing_City;
        if (objRE_Information.PK_Landlord_Mailing_State != null)
            drpLandlordMailingState.SelectedValue = objRE_Information.PK_Landlord_Mailing_State.ToString();
        else
            drpLandlordMailingState.SelectedIndex = 0;
        txtLandlord_Mailing_Zip_Code.Text = objRE_Information.Landlord_Mailing_Zip_Code;
        txtLandlord_Telephone.Text = objRE_Information.Landlord_Telephone;
        txtLandlord_Email.Text = objRE_Information.Landlord_Email;
        rdoSublease.SelectedValue = !string.IsNullOrEmpty(objRE_Information.Sublease) ? objRE_Information.Sublease : "N";
        txtSubtenant.Text = objRE_Information.Subtenant;
        txtLease_Id.Text = objRE_Information.Lease_Id;
        txtLease_Commencement_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Commencement_Date);
        lblSubTenantLeaseCommencementDate.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Commencement_Date);
        lblRentProjectionsLeaseCommencementDate.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Commencement_Date);
        if (objRE_Information.FK_LU_Project_Type != null) drpFK_LU_Project_Type.SelectedValue = objRE_Information.FK_LU_Project_Type.ToString();
        txtLease_Expiration_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Expiration_Date);
        lblSubTenantLeaseExpDate.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Expiration_Date);
        lblRentProjectionsLeaseExpDate.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Expiration_Date);
        txtDate_Acquired.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Date_Acquired);
        txtLease_Term_Months.Text = clsGeneral.GetStringValue(objRE_Information.Lease_Term_Months).Replace(".00", "");
        lblSubTenantLeaseTerm.Text = clsGeneral.GetStringValue(objRE_Information.Lease_Term_Months).Replace(".00", "");
        lblRentProjectionsLeaseTerm.Text = clsGeneral.GetStringValue(objRE_Information.Lease_Term_Months).Replace(".00", "");
        txtDate_Sold.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Date_Sold);
        txtPrior_Lease_Commencement_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Prior_Lease_Commencement_Date);
        lblSubTenantPriorLeaseDate.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Prior_Lease_Commencement_Date);
        lblRentProjectionsPriorLeaseDate.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Prior_Lease_Commencement_Date);
        txtRenewals.Text = objRE_Information.Renewals;
        //txtYear_Built.Text = objRE_Information.Year_Built.ToString();
        txtReminder_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Reminder_Date);
        if (objRE_Information.Reminder_Date != null)
            lblReviewDate.Text = clsGeneral.FormatDateToDisplay(((DateTime)objRE_Information.Reminder_Date).AddDays(-365));
        else
            lblReviewDate.Text = "";
        txtYear_Remodeled.Text = objRE_Information.Year_Remodeled.ToString();
        txtLandlord_Notification_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Landlord_Notification_Date);
        txtRegional_Vice_President.Text = objRE_Information.Regional_Vice_President;
        hdnRegional_Vice_President.Value = txtRegional_Vice_President.Text;
        txtRegionalController.Text = objRE_Information.Regional_Controller;
        hdnRegionalController.Value = txtRegionalController.Text;
        txtVacate_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Vacate_Date);
        txtGeneral_Manager.Text = objRE_Information.General_Manager;
        txtPrimary_Use.Text = objRE_Information.Primary_Use;
        txtController.Text = objRE_Information.Controller;
        txtLease_Codes.Text = objRE_Information.Lease_Codes;
        txtLoss_Control_Manager.Text = objRE_Information.Loss_Control_Manager;
        hdnLoss_Control_Manager.Value = txtLoss_Control_Manager.Text;
        txtTotal_Acres.Text = clsGeneral.GetStringValue(objRE_Information.Total_Acres);
        txtNumber_of_Buildings.Text = clsGeneral.GetStringValue(objRE_Information.Number_of_Buildings).Replace(".00", "");
        txtTotal_Gross_Leaseable_Area.Text = clsGeneral.GetStringValue(objRE_Information.Total_Gross_Leaseable_Area);
        txtLand_Value.Text = clsGeneral.GetStringValue(objRE_Information.Land_Value).Replace(".00", "");
        txtLandlordLegalEntity.Text = objRE_Information.Landlord_Legal_Entity;
        txtAmendmentInfo.Text = objRE_Information.Amendment_Info;
        txtAssignementInfo.Text = objRE_Information.Assignment_Info;

        #endregion

        #region " Bind Lease Maint Obligation Information "

        if (objRE_Information.FK_HVAC_Capital != null)
            drpFK_HVAC_Capital.SelectedValue = objRE_Information.FK_HVAC_Capital.ToString();
        else
            drpFK_HVAC_Capital.SelectedIndex = 0;

        if (objRE_Information.FK_HVAC_Repairs != null)
            drpFK_HVAC_Repairs.SelectedValue = objRE_Information.FK_HVAC_Repairs.ToString();
        else
            drpFK_HVAC_Repairs.SelectedIndex = 0;

        if (objRE_Information.FK_Roof_Capital != null)
            drpFK_Roof_Capital.SelectedValue = objRE_Information.FK_Roof_Capital.ToString();
        else
            drpFK_Roof_Capital.SelectedIndex = 0;

        if (objRE_Information.FK_Roof_Repairs != null)
            drpFK_Roof_Repairs.SelectedValue = objRE_Information.FK_Roof_Repairs.ToString();
        else
            drpFK_Roof_Repairs.SelectedIndex = 0;

        txtOtherRepairs.Text = objRE_Information.Other_Repairs;
        txtMaintenanceNotes.Text = objRE_Information.Maintenance_Notes;

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
            txtRentDetails.Text = objRE_Rent.Rent_Details;
            txtRentAdjustment.Text = objRE_Rent.Rent_Adjustments;
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
        //if (_PK_RE_Subtenant > 0)
        //{
        //    // create object for RE_Subtenant record
        //    RE_Subtenant objRE_Subtenant = new RE_Subtenant(_PK_RE_Subtenant);

        //    //set values in page controls
        //    txtSubtenant_DBA.Text = objRE_Subtenant.Subtenant_DBA;
        //    txtSubtenant_Mailing_Address1.Text = objRE_Subtenant.Subtenant_Mailing_Address1;
        //    txtSubtenant_Mailing_Address2.Text = objRE_Subtenant.Subtenant_Mailing_Address2;
        //    txtSubtenant_Mailing_City.Text = objRE_Subtenant.Subtenant_Mailing_City;
        //    txtSubtenant_Mailing_Zip_Code.Text = objRE_Subtenant.Subtenant_Mailing_Zip_Code;
        //    if (objRE_Subtenant.PK_Subtenant_Mailing_State != null) drpSubtenantMailingState.SelectedValue = objRE_Subtenant.PK_Subtenant_Mailing_State.ToString();
        //    txtSubtenantTelephone.Text = objRE_Subtenant.Subtenant_Telephone;
        //    lblSubTenantLeaseCommencementDate.Text = txtLease_Commencement_Date.Text;
        //    lblSubTenantLeaseTerm.Text = txtLease_Term_Months.Text;
        //    lblSubTenantLeaseExpDate.Text = txtLease_Expiration_Date.Text;
        //    lblSubTenantPriorLeaseDate.Text = txtPrior_Lease_Commencement_Date.Text;
        //    txtCancel_OptionsSubtenant.Text = objRE_Subtenant.Cancel_Options;
        //    txtRenew_OptionsSubtenant.Text = objRE_Subtenant.Renew_Options;
        //    txtOpen_NotificationSubtenant.Text = objRE_Subtenant.Option_Notification;
        //    txtNotification_Due_DateSubtenant.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Subtenant.Notification_Due_Date);
        //    txtSubtenant_Base_RentSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Subtenant_Base_Rent);
        //    txtSubtenant_Monthly_RentSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Subtenant_Monthly_Rent);
        //    txtSecurityDeposit.Text = clsGeneral.GetStringValue(objRE_Subtenant.Security_Deposit);
        //    if (objRE_Subtenant.FK_LU_Escalation != null) drpFK_LU_EscalationSubtenant.SelectedValue = objRE_Subtenant.FK_LU_Escalation.ToString();
        //    if (drpFK_LU_EscalationSubtenant.SelectedItem.Text == "LIBOR Rate Schedule")
        //    {
        //        txtPercentage_RateSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Percentage_Rate);
        //        txtPercentage_RateSubtenant.Enabled = true;
        //    }
        //    txtIncreaseSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Increase);
        //    txtSubLease_Commencement_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Subtenant.Sublease_Commencement_Date);
        //    txtSubLease_Expiration_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Subtenant.Sublease_Expiration_Date);
        //    txtOther_Requirements.Text = objRE_Subtenant.Other_Requirements;
        //}
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


        // set attachment details control in read/write mode. so user can add or remove attachment as well.
        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.RE_Information, (int)_PK_RE_Information, true, 10);
        // bind attachment details to show attachment for current risk profile.
        BindAttachmentDetails();
        //((Button)AttachDetails.FindControl("btnRemoveAttachment")).Visible = App_Access == AccessType.Administrative_Access;

        BindGrids();
        //btnAddAttachment.Enabled = true;
        //Attachment.ShowAttachmentButton = true;
    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        ShowHideAuditButtons(true);
        // show hide div conrols for edit mode
        dvView.Style["display"] = "block";
        dvBack.Style["display"] = "block";
        dvEdit.Style["display"] = "none";
        dvSave.Style["display"] = "none";
        lnkAddNew.Visible = false;

        btnAbstractReport.Visible = false;
        btnAbstractReportView.Visible = true;

        // set all PKs
        DataTable dtPKs = RE_Information.GetPKofAllChildTables(_PK_RE_Information).Tables[0];
        if (dtPKs.Rows.Count > 0)
        {
            _PK_RE_Rent = Convert.ToDecimal(dtPKs.Rows[0]["PK_RE_Rent"]);
            _PK_RE_Subtenant = Convert.ToDecimal(dtPKs.Rows[0]["RE_Subtenant"]);
            _PK_RE_Rent_Projections = Convert.ToDecimal(dtPKs.Rows[0]["RE_Rent_Projections"]);
            _PK_RE_Security_Deposit = Convert.ToDecimal(dtPKs.Rows[0]["RE_Security_Deposit"]);
            _PK_RE_Surrender_Obligations = Convert.ToDecimal(dtPKs.Rows[0]["RE_Surrender_Obligations"]);
            _PK_RE_Notices = Convert.ToDecimal(dtPKs.Rows[0]["RE_Notices"]);
        }

        #region " Bind Real Estate Information "

        // create object for RE_Information record
        RE_Information objRE_Information = new RE_Information(_PK_RE_Information);

        BindPropertyInfo();
        //lblFederal_Id.Text = objRE_Information.Federal_Id;

        // Check if Building is selected for 
        if (objRE_Information.FK_Building_ID.HasValue)
        {
            Building objbuilding = new Building((int)objRE_Information.FK_Building_ID);
            lblFK_LU_Status.Text = objbuilding.Location_Status;
        }
        else
            lblFK_LU_Status.Text = "";

        lblTax_Parcel_Number.Text = objRE_Information.Tax_Parcel_Number;

        //if (objRE_Information.FK_LU_Lease_Type != null) lblFK_LU_Lease_Type.Text = new LU_Lease_Type((decimal)objRE_Information.FK_LU_Lease_Type).Fld_Desc;
        lblLandlord.Text = objRE_Information.Landlord;
        lblLandlord_Location_Address1.Text = objRE_Information.Landlord_Location_Address1;
        lblLandlord_Location_Address2.Text = objRE_Information.Landlord_Location_Address2;
        lblLandlord_Location_City.Text = objRE_Information.Landlord_Location_City;
        if (objRE_Information.PK_Landlord_Location_State != null)
            lblLandlordLocationState.Text = new State((decimal)objRE_Information.PK_Landlord_Location_State).FLD_state;
        else
            lblLandlordLocationState.Text = "";
        lblLandlord_Location_Zip_Code.Text = objRE_Information.Landlord_Location_Zip_Code;
        lblLandlord_Mailing_Address1.Text = objRE_Information.Landlord_Mailing_Address1;
        lblLandlord_Mailing_Address2.Text = objRE_Information.Landlord_Mailing_Address2;
        lblLandlord_Mailing_City.Text = objRE_Information.Landlord_Mailing_City;
        if (objRE_Information.PK_Landlord_Mailing_State != null)
            lblLandlordMailingState.Text = new State((decimal)objRE_Information.PK_Landlord_Mailing_State).FLD_state;
        else
            lblLandlordMailingState.Text = "";
        lblLandlord_Mailing_Zip_Code.Text = objRE_Information.Landlord_Mailing_Zip_Code;
        lblLandlord_Telephone.Text = objRE_Information.Landlord_Telephone;
        lblLandlord_Email.Text = objRE_Information.Landlord_Email;
        lblSublease.Text = objRE_Information.Sublease == "Y" ? "Yes" : "No";
        lblSubtenant.Text = objRE_Information.Subtenant;
        lblLease_Id.Text = objRE_Information.Lease_Id;
        lblLease_Commencement_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Commencement_Date);
        lblSubtenantLeaseCommencementDateView.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Commencement_Date);
        lblRentProjectionsLeaseCommencementDateView.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Commencement_Date);
        if (objRE_Information.FK_LU_Project_Type != null) lblFK_LU_Project_Type.Text = new LU_Project_Type((decimal)objRE_Information.FK_LU_Project_Type).Fld_Desc;
        lblLease_Expiration_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Expiration_Date);
        lblSubtenantLeaseExpDateView.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Expiration_Date);
        lblRentProjectionsLeaseExpDateView.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Lease_Expiration_Date);
        lblDate_Acquired.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Date_Acquired);
        lblLease_Term_Months.Text = clsGeneral.GetStringValue(objRE_Information.Lease_Term_Months).Replace(".00", "");
        lblSubtenantLeaseTermView.Text = clsGeneral.GetStringValue(objRE_Information.Lease_Term_Months).Replace(".00", "");
        lblRentProjectionsLeaseTermView.Text = clsGeneral.GetStringValue(objRE_Information.Lease_Term_Months).Replace(".00", "");
        lblDate_Sold.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Date_Sold);
        lblPrior_Lease_Commencement_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Prior_Lease_Commencement_Date);
        lblSubtenantPriorLeaseDateView.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Prior_Lease_Commencement_Date);
        lblRentProjectionsPriorLeaseDateView.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Prior_Lease_Commencement_Date);
        lblRenewals.Text = objRE_Information.Renewals;
        lblReminder_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Reminder_Date);
        if (objRE_Information.Reminder_Date != null)
            lblReviewDateView.Text = clsGeneral.FormatDateToDisplay(((DateTime)objRE_Information.Reminder_Date).AddDays(-365));
        else
            lblReviewDateView.Text = "";
        lblYear_Remodeled.Text = Convert.ToString(objRE_Information.Year_Remodeled);
        lblLandlord_Notification_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Landlord_Notification_Date);
        lblRegional_Vice_President.Text = objRE_Information.Regional_Vice_President;
        lblRegionalController.Text = objRE_Information.Regional_Controller;
        lblVacate_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Information.Vacate_Date);
        lblGeneral_Manager.Text = objRE_Information.General_Manager;
        lblPrimary_Use.Text = objRE_Information.Primary_Use;
        lblController.Text = objRE_Information.Controller;
        lblLease_Codes.Text = objRE_Information.Lease_Codes;
        lblLoss_Control_Manager.Text = objRE_Information.Loss_Control_Manager;
        lblTotal_Acres.Text = clsGeneral.GetStringValue(objRE_Information.Total_Acres);
        lblNumber_of_Buildings.Text = clsGeneral.GetStringValue(objRE_Information.Number_of_Buildings).Replace(".00", "");
        lblTotal_Gross_Leaseable_Area.Text = clsGeneral.GetStringValue(objRE_Information.Total_Gross_Leaseable_Area);
        lblLand_Value.Text = clsGeneral.GetStringValue(objRE_Information.Land_Value).Replace(".00", "");
        lblLandlordLegalEntity.Text = objRE_Information.Landlord_Legal_Entity;
        lblAmendmentInfo.Text = objRE_Information.Amendment_Info;
        lblAssignementInfo.Text = objRE_Information.Assignment_Info;
        #endregion

        #region " Bind Lease Maint Obligation Information "

        if (objRE_Information.FK_HVAC_Capital != null) lblHVACCapital.Text = new LU_HVAC_Capital((decimal)objRE_Information.FK_HVAC_Capital).Description;
        if (objRE_Information.FK_HVAC_Repairs != null) lblHVACRepairs.Text = new LU_HVAC_Repairs((decimal)objRE_Information.FK_HVAC_Repairs).Description;
        if (objRE_Information.FK_Roof_Capital != null) lblRoofCapital.Text = new LU_Roof_Capital((decimal)objRE_Information.FK_Roof_Capital).Description;
        if (objRE_Information.FK_Roof_Repairs != null) lblRoofRepairs.Text = new LU_Roof_Repairs((decimal)objRE_Information.FK_Roof_Repairs).Description;
        lblOtherRepairs.Text = objRE_Information.Other_Repairs;
        lblMaintenanceNotes.Text = objRE_Information.Maintenance_Notes;

        #endregion

        #region " Bind Rent Information "

        // check if PK for RE_Rent_Projections record is available
        if (_PK_RE_Rent > 0)
        {
            // create object for RE_Rent_Projections record
            RE_Rent objRE_Rent = new RE_Rent(_PK_RE_Rent);

            // set values in page controls
            lblResponsible_PartyRent.Text = objRE_Rent.Responsible_Party;
            lblRentLeaseCommencementDateView.Text = lblLease_Commencement_Date.Text;
            lblRentLeaseTermView.Text = lblLease_Term_Months.Text;
            lblRentLeaseExpDateView.Text = lblLease_Expiration_Date.Text;
            lblRentPriorLeaseDateView.Text = lblPrior_Lease_Commencement_Date.Text;
            lblCancel_OptionsRent.Text = objRE_Rent.Cancel_Options;
            lblRenew_OptionsRent.Text = objRE_Rent.Renew_Options;
            lblRentDetails.Text = objRE_Rent.Rent_Details;
            lblRentAdjustments.Text = objRE_Rent.Rent_Adjustments;
            lblNotification_Due_DateRent.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Rent.Notification_Due_Date);
            lblRentSubtenant_Base_Rent.Text = clsGeneral.GetStringValue(objRE_Rent.Subtenant_Base_Rent);
            lblRentSubtenant_Monthly_Rent.Text = clsGeneral.GetStringValue(objRE_Rent.Subtenant_Monthly_Rent);
            if (objRE_Rent.FK_LU_Escalation != null) lblFK_LU_EscalationRent.Text = new LU_Escalation((decimal)objRE_Rent.FK_LU_Escalation).Fld_Desc;
            lblPercentage_RateRent.Text = clsGeneral.GetStringValue(objRE_Rent.Percentage_Rate);
            lblIncreaseRent.Text = clsGeneral.GetStringValue(objRE_Rent.Increase);
        }
        #endregion

        #region " Bind Subtenant Information "

        // check if PK for RE_Subtenant record is available
        //if (_PK_RE_Subtenant > 0)
        //{
        //    // create object for RE_Subtenant record
        //    RE_Subtenant objRE_Subtenant = new RE_Subtenant(_PK_RE_Subtenant);

        //    // set values in page controls
        //    lblSubtenant_DBA.Text = objRE_Subtenant.Subtenant_DBA;
        //    lblSubtenant_Mailing_Address1.Text = objRE_Subtenant.Subtenant_Mailing_Address1;
        //    lblSubtenant_Mailing_Address2.Text = objRE_Subtenant.Subtenant_Mailing_Address2;
        //    lblSubtenant_Mailing_City.Text = objRE_Subtenant.Subtenant_Mailing_City;
        //    lblSubtenant_Mailing_Zip_Code.Text = objRE_Subtenant.Subtenant_Mailing_Zip_Code;
        //    if (objRE_Subtenant.PK_Subtenant_Mailing_State != null) lblSubtenantMailingState.Text = new State((decimal)objRE_Subtenant.PK_Subtenant_Mailing_State).FLD_state;
        //    lblSubtenantTelephone.Text = objRE_Subtenant.Subtenant_Telephone;
        //    lblSubtenantLeaseCommencementDateView.Text = lblLease_Commencement_Date.Text;
        //    lblSubtenantLeaseTermView.Text = lblLease_Term_Months.Text;
        //    lblSubtenantLeaseExpDateView.Text = lblLease_Expiration_Date.Text;
        //    lblSubtenantPriorLeaseDateView.Text = lblPrior_Lease_Commencement_Date.Text;
        //    lblCancel_OptionsSubtenant.Text = objRE_Subtenant.Cancel_Options;
        //    lblRenew_OptionsSubtenant.Text = objRE_Subtenant.Renew_Options;
        //    lblOpen_NotificationSubtenant.Text = objRE_Subtenant.Option_Notification;
        //    lblNotification_Due_DateSubtenant.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Subtenant.Notification_Due_Date);
        //    lblSubtenant_Base_RentSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Subtenant_Base_Rent);
        //    lblSecurityDeposit.Text = clsGeneral.GetStringValue(objRE_Subtenant.Security_Deposit);
        //    lblSubtenant_Monthly_RentSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Subtenant_Monthly_Rent);
        //    if (objRE_Subtenant.FK_LU_Escalation != null) lblFK_LU_EscalationSubtenant.Text = new LU_Escalation((decimal)objRE_Subtenant.FK_LU_Escalation).Fld_Desc;
        //    lblPercentage_RateSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Percentage_Rate);
        //    lblIncreaseSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Increase);
        //    lblSubleaseCommencementDate.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Subtenant.Sublease_Commencement_Date);
        //    lblSubleaseExpirationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Subtenant.Sublease_Expiration_Date);
        //    lblOtherRequirements.Text = objRE_Subtenant.Other_Requirements;
        //}
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

        // set attachment details control in readonly mode.
        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.RE_Information, (int)_PK_RE_Information, false, 9);

        // bind attachment details to show attachment for current risk profile.
        BindAttachmentDetails();

        if (App_Access == AccessType.View_Only)
            btnBack.Visible = false;

        BindGrids();
    }

    /// <summary>
    /// Binds the dropdown controls on page 
    /// </summary>
    private void BindDropDowns()
    {
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
        //DataTable dtLeaseType = LU_Lease_Type.SelectAll().Tables[0];
        //dtLeaseType.DefaultView.RowFilter = "Active = 'Y'";
        //dtLeaseType = dtLeaseType.DefaultView.ToTable();
        //drpFK_LU_Lease_Type.DataSource = dtLeaseType;
        //drpFK_LU_Lease_Type.DataTextField = "Fld_Desc";
        //drpFK_LU_Lease_Type.DataValueField = "PK_LU_Lease_Type";
        //drpFK_LU_Lease_Type.DataBind();
        //drpFK_LU_Lease_Type.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind all state dropdowns on page
        ComboHelper.FillState(new DropDownList[] { drpLandlord_Location_State, drpLandlordMailingState, drpSubtenantMailingState, 
            drpFK_State_Landlord, drpFK_State_Landlord_Copy, drpFK_State_Tenant, drpFK_State_Tenant_Copy, drpFK_State_Subtenant, 
            drpFK_State_Subtenant_Copy }, 0, true);

        // bind project type dropdown
        DataTable dtProjectType = LU_Project_Type.SelectAll().Tables[0];
        dtProjectType.DefaultView.RowFilter = "Active = 'Y'";
        dtProjectType = dtProjectType.DefaultView.ToTable();
        drpFK_LU_Project_Type.DataSource = dtProjectType;
        drpFK_LU_Project_Type.DataTextField = "Fld_Desc";
        drpFK_LU_Project_Type.DataValueField = "PK_LU_Project_Type";
        drpFK_LU_Project_Type.DataBind();
        drpFK_LU_Project_Type.Items.Insert(0, new ListItem("--Select--", "0"));

        DataTable dtEscalation = LU_Escalation.SelectAll().Tables[0];
        // bind Rent Escalation dropdown
        drpFK_LU_EscalationRent.DataSource = dtEscalation;
        drpFK_LU_EscalationRent.DataValueField = "PK_LU_Escalation";
        drpFK_LU_EscalationRent.DataTextField = "Fld_Desc";
        drpFK_LU_EscalationRent.DataBind();
        drpFK_LU_EscalationRent.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind subtenant Escalation dropdown

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

        // bind Roof Capital dropdown
        DataTable dtRoofCapital = LU_Roof_Capital.SelectAll().Tables[0];
        dtRoofCapital = dtRoofCapital.DefaultView.ToTable();
        drpFK_Roof_Capital.DataSource = dtRoofCapital;
        drpFK_Roof_Capital.DataTextField = "Description";
        drpFK_Roof_Capital.DataValueField = "PK_LU_Roof_Capital";
        drpFK_Roof_Capital.DataBind();
        drpFK_Roof_Capital.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind Roof Repairs dropdown
        DataTable dtRoofRepairs = LU_Roof_Repairs.SelectAll().Tables[0];
        dtRoofRepairs = dtRoofRepairs.DefaultView.ToTable();
        drpFK_Roof_Repairs.DataSource = dtRoofRepairs;
        drpFK_Roof_Repairs.DataTextField = "Description";
        drpFK_Roof_Repairs.DataValueField = "PK_LU_Roof_Repairs";
        drpFK_Roof_Repairs.DataBind();
        drpFK_Roof_Repairs.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind HVAC Repairs dropdown
        DataTable dtHVACRepairs = LU_HVAC_Repairs.SelectAll().Tables[0];
        dtHVACRepairs = dtHVACRepairs.DefaultView.ToTable();
        drpFK_HVAC_Repairs.DataSource = dtHVACRepairs;
        drpFK_HVAC_Repairs.DataTextField = "Description";
        drpFK_HVAC_Repairs.DataValueField = "PK_LU_HVAC_Repairs";
        drpFK_HVAC_Repairs.DataBind();
        drpFK_HVAC_Repairs.Items.Insert(0, new ListItem("--Select--", "0"));

        // bind HVAC Capital dropdown
        DataTable dtHVACCapital = LU_HVAC_Capital.SelectAll().Tables[0];
        dtHVACCapital = dtHVACCapital.DefaultView.ToTable();
        drpFK_HVAC_Capital.DataSource = dtHVACCapital;
        drpFK_HVAC_Capital.DataTextField = "Description";
        drpFK_HVAC_Capital.DataValueField = "PK_LU_HVAC_Capital";
        drpFK_HVAC_Capital.DataBind();
        drpFK_HVAC_Capital.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    /// <summary>
    /// Binds all the grids on page
    /// </summary>
    private void BindGrids()
    {
        BindBuildingGrid();
        BindRealEstateGrid();
        BindTRSRentGrid();
        BindRRSRentGrid();
        BindTRSSubtenantGrid();
        BindORSSubtenantGrid();
        BindTRSRentProjectionGrid();
        BindORSRentProjectionGrid();
        BindRepairMaintenanceGrid();
        BindNotesGrid();
        BindSubtenantGrid();
        BindSubtenanatViewGrid();
    }

    private void BindSubtenanatViewGrid()
    {
        DataTable dtSubtenant = RE_Subtenant.SelectByInformationID(_PK_RE_Information).Tables[0];
        gvSubtenanatView.DataSource = dtSubtenant;
        gvSubtenanatView.DataBind();
    }

    private void BindSubtenantGrid()
    {
        DataTable dtSubtenant = RE_Subtenant.SelectByInformationID(_PK_RE_Information).Tables[0];
        gvSubtenanat.DataSource = dtSubtenant;
        gvSubtenanat.DataBind();
    }

    private void BindBuildingGrid()
    {
        DataTable dtBuilding = RE_Building.SelectByFK_RE_Information(_PK_RE_Information).Tables[0];

        if (_StrOperation == "view")
        {
            gvBuildingView.DataSource = dtBuilding;
            gvBuildingView.DataBind();
        }
        else
        {
            gvBuilding.DataSource = dtBuilding;
            gvBuilding.DataBind();

            // Check User has not admin right then hide Delete column.
            if (App_Access != AccessType.Administrative_Access)
                gvBuilding.Columns[gvBuilding.Columns.Count - 1].Visible = false;
        }
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
    /// Binds the grid listing the RE_Inforamation records on top of the page
    /// </summary>
    private void BindRealEstateGrid()
    {
        // get the data from RE_Information table for the selected location
        DataTable dtRealEstate = RE_Information.SelectByFK_Location(FK_LU_Location_ID).Tables[0];

        // bind the grid
        gvRealEstate.DataSource = dtRealEstate;
        gvRealEstate.DataBind();

        // if page is in view mode then hide the column for Remove link
        if (_StrOperation == "view")
            gvRealEstate.Columns[gvRealEstate.Columns.Count - 1].Visible = false;

        // if logged in user has no full access then hide the column for Remove link
        if (App_Access != AccessType.Administrative_Access)
            gvRealEstate.Columns[gvRealEstate.Columns.Count - 1].Visible = false;
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
    private void SaveData(int intControlEvent, string strRedirectToAfterSave)
    {
        // check if the rent schedule grid records are available and lease commmencement date is not available then show error message
        if ((gvSubtenantORS.Rows.Count > 0 || gvSubtenantTRS.Rows.Count > 0 || gvRentProjectionORS.Rows.Count > 0 || gvRentProjectionTRS.Rows.Count > 0) && txtLease_Commencement_Date.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "alert('Please enter the [Real Estate Information]/Lease Commencement Date in order to manage the Rent schedule grid records.');ShowPanel(1);", true);
        }
        else if (gvBuilding.Rows.Count == 0 && intControlEvent != -1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "ShowPanel(1);alert('Please select at least one building record');", true);
        }
        else
        {
            #region " Save Real Estate Information "
            // create object for the RE_Information
            RE_Information objRE_Information = new RE_Information();

            // get values from page controls
            objRE_Information.PK_RE_Information = _PK_RE_Information;
            objRE_Information.FK_LU_Location = FK_LU_Location_ID;
            //if (hdnBuildingNumber.Value != "")
            //    objRE_Information.FK_Building_ID = Convert.ToDecimal(hdnBuildingNumber.Value);
            //objRE_Information.FK_LU_Location = Convert.ToDecimal(hdnLU_location.Value);
            //objRE_Information.Federal_Id = txtFederal_Id.Text.Trim();

            if (drpFK_LU_Status.SelectedIndex > 0)
                objRE_Information.FK_LU_Status = Convert.ToDecimal(drpFK_LU_Status.SelectedValue);

            objRE_Information.Tax_Parcel_Number = txtTax_Parcel_Number.Text.Trim();
            //if (drpFK_LU_Lease_Type.SelectedIndex > 0) objRE_Information.FK_LU_Lease_Type = Convert.ToDecimal(drpFK_LU_Lease_Type.SelectedValue);
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
            //if (txtYear_Built.Text != "") objRE_Information.Year_Built = clsGeneral.GetDecimalValue(txtYear_Built);
            objRE_Information.Reminder_Date = clsGeneral.FormatNullDateToStore(txtReminder_Date.Text);
            if (txtYear_Remodeled.Text != string.Empty) objRE_Information.Year_Remodeled = clsGeneral.GetDecimalValue(txtYear_Remodeled);
            objRE_Information.Landlord_Notification_Date = clsGeneral.FormatNullDateToStore(txtLandlord_Notification_Date.Text);
            objRE_Information.Regional_Vice_President = txtRegional_Vice_President.Text.Trim();
            objRE_Information.Regional_Controller = txtRegionalController.Text.Trim();
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

            objRE_Information.Landlord_Legal_Entity = txtLandlordLegalEntity.Text.Trim();
            objRE_Information.Amendment_Info = txtAmendmentInfo.Text.Trim();
            objRE_Information.Assignment_Info = txtAssignementInfo.Text.Trim();
            objRE_Information.Update_Date = DateTime.Now;
            objRE_Information.Updated_By = clsSession.UserID;

            if (drpFK_HVAC_Capital.SelectedIndex > 0)
                objRE_Information.FK_HVAC_Capital = Convert.ToDecimal(drpFK_HVAC_Capital.SelectedValue);

            if (drpFK_HVAC_Repairs.SelectedIndex > 0)
                objRE_Information.FK_HVAC_Repairs = Convert.ToDecimal(drpFK_HVAC_Repairs.SelectedValue);

            if (drpFK_Roof_Capital.SelectedIndex > 0)
                objRE_Information.FK_Roof_Capital = Convert.ToDecimal(drpFK_Roof_Capital.SelectedValue);

            if (drpFK_Roof_Repairs.SelectedIndex > 0)
                objRE_Information.FK_Roof_Repairs = Convert.ToDecimal(drpFK_Roof_Repairs.SelectedValue);

            objRE_Information.Other_Repairs = txtOtherRepairs.Text.Trim();
            objRE_Information.Maintenance_Notes = txtMaintenanceNotes.Text.Trim();

            // save the information as per the PK availability
            if (_PK_RE_Information > 0)
            {
                objRE_Information.Update();
                string strArgs = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];
                if (strArgs == "UpdateRLCMDetails")
                {
                    RE_Information.UpdateRLCMDetails(_PK_RE_Information);
                }
            }
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
            objRE_Rent.Rent_Adjustments = txtRentAdjustment.Text.Trim();
            if (txtRentSubtenant_Base_Rent.Text != "") objRE_Rent.Subtenant_Base_Rent = clsGeneral.GetDecimalValue(txtRentSubtenant_Base_Rent);
            if (txtRentSubtenant_Monthly_Rent.Text != "") objRE_Rent.Subtenant_Monthly_Rent = clsGeneral.GetDecimalValue(txtRentSubtenant_Monthly_Rent);
            if (drpFK_LU_EscalationRent.SelectedIndex > 0) objRE_Rent.FK_LU_Escalation = Convert.ToDecimal(drpFK_LU_EscalationRent.SelectedValue);
            if (txtPercentage_RateRent.Text != "") objRE_Rent.Percentage_Rate = clsGeneral.GetDecimalValue(txtPercentage_RateRent);
            if (txtIncreaseRent.Text != "") objRE_Rent.Increase = clsGeneral.GetDecimalValue(txtIncreaseRent);
            objRE_Rent.Update_Date = DateTime.Now;
            objRE_Rent.Updated_By = clsSession.UserID;
            objRE_Rent.Rent_Details = txtRentDetails.Text;

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
            //RE_Subtenant objRE_Subtenant = new RE_Subtenant();

            //// set FK and PK
            //objRE_Subtenant.PK_RE_Subtenant = _PK_RE_Subtenant;
            //objRE_Subtenant.FK_RE_Information = _PK_RE_Information;

            //// get values from page controls
            //objRE_Subtenant.Subtenant_DBA = txtSubtenant_DBA.Text.Trim();
            //objRE_Subtenant.Subtenant_Mailing_Address1 = txtSubtenant_Mailing_Address1.Text.Trim();
            //objRE_Subtenant.Subtenant_Mailing_Address2 = txtSubtenant_Mailing_Address2.Text.Trim();
            //objRE_Subtenant.Subtenant_Mailing_City = txtSubtenant_Mailing_City.Text.Trim();
            //if (drpSubtenantMailingState.SelectedIndex > 0) objRE_Subtenant.PK_Subtenant_Mailing_State = Convert.ToDecimal(drpSubtenantMailingState.SelectedValue);
            //objRE_Subtenant.Subtenant_Mailing_Zip_Code = txtSubtenant_Mailing_Zip_Code.Text.Trim();
            //objRE_Subtenant.Subtenant_Telephone = txtSubtenantTelephone.Text.Trim();
            //objRE_Subtenant.Cancel_Options = txtCancel_OptionsSubtenant.Text.Trim();
            //objRE_Subtenant.Renew_Options = txtRenew_OptionsSubtenant.Text.Trim();
            //objRE_Subtenant.Option_Notification = txtOpen_NotificationSubtenant.Text.Trim();
            //objRE_Subtenant.Notification_Due_Date = clsGeneral.FormatNullDateToStore(txtNotification_Due_DateSubtenant.Text);
            //if (txtSubtenant_Base_RentSubtenant.Text != "") objRE_Subtenant.Subtenant_Base_Rent = clsGeneral.GetDecimalValue(txtSubtenant_Base_RentSubtenant);
            //if (txtSubtenant_Monthly_RentSubtenant.Text != "") objRE_Subtenant.Subtenant_Monthly_Rent = clsGeneral.GetDecimalValue(txtSubtenant_Monthly_RentSubtenant);
            //if (txtSecurityDeposit.Text != "") objRE_Subtenant.Security_Deposit = clsGeneral.GetDecimalValue(txtSecurityDeposit);
            //if (drpFK_LU_EscalationSubtenant.SelectedIndex > 0) objRE_Subtenant.FK_LU_Escalation = Convert.ToDecimal(drpFK_LU_EscalationSubtenant.SelectedValue);
            //if (txtPercentage_RateSubtenant.Text != "") objRE_Subtenant.Percentage_Rate = clsGeneral.GetDecimalValue(txtPercentage_RateSubtenant);
            //if (txtIncreaseSubtenant.Text != "") objRE_Subtenant.Increase = clsGeneral.GetDecimalValue(txtIncreaseSubtenant);
            //objRE_Subtenant.Update_Date = DateTime.Now;
            //objRE_Subtenant.Updated_By = clsSession.UserID;
            //objRE_Subtenant.Sublease_Commencement_Date = clsGeneral.FormatNullDateToStore(txtSubLease_Commencement_Date.Text);
            //objRE_Subtenant.Sublease_Expiration_Date = clsGeneral.FormatNullDateToStore(txtSubLease_Expiration_Date.Text);
            //objRE_Subtenant.Other_Requirements = txtOther_Requirements.Text.Trim();

            //// save record as per the PK availability
            //if (_PK_RE_Subtenant > 0)
            //    objRE_Subtenant.Update();
            //else
            //    _PK_RE_Subtenant = objRE_Subtenant.Insert();

            //// update the Rent Schedule information from the grids
            //bool bRentSubtenantSuccess = UpdateRentScheduleInfo_Subtenant();

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

            try
            {
                // add attachment if any.
                Attachment.Add(clsGeneral.Tables.RE_Information, (int)_PK_RE_Information);
            }
            catch { }

            // set PK value in session
            clsSession.Current_RE_Information_ID = _PK_RE_Information;

            // set flag if error found for rent projection or subtenant info
            string strError = "";
            if (!bRentSuccess) strError = "RentError";
            //if (!bRentSubtenantSuccess) strError = "SubtenantError";
            if (!bRentProjectionSuccess) strError = "RentProjectionError";

            // if any error is not generated
            if (strError == "")
            {
                // save data and reload the page with view mode if Save button is clicked
                if (intControlEvent == 1)
                {
                    _StrOperation = "view";
                    BindDetailsForView();
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
                    clsSession.Str_RE_Operation = "view";
                }
                else if (intControlEvent > 0)
                {
                    // set operation flag to edit in session and redirect to the page url passed
                    clsSession.Str_RE_Operation = "edit";
                    Response.Redirect(strRedirectToAfterSave);
                }
            }
            else
            {
                // display error message depending on the error found
                if (strError == "RentError")
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "alert('The Rent Schedule Grids records for Rent Information could not be saved. Please provide proper data.');ShowPanel(2);", true);
                else if (strError == "SubtenantError")
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "alert('The Rent Schedule Grids records for Subtenant Information could not be saved. Please provide proper data.');ShowPanel(3);", true);
                else
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "alert('The Rent Schedule Grids records for Rent Projections could not be saved. Please provide proper data.');ShowPanel(4);", true);
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
                    RE_Rent_TRS.UpdateRents(Convert.ToDecimal(hdnPK.Value), Convert.ToDecimal(lnkMonthlyRent.Text), Convert.ToDecimal(lnkAdditions.Text), Convert.ToDecimal(hdnPercentage.Value));
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
                    RE_Rent_RRS.UpdateRents(Convert.ToDecimal(hdnPK.Value), Convert.ToDecimal(lnkMonthlyRent.Text));
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

    /// <summary>
    /// Displays the information to be copied from the Property module
    /// </summary> 
    private void BindPropertyInfo()
    {
        bool bValid = true; // denotes whether it is valid to bind the info or not

        // if page is in add mode
        if (_StrOperation.ToLower() != "edit" && _StrOperation.ToLower() != "view")
        {
            // check whether the records for Property, Building, Building_Owenership and lease commencement date are available
            DataTable dt = RE_Information.CheckValidations(FK_LU_Location_ID).Tables[0];
            DataRow dr = dt.Rows[0];

            // if all information is not available 
            if (Convert.ToBoolean(dr["AvailableAll"]) == false)
            {
                // then hide all page controls
                bValid = false;
                pnlEditViewLeaseInfo.Style["display"] = "none";
                tblMsg.Style["display"] = "block";
                lnkAddNew.Visible = false;

                // display error message for the information that is not available
                lblMsg.Text = "The following Property module data must be entered to gain access to the Lease module for the selected location:<br />";
                if (Convert.ToBoolean(dr["Propety_COPE_Avail"]) == false)
                    lblMsg.Text += "<br />Property COPE";
                if (Convert.ToBoolean(dr["Building_Avail"]) == false)
                    lblMsg.Text += "<br />Building";
                if (Convert.ToBoolean(dr["Ownership_Avail"]) == false)
                    lblMsg.Text += "<br />Building Ownership";
                if (Convert.ToBoolean(dr["CommencementDate_Avail"]) == false)
                    lblMsg.Text += "<br />Commencement Date on Building Ownership";
            }
        }

        // if valid to bind the information
        if (bValid)
        {
            // create object for LU_location 
            LU_Location objLU_Location = new LU_Location(Convert.ToDecimal(FK_LU_Location_ID));

            // get PK of Proeprty record by location
            int PK_Property_Cope_ID = Property_COPE.SelectPKByLocation(FK_LU_Location_ID);

            // if PK is available
            if (PK_Property_Cope_ID > 0)
            {
                // get property information
                Property_COPE objPropety_Cope = new Property_COPE(PK_Property_Cope_ID);
                string strStatus = string.Empty;
                if (_PK_RE_Information > 0)
                {
                    RE_Information ObjReInfo = new RE_Information(_PK_RE_Information);
                    if (ObjReInfo.FK_Building_ID.HasValue)
                    {
                        Building objBuilding = new Building((int)ObjReInfo.FK_Building_ID.Value);
                        strStatus = objBuilding.Location_Status;
                    }
                }
                // set values in fields in either view or edit mode depending on the current mode
                if (_StrOperation == "view")
                {
                    lblFK_LU_Location.Text = objLU_Location.dba;
                    //lblLegalEntity.Text = objLU_Location.legal_entity;
                    lblAddress1.Text = objPropety_Cope.Address_1;
                    lblAddress2.Text = objPropety_Cope.Address_2;
                    lblCity.Text = objPropety_Cope.City;
                    lblState.Text = objPropety_Cope.State;
                    lblZipCode.Text = objPropety_Cope.Zip;
                    lblTelephone.Text = objPropety_Cope.Telephone;
                    lblCounty.Text = objLU_Location.County;
                    lblRegion.Text = objLU_Location.Region;
                    lblParentCompanyLegalEntity.Text = objLU_Location.Parent_Company_LE;
                    lblParentCompanyLegalEntityFEIN.Text = objLU_Location.Parent_Company_LE_FEIN;
                    lblLegalEntityOperations.Text = objLU_Location.LE_Operations;
                    lblLegalEntityOperationsFEIN.Text = objLU_Location.LE_Operations_FEIN;
                    lblLegalEntityProperties.Text = objLU_Location.LE_Properties;
                    lblLegalEntityPropertiesFEIN.Text = objLU_Location.LE_Properties_FEIN;
                }
                else
                {
                    txtLU_Location.Text = objLU_Location.dba;

                    ListItem lst = drpFK_LU_Status.Items.FindByText(strStatus);
                    if (lst != null)
                    {
                        drpFK_LU_Status.ClearSelection();
                        lst.Selected = true;

                    }
                    //txtLegalEntity.Text = objLU_Location.legal_entity;
                    txtAddress1.Text = objPropety_Cope.Address_1;
                    txtAddress2.Text = objPropety_Cope.Address_2;
                    txtCity.Text = objPropety_Cope.City;
                    txtState.Text = objPropety_Cope.State;
                    txtZipCode.Text = objPropety_Cope.Zip;
                    txtTelephone.Text = objPropety_Cope.Telephone;
                    txtRegion.Text = objLU_Location.Region;
                    txtCounty.Text = objLU_Location.County;
                    txtParentCompanyLegalEntity.Text = objLU_Location.Parent_Company_LE;
                    txtParentCompanyLegalEntityFEIN.Text = objLU_Location.Parent_Company_LE_FEIN;
                    txtLegalEntityOperations.Text = objLU_Location.LE_Operations;
                    txtLegalEntityOperationsFEIN.Text = objLU_Location.LE_Operations_FEIN;
                    txtLegalEntityProperties.Text = objLU_Location.LE_Properties;
                    txtLegalEntityPropertiesFEIN.Text = objLU_Location.LE_Properties_FEIN;
                }
            }
        }
    }

    /// <summary>
    /// Calculates monthly rent in all Rent Schedule grids when Lease date is changed
    /// </summary>
    private void CalculateRentsOnLeaseDateChanged()
    {
        // set the labels text for commencement date on subtenant and rent projection page
        lblSubTenantLeaseCommencementDate.Text = txtLease_Commencement_Date.Text;
        lblRentProjectionsLeaseCommencementDate.Text = txtLease_Commencement_Date.Text;

        bool bValid = true; // denotes whether valid to calculate the values or not

        bValid = IsValidORSFromDate(gvRentRRS);

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
                {
                    // clear the lease commencement date and show error message for rent projection grid's "From date" column
                    txtLease_Commencement_Date.Text = "";
                    ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowMessageLeaseDateError('RentProjection');", true);
                }
            }
            else
            {
                // clear the lease commencement date and show error message for rent projection grid's "From date" column
                txtLease_Commencement_Date.Text = "";
                ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowMessageLeaseDateError('Subtenant');", true);
            }
        }
        else
        {
            // clear the lease commencement date and show error message for rent projection grid's "From date" column
            txtLease_Commencement_Date.Text = "";
            ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:ShowMessageLeaseDateError('Rent');", true);
        }

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

    /// <summary>
    /// Sets the lease information on the Subtenant Information and Rent Projection panel     
    /// </summary>
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

    private void ShowHideAuditButtons(bool bShow)
    {
        btnRE_Information_Audit.Visible = bShow;
        btnSubtenantAudit.Visible = bShow;
        btnRentProjAudit.Visible = bShow;
        btnSecurityDeposit.Visible = bShow;
        btnSurrenderObligationAudit.Visible = bShow;
        btnNoticesAudit.Visible = bShow;
        btnRE_Rent_Audit.Visible = bShow;
    }

    private void SaveSubtenanatInformation()
    {
        RE_Subtenant objRE_Subtenant = new RE_Subtenant(_PK_RE_Subtenant);

        // set FK and PK
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
        if (txtSecurityDeposit.Text != "") objRE_Subtenant.Security_Deposit = clsGeneral.GetDecimalValue(txtSecurityDeposit);
        if (drpFK_LU_EscalationSubtenant.SelectedIndex > 0) objRE_Subtenant.FK_LU_Escalation = Convert.ToDecimal(drpFK_LU_EscalationSubtenant.SelectedValue);
        if (txtPercentage_RateSubtenant.Text != "") objRE_Subtenant.Percentage_Rate = clsGeneral.GetDecimalValue(txtPercentage_RateSubtenant);
        if (txtIncreaseSubtenant.Text != "") objRE_Subtenant.Increase = clsGeneral.GetDecimalValue(txtIncreaseSubtenant);
        objRE_Subtenant.Update_Date = DateTime.Now;
        objRE_Subtenant.Updated_By = clsSession.UserID;
        objRE_Subtenant.Sublease_Commencement_Date = clsGeneral.FormatNullDateToStore(txtSubLease_Commencement_Date.Text);
        objRE_Subtenant.Sublease_Expiration_Date = clsGeneral.FormatNullDateToStore(txtSubLease_Expiration_Date.Text);
        objRE_Subtenant.Other_Requirements = txtOther_Requirements.Text.Trim();

        // save record as per the PK availability
        if (_PK_RE_Subtenant > 0)
            objRE_Subtenant.Update();
        else
            _PK_RE_Subtenant = objRE_Subtenant.Insert();
        bool bRentSubtenantSuccess = UpdateRentScheduleInfo_Subtenant();
        dvAttachment.Style["display"] = "none";
        tblSubtenant.Style["display"] = "none";
        BindSubtenantGrid();
        ShowPanel(3);
    }

    #endregion

    #region Control Events

    /// <summary>
    /// Handles event of hidden button click after selecting the recoed from popup
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSelectBuildingOwnership_Click(object sender, EventArgs e)
    {
        BindBuildingGrid();
        DataTable dtLandlord = RE_Information.SelectLandlordDetails(_PK_RE_Information).Tables[0];
        if (dtLandlord.Rows.Count > 0)
        {
            DataRow dr = dtLandlord.Rows[0];
            txtLandlord.Text = Convert.ToString(dr["Landlord_Name"]);

            // check if the radio button Sublease has selected "No"
            // and set the lanlord and other information as per that
            if (rdoSublease.SelectedValue == "N")
                txtSubtenant_DBA.Text = "";
            else
                txtSubtenant_DBA.Text = Convert.ToString(dr["Sublease"]);

            // set the values like address and lease information 
            txtLandlordLegalEntity.Text = Convert.ToString(dr["Landlord_Legal_Entity"]);
            txtLandlord_Location_Address1.Text = Convert.ToString(dr["Landlord_Address_1"]);
            txtLandlord_Location_Address2.Text = Convert.ToString(dr["Landlord_Address_2"]);
            txtLandlord_Location_City.Text = Convert.ToString(dr["Landlord_City"]);
            drpLandlord_Location_State.ClearSelection();
            ListItem lst = drpLandlord_Location_State.Items.FindByText(Convert.ToString(dr["Landlord_State"]));
            if (lst != null) lst.Selected = true;
            txtLandlord_Location_Zip_Code.Text = Convert.ToString(dr["Landlord_Zip"]);
            txtLease_Id.Text = Convert.ToString(dr["Lease_Id"]);
            txtLease_Commencement_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dr["Commencement_Date"]);
            txtLease_Expiration_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dr["Expiration_Date"]);

            ListItem liStatus = drpFK_LU_Status.Items.FindByText(Convert.ToString(dr["Location_status"]));
            if (liStatus != null)
            {
                drpFK_LU_Status.ClearSelection();
                liStatus.Selected = true;
            }

            SetLeaseInformation();

            // if lease commencement date is available then calculate the monthly rents on all grids
            if (txtLease_Commencement_Date.Text != "")
            {
                CalculateRentsOnLeaseDateChanged();
            }
            else
                ShowPanel(1);
        }
        else
        {
            txtLandlord.Text = txtSubtenant_DBA.Text = txtLandlordLegalEntity.Text = txtLandlord_Location_Address1.Text = txtLandlord_Location_Address2.Text = "";
            txtLandlord_Location_City.Text = txtLandlord_Location_Zip_Code.Text = txtLease_Id.Text = txtLease_Commencement_Date.Text = txtLease_Expiration_Date.Text = "";
            drpFK_LU_Status.ClearSelection();
            drpLandlord_Location_State.ClearSelection();
        }
    }

    protected void btnSelectSubLease_OnClick(object sender, EventArgs e)
    {
        BindSubtenantGrid();
        ShowPanel(3);
    }

    protected void lnkAddBuilding_Click(object sender, EventArgs e)
    {
        if (_PK_RE_Information == 0)
            SaveData(-1, "");

        ScriptManager.RegisterStartupScript(Page, typeof(string), DateTime.Now.ToString(), "javascript:OpenBuildingPopup('" + Encryption.Encrypt(_PK_RE_Information.ToString()) + "');", true);

    }

    protected void lnkAddSubtenant_Click(object sender, EventArgs e)
    {
        if (_PK_RE_Information == 0)
            SaveData(-1, "");
        ScriptManager.RegisterStartupScript(Page, typeof(string), DateTime.Now.ToString(), "javascript:OpenSubLeasePopup('" + Encryption.Encrypt(_PK_RE_Information.ToString()) + "');", true);
        dvAttachment.Style["display"] = "none";
        gvSubtenanat.Visible = true;
        tblSubtenant.Style["display"] = "none";
        ShowPanel(3);
    }

    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // save the page data
        SaveData(1, "");
    }

    /// <summary>
    /// Sub Lease radio button index changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdoSublease_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoSublease.SelectedValue == "Y")
        {
            if (_PK_RE_Information > 0)
            {
                RE_Information objRE_Information = new RE_Information(_PK_RE_Information);
                if (objRE_Information.FK_Building_ID > 0)
                {
                    Building objBuilding = new Building(Convert.ToInt32(objRE_Information.FK_Building_ID));
                    if (objRE_Information.Sublease == "Y")
                    {
                        int PK_Building_Ownership = Building_Ownership.SelectPKByBuildingID(Convert.ToInt32(objRE_Information.FK_Building_ID));
                        Building_Ownership objOwnership = new Building_Ownership(PK_Building_Ownership);

                        txtSubtenant_DBA.Text = objOwnership.Sublease_Name;
                    }
                    else
                        txtSubtenant_DBA.Text = "";
                }
            }
            else
                txtSubtenant_DBA.Text = "";
        }
        else
            txtSubtenant_DBA.Text = "";

        ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    /// <summary>
    /// Handles Back button click in view mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // set operation flag to edit along with the session 
        _StrOperation = "edit";
        clsSession.Str_RE_Operation = "edit";
        SetValidations();
        SetVadidationForSubLease();
        // show page in edit mode
        BindDetailsForEdit();
        gvRealEstate.Columns[gvRealEstate.Columns.Count - 1].Visible = true;
        ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
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
        {
            txtPercentage_RateRent.Enabled = true;
            Span45.Style["display"] = "block";
        }
        else
        {
            txtPercentage_RateRent.Enabled = false;
            Span45.Style["display"] = "none";
        }

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
        {
            txtPercentage_RateSubtenant.Enabled = true;
            Span169.Style["display"] = "block";
        }
        else
        {
            txtPercentage_RateSubtenant.Enabled = false;
            Span169.Style["display"] = "none";
        }

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
        {
            txtPercentage_Rate.Enabled = true;
            Span170.Style["display"] = "block";
        }
        else
        {
            txtPercentage_Rate.Enabled = false;
            Span170.Style["display"] = "none";
        }

        SetLeaseInformation();

        ShowPanel(4);
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
        SaveData(2, "RentTRS.aspx" + "?loc=" + Request.QueryString["loc"]);
    }

    protected void lnkAddRRSRent_Click(object sender, EventArgs e)
    {
        // save data and redirect to Subtenant Option Rent Schedule page with edit mode
        SaveData(2, "RentRRS.aspx" + "?loc=" + Request.QueryString["loc"]);

    }

    /// <summary>
    /// Handles Add link click for Term Rent Schedule Grid on Subtenant Information panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddTRSSubTenant_Click(object sender, EventArgs e)
    {
        SaveSubtenanatInformation();
        // save data and redirect to Subtenant Term Rent Schedule page with edit mode
        SaveData(2, AppConfig.SiteURL + "SONIC/RealEstate/SubtenantTRS.aspx?loc=" + Request.QueryString["loc"] + "&Subtenant=" + Encryption.Encrypt(Convert.ToString(_PK_RE_Subtenant)));
    }

    /// <summary>
    /// Handles Add link click for Option Rent Schedule Grid on Subtenant Information panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddORSSubTenant_Click(object sender, EventArgs e)
    {
        SaveSubtenanatInformation();
        // save data and redirect to Subtenant Option Rent Schedule page with edit mode
        SaveData(4, AppConfig.SiteURL + "SONIC/RealEstate/SubtenantORS.aspx?loc=" + Request.QueryString["loc"] + "&Subtenant=" + Encryption.Encrypt(Convert.ToString(_PK_RE_Subtenant)));
    }

    /// <summary>
    /// Handles Add link click for Term Rent Schedule Grid on Rent Projections page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddTRSRentProjection_Click(object sender, EventArgs e)
    {
        // save data and redirect to Subtenant Term Rent Schedule page with edit mode
        SaveData(6, AppConfig.SiteURL + "SONIC/RealEstate/RentProjectionTRS.aspx?loc=" + Request.QueryString["loc"]);
    }

    /// <summary>
    /// Handles Add link click for option Rent Schedule Grid on Rent Projections page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddORSRentProjection_Click(object sender, EventArgs e)
    {
        // save data and redirect to Subtenant Option Rent Schedule page with edit mode
        SaveData(8, AppConfig.SiteURL + "SONIC/RealEstate/RentProjectionORS.aspx?loc=" + Request.QueryString["loc"]);
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

        ShowPanel(4);
    }

    /// <summary>
    /// Handles Add link click event for Notes grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNotes_Click(object sender, EventArgs e)
    {
        // save data and redirect to Notes page with edit mode
        SaveData(10, AppConfig.SiteURL + "SONIC/RealEstate/RE_InformationNotes.aspx?loc=" + Request.QueryString["loc"]);
    }

    /// <summary>
    /// Handles Add link click event for Repair Maintenance grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddRepairMaint_Click(object sender, EventArgs e)
    {
        // save data and redirect to Repair Maintenance page with edit mode
        SaveData(12, AppConfig.SiteURL + "SONIC/RealEstate/RepairMantenance.aspx?loc=" + Request.QueryString["loc"]);
    }

    /// <summary>
    /// Handles Add new link click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        // intialize all PKs to zero
        _PK_RE_Information = 0;
        _PK_RE_Rent = 0;
        _PK_RE_Subtenant = 0;
        _PK_RE_Rent_Projections = 0;
        _PK_RE_Security_Deposit = 0;
        _PK_RE_Surrender_Obligations = 0;
        _PK_RE_Notices = 0;

        ShowHideAuditButtons(false);
        // clear page controls
        #region " Clear Real Estate Information "
        drpFK_LU_Status.SelectedIndex = 0;
        lblFK_LU_Status.Text = "";
        //txtFederal_Id.Text = "";
        txtTax_Parcel_Number.Text = "";
        //hdnBuildingNumber.Value = "";
        //txtBuildingNumber.Text = "";
        //txtBuildingAddress1.Text = "";
        //txtBuildingAddress2.Text = "";
        //txtBuildingCity.Text = "";
        //txtBuildingState.Text = "";
        //txtBuildingZipCode.Text = "";
        //drpFK_LU_Lease_Type.SelectedValue = "0";
        txtLandlord.Text = "";
        txtLandlordLegalEntity.Text = "";
        txtLandlord_Location_Address1.Text = "";
        txtLandlord_Location_Address2.Text = "";
        txtLandlord_Location_City.Text = "";
        drpLandlord_Location_State.SelectedValue = "0";
        txtLandlord_Location_Zip_Code.Text = "";
        txtLandlord_Mailing_Address1.Text = "";
        txtLandlord_Mailing_Address2.Text = "";
        txtLandlord_Mailing_City.Text = "";
        drpLandlordMailingState.SelectedValue = "0";
        txtLandlord_Mailing_Zip_Code.Text = "";
        txtLandlord_Telephone.Text = "";
        txtLandlord_Email.Text = "";
        rdoSublease.SelectedValue = "N";
        txtSubtenant.Text = "";
        txtLease_Id.Text = "";
        txtLease_Commencement_Date.Text = "";
        drpFK_LU_Project_Type.SelectedValue = "0";
        txtLease_Expiration_Date.Text = "";
        txtDate_Acquired.Text = "";
        txtLease_Term_Months.Text = "";
        txtDate_Sold.Text = "";
        txtPrior_Lease_Commencement_Date.Text = "";
        txtRenewals.Text = "";
        //txtYear_Built.Text = "";
        txtReminder_Date.Text = "";
        lblReviewDate.Text = "";
        txtYear_Remodeled.Text = "";
        txtLandlord_Notification_Date.Text = "";
        txtRegional_Vice_President.Text = "";
        txtRegionalController.Text = "";
        txtVacate_Date.Text = "";
        txtGeneral_Manager.Text = "";
        txtPrimary_Use.Text = "";
        txtController.Text = "";
        txtLease_Codes.Text = "";
        txtLoss_Control_Manager.Text = "";
        txtTotal_Acres.Text = "";
        txtNumber_of_Buildings.Text = "";
        txtTotal_Gross_Leaseable_Area.Text = "";
        txtLand_Value.Text = "";

        #endregion

        #region " Clear Rent Information "
        txtResponsible_PartyRent.Text = "";
        lblRentLeaseCommencementDate.Text = "";
        lblRentLeaseTerm.Text = "";
        lblRentLeaseExpDate.Text = "";
        lblRentPriorLeaseDate.Text = "";
        txtCancel_OptionsRent.Text = "";
        txtRenew_OptionsRent.Text = "";
        txtRentAdjustment.Text = "";
        txtNotification_Due_DateRent.Text = "";
        txtRentSubtenant_Base_Rent.Text = "";
        txtRentSubtenant_Monthly_Rent.Text = "";
        drpFK_LU_EscalationRent.SelectedIndex = 0;
        txtPercentage_RateRent.Text = "";
        txtIncreaseRent.Text = "";
        txtRentDetails.Text = "";

        #endregion

        #region " Clear Subtenant Information "

        txtSubtenant_DBA.Text = "";
        txtSubtenant_Mailing_Address1.Text = "";
        txtSubtenant_Mailing_Address2.Text = "";
        txtSubtenant_Mailing_City.Text = "";
        txtSubtenant_Mailing_Zip_Code.Text = "";
        drpSubtenantMailingState.SelectedValue = "0";
        txtSubtenantTelephone.Text = "";
        lblSubTenantLeaseCommencementDate.Text = "";
        lblSubTenantLeaseTerm.Text = "";
        lblSubTenantLeaseExpDate.Text = "";
        lblSubTenantPriorLeaseDate.Text = "";
        txtCancel_OptionsSubtenant.Text = "";
        txtRenew_OptionsSubtenant.Text = "";
        txtOpen_NotificationSubtenant.Text = "";
        txtNotification_Due_DateSubtenant.Text = "";
        txtSubtenant_Base_RentSubtenant.Text = "";
        txtSubtenant_Monthly_RentSubtenant.Text = "";
        txtSecurityDeposit.Text = "";
        drpFK_LU_EscalationSubtenant.SelectedValue = "0";
        txtPercentage_RateSubtenant.Text = "";
        txtPercentage_RateSubtenant.Enabled = false;
        txtIncreaseSubtenant.Text = "";
        // set labels for lease information 
        lblSubTenantLeaseCommencementDate.Text = "";
        lblSubTenantLeaseTerm.Text = "";
        lblSubTenantLeaseExpDate.Text = "";
        lblSubTenantPriorLeaseDate.Text = "";

        #endregion

        #region " Clear Rent Projections Information "

        txtResponsible_Party.Text = "";
        lblRentProjectionsLeaseCommencementDate.Text = "";
        lblRentProjectionsLeaseTerm.Text = "";
        lblRentProjectionsLeaseExpDate.Text = "";
        lblRentProjectionsPriorLeaseDate.Text = "";
        txtCancel_Options.Text = "";
        txtRenew_Options.Text = "";
        txtOpen_Notification.Text = "";
        txtNotification_Due_Date.Text = "";
        txtSubtenant_Base_Rent.Text = "";
        txtSubtenant_Monthly_Rent.Text = "";
        drpFK_LU_Escalation.SelectedValue = "0";
        txtPercentage_Rate.Text = "";
        txtPercentage_Rate.Enabled = false;
        txtIncrease.Text = "";
        lblRentProjectionsLeaseCommencementDate.Text = "";
        lblRentProjectionsLeaseTerm.Text = "";
        lblRentProjectionsLeaseExpDate.Text = "";
        lblRentProjectionsPriorLeaseDate.Text = "";

        #endregion

        #region " Clear Security Deposit Information "

        txtAmount.Text = "";
        txtDate_Of_Security_Deposit.Text = "";
        drpFK_LU_Tender_Type.SelectedValue = "0";
        txtReceived_By.Text = "";
        txtBank_Name.Text = "";
        txtCheck_Number.Text = "";
        txtName_On_Check.Text = "";
        txtAccount_Number.Text = "";
        drpFK_LU_Security_Deposit_Held.SelectedValue = "0";
        rdoSecurity_Deposit_Returned.SelectedValue = "N";
        txtDate_Security_Deposit_Returned.Text = "";
        rdoSecurity_Deposit_Reduced.SelectedValue = "N";
        txtSecurity_Deposit_Reduction_Reason.Text = "";
        rdoInterest_On_Security_Deposit.SelectedValue = "N";
        txtInterest_Amount.Text = "";
        txtAmount_Security_Deposit_Returned.Text = "";

        #endregion

        #region " Clear Surrender Obligations Information "

        txtCondition_At_Commencement.Text = "";
        txtPermitted_Use.Text = "";
        txtAlterations.Text = "";
        txtTenants_Obligations.Text = "";
        txtEnvironmental_Matters.Text = "";
        txtLandlords_Obligations.Text = "";

        #endregion

        #region " Clear Notices Information "

        txtLandlord_Company.Text = "";
        txtLandlord_Contact.Text = "";
        txtLandlord_Address1.Text = "";
        txtLandlord_Address2.Text = "";
        txtLandlord_City.Text = "";
        drpFK_State_Landlord.SelectedValue = "0";
        txtLandlord_Zip_Code.Text = "";
        txtLandlord_TelephoneNotices.Text = "";
        txtLandlord_Facsimile.Text = "";
        txtLandlord_EmailNotices.Text = "";
        txtLandlord_Copy_Company.Text = "";
        txtLandlord_Copy_Contact.Text = "";
        txtLandlord_Copy_Address1.Text = "";
        txtLandlord_Copy_Address2.Text = "";
        txtLandlord_Copy_City.Text = "";
        drpFK_State_Landlord_Copy.SelectedValue = "0";
        txtLandlord_Copy_Zip_Code.Text = "";
        txtLandlord_Copy_Telephone.Text = "";
        txtLandlord_Copy_Facsimile.Text = "";
        txtLandlord_Copy_Email.Text = "";
        txtTenant_Company.Text = "";
        txtTenant_Contact.Text = "";
        txtTenant_Address1.Text = "";
        txtTenant_Address2.Text = "";
        txtTenant_City.Text = "";
        drpFK_State_Tenant.SelectedValue = "0";
        txtTenant_Zip_Code.Text = "";
        txtTenant_Telephone.Text = "";
        txtTenant_Facsimile.Text = "";
        txtTenant_Email.Text = "";
        txtTenant_Copy_Company.Text = "";
        txtTenant_Copy_Contact.Text = "";
        txtTenant_Copy_Address1.Text = "";
        txtTenant_Copy_Address2.Text = "";
        txtTenant_Copy_City.Text = "";
        drpFK_State_Tenant_Copy.SelectedValue = "0";
        txtTenant_Copy_Zip_Code.Text = "";
        txtTenant_Copy_Telephone.Text = "";
        txtTenant_Copy_Facsimile.Text = "";
        txtTenant_Copy_Email.Text = "";
        txtSubtenant_Company.Text = "";
        txtSubtenant_Contact.Text = "";
        txtSubtenant_Address1.Text = "";
        txtSubtenant_Address2.Text = "";
        txtSubtenant_City.Text = "";
        drpFK_State_Subtenant.SelectedValue = "0";
        txtSubtenant_Zip_Code.Text = "";
        txtSubtenant_Telephone.Text = "";
        txtSubtenant_Facsimile.Text = "";
        txtSubtenant_Email.Text = "";
        txtSubtenant_Copy_Company.Text = "";
        txtSubtenant_Copy_Contact.Text = "";
        txtSubtenant_Copy_Address1.Text = "";
        txtSubtenant_Copy_Address2.Text = "";
        txtSubtenant_Copy_City.Text = "";
        drpFK_State_Subtenant_Copy.SelectedValue = "0";
        txtSubtenant_Copy_Zip_Code.Text = "";
        txtSubtenant_Copy_Telephone.Text = "";
        txtSubtenant_Copy_Facsimile.Text = "";
        txtSubtenant_Copy_Email.Text = "";

        #endregion

        BindGrids();
        // set attachment details control in editable mode.
        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.RE_Information, (int)_PK_RE_Information, false, 9);

        // bind attachment details to show attachment for current risk profile.
        BindAttachmentDetails();
        //btnAddAttachment.Enabled = false;
        Attachment.ShowAttachmentButton = false;
        ScriptManager.RegisterStartupScript(Page, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    protected void btnSaveSubtenantInformation_OnClick(object sender, EventArgs e)
    {
        SaveSubtenanatInformation();
    }

    protected void btnCancelSubtenantInformation_OnClick(object sender, EventArgs e)
    {
        dvAttachment.Style["display"] = "none";
        tblSubtenant.Style["display"] = "none";
        BindSubtenantGrid();
        ShowPanel(3);
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

    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        if (_PK_RE_Information > 0)
        {
            SetLeaseInformation();
            // add attachment if any.
            Attachment.Add(clsGeneral.Tables.RE_Information, (int)_PK_RE_Information);
            // Bind the attachment detail to view the added attachment
            BindAttachmentDetails();
            // show attachment panel as the page is loaded again
            ScriptManager.RegisterStartupScript(Page, typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(10);", true);
        }
    }

    /// <summary>
    /// handles Add Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Upload_File(string strValue)
    {
        if (_PK_RE_Information > 0)
        {
            SetLeaseInformation();
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
                SaveData(2, "RentTRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
            else
                Response.Redirect("RentTRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
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
                SaveData(2, "RentRRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
            else
                Response.Redirect("RentRRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
        }
        else if (e.CommandName == "RemoveRRS") // if command is for removing the record
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
            // if page is in edit mode then save page data and redirect to Subtenant TRS page
            // else redirect to Subtenant TRS page without saving the record
            if (_StrOperation == "edit")
                SaveData(3, AppConfig.SiteURL + "SONIC/RealEstate/SubtenantTRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
            else
                Response.Redirect(AppConfig.SiteURL + "SONIC/RealEstate/SubtenantTRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
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
            // if page is in edit mode then save page data and redirect to Subtenant ORS page
            // else redirect to Subtenant ORS page without saving the record
            if (_StrOperation == "edit")
                SaveData(5, AppConfig.SiteURL + "SONIC/RealEstate/SubtenantORS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
            else
                Response.Redirect(AppConfig.SiteURL + "SONIC/RealEstate/SubtenantORS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
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
            // if page is in edit mode then save page data and redirect to Rent Projection TRS page
            // else redirect to Rent Projection TRS page without saving the record
            if (_StrOperation == "edit")
                SaveData(7, AppConfig.SiteURL + "SONIC/RealEstate/RentProjectionTRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
            else
                Response.Redirect(AppConfig.SiteURL + "SONIC/RealEstate/RentProjectionTRS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
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
            // if page is in edit mode then save page data and redirect to Rent Projection ORS page
            // else redirect to Rent Projection ORS page without saving the record
            if (_StrOperation == "edit")
                SaveData(9, AppConfig.SiteURL + "SONIC/RealEstate/RentProjectionORS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
            else
                Response.Redirect(AppConfig.SiteURL + "SONIC/RealEstate/RentProjectionORS.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
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
            // if page is in edit mode then save page data and redirect to Repair Mantenance page
            // else redirect to Repair Mantenance page without saving the record
            if (_StrOperation == "edit")
                SaveData(11, AppConfig.SiteURL + "SONIC/RealEstate/RepairMantenance.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
            else
                Response.Redirect(AppConfig.SiteURL + "SONIC/RealEstate/RepairMantenance.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
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
            // if page is in edit mode then save page data and redirect to Notes page
            // else redirect to Notes page without saving the record
            if (_StrOperation == "edit")
                SaveData(13, AppConfig.SiteURL + "SONIC/RealEstate/RE_InformationNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
            else
                Response.Redirect(AppConfig.SiteURL + "SONIC/RealEstate/RE_InformationNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"]);
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

    protected void gvSubtenant_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewSubTenantDetails")
        {
            _PK_RE_Subtenant = Convert.ToInt32(e.CommandArgument);
            if (_PK_RE_Subtenant > 0)
                BindSubtenantForEdit();
            ShowPanel(3);
            BindSubtenantGrid();
        }

        if (e.CommandName == "RemoveSubtenant")
        {
            RE_Subtenant.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindSubtenantGrid();
            dvAttachment.Style["display"] = "none";
            tblSubtenant.Style["display"] = "none";
            ShowPanel(3);
        }
    }

    private void BindSubtenantForEdit()
    {
        RE_Subtenant objRE_Subtenant = new RE_Subtenant(_PK_RE_Subtenant);
        //set values in page controls
        txtSubtenant_DBA.Text = objRE_Subtenant.Subtenant_DBA;
        txtSubtenant_Mailing_Address1.Text = objRE_Subtenant.Subtenant_Mailing_Address1;
        txtSubtenant_Mailing_Address2.Text = objRE_Subtenant.Subtenant_Mailing_Address2;
        txtSubtenant_Mailing_City.Text = objRE_Subtenant.Subtenant_Mailing_City;
        txtSubtenant_Mailing_Zip_Code.Text = objRE_Subtenant.Subtenant_Mailing_Zip_Code;
        if (objRE_Subtenant.PK_Subtenant_Mailing_State != null){drpSubtenantMailingState.SelectedValue = objRE_Subtenant.PK_Subtenant_Mailing_State.ToString();}
        else{drpSubtenantMailingState.SelectedIndex = 0;}
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
        txtSecurityDeposit.Text = clsGeneral.GetStringValue(objRE_Subtenant.Security_Deposit);
        if (objRE_Subtenant.FK_LU_Escalation != null) { drpFK_LU_EscalationSubtenant.SelectedValue = objRE_Subtenant.FK_LU_Escalation.ToString(); }
        else { drpFK_LU_EscalationSubtenant.SelectedIndex = 0; }
        if (drpFK_LU_EscalationSubtenant.SelectedItem.Text == "LIBOR Rate Schedule")
        {
            txtPercentage_RateSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Percentage_Rate);
            txtPercentage_RateSubtenant.Enabled = true;
        }
        txtIncreaseSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Increase);
        txtSubLease_Commencement_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Subtenant.Sublease_Commencement_Date);
        txtSubLease_Expiration_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Subtenant.Sublease_Expiration_Date);
        txtOther_Requirements.Text = objRE_Subtenant.Other_Requirements;
        BindORSSubtenantGrid();
        BindTRSSubtenantGrid();
        pnl3.Style["display"] = "";
        tblSubtenant.Style["display"] = "";
        dvAttachment.Style["display"] = "none";

    }

    protected void gvSubtenantView_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewSubTenantDetails")
        {
            _PK_RE_Subtenant = Convert.ToInt32(e.CommandArgument);
            if (_PK_RE_Subtenant > 0)
                BindSubtenantForView();
            BindSubtenanatViewGrid();
            ShowPanel(3);
        }
    }

    private void BindSubtenantForView()
    {
        RE_Subtenant objRE_Subtenant = new RE_Subtenant(_PK_RE_Subtenant);
        lblSubtenant_DBA.Text = objRE_Subtenant.Subtenant_DBA;
        lblSubtenant_Mailing_Address1.Text = objRE_Subtenant.Subtenant_Mailing_Address1;
        lblSubtenant_Mailing_Address2.Text = objRE_Subtenant.Subtenant_Mailing_Address2;
        lblSubtenant_Mailing_City.Text = objRE_Subtenant.Subtenant_Mailing_City;
        lblSubtenant_Mailing_Zip_Code.Text = objRE_Subtenant.Subtenant_Mailing_Zip_Code;
        if (objRE_Subtenant.PK_Subtenant_Mailing_State != null)
        {
            lblSubtenantMailingState.Text = new State((decimal)objRE_Subtenant.PK_Subtenant_Mailing_State).FLD_state;
        }
        else
        {
            lblSubtenantMailingState.Text = "";
        }

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
        lblSecurityDeposit.Text = clsGeneral.GetStringValue(objRE_Subtenant.Security_Deposit);
        lblSubtenant_Monthly_RentSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Subtenant_Monthly_Rent);
        if (objRE_Subtenant.FK_LU_Escalation != null)
        {
            lblFK_LU_EscalationSubtenant.Text = new LU_Escalation((decimal)objRE_Subtenant.FK_LU_Escalation).Fld_Desc;
        }
        else
        {
            lblFK_LU_EscalationSubtenant.Text = "";
        }
        lblPercentage_RateSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Percentage_Rate);
        lblIncreaseSubtenant.Text = clsGeneral.GetStringValue(objRE_Subtenant.Increase);
        lblSubleaseCommencementDate.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Subtenant.Sublease_Commencement_Date);
        lblSubleaseExpirationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Subtenant.Sublease_Expiration_Date);
        lblOtherRequirements.Text = objRE_Subtenant.Other_Requirements;
        BindORSSubtenantGrid();
        BindTRSSubtenantGrid();
        pnl3View.Style["display"] = "";
        tblSubtenantView.Style["display"] = "";
        BindSubtenanatViewGrid();
    }

    /// <summary>
    /// Handles event when links are clicked on gvRealEstate grid on top of the page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRealEstate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if command is "ShowDetails" 
        if (e.CommandName == "ShowDetails")
        {
            // get PK passed in command argument and store in session
            _PK_RE_Information = Convert.ToDecimal(e.CommandArgument.ToString());
            clsSession.Current_RE_Information_ID = _PK_RE_Information;
            // bind page controls in view or edit based on current page mode
            if (_StrOperation == "edit")
                BindDetailsForEdit();
            else
                BindDetailsForView();

            ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
        else if (e.CommandName == "RemoveLease") // if command is for removing the record
        {
            // set the lease information labels 
            SetLeaseInformation();

            // delete the record from RE_Information and other tables that referring it
            RE_Information.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            // bind the grid again
            BindRealEstateGrid();

            // if current PK is equal to the PK of the record removed then call add new link click to clear information
            if (_PK_RE_Information == Convert.ToDecimal(e.CommandArgument))
                lnkAddNew_Click(null, null);
            else
                ShowPanel(1);
        }
    }

    /// <summary>
    /// Handles event when page link is clicked on gvRealEstate grid on top of the page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRealEstate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // set the lease information labels        
        ShowPanel(1);
        SetLeaseInformation();

        // set the new grid page number and bind the grid
        gvRealEstate.PageIndex = e.NewPageIndex;
        BindRealEstateGrid();
    }

    protected void gvBuilding_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveBuilding")
        {
            _PK_RE_Building = Convert.ToDecimal(e.CommandArgument);
            RE_Building.DeleteByPK(_PK_RE_Building);
            btnSelectBuildingOwnership_Click(null, null);
            ShowPanel(1);
        }
    }
    #endregion

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region "Lease Information"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(68).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        // set menu 1 asterisk display
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 68").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                //case "Federal Id":
                //    strCtrlsIDs += txtFederal_Id.ClientID + ",";
                //    strMessages += "Please enter [Lease Information]/Federal Id" + ",";
                //    Span1.Style["display"] = "inline-block";
                //    break;
                case "Landlord Mailing Address 1":
                    strCtrlsIDs += txtLandlord_Mailing_Address1.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Landlord Mailing Address 1" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Landlord Mailing Address 2":
                    strCtrlsIDs += txtLandlord_Mailing_Address2.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Landlord Mailing Address 2" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Landlord Mailing City":
                    strCtrlsIDs += txtLandlord_Mailing_City.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Landlord Mailing City" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Landlord Mailing State":
                    strCtrlsIDs += drpLandlordMailingState.ClientID + ",";
                    strMessages += "Please select [Lease Information]/Landlord Mailing State" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Landlord Mailing Zip Code":
                    strCtrlsIDs += txtLandlord_Mailing_Zip_Code.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Landlord Mailing Zip Code" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Landlord Telephone":
                    strCtrlsIDs += txtLandlord_Telephone.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Landlord Telephone" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Landlord E-Mail":
                    strCtrlsIDs += txtLandlord_Email.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Landlord E-Mail" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Subtenant":
                    strCtrlsIDs += txtSubtenant.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Subtenant" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Project Type":
                    strCtrlsIDs += drpFK_LU_Project_Type.ClientID + ",";
                    strMessages += "Please select [Lease Information]/Project Type" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Date Acquired":
                    strCtrlsIDs += txtDate_Acquired.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Date Acquired" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Lease Term In Months":
                    strCtrlsIDs += txtLease_Term_Months.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Lease Term In Months" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Date Sold":
                    strCtrlsIDs += txtDate_Sold.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Date Sold" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "Prior Lease Commencement Date":
                    strCtrlsIDs += txtPrior_Lease_Commencement_Date.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Prior Lease Commencement Date" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "Renewals":
                    strCtrlsIDs += txtRenewals.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Renewals" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                case "Year Remodeled":
                    strCtrlsIDs += txtYear_Remodeled.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Year Remodeled" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                case "Reminder Date":
                    strCtrlsIDs += txtReminder_Date.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Reminder Date" + ",";
                    Span17.Style["display"] = "inline-block";
                    break;
                case "Regional Vice President":
                    strCtrlsIDs += txtRegional_Vice_President.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Regional Vice President" + ",";
                    Span18.Style["display"] = "inline-block";
                    break;
                case "Landlord Notification Date":
                    strCtrlsIDs += txtLandlord_Notification_Date.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Landlord Notification Date" + ",";
                    Span19.Style["display"] = "inline-block";
                    break;
                case "General Manager":
                    strCtrlsIDs += txtGeneral_Manager.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/General Manager" + ",";
                    Span20.Style["display"] = "inline-block";
                    break;
                case "Vacate Date":
                    strCtrlsIDs += txtVacate_Date.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Vacate Date" + ",";
                    Span21.Style["display"] = "inline-block";
                    break;
                case "Controller":
                    strCtrlsIDs += txtController.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Controller" + ",";
                    Span22.Style["display"] = "inline-block";
                    break;
                case "Primary Use":
                    strCtrlsIDs += txtPrimary_Use.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Primary Use" + ",";
                    Span23.Style["display"] = "inline-block";
                    break;
                case "Loss Control Manager":
                    strCtrlsIDs += txtLoss_Control_Manager.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Loss Control Manager" + ",";
                    Span24.Style["display"] = "inline-block";
                    break;
                case "Lease Codes":
                    strCtrlsIDs += txtLease_Codes.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Lease Codes" + ",";
                    Span25.Style["display"] = "inline-block";
                    break;
                case "Total Acres":
                    strCtrlsIDs += txtTotal_Acres.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Total Acres" + ",";
                    Span26.Style["display"] = "inline-block";
                    break;
                case "Number of Buildings":
                    strCtrlsIDs += txtNumber_of_Buildings.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Number of Buildings" + ",";
                    Span27.Style["display"] = "inline-block";
                    break;
                case "Total Gross Leasable Area (square feet)":
                    strCtrlsIDs += txtTotal_Gross_Leaseable_Area.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Total Gross Leasable Area (square feet)" + ",";
                    Span28.Style["display"] = "inline-block";
                    break;
                case "Land Value":
                    strCtrlsIDs += txtLand_Value.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Land Value" + ",";
                    Span29.Style["display"] = "inline-block";
                    break;
                case "Amendment Info":
                    strCtrlsIDs += txtAmendmentInfo.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Amendment Info" + ",";
                    Span30.Style["display"] = "inline-block";
                    break;
                case "Assignment Info":
                    strCtrlsIDs += txtAssignementInfo.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Assignment Info" + ",";
                    Span31.Style["display"] = "inline-block";
                    break;
                case "Tax Parcel Number":
                    strCtrlsIDs += txtTax_Parcel_Number.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Tax Parcel Number" + ",";
                    Span33.Style["display"] = "inline-block";
                    break;
                case "Regional Controller":
                    strCtrlsIDs += txtRegionalController.ClientID + ",";
                    strMessages += "Please enter [Lease Information]/Regional Controller" + ",";
                    Span35.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Rent"
        dtFields = clsScreen_Validators.SelectByScreen(69).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        // set menu 1 asterisk display
        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 69").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Responsible Party":
                    strCtrlsIDs += txtResponsible_PartyRent.ClientID + ",";
                    strMessages += "Please enter [Rent]/Responsible Party" + ",";
                    Span32.Style["display"] = "inline-block";
                    break;
                case "Cancel Options":
                    strCtrlsIDs += txtCancel_OptionsRent.ClientID + ",";
                    strMessages += "Please enter [Rent]/Cancel Options" + ",";
                    Span37.Style["display"] = "inline-block";
                    break;
                case "Renewal Options":
                    strCtrlsIDs += txtRenew_OptionsRent.ClientID + ",";
                    strMessages += "Please enter [Rent]/Renewal Options" + ",";
                    Span38.Style["display"] = "inline-block";
                    break;
                case "Renewal Notification Due Date":
                    strCtrlsIDs += txtNotification_Due_DateRent.ClientID + ",";
                    strMessages += "Please enter [Rent]/Renewal Notification Due Date" + ",";
                    Span39.Style["display"] = "inline-block";
                    break;
                case "Annual Rent":
                    strCtrlsIDs += txtRentSubtenant_Base_Rent.ClientID + ",";
                    strMessages += "Please enter [Rent]/Annual Rent" + ",";
                    Span40.Style["display"] = "inline-block";
                    break;
                case "Monthly Rent":
                    strCtrlsIDs += txtRentSubtenant_Monthly_Rent.ClientID + ",";
                    strMessages += "Please enter [Rent]/Monthly Rent" + ",";
                    Span41.Style["display"] = "inline-block";
                    break;
                case "Rent Details":
                    strCtrlsIDs += txtRentDetails.ClientID + ",";
                    strMessages += "Please enter [Rent]/Rent Details" + ",";
                    Span42.Style["display"] = "inline-block";
                    break;
                case "Rent Adjustments":
                    strCtrlsIDs += txtRentAdjustment.ClientID + ",";
                    strMessages += "Please enter [Rent]/Rent Adjustments" + ",";
                    Span43.Style["display"] = "inline-block";
                    break;
                case "Escalation":
                    strCtrlsIDs += drpFK_LU_EscalationRent.ClientID + ",";
                    strMessages += "Please select [Rent]/Escalation" + ",";
                    Span44.Style["display"] = "inline-block";
                    break;
                case "Percentage Rate":
                    strCtrlsIDs += txtPercentage_RateRent.ClientID + ",";
                    strMessages += "Please enter [Rent]/Percentage Rate" + ",";
                    Span45.Style["display"] = "inline-block";
                    break;
                case "Increase Amount":
                    strCtrlsIDs += txtIncreaseRent.ClientID + ",";
                    strMessages += "Please enter [Rent]/Increase Amount" + ",";
                    Span46.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Rent Projections"
        dtFields = clsScreen_Validators.SelectByScreen(71).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        // set menu 1 asterisk display
        MenuAsterisk4.Style["display"] = (dtFields.Select("LeftMenuIndex = 71").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Responsible Party":
                    strCtrlsIDs += txtResponsible_Party.ClientID + ",";
                    strMessages += "Please enter [Rent Projections]/Responsible Party" + ",";
                    Span69.Style["display"] = "inline-block";
                    break;
                case "Cancel Details":
                    strCtrlsIDs += txtCancel_Options.ClientID + ",";
                    strMessages += "Please enter [Rent Projections]/Cancel Details" + ",";
                    Span70.Style["display"] = "inline-block";
                    break;
                case "Renew Options":
                    strCtrlsIDs += txtRenew_Options.ClientID + ",";
                    strMessages += "Please enter [Rent Projections]/Renew Options" + ",";
                    Span71.Style["display"] = "inline-block";
                    break;
                case "Option Notification":
                    strCtrlsIDs += txtOpen_Notification.ClientID + ",";
                    strMessages += "Please enter [Rent Projections]/Option Notification" + ",";
                    Span72.Style["display"] = "inline-block";
                    break;
                case "Notification Due Date":
                    strCtrlsIDs += txtNotification_Due_Date.ClientID + ",";
                    strMessages += "Please enter [Rent Projections]/Notification Due Date" + ",";
                    Span73.Style["display"] = "inline-block";
                    break;
                case "Subtenant Base Rent":
                    strCtrlsIDs += txtSubtenant_Base_Rent.ClientID + ",";
                    strMessages += "Please enter [Rent Projections]/Subtenant Base Rent" + ",";
                    Span74.Style["display"] = "inline-block";
                    break;
                case "Subtenant Monthly Rent":
                    strCtrlsIDs += txtSubtenant_Monthly_Rent.ClientID + ",";
                    strMessages += "Please enter [Rent Projections]/Subtenant Monthly Rent" + ",";
                    Span75.Style["display"] = "inline-block";
                    break;
                case "Escalation":
                    strCtrlsIDs += drpFK_LU_Escalation.ClientID + ",";
                    strMessages += "Please enter [Rent Projections]/Escalation" + ",";
                    Span76.Style["display"] = "inline-block";
                    break;
                case "Increase":
                    strCtrlsIDs += txtIncrease.ClientID + ",";
                    strMessages += "Please enter [Rent Projections]/Increase" + ",";
                    Span77.Style["display"] = "inline-block";
                    break;
                case "Percentage Rate":
                    strCtrlsIDs += txtPercentage_Rate.ClientID + ",";
                    strMessages += "Please enter [Rent Projections]/Percentage Rate" + ",";
                    Span170.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Security Deposit"
        dtFields = clsScreen_Validators.SelectByScreen(72).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        // set menu 1 asterisk display
        MenuAsterisk5.Style["display"] = (dtFields.Select("LeftMenuIndex = 72").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Amount":
                    strCtrlsIDs += txtAmount.ClientID + ",";
                    strMessages += "Please enter [Security Deposit]/Amount" + ",";
                    Span78.Style["display"] = "inline-block";
                    break;
                case "Date of Security Deposit":
                    strCtrlsIDs += txtDate_Of_Security_Deposit.ClientID + ",";
                    strMessages += "Please enter [Security Deposit]/Date of Security Deposit" + ",";
                    Span79.Style["display"] = "inline-block";
                    break;
                case "Tender Type":
                    strCtrlsIDs += drpFK_LU_Tender_Type.ClientID + ",";
                    strMessages += "Please select [Security Deposit]/Tender Type" + ",";
                    Span80.Style["display"] = "inline-block";
                    break;
                case "Received By":
                    strCtrlsIDs += txtReceived_By.ClientID + ",";
                    strMessages += "Please enter [Security Deposit]/Received By" + ",";
                    Span81.Style["display"] = "inline-block";
                    break;
                case "Bank Name the Check was Drawn Against":
                    strCtrlsIDs += txtBank_Name.ClientID + ",";
                    strMessages += "Please enter [Security Deposit]/Bank Name the Check was Drawn Against" + ",";
                    Span82.Style["display"] = "inline-block";
                    break;
                case "Check Number":
                    strCtrlsIDs += txtCheck_Number.ClientID + ",";
                    strMessages += "Please enter [Security Deposit]/Check Number" + ",";
                    Span83.Style["display"] = "inline-block";
                    break;
                case "Name Printed on Check":
                    strCtrlsIDs += txtName_On_Check.ClientID + ",";
                    strMessages += "Please enter [Security Deposit]/Name Printed on Check" + ",";
                    Span84.Style["display"] = "inline-block";
                    break;
                case "Account Number":
                    strCtrlsIDs += txtAccount_Number.ClientID + ",";
                    strMessages += "Please enter [Security Deposit]/Account Number" + ",";
                    Span85.Style["display"] = "inline-block";
                    break;
                case "Security Deposit Held At":
                    strCtrlsIDs += drpFK_LU_Security_Deposit_Held.ClientID + ",";
                    strMessages += "Please select [Security Deposit]/Security Deposit Held At" + ",";
                    Span86.Style["display"] = "inline-block";
                    break;
                case "Date Security Deposit Returned":
                    strCtrlsIDs += txtDate_Security_Deposit_Returned.ClientID + ",";
                    strMessages += "Please enter [Security Deposit]/Date Security Deposit Returned" + ",";
                    Span88.Style["display"] = "inline-block";
                    break;
                case "Reason for Security Deposit Reduction":
                    strCtrlsIDs += txtSecurity_Deposit_Reduction_Reason.ClientID + ",";
                    strMessages += "Please enter [Security Deposit]/Reason for Security Deposit Reduction" + ",";
                    Span90.Style["display"] = "inline-block";
                    break;
                case "Interest Amount":
                    strCtrlsIDs += txtInterest_Amount.ClientID + ",";
                    strMessages += "Please enter [Security Deposit]/Interest Amount" + ",";
                    Span92.Style["display"] = "inline-block";
                    break;
                case "Amount of Security Deposit Returned":
                    strCtrlsIDs += txtAmount_Security_Deposit_Returned.ClientID + ",";
                    strMessages += "Please enter [Security Deposit]/Amount of Security Deposit Returned" + ",";
                    Span93.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Surrender Obligations"
        dtFields = clsScreen_Validators.SelectByScreen(74).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        // set menu 1 asterisk display
        MenuAsterisk7.Style["display"] = (dtFields.Select("LeftMenuIndex = 74").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Condition at Lease Commencement Date":
                    strCtrlsIDs += txtCondition_At_Commencement.ClientID + ",";
                    strMessages += "Please enter [Surrender Obligations]/Condition at Lease Commencement Date" + ",";
                    Span94.Style["display"] = "inline-block";
                    break;
                case "Permitted Use":
                    strCtrlsIDs += txtPermitted_Use.ClientID + ",";
                    strMessages += "Please enter [Surrender Obligations]/Permitted Use" + ",";
                    Span95.Style["display"] = "inline-block";
                    break;
                case "Alterations":
                    strCtrlsIDs += txtAlterations.ClientID + ",";
                    strMessages += "Please enter [Surrender Obligations]/Alterations" + ",";
                    Span96.Style["display"] = "inline-block";
                    break;
                case "Tenant’s Obligations":
                    strCtrlsIDs += txtTenants_Obligations.ClientID + ",";
                    strMessages += "Please enter [Surrender Obligations]/Tenant’s Obligations" + ",";
                    Span97.Style["display"] = "inline-block";
                    break;
                case "Environmental Matters – Tenant’s Covenant":
                    strCtrlsIDs += txtEnvironmental_Matters.ClientID + ",";
                    strMessages += "Please enter [Surrender Obligations]/Environmental Matters – Tenant’s Covenant" + ",";
                    Span98.Style["display"] = "inline-block";
                    break;
                case "Landlord’s Obligations":
                    strCtrlsIDs += txtLandlords_Obligations.ClientID + ",";
                    strMessages += "Please enter [Surrender Obligations]/Landlord’s Obligations" + ",";
                    Span99.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion


        #region "Notices"
        dtFields = clsScreen_Validators.SelectByScreen(75).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        // set menu 1 asterisk display
        MenuAsterisk8.Style["display"] = (dtFields.Select("LeftMenuIndex = 75").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "If to Landlord  -  Company":
                    strCtrlsIDs += txtLandlord_Company.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  Company" + ",";
                    Span100.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  Contact Name":
                    strCtrlsIDs += txtLandlord_Contact.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  Contact Name" + ",";
                    Span101.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  Address 1":
                    strCtrlsIDs += txtLandlord_Address1.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  Address 1" + ",";
                    Span102.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  Address 2":
                    strCtrlsIDs += txtLandlord_Address2.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  Address 2" + ",";
                    Span103.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  City":
                    strCtrlsIDs += txtLandlord_City.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  City" + ",";
                    Span104.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  State":
                    strCtrlsIDs += drpFK_State_Landlord.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  State" + ",";
                    Span105.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  Zip Code":
                    strCtrlsIDs += txtLandlord_Zip_Code.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  Zip Code" + ",";
                    Span106.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  Telephone":
                    strCtrlsIDs += txtLandlord_TelephoneNotices.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  Telephone" + ",";
                    Span107.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  Facsimile":
                    strCtrlsIDs += txtLandlord_Facsimile.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  Facsimile" + ",";
                    Span108.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  E-Mail":
                    strCtrlsIDs += txtLandlord_EmailNotices.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  E-Mail" + ",";
                    Span109.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  With a copy to - Company":
                    strCtrlsIDs += txtLandlord_Copy_Company.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  With a copy to - Company" + ",";
                    Span110.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  With a copy to - Contact Name":
                    strCtrlsIDs += txtLandlord_Copy_Contact.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  With a copy to - Contact Name" + ",";
                    Span111.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  With a copy to - Address 1":
                    strCtrlsIDs += txtLandlord_Copy_Address1.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  With a copy to - Address 1" + ",";
                    Span112.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  With a copy to - Address 2":
                    strCtrlsIDs += txtLandlord_Copy_Address2.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  With a copy to - Address 2" + ",";
                    Span113.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  With a copy to - City":
                    strCtrlsIDs += txtLandlord_Copy_City.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  With a copy to - City" + ",";
                    Span114.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  With a copy to - State":
                    strCtrlsIDs += drpFK_State_Landlord_Copy.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  With a copy to - State" + ",";
                    Span115.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  -  With a copy to - Zip Code":
                    strCtrlsIDs += txtLandlord_Copy_Zip_Code.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  -  With a copy to - Zip Code" + ",";
                    Span116.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  - With a copy to -  Telephone":
                    strCtrlsIDs += txtLandlord_Copy_Telephone.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  - With a copy to -  Telephone" + ",";
                    Span117.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  - With a copy to -  Facsimile":
                    strCtrlsIDs += txtLandlord_Copy_Facsimile.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  - With a copy to -  Facsimile" + ",";
                    Span118.Style["display"] = "inline-block";
                    break;
                case "If to Landlord  - With a copy to - E-Mail":
                    strCtrlsIDs += txtLandlord_Copy_Email.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Landlord  - With a copy to - E-Mail" + ",";
                    Span119.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  Company":
                    strCtrlsIDs += txtTenant_Company.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  Company" + ",";
                    Span120.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  Contact Name":
                    strCtrlsIDs += txtTenant_Contact.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  Contact Name" + ",";
                    Span121.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  Address 1":
                    strCtrlsIDs += txtTenant_Address1.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  Address 1" + ",";
                    Span122.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  Address 2":
                    strCtrlsIDs += txtTenant_Address2.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  Address 2" + ",";
                    Span123.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  City":
                    strCtrlsIDs += txtTenant_City.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  City" + ",";
                    Span124.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  State":
                    strCtrlsIDs += drpFK_State_Tenant.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  State" + ",";
                    Span125.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  Zip Code":
                    strCtrlsIDs += txtTenant_Zip_Code.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  Zip Code" + ",";
                    Span126.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  Telephone":
                    strCtrlsIDs += txtTenant_Telephone.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  Telephone" + ",";
                    Span127.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  Facsimile":
                    strCtrlsIDs += txtTenant_Facsimile.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  Facsimile" + ",";
                    Span128.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  E-Mail":
                    strCtrlsIDs += txtTenant_Email.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  E-Mail" + ",";
                    Span129.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  With a copy to - Company":
                    strCtrlsIDs += txtTenant_Copy_Company.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  With a copy to - Company" + ",";
                    Span130.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  With a copy to - Contact Name":
                    strCtrlsIDs += txtTenant_Copy_Contact.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  With a copy to - Contact Name" + ",";
                    Span131.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  With a copy to - Address 1":
                    strCtrlsIDs += txtTenant_Copy_Address1.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  With a copy to - Address 1" + ",";
                    Span132.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  With a copy to - Address 2":
                    strCtrlsIDs += txtTenant_Copy_Address2.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  With a copy to - Address 2" + ",";
                    Span133.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  With a copy to - City":
                    strCtrlsIDs += txtTenant_Copy_City.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  With a copy to - City" + ",";
                    Span134.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  With a copy to - State":
                    strCtrlsIDs += drpFK_State_Tenant_Copy.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  With a copy to - State" + ",";
                    Span135.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  -  With a copy to - Zip Code":
                    strCtrlsIDs += txtTenant_Copy_Zip_Code.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  -  With a copy to - Zip Code" + ",";
                    Span136.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  - With a copy to -  Telephone":
                    strCtrlsIDs += txtTenant_Copy_Telephone.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  - With a copy to -  Telephone" + ",";
                    Span137.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  - With a copy to -  Facsimile":
                    strCtrlsIDs += txtTenant_Copy_Facsimile.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  - With a copy to -  Facsimile" + ",";
                    Span138.Style["display"] = "inline-block";
                    break;
                case "If to Tenant  - With a copy to - E-Mail":
                    strCtrlsIDs += txtTenant_Copy_Email.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Tenant  - With a copy to - E-Mail" + ",";
                    Span139.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  Company":
                    strCtrlsIDs += txtSubtenant_Company.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  Company" + ",";
                    Span140.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  Contact Name":
                    strCtrlsIDs += txtSubtenant_Contact.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  Contact Name" + ",";
                    Span141.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  Address 1":
                    strCtrlsIDs += txtSubtenant_Address1.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  Address 1" + ",";
                    Span142.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  Address 2":
                    strCtrlsIDs += txtSubtenant_Address2.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  Address 2" + ",";
                    Span143.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  City":
                    strCtrlsIDs += txtSubtenant_City.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  City" + ",";
                    Span144.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  State":
                    strCtrlsIDs += drpFK_State_Subtenant.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  State" + ",";
                    Span145.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  Zip Code":
                    strCtrlsIDs += txtSubtenant_Zip_Code.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  Zip Code" + ",";
                    Span146.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  Telephone":
                    strCtrlsIDs += txtSubtenant_Telephone.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  Telephone" + ",";
                    Span147.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  Facsimile":
                    strCtrlsIDs += txtSubtenant_Facsimile.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  Facsimile" + ",";
                    Span148.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  E-Mail":
                    strCtrlsIDs += txtSubtenant_Email.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  E-Mail" + ",";
                    Span149.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  With a copy to - Company":
                    strCtrlsIDs += txtSubtenant_Copy_Company.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  With a copy to - Company" + ",";
                    Span150.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  With a copy to - Contact Name":
                    strCtrlsIDs += txtSubtenant_Copy_Contact.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  With a copy to - Contact Name" + ",";
                    Span151.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  With a copy to - Address 1":
                    strCtrlsIDs += txtSubtenant_Copy_Address1.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  With a copy to - Address 1" + ",";
                    Span152.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  With a copy to - Address 2":
                    strCtrlsIDs += txtSubtenant_Copy_Address2.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  With a copy to - Address 2" + ",";
                    Span153.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  With a copy to - City":
                    strCtrlsIDs += txtSubtenant_Copy_City.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  With a copy to - City" + ",";
                    Span154.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  With a copy to - State":
                    strCtrlsIDs += drpFK_State_Subtenant_Copy.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  With a copy to - State" + ",";
                    Span155.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   -  With a copy to - Zip Code":
                    strCtrlsIDs += txtSubtenant_Copy_Zip_Code.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   -  With a copy to - Zip Code" + ",";
                    Span156.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   - With a copy to -  Telephone":
                    strCtrlsIDs += txtSubtenant_Copy_Telephone.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   - With a copy to -  Telephone" + ",";
                    Span157.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   - With a copy to -  Facsimile":
                    strCtrlsIDs += txtSubtenant_Copy_Facsimile.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   - With a copy to -  Facsimile" + ",";
                    Span158.Style["display"] = "inline-block";
                    break;
                case "If to Subtenant   - With a copy to - E-Mail":
                    strCtrlsIDs += txtSubtenant_Copy_Email.ClientID + ",";
                    strMessages += "Please enter [Notices]/If to Subtenant   - With a copy to - E-Mail" + ",";
                    Span159.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Lease Maint Obligation "

        dtFields = clsScreen_Validators.SelectByScreen(218).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        // set menu 1 asterisk display
        MenuAsterisk11.Style["display"] = (dtFields.Select("LeftMenuIndex =8").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "HVAC Repairs":
                    strCtrlsIDs += drpFK_HVAC_Repairs.ClientID + ",";
                    strMessages += "Please select [Lease Maint Obligation]/HVAC Repairs" + ",";
                    spanHVACRepairs.Style["display"] = "inline-block";
                    break;

                case "HVAC Capital":
                    strCtrlsIDs += drpFK_HVAC_Capital.ClientID + ",";
                    strMessages += "Please select [Lease Maint Obligation]/HVAC Capital" + ",";
                    spanCapital.Style["display"] = "inline-block";
                    break;

                case "Roof Repairs":
                    strCtrlsIDs += drpFK_Roof_Repairs.ClientID + ",";
                    strMessages += "Please select [Lease Maint Obligation]/Roof Repairs" + ",";
                    span36.Style["display"] = "inline-block";
                    break;

                case "Roof Capital":
                    strCtrlsIDs += drpFK_Roof_Capital.ClientID + ",";
                    strMessages += "Please select [Lease Maint Obligation]/Roof Capital" + ",";
                    span160.Style["display"] = "inline-block";
                    break;

                case "Other Repairs":
                    strCtrlsIDs += txtOtherRepairs.ClientID + ",";
                    strMessages += "Please enter [Lease Maint Obligation]/Other Repairs" + ",";
                    Span161.Style["display"] = "inline-block";
                    break;

                case "Maintenance Notes":
                    strCtrlsIDs += txtMaintenanceNotes.ClientID + ",";
                    strMessages += "Please enter [Lease Maint Obligation]/Maintenance Notes" + ",";
                    Span162.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }

        #endregion


        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;

    }

    private void SetVadidationForSubLease()
    {
        #region "Subtenant Information"
        string strCtrlsIDs = "";
        string strMessages = "";
        DataTable dtFields = clsScreen_Validators.SelectByScreen(68).Tables[0];
        dtFields = clsScreen_Validators.SelectByScreen(70).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        // set menu 1 asterisk display
        MenuAsterisk3.Style["display"] = (dtFields.Select("LeftMenuIndex = 70").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Subtenant Mailing Address 1":
                    strCtrlsIDs += txtSubtenant_Mailing_Address1.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Subtenant Mailing Address 1" + ",";
                    Span47.Style["display"] = "inline-block";
                    break;
                case "Subtenant Mailing Address 2":
                    strCtrlsIDs += txtSubtenant_Mailing_Address2.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Subtenant Mailing Address 2" + ",";
                    Span48.Style["display"] = "inline-block";
                    break;
                case "Subtenant Mailing City":
                    strCtrlsIDs += txtSubtenant_Mailing_City.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Subtenant Mailing City" + ",";
                    Span49.Style["display"] = "inline-block";
                    break;
                case "Subtenant Mailing State":
                    strCtrlsIDs += drpSubtenantMailingState.ClientID + ",";
                    strMessages += "Please select [Subtenant Information]/Subtenant Mailing State" + ",";
                    Span50.Style["display"] = "inline-block";
                    break;
                case "Subtenant Mailing Zip Code":
                    strCtrlsIDs += txtSubtenant_Mailing_Zip_Code.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Subtenant Mailing Zip Code" + ",";
                    Span51.Style["display"] = "inline-block";
                    break;
                case "Subtenant Telephone":
                    strCtrlsIDs += txtSubtenantTelephone.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Subtenant Telephone" + ",";
                    Span52.Style["display"] = "inline-block";
                    break;
                case "Lease Commencement Date":
                    strCtrlsIDs += lblSubTenantLeaseCommencementDate.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Lease Commencement Date" + ",";
                    Span53.Style["display"] = "inline-block";
                    break;
                case "Lease Term in Months":
                    strCtrlsIDs += lblSubTenantLeaseTerm.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Lease Term in Months" + ",";
                    Span54.Style["display"] = "inline-block";
                    break;
                case "Lease Expiration Date":
                    strCtrlsIDs += lblSubTenantLeaseExpDate.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Lease Expiration Date" + ",";
                    Span55.Style["display"] = "inline-block";
                    break;
                case "Prior Lease Commencement Date":
                    strCtrlsIDs += lblSubTenantPriorLeaseDate.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Prior Lease Commencement Date" + ",";
                    Span56.Style["display"] = "inline-block";
                    break;
                case "Sublease Commencement Date":
                    strCtrlsIDs += txtSubLease_Commencement_Date.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Sublease Commencement Date" + ",";
                    Span57.Style["display"] = "inline-block";
                    break;
                case "Sublease Expiration Date":
                    strCtrlsIDs += txtSubLease_Expiration_Date.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Sublease Expiration Date" + ",";
                    Span58.Style["display"] = "inline-block";
                    break;
                case "Rent Details":
                    strCtrlsIDs += txtCancel_OptionsSubtenant.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Rent Details" + ",";
                    Span59.Style["display"] = "inline-block";
                    break;
                case "Renew Options":
                    strCtrlsIDs += txtRenew_OptionsSubtenant.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Renew Options" + ",";
                    Span60.Style["display"] = "inline-block";
                    break;
                case "Late Fees":
                    strCtrlsIDs += txtOpen_NotificationSubtenant.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Late Fees" + ",";
                    Span61.Style["display"] = "inline-block";
                    break;
                case "Other Requirements":
                    strCtrlsIDs += txtOther_Requirements.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Other Requirements" + ",";
                    Span62.Style["display"] = "inline-block";
                    break;
                case "Notification Due Date":
                    strCtrlsIDs += txtNotification_Due_DateSubtenant.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Notification Due Date" + ",";
                    Span63.Style["display"] = "inline-block";
                    break;
                case "Subtenant Annual Rent":
                    strCtrlsIDs += txtSubtenant_Base_RentSubtenant.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Subtenant Annual Rent" + ",";
                    Span64.Style["display"] = "inline-block";
                    break;
                case "Subtenant Monthly Rent":
                    strCtrlsIDs += txtSubtenant_Monthly_RentSubtenant.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Subtenant Monthly Rent" + ",";
                    Span65.Style["display"] = "inline-block";
                    break;
                case "Security Deposit":
                    strCtrlsIDs += txtSecurityDeposit.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Security Deposit" + ",";
                    Span66.Style["display"] = "inline-block";
                    break;
                case "Escalation":
                    strCtrlsIDs += drpFK_LU_EscalationSubtenant.ClientID + ",";
                    strMessages += "Please select [Subtenant Information]/Escalation" + ",";
                    Span67.Style["display"] = "inline-block";
                    break;
                case "Increase":
                    strCtrlsIDs += txtIncreaseSubtenant.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Increase" + ",";
                    Span68.Style["display"] = "inline-block";
                    break;
                case "Percentage Rate":
                    strCtrlsIDs += txtPercentage_RateSubtenant.ClientID + ",";
                    strMessages += "Please enter [Subtenant Information]/Percentage Rate" + ",";
                    Span169.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnSubtenanatIDs.Value = strCtrlsIDs;
        hdnSubtenantErroeMassage.Value = strMessages;
        #endregion
    }
    #endregion
}

