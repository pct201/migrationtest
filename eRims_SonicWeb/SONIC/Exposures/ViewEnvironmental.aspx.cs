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
using ERIMS.DAL;

/// <summary>
/// 
/// Date           : 17-Oct-08
/// 
/// Developer Name : Ravi Patel
/// 
/// Description    : This page is allow user to view the Environmental information for perticular location ID.
///                  This page contains Equipment, Permit, Audit/Inspection, SPCC, Phase-I and EPA-Ids information
///                  for Location ID which is passed in QueryString for view. If Location Id is not valid then it redirect 
///                  to Search page of Exposure Module.
/// 
/// </summary>
public partial class SONIC_Exposures_ViewEnvironmental : clsBasePage
{

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
    /// Enviro_EquipmentID for Edit
    /// </summary>
    public int EditEnviro_EquipmentID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditEnviro_EquipmentID"]) ? Convert.ToInt32(this.ViewState["EditEnviro_EquipmentID"]) : -1); }
        set { this.ViewState["EditEnviro_EquipmentID"] = value; }
    }

    /// <summary>
    /// Equipement Recommendation ID for Edit
    /// </summary>
    public int EditEquipement_RecommendationID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["Equipement_RecommendationID"]) ? Convert.ToInt32(this.ViewState["Equipement_RecommendationID"]) : -1); }
        set { this.ViewState["Equipement_RecommendationID"] = value; }
    }

    /// <summary>
    /// Permit ID for Edit
    /// </summary>
    public int EditPermitID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditPermitID"]) ? Convert.ToInt32(this.ViewState["EditPermitID"]) : -1); }
        set { this.ViewState["EditPermitID"] = value; }
    }

    /// <summary>
    /// Permit Recommendation ID for Edit
    /// </summary>
    public int EditPermit_RecommendationID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditPermit_RecommendationID"]) ? Convert.ToInt32(this.ViewState["EditPermit_RecommendationID"]) : -1); }
        set { this.ViewState["EditPermit_RecommendationID"] = value; }
    }

    /// <summary>
    /// Inspection-Audit ID for Edit
    /// </summary>
    public int EditAuditID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditAuditID"]) ? Convert.ToInt32(this.ViewState["EditAuditID"]) : -1); }
        set { this.ViewState["EditAuditID"] = value; }
    }

    /// <summary>
    /// Inspection-Audit Recommendation ID for Edit
    /// </summary>
    public int EditAudit_RecommendationID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditAudit_RecommendationID"]) ? Convert.ToInt32(this.ViewState["EditAudit_RecommendationID"]) : -1); }
        set { this.ViewState["EditAudit_RecommendationID"] = value; }
    }

    /// <summary>
    /// SPCC ID for Edit
    /// </summary>
    public int EditSPCCID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditSPCCID"]) ? Convert.ToInt32(this.ViewState["EditSPCCID"]) : -1); }
        set { this.ViewState["EditSPCCID"] = value; }
    }

    /// <summary>
    /// SPCC Recommendation ID for Edit
    /// </summary>
    public int EditSPCC_RecommendationID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditSPCC_RecommendationID"]) ? Convert.ToInt32(this.ViewState["EditSPCC_RecommendationID"]) : -1); }
        set { this.ViewState["EditSPCC_RecommendationID"] = value; }
    }

    /// <summary>
    /// Phase1 ID for Edit
    /// </summary>
    public int EditPhase1ID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditPhase1ID"]) ? Convert.ToInt32(this.ViewState["EditPhase1ID"]) : -1); }
        set { this.ViewState["EditPhase1ID"] = value; }
    }

    /// <summary>
    /// Phase1 Recommendation ID for Edit
    /// </summary>
    public int EditPhase1_RecommendationID
    {
        get { return (!clsGeneral.IsNull(this.ViewState["EditPhase1_RecommendationID"]) ? Convert.ToInt32(this.ViewState["EditPhase1_RecommendationID"]) : -1); }
        set { this.ViewState["EditPhase1_RecommendationID"] = value; }
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

        if (!IsPostBack)
        {
            CheckRequest();

            dsSiteMap.SiteMapProvider = "EX-EnvironmentalMenuProvider";
            Page.DataBind();
            trvMenu.Nodes[0].Expand();

            // set Location ID of header grid user control
            ucExposureInfo.PK_LU_Location = LocationID;
            ucExposureInfo.BindExposureInfo();
            isEditable = new LU_Location(Convert.ToDecimal(LocationID)).Active == "Y";
            // Fill all Grid in Summary Page
            FillEquipmentGrid();
            FillPermitGrid();
            FillAuditGrid();
            FillSPCCGrid();
            FillPhaseGrid();
            FillEPAIDGrid();

            SetEditButton();
            // Show Summary panel 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(0);getScrollHeight();", true);

        }

    }

    #endregion

    #region " Events "

    // Back To Edit Environmental Page
    protected void BackToSummary(object sender, CommandEventArgs e)
    {
        Response.Redirect("Environmental.aspx?loc=" + Request.QueryString["loc"], true);
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

        // Initialize Attachment Detail Control for Equipment
        AttachDetailViewEquipment.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Equipment, EditEnviro_EquipmentID, false, 3);
        AttachDetailViewEquipment.Bind();

        // show Audit Popup
        btnEquipmentAuditView.Visible = true;
        btnViewInAdvertentReleaseAuditTrial.Attributes.Add("onclick", "javascript:return AuditPopUp(" + EditEnviro_EquipmentID.ToString() + ")");
        btnEquipmentAuditView.Attributes.Add("onclick", "javascript:return AuditPopUp(" + EditEnviro_EquipmentID.ToString() + ")");
        btnEquipmentBackToEdit.Style.Add(HtmlTextWriterStyle.Display, "none");
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

        // Initialize Attachment Control for Permit
        AttachDetailViewPermit.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Permit, EditPermitID, false, 7);
        AttachDetailViewPermit.Bind();

        // Show Audit Trail
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
        // set Edit Audit/Inspection ID 
        EditAuditID = Convert.ToInt32(gvAudit.DataKeys[e.NewEditIndex].Value);

        // Fill Audit/inspection Records.
        LoadAuditDataByID(EditAuditID);

        // Fill Recommendation Grid for Audit/Inspection
        FillRecommendationGrid(clsGeneral.Exposure_Enviroment_Table.Enviro_Inspection, EditAuditID);

        // Initialize Attachment Control for Audit/Inspectoin
        AttachDetailViewAudit.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Inspection, EditAuditID, false, 10);
        AttachDetailViewAudit.Bind();

        // Show Audit Trail
        btnAuditView.Visible = true;
        btnAuditView.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Inspections.aspx?id=" + EditAuditID.ToString() + "');");

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
        // set Edit SPCC ID 
        EditSPCCID = Convert.ToInt32(gvSPCC.DataKeys[e.NewEditIndex].Value);

        // Fill SPCC Records.
        LoadSPCCDataByID(EditSPCCID);

        // Fill Recommendation Grid for Plan
        FillRecommendationGrid(clsGeneral.Exposure_Enviroment_Table.Enviro_SPCC, EditSPCCID);

        // Initialize Attachment Control for SPCC
        PlanAttachmentDetails.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_SPCC, EditSPCCID, false, 12);
        PlanAttachmentDetails.Bind();

        // Show Audit Trail
        btnSPCCAudit.Visible = true;
        btnSPCCAudit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_SPCC.aspx?id=" + EditSPCCID.ToString() + "');");

        // Show Panel
        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "javascript:OutsideToggleNode(15,14);ShowPanel(11);", true);
    }

    /// <summary>
    /// Row Edit event for Phase-I grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPhaseI_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // set Edit Phase I
        EditPhase1ID = Convert.ToInt32(gvPhaseI.DataKeys[e.NewEditIndex].Value);

        // Fill PhaseI Records.
        LoadPhaseDataByID(EditPhase1ID);

        // Fill Recommendation Grid for PhaseI
        FillRecommendationGrid(clsGeneral.Exposure_Enviroment_Table.Enviro_Phase1, EditPhase1ID);

        // Initialize Attachment Control for PhaseI
        PhaseAttachmentDetails.InitializeAttachmentDetails(clsGeneral.Exposure_Enviroment_Table.Enviro_Phase1, EditPhase1ID, false, 15);
        PhaseAttachmentDetails.Bind();

        // Show Audit Trail
        btnPhase1Audit.Visible = true;
        btnPhase1Audit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Phase.aspx?id=" + EditPhase1ID.ToString() + "');");

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "", "javascript:OutsideToggleNode(19,18);ShowPanel(14);", true);
    }

    /// <summary>
    /// Row Edit event for Equipment Recomeendation grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvViewEquipmentRecommendation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Fill Equipment Fields by Recommendation Id/Equipment
        LoadEquipmentRecommendationRecordByID(Convert.ToInt32(gvViewEquipmentRecommendation.DataKeys[e.NewEditIndex].Value));

    }

    /// <summary>
    /// Row Edit event for Permit Recomeendation Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvViewPermitRecommendation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Fill Equipment Fields by Recommendation Id/Permit
        LoadPermitRecommendationRecordByID(Convert.ToInt32(gvViewPermitRecommendation.DataKeys[e.NewEditIndex].Value));
    }

    /// <summary>
    /// Row Edit event for Audit/Inspection Recomeendation Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvViewAuditRecommendation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Fill Equipment Fields by Recommendation Id for Audit/Inspection
        LoadAuditRecommendationRecordByID(Convert.ToInt32(gvViewAuditRecommendation.DataKeys[e.NewEditIndex].Value));
    }

    /// <summary>
    /// Row Edit event for SPCC/Plan Recomeendation Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPlanRecommendation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Fill Equipment Fields by Recommendation Id for SPCC
        LoadSPCCRecommendationRecordByID(Convert.ToInt32(gvPlanRecommendation.DataKeys[e.NewEditIndex].Value));
    }

    /// <summary>
    /// Row Edit event for Phase-I Recomeendation Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPhaseRecommendation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Fill Equipment Fields by Recommendation Id for PhaseI
        LoadPhaseRecommendationRecordByID(Convert.ToInt32(gvPhaseRecommendation.DataKeys[e.NewEditIndex].Value));

    }

    #endregion

    #region " Methods "

    /// <summary>
    /// function whihc is used for enable - disable edits button in all screen.
    /// </summary>
    private void SetEditButton()
    {
        btnEquipmentBackToEdit.Enabled = isEditable;
        btnEquipmentBack.Enabled = isEditable;
        btnViewInAdvertentBack.Enabled = isEditable;
        btnViewInAdvertentBack.Enabled = isEditable;
        btnAttachmentback.Enabled = isEditable;
        btnEquipmentRecommendationBack.Enabled = isEditable;
        btnPermitBack.Enabled = isEditable;
        btnPermitRecommendationBack.Enabled = isEditable;
        btnPhase1Back.Enabled = isEditable;
        btnPhaseBack.Enabled = isEditable;
        btnSPCCBack.Enabled = isEditable;
        btnSPCCIndBack.Enabled = isEditable;
        btnAuditback.Enabled = isEditable;
        btnAuditIndBack.Enabled = isEditable;
        btnPhaseAttachmentDetails.Enabled = isEditable;
        btnPlanAttachmentDetails.Enabled = isEditable;
        btnAttachDetailViewAudit.Enabled = isEditable;
        btnAttachDetailViewPermit.Enabled = isEditable;
        //btnAttachDetailViewPermit.Enabled = isEditable;
    }

    /// <summary>
    /// Check Whether Requiest is valid or not for parameter location ID
    /// </summary>
    private void CheckRequest()
    {
        int Location_Id;
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

        btnEquipmentBackToEdit.Visible = (App_Access == AccessType.Administrative_Access);
    }

    /// <summary>
    /// Fill Equipment Summary Grid
    /// </summary>
    private void FillEquipmentGrid()
    {
        gvEquipment.DataSource = Enviro_Equipment.SelectByFK_LU_LocationID(LocationID).Tables[0];
        gvEquipment.DataBind();
        isEditable = gvEquipment.Rows.Count > 0 | isEditable;

    }

    /// <summary>
    /// Fill PermitGrid
    /// </summary>
    private void FillPermitGrid()
    {
        gvPermit.DataSource = Enviro_Permit.SelectByLocationID(LocationID).Tables[0];
        gvPermit.DataBind();
        isEditable = gvPermit.Rows.Count > 0 | isEditable;
    }

    /// <summary>
    /// Fill Audit/Inspection Grid
    /// </summary>
    private void FillAuditGrid()
    {

        gvAudit.DataSource = Enviro_Inspection.SelectByLocationID(LocationID).Tables[0];
        gvAudit.DataBind();
        isEditable = gvAudit.Rows.Count > 0 | isEditable;
    }

    /// <summary>
    /// Fill Phase Grid
    /// </summary>
    private void FillPhaseGrid()
    {
        gvPhaseI.DataSource = Enviro_Phase1.SelectByLocationID(LocationID).Tables[0];
        gvPhaseI.DataBind();
        isEditable = gvPhaseI.Rows.Count > 0 | isEditable;
    }

    /// <summary>
    ///  Fill SPCC Grid
    /// </summary>
    private void FillSPCCGrid()
    {
        gvSPCC.DataSource = Enviro_SPCC.SelectByLocationID(LocationID).Tables[0];
        gvSPCC.DataBind();
        isEditable = gvSPCC.Rows.Count > 0 | isEditable;
    }

    /// <summary>
    ///  Fill EPA IDs Grid
    /// </summary>
    private void FillEPAIDGrid()
    {
        DataTable dtEPAID;
        dtEPAID = EPA_IDs.SelectByLocationID(LocationID).Tables[0];

        gvEPAID.DataSource = dtEPAID;
        gvEPAID.DataBind();
        isEditable = gvEPAID.Rows.Count > 0 | isEditable;
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


        // Fill View Equipment Recommdendation Grid
        if (RecommendationTable == clsGeneral.Exposure_Enviroment_Table.Enviro_Equipment)
        {
            this.gvViewEquipmentRecommendation.DataSource = dsRecommendation;
            this.gvViewEquipmentRecommendation.DataBind();
            this.pnlViewEquipmentIndRecommendation.Visible = false;
        }
        // Fill View Permit Recommdendation Grid
        else if (RecommendationTable == clsGeneral.Exposure_Enviroment_Table.Enviro_Permit)
        {
            this.gvViewPermitRecommendation.DataSource = dsRecommendation;
            this.gvViewPermitRecommendation.DataBind();
            this.pnlViewPermitIndRecommendation.Visible = false;
        }
        // Fill Audit/inspecton Recommdendation Grid
        else if (RecommendationTable == clsGeneral.Exposure_Enviroment_Table.Enviro_Inspection)
        {
            this.gvViewAuditRecommendation.DataSource = dsRecommendation;
            this.gvViewAuditRecommendation.DataBind();
            this.pnlViewAuditIndRecommendation.Visible = false;
        }
        // Fill SPCC Recommdendation Grid
        else if (RecommendationTable == clsGeneral.Exposure_Enviroment_Table.Enviro_SPCC)
        {
            this.gvPlanRecommendation.DataSource = dsRecommendation;
            this.gvPlanRecommendation.DataBind();
            this.pnlViewSPCCIndRecommendation.Visible = false;
        }
        // Fill Phase I Recommdendation Grid
        else if (RecommendationTable == clsGeneral.Exposure_Enviroment_Table.Enviro_Phase1)
        {
            this.gvPhaseRecommendation.DataSource = dsRecommendation;
            this.gvPhaseRecommendation.DataBind();
        }

        clsGeneral.DisposeOf(dsRecommendation);

    }

    /// <summary>
    ///  Fill Equipment Data by Equipment ID
    /// </summary>
    /// <param name="PK_Enviro_Equipment_ID"> Equipment ID </param>
    private void LoadEquiepmentDataByID(int PK_Enviro_Equipment_ID)
    {
        DataSet dsEquiepment = new DataSet();

        dsEquiepment = Enviro_Equipment.SelectByPK(PK_Enviro_Equipment_ID);

        this.lblEquipment_Identification.Text = dsEquiepment.Tables[0].Rows[0]["Identification"].ToString();
        this.lblDate_Last_Service.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Date_of_Last_Service"]);
        this.lblEquipment_Insurer.Text = dsEquiepment.Tables[0].Rows[0]["Insurer"].ToString();
        this.lblEquipment_SingleEvent.Text = string.Format("{0:0,0}", dsEquiepment.Tables[0].Rows[0]["Single_Event_Coverage"]);
        this.lblEquipment_Total_Coverage.Text = string.Format("{0:0,0}", dsEquiepment.Tables[0].Rows[0]["Multiple_Event_Total_Coverage"]);
        this.lblEquipment_Capacity.Text = clsGeneral.GetStringValue(dsEquiepment.Tables[0].Rows[0]["Capacity"]);
        this.lblCoverage_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Coverage_Start_Date"]);
        this.lblCoverage_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Coverage_End_Date"]);
        this.lblDate_Of_Last_TCLP.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Date_of_Last_TCLP"]);
        this.lblEquipment_Installation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Installation_Date"]);
        this.lblEquipment_Removal_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Removal_Date"]);
        this.lblEquipment_Closure_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Closure_Date"]);
        this.lblEquipment_Last_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Last_Inspection_Date"]);
        this.lblEquipment_Next_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Next_Inspection_Date"]);
        this.lblEquipment_Construction.Text = dsEquiepment.Tables[0].Rows[0]["Construction"].ToString();
        this.lblEquipment_ConstructionOther.Text = dsEquiepment.Tables[0].Rows[0]["Construction_Other"].ToString().Trim();
        this.lblEquipmnet_Inspection_Company.Text = dsEquiepment.Tables[0].Rows[0]["Insurance_Company"].ToString();
        this.lblEqupment_Inspection_Contact_Name.Text = dsEquiepment.Tables[0].Rows[0]["Inspection_Contact"].ToString();
        this.lblEquipment_Inspection_Company_Telephone.Text = dsEquiepment.Tables[0].Rows[0]["Inspection_Phone"].ToString();
        this.lblEquipment_Registration_Number.Text = dsEquiepment.Tables[0].Rows[0]["Registration_Number"].ToString();
        this.lblEquipment_Certificate_Number.Text = dsEquiepment.Tables[0].Rows[0]["Certificate_Number"].ToString();
        this.lblEquipment_Permit_Begin_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Permit_Begin_Date"]);
        this.lblEquipment_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Permit_End_Date"]);
        this.lblEquipment_ContactsOther.Text = dsEquiepment.Tables[0].Rows[0]["Contents_Other"].ToString();
        this.lblEquipment_Release_Description.Text = dsEquiepment.Tables[0].Rows[0]["Release_Equipment_Description"].ToString();
        this.lblEquipment_MaterialOther.Text = dsEquiepment.Tables[0].Rows[0]["Material_Other"].ToString();
        this.lblEquipment_Other_Reporting_Desc.Text = dsEquiepment.Tables[0].Rows[0]["Other_Req_Descr"].ToString();
        this.lblEquipment_NextReportDate.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Next_Report_Date"]);
        this.lblEquipment_Notes.Text = dsEquiepment.Tables[0].Rows[0]["Notes"].ToString();
        this.lblEquipment_LeakDetection_Type.Text = dsEquiepment.Tables[0].Rows[0]["Leak_Detection_Type"].ToString().Trim();


        this.lblPlan_Revision_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Plan_Revision_Date"]);
        this.lblPlan_Effective_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Plan_Effective_Date"]);
        this.lblPlan_Expiration_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsEquiepment.Tables[0].Rows[0]["Plan_Expiration_Date"]);
        this.lblPlan_ID.Text = dsEquiepment.Tables[0].Rows[0]["Plan_ID"].ToString().Trim();
        this.lblPlan_Vendor.Text = dsEquiepment.Tables[0].Rows[0]["Plan_Vendor"].ToString().Trim();
        this.lblPlan_Vendor_Contact.Text = dsEquiepment.Tables[0].Rows[0]["Plan_Vendor_Contact"].ToString().Trim();
        this.lblPlan_Phone.Text = dsEquiepment.Tables[0].Rows[0]["Plan_Phone"].ToString().Trim();


        this.lblEquipment_Type.Text = dsEquiepment.Tables[0].Rows[0]["type"].ToString();
        this.lblEquipment_Contents.Text = dsEquiepment.Tables[0].Rows[0]["Contents"].ToString();
        this.lblEquipment_Status.Text = dsEquiepment.Tables[0].Rows[0]["status"].ToString();
        this.lblEuipment_Material.Text = dsEquiepment.Tables[0].Rows[0]["Material"].ToString();

        this.lblEquipment_Release_Present.Text = clsGeneral.FormatYesNoToDisplayForView(dsEquiepment.Tables[0].Rows[0]["Release_Equipment_Present"]);
        this.lblEquipment_Overfill_Protection.Text = clsGeneral.FormatYesNoToDisplayForView(dsEquiepment.Tables[0].Rows[0]["Overfill_Protection"]);
        this.lblEquipment_LeakDetection.Text = clsGeneral.FormatYesNoToDisplayForView(dsEquiepment.Tables[0].Rows[0]["Leak_Detection"]);
        this.lblTCLP_File.Text = clsGeneral.FormatYesNoToDisplayForView(dsEquiepment.Tables[0].Rows[0]["TCLP_on_File"]);
        this.lblFlowsToPOTW.Text = clsGeneral.FormatYesNoToDisplayForView(dsEquiepment.Tables[0].Rows[0]["Flows_to_POTW"]);
        this.lblEquipment_Registration_Required.Text = clsGeneral.FormatYesNoToDisplayForView(dsEquiepment.Tables[0].Rows[0]["Registration_Required"]);
        this.lblEquipment_Other_Reporting_Requirements.Text = clsGeneral.FormatYesNoToDisplayForView(dsEquiepment.Tables[0].Rows[0]["Other_Req"]);

        if (lblEquipment_Type.Text.Trim() == "Underground Storage Tank" || lblEquipment_Type.Text.Trim() == "Above Ground Storage Tank")
        {
            tblViewTypeInfo.Style["display"] = "block";
            tblViewOilWater.Style["display"] = "none";
        }
        else if (lblEquipment_Type.Text.Trim() == "Oil Water Seperator")
        {
            tblViewOilWater.Style["display"] = "block";
            tblViewTypeInfo.Style["display"] = "none";
        }
        else
        {
            tblViewOilWater.Style["display"] = "none";
            tblViewTypeInfo.Style["display"] = "none";
        }

        AttachDetailViewEquipment.Visible = true;
        clsGeneral.DisposeOf(dsEquiepment);
    }

    /// <summary>
    /// Load equipment Recommendation Record by PK
    /// </summary>
    /// <param name="RecommendationID"></param>
    private void LoadEquipmentRecommendationRecordByID(int RecommendationID)
    {
        Enviro_Recommendations objRecommendation = new Enviro_Recommendations(RecommendationID);

        // Set Fields 
        this.lblIndivial_Recommendation_Assigned_to.Text = objRecommendation.Assigned_to.ToString();
        this.lblIndivial_Recommendation_Assigned_to_email.Text = objRecommendation.Assigned_to_email.ToString();
        this.lblIndivial_Recommendation_Assigned_to_phone.Text = objRecommendation.Assigned_to_phone.ToString();
        this.lblIndivial_Recommendation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date);
        this.lblIndivial_Recommendation_Date_Closed.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date_closed);
        this.lblIndivial_Recommendation_Due_date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Due_date);
        this.lblIndivial_Recommendation_description.Text = objRecommendation.description.ToString();
        this.lblIndivial_Recommendation_Made_by.Text = objRecommendation.Made_by.ToString();
        this.lblIndivial_Recommendation_Number.Text = objRecommendation.Number.ToString();
        this.lblEstimatedCost.Text = clsGeneral.GetStringValue(objRecommendation.Estimated_Cost);
        this.lblFinalCost.Text = clsGeneral.GetStringValue(objRecommendation.Final_Cost);
        this.lblIndivial_Recommendation_Resolution.Text = objRecommendation.resolution.ToString();
        this.lblIndivial_Recommendation_Title.Text = objRecommendation.title.ToString();
        this.lblIndivial_Recommendation_status.Text = objRecommendation.status.ToString();

        // Show Individual Recomendation Panel.
        pnlViewEquipmentIndRecommendation.Visible = true;

        // show Audit Popup
        btnEquipmentRecommendationAudit.Visible = true;
        btnEquipmentRecommendationAudit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Recommendation.aspx?id=" + RecommendationID.ToString() + "');");

        // Show Panel
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(4);", true);

        clsGeneral.DisposeOf(objRecommendation);
    }

    /// <summary>
    ///  Fill Permit Data by Equipment ID
    /// </summary>
    /// <param name="PK_PermitID"> Permit ID </param>
    private void LoadPermitDataByID(int PK_PermitID)
    {
        Enviro_Permit objPermit = new Enviro_Permit(PK_PermitID);

        // set Fields
        this.lblPermit_Type.Text = objPermit.type;
        this.lblPermit_required.Text = clsGeneral.FormatYesNoToDisplayForView(objPermit.required);
        this.lblPermit_Application_number.Text = objPermit.Application_number;
        this.lblPermit_Certificate_number.Text = objPermit.Certificate_number;
        this.lblPermit_Permit_Begin_date.Text = clsGeneral.FormatDBNullDateToDisplay(objPermit.Begin_date);
        this.lblPermit_Permit_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPermit.End_date);
        this.lblPermit_Last_Inspection_date.Text = clsGeneral.FormatDBNullDateToDisplay(objPermit.Last_Inspection_date);
        this.lblPermit_Next_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPermit.Next_Inspection_Date);
        this.lblPermit_Filing_date.Text = clsGeneral.FormatDBNullDateToDisplay(objPermit.Filing_date);
        this.lblPermit_Next_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPermit.Next_Report_Date);
        this.lblPermit_Notes.Text = objPermit.Notes;
        clsGeneral.DisposeOf(objPermit);

    }

    /// <summary>
    /// Load Recommendation Record by PK
    /// </summary>
    /// <param name="RecommendationID"></param>
    private void LoadPermitRecommendationRecordByID(int RecommendationID)
    {
        Enviro_Recommendations objRecommendation = new Enviro_Recommendations(RecommendationID);

        // Set Fields
        this.lblPermit_Indivial_Recommendation_Assigned_to.Text = objRecommendation.Assigned_to.ToString();
        this.lblPermit_Indivial_Recommendation_Assigned_to_email.Text = objRecommendation.Assigned_to_email.ToString();
        this.lblPermit_Indivial_Recommendation_Assigned_to_phone.Text = objRecommendation.Assigned_to_phone.ToString();
        this.lblPermit_Indivial_Recommendation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date);
        this.lblPermit_Indivial_Recommendation_Date_Closed.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date_closed);
        this.lblPermit_Indivial_Recommendation_Due_date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Due_date);
        this.lblPermit_Indivial_Recommendation_description.Text = objRecommendation.description.ToString();
        this.lblPermit_Indivial_Recommendation_Made_by.Text = objRecommendation.Made_by.ToString();
        this.lblPermit_Indivial_Recommendation_Number.Text = objRecommendation.Number.ToString();
        this.lblPermitEstimatedCost.Text = clsGeneral.GetStringValue(objRecommendation.Estimated_Cost);
        this.lblPermitFinalCost.Text = clsGeneral.GetStringValue(objRecommendation.Final_Cost);
        this.lblPermit_Indivial_Recommendation_Resolution.Text = objRecommendation.resolution.ToString();
        this.lblPermit_Indivial_Recommendation_Title.Text = objRecommendation.title.ToString();
        this.lblPermit_Indivial_Recommendation_status.Text = objRecommendation.status.ToString();
        this.pnlViewPermitIndRecommendation.Visible = true;

        // show Audit Popup
        btnPermitRecommendationAudit.Visible = true;
        btnPermitRecommendationAudit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Recommendation.aspx?id=" + RecommendationID.ToString() + "');");

        // Show Panel 
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(7);", true);

        clsGeneral.DisposeOf(objRecommendation);

    }

    /// <summary>
    /// Fill Audit/inpsection data By AuditID
    /// </summary>
    /// <param name="PK_AuditID"></param>
    private void LoadAuditDataByID(int PK_AuditID)
    {
        Enviro_Inspection objAudit = new Enviro_Inspection(PK_AuditID);

        // Set Fields
        this.lblAudit_Frequency.Text = objAudit.Frequency.Trim();
        this.lblAudit_Cost.Text = clsGeneral.GetStringValue(objAudit.Cost);
        this.lblAudit_Last_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objAudit.Last_Date);
        this.lblAudit_Next_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objAudit.Next_Date);
        this.lblAudits_Next_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objAudit.Next_Report_Date);
        this.lblAudit_Notes.Text = objAudit.Notes.Trim();

        clsGeneral.DisposeOf(objAudit);

    }

    /// <summary>
    /// Fill Audit/Inspection recommendation data by Recommendation ID
    /// </summary>
    /// <param name="RecommendationID"></param>
    private void LoadAuditRecommendationRecordByID(int RecommendationID)
    {
        Enviro_Recommendations objRecommendation = new Enviro_Recommendations(RecommendationID);

        // Set Fields
        this.lblAudit_Indivial_Recommendation_Assigned_to.Text = objRecommendation.Assigned_to.ToString();
        this.lblAudit_Indivial_Recommendation_Assigned_to_email.Text = objRecommendation.Assigned_to_email.ToString();
        this.lblAudit_Indivial_Recommendation_Assigned_to_phone.Text = objRecommendation.Assigned_to_phone.ToString();
        this.lblAudit_Indivial_Recommendation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date);
        this.lblAudit_Indivial_Recommendation_Date_Closed.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date_closed);
        this.lblAudit_Indivial_Recommendation_Due_date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Due_date);
        this.lblAudit_Indivial_Recommendation_description.Text = objRecommendation.description.ToString();
        this.lblAudit_Indivial_Recommendation_Made_by.Text = objRecommendation.Made_by.ToString();
        this.lblAudit_Indivial_Recommendation_Number.Text = objRecommendation.Number.ToString();
        this.lblAuditEstimatedCost.Text = clsGeneral.GetStringValue(objRecommendation.Estimated_Cost);
        this.lblAuditFinalCost.Text = clsGeneral.GetStringValue(objRecommendation.Final_Cost);
        this.lblAudit_Indivial_Recommendation_Resolution.Text = objRecommendation.resolution.ToString();
        this.lblAudit_Indivial_Recommendation_Title.Text = objRecommendation.title.ToString();
        this.lblAudit_Indivial_Recommendation_status.Text = objRecommendation.status.ToString();
        this.pnlViewAuditIndRecommendation.Visible = true;

        // show Audit Popup
        btnAuditIndAudit.Visible = true;
        btnAuditIndAudit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Recommendation.aspx?id=" + RecommendationID.ToString() + "');");

        // Show Panel
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(10);", true);
    }

    /// <summary>
    /// Fill SPCC Data by SPCC ID
    /// </summary>
    /// <param name="EditSPCCID"></param>    
    private void LoadSPCCDataByID(int EditSPCCID)
    {
        Enviro_SPCC objSPCC = new Enviro_SPCC(EditSPCCID);

        this.lblPreparer.Text = objSPCC.Plan_Preparer.Trim();
        this.lblPlan_date.Text = clsGeneral.FormatDBNullDateToDisplay(objSPCC.Last_Date);
        this.lblPlan_Next_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSPCC.Next_Date);
        this.lblPlan_Next_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSPCC.Next_Report_Date);
        this.lblPlan_Phone.Text = objSPCC.Phone.Trim();
        this.lblPlan_Notes.Text = objSPCC.Notes.Trim();
        this.lblphone.Text = objSPCC.Phone;
        this.lblPlan_Cost.Text = clsGeneral.GetStringValue(objSPCC.Cost);


        clsGeneral.DisposeOf(objSPCC);
    }

    /// <summary>
    /// Fill SPCC recommendation data by Recommednation ID
    /// </summary>
    /// <param name="RecommendationID"></param>
    private void LoadSPCCRecommendationRecordByID(int EditSPCC_RecommendationID)
    {
        Enviro_Recommendations objRecommendation = new Enviro_Recommendations(EditSPCC_RecommendationID);

        this.lblPlan_Indivial_Recommendation_Assigned_to.Text = objRecommendation.Assigned_to.ToString();
        this.lblPlan_Indivial_Recommendation_Assigned_to_email.Text = objRecommendation.Assigned_to_email.ToString();
        this.lblPlan_Indivial_Recommendation_Assigned_to_phone.Text = objRecommendation.Assigned_to_phone.ToString();
        this.lblPlan_Indivial_Recommendation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date);
        this.lblPlan_Indivial_Recommendation_Date_Closed.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date_closed);
        this.lblPlan_Indivial_Recommendation_Due_date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Due_date);
        this.lblPlan_Indivial_Recommendation_description.Text = objRecommendation.description.ToString();
        this.lblPlan_Indivial_Recommendation_Made_by.Text = objRecommendation.Made_by.ToString();
        this.lblPlan_Indivial_Recommendation_Number.Text = objRecommendation.Number.ToString();
        this.lblSPCEstimatedCost.Text = clsGeneral.GetStringValue(objRecommendation.Estimated_Cost);
        this.lblSPCFinalCost.Text = clsGeneral.GetStringValue(objRecommendation.Final_Cost);
        this.lblPlan_Indivial_Recommendation_Resolution.Text = objRecommendation.resolution.ToString();
        this.lblPlan_Indivial_Recommendation_Title.Text = objRecommendation.title.ToString();
        this.lblPlan_Indivial_Recommendation_status.Text = objRecommendation.status.Trim();
        this.pnlViewSPCCIndRecommendation.Visible = true;

        // Show panel
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(13);", true);

        // show Audit Popup
        btnSPCCIndAudit.Visible = true;
        btnSPCCIndAudit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Recommendation.aspx?id=" + EditSPCC_RecommendationID.ToString() + "');");

        clsGeneral.DisposeOf(objRecommendation);
    }

    /// <summary>
    /// Fill Phase recommendation data by Recommendation ID
    /// </summary>
    /// <param name="RecommendationID"></param>
    private void LoadPhaseRecommendationRecordByID(int EditPhase_RecommendationID)
    {
        Enviro_Recommendations objRecommendation = new Enviro_Recommendations(EditPhase_RecommendationID);

        this.lblPhase_Indivial_Recommendation_Assigned_to.Text = objRecommendation.Assigned_to.ToString();
        this.lblPhase_Indivial_Recommendation_Assigned_to_email.Text = objRecommendation.Assigned_to_email.ToString();
        this.lblPhase_Indivial_Recommendation_Assigned_to_phone.Text = objRecommendation.Assigned_to_phone.ToString();
        this.lblPhase_Indivial_Recommendation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date);
        this.lblPhase_Indivial_Recommendation_Date_Closed.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Date_closed);
        this.lblPhase_Indivial_Recommendation_Due_date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecommendation.Due_date);
        this.lblPhase_Indivial_Recommendation_description.Text = objRecommendation.description.ToString();
        this.lblPhase_Indivial_Recommendation_Made_by.Text = objRecommendation.Made_by.ToString();
        this.lblPhase_Indivial_Recommendation_Number.Text = objRecommendation.Number.ToString();
        this.lblPhaseEstimatedCost.Text = clsGeneral.GetStringValue(objRecommendation.Estimated_Cost);
        this.lblPhaseFinalCost.Text = clsGeneral.GetStringValue(objRecommendation.Final_Cost);
        this.lblPhase_Indivial_Recommendation_Resolution.Text = objRecommendation.resolution.ToString();
        this.lblPhase_Indivial_Recommendation_Title.Text = objRecommendation.title.ToString();
        this.lblPhase_Indivial_Recommendation_status.Text = objRecommendation.status;
        this.pnlPhaseIndRecommendations.Visible = true;
        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "", "javascript:ShowPanel(16);", true);

        // show Audit Popup
        btnPhaseAudit.Visible = true;
        btnPhaseAudit.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_Recommendation.aspx?id=" + EditPhase_RecommendationID.ToString() + "');");

        clsGeneral.DisposeOf(objRecommendation);
    }

    /// <summary>
    /// Fill PhaseI Data by Phase
    /// </summary>
    /// <param name="EditSPCCID"></param>    
    private void LoadPhaseDataByID(int EditPhaseID)
    {
        Enviro_Phase1 objPhase = new Enviro_Phase1(EditPhaseID);

        this.lblPhase_Assessor.Text = objPhase.ASSESSOR.Trim();
        this.lblPhase_date.Text = clsGeneral.FormatDBNullDateToDisplay(objPhase.Last_Date);
        this.lblPhase_Next_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPhase.Next_Date);
        this.lblPhase_Next_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPhase.Next_Report_Date);
        this.lblPhase_phone.Text = objPhase.Phone.Trim();
        this.lblPhase_Notes.Text = objPhase.Notes.Trim();
        this.lblPhase_Cost.Text = clsGeneral.GetStringValue(objPhase.Cost);

        clsGeneral.DisposeOf(objPhase);

    }

    #endregion

}
