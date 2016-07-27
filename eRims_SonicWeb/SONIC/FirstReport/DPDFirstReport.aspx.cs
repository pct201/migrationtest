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
/// Developer Name : Ravi Gupta   |   Date : 04-08-08
/// Modified By : Dhruti Desai    |   Date : 16-11-10
/// Description    : This Page is used to Add a Dealer Physical Damage Information regarding current First Report Wizard. it also display stored data in View Mode.
/// </summary>

public partial class SONIC_DPDFirstReport : clsBasePage
{
    #region Default Value of Incident_Type Field
    //Here in Incident_Type Filed the value indicate Following Meaning
    //1 = MVA-Single , 2= MVA=Multiple , 3=Fraud , 4=Theft , 5=Partial Theft ,6=Vandalism ,7=Hail , 8=Flood ,9=Fire ,10=Wind  
    #endregion

    #region Private Variable and Property
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
    /// Denotes the DPD First Report ID
    /// </summary>
    public int PK_DPD_FR_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["DPD_FR_ID"]);
        }
        set { ViewState["DPD_FR_ID"] = value; }
    }
    /// <summary>
    /// Denotes the DPD Vehicle First Report ID
    /// </summary>
    public int PK_DPD_FR_Vehicle_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["DPD_FR_Vehicle_ID"]);
        }
        set { ViewState["DPD_FR_Vehicle_ID"] = value; }
    }
    /// <summary>
    /// Denotes the DPD Vehicle First Report ID for Single Vehicle
    /// </summary>
    public int PK_DPD_FR_Single_Vehicle_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["DPD_FR_Single_Vehicle_ID"]);
        }
        set { ViewState["DPD_FR_Single_Vehicle_ID"] = value; }
    }

    /// <summary>
    /// Denotes the DPD Vehicle First Report ID for Single Vehicle
    /// </summary>
    public int PK_DPD_FR_Passenger_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_DPD_FR_Passenger_ID"]);
        }
        set { ViewState["PK_DPD_FR_Passenger_ID"] = value; }
    }
    /// <summary>
    /// Denotes the DPD Vehicle First Report ID for Theft Vehicle
    /// </summary>
    public int PK_DPD_FR_Theft_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_DPD_FR_Theft_ID"]);
        }
        set { ViewState["PK_DPD_FR_Theft_ID"] = value; }
    }

    /// <summary>
    /// Denotes the DPD Vehicle First Report ID for Partial Theft Vehicle
    /// </summary>
    public int PK_DPD_FR_Partial_Theft_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_DPD_FR_Partial_Theft_ID"]);
        }
        set { ViewState["PK_DPD_FR_Partial_Theft_ID"] = value; }
    }

    /// <summary>
    /// Denotes the DPD Vehicle First Report ID for Vandalism
    /// </summary>
    public int PK_DPD_FR_Vandalism_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_DPD_FR_Vandalism_ID"]);
        }
        set { ViewState["PK_DPD_FR_Vandalism_ID"] = value; }
    }

    /// <summary>
    /// Denotes the DPD Vehicle First Report ID for Hail
    /// </summary>
    public int PK_DPD_FR_Hail_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_DPD_FR_Hail_ID"]);
        }
        set { ViewState["PK_DPD_FR_Hail_ID"] = value; }
    }

    /// <summary>
    /// Denotes the DPD Vehicle First Report ID for Flood
    /// </summary>
    public int PK_DPD_FR_Flood_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_DPD_FR_Flood_ID"]);
        }
        set { ViewState["PK_DPD_FR_Flood_ID"] = value; }
    }

    /// <summary>
    /// Denotes the DPD Vehicle First Report ID for Fire
    /// </summary>
    public int PK_DPD_FR_Fire_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_DPD_FR_Fire_ID"]);
        }
        set { ViewState["PK_DPD_FR_Fire_ID"] = value; }
    }

    /// <summary>
    /// Denotes the DPD Vehicle First Report ID for Wind
    /// </summary>
    public int PK_DPD_FR_Wind_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_DPD_FR_Wind_ID"]);
        }
        set { ViewState["PK_DPD_FR_Wind_ID"] = value; }
    }
    /// <summary>
    /// Denotes the DPD Vehicle First Report ID for Multi Vehicle
    /// </summary>
    public int PK_DPD_FR_Multi_Vehicle_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["DPD_FR_Multi_Vehicle_ID"]);
        }
        set { ViewState["DPD_FR_Multi_Vehicle_ID"] = value; }
    }
    /// <summary>
    /// Denotes the DPD Vehicle First Report ID for Fraud Section
    /// </summary>
    public int PK_DPD_FR_Fraud_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_DPD_FR_Fraud_ID"]);
        }
        set { ViewState["PK_DPD_FR_Fraud_ID"] = value; }
    }

    /// <summary>
    /// Denotes the DPD Vehicle First Report Witness ID for Withess Section
    /// </summary>
    public int PK_DPD_Witness_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_DPD_Witness_ID"]);
        }
        set { ViewState["PK_DPD_Witness_ID"] = value; }
    }

    public Hashtable ht_PK_Vehicle_IncidentType
    {
        get
        {
            if (ViewState["ht_PK_Vehicle_IncidentType"] != null)
                return (Hashtable)ViewState["ht_PK_Vehicle_IncidentType"];
            else
                return new Hashtable();
        }
        set { ViewState["ht_PK_Vehicle_IncidentType"] = value; }
    }

    #endregion

    #region "Page Event"
    /// <summary>
    /// Handles Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        SonicTab.SetSelectedTab(Controls_SONICtab_SonicTab.Tab.DPD);
        //declare Handle of Attachment Control for File Upload
        CtrlAttachment.btnHandler += new Sonic_Attachment_DPD.OnButtonClick(Upload_File);
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
            //Used to get PK id from QUery string
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                try
                {
                    PK_DPD_FR_ID = Convert.ToInt32(Encryption.Decrypt(Request.QueryString["id"].ToString()));
                    //set Page Mode as per User Access Type if it is View ONly than always open page in
                    //View Mode Only. else if the report is completed  than open page in View MOde Else in Edit MOde
                    if (Module_Access_Mode == AccessType.View_Only)
                    //if (UserAccessType == AccessType.View_Only)
                    {
                        strPageOpeMode = "view";
                    }
                    else
                    {
                        strPageOpeMode = (new DPD_FR(PK_DPD_FR_ID).Complete == false) ? "edit" : "view";
                    }

                    btnSendMail.Visible = (UserAccessType == AccessType.Administrative_Access) && (new DPD_FR(PK_DPD_FR_ID).Complete == true);
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

            //#region Enable Validator for MVA Single
            //RequiredFieldValidator rfvDrugTestResult = (RequiredFieldValidator)txtDrug_test_results.FindControl("rfvNotes");
            //RequiredFieldValidator rfvDrugTestExplain = (RequiredFieldValidator)txtDrug_test_explanation.FindControl("rfvNotes");
            //RequiredFieldValidator rfvMVA_SingleNot_Driven_By_Customer_Explain = (RequiredFieldValidator)txtMVA_SingleNot_Driven_By_Customer_Explain.FindControl("rfvNotes");
            //rdoDrug_test_performed.Attributes.Add("onclick", "CheckDrugTest(" + rfvDrugTestResult.ClientID + "," + rfvDrugTestExplain.ClientID + ")");
            //rdoAssociate_Cited.Attributes.Add("onclick", "CheckSingleCitation()");
            //rdoVehicle_Driven_By_Customer.Attributes.Add("onclick", "CheckDrivenByCust()");

            //#endregion

            //#region Enable Validator for MVA Multi
            RequiredFieldValidator rfvMVA_MultiDrugTestResult_Multi = (RequiredFieldValidator)txtMVA_MultiDrug_test_results.FindControl("rfvNotes");
            RequiredFieldValidator rfvMVA_MultiDrugTestExplain_Multi = (RequiredFieldValidator)txtMVA_MultiDrug_test_explanation.FindControl("rfvNotes");
            RequiredFieldValidator rfvMVA_MultiDesc_Citation_Multi = (RequiredFieldValidator)txtMVA_MultiDescription_Of_Citation.FindControl("rfvNotes");
            RequiredFieldValidator rfvMVA_MultiNot_Driven_By_Customer_Explain = (RequiredFieldValidator)txtMVA_MultiNot_Driven_By_Customer_Explain.FindControl("rfvNotes");
            rdoMVA_MultiDrug_test_performed.Attributes.Add("onclick", "CheckMultiDrugTest(" + rfvMVA_MultiDrugTestResult_Multi.ClientID + "," + rfvMVA_MultiDrugTestExplain_Multi.ClientID + ")");
            rdoMVA_MultiAssociate_Cited.Attributes.Add("onclick", "CheckMultiCitation(" + rfvMVA_MultiDesc_Citation_Multi.ClientID + ")");
            rdoMVA_MultiVehicle_Driven_By_Customer.Attributes.Add("onclick", "CheckMultiDrivenByCust(" + rfvMVA_MultiNot_Driven_By_Customer_Explain.ClientID + ")");


            //#endregion
            //used to check current Operation Mode
            if (strPageOpeMode == "add")
            {
                //Used to display first panel.
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
                #region Location and Contact Panel
                //fill Sonic Location Number
                ComboHelper.FillSonicLocationNumberOnly(new DropDownList[] { ddlLocationNumber }, 0, true);
                //Fill Location dba Dropdown
                ComboHelper.FillLocationdba(new DropDownList[] { ddlLocationdba }, 0, true);
                //Fill Location Legal Entity Dropdown
                //ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, 0, true);
                //Fill Location FKA Dropdown
                ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);
                //Fill State Dropdown
                ComboHelper.FillState(new DropDownList[] { ddlLoss_State }, 0, true);
                //Fetch Related Record for Location and EMployee
                BindLocationandContactInfo();
                #endregion

                #region Loss Information Panel
                #endregion

                #region Attchement
                BindAttachmentTypes("");
                CtrlAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.DPD_FR, PK_DPD_FR_ID, true, 4);
                #endregion
            }
            else if (strPageOpeMode == "view")
            {
                //Fetch records and display records into view mode
                BindPageInViewMode();
                //used to display related Panel useing Showpanel javascript function
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            }
            else if (strPageOpeMode == "edit")
            {
                //Used to Display Related Panel throught showpanel Javascript function
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
                #region Location and Contact Panel
                //fill Sonic Location Number
                ComboHelper.FillSonicLocationNumberOnlyForView(new DropDownList[] { ddlLocationNumber }, 0, true);
                //Fill Location dba Dropdown
                ComboHelper.FillLocationdbaOnlyForView(new DropDownList[] { ddlLocationdba }, 0, true);
                //Fill Location Legal Entity Dropdown
                //ComboHelper.FillLocationLegal_EntityForView(new DropDownList[] { ddlLegalEntity }, 0, true);
                //Fill Location FKA Dropdown
                ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);
                //Fill State Dropdown
                ComboHelper.FillState(new DropDownList[] { ddlLoss_State }, 0, true);
                //Fetch Related Record for Location and EMployee
                BindLocationandContactInfo();
                #endregion

                #region Loss Information Panel
                //ComboHelper.FillState(new DropDownList[] { ddlTheft_Present_State, ddlPresent_State, ddlMVA_MultiPresent_State, ddlVandalism_Present_State, ddlPartialTheft_Present_State, ddlFire_Present_State, ddlFlood_Present_State, ddlWind_Present_State, ddlFraud_Present_State, ddlHail_Present_State, ddlTheft_Storage_State, ddlFraud_Storage_State, ddltpi_State, ddlPass_State, ddlMVA_MultiPass_State, ddlMVA_Multitpi_State }, 0, true);
                ComboHelper.FillState(new DropDownList[] { ddl_Present_State, ddl_Storage_State, ddlMVA_MultiPass_State, ddlMVA_Multitpi_State }, 0, true);
                #endregion

                #region Attchement
                CtrlAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.DPD_FR, PK_DPD_FR_ID, true, 4);
                #endregion

                //Fetch Data and Display Page in Edit Mode
                BindPageinEditMode();
                //lstCauseOfLoss_SelectedIndexChanged(null, null);
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
                    int retVal = ComplateDDP_FRReport(false);
                    if (retVal == 1)
                    {
                        Response.Redirect("FirstReportStatus.aspx");
                    }
                    else if (retVal == -1)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('First Report is Already Submited.');ShowPanel(4);", true);
                    }
                    else
                    {
                        //used to display related Panel throught Javascript
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('The First Report e-mail send without the attachments.');ShowPanel(4);", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('The First Report has NOT been sent, please reduce the number and/or size of the attachments before attempting to resubmit with attachments.');ShowPanel(4);", true);
                }
            }
            else if (eventTarget == "UserConfirmationPostBackView")
            {
                if (eventArgument == "true")
                {
                    if (ResendMail(false))
                        ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('The First Report e-mail send without the attachments.');ShowPanel(" + hdnCureentPanel.Value + ");", true);
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

    #region Control Event

    #region Save and Continue Button Events

    /// <summary>
    /// BUtton Click Event - To save Location Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLocationSave_Click(object sender, EventArgs e)
    {
        //this is hidden field that are used to check that the panel is saved or not. because this panel
        //contain Require fields and we must have to save this panel. if it is not done than the value of hidden
        //Control is blank and given a prompt when user click on submit button at comment & attachment Panel
        hdnLocation.Value = "1";
        //Update Location and Contact Information
        UpdateLocationContactInformation();
        //Bind Sonic Header
        setSonicHeaderInfo();
        //used to display related Panel throught Javascript
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:ShowPanel(2);", true);
    }

    /// <summary>
    /// Button Click Event - To Save Loss Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLossSave_Click(object sender, EventArgs e)
    {
        //this is hidden field that are used to check that the panel is saved or not. because this panel
        //contain Require fields and we must have to save this panel. if it is not done than the value of hidden
        //Control is blank and given a prompt when user click on submit button at comment & attachment Panel
        hdnLoss.Value = "1";
        //Update Loss Information 
        UpdateLossInformation();
        //used to display related Panel throught Javascript
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:ShowPanel(3);", true);
    }

    /// <summary>
    /// BUtton CLick Event - To Save Witness Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnWitnessSave_Click(object sender, EventArgs e)
    {
        //Update Witness Information 
        UpdateWitnessInformation();
        //used to display related Panel throught Javascript
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:ShowPanel(3);", true);
    }

    /// <summary>
    /// BUtton Click Event - To Save Witness Continue Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnWitnessContinue_Click(object sender, EventArgs e)
    {
        //used to display related Panel throught Javascript
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:ShowPanel(4);", true);
    }

    /// <summary>
    /// BUtton CLick event To Submitt Page Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Complate DPD_First Report and Send Email.
        int retVal = ComplateDDP_FRReport(true);
        if (retVal == 1)
        {
            Response.Redirect("FirstReportStatus.aspx");
        }
        else if (retVal == -1)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('First Report is Already Submited.');ShowPanel(4);", true);
        }
        else
        {
            //used to display related Panel throught Javascript
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
        }

    }

    #endregion

    #region Location and Contact Information Panel Events
    public void BindLocationandContactInfo()
    {
        if (First_Report_Wizard_ID > 0)
        {
            DataSet dsFRWInfo = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.DPD_FR, PK_DPD_FR_ID);

            DataTable dtFRWInfo = dsFRWInfo.Tables[0];
            if (dtFRWInfo.Rows.Count > 0)
            {
                DataRow drFRWInfo = dtFRWInfo.Rows[0];
                #region Fill Location Information Controls
                //if value is not null than select value in dropdown
                if (drFRWInfo["Sonic_Location_Code"] != null)
                {
                    ListItem lstRLN = new ListItem();
                    lstRLN = ddlLocationNumber.Items.FindByText(drFRWInfo["Sonic_Location_Code"].ToString());
                    //check List Item if not null than select = true
                    if (lstRLN != null)
                    {
                        lstRLN.Selected = true;
                    }
                }
                //select value from Location d/b/a Dropdown
                if (drFRWInfo["dba"] != null)
                {
                    ListItem lstdba = new ListItem();
                    lstdba = ddlLocationdba.Items.FindByText(drFRWInfo["dba"].ToString());
                    //check listitem if not null than list item selected = true
                    if (lstdba != null)
                    {
                        lstdba.Selected = true;
                    }
                }
                //select value from Location f/k/a Dropdown
                if (drFRWInfo["FK_Location_ID"] != null)
                {
                    //Fill Location FKA Dropdown
                    ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, (drFRWInfo["FK_Location_ID"] != null) ? Convert.ToInt32(drFRWInfo["FK_Location_ID"]) : 0, true);
                }
                //select value from Location Legal Entity Dropdown
                //if (drFRWInfo["legal_entity"] != null)
                //{
                //    ListItem lstLE = new ListItem();
                //    lstLE = ddlLegalEntity.Items.FindByText(drFRWInfo["legal_entity"].ToString().Trim());
                //    //check list item if not null than list item selected = true
                //    if (lstLE != null)
                //    {
                //        lstLE.Selected = true;
                //    }
                //}

                //set address1,address2,city,state,ZipCOde Values
                txtLocationAddress1.Text = (drFRWInfo["Address_1"] != null) ? Convert.ToString(drFRWInfo["Address_1"]) : "";
                txtLocationAddress2.Text = (drFRWInfo["Address_2"] != null) ? Convert.ToString(drFRWInfo["Address_2"]) : "";
                txtLocationCity.Text = (drFRWInfo["City"] != null) ? Convert.ToString(drFRWInfo["City"]) : "";
                txtLocationState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRWInfo["State"])) ? Convert.ToDecimal(drFRWInfo["State"]) : 0).FLD_state;
                txtLocationZipCode.Text = (drFRWInfo["Zip_Code"] != null) ? Convert.ToString(drFRWInfo["Zip_Code"]) : "";

                #endregion

                #region Fill Contact Information Controls
                txtdba.Text = (drFRWInfo["dba"] != null) ? Convert.ToString(drFRWInfo["dba"]) : "";
                txtContactName.Text = (drFRWInfo["EmployeeName"] != null) ? Convert.ToString(drFRWInfo["EmployeeName"]) : "";
                txtContact_Best_Time.Text = (drFRWInfo["Contact_Best_Time"] != null) ? Convert.ToString(drFRWInfo["Contact_Best_Time"]) : "";
                txtAddress_1.Text = (drFRWInfo["Address_1"] != null) ? Convert.ToString(drFRWInfo["Address_1"]) : "";
                txtAddress_2.Text = (drFRWInfo["Address_2"] != null) ? Convert.ToString(drFRWInfo["Address_2"]) : "";
                txtWork_Phone.Text = (drFRWInfo["TelephoneNumber1"] != null) ? Convert.ToString(drFRWInfo["TelephoneNumber1"]) : "";
                txtEmployee_Cell_Phone.Text = (drFRWInfo["TelephoneNumber2"] != null) ? Convert.ToString(drFRWInfo["TelephoneNumber2"]) : "";
                txtCity.Text = (drFRWInfo["City"] != null) ? Convert.ToString(drFRWInfo["City"]) : "";
                txtZip_Code.Text = (drFRWInfo["Zip_Code"] != null) ? Convert.ToString(drFRWInfo["Zip_Code"]) : "";
                txtState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRWInfo["State"])) ? Convert.ToDecimal(drFRWInfo["State"]) : 0).FLD_state;
                txtEmployee_Fax.Text = (drFRWInfo["Contact_Fax"] != null) ? Convert.ToString(drFRWInfo["Contact_Fax"]) : "";
                txtEmail.Text = (drFRWInfo["FRWEmail"] != null) ? Convert.ToString(drFRWInfo["FRWEmail"]) : "";
                #endregion
            }

            //used to Disable all Controls
            DisableEnableControls(false);
        }
        else
        {
            Response.Redirect("FirstReportSearch.aspx", true);
        }
    }
    /// <summary>
    /// Used to Disable the Controls
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
        txtdba.Enabled = value;
        txtContactName.Enabled = value;
        txtAddress_1.Enabled = value;
        txtAddress_2.Enabled = value;
        txtWork_Phone.Enabled = value;
        txtEmployee_Cell_Phone.Enabled = value;
        txtZip_Code.Enabled = value;
        txtCity.Enabled = value;
        txtState.Enabled = value;
        txtEmail.Enabled = value;
    }

    /// <summary>
    /// Used to Update Location and Contact Information
    /// </summary>
    public void UpdateLocationContactInformation()
    {
        //Update Fax Number to First_Report_Wizard Table
        First_Report_Wizard objFRW = new First_Report_Wizard(First_Report_Wizard_ID);

        objFRW.Contact_Fax = txtEmployee_Fax.Text;
        objFRW.Contact_Best_Time = txtContact_Best_Time.Text;
        //used to update First Report wizard table
        if (First_Report_Wizard_ID > 0)
        {
            objFRW.Update();
        }

        //Update Loss Location information in DPD Table
        DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);

        objDPD_FR.Loss_Address_1 = txtLoss_Address_1.Text;
        objDPD_FR.Loss_Address_2 = txtLoss_Address_2.Text;
        objDPD_FR.On_Company_Property = (rdoOn_Company_Property.SelectedValue == "Y") ? true : false;
        objDPD_FR.Date_Of_Loss = clsGeneral.FormatDateToStore(txtDate_Of_Loss);
        //Set Date of Loss in Loss Section
        txtLossDate_Of_Loss.Text = clsGeneral.FormatDateToDisplay(objDPD_FR.Date_Of_Loss);
        objDPD_FR.Time_of_Loss = txtTime_of_Loss.Text;
        objDPD_FR.Loss_City = txtLoss_City.Text;
        objDPD_FR.Loss_State = (ddlLoss_State.SelectedIndex > 0) ? ddlLoss_State.SelectedValue.ToString() : "";
        objDPD_FR.Loss_ZipCode = txtLoss_ZipCode.Text;
        objDPD_FR.Date_Reported_To_Sonic = clsGeneral.FormatDateToStore(txtDate_Reported_To_Sonic);
        //used to check the PK id. if greater than 0. update DPD_FR table
        if (PK_DPD_FR_ID > 0)
        {
            objDPD_FR.Update();
        }
    }
    #endregion

    #region All the Events for Loss Information Page
    #region Witness Panel Events
    /// <summary>
    /// Update WIthess Information
    /// </summary>
    public void UpdateWitnessInformation()
    {
        //Create Object
        DPD_Witness objDPD_Witness = new DPD_Witness(PK_DPD_Witness_ID);
        objDPD_Witness.FK_DPD_FR_ID = PK_DPD_FR_ID;
        objDPD_Witness.Name = txtWitness_Name.Text;
        objDPD_Witness.Address = txtWitness_Address.Text;
        objDPD_Witness.Phone = txtWitness_Phone.Text;
        if (PK_DPD_Witness_ID > 0)
        {
            objDPD_Witness.Update();
            PK_DPD_Witness_ID = 0;
            btnWitnessSave.Text = "Add";
        }
        else
        {
            PK_DPD_Witness_ID = objDPD_Witness.Insert();
            PK_DPD_Witness_ID = 0;
        }
        btnViewAuditWitness.Visible = false;
        //Claer Controls
        ClearWitness_Controls();
        //bind Grid
        BindWitness();
    }
    #endregion
    #region Bind Witness Grid
    /// <summary>
    /// Bind Witness Grid
    /// </summary>
    public void BindWitness()
    {
        DataTable dtWitness = DPD_Witness.SelectByFK(PK_DPD_FR_ID).Tables[0];
        gvWitnesses.DataSource = dtWitness;
        gvWitnesses.DataBind();
    }
    #endregion
    #region Loss Information Panel Events

    /// <summary>
    /// Used Update Loss Information
    /// </summary>
    public void UpdateLossInformation()
    {
        //Create Object
        DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);

        objDPD_FR.Date_Of_Loss = clsGeneral.FormatDateToStore(txtLossDate_Of_Loss);
        txtDate_Of_Loss.Text = clsGeneral.FormatDateToDisplay(objDPD_FR.Date_Of_Loss);
        #region Update Theft Section
        objDPD_FR.Theft = (lstCauseOfLoss.Items[7].Selected);
        //check if not Checked than delete previous records
        if (objDPD_FR.Theft == false)
        {
            DPD_FR_Vehicle.DeleteByIncidentType(PK_DPD_FR_ID, "4");
            //Bind Grid
        }
        #endregion

        #region Update Partial Theft Section
        objDPD_FR.Partial_Theft = (lstCauseOfLoss.Items[6].Selected);
        //check if not Checked than delete previous records
        if (objDPD_FR.Partial_Theft == false)
        {
            DPD_FR_Vehicle.DeleteByIncidentType(PK_DPD_FR_ID, "5");
            //Bind Grid

        }
        #endregion

        #region Udpate Vandalism
        objDPD_FR.Vandalism = (lstCauseOfLoss.Items[8].Selected);
        //check if not Checked than delete previous records
        if (objDPD_FR.Vandalism == false)
        {
            DPD_FR_Vehicle.DeleteByIncidentType(PK_DPD_FR_ID, "6");
            //Bind Grid

        }
        #endregion

        #region Insert/Update Value into DPD Vehicle Table for MVA-Damage for Single Vehicle
        objDPD_FR.MVA_Single = (lstCauseOfLoss.Items[5].Selected);
        //check if not Checked than delete previous records
        if (objDPD_FR.MVA_Single == false)
        {
            DPD_FR_Vehicle.DeleteByIncidentType(PK_DPD_FR_ID, "1");
            //Bind Grid

        }
        #endregion

        #region Insert/Update Value into DPD Vehicle Table for MVA-Damage for Multiple Vehicle
        objDPD_FR.MVA_Multiple = (lstCauseOfLoss.Items[4].Selected);
        //check if not Checked than delete previous records
        if (objDPD_FR.MVA_Multiple == false)
        {
            DPD_FR_Vehicle.DeleteByIncidentType(PK_DPD_FR_ID, "2");
            //Bind Grid

        }
        #endregion

        #region Update Hail
        objDPD_FR.Hail = (lstCauseOfLoss.Items[3].Selected);
        //check if not Checked than delete previous records
        if (objDPD_FR.Hail == false)
        {
            DPD_FR_Vehicle.DeleteByIncidentType(PK_DPD_FR_ID, "7");
            //Bind Grid

        }
        #endregion

        #region Update Flood
        objDPD_FR.Flood = (lstCauseOfLoss.Items[1].Selected);
        //check if not Checked than delete previous records
        if (objDPD_FR.Flood == false)
        {
            DPD_FR_Vehicle.DeleteByIncidentType(PK_DPD_FR_ID, "8");

        }
        #endregion

        #region Update Fire
        objDPD_FR.Fire = (lstCauseOfLoss.Items[0].Selected);
        //check if not Checked than delete previous records
        if (objDPD_FR.Fire == false)
        {
            DPD_FR_Vehicle.DeleteByIncidentType(PK_DPD_FR_ID, "9");
            //Bind Grid

        }
        #endregion

        #region Update Wind
        objDPD_FR.Wind = (lstCauseOfLoss.Items[9].Selected);
        //check if not Checked than delete previous records
        if (objDPD_FR.Wind == false)
        {
            DPD_FR_Vehicle.DeleteByIncidentType(PK_DPD_FR_ID, "10");
            //Bind Grid

        }
        #endregion

        #region Insert/Update values into DPD Vehicle Table for Fraud
        objDPD_FR.Fraud = (lstCauseOfLoss.Items[2].Selected);
        //check if not Checked than delete previous records
        if (objDPD_FR.Fraud == false)
        {
            DPD_FR_Vehicle.DeleteByIncidentType(PK_DPD_FR_ID, "3");
            //Bind Grid

        }
        #endregion

        //if DPD pk id is greater than 0 than update DPD_FR table
        if (PK_DPD_FR_ID > 0)
        {
            objDPD_FR.Update();
        }
    }
    #endregion
    /// <summary>
    /// Fraud Add
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    //protected void btnAddFraud_Click(object sender, EventArgs e)
    //{
    //    DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);
    //    DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Fraud_ID);
    //    objDFV.Incident_Type = "3";
    //    objDFV.VIN = txtFraud_VIN.Text;
    //    objDFV.Make = txtFraud_Make.Text;
    //    objDFV.Model = txtFraud_Model.Text;
    //    objDFV.Year = string.IsNullOrEmpty(txtFraud_Year.Text) ? 0 : Convert.ToDecimal(txtFraud_Year.Text);
    //    objDFV.TypeOfVehicle = (ddlFraud_TypeOfVehicle.SelectedIndex > 0) ? ddlFraud_TypeOfVehicle.SelectedValue : "";
    //    objDFV.Present_Location = txtFraud_Present_Location.Text;
    //    objDFV.Present_Address = txtFraud_Present_Address.Text;
    //    objDFV.Present_State = (ddlFraud_Present_State.SelectedIndex > 0) ? ddlFraud_Present_State.SelectedValue.ToString() : "0";
    //    objDFV.Present_Zip = txtFraud_Present_Zip.Text;
    //    objDFV.Invoice_Value = string.IsNullOrEmpty(txtFraud_Invoice_Value.Text) ? 0 : Convert.ToDecimal(txtFraud_Invoice_Value.Text);
    //    objDFV.Loss_Description = txtFraud_Loss_Description.Text;

    //    if (rdoFraud_Vehicle_Recovered.SelectedValue == "1")
    //    {
    //        objDFV.Vehicle_Recovered = true;
    //    }
    //    else if (rdoFraud_Vehicle_Recovered.SelectedValue == "0")
    //    {
    //        objDFV.Vehicle_Recovered = false;
    //    }
    //    else
    //        objDFV.Vehicle_Recovered = null;

    //    if (objDFV.Vehicle_Recovered == true)
    //    {
    //        objDFV.Damage_Estimate = string.IsNullOrEmpty(txtFraud_Damage_estimate.Text) ? 0 : Convert.ToDecimal(txtFraud_Damage_estimate.Text);
    //        if (rdoFraud_Dealership_Wish_To_Take_Possession.SelectedValue == "1")
    //        {
    //            objDFV.Dealership_Wish_To_Take_Possession = true;
    //        }
    //        else if (rdoFraud_Dealership_Wish_To_Take_Possession.SelectedValue == "0")
    //        {
    //            objDFV.Dealership_Wish_To_Take_Possession = false;
    //        }
    //        else
    //            objDFV.Dealership_Wish_To_Take_Possession = null;
    //    }
    //    else
    //    {
    //        objDFV.Damage_Estimate = null;
    //        objDFV.Dealership_Wish_To_Take_Possession = null;
    //    }
    //    if (rdoFraudVehicle_In_Storage.SelectedValue == "1")
    //    {
    //        objDFV.Vehicle_In_Storage = true;
    //    }
    //    else if (rdoFraudVehicle_In_Storage.SelectedValue == "0")
    //    {
    //        objDFV.Vehicle_In_Storage = false;
    //    }
    //    else
    //        objDFV.Vehicle_In_Storage = null;

    //    if (objDFV.Vehicle_In_Storage == true)
    //    {
    //        objDFV.storage_Address_1 = txtFraud_Storage_Address_1.Text;
    //        objDFV.storage_Address_2 = txtFraud_Storage_Address_2.Text;
    //        objDFV.Storage_Contact = txtFraud_Storage_Contact.Text;
    //        objDFV.Storage_phone = txtFraud_Storage_phone.Text;
    //        objDFV.storage_City = txtFraud_Storage_City.Text;
    //        objDFV.storage_cost = string.IsNullOrEmpty(txtFraud_Storage_cost.Text) ? 0 : Convert.ToDecimal(txtFraud_Storage_cost.Text);
    //        objDFV.storage_State = (ddlFraud_Storage_State.SelectedIndex > 0) ? ddlFraud_Storage_State.SelectedValue.ToString() : "0";
    //        objDFV.storage_Zip_Code = txtFraud_storage_Zip_Code.Text;
    //    }

    //    if (rdoFraudPoliceNotified.SelectedValue == "1")
    //    {
    //        objDFV.Police_Notified = true;
    //    }
    //    else if (rdoFraudPoliceNotified.SelectedValue == "0")
    //    {
    //        objDFV.Police_Notified = false;
    //    }
    //    else
    //        objDFV.Police_Notified = null;

    //    if (objDFV.Police_Notified == true)
    //    {
    //        objDFV.Police_Report_Number = txtFraudReportNumber.Text;
    //    }
    //    objDFV.FK_DPD_FR_ID = PK_DPD_FR_ID;
    //    //assign null to bit data type field that are not in used
    //    #region Assign Null
    //    objDFV.Driven_By_Associate = null;
    //    objDFV.Associate_Cited = null;
    //    objDFV.Vehicle_Driven_By_Customer = null;
    //    objDFV.Cutomer_Injured = null;
    //    objDFV.Associate_injured = null;
    //    objDFV.drug_test_performed = null;
    //    objDFV.Additional_passengers = null;
    //    objDFV.seeking_subrogation = null;
    //    objDFV.Notice_only_claim = null;
    //    #endregion
    //    //Check PK id. if greater than Zero update value to DPD_FR_Vehicle table. else insert new value in same table
    //    if (PK_DPD_FR_Fraud_ID > 0)
    //    {
    //        objDFV.Update();
    //        PK_DPD_FR_Fraud_ID = 0;
    //        btnAddFraud.Text = "Add";
    //    }
    //    else
    //    {
    //        objDPD_FR.Fraud = true;
    //        objDPD_FR.Update();
    //        PK_DPD_FR_Fraud_ID = objDFV.Insert();
    //        PK_DPD_FR_Fraud_ID = 0;
    //    }
    //    btnViewAuditFraud.Visible = false;
    //    //Clear Controls
    //    ClearFraud_Controls();
    //    //Bind Grid
    //    BindFraudGrid();
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedFraud = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}
    /// <summary>
    /// Partial Thief Add
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnAddPartialTheft_Click(object sender, EventArgs e)
    //{
    //    DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);
    //    DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Partial_Theft_ID);
    //    objDFV.Incident_Type = "5";
    //    objDFV.VIN = txtPartialTheft_VIN.Text;
    //    objDFV.Make = txtPartialTheft_Make.Text;
    //    objDFV.Model = txtPartialTheft_Model.Text;
    //    objDFV.Year = string.IsNullOrEmpty(txtPartialTheft_Year.Text) ? 0 : Convert.ToDecimal(txtPartialTheft_Year.Text);
    //    objDFV.TypeOfVehicle = (ddlPartialTheft_TypeOfVehicle.SelectedIndex > 0) ? ddlPartialTheft_TypeOfVehicle.SelectedValue : "";
    //    objDFV.Present_Location = txtPartialTheft_Present_Location.Text;
    //    objDFV.Present_Address = txtPartialTheft_Present_Address.Text;
    //    objDFV.Present_State = (ddlPartialTheft_Present_State.SelectedIndex > 0) ? ddlPartialTheft_Present_State.SelectedValue.ToString() : "0";
    //    objDFV.Present_Zip = txtPartialTheft_Present_Zip.Text;
    //    objDFV.Invoice_Value = string.IsNullOrEmpty(txtPartialTheft_Invoice_Value.Text) ? 0 : Convert.ToDecimal(txtPartialTheft_Invoice_Value.Text);
    //    objDFV.Loss_Description = txtPartialTheft_Loss_Description.Text;

    //    objDFV.FK_DPD_FR_ID = PK_DPD_FR_ID;
    //    //Check PK id. if greater than Zero update value to DPD_FR_Vehicle table. else insert new value in same table
    //    //set default null value to unused variables
    //    BindNullToBitDatatype(objDFV);
    //    if (PK_DPD_FR_Partial_Theft_ID > 0)
    //    {
    //        objDFV.Update();
    //        PK_DPD_FR_Partial_Theft_ID = 0;
    //        btnAddPartialTheft.Text = "Add";
    //    }
    //    else
    //    {
    //        objDPD_FR.Partial_Theft = true;
    //        objDPD_FR.Update();
    //        PK_DPD_FR_Partial_Theft_ID = objDFV.Insert();
    //        PK_DPD_FR_Partial_Theft_ID = 0;
    //    }
    //    btnViewAuditPartialTheft.Visible = false;
    //    //Clear Controls
    //    ClearPartialTheft_Controls();
    //    //Bind Grid
    //    BindPartialTheftGrid();
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedPartialTheft = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}
    /// <summary>
    /// Vandalism add
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnAddVandalism_Click(object sender, EventArgs e)
    //{
    //    DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);
    //    DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Vandalism_ID);
    //    objDFV.Incident_Type = "6";
    //    objDFV.VIN = txtVandalism_VIN.Text;
    //    objDFV.Make = txtVandalism_Make.Text;
    //    objDFV.Model = txtVandalism_Model.Text;
    //    objDFV.Year = string.IsNullOrEmpty(txtVandalism_Year.Text) ? 0 : Convert.ToDecimal(txtVandalism_Year.Text);
    //    objDFV.TypeOfVehicle = (ddlVandalism_TypeOfVehicle.SelectedIndex > 0) ? ddlVandalism_TypeOfVehicle.SelectedValue : "";
    //    objDFV.Present_Location = txtVandalism_Present_Location.Text;
    //    objDFV.Present_Address = txtVandalism_Present_Address.Text;
    //    objDFV.Present_State = (ddlVandalism_Present_State.SelectedIndex > 0) ? ddlVandalism_Present_State.SelectedValue.ToString() : "0";
    //    objDFV.Present_Zip = txtVandalism_Present_Zip.Text;
    //    objDFV.Invoice_Value = string.IsNullOrEmpty(txtVandalism_Invoice_Value.Text) ? 0 : Convert.ToDecimal(txtVandalism_Invoice_Value.Text);
    //    objDFV.Loss_Description = txtVandalism_Loss_Description.Text;

    //    objDFV.FK_DPD_FR_ID = PK_DPD_FR_ID;
    //    //set default null value to unused variables
    //    BindNullToBitDatatype(objDFV);
    //    //Check PK id. if greater than Zero update value to DPD_FR_Vehicle table. else insert new value in same table
    //    if (PK_DPD_FR_Vandalism_ID > 0)
    //    {
    //        objDFV.Update();
    //        PK_DPD_FR_Vandalism_ID = 0;
    //        btnAddVandalism.Text = "Add";
    //    }
    //    else
    //    {
    //        objDPD_FR.Vandalism = true;
    //        objDPD_FR.Update();
    //        PK_DPD_FR_Vandalism_ID = objDFV.Insert();
    //        PK_DPD_FR_Vandalism_ID = 0;
    //    }
    //    btnViewAuditVandalism.Visible = false;
    //    //Clear Controls
    //    ClearVandalism_Controls();
    //    //Bind Grid
    //    BindVandalismGrid();
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedVandalism = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}
    /// <summary>
    /// Hail Add
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnAddHail_Click(object sender, EventArgs e)
    //{
    //    DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);
    //    DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Hail_ID);
    //    objDFV.Incident_Type = "7";
    //    objDFV.VIN = txtHail_VIN.Text;
    //    objDFV.Make = txtHail_Make.Text;
    //    objDFV.Model = txtHail_Model.Text;
    //    objDFV.Year = string.IsNullOrEmpty(txtHail_Year.Text) ? 0 : Convert.ToDecimal(txtHail_Year.Text);
    //    objDFV.TypeOfVehicle = (ddlHail_TypeOfVehicle.SelectedIndex > 0) ? ddlHail_TypeOfVehicle.SelectedValue : "";
    //    objDFV.Present_Location = txtHail_Present_Location.Text;
    //    objDFV.Present_Address = txtHail_Present_Address.Text;
    //    objDFV.Present_State = (ddlHail_Present_State.SelectedIndex > 0) ? ddlHail_Present_State.SelectedValue.ToString() : "0";
    //    objDFV.Present_Zip = txtHail_Present_Zip.Text;
    //    objDFV.Invoice_Value = string.IsNullOrEmpty(txtHail_Invoice_Value.Text) ? 0 : Convert.ToDecimal(txtHail_Invoice_Value.Text);
    //    objDFV.Loss_Description = txtHail_Loss_Description.Text;

    //    objDFV.FK_DPD_FR_ID = PK_DPD_FR_ID;
    //    //set default null value to unused variables
    //    BindNullToBitDatatype(objDFV);
    //    //Check PK id. if greater than Zero update value to DPD_FR_Vehicle table. else insert new value in same table
    //    if (PK_DPD_FR_Hail_ID > 0)
    //    {
    //        objDFV.Update();
    //        PK_DPD_FR_Hail_ID = 0;
    //        btnAddHail.Text = "Add";
    //    }
    //    else
    //    {
    //        objDPD_FR.Hail = true;
    //        objDPD_FR.Update();
    //        PK_DPD_FR_Hail_ID = objDFV.Insert();
    //        PK_DPD_FR_Hail_ID = 0;
    //    }
    //    btnViewAuditHail.Visible = false;
    //    //Clear Controls
    //    ClearHail_Controls();
    //    //Bind Grid
    //    BindHailGrid();
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedHail = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}

    /// <summary>
    /// Flood Add
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnAddFlood_Click(object sender, EventArgs e)
    //{
    //    DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);
    //    DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Flood_ID);
    //    objDFV.Incident_Type = "8";
    //    objDFV.VIN = txtFlood_VIN.Text;
    //    objDFV.Make = txtFlood_Make.Text;
    //    objDFV.Model = txtFlood_Model.Text;
    //    objDFV.Year = string.IsNullOrEmpty(txtFlood_Year.Text) ? 0 : Convert.ToDecimal(txtFlood_Year.Text);
    //    objDFV.TypeOfVehicle = (ddlFlood_TypeOfVehicle.SelectedIndex > 0) ? ddlFlood_TypeOfVehicle.SelectedValue : "";
    //    objDFV.Present_Location = txtFlood_Present_Location.Text;
    //    objDFV.Present_Address = txtFlood_Present_Address.Text;
    //    objDFV.Present_State = (ddlFlood_Present_State.SelectedIndex > 0) ? ddlFlood_Present_State.SelectedValue.ToString() : "0";
    //    objDFV.Present_Zip = txtFlood_Present_Zip.Text;
    //    objDFV.Invoice_Value = string.IsNullOrEmpty(txtFlood_Invoice_Value.Text) ? 0 : Convert.ToDecimal(txtFlood_Invoice_Value.Text);
    //    objDFV.Loss_Description = txtFlood_Loss_Description.Text;

    //    objDFV.FK_DPD_FR_ID = PK_DPD_FR_ID;
    //    //set default null value to unused variables
    //    BindNullToBitDatatype(objDFV);
    //    //Check PK id. if greater than Zero update value to DPD_FR_Vehicle table. else insert new value in same table
    //    if (PK_DPD_FR_Flood_ID > 0)
    //    {
    //        objDFV.Update();
    //        PK_DPD_FR_Flood_ID = 0;
    //        btnAddFlood.Text = "Add";
    //    }
    //    else
    //    {
    //        objDPD_FR.Flood = true;
    //        objDPD_FR.Update();
    //        PK_DPD_FR_Flood_ID = objDFV.Insert();
    //        PK_DPD_FR_Flood_ID = 0;
    //    }
    //    btnViewAuditFlood.Visible = false;
    //    //Clear Controls
    //    ClearFlood_Controls();
    //    //Bind Grid
    //    BindFloodGrid();
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedFood = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}

    /// <summary>
    /// Fire Add
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnAddFire_Click(object sender, EventArgs e)
    //{
    //    DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);
    //    DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Fire_ID);
    //    objDFV.Incident_Type = "9";
    //    objDFV.VIN = txtFire_VIN.Text;
    //    objDFV.Make = txtFire_Make.Text;
    //    objDFV.Model = txtFire_Model.Text;
    //    objDFV.Year = string.IsNullOrEmpty(txtFire_Year.Text) ? 0 : Convert.ToDecimal(txtFire_Year.Text);
    //    objDFV.TypeOfVehicle = (ddlFire_TypeOfVehicle.SelectedIndex > 0) ? ddlFire_TypeOfVehicle.SelectedValue : "";
    //    objDFV.Present_Location = txtFire_Present_Location.Text;
    //    objDFV.Present_Address = txtFire_Present_Address.Text;
    //    objDFV.Present_State = (ddlFire_Present_State.SelectedIndex > 0) ? ddlFire_Present_State.SelectedValue.ToString() : "0";
    //    objDFV.Present_Zip = txtFire_Present_Zip.Text;
    //    objDFV.Invoice_Value = string.IsNullOrEmpty(txtFire_Invoice_Value.Text) ? 0 : Convert.ToDecimal(txtFire_Invoice_Value.Text);
    //    objDFV.Loss_Description = txtFire_Loss_Description.Text;

    //    objDFV.FK_DPD_FR_ID = PK_DPD_FR_ID;
    //    //set default null value to unused variables
    //    BindNullToBitDatatype(objDFV);
    //    //Check PK id. if greater than Zero update value to DPD_FR_Vehicle table. else insert new value in same table
    //    if (PK_DPD_FR_Fire_ID > 0)
    //    {
    //        objDFV.Update();
    //        PK_DPD_FR_Fire_ID = 0;
    //        btnAddFire.Text = "Add";
    //    }
    //    else
    //    {
    //        objDPD_FR.Fire = true;
    //        objDPD_FR.Update();
    //        PK_DPD_FR_Fire_ID = objDFV.Insert();
    //        PK_DPD_FR_Fire_ID = 0;
    //    }
    //    btnViewAuditFire.Visible = false;
    //    //Clear Controls
    //    ClearFire_Controls();
    //    //Bind Grid
    //    BindFireGrid();
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedFire = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}

    //protected void btnAdd_Click(object sender, EventArgs e)
    //{
    //    StringBuilder sb = new StringBuilder();
    //    sb.Append("<DPD_FR_Vehicle>");

    //    sb.Append("<Incident_Type>" + lstItm.Value + "</Incident_Type>");

    //    sb.Append("<VIN>" + txtVIN.Text + "</VIN>");
    //    sb.Append("<Make>" + txtMake.Text + "</Make>");
    //    sb.Append("<Model>" + txtModel.Text + "</Model>");
    //    if (!string.IsNullOrEmpty(txtYear.Text))
    //    {
    //        sb.Append("<Year>" + Convert.ToDecimal(txtYear.Text) + "</Year>");
    //    }

    //    if (ddlTypeOfVehicle.SelectedIndex > 0)
    //    {
    //        sb.Append("<TypeOfVehicle>" + ddlTypeOfVehicle.SelectedValue + "</TypeOfVehicle>");
    //    }
    //    else
    //    {
    //        sb.Append("<TypeOfVehicle>" + "" + "</TypeOfVehicle>");
    //    }

    //    sb.Append("<Present_Location>" + txtFire_Present_Location.Text + "</Present_Location>");
    //    sb.Append("<Present_Address>" + txtFire_Present_Address.Text + "</Present_Address>");

    //    if (ddlPresent_State.SelectedIndex > 0)
    //    {
    //        sb.Append("<Present_State>" + ddlPresent_State.SelectedValue.ToString() + "</Present_State>");
    //    }
    //    else
    //    {
    //        sb.Append("<Present_State>" + "0" + "</Present_State>");
    //    }

    //    sb.Append("<Present_Zip>" + txtPresent_Zip.Text + "</Present_Zip>");

    //    if(string.IsNullOrEmpty(txtFire_Invoice_Value.Text))
    //    {
    //        sb.Append("<Invoice_Value>" + "0"  + "</Invoice_Value>");
    //    }
    //    else
    //    {
    //        sb.Append("<Invoice_Value>" + Convert.ToDecimal(txtFire_Invoice_Value.Text).ToString() + "</Invoice_Value>");
    //    }

    //    sb.Append("<Loss_Description>" + txtLoss_Description.Text + "</Invoice_Value>");
    //    sb.Append("</DPD_FR_Vehicle>");
    //}

    /// <summary>
    /// Wind Add
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnAddWind_Click(object sender, EventArgs e)
    //{
    //    DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);
    //    DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Wind_ID);
    //    objDFV.Incident_Type = "10";
    //    objDFV.VIN = txtWind_VIN.Text;
    //    objDFV.Make = txtWind_Make.Text;
    //    objDFV.Model = txtWind_Model.Text;
    //    objDFV.Year = string.IsNullOrEmpty(txtWind_Year.Text) ? 0 : Convert.ToDecimal(txtWind_Year.Text);
    //    objDFV.TypeOfVehicle = (ddlWind_TypeOfVehicle.SelectedIndex > 0) ? ddlWind_TypeOfVehicle.SelectedValue : "";
    //    objDFV.Present_Location = txtWind_Present_Location.Text;
    //    objDFV.Present_Address = txtWind_Present_Address.Text;
    //    objDFV.Present_State = (ddlWind_Present_State.SelectedIndex > 0) ? ddlWind_Present_State.SelectedValue.ToString() : "0";
    //    objDFV.Present_Zip = txtWind_Present_Zip.Text;
    //    objDFV.Invoice_Value = string.IsNullOrEmpty(txtWind_Invoice_Value.Text) ? 0 : Convert.ToDecimal(txtWind_Invoice_Value.Text);
    //    objDFV.Loss_Description = txtWind_Loss_Description.Text;

    //    objDFV.FK_DPD_FR_ID = PK_DPD_FR_ID;
    //    //set default null value to unused variables
    //    BindNullToBitDatatype(objDFV);
    //    //Check PK id. if greater than Zero update value to DPD_FR_Vehicle table. else insert new value in same table
    //    if (PK_DPD_FR_Wind_ID > 0)
    //    {
    //        objDFV.Update();
    //        PK_DPD_FR_Wind_ID = 0;
    //        btnAddWind.Text = "Add";
    //    }
    //    else
    //    {
    //        objDPD_FR.Wind = true;
    //        objDPD_FR.Update();
    //        PK_DPD_FR_Wind_ID = objDFV.Insert();
    //        PK_DPD_FR_Wind_ID = 0;
    //    }
    //    btnViewAuditWind.Visible = false;
    //    //Clear Controls
    //    ClearWind_Controls();
    //    //Bind Grid
    //    BindWindGrid();
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedWind = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}

    /// <summary>
    /// Add Theft
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnAddTheft_Click(object sender, EventArgs e)
    //{
    //    DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);
    //    DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Theft_ID);
    //    objDFV.Incident_Type = "4";
    //    objDFV.VIN = txtTheft_VIN.Text;
    //    objDFV.Make = txtTheft_Make.Text;
    //    objDFV.Model = txtTheft_Model.Text;
    //    objDFV.Year = string.IsNullOrEmpty(txtTheft_Year.Text) ? 0 : Convert.ToDecimal(txtTheft_Year.Text);
    //    objDFV.TypeOfVehicle = (ddlTheft_TypeOfVehicle.SelectedIndex > 0) ? ddlTheft_TypeOfVehicle.SelectedValue : "";
    //    objDFV.Present_Location = txtTheft_Present_Location.Text;
    //    objDFV.Present_Address = txtTheft_Present_Address.Text;
    //    objDFV.Present_State = (ddlTheft_Present_State.SelectedIndex > 0) ? ddlTheft_Present_State.SelectedValue.ToString() : "0";
    //    objDFV.Present_Zip = txtTheft_Present_Zip.Text;
    //    objDFV.Invoice_Value = string.IsNullOrEmpty(txtTheft_Invoice_Value.Text) ? 0 : Convert.ToDecimal(txtTheft_Invoice_Value.Text);
    //    objDFV.Loss_Description = txtTheft_Loss_Description.Text;
    //    if (rdoTheft_Vehicle_Recovered.SelectedValue == "1")
    //    {
    //        objDFV.Vehicle_Recovered = true;
    //    }
    //    else if (rdoTheft_Vehicle_Recovered.SelectedValue == "0")
    //    {
    //        objDFV.Vehicle_Recovered = false;
    //    }
    //    else
    //        objDFV.Vehicle_Recovered = null;

    //    if (objDFV.Vehicle_Recovered == true)
    //    {
    //        objDFV.Damage_Estimate = string.IsNullOrEmpty(txtTheft_Damage_estimate.Text) ? 0 : Convert.ToDecimal(txtTheft_Damage_estimate.Text);
    //        if (rdoTheft_Dealership_Wish_To_Take_Possession.SelectedValue == "1")
    //        {
    //            objDFV.Dealership_Wish_To_Take_Possession = true;
    //        }
    //        else if (rdoTheft_Dealership_Wish_To_Take_Possession.SelectedValue == "0")
    //        {
    //            objDFV.Dealership_Wish_To_Take_Possession = false;
    //        }
    //        else
    //            objDFV.Dealership_Wish_To_Take_Possession = null;

    //    }
    //    else
    //    {
    //        objDFV.Damage_Estimate = null;
    //        objDFV.Dealership_Wish_To_Take_Possession = null;
    //    }

    //    if (rdoVehicle_In_Storage.SelectedValue == "1")
    //    {
    //        objDFV.Vehicle_In_Storage = true;
    //    }
    //    else if (rdoVehicle_In_Storage.SelectedValue == "0")
    //    {
    //        objDFV.Vehicle_In_Storage = false;
    //    }
    //    else
    //        objDFV.Vehicle_In_Storage = null;

    //    if (objDFV.Vehicle_In_Storage == true)
    //    {
    //        objDFV.storage_Address_1 = txtTheft_Storage_Address_1.Text;
    //        objDFV.storage_Address_2 = txtTheft_Storage_Address_2.Text;
    //        objDFV.Storage_Contact = txtTheft_Storage_Contact.Text;
    //        objDFV.Storage_phone = txtTheft_Storage_phone.Text;
    //        objDFV.storage_City = txtTheft_Storage_City.Text;
    //        objDFV.storage_cost = string.IsNullOrEmpty(txtTheft_Storage_cost.Text) ? 0 : Convert.ToDecimal(txtTheft_Storage_cost.Text);
    //        objDFV.storage_State = (ddlTheft_Storage_State.SelectedIndex > 0) ? ddlTheft_Storage_State.SelectedValue.ToString() : "0";
    //        objDFV.storage_Zip_Code = txtTheft_storage_Zip_Code.Text;
    //    }
    //    objDFV.FK_DPD_FR_ID = PK_DPD_FR_ID;
    //    //assign null to bit data type field that are not in used
    //    #region Assign Null
    //    objDFV.Driven_By_Associate = null;
    //    objDFV.Associate_Cited = null;
    //    objDFV.Vehicle_Driven_By_Customer = null;
    //    objDFV.Cutomer_Injured = null;
    //    objDFV.Police_Notified = null;
    //    objDFV.Associate_injured = null;
    //    objDFV.drug_test_performed = null;
    //    objDFV.Additional_passengers = null;
    //    objDFV.seeking_subrogation = null;
    //    objDFV.Notice_only_claim = null;
    //    #endregion
    //    //Check PK id. if greater than Zero update value to DPD_FR_Vehicle table. else insert new value in same table
    //    if (PK_DPD_FR_Theft_ID > 0)
    //    {
    //        objDFV.Update();
    //        PK_DPD_FR_Theft_ID = 0;
    //        btnAddTheft.Text = "Add";
    //    }
    //    else
    //    {
    //        objDPD_FR.Theft = true;
    //        objDPD_FR.Update();
    //        PK_DPD_FR_Theft_ID = objDFV.Insert();
    //        PK_DPD_FR_Theft_ID = 0;
    //    }
    //    btnViewAuditTheft.Visible = false;
    //    //Clear Controls
    //    ClearTheft_Controls();
    //    //Bind Grid
    //    BindTheftGrid();

    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedTheft = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}

    /// <summary>
    /// Add MVA Single Vehicle
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnAddDamageSingleVehicle_Click(object sender, EventArgs e)
    //{
    //    DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);
    //    DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Single_Vehicle_ID);
    //    objDFV.Incident_Type = "1";
    //    objDFV.Make = txtMake.Text;
    //    objDFV.Model = txtModel.Text;
    //    objDFV.Year = string.IsNullOrEmpty(txtYear.Text) ? 0 : Convert.ToDecimal(txtYear.Text);
    //    objDFV.VIN = txtVIN.Text;
    //    objDFV.TypeOfVehicle = (ddlTypeOfVehicle.SelectedIndex > 0) ? ddlTypeOfVehicle.SelectedValue : "";
    //    objDFV.Present_Location = txtPresent_Location.Text;
    //    objDFV.Present_Address = txtPresent_Address.Text;
    //    objDFV.Present_State = (ddlPresent_State.SelectedIndex > 0) ? ddlPresent_State.SelectedValue.ToString() : "0";
    //    objDFV.Present_Zip = txtPresent_Zip.Text;
    //    objDFV.Invoice_Value = string.IsNullOrEmpty(txtInvoice_Value.Text) ? 0 : Convert.ToDecimal(txtInvoice_Value.Text);
    //    objDFV.Loss_Description = txtMVASingleLoss_description.Text;
    //    objDFV.Damage_Estimate = string.IsNullOrEmpty(txtDamage_Estimate.Text) ? 0 : Convert.ToDecimal(txtDamage_Estimate.Text);
    //    if (rdoDriven_By_Associate.SelectedValue == "1")
    //        objDFV.Driven_By_Associate = true;
    //    else if (rdoDriven_By_Associate.SelectedValue == "0")
    //        objDFV.Driven_By_Associate = false;
    //    else
    //        objDFV.Driven_By_Associate = null;

    //    if (objDFV.Driven_By_Associate == true)
    //    {
    //        objDFV.Name = txtMVA_SingleName_Yes.Text;
    //        objDFV.Address = txtMVA_SingleAddress_Yes.Text;
    //        objDFV.Phone = txtMVA_SinglePhone_Yes.Text;
    //        if (rdoAssociate_Cited.SelectedValue == "1")
    //            objDFV.Associate_Cited = true;
    //        else if (rdoAssociate_Cited.SelectedValue == "0")
    //            objDFV.Associate_Cited = false;
    //        else
    //            objDFV.Associate_Cited = null;

    //        if (objDFV.Associate_Cited == true)
    //        {
    //            objDFV.Description_Of_Citation = txtDescription_Of_Citation.Text;
    //        }
    //        if (rdoAssociate_injured.SelectedValue == "1")
    //            objDFV.Associate_injured = true;
    //        else if (rdoAssociate_injured.SelectedValue == "0")
    //            objDFV.Associate_injured = false;
    //        else
    //            objDFV.Associate_injured = null;

    //        if (rdoDrug_test_performed.SelectedValue == "1")
    //            objDFV.drug_test_performed = true;
    //        else if (rdoDrug_test_performed.SelectedValue == "0")
    //            objDFV.drug_test_performed = false;
    //        else
    //            objDFV.drug_test_performed = null;

    //        if (objDFV.drug_test_performed == true)
    //        {
    //            objDFV.drug_test_results = txtDrug_test_results.Text;
    //        }
    //        else if (objDFV.drug_test_performed == false)
    //        {
    //            objDFV.drug_test_explanation = txtDrug_test_explanation.Text;
    //        }
    //    }
    //    else if (objDFV.Driven_By_Associate == false)
    //    {
    //        if (rdoVehicle_Driven_By_Customer.SelectedValue == "1")
    //            objDFV.Vehicle_Driven_By_Customer = true;
    //        else if (rdoVehicle_Driven_By_Customer.SelectedValue == "0")
    //            objDFV.Vehicle_Driven_By_Customer = false;
    //        else
    //            objDFV.Vehicle_Driven_By_Customer = null;

    //        if (objDFV.Vehicle_Driven_By_Customer == true)
    //        {
    //            objDFV.Name = txtMVA_SingleName_No.Text;
    //            objDFV.Address = txtMVA_SingleAddress_No.Text;
    //            objDFV.Phone = txtMVA_SinglePhone_No.Text;
    //            if (rdocustomer_injured.SelectedValue == "1")
    //                objDFV.Cutomer_Injured = true;
    //            else if (rdocustomer_injured.SelectedValue == "0")
    //                objDFV.Cutomer_Injured = false;
    //            else
    //                objDFV.Cutomer_Injured = null;

    //        }
    //        else
    //        {
    //            objDFV.Not_Driven_By_Customer_Explain = txtMVA_SingleNot_Driven_By_Customer_Explain.Text;
    //            objDFV.Name = "";
    //            objDFV.Address = "";
    //            objDFV.Phone = "";
    //        }
    //    }

    //    if (rdoAdditional_passengers.SelectedValue == "1")
    //        objDFV.Additional_passengers = true;
    //    else if (rdoAdditional_passengers.SelectedValue == "0")
    //        objDFV.Additional_passengers = false;
    //    else
    //        objDFV.Additional_passengers = null;

    //    if (objDFV.Additional_passengers == false)
    //    {
    //        DPD_FR_Injured_Passenger.DeleteByVehicleID(PK_DPD_FR_Single_Vehicle_ID);
    //        //Bind Grid
    //        BindPassengerGrid(gvMVASingle_Passenger, PK_DPD_FR_Single_Vehicle_ID);
    //    }
    //    if (rdoSeeking_subrogation.SelectedValue == "1")
    //        objDFV.seeking_subrogation = true;
    //    else if (rdoSeeking_subrogation.SelectedValue == "0")
    //        objDFV.seeking_subrogation = false;
    //    else
    //        objDFV.seeking_subrogation = null;

    //    if (objDFV.seeking_subrogation == true)
    //    {
    //        objDFV.TPI_Carrier_name = txtTPI_Carrier_name.Text;
    //        objDFV.tpi_contact = txttpi_contact.Text;
    //        objDFV.TPI_Policy_number = txtTPI_Policy_number.Text;
    //        objDFV.tpi_phone = txttpi_phone.Text;
    //        objDFV.tpi_Address_1 = txttpi_address_1.Text;
    //        objDFV.tpi_Address_2 = txttpi_address_2.Text;
    //        objDFV.tpi_City = txttpi_City.Text;
    //        objDFV.tpi_State = (ddltpi_State.SelectedIndex > 0) ? ddltpi_State.SelectedValue.ToString() : "0";
    //        objDFV.tpi_Zip_Code = txttpi_Zip_Code.Text;
    //        objDFV.recovered_amount = string.IsNullOrEmpty(txtRecovered_Amount.Text) ? 0 : Convert.ToDecimal(txtRecovered_Amount.Text);
    //    }
    //    else
    //    {
    //        if (rdoNotice_only_claim.SelectedValue == "1")
    //            objDFV.Notice_only_claim = true;
    //        else if (rdoNotice_only_claim.SelectedValue == "0")
    //            objDFV.Notice_only_claim = false;
    //        else
    //            objDFV.Notice_only_claim = null;

    //        objDFV.recovered_amount = string.IsNullOrEmpty(txtRecovered_Amount.Text.Trim()) ? 0 : Convert.ToDecimal(txtRecovered_Amount.Text);
    //    }
    //    objDFV.FK_DPD_FR_ID = PK_DPD_FR_ID;
    //    if (PK_DPD_FR_Single_Vehicle_ID > 0)
    //    {
    //        objDFV.Update();
    //        PK_DPD_FR_Single_Vehicle_ID = 0;
    //        btnAddDamageSingleVehicle.Text = "Add";
    //    }
    //    else
    //    {
    //        //Insert new value to table.
    //        objDPD_FR.MVA_Single = true;
    //        objDPD_FR.Update();
    //        PK_DPD_FR_Single_Vehicle_ID = objDFV.Insert();
    //        PK_DPD_FR_Single_Vehicle_ID = 0;
    //    }
    //    btnViewAuditSingle.Visible = false;
    //    //Clear Controls
    //    ClearMVASingle_Controls();
    //    //Bind Grid
    //    BindMVASingleGrid();
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedMVA_single = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}

    /// <summary>
    /// MVA Multi Vehicle Add
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnAddDamageMultiVehicle_Click(object sender, EventArgs e)
    //{
    //    DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);
    //    DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Multi_Vehicle_ID);
    //    objDFV.Incident_Type = "2";
    //    objDFV.Make = txtMVA_MultiMake.Text;
    //    objDFV.Model = txtMVA_MultiModel.Text;
    //    objDFV.Year = string.IsNullOrEmpty(txtMVA_MultiYear.Text) ? 0 : Convert.ToDecimal(txtMVA_MultiYear.Text);
    //    objDFV.VIN = txtMVA_MultiVIN.Text;
    //    objDFV.Vehicle_Owner_Sonic = txtMVA_MultiVehicle_Owner_Sonic.Text;
    //    objDFV.Vehicle_Owner_Address = txtMVA_MultiVehicle_Owner_Address.Text;
    //    objDFV.Vehicle_Owner_Phone = txtMVA_MultiVehicle_Owner_Phone.Text;
    //    objDFV.TypeOfVehicle = (ddlMVA_MultiTypeOfVehicle.SelectedIndex > 0) ? ddlMVA_MultiTypeOfVehicle.SelectedValue : "";
    //    objDFV.Present_Location = txtMVA_MultiPresent_Location.Text;
    //    objDFV.Present_Address = txtMVA_MultiPresent_Address.Text;
    //    objDFV.Present_State = (ddlMVA_MultiPresent_State.SelectedIndex > 0) ? ddlMVA_MultiPresent_State.SelectedValue.ToString() : "0";
    //    objDFV.Present_Zip = txtMVA_MultiPresent_Zip.Text;
    //    objDFV.Invoice_Value = string.IsNullOrEmpty(txtMVA_MultiInvoice_Value.Text) ? 0 : Convert.ToDecimal(txtMVA_MultiInvoice_Value.Text);
    //    objDFV.Loss_Description = txtMVAMultiLoss_description.Text;
    //    objDFV.Damage_Estimate = string.IsNullOrEmpty(txtMVA_MultiDamage_Estimate.Text) ? 0 : Convert.ToDecimal(txtMVA_MultiDamage_Estimate.Text);
    //    if (rdoMVA_MultiDriven_By_Associate.SelectedValue == "1")
    //        objDFV.Driven_By_Associate = true;
    //    else if (rdoMVA_MultiDriven_By_Associate.SelectedValue == "0")
    //        objDFV.Driven_By_Associate = false;
    //    else
    //        objDFV.Driven_By_Associate = null;

    //    if (objDFV.Driven_By_Associate == true)
    //    {
    //        objDFV.Name = txtMVA_MultiName_Yes.Text;
    //        objDFV.Address = txtMVA_MultiAddress_Yes.Text;
    //        objDFV.Phone = txtMVA_MultiPhone_Yes.Text;
    //        if (rdoMVA_MultiAssociate_Cited.SelectedValue == "1")
    //            objDFV.Associate_Cited = true;
    //        else if (rdoMVA_MultiAssociate_Cited.SelectedValue == "0")
    //            objDFV.Associate_Cited = false;
    //        else
    //            objDFV.Associate_Cited = null;

    //        if (objDFV.Associate_Cited == true)
    //        {
    //            objDFV.Description_Of_Citation = txtMVA_MultiDescription_Of_Citation.Text;
    //        }
    //        if (rdoMVA_MultiAssociate_injured.SelectedValue == "1")
    //            objDFV.Associate_injured = true;
    //        else if (rdoMVA_MultiAssociate_injured.SelectedValue == "0")
    //            objDFV.Associate_injured = false;
    //        else
    //            objDFV.Associate_injured = null;

    //        if (rdoMVA_MultiDrug_test_performed.SelectedValue == "1")
    //            objDFV.drug_test_performed = true;
    //        else if (rdoMVA_MultiDrug_test_performed.SelectedValue == "0")
    //            objDFV.drug_test_performed = false;
    //        else
    //            objDFV.drug_test_performed = null;

    //        if (objDFV.drug_test_performed == true)
    //        {
    //            objDFV.drug_test_results = txtMVA_MultiDrug_test_results.Text;
    //        }
    //        else if (objDFV.drug_test_performed == false)
    //        {
    //            objDFV.drug_test_explanation = txtMVA_MultiDrug_test_explanation.Text;
    //        }
    //    }
    //    else if (objDFV.Driven_By_Associate == false)
    //    {
    //        if (rdoMVA_MultiVehicle_Driven_By_Customer.SelectedValue == "1")
    //            objDFV.Vehicle_Driven_By_Customer = true;
    //        else if (rdoMVA_MultiVehicle_Driven_By_Customer.SelectedValue == "0")
    //            objDFV.Vehicle_Driven_By_Customer = false;
    //        else
    //            objDFV.Vehicle_Driven_By_Customer = null;

    //        if (objDFV.Vehicle_Driven_By_Customer == true)
    //        {
    //            objDFV.Name = txtMVA_MultiName_No.Text;
    //            objDFV.Address = txtMVA_MultiAddress_No.Text;
    //            objDFV.Phone = txtMVA_MultiPhone_No.Text;
    //            if (rdoMVA_Multicustomer_injured.SelectedValue == "1")
    //                objDFV.Cutomer_Injured = true;
    //            else if (rdoMVA_Multicustomer_injured.SelectedValue == "0")
    //                objDFV.Cutomer_Injured = false;
    //            else
    //                objDFV.Cutomer_Injured = null;
    //        }
    //        else
    //        {
    //            objDFV.Not_Driven_By_Customer_Explain = txtMVA_MultiNot_Driven_By_Customer_Explain.Text;
    //            objDFV.Name = "";
    //            objDFV.Address = "";
    //            objDFV.Phone = "";
    //        }
    //    }

    //    if (rdoMVA_MultiAdditional_passengers.SelectedValue == "1")
    //        objDFV.Additional_passengers = true;
    //    else if (rdoMVA_MultiAdditional_passengers.SelectedValue == "0")
    //        objDFV.Additional_passengers = false;
    //    else
    //        objDFV.Additional_passengers = null;

    //    if (objDFV.Additional_passengers == false)
    //    {
    //        DPD_FR_Injured_Passenger.DeleteByVehicleID(PK_DPD_FR_Multi_Vehicle_ID);
    //        //Bind Grid
    //        BindPassengerGrid(gvMVAMulti_Passenger, PK_DPD_FR_Multi_Vehicle_ID);
    //    }
    //    if (rdoMVA_MultiSeeking_subrogation.SelectedValue == "1")
    //        objDFV.seeking_subrogation = true;
    //    else if (rdoMVA_MultiSeeking_subrogation.SelectedValue == "0")
    //        objDFV.seeking_subrogation = false;
    //    else
    //        objDFV.seeking_subrogation = null;

    //    if (objDFV.seeking_subrogation == true)
    //    {
    //        objDFV.TPI_Carrier_name = txtMVA_MultiTPI_Carrier_name.Text;
    //        objDFV.tpi_contact = txtMVA_Multitpi_contact.Text;
    //        objDFV.TPI_Policy_number = txtMVA_MultiTPI_Policy_number.Text;
    //        objDFV.tpi_phone = txtMVA_Multitpi_phone.Text;
    //        objDFV.tpi_Address_1 = txtMVA_Multitpi_address_1.Text;
    //        objDFV.tpi_Address_2 = txtMVA_Multitpi_address_2.Text;
    //        objDFV.tpi_City = txtMVA_Multitpi_City.Text;
    //        objDFV.tpi_State = (ddlMVA_Multitpi_State.SelectedIndex > 0) ? ddlMVA_Multitpi_State.SelectedValue.ToString() : "0";
    //        objDFV.tpi_Zip_Code = txtMVA_Multitpi_Zip_Code.Text;
    //        objDFV.recovered_amount = string.IsNullOrEmpty(txtMVA_MultiRecovered_Amount.Text) ? 0 : Convert.ToDecimal(txtMVA_MultiRecovered_Amount.Text);
    //    }
    //    else
    //    {
    //        if (rdoMVA_MultiNotice_only_claim.SelectedValue == "1")
    //            objDFV.Notice_only_claim = true;
    //        else if (rdoMVA_MultiNotice_only_claim.SelectedValue == "0")
    //            objDFV.Notice_only_claim = false;
    //        else
    //            objDFV.Notice_only_claim = null;

    //        objDFV.recovered_amount = string.IsNullOrEmpty(txtMVA_MultiRecovered_Amount.Text.Trim()) ? 0 : Convert.ToDecimal(txtMVA_MultiRecovered_Amount.Text);
    //    }
    //    objDFV.FK_DPD_FR_ID = PK_DPD_FR_ID;
    //    if (PK_DPD_FR_Multi_Vehicle_ID > 0)
    //    {
    //        objDFV.Update();
    //        PK_DPD_FR_Multi_Vehicle_ID = 0;
    //        btnAddDamageMultiVehicle.Text = "Add";
    //    }
    //    else
    //    {
    //        //Insert new value to table.
    //        objDPD_FR.MVA_Multiple = true;
    //        objDPD_FR.Update();
    //        PK_DPD_FR_Multi_Vehicle_ID = objDFV.Insert();
    //        PK_DPD_FR_Multi_Vehicle_ID = 0;
    //    }
    //    btnViewAuditMulti.Visible = false;
    //    //Clear Controls
    //    ClearMVAMulti_Controls();
    //    //Bind Grid
    //    BindMVAMultiGrid();
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedMVA_Multi = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}

    /// <summary>
    /// Add Passenger info for MVA single
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnMVASingle_Passenger_Click(object sender, EventArgs e)
    //{
    //    if (PK_DPD_FR_Single_Vehicle_ID > 0)
    //    {
    //        DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Single_Vehicle_ID);
    //        DPD_FR_Injured_Passenger objDFIP = new DPD_FR_Injured_Passenger(PK_DPD_FR_Passenger_ID);
    //        objDFIP.FK_DPD_FR_ID = PK_DPD_FR_ID;
    //        objDFIP.FK_DPD_FR_Vehicle_ID = PK_DPD_FR_Single_Vehicle_ID;
    //        objDFIP.name = txtPass_Name.Text;
    //        objDFIP.Address_1 = txtPass_Address_1.Text;
    //        objDFIP.Address_2 = txtPass_Address_2.Text;
    //        objDFIP.phone = txtPass_Phone.Text;
    //        objDFIP.City = txtPass_City.Text;
    //        if (rdoPass_Injured.SelectedValue == "1")
    //        {
    //            objDFIP.injured = true;
    //        }
    //        else if (rdoPass_Injured.SelectedValue == "0")
    //        {
    //            objDFIP.injured = false;
    //        }
    //        else
    //            objDFIP.injured = null;
    //        objDFIP.State = (ddlPass_State.SelectedIndex > 0) ? ddlPass_State.SelectedValue.ToString() : "0";
    //        objDFIP.Zip_Code = txtPass_Zip.Text;
    //        if (PK_DPD_FR_Passenger_ID > 0)
    //        {
    //            objDFIP.Update();
    //            PK_DPD_FR_Passenger_ID = 0;
    //            btnMVASingle_Passenger.Text = "Add";
    //        }
    //        else
    //        {
    //            objDFV.Additional_passengers = true;
    //            objDFV.Update();
    //            PK_DPD_FR_Passenger_ID = objDFIP.Insert();
    //            PK_DPD_FR_Passenger_ID = 0;
    //        }
    //        //Claer Controls
    //        ClearMVASinglePassenger_Controls();
    //        //Bind Grid
    //        BindPassengerGrid(gvMVASingle_Passenger, PK_DPD_FR_Single_Vehicle_ID);
    //    }
    //    else
    //    {
    //        ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "javascript:alert('Please save MVA – Damage (Single Vehicle) first.');", true);
    //        //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save MVA – Damage (Single Vehicle) first.');", true);
    //        //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save MVA – Damage (Single Vehicle) first.');", true);
    //    }
    //}

    /// <summary>
    /// Add Passenger info for MVA Multi
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnMVAMulti_Passenger_Click(object sender, EventArgs e)
    {
        if (PK_DPD_FR_Vehicle_ID > 0)
        {
            DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Multi_Vehicle_ID);
            DPD_FR_Injured_Passenger objDFIP = new DPD_FR_Injured_Passenger(PK_DPD_FR_Passenger_ID);
            objDFIP.FK_DPD_FR_ID = PK_DPD_FR_ID;
            objDFIP.FK_DPD_FR_Vehicle_ID = PK_DPD_FR_Multi_Vehicle_ID;
            objDFIP.name = txtMVA_MultiPass_Name.Text;
            objDFIP.Address_1 = txtMVA_MultiPass_Address_1.Text;
            objDFIP.Address_2 = txtMVA_MultiPass_Address_2.Text;
            objDFIP.phone = txtMVA_MultiPass_Phone.Text;
            objDFIP.City = txtMVA_MultiPass_City.Text;
            if (rdoMVA_MultiPass_Injured.SelectedValue == "1")
            {
                objDFIP.injured = true;
            }
            else if (rdoMVA_MultiPass_Injured.SelectedValue == "0")
            {
                objDFIP.injured = false;
            }
            else
                objDFIP.injured = null;
            objDFIP.State = (ddlMVA_MultiPass_State.SelectedIndex > 0) ? ddlMVA_MultiPass_State.SelectedValue.ToString() : "0";
            objDFIP.Zip_Code = txtMVA_MultiPass_Zip.Text;
            if (PK_DPD_FR_Passenger_ID > 0)
            {
                objDFIP.Update();
                PK_DPD_FR_Passenger_ID = 0;
                btnMVA_Multi_Passenger.Text = "Add";
            }
            else
            {
                objDFV.Additional_passengers = true;
                objDFV.Update();
                PK_DPD_FR_Passenger_ID = objDFIP.Insert();
                PK_DPD_FR_Passenger_ID = 0;
            }
            //Claer Controls
            ClearMVAMultiPassenger_Controls();
            //Bind Grid
            BindPassengerGrid(gvMVAMulti_Passenger, PK_DPD_FR_Multi_Vehicle_ID);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "", "javascript:alert('Please save MVA – Damage (Multi Vehicle) record first.');", true);
        }
    }

    //protected void btnResetTheft_Click(object sender, EventArgs e)
    //{
    //    ClearTheft_Controls();
    //}

    //protected void btnResetPartialTheft_Click(object sender, EventArgs e)
    //{
    //    ClearPartialTheft_Controls();
    //}

    //protected void btnResetVandalism_Click(object sender, EventArgs e)
    //{
    //    ClearVandalism_Controls();
    //}

    //protected void btnResetMVASingle_Click(object sender, EventArgs e)
    //{
    //    ClearMVASingle_Controls();
    //}

    //protected void btnResetMVAMultiple_Click(object sender, EventArgs e)
    //{
    //    ClearMVAMulti_Controls();
    //}
    //protected void btnResetHail_Click(object sender, EventArgs e)
    //{
    //    ClearHail_Controls();
    //}

    //protected void btnResetFlood_Click(object sender, EventArgs e)
    //{
    //    ClearFlood_Controls();
    //}
    //protected void btnResetFire_Click(object sender, EventArgs e)
    //{
    //    ClearFire_Controls();
    //}

    //protected void btnResetWind_Click(object sender, EventArgs e)
    //{
    //    ClearWind_Controls();
    //}

    //protected void btnResetFraud_Click(object sender, EventArgs e)
    //{
    //    ClearFraud_Controls();
    //}

    #region Not in use
    //#region Bind MVA-Damage(MultiPle) Grid
    ///// <summary>
    ///// Used to Bind MVA-Damage Grid
    ///// </summary>
    //public void BindMVAMultiGrid()
    //{
    //    DataTable dtMVA_Damage = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "2");
    //    gvMultiVehDamage.DataSource = dtMVA_Damage;
    //    gvMultiVehDamage.DataBind();
    //}
    //#endregion

    //#region Bind Fraud Grid
    ///// <summary>
    ///// Used to Bind Fraud Grid
    ///// </summary>
    //public void BindFraudGrid()
    //{
    //    DataTable dtFraud = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "3");
    //    gvFraud.DataSource = dtFraud;
    //    gvFraud.DataBind();
    //}
    //#endregion

    //#region Bind Theft Grid
    ///// <summary>
    ///// Used to Bind Theft Grid
    ///// </summary>
    //public void BindTheftGrid()
    //{
    //    DataTable dtTheft = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "4");
    //    gvTheft.DataSource = dtTheft;
    //    gvTheft.DataBind();
    //}
    //#endregion



    //#region Bind Vandalism Grid
    ///// <summary>
    ///// Used to Bind Theft Grid
    ///// </summary>
    //public void BindVandalismGrid()
    //{
    //    DataTable dtVandalism = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "6");
    //    gvVandalism.DataSource = dtVandalism;
    //    gvVandalism.DataBind();
    //}
    //#endregion

    //#region Bind Hail Grid
    ///// <summary>
    ///// Used to Bind Theft Grid
    ///// </summary>
    //public void BindHailGrid()
    //{
    //    DataTable dtHail = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "7");
    //    gvHail.DataSource = dtHail;
    //    gvHail.DataBind();
    //}
    //#endregion

    //#region Bind Flood Grid
    ///// <summary>
    ///// Used to Bind Theft Grid
    ///// </summary>
    //public void BindFloodGrid()
    //{
    //    DataTable dtFlood = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "8");
    //    gvFlood.DataSource = dtFlood;
    //    gvFlood.DataBind();
    //}
    //#endregion

    #region Bind Passenger Grid
    /// <summary>
    /// Used to Bind Theft Grid
    /// </summary>
    public void BindPassengerGrid(GridView gvPassenger, decimal VehicleID)
    {
        DataTable dtPassenger = DPD_FR_Injured_Passenger.SelectByVehicleID(VehicleID).Tables[0];
        gvPassenger.DataSource = dtPassenger;
        gvPassenger.DataBind();
    }
    #endregion

    //#region Bind Fire Grid
    ///// <summary>
    ///// Used to Bind Theft Grid
    ///// </summary>
    //public void BindFireGrid()
    //{
    //    DataTable dtFire = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "9");
    //    gvFire.DataSource = dtFire;
    //    gvFire.DataBind();
    //}

    //#region Bind Wind Grid
    ///// <summary>
    ///// Used to Bind Theft Grid
    ///// </summary>
    //public void BindWindGrid()
    //{
    //    DataTable dtWind = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "10");
    //    gvWind.DataSource = dtWind;
    //    gvWind.DataBind();
    //}
    //#endregion
    //#endregion

    //#region Bind MVA Single Grid
    ///// <summary>
    ///// Used to Bind Theft Grid
    ///// </summary>
    //public void BindMVASingleGrid()
    //{
    //    DataTable dtMVASIngle = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "1");
    //    gvMVASingle.DataSource = dtMVASIngle;
    //    gvMVASingle.DataBind();
    //}

    //#endregion

    //#region MVA Multi Grid Events
    //protected void gvMultiVehDamage_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //}
    //protected void gvMultiVehDamage_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    //check Row Type
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkRemove");
    //        //check null value
    //        if (lnkbtn != null)
    //            lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);

    //        LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
    //        //check Null value
    //        if (lnkbtnEdit != null)
    //            lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
    //    }
    //}
    //protected void gvMultiVehDamage_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //}
    //protected void gvMultiVehDamage_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //check Command Name if it is "Remove" than remove the selected row
    //    if (e.CommandName == "Remove")
    //    {
    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        int PK_ID = (gvMultiVehDamage.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvMultiVehDamage.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than delete record
    //        if (PK_ID > 0)
    //        {
    //            DPD_FR_Vehicle.DeleteByPK(PK_ID);
    //        }
    //        ClearMVAMulti_Controls();
    //        PK_DPD_FR_Multi_Vehicle_ID = 0;
    //        //Bind Grid
    //        BindMVAMultiGrid();
    //    }
    //    else if (e.CommandName == "Edit")
    //    {
    //        //Claer the controls first.
    //        ClearMVAMulti_Controls();
    //        btnAddDamageMultiVehicle.Text = "Update";
    //        btnViewAuditMulti.Visible = true;

    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        PK_DPD_FR_Multi_Vehicle_ID = (gvMultiVehDamage.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvMultiVehDamage.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than display below fields else hide.
    //        if (PK_DPD_FR_Multi_Vehicle_ID > 0)
    //        {
    //            btnViewAuditMulti.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_DPD_FR_Multi_Vehicle_ID + ");");
    //            DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Multi_Vehicle_ID);
    //            revMVA_MultiYear.Enabled = true;
    //            tdMVA_Single_Damage.Style.Add("display", "");
    //            txtMVA_MultiMake.Text = string.IsNullOrEmpty(objDFV.Make) ? "" : objDFV.Make.ToString();
    //            txtMVA_MultiModel.Text = string.IsNullOrEmpty(objDFV.Model) ? "" : objDFV.Model.ToString();
    //            txtMVA_MultiYear.Text = (objDFV.Year.ToString() == "0") ? "" : objDFV.Year.ToString();
    //            txtMVA_MultiVIN.Text = string.IsNullOrEmpty(objDFV.VIN) ? "" : objDFV.VIN.ToString();
    //            txtMVA_MultiVehicle_Owner_Sonic.Text = string.IsNullOrEmpty(objDFV.Vehicle_Owner_Sonic) ? "" : objDFV.Vehicle_Owner_Sonic.ToString();
    //            txtMVA_MultiVehicle_Owner_Address.Text = string.IsNullOrEmpty(objDFV.Vehicle_Owner_Address) ? "" : objDFV.Vehicle_Owner_Address.ToString();
    //            txtMVA_MultiVehicle_Owner_Phone.Text = string.IsNullOrEmpty(objDFV.Vehicle_Owner_Phone) ? "" : objDFV.Vehicle_Owner_Phone.ToString();
    //            ListItem lstTypeOfVehicle = ddlMVA_MultiTypeOfVehicle.Items.FindByText(string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString());
    //            ddlMVA_MultiTypeOfVehicle.ClearSelection();
    //            if (lstTypeOfVehicle != null)
    //                lstTypeOfVehicle.Selected = true;

    //            txtMVA_MultiPresent_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
    //            txtMVA_MultiPresent_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
    //            ListItem lstPresent_State = ddlMVA_MultiPresent_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.Present_State) ? "0" : objDFV.Present_State.ToString());
    //            ddlMVA_MultiPresent_State.ClearSelection();
    //            if (lstPresent_State != null)
    //                lstPresent_State.Selected = true;
    //            txtMVA_MultiPresent_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
    //            txtMVA_MultiInvoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);
    //            txtMVAMultiLoss_description.Text = objDFV.Loss_Description;
    //            txtMVA_MultiDamage_Estimate.Text = clsGeneral.GetStringValue(objDFV.Damage_Estimate);
    //            if (objDFV.Driven_By_Associate != null)
    //            {
    //                if (objDFV.Driven_By_Associate == true)
    //                {
    //                    trMVAMulti_DrivenByCA_Yes.Style.Add("display", "");
    //                    txtMVA_MultiAddress_Yes.Text = string.IsNullOrEmpty(objDFV.Address) ? "" : objDFV.Address;
    //                    txtMVA_MultiName_Yes.Text = string.IsNullOrEmpty(objDFV.Name) ? "" : objDFV.Name;
    //                    txtMVA_MultiPhone_Yes.Text = string.IsNullOrEmpty(objDFV.Phone) ? "" : objDFV.Phone;
    //                    rfvMVA_MultiAssociate_Cited.Enabled = true;
    //                    rfvMVA_MultiDrug_test_performed.Enabled = true;
    //                    rdoMVA_MultiDriven_By_Associate.SelectedValue = "1";
    //                    if (objDFV.Associate_Cited != null)
    //                    {
    //                        if (objDFV.Associate_Cited == true)
    //                        {
    //                            trMVA_MultiCitation_Yes.Style.Add("display", "");
    //                            rdoMVA_MultiAssociate_Cited.SelectedValue = "1";
    //                            RequiredFieldValidator rfvMVA_MultiDesc_Citation = (RequiredFieldValidator)txtMVA_MultiDescription_Of_Citation.FindControl("rfvNotes");
    //                            rfvMVA_MultiDesc_Citation.Enabled = true;
    //                            txtMVA_MultiDescription_Of_Citation.Text = string.IsNullOrEmpty(objDFV.Description_Of_Citation) ? "" : objDFV.Description_Of_Citation.ToString();
    //                        }
    //                        else
    //                        {
    //                            rdoMVA_MultiAssociate_Cited.SelectedValue = "0";
    //                        }
    //                    }
    //                    if (objDFV.Associate_injured != null)
    //                    {
    //                        if (objDFV.Associate_injured == true)
    //                            rdoMVA_MultiAssociate_injured.SelectedValue = "1";
    //                        else
    //                            rdoMVA_MultiAssociate_injured.SelectedValue = "0";
    //                    }

    //                    if (objDFV.drug_test_performed != null)
    //                    {
    //                        if (objDFV.drug_test_performed == true)
    //                        {
    //                            rdoMVA_MultiDrug_test_performed.SelectedValue = "1";
    //                            trMVA_MultiDrugYes.Style.Add("display", "");
    //                            RequiredFieldValidator rfvMVA_MultiDrugTestResult = (RequiredFieldValidator)txtMVA_MultiDrug_test_results.FindControl("rfvNotes");
    //                            rfvMVA_MultiDrugTestResult.Enabled = true;
    //                            txtMVA_MultiDrug_test_results.Text = string.IsNullOrEmpty(objDFV.drug_test_results) ? "" : objDFV.drug_test_results.ToString();
    //                        }
    //                        else
    //                        {
    //                            rdoMVA_MultiDrug_test_performed.SelectedValue = "0";
    //                            trMVA_MultiDrugNo.Style.Add("display", "");
    //                            RequiredFieldValidator rfvMVA_MultiDrugTestExplain = (RequiredFieldValidator)txtMVA_MultiDrug_test_explanation.FindControl("rfvNotes");
    //                            rfvMVA_MultiDrugTestExplain.Enabled = true;
    //                            txtMVA_MultiDrug_test_explanation.Text = string.IsNullOrEmpty(objDFV.drug_test_explanation) ? "" : objDFV.drug_test_explanation.ToString();
    //                        }
    //                    }


    //                }
    //                else
    //                {
    //                    trMVAMulti_DrivenByCA_No.Style.Add("display", "");
    //                    rdoMVA_MultiDriven_By_Associate.SelectedValue = "0";
    //                    rfvMVA_MultiVehicle_Driven_By_Customer.Enabled = true;
    //                    if (objDFV.Vehicle_Driven_By_Customer != null)
    //                    {
    //                        if (objDFV.Vehicle_Driven_By_Customer == true)
    //                        {
    //                            //rfvMVA_MultiAddress_No.Enabled = true;
    //                            //rfvMVA_MultiName_No.Enabled = true;
    //                            //rfvMVA_MultiPhone_No.Enabled = true;
    //                            txtMVA_MultiAddress_No.Text = string.IsNullOrEmpty(objDFV.Address) ? "" : objDFV.Address;
    //                            txtMVA_MultiName_No.Text = string.IsNullOrEmpty(objDFV.Name) ? "" : objDFV.Name;
    //                            txtMVA_MultiPhone_No.Text = string.IsNullOrEmpty(objDFV.Phone) ? "" : objDFV.Phone;
    //                            rfvMVA_Multicustomer_injured.Enabled = true;
    //                            rdoMVA_MultiVehicle_Driven_By_Customer.SelectedValue = "1";
    //                            trMVA_MultiCust_Injured.Style.Add("display", "");
    //                            trMVA_MultiCust_Not_Injured.Style.Add("display", "none");
    //                            if (objDFV.Cutomer_Injured != null)
    //                            {
    //                                if (objDFV.Cutomer_Injured == true)
    //                                {
    //                                    rdoMVA_Multicustomer_injured.SelectedValue = "1";
    //                                }
    //                                else
    //                                {
    //                                    rdoMVA_Multicustomer_injured.SelectedValue = "0";
    //                                }
    //                            }
    //                        }
    //                        else
    //                        {
    //                            trMVA_MultiCust_Not_Injured.Style.Add("display", "");
    //                            RequiredFieldValidator rfvMVA_MultiNot_Driven_By_Customer_Explain = (RequiredFieldValidator)txtMVA_MultiNot_Driven_By_Customer_Explain.FindControl("rfvNotes");
    //                            rfvMVA_MultiNot_Driven_By_Customer_Explain.Enabled = true;
    //                            txtMVA_MultiNot_Driven_By_Customer_Explain.Text = string.IsNullOrEmpty(objDFV.Not_Driven_By_Customer_Explain) ? "" : objDFV.Not_Driven_By_Customer_Explain;
    //                            rdoMVA_MultiVehicle_Driven_By_Customer.SelectedValue = "0";
    //                            trMVA_MultiCust_Injured.Style.Add("display", "none");
    //                        }
    //                    }
    //                }
    //            }
    //            gvMVAMulti_Passenger.DataSource = null;
    //            gvMVAMulti_Passenger.DataBind();
    //            if (objDFV.Additional_passengers != null)
    //            {
    //                if (objDFV.Additional_passengers == true)
    //                {
    //                    trMVA_MultiAdditional_passengers_Yes.Style.Add("display", "");
    //                    rdoMVA_MultiAdditional_passengers.SelectedValue = "1";
    //                    BindPassengerGrid(gvMVAMulti_Passenger, PK_DPD_FR_Multi_Vehicle_ID);
    //                }
    //                else
    //                {
    //                    trMVA_MultiAdditional_passengers_Yes.Style.Add("display", "none");
    //                    rdoMVA_MultiAdditional_passengers.SelectedValue = "0";
    //                }
    //            }
    //            if (objDFV.seeking_subrogation != null)
    //            {
    //                if (objDFV.seeking_subrogation == true)
    //                {
    //                    trMVA_MultiSeeking_subrogation_Yes.Style.Add("display", "");
    //                    rdoMVA_MultiSeeking_subrogation.SelectedValue = "1";
    //                    txtMVA_MultiTPI_Carrier_name.Text = objDFV.TPI_Carrier_name;
    //                    txtMVA_Multitpi_contact.Text = objDFV.tpi_contact;
    //                    txtMVA_MultiTPI_Policy_number.Text = objDFV.TPI_Policy_number;
    //                    txtMVA_Multitpi_phone.Text = objDFV.tpi_phone;
    //                    txtMVA_Multitpi_address_1.Text = objDFV.tpi_Address_1;
    //                    txtMVA_Multitpi_address_2.Text = objDFV.tpi_Address_2;
    //                    txtMVA_Multitpi_City.Text = objDFV.tpi_City;
    //                    ddlMVA_Multitpi_State.ClearSelection();
    //                    ListItem lstState = ddlMVA_Multitpi_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.tpi_State) ? "0" : objDFV.tpi_State.ToString());
    //                    if (lstState != null)
    //                    {
    //                        lstState.Selected = true;
    //                    }
    //                    txtMVA_Multitpi_Zip_Code.Text = objDFV.tpi_Zip_Code;
    //                    txtMVA_MultiRecovered_Amount.Text = clsGeneral.GetStringValue(objDFV.recovered_amount);
    //                }
    //                else
    //                {
    //                    rfvMVA_MultiNotice_only_claim.Enabled = true;
    //                    trMVA_MultiSeeking_subrogation_No.Style.Add("display", "");
    //                    if (objDFV.Notice_only_claim != null)
    //                    {
    //                        if (objDFV.Notice_only_claim == true)
    //                            rdoMVA_MultiNotice_only_claim.SelectedValue = "1";
    //                        else
    //                            rdoMVA_MultiNotice_only_claim.SelectedValue = "0";
    //                    }
    //                    //rdoMVA_MultiNotice_only_claim
    //                    rdoMVA_MultiSeeking_subrogation.SelectedValue = "0";
    //                    txtMVA_MultiRecovered_Amount.Text = clsGeneral.GetStringValue(objDFV.recovered_amount);
    //                }

    //            }
    //        }
    //    }
    //}
    //#endregion

    //#region MVA Single Grid Events
    //protected void gvMVASingle_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //}
    //protected void gvMVASingle_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    //check Row Type
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkRemove");
    //        //check null value
    //        if (lnkbtn != null)
    //            lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);

    //        LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
    //        //check Null value
    //        if (lnkbtnEdit != null)
    //            lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
    //    }
    //}
    //protected void gvMVASingle_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //}
    //protected void gvMVASingle_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //check Command Name if it is "Remove" than remove the selected row
    //    if (e.CommandName == "Remove")
    //    {
    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        int PK_ID = (gvMVASingle.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvMVASingle.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than delete record
    //        if (PK_ID > 0)
    //        {
    //            DPD_FR_Vehicle.DeleteByPK(PK_ID);
    //        }
    //        ClearMVASingle_Controls();
    //        PK_DPD_FR_Single_Vehicle_ID = 0;
    //        //Bind Grid
    //        BindMVASingleGrid();
    //    }
    //    else if (e.CommandName == "Edit")
    //    {
    //        //clear the controls first
    //        ClearMVASingle_Controls();
    //        btnAddDamageSingleVehicle.Text = "Update";
    //        btnViewAuditSingle.Visible = true;

    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        PK_DPD_FR_Single_Vehicle_ID = (gvMVASingle.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvMVASingle.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than display below fields else hide.
    //        if (PK_DPD_FR_Single_Vehicle_ID > 0)
    //        {
    //            btnViewAuditSingle.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_DPD_FR_Single_Vehicle_ID + ");");
    //            DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Single_Vehicle_ID);
    //            revYear.Enabled = true;
    //            tdMVA_Single_Damage.Style.Add("display", "");
    //            txtMake.Text = string.IsNullOrEmpty(objDFV.Make) ? "" : objDFV.Make.ToString();
    //            txtModel.Text = string.IsNullOrEmpty(objDFV.Model) ? "" : objDFV.Model.ToString();
    //            txtYear.Text = (objDFV.Year.ToString() == "0") ? "" : objDFV.Year.ToString();
    //            txtVIN.Text = string.IsNullOrEmpty(objDFV.VIN) ? "" : objDFV.VIN.ToString();
    //            txtInvoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);
    //            ListItem lstTypeOfVehicle = ddlTypeOfVehicle.Items.FindByText(string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString());
    //            ddlTypeOfVehicle.ClearSelection();
    //            if (lstTypeOfVehicle != null)
    //                lstTypeOfVehicle.Selected = true;

    //            txtPresent_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
    //            txtPresent_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
    //            ListItem lstPresent_State = ddlPresent_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.Present_State) ? "0" : objDFV.Present_State.ToString());
    //            ddlPresent_State.ClearSelection();
    //            if (lstPresent_State != null)
    //                lstPresent_State.Selected = true;
    //            txtPresent_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
    //            txtDamage_Estimate.Text = clsGeneral.GetStringValue(objDFV.Damage_Estimate);
    //            txtMVASingleLoss_description.Text = objDFV.Loss_Description;
    //            if (objDFV.Driven_By_Associate != null)
    //            {
    //                if (objDFV.Driven_By_Associate == true)
    //                {
    //                    trMVASingle_DrivenByCA_Yes.Style.Add("display", "");
    //                    txtMVA_SingleAddress_Yes.Text = string.IsNullOrEmpty(objDFV.Address) ? "" : objDFV.Address;
    //                    txtMVA_SingleName_Yes.Text = string.IsNullOrEmpty(objDFV.Name) ? "" : objDFV.Name;
    //                    txtMVA_SinglePhone_Yes.Text = string.IsNullOrEmpty(objDFV.Phone) ? "" : objDFV.Phone;
    //                    rfvAssociate_Cited.Enabled = true;
    //                    rfvDrug_test_performed.Enabled = true;
    //                    rdoDriven_By_Associate.SelectedValue = "1";
    //                    if (objDFV.Associate_Cited != null)
    //                    {
    //                        if (objDFV.Associate_Cited == true)
    //                        {
    //                            trCitation_Yes.Style.Add("display", "");
    //                            rdoAssociate_Cited.SelectedValue = "1";
    //                            txtDescription_Of_Citation.Text = string.IsNullOrEmpty(objDFV.Description_Of_Citation) ? "" : objDFV.Description_Of_Citation.ToString();
    //                        }
    //                        else
    //                        {
    //                            rdoAssociate_Cited.SelectedValue = "0";
    //                        }
    //                    }
    //                    if (objDFV.Associate_injured != null)
    //                    {
    //                        if (objDFV.Associate_injured == true)
    //                            rdoAssociate_injured.SelectedValue = "1";
    //                        else
    //                            rdoAssociate_injured.SelectedValue = "0";
    //                    }

    //                    if (objDFV.drug_test_performed != null)
    //                    {
    //                        if (objDFV.drug_test_performed == true)
    //                        {
    //                            rdoDrug_test_performed.SelectedValue = "1";
    //                            trDrugYes.Style.Add("display", "");
    //                            RequiredFieldValidator rfvDrugTestResult = (RequiredFieldValidator)txtDrug_test_results.FindControl("rfvNotes");
    //                            rfvDrugTestResult.Enabled = true;
    //                            txtDrug_test_results.Text = string.IsNullOrEmpty(objDFV.drug_test_results) ? "" : objDFV.drug_test_results.ToString();
    //                        }
    //                        else
    //                        {
    //                            rdoDrug_test_performed.SelectedValue = "0";
    //                            trDrugNo.Style.Add("display", "");
    //                            RequiredFieldValidator rfvDrugTestExplain = (RequiredFieldValidator)txtDrug_test_explanation.FindControl("rfvNotes");
    //                            rfvDrugTestExplain.Enabled = true;
    //                            txtDrug_test_explanation.Text = string.IsNullOrEmpty(objDFV.drug_test_explanation) ? "" : objDFV.drug_test_explanation.ToString();
    //                        }
    //                    }

    //                }
    //                else
    //                {
    //                    trMVASingle_DrivenByCA_No.Style.Add("display", "");
    //                    rdoDriven_By_Associate.SelectedValue = "0";
    //                    rfvVehicle_Driven_By_Customer.Enabled = true;
    //                    if (objDFV.Vehicle_Driven_By_Customer != null)
    //                    {
    //                        if (objDFV.Vehicle_Driven_By_Customer == true)
    //                        {
    //                            //rdoVehicle_Driven_By_Customer.Attributes.Add("onclick", "CheckDrivenByCust(" + rfvMVA_SingleNot_Driven_By_Customer_Explain.ClientID + ")");                                
    //                            txtMVA_SingleAddress_No.Text = string.IsNullOrEmpty(objDFV.Address) ? "" : objDFV.Address;
    //                            txtMVA_SingleName_No.Text = string.IsNullOrEmpty(objDFV.Name) ? "" : objDFV.Name;
    //                            txtMVA_SinglePhone_No.Text = string.IsNullOrEmpty(objDFV.Phone) ? "" : objDFV.Phone;
    //                            rfvcustomer_injured.Enabled = true;
    //                            rdoVehicle_Driven_By_Customer.SelectedValue = "1";
    //                            trCust_Injured.Style.Add("display", "");
    //                            trCust_Not_Injured.Style.Add("display", "none");
    //                            if (objDFV.Cutomer_Injured != null)
    //                            {
    //                                if (objDFV.Cutomer_Injured == true)
    //                                {
    //                                    rdocustomer_injured.SelectedValue = "1";
    //                                }
    //                                else
    //                                {
    //                                    rdocustomer_injured.SelectedValue = "0";
    //                                }
    //                            }
    //                        }
    //                        else
    //                        {
    //                            txtMVA_SingleNot_Driven_By_Customer_Explain.Text = string.IsNullOrEmpty(objDFV.Not_Driven_By_Customer_Explain) ? "" : objDFV.Not_Driven_By_Customer_Explain;
    //                            trCust_Not_Injured.Style.Add("display", "");
    //                            //rdoVehicle_Driven_By_Customer.Attributes.Add("onclick", "CheckDrivenByCust(" + rfvMVA_SingleNot_Driven_By_Customer_Explain.ClientID + ")");
    //                            rdoVehicle_Driven_By_Customer.SelectedValue = "0";
    //                            trCust_Injured.Style.Add("display", "none");
    //                        }
    //                    }
    //                }
    //            }
    //            gvMVASingle_Passenger.DataSource = null;
    //            gvMVASingle_Passenger.DataBind();
    //            if (objDFV.Additional_passengers != null)
    //            {
    //                if (objDFV.Additional_passengers == true)
    //                {
    //                    trAdditional_passengers_Yes.Style.Add("display", "");
    //                    rdoAdditional_passengers.SelectedValue = "1";
    //                    BindPassengerGrid(gvMVASingle_Passenger, PK_DPD_FR_Single_Vehicle_ID);
    //                }
    //                else
    //                {
    //                    trAdditional_passengers_Yes.Style.Add("display", "none");
    //                    rdoAdditional_passengers.SelectedValue = "0";
    //                }
    //            }
    //            if (objDFV.seeking_subrogation != null)
    //            {
    //                if (objDFV.seeking_subrogation == true)
    //                {
    //                    trSeeking_subrogation_Yes.Style.Add("display", "");
    //                    rdoSeeking_subrogation.SelectedValue = "1";
    //                    txtTPI_Carrier_name.Text = objDFV.TPI_Carrier_name;
    //                    txttpi_contact.Text = objDFV.tpi_contact;
    //                    txtTPI_Policy_number.Text = objDFV.TPI_Policy_number;
    //                    txttpi_phone.Text = objDFV.tpi_phone;
    //                    txttpi_address_1.Text = objDFV.tpi_Address_1;
    //                    txttpi_address_2.Text = objDFV.tpi_Address_2;
    //                    txttpi_City.Text = objDFV.tpi_City;
    //                    ddltpi_State.ClearSelection();
    //                    ListItem lstState = ddltpi_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.tpi_State) ? "0" : objDFV.tpi_State.ToString());
    //                    if (lstState != null)
    //                    {
    //                        lstState.Selected = true;
    //                    }
    //                    txttpi_Zip_Code.Text = objDFV.tpi_Zip_Code;
    //                    txtRecovered_Amount.Text = clsGeneral.GetStringValue(objDFV.recovered_amount);
    //                }
    //                else
    //                {
    //                    rfvNotice_only_claim.Enabled = true;
    //                    trSeeking_subrogation_No.Style.Add("display", "");
    //                    if (objDFV.Notice_only_claim != null)
    //                    {
    //                        if (objDFV.Notice_only_claim == true)
    //                            rdoNotice_only_claim.SelectedValue = "1";
    //                        else
    //                            rdoNotice_only_claim.SelectedValue = "0";
    //                    }
    //                    rdoSeeking_subrogation.SelectedValue = "0";
    //                    txtRecovered_Amount.Text = clsGeneral.GetStringValue(objDFV.recovered_amount);
    //                }

    //            }
    //        }
    //    }
    //}
    //#endregion

    //#region Fraud Grid Events
    //protected void gvFraud_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //}
    //protected void gvFraud_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    //check Row Type
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkRemove");
    //        //check null value
    //        if (lnkbtn != null)
    //            lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);

    //        LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
    //        //check Null value
    //        if (lnkbtnEdit != null)
    //            lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
    //    }
    //}
    //protected void gvFraud_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //}
    //protected void gvFraud_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //check Command Name if it is "Remove" than remove the selected row
    //    if (e.CommandName == "Remove")
    //    {
    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        int PK_ID = (gvFraud.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvFraud.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than delete record
    //        if (PK_ID > 0)
    //        {
    //            DPD_FR_Vehicle.DeleteByPK(PK_ID);
    //        }
    //        ClearFraud_Controls();
    //        PK_DPD_FR_Fraud_ID = 0;
    //        //Bind Grid
    //        BindFraudGrid();
    //    }
    //    else if (e.CommandName == "Edit")
    //    {
    //        //clear the control First
    //        ClearFraud_Controls();
    //        btnAddFraud.Text = "Update";
    //        btnViewAuditFraud.Visible = true;

    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        PK_DPD_FR_Fraud_ID = (gvFraud.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvFraud.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than display below fields else hide.
    //        if (PK_DPD_FR_Fraud_ID > 0)
    //        {
    //            btnViewAuditFraud.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_DPD_FR_Fraud_ID + ");");
    //            //DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Fraud_ID);
    //            revFraud_Year.Enabled = true;
    //            tdFraud.Style.Add("display", "");
    //            DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Fraud_ID);
    //            txtFraud_Make.Text = string.IsNullOrEmpty(objDFV.Make) ? "" : objDFV.Make.ToString();
    //            txtFraud_Model.Text = string.IsNullOrEmpty(objDFV.Model) ? "" : objDFV.Model.ToString();
    //            txtFraud_Year.Text = (objDFV.Year.ToString() == "0") ? "" : objDFV.Year.ToString();
    //            txtFraud_VIN.Text = string.IsNullOrEmpty(objDFV.VIN) ? "" : objDFV.VIN.ToString();
    //            ListItem lstTypeOfVehicle = ddlFraud_TypeOfVehicle.Items.FindByText(string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString());
    //            ddlFraud_TypeOfVehicle.ClearSelection();
    //            if (lstTypeOfVehicle != null)
    //                lstTypeOfVehicle.Selected = true;

    //            txtFraud_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
    //            txtFraud_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
    //            ListItem lstPresent_State = ddlFraud_Present_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.Present_State) ? "0" : objDFV.Present_State.ToString());
    //            ddlFraud_Present_State.ClearSelection();
    //            if (lstPresent_State != null)
    //                lstPresent_State.Selected = true;
    //            txtFraud_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
    //            txtFraud_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);
    //            txtFraud_Loss_Description.Text = objDFV.Loss_Description;
    //            if (objDFV.Vehicle_Recovered != null)
    //            {
    //                if (objDFV.Vehicle_Recovered == true)
    //                    rdoFraud_Vehicle_Recovered.SelectedValue = "1";
    //                else
    //                    rdoFraud_Vehicle_Recovered.SelectedValue = "0";
    //            }
    //            if (objDFV.Vehicle_Recovered == true)
    //            {
    //                tdFraud_VehicleRecovred.Style.Add("display", "");
    //                //rfvFraud_Damage_estimate.Enabled = true;
    //                rfvFraud_Dealership_Wish_To_Take_Possession.Enabled = true;
    //                txtFraud_Damage_estimate.Text = clsGeneral.GetStringValue(objDFV.Damage_Estimate);
    //                if (objDFV.Dealership_Wish_To_Take_Possession != null)
    //                {
    //                    if (objDFV.Dealership_Wish_To_Take_Possession == true)
    //                        rdoFraud_Dealership_Wish_To_Take_Possession.SelectedValue = "1";
    //                    else
    //                        rdoFraud_Dealership_Wish_To_Take_Possession.SelectedValue = "0";
    //                }
    //            }
    //            if (objDFV.Vehicle_In_Storage != null)
    //            {
    //                if (objDFV.Vehicle_In_Storage == true)
    //                    rdoFraudVehicle_In_Storage.SelectedValue = "1";
    //                else
    //                    rdoFraudVehicle_In_Storage.SelectedValue = "0";
    //            }
    //            if (objDFV.Vehicle_In_Storage == true)
    //            {
    //                tdFraudVehicle_In_Storage.Style.Add("display", "");
    //                //rfvFraud_Storage_Address_1.Enabled = true;
    //                //rfvFraud_Storage_Contact.Enabled = true;
    //                //rfvFraud_Storage_Address_2.Enabled = true;
    //                //rfvFraud_Storage_phone.Enabled = true;
    //                //rfvFraud_Storage_City.Enabled = true;
    //                //rfvFraud_Storage_cost.Enabled = true;
    //                //rfvFraud_Storage_State.Enabled = true;
    //                //rfvFraud_storage_Zip_Code.Enabled = true;
    //                txtFraud_Storage_Address_1.Text = string.IsNullOrEmpty(objDFV.storage_Address_1) ? "" : objDFV.storage_Address_1.ToString();
    //                txtFraud_Storage_Address_2.Text = string.IsNullOrEmpty(objDFV.storage_Address_2) ? "" : objDFV.storage_Address_2.ToString();
    //                txtFraud_Storage_Contact.Text = string.IsNullOrEmpty(objDFV.Storage_Contact) ? "" : objDFV.Storage_Contact.ToString();
    //                txtFraud_Storage_phone.Text = string.IsNullOrEmpty(objDFV.Storage_phone) ? "" : objDFV.Storage_phone.ToString();
    //                txtFraud_Storage_City.Text = string.IsNullOrEmpty(objDFV.storage_City) ? "" : objDFV.storage_City.ToString();
    //                txtFraud_Storage_cost.Text = clsGeneral.GetStringValue(objDFV.storage_cost);
    //                txtFraud_storage_Zip_Code.Text = string.IsNullOrEmpty(objDFV.storage_Zip_Code) ? "" : objDFV.storage_Zip_Code.ToString();
    //                ddlFraud_Storage_State.ClearSelection();
    //                ListItem lstState = ddlFraud_Storage_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.storage_State) ? "0" : objDFV.storage_State.ToString());
    //                if (lstState != null)
    //                {
    //                    lstState.Selected = true;
    //                }
    //            }
    //            if (objDFV.Police_Notified != null)
    //            {
    //                if (objDFV.Police_Notified == true)
    //                    rdoFraudPoliceNotified.SelectedValue = "1";
    //                else
    //                    rdoFraudPoliceNotified.SelectedValue = "0";
    //            }
    //            if (objDFV.Police_Notified == true)
    //            {
    //                trPoliceNotified.Style.Add("display", "");
    //                txtFraudReportNumber.Text = string.IsNullOrEmpty(objDFV.Police_Report_Number) ? "" : objDFV.Police_Report_Number.ToString();
    //            }
    //        }
    //    }
    //}
    //#endregion

    //#region Theft Grid Events
    //protected void gvTheft_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //}
    //protected void gvTheft_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    //check Row Type
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkRemove");
    //        //check null value
    //        if (lnkbtn != null)
    //            lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);

    //        LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
    //        //check Null value
    //        if (lnkbtnEdit != null)
    //            lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
    //    }
    //}
    //protected void gvTheft_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //}
    //protected void gvTheft_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //check Command Name if it is "Remove" than remove the selected row
    //    if (e.CommandName == "Remove")
    //    {
    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        int PK_ID = (gvTheft.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvTheft.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than delete record
    //        if (PK_ID > 0)
    //        {
    //            DPD_FR_Vehicle.DeleteByPK(PK_ID);
    //        }
    //        ClearTheft_Controls();
    //        PK_DPD_FR_Theft_ID = 0;
    //        //Bind Grid
    //        BindTheftGrid();
    //    }
    //    else if (e.CommandName == "Edit")
    //    {
    //        //clear the controls
    //        ClearTheft_Controls();
    //        btnAddTheft.Text = "Update";
    //        btnViewAuditTheft.Visible = true;

    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        PK_DPD_FR_Theft_ID = (gvTheft.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvTheft.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than display below fields else hide.
    //        if (PK_DPD_FR_Theft_ID > 0)
    //        {
    //            btnViewAuditTheft.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_DPD_FR_Theft_ID + ");");
    //            //DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Theft_ID);
    //            revTheft_Year.Enabled = true;
    //            tdtheft.Style.Add("display", "");
    //            DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Theft_ID);
    //            txtTheft_Make.Text = string.IsNullOrEmpty(objDFV.Make) ? "" : objDFV.Make.ToString();
    //            txtTheft_Model.Text = string.IsNullOrEmpty(objDFV.Model) ? "" : objDFV.Model.ToString();
    //            txtTheft_Year.Text = (objDFV.Year.ToString() == "0") ? "" : objDFV.Year.ToString();
    //            txtTheft_VIN.Text = string.IsNullOrEmpty(objDFV.VIN) ? "" : objDFV.VIN.ToString();
    //            ListItem lstTypeOfVehicle = ddlTheft_TypeOfVehicle.Items.FindByText(string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString());
    //            ddlTheft_TypeOfVehicle.ClearSelection();
    //            if (lstTypeOfVehicle != null)
    //                lstTypeOfVehicle.Selected = true;

    //            txtTheft_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
    //            txtTheft_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
    //            ListItem lstPresent_State = ddlTheft_Present_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.Present_State) ? "0" : objDFV.Present_State.ToString());
    //            ddlTheft_Present_State.ClearSelection();
    //            if (lstPresent_State != null)
    //                lstPresent_State.Selected = true;
    //            txtTheft_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
    //            txtTheft_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);
    //            txtTheft_Loss_Description.Text = objDFV.Loss_Description;
    //            if (objDFV.Vehicle_Recovered != null)
    //            {
    //                if (objDFV.Vehicle_Recovered == true)
    //                    rdoTheft_Vehicle_Recovered.SelectedValue = "1";
    //                else
    //                    rdoTheft_Vehicle_Recovered.SelectedValue = "0";
    //            }
    //            if (objDFV.Vehicle_Recovered == true)
    //            {
    //                tdTheft_VehicleRecovred.Style.Add("display", "");
    //                //rfvTheft_Damage_estimate.Enabled = true;
    //                rfvTheft_Dealership_Wish_To_Take_Possession.Enabled = true;
    //                txtTheft_Damage_estimate.Text = clsGeneral.GetStringValue(objDFV.Damage_Estimate);
    //                if (objDFV.Dealership_Wish_To_Take_Possession != null)
    //                {
    //                    if (objDFV.Dealership_Wish_To_Take_Possession == true)
    //                        rdoTheft_Dealership_Wish_To_Take_Possession.SelectedValue = "1";
    //                    else
    //                        rdoTheft_Dealership_Wish_To_Take_Possession.SelectedValue = "0";
    //                }
    //            }
    //            if (objDFV.Vehicle_In_Storage != null)
    //            {
    //                if (objDFV.Vehicle_In_Storage == true)
    //                    rdoVehicle_In_Storage.SelectedValue = "1";
    //                else
    //                    rdoVehicle_In_Storage.SelectedValue = "0";
    //            }
    //            if (objDFV.Vehicle_In_Storage == true)
    //            {
    //                //rfvTheft_Storage_Address_1.Enabled = true;
    //                //rfvTheft_Storage_Contact.Enabled = true;
    //                //rfvTheft_Storage_Address_2.Enabled = true;
    //                //rfvTheft_Storage_phone.Enabled = true;
    //                //rfvTheft_Storage_City.Enabled = true;
    //                //rfvTheft_Storage_cost.Enabled = true;
    //                //rfvTheft_Storage_State.Enabled = true;
    //                //rfvTheft_storage_Zip_Code.Enabled = true;
    //                tdVehicle_In_Storage.Style.Add("display", "");
    //                txtTheft_Storage_Address_1.Text = string.IsNullOrEmpty(objDFV.storage_Address_1) ? "" : objDFV.storage_Address_1.ToString();
    //                txtTheft_Storage_Address_2.Text = string.IsNullOrEmpty(objDFV.storage_Address_2) ? "" : objDFV.storage_Address_2.ToString();
    //                txtTheft_Storage_Contact.Text = string.IsNullOrEmpty(objDFV.Storage_Contact) ? "" : objDFV.Storage_Contact.ToString();
    //                txtTheft_Storage_phone.Text = string.IsNullOrEmpty(objDFV.Storage_phone) ? "" : objDFV.Storage_phone.ToString();
    //                txtTheft_Storage_City.Text = string.IsNullOrEmpty(objDFV.storage_City) ? "" : objDFV.storage_City.ToString();
    //                txtTheft_Storage_cost.Text = clsGeneral.GetStringValue(objDFV.storage_cost);
    //                txtTheft_storage_Zip_Code.Text = string.IsNullOrEmpty(objDFV.storage_Zip_Code) ? "" : objDFV.storage_Zip_Code.ToString();
    //                ddlTheft_Storage_State.ClearSelection();
    //                ListItem lstState = ddlTheft_Storage_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.storage_State) ? "0" : objDFV.storage_State.ToString());
    //                if (lstState != null)
    //                {
    //                    lstState.Selected = true;
    //                }

    //            }
    //        }
    //    }
    //}
    //#endregion

    #region Partail Theft Grid Events

    #endregion

    //#region Vandalism Grid Events
    //protected void gvVandalism_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //}
    //protected void gvVandalism_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    //check Row Type
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkRemove");
    //        //check null value
    //        if (lnkbtn != null)
    //            lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);

    //        LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
    //        //check Null value
    //        if (lnkbtnEdit != null)
    //            lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
    //    }
    //}
    //protected void gvVandalism_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //}
    //protected void gvVandalism_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //check Command Name if it is "Remove" than remove the selected row
    //    if (e.CommandName == "Remove")
    //    {
    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        int PK_ID = (gvVandalism.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvVandalism.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than delete record
    //        if (PK_ID > 0)
    //        {
    //            DPD_FR_Vehicle.DeleteByPK(PK_ID);
    //        }
    //        ClearVandalism_Controls();
    //        PK_DPD_FR_Vandalism_ID = 0;
    //        //Bind Grid
    //        BindVandalismGrid();
    //    }
    //    else if (e.CommandName == "Edit")
    //    {
    //        ClearVandalism_Controls();
    //        btnAddVandalism.Text = "Update";
    //        btnViewAuditVandalism.Visible = true;

    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        PK_DPD_FR_Vandalism_ID = (gvVandalism.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvVandalism.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than display below fields else hide.
    //        if (PK_DPD_FR_Vandalism_ID > 0)
    //        {
    //            btnViewAuditVandalism.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_DPD_FR_Vandalism_ID + ");");
    //            DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Vandalism_ID);
    //            revVandalism_Year.Enabled = true;
    //            tdVandalism.Style.Add("display", "");
    //            txtVandalism_Make.Text = string.IsNullOrEmpty(objDFV.Make) ? "" : objDFV.Make.ToString();
    //            txtVandalism_Model.Text = string.IsNullOrEmpty(objDFV.Model) ? "" : objDFV.Model.ToString();
    //            txtVandalism_Year.Text = (objDFV.Year.ToString() == "0") ? "" : objDFV.Year.ToString();
    //            txtVandalism_VIN.Text = string.IsNullOrEmpty(objDFV.VIN) ? "" : objDFV.VIN.ToString();
    //            ListItem lstTypeOfVehicle = ddlVandalism_TypeOfVehicle.Items.FindByText(string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString());
    //            ddlVandalism_TypeOfVehicle.ClearSelection();
    //            if (lstTypeOfVehicle != null)
    //                lstTypeOfVehicle.Selected = true;

    //            txtVandalism_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
    //            txtVandalism_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
    //            ListItem lstPresent_State = ddlVandalism_Present_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.Present_State) ? "0" : objDFV.Present_State.ToString());
    //            ddlVandalism_Present_State.ClearSelection();
    //            if (lstPresent_State != null)
    //                lstPresent_State.Selected = true;
    //            txtVandalism_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
    //            txtVandalism_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);
    //            txtVandalism_Loss_Description.Text = objDFV.Loss_Description;
    //        }
    //    }
    //}
    //#endregion

    //#region Hail Grid Events
    //protected void gvHail_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //}
    //protected void gvHail_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    //check Row Type
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkRemove");
    //        //check null value
    //        if (lnkbtn != null)
    //            lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);

    //        LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
    //        //check Null value
    //        if (lnkbtnEdit != null)
    //            lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
    //    }
    //}
    //protected void gvHail_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //}
    //protected void gvHail_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //check Command Name if it is "Remove" than remove the selected row
    //    if (e.CommandName == "Remove")
    //    {
    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        int PK_ID = (gvHail.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvHail.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than delete record
    //        if (PK_ID > 0)
    //        {
    //            DPD_FR_Vehicle.DeleteByPK(PK_ID);
    //        }
    //        ClearHail_Controls();
    //        PK_DPD_FR_Hail_ID = 0;
    //        //Bind Grid
    //        BindHailGrid();
    //    }
    //    else if (e.CommandName == "Edit")
    //    {
    //        ClearHail_Controls();
    //        btnAddHail.Text = "Update";
    //        btnViewAuditHail.Visible = true;

    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        PK_DPD_FR_Hail_ID = (gvHail.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvHail.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than display below fields else hide.
    //        if (PK_DPD_FR_Hail_ID > 0)
    //        {
    //            btnViewAuditHail.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_DPD_FR_Hail_ID + ");");
    //            DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Hail_ID);
    //            revHail_Year.Enabled = true;
    //            tdHail.Style.Add("display", "");
    //            txtHail_Make.Text = string.IsNullOrEmpty(objDFV.Make) ? "" : objDFV.Make.ToString();
    //            txtHail_Model.Text = string.IsNullOrEmpty(objDFV.Model) ? "" : objDFV.Model.ToString();
    //            txtHail_Year.Text = (objDFV.Year.ToString() == "0") ? "" : objDFV.Year.ToString();
    //            txtHail_VIN.Text = string.IsNullOrEmpty(objDFV.VIN) ? "" : objDFV.VIN.ToString();
    //            ListItem lstTypeOfVehicle = ddlHail_TypeOfVehicle.Items.FindByText(string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString());
    //            ddlHail_TypeOfVehicle.ClearSelection();
    //            if (lstTypeOfVehicle != null)
    //                lstTypeOfVehicle.Selected = true;

    //            txtHail_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
    //            txtHail_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
    //            ListItem lstPresent_State = ddlHail_Present_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.Present_State) ? "0" : objDFV.Present_State.ToString());
    //            ddlHail_Present_State.ClearSelection();
    //            if (lstPresent_State != null)
    //                lstPresent_State.Selected = true;
    //            txtHail_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
    //            txtHail_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);
    //            txtHail_Loss_Description.Text = objDFV.Loss_Description;
    //        }
    //    }
    //}
    //#endregion

    //#region Flood Grid Events
    //protected void gvFlood_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //}
    //protected void gvFlood_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    //check Row Type
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkRemove");
    //        //check null value
    //        if (lnkbtn != null)
    //            lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);

    //        LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
    //        //check Null value
    //        if (lnkbtnEdit != null)
    //            lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
    //    }
    //}
    //protected void gvFlood_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //}
    //protected void gvFlood_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //check Command Name if it is "Remove" than remove the selected row
    //    if (e.CommandName == "Remove")
    //    {
    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        int PK_ID = (gvFlood.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvFlood.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than delete record
    //        if (PK_ID > 0)
    //        {
    //            DPD_FR_Vehicle.DeleteByPK(PK_ID);
    //        }
    //        ClearFlood_Controls();
    //        PK_DPD_FR_Flood_ID = 0;
    //        //Bind Grid
    //        BindFloodGrid();
    //    }
    //    else if (e.CommandName == "Edit")
    //    {
    //        ClearFlood_Controls();
    //        btnAddFlood.Text = "Update";
    //        btnViewAuditFlood.Visible = true;

    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        PK_DPD_FR_Flood_ID = (gvFlood.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvFlood.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than display below fields else hide.
    //        if (PK_DPD_FR_Flood_ID > 0)
    //        {
    //            btnViewAuditFlood.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_DPD_FR_Flood_ID + ");");
    //            DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Flood_ID);
    //            revFlood_Year.Enabled = true;
    //            tdFlood.Style.Add("display", "");
    //            txtFlood_Make.Text = string.IsNullOrEmpty(objDFV.Make) ? "" : objDFV.Make.ToString();
    //            txtFlood_Model.Text = string.IsNullOrEmpty(objDFV.Model) ? "" : objDFV.Model.ToString();
    //            txtFlood_Year.Text = (objDFV.Year.ToString() == "0") ? "" : objDFV.Year.ToString();
    //            txtFlood_VIN.Text = string.IsNullOrEmpty(objDFV.VIN) ? "" : objDFV.VIN.ToString();
    //            ListItem lstTypeOfVehicle = ddlFlood_TypeOfVehicle.Items.FindByText(string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString());
    //            ddlFlood_TypeOfVehicle.ClearSelection();
    //            if (lstTypeOfVehicle != null)
    //                lstTypeOfVehicle.Selected = true;

    //            txtFlood_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
    //            txtFlood_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
    //            ListItem lstPresent_State = ddlFlood_Present_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.Present_State) ? "0" : objDFV.Present_State.ToString());
    //            ddlFlood_Present_State.ClearSelection();
    //            if (lstPresent_State != null)
    //                lstPresent_State.Selected = true;
    //            txtFlood_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
    //            txtFlood_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);
    //            txtFlood_Loss_Description.Text = objDFV.Loss_Description;
    //        }
    //    }
    //}
    //#endregion

    //#region Fire Grid Events
    //protected void gvFire_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //}
    //protected void gvFire_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    //check Row Type
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkRemove");
    //        //check null value
    //        if (lnkbtn != null)
    //            lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);

    //        LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
    //        //check Null value
    //        if (lnkbtnEdit != null)
    //            lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
    //    }
    //}
    //protected void gvFire_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //}
    //protected void gvFire_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //check Command Name if it is "Remove" than remove the selected row
    //    if (e.CommandName == "Remove")
    //    {
    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        int PK_ID = (gvFire.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvFire.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than delete record
    //        if (PK_ID > 0)
    //        {
    //            DPD_FR_Vehicle.DeleteByPK(PK_ID);
    //        }
    //        ClearFire_Controls();
    //        PK_DPD_FR_Fire_ID = 0;
    //        //Bind Grid
    //        BindFireGrid();
    //    }
    //    else if (e.CommandName == "Edit")
    //    {
    //        ClearFire_Controls();
    //        btnAddFire.Text = "Update";
    //        btnViewAuditFire.Visible = true;

    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        PK_DPD_FR_Fire_ID = (gvFire.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvFire.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than display below fields else hide.
    //        if (PK_DPD_FR_Fire_ID > 0)
    //        {
    //            btnViewAuditFire.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_DPD_FR_Fire_ID + ");");
    //            DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Fire_ID);
    //            revFire_Year.Enabled = true;
    //            tdFire.Style.Add("display", "");
    //            txtFire_Make.Text = string.IsNullOrEmpty(objDFV.Make) ? "" : objDFV.Make.ToString();
    //            txtFire_Model.Text = string.IsNullOrEmpty(objDFV.Model) ? "" : objDFV.Model.ToString();
    //            txtFire_Year.Text = (objDFV.Year.ToString() == "0") ? "" : objDFV.Year.ToString();
    //            txtFire_VIN.Text = string.IsNullOrEmpty(objDFV.VIN) ? "" : objDFV.VIN.ToString();
    //            ListItem lstTypeOfVehicle = ddlFire_TypeOfVehicle.Items.FindByText(string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString());
    //            ddlFire_TypeOfVehicle.ClearSelection();
    //            if (lstTypeOfVehicle != null)
    //                lstTypeOfVehicle.Selected = true;

    //            txtFire_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
    //            txtFire_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
    //            ListItem lstPresent_State = ddlFire_Present_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.Present_State) ? "0" : objDFV.Present_State.ToString());
    //            ddlFire_Present_State.ClearSelection();
    //            if (lstPresent_State != null)
    //                lstPresent_State.Selected = true;
    //            txtFire_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
    //            txtFire_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);
    //            txtFire_Loss_Description.Text = objDFV.Loss_Description;
    //        }
    //    }
    //}
    //#endregion

    //#region Wind Grid Events
    //protected void gvWind_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //}
    //protected void gvWind_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    //check Row Type
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkRemove");
    //        //check null value
    //        if (lnkbtn != null)
    //            lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);

    //        LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
    //        //check Null value
    //        if (lnkbtnEdit != null)
    //            lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
    //    }
    //}
    //protected void gvWind_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //}
    //protected void gvWind_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //check Command Name if it is "Remove" than remove the selected row
    //    if (e.CommandName == "Remove")
    //    {
    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        int PK_ID = (gvWind.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvWind.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than delete record
    //        if (PK_ID > 0)
    //        {
    //            DPD_FR_Vehicle.DeleteByPK(PK_ID);
    //        }
    //        ClearWind_Controls();
    //        PK_DPD_FR_Wind_ID = 0;
    //        //Bind Grid
    //        BindWindGrid();
    //    }
    //    else if (e.CommandName == "Edit")
    //    {
    //        ClearWind_Controls();
    //        btnAddWind.Text = "Update";
    //        btnViewAuditWind.Visible = true;

    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        PK_DPD_FR_Wind_ID = (gvWind.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvWind.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
    //        //used to check PK id. if greater than 0 than display below fields else hide.
    //        if (PK_DPD_FR_Wind_ID > 0)
    //        {
    //            btnViewAuditWind.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_DPD_FR_Wind_ID + ");");
    //            DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Wind_ID);
    //            revWind_Year.Enabled = true;
    //            tdWind.Style.Add("display", "");
    //            txtWind_Make.Text = string.IsNullOrEmpty(objDFV.Make) ? "" : objDFV.Make.ToString();
    //            txtWind_Model.Text = string.IsNullOrEmpty(objDFV.Model) ? "" : objDFV.Model.ToString();
    //            txtWind_Year.Text = (objDFV.Year.ToString() == "0") ? "" : objDFV.Year.ToString();
    //            txtWind_VIN.Text = string.IsNullOrEmpty(objDFV.VIN) ? "" : objDFV.VIN.ToString();
    //            ListItem lstTypeOfVehicle = ddlWind_TypeOfVehicle.Items.FindByText(string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString());
    //            ddlWind_TypeOfVehicle.ClearSelection();
    //            if (lstTypeOfVehicle != null)
    //                lstTypeOfVehicle.Selected = true;

    //            txtWind_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
    //            txtWind_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
    //            ListItem lstPresent_State = ddlWind_Present_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.Present_State) ? "0" : objDFV.Present_State.ToString());
    //            ddlWind_Present_State.ClearSelection();
    //            if (lstPresent_State != null)
    //                lstPresent_State.Selected = true;
    //            txtWind_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
    //            txtWind_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);
    //            txtWind_Loss_Description.Text = objDFV.Loss_Description;
    //        }
    //    }
    //}
    //#endregion

    //#region MVASingle_Passenger Grid Events
    //protected void gvMVASingle_Passenger_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //}
    //protected void gvMVASingle_Passenger_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    //check Row Type
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkRemove");
    //        //check null value
    //        if (lnkbtn != null)
    //            lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);

    //        LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
    //        //check Null value
    //        if (lnkbtnEdit != null)
    //            lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
    //    }
    //}
    //protected void gvMVASingle_Passenger_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //}
    //protected void gvMVASingle_Passenger_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //check Command Name if it is "Remove" than remove the selected row
    //    if (e.CommandName == "Remove")
    //    {
    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        int PK_ID = (gvMVASingle_Passenger.DataKeys[Index].Values["PK_DPD_FR_Injured_Passenger_id"] != null) ? Convert.ToInt32(gvMVASingle_Passenger.DataKeys[Index].Values["PK_DPD_FR_Injured_Passenger_id"]) : 0;
    //        //used to check PK id. if greater than 0 than delete record
    //        if (PK_ID > 0)
    //        {
    //            DPD_FR_Injured_Passenger.DeleteByPK(PK_ID);
    //        }
    //        ClearMVASinglePassenger_Controls();
    //        PK_DPD_FR_Passenger_ID = 0;
    //        //Bind Grid
    //        BindPassengerGrid(gvMVASingle_Passenger, PK_DPD_FR_Single_Vehicle_ID);
    //    }
    //    else if (e.CommandName == "Edit")
    //    {
    //        ClearMVASinglePassenger_Controls();
    //        btnMVASingle_Passenger.Text = "Update";
    //        btnViewAudit_MVASingle_Passenger.Visible = true;

    //        int Index = Convert.ToInt32(e.CommandArgument);
    //        PK_DPD_FR_Passenger_ID = (gvMVASingle_Passenger.DataKeys[Index].Values["PK_DPD_FR_Injured_Passenger_id"] != null) ? Convert.ToInt32(gvMVASingle_Passenger.DataKeys[Index].Values["PK_DPD_FR_Injured_Passenger_id"]) : 0;
    //        //used to check PK id. if greater than 0 than display below fields else hide.
    //        if (PK_DPD_FR_Passenger_ID > 0)
    //        {
    //            btnViewAudit_MVASingle_Passenger.Attributes.Add("onClick", "return AuditPopUpForDPDPassenger(" + PK_DPD_FR_Passenger_ID + ");");
    //            DPD_FR_Injured_Passenger objDFIP = new DPD_FR_Injured_Passenger(PK_DPD_FR_Passenger_ID);
    //            txtPass_Name.Text = objDFIP.name;
    //            txtPass_Address_1.Text = objDFIP.Address_1;
    //            txtPass_Address_2.Text = objDFIP.Address_2;
    //            txtPass_Phone.Text = objDFIP.phone;
    //            txtPass_City.Text = objDFIP.City;
    //            if (objDFIP.injured != null)
    //            {
    //                if (objDFIP.injured == true)
    //                    rdoPass_Injured.SelectedValue = "1";
    //                else
    //                    rdoPass_Injured.SelectedValue = "0";
    //            }
    //            ddlPass_State.ClearSelection();
    //            ListItem lstPass_State = ddlPass_State.Items.FindByValue(string.IsNullOrEmpty(objDFIP.State) ? "0" : objDFIP.State.ToString());
    //            if (lstPass_State != null)
    //                lstPass_State.Selected = true;
    //            txtPass_Zip.Text = objDFIP.Zip_Code;
    //        }
    //    }
    //}
    //#endregion

    #region MVAMulti_Passenger Grid Events
    protected void gvMVAMulti_Passenger_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void gvMVAMulti_Passenger_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //check Row Type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkRemove");
            //check null value
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);

            LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            //check Null value
            if (lnkbtnEdit != null)
                lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    protected void gvMVAMulti_Passenger_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }
    protected void gvMVAMulti_Passenger_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if it is "Remove" than remove the selected row
        if (e.CommandName == "Remove")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvMVAMulti_Passenger.DataKeys[Index].Values["PK_DPD_FR_Injured_Passenger_id"] != null) ? Convert.ToInt32(gvMVAMulti_Passenger.DataKeys[Index].Values["PK_DPD_FR_Injured_Passenger_id"]) : 0;
            //used to check PK id. if greater than 0 than delete record
            if (PK_ID > 0)
            {
                DPD_FR_Injured_Passenger.DeleteByPK(PK_ID);
            }
            ClearMVAMultiPassenger_Controls();
            PK_DPD_FR_Passenger_ID = 0;
            //Bind Grid
            BindPassengerGrid(gvMVAMulti_Passenger, PK_DPD_FR_Multi_Vehicle_ID);
        }
        else if (e.CommandName == "Edit")
        {
            ClearMVAMultiPassenger_Controls();
            btnMVA_Multi_Passenger.Text = "Update";
            btnViewAudit_MVA_Multi_Passenger.Visible = true;

            int Index = Convert.ToInt32(e.CommandArgument);
            PK_DPD_FR_Passenger_ID = (gvMVAMulti_Passenger.DataKeys[Index].Values["PK_DPD_FR_Injured_Passenger_id"] != null) ? Convert.ToInt32(gvMVAMulti_Passenger.DataKeys[Index].Values["PK_DPD_FR_Injured_Passenger_id"]) : 0;
            //used to check PK id. if greater than 0 than display below fields else hide.
            if (PK_DPD_FR_Passenger_ID > 0)
            {
                btnViewAudit_MVA_Multi_Passenger.Attributes.Add("onClick", "return AuditPopUpForDPDPassenger(" + PK_DPD_FR_Passenger_ID + ");");
                DPD_FR_Injured_Passenger objDFIP = new DPD_FR_Injured_Passenger(PK_DPD_FR_Passenger_ID);
                txtMVA_MultiPass_Name.Text = objDFIP.name;
                txtMVA_MultiPass_Address_1.Text = objDFIP.Address_1;
                txtMVA_MultiPass_Address_2.Text = objDFIP.Address_2;
                txtMVA_MultiPass_Phone.Text = objDFIP.phone;
                txtMVA_MultiPass_City.Text = objDFIP.City;
                if (objDFIP.injured != null)
                {
                    if (objDFIP.injured == true)
                        rdoMVA_MultiPass_Injured.SelectedValue = "1";
                    else
                        rdoMVA_MultiPass_Injured.SelectedValue = "0";
                }
                ddlMVA_MultiPass_State.ClearSelection();
                ListItem lstPass_State = ddlMVA_MultiPass_State.Items.FindByValue(string.IsNullOrEmpty(objDFIP.State) ? "0" : objDFIP.State.ToString());
                if (lstPass_State != null)
                    lstPass_State.Selected = true;
                txtMVA_MultiPass_Zip.Text = objDFIP.Zip_Code;
            }
        }
    }
    #endregion
    //#region Clear Fraud Controls
    ///// <summary>
    ///// used to clear Fraud section controls
    ///// </summary>
    //public void ClearFraud_Controls()
    //{
    //    txtFraud_Make.Text = "";
    //    txtFraud_Model.Text = "";
    //    txtFraud_VIN.Text = "";
    //    txtFraud_Invoice_Value.Text = "";
    //    txtFraud_Loss_Description.Text = "";
    //    txtFraud_Year.Text = "";
    //    txtFraud_Present_Address.Text = "";
    //    txtFraud_Present_Location.Text = "";
    //    txtFraud_Present_Zip.Text = "";
    //    ddlFraud_Present_State.ClearSelection();
    //    ddlFraud_TypeOfVehicle.ClearSelection();
    //    rdoFraud_Vehicle_Recovered.ClearSelection();
    //    rdoFraud_Dealership_Wish_To_Take_Possession.ClearSelection();
    //    txtFraud_Damage_estimate.Text = "";
    //    rdoFraudVehicle_In_Storage.ClearSelection();
    //    txtFraud_Storage_Address_1.Text = "";
    //    txtFraud_Storage_Address_2.Text = "";
    //    txtFraud_Storage_Contact.Text = "";
    //    txtFraud_Storage_cost.Text = "";
    //    txtFraud_Storage_phone.Text = "";
    //    txtFraud_Storage_City.Text = "";
    //    txtFraud_storage_Zip_Code.Text = "";
    //    txtFraudReportNumber.Text = "";
    //    rdoFraudPoliceNotified.ClearSelection();
    //    ddlFraud_Storage_State.ClearSelection();
    //    tdFraud_VehicleRecovred.Style.Add("display", "none");
    //    tdFraudVehicle_In_Storage.Style.Add("display", "none");
    //    trPoliceNotified.Style.Add("display", "none");
    //    btnAddFraud.Text = "Add";
    //    //rfvFraud_Damage_estimate.Enabled = false;
    //    rfvFraud_Dealership_Wish_To_Take_Possession.Enabled = false;
    //    btnViewAuditFraud.Visible = false;
    //    //rfvFraud_Storage_Address_1.Enabled = false;
    //    //rfvFraud_Storage_Contact.Enabled = false;
    //    //rfvFraud_Storage_Address_2.Enabled = false;
    //    //rfvFraud_Storage_phone.Enabled = false;
    //    //rfvFraud_Storage_City.Enabled = false;
    //    //rfvFraud_Storage_cost.Enabled = false;
    //    //rfvFraud_Storage_State.Enabled = false;
    //    //rfvFraud_storage_Zip_Code.Enabled = false;
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedFraud = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}
    //#endregion

    //#region Clear Theft Controls
    ///// <summary>
    ///// used to clear Theft section controls
    ///// </summary>
    //public void ClearTheft_Controls()
    //{
    //    txtTheft_Make.Text = "";
    //    txtTheft_Model.Text = "";
    //    txtTheft_VIN.Text = "";
    //    txtTheft_Present_Address.Text = "";
    //    txtTheft_Present_Location.Text = "";
    //    txtTheft_Present_Zip.Text = "";
    //    ddlTheft_Present_State.ClearSelection();
    //    ddlTheft_TypeOfVehicle.ClearSelection();
    //    txtTheft_Invoice_Value.Text = "";
    //    txtTheft_Loss_Description.Text = "";
    //    txtTheft_Year.Text = "";
    //    rdoTheft_Vehicle_Recovered.ClearSelection();
    //    rdoTheft_Dealership_Wish_To_Take_Possession.ClearSelection();
    //    txtTheft_Damage_estimate.Text = "";
    //    rdoVehicle_In_Storage.ClearSelection();
    //    txtTheft_Storage_Address_1.Text = "";
    //    txtTheft_Storage_Address_2.Text = "";
    //    txtTheft_Storage_Contact.Text = "";
    //    txtTheft_Storage_cost.Text = "";
    //    txtTheft_Storage_phone.Text = "";
    //    txtTheft_Storage_City.Text = "";
    //    txtTheft_storage_Zip_Code.Text = "";
    //    ddlTheft_Storage_State.ClearSelection();
    //    tdTheft_VehicleRecovred.Style.Add("display", "none");
    //    tdVehicle_In_Storage.Style.Add("display", "none");
    //    btnAddTheft.Text = "Add";
    //    btnViewAuditTheft.Visible = false;
    //    //rfvTheft_Damage_estimate.Enabled = false;
    //    rfvTheft_Dealership_Wish_To_Take_Possession.Enabled = false;
    //    //rfvTheft_Storage_Address_1.Enabled = false;
    //    //rfvTheft_Storage_Contact.Enabled = false;
    //    //rfvTheft_Storage_Address_2.Enabled = false;
    //    //rfvTheft_Storage_phone.Enabled = false;
    //    //rfvTheft_Storage_City.Enabled = false;
    //    //rfvTheft_Storage_cost.Enabled = false;
    //    //rfvTheft_Storage_State.Enabled = false;
    //    //rfvTheft_storage_Zip_Code.Enabled = false;
    //    ScriptManager.RegisterClientScriptBlock(this, typeof(string), DateTime.Now.ToString(), "bAddedTheft = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}
    //#endregion

    #region Clear Partial Theft Controls
    /// <summary>
    /// used to clear Theft section controls
    /// </summary>
    public void ClearVehicleDetails_Controls()
    {
        //txtPartialTheft_Make.Text = "";
        //txtPartialTheft_Model.Text = "";
        //txtPartialTheft_VIN.Text = "";
        //txtPartialTheft_Invoice_Value.Text = "";
        //txtPartialTheft_Loss_Description.Text = "";
        //txtPartialTheft_Year.Text = "";
        //txtPartialTheft_Present_Address.Text = "";
        //txtPartialTheft_Present_Location.Text = "";
        //txtPartialTheft_Present_Zip.Text = "";
        //ddlPartialTheft_Present_State.ClearSelection();
        //ddlPartialTheft_TypeOfVehicle.ClearSelection();
        btnAddVehicle.Text = "Add";
        btnViewAuditVehicle.Visible = false;

        ScriptManager.RegisterClientScriptBlock(this, typeof(string), DateTime.Now.ToString(), "bAddedPartialTheft = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    }
    #endregion

    //#region Clear Vandalism Controls
    ///// <summary>
    ///// used to clear Theft section controls
    ///// </summary>
    //public void ClearVandalism_Controls()
    //{
    //    txtVandalism_Make.Text = "";
    //    txtVandalism_Model.Text = "";
    //    txtVandalism_VIN.Text = "";
    //    txtVandalism_Invoice_Value.Text = "";
    //    txtVandalism_Loss_Description.Text = "";
    //    txtVandalism_Year.Text = "";
    //    txtVandalism_Present_Address.Text = "";
    //    txtVandalism_Present_Location.Text = "";
    //    txtVandalism_Present_Zip.Text = "";
    //    ddlVandalism_Present_State.ClearSelection();
    //    ddlVandalism_TypeOfVehicle.ClearSelection();
    //    btnAddVandalism.Text = "Add";
    //    btnViewAuditVandalism.Visible = false;
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedVandalism = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}
    //#endregion

    //#region Clear Hail Controls
    ///// <summary>
    ///// used to clear Theft section controls
    ///// </summary>
    //public void ClearHail_Controls()
    //{
    //    txtHail_Make.Text = "";
    //    txtHail_Model.Text = "";
    //    txtHail_VIN.Text = "";
    //    txtHail_Invoice_Value.Text = "";
    //    txtHail_Loss_Description.Text = "";
    //    txtHail_Year.Text = "";
    //    txtHail_Present_Address.Text = "";
    //    txtHail_Present_Location.Text = "";
    //    txtHail_Present_Zip.Text = "";
    //    ddlHail_Present_State.ClearSelection();
    //    ddlHail_TypeOfVehicle.ClearSelection();
    //    btnAddHail.Text = "Add";
    //    btnViewAuditHail.Visible = false;
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedHail = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}
    //#endregion

    //#region Clear Flood Controls
    ///// <summary>
    ///// used to clear Flood section controls
    ///// </summary>
    //public void ClearFlood_Controls()
    //{
    //    txtFlood_Make.Text = "";
    //    txtFlood_Model.Text = "";
    //    txtFlood_VIN.Text = "";
    //    txtFlood_Invoice_Value.Text = "";
    //    txtFlood_Loss_Description.Text = "";
    //    txtFlood_Year.Text = "";
    //    txtFlood_Present_Address.Text = "";
    //    txtFlood_Present_Location.Text = "";
    //    txtFlood_Present_Zip.Text = "";
    //    ddlFlood_Present_State.ClearSelection();
    //    ddlFlood_TypeOfVehicle.ClearSelection();
    //    btnAddFlood.Text = "Add";
    //    btnViewAuditFlood.Visible = false;
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedFood = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}


    //#endregion

    //#region Clear Wind Controls
    ///// <summary>
    ///// used to clear Wind section controls
    ///// </summary>
    //public void ClearWind_Controls()
    //{
    //    txtWind_Make.Text = "";
    //    txtWind_Model.Text = "";
    //    txtWind_VIN.Text = "";
    //    txtWind_Invoice_Value.Text = "";
    //    txtWind_Loss_Description.Text = "";
    //    txtWind_Year.Text = "";
    //    txtWind_Present_Address.Text = "";
    //    txtWind_Present_Location.Text = "";
    //    txtWind_Present_Zip.Text = "";
    //    ddlWind_Present_State.ClearSelection();
    //    ddlWind_TypeOfVehicle.ClearSelection();
    //    btnAddWind.Text = "Add";
    //    btnViewAuditWind.Visible = false;
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedWind = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}
    //#endregion

    //#region Clear MVA single Passenger Controls
    ///// <summary>
    ///// used to clear Wind section controls
    ///// </summary>
    //public void ClearMVASinglePassenger_Controls()
    //{
    //    txtPass_Name.Text = "";
    //    txtPass_Address_1.Text = "";
    //    txtPass_Address_2.Text = "";
    //    txtPass_Phone.Text = "";
    //    txtPass_City.Text = "";
    //    rdoPass_Injured.ClearSelection();
    //    ddlPass_State.ClearSelection();
    //    txtPass_Zip.Text = "";
    //    btnViewAudit_MVASingle_Passenger.Visible = false;

    //}
    //#endregion

    //#region Clear Fire Controls
    ///// <summary>
    ///// used to clear Fire section controls
    ///// </summary>
    //public void ClearFire_Controls()
    //{
    //    txtFire_Make.Text = "";
    //    txtFire_Model.Text = "";
    //    txtFire_VIN.Text = "";
    //    txtFire_Invoice_Value.Text = "";
    //    txtFire_Loss_Description.Text = "";
    //    txtFire_Year.Text = "";
    //    txtFire_Present_Address.Text = "";
    //    txtFire_Present_Location.Text = "";
    //    txtFire_Present_Zip.Text = "";
    //    ddlFire_Present_State.ClearSelection();
    //    ddlFire_TypeOfVehicle.ClearSelection();
    //    btnAddFire.Text = "Add";
    //    btnViewAuditFire.Visible = false;
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedFire = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}
    //#endregion

    //#region Clear MVA Single Controls
    ///// <summary>
    ///// used to clear MVA Single section controls
    ///// </summary>
    //public void ClearMVASingle_Controls()
    //{
    //    txtMake.Text = "";
    //    txtModel.Text = "";
    //    txtVIN.Text = "";
    //    txtInvoice_Value.Text = "";
    //    txtMVASingleLoss_description.Text = "";
    //    txtYear.Text = "";
    //    txtPresent_Address.Text = "";
    //    txtPresent_Location.Text = "";
    //    txtPresent_Zip.Text = "";
    //    ddlPresent_State.ClearSelection();
    //    ddlTypeOfVehicle.ClearSelection();
    //    txtDamage_Estimate.Text = "";
    //    rdoDriven_By_Associate.ClearSelection();
    //    rdoAssociate_Cited.ClearSelection();
    //    txtDescription_Of_Citation.Text = "";
    //    rdoAssociate_injured.ClearSelection();
    //    rdoDrug_test_performed.ClearSelection();
    //    txtDrug_test_explanation.Text = "";
    //    txtDrug_test_results.Text = "";
    //    rdoVehicle_Driven_By_Customer.ClearSelection();
    //    rdocustomer_injured.ClearSelection();
    //    rdoAdditional_passengers.ClearSelection();
    //    rdoSeeking_subrogation.ClearSelection();
    //    txtTPI_Carrier_name.Text = "";
    //    txttpi_contact.Text = "";
    //    txtTPI_Policy_number.Text = "";
    //    txttpi_phone.Text = "";
    //    txttpi_address_1.Text = "";
    //    txttpi_address_2.Text = "";
    //    txttpi_City.Text = "";
    //    ddltpi_State.ClearSelection();
    //    txttpi_Zip_Code.Text = "";
    //    txtRecovered_Amount.Text = "";
    //    trSeeking_subrogation_Yes.Style.Add("display", "none");
    //    trSeeking_subrogation_No.Style.Add("display", "none");
    //    trAdditional_passengers_Yes.Style.Add("display", "none");
    //    trCust_Injured.Style.Add("display", "none");
    //    trMVASingle_DrivenByCA_No.Style.Add("display", "none");
    //    trMVASingle_DrivenByCA_Yes.Style.Add("display", "none");
    //    trCitation_Yes.Style.Add("display", "none");
    //    trDrugYes.Style.Add("display", "none");
    //    trDrugNo.Style.Add("display", "none");
    //    btnAddDamageSingleVehicle.Text = "Add";
    //    btnViewAuditSingle.Visible = false;
    //    ClearMVASinglePassenger_Controls();
    //    rfvcustomer_injured.Enabled = false;
    //    rfvVehicle_Driven_By_Customer.Enabled = false;
    //    RequiredFieldValidator rfvDrugTestExplain = (RequiredFieldValidator)txtDrug_test_explanation.FindControl("rfvNotes");
    //    rfvDrugTestExplain.Enabled = false;
    //    RequiredFieldValidator rfvDrugTestResult = (RequiredFieldValidator)txtDrug_test_results.FindControl("rfvNotes");
    //    rfvDrugTestResult.Enabled = false;
    //    txtMVA_SingleNot_Driven_By_Customer_Explain.Text = "";
    //    rfvAssociate_Cited.Enabled = false;
    //    rfvDrug_test_performed.Enabled = false;
    //    rdoNotice_only_claim.ClearSelection();
    //    rfvNotice_only_claim.Enabled = false;
    //    txtMVA_SingleAddress_Yes.Text = "";
    //    txtMVA_SingleName_Yes.Text = "";
    //    txtMVA_SinglePhone_Yes.Text = "";
    //    txtMVA_SingleAddress_No.Text = "";
    //    txtMVA_SingleName_No.Text = "";
    //    txtMVA_SinglePhone_No.Text = "";
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedMVA_single = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}
    //#endregion

    //#region Clear MVA Multi Controls
    ///// <summary>
    ///// used to clear MVA Multi section controls
    ///// </summary>
    //public void ClearMVAMulti_Controls()
    //{
    //    txtMVA_MultiMake.Text = "";
    //    txtMVA_MultiModel.Text = "";
    //    txtMVA_MultiVIN.Text = "";
    //    txtMVA_MultiInvoice_Value.Text = "";
    //    txtMVAMultiLoss_description.Text = "";
    //    txtMVA_MultiYear.Text = "";
    //    txtMVA_MultiPresent_Address.Text = "";
    //    txtMVA_MultiPresent_Location.Text = "";
    //    txtMVA_MultiPresent_Zip.Text = "";
    //    ddlMVA_MultiPresent_State.ClearSelection();
    //    ddlMVA_MultiTypeOfVehicle.ClearSelection();
    //    txtMVA_MultiDamage_Estimate.Text = "";
    //    rdoMVA_MultiDriven_By_Associate.ClearSelection();
    //    rdoMVA_MultiAssociate_Cited.ClearSelection();
    //    txtMVA_MultiDescription_Of_Citation.Text = "";
    //    rdoMVA_MultiAssociate_injured.ClearSelection();
    //    rdoMVA_MultiDrug_test_performed.ClearSelection();
    //    txtMVA_MultiDrug_test_explanation.Text = "";
    //    txtMVA_MultiDrug_test_results.Text = "";
    //    rdoMVA_MultiVehicle_Driven_By_Customer.ClearSelection();
    //    rdoMVA_Multicustomer_injured.ClearSelection();
    //    rdoMVA_MultiAdditional_passengers.ClearSelection();
    //    rdoMVA_MultiSeeking_subrogation.ClearSelection();
    //    txtMVA_MultiTPI_Carrier_name.Text = "";
    //    txtMVA_Multitpi_contact.Text = "";
    //    txtMVA_MultiTPI_Policy_number.Text = "";
    //    txtMVA_Multitpi_phone.Text = "";
    //    txtMVA_Multitpi_address_1.Text = "";
    //    txtMVA_Multitpi_address_2.Text = "";
    //    txtMVA_Multitpi_City.Text = "";
    //    ddlMVA_Multitpi_State.ClearSelection();
    //    txtMVA_Multitpi_Zip_Code.Text = "";
    //    txtMVA_MultiRecovered_Amount.Text = "";
    //    trMVA_MultiSeeking_subrogation_Yes.Style.Add("display", "none");
    //    trMVA_MultiSeeking_subrogation_No.Style.Add("display", "none");
    //    trMVA_MultiAdditional_passengers_Yes.Style.Add("display", "none");
    //    trMVA_MultiCust_Injured.Style.Add("display", "none");
    //    trMVAMulti_DrivenByCA_No.Style.Add("display", "none");
    //    trMVAMulti_DrivenByCA_Yes.Style.Add("display", "none");
    //    trMVA_MultiCitation_Yes.Style.Add("display", "none");
    //    trMVA_MultiDrugYes.Style.Add("display", "none");
    //    trMVA_MultiDrugNo.Style.Add("display", "none");
    //    trMVA_MultiCust_Not_Injured.Style.Add("display", "none");
    //    txtMVA_MultiNot_Driven_By_Customer_Explain.Text = "";
    //    btnAddDamageMultiVehicle.Text = "Add";
    //    btnViewAuditMulti.Visible = false;
    //    ClearMVAMultiPassenger_Controls();
    //    rfvMVA_Multicustomer_injured.Enabled = false;
    //    rfvMVA_MultiVehicle_Driven_By_Customer.Enabled = false;
    //    RequiredFieldValidator rfvMVA_MultiDrugTestExplain = (RequiredFieldValidator)txtMVA_MultiDrug_test_explanation.FindControl("rfvNotes");
    //    rfvMVA_MultiDrugTestExplain.Enabled = false;
    //    RequiredFieldValidator rfvMVA_MultiDrugTestResult = (RequiredFieldValidator)txtMVA_MultiDrug_test_results.FindControl("rfvNotes");
    //    rfvMVA_MultiDrugTestResult.Enabled = false;
    //    RequiredFieldValidator rfvMVA_MultiDesc_Citation = (RequiredFieldValidator)txtMVA_MultiDescription_Of_Citation.FindControl("rfvNotes");
    //    rfvMVA_MultiDesc_Citation.Enabled = false;
    //    RequiredFieldValidator rfvMVA_MultiNot_Driven_By_Customer_Explain = (RequiredFieldValidator)txtMVA_MultiNot_Driven_By_Customer_Explain.FindControl("rfvNotes");
    //    rfvMVA_MultiNot_Driven_By_Customer_Explain.Enabled = false;
    //    rfvMVA_MultiAssociate_Cited.Enabled = false;
    //    rfvMVA_MultiDrug_test_performed.Enabled = false;
    //    rdoMVA_MultiNotice_only_claim.ClearSelection();
    //    rfvMVA_MultiNotice_only_claim.Enabled = false;
    //    txtMVA_MultiAddress_Yes.Text = "";
    //    txtMVA_MultiName_Yes.Text = "";
    //    txtMVA_MultiPhone_Yes.Text = "";
    //    txtMVA_MultiAddress_No.Text = "";
    //    txtMVA_MultiName_No.Text = "";
    //    txtMVA_MultiPhone_No.Text = "";
    //    txtMVA_MultiVehicle_Owner_Sonic.Text = "";
    //    txtMVA_MultiVehicle_Owner_Address.Text = "";
    //    txtMVA_MultiVehicle_Owner_Phone.Text = "";
    //    ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedMVA_Multi = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    //}
    //#endregion

    #region Clear MVA Multi Passenger Controls
    /// <summary>
    /// used to clear MVA Multi Passenger controls
    /// </summary>
    public void ClearMVAMultiPassenger_Controls()
    {
        txtMVA_MultiPass_Name.Text = "";
        txtMVA_MultiPass_Address_1.Text = "";
        txtMVA_MultiPass_Address_2.Text = "";
        txtMVA_MultiPass_Phone.Text = "";
        txtMVA_MultiPass_City.Text = "";
        rdoMVA_MultiPass_Injured.ClearSelection();
        ddlMVA_MultiPass_State.ClearSelection();
        txtMVA_MultiPass_Zip.Text = "";
        btnViewAudit_MVA_Multi_Passenger.Visible = false;
    }
    #endregion
    //#region Fill Loss Information Controls [Edit Mode]

    //        #region Theft Section [Edit Mode]
    //        lstCauseOfLoss.Items[7].Selected = objDPD_FR.Theft;
    //        if (objDPD_FR.Theft == true)
    //        {
    //            tdtheft.Style.Add("display", "");
    //            revTheft_Year.Enabled = true;
    //            DataTable dtTheft = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "4");
    //            gvTheft.DataSource = dtTheft;
    //            gvTheft.DataBind();
    //        }

    //        #endregion

    //        #region Partial Theft Section [Edit Mode]
    //        lstCauseOfLoss.Items[6].Selected = objDPD_FR.Partial_Theft;
    //        //used to check checkbox value.if set to true than display related Section
    //        if (objDPD_FR.Partial_Theft == true)
    //        {
    //            tdPartialTheft.Style.Add("display", "");
    //            DataTable dtPartialTheft = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "5");
    //            gvPartialTheft.DataSource = dtPartialTheft;
    //            gvPartialTheft.DataBind();
    //        }
    //        #endregion

    //        #region Fill Vandalism [Edit Mode]
    //        //used to check checkbox value.if set to true than display related Section
    //        lstCauseOfLoss.Items[8].Selected = objDPD_FR.Vandalism;
    //        if (objDPD_FR.Vandalism == true)
    //        {
    //            tdVandalism.Style.Add("display", "");
    //            DataTable dtVandalism = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "6");
    //            gvVandalism.DataSource = dtVandalism;
    //            gvVandalism.DataBind();
    //        }
    //        #endregion

    //        #region Fill MVA-Damage for Single Vehicle [Edit Mode]
    //        lstCauseOfLoss.Items[5].Selected = objDPD_FR.MVA_Single;
    //        //used to check checkbox value.if set to true than display related Section
    //        if (objDPD_FR.MVA_Single == true)
    //        {
    //            tdMVA_Single_Damage.Style.Add("display", "");
    //            revYear.Enabled = true;
    //            DataTable dtMVASingle = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "1");
    //            gvMVASingle.DataSource = dtMVASingle;
    //            gvMVASingle.DataBind();
    //        }
    //        #endregion

    //        #region Fill for MVA-Damage for Multiple Vehicle[Edit Mode]

    //        lstCauseOfLoss.Items[4].Selected = objDPD_FR.MVA_Multiple;
    //        //used to check checkbox value.if set to true than display related Section
    //        if (objDPD_FR.MVA_Multiple == true)
    //        {
    //            tdMVA_Multi_Damage.Style.Add("display", "");
    //            revMVA_MultiYear.Enabled = true;
    //            DataTable dtMultiDamage = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "2");
    //            gvMultiVehDamage.DataSource = dtMultiDamage;
    //            gvMultiVehDamage.DataBind();
    //        }
    //        #endregion

    //        #region Fill Hail [Edit Mode]
    //        lstCauseOfLoss.Items[3].Selected = objDPD_FR.Hail;
    //        //used to check checkbox value.if set to true than display related Section
    //        if (objDPD_FR.Hail == true)
    //        {
    //            tdHail.Style.Add("display", "");
    //            DataTable dtHail = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "7");
    //            gvHail.DataSource = dtHail;
    //            gvHail.DataBind();
    //        }
    //        #endregion

    //        #region Fill Flood [Edit Mode]
    //        lstCauseOfLoss.Items[1].Selected = objDPD_FR.Flood;
    //        //used to check checkbox value.if set to true than display related Section
    //        if (objDPD_FR.Flood == true)
    //        {
    //            tdFlood.Style.Add("display", "");
    //            DataTable dtFlood = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "8");
    //            gvFlood.DataSource = dtFlood;
    //            gvFlood.DataBind();
    //        }
    //        #endregion

    //        #region Fill Fire [Edit Mode]
    //        lstCauseOfLoss.Items[0].Selected = objDPD_FR.Fire;
    //        //used to check checkbox value.if set to true than display related Section
    //        if (objDPD_FR.Fire == true)
    //        {
    //            tdFire.Style.Add("display", "");
    //            DataTable dtFire = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "9");
    //            gvFire.DataSource = dtFire;
    //            gvFire.DataBind();
    //        }
    //        #endregion

    //        #region Fill Wind [Edit Mode]
    //        lstCauseOfLoss.Items[9].Selected = objDPD_FR.Wind;
    //        //used to check checkbox value.if set to true than display related Section
    //        if (objDPD_FR.Wind == true)
    //        {
    //            tdWind.Style.Add("display", "");
    //            DataTable dtWind = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "10");
    //            gvWind.DataSource = dtWind;
    //            gvWind.DataBind();
    //        }
    //        #endregion

    //        #region Fill Fraud
    //        lstCauseOfLoss.Items[2].Selected = objDPD_FR.Fraud;
    //        //used to check checkbox value.if set to true than display related Section
    //        if (objDPD_FR.Fraud == true)
    //        {
    //            tdFraud.Style.Add("display", "");
    //            revFraud_Year.Enabled = true;
    //            DataTable dtFraud = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "3");
    //            gvFraud.DataSource = dtFraud;
    //            gvFraud.DataBind();
    //        }
    //        #endregion

    //        string strCauseSelected = "";
    //        foreach (ListItem lst in lstCauseOfLoss.Items)
    //        {
    //            if (lst.Selected)
    //                strCauseSelected += lst.Value + ",";
    //        }
    //        strCauseSelected = strCauseSelected.TrimEnd(',');
    //        BindAttachmentTypes(strCauseSelected);

    //        #endregion
    #endregion

    #region Witness Grid Events
    protected void gvWitnesses_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void gvWitnesses_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //check Row Type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkRemove");
            //check null value
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);

            LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            //check Null value
            if (lnkbtnEdit != null)
                lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    protected void gvWitnesses_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }
    protected void gvWitnesses_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if it is "Remove" than remove the selected row
        if (e.CommandName == "Remove")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvWitnesses.DataKeys[Index].Values["PK_DPD_Witness_ID"] != null) ? Convert.ToInt32(gvWitnesses.DataKeys[Index].Values["PK_DPD_Witness_ID"]) : 0;
            //used to check PK id. if greater than 0 than delete record
            if (PK_ID > 0)
            {
                DPD_Witness.DeleteByPK(PK_ID);
            }
            ClearWitness_Controls();
            PK_DPD_Witness_ID = 0;
            //Bind Grid
            BindWitness();
        }
        else if (e.CommandName == "Edit")
        {
            ClearWitness_Controls();
            btnWitnessSave.Text = "Update";
            btnViewAuditWitness.Visible = true;

            int Index = Convert.ToInt32(e.CommandArgument);
            PK_DPD_Witness_ID = (gvWitnesses.DataKeys[Index].Values["PK_DPD_Witness_ID"] != null) ? Convert.ToInt32(gvWitnesses.DataKeys[Index].Values["PK_DPD_Witness_ID"]) : 0;
            //used to check PK id. if greater than 0 than display below fields else hide.
            if (PK_DPD_Witness_ID > 0)
            {
                btnViewAuditWitness.Attributes.Add("onClick", "return AuditWitnessPopUp(" + PK_DPD_Witness_ID + ");");
                DPD_Witness objWit = new DPD_Witness(PK_DPD_Witness_ID);
                txtWitness_Name.Text = objWit.Name;
                txtWitness_Address.Text = objWit.Address;
                txtWitness_Phone.Text = objWit.Phone;
            }
        }
    }
    #endregion



    #region Clear Witness Controls
    public void ClearWitness_Controls()
    {
        txtWitness_Phone.Text = "";
        txtWitness_Name.Text = "";
        txtWitness_Address.Text = "";
    }
    #endregion
    #endregion

    #region Comments and Attachments Panel Events
    /// <summary>
    /// Use to update or insert value as per Mode.
    /// </summary>
    /// <returns></returns>
    public int ComplateDDP_FRReport(bool _IsAttachment)
    {
        //used to check pae mode. if it is add than it add new record to related table
        //else if it is edit mode than it Update the current record. else display all data in view mode.
        if (strPageOpeMode == "edit")
        {
            if (_IsAttachment)
            {
                Upload_File("");
                CtrlAttachDetails.Bind();
                decimal FileSize = this.CtrlAttachDetails.GetTotalAttachmentsFileSize();
                if (FileSize > 9.5M)
                {
                    String confirmMessage = "The attachments to this First Report exceed the size limitations for e-mail. The First Report can be sent without the attachments or you can Cancel and remove or reduce the size of the exiting attachments. Do you want to send the First Report without the attachments?";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", " if(window.confirm('" + confirmMessage + "')){ __doPostBack('UserConfirmationPostBack', 'true');} else { alert('The First Report has NOT been sent, please reduce the number and/or size of the attachments before attempting to resubmit with attachments.');ShowPanel(4); }", true);
                    return 0;
                }
            }

            // Declare Object
            DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);

            if (objDPD_FR.Complete)
                return -1;

            //Assign Values
            objDPD_FR.Comments = txtComments.Text;
            objDPD_FR.Complete = true;
            //Update Values
            if (PK_DPD_FR_ID > 0)
            {
                objDPD_FR.Update();
            }
            SendFROI();
            //Insert values into DPD_FR_Attachment table

            if (SendFirstReportMail(_IsAttachment))
            {
                return 1;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "alert('Report Submitted successfully but due to technical problem Mail can not be send at this time, Please try to resend.'); window.location='FirstReportSearch.aspx';", true);
                return 0;
            }
            //return 1;
        }
        else
        {
            return 0;
        }


    }
    #endregion

    /// <summary>
    /// Handles Cause of loss selection change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lstCauseOfLoss_SelectedIndexChanged(object sender, EventArgs e)
    {
        tdVehicleDetails.Style["display"] = "";
        // show/hide the details according to the selection
        //tdtheft.Style["display"] = lstCauseOfLoss.Items[7].Selected ? "" : "none";
        //tdPartialTheft.Style["display"] = lstCauseOfLoss.Items[6].Selected ? "" : "none";
        //tdVandalism.Style["display"] = lstCauseOfLoss.Items[8].Selected ? "" : "none";
        //tdMVA_Single_Damage.Style["display"] = lstCauseOfLoss.Items[5].Selected ? "" : "none";
        //tdMVA_Multi_Damage.Style["display"] = lstCauseOfLoss.Items[4].Selected ? "" : "none";
        //tdHail.Style["display"] = lstCauseOfLoss.Items[3].Selected ? "" : "none";
        //tdFlood.Style["display"] = lstCauseOfLoss.Items[1].Selected ? "" : "none";
        //tdFire.Style["display"] = lstCauseOfLoss.Items[0].Selected ? "" : "none";
        //tdWind.Style["display"] = lstCauseOfLoss.Items[9].Selected ? "" : "none";


        if (lstCauseOfLoss.Items[4].Selected && lstCauseOfLoss.Items[5].Selected)
        {
            trVehicleOwner3.Style["display"] = trVehicleOwner2.Style["display"] = trVehicleOwner1.Style["display"] = trRecoveredAmount.Style["display"] = trDealership.Style["display"] = trOtherPassengers.Style["display"] = trVehicleDrivenByCompanyAssoc.Style["display"] = trDamageEstimate.Style["display"] = "";
            lblName1.Text = "MVA – Damage (Multiple Vehicle) ";
            lblName3.Text = "MVA – Damage (Multiple Vehicle),MVA – Damage (Single Vehicle) ";
            rfvMVA_MultiDriven_By_Associate.Enabled = true;
            rfvMVA_MultiAdditional_passengers.Enabled = true;
            rfvMVA_MultiSeeking_subrogation.Enabled = true;
        }
        //MVA_Single_Damage
        else if (lstCauseOfLoss.Items[5].Selected)
        {
            trRecoveredAmount.Style["display"] = trDealership.Style["display"] = trOtherPassengers.Style["display"] = trVehicleDrivenByCompanyAssoc.Style["display"] = trDamageEstimate.Style["display"] = "";
            trVehicleOwner3.Style["display"] = trVehicleOwner2.Style["display"] = trVehicleOwner1.Style["display"] = "none";
            lblName3.Text = "MVA – Damage (Single Vehicle) ";
            lblName1.Text = "";
            rfvMVA_MultiDriven_By_Associate.Enabled = true;
            rfvMVA_MultiAdditional_passengers.Enabled = true;
            rfvMVA_MultiSeeking_subrogation.Enabled = true;
        }
        //MVA_Multi_Damage
        else if (lstCauseOfLoss.Items[4].Selected)
        {
            trVehicleOwner3.Style["display"] = trVehicleOwner2.Style["display"] = trVehicleOwner1.Style["display"] = trRecoveredAmount.Style["display"] = trDealership.Style["display"] = trOtherPassengers.Style["display"] = trVehicleDrivenByCompanyAssoc.Style["display"] = trDamageEstimate.Style["display"] = "";
            lblName1.Text = "MVA – Damage (Multiple Vehicle) ";
            lblName3.Text = "";
            rfvMVA_MultiDriven_By_Associate.Enabled = true;
            rfvMVA_MultiAdditional_passengers.Enabled = true;
            rfvMVA_MultiSeeking_subrogation.Enabled = true;
        }
        else
        {
            trVehicleOwner3.Style["display"] = trVehicleOwner2.Style["display"] = trVehicleOwner1.Style["display"] = trRecoveredAmount.Style["display"] = trDealership.Style["display"] = trOtherPassengers.Style["display"] = trVehicleDrivenByCompanyAssoc.Style["display"] = trDamageEstimate.Style["display"] = "none";
            lblName3.Text = "";
            lblName1.Text = "";
            rfvMVA_MultiDriven_By_Associate.Enabled = false;
            rfvMVA_MultiAdditional_passengers.Enabled = false;
            rfvMVA_MultiSeeking_subrogation.Enabled = false;
        }



        if (lstCauseOfLoss.Items[7].Selected && lstCauseOfLoss.Items[2].Selected)
        {
            trWerePolicyNotified.Style["display"] = trVehicleInStorage.Style["display"] = trVehicleRecovered.Style["display"] = "";
            rfv_Vehicle_Recovered.Enabled = true;
            rfv_Dealership_Wish_To_Take_Possession.Enabled = false;
            rfvVehicle_In_Storage.Enabled = true;
            rfvPoliceNotified.Enabled = true;
            lblName2.Text = "Fruad,Theft";
            lblName4.Text = "Fruad";
        }
        else if (lstCauseOfLoss.Items[2].Selected)
        {
            trWerePolicyNotified.Style["display"] = trVehicleInStorage.Style["display"] = trVehicleRecovered.Style["display"] = "";
            rfv_Vehicle_Recovered.Enabled = true;
            rfv_Dealership_Wish_To_Take_Possession.Enabled = false;
            rfvVehicle_In_Storage.Enabled = true;
            rfvPoliceNotified.Enabled = true;
            lblName2.Text = "Fruad";
            lblName4.Text = "";
        }
        else if (lstCauseOfLoss.Items[7].Selected)
        {
            trVehicleInStorage.Style["display"] = trVehicleRecovered.Style["display"] = "";
            trWerePolicyNotified.Style["display"] = "none";
            rfv_Vehicle_Recovered.Enabled = true;
            rfv_Dealership_Wish_To_Take_Possession.Enabled = false;
            rfvVehicle_In_Storage.Enabled = true;
            rfvPoliceNotified.Enabled = false;
            lblName5.Text = "Theft";
            lblName4.Text = "";
        }
        else
        {
            trWerePolicyNotified.Style["display"] = trVehicleInStorage.Style["display"] = trVehicleRecovered.Style["display"] = "none";
            rfv_Vehicle_Recovered.Enabled = false;
            rfv_Dealership_Wish_To_Take_Possession.Enabled = false;
            rfvVehicle_In_Storage.Enabled = false;
            rfvPoliceNotified.Enabled = false;
            lblName2.Text = "";
            lblName4.Text = "";
        }

        // Theft or Partial Theft or Vandalism
        if (lstCauseOfLoss.Items[8].Selected || lstCauseOfLoss.Items[6].Selected || lstCauseOfLoss.Items[7].Selected)
        {
            trSecurityVideo.Style["display"] = "";
            rfvTheft_Security_Video_Surveillance.Enabled = true;
            if (lstCauseOfLoss.Items[8].Selected && lstCauseOfLoss.Items[6].Selected && lstCauseOfLoss.Items[7].Selected)
                lblName5.Text = "Theft,Partial Theft,Vandalism";
            else if (lstCauseOfLoss.Items[8].Selected && lstCauseOfLoss.Items[6].Selected)
                lblName5.Text = "Partial Theft,Vandalism";
            else if (lstCauseOfLoss.Items[7].Selected && lstCauseOfLoss.Items[8].Selected)
                lblName5.Text = "Theft,Vandalism";
            else if (lstCauseOfLoss.Items[6].Selected && lstCauseOfLoss.Items[7].Selected)
                lblName5.Text = "Theft,Partial Theft";
            else if (lstCauseOfLoss.Items[6].Selected)
                lblName5.Text = "Partial Theft";
            else if (lstCauseOfLoss.Items[8].Selected)
                lblName5.Text = "Vandalism";
            //else
            //    lblName5.Text = "Theft";

        }
        else
        {
            trSecurityVideo.Style["display"] = "none";
            rfvTheft_Security_Video_Surveillance.Enabled = false;
            lblName5.Text = "";
        }

        //var bAddedTheft, bAddedPartialTheft, bAddedVandalism, bAddedMVA_single, bAddedMVA_Multi, bAddedHail, bAddedFood, bAddedFire, bAddedWind, bAddedFraud;

        // get JS functions list to be called for each selection
        string strJSFunc = "";
        //strJSFunc = strJSFunc + (lstCauseOfLoss.Items[7].Selected ? "TheftCheck(true);" : "bAddedTheft = undefined;");
        //strJSFunc = strJSFunc + (lstCauseOfLoss.Items[6].Selected ? "PartialTheftCheck(true);" : "bAddedPartialTheft = undefined;");
        //strJSFunc = strJSFunc + (lstCauseOfLoss.Items[8].Selected ? "VandalismCheck(true);" : "bAddedVandalism = undefined;");
        //strJSFunc = strJSFunc + (lstCauseOfLoss.Items[5].Selected ? "MVASingleCheck(true);" : "bAddedMVA_single = undefined;");
        //strJSFunc = strJSFunc + (lstCauseOfLoss.Items[4].Selected ? "MVAMultiCheck(true);" : "bAddedMVA_Multi = undefined;");
        //strJSFunc = strJSFunc + (lstCauseOfLoss.Items[3].Selected ? "HailCheck(true);" : "bAddedHail = undefined;");
        //strJSFunc = strJSFunc + (lstCauseOfLoss.Items[1].Selected ? "FloodCheck(true);" : "bAddedFood = undefined;");
        //strJSFunc = strJSFunc + (lstCauseOfLoss.Items[0].Selected ? "FireCheck(true);" : "bAddedFire = undefined;");
        //strJSFunc = strJSFunc + (lstCauseOfLoss.Items[9].Selected ? "WindCheck(true);" : "bAddedWind = undefined;");
        //strJSFunc = strJSFunc + (lstCauseOfLoss.Items[2].Selected ? "FraudCheck(true);" : "bAddedFraud = undefined;");

        // bind attachment type dropdown
        string strCauseSelected = "";
        //if (!IsPostBack)
        //    strCauseSelected = Convert.ToString(lstCauseOfLoss.SelectedValue);
        //else
        //DataTable dtVehicle = DPD_FR_Vehicle.SelectByIncidentType(0, "");
        //foreach (int i in lstCauseOfLoss.GetSelectedIndices())
        //{
        //    switch (lstCauseOfLoss.Items[i].Value)
        //    {
        //        //Theft
        //        case "1":
        //            dtVehicle.Merge(DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "4"));
        //            break;

        //        //Partial Theft
        //        case "2":
        //            dtVehicle.Merge(DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "5"));
        //            break;

        //        //Vandalism
        //        case "3":
        //            dtVehicle.Merge(DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "6"));
        //            break;

        //        //MVA – Damage (Single Vehicle)
        //        case "4":
        //            dtVehicle.Merge(DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "1"));
        //            break;

        //        //MVA – Damage (Multiple Vehicle)
        //        case "5":
        //            dtVehicle.Merge(DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "2"));
        //            break;

        //        //Hail
        //        case "6":
        //            dtVehicle.Merge(DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "7"));
        //            break;

        //        //Flood
        //        case "7":
        //            dtVehicle.Merge(DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "8"));
        //            break;

        //        //Fire
        //        case "8":
        //            dtVehicle.Merge(DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "9"));
        //            break;

        //        //Wind
        //        case "9":
        //            dtVehicle.Merge(DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "10"));
        //            break;

        //        //Fraud
        //        case "10":
        //            dtVehicle.Merge(DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "3"));
        //            break;
        //    }
        //}
        //gvVehicleDetails.DataSource = dtVehicle;
        //gvVehicleDetails.DataBind();

        if (lstCauseOfLoss.GetSelectedIndices().Length == 1)
        {
            lblBase.Text = lstCauseOfLoss.Items[lstCauseOfLoss.GetSelectedIndices()[0]].Text;
        }
        else
        {
            lblBase.Text = "Base Information";
        }

        strCauseSelected = Convert.ToString(Request.Form["ctl00$ContentPlaceHolder1$lstCauseOfLoss"]);
        BindAttachmentTypes(strCauseSelected);
        //btnLossSave.Enabled = false;
        ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "ShowPanel(2);" + strJSFunc + "SetLossSaveButton();", true);
        //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "ShowPanel(2);" + strJSFunc, true);
        //ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedVehicle = false;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);

    }

    #endregion

    #region Bind Page in View Mode

    /// <summary>
    /// Method to bind Page Controls in View Mode
    /// </summary>
    public void BindPageInViewMode()
    {
        if (First_Report_Wizard_ID > 0)
        {
            //Hide Message of "This Report Has not been submitted"
            lblSubmitMessage.Text = "";
            //Declare Object of DPD_FR table
            DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);

            DataSet dsFPWView = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.DPD_FR, PK_DPD_FR_ID);
            DataTable dtFPWView = dsFPWView.Tables[0];
            DataRow drFPWView = dtFPWView.Rows[0];

            #region Fill Location Information Controls

            //Display Location NUmber
            if (drFPWView["Sonic_Location_Code"] != null)
                lblLocationNumber.Text = drFPWView["Sonic_Location_Code"].ToString();
            else
                lblLocationNumber.Text = "";
            //Display dba Value
            if (drFPWView["dba"] != null)
                lblLocationdba.Text = drFPWView["dba"].ToString();
            else
                lblLocationdba.Text = "";
            //Display F/K/A value
            if (drFPWView["FK_Location_ID"] != null)
                lblLocationfka.Text = new LU_Location_FKA(Convert.ToDecimal(drFPWView["FK_Location_ID"])).fka;
            //Display Legal Entity Value
            //if (drFPWView["legal_entity"] != null)
            //    lblLegalEntity.Text = drFPWView["legal_entity"].ToString();
            //else
            //    lblLegalEntity.Text = "";

            //set address1,address2,city,state,ZipCOde Values
            lblLocationAddress1.Text = (drFPWView["Address_1"] != null) ? Convert.ToString(drFPWView["Address_1"]) : "";
            lblLocationAddress2.Text = (drFPWView["Address_2"] != null) ? Convert.ToString(drFPWView["Address_2"]) : "";
            lblLocationCity.Text = (drFPWView["City"] != null) ? Convert.ToString(drFPWView["City"]) : "";
            lblLocationState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFPWView["State"])) ? Convert.ToDecimal(drFPWView["State"]) : 0).FLD_state;
            lblLocationZipCode.Text = (drFPWView["Zip_Code"] != null) ? Convert.ToString(drFPWView["Zip_Code"]) : "";

            #endregion

            #region Fill Contact Information Controls
            lbldba.Text = (drFPWView["dba"] != null) ? Convert.ToString(drFPWView["dba"]) : "";
            lblContactName.Text = (drFPWView["EmployeeName"] != null) ? Convert.ToString(drFPWView["EmployeeName"]) : "";
            lblContact_Best_Time.Text = (drFPWView["Contact_Best_Time"] != null) ? Convert.ToString(drFPWView["Contact_Best_Time"]) : "";
            lblAddress_1.Text = (drFPWView["Address_1"] != null) ? Convert.ToString(drFPWView["Address_1"]) : "";
            lblAddress_2.Text = (drFPWView["Address_2"] != null) ? Convert.ToString(drFPWView["Address_2"]) : "";
            lblWork_Phone.Text = (drFPWView["TelephoneNumber1"] != null) ? Convert.ToString(drFPWView["TelephoneNumber1"]) : "";
            lblEmployee_Cell_Phone.Text = (drFPWView["TelephoneNumber2"] != null) ? Convert.ToString(drFPWView["TelephoneNumber2"]) : "";
            lblCity.Text = (drFPWView["City"] != null) ? Convert.ToString(drFPWView["City"]) : "";
            lblZip_Code.Text = (drFPWView["Zip_Code"] != null) ? Convert.ToString(drFPWView["Zip_Code"]) : "";
            lblState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFPWView["State"])) ? Convert.ToDecimal(drFPWView["State"]) : 0).FLD_state;
            lblEmployee_Fax.Text = (drFPWView["Contact_Fax"] != null) ? Convert.ToString(drFPWView["Contact_Fax"]) : "";
            lblEmail.Text = (drFPWView["FRWEmail"] != null) ? Convert.ToString(drFPWView["FRWEmail"]) : "";
            #endregion

            #region Fill Loss Location information id Different Section
            lblLoss_Address_1.Text = objDPD_FR.Loss_Address_1;
            lblLoss_Address_2.Text = objDPD_FR.Loss_Address_2;
            lblOn_Company_Property.Text = (objDPD_FR.On_Company_Property == true) ? "Yes" : "No";
            lblDate_Of_Loss.Text = clsGeneral.FormatDateToDisplay(objDPD_FR.Date_Of_Loss);
            lblTime_of_Loss.Text = objDPD_FR.Time_of_Loss;
            lblLoss_City.Text = objDPD_FR.Loss_City;
            lblLoss_State.Text = new State(string.IsNullOrEmpty(objDPD_FR.Loss_State) ? 0 : Convert.ToDecimal(objDPD_FR.Loss_State)).FLD_state;
            lblLoss_ZipCode.Text = objDPD_FR.Loss_ZipCode;
            lblDate_Reported_To_Sonic.Text = clsGeneral.FormatDateToDisplay(objDPD_FR.Date_Reported_To_Sonic);
            #endregion

            #region Fill Loss Information Controls [View Mode]

            #region Theft Section [View Mode]
            lblLossDate_Of_Loss.Text = clsGeneral.FormatDateToDisplay(objDPD_FR.Date_Of_Loss);
            chkViewtheft.Checked = objDPD_FR.Theft;
            //Check Theft section if it is true display below fields else hide.
            if (objDPD_FR.Theft == true)
            {
                tdViewTheft.Style.Add("display", "");
                DataTable dtViewTheft = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "4");
                gvViewTheft.DataSource = dtViewTheft;
                gvViewTheft.DataBind();
            }
            #endregion

            #region Partial Theft Section [View Mode]
            chkViewPartialTheft.Checked = objDPD_FR.Partial_Theft;
            //used to check Partial Theft Value
            if (objDPD_FR.Partial_Theft == true)
            {
                tdViewPartialTheft.Style.Add("display", "");
                DataTable dtViewPartialTheft = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "5");
                gvViewPartialTheft.DataSource = dtViewPartialTheft;
                gvViewPartialTheft.DataBind();
            }
            #endregion

            #region Udpate Vandalism [View Mode]
            chkViewVandalism.Checked = objDPD_FR.Vandalism;
            //used to check Vandalism value
            if (objDPD_FR.Vandalism == true)
            {
                tdViewVandalism.Style.Add("display", "");
                DataTable dtViewVandalism = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "6");
                gvViewVandalism.DataSource = dtViewVandalism;
                gvViewVandalism.DataBind();
            }
            #endregion

            #region Insert/Update Value into DPD Vehicle Table for MVA-Damage for Single Vehicle [View Mode]
            chkViewMVA_Single_Damage.Checked = objDPD_FR.MVA_Single;
            //used to check MVA_Single if it is true than display below fields else hide
            if (objDPD_FR.MVA_Single == true)
            {
                tdViewMVA_Single_Damage.Style.Add("display", "");
                DataTable dtSingleDamage = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "1");
                gvViewSingleVehDamage.DataSource = dtSingleDamage;
                gvViewSingleVehDamage.DataBind();
            }
            #endregion

            #region Insert/Update Value into DPD Vehicle Table for MVA-Damage for Multiple Vehicle[View Mode]
            chkViewMVA_Multi_Damage.Checked = objDPD_FR.MVA_Multiple;
            //check MVA Multi values if it is true than display below fields.
            if (objDPD_FR.MVA_Multiple == true)
            {
                tdViewMVA_Multi_Damage.Style.Add("display", "");
                DataTable dtMultiDamage = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "2");
                gvViewMultiVehDamage.DataSource = dtMultiDamage;
                gvViewMultiVehDamage.DataBind();
            }
            #endregion

            #region Update Hail [View Mode]
            chkViewHail.Checked = objDPD_FR.Hail;
            //used to check Hail values it it true than display below fields
            if (objDPD_FR.Hail == true)
            {
                tdViewHail.Style.Add("display", "");
                DataTable dtViewHail = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "7");
                gvViewHail.DataSource = dtViewHail;
                gvViewHail.DataBind();
            }
            #endregion

            #region Update Flood [View Mode]
            chkViewFlood.Checked = objDPD_FR.Flood;
            //used to check Flood value if it true than display below fields
            if (objDPD_FR.Flood == true)
            {
                tdViewFlood.Style.Add("display", "");
                DataTable dtViewFlood = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "8");
                gvViewFlood.DataSource = dtViewFlood;
                gvViewFlood.DataBind();
            }
            #endregion

            #region Update Fire [View Mode]
            chkViewFire.Checked = objDPD_FR.Fire;
            //used to check Fire value if it true than display beloew fields
            if (objDPD_FR.Fire == true)
            {
                tdViewFire.Style.Add("display", "");
                DataTable dtViewFire = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "9");
                gvViewFire.DataSource = dtViewFire;
                gvViewFire.DataBind();
            }
            #endregion

            #region Update Wind [View Mode]
            chkViewWind.Checked = objDPD_FR.Wind;
            //used to check Wind vlaue. if it is set to true than display below fields
            if (objDPD_FR.Wind == true)
            {
                tdViewWind.Style.Add("display", "");
                DataTable dtViewWind = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "10");
                gvViewWind.DataSource = dtViewWind;
                gvViewWind.DataBind();
            }
            #endregion

            #region Insert/Update values into DPD Vehicle Table for Fraud
            chkViewFraud.Checked = objDPD_FR.Fraud;
            //used to check Fraud value. if it is true than display below fields
            if (objDPD_FR.Fraud == true)
            {
                tdViewFraud.Style.Add("display", "");
                DataTable dtFraud = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "3");
                gvViewFraud.DataSource = dtFraud;
                gvViewFraud.DataBind();
            }
            #endregion
            #endregion

            #region Fill Witness Information Controls [View Mode]
            DataTable dtWitness = DPD_Witness.SelectByFK(PK_DPD_FR_ID).Tables[0];
            gvWitnessesView.DataSource = dtWitness;
            gvWitnessesView.DataBind();
            #endregion

            #region Fill Comments and Attachments[View Mode]
            lblComments.Text = objDPD_FR.Comments;
            CtrlViewAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.DPD_FR, PK_DPD_FR_ID, false, 4);
            CtrlViewAttachDetails.Bind();
            #endregion
        }
        else
        {
            Response.Redirect("FirstReportSearch.aspx", true);
        }

    }

    #region Multi Vehicle Grid View Event[View MOde]

    /// <summary>
    /// Grid View Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvViewMultiVehDamage_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if View than display page for View.
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            btnViewAuditMulti_View.Visible = true;
            int PK_ID = (gvViewMultiVehDamage.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvViewMultiVehDamage.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
            //check PK_ID if it is greater than 0 than display below fields else hide below fields
            if (PK_ID > 0)
            {
                btnViewAuditMulti_View.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_ID + ");");
                DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_ID);
                tdViewMultivehicleData.Style.Add("display", "");
                lblViewMVA_MultiMake.Text = string.IsNullOrEmpty(objDFV.Make) ? "" : objDFV.Make.ToString();
                lblViewMVA_MultiModel.Text = string.IsNullOrEmpty(objDFV.Model) ? "" : objDFV.Model.ToString();
                lblViewMVA_MultiYear.Text = (objDFV.Year.ToString() == "0") ? "" : objDFV.Year.ToString();
                lblViewMVA_MultiVIN.Text = string.IsNullOrEmpty(objDFV.VIN) ? "" : objDFV.VIN.ToString();
                lblViewMVA_MultiVehicle_Owner_Sonic.Text = string.IsNullOrEmpty(objDFV.Vehicle_Owner_Sonic) ? "" : objDFV.Vehicle_Owner_Sonic.ToString();
                lblViewMVA_MultiVehicle_Owner_Address.Text = string.IsNullOrEmpty(objDFV.Vehicle_Owner_Address) ? "" : objDFV.Vehicle_Owner_Address.ToString();
                lblViewMVA_MultiVehicle_Owner_Phone.Text = string.IsNullOrEmpty(objDFV.Vehicle_Owner_Phone) ? "" : objDFV.Vehicle_Owner_Phone.ToString();
                lblMVA_Multi_TypeOfVehicle.Text = string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString();
                lblMVA_Multi_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
                lblMVA_Multi_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
                lblMVA_Multi_Present_State.Text = new State(string.IsNullOrEmpty(objDFV.Present_State) ? 0 : Convert.ToDecimal(objDFV.Present_State)).FLD_state;
                lblMVA_Multi_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
                lblViewMVA_MultiInvoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);
                lblViewMVAMultiLoss_description.Text = objDFV.Loss_Description;
                lblViewMVA_MultiDamage_Estimate.Text = clsGeneral.GetStringValue(objDFV.Damage_Estimate);
                if (objDFV.Driven_By_Associate != null)
                {
                    if (objDFV.Driven_By_Associate == true)
                    {
                        trViewMVAMulti_DrivenByCA_Yes.Style.Add("display", "");
                        lblViewMVA_MultiDriven_By_Associate.Text = "Yes";
                        lblViewMVA_MultiName_Yes.Text = string.IsNullOrEmpty(objDFV.Name) ? "" : objDFV.Name;
                        lblViewMVA_MultiAddress_Yes.Text = string.IsNullOrEmpty(objDFV.Address) ? "" : objDFV.Address;
                        lblViewMVA_MultiPhone_Yes.Text = string.IsNullOrEmpty(objDFV.Phone) ? "" : objDFV.Phone;
                        if (objDFV.Associate_Cited != null)
                        {
                            if (objDFV.Associate_Cited == true)
                            {
                                trViewMVA_MultiCitation_Yes.Style.Add("display", "");
                                lblViewMVA_MultiAssociate_Cited.Text = "Yes";
                                lblViewMVA_MultiDescription_Of_Citation.Text = string.IsNullOrEmpty(objDFV.Description_Of_Citation) ? "" : objDFV.Description_Of_Citation.ToString();
                            }
                            else
                            {
                                lblViewMVA_MultiAssociate_Cited.Text = "No";
                            }
                        }
                        if (objDFV.Associate_injured != null)
                        {
                            if (objDFV.Associate_injured == true)
                                lblViewMVA_MultiAssociate_injured.Text = "Yes";
                            else
                                lblViewMVA_MultiAssociate_injured.Text = "No";
                        }

                        if (objDFV.drug_test_performed != null)
                        {
                            if (objDFV.drug_test_performed == true)
                            {
                                lblViewMVA_MultiDrug_test_performed.Text = "Yes";
                                trViewMVA_MultiDrugYes.Style.Add("display", "");
                                lblViewMVA_MultiDrug_test_results.Text = string.IsNullOrEmpty(objDFV.drug_test_results) ? "" : objDFV.drug_test_results.ToString();
                            }
                            else
                            {
                                lblViewMVA_MultiDrug_test_performed.Text = "No";
                                trViewMVA_MultiDrugNo.Style.Add("display", "");
                                lblViewMVA_MultiDrug_test_explanation.Text = string.IsNullOrEmpty(objDFV.drug_test_explanation) ? "" : objDFV.drug_test_explanation.ToString();
                            }
                        }


                    }
                    else
                    {
                        trViewMVAMulti_DrivenByCA_No.Style.Add("display", "");
                        lblViewMVA_MultiDriven_By_Associate.Text = "No";
                        if (objDFV.Vehicle_Driven_By_Customer != null)
                        {
                            if (objDFV.Vehicle_Driven_By_Customer == true)
                            {
                                lblViewMVA_MultiVehicle_Driven_By_Customer.Text = "Yes";
                                lblViewMVA_MultiName_No.Text = string.IsNullOrEmpty(objDFV.Name) ? "" : objDFV.Name;
                                lblViewMVA_MultiAddress_No.Text = string.IsNullOrEmpty(objDFV.Address) ? "" : objDFV.Address;
                                lblViewMVA_MultiPhone_No.Text = string.IsNullOrEmpty(objDFV.Phone) ? "" : objDFV.Phone;
                                trViewMVA_MultiCust_Injured.Style.Add("display", "");
                                trViewMVA_MultiCust_Not_Injured.Style.Add("display", "none");
                                if (objDFV.Cutomer_Injured != null)
                                {
                                    if (objDFV.Cutomer_Injured == true)
                                    {
                                        lblViewMVA_Multicustomer_injured.Text = "Yes";
                                    }
                                    else
                                    {
                                        lblViewMVA_Multicustomer_injured.Text = "No";
                                    }
                                }
                            }
                            else
                            {
                                lblViewMVA_MultiVehicle_Driven_By_Customer.Text = "No";
                                lblViewMVA_MultiNot_Driven_By_Customer_Explain.Text = objDFV.Not_Driven_By_Customer_Explain;
                                trViewMVA_MultiCust_Not_Injured.Style.Add("display", "");
                                trViewMVA_MultiCust_Injured.Style.Add("display", "none");
                            }
                        }
                    }
                }
                gvViewMVAMulti_Passenger.DataSource = null;
                gvViewMVAMulti_Passenger.DataBind();
                if (objDFV.Additional_passengers != null)
                {
                    if (objDFV.Additional_passengers == true)
                    {
                        trViewMVA_MultiAdditional_passengers_Yes.Style.Add("display", "");
                        lblViewMVA_MultiAdditional_passengers.Text = "Yes";
                        BindPassengerGrid(gvViewMVAMulti_Passenger, PK_ID);
                    }
                    else
                    {
                        trViewMVA_MultiAdditional_passengers_Yes.Style.Add("display", "none");
                        lblViewMVA_MultiAdditional_passengers.Text = "No";
                    }
                }
                if (objDFV.seeking_subrogation != null)
                {
                    if (objDFV.seeking_subrogation == true)
                    {
                        trViewMVA_MultiSeeking_subrogation_Yes.Style.Add("display", "");
                        lblViewMVA_MultiSeeking_subrogation.Text = "Yes";
                        lblViewMVA_MultiTPI_Carrier_name.Text = objDFV.TPI_Carrier_name;
                        lblViewMVA_Multitpi_contact.Text = objDFV.tpi_contact;
                        lblViewMVA_MultiTPI_Policy_number.Text = objDFV.TPI_Policy_number;
                        lblViewMVA_Multitpi_phone.Text = objDFV.tpi_phone;
                        lblViewMVA_Multitpi_address_1.Text = objDFV.tpi_Address_1;
                        lblViewMVA_Multitpi_address_2.Text = objDFV.tpi_Address_2;
                        lblViewMVA_Multitpi_City.Text = objDFV.tpi_City;
                        lblViewMVA_Multitpi_State.Text = new State(string.IsNullOrEmpty(objDFV.tpi_State) ? 0 : Convert.ToDecimal(objDFV.tpi_State)).FLD_state;
                        lblViewMVA_Multitpi_Zip_Code.Text = objDFV.tpi_Zip_Code;
                        lblViewMVA_MultiRecovered_Amount.Text = clsGeneral.GetStringValue(objDFV.recovered_amount);
                    }
                    else
                    {
                        trViewMVA_MultiSeeking_subrogation_No.Style.Add("display", "");
                        lblViewMVA_MultiSeeking_subrogation.Text = "No";
                        if (objDFV.Notice_only_claim != null)
                        {
                            if (objDFV.Notice_only_claim == true)
                                lblViewMVA_MultiNotice_only_claim.Text = "Yes";
                            else
                                lblViewMVA_MultiNotice_only_claim.Text = "No";
                        }
                        lblViewMVA_MultiRecovered_Amount.Text = clsGeneral.GetStringValue(objDFV.recovered_amount);
                    }

                }
            }
        }
    }

    /// <summary>
    /// Grid View Row Command Event - Vehicle Damage
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvViewMultiVehDamage_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //used to check Row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkViewMultiVeh");
            //check link button is null or not.
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    #endregion

    #region Single Vehicle Grid View Event[View MOde]

    /// <summary>
    /// Grid View Row Command Event - Single Vehicle Danage
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvViewSingleVehDamage_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if View than display page for View.
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            btnViewAuditSingle_View.Visible = true;
            int PK_ID = (gvViewSingleVehDamage.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvViewSingleVehDamage.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
            //check PK_ID if it is greater than 0 than display below fields else hide below fields
            if (PK_ID > 0)
            {
                btnViewAuditSingle_View.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_ID + ");");
                DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_ID);
                tdViewSinglevehicleData.Style.Add("display", "");
                lblViewMVA_SingleMake.Text = string.IsNullOrEmpty(objDFV.Make) ? "" : objDFV.Make.ToString();
                lblViewMVA_SingleModel.Text = string.IsNullOrEmpty(objDFV.Model) ? "" : objDFV.Model.ToString();
                lblViewMVA_SingleYear.Text = (objDFV.Year.ToString() == "0") ? "" : objDFV.Year.ToString();
                lblViewMVA_SingleVIN.Text = string.IsNullOrEmpty(objDFV.VIN) ? "" : objDFV.VIN.ToString();
                lblMVA_Single_TypeOfVehicle.Text = string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString();
                lblMVA_Single_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
                lblMVA_Single_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
                lblMVA_Single_Present_State.Text = new State(string.IsNullOrEmpty(objDFV.Present_State) ? 0 : Convert.ToDecimal(objDFV.Present_State)).FLD_state;
                lblMVA_Single_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
                lblViewMVA_SingleInvoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);
                lblViewMVASingleLoss_description.Text = objDFV.Loss_Description;
                lblViewMVA_SingleDamage_Estimate.Text = clsGeneral.GetStringValue(objDFV.Damage_Estimate);
                if (objDFV.Driven_By_Associate != null)
                {
                    if (objDFV.Driven_By_Associate == true)
                    {
                        trViewMVASingle_DrivenByCA_Yes.Style.Add("display", "");
                        lblViewMVA_SingleDriven_By_Associate.Text = "Yes";
                        lblViewMVA_SingleName_Yes.Text = string.IsNullOrEmpty(objDFV.Name) ? "" : objDFV.Name;
                        lblViewMVA_SingleAddress_Yes.Text = string.IsNullOrEmpty(objDFV.Address) ? "" : objDFV.Address;
                        lblViewMVA_SinglePhone_Yes.Text = string.IsNullOrEmpty(objDFV.Phone) ? "" : objDFV.Phone;
                        if (objDFV.Associate_Cited != null)
                        {
                            if (objDFV.Associate_Cited == true)
                            {
                                trViewMVA_SingleCitation_Yes.Style.Add("display", "");
                                lblViewMVA_SingleAssociate_Cited.Text = "Yes";
                                lblViewMVA_SingleDescription_Of_Citation.Text = string.IsNullOrEmpty(objDFV.Description_Of_Citation) ? "" : objDFV.Description_Of_Citation.ToString();
                            }
                            else
                            {
                                lblViewMVA_SingleAssociate_Cited.Text = "No";
                            }
                        }
                        if (objDFV.Associate_injured != null)
                        {
                            if (objDFV.Associate_injured == true)
                                lblViewMVA_SingleAssociate_injured.Text = "Yes";
                            else
                                lblViewMVA_SingleAssociate_injured.Text = "No";
                        }

                        if (objDFV.drug_test_performed != null)
                        {
                            if (objDFV.drug_test_performed == true)
                            {
                                lblViewMVA_SingleDrug_test_performed.Text = "Yes";
                                trViewMVA_SingleDrugYes.Style.Add("display", "");
                                lblViewMVA_SingleDrug_test_results.Text = string.IsNullOrEmpty(objDFV.drug_test_results) ? "" : objDFV.drug_test_results.ToString();
                            }
                            else
                            {
                                lblViewMVA_SingleDrug_test_performed.Text = "No";
                                trViewMVA_SingleDrugNo.Style.Add("display", "");
                                lblViewMVA_SingleDrug_test_explanation.Text = string.IsNullOrEmpty(objDFV.drug_test_explanation) ? "" : objDFV.drug_test_explanation.ToString();
                            }
                        }


                    }
                    else
                    {
                        trViewMVASingle_DrivenByCA_No.Style.Add("display", "");
                        lblViewMVA_SingleDriven_By_Associate.Text = "No";
                        if (objDFV.Vehicle_Driven_By_Customer != null)
                        {
                            if (objDFV.Vehicle_Driven_By_Customer == true)
                            {
                                lblViewMVA_SingleName_No.Text = string.IsNullOrEmpty(objDFV.Name) ? "" : objDFV.Name;
                                lblViewMVA_SingleAddress_No.Text = string.IsNullOrEmpty(objDFV.Address) ? "" : objDFV.Address;
                                lblViewMVA_SinglePhone_No.Text = string.IsNullOrEmpty(objDFV.Phone) ? "" : objDFV.Phone;
                                lblViewMVA_SingleVehicle_Driven_By_Customer.Text = "Yes";
                                trViewMVA_SingleCust_Injured.Style.Add("display", "");
                                trViewMVA_SingleCust_Not_Injured.Style.Add("display", "none");
                                if (objDFV.Cutomer_Injured != null)
                                {
                                    if (objDFV.Cutomer_Injured == true)
                                    {
                                        lblViewMVA_Singlecustomer_injured.Text = "Yes";
                                    }
                                    else
                                    {
                                        lblViewMVA_Singlecustomer_injured.Text = "No";
                                    }
                                }
                            }
                            else
                            {
                                lblViewMVA_SingleNot_Driven_By_Customer_Explain.Text = objDFV.Not_Driven_By_Customer_Explain;
                                trViewMVA_SingleCust_Not_Injured.Style.Add("display", "");
                                lblViewMVA_SingleVehicle_Driven_By_Customer.Text = "No";
                                trViewMVA_SingleCust_Injured.Style.Add("display", "none");
                            }
                        }
                    }
                }
                gvViewMVASingle_Passenger.DataSource = null;
                gvViewMVASingle_Passenger.DataBind();
                if (objDFV.Additional_passengers != null)
                {
                    if (objDFV.Additional_passengers == true)
                    {
                        trViewMVA_SingleAdditional_passengers_Yes.Style.Add("display", "");
                        lblViewMVA_SingleAdditional_passengers.Text = "Yes";
                        BindPassengerGrid(gvViewMVASingle_Passenger, PK_ID);
                    }
                    else
                    {
                        trViewMVA_SingleAdditional_passengers_Yes.Style.Add("display", "none");
                        lblViewMVA_SingleAdditional_passengers.Text = "No";
                    }
                }
                if (objDFV.seeking_subrogation != null)
                {
                    if (objDFV.seeking_subrogation == true)
                    {
                        trViewMVA_SingleSeeking_subrogation_Yes.Style.Add("display", "");
                        lblViewMVA_SingleSeeking_subrogation.Text = "Yes";
                        lblViewMVA_SingleTPI_Carrier_name.Text = objDFV.TPI_Carrier_name;
                        lblViewMVA_Singletpi_contact.Text = objDFV.tpi_contact;
                        lblViewMVA_SingleTPI_Policy_number.Text = objDFV.TPI_Policy_number;
                        lblViewMVA_Singletpi_phone.Text = objDFV.tpi_phone;
                        lblViewMVA_Singletpi_address_1.Text = objDFV.tpi_Address_1;
                        lblViewMVA_Singletpi_address_2.Text = objDFV.tpi_Address_2;
                        lblViewMVA_Singletpi_City.Text = objDFV.tpi_City;
                        lblViewMVA_Singletpi_State.Text = new State(string.IsNullOrEmpty(objDFV.tpi_State) ? 0 : Convert.ToDecimal(objDFV.tpi_State)).FLD_state;
                        lblViewMVA_Singletpi_Zip_Code.Text = objDFV.tpi_Zip_Code;
                        lblViewMVA_SingleRecovered_Amount.Text = clsGeneral.GetStringValue(objDFV.recovered_amount);
                    }
                    else
                    {
                        trViewMVA_SingleSeeking_subrogation_No.Style.Add("display", "");
                        lblViewMVA_SingleSeeking_subrogation.Text = "No";
                        if (objDFV.Notice_only_claim != null)
                        {
                            if (objDFV.Notice_only_claim == true)
                                lblViewMVA_SingleNotice_only_claim.Text = "Yes";
                            else
                                lblViewMVA_SingleNotice_only_claim.Text = "No";
                        }
                        lblViewMVA_SingleRecovered_Amount.Text = clsGeneral.GetStringValue(objDFV.recovered_amount);
                    }

                }
            }
        }
    }

    /// <summary>
    /// Grid View Row Created Event - Single Vehicle Damage 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvViewSingleVehDamage_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //used to check Row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkViewSingleVeh");
            //check link button is null or not.
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    #endregion

    #region Partial Theft Grid View Event[View MOde]

    /// <summary>
    /// Grid View Row Command Event - View partial Theft
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvViewPartialTheft_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if View than display page for View.
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            btnViewAuditPartialTheft_View.Visible = true;
            int PK_ID = (gvViewPartialTheft.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvViewPartialTheft.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
            //check PK_ID if it is greater than 0 than display below fields else hide below fields
            if (PK_ID > 0)
            {
                btnViewAuditPartialTheft_View.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_ID + ");");
                tdViewPartilTheftData.Style.Add("display", "");
                DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_ID);
                lblViewPartialTheft_Make.Text = objDFV.Make;
                lblViewPartialTheft_Model.Text = objDFV.Model;
                lblViewPartialTheft_Year.Text = objDFV.Year.ToString();
                lblViewPartialTheft_VIN.Text = objDFV.VIN;
                if (objDFV.Invoice_Value > 0)
                {
                    lblViewPartialTheft_Invoice_Value.Text = "$ " + clsGeneral.GetStringValue(objDFV.Invoice_Value);
                }
                else
                    lblViewPartialTheft_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);

                lblViewPartialTheft_Loss_Description.Text = objDFV.Loss_Description;
                if (objDFV.Security_Video_Surveillance == true)
                    lblPartialTheft_Security_Video_Surveillance.Text = "Yes";
                else
                    lblPartialTheft_Security_Video_Surveillance.Text = "No";

            }
        }
    }

    /// <summary>
    /// Gridview Row Created Event - View partial Theft 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvViewPartialTheft_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //used to check Row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkViewPartialTheft");
            //check link button is null or not.
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    #endregion

    #region Vandalism Grid View Event[View MOde]
    protected void gvViewVandalism_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if View than display page for View.
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            btnViewAuditVandalism_View.Visible = true;
            int PK_ID = (gvViewVandalism.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvViewVandalism.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
            //check PK_ID if it is greater than 0 than display below fields else hide below fields
            if (PK_ID > 0)
            {
                btnViewAuditVandalism_View.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_ID + ");");
                tdViewVandalismData.Style.Add("display", "");
                DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_ID);
                lblViewVandalism_Make.Text = objDFV.Make;
                lblViewVandalism_Model.Text = objDFV.Model;
                lblViewVandalism_Year.Text = objDFV.Year.ToString();
                lblVandalism_TypeOfVehicle.Text = string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString();
                lblVandalism_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
                lblVandalism_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
                lblVandalism_Present_State.Text = new State(string.IsNullOrEmpty(objDFV.Present_State) ? 0 : Convert.ToDecimal(objDFV.Present_State)).FLD_state;
                lblVandalism_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
                lblViewVandalism_VIN.Text = objDFV.VIN;
                if (objDFV.Invoice_Value > 0)
                {
                    lblViewVandalism_Invoice_Value.Text = "$ " + clsGeneral.GetStringValue(objDFV.Invoice_Value);
                }
                else
                    lblViewVandalism_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);

                lblViewVandalism_Loss_Description.Text = objDFV.Loss_Description;

                lblViewPartialTheft_Loss_Description.Text = objDFV.Loss_Description;

                if (objDFV.Security_Video_Surveillance == true)
                    lblVandalism_Security_Video_Surveillance.Text = "Yes";
                else
                    lblVandalism_Security_Video_Surveillance.Text = "No";
            }
        }
    }
    protected void gvViewVandalism_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //used to check Row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkViewVandalism");
            //check link button is null or not.
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    #endregion

    #region Hail Grid View Event[View MOde]
    protected void gvViewHail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if View than display page for View.
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            btnViewAuditHail_View.Visible = true;
            int PK_ID = (gvViewHail.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvViewHail.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
            //check PK_ID if it is greater than 0 than display below fields else hide below fields
            if (PK_ID > 0)
            {
                btnViewAuditHail_View.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_ID + ");");
                tdViewHailData.Style.Add("display", "");
                DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_ID);
                lblViewHail_Make.Text = objDFV.Make;
                lblViewHail_Model.Text = objDFV.Model;
                lblViewHail_Year.Text = objDFV.Year.ToString();
                lblHail_TypeOfVehicle.Text = string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString();
                lblHail_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
                lblHail_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
                lblHail_Present_State.Text = new State(string.IsNullOrEmpty(objDFV.Present_State) ? 0 : Convert.ToDecimal(objDFV.Present_State)).FLD_state;
                lblHail_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
                lblViewHail_VIN.Text = objDFV.VIN;
                if (objDFV.Invoice_Value > 0)
                {
                    lblViewHail_Invoice_Value.Text = "$ " + clsGeneral.GetStringValue(objDFV.Invoice_Value);
                }
                else
                    lblViewHail_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);

                lblViewHail_Loss_Description.Text = objDFV.Loss_Description;
            }
        }
    }
    protected void gvViewHail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //used to check Row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkViewHail");
            //check link button is null or not.
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    #endregion

    #region Flood Grid View Event[View MOde]
    protected void gvViewFlood_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if View than display page for View.
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            btnViewAuditFlood_View.Visible = true;
            int PK_ID = (gvViewFlood.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvViewFlood.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
            //check PK_ID if it is greater than 0 than display below fields else hide below fields
            if (PK_ID > 0)
            {
                btnViewAuditFlood_View.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_ID + ");");
                tdViewFloodData.Style.Add("display", "");
                DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_ID);
                lblViewFlood_Make.Text = objDFV.Make;
                lblViewFlood_Model.Text = objDFV.Model;
                lblViewFlood_Year.Text = objDFV.Year.ToString();
                lblFlood_TypeOfVehicle.Text = string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString();
                lblFlood_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
                lblFlood_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
                lblFlood_Present_State.Text = new State(string.IsNullOrEmpty(objDFV.Present_State) ? 0 : Convert.ToDecimal(objDFV.Present_State)).FLD_state;
                lblFlood_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
                lblViewFlood_VIN.Text = objDFV.VIN;
                if (objDFV.Invoice_Value > 0)
                {
                    lblViewFlood_Invoice_Value.Text = "$ " + clsGeneral.GetStringValue(objDFV.Invoice_Value);
                }
                else
                    lblViewFlood_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);

                lblViewFlood_Loss_Description.Text = objDFV.Loss_Description;
            }
        }
    }
    protected void gvViewFlood_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //used to check Row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkViewFlood");
            //check link button is null or not.
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    #endregion

    #region Fire Grid View Event[View MOde]
    protected void gvViewFire_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if View than display page for View.
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            btnViewAuditFire_View.Visible = true;
            int PK_ID = (gvViewFire.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvViewFire.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
            //check PK_ID if it is greater than 0 than display below fields else hide below fields
            if (PK_ID > 0)
            {
                btnViewAuditFire_View.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_ID + ");");
                tdViewFireData.Style.Add("display", "");
                DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_ID);
                lblViewFire_Make.Text = objDFV.Make;
                lblViewFire_Model.Text = objDFV.Model;
                lblViewFire_Year.Text = objDFV.Year.ToString();
                lblFire_TypeOfVehicle.Text = string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString();
                lblFire_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
                lblFire_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
                lblFire_Present_State.Text = new State(string.IsNullOrEmpty(objDFV.Present_State) ? 0 : Convert.ToDecimal(objDFV.Present_State)).FLD_state;
                lblFire_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
                lblViewFire_VIN.Text = objDFV.VIN;
                if (objDFV.Invoice_Value > 0)
                {
                    lblViewFire_Invoice_Value.Text = "$ " + clsGeneral.GetStringValue(objDFV.Invoice_Value);
                }
                else
                    lblViewFire_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);

                lblViewFire_Loss_Description.Text = objDFV.Loss_Description;
            }
        }
    }
    protected void gvViewFire_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //used to check Row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkViewFire");
            //check link button is null or not.
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    #endregion

    #region Wind Grid View Event[View MOde]
    protected void gvViewWind_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if View than display page for View.
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            btnViewAuditWind_View.Visible = true;
            int PK_ID = (gvViewWind.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvViewWind.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
            //check PK_ID if it is greater than 0 than display below fields else hide below fields
            if (PK_ID > 0)
            {
                btnViewAuditWind_View.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_ID + ");");
                tdViewWindData.Style.Add("display", "");
                DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_ID);
                lblViewWind_Make.Text = objDFV.Make;
                lblViewWind_Model.Text = objDFV.Model;
                lblViewWind_Year.Text = objDFV.Year.ToString();
                lblWind_TypeOfVehicle.Text = string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString();
                lblWind_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
                lblWind_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
                lblWind_Present_State.Text = new State(string.IsNullOrEmpty(objDFV.Present_State) ? 0 : Convert.ToDecimal(objDFV.Present_State)).FLD_state;
                lblWind_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
                lblViewWind_VIN.Text = objDFV.VIN;
                if (objDFV.Invoice_Value > 0)
                {
                    lblViewWind_Invoice_Value.Text = "$ " + clsGeneral.GetStringValue(objDFV.Invoice_Value);
                }
                else
                    lblViewWind_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);

                lblViewWind_Loss_Description.Text = objDFV.Loss_Description;
            }
        }
    }
    protected void gvViewWind_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //used to check Row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkViewWind");
            //check link button is null or not.
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    #endregion

    #region Theft Grid View Event[View MOde]
    protected void gvViewTheft_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if View than display page for View.
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            btnViewAuditTheft_View.Visible = true;
            int PK_ID = (gvViewTheft.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvViewTheft.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
            //check PK_ID if it is greater than 0 than display below fields else hide below fields
            if (PK_ID > 0)
            {
                btnViewAuditTheft_View.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_ID + ");");
                tdViewTheftData.Style.Add("display", "");
                DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_ID);
                lblViewTheft_Make.Text = objDFV.Make;
                lblViewTheft_Model.Text = objDFV.Model;
                lblViewTheft_Year.Text = objDFV.Year.ToString();
                lblViewTheft_VIN.Text = objDFV.VIN;
                lblTheft_TypeOfVehicle.Text = string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString();
                lblTheft_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
                lblTheft_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
                lblTheft_Present_State.Text = new State(string.IsNullOrEmpty(objDFV.Present_State) ? 0 : Convert.ToDecimal(objDFV.Present_State)).FLD_state;
                lblTheft_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
                if (objDFV.Invoice_Value > 0)
                {
                    lblViewTheft_Invoice_Value.Text = "$ " + clsGeneral.GetStringValue(objDFV.Invoice_Value);
                }
                else
                    lblViewTheft_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);

                lblViewTheft_Loss_Description.Text = objDFV.Loss_Description;
                if (objDFV.Vehicle_Recovered == true)
                {
                    lblViewTheft_Vehicle_Recovered.Text = "Yes";
                }
                else
                {
                    lblViewTheft_Vehicle_Recovered.Text = "No";
                }
                if (objDFV.Vehicle_Recovered == true)
                {
                    tdViewTheft_VehicleRecovred.Style.Add("display", "");
                    lblViewTheft_Damage_estimate.Text = clsGeneral.GetStringValue(objDFV.Damage_Estimate);
                    lblViewTheft_Dealership_Wish_To_Take_Possession.Text = (objDFV.Dealership_Wish_To_Take_Possession == true) ? "Yes" : "N0";
                }
                lblViewTheftVehicle_In_Storage.Text = (objDFV.Vehicle_In_Storage == true) ? "Yes" : "No";
                if (objDFV.Vehicle_In_Storage == true)
                {
                    tdViewTheftVehicle_In_Storage.Style.Add("display", "");
                    lblViewTheft_Storage_Address_1.Text = string.IsNullOrEmpty(objDFV.storage_Address_1) ? "" : objDFV.storage_Address_1.ToString();
                    lblViewTheft_Storage_Address_2.Text = string.IsNullOrEmpty(objDFV.storage_Address_2) ? "" : objDFV.storage_Address_2.ToString();
                    lblViewTheft_Storage_Contact.Text = string.IsNullOrEmpty(objDFV.Storage_Contact) ? "" : objDFV.Storage_Contact.ToString();
                    lblViewTheft_Storage_phone.Text = string.IsNullOrEmpty(objDFV.Storage_phone) ? "" : objDFV.Storage_phone.ToString();
                    lblViewTheft_Storage_City.Text = string.IsNullOrEmpty(objDFV.storage_City) ? "" : objDFV.storage_City.ToString();
                    lblViewTheft_Storage_cost.Text = clsGeneral.GetStringValue(objDFV.storage_cost);
                    lblViewTheft_storage_Zip_Code.Text = string.IsNullOrEmpty(objDFV.storage_Zip_Code) ? "" : objDFV.storage_Zip_Code.ToString();
                    lblViewTheft_Storage_State.Text = new State(string.IsNullOrEmpty(objDFV.storage_State) ? 0 : Convert.ToDecimal(objDFV.storage_State)).FLD_state;
                }
                if (objDFV.Security_Video_Surveillance == true)
                    lblTheft_Security_Video_Surveillance.Text = "Yes";
                else
                    lblTheft_Security_Video_Surveillance.Text = "No";
            }
        }
    }
    protected void gvViewTheft_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //used to check Row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkViewTheft");
            //check link button is null or not.
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    #endregion

    #region Fraud Grid View Event[View MOde]
    protected void gvViewFraud_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if View than display page for View.
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            btnViewAuditFraud_View.Visible = true;
            int PK_ID = (gvViewFraud.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvViewFraud.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
            //check PK_ID if it is greater than 0 than display below fields else hide below fields
            if (PK_ID > 0)
            {
                btnViewAuditFraud_View.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_ID + ");");
                tdViewFraudData.Style.Add("display", "");
                DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_ID);
                lblViewFraud_Make.Text = objDFV.Make;
                lblViewFraud_Model.Text = objDFV.Model;
                lblViewFraud_Year.Text = objDFV.Year.ToString();
                lblViewFraud_VIN.Text = objDFV.VIN;
                lblFraud_TypeOfVehicle.Text = string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString();
                lblFraud_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
                lblFraud_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
                lblFraud_Present_State.Text = new State(string.IsNullOrEmpty(objDFV.Present_State) ? 0 : Convert.ToDecimal(objDFV.Present_State)).FLD_state;
                lblFraud_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
                if (objDFV.Invoice_Value > 0)
                {
                    lblViewFraud_Invoice_Value.Text = "$ " + clsGeneral.GetStringValue(objDFV.Invoice_Value);
                }
                else
                    lblViewFraud_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);

                lblViewFraud_Loss_Description.Text = objDFV.Loss_Description;
                if (objDFV.Vehicle_Recovered == true)
                {
                    lblViewFraud_Vehicle_Recovered.Text = "Yes";
                }
                else
                {
                    lblViewFraud_Vehicle_Recovered.Text = "No";
                }
                if (objDFV.Vehicle_Recovered == true)
                {
                    tdViewFraud_VehicleRecovred.Style.Add("display", "");
                    lblViewFraud_Damage_estimate.Text = clsGeneral.GetStringValue(objDFV.Damage_Estimate);
                    lblViewFraud_Dealership_Wish_To_Take_Possession.Text = (objDFV.Dealership_Wish_To_Take_Possession == true) ? "Yes" : "N0";
                }
                lblViewFraudVehicle_In_Storage.Text = (objDFV.Vehicle_In_Storage == true) ? "Yes" : "No";
                if (objDFV.Vehicle_In_Storage == true)
                {
                    tdViewFraudVehicle_In_Storage.Style.Add("display", "");
                    lblViewFraud_Storage_Address_1.Text = string.IsNullOrEmpty(objDFV.storage_Address_1) ? "" : objDFV.storage_Address_1.ToString();
                    lblViewFraud_Storage_Address_2.Text = string.IsNullOrEmpty(objDFV.storage_Address_2) ? "" : objDFV.storage_Address_2.ToString();
                    lblViewFraud_Storage_Contact.Text = string.IsNullOrEmpty(objDFV.Storage_Contact) ? "" : objDFV.Storage_Contact.ToString();
                    lblViewFraud_Storage_phone.Text = string.IsNullOrEmpty(objDFV.Storage_phone) ? "" : objDFV.Storage_phone.ToString();
                    lblViewFraud_Storage_City.Text = string.IsNullOrEmpty(objDFV.storage_City) ? "" : objDFV.storage_City.ToString();
                    lblViewFraud_Storage_cost.Text = clsGeneral.GetStringValue(objDFV.storage_cost);
                    lblViewFraud_storage_Zip_Code.Text = string.IsNullOrEmpty(objDFV.storage_Zip_Code) ? "" : objDFV.storage_Zip_Code.ToString();
                    lblViewFraud_Storage_State.Text = new State(string.IsNullOrEmpty(objDFV.storage_State) ? 0 : Convert.ToDecimal(objDFV.storage_State)).FLD_state;
                }
                lblFraudPoliceNotified.Text = (objDFV.Police_Notified == true) ? "Yes" : "No";
                if (objDFV.Police_Notified == true)
                {
                    trViewPoliceNotified.Style.Add("display", "");
                    lblFraudReportNumber.Text = string.IsNullOrEmpty(objDFV.Police_Report_Number) ? "" : objDFV.Police_Report_Number.ToString(); ;
                }
            }
        }
    }
    protected void gvViewFraud_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //used to check Row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkViewFraud");
            //check link button is null or not.
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    #endregion

    #region Multi Pasenger Grid View Event[View MOde]
    protected void gvViewMVAMulti_Passenger_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if View than display page for View.
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvViewMVAMulti_Passenger.DataKeys[Index].Values["PK_DPD_FR_Injured_Passenger_id"] != null) ? Convert.ToInt32(gvViewMVAMulti_Passenger.DataKeys[Index].Values["PK_DPD_FR_Injured_Passenger_id"]) : 0;
            //check PK_ID if it is greater than 0 than display below fields else hide below fields
            if (PK_ID > 0)
            {
                btnViewAudit_MVA_Multi_Passenger_View.Visible = true;
                btnViewAudit_MVA_Multi_Passenger_View.Attributes.Add("onClick", "return AuditPopUpForDPDPassenger(" + PK_ID + ");");
                trMVA_Multi_Passenger.Style.Add("display", "");
                DPD_FR_Injured_Passenger objDFIP = new DPD_FR_Injured_Passenger(PK_ID);
                lblViewMVA_Multi_Pass_Name.Text = objDFIP.name;
                lblViewMVA_Multi_Pass_Address_1.Text = objDFIP.Address_1;
                lblViewMVA_Multi_Pass_Address_2.Text = objDFIP.Address_2;
                lblViewMVA_Multi_Pass_Phone.Text = objDFIP.phone;
                lblViewMVA_Multi_Pass_City.Text = objDFIP.City;
                if (objDFIP.injured != null)
                {
                    if (objDFIP.injured == true)
                        lblViewMVA_Multi_Pass_Injured.Text = "Yes";
                    else
                        lblViewMVA_Multi_Pass_Injured.Text = "No";
                }
                lblViewMVA_Multi_Pass_State.Text = new State(string.IsNullOrEmpty(objDFIP.State) ? 0 : Convert.ToDecimal(objDFIP.State)).FLD_state;
                lblViewMVA_Multi_Pass_Zip.Text = objDFIP.Zip_Code;
            }
        }
    }
    protected void gvViewMVAMulti_Passenger_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //used to check Row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkViewMultiPassenger");
            //check link button is null or not.
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    #endregion

    #region Single Passenger Grid View Event[View MOde]
    protected void gvViewMVASingle_Passenger_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if View than display page for View.
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvViewMVASingle_Passenger.DataKeys[Index].Values["PK_DPD_FR_Injured_Passenger_id"] != null) ? Convert.ToInt32(gvViewMVASingle_Passenger.DataKeys[Index].Values["PK_DPD_FR_Injured_Passenger_id"]) : 0;
            //check PK_ID if it is greater than 0 than display below fields else hide below fields
            if (PK_ID > 0)
            {
                btnViewAudit_MVASingle_Passenger_View.Visible = true;
                btnViewAudit_MVASingle_Passenger_View.Attributes.Add("onClick", "return AuditPopUpForDPDPassenger(" + PK_ID + ");");
                trMVA_Single_Passenger.Style.Add("display", "");
                DPD_FR_Injured_Passenger objDFIP = new DPD_FR_Injured_Passenger(PK_ID);
                lblViewMVA_Single_Pass_Name.Text = objDFIP.name;
                lblViewMVA_Single_Pass_Address_1.Text = objDFIP.Address_1;
                lblViewMVA_Single_Pass_Address_2.Text = objDFIP.Address_2;
                lblViewMVA_Single_Pass_Phone.Text = objDFIP.phone;
                lblViewMVA_Single_Pass_City.Text = objDFIP.City;
                if (objDFIP.injured != null)
                {
                    if (objDFIP.injured == true)
                        lblViewMVA_Single_Pass_Injured.Text = "Yes";
                    else
                        lblViewMVA_Single_Pass_Injured.Text = "No";
                }
                lblViewMVA_Single_Pass_State.Text = new State(string.IsNullOrEmpty(objDFIP.State) ? 0 : Convert.ToDecimal(objDFIP.State)).FLD_state;
                lblViewMVA_Single_Pass_Zip.Text = objDFIP.Zip_Code;
            }
        }
    }
    protected void gvViewMVASingle_Passenger_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //used to check Row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkViewSinglePassenger");
            //check link button is null or not.
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    #endregion

    #region Witness Grid View Event[View MOde]
    protected void gvWitnessesView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if View than display page for View.
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvWitnessesView.DataKeys[Index].Values["PK_DPD_Witness_ID"] != null) ? Convert.ToInt32(gvWitnessesView.DataKeys[Index].Values["PK_DPD_Witness_ID"]) : 0;
            //check PK_ID if it is greater than 0 than display below fields else hide below fields
            if (PK_ID > 0)
            {
                btnViewAuditWitness_View.Visible = true;
                btnViewAuditWitness_View.Attributes.Add("onClick", "return AuditWitnessPopUp(" + PK_ID + ");");
                trWitness.Style.Add("display", "");
                DPD_Witness objWit = new DPD_Witness(PK_ID);
                lblWitness_Name.Text = objWit.Name;
                lblWitness_Address.Text = objWit.Address;
                lblWitness_Phone.Text = objWit.Phone;
            }
        }
    }

    #endregion

    #endregion

    #region Bind Page in Edit Mode

    /// <summary>
    /// Method to bind Page in Edit Mode
    /// </summary>
    public void BindPageinEditMode()
    {
        if (First_Report_Wizard_ID > 0)
        {
            //create object
            DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);
            //used to check report is complete or not. if not than Message is display else not display
            if (objDPD_FR.Complete == false)
            {
                //Hide Message of "This Report Has not been submitted"
                lblSubmitMessage.Text = "This Report has not been submitted";
            }
            else
            {
                lblSubmitMessage.Text = "";
            }

            DataSet dsFRWInfo = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.DPD_FR, PK_DPD_FR_ID);
            DataTable dtFRWInfo = dsFRWInfo.Tables[0];
            if (dtFRWInfo.Rows.Count > 0)
            {
                DataRow drFRWInfo = dtFRWInfo.Rows[0];
                #region Fill Location Information Controls
                //select value from Location Number Dropdown
                if (drFRWInfo["Sonic_Location_Code"] != null)
                {
                    ListItem lst = new ListItem();
                    lst = ddlLocationNumber.Items.FindByText(drFRWInfo["Sonic_Location_Code"].ToString());
                    //check list item if not null than list item selected = true
                    if (lst != null)
                    {
                        lst.Selected = true;
                    }
                }
                //select value from Location d/b/a Dropdown
                if (drFRWInfo["dba"] != null)
                {
                    ListItem lst = new ListItem();
                    lst = ddlLocationdba.Items.FindByText(drFRWInfo["dba"].ToString());
                    //check list item if not null than list item selected = true
                    if (lst != null)
                    {
                        lst.Selected = true;
                    }
                }
                //select value from Location f/k/a Dropdown
                if (drFRWInfo["FK_Location_ID"] != null)
                {
                    //Fill Location FKA Dropdown
                    ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, (drFRWInfo["FK_Location_ID"] != null) ? Convert.ToInt32(drFRWInfo["FK_Location_ID"]) : 0, true);
                }
                //select value from Location Legal Entity Dropdown
                //if (drFRWInfo["legal_entity"] != null)
                //{
                //    ListItem lst = new ListItem();
                //    lst = ddlLegalEntity.Items.FindByText(drFRWInfo["legal_entity"].ToString());
                //    //check list item if not null than list item selected = true
                //    if (lst != null)
                //    {
                //        lst.Selected = true;
                //    }
                //}

                //set address1,address2,city,state,ZipCOde Values
                txtLocationAddress1.Text = (drFRWInfo["Address_1"] != null) ? Convert.ToString(drFRWInfo["Address_1"]) : "";
                txtLocationAddress2.Text = (drFRWInfo["Address_2"] != null) ? Convert.ToString(drFRWInfo["Address_2"]) : "";
                txtLocationCity.Text = (drFRWInfo["City"] != null) ? Convert.ToString(drFRWInfo["City"]) : "";
                txtLocationState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRWInfo["State"])) ? Convert.ToDecimal(drFRWInfo["State"]) : 0).FLD_state;
                txtLocationZipCode.Text = (drFRWInfo["Zip_Code"] != null) ? Convert.ToString(drFRWInfo["Zip_Code"]) : "";

                #endregion

                #region Fill Contact Information Controls
                txtdba.Text = (drFRWInfo["dba"] != null) ? Convert.ToString(drFRWInfo["dba"]) : "";
                txtContactName.Text = (drFRWInfo["EmployeeName"] != null) ? Convert.ToString(drFRWInfo["EmployeeName"]) : "";
                txtContact_Best_Time.Text = (drFRWInfo["Contact_Best_Time"] != null) ? Convert.ToString(drFRWInfo["Contact_Best_Time"]) : "";
                txtAddress_1.Text = (drFRWInfo["Address_1"] != null) ? Convert.ToString(drFRWInfo["Address_1"]) : "";
                txtAddress_2.Text = (drFRWInfo["Address_2"] != null) ? Convert.ToString(drFRWInfo["Address_2"]) : "";
                txtWork_Phone.Text = (drFRWInfo["TelephoneNumber1"] != null) ? Convert.ToString(drFRWInfo["TelephoneNumber1"]) : "";
                txtEmployee_Cell_Phone.Text = (drFRWInfo["TelephoneNumber2"] != null) ? Convert.ToString(drFRWInfo["TelephoneNumber2"]) : "";
                txtCity.Text = (drFRWInfo["City"] != null) ? Convert.ToString(drFRWInfo["City"]) : "";
                txtZip_Code.Text = (drFRWInfo["Zip_Code"] != null) ? Convert.ToString(drFRWInfo["Zip_Code"]) : "";
                txtState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRWInfo["State"])) ? Convert.ToDecimal(drFRWInfo["State"]) : 0).FLD_state;
                txtEmployee_Fax.Text = (drFRWInfo["Contact_Fax"] != null) ? Convert.ToString(drFRWInfo["Contact_Fax"]) : "";
                txtEmail.Text = (drFRWInfo["FRWEmail"] != null) ? Convert.ToString(drFRWInfo["FRWEmail"]) : "";
                #endregion

                #region Fill Loss Location information id Different Section
                txtLoss_Address_1.Text = objDPD_FR.Loss_Address_1;
                txtLoss_Address_2.Text = objDPD_FR.Loss_Address_2;
                rdoOn_Company_Property.SelectedValue = (objDPD_FR.On_Company_Property == true) ? "Y" : "N";
                txtDate_Of_Loss.Text = clsGeneral.FormatDateToDisplay(objDPD_FR.Date_Of_Loss);
                txtLossDate_Of_Loss.Text = clsGeneral.FormatDateToDisplay(objDPD_FR.Date_Of_Loss);
                txtTime_of_Loss.Text = objDPD_FR.Time_of_Loss;
                txtLoss_City.Text = objDPD_FR.Loss_City;
                //used to check Is string is null or Emplty if false than select value of Dropdown.
                if (!string.IsNullOrEmpty(objDPD_FR.Loss_State))
                {
                    ListItem lstLossSate = new ListItem();
                    lstLossSate = ddlLoss_State.Items.FindByValue(objDPD_FR.Loss_State.ToString());
                    //check list item if not null than list item selected = true
                    if (lstLossSate != null)
                        lstLossSate.Selected = true;
                }
                txtLoss_ZipCode.Text = objDPD_FR.Loss_ZipCode;
                txtDate_Reported_To_Sonic.Text = clsGeneral.FormatDateToDisplay(objDPD_FR.Date_Reported_To_Sonic);
                #endregion
                //used to Disable all Controls
                DisableEnableControls(false);
                #region Fill Loss Information Controls [Edit Mode]

                lstCauseOfLoss.Items[7].Selected = objDPD_FR.Theft;
                lstCauseOfLoss.Items[6].Selected = objDPD_FR.Partial_Theft;
                lstCauseOfLoss.Items[8].Selected = objDPD_FR.Vandalism;
                lstCauseOfLoss.Items[5].Selected = objDPD_FR.MVA_Single;
                lstCauseOfLoss.Items[4].Selected = objDPD_FR.MVA_Multiple;
                lstCauseOfLoss.Items[3].Selected = objDPD_FR.Hail;
                lstCauseOfLoss.Items[1].Selected = objDPD_FR.Flood;
                lstCauseOfLoss.Items[0].Selected = objDPD_FR.Fire;
                lstCauseOfLoss.Items[9].Selected = objDPD_FR.Wind;
                lstCauseOfLoss.Items[2].Selected = objDPD_FR.Fraud;

                DataTable dtVehicle = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "");

                if (dtVehicle != null && dtVehicle.Rows.Count > 0)
                {
                    BindVehicleGrid();
                    lstCauseOfLoss.Style["display"] = "none";
                    ViewState["MODEADD"] = "N";
                    btnEditVehicles.Visible = true;
                }
                else
                {
                    ViewState["MODEADD"] = "Y";
                }
                //    lstCauseOfLoss_SelectedIndexChanged(null, null);


                #endregion

                #region Fill Witness Information [Edit Mode]
                //Bind Witness Grid
                BindWitness();
                #endregion

                #region Fill Comments and Atachments
                txtComments.Text = objDPD_FR.Comments;
                CtrlAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.DPD_FR, PK_DPD_FR_ID, true, 4);
                CtrlAttachDetails.Bind();
                #endregion
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
    public string GenerateEMailBody(out string FirstReportNumber)
    {
        string strFilePath = HttpContext.Current.Server.MapPath("~/EmailTemplate/DPD_FR.htm");
        string strEbdy = clsGeneral.ReadTextFile(strFilePath);
        if (string.IsNullOrEmpty(strEbdy))
        {
            FirstReportNumber = "";
            return "";
        }
        else
        {
            if (First_Report_Wizard_ID > 0)
            {
                //Declare Object of DPD_FR table
                DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);

                DataSet dsEMail = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.DPD_FR, PK_DPD_FR_ID);
                DataTable dtEMail = dsEMail.Tables[0];
                DataRow drEMail = dtEMail.Rows[0];

                #region Fill Location Information Controls

                FirstReportNumber = drEMail["FK_First_Report_ID"].ToString();
                decimal FR_Number = new DPD_FR(!string.IsNullOrEmpty(FirstReportNumber) ? Convert.ToDecimal(FirstReportNumber) : 0).DPD_FR_Number;
                //FirstReportNumber = drEMail["Sonic_Location_Code"].ToString() != string.Empty ? drEMail["Sonic_Location_Code"].ToString() : "";
                strEbdy = strEbdy.Replace("[lblFirstReportNumber]", "DPD-" + FR_Number.ToString());
                //Display Location NUmber
                if (drEMail["Sonic_Location_Code"] != null)
                    strEbdy = strEbdy.Replace("[lblLocationNumber]", drEMail["Sonic_Location_Code"].ToString());
                else
                    strEbdy = strEbdy.Replace("[lblLocationNumber]", "");
                //Display dba Value
                if (drEMail["dba"] != null)
                    strEbdy = strEbdy.Replace("[lblLocationdba]", drEMail["dba"].ToString());
                else
                    strEbdy = strEbdy.Replace("[lblLocationdba]", "");
                //Display F/K/A value
                if (drEMail["FK_Location_ID"] != null)
                    strEbdy = strEbdy.Replace("[lblLocationfka]", new LU_Location_FKA(Convert.ToDecimal(drEMail["FK_Location_ID"])).fka.ToString());
                //Display Legal Entity Value
                //if (drEMail["legal_entity"] != null)
                //    strEbdy = strEbdy.Replace("[lblLegalEntity]", drEMail["legal_entity"].ToString());
                //else
                //    strEbdy = strEbdy.Replace("[lblLegalEntity]", "");

                //set address1,address2,city,state,ZipCOde Values
                strEbdy = strEbdy.Replace("[lblLocationAddress1]", (drEMail["Address_1"] != null) ? Convert.ToString(drEMail["Address_1"]) : "");
                strEbdy = strEbdy.Replace("[lblLocationAddress2]", (drEMail["Address_2"] != null) ? Convert.ToString(drEMail["Address_2"]) : "");
                strEbdy = strEbdy.Replace("[lblLocationCity]", (drEMail["City"] != null) ? Convert.ToString(drEMail["City"]) : "");
                strEbdy = strEbdy.Replace("[lblLocationState]", new State(!string.IsNullOrEmpty(Convert.ToString(drEMail["State"])) ? Convert.ToDecimal(drEMail["State"]) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblLocationZipCode]", (drEMail["Zip_Code"] != null) ? Convert.ToString(drEMail["Zip_Code"]) : "");

                #endregion

                #region Fill Contact Information Controls
                strEbdy = strEbdy.Replace("[lbldba]", (drEMail["dba"] != null) ? Convert.ToString(drEMail["dba"]) : "");
                strEbdy = strEbdy.Replace("[lblContactName]", (drEMail["EmployeeName"] != null) ? Convert.ToString(drEMail["EmployeeName"]) : "");
                strEbdy = strEbdy.Replace("[lblContact_Best_Time]", (drEMail["Contact_Best_Time"] != null) ? Convert.ToString(drEMail["Contact_Best_Time"]) : "");
                strEbdy = strEbdy.Replace("[lblAddress_1]", (drEMail["Address_1"] != null) ? Convert.ToString(drEMail["Address_1"]) : "");
                strEbdy = strEbdy.Replace("[lblAddress_2]", (drEMail["Address_2"] != null) ? Convert.ToString(drEMail["Address_2"]) : "");
                strEbdy = strEbdy.Replace("[lblWork_Phone]", (drEMail["TelephoneNumber1"] != null) ? Convert.ToString(drEMail["TelephoneNumber1"]) : "");
                strEbdy = strEbdy.Replace("[lblEmployee_Cell_Phone]", (drEMail["TelephoneNumber2"] != null) ? Convert.ToString(drEMail["TelephoneNumber2"]) : "");
                strEbdy = strEbdy.Replace("[lblCity]", (drEMail["City"] != null) ? Convert.ToString(drEMail["City"]) : "");
                strEbdy = strEbdy.Replace("[lblZip_Code]", (drEMail["Zip_Code"] != null) ? Convert.ToString(drEMail["Zip_Code"]) : "");
                strEbdy = strEbdy.Replace("[lblState]", new State(!string.IsNullOrEmpty(Convert.ToString(drEMail["State"])) ? Convert.ToDecimal(drEMail["State"]) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblEmployee_Fax]", (drEMail["Contact_Fax"] != null) ? Convert.ToString(drEMail["Contact_Fax"]) : "");
                strEbdy = strEbdy.Replace("[lblEmail]", (drEMail["FRWEmail"] != null) ? Convert.ToString(drEMail["FRWEmail"]) : "");
                #endregion

                #region Fill Loss Location information id Different Section
                strEbdy = strEbdy.Replace("[lblLoss_Address_1]", objDPD_FR.Loss_Address_1);
                strEbdy = strEbdy.Replace("[lblLoss_Address_2]", objDPD_FR.Loss_Address_2);
                strEbdy = strEbdy.Replace("[lblOn_Company_Property]", (objDPD_FR.On_Company_Property == true) ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[lblDate_Of_Loss]", clsGeneral.FormatDateToDisplay(objDPD_FR.Date_Of_Loss));
                strEbdy = strEbdy.Replace("[lblTime_of_Loss]", objDPD_FR.Time_of_Loss);
                strEbdy = strEbdy.Replace("[lblLoss_City]", objDPD_FR.Loss_City);
                strEbdy = strEbdy.Replace("[lblLoss_State]", new State(string.IsNullOrEmpty(objDPD_FR.Loss_State) ? 0 : Convert.ToDecimal(objDPD_FR.Loss_State)).FLD_state);
                strEbdy = strEbdy.Replace("[lblLoss_ZipCode]", objDPD_FR.Loss_ZipCode);
                strEbdy = strEbdy.Replace("[lblDate_Reported_To_Sonic]", clsGeneral.FormatDateToDisplay(objDPD_FR.Date_Reported_To_Sonic));
                #endregion

                #region Fill Loss Information Controls

                #region Theft Section
                //check object value if it set to true display relatyed section
                strEbdy = strEbdy.Replace("[lblLossDate_Of_Loss]", clsGeneral.FormatDateToDisplay(objDPD_FR.Date_Of_Loss));
                if (objDPD_FR.Theft == true)
                {
                    string strTheftBody = "";
                    DataTable dtTheft = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "4");
                    //used to Bind a table for Partial Theft vachicle for Email contact
                    if (dtTheft.Rows.Count > 0)
                    {
                        strTheftBody += "<table cellpadding='3' cellspacing='1' border='0' width='100%' style='background-color:Black;border-collapse: collapse;'>";
                        //make row of table as per record found.
                        for (int intTheftCount = 0; intTheftCount < dtTheft.Rows.Count; intTheftCount++)
                        {
                            strTheftBody += "<tr class='PropertyInfoBG'>";
                            strTheftBody += "<td class='cols' style='width:20%'>VIN</td>";
                            strTheftBody += "<td class='cols' style='width:20%'>Vehicle Make</td>";
                            strTheftBody += "<td class='cols' style='width:20%'>Model</td>";
                            strTheftBody += "<td class='cols' style='width:20%'>Year</td>";
                            strTheftBody += "<td class='cols' style='width:20%'>Invoice Value</td>";
                            strTheftBody += "</tr>";

                            DataRow drTheft = dtTheft.Rows[intTheftCount];
                            strTheftBody += "<tr style='background-color:White;'>";
                            strTheftBody += "<td class='cols'>" + drTheft["VIN"].ToString() + "</td>";
                            strTheftBody += "<td class='cols'>" + drTheft["Make"].ToString() + "</td>";
                            strTheftBody += "<td class='cols'>" + drTheft["Model"].ToString() + "</td>";
                            strTheftBody += "<td class='cols'>" + drTheft["Year"].ToString() + "</td>";
                            if (!string.IsNullOrEmpty(Convert.ToString(drTheft["Invoice_Value"])))
                                strTheftBody += "<td class='cols'>" + "$ " + clsGeneral.GetStringValue(drTheft["Invoice_Value"]) + "</td>";
                            else
                                strTheftBody += "<td class='cols'>" + clsGeneral.GetStringValue(drTheft["Invoice_Value"]) + "</td>";

                            strTheftBody += "</tr>";

                            strTheftBody += GetVehicleDetailForMail(drTheft, "4");
                        }
                        strTheftBody += "</table>";
                    }
                    strEbdy = strEbdy.Replace("[TheftInfo]", strTheftBody);
                }
                else
                {
                    //strEbdy = strEbdy.Replace("[tdViewtheft]", "none");
                    strEbdy = strEbdy.Replace("<!--[tdViewtheft] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewtheft] -->", " -->");
                }
                #endregion

                #region Partial Theft Section
                //check object value if it set to true display related section else hide section
                if (objDPD_FR.Partial_Theft == true)
                {
                    string strPartialBody = "";
                    DataTable dtPartialTheft = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "5");
                    //used to Bind a table for Partial Theft vachicle for Email contact
                    if (dtPartialTheft.Rows.Count > 0)
                    {
                        strPartialBody += "<table cellpadding='3' cellspacing='1' border='0' width='100%' style='background-color:Black;border-collapse: collapse;'>";
                        strPartialBody += "<tr class='PropertyInfoBG'>";
                        strPartialBody += "<td class='cols' style='width:20%'>VIN</td>";
                        strPartialBody += "<td class='cols' style='width:20%'>Vehicle Make</td>";
                        strPartialBody += "<td class='cols' style='width:20%'>Model</td>";
                        strPartialBody += "<td class='cols' style='width:20%'>Year</td>";
                        strPartialBody += "<td class='cols' style='width:20%'>Invoice Value</td>";
                        strPartialBody += "</tr>";
                        //make row of table as per record found.
                        for (int intPTCount = 0; intPTCount < dtPartialTheft.Rows.Count; intPTCount++)
                        {
                            DataRow drPartialheft = dtPartialTheft.Rows[intPTCount];
                            strPartialBody += "<tr style='background-color:White;'>";
                            strPartialBody += "<td class='cols'>" + drPartialheft["VIN"].ToString() + "</td>";
                            strPartialBody += "<td class='cols'>" + drPartialheft["Make"].ToString() + "</td>";
                            strPartialBody += "<td class='cols'>" + drPartialheft["Model"].ToString() + "</td>";
                            strPartialBody += "<td class='cols'>" + drPartialheft["Year"].ToString() + "</td>";
                            if (!string.IsNullOrEmpty(Convert.ToString(drPartialheft["Invoice_Value"])))
                                strPartialBody += "<td class='cols'>" + "$ " + clsGeneral.GetStringValue(drPartialheft["Invoice_Value"]) + "</td>";
                            else
                                strPartialBody += "<td class='cols'>" + clsGeneral.GetStringValue(drPartialheft["Invoice_Value"]) + "</td>";

                            strPartialBody += "</tr>";

                            strPartialBody += GetVehicleDetailForMail(drPartialheft, "5");

                        }
                        strPartialBody += "</table>";
                    }
                    strEbdy = strEbdy.Replace("[PartialTheftInfo]", strPartialBody);
                }
                else
                {
                    //strEbdy = strEbdy.Replace("[tdViewPartialTheft]", "none");
                    strEbdy = strEbdy.Replace("<!--[tdViewPartialTheft] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewPartialTheft] -->", "-->");

                }
                #endregion

                #region Udpate Vandalism
                //check object value if it set to true display related section else Hide the section
                if (objDPD_FR.Vandalism == true)
                {
                    string strVandalismBody = "";
                    DataTable dtVandalism = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "6");
                    //used to Bind a table for Partial Theft vachicle for Email contact
                    if (dtVandalism.Rows.Count > 0)
                    {
                        strVandalismBody += "<table cellpadding='3' cellspacing='1' border='0' width='100%' style='background-color:Black;border-collapse: collapse;'>";

                        //make row of table as per record found.
                        for (int intVandalismCount = 0; intVandalismCount < dtVandalism.Rows.Count; intVandalismCount++)
                        {
                            strVandalismBody += "<tr class='PropertyInfoBG'>";
                            strVandalismBody += "<td class='cols' style='width:20%'>VIN</td>";
                            strVandalismBody += "<td class='cols' style='width:20%'>Vehicle Make</td>";
                            strVandalismBody += "<td class='cols' style='width:20%'>Model</td>";
                            strVandalismBody += "<td class='cols' style='width:20%'>Year</td>";
                            strVandalismBody += "<td class='cols' style='width:20%'>Invoice Value</td>";
                            strVandalismBody += "</tr>";

                            DataRow drVandalism = dtVandalism.Rows[intVandalismCount];
                            strVandalismBody += "<tr style='background-color:White;'>";
                            strVandalismBody += "<td class='cols' >" + drVandalism["VIN"].ToString() + "</td>";
                            strVandalismBody += "<td class='cols' >" + drVandalism["Make"].ToString() + "</td>";
                            strVandalismBody += "<td class='cols' >" + drVandalism["Model"].ToString() + "</td>";
                            strVandalismBody += "<td class='cols' >" + drVandalism["Year"].ToString() + "</td>";
                            if (!string.IsNullOrEmpty(Convert.ToString(drVandalism["Invoice_Value"])))
                                strVandalismBody += "<td class='cols' >" + "$ " + clsGeneral.GetStringValue(drVandalism["Invoice_Value"]) + "</td>";
                            else
                                strVandalismBody += "<td class='cols' >" + clsGeneral.GetStringValue(drVandalism["Invoice_Value"]) + "</td>";

                            strVandalismBody += "</tr>";

                            strVandalismBody += GetVehicleDetailForMail(drVandalism, "6");

                        }
                        strVandalismBody += "</table>";
                    }
                    strEbdy = strEbdy.Replace("[VandalismInfo]", strVandalismBody);
                }
                else
                {
                    //strEbdy = strEbdy.Replace("[tdViewVandalism]", "none");
                    strEbdy = strEbdy.Replace("<!--[tdViewVandalism] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewVandalism] -->", "-->");
                }
                #endregion

                #region Insert/Update Value into DPD Vehicle Table for MVA-Damage for Single Vehicle
                //check object value if it set to true display related section else hide section
                if (objDPD_FR.MVA_Single == true)
                {
                    string strMVASingleBody = "";
                    DataTable dtMVASingle = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "1");
                    //used to Bind a table for Partial MVASingle vachicle for Email contact
                    if (dtMVASingle.Rows.Count > 0)
                    {
                        strMVASingleBody += "<table cellpadding='3' cellspacing='1' border='0' width='100%' style='background-color:Black;Black;border-collapse: collapse;'>";

                        //make row of table as per record found.
                        for (int intMVASingleCount = 0; intMVASingleCount < dtMVASingle.Rows.Count; intMVASingleCount++)
                        {
                            strMVASingleBody += "<tr class='PropertyInfoBG'>";
                            strMVASingleBody += "<td class='cols' style='width:20%'>VIN</td>";
                            strMVASingleBody += "<td class='cols' style='width:20%'>Vehicle Make</td>";
                            strMVASingleBody += "<td class='cols' style='width:20%'>Model</td>";
                            strMVASingleBody += "<td class='cols' style='width:20%'>Year</td>";
                            strMVASingleBody += "<td class='cols' style='width:20%'>Invoice Value</td>";
                            strMVASingleBody += "</tr>";
                            DataRow drMVASingle = dtMVASingle.Rows[intMVASingleCount];
                            strMVASingleBody += "<tr style='background-color:White;'>";
                            strMVASingleBody += "<td class='cols'>" + drMVASingle["VIN"].ToString() + "</td>";
                            strMVASingleBody += "<td class='cols'>" + drMVASingle["Make"].ToString() + "</td>";
                            strMVASingleBody += "<td class='cols'>" + drMVASingle["Model"].ToString() + "</td>";
                            strMVASingleBody += "<td class='cols'>" + drMVASingle["Year"].ToString() + "</td>";
                            if (!string.IsNullOrEmpty(Convert.ToString(drMVASingle["Invoice_Value"])))
                                strMVASingleBody += "<td class='cols'>" + "$ " + clsGeneral.GetStringValue(drMVASingle["Invoice_Value"]) + "</td>";
                            else
                                strMVASingleBody += "<td class='cols'>" + clsGeneral.GetStringValue(drMVASingle["Invoice_Value"]) + "</td>";

                            strMVASingleBody += "</tr>";

                            strMVASingleBody += GetVehicleDetailForMail(drMVASingle, "1");
                        }
                        strMVASingleBody += "</table>";
                    }
                    strEbdy = strEbdy.Replace("[MVASingleInfo]", strMVASingleBody);
                }
                else
                {
                    //strEbdy = strEbdy.Replace("[tdViewMVA_Single_Damage]", "none");
                    strEbdy = strEbdy.Replace("<!--[tdViewMVA_Single_Damage] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewMVA_Single_Damage] -->", "-->");

                }
                #endregion

                #region Insert/Update Value into DPD Vehicle Table for MVA-Damage for Multiple Vehicle
                //check object value if it set to true display related section
                if (objDPD_FR.MVA_Multiple == true)
                {
                    string strMVABody = "";
                    //strEbdy = strEbdy.Replace("[tdViewMVA_Multi_Damage]", "");
                    DataTable dtMultiDamage = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "2");
                    //used to Bind a table for MVA_Multi damage vachicle for Email contact
                    if (dtMultiDamage.Rows.Count > 0)
                    {
                        strMVABody += "<table cellpadding='3' cellspacing='1' border='0' width='100%' style='background-color:Black;Black;border-collapse: collapse;'>";

                        //make row of table as per record found.
                        for (int intMDCount = 0; intMDCount < dtMultiDamage.Rows.Count; intMDCount++)
                        {
                            strMVABody += "<tr class='PropertyInfoBG'>";
                            strMVABody += "<td class='cols' style='width:20%'>Vehicle Make</td>";
                            strMVABody += "<td class='cols' style='width:20%'>Model</td>";
                            strMVABody += "<td class='cols' style='width:20%'>Year</td>";
                            strMVABody += "<td class='cols' style='width:20%'>VIN</td>";
                            strMVABody += "<td class='cols' style='width:20%'>Damage Estimate</td>";
                            strMVABody += "</tr>";

                            DataRow drMultiVeh = dtMultiDamage.Rows[intMDCount];
                            strMVABody += "<tr style='background-color:White;'>";
                            strMVABody += "<td class='cols' >" + drMultiVeh["Make"].ToString() + "</td>";
                            strMVABody += "<td class='cols' >" + drMultiVeh["Model"].ToString() + "</td>";
                            strMVABody += "<td class='cols' >" + drMultiVeh["Year"].ToString() + "</td>";
                            strMVABody += "<td class='cols' >" + drMultiVeh["VIN"].ToString() + "</td>";
                            if (!string.IsNullOrEmpty(Convert.ToString(drMultiVeh["Damage_Estimate"])))
                                strMVABody += "<td class='cols' >" + "$ " + clsGeneral.GetStringValue(drMultiVeh["Damage_Estimate"]) + "</td>";
                            else
                                strMVABody += "<td class='cols' >" + clsGeneral.GetStringValue(drMultiVeh["Damage_Estimate"]) + "</td>";

                            strMVABody += "</tr>";

                            strMVABody += GetVehicleDetailForMail(drMultiVeh, "2");
                        }
                        strMVABody += "</table>";
                    }
                    strEbdy = strEbdy.Replace("[MultiDamageVehicleInfo]", strMVABody);
                }
                else
                {
                    //strEbdy = strEbdy.Replace("[tdViewMVA_Multi_Damage]", "none");
                    strEbdy = strEbdy.Replace("<!--[tdViewMVA_Multi_Damage] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewMVA_Multi_Damage] -->", "-->");
                }
                #endregion

                #region Update Hail
                //check object value if it set to true display related section
                if (objDPD_FR.Hail == true)
                {
                    string strHailBody = "";
                    DataTable dtHail = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "7");
                    //used to Bind a table for Partial Theft vachicle for Email contact
                    if (dtHail.Rows.Count > 0)
                    {
                        strHailBody += "<table cellpadding='3' cellspacing='1' border='0' width='100%' style='background-color:Black;border-collapse: collapse;'>";

                        //make row of table as per record found.
                        for (int intHailCount = 0; intHailCount < dtHail.Rows.Count; intHailCount++)
                        {
                            strHailBody += "<tr class='PropertyInfoBG'>";
                            strHailBody += "<td class='cols' style='width:20%'>VIN</td>";
                            strHailBody += "<td class='cols' style='width:20%'>Vehicle Make</td>";
                            strHailBody += "<td class='cols' style='width:20%'>Model</td>";
                            strHailBody += "<td class='cols' style='width:20%'>Year</td>";
                            strHailBody += "<td class='cols' style='width:20%'>Invoice Value</td>";
                            strHailBody += "</tr>";

                            DataRow drHail = dtHail.Rows[intHailCount];
                            strHailBody += "<tr style='background-color:White;'>";
                            strHailBody += "<td class='cols' >" + drHail["VIN"].ToString() + "</td>";
                            strHailBody += "<td class='cols' >" + drHail["Make"].ToString() + "</td>";
                            strHailBody += "<td class='cols' >" + drHail["Model"].ToString() + "</td>";
                            strHailBody += "<td class='cols' >" + drHail["Year"].ToString() + "</td>";
                            if (!string.IsNullOrEmpty(Convert.ToString(drHail["Invoice_Value"])))
                                strHailBody += "<td class='cols' >" + "$ " + clsGeneral.GetStringValue(drHail["Invoice_Value"]) + "</td>";
                            else
                                strHailBody += "<td class='cols' >" + clsGeneral.GetStringValue(drHail["Invoice_Value"]) + "</td>";

                            strHailBody += "</tr>";
                            strHailBody += GetVehicleDetailForMail(drHail, "7");

                        }
                        strHailBody += "</table>";
                    }
                    strEbdy = strEbdy.Replace("[HailInfo]", strHailBody);
                }
                else
                {
                    //strEbdy = strEbdy.Replace("[tdViewHail]", "none");
                    strEbdy = strEbdy.Replace("<!--[tdViewHail] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewHail] -->", "-->");
                }
                #endregion

                #region Update Flood
                //check object value if it set to true display related section
                if (objDPD_FR.Flood == true)
                {
                    string strFloodBody = "";
                    DataTable dtFlood = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "8");
                    //used to Bind a table for Partial Theft vachicle for Email contact
                    if (dtFlood.Rows.Count > 0)
                    {
                        strFloodBody += "<table cellpadding='3' cellspacing='1' border='0' width='100%' style='background-color:Black;border-collapse: collapse;'>";

                        //make row of table as per record found.
                        for (int intFloodCount = 0; intFloodCount < dtFlood.Rows.Count; intFloodCount++)
                        {
                            strFloodBody += "<tr class='PropertyInfoBG'>";
                            strFloodBody += "<td style='width:20%' class='cols' >VIN</td>";
                            strFloodBody += "<td style='width:20%' class='cols' >Vehicle Make</td>";
                            strFloodBody += "<td style='width:20%' class='cols' >Model</td>";
                            strFloodBody += "<td style='width:20%' class='cols' >Year</td>";
                            strFloodBody += "<td style='width:20%' class='cols' >Invoice Value</td>";
                            strFloodBody += "</tr>";
                            DataRow drFlood = dtFlood.Rows[intFloodCount];
                            strFloodBody += "<tr style='background-color:White;'>";
                            strFloodBody += "<td class='cols' >" + drFlood["VIN"].ToString() + "</td>";
                            strFloodBody += "<td class='cols' >" + drFlood["Make"].ToString() + "</td>";
                            strFloodBody += "<td class='cols' >" + drFlood["Model"].ToString() + "</td>";
                            strFloodBody += "<td class='cols' >" + drFlood["Year"].ToString() + "</td>";
                            if (!string.IsNullOrEmpty(Convert.ToString(drFlood["Invoice_Value"])))
                                strFloodBody += "<td class='cols' >" + "$ " + clsGeneral.GetStringValue(drFlood["Invoice_Value"]) + "</td>";
                            else
                                strFloodBody += "<td class='cols' >" + clsGeneral.GetStringValue(drFlood["Invoice_Value"]) + "</td>";

                            strFloodBody += "</tr>";
                            strFloodBody += GetVehicleDetailForMail(drFlood, "8");
                        }
                        strFloodBody += "</table>";
                    }
                    strEbdy = strEbdy.Replace("[FloodInfo]", strFloodBody);
                }
                else
                {
                    //strEbdy = strEbdy.Replace("[tdViewFlood]", "none");
                    strEbdy = strEbdy.Replace("<!--[tdViewFlood] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewFlood] -->", "-->");
                }
                #endregion

                #region Update Fire
                //check object value if it set to true display related section
                if (objDPD_FR.Fire == true)
                {
                    string strFireBody = "";
                    DataTable dtFire = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "9");
                    //used to Bind a table for Partial Theft vachicle for Email contact
                    if (dtFire.Rows.Count > 0)
                    {
                        strFireBody += "<table cellpadding='3' cellspacing='1' border='0' width='100%' style='background-color:Black;border-collapse: collapse;'>";

                        //make row of table as per record found.
                        for (int intFireCount = 0; intFireCount < dtFire.Rows.Count; intFireCount++)
                        {
                            strFireBody += "<tr class='PropertyInfoBG'>";
                            strFireBody += "<td class='cols' style='width:20%'>VIN</td>";
                            strFireBody += "<td class='cols' style='width:20%'>Vehicle Make</td>";
                            strFireBody += "<td class='cols' style='width:20%'>Model</td>";
                            strFireBody += "<td class='cols' style='width:20%'>Year</td>";
                            strFireBody += "<td class='cols' style='width:20%'>Invoice Value</td>";
                            strFireBody += "</tr>";
                            DataRow drFire = dtFire.Rows[intFireCount];
                            strFireBody += "<tr style='background-color:White;'>";
                            strFireBody += "<td class='cols' >" + drFire["VIN"].ToString() + "</td>";
                            strFireBody += "<td class='cols' >" + drFire["Make"].ToString() + "</td>";
                            strFireBody += "<td class='cols' >" + drFire["Model"].ToString() + "</td>";
                            strFireBody += "<td class='cols' >" + drFire["Year"].ToString() + "</td>";
                            if (!string.IsNullOrEmpty(Convert.ToString(drFire["Invoice_Value"])))
                                strFireBody += "<td class='cols' >" + "$ " + clsGeneral.GetStringValue(drFire["Invoice_Value"]) + "</td>";
                            else
                                strFireBody += "<td class='cols' >" + clsGeneral.GetStringValue(drFire["Invoice_Value"]) + "</td>";

                            strFireBody += "</tr>";
                            strFireBody += GetVehicleDetailForMail(drFire, "9");
                        }
                        strFireBody += "</table>";
                    }
                    strEbdy = strEbdy.Replace("[FireInfo]", strFireBody);
                }
                else
                {
                    //strEbdy = strEbdy.Replace("[tdViewFire]", "none");
                    strEbdy = strEbdy.Replace("<!--[tdViewFire] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewFire] -->", "-->");
                }
                #endregion

                #region Update Wind
                //check object value if it set to true display related section
                if (objDPD_FR.Wind == true)
                {
                    string strWindBody = "";
                    DataTable dtWind = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "10");
                    //used to Bind a table for Partial Theft vachicle for Email contact
                    if (dtWind.Rows.Count > 0)
                    {
                        strWindBody += "<table cellpadding='3' cellspacing='1' border='0' width='100%' style='background-color:Black;border-collapse: collapse;'>";

                        //make row of table as per record found.
                        for (int intWindCount = 0; intWindCount < dtWind.Rows.Count; intWindCount++)
                        {
                            strWindBody += "<tr class='PropertyInfoBG'>";
                            strWindBody += "<td style='width:20%' class='cols' >VIN</td>";
                            strWindBody += "<td style='width:20%' class='cols' >Vehicle Make</td>";
                            strWindBody += "<td style='width:20%' class='cols' >Model</td>";
                            strWindBody += "<td style='width:20%' class='cols' >Year</td>";
                            strWindBody += "<td style='width:20%' class='cols' >Invoice Value</td>";
                            strWindBody += "</tr>";
                            DataRow drWind = dtWind.Rows[intWindCount];
                            strWindBody += "<tr style='background-color:White;'>";
                            strWindBody += "<td class='cols' >" + drWind["VIN"].ToString() + "</td>";
                            strWindBody += "<td class='cols' >" + drWind["Make"].ToString() + "</td>";
                            strWindBody += "<td class='cols' >" + drWind["Model"].ToString() + "</td>";
                            strWindBody += "<td class='cols' >" + drWind["Year"].ToString() + "</td>";
                            if (!string.IsNullOrEmpty(Convert.ToString(drWind["Invoice_Value"])))
                                strWindBody += "<td class='cols' >" + "$ " + clsGeneral.GetStringValue(drWind["Invoice_Value"]) + "</td>";
                            else
                                strWindBody += "<td class='cols' >" + clsGeneral.GetStringValue(drWind["Invoice_Value"]) + "</td>";

                            strWindBody += "</tr>";
                            strWindBody += GetVehicleDetailForMail(drWind, "10");
                        }
                        strWindBody += "</table>";
                    }
                    strEbdy = strEbdy.Replace("[WindInfo]", strWindBody);
                }
                else
                {
                    //strEbdy = strEbdy.Replace("[tdViewWind]", "none");
                    strEbdy = strEbdy.Replace("<!--[tdViewWind] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewWind] -->", "-->");
                }
                #endregion

                #region Insert/Update values into DPD Vehicle Table for Fraud
                //chkViewFraud.Checked = objDPD_FR.Fraud;
                //check object value if it set to true display related section
                if (objDPD_FR.Fraud == true)
                {
                    string strFraudBody = "";
                    //strEbdy = strEbdy.Replace("[tdViewFraud]", "");
                    DataTable dtFraud = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "3");
                    //make tables stucture of select record from datatable for Email Body
                    if (dtFraud.Rows.Count > 0)
                    {
                        strFraudBody += "<table cellpadding='3' cellspacing='1' border='0' width='100%' style='background-color:Black;border-collapse: collapse;'>";

                        //Make a Row of table as per value of Datatable
                        for (int intFCount = 0; intFCount < dtFraud.Rows.Count; intFCount++)
                        {
                            strFraudBody += "<tr class='PropertyInfoBG'>";
                            strFraudBody += "<td class='cols' style='width:20%'>VIN</td>";
                            strFraudBody += "<td class='cols' style='width:20%'>Vehicle Make</td>";
                            strFraudBody += "<td class='cols' style='width:20%'>Model</td>";
                            strFraudBody += "<td class='cols' style='width:20%'>Year</td>";
                            strFraudBody += "<td class='cols' style='width:20%'>Invoice value</td>";
                            strFraudBody += "</tr>";

                            DataRow drFraud = dtFraud.Rows[intFCount];
                            strFraudBody += "<tr style='background-color:White;'>";
                            strFraudBody += "<td class='cols' >" + drFraud["VIN"].ToString() + "</td>";
                            strFraudBody += "<td class='cols' >" + drFraud["Make"].ToString() + "</td>";
                            strFraudBody += "<td class='cols' >" + drFraud["Model"].ToString() + "</td>";
                            strFraudBody += "<td class='cols' >" + drFraud["Year"].ToString() + "</td>";
                            if (!string.IsNullOrEmpty(Convert.ToString(drFraud["Invoice_Value"])))
                                strFraudBody += "<td class='cols' >" + "$ " + clsGeneral.GetStringValue(drFraud["Invoice_Value"]) + "</td>";
                            else
                                strFraudBody += "<td class='cols' >" + clsGeneral.GetStringValue(drFraud["Invoice_Value"]) + "</td>";
                            strFraudBody += "</tr>";

                            strFraudBody += GetVehicleDetailForMail(drFraud, "3");
                        }
                        strFraudBody += "</table>";
                    }
                    strEbdy = strEbdy.Replace("[FraudInfo]", strFraudBody);
                }
                else
                {
                    //strEbdy = strEbdy.Replace("[tdViewFraud]", "none");
                    strEbdy = strEbdy.Replace("<!--[tdViewFraud] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#tdViewFraud] -->", "-->");
                }
                #endregion
                #endregion
                #region Fill Witness
                string strWitnessBody = "";
                DataTable dtWitness = DPD_Witness.SelectByFK(PK_DPD_FR_ID).Tables[0];
                //used to Bind a table for Partial Theft vachicle for Email contact
                if (dtWitness.Rows.Count > 0)
                {
                    strWitnessBody += "<table cellpadding='3' cellspacing='1' border='0' width='100%' style='background-color:Black;border-collapse: collapse;'>";
                    strWitnessBody += "<tr class='PropertyInfoBG'>";
                    strWitnessBody += "<td style='width:33%' class='cols'>Name</td>";
                    strWitnessBody += "<td style='width:33%' class='cols'>Address</td>";
                    strWitnessBody += "<td style='width:34%' class='cols'>Phone</td>";
                    strWitnessBody += "</tr>";
                    //make row of table as per record found.
                    for (int intWitnessCount = 0; intWitnessCount < dtWitness.Rows.Count; intWitnessCount++)
                    {
                        DataRow drWitness = dtWitness.Rows[intWitnessCount];
                        strWitnessBody += "<tr style='background-color:White;'>";
                        strWitnessBody += "<td class='cols'>" + drWitness["Name"].ToString() + "</td>";
                        strWitnessBody += "<td class='cols'>" + drWitness["Address"].ToString() + "</td>";
                        strWitnessBody += "<td class='cols'>" + drWitness["Phone"].ToString() + "</td>";
                        strWitnessBody += "</tr>";
                    }
                    strWitnessBody += "</table>";
                }
                strEbdy = strEbdy.Replace("[WitnessInfo]", strWitnessBody);
                #endregion
                #region Fill Comments and Attachments
                strEbdy = strEbdy.Replace("[lblComments]", objDPD_FR.Comments);
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

    #region Use to Upload Files
    /// <summary>
    /// Used to Upload file rom Comment and Attachment Section
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {
        //Insert values into WC_FR_Attachment table
        CtrlAttachment.Add(clsGeneral.Tables.DPD_FR, PK_DPD_FR_ID);

        // Used to Bind Grid with Attached Data
        CtrlAttachDetails.Bind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
    }
    #endregion

    #region Bind Sonic Header INformation Controls
    /// <summary>
    /// used to set value to Sonic Header Control
    /// </summary>
    public void setSonicHeaderInfo()
    {
        //Create Object
        DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);
        SonicInfo.FirstReportNumber = "DPD-" + objDPD_FR.DPD_FR_Number.ToString();
        SonicInfo.SONICLocationdba = new LU_Location(objDPD_FR.FK_Loss_Location).dba.ToString();
        SonicInfo.DateOfIncident = clsGeneral.FormatDateToDisplay(objDPD_FR.Date_Of_Loss);

        DataTable dtClaimInfo = WC_ClaimInfo.Select_Claim_Number(Convert.ToInt32(objDPD_FR.DPD_FR_Number), "DPD");
        if (dtClaimInfo.Rows.Count > 0)
        {

            SonicInfo.CurrentReportType = (Controls_SONICInfo_SonicInfo.ReportType)(Enum.Parse(typeof(Controls_SONICInfo_SonicInfo.ReportType), Convert.ToString(dtClaimInfo.Rows[0]["ReportType"])));
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

    #region "Email Methods"

    /// <summary>
    /// Used to Bind defaut value(null)
    /// </summary>
    /// <param name="objDFV"></param>
    void BindNullToBitDatatype(DPD_FR_Vehicle objDFV)
    {
        objDFV.Driven_By_Associate = null;
        objDFV.Associate_Cited = null;
        objDFV.Vehicle_Driven_By_Customer = null;
        objDFV.Cutomer_Injured = null;
        objDFV.Vehicle_Recovered = null;
        objDFV.Dealership_Wish_To_Take_Possession = null;
        objDFV.Police_Notified = null;
        objDFV.Vehicle_In_Storage = null;
        objDFV.Associate_injured = null;
        objDFV.drug_test_performed = null;
        objDFV.Additional_passengers = null;
        objDFV.seeking_subrogation = null;
        objDFV.Notice_only_claim = null;

    }

    /// <summary>
    /// Button Click Event - Click to send email
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSendMail_Click(object sender, EventArgs e)
    {
        SendFROI();
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
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", " if(window.confirm('" + confirmMessage + "')){ __doPostBack('UserConfirmationPostBackView', 'true');} else { alert('The First Report has NOT been sent, please reduce the number and/or size of the attachments before attempting to resubmit with attachments.');ShowPanel(4); }", true);
                return;
            }
            if (ResendMail(true))
                ScriptManager.RegisterStartupScript(this, Page.GetType(), System.DateTime.Now.ToString(), "javascript:alert('First Report mail send successfully');ShowPanel(" + hdnCureentPanel.Value + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "alert('Something went wrong. Please try after sometime.'); window.location='FirstReportSearch.aspx';", true);
            
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnCureentPanel.Value + ");", true);
            //clsGeneral.ShowAlert("First Report mail send successfully", this.Page);
        }
    }

    /// <summary>
    /// Method to Send mail again
    /// </summary>
    /// <param name="_IsAttachment"></param>
    private bool ResendMail(bool _IsAttachment)
    {
        // Declare Object
        DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);

        int intAttCount = 0;
        //Insert values into DPD_FR_Attachment table
        CtrlAttachment.Add(clsGeneral.Tables.DPD_FR, PK_DPD_FR_ID);
        //Get Attachment Details
        DataTable dtAtt = DPD_FR_Attacments.SelectByFROL_ID(PK_DPD_FR_ID).Tables[0];
        string[] strAtt = new string[dtAtt.Rows.Count];
        if (_IsAttachment)
        {
            if (dtAtt.Rows.Count > 0)
            {
                foreach (DataRow drAtt in dtAtt.Rows)
                {
                    string strFileName = drAtt["Attachment_Path"].ToString();
                    strFileName = AppConfig.DPD_FRDocPath + strFileName;
                    strAtt[intAttCount] = strFileName;
                    intAttCount = intAttCount + 1;
                }

            }
        }
        //get recipient Id

        DataTable dtRecipient = LU_Location.GetRecipientEmailID(objDPD_FR.FK_Loss_Location, LU_Location.SonicReportType.DPD).Tables[0];
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
        if (First_Report_Wizard_ID > 0)
        {
            string ReturnFRNumber;
            string HtmlBody = GenerateEMailBody(out ReturnFRNumber);
            //string FR_Number = ReturnFRNumber.ToString() != string.Empty ? (ReturnFRNumber) : "0";
            decimal FR_Number = new DPD_FR(ReturnFRNumber.ToString() != string.Empty ? Convert.ToDecimal(ReturnFRNumber) : 0).DPD_FR_Number;

            if (EmailTo.Length > 0 && !string.IsNullOrEmpty(HtmlBody))
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));
                objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Repeat :: Sonic Automotive (acct #42979) reports the following First Report of Loss DPD-" + FR_Number.ToString(), HtmlBody, true, (_IsAttachment ? strAtt : new string[] { }), AppConfig.MailCC);

                return true;
            }
            else
                return false;
        }
        else
            return false;


    }

    /// <summary>
    /// method to send mail for First Report
    /// </summary>
    /// <param name="_IsAttachment"></param>
    private bool SendFirstReportMail(bool _IsAttachment)
    {
        DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);

        int intAttCount = 0;
        //Get Attachment Details
        DataTable dtAtt = DPD_FR_Attacments.SelectByFROL_ID(PK_DPD_FR_ID).Tables[0];
        string[] strAtt = new string[dtAtt.Rows.Count];
        if (_IsAttachment)
        {
            if (dtAtt.Rows.Count > 0)
            {
                foreach (DataRow drAtt in dtAtt.Rows)
                {
                    string strFileName = drAtt["Attachment_Path"].ToString();
                    strFileName = AppConfig.DPD_FRDocPath + strFileName;
                    strAtt[intAttCount] = strFileName;
                    intAttCount = intAttCount + 1;
                }

            }
        }
        //get recipient Id

        DataTable dtRecipient = LU_Location.GetRecipientEmailID(objDPD_FR.FK_Loss_Location, LU_Location.SonicReportType.DPD).Tables[0];
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
        if (First_Report_Wizard_ID > 0)
        {
            string ReturnFRNumber;
            string HtmlBody = GenerateEMailBody(out ReturnFRNumber);
            //string FR_Number = ReturnFRNumber.ToString() != string.Empty ? (ReturnFRNumber) : "0";
            decimal FR_Number = new DPD_FR(ReturnFRNumber.ToString() != string.Empty ? Convert.ToDecimal(ReturnFRNumber) : 0).DPD_FR_Number;
            //generate FIle and store it on disk
            StreamWriter sWriter = null;
            clsGeneral.CreateDirectory(AppConfig.SitePath + "SONIC-Email/" + clsSession.FirstName + "_" + clsSession.LastName + "/DPD_FR/" + DateTime.Today.ToString("MM-dd-yyyy"));
            string strName = AppConfig.SitePath + "SONIC-Email/" + clsSession.FirstName + "_" + clsSession.LastName + "/DPD_FR/" + DateTime.Today.ToString("MM-dd-yyyy") + "/DPD_FR_Email_" + FR_Number.ToString() + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
            string strAttachmentName = AppConfig.SitePath + "SONIC-Email/" + clsSession.FirstName + "_" + clsSession.LastName + "/DPD_FR/" + DateTime.Today.ToString("MM-dd-yyyy") + "/DPD_FR_Attachment_" + FR_Number.ToString() + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
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
                        //check file is physically exists or not.
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
            if (EmailTo.Length > 0 && !string.IsNullOrEmpty(HtmlBody))
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));
                if (_IsAttachment)

                    objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Sonic Automotive (acct #42979) reports the following First Report of Loss DPD-" + FR_Number.ToString(), HtmlBody, true, finalAttachment, AppConfig.MailCC);
                else
                    objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Sonic Automotive (acct #42979) reports the following First Report of Loss DPD-" + FR_Number.ToString(), HtmlBody, true, new string[] { }, AppConfig.MailCC);

                return true;
            }
            else
                return false;
        }
        else
            return false;
        //clsGeneral.SendMail(AppConfig.MailFrom, EmailTo, string.Empty, string.Empty, "Sonic Automotive reports the following First Report of Loss", HtmlBody, strAtt);
        //clsGeneral.SendMailMessage(AppConfig.MailFrom, EmailTo, string.Empty, string.Empty, "Sonic Automotive reports the following First Report of Loss", HtmlBody, true, strAtt);
    }

    /// <summary>
    /// Method to get Vehivle Details For Mail
    /// </summary>
    /// <param name="drVehicle"></param>
    /// <param name="Incident_Type"></param>
    /// <returns></returns>
    private string GetVehicleDetailForMail(DataRow drVehicle, string Incident_Type)
    {
        StringBuilder sbTheft = new StringBuilder(string.Empty);

        sbTheft.Append("<tr style='background-color:White;'><td width='100%' colspan='5' class='cols'>");

        #region "General Conotrols"

        sbTheft.Append("<table width='100%' cellpadding='3' cellspacing='0' style='border-collapse: collapse;'>");
        sbTheft.Append("<tr align='left'>");
        sbTheft.Append("<td style='width: 18%' align='left'>VIN#</td>");
        sbTheft.Append("<td style='width: 4%' align='center'>:</td>");
        sbTheft.Append("<td colspan='4' style='width: 78%'>" + Convert.ToString(drVehicle["VIN"]) + "</td>");
        sbTheft.Append("</tr>");
        sbTheft.Append("<tr>");
        sbTheft.Append("<td style='width: 18%' align='left'>Make</td>");
        sbTheft.Append("<td style='width: 4%' align='center'>:</td>");
        sbTheft.Append("<td align='left' colspan='4'>" + Convert.ToString(drVehicle["Make"]) + "</td>");
        sbTheft.Append("</tr>");
        sbTheft.Append("<tr align='left'>");
        sbTheft.Append("<td >Model</td>");
        sbTheft.Append("<td align='center'>:</td>");
        sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Model"]) + "</td>");
        sbTheft.Append("</tr>");
        sbTheft.Append("<tr>");
        sbTheft.Append("<td >Year</td>");
        sbTheft.Append("<td align='center'>:</td>");
        sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Year"]) + "</td>");
        sbTheft.Append("</tr>");

        if (Incident_Type.Equals("2"))
        {
            sbTheft.Append("<tr>");
            sbTheft.Append("<td >Vehicle Owner if not SONIC</td>");
            sbTheft.Append("<td align='center'>:</td>");
            sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Vehicle_Owner_Sonic"]) + "</td>");
            sbTheft.Append("</tr>");

            sbTheft.Append("<tr>");
            sbTheft.Append("<td >Vehicle Owner Address </td>");
            sbTheft.Append("<td align='center'>:</td>");
            sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Vehicle_Owner_Address"]) + "</td>");
            sbTheft.Append("</tr>");

            sbTheft.Append("<tr>");
            sbTheft.Append("<td >Vehicle Owner Phone</td>");
            sbTheft.Append("<td align='center'>:</td>");
            sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Vehicle_Owner_Phone"]) + "</td>");
            sbTheft.Append("</tr>");

        }

        sbTheft.Append("<tr>");
        sbTheft.Append("<td >Type of Vehicle</td>");
        sbTheft.Append("<td align='center'>:</td>");
        sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["TypeOfVehicle"]) + "</td>");
        sbTheft.Append("</tr>");
        sbTheft.Append("<tr>");
        sbTheft.Append("<td >Location of Vehicle</td>");
        sbTheft.Append("<td align='center'>:</td>");
        sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Present_Location"]) + "</td>");
        sbTheft.Append("</tr>");
        sbTheft.Append("<tr align='left'>");
        sbTheft.Append("<td >Location Address</td>");
        sbTheft.Append("<td align='center'>:</td>");
        sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Present_Address"]) + "</td>");
        sbTheft.Append("</tr>");
        sbTheft.Append("<tr align='left'>");
        sbTheft.Append("<td >Location State</td>");
        sbTheft.Append("<td align='center'>:</td>");
        sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Present_State"]) + "</td>");
        sbTheft.Append("</tr>");
        sbTheft.Append("<tr align='left'>");
        sbTheft.Append("<td >Location Zip</td>");
        sbTheft.Append("<td align='center'>:</td>");
        sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Present_Zip"]) + "</td>");
        sbTheft.Append("</tr>");

        sbTheft.Append("<tr>");
        sbTheft.Append("<td >Invoice Value</td>");
        sbTheft.Append("<td align='center'>:</td>");
        sbTheft.Append("<td colspan='4'>$" + clsGeneral.GetStringValue(drVehicle["Invoice_Value"] != DBNull.Value ? drVehicle["Invoice_Value"] : "0") + "</td>");
        sbTheft.Append("</tr>");

        sbTheft.Append("<tr>");
        sbTheft.Append("<td valign='top' align='left'>Loss Description</td>");
        sbTheft.Append("<td valign='top' align='center'>:</td>");
        sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Loss_Description"]) + "</td>");
        sbTheft.Append("</tr>");

        #endregion

        //Security_Video_Surveillance(for Theft,Partial Theft and Vandalism
        if (Incident_Type.Equals("4") || Incident_Type.Equals("5") || Incident_Type.Equals("6"))
        {
            sbTheft.Append("<tr>");
            sbTheft.Append("<td valign='top' align='left'>Is There a Security Video Surveillance System?</td>");
            sbTheft.Append("<td valign='top' align='center'>:</td>");
            sbTheft.Append("<td colspan='4'>" + GetYesNo(drVehicle["Security_Video_Surveillance"]) + "</td>");
            sbTheft.Append("</tr>");
        }


        if (Incident_Type.Equals("1") || Incident_Type.Equals("2"))
        {
            sbTheft.Append("<tr>");
            sbTheft.Append("<td valign='top' align='left'>Damage Estimate</td>");
            sbTheft.Append("<td valign='top' align='center'>:</td>");
            sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Damage_Estimate"]) + "</td>");
            sbTheft.Append("</tr>");

            sbTheft.Append("<tr>");
            sbTheft.Append("<td valign='top' align='left'>Was vehicle being driven by company associate?</td>");
            sbTheft.Append("<td valign='top' align='center'>:</td>");
            string strRetval = GetYesNo(drVehicle["Driven_By_Associate"]);
            sbTheft.Append("<td colspan='4'>" + strRetval + "</td>");
            sbTheft.Append("</tr>");

            if (strRetval == "No")
            {
                sbTheft.Append("<tr>");
                sbTheft.Append("<td valign='top' align='left' style='padding-left: 20px;'>If No, was vehicle being driven by customer?</td>");
                sbTheft.Append("<td valign='top' align='center'>:</td>");
                string strVehicleDriver = GetYesNo(drVehicle["Vehicle_Driven_By_Customer"]);
                sbTheft.Append("<td colspan='4'>" + strVehicleDriver + "</td>");
                sbTheft.Append("</tr>");

                if (strVehicleDriver == "No")
                {
                    sbTheft.Append("<tr>");
                    sbTheft.Append("<td valign='top' align='left' style='padding-left: 35px;'>If No, Explain</td>");
                    sbTheft.Append("<td valign='top' align='center'>:</td>");
                    sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Not_Driven_By_Customer_Explain"]) + "</td>");
                    sbTheft.Append("</tr>");
                }
                else
                {
                    sbTheft.Append("<tr>");
                    sbTheft.Append("<td valign='top' align='left' style='padding-left: 35px;'>If Yes, Name</td>");
                    sbTheft.Append("<td valign='top' align='center'>:</td>");
                    sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Name"]) + "</td>");
                    sbTheft.Append("</tr>");

                    sbTheft.Append("<tr>");
                    sbTheft.Append("<td valign='top' align='left' style='padding-left: 35px;'>If Yes, Address</td>");
                    sbTheft.Append("<td valign='top' align='center'>:</td>");
                    sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Address"]) + "</td>");
                    sbTheft.Append("</tr>");

                    sbTheft.Append("<tr>");
                    sbTheft.Append("<td valign='top' align='left' style='padding-left: 35px;'>If Yes, Phone</td>");
                    sbTheft.Append("<td valign='top' align='center'>:</td>");
                    sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Phone"]) + "</td>");
                    sbTheft.Append("</tr>");

                    sbTheft.Append("<tr>");
                    sbTheft.Append("<td valign='top' align='left' style='padding-left: 35px;'>If Yes, was associate cited for a violation? </td>");
                    sbTheft.Append("<td valign='top' align='center'>:</td>");
                    sbTheft.Append("<td colspan='4'>" + GetYesNo(drVehicle["Cutomer_Injured"]) + "</td>");
                    sbTheft.Append("</tr>");
                }
            }
            else
            {
                //sbTheft.Append("<tr> <td colspan='6' align='center'>");
                //sbTheft.Append("<table cellpadding='3' cellspacing='1' border='0' width='100%' style='border-collapse: collapse;'>");

                sbTheft.Append("<tr>");
                sbTheft.Append("<td style='width: 18%;padding-left: 20px;' valign='top' align='left'>If Yes, Name</td>");
                sbTheft.Append("<td style='width: 4%' valign='top' align='center'>:</td>");
                sbTheft.Append("<td style='width: 78%' colspan='4'>" + Convert.ToString(drVehicle["Name"]) + "</td>");
                sbTheft.Append("</tr>");

                sbTheft.Append("<tr>");
                sbTheft.Append("<td valign='top' align='left' style='padding-left: 20px;'>If Yes, Address</td>");
                sbTheft.Append("<td valign='top' align='center'>:</td>");
                sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Address"]) + "</td>");
                sbTheft.Append("</tr>");

                sbTheft.Append("<tr>");
                sbTheft.Append("<td valign='top' align='left' style='padding-left: 20px;'>If Yes, Phone</td>");
                sbTheft.Append("<td valign='top' align='center'>:</td>");
                sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Phone"]) + "</td>");
                sbTheft.Append("</tr>");

                string Associate_Cited = GetYesNo(drVehicle["Associate_Cited"]);
                sbTheft.Append("<tr>");
                sbTheft.Append("<td valign='top' align='left' style='padding-left: 20px;'>If Yes, was associate cited for a violation?</td>");
                sbTheft.Append("<td valign='top' align='center'>:</td>");
                sbTheft.Append("<td colspan='4'>" + Associate_Cited + "</td>");
                sbTheft.Append("</tr>");

                if (Associate_Cited == "Yes")
                {
                    sbTheft.Append("<tr>");
                    sbTheft.Append("<td valign='top' align='left' style='padding-left: 35px;'>If Yes, Description of citation</td>");
                    sbTheft.Append("<td valign='top' align='center'>:</td>");
                    sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["Description_Of_Citation"]) + "</td>");
                    sbTheft.Append("</tr>");
                }
                sbTheft.Append("<tr>");
                sbTheft.Append("<td valign='top' align='left' style='padding-left: 20px;'>If Yes, was the associcate injured?</td>");
                sbTheft.Append("<td valign='top' align='center'>:</td>");
                sbTheft.Append("<td colspan='4'>" + GetYesNo(drVehicle["Associate_injured"]) + "</td>");
                sbTheft.Append("</tr>");

                Associate_Cited = GetYesNo(drVehicle["drug_test_performed"]);
                sbTheft.Append("<tr>");
                sbTheft.Append("<td valign='top' align='left' style='padding-left: 20px;'>If Yes, was a post-accident drug test performed?</td>");
                sbTheft.Append("<td valign='top' align='center'>:</td>");
                sbTheft.Append("<td colspan='4'>" + Associate_Cited + "</td>");
                sbTheft.Append("</tr>");

                sbTheft.Append("<tr>");
                sbTheft.Append("<td valign='top' align='left' style='padding-left: 35px;'>If " + Associate_Cited + ", Explain</td>");
                sbTheft.Append("<td valign='top' align='center'>:</td>");
                sbTheft.Append("<td colspan='4'>" + (Associate_Cited == "No" ? Convert.ToString(drVehicle["drug_test_explanation"]) : Convert.ToString(drVehicle["drug_test_results"])) + "</td>");
                sbTheft.Append("</tr>");

                //sbTheft.Append("</table></td></tr>");
            }

            sbTheft.Append("<tr>");
            sbTheft.Append("<td valign='top' align='left'>Were other passengers in the vehicle besides the Associate and the Customer?</td>");
            sbTheft.Append("<td valign='top' align='center'>:</td>");
            strRetval = GetYesNo(drVehicle["Additional_passengers"]);
            sbTheft.Append("<td colspan='4'>" + strRetval + "</td>");
            sbTheft.Append("</tr>");

            if (strRetval == "Yes")
            {
                decimal VehicleID;
                decimal.TryParse(Convert.ToString(drVehicle["PK_DPD_FR_Vehicle_ID"]), out VehicleID);
                DataTable dtPassenger = DPD_FR_Injured_Passenger.SelectByVehicleID(VehicleID).Tables[0];
                sbTheft.Append("<tr> <td width='85%' colspan='6' align='center'>");
                sbTheft.Append("<table cellpadding='3' cellspacing='1' border='0' width='100%' style='background-color:Black;border-collapse: collapse;'>");

                if (dtPassenger.Rows.Count > 0)
                {
                    for (int i = 0; i < dtPassenger.Rows.Count; i++)
                    {
                        string strState = new ERIMS.DAL.State(!string.IsNullOrEmpty(Convert.ToString(dtPassenger.Rows[i]["State"])) ? Convert.ToDecimal(dtPassenger.Rows[i]["State"]) : 0).FLD_state;
                        sbTheft.Append("<tr class='PropertyInfoBG'>");
                        sbTheft.Append("<td class='cols' style='width:20%'>Name</td>");
                        sbTheft.Append("<td class='cols' style='width:20%'>Address 1</td>");
                        sbTheft.Append("<td class='cols' style='width:20%'>City</td>");
                        sbTheft.Append("<td class='cols' style='width:20%'>State</td>");
                        sbTheft.Append("<td class='cols' style='width:20%'>Zip</td>");
                        sbTheft.Append("</tr>");
                        sbTheft.Append("<tr style='background-color:White'>");
                        sbTheft.Append("<td class='cols' style='width:20%'>" + Convert.ToString(dtPassenger.Rows[i]["name"]) + "</td>");
                        sbTheft.Append("<td class='cols' style='width:20%'>" + Convert.ToString(dtPassenger.Rows[i]["Address_1"]) + "</td>");
                        sbTheft.Append("<td class='cols' style='width:20%'>" + Convert.ToString(dtPassenger.Rows[i]["City"]) + "</td>");
                        sbTheft.Append("<td class='cols' style='width:20%'>" + strState + "</td>");
                        sbTheft.Append("<td class='cols' style='width:20%'>" + Convert.ToString(dtPassenger.Rows[i]["Zip_Code"]) + "</td>");
                        sbTheft.Append("</tr>");

                        sbTheft.Append("<tr style='background-color:White;'><td width='100%' colspan='5' class='cols'>");
                        sbTheft.Append("<table cellpadding='3' cellspacing='1' border='0' width='100%' style='background-color:White;border-collapse: collapse;'>");

                        sbTheft.Append("<tr valign='top' align='left'>");
                        sbTheft.Append("<td width='18%'>Contact Name </td>");
                        sbTheft.Append("<td width='4%' align='center'>:</td>");
                        sbTheft.Append("<td width='28%'>" + Convert.ToString(dtPassenger.Rows[i]["name"]) + "</td>");
                        sbTheft.Append("</tr>");

                        sbTheft.Append("<tr valign='top' align='left'>");
                        sbTheft.Append("<td width='18%'>Address 1 </td>");
                        sbTheft.Append("<td width='4%' align='center'>:</td>");
                        sbTheft.Append("<td width='28%'>" + Convert.ToString(dtPassenger.Rows[i]["Address_1"]) + "</td>");

                        sbTheft.Append("<tr valign='top' align='left'>");
                        sbTheft.Append("<td>Address 2 </td>");
                        sbTheft.Append("<td align='center'>:</td>");
                        sbTheft.Append("<td>" + Convert.ToString(dtPassenger.Rows[i]["Address_2"]) + "</td>");
                        sbTheft.Append("<td width='18%'>Phone </td>");
                        sbTheft.Append("<td width='4%' align='center'>:</td>");
                        sbTheft.Append("<td width='28%'>" + Convert.ToString(dtPassenger.Rows[i]["phone"]) + "</td>");

                        sbTheft.Append("<tr valign='top' align='left'>");
                        sbTheft.Append("<td>City  </td>");
                        sbTheft.Append("<td align='center'>:</td>");
                        sbTheft.Append("<td>" + Convert.ToString(dtPassenger.Rows[i]["City"]) + "</td>");
                        sbTheft.Append("<td width='18%'>Injured? </td>");
                        sbTheft.Append("<td width='4%' align='center'>:</td>");
                        sbTheft.Append("<td width='28%'>" + GetYesNo(dtPassenger.Rows[i]["injured"]) + "</td>");

                        sbTheft.Append("<tr valign='top' align='left'>");
                        sbTheft.Append("<td>Storage State </td>");
                        sbTheft.Append("<td align='center'>:</td>");
                        sbTheft.Append("<td colspan='4'>" + strState + "</td>");
                        sbTheft.Append("</tr>");

                        sbTheft.Append("<tr valign='top' align='left'>");
                        sbTheft.Append("<td>Storage Zip </td>");
                        sbTheft.Append("<td align='center'>:</td>");
                        sbTheft.Append("<td colspan='4'>" + Convert.ToString(dtPassenger.Rows[i]["Zip_Code"]) + "</td>");
                        sbTheft.Append("</tr>");

                        sbTheft.Append("</table></td></tr>");
                    }
                }
                else
                {
                    sbTheft.Append("<tr style='background-color:White'>");
                    sbTheft.Append("<td class='cols' style='width:100%' colspan='5'> No Record found </td>");
                    sbTheft.Append("</tr>");
                }
                sbTheft.Append("</table></td></tr>");
            }

            sbTheft.Append("<tr>");
            sbTheft.Append("<td valign='top' align='left'>Is the dealership seeking subrogation from a third party?</td>");
            sbTheft.Append("<td valign='top' align='center'>:</td>");
            strRetval = GetYesNo(drVehicle["seeking_subrogation"]);
            sbTheft.Append("<td colspan='4'>" + strRetval + "</td>");
            sbTheft.Append("</tr>");

            if (strRetval == "Yes")
            {
                sbTheft.Append("<tr> <td width='100%' colspan='6' align='center' >");
                sbTheft.Append("<table cellpadding='3' cellspacing='0' border='0' width='95%' style='background-color:White;border-collapse: collapse;'>");

                sbTheft.Append("<tr valign='top' align='left'>");
                sbTheft.Append("<td width='100%' colspan='6'>If Yes, provide Third Party Insurer Information </td>");
                sbTheft.Append("</tr>");

                sbTheft.Append("<tr valign='top' align='left'>");
                sbTheft.Append("<td width='18%'>Carrier Name </td>");
                sbTheft.Append("<td width='4%' align='center'>:</td>");
                sbTheft.Append("<td width='28%'>" + Convert.ToString(drVehicle["TPI_Carrier_name"]) + "</td>");
                sbTheft.Append("<td width='18%'>Contact Name </td>");
                sbTheft.Append("<td width='4%' align='center'>:</td>");
                sbTheft.Append("<td width='28%'>" + Convert.ToString(drVehicle["tpi_contact"]) + "</td>");
                sbTheft.Append("</tr>");

                sbTheft.Append("<tr valign='top' align='left'>");
                sbTheft.Append("<td width='18%'>Policy Number </td>");
                sbTheft.Append("<td width='4%' align='center'>:</td>");
                sbTheft.Append("<td width='28%'>" + Convert.ToString(drVehicle["TPI_Policy_number"]) + "</td>");
                sbTheft.Append("<td>Phone </td>");
                sbTheft.Append("<td align='center'>:</td>");
                sbTheft.Append("<td>" + Convert.ToString(drVehicle["tpi_phone"]) + "</td>");
                sbTheft.Append("</tr>");

                sbTheft.Append("<tr valign='top' align='left'>");
                sbTheft.Append("<td width='18%'>Address 1 </td>");
                sbTheft.Append("<td width='4%' align='center'>:</td>");
                sbTheft.Append("<td width='28%'>" + Convert.ToString(drVehicle["tpi_Address_1"]) + "</td>");


                sbTheft.Append("<tr valign='top' align='left'>");
                sbTheft.Append("<td>Address 2 </td>");
                sbTheft.Append("<td align='center'>:</td>");
                sbTheft.Append("<td>" + Convert.ToString(drVehicle["tpi_Address_2"]) + "</td>");

                sbTheft.Append("<tr valign='top' align='left'>");
                sbTheft.Append("<td>City  </td>");
                sbTheft.Append("<td align='center'>:</td>");
                sbTheft.Append("<td>" + Convert.ToString(drVehicle["tpi_City"]) + "</td>");

                sbTheft.Append("<tr valign='top' align='left'>");
                sbTheft.Append("<td>Storage State </td>");
                sbTheft.Append("<td align='center'>:</td>");
                sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["tpi_State"]) + "</td>");
                sbTheft.Append("</tr>");

                sbTheft.Append("<tr valign='top' align='left'>");
                sbTheft.Append("<td>Storage Zip </td>");
                sbTheft.Append("<td align='center'>:</td>");
                sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["tpi_Zip_Code"]) + "</td>");
                sbTheft.Append("</tr>");
                sbTheft.Append("</table></td></tr>");

            }
            else
            {
                sbTheft.Append("<tr>");
                sbTheft.Append("<td valign='top' align='left' style='padding-left: 30px;'>If No, is this a notice-only Claim?</td>");
                sbTheft.Append("<td valign='top' align='center'>:</td>");
                strRetval = GetYesNo(drVehicle["Notice_only_claim"]);
                sbTheft.Append("<td colspan='4'>" + strRetval + "</td>");
                sbTheft.Append("</tr>");
            }

            sbTheft.Append("<tr>");
            sbTheft.Append("<td valign='top' align='left'>Recovered Amount?</td>");
            sbTheft.Append("<td valign='top' align='center'>:</td>");
            sbTheft.Append("<td colspan='4'>" + clsGeneral.GetStringValue(drVehicle["recovered_amount"] == DBNull.Value ? "0" : drVehicle["recovered_amount"]) + "</td>");
            sbTheft.Append("</tr>");
        }

        #region "Custom Region"
        if (Incident_Type.Equals("4") || Incident_Type.Equals("3"))
        {
            sbTheft.Append("<tr>");
            sbTheft.Append("<td valign='top' align='left'>Was the Vehicle Recovered?</td>");
            sbTheft.Append("<td valign='top' align='center'>:</td>");
            string strRetval = GetYesNo(drVehicle["Vehicle_Recovered"]);
            sbTheft.Append("<td colspan='4'>" + strRetval + "</td>");
            sbTheft.Append("</tr>");

            if (strRetval == "Yes")
            {
                sbTheft.Append("<tr valign='top' align='left'>");
                sbTheft.Append("<td style='padding-left:10px'>If Yes, damage amount</td>");
                sbTheft.Append("<td align='center'>:</td>");
                sbTheft.Append("<td>$" + clsGeneral.GetStringValue(drVehicle["Damage_Estimate"] == DBNull.Value ? "0" : drVehicle["Damage_Estimate"]) + "</td>");
                sbTheft.Append("</tr>");
                sbTheft.Append("<tr valign='top' align='left' >");
                sbTheft.Append("<td style='padding-left:10px'>If Yes, does the dealership wish to take possession?</td>");
                sbTheft.Append("<td align='center'>:</td>");
                sbTheft.Append("<td >" + GetYesNo(drVehicle["Dealership_Wish_To_Take_Possession"]) + "</td>");
                sbTheft.Append("</tr>");
            }

            sbTheft.Append("<tr>");
            sbTheft.Append("<td valign='top' align='left'>Is the Vehicle in storage?</td>");
            sbTheft.Append("<td valign='top' align='center'>:</td>");
            strRetval = GetYesNo(drVehicle["Vehicle_In_Storage"]);
            sbTheft.Append("<td colspan='4'>" + strRetval + "</td>");
            sbTheft.Append("</tr>");

            if (strRetval == "Yes")
            {
                sbTheft.Append("<tr valign='top' align='left'>");
                sbTheft.Append("<td width='18%' style='padding-left:10px'>Address 1 </td>");
                sbTheft.Append("<td width='4%' align='center'>:</td>");
                sbTheft.Append("<td width='28%'>" + Convert.ToString(drVehicle["storage_Address_1"]) + "</td>");
                sbTheft.Append("<td width='18%'>Contact Name </td>");
                sbTheft.Append("<td width='4%' align='center'>:</td>");
                sbTheft.Append("<td width='28%'>" + Convert.ToString(drVehicle["Storage_Contact"]) + "</td>");
                sbTheft.Append("</tr>");

                sbTheft.Append("<tr valign='top' align='left'>");
                sbTheft.Append("<td style='padding-left:10px'>Address 2 </td>");
                sbTheft.Append("<td align='center'>:</td>");
                sbTheft.Append("<td>" + Convert.ToString(drVehicle["storage_Address_2"]) + "</td>");
                sbTheft.Append("<td>Storage Phone </td>");
                sbTheft.Append("<td align='center'>:</td>");
                sbTheft.Append("<td>" + Convert.ToString(drVehicle["Storage_phone"]) + "</td>");
                sbTheft.Append("</tr>");

                sbTheft.Append("<tr valign='top' align='left'>");
                sbTheft.Append("<td style='padding-left:10px'>City  </td>");
                sbTheft.Append("<td align='center'>:</td>");
                sbTheft.Append("<td>" + Convert.ToString(drVehicle["storage_City"]) + "</td>");
                sbTheft.Append("<td>Cost of Storage </td>");
                sbTheft.Append("<td align='center'>:</td>");
                sbTheft.Append("<td>" + Convert.ToString(drVehicle["storage_cost"]) + "</td>");
                sbTheft.Append("</tr>");

                sbTheft.Append("<tr valign='top' align='left'>");
                sbTheft.Append("<td style='padding-left:10px'>Storage State </td>");
                sbTheft.Append("<td align='center'>:</td>");
                sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["storage_State"]) + "</td>");
                sbTheft.Append("</tr>");

                sbTheft.Append("<tr valign='top' align='left'>");
                sbTheft.Append("<td style='padding-left:10px'>Storage Zip </td>");
                sbTheft.Append("<td align='center'>:</td>");
                sbTheft.Append("<td colspan='4'>" + Convert.ToString(drVehicle["storage_Zip_Code"]) + "</td>");
                sbTheft.Append("</tr>");
            }

            if (Incident_Type.Equals("3"))
            {
                sbTheft.Append("<tr valign='top' align='left'>");
                sbTheft.Append("<td>Were Police Notified?</td>");
                strRetval = GetYesNo(drVehicle["Police_Notified"]);
                sbTheft.Append("<td align='center'>:</td>");
                sbTheft.Append("<td>" + strRetval + "</td>");
                sbTheft.Append("</tr>");
                if (strRetval == "Yes")
                {
                    sbTheft.Append("<tr valign='top' align='left' >");
                    sbTheft.Append("<td >Police Report Number</td>");
                    sbTheft.Append("<td align='center'>:</td>");
                    sbTheft.Append("<td >" + Convert.ToString(drVehicle["Police_Report_Number"]) + "</td>");
                    sbTheft.Append("</tr>");
                }
            }
        }
        #endregion

        sbTheft.Append("</table></td></tr>");
        return sbTheft.ToString();
    }

    /// <summary>
    /// Method to Get yes or no value for Radio button
    /// </summary>
    /// <param name="ObjValue"></param>
    /// <returns></returns>
    private string GetYesNo(object ObjValue)
    {
        if (ObjValue != null && ObjValue != DBNull.Value)
        {
            if (Convert.ToBoolean(ObjValue) == true)
                return "Yes";
            else
                return "No";
        }
        return "No";
    }

    #endregion

    /// <summary>
    /// Binds attachment type dropdown in attachment control
    /// </summary>
    /// <param name="strCauseSelected"></param>
    private void BindAttachmentTypes(string strCauseSelected)
    {
        // get all attachment type dropdowns and clear
        DropDownList[] drpDwn = new DropDownList[5];
        drpDwn[0] = (DropDownList)CtrlAttachment.FindControl("drpAttachType1");
        drpDwn[1] = (DropDownList)CtrlAttachment.FindControl("drpAttachType2");
        drpDwn[2] = (DropDownList)CtrlAttachment.FindControl("drpAttachType3");
        drpDwn[3] = (DropDownList)CtrlAttachment.FindControl("drpAttachType4");
        drpDwn[4] = (DropDownList)CtrlAttachment.FindControl("drpAttachType5");
        foreach (DropDownList drp in drpDwn)
        {
            drp.Items.Clear();
        }

        // if causes are selected
        if (!string.IsNullOrEmpty(strCauseSelected))
        {
            //  get attachment types as per selected causes
            DataSet dsAttachType = new DataSet();
            dsAttachType.ReadXml(AppConfig.SitePath + "App_Data\\DPDAttachmentTypes.xml");
            DataTable dtAttachType = dsAttachType.Tables[0];
            dtAttachType.DefaultView.RowFilter = "CauseID in (" + strCauseSelected.Replace("5", "4") + ")";
            dtAttachType.DefaultView.Sort = "CauseOfLoss asc";

            // bind each dropdown
            foreach (DropDownList drp in drpDwn)
            {

                drp.DataSource = dtAttachType.DefaultView;
                drp.DataTextField = "TypeDesc";
                drp.DataValueField = "TypeDesc";
                drp.DataBind();
                drp.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        else
        {
            foreach (DropDownList drp in drpDwn)
            {
                drp.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
    }

    private void SendFROI()
    {
        clsFROI_Output objFROI = new clsFROI_Output();
        objFROI.FROI_Type = "DPD";
        objFROI.FROI_Number = Convert.ToDecimal(((Label)SonicInfo.FindControl("lblFirstReportNumber")).Text.Trim().Replace("DPD-", ""));
        objFROI.Insert();
    }
    protected void gvWitnessesView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //used to check Row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkViewWitness");
            //check link button is null or not.
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    //#endregion

    public int PK_DPD_FR_Vehicle_ID_1
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_DPD_FR_Vehicle_ID"]);
        }
        set { ViewState["PK_DPD_FR_Vehicle_ID"] = value; }
    }

    protected void btnAddVehicle_Click(object sender, EventArgs e)
    {
        foreach (int i in lstCauseOfLoss.GetSelectedIndices())
        {
            DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);

            DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_DPD_FR_Vehicle_ID);
            objDFV.FK_DPD_FR_ID = PK_DPD_FR_ID;
            objDFV.VIN = txt_VIN.Text;
            objDFV.Make = txt_Make.Text;
            objDFV.Model = txt_Model.Text;
            objDFV.Year = string.IsNullOrEmpty(txt_Year.Text) ? 0 : Convert.ToDecimal(txt_Year.Text);
            objDFV.TypeOfVehicle = (ddl_TypeOfVehicle.SelectedIndex > 0) ? ddl_TypeOfVehicle.SelectedValue : "";
            objDFV.Present_Location = txt_Present_Location.Text;
            objDFV.Present_Address = txt_Present_Address.Text;
            objDFV.Present_State = (ddl_Present_State.SelectedIndex > 0) ? ddl_Present_State.SelectedValue.ToString() : "0";
            objDFV.Present_Zip = txt_Present_Zip.Text;
            objDFV.Invoice_Value = string.IsNullOrEmpty(txt_Invoice_Value.Text) ? 0 : Convert.ToDecimal(txt_Invoice_Value.Text);
            objDFV.Loss_Description = txt_Loss_Description.Text;

            switch (lstCauseOfLoss.Items[i].Value)
            {
                //Theft
                case "1":
                    #region Theft
                    objDFV.Incident_Type = "4";
                    if (rdo_Vehicle_Recovered.SelectedValue == "1")
                    {
                        objDFV.Vehicle_Recovered = true;
                    }
                    else if (rdo_Vehicle_Recovered.SelectedValue == "0")
                    {
                        objDFV.Vehicle_Recovered = false;
                    }
                    else
                        objDFV.Vehicle_Recovered = null;

                    if (objDFV.Vehicle_Recovered == true)
                    {
                        objDFV.Damage_Estimate = string.IsNullOrEmpty(txt_Damage_estimate.Text) ? 0 : Convert.ToDecimal(txt_Damage_estimate.Text);
                        if (rdo_Dealership_Wish_To_Take_Possession.SelectedValue == "1")
                        {
                            objDFV.Dealership_Wish_To_Take_Possession = true;
                        }
                        else if (rdo_Dealership_Wish_To_Take_Possession.SelectedValue == "0")
                        {
                            objDFV.Dealership_Wish_To_Take_Possession = false;
                        }
                        else
                            objDFV.Dealership_Wish_To_Take_Possession = null;

                    }
                    else
                    {
                        objDFV.Damage_Estimate = null;
                        objDFV.Dealership_Wish_To_Take_Possession = null;
                    }

                    if (rdoVehicle_In_Storage.SelectedValue == "1")
                    {
                        objDFV.Vehicle_In_Storage = true;
                    }
                    else if (rdoVehicle_In_Storage.SelectedValue == "0")
                    {
                        objDFV.Vehicle_In_Storage = false;
                    }
                    else
                        objDFV.Vehicle_In_Storage = null;

                    if (objDFV.Vehicle_In_Storage == true)
                    {
                        objDFV.storage_Address_1 = txt_Storage_Address_1.Text;
                        objDFV.storage_Address_2 = txt_Storage_Address_2.Text;
                        objDFV.Storage_Contact = txt_Storage_Contact.Text;
                        objDFV.Storage_phone = txt_Storage_phone.Text;
                        objDFV.storage_City = txt_Storage_City.Text;
                        objDFV.storage_cost = string.IsNullOrEmpty(txt_Storage_cost.Text) ? 0 : Convert.ToDecimal(txt_Storage_cost.Text);
                        objDFV.storage_State = (ddl_Storage_State.SelectedIndex > 0) ? ddl_Storage_State.SelectedValue.ToString() : "0";
                        objDFV.storage_Zip_Code = txt_storage_Zip_Code.Text;
                    }
                    if (rdoTheft_Security_Video_Surveillance.SelectedValue == "1")
                    {
                        objDFV.Security_Video_Surveillance = true;
                    }
                    else if (rdoTheft_Security_Video_Surveillance.SelectedValue == "0")
                    {
                        objDFV.Security_Video_Surveillance = false;
                    }
                    else
                        objDFV.Security_Video_Surveillance = null;
                    objDPD_FR.Theft = true;
                    #endregion
                    break;

                //Partial Theft
                case "2":
                    objDFV.Incident_Type = "5";
                    if (rdoTheft_Security_Video_Surveillance.SelectedValue == "1")
                    {
                        objDFV.Security_Video_Surveillance = true;
                    }
                    else if (rdoTheft_Security_Video_Surveillance.SelectedValue == "0")
                    {
                        objDFV.Security_Video_Surveillance = false;
                    }
                    else
                        objDFV.Security_Video_Surveillance = null;
                    objDPD_FR.Partial_Theft = true;
                    break;

                //Vandalism
                case "3":
                    objDFV.Incident_Type = "6";
                    if (rdoTheft_Security_Video_Surveillance.SelectedValue == "1")
                    {
                        objDFV.Security_Video_Surveillance = true;
                    }
                    else if (rdoTheft_Security_Video_Surveillance.SelectedValue == "0")
                    {
                        objDFV.Security_Video_Surveillance = false;
                    }
                    else
                        objDFV.Security_Video_Surveillance = null;
                    objDPD_FR.Vandalism = true;
                    break;

                //MVA – Damage (Single Vehicle)
                case "4":
                    #region MVA – Damage (Single Vehicle)
                    objDFV.Incident_Type = "1";
                    objDFV.Damage_Estimate = string.IsNullOrEmpty(txtMVA_MultiDamage_Estimate.Text) ? 0 : Convert.ToDecimal(txtMVA_MultiDamage_Estimate.Text);
                    if (rdoMVA_MultiDriven_By_Associate.SelectedValue == "1")
                        objDFV.Driven_By_Associate = true;
                    else if (rdoMVA_MultiDriven_By_Associate.SelectedValue == "0")
                        objDFV.Driven_By_Associate = false;
                    else
                        objDFV.Driven_By_Associate = null;

                    if (objDFV.Driven_By_Associate == true)
                    {
                        objDFV.Name = txtMVA_MultiName_Yes.Text;
                        objDFV.Address = txtMVA_MultiAddress_Yes.Text;
                        objDFV.Phone = txtMVA_MultiPhone_Yes.Text;
                        if (rdoMVA_MultiAssociate_Cited.SelectedValue == "1")
                            objDFV.Associate_Cited = true;
                        else if (rdoMVA_MultiAssociate_Cited.SelectedValue == "0")
                            objDFV.Associate_Cited = false;
                        else
                            objDFV.Associate_Cited = null;

                        if (objDFV.Associate_Cited == true)
                        {
                            objDFV.Description_Of_Citation = txtMVA_MultiDescription_Of_Citation.Text;
                        }
                        if (rdoMVA_MultiAssociate_injured.SelectedValue == "1")
                            objDFV.Associate_injured = true;
                        else if (rdoMVA_MultiAssociate_injured.SelectedValue == "0")
                            objDFV.Associate_injured = false;
                        else
                            objDFV.Associate_injured = null;

                        if (rdoMVA_MultiDrug_test_performed.SelectedValue == "1")
                            objDFV.drug_test_performed = true;
                        else if (rdoMVA_MultiDrug_test_performed.SelectedValue == "0")
                            objDFV.drug_test_performed = false;
                        else
                            objDFV.drug_test_performed = null;

                        if (objDFV.drug_test_performed == true)
                        {
                            objDFV.drug_test_results = txtMVA_MultiDrug_test_results.Text;
                        }
                        else if (objDFV.drug_test_performed == false)
                        {
                            objDFV.drug_test_explanation = txtMVA_MultiDrug_test_explanation.Text;
                        }
                    }
                    else if (objDFV.Driven_By_Associate == false)
                    {
                        if (rdoMVA_MultiVehicle_Driven_By_Customer.SelectedValue == "1")
                            objDFV.Vehicle_Driven_By_Customer = true;
                        else if (rdoMVA_MultiVehicle_Driven_By_Customer.SelectedValue == "0")
                            objDFV.Vehicle_Driven_By_Customer = false;
                        else
                            objDFV.Vehicle_Driven_By_Customer = null;

                        if (objDFV.Vehicle_Driven_By_Customer == true)
                        {
                            objDFV.Name = txtMVA_MultiName_No.Text;
                            objDFV.Address = txtMVA_MultiAddress_No.Text;
                            objDFV.Phone = txtMVA_MultiPhone_No.Text;
                            if (rdoMVA_Multicustomer_injured.SelectedValue == "1")
                                objDFV.Cutomer_Injured = true;
                            else if (rdoMVA_Multicustomer_injured.SelectedValue == "0")
                                objDFV.Cutomer_Injured = false;
                            else
                                objDFV.Cutomer_Injured = null;

                        }
                        else
                        {
                            objDFV.Not_Driven_By_Customer_Explain = txtMVA_MultiNot_Driven_By_Customer_Explain.Text;
                            objDFV.Name = "";
                            objDFV.Address = "";
                            objDFV.Phone = "";
                        }
                    }

                    if (rdoMVA_MultiAdditional_passengers.SelectedValue == "1")
                        objDFV.Additional_passengers = true;
                    else if (rdoMVA_MultiAdditional_passengers.SelectedValue == "0")
                        objDFV.Additional_passengers = false;
                    else
                        objDFV.Additional_passengers = null;

                    if (objDFV.Additional_passengers == false)
                    {
                        DPD_FR_Injured_Passenger.DeleteByVehicleID(PK_DPD_FR_Single_Vehicle_ID);
                        //Bind Grid
                        BindPassengerGrid(gvMVAMulti_Passenger, PK_DPD_FR_Single_Vehicle_ID);
                    }
                    if (rdoMVA_MultiSeeking_subrogation.SelectedValue == "1")
                        objDFV.seeking_subrogation = true;
                    else if (rdoMVA_MultiSeeking_subrogation.SelectedValue == "0")
                        objDFV.seeking_subrogation = false;
                    else
                        objDFV.seeking_subrogation = null;

                    if (objDFV.seeking_subrogation == true)
                    {
                        objDFV.TPI_Carrier_name = txtMVA_MultiTPI_Carrier_name.Text;
                        objDFV.tpi_contact = txtMVA_Multitpi_contact.Text;
                        objDFV.TPI_Policy_number = txtMVA_MultiTPI_Policy_number.Text;
                        objDFV.tpi_phone = txtMVA_Multitpi_phone.Text;
                        objDFV.tpi_Address_1 = txtMVA_Multitpi_address_1.Text;
                        objDFV.tpi_Address_2 = txtMVA_Multitpi_address_2.Text;
                        objDFV.tpi_City = txtMVA_Multitpi_City.Text;
                        objDFV.tpi_State = (ddlMVA_Multitpi_State.SelectedIndex > 0) ? ddlMVA_Multitpi_State.SelectedValue.ToString() : "0";
                        objDFV.tpi_Zip_Code = txtMVA_Multitpi_Zip_Code.Text;
                        objDFV.recovered_amount = string.IsNullOrEmpty(txtMVA_MultiRecovered_Amount.Text) ? 0 : Convert.ToDecimal(txtMVA_MultiRecovered_Amount.Text);
                    }
                    else
                    {
                        if (rdoMVA_MultiNotice_only_claim.SelectedValue == "1")
                            objDFV.Notice_only_claim = true;
                        else if (rdoMVA_MultiNotice_only_claim.SelectedValue == "0")
                            objDFV.Notice_only_claim = false;
                        else
                            objDFV.Notice_only_claim = null;

                        objDFV.recovered_amount = string.IsNullOrEmpty(txtMVA_MultiRecovered_Amount.Text.Trim()) ? 0 : Convert.ToDecimal(txtMVA_MultiRecovered_Amount.Text);
                    }
                    objDPD_FR.MVA_Single = true;
                    #endregion
                    break;

                //MVA – Damage (Multiple Vehicle)
                case "5":
                    #region MVA – Damage (Multiple Vehicle)
                    objDFV.Vehicle_Owner_Sonic = txtMVA_MultiVehicle_Owner_Sonic.Text;
                    objDFV.Vehicle_Owner_Address = txtMVA_MultiVehicle_Owner_Address.Text;
                    objDFV.Vehicle_Owner_Phone = txtMVA_MultiVehicle_Owner_Phone.Text;
                    objDFV.Incident_Type = "2";
                    objDFV.Damage_Estimate = string.IsNullOrEmpty(txtMVA_MultiDamage_Estimate.Text) ? 0 : Convert.ToDecimal(txtMVA_MultiDamage_Estimate.Text);
                    if (rdoMVA_MultiDriven_By_Associate.SelectedValue == "1")
                        objDFV.Driven_By_Associate = true;
                    else if (rdoMVA_MultiDriven_By_Associate.SelectedValue == "0")
                        objDFV.Driven_By_Associate = false;
                    else
                        objDFV.Driven_By_Associate = null;

                    if (objDFV.Driven_By_Associate == true)
                    {
                        objDFV.Name = txtMVA_MultiName_Yes.Text;
                        objDFV.Address = txtMVA_MultiAddress_Yes.Text;
                        objDFV.Phone = txtMVA_MultiPhone_Yes.Text;
                        if (rdoMVA_MultiAssociate_Cited.SelectedValue == "1")
                            objDFV.Associate_Cited = true;
                        else if (rdoMVA_MultiAssociate_Cited.SelectedValue == "0")
                            objDFV.Associate_Cited = false;
                        else
                            objDFV.Associate_Cited = null;

                        if (objDFV.Associate_Cited == true)
                        {
                            objDFV.Description_Of_Citation = txtMVA_MultiDescription_Of_Citation.Text;
                        }
                        if (rdoMVA_MultiAssociate_injured.SelectedValue == "1")
                            objDFV.Associate_injured = true;
                        else if (rdoMVA_MultiAssociate_injured.SelectedValue == "0")
                            objDFV.Associate_injured = false;
                        else
                            objDFV.Associate_injured = null;

                        if (rdoMVA_MultiDrug_test_performed.SelectedValue == "1")
                            objDFV.drug_test_performed = true;
                        else if (rdoMVA_MultiDrug_test_performed.SelectedValue == "0")
                            objDFV.drug_test_performed = false;
                        else
                            objDFV.drug_test_performed = null;

                        if (objDFV.drug_test_performed == true)
                        {
                            objDFV.drug_test_results = txtMVA_MultiDrug_test_results.Text;
                        }
                        else if (objDFV.drug_test_performed == false)
                        {
                            objDFV.drug_test_explanation = txtMVA_MultiDrug_test_explanation.Text;
                        }
                    }
                    else if (objDFV.Driven_By_Associate == false)
                    {
                        if (rdoMVA_MultiVehicle_Driven_By_Customer.SelectedValue == "1")
                            objDFV.Vehicle_Driven_By_Customer = true;
                        else if (rdoMVA_MultiVehicle_Driven_By_Customer.SelectedValue == "0")
                            objDFV.Vehicle_Driven_By_Customer = false;
                        else
                            objDFV.Vehicle_Driven_By_Customer = null;

                        if (objDFV.Vehicle_Driven_By_Customer == true)
                        {
                            objDFV.Name = txtMVA_MultiName_No.Text;
                            objDFV.Address = txtMVA_MultiAddress_No.Text;
                            objDFV.Phone = txtMVA_MultiPhone_No.Text;
                            if (rdoMVA_Multicustomer_injured.SelectedValue == "1")
                                objDFV.Cutomer_Injured = true;
                            else if (rdoMVA_Multicustomer_injured.SelectedValue == "0")
                                objDFV.Cutomer_Injured = false;
                            else
                                objDFV.Cutomer_Injured = null;
                        }
                        else
                        {
                            objDFV.Not_Driven_By_Customer_Explain = txtMVA_MultiNot_Driven_By_Customer_Explain.Text;
                            objDFV.Name = "";
                            objDFV.Address = "";
                            objDFV.Phone = "";
                        }
                    }

                    if (rdoMVA_MultiAdditional_passengers.SelectedValue == "1")
                        objDFV.Additional_passengers = true;
                    else if (rdoMVA_MultiAdditional_passengers.SelectedValue == "0")
                        objDFV.Additional_passengers = false;
                    else
                        objDFV.Additional_passengers = null;

                    if (objDFV.Additional_passengers == false)
                    {
                        DPD_FR_Injured_Passenger.DeleteByVehicleID(PK_DPD_FR_Multi_Vehicle_ID);
                        //Bind Grid
                        BindPassengerGrid(gvMVAMulti_Passenger, PK_DPD_FR_Multi_Vehicle_ID);
                    }
                    if (rdoMVA_MultiSeeking_subrogation.SelectedValue == "1")
                        objDFV.seeking_subrogation = true;
                    else if (rdoMVA_MultiSeeking_subrogation.SelectedValue == "0")
                        objDFV.seeking_subrogation = false;
                    else
                        objDFV.seeking_subrogation = null;

                    if (objDFV.seeking_subrogation == true)
                    {
                        objDFV.TPI_Carrier_name = txtMVA_MultiTPI_Carrier_name.Text;
                        objDFV.tpi_contact = txtMVA_Multitpi_contact.Text;
                        objDFV.TPI_Policy_number = txtMVA_MultiTPI_Policy_number.Text;
                        objDFV.tpi_phone = txtMVA_Multitpi_phone.Text;
                        objDFV.tpi_Address_1 = txtMVA_Multitpi_address_1.Text;
                        objDFV.tpi_Address_2 = txtMVA_Multitpi_address_2.Text;
                        objDFV.tpi_City = txtMVA_Multitpi_City.Text;
                        objDFV.tpi_State = (ddlMVA_Multitpi_State.SelectedIndex > 0) ? ddlMVA_Multitpi_State.SelectedValue.ToString() : "0";
                        objDFV.tpi_Zip_Code = txtMVA_Multitpi_Zip_Code.Text;
                        objDFV.recovered_amount = string.IsNullOrEmpty(txtMVA_MultiRecovered_Amount.Text) ? 0 : Convert.ToDecimal(txtMVA_MultiRecovered_Amount.Text);
                    }
                    else
                    {
                        if (rdoMVA_MultiNotice_only_claim.SelectedValue == "1")
                            objDFV.Notice_only_claim = true;
                        else if (rdoMVA_MultiNotice_only_claim.SelectedValue == "0")
                            objDFV.Notice_only_claim = false;
                        else
                            objDFV.Notice_only_claim = null;

                        objDFV.recovered_amount = string.IsNullOrEmpty(txtMVA_MultiRecovered_Amount.Text.Trim()) ? 0 : Convert.ToDecimal(txtMVA_MultiRecovered_Amount.Text);
                    }
                    objDPD_FR.MVA_Multiple = true;
                    #endregion
                    break;

                //Hail
                case "6":
                    objDFV.Incident_Type = "7";
                    objDPD_FR.Hail = true;
                    break;

                //Flood
                case "7":
                    objDFV.Incident_Type = "8";
                    objDPD_FR.Flood = true;
                    break;

                //Fire
                case "8":
                    objDFV.Incident_Type = "9";
                    objDPD_FR.Fire = true;
                    break;

                //Wind
                case "9":
                    objDFV.Incident_Type = "10";
                    objDPD_FR.Wind = true;
                    break;

                //Fraud
                case "10":
                    #region Fraud
                    objDFV.Incident_Type = "3";
                    if (rdo_Vehicle_Recovered.SelectedValue == "1")
                    {
                        objDFV.Vehicle_Recovered = true;
                    }
                    else if (rdo_Vehicle_Recovered.SelectedValue == "0")
                    {
                        objDFV.Vehicle_Recovered = false;
                    }
                    else
                        objDFV.Vehicle_Recovered = null;

                    if (objDFV.Vehicle_Recovered == true)
                    {
                        objDFV.Damage_Estimate = string.IsNullOrEmpty(txt_Damage_estimate.Text) ? 0 : Convert.ToDecimal(txt_Damage_estimate.Text);
                        if (rdo_Dealership_Wish_To_Take_Possession.SelectedValue == "1")
                        {
                            objDFV.Dealership_Wish_To_Take_Possession = true;
                        }
                        else if (rdo_Dealership_Wish_To_Take_Possession.SelectedValue == "0")
                        {
                            objDFV.Dealership_Wish_To_Take_Possession = false;
                        }
                        else
                            objDFV.Dealership_Wish_To_Take_Possession = null;
                    }
                    else
                    {
                        objDFV.Damage_Estimate = null;
                        objDFV.Dealership_Wish_To_Take_Possession = null;
                    }
                    if (rdoVehicle_In_Storage.SelectedValue == "1")
                    {
                        objDFV.Vehicle_In_Storage = true;
                    }
                    else if (rdoVehicle_In_Storage.SelectedValue == "0")
                    {
                        objDFV.Vehicle_In_Storage = false;
                    }
                    else
                        objDFV.Vehicle_In_Storage = null;

                    if (objDFV.Vehicle_In_Storage == true)
                    {
                        objDFV.storage_Address_1 = txt_Storage_Address_1.Text;
                        objDFV.storage_Address_2 = txt_Storage_Address_2.Text;
                        objDFV.Storage_Contact = txt_Storage_Contact.Text;
                        objDFV.Storage_phone = txt_Storage_phone.Text;
                        objDFV.storage_City = txt_Storage_City.Text;
                        objDFV.storage_cost = string.IsNullOrEmpty(txt_Storage_cost.Text) ? 0 : Convert.ToDecimal(txt_Storage_cost.Text);
                        objDFV.storage_State = (ddl_Storage_State.SelectedIndex > 0) ? ddl_Storage_State.SelectedValue.ToString() : "0";
                        objDFV.storage_Zip_Code = txt_storage_Zip_Code.Text;
                    }

                    if (rdoPoliceNotified.SelectedValue == "1")
                    {
                        objDFV.Police_Notified = true;
                    }
                    else if (rdoPoliceNotified.SelectedValue == "0")
                    {
                        objDFV.Police_Notified = false;
                    }
                    else
                        objDFV.Police_Notified = null;

                    if (objDFV.Police_Notified == true)
                    {
                        objDFV.Police_Report_Number = txtFraudReportNumber.Text;
                    }
                    objDPD_FR.Fraud = true;
                    #endregion
                    break;
            }

            //if (PK_DPD_FR_Vehicle_ID > 0)
            //{
            //    objDFV.Update();
            //    PK_DPD_FR_Theft_ID = 0;
            //    btnAddVehicle.Text = "Add";

            //}
            //else
            //{
            //    objDPD_FR.Update();
            //    PK_DPD_FR_Vehicle_ID = objDFV.Insert();
            //    PK_DPD_FR_Vehicle_ID = 0;
            //}
            if (ht_PK_Vehicle_IncidentType.ContainsKey(objDFV.Incident_Type))
            {
                //objDPD_FR.Update();

                objDFV.PK_DPD_FR_Vehicle_ID = Convert.ToDecimal(ht_PK_Vehicle_IncidentType[objDFV.Incident_Type]);
                objDFV.Update();
                ht_PK_Vehicle_IncidentType.Remove(objDFV.Incident_Type);
            }
            else
            {
                objDPD_FR.Update();
                objDFV.Insert();
            }
        }


        foreach (DictionaryEntry dctEntry in ht_PK_Vehicle_IncidentType)
        {
            decimal PK_ID = Convert.ToDecimal(dctEntry.Value);
            DPD_FR_Vehicle.DeleteByPK(PK_ID);
            DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);
            switch (dctEntry.Key.ToString())
            {
                case "1":
                    objDPD_FR.MVA_Single = false;
                    break;
                case "2":
                    objDPD_FR.MVA_Multiple = false;
                    break;
                case "3":
                    objDPD_FR.Fraud = false;
                    break;
                case "4":
                    objDPD_FR.Theft = false;
                    break;
                case "5":
                    objDPD_FR.Partial_Theft = false;
                    break;
                case "6":
                    objDPD_FR.Vandalism = false;
                    break;
                case "7":
                    objDPD_FR.Hail = false;
                    break;
                case "8":
                    objDPD_FR.Flood = false;
                    break;
                case "9":
                    objDPD_FR.Fire = false;
                    break;
                case "10":
                    objDPD_FR.Wind = false;
                    break;
            }
            objDPD_FR.Update();
        }
        ht_PK_Vehicle_IncidentType = new Hashtable();

        BindVehicleGrid();
        ClearVehicle_Controls();
        lstCauseOfLoss_SelectedIndexChanged(null, null);
        ClearVehicle_Controls();
        BindVehicleGrid();
        lstCauseOfLoss.Style["display"] = "none";
        gvVehicleDetails.Style["display"] = "";
        tdVehicleDetails.Style["display"] = "none";
        btnAddVehicle.Text = "Add";
        btnEditVehicles.Visible = true;
        ViewState["MODEADD"] = "N";
        //objDPD.InsertBYXML();
        ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:bAddedVehicle = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    }

    //protected void lstCauseOfLoss_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    tdVehicleDetails.Style["display"] ="";
    //}

    protected void btnResetVehicle_Click(object sender, EventArgs e)
    {
        if (ViewState["MODEADD"] != null && ViewState["MODEADD"].ToString() == "N")
        {
            ClearVehicle_Controls();
            BindVehicleGrid();
            lstCauseOfLoss.Style["display"] = "none";
            gvVehicleDetails.Style["display"] = "";
            tdVehicleDetails.Style["display"] = "none";
            btnAddVehicle.Text = "Add";
            ht_PK_Vehicle_IncidentType = new Hashtable();
            btnEditVehicles.Visible = true;
        }
        else
        {

            ClearVehicle_Controls();
            lstCauseOfLoss.ClearSelection();
            lstCauseOfLoss.Style["display"] = "";
            gvVehicleDetails.Style["display"] = "none";
            tdVehicleDetails.Style["display"] = "none";
            btnAddVehicle.Text = "Add";
            ht_PK_Vehicle_IncidentType = new Hashtable();
            btnEditVehicles.Visible = false;

        }
        //lstCauseOfLoss_SelectedIndexChanged(null, null);
    }

    #region Vehicle Details Grid Events
    protected void gvVehicleDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void gvVehicleDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //check Row Type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkRemove");
            //check null value
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);

            LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            //check Null value
            if (lnkbtnEdit != null)
                lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    protected void gvVehicleDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }
    protected void gvVehicleDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name if it is "Remove" than remove the selected row
        if (e.CommandName == "Remove")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvVehicleDetails.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvVehicleDetails.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
            //used to check PK id. if greater than 0 than delete record
            if (PK_ID > 0)
            {
                DPD_FR_Vehicle.DeleteByPK(PK_ID);
                Label lbl = (Label)gvVehicleDetails.Rows[Index].FindControl("lblIncident_Type");
                if (lbl != null)
                {
                    DataTable dtTemp = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, lbl.Text);
                    if (dtTemp.Rows.Count == 0)
                    {
                        DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);
                        switch (lbl.Text)
                        {
                            case "1":
                                objDPD_FR.MVA_Single = false;
                                break;
                            case "2":
                                objDPD_FR.MVA_Multiple = false;
                                break;
                            case "3":
                                objDPD_FR.Fraud = false;
                                break;
                            case "4":
                                objDPD_FR.Theft = false;
                                break;
                            case "5":
                                objDPD_FR.Partial_Theft = false;
                                break;
                            case "6":
                                objDPD_FR.Vandalism = false;
                                break;
                            case "7":
                                objDPD_FR.Hail = false;
                                break;
                            case "8":
                                objDPD_FR.Flood = false;
                                break;
                            case "9":
                                objDPD_FR.Fire = false;
                                break;
                            case "10":
                                objDPD_FR.Wind = false;
                                break;
                        }
                        objDPD_FR.Update();
                    }
                }
            }
            ClearVehicle_Controls();
            PK_DPD_FR_Vehicle_ID = 0;
            //Bind Grid
            BindVehicleGrid();
        }
        else if (e.CommandName == "Edit")
        {
            ClearVehicle_Controls();
            btnAddVehicle.Text = "Update";
            btnViewAuditVehicle.Visible = true;

            int Index = Convert.ToInt32(e.CommandArgument);
            PK_DPD_FR_Vehicle_ID = (gvVehicleDetails.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvVehicleDetails.DataKeys[Index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
            //used to check PK id. if greater than 0 than display below fields else hide.
            if (PK_DPD_FR_Vehicle_ID > 0)
            {
                EditVehicleDetails(PK_DPD_FR_Vehicle_ID);
                lstCauseOfLoss_SelectedIndexChanged(null, null);
            }
        }
    }
    #endregion

    public void ClearVehicle_Controls()
    {
        lstCauseOfLoss.Enabled = true;
        PK_DPD_FR_Vehicle_ID = 0;
        txt_Make.Text = "";
        txt_Model.Text = "";
        txt_VIN.Text = "";
        txt_Present_Address.Text = "";
        txt_Present_Location.Text = "";
        txt_Present_Zip.Text = "";
        ddl_Present_State.ClearSelection();
        ddl_TypeOfVehicle.ClearSelection();
        txt_Invoice_Value.Text = "";
        txt_Loss_Description.Text = "";
        txt_Year.Text = "";
        rdo_Vehicle_Recovered.ClearSelection();
        rdo_Dealership_Wish_To_Take_Possession.ClearSelection();
        rdoPoliceNotified.ClearSelection();

        txt_Damage_estimate.Text = "";
        rdoVehicle_In_Storage.ClearSelection();
        txt_Storage_Address_1.Text = "";
        txt_Storage_Address_2.Text = "";
        txt_Storage_Contact.Text = "";
        txt_Storage_cost.Text = "";
        txt_Storage_phone.Text = "";
        txt_Storage_City.Text = "";
        txt_storage_Zip_Code.Text = "";
        ddl_Storage_State.ClearSelection();
        td_VehicleRecovred.Style.Add("display", "none");
        tdVehicle_In_Storage.Style.Add("display", "none");

        txtMVA_MultiDamage_Estimate.Text = "";
        rdoTheft_Security_Video_Surveillance.ClearSelection();
        rdoMVA_MultiDriven_By_Associate.ClearSelection();
        rdoMVA_MultiAssociate_Cited.ClearSelection();
        txtMVA_MultiDescription_Of_Citation.Text = "";
        rdoMVA_MultiAssociate_injured.ClearSelection();
        rdoMVA_MultiDrug_test_performed.ClearSelection();
        txtMVA_MultiDrug_test_explanation.Text = "";
        txtMVA_MultiDrug_test_results.Text = "";
        rdoMVA_MultiVehicle_Driven_By_Customer.ClearSelection();
        rdoMVA_Multicustomer_injured.ClearSelection();
        rdoMVA_MultiAdditional_passengers.ClearSelection();
        rdoMVA_MultiSeeking_subrogation.ClearSelection();
        txtMVA_MultiTPI_Carrier_name.Text = "";
        txtMVA_Multitpi_contact.Text = "";
        txtMVA_MultiTPI_Policy_number.Text = "";
        txtMVA_Multitpi_phone.Text = "";
        txtMVA_Multitpi_address_1.Text = "";
        txtMVA_Multitpi_address_2.Text = "";
        txtMVA_Multitpi_City.Text = "";
        ddlMVA_Multitpi_State.ClearSelection();
        txtMVA_Multitpi_Zip_Code.Text = "";
        txtMVA_MultiRecovered_Amount.Text = "";
        trMVA_MultiSeeking_subrogation_Yes.Style.Add("display", "none");
        trMVA_MultiSeeking_subrogation_No.Style.Add("display", "none");
        trMVA_MultiAdditional_passengers_Yes.Style.Add("display", "none");
        trMVA_MultiCust_Injured.Style.Add("display", "none");
        trMVAMulti_DrivenByCA_No.Style.Add("display", "none");
        trMVAMulti_DrivenByCA_Yes.Style.Add("display", "none");
        trMVA_MultiCitation_Yes.Style.Add("display", "none");
        trMVA_MultiDrugYes.Style.Add("display", "none");
        trMVA_MultiDrugNo.Style.Add("display", "none");
        trMVA_MultiCust_Not_Injured.Style.Add("display", "none");
        txtMVA_MultiNot_Driven_By_Customer_Explain.Text = "";

        ClearMVAMultiPassenger_Controls();

        rfvMVA_Multicustomer_injured.Enabled = false;
        rfvMVA_MultiVehicle_Driven_By_Customer.Enabled = false;
        RequiredFieldValidator rfvMVA_MultiDrugTestExplain = (RequiredFieldValidator)txtMVA_MultiDrug_test_explanation.FindControl("rfvNotes");
        rfvMVA_MultiDrugTestExplain.Enabled = false;
        RequiredFieldValidator rfvMVA_MultiDrugTestResult = (RequiredFieldValidator)txtMVA_MultiDrug_test_results.FindControl("rfvNotes");
        rfvMVA_MultiDrugTestResult.Enabled = false;
        RequiredFieldValidator rfvMVA_MultiDesc_Citation = (RequiredFieldValidator)txtMVA_MultiDescription_Of_Citation.FindControl("rfvNotes");
        rfvMVA_MultiDesc_Citation.Enabled = false;
        RequiredFieldValidator rfvMVA_MultiNot_Driven_By_Customer_Explain = (RequiredFieldValidator)txtMVA_MultiNot_Driven_By_Customer_Explain.FindControl("rfvNotes");
        rfvMVA_MultiNot_Driven_By_Customer_Explain.Enabled = false;
        rfvMVA_MultiAssociate_Cited.Enabled = false;
        rfvMVA_MultiDrug_test_performed.Enabled = false;
        rdoMVA_MultiNotice_only_claim.ClearSelection();
        rfvMVA_MultiNotice_only_claim.Enabled = false;
        txtMVA_MultiAddress_Yes.Text = "";
        txtMVA_MultiName_Yes.Text = "";
        txtMVA_MultiPhone_Yes.Text = "";
        txtMVA_MultiAddress_No.Text = "";
        txtMVA_MultiName_No.Text = "";
        txtMVA_MultiPhone_No.Text = "";
        txtMVA_MultiVehicle_Owner_Sonic.Text = "";
        txtMVA_MultiVehicle_Owner_Address.Text = "";
        txtMVA_MultiVehicle_Owner_Phone.Text = "";


        btnAddVehicle.Text = "Add";

        btnViewAuditVehicle.Visible = false;

        //rfvTheft_Dealership_Wish_To_Take_Possession.Enabled = false;

        //ScriptManager.RegisterClientScriptBlock(this, typeof(string), DateTime.Now.ToString() + "1", "bAddedVehicle = true;EnableDisableLossSavebutton(true);SetLossSaveButton();", true);
    }

    public void BindVehicleGrid()
    {
        DataTable dtVehicle = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, "");
        gvVehicleDetails.DataSource = dtVehicle;
        gvVehicleDetails.DataBind();

        DPD_FR objDPD_FR = new DPD_FR(PK_DPD_FR_ID);
        lstCauseOfLoss.Items[7].Selected = objDPD_FR.Theft;
        lstCauseOfLoss.Items[6].Selected = objDPD_FR.Partial_Theft;
        lstCauseOfLoss.Items[8].Selected = objDPD_FR.Vandalism;
        lstCauseOfLoss.Items[5].Selected = objDPD_FR.MVA_Single;
        lstCauseOfLoss.Items[4].Selected = objDPD_FR.MVA_Multiple;
        lstCauseOfLoss.Items[3].Selected = objDPD_FR.Hail;
        lstCauseOfLoss.Items[1].Selected = objDPD_FR.Flood;
        lstCauseOfLoss.Items[0].Selected = objDPD_FR.Fire;
        lstCauseOfLoss.Items[9].Selected = objDPD_FR.Wind;
        lstCauseOfLoss.Items[2].Selected = objDPD_FR.Fraud;

    }

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        #region "Location/Contact"
        string strCtrlsIDs1 = "";
        string strMessages1 = "";

        DataTable dtFields = clsScreen_Validators.SelectByScreen(18).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk1 = (Label)mnuDPD.Controls[0].FindControl("MenuAsterisk");
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 18").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Address 1": strCtrlsIDs1 += txtLoss_Address_1.ClientID + ","; strMessages1 += "Please enter [Location/Contact]/Address 1" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Address 2": strCtrlsIDs1 += txtLoss_Address_2.ClientID + ","; strMessages1 += "Please enter [Location/Contact]/Address 2" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Date of Loss": strCtrlsIDs1 += txtDate_Of_Loss.ClientID + ","; strMessages1 += "Please enter [Location/Contact]/Date of Loss" + ","; Span3.Style["display"] = "inline-block"; break;
                case "City": strCtrlsIDs1 += txtLoss_City.ClientID + ","; strMessages1 += "Please enter [Location/Contact]/City" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Time of Loss": strCtrlsIDs1 += txtTime_of_Loss.ClientID + ","; strMessages1 += "Please enter [Location/Contact]/Time of Loss" + ","; Span5.Style["display"] = "inline-block"; break;
                case "State": strCtrlsIDs1 += ddlLoss_State.ClientID + ","; strMessages1 += "Please select [Location/Contact]/State" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Zip Code": strCtrlsIDs1 += txtLoss_ZipCode.ClientID + ","; strMessages1 += "Please enter [Location/Contact]/Zip Code" + ","; Span7.Style["display"] = "inline-block"; break;
                case "When to Contact": strCtrlsIDs1 += txtContact_Best_Time.ClientID + ","; strMessages1 += "Please enter [Location/Contact]/When to Contact" + ","; Span8.Style["display"] = "inline-block"; break;
                case "Fax Number": strCtrlsIDs1 += txtEmployee_Fax.ClientID + ","; strMessages1 += "Please enter [Location/Contact]/Fax Number" + ","; Span9.Style["display"] = "inline-block"; break;
                case "Date Reported to Sonic": strCtrlsIDs1 += txtDate_Reported_To_Sonic.ClientID + ","; strMessages1 += "Please enter [Location/Contact]/Date Reported to Sonic" + ","; Span10.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDs1 = strCtrlsIDs1.TrimEnd(',');
        strMessages1 = strMessages1.TrimEnd(',');

        hdnControlIDs1.Value = strCtrlsIDs1;
        hdnErrorMsgs1.Value = strMessages1;
        #endregion

        #region "Loss Information"
        string strCtrlsIDs2 = "";
        string strMessages2 = "";
        string strCtrlsIDs3 = "";
        string strMessages3 = "";
        string strCtrlsIDs4 = "";
        string strMessages4 = "";
        string strCtrlsIDs5 = "";
        string strMessages5 = "";
        string strCtrlsIDs6 = "";
        string strMessages6 = "";
        string strCtrlsIDs7 = "";
        string strMessages7 = "";
        string strCtrlsIDs8 = "";
        string strMessages8 = "";
        string strCtrlsIDs9 = "";
        string strMessages9 = "";
        string strCtrlsIDs10 = "";
        string strMessages10 = "";
        string strCtrlsIDs11 = "";
        string strMessages11 = "";
        string strCtrlsIDs12 = "";
        string strMessages12 = "";
        string strCtrlsIDs13 = "";
        string strMessages13 = "";
        string strCtrlsIDs14 = "";
        string strMessages14 = "";
        dtFields = clsScreen_Validators.SelectByScreen(19).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk2 = (Label)mnuDPD.Controls[1].FindControl("MenuAsterisk");
        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 19").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Cause of Loss to Sonic Inventory":
                    lblAsteriskCause.Style["display"] = "inline-block";
                    break;
                case "VIN#":
                    //strCtrlsIDs2 += txtTheft_VIN.ClientID + ",";
                    strCtrlsIDs2 += txt_VIN.ClientID + ",";
                    //strCtrlsIDs3 += txtPartialTheft_VIN.ClientID + ","; strCtrlsIDs4 += txtVandalism_VIN.ClientID + ","; strCtrlsIDs5 += txtVIN.ClientID + ","; strCtrlsIDs6 += txtMVA_MultiVIN.ClientID + ","; strCtrlsIDs7 += txtHail_VIN.ClientID + ","; strCtrlsIDs8 += txtFlood_VIN.ClientID + ","; strCtrlsIDs9 += txtFire_VIN.ClientID + ","; strCtrlsIDs10 += txtWind_VIN.ClientID + ","; strCtrlsIDs11 += txtFraud_VIN.ClientID + ",";
                    strMessages2 += "Please enter [Loss Information]/VIN#" + ",";
                    Span12.Style["display"] = "inline-block";//= Span23.Style["display"] = Span34.Style["display"] = Span45.Style["display"] = Span56.Style["display"] = Span67.Style["display"] = Span78.Style["display"] = Span89.Style["display"] = Span100.Style["display"] = Span111.Style["display"] = "inline-block";
                    break;
                case "Make":
                    //strCtrlsIDs2 += txtTheft_Make.ClientID + ",";
                    strCtrlsIDs2 += txt_Make.ClientID + ",";
                    //strCtrlsIDs3 += txtPartialTheft_Make.ClientID + ","; strCtrlsIDs4 += txtVandalism_Make.ClientID + ","; strCtrlsIDs5 += txtMake.ClientID + ","; strCtrlsIDs6 += txtMVA_MultiMake.ClientID + ","; strCtrlsIDs7 += txtHail_Make.ClientID + ","; strCtrlsIDs8 += txtFlood_Make.ClientID + ","; strCtrlsIDs9 += txtFire_Make.ClientID + ","; strCtrlsIDs10 += txtWind_Make.ClientID + ","; strCtrlsIDs11 += txtFraud_Make.ClientID + ",";
                    strMessages2 += "Please enter [Loss Information]/Make" + ",";
                    Span13.Style["display"] = "inline-block";//= Span24.Style["display"] = Span35.Style["display"] = Span46.Style["display"] = Span57.Style["display"] = Span68.Style["display"] = Span79.Style["display"] = Span90.Style["display"] = Span101.Style["display"] = Span112.Style["display"] = "inline-block";
                    break;
                case "Model":
                    //strCtrlsIDs2 += txtTheft_Model.ClientID + ","; 
                    strCtrlsIDs2 += txt_Model.ClientID + ",";
                    //strCtrlsIDs3 += txtPartialTheft_Model.ClientID + ","; strCtrlsIDs4 += txtVandalism_Model.ClientID + ","; strCtrlsIDs5 += txtModel.ClientID + ","; strCtrlsIDs6 += txtMVA_MultiModel.ClientID + ","; strCtrlsIDs7 += txtHail_Model.ClientID + ","; strCtrlsIDs8 += txtFlood_Model.ClientID + ","; strCtrlsIDs9 += txtFire_Model.ClientID + ","; strCtrlsIDs10 += txtWind_Model.ClientID + ","; strCtrlsIDs11 += txtFraud_Model.ClientID + ",";
                    strMessages2 += "Please enter [Loss Information]/Model" + ",";
                    Span14.Style["display"] = "inline-block";//= Span25.Style["display"] = Span36.Style["display"] = Span47.Style["display"] = Span58.Style["display"] = Span69.Style["display"] = Span80.Style["display"] = Span91.Style["display"] = Span102.Style["display"] = Span113.Style["display"] = "inline-block";
                    break;
                case "Year":
                    //strCtrlsIDs2 += txtTheft_Year.ClientID + ",";
                    strCtrlsIDs2 += txt_Year.ClientID + ",";
                    //strCtrlsIDs3 += txtPartialTheft_Year.ClientID + ","; strCtrlsIDs4 += txtVandalism_Year.ClientID + ","; strCtrlsIDs5 += txtYear.ClientID + ","; strCtrlsIDs6 += txtMVA_MultiYear.ClientID + ","; strCtrlsIDs7 += txtHail_Year.ClientID + ","; strCtrlsIDs8 += txtFlood_Year.ClientID + ","; strCtrlsIDs9 += txtFire_Year.ClientID + ","; strCtrlsIDs10 += txtWind_Year.ClientID + ","; strCtrlsIDs11 += txtFraud_Year.ClientID + ",";
                    strMessages2 += "Please enter [Loss Information]/Year" + ",";
                    Span15.Style["display"] = "inline-block";//= Span26.Style["display"] = Span37.Style["display"] = Span48.Style["display"] = Span59.Style["display"] = Span70.Style["display"] = Span81.Style["display"] = Span92.Style["display"] = Span103.Style["display"] = Span114.Style["display"] = "inline-block";
                    break;
                case "Type of Vehicle":
                    //strCtrlsIDs2 += ddlTheft_TypeOfVehicle.ClientID + ",";
                    strCtrlsIDs2 += ddl_TypeOfVehicle.ClientID + ",";
                    //strCtrlsIDs3 += ddlPartialTheft_TypeOfVehicle.ClientID + ","; strCtrlsIDs4 += ddlVandalism_TypeOfVehicle.ClientID + ","; strCtrlsIDs5 += ddlTypeOfVehicle.ClientID + ","; strCtrlsIDs6 += ddlMVA_MultiTypeOfVehicle.ClientID + ","; strCtrlsIDs7 += ddlHail_TypeOfVehicle.ClientID + ","; strCtrlsIDs8 += ddlFlood_TypeOfVehicle.ClientID + ","; strCtrlsIDs9 += ddlFire_TypeOfVehicle.ClientID + ","; strCtrlsIDs10 += ddlWind_TypeOfVehicle.ClientID + ","; strCtrlsIDs11 += ddlFraud_TypeOfVehicle.ClientID + ",";
                    strMessages2 += "Please select [Loss Information]/Type of Vehicle" + ",";
                    Span16.Style["display"] = "inline-block";//= Span27.Style["display"] = Span38.Style["display"] = Span49.Style["display"] = Span60.Style["display"] = Span71.Style["display"] = Span82.Style["display"] = Span93.Style["display"] = Span104.Style["display"] = Span115.Style["display"] = "inline-block";
                    break;
                case "Location of Vehicle":
                    //strCtrlsIDs2 += txtTheft_Present_Location.ClientID + ",";
                    strCtrlsIDs2 += txt_Present_Location.ClientID + ",";
                    //strCtrlsIDs3 += txtPartialTheft_Present_Location.ClientID + ","; strCtrlsIDs4 += txtVandalism_Present_Location.ClientID + ","; strCtrlsIDs5 += txtPresent_Location.ClientID + ","; strCtrlsIDs6 += txtMVA_MultiPresent_Location.ClientID + ","; strCtrlsIDs7 += txtHail_Present_Location.ClientID + ","; strCtrlsIDs8 += txtFlood_Present_Location.ClientID + ","; strCtrlsIDs9 += txtFire_Present_Location.ClientID + ","; strCtrlsIDs10 += txtWind_Present_Location.ClientID + ","; strCtrlsIDs11 += txtFraud_Present_Location.ClientID + ",";
                    strMessages2 += "Please enter [Loss Information]/Location of Vehicle" + ",";
                    Span17.Style["display"] = "inline-block";//= Span28.Style["display"] = Span39.Style["display"] = Span50.Style["display"] = Span61.Style["display"] = Span72.Style["display"] = Span83.Style["display"] = Span94.Style["display"] = Span105.Style["display"] = Span116.Style["display"] = "inline-block";
                    break;
                case "Location Address":
                    //strCtrlsIDs2 += txtTheft_Present_Address.ClientID + ","; 
                    strCtrlsIDs2 += txt_Present_Address.ClientID + ",";
                    //strCtrlsIDs3 += txtPartialTheft_Present_Address.ClientID + ","; strCtrlsIDs4 += txtVandalism_Present_Address.ClientID + ","; strCtrlsIDs5 += txtPresent_Address.ClientID + ","; strCtrlsIDs6 += txtMVA_MultiPresent_Address.ClientID + ","; strCtrlsIDs7 += txtHail_Present_Address.ClientID + ","; strCtrlsIDs8 += txtFlood_Present_Address.ClientID + ","; strCtrlsIDs9 += txtFire_Present_Address.ClientID + ","; strCtrlsIDs10 += txtWind_Present_Address.ClientID + ","; strCtrlsIDs11 += txtFraud_Present_Address.ClientID + ",";
                    strMessages2 += "Please enter [Loss Information]/Location Address" + ",";
                    Span18.Style["display"] = "inline-block";//= Span29.Style["display"] = Span40.Style["display"] = Span51.Style["display"] = Span62.Style["display"] = Span73.Style["display"] = Span84.Style["display"] = Span95.Style["display"] = Span106.Style["display"] = Span117.Style["display"] = "inline-block";
                    break;
                case "Location State":
                    //strCtrlsIDs2 += ddlTheft_Present_State.ClientID + ","; 
                    strCtrlsIDs2 += ddl_Present_State.ClientID + ",";
                    //strCtrlsIDs3 += ddlPartialTheft_Present_State.ClientID + ","; strCtrlsIDs4 += ddlVandalism_Present_State.ClientID + ","; strCtrlsIDs5 += ddlPresent_State.ClientID + ","; strCtrlsIDs6 += ddlMVA_MultiPresent_State.ClientID + ","; strCtrlsIDs7 += ddlHail_Present_State.ClientID + ","; strCtrlsIDs8 += ddlFlood_Present_State.ClientID + ","; strCtrlsIDs9 += ddlFire_Present_State.ClientID + ","; strCtrlsIDs10 += ddlWind_Present_State.ClientID + ","; strCtrlsIDs11 += ddlFraud_Present_State.ClientID + ",";
                    strMessages2 += "Please select [Loss Information]/Location State" + ",";
                    Span19.Style["display"] = "inline-block";//= Span30.Style["display"] = Span41.Style["display"] = Span52.Style["display"] = Span63.Style["display"] = Span74.Style["display"] = Span85.Style["display"] = Span96.Style["display"] = Span107.Style["display"] = Span118.Style["display"] = "inline-block";
                    break;
                case "Location Zip":
                    //strCtrlsIDs2 += txtTheft_Present_Zip.ClientID + ","; 
                    strCtrlsIDs2 += txt_Present_Zip.ClientID + ",";
                    //strCtrlsIDs3 += txtPartialTheft_Present_Zip.ClientID + ","; strCtrlsIDs4 += txtVandalism_Present_Zip.ClientID + ","; strCtrlsIDs5 += txtPresent_Zip.ClientID + ","; strCtrlsIDs6 += txtMVA_MultiPresent_Zip.ClientID + ","; strCtrlsIDs7 += txtHail_Present_Zip.ClientID + ","; strCtrlsIDs8 += txtFlood_Present_Zip.ClientID + ","; strCtrlsIDs9 += txtFire_Present_Zip.ClientID + ","; strCtrlsIDs10 += txtWind_Present_Zip.ClientID + ","; strCtrlsIDs11 += txtFraud_Present_Zip.ClientID + ",";
                    strMessages2 += "Please enter [Loss Information]/Location Zip" + ",";
                    Span20.Style["display"] = "inline-block";//= Span31.Style["display"] = Span42.Style["display"] = Span53.Style["display"] = Span64.Style["display"] = Span75.Style["display"] = Span86.Style["display"] = Span97.Style["display"] = Span108.Style["display"] = Span119.Style["display"] = "inline-block";
                    break;
                case "Invoice Value":
                    //strCtrlsIDs2 += txtTheft_Invoice_Value.ClientID + ","; 
                    strCtrlsIDs2 += txt_Invoice_Value.ClientID + ",";
                    //strCtrlsIDs3 += txtPartialTheft_Invoice_Value.ClientID + ","; strCtrlsIDs4 += txtVandalism_Invoice_Value.ClientID + ","; strCtrlsIDs5 += txtInvoice_Value.ClientID + ","; strCtrlsIDs6 += txtMVA_MultiInvoice_Value.ClientID + ","; strCtrlsIDs7 += txtHail_Invoice_Value.ClientID + ","; strCtrlsIDs8 += txtFlood_Invoice_Value.ClientID + ","; strCtrlsIDs9 += txtFire_Invoice_Value.ClientID + ","; strCtrlsIDs10 += txtWind_Invoice_Value.ClientID + ","; strCtrlsIDs11 += txtFraud_Invoice_Value.ClientID + ",";
                    strMessages2 += "Please enter [Loss Information]/Invoice Value" + ",";
                    Span21.Style["display"] = "inline-block";//= Span32.Style["display"] = Span43.Style["display"] = Span54.Style["display"] = Span65.Style["display"] = Span76.Style["display"] = Span87.Style["display"] = Span98.Style["display"] = Span109.Style["display"] = Span120.Style["display"] = "inline-block";
                    break;
                case "Loss Description":
                    //strCtrlsIDs2 += txtTheft_Loss_Description.ClientID + ",";
                    strCtrlsIDs2 += txt_Loss_Description.ClientID + ",";
                    //strCtrlsIDs3 += txtPartialTheft_Loss_Description.ClientID + ","; strCtrlsIDs4 += txtVandalism_Loss_Description.ClientID + ","; strCtrlsIDs5 += txtMVASingleLoss_description.ClientID + ","; strCtrlsIDs6 += txtMVAMultiLoss_description.ClientID + ","; strCtrlsIDs7 += txtHail_Loss_Description.ClientID + ","; strCtrlsIDs8 += txtFlood_Loss_Description.ClientID + ","; strCtrlsIDs9 += txtFire_Loss_Description.ClientID + ","; strCtrlsIDs10 += txtWind_Loss_Description.ClientID + ","; strCtrlsIDs11 += txtFraud_Loss_Description.ClientID + ",";
                    strMessages2 += "Please enter [Loss Information]/Loss Description" + ",";
                    Span22.Style["display"] = "inline-block";//= Span33.Style["display"] = Span44.Style["display"] = Span55.Style["display"] = Span66.Style["display"] = Span77.Style["display"] = Span88.Style["display"] = Span99.Style["display"] = Span110.Style["display"] = Span121.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }

        strMessages3 = strMessages4 = strMessages5 = strMessages6 = strMessages7 = strMessages8 = strMessages9 = strMessages10 = strMessages11 = strMessages2;

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "If Vehicle Recovered - damage amount":
                    strCtrlsIDs2 += txt_Damage_estimate.ClientID + ","; strMessages2 += "Please enter [Loss Information]/damage amount" + ",";
                    Span122.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strCtrlsIDs2 += txt_Storage_Address_1.ClientID + ","; strMessages2 += "Please enter [Loss Information]/Address 1" + ",";
                    //strCtrlsIDs11 += txtFraud_Storage_Address_1.ClientID + ","; strMessages11 += "Please enter [Loss Information]/Address 1" + ",";
                    Span123.Style["display"] = "inline-block";
                    break;
                case "Contact Name":
                    strCtrlsIDs2 += txt_Storage_Contact.ClientID + ","; strMessages2 += "Please enter [Loss Information]/Contact Name" + ",";
                    //strCtrlsIDs11 += txtFraud_Storage_Contact.ClientID + ","; strMessages11 += "Please enter [Loss Information]/Contact Name" + ",";
                    Span124.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strCtrlsIDs2 += txt_Storage_Address_2.ClientID + ","; strMessages2 += "Please enter [Loss Information]/Address 2" + ",";
                    //strCtrlsIDs11 += txtFraud_Storage_Address_2.ClientID + ","; strMessages11 += "Please enter [Loss Information]/Address 2" + ",";
                    Span125.Style["display"] = "inline-block";
                    break;
                case "Storage Phone":
                    strCtrlsIDs2 += txt_Storage_phone.ClientID + ","; strMessages2 += "Please enter [Loss Information]/Storage Phone" + ",";
                    //strCtrlsIDs11 += txtFraud_Storage_phone.ClientID + ","; strMessages11 += "Please enter [Loss Information]/Storage Phone" + ",";
                    Span126.Style["display"] = "inline-block";
                    break;
                case "City":
                    strCtrlsIDs2 += txt_Storage_City.ClientID + ","; strMessages2 += "Please enter [Loss Information]/City" + ",";
                    //strCtrlsIDs11 += txtFraud_Storage_City.ClientID + ","; strMessages11 += "Please enter [Loss Information]/City" + ",";
                    Span127.Style["display"] = "inline-block";
                    break;
                case "Cost of Storage":
                    strCtrlsIDs2 += txt_Storage_cost.ClientID + ","; strMessages2 += "Please enter [Loss Information]/Cost of Storage" + ",";
                    //strCtrlsIDs11 += txtFraud_Storage_cost.ClientID + ","; strMessages11 += "Please enter [Loss Information]/Cost of Storage" + ",";
                    Span128.Style["display"] = "inline-block";
                    break;
                case "Storage State":
                    strCtrlsIDs2 += ddl_Storage_State.ClientID + ","; strMessages2 += "Please select [Loss Information]/Storage State" + ",";
                    //strCtrlsIDs11 += ddlFraud_Storage_State.ClientID + ","; strMessages11 += "Please enter [Loss Information]/Storage State" + ",";
                    Span129.Style["display"] = "inline-block";
                    break;
                case "Storage Zip":
                    strCtrlsIDs2 += txt_storage_Zip_Code.ClientID + ","; strMessages2 += "Please enter [Loss Information]/Storage Zip" + ",";
                    //strCtrlsIDs11 += txtFraud_storage_Zip_Code.ClientID + ","; strMessages11 += "Please enter [Loss Information]/Storage Zip" + ",";
                    Span130.Style["display"] = "inline-block";
                    break;
                case "Police Report Number": strCtrlsIDs11 += txtFraudReportNumber.ClientID + ","; strMessages11 += "Please enter [Loss Information]/Police Report Number" + ","; Span140.Style["display"] = "inline-block"; break;
                case "Date of Loss": strCtrlsIDs12 += txtLossDate_Of_Loss.ClientID + ","; strMessages12 += "Please enter [Loss Information]/Date of Loss" + ","; Span11.Style["display"] = "inline-block"; break;

                case "MVA-Damage Estimate":
                    //strCtrlsIDs5 += txtDamage_Estimate.ClientID + ","; strMessages5 += "Please enter [Loss Information]/Damage Estimate" + ",";
                    strCtrlsIDs6 += txtMVA_MultiDamage_Estimate.ClientID + ","; strMessages6 += "Please enter [Loss Information]/Damage Estimate" + ",";
                    Span172.Style["display"] = "inline-block"; break;
                case "MVA-company associate-Name":
                    //strCtrlsIDs5 += txtMVA_SingleName_Yes.ClientID + ","; strMessages5 += "Please enter [Loss Information]/company associate-Name" + ",";
                    strCtrlsIDs6 += txtMVA_MultiName_Yes.ClientID + ","; strMessages6 += "Please enter [Loss Information]/company associate-Name" + ",";
                    Span173.Style["display"] = "inline-block"; break;
                case "MVA-company associate-Address":
                    //strCtrlsIDs5 += txtMVA_SingleAddress_Yes.ClientID + ","; strMessages5 += "Please enter [Loss Information]/company associate-Address" + ",";
                    strCtrlsIDs6 += txtMVA_MultiAddress_Yes.ClientID + ","; strMessages6 += "Please enter [Loss Information]/company associate-Address" + ",";
                    Span174.Style["display"] = "inline-block"; break;
                case "MVA-company associate-Phone":
                    //strCtrlsIDs5 += txtMVA_SinglePhone_Yes.ClientID + ","; strMessages5 += "Please enter [Loss Information]/company associate-Phone" + ",";
                    strCtrlsIDs6 += txtMVA_MultiPhone_Yes.ClientID + ","; strMessages6 += "Please enter [Loss Information]/company associate-Phone" + ",";
                    Span175.Style["display"] = "inline-block"; break;
                case "MVA-company associate-Description of citation":
                    //strCtrlsIDs5 += txtDescription_Of_Citation.ClientID + ","; strMessages5 += "Please enter [Loss Information]/company associate-Description of citation" + ",";
                    strCtrlsIDs6 += txtMVA_MultiDescription_Of_Citation.ClientID + ","; strMessages6 += "Please enter [Loss Information]/Description of citation" + ",";
                    Span176.Style["display"] = "inline-block"; break;
                case "MVA-company associate-accident drug test-Results":
                    //strCtrlsIDs5 += txtDrug_test_results.ClientID + ","; strMessages5 += "Please enter company [Loss Information]/associate-accident drug test-Results" + ",";
                    strCtrlsIDs6 += txtMVA_MultiDrug_test_results.ClientID + ","; strMessages6 += "Please enter [Loss Information]/accident drug test Results" + ",";
                    Span177.Style["display"] = "inline-block"; break;
                case "MVA-company associate-accident drug test not performed-Explain":
                    //strCtrlsIDs5 += txtDrug_test_explanation.ClientID + ","; strMessages5 += "Please enter company [Loss Information]/associate-accident drug test not performed-Explain" + ",";
                    strCtrlsIDs6 += txtMVA_MultiDrug_test_explanation.ClientID + ","; strMessages6 += "Please enter [Loss Information]/explaination for accident drug test not performed" + ",";
                    Span178.Style["display"] = "inline-block"; break;
                case "MVA-customer-Name":
                    //strCtrlsIDs5 += txtMVA_SingleName_No.ClientID + ","; strMessages5 += "Please enter [Loss Information]/customer-Name" + ",";
                    strCtrlsIDs6 += txtMVA_MultiName_No.ClientID + ","; strMessages6 += "Please enter [Loss Information]/customer-Name" + ",";
                    Span179.Style["display"] = "inline-block"; break;
                case "MVA-customer-Address":
                    //strCtrlsIDs5 += txtMVA_SingleAddress_No.ClientID + ","; strMessages5 += "Please enter [Loss Information]/customer-Address" + ",";
                    strCtrlsIDs6 += txtMVA_MultiAddress_No.ClientID + ","; strMessages6 += "Please enter [Loss Information]/customer-Address" + ",";
                    Span180.Style["display"] = "inline-block"; break;
                case "MVA-customer-Phone":
                    //strCtrlsIDs5 += txtMVA_SinglePhone_No.ClientID + ","; strMessages5 += "Please enter [Loss Information]/customer-Phone" + ",";
                    strCtrlsIDs6 += txtMVA_MultiPhone_No.ClientID + ","; strMessages6 += "Please enter [Loss Information]/customer-Phone" + ",";
                    Span181.Style["display"] = "inline-block"; break;
                case "MVA-vehicle not being driven by customer-Explain":
                    //strCtrlsIDs5 += txtMVA_SingleNot_Driven_By_Customer_Explain.ClientID + ","; strMessages5 += "Please enter [Loss Information]/vehicle not being driven by customer-Explain" + ",";
                    strCtrlsIDs6 += txtMVA_MultiNot_Driven_By_Customer_Explain.ClientID + ","; strMessages6 += "Please enter [Loss Information]/vehicle not being driven by customer-Explain" + ",";
                    Span182.Style["display"] = "inline-block"; break;

                case "MVA-Third Party Insurer-Carrier Name":
                    //strCtrlsIDs5 += txtTPI_Carrier_name.ClientID + ","; strMessages5 += "Please enter Third Party Insurer-Carrier Name" + ",";
                    strCtrlsIDs6 += txtMVA_MultiTPI_Carrier_name.ClientID + ","; strMessages6 += "Please enter [Loss Information]/Third Party Insurer-Carrier Name" + ",";
                    Span190.Style["display"] = "inline-block"; break;
                case "MVA-Third Party Insurer-Contact Name":
                    //strCtrlsIDs5 += txttpi_contact.ClientID + ","; strMessages5 += "Please enter Third Party Insurer-Contact Name" + ",";
                    strCtrlsIDs6 += txtMVA_Multitpi_contact.ClientID + ","; strMessages6 += "Please enter [Loss Information]/Third Party Insurer-Contact Name" + ",";
                    Span191.Style["display"] = "inline-block"; break;
                case "MVA-Third Party Insurer-Policy Number":
                    //strCtrlsIDs5 += txtTPI_Policy_number.ClientID + ","; strMessages5 += "Please enter Third Party Insurer-Policy Number" + ",";
                    strCtrlsIDs6 += txtMVA_MultiTPI_Policy_number.ClientID + ","; strMessages6 += "Please enter [Loss Information]/Third Party Insurer-Policy Number" + ",";
                    Span192.Style["display"] = "inline-block"; break;
                case "MVA-Third Party Insurer-Phone":
                    //strCtrlsIDs5 += txttpi_phone.ClientID + ","; strMessages5 += "Please enter Third Party Insurer-Phone" + ",";
                    strCtrlsIDs6 += txtMVA_Multitpi_phone.ClientID + ","; strMessages6 += "Please enter [Loss Information]/Third Party Insurer-Phone" + ",";
                    Span193.Style["display"] = "inline-block"; break;
                case "MVA-Third Party Insurer-Address 1":
                    //strCtrlsIDs5 += txttpi_address_1.ClientID + ","; strMessages5 += "Please enter Third Party Insurer-Address 1" + ",";
                    strCtrlsIDs6 += txtMVA_Multitpi_address_1.ClientID + ","; strMessages6 += "Please enter [Loss Information]/Third Party Insurer-Address 1" + ",";
                    Span194.Style["display"] = "inline-block"; break;
                case "MVA-Third Party Insurer-Address 2":
                    //strCtrlsIDs5 += txttpi_address_2.ClientID + ","; strMessages5 += "Please enter Third Party Insurer-Address 2" + ",";
                    strCtrlsIDs6 += txtMVA_Multitpi_address_2.ClientID + ","; strMessages6 += "Please enter [Loss Information]/Third Party Insurer-Address 2" + ",";
                    Span195.Style["display"] = "inline-block"; break;
                case "MVA-Third Party Insurer-City":
                    //strCtrlsIDs5 += txttpi_City.ClientID + ","; strMessages5 += "Please enter Third Party Insurer-City" + ",";
                    strCtrlsIDs6 += txtMVA_Multitpi_City.ClientID + ","; strMessages6 += "Please enter [Loss Information]/Third Party Insurer-City" + ",";
                    Span196.Style["display"] = "inline-block"; break;
                case "MVA-Third Party Insurer-State":
                    //strCtrlsIDs5 += ddltpi_State.ClientID + ","; strMessages5 += "Please enter Third Party Insurer-State" + ",";
                    strCtrlsIDs6 += ddlMVA_Multitpi_State.ClientID + ","; strMessages6 += "Please enter [Loss Information]/Third Party Insurer-State" + ",";
                    Span197.Style["display"] = "inline-block"; break;
                case "MVA-Third Party Insurer-Zip":
                    //strCtrlsIDs5 += txttpi_Zip_Code.ClientID + ","; strMessages5 += "Please enter Third Party Insurer-Zip" + ",";
                    strCtrlsIDs6 += txtMVA_Multitpi_Zip_Code.ClientID + ","; strMessages6 += "Please enter [Loss Information]/Third Party Insurer-Zip" + ",";
                    Span198.Style["display"] = "inline-block"; break;
                case "MVA-Recovered Amount":
                    //strCtrlsIDs5 += txtRecovered_Amount.ClientID + ","; strMessages5 += "Please enter Recovered Amount" + ",";
                    strCtrlsIDs6 += txtMVA_MultiRecovered_Amount.ClientID + ","; strMessages6 += "Please enter [Loss Information]/Recovered Amount" + ",";
                    Span199.Style["display"] = "inline-block"; break;

                case "MVA-other passengers-Contact Name":
                    //strCtrlsIDs13 += txtPass_Name.ClientID + ","; strMessages13 += "Please enter other passengers-Contact Name" + ",";
                    strCtrlsIDs14 += txtMVA_MultiPass_Name.ClientID + ","; strMessages14 += "Please enter [Loss Information]/other passengers-Contact Name" + ",";
                    Span183.Style["display"] = "inline-block"; break;
                case "MVA-other passengers-Address 1":
                    //strCtrlsIDs13 += txtPass_Address_1.ClientID + ","; strMessages13 += "Please enter other passengers-Address 1" + ",";
                    strCtrlsIDs14 += txtMVA_MultiPass_Address_1.ClientID + ","; strMessages14 += "Please enter [Loss Information]/other passengers-Address 1" + ",";
                    Span184.Style["display"] = "inline-block"; break;
                case "MVA-other passengers-Address 2":
                    //strCtrlsIDs13 += txtPass_Address_2.ClientID + ","; strMessages13 += "Please enter other passengers-Address 2" + ",";
                    strCtrlsIDs14 += txtMVA_MultiPass_Address_2.ClientID + ","; strMessages14 += "Please enter [Loss Information]/other passengers-Address 2" + ",";
                    Span185.Style["display"] = "inline-block"; break;
                case "MVA-other passengers-Phone":
                    //strCtrlsIDs13 += txtPass_Phone.ClientID + ","; strMessages13 += "Please enter other passengers-Phone" + ",";
                    strCtrlsIDs14 += txtMVA_MultiPass_Phone.ClientID + ","; strMessages14 += "Please enter [Loss Information]/other passengers-Phone" + ",";
                    Span186.Style["display"] = "inline-block"; break;
                case "MVA-other passengers-City":
                    //strCtrlsIDs13 += txtPass_City.ClientID + ","; strMessages13 += "Please enter other passengers-City" + ",";
                    strCtrlsIDs14 += txtMVA_MultiPass_City.ClientID + ","; strMessages14 += "Please enter [Loss Information]/other passengers-City" + ",";
                    Span187.Style["display"] = "inline-block"; break;
                case "MVA-other passengers-State":
                    //strCtrlsIDs13 += ddlPass_State.ClientID + ","; strMessages13 += "Please select other passengers-State" + ",";
                    strCtrlsIDs14 += ddlMVA_MultiPass_State.ClientID + ","; strMessages14 += "Please select [Loss Information]/other passengers-State" + ",";
                    Span188.Style["display"] = "inline-block"; break;
                case "MVA-other passengers-Zip":
                    //strCtrlsIDs13 += txtPass_Zip.ClientID + ","; strMessages13 += "Please enter other [Loss Information]/passengers-Zip" + ",";
                    strCtrlsIDs14 += txtMVA_MultiPass_Zip.ClientID + ","; strMessages14 += "Please enter [Loss Information]/other passengers-Zip" + ",";
                    Span189.Style["display"] = "inline-block"; break;

                case "Vehicle Owner if not SONIC": strCtrlsIDs6 += txtMVA_MultiVehicle_Owner_Sonic.ClientID + ","; strMessages6 += "Please enter [Loss Information]/Vehicle Owner if not SONIC" + ","; Span169.Style["display"] = "inline-block"; break;
                case "Vehicle Owner Address": strCtrlsIDs6 += txtMVA_MultiVehicle_Owner_Address.ClientID + ","; strMessages6 += "Please enter [Loss Information]/Vehicle Owner Address" + ","; Span170.Style["display"] = "inline-block"; break;
                case "Vehicle Owner Phone": strCtrlsIDs6 += txtMVA_MultiVehicle_Owner_Phone.ClientID + ","; strMessages6 += "Please enter [Loss Information]/Vehicle Owner Phone" + ","; Span171.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        strCtrlsIDs2 = strCtrlsIDs2.TrimEnd(',');
        strMessages2 = strMessages2.TrimEnd(',');
        hdnControlIDs2.Value = strCtrlsIDs2;
        hdnErrorMsgs2.Value = strMessages2;

        //strCtrlsIDs3 = strCtrlsIDs3.TrimEnd(',');
        //strMessages3 = strMessages3.TrimEnd(',');
        //hdnControlIDs3.Value = strCtrlsIDs3;
        //hdnErrorMsgs3.Value = strMessages3;

        //strCtrlsIDs4 = strCtrlsIDs4.TrimEnd(',');
        //strMessages4 = strMessages4.TrimEnd(',');
        //hdnControlIDs4.Value = strCtrlsIDs4;
        //hdnErrorMsgs4.Value = strMessages4;

        //strCtrlsIDs5 = strCtrlsIDs5.TrimEnd(',');
        //strMessages5 = strMessages5.TrimEnd(',');
        //hdnControlIDs5.Value = strCtrlsIDs5;
        //hdnErrorMsgs5.Value = strMessages5;

        //strCtrlsIDs6 = strCtrlsIDs6.TrimEnd(',');
        //strMessages6 = strMessages6.TrimEnd(',');
        //hdnControlIDs6.Value = strCtrlsIDs6;
        //hdnErrorMsgs6.Value = strMessages6;

        //strCtrlsIDs7 = strCtrlsIDs7.TrimEnd(',');
        //strMessages7 = strMessages7.TrimEnd(',');
        //hdnControlIDs7.Value = strCtrlsIDs7;
        //hdnErrorMsgs7.Value = strMessages7;

        //strCtrlsIDs8 = strCtrlsIDs8.TrimEnd(',');
        //strMessages8 = strMessages8.TrimEnd(',');
        //hdnControlIDs8.Value = strCtrlsIDs8;
        //hdnErrorMsgs8.Value = strMessages8;

        //strCtrlsIDs9 = strCtrlsIDs9.TrimEnd(',');
        //strMessages9 = strMessages9.TrimEnd(',');
        //hdnControlIDs9.Value = strCtrlsIDs9;
        //hdnErrorMsgs9.Value = strMessages9;

        //strCtrlsIDs10 = strCtrlsIDs10.TrimEnd(',');
        //strMessages10 = strMessages10.TrimEnd(',');
        //hdnControlIDs10.Value = strCtrlsIDs10;
        //hdnErrorMsgs10.Value = strMessages10;

        //strCtrlsIDs11 = strCtrlsIDs11.TrimEnd(',');
        //strMessages11 = strMessages11.TrimEnd(',');
        //hdnControlIDs11.Value = strCtrlsIDs11;
        //hdnErrorMsgs11.Value = strMessages11;

        strCtrlsIDs12 = strCtrlsIDs12.TrimEnd(',');
        strMessages12 = strMessages12.TrimEnd(',');
        hdnControlIDs12.Value = strCtrlsIDs12;
        hdnErrorMsgs12.Value = strMessages12;

        //strCtrlsIDs13 = strCtrlsIDs13.TrimEnd(',');
        //strMessages13 = strMessages13.TrimEnd(',');
        //hdnControlIDs13.Value = strCtrlsIDs13;
        //hdnErrorMsgs13.Value = strMessages13;

        //strCtrlsIDs14 = strCtrlsIDs14.TrimEnd(',');
        //strMessages14 = strMessages14.TrimEnd(',');
        //hdnControlIDs14.Value = strCtrlsIDs14;
        //hdnErrorMsgs14.Value = strMessages14;
        #endregion

        #region "Witnesses"
        string strCtrlsIDs15 = "";
        string strMessages15 = "";

        dtFields = clsScreen_Validators.SelectByScreen(20).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk3 = (Label)mnuDPD.Controls[2].FindControl("MenuAsterisk");
        MenuAsterisk3.Style["display"] = (dtFields.Select("LeftMenuIndex = 20").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Name": strCtrlsIDs15 += txtWitness_Name.ClientID + ","; strMessages15 += "Please enter [Witnesses]/Name" + ","; Span200.Style["display"] = "inline-block"; break;
                case "Address": strCtrlsIDs15 += txtWitness_Address.ClientID + ","; strMessages15 += "Please enter [Witnesses]/Address" + ","; Span201.Style["display"] = "inline-block"; break;
                case "Phone": strCtrlsIDs15 += txtWitness_Phone.ClientID + ","; strMessages15 += "Please enter [Witnesses]/Phone" + ","; Span202.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDs15 = strCtrlsIDs15.TrimEnd(',');
        strMessages15 = strMessages15.TrimEnd(',');

        hdnControlIDs15.Value = strCtrlsIDs15;
        hdnErrorMsgs15.Value = strMessages15;
        #endregion

        #region "Comments"
        string strCtrlsIDs16 = "";
        string strMessages16 = "";

        dtFields = clsScreen_Validators.SelectByScreen(21).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk4 = (Label)mnuDPD.Controls[3].FindControl("MenuAsterisk");
        MenuAsterisk4.Style["display"] = (dtFields.Select("LeftMenuIndex = 21").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Comments": strCtrlsIDs16 += txtComments.ClientID + ","; strMessages16 += "Please enter [Comments]/Comments" + ","; Span203.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDs16 = strCtrlsIDs16.TrimEnd(',');
        strMessages16 = strMessages16.TrimEnd(',');

        hdnControlIDs16.Value = strCtrlsIDs16;
        hdnErrorMsgs16.Value = strMessages16;
        #endregion
    }
    #endregion
    protected void btnEditVehicles_Click(object sender, EventArgs e)
    {
        lstCauseOfLoss.Style["display"] = "";
        gvVehicleDetails.Style["display"] = "none";
        tdVehicleDetails.Style["display"] = "";
        btnAddVehicle.Text = "Update";
        lstCauseOfLoss_SelectedIndexChanged(null, null);
        Hashtable temp_ht_PK_Vehicle_IncidentType = new Hashtable();
        for (int index = 0; index < gvVehicleDetails.Rows.Count; index++)
        {
            PK_DPD_FR_Vehicle_ID = (gvVehicleDetails.DataKeys[index].Values["PK_DPD_FR_Vehicle_ID"] != null) ? Convert.ToInt32(gvVehicleDetails.DataKeys[index].Values["PK_DPD_FR_Vehicle_ID"]) : 0;
            Label lbl = (Label)gvVehicleDetails.Rows[index].FindControl("lblIncident_Type");
            if (lbl != null)
            {
                string Incident_Type = lbl.Text;
                if (!ht_PK_Vehicle_IncidentType.ContainsKey(Incident_Type))
                    temp_ht_PK_Vehicle_IncidentType.Add(Incident_Type, PK_DPD_FR_Vehicle_ID);

                EditVehicleDetails(PK_DPD_FR_Vehicle_ID);
            }

        }
        ht_PK_Vehicle_IncidentType = temp_ht_PK_Vehicle_IncidentType;
        btnEditVehicles.Visible = false;
        ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), DateTime.Now.ToString(), "bAddedVehicle = false;EnableDisableLossSavebutton(true);", true);
    }

    private void EditVehicleDetails(int PK_ID)
    {
        btnViewAuditVehicle.Attributes.Add("onClick", "return AuditPopUpForDPDVeh(" + PK_DPD_FR_Vehicle_ID + ");");
        DPD_FR_Vehicle objDFV = new DPD_FR_Vehicle(PK_ID);

        //lstCauseOfLoss.ClearSelection();
        //lstCauseOfLoss.Enabled = false;

        revTheft_Year.Enabled = true;
        txt_Make.Text = string.IsNullOrEmpty(objDFV.Make) ? "" : objDFV.Make.ToString();
        txt_Model.Text = string.IsNullOrEmpty(objDFV.Model) ? "" : objDFV.Model.ToString();
        txt_Year.Text = (objDFV.Year.ToString() == "0") ? "" : objDFV.Year.ToString();
        txt_VIN.Text = string.IsNullOrEmpty(objDFV.VIN) ? "" : objDFV.VIN.ToString();
        ListItem lstTypeOfVehicle = ddl_TypeOfVehicle.Items.FindByText(string.IsNullOrEmpty(objDFV.TypeOfVehicle) ? "" : objDFV.TypeOfVehicle.ToString());
        ddl_TypeOfVehicle.ClearSelection();
        if (lstTypeOfVehicle != null)
            lstTypeOfVehicle.Selected = true;

        txt_Present_Location.Text = string.IsNullOrEmpty(objDFV.Present_Location) ? "" : objDFV.Present_Location.ToString();
        txt_Present_Address.Text = string.IsNullOrEmpty(objDFV.Present_Address) ? "" : objDFV.Present_Address.ToString();
        ListItem lstPresent_State = ddl_Present_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.Present_State) ? "0" : objDFV.Present_State.ToString());
        ddl_Present_State.ClearSelection();
        if (lstPresent_State != null)
            lstPresent_State.Selected = true;
        txt_Present_Zip.Text = string.IsNullOrEmpty(objDFV.Present_Zip) ? "" : objDFV.Present_Zip;
        txt_Invoice_Value.Text = clsGeneral.GetStringValue(objDFV.Invoice_Value);
        txt_Loss_Description.Text = objDFV.Loss_Description;

        //DataTable dtVehicle = DPD_FR_Vehicle.SelectByIncidentType(PK_DPD_FR_ID, objDFV.Incident_Type);
        //gvVehicleDetails.DataSource = dtVehicle;
        //gvVehicleDetails.DataBind();

        switch (objDFV.Incident_Type)
        {
            //WHEN 1 THEN 'MVA – Damage (Single Vehicle)'
            case "1":
                lstCauseOfLoss.Items[5].Selected = true;
                #region MVA – Damage (Single Vehicle)
                txtMVA_MultiDamage_Estimate.Text = clsGeneral.GetStringValue(objDFV.Damage_Estimate);
                if (objDFV.Driven_By_Associate != null)
                {
                    if (objDFV.Driven_By_Associate == true)
                    {
                        trMVAMulti_DrivenByCA_Yes.Style.Add("display", "");
                        txtMVA_MultiAddress_Yes.Text = string.IsNullOrEmpty(objDFV.Address) ? "" : objDFV.Address;
                        txtMVA_MultiName_Yes.Text = string.IsNullOrEmpty(objDFV.Name) ? "" : objDFV.Name;
                        txtMVA_MultiPhone_Yes.Text = string.IsNullOrEmpty(objDFV.Phone) ? "" : objDFV.Phone;
                        rfvMVA_MultiAssociate_Cited.Enabled = true;
                        rfvMVA_MultiDrug_test_performed.Enabled = true;
                        rdoMVA_MultiDriven_By_Associate.SelectedValue = "1";
                        if (objDFV.Associate_Cited != null)
                        {
                            if (objDFV.Associate_Cited == true)
                            {
                                trMVA_MultiCitation_Yes.Style.Add("display", "");
                                rdoMVA_MultiAssociate_Cited.SelectedValue = "1";
                                RequiredFieldValidator rfvMVA_MultiDesc_Citation = (RequiredFieldValidator)txtMVA_MultiDescription_Of_Citation.FindControl("rfvNotes");
                                rfvMVA_MultiDesc_Citation.Enabled = true;
                                txtMVA_MultiDescription_Of_Citation.Text = string.IsNullOrEmpty(objDFV.Description_Of_Citation) ? "" : objDFV.Description_Of_Citation.ToString();
                            }
                            else
                            {
                                rdoMVA_MultiAssociate_Cited.SelectedValue = "0";
                            }
                        }
                        if (objDFV.Associate_injured != null)
                        {
                            if (objDFV.Associate_injured == true)
                                rdoMVA_MultiAssociate_injured.SelectedValue = "1";
                            else
                                rdoMVA_MultiAssociate_injured.SelectedValue = "0";
                        }

                        if (objDFV.drug_test_performed != null)
                        {
                            if (objDFV.drug_test_performed == true)
                            {
                                rdoMVA_MultiDrug_test_performed.SelectedValue = "1";
                                trMVA_MultiDrugYes.Style.Add("display", "");
                                RequiredFieldValidator rfvMVA_MultiDrugTestResult = (RequiredFieldValidator)txtMVA_MultiDrug_test_results.FindControl("rfvNotes");
                                rfvMVA_MultiDrugTestResult.Enabled = true;
                                txtMVA_MultiDrug_test_results.Text = string.IsNullOrEmpty(objDFV.drug_test_results) ? "" : objDFV.drug_test_results.ToString();
                            }
                            else
                            {
                                rdoMVA_MultiDrug_test_performed.SelectedValue = "0";
                                trMVA_MultiDrugNo.Style.Add("display", "");
                                RequiredFieldValidator rfvMVA_MultiDrugTestExplain = (RequiredFieldValidator)txtMVA_MultiDrug_test_explanation.FindControl("rfvNotes");
                                rfvMVA_MultiDrugTestExplain.Enabled = true;
                                txtMVA_MultiDrug_test_explanation.Text = string.IsNullOrEmpty(objDFV.drug_test_explanation) ? "" : objDFV.drug_test_explanation.ToString();
                            }
                        }


                    }
                    else
                    {
                        trMVAMulti_DrivenByCA_No.Style.Add("display", "");
                        rdoMVA_MultiDriven_By_Associate.SelectedValue = "0";
                        rfvMVA_MultiVehicle_Driven_By_Customer.Enabled = true;
                        if (objDFV.Vehicle_Driven_By_Customer != null)
                        {
                            if (objDFV.Vehicle_Driven_By_Customer == true)
                            {
                                //rfvMVA_MultiAddress_No.Enabled = true;
                                //rfvMVA_MultiName_No.Enabled = true;
                                //rfvMVA_MultiPhone_No.Enabled = true;
                                txtMVA_MultiAddress_No.Text = string.IsNullOrEmpty(objDFV.Address) ? "" : objDFV.Address;
                                txtMVA_MultiName_No.Text = string.IsNullOrEmpty(objDFV.Name) ? "" : objDFV.Name;
                                txtMVA_MultiPhone_No.Text = string.IsNullOrEmpty(objDFV.Phone) ? "" : objDFV.Phone;
                                rfvMVA_Multicustomer_injured.Enabled = true;
                                rdoMVA_MultiVehicle_Driven_By_Customer.SelectedValue = "1";
                                trMVA_MultiCust_Injured.Style.Add("display", "");
                                trMVA_MultiCust_Not_Injured.Style.Add("display", "none");
                                if (objDFV.Cutomer_Injured != null)
                                {
                                    if (objDFV.Cutomer_Injured == true)
                                    {
                                        rdoMVA_Multicustomer_injured.SelectedValue = "1";
                                    }
                                    else
                                    {
                                        rdoMVA_Multicustomer_injured.SelectedValue = "0";
                                    }
                                }
                            }
                            else
                            {
                                trMVA_MultiCust_Not_Injured.Style.Add("display", "");
                                RequiredFieldValidator rfvMVA_MultiNot_Driven_By_Customer_Explain = (RequiredFieldValidator)txtMVA_MultiNot_Driven_By_Customer_Explain.FindControl("rfvNotes");
                                rfvMVA_MultiNot_Driven_By_Customer_Explain.Enabled = true;
                                txtMVA_MultiNot_Driven_By_Customer_Explain.Text = string.IsNullOrEmpty(objDFV.Not_Driven_By_Customer_Explain) ? "" : objDFV.Not_Driven_By_Customer_Explain;
                                rdoMVA_MultiVehicle_Driven_By_Customer.SelectedValue = "0";
                                trMVA_MultiCust_Injured.Style.Add("display", "none");
                            }
                        }
                    }
                }
                gvMVAMulti_Passenger.DataSource = null;
                gvMVAMulti_Passenger.DataBind();
                if (objDFV.Additional_passengers != null)
                {
                    if (objDFV.Additional_passengers == true)
                    {
                        trMVA_MultiAdditional_passengers_Yes.Style.Add("display", "");
                        rdoMVA_MultiAdditional_passengers.SelectedValue = "1";
                        BindPassengerGrid(gvMVAMulti_Passenger, PK_DPD_FR_Multi_Vehicle_ID);
                    }
                    else
                    {
                        trMVA_MultiAdditional_passengers_Yes.Style.Add("display", "none");
                        rdoMVA_MultiAdditional_passengers.SelectedValue = "0";
                    }
                }
                if (objDFV.seeking_subrogation != null)
                {
                    if (objDFV.seeking_subrogation == true)
                    {
                        trMVA_MultiSeeking_subrogation_Yes.Style.Add("display", "");
                        rdoMVA_MultiSeeking_subrogation.SelectedValue = "1";
                        txtMVA_MultiTPI_Carrier_name.Text = objDFV.TPI_Carrier_name;
                        txtMVA_Multitpi_contact.Text = objDFV.tpi_contact;
                        txtMVA_MultiTPI_Policy_number.Text = objDFV.TPI_Policy_number;
                        txtMVA_Multitpi_phone.Text = objDFV.tpi_phone;
                        txtMVA_Multitpi_address_1.Text = objDFV.tpi_Address_1;
                        txtMVA_Multitpi_address_2.Text = objDFV.tpi_Address_2;
                        txtMVA_Multitpi_City.Text = objDFV.tpi_City;
                        ddlMVA_Multitpi_State.ClearSelection();
                        ListItem lstState = ddlMVA_Multitpi_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.tpi_State) ? "0" : objDFV.tpi_State.ToString());
                        if (lstState != null)
                        {
                            lstState.Selected = true;
                        }
                        txtMVA_Multitpi_Zip_Code.Text = objDFV.tpi_Zip_Code;
                        txtMVA_MultiRecovered_Amount.Text = clsGeneral.GetStringValue(objDFV.recovered_amount);
                    }
                    else
                    {
                        rfvMVA_MultiNotice_only_claim.Enabled = true;
                        trMVA_MultiSeeking_subrogation_No.Style.Add("display", "");
                        if (objDFV.Notice_only_claim != null)
                        {
                            if (objDFV.Notice_only_claim == true)
                                rdoMVA_MultiNotice_only_claim.SelectedValue = "1";
                            else
                                rdoMVA_MultiNotice_only_claim.SelectedValue = "0";
                        }
                        //rdoMVA_MultiNotice_only_claim
                        rdoMVA_MultiSeeking_subrogation.SelectedValue = "0";
                        txtMVA_MultiRecovered_Amount.Text = clsGeneral.GetStringValue(objDFV.recovered_amount);
                    }

                }
                #endregion
                trRecoveredAmount.Style["display"] = trDealership.Style["display"] = trOtherPassengers.Style["display"] = trVehicleDrivenByCompanyAssoc.Style["display"] = trDamageEstimate.Style["display"] = "";
                break;

            //WHEN 2 THEN 'MVA – Damage (Multiple Vehicle)'
            case "2":
                lstCauseOfLoss.Items[4].Selected = true;
                #region MVA – Damage (Multiple Vehicle)
                txtMVA_MultiVehicle_Owner_Sonic.Text = string.IsNullOrEmpty(objDFV.Vehicle_Owner_Sonic) ? "" : objDFV.Vehicle_Owner_Sonic.ToString();
                txtMVA_MultiVehicle_Owner_Address.Text = string.IsNullOrEmpty(objDFV.Vehicle_Owner_Address) ? "" : objDFV.Vehicle_Owner_Address.ToString();
                txtMVA_MultiVehicle_Owner_Phone.Text = string.IsNullOrEmpty(objDFV.Vehicle_Owner_Phone) ? "" : objDFV.Vehicle_Owner_Phone.ToString();
                txtMVA_MultiDamage_Estimate.Text = clsGeneral.GetStringValue(objDFV.Damage_Estimate);
                if (objDFV.Driven_By_Associate != null)
                {
                    if (objDFV.Driven_By_Associate == true)
                    {
                        trMVAMulti_DrivenByCA_Yes.Style.Add("display", "");
                        txtMVA_MultiAddress_Yes.Text = string.IsNullOrEmpty(objDFV.Address) ? "" : objDFV.Address;
                        txtMVA_MultiName_Yes.Text = string.IsNullOrEmpty(objDFV.Name) ? "" : objDFV.Name;
                        txtMVA_MultiPhone_Yes.Text = string.IsNullOrEmpty(objDFV.Phone) ? "" : objDFV.Phone;
                        rfvMVA_MultiAssociate_Cited.Enabled = true;
                        rfvMVA_MultiDrug_test_performed.Enabled = true;
                        rdoMVA_MultiDriven_By_Associate.SelectedValue = "1";
                        if (objDFV.Associate_Cited != null)
                        {
                            if (objDFV.Associate_Cited == true)
                            {
                                trMVA_MultiCitation_Yes.Style.Add("display", "");
                                rdoMVA_MultiAssociate_Cited.SelectedValue = "1";
                                RequiredFieldValidator rfvMVA_MultiDesc_Citation = (RequiredFieldValidator)txtMVA_MultiDescription_Of_Citation.FindControl("rfvNotes");
                                rfvMVA_MultiDesc_Citation.Enabled = true;
                                txtMVA_MultiDescription_Of_Citation.Text = string.IsNullOrEmpty(objDFV.Description_Of_Citation) ? "" : objDFV.Description_Of_Citation.ToString();
                            }
                            else
                            {
                                rdoMVA_MultiAssociate_Cited.SelectedValue = "0";
                            }
                        }
                        if (objDFV.Associate_injured != null)
                        {
                            if (objDFV.Associate_injured == true)
                                rdoMVA_MultiAssociate_injured.SelectedValue = "1";
                            else
                                rdoMVA_MultiAssociate_injured.SelectedValue = "0";
                        }

                        if (objDFV.drug_test_performed != null)
                        {
                            if (objDFV.drug_test_performed == true)
                            {
                                rdoMVA_MultiDrug_test_performed.SelectedValue = "1";
                                trMVA_MultiDrugYes.Style.Add("display", "");
                                RequiredFieldValidator rfvMVA_MultiDrugTestResult = (RequiredFieldValidator)txtMVA_MultiDrug_test_results.FindControl("rfvNotes");
                                rfvMVA_MultiDrugTestResult.Enabled = true;
                                txtMVA_MultiDrug_test_results.Text = string.IsNullOrEmpty(objDFV.drug_test_results) ? "" : objDFV.drug_test_results.ToString();
                            }
                            else
                            {
                                rdoMVA_MultiDrug_test_performed.SelectedValue = "0";
                                trMVA_MultiDrugNo.Style.Add("display", "");
                                RequiredFieldValidator rfvMVA_MultiDrugTestExplain = (RequiredFieldValidator)txtMVA_MultiDrug_test_explanation.FindControl("rfvNotes");
                                rfvMVA_MultiDrugTestExplain.Enabled = true;
                                txtMVA_MultiDrug_test_explanation.Text = string.IsNullOrEmpty(objDFV.drug_test_explanation) ? "" : objDFV.drug_test_explanation.ToString();
                            }
                        }


                    }
                    else
                    {
                        trMVAMulti_DrivenByCA_No.Style.Add("display", "");
                        rdoMVA_MultiDriven_By_Associate.SelectedValue = "0";
                        rfvMVA_MultiVehicle_Driven_By_Customer.Enabled = true;
                        if (objDFV.Vehicle_Driven_By_Customer != null)
                        {
                            if (objDFV.Vehicle_Driven_By_Customer == true)
                            {
                                //rfvMVA_MultiAddress_No.Enabled = true;
                                //rfvMVA_MultiName_No.Enabled = true;
                                //rfvMVA_MultiPhone_No.Enabled = true;
                                txtMVA_MultiAddress_No.Text = string.IsNullOrEmpty(objDFV.Address) ? "" : objDFV.Address;
                                txtMVA_MultiName_No.Text = string.IsNullOrEmpty(objDFV.Name) ? "" : objDFV.Name;
                                txtMVA_MultiPhone_No.Text = string.IsNullOrEmpty(objDFV.Phone) ? "" : objDFV.Phone;
                                rfvMVA_Multicustomer_injured.Enabled = true;
                                rdoMVA_MultiVehicle_Driven_By_Customer.SelectedValue = "1";
                                trMVA_MultiCust_Injured.Style.Add("display", "");
                                trMVA_MultiCust_Not_Injured.Style.Add("display", "none");
                                if (objDFV.Cutomer_Injured != null)
                                {
                                    if (objDFV.Cutomer_Injured == true)
                                    {
                                        rdoMVA_Multicustomer_injured.SelectedValue = "1";
                                    }
                                    else
                                    {
                                        rdoMVA_Multicustomer_injured.SelectedValue = "0";
                                    }
                                }
                            }
                            else
                            {
                                trMVA_MultiCust_Not_Injured.Style.Add("display", "");
                                RequiredFieldValidator rfvMVA_MultiNot_Driven_By_Customer_Explain = (RequiredFieldValidator)txtMVA_MultiNot_Driven_By_Customer_Explain.FindControl("rfvNotes");
                                rfvMVA_MultiNot_Driven_By_Customer_Explain.Enabled = true;
                                txtMVA_MultiNot_Driven_By_Customer_Explain.Text = string.IsNullOrEmpty(objDFV.Not_Driven_By_Customer_Explain) ? "" : objDFV.Not_Driven_By_Customer_Explain;
                                rdoMVA_MultiVehicle_Driven_By_Customer.SelectedValue = "0";
                                trMVA_MultiCust_Injured.Style.Add("display", "none");
                            }
                        }
                    }
                }
                gvMVAMulti_Passenger.DataSource = null;
                gvMVAMulti_Passenger.DataBind();
                if (objDFV.Additional_passengers != null)
                {
                    if (objDFV.Additional_passengers == true)
                    {
                        trMVA_MultiAdditional_passengers_Yes.Style.Add("display", "");
                        rdoMVA_MultiAdditional_passengers.SelectedValue = "1";
                        BindPassengerGrid(gvMVAMulti_Passenger, PK_DPD_FR_Multi_Vehicle_ID);
                    }
                    else
                    {
                        trMVA_MultiAdditional_passengers_Yes.Style.Add("display", "none");
                        rdoMVA_MultiAdditional_passengers.SelectedValue = "0";
                    }
                }
                if (objDFV.seeking_subrogation != null)
                {
                    if (objDFV.seeking_subrogation == true)
                    {
                        trMVA_MultiSeeking_subrogation_Yes.Style.Add("display", "");
                        rdoMVA_MultiSeeking_subrogation.SelectedValue = "1";
                        txtMVA_MultiTPI_Carrier_name.Text = objDFV.TPI_Carrier_name;
                        txtMVA_Multitpi_contact.Text = objDFV.tpi_contact;
                        txtMVA_MultiTPI_Policy_number.Text = objDFV.TPI_Policy_number;
                        txtMVA_Multitpi_phone.Text = objDFV.tpi_phone;
                        txtMVA_Multitpi_address_1.Text = objDFV.tpi_Address_1;
                        txtMVA_Multitpi_address_2.Text = objDFV.tpi_Address_2;
                        txtMVA_Multitpi_City.Text = objDFV.tpi_City;
                        ddlMVA_Multitpi_State.ClearSelection();
                        ListItem lstState = ddlMVA_Multitpi_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.tpi_State) ? "0" : objDFV.tpi_State.ToString());
                        if (lstState != null)
                        {
                            lstState.Selected = true;
                        }
                        txtMVA_Multitpi_Zip_Code.Text = objDFV.tpi_Zip_Code;
                        txtMVA_MultiRecovered_Amount.Text = clsGeneral.GetStringValue(objDFV.recovered_amount);
                    }
                    else
                    {
                        rfvMVA_MultiNotice_only_claim.Enabled = true;
                        trMVA_MultiSeeking_subrogation_No.Style.Add("display", "");
                        if (objDFV.Notice_only_claim != null)
                        {
                            if (objDFV.Notice_only_claim == true)
                                rdoMVA_MultiNotice_only_claim.SelectedValue = "1";
                            else
                                rdoMVA_MultiNotice_only_claim.SelectedValue = "0";
                        }
                        //rdoMVA_MultiNotice_only_claim
                        rdoMVA_MultiSeeking_subrogation.SelectedValue = "0";
                        txtMVA_MultiRecovered_Amount.Text = clsGeneral.GetStringValue(objDFV.recovered_amount);
                    }

                }
                #endregion

                trVehicleOwner3.Style["display"] = trVehicleOwner2.Style["display"] = trVehicleOwner1.Style["display"] = trRecoveredAmount.Style["display"] = trDealership.Style["display"] = trOtherPassengers.Style["display"] = trVehicleDrivenByCompanyAssoc.Style["display"] = trDamageEstimate.Style["display"] = "";
                break;

            //WHEN 3 THEN 'Fruad'
            case "3":
                trWerePolicyNotified.Style["display"] = trVehicleInStorage.Style["display"] = trVehicleRecovered.Style["display"] = "";
                lstCauseOfLoss.Items[2].Selected = true;
                if (objDFV.Vehicle_Recovered != null)
                {
                    if (objDFV.Vehicle_Recovered == true)
                        rdo_Vehicle_Recovered.SelectedValue = "1";
                    else
                        rdo_Vehicle_Recovered.SelectedValue = "0";
                }
                if (objDFV.Vehicle_Recovered == true)
                {
                    td_VehicleRecovred.Style.Add("display", "");
                    //rfv_Damage_estimate.Enabled = true;
                    rfv_Dealership_Wish_To_Take_Possession.Enabled = true;
                    txt_Damage_estimate.Text = clsGeneral.GetStringValue(objDFV.Damage_Estimate);
                    if (objDFV.Dealership_Wish_To_Take_Possession != null)
                    {
                        if (objDFV.Dealership_Wish_To_Take_Possession == true)
                            rdo_Dealership_Wish_To_Take_Possession.SelectedValue = "1";
                        else
                            rdo_Dealership_Wish_To_Take_Possession.SelectedValue = "0";
                    }
                }
                if (objDFV.Vehicle_In_Storage != null)
                {
                    if (objDFV.Vehicle_In_Storage == true)
                        rdoVehicle_In_Storage.SelectedValue = "1";
                    else
                        rdoVehicle_In_Storage.SelectedValue = "0";
                }
                if (objDFV.Vehicle_In_Storage == true)
                {
                    tdVehicle_In_Storage.Style.Add("display", "");
                    //rfv_Storage_Address_1.Enabled = true;
                    //rfv_Storage_Contact.Enabled = true;
                    //rfv_Storage_Address_2.Enabled = true;
                    //rfv_Storage_phone.Enabled = true;
                    //rfv_Storage_City.Enabled = true;
                    //rfv_Storage_cost.Enabled = true;
                    //rfv_Storage_State.Enabled = true;
                    //rfv_storage_Zip_Code.Enabled = true;
                    txt_Storage_Address_1.Text = string.IsNullOrEmpty(objDFV.storage_Address_1) ? "" : objDFV.storage_Address_1.ToString();
                    txt_Storage_Address_2.Text = string.IsNullOrEmpty(objDFV.storage_Address_2) ? "" : objDFV.storage_Address_2.ToString();
                    txt_Storage_Contact.Text = string.IsNullOrEmpty(objDFV.Storage_Contact) ? "" : objDFV.Storage_Contact.ToString();
                    txt_Storage_phone.Text = string.IsNullOrEmpty(objDFV.Storage_phone) ? "" : objDFV.Storage_phone.ToString();
                    txt_Storage_City.Text = string.IsNullOrEmpty(objDFV.storage_City) ? "" : objDFV.storage_City.ToString();
                    txt_Storage_cost.Text = clsGeneral.GetStringValue(objDFV.storage_cost);
                    txt_storage_Zip_Code.Text = string.IsNullOrEmpty(objDFV.storage_Zip_Code) ? "" : objDFV.storage_Zip_Code.ToString();
                    ddl_Storage_State.ClearSelection();
                    ListItem lstState = ddl_Storage_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.storage_State) ? "0" : objDFV.storage_State.ToString());
                    if (lstState != null)
                    {
                        lstState.Selected = true;
                    }
                }
                if (objDFV.Police_Notified != null)
                {
                    if (objDFV.Police_Notified == true)
                        rdoPoliceNotified.SelectedValue = "1";
                    else
                        rdoPoliceNotified.SelectedValue = "0";
                }
                if (objDFV.Police_Notified == true)
                {
                    trPoliceNotified.Style.Add("display", "");
                    txtFraudReportNumber.Text = string.IsNullOrEmpty(objDFV.Police_Report_Number) ? "" : objDFV.Police_Report_Number.ToString();
                }
                break;

            //WHEN 4 THEN 'Theft'
            case "4":
                lstCauseOfLoss.Items[7].Selected = true;

                if (objDFV.Security_Video_Surveillance != null)
                {
                    if (objDFV.Security_Video_Surveillance == true)
                        rdoTheft_Security_Video_Surveillance.SelectedValue = "1";
                    else
                        rdoTheft_Security_Video_Surveillance.SelectedValue = "0";
                }

                if (objDFV.Vehicle_Recovered != null)
                {
                    if (objDFV.Vehicle_Recovered == true)
                        rdo_Vehicle_Recovered.SelectedValue = "1";
                    else
                        rdo_Vehicle_Recovered.SelectedValue = "0";
                }
                if (objDFV.Vehicle_Recovered == true)
                {
                    td_VehicleRecovred.Style.Add("display", "");
                    //rfv_Damage_estimate.Enabled = true;
                    rfv_Dealership_Wish_To_Take_Possession.Enabled = true;
                    txt_Damage_estimate.Text = clsGeneral.GetStringValue(objDFV.Damage_Estimate);
                    if (objDFV.Dealership_Wish_To_Take_Possession != null)
                    {
                        if (objDFV.Dealership_Wish_To_Take_Possession == true)
                            rdo_Dealership_Wish_To_Take_Possession.SelectedValue = "1";
                        else
                            rdo_Dealership_Wish_To_Take_Possession.SelectedValue = "0";
                    }
                }
                if (objDFV.Vehicle_In_Storage != null)
                {
                    if (objDFV.Vehicle_In_Storage == true)
                        rdoVehicle_In_Storage.SelectedValue = "1";
                    else
                        rdoVehicle_In_Storage.SelectedValue = "0";
                }
                if (objDFV.Vehicle_In_Storage == true)
                {
                    //rfv_Storage_Address_1.Enabled = true;
                    //rfv_Storage_Contact.Enabled = true;
                    //rfv_Storage_Address_2.Enabled = true;
                    //rfv_Storage_phone.Enabled = true;
                    //rfv_Storage_City.Enabled = true;
                    //rfv_Storage_cost.Enabled = true;
                    //rfv_Storage_State.Enabled = true;
                    //rfv_storage_Zip_Code.Enabled = true;
                    tdVehicle_In_Storage.Style.Add("display", "");
                    txt_Storage_Address_1.Text = string.IsNullOrEmpty(objDFV.storage_Address_1) ? "" : objDFV.storage_Address_1.ToString();
                    txt_Storage_Address_2.Text = string.IsNullOrEmpty(objDFV.storage_Address_2) ? "" : objDFV.storage_Address_2.ToString();
                    txt_Storage_Contact.Text = string.IsNullOrEmpty(objDFV.Storage_Contact) ? "" : objDFV.Storage_Contact.ToString();
                    txt_Storage_phone.Text = string.IsNullOrEmpty(objDFV.Storage_phone) ? "" : objDFV.Storage_phone.ToString();
                    txt_Storage_City.Text = string.IsNullOrEmpty(objDFV.storage_City) ? "" : objDFV.storage_City.ToString();
                    txt_Storage_cost.Text = clsGeneral.GetStringValue(objDFV.storage_cost);
                    txt_storage_Zip_Code.Text = string.IsNullOrEmpty(objDFV.storage_Zip_Code) ? "" : objDFV.storage_Zip_Code.ToString();
                    ddl_Storage_State.ClearSelection();
                    ListItem lstState = ddl_Storage_State.Items.FindByValue(string.IsNullOrEmpty(objDFV.storage_State) ? "0" : objDFV.storage_State.ToString());
                    if (lstState != null)
                    {
                        lstState.Selected = true;
                    }

                }
                trVehicleInStorage.Style["display"] = trVehicleRecovered.Style["display"] = "";
                break;

            //WHEN 5 THEN 'Partial Theft'
            case "5":
                lstCauseOfLoss.Items[6].Selected = true;
                if (objDFV.Security_Video_Surveillance != null)
                {
                    if (objDFV.Security_Video_Surveillance == true)
                        rdoTheft_Security_Video_Surveillance.SelectedValue = "1";
                    else
                        rdoTheft_Security_Video_Surveillance.SelectedValue = "0";
                }
                break;

            //WHEN 6 THEN 'Vandalism'
            case "6":
                lstCauseOfLoss.Items[8].Selected = true;
                if (objDFV.Security_Video_Surveillance != null)
                {
                    if (objDFV.Security_Video_Surveillance == true)
                        rdoTheft_Security_Video_Surveillance.SelectedValue = "1";
                    else
                        rdoTheft_Security_Video_Surveillance.SelectedValue = "0";
                }
                break;

            //WHEN 7 THEN 'Hail'
            case "7":
                lstCauseOfLoss.Items[3].Selected = true;
                break;

            //WHEN 8 THEN 'Flood'
            case "8":
                lstCauseOfLoss.Items[1].Selected = true;
                break;

            //WHEN 9 THEN 'Fire'
            case "9":
                lstCauseOfLoss.Items[0].Selected = true;
                break;

            //WHEN 10 THEN 'Wind'
            case "10":
                lstCauseOfLoss.Items[9].Selected = true;
                break;
        }
    }
}
