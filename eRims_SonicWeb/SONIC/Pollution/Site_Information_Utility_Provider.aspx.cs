using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Pollution_Site_Information_Utility_Provider : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_SI_Utility_Provider
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_SI_Utility_Provider"]);
        }
        set { ViewState["PK_PM_SI_Utility_Provider"] = value; }
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
            PK_PM_SI_Utility_Provider = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
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
            if (PK_PM_SI_Utility_Provider > 0)
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
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_SI_UP_Attachments, Convert.ToInt32(PK_PM_SI_Utility_Provider), "FK_PM_SI_Utility_Provider", "PK_PM_SI_UP_Attachments", false, 2);
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
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_SI_UP_Attachments, Convert.ToInt32(PK_PM_SI_Utility_Provider), "FK_PM_SI_Utility_Provider", "PK_PM_SI_UP_Attachments", true, 2);
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
                // disable Add Attachment button

                 BindAttachmentDetails();
                // don't show div for view mode
                dvView.Style["display"] = "none";
                dvEdit.Style["display"] = "inline";
                btnEdit.Visible = false;
                btnSave.Visible = true;
                btnAuditTrail.Visible = false;
            }
            
        }
    }
    #endregion

    #region Methods



    private void BindDropdown()
    {
        ComboHelper.FillUtilityType(new DropDownList[] { drpFK_LU_Utility_Type }, true);
        ComboHelper.FillState(new DropDownList[] { drpFK_State }, 0, true);
    }

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnBack.Visible = true;
        btnSave.Visible = true;
        btnEdit.Visible = false;
        BindDropdown();
        PM_SI_Utility_Provider objPM_SI_Utility_Provider = new PM_SI_Utility_Provider(PK_PM_SI_Utility_Provider);
        if (objPM_SI_Utility_Provider.FK_LU_Utility_Type != null)
        {
            ListItem lst = drpFK_LU_Utility_Type.Items.FindByValue(objPM_SI_Utility_Provider.FK_LU_Utility_Type.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_LU_Utility_Type.SelectedValue = objPM_SI_Utility_Provider.FK_LU_Utility_Type.ToString();

        }
        txtUtility_Name.Text = objPM_SI_Utility_Provider.Utility_Name;
        txtTelephone.Text = objPM_SI_Utility_Provider.Telephone;
        txtContact_Name.Text = objPM_SI_Utility_Provider.Contact_Name;
        txtAddress_1.Text = objPM_SI_Utility_Provider.Address_1;
        txtAddress_2.Text = objPM_SI_Utility_Provider.Address_2;
        txtCity.Text = objPM_SI_Utility_Provider.City;
        if (objPM_SI_Utility_Provider.FK_PM_Site_Information != null)
            FK_PM_Site_Information = Convert.ToDecimal(objPM_SI_Utility_Provider.FK_PM_Site_Information);
        else
            FK_PM_Site_Information = 0;

        if (objPM_SI_Utility_Provider.FK_State != null)
        {
            ListItem lst = drpFK_State.Items.FindByValue(objPM_SI_Utility_Provider.FK_State.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_State.SelectedValue = objPM_SI_Utility_Provider.FK_State.ToString();
        }
        txtZip_Code.Text = objPM_SI_Utility_Provider.Zip_Code;
        txtContact_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_SI_Utility_Provider.Contact_Start_Date);
        txtContact_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_SI_Utility_Provider.Contact_End_Date);

    }


    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        btnSave.Visible = false;
        btnBack.Visible = true;
        btnEdit.Visible = true;
        lblError.Visible = false;
        PM_SI_Utility_Provider objPM_SI_Utility_Provider = new PM_SI_Utility_Provider(PK_PM_SI_Utility_Provider);
        if (objPM_SI_Utility_Provider.FK_LU_Utility_Type != null)
            lblFK_LU_Utility_Type.Text = new LU_Utility_Type((decimal)objPM_SI_Utility_Provider.FK_LU_Utility_Type).Fld_Desc;
        lblUtility_Name.Text = objPM_SI_Utility_Provider.Utility_Name;
        lblTelephone.Text = objPM_SI_Utility_Provider.Telephone;
        lblContact_Name.Text = objPM_SI_Utility_Provider.Contact_Name;
        lblAddress_1.Text = objPM_SI_Utility_Provider.Address_1;
        lblAddress_2.Text = objPM_SI_Utility_Provider.Address_2;
        lblCity.Text = objPM_SI_Utility_Provider.City;
        if (objPM_SI_Utility_Provider.FK_State != null)
            lblFK_State.Text = new State((decimal)objPM_SI_Utility_Provider.FK_State).FLD_state;
        lblZip_Code.Text = objPM_SI_Utility_Provider.Zip_Code;
        lblContact_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_SI_Utility_Provider.Contact_Start_Date);
        lblContact_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_SI_Utility_Provider.Contact_End_Date);
    }
    #endregion

    #region Control Events

    /// <summary>
    /// Button Edit Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (PK_PM_SI_Utility_Provider > 0)
            Response.Redirect("Site_Information_Utility_Provider.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_SI_Utility_Provider)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)));
    }

    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PM_SI_Utility_Provider objPM_SI_Utility_Provider = new PM_SI_Utility_Provider();
        objPM_SI_Utility_Provider.PK_PM_SI_Utility_Provider = PK_PM_SI_Utility_Provider;
        if (drpFK_LU_Utility_Type.SelectedIndex > 0) objPM_SI_Utility_Provider.FK_LU_Utility_Type = Convert.ToDecimal(drpFK_LU_Utility_Type.SelectedValue);
        objPM_SI_Utility_Provider.Utility_Name = txtUtility_Name.Text.Trim();
        objPM_SI_Utility_Provider.Telephone = txtTelephone.Text.Trim();
        objPM_SI_Utility_Provider.Contact_Name = txtContact_Name.Text.Trim();
        objPM_SI_Utility_Provider.Address_1 = txtAddress_1.Text.Trim();
        objPM_SI_Utility_Provider.Address_2 = txtAddress_2.Text.Trim();
        objPM_SI_Utility_Provider.City = txtCity.Text.Trim();
        if (drpFK_State.SelectedIndex > 0) objPM_SI_Utility_Provider.FK_State = Convert.ToDecimal(drpFK_State.SelectedValue);
        objPM_SI_Utility_Provider.Zip_Code = txtZip_Code.Text.Trim();
        if (FK_PM_Site_Information > 0) objPM_SI_Utility_Provider.FK_PM_Site_Information = FK_PM_Site_Information;
        objPM_SI_Utility_Provider.Contact_Start_Date = clsGeneral.FormatNullDateToStore(txtContact_Start_Date.Text);
        objPM_SI_Utility_Provider.Contact_End_Date = clsGeneral.FormatNullDateToStore(txtContact_End_Date.Text);
        objPM_SI_Utility_Provider.Update_Date = DateTime.Now;
        objPM_SI_Utility_Provider.FK_LU_Location_ID = FK_LU_Location_ID;
        objPM_SI_Utility_Provider.Updated_By = clsSession.UserID;
        objPM_SI_Utility_Provider.Update_Date = DateTime.Now;
        decimal _retval;
        if (PK_PM_SI_Utility_Provider > 0)
        {
            _retval = objPM_SI_Utility_Provider.Update();
            if (_retval == -2)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The selected Utility Type and Sonic Location Code already exist in the Utility Provider table');ShowPanel(1);", true);
            }
            else
            {
                Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_SI_Utility_Provider);
                Attachment.FK_Field_Name = "FK_PM_SI_Utility_Provider";
                Attachment.Add(clsGeneral.Pollution_Tables.PM_SI_UP_Attachments);
                Response.Redirect("Site_Information_Utility_Provider.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_SI_Utility_Provider)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)));
            }
        }
        else
        {
            _retval = objPM_SI_Utility_Provider.Insert();
            if (_retval == -2)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The selected Utility Type and Sonic Location Code already exist in the Utility Provider table');ShowPanel(1);", true);
            }
            else
            {
                PK_PM_SI_Utility_Provider = _retval;
                Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_SI_Utility_Provider);
                Attachment.FK_Field_Name = "FK_PM_SI_Utility_Provider";
                Attachment.Add(clsGeneral.Pollution_Tables.PM_SI_UP_Attachments);
                Response.Redirect("Site_Information_Utility_Provider.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_SI_Utility_Provider)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)));
            }
        }

    }
    /// <summary>
    /// Directs back to the parent page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (StrOperation == "view")
            Response.Redirect("Pollution.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("1"));            
        else
            Response.Redirect("Pollution.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("1"));
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
        if (PK_PM_SI_Utility_Provider > 0)
        {
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_SI_Utility_Provider);
            Attachment.FK_Field_Name = "FK_PM_SI_Utility_Provider";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_SI_UP_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Utility Provider details first');ShowPanel(2);", true);
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

        DataTable dtFields = clsScreen_Validators.SelectByScreen(154).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Utility Type": strCtrlsIDs += drpFK_LU_Utility_Type.ClientID + ","; strMessages += "Please select [Utility Provider]/Utility Type" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Utility Name": strCtrlsIDs += txtUtility_Name.ClientID + ","; strMessages += "Please enter [Utility Provider]/Utility Name" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Telephone": strCtrlsIDs += txtTelephone.ClientID + ","; strMessages += "Please enter [Utility Provider]/Telephone" + ","; Span3.Style["display"] = "inline-block"; break;
                case "Contact Name": strCtrlsIDs += txtContact_Name.ClientID + ","; strMessages += "Please enter [Utility Provider]/Contact Name" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Address 1": strCtrlsIDs += txtAddress_1.ClientID + ","; strMessages += "Please enter [Utility Provider]/Address 1" + ","; Span5.Style["display"] = "inline-block"; break;
                case "Address 2": strCtrlsIDs += txtAddress_2.ClientID + ","; strMessages += "Please enter [Utility Provider]/Address 2" + ","; Span6.Style["display"] = "inline-block"; break;
                case "City": strCtrlsIDs += txtCity.ClientID + ","; strMessages += "Please enter [Utility Provider]/City" + ","; Span7.Style["display"] = "inline-block"; break;
                case "State": strCtrlsIDs += drpFK_State.ClientID + ","; strMessages += "Please select [Utility Provider]/State" + ","; Span8.Style["display"] = "inline-block"; break;
                case "Zip Code": strCtrlsIDs += txtZip_Code.ClientID + ","; strMessages += "Please enter [Utility Provider]/Zip Code" + ","; Span9.Style["display"] = "inline-block"; break;
                case "Contract Start Date": strCtrlsIDs += txtContact_Start_Date.ClientID + ","; strMessages += "Please enter [Utility Provider]/Contract Start Date" + ","; Span10.Style["display"] = "inline-block"; break;
                case "Contract End Date": strCtrlsIDs += txtContact_End_Date.ClientID + ","; strMessages += "Please enter [Utility Provider]/Contract End Date" + ","; Span11.Style["display"] = "inline-block"; break;
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