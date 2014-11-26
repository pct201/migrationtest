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
using ERIMS.DAL;

/// <summary>
/// Date : 9-Oct-08
/// Developer Name : Ravi Patel
/// Modified By : Dhruti Desai On 12 Nov 2010
/// Description : This page is allow user to add-edit-delete Environmental data for particular location ID.
/// This page contains Equipment, Permit, Audit/Inspection, SPCC, Phase-I and EPA-Ids information
/// for Location ID which is passed in QueryString. If Location Id is not valid then it redirect
/// to Search page of Exposure Module.
/// </summary>
public partial class Exposures_Environmental : clsBasePage
{

    #region "Declaration"

    // Constant Value for Attachement User Control
    private const string ATTACHMENT_EQUIPMENT = "Equipment";
    private const string ATTACHMENT_PERMIT = "Permit";
    private const string ATTACHMENT_PHASE = "Phase";
    private const string ATTACHMENT_AUDIT = "Audit";
    private const string ATTACHMENT_PLAN = "Plan";

    #endregion

    #region " Property "

    /// <summary>
    /// Denote Location ID for Equipmental Data
    /// </summary>
    public int LocationID
    {
        //get { return (!clsGeneral.IsNull(Request.QueryString["loc"]) ? Convert.ToInt32(Request.QueryString["loc"]) : -1); }
        get { return Convert.ToInt32(ViewState["loc"]); }
        set { ViewState["loc"] = value; }
    }

    /// <summary>
    /// Denote Equipment ID for Edit
    /// </summary>
    public int EditEnviro_EquipmentID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditEnviro_EquipmentID"]) ? Convert.ToInt32(this.ViewState["EditEnviro_EquipmentID"]) : -1); }
        set { this.ViewState["EditEnviro_EquipmentID"] = value; }
    }

    /// <summary>
    /// Denote Equipement Recommendation ID for Edit
    /// </summary>
    public int EditEquipement_RecommendationID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["Equipement_RecommendationID"]) ? Convert.ToInt32(this.ViewState["Equipement_RecommendationID"]) : -1); }
        set { this.ViewState["Equipement_RecommendationID"] = value; }
    }

    /// <summary>
    /// Denote Permit ID for Edit
    /// </summary>
    public int EditPermitID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditPermitID"]) ? Convert.ToInt32(this.ViewState["EditPermitID"]) : -1); }
        set { this.ViewState["EditPermitID"] = value; }
    }

    /// <summary>
    /// Denote Permit Recommendation ID for Edit
    /// </summary>
    public int EditPermit_RecommendationID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditPermit_RecommendationID"]) ? Convert.ToInt32(this.ViewState["EditPermit_RecommendationID"]) : -1); }
        set { this.ViewState["EditPermit_RecommendationID"] = value; }
    }

    /// <summary>
    /// Denote Inspection-Audit ID for Edit
    /// </summary>
    public int EditAuditID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditAuditID"]) ? Convert.ToInt32(this.ViewState["EditAuditID"]) : -1); }
        set { this.ViewState["EditAuditID"] = value; }
    }

    /// <summary>
    /// Denote Inspection-Audit Recommendation ID for Edit
    /// </summary>
    public int EditAudit_RecommendationID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditAudit_RecommendationID"]) ? Convert.ToInt32(this.ViewState["EditAudit_RecommendationID"]) : -1); }
        set { this.ViewState["EditAudit_RecommendationID"] = value; }
    }

    /// <summary>
    /// Denote SPCC ID for Edit
    /// </summary>
    public int EditSPCCID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditSPCCID"]) ? Convert.ToInt32(this.ViewState["EditSPCCID"]) : -1); }
        set { this.ViewState["EditSPCCID"] = value; }
    }

    /// <summary>
    /// Denote SPCC Recommendation ID for Edit
    /// </summary>
    public int EditSPCC_RecommendationID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditSPCC_RecommendationID"]) ? Convert.ToInt32(this.ViewState["EditSPCC_RecommendationID"]) : -1); }
        set { this.ViewState["EditSPCC_RecommendationID"] = value; }
    }

    /// <summary>
    /// Denote Phase1 ID for Edit
    /// </summary>
    public int EditPhase1ID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditPhase1ID"]) ? Convert.ToInt32(this.ViewState["EditPhase1ID"]) : -1); }
        set { this.ViewState["EditPhase1ID"] = value; }
    }

    /// <summary>
    /// Denote Phase1 Recommendation ID for Edit
    /// </summary>
    public int EditPhase1_RecommendationID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditPhase1_RecommendationID"]) ? Convert.ToInt32(this.ViewState["EditPhase1_RecommendationID"]) : -1); }
        set { this.ViewState["EditPhase1_RecommendationID"] = value; }
    }

    /// <summary>
    /// Denote EPA ID for Edit
    /// </summary>
    public int EditEPAID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditEPAID"]) ? Convert.ToInt32(this.ViewState["EditEPAID"]) : -1); }
        set { this.ViewState["EditEPAID"] = value; }
    }

    /// <summary>
    /// check if current Location is Active or not
    /// </summary>
    public bool isEditable
    {
        get { return Convert.ToBoolean(ViewState["isEditable"]); }
        set { ViewState["isEditable"] = value; }
    }

    #endregion

    #region "Page Events"

    /// <summary>
    /// Event handled when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        // Set Tab selection
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Pollution);

        // Set file Upload event handler for Upload user Control
        EquipmentAttachment.btnHandler += new Controls_Attchment_Environment_Attachment.OnButtonClick(Upload_File);
        PermitAttachment.btnHandler += new Controls_Attchment_Environment_Attachment.OnButtonClick(Upload_File);
        AuditAttachment.btnHandler += new Controls_Attchment_Environment_Attachment.OnButtonClick(Upload_File);
        PlanAttachment.btnHandler += new Controls_Attchment_Environment_Attachment.OnButtonClick(Upload_File);
        PhaseAttachment.btnHandler += new Controls_Attchment_Environment_Attachment.OnButtonClick(Upload_File);

        // Set Client Side Event on equipment DropDown Change
        this.ddlEquiepmentType.Attributes.Add("onchange", "return ChangeEquipmentType();");

        if (!IsPostBack)
        {
            // Check wheter Request for page is Valid or not.
            CheckValidRequest();

            dsSiteMap.SiteMapProvider = "EX-EnvironmentalMenuProvider";
            Page.DataBind();
            trvMenu.Nodes[0].Expand();
                               


            // set UniqueControlID to validation group for Attachment Control
            EquipmentAttachment.UniqueControlID = ATTACHMENT_EQUIPMENT;
            PermitAttachment.UniqueControlID = ATTACHMENT_PERMIT;
            PhaseAttachment.UniqueControlID = ATTACHMENT_PHASE;
            AuditAttachment.UniqueControlID = ATTACHMENT_AUDIT;
            PlanAttachment.UniqueControlID = ATTACHMENT_PLAN;

            // set Location ID of header grid user control
            ucExposureInfo.PK_LU_Location = LocationID;
            ucExposureInfo.BindExposureInfo();

            // Fill all Grid in Summary Page
            FillEquipmentGrid();
            FillPermitGrid();
            FillAuditGrid();
            FillSPCCGrid();
            FillPhaseGrid();
            FillEPAIDGrid();

            this.EditEnviro_EquipmentID = -1;
            isEditable = new LU_Location(Convert.ToDecimal(LocationID)).Active == "Y";

            SetAddButton();
            // Set Number format Key Press Validation
            this.txtCapacity.Attributes.Add("onkeypress", "javascript:return FormatNumber(event,'" + this.txtCapacity.ClientID + "',11,false);");
            this.txtSingle_Event_Coverage.Attributes.Add("onkeypress", "javascript:return FormatNumber(event,'" + this.txtSingle_Event_Coverage.ClientID + "',11,true);");
            this.txtMultiple_Event_Total_Coverage.Attributes.Add("onkeypress", "javascript:return FormatNumber(event,'" + this.txtMultiple_Event_Total_Coverage.ClientID + "',11,true);");
            this.txtAudit_Cost.Attributes.Add("onkeypress", "javascript:return FormatNumber(event,'" + this.txtAudit_Cost.ClientID + "',18,false);");
            this.txtPlan_Cost.Attributes.Add("onkeypress", "javascript:return FormatNumber(event,'" + this.txtPlan_Cost.ClientID + "',18,false);");
            this.txtPhase_Cost.Attributes.Add("onkeypress", "javascript:return FormatNumber(event,'" + this.txtPhase_Cost.ClientID + "',18,false);");

            // Show Summary panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(0);getScrollHeight();", true);
            SetValidations();
        }

    }

    /// <summary>
    /// function use for set hide add link button when Lu_location is en-active.
    /// </summary>
    private void SetAddButton()
    {
        btnAddEquipment.Visible = isEditable;
        lbtAddPermits.Visible = isEditable;
        lbtAddPhase.Visible = isEditable;
        lbtAddSPCC.Visible = isEditable;
        lbtAuditsAdd.Visible = isEditable;
        lblEPAIDlAdd.Visible = isEditable;
    }

    #endregion

    #region " Events "

    /// <summary>
    /// Upload Attachment to server
    /// </summary>
    /// <param name="strValue">Unique ID</param>
    protected void Upload_File(string strValue)
    {

        // Check strValue with unique validation group name
        if (strValue == ATTACHMENT_EQUIPMENT)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);getScrollHeight();", true);

            // Check if Equipment Information is saved or not.
            // If EditEnviro_EquipmentID = -1 then Equipment Information is not save.
            if (EditEnviro_EquipmentID == -1)
            {
                clsGeneral.ShowAlert("Please Save Equipment Information first.", this.Page);
                return;
            }

            // Set Foreign_Table Name for attachment
            EquipmentAttachment.AttachmetnTable = clsGeneral.Exposure_Enviroment_Table.Enviro_Equipment;

            // Upload New file and save path in database
            EquipmentAttachment.Add(EditEnviro_EquipmentID);

            // Bind Attachment Detail Grid.
            EquipmentAttachmentDetail.Bind();
        }
        else if (strValue == ATTACHMENT_PERMIT)
        {
            // Collapse All other treeview node and expand Permit Node.
            trvMenu.CollapseAll();
            trvMenu.Nodes[2].Expand();

            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(6);getScrollHeight();", true);

            // If EditPermitID = -1 then Permit Information is not save.
            if (EditPermitID == -1)
            {
                clsGeneral.ShowAlert("Please Save Permit Information first.", this.Page);
                return;
            }

            // Set Foreign_Table Name for attachment
            PermitAttachment.AttachmetnTable = clsGeneral.Exposure_Enviroment_Table.Enviro_Permit;

            // Upload New file and save path in database
            PermitAttachment.Add(EditPermitID);

            // Bind Attachment Detail Grid.
            PermitAttachmentDetails.Bind();
        }
        else if (strValue == ATTACHMENT_AUDIT)
        {
            // Collapse All other treeview node and expand Audit/Inspection Node.
            trvMenu.CollapseAll();
            trvMenu.Nodes[3].ExpandAll();

            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(9);getScrollHeight();", true);

            // Check If EditAuditID = -1 then Audit/Inspection Information is not save.
            if (EditAuditID == -1)
            {
                clsGeneral.ShowAlert("Please Save Audit/Inspection Information first.", this.Page);
                return;
            }

            // Set Foreign_Table Name for attachment
            AuditAttachment.AttachmetnTable = clsGeneral.Exposure_Enviroment_Table.Enviro_Inspection;

            // Upload New file and save path in database
            AuditAttachment.Add(EditAuditID);

            // Bind Attachment Detail Grid.
            AuditAttachmentDetails.Bind();
        }
        else if (strValue == ATTACHMENT_PLAN)
        {
            // Collapse All other treeview node and expand SPCC Node.
            trvMenu.CollapseAll();
            trvMenu.Nodes[4].ExpandAll();

            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(12);getScrollHeight();", true);

            // Check If EditSPCCID = -1 then SPCC Information is not save.
            if (EditSPCCID == -1)
            {
                clsGeneral.ShowAlert("Please Save SPCC Information first.", this.Page);
                return;
            }

            // Set Foreign_Table Name for attachment
            PlanAttachment.AttachmetnTable = clsGeneral.Exposure_Enviroment_Table.Enviro_SPCC;

            // Upload New file and save path in database
            PlanAttachment.Add(EditSPCCID);

            // Bind Attachment Detail Grid.
            PlanAttachmentDetails.Bind();
        }
        else if (strValue == ATTACHMENT_PHASE)
        {
            // Collapse All other treeview node and expand Phase Node.
            trvMenu.CollapseAll();
            trvMenu.Nodes[5].ExpandAll();

            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(15);getScrollHeight();", true);

            // Check If EditPhase1ID = -1 then PhaseI Information is not save.
            if (EditPhase1ID == -1)
            {
                clsGeneral.ShowAlert("Please Save Phase I Information first.", this.Page);
                return;
            }

            // Set Foreign_Table Name for attachment
            PhaseAttachment.AttachmetnTable = clsGeneral.Exposure_Enviroment_Table.Enviro_Phase1;

            // Upload New file and save path in database
            PhaseAttachment.Add(EditPhase1ID);

            // Bind Attachment Detail Grid.
            PhaseAttachmentDetails.Bind();
        }
    }

    #endregion

    #region " Save Events "

    /// <summary>
    /// Save Equipment Information into Database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEquipmentSaveView_Click(object sender, EventArgs e)
    {
        Enviro_Equipment objEquiepment = new Enviro_Equipment();

        // Check if add record when location is In active
        if (EditEnviro_EquipmentID <= 0 && !isEditable)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(1);", true);
            clsGeneral.ShowAlert("Location for this Record is In Active. So can not add new Record.", this);
            return;
        }

        // Set Equiepment Field value
        objEquiepment.FK_LU_Location_ID = LocationID;
        objEquiepment.Identification = this.txtIdentification.Text.Trim();
        objEquiepment.type = this.ddlEquiepmentType.SelectedValue.ToString().Trim();
        objEquiepment.Leak_Detection_Type = txtLeak_Detection_Type.Text.Trim();
        objEquiepment.Insurer = this.txtInsurer.Text.Trim();

        // Check if Singe event Coverage is enter then assign value else Null
        if (this.txtSingle_Event_Coverage.Text.Trim() != "")
            objEquiepment.Single_Event_Coverage = Convert.ToDecimal(this.txtSingle_Event_Coverage.Text.Trim());

        // Check if multiple event Coverage is enter then assign value else Null
        if (this.txtMultiple_Event_Total_Coverage.Text.Trim() != "")
            objEquiepment.Multiple_Event_Total_Coverage = Convert.ToDecimal(txtMultiple_Event_Total_Coverage.Text.Trim());

        objEquiepment.Coverage_Start_Date = clsGeneral.FormatNullDateToStore(txtCoverage_Start_Date.Text.Trim());
        objEquiepment.Coverage_End_Date = clsGeneral.FormatNullDateToStore(txtCoverage_End_Date.Text.Trim());
        objEquiepment.Installation_Date = clsGeneral.FormatNullDateToStore(this.txtInstallation_Date.Text.Trim());
        objEquiepment.Removal_Date = clsGeneral.FormatNullDateToStore(this.txtRemoval_Date.Text.Trim());
        objEquiepment.Closure_Date = clsGeneral.FormatNullDateToStore(this.txtClosure_Date.Text);
        objEquiepment.Last_Inspection_Date = clsGeneral.FormatNullDateToStore(this.txtLast_Inspection_Date.Text);
        objEquiepment.Next_Inspection_Date = clsGeneral.FormatNullDateToStore(this.txtNext_Inspection_Date.Text);
        objEquiepment.Insurance_Company = this.txtInspection_Company.Text.Trim();
        objEquiepment.Inspection_Contact = this.txtInspection_Contact.Text.Trim();
        objEquiepment.Inspection_Phone = this.txtInspection_Phone.Text.Trim();
        objEquiepment.Last_Inspection_Date = clsGeneral.FormatNullDateToStore(this.txtLast_Inspection_Date.Text);
        objEquiepment.Next_Inspection_Date = clsGeneral.FormatNullDateToStore(this.txtNext_Inspection_Date.Text);
        objEquiepment.Registration_Number = this.txtRegistration_Number.Text.Trim();
        objEquiepment.Certificate_Number = this.txtCertificate_Number.Text.Trim();
        objEquiepment.Permit_Begin_Date = clsGeneral.FormatNullDateToStore(this.txtPermit_Begin_Date.Text.Trim());
        objEquiepment.Permit_End_Date = clsGeneral.FormatNullDateToStore(this.txtPermit_End_Date.Text.Trim());
        objEquiepment.Overfill_Protection = clsGeneral.FormatYesNoToStore(rdoOverfill_Protection);
        objEquiepment.Leak_Detection = clsGeneral.FormatYesNoToStore(rdoLeak_Detection);
        objEquiepment.Registration_Required = clsGeneral.FormatYesNoToStore(rdoRegistration_Required);
        objEquiepment.Other_Req = clsGeneral.FormatYesNoToStore(rdoOther_Req);
        objEquiepment.Other_Req_Descr = this.txtOther_Req_Descr.Text.Trim();
        objEquiepment.Next_Report_Date = clsGeneral.FormatNullDateToStore(this.txtNext_Report_Date.Text.Trim());
        objEquiepment.Notes = this.txtNotes.Text.Trim();
        objEquiepment.Update_Date = DateTime.Now;
        objEquiepment.Updated_By = clsSession.UserID;

        // Check Equipment Type and Save Fields Record as per Equipment Type
        if (this.ddlEquiepmentType.SelectedIndex == 1 || this.ddlEquiepmentType.SelectedIndex == 2)
        {
            objEquiepment.Contents = this.ddlContents.SelectedItem.Value.ToString();
            objEquiepment.Contents_Other = this.txtConents_Other.Text.ToString();
            objEquiepment.status = this.ddlStatus.SelectedItem.Value.ToString();
            objEquiepment.Material = this.ddlMaterial.SelectedItem.Value.ToString();
            objEquiepment.Material_Other = this.txtMaterial_Other.Text.Trim();
            objEquiepment.Construction = this.ddlConstruction.SelectedItem.Value.ToString();
            objEquiepment.Construction_Other = this.txtConstructionOther.Text.Trim();
            objEquiepment.Release_Equipment_Description = this.txtRelease_Equipment_Description.Text.Trim();
            objEquiepment.Release_Equipment_Present = clsGeneral.FormatYesNoToStore(rdoRelease_Equipment_Present);

            // Check if capacity is enter then assign value else Null
            if (this.txtCapacity.Text.Trim() != "")
                objEquiepment.Capacity = Convert.ToDecimal(this.txtCapacity.Text.Trim());

            tblTypeInfo.Style["display"] = "block";
            tblOilWater.Style["display"] = "none";
        }
        else if (this.ddlEquiepmentType.SelectedIndex == 3)
        {
            objEquiepment.Flows_to_POTW = clsGeneral.FormatYesNoToStore(rdoFlows_to_POTW);
            objEquiepment.TCLP_on_File = clsGeneral.FormatYesNoToStore(this.rdoTCLP_on_File);
            objEquiepment.Date_of_Last_Service = clsGeneral.FormatNullDateToStore(this.txtDate_of_Last_Service.Text.Trim());
            objEquiepment.Date_of_Last_TCLP = clsGeneral.FormatNullDateToStore(this.txtDate_of_Last_TCLP.Text.Trim());

            tblOilWater.Style["display"] = "block";
            tblTypeInfo.Style["display"] = "none";
        }
        else
        {
            tblOilWater.Style["display"] = "none";
            tblTypeInfo.Style["display"] = "none";
        }

        // Check EditEnviro_EquipmentID If -1 then insert new record Else update record
        if (EditEnviro_EquipmentID == -1)
        {
            EditEnviro_EquipmentID = objEquiepment.Insert();
            // initalize Attachment Detail user control
            EquipmentAttachmentDetail.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Equipment, EditEnviro_EquipmentID, true, 3);
            EquipmentAttachmentDetail.Bind();
        }
        else
        {
            objEquiepment.PK_Enviro_Equipment_ID = EditEnviro_EquipmentID;
            objEquiepment.Update();
        }

        // Fill Equipment Grid
        FillEquipmentGrid();

        // show Audit Popup
        btnEquipmentAuditView.Visible = true;
        btnEquipmentAuditView.Attributes.Add("onclick", "javascript:return AuditPopUp(" + EditEnviro_EquipmentID.ToString() + ")");
        btnInadvertentAuditView.Visible = true;
        btnInadvertentAuditView.Attributes.Add("onclick", "javascript:return AuditPopUp(" + EditEnviro_EquipmentID.ToString() + ")");


        // Show Next Panel
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(2);", true);

        clsGeneral.DisposeOf(objEquiepment);
    }

    /// <summary>
    /// Save Inadvertent Release information into database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInadvertentSaveView_Click(object sender, EventArgs e)
    {
        // Check if user Equipment Information saved is or not.
        if (EditEnviro_EquipmentID == -1)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(2);", true);
            clsGeneral.ShowAlert("Please Save Equipment Information first.", this.Page);
            return;
        }

        Enviro_Equipment objPlanEquipment;
        objPlanEquipment = new Enviro_Equipment();

        // Assign Fields Value
        objPlanEquipment.PK_Enviro_Equipment_ID = EditEnviro_EquipmentID;
        objPlanEquipment.Plan_ID = this.txtPlan_ID.Text.Trim();
        objPlanEquipment.Plan_Effective_Date = clsGeneral.FormatNullDateToStore(this.txtPlan_Effective_Date.Text.Trim());
        objPlanEquipment.Plan_Expiration_Date = clsGeneral.FormatNullDateToStore(this.txtPlan_Expiration_Date.Text.Trim());
        objPlanEquipment.Plan_Revision_Date = clsGeneral.FormatNullDateToStore(this.txtPlan_Revision_Date.Text.Trim());
        objPlanEquipment.Plan_Vendor = this.txtPlan_Vendor.Text.Trim();
        objPlanEquipment.Plan_Vendor_Contact = this.txtPlan_Vendor_Contact.Text.Trim();
        objPlanEquipment.Plan_Phone = this.txtPlan_Phone.Text.Trim();

        // Update only Plan Identification Information
        objPlanEquipment.UpdatePlanIdentification();

        // Show Next Panel
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(3);", true);

        clsGeneral.DisposeOf(objPlanEquipment);
    }

    /// <summary>
    /// Save Equipment Recommendation into databse
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRecommendationSave_Click(object sender, EventArgs e)
    {

        // Check if recommendation is in Add or edit mode.
        if (this.pnlAddEquipmentRecommendation.Visible == true)
        {
            // Check if Equipment Information is saved or not.
            if (EditEnviro_EquipmentID == -1)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);getScrollHeight();", true);
                clsGeneral.ShowAlert("Please Save Equipment Information first.", this.Page);
                return;
            }

            Enviro_Recommendations objRecommedetaion = new Enviro_Recommendations();

            objRecommedetaion.Foreign_Table = clsGeneral.Exposure_Enviroment_Table.Enviro_Equipment.ToString();
            objRecommedetaion.Foreign_Key = EditEnviro_EquipmentID;
            objRecommedetaion.PK_Enviro_Equipment_Recommendations_ID = EditEquipement_RecommendationID;
            objRecommedetaion.Date = clsGeneral.FormatNullDateToStore(this.txtIndivial_Recommendation_Date.Text.Trim());
            objRecommedetaion.Number = this.txtIndivial_Recommendation_Number.Text.Trim();
            objRecommedetaion.Made_by = this.txtIndivial_Recommendation_Made_by.Text.Trim();
            objRecommedetaion.status = this.ddlIndivial_Recommendation_status.SelectedItem.Value.Trim();
            objRecommedetaion.title = this.txtIndivial_Recommendation_Title.Text.Trim();
            objRecommedetaion.description = this.txtIndivial_Recommendation_description.Text.Trim();
            objRecommedetaion.Assigned_to = this.txtIndivial_Recommendation_Assigned_to.Text.Trim();
            objRecommedetaion.Due_date = clsGeneral.FormatNullDateToStore(this.txtIndivial_Recommendation_Due_date.Text.Trim());
            objRecommedetaion.Assigned_to_phone = this.txtIndivial_Recommendation_Assigned_to_phone.Text.Trim();
            objRecommedetaion.Assigned_to_email = this.txtIndivial_Recommendation_Assigned_to_email.Text.Trim();
            objRecommedetaion.Estimated_Cost = clsGeneral.GetDecimalValue(this.txtEstimatedCost);
            objRecommedetaion.Final_Cost = clsGeneral.GetDecimalValue(this.txtFinalCost);
            objRecommedetaion.resolution = this.txtIndivial_Recommendation_Resolution.Text.Trim();
            objRecommedetaion.Date_closed = clsGeneral.FormatNullDateToStore(this.txtIndivial_Recommendation_Date_Closed.Text.Trim());
            objRecommedetaion.Update_Date = System.DateTime.Today;
            objRecommedetaion.Updated_By = clsSession.UserID;

            // Check Edit existing record or Add New record.
            // if edit index is -1 then add new record So Insert Record else edit existing record SO Update Record
            if (EditEquipement_RecommendationID == -1)
            {
                objRecommedetaion.Insert();
            }
            else
            {
                objRecommedetaion.Update();
            }

            // Hide Recommendation Panel and Return button
            this.pnlAddEquipmentRecommendation.Visible = false;
            this.btnEquipmentRevert.Visible = false;
            this.btnRecommendationAudit.Visible = false;
            this.btnRecommendationSave.Text = "View";

            clsGeneral.DisposeOf(objRecommedetaion);
        }

        Response.Redirect("~/SONIC/Exposures/ViewEnvironmental.aspx?loc=" + Request.QueryString["loc"], true);

    }

    /// <summary>
    /// Save Permit Information into Database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPermit_Save_Click(object sender, EventArgs e)
    {
        Enviro_Permit objPermit = new Enviro_Permit();

        // Check if add record when location is In active
        if (EditPermitID <= 0 && !isEditable)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(5);", true);
            clsGeneral.ShowAlert("Location for this Record is In Active. So can not add new Record.", this);
            return;
        }

        // Set Permit Field value
        objPermit.PK_Enviro_Permit_ID = EditPermitID;
        objPermit.FK_LU_Location_ID = LocationID;
        objPermit.type = this.txtPermit_Type.Text.Trim();
        objPermit.Application_number = this.txtPermit_Application_number.Text.Trim();
        objPermit.Certificate_number = this.txtPermit_Certificate_number.Text.Trim();
        objPermit.Filing_date = clsGeneral.FormatNullDateToStore(this.txtPermit_Filing_date.Text.Trim());
        objPermit.Begin_date = clsGeneral.FormatNullDateToStore(this.txtPermit_Permit_Begin_date.Text.Trim());
        objPermit.End_date = clsGeneral.FormatNullDateToStore(this.txtPermit_Permit_End_Date.Text.Trim());
        objPermit.Last_Inspection_date = clsGeneral.FormatNullDateToStore(this.txtPermit_Last_Inspection_date.Text.Trim());
        objPermit.Next_Inspection_Date = clsGeneral.FormatNullDateToStore(this.txtPermit_Next_Inspection_Date.Text.Trim());
        objPermit.Next_Report_Date = clsGeneral.FormatNullDateToStore(this.txtPermit_Next_Report_Date.Text.Trim());
        objPermit.Notes = this.txtPermit_Notes.Text.Trim();
        objPermit.required = clsGeneral.FormatYesNoToStore(rdoPermit_required);

        // Check EditPermitID If -1 then insert new record Else update record
        if (EditPermitID == -1)
        {
            EditPermitID = objPermit.Insert();

            // initalize Attachment Detail user control
            PermitAttachmentDetails.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Permit, EditPermitID, true, 6);
            PermitAttachmentDetails.Bind();
        }
        else
        {
            objPermit.Update();
        }

        // Fill Permit Grid
        FillPermitGrid();

        // show Audit Popup
        btnPermitAudit.Visible = true;
        btnPermitAudit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Permits.aspx?id=" + EditPermitID.ToString() + "');");

        // Show Next Panel
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(6);", true);

        clsGeneral.DisposeOf(objPermit);

    }

    /// <summary>
    /// Save Permit Recommendation into databse
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPermit_RecommendationSave_Click(object sender, EventArgs e)
    {
        // Check if Permi Recommendation is in Add/Edit Mode or Not.
        if (pnlPermitIndRecommendation.Visible == true)
        {
            // Check if Permit Information is saved or not.
            if (EditPermitID == -1)
            {
                trvMenu.Nodes[2].ExpandAll();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(7);getScrollHeight();", true);
                clsGeneral.ShowAlert("Please Save Permit Information first.", this.Page);
                return;
            }

            Enviro_Recommendations objRecommedetaion = new Enviro_Recommendations();

            objRecommedetaion.Foreign_Table = clsGeneral.Exposure_Enviroment_Table.Enviro_Permit.ToString();
            objRecommedetaion.Foreign_Key = EditPermitID;
            objRecommedetaion.PK_Enviro_Equipment_Recommendations_ID = EditPermit_RecommendationID;
            objRecommedetaion.Date = clsGeneral.FormatNullDateToStore(this.txtPermit_Indivial_Recommendation_Date.Text.Trim());
            objRecommedetaion.Number = this.txtPermit_Indivial_Recommendation_Number.Text.Trim();
            objRecommedetaion.Made_by = this.txtPermit_Indivial_Recommendation_Made_by.Text.Trim();
            objRecommedetaion.status = this.ddlPermit_Indivial_Recommendation_status.SelectedItem.Value.Trim();
            objRecommedetaion.title = this.txtPermit_Indivial_Recommendation_Title.Text.Trim();
            objRecommedetaion.description = this.txtPermit_Indivial_Recommendation_description.Text.Trim();
            objRecommedetaion.Assigned_to = this.txtPermit_Indivial_Recommendation_Assigned_to.Text.Trim();
            objRecommedetaion.Due_date = clsGeneral.FormatNullDateToStore(this.txtPermit_Indivial_Recommendation_Due_date.Text.Trim());
            objRecommedetaion.Assigned_to_phone = this.txtPermit_Indivial_Recommendation_Assigned_to_phone.Text.Trim();
            objRecommedetaion.Assigned_to_email = this.txtPermit_Indivial_Recommendation_Assigned_to_email.Text.Trim();
            objRecommedetaion.Estimated_Cost = clsGeneral.GetDecimalValue(this.txtPermitEstimetedCost);
            objRecommedetaion.Final_Cost = clsGeneral.GetDecimalValue(this.txtPermitFinalCost);
            objRecommedetaion.resolution = this.txtPermit_Indivial_Recommendation_Resolution.Text.Trim();
            objRecommedetaion.Date_closed = clsGeneral.FormatNullDateToStore(this.txtPermit_Indivial_Recommendation_Date_Closed.Text.Trim());

            // Check Edit existing record or Add New record.
            // if edit index is -1 then add new record else edit existing record
            if (EditPermit_RecommendationID == -1)
            {
                objRecommedetaion.Insert();
            }
            else
            {
                objRecommedetaion.Update();
            }

            // Hide Recommendation Panel and Return button
            this.pnlPermitIndRecommendation.Visible = false;
            this.btnPermitRecommendationRevort.Visible = false;
            this.btnPermit_RecommendationAudit.Visible = false;
            this.btnPermit_RecommendationSave.Text = "View";

            clsGeneral.DisposeOf(objRecommedetaion);
        }

        Response.Redirect("~/SONIC/Exposures/ViewEnvironmental.aspx?loc=" + Request.QueryString["loc"], true);

    }

    /// <summary>
    /// Save Audit/Inspection Information into Database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAudit_Save_Click(object sender, EventArgs e)
    {
        Enviro_Inspection objAudit = new Enviro_Inspection();

        // Check if add record when location is In active
        if (EditAuditID <= 0 && !isEditable)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(8);", true);
            clsGeneral.ShowAlert("Location for this Record is In Active. So can not add new Record.", this);
            return;
        }

        // Set Audit/Inspection Fields
        objAudit.PK_Enviro_Inspection_ID = EditAuditID;
        objAudit.FK_LU_Location_ID = LocationID;
        objAudit.Frequency = this.txtAudit_Frequency.Text.Trim();
        objAudit.Last_Date = clsGeneral.FormatNullDateToStore(this.txtAudit_Last_Date.Text.Trim());
        objAudit.Next_Date = clsGeneral.FormatNullDateToStore(this.txtAudit_Next_Date.Text.Trim());
        objAudit.Next_Report_Date = clsGeneral.FormatNullDateToStore(this.txtAudits_Next_Report_Date.Text.Trim());
        objAudit.Notes = this.txtAudit_Notes.Text.Trim();

        if (this.txtAudit_Cost.Text.Trim() != "")
            objAudit.Cost = Convert.ToDecimal(this.txtAudit_Cost.Text.Trim());

        // Check EditAuditID If -1 then insert new record Else update record
        if (EditAuditID == -1)
        {
            EditAuditID = objAudit.Insert();

            // initalize Attachment Detail user control
            AuditAttachmentDetails.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Inspection, EditAuditID, true, 9);
            AuditAttachmentDetails.Bind();
        }
        else
        {
            objAudit.Update();
        }

        // Fill Audit Grid
        FillAuditGrid();

        // show Audit Popup
        btnInspection_Audit.Visible = true;
        btnInspection_Audit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Inspections.aspx?id=" + EditAuditID.ToString() + "');");

        // Show next Panel
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(9);", true);

        clsGeneral.DisposeOf(objAudit);
    }

    /// <summary>
    /// Save Audit Recommendation into databse
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAudit_RecommendationSave_Click(object sender, EventArgs e)
    {
        // Check if Audit recommendation is in Add or edit mode.
        if (pnlAuditIndRecommendations.Visible == true)
        {
            // Check if Audit Information is saved or not.
            if (EditAuditID == -1)
            {
                trvMenu.Nodes[3].ExpandAll();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(10);getScrollHeight();", true);
                clsGeneral.ShowAlert("Please Save Audit Information first.", this.Page);
                return;
            }

            Enviro_Recommendations objRecommedetaion = new Enviro_Recommendations();

            objRecommedetaion.Foreign_Table = clsGeneral.Exposure_Enviroment_Table.Enviro_Inspection.ToString();
            objRecommedetaion.Foreign_Key = EditAuditID;
            objRecommedetaion.PK_Enviro_Equipment_Recommendations_ID = EditAudit_RecommendationID;
            objRecommedetaion.Date = clsGeneral.FormatNullDateToStore(this.txtAudit_Indivial_Recommendation_Date.Text.Trim());
            objRecommedetaion.Number = this.txtAudit_Indivial_Recommendation_Number.Text.Trim();
            objRecommedetaion.Made_by = this.txtAudit_Indivial_Recommendation_Made_by.Text.Trim();
            objRecommedetaion.status = this.ddlAudit_Indivial_Recommendation_status.SelectedItem.Value.Trim();
            objRecommedetaion.title = this.txtAudit_Indivial_Recommendation_Title.Text.Trim();
            objRecommedetaion.description = this.txtAudit_Indivial_Recommendation_description.Text.Trim();
            objRecommedetaion.Assigned_to = this.txtAudit_Indivial_Recommendation_Assigned_to.Text.Trim();
            objRecommedetaion.Due_date = clsGeneral.FormatNullDateToStore(this.txtAudit_Indivial_Recommendation_Due_date.Text.Trim());
            objRecommedetaion.Assigned_to_phone = this.txtAudit_Indivial_Recommendation_Assigned_to_phone.Text.Trim();
            objRecommedetaion.Assigned_to_email = this.txtAudit_Indivial_Recommendation_Assigned_to_email.Text.Trim();
            objRecommedetaion.Estimated_Cost = clsGeneral.GetDecimalValue(this.txtAuditEstimetedCost);
            objRecommedetaion.Final_Cost = clsGeneral.GetDecimalValue(this.txtAuditFinalCost);
            objRecommedetaion.resolution = this.txtAudit_Indivial_Recommendation_Resolution.Text.Trim();
            objRecommedetaion.Date_closed = clsGeneral.FormatNullDateToStore(this.txtAudit_Indivial_Recommendation_Date_Closed.Text.Trim());

            // Check Edit existing record or Add New record.
            // if edit index is -1 then add new record else edit existing record
            if (EditAudit_RecommendationID == -1)
            {
                objRecommedetaion.Insert();
            }
            else
            {
                objRecommedetaion.Update();
            }

            // Hide Recommendation Panel and Return button
            this.pnlAuditIndRecommendations.Visible = false;
            this.btnAuditRecommendationRevort.Visible = false;
            this.btnAudit_RecommendationAudit.Visible = false;
            this.btnAudit_RecommendationSave.Text = "View";

            clsGeneral.DisposeOf(objRecommedetaion);
        }

        Response.Redirect("~/SONIC/Exposures/ViewEnvironmental.aspx?loc=" + Request.QueryString["loc"], true);

    }

    /// <summary>
    /// Save SPCC/Plan Information into Database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPlan_Save_Click(object sender, EventArgs e)
    {
        Enviro_SPCC objSPCC = new Enviro_SPCC();

        // Check if add record when location is In active.
        if (EditSPCCID <= 0 && !isEditable)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(11);", true);
            clsGeneral.ShowAlert("Location for this Record is In Active. So can not add new Record.", this);
            return;
        }

        // Set SPCC Fields
        objSPCC.PK_Enviro_SPCC_ID = EditSPCCID;
        objSPCC.FK_LU_Location_ID = LocationID;
        objSPCC.Plan_Preparer = this.txtPreparer.Text.ToString();
        objSPCC.Last_Date = clsGeneral.FormatNullDateToStore(this.txtPlan_date.Text.Trim());
        objSPCC.Next_Date = clsGeneral.FormatNullDateToStore(this.txtPlan_Next_Date.Text.Trim());
        objSPCC.Next_Report_Date = clsGeneral.FormatNullDateToStore(this.txtPlan_Next_Report_Date.Text.Trim());
        objSPCC.Phone = this.txtphone.Text.Trim();
        objSPCC.Notes = this.txtPlan_Notes.Text.Trim();

        if (this.txtPlan_Cost.Text.Trim() != "")
            objSPCC.Cost = Convert.ToDecimal(this.txtPlan_Cost.Text.Trim());

        // Check EditSPCCID If -1 then insert new record Else update record
        if (EditSPCCID == -1)
        {
            EditSPCCID = objSPCC.Insert();

            // initalize Attachment Detail user control
            PlanAttachmentDetails.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_SPCC, EditSPCCID, true, 12);
            PlanAttachmentDetails.Bind();
        }
        else
        {
            objSPCC.Update();
        }

        // Fill SPCC Grid
        FillSPCCGrid();

        this.btnPlan_Audit.Visible = true;
        this.btnPlan_Audit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_SPCC.aspx?id=" + EditSPCCID.ToString() + "');");
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(12);", true);

        clsGeneral.DisposeOf(objSPCC);
    }

    /// <summary>
    /// Save SPCC/Plan Recommendation into databse
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPlan_RecommendationSave_Click(object sender, EventArgs e)
    {

        // Check if SPCC Recommendation is in Add or edit mode.
        if (pnlSPCCIndRecommendation.Visible == true)
        {
            // Check if SPCC Information is saved or not.
            if (EditSPCCID == -1)
            {
                trvMenu.Nodes[4].ExpandAll();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(13);getScrollHeight();", true);
                clsGeneral.ShowAlert("Please Save SPCC Information first.", this.Page);
                return;
            }

            Enviro_Recommendations objRecommedetaion = new Enviro_Recommendations();

            objRecommedetaion.Foreign_Table = clsGeneral.Exposure_Enviroment_Table.Enviro_SPCC.ToString();
            objRecommedetaion.Foreign_Key = EditSPCCID;
            objRecommedetaion.PK_Enviro_Equipment_Recommendations_ID = EditSPCC_RecommendationID;
            objRecommedetaion.Date = clsGeneral.FormatNullDateToStore(this.txtPlan_Indivial_Recommendation_Date.Text.Trim());
            objRecommedetaion.Number = this.txtPlan_Indivial_Recommendation_Number.Text.Trim();
            objRecommedetaion.Made_by = this.txtPlan_Indivial_Recommendation_Made_by.Text.Trim();
            objRecommedetaion.status = this.ddlPlan_Indivial_Recommendation_status.SelectedItem.Value.Trim();
            objRecommedetaion.title = this.txtPlan_Indivial_Recommendation_Title.Text.Trim();
            objRecommedetaion.description = this.txtPlan_Indivial_Recommendation_description.Text.Trim();
            objRecommedetaion.Assigned_to = this.txtPlan_Indivial_Recommendation_Assigned_to.Text.Trim();
            objRecommedetaion.Due_date = clsGeneral.FormatNullDateToStore(this.txtPlan_Indivial_Recommendation_Due_date.Text.Trim());
            objRecommedetaion.Assigned_to_phone = this.txtPlan_Indivial_Recommendation_Assigned_to_phone.Text.Trim();
            objRecommedetaion.Assigned_to_email = this.txtPlan_Indivial_Recommendation_Assigned_to_email.Text.Trim();
            objRecommedetaion.Estimated_Cost = clsGeneral.GetDecimalValue(this.txtSPCEstimatedCost);
            objRecommedetaion.Final_Cost = clsGeneral.GetDecimalValue(this.txtSPCFinalCost);
            objRecommedetaion.resolution = this.txtPlan_Indivial_Recommendation_Resolution.Text.Trim();
            objRecommedetaion.Date_closed = clsGeneral.FormatNullDateToStore(this.txtPlan_Indivial_Recommendation_Date_Closed.Text.Trim());

            // Check Edit existing record or Add New record.
            // if edit index is -1 then add new record else edit existing record
            if (EditSPCC_RecommendationID == -1)
            {
                objRecommedetaion.Insert();
            }
            else
            {
                objRecommedetaion.Update();
            }

            // Hide Recommendation Panel and Return button
            this.pnlSPCCIndRecommendation.Visible = false;
            this.btnPlan_RecommendationRevert.Visible = false;
            this.btnPlan_RecommendationAudit.Visible = false;

            clsGeneral.DisposeOf(objRecommedetaion);
        }

        Response.Redirect("~/SONIC/Exposures/ViewEnvironmental.aspx?loc=" + Request.QueryString["loc"], true);

    }

    /// <summary>
    /// Save Phase-I Information into Database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPhase_Save_Click(object sender, EventArgs e)
    {
        Enviro_Phase1 objPhase = new Enviro_Phase1();

        // Check if add record when location is In active
        if (EditPhase1ID <= 0 && !isEditable)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(14);", true);
            clsGeneral.ShowAlert("Location for this Record is In Active. So can not add new Record.", this);
            return;
        }

        // Set Phase I Fields
        objPhase.PK_Enviro_Phase1_ID = EditPhase1ID;
        objPhase.FK_LU_Location_ID = LocationID;
        objPhase.ASSESSOR = this.txtPhase_Assessor.Text.Trim();
        objPhase.Last_Date = clsGeneral.FormatNullDateToStore(this.txtPhase_date.Text.Trim());
        objPhase.Next_Date = clsGeneral.FormatNullDateToStore(this.txtPhase_Next_Date.Text.Trim());
        objPhase.Next_Report_Date = clsGeneral.FormatNullDateToStore(this.txtPhase_Next_Report_Date.Text.Trim());
        objPhase.Phone = this.txtPhase_phone.Text.Trim();
        objPhase.Notes = this.txtPhase_Notes.Text.Trim();

        if (this.txtPhase_Cost.Text.Trim() != "")
            objPhase.Cost = Convert.ToDecimal(this.txtPhase_Cost.Text.Trim());

        // Check EditPhase1ID If -1 then insert new record Else update record
        if (EditPhase1ID == -1)
        {
            EditPhase1ID = objPhase.Insert();
            PhaseAttachmentDetails.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Phase1, EditPhase1ID, true, 12);
            PhaseAttachmentDetails.Bind();
        }
        else
        {
            objPhase.Update();
        }

        FillPhaseGrid();

        this.btnPhase_Audit.Visible = true;
        this.btnPhase_Audit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Phase.aspx?id=" + EditPhase1ID.ToString() + "');");

        // Show Next Panel
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(15);", true);

        clsGeneral.DisposeOf(objPhase);

    }

    /// <summary>
    /// Save Phase Recommendation into databse
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPhase_RecommendationSave_Click(object sender, EventArgs e)
    {
        // Check if SPCC Recommendation is in Add or edit mode.
        if (pnlPhaseIndRecommendations.Visible == true)
        {
            // Check if SPCC Information is saved or not.
            if (EditPhase1ID == -1)
            {
                trvMenu.Nodes[5].ExpandAll();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(16);getScrollHeight();", true);
                clsGeneral.ShowAlert("Please Save Phase I Information first.", this.Page);
                return;
            }

            Enviro_Recommendations objRecommedetaion = new Enviro_Recommendations();

            objRecommedetaion.Foreign_Table = clsGeneral.Exposure_Enviroment_Table.Enviro_Phase1.ToString();
            objRecommedetaion.Foreign_Key = EditPhase1ID;
            objRecommedetaion.PK_Enviro_Equipment_Recommendations_ID = EditPhase1_RecommendationID;
            objRecommedetaion.Date = clsGeneral.FormatNullDateToStore(this.txtPhase_Indivial_Recommendation_Date.Text.Trim());
            objRecommedetaion.Number = this.txtPhase_Indivial_Recommendation_Number.Text.Trim();
            objRecommedetaion.Made_by = this.txtPhase_Indivial_Recommendation_Made_by.Text.Trim();
            objRecommedetaion.status = this.ddlPhase_Indivial_Recommendation_status.SelectedItem.Value.Trim();
            objRecommedetaion.title = this.txtPhase_Indivial_Recommendation_Title.Text.Trim();
            objRecommedetaion.description = this.txtPhase_Indivial_Recommendation_description.Text.Trim();
            objRecommedetaion.Assigned_to = this.txtPhase_Indivial_Recommendation_Assigned_to.Text.Trim();
            objRecommedetaion.Due_date = clsGeneral.FormatNullDateToStore(this.txtPhase_Indivial_Recommendation_Due_date.Text.Trim());
            objRecommedetaion.Assigned_to_phone = this.txtPhase_Indivial_Recommendation_Assigned_to_phone.Text.Trim();
            objRecommedetaion.Assigned_to_email = this.txtPhase_Indivial_Recommendation_Assigned_to_email.Text.Trim();
            objRecommedetaion.Estimated_Cost = clsGeneral.GetDecimalValue(this.txtPermitEstimetedCost);
            objRecommedetaion.Final_Cost = clsGeneral.GetDecimalValue(this.txtPermitFinalCost);
            objRecommedetaion.resolution = this.txtPhase_Indivial_Recommendation_Resolution.Text.Trim();
            objRecommedetaion.Date_closed = clsGeneral.FormatNullDateToStore(this.txtPhase_Indivial_Recommendation_Date_Closed.Text.Trim());

            // Check Edit existing record or Add New record.
            // if edit index is -1 then add new record else edit existing record
            if (EditPhase1_RecommendationID == -1)
            {
                objRecommedetaion.Insert();
            }
            else
            {
                objRecommedetaion.Update();
            }

            // Hide Recommendation Panel and Return button
            this.pnlPhaseIndRecommendations.Visible = false;
            this.btnPhase_RecommendationRevert.Visible = false;
            this.btnPhase_RecommendationAudit.Visible = false;

            clsGeneral.DisposeOf(objRecommedetaion);
        }

        Response.Redirect("~/SONIC/Exposures/ViewEnvironmental.aspx?loc=" + Request.QueryString["loc"], false);
    }

    /// <summary>
    /// Save EPA-Ids information into databse
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEPISave_Click(object sender, EventArgs e)
    {
        EPA_IDs objEPA = new EPA_IDs();

        // Check if add record when location is In active
        if (EditEPAID <= 0 && !isEditable)
        {
            clsGeneral.ShowAlert("Location for this Record is In Active. So can not add new Record.", this);
            return;
        }
        // Assign Fields Value
        objEPA.PK_Enviro_Permit_ID = EditEPAID;
        objEPA.FK_LU_Location_ID = LocationID;
        objEPA.type = this.txtEPAType.Text.Trim();
        objEPA.ID_Number = this.txtEPAID_Number.Text.Trim();

        // Check Edit existing record or Add New record.
        // if edit index is -1 then add new record else edit existing record
        if (EditEPAID == -1)
        {
            objEPA.Insert();
        }
        else
        {
            objEPA.Update();
        }

        // Fill EPAID grid
        FillEPAIDGrid();

        clsGeneral.DisposeOf(objEPA);

        // Hide Edit Panel
        this.pnlEPAID.Visible = false;
    }

    #endregion

    # region " Grid Row Edit Event "

    /// <summary>
    /// Row Edit event for Equipment Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEquipment_RowEditing(object sender, GridViewEditEventArgs e)
    {
        EditEnviro_EquipmentID = Convert.ToInt32(gvEquipment.DataKeys[e.NewEditIndex].Value);

        // Fill Equipment Records.
        LoadEquiepmentDataByID(EditEnviro_EquipmentID);

        // Fill Recommendation Grid for Equipment
        FillRecommendationGrid(clsGeneral.Exposure_Enviroment_Table.Enviro_Equipment, EditEnviro_EquipmentID);

        // Set Equipment Attachment user control
        EquipmentAttachmentDetail.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Equipment, EditEnviro_EquipmentID, true, 3);
        EquipmentAttachmentDetail.Bind();

        // show Audit Popup
        btnEquipmentAuditView.Visible = true;
        btnEquipmentAuditView.Attributes.Add("onclick", "javascript:return AuditPopUp(" + EditEnviro_EquipmentID.ToString() + ")");

        btnInadvertentAuditView.Visible = true;
        btnInadvertentAuditView.Attributes.Add("onclick", "javascript:return AuditPopUp(" + EditEnviro_EquipmentID.ToString() + ")");

        // Show Panel
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "javascript:OutsideToggleNode(2,1);ShowPanel(1);", true);
    }

    /// <summary>
    /// Row Edit event for Permit Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPermit_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // set Edit Permit ID
        EditPermitID = Convert.ToInt32(gvPermit.DataKeys[e.NewEditIndex].Value);

        // Fill Permit Records.
        LoadPermitDataByID(EditPermitID);

        // Fill Recommendation Grid for Permit
        FillRecommendationGrid(clsGeneral.Exposure_Enviroment_Table.Enviro_Permit, EditPermitID);

        // Set Permit Attachment user control
        PermitAttachmentDetails.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Permit, EditPermitID, true, 6);
        PermitAttachmentDetails.Bind();

        // show Audit Popup
        btnPermitAudit.Visible = true;
        btnPermitAudit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Permits.aspx?id=" + EditPermitID.ToString() + "');");

        // Show Panel
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "javascript:OutsideToggleNode(7,6);ShowPanel(5);", true);
    }

    /// <summary>
    /// Row Edit event for Audit/Inspection grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAudit_RowEditing(object sender, GridViewEditEventArgs e)
    {
        EditAuditID = Convert.ToInt32(gvAudit.DataKeys[e.NewEditIndex].Value);

        // Fill Audit Record.
        LoadAuditDataByID(EditAuditID);

        // Fill Recommendation Grid for Permit
        FillRecommendationGrid(clsGeneral.Exposure_Enviroment_Table.Enviro_Inspection, EditAuditID);

        // Set Audit/Inspection Attachment user control
        AuditAttachmentDetails.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Inspection, EditAuditID, true, 9);
        AuditAttachmentDetails.Bind();

        // show Audit Popup
        btnInspection_Audit.Visible = true;
        btnInspection_Audit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Inspections.aspx?id=" + EditAuditID.ToString() + "');");

        // Show Panel
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "javascript:OutsideToggleNode(11,10);ShowPanel(8);", true);
    }

    /// <summary>
    /// Row Edit event for SPCC grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSPCC_RowEditing(object sender, GridViewEditEventArgs e)
    {
        EditSPCCID = Convert.ToInt32(gvSPCC.DataKeys[e.NewEditIndex].Value);

        // Fill SPCC Record.
        LoadSPCCDataByID(EditSPCCID);

        // Fill Recommendation Grid for SPCC
        FillRecommendationGrid(clsGeneral.Exposure_Enviroment_Table.Enviro_SPCC, EditSPCCID);

        // Set SPCC Attachment user control
        PlanAttachmentDetails.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_SPCC, EditSPCCID, true, 12);
        PlanAttachmentDetails.Bind();

        // show Audit Popup
        this.btnPlan_Audit.Visible = true;
        this.btnPlan_Audit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_SPCC.aspx?id=" + EditSPCCID.ToString() + "');");

        // Show Panel
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "javascript:OutsideToggleNode(15,14);ShowPanel(11);", true);
    }

    /// <summary>
    /// Row edit event for Phase-I grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPhaseI_RowEditing(object sender, GridViewEditEventArgs e)
    {
        EditPhase1ID = Convert.ToInt32(gvPhaseI.DataKeys[e.NewEditIndex].Value);

        // Fill PhaseI Record.
        LoadPhaseDataByID(EditPhase1ID);

        // Fill Recommendation Grid for PhaseI
        FillRecommendationGrid(clsGeneral.Exposure_Enviroment_Table.Enviro_Phase1, EditPhase1ID);

        // Set PhaseI Attachment user control
        PhaseAttachmentDetails.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Phase1, EditPhase1ID, true, 15);
        PhaseAttachmentDetails.Bind();

        // show Audit Popup
        this.btnPhase_Audit.Visible = true;
        this.btnPhase_Audit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Phase.aspx?id=" + EditPhase1ID.ToString() + "');");

        // Show Panel
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "javascript:OutsideToggleNode(19,18);ShowPanel(14);", true);
    }

    /// <summary>
    /// Row Edit event for Equipment Recomeendation grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEquipmentRecommendation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set Edit ID of Equipment recommendation
        EditEquipement_RecommendationID = Convert.ToInt32(gvEquipmentRecommendation.DataKeys[e.NewEditIndex].Value);

        // Fill Fields of recommendation by Recommendation ID
        LoadEquipmentRecommendationRecordByID(EditEquipement_RecommendationID);
    }

    /// <summary>
    /// Row Edit event for Permit Recomeendation Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPermitRecommendation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set Edit ID of Permit recommendation
        EditPermit_RecommendationID = Convert.ToInt32(gvPermitRecommendation.DataKeys[e.NewEditIndex].Value);

        // Fill Fields of recommendation by Recommendation ID
        LoadPermitRecommendationRecordByID(EditPermit_RecommendationID);
    }

    /// <summary>
    /// Row Edit event for Audit/Inspection Recomeendation Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAuditRecommendation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set Edit ID of Audit/Inspectoin recommendation
        EditAudit_RecommendationID = Convert.ToInt32(gvAuditRecommendation.DataKeys[e.NewEditIndex].Value);

        // Fill Fields of recommendation by Recommendation ID
        LoadAuditRecommendationRecordByID(EditAudit_RecommendationID);
    }

    /// <summary>
    /// Row Edit event for SPCC/Plan Recomeendation Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPlanRecommendation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set Edit ID of SPCC Recommendation
        EditSPCC_RecommendationID = Convert.ToInt32(gvPlanRecommendation.DataKeys[e.NewEditIndex].Value);

        // Fill Fields of recommendation by Recommendation ID
        LoadSPCCRecommendationRecordByID(EditSPCC_RecommendationID);
    }

    /// <summary>
    /// Row Edit event for Phase-I Recomeendation Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPhaseRecommendation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set Edit ID of Phase recommendation
        EditPhase1_RecommendationID = Convert.ToInt32(gvPhaseRecommendation.DataKeys[e.NewEditIndex].Value);

        // Fill Fields of recommendation by Recommendation ID
        LoadPhaseRecommendationRecordByID(EditPhase1_RecommendationID);
    }

    /// <summary>
    /// Row Edit event for EPA-Ids Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEPAID_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set Edit ID of EPA-IDs
        EditEPAID = Convert.ToInt32(gvEPAID.DataKeys[e.NewEditIndex].Value);

        // Fill EPA_IDS Fields
        LoadEPADatabyID(EditEPAID);
    }

    #endregion

    #region " Grid Row Delete Event "
    /// <summary>
    /// Row Delete Event for Equipment grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEquipment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int DeleteID;

        DeleteID = Convert.ToInt32(gvEquipment.DataKeys[e.RowIndex].Value);

        // Delete Equipment Record
        Enviro_Equipment.DeleteByPK(DeleteID);

        // Check if Delete Id and Edit Equipment Id is Same then clear whole Equipment Menu
        if (DeleteID == EditEnviro_EquipmentID)
            ClearEquipment();

        // Bind Equipment grid
        FillEquipmentGrid();

        // Show Panel
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(0);", true);
    }

    /// <summary>
    /// Row Delete Event for Permit grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPermit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int DeleteID;

        DeleteID = Convert.ToInt32(gvPermit.DataKeys[e.RowIndex].Value);

        // delete Permit record
        Enviro_Permit.DeleteByPK(DeleteID);

        // Check if Delete Id and Edit Permit Id is Same then clear whole Permit Menu
        if (DeleteID == EditPermitID)
            ClearPermit();

        // Fill Permit Grid
        FillPermitGrid();

        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(0);", true);
    }

    /// <summary>
    /// Row Delete Event for Audit/Inspection grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAudit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int DeleteID;

        DeleteID = Convert.ToInt32(gvAudit.DataKeys[e.RowIndex].Value);

        // delete Audit record
        Enviro_Inspection.DeleteByPK(DeleteID);

        // Check if Delete Id and Edit Audit/Inspection Id is Same then clear whole Audit/Inspection Menu
        if (DeleteID == EditAuditID)
            ClearAudit();

        // Fill Audit/Inspection Grid
        FillAuditGrid();

        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(0);", true);
    }

    /// <summary>
    /// Row Delete Event for SPCC grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSPCC_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int DeleteId;

        DeleteId = Convert.ToInt32(gvSPCC.DataKeys[e.RowIndex].Value);

        // Delete SPCC Record
        Enviro_SPCC.DeleteByPK(DeleteId);

        // Check if Delete Id and Edit SPCC Id is Same then clear whole SPCC Menu
        if (DeleteId == EditSPCCID)
            ClearSPCC();

        // Fill SPCC Grid
        FillSPCCGrid();

        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(0);", true);
    }

    /// <summary>
    /// Row Delete Event for Phase-I grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPhaseI_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int DeleteID;

        DeleteID = Convert.ToInt32(gvPhaseI.DataKeys[e.RowIndex].Value);

        // Delete Phase-I Record
        Enviro_Phase1.DeleteByPK(DeleteID);

        // Check if Delete Id and Edit Phase-I Id is Same then clear whole Phase-I Menu
        if (DeleteID == EditPhase1ID)
            ClearPhase();

        // Fill Phase Grid
        FillPhaseGrid();

        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(0);", true);
    }

    /// <summary>
    /// Row Delete Event for EPA-Ids grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEPAID_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Delete EAPID Record.
        int DeleteID;

        DeleteID = Convert.ToInt32(gvEPAID.DataKeys[e.RowIndex].Value);
        EPA_IDs.DeleteByPK(DeleteID);

        // Check if Delete Id and Edit Phase-I Id is Same then clear whole EPA-Ids Fields
        if (DeleteID == EditEPAID)
        {
            EditEPAID = -1;
            this.pnlEPAID.Visible = false;
            this.txtEPAType.Text = "";
            this.txtEPAID_Number.Text = "";
        }

        // Fill Grid
        FillEPAIDGrid();
    }

    /// <summary>
    /// Row Delete Event for Requipment Recommendation Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEquipmentRecommendation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // delete Equipment Recommendation record
        Enviro_Recommendations.DeleteByPK(Convert.ToInt32(gvEquipmentRecommendation.DataKeys[e.RowIndex].Value));

        // bind Equipment Recommendation grid
        FillRecommendationGrid(clsGeneral.Exposure_Enviroment_Table.Enviro_Equipment, EditEnviro_EquipmentID);
    }

    /// <summary>
    /// Row Delete Event for Permit Recommendation Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPermitRecommendation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // delete Permit Recommendation record
        Enviro_Recommendations.DeleteByPK(Convert.ToInt32(gvPermitRecommendation.DataKeys[e.RowIndex].Value));

        // bind Permit Recommendation grid
        FillRecommendationGrid(clsGeneral.Exposure_Enviroment_Table.Enviro_Permit, EditPermitID);
    }

    /// <summary>
    /// Row Delete Event for Audit/Inspection Recommendation Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAuditRecommendation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // delete Audit/Inspection Recommendation record
        Enviro_Recommendations.DeleteByPK(Convert.ToInt32(gvAuditRecommendation.DataKeys[e.RowIndex].Value));

        // bind Audit/Inspection Recommendation grid
        FillRecommendationGrid(clsGeneral.Exposure_Enviroment_Table.Enviro_Inspection, EditAuditID);
    }

    /// <summary>
    /// Row Delete Event for SPCC/Plan Recommendation Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPlanRecommendation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // delete SPCC Recommendation record
        Enviro_Recommendations.DeleteByPK(Convert.ToInt32(gvPlanRecommendation.DataKeys[e.RowIndex].Value));

        // bind SPCC Recommendation grid
        FillRecommendationGrid(clsGeneral.Exposure_Enviroment_Table.Enviro_SPCC, EditSPCCID);
    }

    /// <summary>
    /// Row Delete Event for Phase-I Recommendation Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPhaseRecommendation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // delete Phase Recommendation record
        Enviro_Recommendations.DeleteByPK(Convert.ToInt32(gvPhaseRecommendation.DataKeys[e.RowIndex].Value));

        // bind Phase Recommendation grid
        FillRecommendationGrid(clsGeneral.Exposure_Enviroment_Table.Enviro_Phase1, EditPhase1ID);
    }

    #endregion

    #region "Add New Record Event"

    /// <summary>
    /// Handle Add Click for Equipment Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddEquipment_Click(object sender, EventArgs e)
    {
        // Clear Equipment Fields
        ClearEquipment();      

        // Show Next panel and Expand-Collapse Tree Node
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:OutsideToggleNode(2,1);ShowPanel(1);ChangeEquipmentType();", true);

    }

    /// <summary>
    /// Handle Add Click for Permit Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtAddPermits_Click(object sender, EventArgs e)
    {
        // Clear Permit Fields
        ClearPermit();

        // Show Next panel and Expand-Collapse Tree Node
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:OutsideToggleNode(7,6);ShowPanel(5);", true);

    }

    /// <summary>
    /// Handle Add Click for Permit Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtAuditsAdd_Click(object sender, EventArgs e)
    {
        // Clear Audit Fields
        ClearAudit();

        // Show Next panel and Expand-Collapse Tree Node
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:OutsideToggleNode(11,10);ShowPanel(8);", true);

    }

    /// <summary>
    /// Handle Add Click for SPCC Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtAddSPCC_Click(object sender, EventArgs e)
    {
        // Clear SPCC Fields
        ClearSPCC();

        // Show Next panel and Expand-Collapse Tree Node
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:OutsideToggleNode(15,14);ShowPanel(11);", true);

    }

    /// <summary>
    /// Handle Add Click for Phase-I Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtAddPhase_Click(object sender, EventArgs e)
    {
        // Clear PhaseI Fields
        ClearPhase();

        // Show Next panel and Expand-Collapse Tree Node
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:OutsideToggleNode(19,18);ShowPanel(14);", true);
    }

    /// <summary>
    /// Handle Add Click for Equipment Recommendation Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkRecommendation_Click(object sender, EventArgs e)
    {
        // Set Edit Recommendation ID for Equipment
        EditEquipement_RecommendationID = -1;
        ClearEquipmentRecommendation();

        // Show Individual Recommendation Panel and change button Text
        this.pnlAddEquipmentRecommendation.Visible = true;
        this.btnEquipmentRevert.Visible = true;
        this.btnRecommendationAudit.Visible = false;
        this.btnRecommendationSave.Text = "Save & View";
    }

    /// <summary>
    /// Handle Revert & return Click for Equipment Recommendation Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEquipmentRevert_Click(object sender, EventArgs e)
    {
        // Hide Individual Recommendation Panel and change button Text
        this.pnlAddEquipmentRecommendation.Visible = false;
        this.btnEquipmentRevert.Visible = false;
        this.btnRecommendationAudit.Visible = false;
        this.btnRecommendationSave.Text = "View";
    }

    /// <summary>
    /// Handle Add Click for Permit Recommendation Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkPermitRecommendation_Click(object sender, EventArgs e)
    {
        // Set Edit Recommendation ID for Permit
        EditPermit_RecommendationID = -1;
        ClearPermitRecommendation();

        // Show Individual Recommendation Panel and change button Text
        this.pnlPermitIndRecommendation.Visible = true;
        this.btnPermitRecommendationRevort.Visible = true;
        this.btnPermit_RecommendationAudit.Visible = false;
        this.btnPermit_RecommendationSave.Text = "Save & View";
    }

    /// <summary>
    /// Handle Revert & return Click for Permit Recommendation Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPermitRecommendationRevort_Click(object sender, EventArgs e)
    {
        this.pnlPermitIndRecommendation.Visible = false;
        this.btnPermitRecommendationRevort.Visible = false;
        this.btnPermit_RecommendationAudit.Visible = false;
        this.btnPermit_RecommendationSave.Text = "View";
    }

    /// <summary>
    /// Handle Add Click for Audit/Inspection Recommendation Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddAuditRecommendation_Click(object sender, EventArgs e)
    {
        // Set Edit Recommendation ID for Audit/Inspection
        EditAudit_RecommendationID = -1;
        ClearAuditRecommendation();

        // Show Individual Recommendation Panel and change button Text
        this.pnlAuditIndRecommendations.Visible = true;
        this.btnAuditRecommendationRevort.Visible = true;
        this.btnAudit_RecommendationAudit.Visible = false;
        this.btnAudit_RecommendationSave.Text = "Save & View";
    }

    /// <summary>
    /// Handle Revert & return Click for Audit/Inspection Recommendation Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAuditRecommendationRevort_Click(object sender, EventArgs e)
    {
        // Show Individual Recommendation Panel and change button Text for Audit/Inspection
        this.pnlAuditIndRecommendations.Visible = false;
        this.btnAuditRecommendationRevort.Visible = false;
        this.btnAudit_RecommendationAudit.Visible = false;
        this.btnAudit_RecommendationSave.Text = "View";
    }

    /// <summary>
    /// Handle Add Click for SPCC/Plan Recommendation Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkPlanRecommendation_Click(object sender, EventArgs e)
    {
        // Set Edit Recommendation ID for SPCC
        EditSPCC_RecommendationID = -1;
        ClearPlanRecommendation();

        // Show Individual Recommendation Panel and change button Text
        pnlSPCCIndRecommendation.Visible = true;
        btnPlan_RecommendationRevert.Visible = true;
        this.btnPlan_RecommendationAudit.Visible = false;
        btnPlan_RecommendationSave.Text = "Save & View";
    }

    /// <summary>
    /// Handle Revert & return Click for SPCC/Plan Recommendation Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPlan_RecommendationRevert_Click(object sender, EventArgs e)
    {
        // Show Individual Recommendation Panel and change button Text for SPCC
        pnlSPCCIndRecommendation.Visible = false;
        btnPlan_RecommendationRevert.Visible = false;
        this.btnPlan_RecommendationAudit.Visible = false;
        btnPlan_RecommendationSave.Text = "View";
    }

    /// <summary>
    /// Handle Add Click for Phase Recommendation Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkPhaseRecommendation_Click(object sener, EventArgs e)
    {
        // Set Edit Recommendation ID for Phase
        EditPhase1_RecommendationID = -1;
        ClearPhaseRecommendation();

        // Show Individual Recommendation Panel and change button Text
        pnlPhaseIndRecommendations.Visible = true;
        btnPhase_RecommendationRevert.Visible = true;
        btnPhase_RecommendationAudit.Visible = false;
        btnPhase_RecommendationSave.Text = "Save & View";
    }

    /// <summary>
    /// Handle Revert & return Click for Phase-I Recommendation Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPhase_RecommendationRevert_Click(object sender, EventArgs e)
    {
        // Show Individual Recommendation Panel and change button Text for Phase
        pnlPhaseIndRecommendations.Visible = false;
        btnPhase_RecommendationRevert.Visible = false;
        btnPhase_RecommendationAudit.Visible = false;
        btnPhase_RecommendationSave.Text = "View";
    }

    /// <summary>
    /// Handle Add Click for EPA-Ids Record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lblEPAIDlAdd_Click(object sender, EventArgs e)
    {
        // Clear EPA-Ids Fields
        this.txtEPAID_Number.Text = "";
        this.txtEPAType.Text = "";

        // Set EPAIDs Edit ID
        EditEPAID = -1;
        pnlEPAID.Visible = true;
        M1.Style["display"] = "none";
        M2.Style["display"] = "none";
        M3.Style["display"] = "none";
        M4.Style["display"] = "none";
        M5.Style["display"] = "none";
        M6.Style["display"] = "none";
        M7.Style["display"] = "none";
        M8.Style["display"] = "none";
        M9.Style["display"] = "none";
        M10.Style["display"] = "none";
    }

    protected void btnEPICancel_Click(object sender, EventArgs e)
    {
        this.pnlEPAID.Visible = false;
    }

    #endregion

    #region " Methods "

    /// <summary>
    /// Check For User Access and valid parameter Location ID
    /// </summary>
    private void CheckValidRequest()
    {
        int Location_Id;
        // Check if User has right To Add Equipment or View Equipment
        if (App_Access == AccessType.View_Only)
        {
            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
        }

        // Check whether Paramenter Location ID is valid int
        // if not provided then redirect to search page.
        if (!int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out Location_Id))
        {
            Response.Redirect("~/SONIC/Exposures/ExposureSearch.aspx", true);
            return;
        }
        else
        {
            LocationID = Location_Id;
        }

        // Check if Location ID is exists or Not
        // if not then redirect to ExposureSearch Page.
        if (LU_Location.SelectByPK(Location_Id).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/SONIC/Exposures/ExposureSearch.aspx", true);
            return;
        }

        Session["ExposureLocation"] = LocationID;

    }

    /// <summary>
    /// Fill Equipment Summary Grid
    /// </summary>
    private void FillEquipmentGrid()
    {
        gvEquipment.DataSource = Enviro_Equipment.SelectByFK_LU_LocationID(LocationID).Tables[0];
        gvEquipment.DataBind();
    }

    /// <summary>
    /// Fill PermitGrid
    /// </summary>
    private void FillPermitGrid()
    {
        gvPermit.DataSource = Enviro_Permit.SelectByLocationID(LocationID).Tables[0];
        gvPermit.DataBind();
    }

    /// <summary>
    /// Fill Audit/Inspection Grid
    /// </summary>
    private void FillAuditGrid()
    {
        gvAudit.DataSource = Enviro_Inspection.SelectByLocationID(LocationID).Tables[0];
        gvAudit.DataBind();
    }

    /// <summary>
    /// Fill Phase Grid
    /// </summary>
    private void FillPhaseGrid()
    {

        gvPhaseI.DataSource = Enviro_Phase1.SelectByLocationID(LocationID).Tables[0];
        gvPhaseI.DataBind();

    }

    /// <summary>
    /// Fill SPCC Grid
    /// </summary>
    private void FillSPCCGrid()
    {

        gvSPCC.DataSource = Enviro_SPCC.SelectByLocationID(LocationID).Tables[0];
        gvSPCC.DataBind();

    }

    /// <summary>
    /// Fill EPA IDs Grid
    /// </summary>
    private void FillEPAIDGrid()
    {
        DataTable dtEPAID;
        dtEPAID = EPA_IDs.SelectByLocationID(LocationID).Tables[0];

        gvEPAID.DataSource = dtEPAID;
        gvEPAID.DataBind();
    }

    /// <summary>
    /// Fill Recommendation Grid by recommendation foriegn Table name and foeign Key
    /// </summary>
    /// <param name="RecommendationTable">Foreign Table</param>
    /// <param name="ForeignKey_ID">Foreign Key ID</param>
    private void FillRecommendationGrid(clsGeneral.Exposure_Enviroment_Table RecommendationTable, int ForeignKey_ID)
    {
        DataSet dsRecommendation;

        // Fill Equipment Recommdendation Grid
        dsRecommendation = Enviro_Recommendations.SelectByForeignTableKey(RecommendationTable.ToString(), ForeignKey_ID);

        // Fill Equipment Recommdendation Grid
        if (RecommendationTable == clsGeneral.Exposure_Enviroment_Table.Enviro_Equipment)
        {
            this.gvEquipmentRecommendation.DataSource = dsRecommendation;
            this.gvEquipmentRecommendation.DataBind();

            this.pnlAddEquipmentRecommendation.Visible = false;
            this.btnEquipmentRevert.Visible = false;
            this.btnRecommendationAudit.Visible = false;
            this.btnRecommendationSave.Text = "View";
        }
        // Fill Permit Recommdendation Grid
        else if (RecommendationTable == clsGeneral.Exposure_Enviroment_Table.Enviro_Permit)
        {
            this.gvPermitRecommendation.DataSource = dsRecommendation;
            this.gvPermitRecommendation.DataBind();

            this.btnPermitRecommendationRevort.Visible = false;
            this.btnPermit_RecommendationAudit.Visible = false;
            this.pnlPermitIndRecommendation.Visible = false;
            this.btnPermit_RecommendationSave.Text = "View";
        }
        // Fill Audit/inspecton Recommdendation Grid
        else if (RecommendationTable == clsGeneral.Exposure_Enviroment_Table.Enviro_Inspection)
        {
            this.gvAuditRecommendation.DataSource = dsRecommendation;
            this.gvAuditRecommendation.DataBind();

            this.btnAuditRecommendationRevort.Visible = false;
            this.btnAudit_RecommendationAudit.Visible = false;
            this.pnlAuditIndRecommendations.Visible = false;
            this.btnAudit_RecommendationSave.Text = "View";

        }
        // Fill SPCC Recommdendation Grid
        else if (RecommendationTable == clsGeneral.Exposure_Enviroment_Table.Enviro_SPCC)
        {
            this.gvPlanRecommendation.DataSource = dsRecommendation;
            this.gvPlanRecommendation.DataBind();

            pnlSPCCIndRecommendation.Visible = false;
            btnPlan_RecommendationRevert.Visible = false;
            this.btnPlan_RecommendationAudit.Visible = false;
            btnPlan_RecommendationSave.Text = "View";
        }
        // Fill Phase I Recommdendation Grid
        else if (RecommendationTable == clsGeneral.Exposure_Enviroment_Table.Enviro_Phase1)
        {
            this.gvPhaseRecommendation.DataSource = dsRecommendation;
            this.gvPhaseRecommendation.DataBind();

            pnlPhaseIndRecommendations.Visible = false;
            btnPhase_RecommendationRevert.Visible = false;
            btnPhase_RecommendationAudit.Visible = false;
            btnPhase_RecommendationSave.Text = "View";
        }

        clsGeneral.DisposeOf(dsRecommendation);
    }

    /// <summary>
    /// Fill Equipment Data by Equipment ID
    /// </summary>
    /// <param name="PK_Enviro_Equipment_ID"> Equipment ID </param>
    private void LoadEquiepmentDataByID(int PK_Enviro_Equipment_ID)
    {
        DataSet dsEquiepment = new DataSet();

        dsEquiepment = Enviro_Equipment.SelectByPK(PK_Enviro_Equipment_ID);

        this.txtIdentification.Text = dsEquiepment.Tables[0].Rows[0]["Identification"].ToString();
        this.txtDate_of_Last_Service.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Date_of_Last_Service"]);
        this.txtInsurer.Text = dsEquiepment.Tables[0].Rows[0]["Insurer"].ToString();

        if (dsEquiepment.Tables[0].Rows[0]["Single_Event_Coverage"].ToString() != "")
            this.txtSingle_Event_Coverage.Text = string.Format("{0:0,0}", dsEquiepment.Tables[0].Rows[0]["Single_Event_Coverage"]);

        if (dsEquiepment.Tables[0].Rows[0]["Multiple_Event_Total_Coverage"].ToString() != "")
            this.txtMultiple_Event_Total_Coverage.Text = string.Format("{0:0,0}", dsEquiepment.Tables[0].Rows[0]["Multiple_Event_Total_Coverage"]);

        if (dsEquiepment.Tables[0].Rows[0]["Capacity"].ToString().Trim() != "")
            this.txtCapacity.Text = string.Format("{0:0,0}", dsEquiepment.Tables[0].Rows[0]["Capacity"]);

        this.txtCoverage_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Coverage_Start_Date"]);
        this.txtCoverage_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Coverage_End_Date"]);
        this.txtDate_of_Last_TCLP.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Date_of_Last_TCLP"]);
        this.txtInstallation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Installation_Date"]);
        this.txtRemoval_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Removal_Date"]);
        this.txtClosure_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Closure_Date"]);
        this.txtLast_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Last_Inspection_Date"]);
        this.txtNext_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Next_Inspection_Date"]);
        this.txtConstructionOther.Text = dsEquiepment.Tables[0].Rows[0]["Construction_Other"].ToString().Trim();
        this.txtInspection_Company.Text = dsEquiepment.Tables[0].Rows[0]["Insurance_Company"].ToString();
        this.txtInspection_Contact.Text = dsEquiepment.Tables[0].Rows[0]["Inspection_Contact"].ToString();
        this.txtInspection_Phone.Text = dsEquiepment.Tables[0].Rows[0]["Inspection_Phone"].ToString();
        this.txtRegistration_Number.Text = dsEquiepment.Tables[0].Rows[0]["Registration_Number"].ToString();
        this.txtCertificate_Number.Text = dsEquiepment.Tables[0].Rows[0]["Certificate_Number"].ToString();
        this.txtPermit_Begin_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Permit_Begin_Date"]);
        this.txtPermit_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Permit_End_Date"]);
        this.txtConents_Other.Text = dsEquiepment.Tables[0].Rows[0]["Contents_Other"].ToString();
        this.txtRelease_Equipment_Description.Text = dsEquiepment.Tables[0].Rows[0]["Release_Equipment_Description"].ToString();
        this.txtMaterial_Other.Text = dsEquiepment.Tables[0].Rows[0]["Material_Other"].ToString();
        this.txtOther_Req_Descr.Text = dsEquiepment.Tables[0].Rows[0]["Other_Req_Descr"].ToString();
        this.txtNext_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Next_Report_Date"]);
        this.txtNotes.Text = dsEquiepment.Tables[0].Rows[0]["Notes"].ToString();
        this.txtLeak_Detection_Type.Text = dsEquiepment.Tables[0].Rows[0]["Leak_Detection_Type"].ToString().Trim();

        this.txtPlan_Revision_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Plan_Revision_Date"]);
        this.txtPlan_Effective_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Plan_Effective_Date"]);
        this.txtPlan_Expiration_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Plan_Expiration_Date"]);
        this.txtPlan_ID.Text = dsEquiepment.Tables[0].Rows[0]["Plan_ID"].ToString().Trim();
        this.txtPlan_Vendor.Text = dsEquiepment.Tables[0].Rows[0]["Plan_Vendor"].ToString().Trim();
        this.txtPlan_Vendor_Contact.Text = dsEquiepment.Tables[0].Rows[0]["Plan_Vendor_Contact"].ToString().Trim();
        this.txtPlan_Phone.Text = dsEquiepment.Tables[0].Rows[0]["Plan_Phone"].ToString().Trim();

        // Clear Existing Selection of dropdown
        this.ddlContents.ClearSelection();
        this.ddlStatus.ClearSelection();
        this.ddlMaterial.ClearSelection();
        this.ddlConstruction.ClearSelection();
        this.ddlEquiepmentType.ClearSelection();

        this.ddlEquiepmentType.Items.FindByValue(dsEquiepment.Tables[0].Rows[0]["type"].ToString()).Selected = true;
        this.ddlContents.Items.FindByValue(dsEquiepment.Tables[0].Rows[0]["Contents"].ToString()).Selected = true;
        this.ddlStatus.Items.FindByValue(dsEquiepment.Tables[0].Rows[0]["status"].ToString()).Selected = true;
        this.ddlMaterial.Items.FindByValue(dsEquiepment.Tables[0].Rows[0]["Material"].ToString()).Selected = true;
        this.ddlConstruction.Items.FindByValue(dsEquiepment.Tables[0].Rows[0]["Construction"].ToString()).Selected = true;

        clsGeneral.FormatYesNoToDisplayForEdit(rdoRelease_Equipment_Present, dsEquiepment.Tables[0].Rows[0]["Release_Equipment_Present"]);
        clsGeneral.FormatYesNoToDisplayForEdit(rdoOverfill_Protection, dsEquiepment.Tables[0].Rows[0]["Overfill_Protection"]);
        clsGeneral.FormatYesNoToDisplayForEdit(rdoLeak_Detection, dsEquiepment.Tables[0].Rows[0]["Leak_Detection"]);
        clsGeneral.FormatYesNoToDisplayForEdit(rdoTCLP_on_File, dsEquiepment.Tables[0].Rows[0]["TCLP_on_File"]);
        clsGeneral.FormatYesNoToDisplayForEdit(rdoFlows_to_POTW, dsEquiepment.Tables[0].Rows[0]["Flows_to_POTW"]);
        clsGeneral.FormatYesNoToDisplayForEdit(rdoRegistration_Required, dsEquiepment.Tables[0].Rows[0]["Registration_Required"]);
        clsGeneral.FormatYesNoToDisplayForEdit(rdoOther_Req, dsEquiepment.Tables[0].Rows[0]["Other_Req"]);


        if (ddlEquiepmentType.SelectedIndex == 1 || ddlEquiepmentType.SelectedIndex == 2)
        {
            tblTypeInfo.Style["display"] = "block";
            tblOilWater.Style["display"] = "none";
            //rfvStatus.Enabled = true;
            csmvCapacity.Enabled = true;
        }
        else if (ddlEquiepmentType.SelectedIndex == 3)
        {
            tblOilWater.Style["display"] = "block";
            tblTypeInfo.Style["display"] = "none";
            //rfvStatus.Enabled = false;
            csmvCapacity.Enabled = false;
        }
        else
        {
            tblOilWater.Style["display"] = "none";
            tblTypeInfo.Style["display"] = "none";
            //rfvStatus.Enabled = false;
            csmvCapacity.Enabled = false;
        }

        clsGeneral.DisposeOf(dsEquiepment);
    }

    /// <summary>
    /// Load equipment Recommendation Record by PK
    /// </summary>
    /// <param name="RecommendationID"></param>
    private void LoadEquipmentRecommendationRecordByID(int RecommendationID)
    {
        Enviro_Recommendations objRecommendation = new Enviro_Recommendations(RecommendationID);

        this.txtIndivial_Recommendation_Assigned_to.Text = objRecommendation.Assigned_to.ToString();
        this.txtIndivial_Recommendation_Assigned_to_email.Text = objRecommendation.Assigned_to_email.ToString();
        this.txtIndivial_Recommendation_Assigned_to_phone.Text = objRecommendation.Assigned_to_phone.ToString();
        this.txtIndivial_Recommendation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date);
        this.txtIndivial_Recommendation_Date_Closed.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date_closed);
        this.txtIndivial_Recommendation_Due_date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Due_date);
        this.txtIndivial_Recommendation_description.Text = objRecommendation.description.ToString();
        this.txtIndivial_Recommendation_Made_by.Text = objRecommendation.Made_by.ToString();
        this.txtIndivial_Recommendation_Number.Text = objRecommendation.Number.ToString();
        this.txtEstimatedCost.Text = clsGeneral.GetStringValue(objRecommendation.Estimated_Cost);
        this.txtFinalCost.Text = clsGeneral.GetStringValue(objRecommendation.Final_Cost);
        this.txtIndivial_Recommendation_Resolution.Text = objRecommendation.resolution.ToString();
        this.txtIndivial_Recommendation_Title.Text = objRecommendation.title.ToString();
        this.ddlIndivial_Recommendation_status.ClearSelection();
        this.ddlIndivial_Recommendation_status.Items.FindByValue(objRecommendation.status).Selected = true;
        this.btnEquipmentRevert.Visible = true;
        this.btnRecommendationAudit.Visible = true;
        this.btnRecommendationAudit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Recommendation.aspx?id=" + RecommendationID.ToString() + "');");
        this.pnlAddEquipmentRecommendation.Visible = true;
        this.btnRecommendationSave.Text = "Save & View";

        clsGeneral.DisposeOf(objRecommendation);
    }

    /// <summary>
    /// Fill Permit Data by Equipment ID
    /// </summary>
    /// <param name="PK_PermitID"> Permit ID </param>
    private void LoadPermitDataByID(int PK_PermitID)
    {
        Enviro_Permit objPermit = new Enviro_Permit(PK_PermitID);

        this.txtPermit_Type.Text = objPermit.type;
        clsGeneral.FormatYesNoToDisplayForEdit(rdoPermit_required, objPermit.required);
        this.txtPermit_Application_number.Text = objPermit.Application_number;
        this.txtPermit_Certificate_number.Text = objPermit.Certificate_number;
        this.txtPermit_Permit_Begin_date.Text = clsGeneral.FormatDBNullDateToDisplay(objPermit.Begin_date);
        this.txtPermit_Permit_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPermit.End_date);
        this.txtPermit_Last_Inspection_date.Text = clsGeneral.FormatDBNullDateToDisplay(objPermit.Last_Inspection_date);
        this.txtPermit_Next_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPermit.Next_Inspection_Date);
        this.txtPermit_Filing_date.Text = clsGeneral.FormatDBNullDateToDisplay(objPermit.Filing_date);
        this.txtPermit_Next_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPermit.Next_Report_Date);
        this.txtPermit_Notes.Text = objPermit.Notes;

        clsGeneral.DisposeOf(objPermit);

    }

    /// <summary>
    /// Load Recommendation Record by PK
    /// </summary>
    /// <param name="RecommendationID"></param>
    private void LoadPermitRecommendationRecordByID(int RecommendationID)
    {
        Enviro_Recommendations objRecommendation = new Enviro_Recommendations(RecommendationID);

        this.txtPermit_Indivial_Recommendation_Assigned_to.Text = objRecommendation.Assigned_to.ToString();
        this.txtPermit_Indivial_Recommendation_Assigned_to_email.Text = objRecommendation.Assigned_to_email.ToString();
        this.txtPermit_Indivial_Recommendation_Assigned_to_phone.Text = objRecommendation.Assigned_to_phone.ToString();
        this.txtPermit_Indivial_Recommendation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date);
        this.txtPermit_Indivial_Recommendation_Date_Closed.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date_closed);
        this.txtPermit_Indivial_Recommendation_Due_date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Due_date);
        this.txtPermit_Indivial_Recommendation_description.Text = objRecommendation.description.ToString();
        this.txtPermit_Indivial_Recommendation_Made_by.Text = objRecommendation.Made_by.ToString();
        this.txtPermit_Indivial_Recommendation_Number.Text = objRecommendation.Number.ToString();
        this.txtPermitEstimetedCost.Text = clsGeneral.GetStringValue(objRecommendation.Estimated_Cost);
        this.txtPermitFinalCost.Text = clsGeneral.GetStringValue(objRecommendation.Final_Cost);
        this.txtPermit_Indivial_Recommendation_Resolution.Text = objRecommendation.resolution.ToString();
        this.txtPermit_Indivial_Recommendation_Title.Text = objRecommendation.title.ToString();
        this.ddlPermit_Indivial_Recommendation_status.ClearSelection();
        this.ddlPermit_Indivial_Recommendation_status.Items.FindByValue(objRecommendation.status).Selected = true;
        this.btnPermitRecommendationRevort.Visible = true;
        this.btnPermit_RecommendationAudit.Visible = true;
        this.btnPermit_RecommendationAudit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Recommendation.aspx?id=" + RecommendationID.ToString() + "');");
        this.pnlPermitIndRecommendation.Visible = true;
        this.btnPermit_RecommendationSave.Text = "Save & View";

        clsGeneral.DisposeOf(objRecommendation);
    }

    /// <summary>
    /// Fill Audit/inpsection data By AuditID
    /// </summary>
    /// <param name="PK_AuditID"></param>
    private void LoadAuditDataByID(int PK_AuditID)
    {
        Enviro_Inspection objAudit = new Enviro_Inspection(PK_AuditID);

        this.txtAudit_Frequency.Text = objAudit.Frequency.Trim();
        this.txtAudit_Cost.Text = string.Format("{0:N0}", objAudit.Cost);
        this.txtAudit_Last_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objAudit.Last_Date);
        this.txtAudit_Next_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objAudit.Next_Date);
        this.txtAudits_Next_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objAudit.Next_Report_Date);
        this.txtAudit_Notes.Text = objAudit.Notes.Trim();

        clsGeneral.DisposeOf(objAudit);
    }

    /// <summary>
    /// Fill Audit/Inspection recommendation data by Recommendation ID
    /// </summary>
    /// <param name="RecommendationID"></param>
    private void LoadAuditRecommendationRecordByID(int RecommendationID)
    {
        Enviro_Recommendations objRecommendation = new Enviro_Recommendations(RecommendationID);

        this.txtAudit_Indivial_Recommendation_Assigned_to.Text = objRecommendation.Assigned_to.ToString();
        this.txtAudit_Indivial_Recommendation_Assigned_to_email.Text = objRecommendation.Assigned_to_email.ToString();
        this.txtAudit_Indivial_Recommendation_Assigned_to_phone.Text = objRecommendation.Assigned_to_phone.ToString();
        this.txtAudit_Indivial_Recommendation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date);
        this.txtAudit_Indivial_Recommendation_Date_Closed.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date_closed);
        this.txtAudit_Indivial_Recommendation_Due_date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Due_date);
        this.txtAudit_Indivial_Recommendation_description.Text = objRecommendation.description.ToString();
        this.txtAudit_Indivial_Recommendation_Made_by.Text = objRecommendation.Made_by.ToString();
        this.txtAudit_Indivial_Recommendation_Number.Text = objRecommendation.Number.ToString();
        this.txtAuditEstimetedCost.Text = clsGeneral.GetStringValue(objRecommendation.Estimated_Cost);
        this.txtAuditFinalCost.Text = clsGeneral.GetStringValue(objRecommendation.Final_Cost);
        this.txtAudit_Indivial_Recommendation_Resolution.Text = objRecommendation.resolution.ToString();
        this.txtAudit_Indivial_Recommendation_Title.Text = objRecommendation.title.ToString();
        this.ddlAudit_Indivial_Recommendation_status.ClearSelection();
        this.ddlAudit_Indivial_Recommendation_status.Items.FindByValue(objRecommendation.status).Selected = true;
        this.btnAuditRecommendationRevort.Visible = true;
        this.btnAudit_RecommendationAudit.Visible = true;
        this.btnAudit_RecommendationAudit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Recommendation.aspx?id=" + RecommendationID.ToString() + "');");
        this.pnlAuditIndRecommendations.Visible = true;
        this.btnAudit_RecommendationSave.Text = "Save & View";

        clsGeneral.DisposeOf(objRecommendation);
    }

    /// <summary>
    /// Fill SPCC Data by SPCCID
    /// </summary>
    /// <param name="EditSPCCID"></param>
    private void LoadSPCCDataByID(int EditSPCCID)
    {
        Enviro_SPCC objSPCC = new Enviro_SPCC(EditSPCCID);

        this.txtPreparer.Text = objSPCC.Plan_Preparer.Trim();
        this.txtPlan_date.Text = clsGeneral.FormatDBNullDateToDisplay(objSPCC.Last_Date);
        this.txtPlan_Next_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSPCC.Next_Date);
        this.txtPlan_Next_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSPCC.Next_Report_Date);
        this.txtPlan_Phone.Text = objSPCC.Phone.Trim();
        this.txtPlan_Notes.Text = objSPCC.Notes.Trim();
        this.txtphone.Text = objSPCC.Phone;
        this.txtPlan_Cost.Text = string.Format("{0:N0}", objSPCC.Cost);

        clsGeneral.DisposeOf(objSPCC);

    }

    /// <summary>
    /// Fill SPCC recommendation data by SPCC Recommendation ID
    /// </summary>
    /// <param name="RecommendationID"></param>
    private void LoadSPCCRecommendationRecordByID(int EditSPCC_RecommendationID)
    {
        Enviro_Recommendations objRecommendation = new Enviro_Recommendations(EditSPCC_RecommendationID);

        this.txtPlan_Indivial_Recommendation_Assigned_to.Text = objRecommendation.Assigned_to.ToString();
        this.txtPlan_Indivial_Recommendation_Assigned_to_email.Text = objRecommendation.Assigned_to_email.ToString();
        this.txtPlan_Indivial_Recommendation_Assigned_to_phone.Text = objRecommendation.Assigned_to_phone.ToString();
        this.txtPlan_Indivial_Recommendation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date);
        this.txtPlan_Indivial_Recommendation_Date_Closed.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date_closed);
        this.txtPlan_Indivial_Recommendation_Due_date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Due_date);
        this.txtPlan_Indivial_Recommendation_description.Text = objRecommendation.description.ToString();
        this.txtPlan_Indivial_Recommendation_Made_by.Text = objRecommendation.Made_by.ToString();
        this.txtPlan_Indivial_Recommendation_Number.Text = objRecommendation.Number.ToString();
        this.txtSPCEstimatedCost.Text = clsGeneral.GetStringValue(objRecommendation.Estimated_Cost);
        this.txtSPCFinalCost.Text = clsGeneral.GetStringValue(objRecommendation.Final_Cost);
        this.txtPlan_Indivial_Recommendation_Resolution.Text = objRecommendation.resolution.ToString();
        this.txtPlan_Indivial_Recommendation_Title.Text = objRecommendation.title.ToString();
        this.ddlPlan_Indivial_Recommendation_status.ClearSelection();
        this.ddlPlan_Indivial_Recommendation_status.Items.FindByValue(objRecommendation.status).Selected = true;
        this.pnlSPCCIndRecommendation.Visible = true;
        this.btnPlan_RecommendationRevert.Visible = true;
        this.btnPlan_RecommendationAudit.Visible = true;
        this.btnPlan_RecommendationAudit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Recommendation.aspx?id=" + EditSPCC_RecommendationID.ToString() + "');");
        this.btnPlan_RecommendationSave.Text = "Save & View";

        clsGeneral.DisposeOf(objRecommendation);

    }

    /// <summary>
    /// Fill PhaseI Data by SPCC ID
    /// </summary>
    /// <param name="EditSPCCID"></param>
    private void LoadPhaseDataByID(int EditPhaseID)
    {
        Enviro_Phase1 objPhase = new Enviro_Phase1(EditPhaseID);

        this.txtPhase_Assessor.Text = objPhase.ASSESSOR.Trim();
        this.txtPhase_date.Text = clsGeneral.FormatDBNullDateToDisplay(objPhase.Last_Date);
        this.txtPhase_Next_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPhase.Next_Date);
        this.txtPhase_Next_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPhase.Next_Report_Date);
        this.txtPhase_phone.Text = objPhase.Phone.Trim();
        this.txtPhase_Notes.Text = objPhase.Notes.Trim();
        this.txtPhase_Cost.Text = string.Format("{0:N0}", objPhase.Cost);

        clsGeneral.DisposeOf(objPhase);
    }

    /// <summary>
    /// Fill EPA-Ids Data by EPA ID
    /// </summary>
    /// <param name="EditSPCCID"></param>
    private void LoadEPADatabyID(int EditEPAID)
    {
        EPA_IDs objEPA = new EPA_IDs(EditEPAID);

        this.txtEPAType.Text = objEPA.type;
        this.txtEPAID_Number.Text = objEPA.ID_Number;
        this.pnlEPAID.Visible = true;


        this.btnEPIAudit.Visible = true;
        this.btnEPIAudit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_EPA.aspx?id=" + EditEPAID.ToString() + "');");
        clsGeneral.DisposeOf(objEPA);
    }

    /// <summary>
    /// Fill Phase recommendation data by Phase ID
    /// </summary>
    /// <param name="RecommendationID"></param>
    private void LoadPhaseRecommendationRecordByID(int EditSPCC_RecommendationID)
    {
        Enviro_Recommendations objRecommendation = new Enviro_Recommendations(EditSPCC_RecommendationID);

        this.txtPhase_Indivial_Recommendation_Assigned_to.Text = objRecommendation.Assigned_to.ToString();
        this.txtPhase_Indivial_Recommendation_Assigned_to_email.Text = objRecommendation.Assigned_to_email.ToString();
        this.txtPhase_Indivial_Recommendation_Assigned_to_phone.Text = objRecommendation.Assigned_to_phone.ToString();
        this.txtPhase_Indivial_Recommendation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date);
        this.txtPhase_Indivial_Recommendation_Date_Closed.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date_closed);
        this.txtPhase_Indivial_Recommendation_Due_date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Due_date);
        this.txtPhase_Indivial_Recommendation_description.Text = objRecommendation.description.ToString();
        this.txtPhase_Indivial_Recommendation_Made_by.Text = objRecommendation.Made_by.ToString();
        this.txtPhase_Indivial_Recommendation_Number.Text = objRecommendation.Number.ToString();
        this.txtPhaseEstimatedCost.Text = clsGeneral.GetStringValue(objRecommendation.Estimated_Cost);
        this.txtPhaseFinalCost.Text = clsGeneral.GetStringValue(objRecommendation.Final_Cost);
        this.txtPhase_Indivial_Recommendation_Resolution.Text = objRecommendation.resolution.ToString();
        this.txtPhase_Indivial_Recommendation_Title.Text = objRecommendation.title.ToString();
        this.ddlPhase_Indivial_Recommendation_status.ClearSelection();
        this.ddlPhase_Indivial_Recommendation_status.Items.FindByValue(objRecommendation.status).Selected = true;
        this.pnlPhaseIndRecommendations.Visible = true;
        this.btnPhase_RecommendationRevert.Visible = true;
        this.btnPhase_RecommendationAudit.Visible = true;
        this.btnPhase_RecommendationAudit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Recommendation.aspx?id=" + EditSPCC_RecommendationID.ToString() + "');");
        this.btnPhase_RecommendationSave.Text = "Save & View";

        clsGeneral.DisposeOf(objRecommendation);

    }

    /// <summary>
    /// Clear All Filed of PhaseI Information , Attachment and recommendation
    /// </summary>
    private void ClearPhase()
    {
        // Set PhaseI ID and PhaseI Recommendation ID
        EditPhase1ID = -1;
        EditPhase1_RecommendationID = -1;

        // Clear All Fileds of Phase I
        ClearAllPhaseField();

        // Clear Phase I Recommendation Grid
        gvPhaseRecommendation.DataSource = null;
        gvPhaseRecommendation.DataBind();

        // Initialize PhaseI Attachement Detail Control
        PhaseAttachmentDetails.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Phase1, EditPhase1ID, true, 15);
        PhaseAttachmentDetails.Bind();

        this.pnlPhaseIndRecommendations.Visible = false;
        this.btnPhase_RecommendationRevert.Visible = false;
        this.btnPhase_RecommendationAudit.Visible = false;
        this.btnPhase_Audit.Visible = false;
        this.btnPhase_RecommendationSave.Text = "View";

    }

    /// <summary>
    /// Clear All Filed of SPCC Information , Attachment and recommendation
    /// </summary>
    private void ClearSPCC()
    {
        // Set SPCC ID and SPCC Recommendation ID
        EditSPCCID = -1;
        EditSPCC_RecommendationID = -1;

        // Clear All Fileds of SPCC
        ClearAllSPCCField();

        // Clear SPCC Recommendation Grid
        gvPlanRecommendation.DataSource = null;
        gvPlanRecommendation.DataBind();

        // Initialize SPCC Attachement Detail Control
        PlanAttachmentDetails.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_SPCC, EditSPCCID, true, 12);
        PlanAttachmentDetails.Bind();

        this.pnlSPCCIndRecommendation.Visible = false;
        this.btnPlan_RecommendationRevert.Visible = false;
        this.btnPlan_RecommendationAudit.Visible = false;
        this.btnPlan_Audit.Visible = false;
        this.btnPlan_RecommendationSave.Text = "View";
    }

    /// <summary>
    /// Clear All Filed of Audit Information , Attachment and recommendation
    /// </summary>
    private void ClearAudit()
    {
        EditAuditID = -1;
        EditAudit_RecommendationID = -1;

        // Clear All Fileds of Audit/inspection
        ClearAllAuditField();

        // Clear Audit/Inspection Recommendation Grid
        gvAuditRecommendation.DataSource = null;
        gvAuditRecommendation.DataBind();

        // Initialize Audit/Inspection Attachement Detail Control
        AuditAttachmentDetails.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Inspection, EditAuditID, true, 9);
        AuditAttachmentDetails.Bind();

        this.btnInspection_Audit.Visible = false;
        this.btnAuditRecommendationRevort.Visible = false;
        this.btnAudit_RecommendationAudit.Visible = false;
        this.pnlAuditIndRecommendations.Visible = false;
        this.btnAudit_RecommendationSave.Text = "View";

    }

    /// <summary>
    /// Clear All Filed of Equipment Information , Inadvertent Release , Attachment and recommendation
    /// </summary>
    private void ClearEquipment()
    {
        // Set Equipement ID and Equipement Recommendation ID
        EditEnviro_EquipmentID = -1;
        EditEquipement_RecommendationID = -1;

        // Clear All Fileds of Equipment
        ClearAllEquipmentField();

        // Clear Equipment Recommendation Grid
        gvEquipmentRecommendation.DataSource = null;
        gvEquipmentRecommendation.DataBind();

        // Initialize Equipment Attachement Detail Control
        EquipmentAttachmentDetail.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Equipment, EditEnviro_EquipmentID, true, 2);
        EquipmentAttachmentDetail.Bind();

        this.btnEquipmentAuditView.Visible = false;
        this.btnInadvertentAuditView.Visible = false;
        this.pnlAddEquipmentRecommendation.Visible = false;
        this.btnEquipmentRevert.Visible = false;
        this.btnRecommendationAudit.Visible = false;
        this.btnRecommendationSave.Text = "View";
    }

    /// <summary>
    /// Clear All Filed of Permit Information , Attachment and recommendation
    /// </summary>
    private void ClearPermit()
    {
        // Set Permit ID and Permit Recommendation ID
        EditPermitID = -1;
        EditPermit_RecommendationID = -1;

        // Clear All Fileds of Permit
        ClearAllPermitField();

        // Clear Permit Recommendation Grid
        gvPermitRecommendation.DataSource = null;
        gvPermitRecommendation.DataBind();

        // Initialize Permit Attachement Detail Control
        PermitAttachmentDetails.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Permit, EditPermitID, true, 6);
        PermitAttachmentDetails.Bind();

        this.btnPermitAudit.Visible = false;
        this.btnPermitRecommendationRevort.Visible = false;
        this.btnPermit_RecommendationAudit.Visible = false;
        this.pnlPermitIndRecommendation.Visible = false;
        this.btnPermit_RecommendationSave.Text = "View";
    }

    /// <summary>
    /// Clear Equipment Information and Inadvertent Release Fields
    /// </summary>
    private void ClearAllEquipmentField()
    {

        this.txtIdentification.Text = "";
        this.txtDate_of_Last_Service.Text = "";
        this.txtInsurer.Text = "";
        this.txtSingle_Event_Coverage.Text = "";
        this.txtMultiple_Event_Total_Coverage.Text = "";
        this.txtCoverage_Start_Date.Text = "";
        this.txtCoverage_End_Date.Text = "";
        this.txtConstructionOther.Text = "";
        this.txtDate_of_Last_TCLP.Text = "";
        this.txtInstallation_Date.Text = "";
        this.txtRemoval_Date.Text = "";
        this.txtClosure_Date.Text = "";
        this.txtLast_Inspection_Date.Text = "";
        this.txtNext_Inspection_Date.Text = "";
        this.txtInspection_Company.Text = "";
        this.txtInspection_Contact.Text = "";
        this.txtInspection_Phone.Text = "";
        this.txtRegistration_Number.Text = "";
        this.txtCertificate_Number.Text = "";
        this.txtPermit_Begin_Date.Text = "";
        this.txtPermit_End_Date.Text = "";
        this.txtConents_Other.Text = "";
        this.txtRelease_Equipment_Description.Text = "";
        this.txtMaterial_Other.Text = "";
        this.txtOther_Req_Descr.Text = "";
        this.txtNext_Report_Date.Text = "";
        this.txtNotes.Text = "";
        this.txtLeak_Detection_Type.Text = "";

        this.ddlContents.ClearSelection();
        this.ddlStatus.ClearSelection();
        this.ddlMaterial.ClearSelection();
        this.ddlConstruction.ClearSelection();
        this.ddlEquiepmentType.ClearSelection();

        this.ddlEquiepmentType.SelectedIndex = -1;
        this.ddlContents.SelectedIndex = -1;
        this.ddlStatus.SelectedIndex = -1;
        this.ddlMaterial.SelectedIndex = -1;
        this.ddlConstruction.SelectedIndex = -1;

        this.txtCapacity.Text = "";
        this.rdoRelease_Equipment_Present.SelectedIndex = -1;

        this.rdoOverfill_Protection.SelectedIndex = -1;
        this.rdoLeak_Detection.SelectedIndex = -1;
        this.rdoTCLP_on_File.SelectedIndex = -1;
        this.rdoFlows_to_POTW.SelectedIndex = -1;
        this.rdoRegistration_Required.SelectedIndex = -1;
        this.rdoOther_Req.SelectedIndex = -1;

        this.txtPlan_Revision_Date.Text = "";
        this.txtPlan_Effective_Date.Text = "";
        this.txtPlan_Expiration_Date.Text = "";
        this.txtPlan_ID.Text = "";
        this.txtPlan_Vendor.Text = "";
        this.txtPlan_Vendor_Contact.Text = "";
        this.txtPlan_Phone.Text = "";

    }

    /// <summary>
    /// Clear Phase Fields
    /// </summary>
    private void ClearAllPhaseField()
    {
        this.txtPhase_Assessor.Text = "";
        this.txtPhase_date.Text = "";
        this.txtPhase_Next_Date.Text = "";
        this.txtPhase_Next_Report_Date.Text = "";
        this.txtPhase_phone.Text = "";
        this.txtPhase_Notes.Text = "";
        this.txtPhase_Cost.Text = "";
    }

    /// <summary>
    /// Clear SPCC Fields
    /// </summary>
    private void ClearAllSPCCField()
    {
        this.txtPreparer.Text = "";
        this.txtPlan_date.Text = "";
        this.txtPlan_Next_Date.Text = "";
        this.txtPlan_Next_Report_Date.Text = "";
        this.txtPlan_Phone.Text = "";
        this.txtPlan_Notes.Text = "";
        this.txtphone.Text = "";
        this.txtPlan_Cost.Text = "";
    }

    /// <summary>
    /// Clear Audit/Inspection Fields.
    /// </summary>
    private void ClearAllAuditField()
    {
        this.txtAudit_Frequency.Text = "";
        this.txtAudit_Cost.Text = "";
        this.txtAudit_Last_Date.Text = "";
        this.txtAudit_Next_Date.Text = "";
        this.txtAudits_Next_Report_Date.Text = "";
        this.txtAudit_Notes.Text = "";
    }

    /// <summary>
    /// Clear Permis Fields.
    /// </summary>
    private void ClearAllPermitField()
    {
        this.txtPermit_Type.Text = "";
        this.rdoPermit_required.SelectedIndex = -1;
        this.txtPermit_Application_number.Text = "";
        this.txtPermit_Certificate_number.Text = "";
        this.txtPermit_Permit_Begin_date.Text = "";
        this.txtPermit_Permit_End_Date.Text = "";
        this.txtPermit_Last_Inspection_date.Text = "";
        this.txtPermit_Next_Inspection_Date.Text = "";
        this.txtPermit_Filing_date.Text = "";
        this.txtPermit_Next_Report_Date.Text = "";
        this.txtPermit_Notes.Text = "";
    }

    /// <summary>
    /// Clear All Equipment Recommendation Field
    /// </summary>
    private void ClearEquipmentRecommendation()
    {

        this.txtIndivial_Recommendation_Assigned_to.Text = "";
        this.txtIndivial_Recommendation_Assigned_to_email.Text = "";
        this.txtIndivial_Recommendation_Assigned_to_phone.Text = "";
        this.txtIndivial_Recommendation_Date.Text = "";
        this.txtIndivial_Recommendation_Date_Closed.Text = "";
        this.txtIndivial_Recommendation_Due_date.Text = "";
        this.txtIndivial_Recommendation_description.Text = "";
        this.txtIndivial_Recommendation_Made_by.Text = "";
        this.txtIndivial_Recommendation_Number.Text = "";
        this.txtIndivial_Recommendation_Resolution.Text = "";
        this.txtIndivial_Recommendation_Title.Text = "";
        this.ddlIndivial_Recommendation_status.ClearSelection();
        this.ddlIndivial_Recommendation_status.SelectedIndex = 0;
        this.btnEquipmentRevert.Visible = true;
        this.btnRecommendationAudit.Visible = true;
        this.pnlAddEquipmentRecommendation.Visible = true;
        this.btnRecommendationSave.Text = "Save & View";
    }

    /// <summary>
    /// Clear All Permit Recommendation Field
    /// </summary>
    private void ClearPermitRecommendation()
    {
        this.txtPermit_Indivial_Recommendation_Assigned_to.Text = "";
        this.txtPermit_Indivial_Recommendation_Assigned_to_email.Text = "";
        this.txtPermit_Indivial_Recommendation_Assigned_to_phone.Text = "";
        this.txtPermit_Indivial_Recommendation_Date.Text = "";
        this.txtPermit_Indivial_Recommendation_Date_Closed.Text = "";
        this.txtPermit_Indivial_Recommendation_Due_date.Text = "";
        this.txtPermit_Indivial_Recommendation_description.Text = "";
        this.txtPermit_Indivial_Recommendation_Made_by.Text = "";
        this.txtPermit_Indivial_Recommendation_Number.Text = "";
        this.txtPermit_Indivial_Recommendation_Resolution.Text = "";
        this.txtPermit_Indivial_Recommendation_Title.Text = "";
        this.ddlPermit_Indivial_Recommendation_status.ClearSelection();
        this.ddlPermit_Indivial_Recommendation_status.SelectedIndex = 0;
    }

    /// <summary>
    /// Clear All Audit Recommendation Field
    /// </summary>
    private void ClearAuditRecommendation()
    {
        this.txtAudit_Indivial_Recommendation_Assigned_to.Text = "";
        this.txtAudit_Indivial_Recommendation_Assigned_to_email.Text = "";
        this.txtAudit_Indivial_Recommendation_Assigned_to_phone.Text = "";
        this.txtAudit_Indivial_Recommendation_Date.Text = "";
        this.txtAudit_Indivial_Recommendation_Date_Closed.Text = "";
        this.txtAudit_Indivial_Recommendation_Due_date.Text = "";
        this.txtAudit_Indivial_Recommendation_description.Text = "";
        this.txtAudit_Indivial_Recommendation_Made_by.Text = "";
        this.txtAudit_Indivial_Recommendation_Number.Text = "";
        this.txtAudit_Indivial_Recommendation_Resolution.Text = "";
        this.txtAudit_Indivial_Recommendation_Title.Text = "";
        this.ddlAudit_Indivial_Recommendation_status.ClearSelection();
        this.ddlPermit_Indivial_Recommendation_status.SelectedIndex = 0;
    }

    /// <summary>
    /// Clear All SPCC-Plan Recommendation Field
    /// </summary>
    private void ClearPlanRecommendation()
    {
        this.txtPlan_Indivial_Recommendation_Assigned_to.Text = "";
        this.txtPlan_Indivial_Recommendation_Assigned_to_email.Text = "";
        this.txtPlan_Indivial_Recommendation_Assigned_to_phone.Text = "";
        this.txtPlan_Indivial_Recommendation_Date.Text = "";
        this.txtPlan_Indivial_Recommendation_Date_Closed.Text = "";
        this.txtPlan_Indivial_Recommendation_Due_date.Text = "";
        this.txtPlan_Indivial_Recommendation_description.Text = "";
        this.txtPlan_Indivial_Recommendation_Made_by.Text = "";
        this.txtPlan_Indivial_Recommendation_Number.Text = "";
        this.txtPlan_Indivial_Recommendation_Resolution.Text = "";
        this.txtPlan_Indivial_Recommendation_Title.Text = "";
        this.ddlPlan_Indivial_Recommendation_status.ClearSelection();
        this.ddlPlan_Indivial_Recommendation_status.SelectedIndex = 0;
    }

    /// <summary>
    /// Clear All SPCC-Plan Recommendation Field
    /// </summary>
    private void ClearPhaseRecommendation()
    {
        this.txtPhase_Indivial_Recommendation_Assigned_to.Text = "";
        this.txtPhase_Indivial_Recommendation_Assigned_to_email.Text = "";
        this.txtPhase_Indivial_Recommendation_Assigned_to_phone.Text = "";
        this.txtPhase_Indivial_Recommendation_Date.Text = "";
        this.txtPhase_Indivial_Recommendation_Date_Closed.Text = "";
        this.txtPhase_Indivial_Recommendation_Due_date.Text = "";
        this.txtPhase_Indivial_Recommendation_description.Text = "";
        this.txtPhase_Indivial_Recommendation_Made_by.Text = "";
        this.txtPhase_Indivial_Recommendation_Number.Text = "";
        this.txtPhase_Indivial_Recommendation_Resolution.Text = "";
        this.txtPhase_Indivial_Recommendation_Title.Text = "";
        this.ddlPhase_Indivial_Recommendation_status.ClearSelection();
        this.ddlPhase_Indivial_Recommendation_status.SelectedIndex = 0;

    }

    #endregion

    #region "Dynamic Validations"
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        #region "Equipment-Environmental"
        string strCtrlsIDs1 = "";
        string strMessages1 = "";

        DataTable dtFields = clsScreen_Validators.SelectByScreen(60).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();      
        if (dtFields.Select("LeftMenuIndex = 60").Length > 0)
        {           
            TreeNode node = trvMenu.FindNode("Equipment");    
            if (node != null)
            {
                if (node.ChildNodes[0].Text == "Equipment Information")
                {
                    string str = "Equipment Information" + "&nbsp;<span style='color: Red;position:absolute'> * &nbsp;</span>";
                    node.ChildNodes[0].Text = str;
                    node.ChildNodes[0].Expand();
                    node.Expand();//to expand
                }                 
            }
        }     
       
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Identification": strCtrlsIDs1 += txtIdentification.ClientID + ","; strMessages1 += "Please enter Identification" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Type": strCtrlsIDs1 += ddlEquiepmentType.ClientID + ","; strMessages1 += "Please select Type" + ","; Span2.Style["display"] = "inline-block"; break;
                //if tblTypeInfo.style.display != "none"
                case "Contents": strCtrlsIDs1 += ddlContents.ClientID + ","; strMessages1 += "Please enter Contents" + ","; Span131.Style["display"] = "inline-block"; break;
                case "Contents-other": strCtrlsIDs1 += txtConents_Other.ClientID + ","; strMessages1 += "Please enter Contents-other" + ","; Span132.Style["display"] = "inline-block"; break;
                case "Capacity(Gallons)": strCtrlsIDs1 += txtCapacity.ClientID + ","; strMessages1 += "Please enter Capacity(Gallons)" + ","; Span133.Style["display"] = "inline-block"; break;
                case "status": strCtrlsIDs1 += ddlStatus.ClientID + ","; strMessages1 += "Please select status" + ","; Span134.Style["display"] = "inline-block"; break;
                case "Material": strCtrlsIDs1 += ddlMaterial.ClientID + ","; strMessages1 += "Please select Material" + ","; Span135.Style["display"] = "inline-block"; break;
                case "Material-Other": strCtrlsIDs1 += txtMaterial_Other.ClientID + ","; strMessages1 += "Please enter Material-Other" + ","; Span136.Style["display"] = "inline-block"; break;
                case "Construction": strCtrlsIDs1 += ddlConstruction.ClientID + ","; strMessages1 += "Please select Construction" + ","; Span137.Style["display"] = "inline-block"; break;
                case "Construction-Other": strCtrlsIDs1 += txtConstructionOther.ClientID + ","; strMessages1 += "Please enter Construction-Other" + ","; Span138.Style["display"] = "inline-block"; break;
                case "Release Equipment Description": strCtrlsIDs1 += txtRelease_Equipment_Description.ClientID + ","; strMessages1 += "Please enter Release Equipment Description" + ","; Span139.Style["display"] = "inline-block"; break;
                //end

                case "Leak Detection Type": strCtrlsIDs1 += txtLeak_Detection_Type.ClientID + ","; strMessages1 += "Please enter Leak Detection Type" + ","; Span3.Style["display"] = "inline-block"; break;
                case "Insurer": strCtrlsIDs1 += txtInsurer.ClientID + ","; strMessages1 += "Please enter Insurer" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Single Event Coverage": strCtrlsIDs1 += txtSingle_Event_Coverage.ClientID + ","; strMessages1 += "Please enter Single Event Coverage" + ","; Span5.Style["display"] = "inline-block"; break;
                case "Multiple Event/Total Coverage": strCtrlsIDs1 += txtMultiple_Event_Total_Coverage.ClientID + ","; strMessages1 += "Please enter Multiple Event/Total Coverage" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Coverage Start Date": strCtrlsIDs1 += txtCoverage_Start_Date.ClientID + ","; strMessages1 += "Please enter Coverage Start Date" + ","; Span7.Style["display"] = "inline-block"; break;
                case "Coverage End Date": strCtrlsIDs1 += txtCoverage_End_Date.ClientID + ","; strMessages1 += "Please enter Coverage End Date" + ","; Span8.Style["display"] = "inline-block"; break;
                //if tblOilWater.style.display != "none"
                case "Date of Last Service": strCtrlsIDs1 += txtDate_of_Last_Service.ClientID + ","; strMessages1 += "Please enter Date of Last Service" + ","; Span140.Style["display"] = "inline-block"; break;
                case "Date of Last TCLP": strCtrlsIDs1 += txtDate_of_Last_TCLP.ClientID + ","; strMessages1 += "Please enter Date of Last TCLP" + ","; Span141.Style["display"] = "inline-block"; break;
                //end

                case "Installation Date": strCtrlsIDs1 += txtInstallation_Date.ClientID + ","; strMessages1 += "Please enter Installation Date" + ","; Span9.Style["display"] = "inline-block"; break;
                case "Removal Date": strCtrlsIDs1 += txtRemoval_Date.ClientID + ","; strMessages1 += "Please enter Removal Date" + ","; Span10.Style["display"] = "inline-block"; break;
                case "Closure Date": strCtrlsIDs1 += txtClosure_Date.ClientID + ","; strMessages1 += "Please enter Closure Date" + ","; Span11.Style["display"] = "inline-block"; break;
                case "Last Inspection Date": strCtrlsIDs1 += txtLast_Inspection_Date.ClientID + ","; strMessages1 += "Please enter Last Inspection Date" + ","; Span12.Style["display"] = "inline-block"; break;
                case "Next Inspection Date": strCtrlsIDs1 += txtNext_Inspection_Date.ClientID + ","; strMessages1 += "Please enter Next Inspection Date" + ","; Span13.Style["display"] = "inline-block"; break;
                case "Inspection Company": strCtrlsIDs1 += txtInspection_Company.ClientID + ","; strMessages1 += "Please enter Inspection Company" + ","; Span14.Style["display"] = "inline-block"; break;
                case "Inspection Company Contact Name": strCtrlsIDs1 += txtInspection_Contact.ClientID + ","; strMessages1 += "Please enter Inspection Company Contact Name" + ","; Span15.Style["display"] = "inline-block"; break;
                case "Inspection Company Contact Telephone Number": strCtrlsIDs1 += txtInspection_Phone.ClientID + ","; strMessages1 += "Please enter Inspection Company Contact Telephone Number" + ","; Span16.Style["display"] = "inline-block"; break;
                case "Registration Number": strCtrlsIDs1 += txtRegistration_Number.ClientID + ","; strMessages1 += "Please enter Registration Number" + ","; Span17.Style["display"] = "inline-block"; break;
                case "Certificate Number": strCtrlsIDs1 += txtCertificate_Number.ClientID + ","; strMessages1 += "Please enter Certificate Number" + ","; Span18.Style["display"] = "inline-block"; break;
                case "Permit Begin Date": strCtrlsIDs1 += txtPermit_Begin_Date.ClientID + ","; strMessages1 += "Please enter Permit Begin Date" + ","; Span19.Style["display"] = "inline-block"; break;
                case "Permit End Date": strCtrlsIDs1 += txtPermit_End_Date.ClientID + ","; strMessages1 += "Please enter Permit End Date" + ","; Span20.Style["display"] = "inline-block"; break;
                case "Description of Other Reporting Requirements": strCtrlsIDs1 += txtOther_Req_Descr.ClientID + ","; strMessages1 += "Please enter Description of Other Reporting Requirements" + ","; Span21.Style["display"] = "inline-block"; break;
                case "Next Report Date": strCtrlsIDs1 += txtNext_Report_Date.ClientID + ","; strMessages1 += "Please enter Next Report Date" + ","; Span22.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDs1 += txtNotes.ClientID + ","; strMessages1 += "Please enter Notes" + ","; Span23.Style["display"] = "inline-block"; break;
            }
            #endregion
        }        

        strCtrlsIDs1 = strCtrlsIDs1.TrimEnd(',');
        strMessages1 = strMessages1.TrimEnd(',');

        hdnControlIDs1.Value = strCtrlsIDs1;
        hdnErrorMsgs1.Value = strMessages1;
        #endregion

        #region "Equipment-Inadvertent Release"
        string strCtrlsIDs2 = "";
        string strMessages2 = "";

        dtFields = clsScreen_Validators.SelectByScreen(61).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        if (dtFields.Select("LeftMenuIndex = 61").Length > 0)
        {
            TreeNode node = trvMenu.FindNode("Equipment");
            if (node != null)
            {
                if (node.ChildNodes[1].Text == "Inadvertent Release")
                {
                    string str = "Inadvertent Release" + "&nbsp;<span style='color: Red;position:absolute'> * &nbsp;</span>";
                    node.ChildNodes[1].Text = str;
                    node.ChildNodes[1].Expand();
                    node.Expand();//to expand
                }
            }
        }            

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Plan Identification": strCtrlsIDs2 += txtPlan_ID.ClientID + ","; strMessages2 += "Please enter Plan Identification" + ","; Span24.Style["display"] = "inline-block"; break;
                case "Effective Date": strCtrlsIDs2 += txtPlan_Effective_Date.ClientID + ","; strMessages2 += "Please enter Effective Date" + ","; Span25.Style["display"] = "inline-block"; break;
                case "Expiration Date": strCtrlsIDs2 += txtPlan_Expiration_Date.ClientID + ","; strMessages2 += "Please enter Expiration Date" + ","; Span26.Style["display"] = "inline-block"; break;
                case "Last Revision Date": strCtrlsIDs2 += txtPlan_Revision_Date.ClientID + ","; strMessages2 += "Please enter Last Revision Date" + ","; Span27.Style["display"] = "inline-block"; break;
                case "Vendor": strCtrlsIDs2 += txtPlan_Vendor.ClientID + ","; strMessages2 += "Please enter Vendor" + ","; Span28.Style["display"] = "inline-block"; break;
                case "Vendor Contact Name": strCtrlsIDs2 += txtPlan_Vendor_Contact.ClientID + ","; strMessages2 += "Please enter Vendor Contact Name" + ","; Span29.Style["display"] = "inline-block"; break;
                case "Vendor Contact Telephone Number": strCtrlsIDs2 += txtPlan_Phone.ClientID + ","; strMessages2 += "Please enter Vendor Contact Telephone Number" + ","; Span30.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        strCtrlsIDs2 = strCtrlsIDs2.TrimEnd(',');
        strMessages2 = strMessages2.TrimEnd(',');

        hdnControlIDs2.Value = strCtrlsIDs2;
        hdnErrorMsgs2.Value = strMessages2;
        #endregion

        #region "Permit Information"
        string strCtrlsIDs4 = "";
        string strMessages4 = "";

        dtFields = clsScreen_Validators.SelectByScreen(63).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        if (dtFields.Select("LeftMenuIndex = 63").Length > 0)
        {
            TreeNode node = trvMenu.FindNode("Permit");
            if (node != null)
            {
                if (node.ChildNodes[0].Text == "Permit Information")
                {
                    string str = "Permit Information" + "&nbsp;<span style='color: Red;position:absolute'> * &nbsp;</span>";
                    node.ChildNodes[0].Text = str;
                    node.ChildNodes[0].Expand();
                    node.Expand();//to expand
                }
            }
        }          

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Type": strCtrlsIDs4 += txtPermit_Type.ClientID + ","; strMessages4 += "Please enter Type" + ","; Span45.Style["display"] = "inline-block"; break;
                case "Application Regulation Number": strCtrlsIDs4 += txtPermit_Application_number.ClientID + ","; strMessages4 += "Please enter Application Regulation Number" + ","; Span46.Style["display"] = "inline-block"; break;
                case "Certificate number": strCtrlsIDs4 += txtPermit_Certificate_number.ClientID + ","; strMessages4 += "Please enter Certificate number" + ","; Span47.Style["display"] = "inline-block"; break;
                case "Filing date": strCtrlsIDs4 += txtPermit_Filing_date.ClientID + ","; strMessages4 += "Please enter Filing date" + ","; Span48.Style["display"] = "inline-block"; break;
                case "Permit Begin Date": strCtrlsIDs4 += txtPermit_Permit_Begin_date.ClientID + ","; strMessages4 += "Please enter Permit Begin Date" + ","; Span49.Style["display"] = "inline-block"; break;
                case "Permit End Date": strCtrlsIDs4 += txtPermit_Permit_End_Date.ClientID + ","; strMessages4 += "Please enter Permit End Date" + ","; Span50.Style["display"] = "inline-block"; break;
                case "Last Inspection date": strCtrlsIDs4 += txtPermit_Last_Inspection_date.ClientID + ","; strMessages4 += "Please enter Last Inspection date" + ","; Span51.Style["display"] = "inline-block"; break;
                case "Next Inspection Date": strCtrlsIDs4 += txtPermit_Next_Inspection_Date.ClientID + ","; strMessages4 += "Please enter Next Inspection Date" + ","; Span52.Style["display"] = "inline-block"; break;
                case "Next Report Date": strCtrlsIDs4 += txtPermit_Next_Report_Date.ClientID + ","; strMessages4 += "Please enter Next Report Date" + ","; Span53.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDs4 += txtPermit_Notes.ClientID + ","; strMessages4 += "Please enter Notes" + ","; Span54.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        strCtrlsIDs4 = strCtrlsIDs4.TrimEnd(',');
        strMessages4 = strMessages4.TrimEnd(',');

        hdnControlIDs4.Value = strCtrlsIDs4;
        hdnErrorMsgs4.Value = strMessages4;
        #endregion

        #region "Audit/Inspections Information"
        string strCtrlsIDs6 = "";
        string strMessages6 = "";

        dtFields = clsScreen_Validators.SelectByScreen(64).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        if (dtFields.Select("LeftMenuIndex = 64").Length > 0)
        {            
            TreeNode node = trvMenu.FindNode("Audit Inspections");
            if (node != null)
            {
                if (node.ChildNodes[0].Text == "Audit/Inspections Information")
                {
                    string str = "Audit/Inspections Information" + "&nbsp;<span style='color: Red;position:absolute'> * &nbsp;</span>";
                    node.ChildNodes[0].Text = str;
                    node.ChildNodes[0].Expand();
                    node.Expand();//to expand
                }
            }
        }  
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Frequency": strCtrlsIDs6 += txtAudit_Frequency.ClientID + ","; strMessages6 += "Please enter Frequency" + ","; Span69.Style["display"] = "inline-block"; break;
                case "Last Inspection Date": strCtrlsIDs6 += txtAudit_Last_Date.ClientID + ","; strMessages6 += "Please enter Last Inspection Date" + ","; Span70.Style["display"] = "inline-block"; break;
                case "Next Inspection Date": strCtrlsIDs6 += txtAudit_Next_Date.ClientID + ","; strMessages6 += "Please enter Next Inspection Date" + ","; Span71.Style["display"] = "inline-block"; break;
                case "Next Report Date": strCtrlsIDs6 += txtAudits_Next_Report_Date.ClientID + ","; strMessages6 += "Please enter Next Report Date" + ","; Span72.Style["display"] = "inline-block"; break;
                case "Cost": strCtrlsIDs6 += txtAudit_Cost.ClientID + ","; strMessages6 += "Please enter Cost" + ","; Span73.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDs6 += txtAudit_Notes.ClientID + ","; strMessages6 += "Please enter Notes" + ","; Span74.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        strCtrlsIDs6 = strCtrlsIDs6.TrimEnd(',');
        strMessages6 = strMessages6.TrimEnd(',');

        hdnControlIDs6.Value = strCtrlsIDs6;
        hdnErrorMsgs6.Value = strMessages6;
        #endregion

        #region "SPCC Information"
        string strCtrlsIDs8 = "";
        string strMessages8 = "";

        dtFields = clsScreen_Validators.SelectByScreen(65).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        if (dtFields.Select("LeftMenuIndex = 65").Length > 0)
        {
            TreeNode node = trvMenu.FindNode("SPCC");
            if (node != null)
            {
                if (node.ChildNodes[0].Text == "SPCC Information")
                {
                    string str = "SPCC Information" + "&nbsp;<span style='color: Red;position:absolute'> * &nbsp;</span>";
                    node.ChildNodes[0].Text = str;
                    node.ChildNodes[0].Expand();
                    node.Expand();//to expand
                }
            }
        }  
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Plan Preparer": strCtrlsIDs8 += txtPreparer.ClientID + ","; strMessages8 += "Please enter Plan Preparer" + ","; Span89.Style["display"] = "inline-block"; break;
                case "Telephone": strCtrlsIDs8 += txtphone.ClientID + ","; strMessages8 += "Please enter Telephone" + ","; Span90.Style["display"] = "inline-block"; break;
                case "Plan Date": strCtrlsIDs8 += txtPlan_date.ClientID + ","; strMessages8 += "Please enter Plan Date" + ","; Span91.Style["display"] = "inline-block"; break;
                case "Next Review Date": strCtrlsIDs8 += txtPlan_Next_Date.ClientID + ","; strMessages8 += "Please enter Next Review Date" + ","; Span92.Style["display"] = "inline-block"; break;
                case "Next Report Date": strCtrlsIDs8 += txtPlan_Next_Report_Date.ClientID + ","; strMessages8 += "Please enter Next Report Date" + ","; Span93.Style["display"] = "inline-block"; break;
                case "Cost": strCtrlsIDs8 += txtPlan_Cost.ClientID + ","; strMessages8 += "Please enter Cost" + ","; Span94.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDs8 += txtPlan_Notes.ClientID + ","; strMessages8 += "Please enter Notes" + ","; Span95.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        strCtrlsIDs8 = strCtrlsIDs8.TrimEnd(',');
        strMessages8 = strMessages8.TrimEnd(',');

        hdnControlIDs8.Value = strCtrlsIDs8;
        hdnErrorMsgs8.Value = strMessages8;
        #endregion

        #region "Phase I Information"
        string strCtrlsIDs10 = "";
        string strMessages10 = "";

        dtFields = clsScreen_Validators.SelectByScreen(66).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        if (dtFields.Select("LeftMenuIndex = 66").Length > 0)
        {
            TreeNode node = trvMenu.FindNode("Phase I");
            if (node != null)
            {
                if (node.ChildNodes[0].Text == "Phase I Information")
                {
                    string str = "Phase I Information" + "&nbsp;<span style='color: Red;position:absolute'> * &nbsp;</span>";
                    node.ChildNodes[0].Text = str;
                    node.ChildNodes[0].Expand();
                    node.Expand();//to expand
                }
            }
        }  
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Assessor": strCtrlsIDs10 += txtPhase_Assessor.ClientID + ","; strMessages10 += "Please enter Assessor" + ","; Span110.Style["display"] = "inline-block"; break;
                case "Telephone": strCtrlsIDs10 += txtPhase_phone.ClientID + ","; strMessages10 += "Please enter Telephone" + ","; Span111.Style["display"] = "inline-block"; break;
                case "Report Date": strCtrlsIDs10 += txtPhase_date.ClientID + ","; strMessages10 += "Please enter Report Date" + ","; Span112.Style["display"] = "inline-block"; break;
                case "Next Review Date": strCtrlsIDs10 += txtPhase_Next_Date.ClientID + ","; strMessages10 += "Please enter Next Review Date" + ","; Span113.Style["display"] = "inline-block"; break;
                case "Next Report Date": strCtrlsIDs10 += txtPhase_Next_Report_Date.ClientID + ","; strMessages10 += "Please enter Next Report Date" + ","; Span114.Style["display"] = "inline-block"; break;
                case "Cost": strCtrlsIDs10 += txtPhase_Cost.ClientID + ","; strMessages10 += "Please enter Cost" + ","; Span115.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDs10 += txtPhase_Notes.ClientID + ","; strMessages10 += "Please enter Notes" + ","; Span116.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        strCtrlsIDs10 = strCtrlsIDs10.TrimEnd(',');
        strMessages10 = strMessages10.TrimEnd(',');

        hdnControlIDs10.Value = strCtrlsIDs10;
        hdnErrorMsgs10.Value = strMessages10;
        #endregion

        #region "Recommendations"
        string strCtrlsIDs3 = "";
        string strMessages3 = "";
        string strCtrlsIDs5 = "";
        string strMessages5 = "";
        string strCtrlsIDs7 = "";
        string strMessages7 = "";
        string strCtrlsIDs9 = "";
        string strMessages9 = "";
        string strCtrlsIDs11 = "";
        string strMessages11 = "";

        dtFields = clsScreen_Validators.SelectByScreen(62).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        if (dtFields.Select("LeftMenuIndex = 62").Length > 0)
        {
            TreeNode node = trvMenu.FindNode("Equipment");
            if (node != null)
            {
                if (node.ChildNodes[3].Text == "Recommendations")
                {
                    string str = "Recommendations" + "&nbsp;<span style='color: Red;position:absolute'> * &nbsp;</span>";
                    node.ChildNodes[3].Text = str;
                    node.ChildNodes[3].Expand();
                    node.Expand();//to expand
                }
            }
            TreeNode node1 = trvMenu.FindNode("Permit");
            if (node1 != null)
            {
                if (node1.ChildNodes[2].Text == "Recommendations")
                {
                    string str = "Recommendations" + "&nbsp;<span style='color: Red;position:absolute'> * &nbsp;</span>";
                    node1.ChildNodes[2].Text = str;
                    node1.ChildNodes[2].Expand();
                    node1.Expand();//to expand
                }
            }
            TreeNode node2 = trvMenu.FindNode("SPCC");
            if (node2 != null)
            {
                if (node2.ChildNodes[2].Text == "Recommendations")
                {
                    string str = "Recommendations" + "&nbsp;<span style='color: Red;position:absolute'> * &nbsp;</span>";
                    node2.ChildNodes[2].Text = str;
                    node2.ChildNodes[2].Expand();
                    node2.Expand();//to expand
                }
            }
            TreeNode node3 = trvMenu.FindNode("Phase I");
            if (node3 != null)
            {
                if (node3.ChildNodes[2].Text == "Recommendations")
                {
                    string str = "Recommendations" + "&nbsp;<span style='color: Red;position:absolute'> * &nbsp;</span>";
                    node3.ChildNodes[2].Text = str;
                    node3.ChildNodes[2].Expand();
                    node3.Expand();//to expand
                }
            }
            TreeNode node4 = trvMenu.FindNode("Audit Inspections");
            if (node4 != null)
            {
                if (node4.ChildNodes[2].Text == "Recommendations")
                {
                    string str = "Recommendations" + "&nbsp;<span style='color: Red;position:absolute'> * &nbsp;</span>";
                    node4.ChildNodes[2].Text = str;
                    node4.ChildNodes[2].Expand();
                    node4.Expand();//to expand
                }
            }
        }          
        #region "Equipment-Recommendations"
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date of visit": strCtrlsIDs3 += txtIndivial_Recommendation_Date.ClientID + ","; strMessages3 += "Please enter Date of visit" + ","; Span31.Style["display"] = "inline-block"; break;
                case "Recommendation Number": strCtrlsIDs3 += txtIndivial_Recommendation_Number.ClientID + ","; strMessages3 += "Please enter Recommendation Number" + ","; Span32.Style["display"] = "inline-block"; break;
                case "Recommendation Made by": strCtrlsIDs3 += txtIndivial_Recommendation_Made_by.ClientID + ","; strMessages3 += "Please enter Recommendation Made by" + ","; Span33.Style["display"] = "inline-block"; break;
                case "Status": strCtrlsIDs3 += ddlIndivial_Recommendation_status.ClientID + ","; strMessages3 += "Please select Status" + ","; Span34.Style["display"] = "inline-block"; break;
                case "Title": strCtrlsIDs3 += txtIndivial_Recommendation_Title.ClientID + ","; strMessages3 += "Please enter Title" + ","; Span35.Style["display"] = "inline-block"; break;
                case "Detailed Recommendation Description": strCtrlsIDs3 += txtIndivial_Recommendation_description.ClientID + ","; strMessages3 += "Please enter Detailed Recommendation Description" + ","; Span36.Style["display"] = "inline-block"; break;
                case "Assigned To Name": strCtrlsIDs3 += txtIndivial_Recommendation_Assigned_to.ClientID + ","; strMessages3 += "Please enter Assigned To Name" + ","; Span37.Style["display"] = "inline-block"; break;
                case "Due date": strCtrlsIDs3 += txtIndivial_Recommendation_Due_date.ClientID + ","; strMessages3 += "Please enter Due date" + ","; Span38.Style["display"] = "inline-block"; break;
                case "Assigned To Telephone": strCtrlsIDs3 += txtIndivial_Recommendation_Assigned_to_phone.ClientID + ","; strMessages3 += "Please enter Assigned To Telephone" + ","; Span39.Style["display"] = "inline-block"; break;
                case "Assigned To E-mail": strCtrlsIDs3 += txtIndivial_Recommendation_Assigned_to_email.ClientID + ","; strMessages3 += "Please enter Assigned To E-mail" + ","; Span40.Style["display"] = "inline-block"; break;
                case "Estimated Cost $": strCtrlsIDs3 += txtEstimatedCost.ClientID + ","; strMessages3 += "Please enter Estimated Cost $" + ","; Span41.Style["display"] = "inline-block"; break;
                case "Final Cost $": strCtrlsIDs3 += txtFinalCost.ClientID + ","; strMessages3 += "Please enter Final Cost $" + ","; Span42.Style["display"] = "inline-block"; break;
                case "Resolution": strCtrlsIDs3 += txtIndivial_Recommendation_Resolution.ClientID + ","; strMessages3 += "Please enter Resolution" + ","; Span43.Style["display"] = "inline-block"; break;
                case "Date Closed": strCtrlsIDs3 += txtIndivial_Recommendation_Date_Closed.ClientID + ","; strMessages3 += "Please enter Date Closed" + ","; Span44.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        #endregion

        #region "Permit-Recommendations"
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date of visit": strCtrlsIDs5 += txtPermit_Indivial_Recommendation_Date.ClientID + ","; strMessages5 += "Please enter Date of visit" + ","; Span55.Style["display"] = "inline-block"; break;
                case "Recommendation Number": strCtrlsIDs5 += txtPermit_Indivial_Recommendation_Number.ClientID + ","; strMessages5 += "Please enter Recommendation Number" + ","; Span56.Style["display"] = "inline-block"; break;
                case "Recommendation Made by": strCtrlsIDs5 += txtPermit_Indivial_Recommendation_Made_by.ClientID + ","; strMessages5 += "Please enter Recommendation Made by" + ","; Span57.Style["display"] = "inline-block"; break;
                case "Status": strCtrlsIDs5 += ddlPermit_Indivial_Recommendation_status.ClientID + ","; strMessages5 += "Please select Status" + ","; Span58.Style["display"] = "inline-block"; break;
                case "Title": strCtrlsIDs5 += txtPermit_Indivial_Recommendation_Title.ClientID + ","; strMessages5 += "Please enter Title" + ","; Span59.Style["display"] = "inline-block"; break;
                case "Detailed Recommendation Description": strCtrlsIDs5 += txtPermit_Indivial_Recommendation_description.ClientID + ","; strMessages5 += "Please enter Detailed Recommendation Description" + ","; Span60.Style["display"] = "inline-block"; break;
                case "Assigned To Name": strCtrlsIDs5 += txtPermit_Indivial_Recommendation_Assigned_to.ClientID + ","; strMessages5 += "Please enter Assigned To Name" + ","; Span61.Style["display"] = "inline-block"; break;
                case "Due date": strCtrlsIDs5 += txtPermit_Indivial_Recommendation_Due_date.ClientID + ","; strMessages5 += "Please enter Due date" + ","; Span62.Style["display"] = "inline-block"; break;
                case "Assigned To Telephone": strCtrlsIDs5 += txtPermit_Indivial_Recommendation_Assigned_to_phone.ClientID + ","; strMessages5 += "Please enter Assigned To Telephone" + ","; Span63.Style["display"] = "inline-block"; break;
                case "Assigned To E-mail": strCtrlsIDs5 += txtPermit_Indivial_Recommendation_Assigned_to_email.ClientID + ","; strMessages5 += "Please enter Assigned To E-mail" + ","; Span64.Style["display"] = "inline-block"; break;
                case "Estimated Cost $": strCtrlsIDs5 += txtPermitEstimetedCost.ClientID + ","; strMessages5 += "Please enter Estimated Cost $" + ","; Span65.Style["display"] = "inline-block"; break;
                case "Final Cost $": strCtrlsIDs5 += txtPermitFinalCost.ClientID + ","; strMessages5 += "Please enter Final Cost $" + ","; Span66.Style["display"] = "inline-block"; break;
                case "Resolution": strCtrlsIDs5 += txtPermit_Indivial_Recommendation_Resolution.ClientID + ","; strMessages5 += "Please enter Resolution" + ","; Span67.Style["display"] = "inline-block"; break;
                case "Date Closed": strCtrlsIDs5 += txtPermit_Indivial_Recommendation_Date_Closed.ClientID + ","; strMessages5 += "Please enter Date Closed" + ","; Span68.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        #endregion

        #region "Audit-Recommendations"
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date of visit": strCtrlsIDs7 += txtAudit_Indivial_Recommendation_Date.ClientID + ","; strMessages7 += "Please enter Date of visit" + ","; Span75.Style["display"] = "inline-block"; break;
                case "Recommendation Number": strCtrlsIDs7 += txtAudit_Indivial_Recommendation_Number.ClientID + ","; strMessages7 += "Please enter Recommendation Number" + ","; Span76.Style["display"] = "inline-block"; break;
                case "Recommendation Made by": strCtrlsIDs7 += txtAudit_Indivial_Recommendation_Made_by.ClientID + ","; strMessages7 += "Please enter Recommendation Made by" + ","; Span77.Style["display"] = "inline-block"; break;
                case "Status": strCtrlsIDs7 += ddlAudit_Indivial_Recommendation_status.ClientID + ","; strMessages7 += "Please select Status" + ","; Span78.Style["display"] = "inline-block"; break;
                case "Title": strCtrlsIDs7 += txtAudit_Indivial_Recommendation_Title.ClientID + ","; strMessages7 += "Please enter Title" + ","; Span79.Style["display"] = "inline-block"; break;
                case "Detailed Recommendation Description": strCtrlsIDs7 += txtAudit_Indivial_Recommendation_description.ClientID + ","; strMessages7 += "Please enter Detailed Recommendation Description" + ","; Span80.Style["display"] = "inline-block"; break;
                case "Assigned To Name": strCtrlsIDs7 += txtAudit_Indivial_Recommendation_Assigned_to.ClientID + ","; strMessages7 += "Please enter Assigned To Name" + ","; Span81.Style["display"] = "inline-block"; break;
                case "Due date": strCtrlsIDs7 += txtAudit_Indivial_Recommendation_Due_date.ClientID + ","; strMessages7 += "Please enter Due date" + ","; Span82.Style["display"] = "inline-block"; break;
                case "Assigned To Telephone": strCtrlsIDs7 += txtAudit_Indivial_Recommendation_Assigned_to_phone.ClientID + ","; strMessages7 += "Please enter Assigned To Telephone" + ","; Span83.Style["display"] = "inline-block"; break;
                case "Assigned To E-mail": strCtrlsIDs7 += txtIndivial_Recommendation_Assigned_to_email.ClientID + ","; strMessages7 += "Please enter Assigned To E-mail" + ","; Span84.Style["display"] = "inline-block"; break;
                case "Estimated Cost $": strCtrlsIDs7 += txtAuditEstimetedCost.ClientID + ","; strMessages7 += "Please enter Estimated Cost $" + ","; Span85.Style["display"] = "inline-block"; break;
                case "Final Cost $": strCtrlsIDs7 += txtAuditFinalCost.ClientID + ","; strMessages7 += "Please enter Final Cost $" + ","; Span86.Style["display"] = "inline-block"; break;
                case "Resolution": strCtrlsIDs7 += txtAudit_Indivial_Recommendation_Resolution.ClientID + ","; strMessages7 += "Please enter Resolution" + ","; Span87.Style["display"] = "inline-block"; break;
                case "Date Closed": strCtrlsIDs7 += txtAudit_Indivial_Recommendation_Date_Closed.ClientID + ","; strMessages7 += "Please enter Date Closed" + ","; Span88.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        #endregion

        #region "SPCC-Recommendations"
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date of visit": strCtrlsIDs9 += txtPlan_Indivial_Recommendation_Date.ClientID + ","; strMessages9 += "Please enter Date of visit" + ","; Span96.Style["display"] = "inline-block"; break;
                case "Recommendation Number": strCtrlsIDs9 += txtPlan_Indivial_Recommendation_Number.ClientID + ","; strMessages9 += "Please enter Recommendation Number" + ","; Span97.Style["display"] = "inline-block"; break;
                case "Recommendation Made by": strCtrlsIDs9 += txtPlan_Indivial_Recommendation_Made_by.ClientID + ","; strMessages9 += "Please enter Recommendation Made by" + ","; Span98.Style["display"] = "inline-block"; break;
                case "Status": strCtrlsIDs9 += ddlPlan_Indivial_Recommendation_status.ClientID + ","; strMessages9 += "Please select Status" + ","; Span99.Style["display"] = "inline-block"; break;
                case "Title": strCtrlsIDs9 += txtPlan_Indivial_Recommendation_Title.ClientID + ","; strMessages9 += "Please enter Title" + ","; Span100.Style["display"] = "inline-block"; break;
                case "Detailed Recommendation Description": strCtrlsIDs9 += txtPlan_Indivial_Recommendation_description.ClientID + ","; strMessages9 += "Please enter Detailed Recommendation Description" + ","; Span101.Style["display"] = "inline-block"; break;
                case "Assigned To Name": strCtrlsIDs9 += txtPlan_Indivial_Recommendation_Assigned_to.ClientID + ","; strMessages9 += "Please enter Assigned To Name" + ","; Span102.Style["display"] = "inline-block"; break;
                case "Due date": strCtrlsIDs9 += txtPlan_Indivial_Recommendation_Due_date.ClientID + ","; strMessages9 += "Please enter Due date" + ","; Span103.Style["display"] = "inline-block"; break;
                case "Assigned To Telephone": strCtrlsIDs9 += txtPlan_Indivial_Recommendation_Assigned_to_phone.ClientID + ","; strMessages9 += "Please enter Assigned To Telephone" + ","; Span104.Style["display"] = "inline-block"; break;
                case "Assigned To E-mail": strCtrlsIDs9 += txtPlan_Indivial_Recommendation_Assigned_to_email.ClientID + ","; strMessages9 += "Please enter Assigned To E-mail" + ","; Span105.Style["display"] = "inline-block"; break;
                case "Estimated Cost $": strCtrlsIDs9 += txtSPCEstimatedCost.ClientID + ","; strMessages9 += "Please enter Estimated Cost $" + ","; Span106.Style["display"] = "inline-block"; break;
                case "Final Cost $": strCtrlsIDs9 += txtSPCFinalCost.ClientID + ","; strMessages9 += "Please enter Final Cost $" + ","; Span107.Style["display"] = "inline-block"; break;
                case "Resolution": strCtrlsIDs9 += txtPlan_Indivial_Recommendation_Resolution.ClientID + ","; strMessages9 += "Please enter Resolution" + ","; Span108.Style["display"] = "inline-block"; break;
                case "Date Closed": strCtrlsIDs9 += txtPlan_Indivial_Recommendation_Date_Closed.ClientID + ","; strMessages9 += "Please enter Date Closed" + ","; Span109.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        #endregion

        #region "Phase I-Recommendations"
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date of visit": strCtrlsIDs11 += txtPhase_Indivial_Recommendation_Date.ClientID + ","; strMessages11 += "Please enter Date of visit" + ","; Span117.Style["display"] = "inline-block"; break;
                case "Recommendation Number": strCtrlsIDs11 += txtPhase_Indivial_Recommendation_Number.ClientID + ","; strMessages11 += "Please enter Recommendation Number" + ","; Span118.Style["display"] = "inline-block"; break;
                case "Recommendation Made by": strCtrlsIDs11 += txtPhase_Indivial_Recommendation_Made_by.ClientID + ","; strMessages11 += "Please enter Recommendation Made by" + ","; Span119.Style["display"] = "inline-block"; break;
                case "Status": strCtrlsIDs11 += ddlPhase_Indivial_Recommendation_status.ClientID + ","; strMessages11 += "Please select Status" + ","; Span120.Style["display"] = "inline-block"; break;
                case "Title": strCtrlsIDs11 += txtPhase_Indivial_Recommendation_Title.ClientID + ","; strMessages11 += "Please enter Title" + ","; Span121.Style["display"] = "inline-block"; break;
                case "Detailed Recommendation Description": strCtrlsIDs11 += txtPhase_Indivial_Recommendation_description.ClientID + ","; strMessages11 += "Please enter Detailed Recommendation Description" + ","; Span122.Style["display"] = "inline-block"; break;
                case "Assigned To Name": strCtrlsIDs11 += txtPhase_Indivial_Recommendation_Assigned_to.ClientID + ","; strMessages11 += "Please enter Assigned To Name" + ","; Span123.Style["display"] = "inline-block"; break;
                case "Due date": strCtrlsIDs11 += txtPhase_Indivial_Recommendation_Due_date.ClientID + ","; strMessages11 += "Please enter Due date" + ","; Span124.Style["display"] = "inline-block"; break;
                case "Assigned To Telephone": strCtrlsIDs11 += txtPhase_Indivial_Recommendation_Assigned_to_phone.ClientID + ","; strMessages11 += "Please enter Assigned To Telephone" + ","; Span125.Style["display"] = "inline-block"; break;
                case "Assigned To E-mail": strCtrlsIDs11 += txtPhase_Indivial_Recommendation_Assigned_to_email.ClientID + ","; strMessages11 += "Please enter Assigned To E-mail" + ","; Span126.Style["display"] = "inline-block"; break;
                case "Estimated Cost $": strCtrlsIDs11 += txtPhaseEstimatedCost.ClientID + ","; strMessages11 += "Please enter Estimated Cost $" + ","; Span127.Style["display"] = "inline-block"; break;
                case "Final Cost $": strCtrlsIDs11 += txtPhaseFinalCost.ClientID + ","; strMessages11 += "Please enter Final Cost $" + ","; Span128.Style["display"] = "inline-block"; break;
                case "Resolution": strCtrlsIDs11 += txtPhase_Indivial_Recommendation_Resolution.ClientID + ","; strMessages11 += "Please enter Resolution" + ","; Span129.Style["display"] = "inline-block"; break;
                case "Date Closed": strCtrlsIDs11 += txtPhase_Indivial_Recommendation_Date_Closed.ClientID + ","; strMessages11 += "Please enter Date Closed" + ","; Span130.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        #endregion

        strCtrlsIDs3 = strCtrlsIDs3.TrimEnd(',');
        strMessages3 = strMessages3.TrimEnd(',');

        hdnControlIDs3.Value = strCtrlsIDs3;
        hdnErrorMsgs3.Value = strMessages3;

        strCtrlsIDs5 = strCtrlsIDs5.TrimEnd(',');
        strMessages5 = strMessages5.TrimEnd(',');

        hdnControlIDs5.Value = strCtrlsIDs5;
        hdnErrorMsgs5.Value = strMessages5;

        strCtrlsIDs7 = strCtrlsIDs7.TrimEnd(',');
        strMessages7 = strMessages7.TrimEnd(',');

        hdnControlIDs7.Value = strCtrlsIDs7;
        hdnErrorMsgs7.Value = strMessages7;

        strCtrlsIDs9 = strCtrlsIDs9.TrimEnd(',');
        strMessages9 = strMessages9.TrimEnd(',');

        hdnControlIDs9.Value = strCtrlsIDs9;
        hdnErrorMsgs9.Value = strMessages9;

        strCtrlsIDs11 = strCtrlsIDs11.TrimEnd(',');
        strMessages11 = strMessages11.TrimEnd(',');

        hdnControlIDs11.Value = strCtrlsIDs11;
        hdnErrorMsgs11.Value = strMessages11;
        #endregion

        #region "EPA IDs"
        string strCtrlsIDsEPA = "";
        string strMessagesEPA = "";

        dtFields = clsScreen_Validators.SelectByScreen(144).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        if (dtFields.Select("LeftMenuIndex = 144").Length > 0)
        {
            TreeNode node = trvMenu.FindNode("EPA IDs");
            if (node != null)
            {
                //if (node.ChildNodes[0].Text == "EPA IDs")
                {
                    string str = "EPA IDs" + "&nbsp;<span style='color: Red;position:absolute'> * &nbsp;</span>";
                    //node.ChildNodes[0].Text = str;
                   // node.ChildNodes[0].Expand();
                    node.Text = str;
                    node.Expand();//to expand
                }
            }
        }  
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Type":
                    strCtrlsIDsEPA += txtEPAType.ClientID + ",";
                    strMessagesEPA += "Please enter Type" + ",";
                    Span142.Style["display"] = "inline-block";
                    break;
                case "ID":
                    strCtrlsIDsEPA += txtEPAID_Number.ClientID + ",";
                    strMessagesEPA += "Please enter ID" + ",";
                    Span143.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }

        strCtrlsIDsEPA = strCtrlsIDsEPA.TrimEnd(',');
        strMessagesEPA = strMessagesEPA.TrimEnd(',');

        hdnControlIDEPA.Value = strCtrlsIDsEPA;
        hdnErrorMsgsEPA.Value = strMessagesEPA;
        #endregion
    }

   

    #endregion
}