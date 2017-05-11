using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;


public partial class SONIC_Exposures_ACI_Management_ProjectCost_Invoice : clsBasePage
{
    #region " Properties "

    public decimal PK_ACIManagement_ProjectCost_Invoice
    {
        get { return Convert.ToDecimal(ViewState["PK_ACIManagement_ProjectCost_Invoice"]); }
        set { ViewState["PK_ACIManagement_ProjectCost_Invoice"] = value; }
    }

    /// <summary>
    /// denotes Foreign Key of EPM_Identification table
    /// </summary>
    public decimal FK_Management
    {
        get { return Convert.ToDecimal(ViewState["FK_Management"]); }
        set { ViewState["FK_Management"] = value; }
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
     
    #endregion

    #region " page Event "
    /// <summary>
    /// Handles Page load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            txtInvoiceNumber.Focus();
            //LocationID = Convert.ToInt32(Request.QueryString["loc"].ToString());
            FK_Management = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["id"].ToString()));            
            if (Request.QueryString["PCInvoice"] != null) PK_ACIManagement_ProjectCost_Invoice = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["PCInvoice"].ToString()));
            
            StrOperation = Request.QueryString["op"].ToString();
            PanelNum = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();

            ComboHelper.FillState(new DropDownList[] { ddlVendorState }, 0, true);

            if (StrOperation.ToLower() == "add")
            {
                btnProjectCost_Audit.Visible = false;
                SetValidations();
            }

            if (StrOperation.ToLower() == "edit")
            {
                BindProjectCostDetailsForEdit();
                SetValidations();
            }
            else if (StrOperation.ToLower() == "view")
            {
                BindProjectCostDetailsForView();
            }
            //SetValidations();
        }
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
        clsACIManagement_ProjectCost_Invoice objACIManagement_ProjectCost_Invoice = new clsACIManagement_ProjectCost_Invoice();
        objACIManagement_ProjectCost_Invoice.PK_ACIManagement_ProjectCost_Invoice = PK_ACIManagement_ProjectCost_Invoice;
        objACIManagement_ProjectCost_Invoice.FK_Management = FK_Management;
        objACIManagement_ProjectCost_Invoice.Invoice_Number = txtInvoiceNumber.Text;
        if(txtInvoiceDate.Text != string.Empty && txtInvoiceDate.Text != "05/23/1964") objACIManagement_ProjectCost_Invoice.Invoice_Date = clsGeneral.FormatDateToStore(txtInvoiceDate.Text);
        else objACIManagement_ProjectCost_Invoice.Invoice_Date = null;
        objACIManagement_ProjectCost_Invoice.Invoice_Amount = clsGeneral.GetDecimalNullableValue(txtInvoiceAmount);
        objACIManagement_ProjectCost_Invoice.Invoice_Charges_RM = clsGeneral.GetDecimalNullableValue(txtRiskManagement);       
        objACIManagement_ProjectCost_Invoice.Invoice_Charges_CD_RE = clsGeneral.GetDecimalNullableValue(txtCorporateDevelopment);       
        objACIManagement_ProjectCost_Invoice.Invoice_Charges_Store = clsGeneral.GetDecimalNullableValue(txtStore);       
        objACIManagement_ProjectCost_Invoice.Vendor = txtVendor.Text;
        objACIManagement_ProjectCost_Invoice.Vendor_Address = txtVendorAddress.Text;
        objACIManagement_ProjectCost_Invoice.Vendor_City = txtVendorCity.Text;
        if(ddlVendorState.SelectedIndex != -1) objACIManagement_ProjectCost_Invoice.FK_Vendor_State = Convert.ToDecimal(ddlVendorState.SelectedValue);
        objACIManagement_ProjectCost_Invoice.Vendor_Zip_Code = txtVendorZip.Text;
        objACIManagement_ProjectCost_Invoice.Vendor_Contact = txtVendorContactName.Text;
        objACIManagement_ProjectCost_Invoice.Vendor_Telephone = txtVendorTelephone.Text;
        objACIManagement_ProjectCost_Invoice.Vendor_Email = txtVendorEmail.Text;
        objACIManagement_ProjectCost_Invoice.Updated_By = clsSession.UserName;
        objACIManagement_ProjectCost_Invoice.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);
        if (txtInvoice_ProccesedBySonicDate.Text != string.Empty && txtInvoice_ProccesedBySonicDate.Text != "05/23/1964") objACIManagement_ProjectCost_Invoice.Invoice_ProccesedBySonicDate = clsGeneral.FormatDateToStore(txtInvoice_ProccesedBySonicDate.Text);
        if (txtPayment_ReceivedbyACIDate.Text != string.Empty && txtPayment_ReceivedbyACIDate.Text != "05/23/1964") objACIManagement_ProjectCost_Invoice.Payment_ReceivedbyACIDate = clsGeneral.FormatDateToStore(txtPayment_ReceivedbyACIDate.Text);
        objACIManagement_ProjectCost_Invoice.Comments = txtComments.Text;
                
        if (PK_ACIManagement_ProjectCost_Invoice > 0)
            objACIManagement_ProjectCost_Invoice.Update();
        else
            PK_ACIManagement_ProjectCost_Invoice = objACIManagement_ProjectCost_Invoice.Insert();

        Response.Redirect("ACI_Management_ProjectCost_Invoice.aspx?id=" + Encryption.Encrypt(FK_Management.ToString()) +  "&PCInvoice=" + Encryption.Encrypt(PK_ACIManagement_ProjectCost_Invoice.ToString()) + "&pnl=" + PanelNum + "&op=edit", true);
    }

    /// <summary>
    /// Cancel Click of Cancel button and Redirect page to Management's Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_OnClick(object sender, EventArgs e)
    {
        if (StrOperation.ToLower() == "add")
            StrOperation = "edit";
        Response.Redirect("Management.aspx?id=" + Encryption.Encrypt(FK_Management.ToString()) + "&pnl=" + PanelNum + "&mode=" + StrOperation, true);
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

        clsACIManagement_ProjectCost_Invoice objACIManagement_ProjectCost_Invoice = new clsACIManagement_ProjectCost_Invoice(PK_ACIManagement_ProjectCost_Invoice);
        objACIManagement_ProjectCost_Invoice.FK_Management = FK_Management;
        lblInvoiceNumber.Text = objACIManagement_ProjectCost_Invoice.Invoice_Number;
        lblInvoiceDate.Text = clsGeneral.FormatDBNullDateToDisplay(objACIManagement_ProjectCost_Invoice.Invoice_Date);
        lblInvoiceAmount.Text = clsGeneral.FormatCommaSeperatorCurrency(objACIManagement_ProjectCost_Invoice.Invoice_Amount);
        lblRiskManagement.Text = clsGeneral.FormatCommaSeperatorCurrency(objACIManagement_ProjectCost_Invoice.Invoice_Charges_RM);
        lblCorporateDevelopment.Text = clsGeneral.FormatCommaSeperatorCurrency(objACIManagement_ProjectCost_Invoice.Invoice_Charges_CD_RE);
        lblStore.Text = clsGeneral.FormatCommaSeperatorCurrency(objACIManagement_ProjectCost_Invoice.Invoice_Charges_Store);
        lblVendor.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Vendor);
        lblVendorAddress.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Vendor_Address);
        lblVendorCity.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Vendor_City);
        if (objACIManagement_ProjectCost_Invoice.FK_Vendor_State != null) lblVendorState.Text = new State((decimal)objACIManagement_ProjectCost_Invoice.FK_Vendor_State).FLD_state;
        lblVendorZip.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Vendor_Zip_Code);
        lblVendorContactNumber.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Vendor_Contact);
        lblVendorTelephone.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Vendor_Telephone);
        lblVendorEmail.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Vendor_Email);
        lblInvoice_ProccesedBySonicDate.Text = clsGeneral.FormatDBNullDateToDisplay(objACIManagement_ProjectCost_Invoice.Invoice_ProccesedBySonicDate);
        lblPayment_ReceivedbyACIDate.Text = clsGeneral.FormatDBNullDateToDisplay(objACIManagement_ProjectCost_Invoice.Payment_ReceivedbyACIDate);
        lblComments.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Comments);
        //lblComments.Enable = false;
    }

    /// <summary>
    /// bind Project Cost detail for edit mode
    /// </summary>
    private void BindProjectCostDetailsForEdit()
    {
        btnProjectCost_Audit.Visible = true;
        btnCancel.Text = btnCancel.Text.Replace("Cancel", "Back");
        clsACIManagement_ProjectCost_Invoice objACIManagement_ProjectCost_Invoice = new clsACIManagement_ProjectCost_Invoice(PK_ACIManagement_ProjectCost_Invoice);
        objACIManagement_ProjectCost_Invoice.FK_Management = FK_Management;
        txtInvoiceNumber.Text = objACIManagement_ProjectCost_Invoice.Invoice_Number;
        txtInvoiceDate.Text = clsGeneral.FormatDBNullDateToDisplay(objACIManagement_ProjectCost_Invoice.Invoice_Date);
        txtInvoiceAmount.Text = clsGeneral.FormatCommaSeperatorCurrency(objACIManagement_ProjectCost_Invoice.Invoice_Amount);
        txtRiskManagement.Text = clsGeneral.FormatCommaSeperatorCurrency(objACIManagement_ProjectCost_Invoice.Invoice_Charges_RM);
        txtCorporateDevelopment.Text = clsGeneral.FormatCommaSeperatorCurrency(objACIManagement_ProjectCost_Invoice.Invoice_Charges_CD_RE);
        txtStore.Text = clsGeneral.FormatCommaSeperatorCurrency(objACIManagement_ProjectCost_Invoice.Invoice_Charges_Store);
        txtVendor.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Vendor);
        txtVendorAddress.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Vendor_Address);
        txtVendorCity.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Vendor_City);
        if (objACIManagement_ProjectCost_Invoice.FK_Vendor_State != null) ddlVendorState.SelectedValue = Convert.ToString(objACIManagement_ProjectCost_Invoice.FK_Vendor_State);
        txtVendorZip.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Vendor_Zip_Code);
        txtVendorContactName.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Vendor_Contact);
        txtVendorTelephone.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Vendor_Telephone);
        txtVendorEmail.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Vendor_Email);
        txtInvoice_ProccesedBySonicDate.Text = clsGeneral.FormatDBNullDateToDisplay(objACIManagement_ProjectCost_Invoice.Invoice_ProccesedBySonicDate);
        txtPayment_ReceivedbyACIDate.Text = clsGeneral.FormatDBNullDateToDisplay(objACIManagement_ProjectCost_Invoice.Payment_ReceivedbyACIDate);
        txtComments.Text = Convert.ToString(objACIManagement_ProjectCost_Invoice.Comments);
    }

    #endregion

    #region " Dynamic validations "
    private void SetValidations()
    {
        #region " Identification"
        string strCtrlsIDsProjectCost = "";
        string strMessagesProjectCost = "";
        DataTable dtFieldsProjectCost = clsScreen_Validators.SelectByScreen(clsScreen.ScreenSelectByName("Project Cost - Invoice")).Tables[0];
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
                case "Vendor": strCtrlsIDsProjectCost += txtVendor.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Vendor" + ","; spnVendor.Style["display"] = "inline-block"; break;
                case "Vendor Address": strCtrlsIDsProjectCost += txtVendorAddress.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Vendor Address" + ","; spnVendorAddress.Style["display"] = "inline-block"; break;
                case "Vendor City": strCtrlsIDsProjectCost += txtVendorCity.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Vendor City" + ","; spnVendorCity.Style["display"] = "inline-block"; break;
                case "Vendor State": strCtrlsIDsProjectCost += ddlVendorState.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Vendor State" + ","; spnVendorState.Style["display"] = "inline-block"; break;
                case "Vendor Zip": strCtrlsIDsProjectCost += txtVendorZip.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Vendor Zip" + ","; spnVendorZip.Style["display"] = "inline-block"; break;
                case "Vendor Contact Name": strCtrlsIDsProjectCost += txtVendorContactName.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Vendor Contact Name" + ","; spnVendorContactName.Style["display"] = "inline-block"; break;
                case "Vendor Telephone": strCtrlsIDsProjectCost += txtVendorTelephone.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Vendor Telephone" + ","; spnVendorTelephone.Style["display"] = "inline-block"; break;
                case "Vendor E-Mail": strCtrlsIDsProjectCost += txtVendorEmail.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Vendor Email" + ","; spnVendorEmail.Style["display"] = "inline-block"; break;
                case "Comments": strCtrlsIDsProjectCost += txtComments.ClientID + ","; strMessagesProjectCost += "Please select [Project Cost - Invoice]/Comments" + ","; spnComments.Style["display"] = "inline-block"; break;

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