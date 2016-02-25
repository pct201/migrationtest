using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class SONIC_Pollution_PM_Hearing_Conservation : clsBasePage
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
    public decimal PK_PM_Hearing_Conservation
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Hearing_Conservation"]);
        }
        set { ViewState["PK_PM_Hearing_Conservation"] = value; }
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
    protected void Page_Load(object sender, EventArgs e)
    {
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Pollution);
        //Attachment.btnHandler += new Attachment_Pollution.OnButtonClick(Upload_File);


        if (!IsPostBack)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            PK_PM_Hearing_Conservation = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_PM_Site_Information = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);
            FK_LU_Location_ID = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);
            BindDropdowns();
            BindBuildings();
            if (FK_LU_Location_ID > 0)
            {
                Session["ExposureLocation"] = FK_LU_Location_ID;
                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx");

            // shows the first panel           

            if (PK_PM_Hearing_Conservation > 0)
            {
                StrOperation = Convert.ToString(Request.QueryString["op"]);
                //PK_Executive_Risk_Contacts = Convert.ToInt32(Request.QueryString["id"]);
                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDropdowns();
                    BindDetailsForView();
                    btnEdit.Visible = (App_Access == AccessType.Administrative_Access);
                    AttachmentsView.StrOperation = StrOperation;
                    AttachmentsView.PK_ID = PK_PM_Hearing_Conservation;
                    // set attachment details control in readonly mode.
                    //AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Hearing_Conservation_Attachments, Convert.ToInt32(PK_PM_Hearing_Conservation), "FK_PM_Hearing_Conservation", "PK_PM_Hearing_Conservation_Attachments", false, 2);
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
                    //AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Hearing_Conservation_Attachments, Convert.ToInt32(PK_PM_Hearing_Conservation), "FK_PM_Hearing_Conservation", "PK_PM_Hearing_Conservation_Attachments", true, 2);
                    Attachments.PK_ID = PK_PM_Hearing_Conservation;
                }
                
                // bind attachment details to show attachment for current risk profile.
                //BindAttachmentDetails();
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
        ComboHelper.FillState(new DropDownList[] { ddlFK_State }, 0, true);
        ComboHelper.FillEventType(new DropDownList[] { ddlFK_LU_Hearing_Conservation_Test_Type }, 0, true);
        BindActiveEmployeesByLocation();
        BindVendorLookupDetails();

    }
    #endregion

    #region Control Events
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (StrOperation == "view")
            Response.Redirect("Pollution.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("7"));
        else
            Response.Redirect("Pollution.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("7"));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PM_Hearing_Conservation objPM_Hearing_Conservation = new PM_Hearing_Conservation();
        objPM_Hearing_Conservation.PK_PM_Hearing_Conservation = PK_PM_Hearing_Conservation;
        objPM_Hearing_Conservation.FK_PM_Site_Information = FK_PM_Site_Information;
        objPM_Hearing_Conservation.Date_Of_Test = clsGeneral.FormatNullDateToStore(txtDate_Of_Test.Text);
        objPM_Hearing_Conservation.FK_LU_Employee = clsGeneral.GetDecimal(ddlFK_LU_Employee.SelectedValue);
        objPM_Hearing_Conservation.FK_LU_Hearing_Conservation_Test_Type = clsGeneral.GetDecimal(ddlFK_LU_Hearing_Conservation_Test_Type.SelectedValue);
        if (rdlLocation_Exceed_Noise_Level.SelectedIndex > -1)
            objPM_Hearing_Conservation.Location_Exceed_Noise_Level = rdlLocation_Exceed_Noise_Level.SelectedValue;
        else
            objPM_Hearing_Conservation.Location_Exceed_Noise_Level = "0";
        if (rdlSTS_Shift.SelectedIndex > -1)
            objPM_Hearing_Conservation.STS_Shift = rdlSTS_Shift.SelectedValue;
        if (rdlRetest_Scheduled.SelectedIndex > -1)
            objPM_Hearing_Conservation.Retest_Scheduled = rdlRetest_Scheduled.SelectedValue;
        objPM_Hearing_Conservation.Rested_Date = clsGeneral.FormatNullDateToStore(txtRested_Date.Text);
        objPM_Hearing_Conservation.Notes = txtNotes.Text;
        objPM_Hearing_Conservation.Vendor = txtVendor.Text;
        objPM_Hearing_Conservation.Vendor_Representative = txtVendorContactName.Text;
        objPM_Hearing_Conservation.Vendor_Address = txtVendor_Address.Text;
        objPM_Hearing_Conservation.Vendor_City = txtVendor_City.Text;
        objPM_Hearing_Conservation.FK_Vendor_State = clsGeneral.GetDecimal(ddlFK_State.SelectedValue);
        objPM_Hearing_Conservation.Vendor_Zip_Code = txtVendor_Zip_Code.Text;
        objPM_Hearing_Conservation.Vendor_Telephone = txtVendor_Telephone.Text;
        objPM_Hearing_Conservation.Vendor_EMail = txtVendor_EMail.Text;
        objPM_Hearing_Conservation.Update_Date = DateTime.Now;
        objPM_Hearing_Conservation.Updated_By = clsSession.UserID;       

       
        decimal _retVal;
        if (PK_PM_Hearing_Conservation > 0)
            _retVal = objPM_Hearing_Conservation.Update();
        else
            _retVal = objPM_Hearing_Conservation.Insert();        
        

        if (_retVal == -2)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Hearing Conservation that you are trying to add already exists.');ShowPanel(1);", true);
            return;
        }
         //Building details
        string strBuildingIDs = "";
        for (int i = 0; i < chkBuilding.Items.Count; i++)
        {
            if (chkBuilding.Items[i].Selected == true)
            {
                strBuildingIDs = strBuildingIDs + chkBuilding.Items[i].Value + ",";
            }
        }
        strBuildingIDs = strBuildingIDs.TrimEnd(',');
        if (strBuildingIDs != "")
        {
            objPM_Hearing_Conservation.BuildingId = strBuildingIDs;
            objPM_Hearing_Conservation.InsertBuildingDetails(_retVal, strBuildingIDs, objPM_Hearing_Conservation.Updated_By, DateTime.Now);
        }       

        //// add the attachment 
        //Attachment.FK_Field_Value = Convert.ToInt32(_retVal.ToString());
        //Attachment.FK_Field_Name = "FK_PM_Hearing_Conservation";
        //Attachment.Add(clsGeneral.Pollution_Tables.PM_Hearing_Conservation_Attachments);
        Response.Redirect("PM_Hearing_Conservation.aspx?id=" + Encryption.Encrypt(_retVal.ToString()) + "&fid=" + Encryption.Encrypt(FK_PM_Site_Information.ToString()) + "&loc=" + Request.QueryString["loc"] + "&op=view");
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("PM_Hearing_Conservation.aspx?id=" + Encryption.Encrypt(PK_PM_Hearing_Conservation.ToString()) + "&fid=" + Encryption.Encrypt(FK_PM_Site_Information.ToString()) + "&loc=" + Request.QueryString["loc"] + "&op=edit");
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
            //AttachDetailsView.Bind();
        }
        else
        {
            //AttachDetails.Bind();
        }
    }
    /// <summary>
    /// Upload File
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {
        if (PK_PM_Hearing_Conservation > 0)
        {
            // add the attachment 
            //Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Hearing_Conservation);
            //Attachment.FK_Field_Name = "FK_PM_Waste_Hauler";
            //Attachment.Add(clsGeneral.Pollution_Tables.PM_Waste_Hauler_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Hearing Conversation details first.');ShowPanel(2);", true);
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        btnEdit.Visible = true;
        btnSave.Visible = false;
        PM_Hearing_Conservation objPM_Hearing_Conservation = new PM_Hearing_Conservation(PK_PM_Hearing_Conservation);
        lblDate_Of_Test.Text =  clsGeneral.FormatDBNullDateToDisplay(Convert.ToString(objPM_Hearing_Conservation.Date_Of_Test));
        if (objPM_Hearing_Conservation.FK_LU_Hearing_Conservation_Test_Type != null)
            lblFK_LU_Hearing_Conservation_Test_Type.Text = new LU_Hearing_Conservation_Test_Type((decimal)objPM_Hearing_Conservation.FK_LU_Hearing_Conservation_Test_Type).Fld_Desc;

        if (objPM_Hearing_Conservation.FK_LU_Employee != null)
            lblFK_LU_Employee.Text = objPM_Hearing_Conservation.Associate;

        lblLocation_Exceed_Noise_Level.Text = objPM_Hearing_Conservation.Location_Exceed_Noise_Level == "Y" ? "Yes" : "No";
        lblSTS_Shift.Text = objPM_Hearing_Conservation.STS_Shift == "Y" ? "Yes" : "No";
        lblRetest_Scheduled.Text = objPM_Hearing_Conservation.Retest_Scheduled == "Y" ? "Yes" : "No";
        lblRested_Date.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objPM_Hearing_Conservation.Rested_Date));
        lblNotes.Text = objPM_Hearing_Conservation.Notes;
        lblVendor.Text = objPM_Hearing_Conservation.Vendor;
        lblVendor_Representative.Text = objPM_Hearing_Conservation.Vendor_Representative;
        lblVendor_Address.Text = objPM_Hearing_Conservation.Vendor_Address;
        lblVendor_City.Text = objPM_Hearing_Conservation.Vendor_City;
        if (objPM_Hearing_Conservation.FK_Vendor_State != null)
            lblFK_Vendor_State.Text = new ERIMS.DAL.State(Convert.ToDecimal(objPM_Hearing_Conservation.FK_Vendor_State)).FLD_state;
        lblVendor_Zip_Code.Text = objPM_Hearing_Conservation.Vendor_Zip_Code;
        lblVendor_Telephone.Text = objPM_Hearing_Conservation.Vendor_Telephone;
        lblVendor_EMail.Text = objPM_Hearing_Conservation.Vendor_EMail;


        DataSet dsPM_Hearing_Conservation_Buildings = PM_Hearing_Conservation.SelectByFKBuildingNumber(PK_PM_Hearing_Conservation);
        if (dsPM_Hearing_Conservation_Buildings.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drlstBuilding in dsPM_Hearing_Conservation_Buildings.Tables[0].Rows)
            {
                foreach (ListItem lstBuilding in chkBuildingView.Items)
                {
                    if (lstBuilding.Value == drlstBuilding["FK_Building"].ToString())
                    {
                        lstBuilding.Selected = true;
                    }
                }
            }
        }


        if (objPM_Hearing_Conservation.FK_PM_Site_Information != null) FK_PM_Site_Information = Convert.ToDecimal(objPM_Hearing_Conservation.FK_PM_Site_Information);
        if (FK_PM_Site_Information > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;

        //lblStateRegistration.Text = objPM_Waste_Hauler.State_Registration == "Y" ? "Yes" : "No";
        //lblCertificateonFile.Text = objPM_Waste_Hauler.Certification_On_File == "Y" ? "Yes" : "No";
        //lblApply_To_Location.Text = objPM_Waste_Hauler.Apply_To_Location == "Y" ? "Yes" : "No";
    }

    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        PM_Hearing_Conservation objPM_Hearing_Conservation = new PM_Hearing_Conservation(PK_PM_Hearing_Conservation);
        txtDate_Of_Test.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objPM_Hearing_Conservation.Date_Of_Test));
        ddlFK_LU_Employee.SelectedValue = Convert.ToString(objPM_Hearing_Conservation.FK_LU_Employee);
        ddlFK_LU_Hearing_Conservation_Test_Type.SelectedValue = Convert.ToString(objPM_Hearing_Conservation.FK_LU_Hearing_Conservation_Test_Type);
        rdlLocation_Exceed_Noise_Level.SelectedValue = objPM_Hearing_Conservation.Location_Exceed_Noise_Level;
        rdlSTS_Shift.SelectedValue = objPM_Hearing_Conservation.STS_Shift;
        rdlRetest_Scheduled.SelectedValue = objPM_Hearing_Conservation.Retest_Scheduled;
        txtRested_Date.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objPM_Hearing_Conservation.Rested_Date));
        txtNotes.Text = objPM_Hearing_Conservation.Notes;
        ddlVendorLookup.SelectedValue = Convert.ToString(objPM_Hearing_Conservation.PK_PM_Hearing_Conservation);
        txtVendor.Text = objPM_Hearing_Conservation.Vendor;
        txtVendorContactName.Text = objPM_Hearing_Conservation.Vendor_Representative;
        txtVendor_Address.Text = objPM_Hearing_Conservation.Vendor_Address;
        txtVendor_City.Text = objPM_Hearing_Conservation.Vendor_City;
        ddlFK_State.SelectedValue = Convert.ToString(objPM_Hearing_Conservation.FK_Vendor_State);
        txtVendor_Zip_Code.Text = objPM_Hearing_Conservation.Vendor_Zip_Code;
        txtVendor_Telephone.Text = objPM_Hearing_Conservation.Vendor_Telephone;
        txtVendor_EMail.Text = objPM_Hearing_Conservation.Vendor_EMail;       

        if (objPM_Hearing_Conservation.FK_Vendor_State != null)
        {
            ListItem lst = ddlFK_State.Items.FindByValue(objPM_Hearing_Conservation.FK_Vendor_State.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_State.SelectedValue = objPM_Waste_Hauler.FK_State.ToString();
        }

        DataSet dsPM_Hearing_Conservation_Buildings = PM_Hearing_Conservation.SelectByFKBuildingNumber(PK_PM_Hearing_Conservation);
        if (dsPM_Hearing_Conservation_Buildings.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drlstBuilding in dsPM_Hearing_Conservation_Buildings.Tables[0].Rows)
            {
                foreach (ListItem lstBuilding in chkBuilding.Items)
                {
                    if (lstBuilding.Value == drlstBuilding["FK_Building"].ToString())
                    {
                        lstBuilding.Selected = true;
                    }
                }
            }
        }
        //else //old value selected here
        //{
        //    foreach (ListItem lstWasteCode in lstHWCodes.Items)
        //    {
        //        if (lstWasteCode.Value == Convert.ToString(objPM_Waste_Removal.FK_LU_PM_Hazardous_Waste_Codes))
        //        {
        //            lstWasteCode.Selected = true;
        //        }
        //    }
        //}


        if (objPM_Hearing_Conservation.FK_PM_Site_Information != null) FK_PM_Site_Information = Convert.ToDecimal(objPM_Hearing_Conservation.FK_PM_Site_Information);
        if (FK_PM_Site_Information > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;
    }

    private void BindVendorLookupDetails()
    {
        DataSet dsVendorLookUP = LU_Hearing_Conservation_Test_Type.SelectVendorLookUpByPK(PK_PM_Hearing_Conservation);

        if (dsVendorLookUP.Tables.Count > 0)
        {
            ddlVendorLookup.DataSource = dsVendorLookUP.Tables[0];
            ddlVendorLookup.DataTextField = "VendorDetail";
            ddlVendorLookup.DataValueField = "PK_PM_Hearing_Conservation";
            ddlVendorLookup.DataBind();
        }        
        ddlVendorLookup.Items.Insert(0, new ListItem("--Select--", "-1"));
    }

    /// <summary>
    /// bind Building data in radio button list
    /// </summary>
    private void BindBuildings()    
    {
        chkBuilding.ClearSelection();
        chkBuildingView.ClearSelection();
        DataTable dtBuilding = Building.BuildingByFKLocation(Convert.ToInt32(FK_LU_Location_ID)).Tables[0];
        if (StrOperation.ToLower() != "view")
        {
            chkBuilding.DataSource = chkBuildingView.DataSource = dtBuilding;
            chkBuilding.DataTextField = chkBuildingView.DataTextField = "Building_Occupacy";
            chkBuilding.DataValueField = chkBuildingView.DataValueField = "PK_Building_ID";
            chkBuilding.DataBind();
            chkBuildingView.DataBind();
        }
        else
        {
            chkBuildingView.DataSource = dtBuilding;
            chkBuildingView.DataTextField = "Building_Occupacy";
            chkBuildingView.DataValueField = "PK_Building_ID";
            chkBuildingView.DataBind();
        }
    }

    private void BindActiveEmployeesByLocation()
    {
        //FK_LU_Location_ID
        ddlFK_LU_Employee.Items.Clear();
        DataSet dsEmployee = Employee.SelectActiveEmployessByLocation(Convert.ToInt32(FK_LU_Location_ID));
        if (dsEmployee.Tables.Count > 0)
        {
            ddlFK_LU_Employee.DataSource = dsEmployee.Tables[0];
            ddlFK_LU_Employee.DataTextField = "EmployeeName";
            ddlFK_LU_Employee.DataValueField = "PK_Employee_ID";
            ddlFK_LU_Employee.DataBind();
        }
        ddlFK_LU_Employee.Items.Insert(0, new ListItem("-- Select --", "-1"));
        ddlFK_LU_Employee.Items.Insert(1, new ListItem("Entire Department", "0"));
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

        DataTable dtFields = clsScreen_Validators.SelectByScreen(225).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date of Test":
                    strCtrlsIDs += txtDate_Of_Test.ClientID + ",";
                    strMessages += "Please enter [Hearing Conversation]/Date of Test" + ",";
                    spnDate_Of_Test.Style["display"] = "inline-block";
                    break;
                case "Associate":
                    strCtrlsIDs += ddlFK_LU_Employee.ClientID + ",";
                    strMessages += "Please enter [Hearing Conversation]/Associate" + ",";
                    spnFK_LU_Employee.Style["display"] = "inline-block";
                    break;
                case "Event Type":
                    strCtrlsIDs += ddlFK_LU_Hearing_Conservation_Test_Type.ClientID + ",";
                    strMessages += "Please enter [Hearing Conversation]/Event Type" + ",";
                    spnFK_LU_Hearing_Conservation_Test_Type.Style["display"] = "inline-block";
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
