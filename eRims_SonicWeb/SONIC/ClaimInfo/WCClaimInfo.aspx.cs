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
using BAL;
using System.Text;
using System.IO;
using Aspose.Words;

/// <summary>
/// Date : 14 NOV 2008
/// 
/// By : Amit Makwana
/// 
/// Purpose: 
/// To view the claim information for the type Workers Compensation
/// 
/// Functionality:
/// Gets the Workers Compensation Claim ID from querystring and provides the information 
/// for that in view mode
/// </summary>
public partial class SONIC_WCClaimInfo : clsBasePage
{
    #region Private Variable and Property

    /// <summary>
    /// Denotes PK for Workers Compensation Claim
    /// </summary>
    public long PK_WC_CI_ID
    {
        get
        {
            return clsGeneral.GetLong(ViewState["WC_CI_ID"]);
        }
        set { ViewState["WC_CI_ID"] = value; }
    }
    /// <summary>
    /// Denotes PK for Workers Compensation Claim RMW
    /// </summary>
    public int PK_Workers_Comp_RMW
    {
        get
        {
            return Convert.ToInt32(ViewState["PK_Workers_Comp_RMW"]);
        }
        set { ViewState["PK_Workers_Comp_RMW"] = value; }
    }

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

    #region "Page Event"

    /// <summary>
    /// handle Page load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        ClaimTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.WC);
        //declare Atachment Control Handler for uploding File
        ctlAttchment.btnHandler += new Controls_Attachments_Attachment.OnButtonClick(Upload_File);
        CtrlAttachment_Cliam.btnHandler += new Controls_ClaimAttachment_Attachment.OnButtonClick(ClaimUpload_File);
        //ctrlSonicNotes.GetPage += new Controls_Navigation_Navigation.dlgGetPage(ctrlSonicNotes_GetPage);
        //used to check Page Post Back Event
        if (Request.QueryString["ClaimReview"] != null && Request.QueryString["ClaimReview"] != string.Empty)
        {
            if (Request.QueryString["ClaimReview"].ToString() == "1")
                btnClaimReview.Visible = true;
            else
                btnClaimReview.Visible = false;
        }
        else
            btnClaimReview.Visible = false;

        if (!IsPostBack)
        {
            #region General
            // check claim id is passed in querystring or not.
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                try
                {
                    //Get claim id from query string and store in viewstate.   
                    PK_WC_CI_ID = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
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
            BindWCClaimInfo();
            //Initialize Attachment Details Info.
            ctlAttchmentDetails.InitializeAttachmentDetails(clsGeneral.Claim_Tables.WCClaim, Convert.ToInt32(PK_WC_CI_ID), true, 5);
            ctlAttchmentDetails.Bind();

            // initialize control for Whole claim information
            CtlAttachDetail_Cliam.InitializeAttachmentDetails(clsGeneral.Tables.WCClaim, Convert.ToInt32(PK_WC_CI_ID), true, 7);
            CtlAttachDetail_Cliam.Bind();

            //Bind Worker’s Compensation – Risk Management Worksheet
            BindRiskMangWorkSheet();

            SetValidationsClaimInfo();
            SetValidationsRMW();

            //Set the first panel active
            int intPanle = 1;
            if (int.TryParse(Convert.ToString(Request.QueryString["pnl"]), out intPanle))
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + intPanle.ToString() + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
    }

    //protected void ctrlSonicNotes_GetPage()
    //{
    //    //BindGridSonicNotes(PK_WC_CI_ID, clsGeneral.Claim_Tables.WCClaim.ToString(), ctrlSonicNotes.CurrentPage, ctrlSonicNotes.PageSize);
    //    //throw new NotImplementedException();
    //}

    #endregion

    #region Evetns

    /// <summary>
    /// Handle Grid View Data Row Bound Event
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
    /// Grid View WC Transaction List Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWCTransList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "View")
        {
            //Get the Claim Transaction Id
            string PK_ID = Convert.ToString(e.CommandArgument);

            //Fill the Claim Transaction detail. and make transaction panel visible
            BindClaimTransactionDetails(PK_ID);
            //pnlTransactionDetail.Visible = true;
        }
    }

    /// <summary>
    /// Grid Notes Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void gvNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //check Command Name
    //    if (e.CommandName == "EditRecord")
    //    {
    //        //Get the Claim Note ID
    //        Response.Redirect("ClaimNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&FK_Claim=" + Encryption.Encrypt(PK_WC_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.WCClaim.ToString());
    //    }
    //    else if (e.CommandName == "Remove")
    //    {
    //        // Delete record
    //        Claim_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
    //        //BindGridSonicNotes(PK_WC_CI_ID,clsGeneral.Claim_Tables.WCClaim.ToString(),ctrlSonicNotes.CurrentPage,ctrlSonicNotes.PageSize);
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel(6);", true);
    //    }
    //}

    /// <summary>
    /// Link Button Associated First Report Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_Click(object sender, EventArgs e)
    {
        //Get the details of Associated first report from the report number.      
        DataSet dsWCFirstReport = WC_FR.SelectByWC_FR_Number(First_Report_Number);

        //Check First report found or not
        if (dsWCFirstReport != null && dsWCFirstReport.Tables.Count > 0 && dsWCFirstReport.Tables[0].Rows.Count > 0)
        {
            //set the wizard id in session
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(dsWCFirstReport.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);
            //redirect to the Workers Compensation  first report page
            Response.Redirect("../FirstReport/WCFirstReport.aspx?id=" + Encryption.Encrypt(dsWCFirstReport.Tables[0].Rows[0]["PK_WC_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
    }

    /// <summary>
    /// Save WCClaim Dates
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveWCClaim_Click(object sender, EventArgs e)
    {
        WC_ClaimInfo.UpdateRestrictedDates(PK_WC_CI_ID, clsGeneral.FormatNullDateToStore(txtDateRestrictedWorkBegan.Text.Trim()), clsGeneral.FormatNullDateToStore(txtDateRestrictedWorkEnd.Text.Trim()));
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Claim Identification data has been saved.');ShowPanel(1);", true);
    }

    /// <summary>
    /// Save Return To Work Click Dates and Days
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveReturn_To_Work_Click(object sender, EventArgs e)
    {
        WC_ClaimInfo objWC_ClaimInfo = new WC_ClaimInfo(PK_WC_CI_ID);
       
        objWC_ClaimInfo.OSHA_Start_Away_From_Work = clsGeneral.FormatNullDateToStore(txtFrom_Work_Began.Text.Trim());
        objWC_ClaimInfo.OSHA_End_Away_From_Work = clsGeneral.FormatNullDateToStore(txtFrom_Work_End.Text.Trim());
        //if (!string.IsNullOrEmpty(txtDays_Away_From_Work.Text))
        //    objWC_ClaimInfo.OSHA_Days_Away_From_Work = Convert.ToInt32(txtDays_Away_From_Work.Text);
        
        objWC_ClaimInfo.OSHA_Start_Job_Transfer_Restriction = clsGeneral.FormatNullDateToStore(txtDate_On_Job_Began.Text.Trim());
        objWC_ClaimInfo.OSHA_End_Job_Transfer_Restriction = clsGeneral.FormatNullDateToStore(txtDate_On_Job_End.Text.Trim());
        //if (!string.IsNullOrEmpty(txtDays_On_Job.Text))
        //    objWC_ClaimInfo.OSHA_Days_Job_Transfer_Restriction = Convert.ToInt32(txtDays_On_Job.Text);

        objWC_ClaimInfo.UpdateOSHA_Dates();

        BindWCClaimInfo();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Add New Note Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNotesAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClaimNotes.aspx?FK_Claim=" + Encryption.Encrypt(PK_WC_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.WCClaim.ToString());
    }

    /// <summary>
    /// Button Click Event to View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnView_Click(object sender, EventArgs e)
    {
        //string strPK = "";
        //foreach (GridViewRow gRow in gvNotes.Rows)
        //{
        //    if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
        //        strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
        //}
        //strPK = strPK.TrimEnd(',');
        //Response.Redirect("ClaimNotes.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_WC_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.WCClaim.ToString());
    }

    /// <summary>
    /// Button Print Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //string strPK = "";
        //foreach (GridViewRow gRow in gvNotes.Rows)
        //{
        //    if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
        //        strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
        //}
        //strPK = strPK.TrimEnd(',');
        //clsPrintClaimNotes.PrintSelectedSonicNotes(strPK, clsGeneral.Claim_Tables.WCClaim.ToString(), PK_WC_CI_ID);
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindWCTransList(lblClaimNumber2.Text, ctrlPageTransaction.CurrentPage, ctrlPageTransaction.PageSize);
    }

    /// <summary>
    /// Button Print Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrintSelectedTrans_Click(object sender, EventArgs e)
    {
        string strPK = "";

        foreach (GridViewRow gRow in gvWCTransList.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkTranSelect")).Checked)
                strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnID")).Value + ",";
        }
        strPK = strPK.TrimEnd(',');
        PrintTransaction(strPK);
    }

    /// <summary>
    /// Button Mail Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnMailTrans_Click(object sender, EventArgs e)
    {
        string strPKs = "";
        string tab = string.Empty;
        tab = "WC";

        foreach (RepeaterItem rptItem in rptTransDetail.Items)
        {
            if (((CheckBox)rptItem.FindControl("chkRptTransSelect")).Checked)
                strPKs = strPKs + ((HtmlInputHidden)rptItem.FindControl("hdnID")).Value + ",";
        }
        strPKs = strPKs.TrimEnd(',');
        if (strPKs != "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "OpenTransMailPopUp('" + "Transactions" + "','" + strPKs + "','" + tab + "','" + PK_WC_CI_ID + "');", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "javascript:alert('Please select Transaction(s) to mail');", true);
        }
    }

    /// <summary>
    /// Button Print Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrintSelectedTransInner_Click(object sender, EventArgs e)
    {
        string strPK = "";

        foreach (RepeaterItem rptItem in rptTransDetail.Items)
        {
            if (((CheckBox)rptItem.FindControl("chkRptTransSelect")).Checked)
                strPK = strPK + ((HtmlInputHidden)rptItem.FindControl("hdnID")).Value + ",";
        }
        strPK = strPK.TrimEnd(',');
        PrintTransaction(strPK);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Function to bind the Claim Information and Finacial Information
    /// </summary>
    public void BindWCClaimInfo()
    {
        DataSet dsWorkers_Comp_Claims = WC_ClaimInfo.SelectByPK(PK_WC_CI_ID);
        DataTable dtWorkers_Comp_Claims = dsWorkers_Comp_Claims.Tables[0];

        if (dtWorkers_Comp_Claims.Rows.Count > 0)
        {
            DataRow drWorkers_Comp_Claims = dtWorkers_Comp_Claims.Rows[0];
            if (Convert.ToString(drWorkers_Comp_Claims["FLD_state"]) == "Texas")
            {
                ddlCompanionClaim.Visible = false;
                lnkClaim.Visible = true;

                if (drWorkers_Comp_Claims["PK_GL_Prop_RO_ID"] != DBNull.Value)
                {
                    lnkClaim.InnerText = Convert.ToString(drWorkers_Comp_Claims["TX_NS_Companion_Claim_Number"]);
                    lnkClaim.HRef = "PLClaimInfo.aspx?id=" + Encryption.Encrypt(Convert.ToString(drWorkers_Comp_Claims["PK_GL_Prop_RO_ID"]));
                }
                else if (drWorkers_Comp_Claims["PkID"] != DBNull.Value)
                {
                    lnkClaim.InnerText = Convert.ToString(drWorkers_Comp_Claims["TX_NS_Companion_Claim_Number"]);
                    lnkClaim.HRef = "WCClaimInfo.aspx?id=" + Encryption.Encrypt(Convert.ToString(drWorkers_Comp_Claims["PkID"]));
                }
                else
                {
                    lnkClaim.InnerText = Convert.ToString(drWorkers_Comp_Claims["TX_NS_Companion_Claim_Number"]);
                    lnkClaim.HRef = "Javascript:void(0)";
                }
            }
            else
            {
                ddlCompanionClaim.Visible = true;
                lnkClaim.Visible = false;
                ComboHelper.FillCompanionClaimReportType(new DropDownList[] { ddlCompanionClaim }, false, !String.IsNullOrEmpty(Convert.ToString(drWorkers_Comp_Claims["Associated_First_Report"])) ? Convert.ToDecimal(drWorkers_Comp_Claims["Associated_First_Report"]) : 0, "WC_FR");
                if (ddlCompanionClaim.Items.Count == 0)
                    ddlCompanionClaim.Items.Insert(0, new ListItem("-- None --", "0"));
            }
            lblClaimNumber.Text = Convert.ToString(drWorkers_Comp_Claims["Origin_Claim_Number"]);
            if (!string.IsNullOrEmpty(Convert.ToString(drWorkers_Comp_Claims["ClaimReviewID"])))
            {
                if (Convert.ToString(drWorkers_Comp_Claims["ClaimReviewID"]) != "0")
                {
                    lblHeaderClaimNumber.Text = "Claim Number/Review";
                    lnkClaimReviewNumber.Visible = true;
                    lblClaimNumber.Visible = false;
                    lnkClaimReviewNumber.Text = Convert.ToString(drWorkers_Comp_Claims["Origin_Claim_Number"]);
                    Sedgwick_Claim_Review obj = new Sedgwick_Claim_Review(Convert.ToDecimal(drWorkers_Comp_Claims["ClaimReviewID"]));
                    string IsSave = "false";
                    if (obj.FK_Employee_Id == clsSession.CurrentLoginEmployeeId)
                        IsSave = "true";
                    lnkClaimReviewNumber.PostBackUrl = AppConfig.SiteURL + "SONIC/Sedgwick/ClaimSummary.aspx?PK_WCC_ID=" + Convert.ToString(drWorkers_Comp_Claims["PK_Workers_Comp_Claims_ID"]) + "&PK_SCR=" + Convert.ToString(drWorkers_Comp_Claims["ClaimReviewID"]) + "&IsSave=" + IsSave + "&IsReviewAvailable=true";
                }
                else
                {
                    lblHeaderClaimNumber.Text = "Claim Number";
                    lnkClaimReviewNumber.Visible = false;
                    lblClaimNumber.Visible = true;
                }
            }
            lblDateIncident.Text = drWorkers_Comp_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Of_Accident"]));
            lblLocationdba.Text = Convert.ToString(drWorkers_Comp_Claims["dba1"]);
            decimal _decFR_Number;
            if (drWorkers_Comp_Claims["WC_FR_Number"] != DBNull.Value)
            {
                if (decimal.TryParse(Convert.ToString(drWorkers_Comp_Claims["WC_FR_Number"]).Replace("NS-", "").Replace("WC-", ""), out _decFR_Number))
                {
                    // set WC_FR_Number for claim navigation
                    First_Report_Number = _decFR_Number;
                    //lnkAssociatedFirstReport.Text = (lblClaimNumber.Text.StartsWith("NS") ? "NS-" : "WC-") + Convert.ToString(_decFR_Number);
                    lnkAssociatedFirstReport.Text = drWorkers_Comp_Claims["WC_FR_Number"].ToString();
                    //Get the details of Associated first report from the report number.
                    int int_WC_FR = Convert.ToInt32(drWorkers_Comp_Claims["PK_WC_FR_ID"]);
                    int intInvID = Investigation.SelectPKByWc_FR_ID(int_WC_FR);
                    lnkAddInvestigation.PostBackUrl = AppConfig.SiteURL + "SONIC/FirstReport/Investigation.aspx?wc=" + int_WC_FR;

                    if (intInvID > 0)
                    {
                        lnkInvestigation.Text = intInvID.ToString();
                        lnkInvestigation.PostBackUrl = AppConfig.SiteURL + "SONIC/FirstReport/Investigation.aspx?id=" + Encryption.Encrypt(intInvID.ToString()) + "&wc=" + Encryption.Encrypt(int_WC_FR.ToString());
                        lnkAddInvestigation.Visible = false;
                    }
                }
            }
            else
            {
                lnkAddInvestigation.Visible = false;
            }

            lblName.Text = Convert.ToString(drWorkers_Comp_Claims["Employee_Name"]);
            //lblDataOrigin.Text = Convert.ToString(drWorkers_Comp_Claims["Data_Origin"]);
            //lblOriginKeyClaimNumber.Text = Convert.ToString(drWorkers_Comp_Claims["Origin_Key_Claim_Number"]);
            lblDateofUpdate.Text = drWorkers_Comp_Claims["Date_of_Update"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_Update"]));
            lblDataSource.Text = Convert.ToString(drWorkers_Comp_Claims["Data_Origin"]);
            lblClaimNumber2.Text = Convert.ToString(drWorkers_Comp_Claims["Origin_Claim_Number"]).Trim();
            lblAssociatedFirstReport.Text = Convert.ToString(drWorkers_Comp_Claims["Associated_First_Report"]);
            lblKeyClaimNumber.Text = Convert.ToString(drWorkers_Comp_Claims["Origin_Key_Claim_Number"]);

            lblClaimantSequenceNumber.Text = Convert.ToString(drWorkers_Comp_Claims["Claimant_Sequence_Number"]);
            lblEmployeeName.Text = Convert.ToString(drWorkers_Comp_Claims["Employee_Name"]);
            lblClaimantFirstName.Text = Convert.ToString(drWorkers_Comp_Claims["Claimant_First_Name"]);
            lblClaimantLastName.Text = Convert.ToString(drWorkers_Comp_Claims["Claimant_Last_Name"]);
            lblEmployeeStreet.Text = Convert.ToString(drWorkers_Comp_Claims["Employee_Street"]);
            lblEmployeeCity.Text = Convert.ToString(drWorkers_Comp_Claims["Employee_City"]);
            lblEmployeeState.Text = Convert.ToString(drWorkers_Comp_Claims["Employee_State"]);
            lblEmployeeZip.Text = Convert.ToString(drWorkers_Comp_Claims["Employee_Zip"]);
            lblEmployeeGender.Text = Convert.ToString(drWorkers_Comp_Claims["Employee_Gender"]);
            lblEmployeeSSN.Text = Convert.ToString(drWorkers_Comp_Claims["Employee_SSN"]);
            lblEmployeeMaritalStatus.Text = Convert.ToString(drWorkers_Comp_Claims["Marital_Status"]);
            lblDateofBirth.Text = drWorkers_Comp_Claims["Employee_Date_of_Birth"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Employee_Date_of_Birth"]));

            lblStateofAccident.Text = Convert.ToString(drWorkers_Comp_Claims["State_of_Accident"]);
            lblStateofJurisdiction.Text = Convert.ToString(drWorkers_Comp_Claims["State_of_Jurisdiction"]);
            lblDateReportedtoInsurer.Text = drWorkers_Comp_Claims["Date_Reported_to_Insurer"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Reported_to_Insurer"]));
            lblDateofAccident.Text = drWorkers_Comp_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Of_Accident"]));
            lblTimeofLoss.Text = Convert.ToString(drWorkers_Comp_Claims["Time_of_Loss"]);
            lblDateEntered.Text = drWorkers_Comp_Claims["Date_Entered"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Entered"]));
            lblDateClosed.Text = drWorkers_Comp_Claims["Date_Closed"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Closed"]));

            lblClaim_Sub_Status.Text = Convert.ToString(drWorkers_Comp_Claims["Claim_Sub_Status"]);
            lblClaimStatus.Text = Convert.ToString(drWorkers_Comp_Claims["Claim_Status"]);
            lblLocationCode.Text = Convert.ToString(drWorkers_Comp_Claims["Location_Code"]);
            lblCoverageCode.Text = Convert.ToString(drWorkers_Comp_Claims["Coverage_Code"]);

            lblDateSuitFiled.Text = drWorkers_Comp_Claims["Date_Suit_Filed"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Suit_Filed"]));
            lblLawSuitYN.Text = Convert.ToString(drWorkers_Comp_Claims["LitigationYN"]);
            lblSuitResultCode.Text = Convert.ToString(drWorkers_Comp_Claims["Suit_Result_Code"]);
            lblSuitTypeCode.Text = Convert.ToString(drWorkers_Comp_Claims["Suit_Type_Code"]);

            lblPlaintiffAttorneyCode.Text = Convert.ToString(drWorkers_Comp_Claims["Plaintiff_Attorney_Code"]);
            lblTPAPolicyNumber.Text = Convert.ToString(drWorkers_Comp_Claims["SRS_Policy_Number"]);
            lblTPAPolicyBeginDate.Text = drWorkers_Comp_Claims["Policy_Effective_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Policy_Effective_Date"]));
            lblTPAPolicyEndDate.Text = drWorkers_Comp_Claims["Policy_Expiration_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Policy_Expiration_Date"]));
            lblCarrierPolicyNumber.Text = Convert.ToString(drWorkers_Comp_Claims["Other_Carrier_Policy_Number"]);
            lblCarrierPolicyBeginDate.Text = drWorkers_Comp_Claims["Carrier_Effective_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Carrier_Effective_Date"]));
            lblCarrierPolicyEndDate.Text = drWorkers_Comp_Claims["Carrier_Expiration_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Carrier_Expiration_Date"]));
            lblDateDisabilityBegan.Text = drWorkers_Comp_Claims["Date_Disability_Began"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Disability_Began"]));
            lblDateofReturntoWork.Text = drWorkers_Comp_Claims["Date_Return_To_Work"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Return_To_Work"]));
            lblDateofMaximumMedicalImrovement.Text = drWorkers_Comp_Claims["Date_of_Max_Medical_Improvement"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_Max_Medical_Improvement"]));
            lblSurgeryYN.Text = Convert.ToString(drWorkers_Comp_Claims["Surgery_Indicator"]);

            lblControvertedCaseYN.Text = Convert.ToString(drWorkers_Comp_Claims["Controverted_Case_Indicator"]);
            lblDateAppealsApplicationApplied.Text = drWorkers_Comp_Claims["Date_Application_Filed"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Application_Filed"]));
            lblDateofAttorneyDisclosure.Text = drWorkers_Comp_Claims["Date_of_Attorney_Disclosure"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_Attorney_Disclosure"]));
            lblYearLastExposed.Text = Convert.ToString(drWorkers_Comp_Claims["Year_Last_Exposed"]);

            lblNCCIOccupationClassCode.Text = Convert.ToString(drWorkers_Comp_Claims["NCCI_Occupation_Class_Code"]);
            lblCompensationCoverageCode.Text = Convert.ToString(drWorkers_Comp_Claims["Compensation_Coverage_Code"]);
            lblBeneficiarysRelationship.Text = Convert.ToString(drWorkers_Comp_Claims["Beneficiary_Relationship"]);
            lblBeneficiaryDependency.Text = Convert.ToString(drWorkers_Comp_Claims["Beneficiary_Dependency_Indicator"]);
            lblBeneficiary1DateofBirth.Text = drWorkers_Comp_Claims["Beneficiary1_DOB"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Beneficiary1_DOB"]));
            lblBeneficiary2DateofBirth.Text = drWorkers_Comp_Claims["Beneficiary2_DOB"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Beneficiary2_DOB"]));
            lblBeneficiary3DateofBirth.Text = drWorkers_Comp_Claims["Beneficiary3_DOB"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Beneficiary3_DOB"]));
            lblBeneficiary4DateofBirth.Text = drWorkers_Comp_Claims["Beneficiary4_DOB"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Beneficiary4_DOB"]));


            lblOccupationDescription.Text = Convert.ToString(drWorkers_Comp_Claims["Occupation_Description"]);
            lblClaimStatusDescription.Text = Convert.ToString(drWorkers_Comp_Claims["Claim_Status_Description"]);

            lblCauseofInjuryCode.Text = Convert.ToString(drWorkers_Comp_Claims["Cause_of_Injury_Code"]);
            lblNatureofInjuryCode.Text = Convert.ToString(drWorkers_Comp_Claims["Nature_of_Injury_Code"]);
            lblPartofBodyCode.Text = Convert.ToString(drWorkers_Comp_Claims["Part_of_Body_Code"]);
            lblCauseInjuryBodyPartDescription.Text = Convert.ToString(drWorkers_Comp_Claims["Cause_Injury_Body_Part_Description"]);
            lblLTMEDonlyIndicator.Text = Convert.ToString(drWorkers_Comp_Claims["LT_Med_Only_Flag"]);
            lblDateofHire.Text = drWorkers_Comp_Claims["Date_of_Hire"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_Hire"]));
            lblStateofEmployment.Text = Convert.ToString(drWorkers_Comp_Claims["State_of_Employment"]);
            lblNatureofBenefitCode.Text = Convert.ToString(drWorkers_Comp_Claims["Nature_of_Benefit_Code"]);
            lblNumberofDependents.Text = Convert.ToString(drWorkers_Comp_Claims["Number_of_Dependents"]);
            lblPercentageofImpairment.Text = Convert.ToString(drWorkers_Comp_Claims["Percentage_Impairment"]);
            lblZipcodeofAccidentSite.Text = Convert.ToString(drWorkers_Comp_Claims["Zip_of_Accident_Site"]);
            lblDateofDeath.Text = drWorkers_Comp_Claims["Date_of_Death"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_Death"]));
            lblDateReportedtoEmployer.Text = drWorkers_Comp_Claims["Date_Reported_to_Employer"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Reported_to_Employer"]));
            lblDateofFirstIndemnityPayment.Text = drWorkers_Comp_Claims["Date_of_First_Indemnity_Payment"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_First_Indemnity_Payment"]));
            lblAccidentCityTown.Text = Convert.ToString(drWorkers_Comp_Claims["Accident_City_Town"]);
            lblEmploymentStatus.Text = Convert.ToString(drWorkers_Comp_Claims["Employment_Status"]);

            lblNCCICauseofInjuryCode.Text = Convert.ToString(drWorkers_Comp_Claims["FK_NCCI_Cause_of_Injury_Code"]);
            lblNCCIBodyPartCode.Text = Convert.ToString(drWorkers_Comp_Claims["FK_NCCI_Body_Part_Code"]);
            lblNCCINatureofInjuryCode.Text = Convert.ToString(drWorkers_Comp_Claims["NCCI_Nature_Of_Injury_Code"]);
            lblPreviousTPAClaim.Text = Convert.ToString(drWorkers_Comp_Claims["Previous_TPA_Claim_Num_Takeover"]);
            lblAdjustorCode.Text = Convert.ToString(drWorkers_Comp_Claims["Adjustor_Code"]);
            txtDateRestrictedWorkBegan.Text = clsGeneral.FormatDBNullDateToDisplay(drWorkers_Comp_Claims["Date_Restricted_Work_Began"]);
            txtDateRestrictedWorkEnd.Text = clsGeneral.FormatDBNullDateToDisplay(drWorkers_Comp_Claims["Date_Restricted_Work_Ended"]);

            lblClaimantAttorneyRepresentativeYN.Text = Convert.ToString(drWorkers_Comp_Claims["Attorney_Authorized_Rep"]);
            lblIndemnityGrossPaid.Text = drWorkers_Comp_Claims["Indemnity_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Gross_Paid"])) : "";
            lblNetIndemnityPaid.Text = drWorkers_Comp_Claims["Net_Indemnity_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Net_Indemnity_Paid"])) : "";
            lblIndemnityNetRecovered.Text = drWorkers_Comp_Claims["Indemnity_Net_Recovered"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Net_Recovered"])) : "";
            lblIndemnityIncurred.Text = drWorkers_Comp_Claims["Indemnity_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Incurred"])) : "";
            lblIndemnityOutstanding.Text = drWorkers_Comp_Claims["Indemnity_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Outstanding"])) : "";
            lblExpenseGrossPaid.Text = drWorkers_Comp_Claims["Expense_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Expense_Gross_Paid"])) : "";
            lblNetExpensePaid.Text = drWorkers_Comp_Claims["Net_Expense_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Net_Expense_Paid"])) : "";
            lblExpenseNetRecovered.Text = drWorkers_Comp_Claims["Expense_Net_Recovered"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Expense_Net_Recovered"])) : "";
            lblExpenseIncurred.Text = drWorkers_Comp_Claims["Expense_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Expense_Incurred"])) : "";
            lblExpenseOutstanding.Text = drWorkers_Comp_Claims["Expense_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Expense_Outstanding"])) : "";
            lblMedicalGrossPaid.Text = drWorkers_Comp_Claims["Medical_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Gross_Paid"])) : "";
            lblNetMedicalPaid.Text = drWorkers_Comp_Claims["Net_Medical_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Net_Medical_Paid"])) : "";
            lblMedicalNetRecovered.Text = drWorkers_Comp_Claims["Medical_Net_Recovered"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Net_Recovered"])) : "";
            lblMedicalIncurred.Text = drWorkers_Comp_Claims["Medical_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Incurred"])) : "";
            lblMedicalOutstanding.Text = drWorkers_Comp_Claims["Medical_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Outstanding"])) : "";
            lblIndemnityGrossSubrogation.Text = drWorkers_Comp_Claims["Indemnity_Gross_Subrogation"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Gross_Subrogation"])) : "";
            lblIndemnitySubrogationExpense.Text = drWorkers_Comp_Claims["Indemnity_Subrogation_Expense"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Subrogation_Expense"])) : "";
            lblIndemnityGrossSalvage.Text = drWorkers_Comp_Claims["Indemnity_Gross_Salvage"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Gross_Salvage"])) : "";
            lblIndemnitySalvageExpense.Text = drWorkers_Comp_Claims["Indemnity_Salvage_Expense"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Salvage_Expense"])) : "";
            lblIndemnityGrossRefund.Text = drWorkers_Comp_Claims["Indemnity_Gross_Refund"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Gross_Refund"])) : "";
            lblAleGrossSubrogation.Text = drWorkers_Comp_Claims["Ale_Gross_Subrogation"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Ale_Gross_Subrogation"])) : "";
            lblAleGrossSalvage.Text = drWorkers_Comp_Claims["Ale_Gross_Salvage"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Ale_Gross_Salvage"])) : "";
            lblAleGrossRefund.Text = drWorkers_Comp_Claims["Ale_Gross_Refund"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Ale_Gross_Refund"])) : "";
            lblAleRefundExpense.Text = drWorkers_Comp_Claims["Ale_Refund_Expense"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Ale_Refund_Expense"])) : "";
            lblLegalExpenseIncurred.Text = drWorkers_Comp_Claims["Legal_Expense_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Legal_Expense_Incurred"])) : "";
            lblLegalExpensePaidtoDate.Text = drWorkers_Comp_Claims["Legal_Expense_Paid_to_Date"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Legal_Expense_Paid_to_Date"])) : "";
            lblRecoveredIndemnityDeductibleAmount.Text = drWorkers_Comp_Claims["Recovered_Indemnity_Deductible_Amount"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Recovered_Indemnity_Deductible_Amount"])) : "";
            lblRecoveredExpenseDeductibleAmount.Text = drWorkers_Comp_Claims["Recovered_Expense_Deductible_Amount"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Recovered_Expense_Deductible_Amount"])) : "";
            lblRecoveredMedicalDeductibleAmount.Text = drWorkers_Comp_Claims["Recovered_Medical_Deductible_Amount"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Recovered_Medical_Deductible_Amount"])) : "";
            lblMedicalGrossSubrogation.Text = drWorkers_Comp_Claims["Medical_Gross_Subrogation"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Gross_Subrogation"])) : "";
            lblMedicalGrossRefund.Text = drWorkers_Comp_Claims["Medical_Gross_Refund"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Gross_Refund"])) : "";
            lblClaimSubrogationPaidtoDate.Text = drWorkers_Comp_Claims["Claim_Subrogation_Paid_to_Date"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Claim_Subrogation_Paid_to_Date"])) : "";
            lblTotalPaymentToPhysicians.Text = drWorkers_Comp_Claims["Total_Payment_To_Physicians"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Total_Payment_To_Physicians"])) : "";
            lblHospitalExpensesPaidToDate.Text = drWorkers_Comp_Claims["Hospital_Expenses_Paid_To_Date"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Hospital_Expenses_Paid_To_Date"])) : "";
            lblOtherMedicalPaidtoDate.Text = drWorkers_Comp_Claims["Other_Medical_Paid_to_Date"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Other_Medical_Paid_to_Date"])) : "";
            lblVocaRehabExpensePTD.Text = drWorkers_Comp_Claims["Voca_Rehab_Expense_PTD"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Voca_Rehab_Expense_PTD"])) : "";
            lblVocaRehabMaintenancePTD.Text = drWorkers_Comp_Claims["Voca_Rehab_Maintenance_PTD"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Voca_Rehab_Maintenance_PTD"])) : "";
            lblVocaRehabEvaluationPTD.Text = drWorkers_Comp_Claims["Voca_Rehab_Evaluation_PTD"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Voca_Rehab_Evaluation_PTD"])) : "";
            lblVocaRehabEducationPTD.Text = drWorkers_Comp_Claims["Voca_Rehab_Education_PTD"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Voca_Rehab_Education_PTD"])) : "";
            lblOtherVocaRehabExpensesPTD.Text = drWorkers_Comp_Claims["Other_Voca_Rehab_Expenses_PTD"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Other_Voca_Rehab_Expenses_PTD"])) : "";
            lblVocaRehabExpenseIncurred.Text = drWorkers_Comp_Claims["Voca_Rehab_Expense_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Voca_Rehab_Expense_Incurred"])) : "";
            lblNonScheduledIndemnityIncurred.Text = drWorkers_Comp_Claims["Non_Scheduled_Indemnity_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Non_Scheduled_Indemnity_Incurred"])) : "";
            lblNonScheduledImpairmentPercent.Text = Convert.ToString(drWorkers_Comp_Claims["Non_Scheduled_Impairment_Percent"]);
            lblFuneralExpensePTD.Text = drWorkers_Comp_Claims["Funeral_Expense_PTD"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Funeral_Expense_PTD"])) : "";
            lblLumpSumSettlementAmount.Text = drWorkers_Comp_Claims["Lump_Sum_Settlement_Amount"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Lump_Sum_Settlement_Amount"])) : "";
            lblEmployersLiabilityPTD.Text = drWorkers_Comp_Claims["Employers_Liability_PTD"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Employers_Liability_PTD"])) : "";
            lblTemporaryIndemnityIncurred.Text = drWorkers_Comp_Claims["Temporary_Indemnity_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Temporary_Indemnity_Incurred"])) : "";
            lblPreviousTPAIndemnityPaid.Text = drWorkers_Comp_Claims["Previous_TPA_Indemnity_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Previous_TPA_Indemnity_Paid"])) : "";
            lblPreviousTPAMedicalPaid.Text = drWorkers_Comp_Claims["Previous_TPA_Medical_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Previous_TPA_Medical_Paid"])) : "";
            lblPreviousTPAExpensePaid.Text = drWorkers_Comp_Claims["Previous_TPA_Expense_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Previous_TPA_Expense_Paid"])) : "";
            lblEmployeeLegalExpensePTD.Text = drWorkers_Comp_Claims["Employee_Legal_Expense_PTD"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Employee_Legal_Expense_PTD"])) : "";

            lblEffectiveDate.Text = drWorkers_Comp_Claims["RTW_Effective_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Effective_Date"]));
            lblWorkStatusType.Text = Convert.ToString(drWorkers_Comp_Claims["RTW_Work_Status_Type"]);
            lblAuthorizedOffWork.Text = drWorkers_Comp_Claims["RTW_Authorized_Off_Work"] == DBNull.Value ? "" : GetYesNo(Convert.ToString(drWorkers_Comp_Claims["RTW_Authorized_Off_Work"]));
            lblLastWorked.Text = drWorkers_Comp_Claims["RTW_Date_Last_Worked"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Date_Last_Worked"]));
            lblLastWorkedFullDay.Text = drWorkers_Comp_Claims["RTW_DLW_Full_Day"] == DBNull.Value ? "" : GetYesNo(Convert.ToString(drWorkers_Comp_Claims["RTW_DLW_Full_Day"]));
            lblExaminerAnticipatesFullDate.Text = drWorkers_Comp_Claims["RTW_Anticipated_RTW_Ex_Full_Duty"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Anticipated_RTW_Ex_Full_Duty"]));
            lblExaminerAnticipatesRestrictedDate.Text = drWorkers_Comp_Claims["RTW_Anticipated_RTW_Ex_Restricted"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Anticipated_RTW_Ex_Restricted"]));
            lblCaseManagerAnticipateFullDay.Text = drWorkers_Comp_Claims["RTW_Anticipated_RTW_CM_Full_Duty"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Anticipated_RTW_CM_Full_Duty"]));
            lblCaseManagerAnticipateRestrictedDay.Text = drWorkers_Comp_Claims["RTW_Anticipated_RTW_CM_Restricted"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Anticipated_RTW_CM_Restricted"]));
            lblPhysicianAnticipatesFullDay.Text = drWorkers_Comp_Claims["RTW_Anticipated_RTW_Ph_Full_Duty"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Anticipated_RTW_Ph_Full_Duty"]));
            lblPhysicianAnticipatesRestrictedDay.Text = drWorkers_Comp_Claims["RTW_Anticipated_RTW_Ph_Restricted"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Anticipated_RTW_Ph_Restricted"]));
            lblModerateDutyAval.Text = drWorkers_Comp_Claims["RTW_Moderate_Duty_Available"] == DBNull.Value ? "" : GetYesNo(Convert.ToString(drWorkers_Comp_Claims["RTW_Moderate_Duty_Available"]));
            lblModerateDutyOffered.Text = drWorkers_Comp_Claims["RTW_Modified_Duty_Offered"] == DBNull.Value ? "" : GetYesNo(Convert.ToString(drWorkers_Comp_Claims["RTW_Modified_Duty_Offered"]));
            lblModerateDutyAccepted.Text = drWorkers_Comp_Claims["RTW_Modified_Duty_Accepted"] == DBNull.Value ? "" : GetYesNo(Convert.ToString(drWorkers_Comp_Claims["RTW_Modified_Duty_Accepted"]));
            lblModifiedDutyOccupation.Text = Convert.ToString(drWorkers_Comp_Claims["RTW_Modified_Duty_Occupation"]);
            lblModifiedDutyDemand.Text = Convert.ToString(drWorkers_Comp_Claims["RTW_Modified_Duty_Demand"]);
            lblFullDaysModifiedDuty.Text = drWorkers_Comp_Claims["RTW_Full_Days_Modified_Duty"] == DBNull.Value ? "" : GetYesNo(Convert.ToString(drWorkers_Comp_Claims["RTW_Full_Days_Modified_Duty"]));
            lblHoursModifiedDuty.Text = drWorkers_Comp_Claims["RTW_Hours_Modified_Duty"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["RTW_Hours_Modified_Duty"])) : "";
            lblRTWOccupation.Text = Convert.ToString(drWorkers_Comp_Claims["RTW_Occupation"]);
            lblRTWDemand.Text = Convert.ToString(drWorkers_Comp_Claims["RTW_Demand"]);
            lblRTWSchedule.Text = Convert.ToString(drWorkers_Comp_Claims["RTW_Schedule"]);
            lblDateModifiedDutyAval.Text = drWorkers_Comp_Claims["RTW_Date_Modified_Duty_Available"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Date_Modified_Duty_Available"]));
            lblDateModifiedDutyOffered.Text = drWorkers_Comp_Claims["RTW_Date_Modified_Duty_Offered"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Date_Modified_Duty_Offered"]));
            lblDateModifiedDutyAccepted.Text = drWorkers_Comp_Claims["RTW_Date_Modified_Duty_Accepted"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Date_Modified_Duty_Accepted"]));
            lblDateNotified.Text = drWorkers_Comp_Claims["RTW_Date_Notified"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Date_Notified"]));
            lblDisabilityBegan.Text = drWorkers_Comp_Claims["RTW_Date_Disability_Began"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Date_Disability_Began"]));
            lblNumberLostTimeDays.Text = drWorkers_Comp_Claims["RTW_Number_Lost_Time_Days"] != DBNull.Value ? String.Format("{0:N0}", Convert.ToDecimal(drWorkers_Comp_Claims["RTW_Number_Lost_Time_Days"])) : "";
            lblNumberRestrictedWorkDays.Text = drWorkers_Comp_Claims["RTW_Number_Restricted_Work_Days"] != DBNull.Value ? String.Format("{0:N0}", Convert.ToDecimal(drWorkers_Comp_Claims["RTW_Number_Restricted_Work_Days"])) : "";

            lblReasonForTermination.Text = Convert.ToString(drWorkers_Comp_Claims["RTW_Reason_For_Termination"]);

            txtFrom_Work_Began.Text = clsGeneral.FormatDBNullDateToDisplay(drWorkers_Comp_Claims["OSHA_Start_Away_From_Work"]);
            txtFrom_Work_End.Text = clsGeneral.FormatDBNullDateToDisplay(drWorkers_Comp_Claims["OSHA_End_Away_From_Work"]);
            txtDays_Away_From_Work.Text = Convert.ToString(drWorkers_Comp_Claims["OSHA_Days_Away_From_Work"]);

            txtDate_On_Job_Began.Text = clsGeneral.FormatDBNullDateToDisplay(drWorkers_Comp_Claims["OSHA_Start_Job_Transfer_Restriction"]);
            txtDate_On_Job_End.Text = clsGeneral.FormatDBNullDateToDisplay(drWorkers_Comp_Claims["OSHA_End_Job_Transfer_Restriction"]);
            txtDays_On_Job.Text = Convert.ToString(drWorkers_Comp_Claims["OSHA_Days_Job_Transfer_Restriction"]);

            BindWCTransList(lblClaimNumber2.Text, ctrlPageTransaction.CurrentPage, ctrlPageTransaction.PageSize);
            //gvWCTransList.DataSource = Claims_Transaction.SelectByOriginClaimNumber(lblClaimNumber2.Text,);
            //gvWCTransList.DataBind();

            ucAdjusterNotes.ClaimID = PK_WC_CI_ID;
            ucAdjusterNotes.ClaimNumber = lblClaimNumber2.Text;
            ucAdjusterNotes.BindGridNotes(lblClaimNumber2.Text);

            ctrlSonicNotes.PK_WC_CI_ID = PK_WC_CI_ID;
            ctrlSonicNotes.CurrentClaimType = clsGeneral.Claim_Tables.WCClaim.ToString();
            ctrlSonicNotes.BindGridSonicNotes(PK_WC_CI_ID, clsGeneral.Claim_Tables.WCClaim.ToString());

            DataSet objDs = new DataSet();

            objDs = ERIMS.DAL.Claim_CST.Claim_CSTSelectByOriginClaimNumber(Convert.ToString(drWorkers_Comp_Claims["Origin_Claim_Number"]).Trim());
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

    private string GetYesNo(string strYesNo)
    {
        if (strYesNo.ToLower() == "y")
            return "Yes";
        else if (strYesNo.ToLower() == "n")
            return "No";
        else if (strYesNo.ToLower() == "yes")
            return "Yes";
        else if (strYesNo.ToLower() == "no")
            return "No";
        else
            return strYesNo;
    }
    /// <summary>
    /// Function to bind the transaction detials when click on transaction list
    /// </summary>
    /// <param name="PK_ID">Claim Transaction PK Id</param>
    /// <returns></returns>
    public bool BindClaimTransactionDetails(string PK_IDs)
    {
        DataTable dtClaims_Transactions = Claims_Transaction.SelectByPKIDs(PK_IDs).Tables[0];
        if (dtClaims_Transactions.Rows.Count > 0)
        {
            if (dtClaims_Transactions.Rows.Count == 1)
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

                pnlTransactionDetail.Visible = false;
                pnlSingleTransactionDetail.Visible = true;
                pnlTransGrid.Visible = true;
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "SelectDeselectTransHeader(true);", true);
            }
            else
            {
                rptTransDetail.DataSource = dtClaims_Transactions;
                rptTransDetail.DataBind();

                hdnRptRows.Value = dtClaims_Transactions.Rows.Count.ToString();
                pnlTransactionDetail.Visible = true;
                pnlSingleTransactionDetail.Visible = false;
                pnlTransGrid.Visible = false;
            }

            return true;
        }
        return false;
    }

    /// <summary>
    /// //Bind Risk Management WorkSheet
    /// </summary>
    public void BindRiskMangWorkSheet()
    {
        DataSet dsWorkers_Comp_Claims = WC_ClaimInfo.SelectByPK(PK_WC_CI_ID);
        DataTable dtWorkers_Comp_Claims = dsWorkers_Comp_Claims.Tables[0];

        TextBox txtSettlement_MethodChange = (TextBox)txtSettlement_Method.FindControl("txtNote");
        txtSettlement_MethodChange.Attributes.Remove("onchange");
        txtSettlement_MethodChange.Attributes.Add("onchange", "OnChangeFunction();");

        TextBox txtCommentsChange = (TextBox)txtComments.FindControl("txtNote");
        txtCommentsChange.Attributes.Remove("onchange");
        txtCommentsChange.Attributes.Add("onchange", "OnChangeFunction();");

        decimal TotalReserve = 0;
        decimal TotalPaid = 0;
        decimal TotalOutstanding = 0;
        if (dtWorkers_Comp_Claims.Rows.Count > 0)
        {
            DataRow drWorkers_Comp_Claims = dtWorkers_Comp_Claims.Rows[0];

            lblOrigin_Claim_Number.Text = Convert.ToString(drWorkers_Comp_Claims["Origin_Claim_Number"]);
            lblDate_of_Accident.Text = drWorkers_Comp_Claims["Date_of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_Accident"]));
            lblClaimant_First_Name.Text = Convert.ToString(drWorkers_Comp_Claims["Claimant_First_Name"]);
            lblClaimant_Last_Name.Text = Convert.ToString(drWorkers_Comp_Claims["Claimant_Last_Name"]);
            lblEmployee_Date_of_Birth.Text = drWorkers_Comp_Claims["Employee_Date_of_Birth"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Employee_Date_of_Birth"]));
            lblDate_of_Hire.Text = drWorkers_Comp_Claims["Date_of_Hire"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_Hire"]));
            lblDate_Reported_To_Employer.Text = drWorkers_Comp_Claims["Date_Reported_To_Employer"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Reported_To_Employer"]));
            lblDate_Reported_To_Insurer.Text = drWorkers_Comp_Claims["Date_Reported_To_Insurer"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Reported_To_Insurer"]));
            lblState_Of_Accident.Text = Convert.ToString(drWorkers_Comp_Claims["State_Of_Accident"]);
            lblFK_Part_of_Body_Code.Text = new LU_Part_of_Body_Code(string.IsNullOrEmpty(Convert.ToString(drWorkers_Comp_Claims["FK_Part_of_Body_Code"])) ? "" : Convert.ToString(drWorkers_Comp_Claims["FK_Part_of_Body_Code"])).Description;
            lblCause_Injury_Body_Part_Description.Text = Convert.ToString(drWorkers_Comp_Claims["Cause_Injury_Body_Part_Description"]);
            lblFK_Nature_of_Injury_Code.Text = Convert.ToString(drWorkers_Comp_Claims["Nature_of_Injury_Code"]);// new LU_Nature_of_Injury_Code(string.IsNullOrEmpty(Convert.ToString(drWorkers_Comp_Claims["FK_Nature_of_Injury_Code"])) ? "" : Convert.ToString(drWorkers_Comp_Claims["FK_Nature_of_Injury_Code"])).Description;
            lblSurgery_Indicator.Text = Convert.ToString(drWorkers_Comp_Claims["Surgery_Indicator"]) == "2" ? "Yes" : "No";
            lblDate_Disability_Began.Text = drWorkers_Comp_Claims["Date_Disability_Began"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Disability_Began"]));
            lblDate_Return_To_Work.Text = drWorkers_Comp_Claims["Date_Return_To_Work"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Return_To_Work"]));
            lblPercentage_Impairment.Text = Convert.ToString(drWorkers_Comp_Claims["Percentage_Impairment"]);
            lblFK_Cause_of_Injury_Code.Text = Convert.ToString(drWorkers_Comp_Claims["Cause_of_Injury_Code"]); //new LU_Cause_of_Injury(string.IsNullOrEmpty(Convert.ToString(drWorkers_Comp_Claims["FK_Cause_of_Injury_Code"])) ? "" : Convert.ToString(drWorkers_Comp_Claims["FK_Cause_of_Injury_Code"])).Description;
            lblClaim_Status_Description.Text = Convert.ToString(drWorkers_Comp_Claims["Claim_Status_Description"]);
            lblDate_of_Max_Medical_Improvement.Text = drWorkers_Comp_Claims["Date_of_Max_Medical_Improvement"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_Max_Medical_Improvement"]));
            lblFK_NCCI_Occupation_Class_Code.Text = Convert.ToString(drWorkers_Comp_Claims["NCCI_Occupation_Class_Code"]);// new LU_NCCI_Occupation_Class_Code(string.IsNullOrEmpty(Convert.ToString(drWorkers_Comp_Claims["FK_NCCI_Occupation_Class_Code"])) ? "" : Convert.ToString(drWorkers_Comp_Claims["FK_NCCI_Occupation_Class_Code"])).Description;

            lblIndemnity_Incurred.Text = drWorkers_Comp_Claims["Indemnity_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Incurred"])) : "";
            TotalReserve = TotalReserve + (string.IsNullOrEmpty(Convert.ToString(drWorkers_Comp_Claims["Indemnity_Incurred"])) ? 0 : Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Incurred"]));
            lblMedical_Incurred.Text = drWorkers_Comp_Claims["Medical_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Incurred"])) : "";
            TotalReserve = TotalReserve + (string.IsNullOrEmpty(Convert.ToString(drWorkers_Comp_Claims["Medical_Incurred"])) ? 0 : Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Incurred"]));
            lblExpense_Incurred.Text = drWorkers_Comp_Claims["Expense_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Expense_Incurred"])) : "";
            TotalReserve = TotalReserve + (string.IsNullOrEmpty(Convert.ToString(drWorkers_Comp_Claims["Expense_Incurred"])) ? 0 : Convert.ToDecimal(drWorkers_Comp_Claims["Expense_Incurred"]));
            lblTotal_Reserve.Text = String.Format("$ {0:N2}", Convert.ToDecimal(TotalReserve));

            lblIndemnity_Gross_Paid.Text = drWorkers_Comp_Claims["Indemnity_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Gross_Paid"])) : "";
            TotalPaid = TotalPaid + (string.IsNullOrEmpty(Convert.ToString(drWorkers_Comp_Claims["Indemnity_Gross_Paid"])) ? 0 : Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Gross_Paid"]));
            lblMedical_Gross_Paid.Text = drWorkers_Comp_Claims["Medical_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Gross_Paid"])) : "";
            TotalPaid = TotalPaid + (string.IsNullOrEmpty(Convert.ToString(drWorkers_Comp_Claims["Medical_Gross_Paid"])) ? 0 : Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Gross_Paid"]));
            lblExpense_Gross_Paid.Text = drWorkers_Comp_Claims["Expense_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Expense_Gross_Paid"])) : "";
            TotalPaid = TotalPaid + (string.IsNullOrEmpty(Convert.ToString(drWorkers_Comp_Claims["Expense_Gross_Paid"])) ? 0 : Convert.ToDecimal(drWorkers_Comp_Claims["Expense_Gross_Paid"]));
            lblTotal_Paid.Text = String.Format("$ {0:N2}", Convert.ToDecimal(TotalPaid));

            lblIndemnity_Outstanding.Text = drWorkers_Comp_Claims["Indemnity_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Outstanding"])) : "";
            TotalOutstanding = TotalOutstanding + (string.IsNullOrEmpty(Convert.ToString(drWorkers_Comp_Claims["Indemnity_Outstanding"])) ? 0 : Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Outstanding"]));
            lblMedical_Outstanding.Text = drWorkers_Comp_Claims["Medical_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Outstanding"])) : "";
            TotalOutstanding = TotalOutstanding + (string.IsNullOrEmpty(Convert.ToString(drWorkers_Comp_Claims["Medical_Outstanding"])) ? 0 : Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Outstanding"]));
            lblExpense_Outstanding.Text = drWorkers_Comp_Claims["Expense_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drWorkers_Comp_Claims["Expense_Outstanding"])) : "";
            TotalOutstanding = TotalOutstanding + (string.IsNullOrEmpty(Convert.ToString(drWorkers_Comp_Claims["Expense_Outstanding"])) ? 0 : Convert.ToDecimal(drWorkers_Comp_Claims["Expense_Outstanding"]));
            lblTotal_Outstanding.Text = String.Format("$ {0:N2}", Convert.ToDecimal(TotalOutstanding));

            lblFK_LU_Claim_SubType.Text = new LU_Claim_SubType(clsGeneral.GetDecimal(drWorkers_Comp_Claims["FK_LU_Claim_SubType"])).Fld_Description;

            DataSet dsWCR = Workers_Comp_RMW.SelectByFK(PK_WC_CI_ID);
            DataTable dtWCR = dsWCR.Tables[0];
            PK_Workers_Comp_RMW = 0;
            if (dtWCR.Rows.Count > 0)
            {
                DataRow drWCR = dtWCR.Rows[0];
                PK_Workers_Comp_RMW = Convert.ToInt32(drWCR["PK_Workers_Comp_RMW"]);
                txtSettlement_Method.Text = Convert.ToString(drWCR["Settlement_Method"]);
                txtPolicy_Deductible.Text = Convert.ToString(drWCR["Policy_Deductible"]);

                if (drWCR["Compensation_Originally_Denied"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["Compensation_Originally_Denied"]) == true)
                    {
                        rdoCompensation_Originally_Denied.SelectedValue = "1";
                    }
                    else
                    {
                        rdoCompensation_Originally_Denied.SelectedValue = "0";
                    }
                }

                if (drWCR["LS_Reimbursement_Of_Cost"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["LS_Reimbursement_Of_Cost"]) == true)
                    {
                        rdoLS_Reimbursement_Of_Cost.SelectedValue = "1";
                    }
                    else
                    {
                        rdoLS_Reimbursement_Of_Cost.SelectedValue = "0";
                    }
                }

                if (drWCR["Waive_Subrogation"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["Waive_Subrogation"]) == true)
                    {
                        rdoWaive_Subrogation.SelectedValue = "1";
                    }
                    else
                    {
                        rdoWaive_Subrogation.SelectedValue = "0";
                    }
                }

                if (drWCR["Close_Medicals"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["Close_Medicals"]) == true)
                    {
                        rdoClose_Medicals.SelectedValue = "1";
                    }
                    else
                    {
                        rdoClose_Medicals.SelectedValue = "0";
                    }
                }

                if (drWCR["Confidentiality_Clause"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["Confidentiality_Clause"]) == true)
                    {
                        rdoConfidentiality_Clause.SelectedValue = "1";
                    }
                    else
                    {
                        rdoConfidentiality_Clause.SelectedValue = "0";
                    }
                }

                if (drWCR["Other_Medicals"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["Other_Medicals"]) == true)
                    {
                        rdoOther_Medicals.SelectedValue = "1";
                    }
                    else
                    {
                        rdoOther_Medicals.SelectedValue = "0";
                    }
                }

                if (drWCR["Settlement_of_Permanent_Total"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["Settlement_of_Permanent_Total"]) == true)
                    {
                        rdoSettlement_of_Permanent_Total.SelectedValue = "1";
                    }
                    else
                    {
                        rdoSettlement_of_Permanent_Total.SelectedValue = "0";
                    }
                }

                if (drWCR["Resignation"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["Resignation"]) == true)
                    {
                        rdoResignation.SelectedValue = "1";
                    }
                    else
                    {
                        rdoResignation.SelectedValue = "0";
                    }
                }

                if (drWCR["Other_Classification"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["Other_Classification"]) == true)
                    {
                        rdoOther_Classification.SelectedValue = "1";
                    }
                    else
                    {
                        rdoOther_Classification.SelectedValue = "0";
                    }
                }

                txtResignation_Date.Text = drWCR["Resignation_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["Resignation_Date"]));

                txtDefense_Council_Name.Text = Convert.ToString(drWCR["Defense_Council_Name"]);
                txtDefense_Council_Telephone.Text = Convert.ToString(drWCR["Defense_Council_Telephone"]);
                txtClaimant_Attorney.Text = Convert.ToString(drWCR["Claimant_Attorney"]);
                txtClaimant_Attorney_Telephone.Text = Convert.ToString(drWCR["Claimant_Attorney_Telephone"]);
                txtTrial_Date.Text = drWCR["Trial_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["Trial_Date"]));
                txtMediation_Date.Text = drWCR["Mediation_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["Mediation_Date"]));

                txtDemand_Amount.Text = drWCR["Demand_Amount"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drWCR["Demand_Amount"]));
                txtADJ_Requested_Amount.Text = drWCR["ADJ_Requested_Amount"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drWCR["ADJ_Requested_Amount"]));
                txtRM_Requested_Amount.Text = drWCR["RM_Requested_Amount"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drWCR["RM_Requested_Amount"]));
                txtAuthorized_Amount.Text = drWCR["Authorized_Amount"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drWCR["Authorized_Amount"]));
                txtPotential_Total_Exposure.Text = drWCR["Potential_Total_Exposure"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drWCR["Potential_Total_Exposure"]));
                txtSettled_Amount.Text = drWCR["Settled_Amount"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drWCR["Settled_Amount"]));
                if (drWCR["Settled"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["Settled"]) == true)
                    {
                        rdoSettled.SelectedValue = "1";
                    }
                    else
                    {
                        rdoSettled.SelectedValue = "0";
                    }
                }

                if (drWCR["Full_Final_Clincher"] != DBNull.Value)
                {
                    rdoFullFinalClincher.SelectedValue = Convert.ToString(drWCR["Full_Final_Clincher"]);
                }

                txtGM_Email_To.Text = Convert.ToString(drWCR["GM_Email_To"]);
                txtGM_Last_Email_Date.Text = drWCR["GM_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["GM_Last_Email_Date"]));
                txtGM_Response_Date.Text = drWCR["GM_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["GM_Response_Date"]));
                if (drWCR["GM_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["GM_Decision"]) == true)
                    {
                        rdoGM_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoGM_Decision.SelectedValue = "0";
                    }
                }

                txtCRM_Email_To.Text = Convert.ToString(drWCR["CRM_Email_To"]);
                txtCRM_Last_Email_Date.Text = drWCR["CRM_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["CRM_Last_Email_Date"]));
                txtCRM_Response_Date.Text = drWCR["CRM_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["CRM_Response_Date"]));
                if (drWCR["CRM_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["CRM_Decision"]) == true)
                    {
                        rdoCRM_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoCRM_Decision.SelectedValue = "0";
                    }
                }

                txtRVP_Email_To.Text = Convert.ToString(drWCR["RVP_Email_To"]);
                txtRVP_Last_Email_Date.Text = drWCR["RVP_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["RVP_Last_Email_Date"]));
                txtRVP_Response_Date.Text = drWCR["RVP_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["RVP_Response_Date"]));
                if (drWCR["RVP_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["RVP_Decision"]) == true)
                    {
                        rdoRVP_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoRVP_Decision.SelectedValue = "0";
                    }
                }


                txtCC_Email_To.Text = Convert.ToString(drWCR["CC_Email_To"]);
                txtCC_Last_Email_Date.Text = drWCR["CC_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["CC_Last_Email_Date"]));
                txtCC_Response_Date.Text = drWCR["CC_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["CC_Response_Date"]));
                if (drWCR["CC_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["CC_Decision"]) == true)
                    {
                        rdoCC_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoCC_Decision.SelectedValue = "0";
                    }
                }

                txtDRM_Email_To.Text = Convert.ToString(drWCR["DRM_Email_To"]);
                txtDRM_Last_Email_Date.Text = drWCR["DRM_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["DRM_Last_Email_Date"]));
                txtDRM_Response_Date.Text = drWCR["DRM_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["DRM_Response_Date"]));
                if (drWCR["DRM_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["DRM_Decision"]) == true)
                    {
                        rdoDRM_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoDRM_Decision.SelectedValue = "0";
                    }
                }

                txtCFO_Email_To.Text = Convert.ToString(drWCR["CFO_Email_To"]);
                txtCFO_Last_Email_Date.Text = drWCR["CFO_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["CFO_Last_Email_Date"]));
                txtCFO_Response_Date.Text = drWCR["CFO_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["CFO_Response_Date"]));
                if (drWCR["CFO_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["CFO_Decision"]) == true)
                    {
                        rdoCFO_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoCFO_Decision.SelectedValue = "0";
                    }
                }

                txtCOO_Email_To.Text = Convert.ToString(drWCR["COO_Email_To"]);
                txtCOO_Last_Email_Date.Text = drWCR["COO_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["COO_Last_Email_Date"]));
                txtCOO_Response_Date.Text = drWCR["COO_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWCR["COO_Response_Date"]));
                if (drWCR["COO_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drWCR["COO_Decision"]) == true)
                    {
                        rdoCOO_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoCOO_Decision.SelectedValue = "0";
                    }
                }

                txtComments.Text = Convert.ToString(drWCR["Comments"]);
            }
        }
    }

    /// <summary>
    /// Bind Grid Sonic Note
    /// </summary>
    //private void BindGridSonicNotes(decimal FK_Table,string Table_Name,int PageNumber,int PageSize)
    //{
    //    //DataTable dtNotes = Claim_Notes.SelectByFK_Table(PK_WC_CI_ID, clsGeneral.Claim_Tables.WCClaim.ToString(),PageNumber,PageSize).Tables[0];
    //    //gvNotes.DataSource = dtNotes;
    //    //gvNotes.DataBind();

    //    //btnView.Visible = dtNotes.Rows.Count > 0;
    //    //btnPrint.Visible = dtNotes.Rows.Count > 0;
    //}

    /// <summary>
    /// btn Save Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //createing object
        Workers_Comp_RMW objWCR = new Workers_Comp_RMW();
        objWCR.FK_Workers_Comp_Claims = PK_WC_CI_ID;
        objWCR.Update_Date = DateTime.Now;
        objWCR.Updated_By = clsSession.UserID;
        objWCR.Settlement_Method = txtSettlement_Method.Text;
        objWCR.Policy_Deductible = string.IsNullOrEmpty(txtPolicy_Deductible.Text) ? 0 : Convert.ToDecimal(txtPolicy_Deductible.Text);

        if (rdoCompensation_Originally_Denied.SelectedValue == "1")
            objWCR.Compensation_Originally_Denied = true;
        else if (rdoCompensation_Originally_Denied.SelectedValue == "0")
            objWCR.Compensation_Originally_Denied = false;
        else
            objWCR.Compensation_Originally_Denied = null;

        if (rdoLS_Reimbursement_Of_Cost.SelectedValue == "1")
            objWCR.LS_Reimbursement_Of_Cost = true;
        else if (rdoLS_Reimbursement_Of_Cost.SelectedValue == "0")
            objWCR.LS_Reimbursement_Of_Cost = false;
        else
            objWCR.LS_Reimbursement_Of_Cost = null;

        if (rdoWaive_Subrogation.SelectedValue == "1")
            objWCR.Waive_Subrogation = true;
        else if (rdoWaive_Subrogation.SelectedValue == "0")
            objWCR.Waive_Subrogation = false;
        else
            objWCR.Waive_Subrogation = null;

        if (rdoClose_Medicals.SelectedValue == "1")
            objWCR.Close_Medicals = true;
        else if (rdoClose_Medicals.SelectedValue == "0")
            objWCR.Close_Medicals = false;
        else
            objWCR.Close_Medicals = null;

        if (rdoConfidentiality_Clause.SelectedValue == "1")
            objWCR.Confidentiality_Clause = true;
        else if (rdoConfidentiality_Clause.SelectedValue == "0")
            objWCR.Confidentiality_Clause = false;
        else
            objWCR.Confidentiality_Clause = null;

        if (rdoOther_Medicals.SelectedValue == "1")
            objWCR.Other_Medicals = true;
        else if (rdoOther_Medicals.SelectedValue == "0")
            objWCR.Other_Medicals = false;
        else
            objWCR.Other_Medicals = null;

        if (rdoSettlement_of_Permanent_Total.SelectedValue == "1")
            objWCR.Settlement_of_Permanent_Total = true;
        else if (rdoSettlement_of_Permanent_Total.SelectedValue == "0")
            objWCR.Settlement_of_Permanent_Total = false;
        else
            objWCR.Settlement_of_Permanent_Total = null;

        if (rdoResignation.SelectedValue == "1")
            objWCR.Resignation = true;
        else if (rdoResignation.SelectedValue == "0")
            objWCR.Resignation = false;
        else
            objWCR.Resignation = null;

        if (rdoOther_Classification.SelectedValue == "1")
            objWCR.Other_Classification = true;
        else if (rdoOther_Classification.SelectedValue == "0")
            objWCR.Other_Classification = false;
        else
            objWCR.Other_Classification = null;

        objWCR.Resignation_Date = clsGeneral.FormatDateToStore(txtResignation_Date);
        objWCR.Defense_Council_Name = txtDefense_Council_Name.Text;
        objWCR.Defense_Council_Telephone = txtDefense_Council_Telephone.Text;
        objWCR.Claimant_Attorney = txtClaimant_Attorney.Text;
        objWCR.Claimant_Attorney_Telephone = txtClaimant_Attorney_Telephone.Text;
        objWCR.Trial_Date = clsGeneral.FormatDateToStore(txtTrial_Date);
        objWCR.Mediation_Date = clsGeneral.FormatDateToStore(txtMediation_Date);
        objWCR.Demand_Amount = string.IsNullOrEmpty(txtDemand_Amount.Text) ? 0 : Convert.ToDecimal(txtDemand_Amount.Text);
        objWCR.ADJ_Requested_Amount = string.IsNullOrEmpty(txtADJ_Requested_Amount.Text) ? 0 : Convert.ToDecimal(txtADJ_Requested_Amount.Text);
        objWCR.RM_Requested_Amount = string.IsNullOrEmpty(txtRM_Requested_Amount.Text) ? 0 : Convert.ToDecimal(txtRM_Requested_Amount.Text);
        objWCR.Authorized_Amount = string.IsNullOrEmpty(txtAuthorized_Amount.Text) ? 0 : Convert.ToDecimal(txtAuthorized_Amount.Text);
        objWCR.Potential_Total_Exposure = string.IsNullOrEmpty(txtPotential_Total_Exposure.Text) ? 0 : Convert.ToDecimal(txtPotential_Total_Exposure.Text);

        if (rdoSettled.SelectedValue == "1")
            objWCR.Settled = true;
        else if (rdoSettled.SelectedValue == "0")
            objWCR.Settled = false;
        else
            objWCR.Settled = null;

        objWCR.Settled_Amount = string.IsNullOrEmpty(txtSettled_Amount.Text) ? 0 : Convert.ToDecimal(txtSettled_Amount.Text);

        objWCR.Full_Final_Clincher = rdoFullFinalClincher.SelectedValue;

        objWCR.GM_Email_To = txtGM_Email_To.Text;
        objWCR.GM_Last_Email_Date = clsGeneral.FormatDateToStore(txtGM_Last_Email_Date);
        objWCR.GM_Response_Date = clsGeneral.FormatDateToStore(txtGM_Response_Date);
        if (rdoGM_Decision.SelectedValue == "1")
            objWCR.GM_Decision = true;
        else if (rdoGM_Decision.SelectedValue == "0")
            objWCR.GM_Decision = false;
        else
            objWCR.GM_Decision = null;

        objWCR.CRM_Email_To = txtCRM_Email_To.Text;
        objWCR.CRM_Last_Email_Date = clsGeneral.FormatDateToStore(txtCRM_Last_Email_Date);
        objWCR.CRM_Response_Date = clsGeneral.FormatDateToStore(txtCRM_Response_Date);
        if (rdoCRM_Decision.SelectedValue == "1")
            objWCR.CRM_Decision = true;
        else if (rdoCRM_Decision.SelectedValue == "0")
            objWCR.CRM_Decision = false;
        else
            objWCR.CRM_Decision = null;

        objWCR.RVP_Email_To = txtRVP_Email_To.Text;
        objWCR.RVP_Last_Email_Date = clsGeneral.FormatDateToStore(txtRVP_Last_Email_Date);
        objWCR.RVP_Response_Date = clsGeneral.FormatDateToStore(txtRVP_Response_Date);
        if (rdoRVP_Decision.SelectedValue == "1")
            objWCR.RVP_Decision = true;
        else if (rdoRVP_Decision.SelectedValue == "0")
            objWCR.RVP_Decision = false;
        else
            objWCR.RVP_Decision = null;

        objWCR.CC_Email_To = txtCC_Email_To.Text;
        objWCR.CC_Last_Email_Date = clsGeneral.FormatDateToStore(txtCC_Last_Email_Date);
        objWCR.CC_Response_Date = clsGeneral.FormatDateToStore(txtCC_Response_Date);
        if (rdoCC_Decision.SelectedValue == "1")
            objWCR.CC_Decision = true;
        else if (rdoCC_Decision.SelectedValue == "0")
            objWCR.CC_Decision = false;
        else
            objWCR.CC_Decision = null;

        objWCR.DRM_Email_To = txtDRM_Email_To.Text;
        objWCR.DRM_Last_Email_Date = clsGeneral.FormatDateToStore(txtDRM_Last_Email_Date);
        objWCR.DRM_Response_Date = clsGeneral.FormatDateToStore(txtDRM_Response_Date);
        if (rdoDRM_Decision.SelectedValue == "1")
            objWCR.DRM_Decision = true;
        else if (rdoDRM_Decision.SelectedValue == "0")
            objWCR.DRM_Decision = false;
        else
            objWCR.DRM_Decision = null;

        objWCR.CFO_Email_To = txtCFO_Email_To.Text;
        objWCR.CFO_Last_Email_Date = clsGeneral.FormatDateToStore(txtCFO_Last_Email_Date);
        objWCR.CFO_Response_Date = clsGeneral.FormatDateToStore(txtCFO_Response_Date);
        if (rdoCFO_Decision.SelectedValue == "1")
            objWCR.CFO_Decision = true;
        else if (rdoCFO_Decision.SelectedValue == "0")
            objWCR.CFO_Decision = false;
        else
            objWCR.CFO_Decision = null;

        objWCR.COO_Email_To = txtCOO_Email_To.Text;
        objWCR.COO_Last_Email_Date = clsGeneral.FormatDateToStore(txtCOO_Last_Email_Date);
        objWCR.COO_Response_Date = clsGeneral.FormatDateToStore(txtCOO_Response_Date);
        if (rdoCOO_Decision.SelectedValue == "1")
            objWCR.COO_Decision = true;
        else if (rdoCOO_Decision.SelectedValue == "0")
            objWCR.COO_Decision = false;
        else
            objWCR.COO_Decision = null;

        objWCR.Comments = txtComments.Text;
        if (Workers_Comp_RMW.SelectByFK(PK_WC_CI_ID).Tables[0].Rows.Count > 0)
        {
            objWCR.UpdateByFK();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Risk Management Worksheet data has been saved.');ShowPanel(6);", true);
        }
        else
        {
            PK_Workers_Comp_RMW = objWCR.Insert();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Risk Management Worksheet data has been saved.');ShowPanel(6);", true);
        }
        ctlAttchment.Add(clsGeneral.Claim_Tables.WCClaim, Convert.ToInt32(PK_WC_CI_ID));
        ctlAttchmentDetails.Bind();
    }

    /// <summary>
    /// Use to Upload file from Comment section
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {
        ctlAttchment.Add(clsGeneral.Claim_Tables.WCClaim, Convert.ToInt32(PK_WC_CI_ID));

        // Used to Bind Grid with Attached Data
        ctlAttchmentDetails.Bind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
    }

    /// <summary>
    /// Upload Claim Info File
    /// </summary>
    /// <param name="strValue"></param>
    protected void ClaimUpload_File(string strValue)
    {
        //Insert values into AL_FR_Attachment table
        CtrlAttachment_Cliam.Add(clsGeneral.Tables.WCClaim, Convert.ToInt32(PK_WC_CI_ID));
        // Used to Bind Grid with Attached Data
        CtlAttachDetail_Cliam.Bind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(8);", true);
    }

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    return;
    //}

    #endregion

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations-Claim Information
    /// </summary>
    private void SetValidationsClaimInfo()
    {
        string strCtrlsIDsClaimInfo = "";
        string strMessagesClaimInfo = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(28).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date Restricted Work Began": strCtrlsIDsClaimInfo += txtDateRestrictedWorkBegan.ClientID + ","; strMessagesClaimInfo += "Please enter [Claim Identification]/Date Restricted Work Began" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Date Restricted Work Ended": strCtrlsIDsClaimInfo += txtDateRestrictedWorkEnd.ClientID + ","; strMessagesClaimInfo += "Please enter [Claim Identification]/Date Restricted Work Ended" + ","; Span2.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        #endregion

        strCtrlsIDsClaimInfo = strCtrlsIDsClaimInfo.TrimEnd(',');
        strMessagesClaimInfo = strMessagesClaimInfo.TrimEnd(',');

        hdnControlIDsClaimInfo.Value = strCtrlsIDsClaimInfo;
        hdnErrorMsgsClaimInfo.Value = strMessagesClaimInfo;
    }

    /// <summary>
    /// Set all Validations-Risk Manaement Worksheet
    /// </summary>
    private void SetValidationsRMW()
    {
        string strCtrlsIDsRMW = "";
        string strMessagesRMW = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(32).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk5.Style["display"] = (dtFields.Select("LeftMenuIndex = 5").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Settlement Method": strCtrlsIDsRMW += "ctl00_ContentPlaceHolder1_txtSettlement_Method_txtNote,"; strMessagesRMW += "Please enter [Risk Management Worksheet]/Settlement Method" + ","; Span3.Style["display"] = "inline-block"; break;
                case "Policy Deductible": strCtrlsIDsRMW += txtPolicy_Deductible.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Policy Deductible" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Resignation Date": strCtrlsIDsRMW += txtResignation_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Resignation Date" + ","; Span38.Style["display"] = "inline-block"; break;
                case "Defense Council’s Name": strCtrlsIDsRMW += txtDefense_Council_Name.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Defense Council’s Name" + ","; Span5.Style["display"] = "inline-block"; break;
                case "Defense Council’s Telephone": strCtrlsIDsRMW += txtDefense_Council_Telephone.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Defense Council’s Telephone" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Claimant’s Attorney": strCtrlsIDsRMW += txtClaimant_Attorney.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Claimant’s Attorney" + ","; Span7.Style["display"] = "inline-block"; break;
                case "Claimant’s Attorney Telephone": strCtrlsIDsRMW += txtClaimant_Attorney_Telephone.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Claimant’s Attorney Telephone" + ","; Span8.Style["display"] = "inline-block"; break;
                case "Trial Date": strCtrlsIDsRMW += txtTrial_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Trial Date" + ","; Span9.Style["display"] = "inline-block"; break;
                case "Mediation Date": strCtrlsIDsRMW += txtMediation_Date.ClientID + ","; strMessagesRMW += "Please enter[Risk Management Worksheet]/ Mediation Date" + ","; Span10.Style["display"] = "inline-block"; break;
                case "Demand Amount (PA)": strCtrlsIDsRMW += txtDemand_Amount.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Demand Amount (PA)" + ","; Span11.Style["display"] = "inline-block"; break;
                case "Requested Amount (ADJ)": strCtrlsIDsRMW += txtADJ_Requested_Amount.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Requested Amount (ADJ)" + ","; Span12.Style["display"] = "inline-block"; break;
                case "Requested Amount (RM)": strCtrlsIDsRMW += txtRM_Requested_Amount.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Requested Amount (RM)" + ","; Span13.Style["display"] = "inline-block"; break;
                case "Authorized Amount (SAI)": strCtrlsIDsRMW += txtAuthorized_Amount.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Authorized Amount (SAI)" + ","; Span14.Style["display"] = "inline-block"; break;
                case "Potential Total Exposure": strCtrlsIDsRMW += txtPotential_Total_Exposure.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Potential Total Exposure" + ","; Span15.Style["display"] = "inline-block"; break;
                case "Settled Amount": strCtrlsIDsRMW += txtSettled_Amount.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Settled Amount" + ","; Span39.Style["display"] = "inline-block"; break;
                case "GM E-Mail To": strCtrlsIDsRMW += txtGM_Email_To.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/GM E-Mail To" + ","; Span16.Style["display"] = "inline-block"; break;
                case "GM Last E-Mail Date": strCtrlsIDsRMW += txtGM_Last_Email_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/GM Last E-Mail Date" + ","; Span17.Style["display"] = "inline-block"; break;
                case "GM Response Date": strCtrlsIDsRMW += txtGM_Response_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/GM Response Date" + ","; Span18.Style["display"] = "inline-block"; break;
                case "Comments": strCtrlsIDsRMW += "ctl00_ContentPlaceHolder1_txtComments_txtNote,"; strMessagesRMW += "Please enter [Risk Management Worksheet]/Comments" + ","; Span37.Style["display"] = "inline-block"; break;
                case "CRM E-Mail To": strCtrlsIDsRMW += txtCRM_Email_To.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/CRM E-Mail To" + ","; Span19.Style["display"] = "inline-block"; break;
                case "CRM Last E-Mail Date": strCtrlsIDsRMW += txtCRM_Last_Email_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/CRM Last E-Mail Date" + ","; Span20.Style["display"] = "inline-block"; break;
                case "CRM Response Date": strCtrlsIDsRMW += txtCRM_Response_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/CRM Response Date" + ","; Span21.Style["display"] = "inline-block"; break;
                case "RVP E-Mail To": strCtrlsIDsRMW += txtRVP_Email_To.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/RVP E-Mail To" + ","; Span22.Style["display"] = "inline-block"; break;
                case "RVP Last E-Mail Date": strCtrlsIDsRMW += txtRVP_Last_Email_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/RVP Last E-Mail Date" + ","; Span23.Style["display"] = "inline-block"; break;
                case "RVP Response Date": strCtrlsIDsRMW += txtRVP_Response_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/RVP Response Date" + ","; Span24.Style["display"] = "inline-block"; break;
                case "Corporate Controller E-Mail To": strCtrlsIDsRMW += txtCC_Email_To.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Corporate Controller E-Mail To" + ","; Span25.Style["display"] = "inline-block"; break;
                case "Corporate Controller Last E-Mail Date": strCtrlsIDsRMW += txtCC_Last_Email_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Corporate Controller Last E-Mail Date" + ","; Span26.Style["display"] = "inline-block"; break;
                case "Corporate Controller Response Date": strCtrlsIDsRMW += txtCC_Response_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/Corporate Controller Response Date" + ","; Span27.Style["display"] = "inline-block"; break;
                case "DRM E-Mail To": strCtrlsIDsRMW += txtDRM_Email_To.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/DRM E-Mail To" + ","; Span28.Style["display"] = "inline-block"; break;
                case "DRM Last E-Mail Date": strCtrlsIDsRMW += txtDRM_Last_Email_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/DRM Last E-Mail Date" + ","; Span29.Style["display"] = "inline-block"; break;
                case "DRM Response Date": strCtrlsIDsRMW += txtDRM_Response_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/DRM Response Date" + ","; Span30.Style["display"] = "inline-block"; break;
                case "CFO E-Mail To": strCtrlsIDsRMW += txtCFO_Email_To.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/CFO E-Mail To" + ","; Span31.Style["display"] = "inline-block"; break;
                case "CFO Last E-Mail Date": strCtrlsIDsRMW += txtCFO_Last_Email_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/CFO Last E-Mail Date" + ","; Span32.Style["display"] = "inline-block"; break;
                case "CFO Response Date": strCtrlsIDsRMW += txtCFO_Response_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/CFO Response Date" + ","; Span33.Style["display"] = "inline-block"; break;
                case "COO E-Mail To": strCtrlsIDsRMW += txtCOO_Email_To.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/COO E-Mail To" + ","; Span34.Style["display"] = "inline-block"; break;
                case "COO Last E-Mail Date": strCtrlsIDsRMW += txtCOO_Last_Email_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/COO Last E-Mail Date" + ","; Span35.Style["display"] = "inline-block"; break;
                case "COO Response Date": strCtrlsIDsRMW += txtCOO_Response_Date.ClientID + ","; strMessagesRMW += "Please enter [Risk Management Worksheet]/COO Response Date" + ","; Span36.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        #endregion

        strCtrlsIDsRMW = strCtrlsIDsRMW.TrimEnd(',');
        strMessagesRMW = strMessagesRMW.TrimEnd(',');

        hdnControlIDsRMW.Value = strCtrlsIDsRMW;
        hdnErrorMsgsRMW.Value = strMessagesRMW;
    }

    #endregion

    #region Transaction View, Print and Mail

    /// <summary>
    /// Button View Click for Transaction
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnViewSelectedTrans_Click(object sender, EventArgs e)
    {
        string strPK = "";

        foreach (GridViewRow gRow in gvWCTransList.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkTranSelect")).Checked)
                strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnID")).Value + ",";
        }
        strPK = strPK.TrimEnd(',');

        if (strPK != string.Empty)
        {
             BindClaimTransactionDetails(strPK);
        }
    }

    /// <summary>
    /// Button Cancel Click for Transaction
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlTransactionDetail.Visible = false;
        pnlTransGrid.Visible = true;
       
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "SelectDeselectTransHeader(true);", true);
    }

    /// <summary>
    /// Print Transaction Method
    /// </summary>
    /// <param name="strPK"></param>
    private void PrintTransaction(string strPK)
    {
        if (strPK != string.Empty)
        {
            DataTable dtClaim = WC_ClaimInfo.SelectByPK(PK_WC_CI_ID).Tables[0]; ;
            DataTable dtClaims_Transactions = Claims_Transaction.SelectByPKIDs(strPK).Tables[0];
            StringBuilder sbHTML = new StringBuilder();

            #region " Generate HTML Text "

            string strTDBlue = "style='background-color:#95B3D7;border-top:black 1px solid;border-left:black 1px solid;'";
            string strTDWhite = "style='border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid;'";
            sbHTML.Append("<HTML><Body>");
            sbHTML.Append("<b>eRIMS2 Sonic - Selected Claim Transactions</b>");
            sbHTML.Append("<br /></br />");
            sbHTML.Append("<table cellpadding='3' cellspacing='1' border='0' width='100%'>");
            sbHTML.Append("<tr>");
            sbHTML.Append("<td width='25%' align='left' " + strTDBlue + ">");
            sbHTML.Append("<span style='color:white'><b>Claim Number</b></span>");
            sbHTML.Append("</td>");
            sbHTML.Append("<td width='25%' align='left' " + strTDBlue + ">");
            sbHTML.Append("<span style='color:white'><b>Sonic Location d/b/a</b></span>");
            sbHTML.Append("</td>");
            sbHTML.Append("<td width='25%' align='left' " + strTDBlue + ">");
            sbHTML.Append("<span style='color:white'><b>Name</b></span>");
            sbHTML.Append("</td>");
            sbHTML.Append("<td width='25%' align='left' " + strTDBlue.TrimEnd('\'') + "border-right:black 1px solid;'>");
            sbHTML.Append("<span style='color:white'><b>Date of Incident</b></span>");
            sbHTML.Append("</td>");
            sbHTML.Append("</tr>");
            sbHTML.Append("<tr>");
            sbHTML.Append("<td align='left' " + strTDWhite + ">" + Convert.ToString(dtClaim.Rows[0]["Origin_Claim_Number"]) + "</td>");
            sbHTML.Append("<td align='left' " + strTDWhite + ">" + Convert.ToString(dtClaim.Rows[0]["dba1"]) + "</td>");
            sbHTML.Append("<td align='left' " + strTDWhite + ">" + Convert.ToString(dtClaim.Rows[0]["Employee_Name"]) + "</td>");
            sbHTML.Append("<td align='left' " + strTDWhite.TrimEnd('\'') + "border-right:black 1px solid;'>" + clsGeneral.FormatDBNullDateToDisplay(dtClaim.Rows[0]["Date_Of_Accident"]) + "</td>");
            sbHTML.Append("</tr>");
            sbHTML.Append("</table>");
            sbHTML.Append("<br />");

            sbHTML.Append("<table cellpadding='3' cellspacing='1' width='100%'>");
            int i = 0;
            foreach (DataRow drClaims_Transactions in dtClaims_Transactions.Rows)
            {
                sbHTML.Append("<tr>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Date </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + clsGeneral.FormatDBNullDateToDisplay(Convert.ToDateTime(drClaims_Transactions["Transaction_Entry_date"])) + "</td>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Data Source </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Data_Origin"]) + "</td>");
                sbHTML.Append("</tr>");

                sbHTML.Append("<tr>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Payee Name 1 </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Payee_Name1"]) + "</td>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Key Claim Number </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Origin_Key_Claim_Number"]) + "</td>");
                sbHTML.Append("</tr>");

                sbHTML.Append("<tr>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Payee Name 2 </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Payee_Name2"]) + "</td>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Claimant Sequence Number </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Claimant_Sequence_Number"]) + "</td>");
                sbHTML.Append("</tr>");

                sbHTML.Append("<tr>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Payee Name 3 </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Payee_Name3"]) + "</td>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Policy Number </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Policy_Number"]) + "</td>");
                sbHTML.Append("</tr>");

                sbHTML.Append("<tr>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Payee Street Address </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Payee_Street_Address"]) + "</td>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Carrier Policy Number </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Carrier_policy_number"]) + "</td>");
                sbHTML.Append("</tr>");

                sbHTML.Append("<tr>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Payee City </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Payee_City"]) + "</td>");
                sbHTML.Append("<td width='20%' align='left' valign='top'></td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'></td>");
                sbHTML.Append("</tr>");

                sbHTML.Append("<tr>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Payee State </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Payee_State"]) + "</td>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Transaction Amount </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + (drClaims_Transactions["Transaction_Amount"] == DBNull.Value ? "" : String.Format("$ {0:N2}", Convert.ToDecimal(drClaims_Transactions["Transaction_Amount"]))) + "</td>");
                sbHTML.Append("</tr>");

                sbHTML.Append("<tr>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Payee Zip </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Payee_Zip"]) + "</td>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Transaction Sequence Number </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Transaction_Sequence_Number"]) + "</td>");
                sbHTML.Append("</tr>");

                sbHTML.Append("<tr>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Payee ID </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + (Convert.ToString(drClaims_Transactions["Payee_Tax_Number"]) + " - " + Convert.ToString(drClaims_Transactions["Payee_SSN_FEIN"])) + "</td>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Claim Status </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Claim_Status"]) + "</td>");
                sbHTML.Append("</tr>");

                sbHTML.Append("<tr>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Entry Code </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Entry_Code_Desc"]) + "</td>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Entry Code Modiifer </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Entry_Code_Modifier_Desc"]) + "</td>");
                sbHTML.Append("</tr>");

                sbHTML.Append("<tr>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Nature of Benefit </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Nature_of_Benefit_Code_Desc"]) + "</td>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Transaction Nature of Benefit </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Transaction_Nature_of_Benefit_Desc"]) + "</td>");
                sbHTML.Append("</tr>");

                sbHTML.Append("<tr>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Nature of Payment Statement </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Nature_of_Payment_Statement"]) + "</td>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Check Number </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Check_Number"]) + "</td>");
                sbHTML.Append("</tr>");

                sbHTML.Append("<tr>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>SRS Recovery Office Code </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["SRS_Recovery_Office_Code"]) + "</td>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Check Issue Date </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + (drClaims_Transactions["Check_Issue_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drClaims_Transactions["Check_Issue_Date"]))) + "</td>");
                sbHTML.Append("</tr>");

                sbHTML.Append("<tr>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>SRS Draft Issue Office Code </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["SRS_Draft_Issue_Office_Code"]) + "</td>");
                sbHTML.Append("<td width='20%' align='left' valign='top'>Recovery Sequence Number </td>");
                sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
                sbHTML.Append("<td width='26%' align='left' valign='top'>" + Convert.ToString(drClaims_Transactions["Recovery_Sequence_Number"]) + "</td>");
                sbHTML.Append("</tr>");

                if (i < dtClaims_Transactions.Rows.Count - 1)
                {
                    sbHTML.Append("<tr style='height:30px'>");
                    sbHTML.Append("<td colspan='6' style='vertical-align:middle'><hr size='1' color='Black' /></td>");
                    sbHTML.Append("</tr>");
                }

                i++;
            }

            sbHTML.Append("</table>");
            sbHTML.Append("</Body></HTML>");

            #endregion

            #region " Generate WORD Doc "
            string strLisenceFile = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\" + ("Bin") + "\\Aspose.Words.lic";

            if (File.Exists(strLisenceFile))
            {
                //This shows how to license Aspose.Words, if you don't specify a license, 
                //Aspose.Words works in evaluation mode.
                Aspose.Words.License license = new Aspose.Words.License();
                license.SetLicense(strLisenceFile);
            }

            Aspose.Words.Document doc = new Aspose.Words.Document();

            //Build string builder to transport to Doc
            //Once the builder is created, its cursor is positioned at the beginning of the document.
            Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);
            builder.PageSetup.BottomMargin = 15;
            builder.PageSetup.TopMargin = 15;
            builder.PageSetup.LeftMargin = 15;
            builder.PageSetup.RightMargin = 15;
            builder.Font.Size = 10;
            builder.Font.Bold = false;
            builder.Font.Color = System.Drawing.Color.Black;
            builder.Font.Name = "Arial";
            builder.InsertParagraph();
            builder.InsertHtml(sbHTML.ToString());

            //Don't need merge fields in the document anymore.
            doc.MailMerge.DeleteFields();
            builder.MoveToSection(0);
            builder.MoveToHeaderFooter(HeaderFooterType.FooterPrimary);
            builder.PageSetup.PageNumberStyle = NumberStyle.Number;
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            builder.Write("Page ");
            builder.InsertField("PAGE", "");
            builder.Write(" of ");
            builder.InsertField("NUMPAGES", "");
            Section section = doc.Sections[0];
            section.PageSetup.PageStartingNumber = 1;
            section.PageSetup.RestartPageNumbering = true;
            section.PageSetup.PageNumberStyle = NumberStyle.Arabic;

            // Remove content from merged cells.
            // Get collection of cells in the docuemnt.
            NodeCollection cells = doc.GetChildNodes(NodeType.Cell, true);

            foreach (Aspose.Words.Tables.Cell cell in cells)
            {
                // Check whether cell is merged with previouse.
                if (cell.CellFormat.HorizontalMerge == Aspose.Words.Tables.CellMerge.Previous || cell.CellFormat.VerticalMerge == Aspose.Words.Tables.CellMerge.Previous)
                {
                    // Remove content from the cell.
                    cell.RemoveAllChildren();
                }
            }

            Aspose.Words.Tables.Table table = (Aspose.Words.Tables.Table)doc.GetChild(NodeType.Table, 0, true);
            table.AllowAutoFit = false;
            //doc.Save("ClaimNotes.doc", Aspose.Words.SaveFormat.Doc, Aspose.Words.SaveType.OpenInWord, Response);
            doc.Save(Response, "ClaimTransactions.doc", ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));
            Response.Flush();

            #endregion
        }
    }

    #endregion
   
}
