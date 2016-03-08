using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
public partial class SONIC_Franchise_FranchiseAddEdit : clsBasePage
{

    // <summary>
    /// Date : 12 Nov 2010
    /// 
    /// By : Alpesh Patel
    /// 
    /// Purpose: 
    /// Last Modify Administrator Validion changes    
    /// </summary>

    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Franchise
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Franchise"]);
        }
        set { ViewState["PK_Franchise"] = value; }
    }
    /// <summary>
    /// Denotes foriegn key for Location record
    /// </summary>
    public int FK_LU_Location_ID
    {
        get { return Convert.ToInt32(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }
    #endregion

    #region Page Events
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Franchise);

        if (!Page.IsPostBack)
        {
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            // check if location id is passed in querystring or not
            if (Request.QueryString["loc"] != null)
            {
                int loc;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out loc))
                {
                    FK_LU_Location_ID = loc;
                    BindLocationInformation();
                }
                else
                    Response.Redirect("ExposureSearch.aspx");

                // store the location id in session
                Session["ExposureLocation"] = FK_LU_Location_ID;
            }

            if (Request.QueryString["op"] != null)
            {
                StrOperation = Request.QueryString["op"];
            }
            if (StrOperation != string.Empty)
            {
                if (Request.QueryString["id"] != null)
                {
                    decimal PK;
                    if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out PK))
                    {
                        PK_Franchise = PK;
                    }
                }
                if (StrOperation == "view")
                {
                    //if (App_Access != AccessType.Franchise_View && App_Access != AccessType.Franchise_AddEdit)// && App_Access != AccessType.Administrative_Access)
                    //    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

                    // Bind Controls
                    BindDetailsForView();
                }
                else
                {
                    //if (App_Access != AccessType.Franchise_AddEdit )//&& App_Access != AccessType.Administrative_Access)
                    //    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    // Bind Controls
                    BindDetailsForEdit();
                }
            }
            else
            {
                //if (App_Access != AccessType.Franchise_AddEdit)// && App_Access != AccessType.Administrative_Access)
                //    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

                BindDropdowns();
                //BindGridTimeLine();
                BindAttachmentDetails(false);
                // don't show div for view mode
                dvView.Style["display"] = "none";
                btnSave.Visible = true;
                btnEdit.Visible = false;
                // lnkAddTimeLine.Visible = (App_Access == AccessType.Franchise_AddEdit);
            }

            // Bind location information
            ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
            ucCtrlExposureInfo.BindExposureInfo();
            drpFK_Building_Id.Focus();
            if (StrOperation.ToLower() != "view")
                SetValidations();
        }

        if (StrOperation.ToLower() != "view")
        {
            clsGeneral.SetDropDownToolTip(new DropDownList[] { drpFK_Building_Id, drpFK_LU_Franchise_Brand });
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Bind Location Information   
    /// </summary>
    private void BindLocationInformation()
    {
        LU_Location objLoc = new LU_Location(Convert.ToDecimal(FK_LU_Location_ID));
        lblLocationDBA.Text = objLoc.dba;
        //lblLegalEntityName.Text = objLoc.legal_entity;
        lblLocationFKA.Text = new LU_Location_FKA(FK_LU_Location_ID, true).fka;
        lblSonicLocCode.Text = Convert.ToString(objLoc.Sonic_Location_Code);

        lblSonicLocCodeView.Text = lblSonicLocCode.Text;
        lblLocationFKAView.Text = lblLocationFKA.Text;
        //lblLegalEntityNameView.Text = lblLegalEntityName.Text;
        lblLocationDBAView.Text = lblLocationDBA.Text;
    }
    /// <summary>
    /// Bind DropDownList Box
    /// </summary>
    private void BindDropdowns()
    {
        DataTable dtBuilding = Building.SelectByFKLocation(FK_LU_Location_ID).Tables[0];
        dtBuilding.DefaultView.Sort = "Building_Number ASC";

        DataTable dtBuildingSort = dtBuilding.DefaultView.ToTable();
        bool bOccupancy_Sales_New, bOccupancy_Body_Shop, bOccupancy_Parking_Lot, bOccupancy_Sales_Used,
            bOccupancy_Parts, bOccupancy_Raw_Land, bOccupancy_Service, bOccupancy_Ofifce;
        string strOccupancy;
        for (int i = 0; i < dtBuildingSort.Rows.Count; i++)
        {
            bOccupancy_Sales_New = Convert.ToBoolean(dtBuildingSort.Rows[i]["Occupancy_Sales_New"]);
            bOccupancy_Body_Shop = Convert.ToBoolean(dtBuildingSort.Rows[i]["Occupancy_Body_Shop"]);
            bOccupancy_Parking_Lot = Convert.ToBoolean(dtBuildingSort.Rows[i]["Occupancy_Parking_Lot"]);
            bOccupancy_Sales_Used = Convert.ToBoolean(dtBuildingSort.Rows[i]["Occupancy_Sales_Used"]);
            bOccupancy_Parts = Convert.ToBoolean(dtBuildingSort.Rows[i]["Occupancy_Parts"]);
            bOccupancy_Raw_Land = Convert.ToBoolean(dtBuildingSort.Rows[i]["Occupancy_Raw_Land"]);
            bOccupancy_Service = Convert.ToBoolean(dtBuildingSort.Rows[i]["Occupancy_Service"]);
            bOccupancy_Ofifce = Convert.ToBoolean(dtBuildingSort.Rows[i]["Occupancy_Ofifce"]);

            strOccupancy = ""; // used to set the comma seperated occupancies

            // append occupancy text with comma seperation depending on the values
            strOccupancy = Convert.ToString(dtBuildingSort.Rows[i]["Building_Number"]) + " - ";
            //if (bOccupancy_Sales_New) strOccupancy = "Sales - New";
            if (bOccupancy_Sales_New)
                strOccupancy = strOccupancy + "Sales - New" + ", ";
            if (bOccupancy_Body_Shop)
                strOccupancy = strOccupancy + "Body Shop" + ", ";
            if (bOccupancy_Parking_Lot)
                strOccupancy = strOccupancy + "Parking Lot" + ", ";
            if (bOccupancy_Sales_Used)
                strOccupancy = strOccupancy + "Sales - Used" + ", ";
            if (bOccupancy_Parts)
                strOccupancy = strOccupancy + "Parts" + ", ";
            if (bOccupancy_Raw_Land)
                strOccupancy = strOccupancy + "Raw Land" + ", ";
            if (bOccupancy_Service)
                strOccupancy = strOccupancy + "Service" + ", ";
            if (bOccupancy_Ofifce)
                strOccupancy = strOccupancy + "Office" + ", ";

            // set text in occupancy column
            drpFK_Building_Id.Items.Add(new ListItem(strOccupancy.Trim().Trim(','), Convert.ToString(dtBuildingSort.Rows[i]["PK_Building_ID"])));
        }
        drpFK_Building_Id.Items.Insert(0, new ListItem("--Select--", "0"));

        ComboHelper.Fill_LU_Franchise(new DropDownList[] { drpFK_LU_Franchise_Brand }, true, ComboHelper.LU_Franchise.LU_Franchise_Brand);
        //ComboHelper.Fill_LU_Franchise(new DropDownList[] { drpFK_LU_Franchise_Permit_Secured }, true, ComboHelper.LU_Franchise.LU_Franchise_Permit_Secured);
        //ComboHelper.Fill_LU_Franchise(new DropDownList[] { drpFK_LU_Franchise_Plans_Submitted }, true, ComboHelper.LU_Franchise.LU_Franchise_Plans_Submitted);
    }

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        BindDropdowns();
        dvView.Style["display"] = "none";
        dvEdit.Style["display"] = "block";
        btnSave.Visible = true;
        btnEdit.Visible = false;
        btnReturn.Text = "Revert & Return";
        Franchise objFranchise = new Franchise(PK_Franchise);
        if (objFranchise.FK_Building_Id != null)
        {
            drpFK_Building_Id.SelectedValue = objFranchise.FK_Building_Id.ToString();
            txtRenewal_Options.Text = GetRenewalOptions(Convert.ToDecimal(objFranchise.FK_Building_Id));
        }
        txtConstruction_Start.Text = clsGeneral.FormatDBNullDateToDisplay(objFranchise.Construction_Start);
        if (objFranchise.FK_LU_Franchise_Brand != null) drpFK_LU_Franchise_Brand.SelectedValue = objFranchise.FK_LU_Franchise_Brand.ToString();
        txtConstruction_Finish.Text = clsGeneral.FormatDBNullDateToDisplay(objFranchise.Construction_Finish);
        //if (objFranchise.FK_LU_Franchise_Brand_Image != null) drpFK_LU_Franchise_Brand_Image.SelectedValue = objFranchise.FK_LU_Franchise_Brand_Image.ToString();
        txtAnticipated_Completion.Text = clsGeneral.FormatDBNullDateToDisplay(objFranchise.Anticipated_Completion);
        txtFranchise_Renewal_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objFranchise.Franchise_Renewal_Date);
        txtPlanSubmitted.Text = clsGeneral.FormatDBNullDateToDisplay(objFranchise.Plans_Submitted_for_Approval);
        txtPermitSecured.Text = clsGeneral.FormatDBNullDateToDisplay(objFranchise.Permit_Secured);
        txtSignageOrdered.Text = clsGeneral.FormatDBNullDateToDisplay(objFranchise.Signage_Ordered);
        //txtRenewal_Options.Text = objFranchise.Renewal_Options;
        txtAdditional_Land_Comments.Text = objFranchise.Additional_Land_Comments;
        txtScope_of_Improvements.Text = objFranchise.Scope_of_Improvements;
        txtAdditional_Notes.Text = objFranchise.Additional_Notes;
        txtProposedImprovementCosts.Text = clsGeneral.GetStringValue(objFranchise.Proposed_Improvements_Costs);
        // BindGridTimeLine();
        // bind attachment details 
        BindAttachmentDetails(false);
        drpFK_Building_Id.Focus();
    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Style["display"] = "block";
        dvEdit.Style["display"] = "none";
        btnSave.Visible = false;
        btnEdit.Visible = true;
            //(App_Access == AccessType.Franchise_AddEdit);
        btnReturn.Text = "Back";
        Franchise objFranchise = new Franchise(PK_Franchise);

        if (objFranchise.FK_Building_Id != null)
        {
            //Building objBuilding = new Building(Convert.ToInt32(objFranchise.FK_Building_Id));
            DataTable dtBuilding = Building.SelectByPK(Convert.ToInt32(objFranchise.FK_Building_Id)).Tables[0];
            bool bOccupancy_Sales_New, bOccupancy_Body_Shop, bOccupancy_Parking_Lot, bOccupancy_Sales_Used,
                bOccupancy_Parts, bOccupancy_Raw_Land, bOccupancy_Service, bOccupancy_Ofifce;
            string strOccupancy;

            bOccupancy_Sales_New = Convert.ToBoolean(dtBuilding.Rows[0]["Occupancy_Sales_New"]);
            bOccupancy_Body_Shop = Convert.ToBoolean(dtBuilding.Rows[0]["Occupancy_Body_Shop"]);
            bOccupancy_Parking_Lot = Convert.ToBoolean(dtBuilding.Rows[0]["Occupancy_Parking_Lot"]);
            bOccupancy_Sales_Used = Convert.ToBoolean(dtBuilding.Rows[0]["Occupancy_Sales_Used"]);
            bOccupancy_Parts = Convert.ToBoolean(dtBuilding.Rows[0]["Occupancy_Parts"]);
            bOccupancy_Raw_Land = Convert.ToBoolean(dtBuilding.Rows[0]["Occupancy_Raw_Land"]);
            bOccupancy_Service = Convert.ToBoolean(dtBuilding.Rows[0]["Occupancy_Service"]);
            bOccupancy_Ofifce = Convert.ToBoolean(dtBuilding.Rows[0]["Occupancy_Ofifce"]);

            strOccupancy = ""; // used to set the comma seperated occupancies

            // append occupancy text with comma seperation depending on the values
            strOccupancy = Convert.ToString(dtBuilding.Rows[0]["Building_Number"]) + " - ";
            //if (bOccupancy_Sales_New) strOccupancy = "Sales - New";
            //if (bOccupancy_Sales_New) strOccupancy = strOccupancy != "" ? strOccupancy + "Sales - New" : "Sales - New";

            //if (bOccupancy_Body_Shop) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Body Shop" : "Body Shop";
            //if (bOccupancy_Parking_Lot) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Parking Lot" : "Parking Lot";
            //if (bOccupancy_Sales_Used) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Sales - Used" : "Sales - Used";
            //if (bOccupancy_Parts) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Parts" : "Parts";
            //if (bOccupancy_Raw_Land) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Raw Land" : "Raw Land";
            //if (bOccupancy_Service) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Service" : "Service";
            //if (bOccupancy_Ofifce) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Office" : "Office";

            if (bOccupancy_Sales_New)
                strOccupancy = strOccupancy + "Sales - New" + ", ";
            if (bOccupancy_Body_Shop)
                strOccupancy = strOccupancy + "Body Shop" + ", ";
            if (bOccupancy_Parking_Lot)
                strOccupancy = strOccupancy + "Parking Lot" + ", ";
            if (bOccupancy_Sales_Used)
                strOccupancy = strOccupancy + "Sales - Used" + ", ";
            if (bOccupancy_Parts)
                strOccupancy = strOccupancy + "Parts" + ", ";
            if (bOccupancy_Raw_Land)
                strOccupancy = strOccupancy + "Raw Land" + ", ";
            if (bOccupancy_Service)
                strOccupancy = strOccupancy + "Service" + ", ";
            if (bOccupancy_Ofifce)
                strOccupancy = strOccupancy + "Office" + ", ";

            lblFK_Building_Id.Text = strOccupancy.Trim().Trim(',');

            lblRenewal_Options.Text = GetRenewalOptions(Convert.ToDecimal(objFranchise.FK_Building_Id));
        }
        else
        {
            lblFK_Building_Id.Text = "";
            lblRenewal_Options.Text = "";
        }

        lblConstruction_Start.Text = clsGeneral.FormatDBNullDateToDisplay(objFranchise.Construction_Start);
        if (objFranchise.FK_LU_Franchise_Brand != null)
            lblFK_LU_Franchise_Brand.Text = new LU_Franchise_Brand((decimal)objFranchise.FK_LU_Franchise_Brand).Fld_Desc;
        else
            lblFK_LU_Franchise_Brand.Text = "";

        lblConstruction_Finish.Text = clsGeneral.FormatDBNullDateToDisplay(objFranchise.Construction_Finish);

        lblAnticipated_Completion.Text = clsGeneral.FormatDBNullDateToDisplay(objFranchise.Anticipated_Completion);

        lblFK_LU_Franchise_Plans_Submitted.Text = clsGeneral.FormatDBNullDateToDisplay(objFranchise.Plans_Submitted_for_Approval);
        lblFK_LU_Franchise_Permit_Secured.Text = clsGeneral.FormatDBNullDateToDisplay(objFranchise.Permit_Secured);

        lblFranchise_Renewal_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objFranchise.Franchise_Renewal_Date);
        //lblRenewal_Options.Text = objFranchise.Renewal_Options;
        lblAdditional_Land_Comments.Text = objFranchise.Additional_Land_Comments;
        lblScope_of_Improvements.Text = objFranchise.Scope_of_Improvements;
        lblAdditional_Notes.Text = objFranchise.Additional_Notes;
        lblProposedImprovementCosts.Text = clsGeneral.GetStringValue(objFranchise.Proposed_Improvements_Costs);
        lblSignageOrdered.Text = clsGeneral.FormatDBNullDateToDisplay(objFranchise.Signage_Ordered);

        // BindGridTimeLine();
        // bind attachment details 
        BindAttachmentDetails(true);
    }

    private void SaveData()
    {
        Franchise objFranchise = new Franchise();
        objFranchise.PK_Franchise = PK_Franchise;
        if (drpFK_Building_Id.SelectedIndex > 0) objFranchise.FK_Building_Id = Convert.ToDecimal(drpFK_Building_Id.SelectedValue);
        objFranchise.Construction_Start = clsGeneral.FormatNullDateToStore(txtConstruction_Start.Text);
        if (drpFK_LU_Franchise_Brand.SelectedIndex > 0) objFranchise.FK_LU_Franchise_Brand = Convert.ToDecimal(drpFK_LU_Franchise_Brand.SelectedValue);
        objFranchise.Construction_Finish = clsGeneral.FormatNullDateToStore(txtConstruction_Finish.Text);
        // if (drpFK_LU_Franchise_Brand_Image.SelectedIndex > 0) objFranchise.FK_LU_Franchise_Brand_Image = Convert.ToDecimal(drpFK_LU_Franchise_Brand_Image.SelectedValue);
        objFranchise.Anticipated_Completion = clsGeneral.FormatNullDateToStore(txtAnticipated_Completion.Text);
        //if (drpFK_LU_Franchise_Plans_Submitted.SelectedIndex > 0) objFranchise.FK_LU_Franchise_Plans_Submitted = Convert.ToDecimal(drpFK_LU_Franchise_Plans_Submitted.SelectedValue);
        //if (drpFK_LU_Franchise_Permit_Secured.SelectedIndex > 0) objFranchise.FK_LU_Franchise_Permit_Secured = Convert.ToDecimal(drpFK_LU_Franchise_Permit_Secured.SelectedValue);
        objFranchise.Franchise_Renewal_Date = clsGeneral.FormatNullDateToStore(txtFranchise_Renewal_Date.Text);

        objFranchise.Permit_Secured = clsGeneral.FormatNullDateToStore(txtPermitSecured.Text);
        objFranchise.Plans_Submitted_for_Approval = clsGeneral.FormatNullDateToStore(txtPlanSubmitted.Text);
        objFranchise.Signage_Ordered = clsGeneral.FormatNullDateToStore(txtSignageOrdered.Text);

        objFranchise.Proposed_Improvements_Costs = clsGeneral.GetDecimalNullableValue(txtProposedImprovementCosts);
        objFranchise.Additional_Land_Comments = txtAdditional_Land_Comments.Text.Trim();
        //objFranchise.Renewal_Options = txtRenewal_Options.Text.Trim();
        objFranchise.Scope_of_Improvements = txtScope_of_Improvements.Text.Trim();
        objFranchise.Additional_Notes = txtAdditional_Notes.Text.Trim();
        objFranchise.Updated_By = clsSession.UserID;
        objFranchise.Update_Date = DateTime.Now;
        if (PK_Franchise > 0)
            objFranchise.Update();
        else
            PK_Franchise = objFranchise.Insert();
    }

    //private void BindGridTimeLine()
    //{
    //    DataTable dtTimeline = Franchise_Improvements.SelectByFK(PK_Franchise).Tables[0];
    //    if (StrOperation == "view")
    //    {
    //        gvTiemLineView.DataSource = dtTimeline;
    //        gvTiemLineView.DataBind();
    //    }
    //    else
    //    {
    //        gvTimeLine.DataSource = dtTimeline;
    //        gvTimeLine.DataBind();
    //        gvTimeLine.Columns[gvTimeLine.Columns.Count - 1].Visible = (App_Access == AccessType.Franchise_AddEdit);
    //    }
    //}

    /// <summary>
    /// Gets the Renewal Options for passed building
    /// </summary>
    /// <param name="FK_Building"></param>
    /// <returns></returns>
    private string GetRenewalOptions(decimal FK_Building)
    {
        string strRenewal = "";
        // get renewals from Franchise for selected building
        DataTable dtRenewals = RE_Information.SelectRenewalForFranchise(FK_Building).Tables[0];

        // if row is available then set text for renewal option
        if (dtRenewals.Rows.Count > 0)
            strRenewal = Convert.ToString(dtRenewals.Rows[0][0]);

        return strRenewal;
    }

    #endregion

    #region Control Events
    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveData();
        Response.Redirect("FranchiseAddEdit.aspx?id=" + Encryption.Encrypt(PK_Franchise.ToString()) + "&op=view&loc=" + Request.QueryString["loc"]);
    }
    /// <summary>
    /// Handle Edit Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        StrOperation = "edit";
        BindDetailsForEdit();
        // show attachment panel as the page is loaded again
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    /// <summary>
    /// Handle Return button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("FranchiseGrid.aspx?loc=" + Request.QueryString["loc"]);
    }
    /// <summary>
    /// Handle Add Time Line Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddTimeLine_Click(object sender, EventArgs e)
    {
        SaveData();
        if (PK_Franchise > 0)
        {
            Response.Redirect("ImprovementTimeLine.aspx?fid=" + Encryption.Encrypt(PK_Franchise.ToString()) + "&loc=" + Request.QueryString["loc"]);
        }
    }

    /// <summary>
    /// Handles event when building selection is changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpFK_Building_Id_SelectedIndexChanged(object sender, EventArgs e)
    {
        // if building item is selected
        if (drpFK_Building_Id.SelectedIndex > 0)
        {
            // set renewal text from franchise
            txtRenewal_Options.Text = GetRenewalOptions(Convert.ToDecimal(drpFK_Building_Id.SelectedValue));
        }
        else
        {
            txtRenewal_Options.Text = "";
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    #endregion

    #region Attachments Management
    /// <summary>
    /// Binds the attachment details
    /// </summary>
    private void BindAttachmentDetails(bool bViewMode)
    {
        AttachDetails.InitializeAttachmentDetails(PK_Franchise, !bViewMode, 2);
        AttachDetails.Bind();
    }
    /// <summary>
    /// handles Add Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AddAttachment()
    {
        if (PK_Franchise > 0)
        {
            // add attachment if any.
            Attachment.Add(PK_Franchise);
            // Bind the attachment detail to view the added attachment
            BindAttachmentDetails(false);
            // show attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            // show attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);alert('Please save Franchise details first!');", true);
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

        #region "Customer Information"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(58).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Building ":
                    strCtrlsIDs += drpFK_Building_Id.ClientID + ",";
                    strMessages += "Please select Building " + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Brand":
                    strCtrlsIDs += drpFK_LU_Franchise_Brand.ClientID + ",";
                    strMessages += "Please select Brand" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Franchise Renewal Date":
                    strCtrlsIDs += txtFranchise_Renewal_Date.ClientID + ",";
                    strMessages += "Please enter Franchise Renewal Date" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Plans Submitted for Approval":
                    strCtrlsIDs += txtPlanSubmitted.ClientID + ",";
                    strMessages += "Please enter Plans Submitted for Approval" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Permit Secured":
                    strCtrlsIDs += txtPermitSecured.ClientID + ",";
                    strMessages += "Please enter Permit Secured" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Construction Start":
                    strCtrlsIDs += txtConstruction_Start.ClientID + ",";
                    strMessages += "Please enter Construction Start" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Signage Ordered":
                    strCtrlsIDs += txtSignageOrdered.ClientID + ",";
                    strMessages += "Please enter Signage Ordered" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Anticipated Completion":
                    strCtrlsIDs += txtAnticipated_Completion.ClientID + ",";
                    strMessages += "Please enter Anticipated Completion" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Construction Finish":
                    strCtrlsIDs += txtConstruction_Finish.ClientID + ",";
                    strMessages += "Please enter Construction Finish" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Proposed Improvement Costs":
                    strCtrlsIDs += txtProposedImprovementCosts.ClientID + ",";
                    strMessages += "Please enter Proposed Improvement Costs" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Additional Land Comments":
                    strCtrlsIDs += txtAdditional_Land_Comments.ClientID + ",";
                    strMessages += "Please enter Additional Land Comments" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Renewal Options":
                    //strCtrlsIDs += txtRenewal_Options.ClientID + ",";
                    //strMessages += "Please enter Renewal Options" + ",";
                    //Span12.Style["display"] = "inline-block";
                    break;
                case "Scope of Improvements":
                    strCtrlsIDs += txtScope_of_Improvements.ClientID + ",";
                    strMessages += "Please enter Scope of Improvements" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "Additional Notes":
                    strCtrlsIDs += txtAdditional_Notes.ClientID + ",";
                    strMessages += "Please enter Additional Notes" + ",";
                    Span14.Style["display"] = "inline-block";
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
