using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.IO;
using System.Text;
public partial class SONIC_CRM_CRM_Customer : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_CRM_Customer
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_CRM_Customer"]);
        }
        set { ViewState["PK_CRM_Customer"] = value; }
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
    /// Denotes the primary key of CRM_Email_Log table
    /// </summary>
    public decimal PK_CRM_Email_Log
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_CRM_Email_Log"]);
        }
        set { ViewState["PK_CRM_Email_Log"] = value; }
    }
    /// <summary>
    /// Denotes CRM_Field_Resolution column of  CRM_Customers
    /// </summary>
    public decimal CRM_Field_Resolution
    {
        get { return Convert.ToDecimal(ViewState["CRM_Field_Resolution"]); }
        set { ViewState["CRM_Field_Resolution"] = value; }
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
        ucCRMTab.SetSelectedTab(CRMTab.Tab.Customer);
        CRM_Field_Resolution = CRM_Notes.SelectByDesc_CRM(clsGeneral.CRM_Tables.CRM_Customer, "Field Resolution Information"); //13;
        if (!Page.IsPostBack)
        {
            ((Button)Attachment.FindControl("btnAddAttachment")).OnClientClick = "javascript:return IfSave();";
            PK_CRM_Customer = 0;
            hdnPanel.Value = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();
            if (Request.QueryString["id"] != null)
            {
                decimal decPK;
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out decPK))
                    PK_CRM_Customer = decPK;
            }
            if (PK_CRM_Customer > 0)
            {
                StrOperation = Convert.ToString(Request.QueryString["op"]);
                if (StrOperation == "view")
                {
                    // Bind Controls in view mode
                    BindDetailsForView();
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    else
                    {
                        BindDropdowns();
                        // Bind Controls in edit mode
                        BindDetailsForEdit();
                    }
                }
                ucCRMInfo.BindCRMDetails(PK_CRM_Customer);
                ucCRMInfo.Visible = true;
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                else
                {
                    BindDropdowns();
                    BindAttachmentDetails();
                    // Hide div for view mode
                    dvView.Style["display"] = "none";
                    btnEdit.Visible = false;
                    btnAuditTrail.Visible = false;
                    btnEmail.Visible = false;
                    btnSave.Visible = true;
                    ucCRMInfo.Visible = false;
                    drpFK_LU_CRM_Legal_Email.Enabled = false;
                }
            }

            BindGrids();
            if (StrOperation != "view")
                SetValidations();

            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
        }
        else
        {
            // get Event arguments sent from javascript
            string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];

            if (eventTarget == "CalculateNumDaysClosed")
            {
                CalculateDaysClosed();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + eventArgument + ");", true);
                txtLast_Name.Focus();
            }
            else if (eventTarget == "UpdateEmailLogGrid")
            {
                BindGridEmailLog();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + eventArgument + ");", true);
            }
        }
        clsGeneral.SetDropDownToolTip(new DropDownList[] { drpFK_LU_CRM_Source, drpFK_State, drpFK_LU_CRM_Department, drpFK_LU_CRM_Dept_Desc_Detail, drpFK_LU_CRM_Brand, drpFK_LU_Location,
        drpFK_LU_CRM_Contacted_Resolution_1, drpFK_LU_CRM_Contacted_Resolution_2, drpFK_LU_CRM_DFOD, drpFK_LU_CRM_Legal_Email,drpFK_LU_CRM_Response_Method ,drpFK_LU_CRM_Letter_NA_Reason});
    }
    #endregion

    #region Methods
    /// <summary>
    /// Binds all dropdowns
    /// </summary>
    private void BindDropdowns()
    {
        ComboHelper.FillCRM_Source(new DropDownList[] { drpFK_LU_CRM_Source }, true);
        ComboHelper.FillState(new DropDownList[] { drpFK_State }, 0, true);
        ComboHelper.FillCRM_Department(new DropDownList[] { drpFK_LU_CRM_Department }, true);
        ComboHelper.FillCRM_Department_Desc_Detail(new DropDownList[] { drpFK_LU_CRM_Dept_Desc_Detail }, true);
        ComboHelper.FillCRM_Brand(new DropDownList[] { drpFK_LU_CRM_Brand }, true);
        ComboHelper.FillLocationDBA_All(new DropDownList[] { drpFK_LU_Location }, 0, true);
        drpFK_LU_Location.Style.Remove("font-size");
        ComboHelper.FillCRM_RVP(new DropDownList[] { drpFK_LU_CRM_RVP }, true);
        ComboHelper.FillCRM_Contacted_Resolution(new DropDownList[] { drpFK_LU_CRM_Contacted_Resolution_1, drpFK_LU_CRM_Contacted_Resolution_2 }, true);
        ComboHelper.FillCRM_DFOD(new DropDownList[] { drpFK_LU_CRM_DFOD }, true);
        ComboHelper.FillCRM_Legal_Email(new DropDownList[] { drpFK_LU_CRM_Legal_Email }, true);
        ComboHelper.FillCRM_Response_Method(new DropDownList[] { drpFK_LU_CRM_Response_Method }, true);
        ComboHelper.FillCRM_Letter_NA_Reason(new DropDownList[] { drpFK_LU_CRM_Letter_NA_Reason }, true);
    }

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        btnEmail.Visible = false;
        btnSave.Visible = true;
        btnAuditTrail.Visible = true;
        CRM_Customer objCRM_Customer = new CRM_Customer(PK_CRM_Customer);

        #region " Customer Information "

        txtComplaintNumber.Text = PK_CRM_Customer.ToString();
        txtRecord_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.Record_Date);
        if (objCRM_Customer.FK_LU_CRM_Source != null) drpFK_LU_CRM_Source.SelectedValue = objCRM_Customer.FK_LU_CRM_Source.ToString();
        txtLast_Name.Text = objCRM_Customer.Last_Name;
        txtFirst_Name.Text = objCRM_Customer.First_Name;
        txtAddress.Text = objCRM_Customer.Address;
        txtCity.Text = objCRM_Customer.City;
        if (objCRM_Customer.FK_State != null) drpFK_State.SelectedValue = objCRM_Customer.FK_State.ToString();
        txtZip_Code.Text = objCRM_Customer.Zip_Code;
        txtEmail.Text = objCRM_Customer.Email;
        txtHome_Telephone.Text = objCRM_Customer.Home_Telephone;
        txtCell_Telephone.Text = objCRM_Customer.Cell_Telephone;
        txtWork_Telephone.Text = objCRM_Customer.Work_Telephone;
        txtWork_Telephone_Extension.Text = objCRM_Customer.Work_Telephone_Extension;
        txtSummary.Text = objCRM_Customer.Summary;

        #endregion

        #region " Department Information "

        if (objCRM_Customer.FK_LU_CRM_Department != null) drpFK_LU_CRM_Department.SelectedValue = objCRM_Customer.FK_LU_CRM_Department.ToString();
        if (objCRM_Customer.FK_LU_CRM_Dept_Desc_Detail != null) drpFK_LU_CRM_Dept_Desc_Detail.SelectedValue = objCRM_Customer.FK_LU_CRM_Dept_Desc_Detail.ToString();
        txtService_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.Service_Date);
        rdoService_Date_Est.SelectedValue = objCRM_Customer.Service_Date_Est;
        if (objCRM_Customer.FK_LU_Location != null) drpFK_LU_Location.SelectedValue = objCRM_Customer.FK_LU_Location.ToString();
        if (objCRM_Customer.FK_LU_CRM_Brand != null) drpFK_LU_CRM_Brand.SelectedValue = objCRM_Customer.FK_LU_CRM_Brand.ToString();
        txtModel.Text = objCRM_Customer.Model;
        txtYear.Text = Convert.ToString(objCRM_Customer.Year);

        #endregion

        #region " Contacts and Dates "

        if (objCRM_Customer.FK_LU_CRM_Contacted_Resolution_2 != null) drpFK_LU_CRM_Contacted_Resolution_2.SelectedValue = objCRM_Customer.FK_LU_CRM_Contacted_Resolution_2.ToString();
        if (objCRM_Customer.FK_LU_CRM_Contacted_Resolution_1 != null) drpFK_LU_CRM_Contacted_Resolution_1.SelectedValue = objCRM_Customer.FK_LU_CRM_Contacted_Resolution_1.ToString();
        txtResolution_Manager.Text = objCRM_Customer.Resolution_Manager;
        txtResolution_Manager_Email.Text = objCRM_Customer.Resolution_Manager_Email;
        rdoCustomer_Contacted_GM.SelectedValue = objCRM_Customer.Customer_Contacted_GM;
        txtGM_Contact_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.GM_Contact_Date);
        txtGM_Name.Text = objCRM_Customer.GM_Name;
        txtRVP_Contact_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.RVP_Contact_Date);
        if (objCRM_Customer.FK_LU_CRM_RVP != null) drpFK_LU_CRM_RVP.SelectedValue = objCRM_Customer.FK_LU_CRM_RVP.ToString();
        txtDFOD_Contact_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.DFOD_Contact_Date);
        if (objCRM_Customer.FK_LU_CRM_DFOD != null) drpFK_LU_CRM_DFOD.SelectedValue = objCRM_Customer.FK_LU_CRM_DFOD.ToString();
        txtOther_Cotnact_Name.Text = objCRM_Customer.Other_Cotnact_Name;
        rdoLegal_Attorney_General.SelectedValue = objCRM_Customer.Legal_Attorney_General;
        hdnLegal_Attorney_GeneralOLDVal.Value = rdoLegal_Attorney_General.SelectedValue;
        if (rdoLegal_Attorney_General.SelectedValue == "Y")
        {
            if (objCRM_Customer.FK_LU_CRM_Legal_Email != null) drpFK_LU_CRM_Legal_Email.SelectedValue = objCRM_Customer.FK_LU_CRM_Legal_Email.ToString();
            drpFK_LU_CRM_Legal_Email.Enabled = true;
        }
        else
            drpFK_LU_CRM_Legal_Email.Enabled = false;
        rdoDemand_Letter.SelectedValue = objCRM_Customer.Demand_Letter;
        txtUpdate_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.User_Update_Date);
        txtLast_Action.Text = objCRM_Customer.Last_Action;

        #endregion

        #region " Resolution "
        txtResolution_Summary.Text = objCRM_Customer.Resolution_Summary;
        rdoComplete.SelectedValue = objCRM_Customer.Complete;
        txtClose_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.Close_Date);
        txtDays_To_Close.Text = Convert.ToString(objCRM_Customer.Days_To_Close);
        rdoCustomer_Callback_After_Resolution.SelectedValue = objCRM_Customer.Customer_Callback_After_Resolution;
        rdoResolution_Letter_To_Customer.SelectedValue = objCRM_Customer.Resolution_Letter_To_Customer;
        txtDate_Resolution_Letter_Sent.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.Date_Resolution_Letter_Sent);
        if (objCRM_Customer.FK_LU_CRM_Response_Method != null) drpFK_LU_CRM_Response_Method.SelectedValue = objCRM_Customer.FK_LU_CRM_Response_Method.ToString();
        rdoLetter_NA.SelectedValue = objCRM_Customer.Letter_NA;
        if (objCRM_Customer.FK_LU_CRM_Letter_NA_Reason != null) drpFK_LU_CRM_Letter_NA_Reason.SelectedValue = objCRM_Customer.FK_LU_CRM_Letter_NA_Reason.ToString();
        txtLetter_NA_Note.Text = objCRM_Customer.Letter_NA_Note;
        ////txtFieldResolutionInformation.Text = objCRM_Customer.Field_Resolution_Information;
        ////((LinkButton)txtFieldResolutionInformation.FindControl("btnExport")).Visible = true;
        lblNotesHTML.Text = BindFieldNotesData().ToString();
        #endregion

        #region "Email Log"

        #endregion

        #region "Attachment"
        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.CRM_Customer, (int)PK_CRM_Customer, true, 8);
        AttachDetails.Bind();
        if (((GridView)AttachDetails.FindControl("gvAttachment")).Rows.Count > 0)
        {
            ((Button)AttachDetails.FindControl("btnRemoveAttachment")).Visible = !(App_Access == AccessType.View_Only || App_Access == AccessType.CRM_Add);
        }
        #endregion
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
        btnEmail.Visible = true;
        btnAuditTrail.Visible = true;

        CRM_Customer objCRM_Customer = new CRM_Customer(PK_CRM_Customer);

        #region " Customer Information "

        lblComplaintNumber.Text = PK_CRM_Customer.ToString();
        lblRecord_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.Record_Date);
        if (objCRM_Customer.FK_LU_CRM_Source != null)
            lblFK_LU_CRM_Source.Text = new LU_CRM_Source((decimal)objCRM_Customer.FK_LU_CRM_Source).Fld_Desc;
        lblLast_Name.Text = objCRM_Customer.Last_Name;
        lblFirst_Name.Text = objCRM_Customer.First_Name;
        lblAddress.Text = objCRM_Customer.Address;
        lblCity.Text = objCRM_Customer.City;
        if (objCRM_Customer.FK_State != null)
            lblFK_State.Text = new State((decimal)objCRM_Customer.FK_State).FLD_state;
        lblZip_Code.Text = objCRM_Customer.Zip_Code;
        lblEmail.Text = objCRM_Customer.Email;
        lblHome_Telephone.Text = objCRM_Customer.Home_Telephone;
        lblCell_Telephone.Text = objCRM_Customer.Cell_Telephone;
        lblWork_Telephone.Text = objCRM_Customer.Work_Telephone;
        lblWork_Telephone_Extension.Text = objCRM_Customer.Work_Telephone_Extension;
        lblSummary.Text = objCRM_Customer.Summary;

        #endregion

        #region " Department Information "

        if (objCRM_Customer.FK_LU_CRM_Department != null)
            lblFK_LU_CRM_Department.Text = new LU_CRM_Department((decimal)objCRM_Customer.FK_LU_CRM_Department).Fld_Desc;
        if (objCRM_Customer.FK_LU_CRM_Dept_Desc_Detail != null)
            lblFK_LU_CRM_Dept_Desc_Detail.Text = new LU_CRM_Dept_Desc_Detail((decimal)objCRM_Customer.FK_LU_CRM_Dept_Desc_Detail).Fld_Desc;
        lblService_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.Service_Date);
        lblService_Date_Est.Text = objCRM_Customer.Service_Date_Est == "Y" ? "Yes" : "No";
        if (objCRM_Customer.FK_LU_Location != null)
            lblFK_LU_Location.Text = new LU_Location((decimal)objCRM_Customer.FK_LU_Location).dba;
        if (objCRM_Customer.FK_LU_CRM_Brand != null)
            lblFK_LU_CRM_Brand.Text = new LU_CRM_Brand((decimal)objCRM_Customer.FK_LU_CRM_Brand).Fld_Desc;
        lblModel.Text = objCRM_Customer.Model;
        lblYear.Text = Convert.ToString(objCRM_Customer.Year);

        #endregion

        #region " Contacts and Dates "

        if (objCRM_Customer.FK_LU_CRM_Contacted_Resolution_2 != null)
            lblFK_LU_CRM_Contacted_Resolution_2.Text = new LU_CRM_Contacted_Resolution((decimal)objCRM_Customer.FK_LU_CRM_Contacted_Resolution_2).Fld_Desc;
        if (objCRM_Customer.FK_LU_CRM_Contacted_Resolution_1 != null)
            lblFK_LU_CRM_Contacted_Resolution_1.Text = new LU_CRM_Contacted_Resolution((decimal)objCRM_Customer.FK_LU_CRM_Contacted_Resolution_1).Fld_Desc;
        lblResolution_Manager.Text = objCRM_Customer.Resolution_Manager;
        lblResolution_Manager_Email.Text = objCRM_Customer.Resolution_Manager_Email;
        lblCustomer_Contacted_GM.Text = objCRM_Customer.Customer_Contacted_GM == "Y" ? "Yes" : "No";
        lblGM_Contact_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.GM_Contact_Date);
        lblGM_Name.Text = objCRM_Customer.GM_Name;
        lblRVP_Contact_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.RVP_Contact_Date);
        if (objCRM_Customer.FK_LU_CRM_RVP != null)
            lblFK_LU_CRM_RVP.Text = new LU_CRM_RVP((decimal)objCRM_Customer.FK_LU_CRM_RVP).Fld_Desc;
        lblDFOD_Contact_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.DFOD_Contact_Date);
        if (objCRM_Customer.FK_LU_CRM_DFOD != null)
            lblFK_LU_CRM_DFOD.Text = new LU_CRM_DFOD((decimal)objCRM_Customer.FK_LU_CRM_DFOD).Fld_Desc;
        lblOther_Cotnact_Name.Text = objCRM_Customer.Other_Cotnact_Name;
        lblLegal_Attorney_General.Text = objCRM_Customer.Legal_Attorney_General == "Y" ? "Yes" : "No";
        if (objCRM_Customer.FK_LU_CRM_Legal_Email != null)
            lblFK_LU_CRM_Legal_Email.Text = new LU_CRM_Legal_Email((decimal)objCRM_Customer.FK_LU_CRM_Legal_Email).Subject;
        lblDemand_Letter.Text = objCRM_Customer.Demand_Letter == "Y" ? "Yes" : "No";
        lblUpdate_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.User_Update_Date);
        lblLast_Action.Text = objCRM_Customer.Last_Action;

        #endregion

        #region " Resolution "

        lblResolution_Summary.Text = objCRM_Customer.Resolution_Summary;
        lblComplete.Text = objCRM_Customer.Complete == "Y" ? "Yes" : "No";
        lblClose_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.Close_Date);
        lblDays_To_Close.Text = Convert.ToString(objCRM_Customer.Days_To_Close);
        lblCustomer_Callback_After_Resolution.Text = objCRM_Customer.Customer_Callback_After_Resolution == "Y" ? "Yes" : "No";
        lblResolution_Letter_To_Customer.Text = objCRM_Customer.Resolution_Letter_To_Customer == "Y" ? "Yes" : "No";
        lblDate_Resolution_Letter_Sent.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Customer.Date_Resolution_Letter_Sent);
        if (objCRM_Customer.FK_LU_CRM_Response_Method != null)
            lblFK_LU_CRM_Response_Method.Text = new LU_CRM_Response_Method((decimal)objCRM_Customer.FK_LU_CRM_Response_Method).Fld_Desc;
        lblLetter_NA.Text = objCRM_Customer.Letter_NA == "Y" ? "Yes" : "No";
        if (objCRM_Customer.FK_LU_CRM_Letter_NA_Reason != null)
            lblFK_LU_CRM_Letter_NA_Reason.Text = new LU_CRM_Letter_NA_Reason((decimal)objCRM_Customer.FK_LU_CRM_Letter_NA_Reason).Fld_Desc;
        lblLetter_NA_Note.Text = objCRM_Customer.Letter_NA_Note;
        /////lblFieldResolutionInformation.Text = objCRM_Customer.Field_Resolution_Information;
        lblNotesHTML.Text = BindFieldNotesData().ToString();
        #endregion

        #region "Attachment"
        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.CRM_Customer, (int)PK_CRM_Customer, false, 8);
        AttachDetails.Bind();
        #endregion

        btnEdit.Visible = (App_Access != AccessType.View_Only);
    }

    /// <summary>
    /// Save Data
    /// </summary>
    private void SaveData()
    {
        CRM_Customer objCRM_Customer = new CRM_Customer();

        objCRM_Customer.PK_CRM_Customer = PK_CRM_Customer;

        #region " Customer Information "

        objCRM_Customer.Record_Date = clsGeneral.FormatNullDateToStore(txtRecord_Date.Text);
        if (drpFK_LU_CRM_Source.SelectedIndex > 0) objCRM_Customer.FK_LU_CRM_Source = Convert.ToDecimal(drpFK_LU_CRM_Source.SelectedValue);
        objCRM_Customer.Last_Name = txtLast_Name.Text.Trim();
        objCRM_Customer.First_Name = txtFirst_Name.Text.Trim();
        objCRM_Customer.Address = txtAddress.Text.Trim();
        objCRM_Customer.City = txtCity.Text.Trim();
        if (drpFK_State.SelectedIndex > 0) objCRM_Customer.FK_State = Convert.ToDecimal(drpFK_State.SelectedValue);
        objCRM_Customer.Zip_Code = txtZip_Code.Text.Trim();
        objCRM_Customer.Email = txtEmail.Text.Trim();
        objCRM_Customer.Home_Telephone = txtHome_Telephone.Text.Trim();
        objCRM_Customer.Cell_Telephone = txtCell_Telephone.Text.Trim();
        objCRM_Customer.Work_Telephone = txtWork_Telephone.Text.Trim();
        objCRM_Customer.Work_Telephone_Extension = txtWork_Telephone_Extension.Text.Trim();
        objCRM_Customer.Summary = txtSummary.Text.Trim();

        #endregion

        #region " Department Information "

        if (drpFK_LU_CRM_Department.SelectedIndex > 0) objCRM_Customer.FK_LU_CRM_Department = Convert.ToDecimal(drpFK_LU_CRM_Department.SelectedValue);
        if (drpFK_LU_CRM_Dept_Desc_Detail.SelectedIndex > 0) objCRM_Customer.FK_LU_CRM_Dept_Desc_Detail = Convert.ToDecimal(drpFK_LU_CRM_Dept_Desc_Detail.SelectedValue);
        objCRM_Customer.Service_Date = clsGeneral.FormatNullDateToStore(txtService_Date.Text);
        objCRM_Customer.Service_Date_Est = rdoService_Date_Est.SelectedValue;
        if (drpFK_LU_Location.SelectedIndex > 0) objCRM_Customer.FK_LU_Location = Convert.ToDecimal(drpFK_LU_Location.SelectedValue);
        if (drpFK_LU_CRM_Brand.SelectedIndex > 0) objCRM_Customer.FK_LU_CRM_Brand = Convert.ToDecimal(drpFK_LU_CRM_Brand.SelectedValue);
        objCRM_Customer.Model = txtModel.Text.Trim();
        if (txtYear.Text != "") objCRM_Customer.Year = clsGeneral.GetDecimalValue(txtYear);

        #endregion

        #region " Contacts and Dates "

        if (drpFK_LU_CRM_Contacted_Resolution_2.SelectedIndex > 0) objCRM_Customer.FK_LU_CRM_Contacted_Resolution_2 = Convert.ToDecimal(drpFK_LU_CRM_Contacted_Resolution_2.SelectedValue);
        if (drpFK_LU_CRM_Contacted_Resolution_1.SelectedIndex > 0) objCRM_Customer.FK_LU_CRM_Contacted_Resolution_1 = Convert.ToDecimal(drpFK_LU_CRM_Contacted_Resolution_1.SelectedValue);
        objCRM_Customer.Resolution_Manager = txtResolution_Manager.Text.Trim();
        objCRM_Customer.Resolution_Manager_Email = txtResolution_Manager_Email.Text.Trim();
        objCRM_Customer.Customer_Contacted_GM = rdoCustomer_Contacted_GM.SelectedValue;
        objCRM_Customer.GM_Contact_Date = clsGeneral.FormatNullDateToStore(txtGM_Contact_Date.Text);
        objCRM_Customer.GM_Name = txtGM_Name.Text.Trim();
        objCRM_Customer.RVP_Contact_Date = clsGeneral.FormatNullDateToStore(txtRVP_Contact_Date.Text);
        if (drpFK_LU_CRM_RVP.SelectedIndex > 0) objCRM_Customer.FK_LU_CRM_RVP = Convert.ToDecimal(drpFK_LU_CRM_RVP.SelectedValue);
        objCRM_Customer.DFOD_Contact_Date = clsGeneral.FormatNullDateToStore(txtDFOD_Contact_Date.Text);
        if (drpFK_LU_CRM_DFOD.SelectedIndex > 0) objCRM_Customer.FK_LU_CRM_DFOD = Convert.ToDecimal(drpFK_LU_CRM_DFOD.SelectedValue);
        objCRM_Customer.Other_Cotnact_Name = txtOther_Cotnact_Name.Text.Trim();
        objCRM_Customer.Legal_Attorney_General = rdoLegal_Attorney_General.SelectedValue;
        if (drpFK_LU_CRM_Legal_Email.SelectedIndex > 0) objCRM_Customer.FK_LU_CRM_Legal_Email = Convert.ToDecimal(drpFK_LU_CRM_Legal_Email.SelectedValue);
        objCRM_Customer.Demand_Letter = rdoDemand_Letter.SelectedValue;
        objCRM_Customer.User_Update_Date = clsGeneral.FormatNullDateToStore(txtUpdate_Date.Text);
        objCRM_Customer.Last_Action = txtLast_Action.Text.Trim();

        #endregion

        #region " Resolution "

        objCRM_Customer.Resolution_Summary = txtResolution_Summary.Text.Trim();
        objCRM_Customer.Complete = rdoComplete.SelectedValue;
        objCRM_Customer.Close_Date = clsGeneral.FormatNullDateToStore(txtClose_Date.Text);
        if (txtDays_To_Close.Text != "") objCRM_Customer.Days_To_Close = clsGeneral.GetDecimalValue(txtDays_To_Close);
        objCRM_Customer.Customer_Callback_After_Resolution = rdoCustomer_Callback_After_Resolution.SelectedValue;
        objCRM_Customer.Resolution_Letter_To_Customer = rdoResolution_Letter_To_Customer.SelectedValue;
        objCRM_Customer.Date_Resolution_Letter_Sent = clsGeneral.FormatNullDateToStore(txtDate_Resolution_Letter_Sent.Text);
        if (drpFK_LU_CRM_Response_Method.SelectedIndex > 0) objCRM_Customer.FK_LU_CRM_Response_Method = Convert.ToDecimal(drpFK_LU_CRM_Response_Method.SelectedValue);
        objCRM_Customer.Letter_NA = rdoLetter_NA.SelectedValue;
        if (drpFK_LU_CRM_Letter_NA_Reason.SelectedIndex > 0) objCRM_Customer.FK_LU_CRM_Letter_NA_Reason = Convert.ToDecimal(drpFK_LU_CRM_Letter_NA_Reason.SelectedValue);
        objCRM_Customer.Letter_NA_Note = txtLetter_NA_Note.Text.Trim();


        #endregion

        objCRM_Customer.Field_Resolution_Information = "";
        objCRM_Customer.Update_Date = DateTime.Now;
        objCRM_Customer.Updated_By = clsSession.UserID;

        if (PK_CRM_Customer > 0)
            objCRM_Customer.Update();
        else
            PK_CRM_Customer = objCRM_Customer.Insert();
        ucCRMInfo.BindCRMDetails(PK_CRM_Customer);
    }

    /// <summary>
    /// Bind All Grids
    /// </summary>
    private void BindGrids()
    {
        BindGridComplaints();
        BindFieldNotesGrid();
        BindGridEmailLog();
        BindResolutionGrid();
    }

    /// <summary>
    /// Bind Complaint Grid
    /// </summary>
    private void BindGridComplaints()
    {
        DataTable dtComplaints = CRM_Notes.SelectByFK_CRM(PK_CRM_Customer, clsGeneral.CRM_Tables.CRM_Customer, 1).Tables[0];
        if (StrOperation != "view")
        {
            gvComplaint.DataSource = dtComplaints;
            gvComplaint.DataBind();
            gvComplaint.Columns[gvComplaint.Columns.Count - 1].Visible = !(App_Access == AccessType.View_Only || App_Access == AccessType.CRM_Add);
            if (dtComplaints.Rows.Count > 0)
            {
                divgvComplaint.Style["overflow-y"] = "scroll";
                divgvComplaint.Style["height"] = "200px";
            }
            else
            {
                divgvComplaint.Style["overflow-y"] = "hidden";
                divgvComplaint.Style["height"] = "40px";
            }
        }
        else
        {
            gvComplaintView.DataSource = dtComplaints;
            gvComplaintView.DataBind();
            if (dtComplaints.Rows.Count > 0)
            {
                divgvComplaintView.Style["overflow-y"] = "scroll";
                divgvComplaintView.Style["height"] = "200px";
            }
            else
            {
                divgvComplaintView.Style["overflow-y"] = "hidden";
                divgvComplaintView.Style["height"] = "40px";
            }
        }
    }

    /// <summary>
    /// Bind FieldNotes Grid
    /// </summary>
    private void BindFieldNotesGrid()
    {
        DataTable dtNotes = CRM_Notes.SelectByFK_CRM(PK_CRM_Customer, clsGeneral.CRM_Tables.CRM_Customer, 2).Tables[0];
        if (StrOperation != "view")
        {
            gvFieldNotes.DataSource = dtNotes;
            gvFieldNotes.DataBind();
            gvFieldNotes.Columns[gvFieldNotes.Columns.Count - 1].Visible = !(App_Access == AccessType.View_Only || App_Access == AccessType.CRM_Add);
            if (dtNotes.Rows.Count > 0)
            {
                divgvFieldNotes.Style["overflow-y"] = "scroll";
                divgvFieldNotes.Style["height"] = "200px";
            }
            else
            {
                divgvFieldNotes.Style["overflow-y"] = "hidden";
                divgvFieldNotes.Style["height"] = "40px";
            }
        }
        else
        {
            gvFieldNotesView.DataSource = dtNotes;
            gvFieldNotesView.DataBind();
            if (dtNotes.Rows.Count > 0)
            {
                divgvFieldNotesView.Style["overflow-y"] = "scroll";
                divgvFieldNotesView.Style["height"] = "200px";
            }
            else
            {
                divgvFieldNotesView.Style["overflow-y"] = "hidden";
                divgvFieldNotesView.Style["height"] = "40px";
            }
        }
    }

    /// <summary>
    /// Bind EmailLog Grid
    /// </summary>
    public void BindGridEmailLog()
    {
        DataTable dtComplaints = CRM_Email_Log.SelectByFK_CRM(PK_CRM_Customer, Convert.ToString(clsGeneral.CRM_Tables.CRM_Customer)).Tables[0];
        if (StrOperation != "view")
        {
            gvEmailLog.DataSource = dtComplaints;
            gvEmailLog.DataBind();

            if (dtComplaints.Rows.Count > 0)
            {
                dvEmailLogGrid.Style["overflow-y"] = "scroll";
                dvEmailLogGrid.Style["height"] = "200px";
            }
            else
            {
                dvEmailLogGrid.Style["overflow-y"] = "hidden";
                dvEmailLogGrid.Style["height"] = "40px";
            }
        }
        else
        {
            gvEmailLogView.DataSource = dtComplaints;
            gvEmailLogView.DataBind();
            if (dtComplaints.Rows.Count > 0)
            {
                dvEmailLogGridView.Style["overflow-y"] = "scroll";
                dvEmailLogGridView.Style["height"] = "200px";
            }
            else
            {
                dvEmailLogGridView.Style["overflow-y"] = "hidden";
                dvEmailLogGridView.Style["height"] = "40px";
            }
        }
    }

    /// <summary>
    /// Bind Resolution Grid
    /// </summary>
    private void BindResolutionGrid()
    {
        if (PK_CRM_Customer > 0)
        {
            //Resolution Grid Bind
            DataSet dsResolutin = CRM_Notes.SelectByFK_CRM(PK_CRM_Customer, clsGeneral.CRM_Tables.CRM_Customer, CRM_Field_Resolution);
            gvResolution.DataSource = dsResolutin.Tables[0];
            gvResolution.DataBind();
            gvResolution.Columns[gvResolution.Columns.Count - 1].Visible = !(App_Access == AccessType.View_Only || App_Access == AccessType.CRM_Add);
            if (dsResolutin.Tables[0].Rows.Count > 0)
            {
                divgvResolution.Style["overflow-y"] = "scroll";
                divgvResolution.Style["height"] = "200px";
            }
            else
            {
                divgvResolution.Style["overflow-y"] = "hidden";
                divgvResolution.Style["height"] = "40px";
            }

            //Resolution Grid bind
            DataSet dsResolution = CRM_Notes.SelectByFK_CRM(PK_CRM_Customer, clsGeneral.CRM_Tables.CRM_Customer, CRM_Field_Resolution);
            gvResolutionView.DataSource = dsResolution.Tables[0];
            gvResolutionView.DataBind();
            if (dsResolution.Tables[0].Rows.Count > 0)
            {
                divgvResolutionView.Style["overflow-y"] = "scroll";
                divgvResolutionView.Style["height"] = "200px";
            }
            else
            {
                divgvResolutionView.Style["overflow-y"] = "hidden";
                divgvResolutionView.Style["height"] = "40px";
            }
        }
        else
        {
            gvResolution.DataSource = null;
            gvResolution.DataBind();
        }
    }

    /// <summary>
    /// Calculate days closed
    /// </summary>
    private void CalculateDaysClosed()
    {
        txtDays_To_Close.Text = "";

        DateTime? dtStart = null;
        DateTime? dtEnd = null;

        DateTime dtTemp1, dtTemp2;
        if (DateTime.TryParse(txtRecord_Date.Text, out dtTemp1))
            dtStart = dtTemp1;
        if (DateTime.TryParse(txtClose_Date.Text, out dtTemp2))
            dtEnd = dtTemp2;

        int cntDays = 0;
        if (dtStart.HasValue && dtEnd.HasValue)
        {
            if (dtStart < dtEnd)
            {
                int i = 0;
                DateTime dtTemp = Convert.ToDateTime(dtStart);
                while (dtTemp < dtEnd)
                {
                    dtTemp = Convert.ToDateTime(dtStart).AddDays(i);
                    if (Convert.ToDateTime(dtTemp).DayOfWeek != DayOfWeek.Sunday)
                        cntDays++;
                    i++;
                }
                txtDays_To_Close.Text = (cntDays).ToString();
            }
            else if (dtStart == dtEnd)
            {
                txtDays_To_Close.Text = "1";
                //DateTime dtTemp = Convert.ToDateTime(dtStart);
                //if (Convert.ToDateTime(dtTemp).DayOfWeek != DayOfWeek.Sunday)
                //    cntDays++;
                //if (cntDays == 0)
                // txtDays_To_Close.Text = "0";
                //else
                //    txtDays_To_Close.Text = (cntDays - 1).ToString();
            }
        }
    }

    /// <summary>
    /// Send Legal Email
    /// </summary>
    private void SendLegalEmail()
    {
        if (drpFK_LU_CRM_Legal_Email.SelectedIndex > 0)
        {
            LU_CRM_Legal_Email objLegalEmail = new LU_CRM_Legal_Email(Convert.ToDecimal(drpFK_LU_CRM_Legal_Email.SelectedValue));
            string strBody;
            strBody = "Reference Complaint Number: " + PK_CRM_Customer.ToString() + Environment.NewLine + Environment.NewLine + objLegalEmail.Body;
            clsGeneral.SendMailMessage(AppConfig.MailFrom, objLegalEmail.Recipients, objLegalEmail.CC_Recpients, "", objLegalEmail.Subject, strBody, false);

            CRM_Email_Log objLog = new CRM_Email_Log();
            objLog.Table_Name = clsGeneral.CRM_Tables.CRM_Customer.ToString();
            objLog.FK_Table_Name = PK_CRM_Customer;
            objLog.Date = DateTime.Now;
            objLog.Recipients = objLegalEmail.Recipients;
            objLog.CCs = objLegalEmail.CC_Recpients;
            objLog.Subject = objLegalEmail.Subject;
            objLog.Updated_By = clsSession.UserID;
            objLog.Insert();
        }
    }

    /// <summary>
    /// Bind Field Notes Data
    /// </summary>
    /// <returns></returns>
    private StringBuilder BindFieldNotesData()
    {
        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
        sbRecorords.Append("<style type='text/css'></style><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%'><tr><td class='cols_' >");

        sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");//Sub Table
        sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>"); //Title
        sbRecorords.Append("<td >&nbsp;</td>");
        sbRecorords.Append("<td align='center' style='font-size:9pt;' ><b> Field Resolution Information </b></td>");
        sbRecorords.Append("<td style='font-size:9pt' align='right' >Date Run: " + DateTime.Now.ToString("MM/dd/yyyy") + "</td></tr>");

        sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
        sbRecorords.Append("<td class='cols_' width='20%'>Compliant Number</td>");
        sbRecorords.Append("<td class='cols_' width='20%'>Date of Incident</td>");
        sbRecorords.Append("<td class='cols_' width='60%'>Field Resolution Information</td>");
        sbRecorords.Append("</tr>");

        sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
        if (StrOperation == "view")
        {
            sbRecorords.Append("<td  class='cols_'>" + Convert.ToString(lblComplaintNumber.Text) + "</td>");
            sbRecorords.Append("<td  class='cols_'>" + clsGeneral.FormatDBNullDateToDisplay(lblRecord_Date.Text) + "</td>");
            sbRecorords.Append("<td  class='cols_'>" + Convert.ToString(""/** lblFieldResolutionInformation.Text **/) + "</td>");
        }
        else
        {
            sbRecorords.Append("<td  class='cols_'>" + Convert.ToString(txtComplaintNumber.Text) + "</td>");
            sbRecorords.Append("<td  class='cols_'>" + clsGeneral.FormatDBNullDateToDisplay(txtRecord_Date.Text) + "</td>");
            sbRecorords.Append("<td  class='cols_'>" + Convert.ToString("" /** txtFieldResolutionInformation.Text **/) + "</td>");
        }
        sbRecorords.Append("</tr>");
        sbRecorords.Append("</table>");

        sbRecorords.Append("</td>");
        sbRecorords.Append("</tr>");
        sbRecorords.Append("</table>");
        return sbRecorords;
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
        if ((hdnLegal_Attorney_GeneralOLDVal.Value == "N" || hdnLegal_Attorney_GeneralOLDVal.Value == "") && rdoLegal_Attorney_General.SelectedValue == "Y")
        {
            SendLegalEmail();
        }
        Response.Redirect("CRM_Customer.aspx?id=" + Encryption.Encrypt(PK_CRM_Customer.ToString()) + "&op=view");
    }

    /// <summary>
    /// Handles Edit button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("CRM_Customer.aspx?id=" + Encryption.Encrypt(PK_CRM_Customer.ToString()) + "&op=edit");
    }

    /// <summary>
    /// Handles Add Complaint click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddComplaint_Click(object sender, EventArgs e)
    {
        try
        {
            SaveData();
            string str_PK_CRM_Customer = Encryption.Encrypt(PK_CRM_Customer.ToString());
            Response.Redirect("CRM_Customer_Complaint_Notes.aspx?pid=" + str_PK_CRM_Customer + "&bmode=edit");
        }
        catch (Exception ex)
        {
            if ((ex) is System.Threading.ThreadAbortException)
                return;
        }

    }

    /// <summary>
    /// Bind Add Field Note click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddFieldNote_Click(object sender, EventArgs e)
    {
        try
        {
            SaveData();
            string str_PK_CRM_Customer = Encryption.Encrypt(PK_CRM_Customer.ToString());
            Response.Redirect("CRM_Customer_Notes.aspx?pid=" + str_PK_CRM_Customer + "&bmode=edit");
        }
        catch (Exception ex)
        {
            if ((ex) is System.Threading.ThreadAbortException)
                return;
        }
    }

    /// <summary>
    /// Handles Resolution link click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkResolution_Click(object sender, EventArgs e)
    {
        SaveData();
        string str_PK_CRM_Non_Customer = Encryption.Encrypt(PK_CRM_Customer.ToString());
        Response.Redirect("CRM_Customer_Resolution_Notes.aspx?pid=" + str_PK_CRM_Non_Customer + "&bmode=edit");
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
        if (StrOperation != "view")
        {
            if (((GridView)AttachDetails.FindControl("gvAttachment")).Rows.Count > 0)
            {
                ((Button)AttachDetails.FindControl("btnRemoveAttachment")).Visible = !(App_Access == AccessType.View_Only || App_Access == AccessType.CRM_Add);
            }
        }
    }

    protected void Attachment_btnHandler(object sender)
    {
        if (PK_CRM_Customer > 0)
        {
            // add attachment if any.
            Attachment.Add(clsGeneral.Tables.CRM_Customer, (int)PK_CRM_Customer);
            // Bind the attachment detail to view the added attachment
            BindAttachmentDetails();
            // show attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(8);", true);
        }
        else
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please Save Customer Information First');ShowPanel(1);", true);
    }

    protected void ExportToExcel_btnHandler(object sender)
    {
        // Export the data into excel spreadsheet       
        string strcols = "border: black 1px solid;vertical-align: top;font-size: 8pt;border-collapse: collapse;";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        //PrepareControlForExport(gvReportGrid.HeaderRow);
        lblNotesHTML.RenderControl(htmlWrite);
        // gvReportGrid.RenderControl(htmlWrite);

        MemoryStream memorystream = new MemoryStream();
        byte[] _bytes = Encoding.UTF8.GetBytes(stringWrite.ToString().Replace("border-top:#EAEAEA", "border-top:#000000").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>"));
        memorystream.Write(_bytes, 0, _bytes.Length);
        memorystream.Seek(0, SeekOrigin.Begin);

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "CRM_Customer_Complaint_Notes.xls"));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Write(stringWrite.ToString().Replace("#EAEAEA", "White").Replace("#eaeaea", "White").Replace("background-color:#C0C0C0", "background-color:White;").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>").Replace("background-color:#7f7f7f;color:White", "background-color:White;color:Black"));
        HttpContext.Current.Response.End();
    }
    #endregion

    #region " Gridview Events "
    /// <summary>
    /// Handles RowCommand Event of Complaint Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvComplaint_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveNote")
        {
            CRM_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindGridComplaints();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
        }
    }

    /// <summary>
    /// Handles RowCommand Event of FieldNotes Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFieldNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveNote")
        {
            CRM_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindFieldNotesGrid();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
        }
    }

    /// <summary>
    /// Handles RowCommand Event of EmailLog Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEmailLog_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            PK_CRM_Email_Log = (Convert.ToDecimal(e.CommandArgument));
            CRM_Email_Log objEmailLog = new CRM_Email_Log(PK_CRM_Email_Log);
            txtEmailDateSent.Text = clsGeneral.FormatDBNullDateToDisplay(objEmailLog.Date);
            txtRecipient.Text = Convert.ToString(objEmailLog.Recipients);
            txtCCs.Text = Convert.ToString(objEmailLog.CCs);
            txtSubject.Text = Convert.ToString(objEmailLog.Subject);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(7);", true);
        }
    }

    /// <summary>
    /// Handles RowEditing Event of EmailLog Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEmailLog_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }

    /// <summary>
    /// Handles RowCommand Event of EmailLogView Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEmailLogView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            PK_CRM_Email_Log = (Convert.ToDecimal(e.CommandArgument));
            CRM_Email_Log objEmailLog = new CRM_Email_Log(PK_CRM_Email_Log);
            lblEmailDateSent.Text = clsGeneral.FormatDBNullDateToDisplay(objEmailLog.Date);
            lblRecipient.Text = Convert.ToString(objEmailLog.Recipients);
            lblCCs.Text = Convert.ToString(objEmailLog.CCs);
            lblSubject.Text = Convert.ToString(objEmailLog.Subject);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(7);", true);
        }
    }

    /// <summary>
    /// Handles RowEditing Event of EmailLogView Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEmailLogView_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }

    /// <summary>
    /// Handles RowCommand Event of Resolution Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvResolution_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            decimal PK_ID = Convert.ToDecimal(e.CommandArgument);
            // Delete CRM_Notes record
            CRM_Notes.DeleteByPK(PK_ID);
            // Rebind Grid after Delete record           
            BindResolutionGrid();
            // Show Panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
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
        DataTable dtFields = clsScreen_Validators.SelectByScreen(120).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        // set menu 1 asterisk display
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Source":
                    strCtrlsIDs += drpFK_LU_CRM_Source.ClientID + ",";
                    strMessages += "Please select [Customer Information]/Source" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Date of Incident":
                    strCtrlsIDs += txtRecord_Date.ClientID + ",";
                    strMessages += "Please enter [Customer Information]/Date of Incident" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Last Name":
                    strCtrlsIDs += txtLast_Name.ClientID + ",";
                    strMessages += "Please enter [Customer Information]/Last Name" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "First Name":
                    strCtrlsIDs += txtFirst_Name.ClientID + ",";
                    strMessages += "Please enter [Customer Information]/First Name" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Address":
                    strCtrlsIDs += txtAddress.ClientID + ",";
                    strMessages += "Please enter [Customer Information]/Address" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "City":
                    strCtrlsIDs += txtCity.ClientID + ",";
                    strMessages += "Please enter [Customer Information]/City" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "State":
                    strCtrlsIDs += drpFK_State.ClientID + ",";
                    strMessages += "Please select [Customer Information]/State" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Zip":
                    strCtrlsIDs += txtZip_Code.ClientID + ",";
                    strMessages += "Please enter [Customer Information]/Zip" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Email":
                    strCtrlsIDs += txtEmail.ClientID + ",";
                    strMessages += "Please enter [Customer Information]/Email" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Home Telephone":
                    strCtrlsIDs += txtHome_Telephone.ClientID + ",";
                    strMessages += "Please enter [Customer Information]/Home Telephone" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Cell Telephone":
                    strCtrlsIDs += txtCell_Telephone.ClientID + ",";
                    strMessages += "Please enter [Customer Information]/Cell Telephone" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Work Telephone":
                    strCtrlsIDs += txtWork_Telephone.ClientID + ",";
                    strMessages += "Please enter [Customer Information]/Work Telephone" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Work Telephone Extension":
                    strCtrlsIDs += txtWork_Telephone_Extension.ClientID + ",";
                    strMessages += "Please enter [Customer Information]/Work Telephone Extension" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "Summary":
                    strCtrlsIDs += txtSummary.ClientID + ",";
                    strMessages += "Please enter [Customer Information]/Summary" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "Resolution Summary":
                    strCtrlsIDs += txtResolution_Summary.ClientID + ",";
                    strMessages += "Please enter [Customer Information]/Resolution Summary" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Department Information"
        dtFields = clsScreen_Validators.SelectByScreen(121).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        // set menu 2 asterisk display
        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Department":
                    strCtrlsIDs += drpFK_LU_CRM_Department.ClientID + ",";
                    strMessages += "Please select [Department Information]/Department" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                case "Department Detail":
                    strCtrlsIDs += drpFK_LU_CRM_Dept_Desc_Detail.ClientID + ",";
                    strMessages += "Please select [Department Information]/Department Detail" + ",";
                    Span17.Style["display"] = "inline-block";
                    break;
                case "Date of Service":
                    strCtrlsIDs += txtService_Date.ClientID + ",";
                    strMessages += "Please enter [Department Information]/Date of Service" + ",";
                    Span18.Style["display"] = "inline-block";
                    break;
                case "Dealer":
                    strCtrlsIDs += drpFK_LU_Location.ClientID + ",";
                    strMessages += "Please select [Department Information]/Dealer" + ",";
                    Span19.Style["display"] = "inline-block";
                    break;
                case "Brand":
                    strCtrlsIDs += drpFK_LU_CRM_Brand.ClientID + ",";
                    strMessages += "Please select [Department Information]/Brand" + ",";
                    Span20.Style["display"] = "inline-block";
                    break;
                case "Model":
                    strCtrlsIDs += txtModel.ClientID + ",";
                    strMessages += "Please enter [Department Information]/Model" + ",";
                    Span21.Style["display"] = "inline-block";
                    break;
                case "Year":
                    strCtrlsIDs += txtYear.ClientID + ",";
                    strMessages += "Please enter [Department Information]/Year" + ",";
                    Span22.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Contacts and Dates"
        dtFields = clsScreen_Validators.SelectByScreen(122).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        // set menu 3 asterisk display
        MenuAsterisk3.Style["display"] = (dtFields.Select("LeftMenuIndex = 3").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "CRM Contacted":
                    strCtrlsIDs += drpFK_LU_CRM_Contacted_Resolution_2.ClientID + ",";
                    strMessages += "Please select [Contacts and Dates]/CRM Contacted" + ",";
                    Span23.Style["display"] = "inline-block";
                    break;
                case "Resolution Manager":
                    strCtrlsIDs += drpFK_LU_CRM_Contacted_Resolution_1.ClientID + ",";
                    strMessages += "Please enter [Contacts and Dates]/Resolution Manager" + ",";
                    Span24.Style["display"] = "inline-block";
                    break;
                case "Resolution Manager Name":
                    strCtrlsIDs += txtResolution_Manager.ClientID + ",";
                    strMessages += "Please enter [Contacts and Dates]/Resolution Manager Name" + ",";
                    Span25.Style["display"] = "inline-block";
                    break;
                case "Resolution Manager Email":
                    strCtrlsIDs += txtResolution_Manager_Email.ClientID + ",";
                    strMessages += "Please enter [Contacts and Dates]/Resolution Manager Email" + ",";
                    Span26.Style["display"] = "inline-block";
                    break;
                case "Date of Contact GM":
                    strCtrlsIDs += txtGM_Contact_Date.ClientID + ",";
                    strMessages += "Please enter [Contacts and Dates]/Date of Contact GM" + ",";
                    Span27.Style["display"] = "inline-block";
                    break;
                case "GM Name":
                    strCtrlsIDs += txtGM_Name.ClientID + ",";
                    strMessages += "Please enter [Contacts and Dates]/GM Name" + ",";
                    Span28.Style["display"] = "inline-block";
                    break;
                case "Date of Contact RVP":
                    strCtrlsIDs += txtRVP_Contact_Date.ClientID + ",";
                    strMessages += "Please enter [Contacts and Dates]/Date of Contact RVP" + ",";
                    Span29.Style["display"] = "inline-block";
                    break;
                case "RVP Name":
                    strCtrlsIDs += drpFK_LU_CRM_RVP.ClientID + ",";
                    strMessages += "Please select [Contacts and Dates]/RVP Name" + ",";
                    Span30.Style["display"] = "inline-block";
                    break;
                case "Date of Contact DFOD":
                    strCtrlsIDs += txtDFOD_Contact_Date.ClientID + ",";
                    strMessages += "Please enter [Contacts and Dates]/Date of Contact DFOD" + ",";
                    Span31.Style["display"] = "inline-block";
                    break;
                case "DFOD":
                    strCtrlsIDs += drpFK_LU_CRM_DFOD.ClientID + ",";
                    strMessages += "Please select [Contacts and Dates]/DFOD" + ",";
                    Span32.Style["display"] = "inline-block";
                    break;
                case "Other Contact Name":
                    strCtrlsIDs += txtOther_Cotnact_Name.ClientID + ",";
                    strMessages += "Please enter [Contacts and Dates]/Other Contact Name" + ",";
                    Span33.Style["display"] = "inline-block";
                    break;
                case "Legal Email":
                    strCtrlsIDs += drpFK_LU_CRM_Legal_Email.ClientID + ",";
                    strMessages += "Please select [Contacts and Dates]/Legal Email " + ",";
                    if (rdoLegal_Attorney_General.SelectedIndex == 1)
                        Span34.Style["display"] = "none";
                    else
                        Span34.Style["display"] = "inline-block";
                    break;
                case "Date of Last Update":
                    strCtrlsIDs += txtUpdate_Date.ClientID + ",";
                    strMessages += "Please enter [Contacts and Dates]/Date of Last Update" + ",";
                    Span35.Style["display"] = "inline-block";
                    break;
                case "Last Action":
                    strCtrlsIDs += txtLast_Action.ClientID + ",";
                    strMessages += "Please enter [Contacts and Dates]/Last Action" + ",";
                    Span36.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Resolution"
        dtFields = clsScreen_Validators.SelectByScreen(125).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        // set menu 6 asterisk display
        MenuAsterisk6.Style["display"] = (dtFields.Select("LeftMenuIndex = 6").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Close Date":
                    strCtrlsIDs += txtClose_Date.ClientID + ",";
                    strMessages += "Please enter [Resolution]/Close Date" + ",";
                    Span37.Style["display"] = "inline-block";
                    break;
                case "Date Resolution Letter Sent":
                    strCtrlsIDs += txtDate_Resolution_Letter_Sent.ClientID + ",";
                    strMessages += "Please enter [Resolution]/Date Resolution Letter Sent" + ",";
                    Span38.Style["display"] = "inline-block";
                    break;
                case "Sent By":
                    strCtrlsIDs += drpFK_LU_CRM_Response_Method.ClientID + ",";
                    strMessages += "Please select [Resolution]/Sent By" + ",";
                    Span39.Style["display"] = "inline-block";
                    break;
                case "Letter N/A Reason":
                    strCtrlsIDs += drpFK_LU_CRM_Letter_NA_Reason.ClientID + ",";
                    strMessages += "Please select [Resolution]/Letter N/A Reason" + ",";
                    Span40.Style["display"] = "inline-block";
                    break;
                case "Letter N/A Note":
                    strCtrlsIDs += txtLetter_NA_Note.ClientID + ",";
                    strMessages += "Please enter [Resolution]/Letter N/A Note" + ",";
                    Span41.Style["display"] = "inline-block";
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