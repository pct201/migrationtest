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
using System.Text;
using System.IO;
using Aspose.Words;

/// <summary>
/// Date : 14 NOV 2008
/// 
/// By : Amit Makwana
/// 
/// Purpose: 
/// To view the claim information for the type Auto Loss Claim
/// 
/// Functionality:
/// Gets the Auto Loss Claim ID from querystring and provides the information 
/// for that in view mode
/// </summary>
public partial class SONIC_ALClaimInfo : clsBasePage
{
    #region Private Variable and Property

    /// <summary>
    /// Denotes PK for Auto Loss Claim
    /// </summary>
    public long PK_AL_CI_ID
    {
        get
        {
            return clsGeneral.GetLong(ViewState["AL_CI_ID"]);
        }
        set { ViewState["AL_CI_ID"] = value; }
    }
    /// <summary>
    /// Denotes PK for Auto Loss Claim RMW
    /// </summary>
    public int PK_Auto_Loss_RMW
    {
        get
        {
            return Convert.ToInt32(ViewState["PK_Auto_Loss_RMW"]);
        }
        set { ViewState["PK_Auto_Loss_RMW"] = value; }
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

    #region Page Events

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        ClaimTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.AL);
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
                    PK_AL_CI_ID = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
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

            if (Request.QueryString["pnl"] != null && Request.QueryString["pnl"] != string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
            }
            #endregion

            //Bind the Auto Loss Claim Information
            BindAlClaimInfo();
            //Initialize Attachment Details Info.
            ctlAttchmentDetails.InitializeAttachmentDetails(clsGeneral.Claim_Tables.ALClaim, Convert.ToInt32(PK_AL_CI_ID), true, 5);
            ctlAttchmentDetails.Bind();

            // initialize control for Whole claim information
            CtlAttachDetail_Cliam.InitializeAttachmentDetails(clsGeneral.Tables.ALClaim, Convert.ToInt32(PK_AL_CI_ID), true, 6);
            CtlAttachDetail_Cliam.Bind();

            //Bind Risk Management Worksheet
            BindRiskMangWorkSheet();
            //Set the first panel active
            int intPanle = 1;
            if (int.TryParse(Convert.ToString(Request.QueryString["pnl"]), out intPanle))
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + intPanle.ToString() + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            SetValidations();
        }
    }

    #endregion

    #region Controls Events

    /// <summary>
    /// Grid View WC Transaction Row Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvALTransList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check Rowtype
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkTransaction_Entry_date = (LinkButton)e.Row.FindControl("lnkTransaction_Entry_date");
            //check Date_Of_Incident value from datset. if it is not null than display it in proper formate.
            if (DataBinder.Eval(e.Row.DataItem, "Transaction_Entry_date") != DBNull.Value)
                lnkTransaction_Entry_date.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Transaction_Entry_date")));
        }
    }

    /// <summary>
    /// Gridview Row Command Event - WC Trans list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvALTransList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "View")
        {
            //Get the Claim Transaction Id
            string PK_ID = Convert.ToString(e.CommandArgument);

            //Fill the Claim Transaction detail. and make transaction panel visible
            BindClaimTransactionDetails(PK_ID);
              //  pnlTransactionDetail.Visible = true;
        }
    }

    /// <summary>
    /// Gridview Rowcommand Event - Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void gvNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //check Command Name
    //    if (e.CommandName == "EditRecord")
    //    {
    //        //Get the Claim Note ID
    //        Response.Redirect("ClaimNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&FK_Claim=" + Encryption.Encrypt(PK_AL_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.ALClaim.ToString());
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
    /// Button Click Event - Note Add 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNotesAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClaimNotes.aspx?FK_Claim=" + Encryption.Encrypt(PK_AL_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.ALClaim.ToString());

    }

    /// <summary>
    /// Link BUtton Click Event - Asociated First report 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_Click(object sender, EventArgs e)
    {
        //Get the details of Associated first report from the report number.
        DataSet dsALFirstReport = null;
        if (lnkAssociatedFirstReport.Text.StartsWith("AL"))
            dsALFirstReport = AL_FR.SelectByAL_FR_Number(First_Report_Number);
        else if (lnkAssociatedFirstReport.Text.StartsWith("PL"))
            dsALFirstReport = PL_FR.SelectByPL_FR_Number(First_Report_Number);
        else if (lnkAssociatedFirstReport.Text.StartsWith("DPD"))
            dsALFirstReport = DPD_FR.SelectByDPD_FR_Number(First_Report_Number);

        //Check First report found or not
        if (dsALFirstReport.Tables[0].Rows.Count > 0)
        {
            //set the wizard id in session
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(dsALFirstReport.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);

            //redirect to the auto loss first report page
            if (lnkAssociatedFirstReport.Text.StartsWith("AL"))
                Response.Redirect("../FirstReport/ALFirstReport.aspx?id=" + Encryption.Encrypt(dsALFirstReport.Tables[0].Rows[0]["PK_AL_FR_ID"].ToString()));
            else if (lnkAssociatedFirstReport.Text.StartsWith("PL"))
                Response.Redirect("../FirstReport/PLFirstReport.aspx?id=" + Encryption.Encrypt(dsALFirstReport.Tables[0].Rows[0]["PK_PL_FR_ID"].ToString()));
            else if (lnkAssociatedFirstReport.Text.StartsWith("DPD"))
                Response.Redirect("../FirstReport/DPDFirstReport.aspx?id=" + Encryption.Encrypt(dsALFirstReport.Tables[0].Rows[0]["PK_DPD_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
    }

    /// <summary>
    /// btn Save Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //createing object
        Auto_Loss_RMW objALR = new Auto_Loss_RMW();
        objALR.FK_Auto_Loss_Claims = PK_AL_CI_ID;
        objALR.Update_Date = DateTime.Now;
        objALR.Updated_By = clsSession.UserID;

        if (rdoClaimant_Customer.SelectedValue == "1")
            objALR.Claimant_Customer = true;
        else if (rdoClaimant_Customer.SelectedValue == "0")
            objALR.Claimant_Customer = false;
        else
            objALR.Claimant_Customer = null;

        if (rdoClaimant_Third_Party.SelectedValue == "1")
            objALR.Claimant_Third_Party = true;
        else if (rdoClaimant_Third_Party.SelectedValue == "0")
            objALR.Claimant_Third_Party = false;
        else
            objALR.Claimant_Third_Party = null;

        if (rdoDriver_Customer.SelectedValue == "1")
            objALR.Driver_Customer = true;
        else if (rdoDriver_Customer.SelectedValue == "0")
            objALR.Driver_Customer = false;
        else
            objALR.Driver_Customer = null;

        if (rdoDriver_Associate.SelectedValue == "1")
            objALR.Driver_Associate = true;
        else if (rdoDriver_Associate.SelectedValue == "0")
            objALR.Driver_Associate = false;
        else
            objALR.Driver_Associate = null;

        objALR.Liability_Analysis = Convert.ToString(txtLiability_Analysis.Text);

        if (rdoDemand.SelectedValue == "1")
            objALR.Demand = true;
        else if (rdoDemand.SelectedValue == "0")
            objALR.Demand = false;
        else
            objALR.Demand = null;

        objALR.Claimant_Counsel_Name = Convert.ToString(txtClaimant_Counsel_Name.Text);
        objALR.Plantiff_Counsel_Name = Convert.ToString(txtPlantiff_Counsel_Name.Text);

        if (rdoProperty_Damaged.SelectedValue == "1")
            objALR.Property_Damaged = true;
        else if (rdoProperty_Damaged.SelectedValue == "0")
            objALR.Property_Damaged = false;
        else
            objALR.Property_Damaged = null;

        objALR.Property_Damages_Description = Convert.ToString(txtProperty_Damages_Description.Text);
        objALR.Damage_Amount = string.IsNullOrEmpty(txtDamage_Amount.Text) ? 0 : Convert.ToDecimal(txtDamage_Amount.Text);

        if (rdoBodily_Injury.SelectedValue == "1")
            objALR.Bodily_Injury = true;
        else if (rdoBodily_Injury.SelectedValue == "0")
            objALR.Bodily_Injury = false;
        else
            objALR.Bodily_Injury = null;

        objALR.Injury_Description = Convert.ToString(txtInjury_Description.Text);
        objALR.FK_LU_Part_Of_Body = (ddlFK_LU_Part_Of_Body.SelectedIndex > 0 ? Convert.ToDecimal(ddlFK_LU_Part_Of_Body.SelectedValue) : 0);
        objALR.FK_LU_Nature_Of_Injury = (ddlFK_LU_Nature_Of_Injury.SelectedIndex > 0 ? Convert.ToDecimal(ddlFK_LU_Nature_Of_Injury.SelectedValue) : 0);
        objALR.Medical_Treatment_Description = Convert.ToString(txtMedical_Treatment_Description.Text);
        objALR.Medical_Cost = string.IsNullOrEmpty(txtMedical_Cost.Text) ? 0 : Convert.ToDecimal(txtMedical_Cost.Text);
        objALR.Requested_Amount = string.IsNullOrEmpty(txtRequested_Amount.Text) ? 0 : Convert.ToDecimal(txtRequested_Amount.Text);
        objALR.Potential_Total_Exposure = string.IsNullOrEmpty(txtPotential_Total_Exposure.Text) ? 0 : Convert.ToDecimal(txtPotential_Total_Exposure.Text);

        if (rdoSettled.SelectedValue == "1")
            objALR.Settled = true;
        else if (rdoSettled.SelectedValue == "0")
            objALR.Settled = false;
        else
            objALR.Settled = null;

        objALR.Settled_Amount = string.IsNullOrEmpty(txtSettled_Amount.Text) ? 0 : Convert.ToDecimal(txtSettled_Amount.Text);

        objALR.GM_Email_To = txtGM_Email_To.Text;
        if (rdoGM_Decision.SelectedValue == "1")
            objALR.GM_Decision = true;
        else if (rdoGM_Decision.SelectedValue == "0")
            objALR.GM_Decision = false;
        else
            objALR.GM_Decision = null;
        objALR.GM_Last_Email_Date = clsGeneral.FormatDateToStore(txtGM_Last_Email_Date);
        objALR.GM_Response_Date = clsGeneral.FormatDateToStore(txtGM_Response_Date);


        objALR.CRM_Email_To = txtCRM_Email_To.Text;
        if (rdoCRM_Decision.SelectedValue == "1")
            objALR.CRM_Decision = true;
        else if (rdoCRM_Decision.SelectedValue == "0")
            objALR.CRM_Decision = false;
        else
            objALR.CRM_Decision = null;
        objALR.CRM_Last_Email_Date = clsGeneral.FormatDateToStore(txtCRM_Last_Email_Date);
        objALR.CRM_Response_Date = clsGeneral.FormatDateToStore(txtCRM_Response_Date);

        objALR.AGC_Email_To = txtAGC_Email_To.Text;
        if (rdoAGC_Decision.SelectedValue == "1")
            objALR.AGC_Decision = true;
        else if (rdoAGC_Decision.SelectedValue == "0")
            objALR.AGC_Decision = false;
        else
            objALR.AGC_Decision = null;
        objALR.AGC_Last_Email_Date = clsGeneral.FormatDateToStore(txtAGC_Last_Email_Date);
        objALR.AGC_Response_Date = clsGeneral.FormatDateToStore(txtAGC_Response_Date);

        objALR.RVP_Email_To = txtRVP_Email_To.Text;
        if (rdoRVP_Decision.SelectedValue == "1")
            objALR.RVP_Decision = true;
        else if (rdoRVP_Decision.SelectedValue == "0")
            objALR.RVP_Decision = false;
        else
            objALR.RVP_Decision = null;
        objALR.RVP_Last_Email_Date = clsGeneral.FormatDateToStore(txtRVP_Last_Email_Date);
        objALR.RVP_Response_Date = clsGeneral.FormatDateToStore(txtRVP_Response_Date);

        objALR.DRM_Email_To = txtDRM_Email_To.Text;
        if (rdoDRM_Decision.SelectedValue == "1")
            objALR.DRM_Decision = true;
        else if (rdoDRM_Decision.SelectedValue == "0")
            objALR.DRM_Decision = false;
        else
            objALR.DRM_Decision = null;
        objALR.DRM_Last_Email_Date = clsGeneral.FormatDateToStore(txtDRM_Last_Email_Date);
        objALR.DRM_Response_Date = clsGeneral.FormatDateToStore(txtDRM_Response_Date);

        objALR.CFO_Email_To = txtCFO_Email_To.Text;
        if (rdoCFO_Decision.SelectedValue == "1")
            objALR.CFO_Decision = true;
        else if (rdoCFO_Decision.SelectedValue == "0")
            objALR.CFO_Decision = false;
        else
            objALR.CFO_Decision = null;
        objALR.CFO_Last_Email_Date = clsGeneral.FormatDateToStore(txtCFO_Last_Email_Date);
        objALR.CFO_Response_Date = clsGeneral.FormatDateToStore(txtCFO_Response_Date);

        objALR.COO_Email_To = txtCOO_Email_To.Text;
        if (rdoCOO_Decision.SelectedValue == "1")
            objALR.COO_Decision = true;
        else if (rdoCOO_Decision.SelectedValue == "0")
            objALR.COO_Decision = false;
        else
            objALR.COO_Decision = null;
        objALR.COO_Last_Email_Date = clsGeneral.FormatDateToStore(txtCOO_Last_Email_Date);
        objALR.COO_Response_Date = clsGeneral.FormatDateToStore(txtCOO_Response_Date);

        objALR.President_Email_To = txtPresident_Email_To.Text;
        if (rdoPresident_Decision.SelectedValue == "1")
            objALR.President_Decision = true;
        else if (rdoPresident_Decision.SelectedValue == "0")
            objALR.President_Decision = false;
        else
            objALR.President_Decision = null;
        objALR.President_Last_Email_Date = clsGeneral.FormatDateToStore(txtPresident_Last_Email_Date);
        objALR.President_Response_Date = clsGeneral.FormatDateToStore(txtPresident_Response_Date);
        ctlAttchment.Add(clsGeneral.Claim_Tables.ALClaim, Convert.ToInt32(PK_AL_CI_ID));
        ctlAttchmentDetails.Bind();
        objALR.Comments = txtComments.Text;

        if (Auto_Loss_RMW.SelectByFK(PK_AL_CI_ID).Tables[0].Rows.Count > 0)
        {
            objALR.UpdateByFK();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Risk Management Worksheet data has been saved.');ShowPanel(5);", true);
        }
        else
        {
            PK_Auto_Loss_RMW = objALR.Insert();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Risk Management Worksheet data has been saved.');ShowPanel(5);", true);
        }

    }

    /// <summary>
    /// Button Click Event - CLick to view 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnView_Click(object sender, EventArgs e)
    //{
    //    string strPK = "";
    //    foreach (GridViewRow gRow in gvNotes.Rows)
    //    {
    //        if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
    //            strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
    //    }
    //    strPK = strPK.TrimEnd(',');

    //    Response.Redirect("ClaimNotes.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_AL_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.ALClaim.ToString());
    //}

    /// <summary>
    /// Button CLick Event - Button Print
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnPrint_Click(object sender, EventArgs e)
    //{
    //    string strPK = "";
    //    foreach (GridViewRow gRow in gvNotes.Rows)
    //    {
    //        if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
    //            strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
    //    }
    //    strPK = strPK.TrimEnd(',');
    //    clsPrintClaimNotes.PrintSelectedSonicNotes(strPK, clsGeneral.Claim_Tables.ALClaim.ToString(), PK_AL_CI_ID);
    //}

    /// <summary>
    ///  Handles Print button click event for Transaction Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrintSelectedTrans_Click(object sender, EventArgs e)
    {
        string strPK = "";

        foreach (GridViewRow gRow in gvALTransList.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkTranSelect")).Checked)
                strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnID")).Value + ",";
        }
        strPK = strPK.TrimEnd(',');
        PrintTransaction(strPK);
    }

    /// <summary>
    ///  Handles Mail button click event for Transaction Repeater
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnMailTrans_Click(object sender, EventArgs e)
    {
        string strPKs = "";
        string tab = string.Empty;
        tab = "AL";
        foreach (RepeaterItem rptItem in rptTransDetail.Items)
        {
            if (((CheckBox)rptItem.FindControl("chkRptTransSelect")).Checked)
                strPKs = strPKs + ((HtmlInputHidden)rptItem.FindControl("hdnID")).Value + ",";
        }
        strPKs = strPKs.TrimEnd(',');
        if (strPKs != "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "OpenTransMailPopUp('" + "Transactions" + "','" + strPKs + "','" + tab + "','" + PK_AL_CI_ID + "');", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "javascript:alert('Please select Transaction(s) to mail');", true);
        }
    }

    /// <summary>
    ///  Handles Print button click event for Transaction Repeater
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

    /// <summary>
    /// Button CLick Event - Button View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnViewSelectedTrans_Click(object sender, EventArgs e)
    {
        string strPK = "";

        foreach (GridViewRow gRow in gvALTransList.Rows)
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
    /// Button CLick Event - Button Cancel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlTransactionDetail.Visible = false;
        pnlTransGrid.Visible = true;

        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "SelectDeselectTransHeader(true);", true);
    }

    protected void GetPage()
    {
        BindWCTransList(lblOriginClaimNumber.Text, ctrlPageTransaction.CurrentPage, ctrlPageTransaction.PageSize);        
    }
    #endregion

    #region Private Methods

    /// <summary>
    /// Function to bind the Claim Information and Finacial Information
    /// </summary>
    public void BindAlClaimInfo()
    {
        DataSet dsAuto_Loss_Claims = AL_ClaimInfo.SelectByPK(PK_AL_CI_ID);
        DataTable dtAuto_Loss_Claims = dsAuto_Loss_Claims.Tables[0];

        if (dtAuto_Loss_Claims.Rows.Count > 0)
        {
            DataRow drAuto_Loss_Claims = dtAuto_Loss_Claims.Rows[0];

            //Header Info
            ComboHelper.FillCompanionClaimReportType(new DropDownList[] { ddlCompanionClaim }, false, !String.IsNullOrEmpty(Convert.ToString(drAuto_Loss_Claims["Associated_First_Report"])) ? Convert.ToDecimal(drAuto_Loss_Claims["Associated_First_Report"]) : 0, "AL_FR");
            if (ddlCompanionClaim.Items.Count == 0)
                ddlCompanionClaim.Items.Insert(0, new ListItem("-- None --", "0"));
            lblClaimNumber.Text = Convert.ToString(drAuto_Loss_Claims["Origin_Claim_Number"]);
            lblDateIncident.Text = drAuto_Loss_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_Of_Accident"]));
            lblLocationdba.Text = Convert.ToString(drAuto_Loss_Claims["dba1"]);
            lnkAssociatedFirstReport.Text = Convert.ToString(drAuto_Loss_Claims["AL_FR_Number"]);
            decimal _FR_Number;
            if (decimal.TryParse(Convert.ToString(drAuto_Loss_Claims["AL_FR_Number"]), out _FR_Number))
                First_Report_Number = _FR_Number;

            if (!string.IsNullOrEmpty(lnkAssociatedFirstReport.Text.Trim()))
                lnkAssociatedFirstReport.Text = Convert.ToString(drAuto_Loss_Claims["Associated_First_Report_Type"]) + "-" + lnkAssociatedFirstReport.Text;

            lblName.Text = Convert.ToString(drAuto_Loss_Claims["Employee_Name"]);

            //Claim Informations
            lblDataSource.Text = Convert.ToString(drAuto_Loss_Claims["Data_Origin"]);
            lblDateofUpdate.Text = drAuto_Loss_Claims["Date_Entered"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_Entered"]));
            lblOriginClaimNumber.Text = Convert.ToString(drAuto_Loss_Claims["Origin_Claim_Number"]).Trim();
            lblKeyClaimNumber.Text = Convert.ToString(drAuto_Loss_Claims["Origin_Key_Claim_Number"]);
            lblAssociatedFirstReport.Text = Convert.ToString(drAuto_Loss_Claims["AL_FR_Number"]);
            lblClaimantSequenceNumber.Text = Convert.ToString(drAuto_Loss_Claims["Claimant_Sequence_Number"]);
            lblEmployeeName.Text = Convert.ToString(drAuto_Loss_Claims["Employee_Name"]);
            lblClaimantFirstName.Text = Convert.ToString(drAuto_Loss_Claims["Claimant_First_Name"]);
            lblClaimantLastName.Text = Convert.ToString(drAuto_Loss_Claims["Claimant_Last_Name"]);
            lblEmployeeStreet.Text = Convert.ToString(drAuto_Loss_Claims["Employee_Street"]);
            lblEmployeeCity.Text = Convert.ToString(drAuto_Loss_Claims["Employee_City"]);
            lblEmployeeState.Text = Convert.ToString(drAuto_Loss_Claims["Employee_State"]);
            lblEmployeeZip.Text = Convert.ToString(drAuto_Loss_Claims["Employee_Zip"]);
            lblEmployeeGender.Text = Convert.ToString(drAuto_Loss_Claims["Employee_Gender"]);
            lblEmployeeSSN.Text = Convert.ToString(drAuto_Loss_Claims["Employee_SSN"]);
            lblMaritalStatus.Text = Convert.ToString(drAuto_Loss_Claims["Marital_Status"]);
            lblEmployeeDateofBirth.Text = drAuto_Loss_Claims["Employee_Date_of_Birth"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Employee_Date_of_Birth"]));
            lblStateofAccident.Text = Convert.ToString(drAuto_Loss_Claims["State_of_Accident"]);
            lblStateofJurisdiction.Text = Convert.ToString(drAuto_Loss_Claims["State_of_Jurisdiction"]);
            lblDateReportedtoInsurer.Text = drAuto_Loss_Claims["Date_Reported_to_Insurer"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_Reported_to_Insurer"]));
            lblDateofAccident.Text = drAuto_Loss_Claims["Date_of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_of_Accident"]));
            lblTimeofLoss.Text = Convert.ToString(drAuto_Loss_Claims["Time_of_Loss"]);
            lblDateEntered.Text = drAuto_Loss_Claims["Date_Entered"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_Entered"]));
            lblDateClosed.Text = drAuto_Loss_Claims["Date_Closed"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_Closed"]));

            lblClaimStatus.Text = Convert.ToString(drAuto_Loss_Claims["Claim_Status_Code"]);
            lblClaim_sub_status.Text = Convert.ToString(drAuto_Loss_Claims["Claim_Sub_Status"]);
            lblLocationCode.Text = Convert.ToString(drAuto_Loss_Claims["dba"]);
            lblCoverageCode.Text = Convert.ToString(drAuto_Loss_Claims["Coverage_Code"]);

            lblDateSuitFiled.Text = drAuto_Loss_Claims["Date_Suit_Filed"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_Suit_Filed"]));
            lblLitigationYN.Text = Convert.ToString(drAuto_Loss_Claims["LitigationYN"]);
            lblSuitResultCode.Text = Convert.ToString(drAuto_Loss_Claims["Suit_Result_Code"]);
            lblSuitTypeCode.Text = Convert.ToString(drAuto_Loss_Claims["Suit_Type_Code"]);
            lblPlaintiffAttorneyCode.Text = Convert.ToString(drAuto_Loss_Claims["Plaintiff_Attorney_Code"]);
            lblSRSPolicyNumber.Text = Convert.ToString(drAuto_Loss_Claims["SRS_Policy_Number"]);
            lblPolicyEffectiveDate.Text = drAuto_Loss_Claims["Policy_Effective_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Policy_Effective_Date"]));
            lblPolicyExpirationDate.Text = drAuto_Loss_Claims["Policy_Expiration_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Policy_Expiration_Date"]));
            lblOtherCarrierPolicyNumber.Text = Convert.ToString(drAuto_Loss_Claims["Other_Carrier_Policy_Number"]);
            lblCarrierEffectiveDate.Text = drAuto_Loss_Claims["Carrier_Effective_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Carrier_Effective_Date"]));
            lblCarrierExpirationDate.Text = drAuto_Loss_Claims["Carrier_Expiration_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Carrier_Expiration_Date"]));
            lblCatastropheCode.Text = Convert.ToString(drAuto_Loss_Claims["Catastrophe_Code"]);
            lblAccidentCityTown.Text = Convert.ToString(drAuto_Loss_Claims["Accident_City_Town"]);

            lblDriverRelationshipCode.Text = Convert.ToString(drAuto_Loss_Claims["Driver_Relationship_Code"]);
            lblDriverGender.Text = Convert.ToString(drAuto_Loss_Claims["Driver_Gender"]);
            lblDriverLicenseNumber.Text = Convert.ToString(drAuto_Loss_Claims["Driver_License_Number"]);
            lblPreviousTPAClaimNumTakeover.Text = Convert.ToString(drAuto_Loss_Claims["Previous_TPA_Claim_Num_Takeover"]);
            lblClaimsMadeIndicator.Text = Convert.ToString(drAuto_Loss_Claims["Claims_Made_Indicator"]);
            lblClaimsMadeDate.Text = drAuto_Loss_Claims["Claims_Made_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Claims_Made_Date"]));
            lblRetroactiveDate.Text = drAuto_Loss_Claims["Retroactive_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Retroactive_Date"]));

            lblVehicleModel.Text = Convert.ToString(drAuto_Loss_Claims["Vehicle_Model"]);
            lblVIN.Text = Convert.ToString(drAuto_Loss_Claims["VIN"]);
            lblVehicleYear.Text = Convert.ToString(drAuto_Loss_Claims["Vehicle_Year"]);
            lblVehicleMake.Text = Convert.ToString(drAuto_Loss_Claims["Vehicle_Make"]);
            lblAccidentDescription.Text = Convert.ToString(drAuto_Loss_Claims["Accident_Description"]);
            lblClaimDescription.Text = Convert.ToString(drAuto_Loss_Claims["Claim_Description"]);
            lblDriverage.Text = Convert.ToString(drAuto_Loss_Claims["Driver_age"]);
            lblDriverName.Text = Convert.ToString(drAuto_Loss_Claims["Driver_Name"]);
            lblDriverDateofBirth.Text = drAuto_Loss_Claims["Driver_Date_of_Birth"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Driver_Date_of_Birth"]));
            lblDriverMaritalStatus.Text = Convert.ToString(drAuto_Loss_Claims["Driver_Marital_Status"]);
            lblCauseofInjuryCode.Text = Convert.ToString(drAuto_Loss_Claims["Cause_of_Injury_Code_Desc"]);

            //Financials
            lblLossGrossPaid.Text = drAuto_Loss_Claims["Loss_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Loss_Gross_Paid"])) : "";
            lblNetLossPaid.Text = drAuto_Loss_Claims["Net_Loss_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Net_Loss_Paid"])) : "";
            lblLossNetRecovered.Text = drAuto_Loss_Claims["Loss_Net_Recovered"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Loss_Net_Recovered"])) : "";
            lblLossIncurred.Text = drAuto_Loss_Claims["Loss_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Loss_Incurred"])) : "";
            lblLossOutstanding.Text = drAuto_Loss_Claims["Loss_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Loss_Outstanding"])) : "";
            lblExpenseGrossPaid.Text = drAuto_Loss_Claims["Expense_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Expense_Gross_Paid"])) : "";
            lblNetExpensePaid.Text = drAuto_Loss_Claims["Net_Expense_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Net_Expense_Paid"])) : "";
            lblExpenseNetRecovered.Text = drAuto_Loss_Claims["Expense_Net_Recovered"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Expense_Net_Recovered"])) : "";
            lblExpenseIncurred.Text = drAuto_Loss_Claims["Expense_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Expense_Incurred"])) : "";
            lblExpenseOutstanding.Text = drAuto_Loss_Claims["Expense_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Expense_Outstanding"])) : "";
            lblLossGrossSubrogation.Text = drAuto_Loss_Claims["Loss_Gross_Subrogation"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Loss_Gross_Subrogation"])) : "";
            lblLossSubrogationExpense.Text = drAuto_Loss_Claims["Loss_Subrogation_Expense"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Loss_Subrogation_Expense"])) : "";
            lblLossGrossSalvage.Text = drAuto_Loss_Claims["Loss_Gross_Salvage"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Loss_Gross_Salvage"])) : "";
            lblLossSalvageExpense.Text = drAuto_Loss_Claims["Loss_Salvage_Expense"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Loss_Salvage_Expense"])) : "";
            lblLossGrossRefund.Text = drAuto_Loss_Claims["Loss_Gross_Refund"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Loss_Gross_Refund"])) : "";
            lblAleGrossSubrogation.Text = drAuto_Loss_Claims["Ale_Gross_Subrogation"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Ale_Gross_Subrogation"])) : "";
            lblAleGrossSalvage.Text = drAuto_Loss_Claims["Ale_Gross_Salvage"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Ale_Gross_Salvage"])) : "";
            lblAleGrossRefund.Text = drAuto_Loss_Claims["Ale_Gross_Refund"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Ale_Gross_Refund"])) : "";
            lblAleRefundExpense.Text = drAuto_Loss_Claims["Ale_Refund_Expense"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Ale_Refund_Expense"])) : "";
            lblLegalExpenseIncurred.Text = drAuto_Loss_Claims["Legal_Expense_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Legal_Expense_Incurred"])) : "";
            lblLegalExpensePaidtoDate.Text = drAuto_Loss_Claims["Legal_Expense_Paid_to_Date"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Legal_Expense_Paid_to_Date"])) : "";
            lblRecoveredLossDeductibleAmount.Text = drAuto_Loss_Claims["Recovered_Loss_Deductible_Amount"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Recovered_Loss_Deductible_Amount"])) : "";
            lblRecoveredExpenseDeductibleAmount.Text = drAuto_Loss_Claims["Recovered_Expense_Deductible_Amount"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Recovered_Expense_Deductible_Amount"])) : "";
            lblPreviousTPAIndemnityPaid.Text = drAuto_Loss_Claims["Previous_TPA_Indemnity_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Previous_TPA_Indemnity_Paid"])) : "";
            lblPreviousTPAMedicalPaid.Text = drAuto_Loss_Claims["Previous_TPA_Medical_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Previous_TPA_Medical_Paid"])) : "";
            lblPreviousTPAExpensePaid.Text = drAuto_Loss_Claims["Previous_TPA_Expense_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Previous_TPA_Expense_Paid"])) : "";
            lblLineOfCoverage.Text = Convert.ToString(drAuto_Loss_Claims["Line_Of_Coverage"]);

            BindWCTransList(lblOriginClaimNumber.Text, ctrlPageTransaction.CurrentPage, ctrlPageTransaction.PageSize);

            ucAdjusterNotes.ClaimID = PK_AL_CI_ID;
            ucAdjusterNotes.ClaimNumber = lblOriginClaimNumber.Text;
            ucAdjusterNotes.BindGridNotes(lblOriginClaimNumber.Text);

            ctrlSonicNotes.PK_AL_CI_ID = PK_AL_CI_ID;
            ctrlSonicNotes.CurrentClaimType = clsGeneral.Claim_Tables.ALClaim.ToString();
            ctrlSonicNotes.BindGridSonicNotes(PK_AL_CI_ID, clsGeneral.Claim_Tables.ALClaim.ToString());

            DataSet objDs = new DataSet();

            objDs = ERIMS.DAL.Claim_CST.Claim_CSTSelectByOriginClaimNumber(Convert.ToString(drAuto_Loss_Claims["Origin_Claim_Number"]).Trim());
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
        DataSet dsWCTransList = Claims_Transaction.SelectByOriginClaimNumber(lblOriginClaimNumber.Text, PageNumber, PageSize);
        DataTable dtWCTransList = dsWCTransList.Tables[0];
        ctrlPageTransaction.TotalRecords = (dsWCTransList.Tables.Count >= 2) ? Convert.ToInt32(dsWCTransList.Tables[1].Rows[0][0]) : 0;
        ctrlPageTransaction.CurrentPage = (dsWCTransList.Tables.Count >= 2) ? Convert.ToInt32(dsWCTransList.Tables[1].Rows[0][2]) : 0;
        ctrlPageTransaction.RecordsToBeDisplayed = dsWCTransList.Tables[0].Rows.Count;
        ctrlPageTransaction.SetPageNumbers();
        gvALTransList.DataSource = dtWCTransList;
        gvALTransList.DataBind();
    }

    /// <summary>
    /// Function to bind the transaction detials when click on transaction list
    /// </summary>
    /// <param name="PK_ID">Claim Transaction PK Id</param>
    /// <returns></returns>
    public bool BindClaimTransactionDetails(String PK_IDs)
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
            lblClaimantSequenceNumber2.Text = Convert.ToString(drClaims_Transactions["Claimant_Sequence_Number"]);
            lblPolicyNumber.Text = Convert.ToString(drClaims_Transactions["Policy_Number"]);
            lblCarrierpolicynumber2.Text = Convert.ToString(drClaims_Transactions["Carrier_policy_number"]);
            lblTransactionEntrydate.Text = drClaims_Transactions["Transaction_Entry_date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drClaims_Transactions["Transaction_Entry_date"]));
            lblTransactionAmount.Text = drClaims_Transactions["Transaction_Amount"] == DBNull.Value ? "" : String.Format("$ {0:N2}", Convert.ToDecimal(drClaims_Transactions["Transaction_Amount"]));
            lblTransactionSequenceNumber.Text = Convert.ToString(drClaims_Transactions["Transaction_Sequence_Number"]);
            lblClaimStatus2.Text = Convert.ToString(drClaims_Transactions["Claim_Status"]);

            lblEntryCodeModifier.Text = Convert.ToString(drClaims_Transactions["Entry_Code_Modifier_Desc"]);
            lblEntryCode.Text = Convert.ToString(drClaims_Transactions["Entry_Code_Desc"]);
            lblNatureofBenefitCode.Text = Convert.ToString(drClaims_Transactions["Nature_of_Benefit_Code_Desc"]);
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
            lblPayeeId.Text = Convert.ToString(drClaims_Transactions["Payee_Tax_Number"]) + " - " + Convert.ToString(drClaims_Transactions["Payee_SSN_FEIN"]);
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

    //Bind Risk Management WorkSheet
    public void BindRiskMangWorkSheet()
    {
        //Binf Dropdown
        ComboHelper.FillBodyPartAffected(new DropDownList[] { ddlFK_LU_Part_Of_Body }, 0, true);
        ComboHelper.FillNatureofInjury(new DropDownList[] { ddlFK_LU_Nature_Of_Injury }, 0, true);

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

        DataSet dsAuto_Loss_Claims = AL_ClaimInfo.SelectByPK(PK_AL_CI_ID);
        DataTable dtAuto_Loss_Claims = dsAuto_Loss_Claims.Tables[0];

        if (dtAuto_Loss_Claims.Rows.Count > 0)
        {
            DataRow drAuto_Loss_Claims = dtAuto_Loss_Claims.Rows[0];

            lblOrigin_Claim_Number.Text = Convert.ToString(drAuto_Loss_Claims["Origin_Claim_Number"]);
            lblDate_of_Accident.Text = drAuto_Loss_Claims["Date_of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_of_Accident"]));
            lblDate_Entered.Text = drAuto_Loss_Claims["Date_Entered"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_Entered"]));
            lblDate_Reported_To_Insurer.Text = drAuto_Loss_Claims["Date_Reported_To_Insurer"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_Reported_To_Insurer"]));


            if (!string.IsNullOrEmpty(Convert.ToString(drAuto_Loss_Claims["FK_Insured_Location_Code"])))
            {
                LU_Location objLocation = new LU_Location(Convert.ToInt32(drAuto_Loss_Claims["FK_Insured_Location_Code"]));
                if (objLocation.PK_LU_Location_ID > 0)
                    lblFK_Insured_Location_Code.Text = objLocation.RM_Location_Number + "-" + objLocation.Sonic_Location_Code;
                else
                    lblFK_Insured_Location_Code.Text = "";
            }
            else
                lblFK_Insured_Location_Code.Text = "";

            lblRegion.Text = new LU_Location(string.IsNullOrEmpty(Convert.ToString(drAuto_Loss_Claims["FK_Insured_Location_Code"])) ? 0 : Convert.ToInt32(drAuto_Loss_Claims["FK_Insured_Location_Code"])).Region;
            lblState_Of_Accident.Text = Convert.ToString(drAuto_Loss_Claims["State_Of_Accident"]);
            lblState_of_Jurisdiction.Text = Convert.ToString(drAuto_Loss_Claims["State_of_Jurisdiction"]);
            lblClaimantsName.Text = (Convert.ToString(drAuto_Loss_Claims["Claimant_First_Name"]) + " " + Convert.ToString(drAuto_Loss_Claims["Claimant_Last_Name"]));
            lblDriver_Name.Text = Convert.ToString(drAuto_Loss_Claims["Driver_Name"]);
            lblAccident_Description.Text = Convert.ToString(drAuto_Loss_Claims["Accident_Description"]);
            lblPlaintiff_Attorney_Code.Text = Convert.ToString(drAuto_Loss_Claims["Plaintiff_Attorney_Code"]);
            lblLegal_LitigationYN.Text = Convert.ToString(drAuto_Loss_Claims["LitigationYN"]);
            if (Convert.ToString(drAuto_Loss_Claims["LitigationYN"]) == "Y")
            {
                trCRMTitle.Style.Add("display", "none");
                trCRM.Style.Add("display", "none");
            }
            else if (Convert.ToString(drAuto_Loss_Claims["LitigationYN"]) == "N")
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
            lblDate_Suit_Filed.Text = drAuto_Loss_Claims["Date_Suit_Filed"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_Suit_Filed"]));
            lblSuit_Type_Code.Text = Convert.ToString(drAuto_Loss_Claims["Suit_Type_Code"]);
            lblSuit_Result_Code.Text = Convert.ToString(drAuto_Loss_Claims["Suit_Result_Code"]);

            lblLoss_Incurred.Text = drAuto_Loss_Claims["Loss_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Loss_Incurred"])) : "";
            lblLoss_Gross_Paid.Text = drAuto_Loss_Claims["Loss_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Loss_Gross_Paid"])) : "";
            lblLoss_Outstanding.Text = drAuto_Loss_Claims["Loss_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Loss_Outstanding"])) : "";
            lblLoss_Gross_Subrogation.Text = drAuto_Loss_Claims["Loss_Gross_Subrogation"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Loss_Gross_Subrogation"])) : "";

            lblAle_Gross_Subrogation.Text = drAuto_Loss_Claims["Ale_Gross_Subrogation"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Ale_Gross_Subrogation"])) : "";

            lblExpense_Incurred.Text = drAuto_Loss_Claims["Expense_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Expense_Incurred"])) : "";
            lblExpense_Gross_Paid.Text = drAuto_Loss_Claims["Expense_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Expense_Gross_Paid"])) : "";
            lblExpense_Outstanding.Text = drAuto_Loss_Claims["Expense_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Expense_Outstanding"])) : "";

            lblLegal_Expense_Incurred.Text = drAuto_Loss_Claims["Legal_Expense_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Legal_Expense_Incurred"])) : "";
            lblLegal_Expense_Paid_to_Date.Text = drAuto_Loss_Claims["Legal_Expense_Paid_to_Date"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drAuto_Loss_Claims["Legal_Expense_Paid_to_Date"])) : "";


            lblCause_of_Injury_Code.Text = new LU_Cause_of_Injury(string.IsNullOrEmpty(Convert.ToString(drAuto_Loss_Claims["Cause_of_Injury_Code"])) ? "" : Convert.ToString(drAuto_Loss_Claims["Cause_of_Injury_Code"])).Description;

            DataSet dsALC = Auto_Loss_RMW.SelectByFK(PK_AL_CI_ID);
            DataTable dtALC = dsALC.Tables[0];
            PK_Auto_Loss_RMW = 0;
            if (dtALC.Rows.Count > 0)
            {
                DataRow drALC = dtALC.Rows[0];
                PK_Auto_Loss_RMW = Convert.ToInt32(drALC["PK_Auto_Loss_RMW"]);
                if (drALC["Claimant_Customer"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["Claimant_Customer"]) == true)
                    {
                        rdoClaimant_Customer.SelectedValue = "1";
                    }
                    else
                    {
                        rdoClaimant_Customer.SelectedValue = "0";
                    }
                }

                if (drALC["Claimant_Third_Party"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["Claimant_Third_Party"]) == true)
                    {
                        rdoClaimant_Third_Party.SelectedValue = "1";
                    }
                    else
                    {
                        rdoClaimant_Third_Party.SelectedValue = "0";
                    }
                }

                if (drALC["Driver_Customer"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["Driver_Customer"]) == true)
                    {
                        rdoDriver_Customer.SelectedValue = "1";
                    }
                    else
                    {
                        rdoDriver_Customer.SelectedValue = "0";
                    }
                }

                if (drALC["Driver_Associate"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["Driver_Associate"]) == true)
                    {
                        rdoDriver_Associate.SelectedValue = "1";
                    }
                    else
                    {
                        rdoDriver_Associate.SelectedValue = "0";
                    }
                }

                txtLiability_Analysis.Text = Convert.ToString(drALC["Liability_Analysis"]);

                if (drALC["Demand"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["Demand"]) == true)
                    {
                        rdoDemand.SelectedValue = "1";
                    }
                    else
                    {
                        rdoDemand.SelectedValue = "0";
                    }
                }

                txtClaimant_Counsel_Name.Text = Convert.ToString(drALC["Claimant_Counsel_Name"]);
                txtPlantiff_Counsel_Name.Text = Convert.ToString(drALC["Plantiff_Counsel_Name"]);

                if (drALC["Property_Damaged"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["Property_Damaged"]) == true)
                    {
                        rdoProperty_Damaged.SelectedValue = "1";
                    }
                    else
                    {
                        rdoProperty_Damaged.SelectedValue = "0";
                    }
                }

                txtProperty_Damages_Description.Text = Convert.ToString(drALC["Property_Damages_Description"]);
                txtDamage_Amount.Text = drALC["Damage_Amount"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drALC["Damage_Amount"]));

                if (drALC["Bodily_Injury"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["Bodily_Injury"]) == true)
                    {
                        rdoBodily_Injury.SelectedValue = "1";
                    }
                    else
                    {
                        rdoBodily_Injury.SelectedValue = "0";
                    }
                }

                txtInjury_Description.Text = Convert.ToString(drALC["Injury_Description"]);

                //check null value for object
                if (drALC["FK_LU_Part_Of_Body"] != DBNull.Value)
                {
                    ListItem lstFK_LU_Part_Of_Body = new ListItem();
                    lstFK_LU_Part_Of_Body = ddlFK_LU_Part_Of_Body.Items.FindByValue(Convert.ToString(drALC["FK_LU_Part_Of_Body"]));
                    //check null value for listitem. if it is not true than select listitem
                    if (lstFK_LU_Part_Of_Body != null)
                        lstFK_LU_Part_Of_Body.Selected = true;
                }

                //check null value for object
                if (drALC["FK_LU_Nature_Of_Injury"] != DBNull.Value)
                {
                    ListItem lstFK_LU_Nature_Of_Injury = new ListItem();
                    lstFK_LU_Nature_Of_Injury = ddlFK_LU_Nature_Of_Injury.Items.FindByValue(Convert.ToString(drALC["FK_LU_Nature_Of_Injury"]));
                    //check null value for listitem. if it is not true than select listitem
                    if (lstFK_LU_Nature_Of_Injury != null)
                        lstFK_LU_Nature_Of_Injury.Selected = true;
                }

                txtMedical_Treatment_Description.Text = Convert.ToString(drALC["Medical_Treatment_Description"]);
                txtMedical_Cost.Text = drALC["Medical_Cost"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drALC["Medical_Cost"]));
                txtRequested_Amount.Text = drALC["Requested_Amount"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drALC["Requested_Amount"]));
                txtPotential_Total_Exposure.Text = drALC["Potential_Total_Exposure"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drALC["Potential_Total_Exposure"]));

                if (drALC["Settled"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["Settled"]) == true)
                    {
                        rdoSettled.SelectedValue = "1";
                    }
                    else
                    {
                        rdoSettled.SelectedValue = "0";
                    }
                }

                txtSettled_Amount.Text = drALC["Settled_Amount"] == DBNull.Value ? "" : String.Format("{0:N2}", Convert.ToDecimal(drALC["Settled_Amount"]));

                txtGM_Email_To.Text = Convert.ToString(drALC["GM_Email_To"]);
                if (drALC["GM_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["GM_Decision"]) == true)
                    {
                        rdoGM_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoGM_Decision.SelectedValue = "0";
                    }
                }
                txtGM_Last_Email_Date.Text = drALC["GM_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["GM_Last_Email_Date"]));
                txtGM_Response_Date.Text = drALC["GM_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["GM_Response_Date"]));

                txtCRM_Email_To.Text = Convert.ToString(drALC["CRM_Email_To"]);
                if (drALC["CRM_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["CRM_Decision"]) == true)
                    {
                        rdoCRM_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoCRM_Decision.SelectedValue = "0";
                    }
                }
                txtCRM_Last_Email_Date.Text = drALC["CRM_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["CRM_Last_Email_Date"]));
                txtCRM_Response_Date.Text = drALC["CRM_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["CRM_Response_Date"]));

                txtAGC_Email_To.Text = Convert.ToString(drALC["AGC_Email_To"]);
                if (drALC["AGC_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["AGC_Decision"]) == true)
                    {
                        rdoAGC_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoAGC_Decision.SelectedValue = "0";
                    }
                }
                txtAGC_Last_Email_Date.Text = drALC["AGC_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["AGC_Last_Email_Date"]));
                txtAGC_Response_Date.Text = drALC["AGC_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["AGC_Response_Date"]));


                txtRVP_Email_To.Text = Convert.ToString(drALC["RVP_Email_To"]);
                if (drALC["RVP_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["RVP_Decision"]) == true)
                    {
                        rdoRVP_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoRVP_Decision.SelectedValue = "0";
                    }
                }
                txtRVP_Last_Email_Date.Text = drALC["RVP_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["RVP_Last_Email_Date"]));
                txtRVP_Response_Date.Text = drALC["RVP_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["RVP_Response_Date"]));


                txtDRM_Email_To.Text = Convert.ToString(drALC["DRM_Email_To"]);
                if (drALC["DRM_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["DRM_Decision"]) == true)
                    {
                        rdoDRM_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoDRM_Decision.SelectedValue = "0";
                    }
                }
                txtDRM_Last_Email_Date.Text = drALC["DRM_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["DRM_Last_Email_Date"]));
                txtDRM_Response_Date.Text = drALC["DRM_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["DRM_Response_Date"]));

                txtCFO_Email_To.Text = Convert.ToString(drALC["CFO_Email_To"]);
                if (drALC["CFO_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["CFO_Decision"]) == true)
                    {
                        rdoCFO_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoCFO_Decision.SelectedValue = "0";
                    }
                }
                txtCFO_Last_Email_Date.Text = drALC["CFO_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["CFO_Last_Email_Date"]));
                txtCFO_Response_Date.Text = drALC["CFO_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["CFO_Response_Date"]));

                txtCOO_Email_To.Text = Convert.ToString(drALC["COO_Email_To"]);
                if (drALC["COO_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["COO_Decision"]) == true)
                    {
                        rdoCOO_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoCOO_Decision.SelectedValue = "0";
                    }
                }
                txtCOO_Last_Email_Date.Text = drALC["COO_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["COO_Last_Email_Date"]));
                txtCOO_Response_Date.Text = drALC["COO_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["COO_Response_Date"]));

                txtPresident_Email_To.Text = Convert.ToString(drALC["President_Email_To"]);
                if (drALC["President_Decision"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(drALC["President_Decision"]) == true)
                    {
                        rdoPresident_Decision.SelectedValue = "1";
                    }
                    else
                    {
                        rdoPresident_Decision.SelectedValue = "0";
                    }
                }
                txtPresident_Last_Email_Date.Text = drALC["President_Last_Email_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["President_Last_Email_Date"]));
                txtPresident_Response_Date.Text = drALC["President_Response_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drALC["President_Response_Date"]));

                txtComments.Text = Convert.ToString(drALC["Comments"]);
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
        ctlAttchment.Add(clsGeneral.Claim_Tables.ALClaim, Convert.ToInt32(PK_AL_CI_ID));

        // Used to Bind Grid with Attached Data
        ctlAttchmentDetails.Bind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Claim Upload File
    /// </summary>
    /// <param name="strValue"></param>
    protected void ClaimUpload_File(string strValue)
    {
        //Insert values into AL_FR_Attachment table
        CtrlAttachment_Cliam.Add(clsGeneral.Tables.ALClaim, Convert.ToInt32(PK_AL_CI_ID));
        // Used to Bind Grid with Attached Data
        CtlAttachDetail_Cliam.Bind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
    }

    /// <summary>
    /// Bind Sonic Note Grid
    /// </summary>
    //private void BindGridSonicNotes()
    //{
    //    DataTable dtNotes = Claim_Notes.SelectByFK_Table(PK_AL_CI_ID, clsGeneral.Claim_Tables.ALClaim.ToString(),ctrlPageTransaction.CurrentPage,ctrlPageTransaction.PageSize).Tables[0];
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
        DataTable dtFields = clsScreen_Validators.SelectByScreen(38).Tables[0];
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
                case "Body Parts Affected":
                    strCtrlsIDs += ddlFK_LU_Part_Of_Body.ClientID + ",";
                    strMessages += "Please select Body Parts Affected" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Nature of Injury":
                    strCtrlsIDs += ddlFK_LU_Nature_Of_Injury.ClientID + ",";
                    strMessages += "Please enter Nature of Injury" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Description of Medical Treatment":
                    strCtrlsIDs += "ctl00_ContentPlaceHolder1_txtMedical_Treatment_Description_txtNote,";
                    strMessages += "Please enter Description of Medical Treatment" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Total Medical Cost":
                    strCtrlsIDs += txtMedical_Cost.ClientID + ",";
                    strMessages += "Please enter Total Medical Cost" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Requested Amount":
                    strCtrlsIDs += txtRequested_Amount.ClientID + ",";
                    strMessages += "Please enter Requested Amount" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Potential Total Exposure":
                    strCtrlsIDs += txtPotential_Total_Exposure.ClientID + ",";
                    strMessages += "Please enter Potential Total Exposure" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Settled Amount":
                    strCtrlsIDs += txtSettled_Amount.ClientID + ",";
                    strMessages += "Please enter Settled Amount" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "GM Email To":
                    strCtrlsIDs += txtGM_Email_To.ClientID + ",";
                    strMessages += "Please enter GM Email To" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "GM Last E-Mail Date":
                    strCtrlsIDs += txtGM_Last_Email_Date.ClientID + ",";
                    strMessages += "Please enter GM Last E-Mail Date" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                case "GM Response Date":
                    strCtrlsIDs += txtGM_Response_Date.ClientID + ",";
                    strMessages += "Please enter GM Response Date" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                case "Comments":
                    strCtrlsIDs += "ctl00_ContentPlaceHolder1_txtComments_txtNote,";
                    strMessages += "Please enter Comments" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "CRM Email To":
                    strCtrlsIDs += txtCRM_Email_To.ClientID + ",";
                    strMessages += "Please enter CRM Email To" + ",";
                    Span17.Style["display"] = "inline-block";
                    break;
                case "CRM Last E-Mail Date":
                    strCtrlsIDs += txtCRM_Last_Email_Date.ClientID + ",";
                    strMessages += "Please enter CRM Last E-Mail Date" + ",";
                    Span18.Style["display"] = "inline-block";
                    break;
                case "CRM Response Date":
                    strCtrlsIDs += txtCRM_Response_Date.ClientID + ",";
                    strMessages += "Please enter CRM Response Date" + ",";
                    Span19.Style["display"] = "inline-block";
                    break;
                case "AGC E-Mail To":
                    strCtrlsIDs += txtAGC_Email_To.ClientID + ",";
                    strMessages += "Please enter AGC E-Mail To" + ",";
                    Span20.Style["display"] = "inline-block";
                    break;
                case "AGC Last E-Mail Date":
                    strCtrlsIDs += txtAGC_Last_Email_Date.ClientID + ",";
                    strMessages += "Please enter AGC Last E-Mail Date" + ",";
                    Span21.Style["display"] = "inline-block";
                    break;
                case "AGC Response Date":
                    strCtrlsIDs += txtAGC_Response_Date.ClientID + ",";
                    strMessages += "Please enter AGC Response Date" + ",";
                    Span22.Style["display"] = "inline-block";
                    break;
                case "RVP E-Mail To":
                    strCtrlsIDs += txtRVP_Email_To.ClientID + ",";
                    strMessages += "Please enter RVP E-Mail To" + ",";
                    Span23.Style["display"] = "inline-block";
                    break;
                case "RVP Last E-Mail Date":
                    strCtrlsIDs += txtRVP_Last_Email_Date.ClientID + ",";
                    strMessages += "Please enter RVP Last E-Mail Date" + ",";
                    Span24.Style["display"] = "inline-block";
                    break;
                case "RVP Response Date":
                    strCtrlsIDs += txtRVP_Response_Date.ClientID + ",";
                    strMessages += "Please enter RVP Response Date" + ",";
                    Span25.Style["display"] = "inline-block";
                    break;
                case "DRM E-Mail To":
                    strCtrlsIDs += txtDRM_Email_To.ClientID + ",";
                    strMessages += "Please enter DRM E-Mail To" + ",";
                    Span26.Style["display"] = "inline-block";
                    break;
                case "DRM Last E-Mail Date":
                    strCtrlsIDs += txtDRM_Last_Email_Date.ClientID + ",";
                    strMessages += "Please enter DRM Last E-Mail Date" + ",";
                    Span27.Style["display"] = "inline-block";
                    break;
                case "DRM Response Date":
                    strCtrlsIDs += txtDRM_Response_Date.ClientID + ",";
                    strMessages += "Please enter DRM Response Date" + ",";
                    Span28.Style["display"] = "inline-block";
                    break;
                case "CFO E-Mail To":
                    strCtrlsIDs += txtCFO_Email_To.ClientID + ",";
                    strMessages += "Please enter CFO E-Mail To" + ",";
                    Span29.Style["display"] = "inline-block";
                    break;
                case "CFO Last E-Mail Date":
                    strCtrlsIDs += txtCFO_Last_Email_Date.ClientID + ",";
                    strMessages += "Please enter CFO Last E-Mail Date" + ",";
                    Span30.Style["display"] = "inline-block";
                    break;
                case "CFO Response Date":
                    strCtrlsIDs += txtCFO_Response_Date.ClientID + ",";
                    strMessages += "Please enter CFO Response Date" + ",";
                    Span31.Style["display"] = "inline-block";
                    break;
                case "COO E-Mail To":
                    strCtrlsIDs += txtCOO_Email_To.ClientID + ",";
                    strMessages += "Please enter COO E-Mail To" + ",";
                    Span32.Style["display"] = "inline-block";
                    break;
                case "COO Last E-Mail Date":
                    strCtrlsIDs += txtCOO_Last_Email_Date.ClientID + ",";
                    strMessages += "Please enter COO Last E-Mail Date" + ",";
                    Span33.Style["display"] = "inline-block";
                    break;
                case "COO Response Date":
                    strCtrlsIDs += txtCOO_Response_Date.ClientID + ",";
                    strMessages += "Please enter COO Response Date" + ",";
                    Span34.Style["display"] = "inline-block";
                    break;
                case "President E-Mail To":
                    strCtrlsIDs += txtPresident_Email_To.ClientID + ",";
                    strMessages += "Please enter President E-Mail To" + ",";
                    Span35.Style["display"] = "inline-block";
                    break;
                case "President Last E-Mail Date":
                    strCtrlsIDs += txtPresident_Last_Email_Date.ClientID + ",";
                    strMessages += "Please enter President Last E-Mail Date" + ",";
                    Span36.Style["display"] = "inline-block";
                    break;
                case "President Response Date":
                    strCtrlsIDs += txtPresident_Response_Date.ClientID + ",";
                    strMessages += "Please enter President Response Date" + ",";
                    Span37.Style["display"] = "inline-block";
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

    #region Transaction View, Print and Mail
    
    private void PrintTransaction(string strPK)
    {
        if (strPK != string.Empty)
        {
            DataTable dtClaim = AL_ClaimInfo.SelectByPK(PK_AL_CI_ID).Tables[0]; ;
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
