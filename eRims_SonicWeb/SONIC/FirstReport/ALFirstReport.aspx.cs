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
/// Date           : 25-07-08
/// 
/// Developer Name : Ravi Gupta
/// 
/// Description    : This Page is used to Add a Auto Loss Informaition regarding current First Report WIzard.
///                  it also display stored data in View Mode.
/// 
/// </summary>
public partial class SONIC_ALFirstReport : clsBasePage
{
    #region Private Variable and Property
    public RIMS_Base.Biz.CAttachment m_objAttachment;

    private static int AL_FR_ID = 0;
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
    /// Denotes the AL First Report ID
    /// </summary>
    public int PK_AL_FR_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["AL_FR_ID"]);
        }
        set { ViewState["AL_FR_ID"] = value; }
    }
    #endregion

    #region "Page Event"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        SonicTab.SetSelectedTab(Controls_SONICtab_SonicTab.Tab.AL);
        //declare Handle of Attachment Control for File Upload
        CtrlAttachments.btnHandler += new Sonic_Attachment.OnButtonClick(Upload_File);
        txtCurrentDate.Text = DateTime.Now.ToShortDateString().ToString();
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
            //Get Id from Query string
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                try
                {
                    PK_AL_FR_ID = Convert.ToInt32(Encryption.Decrypt(Request.QueryString["id"].ToString()));
                    //set Page Mode as per User Access Type if it is View ONly than always open page in
                    //View Mode Only. else if the report is completed  than open page in View MOde Else in Edit MOde
                    if (Module_Access_Mode == AccessType.View_Only)
                    //if (UserAccessType == AccessType.View_Only)
                    {
                        strPageOpeMode = "view";
                    }
                    else
                    {
                        strPageOpeMode = (new AL_FR(PK_AL_FR_ID).Complete == false) ? "edit" : "view";
                    }

                    btnSendMail.Visible = (UserAccessType == AccessType.Administrative_Access) && (new AL_FR(PK_AL_FR_ID).Complete == true);

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
            //check Page Opertion Mode
            if (strPageOpeMode == "add")
            {
                //used to display panel according to passed Index parameter in function of Javascript.
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

                #region Location and Contact Panel
                //fill Sonic Location Number
                ComboHelper.FillSonicLocationNumberOnlyForView(new DropDownList[] { ddlLocationNumber }, 0, true);
                ddlLocationNumber.Style.Remove("");

                //Fill Location dba Dropdown
                ComboHelper.FillLocationdbaOnlyForView(new DropDownList[] { ddlLocationdba }, 0, true);
                //Fill Location Legal Entity Dropdown
                //ComboHelper.FillLocationLegal_EntityForView(new DropDownList[] { ddlLegalEntity }, 0, true);
                //Fill Location FKA Dropdown
                ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);
                //Fetch Related Record for Location and EMployee
                BindLocationandContactInfo();
                #endregion

                #region Loss Information Panel
                //fill State Combos
                ComboHelper.FillState(new DropDownList[] { ddlClaimant_state, ddlOffsite_State }, 0, true);
                ComboHelper.FillAuto_Liability_Type(new DropDownList[] { ddlAuto_Liability_Type }, 0, true);
                #endregion

                #region Insured Vehicle Information Panel
                //fill State Dropdowns
                ComboHelper.FillState(new DropDownList[] { ddlLicense_Plate_State, ddlVehicle_Location_Driver_State, ddlOwner_State }, 0, true);
                //FIll Vehicle Type Dropdown
                ComboHelper.FillVehicleType(new DropDownList[] { ddlVehicle_Sub_Type }, 0, true);
                #endregion

                #region Isured Vehicle Driver Information Panel
                //Fill State Information
                ComboHelper.FillState(new DropDownList[] { ddlDriver_State, ddlDriver_Drivers_License_State, ddlDriver_Medical_Facility_State }, 0, true);
                #endregion

                #region Insured Vehical Passenger Information Panel
                //Fill State Information
                ComboHelper.FillState(new DropDownList[] { ddlPassenger_State, ddlPassenger_Drivers_License_State }, 0, true);
                #endregion

                #region Othere Vehicle Information Panel
                //fill State Dropdown
                ComboHelper.FillState(new DropDownList[] { ddlOther_Vehicle_License_Plate_State, ddlOther_Vehicle_Location_Driver_State, ddlOther_Vehicle_Owner_State }, 0, true);
                #endregion

                #region Other Vehicle Driver Information Panel
                // fill State Dropdown
                ComboHelper.FillState(new DropDownList[] { ddlOther_Driver_State, ddlOther_Driver_Drivers_License_State, ddlOther_Driver_Medical_Facility_State }, 0, true);
                #endregion

                #region Other Vehicle Passenger Information Panel
                //fill State Dropdown
                ComboHelper.FillState(new DropDownList[] { ddlOth_Veh_Pass_State, ddlOth_Veh_Pass_Medical_Facility_State }, 0, true);
                #endregion

                #region Pedestrian
                //fill State Dropdown
                ComboHelper.FillState(new DropDownList[] { ddlPedestrian_State, ddlPedestrian_Medical_Facility_State }, 0, true);
                #endregion

                #region Witnesses
                //fill State dropdwon
                ComboHelper.FillState(new DropDownList[] { ddlWitness_State }, 0, true);
                #endregion

                #region Attchement
                CtrlAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.AL_FR, PK_AL_FR_ID, true, 11);
                CtrlAttachDetails.Bind();
                #endregion
            }
            else if (strPageOpeMode == "view")
            {
                //Fecth Information
                BindPageinViewMode();
                //Open Next Panel.using Showpanel Javascript function.
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            }
            else if (strPageOpeMode == "edit")
            {
                #region Location and Contact Panel
                //fill Sonic Location Number
                ComboHelper.FillSonicLocationNumberOnlyForView(new DropDownList[] { ddlLocationNumber }, 0, true);
                //Fill Location dba Dropdown
                ComboHelper.FillLocationdbaOnlyForView(new DropDownList[] { ddlLocationdba }, 0, true);
                //Fill Location Legal Entity Dropdown
                //ComboHelper.FillLocationLegal_EntityForView(new DropDownList[] { ddlLegalEntity }, 0, true);
                //Fill Location FKA Dropdown
                ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);
                //Open Next Panel.using Showpanel Javascript function.
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
                #endregion

                #region Loss Information Panel
                //fill State Combos
                ComboHelper.FillState(new DropDownList[] { ddlClaimant_state, ddlOffsite_State }, 0, true);
                ComboHelper.FillAuto_Liability_Type(new DropDownList[] { ddlAuto_Liability_Type }, 0, true);
                #endregion

                #region Insured Vehicle Information Panel
                //fill State Dropdowns
                ComboHelper.FillState(new DropDownList[] { ddlLicense_Plate_State, ddlVehicle_Location_Driver_State, ddlOwner_State }, 0, true);
                //FIll Vehicle Type Dropdown
                ComboHelper.FillVehicleType(new DropDownList[] { ddlVehicle_Sub_Type }, 0, true);
                #endregion

                #region Isured Vehicle Driver Information Panel
                //Fill State Information
                ComboHelper.FillState(new DropDownList[] { ddlDriver_State, ddlDriver_Drivers_License_State, ddlDriver_Medical_Facility_State }, 0, true);
                #endregion

                #region Insured Vehical Passenger Information Panel
                //Fill State Information
                ComboHelper.FillState(new DropDownList[] { ddlPassenger_State, ddlPassenger_Drivers_License_State }, 0, true);
                #endregion

                #region Othere Vehicle Information Panel
                //fill State Dropdown
                ComboHelper.FillState(new DropDownList[] { ddlOther_Vehicle_License_Plate_State, ddlOther_Vehicle_Location_Driver_State, ddlOther_Vehicle_Owner_State }, 0, true);
                #endregion

                #region Other Vehicle Driver Information Panel
                // fill State Dropdown
                ComboHelper.FillState(new DropDownList[] { ddlOther_Driver_State, ddlOther_Driver_Drivers_License_State, ddlOther_Driver_Medical_Facility_State }, 0, true);
                #endregion

                #region Other Vehicle Passenger Information Panel
                //fill State Dropdown
                ComboHelper.FillState(new DropDownList[] { ddlOth_Veh_Pass_State, ddlOth_Veh_Pass_Medical_Facility_State }, 0, true);
                #endregion

                #region Pedestrian
                //fill State Dropdown
                ComboHelper.FillState(new DropDownList[] { ddlPedestrian_State, ddlPedestrian_Medical_Facility_State }, 0, true);
                #endregion

                #region Witnesses
                //fill State dropdwon
                ComboHelper.FillState(new DropDownList[] { ddlWitness_State }, 0, true);
                #endregion

                #region Attchement
                CtrlAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.AL_FR, PK_AL_FR_ID, true, 11);
                CtrlAttachDetails.Bind();
                #endregion

                //Fecth Information
                BindPageinEditMode();
                SetValidations();
            }
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
                    //Complate AL_First Report and Send Email.      
                    Int32 intRetVal = ComplateAL_FRReport(false);

                    if (intRetVal == 1)
                    {
                        Response.Redirect("FirstReportStatus.aspx", true);
                    }
                    else if (intRetVal == -1)
                    {
                        //use to open panel.use ShowPanel javascript Function
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('First Report is already submited');ShowPanel(11);", true);
                    }
                    else
                    {
                        //use to open panel.use ShowPanel javascript Function
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:FireAll(); ShowPanel(11);", true);
                    }

                    ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('The First Report e-mail send without the attachments.');ShowPanel(11);", true);
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('The First Report has NOT been sent, please reduce the number and/or size of the attachments before attempting to resubmit with attachments.');ShowPanel(11);", true);

            }
            else if (eventTarget == "UserConfirmationPostBackView")
            {
                if (eventArgument == "true")
                {
                    if (ResendMail(false))
                        ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('the First Report e-mail send without the attachments.');ShowPanel(11);", true);
                    else
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "alert('Something went wrong. Please try after sometime.'); window.location='FirstReportSearch.aspx';", true);
                }
            }
            if (First_Report_Wizard_ID != clsSession.First_Report_Wizard_ID)
                clsSession.First_Report_Wizard_ID = First_Report_Wizard_ID;
        }
    }

    #endregion

    #region Save and Continue Event

    /// <summary>
    /// BUtton Location Save Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLocationSave_Click(object sender, EventArgs e)
    {
        //Update Location/Contact Information
        UpdateLocationInformation();
        //use to open panel.use ShowPanel javascript Function
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(2);", true);
    }

    /// <summary>
    /// Button Loss Save Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLossSave_Click(object sender, EventArgs e)
    {
        //Update LossInformation
        UpdateLossInformation();
        //Update Hidden field value to identify that user had save these data once
        hdnLoss.Value = "1";
        //Update Sonic Info Header
        setSonicHeaderInfo();
        //use to open panel.use ShowPanel javascript Function
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(3);", true);
    }

    /// <summary>
    /// Button CLick Event - To Save Insured Vehicle Info
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInsuredVehicleSave_Click(object sender, EventArgs e)
    {
        //Update InsuredVehicle Information
        UpdateInsuredVehicleInformation();
        //this is hidden field that are used to check that the panel is saved or not. because this panel
        //contain Require fields and we must have to save this panel. if it is not done than the value of hidden
        //Control is blank and given a prompt when user click on submit button at comment & attachment Panel
        hdnInsured.Value = "1";
        //use to open panel.use ShowPanel javascript Function
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(4);", true);
    }

    /// <summary>
    /// Button Click Event -To Save Insured Driver Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInsuredVehicleDriverSave_Click(object sender, EventArgs e)
    {
        //Update Insured Vehicle Driver Information
        UpdateInsuredVehicleDriverInformation();
        //use to open panel.use ShowPanel javascript Function
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(5);", true);
    }

    /// <summary>
    /// BUtton Click Event - To Save Passenger Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnIVPassengerSave_Click(object sender, EventArgs e)
    {
        //Update Insured Vehicle Passenger Information
        UpdateInsuredVehiclePassengerInformation();
        //use to open panel.use ShowPanel javascript Function
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(6);", true);
    }

    /// <summary>
    /// BUtton Click Event - To Save OV detals
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOVSave_Click(object sender, EventArgs e)
    {
        //update Other Vehicle Information
        UpdateOtherVehicleInformation();
        //this is hidden field that are used to check that the panel is saved or not. because this panel
        //contain Require fields and we must have to save this panel. if it is not done than the value of hidden
        //Control is blank and given a prompt when user click on submit button at comment & attachment Panel
        hdnOther.Value = "1";
        //use to open panel.use ShowPanel javascript Function
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(7);", true);
    }

    /// <summary>
    /// Button CLick Event - To Save OV Driver Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOVDriverSave_Click(object sender, EventArgs e)
    {
        // udpate Other Driver Information
        UpdateOtherDriverInformation();
        //use to open panel.use ShowPanel javascript Function
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(8);", true);
    }

    /// <summary>
    /// Button Click Event -To Save OV Passenger Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOVPassengerSave_Click(object sender, EventArgs e)
    {
        //Update Other vehicle Passenger Information
        UpdateOtherVehiclePassengerInformation();
        //use to open panel.use ShowPanel javascript Function
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(9);", true);
    }

    /// <summary>
    /// Button CLick Event - To Save Pedestrian Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPedestrianSave_Click(object sender, EventArgs e)
    {
        //Udpate Pedestrian Information
        UpdatePedestrianInformation();
        //use to open panel.use ShowPanel javascript Function
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(10);", true);
    }

    /// <summary>
    /// Button Click Event - To Save Witnedd Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnWitnessSave_Click(object sender, EventArgs e)
    {
        //update Witness Information
        UpdateWitnessInformation();
        //use to open panel.use ShowPanel javascript Function
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(11);", true);
    }

    /// <summary>
    /// Used to Submit Whole report.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        UpdateLocationInformation();
        UpdateLossInformation();
        UpdateInsuredVehicleInformation();
        UpdateInsuredVehicleDriverInformation();
        UpdateInsuredVehiclePassengerInformation();
        UpdateOtherVehicleInformation();
        UpdateOtherDriverInformation();
        UpdateOtherVehiclePassengerInformation();
        UpdatePedestrianInformation();
        UpdateWitnessInformation();

        //Complate AL_First Report and Send Email.      
        Int32 intRetVal = ComplateAL_FRReport(true);

        if (intRetVal == 1)
        {
            Response.Redirect("FirstReportStatus.aspx", true);
        }
        else if (intRetVal == -1)
        {
            //use to open panel.use ShowPanel javascript Function
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('First Report is already submited');ShowPanel(11);", true);
        }
        else
        {
            //use to open panel.use ShowPanel javascript Function
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:FireAll(); ShowPanel(11);", true);
        }

    }

    #endregion

    #region Location and Contact Panel Events

    /// <summary>
    /// Used to Bind Location Information and Contact Details
    /// </summary>
    public void BindLocationandContactInfo()
    {
        DataSet dsWizardInfo = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.AL_FR, PK_AL_FR_ID);
        DataTable dtWizardInfo = dsWizardInfo.Tables[0];
        foreach (DataRow drWizardInfo in dtWizardInfo.Rows)
        {
            #region Fill Location Information Controls
            //select value from Location Number Dropdown
            if (drWizardInfo["Sonic_Location_Code"] != null)
            {
                ListItem lst = new ListItem();
                //check list item if not null than list item selected = true
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
            //select value from Location d/b/a Dropdown
            if (drWizardInfo["dba"] != null)
            {
                ListItem lst = new ListItem();
                lst = ddlLocationdba.Items.FindByText(drWizardInfo["dba"].ToString());
                //check list item if not null than list item selected = true
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
            //select value from Location f/k/a Dropdown
            if (drWizardInfo["PK_LU_Location_ID"] != null)
            {
                //Fill Location FKA Dropdown
                // ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, (drWizardInfo["FK_Location_ID"] != null) ? Convert.ToInt32(drWizardInfo["FK_Location_ID"]) : 0, true);


                ListItem lst = new ListItem();
                lst = ddlLocationfka.Items.FindByValue(drWizardInfo["PK_LU_Location_ID"].ToString());
                //check list item if not null than list item selected = true
                if (lst != null)
                {
                    lst.Selected = true;
                }

            }
            //select value from Location Legal Entity Dropdown
            //if (drWizardInfo["legal_entity"] != null)
            //{
            //    ListItem lst = new ListItem();
            //    lst = ddlLegalEntity.Items.FindByText(drWizardInfo["legal_entity"].ToString());
            //    //check list item if not null than list item selected = true
            //    if (lst != null)
            //    {
            //        lst.Selected = true;
            //    }
            //}

            //set address1,address2,city,state,ZipCOde Values
            txtLocationAddress1.Text = (drWizardInfo["Address_1"] != null) ? Convert.ToString(drWizardInfo["Address_1"]) : "";
            txtLocationAddress2.Text = (drWizardInfo["Address_2"] != null) ? Convert.ToString(drWizardInfo["Address_2"]) : "";
            txtLocationCity.Text = (drWizardInfo["City"] != null) ? Convert.ToString(drWizardInfo["City"]) : "";
            txtLocationState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drWizardInfo["State"])) ? Convert.ToDecimal(drWizardInfo["State"]) : 0).FLD_state;
            txtLocationZipCode.Text = (drWizardInfo["Zip_Code"] != null) ? Convert.ToString(drWizardInfo["Zip_Code"]) : "";

            #endregion

            #region Fill Contact Information Controls

            txtContactName.Text = (drWizardInfo["EmployeeName"] != null) ? Convert.ToString(drWizardInfo["EmployeeName"]) : "";
            txtContact_Best_Time.Text = (drWizardInfo["Contact_Best_Time"] != null) ? Convert.ToString(drWizardInfo["Contact_Best_Time"]) : "";
            txtContactTelephoneNumber1.Text = (drWizardInfo["TelephoneNumber1"] != null) ? Convert.ToString(drWizardInfo["TelephoneNumber1"]) : "";
            txtContactTelephoneNumber2.Text = (drWizardInfo["TelephoneNumber2"] != null) ? Convert.ToString(drWizardInfo["TelephoneNumber2"]) : "";
            txtContactFaxNumber.Text = (drWizardInfo["Contact_Fax"] != null) ? Convert.ToString(drWizardInfo["Contact_Fax"]) : "";
            txtContactEmailAddress.Text = (drWizardInfo["FRWEmail"] != null) ? Convert.ToString(drWizardInfo["FRWEmail"]) : "";
            //fill Controls By Cost Center Value
            txtCostCenterdba.Text = (drWizardInfo["dba"] != null) ? Convert.ToString(drWizardInfo["dba"]) : "";
            txtCostCenterAddress1.Text = (drWizardInfo["Address_1"] != null) ? Convert.ToString(drWizardInfo["Address_1"]) : "";
            txtCostCenterAddress2.Text = (drWizardInfo["Address_2"] != null) ? Convert.ToString(drWizardInfo["Address_2"]) : "";
            txtCostCenterCity.Text = (drWizardInfo["City"] != null) ? Convert.ToString(drWizardInfo["City"]) : "";
            txtCostCenterState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drWizardInfo["State"])) ? Convert.ToDecimal(drWizardInfo["State"]) : 0).FLD_state;
            txtCostCenterZipCode.Text = (drWizardInfo["Zip_Code"] != null) ? Convert.ToString(drWizardInfo["Zip_Code"]) : "";
            #endregion

            //used to Disable all COntrols
            DisableEnableControls(false);
        }
    }

    /// <summary>
    /// Used to disable/Enabled Location panel Controls
    /// </summary>
    /// <param name="value"></param>
    public void DisableEnableControls(bool value)
    {
        ddlLocationNumber.Enabled = value;
        ddlLocationfka.Enabled = value;
        ddlLocationdba.Enabled = value;
        //ddlLegalEntity.Enabled = value;
        txtLocationAddress1.Enabled = value;
        txtLocationAddress2.Enabled = value;
        txtLocationCity.Enabled = value;
        txtLocationState.Enabled = value;
        txtLocationZipCode.Enabled = value;
        txtContactName.Enabled = value;
        txtContactTelephoneNumber1.Enabled = value;
        txtContactTelephoneNumber2.Enabled = value;
        txtContactEmailAddress.Enabled = value;
        txtCostCenterdba.Enabled = value;
        txtCostCenterAddress1.Enabled = value;
        txtCostCenterAddress2.Enabled = value;
        txtCostCenterCity.Enabled = value;
        txtCostCenterState.Enabled = value;
        txtCostCenterZipCode.Enabled = value;
    }

    /// <summary>
    /// Used to Update Location Information
    /// </summary>
    public void UpdateLocationInformation()
    {
        //Update Fax Number to First_Report_Wizard Table
        First_Report_Wizard objFRW = new First_Report_Wizard(First_Report_Wizard_ID);
        objFRW.Contact_Best_Time = txtContact_Best_Time.Text;
        objFRW.Contact_Fax = txtContactFaxNumber.Text;
        //Check First Report Wizard ID. if Greater than Zero than update data in First Report Wizard table.
        if (First_Report_Wizard_ID > 0)
        {
            //Update First Report Wizard table.
            objFRW.Update();
        }
    }

    #endregion

    #region Loss Information Panel Events

    /// <summary>
    /// Method to Update Loss information
    /// </summary>
    public void UpdateLossInformation()
    {
        //Create Object for AL_FR
        AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);

        //Set Values to Objects
        objAL_FR.Claimant_state = (ddlClaimant_state.SelectedIndex > 0) ? ddlClaimant_state.SelectedValue.ToString() : "0";
        objAL_FR.FK_LU_Auto_Liability_Type = (ddlAuto_Liability_Type.SelectedIndex > 0) ? ddlAuto_Liability_Type.SelectedValue.ToString() : "0";
        objAL_FR.Date_Of_Loss = clsGeneral.FormatDateToStore(txtDate_Of_Loss);
        objAL_FR.Time_Of_Loss = txtTime_Of_Loss.Text;
        objAL_FR.Loss_offsite = (rdoLoss_offsite.SelectedValue == "Y") ? true : false;
        //Check loss radio button's selcted value. if it is true display fields else hide the fields
        if (rdoLoss_offsite.SelectedValue == "Y")
        {
            hdnOnsiteOffsite.Value = "1";
            objAL_FR.Offsite_Address_1 = txtOffsite_Address1.Text;
            objAL_FR.Offsite_Address_2 = txtOffsite_Address2.Text;
            objAL_FR.Offsite_City = txtOffsite_City.Text;
            objAL_FR.Offsite_State = (ddlOffsite_State.SelectedIndex > 0) ? ddlOffsite_State.SelectedValue.ToString() : "0";
            objAL_FR.Offsite_zip = txtOffsite_zip.Text;
        }
        else
        {
            hdnOnsiteOffsite.Value = "0";
            objAL_FR.Offsite_Address_1 = "";
            objAL_FR.Offsite_Address_2 = "";
            objAL_FR.Offsite_City = "";
            objAL_FR.Offsite_State = "0";
            objAL_FR.Offsite_zip = "";
        }
        objAL_FR.Description_Of_Loss = txtDescription_Of_Loss.Text;
        objAL_FR.Date_Reported_To_Sonic = clsGeneral.FormatDateToStore(txtDate_Reported_To_Sonic);
        objAL_FR.Weather_Conditions = txtWeather_Conditions.Text;
        objAL_FR.Road_Conditions = txtRoad_Conditions.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoWere_Police_Notified.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false
            if (rdoWere_Police_Notified.SelectedValue == "Y")
                objAL_FR.Were_Police_Notified = true;
            else
                objAL_FR.Were_Police_Notified = false;
        }
        else
            objAL_FR.Were_Police_Notified = null;
        //Used to check selected value.according to answer display/Hide fields.
        if (rdoWere_Police_Notified.SelectedValue == "Y")
        {
            hdnPoliceNotify.Value = "1";
            objAL_FR.Police_Agency = txtPolice_Agency.Text;
            objAL_FR.Police_Case_Number = txtPolice_Case_Number.Text;
            objAL_FR.Police_Station_Phone_Number = txtPolice_Station_Phone_Number.Text;
        }
        else
        {
            hdnPoliceNotify.Value = "0";
            objAL_FR.Police_Agency = "";
            objAL_FR.Police_Case_Number = "";
            objAL_FR.Police_Station_Phone_Number = "";
        }
        //use to check selected value if it is "-1" than value set to null.
        if (rdoPedestrian_Involved.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoPedestrian_Involved.SelectedValue == "Y")
            {
                objAL_FR.Pedestrian_Involved = true;
            }
            else
            {
                objAL_FR.Pedestrian_Involved = false;
            }
        }
        else
            objAL_FR.Pedestrian_Involved = null;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoProperty_Damage.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoProperty_Damage.SelectedValue == "Y")
            {
                objAL_FR.Property_Damage = true;
            }
            else
            {
                objAL_FR.Property_Damage = false;
            }
        }
        else
            objAL_FR.Property_Damage = null;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoWitnesses.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoWitnesses.SelectedValue == "Y")
            {
                objAL_FR.Witnesses = true;
            }
            else
            {
                objAL_FR.Witnesses = false;
            }
        }
        else
            objAL_FR.Witnesses = null;


        if (rdoSecurityVideoSystem.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoSecurityVideoSystem.SelectedValue == "Y")
            {
                objAL_FR.Security_Video_System = true;
            }
            else
            {
                objAL_FR.Security_Video_System = false;
            }
        }
        else
            objAL_FR.Security_Video_System = null;

        //used to check PK id. if it greater than Zero. it updtae AL_FR table.
        if (PK_AL_FR_ID > 0)
        {
            objAL_FR.Update();
        }
    }

    #endregion

    #region Insured Vehicle Information Panel Events

    /// <summary>
    /// Method to Update Insured Vehicle Information
    /// </summary>
    public void UpdateInsuredVehicleInformation()
    {
        //Create Object
        AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);

        //Set values to AL_FR object
        objAL_FR.Vehicle_Sub_Type = (ddlVehicle_Sub_Type.SelectedIndex > 0) ? ddlVehicle_Sub_Type.SelectedValue.ToString() : "0";
        objAL_FR.Vehicle_Fleet_number = txtVehicle_Fleet_number.Text;
        objAL_FR.Year = (txtYear.Text != String.Empty) ? Convert.ToDecimal(txtYear.Text) : 0;
        objAL_FR.Make = txtMake.Text;
        objAL_FR.Model = txtModel.Text;
        objAL_FR.VIN = txtVIN.Text;
        objAL_FR.License_Plate_Number = txtLicense_Plate_Number.Text;
        objAL_FR.License_Plate_State = (ddlLicense_Plate_State.SelectedIndex > 0) ? ddlLicense_Plate_State.SelectedValue.ToString() : "0";
        objAL_FR.Vehicle_Color = txtVehicle_Color.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoPermissive_Use.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoPermissive_Use.SelectedValue == "Y")
                objAL_FR.Permissive_Use = true;
            else
                objAL_FR.Permissive_Use = false;
        }
        else
            objAL_FR.Permissive_Use = null;
        objAL_FR.Type_Of_Use = rdoType_Of_Use.SelectedValue.ToString();
        objAL_FR.Vehicle_Damage_Description = txtVehicle_Damage_Description.Text;
        objAL_FR.Repairs_Completed = (rdoRepairs_Completed.SelectedValue == "1") ? true : false;
        objAL_FR.Repairs_Estimated_Amount = txtRepairs_Estimated_Amount.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoDrivable.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoDrivable.SelectedValue == "Y")
                objAL_FR.Drivable = true;
            else
                objAL_FR.Drivable = false;
        }
        else
            objAL_FR.Drivable = null;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoPassengers.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoPassengers.SelectedValue == "Y")
                objAL_FR.Passengers = true;
            else
                objAL_FR.Passengers = false;
        }
        else
            objAL_FR.Passengers = null;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoInsured_Driver_At_Fault.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoInsured_Driver_At_Fault.SelectedValue == "Y")
                objAL_FR.Insured_Driver_At_Fault = true;
            else
                objAL_FR.Insured_Driver_At_Fault = false;
        }
        else
            objAL_FR.Insured_Driver_At_Fault = null;

        objAL_FR.Vehicle_Location = txtVehicle_Location.Text;
        objAL_FR.Vehicle_Location_Driver_Address_1 = txtVehicle_Location_Driver_Address_1.Text;
        objAL_FR.Vehicle_Location_Driver_Address_2 = txtVehicle_Location_Driver_Address_2.Text;
        objAL_FR.Vehicle_Location_Driver_City = txtVehicle_Location_Driver_City.Text;
        objAL_FR.Vehicle_Location_Driver_State = (ddlVehicle_Location_Driver_State.SelectedIndex > 0) ? Convert.ToDecimal(ddlVehicle_Location_Driver_State.SelectedValue) : 0;
        objAL_FR.Vehicle_Location_Driver_ZipCode = txtVehicle_Location_Driver_ZipCode.Text;
        objAL_FR.Owner_Name = txtOwner_Name.Text;
        objAL_FR.Owner_Work_Phone = txtOwner_Work_Phone.Text;
        objAL_FR.Owner_Home_Phone = txtOwner_Home_Phone.Text;
        objAL_FR.Owner_Alternate_Phone = txtOwner_Alternate_Phone.Text;
        objAL_FR.Owner_Address_1 = txtOwner_Address_1.Text;
        objAL_FR.Owner_Address_2 = txtOwner_Address_2.Text;
        objAL_FR.Owner_City = txtOwner_City.Text;
        objAL_FR.Owner_State = (ddlOwner_State.SelectedIndex > 0) ? ddlOwner_State.SelectedValue.ToString() : "0";
        objAL_FR.Owner_ZipCode = txtOwner_ZipCode.Text;
        //Used to check PK id. if it is greater than Zero than data updated in AL_FR table.
        if (PK_AL_FR_ID > 0)
        {
            objAL_FR.Update();
        }
    }

    #endregion

    #region Insured Vehicle Driver Information Panel Events

    /// <summary>
    /// Method to update Insured Vehicle Driver Information
    /// </summary>
    public void UpdateInsuredVehicleDriverInformation()
    {
        //set object
        AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);

        //set values to Object
        objAL_FR.Driver_Name = txtDriver_Name.Text;
        objAL_FR.Driver_SSN = txtDriver_SSN.Text;
        objAL_FR.Driver_Address_1 = txtDriver_Address1.Text;
        objAL_FR.Driver_Date_of_Birth = clsGeneral.FormatDateToStore(txtDriver_Date_of_Birth);
        objAL_FR.Driver_Address_2 = txtDriver_Address2.Text;
        objAL_FR.Driver_City = txtDriver_City.Text;
        objAL_FR.Driver_Work_Phone = txtDriver_Work_Phone.Text;
        objAL_FR.Driver_State = (ddlDriver_State.SelectedIndex > 0) ? ddlDriver_State.SelectedValue.ToString() : "0";
        objAL_FR.Driver_Home_Phone = txtDriver_Home_Phone.Text;
        objAL_FR.Driver_ZipCode = txtDriver_ZipCode.Text;
        objAL_FR.Driver_Altermate_Phone = txtDriver_Altermate_Phone.Text;
        objAL_FR.Driver_Drivers_License_State = (ddlDriver_Drivers_License_State.SelectedIndex > 0) ? ddlDriver_Drivers_License_State.SelectedValue.ToString() : "0";
        objAL_FR.Driver_Drivers_License_Number = txtDriver_Drivers_License_Number.Text;
        objAL_FR.Driver_Relation_to_Insured = txtDriver_Relation_to_Insured.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoCitation_Issued.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoCitation_Issued.SelectedValue == "Y")
                objAL_FR.Citation_Issued = true;
            else
                objAL_FR.Citation_Issued = false;
        }
        else
            objAL_FR.Citation_Issued = null;
        objAL_FR.Citation_Number = txtCitation_Number.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoDriver_Was_Injured.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoDriver_Was_Injured.SelectedValue == "Y")
                objAL_FR.Driver_Was_Injured = true;
            else
                objAL_FR.Driver_Was_Injured = false;
        }
        else
            objAL_FR.Driver_Was_Injured = null;
        objAL_FR.Driver_Injury_Description = txtDriver_Injury_Description.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoDriver_Sought_Medical_Attention.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoDriver_Sought_Medical_Attention.SelectedValue == "Y")
                objAL_FR.Driver_Sought_Medical_Attention = true;
            else
                objAL_FR.Driver_Sought_Medical_Attention = false;
        }
        else
            objAL_FR.Driver_Sought_Medical_Attention = null;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoDriver_Is_Owner.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoDriver_Is_Owner.SelectedValue == "Y")
                objAL_FR.Driver_Is_Owner = true;
            else
                objAL_FR.Driver_Is_Owner = false;
        }
        else
            objAL_FR.Driver_Is_Owner = null;
        //Used to check selected value.
        if (rdoDriver_Taken_By_Emergency_Transportation.SelectedValue == "Y")
            objAL_FR.Driver_Taken_By_Emergency_Transportation = true;
        else
            objAL_FR.Driver_Taken_By_Emergency_Transportation = false;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoDriver_Airlifted_Medivac.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoDriver_Airlifted_Medivac.SelectedValue == "Y")
                objAL_FR.Driver_Airlifted_Medivac = true;
            else
                objAL_FR.Driver_Airlifted_Medivac = false;
        }
        else
            objAL_FR.Driver_Airlifted_Medivac = null;
        objAL_FR.Driver_Medical_Facility_Name = txtDriver_Medical_Facility_Name.Text;
        objAL_FR.Driver_Date_Of_Initial_Treatment = clsGeneral.FormatDateToStore(txtDriver_Date_Of_Initial_Treatment);
        objAL_FR.Driver_Medical_Facility_Type = txtDriver_Medical_Facility_Type.Text;
        objAL_FR.Driver_Treating_Physician_Name = txtDriver_Treating_Physician_Name.Text;
        objAL_FR.Driver_Medical_Facility_Address_1 = txtDriver_Medical_Facility_Address_1.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoDriver_Admitted_to_Hospital.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoDriver_Admitted_to_Hospital.SelectedValue == "Y")
                objAL_FR.Driver_Admitted_to_Hospital = true;
            else
                objAL_FR.Driver_Admitted_to_Hospital = false;
        }
        else
            objAL_FR.Driver_Admitted_to_Hospital = null;
        objAL_FR.Driver_Medical_Facility_Address_2 = txtDriver_Medical_Facility_Address_2.Text;
        objAL_FR.Driver_Medical_Facility_City = txtDriver_Medical_Facility_City.Text;
        objAL_FR.Driver_Medical_Facility_State = (ddlDriver_Medical_Facility_State.SelectedIndex > 0) ? ddlDriver_Medical_Facility_State.SelectedValue.ToString() : "0";
        objAL_FR.Driver_Medical_Facility_ZipCode = txtDriver_Medical_Facility_Zip_Code.Text;
        //Used to check selected value.
        if (rdoDriver_Admitted_to_Hospital.SelectedValue == "Y")
        {
            hdnDriver_Admitted_to_Hospital.Value = "1";
            objAL_FR.Driver_Date_Admitted_to_Hospital = clsGeneral.FormatDateToStore(txtDriver_Date_Admitted_to_Hospital.Text);
            //use to check selected value if it is "-1" than value set to null.
            if (rdoDriver_Still_in_Hospital.SelectedValue != "-1")
            {
                //use to check selected value if it is "Y" than set true else false.
                if (rdoDriver_Still_in_Hospital.SelectedValue == "Y")
                    objAL_FR.Driver_Still_in_Hospital = true;
                else
                    objAL_FR.Driver_Still_in_Hospital = false;
            }
            else
                objAL_FR.Driver_Still_in_Hospital = null;
        }
        else
        {
            hdnDriver_Admitted_to_Hospital.Value = "0";
            objAL_FR.Driver_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            objAL_FR.Driver_Still_in_Hospital = null;
        }
        //Used to check PK id.if greater than ZERO, update data into AL_FR table
        if (PK_AL_FR_ID > 0)
        {
            objAL_FR.Update();
        }
    }
    #endregion

    #region Insured Vehicle Passenger Information Panel Events

    /// <summary>
    /// Method to update Unsured vehicle Passenger details
    /// </summary>
    public void UpdateInsuredVehiclePassengerInformation()
    {
        //Create Object
        AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);

        //Set Values to Created Object
        objAL_FR.Passenger_Name = txtPassenger_Name.Text;
        objAL_FR.Passenger_Address_1 = txtPassenger_Address_1.Text;
        objAL_FR.Passenger_Date_of_Birth = clsGeneral.FormatDateToStore(txtPassenger_Date_of_Birth.Text);
        objAL_FR.Passenger_Address_2 = txtPassenger_Address_2.Text;
        objAL_FR.Passenger_City = txtPassenger_City.Text;
        objAL_FR.Passenger_Work_Phone = txtPassenger_Work_Phone.Text;
        objAL_FR.Passenger_State = (ddlPassenger_State.SelectedIndex > 0) ? ddlPassenger_State.SelectedValue.ToString() : "0";
        objAL_FR.Passenger_Home_Phone = txtPassenger_Home_Phone.Text;
        objAL_FR.Passenger_ZipCode = txtPassenger_ZipCode.Text;
        objAL_FR.Passenger_Alternate_Phone = txtPassenger_Alternate_Phone.Text;
        objAL_FR.Passenger_Drivers_License_State = (ddlPassenger_Drivers_License_State.SelectedIndex > 0) ? ddlPassenger_Drivers_License_State.SelectedValue.ToString() : "0";
        objAL_FR.Passenger_Drivers_License_Number = txtPassenger_Drivers_License_Number.Text;
        objAL_FR.Passenger_Relation_to_Insured = txtPassenger_Relation_to_Insured.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoPassenger_Was_Injured.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoPassenger_Was_Injured.SelectedValue == "Y")
                objAL_FR.Passenger_Was_Injured = true;
            else
                objAL_FR.Passenger_Was_Injured = false;
        }
        else
            objAL_FR.Passenger_Was_Injured = null;
        objAL_FR.Passenger_Description_of_Injury = txtPassenger_Description_of_Injury.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoPassenger_Sought_Medical_Attention.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoPassenger_Sought_Medical_Attention.SelectedValue == "Y")
                objAL_FR.Passenger_Sought_Medical_Attention = true;
            else
                objAL_FR.Passenger_Sought_Medical_Attention = false;
        }
        else
            objAL_FR.Passenger_Sought_Medical_Attention = null;
        //check PK id. if greater than 0 than update record into AL_FR table
        if (PK_AL_FR_ID > 0)
        {
            objAL_FR.Update();
        }
    }
    #endregion

    #region Other Vehicle Information Panel Events

    /// <summary>
    /// Mthod to update Other Vehicle Information
    /// </summary>
    public void UpdateOtherVehicleInformation()
    {
        // create Object
        AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);

        //set values to object
        objAL_FR.Other_Vehicle_Year = (txtOther_Vehicle_Year.Text != String.Empty) ? Convert.ToDecimal(txtOther_Vehicle_Year.Text) : 0;
        objAL_FR.Other_Vehicle_Make = txtOther_Vehicle_Make.Text;
        objAL_FR.Other_Vehicle_Model = txtOther_Vehicle_Model.Text;
        objAL_FR.Other_Vehicle_VIN = txtOther_Vehicle_VIN.Text;
        objAL_FR.Other_Vehicle_License_Plate_Number = txtOther_Vehicle_License_Plate_Number.Text;
        objAL_FR.Other_Vehicle_License_Plate_State = (ddlOther_Vehicle_License_Plate_State.SelectedIndex > 0) ? ddlOther_Vehicle_License_Plate_State.SelectedValue.ToString() : "0";
        objAL_FR.Other_Vehicle_Vehicle_Color = txtOther_Vehicle_Vehicle_Color.Text;
        objAL_FR.Other_Vehicle_Insurance_Co_Name = txtOther_Vehicle_Insurance_Co_Name.Text;
        objAL_FR.Other_Vehicle_Insurance_Co_Phone = txtOther_Vehicle_Insurance_Co_Phone.Text;
        objAL_FR.Passenger_Description_of_Injury = txtPassenger_Description_of_Injury.Text;
        objAL_FR.Other_Vehicle_Insurance_Policy_Number = txtOther_Vehicle_Insurance_Policy_Number.Text;
        objAL_FR.Other_Vehicle_Vehicle_Damage_Description = txtOther_Vehicle_Vehicle_Damage_Description.Text;
        objAL_FR.Other_Vehicle_Repairs_Completed = (rdoOther_Vehicle_Repairs_Completed.SelectedValue == "Y") ? true : false;
        objAL_FR.Other_Vehicle_Repairs_Estimated_Amount = txtOther_Vehicle_Repairs_Estimated_Amount.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoOther_Vehicle_Drivable.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoOther_Vehicle_Drivable.SelectedValue == "Y")
                objAL_FR.Other_Vehicle_Drivable = true;
            else
                objAL_FR.Other_Vehicle_Drivable = false;
        }
        else
            objAL_FR.Other_Vehicle_Drivable = null;
        objAL_FR.Other_Vehicle_Location = txtOther_Vehicle_Location.Text;
        objAL_FR.Other_Vehicle_Location_Telephone = txtOther_Vehicle_Location_Telephone.Text;
        objAL_FR.Other_Vehicle_Location_Driver_Address_1 = txtOther_Vehicle_Location_Driver_Address_1.Text;
        objAL_FR.Other_Vehicle_Location_Driver_Address_2 = txtOther_Vehicle_Location_Driver_Address_2.Text;
        objAL_FR.Other_Vehicle_Location_Driver_City = txtOther_Vehicle_Location_Driver_City.Text;
        objAL_FR.Other_Vehicle_Location_Driver_State = (ddlOther_Vehicle_Location_Driver_State.SelectedIndex > 0) ? ddlOther_Vehicle_Location_Driver_State.SelectedValue.ToString() : "0";
        objAL_FR.Other_Vehicle_Location_Driver_ZipCode = txtOther_Vehicle_Location_Driver_ZipCode.Text;
        objAL_FR.Other_Vehicle_Owner_Name = txtOther_Vehicle_Owner_Name.Text;
        objAL_FR.Other_Vehicle_Owner_Work_Phone = txtOther_Vehicle_Owner_Work_Phone.Text;
        objAL_FR.Other_Vehicle_Owner_Home_Phone = txtOther_Vehicle_Owner_Home_Phone.Text;
        objAL_FR.Other_Vehicle_Owner_Alternate_Phone = txtOther_Vehicle_Owner_Alternate_Phone.Text;
        objAL_FR.Other_Vehicle_Owner_Address_1 = txtOther_Vehicle_Owner_Address_1.Text;
        objAL_FR.Other_Vehicle_Owner_Address_2 = txtOther_Vehicle_Owner_Address_2.Text;
        objAL_FR.Other_Vehicle_Owner_City = txtOther_Vehicle_Owner_City.Text;
        objAL_FR.Other_Vehicle_Owner_State = (ddlOther_Vehicle_Owner_State.SelectedIndex > 0) ? ddlOther_Vehicle_Owner_State.SelectedValue.ToString() : "0";
        objAL_FR.Other_Vehicle_Owner_ZipCode = txtOther_Vehicle_Owner_ZipCode.Text;
        //used to check PK id. if greater than 0.update AL_FR table.
        if (PK_AL_FR_ID > 0)
        {
            objAL_FR.Update();
        }
    }
    #endregion

    #region  Other Vehicle Driver Information Panel Events

    /// <summary>
    /// Method to updates Other Driver Information
    /// </summary>
    public void UpdateOtherDriverInformation()
    {
        // set object
        AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);

        // Set Values to Object
        objAL_FR.Other_Driver_Name = txtOther_Driver_Name.Text;
        objAL_FR.Other_Driver_SSN = txtOther_Driver_SSN.Text;
        objAL_FR.Other_Driver_Address_1 = txtOther_Driver_Address_1.Text;
        objAL_FR.Other_Driver_Date_of_Birth = clsGeneral.FormatDateToStore(txtOther_Driver_Date_of_Birth);
        objAL_FR.Other_Driver_Address_2 = txtOther_Driver_Address_2.Text;
        objAL_FR.Other_Driver_City = txtOther_Driver_City.Text;
        objAL_FR.Other_Driver_State = (ddlOther_Driver_State.SelectedIndex > 0) ? ddlOther_Driver_State.SelectedValue.ToString() : "0";
        objAL_FR.Other_Driver_Home_Phone = txtOther_Driver_Home_Phone.Text;
        objAL_FR.Other_Driver_Work_Phone = txtOther_Driver_Work_Phone.Text;
        objAL_FR.Other_Driver_ZipCode = txtOther_Driver_ZipCode.Text;
        objAL_FR.Other_Driver_Drivers_License_Number = txtOther_Driver_Drivers_License_Number.Text;
        objAL_FR.Other_Driver_Gender = txtOther_Driver_Gender.Text;
        objAL_FR.Other_Driver_Drivers_License_State = (ddlOther_Driver_Drivers_License_State.SelectedIndex > 0) ? ddlOther_Driver_Drivers_License_State.SelectedValue.ToString() : "0";
        //use to check selected value if it is "-1" than value set to null.
        if (rdoOther_Driver_Citation_Issued.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoOther_Driver_Citation_Issued.SelectedValue == "Y")
                objAL_FR.Other_Driver_Citation_Issued = true;
            else
                objAL_FR.Other_Driver_Citation_Issued = false;
        }
        else
            objAL_FR.Other_Driver_Citation_Issued = null;
        objAL_FR.Other_Driver_Citation_Number = txtOther_Driver_Citation_Number.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoOther_Driver_Injured.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoOther_Driver_Injured.SelectedValue == "Y")
                objAL_FR.Other_Driver_Injured = true;
            else
                objAL_FR.Other_Driver_Injured = false;
        }
        else
            objAL_FR.Other_Driver_Injured = null;
        objAL_FR.Other_Driver_Injury_Description = txtOther_Driver_Injury_Description.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoOther_Driver_Sought_Medical_Attention.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoOther_Driver_Sought_Medical_Attention.SelectedValue == "Y")
                objAL_FR.Other_Driver_Sought_Medical_Attention = true;
            else
                objAL_FR.Other_Driver_Sought_Medical_Attention = false;
        }
        else
            objAL_FR.Other_Driver_Sought_Medical_Attention = null;
        objAL_FR.Other_Driver_Taken_By_Emergency_Transportation = (rdoOther_Driver_Taken_By_Emergency_Transportation.SelectedValue == "Y") ? true : false;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoOther_Driver_Airlifted_Medivac.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoOther_Driver_Airlifted_Medivac.SelectedValue == "Y")
                objAL_FR.Other_Driver_Airlifted_Medivac = true;
            else
                objAL_FR.Other_Driver_Airlifted_Medivac = false;
        }
        else
            objAL_FR.Other_Driver_Airlifted_Medivac = null;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoOther_Driver_Admitted_to_Hospital.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoOther_Driver_Admitted_to_Hospital.SelectedValue == "Y")
                objAL_FR.Other_Driver_Admitted_to_Hospital = true;
            else
                objAL_FR.Other_Driver_Admitted_to_Hospital = false;
        }
        else
            objAL_FR.Other_Driver_Admitted_to_Hospital = null;
        objAL_FR.Other_Driver_Medical_Facility_Name = txtOther_Driver_Medical_Facility_Name.Text;
        objAL_FR.Other_Driver_Medical_Facility_Address_1 = txtOther_Driver_Medical_Facility_Address_1.Text;
        objAL_FR.Other_Driver_Medical_Facility_Address_2 = txtOther_Driver_Medical_Facility_Address_2.Text;
        //Used to check selected value.
        if (rdoOther_Driver_Admitted_to_Hospital.SelectedValue == "Y")
        {
            hdnOVDriver.Value = "1";
            objAL_FR.Other_Driver_Date_Admitted_to_Hospital = clsGeneral.FormatDateToStore(txtOther_Driver_Date_Admitted_to_Hospital);
            //use to check selected value if it is "-1" than value set to null.
            if (rdoOther_Driver_Still_in_Hospital.SelectedValue != "-1")
            {
                //use to check selected value if it is "Y" than set true else false.
                if (rdoOther_Driver_Still_in_Hospital.SelectedValue == "Y")
                    objAL_FR.Other_Driver_Still_in_Hospital = true;
                else
                    objAL_FR.Other_Driver_Still_in_Hospital = false;
            }
            else
                objAL_FR.Other_Driver_Still_in_Hospital = null;
        }
        else
        {
            hdnOVDriver.Value = "0";
            objAL_FR.Other_Driver_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            objAL_FR.Other_Driver_Still_in_Hospital = null;
        }
        objAL_FR.Other_Driver_Medical_Facility_City = txtOther_Driver_Medical_Facility_City.Text;
        objAL_FR.Other_Driver_Physicians_Name = txtOther_Driver_Physicians_Name.Text;
        objAL_FR.Other_Driver_Medical_Facility_State = (ddlOther_Driver_Medical_Facility_State.SelectedIndex > 0) ? ddlOther_Driver_Medical_Facility_State.SelectedValue.ToString() : "0";
        objAL_FR.Other_Driver_Medical_Facility_Zip_Code = txtOther_Driver_Medical_Facility_Zip_Code.Text;
        objAL_FR.Other_Driver_Medical_Facility_Type = txtOther_Driver_Medical_Facility_Type.Text;
        //Used to check PK id. if greater than 0. Update AL_FR table.
        if (PK_AL_FR_ID > 0)
        {
            objAL_FR.Update();
        }
    }
    #endregion

    #region Other Vehicle Passenger Information Panel Events

    /// <summary>
    /// Method to update Other Vehicle Passenger info
    /// </summary>
    public void UpdateOtherVehiclePassengerInformation()
    {
        // set object
        AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);

        // Set Values to Object
        objAL_FR.Oth_Veh_Pass_Name = txtOth_Veh_Pass_Name.Text;
        objAL_FR.Oth_Veh_Pass_Date_of_Birth = clsGeneral.FormatDateToStore(txtOth_Veh_Pass_Date_of_Birth);
        objAL_FR.Oth_Veh_Pass_Address_1 = txtOth_Veh_Pass_Address_1.Text;
        objAL_FR.Oth_Veh_Pass_Address_2 = txtOth_Veh_Pass_Address_2.Text;
        objAL_FR.Oth_Veh_Pass_City = txtOth_Veh_Pass_City.Text;
        objAL_FR.Oth_Veh_Pass_State = (ddlOth_Veh_Pass_State.SelectedIndex > 0) ? ddlOth_Veh_Pass_State.SelectedValue.ToString() : "0";
        objAL_FR.Oth_Veh_Pass_Home_Phone = txtOth_Veh_Pass_Home_Phone.Text;
        objAL_FR.Oth_Veh_Pass_Work_Phone = txtOth_Veh_Pass_Work_Phone.Text;
        objAL_FR.Oth_Veh_Pass_Alternate_Phone = txtOth_Veh_Pass_Alternate_Phone.Text;
        objAL_FR.Oth_Veh_Pass_ZipCode = txtOth_Veh_Pass_ZipCode.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoOth_Veh_Pass_Injured.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoOth_Veh_Pass_Injured.SelectedValue == "Y")
                objAL_FR.Oth_Veh_Pass_Injured = true;
            else
                objAL_FR.Oth_Veh_Pass_Injured = false;
        }
        else
            objAL_FR.Oth_Veh_Pass_Injured = null;
        objAL_FR.Oth_Veh_Pass_Injury_Description = txtOth_Veh_Pass_Injury_Description.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoOth_Veh_Pass_Sought_Medical_Attention.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoOth_Veh_Pass_Sought_Medical_Attention.SelectedValue == "Y")
                objAL_FR.Oth_Veh_Pass_Sought_Medical_Attention = true;
            else
                objAL_FR.Oth_Veh_Pass_Sought_Medical_Attention = false;
        }
        else
            objAL_FR.Oth_Veh_Pass_Sought_Medical_Attention = null;
        objAL_FR.Oth_Veh_Pass_Taken_By_Emergency_Transportation = (rdoOth_Veh_Pass_Taken_By_Emergency_Transportation.SelectedValue == "Y") ? true : false;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoOth_Veh_Pass_Airlifted_Medivac.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoOth_Veh_Pass_Airlifted_Medivac.SelectedValue == "Y")
                objAL_FR.Oth_Veh_Pass_Airlifted_Medivac = true;
            else
                objAL_FR.Oth_Veh_Pass_Airlifted_Medivac = false;
        }
        else
            objAL_FR.Oth_Veh_Pass_Airlifted_Medivac = null;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoOth_Veh_Pass_Admitted_to_Hospital.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoOth_Veh_Pass_Admitted_to_Hospital.SelectedValue == "Y")
                objAL_FR.Oth_Veh_Pass_Admitted_to_Hospital = true;
            else
                objAL_FR.Oth_Veh_Pass_Admitted_to_Hospital = false;
        }
        else
            objAL_FR.Oth_Veh_Pass_Admitted_to_Hospital = null;
        objAL_FR.Oth_Veh_Pass_Medical_Facility_Name = txtOth_Veh_Pass_Medical_Facility_Name.Text;
        objAL_FR.Oth_Veh_Pass_Medical_Facility_Address_1 = txtOth_Veh_Pass_Medical_Facility_Address_1.Text;
        objAL_FR.Oth_Veh_Pass_Medical_Facility_Address_2 = txtOth_Veh_Pass_Medical_Facility_Address_2.Text;
        if (rdoOth_Veh_Pass_Admitted_to_Hospital.SelectedValue == "Y")
        {
            hdnOthVehPass.Value = "1";
            objAL_FR.Oth_Veh_Pass_Date_Admitted_to_Hospital = clsGeneral.FormatDateToStore(txtOth_Veh_Pass_Date_Admitted_to_Hospital);
            //use to check selected value if it is "-1" than value set to null.
            if (rdoOth_Veh_Pass_Still_in_Hospital.SelectedValue != "-1")
            {
                //use to check selected value if it is "Y" than set true else false.
                if (rdoOth_Veh_Pass_Still_in_Hospital.SelectedValue == "Y")
                    objAL_FR.Oth_Veh_Pass_Still_in_Hospital = true;
                else
                    objAL_FR.Oth_Veh_Pass_Still_in_Hospital = false;
            }
            else
                objAL_FR.Oth_Veh_Pass_Still_in_Hospital = null;
        }
        else
        {
            hdnOthVehPass.Value = "0";
            objAL_FR.Oth_Veh_Pass_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            objAL_FR.Oth_Veh_Pass_Still_in_Hospital = null;
        }
        objAL_FR.Oth_Veh_Pass_Medical_Facility_City = txtOth_Veh_Pass_Medical_Facility_City.Text;
        objAL_FR.Oth_Veh_Pass_Physicians_Name = txtOth_Veh_Pass_Physicians_Name.Text;
        objAL_FR.Oth_Veh_Pass_Medical_Facility_State = (ddlOth_Veh_Pass_Medical_Facility_State.SelectedIndex > 0) ? Convert.ToDecimal(ddlOth_Veh_Pass_Medical_Facility_State.SelectedValue) : 0;
        objAL_FR.Oth_Veh_Pass_Medical_Facility_ZipCode = txtOth_Veh_Pass_Medical_Facility_Zip_Code.Text;
        objAL_FR.Oth_Veh_Pass_Medical_Facility_Type = txtOth_Veh_Pass_Medical_Facility_Type.Text;
        //used to update PK id. if greater than 0, update AL_FR table
        if (PK_AL_FR_ID > 0)
        {
            objAL_FR.Update();
        }
    }
    #endregion

    #region Pedestrian Information Panel Events

    /// <summary>
    /// Method to update Pedestrian info
    /// </summary>
    public void UpdatePedestrianInformation()
    {
        // set object
        AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);

        // Set Values to Object
        objAL_FR.Pedestrian_Name = txtPedestrian_Name.Text;
        objAL_FR.Pedestrian_Date_of_Birth = clsGeneral.FormatDateToStore(txtPedestrian_Date_of_Birth);
        objAL_FR.Pedestrian_Address_1 = txtPedestrian_Address_1.Text;
        objAL_FR.Pedestrian_Address_2 = txtPedestrian_Address_2.Text;
        objAL_FR.Pedestrian_City = txtPedestrian_City.Text;
        objAL_FR.Pedestrian_State = (ddlPedestrian_State.SelectedIndex > 0) ? ddlPedestrian_State.SelectedValue.ToString() : "0";
        objAL_FR.Pedestrian_Home_Phone = txtPedestrian_Home_Phone.Text;
        objAL_FR.Pedestrian_Work_Phone = txtPedestrian_Work_Phone.Text;
        objAL_FR.Pedestrian_Alternate_Phone = txtPedestrian_Alternate_Phone.Text;
        objAL_FR.Pedestrian_ZipCode = txtPedestrian_ZipCode.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoPedestrian_Injured.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoPedestrian_Injured.SelectedValue == "Y")
                objAL_FR.Pedestrian_Injured = true;
            else
                objAL_FR.Pedestrian_Injured = false;
        }
        else
            objAL_FR.Pedestrian_Injured = null;
        objAL_FR.Pedestrian_Injury_Description = txtPedestrian_Injury_Description.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoPedestrian_Sought_Medical_Attention.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoPedestrian_Sought_Medical_Attention.SelectedValue == "Y")
                objAL_FR.Pedestrian_Sought_Medical_Attention = true;
            else
                objAL_FR.Pedestrian_Sought_Medical_Attention = false;
        }
        else
            objAL_FR.Pedestrian_Sought_Medical_Attention = null;
        objAL_FR.Pedestrian_Taken_By_Emergency_Transportation = (rdoPedestrian_Taken_By_Emergency_Transportation.SelectedValue == "Y") ? true : false;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoPedestrian_Airlifted_Medivac.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoPedestrian_Airlifted_Medivac.SelectedValue == "Y")
                objAL_FR.Pedestrian_Airlifted_Medivac = true;
            else
                objAL_FR.Pedestrian_Airlifted_Medivac = false;
        }
        else
            objAL_FR.Pedestrian_Airlifted_Medivac = null;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoPedestrian_Admitted_to_Hospital.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false.
            if (rdoPedestrian_Admitted_to_Hospital.SelectedValue == "Y")
                objAL_FR.Pedestrian_Admitted_to_Hospital = true;
            else
                objAL_FR.Pedestrian_Admitted_to_Hospital = false;
        }
        else
            objAL_FR.Pedestrian_Admitted_to_Hospital = null;
        objAL_FR.Pedestrian_Medical_Facility_Name = txtPedestrian_Medical_Facility_Name.Text;
        objAL_FR.Pedestrian_Medical_Facility_Address_1 = txtPedestrian_Medical_Facility_Address_1.Text;
        objAL_FR.Pedestrian_Medical_Facility_Address_2 = txtPedestrian_Medical_Facility_Address_2.Text;
        if (rdoPedestrian_Admitted_to_Hospital.SelectedValue == "Y")
        {
            hdnPedestrian.Value = "1";
            objAL_FR.Pedestrian_Date_Admitted_to_Hospital = clsGeneral.FormatDateToStore(txtPedestrian_Date_Admitted_to_Hospital);
            //use to check selected value if it is "-1" than value set to null.
            if (rdoPedestrian_Still_in_Hospital.SelectedValue != "-1")
            {
                //use to check selected value if it is "Y" than set true else false.
                if (rdoPedestrian_Still_in_Hospital.SelectedValue == "Y")
                    objAL_FR.Pedestrian_Still_in_Hospital = true;
                else
                    objAL_FR.Pedestrian_Still_in_Hospital = false;
            }
            else
                objAL_FR.Pedestrian_Still_in_Hospital = null;
        }
        else
        {
            hdnPedestrian.Value = "0";
            objAL_FR.Pedestrian_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            objAL_FR.Pedestrian_Still_in_Hospital = null;
        }
        objAL_FR.Pedestrian_Medical_Facility_City = txtPedestrian_Medical_Facility_City.Text;
        objAL_FR.Pedestrian_Physicians_Name = txtPedestrian_Physicians_Name.Text;
        objAL_FR.Pedestrian_Medical_Facility_State = (ddlPedestrian_Medical_Facility_State.SelectedIndex > 0) ? ddlPedestrian_Medical_Facility_State.SelectedValue.ToString() : "0";
        objAL_FR.Pedestrian_Medical_Facility_Zip_Code = txtPedestrian_Medical_Facility_Zip_Code.Text;
        objAL_FR.Pedestrian_Medical_Facility_Type = txtPedestrian_Medical_Facility_Type.Text;
        //used to check PK id.if greater than 0,update AL_FR table
        if (PK_AL_FR_ID > 0)
        {
            objAL_FR.Update();
        }
    }
    #endregion

    #region Witness Information Panel Events

    /// <summary>
    /// Method to update Witness info
    /// </summary>
    public void UpdateWitnessInformation()
    {
        // create Object
        AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);

        // set Vallue to Object
        objAL_FR.Witness_Name = txtWitness_Name.Text;
        objAL_FR.Witness_Address_1 = txtWitness_Address_1.Text;
        objAL_FR.Witness_Address_2 = txtWitness_Address_2.Text;
        objAL_FR.Witness_City = txtWitness_City.Text;
        objAL_FR.Witness_State = (ddlWitness_State.SelectedIndex > 0) ? ddlWitness_State.SelectedValue.ToString() : "0";
        objAL_FR.Witness_ZipCode = txtWitness_Zip_Code.Text;
        objAL_FR.Witness_Home_Phone = txtWitness_Home_Phone.Text;
        objAL_FR.Witness_Work_Phone = txtWitness_Work_Phone.Text;
        objAL_FR.Witness_Alternate_Phone = txtWitness_Alternate_Phone.Text;
        //used to check PK id.if greater than 0. update AL_FR table.
        if (PK_AL_FR_ID > 0)
        {
            objAL_FR.Update();
        }

    }
    #endregion

    #region Submit Button Event

    /// <summary>
    /// Used to check Page Operation and accrofing to that Send a Email and update Information in AL_FR table
    /// </summary>
    /// <returns></returns>
    public int ComplateAL_FRReport(bool _IsAttachment)
    {
        //check Page Opertain Mode
        if (strPageOpeMode == "edit")
        {
            //if (hdnLoss.Value == "1" && hdnInsured.Value == "1" && hdnOther.Value == "1")
            //{
            if (_IsAttachment)
            {
                Upload_File("");
                CtrlAttachDetails.Bind();
                decimal FileSize = this.CtrlAttachDetails.GetTotalAttachmentsFileSize();
                if (FileSize > 9.5M)
                {
                    String confirmMessage = "The attachments to this First Report exceed the size limitations for e-mail. The First Report can be sent without the attachments or you can Cancel and remove or reduce the size of the exiting attachments. Do you want to send the First Report without the attachments?";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", " if(window.confirm('" + confirmMessage + "')){ __doPostBack('UserConfirmationPostBack', 'true');} else { alert('The First Report has NOT been sent, please reduce the number and/or size of the attachments before attempting to resubmit with attachments.');ShowPanel(11); }", true);
                    return 0;
                }
            }
            // Declare Object
            AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);

            if (objAL_FR.Complete)
                return -1;

            //Assign Values
            objAL_FR.Comments = txtComments.Text;
            objAL_FR.Complete = true;
            //Update Values
            if (PK_AL_FR_ID > 0)
            {
                objAL_FR.Update();
            }

            SendFROI();

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
            //else
            //{
            //    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "alert('Any of the Panel marked with an asterisk is not saved! Please save all panels marked with an asterisk.');", true);
            //    return 0;
            //}
        }
        else
        {
            return 0;
        }

    }

    #endregion

    #region Bind Page in View MOde
    /// <summary>
    /// used to Bind Page in View MOde
    /// </summary>
    public void BindPageinViewMode()
    {
        //Check First Report Wizard ID. if Greater than Zero than update data in First Report Wizard table.
        if (First_Report_Wizard_ID > 0)
        {
            //Hide Message of "This Report Has not been submitted"
            lblSubmitMessage.Text = "";
            //Declare Object of WC_FR table
            AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);

            #region Location/Contact Information
            DataSet dsWizardInfo = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.AL_FR, PK_AL_FR_ID);
            DataTable dtWizardInfo = dsWizardInfo.Tables[0];
            DataRow drWizardInfo = dtWizardInfo.Rows[0];

            #region Fill Location Information Controls
            //select value from Location Number
            if (drWizardInfo["sonic_location_code"] != null)
                lblLocationNumber.Text = drWizardInfo["sonic_location_code"].ToString();
            else
                lblLocationNumber.Text = "";

            //select value from Location d/b/a
            if (drWizardInfo["dba"] != null)
                lblLocationdba.Text = drWizardInfo["dba"].ToString();
            else
                lblLocationdba.Text = "";

            //select value from Location f/k/a
            if (drWizardInfo["FK_Location_ID"] != null)
                lblLocationfka.Text = new LU_Location_FKA(Convert.ToDecimal(drWizardInfo["FK_Location_ID"])).fka;
            else
                lblLocationfka.Text = "";

            //select value from Location Legal Entity
            //if (drWizardInfo["legal_entity"] != null)
            //    lblLegalEntity.Text = drWizardInfo["legal_entity"].ToString();
            //else
            //    lblLegalEntity.Text = "";

            //set address1,address2,city,state,ZipCOde Values
            lblLocationAddress1.Text = (drWizardInfo["Address_1"] != null) ? Convert.ToString(drWizardInfo["Address_1"]) : "";
            lblLocationAddress2.Text = (drWizardInfo["Address_2"] != null) ? Convert.ToString(drWizardInfo["Address_2"]) : "";
            lblLocationCity.Text = (drWizardInfo["City"] != null) ? Convert.ToString(drWizardInfo["City"]) : "";
            lblLocationState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drWizardInfo["State"])) ? Convert.ToDecimal(drWizardInfo["State"]) : 0).FLD_state;
            lblLocationZipCode.Text = (drWizardInfo["Zip_Code"] != null) ? Convert.ToString(drWizardInfo["Zip_Code"]) : "";

            #endregion

            #region Fill Contact Information Controls

            lblContactName.Text = (drWizardInfo["EmployeeName"] != null) ? Convert.ToString(drWizardInfo["EmployeeName"]) : "";
            lblContact_Best_Time.Text = (drWizardInfo["Contact_Best_Time"] != null) ? Convert.ToString(drWizardInfo["Contact_Best_Time"]) : "";
            lblContactTelephoneNumber1.Text = (drWizardInfo["TelephoneNumber1"] != null) ? Convert.ToString(drWizardInfo["TelephoneNumber1"]) : "";
            lblContactTelephoneNumber2.Text = (drWizardInfo["TelephoneNumber2"] != null) ? Convert.ToString(drWizardInfo["TelephoneNumber2"]) : "";
            lblContactFaxNumber.Text = (drWizardInfo["Contact_Fax"] != null) ? Convert.ToString(drWizardInfo["Contact_Fax"]) : "";
            lblContactEmailAddress.Text = (drWizardInfo["FRWEmail"] != null) ? Convert.ToString(drWizardInfo["FRWEmail"]) : "";
            //fill Controls By Cost Center Value
            lblCostCenterdba.Text = (drWizardInfo["dba"] != null) ? Convert.ToString(drWizardInfo["dba"]) : "";
            lblCostCenterAddress1.Text = (drWizardInfo["Address_1"] != null) ? Convert.ToString(drWizardInfo["Address_1"]) : "";
            lblCostCenterAddress2.Text = (drWizardInfo["Address_2"] != null) ? Convert.ToString(drWizardInfo["Address_2"]) : "";
            lblCostCenterCity.Text = (drWizardInfo["City"] != null) ? Convert.ToString(drWizardInfo["City"]) : "";
            lblCostCenterState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drWizardInfo["State"])) ? Convert.ToDecimal(drWizardInfo["State"]) : 0).FLD_state;
            lblCostCenterZipCode.Text = (drWizardInfo["Zip_Code"] != null) ? Convert.ToString(drWizardInfo["Zip_Code"]) : "";
            #endregion

            //used to Disable all COntrols
            DisableEnableControls(false);
            #endregion

            #region Loss Information
            //Set Values to Label Controls
            lblClaimant_state.Text = new State(!string.IsNullOrEmpty(objAL_FR.Claimant_state) ? Convert.ToDecimal(objAL_FR.Claimant_state) : 0).FLD_state;
            lblAuto_Liability_Type.Text = !string.IsNullOrEmpty(objAL_FR.FK_LU_Auto_Liability_Type) ? Convert.ToString(objAL_FR.FK_LU_Auto_Liability_Type) : "";
            lblDate_Of_Loss.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Date_Of_Loss);
            lblTime_Of_Loss.Text = objAL_FR.Time_Of_Loss;
            lblLoss_offsite.Text = (objAL_FR.Loss_offsite == true) ? "Offsite" : "Onsite";
            //check object value.if it is true than dispaly related fiels.else fields are remain hidden
            if (objAL_FR.Loss_offsite == true)
            {
                trViewLossInjuryOccured.Style.Add("display", "block");
                lblOffsite_Address1.Text = objAL_FR.Offsite_Address_1;
                lblOffsite_Address2.Text = objAL_FR.Offsite_Address_2;
                lblOffsite_City.Text = objAL_FR.Offsite_City;
                lblOffsite_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Offsite_State) ? Convert.ToDecimal(objAL_FR.Offsite_State) : 0).FLD_state;
                lblOffsite_zip.Text = objAL_FR.Offsite_zip;
            }

            lblDescription_Of_Loss.Text = objAL_FR.Description_Of_Loss;
            lblDate_Reported_To_Sonic.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Date_Reported_To_Sonic);
            lblWeather_Conditions.Text = objAL_FR.Weather_Conditions;
            lblRoad_Conditions.Text = objAL_FR.Road_Conditions;
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Were_Police_Notified != null)
            {
                if (objAL_FR.Were_Police_Notified == true)
                    lblWere_Police_Notified.Text = "Yes";
                else
                    lblWere_Police_Notified.Text = "No";
            }
            else
                lblWere_Police_Notified.Text = "unknown";
            //check object value
            if (objAL_FR.Were_Police_Notified == true)
            {
                trViewLossPloiceNotified.Style.Add("display", "block");
                lblPolice_Agency.Text = objAL_FR.Police_Agency;
                lblPolice_Case_Number.Text = objAL_FR.Police_Case_Number;
                lblPolice_Station_Phone_Number.Text = objAL_FR.Police_Station_Phone_Number;
            }
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Pedestrian_Involved != null)
            {
                if (objAL_FR.Pedestrian_Involved == true)
                    lblPedestrian_Involved.Text = "Yes";
                else
                    lblPedestrian_Involved.Text = "No";
            }
            else
                lblPedestrian_Involved.Text = "unknown";

            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Property_Damage != null)
            {
                if (objAL_FR.Property_Damage == true)
                    lblProperty_Damage.Text = "Yes";
                else
                    lblProperty_Damage.Text = "No";
            }
            else
                lblProperty_Damage.Text = "unknown";

            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Witnesses != null)
            {
                if (objAL_FR.Witnesses == true)
                    lblWitnesses.Text = "Yes";
                else
                    lblWitnesses.Text = "No";
            }
            else
                lblWitnesses.Text = "unknown";


            if (objAL_FR.Security_Video_System != null)
            {
                if (objAL_FR.Security_Video_System == true)
                    lblSecurityVideoSystem.Text = "Yes";
                else
                    lblSecurityVideoSystem.Text = "No";
            }
            else
                lblSecurityVideoSystem.Text = "unknown";
            #endregion

            #region Insured Vehicle Information
            //Set values to AL_FR object
            lblVehicle_Sub_Type.Text = new Vehicle_Type(!string.IsNullOrEmpty(objAL_FR.Vehicle_Sub_Type) ? Convert.ToDecimal(objAL_FR.Vehicle_Sub_Type) : 0).Fld_Desc;


            lblVehicle_Fleet_number.Text = objAL_FR.Vehicle_Fleet_number;
            lblYear.Text = (objAL_FR.Year.ToString());
            lblMake.Text = objAL_FR.Make;
            lblModel.Text = objAL_FR.Model;
            lblVIN.Text = objAL_FR.VIN;
            lblLicense_Plate_Number.Text = objAL_FR.License_Plate_Number;
            lblLicense_Plate_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.License_Plate_State) ? Convert.ToDecimal(objAL_FR.License_Plate_State) : 0).FLD_state;
            lblVehicle_Color.Text = objAL_FR.Vehicle_Color;
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Permissive_Use != null)
            {
                if (objAL_FR.Permissive_Use == true)
                    lblPermissive_Use.Text = "Yes";
                else
                    lblPermissive_Use.Text = "No";
            }
            else
                lblPermissive_Use.Text = "unknown";
            lblType_Of_Use.Text = objAL_FR.Type_Of_Use;
            lblVehicle_Damage_Description.Text = objAL_FR.Vehicle_Damage_Description;
            lblRepairs_Completed.Text = (objAL_FR.Repairs_Completed == true) ? "Yes" : "No";
            if (objAL_FR.Repairs_Estimated_Amount.ToString() != string.Empty)
            {
                lblRepairs_Estimated_Amount.Text = "$ " + objAL_FR.Repairs_Estimated_Amount;
            }
            else
                lblRepairs_Estimated_Amount.Text = objAL_FR.Repairs_Estimated_Amount;
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Drivable != null)
            {
                if (objAL_FR.Drivable == true)
                    lblDrivable.Text = "Yes";
                else
                    lblDrivable.Text = "No";
            }
            else
                lblDrivable.Text = "unknown";

            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Passengers != null)
            {
                if (objAL_FR.Passengers == true)
                    lblPassengers.Text = "Yes";
                else
                    lblPassengers.Text = "No";
            }
            else
                lblPassengers.Text = "unknown";

            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Insured_Driver_At_Fault != null)
            {
                if (objAL_FR.Insured_Driver_At_Fault == true)
                    lblInsured_Driver_At_Fault.Text = "Yes";
                else
                    lblInsured_Driver_At_Fault.Text = "No";
            }
            else
                lblInsured_Driver_At_Fault.Text = "unknown";


            lblVehicle_Location.Text = objAL_FR.Vehicle_Location;
            lblVehicle_Location_Driver_Address_1.Text = objAL_FR.Vehicle_Location_Driver_Address_1;
            lblVehicle_Location_Driver_Address_2.Text = objAL_FR.Vehicle_Location_Driver_Address_2;
            lblVehicle_Location_Driver_City.Text = objAL_FR.Vehicle_Location_Driver_City;
            lblVehicle_Location_Driver_State.Text = new State(objAL_FR.Vehicle_Location_Driver_State).FLD_state;
            lblVehicle_Location_Driver_ZipCode.Text = objAL_FR.Vehicle_Location_Driver_ZipCode;
            lblOwner_Name.Text = objAL_FR.Owner_Name;
            lblOwner_Work_Phone.Text = objAL_FR.Owner_Work_Phone;
            lblOwner_Home_Phone.Text = objAL_FR.Owner_Home_Phone;
            lblOwner_Alternate_Phone.Text = objAL_FR.Owner_Alternate_Phone;
            lblOwner_Address_1.Text = objAL_FR.Owner_Address_1;
            lblOwner_Address_2.Text = objAL_FR.Owner_Address_2;
            lblOwner_City.Text = objAL_FR.Owner_City;
            lblOwner_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Owner_State) ? Convert.ToDecimal(objAL_FR.Owner_State) : 0).FLD_state;
            lblOwner_ZipCode.Text = objAL_FR.Owner_ZipCode;
            #endregion

            #region Insured Vehicle Driver Information
            //set values to Label controls

            lblDriver_Name.Text = objAL_FR.Driver_Name;
            lblDriver_SSN.Text = objAL_FR.Driver_SSN;
            lblDriver_Address1.Text = objAL_FR.Driver_Address_1;
            lblDriver_Date_of_Birth.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Driver_Date_of_Birth);
            //check Date of Birth is not null.if not null than display age count
            if (objAL_FR.Driver_Date_of_Birth != null)
            {
                if (Convert.ToDateTime(objAL_FR.Driver_Date_of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    lblDriverAgeCount.Text = GetAge(objAL_FR.Driver_Date_of_Birth);
            }
            lblDriver_Address2.Text = objAL_FR.Driver_Address_2;
            lblDriver_City.Text = objAL_FR.Driver_City;
            lblDriver_Work_Phone.Text = objAL_FR.Driver_Work_Phone;
            lblDriver_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Driver_State) ? Convert.ToDecimal(objAL_FR.Driver_State) : 0).FLD_state;
            lblDriver_Home_Phone.Text = objAL_FR.Driver_Home_Phone;
            lblDriver_ZipCode.Text = objAL_FR.Driver_ZipCode;
            lblDriver_Altermate_Phone.Text = objAL_FR.Driver_Altermate_Phone;
            lblDriver_Drivers_License_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Driver_Drivers_License_State) ? Convert.ToDecimal(objAL_FR.Driver_Drivers_License_State) : 0).FLD_state;
            lblDriver_Drivers_License_Number.Text = objAL_FR.Driver_Drivers_License_Number;
            lblDriver_Relation_to_Insured.Text = objAL_FR.Driver_Relation_to_Insured;
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Citation_Issued != null)
            {
                if (objAL_FR.Citation_Issued == true)
                    lblCitation_Issued.Text = "Yes";
                else
                    lblCitation_Issued.Text = "No";
            }
            else
                lblCitation_Issued.Text = "unknown";

            lblCitation_Number.Text = objAL_FR.Citation_Number;

            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Driver_Was_Injured != null)
            {
                if (objAL_FR.Driver_Was_Injured == true)
                    lblDriver_Was_Injured.Text = "Yes";
                else
                    lblDriver_Was_Injured.Text = "No";
            }
            else
                lblDriver_Was_Injured.Text = "unknown";

            lblDriver_Injury_Description.Text = objAL_FR.Driver_Injury_Description;

            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Driver_Sought_Medical_Attention != null)
            {
                if (objAL_FR.Driver_Sought_Medical_Attention == true)
                    lblDriver_Sought_Medical_Attention.Text = "Yes";
                else
                    lblDriver_Sought_Medical_Attention.Text = "No";
            }
            else
                lblDriver_Sought_Medical_Attention.Text = "unknown";
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Driver_Is_Owner != null)
            {
                if (objAL_FR.Driver_Is_Owner == true)
                    lblDriver_Is_Owner.Text = "Yes";
                else
                    lblDriver_Is_Owner.Text = "No";
            }
            else
                lblDriver_Is_Owner.Text = "unknown";

            lblDriver_Taken_By_Emergency_Transportation.Text = (objAL_FR.Driver_Taken_By_Emergency_Transportation == true) ? "Yes" : "No";
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Driver_Airlifted_Medivac != null)
            {
                if (objAL_FR.Driver_Airlifted_Medivac == true)
                    lblDriver_Airlifted_Medivac.Text = "Yes";
                else
                    lblDriver_Airlifted_Medivac.Text = "No";
            }
            else
                lblDriver_Airlifted_Medivac.Text = "unknown";

            lblDriver_Medical_Facility_Name.Text = objAL_FR.Driver_Medical_Facility_Name;
            lblDriver_Date_Of_Initial_Treatment.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Driver_Date_Of_Initial_Treatment);
            lblDriver_Medical_Facility_Type.Text = objAL_FR.Driver_Medical_Facility_Type;
            lblDriver_Treating_Physician_Name.Text = objAL_FR.Driver_Treating_Physician_Name;
            lblDriver_Medical_Facility_Address_1.Text = objAL_FR.Driver_Medical_Facility_Address_1;

            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Driver_Admitted_to_Hospital != null)
            {
                if (objAL_FR.Driver_Admitted_to_Hospital == true)
                    lblDriver_Admitted_to_Hospital.Text = "Yes";
                else
                    lblDriver_Admitted_to_Hospital.Text = "No";
            }
            else
                lblDriver_Admitted_to_Hospital.Text = "unknown";

            lblDriver_Medical_Facility_Address_2.Text = objAL_FR.Driver_Medical_Facility_Address_2;
            lblDriver_Medical_Facility_City.Text = objAL_FR.Driver_Medical_Facility_City;
            lblDriver_Medical_Facility_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Driver_Medical_Facility_State) ? Convert.ToDecimal(objAL_FR.Driver_Medical_Facility_State) : 0).FLD_state;
            lblDriver_Medical_Facility_Zip_Code.Text = objAL_FR.Driver_Medical_Facility_ZipCode;
            //check object value. if it true than display related fields
            if (objAL_FR.Driver_Admitted_to_Hospital == true)
            {
                lblDriver_Date_Admitted_to_Hospital.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Driver_Date_Admitted_to_Hospital);
                //check object value if it s not null than display "unknown" and display also related fields
                if (objAL_FR.Driver_Still_in_Hospital != null)
                {
                    tdViewDateAdmitted.Style.Add("display", "block");
                    tdViewStillHospital.Style.Add("display", "block");
                    //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                    if (objAL_FR.Driver_Still_in_Hospital == true)
                        lblDriver_Still_in_Hospital.Text = "Yes";
                    else
                        lblDriver_Still_in_Hospital.Text = "No";
                }
                else
                    lblDriver_Still_in_Hospital.Text = "unknown";
            }

            #endregion

            #region Insured Vehicle Passenger Information
            //Set Values of Label Controls
            lblPassenger_Name.Text = objAL_FR.Passenger_Name;
            lblPassenger_Address_1.Text = objAL_FR.Passenger_Address_1;
            lblPassenger_Date_of_Birth.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Passenger_Date_of_Birth);
            //check Date of Birth is not null.if not null than display age count
            if (objAL_FR.Passenger_Date_of_Birth != null)
            {
                if (Convert.ToDateTime(objAL_FR.Passenger_Date_of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    lblPassengerAgeCount.Text = GetAge(objAL_FR.Passenger_Date_of_Birth);
            }
            lblPassenger_Address_2.Text = objAL_FR.Passenger_Address_2;
            lblPassenger_City.Text = objAL_FR.Passenger_City;
            lblPassenger_Work_Phone.Text = objAL_FR.Passenger_Work_Phone;
            lblPassenger_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Passenger_State) ? Convert.ToDecimal(objAL_FR.Passenger_State) : 0).FLD_state;
            lblPassenger_Home_Phone.Text = objAL_FR.Passenger_Home_Phone;
            lblPassenger_ZipCode.Text = objAL_FR.Passenger_ZipCode;
            lblPassenger_Alternate_Phone.Text = objAL_FR.Passenger_Alternate_Phone;
            lblPassenger_Drivers_License_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Passenger_Drivers_License_State) ? Convert.ToDecimal(objAL_FR.Passenger_Drivers_License_State) : 0).FLD_state;
            lblPassenger_Drivers_License_Number.Text = objAL_FR.Passenger_Drivers_License_Number;
            lblPassenger_Relation_to_Insured.Text = objAL_FR.Passenger_Relation_to_Insured;
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Passenger_Was_Injured != null)
            {
                if (objAL_FR.Passenger_Was_Injured == true)
                    lblPassenger_Was_Injured.Text = "Yes";
                else
                    lblPassenger_Was_Injured.Text = "No";
            }
            else
                lblPassenger_Was_Injured.Text = "unknown";

            lblPassenger_Description_of_Injury.Text = objAL_FR.Passenger_Description_of_Injury;
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Passenger_Sought_Medical_Attention != null)
            {
                if (objAL_FR.Passenger_Sought_Medical_Attention == true)
                    lblPassenger_Sought_Medical_Attention.Text = "Yes";
                else
                    lblPassenger_Sought_Medical_Attention.Text = "No";
            }
            else
                lblPassenger_Sought_Medical_Attention.Text = "unknown";

            #endregion

            #region Other Vehicle Information
            //set values to label contros
            lblOther_Vehicle_Year.Text = (objAL_FR.Other_Vehicle_Year.ToString());
            lblOther_Vehicle_Make.Text = objAL_FR.Other_Vehicle_Make;
            lblOther_Vehicle_Model.Text = objAL_FR.Other_Vehicle_Model;
            lblOther_Vehicle_VIN.Text = objAL_FR.Other_Vehicle_VIN;
            lblOther_Vehicle_License_Plate_Number.Text = objAL_FR.Other_Vehicle_License_Plate_Number;
            lblOther_Vehicle_License_Plate_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Other_Vehicle_License_Plate_State) ? Convert.ToDecimal(objAL_FR.Other_Vehicle_License_Plate_State) : 0).FLD_state;
            lblOther_Vehicle_Vehicle_Color.Text = objAL_FR.Other_Vehicle_Vehicle_Color;
            lblOther_Vehicle_Insurance_Co_Name.Text = objAL_FR.Other_Vehicle_Insurance_Co_Name;
            lblOther_Vehicle_Insurance_Co_Phone.Text = objAL_FR.Other_Vehicle_Insurance_Co_Phone;
            lblPassenger_Description_of_Injury.Text = objAL_FR.Passenger_Description_of_Injury;
            lblOther_Vehicle_Insurance_Policy_Number.Text = objAL_FR.Other_Vehicle_Insurance_Policy_Number;
            lblOther_Vehicle_Vehicle_Damage_Description.Text = objAL_FR.Other_Vehicle_Vehicle_Damage_Description;
            lblOther_Vehicle_Repairs_Completed.Text = (objAL_FR.Other_Vehicle_Repairs_Completed == true) ? "Yes" : "No";
            if (objAL_FR.Other_Vehicle_Repairs_Estimated_Amount.ToString() != string.Empty)
            {
                lblOther_Vehicle_Repairs_Estimated_Amount.Text = "$ " + objAL_FR.Other_Vehicle_Repairs_Estimated_Amount;
            }
            else
                lblOther_Vehicle_Repairs_Estimated_Amount.Text = objAL_FR.Other_Vehicle_Repairs_Estimated_Amount;
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Other_Vehicle_Drivable != null)
            {
                if (objAL_FR.Other_Vehicle_Drivable == true)
                    lblOther_Vehicle_Drivable.Text = "Yes";
                else
                    lblOther_Vehicle_Drivable.Text = "No";
            }
            else
                lblOther_Vehicle_Drivable.Text = "unknown";

            lblOther_Vehicle_Location.Text = objAL_FR.Other_Vehicle_Location;
            lblOther_Vehicle_Location_Telephone.Text = objAL_FR.Other_Vehicle_Location_Telephone;
            lblOther_Vehicle_Location_Driver_Address_1.Text = objAL_FR.Other_Vehicle_Location_Driver_Address_1;
            lblOther_Vehicle_Location_Driver_Address_2.Text = objAL_FR.Other_Vehicle_Location_Driver_Address_2;
            lblOther_Vehicle_Location_Driver_City.Text = objAL_FR.Other_Vehicle_Location_Driver_City;
            lblOther_Vehicle_Location_Driver_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Other_Vehicle_Location_Driver_State) ? Convert.ToDecimal(objAL_FR.Other_Vehicle_Location_Driver_State) : 0).FLD_state;
            lblOther_Vehicle_Location_Driver_ZipCode.Text = objAL_FR.Other_Vehicle_Location_Driver_ZipCode;
            lblOther_Vehicle_Owner_Name.Text = objAL_FR.Other_Vehicle_Owner_Name;
            lblOther_Vehicle_Owner_Work_Phone.Text = objAL_FR.Other_Vehicle_Owner_Work_Phone;
            lblOther_Vehicle_Owner_Home_Phone.Text = objAL_FR.Other_Vehicle_Owner_Home_Phone;
            lblOther_Vehicle_Owner_Alternate_Phone.Text = objAL_FR.Other_Vehicle_Owner_Alternate_Phone;
            lblOther_Vehicle_Owner_Address_1.Text = objAL_FR.Other_Vehicle_Owner_Address_1;
            lblOther_Vehicle_Owner_Address_2.Text = objAL_FR.Other_Vehicle_Owner_Address_2;
            lblOther_Vehicle_Owner_City.Text = objAL_FR.Other_Vehicle_Owner_City;
            lblOther_Vehicle_Owner_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Other_Vehicle_Owner_State) ? Convert.ToDecimal(objAL_FR.Other_Vehicle_Owner_State) : 0).FLD_state;
            lblOther_Vehicle_Owner_ZipCode.Text = objAL_FR.Other_Vehicle_Owner_ZipCode;
            #endregion

            #region Other Vehicle Driver Information
            // Set Values to label controls
            lblOther_Driver_Name.Text = objAL_FR.Other_Driver_Name;
            lblOther_Driver_SSN.Text = objAL_FR.Other_Driver_SSN;
            lblOther_Driver_Address_1.Text = objAL_FR.Other_Driver_Address_1;
            lblOther_Driver_Date_of_Birth.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Other_Driver_Date_of_Birth);
            //check Date of Birth is not null.if not null than display age count
            if (objAL_FR.Other_Driver_Date_of_Birth != null)
            {
                if (Convert.ToDateTime(objAL_FR.Other_Driver_Date_of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    lblOther_Driver_AgeCount.Text = GetAge(objAL_FR.Other_Driver_Date_of_Birth);
            }
            lblOther_Driver_Address_2.Text = objAL_FR.Other_Driver_Address_2;
            lblOther_Driver_City.Text = objAL_FR.Other_Driver_City;
            lblOther_Driver_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Other_Driver_State) ? Convert.ToDecimal(objAL_FR.Other_Driver_State) : 0).FLD_state;
            lblOther_Driver_Home_Phone.Text = objAL_FR.Other_Driver_Home_Phone;
            lblOther_Driver_Work_Phone.Text = objAL_FR.Other_Driver_Work_Phone;
            lblOther_Driver_ZipCode.Text = objAL_FR.Other_Driver_ZipCode;
            lblOther_Driver_Drivers_License_Number.Text = objAL_FR.Other_Driver_Drivers_License_Number;
            lblOther_Driver_Gender.Text = objAL_FR.Other_Driver_Gender;
            lblOther_Driver_Drivers_License_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Other_Driver_Drivers_License_State) ? Convert.ToDecimal(objAL_FR.Other_Driver_Drivers_License_State) : 0).FLD_state;
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Other_Driver_Citation_Issued != null)
            {
                if (objAL_FR.Other_Driver_Citation_Issued == true)
                    lblOther_Driver_Citation_Issued.Text = "Yes";
                else
                    lblOther_Driver_Citation_Issued.Text = "No";
            }
            else
                lblOther_Driver_Citation_Issued.Text = "unknown";

            lblOther_Driver_Citation_Number.Text = objAL_FR.Other_Driver_Citation_Number;
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Other_Driver_Injured != null)
            {
                if (objAL_FR.Other_Driver_Injured == true)
                    lblOther_Driver_Injured.Text = "Yes";
                else
                    lblOther_Driver_Injured.Text = "No";
            }
            else
                lblOther_Driver_Injured.Text = "unknown";


            lblOther_Driver_Injury_Description.Text = objAL_FR.Other_Driver_Injury_Description;
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Other_Driver_Sought_Medical_Attention != null)
            {
                if (objAL_FR.Other_Driver_Sought_Medical_Attention == true)
                    lblOther_Driver_Sought_Medical_Attention.Text = "Yes";
                else
                    lblOther_Driver_Sought_Medical_Attention.Text = "No";
            }
            else
                lblOther_Driver_Sought_Medical_Attention.Text = "unknown";

            lblOther_Driver_Taken_By_Emergency_Transportation.Text = (objAL_FR.Other_Driver_Taken_By_Emergency_Transportation == true) ? "Yes" : "No";
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Other_Driver_Airlifted_Medivac != null)
            {
                if (objAL_FR.Other_Driver_Airlifted_Medivac == true)
                    lblOther_Driver_Airlifted_Medivac.Text = "Yes";
                else
                    lblOther_Driver_Airlifted_Medivac.Text = "No";
            }
            else
                lblOther_Driver_Airlifted_Medivac.Text = "unknown";
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Other_Driver_Admitted_to_Hospital != null)
            {
                if (objAL_FR.Other_Driver_Admitted_to_Hospital == true)
                    lblOther_Driver_Admitted_to_Hospital.Text = "Yes";
                else
                    lblOther_Driver_Admitted_to_Hospital.Text = "No";
            }
            else
                lblOther_Driver_Admitted_to_Hospital.Text = "unknown";

            lblOther_Driver_Medical_Facility_Name.Text = objAL_FR.Other_Driver_Medical_Facility_Name;
            lblOther_Driver_Medical_Facility_Address_1.Text = objAL_FR.Other_Driver_Medical_Facility_Address_1;
            lblOther_Driver_Medical_Facility_Address_2.Text = objAL_FR.Other_Driver_Medical_Facility_Address_2;
            //check object value. if it is true than display related fields else that fields are remain hidden
            if (objAL_FR.Other_Driver_Admitted_to_Hospital == true)
            {
                tdViewOth_Driver_DateAdmitted.Style.Add("display", "block");
                tdViewOth_Driver_StillHospital.Style.Add("display", "block");
                lblOther_Driver_Date_Admitted_to_Hospital.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Other_Driver_Date_Admitted_to_Hospital);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Other_Driver_Still_in_Hospital != null)
                {
                    if (objAL_FR.Other_Driver_Still_in_Hospital == true)
                        lblOther_Driver_Still_in_Hospital.Text = "Yes";
                    else
                        lblOther_Driver_Still_in_Hospital.Text = "No";
                }
                else
                    lblOther_Driver_Still_in_Hospital.Text = "unknown";
            }
            lblOther_Driver_Medical_Facility_City.Text = objAL_FR.Other_Driver_Medical_Facility_City;
            lblOther_Driver_Physicians_Name.Text = objAL_FR.Other_Driver_Physicians_Name;
            lblOther_Driver_Medical_Facility_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Other_Driver_Medical_Facility_State) ? Convert.ToDecimal(objAL_FR.Other_Driver_Medical_Facility_State) : 0).FLD_state;
            lblOther_Driver_Medical_Facility_Zip_Code.Text = objAL_FR.Other_Driver_Medical_Facility_Zip_Code;
            lblOther_Driver_Medical_Facility_Type.Text = objAL_FR.Other_Driver_Medical_Facility_Type;

            #endregion

            #region Other Vehicle Passenger Information

            // Set Values to label controls
            lblOth_Veh_Pass_Name.Text = objAL_FR.Oth_Veh_Pass_Name;
            lblOth_Veh_Pass_Date_of_Birth.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Oth_Veh_Pass_Date_of_Birth);
            //check Date of Birth is not null.if not null than display age count
            if (objAL_FR.Oth_Veh_Pass_Date_of_Birth != null)
            {
                if (Convert.ToDateTime(objAL_FR.Oth_Veh_Pass_Date_of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    lblOth_Veh_Pass_AgeCount.Text = GetAge(objAL_FR.Oth_Veh_Pass_Date_of_Birth);
            }
            lblOth_Veh_Pass_Address_1.Text = objAL_FR.Oth_Veh_Pass_Address_1;
            lblOth_Veh_Pass_Address_2.Text = objAL_FR.Oth_Veh_Pass_Address_2;
            lblOth_Veh_Pass_City.Text = objAL_FR.Oth_Veh_Pass_City;
            lblOth_Veh_Pass_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Oth_Veh_Pass_State) ? Convert.ToDecimal(objAL_FR.Oth_Veh_Pass_State) : 0).FLD_state;
            lblOth_Veh_Pass_Home_Phone.Text = objAL_FR.Oth_Veh_Pass_Home_Phone;
            lblOth_Veh_Pass_Work_Phone.Text = objAL_FR.Oth_Veh_Pass_Work_Phone;
            lblOth_Veh_Pass_Alternate_Phone.Text = objAL_FR.Oth_Veh_Pass_Alternate_Phone;
            lblOth_Veh_Pass_ZipCode.Text = objAL_FR.Oth_Veh_Pass_ZipCode;
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Oth_Veh_Pass_Injured != null)
            {
                if (objAL_FR.Oth_Veh_Pass_Injured == true)
                    lblOth_Veh_Pass_Injured.Text = "Yes";
                else
                    lblOth_Veh_Pass_Injured.Text = "No";
            }
            else
                lblOth_Veh_Pass_Injured.Text = "unknown";
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Oth_Veh_Pass_Injured != null)
            {
                if (objAL_FR.Oth_Veh_Pass_Injured == true)
                    lblOth_Veh_Pass_Injured.Text = "Yes";
                else
                    lblOth_Veh_Pass_Injured.Text = "No";
            }
            else
                lblOth_Veh_Pass_Injured.Text = "unknown";
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Oth_Veh_Pass_Injured != null)
            {
                if (objAL_FR.Oth_Veh_Pass_Injured == true)
                    lblOth_Veh_Pass_Injured.Text = "Yes";
                else
                    lblOth_Veh_Pass_Injured.Text = "No";
            }
            else
                lblOth_Veh_Pass_Injured.Text = "unknown";


            lblOth_Veh_Pass_Injury_Description.Text = objAL_FR.Oth_Veh_Pass_Injury_Description;
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Oth_Veh_Pass_Sought_Medical_Attention != null)
            {
                if (objAL_FR.Oth_Veh_Pass_Sought_Medical_Attention == true)
                    lblOth_Veh_Pass_Sought_Medical_Attention.Text = "Yes";
                else
                    lblOth_Veh_Pass_Sought_Medical_Attention.Text = "No";
            }
            else
                lblOth_Veh_Pass_Sought_Medical_Attention.Text = "unknown";

            lblOth_Veh_Pass_Taken_By_Emergency_Transportation.Text = ((objAL_FR.Oth_Veh_Pass_Taken_By_Emergency_Transportation == true) ? "Yes" : "No");
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Oth_Veh_Pass_Airlifted_Medivac != null)
            {
                if (objAL_FR.Oth_Veh_Pass_Airlifted_Medivac == true)
                    lblOth_Veh_Pass_Airlifted_Medivac.Text = "Yes";
                else
                    lblOth_Veh_Pass_Airlifted_Medivac.Text = "No";
            }
            else
                lblOth_Veh_Pass_Airlifted_Medivac.Text = "unknown";
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Oth_Veh_Pass_Admitted_to_Hospital != null)
            {
                if (objAL_FR.Oth_Veh_Pass_Admitted_to_Hospital == true)
                    lblOth_Veh_Pass_Admitted_to_Hospital.Text = "Yes";
                else
                    lblOth_Veh_Pass_Admitted_to_Hospital.Text = "No";
            }
            else
                lblOth_Veh_Pass_Admitted_to_Hospital.Text = "unknown";

            lblOth_Veh_Pass_Medical_Facility_Name.Text = objAL_FR.Oth_Veh_Pass_Medical_Facility_Name;
            lblOth_Veh_Pass_Medical_Facility_Address_1.Text = objAL_FR.Oth_Veh_Pass_Medical_Facility_Address_1;
            lblOth_Veh_Pass_Medical_Facility_Address_2.Text = objAL_FR.Oth_Veh_Pass_Medical_Facility_Address_2;
            //check object value. if it is true than display related fields else that fields are remain hidden
            if (objAL_FR.Oth_Veh_Pass_Admitted_to_Hospital == true)
            {
                tdViewOth_Ven_Pass_DateAdmitted.Style.Add("display", "block");
                tdViewOth_Ven_Pass_StillHospital.Style.Add("display", "block");
                lblOth_Veh_Pass_Date_Admitted_to_Hospital.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Oth_Veh_Pass_Date_Admitted_to_Hospital);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Oth_Veh_Pass_Still_in_Hospital != null)
                {
                    if (objAL_FR.Oth_Veh_Pass_Still_in_Hospital == true)
                        lblOth_Veh_Pass_Still_in_Hospital.Text = "Yes";
                    else
                        lblOth_Veh_Pass_Still_in_Hospital.Text = "No";
                }
                else
                    lblOth_Veh_Pass_Still_in_Hospital.Text = "unknown";
            }
            lblOth_Veh_Pass_Medical_Facility_City.Text = objAL_FR.Oth_Veh_Pass_Medical_Facility_City;
            lblOth_Veh_Pass_Physicians_Name.Text = objAL_FR.Oth_Veh_Pass_Physicians_Name;
            lblOth_Veh_Pass_Medical_Facility_State.Text = new State(objAL_FR.Oth_Veh_Pass_Medical_Facility_State).FLD_state;
            lblOth_Veh_Pass_Medical_Facility_Zip_Code.Text = objAL_FR.Oth_Veh_Pass_Medical_Facility_ZipCode;
            lblOth_Veh_Pass_Medical_Facility_Type.Text = objAL_FR.Oth_Veh_Pass_Medical_Facility_Type;

            #endregion

            #region Pedestrian Information
            // Set Values to Label Controls
            lblPedestrian_Name.Text = objAL_FR.Pedestrian_Name;
            lblPedestrian_Date_of_Birth.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Pedestrian_Date_of_Birth);
            //check Date of Birth is not null.if not null than display age count
            if (objAL_FR.Pedestrian_Date_of_Birth != null)
            {
                if (Convert.ToDateTime(objAL_FR.Pedestrian_Date_of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    lblPedestrianAgeCount.Text = GetAge(objAL_FR.Pedestrian_Date_of_Birth);
            }
            lblPedestrian_Address_1.Text = objAL_FR.Pedestrian_Address_1;
            lblPedestrian_Address_2.Text = objAL_FR.Pedestrian_Address_2;
            lblPedestrian_City.Text = objAL_FR.Pedestrian_City;
            lblPedestrian_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Pedestrian_State) ? Convert.ToDecimal(objAL_FR.Pedestrian_State) : 0).FLD_state;
            lblPedestrian_Home_Phone.Text = objAL_FR.Pedestrian_Home_Phone;
            lblPedestrian_Work_Phone.Text = objAL_FR.Pedestrian_Work_Phone;
            lblPedestrian_Alternate_Phone.Text = objAL_FR.Pedestrian_Alternate_Phone;
            lblPedestrian_ZipCode.Text = objAL_FR.Pedestrian_ZipCode;
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Pedestrian_Injured != null)
            {
                if (objAL_FR.Pedestrian_Injured == true)
                    lblPedestrian_Injured.Text = "Yes";
                else
                    lblPedestrian_Injured.Text = "No";
            }
            else
                lblPedestrian_Injured.Text = "unknown";

            lblPedestrian_Injury_Description.Text = objAL_FR.Pedestrian_Injury_Description;
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Pedestrian_Sought_Medical_Attention != null)
            {
                if (objAL_FR.Pedestrian_Sought_Medical_Attention == true)
                    lblPedestrian_Sought_Medical_Attention.Text = "Yes";
                else
                    lblPedestrian_Sought_Medical_Attention.Text = "No";
            }
            else
                lblPedestrian_Sought_Medical_Attention.Text = "unknown";

            lblPedestrian_Taken_By_Emergency_Transportation.Text = (objAL_FR.Pedestrian_Taken_By_Emergency_Transportation == true) ? "Yes" : "No";
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Pedestrian_Airlifted_Medivac != null)
            {
                if (objAL_FR.Pedestrian_Airlifted_Medivac == true)
                    lblPedestrian_Airlifted_Medivac.Text = "Yes";
                else
                    lblPedestrian_Airlifted_Medivac.Text = "No";
            }
            else
                lblPedestrian_Airlifted_Medivac.Text = "unknown";
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Pedestrian_Admitted_to_Hospital != null)
            {
                if (objAL_FR.Pedestrian_Admitted_to_Hospital == true)
                    lblPedestrian_Admitted_to_Hospital.Text = "Yes";
                else
                    lblPedestrian_Admitted_to_Hospital.Text = "No";
            }
            else
                lblPedestrian_Admitted_to_Hospital.Text = "unknwon";

            lblPedestrian_Medical_Facility_Name.Text = objAL_FR.Pedestrian_Medical_Facility_Name;
            lblPedestrian_Medical_Facility_Address_1.Text = objAL_FR.Pedestrian_Medical_Facility_Address_1;
            lblPedestrian_Medical_Facility_Address_2.Text = objAL_FR.Pedestrian_Medical_Facility_Address_2;
            lblPedestrian_Date_Admitted_to_Hospital.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Pedestrian_Date_Admitted_to_Hospital);
            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Pedestrian_Still_in_Hospital != null)
            {
                if (objAL_FR.Pedestrian_Still_in_Hospital == true)
                    lblPedestrian_Still_in_Hospital.Text = "Yes";
                else
                    lblPedestrian_Still_in_Hospital.Text = "No";
            }
            else
                lblPedestrian_Still_in_Hospital.Text = "unknown";

            lblPedestrian_Medical_Facility_City.Text = objAL_FR.Pedestrian_Medical_Facility_City;
            lblPedestrian_Physicians_Name.Text = objAL_FR.Pedestrian_Physicians_Name;
            lblPedestrian_Medical_Facility_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Pedestrian_Medical_Facility_State) ? Convert.ToDecimal(objAL_FR.Pedestrian_Medical_Facility_State) : 0).FLD_state;
            lblPedestrian_Medical_Facility_Zip_Code.Text = objAL_FR.Pedestrian_Medical_Facility_Zip_Code;
            lblPedestrian_Medical_Facility_Type.Text = objAL_FR.Pedestrian_Medical_Facility_Type;
            #endregion

            #region Witness Information
            // set Value to label Controls
            lblWitness_Name.Text = objAL_FR.Witness_Name;
            lblWitness_Address_1.Text = objAL_FR.Witness_Address_1;
            lblWitness_Address_2.Text = objAL_FR.Witness_Address_2;
            lblWitness_City.Text = objAL_FR.Witness_City;
            lblWitness_State.Text = new State(!string.IsNullOrEmpty(objAL_FR.Witness_State) ? Convert.ToDecimal(objAL_FR.Witness_State) : 0).FLD_state;
            lblWitness_Zip_Code.Text = objAL_FR.Witness_ZipCode;
            lblWitness_Home_Phone.Text = objAL_FR.Witness_Home_Phone;
            lblWitness_Work_Phone.Text = objAL_FR.Witness_Work_Phone;
            lblWitness_Alternate_Phone.Text = objAL_FR.Witness_Alternate_Phone;

            #endregion

            #region Comments and Attachments
            //Comments and Attachments
            lblComments.Text = objAL_FR.Comments;
            CtrlViewAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.AL_FR, PK_AL_FR_ID, false, 11);
            CtrlViewAttachDetails.Bind();
            #endregion
        }
        else
        {
            Response.Redirect("FirstReportSearch.aspx", true);
        }
    }
    #endregion

    #region Bind Page in Edit Mode
    /// <summary>
    /// Bind Page in Edit Mode
    /// </summary>
    public void BindPageinEditMode()
    {
        //Check First Report Wizard ID. if Greater than Zero than update data in First Report Wizard table.
        if (First_Report_Wizard_ID > 0)
        {
            //Hide Message of "This Report Has not been submitted"
            lblSubmitMessage.Text = "";
            //Declare Object of WC_FR table
            AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);
            //used to check report is complete or not. if not than Message is display else not display
            if (objAL_FR.Complete == false)
            {
                //Hide Message of "This Report Has not been submitted"
                lblSubmitMessage.Text = "This Report has not been submitted";
            }
            else
            {
                lblSubmitMessage.Text = "";
            }

            #region Location/Contact Information
            DataSet dsWizardInfo = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.AL_FR, PK_AL_FR_ID);
            DataTable dtWizardInfo = dsWizardInfo.Tables[0];
            DataRow drWizardInfo = dtWizardInfo.Rows[0];

            #region Fill Location Information Controls
            //select value from Location Number Dropdown
            if (drWizardInfo["Sonic_Location_Code"] != null)
            {
                ListItem lstLnumber = new ListItem();
                lstLnumber = ddlLocationNumber.Items.FindByText(drWizardInfo["Sonic_Location_Code"].ToString());
                //check list item if not null than list item selected = true
                if (lstLnumber != null)
                    lstLnumber.Selected = true;
            }

            //select value from Location d/b/a Dropdown
            if (drWizardInfo["dba"] != null)
            {
                ListItem lst = new ListItem();
                lst = ddlLocationdba.Items.FindByText(drWizardInfo["dba"].ToString());
                //check list item if not null than list item selected = true
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
            //select value from Location f/k/a Dropdown
            if (drWizardInfo["PK_LU_Location_ID"] != null)
            {
                //Fill Location FKA Dropdown
                //ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, (drWizardInfo["FK_Location_ID"] != null) ? Convert.ToInt32(drWizardInfo["FK_Location_ID"]) : 0, true);

                ListItem lst = new ListItem();
                lst = ddlLocationfka.Items.FindByValue(drWizardInfo["PK_LU_Location_ID"].ToString());
                //check list item if not null than list item selected = true
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }

            //select value from Location Legal Entity Dropdown
            //if (drWizardInfo["legal_entity"] != null)
            //{
            //    ListItem lst = new ListItem();
            //    lst = ddlLegalEntity.Items.FindByText(drWizardInfo["legal_entity"].ToString().Trim());
            //    //check list item if not null than list item selected = true
            //    if (lst != null)
            //    {
            //        lst.Selected = true;
            //    }
            //}

            //set address1,address2,city,state,ZipCOde Values
            txtLocationAddress1.Text = (drWizardInfo["Address_1"] != null) ? Convert.ToString(drWizardInfo["Address_1"]) : "";
            txtLocationAddress2.Text = (drWizardInfo["Address_2"] != null) ? Convert.ToString(drWizardInfo["Address_2"]) : "";
            txtLocationCity.Text = (drWizardInfo["City"] != null) ? Convert.ToString(drWizardInfo["City"]) : "";
            txtLocationState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drWizardInfo["State"])) ? Convert.ToDecimal(drWizardInfo["State"]) : 0).FLD_state;
            txtLocationZipCode.Text = (drWizardInfo["Zip_Code"] != null) ? Convert.ToString(drWizardInfo["Zip_Code"]) : "";

            #endregion

            #region Fill Contact Information Controls

            txtContactName.Text = (drWizardInfo["EmployeeName"] != null) ? Convert.ToString(drWizardInfo["EmployeeName"]) : "";
            txtContact_Best_Time.Text = (drWizardInfo["Contact_Best_Time"] != null) ? Convert.ToString(drWizardInfo["Contact_Best_Time"]) : "";
            txtContactTelephoneNumber1.Text = (drWizardInfo["TelephoneNumber1"] != null) ? Convert.ToString(drWizardInfo["TelephoneNumber1"]) : "";
            txtContactTelephoneNumber2.Text = (drWizardInfo["TelephoneNumber2"] != null) ? Convert.ToString(drWizardInfo["TelephoneNumber2"]) : "";
            txtContactFaxNumber.Text = (drWizardInfo["Contact_Fax"] != null) ? Convert.ToString(drWizardInfo["Contact_Fax"]) : "";
            txtContactEmailAddress.Text = (drWizardInfo["FRWEmail"] != null) ? Convert.ToString(drWizardInfo["FRWEmail"]) : "";
            //fill Controls By Cost Center Value
            txtCostCenterdba.Text = (drWizardInfo["dba"] != null) ? Convert.ToString(drWizardInfo["dba"]) : "";
            txtCostCenterAddress1.Text = (drWizardInfo["Address_1"] != null) ? Convert.ToString(drWizardInfo["Address_1"]) : "";
            txtCostCenterAddress2.Text = (drWizardInfo["Address_2"] != null) ? Convert.ToString(drWizardInfo["Address_2"]) : "";
            txtCostCenterCity.Text = (drWizardInfo["City"] != null) ? Convert.ToString(drWizardInfo["City"]) : "";
            txtCostCenterState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drWizardInfo["State"])) ? Convert.ToDecimal(drWizardInfo["State"]) : 0).FLD_state;
            txtCostCenterZipCode.Text = (drWizardInfo["Zip_Code"] != null) ? Convert.ToString(drWizardInfo["Zip_Code"]) : "";
            #endregion

            //used to Disable all COntrols
            DisableEnableControls(false);
            #endregion

            #region Loss Information
            //Set Values to Objects
            if (objAL_FR.Claimant_state != null)
            {
                ListItem lstClaimant = new ListItem();
                lstClaimant = ddlClaimant_state.Items.FindByValue(objAL_FR.Claimant_state.ToString());
                if (lstClaimant != null)
                    lstClaimant.Selected = true;
            }

            //Set Values to Objects
            if (objAL_FR.FK_LU_Auto_Liability_Type != null)
            {
                ListItem lstAuto_Liability_Type = new ListItem();
                lstAuto_Liability_Type = ddlAuto_Liability_Type.Items.FindByValue(objAL_FR.FK_LU_Auto_Liability_Type.ToString());
                if (lstAuto_Liability_Type != null)
                    lstAuto_Liability_Type.Selected = true;
            }


            txtDate_Of_Loss.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Date_Of_Loss);
            //check Date of Loss. if Date of loss is not null than no require to validate these Panel
            if (objAL_FR.Date_Of_Loss != null)
            {
                if (Convert.ToDateTime(objAL_FR.Date_Of_Loss) != System.Data.SqlTypes.SqlDateTime.MinValue)
                    hdnLoss.Value = "1";
                else
                    hdnLoss.Value = "0";
            }
            else
                hdnLoss.Value = "0";
            txtTime_Of_Loss.Text = objAL_FR.Time_Of_Loss;
            rdoLoss_offsite.SelectedValue = (objAL_FR.Loss_offsite == true) ? "Y" : "N";
            //check object value. if it is true than display related fields else that fields are remain hidden
            if (objAL_FR.Loss_offsite == true)
            {
                trLossInjuryOccured.Style.Add("display", "block");
                hdnOnsiteOffsite.Value = "1";
                txtOffsite_Address1.Text = objAL_FR.Offsite_Address_1;
                txtOffsite_Address2.Text = objAL_FR.Offsite_Address_2;
                txtOffsite_City.Text = objAL_FR.Offsite_City;
                //check object value.
                if (objAL_FR.Offsite_State != null)
                {
                    ListItem lstOffState = new ListItem();
                    lstOffState = ddlOffsite_State.Items.FindByValue(objAL_FR.Offsite_State.ToString());
                    //check value of list item . if it is not null than select Listitem
                    if (lstOffState != null)
                        lstOffState.Selected = true;
                }
                txtOffsite_zip.Text = objAL_FR.Offsite_zip;
            }

            txtDescription_Of_Loss.Text = objAL_FR.Description_Of_Loss;
            txtDate_Reported_To_Sonic.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Date_Reported_To_Sonic);
            txtWeather_Conditions.Text = objAL_FR.Weather_Conditions;
            txtRoad_Conditions.Text = objAL_FR.Road_Conditions;
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Were_Police_Notified != null)
            {
                if (objAL_FR.Were_Police_Notified == true)
                    rdoWere_Police_Notified.SelectedValue = "Y";
                else
                    rdoWere_Police_Notified.SelectedValue = "N";
            }
            else
                rdoWere_Police_Notified.SelectedValue = "-1";
            //check object value. if it true than display related fields else that fields are remian hidden
            if (objAL_FR.Were_Police_Notified == true)
            {
                hdnPoliceNotify.Value = "1";
                trLossPloiceNotified.Style.Add("display", "block");
                txtPolice_Agency.Text = objAL_FR.Police_Agency;
                txtPolice_Case_Number.Text = objAL_FR.Police_Case_Number;
                txtPolice_Station_Phone_Number.Text = objAL_FR.Police_Station_Phone_Number;
            }
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Pedestrian_Involved != null)
            {
                if (objAL_FR.Pedestrian_Involved == true)
                    rdoPedestrian_Involved.SelectedValue = "Y";
                else
                    rdoPedestrian_Involved.SelectedValue = "N";
            }
            else
                rdoPedestrian_Involved.SelectedValue = "-1";
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Property_Damage != null)
            {
                if (objAL_FR.Property_Damage == true)
                    rdoProperty_Damage.SelectedValue = "Y";
                else
                    rdoProperty_Damage.SelectedValue = "N";
            }
            else
                rdoProperty_Damage.SelectedValue = "-1";

            //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
            if (objAL_FR.Witnesses != null)
            {
                if (objAL_FR.Witnesses == true)
                    rdoWitnesses.SelectedValue = "Y";
                else
                    rdoWitnesses.SelectedValue = "N";
            }
            else
                rdoWitnesses.SelectedValue = "-1";


            if (objAL_FR.Security_Video_System != null)
            {
                if (objAL_FR.Security_Video_System == true)
                    rdoSecurityVideoSystem.SelectedValue = "Y";
                else
                    rdoSecurityVideoSystem.SelectedValue = "N";
            }
            else
                rdoSecurityVideoSystem.SelectedValue = "-1";


            #endregion

            #region Insured Vehicle Information
            //Set values to Cotrols from object
            if (objAL_FR.Vehicle_Sub_Type != null)
            {
                ListItem lstVST = new ListItem();
                lstVST = ddlVehicle_Sub_Type.Items.FindByValue(objAL_FR.Vehicle_Sub_Type.ToString());
                //check list item if not null than list item selected = true
                if (lstVST != null)
                    lstVST.Selected = true;
            }

            txtVehicle_Fleet_number.Text = objAL_FR.Vehicle_Fleet_number;
            txtYear.Text = (objAL_FR.Year.ToString() == "0" ? "" : objAL_FR.Year.ToString());
            txtMake.Text = objAL_FR.Make;
            txtModel.Text = objAL_FR.Model;
            txtVIN.Text = objAL_FR.VIN;
            txtLicense_Plate_Number.Text = objAL_FR.License_Plate_Number;
            //check object value
            if (objAL_FR.License_Plate_State != null)
            {
                ListItem lstLPS = new ListItem();
                lstLPS = ddlLicense_Plate_State.Items.FindByValue(objAL_FR.License_Plate_State.ToString());
                //check list item if not null than list item selected = true
                if (lstLPS != null)
                    lstLPS.Selected = true;
            }
            txtVehicle_Color.Text = objAL_FR.Vehicle_Color;
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Permissive_Use != null)
            {
                if (objAL_FR.Permissive_Use == true)
                    rdoPermissive_Use.SelectedValue = "Y";
                else
                    rdoPermissive_Use.SelectedValue = "N";
            }
            else
                rdoPermissive_Use.SelectedValue = "-1";
            ListItem lstType_Use = new ListItem();
            lstType_Use = rdoType_Of_Use.Items.FindByValue(objAL_FR.Type_Of_Use.ToString());
            //check Null value
            if (lstType_Use != null)
                lstType_Use.Selected = true;
            txtVehicle_Damage_Description.Text = objAL_FR.Vehicle_Damage_Description;
            rdoRepairs_Completed.SelectedValue = (objAL_FR.Repairs_Completed == true) ? "1" : "0";
            txtRepairs_Estimated_Amount.Text = objAL_FR.Repairs_Estimated_Amount;
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Drivable != null)
            {
                if (objAL_FR.Drivable == true)
                    rdoDrivable.SelectedValue = "Y";
                else
                    rdoDrivable.SelectedValue = "N";
            }
            else
                rdoDrivable.SelectedValue = "-1";

            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Passengers != null)
            {
                if (objAL_FR.Passengers == true)
                    rdoPassengers.SelectedValue = "Y";
                else
                    rdoPassengers.SelectedValue = "N";
            }
            else
                rdoPassengers.SelectedValue = "-1";
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Insured_Driver_At_Fault != null)
            {
                if (objAL_FR.Insured_Driver_At_Fault == true)
                    rdoInsured_Driver_At_Fault.SelectedValue = "Y";
                else
                    rdoInsured_Driver_At_Fault.SelectedValue = "N";
            }
            else
                rdoInsured_Driver_At_Fault.SelectedValue = "-1";

            txtVehicle_Location.Text = objAL_FR.Vehicle_Location;
            txtVehicle_Location_Driver_Address_1.Text = objAL_FR.Vehicle_Location_Driver_Address_1;
            txtVehicle_Location_Driver_Address_2.Text = objAL_FR.Vehicle_Location_Driver_Address_2;
            txtVehicle_Location_Driver_City.Text = objAL_FR.Vehicle_Location_Driver_City;
            ListItem lstVLDS = new ListItem();
            lstVLDS = ddlVehicle_Location_Driver_State.Items.FindByValue(objAL_FR.Vehicle_Location_Driver_State.ToString());
            //check if Listitem is not null than List item selected = true
            if (lstVLDS != null)
                lstVLDS.Selected = true;

            txtVehicle_Location_Driver_ZipCode.Text = objAL_FR.Vehicle_Location_Driver_ZipCode;
            txtOwner_Name.Text = objAL_FR.Owner_Name;
            txtOwner_Address_1.Text = objAL_FR.Owner_Address_1;
            //check owner name and owner address. if value is not null than no require to validate these Panel.
            if (!string.IsNullOrEmpty(objAL_FR.Owner_Name) && !string.IsNullOrEmpty(objAL_FR.Owner_Address_1))
            {
                hdnInsured.Value = "1";
            }
            else
            {
                hdnInsured.Value = "0";
            }
            txtOwner_Work_Phone.Text = objAL_FR.Owner_Work_Phone;
            txtOwner_Home_Phone.Text = objAL_FR.Owner_Home_Phone;
            txtOwner_Alternate_Phone.Text = objAL_FR.Owner_Alternate_Phone;
            txtOwner_Address_2.Text = objAL_FR.Owner_Address_2;
            txtOwner_City.Text = objAL_FR.Owner_City;
            //check object value
            if (objAL_FR.Owner_State != null)
            {
                ListItem lstOS = new ListItem();
                lstOS = ddlOwner_State.Items.FindByValue(objAL_FR.Owner_State.ToString());
                //check if listitem isnot null than Listitem selcted
                if (lstOS != null)
                    lstOS.Selected = true;
            }
            txtOwner_ZipCode.Text = objAL_FR.Owner_ZipCode;
            #endregion

            #region Insured Vehicle Driver Information
            //set values to Object

            txtDriver_Name.Text = objAL_FR.Driver_Name;
            txtDriver_SSN.Text = objAL_FR.Driver_SSN;
            txtDriver_Address1.Text = objAL_FR.Driver_Address_1;
            txtDriver_Date_of_Birth.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Driver_Date_of_Birth);
            //check Date of Birth is not null.if not null than display age count
            if (objAL_FR.Driver_Date_of_Birth != null)
            {
                if (Convert.ToDateTime(objAL_FR.Driver_Date_of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    txtDriverAgeCount.Text = GetAge(objAL_FR.Driver_Date_of_Birth);
            }
            txtDriver_Address2.Text = objAL_FR.Driver_Address_2;
            txtDriver_City.Text = objAL_FR.Driver_City;
            txtDriver_Work_Phone.Text = objAL_FR.Driver_Work_Phone;
            //check object value
            if (objAL_FR.Driver_State != null)
            {
                ListItem lstDS = new ListItem();
                lstDS = ddlDriver_State.Items.FindByValue(objAL_FR.Driver_State.ToString());
                //check list item if not null than list item selected = true
                if (lstDS != null)
                {
                    lstDS.Selected = true;
                }
            }

            txtDriver_Home_Phone.Text = objAL_FR.Driver_Home_Phone;
            txtDriver_ZipCode.Text = objAL_FR.Driver_ZipCode;
            txtDriver_Altermate_Phone.Text = objAL_FR.Driver_Altermate_Phone;
            //check object value
            if (objAL_FR.Driver_Drivers_License_State != null)
            {
                ListItem lstDDLS = new ListItem();
                lstDDLS = ddlDriver_Drivers_License_State.Items.FindByValue(objAL_FR.Driver_Drivers_License_State.ToString());
                //check list item if not null than list item selected = true
                if (lstDDLS != null)
                {
                    lstDDLS.Selected = true;
                }
            }
            txtDriver_Drivers_License_Number.Text = objAL_FR.Driver_Drivers_License_Number;
            txtDriver_Relation_to_Insured.Text = objAL_FR.Driver_Relation_to_Insured;
            //check object value
            if (objAL_FR.Citation_Issued != null)
            {
                //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
                if (objAL_FR.Citation_Issued == true)
                    rdoCitation_Issued.SelectedValue = "Y";
                else
                    rdoCitation_Issued.SelectedValue = "N";
            }
            else
                rdoCitation_Issued.SelectedValue = "-1";

            txtCitation_Number.Text = objAL_FR.Citation_Number;
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Driver_Was_Injured != null)
            {
                if (objAL_FR.Driver_Was_Injured == true)
                    rdoDriver_Was_Injured.SelectedValue = "Y";
                else
                    rdoDriver_Was_Injured.SelectedValue = "N";
            }
            else
                rdoDriver_Was_Injured.SelectedValue = "-1";

            txtDriver_Injury_Description.Text = objAL_FR.Driver_Injury_Description;
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Driver_Sought_Medical_Attention != null)
            {
                if (objAL_FR.Driver_Sought_Medical_Attention == true)
                    rdoDriver_Sought_Medical_Attention.SelectedValue = "Y";
                else
                    rdoDriver_Sought_Medical_Attention.SelectedValue = "N";
            }
            else
                rdoDriver_Sought_Medical_Attention.SelectedValue = "-1";
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Driver_Is_Owner != null)
            {
                if (objAL_FR.Driver_Is_Owner == true)
                    rdoDriver_Is_Owner.SelectedValue = "Y";
                else
                    rdoDriver_Is_Owner.SelectedValue = "N";
            }
            else
                rdoDriver_Is_Owner.SelectedValue = "-1";

            rdoDriver_Taken_By_Emergency_Transportation.SelectedValue = (objAL_FR.Driver_Taken_By_Emergency_Transportation == true) ? "Y" : "N";
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Driver_Airlifted_Medivac != null)
            {
                if (objAL_FR.Driver_Airlifted_Medivac == true)
                    rdoDriver_Airlifted_Medivac.SelectedValue = "Y";
                else
                    rdoDriver_Airlifted_Medivac.SelectedValue = "N";
            }
            else
                rdoDriver_Airlifted_Medivac.SelectedValue = "-1";

            txtDriver_Medical_Facility_Name.Text = objAL_FR.Driver_Medical_Facility_Name;
            txtDriver_Date_Of_Initial_Treatment.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Driver_Date_Of_Initial_Treatment);
            txtDriver_Medical_Facility_Type.Text = objAL_FR.Driver_Medical_Facility_Type;
            txtDriver_Treating_Physician_Name.Text = objAL_FR.Driver_Treating_Physician_Name;
            txtDriver_Medical_Facility_Address_1.Text = objAL_FR.Driver_Medical_Facility_Address_1;
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Driver_Admitted_to_Hospital != null)
            {
                if (objAL_FR.Driver_Admitted_to_Hospital == true)
                    rdoDriver_Admitted_to_Hospital.SelectedValue = "Y";
                else
                    rdoDriver_Admitted_to_Hospital.SelectedValue = "N";
            }
            else
                rdoDriver_Admitted_to_Hospital.SelectedValue = "-1";

            txtDriver_Medical_Facility_Address_2.Text = objAL_FR.Driver_Medical_Facility_Address_2;
            txtDriver_Medical_Facility_City.Text = objAL_FR.Driver_Medical_Facility_City;
            //check object value
            if (objAL_FR.Driver_Medical_Facility_State != null)
            {
                ListItem lstDMFS = new ListItem();
                lstDMFS = ddlDriver_Medical_Facility_State.Items.FindByValue(objAL_FR.Driver_Medical_Facility_State.ToString());
                //check if ListItem is not null than ListItem is selected
                if (lstDMFS != null)
                    lstDMFS.Selected = true;
            }
            txtDriver_Medical_Facility_Zip_Code.Text = objAL_FR.Driver_Medical_Facility_ZipCode;
            //check object value.if it is true than display rekated fields else fields are remins hidden
            if (objAL_FR.Driver_Admitted_to_Hospital == true)
            {
                tdDateAdmitted.Style.Add("display", "block");
                tdStillHospital.Style.Add("display", "block");
                hdnDriver_Admitted_to_Hospital.Value = "1";
                txtDriver_Date_Admitted_to_Hospital.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Driver_Date_Admitted_to_Hospital);
                //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
                if (objAL_FR.Driver_Still_in_Hospital != null)
                {
                    if (objAL_FR.Driver_Still_in_Hospital == true)
                        rdoDriver_Still_in_Hospital.SelectedValue = "Y";
                    else
                        rdoDriver_Still_in_Hospital.SelectedValue = "N";
                }
                else
                    rdoDriver_Still_in_Hospital.SelectedValue = "-1";
            }

            #endregion

            #region Insured Vehicle Passenger Information
            //Set Values to Created Object
            txtPassenger_Name.Text = objAL_FR.Passenger_Name;
            txtPassenger_Address_1.Text = objAL_FR.Passenger_Address_1;
            txtPassenger_Date_of_Birth.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Passenger_Date_of_Birth);
            //check Date of Birth is not null.if not null than display age count
            if (objAL_FR.Passenger_Date_of_Birth != null)
            {
                if (Convert.ToDateTime(objAL_FR.Passenger_Date_of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    txtPassengerAgeCount.Text = GetAge(objAL_FR.Passenger_Date_of_Birth);
            }
            txtPassenger_Address_2.Text = objAL_FR.Passenger_Address_2;
            txtPassenger_City.Text = objAL_FR.Passenger_City;
            txtPassenger_Work_Phone.Text = objAL_FR.Passenger_Work_Phone;
            //check object value
            if (objAL_FR.Passenger_State != null)
            {
                ListItem lstPS = new ListItem();
                lstPS = ddlPassenger_State.Items.FindByValue(objAL_FR.Passenger_State.ToString());
                //check list item if not null than list item selected = true
                if (lstPS != null)
                    lstPS.Selected = true;
            }
            txtPassenger_Home_Phone.Text = objAL_FR.Passenger_Home_Phone;
            txtPassenger_ZipCode.Text = objAL_FR.Passenger_ZipCode;
            txtPassenger_Alternate_Phone.Text = objAL_FR.Passenger_Alternate_Phone;
            //check object value
            if (objAL_FR.Passenger_Drivers_License_State != null)
            {
                ListItem lstPDLS = new ListItem();
                lstPDLS = ddlPassenger_Drivers_License_State.Items.FindByValue(objAL_FR.Passenger_Drivers_License_State.ToString());
                //check list item if not null than list item selected = true
                if (lstPDLS != null)
                    lstPDLS.Selected = true;
            }
            txtPassenger_Drivers_License_Number.Text = objAL_FR.Passenger_Drivers_License_Number;
            txtPassenger_Relation_to_Insured.Text = objAL_FR.Passenger_Relation_to_Insured;
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Passenger_Was_Injured != null)
            {
                if (objAL_FR.Passenger_Was_Injured == true)
                    rdoPassenger_Was_Injured.SelectedValue = "Y";
                else
                    rdoPassenger_Was_Injured.SelectedValue = "N";
            }
            else
                rdoPassenger_Was_Injured.SelectedValue = "-1";

            txtPassenger_Description_of_Injury.Text = objAL_FR.Passenger_Description_of_Injury;
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Passenger_Sought_Medical_Attention != null)
            {
                if (objAL_FR.Passenger_Sought_Medical_Attention == true)
                    rdoPassenger_Sought_Medical_Attention.SelectedValue = "Y";
                else
                    rdoPassenger_Sought_Medical_Attention.SelectedValue = "N";
            }
            else
                rdoPassenger_Sought_Medical_Attention.SelectedValue = "-1";

            #endregion

            #region Other Vehicle Information
            //set values to controls from object
            txtOther_Vehicle_Year.Text = ((objAL_FR.Other_Vehicle_Year.ToString() == "0") ? "" : objAL_FR.Other_Vehicle_Year.ToString());
            txtOther_Vehicle_Make.Text = objAL_FR.Other_Vehicle_Make;
            txtOther_Vehicle_Model.Text = objAL_FR.Other_Vehicle_Model;
            txtOther_Vehicle_VIN.Text = objAL_FR.Other_Vehicle_VIN;
            txtOther_Vehicle_License_Plate_Number.Text = objAL_FR.Other_Vehicle_License_Plate_Number;
            //check object value
            if (objAL_FR.Other_Vehicle_License_Plate_State != null)
            {
                ListItem lstOVLPS = new ListItem();
                lstOVLPS = ddlOther_Vehicle_License_Plate_State.Items.FindByValue(objAL_FR.Other_Vehicle_License_Plate_State.ToString());
                //check ListItem is not null. if true than ListItem selected is true
                if (lstOVLPS != null)
                    lstOVLPS.Selected = true;
            }
            txtOther_Vehicle_Vehicle_Color.Text = objAL_FR.Other_Vehicle_Vehicle_Color;
            txtOther_Vehicle_Insurance_Co_Name.Text = objAL_FR.Other_Vehicle_Insurance_Co_Name;
            txtOther_Vehicle_Insurance_Co_Phone.Text = objAL_FR.Other_Vehicle_Insurance_Co_Phone;
            txtPassenger_Description_of_Injury.Text = objAL_FR.Passenger_Description_of_Injury;
            txtOther_Vehicle_Insurance_Policy_Number.Text = objAL_FR.Other_Vehicle_Insurance_Policy_Number;
            txtOther_Vehicle_Vehicle_Damage_Description.Text = objAL_FR.Other_Vehicle_Vehicle_Damage_Description;
            rdoOther_Vehicle_Repairs_Completed.SelectedValue = (objAL_FR.Other_Vehicle_Repairs_Completed == true) ? "Y" : "N";
            txtOther_Vehicle_Repairs_Estimated_Amount.Text = objAL_FR.Other_Vehicle_Repairs_Estimated_Amount;
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Other_Vehicle_Drivable != null)
            {
                if (objAL_FR.Other_Vehicle_Drivable == true)
                    rdoOther_Vehicle_Drivable.SelectedValue = "Y";
                else
                    rdoOther_Vehicle_Drivable.SelectedValue = "N";
            }
            else
                rdoOther_Vehicle_Drivable.SelectedValue = "-1";

            txtOther_Vehicle_Location.Text = objAL_FR.Other_Vehicle_Location;
            txtOther_Vehicle_Location_Telephone.Text = objAL_FR.Other_Vehicle_Location_Telephone;
            txtOther_Vehicle_Location_Driver_Address_1.Text = objAL_FR.Other_Vehicle_Location_Driver_Address_1;
            txtOther_Vehicle_Location_Driver_Address_2.Text = objAL_FR.Other_Vehicle_Location_Driver_Address_2;
            txtOther_Vehicle_Location_Driver_City.Text = objAL_FR.Other_Vehicle_Location_Driver_City;
            //check object value
            if (objAL_FR.Other_Vehicle_Location_Driver_State != null)
            {
                ListItem lstOVLDS = new ListItem();
                lstOVLDS = ddlOther_Vehicle_Location_Driver_State.Items.FindByValue(objAL_FR.Other_Vehicle_Location_Driver_State.ToString());
                //check list item if not null than list item selected = true
                if (lstOVLDS != null)
                    lstOVLDS.Selected = true;
            }
            txtOther_Vehicle_Location_Driver_ZipCode.Text = objAL_FR.Other_Vehicle_Location_Driver_ZipCode;
            txtOther_Vehicle_Owner_Name.Text = objAL_FR.Other_Vehicle_Owner_Name;
            txtOther_Vehicle_Owner_Work_Phone.Text = objAL_FR.Other_Vehicle_Owner_Work_Phone;
            txtOther_Vehicle_Owner_Home_Phone.Text = objAL_FR.Other_Vehicle_Owner_Home_Phone;
            txtOther_Vehicle_Owner_Alternate_Phone.Text = objAL_FR.Other_Vehicle_Owner_Alternate_Phone;
            txtOther_Vehicle_Owner_Address_1.Text = objAL_FR.Other_Vehicle_Owner_Address_1;
            //check owner name and owner address. if value is not null than no require to validate these Panel.
            if (!string.IsNullOrEmpty(objAL_FR.Other_Vehicle_Owner_Name) && !string.IsNullOrEmpty(objAL_FR.Other_Vehicle_Owner_Address_1))
            {
                hdnOther.Value = "1";
            }
            else
            {
                hdnOther.Value = "0";
            }
            txtOther_Vehicle_Owner_Address_2.Text = objAL_FR.Other_Vehicle_Owner_Address_2;
            txtOther_Vehicle_Owner_City.Text = objAL_FR.Other_Vehicle_Owner_City;
            //check object value
            if (objAL_FR.Other_Vehicle_Owner_State != null)
            {
                ListItem lstOVOS = new ListItem();
                lstOVOS = ddlOther_Vehicle_Owner_State.Items.FindByValue(objAL_FR.Other_Vehicle_Owner_State.ToString());
                //check list item if not null than list item selected = true
                if (lstOVOS != null)
                    lstOVOS.Selected = true;
            }
            txtOther_Vehicle_Owner_ZipCode.Text = objAL_FR.Other_Vehicle_Owner_ZipCode;
            #endregion

            #region Other Vehicle Driver Information
            // Set Values to controls from object
            txtOther_Driver_Name.Text = objAL_FR.Other_Driver_Name;
            txtOther_Driver_SSN.Text = objAL_FR.Other_Driver_SSN;
            txtOther_Driver_Address_1.Text = objAL_FR.Other_Driver_Address_1;
            txtOther_Driver_Date_of_Birth.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Other_Driver_Date_of_Birth);
            //check Date of Birth is not null.if not null than display age count
            if (objAL_FR.Other_Driver_Date_of_Birth != null)
            {
                if (Convert.ToDateTime(objAL_FR.Other_Driver_Date_of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    txtOther_Driver_AgeCount.Text = GetAge(objAL_FR.Other_Driver_Date_of_Birth);
            }
            txtOther_Driver_Address_2.Text = objAL_FR.Other_Driver_Address_2;
            txtOther_Driver_City.Text = objAL_FR.Other_Driver_City;
            //check object value
            if (objAL_FR.Other_Driver_State != null)
            {
                ListItem lstODS = new ListItem();
                lstODS = ddlOther_Driver_State.Items.FindByValue(objAL_FR.Other_Driver_State.ToString());
                //check Null for ListItem
                if (lstODS != null)
                    lstODS.Selected = true;
            }
            txtOther_Driver_Home_Phone.Text = objAL_FR.Other_Driver_Home_Phone;
            txtOther_Driver_Work_Phone.Text = objAL_FR.Other_Driver_Work_Phone;
            txtOther_Driver_ZipCode.Text = objAL_FR.Other_Driver_ZipCode;
            txtOther_Driver_Drivers_License_Number.Text = objAL_FR.Other_Driver_Drivers_License_Number;
            txtOther_Driver_Gender.Text = objAL_FR.Other_Driver_Gender;
            //check object value
            if (objAL_FR.Other_Driver_Drivers_License_State != null)
            {
                ListItem lstODDL = new ListItem();
                lstODDL = ddlOther_Driver_Drivers_License_State.Items.FindByValue(objAL_FR.Other_Driver_Drivers_License_State.ToString());
                //check Null for ListItem
                if (lstODDL != null)
                    lstODDL.Selected = true;

            }
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Other_Driver_Citation_Issued != null)
            {
                if (objAL_FR.Other_Driver_Citation_Issued == true)
                    rdoOther_Driver_Citation_Issued.SelectedValue = "Y";
                else
                    rdoOther_Driver_Citation_Issued.SelectedValue = "N";
            }
            else
                rdoOther_Driver_Citation_Issued.SelectedValue = "-1";

            txtOther_Driver_Citation_Number.Text = objAL_FR.Other_Driver_Citation_Number;
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Other_Driver_Injured != null)
            {
                if (objAL_FR.Other_Driver_Injured == true)
                    rdoOther_Driver_Injured.SelectedValue = "Y";
                else
                    rdoOther_Driver_Injured.SelectedValue = "N";
            }
            else
                rdoOther_Driver_Injured.SelectedValue = "-1";


            txtOther_Driver_Injury_Description.Text = objAL_FR.Other_Driver_Injury_Description;
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Other_Driver_Sought_Medical_Attention != null)
            {
                if (objAL_FR.Other_Driver_Sought_Medical_Attention == true)
                    rdoOther_Driver_Sought_Medical_Attention.SelectedValue = "Y";
                else
                    rdoOther_Driver_Sought_Medical_Attention.SelectedValue = "N";
            }
            else
                rdoOther_Driver_Sought_Medical_Attention.SelectedValue = "-1";

            rdoOther_Driver_Taken_By_Emergency_Transportation.SelectedValue = (objAL_FR.Other_Driver_Taken_By_Emergency_Transportation == true) ? "Y" : "N";
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Other_Driver_Airlifted_Medivac != null)
            {
                if (objAL_FR.Other_Driver_Airlifted_Medivac == true)
                    rdoOther_Driver_Airlifted_Medivac.SelectedValue = "Y";
                else
                    rdoOther_Driver_Airlifted_Medivac.SelectedValue = "N";
            }
            else
                rdoOther_Driver_Airlifted_Medivac.SelectedValue = "-1";
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Other_Driver_Admitted_to_Hospital != null)
            {
                if (objAL_FR.Other_Driver_Admitted_to_Hospital == true)
                    rdoOther_Driver_Admitted_to_Hospital.SelectedValue = "Y";
                else
                    rdoOther_Driver_Admitted_to_Hospital.SelectedValue = "N";
            }
            else
                rdoOther_Driver_Admitted_to_Hospital.SelectedValue = "-1";

            txtOther_Driver_Medical_Facility_Name.Text = objAL_FR.Other_Driver_Medical_Facility_Name;
            txtOther_Driver_Medical_Facility_Address_1.Text = objAL_FR.Other_Driver_Medical_Facility_Address_1;
            txtOther_Driver_Medical_Facility_Address_2.Text = objAL_FR.Other_Driver_Medical_Facility_Address_2;
            //check object value
            if (objAL_FR.Other_Driver_Admitted_to_Hospital == true)
            {
                tdOth_Driver_DateAdmitted.Style.Add("display", "block");
                tdOth_Driver_StillHospital.Style.Add("display", "block");
                txtOther_Driver_Date_Admitted_to_Hospital.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Other_Driver_Date_Admitted_to_Hospital);
                //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
                if (objAL_FR.Other_Driver_Still_in_Hospital != null)
                {
                    if (objAL_FR.Other_Driver_Still_in_Hospital == true)
                        rdoOther_Driver_Still_in_Hospital.SelectedValue = "Y";
                    else
                        rdoOther_Driver_Still_in_Hospital.SelectedValue = "N";
                }
                else
                    rdoOther_Driver_Still_in_Hospital.SelectedValue = "-1";
            }
            txtOther_Driver_Medical_Facility_City.Text = objAL_FR.Other_Driver_Medical_Facility_City;
            txtOther_Driver_Physicians_Name.Text = objAL_FR.Other_Driver_Physicians_Name;
            //check object value
            if (objAL_FR.Other_Driver_Medical_Facility_State != null)
            {
                ListItem lstODMF = new ListItem();
                lstODMF = ddlOther_Driver_Medical_Facility_State.Items.FindByValue(objAL_FR.Other_Driver_Medical_Facility_State.ToString());
                //check null for ListItem
                if (lstODMF != null)
                    lstODMF.Selected = true;
            }
            txtOther_Driver_Medical_Facility_Zip_Code.Text = objAL_FR.Other_Driver_Medical_Facility_Zip_Code;
            txtOther_Driver_Medical_Facility_Type.Text = objAL_FR.Other_Driver_Medical_Facility_Type;

            #endregion

            #region Other Vehicle Passenger Information

            // Set Values to Object
            txtOth_Veh_Pass_Name.Text = objAL_FR.Oth_Veh_Pass_Name;
            txtOth_Veh_Pass_Date_of_Birth.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Oth_Veh_Pass_Date_of_Birth);
            //check Date of Birth is not null.if not null than display age count
            if (objAL_FR.Oth_Veh_Pass_Date_of_Birth != null)
            {
                if (Convert.ToDateTime(objAL_FR.Oth_Veh_Pass_Date_of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    txtOth_Veh_Pass_AgeCount.Text = GetAge(objAL_FR.Oth_Veh_Pass_Date_of_Birth);
            }
            txtOth_Veh_Pass_Address_1.Text = objAL_FR.Oth_Veh_Pass_Address_1;
            txtOth_Veh_Pass_Address_2.Text = objAL_FR.Oth_Veh_Pass_Address_2;
            txtOth_Veh_Pass_City.Text = objAL_FR.Oth_Veh_Pass_City;
            //check object value
            if (objAL_FR.Oth_Veh_Pass_State != null)
            {
                ListItem lstOVPS = new ListItem();
                lstOVPS = ddlOth_Veh_Pass_State.Items.FindByValue(objAL_FR.Oth_Veh_Pass_State.ToString());
                //check null for ListItem
                if (lstOVPS != null)
                    lstOVPS.Selected = true;
            }
            txtOth_Veh_Pass_Home_Phone.Text = objAL_FR.Oth_Veh_Pass_Home_Phone;
            txtOth_Veh_Pass_Work_Phone.Text = objAL_FR.Oth_Veh_Pass_Work_Phone;
            txtOth_Veh_Pass_Alternate_Phone.Text = objAL_FR.Oth_Veh_Pass_Alternate_Phone;
            txtOth_Veh_Pass_ZipCode.Text = objAL_FR.Oth_Veh_Pass_ZipCode;
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Oth_Veh_Pass_Injured != null)
            {
                if (objAL_FR.Oth_Veh_Pass_Injured == true)
                    rdoOth_Veh_Pass_Injured.SelectedValue = "Y";
                else
                    rdoOth_Veh_Pass_Injured.SelectedValue = "N";
            }
            else
                rdoOth_Veh_Pass_Injured.SelectedValue = "-1";
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Oth_Veh_Pass_Injured != null)
            {
                if (objAL_FR.Oth_Veh_Pass_Injured == true)
                    rdoOth_Veh_Pass_Injured.SelectedValue = "Y";
                else
                    rdoOth_Veh_Pass_Injured.SelectedValue = "N";
            }
            else
                rdoOth_Veh_Pass_Injured.SelectedValue = "-1";
            //check object value
            if (objAL_FR.Oth_Veh_Pass_Injured != null)
            {
                //check object value
                if (objAL_FR.Oth_Veh_Pass_Injured == true)
                    rdoOth_Veh_Pass_Injured.SelectedValue = "Y";
                else
                    rdoOth_Veh_Pass_Injured.SelectedValue = "N";
            }
            else
                rdoOth_Veh_Pass_Injured.SelectedValue = "-1";


            txtOth_Veh_Pass_Injury_Description.Text = objAL_FR.Oth_Veh_Pass_Injury_Description;
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Oth_Veh_Pass_Sought_Medical_Attention != null)
            {
                if (objAL_FR.Oth_Veh_Pass_Sought_Medical_Attention == true)
                    rdoOth_Veh_Pass_Sought_Medical_Attention.SelectedValue = "Y";
                else
                    rdoOth_Veh_Pass_Sought_Medical_Attention.SelectedValue = "N";
            }
            else
                rdoOth_Veh_Pass_Sought_Medical_Attention.SelectedValue = "-1";

            rdoOth_Veh_Pass_Taken_By_Emergency_Transportation.Text = ((objAL_FR.Oth_Veh_Pass_Taken_By_Emergency_Transportation == true) ? "Y" : "N");
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Oth_Veh_Pass_Airlifted_Medivac != null)
            {
                if (objAL_FR.Oth_Veh_Pass_Airlifted_Medivac == true)
                    rdoOth_Veh_Pass_Airlifted_Medivac.SelectedValue = "Y";
                else
                    rdoOth_Veh_Pass_Airlifted_Medivac.SelectedValue = "N";
            }
            else
                rdoOth_Veh_Pass_Airlifted_Medivac.SelectedValue = "-1";
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Oth_Veh_Pass_Admitted_to_Hospital != null)
            {
                if (objAL_FR.Oth_Veh_Pass_Admitted_to_Hospital == true)
                    rdoOth_Veh_Pass_Admitted_to_Hospital.SelectedValue = "Y";
                else
                    rdoOth_Veh_Pass_Admitted_to_Hospital.SelectedValue = "N";
            }
            else
                rdoOth_Veh_Pass_Admitted_to_Hospital.SelectedValue = "-1";


            txtOth_Veh_Pass_Medical_Facility_Name.Text = objAL_FR.Oth_Veh_Pass_Medical_Facility_Name;
            txtOth_Veh_Pass_Medical_Facility_Address_1.Text = objAL_FR.Oth_Veh_Pass_Medical_Facility_Address_1;
            txtOth_Veh_Pass_Medical_Facility_Address_2.Text = objAL_FR.Oth_Veh_Pass_Medical_Facility_Address_2;
            //check object value
            if (objAL_FR.Oth_Veh_Pass_Admitted_to_Hospital == true)
            {
                tdOth_Ven_Pass_DateAdmitted.Style.Add("display", "block");
                tdOth_Ven_Pass_StillHospital.Style.Add("display", "block");
                txtOth_Veh_Pass_Date_Admitted_to_Hospital.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Oth_Veh_Pass_Date_Admitted_to_Hospital);
                //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
                if (objAL_FR.Oth_Veh_Pass_Still_in_Hospital != null)
                {
                    if (objAL_FR.Oth_Veh_Pass_Still_in_Hospital == true)
                        rdoOth_Veh_Pass_Still_in_Hospital.SelectedValue = "Y";
                    else
                        rdoOth_Veh_Pass_Still_in_Hospital.SelectedValue = "N";
                }
                else
                    rdoOth_Veh_Pass_Still_in_Hospital.SelectedValue = "-1";
            }
            txtOth_Veh_Pass_Medical_Facility_City.Text = objAL_FR.Oth_Veh_Pass_Medical_Facility_City;
            txtOth_Veh_Pass_Physicians_Name.Text = objAL_FR.Oth_Veh_Pass_Physicians_Name;
            ListItem lstOVPMF = new ListItem();
            lstOVPMF = ddlOth_Veh_Pass_Medical_Facility_State.Items.FindByValue(objAL_FR.Oth_Veh_Pass_Medical_Facility_State.ToString());
            //check null for ListItem
            if (lstOVPMF != null)
                lstOVPMF.Selected = true;
            txtOth_Veh_Pass_Medical_Facility_Zip_Code.Text = objAL_FR.Oth_Veh_Pass_Medical_Facility_ZipCode;
            txtOth_Veh_Pass_Medical_Facility_Type.Text = objAL_FR.Oth_Veh_Pass_Medical_Facility_Type;

            #endregion

            #region Pedestrian Information
            // Set Values to Object
            txtPedestrian_Name.Text = objAL_FR.Pedestrian_Name;
            txtPedestrian_Date_of_Birth.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Pedestrian_Date_of_Birth);
            //check Date of Birth is not null.if not null than display age count
            if (objAL_FR.Pedestrian_Date_of_Birth != null)
            {
                if (Convert.ToDateTime(objAL_FR.Pedestrian_Date_of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    txtPedestrianAgeCount.Text = GetAge(objAL_FR.Pedestrian_Date_of_Birth);
            }
            txtPedestrian_Address_1.Text = objAL_FR.Pedestrian_Address_1;
            txtPedestrian_Address_2.Text = objAL_FR.Pedestrian_Address_2;
            txtPedestrian_City.Text = objAL_FR.Pedestrian_City;
            //check object value
            if (objAL_FR.Pedestrian_State != null)
            {
                ListItem lstPS = new ListItem();
                lstPS = ddlPedestrian_State.Items.FindByValue(objAL_FR.Pedestrian_State.ToString());
                //check null for ListItem
                if (lstPS != null)
                    lstPS.Selected = true;
            }
            txtPedestrian_Home_Phone.Text = objAL_FR.Pedestrian_Home_Phone;
            txtPedestrian_Work_Phone.Text = objAL_FR.Pedestrian_Work_Phone;
            txtPedestrian_Alternate_Phone.Text = objAL_FR.Pedestrian_Alternate_Phone;
            txtPedestrian_ZipCode.Text = objAL_FR.Pedestrian_ZipCode;
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Pedestrian_Injured != null)
            {
                if (objAL_FR.Pedestrian_Injured == true)
                    rdoPedestrian_Injured.SelectedValue = "Y";
                else
                    rdoPedestrian_Injured.SelectedValue = "N";
            }
            else
                rdoPedestrian_Injured.SelectedValue = "-1";

            txtPedestrian_Injury_Description.Text = objAL_FR.Pedestrian_Injury_Description;
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Pedestrian_Sought_Medical_Attention != null)
            {
                if (objAL_FR.Pedestrian_Sought_Medical_Attention == true)
                    rdoPedestrian_Sought_Medical_Attention.SelectedValue = "Y";
                else
                    rdoPedestrian_Sought_Medical_Attention.SelectedValue = "N";
            }
            else
                rdoPedestrian_Sought_Medical_Attention.SelectedValue = "-1";

            rdoPedestrian_Taken_By_Emergency_Transportation.Text = (objAL_FR.Pedestrian_Taken_By_Emergency_Transportation == true) ? "Y" : "N";
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Pedestrian_Airlifted_Medivac != null)
            {
                if (objAL_FR.Pedestrian_Airlifted_Medivac == true)
                    rdoPedestrian_Airlifted_Medivac.SelectedValue = "Y";
                else
                    rdoPedestrian_Airlifted_Medivac.SelectedValue = "N";
            }
            else
                rdoPedestrian_Airlifted_Medivac.SelectedValue = "-1";
            //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
            if (objAL_FR.Pedestrian_Admitted_to_Hospital != null)
            {
                if (objAL_FR.Pedestrian_Admitted_to_Hospital == true)
                    rdoPedestrian_Admitted_to_Hospital.SelectedValue = "Y";
                else
                    rdoPedestrian_Admitted_to_Hospital.SelectedValue = "N";
            }
            else
                rdoPedestrian_Admitted_to_Hospital.SelectedValue = "-1";

            txtPedestrian_Medical_Facility_Name.Text = objAL_FR.Pedestrian_Medical_Facility_Name;
            txtPedestrian_Medical_Facility_Address_1.Text = objAL_FR.Pedestrian_Medical_Facility_Address_1;
            txtPedestrian_Medical_Facility_Address_2.Text = objAL_FR.Pedestrian_Medical_Facility_Address_2;
            //check object value
            if (objAL_FR.Pedestrian_Admitted_to_Hospital == true)
            {
                tdPedestrian_DateAdmitted.Style.Add("display", "block");
                tdPedestrian_StillHospital.Style.Add("display", "block");
                txtPedestrian_Date_Admitted_to_Hospital.Text = clsGeneral.FormatDateToDisplay(objAL_FR.Pedestrian_Date_Admitted_to_Hospital);
                //check value if it is null than selected value "-1" else if it is true than selected value "Y" else "N"
                if (objAL_FR.Pedestrian_Still_in_Hospital != null)
                {
                    if (objAL_FR.Pedestrian_Still_in_Hospital == true)
                        rdoPedestrian_Still_in_Hospital.SelectedValue = "Y";
                    else
                        rdoPedestrian_Still_in_Hospital.SelectedValue = "N";
                }
                else
                    rdoPedestrian_Still_in_Hospital.SelectedValue = "-1";
            }
            txtPedestrian_Medical_Facility_City.Text = objAL_FR.Pedestrian_Medical_Facility_City;
            txtPedestrian_Physicians_Name.Text = objAL_FR.Pedestrian_Physicians_Name;
            //check object value
            if (objAL_FR.Pedestrian_Medical_Facility_State != null)
            {
                ListItem lstPMFS = new ListItem();
                lstPMFS = ddlPedestrian_Medical_Facility_State.Items.FindByValue(objAL_FR.Pedestrian_Medical_Facility_State.ToString());
                //check null for ListItem
                if (lstPMFS != null)
                    lstPMFS.Selected = true;
            }
            txtPedestrian_Medical_Facility_Zip_Code.Text = objAL_FR.Pedestrian_Medical_Facility_Zip_Code;
            txtPedestrian_Medical_Facility_Type.Text = objAL_FR.Pedestrian_Medical_Facility_Type;
            #endregion

            #region Witness Information
            // set Vallue to Object
            txtWitness_Name.Text = objAL_FR.Witness_Name;
            txtWitness_Address_1.Text = objAL_FR.Witness_Address_1;
            txtWitness_Address_2.Text = objAL_FR.Witness_Address_2;
            txtWitness_City.Text = objAL_FR.Witness_City;
            //check object value
            if (objAL_FR.Witness_State != null)
            {
                ListItem lstWS = new ListItem();
                lstWS = ddlWitness_State.Items.FindByValue(objAL_FR.Witness_State.ToString());
                //check null for ListItem
                if (lstWS != null)
                    lstWS.Selected = true;
            }
            txtWitness_Zip_Code.Text = objAL_FR.Witness_ZipCode;
            txtWitness_Home_Phone.Text = objAL_FR.Witness_Home_Phone;
            txtWitness_Work_Phone.Text = objAL_FR.Witness_Work_Phone;
            txtWitness_Alternate_Phone.Text = objAL_FR.Witness_Alternate_Phone;

            #endregion

            #region Comments and Attachments
            //Comments and Attachments
            txtComments.Text = objAL_FR.Comments;
            CtrlViewAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.AL_FR, PK_AL_FR_ID, false, 11);
            CtrlViewAttachDetails.Bind();
            #endregion
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
    public string GenerateEMailBody(out string FirstReportNumber)
    {
        string strFilePath = HttpContext.Current.Server.MapPath("~/EmailTemplate/AL_FR.htm");
        string strEbdy = clsGeneral.ReadTextFile(strFilePath);
        if (string.IsNullOrEmpty(strEbdy))
        {
            FirstReportNumber = "";
            return "";
        }
        else
        {
            //Check First Report Wizard ID. if Greater than Zero than update data in First Report Wizard table.
            if (First_Report_Wizard_ID > 0)
            {
                //Declare Object of WC_FR table
                AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);

                #region Location/Contact Information
                DataSet dsWizardInfo = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.AL_FR, PK_AL_FR_ID);
                DataTable dtWizardInfo = dsWizardInfo.Tables[0];
                DataRow drWizardInfo = dtWizardInfo.Rows[0];

                #region Fill Location Information Controls

                FirstReportNumber = drWizardInfo["FK_First_Report_ID"].ToString();
                decimal FR_Number = new AL_FR(FirstReportNumber.ToString() != string.Empty ? Convert.ToDecimal(FirstReportNumber) : 0).AL_FR_Number;
                strEbdy = strEbdy.Replace("[lblFirstReportNumber]", "AL-" + FR_Number.ToString());
                //select value from Location Number Dropdown
                if (drWizardInfo["Sonic_Location_Code"] != null)
                    strEbdy = strEbdy.Replace("[lblLocationNumber]", drWizardInfo["Sonic_Location_Code"].ToString());
                else
                    strEbdy = strEbdy.Replace("[lblLocationNumber]", "");

                //select value from Location d/b/a Dropdown
                if (drWizardInfo["dba"] != null)
                    strEbdy = strEbdy.Replace("[lblLocationdba]", drWizardInfo["dba"].ToString());
                else
                    strEbdy = strEbdy.Replace("[lblLocationdba]", "");

                //select value from Location f/k/a Dropdown
                if (drWizardInfo["FK_Location_ID"] != null)
                    strEbdy = strEbdy.Replace("[lblLocationfka]", new LU_Location_FKA(Convert.ToDecimal(drWizardInfo["FK_Location_ID"])).fka);
                else
                    strEbdy = strEbdy.Replace("[lblLocationfka]", "");

                //select value from Location Legal Entity Dropdown
                //if (drWizardInfo["legal_entity"] != null)
                //    strEbdy = strEbdy.Replace("[lblLegalEntity]", drWizardInfo["legal_entity"].ToString());
                //else
                //    strEbdy = strEbdy.Replace("[lblLegalEntity]", "");

                //set address1,address2,city,state,ZipCOde Values
                strEbdy = strEbdy.Replace("[lblLocationAddress1]", (drWizardInfo["Address_1"] != null) ? Convert.ToString(drWizardInfo["Address_1"]) : "");
                strEbdy = strEbdy.Replace("[lblLocationAddress2]", (drWizardInfo["Address_2"] != null) ? Convert.ToString(drWizardInfo["Address_2"]) : "");
                strEbdy = strEbdy.Replace("[lblLocationCity]", (drWizardInfo["City"] != null) ? Convert.ToString(drWizardInfo["City"]) : "");
                strEbdy = strEbdy.Replace("[lblLocationState]", new State(!string.IsNullOrEmpty(Convert.ToString(drWizardInfo["State"])) ? Convert.ToDecimal(drWizardInfo["State"]) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblLocationZipCode]", (drWizardInfo["Zip_Code"] != null) ? Convert.ToString(drWizardInfo["Zip_Code"]) : "");

                #endregion

                #region Fill Contact Information Controls

                strEbdy = strEbdy.Replace("[lblContactName]", (drWizardInfo["EmployeeName"] != null) ? Convert.ToString(drWizardInfo["EmployeeName"]) : "");
                strEbdy = strEbdy.Replace("[lblContact_Best_Time]", (drWizardInfo["Contact_Best_Time"] != null) ? Convert.ToString(drWizardInfo["Contact_Best_Time"]) : "");
                strEbdy = strEbdy.Replace("[lblContactTelephoneNumber1]", (drWizardInfo["TelephoneNumber1"] != null) ? Convert.ToString(drWizardInfo["TelephoneNumber1"]) : "");
                strEbdy = strEbdy.Replace("[lblContactTelephoneNumber2]", (drWizardInfo["TelephoneNumber2"] != null) ? Convert.ToString(drWizardInfo["TelephoneNumber2"]) : "");
                strEbdy = strEbdy.Replace("[lblContactFaxNumber]", (drWizardInfo["Contact_Fax"] != null) ? Convert.ToString(drWizardInfo["Contact_Fax"]) : "");
                strEbdy = strEbdy.Replace("[lblContactEmailAddress]", (drWizardInfo["FRWEmail"] != null) ? Convert.ToString(drWizardInfo["FRWEmail"]) : "");
                //fill Controls By Cost Center Value
                strEbdy = strEbdy.Replace("[lblCostCenterdba]", (drWizardInfo["dba"] != null) ? Convert.ToString(drWizardInfo["dba"]) : "");
                strEbdy = strEbdy.Replace("[lblCostCenterAddress1]", (drWizardInfo["Address_1"] != null) ? Convert.ToString(drWizardInfo["Address_1"]) : "");
                strEbdy = strEbdy.Replace("[lblCostCenterAddress2]", (drWizardInfo["Address_2"] != null) ? Convert.ToString(drWizardInfo["Address_2"]) : "");
                strEbdy = strEbdy.Replace("[lblCostCenterCity]", (drWizardInfo["City"] != null) ? Convert.ToString(drWizardInfo["City"]) : "");
                strEbdy = strEbdy.Replace("[lblCostCenterState]", new State(!string.IsNullOrEmpty(Convert.ToString(drWizardInfo["State"])) ? Convert.ToDecimal(drWizardInfo["State"]) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblCostCenterZipCode]", (drWizardInfo["Zip_Code"] != null) ? Convert.ToString(drWizardInfo["Zip_Code"]) : "");
                #endregion
                #endregion

                #region Loss Information
                //Set Values to Objects
                strEbdy = strEbdy.Replace("[lblClaimant_state]", new State(!string.IsNullOrEmpty(objAL_FR.Claimant_state) ? Convert.ToDecimal(objAL_FR.Claimant_state) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblAuto_Liability_Type]", !string.IsNullOrEmpty(objAL_FR.FK_LU_Auto_Liability_Type) ? Convert.ToString(objAL_FR.FK_LU_Auto_Liability_Type) : "");
                strEbdy = strEbdy.Replace("[lblDate_Of_Loss]", clsGeneral.FormatDateToDisplay(objAL_FR.Date_Of_Loss));
                strEbdy = strEbdy.Replace("[lblTime_Of_Loss]", objAL_FR.Time_Of_Loss);
                strEbdy = strEbdy.Replace("[lblLoss_offsite]", (objAL_FR.Loss_offsite == true) ? "Offsite" : "Onsite");
                //check object value
                if (objAL_FR.Loss_offsite == true)
                {
                    //strEbdy = strEbdy.Replace("[trViewLossInjuryOccured]", "block");
                    strEbdy = strEbdy.Replace("[lblOffsite_Address1]", objAL_FR.Offsite_Address_1);
                    strEbdy = strEbdy.Replace("[lblOffsite_Address2]", objAL_FR.Offsite_Address_2);
                    strEbdy = strEbdy.Replace("[lblOffsite_City]", objAL_FR.Offsite_City);
                    strEbdy = strEbdy.Replace("[lblOffsite_State]", new State(!string.IsNullOrEmpty(objAL_FR.Offsite_State) ? Convert.ToDecimal(objAL_FR.Offsite_State) : 0).FLD_state);
                    strEbdy = strEbdy.Replace("[lblOffsite_zip]", objAL_FR.Offsite_zip);
                }
                else
                {
                    //strEbdy = strEbdy.Replace("[trViewLossInjuryOccured]", "none");
                    strEbdy = strEbdy.Replace("<!--[trViewLossInjuryOccured] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#trViewLossInjuryOccured] -->", "-->");
                }

                strEbdy = strEbdy.Replace("[lblDescription_Of_Loss]", objAL_FR.Description_Of_Loss);
                strEbdy = strEbdy.Replace("[lblDate_Reported_To_Sonic]", clsGeneral.FormatDateToDisplay(objAL_FR.Date_Reported_To_Sonic));
                strEbdy = strEbdy.Replace("[lblWeather_Conditions]", objAL_FR.Weather_Conditions);
                strEbdy = strEbdy.Replace("[lblRoad_Conditions]", objAL_FR.Road_Conditions);
                //check object value
                if (objAL_FR.Were_Police_Notified != null)
                {
                    if (objAL_FR.Were_Police_Notified == true)
                        strEbdy = strEbdy.Replace("[lblWere_Police_Notified]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblWere_Police_Notified]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblWere_Police_Notified]", "unknown");
                //check object value
                if (objAL_FR.Were_Police_Notified == true)
                {
                    strEbdy = strEbdy.Replace("[trViewLossPloiceNotified]", "block");
                    strEbdy = strEbdy.Replace("[lblPolice_Agency]", objAL_FR.Police_Agency);
                    strEbdy = strEbdy.Replace("[lblPolice_Case_Number]", objAL_FR.Police_Case_Number);
                    strEbdy = strEbdy.Replace("[lblPolice_Station_Phone_Number]", objAL_FR.Police_Station_Phone_Number);
                }
                else
                {
                    strEbdy = strEbdy.Replace("<!--[trViewLossPloiceNotified] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#trViewLossPloiceNotified] -->", "-->");
                    //strEbdy = strEbdy.Replace("[trViewLossPloiceNotified]", "none");
                }

                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Pedestrian_Involved != null)
                {
                    if (objAL_FR.Pedestrian_Involved == true)
                        strEbdy = strEbdy.Replace("[lblPedestrian_Involved]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblPedestrian_Involved]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblPedestrian_Involved]", "unknown");
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Property_Damage != null)
                {
                    if (objAL_FR.Property_Damage == true)
                        strEbdy = strEbdy.Replace("[lblProperty_Damage]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblProperty_Damage]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblProperty_Damage]", "unknown");
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Witnesses != null)
                {
                    if (objAL_FR.Witnesses == true)
                        strEbdy = strEbdy.Replace("[lblWitnesses]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblWitnesses]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblWitnesses]", "unknown");

                if (objAL_FR.Security_Video_System != null)
                {
                    if (objAL_FR.Security_Video_System == true)
                        strEbdy = strEbdy.Replace("[lblSecurityVideoSystem]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblSecurityVideoSystem]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblSecurityVideoSystem]", "unknown");

                #endregion

                #region Insured Vehicle Information
                //Set values to AL_FR object
                strEbdy = strEbdy.Replace("[lblVehicle_Sub_Type]", new Vehicle_Type(!string.IsNullOrEmpty(objAL_FR.Vehicle_Sub_Type) ? Convert.ToDecimal(objAL_FR.Vehicle_Sub_Type) : 0).Fld_Desc);
                strEbdy = strEbdy.Replace("[lblVehicle_Fleet_number]", objAL_FR.Vehicle_Fleet_number);
                strEbdy = strEbdy.Replace("[lblYear]", objAL_FR.Year.ToString());
                strEbdy = strEbdy.Replace("[lblMake]", objAL_FR.Make);
                strEbdy = strEbdy.Replace("[lblModel]", objAL_FR.Model);
                strEbdy = strEbdy.Replace("[lblVIN]", objAL_FR.VIN);
                strEbdy = strEbdy.Replace("[lblLicense_Plate_Number]", objAL_FR.License_Plate_Number);
                strEbdy = strEbdy.Replace("[lblLicense_Plate_State]", new State(!string.IsNullOrEmpty(objAL_FR.License_Plate_State) ? Convert.ToDecimal(objAL_FR.License_Plate_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblVehicle_Color]", objAL_FR.Vehicle_Color);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Permissive_Use != null)
                {
                    if (objAL_FR.Permissive_Use == true)
                        strEbdy = strEbdy.Replace("[lblPermissive_Use]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblPermissive_Use]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblPermissive_Use]", "unknown");
                strEbdy = strEbdy.Replace("[lblType_Of_Use]", objAL_FR.Type_Of_Use);
                strEbdy = strEbdy.Replace("[lblVehicle_Damage_Description]", objAL_FR.Vehicle_Damage_Description);
                strEbdy = strEbdy.Replace("[lblRepairs_Completed]", (objAL_FR.Repairs_Completed == true) ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[lblRepairs_Estimated_Amount]", objAL_FR.Repairs_Estimated_Amount);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Drivable != null)
                {
                    if (objAL_FR.Drivable == true)
                        strEbdy = strEbdy.Replace("[lblDrivable]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblDrivable]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblDrivable]", "unknown");
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Passengers != null)
                {
                    if (objAL_FR.Passengers == true)
                        strEbdy = strEbdy.Replace("[lblPassengers]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblPassengers]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblPassengers]", "unknown");
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Insured_Driver_At_Fault != null)
                {
                    if (objAL_FR.Insured_Driver_At_Fault == true)
                        strEbdy = strEbdy.Replace("[lblInsured_Driver_At_Fault]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblInsured_Driver_At_Fault]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblInsured_Driver_At_Fault]", "unknown");


                strEbdy = strEbdy.Replace("[lblVehicle_Location]", objAL_FR.Vehicle_Location);
                strEbdy = strEbdy.Replace("[lblVehicle_Location_Driver_Address_1]", objAL_FR.Vehicle_Location_Driver_Address_1);
                strEbdy = strEbdy.Replace("[lblVehicle_Location_Driver_Address_2]", objAL_FR.Vehicle_Location_Driver_Address_2);
                strEbdy = strEbdy.Replace("[lblVehicle_Location_Driver_City]", objAL_FR.Vehicle_Location_Driver_City);
                strEbdy = strEbdy.Replace("[lblVehicle_Location_Driver_State]", new State(objAL_FR.Vehicle_Location_Driver_State).FLD_state);
                strEbdy = strEbdy.Replace("[lblVehicle_Location_Driver_ZipCode]", objAL_FR.Vehicle_Location_Driver_ZipCode);
                strEbdy = strEbdy.Replace("[lblOwner_Name]", objAL_FR.Owner_Name);
                strEbdy = strEbdy.Replace("[lblOwner_Work_Phone]", objAL_FR.Owner_Work_Phone);
                strEbdy = strEbdy.Replace("[lblOwner_Home_Phone]", objAL_FR.Owner_Home_Phone);
                strEbdy = strEbdy.Replace("[lblOwner_Alternate_Phone]", objAL_FR.Owner_Alternate_Phone);
                strEbdy = strEbdy.Replace("[lblOwner_Address_1]", objAL_FR.Owner_Address_1);
                strEbdy = strEbdy.Replace("[lblOwner_Address_2]", objAL_FR.Owner_Address_2);
                strEbdy = strEbdy.Replace("[lblOwner_City]", objAL_FR.Owner_City);
                strEbdy = strEbdy.Replace("[lblOwner_State]", new State(!string.IsNullOrEmpty(objAL_FR.Owner_State) ? Convert.ToDecimal(objAL_FR.Owner_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblOwner_ZipCode]", objAL_FR.Owner_ZipCode);
                #endregion

                #region Insured Vehicle Driver Information
                //set values to Object

                strEbdy = strEbdy.Replace("[lblDriver_Name]", objAL_FR.Driver_Name);
                strEbdy = strEbdy.Replace("[lblDriver_SSN]", objAL_FR.Driver_SSN.Substring(Math.Max(0, objAL_FR.Driver_SSN.Length - 4)));
                strEbdy = strEbdy.Replace("[lblDriver_Address1]", objAL_FR.Driver_Address_1);
                strEbdy = strEbdy.Replace("[lblDriver_Date_of_Birth]", clsGeneral.FormatDateToDisplay(objAL_FR.Driver_Date_of_Birth));
                //check Date of Birth is not null.if not null than display age count
                if (objAL_FR.Driver_Date_of_Birth != null)
                {
                    if (Convert.ToDateTime(objAL_FR.Driver_Date_of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                        strEbdy = strEbdy.Replace("[lblDriverAgeCount]", GetAge(objAL_FR.Driver_Date_of_Birth));
                    else
                        strEbdy = strEbdy.Replace("[lblDriverAgeCount]", "");
                }
                else
                    strEbdy = strEbdy.Replace("[lblDriverAgeCount]", "");
                strEbdy = strEbdy.Replace("[lblDriver_Address2]", objAL_FR.Driver_Address_2);
                strEbdy = strEbdy.Replace("[lblDriver_City]", objAL_FR.Driver_City);
                strEbdy = strEbdy.Replace("[lblDriver_Work_Phone]", objAL_FR.Driver_Work_Phone);
                strEbdy = strEbdy.Replace("[lblDriver_State]", new State(!string.IsNullOrEmpty(objAL_FR.Driver_State) ? Convert.ToDecimal(objAL_FR.Driver_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblDriver_Home_Phone]", objAL_FR.Driver_Home_Phone);
                strEbdy = strEbdy.Replace("[lblDriver_ZipCode]", objAL_FR.Driver_ZipCode);
                strEbdy = strEbdy.Replace("[lblDriver_Altermate_Phone]", objAL_FR.Driver_Altermate_Phone);
                strEbdy = strEbdy.Replace("[lblDriver_Drivers_License_State]", new State(!string.IsNullOrEmpty(objAL_FR.Driver_Drivers_License_State) ? Convert.ToDecimal(objAL_FR.Driver_Drivers_License_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblDriver_Drivers_License_Number]", objAL_FR.Driver_Drivers_License_Number);
                strEbdy = strEbdy.Replace("[lblDriver_Relation_to_Insured]", objAL_FR.Driver_Relation_to_Insured);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Citation_Issued != null)
                {
                    if (objAL_FR.Citation_Issued == true)
                        strEbdy = strEbdy.Replace("[lblCitation_Issued]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblCitation_Issued]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblCitation_Issued]", "unknown");

                strEbdy = strEbdy.Replace("[lblCitation_Number]", objAL_FR.Citation_Number);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Driver_Was_Injured != null)
                {
                    if (objAL_FR.Driver_Was_Injured == true)
                        strEbdy = strEbdy.Replace("[lblDriver_Was_Injured]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblDriver_Was_Injured]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblDriver_Was_Injured]", "unknown");

                strEbdy = strEbdy.Replace("[lblDriver_Injury_Description]", objAL_FR.Driver_Injury_Description);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Driver_Sought_Medical_Attention != null)
                {
                    if (objAL_FR.Driver_Sought_Medical_Attention == true)
                        strEbdy = strEbdy.Replace("[lblDriver_Sought_Medical_Attention]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblDriver_Sought_Medical_Attention]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblDriver_Sought_Medical_Attention]", "unknown");
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Driver_Is_Owner != null)
                {
                    if (objAL_FR.Driver_Is_Owner == true)
                        strEbdy = strEbdy.Replace("[lblDriver_Is_Owner]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblDriver_Is_Owner]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblDriver_Is_Owner]", "unknown");

                strEbdy = strEbdy.Replace("[lblDriver_Taken_By_Emergency_Transportation]", (objAL_FR.Driver_Taken_By_Emergency_Transportation == true) ? "Yes" : "No");
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Driver_Airlifted_Medivac != null)
                {
                    if (objAL_FR.Driver_Airlifted_Medivac == true)
                        strEbdy = strEbdy.Replace("[lblDriver_Airlifted_Medivac]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblDriver_Airlifted_Medivac]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblDriver_Airlifted_Medivac]", "unknown");

                strEbdy = strEbdy.Replace("[lblDriver_Medical_Facility_Name]", objAL_FR.Driver_Medical_Facility_Name);
                strEbdy = strEbdy.Replace("[lblDriver_Date_Of_Initial_Treatment]", clsGeneral.FormatDateToDisplay(objAL_FR.Driver_Date_Of_Initial_Treatment));
                strEbdy = strEbdy.Replace("[lblDriver_Medical_Facility_Type]", objAL_FR.Driver_Medical_Facility_Type);
                strEbdy = strEbdy.Replace("[lblDriver_Treating_Physician_Name]", objAL_FR.Driver_Treating_Physician_Name);
                strEbdy = strEbdy.Replace("[lblDriver_Medical_Facility_Address_1]", objAL_FR.Driver_Medical_Facility_Address_1);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Driver_Admitted_to_Hospital != null)
                {
                    if (objAL_FR.Driver_Admitted_to_Hospital == true)
                        strEbdy = strEbdy.Replace("[lblDriver_Admitted_to_Hospital]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblDriver_Admitted_to_Hospital]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblDriver_Admitted_to_Hospital]", "unknown");

                strEbdy = strEbdy.Replace("[lblDriver_Medical_Facility_Address_2]", objAL_FR.Driver_Medical_Facility_Address_2);
                strEbdy = strEbdy.Replace("[lblDriver_Medical_Facility_City]", objAL_FR.Driver_Medical_Facility_City);
                strEbdy = strEbdy.Replace("[lblDriver_Medical_Facility_State]", new State(!string.IsNullOrEmpty(objAL_FR.Driver_Medical_Facility_State) ? Convert.ToDecimal(objAL_FR.Driver_Medical_Facility_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblDriver_Medical_Facility_Zip_Code]", objAL_FR.Driver_Medical_Facility_ZipCode);
                //check object value
                if (objAL_FR.Driver_Admitted_to_Hospital == true)
                {
                    strEbdy = strEbdy.Replace("[lblDriver_Date_Admitted_to_Hospital]", clsGeneral.FormatDateToDisplay(objAL_FR.Driver_Date_Admitted_to_Hospital));
                    //check object value.if not null than display related fields else that fields are remain hidden
                    if (objAL_FR.Driver_Still_in_Hospital != null)
                    {
                        //strEbdy = strEbdy.Replace("[tdViewDateAdmitted]", "block");
                        //strEbdy = strEbdy.Replace("[tdViewStillHospital]", "block");
                        //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                        if (objAL_FR.Driver_Still_in_Hospital == true)
                            strEbdy = strEbdy.Replace("[lblDriver_Still_in_Hospital]", "Yes");
                        else
                            strEbdy = strEbdy.Replace("[lblDriver_Still_in_Hospital]", "No");
                    }
                    else
                    {
                        strEbdy = strEbdy.Replace("<!--[tdViewDateAdmitted] -->", "<!--");
                        strEbdy = strEbdy.Replace("<!--[#tdViewDateAdmitted] -->", "-->");
                        //strEbdy = strEbdy.Replace("[tdViewDateAdmitted]", "none");
                        strEbdy = strEbdy.Replace("<!--[tdViewStillHospital] -->", "<!--");
                        strEbdy = strEbdy.Replace("<!--[#tdViewStillHospital] -->", "-->");
                        //strEbdy = strEbdy.Replace("[tdViewStillHospital]", "none");
                        strEbdy = strEbdy.Replace("[lblDriver_Still_in_Hospital]", "unknown");
                    }
                }
                else
                {
                    strEbdy = strEbdy.Replace("<!--[tdViewDateAdmitted] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewDateAdmitted] -->", "-->");
                    //strEbdy = strEbdy.Replace("[tdViewDateAdmitted]", "none");
                    strEbdy = strEbdy.Replace("<!--[tdViewStillHospital] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewStillHospital] -->", "-->");
                    //strEbdy = strEbdy.Replace("[tdViewStillHospital]", "none");
                }

                #endregion

                #region Insured Vehicle Passenger Information
                //Set Values to Created Object
                strEbdy = strEbdy.Replace("[lblPassenger_Name]", objAL_FR.Passenger_Name);
                strEbdy = strEbdy.Replace("[lblPassenger_Address_1]", objAL_FR.Passenger_Address_1);
                strEbdy = strEbdy.Replace("[lblPassenger_Date_of_Birth]", clsGeneral.FormatDateToDisplay(objAL_FR.Passenger_Date_of_Birth));
                //check Date of Birth is not null.if not null than display age count
                if (objAL_FR.Passenger_Date_of_Birth != null)
                {
                    if (Convert.ToDateTime(objAL_FR.Passenger_Date_of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                        strEbdy = strEbdy.Replace("[lblPassengerAgeCount]", GetAge(objAL_FR.Passenger_Date_of_Birth));
                    else
                        strEbdy = strEbdy.Replace("[lblPassengerAgeCount]", "");
                }
                else
                    strEbdy = strEbdy.Replace("[lblPassengerAgeCount]", "");
                strEbdy = strEbdy.Replace("[lblPassenger_Address_2]", objAL_FR.Passenger_Address_2);
                strEbdy = strEbdy.Replace("[lblPassenger_City]", objAL_FR.Passenger_City);
                strEbdy = strEbdy.Replace("[lblPassenger_Work_Phone]", objAL_FR.Passenger_Work_Phone);
                strEbdy = strEbdy.Replace("[lblPassenger_State]", new State(!string.IsNullOrEmpty(objAL_FR.Passenger_State) ? Convert.ToDecimal(objAL_FR.Passenger_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblPassenger_Home_Phone]", objAL_FR.Passenger_Home_Phone);
                strEbdy = strEbdy.Replace("[lblPassenger_ZipCode]", objAL_FR.Passenger_ZipCode);
                strEbdy = strEbdy.Replace("[lblPassenger_Alternate_Phone]", objAL_FR.Passenger_Alternate_Phone);
                strEbdy = strEbdy.Replace("[lblPassenger_Drivers_License_State]", new State(!string.IsNullOrEmpty(objAL_FR.Passenger_Drivers_License_State) ? Convert.ToDecimal(objAL_FR.Passenger_Drivers_License_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblPassenger_Drivers_License_Number]", objAL_FR.Passenger_Drivers_License_Number);
                strEbdy = strEbdy.Replace("[lblPassenger_Relation_to_Insured]", objAL_FR.Passenger_Relation_to_Insured);
                //check object null value
                if (objAL_FR.Passenger_Was_Injured != null)
                {
                    //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                    if (objAL_FR.Passenger_Was_Injured == true)
                        strEbdy = strEbdy.Replace("[lblPassenger_Was_Injured]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblPassenger_Was_Injured]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblPassenger_Was_Injured]", "unknown");

                strEbdy = strEbdy.Replace("[lblPassenger_Description_of_Injury]", objAL_FR.Passenger_Description_of_Injury);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Passenger_Sought_Medical_Attention != null)
                {
                    if (objAL_FR.Passenger_Sought_Medical_Attention == true)
                        strEbdy = strEbdy.Replace("[lblPassenger_Sought_Medical_Attention]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblPassenger_Sought_Medical_Attention]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblPassenger_Sought_Medical_Attention]", "unknown");

                #endregion

                #region Other Vehicle Information
                //set values to object
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Year]", (objAL_FR.Other_Vehicle_Year.ToString()));
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Make]", objAL_FR.Other_Vehicle_Make);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Model]", objAL_FR.Other_Vehicle_Model);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_VIN]", objAL_FR.Other_Vehicle_VIN);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_License_Plate_Number]", objAL_FR.Other_Vehicle_License_Plate_Number);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_License_Plate_State]", new State(!string.IsNullOrEmpty(objAL_FR.Other_Vehicle_License_Plate_State) ? Convert.ToDecimal(objAL_FR.Other_Vehicle_License_Plate_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Vehicle_Color]", objAL_FR.Other_Vehicle_Vehicle_Color);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Insurance_Co_Name]", objAL_FR.Other_Vehicle_Insurance_Co_Name);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Insurance_Co_Phone]", objAL_FR.Other_Vehicle_Insurance_Co_Phone);
                strEbdy = strEbdy.Replace("[lblPassenger_Description_of_Injury]", objAL_FR.Passenger_Description_of_Injury);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Insurance_Policy_Number]", objAL_FR.Other_Vehicle_Insurance_Policy_Number);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Vehicle_Damage_Description]", objAL_FR.Other_Vehicle_Vehicle_Damage_Description);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Repairs_Completed]", (objAL_FR.Other_Vehicle_Repairs_Completed == true) ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Repairs_Estimated_Amount]", objAL_FR.Other_Vehicle_Repairs_Estimated_Amount);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Other_Vehicle_Drivable != null)
                {
                    if (objAL_FR.Other_Vehicle_Drivable == true)
                        strEbdy = strEbdy.Replace("[lblOther_Vehicle_Drivable]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblOther_Vehicle_Drivable]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblOther_Vehicle_Drivable]", "unknown");

                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Location]", objAL_FR.Other_Vehicle_Location);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Location_Telephone]", objAL_FR.Other_Vehicle_Location_Telephone);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Location_Driver_Address_1]", objAL_FR.Other_Vehicle_Location_Driver_Address_1);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Location_Driver_Address_2]", objAL_FR.Other_Vehicle_Location_Driver_Address_2);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Location_Driver_City]", objAL_FR.Other_Vehicle_Location_Driver_City);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Location_Driver_State]", new State(!string.IsNullOrEmpty(objAL_FR.Other_Vehicle_Location_Driver_State) ? Convert.ToDecimal(objAL_FR.Other_Vehicle_Location_Driver_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Location_Driver_ZipCode]", objAL_FR.Other_Vehicle_Location_Driver_ZipCode);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Owner_Name]", objAL_FR.Other_Vehicle_Owner_Name);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Owner_Work_Phone]", objAL_FR.Other_Vehicle_Owner_Work_Phone);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Owner_Home_Phone]", objAL_FR.Other_Vehicle_Owner_Home_Phone);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Owner_Alternate_Phone]", objAL_FR.Other_Vehicle_Owner_Alternate_Phone);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Owner_Address_1]", objAL_FR.Other_Vehicle_Owner_Address_1);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Owner_Address_2]", objAL_FR.Other_Vehicle_Owner_Address_2);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Owner_City]", objAL_FR.Other_Vehicle_Owner_City);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Owner_State]", new State(!string.IsNullOrEmpty(objAL_FR.Other_Vehicle_Owner_State) ? Convert.ToDecimal(objAL_FR.Other_Vehicle_Owner_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblOther_Vehicle_Owner_ZipCode]", objAL_FR.Other_Vehicle_Owner_ZipCode);
                #endregion

                #region Other Vehicle Driver Information
                // Set Values to Object
                strEbdy = strEbdy.Replace("[lblOther_Driver_Name]", objAL_FR.Other_Driver_Name);
                strEbdy = strEbdy.Replace("[lblOther_Driver_SSN]", objAL_FR.Other_Driver_SSN.Substring(Math.Max(0, objAL_FR.Other_Driver_SSN.Length - 4)));
                strEbdy = strEbdy.Replace("[lblOther_Driver_Address_1]", objAL_FR.Other_Driver_Address_1);
                strEbdy = strEbdy.Replace("[lblOther_Driver_Date_of_Birth]", clsGeneral.FormatDateToDisplay(objAL_FR.Other_Driver_Date_of_Birth));
                //check Date of Birth is not null.if not null than display age count
                if (objAL_FR.Other_Driver_Date_of_Birth != null)
                {
                    if (Convert.ToDateTime(objAL_FR.Other_Driver_Date_of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                        strEbdy = strEbdy.Replace("[lblOther_Driver_AgeCount]", GetAge(objAL_FR.Other_Driver_Date_of_Birth));
                    else
                        strEbdy = strEbdy.Replace("[lblOther_Driver_AgeCount]", "");
                }
                else
                    strEbdy = strEbdy.Replace("[lblOther_Driver_AgeCount]", "");
                strEbdy = strEbdy.Replace("[lblOther_Driver_Address_2]", objAL_FR.Other_Driver_Address_2);
                strEbdy = strEbdy.Replace("[lblOther_Driver_City]", objAL_FR.Other_Driver_City);
                strEbdy = strEbdy.Replace("[lblOther_Driver_State]", new State(!string.IsNullOrEmpty(objAL_FR.Other_Driver_State) ? Convert.ToDecimal(objAL_FR.Other_Driver_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblOther_Driver_Home_Phone]", objAL_FR.Other_Driver_Home_Phone);
                strEbdy = strEbdy.Replace("[lblOther_Driver_Work_Phone]", objAL_FR.Other_Driver_Work_Phone);
                strEbdy = strEbdy.Replace("[lblOther_Driver_ZipCode]", objAL_FR.Other_Driver_ZipCode);
                strEbdy = strEbdy.Replace("[lblOther_Driver_Drivers_License_Number]", objAL_FR.Other_Driver_Drivers_License_Number);
                strEbdy = strEbdy.Replace("[lblOther_Driver_Gender]", objAL_FR.Other_Driver_Gender);
                strEbdy = strEbdy.Replace("[lblOther_Driver_Drivers_License_State]", new State(!string.IsNullOrEmpty(objAL_FR.Other_Driver_Drivers_License_State) ? Convert.ToDecimal(objAL_FR.Other_Driver_Drivers_License_State) : 0).FLD_state);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Other_Driver_Citation_Issued != null)
                {
                    if (objAL_FR.Other_Driver_Citation_Issued == true)
                        strEbdy = strEbdy.Replace("[lblOther_Driver_Citation_Issued]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblOther_Driver_Citation_Issued]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblOther_Driver_Citation_Issued]", "unknown");

                strEbdy = strEbdy.Replace("[lblOther_Driver_Citation_Number]", objAL_FR.Other_Driver_Citation_Number);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Other_Driver_Injured != null)
                {
                    if (objAL_FR.Other_Driver_Injured == true)
                        strEbdy = strEbdy.Replace("[lblOther_Driver_Injured]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblOther_Driver_Injured]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblOther_Driver_Injured]", "unknown");


                strEbdy = strEbdy.Replace("[lblOther_Driver_Injury_Description]", objAL_FR.Other_Driver_Injury_Description);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Other_Driver_Sought_Medical_Attention != null)
                {
                    if (objAL_FR.Other_Driver_Sought_Medical_Attention == true)
                        strEbdy = strEbdy.Replace("[lblOther_Driver_Sought_Medical_Attention]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblOther_Driver_Sought_Medical_Attention]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblOther_Driver_Sought_Medical_Attention]", "unknown");

                strEbdy = strEbdy.Replace("[lblOther_Driver_Taken_By_Emergency_Transportation]", (objAL_FR.Other_Driver_Taken_By_Emergency_Transportation == true) ? "Yes" : "No");
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Other_Driver_Airlifted_Medivac != null)
                {
                    if (objAL_FR.Other_Driver_Airlifted_Medivac == true)
                        strEbdy = strEbdy.Replace("[lblOther_Driver_Airlifted_Medivac]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblOther_Driver_Airlifted_Medivac]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblOther_Driver_Airlifted_Medivac]", "unknown");
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Other_Driver_Admitted_to_Hospital != null)
                {
                    if (objAL_FR.Other_Driver_Admitted_to_Hospital == true)
                        strEbdy = strEbdy.Replace("[lblOther_Driver_Admitted_to_Hospital]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblOther_Driver_Admitted_to_Hospital]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblOther_Driver_Admitted_to_Hospital]", "unknown");

                strEbdy = strEbdy.Replace("[lblOther_Driver_Medical_Facility_Name]", objAL_FR.Other_Driver_Medical_Facility_Name);
                strEbdy = strEbdy.Replace("[lblOther_Driver_Medical_Facility_Address_1]", objAL_FR.Other_Driver_Medical_Facility_Address_1);
                strEbdy = strEbdy.Replace("[lblOther_Driver_Medical_Facility_Address_2]", objAL_FR.Other_Driver_Medical_Facility_Address_2);
                //check object value
                if (objAL_FR.Other_Driver_Admitted_to_Hospital == true)
                {
                    //strEbdy = strEbdy.Replace("[tdViewOth_Driver_DateAdmitted]", "block");
                    //strEbdy = strEbdy.Replace("[tdViewOth_Driver_StillHospital]", "block");
                    strEbdy = strEbdy.Replace("[lblOther_Driver_Date_Admitted_to_Hospital]", clsGeneral.FormatDateToDisplay(objAL_FR.Other_Driver_Date_Admitted_to_Hospital));
                    //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                    if (objAL_FR.Other_Driver_Still_in_Hospital != null)
                    {
                        if (objAL_FR.Other_Driver_Still_in_Hospital == true)
                            strEbdy = strEbdy.Replace("[lblOther_Driver_Still_in_Hospital]", "Yes");
                        else
                            strEbdy = strEbdy.Replace("[lblOther_Driver_Still_in_Hospital]", "No");
                    }
                    else
                        strEbdy = strEbdy.Replace("[lblOther_Driver_Still_in_Hospital]", "unknown");
                }
                else
                {
                    strEbdy = strEbdy.Replace("<!--[tdViewOth_Driver_DateAdmitted] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewOth_Driver_DateAdmitted] -->", "-->");
                    //strEbdy = strEbdy.Replace("[tdViewOth_Driver_DateAdmitted]", "none");
                    strEbdy = strEbdy.Replace("<!--[tdViewOth_Driver_StillHospital] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewOth_Driver_StillHospital] -->", "-->");
                    //strEbdy = strEbdy.Replace("[tdViewOth_Driver_StillHospital]", "none");
                }
                strEbdy = strEbdy.Replace("[lblOther_Driver_Medical_Facility_City]", objAL_FR.Other_Driver_Medical_Facility_City);
                strEbdy = strEbdy.Replace("[lblOther_Driver_Physicians_Name]", objAL_FR.Other_Driver_Physicians_Name);
                strEbdy = strEbdy.Replace("[lblOther_Driver_Medical_Facility_State]", new State(!string.IsNullOrEmpty(objAL_FR.Other_Driver_Medical_Facility_State) ? Convert.ToDecimal(objAL_FR.Other_Driver_Medical_Facility_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblOther_Driver_Medical_Facility_Zip_Code]", objAL_FR.Other_Driver_Medical_Facility_Zip_Code);
                strEbdy = strEbdy.Replace("[lblOther_Driver_Medical_Facility_Type]", objAL_FR.Other_Driver_Medical_Facility_Type);

                #endregion

                #region Other Vehicle Passenger Information

                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Name]", objAL_FR.Oth_Veh_Pass_Name);
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Date_of_Birth]", clsGeneral.FormatDateToDisplay(objAL_FR.Oth_Veh_Pass_Date_of_Birth));
                //check Date of Birth is not null.if not null than display age count
                if (objAL_FR.Oth_Veh_Pass_Date_of_Birth != null)
                {
                    if (Convert.ToDateTime(objAL_FR.Oth_Veh_Pass_Date_of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                        strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_AgeCount]", GetAge(objAL_FR.Oth_Veh_Pass_Date_of_Birth));
                    else
                        strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_AgeCount]", "");
                }
                else
                    strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_AgeCount]", "");
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Address_1]", objAL_FR.Oth_Veh_Pass_Address_1);
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Address_2]", objAL_FR.Oth_Veh_Pass_Address_2);
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_City]", objAL_FR.Oth_Veh_Pass_City);
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_State]", new State(!string.IsNullOrEmpty(objAL_FR.Oth_Veh_Pass_State) ? Convert.ToDecimal(objAL_FR.Oth_Veh_Pass_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Home_Phone]", objAL_FR.Oth_Veh_Pass_Home_Phone);
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Work_Phone]", objAL_FR.Oth_Veh_Pass_Work_Phone);
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Alternate_Phone]", objAL_FR.Oth_Veh_Pass_Alternate_Phone);
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_ZipCode]", objAL_FR.Oth_Veh_Pass_ZipCode);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Oth_Veh_Pass_Injured != null)
                {
                    if (objAL_FR.Oth_Veh_Pass_Injured == true)
                        strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Injured]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Injured]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Injured]", "unknown");
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Oth_Veh_Pass_Injured != null)
                {
                    if (objAL_FR.Oth_Veh_Pass_Injured == true)
                        strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Injured]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Injured]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Injured]", "unknown");
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Oth_Veh_Pass_Injured != null)
                {
                    if (objAL_FR.Oth_Veh_Pass_Injured == true)
                        strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Injured]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Injured]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Injured]", "unknown");


                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Injury_Description]", objAL_FR.Oth_Veh_Pass_Injury_Description);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Oth_Veh_Pass_Sought_Medical_Attention != null)
                {
                    if (objAL_FR.Oth_Veh_Pass_Sought_Medical_Attention == true)
                        strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Sought_Medical_Attention]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Sought_Medical_Attention]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Sought_Medical_Attention]", "unknown");

                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Taken_By_Emergency_Transportation]", ((objAL_FR.Oth_Veh_Pass_Taken_By_Emergency_Transportation == true) ? "Yes" : "No"));
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Oth_Veh_Pass_Airlifted_Medivac != null)
                {
                    if (objAL_FR.Oth_Veh_Pass_Airlifted_Medivac == true)
                        strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Airlifted_Medivac]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Airlifted_Medivac]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Airlifted_Medivac]", "unknown");
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Oth_Veh_Pass_Admitted_to_Hospital != null)
                {
                    if (objAL_FR.Oth_Veh_Pass_Admitted_to_Hospital == true)
                        strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Admitted_to_Hospital]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Admitted_to_Hospital]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Admitted_to_Hospital]", "unknown");


                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Medical_Facility_Name]", objAL_FR.Oth_Veh_Pass_Medical_Facility_Name);
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Medical_Facility_Address_1]", objAL_FR.Oth_Veh_Pass_Medical_Facility_Address_1);
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Medical_Facility_Address_2]", objAL_FR.Oth_Veh_Pass_Medical_Facility_Address_2);
                //check object value. if true than display related fields else that fields are remain hidden
                if (objAL_FR.Oth_Veh_Pass_Admitted_to_Hospital == true)
                {
                    //strEbdy = strEbdy.Replace("[tdViewOth_Ven_Pass_DateAdmitted]", "block");
                    //strEbdy = strEbdy.Replace("[tdViewOth_Ven_Pass_StillHospital]", "block");
                    strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Date_Admitted_to_Hospital]", clsGeneral.FormatDateToDisplay(objAL_FR.Oth_Veh_Pass_Date_Admitted_to_Hospital));
                    //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                    if (objAL_FR.Oth_Veh_Pass_Still_in_Hospital != null)
                    {
                        if (objAL_FR.Oth_Veh_Pass_Still_in_Hospital == true)
                            strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Still_in_Hospital]", "Yes");
                        else
                            strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Still_in_Hospital]", "No");
                    }
                    else
                        strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Still_in_Hospital]", "unknown");
                }
                else
                {
                    strEbdy = strEbdy.Replace("<!--[tdViewOth_Ven_Pass_DateAdmitted] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewOth_Ven_Pass_DateAdmitted] -->", "-->");
                    //strEbdy = strEbdy.Replace("[tdViewOth_Ven_Pass_DateAdmitted]", "none");
                    strEbdy = strEbdy.Replace("<!--[tdViewOth_Ven_Pass_StillHospital] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewOth_Ven_Pass_StillHospital] -->", "-->");
                    //strEbdy = strEbdy.Replace("[tdViewOth_Ven_Pass_StillHospital]", "none");
                }
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Medical_Facility_City]", objAL_FR.Oth_Veh_Pass_Medical_Facility_City);
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Physicians_Name]", objAL_FR.Oth_Veh_Pass_Physicians_Name);
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Medical_Facility_State]", new State(objAL_FR.Oth_Veh_Pass_Medical_Facility_State).FLD_state);
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Medical_Facility_Zip_Code]", objAL_FR.Oth_Veh_Pass_Medical_Facility_ZipCode);
                strEbdy = strEbdy.Replace("[lblOth_Veh_Pass_Medical_Facility_Type]", objAL_FR.Oth_Veh_Pass_Medical_Facility_Type);

                #endregion

                #region Pedestrian Information
                // Set Values to Object
                strEbdy = strEbdy.Replace("[lblPedestrian_Name]", objAL_FR.Pedestrian_Name);
                strEbdy = strEbdy.Replace("[lblPedestrian_Date_of_Birth]", clsGeneral.FormatDateToDisplay(objAL_FR.Pedestrian_Date_of_Birth));
                //check Date of Birth is not null.if not null than display age count
                if (objAL_FR.Pedestrian_Date_of_Birth != null)
                {
                    if (Convert.ToDateTime(objAL_FR.Pedestrian_Date_of_Birth) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                        strEbdy = strEbdy.Replace("[lblPedestrianAgeCount]", GetAge(objAL_FR.Pedestrian_Date_of_Birth));
                    else
                        strEbdy = strEbdy.Replace("[lblPedestrianAgeCount]", "");
                }
                else
                    strEbdy = strEbdy.Replace("[lblPedestrianAgeCount]", "");
                strEbdy = strEbdy.Replace("[lblPedestrian_Address_1]", objAL_FR.Pedestrian_Address_1);
                strEbdy = strEbdy.Replace("[lblPedestrian_Address_2]", objAL_FR.Pedestrian_Address_2);
                strEbdy = strEbdy.Replace("[lblPedestrian_City]", objAL_FR.Pedestrian_City);
                strEbdy = strEbdy.Replace("[lblPedestrian_State]", new State(!string.IsNullOrEmpty(objAL_FR.Pedestrian_State) ? Convert.ToDecimal(objAL_FR.Pedestrian_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblPedestrian_Home_Phone]", objAL_FR.Pedestrian_Home_Phone);
                strEbdy = strEbdy.Replace("[lblPedestrian_Work_Phone]", objAL_FR.Pedestrian_Work_Phone);
                strEbdy = strEbdy.Replace("[lblPedestrian_Alternate_Phone]", objAL_FR.Pedestrian_Alternate_Phone);
                strEbdy = strEbdy.Replace("[lblPedestrian_ZipCode]", objAL_FR.Pedestrian_ZipCode);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Pedestrian_Injured != null)
                {
                    if (objAL_FR.Pedestrian_Injured == true)
                        strEbdy = strEbdy.Replace("[lblPedestrian_Injured]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblPedestrian_Injured]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblPedestrian_Injured]", "unknown");

                strEbdy = strEbdy.Replace("[lblPedestrian_Injury_Description]", objAL_FR.Pedestrian_Injury_Description);
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Pedestrian_Sought_Medical_Attention != null)
                {
                    if (objAL_FR.Pedestrian_Sought_Medical_Attention == true)
                        strEbdy = strEbdy.Replace("[lblPedestrian_Sought_Medical_Attention]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblPedestrian_Sought_Medical_Attention]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblPedestrian_Sought_Medical_Attention]", "unknown");

                strEbdy = strEbdy.Replace("[lblPedestrian_Taken_By_Emergency_Transportation]", (objAL_FR.Pedestrian_Taken_By_Emergency_Transportation == true) ? "Yes" : "No");
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Pedestrian_Airlifted_Medivac != null)
                {
                    if (objAL_FR.Pedestrian_Airlifted_Medivac == true)
                        strEbdy = strEbdy.Replace("[lblPedestrian_Airlifted_Medivac]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblPedestrian_Airlifted_Medivac]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblPedestrian_Airlifted_Medivac]", "unknown");
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Pedestrian_Admitted_to_Hospital != null)
                {
                    if (objAL_FR.Pedestrian_Admitted_to_Hospital == true)
                        strEbdy = strEbdy.Replace("[lblPedestrian_Admitted_to_Hospital]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblPedestrian_Admitted_to_Hospital]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblPedestrian_Admitted_to_Hospital]", "unknwon");

                strEbdy = strEbdy.Replace("[lblPedestrian_Medical_Facility_Name]", objAL_FR.Pedestrian_Medical_Facility_Name);
                strEbdy = strEbdy.Replace("[lblPedestrian_Medical_Facility_Address_1]", objAL_FR.Pedestrian_Medical_Facility_Address_1);
                strEbdy = strEbdy.Replace("[lblPedestrian_Medical_Facility_Address_2]", objAL_FR.Pedestrian_Medical_Facility_Address_2);
                strEbdy = strEbdy.Replace("[lblPedestrian_Date_Admitted_to_Hospital]", clsGeneral.FormatDateToDisplay(objAL_FR.Pedestrian_Date_Admitted_to_Hospital));
                //check value if it is null than display "nuknown" else if it is true than display "Yes" else "no"
                if (objAL_FR.Pedestrian_Still_in_Hospital != null)
                {
                    if (objAL_FR.Pedestrian_Still_in_Hospital == true)
                        strEbdy = strEbdy.Replace("[lblPedestrian_Still_in_Hospital]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblPedestrian_Still_in_Hospital]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblPedestrian_Still_in_Hospital]", "unknown");

                strEbdy = strEbdy.Replace("[lblPedestrian_Medical_Facility_City]", objAL_FR.Pedestrian_Medical_Facility_City);
                strEbdy = strEbdy.Replace("[lblPedestrian_Physicians_Name]", objAL_FR.Pedestrian_Physicians_Name);
                strEbdy = strEbdy.Replace("[lblPedestrian_Medical_Facility_State]", new State(!string.IsNullOrEmpty(objAL_FR.Pedestrian_Medical_Facility_State) ? Convert.ToDecimal(objAL_FR.Pedestrian_Medical_Facility_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblPedestrian_Medical_Facility_Zip_Code]", objAL_FR.Pedestrian_Medical_Facility_Zip_Code);
                strEbdy = strEbdy.Replace("[lblPedestrian_Medical_Facility_Type]", objAL_FR.Pedestrian_Medical_Facility_Type);
                #endregion

                #region Witness Information
                // set Vallue to Object
                strEbdy = strEbdy.Replace("[lblWitness_Name]", objAL_FR.Witness_Name);
                strEbdy = strEbdy.Replace("[lblWitness_Address_1]", objAL_FR.Witness_Address_1);
                strEbdy = strEbdy.Replace("[lblWitness_Address_2]", objAL_FR.Witness_Address_2);
                strEbdy = strEbdy.Replace("[lblWitness_City]", objAL_FR.Witness_City);
                strEbdy = strEbdy.Replace("[lblWitness_State]", new State(!string.IsNullOrEmpty(objAL_FR.Witness_State) ? Convert.ToDecimal(objAL_FR.Witness_State) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblWitness_Zip_Code]", objAL_FR.Witness_ZipCode);
                strEbdy = strEbdy.Replace("[lblWitness_Home_Phone]", objAL_FR.Witness_Home_Phone);
                strEbdy = strEbdy.Replace("[lblWitness_Work_Phone]", objAL_FR.Witness_Work_Phone);
                strEbdy = strEbdy.Replace("[lblWitness_Alternate_Phone]", objAL_FR.Witness_Alternate_Phone);

                #endregion

                #region Comments and Attachments
                //Comments and Attachments
                strEbdy = strEbdy.Replace("[lblComments]", objAL_FR.Comments);

                #endregion

                return strEbdy;
            }
            else
            {
                FirstReportNumber = "";
                return "";
            }
        }
    }
    #endregion

    #region General Methods
    /// <summary>
    /// Used to Generate Age from Date passed
    /// </summary>
    /// <param name="dtBirth"></param>
    /// <returns></returns>
    public string GetAge(DateTime dtBirth)
    {
        if (dtBirth != null)
        {
            DateTime dtToday = DateTime.Now;
            int intCurday = dtToday.Day;
            int intCurMon = dtToday.Month;
            int intCurYear = dtToday.Year;
            int intBday = dtBirth.Day;
            int intBMon = dtBirth.Month;
            int intBYear = dtBirth.Year;
            int Age;
            intBMon = intBMon - 1;
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
    #endregion

    #region Use to Upload Files
    /// <summary>
    /// Used to upload file
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {
        //Insert values into AL_FR_Attachment table
        CtrlAttachments.Add(clsGeneral.Tables.AL_FR, PK_AL_FR_ID);
        // Used to Bind Grid with Attached Data
        CtrlAttachDetails.Bind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:FireAll(); ShowPanel(11);", true);
    }
    #endregion

    #region Bind Sonic Header INformation Controls
    /// <summary>
    /// used to set Sonic Header Control information
    /// </summary>
    public void setSonicHeaderInfo()
    {
        //Create Object
        AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);

        SonicInfo.FirstReportNumber = "AL-" + objAL_FR.AL_FR_Number.ToString();
        SonicInfo.SONICLocationdba = new LU_Location(objAL_FR.FK_Loss_Location).dba.ToString();
        SonicInfo.DateOfIncident = clsGeneral.FormatDateToDisplay(objAL_FR.Date_Of_Loss);

        //Set Claim Number
        //DataTable dtClaimInfo = WC_ClaimInfo.Select_Claim_Number(Convert.ToInt32(objAL_FR.AL_FR_Number),"AL");
        DataTable dtClaimInfo = WC_ClaimInfo.Select_Claim_Number(Convert.ToInt32(objAL_FR.PK_AL_FR_ID), "AL");
        if (dtClaimInfo.Rows.Count > 0)
        {
            SonicInfo.CurrentReportType = Controls_SONICInfo_SonicInfo.ReportType.AL;
            SonicInfo.ClaimNumber = Convert.ToString(dtClaimInfo.Rows[0]["Origin_Claim_Number"]);
            SonicInfo.ClaimInfo = Convert.ToString(dtClaimInfo.Rows[0]["ClaimID"]);
        }

        //check user Access type. if it is view only than disable the Add new link from Header.
        if (Module_Access_Mode == AccessType.View_Only)
            //if (UserAccessType == AccessType.View_Only)
            SonicInfo.AddNewLink = false;
        else
            SonicInfo.AddNewLink = true;
    }
    #endregion

    #region "Email Send"

    /// <summary>
    /// Click to Send Emails
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSendMail_Click(object sender, EventArgs e)
    {
        SendFROI();
        //ScriptManager.RegisterStartupScript(this, Page.GetType(), System.DateTime.Now.ToString(), "javascript:alert('First Report sent successfully');ShowPanel(" + hdnCureentPanel.Value + ");", true);

        if (!AppConfig.AllowMailSending)
        {
            ScriptManager.RegisterStartupScript(this, Page.GetType(), System.DateTime.Now.ToString(), "javascript:alert('First Report cannot be sent as mailing option is disabled');ShowPanel(" + hdnCureentPanel.Value + ");", true);
        }
        else
        {
            decimal FileSize = this.CtrlViewAttachDetails.GetTotalAttachmentsFileSize();
            if (FileSize > 9.5M)
            {
                String confirmMessage = "The attachments to this First Report exceed the size limitations for e-mail. The First Report can be sent without the attachments or you can Cancel and remove or reduce the size of the exiting attachments. Do you want to send the First Report without the attachments?";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", " if(window.confirm('" + confirmMessage + "')){ __doPostBack('UserConfirmationPostBackView', 'true');} else { alert('The First Report has NOT been sent, please reduce the number and/or size of the attachments before attempting to resubmit with attachments.');ShowPanel(11); }", true);
                return;
            }

            if (ResendMail(true))
            {
                //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnCureentPanel.Value + ");", true);
                ScriptManager.RegisterStartupScript(this, Page.GetType(), System.DateTime.Now.ToString(), "javascript:alert('First Report mail send successfully');ShowPanel(" + hdnCureentPanel.Value + ");", true);
            }
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "alert('Something went wrong. Please try after sometime.'); window.location='FirstReportSearch.aspx';", true);
        }
    }

    /// <summary>
    /// method to send Email gain
    /// </summary>
    /// <param name="_IsAttachment"></param>
    private bool ResendMail(bool _IsAttachment)
    {

        // Declare Object
        AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);

        int iAttCount = 0;
        //Get Attachment Details
        DataTable dtAtt = AL_FR_Attacments.SelectByFROL_ID(PK_AL_FR_ID).Tables[0];
        string[] strAtt = new string[dtAtt.Rows.Count];
        if (_IsAttachment)
        {
            if (dtAtt.Rows.Count > 0)
            {
                foreach (DataRow drAtt in dtAtt.Rows)
                {
                    string strFileName = drAtt["Attachment_Path"].ToString();
                    strFileName = AppConfig.AL_FRDocPath + strFileName;
                    strAtt[iAttCount] = strFileName;
                    iAttCount = iAttCount + 1;
                }

            }
        }
        //get recipient Id
        //DataTable dtRecipient = Email_Settings.SelectByModuleName("AL").Tables[0];
        DataTable dtRecipient = LU_Location.GetRecipientEmailID(objAL_FR.FK_Loss_Location, LU_Location.SonicReportType.AL).Tables[0];
        string[] EmailTo = new string[dtRecipient.Rows.Count];
        int intToMailCount = 0;
        if (dtRecipient.Rows.Count > 0)
        {
            foreach (DataRow drRecipient in dtRecipient.Rows)
            {
                EmailTo[intToMailCount] = drRecipient["Email"].ToString();
                intToMailCount = intToMailCount + 1;
            }
        }

        //used to send Email
        string ReturnFRNumber;
        if (First_Report_Wizard_ID > 0)
        {
            string HtmlBody = GenerateEMailBody(out ReturnFRNumber);
            decimal FR_Number = new AL_FR(ReturnFRNumber.ToString() != string.Empty ? Convert.ToDecimal(ReturnFRNumber) : 0).AL_FR_Number;

            //Check To EMail ID's. if it is zero than email is not send.
            if (EmailTo.Length > 0 && !string.IsNullOrEmpty(HtmlBody))
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));
                if (_IsAttachment)
                    objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Repeat :: Sonic Automotive (acct #42979) reports the following First Report of Loss AL-" + FR_Number.ToString(), HtmlBody, true, strAtt, AppConfig.MailCC);
                else
                    objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Repeat :: Sonic Automotive (acct #42979) reports the following First Report of Loss AL-" + FR_Number.ToString(), HtmlBody, true, new string[] { }, AppConfig.MailCC);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }

    /// <summary>
    /// Send First report Emails
    /// </summary>
    /// <param name="_IsAttachment"></param>
    private bool SendFirstReportMail(bool _IsAttachment)
    {

        if (First_Report_Wizard_ID > 0)
        {
            AL_FR objAL_FR = new AL_FR(PK_AL_FR_ID);

            int iAttCount = 0;
            //Get Attachment Details
            DataTable dtAtt = AL_FR_Attacments.SelectByFROL_ID(PK_AL_FR_ID).Tables[0];
            string[] strAtt = new string[dtAtt.Rows.Count];
            if (_IsAttachment)
            {
                if (dtAtt.Rows.Count > 0)
                {
                    foreach (DataRow drAtt in dtAtt.Rows)
                    {
                        string strFileName = drAtt["Attachment_Path"].ToString();
                        strFileName = AppConfig.AL_FRDocPath + strFileName;
                        strAtt[iAttCount] = strFileName;
                        iAttCount = iAttCount + 1;
                    }

                }
            }
            //get recipient Id
            //DataTable dtRecipient = Email_Settings.SelectByModuleName("AL").Tables[0];
            DataTable dtRecipient = LU_Location.GetRecipientEmailID(objAL_FR.FK_Loss_Location, LU_Location.SonicReportType.AL).Tables[0];
            string[] EmailTo = new string[dtRecipient.Rows.Count];
            int intToMailCount = 0;
            if (dtRecipient.Rows.Count > 0)
            {
                foreach (DataRow drRecipient in dtRecipient.Rows)
                {
                    EmailTo[intToMailCount] = drRecipient["Email"].ToString();
                    intToMailCount = intToMailCount + 1;
                }
            }
            //used to send Email
            string ReturnFRNumber;
            string HtmlBody = GenerateEMailBody(out ReturnFRNumber);
            decimal FR_Number = new AL_FR(ReturnFRNumber.ToString() != string.Empty ? Convert.ToDecimal(ReturnFRNumber) : 0).AL_FR_Number;
            //generate FIle and store it on disk
            StreamWriter sWriter = null;
            clsGeneral.CreateDirectory(AppConfig.SitePath + "SONIC-Email/" + clsSession.FirstName + "_" + clsSession.LastName + "/AL_FR/" + DateTime.Today.ToString("MM-dd-yyyy"));
            string strName = AppConfig.SitePath + "SONIC-Email/" + clsSession.FirstName + "_" + clsSession.LastName + "/AL_FR/" + DateTime.Today.ToString("MM-dd-yyyy") + "/AL_FR_Email_" + FR_Number.ToString() + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
            string strAttachmentName = AppConfig.SitePath + "SONIC-Email/" + clsSession.FirstName + "_" + clsSession.LastName + "/AL_FR/" + DateTime.Today.ToString("MM-dd-yyyy") + "/AL_FR_Attachment_" + FR_Number.ToString() + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
            string strFName = strName + ".html";
            try
            {
                FileStream FS = new FileStream(strFName, FileMode.Create, FileAccess.ReadWrite);
                sWriter = new StreamWriter(FS);
                sWriter.Write(HtmlBody);
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
            //Check To EMail ID's. if it is zero than email is not send.
            //if (EmailTo.Length > 0)
            if (EmailTo.Length > 0 && !string.IsNullOrEmpty(HtmlBody))
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));
                if (_IsAttachment)
                    objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Sonic Automotive (acct #42979) reports the following First Report of Loss AL-" + FR_Number.ToString(), HtmlBody, true, finalAttachment, AppConfig.MailCC);
                else
                    objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Sonic Automotive (acct #42979) reports the following First Report of Loss AL-" + FR_Number.ToString(), HtmlBody, true, new string[] { }, AppConfig.MailCC);

                return true;
            }
            else
            {
                return false;
            }
        }
        else
            return false;
        //clsGeneral.SendMailMessage(AppConfig.MailFrom, EmailTo, string.Empty, string.Empty, "Sonic Automotive reports the following First Report of Loss", HtmlBody, true, strAtt);
    }

    #endregion

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        string strLocationContactIDs = "";
        string strLocationContactErrorMsgs = "";
        string strLossInformationIDs = "";
        string strLossInformationErrorMsgs = "";
        string strInsuredVehicleIDs = "";
        string strInsuredVehicleErrorMsgs = "";
        string strInsuredVehicleDriverIDs = "";
        string strInsuredVehicleDriverErrorMsgs = "";
        string strInsuredVehiclePassengerIDs = "";
        string strInsuredVehiclePassengerErrorMsgs = "";
        string strOtherVehicleIDs = "";
        string strOtherVehicleErrorMsgs = "";
        string strOtherVehicleDriverIDs = "";
        string strOtherVehicleDriverErrorMsgs = "";
        string strOtherVehiclePassengerIDs = "";
        string strOtherVehiclePassengerErrorMsgs = "";
        string strPedestrianIDs = "";
        string strPedestrianErrorMsgs = "";
        string strWitnessIDs = "";
        string strWitnessErrorMsgs = "";
        string strCommentsIDs = "";
        string strCommentsErrorMsgs = "";

        #region "Location/Contact"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(7).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk1 = (Label)mnuAL.Controls[0].FindControl("MenuAsterisk");
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 7").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "When to Contact":
                    strLocationContactIDs += txtContact_Best_Time.ClientID + ",";
                    strLocationContactErrorMsgs += "Please enter [Location/Contact]/When to Contact" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Fax Number":
                    strLocationContactIDs += txtContactFaxNumber.ClientID + ",";
                    strLocationContactErrorMsgs += "Please enter [Location/Contact]/Fax Number" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        strLocationContactIDs = strLocationContactIDs.TrimEnd(',');
        strLocationContactErrorMsgs = strLocationContactErrorMsgs.TrimEnd(',');

        hdnLocationContactIDs.Value = strLocationContactIDs;
        hdnLocationContactErrorMsgs.Value = strLocationContactErrorMsgs;
        #endregion

        #region "Loss/Information"
        dtFields = clsScreen_Validators.SelectByScreen(8).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk2 = (Label)mnuAL.Controls[1].FindControl("MenuAsterisk");
        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 8").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Accident State":
                    strLossInformationIDs += ddlClaimant_state.ClientID + ",";
                    strLossInformationErrorMsgs += "Please select [Loss/Information]/Accident State" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Auto Liability Type":
                    strLossInformationIDs += ddlAuto_Liability_Type.ClientID + ",";
                    strLossInformationErrorMsgs += "Please select [Loss/Information]/Auto Liability Type" + ",";
                    Span191.Style["display"] = "inline-block";
                    break;
                case "Date of Loss":
                    strLossInformationIDs += txtDate_Of_Loss.ClientID + ",";
                    strLossInformationErrorMsgs += "Please enter [Loss/Information]/Date of Loss" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Time of Incident":
                    strLossInformationIDs += txtTime_Of_Loss.ClientID + ",";
                    strLossInformationErrorMsgs += "Please enter [Loss/Information]/Time of Incident" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strLossInformationIDs += txtOffsite_Address1.ClientID + ",";
                    strLossInformationErrorMsgs += "Please enter [Loss/Information]/Address 1" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strLossInformationIDs += txtOffsite_Address2.ClientID + ",";
                    strLossInformationErrorMsgs += "Please enter [Loss/Information]/Address 2" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "City":
                    strLossInformationIDs += txtOffsite_City.ClientID + ",";
                    strLossInformationErrorMsgs += "Please enter [Loss/Information]/City" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "State":
                    strLossInformationIDs += ddlOffsite_State.ClientID + ",";
                    strLossInformationErrorMsgs += "Please select [Loss/Information]/State" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Zip code":
                    strLossInformationIDs += txtOffsite_zip.ClientID + ",";
                    strLossInformationErrorMsgs += "Please enter [Loss/Information]/Zip code" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Description of Loss":
                    strLossInformationIDs += txtDescription_Of_Loss.ClientID + ",";
                    strLossInformationErrorMsgs += "Please enter [Loss/Information]/Description of Loss" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Date Reported to Sonic":
                    strLossInformationIDs += txtDate_Reported_To_Sonic.ClientID + ",";
                    strLossInformationErrorMsgs += "Please enter Date [Loss/Information]/Reported to Sonic" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Weather Conditions":
                    strLossInformationIDs += txtWeather_Conditions.ClientID + ",";
                    strLossInformationErrorMsgs += "Please enter [Loss/Information]/Weather Conditions" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "Road Conditions":
                    strLossInformationIDs += txtRoad_Conditions.ClientID + ",";
                    strLossInformationErrorMsgs += "Please enter [Loss/Information]/Road Conditions" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "Police":
                    strLossInformationIDs += txtPolice_Agency.ClientID + ",";
                    strLossInformationErrorMsgs += "Please enter [Loss/Information]/Police" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                case "Case Number":
                    strLossInformationIDs += txtPolice_Case_Number.ClientID + ",";
                    strLossInformationErrorMsgs += "Please enter [Loss/Information]/Case Number" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                case "Station Phone Number":
                    strLossInformationIDs += txtPolice_Station_Phone_Number.ClientID + ",";
                    strLossInformationErrorMsgs += "Please enter [Loss/Information]/Station Phone Number" + ",";
                    Span17.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        strLossInformationIDs = strLossInformationIDs.TrimEnd(',');
        strLossInformationErrorMsgs = strLossInformationErrorMsgs.TrimEnd(',');

        hdnLossInformationIDs.Value = strLossInformationIDs;
        hdnLossInformationErrorMsgs.Value = strLossInformationErrorMsgs;
        #endregion

        #region "Insured Vehicle"
        dtFields = clsScreen_Validators.SelectByScreen(9).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk3 = (Label)mnuAL.Controls[2].FindControl("MenuAsterisk");
        MenuAsterisk3.Style["display"] = (dtFields.Select("LeftMenuIndex = 9").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Vehicle Sub Type":
                    strInsuredVehicleIDs += ddlVehicle_Sub_Type.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please select [Insured Vehicle]/Vehicle Sub Type" + ",";
                    Span18.Style["display"] = "inline-block";
                    break;
                case "Fleet/Vehicle Number":
                    strInsuredVehicleIDs += txtVehicle_Fleet_number.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Fleet/Vehicle Number" + ",";
                    Span19.Style["display"] = "inline-block";
                    break;
                case "Year":
                    strInsuredVehicleIDs += txtYear.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Year" + ",";
                    Span20.Style["display"] = "inline-block";
                    break;
                case "Make":
                    strInsuredVehicleIDs += txtMake.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Make" + ",";
                    Span21.Style["display"] = "inline-block";
                    break;
                case "Model":
                    strInsuredVehicleIDs += txtModel.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Model" + ",";
                    Span22.Style["display"] = "inline-block";
                    break;
                case "VIN":
                    strInsuredVehicleIDs += txtVIN.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/VIN" + ",";
                    Span23.Style["display"] = "inline-block";
                    break;
                case "License Plate Number":
                    strInsuredVehicleIDs += txtLicense_Plate_Number.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/License Plate Number" + ",";
                    Span24.Style["display"] = "inline-block";
                    break;
                case "License Plate State":
                    strInsuredVehicleIDs += ddlLicense_Plate_State.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please select [Insured Vehicle]/License Plate State" + ",";
                    Span25.Style["display"] = "inline-block";
                    break;
                case "Vehicle Color":
                    strInsuredVehicleIDs += txtVehicle_Color.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Vehicle Color" + ",";
                    Span26.Style["display"] = "inline-block";
                    break;
                case "Description of Damage":
                    strInsuredVehicleIDs += txtVehicle_Damage_Description.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Description of Damage" + ",";
                    Span27.Style["display"] = "inline-block";
                    break;
                case "Estimated Amount":
                    strInsuredVehicleIDs += txtRepairs_Estimated_Amount.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Estimated Amount" + ",";
                    Span28.Style["display"] = "inline-block";
                    break;
                case "Location where vehicle can be seen":
                    strInsuredVehicleIDs += txtVehicle_Location.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Location where vehicle can be seen" + ",";
                    Span29.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strInsuredVehicleIDs += txtVehicle_Location_Driver_Address_1.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Address 1" + ",";
                    Span30.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strInsuredVehicleIDs += txtVehicle_Location_Driver_Address_2.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Address 2" + ",";
                    Span31.Style["display"] = "inline-block";
                    break;
                case "City":
                    strInsuredVehicleIDs += txtVehicle_Location_Driver_City.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/City" + ",";
                    Span43.Style["display"] = "inline-block";
                    break;
                case "State":
                    strInsuredVehicleIDs += ddlVehicle_Location_Driver_State.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please select [Insured Vehicle]/State" + ",";
                    Span32.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strInsuredVehicleIDs += txtVehicle_Location_Driver_ZipCode.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Zip Code" + ",";
                    Span33.Style["display"] = "inline-block";
                    break;
                case "Owner Name":
                    strInsuredVehicleIDs += txtOwner_Name.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Owner Name" + ",";
                    Span34.Style["display"] = "inline-block";
                    break;
                case "Work Telephone":
                    strInsuredVehicleIDs += txtOwner_Work_Phone.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Work Telephone" + ",";
                    Span35.Style["display"] = "inline-block";
                    break;
                case "Owner Address 1":
                    strInsuredVehicleIDs += txtOwner_Address_1.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Address 1" + ",";
                    Span36.Style["display"] = "inline-block";
                    break;
                case "Home Telephone":
                    strInsuredVehicleIDs += txtOwner_Home_Phone.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Home Telephone" + ",";
                    Span37.Style["display"] = "inline-block";
                    break;
                case "Owner Address 2":
                    strInsuredVehicleIDs += txtOwner_Address_2.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Address 2" + ",";
                    Span38.Style["display"] = "inline-block";
                    break;
                case "Alternate Telephone":
                    strInsuredVehicleIDs += txtOwner_Alternate_Phone.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Alternate Telephone" + ",";
                    Span39.Style["display"] = "inline-block";
                    break;
                case "Owner City":
                    strInsuredVehicleIDs += txtOwner_City.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/City" + ",";
                    Span40.Style["display"] = "inline-block";
                    break;
                case "Owner State":
                    strInsuredVehicleIDs += ddlOwner_State.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please select [Insured Vehicle]/State" + ",";
                    Span41.Style["display"] = "inline-block";
                    break;
                case "Owner Zip Code":
                    strInsuredVehicleIDs += txtOwner_ZipCode.ClientID + ",";
                    strInsuredVehicleErrorMsgs += "Please enter [Insured Vehicle]/Zip Code" + ",";
                    Span42.Style["display"] = "inline-block";
                    break;

            }
            #endregion
        }
        strInsuredVehicleIDs = strInsuredVehicleIDs.TrimEnd(',');
        strInsuredVehicleErrorMsgs = strInsuredVehicleErrorMsgs.TrimEnd(',');

        hdnInsuredVehicleIDs.Value = strInsuredVehicleIDs;
        hdnInsuredVehicleErrorMsgs.Value = strInsuredVehicleErrorMsgs;
        #endregion

        #region "Insured Vehicle Driver"
        dtFields = clsScreen_Validators.SelectByScreen(10).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk4 = (Label)mnuAL.Controls[3].FindControl("MenuAsterisk");
        MenuAsterisk4.Style["display"] = (dtFields.Select("LeftMenuIndex = 10").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Name":
                    strInsuredVehicleDriverIDs += txtDriver_Name.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Name" + ",";
                    Span44.Style["display"] = "inline-block";
                    break;
                case "Social Security Number":
                    strInsuredVehicleDriverIDs += txtDriver_SSN.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Social Security Number" + ",";
                    Span45.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strInsuredVehicleDriverIDs += txtDriver_Address1.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Address 1" + ",";
                    Span46.Style["display"] = "inline-block";
                    break;
                case "Date of Birth":
                    strInsuredVehicleDriverIDs += txtDriver_Date_of_Birth.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Date of Birth" + ",";
                    Span47.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strInsuredVehicleDriverIDs += txtDriver_Address2.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Address 2" + ",";
                    Span48.Style["display"] = "inline-block";
                    break;
                case "Age":
                    strInsuredVehicleDriverIDs += txtDriverAgeCount.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Age" + ",";
                    Span49.Style["display"] = "inline-block";
                    break;
                case "City":
                    strInsuredVehicleDriverIDs += txtDriver_City.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/City" + ",";
                    Span50.Style["display"] = "inline-block";
                    break;
                case "Work Telephone":
                    strInsuredVehicleDriverIDs += txtDriver_Work_Phone.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Work Telephone" + ",";
                    Span51.Style["display"] = "inline-block";
                    break;
                case "State":
                    strInsuredVehicleDriverIDs += ddlDriver_State.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please select [Insured Vehicle Driver]/State" + ",";
                    Span52.Style["display"] = "inline-block";
                    break;
                case "Home Telephone":
                    strInsuredVehicleDriverIDs += txtDriver_Home_Phone.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Home Telephone" + ",";
                    Span53.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strInsuredVehicleDriverIDs += txtDriver_ZipCode.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Zip Code" + ",";
                    Span54.Style["display"] = "inline-block";
                    break;
                case "Alternate Telephone":
                    strInsuredVehicleDriverIDs += txtDriver_Altermate_Phone.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Alternate Telephone" + ",";
                    Span55.Style["display"] = "inline-block";
                    break;
                case "Driver’s License State":
                    strInsuredVehicleDriverIDs += ddlDriver_Drivers_License_State.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Driver’s License State" + ",";
                    Span56.Style["display"] = "inline-block";
                    break;
                case "Driver’s License Number":
                    strInsuredVehicleDriverIDs += txtDriver_Drivers_License_Number.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Driver’s License Number" + ",";
                    Span57.Style["display"] = "inline-block";
                    break;
                case "Relation to Insured":
                    strInsuredVehicleDriverIDs += txtDriver_Relation_to_Insured.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Relation to Insured" + ",";
                    Span58.Style["display"] = "inline-block";
                    break;
                case "Citation Number":
                    strInsuredVehicleDriverIDs += txtCitation_Number.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Citation Number" + ",";
                    Span59.Style["display"] = "inline-block";
                    break;
                case "Description of Injury":
                    strInsuredVehicleDriverIDs += txtDriver_Injury_Description.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Description of Injury" + ",";
                    Span60.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Name":
                    strInsuredVehicleDriverIDs += txtDriver_Medical_Facility_Name.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Medical Facility Name" + ",";
                    Span61.Style["display"] = "inline-block";
                    break;
                case "Date of Initial Treatment":
                    strInsuredVehicleDriverIDs += txtDriver_Date_Of_Initial_Treatment.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Date of Initial Treatment" + ",";
                    Span62.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Type":
                    strInsuredVehicleDriverIDs += txtDriver_Medical_Facility_Type.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Medical Facility Type" + ",";
                    Span63.Style["display"] = "inline-block";
                    break;
                case "Treating Physician’s Name":
                    strInsuredVehicleDriverIDs += txtDriver_Treating_Physician_Name.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Treating Physician’s Name" + ",";
                    Span64.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Address 1":
                    strInsuredVehicleDriverIDs += txtDriver_Medical_Facility_Address_1.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Medical Facility Address 1" + ",";
                    Span65.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Address 2":
                    strInsuredVehicleDriverIDs += txtDriver_Medical_Facility_Address_2.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Medical Facility Address 2" + ",";
                    Span66.Style["display"] = "inline-block";
                    break;
                case "Date Admitted":
                    strInsuredVehicleDriverIDs += txtDriver_Date_Admitted_to_Hospital.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Date Admitted" + ",";
                    Span67.Style["display"] = "inline-block";
                    break;
                case "Medical Facility City":
                    strInsuredVehicleDriverIDs += txtDriver_Medical_Facility_City.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Medical Facility City" + ",";
                    Span68.Style["display"] = "inline-block";
                    break;
                case "Medical Facility State":
                    strInsuredVehicleDriverIDs += ddlDriver_Medical_Facility_State.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please select [Insured Vehicle Driver]/Medical Facility State" + ",";
                    Span69.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Zip Code":
                    strInsuredVehicleDriverIDs += txtDriver_Medical_Facility_Zip_Code.ClientID + ",";
                    strInsuredVehicleDriverErrorMsgs += "Please enter [Insured Vehicle Driver]/Medical Facility Zip Code" + ",";
                    Span70.Style["display"] = "inline-block";
                    break;

            }
            #endregion
        }
        strInsuredVehicleDriverIDs = strInsuredVehicleDriverIDs.TrimEnd(',');
        strInsuredVehicleDriverErrorMsgs = strInsuredVehicleDriverErrorMsgs.TrimEnd(',');

        hdnInsuredVehicleDriverIDs.Value = strInsuredVehicleDriverIDs;
        hdnInsuredVehicleDriverErrorMsgs.Value = strInsuredVehicleDriverErrorMsgs;
        #endregion

        #region "Insured Vehicle Passenger"
        dtFields = clsScreen_Validators.SelectByScreen(11).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk5 = (Label)mnuAL.Controls[4].FindControl("MenuAsterisk");
        MenuAsterisk5.Style["display"] = (dtFields.Select("LeftMenuIndex = 11").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Name":
                    strInsuredVehiclePassengerIDs += txtPassenger_Name.ClientID + ",";
                    strInsuredVehiclePassengerErrorMsgs += "Please enter [Insured Vehicle Passenger]/Name" + ",";
                    Span71.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strInsuredVehiclePassengerIDs += txtPassenger_Address_1.ClientID + ",";
                    strInsuredVehiclePassengerErrorMsgs += "Please enter [Insured Vehicle Passenger]/Address 1" + ",";
                    Span72.Style["display"] = "inline-block";
                    break;
                case "Date of Birth":
                    strInsuredVehiclePassengerIDs += txtPassenger_Date_of_Birth.ClientID + ",";
                    strInsuredVehiclePassengerErrorMsgs += "Please enter [Insured Vehicle Passenger]/Date of Birth" + ",";
                    Span73.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strInsuredVehiclePassengerIDs += txtPassenger_Address_2.ClientID + ",";
                    strInsuredVehiclePassengerErrorMsgs += "Please enter [Insured Vehicle Passenger]/Address 2" + ",";
                    Span74.Style["display"] = "inline-block";
                    break;
                case "Age":
                    strInsuredVehiclePassengerIDs += txtPassengerAgeCount.ClientID + ",";
                    strInsuredVehiclePassengerErrorMsgs += "Please enter [Insured Vehicle Passenger]/Age" + ",";
                    Span75.Style["display"] = "inline-block";
                    break;
                case "City":
                    strInsuredVehiclePassengerIDs += txtPassenger_City.ClientID + ",";
                    strInsuredVehiclePassengerErrorMsgs += "Please enter [Insured Vehicle Passenger]/City" + ",";
                    Span76.Style["display"] = "inline-block";
                    break;
                case "Work Telephone":
                    strInsuredVehiclePassengerIDs += txtPassenger_Work_Phone.ClientID + ",";
                    strInsuredVehiclePassengerErrorMsgs += "Please enter [Insured Vehicle Passenger]/Work Telephone" + ",";
                    Span77.Style["display"] = "inline-block";
                    break;
                case "State":
                    strInsuredVehiclePassengerIDs += ddlPassenger_State.ClientID + ",";
                    strInsuredVehiclePassengerErrorMsgs += "Please select [Insured Vehicle Passenger]/State" + ",";
                    Span78.Style["display"] = "inline-block";
                    break;
                case "Home Telephone":
                    strInsuredVehiclePassengerIDs += txtPassenger_Home_Phone.ClientID + ",";
                    strInsuredVehiclePassengerErrorMsgs += "Please enter [Insured Vehicle Passenger]/Home Telephone" + ",";
                    Span79.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strInsuredVehiclePassengerIDs += txtPassenger_ZipCode.ClientID + ",";
                    strInsuredVehiclePassengerErrorMsgs += "Please enter [Insured Vehicle Passenger]/Zip Code" + ",";
                    Span80.Style["display"] = "inline-block";
                    break;
                case "Alternate Telephone":
                    strInsuredVehiclePassengerIDs += txtPassenger_Alternate_Phone.ClientID + ",";
                    strInsuredVehiclePassengerErrorMsgs += "Please enter [Insured Vehicle Passenger]/Alternate Telephone" + ",";
                    Span81.Style["display"] = "inline-block";
                    break;
                case "Driver’s License State":
                    strInsuredVehiclePassengerIDs += ddlPassenger_Drivers_License_State.ClientID + ",";
                    strInsuredVehiclePassengerErrorMsgs += "Please select [Insured Vehicle Passenger]/Driver’s License State" + ",";
                    Span82.Style["display"] = "inline-block";
                    break;
                case "Driver’s License Number":
                    strInsuredVehiclePassengerIDs += txtPassenger_Drivers_License_Number.ClientID + ",";
                    strInsuredVehiclePassengerErrorMsgs += "Please enter [Insured Vehicle Passenger]/Driver’s License Number" + ",";
                    Span83.Style["display"] = "inline-block";
                    break;
                case "Relation to Insured":
                    strInsuredVehiclePassengerIDs += txtPassenger_Relation_to_Insured.ClientID + ",";
                    strInsuredVehiclePassengerErrorMsgs += "Please enter [Insured Vehicle Passenger]/Relation to Insured" + ",";
                    Span84.Style["display"] = "inline-block";
                    break;
                case "Description of Injury":
                    strInsuredVehiclePassengerIDs += txtPassenger_Description_of_Injury.ClientID + ",";
                    strInsuredVehiclePassengerErrorMsgs += "Please enter [Insured Vehicle Passenger]/Description of Injury" + ",";
                    Span85.Style["display"] = "inline-block";
                    break;

            }
            #endregion
        }
        strInsuredVehiclePassengerIDs = strInsuredVehiclePassengerIDs.TrimEnd(',');
        strInsuredVehiclePassengerErrorMsgs = strInsuredVehiclePassengerErrorMsgs.TrimEnd(',');

        hdnInsuredVehiclePassengerIDs.Value = strInsuredVehiclePassengerIDs;
        hdnInsuredVehiclePassengerErrorMsgs.Value = strInsuredVehiclePassengerErrorMsgs;
        #endregion

        #region "Other Vehicle"
        dtFields = clsScreen_Validators.SelectByScreen(12).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk6 = (Label)mnuAL.Controls[5].FindControl("MenuAsterisk");
        MenuAsterisk6.Style["display"] = (dtFields.Select("LeftMenuIndex = 12").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Year":
                    strOtherVehicleIDs += txtOther_Vehicle_Year.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Year" + ",";
                    Span86.Style["display"] = "inline-block";
                    break;
                case "Make":
                    strOtherVehicleIDs += txtOther_Vehicle_Make.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Make" + ",";
                    Span87.Style["display"] = "inline-block";
                    break;
                case "Model":
                    strOtherVehicleIDs += txtOther_Vehicle_Model.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Model" + ",";
                    Span88.Style["display"] = "inline-block";
                    break;
                case "VIN":
                    strOtherVehicleIDs += txtOther_Vehicle_VIN.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/VIN" + ",";
                    Span89.Style["display"] = "inline-block";
                    break;
                case "License Plate Number":
                    strOtherVehicleIDs += txtOther_Vehicle_License_Plate_Number.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/License Plate Number" + ",";
                    Span90.Style["display"] = "inline-block";
                    break;
                case "License Plate State":
                    strOtherVehicleIDs += ddlOther_Vehicle_License_Plate_State.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please select [Other Vehicle]/License Plate State" + ",";
                    Span91.Style["display"] = "inline-block";
                    break;
                case "Vehicle Color":
                    strOtherVehicleIDs += txtOther_Vehicle_Vehicle_Color.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Vehicle Color" + ",";
                    Span92.Style["display"] = "inline-block";
                    break;
                case "Insurance Company Name":
                    strOtherVehicleIDs += txtOther_Vehicle_Insurance_Co_Name.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Insurance Company Name" + ",";
                    Span93.Style["display"] = "inline-block";
                    break;
                case "Insurance Company Phone":
                    strOtherVehicleIDs += txtOther_Vehicle_Insurance_Co_Phone.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Insurance Company Phone" + ",";
                    Span94.Style["display"] = "inline-block";
                    break;
                case "Policy Number":
                    strOtherVehicleIDs += txtOther_Vehicle_Insurance_Policy_Number.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Policy Number" + ",";
                    Span95.Style["display"] = "inline-block";
                    break;
                case "Description of Damage":
                    strOtherVehicleIDs += txtOther_Vehicle_Vehicle_Damage_Description.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Description of Damage" + ",";
                    Span96.Style["display"] = "inline-block";
                    break;
                case "Estimated Amount":
                    strOtherVehicleIDs += txtOther_Vehicle_Repairs_Estimated_Amount.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Estimated Amount" + ",";
                    Span97.Style["display"] = "inline-block";
                    break;
                case "Location where vehicle can be seen":
                    strOtherVehicleIDs += txtOther_Vehicle_Location.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Location where vehicle can be seen" + ",";
                    Span98.Style["display"] = "inline-block";
                    break;
                case "Location Telephone":
                    strOtherVehicleIDs += txtOther_Vehicle_Location_Telephone.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Location Telephone" + ",";
                    Span99.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strOtherVehicleIDs += txtOther_Vehicle_Location_Driver_Address_1.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Address 1" + ",";
                    Span100.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strOtherVehicleIDs += txtOther_Vehicle_Location_Driver_Address_2.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Address 2" + ",";
                    Span101.Style["display"] = "inline-block";
                    break;
                case "City":
                    strOtherVehicleIDs += txtOther_Vehicle_Location_Driver_City.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/City" + ",";
                    Span102.Style["display"] = "inline-block";
                    break;
                case "State":
                    strOtherVehicleIDs += ddlOther_Vehicle_Location_Driver_State.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please select [Other Vehicle]/State" + ",";
                    Span103.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strOtherVehicleIDs += txtOther_Vehicle_Location_Driver_ZipCode.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Zip Code" + ",";
                    Span104.Style["display"] = "inline-block";
                    break;
                case "Owner Name":
                    strOtherVehicleIDs += txtOther_Vehicle_Owner_Name.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Owner Name" + ",";
                    Span105.Style["display"] = "inline-block";
                    break;
                case "Work Telephone":
                    strOtherVehicleIDs += txtOther_Vehicle_Owner_Work_Phone.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Work Telephone" + ",";
                    Span106.Style["display"] = "inline-block";
                    break;
                case "Owner Address 1":
                    strOtherVehicleIDs += txtOther_Vehicle_Owner_Address_1.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Address 1" + ",";
                    Span107.Style["display"] = "inline-block";
                    break;
                case "Home Telephone":
                    strOtherVehicleIDs += txtOther_Vehicle_Owner_Home_Phone.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Home Telephone" + ",";
                    Span108.Style["display"] = "inline-block";
                    break;
                case "Owner Address 2":
                    strOtherVehicleIDs += txtOther_Vehicle_Owner_Address_2.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Address 2" + ",";
                    Span109.Style["display"] = "inline-block";
                    break;
                case "Alternate Telephone":
                    strOtherVehicleIDs += txtOther_Vehicle_Owner_Alternate_Phone.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Alternate Telephone" + ",";
                    Span110.Style["display"] = "inline-block";
                    break;
                case "Owner City":
                    strOtherVehicleIDs += txtOther_Vehicle_Owner_City.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/City" + ",";
                    Span111.Style["display"] = "inline-block";
                    break;
                case "Owner State":
                    strOtherVehicleIDs += ddlOther_Vehicle_Owner_State.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please select [Other Vehicle]/State" + ",";
                    Span112.Style["display"] = "inline-block";
                    break;
                case "Owner Zip Code":
                    strOtherVehicleIDs += txtOther_Vehicle_Owner_ZipCode.ClientID + ",";
                    strOtherVehicleErrorMsgs += "Please enter [Other Vehicle]/Zip Code" + ",";
                    Span113.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        strOtherVehicleIDs = strOtherVehicleIDs.TrimEnd(',');
        strOtherVehicleErrorMsgs = strOtherVehicleErrorMsgs.TrimEnd(',');

        hdnOtherVehicleIDs.Value = strOtherVehicleIDs;
        hdnOtherVehicleErrorMsgs.Value = strOtherVehicleErrorMsgs;
        #endregion

        #region "Other Vehicle Driver"
        dtFields = clsScreen_Validators.SelectByScreen(13).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk7 = (Label)mnuAL.Controls[6].FindControl("MenuAsterisk");
        MenuAsterisk7.Style["display"] = (dtFields.Select("LeftMenuIndex = 13").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Name":
                    strOtherVehicleDriverIDs += txtOther_Driver_Name.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Name" + ",";
                    Span114.Style["display"] = "inline-block";
                    break;
                case "Social Security Number":
                    strOtherVehicleDriverIDs += txtOther_Driver_SSN.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Social Security Number" + ",";
                    Span115.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strOtherVehicleDriverIDs += txtOther_Driver_Address_1.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Address 1" + ",";
                    Span116.Style["display"] = "inline-block";
                    break;
                case "Date of Birth":
                    strOtherVehicleDriverIDs += txtOther_Driver_Date_of_Birth.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Date of Birth" + ",";
                    Span117.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strOtherVehicleDriverIDs += txtOther_Driver_Address_2.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Address 2" + ",";
                    Span118.Style["display"] = "inline-block";
                    break;
                case "Age":
                    strOtherVehicleDriverIDs += txtOther_Driver_AgeCount.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Age" + ",";
                    Span119.Style["display"] = "inline-block";
                    break;
                case "City":
                    strOtherVehicleDriverIDs += txtOther_Driver_City.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/City" + ",";
                    Span120.Style["display"] = "inline-block";
                    break;
                case "Work Telephone":
                    strOtherVehicleDriverIDs += txtOther_Driver_Work_Phone.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Work Telephone" + ",";
                    Span121.Style["display"] = "inline-block";
                    break;
                case "State":
                    strOtherVehicleDriverIDs += ddlOther_Driver_State.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please select [Other Vehicle Driver]/State" + ",";
                    Span122.Style["display"] = "inline-block";
                    break;
                case "Home Telephone":
                    strOtherVehicleDriverIDs += txtOther_Driver_Home_Phone.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Home Telephone" + ",";
                    Span123.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strOtherVehicleDriverIDs += txtOther_Driver_ZipCode.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Zip Code" + ",";
                    Span124.Style["display"] = "inline-block";
                    break;
                case "Driver’s License Number":
                    strOtherVehicleDriverIDs += txtOther_Driver_Drivers_License_Number.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Driver’s License Number" + ",";
                    Span125.Style["display"] = "inline-block";
                    break;
                case "Gender":
                    strOtherVehicleDriverIDs += txtOther_Driver_Gender.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Gender" + ",";
                    Span126.Style["display"] = "inline-block";
                    break;
                case "Driver’s License State":
                    strOtherVehicleDriverIDs += ddlOther_Driver_Drivers_License_State.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please select [Other Vehicle Driver]/Driver’s License State" + ",";
                    Span127.Style["display"] = "inline-block";
                    break;
                case "Citation Number":
                    strOtherVehicleDriverIDs += txtOther_Driver_Citation_Number.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Citation Number" + ",";
                    Span128.Style["display"] = "inline-block";
                    break;
                case "Description of Injury":
                    strOtherVehicleDriverIDs += txtOther_Driver_Injury_Description.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Description of Injury" + ",";
                    Span129.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Name":
                    strOtherVehicleDriverIDs += txtOther_Driver_Medical_Facility_Name.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Medical Facility Name" + ",";
                    Span130.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Address 1":
                    strOtherVehicleDriverIDs += txtOther_Driver_Medical_Facility_Address_1.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Medical Facility Address 1" + ",";
                    Span131.Style["display"] = "inline-block";
                    break;
                case "Date Admitted":
                    strOtherVehicleDriverIDs += txtOther_Driver_Date_Admitted_to_Hospital.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Date Admitted" + ",";
                    Span132.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Address 2":
                    strOtherVehicleDriverIDs += txtOther_Driver_Medical_Facility_Address_2.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Medical Facility Address 2" + ",";
                    Span133.Style["display"] = "inline-block";
                    break;
                case "Medical Facility City":
                    strOtherVehicleDriverIDs += txtOther_Driver_Medical_Facility_City.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Medical Facility City" + ",";
                    Span134.Style["display"] = "inline-block";
                    break;
                case "Physician's Name":
                    strOtherVehicleDriverIDs += txtOther_Driver_Physicians_Name.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Physician's Name" + ",";
                    Span135.Style["display"] = "inline-block";
                    break;
                case "Medical Facility State":
                    strOtherVehicleDriverIDs += ddlOther_Driver_Medical_Facility_State.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please select [Other Vehicle Driver]/Medical Facility State" + ",";
                    Span136.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Zip Code":
                    strOtherVehicleDriverIDs += txtOther_Driver_Medical_Facility_Zip_Code.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Medical Facility Zip Code" + ",";
                    Span137.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Type":
                    strOtherVehicleDriverIDs += txtOther_Driver_Medical_Facility_Type.ClientID + ",";
                    strOtherVehicleDriverErrorMsgs += "Please enter [Other Vehicle Driver]/Medical Facility Type" + ",";
                    Span138.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        strOtherVehicleDriverIDs = strOtherVehicleDriverIDs.TrimEnd(',');
        strOtherVehicleDriverErrorMsgs = strOtherVehicleDriverErrorMsgs.TrimEnd(',');

        hdnOtherVehicleDriverIDs.Value = strOtherVehicleDriverIDs;
        hdnOtherVehicleDriverErrorMsgs.Value = strOtherVehicleDriverErrorMsgs;
        #endregion

        #region "Other Vehicle Passenger"
        dtFields = clsScreen_Validators.SelectByScreen(14).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk8 = (Label)mnuAL.Controls[7].FindControl("MenuAsterisk");
        MenuAsterisk8.Style["display"] = (dtFields.Select("LeftMenuIndex = 14").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Name":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Name.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Name" + ",";
                    Span139.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Address_1.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Address 1" + ",";
                    Span140.Style["display"] = "inline-block";
                    break;
                case "Date of Birth":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Date_of_Birth.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Date of Birth" + ",";
                    Span141.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Address_2.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Address 2" + ",";
                    Span142.Style["display"] = "inline-block";
                    break;
                case "Age":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_AgeCount.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Age" + ",";
                    Span143.Style["display"] = "inline-block";
                    break;
                case "City":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_City.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/City" + ",";
                    Span144.Style["display"] = "inline-block";
                    break;
                case "Work Telephone":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Work_Phone.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Work Telephone" + ",";
                    Span145.Style["display"] = "inline-block";
                    break;
                case "State":
                    strOtherVehiclePassengerIDs += ddlOth_Veh_Pass_State.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please select [Other Vehicle Passenger]/State" + ",";
                    Span146.Style["display"] = "inline-block";
                    break;
                case "Home Telephone":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Home_Phone.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please select [Other Vehicle Passenger]/Home Telephone" + ",";
                    Span147.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_ZipCode.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please select [Other Vehicle Passenger]/Zip Code" + ",";
                    Span148.Style["display"] = "inline-block";
                    break;
                case "Alternate Telephone":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Alternate_Phone.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Alternate Telephone" + ",";
                    Span149.Style["display"] = "inline-block";
                    break;
                case "Description of Injury":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Injury_Description.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Description of Injury" + ",";
                    Span150.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Name":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Medical_Facility_Name.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Medical Facility Name" + ",";
                    Span151.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Address 1":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Medical_Facility_Address_1.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Medical Facility Address 1" + ",";
                    Span152.Style["display"] = "inline-block";
                    break;
                case "Date Admitted":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Date_Admitted_to_Hospital.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Date Admitted" + ",";
                    Span153.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Address 2":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Medical_Facility_Address_2.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Medical Facility Address 2" + ",";
                    Span154.Style["display"] = "inline-block";
                    break;
                case "Medical Facility City":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Medical_Facility_City.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Medical Facility City" + ",";
                    Span155.Style["display"] = "inline-block";
                    break;
                case "Physician's Name":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Physicians_Name.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Physician's Name" + ",";
                    Span156.Style["display"] = "inline-block";
                    break;
                case "Medical Facility State":
                    strOtherVehiclePassengerIDs += ddlOth_Veh_Pass_Medical_Facility_State.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please select [Other Vehicle Passenger]/Medical Facility State" + ",";
                    Span157.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Zip Code":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Medical_Facility_Zip_Code.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Medical Facility Zip Code" + ",";
                    Span158.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Type":
                    strOtherVehiclePassengerIDs += txtOth_Veh_Pass_Medical_Facility_Type.ClientID + ",";
                    strOtherVehiclePassengerErrorMsgs += "Please enter [Other Vehicle Passenger]/Medical Facility Type" + ",";
                    Span159.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        strOtherVehiclePassengerIDs = strOtherVehiclePassengerIDs.TrimEnd(',');
        strOtherVehiclePassengerErrorMsgs = strOtherVehiclePassengerErrorMsgs.TrimEnd(',');

        hdnOtherVehiclePassengerIDs.Value = strOtherVehiclePassengerIDs;
        hdnOtherVehiclePassengerErrorMsgs.Value = strOtherVehiclePassengerErrorMsgs;
        #endregion

        #region "Pedestrian"
        dtFields = clsScreen_Validators.SelectByScreen(15).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk9 = (Label)mnuAL.Controls[8].FindControl("MenuAsterisk");
        MenuAsterisk9.Style["display"] = (dtFields.Select("LeftMenuIndex = 15").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Name":
                    strPedestrianIDs += txtPedestrian_Name.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Name" + ",";
                    Span160.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strPedestrianIDs += txtPedestrian_Address_1.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Address 1" + ",";
                    Span161.Style["display"] = "inline-block";
                    break;
                case "Date of Birth":
                    strPedestrianIDs += txtPedestrian_Date_of_Birth.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Date of Birth" + ",";
                    Span162.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strPedestrianIDs += txtPedestrian_Address_2.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Address 2" + ",";
                    Span163.Style["display"] = "inline-block";
                    break;
                case "Age":
                    strPedestrianIDs += txtPedestrianAgeCount.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Age" + ",";
                    Span164.Style["display"] = "inline-block";
                    break;
                case "City":
                    strPedestrianIDs += txtPedestrian_City.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/City" + ",";
                    Span165.Style["display"] = "inline-block";
                    break;
                case "Work Telephone":
                    strPedestrianIDs += txtPedestrian_Work_Phone.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Work Telephone" + ",";
                    Span166.Style["display"] = "inline-block";
                    break;
                case "State":
                    strPedestrianIDs += ddlPedestrian_State.ClientID + ",";
                    strPedestrianErrorMsgs += "Please select [Pedestrian]/State" + ",";
                    Span167.Style["display"] = "inline-block";
                    break;
                case "Home Telephone":
                    strPedestrianIDs += txtPedestrian_Home_Phone.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Home Telephone" + ",";
                    Span168.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strPedestrianIDs += txtPedestrian_ZipCode.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Zip Code" + ",";
                    Span169.Style["display"] = "inline-block";
                    break;
                case "Alternate Telephone":
                    strPedestrianIDs += txtPedestrian_Alternate_Phone.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Alternate Telephone" + ",";
                    Span170.Style["display"] = "inline-block";
                    break;
                case "Description of Injury":
                    strPedestrianIDs += txtPedestrian_Injury_Description.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Description of Injury" + ",";
                    Span171.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Name":
                    strPedestrianIDs += txtPedestrian_Medical_Facility_Name.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Medical Facility Name" + ",";
                    Span172.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Address 1":
                    strPedestrianIDs += txtPedestrian_Medical_Facility_Address_1.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Medical Facility Address 1" + ",";
                    Span173.Style["display"] = "inline-block";
                    break;
                case "Date Admitted":
                    strPedestrianIDs += txtPedestrian_Date_Admitted_to_Hospital.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Date Admitted" + ",";
                    Span174.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Address 2":
                    strPedestrianIDs += txtPedestrian_Medical_Facility_Address_2.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Medical Facility Address 2" + ",";
                    Span175.Style["display"] = "inline-block";
                    break;
                case "Medical Facility City":
                    strPedestrianIDs += txtPedestrian_Medical_Facility_City.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Medical Facility City" + ",";
                    Span176.Style["display"] = "inline-block";
                    break;
                case "Physician's Name":
                    strPedestrianIDs += txtPedestrian_Physicians_Name.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Physician's Name" + ",";
                    Span177.Style["display"] = "inline-block";
                    break;
                case "Medical Facility State":
                    strPedestrianIDs += ddlPedestrian_Medical_Facility_State.ClientID + ",";
                    strPedestrianErrorMsgs += "Please select [Pedestrian]/Medical Facility State" + ",";
                    Span178.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Zip Code":
                    strPedestrianIDs += txtPedestrian_Medical_Facility_Zip_Code.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Medical Facility Zip Code" + ",";
                    Span179.Style["display"] = "inline-block";
                    break;
                case "Medical Facility Type":
                    strPedestrianIDs += txtPedestrian_Medical_Facility_Type.ClientID + ",";
                    strPedestrianErrorMsgs += "Please enter [Pedestrian]/Medical Facility Type" + ",";
                    Span180.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        strPedestrianIDs = strPedestrianIDs.TrimEnd(',');
        strPedestrianErrorMsgs = strPedestrianErrorMsgs.TrimEnd(',');

        hdnPedestrianIDs.Value = strPedestrianIDs;
        hdnPedestrianErrorMsgs.Value = strPedestrianErrorMsgs;
        #endregion

        #region "Witness"
        dtFields = clsScreen_Validators.SelectByScreen(16).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk10 = (Label)mnuAL.Controls[9].FindControl("MenuAsterisk");
        MenuAsterisk10.Style["display"] = (dtFields.Select("LeftMenuIndex = 16").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Name":
                    strWitnessIDs += txtWitness_Name.ClientID + ",";
                    strWitnessErrorMsgs += "Please enter [Witness]/Name" + ",";
                    Span181.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strWitnessIDs += txtWitness_Address_1.ClientID + ",";
                    strWitnessErrorMsgs += "Please enter [Witness]/Address 1" + ",";
                    Span182.Style["display"] = "inline-block";
                    break;
                case "Home Telephone":
                    strWitnessIDs += txtWitness_Home_Phone.ClientID + ",";
                    strWitnessErrorMsgs += "Please enter [Witness]/Home Telephone" + ",";
                    Span183.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strWitnessIDs += txtWitness_Address_2.ClientID + ",";
                    strWitnessErrorMsgs += "Please enter [Witness]/Address 2" + ",";
                    Span184.Style["display"] = "inline-block";
                    break;
                case "Work Telephone":
                    strWitnessIDs += txtWitness_Work_Phone.ClientID + ",";
                    strWitnessErrorMsgs += "Please enter [Witness]/Work Telephone" + ",";
                    Span185.Style["display"] = "inline-block";
                    break;
                case "City":
                    strWitnessIDs += txtWitness_City.ClientID + ",";
                    strWitnessErrorMsgs += "Please enter [Witness]/City" + ",";
                    Span186.Style["display"] = "inline-block";
                    break;
                case "Alternate Telephone":
                    strWitnessIDs += txtWitness_Alternate_Phone.ClientID + ",";
                    strWitnessErrorMsgs += "Please enter [Witness]/Alternate Telephone" + ",";
                    Span187.Style["display"] = "inline-block";
                    break;
                case "State":
                    strWitnessIDs += ddlWitness_State.ClientID + ",";
                    strWitnessErrorMsgs += "Please select [Witness]/State" + ",";
                    Span188.Style["display"] = "inline-block";
                    break;
                case "Zip":
                    strWitnessIDs += txtWitness_Zip_Code.ClientID + ",";
                    strWitnessErrorMsgs += "Please enter [Witness]/Zip" + ",";
                    Span189.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        strWitnessIDs = strWitnessIDs.TrimEnd(',');
        strWitnessErrorMsgs = strWitnessErrorMsgs.TrimEnd(',');

        hdnWitnessIDs.Value = strWitnessIDs;
        hdnWitnessErrorMsgs.Value = strWitnessErrorMsgs;
        #endregion

        #region "Comments"
        dtFields = clsScreen_Validators.SelectByScreen(17).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk11 = (Label)mnuAL.Controls[10].FindControl("MenuAsterisk");
        MenuAsterisk11.Style["display"] = (dtFields.Select("LeftMenuIndex = 17").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Comments":
                    strCommentsIDs += txtComments.ClientID + ",";
                    strCommentsErrorMsgs += "Please enter [Comments]/Comments" + ",";
                    Span190.Style["display"] = "inline-block";
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
        objFROI.FROI_Type = "AL";
        objFROI.FROI_Number = Convert.ToDecimal(((Label)SonicInfo.FindControl("lblFirstReportNumber")).Text.Trim().Replace("AL-", ""));
        objFROI.Insert();
    }
}