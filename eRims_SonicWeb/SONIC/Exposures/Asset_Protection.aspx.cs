using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Exposures_AssetProtection : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_AP_Property_Security
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_AP_Property_Security"]);
        }
        set { ViewState["PK_AP_Property_Security"] = value; }
    }

    /// <summary>
    /// Denotes the Primary KeychkSITSOther
    /// </summary>
    public decimal PK_AP_Property_Security_Monitor_Grids
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_AP_Property_Security_Monitor_Grids"]);
        }
        set { ViewState["PK_AP_Property_Security_Monitor_Grids"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal LocationID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["LocationID"]);
        }
        set { ViewState["LocationID"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key of DPD_FR
    /// </summary>
    public decimal FK_DPD_FR_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_DPD_FR_ID"]);
        }
        set { ViewState["FK_DPD_FR_ID"] = value; }
    }

    /// <summary>
    /// Denote Primary key of AP_DPD_FROIs
    /// </summary>
    public decimal PK_AP_DPD_FROIs
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_AP_DPD_FROIs"]);
        }
        set { ViewState["PK_AP_DPD_FROIs"] = value; }
    }

    /// <summary>
    /// Denote Primary key of DPD_Claims_ID
    /// </summary>
    public decimal PK_DPD_Claims_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_DPD_Claims_ID"]);
        }
        set { ViewState["PK_DPD_Claims_ID"] = value; }
    }

    /// <summary>
    ///   Denote Primary key of DPD_FR_Vehicle_ID
    /// </summary>
    public decimal FK_DPD_FR_Vehicle_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_DPD_FR_Vehicle_ID"]);
        }
        set { ViewState["FK_DPD_FR_Vehicle_ID"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal FK_AL_FR_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_AL_FR_ID"]);
        }
        set { ViewState["FK_AL_FR_ID"] = value; }
    }

    /// <summary>
    /// Get Set PK_AP_AL_FROIs
    /// </summary>
    public decimal PK_AP_AL_FROIs
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_AP_AL_FROIs"]);
        }
        set { ViewState["PK_AP_AL_FROIs"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_AP_Cal_Atlantic
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_AP_Cal_Atlantic"]);
        }
        set { ViewState["PK_AP_Cal_Atlantic"] = value; }
    }

    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal FK_Event
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_Event"]);
        }
        set { ViewState["FK_Event"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_AP_Fraud_Events
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_AP_Fraud_Events"]);
        }
        set { ViewState["PK_AP_Fraud_Events"] = value; }
    }

    /// <summary>
    /// Denotes the Notes Primary Key
    /// </summary>
    public decimal PK_AP_FE_Notes
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_AP_FE_Notes"]);
        }
        set { ViewState["PK_AP_FE_Notes"] = value; }
    }

    /// <summary>
    /// Denotes the Notes Primary Key
    /// </summary>
    public decimal PK_AP_FE_PA_Notes
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_AP_FE_PA_Notes"]);
        }
        set { ViewState["PK_AP_FE_PA_Notes"] = value; }
    }

    /// <summary>
    /// Denotes the Transaction Primary Key
    /// </summary>
    public decimal PK_AP_FE_Transactions
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_AP_FE_Transactions"]);
        }
        set { ViewState["PK_AP_FE_Transactions"] = value; }
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
    /// Denotes Property Security Monitor Grid Type
    /// </summary>
    public string StrMonitorGridType
    {
        get { return Convert.ToString(ViewState["StrMonitorGridType"]); }
        set { ViewState["StrMonitorGridType"] = value; }
    }

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortBy_DPDFROIs
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy_DPDFROIs"]) ? ViewState["SortBy_DPDFROIs"].ToString() : string.Empty); }
        set { ViewState["SortBy_DPDFROIs"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string SortOrder_DPDFROIs
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder_DPDFROIs"]) ? ViewState["SortOrder_DPDFROIs"].ToString() : string.Empty); }
        set { ViewState["SortOrder_DPDFROIs"] = value; }
    }

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortBy_AL
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy_AL"]) ? ViewState["SortBy_AL"].ToString() : string.Empty); }
        set { ViewState["SortBy_AL"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string SortOrder_AL
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder_AL"]) ? ViewState["SortOrder_AL"].ToString() : string.Empty); }
        set { ViewState["SortOrder_AL"] = value; }
    }

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string _SortBy_CalAtlantic
    {
        get { return (!clsGeneral.IsNull(ViewState["_SortBy_CalAtlantic"]) ? ViewState["_SortBy_CalAtlantic"].ToString() : string.Empty); }
        set { ViewState["_SortBy_CalAtlantic"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string _SortOrder_CalAtlantic
    {
        get { return (!clsGeneral.IsNull(ViewState["_SortOrder_CalAtlantic"]) ? ViewState["_SortOrder_CalAtlantic"].ToString() : string.Empty); }
        set { ViewState["_SortOrder_CalAtlantic"] = value; }
    }

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string _SortBy_Fraud
    {
        get { return (!clsGeneral.IsNull(ViewState["_SortBy_Fraud"]) ? ViewState["_SortBy_Fraud"].ToString() : string.Empty); }
        set { ViewState["_SortBy_Fraud"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string _SortOrder_Fraud
    {
        get { return (!clsGeneral.IsNull(ViewState["_SortOrder_Fraud"]) ? ViewState["_SortOrder_Fraud"].ToString() : string.Empty); }
        set { ViewState["_SortOrder_Fraud"] = value; }
    }

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string _SortBy_FraudNotes
    {
        get { return (!clsGeneral.IsNull(ViewState["_SortBy_FraudNotes"]) ? ViewState["_SortBy_FraudNotes"].ToString() : string.Empty); }
        set { ViewState["_SortBy_FraudNotes"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string _SortOrder_FraudNotes
    {
        get { return (!clsGeneral.IsNull(ViewState["_SortOrder_FraudNotes"]) ? ViewState["_SortOrder_FraudNotes"].ToString() : string.Empty); }
        set { ViewState["_SortOrder_FraudNotes"] = value; }
    }

    private string Origin_Claim_Number
    {
        get { return (!clsGeneral.IsNull(ViewState["Origin_Claim_Number"]) ? ViewState["Origin_Claim_Number"].ToString() : string.Empty); }
        set { ViewState["Origin_Claim_Number"] = value; }
    }


    private int pK_AP_Property_Security_Financials;

    public int PK_AP_Property_Security_Financials
    {
        get { return pK_AP_Property_Security_Financials; }
        set { pK_AP_Property_Security_Financials = value; }
    }

    public decimal PK_Auto_Loss_Claims_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Auto_Loss_Claims_ID"]);
        }
        set { ViewState["PK_Auto_Loss_Claims_ID"] = value; }
    }

    public decimal AL_RowIndex
    {
        get { return Session["AL_RowIndex"] == null ? 0 : clsGeneral.GetInt(Session["AL_RowIndex"]); }
        set { Session["AL_RowIndex"] = value; }
    }

    public string AP_AL_FROIs_CommandArgs
    {
        get { return (!clsGeneral.IsNull(Session["AP_AL_FROIs_CommandArgs"]) ? Session["AP_AL_FROIs_CommandArgs"].ToString() : string.Empty); }
        set { Session["AP_AL_FROIs_CommandArgs"] = value; }
    }

    public decimal DPD_RowIndex
    {
        get { return Session["DPD_RowIndex"] == null ? 0 : clsGeneral.GetInt(Session["DPD_RowIndex"]); }
        set { Session["DPD_RowIndex"] = value; }
    }

    public string AP_DPD_FROIs_CommandArgs
    {
        get { return (!clsGeneral.IsNull(Session["AP_DPD_FROIs_CommandArgs"]) ? Session["AP_DPD_FROIs_CommandArgs"].ToString() : string.Empty); }
        set { Session["AP_DPD_FROIs_CommandArgs"] = value; }
    }

    public string Building_Number
    {
        get
        {
            return clsGeneral.GetStringValue(ViewState["Building_Number"]);
        }
        set { ViewState["Building_Number"] = value; }
    }

    #endregion

    #region Page Events

    /// <summary>
    /// Event called when page load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.AssetProtection);
        if (!Page.IsPostBack)
        {
            if (App_Access == AccessType.NotAssigned && App_Assest_Protection != AccessType.View_Only)
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

            LocationID = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);
            hdnLocationID.Value = Convert.ToString(LocationID);
            StrOperation = Convert.ToString(Request.QueryString["op"]);
            Session["ExposureLocation"] = LocationID;
            hdnPanel.Value = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();
            CheckValidRequest();

            //PK_AP_Cal_Atlantic = clsAP_Cal_Atlantic.SelectPKByFKLoc(LocationID);

            BindHeaderInfo();
            SortBy_DPDFROIs = "DPD_FR_Number";
            SortOrder_DPDFROIs = "Asc";
            SortBy_AL = "AL_FR_Number";
            SortOrder_AL = "Asc";
            _SortBy_CalAtlantic = "PK_EVENT";
            _SortOrder_CalAtlantic = "asc";
            _SortBy_Fraud = "Fraud_Number";
            _SortOrder_Fraud = "asc";
            _SortBy_FraudNotes = "Note_Date";
            _SortOrder_FraudNotes = "Desc";


            PK_AP_Property_Security = clsAP_Property_Security.SelectPKPropertySecurityByFKLocation(LocationID);
            if (PK_AP_Property_Security > 0 && StrOperation != "edit")
            {
                StrOperation = "view";
            }
            else
            {
                btnBack.Visible = false;
                btnReturnto_View_Mode.Visible = true;
            }

            if (PK_AP_Property_Security == 0)
            {
                //here bind building dropdown and gridview visibility is wrong because this selected fk_building add in AP_Property_Security table but this is zero
                //FillOccupancyByFKLocation(new DropDownList[] { drpFK_Building_Id }, true, LocationID);
                //so here add screen visible
                BindPropertySecurityBuilding();
                tblMainPropertySecurityGrid.Style.Add("display", "");
                tblMainPropertySecurity.Style.Add("display", "none");
                dvProperty_SecuritySave.Style.Add("display", "none");
                btnCancel.Style.Add("display", "");
                btnCopyBuilding.Style.Add("display", "none");

                StrOperation = "edit";
                //btnGenerate_Abstract.Visible = false;
                btnGenerate_Abstract.Style.Add("display", "none");
                btnReturnto_View_Mode.Visible = false;
                //btnGenerate_Abstract.Visible = false;
                txtCCTV_Company_Name.Text = "ACI Protection";
                txtCCTV_Company_Address_1.Text = "970 Pittsburgh Drive";
                txtCCTV_Company_Address_2.Text = string.Empty;
                txtCCTV_Company_City.Text = "Delaware";
                drpFK_CCTV_Company_State.SelectedValue = "36";
                txtCCTV_Company_Zip.Text = "43015";
                txtCCTV_Company_Contact_Name.Text = "Richard Paglieri";
                txtCCTV_Comapny_Contact_Telephone.Text = "740-368-4177";
                txtCCTV_Company_Contact_EMail.Text = "rich@aciprotection.com";
            }
            //else
            //    drpFK_Building_Id.Visible = false;


            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
            if (LocationID != null)
            {
                BindDropDownList();
                if (StrOperation != string.Empty)
                {
                    if (PK_AP_Property_Security > 0)
                    {
                        //btnGenerate_Abstract.Visible = true;
                        btnGenerate_Abstract.Style["display"] = "";

                        Attachments.Location_ID = Convert.ToInt32(LocationID);
                        Attachments.StrOperation = StrOperation;

                        if (StrOperation == "view")
                        {
                            // Bind Controls
                            BindDetailsForViewForProperty_Security();
                            BindDetailsForViewForDPD_FROIs();
                            BindDetailsForView_AL();
                            //BindDetailsForViewForCal_Atlantic();
                            BindDetailsForView_FraudEvents();
                            //AttachDetails.InitializeAttachmentDetails(Convert.ToInt32(LocationID), "FK_LU_Location", "PK_AP_Attachments", false, 6);
                        }
                        else
                        {
                            // Bind Controls
                            btnBack.Visible = false;
                            BindDropDownList();

                            BindDetailsForEditForProperty_Security();
                            BindDetailsForEditForDPD_FROIs();
                            BindDetailsForEdit_AL();
                            //BindDetailsForEditForCal_Atlantic();
                            BindDetailsForEdit_FraudEvents();
                            SetCopyButtonVisibility();
                            //AttachDetails.InitializeAttachmentDetails(Convert.ToInt32(LocationID), "FK_LU_Location", "PK_AP_Attachments", true, 6);                          
                        }
                        //Added for #3437
                        BindPropertySecurityBuilding();
                    }
                }
                else
                {
                    // don't show div for view mode
                    dvView.Style["display"] = "none";
                    BindDropDownList();
                }
                BindPropertySecurityMonitoringGrid();
                BindAP_DPD_FROIs_Grid(CtrlPagingDPD_FROIs.CurrentPage, CtrlPagingDPD_FROIs.PageSize);
                gvDPD_Witnesses.DataBind();
                gvDPD_WitnessesView.DataBind();
                txtLoss_Description.Enabled = false;
                BindAP_AL_FROIs_Grid(CtrlPagingAL_FROIs.CurrentPage, CtrlPagingAL_FROIs.PageSize);
                //AttachDetails.Bind();
                //AttachDetails.FindControl("gvAttachment").DataBind();
                BindCalAtlanticEventGrid();
                BindFraudEventGrid();
                SetValidation();


                if (!string.IsNullOrEmpty(Request.QueryString["DEST"])) { BindOpenDPDFROIs(Convert.ToString(Request.QueryString["DEST"])); }
            }
        }
        else
        {
            // page is get forcibly Postback by "CheckValueChange()" js function when user do changes in data and Wants to redirect on another panel
            // and According to the Current panel's value which is stored in "hdnPanel.Value" Save Button's click event is called and page get redirect 
            // to Selected panel by "eventArgument" value.
            //_SortOrder_FraudNotes = "Desc";
            string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];
            if (eventTarget == "SaveBeforePanelChange")
            {
                if (hdnPanel.Value == "1")
                {
                    btnSave_Click(null, null);
                }
                else if (hdnPanel.Value == "2")
                {
                    btnDPD_FROIsSave_Click(null, null);
                }
                else if (hdnPanel.Value == "3")
                {
                    btnAL_Save_Click(null, null);
                }
                else if (hdnPanel.Value == "4")
                {
                    btnCalAtlanicSave_Click(null, null);
                }
                else if (hdnPanel.Value == "5")
                {
                    btnFraudEventSave_Click(null, null);
                }
                ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + this.Request["__EVENTARGUMENT"] + ");", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
            }
        }
    }
    #endregion

    #region Methods

    #region " Property Security "

    private void BindPropertySecurityBuilding()
    {
        DataSet dsBuildingData = clsAP_Property_Security.BindPropertySecurityBuilding(LocationID);

        if (StrOperation != "view")
        {
            if (dsBuildingData != null && dsBuildingData.Tables.Count > 0)
            {
                gvBuildingPropertySecurity.DataSource = dsBuildingData.Tables[0];
                gvBuildingPropertySecurity.DataBind();
            }
            dvProperty_SecuritySave.Style["display"] = "none";
            //dvProperty_SecuritySave.Attributes.Add("style", "display:none");
            dvAL_Save.Style["display"] = "none";
            dvDPD_Save.Style["display"] = "none";
        }
        else
        {
            if (dsBuildingData != null && dsBuildingData.Tables.Count > 0)
            {
                gvBuildingPropertySecurityView.DataSource = dsBuildingData.Tables[0];
                gvBuildingPropertySecurityView.DataBind();
            }

        }
    }

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEditForProperty_Security()
    {
        clsAP_Property_Security objAP_Property_Security = new clsAP_Property_Security(PK_AP_Property_Security);
        txtCCTV_Company_Name.Text = objAP_Property_Security.CCTV_Company_Name;
        txtCCTV_Company_Address_1.Text = objAP_Property_Security.CCTV_Company_Address_1;
        txtCCTV_Company_Address_2.Text = objAP_Property_Security.CCTV_Company_Address_2;
        txtCCTV_Company_City.Text = objAP_Property_Security.CCTV_Company_City;
        if (objAP_Property_Security.FK_CCTV_Company_State != null) drpFK_CCTV_Company_State.SelectedValue = objAP_Property_Security.FK_CCTV_Company_State.ToString();
        txtCCTV_Company_Zip.Text = objAP_Property_Security.CCTV_Company_Zip;
        txtCCTV_Company_Contact_Name.Text = objAP_Property_Security.CCTV_Company_Contact_Name;
        txtCCTV_Comapny_Contact_Telephone.Text = objAP_Property_Security.CCTV_Comapny_Contact_Telephone;
        txtCCTV_Company_Contact_EMail.Text = objAP_Property_Security.CCTV_Company_Contact_EMail;
        rdoCal_Atlantic_System.SelectedValue = objAP_Property_Security.Cal_Atlantic_System;
        rdoLive_Monitoring.SelectedValue = objAP_Property_Security.Live_Monitoring;
        rdoACI_Burglary_System.SelectedValue = objAP_Property_Security.ACI_Burglary_System;
        rdoLive_Burglary_Monitoring.SelectedValue = objAP_Property_Security.Live_Burglary_Monitoring;
        if (PK_AP_Property_Security == 0)
        {
            if (LocationID != null)
            {
                DataSet ds = clsACI_Link_LU_Location.ACI_Link_LU_LocationSelectByFK_LU_Location(LocationID);

                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Group_ID"] != null)
                    lblGroupID.Text = Convert.ToString(ds.Tables[0].Rows[0]["Group_ID"]);
            }
            lblCreated_Date.Text = clsGeneral.FormatDBNullDateToDisplay(DateTime.Now);
        }
        else
        {
            if (objAP_Property_Security.Group_ID != null)
                lblGroupID.Text = Convert.ToString(objAP_Property_Security.Group_ID);
            else
                lblGroupID.Text = string.Empty;
            lblCreated_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Property_Security.Created_Date);
        }
        //txtHours_Monitored_From.Text = objAP_Property_Security.Hours_Monitored_From;
        //txtHours_Monitored_To.Text = objAP_Property_Security.Hours_Monitored_To;
        txtExterior_Camera_Coverage_Other_Description.Text = objAP_Property_Security.Exterior_Camera_Coverage_Other_Description;
        txtInterior_Camera_Coverage_Other_Description.Text = objAP_Property_Security.Interior_Camera_Coverage_Other_Description;
        rdoBuglar_Alarm_System.SelectedValue = objAP_Property_Security.Buglar_Alarm_System;
        rdoIs_System_Active_and_Function_Properly.SelectedValue = objAP_Property_Security.Is_System_Active_and_Function_Properly;
        txtBurglar_Alarm_Company_Name.Text = objAP_Property_Security.Burglar_Alarm_Company_Name;
        txtBurglar_Alarm_Company_Address_1.Text = objAP_Property_Security.Burglar_Alarm_Company_Address_1;
        txtBurglar_Alarm_Company_Address_2.Text = objAP_Property_Security.Burglar_Alarm_Company_Address_2;
        txtBurglar_Alarm_Company_City.Text = objAP_Property_Security.Burglar_Alarm_Company_City;
        if (objAP_Property_Security.FK_Burglar_Alarm_Company_State != null) drpFK_Burglar_Alarm_Company_State.SelectedValue = objAP_Property_Security.FK_Burglar_Alarm_Company_State.ToString();
        txtBurglar_Alarm_Company_Zip.Text = objAP_Property_Security.Burglar_Alarm_Company_Zip;
        txtBurglar_Alarm_Company_Contact_Name.Text = objAP_Property_Security.Burglar_Alarm_Company_Contact_Name;
        txtBurglar_Alarm_Comapny_Contact_Telephone.Text = objAP_Property_Security.Burglar_Alarm_Comapny_Contact_Telephone;
        txtBurglar_Alarm_Company_Contact_EMail.Text = objAP_Property_Security.Burglar_Alarm_Company_Contact_EMail;
        txtBurglar_Alarm_Coverage_Other_Description.Text = objAP_Property_Security.Burglar_Alarm_Coverage_Other_Description;
        txtBurglar_Alarm_Coverage_Comments.Text = objAP_Property_Security.Burglar_Alarm_Coverage_Comments;
        txtGuard_Company_Name.Text = objAP_Property_Security.Guard_Company_Name;
        txtGuard_Company_Address_1.Text = objAP_Property_Security.Guard_Company_Address_1;
        txtGuard_Company_Address_2.Text = objAP_Property_Security.Guard_Company_Address_2;
        txtGuard_Company_City.Text = objAP_Property_Security.Guard_Company_City;
        if (objAP_Property_Security.FK_Guard_Company_State != null) drpFK_Guard_Company_State.SelectedValue = objAP_Property_Security.FK_Guard_Company_State.ToString();
        txtGuard_Company_Zip.Text = objAP_Property_Security.Guard_Company_Zip;
        txtGuard_Company_Contact_Name.Text = objAP_Property_Security.Guard_Company_Contact_Name;
        txtGuard_Comapny_Contact_Telephone.Text = objAP_Property_Security.Guard_Comapny_Contact_Telephone;
        txtGuard_Company_Contact_EMail.Text = objAP_Property_Security.Guard_Company_Contact_EMail;
        //txtGuard_Hours_Monitored_From.Text = objAP_Property_Security.Guard_Hours_Monitored_From;
        //txtGuard_Hours_Monitored_To.Text = objAP_Property_Security.Guard_Hours_Monitored_To;
        txtOffDuty_Officer_Name.Text = objAP_Property_Security.OffDuty_Officer_Name;
        txtOffDuty_Officer_Telephone.Text = objAP_Property_Security.OffDuty_Officer_Telephone;
        //txtOffDuty_Officer_Hours_Monitored_From.Text = objAP_Property_Security.OffDuty_Officer_Hours_Monitored_From;
        //txtOffDuty_Officer_Hours_Monitored_To.Text = objAP_Property_Security.OffDuty_Officer_Hours_Monitored_To;
        txtAccess_Control_Other_Description.Text = objAP_Property_Security.Access_Control_Other_Description;
        txtSecurity_Inventory_Tracking_System_Other_Description.Text = objAP_Property_Security.Security_Inventory_Tracking_System_Other_Description;
        txtSecurity_Inventory_Tracking_System_Other_Description.Text = objAP_Property_Security.Security_Inventory_Tracking_System_Other_Description;

        txtNumberOfExternalCameras.Text = clsGeneral.FormatCommaSeperatorNumber(objAP_Property_Security.ECC_Number_Of_External_Cameras);
        txtNumberofInternalCameras.Text = clsGeneral.FormatCommaSeperatorNumber(objAP_Property_Security.ECC_Number_Of_Internal_Cameras);


        chkACFirstFloorOnly.Checked = objAP_Property_Security.AC_1st_Floor_Only == "Y" ? true : false;
        chkACBusinessArea.Checked = objAP_Property_Security.AC_Business_Area == "Y" ? true : false;
        chkACCashier.Checked = objAP_Property_Security.AC_Cashier == "Y" ? true : false;
        chkACControlRoom.Checked = objAP_Property_Security.AC_Computer_Room == "Y" ? true : false;
        chkACControllerOffice.Checked = objAP_Property_Security.AC_Controller_Office == "Y" ? true : false;
        chkACEnterExitBuilding.Checked = objAP_Property_Security.AC_EnterExit_Building == "Y" ? true : false;
        chkACFandIOffice.Checked = objAP_Property_Security.AC_F_and_I_Office == "Y" ? true : false;
        chkACGMOffice.Checked = objAP_Property_Security.AC_GM_Office == "Y" ? true : false;
        chkACMulipleFloors.Checked = objAP_Property_Security.AC_Multiple_Floors == "Y" ? true : false;
        chkACOther.Checked = objAP_Property_Security.AC_Other == "Y" ? true : false;
        chkACParts.Checked = objAP_Property_Security.AC_Parts == "Y" ? true : false;
        chkACSmartSafeOffice.Checked = objAP_Property_Security.AC_Smart_Sales_Office == "Y" ? true : false;
        chkEccBack.Checked = objAP_Property_Security.ECC_Back == "Y" ? true : false;
        chkEccCarwash.Checked = objAP_Property_Security.ECC_Car_Wash == "Y" ? true : false;
        chkEccFront.Checked = objAP_Property_Security.ECC_Front == "Y" ? true : false;
        chkEccOther.Checked = objAP_Property_Security.ECC_Other == "Y" ? true : false;
        chkEccsatelliteParking.Checked = objAP_Property_Security.ECC_Satellite_Parking == "Y" ? true : false;
        chkEccSide.Checked = objAP_Property_Security.ECC_Side == "Y" ? true : false;
        chkEccZerodotLine.Checked = objAP_Property_Security.ECC_Zero_Lot_Line == "Y" ? true : false;
        chkFBack.Checked = objAP_Property_Security.F_Back == "Y" ? true : false;
        chkFEntierPerimeter.Checked = objAP_Property_Security.F_Entire_Perimeter == "Y" ? true : false;
        chkFFront.Checked = objAP_Property_Security.F_Front == "Y" ? true : false;
        chkFSatelliteParkingLot.Checked = objAP_Property_Security.F_Satellite_Parking_Lot == "Y" ? true : false;
        chkFSide.Checked = objAP_Property_Security.F_Side == "Y" ? true : false;
        chkFGEnterenceExitAlarms.Checked = objAP_Property_Security.FG_EntranceExit_Alarms == "Y" ? true : false;
        chkFGEnterenceExitGate.Checked = objAP_Property_Security.FG_EntranceExit_Gate == "Y" ? true : false;
        //if(objAP_Property_Security.FK_LU_Location_Id != null) drpFK_LU_Location_Id.SelectedValue = objAP_Property_Security.FK_LU_Location_Id.ToString();
        chkIccBodyShop.Checked = objAP_Property_Security.ICC_Body_Shop == "Y" ? true : false;
        chkIccCashier.Checked = objAP_Property_Security.ICC_Cashier == "Y" ? true : false;
        chkIccComputerRoom.Checked = objAP_Property_Security.ICC_Computer_Room == "Y" ? true : false;
        chkIccDetailBays.Checked = objAP_Property_Security.ICC_Detail_Bays == "Y" ? true : false;
        chkIccKeyBoxArea.Checked = objAP_Property_Security.ICC_Key_Box_Area == "Y" ? true : false;
        chkIccOther.Checked = objAP_Property_Security.ICC_Other == "Y" ? true : false;
        chkIccPartsReceivingArea.Checked = objAP_Property_Security.ICC_Parts_Receiving_Area == "Y" ? true : false;
        chkIccServiceDepartment.Checked = objAP_Property_Security.ICC_Service_Department == "Y" ? true : false;
        chkIccServiceLane.Checked = objAP_Property_Security.ICC_Service_Lane == "Y" ? true : false;
        chkIccShowRoom.Checked = objAP_Property_Security.ICC_Showroom == "Y" ? true : false;
        chkIccSmartSafeOffice.Checked = objAP_Property_Security.ICC_Smart_Safe_Office == "Y" ? true : false;
        chkPBack.Checked = objAP_Property_Security.P_Back == "Y" ? true : false;
        chkPEntirePerimeter.Checked = objAP_Property_Security.P_Entire_Perimeter == "Y" ? true : false;
        chkPFront.Checked = objAP_Property_Security.P_Front == "Y" ? true : false;
        chkPSatelliteParkingLot.Checked = objAP_Property_Security.P_Satellite_Parking_Lot == "Y" ? true : false;
        chkPSide.Checked = objAP_Property_Security.P_Side == "Y" ? true : false;
        chkSITSAutoTracks.Checked = objAP_Property_Security.SITS_Auto_Tracks == "Y" ? true : false;
        chkSITSKeyTracks.Checked = objAP_Property_Security.SITS_Key_Tracks == "Y" ? true : false;
        chkSITSOther.Checked = objAP_Property_Security.SITS_Other == "Y" ? true : false;
        chkZDCollisionCenter.Checked = objAP_Property_Security.ZD_Collision_Center == "Y" ? true : false;
        chkZDOffice.Checked = objAP_Property_Security.ZD_Office == "Y" ? true : false;
        chkZDOther.Checked = objAP_Property_Security.ZD_Other == "Y" ? true : false;
        chkZDParts.Checked = objAP_Property_Security.ZD_Parts == "Y" ? true : false;
        chkZDService.Checked = objAP_Property_Security.ZD_Sales == "Y" ? true : false;
        chkZDSalesShowroom.Checked = objAP_Property_Security.ZD_Sales_Showroom == "Y" ? true : false;

        chkKeyFobs.Checked = objAP_Property_Security.AC_Key_Fobs == "Y" ? true : false;
        chkDoorRestrictions.Checked = objAP_Property_Security.AC_Door_Restrictions == "Y" ? true : false;

        chkSITS_Supra_Key_Advantage.Checked = objAP_Property_Security.SITS_Supra_Key_Advantage == "Y" ? true : false;

        if (objAP_Property_Security.Cap_Index_Crime_Score != null)
            txtCap_Index_Crime_Score.Text = Convert.ToString(objAP_Property_Security.Cap_Index_Crime_Score);
        else
            txtCap_Index_Crime_Score.Text = string.Empty;
        if (objAP_Property_Security.Cap_Index_Risk_Cateogory != null) ddlCap_Index_Risk_Category.SelectedValue = objAP_Property_Security.Cap_Index_Risk_Cateogory.ToString();
        else
            ddlCap_Index_Risk_Category.SelectedIndex = -1;

        //Added due to Issue #3173

        if (gvCCTVHoursMonitoringGrid.Rows.Count > 0)
        {
            if (objAP_Property_Security.Total_Hours_CCTV_Monitored_Per_Week != null)
                txttotalHoursMonitoredPerWeek.Text = Convert.ToString(objAP_Property_Security.Total_Hours_CCTV_Monitored_Per_Week);
            else
                txttotalHoursMonitoredPerWeek.Text = string.Empty;
        }
        else
        {
            txttotalHoursMonitoredPerWeek.Text = string.Empty;
        }

        BindFinancialGridforEdit();

        if (PK_AP_Property_Security > 0)
        {
            btnProperty_SecurityAudit.Visible = true;
        }
    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForViewForProperty_Security()
    {
        dvProperty_SecuritySave.Visible = false;
        clsAP_Property_Security objAP_Property_Security = new clsAP_Property_Security(PK_AP_Property_Security);
        lblCCTV_Company_Name.Text = objAP_Property_Security.CCTV_Company_Name;
        lblCCTV_Company_Address_1.Text = objAP_Property_Security.CCTV_Company_Address_1;
        lblCCTV_Company_Address_2.Text = objAP_Property_Security.CCTV_Company_Address_2;
        lblCCTV_Company_City.Text = objAP_Property_Security.CCTV_Company_City;
        if (objAP_Property_Security.FK_CCTV_Company_State != null)
            lblFK_CCTV_Company_State.Text = new State((decimal)objAP_Property_Security.FK_CCTV_Company_State).FLD_state;
        else
            lblFK_CCTV_Company_State.Text = string.Empty;
        lblCCTV_Company_Zip.Text = objAP_Property_Security.CCTV_Company_Zip;
        lblCCTV_Company_Contact_Name.Text = objAP_Property_Security.CCTV_Company_Contact_Name;
        lblCCTV_Comapny_Contact_Telephone.Text = objAP_Property_Security.CCTV_Comapny_Contact_Telephone;
        lblCCTV_Company_Contact_EMail.Text = objAP_Property_Security.CCTV_Company_Contact_EMail;
        if (objAP_Property_Security.Cal_Atlantic_System != null)
            lblCal_Atlantic_System.Text = objAP_Property_Security.Cal_Atlantic_System == "Y" ? "Yes" : "No";
        else
            lblCal_Atlantic_System.Text = string.Empty;

        lblLive_Burglary_Monitoring.Text = objAP_Property_Security.Live_Burglary_Monitoring == null ? string.Empty : objAP_Property_Security.Live_Burglary_Monitoring == "Y" ? "Yes" : "No";
        lblACI_Burglary_System.Text = objAP_Property_Security.ACI_Burglary_System == null ? string.Empty : objAP_Property_Security.ACI_Burglary_System == "Y" ? "Yes" : "No";

        if (objAP_Property_Security.Live_Monitoring != null)
            lblLive_Monitoring.Text = objAP_Property_Security.Live_Monitoring == "Y" ? "Yes" : "No";
        else
            lblLive_Monitoring.Text = string.Empty;
        if (objAP_Property_Security.Group_ID != null)
            lblGroupIDview.Text = Convert.ToString(objAP_Property_Security.Group_ID);
        else
            lblGroupIDview.Text = string.Empty;
        lblCreated_DateView.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Property_Security.Created_Date);

        //lblHours_Monitored_From.Text = objAP_Property_Security.Hours_Monitored_From;
        //lblHours_Monitored_To.Text = objAP_Property_Security.Hours_Monitored_To;
        lblExterior_Camera_Coverage_Other_Description.Text = objAP_Property_Security.Exterior_Camera_Coverage_Other_Description;
        lblInterior_Camera_Coverage_Other_Description.Text = objAP_Property_Security.Interior_Camera_Coverage_Other_Description;
        if (objAP_Property_Security.Buglar_Alarm_System != null)
            lblBuglar_Alarm_System.Text = objAP_Property_Security.Buglar_Alarm_System == "Y" ? "Yes" : "No";
        else
            lblBuglar_Alarm_System.Text = string.Empty;
        if (objAP_Property_Security.Is_System_Active_and_Function_Properly != null)
            lblIs_System_Active_and_Function_Properly.Text = objAP_Property_Security.Is_System_Active_and_Function_Properly == "Y" ? "Yes" : "No";
        else
            lblIs_System_Active_and_Function_Properly.Text = string.Empty;
        lblBurglar_Alarm_Company_Name.Text = objAP_Property_Security.Burglar_Alarm_Company_Name;
        lblBurglar_Alarm_Company_Address_1.Text = objAP_Property_Security.Burglar_Alarm_Company_Address_1;
        lblBurglar_Alarm_Company_Address_2.Text = objAP_Property_Security.Burglar_Alarm_Company_Address_2;
        lblBurglar_Alarm_Company_City.Text = objAP_Property_Security.Burglar_Alarm_Company_City;
        if (objAP_Property_Security.FK_Burglar_Alarm_Company_State != null)
            lblFK_Burglar_Alarm_Company_State.Text = new State((decimal)objAP_Property_Security.FK_Burglar_Alarm_Company_State).FLD_state;
        else
            lblFK_Burglar_Alarm_Company_State.Text = string.Empty;
        lblBurglar_Alarm_Company_Zip.Text = objAP_Property_Security.Burglar_Alarm_Company_Zip;
        lblBurglar_Alarm_Company_Contact_Name.Text = objAP_Property_Security.Burglar_Alarm_Company_Contact_Name;
        lblBurglar_Alarm_Comapny_Contact_Telephone.Text = objAP_Property_Security.Burglar_Alarm_Comapny_Contact_Telephone;
        lblBurglar_Alarm_Company_Contact_EMail.Text = objAP_Property_Security.Burglar_Alarm_Company_Contact_EMail;
        lblBurglar_Alarm_Coverage_Other_Description.Text = objAP_Property_Security.Burglar_Alarm_Coverage_Other_Description;
        lblBurglar_Alarm_Coverage_Comments.Text = objAP_Property_Security.Burglar_Alarm_Coverage_Comments;
        lblGuard_Company_Name.Text = objAP_Property_Security.Guard_Company_Name;
        lblGuard_Company_Address_1.Text = objAP_Property_Security.Guard_Company_Address_1;
        lblGuard_Company_Address_2.Text = objAP_Property_Security.Guard_Company_Address_2;
        lblGuard_Company_City.Text = objAP_Property_Security.Guard_Company_City;
        if (objAP_Property_Security.FK_Guard_Company_State != null)
            lblFK_Guard_Company_State.Text = new State((decimal)objAP_Property_Security.FK_Guard_Company_State).FLD_state;
        else
            lblFK_Guard_Company_State.Text = string.Empty;
        lblGuard_Company_Zip.Text = objAP_Property_Security.Guard_Company_Zip;
        lblGuard_Company_Contact_Name.Text = objAP_Property_Security.Guard_Company_Contact_Name;
        lblGuard_Comapny_Contact_Telephone.Text = objAP_Property_Security.Guard_Comapny_Contact_Telephone;
        lblGuard_Company_Contact_E_Mail.Text = objAP_Property_Security.Guard_Company_Contact_EMail;
        //lblGuard_Hours_Monitored_From.Text = objAP_Property_Security.Guard_Hours_Monitored_From;
        //lblGuard_Hours_Monitored_To.Text = objAP_Property_Security.Guard_Hours_Monitored_To;
        lblOffDuty_Officer_Name.Text = objAP_Property_Security.OffDuty_Officer_Name;
        lblOffDuty_Officer_Telephone.Text = objAP_Property_Security.OffDuty_Officer_Telephone;
        //lblOffDuty_Officer_Hours_Monitored_From.Text = objAP_Property_Security.OffDuty_Officer_Hours_Monitored_From;
        //lblOffDuty_Officer_Hours_Monitored_To.Text = objAP_Property_Security.OffDuty_Officer_Hours_Monitored_To;
        lblAccess_Control_Other_Description.Text = objAP_Property_Security.Access_Control_Other_Description;
        lblSecurity_Inventory_Tracking_System_Other_Description.Text = objAP_Property_Security.Security_Inventory_Tracking_System_Other_Description;

        lblNumberofExternalCameras.Text = clsGeneral.FormatCommaSeperatorNumber(objAP_Property_Security.ECC_Number_Of_External_Cameras);
        lblNumberofInternalCameras.Text = clsGeneral.FormatCommaSeperatorNumber(objAP_Property_Security.ECC_Number_Of_Internal_Cameras);


        chkACFirstFloorOnlyView.Checked = objAP_Property_Security.AC_1st_Floor_Only == "Y" ? true : false;
        chkACBusinessAreaView.Checked = objAP_Property_Security.AC_Business_Area == "Y" ? true : false;
        chkACCashierView.Checked = objAP_Property_Security.AC_Cashier == "Y" ? true : false;
        chkACControlRoomView.Checked = objAP_Property_Security.AC_Computer_Room == "Y" ? true : false;
        chkACControllerOfficeView.Checked = objAP_Property_Security.AC_Controller_Office == "Y" ? true : false;
        chkACEnterExitBuildingView.Checked = objAP_Property_Security.AC_EnterExit_Building == "Y" ? true : false;
        chkACFandIOfficeView.Checked = objAP_Property_Security.AC_F_and_I_Office == "Y" ? true : false;
        chkACGMOfficeView.Checked = objAP_Property_Security.AC_GM_Office == "Y" ? true : false;
        chkACMulipleFloorsView.Checked = objAP_Property_Security.AC_Multiple_Floors == "Y" ? true : false;
        chkACOtherView.Checked = objAP_Property_Security.AC_Other == "Y" ? true : false;
        chkACPartsView.Checked = objAP_Property_Security.AC_Parts == "Y" ? true : false;
        chkACSmartSafeOfficeView.Checked = objAP_Property_Security.AC_Smart_Sales_Office == "Y" ? true : false;
        chkEccBackView.Checked = objAP_Property_Security.ECC_Back == "Y" ? true : false;
        chkEccCarwashView.Checked = objAP_Property_Security.ECC_Car_Wash == "Y" ? true : false;
        chkEccFrontView.Checked = objAP_Property_Security.ECC_Front == "Y" ? true : false;
        chkEccOtherView.Checked = objAP_Property_Security.ECC_Other == "Y" ? true : false;
        chkEccsatelliteParkingView.Checked = objAP_Property_Security.ECC_Satellite_Parking == "Y" ? true : false;
        chkEccSideView.Checked = objAP_Property_Security.ECC_Side == "Y" ? true : false;
        chkEccZerodotLineView.Checked = objAP_Property_Security.ECC_Zero_Lot_Line == "Y" ? true : false;
        chkFBackView.Checked = objAP_Property_Security.F_Back == "Y" ? true : false;
        chkFEntierPerimeterView.Checked = objAP_Property_Security.F_Entire_Perimeter == "Y" ? true : false;
        chkFFrontView.Checked = objAP_Property_Security.F_Front == "Y" ? true : false;
        chkFSatelliteParkingLotView.Checked = objAP_Property_Security.F_Satellite_Parking_Lot == "Y" ? true : false;
        chkFSideView.Checked = objAP_Property_Security.F_Side == "Y" ? true : false;
        chkFGEnterenceExitAlarmsView.Checked = objAP_Property_Security.FG_EntranceExit_Alarms == "Y" ? true : false;
        chkFGEnterenceExitGateView.Checked = objAP_Property_Security.FG_EntranceExit_Gate == "Y" ? true : false;
        //if (objAP_Property_Security.FK_LU_Location_Id != null)
        //  lblFK_LU_Location_Id.Text = new LU_Location_Id((decimal)objAP_Property_Security.FK_LU_Location_Id).Fld_Desc;
        chkIccBodyShopView.Checked = objAP_Property_Security.ICC_Body_Shop == "Y" ? true : false;
        chkIccCashierView.Checked = objAP_Property_Security.ICC_Cashier == "Y" ? true : false;
        chkIccComputerRoomView.Checked = objAP_Property_Security.ICC_Computer_Room == "Y" ? true : false;
        chkIccDetailBaysView.Checked = objAP_Property_Security.ICC_Detail_Bays == "Y" ? true : false;
        chkIccKeyBoxAreaView.Checked = objAP_Property_Security.ICC_Key_Box_Area == "Y" ? true : false;
        chkIccOtherView.Checked = objAP_Property_Security.ICC_Other == "Y" ? true : false;
        chkIccPartsReceivingAreaView.Checked = objAP_Property_Security.ICC_Parts_Receiving_Area == "Y" ? true : false;
        chkIccServiceDepartmentView.Checked = objAP_Property_Security.ICC_Service_Department == "Y" ? true : false;
        chkIccServiceLaneView.Checked = objAP_Property_Security.ICC_Service_Lane == "Y" ? true : false;
        chkIccShowRoomView.Checked = objAP_Property_Security.ICC_Showroom == "Y" ? true : false;
        chkIccSmartSafeOfficeView.Checked = objAP_Property_Security.ICC_Smart_Safe_Office == "Y" ? true : false;
        chkPBackView.Checked = objAP_Property_Security.P_Back == "Y" ? true : false;
        chkPEntirePerimeterView.Checked = objAP_Property_Security.P_Entire_Perimeter == "Y" ? true : false;
        chkPFrontView.Checked = objAP_Property_Security.P_Front == "Y" ? true : false;
        chkPSatelliteParkingLotView.Checked = objAP_Property_Security.P_Satellite_Parking_Lot == "Y" ? true : false;
        chkPSideView.Checked = objAP_Property_Security.P_Side == "Y" ? true : false;
        chkSITSAutoTracksView.Checked = objAP_Property_Security.SITS_Auto_Tracks == "Y" ? true : false;
        chkSITSKeyTracksView.Checked = objAP_Property_Security.SITS_Key_Tracks == "Y" ? true : false;
        chkSITSOtherView.Checked = objAP_Property_Security.SITS_Other == "Y" ? true : false;
        chkZDCollisionCenterView.Checked = objAP_Property_Security.ZD_Collision_Center == "Y" ? true : false;
        chkZDOfficeView.Checked = objAP_Property_Security.ZD_Office == "Y" ? true : false;
        chkZDOtherView.Checked = objAP_Property_Security.ZD_Other == "Y" ? true : false;
        chkZDPartsView.Checked = objAP_Property_Security.ZD_Parts == "Y" ? true : false;
        chkZDServiceView.Checked = objAP_Property_Security.ZD_Sales == "Y" ? true : false;
        chkZDSalesShowroomView.Checked = objAP_Property_Security.ZD_Sales_Showroom == "Y" ? true : false;
        chkSITS_Supra_Key_AdvantageView.Checked = objAP_Property_Security.SITS_Supra_Key_Advantage == "Y" ? true : false;

        chkKeyFobsView.Checked = objAP_Property_Security.AC_Key_Fobs == "Y" ? true : false;
        chkDoorRestrictionsView.Checked = objAP_Property_Security.AC_Door_Restrictions == "Y" ? true : false;

        if (objAP_Property_Security.Cap_Index_Crime_Score != null)
            lblCap_Index_Crime_Score.Text = Convert.ToString(objAP_Property_Security.Cap_Index_Crime_Score);
        else
            lblCap_Index_Crime_Score.Text = string.Empty;
        if (objAP_Property_Security.Cap_Index_Risk_Cateogory != null)
            lblCap_Index_Risk_Category.Text = new clsLU_AP_Cap_Index_Risk_Category((decimal)objAP_Property_Security.Cap_Index_Risk_Cateogory).Fld_Desc;
        else
            lblCap_Index_Risk_Category.Text = string.Empty;

        if (gvCCTVHoursMonitoringGrid.Rows.Count > 0)
        {
            if (objAP_Property_Security.Total_Hours_CCTV_Monitored_Per_Week != null)
                lblTotalHoursCCTVMonitoredPerWeek.Text = Convert.ToString(objAP_Property_Security.Total_Hours_CCTV_Monitored_Per_Week);
            else
                lblTotalHoursCCTVMonitoredPerWeek.Text = string.Empty;
        }
        else
        {
            lblTotalHoursCCTVMonitoredPerWeek.Text = string.Empty;
        }

        if (PK_AP_Property_Security > 0)
        {
            btnProperty_SecurityAuditView.Visible = true;
        }

        if (App_Assest_Protection == AccessType.View_Only)
            btnBack.Visible = false;

        BindFinancialGridforView();

    }

    /// <summary>
    /// Saves Data of Property Security
    /// </summary>
    private void PropertySecuritySaveData()
    {
        clsAP_Property_Security objAP_Property_Security = new clsAP_Property_Security();
        objAP_Property_Security.PK_AP_Property_Security = PK_AP_Property_Security;
        objAP_Property_Security.FK_LU_Location_Id = LocationID;
        objAP_Property_Security.FK_Building_Id = hdnBuildingNumberByLocation.Value;
        objAP_Property_Security.CCTV_Company_Name = txtCCTV_Company_Name.Text.Trim();
        objAP_Property_Security.CCTV_Company_Address_1 = txtCCTV_Company_Address_1.Text.Trim();
        objAP_Property_Security.CCTV_Company_Address_2 = txtCCTV_Company_Address_2.Text.Trim();
        objAP_Property_Security.CCTV_Company_City = txtCCTV_Company_City.Text.Trim();
        if (drpFK_CCTV_Company_State.SelectedIndex > 0) objAP_Property_Security.FK_CCTV_Company_State = Convert.ToDecimal(drpFK_CCTV_Company_State.SelectedValue);
        objAP_Property_Security.CCTV_Company_Zip = txtCCTV_Company_Zip.Text.Trim();
        objAP_Property_Security.CCTV_Company_Contact_Name = txtCCTV_Company_Contact_Name.Text.Trim();
        objAP_Property_Security.CCTV_Comapny_Contact_Telephone = txtCCTV_Comapny_Contact_Telephone.Text.Trim();
        objAP_Property_Security.CCTV_Company_Contact_EMail = txtCCTV_Company_Contact_EMail.Text.Trim();
        objAP_Property_Security.Cal_Atlantic_System = rdoCal_Atlantic_System.SelectedValue;
        objAP_Property_Security.Live_Monitoring = rdoLive_Monitoring.SelectedValue;
        objAP_Property_Security.ACI_Burglary_System = rdoACI_Burglary_System.SelectedValue;
        objAP_Property_Security.Live_Burglary_Monitoring = rdoLive_Burglary_Monitoring.SelectedValue;
        //objAP_Property_Security.Hours_Monitored_From = txtHours_Monitored_From.Text.Trim();
        //objAP_Property_Security.Hours_Monitored_To = txtHours_Monitored_To.Text.Trim();
        objAP_Property_Security.Exterior_Camera_Coverage_Other_Description = txtExterior_Camera_Coverage_Other_Description.Text.Trim();
        objAP_Property_Security.Interior_Camera_Coverage_Other_Description = txtInterior_Camera_Coverage_Other_Description.Text.Trim();

        objAP_Property_Security.Buglar_Alarm_System = rdoBuglar_Alarm_System.SelectedValue;
        objAP_Property_Security.Is_System_Active_and_Function_Properly = rdoIs_System_Active_and_Function_Properly.SelectedValue;
        objAP_Property_Security.Burglar_Alarm_Company_Name = txtBurglar_Alarm_Company_Name.Text.Trim();
        objAP_Property_Security.Burglar_Alarm_Company_Address_1 = txtBurglar_Alarm_Company_Address_1.Text.Trim();
        objAP_Property_Security.Burglar_Alarm_Company_Address_2 = txtBurglar_Alarm_Company_Address_2.Text.Trim();
        objAP_Property_Security.Burglar_Alarm_Company_City = txtBurglar_Alarm_Company_City.Text.Trim();
        if (drpFK_Burglar_Alarm_Company_State.SelectedIndex > 0) objAP_Property_Security.FK_Burglar_Alarm_Company_State = Convert.ToDecimal(drpFK_Burglar_Alarm_Company_State.SelectedValue);
        objAP_Property_Security.Burglar_Alarm_Company_Zip = txtBurglar_Alarm_Company_Zip.Text.Trim();
        objAP_Property_Security.Burglar_Alarm_Company_Contact_Name = txtBurglar_Alarm_Company_Contact_Name.Text.Trim();
        objAP_Property_Security.Burglar_Alarm_Comapny_Contact_Telephone = txtBurglar_Alarm_Comapny_Contact_Telephone.Text.Trim();
        objAP_Property_Security.Burglar_Alarm_Company_Contact_EMail = txtBurglar_Alarm_Company_Contact_EMail.Text.Trim();
        objAP_Property_Security.Burglar_Alarm_Coverage_Other_Description = txtBurglar_Alarm_Coverage_Other_Description.Text.Trim();
        objAP_Property_Security.Burglar_Alarm_Coverage_Comments = txtBurglar_Alarm_Coverage_Comments.Text.Trim();
        objAP_Property_Security.Guard_Company_Name = txtGuard_Company_Name.Text.Trim();
        objAP_Property_Security.Guard_Company_Address_1 = txtGuard_Company_Address_1.Text.Trim();
        objAP_Property_Security.Guard_Company_Address_2 = txtGuard_Company_Address_2.Text.Trim();
        objAP_Property_Security.Guard_Company_City = txtGuard_Company_City.Text.Trim();
        if (drpFK_Guard_Company_State.SelectedIndex > 0) objAP_Property_Security.FK_Guard_Company_State = Convert.ToDecimal(drpFK_Guard_Company_State.SelectedValue);
        objAP_Property_Security.Guard_Company_Zip = txtGuard_Company_Zip.Text.Trim();
        objAP_Property_Security.Guard_Company_Contact_Name = txtGuard_Company_Contact_Name.Text.Trim();
        objAP_Property_Security.Guard_Comapny_Contact_Telephone = txtGuard_Comapny_Contact_Telephone.Text.Trim();
        objAP_Property_Security.Guard_Company_Contact_EMail = txtGuard_Company_Contact_EMail.Text.Trim();
        //objAP_Property_Security.Guard_Hours_Monitored_From = txtGuard_Hours_Monitored_From.Text.Trim();
        //objAP_Property_Security.Guard_Hours_Monitored_To = txtGuard_Hours_Monitored_To.Text.Trim();
        objAP_Property_Security.OffDuty_Officer_Name = txtOffDuty_Officer_Name.Text.Trim();
        objAP_Property_Security.OffDuty_Officer_Telephone = txtOffDuty_Officer_Telephone.Text.Trim();
        //objAP_Property_Security.OffDuty_Officer_Hours_Monitored_From = txtOffDuty_Officer_Hours_Monitored_From.Text.Trim();
        //objAP_Property_Security.OffDuty_Officer_Hours_Monitored_To = txtOffDuty_Officer_Hours_Monitored_To.Text.Trim();
        objAP_Property_Security.Access_Control_Other_Description = txtAccess_Control_Other_Description.Text.Trim();
        objAP_Property_Security.Security_Inventory_Tracking_System_Other_Description = txtSecurity_Inventory_Tracking_System_Other_Description.Text.Trim();

        objAP_Property_Security.AC_1st_Floor_Only = chkACFirstFloorOnly.Checked ? "Y" : "N";
        objAP_Property_Security.AC_Business_Area = chkACBusinessArea.Checked ? "Y" : "N";
        objAP_Property_Security.AC_Cashier = chkACCashier.Checked ? "Y" : "N";
        objAP_Property_Security.AC_Computer_Room = chkACControlRoom.Checked ? "Y" : "N";
        objAP_Property_Security.AC_Controller_Office = chkACControllerOffice.Checked ? "Y" : "N";
        objAP_Property_Security.AC_EnterExit_Building = chkACEnterExitBuilding.Checked ? "Y" : "N";
        objAP_Property_Security.AC_F_and_I_Office = chkACFandIOffice.Checked ? "Y" : "N";
        objAP_Property_Security.AC_GM_Office = chkACGMOffice.Checked ? "Y" : "N";
        objAP_Property_Security.AC_Multiple_Floors = chkACMulipleFloors.Checked ? "Y" : "N";
        objAP_Property_Security.AC_Other = chkACOther.Checked ? "Y" : "N";
        objAP_Property_Security.AC_Parts = chkACParts.Checked ? "Y" : "N";
        objAP_Property_Security.AC_Smart_Sales_Office = chkACSmartSafeOffice.Checked ? "Y" : "N";
        objAP_Property_Security.ECC_Back = chkEccBack.Checked ? "Y" : "N";
        objAP_Property_Security.ECC_Car_Wash = chkEccCarwash.Checked ? "Y" : "N";
        objAP_Property_Security.ECC_Front = chkEccFront.Checked ? "Y" : "N";
        objAP_Property_Security.ECC_Other = chkEccOther.Checked ? "Y" : "N";
        objAP_Property_Security.ECC_Satellite_Parking = chkEccsatelliteParking.Checked ? "Y" : "N";
        objAP_Property_Security.ECC_Side = chkEccSide.Checked ? "Y" : "N";
        objAP_Property_Security.ECC_Zero_Lot_Line = chkEccZerodotLine.Checked ? "Y" : "N";
        objAP_Property_Security.F_Back = chkFBack.Checked ? "Y" : "N";
        objAP_Property_Security.F_Entire_Perimeter = chkFEntierPerimeter.Checked ? "Y" : "N";
        objAP_Property_Security.F_Front = chkFFront.Checked ? "Y" : "N";
        objAP_Property_Security.F_Satellite_Parking_Lot = chkFSatelliteParkingLot.Checked ? "Y" : "N";
        objAP_Property_Security.F_Side = chkFSide.Checked ? "Y" : "N";
        objAP_Property_Security.FG_EntranceExit_Alarms = chkFGEnterenceExitAlarms.Checked ? "Y" : "N";
        objAP_Property_Security.FG_EntranceExit_Gate = chkFGEnterenceExitGate.Checked ? "Y" : "N";

        objAP_Property_Security.ICC_Body_Shop = chkIccBodyShop.Checked ? "Y" : "N";
        objAP_Property_Security.ICC_Cashier = chkIccCashier.Checked ? "Y" : "N";
        objAP_Property_Security.ICC_Computer_Room = chkIccComputerRoom.Checked ? "Y" : "N";
        objAP_Property_Security.ICC_Detail_Bays = chkIccDetailBays.Checked ? "Y" : "N";
        objAP_Property_Security.ICC_Key_Box_Area = chkIccKeyBoxArea.Checked ? "Y" : "N";
        objAP_Property_Security.ICC_Other = chkIccOther.Checked ? "Y" : "N";
        objAP_Property_Security.ICC_Parts_Receiving_Area = chkIccPartsReceivingArea.Checked ? "Y" : "N";
        objAP_Property_Security.ICC_Service_Department = chkIccServiceDepartment.Checked ? "Y" : "N";
        objAP_Property_Security.ICC_Service_Lane = chkIccServiceLane.Checked ? "Y" : "N";
        objAP_Property_Security.ICC_Showroom = chkIccShowRoom.Checked ? "Y" : "N";
        objAP_Property_Security.ICC_Smart_Safe_Office = chkIccSmartSafeOffice.Checked ? "Y" : "N";
        objAP_Property_Security.P_Back = chkPBack.Checked ? "Y" : "N";
        objAP_Property_Security.P_Entire_Perimeter = chkPEntirePerimeter.Checked ? "Y" : "N";
        objAP_Property_Security.P_Front = chkPFront.Checked ? "Y" : "N";
        objAP_Property_Security.P_Satellite_Parking_Lot = chkPSatelliteParkingLot.Checked ? "Y" : "N";
        objAP_Property_Security.P_Side = chkPSide.Checked ? "Y" : "N";
        objAP_Property_Security.SITS_Auto_Tracks = chkSITSAutoTracks.Checked ? "Y" : "N";
        objAP_Property_Security.SITS_Key_Tracks = chkSITSKeyTracks.Checked ? "Y" : "N";
        objAP_Property_Security.SITS_Other = chkSITSOther.Checked ? "Y" : "N";
        objAP_Property_Security.SITS_Supra_Key_Advantage = chkSITS_Supra_Key_Advantage.Checked ? "Y" : "N";
        objAP_Property_Security.Update_Date = DateTime.Now;
        objAP_Property_Security.Updated_By = clsSession.UserID;
        objAP_Property_Security.ZD_Collision_Center = chkZDCollisionCenter.Checked ? "Y" : "N";
        objAP_Property_Security.ZD_Office = chkZDOffice.Checked ? "Y" : "N";
        objAP_Property_Security.ZD_Other = chkZDOther.Checked ? "Y" : "N";
        objAP_Property_Security.ZD_Parts = chkZDParts.Checked ? "Y" : "N";
        objAP_Property_Security.ZD_Sales = chkZDService.Checked ? "Y" : "N";
        objAP_Property_Security.ZD_Sales_Showroom = chkZDSalesShowroom.Checked ? "Y" : "N";

        if (txtNumberOfExternalCameras.Text == string.Empty)
            objAP_Property_Security.ECC_Number_Of_External_Cameras = null;
        else
            objAP_Property_Security.ECC_Number_Of_External_Cameras = Convert.ToInt32(txtNumberOfExternalCameras.Text.Replace(",", ""));
        if (txtNumberofInternalCameras.Text == string.Empty)
            objAP_Property_Security.ECC_Number_Of_Internal_Cameras = null;
        else
            objAP_Property_Security.ECC_Number_Of_Internal_Cameras = Convert.ToInt32(txtNumberofInternalCameras.Text.Replace(",", ""));
        objAP_Property_Security.AC_Key_Fobs = chkKeyFobs.Checked ? "Y" : "N";
        objAP_Property_Security.AC_Door_Restrictions = chkDoorRestrictions.Checked ? "Y" : "N";

        if (txtCap_Index_Crime_Score.Text.Trim() != string.Empty)
            objAP_Property_Security.Cap_Index_Crime_Score = Convert.ToInt32(Convert.ToString(txtCap_Index_Crime_Score.Text.Trim()));

        if (txttotalHoursMonitoredPerWeek.Text.Trim() != string.Empty)
            objAP_Property_Security.Total_Hours_CCTV_Monitored_Per_Week = Convert.ToString(txttotalHoursMonitoredPerWeek.Text.Trim());

        if (ddlCap_Index_Risk_Category.SelectedIndex > 0) objAP_Property_Security.Cap_Index_Risk_Cateogory = Convert.ToDecimal(ddlCap_Index_Risk_Category.SelectedValue);
        if (objAP_Property_Security.PK_AP_Property_Security > 0)
        {
            objAP_Property_Security.Update();
        }
        else
        {
            PK_AP_Property_Security = objAP_Property_Security.Insert();
        }

        if (PK_AP_Property_Security > 0)
        {
            btnReturnto_View_Mode.Visible = true;
            btnProperty_SecurityAudit.Visible = true;
            //btnGenerate_Abstract.Visible = true;
            BindPropertySecurityBuilding();
            btnGenerate_Abstract.Style["display"] = "";
            dvProperty_SecuritySave.Style["display"] = "";

        }
    }

    /// <summary>
    /// Bind Property Security Monitoring Grid
    /// </summary>
    private void BindPropertySecurityMonitoringGrid()
    {
        DataSet dsMonitoringGrid = clsAP_Property_Security_Monitor_Grids.SelectAllForMonitoringGrid(PK_AP_Property_Security);
        if (StrOperation != "view")
        {

            //Bind CCTV Monitoring Grid
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'CCTV'";
            gvCCTVHoursMonitoringGrid.DataSource = dsMonitoringGrid.Tables[0].DefaultView;
            gvCCTVHoursMonitoringGrid.DataBind();

            //Added due to Issue #3173
            //if (dsMonitoringGrid.Tables[1].Rows.Count > 0)
            //    txttotalHoursMonitoredPerWeek.Text = Convert.ToString(dsMonitoringGrid.Tables[1].Rows[0][0]);

            //Bind Guard Monitoring Grid
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'Guard'";
            gvGuardHoursMonitorGrid.DataSource = dsMonitoringGrid.Tables[0].DefaultView;
            gvGuardHoursMonitorGrid.DataBind();

            //Bidn Off Duty Monitoring Grid
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'Off-Duty Officer'";
            gvOffDutyOfficerHoursMonitoredGrid.DataSource = dsMonitoringGrid.Tables[0].DefaultView;
            gvOffDutyOfficerHoursMonitoredGrid.DataBind();

        }
        else
        {
            //Bind CCTV Monitoring Grid
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'CCTV'";
            gvCCTVHoursMonitoringGridView.DataSource = dsMonitoringGrid.Tables[0].DefaultView;
            gvCCTVHoursMonitoringGridView.DataBind();

            //Added due to Issue #3173
            //if (dsMonitoringGrid.Tables[1].Rows.Count > 0)
            //    lblTotalHoursCCTVMonitoredPerWeek.Text = Convert.ToString(dsMonitoringGrid.Tables[1].Rows[0][0]);

            //Bind Guard Monitoring Grid
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'Guard'";
            gvGuardHoursMonitorGridView.DataSource = dsMonitoringGrid.Tables[0].DefaultView;
            gvGuardHoursMonitorGridView.DataBind();

            //Bidn Off Duty Monitoring Grid
            dsMonitoringGrid.Tables[0].DefaultView.RowFilter = "Grid_Type = 'Off-Duty Officer'";
            gvOffDutyOfficerHoursMonitoredGridView.DataSource = dsMonitoringGrid.Tables[0].DefaultView;
            gvOffDutyOfficerHoursMonitoredGridView.DataBind();
        }

    }


    /// <summary>
    /// Bind Property Security Monitoring Grid
    /// </summary>
    /// 
    private void bindPropertyMonitoringDetailForEdit(decimal PK_AP_Property_Security_Monitor_Grids)
    {
        if (PK_AP_Property_Security_Monitor_Grids > 0)
        {
            clsAP_Property_Security_Monitor_Grids objclsAP_Property_Security_Monitor_Grids = new clsAP_Property_Security_Monitor_Grids(PK_AP_Property_Security_Monitor_Grids);
            StrMonitorGridType = objclsAP_Property_Security_Monitor_Grids.Grid_Type;
            BindPropertySecurityMonitoringGrid();
        }
    }

    /// <summary>
    /// Show Hide Camera rows #Issue 3784 comment 37437
    /// </summary>
    private void ShoHideCameraRow()
    {
        //If user select Burglar Alarm system No Then this two fields should not show up in screen. 
        //If user select Burglar Alarm System YE then this two field should show up in the screen. 
        if (StrOperation == "view")
        {
            if (lblBuglar_Alarm_System.Text == "Yes")
                trACICamera_View.Visible = trLiveCamera_View.Visible = true;
            else
                trACICamera_View.Visible = trLiveCamera_View.Visible = false;
        }
        else
        {
            if (rdoBuglar_Alarm_System.SelectedValue == "Y")
                trACICamera_Edit.Visible = trLiveCamera_Edit.Visible = true;
            else
                trACICamera_Edit.Visible = trLiveCamera_Edit.Visible = false;
        }
    }

    #endregion

    #region "DPD_FROIs"

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEditForDPD_FROIs()
    {
        if (FK_DPD_FR_ID == 0)
            if (Request.QueryString["Sect"] != null && Request.QueryString["Sect"].ToString() == "notes")
            {
                FK_DPD_FR_ID = DPD_RowIndex;
            }

        DataTable dtDPD_FROIs_Detail = clsAP_DPD_FROIs.GetDPD_FROIs_DetailByPK(FK_DPD_FR_ID, FK_DPD_FR_Vehicle_ID, PK_AP_DPD_FROIs).Tables[0];

        if (dtDPD_FROIs_Detail != null && dtDPD_FROIs_Detail.Rows.Count > 0)
        {
            if (PK_AP_DPD_FROIs > 0)
                btnDPD_FROIsAudit_Trail.Visible = true;
            else
                btnDPD_FROIsAudit_Trail.Visible = false;
            lblIncident_Number.Text = dtDPD_FROIs_Detail.Rows[0]["DPD_FR_Number"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["DPD_FR_Number"].ToString() : "";
            txtDate_Of_Loss.Text = dtDPD_FROIs_Detail.Rows[0]["Date_Of_Loss"].ToString() != "" ? clsGeneral.FormatDBNullDateToDisplay(dtDPD_FROIs_Detail.Rows[0]["Date_Of_Loss"].ToString()) : "";
            txtTime_of_Loss.Text = dtDPD_FROIs_Detail.Rows[0]["Time_of_Loss"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Time_of_Loss"].ToString() : "";
            txtCause_of_Loss.Text = dtDPD_FROIs_Detail.Rows[0]["Cause_Of_Loss"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Cause_Of_Loss"].ToString() : "";
            txtVIN.Text = dtDPD_FROIs_Detail.Rows[0]["VIN"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["VIN"].ToString() : "";
            txtMake.Text = dtDPD_FROIs_Detail.Rows[0]["Make"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Make"].ToString() : "";
            txtModel.Text = dtDPD_FROIs_Detail.Rows[0]["Model"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Model"].ToString() : "";
            txtYear.Text = dtDPD_FROIs_Detail.Rows[0]["Year"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Year"].ToString() : "";
            txtTypeOfVehicle.Text = dtDPD_FROIs_Detail.Rows[0]["TypeOfVehicle"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["TypeOfVehicle"].ToString() : "";
            txtPresent_Location.Text = dtDPD_FROIs_Detail.Rows[0]["Present_Location"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Present_Location"].ToString() : "";
            txtPresent_Address.Text = dtDPD_FROIs_Detail.Rows[0]["Present_Address"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Present_Address"].ToString() : "";
            txtPresent_State.Text = dtDPD_FROIs_Detail.Rows[0]["Present_State"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Present_State"].ToString() : "";
            txtPresent_Zip.Text = dtDPD_FROIs_Detail.Rows[0]["Present_Zip"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Present_Zip"].ToString() : "";
            txtInvoice_Value.Text = dtDPD_FROIs_Detail.Rows[0]["Invoice_Value"].ToString() != "" ? clsGeneral.GetStringValue(dtDPD_FROIs_Detail.Rows[0]["Invoice_Value"].ToString()) : "";
            txtLoss_Description.Text = dtDPD_FROIs_Detail.Rows[0]["Loss_Description"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Loss_Description"].ToString() : "";

            chk3rd_Party_Vendor_Related_Theft.Checked = dtDPD_FROIs_Detail.Rows[0]["Third_Party_Vendor_Related_Theft"].ToString() == "Y" ? true : false;
            chkAccess_Control_Failures.Checked = dtDPD_FROIs_Detail.Rows[0]["Access_Control_Failures"].ToString() == "Y" ? true : false;
            chkBreaking_and_Entering.Checked = dtDPD_FROIs_Detail.Rows[0]["Breaking_And_Entering"].ToString() == "Y" ? true : false;


            chkBurglar_Alarm_Failure.Checked = dtDPD_FROIs_Detail.Rows[0]["Burglar_Alarm_Failure"].ToString() == "Y" ? true : false;
            chkCamera_Dead_Spot.Checked = dtDPD_FROIs_Detail.Rows[0]["Camera_Dead_Spot"].ToString() == "Y" ? true : false;
            chkCCTV_Monitoring_Failure.Checked = dtDPD_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure"].ToString() == "Y" ? true : false;

            chkCCTV_Monitoring_Failure_byOperator.Checked = dtDPD_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure_By_Operator"].ToString() == "Y" ? true : false;
            chkDesign_weakness_Property_Protection.Checked = dtDPD_FROIs_Detail.Rows[0]["Design_Weakness_Property_Protection"].ToString() == "Y" ? true : false;
            chkEnvironmental_Obstruction_ConditionCamera.Checked = dtDPD_FROIs_Detail.Rows[0]["Environmental_Obstruction_and_or_Condition_Camera"].ToString() == "Y" ? true : false;

            chkFailure_to_ReportLate_Report.Checked = dtDPD_FROIs_Detail.Rows[0]["Failure_to_Report_and_or_Late_Report"].ToString() == "Y" ? true : false;
            chkKey_Swap.Checked = dtDPD_FROIs_Detail.Rows[0]["Key_Swap"].ToString() == "Y" ? true : false;
            chkLighting_Deficiencies.Checked = dtDPD_FROIs_Detail.Rows[0]["Lighting_Deficiencies"].ToString() == "Y" ? true : false;

            chkLockBox_Not_Properly_Secured.Checked = dtDPD_FROIs_Detail.Rows[0]["Lock_Box_Not_Properly_Secured"].ToString() == "Y" ? true : false;
            chkNegligence_Lackof_Key_Control_Program_Unattended_Keys.Checked = dtDPD_FROIs_Detail.Rows[0]["Negligence_Lack_of_key_Control_Program_Unattended_Keys"].ToString() == "Y" ? true : false;
            chkNonPermissible_User_of_TakingVehicle.Checked = dtDPD_FROIs_Detail.Rows[0]["Non_Permissible_User_of_Taking_Vehicle"].ToString() == "Y" ? true : false;

            chkPower_Outage.Checked = dtDPD_FROIs_Detail.Rows[0]["Power_Outage"].ToString() == "Y" ? true : false;
            chkSecurity_Guard_Failure.Checked = dtDPD_FROIs_Detail.Rows[0]["Security_Guard_Failure"].ToString() == "Y" ? true : false;
            chkStolen_Id.Checked = dtDPD_FROIs_Detail.Rows[0]["Stolen_Id"].ToString() == "Y" ? true : false;

            chkTheft_by_Deception.Checked = dtDPD_FROIs_Detail.Rows[0]["Theft_By_Deception"].ToString() == "Y" ? true : false;
            chkUnauthorized_Building_Entry_Forcible.Checked = dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Forcible"].ToString() == "Y" ? true : false;
            chkUnauthorized_Building_Entry_Unlocked.Checked = dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Unlocked"].ToString() == "Y" ? true : false;

            chkUnauthorized_Vehicle_Entry_Forcible.Checked = dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Forcible"].ToString() == "Y" ? true : false;
            chkUnauthorized_Vehicle_Entry_Unlocked.Checked = dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Unlocked"].ToString() == "Y" ? true : false;
            chkVehicle_Takenby_Tow_Truck.Checked = dtDPD_FROIs_Detail.Rows[0]["Vehicle_Taken_By_Tow_Truck"].ToString() == "Y" ? true : false;

            chkWeather_Related_DamageLoss.Checked = dtDPD_FROIs_Detail.Rows[0]["Weather_Related_Damage_and_or_Loss"].ToString() == "Y" ? true : false;
            chkOther_Describe.Checked = dtDPD_FROIs_Detail.Rows[0]["Other_Describe"].ToString() == "Y" ? true : false;

            txtInvestigation_Finding_Other_Description.Text = dtDPD_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"].ToString() : "";
            txtRoot_Cause.Text = dtDPD_FROIs_Detail.Rows[0]["Root_Cause"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Root_Cause"].ToString() : "";
            txtIncident_Prevention.Text = dtDPD_FROIs_Detail.Rows[0]["Incident_Prevention"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Incident_Prevention"].ToString() : "";
            txtPerson_Tasked.Text = dtDPD_FROIs_Detail.Rows[0]["Person_Tasked"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Person_Tasked"].ToString() : "";

            txtTarget_Date_of_Completion.Text = dtDPD_FROIs_Detail.Rows[0]["Target_Date_of_Completion"].ToString() != "" ? clsGeneral.FormatDBNullDateToDisplay(dtDPD_FROIs_Detail.Rows[0]["Target_Date_of_Completion"].ToString()) : "";
            txtStatus_Due_On.Text = dtDPD_FROIs_Detail.Rows[0]["Status_Due_On"].ToString() != "" ? clsGeneral.FormatDBNullDateToDisplay(dtDPD_FROIs_Detail.Rows[0]["Status_Due_On"].ToString()) : "";

            txtComments.Text = dtDPD_FROIs_Detail.Rows[0]["Comments"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Comments"].ToString() : "";
            txtFinancial_Loss.Text = dtDPD_FROIs_Detail.Rows[0]["Financial_Loss"].ToString() != "" ? clsGeneral.GetStringValue(dtDPD_FROIs_Detail.Rows[0]["Financial_Loss"].ToString()) : "";
            txtRecovery.Text = dtDPD_FROIs_Detail.Rows[0]["Recovery"].ToString() != "" ? clsGeneral.GetStringValue(dtDPD_FROIs_Detail.Rows[0]["Recovery"].ToString()) : "";
            drpItem_Status.SelectedValue = dtDPD_FROIs_Detail.Rows[0]["Item_Status"].ToString() == "O" ? "1" : dtDPD_FROIs_Detail.Rows[0]["Item_Status"].ToString() == "C" ? "2" : "0";
            lblDPDClaim_Number.Text = dtDPD_FROIs_Detail.Rows[0]["Origin_Claim_Number"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Origin_Claim_Number"].ToString() : "";

            txtVehicleColor.Text = dtDPD_FROIs_Detail.Rows[0]["Vehicle_Color"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Vehicle_Color"].ToString() : "";
            txtPoliceCaseNumber.Text = dtDPD_FROIs_Detail.Rows[0]["Police_Case_Number"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Police_Case_Number"].ToString() : "";
            txtInvestigatingPoliceDepartment.Text = dtDPD_FROIs_Detail.Rows[0]["Investigating_Police_Department"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Investigating_Police_Department"].ToString() : "";
            chkVandalism.Checked = dtDPD_FROIs_Detail.Rows[0]["Vandalism"].ToString() == "Y" ? true : false;
            chkLockBox.Checked = Convert.ToString(dtDPD_FROIs_Detail.Rows[0]["Lock_Box_Stolen_Removed"]) == "Y" ? true : false;

            if (!string.IsNullOrEmpty(AP_DPD_FROIs_CommandArgs))
            {
                string[] arg = new string[4];
                arg = AP_DPD_FROIs_CommandArgs.Split(';');
                FK_DPD_FR_ID = Convert.ToDecimal(arg[0]);
                PK_AP_DPD_FROIs = Convert.ToDecimal(arg[1]);
                clsSession.First_Report_Wizard_ID = Convert.ToInt32(arg[2]);
                FK_DPD_FR_Vehicle_ID = Convert.ToDecimal(arg[3]);
                PK_DPD_Claims_ID = Convert.ToDecimal(arg[4]);
            }
            if (PK_AP_DPD_FROIs > 0)
            {
                ctrlAPNotes_DPD.Location_ID = Convert.ToInt32(LocationID);
                ctrlAPNotes_DPD.PK_DPD_Claims_ID = Convert.ToInt32(PK_DPD_Claims_ID);
                ctrlAPNotes_DPD.CurrentClaimType = "AP_DPD_FROIs";
                ctrlAPNotes_DPD.BindGridSonicNotes(PK_AP_DPD_FROIs, "AP_DPD_FROIs");
            }
            else
            {
                ctrlAPNotes_DPD.BindEmptyGrid();
            }
        }
    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForViewForDPD_FROIs()
    {
        if (FK_DPD_FR_ID == 0)
        {
            if (Request.QueryString["Sect"] != null && Request.QueryString["Sect"].ToString() == "notes")
            {
                FK_DPD_FR_ID = DPD_RowIndex;
            }

            if (!string.IsNullOrEmpty(AP_DPD_FROIs_CommandArgs))
            {
                string[] arg = new string[4];
                arg = AP_DPD_FROIs_CommandArgs.Split(';');
                FK_DPD_FR_ID = Convert.ToDecimal(arg[0]);
                PK_AP_DPD_FROIs = Convert.ToDecimal(arg[1]);
                clsSession.First_Report_Wizard_ID = Convert.ToInt32(arg[2]);
                FK_DPD_FR_Vehicle_ID = Convert.ToDecimal(arg[3]);
                PK_DPD_Claims_ID = Convert.ToDecimal(arg[4]);

            }
        }

        DataTable dtDPD_FROIs_Detail = clsAP_DPD_FROIs.GetDPD_FROIs_DetailByPK(FK_DPD_FR_ID, FK_DPD_FR_Vehicle_ID, PK_AP_DPD_FROIs).Tables[0];

        if (dtDPD_FROIs_Detail != null && dtDPD_FROIs_Detail.Rows.Count > 0)
        {
            if (PK_AP_DPD_FROIs > 0)
                btnDPD_FROIsAudit_TrailView.Visible = true;
            else
                btnDPD_FROIsAudit_TrailView.Visible = false;
            lblIncident_NumberView.Text = dtDPD_FROIs_Detail.Rows[0]["DPD_FR_Number"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["DPD_FR_Number"].ToString() : "";
            lblDate_Of_Loss.Text = dtDPD_FROIs_Detail.Rows[0]["Date_Of_Loss"].ToString() != "" ? clsGeneral.FormatDBNullDateToDisplay(dtDPD_FROIs_Detail.Rows[0]["Date_Of_Loss"].ToString()) : "";
            lblTime_of_Loss.Text = dtDPD_FROIs_Detail.Rows[0]["Time_of_Loss"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Time_of_Loss"].ToString() : "";
            lblCause_of_Loss.Text = dtDPD_FROIs_Detail.Rows[0]["Cause_Of_Loss"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Cause_Of_Loss"].ToString() : "";
            lblVIN.Text = dtDPD_FROIs_Detail.Rows[0]["VIN"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["VIN"].ToString() : "";
            lblMake.Text = dtDPD_FROIs_Detail.Rows[0]["Make"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Make"].ToString() : "";
            lblModel.Text = dtDPD_FROIs_Detail.Rows[0]["Model"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Model"].ToString() : "";
            lblYear.Text = dtDPD_FROIs_Detail.Rows[0]["Year"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Year"].ToString() : "";
            lblTypeOfVehicle.Text = dtDPD_FROIs_Detail.Rows[0]["TypeOfVehicle"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["TypeOfVehicle"].ToString() : "";
            lblPresent_Location.Text = dtDPD_FROIs_Detail.Rows[0]["Present_Location"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Present_Location"].ToString() : "";
            lblPresent_Address.Text = dtDPD_FROIs_Detail.Rows[0]["Present_Address"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Present_Address"].ToString() : "";
            lblPresent_State.Text = dtDPD_FROIs_Detail.Rows[0]["Present_State"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Present_State"].ToString() : "";
            lblPresent_Zip.Text = dtDPD_FROIs_Detail.Rows[0]["Present_Zip"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Present_Zip"].ToString() : "";
            lblInvoice_Value.Text = dtDPD_FROIs_Detail.Rows[0]["Invoice_Value"].ToString() != "" ? clsGeneral.GetStringValue(dtDPD_FROIs_Detail.Rows[0]["Invoice_Value"].ToString()) : "";
            lblLoss_Description.Text = dtDPD_FROIs_Detail.Rows[0]["Loss_Description"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Loss_Description"].ToString() : "";

            chk3rd_Party_Vendor_Related_TheftView.Checked = dtDPD_FROIs_Detail.Rows[0]["Third_Party_Vendor_Related_Theft"].ToString() == "Y" ? true : false;
            chkAccess_Control_FailuresView.Checked = dtDPD_FROIs_Detail.Rows[0]["Access_Control_Failures"].ToString() == "Y" ? true : false;
            chkBreaking_and_EnteringView.Checked = dtDPD_FROIs_Detail.Rows[0]["Breaking_And_Entering"].ToString() == "Y" ? true : false;


            chkBurglar_Alarm_FailureView.Checked = dtDPD_FROIs_Detail.Rows[0]["Burglar_Alarm_Failure"].ToString() == "Y" ? true : false;
            chkCamera_Dead_SpotView.Checked = dtDPD_FROIs_Detail.Rows[0]["Camera_Dead_Spot"].ToString() == "Y" ? true : false;
            chkCCTV_Monitoring_FailureView.Checked = dtDPD_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure"].ToString() == "Y" ? true : false;

            chkCCTV_Monitoring_Failure_byOperatorView.Checked = dtDPD_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure_By_Operator"].ToString() == "Y" ? true : false;
            chkDesign_weakness_Property_ProtectionView.Checked = dtDPD_FROIs_Detail.Rows[0]["Design_Weakness_Property_Protection"].ToString() == "Y" ? true : false;
            chkEnvironmental_Obstruction_ConditionCameraView.Checked = dtDPD_FROIs_Detail.Rows[0]["Environmental_Obstruction_and_or_Condition_Camera"].ToString() == "Y" ? true : false;

            chkFailure_to_ReportLate_ReportView.Checked = dtDPD_FROIs_Detail.Rows[0]["Failure_to_Report_and_or_Late_Report"].ToString() == "Y" ? true : false;
            chkKey_SwapView.Checked = dtDPD_FROIs_Detail.Rows[0]["Key_Swap"].ToString() == "Y" ? true : false;
            chkLighting_DeficienciesView.Checked = dtDPD_FROIs_Detail.Rows[0]["Lighting_Deficiencies"].ToString() == "Y" ? true : false;

            chkLockBox_Not_Properly_SecuredView.Checked = dtDPD_FROIs_Detail.Rows[0]["Lock_Box_Not_Properly_Secured"].ToString() == "Y" ? true : false;
            chkNegligence_Lackof_Key_Control_Program_Unattended_KeysView.Checked = dtDPD_FROIs_Detail.Rows[0]["Negligence_Lack_of_key_Control_Program_Unattended_Keys"].ToString() == "Y" ? true : false;
            chkNonPermissible_User_of_TakingVehicleView.Checked = dtDPD_FROIs_Detail.Rows[0]["Non_Permissible_User_of_Taking_Vehicle"].ToString() == "Y" ? true : false;

            chkPower_OutageView.Checked = dtDPD_FROIs_Detail.Rows[0]["Power_Outage"].ToString() == "Y" ? true : false;
            chkSecurity_Guard_FailureView.Checked = dtDPD_FROIs_Detail.Rows[0]["Security_Guard_Failure"].ToString() == "Y" ? true : false;
            chkStolen_IdView.Checked = dtDPD_FROIs_Detail.Rows[0]["Stolen_Id"].ToString() == "Y" ? true : false;

            chkTheft_by_DeceptionView.Checked = dtDPD_FROIs_Detail.Rows[0]["Theft_By_Deception"].ToString() == "Y" ? true : false;
            chkUnauthorized_Building_Entry_ForcibleView.Checked = dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Forcible"].ToString() == "Y" ? true : false;
            chkUnauthorized_Building_Entry_UnlockedView.Checked = dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Unlocked"].ToString() == "Y" ? true : false;

            chkUnauthorized_Vehicle_Entry_ForcibleView.Checked = dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Forcible"].ToString() == "Y" ? true : false;
            chkUnauthorized_Vehicle_Entry_UnlockedView.Checked = dtDPD_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Unlocked"].ToString() == "Y" ? true : false;
            chkVehicle_Takenby_Tow_TruckView.Checked = dtDPD_FROIs_Detail.Rows[0]["Vehicle_Taken_By_Tow_Truck"].ToString() == "Y" ? true : false;

            chkWeather_Related_DamageLossView.Checked = dtDPD_FROIs_Detail.Rows[0]["Weather_Related_Damage_and_or_Loss"].ToString() == "Y" ? true : false;
            chkOther_DescribeView.Checked = dtDPD_FROIs_Detail.Rows[0]["Other_Describe"].ToString() == "Y" ? true : false;

            lblInvestigation_Finding_Other_Description.Text = dtDPD_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"].ToString() : "";
            lblRoot_Cause.Text = dtDPD_FROIs_Detail.Rows[0]["Root_Cause"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Root_Cause"].ToString() : "";
            lblIncident_Prevention.Text = dtDPD_FROIs_Detail.Rows[0]["Incident_Prevention"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Incident_Prevention"].ToString() : "";
            lblPerson_Tasked.Text = dtDPD_FROIs_Detail.Rows[0]["Person_Tasked"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Person_Tasked"].ToString() : "";

            lblTarget_Date_of_Completion.Text = dtDPD_FROIs_Detail.Rows[0]["Target_Date_of_Completion"].ToString() != "" ? clsGeneral.FormatDBNullDateToDisplay(dtDPD_FROIs_Detail.Rows[0]["Target_Date_of_Completion"].ToString()) : "";
            lblStatus_Due_On.Text = dtDPD_FROIs_Detail.Rows[0]["Status_Due_On"].ToString() != "" ? clsGeneral.FormatDBNullDateToDisplay(dtDPD_FROIs_Detail.Rows[0]["Status_Due_On"].ToString()) : "";

            lblComments.Text = dtDPD_FROIs_Detail.Rows[0]["Comments"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Comments"].ToString() : "";
            lblFinancial_Loss.Text = dtDPD_FROIs_Detail.Rows[0]["Financial_Loss"].ToString() != "" ? clsGeneral.GetStringValue(dtDPD_FROIs_Detail.Rows[0]["Financial_Loss"].ToString()) : "";
            lblRecovery.Text = dtDPD_FROIs_Detail.Rows[0]["Recovery"].ToString() != "" ? clsGeneral.GetStringValue(dtDPD_FROIs_Detail.Rows[0]["Recovery"].ToString()) : "";
            lblItem_Status.Text = dtDPD_FROIs_Detail.Rows[0]["Item_Status"].ToString() == "O" ? "Open" : dtDPD_FROIs_Detail.Rows[0]["Item_Status"].ToString() == "C" ? "Close" : "";
            lblDPDClaim_NumberView.Text = dtDPD_FROIs_Detail.Rows[0]["Origin_Claim_Number"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Origin_Claim_Number"].ToString() : "";

            lblVehicleColor.Text = dtDPD_FROIs_Detail.Rows[0]["Vehicle_Color"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Vehicle_Color"].ToString() : "";
            lblPoliceCaseNumber.Text = dtDPD_FROIs_Detail.Rows[0]["Police_Case_Number"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Police_Case_Number"].ToString() : "";
            lblInvestigatingPoliceDepartment.Text = dtDPD_FROIs_Detail.Rows[0]["Investigating_Police_Department"].ToString() != "" ? dtDPD_FROIs_Detail.Rows[0]["Investigating_Police_Department"].ToString() : "";
            chkVandalismView.Checked = dtDPD_FROIs_Detail.Rows[0]["Vandalism"].ToString() == "Y" ? true : false;
            chkLockBoxView.Checked = Convert.ToString(dtDPD_FROIs_Detail.Rows[0]["Lock_Box_Stolen_Removed"]) == "Y" ? true : false;
            if (PK_AP_DPD_FROIs > 0)
            {
                ctrlAPNotes_DPDView.Location_ID = Convert.ToInt32(LocationID);
                ctrlAPNotes_DPDView.PK_DPD_Claims_ID = Convert.ToInt32(PK_DPD_Claims_ID);
                ctrlAPNotes_DPDView.CurrentClaimType = "AP_DPD_FROIs";
                ctrlAPNotes_DPDView.BindGridSonicNotes(PK_AP_DPD_FROIs, "AP_DPD_FROIs");
            }
            else
            {
                ctrlAPNotes_DPDView.BindEmptyGrid();
            }
        }
    }

    /// <summary>
    /// Bind Assest Protection DPD FROIs Grid
    /// </summary>
    /// <param name="PageNumber"></param>
    /// <param name="PageSize"></param>
    private void BindAP_DPD_FROIs_Grid(int PageNumber, int PageSize)
    {
        if (StrOperation.ToLower() == "view")
        {
            DataSet dsFROIs = clsAP_DPD_FROIs.GetDataToBindFROIsGrid(rdoDPD_FROIsView.SelectedValue, LocationID, PageNumber, PageSize, SortOrder_DPDFROIs, SortBy_DPDFROIs);
            DataTable dtFROIs = dsFROIs.Tables[0];
            CtrlPagingDPD_FROIsView.TotalRecords = (dsFROIs.Tables.Count >= 2) ? Convert.ToInt32(dsFROIs.Tables[1].Rows[0][0]) : 0;
            CtrlPagingDPD_FROIsView.CurrentPage = (dsFROIs.Tables.Count >= 2) ? Convert.ToInt32(dsFROIs.Tables[1].Rows[0][2]) : 0;
            CtrlPagingDPD_FROIsView.RecordsToBeDisplayed = dsFROIs.Tables[0].Rows.Count;
            CtrlPagingDPD_FROIsView.SetPageNumbers();
            gvAP_DPD_FROIsView.DataSource = dtFROIs;
            gvAP_DPD_FROIsView.DataBind();
        }
        else
        {
            DataSet dsFROIs = clsAP_DPD_FROIs.GetDataToBindFROIsGrid(rdoFROIs.SelectedValue, LocationID, PageNumber, PageSize, SortOrder_DPDFROIs, SortBy_DPDFROIs);
            DataTable dtFROIs = dsFROIs.Tables[0];
            CtrlPagingDPD_FROIs.TotalRecords = (dsFROIs.Tables.Count >= 2) ? Convert.ToInt32(dsFROIs.Tables[1].Rows[0][0]) : 0;
            CtrlPagingDPD_FROIs.CurrentPage = (dsFROIs.Tables.Count >= 2) ? Convert.ToInt32(dsFROIs.Tables[1].Rows[0][2]) : 0;
            CtrlPagingDPD_FROIs.RecordsToBeDisplayed = dsFROIs.Tables[0].Rows.Count;
            CtrlPagingDPD_FROIs.SetPageNumbers();
            gvAP_DPD_FROIs.DataSource = dtFROIs;
            gvAP_DPD_FROIs.DataBind();
        }
    }

    /// <summary>
    /// Bind Witness Grid
    /// </summary>
    private void BindWitnessGrid()
    {
        DataTable dtWitness = DPD_Witness.SelectByFK(FK_DPD_FR_ID).Tables[0];
        if (StrOperation.ToLower() != "view")
        {
            gvDPD_Witnesses.DataSource = dtWitness;
            gvDPD_Witnesses.DataBind();
        }
        else
        {
            gvDPD_WitnessesView.DataSource = dtWitness;
            gvDPD_WitnessesView.DataBind();
        }

    }

    /// <summary>
    /// Clear DPD FROIS Details
    /// </summary>
    private void ClearDPDFROIS()
    {
        lblDate_Of_Loss.Text = "";
        lblTime_of_Loss.Text = "";
        lblCause_of_Loss.Text = "";
        lblVIN.Text = "";
        lblMake.Text = "";
        lblModel.Text = "";
        lblYear.Text = "";
        lblTypeOfVehicle.Text = "";
        lblVehicleColor.Text = "";
        lblPresent_Location.Text = "";
        lblPresent_Address.Text = "";
        lblPresent_State.Text = "";
        lblPresent_Zip.Text = "";
        lblInvoice_Value.Text = "";
        lblPoliceCaseNumber.Text = "";
        lblInvestigatingPoliceDepartment.Text = "";
        lblLoss_Description.Text = "";
        lblAssocaitedClaimNo.Text = "";
        lblDPDClaim_NumberView.Text = "";
        lblIncident_NumberView.Text = "";
        ctrlAPNotes_DPDView.BindEmptyGrid();

        chk3rd_Party_Vendor_Related_TheftView.Checked = false;
        chkAccess_Control_FailuresView.Checked = false;
        chkBreaking_and_EnteringView.Checked = false;
        chkBurglar_Alarm_FailureView.Checked = false;
        chkCamera_Dead_SpotView.Checked = false;
        chkCCTV_Monitoring_FailureView.Checked = false;
        chkCCTV_Monitoring_Failure_byOperatorView.Checked = false;
        chkDesign_weakness_Property_ProtectionView.Checked = false;
        chkEnvironmental_Obstruction_ConditionCameraView.Checked = false;
        chkFailure_to_ReportLate_ReportView.Checked = false;
        chkKey_SwapView.Checked = false;
        chkLighting_DeficienciesView.Checked = false;
        chkLockBoxView.Checked = false;
        chkLockBox_Not_Properly_SecuredView.Checked = false;
        chkNegligence_Lackof_Key_Control_Program_Unattended_KeysView.Checked = false;
        chkNonPermissible_User_of_TakingVehicleView.Checked = false;
        chkPower_OutageView.Checked = false;
        chkSecurity_Guard_FailureView.Checked = false;
        chkStolen_IdView.Checked = false;
        chkTheft_by_DeceptionView.Checked = false;
        chkUnauthorized_Building_Entry_ForcibleView.Checked = false;
        chkUnauthorized_Building_Entry_UnlockedView.Checked = false;
        chkUnauthorized_Vehicle_Entry_ForcibleView.Checked = false;
        chkUnauthorized_Vehicle_Entry_UnlockedView.Checked = false;
        chkVehicle_Takenby_Tow_TruckView.Checked = false;
        chkWeather_Related_DamageLossView.Checked = false;
        chkVandalismView.Checked = false;
        chkOther_DescribeView.Checked = false;

        lblInvestigation_Finding_Other_Description.Text = "";
        lblRoot_Cause.Text = "";
        lblIncident_Prevention.Text = "";
        lblPerson_Tasked.Text = "";
        lblTarget_Date_of_Completion.Text = "";
        lblStatus_Due_On.Text = "";
        lblComments.Text = "";
        lblFinancial_Loss.Text = "";
        lblRecovery.Text = "";
        lblItem_Status.Text = "";

        btnDPD_FROIsAudit_TrailView.Visible = false;
    }
    #endregion

    #region "AL_FROI"

    /// <summary>
    /// Bind AP_AL_FROIs Grid
    /// </summary>
    private void BindAP_AL_FROIs_Grid(int PageNumber, int PageSize)
    {
        if (StrOperation.ToLower() == "view")
        {
            DataSet dsFROIs = clsAP_AL_FROIs.GetDataToBindFROIsGrid(rdoAL_FROIsView.SelectedValue, LocationID, SortBy_AL, SortOrder_AL, PageNumber, PageSize);
            DataTable dtFROIs = dsFROIs.Tables[0];
            CtrlPagingAL_FROIsView.TotalRecords = (dsFROIs.Tables.Count >= 2) ? Convert.ToInt32(dsFROIs.Tables[1].Rows[0][0]) : 0;
            CtrlPagingAL_FROIsView.CurrentPage = (dsFROIs.Tables.Count >= 2) ? Convert.ToInt32(dsFROIs.Tables[1].Rows[0][2]) : 0;
            CtrlPagingAL_FROIsView.RecordsToBeDisplayed = dsFROIs.Tables[0].Rows.Count;
            CtrlPagingAL_FROIsView.SetPageNumbers();
            gvAP_AL_FROIsView.DataSource = dtFROIs;
            gvAP_AL_FROIsView.DataBind();
        }
        else
        {
            DataSet dsFROIs = clsAP_AL_FROIs.GetDataToBindFROIsGrid(rdoAL_FROIs.SelectedValue, LocationID, SortBy_AL, SortOrder_AL, PageNumber, PageSize);
            DataTable dtFROIs = dsFROIs.Tables[0];
            CtrlPagingAL_FROIs.TotalRecords = (dsFROIs.Tables.Count >= 2) ? Convert.ToInt32(dsFROIs.Tables[1].Rows[0][0]) : 0;
            CtrlPagingAL_FROIs.CurrentPage = (dsFROIs.Tables.Count >= 2) ? Convert.ToInt32(dsFROIs.Tables[1].Rows[0][2]) : 0;
            CtrlPagingAL_FROIs.RecordsToBeDisplayed = dsFROIs.Tables[0].Rows.Count;
            CtrlPagingAL_FROIs.SetPageNumbers();
            gvAP_AL_FROIs.DataSource = dtFROIs;
            gvAP_AL_FROIs.DataBind();
        }
    }

    /// <summary>
    /// Bind Details in edit mode
    /// </summary>
    private void BindDetailsForEdit_AL()
    {
        if (FK_AL_FR_ID == 0)
            if (Request.QueryString["Sect"] != null && Request.QueryString["Sect"].ToString() == "notes")
            {
                FK_AL_FR_ID = AL_RowIndex;
            }
        DataTable dtAL_FROIs_Detail = clsAP_AL_FROIs.GetAL_FROIs_DetailByPK(FK_AL_FR_ID).Tables[0];
        if (dtAL_FROIs_Detail != null && dtAL_FROIs_Detail.Rows.Count > 0)
        {
            if (PK_AP_AL_FROIs > 0)
                btnAL_ViewAuditTrail.Visible = true;
            else
                btnAL_ViewAuditTrail.Visible = false;
            #region "Incident Information"
            lblAL_Incident_Number.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["AL_FR_Number"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["AL_FR_Number"]) : "";
            txtAL_Date_Of_Loss.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Date_Of_Loss"]) != "" ? clsGeneral.FormatDBNullDateToDisplay(dtAL_FROIs_Detail.Rows[0]["Date_Of_Loss"].ToString()) : "";
            txtAL_Time_of_Loss.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Time_of_Loss"]) != "" ? dtAL_FROIs_Detail.Rows[0]["Time_of_Loss"].ToString() : "";
            txtAL_Description_Of_Loss.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Description_Of_Loss"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Description_Of_Loss"]) : "";
            if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Loss_offsite"])))
            {
                if ((Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Loss_offsite"])) == true)
                {
                    rdbAL_Offsite.Checked = true;
                    rdbAL_Onsite.Checked = false;
                }
                else
                {
                    rdbAL_Onsite.Checked = true;
                    rdbAL_Offsite.Checked = false;
                }
            }
            if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Were_Police_Notified"])))
                rdbAL_WerePoliceNotified.SelectedValue = Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Were_Police_Notified"]) == true ? "Y" : "N";
            if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Pedestrian_Involved"])))
                rdbAL_WerePedestriansInvolved.SelectedValue = Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Pedestrian_Involved"]) == true ? "Y" : "N";
            if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Property_Damage"])))
                rdbAL_propertydamage.SelectedValue = Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Property_Damage"]) == true ? "Y" : "N";
            if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Witnesses"])))
                rdbAL_Witnesses.SelectedValue = Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Witnesses"]) == true ? "Y" : "N";
            if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Security_Video_System"])))
                rdbAL_SecurityVideo.SelectedValue = Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Security_Video_System"]) == true ? "Y" : "N";

            txtAL_WeatherConditions.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Weather_Conditions"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Weather_Conditions"]) : "";
            txtAL_RoadConditions.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Road_Conditions"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Road_Conditions"]) : "";

            lblALClaim_Number.Text = dtAL_FROIs_Detail.Rows[0]["Origin_Claim_Number"].ToString() != "" ? dtAL_FROIs_Detail.Rows[0]["Origin_Claim_Number"].ToString() : "";
            if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Witnesses"])))
            {
                if ((Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Witnesses"])) == true)
                {
                    gvAL_Witnesses.DataSource = dtAL_FROIs_Detail;
                    gvAL_Witnesses.DataBind();
                }
            }
            else
            {
                gvAL_Witnesses.DataSource = null;
                gvAL_Witnesses.DataBind();
            }
            #endregion

            #region "Investigation"
            chkAL_3rd_Party_Vendor_Related_Theft.Checked = dtAL_FROIs_Detail.Rows[0]["Third_Party_Vendor_Related_Theft"].ToString() == "Y" ? true : false;
            chkAL_Access_Control_Failures.Checked = dtAL_FROIs_Detail.Rows[0]["Access_Control_Failures"].ToString() == "Y" ? true : false;
            chkAL_Breaking_and_Entering.Checked = dtAL_FROIs_Detail.Rows[0]["Breaking_And_Entering"].ToString() == "Y" ? true : false;


            chkAL_Burglar_Alarm_Failure.Checked = dtAL_FROIs_Detail.Rows[0]["Burglar_Alarm_Failure"].ToString() == "Y" ? true : false;
            chkAL_Camera_Dead_Spot.Checked = dtAL_FROIs_Detail.Rows[0]["Camera_Dead_Spot"].ToString() == "Y" ? true : false;
            chkAL_CCTV_Monitoring_Failure.Checked = dtAL_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure"].ToString() == "Y" ? true : false;

            chkAL_CCTV_Monitoring_Failure_byOperator.Checked = dtAL_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure_By_Operator"].ToString() == "Y" ? true : false;
            chkAL_Design_weakness_Property_Protection.Checked = dtAL_FROIs_Detail.Rows[0]["Design_Weakness_Property_Protection"].ToString() == "Y" ? true : false;
            chkAL_Environmental_Obstruction_ConditionCamera.Checked = dtAL_FROIs_Detail.Rows[0]["Environmental_Obstruction_and_or_Condition_Camera"].ToString() == "Y" ? true : false;

            chkAL_Failure_to_ReportLate_Report.Checked = dtAL_FROIs_Detail.Rows[0]["Failure_to_Report_and_or_Late_Report"].ToString() == "Y" ? true : false;
            chkAL_Key_Swap.Checked = dtAL_FROIs_Detail.Rows[0]["Key_Swap"].ToString() == "Y" ? true : false;
            chkAL_Lighting_Deficiencies.Checked = dtAL_FROIs_Detail.Rows[0]["Lighting_Deficiencies"].ToString() == "Y" ? true : false;

            chkAL_LockBox_Not_Properly_Secured.Checked = dtAL_FROIs_Detail.Rows[0]["Lock_Box_Not_Properly_Secured"].ToString() == "Y" ? true : false;
            chkAL_Negligence_Lackof_Key_Control_Program_Unattended_Keys.Checked = dtAL_FROIs_Detail.Rows[0]["Negligence_Lack_of_key_Control_Program_Unattended_Keys"].ToString() == "Y" ? true : false;
            chkAL_NonPermissible_User_of_TakingVehicle.Checked = dtAL_FROIs_Detail.Rows[0]["Non_Permissible_User_of_Taking_Vehicle"].ToString() == "Y" ? true : false;

            chkAL_Power_Outage.Checked = dtAL_FROIs_Detail.Rows[0]["Power_Outage"].ToString() == "Y" ? true : false;
            chkAL_Security_Guard_Failure.Checked = dtAL_FROIs_Detail.Rows[0]["Security_Guard_Failure"].ToString() == "Y" ? true : false;
            chkAL_Stolen_Id.Checked = dtAL_FROIs_Detail.Rows[0]["Stolen_Id"].ToString() == "Y" ? true : false;

            chkAL_Theft_by_Deception.Checked = dtAL_FROIs_Detail.Rows[0]["Theft_By_Deception"].ToString() == "Y" ? true : false;
            chkAL_Unauthorized_Building_Entry_Forcible.Checked = dtAL_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Forcible"].ToString() == "Y" ? true : false;
            chkAL_Unauthorized_Building_Entry_Unlocked.Checked = dtAL_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Unlocked"].ToString() == "Y" ? true : false;

            chkAL_Unauthorized_Vehicle_Entry_Forcible.Checked = dtAL_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Forcible"].ToString() == "Y" ? true : false;
            chkAL_Unauthorized_Vehicle_Entry_Unlocked.Checked = dtAL_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Unlocked"].ToString() == "Y" ? true : false;
            chkAL_Vehicle_Takenby_Tow_Truck.Checked = dtAL_FROIs_Detail.Rows[0]["Vehicle_Taken_By_Tow_Truck"].ToString() == "Y" ? true : false;

            chkAL_Weather_Related_DamageLoss.Checked = dtAL_FROIs_Detail.Rows[0]["Weather_Related_Damage_and_or_Loss"].ToString() == "Y" ? true : false;
            chkAL_Other_Describe.Checked = dtAL_FROIs_Detail.Rows[0]["Other_Describe"].ToString() == "Y" ? true : false;

            txtAL_Investigation_Finding.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"]) : "";


            #endregion

            #region "FROI Review"
            txtAL_Root_Cause.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Root_Cause"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Root_Cause"]) : "";
            txtAL_Incident_Prevention.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Incident_Prevention"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Incident_Prevention"]) : "";
            txtAL_Person_Tasked.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Person_Tasked"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Person_Tasked"]) : "";

            txtAL_Target_Date_of_Completion.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Target_Date_of_Completion"]) != "" ? clsGeneral.FormatDBNullDateToDisplay(dtAL_FROIs_Detail.Rows[0]["Target_Date_of_Completion"].ToString()) : "";
            txtAL_Status_Due_On.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Status_Due_On"]) != "" ? clsGeneral.FormatDBNullDateToDisplay(dtAL_FROIs_Detail.Rows[0]["Status_Due_On"].ToString()) : "";

            txtAL_Comments.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Comments"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Comments"]) : "";
            txtAL_Financial_Loss.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Financial_Loss"]) != "" ? clsGeneral.GetStringValue(dtAL_FROIs_Detail.Rows[0]["Financial_Loss"].ToString()) : "";
            txtAL_Recovery.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Recovery"]) != "" ? clsGeneral.GetStringValue(dtAL_FROIs_Detail.Rows[0]["Recovery"].ToString()) : "";
            drpAL_Item_Status.SelectedValue = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Item_Status"]) == "O" ? "1" : Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Item_Status"]) == "C" ? "2" : "0";
            #endregion

            #region "Notes"
            if (!string.IsNullOrEmpty(AP_AL_FROIs_CommandArgs))
            {
                string[] arg = new string[4];
                arg = AP_AL_FROIs_CommandArgs.Split(';');
                FK_AL_FR_ID = Convert.ToDecimal(arg[0]);
                PK_AP_AL_FROIs = Convert.ToDecimal(arg[1]);
                clsSession.First_Report_Wizard_ID = Convert.ToInt32(arg[2]);
                PK_Auto_Loss_Claims_ID = Convert.ToDecimal(arg[3]);
                Origin_Claim_Number = Convert.ToString(arg[4]);
            }

            ucAdjusterNotes.ClaimID = (long)PK_Auto_Loss_Claims_ID;
            ucAdjusterNotes.ClaimNumber = Origin_Claim_Number;
            ucAdjusterNotes.BindGridNotes(Origin_Claim_Number);

            if (PK_AP_AL_FROIs > 0)
            {
                ctrlAPNotes_AL.Location_ID = Convert.ToInt32(LocationID);
                ctrlAPNotes_AL.PK_AL_CI_ID = Convert.ToInt32(PK_Auto_Loss_Claims_ID);
                ctrlAPNotes_AL.CurrentClaimType = "AP_AL_FROIs";
                ctrlAPNotes_AL.BindGridSonicNotes(PK_AP_AL_FROIs, "AP_AL_FROIs");
            }
            else
            {
                ctrlAPNotes_AL.BindEmptyGrid();
            }

            #endregion
        }

    }

    /// <summary>
    /// Bind Details in view mode
    /// </summary>
    private void BindDetailsForView_AL()
    {
        if (FK_AL_FR_ID == 0)
            if (Request.QueryString["Sect"] != null && Request.QueryString["Sect"].ToString() == "notes")
            {
                FK_AL_FR_ID = AL_RowIndex;
            }

        DataTable dtAL_FROIs_Detail = clsAP_AL_FROIs.GetAL_FROIs_DetailByPK(FK_AL_FR_ID).Tables[0];
        if (dtAL_FROIs_Detail != null && dtAL_FROIs_Detail.Rows.Count > 0)
        {
            if (PK_AP_AL_FROIs > 0)
                btnAL_ViewAuditTrailView.Visible = true;
            else
                btnAL_ViewAuditTrailView.Visible = false;
            #region "Incident Information"
            lblAL_Incident_NumberView.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["AL_FR_Number"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["AL_FR_Number"]) : "";
            lblAL_Date_of_Loss.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Date_Of_Loss"]) != "" ? clsGeneral.FormatDBNullDateToDisplay(dtAL_FROIs_Detail.Rows[0]["Date_Of_Loss"].ToString()) : "";
            lblAL_Time_of_Loss.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Time_of_Loss"]) != "" ? dtAL_FROIs_Detail.Rows[0]["Time_of_Loss"].ToString() : "";
            lblDescription_Of_Loss.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Description_Of_Loss"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Description_Of_Loss"]) : "";
            if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Loss_offsite"])))
            {
                if ((Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Loss_offsite"])) == true)
                {
                    rdbAL_OffsiteView.Checked = true;
                    rdbAL_OnsiteView.Checked = false;
                }
                else
                {
                    rdbAL_OnsiteView.Checked = true;
                    rdbAL_OffsiteView.Checked = false;
                }
            }
            if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Were_Police_Notified"])))
                rdbAL_WerePoliceNotifiedView.SelectedValue = Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Were_Police_Notified"]) == true ? "Y" : "N";
            if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Pedestrian_Involved"])))
                rdbAL_WerePedestriansInvolvedView.SelectedValue = Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Pedestrian_Involved"]) == true ? "Y" : "N";
            if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Property_Damage"])))
                rdbAL_propertydamageView.SelectedValue = Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Property_Damage"]) == true ? "Y" : "N";
            if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Witnesses"])))
                rdbAL_WitnessesView.SelectedValue = Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Witnesses"]) == true ? "Y" : "N";
            if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Security_Video_System"])))
                rdbAL_SecurityVideoView.SelectedValue = Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Security_Video_System"]) == true ? "Y" : "N";

            lblWeatherConditions.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Weather_Conditions"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Weather_Conditions"]) : "";
            lblRoadConditions.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Road_Conditions"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Road_Conditions"]) : "";
            lblALClaim_NumberView.Text = dtAL_FROIs_Detail.Rows[0]["Origin_Claim_Number"].ToString() != "" ? dtAL_FROIs_Detail.Rows[0]["Origin_Claim_Number"].ToString() : "";

            if (!string.IsNullOrEmpty(Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Witnesses"])))
            {
                if ((Convert.ToBoolean(dtAL_FROIs_Detail.Rows[0]["Witnesses"])) == true)
                {
                    gvAL_WitnessesView.DataSource = dtAL_FROIs_Detail;
                    gvAL_WitnessesView.DataBind();
                }
            }
            else
            {
                gvAL_WitnessesView.DataSource = null;
                gvAL_WitnessesView.DataBind();
            }
            #endregion

            #region "Investigation"
            chkAL_3rd_Party_Vendor_Related_TheftView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Third_Party_Vendor_Related_Theft"]) == "Y" ? true : false;
            chkAL_Access_Control_FailuresView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Access_Control_Failures"]) == "Y" ? true : false;
            chkAL_Breaking_and_EnteringView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Breaking_And_Entering"]) == "Y" ? true : false;


            chkAL_Burglar_Alarm_FailureView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Burglar_Alarm_Failure"]) == "Y" ? true : false;
            chkAL_Camera_Dead_SpotView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Camera_Dead_Spot"]) == "Y" ? true : false;
            chkAL_CCTV_Monitoring_FailureView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure"]) == "Y" ? true : false;

            chkAL_CCTV_Monitoring_Failure_byOperatorView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["CCTV_Monitoring_Failure_By_Operator"]) == "Y" ? true : false;
            chkAL_Design_weakness_Property_ProtectionView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Design_Weakness_Property_Protection"]) == "Y" ? true : false;
            chkAL_Environmental_Obstruction_ConditionCameraView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Environmental_Obstruction_and_or_Condition_Camera"]) == "Y" ? true : false;

            chkAL_Failure_to_ReportLate_ReportView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Failure_to_Report_and_or_Late_Report"]) == "Y" ? true : false;
            chkAL_Key_SwapView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Key_Swap"]) == "Y" ? true : false;
            chkAL_Lighting_DeficienciesView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Lighting_Deficiencies"]) == "Y" ? true : false;

            chkAL_LockBox_Not_Properly_SecuredView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Lock_Box_Not_Properly_Secured"]) == "Y" ? true : false;
            chkAL_Negligence_Lackof_Key_Control_Program_Unattended_KeysView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Negligence_Lack_of_key_Control_Program_Unattended_Keys"]) == "Y" ? true : false;
            chkAL_NonPermissible_User_of_TakingVehicleView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Non_Permissible_User_of_Taking_Vehicle"]) == "Y" ? true : false;

            chkAL_Power_OutageView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Power_Outage"]) == "Y" ? true : false;
            chkAL_Security_Guard_FailureView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Security_Guard_Failure"]) == "Y" ? true : false;
            chkAL_Stolen_IdView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Stolen_Id"]) == "Y" ? true : false;

            chkAL_Theft_by_DeceptionView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Theft_By_Deception"]) == "Y" ? true : false;
            chkAL_Unauthorized_Building_Entry_ForcibleView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Forcible"]) == "Y" ? true : false;
            chkAL_Unauthorized_Building_Entry_UnlockedView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Unauthorized_Building_Entry_Unlocked"]) == "Y" ? true : false;

            chkAL_Unauthorized_Vehicle_Entry_ForcibleView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Forcible"]) == "Y" ? true : false;
            chkAL_Unauthorized_Vehicle_Entry_UnlockedView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Unauthorized_Vehicle_Entry_Unlocked"]) == "Y" ? true : false;
            chkAL_Vehicle_Takenby_Tow_TruckView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Vehicle_Taken_By_Tow_Truck"]) == "Y" ? true : false;

            chkAL_Weather_Related_DamageLossView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Weather_Related_Damage_and_or_Loss"]) == "Y" ? true : false;
            chkAL_Other_DescribeView.Checked = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Other_Describe"]) == "Y" ? true : false;

            lblAL_Investigation_Finding.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Investigation_Finding_Other_Description"]) : "";


            #endregion

            #region "FROI Review"
            lblAL_Root_Cause.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Root_Cause"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Root_Cause"]) : "";
            lblAL_Incident_Prevention.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Incident_Prevention"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Incident_Prevention"]) : "";
            lblAL_Person_Tasked.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Person_Tasked"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Person_Tasked"]) : "";

            lblAL_Target_Date_of_Completion.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Target_Date_of_Completion"]) != "" ? clsGeneral.FormatDBNullDateToDisplay(dtAL_FROIs_Detail.Rows[0]["Target_Date_of_Completion"].ToString()) : "";
            lblAL_Status_Due_On.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Status_Due_On"]) != "" ? clsGeneral.FormatDBNullDateToDisplay(dtAL_FROIs_Detail.Rows[0]["Status_Due_On"].ToString()) : "";

            lblAL_Comments.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Comments"]) != "" ? Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Comments"]) : "";
            lblAL_Financial_Loss.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Financial_Loss"]) != "" ? clsGeneral.GetStringValue(dtAL_FROIs_Detail.Rows[0]["Financial_Loss"].ToString()) : "";
            lblAL_Recovery.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Recovery"]) != "" ? clsGeneral.GetStringValue(dtAL_FROIs_Detail.Rows[0]["Recovery"].ToString()) : "";
            lblAL_Item_Status.Text = Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Item_Status"]) == "O" ? "Open" : Convert.ToString(dtAL_FROIs_Detail.Rows[0]["Item_Status"]) == "C" ? "Close" : "";
            #endregion

            #region "Notes"
            if (!string.IsNullOrEmpty(AP_AL_FROIs_CommandArgs))
            {
                string[] arg = new string[4];
                arg = AP_AL_FROIs_CommandArgs.Split(';');
                FK_AL_FR_ID = Convert.ToDecimal(arg[0]);
                PK_AP_AL_FROIs = Convert.ToDecimal(arg[1]);
                clsSession.First_Report_Wizard_ID = Convert.ToInt32(arg[2]);
                PK_Auto_Loss_Claims_ID = Convert.ToDecimal(arg[3]);
                Origin_Claim_Number = Convert.ToString(arg[4]);
            }

            ucAdjusterNotesView.ClaimID = (long)PK_Auto_Loss_Claims_ID;
            ucAdjusterNotesView.ClaimNumber = Origin_Claim_Number;
            ucAdjusterNotesView.BindGridNotes(Origin_Claim_Number);

            if (PK_AP_AL_FROIs > 0)
            {
                ctrlAPNotes_ALView.Location_ID = Convert.ToInt32(LocationID);
                ctrlAPNotes_ALView.PK_AL_CI_ID = Convert.ToInt32(PK_Auto_Loss_Claims_ID);
                ctrlAPNotes_ALView.CurrentClaimType = "AP_AL_FROIs";
                ctrlAPNotes_ALView.BindGridSonicNotes(PK_AP_AL_FROIs, "AP_AL_FROIs");
            }
            else
            {
                ctrlAPNotes_ALView.BindEmptyGrid();
            }
            #endregion


        }


    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage_AL(GridViewRow headerRow)
    {
        Int32 iCol = GetSortColumnIndex_AL(SortBy_AL);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder_AL = SortOrder_AL == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

        // check for the order and
        // set the images accordingly 
        if (SortDirection.Ascending.ToString() == strSortOrder_AL)
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }

        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);
    }

    /// <summary>
    /// Returns the index of the column which contains perticular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex_AL(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        if (StrOperation == "view")
        {
            foreach (DataControlField field in gvAP_AL_FROIsView.Columns)
            {
                //check Sort Expression value
                if (field.SortExpression.ToString() == strSortExp)
                {
                    //nRet = gvEventView.Columns.IndexOf(field);
                    nRet = gvAP_AL_FROIsView.Columns.IndexOf(field);
                }
            }
            return nRet;
        }
        else
        {
            foreach (DataControlField field in gvAP_AL_FROIs.Columns)
            {
                //check Sort Expression value
                if (field.SortExpression.ToString() == strSortExp)
                {
                    //nRet = gvEvent.Columns.IndexOf(field);
                    nRet = gvAP_AL_FROIs.Columns.IndexOf(field);
                }
            }
            return nRet;
        }
    }

    #endregion

    #region "Cal - Atlantic"

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEditForCal_Atlantic()
    {
        clsAP_Cal_Atlantic objAP_Cal_Atlantic = new clsAP_Cal_Atlantic(PK_AP_Cal_Atlantic);
        if (PK_AP_Cal_Atlantic > 0)
            btnCal_AtlanticAudit_Trail.Visible = true;
        else
            btnCal_AtlanticAudit_Trail.Visible = false;
        //FK_Event = Convert.ToDecimal(objAP_Cal_Atlantic.FK_Event);

        txtPotential_Risk.Text = objAP_Cal_Atlantic.Potential_Risk;
        txtAction_Taken.Text = objAP_Cal_Atlantic.Action_Taken;
        rdoWas_Law_Enforcement_Notified.SelectedValue = objAP_Cal_Atlantic.Was_Law_Enforcement_Notified;
        txtOfficer_Name.Text = objAP_Cal_Atlantic.Officer_Name;
        txtPhone_Number.Text = objAP_Cal_Atlantic.Phone_Number;
        txtEMail.Text = objAP_Cal_Atlantic.EMail;
        txtLaw_Enforcement_Agency.Text = objAP_Cal_Atlantic.Law_Enforcement_Agency;
        txtLocation.Text = objAP_Cal_Atlantic.Location;
        txtPolice_Report_Number.Text = objAP_Cal_Atlantic.Police_Report_Number;
        txtNotes.Text = objAP_Cal_Atlantic.Notes;
        txtCalRoot_Cause.Text = objAP_Cal_Atlantic.Root_Cause;
        txtevent_Prevention.Text = objAP_Cal_Atlantic.Event_Prevention;
        txtCalPerson_Tasked.Text = objAP_Cal_Atlantic.Person_Tasked;
        txtCalTarget_Date_of_Completion.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Cal_Atlantic.Target_Date_of_Completion);
        txtCalStatus_Due_On.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Cal_Atlantic.Status_Due_On);
        txtCalComments.Text = objAP_Cal_Atlantic.Comments;
        txtCalFinancial_Loss.Text = clsGeneral.GetStringValue(objAP_Cal_Atlantic.Financial_Loss);
        txtCalRecovery.Text = clsGeneral.GetStringValue(objAP_Cal_Atlantic.Recovery);
        if (objAP_Cal_Atlantic.Item_Status != null && objAP_Cal_Atlantic.Item_Status != string.Empty)
        {
            ddlCalAtlantic_Item_Status.SelectedValue = objAP_Cal_Atlantic.Item_Status;
        }


        if (objAP_Cal_Atlantic.Auto_Liability == "Y")
        {
            rblInsuranceClaimType.SelectedValue = "Auto Liability";
            bindFROIDropdown("AL");
        }
        else if (objAP_Cal_Atlantic.DPD == "Y")
        {
            rblInsuranceClaimType.SelectedValue = "DPD";
            bindFROIDropdown("DPD");
        }
        else if (objAP_Cal_Atlantic.Premises_Liability == "Y")
        {
            rblInsuranceClaimType.SelectedValue = "Premises Liability";
            bindFROIDropdown("PL");
        }
        else if (objAP_Cal_Atlantic.Property_Damage == "Y")
        {
            rblInsuranceClaimType.SelectedValue = "Property Damage";
            bindFROIDropdown("Property");
        }

        if (ddlAssociateFROINo.Items.Contains(ddlAssociateFROINo.Items.FindByText(objAP_Cal_Atlantic.Associated_FROI_Number)))
            ddlAssociateFROINo.Items.FindByText(objAP_Cal_Atlantic.Associated_FROI_Number).Selected = true;
        if (ddlAssociatedClaimNo.Items.Contains(ddlAssociatedClaimNo.Items.FindByText(objAP_Cal_Atlantic.Associated_Claim_Number)))
            ddlAssociatedClaimNo.Items.FindByText(objAP_Cal_Atlantic.Associated_Claim_Number).Selected = true;

        //chkAuto_Liability.Checked = objAP_Cal_Atlantic.Auto_Liability == "Y" ? true : false;
        //chkDPD.Checked = objAP_Cal_Atlantic.DPD == "Y" ? true : false;
        //chkPremises_Liability.Checked = objAP_Cal_Atlantic.Premises_Liability == "Y" ? true : false;
        //chkProperty_Damage.Checked = objAP_Cal_Atlantic.Property_Damage == "Y" ? true : false;


    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForViewForCal_Atlantic()
    {
        //dvCalAtlanticSave.Visible = false;
        dvCal_Grid.Visible = true;
        if (PK_AP_Cal_Atlantic > 0)
            btnCal_AtlanticAudit_TrailView.Visible = true;
        else
            btnCal_AtlanticAudit_TrailView.Visible = false;
        clsAP_Cal_Atlantic objAP_Cal_Atlantic = new clsAP_Cal_Atlantic(PK_AP_Cal_Atlantic);
        lblPotential_Risk.Text = objAP_Cal_Atlantic.Potential_Risk;
        lblAction_Taken.Text = objAP_Cal_Atlantic.Action_Taken;
        if (objAP_Cal_Atlantic.Was_Law_Enforcement_Notified != null)
            lblWas_Law_Enforcement_Notified.Text = objAP_Cal_Atlantic.Was_Law_Enforcement_Notified == "Y" ? "Yes" : "No";
        else
            lblWas_Law_Enforcement_Notified.Text = "";
        lblOfficer_Name.Text = objAP_Cal_Atlantic.Officer_Name;
        lblPhone_Number.Text = objAP_Cal_Atlantic.Phone_Number;
        lblEMail.Text = objAP_Cal_Atlantic.EMail;
        lblLaw_Enforcement_Agency.Text = objAP_Cal_Atlantic.Law_Enforcement_Agency;
        lblLocation.Text = objAP_Cal_Atlantic.Location;
        lblPolice_Report_Number.Text = objAP_Cal_Atlantic.Police_Report_Number;
        lblNotes.Text = objAP_Cal_Atlantic.Notes;
        lblRoot_Cause.Text = objAP_Cal_Atlantic.Root_Cause;
        lblEvent_Prevention.Text = objAP_Cal_Atlantic.Event_Prevention;
        lblTask_Prevent_Reoccurance.Text = objAP_Cal_Atlantic.Person_Tasked;
        lblCal_Target_Date_of_Completion.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Cal_Atlantic.Target_Date_of_Completion);
        lblCal_Status_Due_On.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Cal_Atlantic.Status_Due_On);
        lblComments.Text = objAP_Cal_Atlantic.Comments;
        lblCal_Financial_Loss.Text = clsGeneral.GetStringValue(objAP_Cal_Atlantic.Financial_Loss);
        lblCal_Recovery.Text = clsGeneral.GetStringValue(objAP_Cal_Atlantic.Recovery);
        if (objAP_Cal_Atlantic.Item_Status != null)
            lblCal_Item_Status.Text = objAP_Cal_Atlantic.Item_Status == "O" ? "Open" : "Closed";
        else
            lblCal_Item_Status.Text = "";
        lblAssociatedFROINo.Text = objAP_Cal_Atlantic.Associated_FROI_Number;
        lblAssocaitedClaimNo.Text = objAP_Cal_Atlantic.Associated_Claim_Number;

        if (objAP_Cal_Atlantic.Auto_Liability == "Y")
        {
            rblInsuranceClaimTypeView.SelectedValue = "Auto Liability";

        }
        else if (objAP_Cal_Atlantic.DPD == "Y")
        {
            rblInsuranceClaimTypeView.SelectedValue = "DPD";

        }
        else if (objAP_Cal_Atlantic.Premises_Liability == "Y")
        {
            rblInsuranceClaimTypeView.SelectedValue = "Premises Liability";

        }
        else if (objAP_Cal_Atlantic.Property_Damage == "Y")
        {
            rblInsuranceClaimTypeView.SelectedValue = "Property Damage";

        }

        //chkAuto_LiabilityView.Checked = objAP_Cal_Atlantic.Auto_Liability == "Y" ? true : false;
        //chkDPDView.Checked = objAP_Cal_Atlantic.DPD == "Y" ? true : false;
        //chkPremises_LiabilityView.Checked = objAP_Cal_Atlantic.Premises_Liability == "Y" ? true : false;
        //chkProperty_DamageView.Checked = objAP_Cal_Atlantic.Property_Damage == "Y" ? true : false;


    }

    /// Save Values to Database
    /// </summary>
    private void SaveCal_AtlanticData()
    {
        clsAP_Cal_Atlantic objAP_Cal_Atlantic = new clsAP_Cal_Atlantic();
        objAP_Cal_Atlantic.FK_LU_Location = LocationID;
        objAP_Cal_Atlantic.FK_Event = FK_Event;

        objAP_Cal_Atlantic.PK_AP_Cal_Atlantic = PK_AP_Cal_Atlantic;
        objAP_Cal_Atlantic.Potential_Risk = txtPotential_Risk.Text.Trim();
        objAP_Cal_Atlantic.Action_Taken = txtAction_Taken.Text.Trim();
        objAP_Cal_Atlantic.Was_Law_Enforcement_Notified = rdoWas_Law_Enforcement_Notified.SelectedValue;
        objAP_Cal_Atlantic.Officer_Name = txtOfficer_Name.Text.Trim();
        objAP_Cal_Atlantic.Phone_Number = txtPhone_Number.Text.Trim();
        objAP_Cal_Atlantic.EMail = txtEMail.Text.Trim();
        objAP_Cal_Atlantic.Law_Enforcement_Agency = txtLaw_Enforcement_Agency.Text.Trim();
        objAP_Cal_Atlantic.Location = txtLocation.Text.Trim();
        objAP_Cal_Atlantic.Police_Report_Number = txtPolice_Report_Number.Text.Trim();
        objAP_Cal_Atlantic.Notes = txtNotes.Text.Trim();
        objAP_Cal_Atlantic.Root_Cause = txtCalRoot_Cause.Text.Trim();
        objAP_Cal_Atlantic.Event_Prevention = txtevent_Prevention.Text.Trim();
        objAP_Cal_Atlantic.Person_Tasked = txtCalPerson_Tasked.Text.Trim();
        objAP_Cal_Atlantic.Target_Date_of_Completion = clsGeneral.FormatNullDateToStore(txtCalTarget_Date_of_Completion.Text);
        objAP_Cal_Atlantic.Status_Due_On = clsGeneral.FormatNullDateToStore(txtCalStatus_Due_On.Text);
        objAP_Cal_Atlantic.Comments = txtCalComments.Text.Trim();
        objAP_Cal_Atlantic.Associated_FROI_Number = ddlAssociateFROINo.SelectedIndex > 0 ? ddlAssociateFROINo.SelectedItem.Text : "";
        objAP_Cal_Atlantic.Associated_Claim_Number = ddlAssociatedClaimNo.SelectedIndex > 0 ? ddlAssociatedClaimNo.SelectedItem.Text : "";

        if (txtCalFinancial_Loss.Text != "") objAP_Cal_Atlantic.Financial_Loss = clsGeneral.GetDecimalValue(txtCalFinancial_Loss);
        if (txtCalRecovery.Text != "") objAP_Cal_Atlantic.Recovery = clsGeneral.GetDecimalValue(txtCalRecovery);
        if (ddlCalAtlantic_Item_Status.SelectedIndex > 0)
        {
            objAP_Cal_Atlantic.Item_Status = ddlCalAtlantic_Item_Status.SelectedValue;
        }


        switch (rblInsuranceClaimType.SelectedValue)
        {
            case "Auto Liability":
                objAP_Cal_Atlantic.Auto_Liability = "Y";
                objAP_Cal_Atlantic.DPD = "N";
                objAP_Cal_Atlantic.Premises_Liability = "N";
                objAP_Cal_Atlantic.Property_Damage = "N";
                break;
            case "DPD":
                objAP_Cal_Atlantic.Auto_Liability = "N";
                objAP_Cal_Atlantic.DPD = "Y";
                objAP_Cal_Atlantic.Premises_Liability = "N";
                objAP_Cal_Atlantic.Property_Damage = "N";
                break;
            case "Premises Liability":
                objAP_Cal_Atlantic.Auto_Liability = "N";
                objAP_Cal_Atlantic.DPD = "N";
                objAP_Cal_Atlantic.Premises_Liability = "Y";
                objAP_Cal_Atlantic.Property_Damage = "N";
                break;
            case "Property Damage":
                objAP_Cal_Atlantic.Auto_Liability = "N";
                objAP_Cal_Atlantic.DPD = "N";
                objAP_Cal_Atlantic.Premises_Liability = "N";
                objAP_Cal_Atlantic.Property_Damage = "Y";
                break;
        }

        //objAP_Cal_Atlantic.Auto_Liability = chkAuto_Liability.Checked ? "Y" : "N"; ;
        //objAP_Cal_Atlantic.DPD = chkDPD.Checked ? "Y" : "N"; ;
        //objAP_Cal_Atlantic.Premises_Liability = chkPremises_Liability.Checked ? "Y" : "N"; ;
        //objAP_Cal_Atlantic.Property_Damage = chkProperty_Damage.Checked ? "Y" : "N"; ;
        objAP_Cal_Atlantic.Update_Date = DateTime.Now;
        objAP_Cal_Atlantic.Updated_By = clsSession.UserID;

        if (PK_AP_Cal_Atlantic > 0)
        {
            objAP_Cal_Atlantic.Update();
        }
        else
        {
            PK_AP_Cal_Atlantic = objAP_Cal_Atlantic.Insert();
        }
        if (PK_AP_Cal_Atlantic > 0)
            btnCal_AtlanticAudit_Trail.Visible = true;
        else
            btnCal_AtlanticAudit_Trail.Visible = false;
        BindCalAtlanticEventGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);

    }

    /// <summary>
    /// Bind Event Information
    /// </summary>
    private void BindEvent()
    {
        if (FK_Event > 0)
        {
            DataTable dtEvent = clsAP_Cal_Atlantic.SelectAP_CalAtlanticPKByFKEvent(FK_Event).Tables[0];
            lnkbtnViewCalatlanticData.Enabled = true;
            lnkbtnViewCalatlanticDataView.Enabled = true;
            if (StrOperation == "view")
            {
                lblDateOfEvent.Text = clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Occurence_Date"].ToString());
                if (dtEvent.Rows[0]["FK_LU_Event_Type"] != DBNull.Value && dtEvent.Rows[0]["FK_LU_Event_Type"] != "")
                    lblTypeOfEvent.Text = new clsLU_Event_Type(Convert.ToDecimal(dtEvent.Rows[0]["FK_LU_Event_Type"].ToString())).Fld_Desc;
                else
                    lblTypeOfEvent.Text = "";

                lblEventReportDate.Text = clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Report_Date"].ToString());
                lblInvestigationReportDate.Text = clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Investigation_Report_Date"].ToString());
                if (dtEvent.Rows[0]["FK_LU_Event_Description"] != null && Convert.ToString(dtEvent.Rows[0]["FK_LU_Event_Description"]) != "")
                    lblFK_LU_Event_Description.Text = new clsLU_Event_Description((decimal)dtEvent.Rows[0]["FK_LU_Event_Description"]).Fld_Desc;
                else
                    lblFK_LU_Event_Description.Text = "";
                lblDate_Opened.Text = clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Date_Opened"].ToString());
                lblDateSendToClient.Text = clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Date_Sent"].ToString());
                lblEventOccuranceDate.Text = clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Occurence_Date"].ToString());

            }
            else
            {
                txtDateOfEvent.Text = clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Occurence_Date"].ToString());
                if (dtEvent.Rows[0]["FK_LU_Event_Type"] != DBNull.Value && dtEvent.Rows[0]["FK_LU_Event_Type"] != "")
                    txtTypeofEvent.Text = new clsLU_Event_Type(Convert.ToDecimal(dtEvent.Rows[0]["FK_LU_Event_Type"].ToString())).Fld_Desc;
                else
                    txtTypeofEvent.Text = "";
                txtEventReportDate.Text = clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Report_Date"].ToString());
                txtInvestigationReportDate.Text = clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Investigation_Report_Date"].ToString());
                if (dtEvent.Rows[0]["FK_LU_Event_Description"] != null && Convert.ToString(dtEvent.Rows[0]["FK_LU_Event_Description"]) != "")
                    txtFK_LU_Event_Description.Text = new clsLU_Event_Description((decimal)dtEvent.Rows[0]["FK_LU_Event_Description"]).Fld_Desc;
                else
                    txtFK_LU_Event_Description.Text = "";
                txtDate_Opened.Text = clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Date_Opened"].ToString());
                txtDateSendToClient.Text = clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Date_Sent"].ToString());
                txtEventOccuranceDate.Text = clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Occurence_Date"].ToString());
            }

            PK_AP_Cal_Atlantic = Convert.ToDecimal(dtEvent.Rows[0]["PK_AP_Cal_Atlantic"].ToString());


            if (StrOperation == "view" || StrOperation == string.Empty)
            {

                // Bind Controls
                BindDetailsForViewForCal_Atlantic();
            }
            else
            {
                // Bind Controls
                BindDetailsForEditForCal_Atlantic();
            }

        }

    }

    /// <summary>
    /// Bind Froi and Claim dropdown as per insurance type
    /// </summary>
    /// <param name="strTableofInsuranceClaim"></param>
    private void bindFROIDropdown(string strTableofInsuranceClaim)
    {
        if (txtDateOfEvent.Text != "")
        {
            DataTable dt = clsAP_Cal_Atlantic.SelectFROIFromInsuranceClaimType(strTableofInsuranceClaim, Convert.ToDateTime(txtDateOfEvent.Text)).Tables[0];
            ddlAssociateFROINo.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                ddlAssociateFROINo.Items.Clear();
                ddlAssociateFROINo.DataTextField = "Number";
                ddlAssociateFROINo.DataValueField = "ID";
                ddlAssociateFROINo.DataSource = dt;
                ddlAssociateFROINo.DataBind();
            }
            ddlAssociateFROINo.Items.Insert(0, new ListItem("-- Select --", "0"));

            dt = clsAP_Cal_Atlantic.SelectClaimNoInsuranceClaimType(strTableofInsuranceClaim, Convert.ToDateTime(txtDateOfEvent.Text)).Tables[0];
            ddlAssociatedClaimNo.Items.Clear();
            if (dt.Rows.Count > 0)
            {

                ddlAssociatedClaimNo.DataTextField = "Claim_No";
                ddlAssociatedClaimNo.DataValueField = "ID";
                ddlAssociatedClaimNo.DataSource = dt;
                ddlAssociatedClaimNo.DataBind();

            }
            ddlAssociatedClaimNo.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        else
        {
            ddlAssociateFROINo.Items.Clear();
            ddlAssociatedClaimNo.Items.Clear();
            ddlAssociateFROINo.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlAssociatedClaimNo.Items.Insert(0, new ListItem("-- Select --", "0"));
        }

    }

    /// <summary>
    ///  Add Sort Image as per Current sort 
    /// </summary>
    /// <param name="headerRow"></param>
    private void AddSortImage_CalAtlantic(GridViewRow headerRow)
    {
        Int32 iCol = GetSortColumnIndex_CalAtlantic(_SortBy_CalAtlantic);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder_AL = _SortOrder_CalAtlantic == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

        // check for the order and
        // set the images accordingly 
        if (SortDirection.Ascending.ToString() == strSortOrder_AL)
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }

        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);
    }

    /// <summary>
    /// Returns the index of the column which contains perticular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex_CalAtlantic(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        if (StrOperation == "view")
        {
            foreach (DataControlField field in gvEventView.Columns)
            {
                //check Sort Expression value
                if (field.SortExpression.ToString() == strSortExp)
                {
                    nRet = gvEventView.Columns.IndexOf(field);
                }
            }
            return nRet;
        }
        else
        {
            foreach (DataControlField field in gvEvent.Columns)
            {
                //check Sort Expression value
                if (field.SortExpression.ToString() == strSortExp)
                {
                    nRet = gvEvent.Columns.IndexOf(field);
                }
            }
            return nRet;
        }


    }

    #endregion

    #region "Fraud Events"

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit_FraudEvents()
    {
        BindDropDowns();

        clsAP_Fraud_Events objAP_Fraud_Events = new clsAP_Fraud_Events(PK_AP_Fraud_Events);
        txtFraudNumber.Text = objAP_Fraud_Events.Fraud_Number;
        txtExpPeriodBeginDate.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Exposure_Period_Begin_Date);
        txtExpoPeriodEndDate.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Exposure_Period_End_Date);
        txtReportedTo.Text = objAP_Fraud_Events.Reported_To;
        txtReportedDate.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Reported_Date);
        txtDesciptionofEvent.Text = objAP_Fraud_Events.Description_of_Event;
        txtOther_Notification_Description.Text = objAP_Fraud_Events.Other_Notification_Description;
        txtInternal_Review_Purification_Notes.Text = objAP_Fraud_Events.Internal_Review_Purification_Notes;
        txtFraud_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Fraud_Date);
        txtHR_Assignment.Text = objAP_Fraud_Events.HR_Assignment;
        txtHR_Associate_Contacted.Text = objAP_Fraud_Events.HR_Associate_Contacted;
        txtDate_HR_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_HR_Assigned);
        txtInternal_Audit_Assignment.Text = objAP_Fraud_Events.Internal_Audit_Assignment;
        txtInternal_Audit_Associate_Contacted.Text = objAP_Fraud_Events.Internal_Audit_Associate_Contacted;
        txtDate_Internal_Audit_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Internal_Audit_Assigned);
        txtStore_Controller_Assignment.Text = objAP_Fraud_Events.Store_Controller_Assignment;
        txtStore_Controller_Associate_Contacted.Text = objAP_Fraud_Events.Store_Controller_Associate_Contacted;
        txtDate_Store_Controller_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Store_Controller_Assigned);
        txtRegional_Controller_Assignment.Text = objAP_Fraud_Events.Regional_Controller_Assignment;
        txtRegional_Controller_Associate_Contacted.Text = objAP_Fraud_Events.Regional_Controller_Associate_Contacted;
        txtDate_Regional_Controller_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Regional_Controller_Assigned);
        txtLegal_Department_Assignment.Text = objAP_Fraud_Events.Legal_Department_Assignment;
        txtLegal_Department_Associate_Contacted.Text = objAP_Fraud_Events.Legal_Department_Associate_Contacted;
        txtDate_Legal_Department_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Legal_Department_Assigned);
        txtOutside_Legal_Assignment.Text = objAP_Fraud_Events.Outside_Legal_Assignment;
        txtOutside_Legal_Associate_Contacted.Text = objAP_Fraud_Events.Outside_Legal_Associate_Contacted;
        txtDate_Outside_Legal_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Outside_Legal_Assigned);
        txtOperations_Assignment.Text = objAP_Fraud_Events.Operations_Assignment;
        txtOperations_Associate_Contacted.Text = objAP_Fraud_Events.Operations_Associate_Contacted;
        txtDate_Operations_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Operations_Assigned);
        txtRetail_Lending_Assignment.Text = objAP_Fraud_Events.Retail_Lending_Assignment;
        txtRetail_Lending_Associate_Contacted.Text = objAP_Fraud_Events.Retail_Lending_Associate_Contacted;
        txtDate_Retail_Lending_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Retail_Lending_Assigned);
        txtBT_Security_Assignment.Text = objAP_Fraud_Events.BT_Security_Assignment;
        txtBT_Security_Associate_Contacted.Text = objAP_Fraud_Events.BT_Security_Associate_Contacted;
        txtDate_BT_Security_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_BT_Security_Assigned);
        txtOther_Assignment.Text = objAP_Fraud_Events.Other_Assignment;
        txtAssociated_Contacted.Text = objAP_Fraud_Events.Other_Associate_Contacted;
        txtDate_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Other_Assigned);
        txtOnSite_Findings.Text = objAP_Fraud_Events.OnSite_Findings;
        txtTLO_Findings.Text = objAP_Fraud_Events.TLO_Findings;
        txtStatements_Obtained.Text = objAP_Fraud_Events.Statements_Obtained;
        txtFact_Finding_andor_Due_Diligence.Text = objAP_Fraud_Events.Fact_Finding_andor_Due_Diligence;
        txtLaw_Enforcement_Involvement.Text = objAP_Fraud_Events.Law_Enforcement_Involvement;
        txtDetailed_Deisposition_Game_Plan_Description.Text = objAP_Fraud_Events.Detailed_Deisposition_Game_Plan_Description;
        txtDetail_Description_of_Root_Cause.Text = objAP_Fraud_Events.Detail_Description_of_Root_Cause;
        txtDetail_Description_of_Corrective_Action_andor_Recommendation.Text = objAP_Fraud_Events.Detail_Description_of_Corrective_Action_andor_Recommendation;
        if (objAP_Fraud_Events.Close_File != null)
            rdoClose_File.SelectedValue = objAP_Fraud_Events.Close_File;
        else
            rdoClose_File.ClearSelection();
        txtClose_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Close_Date);
        if (objAP_Fraud_Events.Reopen_File != null)
            rdoReopen_File.SelectedValue = objAP_Fraud_Events.Reopen_File;
        else
            rdoReopen_File.ClearSelection();
        txtReopen_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Reopen_Date);
        txtFraudEvent_Comments.Text = objAP_Fraud_Events.Comments;


        chkSuspension.Checked = objAP_Fraud_Events.ACC_Suspension == "Y" ? true : false;
        chkTermination.Checked = objAP_Fraud_Events.ACC_Termination == "Y" ? true : false;
        chkVerbal.Checked = objAP_Fraud_Events.ACC_Verbal == "Y" ? true : false;
        chkWritten.Checked = objAP_Fraud_Events.ACC_Written == "Y" ? true : false;
        chkAccountPayableSchemes.Checked = objAP_Fraud_Events.Account_Payable_Schemes == "Y" ? true : false;
        chkAccountingGapsandControl.Checked = objAP_Fraud_Events.Accounting_Gaps_and_Controls == "Y" ? true : false;
        chkMFRIncentives.Checked = objAP_Fraud_Events.Aging_MFR_Incentives == "Y" ? true : false;
        chkAgingWarranties.Checked = objAP_Fraud_Events.Aging_Warranties == "Y" ? true : false;
        chkAssociateCollusion.Checked = objAP_Fraud_Events.Associate_Collusion == "Y" ? true : false;
        chkBillingSchemes.Checked = objAP_Fraud_Events.Billing_Schemes == "Y" ? true : false;
        chkCorrectiveActionRecommendationOther.Checked = objAP_Fraud_Events.CA_Other == "Y" ? true : false;
        chkchangeaControl.Checked = objAP_Fraud_Events.Change_a_Control == "Y" ? true : false;
        chkCivilAction.Checked = objAP_Fraud_Events.Civil_Actrion == "Y" ? true : false;
        chkCommunicationStrategy.Checked = objAP_Fraud_Events.Communication_Strategy == "Y" ? true : false;
        chkCriminalAction.Checked = objAP_Fraud_Events.Crimimal_Action == "Y" ? true : false;
        chkCurrentSystemEnhancement.Checked = objAP_Fraud_Events.Current_Systen_Enhancement == "Y" ? true : false;
        chkCustomerRelationsHotLine.Checked = objAP_Fraud_Events.Customer_Relations_Hotline == "Y" ? true : false;
        chkDiscoveredFraudthroughAudits.Checked = objAP_Fraud_Events.Discovered_Fraud_through_Audits == "Y" ? true : false;
        chkDispositionGameplanOther.Checked = objAP_Fraud_Events.Disposition_Game_Plan_Other == "Y" ? true : false;
        chkExternalScam.Checked = objAP_Fraud_Events.External_Scam == "Y" ? true : false;

        //if (objAP_Fraud_Events.FK_LU_Location != null) drpFK_LU_Location.SelectedValue = objAP_Fraud_Events.FK_LU_Location.ToString();


        chkFurtherInvestigation.Checked = objAP_Fraud_Events.Further_Investigation == "Y" ? true : false;
        chkImplementPolicy.Checked = objAP_Fraud_Events.Implementation_Policy == "Y" ? true : false;
        chkImproperDisclosuretoCustomerFandIProductPurchase.Checked = objAP_Fraud_Events.Improper_Disclosure_to_Customer_F_and_I_Product_Purchase == "Y" ? true : false;
        chkImproperDisclosuretoCustomerVehiclePurchase.Checked = objAP_Fraud_Events.Improper_Disclosure_to_Customer_Vehicle_Purchase == "Y" ? true : false;
        chkIntrnlAditCntrlLeadToFraudEvent.Checked = objAP_Fraud_Events.Internal_Audit_Control_Breakdown_leading_to_Fraud_Event == "Y" ? true : false;
        chkInventorySchemes.Checked = objAP_Fraud_Events.Inventory_Schemes == "Y" ? true : false;
        chkNewSystemChange.Checked = objAP_Fraud_Events.New_System_Change == "Y" ? true : false;
        chkOther.Checked = objAP_Fraud_Events.Notification_Other == "Y" ? true : false;
        chkOperasionsNoAdherencetoSonicPolicyandPlaybook.Checked = objAP_Fraud_Events.Operations_No_Adherence_to_Sonic_Policy_And_Playbook == "Y" ? true : false;
        chkResultOfDespositionPlan.Checked = objAP_Fraud_Events.Results_of_Disposition_Plan == "Y" ? true : false;
        chkRetailLending.Checked = objAP_Fraud_Events.Retail_Lending == "Y" ? true : false;
        chkRetraining.Checked = objAP_Fraud_Events.ReTraining == "Y" ? true : false;
        chkDispositionGameplanOther.Checked = objAP_Fraud_Events.Root_Cause_Other == "Y" ? true : false;
        chkSonicAssociate1800HotLine.Checked = objAP_Fraud_Events.Sonic_Associates_1800_Hotline == "Y" ? true : false;
        chkStoreRedFlags.Checked = objAP_Fraud_Events.Store_Red_Flags == "Y" ? true : false;
        chkTraining.Checked = objAP_Fraud_Events.Training == "Y" ? true : false;
        chkVendorCollusion.Checked = objAP_Fraud_Events.Vendor_Collusion == "Y" ? true : false;
        chkVendorSchemes.Checked = objAP_Fraud_Events.Vendor_Schemes == "Y" ? true : false;

        chkMonthlyARControlReview.Checked = objAP_Fraud_Events.Monthly_AR_Control_Review == "Y" ? true : false;

        if (PK_AP_Fraud_Events > 0)
        {
            btnFruad_EventAudit_Trail.Visible = true;
        }
        else
        {
            btnFruad_EventAudit_Trail.Visible = false;
        }

        BindNotesGrid();
        BindFraudNotesGrid();
        BindTransactionGrid();
        BindFinancialMatrix();
    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView_FraudEvents()
    {
        clsAP_Fraud_Events objAP_Fraud_Events = new clsAP_Fraud_Events(PK_AP_Fraud_Events);
        lblFraudNumber.Text = objAP_Fraud_Events.Fraud_Number;
        lblExposurePeriodBeginDate.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Exposure_Period_Begin_Date);
        lblExposurePeriodEndDate.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Exposure_Period_End_Date);
        lblReportedTo.Text = objAP_Fraud_Events.Reported_To;
        lblReportedDate.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Reported_Date);
        lblDesciptionOfEvent.Text = objAP_Fraud_Events.Description_of_Event;
        lblOther_Notification_Description.Text = objAP_Fraud_Events.Other_Notification_Description;
        lblInternal_Review_Purification_Notes.Text = objAP_Fraud_Events.Internal_Review_Purification_Notes;
        lblFraud_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Fraud_Date);
        lblHR_Assignment.Text = objAP_Fraud_Events.HR_Assignment;
        lblHR_Associate_Contacted.Text = objAP_Fraud_Events.HR_Associate_Contacted;
        lblDate_HR_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_HR_Assigned);
        lblInternal_Audit_Assignment.Text = objAP_Fraud_Events.Internal_Audit_Assignment;
        lblInternal_Audit_Associate_Contacted.Text = objAP_Fraud_Events.Internal_Audit_Associate_Contacted;
        lblDate_Internal_Audit_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Internal_Audit_Assigned);
        lblStore_Controller_Assignment.Text = objAP_Fraud_Events.Store_Controller_Assignment;
        lblStore_Controller_Associate_Contacted.Text = objAP_Fraud_Events.Store_Controller_Associate_Contacted;
        lblDate_Store_Controller_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Store_Controller_Assigned);
        lblRegional_Controller_Assignment.Text = objAP_Fraud_Events.Regional_Controller_Assignment;
        lblRegional_Controller_Associate_Contacted.Text = objAP_Fraud_Events.Regional_Controller_Associate_Contacted;
        lblDate_Regional_Controller_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Regional_Controller_Assigned);
        lblLegal_Department_Assignment.Text = objAP_Fraud_Events.Legal_Department_Assignment;
        lblLegal_Department_Associate_Contacted.Text = objAP_Fraud_Events.Legal_Department_Associate_Contacted;
        lblDate_Legal_Department_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Legal_Department_Assigned);
        lblOutside_Legal_Assignment.Text = objAP_Fraud_Events.Outside_Legal_Assignment;
        lblOutside_Legal_Associate_Contacted.Text = objAP_Fraud_Events.Outside_Legal_Associate_Contacted;
        lblDate_Outside_Legal_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Outside_Legal_Assigned);
        lblOperations_Assignment.Text = objAP_Fraud_Events.Operations_Assignment;
        lblOperations_Associate_Contacted.Text = objAP_Fraud_Events.Operations_Associate_Contacted;
        lblDate_Operations_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Operations_Assigned);
        lblRetail_Lending_Assignment.Text = objAP_Fraud_Events.Retail_Lending_Assignment;
        lblRetail_Lending_Associate_Contacted.Text = objAP_Fraud_Events.Retail_Lending_Associate_Contacted;
        lblDate_Retail_Lending_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Retail_Lending_Assigned);
        lblBT_Security_Assignment.Text = objAP_Fraud_Events.BT_Security_Assignment;
        lblBT_Security_Associate_Contacted.Text = objAP_Fraud_Events.BT_Security_Associate_Contacted;
        lblDate_BT_Security_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_BT_Security_Assigned);
        lblOther_Assignment.Text = objAP_Fraud_Events.Other_Assignment;
        lblAssociated_Contacted.Text = objAP_Fraud_Events.Other_Associate_Contacted;
        lblDate_Assigned.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Date_Other_Assigned);
        lblOnSite_Findings.Text = objAP_Fraud_Events.OnSite_Findings;
        lblTLO_Findings.Text = objAP_Fraud_Events.TLO_Findings;
        lblStatements_Obtained.Text = objAP_Fraud_Events.Statements_Obtained;
        lblFact_Finding_andor_Due_Diligence.Text = objAP_Fraud_Events.Fact_Finding_andor_Due_Diligence;
        lblLaw_Enforcement_Involvement.Text = objAP_Fraud_Events.Law_Enforcement_Involvement;
        lblDetailed_Deisposition_Game_Plan_Description.Text = objAP_Fraud_Events.Detailed_Deisposition_Game_Plan_Description;
        lblDetail_Description_of_Root_Cause.Text = objAP_Fraud_Events.Detail_Description_of_Root_Cause;
        lblDetail_Description_of_Corrective_Action_andor_Recommendation.Text = objAP_Fraud_Events.Detail_Description_of_Corrective_Action_andor_Recommendation;
        if (objAP_Fraud_Events.Close_File != null)
            lblClose_File.Text = objAP_Fraud_Events.Close_File == "Y" ? "Yes" : "No";
        else
            lblClose_File.Text = "";
        lblClose_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Close_Date);
        if (objAP_Fraud_Events.Reopen_File != null)
            lblReopen_File.Text = objAP_Fraud_Events.Reopen_File == "Y" ? "Yes" : "No";
        else
            lblReopen_File.Text = "";
        lblReopen_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objAP_Fraud_Events.Reopen_Date);
        lblEventComments.Text = objAP_Fraud_Events.Comments;


        //if (objAP_Fraud_Events.FK_LU_Location != null)
        //    lblFK_LU_Location.Text = new LU_Location((decimal)objAP_Fraud_Events.FK_LU_Location).Fld_Desc;
        chkSuspensionView.Checked = objAP_Fraud_Events.ACC_Suspension == "Y" ? true : false;
        chkTerminationView.Checked = objAP_Fraud_Events.ACC_Termination == "Y" ? true : false;
        chkVerbalView.Checked = objAP_Fraud_Events.ACC_Verbal == "Y" ? true : false;
        chkWrittenView.Checked = objAP_Fraud_Events.ACC_Written == "Y" ? true : false;
        chkAccountPayableSchemesView.Checked = objAP_Fraud_Events.Account_Payable_Schemes == "Y" ? true : false;
        chkAccountingGapsandControlView.Checked = objAP_Fraud_Events.Accounting_Gaps_and_Controls == "Y" ? true : false;
        chkMFRIncentivesView.Checked = objAP_Fraud_Events.Aging_MFR_Incentives == "Y" ? true : false;
        chkAgingWarrantiesView.Checked = objAP_Fraud_Events.Aging_Warranties == "Y" ? true : false;
        chkAssociateCollusionView.Checked = objAP_Fraud_Events.Associate_Collusion == "Y" ? true : false;
        chkBillingSchemesView.Checked = objAP_Fraud_Events.Billing_Schemes == "Y" ? true : false;
        chkCorrectiveActionRecommendationOtherView.Checked = objAP_Fraud_Events.CA_Other == "Y" ? true : false;
        chkchangeaControlView.Checked = objAP_Fraud_Events.Change_a_Control == "Y" ? true : false;
        chkCivilActionView.Checked = objAP_Fraud_Events.Civil_Actrion == "Y" ? true : false;
        chkCommunicationStrategyView.Checked = objAP_Fraud_Events.Communication_Strategy == "Y" ? true : false;
        chkCriminalActionView.Checked = objAP_Fraud_Events.Crimimal_Action == "Y" ? true : false;
        chkCurrentSystemEnhancementView.Checked = objAP_Fraud_Events.Current_Systen_Enhancement == "Y" ? true : false;
        chkCustomerRelationsHotLineView.Checked = objAP_Fraud_Events.Customer_Relations_Hotline == "Y" ? true : false;
        chkDiscoveredFraudthroughAuditsView.Checked = objAP_Fraud_Events.Discovered_Fraud_through_Audits == "Y" ? true : false;
        chkDispositionGameplanOtherView.Checked = objAP_Fraud_Events.Disposition_Game_Plan_Other == "Y" ? true : false;
        chkExternalScamView.Checked = objAP_Fraud_Events.External_Scam == "Y" ? true : false;
        chkFurtherInvestigationView.Checked = objAP_Fraud_Events.Further_Investigation == "Y" ? true : false;
        chkImplementPolicyView.Checked = objAP_Fraud_Events.Implementation_Policy == "Y" ? true : false;
        chkImproperDisclosuretoCustomerFandIProductPurchaseView.Checked = objAP_Fraud_Events.Improper_Disclosure_to_Customer_F_and_I_Product_Purchase == "Y" ? true : false;
        chkImproperDisclosuretoCustomerVehiclePurchaseView.Checked = objAP_Fraud_Events.Improper_Disclosure_to_Customer_Vehicle_Purchase == "Y" ? true : false;
        chkIntrnlAditCntrlLeadToFraudEventView.Checked = objAP_Fraud_Events.Internal_Audit_Control_Breakdown_leading_to_Fraud_Event == "Y" ? true : false;
        chkInventorySchemesView.Checked = objAP_Fraud_Events.Inventory_Schemes == "Y" ? true : false;
        chkNewSystemChangeView.Checked = objAP_Fraud_Events.New_System_Change == "Y" ? true : false;
        chkOtherView.Checked = objAP_Fraud_Events.Notification_Other == "Y" ? true : false;
        chkOperasionsNoAdherencetoSonicPolicyandPlaybookView.Checked = objAP_Fraud_Events.Operations_No_Adherence_to_Sonic_Policy_And_Playbook == "Y" ? true : false;
        chkResultOfDespositionPlanView.Checked = objAP_Fraud_Events.Results_of_Disposition_Plan == "Y" ? true : false;
        chkRetailLendingView.Checked = objAP_Fraud_Events.Retail_Lending == "Y" ? true : false;
        chkRetrainingView.Checked = objAP_Fraud_Events.ReTraining == "Y" ? true : false;
        chkDispositionGameplanOtherView.Checked = objAP_Fraud_Events.Root_Cause_Other == "Y" ? true : false;
        chkSonicAssociate1800HotLineView.Checked = objAP_Fraud_Events.Sonic_Associates_1800_Hotline == "Y" ? true : false;
        chkStoreRedFlagsView.Checked = objAP_Fraud_Events.Store_Red_Flags == "Y" ? true : false;
        chkTrainingView.Checked = objAP_Fraud_Events.Training == "Y" ? true : false;
        chkVendorCollusionView.Checked = objAP_Fraud_Events.Vendor_Collusion == "Y" ? true : false;
        chkVendorSchemesView.Checked = objAP_Fraud_Events.Vendor_Schemes == "Y" ? true : false;

        chkMonthlyARControlReviewView.Checked = objAP_Fraud_Events.Monthly_AR_Control_Review == "Y" ? true : false;

        if (PK_AP_Fraud_Events > 0)
        {
            btnFruad_EventAudit_TrailView.Visible = true;
        }
        else
        {
            btnFruad_EventAudit_TrailView.Visible = false;
        }

        BindNotesGrid();
        BindFraudNotesGrid();
        BindTransactionGrid();
        BindFinancialMatrix();
    }

    /// <summary>
    /// Save Fraud Event Data 
    /// </summary>
    private void FraudEventSaveData()
    {
        clsAP_Fraud_Events objAP_Fraud_Events = new clsAP_Fraud_Events();

        objAP_Fraud_Events.FK_LU_Location = LocationID;
        objAP_Fraud_Events.PK_AP_Fraud_Events = PK_AP_Fraud_Events;
        objAP_Fraud_Events.Exposure_Period_Begin_Date = clsGeneral.FormatNullDateToStore(txtExpPeriodBeginDate.Text);
        objAP_Fraud_Events.Exposure_Period_End_Date = clsGeneral.FormatNullDateToStore(txtExpoPeriodEndDate.Text);
        objAP_Fraud_Events.Reported_To = txtReportedTo.Text;
        objAP_Fraud_Events.Reported_Date = clsGeneral.FormatNullDateToStore(txtReportedDate.Text);
        objAP_Fraud_Events.Description_of_Event = txtDesciptionofEvent.Text;
        objAP_Fraud_Events.Other_Notification_Description = txtOther_Notification_Description.Text.Trim();
        objAP_Fraud_Events.Internal_Review_Purification_Notes = txtInternal_Review_Purification_Notes.Text.Trim();
        objAP_Fraud_Events.Fraud_Date = clsGeneral.FormatNullDateToStore(txtFraud_Date.Text);
        objAP_Fraud_Events.HR_Assignment = txtHR_Assignment.Text.Trim();
        objAP_Fraud_Events.HR_Associate_Contacted = txtHR_Associate_Contacted.Text.Trim();
        objAP_Fraud_Events.Date_HR_Assigned = clsGeneral.FormatNullDateToStore(txtDate_HR_Assigned.Text);
        objAP_Fraud_Events.Internal_Audit_Assignment = txtInternal_Audit_Assignment.Text.Trim();
        objAP_Fraud_Events.Internal_Audit_Associate_Contacted = txtInternal_Audit_Associate_Contacted.Text.Trim();
        objAP_Fraud_Events.Date_Internal_Audit_Assigned = clsGeneral.FormatNullDateToStore(txtDate_Internal_Audit_Assigned.Text);
        objAP_Fraud_Events.Store_Controller_Assignment = txtStore_Controller_Assignment.Text.Trim();
        objAP_Fraud_Events.Store_Controller_Associate_Contacted = txtStore_Controller_Associate_Contacted.Text.Trim();
        objAP_Fraud_Events.Date_Store_Controller_Assigned = clsGeneral.FormatNullDateToStore(txtDate_Store_Controller_Assigned.Text);
        objAP_Fraud_Events.Regional_Controller_Assignment = txtRegional_Controller_Assignment.Text.Trim();
        objAP_Fraud_Events.Regional_Controller_Associate_Contacted = txtRegional_Controller_Associate_Contacted.Text.Trim();
        objAP_Fraud_Events.Date_Regional_Controller_Assigned = clsGeneral.FormatNullDateToStore(txtDate_Regional_Controller_Assigned.Text);
        objAP_Fraud_Events.Legal_Department_Assignment = txtLegal_Department_Assignment.Text.Trim();
        objAP_Fraud_Events.Legal_Department_Associate_Contacted = txtLegal_Department_Associate_Contacted.Text.Trim();
        objAP_Fraud_Events.Date_Legal_Department_Assigned = clsGeneral.FormatNullDateToStore(txtDate_Legal_Department_Assigned.Text);
        objAP_Fraud_Events.Outside_Legal_Assignment = txtOutside_Legal_Assignment.Text.Trim();
        objAP_Fraud_Events.Outside_Legal_Associate_Contacted = txtOutside_Legal_Associate_Contacted.Text.Trim();
        objAP_Fraud_Events.Date_Outside_Legal_Assigned = clsGeneral.FormatNullDateToStore(txtDate_Outside_Legal_Assigned.Text);
        objAP_Fraud_Events.Operations_Assignment = txtOperations_Assignment.Text.Trim();
        objAP_Fraud_Events.Operations_Associate_Contacted = txtOperations_Associate_Contacted.Text.Trim();
        objAP_Fraud_Events.Date_Operations_Assigned = clsGeneral.FormatNullDateToStore(txtDate_Operations_Assigned.Text);
        objAP_Fraud_Events.Retail_Lending_Assignment = txtRetail_Lending_Assignment.Text.Trim();
        objAP_Fraud_Events.Retail_Lending_Associate_Contacted = txtRetail_Lending_Associate_Contacted.Text.Trim();
        objAP_Fraud_Events.Date_Retail_Lending_Assigned = clsGeneral.FormatNullDateToStore(txtDate_Retail_Lending_Assigned.Text);
        objAP_Fraud_Events.BT_Security_Assignment = txtBT_Security_Assignment.Text.Trim();
        objAP_Fraud_Events.BT_Security_Associate_Contacted = txtBT_Security_Associate_Contacted.Text.Trim();
        objAP_Fraud_Events.Date_BT_Security_Assigned = clsGeneral.FormatNullDateToStore(txtDate_BT_Security_Assigned.Text);
        objAP_Fraud_Events.Other_Assignment = txtOther_Assignment.Text.Trim();
        objAP_Fraud_Events.Other_Associate_Contacted = txtAssociated_Contacted.Text.Trim();
        objAP_Fraud_Events.Date_Other_Assigned = clsGeneral.FormatNullDateToStore(txtDate_Assigned.Text);
        objAP_Fraud_Events.OnSite_Findings = txtOnSite_Findings.Text.Trim();
        objAP_Fraud_Events.TLO_Findings = txtTLO_Findings.Text.Trim();
        objAP_Fraud_Events.Statements_Obtained = txtStatements_Obtained.Text.Trim();
        objAP_Fraud_Events.Fact_Finding_andor_Due_Diligence = txtFact_Finding_andor_Due_Diligence.Text.Trim();
        objAP_Fraud_Events.Law_Enforcement_Involvement = txtLaw_Enforcement_Involvement.Text.Trim();
        objAP_Fraud_Events.Detailed_Deisposition_Game_Plan_Description = txtDetailed_Deisposition_Game_Plan_Description.Text.Trim();
        objAP_Fraud_Events.Detail_Description_of_Root_Cause = txtDetail_Description_of_Root_Cause.Text.Trim();
        objAP_Fraud_Events.Detail_Description_of_Corrective_Action_andor_Recommendation = txtDetail_Description_of_Corrective_Action_andor_Recommendation.Text.Trim();
        objAP_Fraud_Events.Close_File = rdoClose_File.SelectedValue;
        objAP_Fraud_Events.Close_Date = clsGeneral.FormatNullDateToStore(txtClose_Date.Text);
        objAP_Fraud_Events.Reopen_File = rdoReopen_File.SelectedValue;
        objAP_Fraud_Events.Reopen_Date = clsGeneral.FormatNullDateToStore(txtReopen_Date.Text);
        objAP_Fraud_Events.Comments = txtFraudEvent_Comments.Text.Trim();

        objAP_Fraud_Events.ACC_Suspension = chkSuspension.Checked ? "Y" : "N";
        objAP_Fraud_Events.ACC_Termination = chkTermination.Checked ? "Y" : "N";
        objAP_Fraud_Events.ACC_Verbal = chkVerbal.Checked ? "Y" : "N";
        objAP_Fraud_Events.ACC_Written = chkWritten.Checked ? "Y" : "N";
        objAP_Fraud_Events.Account_Payable_Schemes = chkAccountPayableSchemes.Checked ? "Y" : "N";
        objAP_Fraud_Events.Accounting_Gaps_and_Controls = chkAccountingGapsandControl.Checked ? "Y" : "N";
        objAP_Fraud_Events.Aging_MFR_Incentives = chkMFRIncentives.Checked ? "Y" : "N";
        objAP_Fraud_Events.Aging_Warranties = chkAgingWarranties.Checked ? "Y" : "N";
        objAP_Fraud_Events.Associate_Collusion = chkAssociateCollusion.Checked ? "Y" : "N";
        objAP_Fraud_Events.Billing_Schemes = chkBillingSchemes.Checked ? "Y" : "N";
        objAP_Fraud_Events.CA_Other = chkCorrectiveActionRecommendationOther.Checked ? "Y" : "N";
        objAP_Fraud_Events.Change_a_Control = chkchangeaControl.Checked ? "Y" : "N";
        objAP_Fraud_Events.Civil_Actrion = chkCivilAction.Checked ? "Y" : "N";
        objAP_Fraud_Events.Communication_Strategy = chkCommunicationStrategy.Checked ? "Y" : "N";
        objAP_Fraud_Events.Crimimal_Action = chkCriminalAction.Checked ? "Y" : "N";
        objAP_Fraud_Events.Current_Systen_Enhancement = chkCurrentSystemEnhancement.Checked ? "Y" : "N";
        objAP_Fraud_Events.Customer_Relations_Hotline = chkCustomerRelationsHotLine.Checked ? "Y" : "N";
        objAP_Fraud_Events.Discovered_Fraud_through_Audits = chkDiscoveredFraudthroughAudits.Checked ? "Y" : "N";
        objAP_Fraud_Events.Disposition_Game_Plan_Other = chkDispositionGameplanOther.Checked ? "Y" : "N";
        objAP_Fraud_Events.External_Scam = chkExternalScam.Checked ? "Y" : "N";
        objAP_Fraud_Events.Further_Investigation = chkFurtherInvestigation.Checked ? "Y" : "N";
        objAP_Fraud_Events.Implementation_Policy = chkImplementPolicy.Checked ? "Y" : "N";
        objAP_Fraud_Events.Improper_Disclosure_to_Customer_F_and_I_Product_Purchase = chkImproperDisclosuretoCustomerFandIProductPurchase.Checked ? "Y" : "N";
        objAP_Fraud_Events.Improper_Disclosure_to_Customer_Vehicle_Purchase = chkImproperDisclosuretoCustomerVehiclePurchase.Checked ? "Y" : "N";
        objAP_Fraud_Events.Internal_Audit_Control_Breakdown_leading_to_Fraud_Event = chkIntrnlAditCntrlLeadToFraudEvent.Checked ? "Y" : "N";
        objAP_Fraud_Events.Inventory_Schemes = chkInventorySchemes.Checked ? "Y" : "N";
        objAP_Fraud_Events.New_System_Change = chkNewSystemChange.Checked ? "Y" : "N";
        objAP_Fraud_Events.Notification_Other = chkOther.Checked ? "Y" : "N";
        objAP_Fraud_Events.Operations_No_Adherence_to_Sonic_Policy_And_Playbook = chkOperasionsNoAdherencetoSonicPolicyandPlaybook.Checked ? "Y" : "N";
        objAP_Fraud_Events.Results_of_Disposition_Plan = chkResultOfDespositionPlan.Checked ? "Y" : "N";
        objAP_Fraud_Events.Retail_Lending = chkRetailLending.Checked ? "Y" : "N";
        objAP_Fraud_Events.ReTraining = chkRetraining.Checked ? "Y" : "N";
        objAP_Fraud_Events.Root_Cause_Other = chkDispositionGameplanOther.Checked ? "Y" : "N";
        objAP_Fraud_Events.Sonic_Associates_1800_Hotline = chkSonicAssociate1800HotLine.Checked ? "Y" : "N";
        objAP_Fraud_Events.Store_Red_Flags = chkStoreRedFlags.Checked ? "Y" : "N";
        objAP_Fraud_Events.Training = chkTraining.Checked ? "Y" : "N";
        objAP_Fraud_Events.Vendor_Collusion = chkVendorCollusion.Checked ? "Y" : "N";
        objAP_Fraud_Events.Vendor_Schemes = chkVendorSchemes.Checked ? "Y" : "N";

        objAP_Fraud_Events.Monthly_AR_Control_Review = chkMonthlyARControlReview.Checked ? "Y" : "N";

        objAP_Fraud_Events.Update_Date = DateTime.Now;
        objAP_Fraud_Events.Updated_By = clsSession.UserID;

        if (PK_AP_Fraud_Events > 0)
        {
            objAP_Fraud_Events.Update();
        }
        else
        {
            PK_AP_Fraud_Events = objAP_Fraud_Events.Insert();
        }
        if (PK_AP_Fraud_Events > 0)
        {
            btnFruad_EventAudit_Trail.Visible = true;
        }
        else
        {
            btnFruad_EventAudit_Trail.Visible = false;
        }
        BindFraudEventGrid();
        BindDetailsForEdit_FraudEvents();
    }

    /// <summary>
    /// Bind Selceted Notes Detail 
    /// </summary>
    private void bindNotesDetailForEdit()
    {
        if (PK_AP_FE_Notes > 0)
        {
            btnNotesGridAdd.Visible = true;
            btnFraudNotesGridAdd.Visible = false;

            clsAP_FE_Notes objclsAP_FE_Notes = new clsAP_FE_Notes(PK_AP_FE_Notes);
            btnViewAuditNotesGrid.Visible = true;
            btnViewFraudAuditNotesGrid.Visible = false;
            btnFraudEventSave.Visible = false;
            btnFruad_EventAudit_Trail.Visible = false;
            txtNotesDate.Text = clsGeneral.FormatDBNullDateToDisplay(objclsAP_FE_Notes.Note_Date);
            txtNotesAdd.Text = objclsAP_FE_Notes.Note;
        }
    }

    /// <summary>
    /// Bind Selceted Notes Detail 
    /// </summary>
    private void bindNotesFraudDetailForEdit()
    {
        if (PK_AP_FE_PA_Notes > 0)
        {
            btnNotesGridAdd.Visible = false;
            btnFraudNotesGridAdd.Visible = true;

            AP_FE_PA_Notes AP_FE_PA_Notes = new AP_FE_PA_Notes(PK_AP_FE_PA_Notes);
            btnViewAuditNotesGrid.Visible = false;
            btnViewFraudAuditNotesGrid.Visible = true;
            btnFraudEventSave.Visible = false;
            btnFruad_EventAudit_Trail.Visible = false;
            txtNotesDate.Text = clsGeneral.FormatDBNullDateToDisplay(AP_FE_PA_Notes.Note_Date);
            txtNotesAdd.Text = AP_FE_PA_Notes.Note;
        }
    }

    /// <summary>
    /// Bind Selceted Notes Detail 
    /// </summary>
    private void bindNotesDetailForView()
    {
        if (PK_AP_FE_Notes > 0)
        {
            clsAP_FE_Notes objclsAP_FE_Notes = new clsAP_FE_Notes(PK_AP_FE_Notes);
            btnViewAuditNotesGridView.Visible = true;
            btnViewAuditNotesFraudGridView.Visible = false;
            btnFruad_EventAudit_TrailView.Visible = false;
            btnFraudEventSave.Visible = false;
            lblNotesDate.Text = clsGeneral.FormatDBNullDateToDisplay(objclsAP_FE_Notes.Note_Date);
            txtNotesAddView.Text = objclsAP_FE_Notes.Note;
        }
    }

    /// <summary>
    /// Bind Selceted Notes Detail 
    /// </summary>
    private void bindNotesDetailFraudForView()
    {
        if (PK_AP_FE_PA_Notes > 0)
        {
            AP_FE_PA_Notes AP_FE_PA_Notes = new AP_FE_PA_Notes(PK_AP_FE_PA_Notes);
            btnViewAuditNotesGridView.Visible = false;
            btnViewAuditNotesFraudGridView.Visible = true;
            btnFruad_EventAudit_TrailView.Visible = false;
            btnFraudEventSave.Visible = false;
            lblNotesDate.Text = clsGeneral.FormatDBNullDateToDisplay(AP_FE_PA_Notes.Note_Date);
            txtNotesAddView.Text = AP_FE_PA_Notes.Note;
        }
    }

    /// <summary>
    /// Bind Selected Transaction Detail
    /// </summary>
    private void bindTransactionDetailForEdit()
    {
        if (PK_AP_FE_Transactions > 0)
        {
            btnViewAuditTransactionGrid.Visible = true;
            btnFraudEventSave.Visible = false;
            btnFruad_EventAudit_Trail.Visible = false;
            clsAP_FE_Transactions objclsAP_FE_Transactions = new clsAP_FE_Transactions(PK_AP_FE_Transactions);
            ddlTransactionCatagory.SelectedValue = (objclsAP_FE_Transactions.FK_LU_Transaction_Category > 0 ? objclsAP_FE_Transactions.FK_LU_Transaction_Category.ToString() : "0");
            ddlTransactionType.SelectedValue = (objclsAP_FE_Transactions.FK_LU_Transaction_Type > 0 ? objclsAP_FE_Transactions.FK_LU_Transaction_Type.ToString() : "0");
            txtTransactionDate.Text = clsGeneral.FormatDBNullDateToDisplay(objclsAP_FE_Transactions.Transaction_Date);
            txtTransactionAmount.Text = objclsAP_FE_Transactions.Transaction_Amount.ToString();
        }
    }

    /// <summary>
    /// Bind Selected Transaction Detail
    /// </summary>
    private void bindTransactionDetailForView()
    {
        if (PK_AP_FE_Transactions > 0)
        {
            btnViewAuditTransactionGridView.Visible = true;
            btnFraudEventSave.Visible = false;
            btnFruad_EventAudit_TrailView.Visible = false;
            clsAP_FE_Transactions objclsAP_FE_Transactions = new clsAP_FE_Transactions(PK_AP_FE_Transactions);
            lblTransactionCatagory.Text = (objclsAP_FE_Transactions.FK_LU_Transaction_Category > 0 ? new clsLU_Transaction_Category(Convert.ToDecimal(objclsAP_FE_Transactions.FK_LU_Transaction_Category)).Fld_Desc : "");
            lblTransactionType.Text = (objclsAP_FE_Transactions.FK_LU_Transaction_Category > 0 ? new clsLU_Transaction_Type(Convert.ToDecimal(objclsAP_FE_Transactions.FK_LU_Transaction_Type)).Fld_Desc : "");
            lblTransactionDate.Text = clsGeneral.FormatDBNullDateToDisplay(objclsAP_FE_Transactions.Transaction_Date);
            lblTransactionAmount.Text = objclsAP_FE_Transactions.Transaction_Amount.ToString();
        }
    }

    /// <summary>
    /// Bind Notes Grid
    /// </summary>
    private void BindNotesGrid()
    {
        if (StrOperation != "view")
        {
            gvNotesGrid.DataSource = clsAP_FE_Notes.SelectNotesByFKFraudEvent(PK_AP_Fraud_Events).Tables[0];
            gvNotesGrid.DataBind();
        }
        else
        {
            gvNotesGridView.DataSource = clsAP_FE_Notes.SelectNotesByFKFraudEvent(PK_AP_Fraud_Events).Tables[0];
            gvNotesGridView.DataBind();
        }
    }

    /// <summary>
    /// Bind Notes Grid
    /// </summary>
    private void BindFraudNotesGrid()
    {
        if (StrOperation != "view")
        {
            if (PK_AP_Fraud_Events > 0)
            {
                gvFraudEventsNote.DataSource = AP_FE_PA_Notes.SelectNotesByFKFraudEvent(PK_AP_Fraud_Events, _SortOrder_FraudNotes).Tables[0];
            }
            gvFraudEventsNote.DataBind();

        }
        else
        {
            if (PK_AP_Fraud_Events > 0)
            {
                gvNotesGridFraudView.DataSource = AP_FE_PA_Notes.SelectNotesByFKFraudEvent(PK_AP_Fraud_Events, _SortOrder_FraudNotes).Tables[0];
            }
            gvNotesGridFraudView.DataBind();

        }
    }

    /// <summary>
    /// Bind Transaction Grid
    /// </summary>
    private void BindTransactionGrid()
    {
        if (StrOperation != "view")
        {
            gvFinancialReserveTransaction.DataSource = clsAP_FE_Transactions.SelectTransactionByFKFraudEvent(PK_AP_Fraud_Events).Tables[0];
            gvFinancialReserveTransaction.DataBind();
        }
        else
        {
            gvFinancialReserveTransactionView.DataSource = clsAP_FE_Transactions.SelectTransactionByFKFraudEvent(PK_AP_Fraud_Events).Tables[0];
            gvFinancialReserveTransactionView.DataBind();
        }
    }

    /// <summary>
    /// Bind Fraud Event Grid
    /// </summary>
    private void BindFraudEventGrid()
    {
        if (StrOperation != "view")
        {
            DataSet ds_FruadEvent = clsAP_Fraud_Events.SelectFraudEventByFkLocation(rdoFraud_EventTo_Include.SelectedValue, LocationID, _SortBy_Fraud, _SortOrder_Fraud, CtrlPaging_Fraud.CurrentPage, CtrlPaging_Fraud.PageSize);
            gvFraudEvent.DataSource = ds_FruadEvent.Tables[0];
            gvFraudEvent.DataBind();
            CtrlPaging_Fraud.TotalRecords = (ds_FruadEvent.Tables.Count >= 2) ? Convert.ToInt32(ds_FruadEvent.Tables[1].Rows[0][0]) : 0;
            CtrlPaging_Fraud.CurrentPage = (ds_FruadEvent.Tables.Count >= 2) ? Convert.ToInt32(ds_FruadEvent.Tables[1].Rows[0][2]) : 0;
            CtrlPaging_Fraud.RecordsToBeDisplayed = ds_FruadEvent.Tables[0].Rows.Count;
            CtrlPaging_Fraud.SetPageNumbers();
            if (gvFraudEvent.Rows.Count == 0)
            {
                lnkbtnFraudEventAdd.Visible = false;
            }
            else
            {
                lnkbtnFraudEventAdd.Visible = true;
            }
        }
        else
        {
            DataSet ds_FruadEvent = clsAP_Fraud_Events.SelectFraudEventByFkLocation(rbtnlFraudEventView.SelectedValue, LocationID, _SortBy_Fraud, _SortOrder_Fraud, CtrlPaging_FraudView.CurrentPage, CtrlPaging_FraudView.PageSize);
            gvFraudEventView.DataSource = ds_FruadEvent.Tables[0];
            gvFraudEventView.DataBind();
            CtrlPaging_FraudView.TotalRecords = (ds_FruadEvent.Tables.Count >= 2) ? Convert.ToInt32(ds_FruadEvent.Tables[1].Rows[0][0]) : 0;
            CtrlPaging_FraudView.CurrentPage = (ds_FruadEvent.Tables.Count >= 2) ? Convert.ToInt32(ds_FruadEvent.Tables[1].Rows[0][2]) : 0;
            CtrlPaging_FraudView.RecordsToBeDisplayed = ds_FruadEvent.Tables[0].Rows.Count;
            CtrlPaging_FraudView.SetPageNumbers();
        }
    }

    /// <summary>
    /// Bind Financial Matrix
    /// </summary>
    private void BindFinancialMatrix()
    {
        DataSet ds = clsAP_FE_Transactions.SelectFinancialMatrixValue(PK_AP_Fraud_Events);
        if (StrOperation != "view")
        {
            lblFMReservePotentialLoss.Text = clsGeneral.GetStringValue(ds.Tables[0].Rows[0][0].ToString());
            lblFMReserveExpense.Text = clsGeneral.GetStringValue(ds.Tables[1].Rows[0][0].ToString());
            lblFMReserveTotal.Text = clsGeneral.GetStringValue(ds.Tables[2].Rows[0][0].ToString());
            lblFMPaidPotentialLoss.Text = clsGeneral.GetStringValue(ds.Tables[3].Rows[0][0].ToString());
            lblFMPaidExpense.Text = clsGeneral.GetStringValue(ds.Tables[4].Rows[0][0].ToString());
            lblFMPaidTotal.Text = clsGeneral.GetStringValue(ds.Tables[5].Rows[0][0].ToString());
            lblFMRecoveryPotentialLoss.Text = clsGeneral.GetStringValue(ds.Tables[6].Rows[0][0].ToString());
            lblFMRecoveryExpense.Text = clsGeneral.GetStringValue(ds.Tables[7].Rows[0][0].ToString());
            lblFMRecoveryTotal.Text = clsGeneral.GetStringValue(ds.Tables[8].Rows[0][0].ToString());
            lblFMOutstandingPotentialLoss.Text = clsGeneral.GetStringValue(ds.Tables[9].Rows[0][0].ToString());
            lblFMOutstandingExpense.Text = clsGeneral.GetStringValue(ds.Tables[10].Rows[0][0].ToString());
            lblFMOutstandingTotal.Text = clsGeneral.GetStringValue(ds.Tables[11].Rows[0][0].ToString());
        }
        else
        {
            lblFMReservePotentialLossView.Text = clsGeneral.GetStringValue(ds.Tables[0].Rows[0][0].ToString());
            lblFMReserveExpenseView.Text = clsGeneral.GetStringValue(ds.Tables[1].Rows[0][0].ToString());
            lblFMReserveTotalView.Text = clsGeneral.GetStringValue(ds.Tables[2].Rows[0][0].ToString());
            lblFMPaidPotentialLossView.Text = clsGeneral.GetStringValue(ds.Tables[3].Rows[0][0].ToString());
            lblFMPaidExpenseView.Text = clsGeneral.GetStringValue(ds.Tables[4].Rows[0][0].ToString());
            lblFMPaidTotalView.Text = clsGeneral.GetStringValue(ds.Tables[5].Rows[0][0].ToString());
            lblFMRecoveryPotentialLossView.Text = clsGeneral.GetStringValue(ds.Tables[6].Rows[0][0].ToString());
            lblFMRecoveryExpenseView.Text = clsGeneral.GetStringValue(ds.Tables[7].Rows[0][0].ToString());
            lblFMRecoveryTotalView.Text = clsGeneral.GetStringValue(ds.Tables[8].Rows[0][0].ToString());
            lblFMOutstandingPotentialLossView.Text = clsGeneral.GetStringValue(ds.Tables[9].Rows[0][0].ToString());
            lblFMOutstandingExpenseView.Text = clsGeneral.GetStringValue(ds.Tables[10].Rows[0][0].ToString());
            lblFMOutstandingTotalView.Text = clsGeneral.GetStringValue(ds.Tables[11].Rows[0][0].ToString());
        }

    }

    /// <summary>
    /// Clear Add Form of Grid
    /// </summary>
    private void ClearAddGridControl()
    {
        ddlTransactionCatagory.ClearSelection();
        ddlTransactionType.ClearSelection();
        txtTransactionDate.Text = "";
        txtTransactionAmount.Text = "";
        txtNotesDate.Text = "";
        txtNotesAdd.Text = "";
        btnFraudEventSave.Visible = true;
        btnViewAuditNotesGrid.Visible = false;
        btnViewFraudAuditNotesGrid.Visible = false;
        btnViewAuditNotesGridView.Visible = false;
        btnViewAuditNotesFraudGridView.Visible = false;
        btnViewAuditTransactionGrid.Visible = false;
        btnViewAuditTransactionGridView.Visible = false;

        tblMainFraudEvent.Style["display"] = pnlTransactionGridAdd.Style["display"] = tblMainFraudEventView.Style["display"] = pnlNoteGridAdd.Style["display"] = pnlNoteGridAddView.Style["display"] = pnlTransactionGridAddView.Style["display"] = "none";
        if (StrOperation == "view")
        {
            tblMainFraudEventView.Style["display"] = "";
            btnFruad_EventAudit_TrailView.Visible = true;
        }
        else
        {
            tblMainFraudEvent.Style["display"] = "";
            btnFruad_EventAudit_Trail.Visible = true;
        }
    }

    /// <summary>
    /// Binds the dropdown controls on page 
    /// </summary>
    private void BindDropDowns()
    {

        DataTable dtTransaction_Type = clsLU_Transaction_Type.SelectAll().Tables[0];
        // bind Rent Escalation dropdown
        ddlTransactionType.DataSource = dtTransaction_Type;
        ddlTransactionType.DataValueField = "PK_LU_Transaction_Type";
        ddlTransactionType.DataTextField = "Fld_Desc";
        ddlTransactionType.DataBind();
        ddlTransactionType.Items.Insert(0, new ListItem("--Select--", "0"));


        DataTable dtTransaction_Catagory = clsLU_Transaction_Category.SelectAll().Tables[0];
        // bind Rent Escalation dropdown
        ddlTransactionCatagory.DataSource = dtTransaction_Catagory;
        ddlTransactionCatagory.DataValueField = "PK_LU_Transaction_Category";
        ddlTransactionCatagory.DataTextField = "Fld_Desc";
        ddlTransactionCatagory.DataBind();
        ddlTransactionCatagory.Items.Insert(0, new ListItem("--Select--", "0"));


    }

    /// <summary>
    /// Returns the index of the column which contains perticular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex_Fraud(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        if (StrOperation == "view")
        {
            foreach (DataControlField field in gvFraudEventView.Columns)
            {
                //check Sort Expression value
                if (field.SortExpression.ToString() == strSortExp)
                {
                    nRet = gvFraudEventView.Columns.IndexOf(field);
                }
            }
            return nRet;
        }
        else
        {
            foreach (DataControlField field in gvFraudEvent.Columns)
            {
                //check Sort Expression value
                if (field.SortExpression.ToString() == strSortExp)
                {
                    nRet = gvFraudEvent.Columns.IndexOf(field);
                }
            }
            return nRet;
        }

    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage_Fraud(GridViewRow headerRow)
    {
        Int32 iCol = GetSortColumnIndex_Fraud(_SortBy_Fraud);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder_AL = _SortOrder_Fraud == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

        // check for the order and
        // set the images accordingly 
        if (SortDirection.Ascending.ToString() == strSortOrder_AL)
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }

        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);
    }

    #endregion

    #region "Attachment"

    /// <summary>
    /// Binds the attachment details
    /// </summary>
    private void BindAttachmentDetails()
    {
        //dvAttachment.Style["display"] = "block";
        //AttachDetails.Bind();
    }

    #endregion

    #region " General Methods "
    /// <summary>
    /// Check Whether request is valid or not
    /// </summary>
    private void CheckValidRequest()
    {
        int Location_Id;
        // Check if User has right To Add Equipment or View Equipment
        if (App_Access == AccessType.View_Only & App_Assest_Protection != AccessType.View_Only)
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
    /// Binds Header Info
    /// </summary>
    private void BindHeaderInfo()
    {
        DataTable dtLocationInfo = LU_Location.SelectByPK(LocationID).Tables[0];
        if (dtLocationInfo != null && dtLocationInfo.Rows.Count > 0)
        {
            lblHeaderLocationNumber.Text = "Location Number";
            lblLocation_Number.Text = (dtLocationInfo.Rows[0]["Sonic_Location_Code"].ToString() != "") ? dtLocationInfo.Rows[0]["Sonic_Location_Code"].ToString() : "";
            lblLocationdba.Text = (dtLocationInfo.Rows[0]["dba"].ToString() != "") ? dtLocationInfo.Rows[0]["dba"].ToString() : "";
            lblAddress.Text = (dtLocationInfo.Rows[0]["Address"].ToString() != "") ? dtLocationInfo.Rows[0]["Address"].ToString() : "";
            lblCity.Text = (dtLocationInfo.Rows[0]["City"].ToString() != "") ? dtLocationInfo.Rows[0]["City"].ToString() : "";
            lblState.Text = (dtLocationInfo.Rows[0]["StateName"].ToString() != "") ? dtLocationInfo.Rows[0]["StateName"].ToString() : "";
            lblZip.Text = (dtLocationInfo.Rows[0]["Zip_Code"].ToString() != "") ? dtLocationInfo.Rows[0]["Zip_Code"].ToString() : "";
            hdnLocationdba.Value = lblLocationdba.Text;
        }
    }

    #endregion

    #endregion

    #region Control Events

    #region "Property Security"

    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PropertySecuritySaveData();
        FinancialGrid();
    }

    /// <summary>
    /// Bind Drop Down Items
    /// </summary>
    private void BindDropDownList()
    {
        ComboHelper.FillState(new DropDownList[] { drpFK_CCTV_Company_State, drpFK_Burglar_Alarm_Company_State, drpFK_Guard_Company_State }, 0, true);
        ComboHelper.FillWeekDays(new DropDownList[] { ddlDayMonitoringBegins, ddlDayMonitoringEnds }, 0, true);
        ComboHelper.FillCap_Index_Risk_Category(new DropDownList[] { ddlCap_Index_Risk_Category }, true);
    }

    /// <summary>
    /// Handles Event when CCTV Monitoring Grid add is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddCCTVHoursMonitoringGrid_Click(object sender, EventArgs e)
    {
        gvCCTVHoursMonitoringGrid.EditIndex = -1;
        BindPropertySecurityMonitoringGrid();
        Control control = null;
        PropertySecuritySaveData();
        //tblMainPropertySecurity.Style["display"] = tblMainPropertySecurityView.Style["display"] = dvProperty_SecuritySave.Style["display"] = pnlAddPropertySecurityMonitorGridView.Style["display"] = "none";
        // pnlAddPropertySecurityMonitorGrid.Style["display"] = "";
        // btnAddPSMonitorGird.Visible = true;
        // btnBackPropertySecurity.Visible = true;
        //  btnSave.Visible = false;
        //  btnProperty_SecurityAudit.Visible = false;
        // btnProperty_SecurityAuditView.Visible = false;
        PK_AP_Property_Security_Monitor_Grids = 0;
        StrMonitorGridType = "CCTV";
        gvCCTVHoursMonitoringGrid.Visible = true;
        gvCCTVHoursMonitoringGrid.ShowFooter = true;
        gvCCTVHoursMonitoringGrid.EmptyDataRowStyle.CssClass = "displayBlock";
        BindPropertySecurityMonitoringGrid();
        if (gvCCTVHoursMonitoringGrid.FooterRow != null)
        {
            control = gvCCTVHoursMonitoringGrid.FooterRow;
        }
        else
        {
            control = gvCCTVHoursMonitoringGrid.Controls[0].Controls[0];
        }
        DropDownList ddlTimeBegin = (DropDownList)control.FindControl("ddlDayMonitoringBeginsAdd");
        DropDownList ddlTimeEnd = (DropDownList)control.FindControl("ddlDayMonitoringEndsAdd");
        ComboHelper.FillWeekDays(new DropDownList[] { ddlTimeBegin, ddlTimeEnd }, 0, true);

        // Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "gvMonitoingGrid_RowCommand();", true);
    }

    /// <summary>
    /// Handles Event when Guard Monitoring Grid Add is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddGaurdHoursMonitoredGrid_Click(object sender, EventArgs e)
    {
        Control control = null;
        PropertySecuritySaveData();
        // tblMainPropertySecurity.Style["display"] = tblMainPropertySecurityView.Style["display"] = dvProperty_SecuritySave.Style["display"] = pnlAddPropertySecurityMonitorGridView.Style["display"] = "none";
        //  pnlAddPropertySecurityMonitorGrid.Style["display"] = "";
        // btnAddPSMonitorGird.Visible = true;
        // btnBackPropertySecurity.Visible = true;
        //   btnSave.Visible = false;
        //btnProperty_SecurityAudit.Visible = false;
        //btnProperty_SecurityAuditView.Visible = false;
        PK_AP_Property_Security_Monitor_Grids = 0;
        StrMonitorGridType = "Guard";

        gvGuardHoursMonitorGrid.ShowFooter = true;
        gvGuardHoursMonitorGrid.EmptyDataRowStyle.CssClass = "displayBlock";
        BindPropertySecurityMonitoringGrid();
        if (gvGuardHoursMonitorGrid.FooterRow != null)
        {
            control = gvGuardHoursMonitorGrid.FooterRow;
        }
        else
        {
            control = gvGuardHoursMonitorGrid.Controls[0].Controls[0];
        }
        DropDownList ddlTimeBegin = (DropDownList)control.FindControl("ddlDayMonitoringBeginsAdd");
        DropDownList ddlTimeEnd = (DropDownList)control.FindControl("ddlDayMonitoringEndsAdd");
        ComboHelper.FillWeekDays(new DropDownList[] { ddlTimeBegin, ddlTimeEnd }, 0, true);
        //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    /// <summary>
    /// Handles Event when Off Duty Monitoring Grid Add is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddOffdutyOfficerHoursMonitoredGrid_Click(object sender, EventArgs e)
    {

        Control control = null;
        PropertySecuritySaveData();
        //tblMainPropertySecurity.Style["display"] = tblMainPropertySecurityView.Style["display"] = dvProperty_SecuritySave.Style["display"] = pnlAddPropertySecurityMonitorGridView.Style["display"] = "none";
        //pnlAddPropertySecurityMonitorGrid.Style["display"] = "";
        //btnAddPSMonitorGird.Visible = true;
        //btnBackPropertySecurity.Visible = true;
        //btnSave.Visible = false;
        //btnProperty_SecurityAudit.Visible = false;
        //btnProperty_SecurityAuditView.Visible = false;
        //PK_AP_Property_Security_Monitor_Grids = 0;
        StrMonitorGridType = "Off-Duty Officer";
        gvOffDutyOfficerHoursMonitoredGrid.ShowFooter = true;
        gvOffDutyOfficerHoursMonitoredGrid.EmptyDataRowStyle.CssClass = "displayBlock";
        BindPropertySecurityMonitoringGrid();
        if (gvOffDutyOfficerHoursMonitoredGrid.FooterRow != null)
        {
            control = gvOffDutyOfficerHoursMonitoredGrid.FooterRow;
        }
        else
        {
            control = gvOffDutyOfficerHoursMonitoredGrid.Controls[0].Controls[0];
        }
        DropDownList ddlTimeBegin = (DropDownList)control.FindControl("ddlDayMonitoringBeginsAdd");
        DropDownList ddlTimeEnd = (DropDownList)control.FindControl("ddlDayMonitoringEndsAdd");
        ComboHelper.FillWeekDays(new DropDownList[] { ddlTimeBegin, ddlTimeEnd }, 0, true);
    }

    /// <summary>
    /// Handles Click event of Add Property Security Monitor
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddPSMonitorGird_Click(object sender, EventArgs e)
    {
        clsAP_Property_Security_Monitor_Grids objclsAP_Property_Security_Monitor_Grids = new clsAP_Property_Security_Monitor_Grids();
        objclsAP_Property_Security_Monitor_Grids.PK_AP_Property_Security_Monitor_Grids = PK_AP_Property_Security_Monitor_Grids;
        objclsAP_Property_Security_Monitor_Grids.FK_AP_Property_Security = PK_AP_Property_Security;
        objclsAP_Property_Security_Monitor_Grids.Grid_Type = StrMonitorGridType;
        if (ddlDayMonitoringBegins.SelectedIndex > 0)
            objclsAP_Property_Security_Monitor_Grids.Start_Day = Convert.ToDecimal(ddlDayMonitoringBegins.SelectedValue);
        objclsAP_Property_Security_Monitor_Grids.Start_Time = txtTimeMonitoringBegins.Text;
        if (ddlDayMonitoringEnds.SelectedIndex > 0)
            objclsAP_Property_Security_Monitor_Grids.End_Day = Convert.ToDecimal(ddlDayMonitoringEnds.SelectedValue);
        objclsAP_Property_Security_Monitor_Grids.End_Time = txtTimeMonitoringEnds.Text;
        objclsAP_Property_Security_Monitor_Grids.Hours = txtMonitoringPeriodHours.Text;
        objclsAP_Property_Security_Monitor_Grids.Updated_By = clsSession.UserID;
        objclsAP_Property_Security_Monitor_Grids.Updated_Date = DateTime.Now;

        if (PK_AP_Property_Security_Monitor_Grids > 0)
        {
            objclsAP_Property_Security_Monitor_Grids.Update();
        }
        else
        {
            PK_AP_Property_Security_Monitor_Grids = objclsAP_Property_Security_Monitor_Grids.Insert();
        }

        //Bind Grid
        BindPropertySecurityMonitoringGrid();
        clsAP_Property_Security objPropertySec = new clsAP_Property_Security(PK_AP_Property_Security);
        txttotalHoursMonitoredPerWeek.Text = objPropertySec.Total_Hours_CCTV_Monitored_Per_Week;
        ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    /// <summary>
    /// Handles Click event of btnShowPropertySecurityFromMonitor
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowPropertySecurityFromMonitor_Click(object sender, EventArgs e)
    {
        pnlAddPropertySecurityMonitorGridView.Style["display"] = pnlAddPropertySecurityMonitorGrid.Style["display"] = "none";
        if (StrOperation == "view")
        {
            btnBackPropertySecurityView.Visible = false;
            btnProperty_SecurityAuditView.Visible = true;
            tblMainPropertySecurityView.Style["display"] = "";
        }
        else
        {
            ddlDayMonitoringBegins.ClearSelection();
            ddlDayMonitoringEnds.ClearSelection();
            txtTimeMonitoringBegins.Text = "";
            txtTimeMonitoringEnds.Text = "";
            txtMonitoringPeriodHours.Text = "";
            //btnAddPSMonitorGird.Visible = false;
            btnBackPropertySecurity.Visible = false;
            btnSave.Visible = true;
            btnProperty_SecurityAudit.Visible = true;
            tblMainPropertySecurity.Style["display"] = "";
            dvProperty_SecuritySave.Style["display"] = "";

        }
        ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    protected void txtCap_Index_Crime_Score_TextChanged(object sender, EventArgs e)
    {
        if (txtCap_Index_Crime_Score.Text != string.Empty)
        {
            int intCap_Index_Category_Score_value = clsAP_Property_Security.SelectAP_Cap_Index_Risk_CategorybyScore(Convert.ToInt32(txtCap_Index_Crime_Score.Text));

            if (intCap_Index_Category_Score_value > 0)
            {
                if (ddlCap_Index_Risk_Category.Items.Contains(ddlCap_Index_Risk_Category.Items.FindByValue(intCap_Index_Category_Score_value.ToString())))
                {
                    ddlCap_Index_Risk_Category.SelectedValue = intCap_Index_Category_Score_value.ToString();
                }
                else
                {
                    ddlCap_Index_Risk_Category.ClearSelection();
                }
            }
            else
            {
                ddlCap_Index_Risk_Category.ClearSelection();
            }
        }
        ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:OnChangeFunction();", true);
    }

    //protected void btnSaveFinancialGrid_Click(object sender, EventArgs e)
    //{
    //    FinancialGrid();
    //}

    private void FinancialGrid()
    {
        clsAP_Property_Security_Financials objAP_Property_Security_Financial = new clsAP_Property_Security_Financials();
        decimal decAP_Property_Security_Financial = 0;
        if (PK_AP_Property_Security > 0) decAP_Property_Security_Financial = PK_AP_Property_Security;

        if (decAP_Property_Security_Financial > 0)
        {
            for (int i = 0; i < 6; i++)
            {

                objAP_Property_Security_Financial.FK_AP_Property_Security = decAP_Property_Security_Financial;

                if (i == 0)
                {
                    objAP_Property_Security_Financial.Category = lblCCTVOnly.Text;
                    objAP_Property_Security_Financial.Total_Capex = clsGeneral.GetDecimalNullableValue(txtCCTVOnlyTC);
                    objAP_Property_Security_Financial.Total_Monthly_Charge = clsGeneral.GetDecimalNullableValue(txtCCTVOnlyTM);
                }
                else if (i == 1)
                {
                    objAP_Property_Security_Financial.Category = lblBurglarAlarms.Text;
                    objAP_Property_Security_Financial.Total_Capex = clsGeneral.GetDecimalNullableValue(txtBurglarAlarmsTC);
                    objAP_Property_Security_Financial.Total_Monthly_Charge = clsGeneral.GetDecimalNullableValue(txtBurglarAlarmsTM);
                }

                else if (i == 2)
                {
                    objAP_Property_Security_Financial.Category = lblGuardServices.Text;
                    objAP_Property_Security_Financial.Total_Capex = clsGeneral.GetDecimalNullableValue(txtGuardServicesTC);
                    objAP_Property_Security_Financial.Total_Monthly_Charge = clsGeneral.GetDecimalNullableValue(txtGuardServicesTM);
                }
                else if (i == 3)
                {
                    objAP_Property_Security_Financial.Category = lblAccessControl.Text;
                    objAP_Property_Security_Financial.Total_Capex = clsGeneral.GetDecimalNullableValue(txtAccessControlTC);
                    objAP_Property_Security_Financial.Total_Monthly_Charge = clsGeneral.GetDecimalNullableValue(txtAccessControlTM);
                }
                else if (i == 4)
                {
                    objAP_Property_Security_Financial.Category = lblSecurityInventoryTrackingSystems.Text;
                    objAP_Property_Security_Financial.Total_Capex = clsGeneral.GetDecimalNullableValue(txtSecurityInventoryTrackingSystemsTC);
                    objAP_Property_Security_Financial.Total_Monthly_Charge = clsGeneral.GetDecimalNullableValue(txtSecurityInventoryTrackingSystemsTM);
                }
                else
                {
                    objAP_Property_Security_Financial.Category = lblCategory.Text;
                    objAP_Property_Security_Financial.Total_Capex = clsGeneral.GetDecimalNullableValue(txtCategoryTC);
                    objAP_Property_Security_Financial.Total_Monthly_Charge = clsGeneral.GetDecimalNullableValue(txtCategoryTM);
                }

                objAP_Property_Security_Financial.Update_Date = DateTime.Now;
                objAP_Property_Security_Financial.Updated_By = clsSession.UserID;

                DataSet ds = objAP_Property_Security_Financial.GetAPPropertySecurityFinancialsFromCategory();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    objAP_Property_Security_Financial.PK_AP_Property_Security_Financials = Convert.ToInt32(ds.Tables[0].Rows[0]["PK_AP_Property_Security_Financials"].ToString());
                    objAP_Property_Security_Financial.Update();
                }
                else
                {
                    PK_AP_Property_Security_Financials = objAP_Property_Security_Financial.Insert();
                }
            }
        }
        else
        {
            string str = "<script>alert(\"Please Save Property Security Details First.\");</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);
        }
    }

    private void BindFinancialGridforEdit()
    {
        clsAP_Property_Security_Financials objAP_Property_Security_Financial = new clsAP_Property_Security_Financials();
        decimal decAP_Property_Security_Financial = 0;
        if (PK_AP_Property_Security > 0) decAP_Property_Security_Financial = PK_AP_Property_Security;

        if (decAP_Property_Security_Financial > 0)
        {

            objAP_Property_Security_Financial.FK_AP_Property_Security = decAP_Property_Security_Financial;

            DataSet ds = objAP_Property_Security_Financial.GetAPPropertySecurityFinancialsFromFK();
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                //if (objwc.Total_Paid_To_Date != null) txtTotalPaid.Text = objwc.Total_Paid_To_Date.Value.ToString("N2");
                if (dt.Rows[0]["Category"].ToString() == "CCTV Only")
                {
                    if (dt.Rows[0]["Total_Capex"].ToString() != string.Empty)
                        txtCCTVOnlyTC.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["Total_Capex"]);
                    if (dt.Rows[0]["Total_Monthly_Charge"].ToString() != string.Empty)
                        txtCCTVOnlyTM.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["Total_Monthly_Charge"]);
                }

                if (dt.Rows[1]["Category"].ToString() == "Burglar Alarms")
                {
                    if (dt.Rows[1]["Total_Capex"].ToString() != string.Empty)
                        txtBurglarAlarmsTC.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[1]["Total_Capex"]);
                    if (dt.Rows[1]["Total_Monthly_Charge"].ToString() != string.Empty)
                        txtBurglarAlarmsTM.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[1]["Total_Monthly_Charge"]);
                }

                if (dt.Rows[2]["Category"].ToString() == "Guard Services")
                {
                    if (dt.Rows[2]["Total_Capex"].ToString() != string.Empty)
                        txtGuardServicesTC.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[2]["Total_Capex"]);
                    if (dt.Rows[2]["Total_Monthly_Charge"].ToString() != string.Empty)
                        txtGuardServicesTM.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[2]["Total_Monthly_Charge"]);
                }

                if (dt.Rows[3]["Category"].ToString() == "Access Control")
                {
                    if (dt.Rows[3]["Total_Capex"].ToString() != string.Empty)
                        txtAccessControlTC.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[3]["Total_Capex"]);
                    if (dt.Rows[3]["Total_Monthly_Charge"].ToString() != string.Empty)
                        txtAccessControlTM.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[3]["Total_Monthly_Charge"]);
                }

                if (dt.Rows[4]["Category"].ToString() == "Security Inventory Tracking Systems")
                {
                    if (dt.Rows[4]["Total_Capex"].ToString() != string.Empty)
                        txtSecurityInventoryTrackingSystemsTC.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[4]["Total_Capex"]);
                    if (dt.Rows[4]["Total_Monthly_Charge"].ToString() != string.Empty)
                        txtSecurityInventoryTrackingSystemsTM.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[4]["Total_Monthly_Charge"]);
                }

                if (dt.Rows[5]["Category"].ToString() == "CCTV and Live Monitoring Services")
                {
                    if (dt.Rows[5]["Total_Capex"].ToString() != string.Empty)
                        txtCategoryTC.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[5]["Total_Capex"]);
                    if (dt.Rows[5]["Total_Monthly_Charge"].ToString() != string.Empty)
                        txtCategoryTM.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[5]["Total_Monthly_Charge"]);
                }
            }

        }
        else
        {
            txtCCTVOnlyTC.Text = txtCCTVOnlyTM.Text = txtBurglarAlarmsTC.Text = txtBurglarAlarmsTM.Text = txtGuardServicesTC.Text =
                txtGuardServicesTM.Text = txtAccessControlTC.Text = txtAccessControlTM.Text = txtSecurityInventoryTrackingSystemsTC.Text = txtSecurityInventoryTrackingSystemsTM.Text =
                 txtCategoryTC.Text = txtCategoryTM.Text = string.Empty;
        }

    }

    private void BindFinancialGridforView()
    {
        clsAP_Property_Security_Financials objAP_Property_Security_Financial = new clsAP_Property_Security_Financials();
        decimal decAP_Property_Security_Financial = 0;
        if (PK_AP_Property_Security > 0) decAP_Property_Security_Financial = PK_AP_Property_Security;

        if (decAP_Property_Security_Financial > 0)
        {

            objAP_Property_Security_Financial.FK_AP_Property_Security = decAP_Property_Security_Financial;

            DataSet ds = objAP_Property_Security_Financial.GetAPPropertySecurityFinancialsFromFK();
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Category"].ToString() == "CCTV Only")
                {
                    if (dt.Rows[0]["Total_Capex"].ToString() != string.Empty)
                        lblCCTVOnlyTC.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["Total_Capex"]);
                    if (dt.Rows[0]["Total_Monthly_Charge"].ToString() != string.Empty)
                        lblCCTVOnlyTM.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[0]["Total_Monthly_Charge"]);
                }

                if (dt.Rows[1]["Category"].ToString() == "Burglar Alarms")
                {
                    if (dt.Rows[1]["Total_Capex"].ToString() != string.Empty)
                        lblBurglarAlarmsTC.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[1]["Total_Capex"]);
                    if (dt.Rows[1]["Total_Monthly_Charge"].ToString() != string.Empty)
                        lblBurglarAlarmsTM.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[1]["Total_Monthly_Charge"]);
                }

                if (dt.Rows[2]["Category"].ToString() == "Guard Services")
                {
                    if (dt.Rows[2]["Total_Capex"].ToString() != string.Empty)
                        lblGuardServicesTC.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[2]["Total_Capex"]);
                    if (dt.Rows[2]["Total_Monthly_Charge"].ToString() != string.Empty)
                        lblGuardServicesTM.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[2]["Total_Monthly_Charge"]);
                }

                if (dt.Rows[3]["Category"].ToString() == "Access Control")
                {
                    if (dt.Rows[3]["Total_Capex"].ToString() != string.Empty)
                        lblAccessControlTC.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[3]["Total_Capex"]);
                    if (dt.Rows[3]["Total_Monthly_Charge"].ToString() != string.Empty)
                        lblAccessControlTM.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[3]["Total_Monthly_Charge"]);
                }

                if (dt.Rows[4]["Category"].ToString() == "Security Inventory Tracking Systems")
                {
                    if (dt.Rows[4]["Total_Capex"].ToString() != string.Empty)
                        lblSecurityInventoryTrackingSystemsTC.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[4]["Total_Capex"]);
                    if (dt.Rows[4]["Total_Monthly_Charge"].ToString() != string.Empty)
                        lblSecurityInventoryTrackingSystemsTM.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[4]["Total_Monthly_Charge"]);
                }


                if (dt.Rows[5]["Category"].ToString() == "CCTV and Live Monitoring Services")
                {
                    if (dt.Rows[5]["Total_Capex"].ToString() != string.Empty)
                        lblCategoryTC.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[5]["Total_Capex"]);
                    if (dt.Rows[5]["Total_Monthly_Charge"].ToString() != string.Empty)
                        lblCategoryTM.Text = clsGeneral.FormatCommaSeperatorCurrency(dt.Rows[5]["Total_Monthly_Charge"]);
                }

            }


        }
        else
        {
            lblCCTVOnlyTC.Text = lblCCTVOnlyTM.Text = lblBurglarAlarmsTC.Text =
                lblBurglarAlarmsTM.Text = lblGuardServicesTC.Text = lblGuardServicesTM.Text = lblAccessControlTC.Text = lblAccessControlTM.Text =
                lblSecurityInventoryTrackingSystemsTC.Text = lblSecurityInventoryTrackingSystemsTM.Text = lblCategoryTC.Text = lblCategoryTM.Text = string.Empty;
        }

    }

    //protected void btnCancelFinancialGrid_Click(object sender, EventArgs e)
    //{
    //    txtCCTVOnlyTC.Text = string.Empty;
    //    txtCCTVOnlyTM.Text = string.Empty;
    //    txtBurglarAlarmsTC.Text = string.Empty;
    //    txtBurglarAlarmsTM.Text = string.Empty;
    //    txtCategoryTC.Text = string.Empty;
    //    txtCategoryTM.Text = string.Empty;
    //    txtGuardServicesTC.Text = string.Empty;
    //    txtGuardServicesTM.Text = string.Empty;
    //    txtAccessControlTC.Text = string.Empty;
    //    txtAccessControlTM.Text = string.Empty;
    //    txtSecurityInventoryTrackingSystemsTC.Text = string.Empty;
    //    txtSecurityInventoryTrackingSystemsTM.Text = string.Empty;
    //}
    protected void btnViewAuditFinancialGrid_Click(object sender, EventArgs e)
    {

    }

    protected void lnkAddFraudNotesGrid_Click(object sender, EventArgs e)
    {
        btnNotesGridAdd.Visible = false;
        btnFraudNotesGridAdd.Visible = true;

        tblMainFraudEvent.Style["display"] = tblMainFraudEventView.Style["display"] = pnlTransactionGridAdd.Style["display"] = pnlNoteGridAddView.Style["display"] = pnlTransactionGridAddView.Style["display"] = "none";
        pnlNoteGridAdd.Style["display"] = "";
        PK_AP_FE_PA_Notes = 0;
        btnViewAuditNotesGrid.Visible = false;
        btnFraudEventSave.Visible = false;
        btnFruad_EventAudit_Trail.Visible = false;
        dvFraudEventSave.Style["display"] = "none";

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);

    }

    protected void btnFraudNotesGridAdd_Click(object sender, EventArgs e)
    {
        AP_FE_PA_Notes AP_FE_PA_Notes = new AP_FE_PA_Notes();

        AP_FE_PA_Notes.PK_AP_FE_PA_Notes = PK_AP_FE_PA_Notes;
        AP_FE_PA_Notes.FK_AP_Fraud_Events = PK_AP_Fraud_Events;
        AP_FE_PA_Notes.Note_Date = clsGeneral.FormatNullDateToStore(txtNotesDate.Text);
        AP_FE_PA_Notes.Note = txtNotesAdd.Text;
        AP_FE_PA_Notes.Update_Date = DateTime.Now;
        AP_FE_PA_Notes.Updated_By = clsSession.UserID;

        if (PK_AP_FE_PA_Notes > 0)
        {
            AP_FE_PA_Notes.Update();
        }
        else
        {
            PK_AP_FE_PA_Notes = AP_FE_PA_Notes.Insert();
        }

        //ClearAddGridControl();
        btnViewAuditNotesGrid.Visible = false;
        btnViewFraudAuditNotesGrid.Visible = true;
        BindFraudNotesGrid();
        ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        BindHeaderInfo();

        dvAL_Save.Style["display"] = "none";
        dvDPD_Save.Style["display"] = "none";
        tblMainPropertySecurityGrid.Style["display"] = "";
        tblMainPropertySecurity.Style["display"] = "none";
        dvProperty_SecuritySave.Style["display"] = "none";
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
    protected void btnProperty_SecurityCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Asset_Protection.aspx?loc=" + Request.QueryString["loc"] + "&pnl=" + hdnPanel.Value + "&op=view");
    }

    protected void rdoBuglar_Alarm_System_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShoHideCameraRow();
        //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    #endregion

    #region " DPD_FROIs "

    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDPD_FROIsSave_Click(object sender, EventArgs e)
    {
        clsAP_DPD_FROIs ObjAP_DPD_FROIs = new clsAP_DPD_FROIs();
        ObjAP_DPD_FROIs.PK_AP_DPD_FROIs = PK_AP_DPD_FROIs;

        ObjAP_DPD_FROIs.FK_LU_Location = LocationID;

        ObjAP_DPD_FROIs.FK_DPD_FR = FK_DPD_FR_ID;
        ObjAP_DPD_FROIs.FK_DPD_FR_Vehicle_ID = FK_DPD_FR_Vehicle_ID;

        ObjAP_DPD_FROIs.Third_Party_Vendor_Related_Theft = chk3rd_Party_Vendor_Related_Theft.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Access_Control_Failures = chkAccess_Control_Failures.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Breaking_And_Entering = chkBreaking_and_Entering.Checked ? "Y" : "N";

        ObjAP_DPD_FROIs.Burglar_Alarm_Failure = chkBurglar_Alarm_Failure.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Camera_Dead_Spot = chkCamera_Dead_Spot.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.CCTV_Monitoring_Failure = chkCCTV_Monitoring_Failure.Checked ? "Y" : "N";

        ObjAP_DPD_FROIs.CCTV_Monitoring_Failure_By_Operator = chkCCTV_Monitoring_Failure_byOperator.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Design_Weakness_Property_Protection = chkDesign_weakness_Property_Protection.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Environmental_Obstruction_and_or_Condition_Camera = chkEnvironmental_Obstruction_ConditionCamera.Checked ? "Y" : "N";

        ObjAP_DPD_FROIs.Failure_to_Report_and_or_Late_Report = chkFailure_to_ReportLate_Report.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Key_Swap = chkKey_Swap.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Lighting_Deficiencies = chkLighting_Deficiencies.Checked ? "Y" : "N";

        ObjAP_DPD_FROIs.Lock_Box_Not_Properly_Secured = chkLockBox_Not_Properly_Secured.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Negligence_Lack_of_key_Control_Program_Unattended_Keys = chkNegligence_Lackof_Key_Control_Program_Unattended_Keys.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Non_Permissible_User_of_Taking_Vehicle = chkNonPermissible_User_of_TakingVehicle.Checked ? "Y" : "N";

        ObjAP_DPD_FROIs.Power_Outage = chkPower_Outage.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Security_Guard_Failure = chkSecurity_Guard_Failure.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Stolen_Id = chkStolen_Id.Checked ? "Y" : "N";

        ObjAP_DPD_FROIs.Theft_By_Deception = chkTheft_by_Deception.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Unauthorized_Building_Entry_Forcible = chkUnauthorized_Building_Entry_Forcible.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Unauthorized_Building_Entry_Unlocked = chkUnauthorized_Building_Entry_Unlocked.Checked ? "Y" : "N";

        ObjAP_DPD_FROIs.Unauthorized_Vehicle_Entry_Forcible = chkUnauthorized_Vehicle_Entry_Forcible.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Unauthorized_Vehicle_Entry_Unlocked = chkUnauthorized_Vehicle_Entry_Unlocked.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Vehicle_Taken_By_Tow_Truck = chkVehicle_Takenby_Tow_Truck.Checked ? "Y" : "N";

        ObjAP_DPD_FROIs.Weather_Related_Damage_and_or_Loss = chkWeather_Related_DamageLoss.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Other_Describe = chkOther_Describe.Checked ? "Y" : "N";

        if (txtInvestigatingPoliceDepartment.Text != "") ObjAP_DPD_FROIs.Investigating_Police_Department = txtInvestigatingPoliceDepartment.Text;
        if (txtVehicleColor.Text != "") ObjAP_DPD_FROIs.Vehicle_Color = txtVehicleColor.Text;
        if (txtPoliceCaseNumber.Text != "") ObjAP_DPD_FROIs.Police_Case_Number = txtPoliceCaseNumber.Text;

        ObjAP_DPD_FROIs.Vandalism = chkVandalism.Checked ? "Y" : "N";
        ObjAP_DPD_FROIs.Lock_Box_Stolen_Removed = chkLockBox.Checked ? "Y" : "N";

        if (txtInvestigation_Finding_Other_Description.Text != "") ObjAP_DPD_FROIs.Investigation_Finding_Other_Description = txtInvestigation_Finding_Other_Description.Text;
        else ObjAP_DPD_FROIs.Investigation_Finding_Other_Description = "";
        if (txtRoot_Cause.Text != "") ObjAP_DPD_FROIs.Root_Cause = txtRoot_Cause.Text;
        if (txtIncident_Prevention.Text != "") ObjAP_DPD_FROIs.Incident_Prevention = txtIncident_Prevention.Text;
        if (txtPerson_Tasked.Text != "") ObjAP_DPD_FROIs.Person_Tasked = txtPerson_Tasked.Text;
        if (txtTarget_Date_of_Completion.Text != "") ObjAP_DPD_FROIs.Target_Date_of_Completion = clsGeneral.FormatDateToStore(txtTarget_Date_of_Completion.Text);
        if (txtStatus_Due_On.Text != "") ObjAP_DPD_FROIs.Status_Due_On = clsGeneral.FormatDateToStore(txtStatus_Due_On.Text);
        if (txtComments.Text != "") ObjAP_DPD_FROIs.Comments = txtComments.Text;
        if (txtFinancial_Loss.Text != "") ObjAP_DPD_FROIs.Financial_Loss = Convert.ToDecimal(txtFinancial_Loss.Text);
        if (txtRecovery.Text != "") ObjAP_DPD_FROIs.Recovery = Convert.ToDecimal(txtRecovery.Text);
        if (drpItem_Status.SelectedIndex > 0)
        {
            ObjAP_DPD_FROIs.Item_Status = drpItem_Status.SelectedItem.Text == "Open" ? "O" : "C";
        }
        ObjAP_DPD_FROIs.Updated_By = clsSession.UserName;
        ObjAP_DPD_FROIs.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);

        if (PK_AP_DPD_FROIs > 0)
            ObjAP_DPD_FROIs.Update();
        else
            PK_AP_DPD_FROIs = ObjAP_DPD_FROIs.Insert();

        if (PK_AP_DPD_FROIs > 0)
            btnDPD_FROIsAudit_Trail.Visible = true;
        else
            btnDPD_FROIsAudit_Trail.Visible = false;

        if (PK_AP_DPD_FROIs > 0)
        {
            ctrlAPNotes_DPD.Location_ID = Convert.ToInt32(LocationID);
            ctrlAPNotes_DPD.PK_DPD_Claims_ID = Convert.ToInt32(PK_DPD_Claims_ID);
            ctrlAPNotes_DPD.CurrentClaimType = "AP_DPD_FROIs";
            ctrlAPNotes_DPD.BindGridSonicNotes(PK_AP_DPD_FROIs, "AP_DPD_FROIs");

            if (!string.IsNullOrEmpty(AP_DPD_FROIs_CommandArgs))
            {
                string[] arg = new string[4];
                arg = AP_DPD_FROIs_CommandArgs.Split(';');
                arg[1] = Convert.ToString(PK_AP_DPD_FROIs);
                AP_DPD_FROIs_CommandArgs = string.Join(";", arg);
            }
        }

        BindAP_DPD_FROIs_Grid(CtrlPagingDPD_FROIs.CurrentPage, CtrlPagingDPD_FROIs.PageSize);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }

    /// <summary>
    /// Dropdown Selected Index changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdoDPD_FROIs_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindAP_DPD_FROIs_Grid(CtrlPagingDPD_FROIs.CurrentPage, CtrlPagingDPD_FROIs.PageSize);

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPageDPD_FROIs()
    {
        if (StrOperation.ToLower() == "view")
        {
            BindAP_DPD_FROIs_Grid(CtrlPagingDPD_FROIsView.CurrentPage, CtrlPagingDPD_FROIsView.PageSize);
        }
        else
            BindAP_DPD_FROIs_Grid(CtrlPagingDPD_FROIs.CurrentPage, CtrlPagingDPD_FROIs.PageSize);

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }

    #endregion

    #region "AL_FROI"

    /// <summary>
    /// Save Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAL_Save_Click(object sender, EventArgs e)
    {
        clsAP_AL_FROIs ObjAP_AL_FROIs = new clsAP_AL_FROIs();
        ObjAP_AL_FROIs.PK_AP_AL_FROIs = PK_AP_AL_FROIs;

        ObjAP_AL_FROIs.FK_LU_Location = LocationID;
        ObjAP_AL_FROIs.FK_AL_FR = FK_AL_FR_ID;
        ObjAP_AL_FROIs.Third_Party_Vendor_Related_Theft = chkAL_3rd_Party_Vendor_Related_Theft.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Access_Control_Failures = chkAL_Access_Control_Failures.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Breaking_And_Entering = chkAL_Breaking_and_Entering.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Burglar_Alarm_Failure = chkAL_Burglar_Alarm_Failure.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Camera_Dead_Spot = chkAL_Camera_Dead_Spot.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.CCTV_Monitoring_Failure = chkAL_CCTV_Monitoring_Failure.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.CCTV_Monitoring_Failure_By_Operator = chkAL_CCTV_Monitoring_Failure_byOperator.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Design_Weakness_Property_Protection = chkAL_Design_weakness_Property_Protection.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Environmental_Obstruction_and_or_Condition_Camera = chkAL_Environmental_Obstruction_ConditionCamera.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Failure_to_Report_and_or_Late_Report = chkAL_Failure_to_ReportLate_Report.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Key_Swap = chkAL_Key_Swap.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Lighting_Deficiencies = chkAL_Lighting_Deficiencies.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Lock_Box_Not_Properly_Secured = chkAL_LockBox_Not_Properly_Secured.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Negligence_Lack_of_key_Control_Program_Unattended_Keys = chkAL_Negligence_Lackof_Key_Control_Program_Unattended_Keys.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Non_Permissible_User_of_Taking_Vehicle = chkAL_NonPermissible_User_of_TakingVehicle.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Power_Outage = chkAL_Power_Outage.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Security_Guard_Failure = chkAL_Security_Guard_Failure.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Stolen_Id = chkAL_Stolen_Id.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Theft_By_Deception = chkAL_Theft_by_Deception.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Unauthorized_Building_Entry_Forcible = chkAL_Unauthorized_Building_Entry_Forcible.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Unauthorized_Building_Entry_Unlocked = chkAL_Unauthorized_Building_Entry_Unlocked.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Unauthorized_Vehicle_Entry_Forcible = chkAL_Unauthorized_Vehicle_Entry_Forcible.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Unauthorized_Vehicle_Entry_Unlocked = chkAL_Unauthorized_Vehicle_Entry_Unlocked.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Vehicle_Taken_By_Tow_Truck = chkAL_Vehicle_Takenby_Tow_Truck.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Weather_Related_Damage_and_or_Loss = chkAL_Weather_Related_DamageLoss.Checked ? "Y" : "N";
        ObjAP_AL_FROIs.Other_Describe = chkAL_Other_Describe.Checked ? "Y" : "N";
        if (txtAL_Investigation_Finding.Text != "")
            ObjAP_AL_FROIs.Investigation_Finding_Other_Description = txtAL_Investigation_Finding.Text;
        else
            ObjAP_AL_FROIs.Investigation_Finding_Other_Description = "";
        if (txtAL_Root_Cause.Text != "")
            ObjAP_AL_FROIs.Root_Cause = txtAL_Root_Cause.Text;
        else
            ObjAP_AL_FROIs.Root_Cause = "";
        if (txtAL_Incident_Prevention.Text != "")
            ObjAP_AL_FROIs.Incident_Prevention = txtAL_Incident_Prevention.Text;
        else
            ObjAP_AL_FROIs.Incident_Prevention = "";
        if (txtAL_Person_Tasked.Text != "")
            ObjAP_AL_FROIs.Person_Tasked = txtAL_Person_Tasked.Text;
        else
            ObjAP_AL_FROIs.Person_Tasked = "";
        if (txtAL_Target_Date_of_Completion.Text != "")
            ObjAP_AL_FROIs.Target_Date_of_Completion = clsGeneral.FormatDateToStore(txtAL_Target_Date_of_Completion.Text);
        if (txtAL_Status_Due_On.Text != "")
            ObjAP_AL_FROIs.Status_Due_On = clsGeneral.FormatDateToStore(txtAL_Status_Due_On.Text);
        if (txtAL_Comments.Text != "")
            ObjAP_AL_FROIs.Comments = txtAL_Comments.Text;
        else
            ObjAP_AL_FROIs.Comments = "";

        if (txtAL_Financial_Loss.Text != "") ObjAP_AL_FROIs.Financial_Loss = Convert.ToDecimal(txtAL_Financial_Loss.Text);
        if (txtAL_Recovery.Text != "") ObjAP_AL_FROIs.Recovery = Convert.ToDecimal(txtAL_Recovery.Text);
        if (drpAL_Item_Status.SelectedIndex > 0)
        {
            ObjAP_AL_FROIs.Item_Status = drpAL_Item_Status.SelectedItem.Text == "Open" ? "O" : "C";
        }


        ObjAP_AL_FROIs.Updated_By = clsSession.UserID;
        ObjAP_AL_FROIs.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);

        if (PK_AP_AL_FROIs > 0)
            ObjAP_AL_FROIs.Update();
        else
            PK_AP_AL_FROIs = ObjAP_AL_FROIs.Insert();

        if (PK_AP_AL_FROIs > 0)
            btnAL_ViewAuditTrail.Visible = true;
        else
            btnAL_ViewAuditTrail.Visible = false;


        if (PK_AP_AL_FROIs > 0)
        {
            ctrlAPNotes_AL.Location_ID = Convert.ToInt32(LocationID);
            ctrlAPNotes_AL.PK_AL_CI_ID = Convert.ToInt32(PK_Auto_Loss_Claims_ID);
            ctrlAPNotes_AL.CurrentClaimType = "AP_AL_FROIs";
            ctrlAPNotes_AL.BindGridSonicNotes(PK_AP_AL_FROIs, "AP_AL_FROIs");

            if (!string.IsNullOrEmpty(AP_AL_FROIs_CommandArgs))
            {
                string[] arg = new string[4];
                arg = AP_AL_FROIs_CommandArgs.Split(';');
                arg[1] = Convert.ToString(PK_AP_AL_FROIs);
                AP_AL_FROIs_CommandArgs = string.Join(";", arg);
            }
        }

        BindAP_AL_FROIs_Grid(CtrlPagingAL_FROIs.CurrentPage, CtrlPagingAL_FROIs.PageSize);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }

    /// <summary>
    /// Index Changed Event of Radio Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdoAL_FROIs_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (StrOperation.ToLower() == "view")
        {
            BindAP_AL_FROIs_Grid(CtrlPagingAL_FROIsView.CurrentPage, CtrlPagingAL_FROIsView.PageSize);
        }
        else
        {
            BindAP_AL_FROIs_Grid(CtrlPagingAL_FROIs.CurrentPage, CtrlPagingAL_FROIs.PageSize);
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPageFROIs_AL()
    {
        if (StrOperation.ToLower() != "view")
        {
            BindAP_AL_FROIs_Grid(CtrlPagingAL_FROIs.CurrentPage, CtrlPagingAL_FROIs.PageSize);
        }
        else
        {
            BindAP_AL_FROIs_Grid(CtrlPagingAL_FROIsView.CurrentPage, CtrlPagingAL_FROIsView.PageSize);
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }

    #endregion

    #region "Cal- Atlantic"

    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCalAtlanicSave_Click(object sender, EventArgs e)
    {
        if (FK_Event > 0)
        {
            SaveCal_AtlanticData();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please select Event.');", true);

        }

    }

    /// <summary>
    /// View Cal - Atlantic Data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnViewCalatlanticData_Click(Object sender, EventArgs e)
    {
        if (FK_Event > 0)
        {
            clsSession.LocationID = LocationID;
            Response.Redirect(AppConfig.SiteURL + "SONIC/CalAtlantic/Event.aspx?eid=" + Encryption.Encrypt(FK_Event.ToString()) + "&loc=" + Encryption.Encrypt(LocationID.ToString()));
        }
    }

    /// <summary>
    /// If user change Insurance Claim type
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rblInsuranceClaimType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblInsuranceClaimType.SelectedItem.Text == "Auto Liability")
            bindFROIDropdown("AL");
        else if (rblInsuranceClaimType.SelectedItem.Text == "DPD")
            bindFROIDropdown("DPD");
        else if (rblInsuranceClaimType.SelectedItem.Text == "Premises Liability")
            bindFROIDropdown("PL");
        else if (rblInsuranceClaimType.SelectedItem.Text == "Property Damage")
            bindFROIDropdown("Property");

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
    }

    /// <summary>
    /// Index Changed Event of Radio Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rbtnlEvent_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCalAtlanticEventGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPageAP_Calatlantic()
    {
        BindCalAtlanticEventGrid();
    }

    #endregion

    #region "Fraud Events"

    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFraudEventSave_Click(object sender, EventArgs e)
    {
        FraudEventSaveData();

    }

    /// <summary>
    /// Handles Event when Financial Transaction add is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <summary>
    /// Handles Event when Financial Transaction add is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddFinancialGrid_Click(object sender, EventArgs e)
    {
        FraudEventSaveData();
        tblMainFraudEvent.Style["display"] = tblMainFraudEventView.Style["display"] = pnlNoteGridAdd.Style["display"] = pnlNoteGridAddView.Style["display"] = pnlTransactionGridAddView.Style["display"] = "none";
        pnlTransactionGridAdd.Style["display"] = "";
        btnViewAuditTransactionGrid.Visible = false;
        btnFraudEventSave.Visible = false;
        btnFruad_EventAudit_Trail.Visible = false;
        PK_AP_FE_Transactions = 0;
        dvFraudEventSave.Style["display"] = "none";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Back From transaction Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBackFraudEventFromTransaction_Click(object sender, EventArgs e)
    {
        ClearAddGridControl();
        dvFraudEventSave.Style["display"] = "";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Handles Event when Notes Grid add is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddNotesGrid_Click(object sender, EventArgs e)
    {
        btnNotesGridAdd.Visible = true;
        btnFraudNotesGridAdd.Visible = false;

        FraudEventSaveData();


        tblMainFraudEvent.Style["display"] = tblMainFraudEventView.Style["display"] = pnlTransactionGridAdd.Style["display"] = pnlNoteGridAddView.Style["display"] = pnlTransactionGridAddView.Style["display"] = "none";
        pnlNoteGridAdd.Style["display"] = "";
        PK_AP_FE_Notes = 0;
        btnViewAuditNotesGrid.Visible = false;
        btnFraudEventSave.Visible = false;
        btnFruad_EventAudit_Trail.Visible = false;
        dvFraudEventSave.Style["display"] = "none";

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Handles Save button click in Fraud Transaction Panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnTransactionGridAdd_Click(object sender, EventArgs e)
    {
        clsAP_FE_Transactions objclsAP_FE_Transactions = new clsAP_FE_Transactions();
        objclsAP_FE_Transactions.PK_AP_FE_Transactions = PK_AP_FE_Transactions;
        objclsAP_FE_Transactions.FK_AP_Fraud_Events = PK_AP_Fraud_Events;
        objclsAP_FE_Transactions.FK_LU_Transaction_Type = ddlTransactionType.SelectedIndex > 0 ? Convert.ToDecimal(ddlTransactionType.SelectedValue) : 0;
        objclsAP_FE_Transactions.FK_LU_Transaction_Category = ddlTransactionCatagory.SelectedIndex > 0 ? Convert.ToDecimal(ddlTransactionCatagory.SelectedValue) : 0;
        if (txtTransactionDate.Text != "")
            objclsAP_FE_Transactions.Transaction_Date = clsGeneral.FormatNullDateToStore(txtTransactionDate.Text);
        if (txtTransactionAmount.Text != "")
            objclsAP_FE_Transactions.Transaction_Amount = Convert.ToDecimal(txtTransactionAmount.Text);
        objclsAP_FE_Transactions.Update_Date = DateTime.Now;
        objclsAP_FE_Transactions.Updated_By = clsSession.UserID;
        if (PK_AP_FE_Transactions > 0)
        {
            objclsAP_FE_Transactions.Update();
        }
        else
        {
            PK_AP_FE_Transactions = objclsAP_FE_Transactions.Insert();
        }

        //ClearAddGridControl();
        BindTransactionGrid();
        BindFinancialMatrix();
        btnViewAuditTransactionGrid.Visible = true;
        ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);

    }

    /// <summary>
    /// Save New Note Data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNotesGridAdd_Click(object sender, EventArgs e)
    {
        clsAP_FE_Notes objclsAP_FE_Notes = new clsAP_FE_Notes();

        objclsAP_FE_Notes.PK_AP_FE_Notes = PK_AP_FE_Notes;
        objclsAP_FE_Notes.FK_AP_Fraud_Events = PK_AP_Fraud_Events;
        objclsAP_FE_Notes.Note_Date = clsGeneral.FormatNullDateToStore(txtNotesDate.Text);
        objclsAP_FE_Notes.Note = txtNotesAdd.Text;
        objclsAP_FE_Notes.Update_Date = DateTime.Now;
        objclsAP_FE_Notes.Updated_By = clsSession.UserID;

        if (PK_AP_FE_Notes > 0)
        {
            objclsAP_FE_Notes.Update();
        }
        else
        {
            PK_AP_FE_Notes = objclsAP_FE_Notes.Insert();
        }

        //ClearAddGridControl();
        btnViewAuditNotesGrid.Visible = true;
        btnViewFraudAuditNotesGrid.Visible = false;
        BindNotesGrid();
        ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Index Changed Event of Radio Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdoFraud_EventTo_Include_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindFraudEventGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPageFROIs_Fraud()
    {
        BindFraudEventGrid();
    }

    /// <summary>
    /// Add new Fraud Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFraudEventAdd_Click(object sender, EventArgs e)
    {
        PK_AP_Fraud_Events = 0;
        //clearControls();
        BindDetailsForEdit_FraudEvents();
        BindDropDowns();
        dvView.Style["display"] = "none";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    #endregion

    #region " General Events "
    /// <summary>
    /// Handles back button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Asset_Protection.aspx?id=" + Encryption.Encrypt(PK_AP_Property_Security.ToString()) + "&loc=" + Request.QueryString["loc"] + "&pnl=" + hdnPanel.Value + "&op=edit");
    }

    /// <summary>
    /// To enable View mode of page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReturnto_View_Mode_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("Asset_Protection.aspx?id=" + Encryption.Encrypt(PK_AP_Property_Security.ToString()) + "&loc=" + Request.QueryString["loc"] + "&pnl=" + hdnPanel.Value + "&op=view");
    }

    /// <summary>
    /// handles Add Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddAttachment_Click(string sender)
    {
        if (PK_AP_Property_Security > 0)
        {
            // add attachment if any.
            Attachments.Location_ID = Convert.ToInt32(LocationID);
            //Attachments.Add();
            // Bind the attachment detail to view the added attachment
            BindAttachmentDetails();
            // show attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "javascript:alert('Please save the Property Security Information first');", true);
        }
    }
    #endregion

    #endregion

    #region Grid Events

    #region " Property Security "

    /// <summary>
    /// Handles gvNotesGrid grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMonitoingGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        GridView gridView = ((GridView)sender);
        String grid = gridView.ID;

        if (grid == "gvCCTVHoursMonitoringGrid")
        {
            StrMonitorGridType = "CCTV";

        }
        else if (grid == "gvGuardHoursMonitorGrid")
        {
            StrMonitorGridType = "Guard";

        }
        else
        {
            StrMonitorGridType = "Off-Duty Officer";
            //grid = gvOffDutyOfficerHoursMonitoredGrid;
        }


        if (e.CommandName == "gvEdit")
        {
            PK_AP_Property_Security_Monitor_Grids = Convert.ToDecimal(e.CommandArgument.ToString());
            if (PK_AP_Property_Security_Monitor_Grids > 0)
            {
                tblMainPropertySecurity.Style["display"] = tblMainPropertySecurityView.Style["display"] =
                    // dvProperty_SecuritySavelnkbtnDayMonitoringBegins.Style["display"] = 
               pnlAddPropertySecurityMonitorGrid.Style["display"] = pnlAddPropertySecurityMonitorGridView.Style["display"] = "none";
                //if (StrOperation == "view")
                //{

                //    btnBackPropertySecurityView.Visible = true;
                //    pnlAddPropertySecurityMonitorGridView.Style["display"] = "";
                //}
                //else

                //btnAddPSMonitorGird.Visible = true;
                //  btnBackPropertySecurity.Visible = true;
                //    pnlAddPropertySecurityMonitorGrid.Style["display"] = "";


                bindPropertyMonitoringDetailForEdit(PK_AP_Property_Security_Monitor_Grids);
            }

        }
        else if (e.CommandName == "Remove")
        {
            index = Convert.ToInt32(e.CommandArgument);
            clsAP_Property_Security_Monitor_Grids.DeleteByPK(index);

            BindPropertySecurityMonitoringGrid();
            clsAP_Property_Security objPropertySec = new clsAP_Property_Security(PK_AP_Property_Security);
            txttotalHoursMonitoredPerWeek.Text = objPropertySec.Total_Hours_CCTV_Monitored_Per_Week;

        }
        else if (e.CommandName == "gvAdd")
        {
            GridView grid1;
            Control control = null;
            if (StrMonitorGridType == "CCTV")
            {
                grid1 = gvCCTVHoursMonitoringGrid;
            }
            else if (StrMonitorGridType == "Guard")
            {
                grid1 = gvGuardHoursMonitorGrid;
            }
            else
            {
                grid1 = gvOffDutyOfficerHoursMonitoredGrid;
            }
            if (grid1.FooterRow != null)
            {
                control = grid1.FooterRow;
            }
            else
            {
                control = grid1.Controls[0].Controls[0];
            }

            TextBox txtTimeBegin = (TextBox)control.FindControl("txtTimeMonitoringBeginsAdd");
            TextBox txtTimeEnd = (TextBox)control.FindControl("txtTimeMonitoringEndsAdd");

            DropDownList ddlTimeBegin = (DropDownList)control.FindControl("ddlDayMonitoringBeginsAdd");
            string valBegin = ddlTimeBegin.SelectedValue;

            DropDownList ddlTimeEnd = (DropDownList)control.FindControl("ddlDayMonitoringEndsAdd");
            string valEnd = ddlTimeEnd.SelectedValue;
            TextBox txtTimeHours = (TextBox)control.FindControl("txtMonitoringPeriodHoursAdd");


            clsAP_Property_Security_Monitor_Grids objclsAP_Property_Security_Monitor_Grids = new clsAP_Property_Security_Monitor_Grids();
            objclsAP_Property_Security_Monitor_Grids.PK_AP_Property_Security_Monitor_Grids = PK_AP_Property_Security_Monitor_Grids;
            objclsAP_Property_Security_Monitor_Grids.FK_AP_Property_Security = PK_AP_Property_Security;
            objclsAP_Property_Security_Monitor_Grids.Grid_Type = StrMonitorGridType;

            objclsAP_Property_Security_Monitor_Grids.Start_Day = Convert.ToDecimal(valBegin);
            objclsAP_Property_Security_Monitor_Grids.Start_Time = txtTimeBegin.Text;

            objclsAP_Property_Security_Monitor_Grids.End_Day = Convert.ToDecimal(valEnd);
            objclsAP_Property_Security_Monitor_Grids.End_Time = txtTimeEnd.Text;
            objclsAP_Property_Security_Monitor_Grids.Hours = txtTimeHours.Text;
            objclsAP_Property_Security_Monitor_Grids.Updated_By = clsSession.UserID;
            objclsAP_Property_Security_Monitor_Grids.Updated_Date = DateTime.Now;

            PK_AP_Property_Security_Monitor_Grids = objclsAP_Property_Security_Monitor_Grids.Insert();

            grid1.ShowFooter = false;

            clsAP_Property_Security objPropertySec = new clsAP_Property_Security(PK_AP_Property_Security);
            txttotalHoursMonitoredPerWeek.Text = objPropertySec.Total_Hours_CCTV_Monitored_Per_Week;
            grid1.EditIndex = -1;
            BindPropertySecurityMonitoringGrid();

        }
        //else if (e.CommandName == "gvCancel")
        //{
        //    grid.EditIndex = -1;
        //    BindPropertySecurityMonitoringGrid();
        //}
        //else if(e.CommandName == "Edit")
        //{
        //  grid.ShowFooter = false;

        //    grid.EditIndex = RowIndex;
        //    BindPropertySecurityMonitoringGrid();

        //     ddlTimeBegin = (DropDownList)grid.Rows[RowIndex].Cells[0].FindControl("ddlDayMonitoringBegins");

        //    ddlTimeEnd = (DropDownList)grid.Rows[RowIndex].Cells[0].FindControl("ddlDayMonitoringEnds");
        //    ComboHelper.FillWeekDays(new DropDownList[] { ddlTimeBegin, ddlTimeEnd }, 0, true);
        //    decimal id = Convert.ToDecimal(grid.DataKeys[RowIndex].Values["PK_AP_Property_Security_Monitor_Grids"].ToString());
        //    clsAP_Property_Security_Monitor_Grids objclsAP_Property_Security_Monitor_Grids = new clsAP_Property_Security_Monitor_Grids(id);
        //    ddlTimeBegin.SelectedIndex = Convert.ToInt32(objclsAP_Property_Security_Monitor_Grids.Start_Day);
        //    ddlTimeEnd.SelectedIndex = Convert.ToInt32(objclsAP_Property_Security_Monitor_Grids.End_Day);
        //}
        //else if (e.CommandName == "gvUpdate")
        //{

        //    TextBox txtTimeBegin = grid.Rows[RowIndex].FindControl("txtTimeMonitoringBegins") as TextBox;
        //    TextBox txtTimeEnd = grid.Rows[RowIndex].FindControl("txtTimeMonitoringEnds") as TextBox;
        //    int id = Convert.ToInt32(grid.DataKeys[RowIndex].Values["PK_AP_Property_Security_Monitor_Grids"].ToString());

        //    //   int Hours = Convert.ToInt16(gvCCTVHoursMonitoringGrid.DataKeys[e.RowIndex].Values["PK_AP_Property_Security_Monitor_Grids"].ToString());
        //    DropDownList ddlTimeBegin = (DropDownList)grid.Rows[RowIndex].Cells[0].FindControl("ddlDayMonitoringBegins");
        //    string valBegin = ddlTimeBegin.SelectedValue;

        //    DropDownList ddlTimeEnd = (DropDownList)grid.Rows[RowIndex].Cells[0].FindControl("ddlDayMonitoringEnds");
        //    string valEnd = ddlTimeEnd.SelectedValue;
        //    TextBox txtTimeHours = grid.Rows[RowIndex].FindControl("txtMonitoringPeriodHours") as TextBox;

        //    clsAP_Property_Security_Monitor_Grids objclsAP_Property_Security_Monitor_Grids = new clsAP_Property_Security_Monitor_Grids();
        //    objclsAP_Property_Security_Monitor_Grids.PK_AP_Property_Security_Monitor_Grids = id;
        //    objclsAP_Property_Security_Monitor_Grids.FK_AP_Property_Security = PK_AP_Property_Security;
        //    objclsAP_Property_Security_Monitor_Grids.Grid_Type = StrMonitorGridType;

        //    objclsAP_Property_Security_Monitor_Grids.Start_Day = Convert.ToDecimal(valBegin);
        //    objclsAP_Property_Security_Monitor_Grids.Start_Time = txtTimeBegin.Text;

        //    objclsAP_Property_Security_Monitor_Grids.End_Day = Convert.ToDecimal(valEnd);
        //    objclsAP_Property_Security_Monitor_Grids.End_Time = txtTimeEnd.Text;
        //    objclsAP_Property_Security_Monitor_Grids.Hours = txtTimeHours.Text;
        //    objclsAP_Property_Security_Monitor_Grids.Updated_By = clsSession.UserID;
        //    objclsAP_Property_Security_Monitor_Grids.Updated_Date = DateTime.Now;

        //    objclsAP_Property_Security_Monitor_Grids.Update();

        //    clsAP_Property_Security objPropertySec = new clsAP_Property_Security(PK_AP_Property_Security);
        //    txttotalHoursMonitoredPerWeek.Text = objPropertySec.Total_Hours_CCTV_Monitored_Per_Week;
        //    grid.EditIndex = -1;
        //    BindPropertySecurityMonitoringGrid();
        //}

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    //protected void gvCCTVHoursMonitoringGrid_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    gvCCTVHoursMonitoringGrid.ShowFooter = false;
    //    decimal id = Convert.ToDecimal(gvCCTVHoursMonitoringGrid.DataKeys[e.NewEditIndex].Values["PK_AP_Property_Security_Monitor_Grids"].ToString());
    //    gvCCTVHoursMonitoringGrid.EditIndex = e.NewEditIndex;
    //    bindPropertyMonitoringDetailForEdit(id);
    //    DropDownList ddlTimeBegin = (DropDownList)gvCCTVHoursMonitoringGrid.Rows[e.NewEditIndex].Cells[0].FindControl("ddlDayMonitoringBegins");

    //    DropDownList ddlTimeEnd = (DropDownList)gvCCTVHoursMonitoringGrid.Rows[e.NewEditIndex].Cells[0].FindControl("ddlDayMonitoringEnds");
    //    ComboHelper.FillWeekDays(new DropDownList[] { ddlTimeBegin, ddlTimeEnd }, 0, true);
    //    //decimal id = Convert.ToDecimal(gvCCTVHoursMonitoringGrid.DataKeys[e.NewEditIndex].Values["PK_AP_Property_Security_Monitor_Grids"].ToString());
    //    clsAP_Property_Security_Monitor_Grids objclsAP_Property_Security_Monitor_Grids = new clsAP_Property_Security_Monitor_Grids(id);
    //    ddlTimeBegin.SelectedIndex = Convert.ToInt32(objclsAP_Property_Security_Monitor_Grids.Start_Day);
    //    ddlTimeEnd.SelectedIndex = Convert.ToInt32(objclsAP_Property_Security_Monitor_Grids.End_Day);

    // }
    protected void MonitoringGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView grid;
        if (StrMonitorGridType == "CCTV")
        {
            grid = gvCCTVHoursMonitoringGrid;
        }
        else if (StrMonitorGridType == "Guard")
        {
            grid = gvGuardHoursMonitorGrid;
        }
        else
        {
            grid = gvOffDutyOfficerHoursMonitoredGrid;
        }
        grid.ShowFooter = false;

        grid.EditIndex = e.NewEditIndex;
        BindPropertySecurityMonitoringGrid();

        DropDownList ddlTimeBegin = (DropDownList)grid.Rows[e.NewEditIndex].Cells[0].FindControl("ddlDayMonitoringBegins");

        DropDownList ddlTimeEnd = (DropDownList)grid.Rows[e.NewEditIndex].Cells[0].FindControl("ddlDayMonitoringEnds");
        ComboHelper.FillWeekDays(new DropDownList[] { ddlTimeBegin, ddlTimeEnd }, 0, true);
        decimal id = Convert.ToDecimal(grid.DataKeys[e.NewEditIndex].Values["PK_AP_Property_Security_Monitor_Grids"].ToString());
        clsAP_Property_Security_Monitor_Grids objclsAP_Property_Security_Monitor_Grids = new clsAP_Property_Security_Monitor_Grids(id);
        ddlTimeBegin.SelectedIndex = Convert.ToInt32(objclsAP_Property_Security_Monitor_Grids.Start_Day);
        ddlTimeEnd.SelectedIndex = Convert.ToInt32(objclsAP_Property_Security_Monitor_Grids.End_Day);

    }
    protected void MonitoringGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        GridView grid;
        if (StrMonitorGridType == "CCTV")
        {
            grid = gvCCTVHoursMonitoringGrid;
        }
        else if (StrMonitorGridType == "Guard")
        {
            grid = gvGuardHoursMonitorGrid;
        }
        else
        {
            grid = gvOffDutyOfficerHoursMonitoredGrid;
        }

        TextBox txtTimeBegin = grid.Rows[e.RowIndex].FindControl("txtTimeMonitoringBegins") as TextBox;
        TextBox txtTimeEnd = grid.Rows[e.RowIndex].FindControl("txtTimeMonitoringEnds") as TextBox;
        int id = Convert.ToInt32(grid.DataKeys[e.RowIndex].Values["PK_AP_Property_Security_Monitor_Grids"].ToString());

        //   int Hours = Convert.ToInt16(gvCCTVHoursMonitoringGrid.DataKeys[e.RowIndex].Values["PK_AP_Property_Security_Monitor_Grids"].ToString());
        DropDownList ddlTimeBegin = (DropDownList)grid.Rows[e.RowIndex].Cells[0].FindControl("ddlDayMonitoringBegins");
        string valBegin = ddlTimeBegin.SelectedIndex.ToString();

        DropDownList ddlTimeEnd = (DropDownList)grid.Rows[e.RowIndex].Cells[0].FindControl("ddlDayMonitoringEnds");
        string valEnd = ddlTimeEnd.SelectedValue;
        TextBox txtTimeHours = grid.Rows[e.RowIndex].FindControl("txtMonitoringPeriodHours") as TextBox;

        clsAP_Property_Security_Monitor_Grids objclsAP_Property_Security_Monitor_Grids = new clsAP_Property_Security_Monitor_Grids();
        objclsAP_Property_Security_Monitor_Grids.PK_AP_Property_Security_Monitor_Grids = id;
        objclsAP_Property_Security_Monitor_Grids.FK_AP_Property_Security = PK_AP_Property_Security;
        objclsAP_Property_Security_Monitor_Grids.Grid_Type = StrMonitorGridType;

        objclsAP_Property_Security_Monitor_Grids.Start_Day = Convert.ToDecimal(valBegin);
        objclsAP_Property_Security_Monitor_Grids.Start_Time = txtTimeBegin.Text;

        objclsAP_Property_Security_Monitor_Grids.End_Day = Convert.ToDecimal(valEnd);
        objclsAP_Property_Security_Monitor_Grids.End_Time = txtTimeEnd.Text;
        objclsAP_Property_Security_Monitor_Grids.Hours = txtTimeHours.Text;
        objclsAP_Property_Security_Monitor_Grids.Updated_By = clsSession.UserID;
        objclsAP_Property_Security_Monitor_Grids.Updated_Date = DateTime.Now;

        objclsAP_Property_Security_Monitor_Grids.Update();

        clsAP_Property_Security objPropertySec = new clsAP_Property_Security(PK_AP_Property_Security);
        txttotalHoursMonitoredPerWeek.Text = objPropertySec.Total_Hours_CCTV_Monitored_Per_Week;
        grid.EditIndex = -1;
        BindPropertySecurityMonitoringGrid();
    }



    protected void gvCCTVHoursMonitoringGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        TextBox txtTimeBegin = gvCCTVHoursMonitoringGrid.Rows[e.RowIndex].FindControl("txtTimeMonitoringBegins") as TextBox;
        TextBox txtTimeEnd = gvCCTVHoursMonitoringGrid.Rows[e.RowIndex].FindControl("txtTimeMonitoringEnds") as TextBox;
        int id = Convert.ToInt32(gvCCTVHoursMonitoringGrid.DataKeys[e.RowIndex].Values["PK_AP_Property_Security_Monitor_Grids"].ToString());

        //   int Hours = Convert.ToInt16(gvCCTVHoursMonitoringGrid.DataKeys[e.RowIndex].Values["PK_AP_Property_Security_Monitor_Grids"].ToString());
        DropDownList ddlTimeBegin = (DropDownList)gvCCTVHoursMonitoringGrid.Rows[e.RowIndex].Cells[0].FindControl("ddlDayMonitoringBegins");
        string valBegin = ddlTimeBegin.SelectedValue;

        DropDownList ddlTimeEnd = (DropDownList)gvCCTVHoursMonitoringGrid.Rows[e.RowIndex].Cells[0].FindControl("ddlDayMonitoringEnds");
        string valEnd = ddlTimeEnd.SelectedValue;
        TextBox txtTimeHours = gvCCTVHoursMonitoringGrid.Rows[e.RowIndex].FindControl("txtMonitoringPeriodHours") as TextBox;

        clsAP_Property_Security_Monitor_Grids objclsAP_Property_Security_Monitor_Grids = new clsAP_Property_Security_Monitor_Grids();
        objclsAP_Property_Security_Monitor_Grids.PK_AP_Property_Security_Monitor_Grids = id;
        objclsAP_Property_Security_Monitor_Grids.FK_AP_Property_Security = PK_AP_Property_Security;
        objclsAP_Property_Security_Monitor_Grids.Grid_Type = "CCTV";

        objclsAP_Property_Security_Monitor_Grids.Start_Day = Convert.ToDecimal(valBegin);
        objclsAP_Property_Security_Monitor_Grids.Start_Time = txtTimeBegin.Text;

        objclsAP_Property_Security_Monitor_Grids.End_Day = Convert.ToDecimal(valEnd);
        objclsAP_Property_Security_Monitor_Grids.End_Time = txtTimeEnd.Text;
        objclsAP_Property_Security_Monitor_Grids.Hours = txtTimeHours.Text;
        objclsAP_Property_Security_Monitor_Grids.Updated_By = clsSession.UserID;
        objclsAP_Property_Security_Monitor_Grids.Updated_Date = DateTime.Now;

        objclsAP_Property_Security_Monitor_Grids.Update();

        clsAP_Property_Security objPropertySec = new clsAP_Property_Security(PK_AP_Property_Security);
        txttotalHoursMonitoredPerWeek.Text = objPropertySec.Total_Hours_CCTV_Monitored_Per_Week;
        gvCCTVHoursMonitoringGrid.EditIndex = -1;
        BindPropertySecurityMonitoringGrid();
    }

    //protected void gvCCTVHoursMonitoringGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        DropDownList ddlTimeBegin = (DropDownList)gvCCTVHoursMonitoringGrid.FooterRow.FindControl("ddlDayMonitoringBeginsAdd");
    //        string valBegin = ddlTimeBegin.SelectedValue;

    //        DropDownList ddlTimeEnd = (DropDownList)gvCCTVHoursMonitoringGrid.FooterRow.FindControl("ddlDayMonitoringEndsAdd");
    //        string valEnd = ddlTimeEnd.SelectedValue;

    //        ComboHelper.FillWeekDays(new DropDownList[] { ddlTimeBegin, ddlTimeEnd }, 0, true);
    //    }
    //}
    protected void MonitoringGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView grid;
        if (StrMonitorGridType == "CCTV")
        {
            grid = gvCCTVHoursMonitoringGrid;
        }
        else if (StrMonitorGridType == "Guard")
        {
            grid = gvGuardHoursMonitorGrid;
        }
        else
        {
            grid = gvOffDutyOfficerHoursMonitoredGrid;
        }
        grid.EditIndex = -1;
        BindPropertySecurityMonitoringGrid();
    }


    //protected void gvCCTVHoursMonitoringGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    gvCCTVHoursMonitoringGrid.EditIndex = -1;
    //    BindPropertySecurityMonitoringGrid();
    //}

    protected void gvNotesGridFraudView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "gvEdit")
        {
            PK_AP_FE_PA_Notes = Convert.ToDecimal(e.CommandArgument.ToString());
            if (PK_AP_FE_PA_Notes > 0)
            {
                tblMainFraudEvent.Style["display"] = tblMainFraudEventView.Style["display"] = pnlNoteGridAdd.Style["display"] = pnlTransactionGridAdd.Style["display"] = pnlTransactionGridAddView.Style["display"] = "none";
                pnlNoteGridAddView.Style["display"] = "";
                bindNotesDetailFraudForView();
            }
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }
    protected void gvFraudEventsNote_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        _SortOrder_FraudNotes = _SortOrder_FraudNotes == "asc" ? "desc" : "asc";
        //BindFraudEventGrid();
        BindFraudNotesGrid();
    }
    protected void gvNotesGridFraudView_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        _SortOrder_FraudNotes = _SortOrder_FraudNotes == "asc" ? "desc" : "asc";
        //BindFraudEventGrid();
        BindFraudNotesGrid();
    }
    protected void gvFraudEventsNote_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        if (e.CommandName == "gvEdit")
        {
            PK_AP_FE_PA_Notes = Convert.ToDecimal(e.CommandArgument.ToString());
            if (PK_AP_FE_PA_Notes > 0)
            {
                tblMainFraudEvent.Style["display"] = tblMainFraudEventView.Style["display"] = pnlNoteGridAddView.Style["display"] = pnlTransactionGridAdd.Style["display"] = pnlTransactionGridAddView.Style["display"] = "none";
                pnlNoteGridAdd.Style["display"] = "";
                bindNotesFraudDetailForEdit();
            }

        }
        else if (e.CommandName == "Remove")
        {
            index = Convert.ToInt32(e.CommandArgument);
            AP_FE_PA_Notes.DeleteByPK(index);

            BindFraudNotesGrid();
        }

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);

    }
    #endregion

    #region " DPD_FROIs "

    /// <summary>
    /// handles Row command of AP_DPD_FROIs Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAP_DPD_FROIs_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit_DPD_FROIs")
        {
            string[] arg = new string[5];
            arg = e.CommandArgument.ToString().Split(';');
            FK_DPD_FR_ID = Convert.ToDecimal(arg[0]);
            PK_AP_DPD_FROIs = Convert.ToDecimal(arg[1]);
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(arg[2]);
            FK_DPD_FR_Vehicle_ID = Convert.ToDecimal(arg[3]);
            PK_DPD_Claims_ID = Convert.ToDecimal(arg[4]);

            AP_DPD_FROIs_CommandArgs = e.CommandArgument.ToString();
            DPD_RowIndex = FK_DPD_FR_ID;

            BindWitnessGrid();

            if (StrOperation.ToLower() == "edit")
            {
                BindDetailsForEditForDPD_FROIs();
            }
            else if (StrOperation.ToLower() == "view")
            {

                BindDetailsForViewForDPD_FROIs();
            }
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }

    /// <summary>
    /// Handles RowDataBound of Claim_Notes Grid in edit mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaim_Notes_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdnPk_Claim_Notes = (HiddenField)e.Row.FindControl("hdnPk_Claim_Notes");
            HiddenField hndFK_Claim = (HiddenField)e.Row.FindControl("hndFK_Claim");
            LinkButton lnkNote_Date = (LinkButton)e.Row.FindControl("lnkNote_Date");

            decimal Pk_Claim_Notes, FK_Claim = 0;
            Pk_Claim_Notes = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PK_Claim_Notes"));
            FK_Claim = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "FK_Table"));

            lnkNote_Date.Attributes.Add("onclick", "javascript:return OpenClaimNotes('" + Encryption.Encrypt(Pk_Claim_Notes.ToString()) + "','" + Encryption.Encrypt(FK_Claim.ToString()) + "');");
        }
    }

    /// <summary>
    /// Handles RowDataBound of Claim_Notes Grid in view mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimNotesView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdnPk_Claim_Notes = (HiddenField)e.Row.FindControl("hdnPk_Claim_NotesView");
            HiddenField hndFK_Claim = (HiddenField)e.Row.FindControl("hndFK_ClaimView");
            LinkButton lnkNote_DateView = (LinkButton)e.Row.FindControl("lnkNoteDateView");

            decimal Pk_Claim_Notes, FK_Claim = 0;
            Pk_Claim_Notes = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PK_Claim_Notes"));
            FK_Claim = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "FK_Table"));

            lnkNote_DateView.Attributes.Add("onclick", "javascript:return OpenClaimNotesView('" + Encryption.Encrypt(Pk_Claim_Notes.ToString()) + "','" + Encryption.Encrypt(FK_Claim.ToString()) + "');");
        }
    }

    /// <summary>
    /// handles sorting for AP_DPD_FROIs Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAP_DPD_FROIs_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder_DPDFROIs = (SortBy_DPDFROIs == e.SortExpression) ? (SortOrder_DPDFROIs == "asc" ? "desc" : "asc") : "asc";
        SortBy_DPDFROIs = e.SortExpression;
        BindAP_DPD_FROIs_Grid(CtrlPagingDPD_FROIs.CurrentPage, CtrlPagingDPD_FROIs.PageSize);
    }

    /// <summary>
    /// Handles event when Grid row is created
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAP_DPD_FROIs_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != SortBy_DPDFROIs)
            {
                // update sort image beside the column header 
                AddSortImage(e.Row);
            }
            else
            {
                // add sort image beside the column header 
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[3].Controls.Add(sortImage);
            }
        }
    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage(GridViewRow headerRow)
    {
        Int32 iCol = GetSortColumnIndexForDPD_FROIs(SortBy_DPDFROIs);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder = SortOrder_DPDFROIs == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

        // check for the order and
        // set the images accordingly 
        if (SortDirection.Ascending.ToString() == strSortOrder)
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }

        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);
    }

    /// <summary>
    /// Returns the index of the column which contains perticular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndexForDPD_FROIs(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        if (StrOperation == "view")
        {
            foreach (DataControlField field in gvAP_DPD_FROIsView.Columns)
            {
                //check Sort Expression value
                if (field.SortExpression.ToString() == strSortExp)
                {
                    //nRet = gvFraudEventView.Columns.IndexOf(field);
                    nRet = gvAP_DPD_FROIsView.Columns.IndexOf(field);
                }
            }
            return nRet;
        }
        else
        {
            foreach (DataControlField field in gvAP_DPD_FROIs.Columns)
            {
                //check Sort Expression value
                if (field.SortExpression.ToString() == strSortExp)
                {
                    //nRet = gvFraudEvent.Columns.IndexOf(field);
                    nRet = gvAP_DPD_FROIs.Columns.IndexOf(field);
                }
            }
            return nRet;
        }
    }

    #endregion

    #region "AL_FROI"

    /// <summary>
    /// Row Command
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAP_AL_FROIs_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Edit_AL_FROIs")
        {
            string[] arg = new string[4];
            arg = e.CommandArgument.ToString().Split(';');
            FK_AL_FR_ID = Convert.ToDecimal(arg[0]);
            PK_AP_AL_FROIs = Convert.ToDecimal(arg[1]);
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(arg[2]);
            PK_Auto_Loss_Claims_ID = Convert.ToDecimal(arg[3]);
            Origin_Claim_Number = Convert.ToString(arg[4]);
            AP_AL_FROIs_CommandArgs = e.CommandArgument.ToString();
            AL_RowIndex = FK_AL_FR_ID;

            if (StrOperation.ToLower() != "view")
            {
                BindDetailsForEdit_AL();
                //BindClaim_NotesGrid_AL();
            }
            else
            {
                BindDetailsForView_AL();
                //BindClaim_NotesGrid_AL();
            }
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
        }

    }

    ///// <summary>
    ///// gvAL_Claim_Notes OnRowCommand
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void gvAL_Claim_Notes_OnRowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "ViewClaim_Notes")
    //    {
    //        Response.Redirect("SONIC/ClaimInfo/ALClaimInfo.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
    //    }
    //}
    protected void gvAL_Claim_Notes_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkNote_Date = (LinkButton)e.Row.FindControl("lnkNote_Date");
            decimal PK_Auto_Loss_Claims_ID = 0;
            PK_Auto_Loss_Claims_ID = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PK_Auto_Loss_Claims_ID"));
            lnkNote_Date.Attributes.Add("onclick", "javascript:return OpenClaimNotes('" + Encryption.Encrypt(PK_Auto_Loss_Claims_ID.ToString()) + "');");
        }
    }

    /// <summary>
    /// Sorting For AP_AL_FROIs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAP_AL_FROIs_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder_AL = (SortBy_AL == e.SortExpression) ? (SortOrder_AL == "asc" ? "desc" : "asc") : "asc";
        SortBy_AL = e.SortExpression;
        BindAP_AL_FROIs_Grid(CtrlPagingAL_FROIs.CurrentPage, CtrlPagingAL_FROIs.PageSize);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }

    /// <summary>
    /// Handles event when Grid row is created
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAP_AL_FROIs_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != SortBy_AL)
            {
                // update sort image beside the column header 
                AddSortImage_AL(e.Row);
            }
            else
            {
                // add sort image beside the column header 
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[3].Controls.Add(sortImage);
            }
        }
    }

    #endregion

    #region "Cal - Atlantic"

    /// <summary>
    /// Bind Fraud Event Grid
    /// </summary>
    private void BindCalAtlanticEventGrid()
    {
        if (StrOperation != "view")
        {
            DataSet ds_CalAtlantic = clsAP_Cal_Atlantic.SelectEventForCalAtlantic(rbtnlEvent.SelectedValue, LocationID, _SortBy_CalAtlantic, _SortOrder_CalAtlantic, CtrlPagingAP_Calatlantic.CurrentPage, CtrlPagingAP_Calatlantic.PageSize);
            gvEvent.DataSource = ds_CalAtlantic.Tables[0];
            gvEvent.DataBind();
            CtrlPagingAP_Calatlantic.TotalRecords = (ds_CalAtlantic.Tables.Count >= 2) ? Convert.ToInt32(ds_CalAtlantic.Tables[1].Rows[0][0]) : 0;
            CtrlPagingAP_Calatlantic.CurrentPage = (ds_CalAtlantic.Tables.Count >= 2) ? Convert.ToInt32(ds_CalAtlantic.Tables[1].Rows[0][2]) : 0;
            CtrlPagingAP_Calatlantic.RecordsToBeDisplayed = ds_CalAtlantic.Tables[0].Rows.Count;
            CtrlPagingAP_Calatlantic.SetPageNumbers();
        }
        else
        {
            DataSet ds_CalAtlantic = clsAP_Cal_Atlantic.SelectEventForCalAtlantic(rbtnlEventView.SelectedValue, LocationID, _SortBy_CalAtlantic, _SortOrder_CalAtlantic, CtrlPagingAP_CalatlanticView.CurrentPage, CtrlPagingAP_CalatlanticView.PageSize);
            gvEventView.DataSource = ds_CalAtlantic.Tables[0];
            gvEventView.DataBind();
            CtrlPagingAP_CalatlanticView.TotalRecords = (ds_CalAtlantic.Tables.Count >= 2) ? Convert.ToInt32(ds_CalAtlantic.Tables[1].Rows[0][0]) : 0;
            CtrlPagingAP_CalatlanticView.CurrentPage = (ds_CalAtlantic.Tables.Count >= 2) ? Convert.ToInt32(ds_CalAtlantic.Tables[1].Rows[0][2]) : 0;
            CtrlPagingAP_CalatlanticView.RecordsToBeDisplayed = ds_CalAtlantic.Tables[0].Rows.Count;
            CtrlPagingAP_CalatlanticView.SetPageNumbers();
        }
    }

    /// <summary>
    /// Handles gvNotesGrid grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEvent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "gvEdit")
        {
            FK_Event = Convert.ToDecimal(e.CommandArgument.ToString());
            if (FK_Event > 0)
            {
                BindEvent();
            }
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
        }

    }

    /// <summary>
    /// Handles event when row header link is clicked for sorting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEvent_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        _SortOrder_CalAtlantic = (_SortBy_CalAtlantic == e.SortExpression) ? (_SortOrder_CalAtlantic == "asc" ? "desc" : "asc") : "asc";
        _SortBy_CalAtlantic = e.SortExpression;
        BindCalAtlanticEventGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
    }

    /// <summary>
    /// Handles event when Grid row is created
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEvent_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != _SortBy_CalAtlantic)
            {
                // update sort image beside the column header 
                AddSortImage_CalAtlantic(e.Row);
            }
            else
            {
                // add sort image beside the column header 
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[3].Controls.Add(sortImage);
            }
        }
    }

    #endregion

    #region "Fraud Events"

    /// <summary>
    /// Handles gvNotesGrid grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNotesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        if (e.CommandName == "gvEdit")
        {
            PK_AP_FE_Notes = Convert.ToDecimal(e.CommandArgument.ToString());
            if (PK_AP_FE_Notes > 0)
            {
                tblMainFraudEvent.Style["display"] = tblMainFraudEventView.Style["display"] = pnlNoteGridAddView.Style["display"] = pnlTransactionGridAdd.Style["display"] = pnlTransactionGridAddView.Style["display"] = "none";
                pnlNoteGridAdd.Style["display"] = "";
                bindNotesDetailForEdit();
            }

        }
        else if (e.CommandName == "Remove")
        {
            index = Convert.ToInt32(e.CommandArgument);
            clsAP_FE_Notes.DeleteByPK(index);

            BindNotesGrid();
        }

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Handles gvNotesGrid grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFinancialReserveTransaction_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        if (e.CommandName == "gvEdit")
        {
            PK_AP_FE_Transactions = Convert.ToDecimal(e.CommandArgument.ToString());
            if (PK_AP_FE_Transactions > 0)
            {
                tblMainFraudEvent.Style["display"] = tblMainFraudEventView.Style["display"] = pnlNoteGridAdd.Style["display"] = pnlNoteGridAddView.Style["display"] = pnlTransactionGridAddView.Style["display"] = "none";
                pnlTransactionGridAdd.Style["display"] = "";
                bindTransactionDetailForEdit();
            }

        }
        else if (e.CommandName == "Remove")
        {
            index = Convert.ToInt32(e.CommandArgument);
            clsAP_FE_Transactions.DeleteByPK(index);

            BindTransactionGrid();
            BindFinancialMatrix();
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Handles gvNotesGrid grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNotesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "gvEdit")
        {
            PK_AP_FE_Notes = Convert.ToDecimal(e.CommandArgument.ToString());
            if (PK_AP_FE_Notes > 0)
            {
                tblMainFraudEvent.Style["display"] = tblMainFraudEventView.Style["display"] = pnlNoteGridAdd.Style["display"] = pnlTransactionGridAdd.Style["display"] = pnlTransactionGridAddView.Style["display"] = "none";
                pnlNoteGridAddView.Style["display"] = "";
                bindNotesDetailForView();
            }
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Handles gvNotesGrid grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFinancialReserveTransactionView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        if (e.CommandName == "gvEdit")
        {
            PK_AP_FE_Transactions = Convert.ToDecimal(e.CommandArgument.ToString());
            if (PK_AP_FE_Transactions > 0)
            {
                tblMainFraudEvent.Style["display"] = pnlNoteGridAdd.Style["display"] = pnlNoteGridAddView.Style["display"] = pnlTransactionGridAdd.Style["display"] = tblMainFraudEventView.Style["display"] = "none";
                pnlTransactionGridAddView.Style["display"] = "";
                bindTransactionDetailForView();
            }
        }
        else if (e.CommandName == "Remove")
        {
            index = Convert.ToInt32(e.CommandArgument);
            clsAP_FE_Transactions.DeleteByPK(index);

            BindTransactionGrid();
            BindFinancialMatrix();
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Handles gvNotesGrid grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFraudEvent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "gvEdit")
        {
            _SortOrder_FraudNotes = "Desc";
            PK_AP_Fraud_Events = Convert.ToDecimal(e.CommandArgument.ToString());
            if (PK_AP_Fraud_Events > 0)
            {
                BindDetailsForEdit_FraudEvents();
            }

        }
        if (e.CommandName == "gvRemove")
        {
            PK_AP_Fraud_Events = Convert.ToDecimal(e.CommandArgument.ToString());
            if (PK_AP_Fraud_Events > 0)
            {
                clsAP_Fraud_Events.DeleteByPK(PK_AP_Fraud_Events);
                BindFraudEventGrid();
            }
        }
        ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "ShowPanel(5);", true);
    }

    /// <summary>
    /// Handles event when row header link is clicked for sorting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFraudEvent_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        _SortOrder_Fraud = (_SortBy_Fraud == e.SortExpression) ? (_SortOrder_Fraud == "asc" ? "desc" : "asc") : "asc";
        _SortBy_Fraud = e.SortExpression;
        BindFraudEventGrid();
    }

    /// <summary>
    /// Handles event when Grid row is created
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFraudEvent_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != _SortBy_Fraud)
            {
                // update sort image beside the column header 
                AddSortImage_Fraud(e.Row);
            }
            else
            {
                // add sort image beside the column header 
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[3].Controls.Add(sortImage);
            }
        }
    }
    /// <summary>
    /// Handles gvNotesGrid grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFraudEventView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "gvEdit")
        {
            _SortOrder_FraudNotes = "Desc";
            PK_AP_Fraud_Events = Convert.ToDecimal(e.CommandArgument.ToString());
            if (PK_AP_Fraud_Events > 0)
            {
                BindDetailsForView_FraudEvents();
            }


        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Handles event when row header link is clicked for sorting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFraudEventView_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        _SortOrder_Fraud = (_SortBy_Fraud == e.SortExpression) ? (_SortOrder_Fraud == "asc" ? "desc" : "asc") : "asc";
        _SortBy_Fraud = e.SortExpression;
        BindFraudEventGrid();
    }

    /// <summary>
    /// Handles event when Grid row is created
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFraudEventView_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != _SortBy_Fraud)
            {
                // update sort image beside the column header 
                AddSortImage_Fraud(e.Row);
            }
            else
            {
                // add sort image beside the column header 
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[3].Controls.Add(sortImage);
            }
        }
    }

    #endregion

    #endregion

    #region Dynamic Validation

    /// <summary>
    /// Set Dynamic Validation
    /// </summary>
    private void SetValidation()
    {
        #region " Property Security "
        string strCtrlsIDsProperty_Security = "";
        string strMessagesProperty_Security = "";
        DataTable dtFieldsProperty_Security = clsScreen_Validators.SelectByScreen(199).Tables[0];
        dtFieldsProperty_Security.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsProperty_Security = dtFieldsProperty_Security.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFieldsProperty_Security.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drFieldProperty_Security in dtFieldsProperty_Security.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldProperty_Security["Field_Name"]))
            {
                case "CCTV Company Name": strCtrlsIDsProperty_Security += txtCCTV_Company_Name.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/CCTV Company Name" + ","; Span1.Style["display"] = "inline-block"; break;
                case "CCTV Company Address 1": strCtrlsIDsProperty_Security += txtCCTV_Company_Address_1.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/CCTV Company Address 1" + ","; Span2.Style["display"] = "inline-block"; break;
                case "CCTV Company Address 2": strCtrlsIDsProperty_Security += txtCCTV_Company_Address_2.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/CCTV Company Address 2" + ","; Span3.Style["display"] = "inline-block"; break;
                case "CCTV Company City": strCtrlsIDsProperty_Security += txtCCTV_Company_City.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/CCTV Company City" + ","; Span4.Style["display"] = "inline-block"; break;
                case "CCTV Company State": strCtrlsIDsProperty_Security += drpFK_CCTV_Company_State.ClientID + ","; strMessagesProperty_Security += "Please select [Property Security]/CCTV Company State" + ","; Span5.Style["display"] = "inline-block"; break;
                case "CCTV Company Zip": strCtrlsIDsProperty_Security += txtCCTV_Company_Zip.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/CCTV Company Zip" + ","; Span6.Style["display"] = "inline-block"; break;
                case "CCTV Company Contact Name": strCtrlsIDsProperty_Security += txtCCTV_Company_Contact_Name.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/CCTV Company Contact Name" + ","; Span7.Style["display"] = "inline-block"; break;
                case "CCTV Company Contact Telephone": strCtrlsIDsProperty_Security += txtCCTV_Company_Contact_Name.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/CCTV Company Contact Telephone" + ","; Span8.Style["display"] = "inline-block"; break;
                case "CCTV Company Contact E-Mail": strCtrlsIDsProperty_Security += txtCCTV_Company_Contact_EMail.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/CCTV Company Contact E-Mail" + ","; Span9.Style["display"] = "inline-block"; break;
                //case "Hours Monitored From": strCtrlsIDsProperty_Security += txtHours_Monitored_From.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Hours Monitored From" + ","; Span10.Style["display"] = "inline-block"; break;
                //case "Hours Monitored To": strCtrlsIDsProperty_Security += txtHours_Monitored_To.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Hours Monitored To" + ","; Span11.Style["display"] = "inline-block"; break;
                case "Exterior Camera Coverage – Other Description": strCtrlsIDsProperty_Security += txtExterior_Camera_Coverage_Other_Description.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Exterior Camera Coverage – Other Description" + ","; Span12.Style["display"] = "inline-block"; break;
                case "Interior Camera Coverage – Other Description": strCtrlsIDsProperty_Security += txtInterior_Camera_Coverage_Other_Description.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Interior Camera Coverage – Other Description" + ","; Span13.Style["display"] = "inline-block"; break;
                case "Burglar Alarm Company Name": strCtrlsIDsProperty_Security += txtBurglar_Alarm_Company_Name.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Burglar Alarm Company Name" + ","; Span14.Style["display"] = "inline-block"; break;
                case "Burglar Alarm Company Address 1": strCtrlsIDsProperty_Security += txtBurglar_Alarm_Company_Address_1.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Burglar Alarm Company Address 1" + ","; Span15.Style["display"] = "inline-block"; break;
                case "Burglar Alarm Company Address 2": strCtrlsIDsProperty_Security += txtBurglar_Alarm_Company_Address_2.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Burglar Alarm Company Address 2" + ","; Span16.Style["display"] = "inline-block"; break;
                case "Burglar Alarm Company City": strCtrlsIDsProperty_Security += txtBurglar_Alarm_Company_City.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Burglar Alarm Company City" + ","; Span17.Style["display"] = "inline-block"; break;
                case "Burglar Alarm Company State": strCtrlsIDsProperty_Security += drpFK_Burglar_Alarm_Company_State.ClientID + ","; strMessagesProperty_Security += "Please select [Property Security]/Burglar Alarm Company State" + ","; Span18.Style["display"] = "inline-block"; break;
                case "Burglar Alarm Company Zip": strCtrlsIDsProperty_Security += txtBurglar_Alarm_Company_Zip.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Burglar Alarm Company Zip" + ","; Span19.Style["display"] = "inline-block"; break;
                case "Burglar Alarm Company Contact Name": strCtrlsIDsProperty_Security += txtBurglar_Alarm_Company_Contact_Name.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Burglar Alarm Company Contact Name" + ","; Span20.Style["display"] = "inline-block"; break;
                case "Burglar Alarm Company Contact Telephone": strCtrlsIDsProperty_Security += txtBurglar_Alarm_Comapny_Contact_Telephone.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Burglar Alarm Company Contact Telephone" + ","; Span21.Style["display"] = "inline-block"; break;
                case "Burglar Alarm Company Contact E-Mail": strCtrlsIDsProperty_Security += txtBurglar_Alarm_Company_Contact_EMail.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Burglar Alarm Company Contact E-Mail" + ","; Span22.Style["display"] = "inline-block"; break;
                case "Burglar Alarm Coverage – Other Description": strCtrlsIDsProperty_Security += txtBurglar_Alarm_Coverage_Other_Description.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Burglar Alarm Coverage – Other Description" + ","; Span23.Style["display"] = "inline-block"; break;
                case "Burglar Alarm Coverage Comments": strCtrlsIDsProperty_Security += txtBurglar_Alarm_Coverage_Comments.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Burglar Alarm Coverage Comments" + ","; Span24.Style["display"] = "inline-block"; break;
                case "Guard Company Name": strCtrlsIDsProperty_Security += txtGuard_Company_Name.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Guard Company Name" + ","; Span25.Style["display"] = "inline-block"; break;
                case "Guard Company Address 1": strCtrlsIDsProperty_Security += txtGuard_Company_Address_1.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Guard Company Address 1" + ","; Span26.Style["display"] = "inline-block"; break;
                case "Guard Company Address 2": strCtrlsIDsProperty_Security += txtGuard_Company_Address_2.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Guard Company Address 2" + ","; Span27.Style["display"] = "inline-block"; break;
                case "Guard Company City": strCtrlsIDsProperty_Security += txtGuard_Company_City.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Guard Company City" + ","; Span28.Style["display"] = "inline-block"; break;
                case "Guard Company State": strCtrlsIDsProperty_Security += drpFK_Guard_Company_State.ClientID + ","; strMessagesProperty_Security += "Please select [Property Security]/Guard Company State" + ","; Span29.Style["display"] = "inline-block"; break;
                case "Guard Company Zip": strCtrlsIDsProperty_Security += txtGuard_Company_Zip.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Guard Company Zip" + ","; Span30.Style["display"] = "inline-block"; break;
                case "Guard Company Contact Name": strCtrlsIDsProperty_Security += txtGuard_Company_Contact_Name.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Guard Company Contact Name" + ","; Span31.Style["display"] = "inline-block"; break;
                case "Guard Company Contact Telephone": strCtrlsIDsProperty_Security += txtGuard_Comapny_Contact_Telephone.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Guard Company Contact Telephone" + ","; Span32.Style["display"] = "inline-block"; break;
                case "Guard Company Contact E-Mail ": strCtrlsIDsProperty_Security += txtGuard_Company_Contact_EMail.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Guard Company Contact E-Mail " + ","; Span33.Style["display"] = "inline-block"; break;
                //case "Guard Hours Monitored From": strCtrlsIDsProperty_Security += txtGuard_Hours_Monitored_From.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Guard Hours Monitored From" + ","; Span34.Style["display"] = "inline-block"; break;
                //case "Guard Hours Monitored To": strCtrlsIDsProperty_Security += txtGuard_Hours_Monitored_To.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Guard Hours Monitored To" + ","; Span35.Style["display"] = "inline-block"; break;
                case "Off-Duty Officer Name": strCtrlsIDsProperty_Security += txtOffDuty_Officer_Name.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Off-Duty Officer Name" + ","; Span36.Style["display"] = "inline-block"; break;
                case "Off-Duty Officer Telephone": strCtrlsIDsProperty_Security += txtOffDuty_Officer_Telephone.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Off-Duty Officer Telephone" + ","; Span37.Style["display"] = "inline-block"; break;
                //case "Off-Duty Officer Hours Monitored From": strCtrlsIDsProperty_Security += txtOffDuty_Officer_Hours_Monitored_From.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Off-Duty Officer Hours Monitored From" + ","; Span38.Style["display"] = "inline-block"; break;
                //case "Off-Duty Officer Hours Monitored To": strCtrlsIDsProperty_Security += txtOffDuty_Officer_Hours_Monitored_To.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Off-Duty Officer Hours Monitored To" + ","; Span39.Style["display"] = "inline-block"; break;
                case "Access Control – Other Description": strCtrlsIDsProperty_Security += txtAccess_Control_Other_Description.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Access Control – Other Description" + ","; Span40.Style["display"] = "inline-block"; break;
                case "Security Inventory Tracking System – Other Description": strCtrlsIDsProperty_Security += txtSecurity_Inventory_Tracking_System_Other_Description.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Security Inventory Tracking System – Other Description" + ","; Span41.Style["display"] = "inline-block"; break;
                case "Cap Index Crime Score": strCtrlsIDsProperty_Security += txtCap_Index_Crime_Score.ClientID + ","; strMessagesProperty_Security += "Please enter [Property Security]/Cap Index Crime Score" + ","; Span141.Style["display"] = "inline-block"; break;
                case "Cap Index Risk Category": strCtrlsIDsProperty_Security += ddlCap_Index_Risk_Category.ClientID + ","; strMessagesProperty_Security += "Please select [Property Security]/Cap Index Risk Category" + ","; Span142.Style["display"] = "inline-block"; break;
                case "Number of External Cameras": strCtrlsIDsProperty_Security += txtNumberOfExternalCameras.ClientID + ","; strMessagesProperty_Security += "Please select [Property Security]/Number of External Cameras" + ","; Span143.Style["display"] = "inline-block"; break;
                case "Number of Internal Cameras": strCtrlsIDsProperty_Security += txtNumberofInternalCameras.ClientID + ","; strMessagesProperty_Security += "Please select [Property Security]/Number of Internal Cameras" + ","; Span144.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDsProperty_Security = strCtrlsIDsProperty_Security.TrimEnd(',');
        strMessagesProperty_Security = strMessagesProperty_Security.TrimEnd(',');

        hdnControlIDsProperty_Security.Value = strCtrlsIDsProperty_Security;
        hdnErrorMsgsProperty_Security.Value = strMessagesProperty_Security;

        #endregion

        #region " DPD FROIs "
        string strCtrlsIDsDPD_FROIs = "";
        string strMessagesDPD_FROIs = "";
        DataTable dtFieldsDPD_FROIs = clsScreen_Validators.SelectByScreen(200).Tables[0];
        dtFieldsDPD_FROIs.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsDPD_FROIs = dtFieldsDPD_FROIs.DefaultView.ToTable();
        MenuAsterisk2.Style["display"] = (dtFieldsDPD_FROIs.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drFieldDPD_FROIs in dtFieldsDPD_FROIs.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldDPD_FROIs["Field_Name"]))
            {
                case "Investigation Finding – Other Description": strCtrlsIDsDPD_FROIs += txtInvestigation_Finding_Other_Description.ClientID + ","; strMessagesDPD_FROIs += "Please enter [DPD FROIs]/Investigation Finding – Other Description" + ","; Span42.Style["display"] = "inline-block"; break;
                case "What is the incident’s root cause?": strCtrlsIDsDPD_FROIs += txtRoot_Cause.ClientID + ","; strMessagesDPD_FROIs += "Please enter [DPD FROIs]/What is the incident’s root cause?" + ","; Span43.Style["display"] = "inline-block"; break;
                case "How can the incident be prevented from happening again?": strCtrlsIDsDPD_FROIs += txtIncident_Prevention.ClientID + ","; strMessagesDPD_FROIs += "Please enter [DPD FROIs]/How can the incident be prevented from happening again?" + ","; Span44.Style["display"] = "inline-block"; break;
                case "Who has been tasked with implementing practices/procedures to prevent re-occurrence?": strCtrlsIDsDPD_FROIs += txtPerson_Tasked.ClientID + ","; strMessagesDPD_FROIs += "Please enter [DPD FROIs]/Who has been tasked with implementing practices/procedures to prevent re-occurrence?" + ","; Span45.Style["display"] = "inline-block"; break;
                case "Target Date of Completion": strCtrlsIDsDPD_FROIs += txtTarget_Date_of_Completion.ClientID + ","; strMessagesDPD_FROIs += "Please enter [DPD FROIs]/Target Date of Completion" + ","; Span46.Style["display"] = "inline-block"; break;
                case "Status Due On": strCtrlsIDsDPD_FROIs += txtStatus_Due_On.ClientID + ","; strMessagesDPD_FROIs += "Please enter [DPD FROIs]/Status Due On" + ","; Span47.Style["display"] = "inline-block"; break;
                case "Comments": strCtrlsIDsDPD_FROIs += txtComments.ClientID + ","; strMessagesDPD_FROIs += "Please enter [DPD FROIs]/Comments" + ","; Span48.Style["display"] = "inline-block"; break;
                case "Financial Loss": strCtrlsIDsDPD_FROIs += txtFinancial_Loss.ClientID + ","; strMessagesDPD_FROIs += "Please enter [DPD FROIs]/Financial Loss" + ","; Span49.Style["display"] = "inline-block"; break;
                case "Recovery": strCtrlsIDsDPD_FROIs += txtRecovery.ClientID + ","; strMessagesDPD_FROIs += "Please enter [DPD FROIs]/Recovery" + ","; Span50.Style["display"] = "inline-block"; break;
                case "Item Status": strCtrlsIDsDPD_FROIs += drpItem_Status.ClientID + ","; strMessagesDPD_FROIs += "Please select [DPD FROIs]/Item Status" + ","; Span51.Style["display"] = "inline-block"; break;
                case "Vehicle Color": strCtrlsIDsDPD_FROIs += txtVehicleColor.ClientID + ","; strMessagesDPD_FROIs += "Please enter [DPD FROIs]/Vehicle Color" + ","; Span145.Style["display"] = "inline-block"; break;
                case "Police Case Number": strCtrlsIDsDPD_FROIs += txtPoliceCaseNumber.ClientID + ","; strMessagesDPD_FROIs += "Please enter [DPD FROIs]/Police Case Number" + ","; Span146.Style["display"] = "inline-block"; break;
                case "Investigating Police Department": strCtrlsIDsDPD_FROIs += txtInvestigatingPoliceDepartment.ClientID + ","; strMessagesDPD_FROIs += "Please enter [DPD FROIs]/Investigating Police Department" + ","; Span147.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDsDPD_FROIs = strCtrlsIDsDPD_FROIs.TrimEnd(',');
        strMessagesDPD_FROIs = strMessagesDPD_FROIs.TrimEnd(',');

        hdnControlIDsDPD_FROIs.Value = strCtrlsIDsDPD_FROIs;
        hdnErrorMsgsDPD_FROIs.Value = strMessagesDPD_FROIs;
        #endregion

        #region " AL FROIs "
        string strCtrlsIDsAL_FROIs = "";
        string strMessagesAL_FROIs = "";
        DataTable dtFieldsAL_FROIs = clsScreen_Validators.SelectByScreen(201).Tables[0];
        dtFieldsAL_FROIs.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsAL_FROIs = dtFieldsAL_FROIs.DefaultView.ToTable();
        MenuAsterisk3.Style["display"] = (dtFieldsAL_FROIs.Select("LeftMenuIndex = 3").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drFieldDPD_FROIs in dtFieldsDPD_FROIs.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldDPD_FROIs["Field_Name"]))
            {
                case "Investigation Finding – Other Description": strCtrlsIDsAL_FROIs += txtAL_Investigation_Finding.ClientID + ","; strMessagesAL_FROIs += "Please enter [AL FROIs]/Investigation Finding – Other Description" + ","; Span52.Style["display"] = "inline-block"; break;
                case "What is the incident’s root cause?": strCtrlsIDsAL_FROIs += txtAL_Root_Cause.ClientID + ","; strMessagesAL_FROIs += "Please enter [AL FROIs]/What is the incident’s root cause?" + ","; Span53.Style["display"] = "inline-block"; break;
                case "How can the incident be prevented from happening again?": strCtrlsIDsAL_FROIs += txtAL_Incident_Prevention.ClientID + ","; strMessagesAL_FROIs += "Please enter [AL FROIs]/How can the incident be prevented from happening again?" + ","; Span54.Style["display"] = "inline-block"; break;
                case "Who has been tasked with implementing practices/procedures to prevent re-occurrence?": strCtrlsIDsAL_FROIs += txtAL_Person_Tasked.ClientID + ","; strMessagesAL_FROIs += "Please enter [AL FROIs]/Who has been tasked with implementing practices/procedures to prevent re-occurrence?" + ","; Span55.Style["display"] = "inline-block"; break;
                case "Target Date of Completion": strCtrlsIDsAL_FROIs += txtAL_Target_Date_of_Completion.ClientID + ","; strMessagesAL_FROIs += "Please enter [AL FROIs]/Target Date of Completion" + ","; Span56.Style["display"] = "inline-block"; break;
                case "Status Due On": strCtrlsIDsAL_FROIs += txtAL_Status_Due_On.ClientID + ","; strMessagesAL_FROIs += "Please enter [AL FROIs]/Status Due On" + ","; Span57.Style["display"] = "inline-block"; break;
                case "Comments": strCtrlsIDsAL_FROIs += txtAL_Comments.ClientID + ","; strMessagesAL_FROIs += "Please enter [AL FROIs]/Comments" + ","; Span58.Style["display"] = "inline-block"; break;
                case "Financial Loss": strCtrlsIDsAL_FROIs += txtAL_Financial_Loss.ClientID + ","; strMessagesAL_FROIs += "Please enter [AL FROIs]/Financial Loss" + ","; Span59.Style["display"] = "inline-block"; break;
                case "Recovery": strCtrlsIDsAL_FROIs += txtAL_Recovery.ClientID + ","; strMessagesAL_FROIs += "Please enter [AL FROIs]/Recovery" + ","; Span60.Style["display"] = "inline-block"; break;
                case "Item Status": strCtrlsIDsAL_FROIs += drpAL_Item_Status.ClientID + ","; strMessagesAL_FROIs += "Please select [AL FROIs]/Item Status" + ","; Span61.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDsAL_FROIs = strCtrlsIDsAL_FROIs.TrimEnd(',');
        strMessagesAL_FROIs = strMessagesAL_FROIs.TrimEnd(',');

        hdnControlIDsAL_FROIs.Value = strCtrlsIDsAL_FROIs;
        hdnErrorMsgsAL_FROIs.Value = strMessagesAL_FROIs;
        #endregion

        #region " Cal-Atlantic "
        string strCtrlsIDsCalAtlantic = "";
        string strMessagesCalAtlantic = "";
        DataTable dtFieldsCalAtlantic = clsScreen_Validators.SelectByScreen(202).Tables[0];
        dtFieldsCalAtlantic.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsCalAtlantic = dtFieldsCalAtlantic.DefaultView.ToTable();
        //MenuAsterisk4.Style["display"] = (dtFieldsCalAtlantic.Select("LeftMenuIndex = 4").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drFieldCalAtlantic in dtFieldsCalAtlantic.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldCalAtlantic["Field_Name"]))
            {
                //Change Header text from Cal-Atlantic to ACI as per client's request Bug ID = 2552 
                case "Potential Risk ": strCtrlsIDsCalAtlantic += txtPotential_Risk.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Potential Risk " + ","; Span62.Style["display"] = "inline-block"; break;
                case "Action Taken": strCtrlsIDsCalAtlantic += txtAction_Taken.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Action Taken" + ","; Span63.Style["display"] = "inline-block"; break;
                case "Officer Name": strCtrlsIDsCalAtlantic += txtOfficer_Name.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Officer Name" + ","; Span64.Style["display"] = "inline-block"; break;
                case "Phone Number": strCtrlsIDsCalAtlantic += txtPhone_Number.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Phone Number" + ","; Span65.Style["display"] = "inline-block"; break;
                case "E-Mail": strCtrlsIDsCalAtlantic += txtEMail.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/E-Mail" + ","; Span66.Style["display"] = "inline-block"; break;
                case "Law Enforcement Agency": strCtrlsIDsCalAtlantic += txtLaw_Enforcement_Agency.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Law Enforcement Agency" + ","; Span67.Style["display"] = "inline-block"; break;
                case "Location": strCtrlsIDsCalAtlantic += txtLocation.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Location" + ","; Span68.Style["display"] = "inline-block"; break;
                case "Police Report Number": strCtrlsIDsCalAtlantic += txtPolice_Report_Number.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Police Report Number" + ","; Span69.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDsCalAtlantic += txtNotes.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Notes" + ","; Span70.Style["display"] = "inline-block"; break;
                case "Associated FROI Number": strCtrlsIDsCalAtlantic += ddlAssociateFROINo.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Associated FROI Number" + ","; Span71.Style["display"] = "inline-block"; break;
                case "Associated Claim Number": strCtrlsIDsCalAtlantic += ddlAssociatedClaimNo.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Associated Claim Number" + ","; Span72.Style["display"] = "inline-block"; break;
                case "What is the event’s root cause?": strCtrlsIDsCalAtlantic += txtCalRoot_Cause.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/What is the event’s root cause?" + ","; Span73.Style["display"] = "inline-block"; break;
                case "How can the event be prevented from happening again?": strCtrlsIDsCalAtlantic += txtevent_Prevention.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/How can the event be prevented from happening again?" + ","; Span74.Style["display"] = "inline-block"; break;
                case "Who has been tasked with implementing practices/procedures to prevent re-occurrence?": strCtrlsIDsCalAtlantic += txtCalPerson_Tasked.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Who has been tasked with implementing practices/procedures to prevent re-occurrence?" + ","; Span75.Style["display"] = "inline-block"; break;
                case "Target Date of Completion": strCtrlsIDsCalAtlantic += txtCalTarget_Date_of_Completion.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Target Date of Completion" + ","; Span76.Style["display"] = "inline-block"; break;
                case "Status Due On": strCtrlsIDsCalAtlantic += txtCalStatus_Due_On.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Status Due On" + ","; Span77.Style["display"] = "inline-block"; break;
                case "Comments": strCtrlsIDsCalAtlantic += txtCalComments.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Comments" + ","; Span78.Style["display"] = "inline-block"; break;
                case "Financial Loss": strCtrlsIDsCalAtlantic += txtCalFinancial_Loss.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Financial Loss" + ","; Span79.Style["display"] = "inline-block"; break;
                case "Recovery": strCtrlsIDsCalAtlantic += txtCalRecovery.ClientID + ","; strMessagesCalAtlantic += "Please enter [ACI]/Recovery" + ","; Span80.Style["display"] = "inline-block"; break;
                case "Item Status": strCtrlsIDsCalAtlantic += ddlCalAtlantic_Item_Status.ClientID + ","; strMessagesCalAtlantic += "Please select [ACI]/Item Status" + ","; Span81.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDsCalAtlantic = strCtrlsIDsCalAtlantic.TrimEnd(',');
        strMessagesCalAtlantic = strMessagesCalAtlantic.TrimEnd(',');

        hdnControlIDsCalAtlantic.Value = strCtrlsIDsCalAtlantic;
        hdnErrorMsgsCalAtlantic.Value = strMessagesCalAtlantic;
        #endregion

        #region " Fraud Events "
        string strCtrlsIDsFraudEvents = "";
        string strMessagesFraudEvents = "";
        string strCtrlsIDsNotes = "";
        string strMessagesNotes = "";
        string strCtrlsIDsTransaction = "";
        string strMessagesTransaction = "";

        DataTable dtFieldsFraudEvents = clsScreen_Validators.SelectByScreen(203).Tables[0];
        dtFieldsFraudEvents.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsFraudEvents = dtFieldsFraudEvents.DefaultView.ToTable();
        MenuAsterisk4.Style["display"] = (dtFieldsFraudEvents.Select("LeftMenuIndex = 4").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drFieldFraudEvents in dtFieldsFraudEvents.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldFraudEvents["Field_Name"]))
            {
                case "Exposure Period Begin Date": strCtrlsIDsFraudEvents += txtExpPeriodBeginDate.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Exposure Period Begin Date" + ","; Span82.Style["display"] = "inline-block"; break;
                case "Exposure Period End Date": strCtrlsIDsFraudEvents += txtExpoPeriodEndDate.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Exposure Period End Date" + ","; Span83.Style["display"] = "inline-block"; break;
                case "Reported To": strCtrlsIDsFraudEvents += txtReportedTo.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Reported To" + ","; Span84.Style["display"] = "inline-block"; break;
                case "Reported Date": strCtrlsIDsFraudEvents += txtReportedDate.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Reported Date" + ","; Span85.Style["display"] = "inline-block"; break;
                case "Description of Event ": strCtrlsIDsFraudEvents += txtDesciptionofEvent.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Description of Event " + ","; Span86.Style["display"] = "inline-block"; break;
                case "Other Notification Description": strCtrlsIDsFraudEvents += txtOther_Notification_Description.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Other Notification Description" + ","; Span87.Style["display"] = "inline-block"; break;
                case "Initial Claim Review Purification Notes": strCtrlsIDsFraudEvents += txtInternal_Review_Purification_Notes.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Initial Claim Review Purification Notes" + ","; Span88.Style["display"] = "inline-block"; break;
                case "Fraud Date": strCtrlsIDsFraudEvents += txtFraud_Date.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Fraud Date" + ","; Span89.Style["display"] = "inline-block"; break;
                case "HR Assignment": strCtrlsIDsFraudEvents += txtHR_Assignment.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/HR Assignment" + ","; Span90.Style["display"] = "inline-block"; break;
                case "HR Associate Contacted": strCtrlsIDsFraudEvents += txtHR_Associate_Contacted.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/HR Associate Contacted" + ","; Span91.Style["display"] = "inline-block"; break;
                case "Date HR Assigned": strCtrlsIDsFraudEvents += txtDate_HR_Assigned.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Date HR Assigned" + ","; Span92.Style["display"] = "inline-block"; break;
                case "Internal Audit Assignment": strCtrlsIDsFraudEvents += txtInternal_Audit_Assignment.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Internal Audit Assignment" + ","; Span93.Style["display"] = "inline-block"; break;
                case "Internal Audit Associate Contacted ": strCtrlsIDsFraudEvents += txtInternal_Audit_Associate_Contacted.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Internal Audit Associate Contacted " + ","; Span94.Style["display"] = "inline-block"; break;
                case "Date Internal Audit Assigned": strCtrlsIDsFraudEvents += txtDate_Internal_Audit_Assigned.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Date Internal Audit Assigned" + ","; Span95.Style["display"] = "inline-block"; break;
                case "Store Controller Assignment": strCtrlsIDsFraudEvents += txtStore_Controller_Assignment.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Store Controller Assignment" + ","; Span96.Style["display"] = "inline-block"; break;
                case "Store Controller Associate Contacted": strCtrlsIDsFraudEvents += txtStore_Controller_Associate_Contacted.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Store Controller Associate Contacted" + ","; Span97.Style["display"] = "inline-block"; break;
                case "Date Store Controller Assigned": strCtrlsIDsFraudEvents += txtDate_Store_Controller_Assigned.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Date Store Controller Assigned" + ","; Span98.Style["display"] = "inline-block"; break;
                case "Regional Controller Assignment ": strCtrlsIDsFraudEvents += txtRegional_Controller_Assignment.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Regional Controller Assignment " + ","; Span99.Style["display"] = "inline-block"; break;
                case "Regional Controller Associate Contacted": strCtrlsIDsFraudEvents += txtRegional_Controller_Associate_Contacted.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Regional Controller Associate Contacted" + ","; Span100.Style["display"] = "inline-block"; break;
                case "Date Regional Controller Assigned": strCtrlsIDsFraudEvents += txtDate_Regional_Controller_Assigned.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Date Regional Controller Assigned" + ","; Span101.Style["display"] = "inline-block"; break;
                case "Legal Department Assignment": strCtrlsIDsFraudEvents += txtLegal_Department_Assignment.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Legal Department Assignment" + ","; Span102.Style["display"] = "inline-block"; break;
                case "Legal Department Associate Contacted": strCtrlsIDsFraudEvents += txtLegal_Department_Associate_Contacted.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Legal Department Associate Contacted" + ","; Span103.Style["display"] = "inline-block"; break;
                case "Date Legal Department Assigned": strCtrlsIDsFraudEvents += txtDate_Legal_Department_Assigned.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Date Legal Department Assigned" + ","; Span104.Style["display"] = "inline-block"; break;
                case "Outside Legal Assignment": strCtrlsIDsFraudEvents += txtOutside_Legal_Assignment.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Outside Legal Assignment" + ","; Span105.Style["display"] = "inline-block"; break;
                case "Outside Legal Person Contacted": strCtrlsIDsFraudEvents += txtDate_Outside_Legal_Assigned.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Outside Legal Person Contacted" + ","; Span106.Style["display"] = "inline-block"; break;
                case "Date Outside Legal Assigned": strCtrlsIDsFraudEvents += txtDate_Outside_Legal_Assigned.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Date Outside Legal Assigned" + ","; Span107.Style["display"] = "inline-block"; break;
                case "Operations Assignment": strCtrlsIDsFraudEvents += txtOperations_Assignment.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Operations Assignment" + ","; Span108.Style["display"] = "inline-block"; break;
                case "Operations Associate Contacted": strCtrlsIDsFraudEvents += txtOperations_Associate_Contacted.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Operations Associate Contacted" + ","; Span109.Style["display"] = "inline-block"; break;
                case "Date Operations Assigned": strCtrlsIDsFraudEvents += txtDate_Operations_Assigned.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Date Operations Assigned" + ","; Span110.Style["display"] = "inline-block"; break;
                case "Retail Lending Assignment": strCtrlsIDsFraudEvents += txtRetail_Lending_Assignment.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Retail Lending Assignment" + ","; Span111.Style["display"] = "inline-block"; break;
                case "Retail Lending Associate Contacted": strCtrlsIDsFraudEvents += txtRetail_Lending_Associate_Contacted.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Retail Lending Associate Contacted" + ","; Span112.Style["display"] = "inline-block"; break;
                case "Date Retail Lending Assigned": strCtrlsIDsFraudEvents += txtDate_Retail_Lending_Assigned.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Date Retail Lending Assigned" + ","; Span113.Style["display"] = "inline-block"; break;
                case "BT Security Assignment": strCtrlsIDsFraudEvents += txtBT_Security_Assignment.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/BT Security Assignment" + ","; Span135.Style["display"] = "inline-block"; break;
                case "BT Security Associate Contacted": strCtrlsIDsFraudEvents += txtBT_Security_Associate_Contacted.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/BT Security Associate Contacted" + ","; Span136.Style["display"] = "inline-block"; break;
                case "Date BT Security Assigned": strCtrlsIDsFraudEvents += txtDate_BT_Security_Assigned.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Date BT Security Assigned" + ","; Span137.Style["display"] = "inline-block"; break;
                case "Other Assignment": strCtrlsIDsFraudEvents += txtOther_Assignment.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Other Assignment" + ","; Span138.Style["display"] = "inline-block"; break;
                case "Associated Contacted": strCtrlsIDsFraudEvents += txtAssociated_Contacted.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Associated Contacted" + ","; Span139.Style["display"] = "inline-block"; break;
                case "Date Assigned": strCtrlsIDsFraudEvents += txtDate_Assigned.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Date Assigned" + ","; Span140.Style["display"] = "inline-block"; break;
                case "On-Site Findings": strCtrlsIDsFraudEvents += txtOnSite_Findings.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/On-Site Findings" + ","; Span114.Style["display"] = "inline-block"; break;
                case "TLO Findings": strCtrlsIDsFraudEvents += txtTLO_Findings.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/TLO Findings" + ","; Span115.Style["display"] = "inline-block"; break;
                case "Statements Obtained": strCtrlsIDsFraudEvents += txtStatements_Obtained.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Statements Obtained" + ","; Span116.Style["display"] = "inline-block"; break;
                case "Fact Finding/Due-Diligence": strCtrlsIDsFraudEvents += txtFact_Finding_andor_Due_Diligence.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Fact Finding/Due-Diligence" + ","; Span117.Style["display"] = "inline-block"; break;
                case "Law Enforcement Involvement": strCtrlsIDsFraudEvents += txtLaw_Enforcement_Involvement.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Law Enforcement Involvement" + ","; Span118.Style["display"] = "inline-block"; break;
                case "Detailed Disposition Game Plan Description": strCtrlsIDsFraudEvents += txtDetailed_Deisposition_Game_Plan_Description.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Detailed Disposition Game Plan Description" + ","; Span119.Style["display"] = "inline-block"; break;
                case "Detail Description of Root Cause": strCtrlsIDsFraudEvents += txtDetail_Description_of_Root_Cause.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Detail Description of Root Cause" + ","; Span120.Style["display"] = "inline-block"; break;
                case "Detailed Description of Corrective Action/Recommendation": strCtrlsIDsFraudEvents += txtDetail_Description_of_Corrective_Action_andor_Recommendation.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Detailed Description of Corrective Action/Recommendation" + ","; Span121.Style["display"] = "inline-block"; break;
                case "Close Date": strCtrlsIDsFraudEvents += txtClose_Date.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Close Date" + ","; Span122.Style["display"] = "inline-block"; break;
                case "Reopen Date": strCtrlsIDsFraudEvents += txtReopen_Date.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Reopen Date" + ","; Span123.Style["display"] = "inline-block"; break;
                case "Comments": strCtrlsIDsFraudEvents += txtFraudEvent_Comments.ClientID + ","; strMessagesFraudEvents += "Please enter [Fraud Events]/Comments" + ","; Span124.Style["display"] = "inline-block"; break;
            }
            #endregion
            #region " Notes "
            switch (Convert.ToString(drFieldFraudEvents["Field_Name"]))
            {
                case "Date": strCtrlsIDsNotes += txtNotesDate.ClientID + ","; strMessagesNotes += "Please enter [Fraud Events]/Date" + ","; Span130.Style["display"] = "inline-block"; break;
                case "Note Text ": strCtrlsIDsNotes += txtNotesAdd.ClientID + ","; strMessagesNotes += "Please enter [Fraud Events]/Note Text " + ","; Span125.Style["display"] = "inline-block"; break;
            }
            #endregion
            #region " Transaction "
            switch (Convert.ToString(drFieldFraudEvents["Field_Name"]))
            {
                case "Transaction Type": strCtrlsIDsTransaction += ddlTransactionType.ClientID + ","; strMessagesTransaction += "Please select [Fraud Events]/Transaction Type" + ","; Span126.Style["display"] = "inline-block"; break;
                case "Transaction Catagory": strCtrlsIDsTransaction += ddlTransactionCatagory.ClientID + ","; strMessagesTransaction += "Please select [Fraud Events]/Transaction Catagory" + ","; Span127.Style["display"] = "inline-block"; break;
                case "Transaction Date": strCtrlsIDsTransaction += txtTransactionDate.ClientID + ","; strMessagesTransaction += "Please enter [Fraud Events]/Transaction Date" + ","; Span128.Style["display"] = "inline-block"; break;
                case "Transaction Amount": strCtrlsIDsTransaction += txtTransactionAmount.ClientID + ","; strMessagesTransaction += "Please enter [Fraud Events]/Transaction Amount" + ","; Span129.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDsFraudEvents = strCtrlsIDsFraudEvents.TrimEnd(',');
        strMessagesFraudEvents = strMessagesFraudEvents.TrimEnd(',');

        hdnControlIDsFraudEvents.Value = strCtrlsIDsFraudEvents;
        hdnErrorMsgsFraudEvents.Value = strMessagesFraudEvents;

        strCtrlsIDsNotes = strCtrlsIDsNotes.TrimEnd(',');
        strMessagesNotes = strMessagesNotes.TrimEnd(',');

        hdnControlIDsNotes.Value = strCtrlsIDsNotes;
        hdnErrorMsgsNotes.Value = strMessagesNotes;

        strCtrlsIDsTransaction = strCtrlsIDsTransaction.TrimEnd(',');
        strMessagesTransaction = strMessagesTransaction.TrimEnd(',');

        hdnControlIDsTransaction.Value = strCtrlsIDsTransaction;
        hdnErrorMsgsTransaction.Value = strMessagesTransaction;

        #endregion
    }

    #endregion

    #region For RLCM QA QC Module
    private void BindOpenDPDFROIs(string Dest)
    {
        if (Dest == "DPD")
        {
            rdoFROIs.SelectedIndex = 0;
            rdoDPD_FROIsView.SelectedIndex = 0;
            AP_DPD_FROIs_CommandArgs = null;
            BindAP_DPD_FROIs_Grid(CtrlPagingDPD_FROIs.CurrentPage, CtrlPagingDPD_FROIs.PageSize);
            ClearDPDFROIS();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else if (Dest == "AL")
        {
            rdoAL_FROIs.SelectedIndex = 0;
            rdoAL_FROIsView.SelectedIndex = 0;
            BindAP_AL_FROIs_Grid(CtrlPagingAL_FROIsView.CurrentPage, CtrlPagingAL_FROIsView.PageSize);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
        }
    }
    #endregion

    protected void gvBuildingPropertySecurity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "gvEdit")
        {
            PK_AP_Property_Security = Convert.ToDecimal(e.CommandArgument);
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            HiddenField hdnBuildingNumber = (HiddenField)row.FindControl("hdnBuildingNumber");
            if (hdnBuildingNumber != null)
            {
                lblHeaderLocationNumber.Text += " - Building";
                lblLocation_Number.Text += " - " + hdnBuildingNumber.Value;
            }

            ////Copy Functionality
            //Sets Building Number that needs to be copied from
            hdnBuildingNumberByLocation.Value = hdnBuildingNumber.Value;
            SetCopyButtonVisibility();
            BindDetailsForEditForProperty_Security();
            BindPropertySecurityMonitoringGrid();

            if (PK_AP_Property_Security == 0)
            {
                txtCCTV_Company_Name.Text = "ACI Protection";
                txtCCTV_Company_Address_1.Text = "970 Pittsburgh Drive";
                txtCCTV_Company_Address_2.Text = string.Empty;
                txtCCTV_Company_City.Text = "Delaware";
                drpFK_CCTV_Company_State.SelectedValue = "36";
                txtCCTV_Company_Zip.Text = "43015";
                txtCCTV_Company_Contact_Name.Text = "Richard Paglieri";
                txtCCTV_Comapny_Contact_Telephone.Text = "740-368-4177";
                txtCCTV_Company_Contact_EMail.Text = "rich@aciprotection.com";
            }

            tblMainPropertySecurityGrid.Style["display"] = "none";
            tblMainPropertySecurity.Style["display"] = "";
            dvProperty_SecuritySave.Style["display"] = "";
            ShoHideCameraRow();
        }
        else if (e.CommandName == "gvView")
        {
            PK_AP_Property_Security = Convert.ToDecimal(e.CommandArgument);
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            HiddenField hdnBuildingNumber = (HiddenField)row.FindControl("hdnBuildingNumberView");
            if (hdnBuildingNumber != null)
            {
                lblHeaderLocationNumber.Text += " - Building";
                lblLocation_Number.Text += " - " + hdnBuildingNumber.Value;
            }

            SetCopyButtonVisibility();
            BindDetailsForViewForProperty_Security();
            BindPropertySecurityMonitoringGrid();
            tblMainPropertySecurityGridView.Style["display"] = "none";
            tblMainPropertySecurityView.Style["display"] = "";
            //dvProperty_SecuritySave.Style["display"] = "";
            ShoHideCameraRow();
        }
        if (e.CommandName == "Remove")
        {
            PK_AP_Property_Security = Convert.ToDecimal(e.CommandArgument);
            clsAP_Property_Security.DeleteByPKBuilding(PK_AP_Property_Security);
            BindPropertySecurityBuilding();
        }
    }

    //Sets the visibility of Copy Button
    private void SetCopyButtonVisibility()
    {
        if (StrOperation == "edit")
        {
            if (PK_AP_Property_Security > 0)
                btnCopyBuilding.Style.Add("display", "");
            else
                btnCopyBuilding.Style.Add("display", "none");
        }
    }

    /// <summary>
    /// Fill Occupancy By FKLocation Drop downs
    /// </summary>
    /// <param name="dropDownList">All dropDownList</param>
    /// <param name="booladdSelectAsFirstElement">Add --select-- to first item in each drop down or not</param>
    //public static void FillOccupancyByFKLocation(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, decimal fK_LU_Location_ID)
    //{
    //    const string SELECT_STRING = "-- Select --";
    //    DataSet dsData = ERIMS.DAL.Building.SelectOccupancyByFKLocation(fK_LU_Location_ID);
    //    foreach (DropDownList lstToFill in dropDowns)
    //    {
    //        lstToFill.Items.Clear();
    //        lstToFill.DataTextField = "Building_Occupancy";
    //        lstToFill.DataValueField = "PK_Building_ID";
    //        lstToFill.DataSource = dsData.Tables[0].DefaultView;
    //        lstToFill.DataBind();
    //        //check require to add "-- select --" at first item of dropdown.
    //        if (booladdSelectAsFirstElement)
    //        {
    //            lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
    //        }
    //    }
    //}


}