using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
public partial class SONIC_Pollution_ComplianceReporting_ChemicalInventory : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_CR_Chemical_Inventory
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_CR_Chemical_Inventory"]);
        }
        set { ViewState["PK_PM_CR_Chemical_Inventory"] = value; }
    }
    public decimal FK_PM_Compliance_Reporting
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_PM_Compliance_Reporting"]);
        }
        set { ViewState["FK_PM_Compliance_Reporting"] = value; }
    }
    public decimal FK_PM_Site_Information
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_PM_Site_Information"]);
        }
        set { ViewState["FK_PM_Site_Information"] = value; }
    }
    /// <summary>
    /// Denotes foriegn key for Location record
    /// </summary>
    public decimal FK_LU_Location_ID
    {
        get { return Convert.ToInt32(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_CR_CI_Hazards
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_CR_CI_Hazards"]);
        }
        set { ViewState["PK_PM_CR_CI_Hazards"] = value; }
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
    protected void Page_Load(object sender, EventArgs e)
    {
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Pollution);
        Attachment.btnHandler += new Attachment_Pollution.OnButtonClick(Upload_File);
        if (!Page.IsPostBack)
        {          
            BindDropDown();
            StrOperation = Convert.ToString(Request.QueryString["op"]);
            PK_PM_CR_Chemical_Inventory = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_PM_Compliance_Reporting = clsGeneral.GetQueryStringID(Request.QueryString["cid"]);
            FK_PM_Site_Information = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);
            FK_LU_Location_ID = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);
            // check if location id is passed in querystring or not
            if (FK_LU_Location_ID > 0)
            {
                Session["ExposureLocation"] = FK_LU_Location_ID;
                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx");
            if (PK_PM_CR_Chemical_Inventory > 0)
            {
                //PK_Executive_Risk_Contacts = Convert.ToInt32(Request.QueryString["id"]);
                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDetailsForView();
                    btnCancelView.Visible = (App_Access == AccessType.Administrative_Access);
                    // set attachment details control in readonly mode.
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_CR_CI_Attachments, Convert.ToInt32(PK_PM_CR_Chemical_Inventory), "FK_PM_CR_Chemical_Inventory", "PK_PM_CR_CI_Attachments", false, 2);
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    SetValidations();
                    // Bind Controls
                    BindDetailsForEdit();
                    // set attachment details control in read/write mode. so user can add or remove attachment as well.
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_CR_CI_Attachments, Convert.ToInt32(PK_PM_CR_Chemical_Inventory), "FK_PM_CR_Chemical_Inventory", "PK_PM_CR_CI_Attachments", true, 2);
                }
                BindAttachmentDetails();
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                SetValidations();
                btnAuditTrail.Visible = false;
                // disable Add Attachment button               
                BindAttachmentDetails();
                // don't show div for view mode
                dvView.Style["display"] = "none";
                BindHazardTypeGrid(PK_PM_CR_Chemical_Inventory);
            }
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        clsPM_CR_Chemical_Inventory objPM_CR_Chemical_Inventory = new clsPM_CR_Chemical_Inventory(PK_PM_CR_Chemical_Inventory);
        FK_PM_Compliance_Reporting = Convert.ToDecimal(objPM_CR_Chemical_Inventory.FK_PM_Compliance_Reporting);
        if (objPM_CR_Chemical_Inventory.FK_LU_Chemical_Type != null)
        {
            ListItem lst = drpFK_LU_Chemical_Type.Items.FindByValue(objPM_CR_Chemical_Inventory.FK_LU_Chemical_Type.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_LU_Chemical_Type.SelectedValue=objPM_CR_Chemical_Inventory.FK_LU_Chemical_Type.ToString();
        }
        txtCAS_Number.Text = objPM_CR_Chemical_Inventory.CAS_Number;
        rdoPure_Mixture.SelectedValue = objPM_CR_Chemical_Inventory.Pure_Mixture;
        txtChemical_Name.Text = objPM_CR_Chemical_Inventory.Chemical_Name;
        txtMixture_Components.Text = objPM_CR_Chemical_Inventory.Mixture_Components;
        rdoPhysical_State.SelectedValue = objPM_CR_Chemical_Inventory.Physical_State;
        txtMaximum_Pounds_On_Site.Text = clsGeneral.GetStringValue(objPM_CR_Chemical_Inventory.Maximum_Pounds_On_Site);
        txtDaily_maximum_Pounds_On_Site.Text = clsGeneral.GetStringValue(objPM_CR_Chemical_Inventory.Daily_maximum_Pounds_On_Site);
        txtAverage_Pounds_On_Site.Text = clsGeneral.GetStringValue(objPM_CR_Chemical_Inventory.Average_Pounds_On_Site);
        txtDaily_Average_Pounds_On_Site.Text = clsGeneral.GetStringValue(objPM_CR_Chemical_Inventory.Daily_Average_Pounds_On_Site);
        if (objPM_CR_Chemical_Inventory.FK_LU_Storage_Type != null)
        {
            ListItem lst = drpFK_LU_Storage_Type.Items.FindByValue(objPM_CR_Chemical_Inventory.FK_LU_Storage_Type.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_LU_Storage_Type.SelectedValue = objPM_CR_Chemical_Inventory.FK_LU_Storage_Type.ToString();
        }
        if (objPM_CR_Chemical_Inventory.FK_LU_Storage_Location != null)
        {
            ListItem lst = drpFK_LU_Storage_Location.Items.FindByValue(objPM_CR_Chemical_Inventory.FK_LU_Storage_Location.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_LU_Storage_Location.SelectedValue = objPM_CR_Chemical_Inventory.FK_LU_Storage_Location.ToString();
        }
        txtState_Local_Fees.Text = clsGeneral.GetStringValue(objPM_CR_Chemical_Inventory.State_Local_Fees);
        txtMethod.Text = objPM_CR_Chemical_Inventory.Method;
        txtDescription.Text = objPM_CR_Chemical_Inventory.Description;
        rdoInitial_6H_Notification_Submitted.SelectedValue = objPM_CR_Chemical_Inventory.Initial_6H_Notification_Submitted;
        rdoSixH_Compliance_Verification_Submitted.SelectedValue = objPM_CR_Chemical_Inventory.SixH_Compliance_Verification_Submitted;
        rdoNotifications_6H_Changes_Reports_Submitted.SelectedValue = objPM_CR_Chemical_Inventory.Notifications_6H_Changes_Reports_Submitted;
        BindHazardTypeGrid(PK_PM_CR_Chemical_Inventory);
    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        dvSave.Visible = true;
        btnSave.Visible = false;
        btnCancelView.Visible = true;
        clsPM_CR_Chemical_Inventory objPM_CR_Chemical_Inventory = new clsPM_CR_Chemical_Inventory(PK_PM_CR_Chemical_Inventory);
        FK_PM_Compliance_Reporting = Convert.ToDecimal(objPM_CR_Chemical_Inventory.FK_PM_Compliance_Reporting);
        if (objPM_CR_Chemical_Inventory.FK_LU_Chemical_Type != null)
            lblFK_LU_Chemical_Type.Text = new clsLU_Chemical_Type((decimal)objPM_CR_Chemical_Inventory.FK_LU_Chemical_Type).Fld_Desc;
        lblCAS_Number.Text = objPM_CR_Chemical_Inventory.CAS_Number;
        lblPure_Mixture.Text = objPM_CR_Chemical_Inventory.Pure_Mixture == "P" ? "Pure" : "Mixture";
        lblChemical_Name.Text = objPM_CR_Chemical_Inventory.Chemical_Name;
        lblMixture_Components.Text = objPM_CR_Chemical_Inventory.Mixture_Components;
        lblPhysical_State.Text = objPM_CR_Chemical_Inventory.Physical_State == "S" ? "Solid" : objPM_CR_Chemical_Inventory.Physical_State == "L" ? "Liquid" : "Gas";
        lblMaximum_Pounds_On_Site.Text = clsGeneral.GetStringValue(objPM_CR_Chemical_Inventory.Maximum_Pounds_On_Site);
        lblDaily_maximum_Pounds_On_Site.Text = clsGeneral.GetStringValue(objPM_CR_Chemical_Inventory.Daily_maximum_Pounds_On_Site);
        lblAverage_Pounds_On_Site.Text = clsGeneral.GetStringValue(objPM_CR_Chemical_Inventory.Average_Pounds_On_Site);
        lblDaily_Average_Pounds_On_Site.Text = clsGeneral.GetStringValue(objPM_CR_Chemical_Inventory.Daily_Average_Pounds_On_Site);
        if (objPM_CR_Chemical_Inventory.FK_LU_Storage_Type != null)
            lblFK_LU_Storage_Type.Text = new clsLU_Storage_Type((decimal)objPM_CR_Chemical_Inventory.FK_LU_Storage_Type).Fld_Desc;
        if (objPM_CR_Chemical_Inventory.FK_LU_Storage_Location != null)
            lblFK_LU_Storage_Location.Text = new clsLU_Storage_Location((decimal)objPM_CR_Chemical_Inventory.FK_LU_Storage_Location).Fld_Desc;
        lblState_Local_Fees.Text = string.Format("{0:C2}",objPM_CR_Chemical_Inventory.State_Local_Fees);
        lblMethod.Text = objPM_CR_Chemical_Inventory.Method;
        lblDescription.Text = objPM_CR_Chemical_Inventory.Description;
        lblInitial_6H_Notification_Submitted.Text = objPM_CR_Chemical_Inventory.Initial_6H_Notification_Submitted == "Y" ? "Yes" : objPM_CR_Chemical_Inventory.Initial_6H_Notification_Submitted == "R" ? "Not Required" : "No";
        lblSixH_Compliance_Verification_Submitted.Text = objPM_CR_Chemical_Inventory.SixH_Compliance_Verification_Submitted == "Y" ? "Yes" : objPM_CR_Chemical_Inventory.SixH_Compliance_Verification_Submitted == "R" ? "Not Required" : "No";
        lblNotifications_6H_Changes_Reports_Submitted.Text = objPM_CR_Chemical_Inventory.Notifications_6H_Changes_Reports_Submitted == "Y" ? "Yes" : "No";
        BindHazardTypeGridView(PK_PM_CR_Chemical_Inventory);
    }

    //Fill DropDown List Data
    private void BindDropDown()
    {
        ComboHelper.FillChemicalType(new DropDownList[] { drpFK_LU_Chemical_Type }, true);
        ComboHelper.FillStorageLocation(new DropDownList[] { drpFK_LU_Storage_Location  }, true);
        ComboHelper.FillStorageType(new DropDownList[] { drpFK_LU_Storage_Type }, true);
        ComboHelper.FillHazardType(new DropDownList[] { drpHazardType }, true);  
    }
    /// <summary>
    /// Save Data
    /// </summary>
    private void SaveData()
    {
        clsPM_CR_Chemical_Inventory objPM_CR_Chemical_Inventory = new clsPM_CR_Chemical_Inventory();
        objPM_CR_Chemical_Inventory.PK_PM_CR_Chemical_Inventory = PK_PM_CR_Chemical_Inventory;
        objPM_CR_Chemical_Inventory.FK_PM_Compliance_Reporting = FK_PM_Compliance_Reporting;
        if (drpFK_LU_Chemical_Type.SelectedIndex > 0) objPM_CR_Chemical_Inventory.FK_LU_Chemical_Type = Convert.ToDecimal(drpFK_LU_Chemical_Type.SelectedValue);
        objPM_CR_Chemical_Inventory.CAS_Number = txtCAS_Number.Text.Trim();
        objPM_CR_Chemical_Inventory.Pure_Mixture = rdoPure_Mixture.SelectedValue;
        objPM_CR_Chemical_Inventory.Chemical_Name = txtChemical_Name.Text.Trim();
        objPM_CR_Chemical_Inventory.Mixture_Components = txtMixture_Components.Text.Trim();
        objPM_CR_Chemical_Inventory.Physical_State = rdoPhysical_State.SelectedValue;
        if (txtMaximum_Pounds_On_Site.Text != "") objPM_CR_Chemical_Inventory.Maximum_Pounds_On_Site = clsGeneral.GetDecimalValue(txtMaximum_Pounds_On_Site);
        if (txtDaily_maximum_Pounds_On_Site.Text != "") objPM_CR_Chemical_Inventory.Daily_maximum_Pounds_On_Site = clsGeneral.GetDecimalValue(txtDaily_maximum_Pounds_On_Site);
        if (txtAverage_Pounds_On_Site.Text != "") objPM_CR_Chemical_Inventory.Average_Pounds_On_Site = clsGeneral.GetDecimalValue(txtAverage_Pounds_On_Site);
        if (txtDaily_Average_Pounds_On_Site.Text != "") objPM_CR_Chemical_Inventory.Daily_Average_Pounds_On_Site = clsGeneral.GetDecimalValue(txtDaily_Average_Pounds_On_Site);
        if (drpFK_LU_Storage_Type.SelectedIndex > 0) objPM_CR_Chemical_Inventory.FK_LU_Storage_Type = Convert.ToDecimal(drpFK_LU_Storage_Type.SelectedValue);
        if (drpFK_LU_Storage_Location.SelectedIndex > 0) objPM_CR_Chemical_Inventory.FK_LU_Storage_Location = Convert.ToDecimal(drpFK_LU_Storage_Location.SelectedValue);
        if (txtState_Local_Fees.Text != "") objPM_CR_Chemical_Inventory.State_Local_Fees = clsGeneral.GetDecimalValue(txtState_Local_Fees);
        objPM_CR_Chemical_Inventory.Method = txtMethod.Text.Trim();
        objPM_CR_Chemical_Inventory.Description = txtDescription.Text.Trim();
        objPM_CR_Chemical_Inventory.Initial_6H_Notification_Submitted = rdoInitial_6H_Notification_Submitted.SelectedValue;
        objPM_CR_Chemical_Inventory.SixH_Compliance_Verification_Submitted = rdoSixH_Compliance_Verification_Submitted.SelectedValue;
        objPM_CR_Chemical_Inventory.Notifications_6H_Changes_Reports_Submitted = rdoNotifications_6H_Changes_Reports_Submitted.SelectedValue;
        objPM_CR_Chemical_Inventory.Update_Date = DateTime.Now;
        objPM_CR_Chemical_Inventory.Updated_By = clsSession.UserID;
        if (PK_PM_CR_Chemical_Inventory > 0)
            objPM_CR_Chemical_Inventory.Update();
        else
            PK_PM_CR_Chemical_Inventory = objPM_CR_Chemical_Inventory.Insert();
    }
    /// <summary>
    /// Get Record into Hazard Grid - Edit mode
    /// </summary>
    /// <param name="PK_ID">Primary key value for Role table</param>
    private void BindHazardTypeGrid(decimal PK_ID)
    {
        gvHazards.DataSource = clsPM_CR_CI_Hazards.SelectAllByFK(PK_ID);
        gvHazards.DataBind();
    }
    /// <summary>
    /// Get Record into Hazard Grid - View mode
    /// </summary>
    /// <param name="PK_ID">Primary key value for Role table</param>
    private void BindHazardTypeGridView(decimal PK_ID)
    {
        gvHazardsView.DataSource = clsPM_CR_CI_Hazards.SelectAllByFK(PK_ID);
        gvHazardsView.DataBind();
    }

    #endregion

    #region Control Events
    /// <summary>
    /// handles Hazard grid Row Command event
    /// </summary>    
    protected void gvHazards_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            decimal decPK = Convert.ToDecimal(e.CommandArgument);
            clsPM_CR_CI_Hazards.DeleteByPK(decPK);
            BindHazardTypeGrid(PK_PM_CR_Chemical_Inventory);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
    }
    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveData();
        Upload_File("");
        Response.Redirect("ChemicalInventory.aspx?id=" + Encryption.Encrypt(PK_PM_CR_Chemical_Inventory.ToString()) +"&fid=" + Encryption.Encrypt(FK_PM_Site_Information.ToString()) + "&loc=" + Request.QueryString["loc"] + "&op=view");
    }
    /// <summary>
    /// Handles Back Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnback_Click(object sender, EventArgs e)
    {
        if (StrOperation == "view")
            StrOperation = "view";
        else
            StrOperation = "edit";       
        Response.Redirect("Pollution.aspx?op=" + StrOperation + "&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Request.QueryString["loc"]+"&pnl=" + Encryption.Encrypt("3"));
    }
     /// <summary>
    /// Handles Cancel View Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChemicalInventory.aspx?id=" + Encryption.Encrypt(PK_PM_CR_Chemical_Inventory.ToString()) + "&fid=" + Encryption.Encrypt(FK_PM_Site_Information.ToString()) + "&loc=" + Request.QueryString["loc"] + "&op=edit");
    }
    /// <summary>
    /// Handles Add New Hazards Identification Button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddHazards_Click(object sender, EventArgs e)
    {
       
        SaveData();
        PK_PM_CR_CI_Hazards = 0;
        drpHazardType.SelectedIndex = 0;
        pnlDetail.Visible = false;
        pnlAddHazard.Visible = true;
        hdnVisibleAttach.Value = "1";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    /// <summary>
    ///  Handles Cancel Hazards Identification Button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelHazard_Click(object sender, EventArgs e)
    {
        pnlDetail.Visible = true;
        pnlAddHazard.Visible = false;
        hdnVisibleAttach.Value = "0";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    /// <summary>
    ///  Handles Save Hazards Identification Button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveHazard_Click(object sender, EventArgs e)
    {
        clsPM_CR_CI_Hazards objPM_CR_CI_Hazards = new clsPM_CR_CI_Hazards();
        decimal _retVal;
        objPM_CR_CI_Hazards.PK_PM_CR_CI_Hazards = PK_PM_CR_CI_Hazards;
        objPM_CR_CI_Hazards.FK_PM_CR_Chemical_Inventory = PK_PM_CR_Chemical_Inventory;
        if (drpHazardType.SelectedIndex > 0)
            objPM_CR_CI_Hazards.FK_LU_Hazard_Type = Convert.ToDecimal(drpHazardType.SelectedValue);
        _retVal = objPM_CR_CI_Hazards.Insert();
        if (_retVal < 0)
        {
            if (_retVal == -2)
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('The Hazards Type you are trying to add already exists');", true);
                drpHazardType.Focus();
            }
            return;
        }
        else
        {
            PK_PM_CR_CI_Hazards = _retVal;
        }
        //clear Control
        drpHazardType.SelectedIndex = 0;
        //Bind Grid Function
        BindHazardTypeGrid(PK_PM_CR_Chemical_Inventory);   
        pnlDetail.Visible = true;
        pnlAddHazard.Visible = false;
        hdnVisibleAttach.Value = "0";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    #endregion

    #region Attachments Management
    /// <summary>
    /// Binds the attachment details
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["display"] = "block";
        if (StrOperation == "view")
        {
            AttachDetailsView.Bind();
        }
        else
        {
            AttachDetails.Bind();
        }
    }
    /// <summary>
    /// Upload File
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {
        if (PK_PM_CR_Chemical_Inventory > 0)
        {
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_CR_Chemical_Inventory);
            Attachment.FK_Field_Name = "FK_PM_CR_Chemical_Inventory";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_CR_CI_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Compliance Reporting - Chemical Inventory details first');ShowPanel(2);", true);
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

        
        DataTable dtFields = clsScreen_Validators.SelectByScreen(157).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Chemical Type": strCtrlsIDs += drpFK_LU_Chemical_Type.ClientID + ","; strMessages += "Please select [Chemical Inventory]/Chemical Type" + ","; Span1.Style["display"] = "inline-block"; break;
                case "CAS Number": strCtrlsIDs += txtCAS_Number.ClientID + ","; strMessages += "Please enter [Chemical Inventory]/CAS Number" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Chemical Name": strCtrlsIDs += txtChemical_Name.ClientID + ","; strMessages += "Please enter [Chemical Inventory]/Chemical Name" + ","; Span3.Style["display"] = "inline-block"; break;
                case "If Mixture, List Chemical Components": strCtrlsIDs += txtMixture_Components.ClientID + ","; strMessages += "Please enter [Chemical Inventory]/If Mixture; List Chemical Components" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Maximum Amount On-Site In Pounds": strCtrlsIDs += txtMaximum_Pounds_On_Site.ClientID + ","; strMessages += "Please enter [Chemical Inventory]/Maximum Amount On-Site In Pounds" + ","; Span5.Style["display"] = "inline-block"; break;
                case "Daily Maximum Amount On-Site in Pounds": strCtrlsIDs += txtDaily_maximum_Pounds_On_Site.ClientID + ","; strMessages += "Please enter [Chemical Inventory]/Daily Maximum Amount On-Site in Pounds" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Average Amount On-Site in Pounds": strCtrlsIDs += txtAverage_Pounds_On_Site.ClientID + ","; strMessages += "Please enter [Chemical Inventory]/Average Amount On-Site in Pounds" + ","; Span7.Style["display"] = "inline-block"; break;
                case "Daily Average Amount On-Site in Pounds": strCtrlsIDs += txtDaily_Average_Pounds_On_Site.ClientID + ","; strMessages += "Please enter [Chemical Inventory]/Daily Average Amount On-Site in Pounds" + ","; Span8.Style["display"] = "inline-block"; break;
                case "Storage Type": strCtrlsIDs += drpFK_LU_Storage_Type.ClientID + ","; strMessages += "Please select [Chemical Inventory]/Storage Type" + ","; Span9.Style["display"] = "inline-block"; break;
                case "Storage Location": strCtrlsIDs += drpFK_LU_Storage_Location.ClientID + ","; strMessages += "Please select [Chemical Inventory]/Storage Location" + ","; Span10.Style["display"] = "inline-block"; break;
                case "State/Local Fees": strCtrlsIDs += txtState_Local_Fees.ClientID + ","; strMessages += "Please enter [Chemical Inventory]/State/Local Fees" + ","; Span11.Style["display"] = "inline-block"; break;
                case "Method": strCtrlsIDs += txtMethod.ClientID + ","; strMessages += "Please enter [Chemical Inventory]/Method" + ","; Span12.Style["display"] = "inline-block"; break;
                case "Description": strCtrlsIDs += txtDescription.ClientID + ","; strMessages += "Please enter [Chemical Inventory]/Description" + ","; Span13.Style["display"] = "inline-block"; break;                
            }
            #endregion
        }
       

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
    }
    #endregion
}