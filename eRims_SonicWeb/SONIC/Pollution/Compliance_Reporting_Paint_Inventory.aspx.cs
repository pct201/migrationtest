using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Pollution_Compliance_Reporting_Paint_Inventory : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_CR_Paint_Inventory
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_CR_Paint_Inventory"]);
        }
        set { ViewState["PK_PM_CR_Paint_Inventory"] = value; }
    }
    /// <summary>
    /// Denotes foriegn key for Compliance Reporting
    /// </summary>
    public decimal FK_PM_Compliance_Reporting
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_PM_Compliance_Reporting"]);
        }
        set { ViewState["FK_PM_Compliance_Reporting"] = value; }
    }

    /// <summary>
    /// Denotes foriegn key for Site Information
    /// </summary>
    public decimal FK_PM_Site_Information
    {
        get { return clsGeneral.GetInt(ViewState["FK_PM_Site_Information"]); }
        set { ViewState["FK_PM_Site_Information"] = value; }
    }

    /// <summary>
    /// Denotes foriegn key for Location record
    /// </summary>
    public decimal FK_LU_Location_ID
    {
        get { return Convert.ToDecimal(ViewState["FK_LU_Location_ID"]); }
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
    protected void Page_Load(object sender, EventArgs e)
    {
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Pollution);
        Attachment.btnHandler += new Attachment_Pollution.OnButtonClick(Upload_File);
        if (!Page.IsPostBack)
        {
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            PK_PM_CR_Paint_Inventory = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_PM_Compliance_Reporting = clsGeneral.GetQueryStringID(Request.QueryString["cid"]);
            FK_PM_Site_Information = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);
            FK_LU_Location_ID = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);
            if (FK_LU_Location_ID > 0)
            {
                Session["ExposureLocation"] = FK_LU_Location_ID;
                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx");
            if (PK_PM_CR_Paint_Inventory > 0)
            {
                if (Request.QueryString["op"] != null)
                {
                    StrOperation = Request.QueryString["op"];
                }
                else
                    StrOperation = "edit";

                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDetailsForView();
                    dvView.Style["display"] = "inline";
                    dvEdit.Style["display"] = "none";
                    btnSave.Visible = false;
                    btnEdit.Visible = (App_Access == AccessType.Administrative_Access);
                    // set attachment details control in readonly mode.
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_CR_PI_Attachments, Convert.ToInt32(PK_PM_CR_Paint_Inventory), "FK_PM_CR_Paint_Inventory", "PK_PM_CR_PI_Attachments", false, 2);
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    SetValidations();
                    // Bind Controls
                    BindDetailsForEdit();
                    dvView.Style["display"] = "none";
                    dvEdit.Style["display"] = "inline";
                    btnSave.Visible = true;
                    btnEdit.Visible = false;
                    // set attachment details control in read/write mode. so user can add or remove attachment as well.
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_CR_PI_Attachments, Convert.ToInt32(PK_PM_CR_Paint_Inventory), "FK_PM_CR_Paint_Inventory", "PK_PM_CR_PI_Attachments", true, 2);
                }
                // bind attachment details to show attachment for current risk profile.
                BindAttachmentDetails();
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                SetValidations();
                BindDropdown();
                BindAttachmentDetails();
                // don't show div for view mode
                btnAuditTrail.Visible = false;
                dvView.Style["display"] = "none";
                dvEdit.Style["display"] = "inline";
                BindGrid();
                btnEdit.Visible = false;
            }
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Binds the grid for Edit
    /// </summary>
    private void BindGrid()
    {
        PM_CR_PI_Inventory objPM_CR_PI_Inventory = new PM_CR_PI_Inventory();
        gvPaintInventory.DataSource = objPM_CR_PI_Inventory.SelectByFK(PK_PM_CR_Paint_Inventory);
        gvPaintInventory.DataBind();
    }

    /// <summary>
    /// Binds the grid for View
    /// </summary>
    private void BindGridView()
    {
        PM_CR_PI_Inventory objPM_CR_PI_Inventory = new PM_CR_PI_Inventory();
        gvPaintInventoryView.DataSource = objPM_CR_PI_Inventory.SelectByFK(PK_PM_CR_Paint_Inventory);
        gvPaintInventoryView.DataBind();
    }

    private void BindDropdown()
    {
        ComboHelper.FillPaintType(new DropDownList[] { drpFK_LU_Paint_Type }, true);
        ComboHelper.FillChemicalFamily(new DropDownList[] { drpFK_LU_Chemical_Family }, true);
        ComboHelper.FillStorageType(new DropDownList[] { drpFK_LU_Storage_Type }, true);
        ComboHelper.FillStorageLocation(new DropDownList[] { drpFK_LU_Storage_Location }, true);
    }

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        BindDropdown();
        PM_CR_Paint_Inventory objPM_CR_Paint_Inventory = new PM_CR_Paint_Inventory(PK_PM_CR_Paint_Inventory);
        if (objPM_CR_Paint_Inventory.FK_LU_Paint_Type != null)
        {
            ListItem lst = drpFK_LU_Paint_Type.Items.FindByValue(objPM_CR_Paint_Inventory.FK_LU_Paint_Type.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_LU_Paint_Type.SelectedValue = objPM_CR_Paint_Inventory.FK_LU_Paint_Type.ToString();

        }
        txtCAS_Number.Text = objPM_CR_Paint_Inventory.CAS_Number;
        rdoPure_Mixture.SelectedValue = objPM_CR_Paint_Inventory.Pure_Mixture;
        txtMixture_Components.Text = objPM_CR_Paint_Inventory.Mixture_Components;
        txtProduct_Identification_Number.Text = objPM_CR_Paint_Inventory.Product_Identification_Number;
        txtProduct_Name.Text = objPM_CR_Paint_Inventory.Product_Name;
        txtManufacturer.Text = objPM_CR_Paint_Inventory.Manufacturer;
        txtSynonyms.Text = objPM_CR_Paint_Inventory.Synonyms;
        txtIssue_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_Paint_Inventory.Issue_Date);
        txtEdition_Number.Text = objPM_CR_Paint_Inventory.Edition_Number;
        if (objPM_CR_Paint_Inventory.FK_LU_Chemical_Family != null)
        {
            ListItem lst = drpFK_LU_Chemical_Family.Items.FindByValue(objPM_CR_Paint_Inventory.FK_LU_Chemical_Family.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_LU_Chemical_Family.SelectedValue = objPM_CR_Paint_Inventory.FK_LU_Chemical_Family.ToString();
        }
        txtMSDS_Number.Text = objPM_CR_Paint_Inventory.MSDS_Number;
        txtEmergency_Overview.Text = objPM_CR_Paint_Inventory.Emergency_Overview;
        txtComposition_Information.Text = objPM_CR_Paint_Inventory.Composition_Information;
        if (objPM_CR_Paint_Inventory.FK_LU_Storage_Type != null)
        {
            ListItem lst = drpFK_LU_Storage_Type.Items.FindByValue(objPM_CR_Paint_Inventory.FK_LU_Storage_Type.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_LU_Storage_Type.SelectedValue = objPM_CR_Paint_Inventory.FK_LU_Storage_Type.ToString();
        }
        if (objPM_CR_Paint_Inventory.FK_LU_Storage_Location != null)
        {
            ListItem lst = drpFK_LU_Storage_Location.Items.FindByValue(objPM_CR_Paint_Inventory.FK_LU_Storage_Location.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_LU_Storage_Location.SelectedValue = objPM_CR_Paint_Inventory.FK_LU_Storage_Location.ToString();
        }
        if (objPM_CR_Paint_Inventory.FK_PM_Compliance_Reporting != null) FK_PM_Compliance_Reporting = Convert.ToDecimal(objPM_CR_Paint_Inventory.FK_PM_Compliance_Reporting);
        txtPaint_Color.Text = objPM_CR_Paint_Inventory.Paint_Color;

        BindGrid();
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
        btnEdit.Visible = true;
        PM_CR_Paint_Inventory objPM_CR_Paint_Inventory = new PM_CR_Paint_Inventory(PK_PM_CR_Paint_Inventory);
        if (objPM_CR_Paint_Inventory.FK_LU_Paint_Type != null)
            lblFK_LU_Paint_Type.Text = new LU_Paint_Type((decimal)objPM_CR_Paint_Inventory.FK_LU_Paint_Type).Fld_Desc;
        lblCAS_Number.Text = objPM_CR_Paint_Inventory.CAS_Number;
        if (objPM_CR_Paint_Inventory.Pure_Mixture != null)
            lblPure_Mixture.Text = objPM_CR_Paint_Inventory.Pure_Mixture == "P" ? "Pure" : "Mixture";

        lblMixture_Components.Text = objPM_CR_Paint_Inventory.Mixture_Components;
        lblProduct_Identification_Number.Text = objPM_CR_Paint_Inventory.Product_Identification_Number;
        lblProduct_Name.Text = objPM_CR_Paint_Inventory.Product_Name;
        lblManufacturer.Text = objPM_CR_Paint_Inventory.Manufacturer;
        lblSynonyms.Text = objPM_CR_Paint_Inventory.Synonyms;
        lblIssue_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_Paint_Inventory.Issue_Date);
        lblEdition_Number.Text = objPM_CR_Paint_Inventory.Edition_Number;
        if (objPM_CR_Paint_Inventory.FK_LU_Chemical_Family != null)
            lblFK_LU_Chemical_Family.Text = new LU_Chemical_Family((decimal)objPM_CR_Paint_Inventory.FK_LU_Chemical_Family).Fld_Desc;
        lblMSDS_Number.Text = objPM_CR_Paint_Inventory.MSDS_Number;
        lblEmergency_Overview.Text = objPM_CR_Paint_Inventory.Emergency_Overview;
        lblComposition_Information.Text = objPM_CR_Paint_Inventory.Composition_Information;
        if (objPM_CR_Paint_Inventory.FK_LU_Storage_Type != null)
            lblFK_LU_Storage_Type.Text = new clsLU_Storage_Type((decimal)objPM_CR_Paint_Inventory.FK_LU_Storage_Type).Fld_Desc;
        if (objPM_CR_Paint_Inventory.FK_LU_Storage_Location != null)
            lblFK_LU_Storage_Location.Text = new clsLU_Storage_Location((decimal)objPM_CR_Paint_Inventory.FK_LU_Storage_Location).Fld_Desc;
        if (objPM_CR_Paint_Inventory.FK_PM_Compliance_Reporting != null)
            FK_PM_Compliance_Reporting = Convert.ToDecimal(new PM_Compliance_Reporting((decimal)objPM_CR_Paint_Inventory.FK_PM_Compliance_Reporting, false).PK_PM_Compliance_Reporting);
        lblPaint_Color.Text = objPM_CR_Paint_Inventory.Paint_Color;
        BindGridView();
    }
    /// <summary>
    /// Performs the insert/update
    /// </summary>
    /// <param name="IsFromAdd"></param>
    private void SavePaintInventory(bool IsFromAdd)
    {
        PM_CR_Paint_Inventory objPM_CR_Paint_Inventory = new PM_CR_Paint_Inventory();
        objPM_CR_Paint_Inventory.PK_PM_CR_Paint_Inventory = PK_PM_CR_Paint_Inventory;
        if (drpFK_LU_Paint_Type.SelectedIndex > 0) objPM_CR_Paint_Inventory.FK_LU_Paint_Type = Convert.ToDecimal(drpFK_LU_Paint_Type.SelectedValue);
        objPM_CR_Paint_Inventory.CAS_Number = txtCAS_Number.Text.Trim();
        objPM_CR_Paint_Inventory.Pure_Mixture = rdoPure_Mixture.SelectedValue;
        objPM_CR_Paint_Inventory.Mixture_Components = txtMixture_Components.Text.Trim();
        objPM_CR_Paint_Inventory.Product_Identification_Number = txtProduct_Identification_Number.Text.Trim();
        objPM_CR_Paint_Inventory.Product_Name = txtProduct_Name.Text.Trim();
        objPM_CR_Paint_Inventory.Manufacturer = txtManufacturer.Text.Trim();
        objPM_CR_Paint_Inventory.Synonyms = txtSynonyms.Text.Trim();
        objPM_CR_Paint_Inventory.Issue_Date = clsGeneral.FormatNullDateToStore(txtIssue_Date.Text);
        objPM_CR_Paint_Inventory.Edition_Number = txtEdition_Number.Text.Trim();
        if (drpFK_LU_Chemical_Family.SelectedIndex > 0) objPM_CR_Paint_Inventory.FK_LU_Chemical_Family = Convert.ToDecimal(drpFK_LU_Chemical_Family.SelectedValue);
        objPM_CR_Paint_Inventory.MSDS_Number = txtMSDS_Number.Text.Trim();
        objPM_CR_Paint_Inventory.Emergency_Overview = txtEmergency_Overview.Text.Trim();
        objPM_CR_Paint_Inventory.Composition_Information = txtComposition_Information.Text.Trim();
        if (drpFK_LU_Storage_Type.SelectedIndex > 0) objPM_CR_Paint_Inventory.FK_LU_Storage_Type = Convert.ToDecimal(drpFK_LU_Storage_Type.SelectedValue);
        if (drpFK_LU_Storage_Location.SelectedIndex > 0) objPM_CR_Paint_Inventory.FK_LU_Storage_Location = Convert.ToDecimal(drpFK_LU_Storage_Location.SelectedValue);
        objPM_CR_Paint_Inventory.FK_PM_Compliance_Reporting = FK_PM_Compliance_Reporting;
        objPM_CR_Paint_Inventory.Paint_Color = txtPaint_Color.Text.Trim();
        objPM_CR_Paint_Inventory.Updated_By = clsSession.UserID;
        objPM_CR_Paint_Inventory.Update_Date = DateTime.Now;
        decimal _retVal;
        if (PK_PM_CR_Paint_Inventory > 0)
        {
            objPM_CR_Paint_Inventory.Update();

            if (!IsFromAdd)
            {
                // add the attachment 
                Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_CR_Paint_Inventory);
                Attachment.FK_Field_Name = "FK_PM_CR_Paint_Inventory";
                Attachment.Add(clsGeneral.Pollution_Tables.PM_CR_PI_Attachments);
                Response.Redirect("Compliance_Reporting_Paint_Inventory.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_CR_Paint_Inventory)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
            }
        }
        else
        {
            _retVal = objPM_CR_Paint_Inventory.Insert();
            PK_PM_CR_Paint_Inventory = _retVal;

            if (!IsFromAdd)
            {
                // add the attachment 
                Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_CR_Paint_Inventory);
                Attachment.FK_Field_Name = "FK_PM_CR_Paint_Inventory";
                Attachment.Add(clsGeneral.Pollution_Tables.PM_CR_PI_Attachments);
                Response.Redirect("Compliance_Reporting_Paint_Inventory.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_CR_Paint_Inventory)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
            }
        }
    }

    #endregion

    #region Control Events

    /// <summary>
    /// Handles Event when Paint Inventory add is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbAddPaintInventory_Click(object sender, EventArgs e)
    {
        SavePaintInventory(true);
        Response.Redirect("PM_CR_Paint_Inventory.aspx?fid=" + Encryption.Encrypt(Convert.ToString(PK_PM_CR_Paint_Inventory)) + "&fid2=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));

    }

    /// <summary>
    /// Redirects from the view to edit state
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (PK_PM_CR_Paint_Inventory > 0)
            Response.Redirect("Compliance_Reporting_Paint_Inventory.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_CR_Paint_Inventory)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
    }

    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SavePaintInventory(false);
    }
    /// <summary>
    /// Directs back to the parent page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (StrOperation == "view")
            Response.Redirect("Pollution.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("3"));
        else
            Response.Redirect("Pollution.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("3"));
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
        if (PK_PM_CR_Paint_Inventory > 0)
        {
            SavePaintInventory(true);
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_CR_Paint_Inventory);
            Attachment.FK_Field_Name = "FK_PM_CR_Paint_Inventory";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_CR_PI_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Paint Inventory details first');ShowPanel(2);", true);
        }
    }


    #endregion

    #region GridEvents

    /// <summary>
    /// Handles gvPaintInventory grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPaintInventory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        if (e.CommandName == "gvEdit")
        {
            Response.Redirect("PM_CR_Paint_Inventory.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(e.CommandArgument)) + "&fid=" + Encryption.Encrypt(Convert.ToString(PK_PM_CR_Paint_Inventory)) + "&fid2=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
        }
        else if (e.CommandName == "Remove")
        {
            index = Convert.ToInt32(e.CommandArgument);
            if (index > 0)
            {
                PM_CR_PI_Inventory.DeleteByPK(index);
            }
            BindGrid();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
    }
    /// <summary>
    /// Handles gvPaintInventory grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPaintInventoryView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "gvEdit")
        {
            Response.Redirect("PM_CR_Paint_Inventory.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(e.CommandArgument)) + "&fid=" + Encryption.Encrypt(Convert.ToString(PK_PM_CR_Paint_Inventory)) + "&fid2=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
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

        

        DataTable dtFields = clsScreen_Validators.SelectByScreen(158).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Paint Type": strCtrlsIDs += drpFK_LU_Paint_Type.ClientID + ","; strMessages += "Please select [Paint Inventory]/Paint Type" + ","; Span1.Style["display"] = "inline-block"; break;
                case "CAS Number": strCtrlsIDs += txtCAS_Number.ClientID + ","; strMessages += "Please enter [Paint Inventory]/CAS Number" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Paint Color": strCtrlsIDs += txtPaint_Color.ClientID + ","; strMessages += "Please enter [Paint Inventory]/Paint Color" + ","; Span3.Style["display"] = "inline-block"; break;
                case "If Mixture, List Components": strCtrlsIDs += txtMixture_Components.ClientID + ","; strMessages += "Please enter [Paint Inventory]/If Mixture; List Components" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Product Identification Number": strCtrlsIDs += txtProduct_Identification_Number.ClientID + ","; strMessages += "Please enter [Paint Inventory]/Product Identification Number" + ","; Span5.Style["display"] = "inline-block"; break;
                case "Product Name": strCtrlsIDs += txtProduct_Name.ClientID + ","; strMessages += "Please enter [Paint Inventory]/Product Name" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Manufacturer": strCtrlsIDs += txtManufacturer.ClientID + ","; strMessages += "Please enter [Paint Inventory]/Manufacturer" + ","; Span7.Style["display"] = "inline-block"; break;
                case "Synonyms": strCtrlsIDs += txtSynonyms.ClientID + ","; strMessages += "Please enter [Paint Inventory]/Synonyms" + ","; Span8.Style["display"] = "inline-block"; break;
                case "Issue Date": strCtrlsIDs += txtIssue_Date.ClientID + ","; strMessages += "Please enter [Paint Inventory]/Issue Date" + ","; Span9.Style["display"] = "inline-block"; break;
                case "Edition Number": strCtrlsIDs += txtEdition_Number.ClientID + ","; strMessages += "Please enter [Paint Inventory]/Edition Number" + ","; Span10.Style["display"] = "inline-block"; break;
                case "Chemical Family": strCtrlsIDs += drpFK_LU_Chemical_Family.ClientID + ","; strMessages += "Please select [Paint Inventory]/Chemical Family" + ","; Span11.Style["display"] = "inline-block"; break;
                case "MSDS Number": strCtrlsIDs += txtMSDS_Number.ClientID + ","; strMessages += "Please enter [Paint Inventory]/MSDS Number" + ","; Span12.Style["display"] = "inline-block"; break;
                case "Emergency Overview": strCtrlsIDs += txtEmergency_Overview.ClientID + ","; strMessages += "Please enter [Paint Inventory]/Emergency Overview" + ","; Span13.Style["display"] = "inline-block"; break;
                case "Composition Information": strCtrlsIDs += txtComposition_Information.ClientID + ","; strMessages += "Please enter [Paint Inventory]/Composition Information" + ","; Span14.Style["display"] = "inline-block"; break;
                case "Storage Type": strCtrlsIDs += drpFK_LU_Storage_Type.ClientID + ","; strMessages += "Please select [Paint Inventory]/Storage Type" + ","; Span15.Style["display"] = "inline-block"; break;
                case "Storage Location": strCtrlsIDs += drpFK_LU_Storage_Location.ClientID + ","; strMessages += "Please select [Paint Inventory]/Storage Location" + ","; Span16.Style["display"] = "inline-block"; break;
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