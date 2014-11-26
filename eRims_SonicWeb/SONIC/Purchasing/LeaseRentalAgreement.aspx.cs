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

public partial class SONIC_Purchasing_LeaseRentalAgreement : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes Primary key value for Executive Risk record
    /// </summary>
    public int PK_Purchasing_LR_Agreement
    {
        get { return clsGeneral.GetInt(ViewState["PK_Purchasing_LR_Agreement"]); }
        set { ViewState["PK_Purchasing_LR_Agreement"] = value; }
    }

    /// <summary>
    /// Denotes operation either view or edit
    /// </summary>
    public string StrOperation
    {
        get
        {
            return clsSession.Str_LR_Agreement_Operation;
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
            clsSession.Current_LR_Agreement_ID = PK_Purchasing_LR_Agreement = 0;
            if (!String.IsNullOrEmpty(Request.QueryString["op"]))
            {
                if (Convert.ToString(Request.QueryString["op"]) == "add")
                {
                    clsSession.Str_LR_Agreement_Operation = "add";
                    btnLAAudit.Visible = false;
                    btnLAAudit_View.Visible = false;
                }
            }
            else
            {
                if (!clsGeneral.IsNull(Request.QueryString["id"]))
                {
                    int index;
                    if (int.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                        clsSession.Current_LR_Agreement_ID = PK_Purchasing_LR_Agreement = index;
                    else
                        clsSession.Str_LR_Agreement_Operation = "add";
                }
                else
                    clsSession.Str_LR_Agreement_Operation = "add";
            }
            CheckUserRights();
            if (clsSession.Str_LR_Agreement_Operation != "add")
            {
                if (clsSession.Str_LR_Agreement_Operation == "view")
                {
                    btnNextStepView.Visible = true;
                    btnVAbstractReport.Visible = true;
                    btnLAAudit.Visible = false;
                    btnLAAudit_View.Visible = true;
                    setControlsView();
                }
                else
                {
                    BindDropDown();
                    if (PK_Purchasing_LR_Agreement > 0)
                    {
                        btnLAAudit.Visible = true;
                        btnLAAudit_View.Visible = false;
                        tdAbstractReport.Visible = true;
                        tdAudit.Visible = true;
                        setControlsEdit();
                    }
                    else
                        LR_ArgreementTAB.Visible = false;
                }
            }
            else
            {
                BindDropDown();
                Attachment.ShowAttachmentButton = false;
                LR_ArgreementTAB.Visible = false;
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

            if (clsSession.Str_LR_Agreement_Operation != "view")
                SetValidations();

        }
        if (Purchasing_SearchTAB.Visible)
            Purchasing_SearchTAB.SetSelectedTab(CtrlPurchasing_Search.Tab.Purchasing);
    }

    #endregion

    #region "Grid Events"

    /// <summary>
    /// Handle Grid Row comand - Notes 
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
                Purchasing_LR_Note.DeleteByPK(intPKID);
                gvNotesGrid.DataSource = Purchasing_LR_Note.SelectByFK_LR(PK_Purchasing_LR_Agreement);
                gvNotesGrid.DataBind();
            }
        }
        // show the panel in which the carrier grid exists as the page is loaded again
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }

    /// <summary>
    /// Handle Grid Row comand - Applicable Assets 
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
                Purchasing_LR_Asset.DeleteByPK(intPKID);
                gvApplicableAssets.DataSource = Purchasing_LR_Asset.SelectByFK_LR(PK_Purchasing_LR_Agreement, string.Empty);
                gvApplicableAssets.DataBind();
            }
        }
        else if (e.CommandName.ToString() == "edititem")
        {
            SaveData();
            Response.Redirect("LR_Asset.aspx?id=" + Encryption.Encrypt(intPKID.ToString()), true);
        }
        // show the panel in which the carrier grid exists as the page is loaded again
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    /// <summary>
    /// Handle Row Command Event og\f Grid
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
                Purchasing_LR_Dealer.DeleteByPK(intPKID);
                BindGridView();

            }
        }
        else if (e.CommandName.ToString() == "edititem")
        {
            SaveData();
            Response.Redirect("LRDealership.aspx?id=" + Encryption.Encrypt(intPKID.ToString()), true);
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
    /// Handle Row Command Event og\f Grid
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
    /// Handle add attachment event for lease rental agreement
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Upload_File(string strValue)
    {
        if (PK_Purchasing_LR_Agreement > 0)
        {
            // add the attachment 
            Attachment.Add(clsGeneral.Tables.Purchasing_LR_Agreement, PK_Purchasing_LR_Agreement);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
        }
    }

    /// <summary>
    /// Handle add note click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lblAddNotes_Click(object sender, EventArgs e)
    {
        // saves data
        SaveData();
        clsSession.Str_LR_Agreement_Operation = "edit";
        //redirect to Executive risk carrier page
        Response.Redirect(AppConfig.SiteURL + "SONIC/Purchasing/LR_Notes.aspx");
    }


    /// <summary>
    /// Handle Add asset click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkApplicableAssets_Click(object sender, EventArgs e)
    {
        // saves data
        SaveData();
        clsSession.Str_LR_Agreement_Operation = "edit";
        //redirect to Executive risk carrier page
        Response.Redirect(AppConfig.SiteURL + "SONIC/Purchasing/LR_Asset.aspx");
    }

    /// <summary>
    /// handle sevas data event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        //save data
        SaveData();

        // update the session variable for operation for view
        clsSession.Str_LR_Agreement_Operation = "view";

        // open the page in view mode
        Response.Redirect("LeaseRentalAgreement.aspx?id=" + Encryption.Encrypt(PK_Purchasing_LR_Agreement.ToString()));
    }

    /// <summary>
    /// Handle Next setp button event in edit /add mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNextStep_Click(object sender, EventArgs e)
    {
        //save data
        SaveData();

        // update the session variable for operation for view
        clsSession.Str_LR_Agreement_Operation = "view";

        // open the page in view mode
        Response.Redirect("LeaseRentalAgreement.aspx?id=" + Encryption.Encrypt(PK_Purchasing_LR_Agreement.ToString()));
    }
    protected void btnPK_Click(object sender, EventArgs e)
    {
        BindGridView();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }

    /// <summary>
    /// Handle Back button event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // update the session variable for operation for view
        clsSession.Str_LR_Agreement_Operation = "edit";

        // open the page in view mode
        Response.Redirect("LeaseRentalAgreement.aspx?id=" + Encryption.Encrypt(PK_Purchasing_LR_Agreement.ToString()));
    }

    /// <summary>
    /// Handle Next Setp event in view mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNextStepView_Click(object sender, EventArgs e)
    {

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
        clsSession.Str_LR_Agreement_Operation = "edit";
        //redirect to Executive risk carrier page
        Response.Redirect(AppConfig.SiteURL + "SONIC/Purchasing/LRDealership.aspx");
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind All dropdownlist
    /// </summary>
    private void BindDropDown()
    {
        //Agreement Level  

        drpAgreementLevel.DataSource = LU_Service_Contract.selectAll();
        drpAgreementLevel.DataTextField = "Fld_Desc";
        drpAgreementLevel.DataValueField = "PK_LU_Service_Contract";
        drpAgreementLevel.DataBind();
        drpAgreementLevel.Items.Insert(0, new ListItem("--Select--", "0"));

        //Equipement Type
        drpEquipmentType.DataSource = LU_Equipment_Type.SelectAll();
        drpEquipmentType.DataTextField = "Fld_Desc";
        drpEquipmentType.DataValueField = "PK_LU_Equipment_Type";
        drpEquipmentType.DataBind();

        drpEquipmentType.Items.Insert(0, new ListItem("--Select--", "0"));

        //Dealership Department 
        drpDealershipDepartment.DataSource = LU_Dealership_Department.SelectAll();
        drpDealershipDepartment.DataTextField = "Fld_Desc";
        drpDealershipDepartment.DataValueField = "PK_LU_Dealership_Department";
        drpDealershipDepartment.DataBind();

        drpDealershipDepartment.Items.Insert(0, new ListItem("--Select--", "0"));


        //LR Type
        drpLRType.DataSource = LU_LR_Type.SelectAll();
        drpLRType.DataTextField = "Fld_Desc";
        drpLRType.DataValueField = "PK_LU_LR_Type";
        drpLRType.DataBind();

        drpLRType.Items.Insert(0, new ListItem("--Select--", "0"));


        //Auto Renue
        drpAutoRenueOptions.DataSource = LU_Auto_Renue.AutoRenewOptionSelectAll();
        drpAutoRenueOptions.DataTextField = "Fld_Desc";
        drpAutoRenueOptions.DataValueField = "PK_LU_Auto_Renew";
        drpAutoRenueOptions.DataBind();

        drpAutoRenueOptions.Items.Insert(0, new ListItem("--Select--", "0"));

        hdDealershipDepartment.Value = "0";
    }

    /// <summary>
    /// Bind grid views as per operation mode
    /// </summary>
    private void BindGridView()
    {
        if (clsSession.Str_LR_Agreement_Operation == "view")
        {
            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Purchasing_LR_Agreement, PK_Purchasing_LR_Agreement, false, 4);
            gvNotesGridView.DataSource = Purchasing_LR_Note.SelectByFK_LR(PK_Purchasing_LR_Agreement);
            gvNotesGridView.DataBind();

            gvApplicableAssetsView.DataSource = Purchasing_LR_Asset.SelectByFK_LR(PK_Purchasing_LR_Agreement, string.Empty);
            gvApplicableAssetsView.DataBind();

            gvDealershipGridView.DataSource = Purchasing_LR_Dealer.SelectByLR_Agreement(PK_Purchasing_LR_Agreement, string.Empty);
            gvDealershipGridView.DataBind();

            gvSupplierView.DataSource = Purchasing_LR_Agreement.GetPurchasing_SonicAndSupplier_ContactInformation(PK_Purchasing_LR_Agreement, 2, "");
            gvSupplierView.DataBind();

            gvSonicView.DataSource = Purchasing_LR_Agreement.GetPurchasing_SonicAndSupplier_ContactInformation(PK_Purchasing_LR_Agreement, 1, "");
            gvSonicView.DataBind();
        }
        else
        {
            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Purchasing_LR_Agreement, PK_Purchasing_LR_Agreement, true, 4);
            if (PK_Purchasing_LR_Agreement > 0)
            {
                gvNotesGrid.DataSource = Purchasing_LR_Note.SelectByFK_LR(PK_Purchasing_LR_Agreement);
                gvApplicableAssets.DataSource = Purchasing_LR_Asset.SelectByFK_LR(PK_Purchasing_LR_Agreement, string.Empty);
                gvDealershipGrid.DataSource = Purchasing_LR_Dealer.SelectByLR_Agreement(PK_Purchasing_LR_Agreement, string.Empty);
                gvSuppiler.DataSource = Purchasing_LR_Agreement.GetPurchasing_SonicAndSupplier_ContactInformation(PK_Purchasing_LR_Agreement, 2, "");
                gvSonic.DataSource = Purchasing_LR_Agreement.GetPurchasing_SonicAndSupplier_ContactInformation(PK_Purchasing_LR_Agreement, 1, "");
            }
            else
            {
                gvNotesGrid.DataSource = null;
                gvApplicableAssets.DataSource = null;
                gvDealershipGrid.DataSource = null;
                gvSuppiler.DataSource = null;
                gvSonic.DataSource = null;
            }
            gvNotesGrid.DataBind();
            gvApplicableAssets.DataBind();
            gvDealershipGrid.DataBind();
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
    /// set controls(textbox and grid) for edit operation
    /// </summary>
    private void setControlsEdit()
    {
        Purchasing_LR_Agreement objLR = new Purchasing_LR_Agreement(PK_Purchasing_LR_Agreement);

        txtSupplier.Text = objLR.Supplier.ToString();
        drpEquipmentType.SelectedValue = objLR.FK_LU_Equipment_Type.ToString();
        txtPaymentTerms.Text = objLR.Payment_Terms;
        txtBuyout.Text = clsGeneral.GetStringValue(objLR.Buyout);
        txtLateFee.Text = (objLR.Late_Fee);
        drpLRType.SelectedValue = objLR.FK_LU_LR_Type.ToString();
        txtLeasedAmount.Text = clsGeneral.GetStringValue(objLR.Leased_Amount);
        txtLeaseRate.Text = (objLR.Lease_Rate);
        txtLRAgreementNote.Text = objLR.End_Of_Lease_Options;
        txtStartDate.Text = (objLR.Start_Date == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue ? string.Empty : clsGeneral.FormatDBNullDateToDisplay(objLR.Start_Date));
        txtEndDate.Text = (objLR.End_Date == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue ? string.Empty : clsGeneral.FormatDBNullDateToDisplay(objLR.End_Date));
        txtTermInMonths.Text = clsGeneral.GetStringValue(objLR.Term_In_Months).Replace(".00", "");
        txtNotificationDate.Text = (objLR.Notification_Date == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue ? string.Empty : clsGeneral.FormatDBNullDateToDisplay(objLR.Notification_Date));
        txtMonthlyCost.Text = clsGeneral.GetStringValue(objLR.Monthly_Cost);
        txtAnnualCost.Text = clsGeneral.GetStringValue(objLR.Annual_Cost);
        txtTotalCommitted.Text = clsGeneral.GetStringValue(objLR.Total_Committed);
        txtContractorCustomerNumber.Text = Convert.ToString(objLR.Customer_Contract_Number);
        drpAutoRenueOptions.SelectedValue = objLR.FK_LU_Auto_Renew.ToString();
        if (drpAutoRenueOptions.SelectedItem.Text.ToLower().Trim() == "other")
        {
            txtAutorenueOther.Enabled = true;
        }
        txtAutorenueOther.Text = objLR.Auto_Renew_Other.ToString();
        drpDealershipDepartment.SelectedValue = objLR.FK_LU_Dealership_Department.ToString();
        hdDealershipDepartment.Value = drpDealershipDepartment.SelectedIndex.ToString();
        ddlStatus.SelectedValue = objLR.Status.ToString();
        drpAgreementLevel.SelectedValue = objLR.FK_LU_Service_Contract.ToString();
        rdbCOINeed.SelectedValue = objLR.COI_Needed;
    }

    /// <summary>
    /// set controls(textbox and grid) for view operation
    /// </summary>
    private void setControlsView()
    {
        Purchasing_LR_Agreement objLR = new Purchasing_LR_Agreement(PK_Purchasing_LR_Agreement);
        lblSupplier.Text = Convert.ToString(objLR.Supplier);
        lblEquipementType.Text = new LU_Equipment_Type(objLR.FK_LU_Equipment_Type).Fld_Desc;
        lblPaymentTerms.Text = objLR.Payment_Terms;
        lblBuyout.Text = "$ " + clsGeneral.GetStringValue(objLR.Buyout);
        lblLatefee.Text = (objLR.Late_Fee);
        lblLRType.Text = new LU_LR_Type(objLR.FK_LU_LR_Type).Fld_Desc;
        lblLeaseAmount.Text = "$ " + clsGeneral.GetStringValue(objLR.Leased_Amount);
        lblLeasedRate.Text = (objLR.Lease_Rate);
        lblLRAgreementNote.Text = objLR.End_Of_Lease_Options;
        //lblStartDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(objLR.Start_Date)));
        //lblEndDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(objLR.End_Date)));
        lblStartDate.Text = clsGeneral.FormatDBNullDateToDisplay(objLR.Start_Date);
        lblEndDate.Text = clsGeneral.FormatDBNullDateToDisplay(objLR.End_Date);
        lblTermsInMonths.Text = clsGeneral.GetStringValue(objLR.Term_In_Months).Replace(".00", "");
        lblNotificationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objLR.Notification_Date);
        lblMonthlyCost.Text = "$ " + clsGeneral.GetStringValue(objLR.Monthly_Cost);
        lblAnnualCost.Text = "$ " + clsGeneral.GetStringValue(objLR.Annual_Cost);
        lblTotalCommitted.Text = "$ " + clsGeneral.GetStringValue(objLR.Total_Committed);
        lblCustomerContractorNumber.Text = Convert.ToString(objLR.Customer_Contract_Number);
        lblAutoRenewOptions.Text = new LU_Auto_Renue(objLR.FK_LU_Auto_Renew).Fld_Desc;
        lblAutoRenueOther.Text = Convert.ToString(objLR.Auto_Renew_Other);
        //LU_Location objLocation = new LU_Location(objLR.FK_LU_Location);
        lblDealershipDepartment.Text = new LU_Dealership_Department(objLR.FK_LU_Dealership_Department).Fld_Desc;
        lblStatus.Text = objLR.Status;
        lblAgreementLevel.Text = new LU_Service_Contract(objLR.FK_LU_Service_Contract).Fld_Desc;
        lblCOINeed.Text = objLR.COI_Needed.ToUpper() == "Y" ? "Yes" : "No";
    }

    /// <summary>
    /// save data add or update
    /// </summary>
    private void SaveData()
    {
        if (Page.IsValid)
        {
            // create object for the executive risk record
            Purchasing_LR_Agreement objLR = new Purchasing_LR_Agreement();

            // get the values from the page controls
            objLR.PK_Purchasing_LR_Agreement = PK_Purchasing_LR_Agreement;
            objLR.Supplier = txtSupplier.Text.Trim();
            objLR.FK_LU_Equipment_Type = Convert.ToDecimal(drpEquipmentType.SelectedValue);
            objLR.Payment_Terms = txtPaymentTerms.Text.Trim();
            objLR.Buyout = (txtBuyout.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txtBuyout.Text.Trim()));
            objLR.Late_Fee = txtLateFee.Text.Trim();
            objLR.FK_LU_LR_Type = Convert.ToDecimal(drpLRType.SelectedValue);
            objLR.Leased_Amount = (txtLeasedAmount.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txtLeasedAmount.Text.Trim()));
            objLR.Lease_Rate = txtLeaseRate.Text.Trim();
            objLR.Lease_Rate_Time_Period = ""; //txtLeaseRateTimePeriod.Text.Trim();
            objLR.End_Of_Lease_Options = txtLRAgreementNote.Text.Trim();
            objLR.Start_Date = clsGeneral.FormatNullDateToStore(txtStartDate.Text.Trim());
            objLR.End_Date = clsGeneral.FormatNullDateToStore(txtEndDate.Text.Trim());
            objLR.Term_In_Months = (txtTermInMonths.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txtTermInMonths.Text.Trim()));
            objLR.Monthly_Cost = (txtMonthlyCost.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txtMonthlyCost.Text.Trim()));
            objLR.Annual_Cost = (txtAnnualCost.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txtAnnualCost.Text.Trim()));
            objLR.Total_Committed = (txtTotalCommitted.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txtTotalCommitted.Text.Trim()));
            objLR.Customer_Contract_Number = Convert.ToString(txtContractorCustomerNumber.Text.Trim());
            objLR.FK_LU_Auto_Renew = Convert.ToDecimal(drpAutoRenueOptions.SelectedValue);
            objLR.Auto_Renew_Other = txtAutorenueOther.Text.Trim();
            objLR.Notification_Date = clsGeneral.FormatNullDateToStore(txtNotificationDate.Text.Trim());
            objLR.Renewal_Terms = "";
            objLR.Notification_Terms = "";
            objLR.Applicable_Dealers = ""; //txtApplicableDealers.Text.Trim();           
            objLR.FK_LU_Dealership_Department = Convert.ToDecimal(drpDealershipDepartment.SelectedValue);
            objLR.Update_Date = DateTime.Now;
            objLR.Updated_By = clsSession.UserID.ToString();
            objLR.Status = ddlStatus.SelectedIndex > 0 ? ddlStatus.SelectedValue : null;
            objLR.FK_LU_Service_Contract = Convert.ToDecimal(drpAgreementLevel.SelectedValue);
            objLR.COI_Needed = Convert.ToString(rdbCOINeed.SelectedValue);

            // update or insert the data according to the primary key
            if (PK_Purchasing_LR_Agreement > 0)
                objLR.Update();
            else
                PK_Purchasing_LR_Agreement = objLR.Insert();

            Upload_File(string.Empty);
            clsSession.Current_LR_Agreement_ID = PK_Purchasing_LR_Agreement;
        }
    }

    /// <summary>
    /// check user rights
    /// </summary>
    private void CheckUserRights()
    {
        if (clsSession.Str_LR_Agreement_Operation == "view")
        {
            btnBack.Visible = true;
        }
        if (App_Access == AccessType.View_Only)
        {
            if (clsSession.Str_LR_Agreement_Operation != "view")
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
            }
            btnBack.Visible = false;
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

        #region "Lease/Rental Agreement"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(89).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        Label MenuAsterisk1 = (Label)mnuLRAgreement.Controls[0].FindControl("MenuAsterisk");
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 89").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Supplier":
                    strCtrlsIDs += txtSupplier.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Supplier" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Equipment Type":
                    strCtrlsIDs += drpEquipmentType.ClientID + ",";
                    strMessages += "Please select [Lease/Rental Agreement]/Equipment Type" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Payment Terms":
                    strCtrlsIDs += txtPaymentTerms.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Payment Terms" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Buyout":
                    strCtrlsIDs += txtBuyout.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Buyout" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Late Fee":
                    strCtrlsIDs += txtLateFee.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Late Fee" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Lease/Rental Type":
                    strCtrlsIDs += drpLRType.ClientID + ",";
                    strMessages += "Please select [Lease/Rental Agreement]/Lease/Rental Type" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Leased Amount":
                    strCtrlsIDs += txtLeasedAmount.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Leased Amount" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Lease Factor":
                    strCtrlsIDs += txtLeaseRate.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Lease Factor" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Lease/Rental Agreement Notes":
                    strCtrlsIDs += txtLRAgreementNote.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Lease/Rental Agreement Notes" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Start Date":
                    strCtrlsIDs += txtStartDate.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Start Date" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "End Date":
                    strCtrlsIDs += txtEndDate.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/End Date" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Status":
                    strCtrlsIDs += ddlStatus.ClientID + ",";
                    strMessages += "Please select [Lease/Rental Agreement]/Status" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Agreement Level":
                    strCtrlsIDs += drpAgreementLevel.ClientID + ",";
                    strMessages += "Please select [Lease/Rental Agreement]/Agreement Level" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "Term in Months":
                    strCtrlsIDs += txtTermInMonths.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Term in Months" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "Notification Date":
                    strCtrlsIDs += txtNotificationDate.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Notification Date" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                case "Monthly Cost":
                    strCtrlsIDs += txtMonthlyCost.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Monthly Cost" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                case "Annual Cost":
                    strCtrlsIDs += txtAnnualCost.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Annual Cost" + ",";
                    Span17.Style["display"] = "inline-block";
                    break;
                case "Total Committed $":
                    strCtrlsIDs += txtTotalCommitted.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Total Committed $" + ",";
                    Span18.Style["display"] = "inline-block";
                    break;
                case "Customer/Contract Number":
                    strCtrlsIDs += txtContractorCustomerNumber.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Customer/Contract Number" + ",";
                    Span19.Style["display"] = "inline-block";
                    break;
                case "Auto Renew Options":
                    strCtrlsIDs += drpAutoRenueOptions.ClientID + ",";
                    strMessages += "Please select [Lease/Rental Agreement]/Auto Renew Options" + ",";
                    Span20.Style["display"] = "inline-block";
                    break;
                case "Auto Renew Other":
                    strCtrlsIDs += txtAutorenueOther.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Auto Renew Other" + ",";
                    Span21.Style["display"] = "inline-block";
                    break;
                case "Dealership Department":
                    strCtrlsIDs += drpDealershipDepartment.ClientID + ",";
                    strMessages += "Please enter [Lease/Rental Agreement]/Dealership Department" + ",";
                    Span22.Style["display"] = "inline-block";
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
