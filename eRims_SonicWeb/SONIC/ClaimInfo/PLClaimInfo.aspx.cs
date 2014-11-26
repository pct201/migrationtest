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

/// <summary>
/// Date : 14 NOV 2008
/// 
/// By : Amit Makwana
/// 
/// Purpose: 
/// To view the claim information for the type Premises Loss Claim
/// 
/// Functionality:
/// Gets the Premises Loss Claim ID from querystring and provides the information 
/// for that in view mode
/// </summary>
public partial class SONIC_PLClaimInfo : clsBasePage
{
    #region Private Variable and Property

    /// <summary>
    /// Denotes PK for Premises Loss Claim
    /// </summary>
    public long PK_PL_CI_ID
    {
        get
        {
            return clsGeneral.GetLong(ViewState["PL_CI_ID"]);
        }
        set { ViewState["PL_CI_ID"] = value; }
    }
    /// <summary>
    /// Denotes PK for Premises Loss Claim RMW
    /// </summary>
    public int PK_Premises_Loss_RMW
    {
        get
        {
            return Convert.ToInt32(ViewState["PK_Premises_Loss_RMW"]);
        }
        set { ViewState["PK_Premises_Loss_RMW"] = value; }
    }
    /// <summary>
    /// Denotes first report number
    /// </summary>
    public decimal First_Report_Number
    {
        get
        {
            return clsGeneral.IsNull(ViewState["First_Report_Number"]) ? 0 : Convert.ToDecimal(ViewState["First_Report_Number"]);
        }
        set
        {
            ViewState["First_Report_Number"] = value;
        }
    }

    #endregion

    #region Events

    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        ClaimTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.PL);
        //declare Atachment Control Handler for uploding File
        ctlAttchment.btnHandler += new Controls_Attachments_Attachment.OnButtonClick(Upload_File);
        CtrlAttachment_Cliam.btnHandler += new Controls_ClaimAttachment_Attachment.OnButtonClick(ClaimUpload_File);

        //used to check Page Post Back Event
        if (!IsPostBack)
        {
            #region General
            // check claim id is passed in querystring or not.
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                try
                {
                    //Get claim id from query string and store in viewstate.   
                    PK_PL_CI_ID = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));                   
                    clsSession.ClaimID_Diary = Request.QueryString["id"].ToString();
                }
                catch
                {
                    Response.Redirect("ClaimInformationSearch.aspx");
                }
            }
            else
            {
                //if no querystring is passed redirect to search page.
                Response.Redirect("ClaimInformationSearch.aspx");
            }

            #endregion

            //Bind the Premises Loss Claim Information
            BindPlClaimInfo();
            //Initialize Attachment Details Info.
            ctlAttchmentDetails.InitializeAttachmentDetails(clsGeneral.Claim_Tables.PLClaim, Convert.ToInt32(PK_PL_CI_ID), true, 5);
            ctlAttchmentDetails.Bind();

            // initialize control for Whole claim information
            CtlAttachDetail_Cliam.InitializeAttachmentDetails(clsGeneral.Tables.PLClaim, Convert.ToInt32(PK_PL_CI_ID), true, 7);
            CtlAttachDetail_Cliam.Bind();
            //Bind Risk Management Worksheet
            BindRiskMangWorkSheet();
            //Set the first panel active
            int intPanle = 1;
            if (int.TryParse(Convert.ToString(Request.QueryString["pnl"]), out intPanle))
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + intPanle.ToString() + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            //BindGridSonicNotes();
            SetValidations();
        }
    }

    /// <summary>
    /// Handles event for rowdatabound in transaction grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWCTransList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check Rowtype
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkTransaction_Entry_date = (LinkButton)e.Row.FindControl("lnkTransaction_Entry_date");

            //check Date_Of_Incident value from datset. if it is not null than display it in proper format.
            if (DataBinder.Eval(e.Row.DataItem, "Transaction_Entry_date") != DBNull.Value)
                lnkTransaction_Entry_date.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Transaction_Entry_date")));
        }
    }

    /// <summary>
    /// Handles Rowcommand event for transaction grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWCTransList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "View")
        {
            //Get the Claim Transaction Id
            long PK_ID = Convert.ToInt64(e.CommandArgument);

            //Fill the Claim Transaction detail. and make transaction panel visible
            if (BindClaimTransactionDetails(PK_ID))
                pnlTransactionDetail.Visible = true;
        }
    }

    /// <summary>
    /// Handles rowcommand event for notes grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void gvNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //check Command Name
    //    if (e.CommandName == "EditRecord")
    //    {
    //        //Get the Claim Note ID
    //        Response.Redirect("ClaimNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&FK_Claim=" + Encryption.Encrypt(PK_PL_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.PLClaim.ToString());
    //    }
    //    else if (e.CommandName == "Remove")
    //    {
    //        // Delete record
    //        Claim_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

    //        BindGridSonicNotes();
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel(6);", true);

    //    }
    //}

    /// <summary>
    /// Handles Associated first report link 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_Click(object sender, EventArgs e)
    {
        //Get the details of Associated first report from the report number.
        DataSet dsPLFirstReport = PL_FR.SelectByPL_FR_Number(First_Report_Number);    

        //Check First report found or not
        if (dsPLFirstReport.Tables[0].Rows.Count > 0)
        {
            //set the wizard id in session
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(dsPLFirstReport.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);
            //redirect to the Premises Loss first report page
            Response.Redirect("../FirstReport/PLFirstReport.aspx?id=" + Encryption.Encrypt(dsPLFirstReport.Tables[0].Rows[0]["PK_PL_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
    }

    /// <summary>
    /// Handles Save button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //create object for claim
        Premises_Loss_RMW objPLR = new Premises_Loss_RMW();

        // set object values from page controls
        objPLR.FK_Premises_Loss_Claims = PK_PL_CI_ID;
        objPLR.Update_Date = DateTime.Now;
        objPLR.Updated_By = clsSession.UserID;

        if (rdoClaimant_Customer.SelectedValue == "1")
            objPLR.Claimant_Customer = true;
        else if (rdoClaimant_Customer.SelectedValue == "0")
            objPLR.Claimant_Customer = false;
        else
            objPLR.Claimant_Customer = null;

        if (rdoClaimant_Third_Party.SelectedValue == "1")
            objPLR.Claimant_Third_Party = true;
        else if (rdoClaimant_Third_Party.SelectedValue == "0")
            objPLR.Claimant_Third_Party = false;
        else
            objPLR.Claimant_Third_Party = null;

        objPLR.Liability_Analysis = Convert.ToString(txtLiability_Analysis.Text);

        if (rdoDemand.SelectedValue == "1")
            objPLR.Demand = true;
        else if (rdoDemand.SelectedValue == "0")
            objPLR.Demand = false;
        else
            objPLR.Demand = null;

        objPLR.Claimant_Counsel_Name = Convert.ToString(txtClaimant_Counsel_Name.Text);
        objPLR.Plantiff_Counsel_Name = Convert.ToString(txtPlantiff_Counsel_Name.Text);

        if (rdoProperty_Damaged.SelectedValue == "1")
            objPLR.Property_Damaged = true;
        else if (rdoProperty_Damaged.SelectedValue == "0")
            objPLR.Property_Damaged = false;
        else
            objPLR.Property_Damaged = null;

        objPLR.Property_Damages_Description = Convert.ToString(txtProperty_Damages_Description.Text);
        objPLR.Damage_Amount = string.IsNullOrEmpty(txtDamage_Amount.Text) ? 0 : Convert.ToDecimal(txtDamage_Amount.Text);

        if (rdoBodily_Injury.SelectedValue == "1")
            objPLR.Bodily_injury = true;
        else if (rdoBodily_Injury.SelectedValue == "0")
            objPLR.Bodily_injury = false;
        else
            objPLR.Bodily_injury = null;

        objPLR.Injury_Description = Convert.ToString(txtInjury_Description.Text);
        objPLR.Medical_Treatment_Description = Convert.ToString(txtMedical_Treatment_Description.Text);
        objPLR.Medical_Cost = string.IsNullOrEmpty(txtMedical_Cost.Text) ? 0 : Convert.ToDecimal(txtMedical_Cost.Text);
        objPLR.Requested_Amount = string.IsNullOrEmpty(txtRequested_Amount.Text) ? 0 : Convert.ToDecimal(txtRequested_Amount.Text);
        objPLR.Potential_Total_Exposure = string.IsNullOrEmpty(txtPotential_Total_Exposure.Text) ? 0 : Convert.ToDecimal(txtPotential_Total_Exposure.Text);

        if (rdoSettled.SelectedValue == "1")
            objPLR.Settled = true;
        else if (rdoSettled.SelectedValue == "0")
            objPLR.Settled = false;
        else
            objPLR.Settled = null;

        objPLR.Settled_Amount = string.IsNullOrEmpty(txtSettled_Amount.Text) ? 0 : Convert.ToDecimal(txtSettled_Amount.Text);

        objPLR.GM_Email_To = txtGM_Email_To.Text;
        if (rdoGM_Decision.SelectedValue == "1")
            objPLR.GM_Decision = true;
        else if (rdoGM_Decision.SelectedValue == "0")
            objPLR.GM_Decision = false;
        else
            objPLR.GM_Decision = null;
        objPLR.GM_Last_Email_Date = clsGeneral.FormatDateToStore(txtGM_Last_Email_Date);
        objPLR.GM_Response_Date = clsGeneral.FormatDateToStore(txtGM_Response_Date);


        objPLR.CRM_Email_To = txtCRM_Email_To.Text;
        if (rdoCRM_Decision.SelectedValue == "1")
            objPLR.CRM_Decision = true;
        else if (rdoCRM_Decision.SelectedValue == "0")
            objPLR.CRM_Decision = false;
        else
            objPLR.CRM_Decision = null;
        objPLR.CRM_Last_Email_Date = clsGeneral.FormatDateToStore(txtCRM_Last_Email_Date);
        objPLR.CRM_Response_Date = clsGeneral.FormatDateToStore(txtCRM_Response_Date);

        objPLR.AGC_Email_To = txtAGC_Email_To.Text;
        if (rdoAGC_Decision.SelectedValue == "1")
            objPLR.AGC_Decision = true;
        else if (rdoAGC_Decision.SelectedValue == "0")
            objPLR.AGC_Decision = false;
        else
            objPLR.AGC_Decision = null;
        objPLR.AGC_Last_Email_Date = clsGeneral.FormatDateToStore(txtAGC_Last_Email_Date);
        objPLR.AGC_Response_Date = clsGeneral.FormatDateToStore(txtAGC_Response_Date);

        objPLR.RVP_Email_To = txtRVP_Email_To.Text;
        if (rdoRVP_Decision.SelectedValue == "1")
            objPLR.RVP_Decision = true;
        else if (rdoRVP_Decision.SelectedValue == "0")
            objPLR.RVP_Decision = false;
        else
            objPLR.RVP_Decision = null;
        objPLR.RVP_Last_Email_Date = clsGeneral.FormatDateToStore(txtRVP_Last_Email_Date);
        objPLR.RVP_Response_Date = clsGeneral.FormatDateToStore(txtRVP_Response_Date);

        objPLR.DRM_Email_To = txtDRM_Email_To.Text;
        if (rdoDRM_Decision.SelectedValue == "1")
            objPLR.DRM_Decision = true;
        else if (rdoDRM_Decision.SelectedValue == "0")
            objPLR.DRM_Decision = false;
        else
            objPLR.DRM_Decision = null;
        objPLR.DRM_Last_Email_Date = clsGeneral.FormatDateToStore(txtDRM_Last_Email_Date);
        objPLR.DRM_Response_Date = clsGeneral.FormatDateToStore(txtDRM_Response_Date);

        objPLR.CFO_Email_To = txtCFO_Email_To.Text;
        if (rdoCFO_Decision.SelectedValue == "1")
            objPLR.CFO_Decision = true;
        else if (rdoCFO_Decision.SelectedValue == "0")
            objPLR.CFO_Decision = false;
        else
            objPLR.CFO_Decision = null;
        objPLR.CFO_Last_Email_Date = clsGeneral.FormatDateToStore(txtCFO_Last_Email_Date);
        objPLR.CFO_Response_Date = clsGeneral.FormatDateToStore(txtCFO_Response_Date);

        objPLR.COO_Email_To = txtCOO_Email_To.Text;
        if (rdoCOO_Decision.SelectedValue == "1")
            objPLR.COO_Decision = true;
        else if (rdoCOO_Decision.SelectedValue == "0")
            objPLR.COO_Decision = false;
        else
            objPLR.COO_Decision = null;
        objPLR.COO_Last_Email_Date = clsGeneral.FormatDateToStore(txtCOO_Last_Email_Date);
        objPLR.COO_Response_Date = clsGeneral.FormatDateToStore(txtCOO_Response_Date);

        objPLR.President_Email_To = txtPresident_Email_To.Text;
        if (rdoPresident_Decision.SelectedValue == "1")
            objPLR.President_Decision = true;
        else if (rdoPresident_Decision.SelectedValue == "0")
            objPLR.President_Decision = false;
        else
            objPLR.President_Decision = null;
        objPLR.President_Last_Email_Date = clsGeneral.FormatDateToStore(txtPresident_Last_Email_Date);
        objPLR.President_Response_Date = clsGeneral.FormatDateToStore(txtPresident_Response_Date);

        objPLR.Comments = txtComments.Text;
        ctlAttchment.Add(clsGeneral.Claim_Tables.PLClaim, Convert.ToInt32(PK_PL_CI_ID));

        // Used to Bind Grid with Attached Data
        ctlAttchmentDetails.Bind();
        if (Premises_Loss_RMW.SelectByFK(PK_PL_CI_ID).Tables[0].Rows.Count > 0)
        {
            objPLR.UpdateByFK();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Risk Management Worksheet data has been saved.');ShowPanel(5);", true);
        }
        else
        {
            PK_Premises_Loss_RMW = objPLR.Insert();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Risk Management Worksheet data has been saved.');ShowPanel(5);", true);
        }
    }

    /// <summary>
    /// handles Add link click event for notes grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNotesAdd_Click(object sender, EventArgs e)
    {
        // redirect to Claim notes
        Response.Redirect("ClaimNotes.aspx?FK_Claim=" + Encryption.Encrypt(PK_PL_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.PLClaim.ToString());
    }

    protected void GetPage()
    {
        BindWCTransList(lblClaimNumber2.Text, ctrlPageTransaction.CurrentPage, ctrlPageTransaction.PageSize);
    }

    /// <summary>
    /// Handles View button click event for notes grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnView_Click(object sender, EventArgs e)
    //{
    //    // get selected Note IDs
    //    string strPK = "";
    //    foreach (GridViewRow gRow in gvNotes.Rows)
    //    {
    //        if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
    //            strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
    //    }
    //    strPK = strPK.TrimEnd(',');
    //    // redirect to Claim notes page
    //    Response.Redirect("ClaimNotes.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_PL_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.PLClaim.ToString());
    //}

    /// <summary>
    /// Handles Print button click event for notes grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnPrint_Click(object sender, EventArgs e)
    //{
    //    // get selected notes IDs
    //    string strPK = "";
    //    foreach (GridViewRow gRow in gvNotes.Rows)
    //    {
    //        if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
    //            strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
    //    }
    //    strPK = strPK.TrimEnd(',');

    //    // generate word doc
    //    clsPrintClaimNotes.PrintSelectedSonicNotes(strPK, clsGeneral.Claim_Tables.PLClaim.ToString(), PK_PL_CI_ID);
    //}

    #endregion

    #region Private Methods

    /// <summary>
    /// Function to bind the Claim Information and Finacial Information
    /// </summary>
    public void BindPlClaimInfo()
    {
        DataSet dsPremises_Loss_Claims = PL_ClaimInfo.SelectByPK(PK_PL_CI_ID);
        DataTable dtPremises_Loss_Claims = dsPremises_Loss_Claims.Tables[0];

        if (dtPremises_Loss_Claims.Rows.Count > 0)
        {
            DataRow drPremises_Loss_Claims = dtPremises_Loss_Claims.Rows[0];

            if (drPremises_Loss_Claims["PK_Workers_Comp_Claims_ID"] != DBNull.Value)
            {
                ddlCompanionClaim.Visible = false;
                lnkClaim.Visible = true;
                lnkClaim.InnerText = Convert.ToString(drPremises_Loss_Claims["Companion_Claim"]);
                lnkClaim.HRef = "WCClaimInfo.aspx?id=" + Encryption.Encrypt(Convert.ToString(drPremises_Loss_Claims["PK_Workers_Comp_Claims_ID"]));
            }
            else
            {
                ddlCompanionClaim.Visible = true;
                lnkClaim.Visible = false;
                ComboHelper.FillCompanionClaimReportType(new DropDownList[] { ddlCompanionClaim }, false, !String.IsNullOrEmpty(Convert.ToString(drPremises_Loss_Claims["Associated_First_Report"])) ? Convert.ToDecimal(drPremises_Loss_Claims["Associated_First_Report"]) : 0, "PL_FR");
                if (ddlCompanionClaim.Items.Count == 0)
                    ddlCompanionClaim.Items.Insert(0, new ListItem("-- None --", "0"));
            }

            //Header Info
            lblClaimNumber.Text = Convert.ToString(drPremises_Loss_Claims["Origin_Claim_Number"]);
            lblDateIncident.Text = drPremises_Loss_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_Of_Accident"]));
            lblLocationdba.Text = Convert.ToString(drPremises_Loss_Claims["dba1"]);
            lnkAssociatedFirstReport.Text = Convert.ToString(drPremises_Loss_Claims["FR_Number"]);
            if (!string.IsNullOrEmpty(lnkAssociatedFirstReport.Text.Trim()))
                lnkAssociatedFirstReport.Text = "PL-" + lnkAssociatedFirstReport.Text;

            decimal _FR_Number;
            if (decimal.TryParse(Convert.ToString(drPremises_Loss_Claims["FR_Number"]), out _FR_Number))
                First_Report_Number = _FR_Number;

            lblName.Text = Convert.ToString(drPremises_Loss_Claims["Employee_Name"]);
            //Claim Informations
            lblDataSource.Text = Convert.ToString(drPremises_Loss_Claims["Data_Origin"]);
            lblDateofUpdate.Text = drPremises_Loss_Claims["Date_Entered"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_Entered"]));
            lblClaimNumber2.Text = Convert.ToString(drPremises_Loss_Claims["Origin_Claim_Number"]).Trim();
            lblKeyClaimNumber.Text = Convert.ToString(drPremises_Loss_Claims["Origin_Key_Claim_Number"]);
            lblAssociatedFirstReport.Text = Convert.ToString(drPremises_Loss_Claims["Associated_First_Report"]);
            lblClaimantSequenceNumber.Text = Convert.ToString(drPremises_Loss_Claims["Claimant_Sequence_Number"]);
            lblEmployeeName.Text = Convert.ToString(drPremises_Loss_Claims["Employee_Name"]);
            lblClaimantFirstName.Text = Convert.ToString(drPremises_Loss_Claims["Claimant_First_Name"]);
            lblClaimantLastName.Text = Convert.ToString(drPremises_Loss_Claims["Claimant_Last_Name"]);
            lblEmployeeStreet.Text = Convert.ToString(drPremises_Loss_Claims["Employee_Street"]);
            lblEmployeeCity.Text = Convert.ToString(drPremises_Loss_Claims["Employee_City"]);
            lblEmployeeState.Text = Convert.ToString(drPremises_Loss_Claims["Employee_State"]);
            lblEmployeeZip.Text = Convert.ToString(drPremises_Loss_Claims["Employee_Zip"]);
            lblEmployeeGender.Text = Convert.ToString(drPremises_Loss_Claims["Employee_Gender"]);
            lblEmployeeSSN.Text = Convert.ToString(drPremises_Loss_Claims["Employee_SSN"]);
            lblEmployeeMaritalStatus.Text = Convert.ToString(drPremises_Loss_Claims["Marital_Status"]);
            lblDateofBirth.Text = drPremises_Loss_Claims["Employee_Date_of_Birth"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Employee_Date_of_Birth"]));
            lblStateofAccident.Text = Convert.ToString(drPremises_Loss_Claims["State_of_Accident"]);
            lblStateofJurisdiction.Text = Convert.ToString(drPremises_Loss_Claims["State_of_Jurisdiction"]);
            lblDateReportedtoInsurer.Text = drPremises_Loss_Claims["Date_Reported_to_Insurer"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_Reported_to_Insurer"]));
            lblDateofAccident.Text = drPremises_Loss_Claims["Date_of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_of_Accident"]));
            lblTimeofLoss.Text = Convert.ToString(drPremises_Loss_Claims["Time_of_Loss"]);
            lblDateEntered.Text = drPremises_Loss_Claims["Date_Entered"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_Entered"]));
            lblDateClosed.Text = drPremises_Loss_Claims["Date_Closed"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_Closed"]));

            lblClaimStatus.Text = Convert.ToString(drPremises_Loss_Claims["Claim_Status_Code"]);
            lblClaim_substatus.Text = Convert.ToString(drPremises_Loss_Claims["Claim_Sub_Status"]);
            lblLocationCode.Text = Convert.ToString(drPremises_Loss_Claims["dba"]);
            lblCoverageCode.Text = Convert.ToString(drPremises_Loss_Claims["Coverage_Code"]);

            lblDateSuitFiled.Text = drPremises_Loss_Claims["Date_Suit_Filed"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_Suit_Filed"]));
            lblLawSuitYN.Text = Convert.ToString(drPremises_Loss_Claims["LitigationYN"]);
            lblSuitResultCode.Text = Convert.ToString(drPremises_Loss_Claims["FK_Suit_Result_Code"]);
            lblSuitTypeCode.Text = Convert.ToString(drPremises_Loss_Claims["FK_Suit_Type_Code"]);
            lblPlaintiffAttorneyCode.Text = Convert.ToString(drPremises_Loss_Claims["Plaintiff_Attorney_Code"]);
            lblSRSPolicyNumber.Text = Convert.ToString(drPremises_Loss_Claims["SRS_Policy_Number"]);
            lblPolicyEffectiveDate.Text = drPremises_Loss_Claims["Policy_Effective_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Policy_Effective_Date"]));
            lblPolicyExpirationDate.Text = drPremises_Loss_Claims["Policy_Expiration_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Policy_Expiration_Date"]));
            lblOtherCarrierPolicyNumber.Text = Convert.ToString(drPremises_Loss_Claims["Other_Carrier_Policy_Number"]);
            lblCarrierEffectiveDate.Text = drPremises_Loss_Claims["Carrier_Effective_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Carrier_Effective_Date"]));
            lblCarrierExpirationDate.Text = drPremises_Loss_Claims["Carrier_Expiration_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Carrier_Expiration_Date"]));
            lblCatastropheCode.Text = Convert.ToString(drPremises_Loss_Claims["Catastrophe_Code"]);
            lblAccidentCityTown.Text = Convert.ToString(drPremises_Loss_Claims["Accident_City_Town"]);
            lblLocationProductName.Text = Convert.ToString(drPremises_Loss_Claims["Location_Product_Name"]);

            lblPreviousTPAClaimNumTakeover.Text = Convert.ToString(drPremises_Loss_Claims["Previous_TPA_Claim_Num_Takeover"]);
            lblClaimsMadeIndicator.Text = Convert.ToString(drPremises_Loss_Claims["Claims_Made_Indicator"]);
            lblClaimsMadeDate.Text = drPremises_Loss_Claims["Claims_Made_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Claims_Made_Date"]));
            lblRetroactiveDate.Text = drPremises_Loss_Claims["Retroactive_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Retroactive_Date"]));

            lblNCCICauseofinjurycode.Text = Convert.ToString(drPremises_Loss_Claims["NCCI_Cause_of_Injury_Code"]);
            lblNCCIBodyPartCode.Text = Convert.ToString(drPremises_Loss_Claims["NCCI_Body_Part_Code"]);
            lblNCCINatureofInjurycode.Text = Convert.ToString(drPremises_Loss_Claims["NCCI_Nature_Of_Injury_Code"]);

            lblClaimStatusDescription.Text = Convert.ToString(drPremises_Loss_Claims["Claim_Description"]);
            lblAccidentDescription.Text = Convert.ToString(drPremises_Loss_Claims["Accident_Description"]);
            lblCauseofInjuryCode.Text = Convert.ToString(drPremises_Loss_Claims["Cause_of_Injury_Code_Desc"]);
            lblNatureofInjuryCode.Text = Convert.ToString(drPremises_Loss_Claims["Nature_of_Injury_Code_desc"]);
            lblPartofBodycode.Text = Convert.ToString(drPremises_Loss_Claims["Part_of_Body_code_desc"]);

            //Financials
            lblLossGrossPaid.Text = drPremises_Loss_Claims["Loss_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Loss_Gross_Paid"])) : "";
            lblNetLossPaid.Text = drPremises_Loss_Claims["Net_Loss_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Net_Loss_Paid"])) : "";
            lblLossNetRecovered.Text = drPremises_Loss_Claims["Loss_Net_Recovered"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Loss_Net_Recovered"])) : "";
            lblLossIncurred.Text = drPremises_Loss_Claims["Loss_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Loss_Incurred"])) : "";
            lblLossOutstanding.Text = drPremises_Loss_Claims["Loss_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Loss_Outstanding"])) : "";
            lblExpenseGrossPaid.Text = drPremises_Loss_Claims["Expense_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Expense_Gross_Paid"])) : "";
            lblNetExpensePaid.Text = drPremises_Loss_Claims["Net_Expense_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Net_Expense_Paid"])) : "";
            lblExpenseNetRecovered.Text = drPremises_Loss_Claims["Expense_Net_Recovered"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Expense_Net_Recovered"])) : "";
            lblExpenseIncurred.Text = drPremises_Loss_Claims["Expense_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Expense_Incurred"])) : "";
            lblExpenseOutstanding.Text = drPremises_Loss_Claims["Expense_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Expense_Outstanding"])) : "";
            lblLossGrossSubrogation.Text = drPremises_Loss_Claims["Loss_Gross_Subrogation"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Loss_Gross_Subrogation"])) : "";
            lblLossSubrogationExpense.Text = drPremises_Loss_Claims["Loss_Subrogation_Expense"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Loss_Subrogation_Expense"])) : "";
            lblLossGrossSalvage.Text = drPremises_Loss_Claims["Loss_Gross_Salvage"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Loss_Gross_Salvage"])) : "";
            lblLossSalvageExpense.Text = drPremises_Loss_Claims["Loss_Salvage_Expense"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Loss_Salvage_Expense"])) : "";
            lblLossGrossRefund.Text = drPremises_Loss_Claims["Loss_Gross_Refund"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Loss_Gross_Refund"])) : "";
            lblAleGrossSubrogation.Text = drPremises_Loss_Claims["Ale_Gross_Subrogation"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Ale_Gross_Subrogation"])) : "";
            lblAleGrossSalvage.Text = drPremises_Loss_Claims["Ale_Gross_Salvage"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Ale_Gross_Salvage"])) : "";
            lblAleGrossRefund.Text = drPremises_Loss_Claims["Ale_Gross_Refund"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Ale_Gross_Refund"])) : "";
            lblAleRefundExpense.Text = drPremises_Loss_Claims["Ale_Refund_Expense"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Ale_Refund_Expense"])) : "";
            lblLegalExpenseIncurred.Text = drPremises_Loss_Claims["Legal_Expense_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Legal_Expense_Incurred"])) : "";
            lblLegalExpensePaidtoDate.Text = drPremises_Loss_Claims["Legal_Expense_Paid_to_Date"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Legal_Expense_Paid_to_Date"])) : "";
            lblRecoveredLossDeductibleAmount.Text = drPremises_Loss_Claims["Recovered_Loss_Deductible_Amount"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Recovered_Loss_Deductible_Amount"])) : "";
            lblRecoveredExpenseDeductibleAmount.Text = drPremises_Loss_Claims["Recovered_Expense_Deductible_Amount"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Recovered_Expense_Deductible_Amount"])) : "";
            lblPreviousTPAIndemnityPaid.Text = drPremises_Loss_Claims["Previous_TPA_Indemnity_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Previous_TPA_Indemnity_Paid"])) : "";
            lblPreviousTPAMedicalPaid.Text = drPremises_Loss_Claims["Previous_TPA_Medical_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Previous_TPA_Medical_Paid"])) : "";
            lblPreviousTPAExpensePaid.Text = drPremises_Loss_Claims["Previous_TPA_Expense_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Previous_TPA_Expense_Paid"])) : "";

            BindWCTransList(lblClaimNumber2.Text, ctrlPageTransaction.CurrentPage, ctrlPageTransaction.PageSize);

            ucAdjusterNotes.ClaimID = PK_PL_CI_ID;
            ucAdjusterNotes.ClaimNumber = lblClaimNumber2.Text;
            ucAdjusterNotes.BindGridNotes(lblClaimNumber2.Text);

            ctrlSonicNotes.PK_PL_CI_ID = PK_PL_CI_ID;
            ctrlSonicNotes.CurrentClaimType = clsGeneral.Claim_Tables.PLClaim.ToString();
            ctrlSonicNotes.BindGridSonicNotes(PK_PL_CI_ID, clsGeneral.Claim_Tables.PLClaim.ToString());

            DataSet objDs = new DataSet();

            objDs = ERIMS.DAL.Claim_CST.Claim_CSTSelectByOriginClaimNumber(Convert.ToString(drPremises_Loss_Claims["Origin_Claim_Number"]).Trim());
            if (objDs != null && objDs.Tables.Count > 0 && objDs.Tables[0].Rows.Count > 0)
            {
                lblProcessingOffice.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Processing_Office"]);
                if (!string.IsNullOrEmpty(Convert.ToString(objDs.Tables[0].Rows[0]["Status_Date_Change"])))
                    lblStatusChangeDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objDs.Tables[0].Rows[0]["Status_Date_Change"]));
                else
                    lblStatusChangeDate.Text = string.Empty;

                lblStatus.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Status"].ToString());
                lblSubStatus.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Sub_Status"].ToString());
                lblReopen.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Reopen_Flag"].ToString());
                lblReason1.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Fld_Desc1"].ToString());
                lblReason2.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Fld_Desc2"].ToString());
                lblReason3.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Fld_Desc3"].ToString());
                lblReason4.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Fld_Desc4"].ToString());
                lblReason5.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Fld_Desc5"].ToString());

            }
        }
    }
    public void BindWCTransList(string Origional_Claim_Number, int PageNumber, int PageSize)
    {
        DataSet dsWCTransList = Claims_Transaction.SelectByOriginClaimNumber(lblClaimNumber2.Text, PageNumber, PageSize);
        DataTable dtWCTransList = dsWCTransList.Tables[0];
        ctrlPageTransaction.TotalRecords = (dsWCTransList.Tables.Count >= 2) ? Convert.ToInt32(dsWCTransList.Tables[1].Rows[0][0]) : 0;
        ctrlPageTransaction.CurrentPage = (dsWCTransList.Tables.Count >= 2) ? Convert.ToInt32(dsWCTransList.Tables[1].Rows[0][2]) : 0;
        ctrlPageTransaction.RecordsToBeDisplayed = dsWCTransList.Tables[0].Rows.Count;
        ctrlPageTransaction.SetPageNumbers();
        gvWCTransList.DataSource = dtWCTransList;
        gvWCTransList.DataBind();
    }
    /// <summary>
    /// Function to bind the transaction detials when click on transaction list
    /// </summary>
    /// <param name="PK_ID">Claim Transaction PK Id</param>
    /// <returns></returns>
    public bool BindClaimTransactionDetails(Int64 PK_ID)
    {
        DataTable dtClaims_Transactions = Claims_Transaction.SelectByPK(PK_ID).Tables[0];
        if (dtClaims_Transactions.Rows.Count > 0)
        {
            DataRow drClaims_Transactions = dtClaims_Transactions.Rows[0];

            lblDataOrigin.Text = Convert.ToString(drClaims_Transactions["Data_Origin"]);
            lblOriginKeyClaimNumber.Text = Convert.ToString(drClaims_Transactions["Origin_Claim_Number"]);
            lblOriginKeyClaimNumber.Text = Convert.ToString(drClaims_Transactions["Origin_Key_Claim_Number"]);
            lblClaimantSequenceNumber3.Text = Convert.ToString(drClaims_Transactions["Claimant_Sequence_Number"]);
            lblPolicyNumber.Text = Convert.ToString(drClaims_Transactions["Policy_Number"]);
            lblCarrierpolicynumber2.Text = Convert.ToString(drClaims_Transactions["Carrier_policy_number"]);
            lblTransactionEntrydate.Text = drClaims_Transactions["Transaction_Entry_date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drClaims_Transactions["Transaction_Entry_date"]));
            lblTransactionAmount.Text = drClaims_Transactions["Transaction_Amount"] == DBNull.Value ? "" : String.Format("$ {0:N2}", Convert.ToDecimal(drClaims_Transactions["Transaction_Amount"]));
            lblTransactionSequenceNumber.Text = Convert.ToString(drClaims_Transactions["Transaction_Sequence_Number"]);
            lblClaimStatus2.Text = Convert.ToString(drClaims_Transactions["Claim_Status"]);
            lblEmployeeMaritalStatus2.Text = "";
            lblEntryCodeModifier.Text = Convert.ToString(drClaims_Transactions["Entry_Code_Modifier_Desc"]);
            lblEntryCode.Text = Convert.ToString(drClaims_Transactions["Entry_Code_Desc"]);
            lblNatureofBenefitCode2.Text = Convert.ToString(drClaims_Transactions["Nature_of_Benefit_Code_Desc"]);
            lblTransactionNatureofBenefit.Text = Convert.ToString(drClaims_Transactions["Transaction_Nature_of_Benefit_Desc"]);

            lblNatureofPaymentStatement.Text = Convert.ToString(drClaims_Transactions["Nature_of_Payment_Statement"]);
            lblCheckNumber.Text = Convert.ToString(drClaims_Transactions["Check_Number"]);
            lblCheckIssueDate.Text = drClaims_Transactions["Check_Issue_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drClaims_Transactions["Check_Issue_Date"]));
            lblPayeeName1.Text = Convert.ToString(drClaims_Transactions["Payee_Name1"]);
            lblPayeeName2.Text = Convert.ToString(drClaims_Transactions["Payee_Name2"]);
            lblPayeeName3.Text = Convert.ToString(drClaims_Transactions["Payee_Name3"]);
            lblPayeeStreetAddress.Text = Convert.ToString(drClaims_Transactions["Payee_Street_Address"]);
            lblPayeeCity.Text = Convert.ToString(drClaims_Transactions["Payee_City"]);
            lblPayeeState.Text = Convert.ToString(drClaims_Transactions["Payee_State"]);
            lblPayeeZip.Text = Convert.ToString(drClaims_Transactions["Payee_Zip"]);
            lblPayeeID.Text = Convert.ToString(drClaims_Transactions["Payee_Tax_Number"]) + " - " + Convert.ToString(drClaims_Transactions["Payee_SSN_FEIN"]);
            lblSRSRecoveryOfficeCode.Text = Convert.ToString(drClaims_Transactions["SRS_Recovery_Office_Code"]);
            lblSRSDraftIssueOfficeCode.Text = Convert.ToString(drClaims_Transactions["SRS_Draft_Issue_Office_Code"]);
            lblRecoverySequenceNumber.Text = Convert.ToString(drClaims_Transactions["Recovery_Sequence_Number"]);

            return true;
        }
        return false;
    }

    //Bind Risk Management WorkSheet
    public void BindRiskMangWorkSheet()
    {
        TextBox txtLiability_AnalysisChange = (TextBox)txtLiability_Analysis.FindControl("txtNote");
        txtLiability_AnalysisChange.Attributes.Remove("onchange");
        txtLiability_AnalysisChange.Attributes.Add("onchange", "OnChangeFunction();");

        TextBox txtProperty_DamageChange = (TextBox)txtProperty_Damages_Description.FindControl("txtNote");
        txtProperty_DamageChange.Attributes.Remove("onchange");
        txtProperty_DamageChange.Attributes.Add("onchange", "OnChangeFunction();");

        TextBox txtDescriptionInjuryChange = (TextBox)txtInjury_Description.FindControl("txtNote");
        txtDescriptionInjuryChange.Attributes.Remove("onchange");
        txtDescriptionInjuryChange.Attributes.Add("onchange", "OnChangeFunction();");

        TextBox txtMedical_Treatment_DescriptionChange = (TextBox)txtMedical_Treatment_Description.FindControl("txtNote");
        txtMedical_Treatment_DescriptionChange.Attributes.Remove("onchange");
        txtMedical_Treatment_DescriptionChange.Attributes.Add("onchange", "OnChangeFunction();");

        TextBox txtCommentsChange = (TextBox)txtComments.FindControl("txtNote");
        txtCommentsChange.Attributes.Remove("onchange");
        txtCommentsChange.Attributes.Add("onchange", "OnChangeFunction();");

        DataSet dsPremises_Loss_Claims = PL_ClaimInfo.SelectByPK(PK_PL_CI_ID);
        DataTable dtPremises_Loss_Claims = dsPremises_Loss_Claims.Tables[0];

        if (dtPremises_Loss_Claims.Rows.Count > 0)
        {
            DataRow drPremises_Loss_Claims = dtPremises_Loss_Claims.Rows[0];

            lblOrigin_Claim_Number.Text = Convert.ToString(drPremises_Loss_Claims["Origin_Claim_Number"]);
            lblDate_of_Accident.Text = drPremises_Loss_Claims["Date_of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_of_Accident"]));
            lblDate_Entered.Text = drPremises_Loss_Claims["Date_Entered"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_Entered"]));
            lblDate_Reported_To_Insurer.Text = drPremises_Loss_Claims["Date_Reported_To_Insurer"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_Reported_To_Insurer"]));

            if (!string.IsNullOrEmpty(Convert.ToString(drPremises_Loss_Claims["FK_Insured_Location_Code"])))
            {
                LU_Location objLocation = new LU_Location(Convert.ToInt32(drPremises_Loss_Claims["FK_Insured_Location_Code"]));
                if (objLocation.PK_LU_Location_ID > 0)
                    lblFK_Insured_Location_Code.Text = objLocation.RM_Location_Number + "-" + objLocation.Sonic_Location_Code;
                else
                    lblFK_Insured_Location_Code.Text = "";
            }
            else
                lblFK_Insured_Location_Code.Text = "";

            lblRegion.Text = new LU_Location(string.IsNullOrEmpty(Convert.ToString(drPremises_Loss_Claims["FK_Insured_Location_Code"])) ? 0 : Convert.ToInt32(drPremises_Loss_Claims["FK_Insured_Location_Code"])).Region;
            lblState_Of_Accident.Text = Convert.ToString(drPremises_Loss_Claims["State_Of_Accident"]);
            lblState_of_Jurisdiction.Text = Convert.ToString(drPremises_Loss_Claims["State_of_Jurisdiction"]);
            lblClaimantNameWorksheet.Text = (Convert.ToString(drPremises_Loss_Claims["Claimant_First_Name"]) + " " + Convert.ToString(drPremises_Loss_Claims["Claimant_Last_Name"]));
            //lblDriver_Name.Text = Convert.ToString(drPremises_Loss_Claims["Driver_Name"]);
            lblAccident_Description.Text = Convert.ToString(drPremises_Loss_Claims["Accident_Description"]);
            lblPlaintiff_Attorney_Code.Text = Convert.ToString(drPremises_Loss_Claims["Plaintiff_Attorney_Code"]);
            lblLitigationYN.Text = Convert.ToString(drPremises_Loss_Claims["LitigationYN"]);
            if (Convert.ToString(drPremises_Loss_Claims["LitigationYN"]) == "Y")
            {
                trCRMTitle.Style.Add("display", "none");
                trCRM.Style.Add("display", "none");
            }
            else if (Convert.ToString(drPremises_Loss_Claims["LitigationYN"]) == "N")
            {
                trAGCTitle.Style.Add("display", "none");
                trAGC.Style.Add("display", "none");
                trPRESIDENTTitle.Style.Add("display", "none");
                trPRESIDENT.Style.Add("display", "none");
            }
            else
            {
                trCRMTitle.Style.Add("display", "block");
                trCRM.Style.Add("display", "block");
                trAGCTitle.Style.Add("display", "block");
                trAGC.Style.Add("display", "block");
                trPRESIDENTTitle.Style.Add("display", "block");
                trPRESIDENT.Style.Add("display", "block");
            }
            lblDate_Suit_Filed.Text = drPremises_Loss_Claims["Date_Suit_Filed"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_Suit_Filed"]));
            lblFK_Suit_Type_Code.Text = Convert.ToString(drPremises_Loss_Claims["FK_Suit_Type_Code"]);
            lblFK_Suit_Result_Code.Text = Convert.ToString(drPremises_Loss_Claims["FK_Suit_Result_Code"]);

            lblLoss_Incurred.Text = drPremises_Loss_Claims["Loss_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Loss_Incurred"])) : "";
            lblLoss_Gross_Paid.Text = drPremises_Loss_Claims["Loss_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Loss_Gross_Paid"])) : "";
            lblLoss_Outstanding.Text = drPremises_Loss_Claims["Loss_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Loss_Outstanding"])) : "";
            lblLoss_Gross_Subrogation.Text = drPremises_Loss_Claims["Loss_Gross_Subrogation"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Loss_Gross_Subrogation"])) : "";

            lblAle_Gross_Subrogation.Text = drPremises_Loss_Claims["Ale_Gross_Subrogation"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Ale_Gross_Subrogation"])) : "";

            lblExpense_Incurred.Text = drPremises_Loss_Claims["Expense_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Expense_Incurred"])) : "";
            lblExpense_Gross_Paid.Text = drPremises_Loss_Claims["Expense_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Expense_Gross_Paid"])) : "";
            lblExpense_Outstanding.Text = drPremises_Loss_Claims["Expense_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Expense_Outstanding"])) : "";

            lblLegal_Expense_Incurred.Text = drPremises_Loss_Claims["Legal_Expense_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Legal_Expense_Incurred"])) : "";
            lblLegal_Expense_Paid_to_Date.Text = drPremises_Loss_Claims["Legal_Expense_Paid_to_Date"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drPremises_Loss_Claims["Legal_Expense_Paid_to_Date"])) : "";
            lblCause_of_Injury_Code.Text = new LU_Cause_of_Injury(string.IsNullOrEmpty(Convert.ToString(drPremises_Loss_Claims["Cause_of_Injury_Code"])) ? "" : Convert.ToString(drPremises_Loss_Claims["Cause_of_Injury_Code"])).Description;
            lblPart_of_Body_Code.Text = new LU_Part_of_Body_Code(string.IsNullOrEmpty(Convert.ToString(drPremises_Loss_Claims["Part_of_Body_Code"])) ? "" : Convert.ToString(drPremises_Loss_Claims["Part_of_Body_Code"])).Description;
            lblNCCI_Nature_of_Injury_Code.Text = new LU_Nature_of_Injury_Code(string.IsNullOrEmpty(Convert.ToString(drPremises_Loss_Claims["NCCI_Nature_of_Injury_Code"])) ? "" : Convert.ToString(drPremises_Loss_Claims["NCCI_Nature_of_Injury_Code"])).Description;

            DataSet dsPLC = Premises_Loss_RMW.SelectByFK(PK_PL_CI_ID);
            DataTable dtPLC = dsPLC.Tables[0];
            PK_Premises_Loss_RMW = 0;
            if (dtPLC.Rows.Count > 0)
            {
                DataRow drPLC = dtPLC.Rows[0];
                PK_Premises_Loss_RMW = Convert.ToInt32(drPLC["PK_Premises_Loss_RMW"]);
                if (drPLC["Claimant_Customer"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drPLC["Claimant_Customer"]) == true)
                    {
                        rdoClaimant_Customer.SelectedValue = "1";
                    }
                    else
                    {
                        rdoClaimant_Customer.SelectedValue = "0";
                    }
                }

                if (drPLC["Claimant_Third_Party"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drPLC["Claimant_Third_Party"]) == true)
                    {
                        rdoClaimant_Third_Party.SelectedValue = "1";
                    }
                    else
                    {
                        rdoClaimant_Third_Party.SelectedValue = "0";
                    }
                }

                txtLiability_Analysis.Text = Convert.ToString(drPLC["Liability_Analysis"]);

                if (drPLC["Demand"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drPLC["Demand"]) == true)
                    {
                        rdoDemand.SelectedValue = "1";
                    }
                    else
                    {
                        rdoDemand.SelectedValue = "0";
                    }
                }

                txtClaimant_Counsel_Name.Text = Convert.ToString(drPLC["Claimant_Counsel_Name"]);
                txtPlantiff_Counsel_Name.Text = Convert.ToString(drPLC["Plantiff_Counsel_Name"]);

                if (drPLC["Property_Damaged"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drPLC["Property_Damaged"]) == true)
                    {
                        rdoProperty_Damaged.SelectedValue = "1";
                    }
                    else
                    {
                        rdoProperty_Damaged.SelectedValue = "0";
                    }
                }

                txtProperty_Damages_Description.Text = Convert.ToString(drPLC["Property_Damages_Description"]);
                txtDamage_Amount.Text = drPLC["Damage_Amount"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drPLC["Damage_Amount"]));

                if (drPLC["Bodily_Injury"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drPLC["Bodily_Injury"]) == true)
                    {
                        rdoBodily_Injury.SelectedValue = "1";
                    }
                    else
                    {
                        rdoBodily_Injury.SelectedValue = "0";
                    }
                }

                txtInjury_Description.Text = Convert.ToString(drPLC["Injury_Description"]);

                txtMedical_Treatment_Description.Text = Convert.ToString(drPLC["Medical_Treatment_Description"]);
                txtMedical_Cost.Text = drPLC["Medical_Cost"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drPLC["Medical_Cost"]));
                txtRequested_Amount.Text = drPLC["Requested_Amount"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drPLC["Requested_Amount"]));
                txtPotential_Total_Exposure.Text = drPLC["Potential_Total_Exposure"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drPLC["Potential_Total_Exposure"]));

                if (drPLC["Settled"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drPLC["Settled"]) == true)
                    {
                        rdoSettled.SelectedValue = "1";
                    }
                    else
                    {
                        rdoSettled.SelectedValue = "0";
                    }
                }

                txtSettled_Amount.Text = drPLC["Settled_Amount"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drPLC["Settled_Amount"]));

                txtGM_Email_To.Text = Convert.ToString(drPLC["GM_Email_To"]);
                if (drPLC["GM_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drPLC["GM_Decision"]) == true)
                    {
                        rdoGM_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoGM_Decision.SelectedValue = "0";
                    }
                }
                txtGM_Last_Email_Date.Text = drPLC["GM_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["GM_Last_Email_Date"]));
                txtGM_Response_Date.Text = drPLC["GM_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["GM_Response_Date"]));

                txtCRM_Email_To.Text = Convert.ToString(drPLC["CRM_Email_To"]);
                if (drPLC["CRM_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drPLC["CRM_Decision"]) == true)
                    {
                        rdoCRM_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoCRM_Decision.SelectedValue = "0";
                    }
                }
                txtCRM_Last_Email_Date.Text = drPLC["CRM_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["CRM_Last_Email_Date"]));
                txtCRM_Response_Date.Text = drPLC["CRM_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["CRM_Response_Date"]));

                txtAGC_Email_To.Text = Convert.ToString(drPLC["AGC_Email_To"]);
                if (drPLC["AGC_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drPLC["AGC_Decision"]) == true)
                    {
                        rdoAGC_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoAGC_Decision.SelectedValue = "0";
                    }
                }
                txtAGC_Last_Email_Date.Text = drPLC["AGC_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["AGC_Last_Email_Date"]));
                txtAGC_Response_Date.Text = drPLC["AGC_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["AGC_Response_Date"]));


                txtRVP_Email_To.Text = Convert.ToString(drPLC["RVP_Email_To"]);
                if (drPLC["RVP_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drPLC["RVP_Decision"]) == true)
                    {
                        rdoRVP_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoRVP_Decision.SelectedValue = "0";
                    }
                }
                txtRVP_Last_Email_Date.Text = drPLC["RVP_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["RVP_Last_Email_Date"]));
                txtRVP_Response_Date.Text = drPLC["RVP_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["RVP_Response_Date"]));


                txtDRM_Email_To.Text = Convert.ToString(drPLC["DRM_Email_To"]);
                if (drPLC["DRM_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drPLC["DRM_Decision"]) == true)
                    {
                        rdoDRM_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoDRM_Decision.SelectedValue = "0";
                    }
                }
                txtDRM_Last_Email_Date.Text = drPLC["DRM_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["DRM_Last_Email_Date"]));
                txtDRM_Response_Date.Text = drPLC["DRM_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["DRM_Response_Date"]));

                txtCFO_Email_To.Text = Convert.ToString(drPLC["CFO_Email_To"]);
                if (drPLC["CFO_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drPLC["CFO_Decision"]) == true)
                    {
                        rdoCFO_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoCFO_Decision.SelectedValue = "0";
                    }
                }
                txtCFO_Last_Email_Date.Text = drPLC["CFO_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["CFO_Last_Email_Date"]));
                txtCFO_Response_Date.Text = drPLC["CFO_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["CFO_Response_Date"]));

                txtCOO_Email_To.Text = Convert.ToString(drPLC["COO_Email_To"]);
                if (drPLC["COO_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drPLC["COO_Decision"]) == true)
                    {
                        rdoCOO_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoCOO_Decision.SelectedValue = "0";
                    }
                }
                txtCOO_Last_Email_Date.Text = drPLC["COO_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["COO_Last_Email_Date"]));
                txtCOO_Response_Date.Text = drPLC["COO_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["COO_Response_Date"]));

                txtPresident_Email_To.Text = Convert.ToString(drPLC["President_Email_To"]);
                if (drPLC["President_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drPLC["President_Decision"]) == true)
                    {
                        rdoPresident_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoPresident_Decision.SelectedValue = "0";
                    }
                }
                txtPresident_Last_Email_Date.Text = drPLC["President_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["President_Last_Email_Date"]));
                txtPresident_Response_Date.Text = drPLC["President_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPLC["President_Response_Date"]));

                txtComments.Text = Convert.ToString(drPLC["Comments"]);
            }
        }
    }

    /// <summary>
    /// Use to Upload file from Comment section
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {


        //Insert values into WC_FR_Attachment table
        ctlAttchment.Add(clsGeneral.Claim_Tables.PLClaim, Convert.ToInt32(PK_PL_CI_ID));

        // Used to Bind Grid with Attached Data
        ctlAttchmentDetails.Bind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Used to upload attachment file
    /// </summary>
    /// <param name="strValue"></param>
    protected void ClaimUpload_File(string strValue)
    {
        //Insert values into AL_FR_Attachment table
        CtrlAttachment_Cliam.Add(clsGeneral.Tables.PLClaim, Convert.ToInt32(PK_PL_CI_ID));
        // Used to Bind Grid with Attached Data
        CtlAttachDetail_Cliam.Bind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(7);", true);
    }

    /// <summary>
    /// Binds the Notes grid
    /// </summary>
    //private void BindGridSonicNotes()
    //{
    //    DataTable dtNotes = Claim_Notes.SelectByFK_Table(PK_PL_CI_ID, clsGeneral.Claim_Tables.PLClaim.ToString()).Tables[0];
    //    gvNotes.DataSource = dtNotes;
    //    gvNotes.DataBind();

    //    btnView.Visible = dtNotes.Rows.Count > 0;
    //    btnPrint.Visible = dtNotes.Rows.Count > 0;
    //}

    #endregion

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region "Risk Management Worksheet"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(52).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk5.Style["display"] = (dtFields.Select("LeftMenuIndex = 5").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Liability Analysis":
                    strCtrlsIDs += "ctl00_ContentPlaceHolder1_txtLiability_Analysis_txtNote,";
                    strMessages += "Please enter Liability Analysis" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Name of Claimant Counsel":
                    strCtrlsIDs += txtClaimant_Counsel_Name.ClientID + ",";
                    strMessages += "Please enter Name of Claimant Counsel" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Name of Plaintiff Counsel":
                    strCtrlsIDs += txtPlantiff_Counsel_Name.ClientID + ",";
                    strMessages += "Please enter Name of Plaintiff Counsel" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Description of Property Damages":
                    strCtrlsIDs += "ctl00_ContentPlaceHolder1_txtProperty_Damages_Description_txtNote,";
                    strMessages += "Please enter Description of Property Damages" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Damage Amount":
                    strCtrlsIDs += txtDamage_Amount.ClientID + ",";
                    strMessages += "Please enter Damage Amount" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Description of Injuries":
                    strCtrlsIDs += "ctl00_ContentPlaceHolder1_txtInjury_Description_txtNote,";
                    strMessages += "Please enter Description of Injuries" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Description of Medical Treatment":
                    strCtrlsIDs += "ctl00_ContentPlaceHolder1_txtMedical_Treatment_Description_txtNote,";
                    strMessages += "Please enter Description of Medical Treatment" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Total Medical Cost":
                    strCtrlsIDs += txtMedical_Cost.ClientID + ",";
                    strMessages += "Please enter Total Medical Cost" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Requested Amount":
                    strCtrlsIDs += txtRequested_Amount.ClientID + ",";
                    strMessages += "Please enter Requested Amount" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Potential Total Exposure":
                    strCtrlsIDs += txtPotential_Total_Exposure.ClientID + ",";
                    strMessages += "Please enter Potential Total Exposure" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Settled Amount":
                    strCtrlsIDs += txtSettled_Amount.ClientID + ",";
                    strMessages += "Please enter Settled Amount" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "GM E-Mail To":
                    strCtrlsIDs += txtGM_Email_To.ClientID + ",";
                    strMessages += "Please enter GM E-Mail To" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "GM Last E-Mail Date":
                    strCtrlsIDs += txtGM_Last_Email_Date.ClientID + ",";
                    strMessages += "Please enter GM Last E-Mail Date" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "GM Response Date":
                    strCtrlsIDs += txtGM_Response_Date.ClientID + ",";
                    strMessages += "Please enter GM Response Date" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "Comments":
                    strCtrlsIDs += "ctl00_ContentPlaceHolder1_txtComments_txtNote,";
                    strMessages += "Please enter Comments" + ",";
                    Span36.Style["display"] = "inline-block";
                    break;
                case "CRM E-Mail To":
                    strCtrlsIDs += txtCRM_Email_To.ClientID + ",";
                    strMessages += "Please enter CRM E-Mail To" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                case "CRM Last E-Mail Date":
                    strCtrlsIDs += txtCRM_Last_Email_Date.ClientID + ",";
                    strMessages += "Please enter CRM Last E-Mail Date" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                case "CRM Response Date":
                    strCtrlsIDs += txtCRM_Response_Date.ClientID + ",";
                    strMessages += "Please enter CRM Response Date" + ",";
                    Span17.Style["display"] = "inline-block";
                    break;
                case "RVP E-Mail To":
                    strCtrlsIDs += txtRVP_Email_To.ClientID + ",";
                    strMessages += "Please enter RVP E-Mail To" + ",";
                    Span21.Style["display"] = "inline-block";
                    break;
                case "RVP Last E-Mail Date":
                    strCtrlsIDs += txtRVP_Last_Email_Date.ClientID + ",";
                    strMessages += "Please enter RVP Last E-Mail Date" + ",";
                    Span22.Style["display"] = "inline-block";
                    break;
                case "RVP Response Date":
                    strCtrlsIDs += txtRVP_Response_Date.ClientID + ",";
                    strMessages += "Please enter RVP Response Date" + ",";
                    Span23.Style["display"] = "inline-block";
                    break;
                case "DRM E-Mail To":
                    strCtrlsIDs += txtDRM_Email_To.ClientID + ",";
                    strMessages += "Please enter DRM E-Mail To" + ",";
                    Span24.Style["display"] = "inline-block";
                    break;
                case "DRM Last E-Mail Date":
                    strCtrlsIDs += txtDRM_Last_Email_Date.ClientID + ",";
                    strMessages += "Please enter DRM Last E-Mail Date" + ",";
                    Span25.Style["display"] = "inline-block";
                    break;
                case "DRM Response Date":
                    strCtrlsIDs += txtDRM_Response_Date.ClientID + ",";
                    strMessages += "Please enter DRM Response Date" + ",";
                    Span26.Style["display"] = "inline-block";
                    break;
                case "CFO E-Mail To":
                    strCtrlsIDs += txtCFO_Email_To.ClientID + ",";
                    strMessages += "Please enter CFO E-Mail To" + ",";
                    Span27.Style["display"] = "inline-block";
                    break;
                case "CFO Last E-Mail Date":
                    strCtrlsIDs += txtCFO_Last_Email_Date.ClientID + ",";
                    strMessages += "Please enter CFO Last E-Mail Date" + ",";
                    Span28.Style["display"] = "inline-block";
                    break;
                case "CFO Response Date":
                    strCtrlsIDs += txtCFO_Response_Date.ClientID + ",";
                    strMessages += "Please enter CFO CFO Response Date" + ",";
                    Span29.Style["display"] = "inline-block";
                    break;
                case "COO E-Mail To":
                    strCtrlsIDs += txtCOO_Email_To.ClientID + ",";
                    strMessages += "Please enter COO E-Mail To" + ",";
                    Span30.Style["display"] = "inline-block";
                    break;
                case "COO Last E-Mail Date":
                    strCtrlsIDs += txtCOO_Last_Email_Date.ClientID + ",";
                    strMessages += "Please enter COO Last E-Mail Date" + ",";
                    Span31.Style["display"] = "inline-block";
                    break;
                case "COO Response Date":
                    strCtrlsIDs += txtCOO_Response_Date.ClientID + ",";
                    strMessages += "Please enter COO Response Date" + ",";
                    Span32.Style["display"] = "inline-block";
                    break;
                case "AGC E-Mail To":
                    strCtrlsIDs += txtAGC_Email_To.ClientID + ",";
                    strMessages += "Please enter AGC E-Mail To" + ",";
                    Span18.Style["display"] = "inline-block";
                    break;
                case "AGC Last E-Mail Date":
                    strCtrlsIDs += txtAGC_Last_Email_Date.ClientID + ",";
                    strMessages += "Please enter AGC Last E-Mail Date" + ",";
                    Span19.Style["display"] = "inline-block";
                    break;
                case "AGC Response Date":
                    strCtrlsIDs += txtAGC_Response_Date.ClientID + ",";
                    strMessages += "Please enter AGC Response Date" + ",";
                    Span20.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
        #endregion
    }
    #endregion
}
