using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Pollution_PM_CR_Paint_Inventory : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes foreign key for PM_CR_Paint_Inventory
    /// </summary>
    public decimal FK_PM_CR_Paint_Inventory
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_PM_CR_Paint_Inventory"]);
        }
        set { ViewState["FK_PM_CR_Paint_Inventory"] = value; }
    }
    /// <summary>
    /// Denotes foreign key for PM_CR_Paint_Inventory
    /// </summary>
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
        get { return Convert.ToDecimal(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_CR_PI_Inventory
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_CR_PI_Inventory"]);
        }
        set { ViewState["PK_PM_CR_PI_Inventory"] = value; }
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
    /// Handles Page Load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Pollution);
        if (!Page.IsPostBack)
        {            
            PK_PM_CR_PI_Inventory = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_PM_CR_Paint_Inventory = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);
            FK_PM_Site_Information = clsGeneral.GetQueryStringID(Request.QueryString["fid2"]);
            FK_LU_Location_ID = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);

            if (FK_LU_Location_ID > 0)
            {
                Session["ExposureLocation"] = FK_LU_Location_ID;
                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx");

            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            if (PK_PM_CR_PI_Inventory > 0)
            {
                
                StrOperation = Convert.ToString(Request.QueryString["op"]);
                //PK_Executive_Risk_Contacts = Convert.ToInt32(Request.QueryString["id"]);
                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDropdowns();
                    BindDetailsForView();
                    btnEdit.Visible = (App_Access == AccessType.Administrative_Access);
                    // set attachment details control in readonly mode.
                    //AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Executive_Risk_Contacts, PK_Executive_Risk_Contacts, false, 2);
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    SetValidations();
                    // Bind Controls
                    BindDropdowns();
                    BindDetailsForEdit();
                    // set attachment details control in read/write mode. so user can add or remove attachment as well.
                    //AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Executive_Risk_Contacts, PK_Executive_Risk_Contacts, true, 2);
                }
                // bind attachment details to show attachment for current risk profile.
                //BindAttachmentDetails();
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                SetValidations();
                btnAuditTrail.Visible = false;
                // disable Add Attachment button
                btnEdit.Visible = false;
                BindDropdowns();
                // don't show div for view mode
                dvView.Style["display"] = "none";
                if (FK_PM_CR_Paint_Inventory > 0)
                    btnBack.Visible = true;
                else
                    btnBack.Visible = false;
            }
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Binds all dropdowns
    /// </summary>
    private void BindDropdowns()
    {
        ComboHelper.FillLU_Units(new DropDownList[] { drpFK_LU_Units }, true);
    }
    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        PM_CR_PI_Inventory objPM_CR_PI_Inventory = new PM_CR_PI_Inventory(PK_PM_CR_PI_Inventory);
        txtSupplier.Text = objPM_CR_PI_Inventory.Supplier;
        txtDate_Purchased.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_PI_Inventory.Date_Purchased);
        txtAmount_Purchased.Text = clsGeneral.GetStringValue(objPM_CR_PI_Inventory.Amount_Purchased);
        if (objPM_CR_PI_Inventory.FK_LU_Units != null)
        {
            ListItem lst = drpFK_LU_Units.Items.FindByValue(objPM_CR_PI_Inventory.FK_LU_Units.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_LU_Units.SelectedValue = objPM_CR_PI_Inventory.FK_LU_Units.ToString();
        }
        txtStart_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_PI_Inventory.Start_Date);
        txtEnd_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_PI_Inventory.End_Date);
        txtAmount_Used.Text = clsGeneral.GetStringValue(objPM_CR_PI_Inventory.Amount_Used);
        txtEnding_Inventory.Text = clsGeneral.GetStringValue(objPM_CR_PI_Inventory.Ending_Inventory);
        if (objPM_CR_PI_Inventory.FK_PM_CR_Paint_Inventory != null) 
            FK_PM_CR_Paint_Inventory = Convert.ToDecimal(objPM_CR_PI_Inventory.FK_PM_CR_Paint_Inventory);
        if (FK_PM_CR_Paint_Inventory > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;
                
    }
    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        btnEdit.Visible = true;
        btnSave.Visible = false;
        PM_CR_PI_Inventory objPM_CR_PI_Inventory = new PM_CR_PI_Inventory(PK_PM_CR_PI_Inventory);
        lblSupplier.Text = objPM_CR_PI_Inventory.Supplier;
        lblDate_Purchased.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_PI_Inventory.Date_Purchased);
        lblAmount_Purchased.Text = clsGeneral.GetStringValue(objPM_CR_PI_Inventory.Amount_Purchased);
        if (objPM_CR_PI_Inventory.FK_LU_Units != null)
            lblFK_LU_Units.Text = new LU_Units((decimal)objPM_CR_PI_Inventory.FK_LU_Units).Fld_Desc;
        lblStart_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_PI_Inventory.Start_Date);
        lblEnd_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_PI_Inventory.End_Date);
        lblAmount_Used.Text = clsGeneral.GetStringValue(objPM_CR_PI_Inventory.Amount_Used);
        lblEnding_Inventory.Text = clsGeneral.GetStringValue(objPM_CR_PI_Inventory.Ending_Inventory);
        if (objPM_CR_PI_Inventory.FK_PM_CR_Paint_Inventory != null) FK_PM_CR_Paint_Inventory = Convert.ToDecimal(objPM_CR_PI_Inventory.FK_PM_CR_Paint_Inventory);
        if (FK_PM_CR_Paint_Inventory > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;
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
        PM_CR_PI_Inventory objPM_CR_PI_Inventory = new PM_CR_PI_Inventory();
        objPM_CR_PI_Inventory.PK_PM_CR_PI_Inventory = PK_PM_CR_PI_Inventory;
        objPM_CR_PI_Inventory.Supplier = txtSupplier.Text.Trim();
        objPM_CR_PI_Inventory.Date_Purchased = clsGeneral.FormatNullDateToStore(txtDate_Purchased.Text);
        if (txtAmount_Purchased.Text != "") objPM_CR_PI_Inventory.Amount_Purchased = clsGeneral.GetDecimalValue(txtAmount_Purchased);
        if (drpFK_LU_Units.SelectedIndex > 0) objPM_CR_PI_Inventory.FK_LU_Units = Convert.ToDecimal(drpFK_LU_Units.SelectedValue);
        objPM_CR_PI_Inventory.Start_Date = clsGeneral.FormatNullDateToStore(txtStart_Date.Text);
        objPM_CR_PI_Inventory.End_Date = clsGeneral.FormatNullDateToStore(txtEnd_Date.Text);
        if (txtAmount_Used.Text != "") objPM_CR_PI_Inventory.Amount_Used = clsGeneral.GetDecimalValue(txtAmount_Used);
        if (txtEnding_Inventory.Text != "") objPM_CR_PI_Inventory.Ending_Inventory = clsGeneral.GetDecimalValue(txtEnding_Inventory);
        objPM_CR_PI_Inventory.FK_PM_CR_Paint_Inventory = FK_PM_CR_Paint_Inventory;
        objPM_CR_PI_Inventory.Update_Date = DateTime.Now;
        objPM_CR_PI_Inventory.Updated_By = clsSession.UserID;

        decimal _retVal;
        if (PK_PM_CR_PI_Inventory > 0)
            _retVal = objPM_CR_PI_Inventory.Update();
        else
            _retVal = objPM_CR_PI_Inventory.Insert();

        if (_retVal == -2)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Paint Inventory that you are trying to add already exists.');ShowPanel(1);", true);
            return;
        }
        Response.Redirect("PM_CR_Paint_Inventory.aspx?id=" + Encryption.Encrypt(_retVal.ToString()) + "&op=view&fid2" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_CR_Paint_Inventory)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
    }
    /// <summary>
    /// Handles Edit button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("PM_CR_Paint_Inventory.aspx?id=" + Encryption.Encrypt(PK_PM_CR_PI_Inventory.ToString()) + "&op=edit&fid2" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_CR_Paint_Inventory)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
    }
    /// <summary>
    /// Handles Back button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (StrOperation == "view")
            Response.Redirect("Compliance_Reporting_Paint_Inventory.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_CR_Paint_Inventory)) + "&fid" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
        else
            Response.Redirect("Compliance_Reporting_Paint_Inventory.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_CR_Paint_Inventory)) + "&fid" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
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

        DataTable dtFields = clsScreen_Validators.SelectByScreen(159).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Supplier": strCtrlsIDs += txtSupplier.ClientID + ","; strMessages += "Please enter [Paint Inventory]/Supplier" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Date Purchased": strCtrlsIDs += txtDate_Purchased.ClientID + ","; strMessages += "Please enter [Paint Inventory]/Date Purchased" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Amount Purchased": strCtrlsIDs += txtAmount_Purchased.ClientID + ","; strMessages += "Please enter [Paint Inventory]/Amount Purchased" + ","; Span3.Style["display"] = "inline-block"; break;
                case "Units": strCtrlsIDs += drpFK_LU_Units.ClientID + ","; strMessages += "Please select [Paint Inventory]/Units" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Start Date": strCtrlsIDs += txtStart_Date.ClientID + ","; strMessages += "Please enter [Paint Inventory]/Start Date" + ","; Span5.Style["display"] = "inline-block"; break;
                case "End Date": strCtrlsIDs += txtEnd_Date.ClientID + ","; strMessages += "Please enter [Paint Inventory]/End Date" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Amount Used": strCtrlsIDs += txtAmount_Used.ClientID + ","; strMessages += "Please enter [Paint Inventory]/Amount Used" + ","; Span7.Style["display"] = "inline-block"; break;
                case "Ending Inventory": strCtrlsIDs += txtEnding_Inventory.ClientID + ","; strMessages += "Please enter [Paint Inventory]/Ending Inventory" + ","; Span8.Style["display"] = "inline-block"; break;
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