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

public partial class SONIC_Purchasing_PurchasingAssetInformation : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes Primary key value for Purchasing Asset record
    /// </summary>
    public int PK_Purchasing_Asset
    {
        get { return clsGeneral.GetInt(ViewState["PK_Purchasing_Asset"]); }
        set { ViewState["PK_Purchasing_Asset"] = value; }
    }
    /// <summary>  
    /// Denotes operation either view or edit
    /// </summary>
    public String StrOperation
    {
        get
        {
            if (!String.IsNullOrEmpty(Request.QueryString["op"]))
            {
                return Convert.ToString(Request.QueryString["op"]);
            }
            else
            {
                return String.Empty;
            }
        }
    }
    /// <summary>
    /// Denotes operation either view or edit
    /// </summary>
    public string strOperation
    {
        get
        {
            return clsSession.Str_Asset_Operation;
        }
    }

    #endregion

    #region "Page event"
    protected void Page_Load(object sender, EventArgs e)
    {
        Attachment.btnHandler += new Controls_Attachments_Attachment.OnButtonClick(Upload_File);
        if (!IsPostBack)
        {
            clsSession.Current_Purchasing_Asset_ID = PK_Purchasing_Asset = 0;
            // set panel
            // check for the querystring whether panel number is passed 
            // otherwise display first panel
            if (!clsGeneral.IsNull(Request.QueryString["pnl"]))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + Request.QueryString["pnl"] + ");", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            }
            //Call to Dropdown list data
            BindDropDown();
            if (!String.IsNullOrEmpty(Request.QueryString["op"]))
            {
                if (Convert.ToString(Request.QueryString["op"]) == "add")
                    clsSession.Str_Asset_Operation = "add";
            }
            else
            {

                // set the primary key 
                if (!clsGeneral.IsNull(Request.QueryString["id"]))
                {
                    int index;
                    if (int.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                        clsSession.Current_Purchasing_Asset_ID = PK_Purchasing_Asset = index;
                    else
                        clsSession.Str_Asset_Operation = "add";
                }
                else
                    clsSession.Str_Asset_Operation = "add";
            }
            // check for the operation if edit mode or view mode
            if (clsSession.Str_Asset_Operation != "add")
            {
                // set PK_Executive_Risk_Carrier
                //PK_Purchasing_Asset = index;
                BindGrids();
                if (clsSession.Str_Asset_Operation == "view")
                {
                    btnBack.Visible = true;
                    // Bind Controls in view mode
                    btnNextStepView.Visible = true;
                    BindDetailsForView();
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Tables.Purchasing_Asset, PK_Purchasing_Asset, false, 3);
                }
                else
                {
                    //Bind Controls in edit mode
                    BindDetailsForEdit();
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Tables.Purchasing_Asset, PK_Purchasing_Asset, true, 3);
                }

                BindAttachmentDetails();
            }
            else
            {
                // hide the add attachment button 
                Attachment.ShowAttachmentButton = false;
                PurchasingAssetTab.Visible = false;
                btnAssetInfoAudit.Visible = false;
                btnAssetInfoAudit_View.Visible = false;
                //set the panel value
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
                BindAttachmentDetails();
            }
            CheckUserRights();
            if (clsSession.Str_Asset_Operation != "view")
                SetValidations();
           
        }

    }
    #endregion

    #region "Methods"
    /// <summary>
    /// Binds all grids on page
    /// </summary>
    private void BindGrids()
    {
        BindServiceContactDetail();
        BindLRAggrementDetail();
        BindNotesViewGrid();
    }

    /// <summary>
    /// Used to save the data
    /// </summary>
    private void SaveData()
    {
        // if page is valid
        if (Page.IsValid)
        {
            // create object for the Purchasing Asset record
            Purchasing_Asset objAsset = new Purchasing_Asset();
            // get the values from the page controls
            objAsset.PK_Purchasing_Asset = PK_Purchasing_Asset;
            objAsset.Type = txtType.Text.Trim();
            if (hdnFK_LU_Manufacturer.Value != "")
                objAsset.FK_LU_Manufacturer = Convert.ToDecimal(hdnFK_LU_Manufacturer.Value);
            else
                objAsset.FK_LU_Manufacturer = 0;
            objAsset.FK_LU_Dealership_Department = Convert.ToDecimal(ddlFK_LU_Dealership_Department.SelectedValue);
            objAsset.Serial_Number = txtSerial_Number.Text.Trim();
            objAsset.Model_Number = txtModel_Number.Text.Trim();
            objAsset.Supplier = txtSupplier.Text.Trim();
            objAsset.Acquisition_Date = clsGeneral.FormatDateToStore(txtAcquisition_Date);
            objAsset.Useful_Life = txtUseful_Life.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtUseful_Life.Text.Trim());
            if (txtAcquisition_Cost.Text.Trim() == "")
                objAsset.Acquisition_Cost = 0;
            else
                objAsset.Acquisition_Cost = Convert.ToDecimal(txtAcquisition_Cost.Text.Trim());
            objAsset.FK_LU_Location = Convert.ToDecimal(ddlFK_LU_Location.SelectedValue);
            objAsset.Notes = txtNotes.Text.Trim();
            objAsset.Update_Date = DateTime.Now;
            objAsset.Updated_By = clsSession.UserID.ToString();
            // update or insert the data according to the primary key
            if (PK_Purchasing_Asset > 0)
            {
                objAsset.Update();
            }
            else
            {
                PK_Purchasing_Asset = objAsset.Insert();
            }
            Upload_File(string.Empty);
            BindAttachmentDetails();
        }
    }

    /// <summary>
    /// /// <summary>
    /// Displays the page in edit mode
    /// </summary>
    /// </summary>
    private void BindDetailsForEdit()
    {
        // don't show div for view mode
        dvView.Style["display"] = "None";
        // create object for the Purchasing Asset record
        Purchasing_Asset objAsset = new Purchasing_Asset(PK_Purchasing_Asset);
        txtType.Text = objAsset.Type;
        LU_Manufacturer objManufacturer = new LU_Manufacturer(objAsset.FK_LU_Manufacturer);
        txtFK_LU_Manufacturer.Text = objManufacturer.Fld_Desc;
        hdnFK_LU_Manufacturer.Value = objAsset.FK_LU_Manufacturer.ToString();
        ddlFK_LU_Dealership_Department.SelectedValue = Convert.ToString(objAsset.FK_LU_Dealership_Department);
        txtSerial_Number.Text = objAsset.Serial_Number;
        txtModel_Number.Text = objAsset.Model_Number;
        txtSupplier.Text = objAsset.Supplier;
        txtAcquisition_Date.Text = clsGeneral.FormatDateToDisplay(objAsset.Acquisition_Date);
        txtUseful_Life.Text = Convert.ToString(objAsset.Useful_Life);
        txtAcquisition_Cost.Text = clsGeneral.GetStringValue(objAsset.Acquisition_Cost).Replace(".00", "");
        ddlFK_LU_Location.SelectedValue = Convert.ToString(objAsset.FK_LU_Location);
        txtNotes.Text = objAsset.Notes;
        btnAssetInfoAudit_View.Visible = false;
        btnAssetInfoAudit.Visible = true;
    }

    /// /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        // don't show div for view mode
        dvView.Style["display"] = "block";
        dvEdit.Style["Display"] = "None";
        dvSave.Style["Display"] = "None";
        // create object for the Purchasing Asset record
        Purchasing_Asset objAsset = new Purchasing_Asset(PK_Purchasing_Asset);
        lblType.Text = objAsset.Type;
        LU_Manufacturer objManufacturer = new LU_Manufacturer(objAsset.FK_LU_Manufacturer);
        lblFK_LU_Manufacturer.Text = objManufacturer.Fld_Desc;
        // create object
        LU_Dealership_Department objRiskCarrier = new LU_Dealership_Department(objAsset.FK_LU_Dealership_Department);
        lblFK_LU_Dealership_Department.Text = objRiskCarrier.Fld_Desc;
        // set values in page controls     
        lblSerial_Number.Text = objAsset.Serial_Number;
        lblModel_Number.Text = objAsset.Model_Number;
        lblSupplier.Text = objAsset.Supplier;
        lblAcquisition_Date.Text = clsGeneral.FormatDateToDisplay(objAsset.Acquisition_Date);
        lblUseful_Life.Text = Convert.ToString(objAsset.Useful_Life);
        lblAcquisition_Cost.Text = clsGeneral.GetStringValue(objAsset.Acquisition_Cost).Replace(".00", "");
        //lbllocation.Text = Convert.ToString(objAsset.FK_LU_Location);
        lblNotes.Text = objAsset.Notes;
        btnAssetInfoAudit_View.Visible = true;
        btnAssetInfoAudit.Visible = false;
        DataTable dtService = Purchasing_Asset.Purchasing_AssetSelectByLocationFK(PK_Purchasing_Asset);
        if (dtService.Rows.Count > 0)
        {
            lbllocation.Text = dtService.Rows[0]["Location"].ToString();
        }
        
    }
    /// <summary>
    /// Function to bind Dropdown list in require page
    /// </summary>
    private void BindDropDown()
    {

        //Dealership Department 
        ddlFK_LU_Dealership_Department.DataSource = LU_Dealership_Department.SelectAll();
        ddlFK_LU_Dealership_Department.DataTextField = "Fld_Desc";
        ddlFK_LU_Dealership_Department.DataValueField = "PK_LU_Dealership_Department";
        ddlFK_LU_Dealership_Department.DataBind();
        ddlFK_LU_Dealership_Department.Items.Insert(0, new ListItem("--Select--", "0"));

        //Location 
        DataTable dtLocation = LU_Location.SelectAllDealershipByUser(Convert.ToDecimal(clsSession.UserID)).Tables[0];
        dtLocation.DefaultView.RowFilter = " Active = 'Y'";
        dtLocation = dtLocation.DefaultView.ToTable();
        ddlFK_LU_Location.DataSource = dtLocation;
        ddlFK_LU_Location.DataTextField = "Location";
        ddlFK_LU_Location.DataValueField = "PK_LU_Location_ID";
        ddlFK_LU_Location.DataBind();
        ddlFK_LU_Location.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    /// <summary>
    /// check user rights
    /// </summary>
    private void CheckUserRights()
    {
        if (App_Access == AccessType.View_Only)
        {
            if (clsSession.Str_Asset_Operation != "view")
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
            }
            btnBack.Visible = false;
            btnNextStepView.Visible = false;
        }
    }

    #endregion

    #region "BindDataGrid"
    /// <summary>
    /// Bind Service Contact Grid in Edit mode
    /// </summary>
    private void BindServiceContactDetail()
    {
        DataTable dtService = Purchasing_Asset.Purchasing_ServiceContractSelectByFK(PK_Purchasing_Asset);
        if (clsSession.Str_Asset_Operation == "view")
        {
            gvServiceContact.DataSource = dtService;
            gvServiceContact.DataBind();
        }
        else
        {
            grvService.DataSource = dtService;
            grvService.DataBind();
        }
    }
    /// <summary>
    /// Bind LR Aggrement Grid in Edit mode
    /// </summary>
    private void BindLRAggrementDetail()
    {
        DataTable dtLRAggrement = Purchasing_Asset.Purchasing_LRAggrementSelectByFK(PK_Purchasing_Asset);
        if (clsSession.Str_Asset_Operation == "view")
        {
            gvLRAgreementView.DataSource = dtLRAggrement;
            gvLRAgreementView.DataBind();
        }
        else
        {
            gvLRAgreement.DataSource = dtLRAggrement;
            gvLRAgreement.DataBind();
        }
    }

    /// <summary>
    /// Bind Notes in Grid data value in view 
    /// </summary>
    private void BindNotesViewGrid()
    {
        DataTable dtNotes = Purchasing_Asset_Notes.SelectByFK(PK_Purchasing_Asset).Tables[0];
        if (clsSession.Str_Asset_Operation == "view")
        {
            gvPurchaseNotesView.DataSource = dtNotes;
            gvPurchaseNotesView.DataBind();
            gvPurchaseNotesView.Columns[2].Visible = false;
        }
        else
        {
            gvPurchaseNotes.DataSource = dtNotes;
            gvPurchaseNotes.DataBind();
        }
    }
    #endregion

    #region "Attachments Management"
    /// <summary>
    /// Binds the attachment details
    /// </summary>
    private void BindAttachmentDetails()
    {
        pnlAttachmentDetailView.Style["Display"] = "block";
        AttachDetailsView.Bind();
    }

    /// <summary>
    /// Handles Add Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Upload_File(string strValue)
    {
        if (PK_Purchasing_Asset > 0)
        {
            // add the attachment 
            Attachment.Add(clsGeneral.Tables.Purchasing_Asset, PK_Purchasing_Asset);
            // bind the details to view added attachment
            BindAttachmentDetails();
            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
        }
        else
        {
        }
    }

    #endregion

    #region "Grid Event"
    /// <summary>
    /// Notes grid in row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPurchaseNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //// view the notes record by primary key passed in argument 
        decimal intPKID = Convert.ToDecimal(e.CommandArgument);
        if (e.CommandName == "ViewNote")
        {
            Response.Redirect("PurchasingAssetNote.aspx?id=" + Encryption.Encrypt(intPKID.ToString()));
        }
        // delete the notes record by primary key passed in argument
        else if (e.CommandName == "RemoveNote")
        {
            Purchasing_Asset_Notes.DeleteByPK(intPKID);
            BindNotesViewGrid();
            // show the panel in which the expense grid exists as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
    }
    /// <summary>
    /// Service contact in row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvServiceContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //// view the service contact by primary key passed in argument in open in new page service contact detail display
        if (e.CommandName == "ViewService")
        {
            clsSession.Str_ServiceContract_Operation = "view";

            // open the page in view mode
            Response.Redirect("ServiceContract.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
            // Response.Redirect("ServiceContract.aspx?id=" + e.CommandArgument.ToString() + "&op=view");
        }
    }
    /// <summary>
    /// LR Agreement row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLRAgreement_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // view the LRAgreement by primary key passed in argument in open in new page LR/Agreement detail display
        if (e.CommandName == "ViewLR")
        {
            clsSession.Str_LR_Agreement_Operation = "view";
            Response.Redirect("LeaseRentalAgreement.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));

        }


        // open the page in view mode

    }
    /// <summary>
    /// LR Agreement Page index change event in edit mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLRAgreement_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (StrOperation == "view")
        {
            gvLRAgreementView.PageIndex = e.NewPageIndex;
        }
        else
        {
            gvLRAgreement.PageIndex = e.NewPageIndex;
        }
        BindLRAggrementDetail();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

    }
    /// Service contact page index change in view mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvServiceContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (StrOperation == "view")
        {
            gvServiceContact.PageIndex = e.NewPageIndex;
        }
        else
        {
            grvService.PageIndex = e.NewPageIndex;
        }
        BindServiceContactDetail();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    #endregion

    #region "Event"
    /// <summary>
    /// Notes grid add link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lblAddNotes_Click(object sender, EventArgs e)
    {
        // saves data
        SaveData();
        clsSession.Current_Purchasing_Asset_ID = PK_Purchasing_Asset;
        clsSession.Str_Asset_Operation = "edit";
        //redirect to Executive risk carrier page
        Response.Redirect(AppConfig.SiteURL + "SONIC/Purchasing/PurchasingAssetNote.aspx");
    }
    /// <summary>
    /// Back button click event in page in edit mode 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // redirec to Executive risk page                        
        clsSession.Str_Asset_Operation = "edit";
        Response.Redirect("PurchasingAssetInformation.aspx?id=" + Encryption.Encrypt(PK_Purchasing_Asset.ToString()));
    }
    protected void btnNotesSave_Click(object sender, EventArgs e)
    {
        Purchasing_Asset_Notes objPurchaseNotes = new Purchasing_Asset_Notes();
        objPurchaseNotes.FK_Purchasing_Service_Contract = PK_Purchasing_Asset;
        objPurchaseNotes.Note = txtPur_Asset_Note.Text;
        objPurchaseNotes.Note_Date = clsGeneral.FormatDateToStore(txtPur_Asset_Note_Date.Text);
        objPurchaseNotes.Update_Date = DateTime.Now;
        objPurchaseNotes.Updated_By = "";
        int PK_Purchasing_AssetNotes = objPurchaseNotes.Insert();
    }
    /// <summary>
    /// Save and view button click event in Save data 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        SaveData();
        clsSession.Str_Asset_Operation = "view";
        Response.Redirect("PurchasingAssetInformation.aspx?id=" + Encryption.Encrypt(PK_Purchasing_Asset.ToString()));
    }

    /// <summary>
    /// Handles Next step button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNextStep_Click(object sender, EventArgs e)
    {
        SaveData();
        clsSession.Str_Asset_Operation = "edit";
        Response.Redirect("PurchasingAssetInformation.aspx?id=" + Encryption.Encrypt(PK_Purchasing_Asset.ToString()));

    }
    protected void btnNextStepView_Click(object sender, EventArgs e)
    {

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

        #region "Asset Information"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(87).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk1 = (Label)mnuPurchasingAsset.Controls[0].FindControl("MenuAsterisk");
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 87").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Type":
                    strCtrlsIDs += txtType.ClientID + ",";
                    strMessages += "Please enter [Asset Information]/Type" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Manufacturer":
                    strCtrlsIDs += txtFK_LU_Manufacturer.ClientID + ",";
                    strMessages += "Please enter [Asset Information]/Manufacturer" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Dealership Department":
                    strCtrlsIDs += ddlFK_LU_Dealership_Department.ClientID + ",";
                    strMessages += "Please select [Asset Information]/Dealership Department" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Serial Number":
                    strCtrlsIDs += txtSerial_Number.ClientID + ",";
                    strMessages += "Please enter [Asset Information]/Serial Number" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Model Number":
                    strCtrlsIDs += txtModel_Number.ClientID + ",";
                    strMessages += "Please enter [Asset Information]/Model Number" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Supplier":
                    strCtrlsIDs += txtSupplier.ClientID + ",";
                    strMessages += "Please enter [Asset Information]/Supplier" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Acquisition Date":
                    strCtrlsIDs += txtAcquisition_Date.ClientID + ",";
                    strMessages += "Please enter [Asset Information]/Acquisition Date" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Useful Life in Months":
                    strCtrlsIDs += txtUseful_Life.ClientID + ",";
                    strMessages += "Please enter [Asset Information]/Useful Life in Months" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Acquisition Cost":
                    strCtrlsIDs += txtAcquisition_Cost.ClientID + ",";
                    strMessages += "Please enter [Asset Information]/Acquisition Cost" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Location":
                    strCtrlsIDs += ddlFK_LU_Location.ClientID + ",";
                    strMessages += "Please select [Asset Information]/Location" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Asset Information]/Notes" + ",";
                    Span11.Style["display"] = "inline-block";
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
