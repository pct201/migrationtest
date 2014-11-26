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

public partial class SONIC_Purchasing_ServiceContract : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes Primary key value for Purchasing Service Contract
    /// </summary>
    public int PK_Purchasing_Service_Contract
    {
        get { return clsGeneral.GetInt(ViewState["PK_Purchasing_Service_Contract"]); }
        set { ViewState["PK_Purchasing_Service_Contract"] = value; }
    }

    /// <summary>
    /// Denotes operation either view or edit
    /// </summary>
    public string StrOperation
    {
        get
        {
            return clsSession.Str_ServiceContract_Operation;
        }
    }

    #endregion

    #region "Page Event"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Attachment.btnHandler += new Controls_Attachments_Attachment.OnButtonClick(Upload_File);
        if (!IsPostBack)
        {
            // set the primary key 
            clsSession.Current_Purchasing_Service_Contract_ID = PK_Purchasing_Service_Contract = 0;

            // if operation is set to add then set the controls accordingly
            if (!String.IsNullOrEmpty(Request.QueryString["op"]))
            {
                if (Convert.ToString(Request.QueryString["op"]) == "add")
                {
                    clsSession.Str_ServiceContract_Operation = "add";
                    tdAbstractReport.Visible = false;
                    btnLAAudit_View.Visible = false;
                    btnVAbstractReport.Visible = false;
                }
                else if (Convert.ToString(Request.QueryString["op"]) == "view")
                {
                    // set controls and data in view mode
                    btnNextStepView.Visible = true;
                    btnLAAudit_View.Visible = true;
                    btnVAbstractReport.Visible = true;
                    setControlsView();
                }
            }
            else
            {
                // if ID is passed in querystring then set the PK and controls
                if (!clsGeneral.IsNull(Request.QueryString["id"]))
                {
                    int index;
                    if (int.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                        clsSession.Current_Purchasing_Service_Contract_ID = PK_Purchasing_Service_Contract = index;
                    else
                    {
                        clsSession.Str_ServiceContract_Operation = "add";
                        btnVAbstractReport.Visible = false;
                        btnLAAudit_View.Visible = false;
                    }
                }
                else
                {
                    clsSession.Str_ServiceContract_Operation = "add";
                    btnVAbstractReport.Visible = false;
                    btnLAAudit_View.Visible = false;
                }
            }

            // check rights for the user
            CheckUserRights();

            // if page is not in add mode
            if (clsSession.Str_ServiceContract_Operation != "add")
            {
                // if view mode
                if (clsSession.Str_ServiceContract_Operation == "view")
                {
                    // set controls and data in view mode
                    btnNextStepView.Visible = true;
                    btnLAAudit_View.Visible = true;
                    btnVAbstractReport.Visible = true;
                    setControlsView();
                }
                else
                {
                    // bind all dropdowns
                    BindDropDown();

                    // if PK is available
                    if (PK_Purchasing_Service_Contract > 0)
                    {
                        btnLAAudit_View.Visible = false;
                        btnVAbstractReport.Visible = false;
                        tdAbstractReport.Visible = true;
                        tdAuditTrial.Visible = true;
                        setControlsEdit();
                    }
                    else
                        PurchasingTab.Visible = false;
                }
            }
            else
            {
                Attachment.ShowAttachmentButton = false;
                PurchasingTab.Visible = false;
                BindDropDown();
            }
            BindGridView();
            Purchasing_SearchTAB.StrRedirectTo = "";
            // set panel
            // check for the querystring whether panel number is passed 
            // otherwise display first panel
            if (!clsGeneral.IsNull(Request.QueryString["pnl"]))
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + Request.QueryString["pnl"] + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            if (clsSession.Str_ServiceContract_Operation != "view")
                SetValidations();
        }
        if (Purchasing_SearchTAB.Visible)
            Purchasing_SearchTAB.SetSelectedTab(CtrlPurchasing_Search.Tab.Purchasing);
    }

    #endregion

    #region "Grid Events"

    /// <summary>
    /// Handle Row Command Event of Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDealeshipDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        decimal intPKID = Convert.ToDecimal(e.CommandArgument);
        if (e.CommandName.ToString() == "remove")
        {
            if (intPKID > 0)
            {
                Purchasing_SC_Department.DeleteByPK(intPKID);
                BindGridView();
                PurchasingTab.BindIdentificationInformation();
                //gvDealeshipDepartment.DataSource = Purchasing_SC_Department.SelectAllByServiceContract(PK_Purchasing_Service_Contract, string.Empty);
                //gvDealeshipDepartment.DataBind();
            }
        }
        else if (e.CommandName.ToString() == "edititem")
        {
            SaveData();
            Response.Redirect("DealershipDepartment.aspx?id=" + Encryption.Encrypt(intPKID.ToString()), true);
        }
        // show the panel in which the carrier grid exists as the page is loaded again
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    /// <summary>
    /// Handle Datarow Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDealeshipDepartment_DataRowBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdCount = (HiddenField)e.Row.FindControl("hdCount");
            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkRemove");

            int intCount = Convert.ToInt32(hdCount.Value);
            lnkDelete.Attributes.Add("onclick", "return ConfirmDeleteSubRecord(" + intCount + ");");
        }
    }

    /// <summary>
    /// Handle Row Command Event of Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDealershipGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        decimal intPKID = Convert.ToDecimal(e.CommandArgument);
        if (e.CommandName.ToString() == "remove")
        {
            if (intPKID > 0)
            {
                Purchasing_SC_Dealer.DeleteByPK(intPKID);
                //gvDealershipGrid.DataSource = Purchasing_SC_Dealer.SelectByServiceContract(PK_Purchasing_Service_Contract, string.Empty);
                //gvDealershipGrid.DataBind();
                BindGridView();
                PurchasingTab.BindIdentificationInformation();
            }
        }
        else if (e.CommandName.ToString() == "edititem")
        {
            SaveData();
            Response.Redirect("Dealership.aspx?id=" + Encryption.Encrypt(intPKID.ToString()), true);
        }
        // show the panel in which the carrier grid exists as the page is loaded again
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    /// <summary>
    /// Handle Datarow Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDealershipGrid_DataRowBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdCount = (HiddenField)e.Row.FindControl("hdCount");
            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkRemove");

            int intCount = Convert.ToInt32(hdCount.Value);
            lnkDelete.Attributes.Add("onclick", "return ConfirmDeleteSubRecord(" + intCount + ");");
        }
    }

    /// <summary>
    /// Handle Row Command Event of Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvApplicableAssets_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        decimal intPKID = Convert.ToDecimal(e.CommandArgument);
        if (e.CommandName.ToString() == "remove")
        {
            if (intPKID > 0)
            {
                Purchasing_SC_Asset.DeleteByPK(intPKID);
                BindGridView();
                //gvApplicableAssets.DataSource = Purchasing_SC_Asset.SelectByFK_Service_Contract(PK_Purchasing_Service_Contract, string.Empty);
                //gvApplicableAssets.DataBind();
            }
        }
        else if (e.CommandName.ToString() == "edititem")
        {
            SaveData();
            Response.Redirect("Asset.aspx?id=" + Encryption.Encrypt(intPKID.ToString()), true);
        }
        // show the panel in which the carrier grid exists as the page is loaded again
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    /// <summary>
    /// Handle Row Command Event og\f Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNotesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "remove")
        {
            decimal intPKID = Convert.ToDecimal(e.CommandArgument);

            if (intPKID > 0)
            {
                Purchasing_SC_Notes.DeleteByPK(intPKID);
                gvNotesGrid.DataSource = Purchasing_SC_Notes.SelectAllByServiceContract(PK_Purchasing_Service_Contract);
                gvNotesGrid.DataBind();
            }
        }
        // show the panel in which the carrier grid exists as the page is loaded again
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }
    /// <summary>
    /// Handle Row Command Event og\f Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSuppiler_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        decimal intPKID = Convert.ToDecimal(e.CommandArgument);
        if (e.CommandName.ToString() == "remove")
        {
            if (intPKID > 0)
            {
                Purchasing_Contacts_Link.DeleteByPK(intPKID);
                BindGridView();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
            }
        }
    }

    /// <summary>
    /// Handles event when rowdata is bound in Supplier grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSuppiler_DataRowBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strState = "", strZipCode = "", strCity = "", strAddress1 = "", strAddress2 = "";
            string strContactDetail = "";
            strCity = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "City"));
            strState = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FLD_abbreviation"));
            strZipCode = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ZIP_Code"));
            strAddress1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_1"));
            strAddress2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_2"));
            if (strAddress1 != "")
            {
                ((Label)e.Row.FindControl("lblAddress1")).Text = strAddress1 + "</br>";
            }
            if (strAddress2 != "")
            {
                ((Label)e.Row.FindControl("lblAddress2")).Text = strAddress2 + "</br>";
            }
            if (strCity != "")
            {
                if (strState != "")
                {
                    strContactDetail = strCity + ", " + strState + " " + strZipCode;
                    ((Label)e.Row.FindControl("lblContactDeatail")).Text = strContactDetail;
                }
                else
                {
                    strContactDetail = strCity + " " + strZipCode;
                    ((Label)e.Row.FindControl("lblContactDeatail")).Text = strContactDetail;
                }
            }
            else
            {
                strContactDetail = strState + " " + strZipCode;
                ((Label)e.Row.FindControl("lblContactDeatail")).Text = strContactDetail;
            }
        }
    }
    /// <summary>
    /// Handle Row Command Event of Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSonic_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        decimal intPKID = Convert.ToDecimal(e.CommandArgument);
        if (e.CommandName.ToString() == "remove")
        {
            if (intPKID > 0)
            {
                Purchasing_Contacts_Link.DeleteByPK(intPKID);
                BindGridView();
                // show the panel in which the carrier grid exists as the page is loaded again
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
            }
        }
    }

    /// <summary>
    /// Handles event when rowdata is bound to sonic grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSonic_DataRowBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strState = "", strZipCode = "", strCity = "", strAddress1 = "", strAddress2 = "";
            string strContactDetail = "";
            strCity = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "City"));
            strState = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FLD_abbreviation"));
            strZipCode = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ZIP_Code"));
            strAddress1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_1"));
            strAddress2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_2"));
            if (strAddress1 != "")
            {
                ((Label)e.Row.FindControl("lblAddress1")).Text = strAddress1 + "</br>";
            }
            if (strAddress2 != "")
            {
                ((Label)e.Row.FindControl("lblAddress2")).Text = strAddress2 + "</br>";
            }
            if (strCity != "")
            {
                if (strState != "")
                {
                    strContactDetail = strCity + ", " + strState + " " + strZipCode;
                    ((Label)e.Row.FindControl("lblSonicContactDeatail")).Text = strContactDetail;
                }
                else
                {
                    strContactDetail = strCity + " " + strZipCode;
                    ((Label)e.Row.FindControl("lblSonicContactDeatail")).Text = strContactDetail;
                }
            }
            else
            {
                strContactDetail = strState + " " + strZipCode;
                ((Label)e.Row.FindControl("lblSonicContactDeatail")).Text = strContactDetail;
            }
        }
    }

    /// <summary>
    /// Handles event when rowdata is bound to supplier grid in view mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSupplierView_DataRowBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strState = "", strZipCode = "", strCity = "", strAddress1 = "", strAddress2 = "";
            string strContactDetail = "";
            strCity = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "City"));
            strState = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FLD_abbreviation"));
            strZipCode = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ZIP_Code"));
            strAddress1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_1"));
            strAddress2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_2"));
            if (strAddress1 != "")
            {
                ((Label)e.Row.FindControl("lblAddress1View")).Text = strAddress1 + "</br>";
            }
            if (strAddress2 != "")
            {
                ((Label)e.Row.FindControl("lblAddress2View")).Text = strAddress2 + "</br>";
            }
            if (strCity != "")
            {
                if (strState != "")
                {
                    strContactDetail = strCity + ", " + strState + " " + strZipCode;
                    ((Label)e.Row.FindControl("lblSupplierContactDeatailView")).Text = strContactDetail;
                }
                else
                {
                    strContactDetail = strCity + " " + strZipCode;
                    ((Label)e.Row.FindControl("lblSupplierContactDeatailView")).Text = strContactDetail;
                }
            }
            else
            {
                strContactDetail = strState + " " + strZipCode;
                ((Label)e.Row.FindControl("lblSupplierContactDeatailView")).Text = strContactDetail;
            }
        }
    }

    /// <summary>
    /// Handles event when rowdata is bound to sonic grid in view mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSonicView_DataRowBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strState = "", strZipCode = "", strCity = "", strAddress1 = "", strAddress2 = "";
            string strContactDetail = "";
            strCity = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "City"));
            strState = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FLD_abbreviation"));
            strZipCode = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ZIP_Code"));
            strAddress1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_1"));
            strAddress2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_2"));
            if (strAddress1 != "")
            {
                ((Label)e.Row.FindControl("lblSonicAddress1View")).Text = strAddress1 + "</br>";
            }
            if (strAddress2 != "")
            {
                ((Label)e.Row.FindControl("lblSonicAddress2View")).Text = strAddress2 + "</br>";
            }
            if (strCity != "")
            {
                if (strState != "")
                {
                    strContactDetail = strCity + ", " + strState + " " + strZipCode;
                    ((Label)e.Row.FindControl("lblSonicContactDeatailView")).Text = strContactDetail;
                }
                else
                {
                    strContactDetail = strCity + " " + strZipCode;
                    ((Label)e.Row.FindControl("lblSonicContactDeatailView")).Text = strContactDetail;
                }
            }
            else
            {
                strContactDetail = strState + " " + strZipCode;
                ((Label)e.Row.FindControl("lblSonicContactDeatailView")).Text = strContactDetail;
            }
        }
    }
    #endregion

    #region "Events"

    /// <summary>
    /// Handles DealerShip Department grid add link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkDealshipDepartment_Click(object sender, EventArgs e)
    {
        // saves data
        SaveData();
        clsSession.Str_ServiceContract_Operation = "edit";
        //redirect to Executive risk carrier page
        Response.Redirect(AppConfig.SiteURL + "SONIC/Purchasing/DealershipDepartment.aspx");
    }

    /// <summary>
    /// Handles DealerShip Grid grid add link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkDealershipGrid_Click(object sender, EventArgs e)
    {
        // saves data
        SaveData();
        clsSession.Str_ServiceContract_Operation = "edit";
        //redirect to Executive risk carrier page
        Response.Redirect(AppConfig.SiteURL + "SONIC/Purchasing/Dealership.aspx");
    }

    /// <summary>
    /// Handles Applicable Assets grid add link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkApplicableAssets_Click(object sender, EventArgs e)
    {
        // saves data
        SaveData();
        clsSession.Str_ServiceContract_Operation = "edit";
        //redirect to Executive risk carrier page
        Response.Redirect(AppConfig.SiteURL + "SONIC/Purchasing/Asset.aspx");
    }

    /// <summary>
    /// Handles Notes grid add link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lblAddNotes_Click(object sender, EventArgs e)
    {
        // saves data
        SaveData();
        clsSession.Str_ServiceContract_Operation = "edit";
        //redirect to Executive risk carrier page
        Response.Redirect(AppConfig.SiteURL + "SONIC/Purchasing/ServiceContractNote.aspx");
    }

    /// <summary>
    /// Handles Add Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Upload_File(string strValue)
    {
        if (PK_Purchasing_Service_Contract > 0)
        {
            // add the attachment 
            Attachment.Add(clsGeneral.Tables.Purchasing_Service_Contract, PK_Purchasing_Service_Contract);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
        }
    }

    /// <summary>
    /// handle Save data for Service Contract
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        //save data
        SaveData();

        // update the session variable for operation for view
        clsSession.Str_ServiceContract_Operation = "view";

        // open the page in view mode
        Response.Redirect("ServiceContract.aspx?id=" + Encryption.Encrypt(PK_Purchasing_Service_Contract.ToString()));
    }

    /// <summary>
    /// Handle Next setp process add/edit or View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNextStep_Click(object sender, EventArgs e)
    {
        SaveData();
        // update the session variable for operation for view
        clsSession.Str_ServiceContract_Operation = "view";

        // open the page in view mode
        Response.Redirect("ServiceContract.aspx?id=" + Encryption.Encrypt(PK_Purchasing_Service_Contract.ToString()));
    }

    /// <summary>
    /// Handle Back step
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // open the page in eidt mode
        clsSession.Str_ServiceContract_Operation = "edit";
        Response.Redirect("ServiceContract.aspx?id=" + Encryption.Encrypt(PK_Purchasing_Service_Contract.ToString()));
    }

    /// <summary>
    /// Handle next step event for View mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNextStepView_Click(object sender, EventArgs e)
    {

    }
    protected void btnPK_Click(object sender, EventArgs e)
    {
        BindGridView();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }

    #endregion

    #region "Methods"
    /// <summary>
    /// Bind dropdown list
    /// </summary>
    private void BindDropDown()
    {
        //Contract Level

        drpContractLevel.DataSource = LU_Service_Contract.selectAll();
        drpContractLevel.DataTextField = "Fld_Desc";
        drpContractLevel.DataValueField = "PK_LU_Service_Contract";
        drpContractLevel.DataBind();

        drpContractLevel.Items.Insert(0, new ListItem("--Select--", "0"));

        //Auto Renue
        drpAutoRenueOptions.DataSource = LU_Auto_Renue.AutoRenewOptionSelectAll();
        drpAutoRenueOptions.DataTextField = "Fld_Desc";
        drpAutoRenueOptions.DataValueField = "PK_LU_Auto_Renew";
        drpAutoRenueOptions.DataBind();

        drpAutoRenueOptions.Items.Insert(0, new ListItem("--Select--", "0"));

        //Notification Methods
        drpNotificationMethod.DataSource = LU_Notification_Method.NotificationMethodsSelectAll();
        drpNotificationMethod.DataTextField = "Fld_Desc";
        drpNotificationMethod.DataValueField = "PK_LU_Notification_Method";
        drpNotificationMethod.DataBind();

        drpNotificationMethod.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    /// <summary>
    /// save data add or update
    /// </summary>
    private void SaveData()
    {
        if (Page.IsValid)
        {
            // create object for the executive risk record
            PurchasingServiceContract objServiceContract = new PurchasingServiceContract();

            // get the values from the page controls
            objServiceContract.PK_Purchasing_Service_Contract = PK_Purchasing_Service_Contract;
            objServiceContract.Supplier = txtSupplier.Text.Trim();
            objServiceContract.Service_Type = txtServiceType.Text.Trim();
            objServiceContract.Start_Date = clsGeneral.FormatNullDateToStore(txtStartDate.Text.Trim());
            objServiceContract.End_Date = clsGeneral.FormatNullDateToStore(txtEndDate.Text.Trim());
            objServiceContract.Term_In_Months = (txtTermInMonths.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txtTermInMonths.Text.Trim()));
            objServiceContract.Service_Frequency = txtServiceFrequency.Text.Trim();
            objServiceContract.Monthly_Cost = (txtMonthlyCost.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txtMonthlyCost.Text.Trim()));
            objServiceContract.Annual_Cost = (txtAnnualCost.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txtAnnualCost.Text.Trim()));
            objServiceContract.Total_Committed = (txtTotalCommitted.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txtTotalCommitted.Text.Trim()));
            objServiceContract.FK_LU_Service_Contract = Convert.ToDecimal(drpContractLevel.SelectedValue);
            objServiceContract.Legal_Confidential = rdoLegalConfidential.SelectedValue;
            objServiceContract.FK_LU_Auto_Renew = Convert.ToDecimal(drpAutoRenueOptions.SelectedValue);
            objServiceContract.Customer_Contract_Number = Convert.ToString(txtCustomerContractNumber.Text.Trim());
            objServiceContract.Auto_Renew_Other = txtAutorenueOther.Text.Trim();
            objServiceContract.Notification_Method = Convert.ToDecimal(drpNotificationMethod.SelectedValue);
            objServiceContract.Notification_Date = clsGeneral.FormatNullDateToStore(txtNotificationDate.Text.Trim());
            objServiceContract.Notification_Content = txtContractNotes.Text.Trim();
            objServiceContract.Renewal_Terms = "";
            objServiceContract.Notification_Terms = "";
            //objServiceContract.Applicable_Dealers = txtApplicableDealers.Text.Trim();
            objServiceContract.Update_Date = DateTime.Now;
            objServiceContract.Updated_By = clsSession.UserID.ToString();
            objServiceContract.Status = ddlStatus.SelectedIndex > 0 ? ddlStatus.SelectedValue : null;
            objServiceContract.COI_Needed = Convert.ToString(rdbCOINeed.SelectedValue);

            // update or insert the data according to the primary key
            if (PK_Purchasing_Service_Contract > 0)
            {
                objServiceContract.Update();
            }
            else
            {
                PK_Purchasing_Service_Contract = objServiceContract.Insert();
            }
            Upload_File(string.Empty);
            clsSession.Current_Purchasing_Service_Contract_ID = PK_Purchasing_Service_Contract;
        }
    }

    /// <summary>
    /// set controls(textbox and grid) for edit operation
    /// </summary>
    private void setControlsEdit()
    {
        PurchasingServiceContract objServiceContract = new PurchasingServiceContract();
        if (objServiceContract.View(PK_Purchasing_Service_Contract))
        {
            txtSupplier.Text = objServiceContract.Supplier.ToString();
            txtServiceType.Text = objServiceContract.Service_Type;
            txtStartDate.Text = (objServiceContract.Start_Date == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue ? string.Empty : clsGeneral.FormatDBNullDateToDisplay(objServiceContract.Start_Date));
            txtEndDate.Text = (objServiceContract.End_Date == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue ? string.Empty : clsGeneral.FormatDBNullDateToDisplay(objServiceContract.End_Date));
            txtTermInMonths.Text = clsGeneral.GetStringValue(objServiceContract.Term_In_Months).Replace(".00", "");
            txtServiceFrequency.Text = objServiceContract.Service_Frequency;
            txtMonthlyCost.Text = clsGeneral.GetStringValue(objServiceContract.Monthly_Cost);
            txtAnnualCost.Text = clsGeneral.GetStringValue(objServiceContract.Annual_Cost);
            txtCustomerContractNumber.Text = Convert.ToString(objServiceContract.Customer_Contract_Number);
            drpContractLevel.SelectedValue = objServiceContract.FK_LU_Service_Contract.ToString();
            txtTotalCommitted.Text = clsGeneral.GetStringValue(objServiceContract.Total_Committed);
            rdoLegalConfidential.SelectedValue = objServiceContract.Legal_Confidential.ToString();
            drpAutoRenueOptions.SelectedValue = objServiceContract.FK_LU_Auto_Renew.ToString();
            if (drpAutoRenueOptions.SelectedItem.Text.ToLower().Trim() == "other")
            {
                txtAutorenueOther.Enabled = true;
            }
            txtAutorenueOther.Text = objServiceContract.Auto_Renew_Other.ToString();
            drpNotificationMethod.SelectedValue = objServiceContract.Notification_Method.ToString();
            txtNotificationDate.Text = (objServiceContract.Notification_Date == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue ? string.Empty : clsGeneral.FormatDBNullDateToDisplay(objServiceContract.Notification_Date));
            txtContractNotes.Text = objServiceContract.Notification_Content.ToString();
            //txtApplicableDealers.Text = objServiceContract.Applicable_Dealers;
            ddlStatus.SelectedValue = objServiceContract.Status.ToString();
            rdbCOINeed.SelectedValue = Convert.ToString(objServiceContract.COI_Needed);
        }
    }

    /// <summary>
    /// set controls(textbox and grid) for view operation
    /// </summary>
    private void setControlsView()
    {
        PurchasingServiceContract objServiceContract = new PurchasingServiceContract();
        if (objServiceContract.View(PK_Purchasing_Service_Contract))
        {
            lblSupplier.Text = objServiceContract.Supplier.ToString();
            lblServiceType.Text = objServiceContract.Service_Type;
            lblStartDate.Text = clsGeneral.FormatDBNullDateToDisplay(objServiceContract.Start_Date);
            lblEndDate.Text = clsGeneral.FormatDBNullDateToDisplay(objServiceContract.End_Date);
            lblTermInMonth.Text = objServiceContract.Term_In_Months.ToString().Replace(".00", "");
            lblServiceFrequency.Text = objServiceContract.Service_Frequency;
            lblMonthlyCost.Text = "$ " + clsGeneral.GetStringValue(objServiceContract.Monthly_Cost);
            lblAnnualCost.Text = "$ " + clsGeneral.GetStringValue(objServiceContract.Annual_Cost);
            lblTotalCommitted.Text = "$ " + clsGeneral.GetStringValue(objServiceContract.Total_Committed);
            lblLegalConfidential.Text = (objServiceContract.Legal_Confidential.ToString()) == "Y" ? "Yes" : "No";
            lblCustomerContractorNumber.Text = Convert.ToString(objServiceContract.Customer_Contract_Number);
            lblAutorenueOther.Text = objServiceContract.Auto_Renew_Other.ToString();
            lblNotificationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objServiceContract.Notification_Date);
            lblContractNote.Text = objServiceContract.Notification_Content.ToString();
            //lblApplicableDealers.Text = objServiceContract.Applicable_Dealers;
            lblControlLevel.Text = new LU_Service_Contract(objServiceContract.FK_LU_Service_Contract).Fld_Desc;
            lblAutoRenew.Text = new LU_Auto_Renue(objServiceContract.FK_LU_Auto_Renew).Fld_Desc;
            lblNotificationMethod.Text = new LU_Notification_Method(objServiceContract.Notification_Method).Fld_Desc;
            lblStatus.Text = objServiceContract.Status;
            lblCOINeeded.Text = objServiceContract.COI_Needed.ToUpper() == "Y" ? "Yes" : "No";
        }
    }

    /// <summary>
    /// Bind grid views as per operation mode
    /// </summary>
    private void BindGridView()
    {
        if (clsSession.Str_ServiceContract_Operation == "view")
        {
            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Purchasing_Service_Contract, PK_Purchasing_Service_Contract, false, 4);
            gvNotesGridView.DataSource = Purchasing_SC_Notes.SelectAllByServiceContract(PK_Purchasing_Service_Contract);
            gvNotesGridView.DataBind();

            gvDealeshipDepartmentView.DataSource = Purchasing_SC_Department.SelectAllByServiceContract(PK_Purchasing_Service_Contract, string.Empty);
            gvDealeshipDepartmentView.DataBind();

            gvDealershipGridView.DataSource = Purchasing_SC_Dealer.SelectByServiceContract(PK_Purchasing_Service_Contract, string.Empty);
            gvDealershipGridView.DataBind();

            gvApplicableAssetsView.DataSource = Purchasing_SC_Asset.SelectByFK_Service_Contract(PK_Purchasing_Service_Contract, string.Empty);
            gvApplicableAssetsView.DataBind();

            gvSupplierView.DataSource = Purchasing_LR_Agreement.GetPurchasing_SonicAndSupplier_ContactInformation(PK_Purchasing_Service_Contract, 2, "SC");
            gvSupplierView.DataBind();

            gvSonicView.DataSource = Purchasing_LR_Agreement.GetPurchasing_SonicAndSupplier_ContactInformation(PK_Purchasing_Service_Contract, 1, "SC");
            gvSonicView.DataBind();
        }
        else
        {
            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Purchasing_Service_Contract, PK_Purchasing_Service_Contract, true, 4);
            if (PK_Purchasing_Service_Contract > 0)
            {
                gvDealeshipDepartment.DataSource = Purchasing_SC_Department.SelectAllByServiceContract(PK_Purchasing_Service_Contract, string.Empty);
                gvDealershipGrid.DataSource = Purchasing_SC_Dealer.SelectByServiceContract(PK_Purchasing_Service_Contract, string.Empty);
                gvNotesGrid.DataSource = Purchasing_SC_Notes.SelectAllByServiceContract(PK_Purchasing_Service_Contract);
                gvApplicableAssets.DataSource = Purchasing_SC_Asset.SelectByFK_Service_Contract(PK_Purchasing_Service_Contract, string.Empty);
                gvSuppiler.DataSource = Purchasing_LR_Agreement.GetPurchasing_SonicAndSupplier_ContactInformation(PK_Purchasing_Service_Contract, 2, "SC");
                gvSonic.DataSource = Purchasing_LR_Agreement.GetPurchasing_SonicAndSupplier_ContactInformation(PK_Purchasing_Service_Contract, 1, "SC");
            }
            else
            {
                gvDealeshipDepartment.DataSource = null;
                gvDealershipGrid.DataSource = null;
                gvNotesGrid.DataSource = null;
                gvApplicableAssets.DataSource = null;
                gvSuppiler.DataSource = null;
                gvSonic.DataSource = null;
            }
            gvDealeshipDepartment.DataBind();
            gvDealershipGrid.DataBind();
            gvNotesGrid.DataBind();
            gvApplicableAssets.DataBind();
            gvSuppiler.DataBind();
            gvSonic.DataBind();
        }
        BindAttachmentDetails();
    }

    /// <summary>
    /// Binds the attachment details
    /// </summary>
    private void BindAttachmentDetails()
    {
        //dvAttachment.Style["Display"] = "block";         
        AttachDetails.Bind();
    }

    /// <summary>
    /// check user rights
    /// </summary>
    private void CheckUserRights()
    {
        if (clsSession.Str_ServiceContract_Operation == "view")
        {
            btnBack.Visible = true;
        }
        if (App_Access == AccessType.View_Only)
        {
            if (clsSession.Str_ServiceContract_Operation != "view")
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
            }
            else
            {
                PurchasingServiceContract objServiceContract = new PurchasingServiceContract();
                objServiceContract.View(PK_Purchasing_Service_Contract);
                if (objServiceContract.Legal_Confidential.ToLower().Trim() == "y")
                {
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
                }
            }
            btnBack.Visible = false;
        }
        else
        {
            if (App_Access == AccessType.Purchasing_Edit)
            {
                if (PK_Purchasing_Service_Contract > 0)
                {
                    PurchasingServiceContract objServiceContract = new PurchasingServiceContract();
                    objServiceContract.View(PK_Purchasing_Service_Contract);
                    if (objServiceContract.Legal_Confidential.ToLower().Trim() == "y")
                    {
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
                    }
                }
                rdoLegalConfidential.Enabled = false;
            }
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

        #region "Service Contract"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(92).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk1 = (Label)mnuServiceContract.Controls[0].FindControl("MenuAsterisk");
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 92").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Supplier":
                    strCtrlsIDs += txtSupplier.ClientID + ",";
                    strMessages += "Please enter [Service Contract]/Supplier" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Service Type":
                    strCtrlsIDs += txtServiceType.ClientID + ",";
                    strMessages += "Please enter [Service Contract]/Service Type" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Start Date":
                    strCtrlsIDs += txtStartDate.ClientID + ",";
                    strMessages += "Please enter [Service Contract]/Start Date" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "End Date":
                    strCtrlsIDs += txtEndDate.ClientID + ",";
                    strMessages += "Please enter [Service Contract]/End Date" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Term in Months":
                    strCtrlsIDs += txtTermInMonths.ClientID + ",";
                    strMessages += "Please enter [Service Contract]/Term in Months" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Service Frequency":
                    strCtrlsIDs += txtServiceFrequency.ClientID + ",";
                    strMessages += "Please enter [Service Contract]/Service Frequency" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Monthly Cost":
                    strCtrlsIDs += txtMonthlyCost.ClientID + ",";
                    strMessages += "Please enter [Service Contract]/Monthly Cost" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Annual Cost":
                    strCtrlsIDs += txtAnnualCost.ClientID + ",";
                    strMessages += "Please enter [Service Contract]/Annual Cost" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Contract Level":
                    strCtrlsIDs += drpContractLevel.ClientID + ",";
                    strMessages += "Please select [Service Contract]/Contract Level" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Total Committed $":
                    strCtrlsIDs += txtTotalCommitted.ClientID + ",";
                    strMessages += "Please enter [Service Contract]/Total Committed $" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Customer/Contract Number":
                    strCtrlsIDs += txtCustomerContractNumber.ClientID + ",";
                    strMessages += "Please enter [Service Contract]/Customer/Contract Number" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Auto Renew Options":
                    strCtrlsIDs += drpAutoRenueOptions.ClientID + ",";
                    strMessages += "Please select [Service Contract]/Auto Renew Options" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Auto Renew Other":
                    strCtrlsIDs += txtAutorenueOther.ClientID + ",";
                    strMessages += "Please enter [Service Contract]/Auto Renew Other" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "Notification Method":
                    strCtrlsIDs += drpNotificationMethod.ClientID + ",";
                    strMessages += "Please select [Service Contract]/Notification Method" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "Notification Date":
                    strCtrlsIDs += txtNotificationDate.ClientID + ",";
                    strMessages += "Please enter [Service Contract]/Notification Date" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                case "Status":
                    strCtrlsIDs += ddlStatus.ClientID + ",";
                    strMessages += "Please select [Service Contract]/Status" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                case "Contract Notes":
                    strCtrlsIDs += txtContractNotes.ClientID + ",";
                    strMessages += "Please enter [Service Contract]/Contract Notes" + ",";
                    Span17.Style["display"] = "inline-block";
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
