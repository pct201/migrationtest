using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using Microsoft.VisualBasic;

public partial class SONIC_RealEstate_RepairMantenance : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_RE_Repair_Maintenance
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_RE_Repair_Maintenance"]);
        }
        set { ViewState["PK_RE_Repair_Maintenance"] = value; }
    }
    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(clsSession.Str_RE_Operation); }
    }

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (clsSession.Current_RE_Information_ID > 0)
            {
                RealEstate_Info.PK_RE_Information = clsSession.Current_RE_Information_ID;
                RealEstate_Info.BindrRealEstateInfo();
                BindDropDownList();
                PK_RE_Repair_Maintenance = 0;
                if (Request.QueryString["id"] != null)
                {
                    decimal index;
                    if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                    {
                        PK_RE_Repair_Maintenance = index;
                    }
                }

                btnViewAudit.Visible = (PK_RE_Repair_Maintenance > 0);
                if (StrOperation != string.Empty)
                {
                    //PK_Executive_Risk_Contacts = Convert.ToInt32(Request.QueryString["id"]);
                    if (StrOperation == "view")
                    {
                        // Bind Controls
                        BindDetailsForView();
                    }
                    else
                    {
                        // check if user has only view rights and try to edit record.
                        if (App_Access == AccessType.View_Only)
                        {
                            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                        }
                        // Bind Controls
                        BindDetailsForEdit();
                    }
                }
                else
                {
                    // don't show div for view mode
                    dvView.Style["display"] = "none";                   
                }
            }
            else
            {
                Response.Redirect("RealEstateAddEdit.aspx", true);
            }
            SetValidations();
        }
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Lease);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Bind All drop Down list
    /// </summary>
    private void BindDropDownList()
    {
        //Repair Type
        DataTable dtRepairType = LU_Repair_Type.SelectAll().Tables[0];
        dtRepairType.DefaultView.RowFilter = "Active = 'Y'";
        dtRepairType = dtRepairType.DefaultView.ToTable();
        drpFK_LU_Repair_Type.DataSource = dtRepairType;
        drpFK_LU_Repair_Type.DataTextField = "Fld_Desc";
        drpFK_LU_Repair_Type.DataValueField = "PK_LU_Repair_Type";
        drpFK_LU_Repair_Type.DataBind();
        drpFK_LU_Repair_Type.Items.Insert(0, new ListItem("--Select--", "0"));

        //Scope of work
        DataTable dtWorkScope = LU_Work_Scope.SelectAll().Tables[0];
        dtWorkScope.DefaultView.RowFilter = "Active='Y'";
        dtWorkScope = dtWorkScope.DefaultView.ToTable();
        drpFK_LU_Work_Scope.DataSource = dtWorkScope;
        drpFK_LU_Work_Scope.DataTextField = "Fld_Desc";
        drpFK_LU_Work_Scope.DataValueField = "PK_LU_Work_Scope";
        drpFK_LU_Work_Scope.DataBind();
        drpFK_LU_Work_Scope.Items.Insert(0, new ListItem("--Select--", "0"));

        ///States
        DataTable dtContractor = RE_Contractor.SelectAllContractor().Tables[0];
        dtContractor.DefaultView.RowFilter = "Active='Y'";
        dtContractor = dtContractor.DefaultView.ToTable();
        drpFK_RE_Contractor.DataSource = dtContractor;
        drpFK_RE_Contractor.DataTextField = "Contractor";
        drpFK_RE_Contractor.DataValueField = "PK_RE_Contractor";
        drpFK_RE_Contractor.DataBind();

        drpFK_RE_Contractor.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Style["display"] = "none";
        dvEdit.Style["display"] = "block";

        RE_Repair_Maintenance objRE_Repair_Maintenance = new RE_Repair_Maintenance(PK_RE_Repair_Maintenance);
        drpFK_LU_Repair_Type.SelectedValue = objRE_Repair_Maintenance.FK_LU_Repair_Type.ToString();
        txtDate_PCA_Ordered.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Repair_Maintenance.Date_PCA_Ordered);
        txtDate_PCA_Conducted.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Repair_Maintenance.Date_PCA_Conducted);
        txtPCA_Conducted_By.Text = objRE_Repair_Maintenance.PCA_Conducted_By;
        drpFK_LU_Work_Scope.SelectedValue = objRE_Repair_Maintenance.FK_LU_Work_Scope.ToString();
        txtRepairDesc.Text = Convert.ToString(objRE_Repair_Maintenance.Damage_Description);
        txtDetailed_Description.Text = objRE_Repair_Maintenance.Detailed_Description;
        drpFK_RE_Contractor.SelectedValue = Convert.ToString(objRE_Repair_Maintenance.FK_RE_Contractor);
        BindContractorDetails(Convert.ToDecimal(drpFK_RE_Contractor.SelectedValue));
        txtEstimate_Amount.Text = clsGeneral.GetStringValue(objRE_Repair_Maintenance.Estimate_Amount);
        txtProposal_Amount.Text = clsGeneral.GetStringValue(objRE_Repair_Maintenance.Proposal_Amount);
        txtActual_Amount.Text = clsGeneral.GetStringValue(objRE_Repair_Maintenance.Actual_Amount);
        txtEstaimted_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Repair_Maintenance.Estaimted_Start_Date);
        txtActual_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Repair_Maintenance.Actual_Start_Date);
        txtEnd_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Repair_Maintenance.End_Date);

        if (objRE_Repair_Maintenance.Actual_Start_Date != null && objRE_Repair_Maintenance.End_Date != null)
        {
            long lngDaysDiff = Microsoft.VisualBasic.DateAndTime.DateDiff(DateInterval.Day, Convert.ToDateTime(objRE_Repair_Maintenance.Actual_Start_Date), Convert.ToDateTime(objRE_Repair_Maintenance.End_Date), Microsoft.VisualBasic.FirstDayOfWeek.System, FirstWeekOfYear.System);
            txtNumberofDay.Text = lngDaysDiff.ToString();
        }

        if (objRE_Repair_Maintenance.Actual_Amount != null && objRE_Repair_Maintenance.Proposal_Amount != null)
        {
            txtVariance.Text = clsGeneral.GetStringValue(Convert.ToString(Convert.ToDecimal(objRE_Repair_Maintenance.Actual_Amount) - Convert.ToDecimal(objRE_Repair_Maintenance.Proposal_Amount)));
        }
    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        if (PK_RE_Repair_Maintenance > 0)
        {
            dvView.Style["display"] = "block";
            dvEdit.Style["display"] = "none";
            dvSave.Style["display"] = "none";

            RE_Repair_Maintenance objRE_Repair_Maintenance = new RE_Repair_Maintenance(PK_RE_Repair_Maintenance);
            lblFK_LU_Repair_Type.Text = objRE_Repair_Maintenance.FK_LU_Repair_Type != null ? new LU_Repair_Type(Convert.ToDecimal(objRE_Repair_Maintenance.FK_LU_Repair_Type)).Fld_Desc : "";
            lblDate_PCA_Ordered.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Repair_Maintenance.Date_PCA_Ordered);
            lblDate_PCA_Conducted.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Repair_Maintenance.Date_PCA_Conducted);
            lblPCA_Conducted_By.Text = objRE_Repair_Maintenance.PCA_Conducted_By;
            lblFK_LU_Work_Scope.Text = objRE_Repair_Maintenance.FK_LU_Work_Scope != null ? new LU_Work_Scope(Convert.ToDecimal(objRE_Repair_Maintenance.FK_LU_Work_Scope)).Fld_Desc : "";
            lblRepairDamageDesc.Text = Convert.ToString(objRE_Repair_Maintenance.Damage_Description);
            lblDetailed_Description.Text = objRE_Repair_Maintenance.Detailed_Description;
            lblEstimate_Amount.Text = clsGeneral.GetStringValue(objRE_Repair_Maintenance.Estimate_Amount);
            lblProposal_Amount.Text = clsGeneral.GetStringValue(objRE_Repair_Maintenance.Proposal_Amount);
            lblActual_Amount.Text = clsGeneral.GetStringValue(objRE_Repair_Maintenance.Actual_Amount);
            lblEstaimted_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Repair_Maintenance.Estaimted_Start_Date);
            lblActual_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Repair_Maintenance.Actual_Start_Date);
            lblEnd_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRE_Repair_Maintenance.End_Date);

            if (objRE_Repair_Maintenance.Actual_Start_Date != null && objRE_Repair_Maintenance.End_Date != null)
            {
                long lngDaysDiff = Microsoft.VisualBasic.DateAndTime.DateDiff(DateInterval.Day, Convert.ToDateTime(objRE_Repair_Maintenance.Actual_Start_Date), Convert.ToDateTime(objRE_Repair_Maintenance.End_Date), Microsoft.VisualBasic.FirstDayOfWeek.System, FirstWeekOfYear.System);
                lblNumberofDayView.Text = lngDaysDiff.ToString();
            }

            if (objRE_Repair_Maintenance.Actual_Amount != null && objRE_Repair_Maintenance.Proposal_Amount != null)
            {
                lblVarianceview.Text = clsGeneral.GetStringValue(Convert.ToString(Convert.ToDecimal(objRE_Repair_Maintenance.Actual_Amount) - Convert.ToDecimal(objRE_Repair_Maintenance.Proposal_Amount)));
            }

            RE_Contractor objRE_Contractor = new RE_Contractor(clsGeneral.GetInt(objRE_Repair_Maintenance.FK_RE_Contractor));

            lblFK_RE_Contractor.Text = objRE_Contractor.Contractor_Company + " - " + objRE_Contractor.Contractor_Contact + " - " + objRE_Contractor.Contractor_City;
            lblContractor_Contact.Text = objRE_Contractor.Contractor_Contact;
            lblContractor_Address1.Text = objRE_Contractor.Contractor_Address1;
            lblContractor_Address2.Text = objRE_Contractor.Contractor_Address2;
            lblContractor_City.Text = objRE_Contractor.Contractor_City;
            lblFK_State_Contractor.Text = objRE_Contractor.FK_State_Contractor.ToString();
            lblContractor_Zip_Code.Text = objRE_Contractor.Contractor_Zip_Code;
            lblContractor_Telephone.Text = objRE_Contractor.Contractor_Telephone;
            lblContractor_Facsimile.Text = objRE_Contractor.Contractor_Facsimile;
            lblContractor_Email.Text = objRE_Contractor.Contractor_Email;
        }
        else
        {
            Response.Redirect("RealEstateAddEdit.aspx?id=" + Encryption.Encrypt(clsSession.Current_RE_Information_ID.ToString()) + "&pnl=5", true);
        }
    }

    /// <summary>
    /// Bind Contractor Details
    /// </summary>
    /// <param name="FK_RE_Contractor"></param>
    private void BindContractorDetails(decimal FK_RE_Contractor)
    {
        RE_Contractor objRE_Contractor = new RE_Contractor(FK_RE_Contractor);
        lblContactName.Text = objRE_Contractor.Contractor_Contact;
        lblAddress1.Text = objRE_Contractor.Contractor_Address1;
        lblAddress2.Text = objRE_Contractor.Contractor_Address2;
        lblCity.Text = objRE_Contractor.Contractor_City;
        lblState.Text = Convert.ToString(new State(Convert.ToDecimal(objRE_Contractor.FK_State_Contractor)).FLD_state);
        lblZipCode.Text = objRE_Contractor.Contractor_Zip_Code;
        lblTelephone.Text = objRE_Contractor.Contractor_Telephone;
        lblFacsimile.Text = objRE_Contractor.Contractor_Facsimile;
        lblEmail.Text = objRE_Contractor.Contractor_Email;
    }

    /// <summary>
    /// set properties for save
    /// </summary>
    /// <param name="objRE_Repair_Maintenance"></param>
    private void setProperties(RE_Repair_Maintenance objRE_Repair_Maintenance)
    {
        objRE_Repair_Maintenance.PK_RE_Repair_Maintenance = PK_RE_Repair_Maintenance;
        objRE_Repair_Maintenance.FK_RE_Information = clsSession.Current_RE_Information_ID;
        objRE_Repair_Maintenance.FK_LU_Repair_Type = drpFK_LU_Repair_Type.SelectedIndex > 0 ? Convert.ToDecimal(drpFK_LU_Repair_Type.SelectedValue) : -1;
        objRE_Repair_Maintenance.Date_PCA_Ordered = clsGeneral.FormatNullDateToStore(txtDate_PCA_Ordered.Text);
        objRE_Repair_Maintenance.Date_PCA_Conducted = clsGeneral.FormatNullDateToStore(txtDate_PCA_Conducted.Text);
        objRE_Repair_Maintenance.PCA_Conducted_By = txtPCA_Conducted_By.Text.Trim();
        objRE_Repair_Maintenance.FK_LU_Work_Scope = drpFK_LU_Work_Scope.SelectedIndex > 0 ? Convert.ToDecimal(drpFK_LU_Work_Scope.SelectedValue) : -1;
        objRE_Repair_Maintenance.Damage_Description = txtRepairDesc.Text.Trim();
        objRE_Repair_Maintenance.Detailed_Description = txtDetailed_Description.Text.Trim();
        objRE_Repair_Maintenance.FK_RE_Contractor = drpFK_RE_Contractor.SelectedIndex > 0 ? Convert.ToDecimal(drpFK_RE_Contractor.SelectedValue) : -1;
        objRE_Repair_Maintenance.Estimate_Amount = clsGeneral.GetDecimalValue(txtEstimate_Amount);
        objRE_Repair_Maintenance.Proposal_Amount = clsGeneral.GetDecimalValue(txtProposal_Amount);
        objRE_Repair_Maintenance.Actual_Amount = clsGeneral.GetDecimalValue(txtActual_Amount);
        objRE_Repair_Maintenance.Estaimted_Start_Date = clsGeneral.FormatNullDateToStore(txtEstaimted_Start_Date.Text);
        objRE_Repair_Maintenance.Actual_Start_Date = clsGeneral.FormatNullDateToStore(txtActual_Start_Date.Text);
        objRE_Repair_Maintenance.End_Date = clsGeneral.FormatNullDateToStore(txtEnd_Date.Text);
        objRE_Repair_Maintenance.Update_Date = DateTime.Now;
        objRE_Repair_Maintenance.Updated_By = clsSession.UserID;
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
        RE_Repair_Maintenance objRE_Repair_Maintenance = new RE_Repair_Maintenance();
        setProperties(objRE_Repair_Maintenance);
        if (PK_RE_Repair_Maintenance > 0)
        {
            objRE_Repair_Maintenance.Update();
        }
        else
        {
            objRE_Repair_Maintenance.Insert();
        }

        if (Request.QueryString["loc"] != null)
            Response.Redirect("Lease.aspx?loc=" + Request.QueryString["loc"] + "&pnl=6&op=" + clsSession.Str_RE_Operation, true);
        else
            Response.Redirect("RealEstateAddEdit.aspx?pnl=6", true);
    }

    /// <summary>
    /// Handel Back Button event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["loc"] != null)
            Response.Redirect("Lease.aspx?loc=" + Request.QueryString["loc"] + "&pnl=6&op=" + clsSession.Str_RE_Operation, true);
        else
            Response.Redirect("RealEstateAddEdit.aspx?pnl=6", true);
    }

    /// <summary>
    /// Handle Dropdown Selected Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpFK_RE_Contractor_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindContractorDetails(Convert.ToDecimal(drpFK_RE_Contractor.SelectedValue));
    }

    #endregion

    #region Dynamic Validations

    private void SetValidations()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region "Rent Projections - Term Rent Schedule"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(73).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Type of Repair":
                    strCtrlsIDs += drpFK_LU_Repair_Type.ClientID + ",";
                    strMessages += "Please enter Type of Repair" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Date PCA Ordered":
                    strCtrlsIDs += txtDate_PCA_Ordered.ClientID + ",";
                    strMessages += "Please enter Date PCA Ordered" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Date PCA Conducted":
                    strCtrlsIDs += txtDate_PCA_Conducted.ClientID + ",";
                    strMessages += "Please enter Date PCA Conducted" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "PCA Conducted By":
                    strCtrlsIDs += txtPCA_Conducted_By.ClientID + ",";
                    strMessages += "Please enter PCA Conducted By" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Scope of Work":
                    strCtrlsIDs += drpFK_LU_Work_Scope.ClientID + ",";
                    strMessages += "Please enter Scope of Work" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "General Repair/Damage Description":
                    strCtrlsIDs += txtRepairDesc.ClientID + ",";
                    strMessages += "Please enter General Repair/Damage Description" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Detailed Description of Repair/Damage":
                    strCtrlsIDs += txtDetailed_Description.ClientID + ",";
                    strMessages += "Please enter Detailed Description of Repair/Damage" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Contractor":
                    strCtrlsIDs += drpFK_RE_Contractor.ClientID + ",";
                    strMessages += "Please enter Contractor" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Estimate Amount":
                    strCtrlsIDs += txtEstimate_Amount.ClientID + ",";
                    strMessages += "Please enter Estimate Amount" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Proposal Amount":
                    strCtrlsIDs += txtProposal_Amount.ClientID + ",";
                    strMessages += "Please enter Proposal Amount" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Actual Amount":
                    strCtrlsIDs += txtActual_Amount.ClientID + ",";
                    strMessages += "Please enter Actual Amount" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Variance":
                    strCtrlsIDs += txtVariance.ClientID + ",";
                    strMessages += "Please enter Variance" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Estimated Start Date":
                    strCtrlsIDs += txtEstaimted_Start_Date.ClientID + ",";
                    strMessages += "Please enter Estimated Start Date" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "Actual Start Date":
                    strCtrlsIDs += txtActual_Start_Date.ClientID + ",";
                    strMessages += "Please enter Actual Start Date" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "End Date":
                    strCtrlsIDs += txtEnd_Date.ClientID + ",";
                    strMessages += "Please enter End Date" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                case "Number of Day":
                    strCtrlsIDs += txtNumberofDay.ClientID + ",";
                    strMessages += "Please enter Number of Day" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
        #endregion
    }

    #endregion
}
