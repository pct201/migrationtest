using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ERIMS.DAL;
using System.Collections.Generic;
using System.Text;

public partial class Admin_COIAddEdit : clsBasePage
{
    /// <summary>
    /// Modify By Alpesh Patel      Modify Date: 21/12/2010
    /// Change Requirement By BugsTrackerIssue #1004 
    /// Changes Insured Band screen.Design Changes and Display Multiple Building Record in Grid.
    /// Add New Session Value To Store Manually Data in Building Grid Information.
    /// All Building Grid Information Data are Save in Save & View Button Click Event 
    /// </summary>


    #region "Variables"
    // denotes whether to edit or view the record
    string strOperation = "";

    public const string SIGNATURE_NULL_TEXT = "The Certificates of Insurance issued on [Issue_Date] contains the following deficiencies that need to be corrected within the next 30 days:";
    public const string SIGNATURE1_TEXT = "The Risk Management Department has not received a current Certificate of Insurance verifying your insurance requirements as outlined in your Franchise Agreement.  Please request your agent to forward to my attention a Certificate of Liability Insurance (Acord 25) and Evidence of Property Insurance (Acord 24, 27 or 28).  Should you or your agent have any questions, please give me a call and we can discuss.";

    public const string SIGNATURE2_TEXT = "The Risk Management Department has not received a current Certificate of Insurance verifying your insurance requirements as outlined in your Agreement.  Please request your agent to forward to my attention a Certificate of Insurance.  Should you or your agent have any questions, please give me a call and we can discuss.";

    #endregion

    #region "Properties"
    string _strOperation = "";
    /// <summary>
    /// Denotes operation either view or edit
    /// </summary>
    public string StrOperation
    {
        get
        {
            return _strOperation;
        }
    }
    /// <summary>
    /// primary key for Risk profile (will be used for all policy grids to bind)
    /// </summary>
    public decimal PK_Risk_Profile
    {
        get
        {
            if (!clsGeneral.IsNull(ViewState["Profile_ID"]))
                return Convert.ToInt32(ViewState["Profile_ID"]);
            else
                return 0;
        }
        set { ViewState["Profile_ID"] = value; }
    }

    /// <summary>
    /// primary key for COI record
    /// </summary>
    public int PK_COIs
    {
        get
        {
            if (!clsGeneral.IsNull(ViewState["COI_ID"]))
                return Convert.ToInt32(ViewState["COI_ID"]);
            else
                return 0;
        }
        set { ViewState["COI_ID"] = value; }
    }

    /// <summary>
    /// Encrypted primary key for COI record
    /// </summary>
    public string PK_COIs_Encrypt
    {
        get
        {
            if (!clsGeneral.IsNull(ViewState["COI_ID"]))
                return Encryption.Encrypt(Convert.ToString(ViewState["COI_ID"]));
            else
                return "0";
        }
        set { ViewState["COI_ID"] = value; }
    }

    /// <summary>
    /// Set Old hdnPK_Building_Ownership_ID value
    /// </summary>
    public string strOldhdnPK_Building_Ownership_ID
    {
        get
        {
            if (!clsGeneral.IsNull(ViewState["strOldhdnPK_Building_Ownership_ID"]))
                return (Convert.ToString(ViewState["strOldhdnPK_Building_Ownership_ID"]));
            else
                return "0";
        }
        set { ViewState["strOldhdnPK_Building_Ownership_ID"] = value; }
    }

    /// <summary>
    /// Return Current COI's Location Id
    /// </summary>
    private int Fk_Lu_Location_Id
    {
        get 
        {
            if (ddlDBA.SelectedIndex > -1)
            {
                return Convert.ToInt32(ddlDBA.SelectedValue);
            }
            else
            {
                return 0;
            }        
        }
    }

    public long Location_ID
    {
        get { return Convert.ToInt64(ViewState["Location_ID"]); }
        set { ViewState["Location_ID"] = value; }
    }

    public int CurrentPage
    {
        get { return Convert.ToInt32(ViewState["CurrentPage"]); }
        set { ViewState["CurrentPage"] = value; }
    }
    public int PageSize
    {
        get { return Convert.ToInt32(ViewState["PageSize"]); }
        set { ViewState["PageSize"] = value; }
    }

    #endregion

    #region "Page Events"


    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        ctrlPageSonicNotes.GetPage += new Controls_Navigation_Navigation.dlgGetPage(ctrlPageSonicNotes_GetPage);
        int width1 = System.Windows.Forms.SystemInformation.VirtualScreen.Width;
        //when first time the page is loaded
        if (!IsPostBack)
        {
            //Check COIInsuredBuilding.aspx page is redirect then session value is not null otherwise session value is null
            if (clsGeneral.IsNull(Request.QueryString["sv"]))
                Session["dt_Building"] = null;

            ((Button)Attachment.FindControl("btnAddAttachment")).OnClientClick = "javascript:return IfSave();";
            //// if page is loaded first time.
            if (App_Access == AccessType.NotAssigned)
                Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
            else
            {
                if (!clsGeneral.IsNull(Request.QueryString["pnl"]))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + Request.QueryString["pnl"] + ");", true);
                    _strOperation = Request.QueryString["op"].ToString();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

                }
                // if querystring for operation to be perfrmed is passed(view or edit);
                if (!clsGeneral.IsNull(Request.QueryString["op"]))
                {
                    strOperation = Request.QueryString["op"].ToString();

                    // if id is passed in querystring.
                    if (!clsGeneral.IsNull(Request.QueryString["id"]))
                    {
                        // set COI id.
                        PK_COIs = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));

                        // show all grids
                        dvGrids.Style["Display"] = "block";
                        _strOperation = Request.QueryString["op"].ToString().ToLower();
                        // if full access are given to client then 
                        if (strOperation == "view")
                        {
                            // show view div
                            dvView.Style["Display"] = "block";
                            // set values in label as per COI id.
                            BindDetailsForView();
                            // set attachment details control in readonly mode.
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Certificates_of_Insurance, PK_COIs, false, 11);
                            if (App_Access == AccessType.View_Only)
                            {
                                btnEdit.Visible = false;
                                btnGenerateLetter.Visible = false;
                            }
                        }
                        else
                        {
                            if (App_Access == AccessType.Administrative_Access)
                            {
                                //bind all dropdowns of the page 
                                BindDropdowns();
                                // set values in textbox and all other controls.
                                BindDetailsForEdit();
                                // set attachment details control in read/write mode. so user can add or remove attachment as well.
                                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Certificates_of_Insurance, PK_COIs, true, 11);
                            }
                            else
                                Response.Redirect(Request.Url.ToString().Replace("edit", "view"));
                        }

                        //bind all grids of the page
                        BIND_ALL_GRIDS();
                    }
                    else
                    {
                        if (App_Access != AccessType.Administrative_Access)
                            Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
                        btnBack.Style["Display"] = "none";
                        dvSave.Style["Display"] = "block";
                    }

                    if (PK_COIs > 0)
                    {
                        ucCtrlCOIInfo.PK_COIs = PK_COIs;
                        ucCtrlCOIInfo.BindrCOIInfo();
                    }
                    else
                    {
                        ucCtrlCOIInfo.Visible = false;
                    }
                    // bind attachment details to show attachment for current COI.
                    BindAttachmentDetails();
                }
                else
                {
                    // the page will be in add mode

                    if (App_Access == AccessType.Administrative_Access)
                    {
                        //bind all grids (will be empty with the Empty record message) 
                        BIND_ALL_GRIDS();
                        //bind all dropdowns
                        BindDropdowns();
                        dvSave.Style["Display"] = "block";
                        BindComplianceGridForEdit();
                        ucCtrlCOIInfo.Visible = false;
                    }
                    else
                        Response.Redirect("COIList.aspx");
                }
            }

            if (Request.QueryString["sv"] != null)
            {
                SetDataFromSession();
                SetBuildingTIV();
            }

        }
        clsGeneral.SetDropDownToolTip(new DropDownList[] { drpRiskProfile });
        SetValidations();
    }
    #endregion

    #region "Grid Binding"
    /// <summary>
    /// Calls sepearate function for grid bind
    /// </summary>
    private void BindGrid()
    {
        DataSet ds = new DataSet();
        ds = COI_CertificateType_Detail.SelectAll(PK_COIs);
        if (ds != null)
        {
            DataTable dt = ds.Tables[0];
            if (strOperation == "view")
            {
                grvCertificateTypesView.DataSource = dt;
                grvCertificateTypesView.DataBind();
            }
            else
            {
                grvCertificateTypes.DataSource = dt;
                grvCertificateTypes.DataBind();
            }
        }
    }
    /// <summary>
    /// Calls sepearate function for each grid band
    /// </summary>
    private void BIND_ALL_GRIDS()
    {
        BindProducerGrid();
        BindInsuranceCompanyGrid();
        /********* GRIDS IN LIMITS AND COVERAGE BAND *******************/
        BindGeneralPolicyGrid();
        BindAutomobilePolicyGrid();
        BindExcessPolicyGrid();
        BindWCPolicyGrid();
        BindPropertyPolicyGrid();
        BindProfessionalPolicyGrid();
        BindLiquorPolicyGrid();
        /***************************************************************/
        BindOwnersGrid();
        BindCopiesGrid();
        BindBuildingGrid(); //Add New Function Bind Multiple Building

        BindGrid();

        BindGridSonicNotes();


    }

    /// <summary>
    /// Producers Band
    /// </summary>
    private void BindProducerGrid()
    {
        DataTable dtProducres = COI_Producers.SelectByFK_COIs(PK_COIs).Tables[0];
        gvProducers.DataSource = dtProducres;
        gvProducers.DataBind();
        //Set Coulumns as per Current Mode
        gvProducers.Columns[2].Visible = (strOperation == "view") ? false : true;
    }

    /// <summary>
    /// Insurance companies Band
    /// </summary>
    private void BindInsuranceCompanyGrid()
    {
        DataTable dtCompanies = COI_Insurance_Companies.SelectByFK_COIs(PK_COIs).Tables[0];
        gvInsuranceCompanies.DataSource = dtCompanies;
        gvInsuranceCompanies.DataBind();
        //Set Coulumns as per Current Mode
        gvInsuranceCompanies.Columns[2].Visible = (strOperation == "view") ? false : true;
    }

    /// <summary>
    /// General Policy Band
    /// </summary>
    private void BindGeneralPolicyGrid()
    {
        DataTable dtGeneralPolicy = COI_General_Policies.SelectByRiskProfile(PK_COIs, PK_Risk_Profile).Tables[0];
        gvGeneralPolicies.DataSource = dtGeneralPolicy;
        gvGeneralPolicies.DataBind();
        //Set Coulumns as per Current Mode
        gvGeneralPolicies.Columns[3].Visible = (strOperation == "view") ? false : true;
    }

    /// <summary>
    /// Automobile policy Band
    /// </summary>
    private void BindAutomobilePolicyGrid()
    {
        DataTable dtAutoPolicy = COI_Automobile_Policies.SelectByRiskProfile(PK_COIs, PK_Risk_Profile).Tables[0];
        gvAutomobilePolicies.DataSource = dtAutoPolicy;
        gvAutomobilePolicies.DataBind();
        //Set Coulumns as per Current Mode
        gvAutomobilePolicies.Columns[3].Visible = (strOperation == "view") ? false : true;
    }

    /// <summary>
    /// Excess Policy band
    /// </summary>
    private void BindExcessPolicyGrid()
    {
        DataTable dtExcessPolicy = COI_Excess_Policies.SelectByRiskProfile(PK_COIs, PK_Risk_Profile).Tables[0];
        gvExcessPolicies.DataSource = dtExcessPolicy;
        gvExcessPolicies.DataBind();
        //Set Coulumns as per Current Mode
        gvExcessPolicies.Columns[3].Visible = (strOperation == "view") ? false : true;
    }

    /// <summary>
    /// WC policy Band
    /// </summary>
    private void BindWCPolicyGrid()
    {
        DataTable dtWCPolicy = COI_WC_Policies.SelectByRiskProfile(PK_COIs, PK_Risk_Profile).Tables[0];
        gvWCPolicies.DataSource = dtWCPolicy;
        gvWCPolicies.DataBind();
        //Set Coulumns as per Current Mode
        gvWCPolicies.Columns[3].Visible = (strOperation == "view") ? false : true;
    }

    /// <summary>
    /// Property Policy Band
    /// </summary>
    private void BindPropertyPolicyGrid()
    {
        //DataTable dtPropertyPolicy = COI_Property_Policies.SelectByRiskProfile(PK_COIs, 0).Tables[0];
        DataTable dtPropertyPolicy = COI_Property_Policies.SelectByRiskProfile(PK_COIs, PK_Risk_Profile).Tables[0];
        gvPropertyPolicies.DataSource = dtPropertyPolicy;
        gvPropertyPolicies.DataBind();
        gvPropertyPolicies.Columns[3].Visible = (strOperation == "view") ? false : true;
    }

    /// <summary>
    /// Professional Policy Band
    /// </summary>
    private void BindProfessionalPolicyGrid()
    {
        DataTable dtProfessionalPolicy = COI_Professional_Policies.SelectByRiskProfile(PK_COIs, PK_Risk_Profile).Tables[0];
        gvProfessionalPolicies.DataSource = dtProfessionalPolicy;
        gvProfessionalPolicies.DataBind();
        gvProfessionalPolicies.Columns[3].Visible = (strOperation == "view") ? false : true;
    }
    /// <summary>
    /// Liquor Policy Band
    /// </summary>
    private void BindLiquorPolicyGrid()
    {
        DataTable dtLiquorPolicy = COI_Liquor_Policies.SelectByRiskProfile(PK_COIs, PK_Risk_Profile).Tables[0];
        gvLiquorPolicies.DataSource = dtLiquorPolicy;
        gvLiquorPolicies.DataBind();
        gvLiquorPolicies.Columns[3].Visible = (strOperation == "view") ? false : true;
    }

    /// <summary>
    /// Owners Band
    /// </summary>
    private void BindOwnersGrid()
    {
        DataTable dtOwners = COI_Owners.SelectByFK_COIs(PK_COIs).Tables[0];
        gvOwners.DataSource = dtOwners;
        gvOwners.DataBind();
        gvOwners.Columns[2].Visible = (strOperation == "view") ? false : true;
    }

    /// <summary>
    /// Copies Band
    /// </summary>
    private void BindCopiesGrid()
    {
        DataTable dtCopies = COI_Copies.SelectByFK_COIs(PK_COIs).Tables[0];
        gvCopies.DataSource = dtCopies;
        gvCopies.DataBind();
        gvCopies.Columns[2].Visible = (strOperation == "view") ? false : true;
    }
    //Bind Building Grid   
    private void BindBuildingGrid()
    {
        DataTable dtTempBuilding;
        //View Mode Data Bind
        if (strOperation == "view")
        {
            DataTable dtInsureds_Buildings = clsCOI_Insureds_Buildings.SelectByFK_COI_Insureds(PK_COIs).Tables[0];
            dtInsureds_Buildings.DefaultView.Sort = "Building_Number";
            gvBuildingInformationView.DataSource = dtInsureds_Buildings.DefaultView.ToTable();
            gvBuildingInformationView.DataBind();
        }
        else
        {
            //Check in Edit Mode PK_COIs wise display in BuildingGrid
            DataTable dtInsureds_Buildings = clsCOI_Insureds_Buildings.SelectByFK_COI_Insureds(PK_COIs).Tables[0];
            if (Session["dt_Building"] != null) //First Time Check Session Value are data store or not 
            {
                dtTempBuilding = (DataTable)Session["dt_Building"];
                dtTempBuilding.DefaultView.Sort = "Building_Number";
                gvBuildingInformation.DataSource = dtTempBuilding.DefaultView.ToTable();
                gvBuildingInformation.DataBind();
            }
            else
            {
                dtInsureds_Buildings.DefaultView.Sort = "Building_Number";
                gvBuildingInformation.DataSource = dtInsureds_Buildings.DefaultView.ToTable();
                gvBuildingInformation.DataBind();
                gvBuildingInformation.Columns[2].Visible = (strOperation == "view") ? false : true;
                Session["dt_Building"] = dtInsureds_Buildings;
            }
        }
    }

    private void SetBuildingTIV()
    {
        //string strBuillding_Numbers = "";
        //DataTable dtBuildings = (DataTable)Session["dt_Building"];
        //if (dtBuildings != null)
        //{
        //    if (dtBuildings.Rows.Count > 0)
        //    {
        //        foreach (DataRow drBuilding in dtBuildings.Rows)
        //        {
        //            strBuillding_Numbers = strBuillding_Numbers + Convert.ToString(drBuilding["Building_Number"]) + ",";
        //        }
        //        strBuillding_Numbers = strBuillding_Numbers.TrimEnd(',');
        //    }
        //}

        //DataTable dtTIV = COI_Insureds.GetBuildingTIV(strBuillding_Numbers).Tables[0];
        DataTable dtTIV = COI_Insureds.GetBuildingTIV(Fk_Lu_Location_Id,PK_COIs).Tables[0];
        txtBuilding_TIV.Enabled = Convert.ToBoolean(dtTIV.Rows[0]["AllowEdit"]);
        txtBuilding_TIV.Text = string.Format("{0:N2}", dtTIV.Rows[0]["Building_TIV"]);
    }

    private void SetDataFromSession()
    {
        DataTable dtCOIInfo = (DataTable)Session["dtCOI"];

        if (dtCOIInfo != null)
        {
            if (dtCOIInfo.Rows.Count > 0)
            {
                // get data from page controls and store in session table
                DataRow drCOI = dtCOIInfo.Rows[0];
                rdoSubleaseAgreement.SelectedValue = Convert.ToString(drCOI["Sublease"]);
                txtName.Text = Convert.ToString(drCOI["InsuredName"]);
                txtIssueDate.Text = Convert.ToString(drCOI["Issue_Date"]);
                txtLandlordName.Text = Convert.ToString(drCOI["LandlordName"]);
                txtSubleaseName.Text = Convert.ToString(drCOI["SubleaseName"]);
                ddlDBA.SelectedValue = Convert.ToString(drCOI["DBA"]);
                drpRegion.SelectedValue = Convert.ToString(drCOI["Region"]);
                txtContactLastName.Text = Convert.ToString(drCOI["LastName"]);
                txtContactFirstName.Text = Convert.ToString(drCOI["FirstName"]);
                txtContactTitle.Text = Convert.ToString(drCOI["Title"]);
                txtContactEmail.Text = Convert.ToString(drCOI["Email"]);
                txtContactPhone.Text = Convert.ToString(drCOI["Phone"]);
                txtContactFax.Text = Convert.ToString(drCOI["Fax"]);
                //txtDateActivated.Text = Convert.ToString(drCOI["DateActivated"]);
                //txtDateClosed.Text = Convert.ToString(drCOI["DateClosed"]);
                rdoInsuredActive.SelectedValue = Convert.ToString(drCOI["InsuredActive"]);
                rdoAMBestRequired.SelectedValue = Convert.ToString(drCOI["AMBest"]);
                txtNotes.Text = Convert.ToString(drCOI["Notes"]);
            }
        }
    }
    #endregion

    #region "Bind Details for Edit or View"
    /// <summary>
    /// Bind compliance for edit
    /// </summary>
    private void BindComplianceGridForEdit()
    {
        DataTable dt = COI_Compliance_Text.SelectAll().Tables[0];
        DataTable dtTemp = new DataTable();
        dtTemp = dt.Clone();
        DataRow[] dr;
        if (dt.Rows.Count > 0)
        {
            dr = dt.Select("IsTurnedOn = 'Y'");
            for (int i = 0; i < dr.Length; i++)
            {
                dtTemp.ImportRow(dr[i]);
            }
        }
        dlComplianceText.DataSource = dtTemp;
        dlComplianceText.DataBind();
    }
    /// <summary>
    /// Bind Compliance data for View
    /// </summary>
    private void BindComplianceGridForView()
    {
        DataTable dt = COI_Compliance_Text.SelectAll().Tables[0];
        DataTable dtTemp = new DataTable();
        dtTemp = dt.Clone();
        DataRow[] dr;
        if (dt.Rows.Count > 0)
        {
            dr = dt.Select("IsTurnedOn = 'Y'");
            for (int i = 0; i < dr.Length; i++)
            {
                dtTemp.ImportRow(dr[i]);
            }
        }
        dlComplianceView.DataSource = dtTemp;
        dlComplianceView.DataBind();

    }
    /// <summary>
    /// Displays the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Style["Display"] = "none"; // hide the labels for viewing the records
        dvSave.Style["Display"] = "block"; // show the save and attachment button
        btnBack.Style["Display"] = "none";
        btnSave.Style["Display"] = "inline";
        _strOperation = "edit";
        //--------- COI details
        //initialize object for COIs record
        COIs objCOI = new COIs(PK_COIs);
        // set values
        txtIssueDate.Text = clsGeneral.FormatDate(objCOI.Issue_Date);
        txtDateRequested.Text = clsGeneral.FormatDate(objCOI.Date_Requested);
        drpRiskProfile.SelectedValue = Convert.ToString(objCOI.FK_COI_Risk_Profile);

        // set Risk profile ID for getting limits and risk in Limits and Coverage Bands         
        PK_Risk_Profile = objCOI.FK_COI_Risk_Profile;
        txtProfileNote.Text = objCOI.Profle_Notes;
        rdoGeneralRequired.SelectedValue = objCOI.General_Required;
        rdoAutoRequired.SelectedValue = objCOI.Automobile_Required;
        rdoExcessRequired.SelectedValue = objCOI.Excess_Required;
        rdoWCRequired.SelectedValue = objCOI.WC_Required;
        rdoPropertyRequired.SelectedValue = objCOI.Property_Required;
        rdoProfessionalRequired.SelectedValue = objCOI.Professional_Required;
        rdoLiquorRequired.SelectedValue = objCOI.Liquor_Required;
        rdoSignedRecieved.SelectedValue = objCOI.Signed_Certificate_Received;
        txtCancellationNotice.Text = objCOI.Cancellation_Notice.ToString();
        rdoCOIActive.SelectedValue = objCOI.COI_Active;
        if (objCOI.FK_COI_Signature != 0) { drpSignature.SelectedValue = Convert.ToString(objCOI.FK_COI_Signature); }
        rdoSendByEmail.SelectedValue = objCOI.Send_By_Email;
        txtLevel1Text.Text = objCOI.LeveL_1_Text;
        txtLevel2Text.Text = objCOI.LeveL_2_Text;
        txtLevel3Text.Text = objCOI.LeveL_3_Text;
        txtLevel4Text.Text = objCOI.LeveL_4_Text;
        ddlDBA.SelectedValue = Convert.ToString(objCOI.FK_LU_Location_ID);

        //Bind compliance data
        BindComplianceGridForEdit();

        //------- Insured details 

        // initialize the insured object
        COI_Insureds objInsured = new COI_Insureds(objCOI.FK_COI_Insureds,PK_COIs);

        Building_Ownership objOwnership = new Building_Ownership((Int32)objInsured.FK_Building_Ownership_ID);
        //set values
        txtName.Text = objInsured.Insured_Name;
        txtContactFirstName.Text = objInsured.Contact_First_Name;
        txtContactLastName.Text = objInsured.Contact_Last_Name;
        txtContactTitle.Text = objInsured.Contact_Title;
        txtContactPhone.Text = objInsured.Contact_Phone;
        txtContactFax.Text = objInsured.Contact_Fax;
        txtContactEmail.Text = objInsured.Contact_EMail;
        //txtDateActivated.Text = clsGeneral.FormatDate(objInsured.Date_Activiated);
        //txtDateClosed.Text = clsGeneral.FormatDate(objInsured.Date_Closed);
        drpRegion.SelectedValue = Convert.ToString(objInsured.FK_COI_Region);
        rdoInsuredActive.SelectedValue = objInsured.Active;
        rdoAMBestRequired.SelectedValue = objInsured.AM_Best_Required;
        if (Convert.ToString(objInsured.Sublease_Agreement) == "Y")
        {
            rdoSubleaseAgreement.SelectedValue = objInsured.Sublease_Agreement;
        }
        else
        {
            rdoSubleaseAgreement.SelectedValue = "N";
        }

        txtNotes.Text = objInsured.Notes;
        txtBuilding_TIV.Text = string.Format("{0:N2}", objInsured.Building_TIV);
        //txtSubleaseName.Text = objOwnership.Sublease_Name;

        if ((Int32)objInsured.FK_Building_Ownership_ID > 0)
        {
            DataSet dsLease = DAL.clsBuilding_Ownership_Sublease.SelectByFK((Int32)objInsured.FK_Building_Ownership_ID);
            if (dsLease != null && dsLease.Tables.Count > 0 && dsLease.Tables[0].Rows.Count > 0 && dsLease.Tables[0].Rows[0]["Sublease_Name"] != null)
                txtSubleaseName.Text = Convert.ToString(dsLease.Tables[0].Rows[0]["Sublease_Name"]);
        }
        else
            txtSubleaseName.Text = string.Empty;

        txtLandlordName.Text = objOwnership.Landlord_Name;
        hdnPK_Building_Ownership_ID.Value = Convert.ToString(objInsured.FK_Building_Ownership_ID);
        //hdnPK_Building_Ownership_ID_Old.Value = Convert.ToString(objInsured.FK_Building_Ownership_ID);
        hdntxtName.Value = objInsured.Insured_Name;
        hdnLandlordName.Value = objOwnership.Landlord_Name;
        hdnstrRegion.Value = Convert.ToString(objInsured.FK_COI_Region);
        hdnBuilding_Number.Value = objInsured.Building_Number;
        hdntxtAddress1.Value = objInsured.Address_1;
        hdntxtAddress2.Value = objInsured.Address_2;
        hdntxtCity.Value = objInsured.City;
        hdntxtContactTitle.Value = objInsured.Contact_Title;
        hdndrpState.Value = Convert.ToString(objInsured.FK_State);
        hdntxtZipCode.Value = objInsured.Zip_Code;
        hdntxtContactFirstName.Value = objInsured.Contact_First_Name;
        hdntxtContactLastName.Value = objInsured.Contact_Last_Name;
        hdntxtContactPhone.Value = objInsured.Contact_Phone;
        hdntxtContactFax.Value = objInsured.Contact_Fax;
        hdntxtContactEmail.Value = objInsured.Contact_EMail;
        //if (objInsured.FK_Building_Ownership_ID > 0)
        //{
        //    txtName.Enabled = false;
        //    txtContactFirstName.Enabled = false;
        //    txtContactLastName.Enabled = false;
        //    txtContactTitle.Enabled = false;
        //    txtContactPhone.Enabled = false;
        //    txtContactEmail.Enabled = false;
        //    txtContactFax.Enabled = false;
        //    ddlDBA.Enabled = false;
        //}
        txtBuilding_TIV.Enabled = objInsured.AllowEditTIV;

        //ctrlSonicNotes.PK_COI_Claims_ID = PK_COIs;
        //ctrlSonicNotes.CurrentClaimType = clsGeneral.Claim_Tables.COIClaim.ToString();
        //ctrlSonicNotes.BindGridSonicNotes(PK_COIs, clsGeneral.Claim_Tables.COIClaim.ToString());


        //if (!objInsured.AllowEditTIV)
        //txtBuilding_TIV.Text = string.Format("{0:N2}", objCOI.Building_TIV);

        //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:onSubleaseChange();", true);
    }

    /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Style["Display"] = "block"; // hide the textboxes for editing the records
        dvBack.Style["Display"] = "block"; // show back button
        dvEdit.Style["Display"] = "None";
        btnBack.Style["Display"] = "block";
        btnSave.Style["Display"] = "none";
        _strOperation = "view";
        btnEdit.Visible = true;
        // hide the add or remove link in all grids
        Hide_GridBands_Controls();

        //------ COI details
        //initialize the Coi object
        COIs objCOI = new COIs(PK_COIs);

        //set values
        lblIssueDate.Text = clsGeneral.FormatDate(objCOI.Issue_Date);        
        lblDateRequested.Text = clsGeneral.FormatDate(objCOI.Date_Requested);
        lblRiskProfile.Text = objCOI.FK_COI_Risk_Profile != null ? new COI_Risk_Profiles(Convert.ToDecimal(objCOI.FK_COI_Risk_Profile)).Name.ToString() : "";

        //Bind Compliance Data
        BindComplianceGridForView();

        // set Risk profile ID for getting limits and risk in Limits and Coverage Bands 
        PK_Risk_Profile = objCOI.FK_COI_Risk_Profile;
        lblProfileNote.Text = objCOI.Profle_Notes;
        lblGeneralRequired.Text = (objCOI.General_Required == "Y") ? "YES" : "NO";
        lblAutoRequired.Text = (objCOI.Automobile_Required == "Y") ? "YES" : "NO";
        lblExcessRequired.Text = (objCOI.Excess_Required == "Y") ? "YES" : "NO";
        lblWCRequired.Text = (objCOI.WC_Required == "Y") ? "YES" : "NO";
        lblPropertyRequired.Text = (objCOI.Property_Required == "Y") ? "YES" : "NO";
        lblProfessionalRequired.Text = (objCOI.Professional_Required == "Y") ? "YES" : "NO";
        lblLiquorRequired.Text = (objCOI.Liquor_Required == "Y") ? "YES" : "NO";
        lblLiquorRequired.Text = (objCOI.Liquor_Required == "Y") ? "YES" : "NO";
        lblSignedRecieved.Text = (objCOI.Signed_Certificate_Received == "Y") ? "YES" : "NO";
        lblCancellationNotice.Text = objCOI.Cancellation_Notice.ToString();
        lblCOIActive.Text = (objCOI.COI_Active == "Y") ? "YES" : "NO";
        lblSignature.Text = new COI_Signature(objCOI.FK_COI_Signature).Fld_Desc;
        lblSendByEmail.Text = (objCOI.Send_By_Email == "Y") ? "YES" : "NO";
        lblLevel1Text.Text = objCOI.LeveL_1_Text;
        lblLevel2Text.Text = objCOI.LeveL_2_Text;
        lblLevel3Text.Text = objCOI.LeveL_3_Text;
        lblLevel4Text.Text = objCOI.LeveL_4_Text;
        if (objCOI.FK_LU_Location_ID > 0)
        {
            DataSet ds = new DataSet();
            ds = LU_Location.SelectByPK(objCOI.FK_LU_Location_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lblDBA.Text = ds.Tables[0].Rows[0]["DBA"].ToString();
            }
        }

        //------ Insured details
        //initialize the Insured object
        COI_Insureds objInsured = new COI_Insureds(objCOI.FK_COI_Insureds,PK_COIs);
        Building_Ownership objOwnership = new Building_Ownership((Int32)objInsured.FK_Building_Ownership_ID);

        //set values
        lblName.Text = objInsured.Insured_Name;

        lblContactFirstName.Text = objInsured.Contact_First_Name;
        lblContactLastName.Text = objInsured.Contact_Last_Name;
        lblContactTitle.Text = objInsured.Contact_Title;
        lblContactPhone.Text = objInsured.Contact_Phone;
        lblContactFax.Text = objInsured.Contact_Fax;
        lblContactEmail.Text = objInsured.Contact_EMail;
        //lblDateActivated.Text = clsGeneral.FormatDate(objInsured.Date_Activiated);
        //lblDateClosed.Text = clsGeneral.FormatDate(objInsured.Date_Closed);
        if (objInsured.FK_COI_Region != "0")
            lblRegion.Text = objInsured.FK_COI_Region;
        lblInsuredActive.Text = (objInsured.Active == "Y") ? "YES" : "NO";
        lblAMBestRequired.Text = (objInsured.AM_Best_Required == "Y") ? "YES" : "NO";
        lblSuleaseAgreement.Text = (objInsured.Sublease_Agreement == "Y") ? "YES" : "NO";
        lblNotes.Text = objInsured.Notes;
        lblBuilding_TIV.Text = string.Format("{0:N2}", objInsured.Building_TIV);
        //lblSubleaseName.Text = objOwnership.Sublease_Name;
        if ((Int32)objInsured.FK_Building_Ownership_ID > 0)
        {
            DataSet dsLease = DAL.clsBuilding_Ownership_Sublease.SelectByFK((Int32)objInsured.FK_Building_Ownership_ID);
            if (dsLease != null && dsLease.Tables.Count > 0 && dsLease.Tables[0].Rows.Count > 0 && dsLease.Tables[0].Rows[0]["Sublease_Name"] != null)
                lblSubleaseName.Text = Convert.ToString(dsLease.Tables[0].Rows[0]["Sublease_Name"]);
        }
        else
            lblSubleaseName.Text = string.Empty;
        lblLandlordName.Text = objOwnership.Landlord_Name;
        //ctrlSonicNotes.PK_COI_Claims_ID = PK_COIs;
        //ctrlSonicNotes.CurrentClaimType = clsGeneral.Claim_Tables.COIClaim.ToString();
        //ctrlSonicNotes.BindGridSonicNotes(PK_COIs, clsGeneral.Claim_Tables.COIClaim.ToString());
        //lblBuilding_TIV.Text = string.Format("{0:N2}", objCOI.Building_TIV);
    }
    #endregion

    #region "Other Methods"

    /// <summary>
    /// Set Building Information hdnvalue to object value
    /// </summary>
    /// <param name="objInsured"></param>
    private void SetBuildingInformation(COI_Insureds objInsured)
    {
        // create a new Insured object.

        //-------Get Insured details       
        objInsured.Insured_Name = hdntxtName.Value;
        objInsured.Address_1 = hdntxtAddress1.Value;
        objInsured.Building_Number = hdnBuilding_Number.Value;
        objInsured.FK_COI_Region = hdnstrRegion.Value;
        objInsured.Address_2 = hdntxtAddress2.Value;
        objInsured.City = hdntxtCity.Value;
        objInsured.Contact_Title = hdntxtContactTitle.Value;
        if (hdndrpState.Value != "") objInsured.FK_State = Convert.ToInt32(hdndrpState.Value);
        objInsured.Zip_Code = hdntxtZipCode.Value;
        objInsured.Contact_First_Name = hdntxtContactFirstName.Value;
        objInsured.Contact_Last_Name = hdntxtContactLastName.Value;
        objInsured.Contact_Phone = hdntxtContactPhone.Value;
        objInsured.Contact_Fax = hdntxtContactFax.Value;
        objInsured.Contact_EMail = hdntxtContactEmail.Value;

    }

    /// <summary>
    /// Bind Grid Sonic Note
    /// </summary>
    private void BindGridSonicNotes()
    {
        CurrentPage = ctrlPageSonicNotes.CurrentPage;
        PageSize = ctrlPageSonicNotes.PageSize;

        DataSet dsNotes = clsCOI_Notes.SelectByFK_Table(PK_COIs, CurrentPage, PageSize);
        DataTable dtNotes = dsNotes.Tables[0];
        if (gvNotes.Rows.Count == 0)
        {
            gvNotes.DataBind();
            btnView.Visible = false;
            btnPrint.Visible = false;
        }
        ctrlPageSonicNotes.TotalRecords = (dsNotes.Tables.Count >= 2) ? Convert.ToInt32(dsNotes.Tables[1].Rows[0][0]) : 0;
        ctrlPageSonicNotes.CurrentPage = (dsNotes.Tables.Count >= 2) ? Convert.ToInt32(dsNotes.Tables[1].Rows[0][2]) : 0;
        ctrlPageSonicNotes.RecordsToBeDisplayed = dsNotes.Tables[0].Rows.Count;
        ctrlPageSonicNotes.SetPageNumbers();
        gvNotes.DataSource = dtNotes;
        gvNotes.DataBind();



        btnView.Visible = dtNotes.Rows.Count > 0;
        btnPrint.Visible = dtNotes.Rows.Count > 0;
    }

    /// <summary>
    /// Bind All DropDownListBox 
    /// </summary>
    private void BindDropdowns()
    {
        //Bind dropdown for Regions
        DataTable dtRegion = LU_Location.GetRegionList().Tables[0];
        drpRegion.DataSource = dtRegion;
        drpRegion.DataTextField = "region";
        drpRegion.DataValueField = "region";
        drpRegion.DataBind();
        drpRegion.Items.Insert(0, new ListItem("--Select--", "0"));

        //Bind dropdown for Risk Profiles
        DataTable dtRiskProfiles = COI_Risk_Profiles.SelectAll().Tables[0];
        drpRiskProfile.DataSource = dtRiskProfiles;
        drpRiskProfile.DataTextField = "Name";
        drpRiskProfile.DataValueField = "PK_COI_Risk_Profile";
        drpRiskProfile.DataBind();
        drpRiskProfile.Items.Insert(0, new ListItem("--Select--", "0"));

        //bind dropdown for Signature
        DataTable dtSignature = COI_Signature.SelectAll().Tables[0];
        drpSignature.DataSource = dtSignature;
        drpSignature.DataTextField = "Fld_Desc";
        drpSignature.DataValueField = "PK_COI_Signature";
        drpSignature.DataBind();
        drpSignature.Items.Insert(0, "--Select--");

        //bind dropdowns for DBA
        //DataTable dtDBA = LU_Location.SelectAllLocation().Tables[0];
        DataTable dtDBA = clsGetInsuredName_SONIC.GetLu_Location_DBA_List().Tables[0];
        ddlDBA.DataSource = dtDBA;
        ddlDBA.DataTextField = "DBA";
        ddlDBA.DataValueField = "PK_LU_Location_ID";
        ddlDBA.DataBind();
        ddlDBA.Items.Insert(0, new ListItem("--Select--", "0"));
        clsGeneral.SetDropDownToolTip(new DropDownList[] { ddlDBA });
    }
    /// <summary>
    /// Hid all Add links for View Mode of COI Add Edit page
    /// </summary>
    private void Hide_GridBands_Controls()
    {
        // Hide all the add links in all grid bands
        lnkProducersAdd.Style["Display"] = "none";
        lnkCompaniesAdd.Style["Display"] = "none";
        lnkGeneralAdd.Style["Display"] = "none";
        lnkAutoAdd.Style["Display"] = "none";
        lnkExcessAdd.Style["Display"] = "none";
        lnkWCAdd.Style["Display"] = "none";
        lnkPropertyAdd.Style["Display"] = "none";
        lnkProfessionalAdd.Style["Display"] = "none";
        lnkLiquorAdd.Style["Display"] = "none";
        lnkOwnersAdd.Style["Display"] = "none";
        lnkCopiesAdd.Style["Display"] = "none";
        btnNotesAdd.Style["Display"] = "none";

        //Hide radio buttons in grid bands 
        rdoGeneralRequired.Visible = false;
        rdoAutoRequired.Visible = false;
        rdoExcessRequired.Visible = false;
        rdoWCRequired.Visible = false;
        rdoPropertyRequired.Visible = false;
        rdoProfessionalRequired.Visible = false;
        rdoLiquorRequired.Visible = false;
    }


    /// <summary>
    /// Grid Notes Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>


    /// <summary>
    /// Button Click Event to View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnView_Click(object sender, EventArgs e)
    {
        string strPK = "";
        foreach (GridViewRow gRow in gvNotes.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
                strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
        }
        strPK = strPK.TrimEnd(',');
        Response.Redirect("..\\Sonic\\ClaimInfo\\ClaimNotesCOI.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_COIs.ToString()) + "&tbl=" + "COIs" + "&loc=" + Fk_Lu_Location_Id + "&op=" + Request.QueryString["op"].ToString());
    }

    /// <summary>
    /// Button Print Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string strPK = "";
        foreach (GridViewRow gRow in gvNotes.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
                strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
        }
        strPK = strPK.TrimEnd(',');
        clsPrintClaimNotesCOI.PrintSelectedSonicNotes(strPK, "COIs", PK_COIs);
    }


    protected void btnNotesAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("..\\Sonic\\ClaimInfo\\ClaimNotesCOI.aspx?loc=" + Fk_Lu_Location_Id + "&FK_Claim=" + Encryption.Encrypt(PK_COIs.ToString()) + "&tbl=" + "COIs" + "&op=" + Request.QueryString["op"].ToString());
    }
    protected void btnPrintSelectedNotes_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }

    protected void ctrlPageSonicNotes_GetPage()
    {
        BindGridSonicNotes();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + 10 + ");", true);

    }

    #endregion

    #region "Save"
    /// <summary>
    /// Handles Save Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveRecord();
        Response.Redirect("COIAddEdit.aspx?op=view&id=" + PK_COIs_Encrypt);
    }

    // add or update COI.
    protected void SaveRecord()
    {
        // create a new COI object.
        COIs objCOI = new COIs(PK_COIs);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

        // Get COI details
        if (txtIssueDate.Text != String.Empty)
            objCOI.Issue_Date = Convert.ToDateTime(txtIssueDate.Text);
        // Get COI details
        if (txtDateRequested.Text != String.Empty)
            objCOI.Date_Requested = Convert.ToDateTime(txtDateRequested.Text);
        else
            objCOI.Date_Requested = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        objCOI.FK_COI_Risk_Profile = Convert.ToInt32(drpRiskProfile.SelectedValue);
        objCOI.Profle_Notes = txtProfileNote.Text.Trim();
        objCOI.General_Required = rdoGeneralRequired.SelectedValue;
        objCOI.Automobile_Required = rdoAutoRequired.SelectedValue;
        objCOI.Excess_Required = rdoExcessRequired.SelectedValue;
        objCOI.WC_Required = rdoWCRequired.SelectedValue;
        objCOI.Property_Required = rdoPropertyRequired.SelectedValue;
        objCOI.Professional_Required = rdoProfessionalRequired.SelectedValue;
        objCOI.Liquor_Required = rdoLiquorRequired.SelectedValue;
        objCOI.Signed_Certificate_Received = rdoSignedRecieved.SelectedValue;
        objCOI.Cancellation_Notice = (txtCancellationNotice.Text.Trim() != string.Empty) ? Convert.ToInt32(txtCancellationNotice.Text.Trim()) : 0;
        if (Request.Form[txtBuilding_TIV.UniqueID] != null)
            objCOI.Building_TIV = Convert.ToDecimal(Request.Form[txtBuilding_TIV.UniqueID]);
        else if (txtBuilding_TIV.Text != string.Empty)
            objCOI.Building_TIV = Convert.ToDecimal(txtBuilding_TIV.Text.Trim().Replace(",", ""));
        objCOI.COI_Active = rdoCOIActive.SelectedValue;
        objCOI.FK_COI_Signature = (drpSignature.SelectedIndex != 0) ? Convert.ToInt32(drpSignature.SelectedValue) : 0;
        objCOI.Send_By_Email = rdoSendByEmail.SelectedValue;
        
        //Savecompliance text.
        foreach (DataListItem Item in dlComplianceText.Items)
        {
            int ID = Convert.ToInt32(((HiddenField)Item.FindControl("hdnPK")).Value);
            RadioButtonList rdoCompliance = (RadioButtonList)Item.FindControl("rdoCompliance");
            Label lblComplianceText = (Label)Item.FindControl("lblComplianceText");
            if (ID == 1)
            {
                if (rdoCompliance.SelectedValue == "Y") objCOI.Compliance_01 = "Y"; else objCOI.Compliance_01 = "N";
            }
            else if (ID == 2)
            {
                if (rdoCompliance.SelectedValue == "Y") objCOI.Compliance_02 = "Y"; else objCOI.Compliance_02 = "N";
            }
            else if (ID == 3)
            {
                if (rdoCompliance.SelectedValue == "Y") objCOI.Compliance_03 = "Y"; else objCOI.Compliance_03 = "N";
            }
            else if (ID == 4)
            {
                if (rdoCompliance.SelectedValue == "Y") objCOI.Compliance_04 = "Y"; else objCOI.Compliance_04 = "N";
            }
            else if (ID == 5)
            {
                if (rdoCompliance.SelectedValue == "Y") objCOI.Compliance_05 = "Y"; else objCOI.Compliance_05 = "N";
            }
            else if (ID == 6)
            {
                if (rdoCompliance.SelectedValue == "Y") objCOI.Compliance_06 = "Y"; else objCOI.Compliance_06 = "N";
            }
            else if (ID == 7)
            {
                if (rdoCompliance.SelectedValue == "Y") objCOI.Compliance_07 = "Y"; else objCOI.Compliance_07 = "N";
            }
            else if (ID == 8)
            {
                if (rdoCompliance.SelectedValue == "Y") objCOI.Compliance_08 = "Y"; else objCOI.Compliance_08 = "N";
            }
            else if (ID == 9)
            {
                if (rdoCompliance.SelectedValue == "Y") objCOI.Compliance_09 = "Y"; else objCOI.Compliance_09 = "N";
            }
            else if (ID == 10)
            {
                if (rdoCompliance.SelectedValue == "Y") objCOI.Compliance_10 = "Y"; else objCOI.Compliance_10 = "N";
            }

        }
        objCOI.FK_LU_Location_ID = Convert.ToInt32(ddlDBA.SelectedValue);
        objCOI.LeveL_1_Text = txtLevel1Text.Text.Trim();
        objCOI.LeveL_2_Text = txtLevel2Text.Text.Trim();
        objCOI.LeveL_3_Text = txtLevel3Text.Text.Trim();
        objCOI.LeveL_4_Text = txtLevel4Text.Text.Trim();
        objCOI.Update_Date = DateTime.Today;
        objCOI.Updated_By = clsSession.UserName;
        
        // create a new Insured object.
        COI_Insureds objInsured = new COI_Insureds();

        //-------Get Insured details 
        objInsured.PK_COI_Insureds = (PK_COIs > 0) ? objCOI.FK_COI_Insureds : 0;

        //if (Convert.ToDecimal(hdnPK_Building_Ownership_ID.Value) > 0)
        //{
        //    SetBuildingInformation(objInsured);
        //}
        //else
        //{

        objInsured.Insured_Name = txtName.Text.Trim();
        objInsured.Contact_Fax = txtContactFax.Text.Trim();
        objInsured.Contact_First_Name = txtContactFirstName.Text.Trim();
        objInsured.Contact_Last_Name = txtContactLastName.Text.Trim();
        objInsured.Contact_Title = txtContactTitle.Text.Trim();
        objInsured.Contact_Phone = txtContactPhone.Text.Trim();
        objInsured.Contact_EMail = txtContactEmail.Text.Trim();
        objInsured.FK_COI_Region = Convert.ToString(drpRegion.SelectedValue);
        //}
        //if (txtDateActivated.Text != String.Empty)
        //    objInsured.Date_Activiated = Convert.ToDateTime(txtDateActivated.Text);
        //if (txtDateClosed.Text != String.Empty)
        //    objInsured.Date_Closed = Convert.ToDateTime(txtDateClosed.Text);

        objInsured.Active = rdoInsuredActive.SelectedValue;
        objInsured.AM_Best_Required = rdoAMBestRequired.SelectedValue;
        objInsured.Sublease_Agreement = rdoSubleaseAgreement.SelectedValue;
        objInsured.Notes = txtNotes.Text.Trim();
        objInsured.FK_Building_Ownership_ID = Convert.ToDecimal(hdnPK_Building_Ownership_ID.Value);
        
        // if COI is in update mode
        if (PK_COIs > 0)
        {
            //update both COI and Insured record
            objInsured.Update();
            objCOI.Update();
        }
        else
        {
            //first insert the insured record so the COI record will refer its ID
            objCOI.FK_COI_Insureds = objInsured.Insert();
            //set the primary key for COI = the newly inserted COI
            PK_COIs = objCOI.Insert();
            dvGrids.Style["Display"] = "block";
        }
        ///Insert Building Information Grid Data in COI_Insureds_Buildings Table 
        decimal _retVal;
        DataTable dtTempBuilding = (DataTable)Session["dt_Building"];

        //First Delete all record in FK_COI_Insureds wise in COI_Insureds_Buildings Table and add new all record in Currently Bind Building Inforamtion Grid Data  
        clsCOI_Insureds_Buildings.DeleteByFK(Convert.ToDecimal(objCOI.FK_COI_Insureds));
        if (dtTempBuilding != null)
        {
            clsCOI_Insureds_Buildings objclsCOI_Insureds_Buildings = new clsCOI_Insureds_Buildings();
            for (int i = 0; i < dtTempBuilding.Rows.Count; i++)
            {
                // if (dtTempBuilding.Rows[i]["PK_COI_Insureds_Buildings"] != null)
                //objclsCOI_Insureds_Buildings.PK_COI_Insureds_Buildings = Convert.ToDecimal(dtTempBuilding.Rows[i]["PK_COI_Insureds_Buildings"]);
                objclsCOI_Insureds_Buildings.Building_Number = Convert.ToString(dtTempBuilding.Rows[i]["Building_Number"]);
                objclsCOI_Insureds_Buildings.FK_COI_Insureds = objCOI.FK_COI_Insureds;
                objclsCOI_Insureds_Buildings.Address_1 = Convert.ToString(dtTempBuilding.Rows[i]["Address_1"]);
                objclsCOI_Insureds_Buildings.Address_2 = Convert.ToString(dtTempBuilding.Rows[i]["Address_2"]);
                objclsCOI_Insureds_Buildings.City = Convert.ToString(dtTempBuilding.Rows[i]["City"]);
                if (dtTempBuilding.Rows[i]["FK_State"] != DBNull.Value)
                    objclsCOI_Insureds_Buildings.FK_State = Convert.ToDecimal(dtTempBuilding.Rows[i]["FK_State"]);
                objclsCOI_Insureds_Buildings.Zip = Convert.ToString(dtTempBuilding.Rows[i]["Zip"]);
                objclsCOI_Insureds_Buildings.Update_Date = DateTime.Today;
                objclsCOI_Insureds_Buildings.Updated_By = clsSession.UserName;
                _retVal = objclsCOI_Insureds_Buildings.Insert();
            }
        }

        // add attachment if any.
        Attachment.Add(clsGeneral.Tables.Certificates_of_Insurance, PK_COIs);
        //}
        Session["dt_Building"] = null;
    }
    /// <summary>
    /// Handles DummyForSave Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDummyForSave_Click(object sender, EventArgs e)
    {
        SaveRecord();
        string strPath = string.Empty;

        if (!string.IsNullOrEmpty(hdnPageName.Value))
        {
            if (hdnPageName.Value.IndexOf("?") > 0)
                strPath = hdnPageName.Value + "&coi=" + PK_COIs_Encrypt + "&op=" + Request.QueryString["op"];
            else
                strPath = hdnPageName.Value + "?coi=" + PK_COIs_Encrypt;
            Response.Redirect(strPath);
        }
    }
    #endregion

    #region "GridViews Events"
    /// <summary>
    /// On Row Data Bound set the Risk Image for Property Policy Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPropertyPolicies_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            // show the green or red bullet for risk 
            HtmlImage imgRisk = (HtmlImage)e.Row.FindControl("imgRisk");
            if (DataBinder.Eval(e.Row.DataItem, "HasRisk") != DBNull.Value)
            {
                //check if the policy record has risk or not and set images according to that
                bool bHasRisk = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "HasRisk"));
                if (bHasRisk)
                    imgRisk.Src = AppConfig.RiskImageURL;
                else
                    imgRisk.Src = AppConfig.NoRiskImageURL;
            }
            else
                imgRisk.Style["Display"] = "none";
        }
        if (e.Row.RowType == DataControlRowType.EmptyDataRow)
        {
            HtmlTable tblPropertyYes = (HtmlTable)e.Row.FindControl("tblPropertyYes");
            HtmlTable tblPropertyNo = (HtmlTable)e.Row.FindControl("tblPropertyNo");
            if (rdoPropertyRequired.SelectedValue == "Y")
            {
                tblPropertyYes.Style["Display"] = "";
                tblPropertyNo.Style["Display"] = "none";
            }
            else
            {
                tblPropertyYes.Style["Display"] = "none";
                tblPropertyNo.Style["Display"] = "";
            }
        }
    }

    // all following functions are for remove links in perticular grid
    protected void gvProducers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveProducer")
        {
            COI_Producers.Delete(Convert.ToDecimal(e.CommandArgument));
            BindProducerGrid();
        }
    }
    /// <summary>
    /// Handles Insurance Company Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvInsuranceCompanies_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveCompany")
        {
            COI_Insurance_Companies.Delete(Convert.ToDecimal(e.CommandArgument));
            BindInsuranceCompanyGrid();
        }
    }
    /// <summary>
    /// Handles General Policy Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvGeneralPolicies_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemovePolicy")
        {
            COI_General_Policies.Delete(Convert.ToDecimal(e.CommandArgument));
            BindGeneralPolicyGrid();
        }
    }
    /// <summary>
    /// Handles AutomobilePolicie Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAutomobilePolicies_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemovePolicy")
        {
            COI_Automobile_Policies.Delete(Convert.ToDecimal(e.CommandArgument));
            BindAutomobilePolicyGrid();
        }
    }
    /// <summary>
    /// Handles ExcessPolicies Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvExcessPolicies_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemovePolicy")
        {
            COI_Excess_Policies.Delete(Convert.ToDecimal(e.CommandArgument));
            BindExcessPolicyGrid();
        }
    }
    /// <summary>
    /// Handles WC Policies Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWCPolicies_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemovePolicy")
        {
            COI_WC_Policies.Delete(Convert.ToDecimal(e.CommandArgument));
            BindWCPolicyGrid();
        }
    }
    /// <summary>
    /// Handles ProperyPolicy Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPropertyPolicies_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemovePolicy")
        {
            //get the property policy id and the location id           
            COI_Property_Policies.Delete(Convert.ToDecimal(e.CommandArgument));
            BindPropertyPolicyGrid();
        }
    }
    /// <summary>
    /// Handles Professional Policy Row Commad Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProfessionalPolicies_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemovePolicy")
        {
            COI_Professional_Policies.Delete(Convert.ToDecimal(e.CommandArgument));
            BindProfessionalPolicyGrid();
        }
    }
    /// <summary>
    /// Handles Liquor Policy Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLiquorPolicies_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemovePolicy")
        {
            COI_Liquor_Policies.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindLiquorPolicyGrid();
        }
    }
    /// <summary>
    /// Handles Owner Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvOwners_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveOwner")
        {
            COI_Owners.Delete(Convert.ToDecimal(e.CommandArgument));
            BindOwnersGrid();
        }
    }
    /// <summary>
    /// Handles Copies Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCopies_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveCopies")
        {
            COI_Copies.Delete(Convert.ToDecimal(e.CommandArgument));
            BindCopiesGrid();
        }
    }

    protected void grvCertificateTypes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveCertiType")
        {
            COI_CertificateType_Detail.Delete(Convert.ToDecimal(e.CommandArgument));
            BindGrid();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
        }
        if (e.CommandName == "ViewDetail")
        {
            string[] arg = new string[2];

            arg = e.CommandArgument.ToString().Split(';');
            int id = Convert.ToInt32(arg[0]);
            int Type = Convert.ToInt32(arg[1]);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:OpenChooseCertiType('" + Type + "','" + id + "');", true);
        }
    }
    protected void btnhdnReload_Click(object sender, EventArgs e)
    {
        BindGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }
    protected void gvGeneralPolicies_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.EmptyDataRow)
        {
            HtmlTable tblGeneralYes = (HtmlTable)e.Row.FindControl("tblGeneralYes");
            HtmlTable tblGeneralNo = (HtmlTable)e.Row.FindControl("tblGeneralNo");
            string IsRequired = strOperation == "view" ? lblGeneralRequired.Text : rdoGeneralRequired.SelectedValue;
            if (IsRequired == "Y" || IsRequired == "YES")
            {
                tblGeneralYes.Style["Display"] = "";
                tblGeneralNo.Style["Display"] = "none";
            }
            else
            {
                tblGeneralYes.Style["Display"] = "none";
                tblGeneralNo.Style["Display"] = "";
            }
        }
    }
    protected void gvAutomobilePolicies_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.EmptyDataRow)
        {
            HtmlTable tblAutomobileYes = (HtmlTable)e.Row.FindControl("tblAutomobileYes");
            HtmlTable tblAutomobileNo = (HtmlTable)e.Row.FindControl("tblAutomobileNo");
            string IsRequired = strOperation == "view" ? lblAutoRequired.Text : rdoAutoRequired.SelectedValue;
            if (IsRequired == "Y" || IsRequired == "YES")
            {
                tblAutomobileYes.Style["Display"] = "";
                tblAutomobileNo.Style["Display"] = "none";
            }
            else
            {
                tblAutomobileYes.Style["Display"] = "none";
                tblAutomobileNo.Style["Display"] = "";
            }
        }
    }
    protected void gvExcessPolicies_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.EmptyDataRow)
        {
            HtmlTable tblExcessYes = (HtmlTable)e.Row.FindControl("tblExcessYes");
            HtmlTable tblExcessNo = (HtmlTable)e.Row.FindControl("tblExcessNo");
            string IsRequired = strOperation == "view" ? lblExcessRequired.Text : rdoExcessRequired.SelectedValue;
            if (IsRequired == "Y" || IsRequired == "YES")
            {
                tblExcessYes.Style["Display"] = "";
                tblExcessNo.Style["Display"] = "none";
            }
            else
            {
                tblExcessYes.Style["Display"] = "none";
                tblExcessNo.Style["Display"] = "";
            }
        }
    }
    protected void gvWCPolicies_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.EmptyDataRow)
        {
            HtmlTable tblWCYes = (HtmlTable)e.Row.FindControl("tblWCYes");
            HtmlTable tblWCNo = (HtmlTable)e.Row.FindControl("tblWCNo");
            string IsRequired = strOperation == "view" ? lblWCRequired.Text : rdoWCRequired.SelectedValue;
            if (IsRequired == "Y" || IsRequired == "YES")
            {
                tblWCYes.Style["Display"] = "";
                tblWCNo.Style["Display"] = "none";
            }
            else
            {
                tblWCYes.Style["Display"] = "none";
                tblWCNo.Style["Display"] = "";
            }
        }
    }
    protected void gvProfessionalPolicies_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.EmptyDataRow)
        {
            HtmlTable tblProfessionalYes = (HtmlTable)e.Row.FindControl("tblProfessionalYes");
            HtmlTable tblProfessionalNo = (HtmlTable)e.Row.FindControl("tblProfessionalNo");
            string IsRequired = strOperation == "view" ? lblProfessionalRequired.Text : rdoProfessionalRequired.SelectedValue;
            if (IsRequired == "Y" || IsRequired == "YES")
            {
                tblProfessionalYes.Style["Display"] = "";
                tblProfessionalNo.Style["Display"] = "none";
            }
            else
            {
                tblProfessionalYes.Style["Display"] = "none";
                tblProfessionalNo.Style["Display"] = "";
            }
        }
    }
    protected void gvLiquorPolicies_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.EmptyDataRow)
        {
            HtmlTable tblLiabilityYes = (HtmlTable)e.Row.FindControl("tblLiabilityYes");
            HtmlTable tblLiabilityNo = (HtmlTable)e.Row.FindControl("tblLiabilityNo");
            string IsRequired = strOperation == "view" ? lblLiquorRequired.Text : rdoLiquorRequired.SelectedValue;
            if (IsRequired == "Y" || IsRequired == "YES")
            {
                tblLiabilityYes.Style["Display"] = "";
                tblLiabilityNo.Style["Display"] = "none";
            }
            else
            {
                tblLiabilityYes.Style["Display"] = "none";
                tblLiabilityNo.Style["Display"] = "";
            }
        }
    }

    protected void gvNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "EditRecord")
        {
            //Get the Claim Note ID
            Response.Redirect("..\\Sonic\\ClaimInfo\\ClaimNotesCOI.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Fk_Lu_Location_Id + "&FK_Claim=" + Encryption.Encrypt(PK_COIs.ToString()) + "&tbl=" + "COIs" + "&op=" + Request.QueryString["op"].ToString());
        }
        else if (e.CommandName == "Remove")
        {
            // Delete record
            clsCOI_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindGridSonicNotes();
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel(10);", true);
        }
    }
    /// <summary>
    /// Handles Owner Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuildingInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveBuilding")
        {
            //clsCOI_Insureds_Buildings.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            //Temp DataTable To Store Session Data
            DataTable dtTempBuilding = (DataTable)Session["dt_Building"];
            for (int i = dtTempBuilding.Rows.Count - 1; i >= 0; i--)
            {
                //Remove DataTable Row in selected BuildingNumber record
                DataRow dr = dtTempBuilding.Rows[i];
                string strBuilding_Number = Convert.ToString(dr["Building_Number"]);
                if (strBuilding_Number == Convert.ToString(e.CommandArgument))
                {
                    dtTempBuilding.Rows.Remove(dr);
                }
            }
            dtTempBuilding.AcceptChanges();
            gvBuildingInformation.DataSource = dtTempBuilding;
            gvBuildingInformation.DataBind();
            Session["dt_Building"] = dtTempBuilding; //Remove DataTable Row after Sessoin are Bind Data  
            SetBuildingTIV();
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:onSubleaseChange();ShowPanel(1);", true);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
        if (e.CommandName == "EditBuilding")
        {
            Response.Redirect("COIInsuredBuilding.aspx?coi=" + PK_COIs_Encrypt + "&op=" + Request.QueryString["op"] + "&id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "");
        }
    }
    protected void gvBuildingInformationView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewBuilding")
        {
            Response.Redirect("COIInsuredBuilding.aspx?coi=" + PK_COIs_Encrypt + "&op=" + Request.QueryString["op"] + "&id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "");
        }
    }
    #endregion

    #region "Attachments Management"
    /// <summary>
    /// Bind theAttachment Details
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["Display"] = "block";
        AttachDetails.Bind();
    }
    /// <summary>
    /// Attachment Control Add Attachment Button event 
    /// </summary>
    /// <param name="sender"></param>
    protected void Attachment_btnHandler(object sender)
    {
        if (PK_COIs > 0)
        {
            // add attachment if any.
            Attachment.Add(clsGeneral.Tables.Certificates_of_Insurance, PK_COIs);
            // Bind the attachment detail to view the added attachment
            BindAttachmentDetails();
            // show attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(10);", true);
        }
        else
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please save Certificates of Insurance First');ShowPanel(1);", true);

    }

    #endregion

    #region "Other Events"
    /// <summary>
    /// ComplianceText Item Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dlComplianceText_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (PK_COIs != 0)
        {
            COIs objCOI = new COIs(PK_COIs);
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int ID = Convert.ToInt32(((HiddenField)e.Item.FindControl("hdnPK")).Value);
                RadioButtonList rdoCompliance = (RadioButtonList)e.Item.FindControl("rdoCompliance");
                Label lblComplianceText = (Label)e.Item.FindControl("lblComplianceText");
                if (objCOI.Compliance_01 == "Y" && ID == 1)
                {
                    rdoCompliance.Items[0].Selected = true;
                    rdoCompliance.Items[1].Selected = false;
                }
                else if (objCOI.Compliance_02 == "Y" && ID == 2)
                {
                    rdoCompliance.Items[0].Selected = true;
                    rdoCompliance.Items[1].Selected = false;
                }
                else if (objCOI.Compliance_03 == "Y" && ID == 3)
                {
                    rdoCompliance.Items[0].Selected = true;
                    rdoCompliance.Items[1].Selected = false;
                }
                else if (objCOI.Compliance_04 == "Y" && ID == 4)
                {
                    rdoCompliance.Items[0].Selected = true;
                    rdoCompliance.Items[1].Selected = false;
                }
                else if (objCOI.Compliance_05 == "Y" && ID == 5)
                {
                    rdoCompliance.Items[0].Selected = true;
                    rdoCompliance.Items[1].Selected = false;
                }
                else if (objCOI.Compliance_06 == "Y" && ID == 6)
                {
                    rdoCompliance.Items[0].Selected = true;
                    rdoCompliance.Items[1].Selected = false;
                }
                else if (objCOI.Compliance_07 == "Y" && ID == 7)
                {
                    rdoCompliance.Items[0].Selected = true;
                    rdoCompliance.Items[1].Selected = false;
                }
                else if (objCOI.Compliance_08 == "Y" && ID == 8)
                {
                    rdoCompliance.Items[0].Selected = true;
                    rdoCompliance.Items[1].Selected = false;
                }
                else if (objCOI.Compliance_09 == "Y" && ID == 9)
                {
                    rdoCompliance.Items[0].Selected = true;
                    rdoCompliance.Items[1].Selected = false;
                }
                else if (objCOI.Compliance_10 == "Y" && ID == 10)
                {
                    rdoCompliance.Items[0].Selected = true;
                    rdoCompliance.Items[1].Selected = false;
                }

            }
        }
    }
    /// <summary>
    /// ComplianceTextView Item Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dlComplianceTextView_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (PK_COIs != 0)
        {
            COIs objCOI = new COIs(PK_COIs);
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int ID = Convert.ToInt32(((HiddenField)e.Item.FindControl("hdnPK")).Value);
                Label lblIsTurnedOn = (Label)e.Item.FindControl("lblIsTurnedOn");
                if (objCOI.Compliance_01 == "Y" && ID == 1)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_02 == "Y" && ID == 2)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_03 == "Y" && ID == 3)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_04 == "Y" && ID == 4)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_05 == "Y" && ID == 5)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_06 == "Y" && ID == 6)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_07 == "Y" && ID == 7)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_08 == "Y" && ID == 8)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_09 == "Y" && ID == 9)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_10 == "Y" && ID == 10)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else
                {
                    lblIsTurnedOn.Text = "NO";
                }
            }
        }
    }
    /// <summary>
    /// Handles Back Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBackToCOIList_Click(object sender, EventArgs e)
    {
        // Back to COI list page
        Response.Redirect("COIList.aspx");
    }

    /// <summary>
    /// Back Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("COIList.aspx");
    }

    /// <summary>
    /// Handles Edit Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("COIAddEdit.aspx?op=edit&id=" + Encryption.Encrypt(PK_COIs.ToString()));
    }
    /// <summary>
    /// Handles OwnershipDetail Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOwnershipDetails_Click(object sender, EventArgs e)
    {

        DataTable dtTempBuilding;
        txtName.Text = hdntxtName.Value;
        txtSubleaseName.Text = hdntxtName.Value;
        txtLandlordName.Text = hdnLandlordName.Value;
        string strAddress1 = hdntxtAddress1.Value;
        string strAddress2 = hdntxtAddress2.Value;
        string strBuildingNumber = hdnBuilding_Number.Value;
        string strCity = hdntxtCity.Value;
        string strState = hdndrpState.Value;

        txtBuilding_TIV.Text = hdntxtBuilding_TIV.Value;
        txtContactFirstName.Text = hdntxtContactFirstName.Value;
        txtContactLastName.Text = hdntxtContactLastName.Value;
        txtContactTitle.Text = hdntxtContactTitle.Value;
        txtContactPhone.Text = hdntxtContactPhone.Value;
        txtContactFax.Text = hdntxtContactFax.Value;
        txtContactEmail.Text = hdntxtContactEmail.Value;

        ListItem lstDBA = ddlDBA.Items.FindByText(Convert.ToString(hdnDBA.Value));
        if (lstDBA != null)
            ddlDBA.SelectedValue = lstDBA.Value;

        if (hdnstrRegion.Value != "")
            drpRegion.SelectedValue = hdnstrRegion.Value;
        else
            drpRegion.SelectedValue = "0";
        //txtName.Enabled = false;
        //txtBuilding_TIV.Enabled = false;
        //txtContactFirstName.Enabled = false;
        //txtContactLastName.Enabled = false;
        //txtContactTitle.Enabled = false;
        //txtContactPhone.Enabled = false;
        //txtContactFax.Enabled = false;
        //txtContactEmail.Enabled = false;
        dtTempBuilding = (DataTable)Session["dt_Building"];
        // IN PopUp Data are fetch PK_Location_ID field and bind Building Information Data in BuildingGrid
        decimal decPK_LU_Location_ID = Convert.ToDecimal(hdnPK_LU_Location_ID.Value);

        //DataTable dtBuildingInformation = clsCOI_Insureds_Buildings.Select_Building_By_Location_ID(decPK_LU_Location_ID).Tables[0];
        DataTable dtBuildingInformation = clsCOI_Insureds_Buildings.Select_Building_SelectByPK_LU_Location_IDANDLandLord(decPK_LU_Location_ID, hdnLandlordName.Value, hdntxtName.Value).Tables[0];
        if (dtBuildingInformation != null && dtBuildingInformation.Rows.Count > 0)
        {
            if (dtTempBuilding != null && dtTempBuilding.Rows.Count > 0)
            {

                for (int i = dtTempBuilding.Rows.Count - 1; i >= 0; i--)
                {
                    //Remove DataTable Row in selected BuildingNumber record
                    DataRow dr = dtTempBuilding.Rows[i];
                    dtTempBuilding.Rows.Remove(dr);
                }
                dtTempBuilding.AcceptChanges();
                foreach (DataRow drBuilding in dtBuildingInformation.Rows)
                {
                    {
                        DataRow[] drArray = dtTempBuilding.Select("Building_Number='" + Convert.ToString(drBuilding["Building_Number"]) + "'");
                        if (drArray == null || drArray.Length == 0)
                            dtTempBuilding.ImportRow(drBuilding);
                    }
                }
            }
            else
            {
                foreach (DataRow drBuilding in dtBuildingInformation.Rows)
                {
                    dtTempBuilding.ImportRow(drBuilding);
                }
            }
            dtTempBuilding.DefaultView.Sort = "Building_Number";
            gvBuildingInformation.DataSource = dtTempBuilding.DefaultView.ToTable();
            gvBuildingInformation.DataBind();
            gvBuildingInformation.Columns[2].Visible = (strOperation == "view") ? false : true;
            // Session Data store in Temporary Table 
            Session["dt_Building"] = dtTempBuilding;
        }

        SetBuildingTIV();

        //ddlDBA.Enabled = false;
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    protected void ddlDBA_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDBA.SelectedIndex > 0)
        {
            drpRegion.ClearSelection();
            LU_Location objLoc = new LU_Location(Convert.ToDecimal(ddlDBA.SelectedValue));
            ListItem lst = drpRegion.Items.FindByText(objLoc.Region);
            if (lst != null)
                lst.Selected = true;
            else
                drpRegion.SelectedIndex = 0;
            SetBuildingTIV();
        }
        else
        {
            drpRegion.ClearSelection();
            drpRegion.SelectedIndex = 0;
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    /// <summary>
    /// Handles event when Add building link is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddBuilding_Click(object sender, EventArgs e)
    {
        DataTable dtCOIInfo = null;

        // add sesstion table for coi if does not exist
        if (Session["dtCOI"] == null)
        {
            DataTable dtCOI = new DataTable();
            dtCOI.Columns.Add("Sublease", typeof(string));
            dtCOI.Columns.Add("InsuredName", typeof(string));
            dtCOI.Columns.Add("Issue_Date", typeof(string));
            dtCOI.Columns.Add("LandlordName", typeof(string));
            dtCOI.Columns.Add("SubleaseName", typeof(string));
            dtCOI.Columns.Add("DBA", typeof(string));
            dtCOI.Columns.Add("Region", typeof(string));
            dtCOI.Columns.Add("LastName", typeof(string));
            dtCOI.Columns.Add("FirstName", typeof(string));
            dtCOI.Columns.Add("Title", typeof(string));
            dtCOI.Columns.Add("Email", typeof(string));
            dtCOI.Columns.Add("Phone", typeof(string));
            dtCOI.Columns.Add("Fax", typeof(string));
            dtCOI.Columns.Add("DateActivated", typeof(string));
            dtCOI.Columns.Add("DateClosed", typeof(string));
            dtCOI.Columns.Add("InsuredActive", typeof(string));
            dtCOI.Columns.Add("AMBest", typeof(string));
            dtCOI.Columns.Add("Notes", typeof(string));
            Session["dtCOI"] = dtCOI;
        }
        dtCOIInfo = (DataTable)Session["dtCOI"];
        dtCOIInfo.Clear();

        // get data from page controls and store in session table
        DataRow drCOI = dtCOIInfo.NewRow();
        drCOI["Sublease"] = rdoSubleaseAgreement.SelectedValue;
        drCOI["InsuredName"] = txtName.Text.Trim();
        drCOI["Issue_Date"] = txtIssueDate.Text.Trim();
        drCOI["LandlordName"] = txtLandlordName.Text.Trim();
        drCOI["SubleaseName"] = txtSubleaseName.Text.Trim();
        drCOI["DBA"] = ddlDBA.SelectedValue;
        drCOI["Region"] = drpRegion.SelectedValue;
        drCOI["LastName"] = txtContactLastName.Text.Trim();
        drCOI["FirstName"] = txtContactFirstName.Text.Trim();
        drCOI["Title"] = txtContactTitle.Text.Trim();
        drCOI["Email"] = txtContactEmail.Text.Trim();
        drCOI["Phone"] = txtContactPhone.Text.Trim();
        drCOI["Fax"] = txtContactFax.Text.Trim();
        //drCOI["DateActivated"] = txtDateActivated.Text.Trim();
        //drCOI["DateClosed"] = txtDateClosed.Text.Trim();
        drCOI["InsuredActive"] = rdoInsuredActive.SelectedValue;
        drCOI["AMBest"] = rdoAMBestRequired.SelectedValue;
        drCOI["Notes"] = txtNotes.Text.Trim();
        dtCOIInfo.Rows.Add(drCOI);
        Session["dtCOI"] = dtCOIInfo;

        Response.Redirect("COIInsuredBuilding.aspx?coi=" + PK_COIs_Encrypt.ToString());
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

        #region "Insureds"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(96).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Insured Name":
                    strCtrlsIDs += txtName.ClientID + ",";
                    strMessages += "Please enter [Insured]/Insured Name " + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Issue Date":
                    strCtrlsIDs += txtIssueDate.ClientID + ",";
                    strMessages += "Please enter [Insured]/Date Received" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "D/B/A Location Name":
                    strCtrlsIDs += ddlDBA.ClientID + ",";
                    strMessages += "Please select [Insured]/ D/B/A Location Name" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                //case "Address 1":
                //    strCtrlsIDs += txtAddress1.ClientID + ",";
                //    strMessages += "Please enter [Insured]/Address 1" + ",";
                //    Span5.Style["display"] = "inline-block";
                //    break;
                case "Contact Last Name":
                    strCtrlsIDs += txtContactLastName.ClientID + ",";
                    strMessages += "Please enter [Insured]/Contact Last Name" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                //case "Address 2":
                //    strCtrlsIDs += txtAddress2.ClientID + ",";
                //    strMessages += "Please enter [Insured]/Address 2" + ",";
                //    Span7.Style["display"] = "inline-block";
                //    break;
                case "Contact First Name":
                    strCtrlsIDs += txtContactFirstName.ClientID + ",";
                    strMessages += "Please enter [Insured]/Contact First Name" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                //case "City":
                //    strCtrlsIDs += txtCity.ClientID + ",";
                //    strMessages += "Please enter [Insured]/City" + ",";
                //    Span9.Style["display"] = "inline-block";
                //    break;
                case "Contact Title":
                    strCtrlsIDs += txtContactTitle.ClientID + ",";
                    strMessages += "Please enter [Insured]/Contact Title" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                //case "State":
                //    strCtrlsIDs += drpState.ClientID + ",";
                //    strMessages += "Please select [Insured]/State" + ",";
                //    Span11.Style["display"] = "inline-block";
                //    break;
                case "Contact Phone":
                    strCtrlsIDs += txtContactPhone.ClientID + ",";
                    strMessages += "Please enter [Insured]/Contact Phone" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                //case "Zip Code":
                //    strCtrlsIDs += txtZipCode.ClientID + ",";
                //    strMessages += "Please enter [Insured]/Zip Code" + ",";
                //    Span13.Style["display"] = "inline-block";
                //    break;
                case "Contact Fax":
                    strCtrlsIDs += txtContactFax.ClientID + ",";
                    strMessages += "Please enter [Insured]/Contact Fax" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                //case "Type ":
                //    strCtrlsIDs += drpType.ClientID + ",";
                //    strMessages += "Please select [Insured]/Type " + ",";
                //    Span15.Style["display"] = "inline-block";
                //    break;
                case "Contact E-Mail":
                    strCtrlsIDs += txtContactEmail.ClientID + ",";
                    strMessages += "Please enter [Insured]/Contact E-Mail" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                //case "Date Activated":
                //    strCtrlsIDs += txtDateActivated.ClientID + ",";
                //    strMessages += "Please enter [Insured]/Date Activated" + ",";
                //    Span17.Style["display"] = "inline-block";
                //    break;
                //case "Date Closed":
                //    strCtrlsIDs += txtDateClosed.ClientID + ",";
                //    strMessages += "Please enter [Insured]/Date Closed" + ",";
                //    Span18.Style["display"] = "inline-block";
                //    break;
                case "Region ":
                    strCtrlsIDs += drpRegion.ClientID + ",";
                    strMessages += "Please select [Insured]/Region " + ",";
                    Span19.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Insured]/Notes" + ",";
                    Span20.Style["display"] = "inline-block";
                    break;
                case "Date Requested":
                    strCtrlsIDs += txtDateRequested.ClientID + ",";
                    strMessages += "Please enter [Insured]/Date Requested" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Risk Profile"
        dtFields = clsScreen_Validators.SelectByScreen(97).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case " Risk Profile ":
                    strCtrlsIDs += drpRiskProfile.ClientID + ",";
                    strMessages += "Please select [Risk Profile]/Risk Profile " + ",";
                    Span21.Style["display"] = "inline-block";
                    break;
                case " Profile Notes":
                    strCtrlsIDs += txtProfileNote.ClientID + ",";
                    strMessages += "Please enter [Risk Profile]/Profile Notes" + ",";
                    Span23.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Compliance"
        dtFields = clsScreen_Validators.SelectByScreen(98).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk3.Style["display"] = (dtFields.Select("LeftMenuIndex = 3").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Certificate Includes Notice of Cancellation of":
                    strCtrlsIDs += txtCancellationNotice.ClientID + ",";
                    strMessages += "Please enter [Compliance]/Certificate Includes Notice of Cancellation of Days" + ",";
                    Span24.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Notification Letter"
        dtFields = clsScreen_Validators.SelectByScreen(99).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk4.Style["display"] = (dtFields.Select("LeftMenuIndex = 4").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Signature":
                    strCtrlsIDs += drpSignature.ClientID + ",";
                    strMessages += "Please select [Notification Letter]/Signature" + ",";
                    Span25.Style["display"] = "inline-block";
                    break;
                case "Level 1 Text":
                    strCtrlsIDs += txtLevel1Text.ClientID + ",";
                    strMessages += "Please enter [Notification Letter]/Level 1 Text" + ",";
                    Span26.Style["display"] = "inline-block";
                    break;
                case "Level 2 Text":
                    strCtrlsIDs += txtLevel2Text.ClientID + ",";
                    strMessages += "Please enter [Notification Letter]/Level 2 Text" + ",";
                    Span27.Style["display"] = "inline-block";
                    break;
                case "Level 3 Text":
                    strCtrlsIDs += txtLevel3Text.ClientID + ",";
                    strMessages += "Please enter [Notification Letter]/Level 3 Text" + ",";
                    Span28.Style["display"] = "inline-block";
                    break;
                case "Level 4 Text":
                    strCtrlsIDs += txtLevel4Text.ClientID + ",";
                    strMessages += "Please enter [Notification Letter]/Level 4 Text" + ",";
                    Span29.Style["display"] = "inline-block";
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
    #endregion   
   
}
