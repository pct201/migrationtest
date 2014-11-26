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
/// Description    : Used to add Primises Liability Information to current First Report Wizard ID.
///                  also display Record is View MOde
/// 
/// </summary>
public partial class SONIC_PLFirstReport : clsBasePage
{
    #region Private variable and Property
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
    public int PK_PL_FR_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PL_FR_ID"]);
        }
        set { ViewState["PK_PL_FR_ID"] = value; }
    }
    #endregion

    #region Page Load Events

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        SonicTab.SetSelectedTab(Controls_SONICtab_SonicTab.Tab.PL);
        //Disable Menus while Page Load - except Location and Loss information Menu because remaining of the Menus are display accroding to user's input.
        pnlPageLoadScript.Visible = true;
        txtCurrentDate1.Text = DateTime.Now.ToShortDateString().ToString();
        //declare Handle of Attachment Control for File Upload
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
            //used to set PK id from Query String
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                try
                {
                    PK_PL_FR_ID = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                    //set Page Mode as per User Access Type if it is View ONly than always open page in
                    //View Mode Only. else if the report is completed  than open page in View MOde Else in Edit MOde
                    if (Module_Access_Mode == AccessType.View_Only)
                    //if (UserAccessType == AccessType.View_Only)
                    {
                        strPageOpeMode = "view";
                    }
                    else
                    {
                        strPageOpeMode = (new PL_FR(PK_PL_FR_ID).Complete == false) ? "edit" : "view";
                    }
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

            int pnlIndex = 1;
            try { pnlIndex = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["pnl"])); }
            catch { }

            if (pnlIndex < 1)
                pnlIndex = 1;
            //used to display Location Panel by calling Show panel Function of javascript
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + pnlIndex + ");", true);
            if (strPageOpeMode == "add")
            {
                SetValidationsLocation();
                SetValidationsLossInfo();
                SetValidationsComments();
                SetValidationsInjury();
                SetValidationsProduct();
                SetValidationsProperty();
                SetValidationsWitness();

                #region Location and Contact Panel
                //fill Sonic Location Number
                ComboHelper.FillSonicLocationNumberOnly(new DropDownList[] { ddlLocationNumber }, 0, true);
                //Fill Location dba Dropdown
                ComboHelper.FillLocationdba(new DropDownList[] { ddlLocationdba }, 0, true);
                //Fill Location Legal Entity Dropdown
                ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, 0, true);
                //Fill Location FKA Dropdown
                ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);
                //Fetch Related Record for Location and EMployee
                BindLocationandContactInfo();
                #endregion

                #region Loss Information Panel
                //Fill State
                ComboHelper.FillState(new DropDownList[] { ddlClaimant_State }, 0, true);
                #endregion

                #region Product Information Panel
                //Fill State
                ComboHelper.FillState(new DropDownList[] { ddlProduct_State }, 0, true);
                #endregion

                #region Injury Information
                //fill State
                ComboHelper.FillState(new DropDownList[] { ddlInjured_State, ddlInjured_Medical_Facility_State }, 0, true);
                //fill Body Part Dropdown
                ComboHelper.FillBodyPartAffected(new DropDownList[] { ddlbody_part }, 0, true);
                #endregion

                #region Property Information
                //fill State
                ComboHelper.FillState(new DropDownList[] { ddlProperty_State }, 0, true);
                #endregion

                #region Witness Information
                //Fill State
                ComboHelper.FillState(new DropDownList[] { ddlWitness_State }, 0, true);
                #endregion

                #region Attchement
                CtrlAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.PL_FR, PK_PL_FR_ID, true, 7);
                CtrlAttachDetails.Bind();
                #endregion
            }
            if (strPageOpeMode == "view")
            {
                //Bind Page in View Mode
                BindPageViewMode();
            }
            if (strPageOpeMode == "edit")
            {
                SetValidationsLocation();
                SetValidationsLossInfo();
                SetValidationsComments();
                SetValidationsInjury();
                SetValidationsProduct();
                SetValidationsProperty();
                SetValidationsWitness();

                #region Location and Contact Panel
                //fill Sonic Location Number
                ComboHelper.FillSonicLocationNumberOnlyForView(new DropDownList[] { ddlLocationNumber }, 0, true);
                //Fill Location dba Dropdown
                ComboHelper.FillLocationdbaOnlyForView(new DropDownList[] { ddlLocationdba }, 0, true);
                //Fill Location Legal Entity Dropdown
                ComboHelper.FillLocationLegal_EntityForView(new DropDownList[] { ddlLegalEntity }, 0, true);
                //Fill Location FKA Dropdown
                ComboHelper.FillLocationfka(new DropDownList[] { ddlLocationfka }, 0, true);
                //Fetch Related Record for Location and EMployee
                BindLocationandContactInfo();
                #endregion

                #region Loss Information Panel
                //Fill State
                ComboHelper.FillState(new DropDownList[] { ddlClaimant_State }, 0, true);
                #endregion

                #region Product Information Panel
                //Fill State
                ComboHelper.FillState(new DropDownList[] { ddlProduct_State }, 0, true);
                #endregion

                #region Injury Information
                //fill State
                ComboHelper.FillState(new DropDownList[] { ddlInjured_State, ddlInjured_Medical_Facility_State }, 0, true);
                //fill Body Part Dropdown
                ComboHelper.FillBodyPartAffected(new DropDownList[] { ddlbody_part }, 0, true);
                #endregion

                #region Property Information
                //fill State
                ComboHelper.FillState(new DropDownList[] { ddlProperty_State }, 0, true);
                #endregion

                #region Witness Information
                //Fill State
                ComboHelper.FillState(new DropDownList[] { ddlWitness_State }, 0, true);
                #endregion

                //Bind Page in Edit Mode
                BindPageEditMode();
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
                    //Complate PL_First Report and Send Email.
                    Int32 intRetVal = ComplatePL_FRReport(false);
                    if (intRetVal == 1)
                    {
                        Response.Redirect("FirstReportStatus.aspx", true);
                    }
                    else if (intRetVal == -1)
                    {
                        //use to open panel.use ShowPanel javascript Function
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('First Report is already submited');ShowPanel(7);", true);
                    }
                    else
                    {
                        //used to display Comment and Attachment Panel useing Showpanel function in Javascript
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The First Report e-mail send without the attachments.');ShowPanel(7);", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('The First Report has NOT been sent, please reduce the number and/or size of the attachments before attempting to resubmit with attachments.');ShowPanel(7);", true);
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

    #region Save and Continue Clicks

    /// <summary>
    /// BUtton CLick Event - To Save Location Info
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLocationSave_Click(object sender, EventArgs e)
    {
        //Update Location Information
        UpdateLocationInformation();
        //used to display Loss information panel useing ShowPanel Function of Javascript
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:FireAll(); ShowPanel(2);", true);
    }

    /// <summary>
    /// BUtton CLick Event - To save Loss Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLossSave_Click(object sender, EventArgs e)
    {
        //Update Loss Informaiton
        UpdateLossInformation();
        //Bind Sonic Header
        setSonicHeaderInfo();
        //this is hidden field that are used to check that the panel is saved or not. because this panel
        //contain Require fields and we must have to save this panel. if it is not done than the value of hidden
        //Control is blank and given a prompt when user click on submit button at comment & attachment Panel
        hdnLoss.Value = "1";
        //used to display Next panel from the Panel list using gScript Function that require a panel number that are open, as paramater
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", gScript(3), true);
    }

    /// <summary>
    /// Button Click Event - To Save Product Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnProductSave_Click(object sender, EventArgs e)
    {
        //Update Product Information
        UpdateProductInformation();
        //used to display Next panel from the Panel list using gScript Function that require a panel number that are open, as paramater
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", gScript(4), true);
    }

    /// <summary>
    /// Button Click Evant - To save Injured Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInjuredSave_Click(object sender, EventArgs e)
    {
        // Update Injured Information
        UpdateInjuredInformation();
        //used to display Next panel from the Panel list using gScript Function that require a panel number that are open, as paramater
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", gScript(5), true);
    }

    /// <summary>
    /// Button Click Event - To Save Property Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPropertySave_Click(object sender, EventArgs e)
    {
        //Update Property Information
        UpdatePropertyInformation();
        //used to display Next panel from the Panel list using gScript Function that require a panel number that are open, as paramater
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", gScript(6), true);
    }

    /// <summary>
    /// Button Click Event - To Save Witness Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnWitnessSave_Click(object sender, EventArgs e)
    {
        //Update Witness Information
        UpdateWitnessInformation();
        //used to display Next panel from the Panel list using gScript Function that require a panel number that are open, as paramater
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", gScript(7), true);
    }

    /// <summary>
    /// BUtton Submit Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Complate PL_First Report and Send Email.
        Int32 intRetVal = ComplatePL_FRReport(true);
        if (intRetVal == 1)
        {
            Response.Redirect("FirstReportStatus.aspx", true);
        }
        else if (intRetVal == -1)
        {
            //use to open panel.use ShowPanel javascript Function
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('First Report is already submited');ShowPanel(7);", true);
        }
        else
        {
            //used to display Comment and Attachment Panel useing Showpanel function in Javascript
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(7);", true);
        }
    }
    #endregion

    #region Location and Contact Panel Events
    /// <summary>
    /// Used to Bind Location Information and Contact Details
    /// </summary>
    public void BindLocationandContactInfo()
    {
        DataSet dsFRW = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.PL_FR, PK_PL_FR_ID);
        DataTable dtFRW = dsFRW.Tables[0];
        foreach (DataRow drFRW in dtFRW.Rows)
        {
            #region Fill Location Information Controls
            //select value from Location Number Dropdown
            if (drFRW["Sonic_Location_Code"] != null)
            {
                ListItem lst = new ListItem();
                lst = ddlLocationNumber.Items.FindByText(drFRW["Sonic_Location_Code"].ToString());
                //used to check if Listitem is not null than value is selected
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
            //select value from Location d/b/a Dropdown
            if (drFRW["dba"] != null)
            {
                ListItem lst = new ListItem();
                lst = ddlLocationdba.Items.FindByText(drFRW["dba"].ToString());
                //used to check if Listitem is not null than value is selected
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
            if (drFRW["legal_entity"] != null)
            {
                ListItem lst = new ListItem();
                lst = ddlLegalEntity.Items.FindByText(drFRW["legal_entity"].ToString().Trim());
                //used to check if Listitem is not null than value is selected
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }

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
            txtCostCenterdba.Text = (drFRW["dba"] != null) ? Convert.ToString(drFRW["dba"]) : "";
            txtCostCenterAddress2.Text = (drFRW["Address_1"] != null) ? Convert.ToString(drFRW["Address_1"]) : "";
            txtCostCenterAddress2.Text = (drFRW["Address_2"] != null) ? Convert.ToString(drFRW["Address_2"]) : "";
            txtCostCenterCity.Text = (drFRW["City"] != null) ? Convert.ToString(drFRW["City"]) : "";
            txtCostCenterZipCode.Text = (drFRW["Zip_Code"] != null) ? Convert.ToString(drFRW["Zip_Code"]) : "";
            txtCostCenterState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state;
            #endregion
            //Set DBA name to Loss Panel
            txtDBA.Text = drFRW["dba"].ToString();

            //used to Disable all COntrols
            DisableEnableControls(false);
        }
    }
    /// <summary>
    /// used to Enable/disable the Locaiton Controls as per passed value
    /// </summary>
    /// <param name="value"></param>
    public void DisableEnableControls(bool value)
    {
        ddlLocationNumber.Enabled = value;
        ddlLocationfka.Enabled = value;
        ddlLocationdba.Enabled = value;
        ddlLegalEntity.Enabled = value;
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
        txtDBA.Enabled = value;
    }

    //Used to Update Location Information
    public void UpdateLocationInformation()
    {
        //Update Fax Number to First_Report_Wizard Table
        First_Report_Wizard objFRW = new First_Report_Wizard(First_Report_Wizard_ID);
        objFRW.Contact_Best_Time = txtContact_Best_Time.Text;
        objFRW.Contact_Fax = txtContactFaxNumber.Text;
        //check PK ID greater than 0 than update First_Report_Wizard Table
        if (First_Report_Wizard_ID > 0)
        {
            objFRW.Update();
        }

        //Update Sonic Reported Date to Property Table
        PL_FR objPL_FR = new PL_FR(PK_PL_FR_ID);
        //if PK PL id greater than 0 than Update record
        if (PK_PL_FR_ID > 0)
        {
            objPL_FR.Update();
        }
    }
    #endregion

    #region Loss Information Panel Events
    /// <summary>
    /// Used to Update Loss Informaiton
    /// </summary>
    public void UpdateLossInformation()
    {
        // Create Object for PL_FR
        PL_FR objPL_FR = new PL_FR(PK_PL_FR_ID);

        // Set values to object
        objPL_FR.Claimant_State = (ddlClaimant_State.SelectedIndex > 0) ? Convert.ToDecimal(ddlClaimant_State.SelectedValue) : 0;
        objPL_FR.Date_of_Loss = clsGeneral.FormatDateToStore(txtDate_Of_Loss);
        objPL_FR.Time_of_Loss = txtTime_Of_Loss.Text;
        objPL_FR.Non_Sonic_Loss_Location = txtNonSonic_Loss_Location.Text;
        objPL_FR.Description_of_Loss = txtDescription_Of_Loss.Text;
        objPL_FR.Date_Reported_To_Sonic = clsGeneral.FormatDateToStore(txtDate_Reported_To_Sonic);
        objPL_FR.Weather_Conditions = txtWeather_Conditions.Text;
        objPL_FR.Road_Conditions = txtRoad_Conditions.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoWere_Police_Notified.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false
            if (rdoWere_Police_Notified.SelectedValue == "Y")
                objPL_FR.Were_Police_Notified = true;
            else
                objPL_FR.Were_Police_Notified = false;
        }
        else
            objPL_FR.Were_Police_Notified = null;

        if (rdoSecurityVideoSystem.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false
            if (rdoSecurityVideoSystem.SelectedValue == "Y")
                objPL_FR.Security_Video_System = true;
            else
                objPL_FR.Security_Video_System = false;
        }
        else
            objPL_FR.Security_Video_System = null;


        //used to check Ploce notificaiton value if "Y" than below fields get the value.
        if (rdoWere_Police_Notified.SelectedValue == "Y")
        {
            hdnPoliceNotify.Value = "1";
            objPL_FR.Police_Organization = txtPolice_Organization.Text;
            objPL_FR.Case_Number = txtCase_Number.Text;
            objPL_FR.Police_telephone = txtPolice_telephone.Text;
        }
        else
        {
            hdnPoliceNotify.Value = "0";
            objPL_FR.Police_Organization = "";
            objPL_FR.Case_Number = "";
            objPL_FR.Police_telephone = "";
        }
        objPL_FR.Loss_Category = txtLoss_Category.Text;
        //use to check selected value if it is "-1" than value set to null.
        if (rdoPersonal_Bodily_Injury.SelectedValue != "-1")
        {
            //use to check selected value if it is "Y" than set true else false and while false than all controls of the panels are set to null and Updated for current ID
            if (rdoPersonal_Bodily_Injury.SelectedValue == "Y")
                objPL_FR.Personal_Bodily_Injury = true;
            else
            {
                objPL_FR.Personal_Bodily_Injury = false;
                // Insert Null Values 
                #region Insert NUll Values in Injured Fields
                //Set value to Object
                objPL_FR.Injured_Name = null;
                objPL_FR.Injured_Gender = null;
                objPL_FR.Injured_Address_1 = null;
                objPL_FR.Injured_Work_Phone = null;
                objPL_FR.Injured_Address_2 = null;
                objPL_FR.Injured_Home_Phone = null;
                objPL_FR.Injured_City = null;
                objPL_FR.Injured_Alternate_Telephone = null;
                objPL_FR.Injured_State = null;
                objPL_FR.Injured_ZipCode = null;
                objPL_FR.What_Was_Injured_Doing = null;
                objPL_FR.Injured_Injury_Description = null;
                objPL_FR.body_part = null;
                objPL_FR.Injured_Medical_Treatment_Provided = null;
                objPL_FR.Injured_Taken_By_Emergency_Transportation = false;
                objPL_FR.Injured_Airlifted_Medivac = null;
                objPL_FR.Injured_Medical_Facility_Name = null;
                objPL_FR.Injured_Date_of_Initial_Treatment = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                objPL_FR.Injured_Medical_Facility_Type = null;
                objPL_FR.Injured_Physicians_Name = null;
                objPL_FR.Injured_Medical_Facility_Address_1 = null;
                objPL_FR.Injured_Admitted_to_Hospital = null;
                objPL_FR.Injured_Medical_Facility_City = null;
                objPL_FR.Injured_Medical_Facility_Address_2 = null;
                objPL_FR.Injured_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                objPL_FR.Injured_Still_in_Hospital = null;
                objPL_FR.Injured_Medical_Facility_State = null;
                objPL_FR.Injured_Medical_Facility_Zip_Code = null;
                //check PK id is greater than 0.if yes than update Info. into PL_FR table
                //if (PK_PL_FR_ID > 0)
                //{
                //    objPL_FR.Update();
                //}
                #endregion
            }
        }
        else
        {
            objPL_FR.Personal_Bodily_Injury = null;
            // Insert Null Values 
            #region Insert NUll Values in Injured Fields
            //Set value to Object
            objPL_FR.Injured_Name = null;
            objPL_FR.Injured_Gender = null;
            objPL_FR.Injured_Address_1 = null;
            objPL_FR.Injured_Work_Phone = null;
            objPL_FR.Injured_Address_2 = null;
            objPL_FR.Injured_Home_Phone = null;
            objPL_FR.Injured_City = null;
            objPL_FR.Injured_Alternate_Telephone = null;
            objPL_FR.Injured_State = null;
            objPL_FR.Injured_ZipCode = null;
            objPL_FR.What_Was_Injured_Doing = null;
            objPL_FR.Injured_Injury_Description = null;
            objPL_FR.body_part = null;
            objPL_FR.Injured_Medical_Treatment_Provided = null;
            objPL_FR.Injured_Taken_By_Emergency_Transportation = false;
            objPL_FR.Injured_Airlifted_Medivac = null;
            objPL_FR.Injured_Medical_Facility_Name = null;
            objPL_FR.Injured_Date_of_Initial_Treatment = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            objPL_FR.Injured_Medical_Facility_Type = null;
            objPL_FR.Injured_Physicians_Name = null;
            objPL_FR.Injured_Medical_Facility_Address_1 = null;
            objPL_FR.Injured_Admitted_to_Hospital = null;
            objPL_FR.Injured_Medical_Facility_City = null;
            objPL_FR.Injured_Medical_Facility_Address_2 = null;
            objPL_FR.Injured_Date_Admitted_to_Hospital = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            objPL_FR.Injured_Still_in_Hospital = null;
            objPL_FR.Injured_Medical_Facility_State = null;
            objPL_FR.Injured_Medical_Facility_Zip_Code = null;
            //check PK id is greater than 0.if yes than update Info. into PL_FR table
            //if (PK_PL_FR_ID > 0)
            //{
            //    objPL_FR.Update();
            //}
            #endregion
        }
        //use to check selected value if it is "Y" than set true else false and while false than all controls of the panels are set to null and Updated for current ID
        if (rdoProperty_Damage.SelectedValue != "-1")
        {
            if (rdoProperty_Damage.SelectedValue == "Y")
                objPL_FR.Property_Damage = true;
            else
            {
                objPL_FR.Property_Damage = false;
                //Insert Null Values
                #region Insert NUll Values in Property Fields
                objPL_FR.Property_Description = null;
                objPL_FR.Property_Damage_Description = null;
                objPL_FR.Estimate_Available = null;
                objPL_FR.Estimate_Amount = 0;
                objPL_FR.Property_Estimator_Name = null;
                objPL_FR.Estimator_Phone = null;
                objPL_FR.Property_Business_Name = null;
                objPL_FR.Property_Address_1 = null;
                objPL_FR.Property_Address_2 = null;
                objPL_FR.Property_City = null;
                objPL_FR.Property_State = null;
                objPL_FR.Property_Zip_Code = null;
                objPL_FR.Location_where_property_can_be_seen = null;
                objPL_FR.Owner_Name = null;
                objPL_FR.Owner_Work_Telephone = null;
                objPL_FR.Owner_Home_Telephone = null;
                objPL_FR.Owner_Alternate_Telephone = null;
                //check PK id is greater than 0.if yes than update Info. into PL_FR table
                //if (PK_PL_FR_ID > 0)
                //{
                //    objPL_FR.Update();
                //}
                #endregion
            }
        }
        else
        {
            objPL_FR.Property_Damage = null;
            //Insert Null Values
            #region Insert NUll Values in Property Fields
            objPL_FR.Property_Description = null;
            objPL_FR.Property_Damage_Description = null;
            objPL_FR.Estimate_Available = null;
            objPL_FR.Estimate_Amount = 0;
            objPL_FR.Property_Estimator_Name = null;
            objPL_FR.Estimator_Phone = null;
            objPL_FR.Property_Business_Name = null;
            objPL_FR.Property_Address_1 = null;
            objPL_FR.Property_Address_2 = null;
            objPL_FR.Property_City = null;
            objPL_FR.Property_State = null;
            objPL_FR.Property_Zip_Code = null;
            objPL_FR.Location_where_property_can_be_seen = null;
            objPL_FR.Owner_Name = null;
            objPL_FR.Owner_Work_Telephone = null;
            objPL_FR.Owner_Home_Telephone = null;
            objPL_FR.Owner_Alternate_Telephone = null;
            //check PK id is greater than 0.if yes than update Info. into PL_FR table
            //if (PK_PL_FR_ID > 0)
            //{
            //    objPL_FR.Update();
            //}
            #endregion
        }
        //use to check selected value if it is "Y" than set true else false and while false than all controls of the panels are set to null and Updated for current ID
        if (rdoWitnesses.SelectedValue != "-1")
        {
            if (rdoWitnesses.SelectedValue == "Y")
                objPL_FR.Witnesses = true;
            else
            {
                objPL_FR.Witnesses = false;
                //Insert Null Values
                #region Insert Null Values to Witness Fields
                objPL_FR.Witness_Name = null;
                objPL_FR.Witness_Home_Telephone = null;
                objPL_FR.Witness_Work_Telephone = null;
                objPL_FR.Witness_Alternate_Telephone = null;
                objPL_FR.Witness_Address_1 = null;
                objPL_FR.Witness_Address_2 = null;
                objPL_FR.Witness_City = null;
                objPL_FR.Witness_State = null;
                objPL_FR.Witness_Zip_Code = null;
                //check PK id is greater than 0.if yes than update Info. into PL_FR table
                //if (PK_PL_FR_ID > 0)
                //{
                //    objPL_FR.Update();
                //}
                #endregion
            }
        }
        else
        {
            objPL_FR.Witnesses = null;
            //Insert Null Values
            #region Insert Null Values to Witness Fields
            objPL_FR.Witness_Name = null;
            objPL_FR.Witness_Home_Telephone = null;
            objPL_FR.Witness_Work_Telephone = null;
            objPL_FR.Witness_Alternate_Telephone = null;
            objPL_FR.Witness_Address_1 = null;
            objPL_FR.Witness_Address_2 = null;
            objPL_FR.Witness_City = null;
            objPL_FR.Witness_State = null;
            objPL_FR.Witness_Zip_Code = null;
            //check PK id is greater than 0.if yes than update Info. into PL_FR table
            //if (PK_PL_FR_ID > 0)
            //{
            //    objPL_FR.Update();
            //}
            #endregion
        }
        //use to check selected value if it is "Y" than set true else false and while false than all controls of the panels are set to null and Updated for current ID
        if (rdoProduct_Involved.SelectedValue != "-1")
        {
            if (rdoProduct_Involved.SelectedValue == "Y")
                objPL_FR.Product_Involved = true;
            else
            {
                objPL_FR.Product_Involved = false;
                //Insert Nulll Values
                #region Insert Null Values to Product Fields
                objPL_FR.Type_of_Product = null;
                objPL_FR.Manufacturer_Name = null;
                objPL_FR.Product_Address_1 = null;
                objPL_FR.Product_Address_2 = null;
                objPL_FR.Product_City = null;
                objPL_FR.Product_State = null;
                objPL_FR.Product_Zip_Code = null;
                objPL_FR.Product_Location = null;
                //check PK id is greater than 0.if yes than update Info. into PL_FR table
                //if (PK_PL_FR_ID > 0)
                //{
                //    objPL_FR.Update();
                //}
                #endregion
            }
        }
        else
        {
            objPL_FR.Product_Involved = null;
            //Insert Nulll Values
            #region Insert Null Values to Product Fields
            objPL_FR.Type_of_Product = null;
            objPL_FR.Manufacturer_Name = null;
            objPL_FR.Product_Address_1 = null;
            objPL_FR.Product_Address_2 = null;
            objPL_FR.Product_City = null;
            objPL_FR.Product_State = null;
            objPL_FR.Product_Zip_Code = null;
            objPL_FR.Product_Location = null;
            //check PK id is greater than 0.if yes than update Info. into PL_FR table
            //if (PK_PL_FR_ID > 0)
            //{
            //    objPL_FR.Update();
            //}
            #endregion
        }
        //check PK id is greater than 0.if yes than update Info. into PL_FR table
        if (PK_PL_FR_ID > 0)
        {
            objPL_FR.Update();
        }
    }

    /// <summary>
    /// Gridview Involvenet Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvInvolvement_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            decimal _PK_FR_PL_Involvement = Convert.ToDecimal(e.CommandArgument);
            Response.Redirect("IncidentInvolvement.aspx?id=" + Encryption.Encrypt(_PK_FR_PL_Involvement.ToString()) + "&mode=edit", true);
        }
        else if (e.CommandName == "RemoveRecord")
        {
            decimal _PK_FR_PL_Involvement = Convert.ToDecimal(e.CommandArgument);
            clsFR_PL_Involvement.DeleteByPK(_PK_FR_PL_Involvement);
            gvInvolvement.DataSource = clsFR_PL_Involvement.SelectByFK(PK_PL_FR_ID);
            gvInvolvement.DataBind();
        }
        else if (e.CommandName == "ViewRecord")
        {
            decimal _PK_FR_PL_Involvement = Convert.ToDecimal(e.CommandArgument);
            Response.Redirect("IncidentInvolvement.aspx?id=" + Encryption.Encrypt(_PK_FR_PL_Involvement.ToString()) + "&mode=view", true);
        }
    }

    /// <summary>
    /// Link button Add Incident Involvement Grid Record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddInvolvements_Click(object sender, EventArgs e)
    {
        //Update Loss Informaiton
        UpdateLossInformation();

        Response.Redirect("IncidentInvolvement.aspx?prid=" + Encryption.Encrypt(PK_PL_FR_ID.ToString()), true);
    }

    #endregion

    #region Product Panel Events
    /// <summary>
    /// Update Product Information
    /// </summary>
    public void UpdateProductInformation()
    {
        // Create Object
        PL_FR objPL_FR = new PL_FR(PK_PL_FR_ID);

        //Set Values to Object
        objPL_FR.Product_Involved = true;
        objPL_FR.Type_of_Product = txtType_of_Product.Text;
        objPL_FR.Manufacturer_Name = txtManufacturer_Name.Text;
        objPL_FR.Product_Address_1 = txtProduct_Address_1.Text;
        objPL_FR.Product_Address_2 = txtProduct_Address_2.Text;
        objPL_FR.Product_City = txtProduct_City.Text;
        objPL_FR.Product_State = (ddlProduct_State.SelectedIndex > 0) ? ddlProduct_State.SelectedValue.ToString() : "0";
        objPL_FR.Product_Zip_Code = txtProduct_Zip_Code.Text;
        objPL_FR.Product_Location = txtProduct_Location.Text;
        //check PK id is greater than 0.if yes than update Info. into PL_FR table
        if (PK_PL_FR_ID > 0)
        {
            objPL_FR.Update();
        }
    }
    #endregion

    #region Injured Information
    /// <summary>
    /// Use to update Injured Information
    /// </summary>
    public void UpdateInjuredInformation()
    {
        // Create object
        PL_FR objPL_FR = new PL_FR(PK_PL_FR_ID);

        //Set value to Object
        objPL_FR.Personal_Bodily_Injury = true;
        objPL_FR.Injured_Name = txtInjured_Name.Text;
        objPL_FR.Injured_Gender = txtInjured_Gender.Text;
        objPL_FR.Injured_Address_1 = txtInjured_Address_1.Text;
        objPL_FR.Injured_Work_Phone = txtInjured_Work_Phone.Text;
        objPL_FR.Injured_Address_2 = txtInjured_Address_2.Text;
        objPL_FR.Injured_Home_Phone = txtInjured_Home_Phone.Text;
        objPL_FR.Injured_City = txtInjured_City.Text;
        objPL_FR.Injured_Alternate_Telephone = txtInjured_Alternate_Telephone.Text;
        objPL_FR.Injured_State = (ddlInjured_State.SelectedIndex > 0) ? ddlInjured_State.SelectedValue.ToString() : "0";
        objPL_FR.Injured_ZipCode = txtInjured_Zip_Code.Text;
        objPL_FR.What_Was_Injured_Doing = txtWhat_Was_Injured_Doing.Text;
        objPL_FR.Injured_Injury_Description = txtInjured_Injury_Description.Text;
        objPL_FR.body_part = (ddlbody_part.SelectedIndex > 0) ? ddlbody_part.SelectedValue.ToString() : "0";
        objPL_FR.Injured_Medical_Treatment_Provided = txtInjured_Medical_Treatment_Provided.Text;
        objPL_FR.Injured_Taken_By_Emergency_Transportation = (rdoInjured_Taken_By_Emergency_Transportation.SelectedValue == "Y") ? true : false;
        //use to check radio button selected value if it is "-1" than set null value
        if (rdoInjured_Airlifted_Medivac.SelectedValue != "-1")
        {
            //use to check radio button selected value if it is "Y" than set true else set false.
            if (rdoInjured_Airlifted_Medivac.SelectedValue == "Y")
                objPL_FR.Injured_Airlifted_Medivac = true;
            else
                objPL_FR.Injured_Airlifted_Medivac = false;
        }
        else
            objPL_FR.Injured_Airlifted_Medivac = null;
        objPL_FR.Injured_Medical_Facility_Name = txtInjured_Medical_Facility_Name.Text;
        objPL_FR.Injured_Date_of_Initial_Treatment = clsGeneral.FormatDateToStore(txtInjured_Date_of_Initial_Treatment);
        objPL_FR.Injured_Medical_Facility_Type = txtInjured_Medical_Facility_Type.Text;
        objPL_FR.Injured_Physicians_Name = txtInjured_Physicians_Name.Text;
        objPL_FR.Injured_Medical_Facility_Address_1 = txtInjured_Medical_Facility_Address_1.Text;
        //use to check radio button selected value if it is "-1" than set null value
        if (rdoInjured_Admitted_to_Hospital.SelectedValue != "-1")
        {
            //use to check radio button selected value if it is "Y" than set true else set false.
            if (rdoInjured_Admitted_to_Hospital.SelectedValue == "Y")
                objPL_FR.Injured_Admitted_to_Hospital = true;
            else
                objPL_FR.Injured_Admitted_to_Hospital = false;
        }
        else
            objPL_FR.Injured_Admitted_to_Hospital = null;
        objPL_FR.Injured_Medical_Facility_City = txtInjured_Medical_Facility_City.Text;
        objPL_FR.Injured_Medical_Facility_Address_2 = txtInjured_Medical_Facility_Address_2.Text;
        //use to check radio button selected value if it is "Y" than set below fields else fields remains hidden and set to null
        if (rdoInjured_Admitted_to_Hospital.SelectedValue == "Y")
        {
            objPL_FR.Injured_Date_Admitted_to_Hospital = clsGeneral.FormatDateToStore(txtInjured_Date_Admitted_to_Hospital);
            //use to check radio button selected value if it is "-1" than set null value
            if (rdoInjured_Still_in_Hospital.SelectedValue != "-1")
            {
                //use to check radio button selected value if it is "Y" than set true else set false.
                if (rdoInjured_Still_in_Hospital.SelectedValue == "Y")
                    objPL_FR.Injured_Still_in_Hospital = true;
                else
                    objPL_FR.Injured_Still_in_Hospital = false;
            }
        }
        else
            objPL_FR.Injured_Still_in_Hospital = null;
        objPL_FR.Injured_Medical_Facility_State = (ddlInjured_Medical_Facility_State.SelectedIndex > 0) ? ddlInjured_Medical_Facility_State.SelectedValue.ToString() : "0";
        objPL_FR.Injured_Medical_Facility_Zip_Code = txtInjured_Medical_Facility_Zip_Code.Text;
        //check PK id is greater than 0.if yes than update Info. into PL_FR table
        if (PK_PL_FR_ID > 0)
        {
            objPL_FR.Update();
        }
    }
    #endregion

    #region Property Information Panel

    /// <summary>
    /// Method - To Update Property Info
    /// </summary>
    public void UpdatePropertyInformation()
    {
        //Create new Object
        PL_FR objPL_FR = new PL_FR(PK_PL_FR_ID);

        //set values to Object
        objPL_FR.Property_Damage = true;
        objPL_FR.Property_Description = txtProperty_Description.Text;
        objPL_FR.Property_Damage_Description = txtProperty_Damage_Description.Text;
        //use to check radio button selected value if it is "-1" than set null value
        if (rdoEstimate_Available.SelectedValue != "-1")
        {
            //use to check radio button selected value if it is "Y" than set true else set false.
            if (rdoEstimate_Available.SelectedValue == "Y")
                objPL_FR.Estimate_Available = true;
            else
                objPL_FR.Estimate_Available = false;
        }
        else
            objPL_FR.Estimate_Available = null;
        objPL_FR.Estimate_Amount = string.IsNullOrEmpty(txtEstimate_Amount.Text) ? 0 : Convert.ToDecimal(txtEstimate_Amount.Text);
        objPL_FR.Property_Estimator_Name = txtProperty_Estimator_Name.Text;
        objPL_FR.Estimator_Phone = txtEstimator_Phone.Text;
        objPL_FR.Property_Business_Name = txtProperty_Business_Name.Text;
        objPL_FR.Property_Address_1 = txtProperty_Address_1.Text;
        objPL_FR.Property_Address_2 = txtProperty_Address_2.Text;
        objPL_FR.Property_City = txtProperty_City.Text;
        objPL_FR.Property_State = (ddlProperty_State.SelectedIndex > 0) ? ddlProperty_State.SelectedValue.ToString() : "0";
        objPL_FR.Property_Zip_Code = txtProperty_Zip_Code.Text;
        objPL_FR.Location_where_property_can_be_seen = txtLocation_where_property_can_be_seen.Text;
        objPL_FR.Owner_Name = txtOwner_Name.Text;
        objPL_FR.Owner_Work_Telephone = txtOwner_Work_Telephone.Text;
        objPL_FR.Owner_Home_Telephone = txtOwner_Home_Telephone.Text;
        objPL_FR.Owner_Alternate_Telephone = txtOwner_Alternate_Telephone.Text;
        //check PK id is greater than 0.if yes than update Info. into PL_FR table
        if (PK_PL_FR_ID > 0)
        {
            objPL_FR.Update();
        }
    }
    #endregion

    #region Witness Information Panel

    /// <summary>
    /// Method - to update Witness Info
    /// </summary>
    public void UpdateWitnessInformation()
    {
        //Create Objects
        PL_FR objPL_FR = new PL_FR(PK_PL_FR_ID);

        //set Values to objects
        objPL_FR.Witnesses = true;
        objPL_FR.Witness_Name = txtWitness_Name.Text;
        objPL_FR.Witness_Home_Telephone = txtWitness_Home_Phone.Text;
        objPL_FR.Witness_Work_Telephone = txtWitness_Work_Phone.Text;
        objPL_FR.Witness_Alternate_Telephone = txtWitness_Alternate_Phone.Text;
        objPL_FR.Witness_Address_1 = txtWitness_Address_1.Text;
        objPL_FR.Witness_Address_2 = txtWitness_Address_2.Text;
        objPL_FR.Witness_City = txtWitness_City.Text;
        objPL_FR.Witness_State = (ddlWitness_State.SelectedIndex > 0) ? ddlWitness_State.SelectedValue.ToString() : "0";
        objPL_FR.Witness_Zip_Code = txtWitness_Zip_Code.Text;
        //check PK id is greater than 0.if yes than update Info. into PL_FR table
        if (PK_PL_FR_ID > 0)
        {
            objPL_FR.Update();
        }
    }

    #endregion

    #region Submit Button related Methods

    /// <summary>
    /// Used to Update PL_FR table and Send a Email
    /// </summary>
    /// <returns></returns>
    public int ComplatePL_FRReport(bool _IsAttachment)
    {
        //if opertaion is add add new record into table
        if (strPageOpeMode == "edit")
        {
            if (hdnLoss.Value == "1")
            {
                if (_IsAttachment)
                {
                    CtrlAttachment.Add(clsGeneral.Tables.PL_FR, PK_PL_FR_ID);
                    CtrlAttachDetails.Bind();
                    decimal FileSize = this.CtrlAttachDetails.GetTotalAttachmentsFileSize();
                    if (FileSize > 9.5M)
                    {
                        String confirmMessage = "The attachments to this First Report exceed the size limitations for e-mail. The First Report can be sent without the attachments or you can Cancel and remove or reduce the size of the exiting attachments. Do you want to send the First Report without the attachments?";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", " if(window.confirm('" + confirmMessage + "')){ __doPostBack('UserConfirmationPostBack','true');} else {alert('The First Report has NOT been sent, please reduce the number and/or size of the attachments before attempting to resubmit with attachments.');ShowPanel(7);}", true);
                        return 0;
                    }
                }

                // Declare Object
                PL_FR objPL_FR = new PL_FR(PK_PL_FR_ID);

                if (objPL_FR.Complete)
                    return -1;

                //Assign Values
                objPL_FR.Comments = txtComments.Text;

                objPL_FR.Complete = true;
                //Update Values
                if (PK_PL_FR_ID > 0)
                {
                    objPL_FR.Update();
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

    #region Bind Page in View Mode

    /// <summary>
    /// Method - To bind page controls in View mode
    /// </summary>
    public void BindPageViewMode()
    {
        if (First_Report_Wizard_ID > 0)
        {
            //Hide Message of "This Report Has not been submitted"
            lblSubmitMessage.Text = "";
            //Declare Object of WC_FR table
            PL_FR objPL_FR = new PL_FR(PK_PL_FR_ID);

            #region Location/Contact Information
            DataSet dsFRW = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.PL_FR, PK_PL_FR_ID);
            DataTable dtFRW = dsFRW.Tables[0];
            if (dtFRW.Rows.Count > 0)
            {
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
                if (drFRW["legal_entity"] != null)
                    lblLegalEntity.Text = drFRW["legal_entity"].ToString();
                else
                    lblLegalEntity.Text = "";

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
                lblCostCenterdba.Text = (drFRW["dba"] != null) ? Convert.ToString(drFRW["dba"]) : "";
                lblCostCenterAddress1.Text = (drFRW["Address_1"] != null) ? Convert.ToString(drFRW["Address_1"]) : "";
                lblCostCenterAddress2.Text = (drFRW["Address_2"] != null) ? Convert.ToString(drFRW["Address_2"]) : "";
                lblCostCenterCity.Text = (drFRW["City"] != null) ? Convert.ToString(drFRW["City"]) : "";
                lblCostCenterZipCode.Text = (drFRW["Zip_Code"] != null) ? Convert.ToString(drFRW["Zip_Code"]) : "";
                lblCostCenterState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state;
                #endregion
                lblDBA.Text = drFRW["dba"].ToString();
            }
            #endregion

            #region Loss Information
            //Set values to object
            lblClaimant_State.Text = new State(Convert.ToDecimal(objPL_FR.Claimant_State)).FLD_state;
            lblDate_Of_Loss.Text = clsGeneral.FormatDateToDisplay(objPL_FR.Date_of_Loss);
            lblTime_Of_Loss.Text = objPL_FR.Time_of_Loss;
            lblNonSonic_Loss_Location.Text = objPL_FR.Non_Sonic_Loss_Location;
            lblDescription_Of_Loss.Text = objPL_FR.Description_of_Loss;
            lblDate_Reported_To_Sonic.Text = clsGeneral.FormatDateToDisplay(objPL_FR.Date_Reported_To_Sonic);
            lblWeather_Conditions.Text = objPL_FR.Weather_Conditions;
            lblRoad_Conditions.Text = objPL_FR.Road_Conditions;
            //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
            if (objPL_FR.Were_Police_Notified != null)
            {
                if (objPL_FR.Were_Police_Notified == true)
                    lblWere_Police_Notified.Text = "Yes";
                else
                    lblWere_Police_Notified.Text = "No";
            }
            else
                lblWere_Police_Notified.Text = "unknown";
            //check object value if it is true than below fields are display else fields are remain hidden with null value
            if (objPL_FR.Were_Police_Notified == true)
            {
                trViewLossPoliceNotified.Style.Add("display", "");
                lblPolice_Organization.Text = objPL_FR.Police_Organization;
                lblCase_Number.Text = objPL_FR.Case_Number;
                lblPolice_telephone.Text = objPL_FR.Police_telephone;
            }
            lblLoss_Category.Text = objPL_FR.Loss_Category;
            //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
            if (objPL_FR.Personal_Bodily_Injury != null)
            {
                if (objPL_FR.Personal_Bodily_Injury == true)
                    lblPersonal_Bodily_Injury.Text = "Yes";
                else
                    lblPersonal_Bodily_Injury.Text = "No";
            }
            else
                lblPersonal_Bodily_Injury.Text = "unknown";
            //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
            if (objPL_FR.Property_Damage != null)
            {
                if (objPL_FR.Property_Damage == true)
                    lblProperty_Damage.Text = "Yes";
                else
                    lblProperty_Damage.Text = "No";
            }
            else
                lblProperty_Damage.Text = "unknown";
            //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
            if (objPL_FR.Witnesses != null)
            {
                if (objPL_FR.Witnesses == true)
                    lblWitnesses.Text = "Yes";
                else
                    lblWitnesses.Text = "No";
            }
            else
                lblWitnesses.Text = "unknown";
            //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
            if (objPL_FR.Product_Involved != null)
            {
                if (objPL_FR.Product_Involved == true)
                    lblProduct_Involved.Text = "Yes";
                else
                    lblProduct_Involved.Text = "No";
            }
            else
                lblProduct_Involved.Text = "unknown";

            if (objPL_FR.Security_Video_System != null)
            {
                if (objPL_FR.Security_Video_System == true)
                    lblSecurityVideoSystem.Text = "Yes";
                else
                    lblSecurityVideoSystem.Text = "No";
            }
            else
                lblSecurityVideoSystem.Text = "unknown";

            //chck value if it is true than diaply Injured Panel and with values.
            if (objPL_FR.Personal_Bodily_Injury == true)
            {
                pnlDisplayInjuryTab.Visible = true;
                //Bind Injury Panel
                lblInjured_Name.Text = objPL_FR.Injured_Name;
                lblInjured_Gender.Text = objPL_FR.Injured_Gender;
                lblInjured_Address_1.Text = objPL_FR.Injured_Address_1;
                lblInjured_Work_Phone.Text = objPL_FR.Injured_Work_Phone;
                lblInjured_Address_2.Text = objPL_FR.Injured_Address_2;
                lblInjured_Home_Phone.Text = objPL_FR.Injured_Home_Phone;
                lblInjured_City.Text = objPL_FR.Injured_City;
                lblInjured_Alternate_Telephone.Text = objPL_FR.Injured_Alternate_Telephone;
                lblInjured_State.Text = new State(string.IsNullOrEmpty(objPL_FR.Injured_State) ? 0 : Convert.ToDecimal(objPL_FR.Injured_State)).FLD_state;
                lblInjured_Zip_Code.Text = objPL_FR.Injured_ZipCode;
                lblWhat_Was_Injured_Doing.Text = objPL_FR.What_Was_Injured_Doing;
                lblInjured_Injury_Description.Text = objPL_FR.Injured_Injury_Description;
                lblbody_part.Text = new LU_Part_Of_Body(string.IsNullOrEmpty(objPL_FR.body_part) ? 0 : Convert.ToDecimal(objPL_FR.body_part)).Description;
                lblInjured_Medical_Treatment_Provided.Text = objPL_FR.Injured_Medical_Treatment_Provided;
                lblInjured_Taken_By_Emergency_Transportation.Text = (objPL_FR.Injured_Taken_By_Emergency_Transportation == true) ? "Yes" : "No";
                //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
                if (objPL_FR.Injured_Airlifted_Medivac != null)
                {
                    if (objPL_FR.Injured_Airlifted_Medivac == true)
                        lblInjured_Airlifted_Medivac.Text = "Yes";
                    else
                        lblInjured_Airlifted_Medivac.Text = "No";
                }
                else
                    lblInjured_Airlifted_Medivac.Text = "unknown";


                lblInjured_Medical_Facility_Name.Text = objPL_FR.Injured_Medical_Facility_Name;
                lblInjured_Date_of_Initial_Treatment.Text = clsGeneral.FormatDateToDisplay(objPL_FR.Injured_Date_of_Initial_Treatment);

                lblInjured_Medical_Facility_Type.Text = objPL_FR.Injured_Medical_Facility_Type;
                lblInjured_Physicians_Name.Text = objPL_FR.Injured_Physicians_Name;
                lblInjured_Medical_Facility_Address_1.Text = objPL_FR.Injured_Medical_Facility_Address_1;
                //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
                if (objPL_FR.Injured_Admitted_to_Hospital != null)
                {
                    if (objPL_FR.Injured_Admitted_to_Hospital == true)
                        lblInjured_Admitted_to_Hospital.Text = "Yes";
                    else
                        lblInjured_Admitted_to_Hospital.Text = "No";
                }
                else
                    lblInjured_Admitted_to_Hospital.Text = "unknown";

                lblInjured_Medical_Facility_City.Text = objPL_FR.Injured_Medical_Facility_City;
                lblInjured_Medical_Facility_Address_2.Text = objPL_FR.Injured_Medical_Facility_Address_2;
                //used to check if te value set to true below fields are displayed and populate with related value
                //else below fileds are remain hidden.
                if (objPL_FR.Injured_Admitted_to_Hospital == true)
                {
                    tdViewInjury_DateAdmitted.Style.Add("display", "");
                    tdViewInjury_StillHospital.Style.Add("display", "");
                    lblInjured_Date_Admitted_to_Hospital.Text = clsGeneral.FormatDateToDisplay(objPL_FR.Injured_Date_Admitted_to_Hospital);
                    //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
                    if (objPL_FR.Injured_Still_in_Hospital != null)
                    {
                        if (objPL_FR.Injured_Still_in_Hospital == true)
                            lblInjured_Still_in_Hospital.Text = "Yes";
                        else
                            lblInjured_Still_in_Hospital.Text = "No";
                    }
                    else
                        lblInjured_Still_in_Hospital.Text = "unknown";
                }

                lblInjured_Medical_Facility_State.Text = new State(string.IsNullOrEmpty(objPL_FR.Injured_Medical_Facility_State) ? 0 : Convert.ToDecimal(objPL_FR.Injured_Medical_Facility_State)).FLD_state;
                lblInjured_Medical_Facility_Zip_Code.Text = objPL_FR.Injured_Medical_Facility_Zip_Code;
            }
            //used to check value if it is true than display Property Panel with all data populated to controls
            if (objPL_FR.Property_Damage == true)
            {
                pnlDisplayPropertyTab.Visible = true;
                //Bind Property Panel
                lblProperty_Description.Text = objPL_FR.Property_Description;
                lblProperty_Damage_Description.Text = objPL_FR.Property_Damage_Description;
                //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
                if (objPL_FR.Estimate_Available != null)
                {
                    if (objPL_FR.Estimate_Available == true)
                        lblEstimate_Available.Text = "Yes";
                    else
                        lblEstimate_Available.Text = "No";
                }
                else
                    lblEstimate_Available.Text = "unknown";
                lblEstimate_Amount.Text = "$ " + clsGeneral.GetStringValue(objPL_FR.Estimate_Amount);
                lblProperty_Estimator_Name.Text = objPL_FR.Property_Estimator_Name;
                lblEstimator_Phone.Text = objPL_FR.Estimator_Phone;
                lblProperty_Business_Name.Text = objPL_FR.Property_Business_Name;
                lblProperty_Address_1.Text = objPL_FR.Property_Address_1;
                lblProperty_Address_2.Text = objPL_FR.Property_Address_2;
                lblProperty_City.Text = objPL_FR.Property_City;
                lblProperty_State.Text = new State(string.IsNullOrEmpty(objPL_FR.Property_State) ? 0 : Convert.ToDecimal(objPL_FR.Property_State)).FLD_state;
                lblProperty_Zip_Code.Text = objPL_FR.Property_Zip_Code;
                lblLocation_where_property_can_be_seen.Text = objPL_FR.Location_where_property_can_be_seen;
                lblOwner_Name.Text = objPL_FR.Owner_Name;
                lblOwner_Work_Telephone.Text = objPL_FR.Owner_Work_Telephone;
                lblOwner_Home_Telephone.Text = objPL_FR.Owner_Home_Telephone;
                lblOwner_Alternate_Telephone.Text = objPL_FR.Owner_Alternate_Telephone;
            }
            //used to check value if it is true than display Witness Panel with all data populated to controls
            if (objPL_FR.Witnesses == true)
            {
                pnlDisplayWitnessesTab.Visible = true;
                //Bind Witness Panel
                lblWitness_Name.Text = objPL_FR.Witness_Name;
                lblWitness_Home_Phone.Text = objPL_FR.Witness_Home_Telephone;
                lblWitness_Work_Phone.Text = objPL_FR.Witness_Work_Telephone;
                lblWitness_Alternate_Phone.Text = objPL_FR.Witness_Alternate_Telephone;
                lblWitness_Address_1.Text = objPL_FR.Witness_Address_1;
                lblWitness_Address_2.Text = objPL_FR.Witness_Address_2;
                lblWitness_City.Text = objPL_FR.Witness_City;
                lblWitness_State.Text = new State(string.IsNullOrEmpty(objPL_FR.Witness_State) ? 0 : Convert.ToDecimal(objPL_FR.Witness_State)).FLD_state;
                lblWitness_Zip_Code.Text = objPL_FR.Witness_Zip_Code;
            }
            //used to check value if it is true than display Product Panel with all data populated to controls
            if (objPL_FR.Product_Involved == true)
            {
                pnlDisplayProductTab.Visible = true;
                //Bind Product Involved Panel
                lblType_of_Product.Text = objPL_FR.Type_of_Product;
                lblManufacturer_Name.Text = objPL_FR.Manufacturer_Name;
                lblProduct_Address_1.Text = objPL_FR.Product_Address_1;
                lblProduct_Address_2.Text = objPL_FR.Product_Address_2;
                lblProduct_City.Text = objPL_FR.Product_City;
                lblProduct_State.Text = new State(String.IsNullOrEmpty(objPL_FR.Product_State) ? 0 : Convert.ToDecimal(objPL_FR.Product_State)).FLD_state;
                lblProduct_Zip_Code.Text = objPL_FR.Product_Zip_Code;
                lblProduct_Location.Text = objPL_FR.Product_Location;
            }
            #endregion

            #region "Involvement grid"

            gvInvolvementView.DataSource = clsFR_PL_Involvement.SelectByFK(PK_PL_FR_ID);
            gvInvolvementView.DataBind();

            #endregion

            #region Comments and Attachments
            lblComments.Text = objPL_FR.Comments;
            CtrlViewAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.PL_FR, PK_PL_FR_ID, false, 7);
            CtrlViewAttachDetails.Bind();
            #endregion
        }
        else
        {
            Response.Redirect("FirstReportSearch.aspx", true);
        }
    }
    #endregion

    #region Bind Page in Edit MOde

    /// <summary>
    /// Method - To Bind Page in Edit Mode
    /// </summary>
    public void BindPageEditMode()
    {
        if (First_Report_Wizard_ID > 0)
        {
            //Declare Object of WC_FR table
            PL_FR objPL_FR = new PL_FR(PK_PL_FR_ID);
            //used to check report is complete or not. if not than Message is display else not display
            if (objPL_FR.Complete == false)
            {
                //Hide Message of "This Report Has not been submitted"
                lblSubmitMessage.Text = "This Report has not been submitted";
            }
            else
            {
                lblSubmitMessage.Text = "";
            }

            #region Location/Contact Information
            DataSet dsFRW = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.PL_FR, PK_PL_FR_ID);
            DataTable dtFRW = dsFRW.Tables[0];
            if (dtFRW.Rows.Count > 0)
            {
                DataRow drFRW = dtFRW.Rows[0];

                #region Fill Location Information Controls
                //select value from Location Number Dropdown
                if (drFRW["Sonic_Location_Code"] != null)
                {
                    ListItem lstLnumber = new ListItem();
                    lstLnumber = ddlLocationNumber.Items.FindByText(drFRW["Sonic_Location_Code"].ToString());
                    //used to check if Listitem is not null than value is selected
                    if (lstLnumber != null)
                        lstLnumber.Selected = true;
                }

                //select value from Location d/b/a Dropdown
                if (drFRW["dba1"] != null)
                {
                    ListItem lstdba = new ListItem();
                    lstdba = ddlLocationdba.Items.FindByText(drFRW["dba1"].ToString());
                    //used to check if Listitem is not null than value is selected
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
                if (drFRW["legal_entity"] != null)
                {
                    ListItem lstLE = new ListItem();
                    lstLE = ddlLegalEntity.Items.FindByText(drFRW["legal_entity"].ToString());
                    //used to check if Listitem is not null than value is selected
                    if (lstLE != null)
                    {
                        lstLE.Selected = true;
                    }
                }

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
                txtCostCenterdba.Text = (drFRW["dba1"] != null) ? Convert.ToString(drFRW["dba1"]) : "";
                txtCostCenterAddress1.Text = (drFRW["Address_1"] != null) ? Convert.ToString(drFRW["Address_1"]) : "";
                txtCostCenterAddress2.Text = (drFRW["Address_2"] != null) ? Convert.ToString(drFRW["Address_2"]) : "";
                txtCostCenterCity.Text = (drFRW["City"] != null) ? Convert.ToString(drFRW["City"]) : "";
                txtCostCenterZipCode.Text = (drFRW["Zip_Code"] != null) ? Convert.ToString(drFRW["Zip_Code"]) : "";
                txtCostCenterState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state;
                #endregion

                //used to Disable all COntrols
                DisableEnableControls(false);
            }
            #endregion

            #region Loss Information
            //Set values to object
            ListItem lstCS = new ListItem();
            lstCS = ddlClaimant_State.Items.FindByValue(objPL_FR.Claimant_State.ToString());
            //used to check if Listitem is not null than value is selected
            if (lstCS != null)
                lstCS.Selected = true;

            txtDate_Of_Loss.Text = clsGeneral.FormatDateToDisplay(objPL_FR.Date_of_Loss);
            //check Date of Loss. if Date of loss is not null than no require to validate these Panel
            if (objPL_FR.Date_of_Loss != null)
            {
                if (Convert.ToDateTime(objPL_FR.Date_of_Loss) != System.Data.SqlTypes.SqlDateTime.MinValue)
                    hdnLoss.Value = "1";
                else
                    hdnLoss.Value = "0";
            }
            else
                hdnLoss.Value = "0";
            txtTime_Of_Loss.Text = objPL_FR.Time_of_Loss;
            txtNonSonic_Loss_Location.Text = objPL_FR.Non_Sonic_Loss_Location;
            txtDescription_Of_Loss.Text = objPL_FR.Description_of_Loss;
            txtDate_Reported_To_Sonic.Text = clsGeneral.FormatDateToDisplay(objPL_FR.Date_Reported_To_Sonic);
            txtWeather_Conditions.Text = objPL_FR.Weather_Conditions;
            txtRoad_Conditions.Text = objPL_FR.Road_Conditions;
            //used to check if the value is null than set values to radio button is "-1"and if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
            if (objPL_FR.Were_Police_Notified != null)
            {
                if (objPL_FR.Were_Police_Notified == true)
                    rdoWere_Police_Notified.SelectedValue = "Y";
                else
                    rdoWere_Police_Notified.SelectedValue = "N";
            }
            else
                rdoWere_Police_Notified.SelectedValue = "-1";
            //used to check the value. if it is true than display below fields else these field are hidden.
            if (objPL_FR.Were_Police_Notified == true)
            {
                trLossPoliceNotified.Style.Add("display", "");
                txtPolice_Organization.Text = objPL_FR.Police_Organization;
                txtCase_Number.Text = objPL_FR.Case_Number;
                txtPolice_telephone.Text = objPL_FR.Police_telephone;
            }
            txtLoss_Category.Text = objPL_FR.Loss_Category;
            //used to check if the value is null than set values to radio button is "-1"and if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
            if (objPL_FR.Personal_Bodily_Injury != null)
            {
                if (objPL_FR.Personal_Bodily_Injury == true)
                    rdoPersonal_Bodily_Injury.SelectedValue = "Y";
                else
                    rdoPersonal_Bodily_Injury.SelectedValue = "N";
            }
            else
                rdoPersonal_Bodily_Injury.SelectedValue = "-1";
            //used to check if the value is null than set values to radio button is "-1"and if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
            if (objPL_FR.Property_Damage != null)
            {
                if (objPL_FR.Property_Damage == true)
                    rdoProperty_Damage.SelectedValue = "Y";
                else
                    rdoProperty_Damage.SelectedValue = "N";
            }
            else
                rdoProperty_Damage.SelectedValue = "-1";
            //used to check if the value is null than set values to radio button is "-1"and if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
            if (objPL_FR.Witnesses != null)
            {
                if (objPL_FR.Witnesses == true)
                    rdoWitnesses.SelectedValue = "Y";
                else
                    rdoWitnesses.SelectedValue = "N";
            }
            else
                rdoWitnesses.SelectedValue = "-1";
            //used to check if the value is null than set values to radio button is "-1"and if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
            if (objPL_FR.Product_Involved != null)
            {
                if (objPL_FR.Product_Involved == true)
                    rdoProduct_Involved.SelectedValue = "Y";
                else
                    rdoProduct_Involved.SelectedValue = "N";
            }
            else
                rdoProduct_Involved.SelectedValue = "-1";

            //Set Security Video System Radiobuttons
            if (objPL_FR.Security_Video_System != null)
            {
                if (objPL_FR.Security_Video_System == true)
                    rdoSecurityVideoSystem.SelectedValue = "Y";
                else
                    rdoSecurityVideoSystem.SelectedValue = "N";
            }
            else
                rdoSecurityVideoSystem.SelectedValue = "-1";

            //used to check values. if value is true than display Injury Panel
            if (objPL_FR.Personal_Bodily_Injury == true)
            {
                pnlDisplayInjuryTab.Visible = true;
                //Bind Injury Panel
                txtInjured_Name.Text = objPL_FR.Injured_Name;
                txtInjured_Gender.Text = objPL_FR.Injured_Gender;
                txtInjured_Address_1.Text = objPL_FR.Injured_Address_1;
                txtInjured_Work_Phone.Text = objPL_FR.Injured_Work_Phone;
                txtInjured_Address_2.Text = objPL_FR.Injured_Address_2;
                txtInjured_Home_Phone.Text = objPL_FR.Injured_Home_Phone;
                txtInjured_City.Text = objPL_FR.Injured_City;
                txtInjured_Alternate_Telephone.Text = objPL_FR.Injured_Alternate_Telephone;
                //used to check the value is NUll or Empty.if it return false than below fields are display else remain hidden
                if (string.IsNullOrEmpty(objPL_FR.Injured_State) == false)
                {
                    ListItem lstIS = new ListItem();
                    lstIS = ddlInjured_State.Items.FindByValue(objPL_FR.Injured_State);
                    //used to check if Listitem is not null than value is selected
                    if (lstIS != null)
                        lstIS.Selected = true;
                }
                txtInjured_Zip_Code.Text = objPL_FR.Injured_ZipCode;
                txtWhat_Was_Injured_Doing.Text = objPL_FR.What_Was_Injured_Doing;
                txtInjured_Injury_Description.Text = objPL_FR.Injured_Injury_Description;
                //used to check the value is NUll or Empty.if it return false than below fields are display else remain hidden
                if (string.IsNullOrEmpty(objPL_FR.body_part) == false)
                {
                    ListItem lstBP = new ListItem();
                    lstBP = ddlbody_part.Items.FindByValue(objPL_FR.body_part);
                    //used to check if Listitem is not null than value is selected
                    if (lstBP != null)
                        lstBP.Selected = true;
                }
                txtInjured_Medical_Treatment_Provided.Text = objPL_FR.Injured_Medical_Treatment_Provided;
                rdoInjured_Taken_By_Emergency_Transportation.SelectedValue = (objPL_FR.Injured_Taken_By_Emergency_Transportation == true) ? "Y" : "N";
                //used to check if the value is null than set values to radio button is "-1"and if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
                if (objPL_FR.Injured_Airlifted_Medivac != null)
                {
                    if (objPL_FR.Injured_Airlifted_Medivac == true)
                        rdoInjured_Airlifted_Medivac.SelectedValue = "Y";
                    else
                        rdoInjured_Airlifted_Medivac.SelectedValue = "N";
                }
                else
                    rdoInjured_Airlifted_Medivac.SelectedValue = "-1";


                txtInjured_Medical_Facility_Name.Text = objPL_FR.Injured_Medical_Facility_Name;
                txtInjured_Date_of_Initial_Treatment.Text = clsGeneral.FormatDateToDisplay(objPL_FR.Injured_Date_of_Initial_Treatment);

                txtInjured_Medical_Facility_Type.Text = objPL_FR.Injured_Medical_Facility_Type;
                txtInjured_Physicians_Name.Text = objPL_FR.Injured_Physicians_Name;
                txtInjured_Medical_Facility_Address_1.Text = objPL_FR.Injured_Medical_Facility_Address_1;
                //used to check if the value is null than set values to radio button is "-1"and if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
                if (objPL_FR.Injured_Admitted_to_Hospital != null)
                {
                    if (objPL_FR.Injured_Admitted_to_Hospital == true)
                        rdoInjured_Admitted_to_Hospital.SelectedValue = "Y";
                    else
                        rdoInjured_Admitted_to_Hospital.SelectedValue = "N";
                }
                else
                    rdoInjured_Admitted_to_Hospital.SelectedValue = "-1";

                txtInjured_Medical_Facility_City.Text = objPL_FR.Injured_Medical_Facility_City;
                txtInjured_Medical_Facility_Address_2.Text = objPL_FR.Injured_Medical_Facility_Address_2;
                //check if value is true than display below fields else fields are remain hidden
                if (objPL_FR.Injured_Admitted_to_Hospital == true)
                {
                    tdInjury_DateAdmitted.Style.Add("display", "");
                    tdInjury_StillHospital.Style.Add("display", "");
                    txtInjured_Date_Admitted_to_Hospital.Text = clsGeneral.FormatDateToDisplay(objPL_FR.Injured_Date_Admitted_to_Hospital);
                    //used to check if the value is null than set values to radio button is "-1"and if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
                    if (objPL_FR.Injured_Still_in_Hospital != null)
                    {
                        if (objPL_FR.Injured_Still_in_Hospital == true)
                            rdoInjured_Still_in_Hospital.SelectedValue = "Y";
                        else
                            rdoInjured_Still_in_Hospital.SelectedValue = "N";
                    }
                    else
                        rdoInjured_Still_in_Hospital.SelectedValue = "-1";
                }
                //checke value is null or empty. if returns false than display below fields. else remains hidden
                if (string.IsNullOrEmpty(objPL_FR.Injured_Medical_Facility_State) == false)
                {
                    ListItem lstIMFS = new ListItem();
                    lstIMFS = ddlInjured_Medical_Facility_State.Items.FindByValue(objPL_FR.Injured_Medical_Facility_State);
                    //used to check if Listitem is not null than value is selected
                    if (lstIMFS != null)
                        lstIMFS.Selected = true;
                }
                txtInjured_Medical_Facility_Zip_Code.Text = objPL_FR.Injured_Medical_Facility_Zip_Code;
            }

            //check value if it true than display Property Informaiton Panel else remains hidden
            if (objPL_FR.Property_Damage == true)
            {
                pnlDisplayPropertyTab.Visible = true;
                //Bind Property Panel
                txtProperty_Description.Text = objPL_FR.Property_Description;
                txtProperty_Damage_Description.Text = objPL_FR.Property_Damage_Description;
                //used to check if the value is null than set values to radio button is "-1"and if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
                if (objPL_FR.Estimate_Available != null)
                {
                    if (objPL_FR.Estimate_Available == true)
                        rdoEstimate_Available.SelectedValue = "Y";
                    else
                        rdoEstimate_Available.SelectedValue = "N";
                }
                else
                    rdoEstimate_Available.SelectedValue = "-1";
                txtEstimate_Amount.Text = clsGeneral.GetStringValue(objPL_FR.Estimate_Amount);
                txtProperty_Estimator_Name.Text = objPL_FR.Property_Estimator_Name;
                txtEstimator_Phone.Text = objPL_FR.Estimator_Phone;
                txtProperty_Business_Name.Text = objPL_FR.Property_Business_Name;
                txtProperty_Address_1.Text = objPL_FR.Property_Address_1;
                txtProperty_Address_2.Text = objPL_FR.Property_Address_2;
                txtProperty_City.Text = objPL_FR.Property_City;
                //check value is null or empty. if return false displayed below fields else remains hidden
                if (string.IsNullOrEmpty(objPL_FR.Property_State) == false)
                {
                    ListItem lstPS = new ListItem();
                    lstPS = ddlProperty_State.Items.FindByValue(objPL_FR.Property_State);
                    //used to check if Listitem is not null than value is selected
                    if (lstPS != null)
                        lstPS.Selected = true;
                }
                txtProperty_Zip_Code.Text = objPL_FR.Property_Zip_Code;
                txtLocation_where_property_can_be_seen.Text = objPL_FR.Location_where_property_can_be_seen;
                txtOwner_Name.Text = objPL_FR.Owner_Name;
                txtOwner_Work_Telephone.Text = objPL_FR.Owner_Work_Telephone;
                txtOwner_Home_Telephone.Text = objPL_FR.Owner_Home_Telephone;
                txtOwner_Alternate_Telephone.Text = objPL_FR.Owner_Alternate_Telephone;
            }
            //check value.if it is true then display witness information panel else remains hidden
            if (objPL_FR.Witnesses == true)
            {
                pnlDisplayWitnessesTab.Visible = true;
                //Bind Witness Panel
                txtWitness_Name.Text = objPL_FR.Witness_Name;
                txtWitness_Home_Phone.Text = objPL_FR.Witness_Home_Telephone;
                txtWitness_Work_Phone.Text = objPL_FR.Witness_Work_Telephone;
                txtWitness_Alternate_Phone.Text = objPL_FR.Witness_Alternate_Telephone;
                txtWitness_Address_1.Text = objPL_FR.Witness_Address_1;
                txtWitness_Address_2.Text = objPL_FR.Witness_Address_2;
                txtWitness_City.Text = objPL_FR.Witness_City;
                //used to check value is null or empty. if returns false than disply related fields else remain hidden
                if (string.IsNullOrEmpty(objPL_FR.Witness_State) == false)
                {
                    ListItem lstWS = new ListItem();
                    lstWS = ddlWitness_State.Items.FindByValue(objPL_FR.Witness_State);
                    //used to check if Listitem is not null than value is selected
                    if (lstWS != null)
                        lstWS.Selected = true;
                }
                txtWitness_Zip_Code.Text = objPL_FR.Witness_Zip_Code;
            }
            //used to check value. if value is true than display Product Information panel else Remains Hidden
            if (objPL_FR.Product_Involved == true)
            {
                pnlDisplayProductTab.Visible = true;
                //Bind Product Involved Panel
                txtType_of_Product.Text = objPL_FR.Type_of_Product;
                txtManufacturer_Name.Text = objPL_FR.Manufacturer_Name;
                txtProduct_Address_1.Text = objPL_FR.Product_Address_1;
                txtProduct_Address_2.Text = objPL_FR.Product_Address_2;
                txtProduct_City.Text = objPL_FR.Product_City;
                //used to check value is null or empty. if returns false than disply related fields else remain hidden
                if (String.IsNullOrEmpty(objPL_FR.Product_State) == false)
                {
                    ListItem lstPS = new ListItem();
                    lstPS = ddlProduct_State.Items.FindByValue(objPL_FR.Product_State);
                    //used to check if Listitem is not null than value is selected
                    if (lstPS != null)
                        lstPS.Selected = true;
                }
                txtProduct_Zip_Code.Text = objPL_FR.Product_Zip_Code;
                txtProduct_Location.Text = objPL_FR.Product_Location;
            }
            #endregion

            #region "Involvement grid"

            gvInvolvement.DataSource = clsFR_PL_Involvement.SelectByFK(PK_PL_FR_ID);
            gvInvolvement.DataBind();

            #endregion

            #region Comments and Attachments
            txtComments.Text = objPL_FR.Comments;
            CtrlAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.PL_FR, PK_PL_FR_ID, true, 7);
            CtrlAttachDetails.Bind();
            #endregion
        }
        else
        {
            Response.Redirect("FirstReportSearch.aspx", true);
        }
    }

    #endregion

    #region "General"
    /// <summary>
    /// Used to Generate script to dynamically select next panel.
    /// </summary>
    /// <param name="Index">No of Panel</param>
    /// <returns></returns>
    public string gScript(int Index)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("var bool=false;");
        sb.AppendLine("for(i=" + Index + ";i<=6;i++)");
        sb.AppendLine("{");
        sb.AppendLine("if(document.getElementById('PLMenu'+i).style.display =='')");
        sb.AppendLine("{");
        sb.AppendLine("FireAll(); ShowPanel(i);");
        sb.AppendLine("bool=true;");
        sb.AppendLine("break;");
        sb.AppendLine("}");
        sb.AppendLine("}");
        sb.AppendLine("if(bool==false)");
        sb.AppendLine("{");
        sb.AppendLine("FireAll(); ShowPanel(7);");
        sb.AppendLine("}");
        return sb.ToString();
    }
    #endregion

    #region Email Body Generator

    /// <summary>
    /// Used to Create Email Body
    /// </summary>
    /// <returns></returns>
    public string GenerateEMailBody(out string FirstReportNumber)
    {
        string strFilePath = HttpContext.Current.Server.MapPath("~/EmailTemplate/PL_FR.htm");
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
                //Declare Object of WC_FR table
                PL_FR objPL_FR = new PL_FR(PK_PL_FR_ID);

                #region Location/Contact Information
                DataSet dsFRW = First_Report_Wizard.GetInfoByWizardID(First_Report_Wizard_ID, First_Report_Wizard.Tables.PL_FR, PK_PL_FR_ID);
                DataTable dtFRW = dsFRW.Tables[0];
                if (dtFRW.Rows.Count > 0)
                {
                    DataRow drFRW = dtFRW.Rows[0];

                    #region Fill Location Information Controls

                    FirstReportNumber = drFRW["FK_First_Report_ID"].ToString();
                    decimal FR_Number = new PL_FR(FirstReportNumber.ToString() != string.Empty ? Convert.ToDecimal(FirstReportNumber) : 0).PL_FR_Number;
                    strEbdy = strEbdy.Replace("[lblFirstReportNumber]", "PL-" + FR_Number.ToString());
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
                    if (drFRW["legal_entity"] != null)
                        strEbdy = strEbdy.Replace("[lblLegalEntity]", drFRW["legal_entity"].ToString());
                    else
                        strEbdy = strEbdy.Replace("[lblLegalEntity]", "");

                    //set address1,address2,city,state,ZipCOde Values
                    strEbdy = strEbdy.Replace("[lblLocationAddress1]", (drFRW["Address_1"] != null) ? Convert.ToString(drFRW["Address_1"]) : "");
                    strEbdy = strEbdy.Replace("[lblLocationAddress2]", (drFRW["Address_2"] != null) ? Convert.ToString(drFRW["Address_2"]) : "");
                    strEbdy = strEbdy.Replace("[lblLocationCity]", (drFRW["City"] != null) ? Convert.ToString(drFRW["City"]) : "");
                    strEbdy = strEbdy.Replace("[lblLocationState]", new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state);
                    strEbdy = strEbdy.Replace("[lblLocationZipCode]", (drFRW["Zip_Code"] != null) ? Convert.ToString(drFRW["Zip_Code"]) : "");

                    #endregion

                    #region Fill Contact Information Controls

                    //lblContactName.Text = (drFRW["EmployeeName"] != null) ? Convert.ToString(drFRW["EmployeeName"]) : "";
                    //lblContact_Best_Time.Text = (drFRW["Contact_Best_Time"] != null) ? Convert.ToString(drFRW["Contact_Best_Time"]) : "";
                    //lblContactTelephoneNumber1.Text = (drFRW["Work_Phone"] != null) ? Convert.ToString(drFRW["Work_Phone"]) : "";
                    //lblContactTelephoneNumber2.Text = (drFRW["Employee_Cell_Phone"] != null) ? Convert.ToString(drFRW["Employee_Cell_Phone"]) : "";
                    //lblContactFaxNumber.Text = (drFRW["Contact_Fax"] != null) ? Convert.ToString(drFRW["Contact_Fax"]) : "";
                    //lblContactEmailAddress.Text = (drFRW["Email"] != null) ? Convert.ToString(drFRW["Email"]) : "";
                    //lblCostCenterdba.Text = (drFRW["dba"] != null) ? Convert.ToString(drFRW["dba"]) : "";
                    //lblCostCenterAddress2.Text = (drFRW["Work_Phone"] != null) ? Convert.ToString(drFRW["Work_Phone"]) : "";
                    //lblCostCenterAddress2.Text = (drFRW["Employee_Cell_Phone"] != null) ? Convert.ToString(drFRW["Employee_Cell_Phone"]) : "";
                    //lblCostCenterCity.Text = (drFRW["City"] != null) ? Convert.ToString(drFRW["City"]) : "";
                    //lblCostCenterZipCode.Text = (drFRW["Zip_Code"] != null) ? Convert.ToString(drFRW["Zip_Code"]) : "";
                    //lblCostCenterState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state;


                    strEbdy = strEbdy.Replace("[lblContactName]", (drFRW["EmployeeName"] != null) ? Convert.ToString(drFRW["EmployeeName"]) : "");
                    strEbdy = strEbdy.Replace("[lblContact_Best_Time]", (drFRW["Contact_Best_Time"] != null) ? Convert.ToString(drFRW["Contact_Best_Time"]) : "");
                    strEbdy = strEbdy.Replace("[lblContactTelephoneNumber1]", (drFRW["TelephoneNumber1"] != null) ? Convert.ToString(drFRW["TelephoneNumber1"]) : "");
                    strEbdy = strEbdy.Replace("[lblContactTelephoneNumber2]", (drFRW["TelephoneNumber2"] != null) ? Convert.ToString(drFRW["TelephoneNumber2"]) : "");
                    strEbdy = strEbdy.Replace("[lblContactFaxNumber]", (drFRW["Contact_Fax"] != null) ? Convert.ToString(drFRW["Contact_Fax"]) : "");
                    strEbdy = strEbdy.Replace("[lblContactEmailAddress]", (drFRW["FRWEmail"] != null) ? Convert.ToString(drFRW["FRWEmail"]) : "");
                    //fill Controls By Cost Center Value
                    strEbdy = strEbdy.Replace("[lblCostCenterdba]", (drFRW["dba"] != null) ? Convert.ToString(drFRW["dba"]) : "");
                    strEbdy = strEbdy.Replace("[lblCostCenterAddress1]", (drFRW["Address_1"] != null) ? Convert.ToString(drFRW["Address_1"]) : "");
                    strEbdy = strEbdy.Replace("[lblCostCenterAddress2]", (drFRW["Address_2"] != null) ? Convert.ToString(drFRW["Address_2"]) : "");
                    strEbdy = strEbdy.Replace("[lblCostCenterCity]", (drFRW["City"] != null) ? Convert.ToString(drFRW["City"]) : "");
                    strEbdy = strEbdy.Replace("[lblCostCenterState]", new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state);
                    strEbdy = strEbdy.Replace("[lblCostCenterZipCode]", (drFRW["Zip_Code"] != null) ? Convert.ToString(drFRW["Zip_Code"]) : "");
                    #endregion
                    strEbdy = strEbdy.Replace("[lblDBA]", drFRW["dba"].ToString());
                }
                else
                {
                    FirstReportNumber = "";
                }
                #endregion

                #region Loss Information
                //Set values to object
                strEbdy = strEbdy.Replace("[lblClaimant_State]", new State(Convert.ToDecimal(objPL_FR.Claimant_State)).FLD_state);
                strEbdy = strEbdy.Replace("[lblDate_Of_Loss]", clsGeneral.FormatDateToDisplay(objPL_FR.Date_of_Loss));
                strEbdy = strEbdy.Replace("[lblTime_Of_Loss]", objPL_FR.Time_of_Loss);
                strEbdy = strEbdy.Replace("[lblNonSonic_Loss_Location]", objPL_FR.Non_Sonic_Loss_Location);
                strEbdy = strEbdy.Replace("[lblDescription_Of_Loss]", objPL_FR.Description_of_Loss);
                strEbdy = strEbdy.Replace("[lblDate_Reported_To_Sonic]", clsGeneral.FormatDateToDisplay(objPL_FR.Date_Reported_To_Sonic));
                strEbdy = strEbdy.Replace("[lblWeather_Conditions]", objPL_FR.Weather_Conditions);
                strEbdy = strEbdy.Replace("[lblRoad_Conditions]", objPL_FR.Road_Conditions);

                string strInvolvement = "";
                try
                {
                    DataTable dtInveolvement = clsFR_PL_Involvement.SelectByFK(PK_PL_FR_ID).Tables[0];
                    if (dtInveolvement != null && dtInveolvement.Rows.Count > 0)
                    {
                        strInvolvement += "<table width='100%' cellpadding='1' cellspacing='1' border='0'>";
                        strInvolvement += "<tr class='bandHeaderRow'>";
                        strInvolvement += "<td align='left' width='22%'>&nbsp;Type</td>";
                        strInvolvement += "<td align='left' width='28%'>&nbsp;Name</td>";
                        strInvolvement += "<td align='left' width='28%'>&nbsp;Address</td>";
                        strInvolvement += "<td align='left' width='22%'>&nbsp;Phone</td>";
                        strInvolvement += "</tr>";

                        foreach (DataRow dr in dtInveolvement.Rows)
                        {
                            strInvolvement += "<tr>";
                            strInvolvement += "<td align='left' >&nbsp;" + Convert.ToString(dr["TypeName"]) + "</td>";
                            strInvolvement += "<td align='left' >&nbsp;" + Convert.ToString(dr["Name"]) + "</td>";
                            strInvolvement += "<td align='left' >&nbsp;" + Convert.ToString(dr["Address"]) + "</td>";
                            strInvolvement += "<td align='left' >&nbsp;" + Convert.ToString(dr["Home_Telephone"]) + "</td>";
                            strInvolvement += "</tr>";
                        }
                        strInvolvement += "</table>";
                    }
                    else
                        strInvolvement = "<div class='bandHeaderRow'><b>&nbsp;No Record(s) Found.</b></div>";
                }
                catch
                {
                    strInvolvement = "<div class='bandHeaderRow'><b>&nbsp;No Record(s) Found.</b></div>";
                }

                strEbdy = strEbdy.Replace("[Incident_Involvement_Grid]", strInvolvement);

                //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
                if (objPL_FR.Were_Police_Notified != null)
                {
                    if (objPL_FR.Were_Police_Notified == true)
                        strEbdy = strEbdy.Replace("[lblWere_Police_Notified]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblWere_Police_Notified]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblWere_Police_Notified]", "unknown");

                if (objPL_FR.Security_Video_System != null)
                {
                    if (objPL_FR.Security_Video_System == true)
                        strEbdy = strEbdy.Replace("[lblSecurityVideoSystem]", "Yes");
                    else
                        strEbdy = strEbdy.Replace("[lblSecurityVideoSystem]", "No");
                }
                else
                    strEbdy = strEbdy.Replace("[lblSecurityVideoSystem]", "unknown");

                //check value. if it is true than display related fields else remains hidden
                if (objPL_FR.Were_Police_Notified == true)
                {
                    //strEbdy = strEbdy.Replace("[PolicNotification]", "block");
                    strEbdy = strEbdy.Replace("[lblPolice_Organization]", objPL_FR.Police_Organization);
                    strEbdy = strEbdy.Replace("[lblCase_Number]", objPL_FR.Case_Number);
                    strEbdy = strEbdy.Replace("[lblPolice_telephone]", objPL_FR.Police_telephone);
                }
                else
                {
                    //strEbdy = strEbdy.Replace("[PolicNotification]", "none");
                    strEbdy = strEbdy.Replace("<!--[PolicNotification] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#PolicNotification] -->", "-->");
                }
                strEbdy = strEbdy.Replace("[lblLoss_Category]", objPL_FR.Loss_Category);
                //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
                if (objPL_FR.Personal_Bodily_Injury != null)
                {
                    if (objPL_FR.Personal_Bodily_Injury == true)
                        strEbdy = strEbdy.Replace("[lblPersonal_Bodily_Injury]", "Yes");
                    else
                    {
                        strEbdy = strEbdy.Replace("[lblPersonal_Bodily_Injury]", "No");
                        strEbdy = strEbdy.Replace("<!--[DateAdmitted] -->", "");
                        strEbdy = strEbdy.Replace("<!--[#DateAdmitted] -->", "");
                        strEbdy = strEbdy.Replace("<!--[StillHospital] -->", "");
                        strEbdy = strEbdy.Replace("<!--[#StillHospital] -->", "");
                        strEbdy = strEbdy.Replace("<!--[divInjury] -->", "<!--");
                        strEbdy = strEbdy.Replace("<!--[#divInjury] -->", "-->");

                    }
                }
                else
                {
                    strEbdy = strEbdy.Replace("[lblPersonal_Bodily_Injury]", "unknown");
                    strEbdy = strEbdy.Replace("<!--[DateAdmitted] -->", "");
                    strEbdy = strEbdy.Replace("<!--[#DateAdmitted] -->", "");
                    strEbdy = strEbdy.Replace("<!--[StillHospital] -->", "");
                    strEbdy = strEbdy.Replace("<!--[#StillHospital] -->", "");
                    strEbdy = strEbdy.Replace("<!--[divInjury] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#divInjury] -->", "-->");
                }
                //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
                if (objPL_FR.Property_Damage != null)
                {
                    if (objPL_FR.Property_Damage == true)
                        strEbdy = strEbdy.Replace("[lblProperty_Damage]", "Yes");
                    else
                    {
                        strEbdy = strEbdy.Replace("[lblProperty_Damage]", "No");
                        strEbdy = strEbdy.Replace("<!--[divProperty] -->", "<!--");
                        strEbdy = strEbdy.Replace("<!--[#divProperty] -->", "-->");
                    }
                }
                else
                {
                    strEbdy = strEbdy.Replace("[lblProperty_Damage]", "unknown");
                    strEbdy = strEbdy.Replace("<!--[divProperty] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#divProperty] -->", "-->");
                }
                //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
                if (objPL_FR.Witnesses != null)
                {
                    if (objPL_FR.Witnesses == true)
                        strEbdy = strEbdy.Replace("[lblWitnesses]", "Yes");
                    else
                    {
                        strEbdy = strEbdy.Replace("[lblWitnesses]", "No");
                        strEbdy = strEbdy.Replace("<!--[divWitness] -->", "<!--");
                        strEbdy = strEbdy.Replace("<!--[#divWitness] -->", "-->");
                    }
                }
                else
                {
                    strEbdy = strEbdy.Replace("[lblWitnesses]", "unknown");
                    strEbdy = strEbdy.Replace("<!--[divWitness] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#divWitness] -->", "-->");
                }
                //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
                if (objPL_FR.Product_Involved != null)
                {
                    if (objPL_FR.Product_Involved == true)
                        strEbdy = strEbdy.Replace("[lblProduct_Involved]", "Yes");
                    else
                    {
                        strEbdy = strEbdy.Replace("[lblProduct_Involved]", "No");
                        strEbdy = strEbdy.Replace("<!--[divProduct] -->", "<!--");
                        strEbdy = strEbdy.Replace("<!--[#divProduct] -->", "-->");
                    }
                }
                else
                {
                    strEbdy = strEbdy.Replace("[lblProduct_Involved]", "unknown");
                    strEbdy = strEbdy.Replace("<!--[divProduct] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#divProduct] -->", "-->");
                }
                //used to check value. if it is true than display related fields else remains hidden
                if (objPL_FR.Personal_Bodily_Injury == true)
                {
                    //strEbdy = strEbdy.Replace("[divInjury]", "block");
                    //Bind Injury Panel
                    strEbdy = strEbdy.Replace("[lblInjured_Name]", objPL_FR.Injured_Name);
                    strEbdy = strEbdy.Replace("[lblInjured_Gender]", objPL_FR.Injured_Gender);
                    strEbdy = strEbdy.Replace("[lblInjured_Address_1]", objPL_FR.Injured_Address_1);
                    strEbdy = strEbdy.Replace("[lblInjured_Work_Phone]", objPL_FR.Injured_Work_Phone);
                    strEbdy = strEbdy.Replace("[lblInjured_Address_2]", objPL_FR.Injured_Address_2);
                    strEbdy = strEbdy.Replace("[lblInjured_Home_Phone]", objPL_FR.Injured_Home_Phone);
                    strEbdy = strEbdy.Replace("[lblInjured_City]", objPL_FR.Injured_City);
                    strEbdy = strEbdy.Replace("[lblInjured_Alternate_Telephone]", objPL_FR.Injured_Alternate_Telephone);
                    strEbdy = strEbdy.Replace("[lblInjured_State]", new State(string.IsNullOrEmpty(objPL_FR.Injured_State) ? 0 : Convert.ToDecimal(objPL_FR.Injured_State)).FLD_state);
                    strEbdy = strEbdy.Replace("[lblInjured_Zip_Code]", objPL_FR.Injured_ZipCode);
                    strEbdy = strEbdy.Replace("[lblWhat_Was_Injured_Doing]", objPL_FR.What_Was_Injured_Doing);
                    strEbdy = strEbdy.Replace("[lblInjured_Injury_Description]", objPL_FR.Injured_Injury_Description);
                    strEbdy = strEbdy.Replace("[lblbody_part]", new LU_Part_Of_Body(string.IsNullOrEmpty(objPL_FR.body_part) ? 0 : Convert.ToDecimal(objPL_FR.body_part)).Description);
                    strEbdy = strEbdy.Replace("[lblInjured_Medical_Treatment_Provided]", objPL_FR.Injured_Medical_Treatment_Provided);
                    strEbdy = strEbdy.Replace("[lblInjured_Taken_By_Emergency_Transportation]", (objPL_FR.Injured_Taken_By_Emergency_Transportation == true) ? "Yes" : "No");
                    //check value if it is null than display "unknown" else if it is truw than display "Yes" else "no"
                    if (objPL_FR.Injured_Airlifted_Medivac != null)
                    {
                        if (objPL_FR.Injured_Airlifted_Medivac == true)
                            strEbdy = strEbdy.Replace("[lblInjured_Airlifted_Medivac]", "Yes");
                        else
                            strEbdy = strEbdy.Replace("[lblInjured_Airlifted_Medivac]", "No");
                    }
                    else
                        strEbdy = strEbdy.Replace("[lblInjured_Airlifted_Medivac]", "unknown");


                    strEbdy = strEbdy.Replace("[lblInjured_Medical_Facility_Name]", objPL_FR.Injured_Medical_Facility_Name);
                    strEbdy = strEbdy.Replace("[lblInjured_Date_of_Initial_Treatment]", clsGeneral.FormatDateToDisplay(objPL_FR.Injured_Date_of_Initial_Treatment));

                    strEbdy = strEbdy.Replace("[lblInjured_Medical_Facility_Type]", objPL_FR.Injured_Medical_Facility_Type);
                    strEbdy = strEbdy.Replace("[lblInjured_Physicians_Name]", objPL_FR.Injured_Physicians_Name);
                    strEbdy = strEbdy.Replace("[lblInjured_Medical_Facility_Address_1]", objPL_FR.Injured_Medical_Facility_Address_1);
                    //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
                    if (objPL_FR.Injured_Admitted_to_Hospital != null)
                    {
                        if (objPL_FR.Injured_Admitted_to_Hospital == true)
                            strEbdy = strEbdy.Replace("[lblInjured_Admitted_to_Hospital]", "Yes");
                        else
                            strEbdy = strEbdy.Replace("[lblInjured_Admitted_to_Hospital]", "No");
                    }
                    else
                        strEbdy = strEbdy.Replace("[lblInjured_Admitted_to_Hospital]", "unknown");

                    strEbdy = strEbdy.Replace("[lblInjured_Medical_Facility_City]", objPL_FR.Injured_Medical_Facility_City);
                    strEbdy = strEbdy.Replace("[lblInjured_Medical_Facility_Address_2]", objPL_FR.Injured_Medical_Facility_Address_2);
                    //check value. if it is true than display related fields else they remains hidden
                    if (objPL_FR.Injured_Admitted_to_Hospital == true)
                    {
                        //strEbdy = strEbdy.Replace("[DateAdmitted]", "block");
                        //strEbdy = strEbdy.Replace("[StillHospital]", "block");
                        strEbdy = strEbdy.Replace("[lblInjured_Date_Admitted_to_Hospital]", clsGeneral.FormatDateToDisplay(objPL_FR.Injured_Date_Admitted_to_Hospital));
                        //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
                        if (objPL_FR.Injured_Still_in_Hospital != null)
                        {
                            if (objPL_FR.Injured_Still_in_Hospital == true)
                                strEbdy = strEbdy.Replace("[lblInjured_Still_in_Hospital]", "Yes");
                            else
                                strEbdy = strEbdy.Replace("[lblInjured_Still_in_Hospital]", "No");
                        }
                        else
                            strEbdy = strEbdy.Replace("[lblInjured_Still_in_Hospital]", "unknown");
                    }
                    else
                    {
                        strEbdy = strEbdy.Replace("<!--[DateAdmitted] -->", "<!--");
                        strEbdy = strEbdy.Replace("<!--[#DateAdmitted] -->", "-->");
                        //strEbdy = strEbdy.Replace("[DateAdmitted]", "none");
                        strEbdy = strEbdy.Replace("<!--[StillHospital] -->", "<!--");
                        strEbdy = strEbdy.Replace("<!--[#StillHospital] -->", "-->");
                        //strEbdy = strEbdy.Replace("[StillHospital]", "none");
                    }

                    strEbdy = strEbdy.Replace("[lblInjured_Medical_Facility_State]", new State(string.IsNullOrEmpty(objPL_FR.Injured_Medical_Facility_State) ? 0 : Convert.ToDecimal(objPL_FR.Injured_Medical_Facility_State)).FLD_state);
                    strEbdy = strEbdy.Replace("[lblInjured_Medical_Facility_Zip_Code]", objPL_FR.Injured_Medical_Facility_Zip_Code);
                }
                else
                {
                    strEbdy = strEbdy.Replace("<!--[DateAdmitted] -->", "");
                    strEbdy = strEbdy.Replace("<!--[#DateAdmitted] -->", "");
                    strEbdy = strEbdy.Replace("<!--[StillHospital] -->", "");
                    strEbdy = strEbdy.Replace("<!--[#StillHospital] -->", "");
                    strEbdy = strEbdy.Replace("<!--[divInjury] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#divInjury] -->", "-->");
                }
                //check values if return true than display Property Panel else remain hidden
                if (objPL_FR.Property_Damage == true)
                {
                    //strEbdy = strEbdy.Replace("[divProperty]", "block");
                    //Bind Property Panel 
                    strEbdy = strEbdy.Replace("[lblProperty_Description]", objPL_FR.Property_Description);
                    strEbdy = strEbdy.Replace("[lblProperty_Damage_Description]", objPL_FR.Property_Damage_Description);
                    //check value if it is null than display "nuknown" else if it is truw than display "Yes" else "no"
                    if (objPL_FR.Estimate_Available != null)
                    {
                        if (objPL_FR.Estimate_Available == true)
                            strEbdy = strEbdy.Replace("[lblEstimate_Available]", "Yes");
                        else
                            strEbdy = strEbdy.Replace("[lblEstimate_Available]", "No");
                    }
                    else
                        strEbdy = strEbdy.Replace("[lblEstimate_Available]", "unknown");
                    strEbdy = strEbdy.Replace("[lblEstimate_Amount]", "$ " + clsGeneral.GetStringValue(objPL_FR.Estimate_Amount));
                    strEbdy = strEbdy.Replace("[lblProperty_Estimator_Name]", objPL_FR.Property_Estimator_Name);
                    strEbdy = strEbdy.Replace("[lblEstimator_Phone]", objPL_FR.Estimator_Phone);
                    strEbdy = strEbdy.Replace("[lblProperty_Business_Name]", objPL_FR.Property_Business_Name);
                    strEbdy = strEbdy.Replace("[lblProperty_Address_1]", objPL_FR.Property_Address_1);
                    strEbdy = strEbdy.Replace("[lblProperty_Address_2]", objPL_FR.Property_Address_2);
                    strEbdy = strEbdy.Replace("[lblProperty_City]", objPL_FR.Property_City);
                    strEbdy = strEbdy.Replace("[lblProperty_State]", new State(string.IsNullOrEmpty(objPL_FR.Property_State) ? 0 : Convert.ToDecimal(objPL_FR.Property_State)).FLD_state);
                    strEbdy = strEbdy.Replace("[lblProperty_Zip_Code]", objPL_FR.Property_Zip_Code);
                    strEbdy = strEbdy.Replace("[lblLocation_where_property_can_be_seen]", objPL_FR.Location_where_property_can_be_seen);
                    strEbdy = strEbdy.Replace("[lblOwner_Name]", objPL_FR.Owner_Name);
                    strEbdy = strEbdy.Replace("[lblOwner_Work_Telephone]", objPL_FR.Owner_Work_Telephone);
                    strEbdy = strEbdy.Replace("[lblOwner_Home_Telephone]", objPL_FR.Owner_Home_Telephone);
                    strEbdy = strEbdy.Replace("[lblOwner_Alternate_Telephone]", objPL_FR.Owner_Alternate_Telephone);
                }
                else
                {
                    //strEbdy = strEbdy.Replace("[divProperty]", "none");
                    strEbdy = strEbdy.Replace("<!--[divProperty] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#divProperty] -->", "-->");
                }
                //used to check values. if it is true than display Witness Information panel else Remains hidden
                if (objPL_FR.Witnesses == true)
                {
                    //strEbdy = strEbdy.Replace("[divWitness]", "block");
                    //Bind Witness Panel 
                    strEbdy = strEbdy.Replace("[lblWitness_Name]", objPL_FR.Witness_Name);
                    strEbdy = strEbdy.Replace("[lblWitness_Home_Phone]", objPL_FR.Witness_Home_Telephone);
                    strEbdy = strEbdy.Replace("[lblWitness_Work_Phone]", objPL_FR.Witness_Work_Telephone);
                    strEbdy = strEbdy.Replace("[lblWitness_Alternate_Phone]", objPL_FR.Witness_Alternate_Telephone);
                    strEbdy = strEbdy.Replace("[lblWitness_Address_1]", objPL_FR.Witness_Address_1);
                    strEbdy = strEbdy.Replace("[lblWitness_Address_2]", objPL_FR.Witness_Address_2);
                    strEbdy = strEbdy.Replace("[lblWitness_City]", objPL_FR.Witness_City);
                    strEbdy = strEbdy.Replace("[lblWitness_State]", new State(string.IsNullOrEmpty(objPL_FR.Witness_State) ? 0 : Convert.ToDecimal(objPL_FR.Witness_State)).FLD_state);
                    strEbdy = strEbdy.Replace("[lblWitness_Zip_Code]", objPL_FR.Witness_Zip_Code);
                }
                else
                {
                    //strEbdy = strEbdy.Replace("[divWitness]", "none");
                    strEbdy = strEbdy.Replace("<!--[divWitness] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#divWitness] -->", " -->");
                }
                //used to check values.if it is true than display product information panel else remains hidden
                if (objPL_FR.Product_Involved == true)
                {
                    //strEbdy = strEbdy.Replace("[divProduct]", "block");
                    //Bind Product Involved Panel 
                    strEbdy = strEbdy.Replace("[lblType_of_Product]", objPL_FR.Type_of_Product);
                    strEbdy = strEbdy.Replace("[lblManufacturer_Name]", objPL_FR.Manufacturer_Name);
                    strEbdy = strEbdy.Replace("[lblProduct_Address_1]", objPL_FR.Product_Address_1);
                    strEbdy = strEbdy.Replace("[lblProduct_Address_2]", objPL_FR.Product_Address_2);
                    strEbdy = strEbdy.Replace("[lblProduct_City]", objPL_FR.Product_City);
                    strEbdy = strEbdy.Replace("[lblProduct_State]", new State(String.IsNullOrEmpty(objPL_FR.Product_State) ? 0 : Convert.ToDecimal(objPL_FR.Product_State)).FLD_state);
                    strEbdy = strEbdy.Replace("[lblProduct_Zip_Code]", objPL_FR.Product_Zip_Code);
                    strEbdy = strEbdy.Replace("[lblProduct_Location]", objPL_FR.Product_Location);
                }
                else
                {
                    //strEbdy = strEbdy.Replace("[divProduct]", "none");
                    strEbdy = strEbdy.Replace("<!--[divProduct] -->", "<!--");
                    strEbdy = strEbdy.Replace("<!--[#divProduct] -->", " -->");
                }
                #endregion

                strEbdy = strEbdy.Replace("[lblComments]", objPL_FR.Comments);
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
    /// Update File
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {
        //Insert values into AL_FR_Attachment table
        CtrlAttachment.Add(clsGeneral.Tables.PL_FR, PK_PL_FR_ID);
        // Used to Bind Grid with Attached Data
        CtrlAttachDetails.Bind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:FireAll(); ShowPanel(7);", true);
    }

    #endregion

    #region Bind Sonic Header INformation Controls

    /// <summary>
    /// set values to SONIC informaiton header control
    /// </summary>
    public void setSonicHeaderInfo()
    {
        //Create Object
        PL_FR objPL_FR = new PL_FR(PK_PL_FR_ID);
        SonicInfo.FirstReportNumber = "PL-" + objPL_FR.PL_FR_Number.ToString();
        SonicInfo.SONICLocationdba = new LU_Location(objPL_FR.FK_LU_Location_ID).dba.ToString();
        SonicInfo.DateOfIncident = clsGeneral.FormatDateToDisplay(objPL_FR.Date_of_Loss);

        DataTable dtClaimInfo = WC_ClaimInfo.Select_Claim_Number(PK_PL_FR_ID, "PL");
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

    #region "Send Email"

    /// <summary>
    /// send Email-button click event
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
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", " if(window.confirm('" + confirmMessage + "')){ __doPostBack('UserConfirmationPostBackView','true');} else {alert('The First Report has NOT been sent, please reduce the number and/or size of the attachments before attempting to resubmit with attachments.');ShowPanel(7);}", true);
                return;
            }

            if (ResendMail(true))
                ScriptManager.RegisterStartupScript(this, Page.GetType(), System.DateTime.Now.ToString(), "javascript:alert('First Report mail send successfully');ShowPanel(" + hdnCureentPanel.Value + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "alert('Something went wrong. Please try after sometime.'); window.location='FirstReportSearch.aspx';", true);
        }
    }

    /// <summary>
    /// resend Email
    /// </summary>
    /// <param name="_IsAttachment"></param>
    private bool ResendMail(bool _IsAttachment)
    {
        // Declare Object
        PL_FR objPL_FR = new PL_FR(PK_PL_FR_ID);

        int intAttCount = 0;
        //Get Attachment Details
        DataTable dtAtt = PL_FR_Attachments.SelectByFR_ID(PK_PL_FR_ID).Tables[0];
        string[] strAtt = new string[dtAtt.Rows.Count];
        if (_IsAttachment)
        {
            if (dtAtt.Rows.Count > 0)
            {
                foreach (DataRow drAtt in dtAtt.Rows)
                {
                    string strFileName = drAtt["Attachment_Path"].ToString();
                    strFileName = AppConfig.PL_FRDocPath + strFileName;
                    strAtt[intAttCount] = strFileName;
                    intAttCount = intAttCount + 1;
                }

            }
        }
        //get recipient Id
        //DataTable dtRecipient = Email_Settings.SelectByModuleName("PL").Tables[0];
        DataTable dtRecipient = LU_Location.GetRecipientEmailID(objPL_FR.FK_LU_Location_ID, LU_Location.SonicReportType.PL).Tables[0];
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
            decimal FR_Number = new PL_FR(ReturnFRNumber.ToString() != string.Empty ? Convert.ToDecimal(ReturnFRNumber) : 0).PL_FR_Number;

            // send Email
            if (EmailTo.Length > 0 && !string.IsNullOrEmpty(HtmlBody))
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));
                objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Repeat :: Sonic Automotive (acct #42979) reports the following First Report of Loss PL-" + FR_Number.ToString(), HtmlBody, true, (_IsAttachment ? strAtt : new string[] { }), AppConfig.MailCC);

                return true;
            }
            //clsGeneral.SendMailMessage(AppConfig.MailFrom, EmailTo, string.Empty, string.Empty, "Sonic Automotive reports the following First Report of Loss", HtmlBody, true, strAtt);        
            else
                return false;
        }
        else
            return false;
    }

    /// <summary>
    /// Send First Report Email
    /// </summary>
    /// <param name="_IsAttachment"></param>
    private bool SendFirstReportMail(bool _IsAttachment)
    {
        PL_FR objPL_FR = new PL_FR(PK_PL_FR_ID);

        int intAttCount = 0;
        //Get Attachment Details
        DataTable dtAtt = PL_FR_Attachments.SelectByFR_ID(PK_PL_FR_ID).Tables[0];
        string[] strAtt = new string[dtAtt.Rows.Count];

        if (_IsAttachment)
        {
            if (dtAtt.Rows.Count > 0)
            {
                foreach (DataRow drAtt in dtAtt.Rows)
                {
                    string strFileName = drAtt["Attachment_Path"].ToString();
                    strFileName = AppConfig.PL_FRDocPath + strFileName;
                    strAtt[intAttCount] = strFileName;
                    intAttCount = intAttCount + 1;
                }
            }
        }
        //get recipient Id
        //DataTable dtRecipient = Email_Settings.SelectByModuleName("PL").Tables[0];
        DataTable dtRecipient = LU_Location.GetRecipientEmailID(objPL_FR.FK_LU_Location_ID, LU_Location.SonicReportType.PL).Tables[0];
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
            decimal FR_Number = new PL_FR(ReturnFRNumber.ToString() != string.Empty ? Convert.ToDecimal(ReturnFRNumber) : 0).PL_FR_Number;
            //generate FIle and store it on disk
            StreamWriter sWriter = null;
            clsGeneral.CreateDirectory(AppConfig.SitePath + "SONIC-Email/" + clsSession.FirstName + "_" + clsSession.LastName + "/PL_FR/" + DateTime.Today.ToString("MM-dd-yyyy"));
            string strName = AppConfig.SitePath + "SONIC-Email/" + clsSession.FirstName + "_" + clsSession.LastName + "/PL_FR/" + DateTime.Today.ToString("MM-dd-yyyy") + "/PL_FR_Email_" + FR_Number.ToString() + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
            string strAttachmentName = AppConfig.SitePath + "SONIC-Email/" + clsSession.FirstName + "_" + clsSession.LastName + "/PL_FR/" + DateTime.Today.ToString("MM-dd-yyyy") + "/PL_FR_Attachment_" + FR_Number.ToString() + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
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
            //Copying Attchment Files.
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

                if (_IsAttachment)
                    objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Sonic Automotive (acct #42979) reports the following First Report of Loss PL-" + FR_Number.ToString(), HtmlBody, true, finalAttachment, AppConfig.MailCC);
                else
                    objEmail.SendMailMessage(AppConfig.MailFrom, " ", EmailTo, "Sonic Automotive (acct #42979) reports the following First Report of Loss PL-" + FR_Number.ToString(), HtmlBody, true, new string[] { }, AppConfig.MailCC);

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
    /// Set all Validations-Location/Contact
    /// </summary>
    private void SetValidationsLocation()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(25).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        // Label MenuAsterisk1 = (Label)mnuPL.Controls[0].FindControl("MenuAsterisk");
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 25").Length > 0) ? "" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "When to Contact": strCtrlsIDs += txtContact_Best_Time.ClientID + ","; strMessages += "Please enter [Location/Contact]/When to Contact" + ","; Span1.Style["display"] = ""; break;
                case "Fax Number": strCtrlsIDs += txtContactFaxNumber.ClientID + ","; strMessages += "Please enter [Location/Contact]/Fax Number" + ","; Span2.Style["display"] = ""; break;
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
        DataTable dtFields = clsScreen_Validators.SelectByScreen(26).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        //Label MenuAsterisk2 = (Label)mnuPL.Controls[1].FindControl("MenuAsterisk");
        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 26").Length > 0) ? "" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Claimant State": strCtrlsIDsLossInfo += ddlClaimant_State.ClientID + ","; strMessagesLossInfo += "Please select [Loss Information]/Claimant State" + ","; Span3.Style["display"] = ""; break;
                case "Date of Loss": strCtrlsIDsLossInfo += txtDate_Of_Loss.ClientID + ","; strMessagesLossInfo += "Please enter [Loss Information]/Date of Loss" + ","; Span4.Style["display"] = ""; break;
                case "Time of Incident": strCtrlsIDsLossInfo += txtTime_Of_Loss.ClientID + ","; strMessagesLossInfo += "Please enter [Loss Information]/Time of Incident" + ","; Span5.Style["display"] = ""; break;
                case "Non-Sonic Loss Location": strCtrlsIDsLossInfo += txtNonSonic_Loss_Location.ClientID + ","; strMessagesLossInfo += "Please enter [Loss Information]/Non-Sonic Loss Location" + ","; Span7.Style["display"] = ""; break;
                case "Description of Loss": strCtrlsIDsLossInfo += txtDescription_Of_Loss.ClientID + ","; strMessagesLossInfo += "Please enter [Loss Information]/Description of Loss" + ","; Span8.Style["display"] = ""; break;
                case "Date Reported to Sonic": strCtrlsIDsLossInfo += txtDate_Reported_To_Sonic.ClientID + ","; strMessagesLossInfo += "Please enter [Loss Information]/Date Reported to Sonic" + ","; Span9.Style["display"] = ""; break;
                case "Weather Conditions": strCtrlsIDsLossInfo += txtWeather_Conditions.ClientID + ","; strMessagesLossInfo += "Please enter [Loss Information]/Weather Conditions" + ","; Span10.Style["display"] = ""; break;
                case "Road Conditions": strCtrlsIDsLossInfo += txtRoad_Conditions.ClientID + ","; strMessagesLossInfo += "Please enter [Loss Information]/Road Conditions" + ","; Span11.Style["display"] = ""; break;
                case "Loss Category": strCtrlsIDsLossInfo += txtLoss_Category.ClientID + ","; strMessagesLossInfo += "Please enter [Loss Information]/Loss Category" + ","; Span15.Style["display"] = ""; break;
                case "Police": strCtrlsIDsLossInfo += txtPolice_Organization.ClientID + ","; strMessagesLossInfo += "Please enter [Loss Information]/Police" + ","; Span12.Style["display"] = ""; break;
                case "Case Number": strCtrlsIDsLossInfo += txtCase_Number.ClientID + ","; strMessagesLossInfo += "Please enter [Loss Information]/Case Number" + ","; Span13.Style["display"] = ""; break;
                case "Station Phone Number ": strCtrlsIDsLossInfo += txtPolice_telephone.ClientID + ","; strMessagesLossInfo += "Please enter [Loss Information]/Station Phone Number " + ","; Span14.Style["display"] = ""; break;
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
    /// Set all Validations - Comment 
    /// </summary>
    private void SetValidationsComments()
    {
        string strCtrlsIDsComments = "";
        string strMessagesComments = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(27).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        //  Label MenuAsterisk3 = (Label)mnuPL.Controls[6].FindControl("MenuAsterisk");
        MenuAsterisk7.Style["display"] = (dtFields.Select("LeftMenuIndex = 27").Length > 0) ? "" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Comments": strCtrlsIDsComments += txtComments.ClientID + ","; strMessagesComments += "Please enter [Comments]/Comments" + ","; Span6.Style["display"] = ""; break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDsComments = strCtrlsIDsComments.TrimEnd(',');
        strMessagesComments = strMessagesComments.TrimEnd(',');

        hdnControlIDsComments.Value = strCtrlsIDsComments;
        hdnErrorMsgsComments.Value = strMessagesComments;
    }

    /// <summary>
    /// Set all Validations - Injury Information
    /// </summary>
    private void SetValidationsInjury()
    {
        string strCtrlsIDsInjury = "";
        string strMessagesInjury = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(138).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        //  Label MenuAsterisk4 = (Label)mnuPL.Controls[3].FindControl("MenuAsterisk");
        MenuAsterisk4.Style["display"] = (dtFields.Select("LeftMenuIndex = 138").Length > 0) ? "" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Injured Name ": strCtrlsIDsInjury += txtInjured_Name.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Injured Name " + ","; Span16.Style["display"] = ""; break;
                case "Gender": strCtrlsIDsInjury += txtInjured_Gender.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Gender" + ","; Span17.Style["display"] = ""; break;
                case "Address 1 ": strCtrlsIDsInjury += txtInjured_Address_1.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Address 1 " + ","; Span18.Style["display"] = ""; break;
                case "Work Telephone": strCtrlsIDsInjury += txtInjured_Work_Phone.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Work Telephone" + ","; Span19.Style["display"] = ""; break;
                case "Address 2": strCtrlsIDsInjury += txtInjured_Address_2.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Address 2" + ","; Span20.Style["display"] = ""; break;
                case "Home Telephone": strCtrlsIDsInjury += txtInjured_Home_Phone.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Home Telephone" + ","; Span21.Style["display"] = ""; break;
                case "City ": strCtrlsIDsInjury += txtInjured_City.ClientID + ","; strMessagesInjury += "Please enter [Injury]/City " + ","; Span22.Style["display"] = ""; break;
                case "Alternate Telephone": strCtrlsIDsInjury += txtInjured_Alternate_Telephone.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Alternate Telephone" + ","; Span23.Style["display"] = ""; break;
                case "State ": strCtrlsIDsInjury += ddlInjured_State.ClientID + ","; strMessagesInjury += "Please select [Injury]/State " + ","; Span24.Style["display"] = ""; break;
                case "Zip Code": strCtrlsIDsInjury += txtInjured_Zip_Code.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Zip Code" + ","; Span25.Style["display"] = ""; break;
                case "What was the Injured person doing when the loss occurred?": strCtrlsIDsInjury += txtWhat_Was_Injured_Doing.ClientID + ","; strMessagesInjury += "Please enter [Injury]/What was the Injured person doing when the loss occurred?" + ","; Span26.Style["display"] = ""; break;
                case "Description of Injury": strCtrlsIDsInjury += txtInjured_Injury_Description.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Description of Injury" + ","; Span27.Style["display"] = ""; break;
                case "Body Part Affected": strCtrlsIDsInjury += ddlbody_part.ClientID + ","; strMessagesInjury += "Please select [Injury]/Body Part Affected" + ","; Span28.Style["display"] = ""; break;
                case "Medical Treatment Provided ": strCtrlsIDsInjury += txtInjured_Medical_Treatment_Provided.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Medical Treatment Provided " + ","; Span29.Style["display"] = ""; break;
                case "Medical Facility Name": strCtrlsIDsInjury += txtInjured_Medical_Facility_Name.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Medical Facility Name" + ","; Span30.Style["display"] = ""; break;
                case "Date of Initial Treatment": strCtrlsIDsInjury += txtInjured_Date_of_Initial_Treatment.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Date of Initial Treatment" + ","; Span31.Style["display"] = ""; break;
                case "Medical Facility Type": strCtrlsIDsInjury += txtInjured_Medical_Facility_Type.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Medical Facility Type" + ","; Span32.Style["display"] = ""; break;
                case "Treating Physician’s Name ": strCtrlsIDsInjury += txtInjured_Physicians_Name.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Treating Physician’s Name " + ","; Span33.Style["display"] = ""; break;
                case "Medical Facility Address 1 ": strCtrlsIDsInjury += txtInjured_Medical_Facility_Address_1.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Medical Facility Address 1 " + ","; Span34.Style["display"] = ""; break;
                case "Medical Facility Address 2 ": strCtrlsIDsInjury += txtInjured_Medical_Facility_Address_2.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Medical Facility Address 2 " + ","; Span35.Style["display"] = ""; break;
                case "Medical Facility City": strCtrlsIDsInjury += txtInjured_Medical_Facility_City.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Medical Facility City" + ","; Span37.Style["display"] = ""; break;
                case "Medical Facility State": strCtrlsIDsInjury += ddlInjured_Medical_Facility_State.ClientID + ","; strMessagesInjury += "Please select [Injury]/Medical Facility State" + ","; Span38.Style["display"] = ""; break;
                case "Medical Facility Zip Code ": strCtrlsIDsInjury += txtInjured_Medical_Facility_Zip_Code.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Medical Facility Zip Code " + ","; Span39.Style["display"] = ""; break;
                case "Date Admitted": strCtrlsIDsInjury += txtInjured_Date_Admitted_to_Hospital.ClientID + ","; strMessagesInjury += "Please enter [Injury]/Date Admitted" + ","; Span36.Style["display"] = ""; break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDsInjury = strCtrlsIDsInjury.TrimEnd(',');
        strMessagesInjury = strMessagesInjury.TrimEnd(',');

        hdnControlIDsInjury.Value = strCtrlsIDsInjury;
        hdnErrorMsgsInjury.Value = strMessagesInjury;
    }

    /// <summary>
    /// Set all Validations - Product Information 
    /// </summary>
    private void SetValidationsProduct()
    {
        string strCtrlsIDsProduct = "";
        string strMessagesProduct = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(141).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        //  Label MenuAsterisk5 = (Label)mnuPL.Controls[2].FindControl("MenuAsterisk");
        MenuAsterisk3.Style["display"] = (dtFields.Select("LeftMenuIndex = 141").Length > 0) ? "" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Type of Product ": strCtrlsIDsProduct += txtType_of_Product.ClientID + ","; strMessagesProduct += "Please enter [Product] / Type of Product " + ","; Span40.Style["display"] = ""; break;
                case "Manufacturer Name": strCtrlsIDsProduct += txtManufacturer_Name.ClientID + ","; strMessagesProduct += "Please enter [Product] / Manufacturer Name" + ","; Span41.Style["display"] = ""; break;
                case "Address 1": strCtrlsIDsProduct += txtProduct_Address_1.ClientID + ","; strMessagesProduct += "Please enter [Product] / Address 1" + ","; Span42.Style["display"] = ""; break;
                case "Address 2 ": strCtrlsIDsProduct += txtProduct_Address_2.ClientID + ","; strMessagesProduct += "Please enter [Product] / Address 2 " + ","; Span43.Style["display"] = ""; break;
                case "City": strCtrlsIDsProduct += txtProduct_City.ClientID + ","; strMessagesProduct += "Please enter [Product] / City" + ","; Span44.Style["display"] = ""; break;
                case "State ": strCtrlsIDsProduct += ddlProduct_State.ClientID + ","; strMessagesProduct += "Please select [Product] / State " + ","; Span45.Style["display"] = ""; break;
                case "Zip Code": strCtrlsIDsProduct += txtProduct_Zip_Code.ClientID + ","; strMessagesProduct += "Please enter [Product] / Zip Code" + ","; Span46.Style["display"] = ""; break;
                case "Location where vehicle can be seen": strCtrlsIDsProduct += txtProduct_Location.ClientID + ","; strMessagesProduct += "Please enter [Product] / Location where vehicle can be seen" + ","; Span47.Style["display"] = ""; break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDsProduct = strCtrlsIDsProduct.TrimEnd(',');
        strMessagesProduct = strMessagesProduct.TrimEnd(',');

        hdnControlIDsProduct.Value = strCtrlsIDsProduct;
        hdnErrorMsgsProduct.Value = strMessagesProduct;
    }

    /// <summary>
    /// Set all Validations - Property Information 
    /// </summary>
    private void SetValidationsProperty()
    {
        string strCtrlsIDsProperty = "";
        string strMessagesProperty = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(139).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        //    Label MenuAsterisk6 = (Label)mnuPL.Controls[4].FindControl("MenuAsterisk");
        MenuAsterisk5.Style["display"] = (dtFields.Select("LeftMenuIndex = 139").Length > 0) ? "" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Property Description": strCtrlsIDsProperty += txtProperty_Description.ClientID + ","; strMessagesProperty += "Please enter [Property] / Property Description" + ","; Span48.Style["display"] = ""; break;
                case "Damage Description ": strCtrlsIDsProperty += txtProperty_Damage_Description.ClientID + ","; strMessagesProperty += "Please enter [Property] / Damage Description " + ","; Span49.Style["display"] = ""; break;
                case "Estimate Amount ": strCtrlsIDsProperty += txtEstimate_Amount.ClientID + ","; strMessagesProperty += "Please enter [Property] / Estimate Amount " + ","; Span50.Style["display"] = ""; break;
                case "Estimator Name": strCtrlsIDsProperty += txtProperty_Estimator_Name.ClientID + ","; strMessagesProperty += "Please enter [Property] / Estimator Name" + ","; Span51.Style["display"] = ""; break;
                case "Estimator Phone": strCtrlsIDsProperty += txtEstimator_Phone.ClientID + ","; strMessagesProperty += "Please enter [Property] / Estimator Phone" + ","; Span52.Style["display"] = ""; break;
                case "Business Name": strCtrlsIDsProperty += txtProperty_Business_Name.ClientID + ","; strMessagesProperty += "Please enter [Property] / Business Name" + ","; Span53.Style["display"] = ""; break;
                case "Owner Name": strCtrlsIDsProperty += txtOwner_Name.ClientID + ","; strMessagesProperty += "Please enter [Property] / Owner Name" + ","; Span54.Style["display"] = ""; break;
                case "Address 1": strCtrlsIDsProperty += txtProperty_Address_1.ClientID + ","; strMessagesProperty += "Please enter [Property] / Address 1" + ","; Span55.Style["display"] = ""; break;
                case "Work Telephone": strCtrlsIDsProperty += txtOwner_Work_Telephone.ClientID + ","; strMessagesProperty += "Please enter [Property] / Work Telephone" + ","; Span56.Style["display"] = ""; break;
                case "Address 2 ": strCtrlsIDsProperty += txtProperty_Address_2.ClientID + ","; strMessagesProperty += "Please enter [Property] / Address 2 " + ","; Span57.Style["display"] = ""; break;
                case "Home Telephone": strCtrlsIDsProperty += txtOwner_Home_Telephone.ClientID + ","; strMessagesProperty += "Please enter [Property] / Home Telephone" + ","; Span58.Style["display"] = ""; break;
                case "City ": strCtrlsIDsProperty += txtProperty_City.ClientID + ","; strMessagesProperty += "Please enter [Property] / City " + ","; Span59.Style["display"] = ""; break;
                case "Alternate Telephone": strCtrlsIDsProperty += txtOwner_Alternate_Telephone.ClientID + ","; strMessagesProperty += "Please enter [Property] / Alternate Telephone" + ","; Span60.Style["display"] = ""; break;
                case "State ": strCtrlsIDsProperty += ddlProperty_State.ClientID + ","; strMessagesProperty += "Please select [Property] / State " + ","; Span61.Style["display"] = ""; break;
                case "Zip Code ": strCtrlsIDsProperty += txtProperty_Zip_Code.ClientID + ","; strMessagesProperty += "Please enter [Property] / Zip Code " + ","; Span62.Style["display"] = ""; break;
                case "Location where property can be seen ": strCtrlsIDsProperty += txtLocation_where_property_can_be_seen.ClientID + ","; strMessagesProperty += "Please enter [Property] / Location where property can be seen " + ","; Span63.Style["display"] = ""; break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDsProperty = strCtrlsIDsProperty.TrimEnd(',');
        strMessagesProperty = strMessagesProperty.TrimEnd(',');

        hdnControlIDsProperty.Value = strCtrlsIDsProperty;
        hdnErrorMsgsProperty.Value = strMessagesProperty;
    }

    /// <summary>
    /// Set all Validations - Witness Information 
    /// </summary>
    private void SetValidationsWitness()
    {
        string strCtrlsIDsWitness = "";
        string strMessagesWitness = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(140).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        //Label MenuAsterisk7 = (Label)mnuPL.Controls[5].FindControl("MenuAsterisk");
        MenuAsterisk6.Style["display"] = (dtFields.Select("LeftMenuIndex = 140").Length > 0) ? "" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Name": strCtrlsIDsWitness += txtWitness_Name.ClientID + ","; strMessagesWitness += "Please enter [Witness] / Name" + ","; Span64.Style["display"] = ""; break;
                case "Address 1": strCtrlsIDsWitness += txtWitness_Address_1.ClientID + ","; strMessagesWitness += "Please enter [Witness] / Address 1" + ","; Span65.Style["display"] = ""; break;
                case "Home Telephone": strCtrlsIDsWitness += txtWitness_Home_Phone.ClientID + ","; strMessagesWitness += "Please enter [Witness] / Home Telephone" + ","; Span66.Style["display"] = ""; break;
                case "Address 2": strCtrlsIDsWitness += txtWitness_Address_2.ClientID + ","; strMessagesWitness += "Please enter [Witness] / Address 2" + ","; Span67.Style["display"] = ""; break;
                case "Work Telephone": strCtrlsIDsWitness += txtWitness_Work_Phone.ClientID + ","; strMessagesWitness += "Please enter [Witness] / Work Telephone" + ","; Span68.Style["display"] = ""; break;
                case "City": strCtrlsIDsWitness += txtWitness_City.ClientID + ","; strMessagesWitness += "Please enter [Witness] / City" + ","; Span69.Style["display"] = ""; break;
                case "Alternate Telephone": strCtrlsIDsWitness += txtWitness_Alternate_Phone.ClientID + ","; strMessagesWitness += "Please enter [Witness] / Alternate Telephone" + ","; Span70.Style["display"] = ""; break;
                case "State": strCtrlsIDsWitness += ddlWitness_State.ClientID + ","; strMessagesWitness += "Please select [Witness] / State" + ","; Span71.Style["display"] = ""; break;
                case "Zip": strCtrlsIDsWitness += txtWitness_Zip_Code.ClientID + ","; strMessagesWitness += "Please enter [Witness] / Zip" + ","; Span72.Style["display"] = ""; break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDsWitness = strCtrlsIDsWitness.TrimEnd(',');
        strMessagesWitness = strMessagesWitness.TrimEnd(',');

        hdnControlIDsWitness.Value = strCtrlsIDsWitness;
        hdnErrorMsgsWitness.Value = strMessagesWitness;
    }

    #endregion

    private void SendFROI()
    {
        clsFROI_Output objFROI = new clsFROI_Output();
        objFROI.FROI_Type = "PL";
        objFROI.FROI_Number = Convert.ToDecimal(((Label)SonicInfo.FindControl("lblFirstReportNumber")).Text.Trim().Replace("PL-", ""));
        objFROI.Insert();
    }
}
