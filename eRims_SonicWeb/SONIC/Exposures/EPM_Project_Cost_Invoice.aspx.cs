using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;


public partial class SONIC_Exposures_EPM_Project_Cost_Invoice : clsBasePage
{
    #region " Properties "
    
    public decimal PK_EPM_Project_Cost_Invoice
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Project_Cost_Invoice"]); }
        set { ViewState["PK_EPM_Project_Cost_Invoice"] = value; }
    }

    /// <summary>
    /// denotes Foreign Key of EPM_Identification table
    /// </summary>
    public decimal FK_EPM_Identification
    {
        get { return Convert.ToDecimal(ViewState["FK_EPM_Identification"]); }
        set { ViewState["FK_EPM_Identification"] = value; }
    }

    /// <summary>
    /// Denote Location ID for Environmental Project Management Data
    /// </summary>
    public int LocationID
    {
        get { return Convert.ToInt32(ViewState["LocationID"]); }
        set { ViewState["LocationID"] = value; }
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
    /// Denote PanelNum 
    /// </summary>
    public string PanelNum
    {
        get { return Convert.ToString(ViewState["PanelNum"]); }
        set { ViewState["PanelNum"] = value; }
    }

    /// <summary>
    /// denotes Primary Key of Epm_identification table
    /// </summary>
    public decimal Identification_ID
    {
        get { return Convert.ToDecimal(ViewState["Identification_ID"]); }
        set { ViewState["Identification_ID"] = value; }
    }

    #endregion

    #region " page Event "
    /// <summary>
    /// Handles Page load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.ProjectManagement);

        if (!IsPostBack)
        {
            txtInvoiceNumber.Focus();
            LocationID = Convert.ToInt32(Request.QueryString["loc"].ToString());
            FK_EPM_Identification = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["Cid"].ToString()));            
            if (Request.QueryString["PCInvoice"] != null) PK_EPM_Project_Cost_Invoice = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["PCInvoice"].ToString()));
            Identification_ID = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["id"].ToString()));
            StrOperation = Request.QueryString["op"].ToString();
            PanelNum = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();

            ComboHelper.FillState(new DropDownList[] { ddlVendorState }, 0, true);

            //ComboHelper.FillEPM_Project_Phase(new DropDownList[] { drpProject_Phase }, true);
            BindHeaderInfo();
            

            if (StrOperation.ToLower() == "add")
            {
                btnProjectCost_Audit.Visible = false;
            }

            if (StrOperation.ToLower() == "edit")
            {
                BindProjectCostDetailsForEdit();
            }
            else if (StrOperation.ToLower() == "view")
            {
                BindProjectCostDetailsForView();
            }
            SetValidations();
            // store the location id in session
            Session["ExposureLocation"] = LocationID;
        }
        //txtDateToday.Text = DateTime.Today.ToString("MM/dd/yyyy");
    }
    #endregion

    #region " Button Events "
    /// <summary>
    /// Handles save Click Of Project Cost
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveProject_Cost_OnClick(object sender, EventArgs e)
    {
        clsEPM_Project_Cost_Invoice objEPM_Project_Cost_Invoice = new clsEPM_Project_Cost_Invoice();
        objEPM_Project_Cost_Invoice.PK_EPM_Project_Cost_Invoice = PK_EPM_Project_Cost_Invoice;
        objEPM_Project_Cost_Invoice.FK_EPM_Identification = FK_EPM_Identification;
        objEPM_Project_Cost_Invoice.Invoice_Number = txtInvoiceNumber.Text;
        if(txtInvoiceDate.Text != string.Empty && txtInvoiceDate.Text != "05/23/1964") objEPM_Project_Cost_Invoice.Invoice_Date = clsGeneral.FormatDateToStore(txtInvoiceDate.Text);
        else objEPM_Project_Cost_Invoice.Invoice_Date = null;
        objEPM_Project_Cost_Invoice.Invoice_Amount = clsGeneral.GetDecimalNullableValue(txtInvoiceAmount);
        objEPM_Project_Cost_Invoice.Invoice_Charges_RM = clsGeneral.GetDecimalNullableValue(txtRiskManagement);       
        objEPM_Project_Cost_Invoice.Invoice_Charges_CD_RE = clsGeneral.GetDecimalNullableValue(txtCorporateDevelopment);       
        objEPM_Project_Cost_Invoice.Invoice_Charges_Store = clsGeneral.GetDecimalNullableValue(txtStore);       
        objEPM_Project_Cost_Invoice.Vendor = txtVendor.Text;
        objEPM_Project_Cost_Invoice.Vendor_Address = txtVendorAddress.Text;
        objEPM_Project_Cost_Invoice.Vendor_City = txtVendorCity.Text;
        if(ddlVendorState.SelectedIndex != -1) objEPM_Project_Cost_Invoice.FK_Vendor_State = Convert.ToDecimal(ddlVendorState.SelectedValue);
        objEPM_Project_Cost_Invoice.Vendor_Zip_Code = txtVendorZip.Text;
        objEPM_Project_Cost_Invoice.Vendor_Contact = txtVendorContactName.Text;
        objEPM_Project_Cost_Invoice.Vendor_Telephone = txtVendorTelephone.Text;
        objEPM_Project_Cost_Invoice.Vendor_Email = txtVendorEmail.Text;
        objEPM_Project_Cost_Invoice.Updated_By = clsSession.UserName;
        objEPM_Project_Cost_Invoice.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);
        
        if (PK_EPM_Project_Cost_Invoice > 0)
            objEPM_Project_Cost_Invoice.Update();
        else
            PK_EPM_Project_Cost_Invoice = objEPM_Project_Cost_Invoice.Insert();

        Response.Redirect("EPM_Project_Cost_Invoice.aspx?loc=" + LocationID.ToString() + "&Cid=" + Encryption.Encrypt(FK_EPM_Identification.ToString()) + "&id=" + Encryption.Encrypt(Identification_ID.ToString()) +  "&PCInvoice=" + Encryption.Encrypt(PK_EPM_Project_Cost_Invoice.ToString()) + "&pnl=" + PanelNum + "&op=edit", true);
    }

    /// <summary>
    /// Handels Cancel Click of Cancel button and Redirect page to Project_Management's Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_OnClick(object sender, EventArgs e)
    {
        if (StrOperation.ToLower() == "add")
            StrOperation = "edit";
        Response.Redirect("Project_Management.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&id=" + Encryption.Encrypt(FK_EPM_Identification.ToString()) + "&pnl=" + PanelNum + "&op=" + StrOperation, true);
    }
    #endregion

    #region " Private Method "
    /// <summary>
    /// bind Project Cost detail for view mode
    /// </summary>
    private void BindProjectCostDetailsForView()
    {
        btnProjectCost_Audit.Visible = true;
        btnSaveProject_Cost.Visible = false;
        dvEdit.Style["display"] = "none";
        divView.Style["display"] = "";
        btnCancel.Text = btnCancel.Text.Replace("Cancel", "Back");

        clsEPM_Project_Cost_Invoice objEPM_Project_Cost_Invoice = new clsEPM_Project_Cost_Invoice(PK_EPM_Project_Cost_Invoice);
        objEPM_Project_Cost_Invoice.FK_EPM_Identification = FK_EPM_Identification;
        lblInvoiceNumber.Text = objEPM_Project_Cost_Invoice.Invoice_Number;
        lblInvoiceDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEPM_Project_Cost_Invoice.Invoice_Date);
        lblInvoiceAmount.Text = clsGeneral.FormatCommaSeperatorCurrency(objEPM_Project_Cost_Invoice.Invoice_Amount);
        lblRiskManagement.Text = clsGeneral.FormatCommaSeperatorCurrency(objEPM_Project_Cost_Invoice.Invoice_Charges_RM);
        lblCorporateDevelopment.Text = clsGeneral.FormatCommaSeperatorCurrency(objEPM_Project_Cost_Invoice.Invoice_Charges_CD_RE);
        lblStore.Text = clsGeneral.FormatCommaSeperatorCurrency(objEPM_Project_Cost_Invoice.Invoice_Charges_Store);
        lblVendor.Text = Convert.ToString(objEPM_Project_Cost_Invoice.Vendor);
        lblVendorAddress.Text = Convert.ToString(objEPM_Project_Cost_Invoice.Vendor_Address);
        lblVendorCity.Text = Convert.ToString(objEPM_Project_Cost_Invoice.Vendor_City);
        if (objEPM_Project_Cost_Invoice.FK_Vendor_State != null) lblVendorState.Text = new State((decimal)objEPM_Project_Cost_Invoice.FK_Vendor_State).FLD_state;
        lblVendorZip.Text = Convert.ToString(objEPM_Project_Cost_Invoice.Vendor_Zip_Code);
        lblVendorContactNumber.Text = Convert.ToString(objEPM_Project_Cost_Invoice.Vendor_Contact);
        lblVendorTelephone.Text = Convert.ToString(objEPM_Project_Cost_Invoice.Vendor_Telephone);
        lblVendorEmail.Text = Convert.ToString(objEPM_Project_Cost_Invoice.Vendor_Email);
    }

    /// <summary>
    /// bind Project Cost detail for edit mode
    /// </summary>
    private void BindProjectCostDetailsForEdit()
    {
        btnProjectCost_Audit.Visible = true;
        btnCancel.Text = btnCancel.Text.Replace("Cancel", "Back");
        clsEPM_Project_Cost_Invoice objEPM_Project_Cost_Invoice = new clsEPM_Project_Cost_Invoice(PK_EPM_Project_Cost_Invoice);
        objEPM_Project_Cost_Invoice.FK_EPM_Identification = FK_EPM_Identification;
        txtInvoiceNumber.Text = objEPM_Project_Cost_Invoice.Invoice_Number;
        txtInvoiceDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEPM_Project_Cost_Invoice.Invoice_Date);
        txtInvoiceAmount.Text = clsGeneral.FormatCommaSeperatorCurrency(objEPM_Project_Cost_Invoice.Invoice_Amount);
        txtRiskManagement.Text = clsGeneral.FormatCommaSeperatorCurrency(objEPM_Project_Cost_Invoice.Invoice_Charges_RM);
        txtCorporateDevelopment.Text = clsGeneral.FormatCommaSeperatorCurrency(objEPM_Project_Cost_Invoice.Invoice_Charges_CD_RE);
        txtStore.Text = clsGeneral.FormatCommaSeperatorCurrency(objEPM_Project_Cost_Invoice.Invoice_Charges_Store);
        txtVendor.Text = Convert.ToString(objEPM_Project_Cost_Invoice.Vendor);
        txtVendorAddress.Text = Convert.ToString(objEPM_Project_Cost_Invoice.Vendor_Address);
        txtVendorCity.Text =  Convert.ToString(objEPM_Project_Cost_Invoice.Vendor_City);
        if (objEPM_Project_Cost_Invoice.FK_Vendor_State != null) ddlVendorState.SelectedValue = Convert.ToString(objEPM_Project_Cost_Invoice.FK_Vendor_State);
        txtVendorZip.Text = Convert.ToString(objEPM_Project_Cost_Invoice.Vendor_Zip_Code);
        txtVendorContactName.Text = Convert.ToString(objEPM_Project_Cost_Invoice.Vendor_Contact);
        txtVendorTelephone.Text = Convert.ToString(objEPM_Project_Cost_Invoice.Vendor_Telephone);
        txtVendorEmail.Text = Convert.ToString(objEPM_Project_Cost_Invoice.Vendor_Email);
    }

    /// <summary>
    /// Bind Header Info
    /// </summary>
    private void BindHeaderInfo()
    {
        DataTable dtLocationInfo = LU_Location.SelectByPK(LocationID).Tables[0];
        if (dtLocationInfo != null && dtLocationInfo.Rows.Count > 0)
        {
            lblLocation_Number.Text = (dtLocationInfo.Rows[0]["Sonic_Location_Code"].ToString() != "") ? dtLocationInfo.Rows[0]["Sonic_Location_Code"].ToString() : "";
            lblLocationdba.Text = (dtLocationInfo.Rows[0]["dba"].ToString() != "") ? dtLocationInfo.Rows[0]["dba"].ToString() : "";
            lblAddress.Text = (dtLocationInfo.Rows[0]["Address"].ToString() != "") ? dtLocationInfo.Rows[0]["Address"].ToString() : "";
            lblCity.Text = (dtLocationInfo.Rows[0]["City"].ToString() != "") ? dtLocationInfo.Rows[0]["City"].ToString() : "";
            lblState.Text = (dtLocationInfo.Rows[0]["StateName"].ToString() != "") ? dtLocationInfo.Rows[0]["StateName"].ToString() : "";
            lblZip.Text = (dtLocationInfo.Rows[0]["Zip_Code"].ToString() != "") ? dtLocationInfo.Rows[0]["Zip_Code"].ToString() : "";
        }
        DataTable dtProjectNumber = clsEPM_Identification.GetProjectNumber(LocationID, Identification_ID == 0 ? FK_EPM_Identification : Identification_ID).Tables[0];
        if (dtProjectNumber != null && dtProjectNumber.Rows.Count > 0)
        {
            lblHeaderProject_Number.Text = (dtProjectNumber.Rows[0]["Project_Number"].ToString() != "") ? dtProjectNumber.Rows[0]["Project_Number"].ToString() : "";
            lblHeaderProject_Type.Text = (dtProjectNumber.Rows[0]["Project_Type"].ToString() != "") ? dtProjectNumber.Rows[0]["Project_Type"].ToString() : "";
            tdProjectNum.Style["display"] = "block"; tdHeaderPro_Num.Style["display"] = "block"; tdHeaderProType.Style["display"] = "block"; tdProjectType.Style["display"] = "block";
        }
    }
    #endregion

    #region " Dynamic validations "
    private void SetValidations()
    {
        #region " Identification"
        string strCtrlsIDsProjectCost = "";
        string strMessagesProjectCost = "";
        DataTable dtFieldsProjectCost = clsScreen_Validators.SelectByScreen(214).Tables[0];
        dtFieldsProjectCost.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsProjectCost = dtFieldsProjectCost.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFieldsProjectCost.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drFieldsProjectCost in dtFieldsProjectCost.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldsProjectCost["Field_Name"]))
            {
                case "Invoice Number": strCtrlsIDsProjectCost += txtInvoiceNumber.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Invoice Number" + ","; spnInvoiceNumber.Style["display"] = "inline-block"; break;
                case "Invoice Date": strCtrlsIDsProjectCost += txtInvoiceDate.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Invoice Date" + ","; spnInvoiceDate.Style["display"] = "inline-block"; break;
                case "Invoice Amount": strCtrlsIDsProjectCost += txtInvoiceAmount.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Invoice Amount" + ","; spnInvoiceAmount.Style["display"] = "inline-block"; break;
                case "Risk Management": strCtrlsIDsProjectCost += txtRiskManagement.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Risk Management" + ","; spnRiskManagement.Style["display"] = "inline-block"; break;
                case "Corporate Development/Real Estate": strCtrlsIDsProjectCost += txtCorporateDevelopment.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Corporate Development" + ","; spnCorporateDevelopment.Style["display"] = "inline-block"; break;
                case "Store": strCtrlsIDsProjectCost += txtStore.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Store" + ","; spnStore.Style["display"] = "inline-block"; break;
                case "Vendor": strCtrlsIDsProjectCost += txtVendor.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Store" + ","; spnVendor.Style["display"] = "inline-block"; break;
                case "Vendor Address": strCtrlsIDsProjectCost += txtVendorAddress.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Vendor Address" + ","; spnVendorAddress.Style["display"] = "inline-block"; break;
                case "Vendor City": strCtrlsIDsProjectCost += txtVendorCity.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Vendor City" + ","; spnVendorCity .Style["display"] = "inline-block"; break;
                case "Vendor State": strCtrlsIDsProjectCost += ddlVendorState.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Vendor State" + ","; spnVendorState.Style["display"] = "inline-block"; break;
                case "Vendor Zip": strCtrlsIDsProjectCost += txtVendorZip.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Vendor Zip" + ","; spnVendorZip.Style["display"] = "inline-block"; break;
                case "Vendor Contact Name": strCtrlsIDsProjectCost += txtVendorContactName.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Vendor Contact Name" + ","; spnVendorContactName.Style["display"] = "inline-block"; break;
                case "Vendor Telephone": strCtrlsIDsProjectCost += txtVendorTelephone.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Vendor Telephone" + ","; spnVendorTelephone.Style["display"] = "inline-block"; break;
                case "Vendor E-Mail": strCtrlsIDsProjectCost += txtVendorEmail.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Vendor Email" + ","; spnVendorEmail.Style["display"] = "inline-block"; break;

            }
            #endregion
        }
        strCtrlsIDsProjectCost = strCtrlsIDsProjectCost.TrimEnd(',');
        strMessagesProjectCost = strMessagesProjectCost.TrimEnd(',');

        hdnControlIDsProjectCost.Value = strCtrlsIDsProjectCost;
        hdnErrorMsgsProjectCost.Value = strMessagesProjectCost;

        #endregion
    }
    #endregion
}