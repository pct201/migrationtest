using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Pollution_Site_Information_FacilityId : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_SI_Faciltiy_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_SI_Faciltiy_ID"]);
        }
        set { ViewState["PK_PM_SI_Faciltiy_ID"] = value; }
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
            PK_PM_SI_Faciltiy_ID = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
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
            
            if (PK_PM_SI_Faciltiy_ID > 0)
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
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_SI_FI_Attachments, Convert.ToInt32(PK_PM_SI_Faciltiy_ID), "FK_PM_SI_Facility_Id", "PK_PM_SI_FI_Attachments", false, 2);
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
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_SI_FI_Attachments, Convert.ToInt32(PK_PM_SI_Faciltiy_ID), "FK_PM_SI_Facility_Id", "PK_PM_SI_FI_Attachments", true, 2);
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
                btnEdit.Visible = false;
                BindAttachmentDetails();
                // don't show div for view mode
                dvView.Style["display"] = "none";
                dvEdit.Style["display"] = "inline";
                btnAuditTrail.Visible = false;
            }
        }
    }
    #endregion

    #region Methods

    private void BindDropdown()
    {
        ComboHelper.FillAgency(new DropDownList[] { drpFK_LU_Agency }, true);
        ComboHelper.FillMedia(new DropDownList[] { drpFK_LU_Media }, true);
        ComboHelper.FillState(new DropDownList[] { drpFK_State }, 0, true);
    }

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        btnBack.Visible = true;
        btnSave.Visible = true;
        BindDropdown();
        PM_SI_Facility_Id objPM_SI_Facility_Id = new PM_SI_Facility_Id(PK_PM_SI_Faciltiy_ID);
        if (objPM_SI_Facility_Id.FK_LU_Agency != null)
        {
            ListItem lst = drpFK_LU_Agency.Items.FindByValue(objPM_SI_Facility_Id.FK_LU_Agency.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_LU_Agency.SelectedValue = objPM_SI_Facility_Id.FK_LU_Agency.ToString();
        }
        if (objPM_SI_Facility_Id.FK_LU_Media != null)
        {
            ListItem lst = drpFK_LU_Media.Items.FindByValue(objPM_SI_Facility_Id.FK_LU_Media.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_LU_Media.SelectedValue = objPM_SI_Facility_Id.FK_LU_Media.ToString();
        }
        txtIdentification_Number.Text = objPM_SI_Facility_Id.Identification_Number;
        txtContact_Name.Text = objPM_SI_Facility_Id.Contact_Name;
        txtAddress_1.Text = objPM_SI_Facility_Id.Address_1;
        txtAddress_2.Text = objPM_SI_Facility_Id.Address_2;
        txtCity.Text = objPM_SI_Facility_Id.City;
        if (objPM_SI_Facility_Id.FK_State != null)
        {
            ListItem lst = drpFK_State.Items.FindByValue(objPM_SI_Facility_Id.FK_State.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_State.SelectedValue = objPM_SI_Facility_Id.FK_State.ToString();
        }
        txtZip_Code.Text = objPM_SI_Facility_Id.Zip_Code;
        txtTelephone.Text = objPM_SI_Facility_Id.Telephone;
        if (objPM_SI_Facility_Id.FK_PM_Site_Information != null)
            FK_PM_Site_Information = (decimal)objPM_SI_Facility_Id.FK_PM_Site_Information;

    }


    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        lblError.Visible = false;
        btnEdit.Visible = true;
        btnSave.Visible = false;
        btnBack.Visible = true;
        PM_SI_Facility_Id objPM_SI_Facility_Id = new PM_SI_Facility_Id(PK_PM_SI_Faciltiy_ID);
        if (objPM_SI_Facility_Id.FK_LU_Agency != null)
            lblFK_LU_Agency.Text = new LU_Agency((decimal)objPM_SI_Facility_Id.FK_LU_Agency).Fld_Desc;
        if (objPM_SI_Facility_Id.FK_LU_Media != null)
            lblFK_LU_Media.Text = new clsLU_Media((decimal)objPM_SI_Facility_Id.FK_LU_Media).Fld_Desc;
        lblIdentification_Number.Text = objPM_SI_Facility_Id.Identification_Number;
        lblContact_Name.Text = objPM_SI_Facility_Id.Contact_Name;
        lblAddress_1.Text = objPM_SI_Facility_Id.Address_1;
        lblAddress_2.Text = objPM_SI_Facility_Id.Address_2;
        lblCity.Text = objPM_SI_Facility_Id.City;
        if (objPM_SI_Facility_Id.FK_State != null)
            lblFK_State.Text = new State((decimal)objPM_SI_Facility_Id.FK_State).FLD_state;
        lblZip_Code.Text = objPM_SI_Facility_Id.Zip_Code;
        lblTelephone.Text = objPM_SI_Facility_Id.Telephone;

    }

    #endregion

    #region Control Events
    /// <summary>
    /// Redirects from the view to edit state
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (PK_PM_SI_Faciltiy_ID > 0)
            Response.Redirect("Site_Information_FacilityId.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_SI_Faciltiy_ID)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)));
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

    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PM_SI_Facility_Id objPM_SI_Facility_Id = new PM_SI_Facility_Id();
        objPM_SI_Facility_Id.PK_PM_SI_Faciltiy_ID = PK_PM_SI_Faciltiy_ID;
        if (drpFK_LU_Agency.SelectedIndex > 0) objPM_SI_Facility_Id.FK_LU_Agency = Convert.ToDecimal(drpFK_LU_Agency.SelectedValue);
        if (drpFK_LU_Media.SelectedIndex > 0) objPM_SI_Facility_Id.FK_LU_Media = Convert.ToDecimal(drpFK_LU_Media.SelectedValue);
        objPM_SI_Facility_Id.Identification_Number = txtIdentification_Number.Text.Trim();
        objPM_SI_Facility_Id.Contact_Name = txtContact_Name.Text.Trim();
        objPM_SI_Facility_Id.Address_1 = txtAddress_1.Text.Trim();
        objPM_SI_Facility_Id.Address_2 = txtAddress_2.Text.Trim();
        objPM_SI_Facility_Id.City = txtCity.Text.Trim();
        if (drpFK_State.SelectedIndex > 0) objPM_SI_Facility_Id.FK_State = Convert.ToDecimal(drpFK_State.SelectedValue);
        objPM_SI_Facility_Id.Zip_Code = txtZip_Code.Text.Trim();
        objPM_SI_Facility_Id.Telephone = txtTelephone.Text.Trim();
        objPM_SI_Facility_Id.FK_PM_Site_Information = FK_PM_Site_Information;
        objPM_SI_Facility_Id.FK_LU_Location_ID = FK_LU_Location_ID;
        objPM_SI_Facility_Id.Updated_By = clsSession.UserID;
        objPM_SI_Facility_Id.Updated_Date = DateTime.Now;
        decimal _retVal;
        if (PK_PM_SI_Faciltiy_ID > 0)
        {
            _retVal = objPM_SI_Facility_Id.Update();
            if (_retVal == -2)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The selected Agency, Media, Identification Number and Sonic Location Code already exist in the Facility ID table');ShowPanel(1);", true);
                btnEdit.Visible = false;
            }
            else
            {
                // add the attachment 
                Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_SI_Faciltiy_ID);
                Attachment.FK_Field_Name = "FK_PM_SI_Facility_ID";
                Attachment.Add(clsGeneral.Pollution_Tables.PM_SI_FI_Attachments);
                Response.Redirect("Site_Information_FacilityId.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_SI_Faciltiy_ID)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)));
            }
        }
        else
        {
            _retVal = objPM_SI_Facility_Id.Insert();
            if (_retVal == -2)
            {                
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The selected Agency, Media, Identification Number and Sonic Location Code already exist in the Facility ID table');ShowPanel(1);", true);                
                btnEdit.Visible = false;
            }
            else
            {
                PK_PM_SI_Faciltiy_ID = _retVal;
                // add the attachment 
                Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_SI_Faciltiy_ID);
                Attachment.FK_Field_Name = "FK_PM_SI_Facility_ID";
                Attachment.Add(clsGeneral.Pollution_Tables.PM_SI_FI_Attachments);
                Response.Redirect("Site_Information_FacilityId.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_SI_Faciltiy_ID)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)));
            }
        }

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
        if (PK_PM_SI_Faciltiy_ID > 0)
        {
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_SI_Faciltiy_ID);
            Attachment.FK_Field_Name = "FK_PM_SI_Facility_ID";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_SI_FI_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Facility Id details first.');ShowPanel(2);", true);
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

        DataTable dtFields = clsScreen_Validators.SelectByScreen(155).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Agency": strCtrlsIDs += drpFK_LU_Agency.ClientID + ","; strMessages += "Please select [Facility Id]/Agency" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Media": strCtrlsIDs += drpFK_LU_Media.ClientID + ","; strMessages += "Please select [Facility Id]/Media" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Identification Number": strCtrlsIDs += txtIdentification_Number.ClientID + ","; strMessages += "Please enter [Facility Id]/Identification Number" + ","; Span3.Style["display"] = "inline-block"; break;
                case "Contact Name": strCtrlsIDs += txtContact_Name.ClientID + ","; strMessages += "Please enter [Facility Id]/Contact Name" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Address 1": strCtrlsIDs += txtAddress_1.ClientID + ","; strMessages += "Please enter [Facility Id]/Address 1" + ","; Span5.Style["display"] = "inline-block"; break;
                case "Address 2": strCtrlsIDs += txtAddress_2.ClientID + ","; strMessages += "Please enter [Facility Id]/Address 2" + ","; Span6.Style["display"] = "inline-block"; break;
                case "City": strCtrlsIDs += txtCity.ClientID + ","; strMessages += "Please enter [Facility Id]/City" + ","; Span7.Style["display"] = "inline-block"; break;
                case "State": strCtrlsIDs += drpFK_State.ClientID + ","; strMessages += "Please select [Facility Id]/State" + ","; Span8.Style["display"] = "inline-block"; break;
                case "Zip Code": strCtrlsIDs += txtZip_Code.ClientID + ","; strMessages += "Please enter [Facility Id]/Zip Code" + ","; Span9.Style["display"] = "inline-block"; break;
                case "Telephone": strCtrlsIDs += txtTelephone.ClientID + ","; strMessages += "Please enter [Facility Id]/Telephone" + ","; Span10.Style["display"] = "inline-block"; break;
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