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
using System.IO;
using System.Text;
using ERIMS.DAL;

/// <summary>
/// Date           : 18-07-08
/// 
/// Developer Name : Ravi Gupta
/// 
/// Description    : Used to add Worker Compensasion Information to current First Report Wizard ID.
///                  also display Record is View MOde
/// 
/// </summary>
public partial class SONIC_WCFirstReport : clsBasePage
{
    #region Page Level Variable and Property
    /// <summary>
    /// Used to set Page OPeration MOde if Complete field of related table is true than display page in View MOde only. 
    /// else display in edit mode.
    /// </summary>
    public string strPageOpeMode
    {
        get { return Convert.ToString(ViewState["strPageOpeMode"]); }
        set { ViewState["strPageOpeMode"] = value; }
    }
    /// <summary>
    /// Denotes the First Report ID
    /// </summary>
    public int First_Report_Wizard_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["First_Report_Wizard_ID"]);
        }
        set { ViewState["First_Report_Wizard_ID"] = value; }
    }
    /// <summary>
    /// Denotes the WC First Report ID
    /// </summary>
    public int PK_WC_FR_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["WC_FR_ID"]);
        }
        set { ViewState["WC_FR_ID"] = value; }
    }
    #endregion

    #region Main Event

    /// <summary>
    /// Page load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        txtCurrentDate.Text = DateTime.Now.ToShortDateString().ToString();
        SonicTab.SetSelectedTab(Controls_SONICtab_SonicTab.Tab.WC);

        if (Request.QueryString["ClaimReview"] != null && Request.QueryString["ClaimReview"] != string.Empty)
        {
            if (Request.QueryString["ClaimReview"].ToString() == "1")
                btnClaimReview.Visible = true;
            else
                btnClaimReview.Visible = false;
        }
        else
            btnClaimReview.Visible = false;

        //declare Atachment Control Handler for uploding File
        CtrlAttachment.btnHandler += new Sonic_Attachment.OnButtonClick(Upload_File);
        if (!Page.IsPostBack)
        {
            btnSendMail.Visible = (UserAccessType == AccessType.Administrative_Access);
            if (Request.QueryString["WZ_ID"] != null)
            {
                int WZ_ID;
                WZ_ID = Convert.ToInt32(Encryption.Decrypt(Request.QueryString["WZ_ID"]));
                clsSession.First_Report_Wizard_ID = WZ_ID;
                First_Report_Wizard_ID = WZ_ID;
            }
            if (string.IsNullOrEmpty(Convert.ToString(First_Report_Wizard_ID)) || First_Report_Wizard_ID == 0)
            {
                First_Report_Wizard_ID = clsSession.First_Report_Wizard_ID;
            }
            #region General
            //Get id from query string.
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                try
                {
                    PK_WC_FR_ID = Convert.ToInt32(Encryption.Decrypt(Request.QueryString["id"].ToString()));
                    //set Page Mode as per User Access Type if it is View ONly than always open page in
                    //View Mode Only. else if the report is completed  than open page in View MOde Else in Edit MOde
                    if (Module_Access_Mode == AccessType.View_Only)
                    //if (UserAccessType == AccessType.View_Only)
                    {
                        strPageOpeMode = "view";
                    }
                    else
                    {
                        strPageOpeMode = (new WC_FR(PK_WC_FR_ID).Complete == false) ? "edit" : "view";
                    }
                    btnSendMail.Visible = (UserAccessType == AccessType.Administrative_Access) && (new WC_FR(PK_WC_FR_ID).Complete == true);
                }
                catch
                {
                    Response.Redirect("FirstReportSearch.aspx");
                }
            }
            else
            {
                Response.Redirect("FirstReportSearch.aspx");
            }
            #endregion
            //Bind Sonic Header
            setSonicHeaderInfo();
            //Check the Page Mode[add,edit,view]
            if (strPageOpeMode == "add")
            {

                #region Location and Contact Panel
                //fill Sonic Location Number
                //ComboHelper.FillSonicLocationNumber(new DropDownList[] { ddlLocationNumber }, 0, true);
                //Fill Location dba Dropdown
                //ComboHelper.FillLocationdba(new DropDownList[] { ddlLocationdba }, 0, true);
                //Fill Location Legal Entity Dropdown
                //ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, 0, true);
                //Fill Location FKA Dropdown
                //ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);
                //Fill NameDropdown
                //ComboHelper.FillAssociateName(new DropDownList[] { ddlContactName }, 0, true);
                //Fetch Related Record for Location and EMployee
                BindLocationandContactInfo();
                //Bind Contacts Information
                BindContactsInformation();
                //open panel by using ShowPanel function of Javascript
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
                #endregion

                #region Associate Information Panel
                ////Fill associate Name Dropdown
                //ComboHelper.FillAssociateName(new DropDownList[] { ddlAssociateName }, 0, true);
                //fill State Dropdown
                ComboHelper.FillState(new DropDownList[] { ddlState_of_hire }, 0, true);
                //fill Marital Status dropdown
                //ComboHelper.FillMaritalStatus(new DropDownList[] { ddlMarital_Status }, 0, true);
                ////fill Department dropdown
                //ComboHelper.FillDepartment(new DropDownList[] { ddlDepartment }, 0, true);
                #endregion

                #region Incident Information Panel
                //Fill State Dropdown
                ComboHelper.FillState(new DropDownList[] { ddlFiling_State, ddlOffsite_State }, 0, true);
                //Fill Nature of Injury Dropdown
                ComboHelper.FillNatureofInjury(new DropDownList[] { ddlFK_Nature_Of_Injury }, 0, true);
                //Fill Nature of Injury Dropdown
                ComboHelper.FillDepartment(new DropDownList[] { ddlFK_Department_Where_Occurred }, 0, true);
                //Fill Body Part Afftected Dropdown
                //ComboHelper.FillBodyPartAffected(new DropDownList[] { ddlFK_Body_Parts_Affected }, 0, true);
                //Fill Body Part Afftected Dropdown
                ComboHelper.FillBodyPartAffectedByFirstReport(new DropDownList[] { ddlFK_Body_Parts_Affected }, 0, true, "WC%");
                #endregion

                #region Medical Facility Panel
                // fill Medical Facility State
                ComboHelper.FillState(new DropDownList[] { ddlMedical_Facility_State }, 0, true);
                // Fill Physician's State
                ComboHelper.FillState(new DropDownList[] { ddlPhysician_State }, 0, true);
                #endregion

                #region Attchement
                //used to Initialize a Attchment Detail 
                CtrlAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.WC_FR, PK_WC_FR_ID, true, 6);
                CtrlAttachDetails.Bind();
                #endregion

                #region Comments Panel
                lstInitialClaim.Items.AddRange(WC_FR.InitialClaimClassificationList());
                #endregion
            }
            else if (strPageOpeMode == "view")
            {
                //Fetch Location and Employee Information
                BindPageinViewMode();
                //Open Next Panel.
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            }
            else if (strPageOpeMode == "edit")
            {
                #region Location and Contact Panel
                //fill Sonic Location Number
                //ComboHelper.FillSonicLocationNumber(new DropDownList[] { ddlLocationNumber }, 0, true);
                //Fill Location dba Dropdown
                //ComboHelper.FillLocationdba(new DropDownList[] { ddlLocationdba }, 0, true);
                //Fill Location Legal Entity Dropdown
                //ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, 0, true);
                //Fill Location FKA Dropdown
                //ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);
                //Fill NameDropdown
                //ComboHelper.FillAssociateName(new DropDownList[] { ddlContactName }, 0, true);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
                #endregion

                #region Associate Information Panel
                //Fill NameDropdown
                //ComboHelper.FillAssociateName(new DropDownList[] { ddlAssociateName }, 0, true);
                ComboHelper.FillState(new DropDownList[] { ddlState_of_hire }, 0, true);
                //ComboHelper.FillMaritalStatus(new DropDownList[] { ddlMarital_Status }, 0, true);
                //ComboHelper.FillDepartment(new DropDownList[] { ddlDepartment }, 0, true);
                #endregion

                #region Incident Information Panel
                //Fill State Dropdown
                ComboHelper.FillState(new DropDownList[] { ddlFiling_State, ddlOffsite_State}, 0, true);
                //Fill Nature of Injury Dropdown
                ComboHelper.FillNatureofInjury(new DropDownList[] { ddlFK_Nature_Of_Injury }, 0, true);
                //Fill Nature of Injury Dropdown
                ComboHelper.FillDepartment(new DropDownList[] { ddlFK_Department_Where_Occurred }, 0, true);
                //Fill Body Part Affected Dropdown
                //ComboHelper.FillBodyPartAffected(new DropDownList[] { ddlFK_Body_Parts_Affected }, 0, true);
                ComboHelper.FillBodyPartAffectedByFirstReport(new DropDownList[] { ddlFK_Body_Parts_Affected }, 0, true, "WC%");
                #endregion

                #region Medical Facility Panel
                // fill Medical Facility State
                ComboHelper.FillState(new DropDownList[] { ddlMedical_Facility_State }, 0, true);
                // Fill Physician's State
                ComboHelper.FillState(new DropDownList[] { ddlPhysician_State }, 0, true);
                #endregion

                #region Comments Panel
                lstInitialClaim.Items.AddRange(WC_FR.InitialClaimClassificationList());
                #endregion

                #region Attchement
                CtrlAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.WC_FR, PK_WC_FR_ID, true, 6);
                CtrlAttachDetails.Bind();
                #endregion

                //Bind Page in Edit Mode
                BindPageinEditMode();
            }
            if (strPageOpeMode != "view")
                SetValidations();
        }
        else
        {
            string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];

            // if postback by Confirmation dialog then save record
            if (eventTarget == "UserConfirmationPostBack")
            {
                if (eventArgument == "true")
                {
                    Int32 intRetVal = ComplateWC_FRReport(false);
                    Investigation objInv = new Investigation();

                    if (intRetVal == 1)
                    {
                        int InvestigationID = Investigation.SelectPKByWc_FR_ID(PK_WC_FR_ID);
                        if (InvestigationID <= 0)
                        {
                            objInv.FK_WC_FR_ID = Convert.ToInt32(PK_WC_FR_ID);
                            objInv.FK_LU_Location_ID = Convert.ToInt32(new WC_FR(PK_WC_FR_ID).FK_LU_Location);
                            objInv.Updated_Date = System.DateTime.Now;
                            SaveInvestigation(objInv, PK_WC_FR_ID);
                            InvestigationID = objInv.Insert();
                            
                        }

                        Response.Redirect(AppConfig.SiteURL + "SONIC/FirstReport/Investigation.aspx?id=" + Encryption.Encrypt(InvestigationID.ToString()) + "&wc=" + Encryption.Encrypt(PK_WC_FR_ID.ToString()) + "&op=edit");

                        //Response.Redirect("FirstReportStatus.aspx", true);
                    }
                    else if (intRetVal == -1)
                    {
                        //use to open panel.use ShowPanel javascript Function
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('First Report is already submited');ShowPanel(6);", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:FireAll(); ShowPanel(6);", true);
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('the First Report e-mail send without the attachments.');ShowPanel(6);", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('The First Report has NOT been sent, please reduce the number and/or size of the attachments before attempting to resubmit with attachments.');ShowPanel(6);", true);
                }
            }
            else if (eventTarget == "UserConfirmationPostBackView")
            {
                if (eventArgument == "true")
                {
                    if (ReSendReport(false))
                        ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('the First Report e-mail send without the attachments.');ShowPanel(6);", true);
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "alert('Something went wrong. Please try after sometime.'); window.location='FirstReportSearch.aspx';", true);
                    }
                }
            }
            if (First_Report_Wizard_ID != clsSession.First_Report_Wizard_ID)
                clsSession.First_Report_Wizard_ID = First_Report_Wizard_ID;
        }
    }

    #endregion

    #region Save and Continue Event

    /// <summary>
    /// Locaiton Information Panel Save Button CLick
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLocationSave_Click(object sender, EventArgs e)
    {
        //Update Fax Number INformation
        UpdateLocationInformation();
        //Bind Sonic Header
        setSonicHeaderInfo();
        //Open Next Panel.
        //ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(2);", true);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:FireAll();ShowPanel(2);", true);
    }

    /// <summary>
    /// Associate Information Panel Save Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAssociateSave_Click(object sender, EventArgs e)
    {
        //Update Asscoiate Information of WC_FR table
        UpdateAssociateInformation();
        //this is hidden field that are used to check that the panel is saved or not. because this panel
        //contain Require fields and we must have to save this panel. if it is not done than the value of hidden
        //Control is blank and given a prompt when user click on submit button at comment & attachment Panel
        hdnAssociate.Value = "1";
        //Bind Sonic Header
        setSonicHeaderInfo();
        //Open Next Panel.
        //ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(3);", true);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:FireAll();ShowPanel(3);", true);

    }

    /// <summary>
    /// Incident Information Panel Save Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnIncidentSave_Click(object sender, EventArgs e)
    {
        // Update Incident Information of WC_FR table
        UpdateIncidentInformation();
        //this is hidden field that are used to check that the panel is saved or not. because this panel
        //contain Require fields and we must have to save this panel. if it is not done than the value of hidden
        //Control is blank and given a prompt when user click on submit button at comment & attachment Panel
        hdnIncident.Value = "1";
        //Bind Sonic Header
        setSonicHeaderInfo();
        //Open Next Panel.
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:FireAll(); ShowPanel(4);", true);
        //ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(4);", true);
    }

    /// <summary>
    /// Medical Panel Save Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnMedicalSave_Click(object sender, EventArgs e)
    {
        //Update Medical Information of WC_FR table
        UpdateMedicalInformation();
        //Bind Sonic Header
        setSonicHeaderInfo();
        //Open Next Panel.
        //ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(5);", true);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:FireAll();ShowPanel(5);", true);

    }

    /// <summary>
    /// Contact Informaiton Panel Save Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnContactsSave_Click(object sender, EventArgs e)
    {
        //Bind Sonic Header
        setSonicHeaderInfo();
        //Open Next Panel.
        //ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(6);", true);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:FireAll();ShowPanel(6);", true);
    }

    /// <summary>
    /// Submit Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Complate WC_First Report and Send Email.
        Int32 intRetVal = ComplateWC_FRReport(true);
        Investigation objInv = new Investigation();

        if (intRetVal == 1)
        {
            int InvestigationID = Investigation.SelectPKByWc_FR_ID(PK_WC_FR_ID);
            if (InvestigationID <= 0)
            {
                objInv.FK_WC_FR_ID = Convert.ToInt32(PK_WC_FR_ID);
                objInv.FK_LU_Location_ID = Convert.ToInt32(new WC_FR(PK_WC_FR_ID).FK_LU_Location);
                objInv.Updated_Date = System.DateTime.Now;
                SaveInvestigation(objInv, PK_WC_FR_ID);
                InvestigationID = objInv.Insert();
            }

            Response.Redirect(AppConfig.SiteURL + "SONIC/FirstReport/Investigation.aspx?id=" + Encryption.Encrypt(InvestigationID.ToString()) + "&wc=" + Encryption.Encrypt(PK_WC_FR_ID.ToString()) + "&op=edit&isStatus=True");

            //Response.Redirect("FirstReportStatus.aspx", true);
        }
        else if (intRetVal == -1)
        {
            //use to open panel.use ShowPanel javascript Function
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('First Report is already submited');ShowPanel(6);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:FireAll(); ShowPanel(6);", true);
        }
    }

    #endregion

    #region Location and Contact Panel Events

    /// <summary>
    /// Used to Bind Location Information and Contact Details
    /// </summary>
    public void BindLocationandContactInfo()
    {
        DataSet dsFRW = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.WC_FR, PK_WC_FR_ID);
        DataTable dtFRW = dsFRW.Tables[0];
        foreach (DataRow drFRW in dtFRW.Rows)
        {
            #region Fill Location Information Controls
            //select value from Location Number Dropdown
            if (drFRW["ADP_DMS"] != null)
            {
                txtLocationNumberEdit.Text = Convert.ToString(drFRW["sonic_location_code"]);
                //ListItem lstRMLocaiton = new ListItem();
                //lstRMLocaiton = ddlLocationNumber.Items.FindByText(drFRW["RM_Location_Number"].ToString());
                ////check ListItem is not null.if true than select the item
                //if (lstRMLocaiton != null)
                //{
                //    lstRMLocaiton.Selected = true;
                //}
                //fill Associate Information Dropdown
                //fill Associate Information Dropdown
                string strSonicLocationCode = Convert.ToString(drFRW["Sonic_Location_Code"]);
                ComboHelper.FillAssociateByContact(new DropDownList[] { ddlAssociateName }, true, Convert.ToInt32(strSonicLocationCode));
                //string[] strCostCenter = ddlLocationNumber.SelectedItem.ToString().Split(Convert.ToChar("."));
                //ComboHelper.FillAssociateByContact(new DropDownList[] { ddlAssociateName }, true, (ddlLocationNumber.SelectedIndex > 0) ? Convert.ToInt32(strCostCenter[strCostCenter.Length - 1].ToString()) : 0);
                //ComboHelper.FillAssociateByContact(new DropDownList[] { ddlAssociateName }, true, (ddlLocationNumber.SelectedIndex > 0) ? Convert.ToInt32(ddlLocationNumber.SelectedValue) : 0);
            }
            //select value from Location d/b/a Dropdown
            txtLocationdbaEdit.Text = drFRW["dba"].ToString();
            //if (drFRW["dba"] != null)
            //{
            //    ListItem lstdba = new ListItem();
            //    lstdba = ddlLocationdba.Items.FindByText(drFRW["dba"].ToString());
            //    //check ListItem is not null.if true than select the item
            //    if (lstdba != null)
            //    {
            //        lstdba.Selected = true;
            //    }
            //}
            //select value from Location f/k/a Dropdown
            txtLocationfkaEdit.Text = new LU_Location_FKA((drFRW["FK_Location_ID"] != null) ? Convert.ToInt32(drFRW["FK_Location_ID"]) : 0, true).fka;
            //if (drFRW["FK_Location_ID"] != null)
            //{
            //    //Fill Location FKA Dropdown
            //    ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, (drFRW["FK_Location_ID"] != null) ? Convert.ToInt32(drFRW["FK_Location_ID"]) : 0, true);
            //}
            //select value from Location Legal Entity Dropdown
            //txtLegalEntityEdit.Text = drFRW["legal_entity"].ToString();
            //if (drFRW["legal_entity"] != null)
            //{
            //    ListItem lstLegalEntity = new ListItem();
            //    lstLegalEntity = ddlLegalEntity.Items.FindByText(drFRW["legal_entity"].ToString());
            //    //check ListItem is not null.if true than select the item
            //    if (lstLegalEntity != null)
            //    {
            //        lstLegalEntity.Selected = true;
            //    }
            //}

            //set address1,address2,city,state,ZipCOde Values
            txtLocationAddress1.Text = (drFRW["Address_1"] != null) ? Convert.ToString(drFRW["Address_1"]) : "";
            txtLocationAddress2.Text = (drFRW["Address_2"] != null) ? Convert.ToString(drFRW["Address_2"]) : "";
            txtLocationCity.Text = (drFRW["City"] != null) ? Convert.ToString(drFRW["City"]) : "";
            txtLocationState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state;
            txtLocationZipCode.Text = (drFRW["Zip_Code"] != null) ? Convert.ToString(drFRW["Zip_Code"]) : "";

            #endregion

            #region Fill Contact Information Controls
            //select value from Contact Name Dropdown
            txtContactNameEdit.Text = new Employee(Convert.ToDecimal(drFRW["FK_Employee_ID"].ToString())).Last_Name.Trim() + ", " + new Employee(Convert.ToDecimal(drFRW["FK_Employee_ID"].ToString())).First_Name.Trim() + " " + new Employee(Convert.ToDecimal(drFRW["FK_Employee_ID"].ToString())).Middle_Name.Trim();

            // set job Title,Telephone1,Telephone2,Fax Email Address
            txtContactTitle.Text = (drFRW["Job_Title"] != null) ? Convert.ToString(drFRW["Job_Title"]) : "";
            txtContactTelephoneNumber1.Text = (drFRW["TelephoneNumber1"] != null) ? Convert.ToString(drFRW["TelephoneNumber1"]) : "";
            txtContactTelephoneNumber2.Text = (drFRW["TelephoneNumber2"] != null) ? Convert.ToString(drFRW["TelephoneNumber2"]) : "";
            txtContactFaxNumber.Text = (drFRW["Contact_Fax"] != null) ? Convert.ToString(drFRW["Contact_Fax"]) : "";
            txtContactEmailAddress.Text = (drFRW["FRWEmail"] != null) ? Convert.ToString(drFRW["FRWEmail"]) : "";
            #endregion
        }
    }

    #endregion

    #region Update Location Information Panel Events
    /// <summary>
    /// Update Location Information
    /// </summary>
    public void UpdateLocationInformation()
    {
        //Update Fax Number to First_Report_Wizard Table
        First_Report_Wizard objFRW = new First_Report_Wizard(First_Report_Wizard_ID);

        objFRW.Contact_Fax = txtContactFaxNumber.Text;
        //used to check First Report Wizard if if it is greater than 0 than Update First_Report_Wizard table.
        if (First_Report_Wizard_ID > 0)
        {
            objFRW.Update();
        }
    }
    #endregion

    #region Associate Information Panel Events
    /// <summary>
    /// Associate Dropdown selected Index change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlAssociateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Define Object
        Employee objEmployee = new Employee((ddlAssociateName.SelectedIndex > 0) ? Convert.ToInt32(ddlAssociateName.SelectedValue) : 0);
        // Set Values to Controls
        txtDate_Of_Birth.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Date_Of_Birth);
        //if date of birth is not null than count the age and set the value to control
        if (objEmployee.Date_Of_Birth != null)
        {
            if (Convert.ToDateTime(objEmployee.Date_Of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                txtCountdate_of_birth.Text = GetAge(Convert.ToDateTime(objEmployee.Date_Of_Birth));
            else
                txtCountdate_of_birth.Text = "";
        }
        else
        {
            txtCountdate_of_birth.Text = "";
        }
        txtGender.Text = Convert.ToString(objEmployee.Sex);
        txtAddress_1.Text = Convert.ToString(objEmployee.Employee_Address_1);
        if (!string.IsNullOrEmpty(objEmployee.Social_Security_Number))
            txtSocial_Security_Number.Text = clsGeneral.SupressString(objEmployee.Social_Security_Number.ToString(), objEmployee.Social_Security_Number.ToString().Length - 4);
        else
            txtSocial_Security_Number.Text = "";

        if (!string.IsNullOrEmpty(objEmployee.Employee_Address_2))
            txtAddress_2.Text = objEmployee.Employee_Address_2.ToString();

        txtDate_of_Hire.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Hire_Date);
        if (!string.IsNullOrEmpty(objEmployee.Employee_City))
            txtCity.Text = objEmployee.Employee_City.ToString();
        if (!string.IsNullOrEmpty(objEmployee.Job_Title))
            txtJob_Title.Text = objEmployee.Job_Title.ToString();
        //txtDescription.Text = new LU_Job_Classification((objEmployee.FK_Job_Classification != null) ? Convert.ToDecimal(objEmployee.FK_Job_Classification) : 0).Description;
        if (objEmployee.Employee_State != null)
            txtStateEdit.Text = new State((decimal)objEmployee.Employee_State).FLD_state;
        //ListItem lst = new ListItem();
        //ddlState.ClearSelection();
        //lst = ddlState.Items.FindByValue(objEmployee.Employee_State.ToString());
        ////check Listitem value.if it is not null than select the value
        //if (lst != null)
        //{
        //    lst.Selected = true;
        //}
        if (!string.IsNullOrEmpty(objEmployee.Employee_Zip_Code))
            txtZip_code.Text = objEmployee.Employee_Zip_Code.ToString();
        if (!string.IsNullOrEmpty(objEmployee.Occupation_Description))
            txtOccupation_description.Text = objEmployee.Occupation_Description.ToString();
        if (!string.IsNullOrEmpty(objEmployee.Employee_Home_Phone))
            txtHome_Phone.Text = objEmployee.Employee_Home_Phone.ToString();
        if (!string.IsNullOrEmpty(objEmployee.Employee_Cell_Phone))
            txtCell_phone.Text = objEmployee.Employee_Cell_Phone.ToString();

        //check if salary is -1 than display blank
        if (objEmployee.Salary != null)
        {
            if (objEmployee.Salary != -1)
                txtSalary.Text = clsGeneral.SupressString(objEmployee.Salary.ToString(), objEmployee.Salary.ToString().Length);
            else
                txtSalary.Text = "";
        }
        if (!string.IsNullOrEmpty(objEmployee.Frequency))
            txtSalary_Frequency.Text = objEmployee.Frequency.ToString();

        if (!string.IsNullOrEmpty(objEmployee.Supervisor))
            txtSupervisor_Name.Text = objEmployee.Supervisor.ToString();

        if (!string.IsNullOrEmpty(objEmployee.Drivers_License_State))
            txtDriver_License_stateEdit.Text = objEmployee.Drivers_License_State.ToString();

        if (!string.IsNullOrEmpty(objEmployee.Drivers_License_Number))
            txtDriver_License_Number.Text = objEmployee.Drivers_License_Number.ToString();

        if (!string.IsNullOrEmpty(objEmployee.Email))
            txtemail.Text = objEmployee.Email.ToString();

        //check if Employee Associate ID is -1 than display blank
        if (objEmployee.PK_Employee_ID != -1)
            txtSonic_Employee_ID.Text = objEmployee.PK_Employee_ID.ToString();
        else
            txtSonic_Employee_ID.Text = "";
        //check if No of Department is -1 than display blank
        if (objEmployee.Number_Of_Dependents != null)
            txtNumber_of_Dependents.Text = objEmployee.Number_Of_Dependents.ToString();
        else
            txtNumber_of_Dependents.Text = "";

        if (objEmployee.FK_Marital_Status != null)
            txtMarital_StatusEdit.Text = new Marital_Status(objEmployee.FK_Marital_Status.ToString() != string.Empty ? Convert.ToDecimal(objEmployee.FK_Marital_Status.ToString()) : 0).FLD_desc;

        if (!string.IsNullOrEmpty(objEmployee.Active_Inactive_Leave))
            txtActive_Inactive_Leave.Text = objEmployee.Active_Inactive_Leave;

        //Used to Disable Controls
        DisableAssociateControls(false);
        //ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(2);", true);
        //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:FireAll(); ShowPanel(2);", true);
    }
    /// <summary>
    /// Used to Displable/Enable COntrols as per Passed Value of Associate Information Panel
    /// </summary>
    /// <param name="value"></param>
    public void DisableAssociateControls(bool value)
    {
        txtDate_Of_Birth.Enabled = value;
        txtGender.Enabled = value;
        txtAddress_1.Enabled = value;
        txtSocial_Security_Number.Enabled = value;
        txtAddress_2.Enabled = value;
        txtDate_of_Hire.Enabled = value;
        txtCity.Enabled = value;
        txtJob_Title.Enabled = value;
        txtDescription.Enabled = value;
        //ddlState.Enabled = value;
        txtZip_code.Enabled = value;
        txtOccupation_description.Enabled = value;
        txtHome_Phone.Enabled = value;
        txtCell_phone.Enabled = value;
        txtSalary.Enabled = value;
        txtSalary_Frequency.Enabled = value;
        txtSupervisor_Name.Enabled = value;
        //ddlDriver_License_state.Enabled = value;
        txtDriver_License_Number.Enabled = value;
        txtemail.Enabled = value;
        txtSonic_Employee_ID.Enabled = value;
        txtNumber_of_Dependents.Enabled = value;
        //ddlMarital_Status.Enabled = value;
        txtActive_Inactive_Leave.Enabled = value;
    }

    /// <summary>
    /// Used to Update Associated Informaiton to WC_FR table
    /// </summary>
    public void UpdateAssociateInformation()
    {
        // Declare Object
        WC_FR objWC_FR = new WC_FR(PK_WC_FR_ID);
        // Set Values of Object for update
        objWC_FR.FK_Injured = (ddlAssociateName.SelectedIndex > 0) ? Convert.ToDecimal(ddlAssociateName.SelectedValue) : 0;
        objWC_FR.Alternate_Phone_2 = txtAlternate_Phone_2.Text;
        objWC_FR.Employee_hrs_per_week = (txtEmployee_hrs_per_week.Text != "") ? Convert.ToDecimal(txtEmployee_hrs_per_week.Text.ToString()) : 0;
        objWC_FR.Employee_Days_per_week = (txtEmployee_Days_per_week.Text != "") ? Convert.ToDecimal(txtEmployee_Days_per_week.Text.ToString()) : 0;
        objWC_FR.Employee_Time_Shift_Begins = txtEmployee_Time_Shift_Begins.Text;
        objWC_FR.Supervisor_Phone = txtSupervisor_Telephone.Text;
        objWC_FR.Employee_Time_Shift_Ends = txtEmployee_Time_Shift_Ends.Text;
        objWC_FR.Motor_Vehicle_Accident = (rdoMotor_Vehicle_Accident.SelectedValue == "Y") ? true : false;
        objWC_FR.State_of_Hire = (ddlState_of_hire.SelectedIndex > 0) ? ddlState_of_hire.SelectedValue.ToString() : "0";
        //check PK id. if greater than 0 than update WC_FR table
        if (PK_WC_FR_ID > 0)
        {
            objWC_FR.Update();
        }
    }
    #endregion

    #region Incident Information Panel Events
    /// <summary>
    /// Used to Update Incident Information
    /// </summary>
    public void UpdateIncidentInformation()
    {
        // Declare Object
        WC_FR objWC_FR = new WC_FR(PK_WC_FR_ID);

        // Set Values of Object for update
        objWC_FR.Date_Of_Incident = txtDate_Of_Incident.Text;
        objWC_FR.Time_Of_Incident = txtTime_Of_Incident.Text;
        objWC_FR.Filing_State = (ddlFiling_State.SelectedIndex > 0) ? ddlFiling_State.SelectedValue : "0";
        objWC_FR.InjuryOccurredOffsite = (rdoInjuryOccurredOffsite.SelectedValue == "Y") ? true : false;
        //check radio button value if it is "Y" than related fields are displyed else remains hidden.
        if (rdoInjuryOccurredOffsite.SelectedValue == "Y")
        {
            hdnOnsiteOffsite.Value = "1";
            objWC_FR.Offsite_Address1 = txtOffsite_Address1.Text;
            objWC_FR.Offsite_Address2 = txtOffsite_Address2.Text;
            objWC_FR.Offsite_City = txtOffsite_City.Text;
            objWC_FR.Offsite_State = (ddlOffsite_State.SelectedIndex > 0) ? ddlOffsite_State.SelectedValue.ToString() : "0";
            objWC_FR.Offsite_zip = txtOffsite_zip.Text;
        }
        else
        {
            hdnOnsiteOffsite.Value = "0";
            objWC_FR.Offsite_Address1 = "";
            objWC_FR.Offsite_Address2 = "";
            objWC_FR.Offsite_City = "";
            objWC_FR.Offsite_State = "0";
            objWC_FR.Offsite_zip = "";
        }
        objWC_FR.Description_Of_Incident = txtDescription_Of_Incident.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoAssociate_Injured_Regular_Job.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false
            if (rdoAssociate_Injured_Regular_Job.SelectedValue == "Y")
            {
                objWC_FR.Associate_Injured_Regular_Job = true;
            }
            else
            {
                objWC_FR.Associate_Injured_Regular_Job = false;
            }
        }
        else
            objWC_FR.Associate_Injured_Regular_Job = null;

        objWC_FR.FK_Nature_Of_Injury = (ddlFK_Nature_Of_Injury.SelectedIndex > 0) ? Convert.ToDecimal(ddlFK_Nature_Of_Injury.SelectedValue) : 0;
        objWC_FR.FK_Department_Where_Occurred = (ddlFK_Department_Where_Occurred.SelectedIndex > 0) ? Convert.ToDecimal(ddlFK_Department_Where_Occurred.SelectedValue) : 0;
        objWC_FR.FK_Body_Parts_Affected = (ddlFK_Body_Parts_Affected.SelectedIndex > 0) ? ddlFK_Body_Parts_Affected.SelectedValue : "0";
        //use to check selected value if it is "-1" than value set to null.
        if (rdoSafeguards_Provided.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false
            if (rdoSafeguards_Provided.SelectedValue == "Y")
            {
                objWC_FR.Safeguards_Provided = true;
            }
            else
            {
                objWC_FR.Safeguards_Provided = false;
            }
        }
        else
            objWC_FR.Safeguards_Provided = null;

        //use to check selected value if it is "-1" than value set to null.
        if (rdoSafeguards_Used.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false
            if (rdoSafeguards_Used.SelectedValue == "Y")
            {
                objWC_FR.Safeguards_Used = true;
            }
            else
            {
                objWC_FR.Safeguards_Used = false;
            }
        }
        else
            objWC_FR.Safeguards_Used = null;

        //use to check selected value if it is "-1" than value set to null.
        if (rdoMachine_Part_Involved.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false
            if (rdoMachine_Part_Involved.SelectedValue == "Y")
            {
                objWC_FR.Machine_Part_Involved = true;
            }
            else
            {
                objWC_FR.Machine_Part_Involved = false;
            }
        }
        else
            objWC_FR.Machine_Part_Involved = null;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoMachine_Part_Defective.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false
            if (rdoMachine_Part_Defective.SelectedValue == "Y")
            {
                objWC_FR.Machine_Part_Defective = true;
            }
            else
            {
                objWC_FR.Machine_Part_Defective = false;
            }
        }
        else
            objWC_FR.Machine_Part_Defective = null;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoClaim_Questionable.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false
            if (rdoClaim_Questionable.SelectedValue == "1")
            {
                objWC_FR.Claim_Questionable = true;
            }
            else
            {
                objWC_FR.Claim_Questionable = false;
            }
        }
        else
            objWC_FR.Claim_Questionable = null;

        objWC_FR.Claim_Questionable_Description = txtClaim_Questionable_Description.Text;
        objWC_FR.Date_Reported_To_Sonic = clsGeneral.FormatDateToStore(txtDate_Reported_To_Sonic);
        objWC_FR.person_reported_to = txtperson_reported_to.Text;
        objWC_FR.Witnesses = (rdoWitnesses.SelectedValue == "1") ? true : false;
        objWC_FR.Witness_1 = txtWitness_1.Text;
        objWC_FR.Witness_1_Phone = txtWitness_1_Phone.Text;
        objWC_FR.Witness_2 = txtWitness_2.Text;
        objWC_FR.Witness_2_Phone = txtWitness_2_Phone.Text;
        objWC_FR.Witness_3 = txtWitness_3.Text;
        objWC_FR.Witness_3_Phone = txtWitness_3_Phone.Text;
        objWC_FR.Fatality = (rdoFatality.SelectedValue == "1") ? true : false;

        //objWC_FR.Physician_Other_Professional = txtPhysician_Other_Professional.Text.Trim();
        //objWC_FR.Facility = txtFacility.Text.Trim();
        //objWC_FR.Facility_Address = txtFacility_Address.Text.Trim();
        //objWC_FR.Facility_City = txtFacility_City.Text.Trim();
        //objWC_FR.FK_State_Facility = (ddlFK_State_Facility.SelectedIndex > 0) ?  Convert.ToDecimal(ddlFK_State_Facility.SelectedValue) : 0;
        //objWC_FR.Facility_Zip_Code = txtFacility_Zip_Code.Text;
        objWC_FR.Emergency_Room = rblEmergency_Room.SelectedValue;
        objWC_FR.Time_Began_Work = txtTime_Began_Work.Text;
        objWC_FR.Activity_Before_Incident = txtActivity_Before_Incident.Text.Trim();
        objWC_FR.Object_Substance_Involved = txtObject_Substance_Involved.Text.Trim();

        // Update Values
        if (PK_WC_FR_ID > 0)
        {
            objWC_FR.Update();
        }
    }
    #endregion

    #region Medical Information Panel Events

    /// <summary>
    /// Used to Update Medical Information
    /// </summary>
    public void UpdateMedicalInformation()
    {
        // Declare Object
        WC_FR objWC_FR = new WC_FR(PK_WC_FR_ID);

        //Assign Values
        objWC_FR.Initial_Medical_Treatment = txtInitial_Medical_Treatment.Text;
        objWC_FR.Date_of_Initial_Medical_Treatment = clsGeneral.FormatDateToStore(txtDate_of_Initial_Medical_Treatment);
        objWC_FR.Taken_By_Emergency_Transportation = (rdoTaken_By_Emergency_Transportation.SelectedValue == "1") ? true : false;
        objWC_FR.Medical_Facility_Name = txtMedical_Facility_Name.Text;
        objWC_FR.Treating_Physician_Name = txtTreating_Physician_Name.Text;
        objWC_FR.Medical_Facility_Address1 = txtMedical_Facility_Address1.Text;
        objWC_FR.Medical_Facility_Address2 = txtMedical_Facility_Address2.Text;
        objWC_FR.Medical_Facility_City = txtMedical_Facility_City.Text;
        objWC_FR.Medical_Facility_State = (ddlMedical_Facility_State.SelectedIndex > 0) ? ddlMedical_Facility_State.SelectedValue.ToString() : "0";
        objWC_FR.Medical_Facility_Zip = txtMedical_Facility_Zip.Text;
        objWC_FR.Medical_Facility_Phone = txtMedical_Facility_Phone.Text;
        objWC_FR.Telephone_Nurse_Consultation = rdoTelephone_Nurse_Consultation.SelectedValue;
        objWC_FR.Supervisor_Involved_In_Consultation = rdoSupervisor_Involved_In_Consultation.SelectedValue;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoAdmitted_to_Hospital.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false
            if (rdoAdmitted_to_Hospital.SelectedValue == "Y")
            {
                objWC_FR.Admitted_to_Hospital = true;
            }
            else
            {
                objWC_FR.Admitted_to_Hospital = false;
            }
        }
        else
            objWC_FR.Admitted_to_Hospital = null;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoStill_In_Hospital.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false
            if (rdoStill_In_Hospital.SelectedValue == "Y")
            {
                objWC_FR.Still_In_Hospital = true;
            }
            else
            {
                objWC_FR.Still_In_Hospital = false;
            }
        }
        else
            objWC_FR.Still_In_Hospital = null;
        objWC_FR.Status_Out_Of_Work = rdoStatus_Out_Of_Work.Checked;
        objWC_FR.Status_Out_Of_Work_Date = clsGeneral.FormatDateToStore(txtStatus_Out_Of_Work_date);
        objWC_FR.Status_Return_To_Work_Unrestricted = rdoStatus_Return_To_Work_Unrestricted.Checked;
        objWC_FR.Status_Return_To_Work_Unrestricted_Date = clsGeneral.FormatDateToStore(txtStatus_Return_To_Work_Unrestricted_date);
        objWC_FR.Status_Return_Tp_Work_Restricted = rdoStatus_Return_Tp_Work_Restricted.Checked;
        objWC_FR.Status_Return_Tp_Work_Restricted_Date = clsGeneral.FormatDateToStore(txtStatus_Return_Tp_Work_Restricted_date);
        objWC_FR.Status_Unknown = rdoStatus_Unknown.Checked;
        objWC_FR.Next_Doctor_Visit = clsGeneral.FormatDateToStore(txtNext_Doctor_Visit);
        objWC_FR.Referring_Physician = (rdoReferring_Physician.SelectedValue == "Y") ? true : false;
        //check rdo button value. if it is "Y" than related fields are display else remains hidden
        if (rdoReferring_Physician.SelectedValue == "Y")
        {
            hdnMedicalPhysician.Value = "1";
            objWC_FR.Physician_Name = txtPhysician_Name.Text;
            objWC_FR.Physician_Address1 = txtPhysician_Address1.Text;
            objWC_FR.Physician_Address2 = txtPhysician_Address2.Text;
            objWC_FR.Physician_City = txtPhysician_City.Text;
            objWC_FR.Physician_State = (ddlPhysician_State.SelectedIndex > 0) ? ddlPhysician_State.SelectedValue.ToString() : "0";
            objWC_FR.Physician_Zip = txtPhysician_Zip.Text;
            objWC_FR.Physician_Phone = txtPhysician_Phone.Text;
        }
        else
        {
            hdnMedicalPhysician.Value = "0";
            objWC_FR.Physician_Name = "";
            objWC_FR.Physician_Address1 = "";
            objWC_FR.Physician_Address2 = "";
            objWC_FR.Physician_City = "";
            objWC_FR.Physician_State = "0";
            objWC_FR.Physician_Zip = "";
            objWC_FR.Physician_Phone = "";
        }

        //Update Values
        if (PK_WC_FR_ID > 0)
        {
            objWC_FR.Update();
        }
    }

    protected void rdoTelephone_Nurse_Consultation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoTelephone_Nurse_Consultation.SelectedValue == "Y")
        {
            rdoSupervisor_Involved_In_Consultation.Enabled = true;
        }
        else
        {
            rdoSupervisor_Involved_In_Consultation.Enabled = false;
            rdoSupervisor_Involved_In_Consultation.SelectedValue = "N";
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);

    }
    #endregion

    #region Contacts Information Panel Events
    //Used to Bind Contacts Information
    public void BindContactsInformation()
    {
        DataSet dsFRW = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.WC_FR, PK_WC_FR_ID);
        DataTable dtFRW = dsFRW.Tables[0];
        foreach (DataRow drFRW in dtFRW.Rows)
        {
            txtdba.Text = drFRW["dba"].ToString();
            txtContactDetailAddress_1.Text = drFRW["Address_1"].ToString();
            txtContactAddress2.Text = drFRW["Address_2"].ToString();
            txtContactDetailCity.Text = drFRW["City"].ToString();
            txtContactDetailState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state;
            txtContactDetailZipCode.Text = drFRW["Zip_Code"].ToString();
            txtContactDetailContactName.Text = drFRW["Last_Name"].ToString().Trim() + ", " + drFRW["First_Name"].ToString().Trim() + " " + drFRW["Middle_Name"].ToString().Trim();
            txtContactBestTime.Text = drFRW["Contact_Best_Time"].ToString();
            txtContactTelephone1.Text = (drFRW["TelephoneNumber1"] != null) ? Convert.ToString(drFRW["TelephoneNumber1"]) : "";
            txtContactTelephone2.Text = (drFRW["TelephoneNumber2"] != null) ? Convert.ToString(drFRW["TelephoneNumber2"]) : "";
            txtContactDetailFaxNumber.Text = drFRW["Contact_Fax"].ToString();
            txtContactDetailEmailAddress.Text = drFRW["FRWEmail"].ToString();
            //check Regional Loss Control ID. if it is not null than fill values to that ID 
            if (drFRW["FK_Regional_Loss_Control_ID"] != null)
            {
                Regional_Loss_Control objRLC = new Regional_Loss_Control(Convert.ToDecimal(drFRW["FK_Regional_Loss_Control_ID"]));
                txtContactRegionalManager.Text = objRLC.Manager.ToString();
                txtContactRLCMTelephone1.Text = objRLC.Telephone1.ToString();
                txtContactRLCMTelephone2.Text = objRLC.Telephone2.ToString();
                txtContactRLCMEmailAddress.Text = objRLC.Email.ToString();
            }
            //Disable Controls
            DisableEnableControlsforContact(false);
        }
    }
    /// <summary>
    /// Used to Disable or Enable a Controls
    /// </summary>
    /// <param name="value"></param>
    public void DisableEnableControlsforContact(bool value)
    {
        txtdba.Enabled = value;
        txtContactDetailAddress_1.Enabled = value;
        txtContactAddress2.Enabled = value;
        txtContactDetailCity.Enabled = value;
        txtContactDetailState.Enabled = value;
        txtContactDetailZipCode.Enabled = value;
        txtContactDetailContactName.Enabled = value;
        txtContactBestTime.Enabled = value;
        txtContactTelephone1.Enabled = value;
        txtContactTelephone2.Enabled = value;
        txtContactDetailFaxNumber.Enabled = value;
        txtContactDetailEmailAddress.Enabled = value;
        txtContactRegionalManager.Enabled = value;
        txtContactRLCMTelephone1.Enabled = value;
        txtContactRLCMTelephone2.Enabled = value;
        txtContactRLCMEmailAddress.Enabled = value;
    }
    #endregion

    #region Submit Button Event
    /// <summary>
    /// Used to Add,update record of WC_FR and Send Mail
    /// </summary>
    /// <returns></returns>
    public int ComplateWC_FRReport(bool _IsAttachment)
    {
        //used to check Page OPeration Mode
        if (strPageOpeMode == "edit")
        {
            if (hdnAssociate.Value == "1" && hdnIncident.Value == "1")
            {
                if (_IsAttachment)
                {
                    Upload_File(string.Empty);
                    decimal FileSize = this.CtrlAttachDetails.GetTotalAttachmentsFileSize();
                    if (FileSize > 9.5M)
                    {
                        String confirmMessage = "The attachments to this First Report exceed the size limitations for e-mail. The First Report can be sent without the attachments or you can Cancel and remove or reduce the size of the exiting attachments. Do you want to send the First Report without the attachments?";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", " if(window.confirm('" + confirmMessage + "')){ __doPostBack('UserConfirmationPostBack','true');} else {alert('The First Report has NOT been sent, please reduce the number and/or size of the attachments before attempting to resubmit with attachments.');ShowPanel(6);}", true);
                        return 0;
                    }
                }

                // Declare Object

                WC_FR objWC_FR = new WC_FR(PK_WC_FR_ID);
                //Assign Values
                objWC_FR.Comments = txtComments.Text;

                string strInitialClaim = string.Empty;
                foreach (ListItem li in lstInitialClaim.Items)
                {
                    if (li.Selected)
                        strInitialClaim += li.Value + ",";
                }
                strInitialClaim = strInitialClaim.TrimEnd(',');
                objWC_FR.Initial_Claim_Classification = strInitialClaim;
                objWC_FR.Date_Reported_to_SRS = DateTime.Now;

                if (objWC_FR.Complete)
                    return -1;

                objWC_FR.Complete = true;
                //Update Values
                if (PK_WC_FR_ID > 0)
                {
                    objWC_FR.Update();
                }

                if (objWC_FR.Filing_State != "36")
                    SendFROI();

                // if state of the location is not "Ohio" then only send the mail
                string State = new LU_Location(objWC_FR.FK_LU_Location).State;
                decimal decState = 0;

                // Check if state is not empty
                if (!string.IsNullOrEmpty(State))
                    decimal.TryParse(State, out decState);

                string strState = new State(Convert.ToDecimal(decState)).FLD_state;

                //if (strState.ToLower() != "Ohio".ToLower())
                //{
                if (SendFirstReportMail(_IsAttachment))
                {
                    return 1;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "alert('Report Submitted successfully but due to technical problem Mail can not be send at this time, Please try to resend.'); window.location='FirstReportSearch.aspx';", true);
                    return 0;
                }
                //}
                //clsGeneral.SendMailMessage(AppConfig.MailFrom, EmailTo, string.Empty, string.Empty, "Sonic Automotive reports the following First Report of Loss", HtmlBody, true, strAtt);
                //return 1;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "alert('Any of the Panel marked with an asterisk is not saved! Please save all panels marked with an asterisk.');", true);
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }
    #endregion

    #region General Methods
    /// <summary>
    /// Used to count the Age as per passed date.
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public string GetAge(DateTime dt)
    {
        if (dt != null)
        {
            DateTime dtToday = DateTime.Now;
            int intCurday = dtToday.Day;
            int intCurMon = dtToday.Month;
            int intCurYear = dtToday.Year;
            int intBday = dt.Day;
            int intBMon = dt.Month;
            int intBYear = dt.Year;
            int Age;
            //used to check Current date with birthdate.
            if ((intCurMon > intBMon) || (intCurMon == intBMon && intCurday >= intBday))
            {
                Age = intBYear;
            }
            else
            {
                Age = intBYear + 1;
            }
            return Convert.ToString(intCurYear - Age);
        }
        else
        {
            return String.Empty;
        }
    }

    /// <summary>
    /// Insert Investigation record.
    /// </summary>
    public void SaveInvestigation(Investigation objInv,int WC_FR_ID_For_Investigation)
    {
        WC_FR objWC_FR = new WC_FR(WC_FR_ID_For_Investigation);

        objInv.Physician_Other_Professional = objWC_FR.Treating_Physician_Name;
        objInv.Facility = objWC_FR.Medical_Facility_Name;
        objInv.Facility_Address = objWC_FR.Medical_Facility_Address1;
        objInv.Facility_City = objWC_FR.Medical_Facility_City;

        if (!string.IsNullOrEmpty(objWC_FR.Medical_Facility_State))
        {
            objInv.FK_State_Facility = clsGeneral.GetDecimal(objWC_FR.Medical_Facility_State);
        }

        objInv.Facility_Zip_Code = objWC_FR.Medical_Facility_Zip;
        objInv.Emergency_Room = objWC_FR.Emergency_Room;
        objInv.Time_Began_Work = objWC_FR.Time_Began_Work;
        objInv.Activity_Before_Incident = objWC_FR.Activity_Before_Incident;
        objInv.Object_Substance_Involved = objWC_FR.Object_Substance_Involved;
        objInv.Admitted_to_Hospital = objWC_FR.Admitted_to_Hospital;
    }

    #endregion

    #region Bind Page in View MOde
    /// <summary>
    /// Bind whole page in View Mode
    /// </summary>
    public void BindPageinViewMode()
    {
        if (First_Report_Wizard_ID > 0)
        {
            //Hide Message of "This Report Has not been submitted"
            lblSubmitMessage.Text = "";
            //Declare Object of WC_FR table
            WC_FR objWC_FR = new WC_FR(PK_WC_FR_ID);

            DataSet dsFRW = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.WC_FR, PK_WC_FR_ID);
            DataTable dtFRW = dsFRW.Tables[0];
            if (dtFRW.Rows.Count <= 0)
                Response.Redirect("FirstReportSearch.aspx");
            DataRow drFRW = dtFRW.Rows[0];
            #region Fill Location Information Controls
            //Display Location NUmber
            if (drFRW["sonic_location_code"] != null)
                lblLocationNumber.Text = drFRW["sonic_location_code"].ToString();
            else
                lblLocationNumber.Text = "";
            //Display dba Value
            if (drFRW["dba"] != null)
                lblLocationdba.Text = drFRW["dba"].ToString();
            else
                lblLocationdba.Text = "";
            //Display F/K/A value
            if (drFRW["FK_Location_ID"] != null)
                lblLocationfka.Text = new LU_Location_FKA(Convert.ToDecimal(drFRW["FK_Location_ID"])).fka;
            //Display Legal Entity Value
            //if (drFRW["legal_entity"] != null)
            //    lblLegalEntity.Text = drFRW["legal_entity"].ToString();
            //else
            //    lblLegalEntity.Text = "";

            //set address1,address2,city,state,ZipCOde Values
            lblLocationAddress1.Text = (drFRW["Address_1"] != null) ? Convert.ToString(drFRW["Address_1"]) : "";
            lblLocationAddress2.Text = (drFRW["Address_2"] != null) ? Convert.ToString(drFRW["Address_2"]) : "";
            lblLocationCity.Text = (drFRW["City"] != null) ? Convert.ToString(drFRW["City"]) : "";
            lblLocationState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state;
            lblLocationZipCode.Text = (drFRW["Zip_Code"] != null) ? Convert.ToString(drFRW["Zip_Code"]) : "";

            #endregion

            #region Fill Contact Information Controls [View Mode]

            Employee ObjEmp = new Employee(Convert.ToDecimal(drFRW["FK_Employee_ID"]));
            //select value of Contact Name 
            if (ObjEmp.PK_Employee_ID > 0)
                lblContactName.Text = ObjEmp.Last_Name.Trim() + ", " + ObjEmp.First_Name.Trim() + " " + (string.IsNullOrEmpty(ObjEmp.Middle_Name) ? "" : ObjEmp.Middle_Name).Trim();
            else
                lblContactName.Text = "";

            // set job Title,Telephone1,Telephone2,Fax Email Address
            lblContactTitle.Text = (drFRW["Job_Title"] != null) ? Convert.ToString(drFRW["Job_Title"]) : "";
            lblContactTelephoneNumber1.Text = (drFRW["TelephoneNumber1"] != null) ? Convert.ToString(drFRW["TelephoneNumber1"]) : "";
            lblContactTelephoneNumber2.Text = (drFRW["TelephoneNumber2"] != null) ? Convert.ToString(drFRW["TelephoneNumber2"]) : "";
            lblContactFaxNumber.Text = (drFRW["Contact_Fax"] != null) ? Convert.ToString(drFRW["Contact_Fax"]) : "";
            lblContactEmailAddress.Text = (drFRW["FRWEmail"] != null) ? Convert.ToString(drFRW["FRWEmail"]) : "";
            #endregion

            #region Fill Contacts Panel Information COntrols[View Mode]
            lbldba.Text = drFRW["dba"].ToString();
            lblContactDetailAddress_1.Text = drFRW["Address_1"].ToString();
            lblContactAddress2.Text = drFRW["Address_2"].ToString();
            lblContactDetailCity.Text = drFRW["City"].ToString();
            lblContactDetailState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state;
            lblContactDetailZipCode.Text = drFRW["Zip_Code"].ToString();
            lblContactDetailContactName.Text = drFRW["Last_Name"].ToString().Trim() + ", " + drFRW["First_Name"].ToString().Trim() + " " + drFRW["Middle_Name"].ToString().Trim();
            lblContactBestTime.Text = drFRW["Contact_Best_Time"].ToString();
            lblContactTelephone1.Text = drFRW["TelephoneNumber1"].ToString();
            lblContactTelephone2.Text = drFRW["TelephoneNumber2"].ToString();
            lblContactDetailFaxNumber.Text = drFRW["Contact_Fax"].ToString();
            lblContactDetailEmailAddress.Text = drFRW["FRWEmail"].ToString();

            if (drFRW["FK_Regional_Loss_Control_ID"] != null && drFRW["FK_Regional_Loss_Control_ID"].ToString() != string.Empty)
            {
                Regional_Loss_Control objRLC = new Regional_Loss_Control(Convert.ToDecimal(drFRW["FK_Regional_Loss_Control_ID"]));
                lblContactRegionalManager.Text = objRLC.Manager.ToString();
                lblContactRLCMTelephone1.Text = objRLC.Telephone1.ToString();
                lblContactRLCMTelephone2.Text = objRLC.Telephone2.ToString();
                lblContactRLCMEmailAddress.Text = objRLC.Email.ToString();
            }
            #endregion
            // Define Object
            Employee objEmployee = new Employee(objWC_FR.FK_Injured);
            ObjEmp = new Employee(Convert.ToDecimal(objEmployee.PK_Employee_ID));
            // Set Values to Controls
            if (objEmployee.PK_Employee_ID != -1)
                lblAssociateName.Text = Convert.ToString(ObjEmp.Last_Name).Trim() + ", " + Convert.ToString(ObjEmp.First_Name).Trim() + " " + Convert.ToString(string.IsNullOrEmpty(ObjEmp.Middle_Name) ? "" : ObjEmp.Middle_Name).Trim();
            else
                lblAssociateName.Text = "";
            lblDate_Of_Birth.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Date_Of_Birth);
            if (objEmployee.Date_Of_Birth != null)
            {
                if (Convert.ToDateTime(objEmployee.Date_Of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    lblCountdate_of_birth.Text = GetAge(Convert.ToDateTime(objEmployee.Date_Of_Birth));
            }
            lblGender.Text = Convert.ToString(objEmployee.Sex);
            lblAddress_1.Text = Convert.ToString(objEmployee.Employee_Address_1);

            if (!string.IsNullOrEmpty(objEmployee.Social_Security_Number))
                lblSocial_Security_Number.Text = clsGeneral.SupressString(objEmployee.Social_Security_Number.ToString(), objEmployee.Social_Security_Number.ToString().Length - 4);

            lblAddress_2.Text = Convert.ToString(objEmployee.Employee_Address_2);
            lblDate_of_Hire.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Hire_Date);
            lblCity.Text = Convert.ToString(objEmployee.Employee_City);
            lblJob_Title.Text = Convert.ToString(objEmployee.Job_Title);

            if (objEmployee.FK_Job_Classification != null)
                lblDescription.Text = new LU_Job_Classification(Convert.ToDecimal(objEmployee.FK_Job_Classification)).Description;

            if (objEmployee.Employee_State != null)
                lblState.Text = new State((decimal)objEmployee.Employee_State).FLD_state;

            lblZip_code.Text = Convert.ToString(objEmployee.Employee_Zip_Code);
            lblOccupation_description.Text = Convert.ToString(objEmployee.Occupation_Description);
            lblHome_Phone.Text = Convert.ToString(objEmployee.Employee_Home_Phone);
            lblCell_phone.Text = Convert.ToString(objEmployee.Employee_Cell_Phone);
            if (objEmployee.Salary != null)
                lblSalary.Text = clsGeneral.SupressString(objEmployee.Salary.ToString(), objEmployee.Salary.ToString().Length);
            else
                lblSalary.Text = "";
            lblSalary_Frequency.Text = Convert.ToString(objEmployee.Frequency);
            lblSupervisor_Name.Text = Convert.ToString(objEmployee.Supervisor);
            lblDriver_License_state.Text = Convert.ToString(objEmployee.Drivers_License_State);
            lblDriver_License_Number.Text = Convert.ToString(objEmployee.Drivers_License_Number);
            lblemail.Text = Convert.ToString(objEmployee.Email);
            if (objEmployee.PK_Employee_ID != -1)
                lblSonic_Employee_ID.Text = objEmployee.PK_Employee_ID.ToString();
            else
                lblSonic_Employee_ID.Text = "";
            if (objEmployee.Number_Of_Dependents != null)
                lblNumber_of_Dependents.Text = objEmployee.Number_Of_Dependents.ToString();
            else
                lblNumber_of_Dependents.Text = "";

            if (objEmployee.FK_Marital_Status != null)
                lblMarital_Status.Text = new Marital_Status(Convert.ToDecimal(objEmployee.FK_Marital_Status)).FLD_desc;

            lblActive_Inactive_Leave.Text = Convert.ToString(objEmployee.Active_Inactive_Leave);
            //Set Contols of Associate infomariton obtained from WC_FR table
            lblAlternate_Phone_2.Text = objWC_FR.Alternate_Phone_2;
            lblEmployee_Days_per_week.Text = objWC_FR.Employee_Days_per_week.ToString();
            lblEmployee_hrs_per_week.Text = objWC_FR.Employee_hrs_per_week.ToString();
            lblEmployee_Time_Shift_Begins.Text = objWC_FR.Employee_Time_Shift_Begins.ToString();
            lblEmployee_Time_Shift_Ends.Text = objWC_FR.Employee_Time_Shift_Ends.ToString();
            lblSupervisor_Telephone.Text = objWC_FR.Supervisor_Phone.ToString();
            lblMotor_Vehicle_Accident.Text = (objWC_FR.Motor_Vehicle_Accident == true) ? "Yes" : "No";
            lblState_of_hire.Text = new State(String.IsNullOrEmpty(objWC_FR.State_of_Hire) ? 0 : Convert.ToDecimal(objWC_FR.State_of_Hire)).FLD_state;

            //Incident Information
            // Set Values of Object for update
            lblDate_Of_Incident.Text = objWC_FR.Date_Of_Incident;
            lblTime_Of_Incident.Text = objWC_FR.Time_Of_Incident;
            lblFiling_State.Text = new State(string.IsNullOrEmpty(objWC_FR.Filing_State) ? 0 : Convert.ToDecimal(objWC_FR.Filing_State)).FLD_state;
            lblInjuryOccurredOffsite.Text = (objWC_FR.InjuryOccurredOffsite == true) ? "Offsite" : "Onsite";
            //check InjuryOccuedOffsite value. if it true than display related fields else remains hidden
            if (objWC_FR.InjuryOccurredOffsite == true)
            {
                trViewIncidentInjuryOccured.Style.Add("display", "block");
                lblOffsite_Address1.Text = objWC_FR.Offsite_Address1;
                lblOffsite_Address2.Text = objWC_FR.Offsite_Address2;
                lblOffsite_City.Text = objWC_FR.Offsite_City;
                lblOffsite_State.Text = new State(String.IsNullOrEmpty(objWC_FR.Offsite_State) ? 0 : Convert.ToDecimal(objWC_FR.Offsite_State)).FLD_state;
                lblOffsite_zip.Text = objWC_FR.Offsite_zip;
            }
            lblDescription_Of_Incident.Text = objWC_FR.Description_Of_Incident;
            //check object value if it null than display "unknown"
            if (objWC_FR.Associate_Injured_Regular_Job != null)
            {
                //check if object value is true than display "Yes" else display "No"
                if (objWC_FR.Associate_Injured_Regular_Job == true)
                    lblAssociate_Injured_Regular_Job.Text = "Yes";
                else
                    lblAssociate_Injured_Regular_Job.Text = "No";
            }
            else
                lblAssociate_Injured_Regular_Job.Text = "unknown";

            lblFK_Nature_Of_Injury.Text = new LU_Nature_of_Injury((objWC_FR.FK_Nature_Of_Injury != null) ? Convert.ToDecimal(objWC_FR.FK_Nature_Of_Injury) : 0).Description;
            lblFK_Department_Where_Occurred.Text = new LU_Department((objWC_FR.FK_Department_Where_Occurred != null) ? Convert.ToDecimal(objWC_FR.FK_Department_Where_Occurred) : 0).Description;
            lblFK_Body_Parts_Affected.Text = new LU_Part_Of_Body(string.IsNullOrEmpty(objWC_FR.FK_Body_Parts_Affected) ? 0 : Convert.ToDecimal(objWC_FR.FK_Body_Parts_Affected)).Description;
            lblTelephone_Nurse_Consultation.Text = objWC_FR.Telephone_Nurse_Consultation == "Y" ? "Yes" : "No";
            lblSupervisor_Involved_In_Consultation.Text = objWC_FR.Supervisor_Involved_In_Consultation == "Y" ? "Yes" : "No";
            //check object value if it null than display "unknown"
            if (objWC_FR.Safeguards_Provided != null)
            {
                //check if object value is true than display "Yes" else display "No"
                if (objWC_FR.Safeguards_Provided == true)
                    lblSafeguards_Provided.Text = "Yes";
                else
                    lblSafeguards_Provided.Text = "No";
            }
            else
                lblSafeguards_Provided.Text = "unknown";
            //check object value if it null than display "unknown"
            if (objWC_FR.Safeguards_Used != null)
            {
                //check if object value is true than display "Yes" else display "No"
                if (objWC_FR.Safeguards_Used == true)
                    lblSafeguards_Used.Text = "Yes";
                else
                    lblSafeguards_Used.Text = "No";
            }
            else
                lblSafeguards_Used.Text = "unknown";
            //check object value if it null than display "unknown"
            if (objWC_FR.Machine_Part_Involved != null)
            {
                //check if object value is true than display "Yes" else display "No"
                if (objWC_FR.Machine_Part_Involved == true)
                    lblMachine_Part_Involved.Text = "Yes";
                else
                    lblMachine_Part_Involved.Text = "No";
            }
            else
                lblMachine_Part_Involved.Text = "unknown";
            //check object value if it null than display "unknown"
            if (objWC_FR.Machine_Part_Defective != null)
            {
                //check if object value is true than display "Yes" else display "No"
                if (objWC_FR.Machine_Part_Defective == true)
                    lblMachine_Part_Defective.Text = "Yes";
                else
                    lblMachine_Part_Defective.Text = "No";
            }
            else
                lblMachine_Part_Defective.Text = "unknown";
            //check object value if it null than display "unknown"
            if (objWC_FR.Claim_Questionable != null)
            {
                //check if object value is true than display "Yes" else display "No"
                if (objWC_FR.Claim_Questionable == true)
                    lblClaim_Questionable.Text = "Yes";
                else
                    lblClaim_Questionable.Text = "No";
            }
            else
                lblClaim_Questionable.Text = "unknown";

            lblClaim_Questionable_Description.Text = objWC_FR.Claim_Questionable_Description;
            lblDate_Reported_To_Sonic.Text = clsGeneral.FormatDateToDisplay(objWC_FR.Date_Reported_To_Sonic);
            lblperson_reported_to.Text = objWC_FR.person_reported_to;
            lblWitnesses.Text = ((objWC_FR.Witnesses == true) ? "Yes" : "No");
            lblWitness_1.Text = objWC_FR.Witness_1;
            lblWitness_1_Phone.Text = objWC_FR.Witness_1_Phone;
            lblWitness_2.Text = objWC_FR.Witness_2;
            lblWitness_2_Phone.Text = objWC_FR.Witness_2_Phone;
            lblWitness_3.Text = objWC_FR.Witness_3;
            lblWitness_3_Phone.Text = objWC_FR.Witness_3_Phone;
            lblFatality.Text = (objWC_FR.Fatality == true) ? "Yes" : "No";

            //Medical Information
            lblInitial_Medical_Treatment.Text = objWC_FR.Initial_Medical_Treatment;
            lblDate_of_Initial_Medical_Treatment.Text = clsGeneral.FormatDateToDisplay(objWC_FR.Date_of_Initial_Medical_Treatment);
            lblTaken_By_Emergency_Transportation.Text = (objWC_FR.Taken_By_Emergency_Transportation == true) ? "Yes" : "No";
            lblMedical_Facility_Name.Text = objWC_FR.Medical_Facility_Name;
            lblTreating_Physician_Name.Text = objWC_FR.Treating_Physician_Name;
            lblMedical_Facility_Address1.Text = objWC_FR.Medical_Facility_Address1;
            lblMedical_Facility_Address2.Text = objWC_FR.Medical_Facility_Address2;
            lblMedical_Facility_City.Text = objWC_FR.Medical_Facility_City;
            lblMedical_Facility_State.Text = new State(String.IsNullOrEmpty(objWC_FR.Medical_Facility_State) ? 0 : Convert.ToDecimal(objWC_FR.Medical_Facility_State)).FLD_state;
            lblMedical_Facility_Zip.Text = objWC_FR.Medical_Facility_Zip;
            lblMedical_Facility_Phone.Text = objWC_FR.Medical_Facility_Phone;
            //check object value if it null than display "unknown"
            if (objWC_FR.Admitted_to_Hospital != null)
            {
                //check if object value is true than display "Yes" else display "No"
                if (objWC_FR.Admitted_to_Hospital == true)
                    lblAdmitted_to_Hospital.Text = "Yes";
                else
                    lblAdmitted_to_Hospital.Text = "No";
            }
            else
                lblAdmitted_to_Hospital.Text = "unknown";
            //check object value if it null than display "unknown"
            if (objWC_FR.Still_In_Hospital != null)
            {
                //check if object value is true than display "Yes" else display "No"
                if (objWC_FR.Still_In_Hospital == true)
                    lblStill_In_Hospital.Text = "Yes";
                else
                    lblStill_In_Hospital.Text = "No";
            }
            else
                lblStill_In_Hospital.Text = "unknown";

            lblStatus_Out_Of_Work.Text = (objWC_FR.Status_Out_Of_Work == true) ? "Yes" : "No";
            lblStatus_Out_Of_Work_date.Text = clsGeneral.FormatDateToDisplay(objWC_FR.Status_Out_Of_Work_Date);
            lblStatus_Return_To_Work_Unrestricted.Text = (objWC_FR.Status_Return_To_Work_Unrestricted == true) ? "Yes" : "No";
            lblStatus_Return_To_Work_Unrestricted_date.Text = clsGeneral.FormatDateToDisplay(objWC_FR.Status_Return_To_Work_Unrestricted_Date);
            lblStatus_Return_Tp_Work_Restricted.Text = (objWC_FR.Status_Return_Tp_Work_Restricted == true) ? "Yes" : "No";
            lblStatus_Return_Tp_Work_Restricted_date.Text = clsGeneral.FormatDateToDisplay(objWC_FR.Status_Return_Tp_Work_Restricted_Date); ;
            lblStatus_Unknown.Text = (objWC_FR.Status_Unknown == true) ? "Yes" : "No";
            lblNext_Doctor_Visit.Text = clsGeneral.FormatDateToDisplay(objWC_FR.Next_Doctor_Visit);
            lblReferring_Physician.Text = (objWC_FR.Referring_Physician == true) ? "Yes" : "No";
            //check Reffering Physican value if it is true than displayed related fields else fields are remain Hidden
            if (objWC_FR.Referring_Physician == true)
            {
                tdViewReferringPhysican.Style.Add("display", "block");
                lblPhysician_Name.Text = objWC_FR.Physician_Name;
                lblPhysician_Address1.Text = objWC_FR.Physician_Address1;
                lblPhysician_Address2.Text = objWC_FR.Physician_Address2;
                lblPhysician_City.Text = objWC_FR.Physician_City;
                lblPhysician_State.Text = new State(String.IsNullOrEmpty(objWC_FR.Physician_State) ? 0 : Convert.ToDecimal(objWC_FR.Physician_State)).FLD_state;
                lblPhysician_Zip.Text = objWC_FR.Physician_Zip;
                lblPhysician_Phone.Text = objWC_FR.Physician_Phone;
            }

            //lblPhysician_Other_Professional.Text = objWC_FR.Physician_Other_Professional;
            //lblFacility.Text = objWC_FR.Facility;
            //lblFacility_Address.Text = objWC_FR.Facility_Address;
            //lblFacility_City.Text = objWC_FR.Facility_City;

            //if (objWC_FR.FK_State_Facility > 0)
            //{
            //    lblFK_State_Facility.Text = new State(String.IsNullOrEmpty(Convert.ToString(objWC_FR.FK_State_Facility)) ? 0 : Convert.ToDecimal(objWC_FR.FK_State_Facility)).FLD_state;
            //}

            //lblFacility_Zip_Code.Text = objWC_FR.Facility_Zip_Code;
            lblEmergency_Room.Text = (objWC_FR.Emergency_Room == "Y") ? "Yes" : "No";
            lblTime_Began_Work.Text = objWC_FR.Time_Began_Work;
            lblActivity_Before_Incident.Text = objWC_FR.Activity_Before_Incident;
            lblObject_Substance_Involved.Text = objWC_FR.Object_Substance_Involved;

            //Comments and Attachments
            lblComments.Text = objWC_FR.Comments;

            //Set Initial Claim Classification
            string strInitialClaim = string.Empty;
            string[] strSelectedClaim = objWC_FR.Initial_Claim_Classification.Split(',');
            ListItem[] liClaim = WC_FR.InitialClaimClassificationList();

            if (strSelectedClaim.Length > 0)
            {
                for (int i = 0; i < strSelectedClaim.Length; i++)
                {
                    foreach (ListItem li in liClaim)
                    {

                        if (li.Value == strSelectedClaim[i])
                        {
                            if (i == strSelectedClaim.Length - 0)
                                strInitialClaim += li.Text;
                            else
                                strInitialClaim += li.Text + "<br/>";
                        }

                    }
                }
            }

            strInitialClaim = strInitialClaim.TrimEnd(',');
            lblInitial_Claim_Classification.Text = strInitialClaim;


            lblDate_Reported_to_SRS.Text = clsGeneral.FormatDateToDisplay(objWC_FR.Date_Reported_to_SRS);
            CtrlAttachmentDetailsView.InitializeAttachmentDetails(clsGeneral.Tables.WC_FR, PK_WC_FR_ID, false, 6);
            CtrlAttachmentDetailsView.Bind();
        }
        else
        {
            Response.Redirect("FirstReportSearch.aspx", true);
        }
    }
    #endregion

    #region Bind Page in Edit Mode
    /// <summary>
    /// Used to Bind page in Edit MOde
    /// </summary>
    public void BindPageinEditMode()
    {

        if (First_Report_Wizard_ID > 0)
        {
            //Declare Object of WC_FR table
            WC_FR objWC_FR = new WC_FR(PK_WC_FR_ID);
            //used to check report is complete or not. if not than Message is display else not display
            if (objWC_FR.Complete == false)
            {
                //Hide Message of "This Report Has not been submitted"
                lblSubmitMessage.Text = "This Report has not been submitted";
            }
            else
            {
                lblSubmitMessage.Text = "";
            }
            DataSet dsFRW = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.WC_FR, PK_WC_FR_ID);
            DataTable dtFRW = dsFRW.Tables[0];
            if (dtFRW.Rows.Count <= 0)
                Response.Redirect("FirstReportSearch.aspx");

            DataRow drFRW = dtFRW.Rows[0];
            #region Fill Location/Contact Information Controls
            #region Fill Location Information Controls
            //select value from Location Number Dropdown
            txtLocationNumberEdit.Text = Convert.ToString(drFRW["sonic_location_code"]);
            if (drFRW["ADP_DMS"] != null)
            {
                //ListItem lst = new ListItem();
                //lst = ddlLocationNumber.Items.FindByText(drFRW["RM_Location_Number"].ToString());
                //if (lst != null)
                //{
                //    lst.Selected = true;
                //}
                //fill Associate Information Dropdown
                //string[] strCostCenter = drFRW["RM_Location_Number"].ToString().Split(Convert.ToChar("."));
                //ComboHelper.FillAssociateByContact(new DropDownList[] { ddlAssociateName }, true, Convert.ToInt32(strCostCenter[strCostCenter.Length - 1].ToString()));

                string strSonicLocationCode = Convert.ToString(drFRW["Sonic_Location_Code"]);
                ComboHelper.FillAssociateByContact(new DropDownList[] { ddlAssociateName }, true, Convert.ToInt32(strSonicLocationCode));

                //ComboHelper.FillAssociateByContact(new DropDownList[] { ddlAssociateName }, true, (ddlLocationNumber.SelectedIndex > 0) ? Convert.ToInt32(ddlLocationNumber.SelectedValue) : 0);
            }
            //select value from Location d/b/a Dropdown
            txtLocationdbaEdit.Text = drFRW["dba"].ToString();
            txtLocationfkaEdit.Text = new LU_Location_FKA((drFRW["FK_Location_ID"] != null) ? Convert.ToInt32(drFRW["FK_Location_ID"]) : 0, true).fka;
            //select value from Location Legal Entity Dropdown
            //txtLegalEntityEdit.Text = drFRW["legal_entity"].ToString();

            //set address1,address2,city,state,ZipCOde Values
            txtLocationAddress1.Text = (drFRW["Address_1"] != null) ? Convert.ToString(drFRW["Address_1"]) : "";
            txtLocationAddress2.Text = (drFRW["Address_2"] != null) ? Convert.ToString(drFRW["Address_2"]) : "";
            txtLocationCity.Text = (drFRW["City"] != null) ? Convert.ToString(drFRW["City"]) : "";
            txtLocationState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state;
            txtLocationZipCode.Text = (drFRW["Zip_Code"] != null) ? Convert.ToString(drFRW["Zip_Code"]) : "";

            #endregion

            #region Fill Contact Information Controls
            //select value from Contact Name Dropdown
            Employee ObjEmp = new Employee(Convert.ToDecimal(drFRW["FK_Employee_ID"].ToString()));
            if (ObjEmp.PK_Employee_ID > 0)
                txtContactNameEdit.Text = ObjEmp.Last_Name.Trim() + ", " + ObjEmp.First_Name.Trim() + " " + (string.IsNullOrEmpty(ObjEmp.Middle_Name) ? "" : ObjEmp.Middle_Name).Trim();
            // set job Title,Telephone1,Telephone2,Fax Email Address
            txtContactTitle.Text = (drFRW["Job_Title"] != null) ? Convert.ToString(drFRW["Job_Title"]) : "";
            txtContactTelephoneNumber1.Text = (drFRW["TelephoneNumber1"] != null) ? Convert.ToString(drFRW["TelephoneNumber1"]) : "";
            txtContactTelephoneNumber2.Text = (drFRW["TelephoneNumber2"] != null) ? Convert.ToString(drFRW["TelephoneNumber2"]) : "";
            txtContactFaxNumber.Text = (drFRW["Contact_Fax"] != null) ? Convert.ToString(drFRW["Contact_Fax"]) : "";
            txtContactEmailAddress.Text = (drFRW["FRWEmail"] != null) ? Convert.ToString(drFRW["FRWEmail"]) : "";
            #endregion

            #endregion

            #region Fill Contacts Panel Information COntrols[View Mode]
            txtdba.Text = drFRW["dba"].ToString();
            txtContactDetailAddress_1.Text = drFRW["Address_1"].ToString();
            txtContactAddress2.Text = drFRW["Address_2"].ToString();
            txtContactDetailCity.Text = drFRW["City"].ToString();
            txtContactDetailState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state;
            txtContactDetailZipCode.Text = drFRW["Zip_Code"].ToString();
            txtContactDetailContactName.Text = drFRW["Last_Name"].ToString().Trim() + ", " + drFRW["First_Name"].ToString().Trim() + " " + drFRW["Middle_Name"].ToString().Trim();
            txtContactBestTime.Text = drFRW["Contact_Best_Time"].ToString();
            //txtContactTelephone1.Text = drFRW["Work_Phone"].ToString();
            //txtContactTelephone2.Text = drFRW["Employee_Cell_Phone"].ToString();
            txtContactTelephone1.Text = (drFRW["TelephoneNumber1"] != null) ? Convert.ToString(drFRW["TelephoneNumber1"]) : "";
            txtContactTelephone2.Text = (drFRW["TelephoneNumber2"] != null) ? Convert.ToString(drFRW["TelephoneNumber2"]) : "";
            txtContactDetailFaxNumber.Text = drFRW["Contact_Fax"].ToString();
            //txtContactDetailEmailAddress.Text = drFRW["Email"].ToString();
            txtContactDetailEmailAddress.Text = drFRW["FRWEmail"].ToString();
            //check Regional loss control value if it not null than select values to that id and set to related controls
            if (drFRW["FK_Regional_Loss_Control_ID"] != null && drFRW["FK_Regional_Loss_Control_ID"].ToString() != string.Empty)
            {
                Regional_Loss_Control objRLC = new Regional_Loss_Control(Convert.ToDecimal(drFRW["FK_Regional_Loss_Control_ID"]));
                txtContactRegionalManager.Text = objRLC.Manager.ToString();
                txtContactRLCMTelephone1.Text = objRLC.Telephone1.ToString();
                txtContactRLCMTelephone2.Text = objRLC.Telephone2.ToString();
                txtContactRLCMEmailAddress.Text = objRLC.Email.ToString();
            }
            //Disable Controls
            DisableEnableControlsforContact(false);
            #endregion

            // Define Object
            Employee objEmployee = new Employee((objWC_FR.FK_Injured));
            ListItem lstEID = new ListItem();
            lstEID = ddlAssociateName.Items.FindByValue(objEmployee.PK_Employee_ID.ToString());
            //check null value for Listitem
            if (lstEID != null)
                lstEID.Selected = true;
            //used to check validation.if no associated name is selected than validation fire else nothing
            if (ddlAssociateName.SelectedIndex > 0)
            {
                hdnAssociate.Value = "1";
            }
            else
            {
                hdnAssociate.Value = "0";
            }
            txtDate_Of_Birth.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Date_Of_Birth);
            //check null value for object. if it is not null than count age.
            if (objEmployee.Date_Of_Birth != null)
            {
                if (Convert.ToDateTime(objEmployee.Date_Of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    txtCountdate_of_birth.Text = GetAge((DateTime)objEmployee.Date_Of_Birth);
            }

            txtGender.Text = Convert.ToString(objEmployee.Sex);
            txtAddress_1.Text = Convert.ToString(objEmployee.Employee_Address_1);
            if (!string.IsNullOrEmpty(objEmployee.Social_Security_Number))
                txtSocial_Security_Number.Text = clsGeneral.SupressString(objEmployee.Social_Security_Number.ToString(), objEmployee.Social_Security_Number.ToString().Length - 4);
            else
                txtSocial_Security_Number.Text = "";

            txtAddress_2.Text = Convert.ToString(objEmployee.Employee_Address_2);
            txtDate_of_Hire.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Hire_Date);
            txtCity.Text = Convert.ToString(objEmployee.Employee_City);
            txtJob_Title.Text = Convert.ToString(objEmployee.Job_Title);

            if (objEmployee.FK_Job_Classification != null)
                txtDescription.Text = new LU_Job_Classification(Convert.ToDecimal(objEmployee.FK_Job_Classification)).Description;

            if (objEmployee.Employee_State != null)
                txtStateEdit.Text = new State((decimal)objEmployee.Employee_State).FLD_state;

            txtZip_code.Text = Convert.ToString(objEmployee.Employee_Zip_Code);
            txtOccupation_description.Text = Convert.ToString(objEmployee.Occupation_Description);
            txtHome_Phone.Text = Convert.ToString(objEmployee.Employee_Home_Phone);
            txtCell_phone.Text = Convert.ToString(objEmployee.Employee_Cell_Phone);
            //check if salary is -1 than display blank
            if (objEmployee.Salary != null)
                txtSalary.Text = clsGeneral.SupressString(objEmployee.Salary.ToString(), objEmployee.Salary.ToString().Length);
            else
                txtSalary.Text = "";
            txtSalary_Frequency.Text = Convert.ToString(objEmployee.Frequency);
            txtSupervisor_Name.Text = Convert.ToString(objEmployee.Supervisor);
            //check null value for object.
            txtDriver_License_stateEdit.Text = Convert.ToString(objEmployee.Drivers_License_State);
            txtDriver_License_Number.Text = Convert.ToString(objEmployee.Drivers_License_Number);
            txtemail.Text = Convert.ToString(objEmployee.Email);
            //check if Employee Associate ID is -1 than display blank
            if (objEmployee.PK_Employee_ID != -1)
                txtSonic_Employee_ID.Text = objEmployee.PK_Employee_ID.ToString();
            else
                txtSonic_Employee_ID.Text = "";
            //check if No of Department is -1 than display blank
            if (objEmployee.Number_Of_Dependents != null)
                txtNumber_of_Dependents.Text = objEmployee.Number_Of_Dependents.ToString();
            else
                txtNumber_of_Dependents.Text = "";
            if (objEmployee.FK_Marital_Status != null)
                txtMarital_StatusEdit.Text = new Marital_Status(objEmployee.FK_Marital_Status.ToString() != string.Empty ? Convert.ToDecimal(objEmployee.FK_Marital_Status.ToString()) : 0).FLD_desc;
            txtAlternate_Phone_2.Text = objWC_FR.Alternate_Phone_2;
            txtEmployee_Days_per_week.Text = objWC_FR.Employee_Days_per_week.ToString();
            txtEmployee_hrs_per_week.Text = objWC_FR.Employee_hrs_per_week.ToString();
            txtEmployee_Time_Shift_Begins.Text = objWC_FR.Employee_Time_Shift_Begins.ToString();
            txtEmployee_Time_Shift_Ends.Text = objWC_FR.Employee_Time_Shift_Ends.ToString();
            txtSupervisor_Telephone.Text = objWC_FR.Supervisor_Phone;
            rdoMotor_Vehicle_Accident.SelectedValue = (objWC_FR.Motor_Vehicle_Accident == true) ? "Y" : "N";
            //check null value for object
            if (objWC_FR.State_of_Hire != null)
            {
                ListItem lstStateHire = new ListItem();
                lstStateHire = ddlState_of_hire.Items.FindByValue(objWC_FR.State_of_Hire);
                //check null value for listitem. if it is not true than select listitem
                if (lstStateHire != null)
                    lstStateHire.Selected = true;
            }

            //Disabling Controls
            ddlAssociateName.Enabled = true;
            DisableAssociateControls(false);
            //Incident Information
            // Set Values of Object for update
            txtDate_Of_Incident.Text = objWC_FR.Date_Of_Incident;
            //used to check validation.if date of Incident is not null or Empty than no validation is fired to select Incident
            //date else validation is fired to select Date of INcident.
            if (!string.IsNullOrEmpty(objWC_FR.Date_Of_Incident))
            {
                hdnIncident.Value = "1";
            }
            else
            {
                hdnIncident.Value = "0";
            }
            txtTime_Of_Incident.Text = objWC_FR.Time_Of_Incident;
            //check null value for object
            if (objWC_FR.Filing_State != null)
            {
                ListItem lstFillState = new ListItem();
                lstFillState = ddlFiling_State.Items.FindByValue(objWC_FR.Filing_State);
                //check null value for listitem. if it is not true than select listitem
                if (lstFillState != null)
                    lstFillState.Selected = true;
            }
            //check InjuryOccuredOffsute value if it true than select "y" else "N".
            if (objWC_FR.InjuryOccurredOffsite == true)
                rdoInjuryOccurredOffsite.SelectedValue = "Y";
            else
                rdoInjuryOccurredOffsite.SelectedValue = "N";
            //check InjuryOccuredOffsite value. if it is true than display related fielda else that fields are remain hidden.
            if (objWC_FR.InjuryOccurredOffsite == true)
            {
                hdnOnsiteOffsite.Value = "1";
                trIncidentInjuryOccured.Style.Add("display", "");
                txtOffsite_Address1.Text = objWC_FR.Offsite_Address1;
                txtOffsite_Address2.Text = objWC_FR.Offsite_Address2;
                txtOffsite_City.Text = objWC_FR.Offsite_City;
                //check null for object
                if (objWC_FR.Offsite_State != null)
                {
                    ListItem lstOffsiteState = new ListItem();
                    lstOffsiteState = ddlOffsite_State.Items.FindByValue(objWC_FR.Offsite_State);
                    //check null value for listitem. if it is not true than select listitem
                    if (lstOffsiteState != null)
                        lstOffsiteState.Selected = true;
                }
                txtOffsite_zip.Text = objWC_FR.Offsite_zip;
            }
            rdoTelephone_Nurse_Consultation.SelectedValue = objWC_FR.Telephone_Nurse_Consultation;
            if (!string.IsNullOrEmpty(objWC_FR.Telephone_Nurse_Consultation))
            {
                if (objWC_FR.Telephone_Nurse_Consultation == "N")
                {
                    rdoSupervisor_Involved_In_Consultation.Enabled = false;
                    rdoSupervisor_Involved_In_Consultation.SelectedValue = "N";
                }
                else
                    rdoSupervisor_Involved_In_Consultation.SelectedValue = objWC_FR.Supervisor_Involved_In_Consultation;
            }
            else
            {
                rdoSupervisor_Involved_In_Consultation.Enabled = false;
                rdoSupervisor_Involved_In_Consultation.SelectedValue = "N";
            }

            txtDescription_Of_Incident.Text = objWC_FR.Description_Of_Incident;
            //used to check if the value is null than set values to radio button is "-1"and 
            //if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
            if (objWC_FR.Associate_Injured_Regular_Job != null)
            {
                if (objWC_FR.Associate_Injured_Regular_Job == true)
                    rdoAssociate_Injured_Regular_Job.SelectedValue = "Y";
                else
                    rdoAssociate_Injured_Regular_Job.SelectedValue = "N";
            }
            else
                rdoAssociate_Injured_Regular_Job.SelectedValue = "-1";
            ListItem lstNatureofInjury = new ListItem();
            lstNatureofInjury = ddlFK_Nature_Of_Injury.Items.FindByValue(objWC_FR.FK_Nature_Of_Injury.ToString());
            //check null value for listitem. if it is not true than select listitem
            if (lstNatureofInjury != null)
                lstNatureofInjury.Selected = true;
            ListItem lstDepartment = new ListItem();
            lstDepartment = ddlFK_Department_Where_Occurred.Items.FindByValue(objWC_FR.FK_Department_Where_Occurred.ToString());
            //check null value for listitem. if it is not true than select listitem
            if (lstDepartment != null)
                lstDepartment.Selected = true;
            //check null for object value
            if (!string.IsNullOrEmpty(objWC_FR.FK_Body_Parts_Affected))
            {
                ListItem lstBodyPart = new ListItem();
                lstBodyPart = ddlFK_Body_Parts_Affected.Items.FindByValue(objWC_FR.FK_Body_Parts_Affected.ToString());
                //check null value for listitem. if it is not true than select listitem
                if (lstBodyPart != null)
                    lstBodyPart.Selected = true;
            }
            //used to check if the value is null than set values to radio button is "-1"and 
            //if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
            if (objWC_FR.Safeguards_Provided != null)
            {
                if (objWC_FR.Safeguards_Provided == true)
                    rdoSafeguards_Provided.SelectedValue = "Y";
                else
                    rdoSafeguards_Provided.SelectedValue = "N";
            }
            else
                rdoSafeguards_Provided.SelectedValue = "-1";
            //used to check if the value is null than set values to radio button is "-1"and 
            //if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
            if (objWC_FR.Safeguards_Used != null)
            {
                if (objWC_FR.Safeguards_Used == true)
                    rdoSafeguards_Used.SelectedValue = "Y";
                else
                    rdoSafeguards_Used.SelectedValue = "N";
            }
            else
                rdoSafeguards_Used.SelectedValue = "-1";
            //used to check if the value is null than set values to radio button is "-1"and 
            //if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
            if (objWC_FR.Machine_Part_Involved != null)
            {
                if (objWC_FR.Machine_Part_Involved == true)
                    rdoMachine_Part_Involved.SelectedValue = "Y";
                else
                    rdoMachine_Part_Involved.SelectedValue = "N";
            }
            else
                rdoMachine_Part_Involved.SelectedValue = "-1";
            //used to check if the value is null than set values to radio button is "-1"and 
            //if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
            if (objWC_FR.Machine_Part_Defective != null)
            {
                if (objWC_FR.Machine_Part_Defective == true)
                    rdoMachine_Part_Defective.SelectedValue = "Y";
                else
                    rdoMachine_Part_Defective.SelectedValue = "N";
            }
            else
                rdoMachine_Part_Defective.SelectedValue = "-1";
            //used to check if the value is null than set values to radio button is "-1"and 
            //if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
            if (objWC_FR.Claim_Questionable != null)
            {
                if (objWC_FR.Claim_Questionable == true)
                    rdoClaim_Questionable.SelectedValue = "1";
                else
                    rdoClaim_Questionable.SelectedValue = "0";
            }
            else
                rdoClaim_Questionable.SelectedValue = "-1";

            txtClaim_Questionable_Description.Text = objWC_FR.Claim_Questionable_Description;
            txtDate_Reported_To_Sonic.Text = clsGeneral.FormatDateToDisplay(objWC_FR.Date_Reported_To_Sonic);
            txtperson_reported_to.Text = objWC_FR.person_reported_to;
            //check object value.if it is true than select radio button value to "Y" else  "N"
            if (objWC_FR.Witnesses == true)
                rdoWitnesses.SelectedValue = "1";
            else
                rdoWitnesses.SelectedValue = "0";

            txtWitness_1.Text = objWC_FR.Witness_1;
            txtWitness_1_Phone.Text = objWC_FR.Witness_1_Phone;
            txtWitness_2.Text = objWC_FR.Witness_2;
            txtWitness_2_Phone.Text = objWC_FR.Witness_2_Phone;
            txtWitness_3.Text = objWC_FR.Witness_3;
            txtWitness_3_Phone.Text = objWC_FR.Witness_3_Phone;
            //check null for object value. if it is true than set radion button value to "Y" else "N"
            if (objWC_FR.Fatality == true)
                rdoFatality.SelectedValue = "1";
            else
                rdoFatality.SelectedValue = "0";

            //Medical Information
            txtInitial_Medical_Treatment.Text = objWC_FR.Initial_Medical_Treatment;
            txtDate_of_Initial_Medical_Treatment.Text = clsGeneral.FormatDateToDisplay(objWC_FR.Date_of_Initial_Medical_Treatment);
            //check null value for object.if it is true than set radio button value to "Y" else "N"
            if (objWC_FR.Taken_By_Emergency_Transportation == true)
                rdoTaken_By_Emergency_Transportation.SelectedValue = "1";
            else
                rdoTaken_By_Emergency_Transportation.SelectedValue = "0";
            txtMedical_Facility_Name.Text = objWC_FR.Medical_Facility_Name;
            txtTreating_Physician_Name.Text = objWC_FR.Treating_Physician_Name;
            txtMedical_Facility_Address1.Text = objWC_FR.Medical_Facility_Address1;
            txtMedical_Facility_Address2.Text = objWC_FR.Medical_Facility_Address2;
            txtMedical_Facility_City.Text = objWC_FR.Medical_Facility_City;
            //check null for object value.
            if (objWC_FR.Medical_Facility_State != null)
            {
                ListItem lstMState = new ListItem();
                lstMState = ddlMedical_Facility_State.Items.FindByValue(objWC_FR.Medical_Facility_State.ToString());
                //check null value for LIstitem. if ListItem is not null than selected = true
                if (lstMState != null)
                    lstMState.Selected = true;
            }
            txtMedical_Facility_Zip.Text = objWC_FR.Medical_Facility_Zip;
            txtMedical_Facility_Phone.Text = objWC_FR.Medical_Facility_Phone;
            //used to check if the value is null than set values to radio button is "-1"and 
            //if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
            if (objWC_FR.Admitted_to_Hospital != null)
            {
                if (objWC_FR.Admitted_to_Hospital == true)
                    rdoAdmitted_to_Hospital.SelectedValue = "Y";
                else
                    rdoAdmitted_to_Hospital.SelectedValue = "N";
            }
            else
                rdoAdmitted_to_Hospital.SelectedValue = "-1";
            //used to check if the value is null than set values to radio button is "-1"and 
            //if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
            if (objWC_FR.Still_In_Hospital != null)
            {
                if (objWC_FR.Still_In_Hospital == true)
                    rdoStill_In_Hospital.SelectedValue = "Y";
                else
                    rdoStill_In_Hospital.SelectedValue = "N";
            }
            else
                rdoStill_In_Hospital.SelectedValue = "-1";

            rdoStatus_Out_Of_Work.Checked = objWC_FR.Status_Out_Of_Work;
            //check null value to object. if it is true than display relatd panel
            if (objWC_FR.Status_Out_Of_Work == true)
            {
                pnlOutOFWord.Visible = true;
            }
            txtStatus_Out_Of_Work_date.Text = clsGeneral.FormatDateToDisplay(objWC_FR.Status_Out_Of_Work_Date);
            rdoStatus_Return_To_Work_Unrestricted.Checked = objWC_FR.Status_Return_To_Work_Unrestricted;
            //check null value to object. if it is true than display relatd panel
            if (objWC_FR.Status_Return_To_Work_Unrestricted == true)
            {
                pnlUnrestricted.Visible = true;
            }
            txtStatus_Return_To_Work_Unrestricted_date.Text = clsGeneral.FormatDateToDisplay(objWC_FR.Status_Return_To_Work_Unrestricted_Date);
            rdoStatus_Return_Tp_Work_Restricted.Checked = objWC_FR.Status_Return_Tp_Work_Restricted;
            //check null value to object. if it is true than display relatd panel
            if (objWC_FR.Status_Return_Tp_Work_Restricted == true)
            {
                pnlrestricted.Visible = true;
            }
            txtStatus_Return_Tp_Work_Restricted_date.Text = clsGeneral.FormatDateToDisplay(objWC_FR.Status_Return_Tp_Work_Restricted_Date); ;
            rdoStatus_Unknown.Checked = objWC_FR.Status_Unknown;
            txtNext_Doctor_Visit.Text = clsGeneral.FormatDateToDisplay(objWC_FR.Next_Doctor_Visit);
            //Check object value. if it is true than select "Y" to radio button else "N"
            if (objWC_FR.Referring_Physician == true)
            {
                rdoReferring_Physician.SelectedValue = "Y";
            }
            else
            {
                rdoReferring_Physician.SelectedValue = "N";
            }
            //check object value. if it true than display related fields else fields are remain hidden
            if (objWC_FR.Referring_Physician == true)
            {
                tdReferringPhysican.Style.Add("display", "block");
                txtPhysician_Name.Text = objWC_FR.Physician_Name;
                txtPhysician_Address1.Text = objWC_FR.Physician_Address1;
                txtPhysician_Address2.Text = objWC_FR.Physician_Address2;
                txtPhysician_City.Text = objWC_FR.Physician_City;
                if (objWC_FR.Physician_State != null)
                {
                    ListItem lstPState = new ListItem();
                    lstPState = ddlPhysician_State.Items.FindByValue(objWC_FR.Physician_State.ToString());
                    if (lstPState != null)
                        lstPState.Selected = true;
                }
                txtPhysician_Zip.Text = objWC_FR.Physician_Zip;
                txtPhysician_Phone.Text = objWC_FR.Physician_Phone;
            }

            //txtPhysician_Other_Professional.Text = objWC_FR.Physician_Other_Professional;
            //txtFacility.Text = objWC_FR.Facility;
            //txtFacility_Address.Text = objWC_FR.Facility_Address;
            //txtFacility_City.Text = objWC_FR.Facility_City;

            //if (objWC_FR.FK_State_Facility > 0)
            //{
            //    ddlFK_State_Facility.SelectedValue = Convert.ToString(objWC_FR.FK_State_Facility);
            //}
            //else
            //{
            //    ddlFK_State_Facility.SelectedValue = "0";
            //}

            //txtFacility_Zip_Code.Text = objWC_FR.Facility_Zip_Code;
            rblEmergency_Room.SelectedValue = objWC_FR.Emergency_Room == "Y" ? objWC_FR.Emergency_Room : "N";
            txtTime_Began_Work.Text = objWC_FR.Time_Began_Work;
            txtActivity_Before_Incident.Text = objWC_FR.Activity_Before_Incident;
            txtObject_Substance_Involved.Text = objWC_FR.Object_Substance_Involved;

            //Comments and Attachments
            txtComments.Text = objWC_FR.Comments;

            //Set selected Initial Claim Classification listbox Items
            string[] strInitialClaim = objWC_FR.Initial_Claim_Classification.Split(',');
            if (strInitialClaim.Length > 0)
            {
                for (int i = 0; i < strInitialClaim.Length; i++)
                {
                    foreach (ListItem li in lstInitialClaim.Items)
                    {
                        if (li.Value == strInitialClaim[i])
                            li.Selected = true;
                    }
                }
            }
        }
        else
        {
            Response.Redirect("FirstReportSearch.aspx", true);
        }
    }
    #endregion

    #region Email Body Generator
    /// <summary>
    /// Used to Create Email Body
    /// </summary>
    /// <returns></returns>
    public string GenerateEMailBody(out string FirstReportNumber, ref string SocialSecurityNumber, out string Fr_Number_Prefix)
    {
        string strFilePath = HttpContext.Current.Server.MapPath("~/EmailTemplate/WC_FR.htm");
        string strEbdy = clsGeneral.ReadTextFile(strFilePath);
        if (string.IsNullOrEmpty(strEbdy))
        {
            FirstReportNumber = "";
            Fr_Number_Prefix = "";
            return "";
        }
        else
        {
            //Check First Report Wizard ID. if Greater than Zero than update data in First Report Wizard table.
            if (First_Report_Wizard_ID > 0)
            {
                //Declare Object of WC_FR table
                WC_FR objWC_FR = new WC_FR(PK_WC_FR_ID);

                DataSet dsFRW = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.WC_FR, PK_WC_FR_ID);
                DataTable dtFRW = dsFRW.Tables[0];
                if (dtFRW.Rows.Count > 0)
                {
                    DataRow drFRW = dtFRW.Rows[0];
                    #region Fill Location Information Controls

                    FirstReportNumber = drFRW["FK_First_Report_ID"].ToString();
                    Fr_Number_Prefix = drFRW["Fr_Number1"].ToString();
                    if (Fr_Number_Prefix == "NS-" && !string.IsNullOrEmpty(objWC_FR.Date_Of_Incident))
                    {
                        if (Convert.ToDateTime(objWC_FR.Date_Of_Incident) < Convert.ToDateTime("11/30/2011"))
                        {
                            Fr_Number_Prefix = "WC-";
                        }
                    }
                    decimal FR_Number = new WC_FR(FirstReportNumber.ToString() != string.Empty ? Convert.ToDecimal(FirstReportNumber) : 0).WC_FR_Number;
                    //strEbdy = strEbdy.Replace("[lblFirstReportNumber]", "WC-" + FR_Number.ToString());
                    strEbdy = strEbdy.Replace("[lblFirstReportNumber]", Fr_Number_Prefix + FR_Number.ToString());
                    //Display Location NUmber
                    if (drFRW["Sonic_Location_Code"] != null)
                        strEbdy = strEbdy.Replace("[lblLocationNumber]", drFRW["Sonic_Location_Code"].ToString());
                    else
                        strEbdy = strEbdy.Replace("[lblLocationNumber]", "");
                    //Display dba Value
                    if (drFRW["dba"] != null)
                        strEbdy = strEbdy.Replace("[lblLocationdba]", drFRW["dba"].ToString());
                    else
                        strEbdy = strEbdy.Replace("[lblLocationdba]", "");
                    //Display F/K/A value
                    if (drFRW["FK_Location_ID"] != null)
                        strEbdy = strEbdy.Replace("[lblLocationfka]", new LU_Location_FKA(Convert.ToDecimal(drFRW["FK_Location_ID"])).fka.ToString());
                    //Display Legal Entity Value
                    //if (drFRW["legal_entity"] != null)
                    //    strEbdy = strEbdy.Replace("[lblLegalEntity]", drFRW["legal_entity"].ToString());
                    //else
                    //    strEbdy = strEbdy.Replace("[lblLegalEntity]", "");

                    //set address1,address2,city,state,ZipCOde Values
                    strEbdy = strEbdy.Replace("[lblLocationAddress1]", (drFRW["Address_1"] != null) ? Convert.ToString(drFRW["Address_1"]) : "");
                    strEbdy = strEbdy.Replace("[lblLocationAddress2]", (drFRW["Address_2"] != null) ? Convert.ToString(drFRW["Address_2"]) : "");
                    strEbdy = strEbdy.Replace("[lblLocationCity]", (drFRW["City"] != null) ? Convert.ToString(drFRW["City"]) : "");
                    strEbdy = strEbdy.Replace("[lblLocationState]", new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state);
                    strEbdy = strEbdy.Replace("[lblLocationZipCode]", (drFRW["Zip_Code"] != null) ? Convert.ToString(drFRW["Zip_Code"]) : "");



                    #endregion

                    #region Fill Contact Information Controls
                    //select value of Contact Name 
                    Employee ObjEmp = new Employee(Convert.ToDecimal(drFRW["FK_Employee_ID"]));
                    if (drFRW["FK_Employee_ID"] != null)
                        strEbdy = strEbdy.Replace("[lblContactName]", ObjEmp.Last_Name.Trim() + ", " + ObjEmp.First_Name.Trim() + " " + (string.IsNullOrEmpty(ObjEmp.Middle_Name) ? "" : ObjEmp.Middle_Name).Trim());
                    else
                        strEbdy = strEbdy.Replace("[lblContactName]", "");

                    // set job Title,Telephone1,Telephone2,Fax Email Address
                    strEbdy = strEbdy.Replace("[lblContactTitle]", (drFRW["Job_Title"] != null) ? Convert.ToString(drFRW["Job_Title"]) : "");
                    //strEbdy = strEbdy.Replace("[lblContactTelephoneNumber1]", (drFRW["Work_Phone"] != null) ? Convert.ToString(drFRW["Work_Phone"]) : "");
                    //strEbdy = strEbdy.Replace("[lblContactTelephoneNumber2]", (drFRW["Employee_Cell_Phone"] != null) ? Convert.ToString(drFRW["Employee_Cell_Phone"]) : "");
                    strEbdy = strEbdy.Replace("[lblContactTelephoneNumber1]", (drFRW["TelephoneNumber1"] != null) ? Convert.ToString(drFRW["TelephoneNumber1"]) : "");
                    strEbdy = strEbdy.Replace("[lblContactTelephoneNumber2]", (drFRW["TelephoneNumber2"] != null) ? Convert.ToString(drFRW["TelephoneNumber2"]) : "");
                    strEbdy = strEbdy.Replace("[lblContactFaxNumber]", (drFRW["Contact_Fax"] != null) ? Convert.ToString(drFRW["Contact_Fax"]) : "");
                    strEbdy = strEbdy.Replace("[lblContactEmailAddress]", (drFRW["FRWEmail"] != null) ? Convert.ToString(drFRW["FRWEmail"]) : "");
                    strEbdy = strEbdy.Replace("[lbldba]", drFRW["dba"].ToString());
                    #endregion

                    #region Fill Contacts Panel Information COntrols


                    strEbdy = strEbdy.Replace("[lblContactDetailAddress_1]", drFRW["Address_1"].ToString());
                    strEbdy = strEbdy.Replace("[lblContactAddress2]", drFRW["Address_2"].ToString());
                    strEbdy = strEbdy.Replace("[lblContactDetailCity]", drFRW["City"].ToString());
                    strEbdy = strEbdy.Replace("[lblContactDetailState]", new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state);
                    strEbdy = strEbdy.Replace("[lblContactDetailZipCode]", drFRW["Zip_Code"].ToString());
                    strEbdy = strEbdy.Replace("[lblContactDetailContactName]", drFRW["Last_Name"].ToString().Trim() + ", " + drFRW["First_Name"].ToString().Trim() + " " + drFRW["Middle_Name"].ToString().Trim());
                    strEbdy = strEbdy.Replace("[lblContactBestTime]", drFRW["Contact_Best_Time"].ToString());
                    strEbdy = strEbdy.Replace("[lblContactTelephone1]", drFRW["TelephoneNumber1"].ToString());
                    strEbdy = strEbdy.Replace("[lblContactTelephone2]", drFRW["TelephoneNumber2"].ToString());
                    strEbdy = strEbdy.Replace("[lblContactDetailFaxNumber]", drFRW["Contact_Fax"].ToString());
                    strEbdy = strEbdy.Replace("[lblContactDetailEmailAddress]", drFRW["FRWEmail"].ToString());
                    //checke value if it is not null than fill related fileds value.
                    if (drFRW["FK_Regional_Loss_Control_ID"] != null && drFRW["FK_Regional_Loss_Control_ID"].ToString() != string.Empty)
                    {
                        Regional_Loss_Control objRLC = new Regional_Loss_Control(Convert.ToDecimal(drFRW["FK_Regional_Loss_Control_ID"]));
                        strEbdy = strEbdy.Replace("[lblContactRegionalManager]", objRLC.Manager.ToString());
                        strEbdy = strEbdy.Replace("[lblContactRLCMTelephone1]", objRLC.Telephone1.ToString());
                        strEbdy = strEbdy.Replace("[lblContactRLCMTelephone2]", objRLC.Telephone2.ToString());
                        strEbdy = strEbdy.Replace("[lblContactRLCMEmailAddress]", objRLC.Email.ToString());
                    }
                    else
                    {
                        strEbdy = strEbdy.Replace("[lblContactRegionalManager]", "");
                        strEbdy = strEbdy.Replace("[lblContactRLCMTelephone1]", "");
                        strEbdy = strEbdy.Replace("[lblContactRLCMTelephone2]", "");
                        strEbdy = strEbdy.Replace("[lblContactRLCMEmailAddress]", "");
                    }
                    #endregion

                    // Define Object
                    Employee objEmployee = new Employee((objWC_FR.FK_Injured));
                    Employee objEmp = new Employee(Convert.ToDecimal(objEmployee.PK_Employee_ID));
                    // Set Values to Controls

                    strEbdy = strEbdy.Replace("[lblAssociateName]", Convert.ToString(objEmp.Last_Name).Trim() + ", " + Convert.ToString(objEmp.First_Name).Trim() + " " + Convert.ToString(string.IsNullOrEmpty(objEmp.Middle_Name) ? "" : objEmp.Middle_Name).Trim());
                    strEbdy = strEbdy.Replace("[lblDate_Of_Birth]", clsGeneral.FormatDBNullDateToDisplay(objEmployee.Date_Of_Birth));
                    //check object value. if it is not null than count an age.
                    if (objEmployee.Date_Of_Birth != null)
                    {
                        if (Convert.ToDateTime(objEmployee.Date_Of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                            strEbdy = strEbdy.Replace("[lblCountdate_of_birth]", GetAge((DateTime)objEmployee.Date_Of_Birth));
                    }
                    else
                        strEbdy = strEbdy.Replace("[lblCountdate_of_birth]", "");

                    strEbdy = strEbdy.Replace("[lblGender]", Convert.ToString(objEmployee.Sex));
                    strEbdy = strEbdy.Replace("[lblAddress_1]", Convert.ToString(objEmployee.Employee_Address_1));
                    //strEbdy = strEbdy.Replace("[lblSocial_Security_Number]", clsGeneral.SupressString(objEmployee.Social_Security_Number.ToString(), objEmployee.Social_Security_Number.ToString().Length - 4));
                    SocialSecurityNumber = Convert.ToString(objEmployee.Social_Security_Number);
                    strEbdy = strEbdy.Replace("[lblAddress_2]", Convert.ToString(objEmployee.Employee_Address_2));
                    strEbdy = strEbdy.Replace("[lblDate_of_Hire]", clsGeneral.FormatDBNullDateToDisplay(objEmployee.Hire_Date));
                    strEbdy = strEbdy.Replace("[lblCity]", Convert.ToString(objEmployee.Employee_City));
                    strEbdy = strEbdy.Replace("[lblJob_Title]", Convert.ToString(objEmployee.Job_Title));

                    if (objEmployee.FK_Job_Classification != null)
                        strEbdy = strEbdy.Replace("[lblDescription]", new LU_Job_Classification(Convert.ToDecimal(objEmployee.FK_Job_Classification)).Description);
                    else
                        strEbdy = strEbdy.Replace("[lblDescription]", "");

                    strEbdy = strEbdy.Replace("[lblState]", new State(!string.IsNullOrEmpty(Convert.ToString(objEmployee.Employee_State)) ? Convert.ToDecimal(objEmployee.Employee_State) : 0).FLD_state);
                    strEbdy = strEbdy.Replace("[lblZip_code]", Convert.ToString(objEmployee.Employee_Zip_Code));
                    strEbdy = strEbdy.Replace("[lblOccupation_description]", Convert.ToString(objEmployee.Occupation_Description));
                    strEbdy = strEbdy.Replace("[lblHome_Phone]", Convert.ToString(objEmployee.Employee_Home_Phone));
                    strEbdy = strEbdy.Replace("[lblCell_phone]", Convert.ToString(objEmployee.Employee_Cell_Phone));
                    strEbdy = strEbdy.Replace("[lblSalary]", Convert.ToString(objEmployee.Salary));
                    strEbdy = strEbdy.Replace("[lblSalary_Frequency]", Convert.ToString(objEmployee.Frequency));
                    strEbdy = strEbdy.Replace("[lblSupervisor_Name]", Convert.ToString(objEmployee.Supervisor));
                    strEbdy = strEbdy.Replace("[lblDriver_License_state]", Convert.ToString(objEmployee.Drivers_License_State));
                    strEbdy = strEbdy.Replace("[lblDriver_License_Number]", Convert.ToString(objEmployee.Drivers_License_Number));
                    strEbdy = strEbdy.Replace("[lblemail]", Convert.ToString(objEmployee.Email));
                    strEbdy = strEbdy.Replace("[lblSonic_Employee_ID]", objEmployee.PK_Employee_ID.ToString());
                    strEbdy = strEbdy.Replace("[lblNumber_of_Dependents]", Convert.ToString(objEmployee.Number_Of_Dependents));

                    if (objEmployee.FK_Marital_Status != null)
                        strEbdy = strEbdy.Replace("[lblMarital_Status]", new Marital_Status(Convert.ToDecimal(objEmployee.FK_Marital_Status)).FLD_desc);
                    else
                        strEbdy = strEbdy.Replace("[lblMarital_Status]", "");

                    strEbdy = strEbdy.Replace("[lblActive_Inactive_Leave]", Convert.ToString(objEmployee.Active_Inactive_Leave));
                    strEbdy = strEbdy.Replace("[lblAlternate_Phone_2]", objWC_FR.Alternate_Phone_2);
                    //Set Contols of Associate infomariton obtained from WC_FR table
                    strEbdy = strEbdy.Replace("[lblEmployee_Days_per_week]", objWC_FR.Employee_Days_per_week.ToString());
                    strEbdy = strEbdy.Replace("[lblEmployee_hrs_per_week]", objWC_FR.Employee_hrs_per_week.ToString());
                    strEbdy = strEbdy.Replace("[lblEmployee_Time_Shift_Begins]", objWC_FR.Employee_Time_Shift_Begins.ToString());
                    strEbdy = strEbdy.Replace("[lblEmployee_Time_Shift_Ends]", objWC_FR.Employee_Time_Shift_Ends.ToString());
                    strEbdy = strEbdy.Replace("[lblSupervisor_Telephone]", objWC_FR.Supervisor_Phone.ToString());
                    strEbdy = strEbdy.Replace("[lblMotor_Vehicle_Accident]", (objWC_FR.Motor_Vehicle_Accident == true) ? "Yes" : "No");
                    strEbdy = strEbdy.Replace("[lblState_of_hire]", new State(String.IsNullOrEmpty(objWC_FR.State_of_Hire) ? 0 : Convert.ToDecimal(objWC_FR.State_of_Hire)).FLD_state);

                    //Incident Information
                    // Set Values of Object for update
                    strEbdy = strEbdy.Replace("[lblDate_Of_Incident]", objWC_FR.Date_Of_Incident);
                    strEbdy = strEbdy.Replace("[lblTime_Of_Incident]", objWC_FR.Time_Of_Incident);
                    strEbdy = strEbdy.Replace("[lblFiling_State]", new State(String.IsNullOrEmpty(objWC_FR.Filing_State) ? 0 : Convert.ToDecimal(objWC_FR.Filing_State)).FLD_state);
                    strEbdy = strEbdy.Replace("[lblInjuryOccurredOffsite]", (objWC_FR.InjuryOccurredOffsite == true) ? "Offsite" : "Onsite");
                    //check object value if it is true than display related fields.
                    if (objWC_FR.InjuryOccurredOffsite == true)
                    {
                        strEbdy = strEbdy.Replace("[lblOffsite_Address1]", objWC_FR.Offsite_Address1);
                        strEbdy = strEbdy.Replace("[lblOffsite_Address2]", objWC_FR.Offsite_Address2);
                        strEbdy = strEbdy.Replace("[lblOffsite_City]", objWC_FR.Offsite_City);
                        strEbdy = strEbdy.Replace("[lblOffsite_State]", new State(String.IsNullOrEmpty(objWC_FR.Offsite_State) ? 0 : Convert.ToDecimal(objWC_FR.Offsite_State)).FLD_state);
                        strEbdy = strEbdy.Replace("[lblOffsite_zip]", objWC_FR.Offsite_zip);
                    }
                    else
                    {
                        //strEbdy = strEbdy.Replace("[trViewIncidentInjuryOccured]", "none");
                        strEbdy = strEbdy.Replace("<!--[trViewIncidentInjuryOccured] -->", "<!--");
                        strEbdy = strEbdy.Replace("<!--[#trViewIncidentInjuryOccured] -->", " -->");
                    }
                    strEbdy = strEbdy.Replace("[lblDescription_Of_Incident]", objWC_FR.Description_Of_Incident);
                    //used to check if the value is null than set value "unknown"and 
                    //if the value is not null than and else if value is true than set value "Yes" else "N0"
                    if (objWC_FR.Associate_Injured_Regular_Job != null)
                    {
                        if (objWC_FR.Associate_Injured_Regular_Job == true)
                            strEbdy = strEbdy.Replace("[lblAssociate_Injured_Regular_Job]", "Yes");
                        else
                            strEbdy = strEbdy.Replace("[lblAssociate_Injured_Regular_Job]", "No");
                    }
                    else
                        strEbdy = strEbdy.Replace("[lblAssociate_Injured_Regular_Job]", "unknown");
                    strEbdy = strEbdy.Replace("[lblFK_Nature_Of_Injury]", new LU_Nature_of_Injury((objWC_FR.FK_Nature_Of_Injury != null) ? Convert.ToDecimal(objWC_FR.FK_Nature_Of_Injury) : 0).Description);
                    strEbdy = strEbdy.Replace("[lblFK_Department_Where_Occurred]", new LU_Department((objWC_FR.FK_Department_Where_Occurred != null) ? Convert.ToDecimal(objWC_FR.FK_Department_Where_Occurred) : 0).Description);
                    strEbdy = strEbdy.Replace("[lblFK_Body_Parts_Affected]", new LU_Part_Of_Body((objWC_FR.FK_Body_Parts_Affected != null) ? Convert.ToDecimal(objWC_FR.FK_Body_Parts_Affected) : 0).Description);
                    //used to check if the value is null than set value "unknown"and 
                    //if the value is not null than and else if value is true than set value "Yes" else "N0"
                    if (objWC_FR.Safeguards_Provided != null)
                    {
                        if (objWC_FR.Safeguards_Provided == true)
                            strEbdy = strEbdy.Replace("[lblSafeguards_Provided]", "Yes");
                        else
                            strEbdy = strEbdy.Replace("[lblSafeguards_Provided]", "No");
                    }
                    else
                        strEbdy = strEbdy.Replace("[lblSafeguards_Provided]", "unknown");
                    //used to check if the value is null than set value "unknown"and 
                    //if the value is not null than and else if value is true than set value "Yes" else "N0"
                    if (objWC_FR.Safeguards_Used != null)
                    {
                        if (objWC_FR.Safeguards_Used == true)
                            strEbdy = strEbdy.Replace("[lblSafeguards_Used]", "Yes");
                        else
                            strEbdy = strEbdy.Replace("[lblSafeguards_Used]", "No");
                    }
                    else
                        strEbdy = strEbdy.Replace("[lblSafeguards_Used]", "unknown");

                    //used to check if the value is null than set value "unknown"and 
                    //if the value is not null than and else if value is true than set value "Yes" else "N0"
                    if (objWC_FR.Machine_Part_Involved != null)
                    {
                        if (objWC_FR.Machine_Part_Involved == true)
                            strEbdy = strEbdy.Replace("[lblMachine_Part_Involved]", "Yes");
                        else
                            strEbdy = strEbdy.Replace("[lblMachine_Part_Involved]", "No");
                    }
                    else
                        strEbdy = strEbdy.Replace("[lblMachine_Part_Involved]", "unknown");

                    //used to check if the value is null than set value "unknown"and 
                    //if the value is not null than and else if value is true than set value "Yes" else "N0"
                    if (objWC_FR.Machine_Part_Defective != null)
                    {
                        if (objWC_FR.Machine_Part_Defective == true)
                            strEbdy = strEbdy.Replace("[lblMachine_Part_Defective]", "Yes");
                        else
                            strEbdy = strEbdy.Replace("[lblMachine_Part_Defective]", "No");
                    }
                    else
                        strEbdy = strEbdy.Replace("[lblMachine_Part_Defective]", "unknown");

                    //used to check if the value is null than set value "unknown"and 
                    //if the value is not null than and else if value is true than set value "Yes" else "N0"
                    if (objWC_FR.Claim_Questionable != null)
                    {
                        if (objWC_FR.Claim_Questionable == true)
                            strEbdy = strEbdy.Replace("[lblClaim_Questionable]", "Yes");
                        else
                            strEbdy = strEbdy.Replace("[lblClaim_Questionable]", "No");
                    }
                    else
                        strEbdy = strEbdy.Replace("[lblClaim_Questionable]", "unknown");

                    strEbdy = strEbdy.Replace("[lblClaim_Questionable_Description]", objWC_FR.Claim_Questionable_Description);
                    strEbdy = strEbdy.Replace("[lblDate_Reported_To_Sonic]", clsGeneral.FormatDateToDisplay(objWC_FR.Date_Reported_To_Sonic));
                    strEbdy = strEbdy.Replace("[lblperson_reported_to]", objWC_FR.person_reported_to);
                    strEbdy = strEbdy.Replace("[lblWitnesses]", ((objWC_FR.Witnesses == true) ? "Yes" : "No"));
                    strEbdy = strEbdy.Replace("[lblWitness_1]", objWC_FR.Witness_1);
                    strEbdy = strEbdy.Replace("[lblWitness_1_Phone]", objWC_FR.Witness_1_Phone);
                    strEbdy = strEbdy.Replace("[lblWitness_2]", objWC_FR.Witness_2);
                    strEbdy = strEbdy.Replace("[lblWitness_2_Phone]", objWC_FR.Witness_2_Phone);
                    strEbdy = strEbdy.Replace("[lblWitness_3]", objWC_FR.Witness_3);
                    strEbdy = strEbdy.Replace("[lblWitness_3_Phone]", objWC_FR.Witness_3_Phone);
                    strEbdy = strEbdy.Replace("[lblFatality]", (objWC_FR.Fatality == true) ? "Yes" : "No");

                    //Medical Information
                    strEbdy = strEbdy.Replace("[lblTelephone_Nurse_Consultation]", objWC_FR.Telephone_Nurse_Consultation == "Y" ? "Yes" : "No");
                    strEbdy = strEbdy.Replace("[lblSupervisor_Involved_In_Consultation]", objWC_FR.Supervisor_Involved_In_Consultation == "Y" ? "Yes" : "No");
                    strEbdy = strEbdy.Replace("[lblInitial_Medical_Treatment]", objWC_FR.Initial_Medical_Treatment);
                    strEbdy = strEbdy.Replace("[lblDate_of_Initial_Medical_Treatment]", clsGeneral.FormatDateToDisplay(objWC_FR.Date_of_Initial_Medical_Treatment));
                    strEbdy = strEbdy.Replace("[lblTaken_By_Emergency_Transportation]", (objWC_FR.Taken_By_Emergency_Transportation == true) ? "Yes" : "No");
                    strEbdy = strEbdy.Replace("[lblMedical_Facility_Name]", objWC_FR.Medical_Facility_Name);
                    strEbdy = strEbdy.Replace("[lblTreating_Physician_Name]", objWC_FR.Treating_Physician_Name);
                    strEbdy = strEbdy.Replace("[lblMedical_Facility_Address1]", objWC_FR.Medical_Facility_Address1);
                    strEbdy = strEbdy.Replace("[lblMedical_Facility_Address2]", objWC_FR.Medical_Facility_Address2);
                    strEbdy = strEbdy.Replace("[lblMedical_Facility_City]", objWC_FR.Medical_Facility_City);
                    strEbdy = strEbdy.Replace("[lblMedical_Facility_State]", new State(String.IsNullOrEmpty(objWC_FR.Medical_Facility_State) ? 0 : Convert.ToDecimal(objWC_FR.Medical_Facility_State)).FLD_state);
                    strEbdy = strEbdy.Replace("[lblMedical_Facility_Zip]", objWC_FR.Medical_Facility_Zip);
                    strEbdy = strEbdy.Replace("[lblMedical_Facility_Phone]", objWC_FR.Medical_Facility_Phone);

                    //used to check if the value is null than set value "unknown"and 
                    //if the value is not null than and else if value is true than set value "Yes" else "N0"
                    if (objWC_FR.Admitted_to_Hospital != null)
                    {
                        if (objWC_FR.Admitted_to_Hospital == true)
                            strEbdy = strEbdy.Replace("[lblAdmitted_to_Hospital]", "Yes");
                        else
                            strEbdy = strEbdy.Replace("[lblAdmitted_to_Hospital]", "No");
                    }
                    else
                        strEbdy = strEbdy.Replace("[lblAdmitted_to_Hospital]", "unknown");

                    //used to check if the value is null than set value "unknown"and 
                    //if the value is not null than and else if value is true than set value "Yes" else "N0"
                    if (objWC_FR.Still_In_Hospital != null)
                    {
                        if (objWC_FR.Still_In_Hospital == true)
                            strEbdy = strEbdy.Replace("[lblStill_In_Hospital]", "Yes");
                        else
                            strEbdy = strEbdy.Replace("[lblStill_In_Hospital]", "No");
                    }
                    else
                        strEbdy = strEbdy.Replace("[lblStill_In_Hospital]", "unknown");

                    strEbdy = strEbdy.Replace("[lblStatus_Out_Of_Work]", (objWC_FR.Status_Out_Of_Work == true) ? "Yes" : "No");
                    strEbdy = strEbdy.Replace("[lblStatus_Out_Of_Work_date]", clsGeneral.FormatDateToDisplay(objWC_FR.Status_Out_Of_Work_Date));
                    strEbdy = strEbdy.Replace("[lblStatus_Return_To_Work_Unrestricted]", (objWC_FR.Status_Return_To_Work_Unrestricted == true) ? "Yes" : "No");
                    strEbdy = strEbdy.Replace("[lblStatus_Return_To_Work_Unrestricted_date]", clsGeneral.FormatDateToDisplay(objWC_FR.Status_Return_To_Work_Unrestricted_Date));
                    strEbdy = strEbdy.Replace("[lblStatus_Return_Tp_Work_Restricted]", (objWC_FR.Status_Return_Tp_Work_Restricted == true) ? "Yes" : "No");
                    strEbdy = strEbdy.Replace("[lblStatus_Return_Tp_Work_Restricted_date]", clsGeneral.FormatDateToDisplay(objWC_FR.Status_Return_Tp_Work_Restricted_Date));
                    strEbdy = strEbdy.Replace("[lblStatus_Unknown]", (objWC_FR.Status_Unknown == true) ? "Yes" : "No");
                    strEbdy = strEbdy.Replace("[lblNext_Doctor_Visit]", clsGeneral.FormatDateToDisplay(objWC_FR.Next_Doctor_Visit));
                    strEbdy = strEbdy.Replace("[lblReferring_Physician]", (objWC_FR.Referring_Physician == true) ? "Yes" : "No");
                    //check object value. if it is set to true than display related fields else fields are remain hidden
                    if (objWC_FR.Referring_Physician == true)
                    {

                        //strEbdy = strEbdy.Replace("[tdViewReferringPhysican]", "block");
                        strEbdy = strEbdy.Replace("[lblPhysician_Name]", objWC_FR.Physician_Name);
                        strEbdy = strEbdy.Replace("[lblPhysician_Address1]", objWC_FR.Physician_Address1);
                        strEbdy = strEbdy.Replace("[lblPhysician_Address2]", objWC_FR.Physician_Address2);
                        strEbdy = strEbdy.Replace("[lblPhysician_City]", objWC_FR.Physician_City);
                        strEbdy = strEbdy.Replace("[lblPhysician_State]", new State(String.IsNullOrEmpty(objWC_FR.Physician_State) ? 0 : Convert.ToDecimal(objWC_FR.Physician_State)).FLD_state);
                        strEbdy = strEbdy.Replace("[lblPhysician_Zip]", objWC_FR.Physician_Zip);
                        strEbdy = strEbdy.Replace("[lblPhysician_Phone]", objWC_FR.Physician_Phone);
                    }
                    else
                    {
                        //strEbdy = strEbdy.Replace("[tdViewReferringPhysican]", "none");
                        strEbdy = strEbdy.Replace("<!--[tdViewReferringPhysican] -->", "<!--");
                        strEbdy = strEbdy.Replace("<!--[#tdViewReferringPhysican] -->", " -->");
                    }

                    //Comments and Attachments
                    strEbdy = strEbdy.Replace("[lblComments]", objWC_FR.Comments);

                    //Set Initial Claim Classification
                    string strInitialClaim = string.Empty;
                    string[] strSelectedClaim = objWC_FR.Initial_Claim_Classification.Split(',');
                    ListItem[] liClaim = WC_FR.InitialClaimClassificationList();

                    if (strSelectedClaim.Length > 0)
                    {
                        for (int i = 0; i < strSelectedClaim.Length; i++)
                        {
                            foreach (ListItem li in liClaim)
                            {

                                if (li.Value == strSelectedClaim[i])
                                {
                                    if (i == strSelectedClaim.Length - 0)
                                        strInitialClaim += li.Text;
                                    else
                                        strInitialClaim += li.Text + "<br/>";
                                }

                            }
                        }
                    }

                    strInitialClaim = strInitialClaim.TrimEnd(',');
                    strEbdy = strEbdy.Replace("[lblInitialClaimClassification]", strInitialClaim);
                    return strEbdy;
                }
                else
                {
                    FirstReportNumber = "";
                    Fr_Number_Prefix = "";
                    return "";
                }
            }
            else
            {
                FirstReportNumber = "";
                Fr_Number_Prefix = "";
                return "";
            }
        }

    }
    #endregion

    #region Use to Upload Files
    /// <summary>
    /// Use to Upload file from Comment section
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {
        //Insert values into WC_FR_Attachment table
        CtrlAttachment.Add(clsGeneral.Tables.WC_FR, PK_WC_FR_ID);

        // Used to Bind Grid with Attached Data
        CtrlAttachDetails.Bind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:FireAll(); ShowPanel(6);", true);
    }
    #endregion

    #region Bind Sonic Header INformation Controls
    /// <summary>
    /// Used to Bind Sonic Header Information for WC_FR page
    /// </summary>
    public void setSonicHeaderInfo()
    {
        //Create Object
        WC_FR objWC_FR = new WC_FR(PK_WC_FR_ID);

        //SonicInfo.FirstReportNumber = "WC-" + objWC_FR.WC_FR_Number.ToString();
        DataTable dtWCState = WC_FR.SelectByState(PK_WC_FR_ID);
        SonicInfo.FirstReportNumber = dtWCState.Rows[0][0].ToString();

        //Set Claim Number
        DataTable dtClaimInfo = WC_ClaimInfo.Select_Claim_Number(PK_WC_FR_ID, "WC");
        if (dtClaimInfo.Rows.Count > 0)
        {
            SonicInfo.CurrentReportType = Controls_SONICInfo_SonicInfo.ReportType.WC;
            SonicInfo.ClaimNumber = Convert.ToString(dtClaimInfo.Rows[0]["Origin_Claim_Number"]);
            SonicInfo.ClaimInfo = Convert.ToString(dtClaimInfo.Rows[0]["ClaimID"]);
        }
        SonicInfo.SONICLocationdba = new LU_Location(objWC_FR.FK_LU_Location).dba.ToString();
        SonicInfo.DateOfIncident = objWC_FR.Date_Of_Incident.ToString();
        SonicInfo.CurrentReportType = Controls_SONICInfo_SonicInfo.ReportType.WC;
        Employee ObjEmp = new Employee(objWC_FR.FK_Injured);
        SonicInfo.Name = (ObjEmp.PK_Employee_ID > 0) ? Convert.ToString(ObjEmp.Last_Name).Trim() + ", " + Convert.ToString(ObjEmp.First_Name).Trim() + " " + Convert.ToString(string.IsNullOrEmpty(ObjEmp.Middle_Name) ? "" : ObjEmp.Middle_Name).Trim() : "";
        //create Employee object for Employee Name
        Employee objEmp = new Employee(objWC_FR.FK_Contact);
        //SonicInfo.Name = objEmp.Last_Name + "," + objEmp.First_Name + " " + objEmp.Middle_Name;
        SonicInfo.WC_FR_ID_For_Investigation = PK_WC_FR_ID;
        //check user Access type. if it is view only than disable the Add new link from Header.
        //if (UserAccessType == AccessType.View_Only)
        if (Module_Access_Mode == AccessType.View_Only)
        {
            SonicInfo.AddNewLink = false;
            SonicInfo.Access_Type = false;
        }
        else
        {
            SonicInfo.AddNewLink = true;
            SonicInfo.Access_Type = true;
        }
        SonicInfo.ShowInvestigation = true;
    }
    #endregion

    #region BtnHidn Click Event
    protected void btnHdnTest_Click(object sender, EventArgs e)
    {
        // Define Object
        Employee objEmployee = new Employee((ddlAssociateName.SelectedIndex > 0) ? Convert.ToInt32(ddlAssociateName.SelectedValue) : 0);
        // Set Values to Controls
        txtDate_Of_Birth.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Date_Of_Birth);
        //if date of birth is not null than count the age and set the value to control
        if (objEmployee.Date_Of_Birth != null)
        {
            if (Convert.ToDateTime(objEmployee.Date_Of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                txtCountdate_of_birth.Text = GetAge(Convert.ToDateTime(objEmployee.Date_Of_Birth));
            else
                txtCountdate_of_birth.Text = "";
        }
        else
        {
            txtCountdate_of_birth.Text = "";
        }
        txtGender.Text = Convert.ToString(objEmployee.Sex);
        txtAddress_1.Text = Convert.ToString(objEmployee.Employee_Address_1);

        if (!string.IsNullOrEmpty(objEmployee.Social_Security_Number))
            txtSocial_Security_Number.Text = clsGeneral.SupressString(objEmployee.Social_Security_Number.ToString(), objEmployee.Social_Security_Number.ToString().Length - 4);
        else
            txtSocial_Security_Number.Text = "";

        txtAddress_2.Text = Convert.ToString(objEmployee.Employee_Address_2);
        txtDate_of_Hire.Text = clsGeneral.FormatDBNullDateToDisplay(objEmployee.Hire_Date);
        txtCity.Text = Convert.ToString(objEmployee.Employee_City);
        txtJob_Title.Text = Convert.ToString(objEmployee.Job_Title);

        if (objEmployee.FK_Job_Classification != null)
            txtDescription.Text = new LU_Job_Classification((objEmployee.FK_Job_Classification != null) ? Convert.ToDecimal(objEmployee.FK_Job_Classification) : 0).Description;
        else
            txtDescription.Text = "";

        if (objEmployee.Employee_State != null)
            txtStateEdit.Text = new State(Convert.ToDecimal(objEmployee.Employee_State)).FLD_state;
        else
            txtStateEdit.Text = "";

        txtZip_code.Text = Convert.ToString(objEmployee.Employee_Zip_Code);
        txtOccupation_description.Text = Convert.ToString(objEmployee.Occupation_Description);
        txtHome_Phone.Text = Convert.ToString(objEmployee.Employee_Home_Phone);
        txtCell_phone.Text = Convert.ToString(objEmployee.Employee_Cell_Phone);
        //check if salary is -1 than display blank
        if (objEmployee.Salary != null)
            txtSalary.Text = clsGeneral.SupressString(objEmployee.Salary.ToString(), objEmployee.Salary.ToString().Length);
        else
            txtSalary.Text = "";

        txtSalary_Frequency.Text = Convert.ToString(objEmployee.Frequency);
        txtSupervisor_Name.Text = Convert.ToString(objEmployee.Supervisor);
        txtDriver_License_stateEdit.Text = Convert.ToString(objEmployee.Drivers_License_State);
        txtDriver_License_Number.Text = Convert.ToString(objEmployee.Drivers_License_Number);
        txtemail.Text = Convert.ToString(objEmployee.Email);
        //check if Employee Associate ID is -1 than display blank
        if (objEmployee.PK_Employee_ID != -1)
            txtSonic_Employee_ID.Text = objEmployee.PK_Employee_ID.ToString();
        else
            txtSonic_Employee_ID.Text = "";
        //check if No of Department is -1 than display blank
        if (objEmployee.Number_Of_Dependents != null)
            txtNumber_of_Dependents.Text = Convert.ToString(objEmployee.Number_Of_Dependents);
        else
            txtNumber_of_Dependents.Text = "";
        txtMarital_StatusEdit.Text = new Marital_Status(objEmployee.FK_Marital_Status.ToString() != string.Empty ? Convert.ToDecimal(objEmployee.FK_Marital_Status.ToString()) : 0).FLD_desc;
        DisableAssociateControls(false);
        //Open Next Panel.
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:FireAll(); ShowPanel(2);", true);
    }
    #endregion

    #region "Send Email"

    /// <summary>
    /// Button Click Event - To send Email
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSendMail_Click(object sender, EventArgs e)
    {
        if (lblFiling_State.Text.ToLower() != "Ohio".ToLower())
            SendFROI();
        //ScriptManager.RegisterStartupScript(this, Page.GetType(), System.DateTime.Now.ToString(), "javascript:alert('First Report sent successfully');ShowPanel(" + hdnCureentPanel.Value + ");", true);
        if (!AppConfig.AllowMailSending)
        {
            ScriptManager.RegisterStartupScript(this, Page.GetType(), System.DateTime.Now.ToString(), "javascript:alert('First Report cannot be sent as mailing option is disabled');ShowPanel(" + hdnCureentPanel.Value + ");", true);
        }
        else
        {
            decimal FileSize = this.CtrlAttachmentDetailsView.GetTotalAttachmentsFileSize();
            if (FileSize > 9.5M)
            {
                String confirmMessage = "The attachments to this First Report exceed the size limitations for e-mail. The First Report can be sent without the attachments or you can Cancel and remove or reduce the size of the exiting attachments. Do you want to send the First Report without the attachments?";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", " if(window.confirm('" + confirmMessage + "')){ __doPostBack('UserConfirmationPostBackView','true');} else {alert('The First Report has NOT been sent.');ShowPanel(6);}", true);
                return;
            }
            if (ReSendReport(true))
                ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('First Report mail send successfully');ShowPanel("+ hdnCureentPanel.Value +");", true);
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "alert('Something went wrong. Please try after sometime.'); window.location='FirstReportSearch.aspx';", true);
            }
        }
    }

    /// <summary>
    /// Resend Email method
    /// </summary>
    /// <param name="_IsAttachment"></param>
    private bool ReSendReport(bool _IsAttachment)
    {
        // Declare Object
        WC_FR objWC_FR = new WC_FR(PK_WC_FR_ID);

        int iAttCount = 0;
        //Get Attachment Details
        DataTable dtAtt = WC_FR_Attacments.SelectByFROI_ID(PK_WC_FR_ID).Tables[0];
        string[] strAtt = new string[dtAtt.Rows.Count];

        if (_IsAttachment)
        {
            //check datatable row count.
            if (dtAtt.Rows.Count > 0)
            {
                foreach (DataRow drAtt in dtAtt.Rows)
                {
                    string strFileName = drAtt["Attachment_Path"].ToString();
                    strFileName = AppConfig.WC_FRDocPath + strFileName;
                    strAtt[iAttCount] = strFileName;
                    iAttCount = iAttCount + 1;
                }
            }
        }

        string[] NewEmailTo;

        if (!string.IsNullOrEmpty(AppConfig.WC_FR_EmailID))
            NewEmailTo = AppConfig.WC_FR_EmailID.ToString().Trim().Split(Convert.ToChar(","));
        else
            NewEmailTo = new string[0];

        System.Collections.Generic.List<string> lstMail = new System.Collections.Generic.List<string>();

        //get recipient Id for Databse
        //DataTable dtRecipient = Email_Settings.SelectByModuleName("WC").Tables[0];
        DataTable dtRecipient = LU_Location.GetRecipientEmailID(objWC_FR.FK_LU_Location, LU_Location.SonicReportType.WC).Tables[0];

        int intToMailCount = 0;
        if (dtRecipient.Rows.Count > 0)
        {
            foreach (DataRow drRecipient in dtRecipient.Rows)
            {
                lstMail.Insert(intToMailCount, drRecipient["Email"].ToString());
                //for (int iCount = 0; iCount < NewEmailTo.Length; iCount++)
                //{
                //    if (NewEmailTo[iCount].ToLower() == drRecipient["Email"].ToString().ToLower())
                //    {
                //        lstMail.Remove(drRecipient["Email"].ToString());
                //        intToMailCount--;
                //        break;
                //    }
                //}
                intToMailCount++;
            }
        }

        string[] EmailTo = lstMail.ToArray();
        //used to send Email
        if (First_Report_Wizard_ID > 0)
        {
            bool flag = false;
            string ReturnFRNumber, Fr_Number_Prefix;
            string SocialNumber = string.Empty;
            string HtmlBodyWithSSNsupress;
            string HtmlBodyWithOutSSNsupress;
            string HtmlBody = GenerateEMailBody(out ReturnFRNumber, ref SocialNumber, out Fr_Number_Prefix);
            HtmlBodyWithSSNsupress = HtmlBody.Replace("[lblSocial_Security_Number]", clsGeneral.SupressString(SocialNumber.ToString(), SocialNumber.ToString().Length - 4));
            HtmlBodyWithOutSSNsupress = HtmlBody.Replace("[lblSocial_Security_Number]", SocialNumber.ToString());
            decimal FR_Number = new WC_FR(ReturnFRNumber.ToString() != string.Empty ? Convert.ToDecimal(ReturnFRNumber) : 0).WC_FR_Number;

            if (EmailTo.Length > 0 && !string.IsNullOrEmpty(HtmlBodyWithSSNsupress))
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));

                if (_IsAttachment)
                    objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Repeat :: Sonic Automotive (acct #42979) reports the following First Report of Loss " + Fr_Number_Prefix + FR_Number.ToString(), HtmlBodyWithSSNsupress, true, strAtt, AppConfig.MailCC);
                else
                    objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Repeat :: Sonic Automotive (acct #42979) reports the following First Report of Loss " + Fr_Number_Prefix + FR_Number.ToString(), HtmlBodyWithSSNsupress, true, new string[] { }, AppConfig.MailCC);

                flag = true;
            }
            else
            {
                flag = false;
            }

            if (NewEmailTo.Length > 0 && !string.IsNullOrEmpty(HtmlBodyWithOutSSNsupress))
            {
                EmailHelper objEmail1 = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));

                if (_IsAttachment)
                    objEmail1.SendMailMessage(AppConfig.MailFrom, " ", NewEmailTo, "Repeat :: Sonic Automotive (acct #42979) reports the following First Report of Loss " + Fr_Number_Prefix + FR_Number.ToString(), HtmlBodyWithOutSSNsupress, true, strAtt, AppConfig.MailCC);
                else
                    objEmail1.SendMailMessage(AppConfig.MailFrom, " ", NewEmailTo, "Repeat :: Sonic Automotive (acct #42979) reports the following First Report of Loss " + Fr_Number_Prefix + FR_Number.ToString(), HtmlBodyWithOutSSNsupress, true, strAtt, AppConfig.MailCC);

                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
            //clsGeneral.SendMailMessage(AppConfig.MailFrom, EmailTo, string.Empty, string.Empty, "Sonic Automotive reports the following First Report of Loss", HtmlBody, true, strAtt); 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnCureentPanel.Value + ");", true);
        }
        else
        {
            return false;
        }

    }

    /// <summary>
    /// First Report Mail Send Method
    /// </summary>
    /// <param name="_IsAttachment"></param>
    private bool SendFirstReportMail(bool _IsAttachment)
    {
        // Declare Object
        WC_FR objWC_FR = new WC_FR(PK_WC_FR_ID);
        int iAttCount = 0;
        //Get Attachment Details
        DataTable dtAtt = WC_FR_Attacments.SelectByFROI_ID(PK_WC_FR_ID).Tables[0];
        string[] strAtt = new string[dtAtt.Rows.Count];
        if (_IsAttachment)
        {
            //check datatable row count.
            if (dtAtt.Rows.Count > 0)
            {
                foreach (DataRow drAtt in dtAtt.Rows)
                {
                    string strFileName = drAtt["Attachment_Path"].ToString();
                    strFileName = AppConfig.WC_FRDocPath + strFileName;
                    strAtt[iAttCount] = strFileName;
                    iAttCount = iAttCount + 1;
                }
            }
        }

        string[] NewEmailTo;
        if (!string.IsNullOrEmpty(AppConfig.WC_FR_EmailID))
            NewEmailTo = AppConfig.WC_FR_EmailID.ToString().Trim().Split(Convert.ToChar(","));
        else
            NewEmailTo = new string[0];

        System.Collections.Generic.List<string> lstMail = new System.Collections.Generic.List<string>();

        //get recipient Id for Database
        //DataTable dtRecipient = Email_Settings.SelectByModuleName("WC").Tables[0];
        DataTable dtRecipient = LU_Location.GetRecipientEmailID(objWC_FR.FK_LU_Location, LU_Location.SonicReportType.WC).Tables[0];

        int intToMailCount = 0;
        if (dtRecipient.Rows.Count > 0)
        {
            foreach (DataRow drRecipient in dtRecipient.Rows)
            {
                lstMail.Insert(intToMailCount, drRecipient["Email"].ToString());
                //for (int iCount = 0; iCount < NewEmailTo.Length; iCount++)
                //{
                //    if (NewEmailTo[iCount].ToLower() == drRecipient["Email"].ToString().ToLower())
                //    {
                //        lstMail.Remove(drRecipient["Email"].ToString());
                //        intToMailCount--;
                //        break;
                //    }
                //}
                intToMailCount++;
            }
        }

        string[] EmailTo = lstMail.ToArray();

        //used to send Email
        if (First_Report_Wizard_ID > 0)
        {
            bool flag = false;
            string ReturnFRNumber, Fr_Number_Prefix;
            string SocialNumber = string.Empty;
            string HtmlBodyWithSSNsupress;
            string HtmlBodyWithOutSSNsupress;
            string HtmlBody = GenerateEMailBody(out ReturnFRNumber, ref SocialNumber, out Fr_Number_Prefix);
            if (!string.IsNullOrEmpty(SocialNumber))
            {
                HtmlBodyWithSSNsupress = HtmlBody.Replace("[lblSocial_Security_Number]", clsGeneral.SupressString(SocialNumber.ToString(), SocialNumber.ToString().Length - 4));
                HtmlBodyWithOutSSNsupress = HtmlBody.Replace("[lblSocial_Security_Number]", SocialNumber.ToString());
            }
            else
            {
                HtmlBodyWithSSNsupress = HtmlBody.Replace("[lblSocial_Security_Number]", "");
                HtmlBodyWithOutSSNsupress = HtmlBody.Replace("[lblSocial_Security_Number]", "");
            }

            decimal FR_Number = new WC_FR(ReturnFRNumber.ToString() != string.Empty ? Convert.ToDecimal(ReturnFRNumber) : 0).WC_FR_Number;
            //generate FIle and store it on disk
            StreamWriter sWriter = null;
            clsGeneral.CreateDirectory(AppConfig.SitePath + "SONIC-Email/" + clsSession.FirstName + "_" + clsSession.LastName + "/WC_FR/" + DateTime.Today.ToString("MM-dd-yyyy"));
            string strName = AppConfig.SitePath + "SONIC-Email/" + clsSession.FirstName + "_" + clsSession.LastName + "/WC_FR/" + DateTime.Today.ToString("MM-dd-yyyy") + "/WC_FR_Email_" + FR_Number.ToString() + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
            string strAttachmentName = AppConfig.SitePath + "SONIC-Email/" + clsSession.FirstName + "_" + clsSession.LastName + "/WC_FR/" + DateTime.Today.ToString("MM-dd-yyyy") + "/WC_FR_Attachment_" + FR_Number.ToString() + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
            string strFName = strName + ".html";
            try
            {
                FileStream FS = new FileStream(strFName, FileMode.Create, FileAccess.ReadWrite);
                sWriter = new StreamWriter(FS);
                sWriter.Write(HtmlBodyWithSSNsupress);
            }
            finally
            {
                if (sWriter != null)
                {
                    sWriter.Close();
                }
            }

            //Copying Attachment Files.
            string[] finalAttachment = new string[strAtt.Length];
            int intfinalcount = 0;
            try
            {
                if (_IsAttachment)
                {
                    for (int iCount = 0; iCount < strAtt.Length; iCount++)
                    {
                        string[] strExtension = strAtt[iCount].Split(Convert.ToChar("."));
                        if (File.Exists(strAtt[iCount]))
                        {
                            File.Copy(strAtt[iCount], strAttachmentName + "_" + (iCount + 1) + "." + strExtension[strExtension.Length - 1], true);
                            finalAttachment[intfinalcount] = strAtt[iCount].ToString();
                            intfinalcount = intfinalcount + 1;
                        }
                    }
                }
            }
            finally { }

            if (EmailTo.Length > 0 && !string.IsNullOrEmpty(HtmlBodyWithSSNsupress))
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));

                if (_IsAttachment)
                    objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Sonic Automotive (acct #42979) reports the following First Report of Loss " + Fr_Number_Prefix + FR_Number.ToString(), HtmlBodyWithSSNsupress, true, strAtt, AppConfig.MailCC);
                else
                    objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Sonic Automotive (acct #42979) reports the following First Report of Loss " + Fr_Number_Prefix + FR_Number.ToString(), HtmlBodyWithSSNsupress, true, new string[] { }, AppConfig.MailCC);

                flag = true;
            }
            else
            {
                flag = false;
            }

            if (NewEmailTo.Length > 0 && !string.IsNullOrEmpty(HtmlBodyWithOutSSNsupress))
            {
                EmailHelper objEmail1 = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));

                if (_IsAttachment)
                    objEmail1.SendMailMessage(AppConfig.MailFrom, " ", NewEmailTo, "Sonic Automotive (acct #42979) reports the following First Report of Loss " + Fr_Number_Prefix + FR_Number.ToString(), HtmlBodyWithOutSSNsupress, true, strAtt, AppConfig.MailCC);
                else
                    objEmail1.SendMailMessage(AppConfig.MailFrom, " ", NewEmailTo, "Sonic Automotive (acct #42979) reports the following First Report of Loss " + Fr_Number_Prefix + FR_Number.ToString(), HtmlBodyWithOutSSNsupress, true, new string[] { }, AppConfig.MailCC);

                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }
        else
            return false;

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
        string strAssociatesIDs = "";
        string strAssociateErrorMsgs = "";
        string strIncidentIDs = "";
        string strIncidentErrorMsgs = "";
        string strMedicalIDs = "";
        string strMedicalErrorMsgs = "";
        string strCommentsIDs = "";
        string strCommentsErrorMsgs = "";

        #region "Location/Contact"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(1).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();



        // set menu 1 asterisk display     
        Label MenuAsterisk1 = (Label)mnuWC.Controls[0].FindControl("MenuAsterisk");
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Fax Number":
                    strCtrlsIDs += txtContactFaxNumber.ClientID + ",";
                    strMessages += "Please enter [Location/Contact]/Fax Number" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
        #endregion

        #region "Associate/Information"
        dtFields = clsScreen_Validators.SelectByScreen(2).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk2 = (Label)mnuWC.Controls[1].FindControl("MenuAsterisk");
        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Name":
                    strAssociatesIDs += ddlAssociateName.ClientID + ",";
                    strAssociateErrorMsgs += "Please select [Associate Information]/Name" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Alternate Phone 2":
                    strAssociatesIDs += txtAlternate_Phone_2.ClientID + ",";
                    strAssociateErrorMsgs += "Please enter [Associate Information]/Alternate Phone 2" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "State of Hire":
                    strAssociatesIDs += ddlState_of_hire.ClientID + ",";
                    strAssociateErrorMsgs += "Please select [Associate Information]/State of Hire" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Hours worked Per week":
                    strAssociatesIDs += txtEmployee_hrs_per_week.ClientID + ",";
                    strAssociateErrorMsgs += "Please enter [Associate Information]/Hours worked Per week" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Days worked Per week":
                    strAssociatesIDs += txtEmployee_Days_per_week.ClientID + ",";
                    strAssociateErrorMsgs += "Please enter [Associate Information]/Days worked Per week" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Time Shift Begins":
                    strAssociatesIDs += txtEmployee_Time_Shift_Begins.ClientID + ",";
                    strAssociateErrorMsgs += "Please enter [Associate Information]/Time Shift Begins" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Time Shift Ends":
                    strAssociatesIDs += txtEmployee_Time_Shift_Ends.ClientID + ",";
                    strAssociateErrorMsgs += "Please enter [Associate Information]/Time Shift Ends" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Supervisor Telephone":
                    strAssociatesIDs += txtSupervisor_Telephone.ClientID + ",";
                    strAssociateErrorMsgs += "Please enter [Associate Information]/Supervisor Telephone" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        strAssociatesIDs = strAssociatesIDs.TrimEnd(',');
        strAssociateErrorMsgs = strAssociateErrorMsgs.TrimEnd(',');

        hdnAssociateID.Value = strAssociatesIDs;
        hdnAssociateErrorMsgs.Value = strAssociateErrorMsgs;
        #endregion

        #region "Incident/Information"
        dtFields = clsScreen_Validators.SelectByScreen(3).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk3 = (Label)mnuWC.Controls[2].FindControl("MenuAsterisk");
        MenuAsterisk3.Style["display"] = (dtFields.Select("LeftMenuIndex = 3").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date of Incident":
                    strIncidentIDs += txtDate_Of_Incident.ClientID + ",";
                    strIncidentErrorMsgs += "Please enter [Incident/Information]/Date of Incident" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Time of Incident(HH:MM)":
                    strIncidentIDs += txtTime_Of_Incident.ClientID + ",";
                    strIncidentErrorMsgs += "Please enter [Incident/Information]/Time of Incident(HH:MM)" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Filing State":
                    strIncidentIDs += ddlFiling_State.ClientID + ",";
                    strIncidentErrorMsgs += "Please select [Incident/Information]/Filing State" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Description of Incident":
                    strIncidentIDs += txtDescription_Of_Incident.ClientID + ",";
                    strIncidentErrorMsgs += "Please enter [Incident/Information]/Description of Incident" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "Nature of Injury":
                    strIncidentIDs += ddlFK_Nature_Of_Injury.ClientID + ",";
                    strIncidentErrorMsgs += "Please select [Incident/Information]/Nature of Injury" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "Department Where Injury Occurred":
                    strIncidentIDs += ddlFK_Department_Where_Occurred.ClientID + ",";
                    strIncidentErrorMsgs += "Please select [Incident/Information]/Department Where Injury Occurred" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                case "Body Part Affected":
                    strIncidentIDs += ddlFK_Body_Parts_Affected.ClientID + ",";
                    strIncidentErrorMsgs += "Please select [Incident/Information]/Body Part Affected" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                //case "Was the claim Questionable? If Yes Why?":
                //    strIncidentIDs += txtClaim_Questionable_Description.ClientID + ",";
                //    strIncidentErrorMsgs += "Please enter [Incident/Information]/Was the claim Questionable? If Yes Why?" + ",";
                //    Span17.Style["display"] = "inline-block";
                //    break;
                case "Date Reported to Sonic":
                    strIncidentIDs += txtDate_Reported_To_Sonic.ClientID + ",";
                    strIncidentErrorMsgs += "Please enter [Incident/Information]/Date Reported to Sonic" + ",";
                    Span18.Style["display"] = "inline-block";
                    break;
                case "To Whom at Sonic was Incident Reported to?":
                    strIncidentIDs += txtperson_reported_to.ClientID + ",";
                    strIncidentErrorMsgs += "Please enter [Incident/Information]/To Whom at Sonic was Incident Reported to?" + ",";
                    Span19.Style["display"] = "inline-block";
                    break;
                case "Witness 1":
                    strIncidentIDs += txtWitness_1.ClientID + ",";
                    strIncidentErrorMsgs += "Please enter [Incident/Information]/Witness 1" + ",";
                    Span20.Style["display"] = "inline-block";
                    break;
                case "Witness 2":
                    strIncidentIDs += txtWitness_2.ClientID + ",";
                    strIncidentErrorMsgs += "Please enter [Incident/Information]/Witness 2" + ",";
                    Span21.Style["display"] = "inline-block";
                    break;
                case "Witness 3":
                    strIncidentIDs += txtWitness_3.ClientID + ",";
                    strIncidentErrorMsgs += "Please enter [Incident/Information]/Witness 3" + ",";
                    Span22.Style["display"] = "inline-block";
                    break;
                case "Witness 1 Telephone":
                    strIncidentIDs += txtWitness_1_Phone.ClientID + ",";
                    strIncidentErrorMsgs += "Please enter [Incident/Information]/Witness 1 Telephone" + ",";
                    Span23.Style["display"] = "inline-block";
                    break;
                case "Witness 2 Telephone":
                    strIncidentIDs += txtWitness_2_Phone.ClientID + ",";
                    strIncidentErrorMsgs += "Please enter [Incident/Information]/Witness 2 Telephone" + ",";
                    Span24.Style["display"] = "inline-block";
                    break;
                case "Witness 3 Telephone":
                    strIncidentIDs += txtWitness_3_Phone.ClientID + ",";
                    strIncidentErrorMsgs += "Please enter [Incident/Information]/Witness 3 Telephone" + ",";
                    Span25.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strIncidentIDs += txtOffsite_Address1.ClientID + ",";
                    strIncidentErrorMsgs += "Please enter [Incident/Information]/Address 1" + ",";
                    Span40.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strIncidentIDs += txtOffsite_Address2.ClientID + ",";
                    strIncidentErrorMsgs += "Please enter [Incident/Information]/Address 2" + ",";
                    Span41.Style["display"] = "inline-block";
                    break;
                case "City":
                    strIncidentIDs += txtOffsite_City.ClientID + ",";
                    strIncidentErrorMsgs += "Please enter [Incident/Information]/City" + ",";
                    Span42.Style["display"] = "inline-block";
                    break;
                case "State":
                    strIncidentIDs += ddlOffsite_State.ClientID + ",";
                    strIncidentErrorMsgs += "Please select [Incident/Information]/State" + ",";
                    Span43.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strIncidentIDs += txtOffsite_zip.ClientID + ",";
                    strIncidentErrorMsgs += "Please enter [Incident/Information]/Zip Code" + ",";
                    Span44.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        strIncidentIDs = strIncidentIDs.TrimEnd(',');
        strIncidentErrorMsgs = strIncidentErrorMsgs.TrimEnd(',');

        hdnIncidentID.Value = strIncidentIDs;
        hdnIncidentErrorMsgs.Value = strIncidentErrorMsgs;
        #endregion

        #region "Medical"
        dtFields = clsScreen_Validators.SelectByScreen(4).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk4 = (Label)mnuWC.Controls[3].FindControl("MenuAsterisk");
        MenuAsterisk4.Style["display"] = (dtFields.Select("LeftMenuIndex = 4").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Describe Initial Treatment":
                    strMedicalIDs += txtInitial_Medical_Treatment.ClientID + ",";
                    strMedicalErrorMsgs += "Please enter [Medical]/Describe Initial Treatment" + ",";
                    Span27.Style["display"] = "inline-block";
                    break;
                case "Date of Initial Treatment":
                    strMedicalIDs += txtDate_of_Initial_Medical_Treatment.ClientID + ",";
                    strMedicalErrorMsgs += "Please enter [Medical]/Date of Initial Treatment" + ",";
                    Span28.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Name":
                    strMedicalIDs += txtMedical_Facility_Name.ClientID + ",";
                    strMedicalErrorMsgs += "Please enter [Medical]/Medical Facility Name" + ",";
                    Span29.Style["display"] = "inline-block";
                    break;
                case "Treating Physician's Name":
                    strMedicalIDs += txtTreating_Physician_Name.ClientID + ",";
                    strMedicalErrorMsgs += "Please enter [Medical]/Treating Physician's Name" + ",";
                    Span30.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Address 1":
                    strMedicalIDs += txtMedical_Facility_Address1.ClientID + ",";
                    strMedicalErrorMsgs += "Please enter [Medical]/Medical Facility Address 1" + ",";
                    Span31.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Address 2":
                    strMedicalIDs += txtMedical_Facility_Address2.ClientID + ",";
                    strMedicalErrorMsgs += "Please enter [Medical]/Medical Facility Address 2" + ",";
                    Span32.Style["display"] = "inline-block";
                    break;
                case "Medical Facility City":
                    strMedicalIDs += txtMedical_Facility_City.ClientID + ",";
                    strMedicalErrorMsgs += "Please enter [Medical]/Medical Facility City" + ",";
                    Span33.Style["display"] = "inline-block";
                    break;
                case "Medical Facility State":
                    strMedicalIDs += ddlMedical_Facility_State.ClientID + ",";
                    strMedicalErrorMsgs += "Please select [Medical]/Medical Facility State" + ",";
                    Span34.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Zip Code":
                    strMedicalIDs += txtMedical_Facility_Zip.ClientID + ",";
                    strMedicalErrorMsgs += "Please enter [Medical]/Medical Facility Zip Code" + ",";
                    Span35.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Telephone":
                    strMedicalIDs += txtMedical_Facility_Phone.ClientID + ",";
                    strMedicalErrorMsgs += "Please enter [Medical]/Medical Facility Telephone" + ",";
                    Span36.Style["display"] = "inline-block";
                    break;
                case "Next Doctor’s Office Visit":
                    strMedicalIDs += txtNext_Doctor_Visit.ClientID + ",";
                    strMedicalErrorMsgs += "Please enter [Medical]/Next Doctor’s Office Visit" + ",";
                    Span37.Style["display"] = "inline-block";
                    break;
                case "Out of work Date":
                    strMedicalIDs += txtStatus_Out_Of_Work_date.ClientID + ",";
                    strMedicalErrorMsgs += "Please enter [Medical]/Out of Work As Of Date" + ",";
                    Span45.Style["display"] = "none";
                    break;
                case "Return Regular Date":
                    strMedicalIDs += txtStatus_Return_To_Work_Unrestricted_date.ClientID + ",";
                    strMedicalErrorMsgs += "Please enter [Medical]/Returned to Regular Job with no Restrictions As Of Date" + ",";
                    Span46.Style["display"] = "none";
                    break;
                case "Returned work with Date":
                    strMedicalIDs += txtStatus_Return_Tp_Work_Restricted_date.ClientID + ",";
                    strMedicalErrorMsgs += "Please enter [Medical]/Returned to Work with Restrictions AS Of Date" + ",";
                    Span47.Style["display"] = "none";
                    break;
                case "Physician's Name": strMedicalIDs += txtPhysician_Name.ClientID + ","; strMedicalErrorMsgs += "Please enter [Medical]Physician's Name" + ","; Span48.Style["display"] = "inline-block"; break;
                case "Physician's Address 1": strMedicalIDs += txtPhysician_Address1.ClientID + ","; strMedicalErrorMsgs += "Please enter [Medical]Physician's Address 1" + ","; Span49.Style["display"] = "inline-block"; break;
                case "Physician's Address 2": strMedicalIDs += txtPhysician_Address2.ClientID + ","; strMedicalErrorMsgs += "Please enter [Medical]Physician's Address 2" + ","; Span50.Style["display"] = "inline-block"; break;
                case "Physician's City": strMedicalIDs += txtPhysician_City.ClientID + ","; strMedicalErrorMsgs += "Please enter [Medical]Physician's City" + ","; Span51.Style["display"] = "inline-block"; break;
                case "Physician's State": strMedicalIDs += ddlPhysician_State.ClientID + ","; strMedicalErrorMsgs += "Please enter [Medical]Physician's State" + ","; Span52.Style["display"] = "inline-block"; break;
                case "Physician's Zip Code": strMedicalIDs += txtPhysician_Zip.ClientID + ","; strMedicalErrorMsgs += "Please enter [Medical]Physician's Zip Code" + ","; Span53.Style["display"] = "inline-block"; break;
                case "Physician's Telephone": strMedicalIDs += txtPhysician_Phone.ClientID + ","; strMedicalErrorMsgs += "Please enter [Medical]Physician's Telephone" + ","; Span54.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strMedicalIDs = strMedicalIDs.TrimEnd(',');
        strMedicalErrorMsgs = strMedicalErrorMsgs.TrimEnd(',');

        hdnMedicalID.Value = strMedicalIDs;
        hdnMedicalErrorMsgs.Value = strMedicalErrorMsgs;
        #endregion

        #region "Comments"
        dtFields = clsScreen_Validators.SelectByScreen(6).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk5 = (Label)mnuWC.Controls[5].FindControl("MenuAsterisk");
        MenuAsterisk5.Style["display"] = (dtFields.Select("LeftMenuIndex = 6").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Initial Claim Classification":
                    strCommentsIDs += lstInitialClaim.ClientID + ",";
                    strCommentsErrorMsgs += "Please select [Comments]/Initial Claim Classification" + ",";
                    Span38.Style["display"] = "inline-block";
                    break;
                case "Comments/Special Instructor to Adjuster":
                    strCommentsIDs += txtComments.ClientID + ",";
                    strCommentsErrorMsgs += "Please enter [Comments]/Special Instructor to Adjuster" + ",";
                    Span39.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        strCommentsIDs = strCommentsIDs.TrimEnd(',');
        strCommentsErrorMsgs = strCommentsErrorMsgs.TrimEnd(',');

        hdnCommentsID.Value = strCommentsIDs;
        hdnCommentsErrorMsgs.Value = strCommentsErrorMsgs;
        #endregion


    }

    #endregion

    private void SendFROI()
    {
        clsFROI_Output objFROI = new clsFROI_Output();
        objFROI.FROI_Type = "WC";
        objFROI.FROI_Number = Convert.ToDecimal(((Label)SonicInfo.FindControl("lblFirstReportNumber")).Text.Trim().Replace("WC-", "").Replace("NS-", ""));
        objFROI.Insert();
    }
}

