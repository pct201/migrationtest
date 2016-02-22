using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
public partial class SONIC_Pollution_Pollution : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Site_Information
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Site_Information"]);
        }
        set { ViewState["PK_PM_Site_Information"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key for compliance report
    /// </summary>
    public decimal PK_PM_Compliance_Reporting
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Compliance_Reporting"]);
        }
        set { ViewState["PK_PM_Compliance_Reporting"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key for remediation 
    /// </summary>
    public decimal PK_PM_Remediation
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Remediation"]);
        }
        set { ViewState["PK_PM_Remediation"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key for Waste Disposal 
    /// </summary>
    public decimal PK_PM_Waste_Disposal
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Waste_Disposal"]);
        }
        set { ViewState["PK_PM_Waste_Disposal"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key for Waste Disposal 
    /// </summary>
    public decimal PK_PM_Violation_Main
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Violation_Main"]);
        }
        set { ViewState["PK_PM_Violation_Main"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key for audit inspection
    /// </summary>
    public decimal PK_PM_Audit_Inspections
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Audit_Inspections"]);
        }
        set { ViewState["PK_PM_Audit_Inspections"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
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
    /// Denotes foriegn key for Location record
    /// </summary>
    public decimal FK_Building_ID
    {
        get { return Convert.ToDecimal(ViewState["FK_Building_ID"]); }
        set { ViewState["FK_Building_ID"] = value; }
    }

    /// <summary>
    /// Used to set the locking flag
    /// </summary>
    public bool IsLockedByCurrentUser
    {
        get { return ViewState["IsLockedByCurrentUser"] == null ? false : Convert.ToBoolean(ViewState["IsLockedByCurrentUser"]); }
        set { ViewState["IsLockedByCurrentUser"] = value; }
    }

    #endregion

    #region Page Events
    /// <summary>
    /// Handles page load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // set tab
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Pollution);
        if (!Page.IsPostBack)
        {            
            Session["SIC"] = null;
            Attachment.Table_Name = "PM_Attachments";
            AttachDetails.Table_Name = "PM_Attachments";
            Attachment.BindAttachmentType();
            
            // check if location id is passed in querystring or not
            if (Request.QueryString["loc"] != null)
            {
                int loc;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out loc))
                    FK_LU_Location_ID = loc;
            }

            if (Request.QueryString["Build"] != null)
            {
                int FK_Build;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["Build"]), out FK_Build))
                    FK_Building_ID = FK_Build;
                Session["EnviroBuilding"] = FK_Building_ID;
            }
            else
                FK_Building_ID = Convert.ToDecimal(Session["EnviroBuilding"]);


            // Bind location information
            if (FK_LU_Location_ID > 0 && FK_Building_ID > 0)
            {
                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();

                // store the location id in session
                Session["ExposureLocation"] = FK_LU_Location_ID;
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx");

            //check for page operation and set operation
            if (Request.QueryString["op"] != null)
                StrOperation = Request.QueryString["op"];

            if (StrOperation != string.Empty)
            {
                // get PK
                if (Request.QueryString["id"] != null && Convert.ToString(Request.QueryString["id"]).Trim() != "")
                    PK_PM_Site_Information = clsGeneral.GetQueryStringID(Request.QueryString["id"]);

                //get PK by PM_Compliance_Reporting
                if (Request.QueryString["fid"] != null && Convert.ToString(Request.QueryString["fid"]).Trim() != "")
                {
                    PK_PM_Compliance_Reporting = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);
                    PM_Compliance_Reporting objPM_Compliance_Reporting = new PM_Compliance_Reporting((decimal)PK_PM_Compliance_Reporting, false);
                    PK_PM_Site_Information = Convert.ToDecimal(objPM_Compliance_Reporting.FK_PM_Site_Information);
                }                

                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDetailsForView();
                    BindAllGridsView();
                    SetBuildingInfo(true);
                    btnEdit.Visible = (App_Access == AccessType.Administrative_Access);
                    // set attachment details control in readonly mode.
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Attachments, Convert.ToInt32(PK_PM_Site_Information), "FK_PM_Site_Information", "PK_PM_Attachments", false, 9);
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

                    BindDropdowns();
                    // Bind Controls
                    BindDetailsForEdit();
                    SetBuildingInfo(false);
                    BindAllGrids();
                    // set attachment details control in read/write mode. so user can add or remove attachment as well.
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Attachments, Convert.ToInt32(PK_PM_Site_Information), "FK_PM_Site_Information", "PK_PM_Attachments", true, 9);

                    SetValidations();
                }
                // bind attachment details to show attachment for current site information
                BindAttachmentDetails();
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

                // check if other user has access for the building
                DataSet dsLock = clsPM_Building_Edit.CheckAccess(FK_Building_ID);
                if (dsLock.Tables[0].Rows.Count > 0)
                {
                    if (dsLock.Tables[0].Rows[0]["FK_Security_ID"].ToString() == clsSession.UserID)
                        IsLockedByCurrentUser = true;
                    else
                    {
                        IsLockedByCurrentUser = false;
                        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('Data for the selected building is currently being added, please wait until the data are saved before editing.');", true);
                    }
                }
                SetBuildingInfo(false);
                BindDropdowns();
                btnSave.Visible = true;
                btnEdit.Visible = false;
                BindAttachmentDetails();
                // don't show div for view mode
                dvView.Style["display"] = "none";
                btnAuditTrail.Visible = false;
                gvUtility.DataBind();
                gvFacility.DataBind();
                gvPermits.DataBind();
                //gvChemicalInventory.DataBind();
                //gvPaintInventory.DataBind();
                gvTierII.DataBind();
                gvAir_Permit.DataBind();
                gvSixH.DataBind();
                gvEquipment.DataBind();
                gvWasteHauler.DataBind();
                gvTSDF.DataBind();
                gvWasteRemoval.DataBind();
                gvFrequency.DataBind();
                //Remove PhaseI Grid : 3187
                //gvPhaseI.DataBind();
                gvEPAInspections.DataBind();
                gvRemediations.DataBind();
                gvViolations.DataBind();

                BindGridOshaLog();
                
                // set attachment details control in read/write mode. so user can add or remove attachment as well.
                AttachDetails.FindControl("gvAttachment").DataBind();
                SetValidations();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            }

            hdPanel.Value = "1";
            // check panel number passed in querystring and show panel accordingly
            if (Request.QueryString["pnl"] != null)
            {
                int intPanel = 1;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["pnl"]), out intPanel))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + intPanel + ");", true);
                    hdPanel.Value = intPanel.ToString();
                }
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            }
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
        else
        {
            if (StrOperation != "view")
                SetPopupValuesOnPostBack();
        }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Save the details
    /// </summary>
    private void SaveData()
    {
        Guid AuditId = Guid.NewGuid();

        // create object and set values
        PM_Site_Information objPM_Site_Information = new PM_Site_Information();
        objPM_Site_Information.PK_PM_Site_Information = PK_PM_Site_Information;
        objPM_Site_Information.FK_LU_Location = FK_LU_Location_ID;
        objPM_Site_Information.FK_Building = FK_Building_ID;
        if (drpFK_County.SelectedIndex > 0) objPM_Site_Information.FK_County = Convert.ToDecimal(drpFK_County.SelectedValue);
        if (hdnSIC.Value != "") objPM_Site_Information.FK_LU_SIC = Convert.ToDecimal(hdnSIC.Value);
        if (hdnNAICS.Value != "") objPM_Site_Information.FK_LU_NAICS = Convert.ToDecimal(hdnNAICS.Value);
        if (txtNumber_Of_Employees.Text != "") objPM_Site_Information.Number_Of_Employees = clsGeneral.GetDecimalValue(txtNumber_Of_Employees);
        if (txtNumber_Of_Shift.Text != "") objPM_Site_Information.Number_Of_Shift = clsGeneral.GetDecimalValue(txtNumber_Of_Shift);
        if (txtDays_Per_Week.Text.Trim() != "") objPM_Site_Information.Days_Per_Week = Convert.ToInt32(txtDays_Per_Week.Text.Trim());
        if (txtWeeks_Per_Year.Text.Trim() != "") objPM_Site_Information.Weeks_Per_Year = Convert.ToInt32(txtWeeks_Per_Year.Text.Trim());
        if (!string.IsNullOrEmpty(txtFacility_Construction_Completion_Year.Text))
            objPM_Site_Information.Facility_Construction_Completion_Year = Convert.ToInt32(txtFacility_Construction_Completion_Year.Text);
        objPM_Site_Information.Owner_Of_Facility = txtOwner_Of_Facility.Text.Trim();
        objPM_Site_Information.Latitude = txtLatitude.Text.Trim();
        objPM_Site_Information.Longitude = txtLongitude.Text.Trim();
        objPM_Site_Information.Update_Date = DateTime.Now;
        objPM_Site_Information.Updated_By = clsSession.UserID;
        objPM_Site_Information.AuditID = AuditId;

        // insert or update the records based on PK
        if (PK_PM_Site_Information > 0)
            objPM_Site_Information.Update();
        else
            PK_PM_Site_Information = objPM_Site_Information.Insert();

        // save compliance reporting details
        PM_Compliance_Reporting objPM_Compliance_Reporting = new PM_Compliance_Reporting();
        objPM_Compliance_Reporting.PK_PM_Compliance_Reporting = PK_PM_Compliance_Reporting;
        objPM_Compliance_Reporting.FK_PM_Site_Information = PK_PM_Site_Information;
        //objPM_Compliance_Reporting.Federal_Facility_Identification_Number = txtFederal_Facility_Identification_Number.Text.Trim();
        //objPM_Compliance_Reporting.State_Facility_Identification_Number = txtState_Facility_Identification_Number.Text.Trim();
        objPM_Compliance_Reporting.Contact_Name = txtContact_Name.Text.Trim();
        objPM_Compliance_Reporting.Contact_Telephone = txtContact_Telephone.Text.Trim();
        objPM_Compliance_Reporting.Emergency_Contact_Name = txtEmergency_Contact_Name.Text.Trim();
        objPM_Compliance_Reporting.Emergency_Telephone = txtEmergency_Telephone.Text.Trim();
        objPM_Compliance_Reporting.Update_Date = DateTime.Now;
        objPM_Compliance_Reporting.Updated_By = clsSession.UserID;
        objPM_Compliance_Reporting.AuditID = AuditId;
        if (PK_PM_Compliance_Reporting > 0)
            objPM_Compliance_Reporting.Update();
        else
            PK_PM_Compliance_Reporting = objPM_Compliance_Reporting.Insert();

        // save Remediation details
        PM_Remediation objRemediation = new PM_Remediation();
        objRemediation.PK_PM_Remediation = PK_PM_Remediation;
        objRemediation.FK_PM_Site_Information = PK_PM_Site_Information;
        objRemediation.Notes = txtRemediationNote.Text.Trim();
        objRemediation.Update_Date = DateTime.Now;
        objRemediation.Updated_By = clsSession.UserID;
        objRemediation.AuditID = AuditId;
        if (PK_PM_Remediation > 0)
            objRemediation.Update();
        else
            PK_PM_Remediation = objRemediation.Insert();

        //save waste disposal notes
        PM_Waste_Disposal objDisposal = new PM_Waste_Disposal();
        objDisposal.PK_PM_Waste_Disposal = PK_PM_Waste_Disposal;
        objDisposal.FK_PM_Site_Information = PK_PM_Site_Information;
        objDisposal.Notes = txtWasteDisposalNotes.Text.Trim();
        objDisposal.Update_Date = DateTime.Now;
        objDisposal.Updated_By = clsSession.UserID;
        objDisposal.AuditID = AuditId;
        if (PK_PM_Waste_Disposal > 0)
            objDisposal.Update();
        else
            PK_PM_Waste_Disposal = objDisposal.Insert();

        //save audit/inspection notes
        PM_Audit_Inspections objInspection = new PM_Audit_Inspections();
        objInspection.PK_PM_Audit_Inspections = PK_PM_Audit_Inspections;
        objInspection.FK_PM_Site_Information = PK_PM_Site_Information;
        objInspection.Notes = txtInspectionNotes.Text.Trim();
        objInspection.Update_Date = DateTime.Now;
        objInspection.Updated_By = clsSession.UserID;
        objInspection.AuditID = AuditId;
        if (PK_PM_Audit_Inspections > 0)
            objInspection.Update();
        else
            PK_PM_Audit_Inspections = objInspection.Insert();

        //save violations notes
        PM_Violation_Main objViolation = new PM_Violation_Main();
        objViolation.PK_PM_Violation_Main = PK_PM_Violation_Main;
        objViolation.FK_PM_Site_Information = PK_PM_Site_Information;
        objViolation.Notes = txtViolationsNotes.Text.Trim();
        objViolation.Update_Date = DateTime.Now;
        objViolation.Updated_By = clsSession.UserID;
        objViolation.AuditID = AuditId;
        if (PK_PM_Violation_Main > 0)
            objViolation.Update();
        else
            PK_PM_Violation_Main = objViolation.Insert();

        // save attachment
        btnAddAttachment_Click("");
    }

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnSave.Visible = true;
        btnEdit.Visible = false;

        // create object for site_information
        PM_Site_Information objPM_Site_Information;

        // if PK is available then select by PK else select by location ID
        if (PK_PM_Site_Information > 0)
            objPM_Site_Information = new PM_Site_Information(PK_PM_Site_Information, false);
        else
            objPM_Site_Information = new PM_Site_Information(FK_LU_Location_ID, true);
        if (objPM_Site_Information.PK_PM_Site_Information > 0) PK_PM_Site_Information = (decimal)objPM_Site_Information.PK_PM_Site_Information;
        //if (objPM_Site_Information.FK_Building != null)
        //{
        //    ListItem lst = drpFK_Building.Items.FindByValue(objPM_Site_Information.FK_Building.ToString());
        //    if (lst != null)
        //        lst.Selected = true;
        //    //drpFK_Building.SelectedValue = objPM_Site_Information.FK_Building.ToString();
        //}
        if (objPM_Site_Information.FK_County != null)
        {
            ListItem lst = drpFK_County.Items.FindByValue(objPM_Site_Information.FK_County.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_County.SelectedValue = objPM_Site_Information.FK_County.ToString();
        }

        // if SIC ID is avaialble
        if (objPM_Site_Information.FK_LU_SIC != null)
        {
            // create object for SIC and set code and descriptions
            LU_SIC objSIC = new LU_SIC((decimal)objPM_Site_Information.FK_LU_SIC);
            string strDesc = objSIC.Fld_Desc_1 + "<br/>" + objSIC.Fld_Desc_2 + "<br/>" + objSIC.Fld_Desc_3;

            hdnSIC.Value = objPM_Site_Information.FK_LU_SIC.ToString();
            txtSIC.Text = objSIC.Fld_Code;
            lblSIC.Text = strDesc;
            txtSICDesc.Text = Server.HtmlEncode(strDesc);
            Session["SIC"] = txtSIC.Text + ":" + lblSIC.Text;
        }

        // if NAICS ID is avaialble then set all level descriptions
        if (objPM_Site_Information.FK_LU_NAICS != null)
        {
            DataTable dtNAICS = LU_NAICS.SelectDescriptionsByPK((decimal)objPM_Site_Information.FK_LU_NAICS).Tables[0];
            if (dtNAICS.Rows.Count > 0)
            {
                DataRow dr = dtNAICS.Rows[0];
                string strDesc = "";
                strDesc = Convert.ToString(dr["Desc_1"]);
                if (!string.IsNullOrEmpty(Convert.ToString(dr["Desc_2"]))) strDesc = strDesc + "<br/>" + Convert.ToString(dr["Desc_2"]);
                if (!string.IsNullOrEmpty(Convert.ToString(dr["Desc_3"]))) strDesc = strDesc + "<br/>" + Convert.ToString(dr["Desc_3"]);
                if (!string.IsNullOrEmpty(Convert.ToString(dr["Desc_4"]))) strDesc = strDesc + "<br/>" + Convert.ToString(dr["Desc_4"]);
                if (!string.IsNullOrEmpty(Convert.ToString(dr["Desc_5"]))) strDesc = strDesc + "<br/>" + Convert.ToString(dr["Desc_5"]);

                hdnNAICS.Value = objPM_Site_Information.FK_LU_NAICS.ToString();
                txtNAICS.Text = dr["Fld_Code"].ToString();
                lblNAICS.Text = strDesc;
                txtNAICSDesc.Text = Server.HtmlEncode(strDesc);
            }
        }
        txtNumber_Of_Employees.Text = string.Format("{0:N0}", objPM_Site_Information.Number_Of_Employees);
        txtNumber_Of_Shift.Text = string.Format("{0:N0}", objPM_Site_Information.Number_Of_Shift);
        txtDays_Per_Week.Text = string.Format("{0:N0}", objPM_Site_Information.Days_Per_Week);
        txtWeeks_Per_Year.Text = string.Format("{0:N0}", objPM_Site_Information.Weeks_Per_Year);
        txtFacility_Construction_Completion_Year.Text = Convert.ToString(objPM_Site_Information.Facility_Construction_Completion_Year);
        txtOwner_Of_Facility.Text = objPM_Site_Information.Owner_Of_Facility;
        txtLatitude.Text = objPM_Site_Information.Latitude;
        txtLongitude.Text = objPM_Site_Information.Longitude;

        // bind compliance reporting details
        PM_Compliance_Reporting objPM_Compliance_Reporting = new PM_Compliance_Reporting((decimal)PK_PM_Site_Information, true);
        if (objPM_Compliance_Reporting.PK_PM_Compliance_Reporting > 0) PK_PM_Compliance_Reporting = (decimal)objPM_Compliance_Reporting.PK_PM_Compliance_Reporting;
        //txtFederal_Facility_Identification_Number.Text = objPM_Compliance_Reporting.Federal_Facility_Identification_Number;
        //txtState_Facility_Identification_Number.Text = objPM_Compliance_Reporting.State_Facility_Identification_Number;
        txtContact_Name.Text = objPM_Compliance_Reporting.Contact_Name;
        txtContact_Telephone.Text = objPM_Compliance_Reporting.Contact_Telephone;
        txtEmergency_Contact_Name.Text = objPM_Compliance_Reporting.Emergency_Contact_Name;
        txtEmergency_Telephone.Text = objPM_Compliance_Reporting.Emergency_Telephone;

        // bind remediation details
        PM_Remediation objPM_Remediation = new PM_Remediation((decimal)PK_PM_Site_Information, true);
        if (objPM_Remediation.PK_PM_Remediation > 0) PK_PM_Remediation = (decimal)objPM_Remediation.PK_PM_Remediation;
        txtRemediationNote.Text = objPM_Remediation.Notes;

        // bind waste disposal notes
        PM_Waste_Disposal objDisposal = new PM_Waste_Disposal((decimal)PK_PM_Site_Information, true);
        if (objDisposal.PK_PM_Waste_Disposal > 0) PK_PM_Waste_Disposal = (decimal)objDisposal.PK_PM_Waste_Disposal;
        txtWasteDisposalNotes.Text = objDisposal.Notes;

        // bind audit inspection notes
        PM_Audit_Inspections objInspections = new PM_Audit_Inspections((decimal)PK_PM_Site_Information, true);
        if (objInspections.PK_PM_Audit_Inspections > 0) PK_PM_Audit_Inspections = (decimal)objInspections.PK_PM_Audit_Inspections;
        txtInspectionNotes.Text = objInspections.Notes;

        // bind violation notes
        PM_Violation_Main objViolation = new PM_Violation_Main((decimal)PK_PM_Site_Information, true);
        if (objViolation.PK_PM_Violation_Main > 0) PK_PM_Violation_Main = (decimal)objViolation.PK_PM_Violation_Main;
        txtViolationsNotes.Text = objViolation.Notes;
    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        btnSave.Visible = false;
        btnEdit.Visible = true;
        // create object for site_information
        PM_Site_Information objPM_Site_Information;

        // if PK is available then select by PK else select by location ID
        if (PK_PM_Site_Information > 0)
            objPM_Site_Information = new PM_Site_Information(PK_PM_Site_Information, false);
        else
            objPM_Site_Information = new PM_Site_Information(FK_LU_Location_ID, true);

        if (objPM_Site_Information.PK_PM_Site_Information > 0) PK_PM_Site_Information = (decimal)objPM_Site_Information.PK_PM_Site_Information;

        if (objPM_Site_Information.FK_County != null)
            lblFK_County.Text = new County((decimal)objPM_Site_Information.FK_County).FLD_county;
        else
            lblFK_County.Text = "";
        // if SIC ID is avaialble
        if (objPM_Site_Information.FK_LU_SIC != null)
        {
            // create object for SIC and set code and descriptions
            LU_SIC objSIC = new LU_SIC((decimal)objPM_Site_Information.FK_LU_SIC);
            lblFK_LU_SIC.Text = objSIC.Fld_Code;
            lblSICDesc.Text = objSIC.Fld_Desc_1 + "<br/>" + objSIC.Fld_Desc_2 + "<br/>" + objSIC.Fld_Desc_3;

            Session["SIC"] = lblFK_LU_SIC.Text + ":" + lblSICDesc.Text;
        }
        else
        {
            lblFK_LU_SIC.Text = "";
            lblSICDesc.Text = "";
        }

        // if NAICS ID is avaialble then set all level descriptions
        if (objPM_Site_Information.FK_LU_NAICS != null)
        {
            DataTable dtNAICS = LU_NAICS.SelectDescriptionsByPK((decimal)objPM_Site_Information.FK_LU_NAICS).Tables[0];
            if (dtNAICS.Rows.Count > 0)
            {
                DataRow dr = dtNAICS.Rows[0];
                string strDesc = "";
                strDesc = Convert.ToString(dr["Desc_1"]);
                if (!string.IsNullOrEmpty(Convert.ToString(dr["Desc_2"]))) strDesc = strDesc + "<br/>" + Convert.ToString(dr["Desc_2"]);
                if (!string.IsNullOrEmpty(Convert.ToString(dr["Desc_3"]))) strDesc = strDesc + "<br/>" + Convert.ToString(dr["Desc_3"]);
                if (!string.IsNullOrEmpty(Convert.ToString(dr["Desc_4"]))) strDesc = strDesc + "<br/>" + Convert.ToString(dr["Desc_4"]);
                if (!string.IsNullOrEmpty(Convert.ToString(dr["Desc_5"]))) strDesc = strDesc + "<br/>" + Convert.ToString(dr["Desc_5"]);

                lblFK_LU_NAICS.Text = dr["Fld_Code"].ToString();
                lblNAICSDesc.Text = strDesc;
            }
            else
            {
                lblFK_LU_NAICS.Text = "";
                lblNAICSDesc.Text = "";
            }
        }
        else
        {
            lblFK_LU_NAICS.Text = "";
            lblNAICSDesc.Text = "";
        }
        lblNumber_Of_Employees.Text = string.Format("{0:N0}", objPM_Site_Information.Number_Of_Employees);
        lblNumber_Of_Shift.Text = string.Format("{0:N0}", objPM_Site_Information.Number_Of_Shift);
        lblDays_Per_Week.Text = string.Format("{0:N0}", objPM_Site_Information.Days_Per_Week);
        lblWeeks_Per_Year.Text = string.Format("{0:N0}", objPM_Site_Information.Weeks_Per_Year);
        lblFacility_Construction_Completion_Year.Text = Convert.ToString(objPM_Site_Information.Facility_Construction_Completion_Year);
        lblOwner_Of_Facility.Text = objPM_Site_Information.Owner_Of_Facility;
        lblLatitude.Text = objPM_Site_Information.Latitude;
        lblLongitude.Text = objPM_Site_Information.Longitude;

        // bind Compliance Reporting details
        PM_Compliance_Reporting objPM_Compliance_Reporting = new PM_Compliance_Reporting((decimal)PK_PM_Site_Information, true);
        if (objPM_Compliance_Reporting.PK_PM_Compliance_Reporting > 0) PK_PM_Compliance_Reporting = (decimal)objPM_Compliance_Reporting.PK_PM_Compliance_Reporting;
        //lblFederal_Facility_Identification_Number.Text = objPM_Compliance_Reporting.Federal_Facility_Identification_Number;
        //lblState_Facility_Identification_Number.Text = objPM_Compliance_Reporting.State_Facility_Identification_Number;
        lblContact_Name.Text = objPM_Compliance_Reporting.Contact_Name;
        lblContact_Telephone.Text = objPM_Compliance_Reporting.Contact_Telephone;
        lblEmergency_Contact_Name.Text = objPM_Compliance_Reporting.Emergency_Contact_Name;
        lblEmergency_Telephone.Text = objPM_Compliance_Reporting.Emergency_Telephone;

        // bind remediation details
        PM_Remediation objPM_Remediation = new PM_Remediation((decimal)PK_PM_Site_Information, true);
        if (objPM_Remediation.PK_PM_Remediation > 0) PK_PM_Remediation = (decimal)objPM_Remediation.PK_PM_Remediation;
        lblRemediationNotes.Text = objPM_Remediation.Notes;

        // bind waste disposal notes
        PM_Waste_Disposal objDisposal = new PM_Waste_Disposal((decimal)PK_PM_Site_Information, true);
        if (objDisposal.PK_PM_Waste_Disposal > 0) PK_PM_Waste_Disposal = (decimal)objDisposal.PK_PM_Waste_Disposal;
        lblWasteDisposalNotes.Text = objDisposal.Notes;

        // bind audit inspection notes
        PM_Audit_Inspections objInspections = new PM_Audit_Inspections((decimal)PK_PM_Site_Information, true);
        if (objInspections.PK_PM_Audit_Inspections > 0) PK_PM_Audit_Inspections = (decimal)objInspections.PK_PM_Audit_Inspections;
        lblInspectionNotes.Text = objInspections.Notes;

        // bind violation notes
        PM_Violation_Main objViolation = new PM_Violation_Main((decimal)PK_PM_Site_Information, true);
        if (objViolation.PK_PM_Violation_Main > 0) PK_PM_Violation_Main = (decimal)objViolation.PK_PM_Violation_Main;
        lblViolationsNotes.Text = objViolation.Notes;

        // show change building button if more than one building is avaialble for the location
        btnChangeBuilding.Visible = (Building.SelectByFKLocation(FK_LU_Location_ID).Tables[0].Rows.Count > 1);

    }

    private void SetBuildingInfo(bool bView)
    {
        if (FK_Building_ID > 0)
        {
            Building objBuilding = new Building((int)FK_Building_ID);
            string strBuilding = objBuilding.Building_Number + " - ";
            string strOccupancy = "";

            if (Convert.ToBoolean(objBuilding.Occupancy_Sales_New)) strOccupancy = "Sales - New";
            if (Convert.ToBoolean(objBuilding.Occupancy_Body_Shop)) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Body Shop" : "Body Shop";
            if (Convert.ToBoolean(objBuilding.Occupancy_Parking_Lot)) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Parking Lot" : "Parking Lot";
            if (Convert.ToBoolean(objBuilding.Occupancy_Sales_Used)) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Sales - Used" : "Sales - Used";
            if (Convert.ToBoolean(objBuilding.Occupancy_Parts)) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Parts" : "Parts";
            if (Convert.ToBoolean(objBuilding.Occupancy_Raw_Land)) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Raw Land" : "Raw Land";
            if (Convert.ToBoolean(objBuilding.Occupancy_Service)) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Service" : "Service";
            if (Convert.ToBoolean(objBuilding.Occupancy_Ofifce)) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Office" : "Office";

            strBuilding = strBuilding + strOccupancy + "</br>";

            if (!string.IsNullOrEmpty(objBuilding.Address_1)) strBuilding = strBuilding + objBuilding.Address_1 + ", ";
            if (!string.IsNullOrEmpty(objBuilding.City)) strBuilding = strBuilding + objBuilding.City + ", ";
            if (!string.IsNullOrEmpty(objBuilding.State)) strBuilding = strBuilding + objBuilding.State + ", ";
            if (!string.IsNullOrEmpty(objBuilding.Zip)) strBuilding = strBuilding + objBuilding.Zip;

            if (bView)
                lblFK_BuildingView.Text = strBuilding;
            else
                lblFK_Building.Text = strBuilding;
        }
    }

    /// <summary>
    /// Bind DropDownList Box
    /// </summary>
    private void BindDropdowns()
    {
        //DataTable dtBuilding = Building.BuildingByFKLocation(FK_LU_Location_ID).Tables[0];
        //dtBuilding.DefaultView.Sort = "Building_Number ASC";
        //dtBuilding = dtBuilding.DefaultView.ToTable();
        //for (int i = 0; i < dtBuilding.Rows.Count; i++)
        //{
        //    string strBuilding = "";
        //    DataRow dr = dtBuilding.Rows[i];
        //    strBuilding = Convert.ToString(dr["Building_Number"]);
        //    if (!string.IsNullOrEmpty(Convert.ToString(dr["Address_1"])))
        //        strBuilding = strBuilding.Length > 0 ? strBuilding + ", " + dr["Address_1"] : strBuilding;
        //    if (!string.IsNullOrEmpty(Convert.ToString(dr["City"])))
        //        strBuilding = strBuilding.Length > 0 ? strBuilding + ", " + dr["City"] : strBuilding;
        //    if (!string.IsNullOrEmpty(Convert.ToString(dr["State"])))
        //        strBuilding = strBuilding.Length > 0 ? strBuilding + ", " + dr["State"] : strBuilding;

        //    // set text in occupancy column
        //    drpFK_Building.Items.Add(new ListItem(strBuilding.Trim().Trim(','), Convert.ToString(dr["PK_Building_ID"])));

        //}

        //drpFK_Building.DataSource = dtBuilding;
        //drpFK_Building.DataTextField = "Building_Occupacy";
        //drpFK_Building.DataValueField = "PK_Building_ID";
        //drpFK_Building.DataBind();
        //drpFK_Building.Items.Insert(0, new ListItem("--Select--", "0"));

        //bind county dropdown
        drpFK_County.Items.Clear();
        string strState = ((Label)ucCtrlExposureInfo.FindControl("lblState")).Text;
        if (!string.IsNullOrEmpty(strState))
        {
            DataTable dtCounty = County.SelectAllByState(strState).Tables[0];
            drpFK_County.DataSource = dtCounty;
            drpFK_County.DataTextField = "Fld_County";
            drpFK_County.DataValueField = "PK_ID";
            drpFK_County.DataBind();
        }
        drpFK_County.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    /// <summary>
    /// Sets popup values on postback
    /// </summary>
    private void SetPopupValuesOnPostBack()
    {
        // SIC popup values
        txtSIC.Text = Request.Form[txtSIC.UniqueID];
        txtSICDesc.Text = Request.Form[txtSICDesc.UniqueID];
        lblSIC.Text = Server.HtmlDecode(txtSICDesc.Text);        

        // NAICS popup values
        txtNAICS.Text = Request.Form[txtNAICS.UniqueID];
        txtNAICSDesc.Text = Request.Form[txtNAICSDesc.UniqueID];
        lblNAICS.Text = Server.HtmlDecode(txtNAICSDesc.Text);
    }

    /// <summary>
    /// Binds all grids on the page
    /// </summary>
    private void BindAllGrids()
    {
        DataSet dsGrids = PM_Site_Information.SelectAllGrids(PK_PM_Site_Information);

        // Utility Provider Grid
        gvUtility.DataSource = dsGrids.Tables[0];
        gvUtility.DataBind();

        // Facility Id Grid
        gvFacility.DataSource = dsGrids.Tables[1];
        gvFacility.DataBind();

        // Permits  Grid
        gvPermits.DataSource = dsGrids.Tables[2];
        gvPermits.DataBind();

        //// Chemical Inventory Grid
        //gvChemicalInventory.DataSource = dsGrids.Tables[3];
        //gvChemicalInventory.DataBind();

        //// Paint Inventory Grid
        //gvPaintInventory.DataSource = dsGrids.Tables[4];
        //gvPaintInventory.DataBind();

        // Equipment Grid
        gvEquipment.DataSource = dsGrids.Tables[5];
        gvEquipment.DataBind();

        // Waste Hauler Grid
        gvWasteHauler.DataSource = dsGrids.Tables[6];
        gvWasteHauler.DataBind();

        // Receiving TSDF Grid
        gvTSDF.DataSource = dsGrids.Tables[7];
        gvTSDF.DataBind();

        // Waste Removal Grid
        gvWasteRemoval.DataSource = dsGrids.Tables[8];
        gvWasteRemoval.DataBind();

        // Frequency Grid
        gvFrequency.DataSource = dsGrids.Tables[9];
        gvFrequency.DataBind();

        // Phase I Grid
        //Remove PhaseI Grid : 3187
        //gvPhaseI.DataSource = dsGrids.Tables[10];
        //gvPhaseI.DataBind();

        // EPA Inspections Grid
        gvEPAInspections.DataSource = dsGrids.Tables[11];
        gvEPAInspections.DataBind();

        // Remediations Grid
        gvRemediations.DataSource = dsGrids.Tables[12];
        gvRemediations.DataBind();

        // Violations Grid
        gvViolations.DataSource = dsGrids.Tables[13];
        gvViolations.DataBind();

        // TierII Grid
        gvTierII.DataSource = dsGrids.Tables[14];
        gvTierII.DataBind();

        // Air Permit Grid
        gvAir_Permit.DataSource = dsGrids.Tables[15];
        gvAir_Permit.DataBind();

        // 6H Grid
        gvSixH.DataSource = dsGrids.Tables[16];
        gvSixH.DataBind();

        BindGridOshaLog();        
    }

    /// <summary>
    /// Binds all grids on the page
    /// </summary>
    private void BindAllGridsView()
    {
        DataSet dsGrids = PM_Site_Information.SelectAllGrids(PK_PM_Site_Information);

        // Utility Provider Grid
        gvUtilityView.DataSource = dsGrids.Tables[0];
        gvUtilityView.DataBind();

        // Facility Id Grid
        gvFacilityView.DataSource = dsGrids.Tables[1];
        gvFacilityView.DataBind();

        // Permits  Grid
        gvPermitsView.DataSource = dsGrids.Tables[2];
        gvPermitsView.DataBind();

        //// Chemical Inventory Grid
        //gvChemicalInventoryView.DataSource = dsGrids.Tables[3];
        //gvChemicalInventoryView.DataBind();

        //// Paint Inventory Grid
        //gvPaintInventoryView.DataSource = dsGrids.Tables[4];
        //gvPaintInventoryView.DataBind();

        // Equipment Grid
        gvEquipmentView.DataSource = dsGrids.Tables[5];
        gvEquipmentView.DataBind();

        // Waste Hauler Grid
        gvWasteHaulerView.DataSource = dsGrids.Tables[6];
        gvWasteHaulerView.DataBind();

        // Receiving TSDF Grid
        gvTSDFView.DataSource = dsGrids.Tables[7];
        gvTSDFView.DataBind();

        // Waste Removal Grid
        gvWasteRemovalView.DataSource = dsGrids.Tables[8];
        gvWasteRemovalView.DataBind();

        // Frequency Grid
        gvFrequencyView.DataSource = dsGrids.Tables[9];
        gvFrequencyView.DataBind();

        // Phase I Grid
        //gvPhaseIView.DataSource = dsGrids.Tables[10];
        //gvPhaseIView.DataBind();

        // EPA Inspections Grid
        gvEPAInspectionsView.DataSource = dsGrids.Tables[11];
        gvEPAInspectionsView.DataBind();

        // Remediations Grid
        gvRemediationsView.DataSource = dsGrids.Tables[12];
        gvRemediationsView.DataBind();

        // Violations Grid
        gvViolationsView.DataSource = dsGrids.Tables[13];
        gvViolationsView.DataBind();

        // Tier II Grid
        gvTierIIView.DataSource = dsGrids.Tables[14];
        gvTierIIView.DataBind();

        // Air Permit Grid
        gvAir_PermitView.DataSource = dsGrids.Tables[15];
        gvAir_PermitView.DataBind();

        // 6H Grid
        gvSixHView.DataSource = dsGrids.Tables[16];
        gvSixHView.DataBind();

        BindGridOshaLog();
        //BindGridViewOshaLog();
    }

    /// <summary>
    /// Binds Utility Provider grid
    /// </summary>
    private void BindGridUtilityProvider()
    {
        DataTable dtUtility = PM_SI_Utility_Provider.SelectByFK_SiteInfo(PK_PM_Site_Information).Tables[0];
        gvUtility.DataSource = dtUtility;
        gvUtility.DataBind();
    }

    /// <summary>
    /// Binds facility ID grid
    /// </summary>
    private void BindGridFacilityID()
    {
        DataTable dtFacility = PM_SI_Facility_Id.SelectByFK_SiteInfo(PK_PM_Site_Information).Tables[0];
        gvFacility.DataSource = dtFacility;
        gvFacility.DataBind();
    }

    /// <summary>
    /// Binds permits grid
    /// </summary>
    private void BindGridPermits()
    {
        DataTable dtPermits = PM_Permits.SelectByFK_SiteInfo(PK_PM_Site_Information).Tables[0];
        gvPermits.DataSource = dtPermits;
        gvPermits.DataBind();
    }

    ///// <summary>
    ///// Binds chemical inventory grid
    ///// </summary>
    //private void BindGridChemicalInv()
    //{
    //    DataTable dtInventory = clsPM_CR_Chemical_Inventory.SelectByFK_SiteInfo(PK_PM_Site_Information).Tables[0];
    //    gvChemicalInventory.DataSource = dtInventory;
    //    gvChemicalInventory.DataBind();
    //}

    ///// <summary>
    ///// Binds Paint inventory grid
    ///// </summary>
    //private void BindGridPaintInv()
    //{
    //    DataTable dtInventory = PM_CR_Paint_Inventory.SelectByFK_SiteInfo(PK_PM_Site_Information).Tables[0];
    //    gvPaintInventory.DataSource = dtInventory;
    //    gvPaintInventory.DataBind();
    //}

    /// <summary>
    /// Binds Tier II grid
    /// </summary>
    private void BindGridTierII()
    {
        DataTable dtCR_Grids = PM_CR_Grids.SelectByFK(PK_PM_Site_Information, "TierII").Tables[0];
        gvTierII.DataSource = dtCR_Grids;
        gvTierII.DataBind();
    }

    /// <summary>
    /// Binds Air_Permit grid
    /// </summary>
    private void BindGridAir_Permit()
    {
        DataTable dtCR_Grids = PM_CR_Grids.SelectByFK(PK_PM_Site_Information, "Air Permit").Tables[0];
        gvAir_Permit.DataSource = dtCR_Grids;
        gvAir_Permit.DataBind();
    }

    /// <summary>
    /// Binds SixH grid
    /// </summary>
    private void BindGridSixH()
    {
        DataTable dtCR_Grids = PM_CR_Grids.SelectByFK(PK_PM_Site_Information, "6H").Tables[0];
        gvSixH.DataSource = dtCR_Grids;
        gvSixH.DataBind();
    }

    /// <summary>
    /// Binds equipment grid
    /// </summary>
    private void BindGridEquipment()
    {
        DataTable dtEquipment = clsPM_Equipment.SelectByFK_SiteInfo(PK_PM_Site_Information).Tables[0];
        gvEquipment.DataSource = dtEquipment;
        gvEquipment.DataBind();
    }

    /// <summary>
    /// Binds waste hauler grid
    /// </summary>
    private void BindGridWasteHauler()
    {
        DataTable dtWasteHauler = PM_Waste_Hauler.SelectByFK_SiteInfo(PK_PM_Site_Information).Tables[0];
        gvWasteHauler.DataSource = dtWasteHauler;
        gvWasteHauler.DataBind();
    }
    /// <summary>
    /// Binds Receiving TSDF Grid
    /// </summary>
    private void BindGridTSDF()
    {
        DataTable dtTSDF = PM_Receiving_TSDF.SelectByFK_SiteInfo(PK_PM_Site_Information).Tables[0];
        gvTSDF.DataSource = dtTSDF;
        gvTSDF.DataBind();
    }

    /// <summary>
    /// Binds Receiving TSDF Grid
    /// </summary>
    private void BindGridWasteRemoval()
    {
        DataTable dtWasteRemoval = PM_Waste_Removal.SelectByFK_SiteInfo(PK_PM_Site_Information).Tables[0];
        gvWasteRemoval.DataSource = dtWasteRemoval;
        gvWasteRemoval.DataBind();
    }

    /// <summary>
    /// Binds Frequency Grid
    /// </summary>
    private void BindGridFrequency()
    {
        DataTable dtFrequency = PM_Frequency.SelectByFK_SiteInfo(PK_PM_Site_Information).Tables[0];
        gvFrequency.DataSource = dtFrequency;
        gvFrequency.DataBind();
    }

    /// <summary>
    /// Binds Phase I Grid
    /// </summary>
    private void BindGridPhaseI()
    {
        //DataTable dtPhaseI = PM_Phase_I.SelectByFK_SiteInfo(PK_PM_Site_Information).Tables[0];
        //gvPhaseI.DataSource = dtPhaseI;
        //gvPhaseI.DataBind();
    }

    /// <summary>
    /// Binds Phase I Grid
    /// </summary>
    private void BindGridEPAInspection()
    {
        DataTable dtEPAInspection = PM_EPA_Inspection.SelectByFK_SiteInfo(PK_PM_Site_Information).Tables[0];
        gvEPAInspections.DataSource = dtEPAInspection;
        gvEPAInspections.DataBind();
    }

    /// <summary>
    /// Binds Remediation Grid
    /// </summary>
    private void BindGridRemediation()
    {
        DataTable dtRemediation = PM_Remediation_Grid.SelectByFK_SiteInfo(PK_PM_Site_Information).Tables[0];
        gvRemediations.DataSource = dtRemediation;
        gvRemediations.DataBind();
    }

    /// <summary>
    /// Binds Violation Grid
    /// </summary>
    private void BindGridViolation()
    {
        DataTable dtViolation = PM_Violation.SelectByFK_SiteInfo(PK_PM_Site_Information).Tables[0];
        gvViolations.DataSource = dtViolation;
        gvViolations.DataBind();
    }

    /// <summary>
    /// Binds SixH grid
    /// </summary>
    private void BindGridOshaLog()
    {
        
        if (PK_PM_Compliance_Reporting > 0)
        {
            lnkComplainceReportingOSHA.Visible = true;
            DataSet ds = clsPM_Complaince_Reporting_OSHA.SelectByFK(PK_PM_Compliance_Reporting);
            DataTable dtCompliance_Reporting = ds.Tables[0];
            gvComplainceReportingOSHA.DataSource = gvOshaLogGridView.DataSource = dtCompliance_Reporting;
            gvComplainceReportingOSHA.DataBind();
            gvOshaLogGridView.DataBind();
        }
        else
        {
            lnkComplainceReportingOSHA.Visible = false;
            gvComplainceReportingOSHA.DataBind();
        }
    }

    //private void BindGridViewOshaLog()
    //{

    //    if (PK_PM_Compliance_Reporting > 0)
    //    {
    //        DataSet ds = clsPM_Complaince_Reporting_OSHA.SelectByFK(PK_PM_Compliance_Reporting);
    //        DataTable dtCompliance_Reporting = ds.Tables[0];
    //        gvOshaLogGridView.DataSource = dtCompliance_Reporting;
    //        gvOshaLogGridView.DataBind();
    //    }
    //    else
    //    {
    //        gvOshaLogGridView.DataBind();
    //    }
    //}
    #endregion

    #region Control Events

    //protected void drpFK_Building_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (drpFK_Building.SelectedIndex > 0)
    //    {
    //        if ((drpFK_Building.SelectedValue != null) && (!string.IsNullOrEmpty(drpFK_Building.SelectedValue)))
    //        {
    //            Building objBuilding = new Building(Convert.ToInt16(drpFK_Building.SelectedValue));
    //            txtFacility_Construction_Completion_Year.Text = objBuilding.Year_Built;
    //        }
    //    }
    //    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    //}

    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (PK_PM_Site_Information == 0 && !IsLockedByCurrentUser)
        {
            if (PM_Site_Information.SelectByBuildLoc(FK_LU_Location_ID, FK_Building_ID).Tables[0].Rows.Count > 0)
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('Data for the selected building has already been added, please return to the building grid and select to edit the data, if desired.');window.location.href='BuildingList.aspx?loc=" + Request.QueryString["loc"] + "';", true);
            else
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('Data for the selected building is currently being added, please wait until the data are saved before editing.');", true);
        }
        else
        {
            bool bValid = true;
            if (PK_PM_Site_Information == 0)
            {
                if (PM_Site_Information.SelectByBuildLoc(FK_LU_Location_ID, FK_Building_ID).Tables[0].Rows.Count > 0) bValid = false;
            }
            if (bValid)
            {
                SaveData();
                clsPM_Building_Edit.DeleteAccess(FK_Building_ID);
                Response.Redirect("Pollution.aspx?loc=" + Request.QueryString["loc"] + "&op=view" + "&id=" + Encryption.Encrypt(PK_PM_Site_Information.ToString()) + "&pnl=" + Encryption.Encrypt(hdPanel.Value));
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('Data for the selected building has already been added, please return to the building grid and select to edit the data, if desired.');", true);
            }
        }
    }

    /// <summary>
    /// Handles event button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Pollution.aspx?loc=" + Request.QueryString["loc"] + "&op=edit" + "&id=" + Encryption.Encrypt(PK_PM_Site_Information.ToString()) + "&pnl=" + Encryption.Encrypt(hdPanel.Value));
    }

    /// <summary>
    /// Handles event when Add link is clicked for grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddGridRecord_Click(object sender, EventArgs e)
    {
        SaveData();

        // get linkbutton ID
        string strLinkID = ((LinkButton)sender).ID;

        // set page URL
        string strURL = "";
        if (strLinkID == "lnkAddUtility") strURL = "Site_Information_Utility_Provider.aspx?";
        else if (strLinkID == "lnkAddFacility") strURL = "Site_Information_FacilityId.aspx?";
        else if (strLinkID == "lnkAddPermits") strURL = "PM_Permits.aspx?";
        //else if (strLinkID == "lnkChemicalInventory") strURL = "ChemicalInventory.aspx?";
        //else if (strLinkID == "lnkPaintInventory") strURL = "Compliance_Reporting_Paint_Inventory.aspx?";
        else if (strLinkID == "lnkTierII") strURL = "PM_CR_Grids.aspx?&gtype=" + Encryption.Encrypt("Tier II") + "&";
        else if (strLinkID == "lnkAir_Permit") strURL = "PM_CR_Grids.aspx?&gtype=" + Encryption.Encrypt("Air Permit") + "&";
        else if (strLinkID == "lnkSixH") strURL = "PM_CR_Grids.aspx?&gtype=" + Encryption.Encrypt("6H") + "&";
        else if (strLinkID == "lnkAddEquipment") strURL = "Equipment.aspx?";
        else if (strLinkID == "lnkWasteHauler") strURL = "PM_Waste_Hauler.aspx?";
        else if (strLinkID == "lnkAddTSDF") strURL = "PM_Receiving_TSDF.aspx?";
        else if (strLinkID == "lnkWasteRemoval") strURL = "Waste_Disposal_Waste_Removal.aspx?";
        else if (strLinkID == "lnkFrequency") strURL = "Audit_Inspections_Frequency.aspx?";
        else if (strLinkID == "lnkPhaseI") strURL = "PM_Phase_I.aspx?";
        else if (strLinkID == "lnkEPAInspection") strURL = "PM_EPA_Inspection.aspx?";
        else if (strLinkID == "lnkRemediations") strURL = "PM_Remediation_Grid.aspx?";
        else if (strLinkID == "lnkViolations") strURL = "PM_Violation.aspx?";
        else if (strLinkID == "lnkHearingConversation") strURL = "PM_Hearing_Conservation.aspx?";
        else if (strLinkID == "lnkRespiratoryProtection") strURL = "PM_Respiratory_Protection.aspx?";

        // redirect to page with ID and operation
        strURL = strURL + "fid=" + Encryption.Encrypt(PK_PM_Site_Information.ToString()) + "&loc=" + Request.QueryString["loc"];
        if (strLinkID == "lnkTierII" || strLinkID == "lnkAir_Permit" || strLinkID == "lnkSixH")
            strURL = strURL + "&cid=" + Encryption.Encrypt(PK_PM_Compliance_Reporting.ToString());
        else if (strLinkID == "lnkRemediations")
            strURL = strURL + "&rid=" + Encryption.Encrypt(PK_PM_Remediation.ToString());
        else if (strLinkID == "lnkRespiratoryProtection")
            strURL = strURL + "&rid=" + Encryption.Encrypt(PK_PM_Remediation.ToString());
        Response.Redirect(strURL);
    }

    /// <summary>
    /// Handles event when change building button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnChangeBuilding_Click(object sender, EventArgs e)
    {
        Response.Redirect("BuildingList.aspx?loc=" + Request.QueryString["loc"]);
    }

    protected void lnkComplainceReportingOSHA_Click(object sender, EventArgs e)
    {
        if (PK_PM_Compliance_Reporting > 0)
        {            
            string strURL = "PM_Compliance_Reporting_OSHA.aspx?";
            strURL = strURL + "fid=" + Encryption.Encrypt(PK_PM_Compliance_Reporting.ToString()) + "&loc=" + Request.QueryString["loc"];
            Response.Redirect(strURL);
        }
    }

    #endregion

    #region Attachments Management
    /// <summary>
    /// Binds the attachment details
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["display"] = "block";
        AttachDetails.Bind();
    }
    /// <summary>
    /// handles Add Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddAttachment_Click(string sender)
    {
        if (PK_PM_Site_Information > 0)
        {
            // add attachment if any.
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Site_Information);
            Attachment.FK_Field_Name = "FK_PM_Site_Information";
            Attachment.Table_Name = "PM_Attachments";
            Attachment.Building_ID = FK_Building_ID;
            Attachment.Add(clsGeneral.Pollution_Tables.PM_Attachments);
            // Bind the attachment detail to view the added attachment
            BindAttachmentDetails();
            // show attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(9);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save the Site Information first');ShowPanel(9);", true);
        }

    }
    #endregion

    #region " Gridview Events "
    /// <summary>
    /// Handles gridview command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // get gridview ID
        string strGridID = ((GridView)sender).ID;

        // if command is for edit or view details
        if (e.CommandName == "EditDetails" || e.CommandName == "ViewDetails")
        {
            // set page URL
            string strURL = "";
            if (strGridID.IndexOf("gvUtility") > -1) strURL = "Site_Information_Utility_Provider.aspx?";
            else if (strGridID.IndexOf("gvFacility") > -1) strURL = "Site_Information_FacilityId.aspx?";
            else if (strGridID.IndexOf("gvPermits") > -1) strURL = "PM_Permits.aspx?";
            //else if (strGridID.IndexOf("gvChemicalInventory") > -1) strURL = "ChemicalInventory.aspx?";
            //else if (strGridID.IndexOf("gvPaintInventory") > -1) strURL = "Compliance_Reporting_Paint_Inventory.aspx?";
            else if (strGridID.IndexOf("gvTierII") > -1) strURL = "PM_CR_Grids.aspx?&gtype=" + Encryption.Encrypt("Tier II") + "&";
            else if (strGridID.IndexOf("gvAir_Permit") > -1) strURL = "PM_CR_Grids.aspx?&gtype=" + Encryption.Encrypt("Air Permit") + "&";
            else if (strGridID.IndexOf("gvSixH") > -1) strURL = "PM_CR_Grids.aspx?&gtype=" + Encryption.Encrypt("6H") + "&";
            else if (strGridID.IndexOf("gvEquipment") > -1) strURL = "Equipment.aspx?";
            else if (strGridID.IndexOf("gvWasteHauler") > -1) strURL = "PM_Waste_Hauler.aspx?";
            else if (strGridID.IndexOf("gvTSDF") > -1) strURL = "PM_Receiving_TSDF.aspx?";
            else if (strGridID.IndexOf("gvWasteRemoval") > -1) strURL = "Waste_Disposal_Waste_Removal.aspx?";
            else if (strGridID.IndexOf("gvFrequency") > -1) strURL = "Audit_Inspections_Frequency.aspx?";
            else if (strGridID.IndexOf("gvPhaseI") > -1) strURL = "PM_Phase_I.aspx?";
            else if (strGridID.IndexOf("gvEPAInspections") > -1) strURL = "PM_EPA_Inspection.aspx?";
            else if (strGridID.IndexOf("gvRemediations") > -1) strURL = "PM_Remediation_Grid.aspx?";
            else if (strGridID.IndexOf("gvViolations") > -1) strURL = "PM_Violation.aspx?";

            // redirect to page with ID and operation
            strURL = strURL + "id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&op=" + (e.CommandName == "EditDetails" ? "edit" : "view") + "&fid=" + Encryption.Encrypt(PK_PM_Site_Information.ToString()) + "&loc=" + Request.QueryString["loc"];
            if (strGridID.IndexOf("gvTierII") > -1 || strGridID.IndexOf("gvAir_Permit") > -1 || strGridID.IndexOf("gvSixH") > -1)
                strURL = strURL + "&cid=" + Encryption.Encrypt(PK_PM_Compliance_Reporting.ToString());
            else if (strGridID.IndexOf("gvRemediations") > -1)
                strURL = strURL + "&rid=" + Encryption.Encrypt(PK_PM_Remediation.ToString());
            Response.Redirect(strURL);
        }
        else if (e.CommandName == "RemoveDetails")
        {
            #region " Remove Data "
            // set panel number, delete the record depending on the grid id and re-bind the grid
            int intPanel = 1;
            if (strGridID == "gvUtility")
            {
                PM_SI_Utility_Provider.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                BindGridUtilityProvider();
            }
            else if (strGridID == "gvFacility")
            {
                PM_SI_Facility_Id.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                BindGridFacilityID();
            }
            else if (strGridID == "gvPermits")
            {
                intPanel = 2;
                PM_Permits.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                BindGridPermits();
            }
            //else if (strGridID == "gvChemicalInventory")
            //{
            //    intPanel = 3;
            //    clsPM_CR_Chemical_Inventory.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            //    BindGridChemicalInv();
            //}
            //else if (strGridID == "gvPaintInventory")
            //{
            //    intPanel = 3;
            //    PM_CR_Paint_Inventory.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            //    BindGridPaintInv();
            //}
            else if (strGridID == "gvTierII")
            {
                intPanel = 3;
                PM_CR_Grids.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                BindGridTierII();
            }
            else if (strGridID == "gvAir_Permit")
            {
                intPanel = 3;
                PM_CR_Grids.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                BindGridAir_Permit();
            }
            else if (strGridID == "gvSixH")
            {
                intPanel = 3;
                PM_CR_Grids.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                BindGridSixH();
            }
            else if (strGridID == "gvEquipment")
            {
                intPanel = 4;
                clsPM_Equipment.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                BindGridEquipment();
            }
            else if (strGridID == "gvWasteHauler")
            {
                intPanel = 5;
                PM_Waste_Hauler.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                BindGridWasteHauler();
            }
            else if (strGridID == "gvTSDF")
            {
                intPanel = 5;
                PM_Receiving_TSDF.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                BindGridTSDF();
            }
            else if (strGridID == "gvWasteRemoval")
            {
                intPanel = 5;
                PM_Waste_Removal.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                BindGridWasteRemoval();
            }
            else if (strGridID == "gvFrequency")
            {
                intPanel = 6;
                PM_Frequency.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                BindGridFrequency();
            }
            //Remove PhaseI Grid #3187
            //else if (strGridID == "gvPhaseI")
            //{
            //    intPanel = 6;
            //    PM_Phase_I.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            //    BindGridPhaseI();
            //}
            else if (strGridID == "gvEPAInspections")
            {
                intPanel = 6;
                PM_EPA_Inspection.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                BindGridEPAInspection();
            }
            else if (strGridID == "gvRemediations")
            {
                intPanel = 7;
                PM_Remediation_Grid.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                BindGridRemediation();
            }
            else if (strGridID == "gvViolations")
            {
                intPanel = 8;
                PM_Violation.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
                BindGridViolation();
            }
            #endregion
            // show specified panel
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "Javascript:ShowPanel(" + intPanel + ");", true);
        }
    }

    protected void gvComplainceReportingOSHA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditDetails" || e.CommandName == "ViewDetails")
        {
            string strURL = "PM_Compliance_Reporting_OSHA.aspx?";
            strURL = strURL + "id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&op=" + (e.CommandName == "EditDetails" ? "edit" : "view") + "&fid=" + Encryption.Encrypt(PK_PM_Compliance_Reporting.ToString()) + "&loc=" + Request.QueryString["loc"];
            Response.Redirect(strURL);
        }
        else if (e.CommandName == "RemoveDetails")
        {
            clsPM_Complaince_Reporting_OSHA.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindGridOshaLog();
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "Javascript:ShowPanel(" + 3 + ");", true);
        }
    }

    public string CheckStatus(object myValue)
    {
        if (myValue.ToString() == "Y")
        {
            return "Yes";
        }
        else if (myValue.ToString() == "N")
        {
            return "No";
        }
        else
        {
            return string.Empty;
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

        #region " Site Information "

        DataTable dtFields = clsScreen_Validators.SelectByScreen(147).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Building":
                    //strCtrlsIDs += drpFK_Building.ClientID + ",";
                    //strMessages += "Please select [Site Information]/Building" + ",";
                    //Span1.Style["display"] = "inline-block";
                    break;
                case "County":
                    strCtrlsIDs += drpFK_County.ClientID + ",";
                    strMessages += "Please select [Site Information]/County" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "SIC Code":
                    strCtrlsIDs += txtSIC.ClientID + ",";
                    strMessages += "Please enter [Site Information]/SIC Code" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "NAICS Code":
                    strCtrlsIDs += txtNAICS.ClientID + ",";
                    strMessages += "Please enter [Site Information]/NAICS Code" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Number of Associates":
                    strCtrlsIDs += txtNumber_Of_Employees.ClientID + ",";
                    strMessages += "Please enter [Site Information]/Number of Associates" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Number of Shifts":
                    strCtrlsIDs += txtNumber_Of_Shift.ClientID + ",";
                    strMessages += "Please enter [Site Information]/Number of Shifts" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Days Per Week":
                    strCtrlsIDs += txtDays_Per_Week.ClientID + ",";
                    strMessages += "Please enter [Site Information]/Days Per Week" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Weeks Per Year":
                    strCtrlsIDs += txtWeeks_Per_Year.ClientID + ",";
                    strMessages += "Please enter [Site Information]/Weeks Per Year" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Facility Construction Completion Year":
                    strCtrlsIDs += txtFacility_Construction_Completion_Year.ClientID + ",";
                    strMessages += "Please enter [Site Information]/Facility Construction Completion Year" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Owner of Facility":
                    strCtrlsIDs += txtOwner_Of_Facility.ClientID + ",";
                    strMessages += "Please enter [Site Information]/Owner of Facility" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Latitude":
                    strCtrlsIDs += txtLatitude.ClientID + ",";
                    strMessages += "Please enter [Site Information]/Latitude" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Longitude":
                    strCtrlsIDs += txtLongitude.ClientID + ",";
                    strMessages += "Please enter [Site Information]/Longitude" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region " Compliance Reporting "

        dtFields = clsScreen_Validators.SelectByScreen(148).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk2.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                //case "Federal Facility Identification Number":
                //    strCtrlsIDs += txtFederal_Facility_Identification_Number.ClientID + ",";
                //    strMessages += "Please enter [Compliance Reporting]/Federal Facility Identification Number" + ",";
                //    Span13.Style["display"] = "inline-block";
                //    break;
                //case "State Facility Identification Number":
                //    strCtrlsIDs += txtState_Facility_Identification_Number.ClientID + ",";
                //    strMessages += "Please enter [Compliance Reporting]/State Facility Identification Number" + ",";
                //    Span14.Style["display"] = "inline-block";
                //    break;
                case "Contact Name":
                    strCtrlsIDs += txtContact_Name.ClientID + ",";
                    strMessages += "Please enter [Compliance Reporting]/Contact Name" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                case "Contact Telephone":
                    strCtrlsIDs += txtContact_Telephone.ClientID + ",";
                    strMessages += "Please enter [Compliance Reporting]/Contact Telephone" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                case "Emergency Contact Name":
                    strCtrlsIDs += txtEmergency_Contact_Name.ClientID + ",";
                    strMessages += "Please enter [Compliance Reporting]/Emergency Contact Name" + ",";
                    Span17.Style["display"] = "inline-block";
                    break;
                case "Emergency Contact Telephone":
                    strCtrlsIDs += txtEmergency_Telephone.ClientID + ",";
                    strMessages += "Please enter [Compliance Reporting]/Emergency Contact Telephone" + ",";
                    Span18.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }

        #endregion

        #region " Waste Disposal "

        dtFields = clsScreen_Validators.SelectByScreen(150).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk3.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Notes":
                    strCtrlsIDs += txtWasteDisposalNotes.ClientID + ",";
                    strMessages += "Please enter [Waste Disposal]/Notes" + ",";
                    Span19.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }

        #endregion

        #region " Audit/Inspections "

        dtFields = clsScreen_Validators.SelectByScreen(151).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk4.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Notes":
                    strCtrlsIDs += txtInspectionNotes.ClientID + ",";
                    strMessages += "Please enter [Audit/Inspections]/Notes" + ",";
                    Span20.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }

        #endregion

        #region " Remediations "

        dtFields = clsScreen_Validators.SelectByScreen(152).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk6.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Notes":
                    strCtrlsIDs += txtRemediationNote.ClientID + ",";
                    strMessages += "Please enter [Remediations]/Notes" + ",";
                    Span21.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }

        #endregion

        #region " Violations "

        dtFields = clsScreen_Validators.SelectByScreen(153).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk5.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Notes":
                    strCtrlsIDs += txtViolationsNotes.ClientID + ",";
                    strMessages += "Please enter [Violations]/Notes" + ",";
                    Span22.Style["display"] = "inline-block";
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


    protected void lnkAddHearingConversation_Click(object sender, EventArgs e)
    {

    }
    protected void gvHearingConversation_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void lnkAddRespiratoryProtection_Click(object sender, EventArgs e)
    {

    }
    protected void gvRespiratoryProtection_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
   
}