using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class Management_Management : clsBasePage
{

    #region Property

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Management
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Management"]);
        }
        set { ViewState["PK_Management"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return ViewState["StrOperation"] != null ? Convert.ToString(ViewState["StrOperation"]) : "view"; }
        set { ViewState["StrOperation"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_ID_Store
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_ID_Store"]);
        }
        set { ViewState["PK_ID_Store"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_ID_ACI
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_ID_ACI"]);
        }
        set { ViewState["PK_ID_ACI"] = value; }
    }

    #endregion

    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCurrentDate.Text = clsGeneral.FormatDateToDisplay(DateTime.Now);
            PK_Management = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            StrOperation = Convert.ToString(Request.QueryString["mode"]);
            if (StrOperation == "add")
            {
                Session.Remove("Managementcriteria");
                drpFacilitiesIssue.SelectedValue = "Y";
                drpFacilitiesIssue.Enabled = false;
            }
            if (PK_Management > 0)
            {
                if (StrOperation.ToLower() == "view")
                {
                    BindDetailsForView();
                }
                else if (StrOperation.ToLower() == "edit")
                {
                    BindDropDown();
                    BindDetailsForEdit();
                }
                BindStoreGrid();
                BindACIGrid();
            }
            else
            {
                // Check User Rights
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

                BindDropDown();
                drpClientIssue.ClearSelection();
                drpClientIssue.SelectedValue = "Y";
                BindStoreGrid();
                BindACIGrid();
            }
        }
        ctrlMgmtTab.SetSelectedTab(Controls_ManagementTab_ManagementTab.Tab.Management);

    }
    #endregion

    #region "Methods"

    /// <summary>
    /// Bind DropDown
    /// </summary>
    private void BindDropDown()
    {
        //ComboHelper.FillLocation(new DropDownList[] { drpLocation }, true);
        ComboHelper.FillLocationByACIUser((new DropDownList[] { drpLocation }), Convert.ToDecimal(clsSession.UserID), true);
        //ComboHelper.FillLU_Region(new DropDownList[] { drpRegion }, true);
        //ComboHelper.FillState(new DropDownList[] { drpState }, true);
        ComboHelper.FillLU_Camera_Type(new DropDownList[] { drpCameraType }, true);
    }

    /// <summary>
    /// Save Record into Management Table
    /// </summary>
    private void SaveRecord()
    {
        clsManagement objRecord = new clsManagement();
        objRecord.PK_Management_ID = PK_Management;

        //objRecord.Company = txtCompany.Text;
        //objRecord.Company_Phone = txtCompany_Phone.Text;
        //objRecord.City = txtCity.Text;
        //objRecord.County = txtCounty.Text;
        objRecord.Camera_Number = txtCameraNumber.Text;
        objRecord.Cost = !string.IsNullOrEmpty(txtCost.Text) ? Convert.ToDecimal(txtCost.Text) : 0;
        objRecord.Camera_Concern = ctrlCameraConcern.Text;
        objRecord.Recommendation = ctrlRecommendation.Text;
        if (drpLocation.SelectedIndex > 0)
            objRecord.FK_LU_Location = Convert.ToDecimal(drpLocation.SelectedValue);
        else
            objRecord.FK_LU_Location = null;
        //if (drpState.SelectedIndex > 0)
        //    objRecord.FK_LU_State = Convert.ToDecimal(drpState.SelectedValue);
        //else
        //    objRecord.FK_LU_State = null;
        //if (drpRegion.SelectedIndex > 0)
        //    objRecord.FK_LU_Region = Convert.ToDecimal(drpRegion.SelectedValue);
        //else
        //    objRecord.FK_LU_Region = null;

        objRecord.FK_LU_State = null;
        objRecord.FK_LU_Region = null;
        if (drpCameraType.SelectedIndex > 0)
            objRecord.FK_LU_Camera_Type = Convert.ToDecimal(drpCameraType.SelectedValue);
        else
            objRecord.FK_LU_Camera_Type = null;

        if (!string.IsNullOrEmpty(Convert.ToString(rblTask_Complete.SelectedValue)))
            objRecord.Task_Complete = Convert.ToBoolean(Convert.ToInt32(rblTask_Complete.SelectedValue));
        else
            objRecord.Task_Complete = null;


        //set value of Client Issue
        if (drpClientIssue.SelectedIndex > 0)
            objRecord.FK_LU_Client_Issue = Convert.ToString(drpClientIssue.SelectedValue);
        else
            objRecord.FK_LU_Client_Issue = null;


        //set value of Facilities Issue 
        if (drpFacilitiesIssue.SelectedIndex > 0)
            objRecord.FK_LU_Facilities_Issue = Convert.ToString(drpFacilitiesIssue.SelectedValue);
        else
            objRecord.FK_LU_Facilities_Issue = null;
        objRecord.Date_Scheduled = clsGeneral.FormatNullDateToStore(txtdate_Scheduled.Text);
        objRecord.Date_Complete = clsGeneral.FormatNullDateToStore(txtDate_Completed.Text);
        objRecord.CR_Approved = clsGeneral.FormatNullDateToStore(txtCR_Approved.Text);
        if (txtLocation_Code.Text != "")
            objRecord.Location_Code = Convert.ToDecimal(txtLocation_Code.Text);
        //objRecord.Store_Contact_First_Name = txtStore_Contact_First_Name.Text;
        //objRecord.Store_Contact_Last_Name = txtStore_Contact_Last_Name.Text;
        //objRecord.Store_Contact_Phone = txtStore_Contact_Phone.Text;
        //objRecord.Store_Contact_Email = txtStore_Contact_Email.Text;
        //objRecord.Aci_Contact_First_Name = txtAci_Contact_First_Name.Text;
        //objRecord.Aci_Contact_Last_Name = txtAci_Contact_Last_Name.Text;
        //objRecord.Aci_Contact_Phone = txtAci_Contact_Phone.Text;
        //objRecord.Aci_Contact_Email = txtAci_Contact_Email.Text;

        objRecord.Update_Date = DateTime.Now;
        objRecord.Updated_By = clsSession.UserID;

        if (PK_Management > 0)
            objRecord.Update();
        else
            PK_Management = objRecord.Insert();
    }

    /// <summary>
    /// Bind Details
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnViewAudit.Visible = true;
        pnlView.Attributes.CssStyle.Add("display", "none");
        pnl1.Attributes.CssStyle.Add("display", "block");
        clsManagement objRecord = new clsManagement(PK_Management);
        if (PK_Management > 0)
        {
            if (objRecord.PK_Management_ID != null)
                PK_Management = Convert.ToDecimal(objRecord.PK_Management_ID);

            //txtCompany.Text = objRecord.Company != null ? objRecord.Company : "";
            //txtCompany_Phone.Text = objRecord.Company_Phone != null ? objRecord.Company_Phone : "";
            //txtCity.Text = objRecord.City != null ? objRecord.City : "";
            //txtCounty.Text = objRecord.County != null ? objRecord.County : "";
            txtCameraNumber.Text = objRecord.Camera_Number != null ? objRecord.Camera_Number : "";
            txtCost.Text = objRecord.Cost != null ? Convert.ToString(objRecord.Cost) : "";
            ctrlCameraConcern.Text = objRecord.Camera_Concern != null ? Convert.ToString(objRecord.Camera_Concern) : "";
            ctrlRecommendation.Text = objRecord.Recommendation != null ? Convert.ToString(objRecord.Recommendation) : "";


            if (!string.IsNullOrEmpty(Convert.ToString(objRecord.Task_Complete)))
                rblTask_Complete.SelectedValue = Convert.ToString(Convert.ToDecimal(objRecord.Task_Complete));
            else
                rblTask_Complete.ClearSelection();

            if (objRecord.FK_LU_Location != null) drpLocation.SelectedValue = Convert.ToString(objRecord.FK_LU_Location);
            //if (objRecord.FK_LU_State != null) drpState.SelectedValue = Convert.ToString(objRecord.FK_LU_State);
            //if (objRecord.FK_LU_Region != null) drpRegion.SelectedValue = Convert.ToString(objRecord.FK_LU_Region);
            if (objRecord.FK_LU_Camera_Type != null) drpCameraType.SelectedValue = Convert.ToString(objRecord.FK_LU_Camera_Type);
            if (objRecord.FK_LU_Client_Issue != null) drpClientIssue.SelectedValue = Convert.ToString(objRecord.FK_LU_Client_Issue);
            if (objRecord.FK_LU_Facilities_Issue != null) drpFacilitiesIssue.SelectedValue = Convert.ToString(objRecord.FK_LU_Facilities_Issue);

            txtdate_Scheduled.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.Date_Scheduled);
            txtDate_Completed.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.Date_Complete);
            txtCR_Approved.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.CR_Approved);

            if (objRecord.Location_Code != null)
                txtLocation_Code.Text = Convert.ToString(objRecord.Location_Code);
        }
    }

    /// <summary>
    /// Bind Details
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        pnlView.Attributes.CssStyle.Add("display", "block");
        pnl1.Attributes.CssStyle.Add("display", "none");
        btnEdit.Visible = true;
        btnSave.Visible = false;
        btnViewAudit.Visible = true;
        btnEdit.Visible = (App_Access != AccessType.View_Only);

        clsManagement objRecord = new clsManagement(PK_Management);
        if (PK_Management > 0)
        {
            //lblCompany.Text = objRecord.Company != null ? objRecord.Company : "";
            //lblCompany_Phone.Text = objRecord.Company_Phone != null ? objRecord.Company_Phone : "";
            //lblCity.Text = objRecord.City != null ? objRecord.City : "";
            //lblCounty.Text = objRecord.County != null ? objRecord.County : "";
            lblCameraNumber.Text = objRecord.Camera_Number != null ? objRecord.Camera_Number : "";
            lblCost.Text = objRecord.Cost != null ? Convert.ToString(objRecord.Cost) : "";
            lblCameraConcern.Text = objRecord.Camera_Concern != null ? objRecord.Camera_Concern : "";
            lblRecommendation.Text = objRecord.Recommendation != null ? objRecord.Recommendation : "";

            lblDateScheduled.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.Date_Scheduled);
            lblDateComleted.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.Date_Complete);
            lblCRApproved.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.CR_Approved);

            if (objRecord.FK_LU_Location != null)
                lblLocation.Text = new clsAci_Lu_Location((decimal)objRecord.FK_LU_Location).Fld_Desc;
            else
                lblLocation.Text = "";

            //if (objRecord.FK_LU_State != null)
            //    lblState.Text = new LU_State((decimal)objRecord.FK_LU_State).Fld_Desc;
            //else
            //    lblState.Text = "";

            //if (objRecord.FK_LU_Region != null)
            //    lblRegion.Text = new LU_Region((decimal)objRecord.FK_LU_Region).Fld_Desc;
            //else
            //    lblRegion.Text = "";

            switch (objRecord.Task_Complete)
            {
                case true:
                    lblTask_Complete.Text = "Yes";
                    break;
                case false:
                    lblTask_Complete.Text = "No";
                    break;
                default:
                    lblTask_Complete.Text = "";
                    break;
            }

            if (objRecord.FK_LU_Camera_Type != null)
                lblCameraType.Text = new LU_Camera_Type((decimal)objRecord.FK_LU_Camera_Type).Fld_Desc;
            else
                lblCameraType.Text = "";

            if (objRecord.FK_LU_Client_Issue != null)
            {
                if (objRecord.FK_LU_Client_Issue == "Y")
                    lblClientIssue.Text = "Yes";
                else if (objRecord.FK_LU_Client_Issue == "N")
                    lblClientIssue.Text = "No";
            }
            else
            {
                lblClientIssue.Text = "";
            }

            if (objRecord.FK_LU_Facilities_Issue != null)
            {
                if (objRecord.FK_LU_Facilities_Issue == "Y")
                    lblFacilitiesIssue.Text = "Yes";
                else if (objRecord.FK_LU_Facilities_Issue == "N")
                    lblFacilitiesIssue.Text = "No";
            }
            else
            {
                lblFacilitiesIssue.Text = "";
            }

            if (objRecord.Location_Code != null)
                lblLocation_Code.Text = Convert.ToString(objRecord.Location_Code);
            //lblStore_Contact_First_Name.Text = objRecord.Store_Contact_First_Name;
            //lblStore_Contact_Last_Name.Text = objRecord.Store_Contact_Last_Name;
            //lblStore_Contact_Phone.Text = objRecord.Store_Contact_Phone;
            //lblStore_Contact_Email.Text = objRecord.Store_Contact_Email;
            //lblAci_Contact_First_Name.Text = objRecord.Aci_Contact_First_Name;
            //lblAci_Contact_Last_Name.Text = objRecord.Aci_Contact_Last_Name;
            //lblAci_Contact_Phone.Text = objRecord.Aci_Contact_Phone;
            //lblAci_Contact_Email.Text = objRecord.Aci_Contact_Email;
        }

    }

    /// <summary>
    /// Bind Store Grid
    /// </summary>
    private void BindStoreGrid()
    {

        if (StrOperation.ToLower() == "view")
        {
            gvStoreContactView.DataSource = clsManagement_Sonic_Contact.SelectByFK_Management(PK_Management);
            gvStoreContactView.DataBind();
        }
        else if (StrOperation.ToLower() == "edit" || StrOperation.ToLower() == "add")
        {
            gvStoreContact.DataSource = clsManagement_Sonic_Contact.SelectByFK_Management(PK_Management);
            gvStoreContact.DataBind();
        }
        else
        {
            gvStoreContact.DataSource = null;
            gvStoreContact.DataBind();
        }

    }

    /// <summary>
    /// Bind ACI Grid
    /// </summary>
    private void BindACIGrid()
    {

        if (StrOperation.ToLower() == "view")
        {
            gvACIContactView.DataSource = clsManagement_ACI_Contact.SelectByFK_Management(PK_Management);
            gvACIContactView.DataBind();
        }
        else if (StrOperation.ToLower() == "edit" || StrOperation.ToLower() == "add")
        {
            gvACIContact.DataSource = clsManagement_ACI_Contact.SelectByFK_Management(PK_Management);
            gvACIContact.DataBind();
        }
        else
        {
            gvACIContact.DataSource = null;
            gvACIContact.DataBind();
        }

    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearStoreControls()
    {
        //clear control
        _PK_ID_Store = 0;
        txtStore_Contact_First_Name.Text = string.Empty;
        txtStore_Contact_Last_Name.Text = string.Empty;
        txtStore_Contact_Email.Text = string.Empty;
        txtStore_Contact_Phone.Text = string.Empty;
    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearACIControls()
    {
        //clear control
        _PK_ID_ACI = 0;
        txtAci_Contact_First_Name.Text = string.Empty;
        txtAci_Contact_Last_Name.Text = string.Empty;
        txtAci_Contact_Email.Text = string.Empty;
        txtAci_Contact_Phone.Text = string.Empty;
    }

    #endregion

    #region "Other Event"

    /// <summary>
    /// Click Save Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveRecord();

        if (StrOperation.ToLower() == "add" || StrOperation.ToLower() == "addto" || StrOperation.ToLower() == "")
        {
            Response.Redirect("Management.aspx?id=" + Encryption.Encrypt(PK_Management.ToString()) + "&mode=edit", true);
        }
        else
        {
            Response.Redirect("Management.aspx?id=" + Encryption.Encrypt(PK_Management.ToString()) + "&mode=view", true);

        }
    }

    /// <summary>
    /// Edit 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Management.aspx?id=" + Encryption.Encrypt(PK_Management.ToString()) + "&mode=edit", true);
    }

    /// <summary>
    /// Click on Cancel Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManagementSearch.aspx?criteria=1", true);
    }

    /// <summary>
    /// Add new button link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddStoreNew_Click(object sender, EventArgs e)
    {
        btnStoreAdd.Text = "Add";
        _PK_ID_Store = 0;
        trstoreGrid.Style.Add("display", "none");
        trstoreContact.Style.Add("display", "");
        lnkStoreCancel.Style.Add("display", "inline");
        txtStore_Contact_First_Name.Text = string.Empty;
        txtStore_Contact_Last_Name.Text = string.Empty;
        txtStore_Contact_Phone.Text = string.Empty;
        txtStore_Contact_Email.Text = string.Empty; ;
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtStore_Contact_First_Name);
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkStoreCancel_Click(object sender, EventArgs e)
    {
        trstoreGrid.Style.Add("display", "");
        trstoreContact.Style.Add("display", "none");
        lnkStoreCancel.Style.Add("display", "none");
        txtStore_Contact_First_Name.Text = string.Empty;
        txtStore_Contact_Last_Name.Text = string.Empty;
        txtStore_Contact_Phone.Text = string.Empty;
        txtStore_Contact_Email.Text = string.Empty;
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnStoreAdd_Click(object sender, EventArgs e)
    {
        SaveRecord();

        clsManagement_Sonic_Contact objSonic_Contact = new clsManagement_Sonic_Contact();

        objSonic_Contact.PK_Management_Sonic_Contact = _PK_ID_Store;
        objSonic_Contact.FK_Management = PK_Management;
        objSonic_Contact.First_Name = txtStore_Contact_First_Name.Text.Trim();
        objSonic_Contact.Last_name = txtStore_Contact_Last_Name.Text.Trim();
        objSonic_Contact.Phone = txtStore_Contact_Phone.Text.Trim();
        objSonic_Contact.Email = txtStore_Contact_Email.Text.Trim();

        if (_PK_ID_Store > 0)
        {
            objSonic_Contact.Update();
        }
        else
        {
            objSonic_Contact.Insert();
        }

        //clear Control
        ClearStoreControls();
        //Bind Grid Function
        BindStoreGrid();
        BindACIGrid();
        //Cancel CLick
        lnkStoreCancel_Click(null, null);
    }


    /// <summary>
    /// Add new button link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddACINew_Click(object sender, EventArgs e)
    {
        btnACIAdd.Text = "Add";
        _PK_ID_ACI = 0;
        trACIGrid.Style.Add("display", "none");
        trACIContact.Style.Add("display", "");
        lnkACICancel.Style.Add("display", "inline");
        txtAci_Contact_First_Name.Text = string.Empty;
        txtAci_Contact_Last_Name.Text = string.Empty;
        txtAci_Contact_Phone.Text = string.Empty;
        txtAci_Contact_Email.Text = string.Empty; ;
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtAci_Contact_First_Name);
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkACICancel_Click(object sender, EventArgs e)
    {
        trACIGrid.Style.Add("display", "");
        trACIContact.Style.Add("display", "none");
        lnkACICancel.Style.Add("display", "none");
        txtAci_Contact_First_Name.Text = string.Empty;
        txtAci_Contact_Last_Name.Text = string.Empty;
        txtAci_Contact_Phone.Text = string.Empty;
        txtAci_Contact_Email.Text = string.Empty;
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnACIAdd_Click(object sender, EventArgs e)
    {
        SaveRecord();

        clsManagement_ACI_Contact objACI_Contact = new clsManagement_ACI_Contact();

        objACI_Contact.PK_Management_ACI_Contact = _PK_ID_ACI;
        objACI_Contact.FK_Management = PK_Management;
        objACI_Contact.First_Name = txtAci_Contact_First_Name.Text.Trim();
        objACI_Contact.Last_name = txtAci_Contact_Last_Name.Text.Trim();
        objACI_Contact.Phone = txtAci_Contact_Phone.Text.Trim();
        objACI_Contact.Email = txtAci_Contact_Email.Text.Trim();

        if (_PK_ID_ACI > 0)
        {
            objACI_Contact.Update();
        }
        else
        {
            objACI_Contact.Insert();
        }

        //clear Control
        ClearACIControls();
        //Bind Grid Function
        BindACIGrid();
        //Cancel CLick
        lnkACICancel_Click(null, null);
    }

    /// <summary>
    /// selected index change event of drpLocation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(drpLocation.SelectedValue))
        {
            clsAci_Lu_Location lu = new clsAci_Lu_Location(Convert.ToDecimal(drpLocation.SelectedValue));
            txtLocation_Code.Text = Convert.ToString(lu.Fld_Code);
        }
    }
    #endregion

    #region "Grid Event"

    /// <summary>
    /// Event for paging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvStoreContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStoreContact.PageIndex = e.NewPageIndex; //Page new index call
        BindStoreGrid();
    }

    /// <summary>
    /// Row command event for Edit and update
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvStoreContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_ID_Store = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trstoreGrid.Style.Add("display", "none");
            trstoreContact.Style.Add("display", "block");
            lnkStoreCancel.Style.Add("display", "inline");
            btnStoreAdd.Text = "Update";
            // get record from database

            clsManagement_Sonic_Contact objSonic_Contact = new clsManagement_Sonic_Contact(_PK_ID_Store);

            txtStore_Contact_First_Name.Text = Convert.ToString(objSonic_Contact.First_Name);
            txtStore_Contact_Last_Name.Text = Convert.ToString(objSonic_Contact.Last_name);
            txtStore_Contact_Phone.Text = Convert.ToString(objSonic_Contact.Phone);
            txtStore_Contact_Email.Text = Convert.ToString(objSonic_Contact.Email);

            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtStore_Contact_First_Name);
        }
        else if (e.CommandName == "DeleteRecord")
        {
            _PK_ID_Store = Convert.ToDecimal(e.CommandArgument);

            clsManagement_Sonic_Contact.DeleteByPK(_PK_ID_Store);
            BindStoreGrid();
        }
    }

    /// <summary>
    /// Handle Row Data Bound of Store Contact grid 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvStoreContact_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (StrOperation.ToLower() == "edit")
            {
                ((LinkButton)e.Row.Cells[0].FindControl("lnkEdit")).Visible = (App_Access == AccessType.Administrative_Access);//App_Access == AccessType.Edit ||
                ((LinkButton)e.Row.Cells[0].FindControl("lnkDelete")).Visible = (App_Access == AccessType.Delete || App_Access == AccessType.Administrative_Access);
            }
        }
    }

    /// <summary>
    /// Event for paging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvACIContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvACIContact.PageIndex = e.NewPageIndex; //Page new index call
        BindACIGrid();
    }

    /// <summary>
    /// Row command event for Edit and update
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvACIContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_ID_ACI = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trACIGrid.Style.Add("display", "none");
            trACIContact.Style.Add("display", "block");
            lnkACICancel.Style.Add("display", "inline");
            btnACIAdd.Text = "Update";
            // get record from database

            clsManagement_ACI_Contact objACI_Contact = new clsManagement_ACI_Contact(_PK_ID_ACI);

            txtAci_Contact_First_Name.Text = Convert.ToString(objACI_Contact.First_Name);
            txtAci_Contact_Last_Name.Text = Convert.ToString(objACI_Contact.Last_name);
            txtAci_Contact_Phone.Text = Convert.ToString(objACI_Contact.Phone);
            txtAci_Contact_Email.Text = Convert.ToString(objACI_Contact.Email);

            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtAci_Contact_First_Name);
        }
        else if (e.CommandName == "DeleteRecord")
        {
            _PK_ID_ACI = Convert.ToDecimal(e.CommandArgument);

            clsManagement_ACI_Contact.DeleteByPK(_PK_ID_ACI);
            BindACIGrid();
        }
    }

    /// <summary>
    /// Handle Row Data Bound of Store Contact grid 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvACIContact_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (StrOperation.ToLower() == "edit")
            {
                ((LinkButton)e.Row.Cells[0].FindControl("lnkEdit")).Visible = (App_Access == AccessType.Administrative_Access);//App_Access == AccessType.Edit ||
                ((LinkButton)e.Row.Cells[0].FindControl("lnkDelete")).Visible = (App_Access == AccessType.Delete || App_Access == AccessType.Administrative_Access);
            }
        }
    }

    #endregion
    
}