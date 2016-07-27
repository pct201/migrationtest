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
/// Description    : Used to add Property Information to current First Report Wizard ID.
///                  also display Record is View MOde
/// 
/// 
/// </summary>
public partial class SONIC_PropertyFirstReport : clsBasePage
{
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
    /// Denotes the Property First Report ID
    /// </summary>
    public int PK_Prop_FR_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Prop_FR_ID"]);
        }
        set { ViewState["PK_Prop_FR_ID"] = value; }
    }
    /// <summary>
    /// Denotes the Property Building Affected ID
    /// </summary>
    public int PK_Prop_FR_Building_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Prop_FR_Building_ID"]);
        }
        set { ViewState["PK_Prop_FR_Building_ID"] = value; }
    }
    /// <summary>
    /// Denotes the Property Witness Affected ID
    /// </summary>
    public int PK_Prop_FR_Witness_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Prop_FR_Witness_ID"]);
        }
        set { ViewState["PK_Prop_FR_Witness_ID"] = value; }
    }
    #endregion

    #region Page Load Event

    /// <summary>
    /// Page load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        SonicTab.SetSelectedTab(Controls_SONICtab_SonicTab.Tab.Property);
        //declare Handle of Attachment Control for File Upload
        txtCurrentDate.Text = DateTime.Now.ToShortDateString().ToString();
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
            //used to get PK id from Query String
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                try
                {
                    PK_Prop_FR_ID = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                    //set Page Mode as per User Access Type if it is View ONly than always open page in
                    //View Mode Only. else if the report is completed  than open page in View MOde Else in Edit MOde
                    if (Module_Access_Mode == AccessType.View_Only)
                    //if (UserAccessType == AccessType.View_Only)
                    {
                        strPageOpeMode = "view";
                    }
                    else
                    {
                        bool isReportCompleted = new Property_FR(PK_Prop_FR_ID).Complete;
                        strPageOpeMode = !isReportCompleted ? "edit" : "view";
                        //SonicInfo.ClaimLinkVisibility = isReportCompleted ? true : false;
                        Property_Claims property_Claims = new Property_Claims();
                        property_Claims.SelectByProperty_FR_ID(PK_Prop_FR_ID);
                        SonicInfo.SetClaimPostBackUrlAndVisibility(property_Claims.PK_Property_Claims_ID == null ? 0 : property_Claims.PK_Property_Claims_ID.Value, property_Claims.FK_First_Report_Wizard_ID);
                    }

                    btnSendMail.Visible = (UserAccessType == AccessType.Administrative_Access) && (new Property_FR(PK_Prop_FR_ID).Complete == true);
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
            //used to open Location Panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            if (strPageOpeMode == "add")
            {
                SetValidationsLocation();
                SetValidationsLossInfo();
                SetValidationsLossInfoBuilding();
                SetValidationsLossInfoWitness();
                SetValidationsComments();
                #region Location and Contact Panel
                //fill Sonic Location Number
                ComboHelper.FillSonicLocationNumberOnly(new DropDownList[] { ddlLocationNumber }, 0, true);
                //Fill Location dba Dropdown
                ComboHelper.FillLocationdba(new DropDownList[] { ddlLocationdba }, 0, true);
                //Fill Location Legal Entity Dropdown
                //ComboHelper.FillLocationLegal_EntityForView(new DropDownList[] { ddlLegalEntity }, 0, true);
                //Fill Location FKA Dropdown
                ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);
                //Fetch Related Record for Location and EMployee
                BindLocationandContactInfo();
                
                #endregion

                #region Loss Information
                //fill State
                ComboHelper.FillState(new DropDownList[] { ddlB_State, ddlW_State }, 0, true);
                #endregion

                #region "Comments and Attachments"
                CtrlAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Property_FR, PK_Prop_FR_ID, true, 3);
                CtrlAttachDetails.Bind();
                #endregion
            }
            else if (strPageOpeMode == "view")
            {
                //Bind Page in View Mode
                BindPageInViewMode();
                
            }
            else if (strPageOpeMode == "edit")
            {
                SetValidationsLocation();
                SetValidationsLossInfo();
                SetValidationsLossInfoBuilding();
                SetValidationsLossInfoWitness();
                SetValidationsComments();
                #region Location and Contact Panel
                //fill Sonic Location Number
                ComboHelper.FillSonicLocationNumberOnlyForView(new DropDownList[] { ddlLocationNumber }, 0, true);
                //Fill Location dba Dropdown
                ComboHelper.FillLocationdbaOnlyForView(new DropDownList[] { ddlLocationdba }, 0, true);
                //Fill Location Legal Entity Dropdown
                //ComboHelper.FillLocationLegal_EntityForView(new DropDownList[] { ddlLegalEntity }, 0, true);
                //Fill Location FKA Dropdown
                ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);
                //Fetch Related Record for Location and EMployee
                BindLocationandContactInfo();
                #endregion

                #region Loss Information
                //fill State
                ComboHelper.FillState(new DropDownList[] { ddlB_State, ddlW_State }, 0, true);
                #endregion

                // Bind Page in Edit Mode
                BindPageInEditMode();
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
                    int retVal = ComplateProperty_FRReport(false);
                    if (retVal == 1)
                    {
                        Response.Redirect("FirstReportStatus.aspx");
                    }
                    else if (retVal == -1)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('First Report is Already Submited.');ShowPanel(3);", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The First Report e-mail send without the attachments.');ShowPanel(3);", true);
                    }
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
    /// <summary>
    /// Used to Add BUilding Affetced record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddBuilding_Click(object sender, EventArgs e)
    {
        //if main Property Id that are used in Property_FR_Building table as Foreign kry. if this id is equal to 0 than no record is inserted
        if (PK_Prop_FR_ID > 0)
        {
            // Creating Object
            Property_FR_Building objPFB = new Property_FR_Building(PK_Prop_FR_Building_ID);

            objPFB.Occupancy = txtB_Occupancy.Text;
            objPFB.Address_1 = txtB_Address_1.Text;
            objPFB.Address_2 = txtB_Address_2.Text;
            objPFB.City = txtB_City.Text;
            objPFB.State = (ddlB_State.SelectedIndex > 0) ? ddlB_State.SelectedValue.ToString() : "0";
            objPFB.Zip = txtB_Zip.Text;
            objPFB.FK_Property_FR_ID = PK_Prop_FR_ID;
            //if PK id Greater > 0 than Update Else INsert
            if (PK_Prop_FR_Building_ID > 0)
            {
                objPFB.Update();
                PK_Prop_FR_Building_ID = 0;
                btnAddBuilding.Text = "Add";
            }
            else
            {
                PK_Prop_FR_Building_ID = objPFB.Insert();
                PK_Prop_FR_Building_ID = 0;
            }

            btnBuildingAudit.Visible = false;
            //Bind Grid
            BindBuildingGrid();
            //Clear COntrols
            clearBuldingControls();
        }
    }
    /// <summary>
    /// Used to add new Witness Record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddWitness_Click(object sender, EventArgs e)
    {
        //if main Property Id that are used in Property_FR_Witness table as Foreign kry. if this id is equal to 0 than no record is inserted
        if (PK_Prop_FR_ID > 0)
        {
            //Creating Object
            Property_FR_Witness objPFW = new Property_FR_Witness(PK_Prop_FR_Witness_ID);
            {
                objPFW.Name = txtW_Name.Text;
                objPFW.Address_1 = txtW_Address_1.Text;
                objPFW.Address_2 = txtW_Address_2.Text;
                objPFW.City = txtW_City.Text;
                objPFW.State = (ddlW_State.SelectedIndex > 0) ? ddlW_State.SelectedValue.ToString() : "0";
                objPFW.Zip = txtW_Zip.Text;
                objPFW.FK_Property_FR_ID = PK_Prop_FR_ID;
                //used to check PK id of Property_FR_Witness table. if it is greater than 0 than update values else Insert new record
                if (PK_Prop_FR_Witness_ID > 0)
                {
                    objPFW.Update();
                    PK_Prop_FR_Witness_ID = 0;
                    btnAddWitness.Text = "Add";
                }
                else
                {
                    PK_Prop_FR_Witness_ID = objPFW.Insert();
                    PK_Prop_FR_Witness_ID = 0;
                }
                btnWitnessAudit.Visible = false;
                //Bind Grid
                BindWitnessGrid();
                //Clear COntrols
                clearWitnessControls();
            }
        }
    }
    #endregion

    #region Save and COntinue Button EVents
    /// <summary>
    /// Button Click Event - To Save Location Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLocationSave_Click(object sender, EventArgs e)
    {
        //Update Location information
        UpdateLocationInformation();
        //used to open Loss Information panel using ShowPanel Javascript function
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:ShowPanel(2);", true);
    }

    /// <summary>
    /// Button Click Event - To Save Loss Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLossSave_Click(object sender, EventArgs e)
    {
        //update Loss Information
        UpdateLossInformation();
        //Bind Sonic Header
        setSonicHeaderInfo();
        //used to open Commment Information panel using ShowPanel Javascript function
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:ShowPanel(3);", true);
    }

    /// <summary>
    /// Button Click Event to Submit 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Complate Property_First Report and Send Email.
        int retVal = ComplateProperty_FRReport(true);
        if (retVal == 1)
        {
            Response.Redirect("FirstReportStatus.aspx");
        }
        else if (retVal == -1)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('First Report is Already Submited.');ShowPanel(3);", true);
        }
        else
        {
            //used to open Comment and Attachment Panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
        }
    }

    private void CopyDataToPropertyClaim()
    {
        Property_Claims.CopyDataFromFRToClaims(PK_Prop_FR_ID, (int)clsGeneral.Major_Coverage.Property_Claims);
    }

    /// <summary>
    /// Copy files from Property_FR to Property_Claims folders
    /// </summary>
    private void CopyFolderStructure()
    {
        DataSet dsAttachmentData = Property_FR_Attacments.SelectByFK_Property_FR_ID(PK_Prop_FR_ID);
        if (dsAttachmentData != null && dsAttachmentData.Tables.Count > 0 && dsAttachmentData.Tables[0] != null)
        {
            string strSourcePath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)clsGeneral.Tables.Property_FR]);
            string strDestPath = clsGeneral.GetAttachmentDocPath(clsGeneral.TableNames[(int)clsGeneral.Tables.Property_Claims]);
            string DocSourcePath = string.Concat(strSourcePath, "\\");
            string DocDestPath = string.Concat(strDestPath, "\\");
            string strSourceFullName = string.Empty, strDestFullName = string.Empty;
            foreach (DataRow dr in dsAttachmentData.Tables[0].Rows)
            {
                strSourceFullName = DocSourcePath + Convert.ToString(dr["Attachment_Path"]);
                strDestFullName = DocDestPath + Convert.ToString(dr["Attachment_Path"]);
                clsGeneral.CopyFile(strSourceFullName, strDestFullName, true, false);
            }
        }
    }

    #endregion

    #region Location and Contact Panel Events
    /// <summary>
    /// Used to Bind Location Information and Contact Details
    /// </summary>
    public void BindLocationandContactInfo()
    {
        DataSet dsFRW = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.Property_FR, PK_Prop_FR_ID);
        DataTable dtFRW = dsFRW.Tables[0];
        foreach (DataRow drFRW in dtFRW.Rows)
        {
            #region Fill Location Information Controls
            //select value from Location Number Dropdown
            if (drFRW["Sonic_Location_Code"] != null)
            {
                ListItem lstRLM = new ListItem();
                lstRLM = ddlLocationNumber.Items.FindByText(drFRW["Sonic_Location_Code"].ToString());
                //check list item if not null than list item selected = true
                if (lstRLM != null)
                {
                    lstRLM.Selected = true;
                }
            }
            //select value from Location d/b/a Dropdown
            if (drFRW["dba"] != null)
            {
                ListItem lstdba = new ListItem();
                lstdba = ddlLocationdba.Items.FindByText(drFRW["dba"].ToString());
                //check list item if not null than list item selected = true
                if (lstdba != null)
                {
                    lstdba.Selected = true;
                }
            }
            //select value from Location f/k/a Dropdown
            if (drFRW["FK_Location_ID"] != null)
            {
                //Fill Location FKA Dropdown
                ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, (drFRW["FK_Location_ID"] != null) ? Convert.ToInt32(drFRW["FK_Location_ID"]) : 0, true);
            }
            //select value from Location Legal Entity Dropdown
            //if (drFRW["legal_entity"] != null)
            //{
            //    ListItem lstLE = new ListItem();
            //    lstLE = ddlLegalEntity.Items.FindByText(drFRW["legal_entity"].ToString().Trim());
            //    //check list item if not null than list item selected = true
            //    if (lstLE != null)
            //    {
            //        lstLE.Selected = true;
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

            txtContactName.Text = (drFRW["EmployeeName"] != null) ? Convert.ToString(drFRW["EmployeeName"]) : "";
            txtContact_Best_Time.Text = (drFRW["Contact_Best_Time"] != null) ? Convert.ToString(drFRW["Contact_Best_Time"]) : "";
            txtContactTelephoneNumber1.Text = (drFRW["TelephoneNumber1"] != null) ? Convert.ToString(drFRW["TelephoneNumber1"]) : "";
            txtContactTelephoneNumber2.Text = (drFRW["TelephoneNumber2"] != null) ? Convert.ToString(drFRW["TelephoneNumber2"]) : "";
            txtContactFaxNumber.Text = (drFRW["Contact_Fax"] != null) ? Convert.ToString(drFRW["Contact_Fax"]) : "";
            txtContactEmailAddress.Text = (drFRW["FRWEmail"] != null) ? Convert.ToString(drFRW["FRWEmail"]) : "";
            //fill Controls By Cost Center Value
            txtCostCenterdba.Text = (drFRW["dba"] != null) ? Convert.ToString(drFRW["dba"]) : "";
            txtCostCenterAddress1.Text = (drFRW["Employee_Address_1"] != null) ? Convert.ToString(drFRW["Employee_Address_1"]) : "";
            txtCostCenterAddress2.Text = (drFRW["Employee_Address_2"] != null) ? Convert.ToString(drFRW["Employee_Address_2"]) : "";
            txtCostCenterCity.Text = (drFRW["Employee_City"] != null) ? Convert.ToString(drFRW["Employee_City"]) : "";
            txtCostCenterState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state;
            txtCostCenterZipCode.Text = (drFRW["Employee_Zip_Code"] != null) ? Convert.ToString(drFRW["Employee_Zip_Code"]) : "";

            #endregion

            //used to Disable all COntrols
            DisableEnableControls(false);
        }
    }
    /// <summary>
    /// Used to disable Location Information
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

    //Used to Update Location Information
    public void UpdateLocationInformation()
    {
        //Update Fax Number to First_Report_Wizard Table
        First_Report_Wizard objFRW = new First_Report_Wizard(First_Report_Wizard_ID);
        objFRW.Contact_Best_Time = txtContact_Best_Time.Text;
        objFRW.Contact_Fax = txtContactFaxNumber.Text;
        //check if First_Report_Wizard_ID > 0 than Update record
        if (First_Report_Wizard_ID > 0)
        {
            objFRW.Update();
        }

        //Update Sonic Reported Date to Property Table
        Property_FR objPro_FR = new Property_FR(PK_Prop_FR_ID);
        objPro_FR.Date_Reported_to_Sonic = clsGeneral.FormatDateToStore(txtDate_Reported_To_Sonic);
        //if Property ID > 0 than Update table
        if (PK_Prop_FR_ID > 0)
        {
            objPro_FR.Update();
        }
    }
    #endregion

    #region Loss Information Panel Events

    /// <summary>
    /// Method - to update Loss information
    /// </summary>
    public void UpdateLossInformation()
    {
        //Create Object
        Property_FR objPro_FR = new Property_FR(PK_Prop_FR_ID);

        //set Values to Objects
        objPro_FR.Date_Of_Loss = clsGeneral.FormatDateToStore(txtDate_Of_Loss);
        objPro_FR.Time_Of_Loss = txtTime_Of_Loss.Text;
        objPro_FR.Fire = chkFire.Checked;
        objPro_FR.Property_Damage_by_Sonic_Associate = chkProperty_Damage_by_Sonic_Associate.Checked;
        objPro_FR.Wind_Damage = chkWind_Damage.Checked;
        objPro_FR.Environmental_Loss = chkEnvironmental_Loss.Checked;
        objPro_FR.Hail_Damage = chkHail_Damage.Checked;
        objPro_FR.Vandalism_To_The_Property = chkVandalism_To_The_Property.Checked;
        objPro_FR.Earth_Movement = chkEnvironmental_Loss.Checked;
        objPro_FR.Theft_Associate_Tools = chkTheft_Associate_Tools.Checked;
        objPro_FR.Flood = chkFlood.Checked;
        objPro_FR.Theft_All_Other = chkTheft_All_Other.Checked;
        objPro_FR.Third_Party_Property_Damage = chkThird_Party_Property_Damage.Checked;
        objPro_FR.Other = chkOther.Checked;
        objPro_FR.Description_of_Loss = txtDescription_of_Loss.Text;
        objPro_FR.Damage_Building_Facilities_Est_Cost = string.IsNullOrEmpty(txtDamage_Building_Facilities_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Building_Facilities_Est_Cost.Text);
        objPro_FR.Damage_Building_Facilities_Actual_Cost = string.IsNullOrEmpty(txtDamage_Building_Facilities_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Building_Facilities_Actual_Cost.Text);
        objPro_FR.Damage_Equipment_Est_Cost = string.IsNullOrEmpty(txtDamage_Equipment_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Equipment_Est_Cost.Text);
        objPro_FR.Damage_Equipment_Actual_Cost = string.IsNullOrEmpty(txtDamage_Equipment_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Equipment_Actual_Cost.Text);
        objPro_FR.Damage_Product_Damage_Est_Cost = string.IsNullOrEmpty(txtDamage_Product_Damage_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Product_Damage_Est_Cost.Text);
        objPro_FR.Damage_Product_Damage_Actual_Cost = string.IsNullOrEmpty(txtDamage_Product_Damage_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Product_Damage_Actual_Cost.Text);
        objPro_FR.Damage_Parts_Est_Cost = string.IsNullOrEmpty(txtDamage_Parts_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Parts_Est_Cost.Text);
        objPro_FR.Damage_Parts_Actual_Cost = string.IsNullOrEmpty(txtDamage_Parts_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Parts_Actual_Cost.Text);
        objPro_FR.Damage_Salvage_Cleanup_Est_Cost = string.IsNullOrEmpty(txtDamage_Salvage_Cleanup_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Salvage_Cleanup_Est_Cost.Text);
        objPro_FR.Damage_Salvage_Cleanup_Actual_Cost = string.IsNullOrEmpty(txtDamage_Salvage_Cleanup_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Salvage_Cleanup_Actual_Cost.Text);
        objPro_FR.Damage_Decontamination_Est_Cost = string.IsNullOrEmpty(txtDamage_Decontamination_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Decontamination_Est_Cost.Text);
        objPro_FR.Damage_Decontamination_Actual_Cost = string.IsNullOrEmpty(txtDamage_Decontamination_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Decontamination_Actual_Cost.Text);
        objPro_FR.Damage_Electronic_Data_Est_Cost = string.IsNullOrEmpty(txtDamage_Electronic_Data_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Electronic_Data_Est_Cost.Text);
        objPro_FR.Damage_Electronic_Data_Actual_Cost = string.IsNullOrEmpty(txtDamage_Electronic_Data_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Electronic_Data_Actual_Cost.Text);
        objPro_FR.Damage_Service_Interruption_Est_Cost = string.IsNullOrEmpty(txtDamage_Service_Interruption_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Service_Interruption_Est_Cost.Text);
        objPro_FR.Damage_Service_Interruption_Actual_Cost = string.IsNullOrEmpty(txtDamage_Service_Interruption_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Service_Interruption_Actual_Cost.Text);
        objPro_FR.Damage_Payroll_Est_Cost = string.IsNullOrEmpty(txtDamage_Payroll_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Payroll_Est_Cost.Text);
        objPro_FR.Damage_Payroll_Actual_Cost = string.IsNullOrEmpty(txtDamage_Payroll_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Payroll_Actual_Cost.Text);
        objPro_FR.Damage_Loss_of_Sales_Est_Cost = string.IsNullOrEmpty(txtDamage_Loss_of_Sales_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Loss_of_Sales_Est_Cost.Text);
        objPro_FR.Damage_Loss_of_Sales_Actual_Cost = string.IsNullOrEmpty(txtDamage_Loss_of_Sales_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Loss_of_Sales_Actual_Cost.Text);
        objPro_FR.Date_Cleanup_Complete = clsGeneral.FormatDateToStore(txtDate_Cleanup_Complete);
        objPro_FR.Date_Repairs_Complete = clsGeneral.FormatDateToStore(txtDate_Repairs_Complete);
        objPro_FR.Date_Full_Service_Resumed = clsGeneral.FormatDateToStore(txtDate_Full_Service_Resumed);
        objPro_FR.Date_Fire_Protection_Services_Resumed = clsGeneral.FormatDateToStore(txtDate_Fire_Protection_Services_Resumed);
        if (rdo_Security_Video_Surveillance.SelectedValue == "1")
        {
            objPro_FR.Security_Video_Surveillance = true;
        }
        else if (rdo_Security_Video_Surveillance.SelectedValue == "0")
        {
            objPro_FR.Security_Video_Surveillance = false;
        }
        else
            objPro_FR.Security_Video_Surveillance = null;
        //if Property_P_Id > 0 than update Record
        if (PK_Prop_FR_ID > 0)
        {
            objPro_FR.Update();
        }
    }
    #endregion

    #region Comments and Attachment Panel Events

    /// <summary>
    /// Used to Update Property Table and Send an email.
    /// </summary>
    /// <returns></returns>
    public int ComplateProperty_FRReport(bool _IsAttachment)
    {
        //Check current Page opertaion if it is add mode then values are updated and Email is fired
        if (strPageOpeMode == "edit")
        {
            if (_IsAttachment)
            {
                Property_FR ObjProp_FR = new Property_FR(PK_Prop_FR_ID);
                if (ObjProp_FR.Complete)
                    return -1;

                ObjProp_FR.Comments = txtComments.Text;
                ObjProp_FR.Date_Report_Complete = txtDateReportComplate.Text;
                ObjProp_FR.Date_Claim_Closed = txtClaimClosed.Text;

                if (PK_Prop_FR_ID > 0)
                    ObjProp_FR.Update();

                CtrlAttachment.Add(clsGeneral.Tables.Property_FR, PK_Prop_FR_ID);
                CtrlAttachDetails.Bind();
                decimal FileSize = this.CtrlAttachDetails.GetTotalAttachmentsFileSize();
                if (FileSize > 9.5M)
                {
                    String confirmMessage = "The attachments to this First Report exceed the size limitations for e-mail. The First Report can be sent without the attachments or you can Cancel and remove or reduce the size of the exiting attachments. Do you want to send the First Report without the attachments?";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", " if(window.confirm('" + confirmMessage + "')){ __doPostBack('UserConfirmationPostBack','true');} else {alert('The First Report has NOT been sent, please reduce the number and/or size of the attachments before attempting to resubmit with attachments.');ShowPanel(3);}", true);
                    return 0;
                }
            }

            // Declare Object
            Property_FR objProp_FR = new Property_FR(PK_Prop_FR_ID);

            if (objProp_FR.Complete)
                return -1;

            //Assign Values
            objProp_FR.Comments = txtComments.Text;
            objProp_FR.Date_Report_Complete = txtDateReportComplate.Text;
            objProp_FR.Date_Claim_Closed = txtClaimClosed.Text;
            objProp_FR.Complete = true;
            //Update Values
            if (PK_Prop_FR_ID > 0)
                objProp_FR.Update();

            CopyDataToPropertyClaim();
            CopyFolderStructure();
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
            return 0;


    }

    #endregion

    #region Building Affected and Witness Grid View Bind

    /// <summary>
    /// Used to Bind a Building Grid
    /// </summary>
    public void BindBuildingGrid()
    {
        if (PK_Prop_FR_ID > 0)
        {
            DataTable dtBuilding = Property_FR_Building.GetBuildingResultByPropertyID(PK_Prop_FR_ID);
            gvBUilding.DataSource = dtBuilding;
            gvBUilding.DataBind();
        }
    }

    /// <summary>
    /// Used to Bind Witness Grid
    /// </summary>
    public void BindWitnessGrid()
    {
        if (PK_Prop_FR_ID > 0)
        {
            DataTable dtWitness = Property_FR_Witness.GetWitnessResultByPropertyID(PK_Prop_FR_ID);
            gvWitness.DataSource = dtWitness;
            gvWitness.DataBind();
        }
    }

    #endregion

    #region Claear Building Affected and Witness Controls

    /// <summary>
    /// Use to Clear Building Controls
    /// </summary>
    public void clearBuldingControls()
    {
        txtB_Occupancy.Text = "";
        txtB_Address_1.Text = "";
        txtB_Address_2.Text = "";
        txtB_City.Text = "";
        ddlB_State.SelectedValue = "0";
        txtB_Zip.Text = "";
    }

    //Use to Clear Witness Controls
    public void clearWitnessControls()
    {
        txtW_Name.Text = "";
        txtW_Address_1.Text = "";
        txtW_Address_2.Text = "";
        txtW_City.Text = "";
        ddlW_State.SelectedValue = "0";
        txtW_Zip.Text = "";
    }
    #endregion

    #region Building and Witness Grid Events

    /// <summary>
    /// Gridview Row Created Event - Building
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBUilding_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Check Row Type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtnRemove = (LinkButton)e.Row.FindControl("lnkRemove");
            //Check Link BUtton Found or Not
            if (lnkbtnRemove != null)
                lnkbtnRemove.CommandArgument = Convert.ToString(e.Row.RowIndex);

            LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            //Check Link Button Found Or Not
            if (lnkbtnEdit != null)
                lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }

    /// <summary>
    /// Grid View RowCommand EVent
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBUilding_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "Remove")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvBUilding.DataKeys[Index].Values["PK_Property_FR_Building_ID"] != null) ? Convert.ToInt32(gvBUilding.DataKeys[Index].Values["PK_Property_FR_Building_ID"]) : 0;
            //check if PK_ID > 0 than Delete selected row
            if (PK_ID > 0)
            {
                Property_FR_Building.DeleteByPK(PK_ID);
            }
            //Bind Grid
            BindBuildingGrid();
        }
        else if (e.CommandName == "Edit")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            PK_Prop_FR_Building_ID = (gvBUilding.DataKeys[Index].Values["PK_Property_FR_Building_ID"] != null) ? Convert.ToInt32(gvBUilding.DataKeys[Index].Values["PK_Property_FR_Building_ID"]) : 0;
            //check Property FR building ID if it is greater than 0  than set values to all building controls
            if (PK_Prop_FR_Building_ID > 0)
            {
                btnAddBuilding.Text = "Update";
                btnBuildingAudit.Visible = true;
                Property_FR_Building objPFB = new Property_FR_Building(PK_Prop_FR_Building_ID);
                txtB_Occupancy.Text = objPFB.Occupancy;
                txtB_Address_1.Text = objPFB.Address_1;
                txtB_Address_2.Text = objPFB.Address_2;
                txtB_City.Text = objPFB.City;
                //check string is null or empty. if false than select value to state Dropdown
                if (string.IsNullOrEmpty(objPFB.State) == false)
                {
                    ddlB_State.ClearSelection();
                    ListItem lstPFB_State = new ListItem();
                    lstPFB_State = ddlB_State.Items.FindByValue(objPFB.State.ToString());
                    if (lstPFB_State != null)
                        lstPFB_State.Selected = true;
                }
                txtB_Zip.Text = objPFB.Zip;
                btnBuildingAudit.Attributes.Add("onClick", "return AuditPopUpForBuilding(" + PK_Prop_FR_Building_ID + ");");
            }
        }
    }

    /// <summary>
    /// Grid view Rowediting event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBUilding_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }

    /// <summary>
    /// Grid View Row Created Event - Witness
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWitness_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // Used to check Row Type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtnRemove = (LinkButton)e.Row.FindControl("lnkRemove");
            //used to check Link button found or not
            if (lnkbtnRemove != null)
                lnkbtnRemove.CommandArgument = Convert.ToString(e.Row.RowIndex);

            LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            //used to check Link Button Found or not.
            if (lnkbtnEdit != null)
                lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }

    /// <summary>
    /// Grid View Row Command Event - Witness
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWitness_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //used to check Command Name if it is "Remove" than remove the selected Row.
        if (e.CommandName == "Remove")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvWitness.DataKeys[Index].Values["PK_Property_FR_Witness_ID"] != null) ? Convert.ToInt32(gvWitness.DataKeys[Index].Values["PK_Property_FR_Witness_ID"]) : 0;
            //check if PK id grater than 0 than delete selected value
            if (PK_ID > 0)
            {
                Property_FR_Witness.DeleteByPK(PK_ID);
            }
            //Bind Grid
            BindWitnessGrid();
        }
        else if (e.CommandName == "Edit")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            PK_Prop_FR_Witness_ID = (gvWitness.DataKeys[Index].Values["PK_Property_FR_Witness_ID"] != null) ? Convert.ToInt32(gvWitness.DataKeys[Index].Values["PK_Property_FR_Witness_ID"]) : 0;
            //check id Witness id > 0 than set all witness fields
            if (PK_Prop_FR_Witness_ID > 0)
            {
                btnAddWitness.Text = "Update";
                btnWitnessAudit.Visible = true;
                Property_FR_Witness objPFW = new Property_FR_Witness(PK_Prop_FR_Witness_ID);
                txtW_Name.Text = objPFW.Name;
                txtW_Address_1.Text = objPFW.Address_1;
                txtW_Address_2.Text = objPFW.Address_2;
                txtW_City.Text = objPFW.City;
                //check string is null or empty for State. if false than selected State value to drodown
                if (string.IsNullOrEmpty(objPFW.State) == false)
                {
                    ListItem lstPFW_State = new ListItem();
                    ddlW_State.ClearSelection();
                    lstPFW_State = ddlW_State.Items.FindByValue(objPFW.State.ToString());
                    //check list item if not null than list item selected = true
                    if (lstPFW_State != null)
                        lstPFW_State.Selected = true;
                }
                txtW_Zip.Text = objPFW.Zip;
                btnWitnessAudit.Attributes.Add("onClick", "return AuditPopUpForWitness(" + PK_Prop_FR_Witness_ID + ");");
            }
        }
    }

    /// <summary>
    /// Gridview Row Editing event - Witness
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWitness_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }

    #endregion

    #region Bind Page in VIew Mode

    /// <summary>
    /// Bind page controls in View Mode
    /// </summary>
    public void BindPageInViewMode()
    {
        if (First_Report_Wizard_ID > 0)
        {
            //Creating Object
            Property_FR objPro_FR = new Property_FR(PK_Prop_FR_ID);

            //blank a Submit report message
            lblSubmitMessage.Text = "";

            #region Location/Contact Information
            DataSet dsFRW = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.Property_FR, PK_Prop_FR_ID);
            DataTable dtFRW = dsFRW.Tables[0];
            DataRow drFRW = dtFRW.Rows[0];

            #region Fill Location Information Controls
            //select value from Location Number
            if (drFRW["Sonic_Location_Code"] != null)
                lblLocationNumber.Text = drFRW["Sonic_Location_Code"].ToString();
            else
                lblLocationNumber.Text = "";

            //select value from Location d/b/a
            if (drFRW["dba"] != null)
                lblLocationdba.Text = drFRW["dba"].ToString();
            else
                lblLocationdba.Text = "";

            //select value from Location f/k/a
            if (drFRW["FK_Location_ID"] != null)
                lblLocationfka.Text = new LU_Location_FKA(Convert.ToDecimal(drFRW["FK_Location_ID"])).fka;
            else
                lblLocationfka.Text = "";

            //select value from Location Legal Entity
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

            #region Fill Contact Information Controls

            lblContactName.Text = (drFRW["EmployeeName"] != null) ? Convert.ToString(drFRW["EmployeeName"]) : "";
            lblContact_Best_Time.Text = (drFRW["Contact_Best_Time"] != null) ? Convert.ToString(drFRW["Contact_Best_Time"]) : "";
            lblContactTelephoneNumber1.Text = (drFRW["TelephoneNumber1"] != null) ? Convert.ToString(drFRW["TelephoneNumber1"]) : "";
            lblContactTelephoneNumber2.Text = (drFRW["TelephoneNumber2"] != null) ? Convert.ToString(drFRW["TelephoneNumber2"]) : "";
            lblContactFaxNumber.Text = (drFRW["Contact_Fax"] != null) ? Convert.ToString(drFRW["Contact_Fax"]) : "";
            lblContactEmailAddress.Text = (drFRW["FRWEmail"] != null) ? Convert.ToString(drFRW["FRWEmail"]) : "";
            //fill Controls By Cost Center Value
            lblCostCenterdba.Text = (drFRW["dba"] != null) ? Convert.ToString(drFRW["dba"]) : "";
            lblCostCenterAddress1.Text = (drFRW["Employee_Address_1"] != null) ? Convert.ToString(drFRW["Employee_Address_1"]) : "";
            lblCostCenterAddress2.Text = (drFRW["Employee_Address_2"] != null) ? Convert.ToString(drFRW["Employee_Address_2"]) : "";
            lblCostCenterCity.Text = (drFRW["Employee_City"] != null) ? Convert.ToString(drFRW["Employee_City"]) : "";
            lblCostCenterState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state;
            lblCostCenterZipCode.Text = (drFRW["Employee_Zip_Code"] != null) ? Convert.ToString(drFRW["Employee_Zip_Code"]) : "";
            #endregion
            lblDate_Reported_To_Sonic.Text = clsGeneral.FormatDateToDisplay(objPro_FR.Date_Reported_to_Sonic);
            #endregion

            #region Loss Information
            lblDate_Of_Loss.Text = clsGeneral.FormatDateToDisplay(objPro_FR.Date_Of_Loss);
            lblTime_Of_Loss.Text = objPro_FR.Time_Of_Loss;
            chkViewFire.Checked = objPro_FR.Fire;
            chkViewProperty_Damage_by_Sonic_Associate.Checked = objPro_FR.Property_Damage_by_Sonic_Associate;
            chkViewWind_Damage.Checked = objPro_FR.Wind_Damage;
            chkViewEnvironmental_Loss.Checked = objPro_FR.Environmental_Loss;
            chkViewHail_Damage.Checked = objPro_FR.Hail_Damage;
            chkViewVandalism_To_The_Property.Checked = objPro_FR.Vandalism_To_The_Property;
            chkViewEarth_Movement.Checked = objPro_FR.Earth_Movement;
            chkViewTheft_Associate_Tools.Checked = objPro_FR.Theft_Associate_Tools;
            chkViewFlood.Checked = objPro_FR.Flood;
            chkViewTheft_All_Other.Checked = objPro_FR.Theft_All_Other;
            chkViewThird_Party_Property_Damage.Checked = objPro_FR.Third_Party_Property_Damage;
            chkViewOther.Checked = objPro_FR.Other;
            lblDescription_of_Loss.Text = objPro_FR.Description_of_Loss;
            decimal EstCount = 0;
            decimal actCount = 0;

            if (objPro_FR.Security_Video_Surveillance == true)
                lbl_Security_Video_Surveillance.Text = "Yes";
            else
                lbl_Security_Video_Surveillance.Text = "No";

            lblDamage_Building_Facilities_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Building_Facilities_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Building_Facilities_Est_Cost.ToString());

            lblDamage_Building_Facilities_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Building_Facilities_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Building_Facilities_Actual_Cost.ToString());

            lblDamage_Equipment_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Equipment_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Equipment_Est_Cost.ToString());

            lblDamage_Equipment_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Equipment_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Equipment_Actual_Cost.ToString());

            lblDamage_Product_Damage_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Product_Damage_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Product_Damage_Est_Cost.ToString());

            lblDamage_Product_Damage_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Product_Damage_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Product_Damage_Actual_Cost.ToString());

            lblDamage_Parts_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Parts_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Parts_Est_Cost.ToString());

            lblDamage_Parts_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Parts_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Parts_Actual_Cost.ToString());

            lblDamage_Salvage_Cleanup_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Salvage_Cleanup_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Salvage_Cleanup_Est_Cost.ToString());

            lblDamage_Salvage_Cleanup_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Salvage_Cleanup_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Salvage_Cleanup_Actual_Cost.ToString());

            lblDamage_Decontamination_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Decontamination_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Decontamination_Est_Cost.ToString());

            lblDamage_Decontamination_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Decontamination_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Decontamination_Actual_Cost.ToString());

            lblDamage_Electronic_Data_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Electronic_Data_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Electronic_Data_Est_Cost.ToString());

            lblDamage_Electronic_Data_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Electronic_Data_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Electronic_Data_Actual_Cost.ToString());

            lblDamage_Service_Interruption_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Service_Interruption_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Service_Interruption_Est_Cost.ToString());

            lblDamage_Service_Interruption_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Service_Interruption_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Service_Interruption_Actual_Cost.ToString());

            lblDamage_Payroll_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Payroll_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Payroll_Est_Cost.ToString());

            lblDamage_Payroll_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Payroll_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Payroll_Actual_Cost.ToString());

            lblDamage_Loss_of_Sales_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Loss_of_Sales_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Loss_of_Sales_Est_Cost.ToString());

            lblDamage_Loss_of_Sales_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Loss_of_Sales_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Loss_of_Sales_Actual_Cost.ToString());

            lblEstCalculated.Text = clsGeneral.GetStringValue(EstCount);
            lblActualCalculated.Text = clsGeneral.GetStringValue(actCount);

            lblDate_Cleanup_Complete.Text = clsGeneral.FormatDateToDisplay(objPro_FR.Date_Cleanup_Complete);
            lblDate_Repairs_Complete.Text = clsGeneral.FormatDateToDisplay(objPro_FR.Date_Repairs_Complete);
            lblDate_Full_Service_Resumed.Text = clsGeneral.FormatDateToDisplay(objPro_FR.Date_Full_Service_Resumed);
            lblDate_Fire_Protection_Services_Resumed.Text = clsGeneral.FormatDateToDisplay(objPro_FR.Date_Fire_Protection_Services_Resumed);

            #endregion

            #region Bind Building and Witness Grid in View Mode
            BindBuildingAffectedGrid();
            BindWitnessViewGrid();
            #endregion

            #region Comments and Attachments
            lblComments.Text = objPro_FR.Comments;
            lblDateReportComplate.Text = objPro_FR.Date_Report_Complete;
            lblClaimClosed.Text = objPro_FR.Date_Claim_Closed;
            CtrlViewAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Property_FR, PK_Prop_FR_ID, false, 3);
            CtrlViewAttachDetails.Bind();
            #endregion
        }
        else
        {
            Response.Redirect("FirstReportSearch.aspx", true);
        }
    }

    #region Bind Building Affected View Mode Grid

    /// <summary>
    /// used to bind Building Grid in View MOde
    /// </summary>
    public void BindBuildingAffectedGrid()
    {
        //used to check Property id if it is greater than 0 bind Building Grid
        if (PK_Prop_FR_ID > 0)
        {
            DataTable dtBuilding = Property_FR_Building.GetBuildingResultByPropertyID(PK_Prop_FR_ID);
            gvViewBUilding.DataSource = dtBuilding;
            gvViewBUilding.DataBind();
        }
    }

    #endregion

    #region Bind Witness View Mode Grid

    /// <summary>
    /// Bind Witness Grid in View Mode
    /// </summary>
    public void BindWitnessViewGrid()
    {
        //used to check Propety id if it greater than 0 bind Witness Grid
        if (PK_Prop_FR_ID > 0)
        {
            DataTable dtWitness = Property_FR_Witness.GetWitnessResultByPropertyID(PK_Prop_FR_ID);
            gvViewWitness.DataSource = dtWitness;
            gvViewWitness.DataBind();
        }
    }

    #endregion

    #region Builing and Witness Grid Events [View Mode]

    /// <summary>
    /// Grid View - Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvViewBUilding_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //used to check Row Type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkViewBuilding");
            //used to check Link button found or not
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }

    /// <summary>
    /// Grid View Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvViewBUilding_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //used to check Command Name
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvViewBUilding.DataKeys[Index].Values["PK_Property_FR_Building_ID"] != null) ? Convert.ToInt32(gvViewBUilding.DataKeys[Index].Values["PK_Property_FR_Building_ID"]) : 0;
            // pk Greater than 0 than set values to below foelds else fields are remain hidden
            if (PK_ID > 0)
            {
                btnViewBuildingAudit.Visible = true;
                btnViewBuildingAudit.Attributes.Add("onClick", "return AuditPopUpForBuilding(" + PK_ID + ");");
                Property_FR_Building objPFB = new Property_FR_Building(PK_ID);
                tdViewBuilding.Style.Add("display", "block");
                lblB_Occupancy.Text = objPFB.Occupancy;
                lblB_Address_1.Text = objPFB.Address_1;
                lblB_Address_2.Text = objPFB.Address_2;
                lblB_City.Text = objPFB.City;
                lblB_State.Text = new State(string.IsNullOrEmpty(objPFB.State) ? 0 : Convert.ToDecimal(objPFB.State)).FLD_state;
                lblB_Zip.Text = objPFB.Zip;
            }
            else
            {
                tdViewBuilding.Style.Add("display", "none");
                lblB_Occupancy.Text = "";
                lblB_Address_1.Text = "";
                lblB_Address_2.Text = "";
                lblB_City.Text = "";
                lblB_State.Text = "";
                lblB_Zip.Text = "";
            }
        }
    }

    /// <summary>
    /// Grid View Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvViewWitness_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //used to check Row Type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkViewWitness");
            //check lnkbt is found or not
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }

    /// <summary>
    /// Grid View Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvViewWitness_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //used to check command Name
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvViewWitness.DataKeys[Index].Values["PK_Property_FR_Witness_ID"] != null) ? Convert.ToInt32(gvViewWitness.DataKeys[Index].Values["PK_Property_FR_Witness_ID"]) : 0;
            //used to check PK id if greater than 0 than set values to below firelds else fields are empty and remains hidden
            if (PK_ID > 0)
            {
                btnViewWitnessAudit.Visible = true;
                btnViewWitnessAudit.Attributes.Add("onClick", "return AuditPopUpForWitness(" + PK_ID + ");");
                Property_FR_Witness objPFW = new Property_FR_Witness(PK_ID);
                tdViewWitness.Style.Add("display", "block");
                lblW_Name.Text = objPFW.Name;
                lblW_Address_1.Text = objPFW.Address_1;
                lblW_Address_2.Text = objPFW.Address_2;
                lblW_City.Text = objPFW.City;
                lblW_State.Text = new State(string.IsNullOrEmpty(objPFW.State) ? 0 : Convert.ToDecimal(objPFW.State)).FLD_state;
                lblW_Zip.Text = objPFW.Zip;
            }
            else
            {
                tdViewWitness.Style.Add("display", "none");
                lblW_Name.Text = "";
                lblW_Address_1.Text = "";
                lblW_Address_2.Text = "";
                lblW_City.Text = "";
                lblW_State.Text = "";
                lblW_Zip.Text = "";
            }
        }
    }

    #endregion

    #endregion

    #region Bind Page in Edit Mode

    /// <summary>
    /// Bind page in Edit Mode
    /// </summary>
    public void BindPageInEditMode()
    {
        if (First_Report_Wizard_ID > 0)
        {
            //Creating Object
            Property_FR objPro_FR = new Property_FR(PK_Prop_FR_ID);
            //used to check report is complete or not. if not than Message is display else not display
            if (objPro_FR.Complete == false)
            {
                //Hide Message of "This Report Has not been submitted"
                lblSubmitMessage.Text = "This Report has not been submitted";
            }
            else
            {
                lblSubmitMessage.Text = "";
            }
            #region Location/Contact Information
            DataSet dsFRW = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.Property_FR, PK_Prop_FR_ID);
            DataTable dtFRW = dsFRW.Tables[0];
            DataRow drFRW = dtFRW.Rows[0];

            #region Fill Location Information Controls
            //select value from Location Number Dropdown
            if (drFRW["Sonic_Location_Code"] != null)
            {
                ListItem lstLnumber = new ListItem();
                lstLnumber = ddlLocationNumber.Items.FindByText(drFRW["Sonic_Location_Code"].ToString());
                //check list item if not null than list item selected = true
                if (lstLnumber != null)
                    lstLnumber.Selected = true;
            }

            //select value from Location d/b/a Dropdown
            if (drFRW["dba"] != null)
            {
                ListItem lst = new ListItem();
                lst = ddlLocationdba.Items.FindByText(drFRW["dba"].ToString());
                //check list item if not null than list item selected = true
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
            //select value from Location f/k/a Dropdown
            if (drFRW["FK_Location_ID"] != null)
            {
                //Fill Location FKA Dropdown
                ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, (drFRW["FK_Location_ID"] != null) ? Convert.ToInt32(drFRW["FK_Location_ID"]) : 0, true);
            }

            //select value from Location Legal Entity Dropdown
            //if (drFRW["legal_entity"] != null)
            //{
            //    ListItem lst = new ListItem();
            //    lst = ddlLegalEntity.Items.FindByText(drFRW["legal_entity"].ToString());
            //    //check list item if not null than list item selected = true
            //    if (lst != null)
            //    {
            //        lst.Selected = true;
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

            txtContactName.Text = (drFRW["EmployeeName"] != null) ? Convert.ToString(drFRW["EmployeeName"]) : "";
            txtContact_Best_Time.Text = (drFRW["Contact_Best_Time"] != null) ? Convert.ToString(drFRW["Contact_Best_Time"]) : "";
            txtContactTelephoneNumber1.Text = (drFRW["TelephoneNumber1"] != null) ? Convert.ToString(drFRW["TelephoneNumber1"]) : "";
            txtContactTelephoneNumber2.Text = (drFRW["TelephoneNumber2"] != null) ? Convert.ToString(drFRW["TelephoneNumber2"]) : "";
            txtContactFaxNumber.Text = (drFRW["Contact_Fax"] != null) ? Convert.ToString(drFRW["Contact_Fax"]) : "";
            txtContactEmailAddress.Text = (drFRW["FRWEmail"] != null) ? Convert.ToString(drFRW["FRWEmail"]) : "";
            //fill Controls By Cost Center Value
            txtCostCenterdba.Text = (drFRW["dba"] != null) ? Convert.ToString(drFRW["dba"]) : "";
            txtCostCenterAddress1.Text = (drFRW["Employee_Address_1"] != null) ? Convert.ToString(drFRW["Employee_Address_1"]) : "";
            txtCostCenterAddress2.Text = (drFRW["Employee_Address_2"] != null) ? Convert.ToString(drFRW["Employee_Address_2"]) : "";
            txtCostCenterCity.Text = (drFRW["Employee_City"] != null) ? Convert.ToString(drFRW["Employee_City"]) : "";
            txtCostCenterState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state;
            txtCostCenterZipCode.Text = (drFRW["Employee_Zip_Code"] != null) ? Convert.ToString(drFRW["Employee_Zip_Code"]) : "";
            txtDate_Reported_To_Sonic.Text = clsGeneral.FormatDateToDisplay(objPro_FR.Date_Reported_to_Sonic);
            #endregion

            //used to Disable all COntrols
            DisableEnableControls(false);
            #endregion

            #region Loss Information
            txtDate_Of_Loss.Text = clsGeneral.FormatDateToDisplay(objPro_FR.Date_Of_Loss);
            txtTime_Of_Loss.Text = objPro_FR.Time_Of_Loss;
            chkFire.Checked = objPro_FR.Fire;
            chkProperty_Damage_by_Sonic_Associate.Checked = objPro_FR.Property_Damage_by_Sonic_Associate;
            chkWind_Damage.Checked = objPro_FR.Wind_Damage;
            chkEnvironmental_Loss.Checked = objPro_FR.Environmental_Loss;
            chkHail_Damage.Checked = objPro_FR.Hail_Damage;
            chkVandalism_To_The_Property.Checked = objPro_FR.Vandalism_To_The_Property;
            chkEarth_Movement.Checked = objPro_FR.Earth_Movement;
            chkTheft_Associate_Tools.Checked = objPro_FR.Theft_Associate_Tools;
            chkFlood.Checked = objPro_FR.Flood;
            chkTheft_All_Other.Checked = objPro_FR.Theft_All_Other;
            chkThird_Party_Property_Damage.Checked = objPro_FR.Third_Party_Property_Damage;
            chkOther.Checked = objPro_FR.Other;
            txtDescription_of_Loss.Text = objPro_FR.Description_of_Loss;
            if (objPro_FR.Security_Video_Surveillance != null)
            {
                if (objPro_FR.Security_Video_Surveillance == true)
                    rdo_Security_Video_Surveillance.SelectedValue = "1";
                else
                    rdo_Security_Video_Surveillance.SelectedValue = "0";
            }

            decimal EstCount = 0;
            decimal actCount = 0;
            txtDamage_Building_Facilities_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Building_Facilities_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Building_Facilities_Est_Cost.ToString());

            txtDamage_Building_Facilities_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Building_Facilities_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Building_Facilities_Actual_Cost.ToString());

            txtDamage_Equipment_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Equipment_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Equipment_Est_Cost.ToString());

            txtDamage_Equipment_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Equipment_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Equipment_Actual_Cost.ToString());

            txtDamage_Product_Damage_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Product_Damage_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Product_Damage_Est_Cost.ToString());

            txtDamage_Product_Damage_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Product_Damage_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Product_Damage_Actual_Cost.ToString());

            txtDamage_Parts_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Parts_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Parts_Est_Cost.ToString());

            txtDamage_Parts_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Parts_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Parts_Actual_Cost.ToString());

            txtDamage_Salvage_Cleanup_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Salvage_Cleanup_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Salvage_Cleanup_Est_Cost.ToString());

            txtDamage_Salvage_Cleanup_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Salvage_Cleanup_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Salvage_Cleanup_Actual_Cost.ToString());

            txtDamage_Decontamination_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Decontamination_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Decontamination_Est_Cost.ToString());

            txtDamage_Decontamination_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Decontamination_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Decontamination_Actual_Cost.ToString());

            txtDamage_Electronic_Data_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Electronic_Data_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Electronic_Data_Est_Cost.ToString());

            txtDamage_Electronic_Data_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Electronic_Data_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Electronic_Data_Actual_Cost.ToString());

            txtDamage_Service_Interruption_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Service_Interruption_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Service_Interruption_Est_Cost.ToString());

            txtDamage_Service_Interruption_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Service_Interruption_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Service_Interruption_Actual_Cost.ToString());

            txtDamage_Payroll_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Payroll_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Payroll_Est_Cost.ToString());

            txtDamage_Payroll_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Payroll_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Payroll_Actual_Cost.ToString());

            txtDamage_Loss_of_Sales_Est_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Loss_of_Sales_Est_Cost);
            EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Loss_of_Sales_Est_Cost.ToString());

            txtDamage_Loss_of_Sales_Actual_Cost.Text = clsGeneral.GetStringValue(objPro_FR.Damage_Loss_of_Sales_Actual_Cost);
            actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Loss_of_Sales_Actual_Cost.ToString());

            txtEstCalculated.Text = clsGeneral.GetStringValue(EstCount);
            txtActualCalculated.Text = clsGeneral.GetStringValue(actCount);

            txtDate_Cleanup_Complete.Text = clsGeneral.FormatDateToDisplay(objPro_FR.Date_Cleanup_Complete);
            txtDate_Repairs_Complete.Text = clsGeneral.FormatDateToDisplay(objPro_FR.Date_Repairs_Complete);
            txtDate_Full_Service_Resumed.Text = clsGeneral.FormatDateToDisplay(objPro_FR.Date_Full_Service_Resumed);
            txtDate_Fire_Protection_Services_Resumed.Text = clsGeneral.FormatDateToDisplay(objPro_FR.Date_Fire_Protection_Services_Resumed);

            #endregion

            #region Bind Building and Witness Grid
            BindWitnessGrid();
            BindBuildingGrid();
            #endregion

            #region Comments and Attachments
            txtComments.Text = objPro_FR.Comments;
            txtDateReportComplate.Text = objPro_FR.Date_Report_Complete;
            txtClaimClosed.Text = objPro_FR.Date_Claim_Closed;
            CtrlAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Property_FR, PK_Prop_FR_ID, true, 3);
            CtrlAttachDetails.Bind();
            #endregion
        }
        else
        {
            Response.Redirect("FirstReportSearch.aspx", true);
        }
    }

    #endregion

    #region Generate Email

    /// <summary>
    /// Used to Create Email Body
    /// </summary>
    /// <returns></returns>
    public string GenerateEMailBody(out string FirstReportNumber)
    {
        string strFilePath = HttpContext.Current.Server.MapPath("~/EmailTemplate/Property_FR.htm");
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

                //Creating Object
                Property_FR objPro_FR = new Property_FR(PK_Prop_FR_ID);

                #region Location/Contact Information
                DataSet dsFRW = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.Property_FR, PK_Prop_FR_ID);
                DataTable dtFRW = dsFRW.Tables[0];
                DataRow drFRW = dtFRW.Rows[0];

                #region Fill Location Information Controls

                FirstReportNumber = drFRW["FK_First_Report_ID"].ToString();
                decimal FR_Number = new Property_FR(FirstReportNumber.ToString() != string.Empty ? Convert.ToDecimal(FirstReportNumber) : 0).Property_FR_Number;
                strEbdy = strEbdy.Replace("[lblFirstReportNumber]", "Property-" + FR_Number.ToString());
                //select value from Location Number
                if (drFRW["Sonic_Location_Code"] != null)
                    strEbdy = strEbdy.Replace("[lblLocationNumber]", drFRW["Sonic_Location_Code"].ToString());
                else
                    strEbdy = strEbdy.Replace("[lblLocationNumber]", "");

                //select value from Location d/b/a
                if (drFRW["dba"] != null)
                    strEbdy = strEbdy.Replace("[lblLocationdba]", drFRW["dba"].ToString());
                else
                    strEbdy = strEbdy.Replace("[lblLocationdba]", "");

                //select value from Location f/k/a
                if (drFRW["FK_Location_ID"] != null)
                    strEbdy = strEbdy.Replace("[lblLocationfka]", new LU_Location_FKA(Convert.ToDecimal(drFRW["FK_Location_ID"])).fka);
                else
                    strEbdy = strEbdy.Replace("[lblLocationfka]", "");

                //select value from Location Legal Entity
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

                strEbdy = strEbdy.Replace("[lblContactName]", (drFRW["EmployeeName"] != null) ? Convert.ToString(drFRW["EmployeeName"]) : "");
                strEbdy = strEbdy.Replace("[lblContact_Best_Time]", (drFRW["Contact_Best_Time"] != null) ? Convert.ToString(drFRW["Contact_Best_Time"]) : "");
                strEbdy = strEbdy.Replace("[lblContactTelephoneNumber1]", (drFRW["TelephoneNumber1"] != null) ? Convert.ToString(drFRW["TelephoneNumber1"]) : "");
                strEbdy = strEbdy.Replace("[lblContactTelephoneNumber2]", (drFRW["TelephoneNumber2"] != null) ? Convert.ToString(drFRW["TelephoneNumber2"]) : "");
                strEbdy = strEbdy.Replace("[lblContactFaxNumber]", (drFRW["Contact_Fax"] != null) ? Convert.ToString(drFRW["Contact_Fax"]) : "");
                strEbdy = strEbdy.Replace("[lblContactEmailAddress]", (drFRW["FRWEmail"] != null) ? Convert.ToString(drFRW["FRWEmail"]) : "");
                //fill Controls By Cost Center Value
                strEbdy = strEbdy.Replace("[lblCostCenterdba]", (drFRW["dba"] != null) ? Convert.ToString(drFRW["dba"]) : "");
                strEbdy = strEbdy.Replace("[lblCostCenterAddress1]", (drFRW["Employee_Address_1"] != null) ? Convert.ToString(drFRW["Employee_Address_1"]) : "");
                strEbdy = strEbdy.Replace("[lblCostCenterAddress2]", (drFRW["Employee_Address_2"] != null) ? Convert.ToString(drFRW["Employee_Address_2"]) : "");
                strEbdy = strEbdy.Replace("[lblCostCenterCity]", (drFRW["Employee_City"] != null) ? Convert.ToString(drFRW["Employee_City"]) : "");
                strEbdy = strEbdy.Replace("[lblCostCenterState]", new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state);
                strEbdy = strEbdy.Replace("[lblCostCenterZipCode]", (drFRW["Employee_Zip_Code"] != null) ? Convert.ToString(drFRW["Employee_Zip_Code"]) : "");
                strEbdy = strEbdy.Replace("[lblDate_Reported_To_Sonic]", clsGeneral.FormatDateToDisplay(objPro_FR.Date_Reported_to_Sonic));
                #endregion
                #endregion

                #region Bind Building Affected
                string strBuildingBody = "";
                DataTable dtBuilding = Property_FR_Building.GetBuildingResultByPropertyID(PK_Prop_FR_ID);
                //check data table have rows count greater than 0
                //if yes than generate table sturcture for Building affected records
                if (dtBuilding.Rows.Count > 0)
                {
                    strBuildingBody += "<table cellpadding='3' cellspacing='1' border='0' width='100%' style='background-color:Black;'>";
                    strBuildingBody += "<tr class='PropertyInfoBG'>";
                    strBuildingBody += "<td style='width:20%'>Occupancy</td>";
                    strBuildingBody += "<td style='width:20%'>Address</td>";
                    strBuildingBody += "<td style='width:20%'>City</td>";
                    strBuildingBody += "<td style='width:20%'>State</td>";
                    strBuildingBody += "<td style='width:20%'>Zip</td>";
                    strBuildingBody += "</tr>";
                    for (int intRCount = 0; intRCount < dtBuilding.Rows.Count; intRCount++)
                    {
                        DataRow drBuilding = dtBuilding.Rows[intRCount];
                        strBuildingBody += "<tr style='background-color:White;'>";
                        strBuildingBody += "<td>" + drBuilding["Occupancy"].ToString() + "</td>";
                        strBuildingBody += "<td>" + drBuilding["Address_1"].ToString() + "</td>";
                        strBuildingBody += "<td>" + drBuilding["City"].ToString() + "</td>";
                        strBuildingBody += "<td>" + new State(Convert.ToDecimal(drBuilding["State"])).FLD_state.ToString() + "</td>";
                        strBuildingBody += "<td>" + drBuilding["Zip"].ToString() + "</td>";
                        strBuildingBody += "</tr>";
                    }
                    strBuildingBody += "</table>";
                }
                strEbdy = strEbdy.Replace("[BuildingGrid]", strBuildingBody);
                #endregion

                #region Bind Witness Grid
                string strWitnessBody = "";
                DataTable dtWitness = Property_FR_Witness.GetWitnessResultByPropertyID(PK_Prop_FR_ID);
                //check witness record count.if greater than 0 than create table structure for Witness records for Email
                if (dtWitness.Rows.Count > 0)
                {
                    strWitnessBody += "<table cellpadding='3' cellspacing='1' border='0' width='100%' style='background-color:Black;'>";
                    strWitnessBody += "<tr class='PropertyInfoBG'>";
                    strWitnessBody += "<td style='width:20%'>Name</td>";
                    strWitnessBody += "<td style='width:20%'>Address</td>";
                    strWitnessBody += "<td style='width:20%'>City</td>";
                    strWitnessBody += "<td style='width:20%'>State</td>";
                    strWitnessBody += "<td style='width:20%'>Zip</td>";
                    strWitnessBody += "</tr>";
                    for (int intWCount = 0; intWCount < dtWitness.Rows.Count; intWCount++)
                    {
                        DataRow drWitness = dtWitness.Rows[intWCount];
                        strWitnessBody += "<tr style='background-color:White;'>";
                        strWitnessBody += "<td>" + drWitness["Name"].ToString() + "</td>";
                        strWitnessBody += "<td>" + drWitness["Address_1"].ToString() + "</td>";
                        strWitnessBody += "<td>" + drWitness["City"].ToString() + "</td>";
                        strWitnessBody += "<td>" + new State(Convert.ToDecimal(drWitness["State"])).FLD_state.ToString() + "</td>";
                        strWitnessBody += "<td>" + drWitness["Zip"].ToString() + "</td>";
                        strWitnessBody += "</tr>";
                    }
                    strWitnessBody += "</table>";
                }
                strEbdy = strEbdy.Replace("[WitnessGrid]", strWitnessBody);
                #endregion

                #region Loss Information
                strEbdy = strEbdy.Replace("[lblDate_Of_Loss]", clsGeneral.FormatDateToDisplay(objPro_FR.Date_Of_Loss));
                strEbdy = strEbdy.Replace("[lblTime_Of_Loss]", objPro_FR.Time_Of_Loss);
                strEbdy = strEbdy.Replace("[Fire]", (objPro_FR.Fire == true) ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[Property_Damage_by_Sonic_Associate]", (objPro_FR.Property_Damage_by_Sonic_Associate == true) ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[Wind_Damage]", (objPro_FR.Wind_Damage == true) ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[Environmental_Loss]", (objPro_FR.Environmental_Loss == true) ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[Hail_Damage]", (objPro_FR.Hail_Damage == true) ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[Vandalism_To_The_Property]", (objPro_FR.Vandalism_To_The_Property == true) ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[Earth_Movement]", (objPro_FR.Earth_Movement == true) ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[Theft_Associate_Tools]", (objPro_FR.Theft_Associate_Tools == true) ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[Flood]", (objPro_FR.Flood == true) ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[Theft_All_Other]", (objPro_FR.Theft_All_Other == true) ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[Third_Party_Property_Damage]", (objPro_FR.Third_Party_Property_Damage == true) ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[Other]", (objPro_FR.Other == true) ? "Yes" : "No");
                strEbdy = strEbdy.Replace("[lblDescription_of_Loss]", objPro_FR.Description_of_Loss);
                strEbdy = strEbdy.Replace("[lblSecurity_Video_Surveillance]", (objPro_FR.Security_Video_Surveillance == true) ? "Yes" : "No");
                decimal EstCount = 0;
                decimal actCount = 0;

                strEbdy = strEbdy.Replace("[lblDamage_Building_Facilities_Est_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Building_Facilities_Est_Cost));
                EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Building_Facilities_Est_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Building_Facilities_Actual_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Building_Facilities_Actual_Cost));
                actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Building_Facilities_Actual_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Equipment_Est_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Equipment_Est_Cost));
                EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Equipment_Est_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Equipment_Actual_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Equipment_Actual_Cost));
                actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Equipment_Actual_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Product_Damage_Est_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Product_Damage_Est_Cost));
                EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Product_Damage_Est_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Product_Damage_Actual_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Product_Damage_Actual_Cost));
                actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Product_Damage_Actual_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Parts_Est_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Parts_Est_Cost));
                EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Parts_Est_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Parts_Actual_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Parts_Actual_Cost));
                actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Parts_Actual_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Salvage_Cleanup_Est_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Salvage_Cleanup_Est_Cost));
                EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Salvage_Cleanup_Est_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Salvage_Cleanup_Actual_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Salvage_Cleanup_Actual_Cost));
                actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Salvage_Cleanup_Actual_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Decontamination_Est_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Decontamination_Est_Cost));
                EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Decontamination_Est_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Decontamination_Actual_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Decontamination_Actual_Cost));
                actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Decontamination_Actual_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Electronic_Data_Est_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Electronic_Data_Est_Cost));
                EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Electronic_Data_Est_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Electronic_Data_Actual_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Electronic_Data_Actual_Cost));
                actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Electronic_Data_Actual_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Service_Interruption_Est_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Service_Interruption_Est_Cost));
                EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Service_Interruption_Est_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Service_Interruption_Actual_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Service_Interruption_Actual_Cost));
                actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Service_Interruption_Actual_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Payroll_Est_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Payroll_Est_Cost));
                EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Payroll_Est_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Payroll_Actual_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Payroll_Actual_Cost));
                actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Payroll_Actual_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Loss_of_Sales_Est_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Loss_of_Sales_Est_Cost));
                EstCount = EstCount + Convert.ToDecimal(objPro_FR.Damage_Loss_of_Sales_Est_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblDamage_Loss_of_Sales_Actual_Cost]", clsGeneral.GetStringValue(objPro_FR.Damage_Loss_of_Sales_Actual_Cost));
                actCount = actCount + Convert.ToDecimal(objPro_FR.Damage_Loss_of_Sales_Actual_Cost.ToString());

                strEbdy = strEbdy.Replace("[lblEstCalculated]", clsGeneral.GetStringValue(EstCount));
                strEbdy = strEbdy.Replace("[lblActualCalculated]", clsGeneral.GetStringValue(actCount));

                strEbdy = strEbdy.Replace("[lblDate_Cleanup_Complete]", clsGeneral.FormatDateToDisplay(objPro_FR.Date_Cleanup_Complete));
                strEbdy = strEbdy.Replace("[lblDate_Repairs_Complete]", clsGeneral.FormatDateToDisplay(objPro_FR.Date_Repairs_Complete));
                strEbdy = strEbdy.Replace("[lblDate_Full_Service_Resumed]", clsGeneral.FormatDateToDisplay(objPro_FR.Date_Full_Service_Resumed));
                strEbdy = strEbdy.Replace("[lblDate_Fire_Protection_Services_Resumed]", clsGeneral.FormatDateToDisplay(objPro_FR.Date_Fire_Protection_Services_Resumed));

                #endregion

                #region Comments and Attachments
                strEbdy = strEbdy.Replace("[lblComments]", objPro_FR.Comments);
                strEbdy = strEbdy.Replace("[lblDateReportComplate]", objPro_FR.Date_Report_Complete);
                strEbdy = strEbdy.Replace("[lblClaimClosed]", objPro_FR.Date_Claim_Closed);
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
    /// Used to Upload Files
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {
        //Insert values into Property_FR_Attachment table
        CtrlAttachment.Add(clsGeneral.Tables.Property_FR, PK_Prop_FR_ID);

        // Used to Bind Grid with Attached Data
        CtrlAttachDetails.Bind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }

    #endregion

    #region Bind Sonic Header INformation Controls

    /// <summary>
    /// used to set values for sonic header control
    /// </summary>
    public void setSonicHeaderInfo()
    {
        //Create Object
        Property_FR objPro_FR = new Property_FR(PK_Prop_FR_ID);
        SonicInfo.FirstReportNumber = "Prop-" + objPro_FR.Property_FR_Number.ToString();
        SonicInfo.SONICLocationdba = new LU_Location(objPro_FR.FK_Location_Code).dba.ToString();
        SonicInfo.DateOfIncident = clsGeneral.FormatDateToDisplay(objPro_FR.Date_Of_Loss);
        
        //Set Claim Number
        DataTable dtClaimInfo = WC_ClaimInfo.Select_Claim_Number(Convert.ToInt32(objPro_FR.Property_FR_Number), "Property");
        if (dtClaimInfo.Rows.Count > 0)
        {
            SonicInfo.CurrentReportType = Controls_SONICInfo_SonicInfo.ReportType.Property;
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

    #region "Send Email"

    /// <summary>
    /// Send Mail - Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSendMail_Click(object sender, EventArgs e)
    {
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
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", " if(window.confirm('" + confirmMessage + "')){ __doPostBack('UserConfirmationPostBackView','true');} else {alert('The First Report has NOT been sent, please reduce the number and/or size of the attachments before attempting to resubmit with attachments.');ShowPanel(" + hdnCureentPanel.Value + ");}", true);
                return;
            }

            if (ResendMail(true))
                ScriptManager.RegisterStartupScript(this, Page.GetType(), System.DateTime.Now.ToString(), "javascript:alert('First Report mail send successfully');ShowPanel(" + hdnCureentPanel.Value + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "alert('Something went wrong. Please try after sometime.'); window.location='FirstReportSearch.aspx';", true);
        }
    }

    /// <summary>
    /// resend Mail - Method
    /// </summary>
    /// <param name="_IsAttachment"></param>
    private bool ResendMail(bool _IsAttachment)
    {
        // Declare Object
        Property_FR objProp_FR = new Property_FR(PK_Prop_FR_ID);
        int intCount = 0;
        //Get Attachment Details
        DataTable dtAtt = Property_FR_Attacments.SelectByFR_ID(PK_Prop_FR_ID).Tables[0];
        string[] strAtt = new string[dtAtt.Rows.Count];
        //Count the no of record find.
        if (_IsAttachment)
        {
            if (dtAtt.Rows.Count > 0)
            {
                foreach (DataRow drAtt in dtAtt.Rows)
                {
                    string strFileName = drAtt["Attachment_Path"].ToString();
                    strFileName = AppConfig.Property_FRDocPath + strFileName;
                    strAtt[intCount] = strFileName;
                    intCount = intCount + 1;
                }

            }
        }
        //get recipient Id
        //DataTable dtRecipient = Email_Settings.SelectByModuleName("PROP").Tables[0];
        DataTable dtRecipient = LU_Location.GetRecipientEmailID(objProp_FR.FK_Location_Code, LU_Location.SonicReportType.Property).Tables[0];
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
            decimal FR_Number = new Property_FR(ReturnFRNumber.ToString() != string.Empty ? Convert.ToDecimal(ReturnFRNumber) : 0).Property_FR_Number;

            if (EmailTo.Length > 0 && !string.IsNullOrEmpty(HtmlBody))
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));
                objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Repeat :: Sonic Automotive (acct #42979) reports the following First Report of Loss Property-" + FR_Number.ToString(), HtmlBody, true, (_IsAttachment ? strAtt : new string[] { }), AppConfig.MailCC);

                return true;
            }
            else
                return false;
            //clsGeneral.SendMailMessage(AppConfig.MailFrom, EmailTo, string.Empty, string.Empty, "Sonic Automotive reports the following First Report of Loss", HtmlBody, true, strAtt);
        }
        else
            return false;

    }

    /// <summary>
    /// Send First Report Mail - Method
    /// </summary>
    /// <param name="_IsAttachment"></param>
    private bool SendFirstReportMail(bool _IsAttachment)
    {
        Property_FR objProp_FR = new Property_FR(PK_Prop_FR_ID);

        int intCount = 0;
        //Get Attachment Details
        DataTable dtAtt = Property_FR_Attacments.SelectByFR_ID(PK_Prop_FR_ID).Tables[0];
        string[] strAtt = new string[dtAtt.Rows.Count];
        //Count the no of record find.
        if (_IsAttachment)
        {
            if (dtAtt.Rows.Count > 0)
            {
                foreach (DataRow drAtt in dtAtt.Rows)
                {
                    string strFileName = drAtt["Attachment_Path"].ToString();
                    strFileName = AppConfig.Property_FRDocPath + strFileName;
                    strAtt[intCount] = strFileName;
                    intCount = intCount + 1;
                }
            }
        }
        //get recipient Id
        //DataTable dtRecipient = Email_Settings.SelectByModuleName("PROP").Tables[0];
        DataTable dtRecipient = LU_Location.GetRecipientEmailID(objProp_FR.FK_Location_Code, LU_Location.SonicReportType.Property).Tables[0];
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
            decimal FR_Number = new Property_FR(ReturnFRNumber.ToString() != string.Empty ? Convert.ToDecimal(ReturnFRNumber) : 0).Property_FR_Number;
            //generate FIle and store it on disk
            StreamWriter sWriter = null;
            clsGeneral.CreateDirectory(AppConfig.SitePath + "SONIC-Email/" + clsSession.FirstName + "_" + clsSession.LastName + "/Property_FR/" + DateTime.Today.ToString("MM-dd-yyyy"));
            string strName = AppConfig.SitePath + "SONIC-Email/" + clsSession.FirstName + "_" + clsSession.LastName + "/Property_FR/" + DateTime.Today.ToString("MM-dd-yyyy") + "/Property_FR_Email_" + FR_Number.ToString() + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
            string strAttachmentName = AppConfig.SitePath + "SONIC-Email/" + clsSession.FirstName + "_" + clsSession.LastName + "/Property_FR/" + DateTime.Today.ToString("MM-dd-yyyy") + "/Property_FR_Attachment_" + FR_Number.ToString() + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
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
            if (EmailTo.Length > 0 && !string.IsNullOrEmpty(HtmlBody))
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));
                objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Sonic Automotive (acct #42979) reports the following First Report of Loss Property-" + FR_Number.ToString(), HtmlBody, true, finalAttachment, AppConfig.MailCC);

                return true;
            }
            else
                return false;
            //clsGeneral.SendMailMessage(AppConfig.MailFrom, EmailTo, string.Empty, string.Empty, "Sonic Automotive reports the following First Report of Loss", HtmlBody, true, strAtt);
        }
        else
            return false;
    }

    #endregion

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidationsLocation()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(22).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk1 = (Label)mnuProperty.Controls[0].FindControl("MenuAsterisk");
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 22").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "When to Contact": strCtrlsIDs += txtContact_Best_Time.ClientID + ","; strMessages += "Please enter [Location/Contact]/ When to Contact" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Fax Number": strCtrlsIDs += txtContactFaxNumber.ClientID + ","; strMessages += "Please enter [Location/Contact]/Fax Number" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Date Reported to Sonic": strCtrlsIDs += txtDate_Reported_To_Sonic.ClientID + ","; strMessages += "Please enter [Location/Contact]/Date Reported to Sonic" + ","; Span3.Style["display"] = "inline-block"; break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsLocation.Value = strCtrlsIDs;
        hdnErrorMsgsLocation.Value = strMessages;
    }

    /// <summary>
    /// Set all Validations - Loss Information
    /// </summary>
    private void SetValidationsLossInfo()
    {
        string strCtrlsIDsLossInfo = "";
        string strMessagesLossInfo = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(23).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk2 = (Label)mnuProperty.Controls[1].FindControl("MenuAsterisk");
        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 23").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date of Loss": strCtrlsIDsLossInfo += txtDate_Of_Loss.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Date of Loss" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Time of Loss": strCtrlsIDsLossInfo += txtTime_Of_Loss.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Time of Loss" + ","; Span5.Style["display"] = "inline-block"; break;
                case "Description of Loss": strCtrlsIDsLossInfo += txtDescription_of_Loss.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Description of Loss" + ","; Span18.Style["display"] = "inline-block"; break;
                case "Damages Estimated Cost - Building and Facilities": strCtrlsIDsLossInfo += txtDamage_Building_Facilities_Est_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Estimated Cost - Building and Facilities" + ","; Span19.Style["display"] = "inline-block"; break;
                case "Damages Estimated Cost - Equipment": strCtrlsIDsLossInfo += txtDamage_Equipment_Est_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Estimated Cost - Equipment" + ","; Span20.Style["display"] = "inline-block"; break;
                case "Damages Estimated Cost - Product Damage": strCtrlsIDsLossInfo += txtDamage_Product_Damage_Est_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Estimated Cost - Product Damage" + ","; Span21.Style["display"] = "inline-block"; break;
                case "Damages Estimated Cost - Parts": strCtrlsIDsLossInfo += txtDamage_Parts_Est_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Estimated Cost - Parts" + ","; Span22.Style["display"] = "inline-block"; break;
                case "Damages Estimated Cost - Salvage and Cleanup Expenses (including labor)": strCtrlsIDsLossInfo += txtDamage_Salvage_Cleanup_Est_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Estimated Cost - Salvage and Cleanup Expenses (including labor)" + ","; Span23.Style["display"] = "inline-block"; break;
                case "Damages Estimated Cost - Decontamination Expenses": strCtrlsIDsLossInfo += txtDamage_Decontamination_Est_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Estimated Cost - Decontamination Expenses" + ","; Span24.Style["display"] = "inline-block"; break;
                case "Damages Estimated Cost - Electronic Data/Processing Media": strCtrlsIDsLossInfo += txtDamage_Electronic_Data_Est_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Estimated Cost - Electronic Data/Processing Media" + ","; Span25.Style["display"] = "inline-block"; break;
                case "Damages Estimated Cost - Service Interruption": strCtrlsIDsLossInfo += txtDamage_Service_Interruption_Est_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Estimated Cost - Service Interruption" + ","; Span26.Style["display"] = "inline-block"; break;
                case "Damages Estimated Cost - Ordinary Payroll": strCtrlsIDsLossInfo += txtDamage_Payroll_Est_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Estimated Cost - Ordinary Payroll" + ","; Span27.Style["display"] = "inline-block"; break;
                case "Damages Estimated Cost - Loss of Sales": strCtrlsIDsLossInfo += txtDamage_Loss_of_Sales_Est_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Estimated Cost - Loss of Sales" + ","; Span28.Style["display"] = "inline-block"; break;
                case "Damages Estimated Cost - TOTAL": strCtrlsIDsLossInfo += txtEstCalculated.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Estimated Cost - TOTAL" + ","; Span29.Style["display"] = "inline-block"; break;
                case "Damages Actual Cost - Building and Facilities": strCtrlsIDsLossInfo += txtDamage_Building_Facilities_Actual_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Actual Cost - Building and Facilities" + ","; Span19.Style["display"] = "inline-block"; break;
                case "Damages Actual Cost - Equipment": strCtrlsIDsLossInfo += txtDamage_Equipment_Actual_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Actual Cost - Equipment" + ","; Span20.Style["display"] = "inline-block"; break;
                case "Damages Actual Cost - Product Damage": strCtrlsIDsLossInfo += txtDamage_Product_Damage_Actual_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Actual Cost - Product Damage" + ","; Span21.Style["display"] = "inline-block"; break;
                case "Damages Actual Cost - Parts": strCtrlsIDsLossInfo += txtDamage_Parts_Actual_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Actual Cost - Parts" + ","; Span22.Style["display"] = "inline-block"; break;
                case "Damages Actual Cost - Salvage and Cleanup Expenses (including labor)": strCtrlsIDsLossInfo += txtDamage_Salvage_Cleanup_Actual_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Actual Cost - Salvage and Cleanup Expenses (including labor)" + ","; Span23.Style["display"] = "inline-block"; break;
                case "Damages Actual Cost - Decontamination Expenses": strCtrlsIDsLossInfo += txtDamage_Decontamination_Actual_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Actual Cost - Decontamination Expenses" + ","; Span24.Style["display"] = "inline-block"; break;
                case "Damages Actual Cost - Electronic Data/Processing Media": strCtrlsIDsLossInfo += txtDamage_Electronic_Data_Actual_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Actual Cost - Electronic Data/Processing Media" + ","; Span25.Style["display"] = "inline-block"; break;
                case "Damages Actual Cost - Service Interruption": strCtrlsIDsLossInfo += txtDamage_Service_Interruption_Actual_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Actual Cost - Service Interruption" + ","; Span26.Style["display"] = "inline-block"; break;
                case "Damages Actual Cost - Ordinary Payroll": strCtrlsIDsLossInfo += txtDamage_Payroll_Actual_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Actual Cost - Ordinary Payroll" + ","; Span27.Style["display"] = "inline-block"; break;
                case "Damages Actual Cost - Loss of Sales": strCtrlsIDsLossInfo += txtDamage_Loss_of_Sales_Actual_Cost.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Actual Cost - Loss of Sales" + ","; Span28.Style["display"] = "inline-block"; break;
                case "Damages Actual Cost - TOTAL": strCtrlsIDsLossInfo += txtActualCalculated.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Damages Actual Cost - TOTAL" + ","; Span29.Style["display"] = "inline-block"; break;
                case "Date Clean-up or Salvage Operations Completed": strCtrlsIDsLossInfo += txtDate_Cleanup_Complete.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Date Clean-up or Salvage Operations Completed" + ","; Span30.Style["display"] = "inline-block"; break;
                case "Date Equipment/Biuilding Repairs Completed": strCtrlsIDsLossInfo += txtDate_Repairs_Complete.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Date Equipment/Biuilding Repairs Completed" + ","; Span31.Style["display"] = "inline-block"; break;
                case "Date Full Services Resumed": strCtrlsIDsLossInfo += txtDate_Full_Service_Resumed.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Date Full Services Resumed" + ","; Span32.Style["display"] = "inline-block"; break;
                case "Date Fire Protection Services Resumed": strCtrlsIDsLossInfo += txtDate_Fire_Protection_Services_Resumed.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Date Fire Protection Services Resumed" + ","; Span33.Style["display"] = "inline-block"; break;

            }

            #endregion
        }
        #endregion

        strCtrlsIDsLossInfo = strCtrlsIDsLossInfo.TrimEnd(',');
        strMessagesLossInfo = strMessagesLossInfo.TrimEnd(',');

        hdnControlIDsLossInfo.Value = strCtrlsIDsLossInfo;
        hdnErrorMsgsLossInfo.Value = strMessagesLossInfo;
    }

    /// <summary>
    /// Set all Validations - Loss Information building Affected
    /// </summary>
    private void SetValidationsLossInfoBuilding()
    {
        string strCtrlsIDsLossInfo = "";
        string strMessagesLossInfo = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(23).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk3 = (Label)mnuProperty.Controls[1].FindControl("MenuAsterisk");
        MenuAsterisk3.Style["display"] = (dtFields.Select("LeftMenuIndex = 23").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Building Affected - Occupancy (Departments)": strCtrlsIDsLossInfo += txtB_Occupancy.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Building Affected - Occupancy (Departments)" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Building Affected - Address 1": strCtrlsIDsLossInfo += txtB_Address_1.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Building Affected - Address 1" + ","; Span7.Style["display"] = "inline-block"; break;
                case "Building Affected - Address 2": strCtrlsIDsLossInfo += txtB_Address_2.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Building Affected - Address 2" + ","; Span8.Style["display"] = "inline-block"; break;
                case "Building Affected - City": strCtrlsIDsLossInfo += txtB_City.ClientID + ","; strMessagesLossInfo += "Please select [Loss information]/Building Affected - City" + ","; Span9.Style["display"] = "inline-block"; break;
                case "Building Affected - State": strCtrlsIDsLossInfo += ddlB_State.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Building Affected - State" + ","; Span10.Style["display"] = "inline-block"; break;
                case "Building Affected - Zip Code": strCtrlsIDsLossInfo += txtB_Zip.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Building Affected - Zip Code" + ","; Span11.Style["display"] = "inline-block"; break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDsLossInfo = strCtrlsIDsLossInfo.TrimEnd(',');
        strMessagesLossInfo = strMessagesLossInfo.TrimEnd(',');

        hdnControlIDsLossInfoBuilding.Value = strCtrlsIDsLossInfo;
        hdnErrorMsgsLossInfoBuilding.Value = strMessagesLossInfo;
    }

    /// <summary>
    /// Set all Validations - Loss Information Witness
    /// </summary>
    private void SetValidationsLossInfoWitness()
    {
        string strCtrlsIDsLossInfo = "";
        string strMessagesLossInfo = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(23).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk4 = (Label)mnuProperty.Controls[1].FindControl("MenuAsterisk");
        MenuAsterisk4.Style["display"] = (dtFields.Select("LeftMenuIndex = 23").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Witnesses - Name": strCtrlsIDsLossInfo += txtW_Name.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Witnesses - Name" + ","; Span12.Style["display"] = "inline-block"; break;
                case "Witnesses - Address 1": strCtrlsIDsLossInfo += txtW_Address_1.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Witnesses - Address 1" + ","; Span13.Style["display"] = "inline-block"; break;
                case "Witnesses - Address 2": strCtrlsIDsLossInfo += txtW_Address_2.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Witnesses - Address 2" + ","; Span14.Style["display"] = "inline-block"; break;
                case "Witnesses - City": strCtrlsIDsLossInfo += txtW_City.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Witnesses - City" + ","; Span15.Style["display"] = "inline-block"; break;
                case "Witnesses - State": strCtrlsIDsLossInfo += ddlW_State.ClientID + ","; strMessagesLossInfo += "Please select [Loss information]/Witnesses - State" + ","; Span16.Style["display"] = "inline-block"; break;
                case "Witnesses - Zip Code": strCtrlsIDsLossInfo += txtW_Zip.ClientID + ","; strMessagesLossInfo += "Please enter [Loss information]/Witnesses - Zip Code" + ","; Span17.Style["display"] = "inline-block"; break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDsLossInfo = strCtrlsIDsLossInfo.TrimEnd(',');
        strMessagesLossInfo = strMessagesLossInfo.TrimEnd(',');

        hdnControlIDsLossInfoWitness.Value = strCtrlsIDsLossInfo;
        hdnErrorMsgsLossInfoWitness.Value = strMessagesLossInfo;
    }

    /// <summary>
    /// Set all Validations - Loss Information Witness
    /// </summary>
    private void SetValidationsComments()
    {
        string strCtrlsIDsComments = "";
        string strMessagesComments = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(24).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk5 = (Label)mnuProperty.Controls[2].FindControl("MenuAsterisk");
        MenuAsterisk5.Style["display"] = (dtFields.Select("LeftMenuIndex = 24").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Comments/Instructions": strCtrlsIDsComments += txtComments.ClientID + ","; strMessagesComments += "Please enter [Comments]/Comments/Instructions" + ","; Span34.Style["display"] = "inline-block"; break;
                case "Date Report Completed": strCtrlsIDsComments += txtDateReportComplate.ClientID + ","; strMessagesComments += "Please enter [Comments]/Date Report Completed" + ","; Span35.Style["display"] = "inline-block"; break;
                case "Date Claim Closed": strCtrlsIDsComments += txtClaimClosed.ClientID + ","; strMessagesComments += "Please enter [Comments]/Date Claim Closed" + ","; Span36.Style["display"] = "inline-block"; break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDsComments = strCtrlsIDsComments.TrimEnd(',');
        strMessagesComments = strMessagesComments.TrimEnd(',');

        hdnControlIDsComments.Value = strCtrlsIDsComments;
        hdnErrorMsgsComments.Value = strMessagesComments;
    }

    #endregion
}
