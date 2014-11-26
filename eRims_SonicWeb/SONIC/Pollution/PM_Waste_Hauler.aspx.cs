using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Pollution_PM_Waste_Hauler : clsBasePage
{
    #region Properties
    public decimal FK_PM_Site_Information
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_PM_Site_Information"]);
        }
        set { ViewState["FK_PM_Site_Information"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Waste_Hauler
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Waste_Hauler"]);
        }
        set { ViewState["PK_PM_Waste_Hauler"] = value; }
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
    /// Denotes foriegn key for Location record
    /// </summary>
    public decimal FK_LU_Location_ID
    {
        get { return Convert.ToDecimal(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
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
        Attachment.btnHandler += new Attachment_Pollution.OnButtonClick(Upload_File);
        if (!Page.IsPostBack)
        {
            PK_PM_Waste_Hauler = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
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

            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            if (PK_PM_Waste_Hauler > 0)
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
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Waste_Hauler_Attachments, Convert.ToInt32(PK_PM_Waste_Hauler), "FK_PM_Waste_Hauler", "PK_PM_Waste_Hauler_Attachments", false, 2);
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    // Bind Controls
                    BindDropdowns();
                    SetValidations();
                    BindDetailsForEdit();
                    // set attachment details control in read/write mode. so user can add or remove attachment as well.
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Waste_Hauler_Attachments, Convert.ToInt32(PK_PM_Waste_Hauler), "FK_PM_Waste_Hauler", "PK_PM_Waste_Hauler_Attachments", true, 2);
                }
                // bind attachment details to show attachment for current risk profile.
                BindAttachmentDetails();
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

                // disable Add Attachment button                
                btnEdit.Visible = false;
                btnAuditTrail.Visible = false;
                BindDropdowns();
                SetValidations();
                BindAttachmentDetails();
                // don't show div for view mode
                dvView.Style["display"] = "none";
                if (FK_PM_Site_Information > 0)
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
        PM_Waste_Hauler objPM_Waste_Hauler = new PM_Waste_Hauler(PK_PM_Waste_Hauler);
        txtWaste_Hauler_Name.Text = objPM_Waste_Hauler.Waste_Hauler_Name;
        txtAddress_1.Text = objPM_Waste_Hauler.Address_1;
        txtAddress_2.Text = objPM_Waste_Hauler.Address_2;
        txtCity.Text = objPM_Waste_Hauler.City;
        if (objPM_Waste_Hauler.FK_State != null)
        {
            ListItem lst = drpFK_State.Items.FindByValue(objPM_Waste_Hauler.FK_State.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_State.SelectedValue = objPM_Waste_Hauler.FK_State.ToString();
        }
        txtZipCode.Text = objPM_Waste_Hauler.Zip_Code;
        txtContact_Name.Text = objPM_Waste_Hauler.Contact_Name;
        txtContact_Telephone.Text = objPM_Waste_Hauler.Contact_Telephone;
        txtEPA_ID_Number.Text = objPM_Waste_Hauler.EPA_ID_Number;
        if (objPM_Waste_Hauler.FK_PM_Site_Information != null) FK_PM_Site_Information = Convert.ToDecimal(objPM_Waste_Hauler.FK_PM_Site_Information);
        if (FK_PM_Site_Information > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;

        if (objPM_Waste_Hauler.State_Registration != null)
            rdbStateRegistration.SelectedValue = objPM_Waste_Hauler.State_Registration;
        else
            rdbStateRegistration.SelectedValue = "Y";

        if (objPM_Waste_Hauler.Certification_On_File != null)
            rdbCertificateOnFile.SelectedValue = objPM_Waste_Hauler.Certification_On_File;
        else
            rdbCertificateOnFile.SelectedValue = "Y";
        if (objPM_Waste_Hauler.Apply_To_Location != null)
            rdoApply_To_Location.SelectedValue = objPM_Waste_Hauler.Apply_To_Location;

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
        PM_Waste_Hauler objPM_Waste_Hauler = new PM_Waste_Hauler(PK_PM_Waste_Hauler);
        lblWaste_Hauler_Name.Text = objPM_Waste_Hauler.Waste_Hauler_Name;
        lblAddress_1.Text = objPM_Waste_Hauler.Address_1;
        lblAddress_2.Text = objPM_Waste_Hauler.Address_2;
        lblCity.Text = objPM_Waste_Hauler.City;
        if (objPM_Waste_Hauler.FK_State != null)
            lblFK_State.Text = new State((decimal)objPM_Waste_Hauler.FK_State).FLD_state;
        lblZip_Code.Text = objPM_Waste_Hauler.Zip_Code;
        lblContact_Name.Text = objPM_Waste_Hauler.Contact_Name;
        lblContact_Telephone.Text = objPM_Waste_Hauler.Contact_Telephone;
        lblEPA_ID_Number.Text = objPM_Waste_Hauler.EPA_ID_Number;
        if (objPM_Waste_Hauler.FK_PM_Site_Information != null) FK_PM_Site_Information = Convert.ToDecimal(objPM_Waste_Hauler.FK_PM_Site_Information);
        if (FK_PM_Site_Information > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;

        lblStateRegistration.Text = objPM_Waste_Hauler.State_Registration == "Y" ? "Yes" : "No";
        lblCertificateonFile.Text = objPM_Waste_Hauler.Certification_On_File == "Y" ? "Yes" : "No";
        lblApply_To_Location.Text = objPM_Waste_Hauler.Apply_To_Location == "Y" ? "Yes" : "No";
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
        PM_Waste_Hauler objPM_Waste_Hauler = new PM_Waste_Hauler();
        objPM_Waste_Hauler.PK_PM_Waste_Hauler = PK_PM_Waste_Hauler;
        objPM_Waste_Hauler.Waste_Hauler_Name = txtWaste_Hauler_Name.Text.Trim();
        objPM_Waste_Hauler.Address_1 = txtAddress_1.Text.Trim();
        objPM_Waste_Hauler.Address_2 = txtAddress_2.Text.Trim();
        objPM_Waste_Hauler.City = txtCity.Text.Trim();
        if (drpFK_State.SelectedIndex > 0) objPM_Waste_Hauler.FK_State = Convert.ToDecimal(drpFK_State.SelectedValue);
        objPM_Waste_Hauler.Zip_Code = txtZipCode.Text.Trim();
        objPM_Waste_Hauler.Contact_Name = txtContact_Name.Text.Trim();
        objPM_Waste_Hauler.Contact_Telephone = txtContact_Telephone.Text.Trim();
        objPM_Waste_Hauler.EPA_ID_Number = txtEPA_ID_Number.Text.Trim();
        objPM_Waste_Hauler.FK_PM_Site_Information = FK_PM_Site_Information;
        objPM_Waste_Hauler.Update_Date = DateTime.Now;
        objPM_Waste_Hauler.Updated_By = clsSession.UserID;
        objPM_Waste_Hauler.Certification_On_File = rdbCertificateOnFile.SelectedValue;
        objPM_Waste_Hauler.State_Registration = rdbStateRegistration.SelectedValue;
        objPM_Waste_Hauler.Apply_To_Location = rdoApply_To_Location.SelectedValue;
        decimal _retVal;
        if (PK_PM_Waste_Hauler > 0)
            _retVal = objPM_Waste_Hauler.Update();
        else
            _retVal = objPM_Waste_Hauler.Insert();

        if (_retVal == -2)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Waste Hauler that you are trying to add already exists.');ShowPanel(1);", true);
            return;
        }
        // add the attachment 
        Attachment.FK_Field_Value = Convert.ToInt32(_retVal.ToString());
        Attachment.FK_Field_Name = "FK_PM_Waste_Hauler";
        Attachment.Add(clsGeneral.Pollution_Tables.PM_Waste_Hauler_Attachments);
        Response.Redirect("PM_Waste_Hauler.aspx?id=" + Encryption.Encrypt(_retVal.ToString()) + "&fid=" + Encryption.Encrypt(FK_PM_Site_Information.ToString()) + "&loc=" + Request.QueryString["loc"] + "&op=view");
    }
    /// <summary>
    /// Handles Edit button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("PM_Waste_Hauler.aspx?id=" + Encryption.Encrypt(PK_PM_Waste_Hauler.ToString()) + "&fid=" + Encryption.Encrypt(FK_PM_Site_Information.ToString()) + "&loc=" + Request.QueryString["loc"] + "&op=edit");
    }
    /// <summary>
    /// Handles Back button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (StrOperation == "view")
            Response.Redirect("Pollution.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("5"));
        else
            Response.Redirect("Pollution.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("5"));
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
        if (PK_PM_Waste_Hauler > 0)
        {
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Waste_Hauler);
            Attachment.FK_Field_Name = "FK_PM_Waste_Hauler";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_Waste_Hauler_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Waste Hauler details first.');ShowPanel(2);", true);
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

        #region " Site Information "

        DataTable dtFields = clsScreen_Validators.SelectByScreen(165).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Waste Hauler Name":
                    strCtrlsIDs += txtWaste_Hauler_Name.ClientID + ",";
                    strMessages += "Please enter [Hazardous Waste Hauler]/Waste Hauler Name" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strCtrlsIDs += txtAddress_1.ClientID + ",";
                    strMessages += "Please enter [Hazardous Waste Hauler]/Address 1" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strCtrlsIDs += txtAddress_2.ClientID + ",";
                    strMessages += "Please enter [Hazardous Waste Hauler]/Address 2" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "City":
                    strCtrlsIDs += txtCity.ClientID + ",";
                    strMessages += "Please enter [Hazardous Waste Hauler]/City" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "State":
                    strCtrlsIDs += drpFK_State.ClientID + ",";
                    strMessages += "Please select [Hazardous Waste Hauler]/State" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strCtrlsIDs += txtZipCode.ClientID + ",";
                    strMessages += "Please enter [Hazardous Waste Hauler]/Zip Code" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Contact Name":
                    strCtrlsIDs += txtContact_Name.ClientID + ",";
                    strMessages += "Please enter [Hazardous Waste Hauler]/Contact Name" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Contact Telephone":
                    strCtrlsIDs += txtContact_Telephone.ClientID + ",";
                    strMessages += "Please enter [Hazardous Waste Hauler]/Contact Telephone" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "EPA ID Number":
                    strCtrlsIDs += txtEPA_ID_Number.ClientID + ",";
                    strMessages += "Please enter [Hazardous Waste Hauler]/EPA ID Number" + ",";
                    Span9.Style["display"] = "inline-block";
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