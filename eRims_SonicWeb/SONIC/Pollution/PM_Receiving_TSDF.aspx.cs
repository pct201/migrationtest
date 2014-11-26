using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Pollution_PM_Receiving_TSDF : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes foriegn key for site information
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
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Receiving_TSDF
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Receiving_TSDF"]);
        }
        set { ViewState["PK_PM_Receiving_TSDF"] = value; }
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
            PK_PM_Receiving_TSDF = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
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
            if (PK_PM_Receiving_TSDF > 0)
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
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Receiving_TSDF_Attachments, Convert.ToInt32(PK_PM_Receiving_TSDF), "FK_PM_Receiving_TSDF", "PK_PM_Receiving_TSDF_Attachments", false, 2);
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
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Receiving_TSDF_Attachments, Convert.ToInt32(PK_PM_Receiving_TSDF), "FK_PM_Receiving_TSDF", "PK_PM_Receiving_TSDF_Attachments", true, 2);
                }
                // bind attachment details to show attachment for current risk profile.
                BindAttachmentDetails();
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

                // disable Add Attachment button
                btnAuditTrail.Visible = false;
                btnEdit.Visible = false;
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

        //Bind HW Methods
        DataTable dtMethods = clsLU_HW_Method.SelectAll().Tables[0];

        dtMethods.DefaultView.RowFilter = "Active='Y'";
        dtMethods.DefaultView.Sort = "Fld_Desc";

        drpLUHWMethod.DataSource = dtMethods.DefaultView;
        drpLUHWMethod.DataTextField = "Fld_Desc";
        drpLUHWMethod.DataValueField = "PK_LU_HW_Method";
        drpLUHWMethod.DataBind();
        drpLUHWMethod.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        PM_Receiving_TSDF objPM_Receiving_TSDF = new PM_Receiving_TSDF(PK_PM_Receiving_TSDF);
        txtReceiving_TSDF_Name.Text = objPM_Receiving_TSDF.Receiving_TSDF_Name;
        txtAddress_1.Text = objPM_Receiving_TSDF.Address_1;
        txtAddress_2.Text = objPM_Receiving_TSDF.Address_2;
        txtCity.Text = objPM_Receiving_TSDF.City;
        if (objPM_Receiving_TSDF.FK_State != null)
        {
            ListItem lst = drpFK_State.Items.FindByValue(objPM_Receiving_TSDF.FK_State.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_State.SelectedValue = objPM_Receiving_TSDF.FK_State.ToString();
        }
        txtZipCode.Text = objPM_Receiving_TSDF.Zip_Code;
        txtContact_Name.Text = objPM_Receiving_TSDF.Contact_Name;
        txtContact_Telephone.Text = objPM_Receiving_TSDF.Contact_Telephone;
        txtEPA_ID_Number.Text = objPM_Receiving_TSDF.EPA_ID_Number;
        rdoCOI_ON_File.SelectedValue = objPM_Receiving_TSDF.COI_ON_File;
        if (objPM_Receiving_TSDF.FK_PM_Site_Information != null) FK_PM_Site_Information = Convert.ToDecimal(objPM_Receiving_TSDF.FK_PM_Site_Information);
        if (FK_PM_Site_Information > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;
        txtHazardous_Waste_Method.Text = Convert.ToString(objPM_Receiving_TSDF.Hazardous_Waste_Method);
        drpLUHWMethod.SelectedValue = Convert.ToString(objPM_Receiving_TSDF.FK_LU_HW_Method);
        rdbTDSFDistance.SelectedValue = Convert.ToString(objPM_Receiving_TSDF.TDSF_Distance);
        if(objPM_Receiving_TSDF.Apply_To_Location!=null)rdoApply_To_Location.SelectedValue = Convert.ToString(objPM_Receiving_TSDF.Apply_To_Location);
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
        PM_Receiving_TSDF objPM_Receiving_TSDF = new PM_Receiving_TSDF(PK_PM_Receiving_TSDF);
        lblReceiving_TSDF_Name.Text = objPM_Receiving_TSDF.Receiving_TSDF_Name;
        lblAddress_1.Text = objPM_Receiving_TSDF.Address_1;
        lblAddress_2.Text = objPM_Receiving_TSDF.Address_2;
        lblCity.Text = objPM_Receiving_TSDF.City;
        if (objPM_Receiving_TSDF.FK_State != null)
            lblFK_State.Text = new State((decimal)objPM_Receiving_TSDF.FK_State).FLD_state;
        lblZip_Code.Text = objPM_Receiving_TSDF.Zip_Code;
        lblContact_Name.Text = objPM_Receiving_TSDF.Contact_Name;
        lblContact_Telephone.Text = objPM_Receiving_TSDF.Contact_Telephone;
        lblEPA_ID_Number.Text = objPM_Receiving_TSDF.EPA_ID_Number;
        lblCOI_ON_File.Text = objPM_Receiving_TSDF.COI_ON_File == "Y" ? "Yes" : "No";
        if (objPM_Receiving_TSDF.FK_PM_Site_Information != null) FK_PM_Site_Information = Convert.ToDecimal(objPM_Receiving_TSDF.FK_PM_Site_Information);
        if (FK_PM_Site_Information > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;
        lblHazardous_Waste_Method.Text = Convert.ToString(objPM_Receiving_TSDF.Hazardous_Waste_Method);
        if (objPM_Receiving_TSDF.FK_LU_HW_Method != null)
            lblLUHWMethod.Text = Convert.ToString(new clsLU_HW_Method(Convert.ToDecimal(objPM_Receiving_TSDF.FK_LU_HW_Method)).Fld_Desc);
        else
            lblLUHWMethod.Text = "";
        lblTDSFDistance.Text = Convert.ToString(objPM_Receiving_TSDF.TDSF_Distance) == "Y" ? "Yes" : "No";
        lblApply_To_Location.Text =objPM_Receiving_TSDF.Apply_To_Location == "Y" ? "Yes" : "No";
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
        PM_Receiving_TSDF objPM_Receiving_TSDF = new PM_Receiving_TSDF();
        objPM_Receiving_TSDF.PK_PM_Receiving_TSDF = PK_PM_Receiving_TSDF;
        objPM_Receiving_TSDF.Receiving_TSDF_Name = txtReceiving_TSDF_Name.Text.Trim();
        objPM_Receiving_TSDF.Address_1 = txtAddress_1.Text.Trim();
        objPM_Receiving_TSDF.Address_2 = txtAddress_2.Text.Trim();
        objPM_Receiving_TSDF.City = txtCity.Text.Trim();
        if (drpFK_State.SelectedIndex > 0) objPM_Receiving_TSDF.FK_State = Convert.ToDecimal(drpFK_State.SelectedValue);
        objPM_Receiving_TSDF.Zip_Code = txtZipCode.Text.Trim();
        objPM_Receiving_TSDF.Contact_Name = txtContact_Name.Text.Trim();
        objPM_Receiving_TSDF.Contact_Telephone = txtContact_Telephone.Text.Trim();
        objPM_Receiving_TSDF.EPA_ID_Number = txtEPA_ID_Number.Text.Trim();
        objPM_Receiving_TSDF.COI_ON_File = rdoCOI_ON_File.SelectedValue;
        objPM_Receiving_TSDF.FK_PM_Site_Information = FK_PM_Site_Information;
        objPM_Receiving_TSDF.Update_Date = DateTime.Now;
        objPM_Receiving_TSDF.Updated_By = clsSession.UserID;
        objPM_Receiving_TSDF.Hazardous_Waste_Method = Convert.ToString(txtHazardous_Waste_Method.Text.Trim());
        objPM_Receiving_TSDF.FK_LU_HW_Method = Convert.ToDecimal(drpLUHWMethod.SelectedValue);
        objPM_Receiving_TSDF.TDSF_Distance = Convert.ToString(rdbTDSFDistance.SelectedValue);
        objPM_Receiving_TSDF.Apply_To_Location = Convert.ToString(rdoApply_To_Location.SelectedValue);
        
        decimal _retVal;
        if (PK_PM_Receiving_TSDF > 0)
            _retVal = objPM_Receiving_TSDF.Update();
        else
            _retVal = objPM_Receiving_TSDF.Insert();

        if (_retVal == -2)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Reciving TSDF that you are trying to add already exists.');ShowPanel(1);", true);
            return;
        }
        // add the attachment 
        Attachment.FK_Field_Value = Convert.ToInt32(_retVal.ToString());
        Attachment.FK_Field_Name = "FK_PM_Receiving_TSDF";
        Attachment.Add(clsGeneral.Pollution_Tables.PM_Receiving_TSDF_Attachments);
        Response.Redirect("PM_Receiving_TSDF.aspx?id=" + Encryption.Encrypt(_retVal.ToString()) + "&fid=" + Encryption.Encrypt(FK_PM_Site_Information.ToString()) + "&loc=" + Request.QueryString["loc"] + "&op=view");
    }
    /// <summary>
    /// Handles Edit button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("PM_Receiving_TSDF.aspx?id=" + Encryption.Encrypt(PK_PM_Receiving_TSDF.ToString()) + "&fid=" + Encryption.Encrypt(FK_PM_Site_Information.ToString()) + "&loc=" + Request.QueryString["loc"] + "&op=edit");
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
        if (PK_PM_Receiving_TSDF > 0)
        {
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Receiving_TSDF);
            Attachment.FK_Field_Name = "FK_PM_Receiving_TSDF";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_Receiving_TSDF_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Receiving TSDF details first');ShowPanel(2);", true);
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

        DataTable dtFields = clsScreen_Validators.SelectByScreen(166).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Receiving TSDF Name":
                    strCtrlsIDs += txtReceiving_TSDF_Name.ClientID + ",";
                    strMessages += "Please enter [Receiving TSDF]/Receiving TSDF Name" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strCtrlsIDs += txtAddress_1.ClientID + ",";
                    strMessages += "Please enter [Receiving TSDF]/Address 1" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strCtrlsIDs += txtAddress_2.ClientID + ",";
                    strMessages += "Please enter [Receiving TSDF]/Address 2" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "City":
                    strCtrlsIDs += txtCity.ClientID + ",";
                    strMessages += "Please enter [Receiving TSDF]/City" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "State":
                    strCtrlsIDs += drpFK_State.ClientID + ",";
                    strMessages += "Please select [Receiving TSDF]/State" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strCtrlsIDs += txtZipCode.ClientID + ",";
                    strMessages += "Please enter [Receiving TSDF]/Zip Code" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Contact Name":
                    strCtrlsIDs += txtContact_Name.ClientID + ",";
                    strMessages += "Please enter [Receiving TSDF]/Contact Name" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Contact Telephone":
                    strCtrlsIDs += txtContact_Telephone.ClientID + ",";
                    strMessages += "Please enter [Receiving TSDF]/Contact Telephone" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "EPA ID Number":
                    strCtrlsIDs += txtEPA_ID_Number.ClientID + ",";
                    strMessages += "Please enter [Receiving TSDF]/EPA ID Number" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;               
                case "Method Used to Dispose of Hazardous Waste":
                    strCtrlsIDs += drpLUHWMethod.ClientID + ",";
                    strMessages += "Please select [Receiving TSDF]/Method Used to Dispose of Hazardous Waste" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Describe Other Method, If Selected":
                    strCtrlsIDs += txtHazardous_Waste_Method.ClientID + ",";
                    strMessages += "Please enter [Receiving TSDF]/Describe Other Method; If Selected" + ",";
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