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
using RIMS_Base.Biz;
using System.Collections.Generic;

/// <summary>
/// Date : 29 MAY 2008
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// To add, edit and view the Executive Risk record
/// 
/// Functionality:
/// Checks for the Session value for operation
/// and sets the page controls in view or edit or add mode
/// Also performs attachments adding, listing and removing
/// </summary>
public partial class PropertyLiability_ExecutiveRisk : clsBasePage
{
    /// <summary>
    /// Variables
    /// </summary>
    public RIMS_Base.Biz.CRolePermission m_objRightDetails;
    List<RIMS_Base.CRolePermission> lstRightDetails = null;

    #region "Properties"

    /// <summary>
    /// Denotes Primary key value for Executive Risk record
    /// </summary>
    public int PK_Executive_Risk
    {
        get { return clsGeneral.GetInt(ViewState["PK_Executive_Risk"]); }
        set { ViewState["PK_Executive_Risk"] = value; }
    }

    /// <summary>
    /// Denotes operation either view or edit
    /// </summary>
    public string StrOperation
    {
        get
        {
            return clsSession.Str_Executive_Operation;
        }
    }

    public bool bAddTo
    {
        get
        {
            if (Request.QueryString["Claim"] != null && Request.QueryString["Claim"] == "AddTo")
                return true;
            else
                return false;
        }
    }
    #endregion

    #region "Page Events"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //SetUserRights();
        // if page is loaded first time.
        Attachment.btnHandler += new Controls_Attachments_Attachment.OnButtonClick(Upload_File);
        if (!IsPostBack)
        {
            if ((!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["Claim"]))) || (!clsGeneral.IsNull(Request.QueryString["op"])))
            {
                clsSession.Str_Executive_Operation = "";
                Session["WorkerCompID"] = null;
                clsSession.Current_Executive_Risk_ID = 0;
            }
            // set panel
            // check for the querystring whether panel number is passed 
            // otherwise display first panel
            if (!clsGeneral.IsNull(Request.QueryString["pnl"]))
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + Request.QueryString["pnl"] + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            // set the primary key 
            if (!clsGeneral.IsNull(Request.QueryString["id"]))
                PK_Executive_Risk = Convert.ToInt32(Request.QueryString["id"]);

            ViewState["PK_Liability_Claim"] = Session["WorkerCompID"];

            if (bAddTo)
            {
                // Bind required dropdowns
                BindDropDowns();
                // set values in textbox and all other controls.
                BindDetailsForEdit();
                // set attachment details control in read/write mode. so user can add or remove attachment as well.
                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Executive_Risk, PK_Executive_Risk, true, 11);
                BindAttachmentDetails();
            }
            else
            {
                // check for the operation whether it is edit or view
                if ((StrOperation != string.Empty) && (StrOperation == "view" || StrOperation == "edit") && (!String.IsNullOrEmpty(Request.QueryString["id"])))
                {
                    if (StrOperation == "view")
                    {
                        // if view mode
                        // set values in label as per id.
                        BindDetailsForView();
                        // set attachment details control in readonly mode.
                        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Executive_Risk, PK_Executive_Risk, false, 11);
                    }
                    else
                    {
                        // Bind required dropdowns
                        BindDropDowns();
                        // set values in textbox and all other controls.
                        BindDetailsForEdit();
                        // set attachment details control in read/write mode. so user can add or remove attachment as well.
                        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Executive_Risk, PK_Executive_Risk, true, 11);
                    }
                    // bind attachment details to show attachment for current executive risk record
                    BindAttachmentDetails();
                }
                else
                {
                    if (Module_Access_Mode != AccessType.Administrative_Access)
                        Response.Redirect("../Search/NoRights.aspx", false);
                    else
                    {
                        // hide the add attachment button 
                        Attachment.ShowAttachmentButton = false;
                        ExecutiveRiskInfo.Visible = false;
                        btnViewAudit.Visible = false;
                        btnAuditView.Visible = false;
                        btnBackToSearch.Visible = false;
                        // set the next claim number
                        lblClaimNumber.Text = Executive_Risk.GetNextClaimNumber(false, "");
                        lblTempClaimNumber.Visible = true;
                        // don't show div for view mode
                        dvView.Style["Display"] = "None";
                        // bind grids
                        BindGrids();
                        // Bind required dropdowns
                        BindDropDowns();
                    }
                }
            }
            if (StrOperation != "view")
                SetValidations();
        }
        if (Session["ViewAll"] != null)
        {
            btnBack.Visible = false;
            btnNextStepView.Visible = true;
            btnViewAudit.Visible = false;
            btnAuditView.Visible = true;
            btnBackToSearch.Visible = true;
        }

        if (ExecutiveRiskInfo.Visible)
            ExecutiveRiskInfo.SetSelectedTab(CtrlExecutiveRiskInfo.Tab.Executive_Risk);

    }

    #endregion

    #region "Bind Details for Edit or View"

    /// <summary>
    /// Displays the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        // don't show div for view mode
        dvView.Style["display"] = "None";
        // create object for the executive risk record
        Executive_Risk objRisk = new Executive_Risk(PK_Executive_Risk);
        // set the values 
        lblClaimNumber.Text = bAddTo ? Executive_Risk.GetNextClaimNumber(bAddTo, objRisk.Claim_Number) : objRisk.Claim_Number;        
        ddlRMLocationNumber.SelectedValue = Convert.ToString(objRisk.FK_Entity);
        ddlLocationdba.SelectedValue = Convert.ToString(objRisk.FK_Entity);
        ddlLegalEntity.SelectedValue = Convert.ToString(objRisk.FK_Entity);
        ddlEntity.SelectedValue = Convert.ToString(objRisk.FK_Entity);
        drpTypeOfClaim.SelectedValue = Convert.ToString(objRisk.FK_Type_Of_ER_Claim);
        if (drpTypeOfClaim.SelectedItem.Text == "Other") txtOtherClaimType.Text = objRisk.Claim_Type_Other;
        //drpTypeOfAllegation.SelectedValue = Convert.ToString(objRisk.FK_Type_Of_ER_Allegation);
        txtLegalFileNumber.Text = objRisk.Legal_File_Number;
        txtComplaintant.Text = objRisk.Complainant_Plaintiff;
        txtDefendant.Text = objRisk.Defendant;
        txtClaimDescription.Text = objRisk.Claim_Description;
        txtDateClaimOpened.Text = clsGeneral.FormatDateToDisplay(objRisk.Claim_Open_Date);
        txtDateClaimClosed.Text = clsGeneral.FormatDateToDisplay(objRisk.Claim_Close_Date);
        txtDateClaimReopened.Text = clsGeneral.FormatDateToDisplay(objRisk.Claim_Reopen_Date);
        rdoBordereauReport.SelectedValue = objRisk.Bordereau_Report;
        txtClaimStatus.Text = objRisk.Claim_Status_Comments;
        rdoEEOC.SelectedValue = objRisk.EEOC;
        txtStateEmploymentComission.Text = objRisk.State_Employment_Commission;
        rdoLetterReceived.SelectedValue = objRisk.Representation_Letter_Received;
        txtDateLetterReceived.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Representation_Letter_Received);
        rdoSecurityLitigation.SelectedValue = objRisk.Security_Litigation;
        rdoOtherLitigation.SelectedValue = objRisk.Other_Litigation;
        txtJuridiction.Text = objRisk.Jurisdiction;
        txtDateComplaintFiled.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Complaint_Suit_Filed);
        txtDateSuitServed.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Suite_Served);
        txtCaseNumber.Text = objRisk.Case_Number;
        txtPrimaryClaimNumber.Text = objRisk.Primary_Insurance_Claim_Number;
        txtPrimaryPolicyNumber.Text = objRisk.Primary_Insurance_Policy_Number;
        txtPrimaryPolicyEffectiveDate.Text = clsGeneral.FormatDateToDisplay(objRisk.Primary_Policy_Effective_Date);
        txtPrimaryPolicyExpirationDate.Text = clsGeneral.FormatDateToDisplay(objRisk.Primary_Policy_Expiration_Date);
        txtTotalProgramLimit.Text = clsGeneral.GetStringValue(objRisk.Total_Program_Limit).Replace(".00", "");
        txtPrimaryDeductable.Text = clsGeneral.GetStringValue(objRisk.Primary_Deductable).Replace(".00", "");
        txtAllocation.Text = clsGeneral.GetStringValue(objRisk.Allocation).Replace(".00", "");
        txtDateAllegedWrongfulAct.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Alleged_Wrongful_Act);
        txtDateComplaintReceived.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Complaint_Received);
        txtDateLegalReceivedComplaint.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Legal_Received_Complaint);
        txtDateRiskMgmtReceivedComplaint.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Risk_Management_Received_Complaint);
        txtDateBrokerReceivedComplaint.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Broker_Received_Complaint);
        txtDateCarrierNotified.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Carrier_Notified);
        txtDateAcknowledgementByPrimaryCarrier.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Acknowledgement_Primary_Carrier);
        txtInternalCounsel.Text = objRisk.Internal_Counsel;
        txtTelephone.Text = objRisk.Legal_Telephone;
        rdoPanelCounselRequired.SelectedValue = objRisk.Panel_Counsel_Required;
        txtPrimaryDefenseFileNumber.Text = objRisk.Primary_Defense_File_Number;
        txtSecondaryDefenseFileNumber.Text = objRisk.Secondary_Defense_File_Number;
        txtCourt.Text = objRisk.Court;
        txtJudge.Text = objRisk.Judge_Arbitrator;
        txtLegalStatus.Text = objRisk.Legal_Status;
        txtEstimatedDemandExposure.Text = clsGeneral.GetStringValue(objRisk.Estimated_Demand_Exposure).Replace(".00", "");
        txtEstimatedDefenseExpense.Text = clsGeneral.GetStringValue(objRisk.Estimated_Defense_Expense).Replace(".00", "");
        txtDemandExposureDate.Text = clsGeneral.FormatDateToDisplay(objRisk.Demand_Exposure_Date);
        txtEstimatedDefenseExpenseDate.Text = clsGeneral.FormatDateToDisplay(objRisk.Estimated_Defense_Expense_Date);
        txtActualSettlement.Text = clsGeneral.GetStringValue(objRisk.Actual_Settlement);
        txtActualSettlementDate.Text = clsGeneral.FormatDateToDisplay(objRisk.Actual_Settlement_Date);
        txtActualDefenseExpense.Text = clsGeneral.GetStringValue(objRisk.Actual_Defense_Expense);
        txtActualDefenseExpenseDate.Text = clsGeneral.FormatDateToDisplay(objRisk.Actual_Defense_Expense_Date);
        txtComments.Text = objRisk.Comments;
        txtLegalComplaintRecipient.Text = objRisk.Legal_Complaint_Recipient;
        txtDateHRReceivedComplaint.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_HR_Received_Compliant);
        txtHRComplaintRecipient.Text = objRisk.HR_Complaint_Recipient;

        DataTable dtAllegation = clsExecutive_Risk_Allegation.SelectByFK_Executive_Risk(PK_Executive_Risk).Tables[0];
        if (dtAllegation != null && dtAllegation.Rows.Count > 0)
        {
            for (int i = 0; i < dtAllegation.Rows.Count; i++)
            {
                ListItem lst;
                lst = lstFK_Type_Of_ER_Allegation.Items.FindByValue(dtAllegation.Rows[i]["FK_Type_Of_ER_Allegation"].ToString());
                if (lst != null)
                    lst.Selected = true;
            }
        }

        if (!bAddTo)
        {
            // bind grids
            BindGrids();
        }
        // set Primarykey = 0 if required for AddTo
        if (bAddTo)
        {
            PK_Executive_Risk = 0;
            clsSession.Current_Executive_Risk_ID = 0;
        }
    }

    /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        ComboHelper.FillType_Of_ER_Allegation(new ListBox[] { lstFK_Type_Of_ER_AllegationView }, true);
        // show view div
        dvView.Style["Display"] = "block";
        // don't show div edit in viewmode.
        dvEdit.Style["Display"] = "None";
        dvSave.Style["Display"] = "None";
        // hide back button
        btnBack.Visible = UserAccessType != AccessType.Executive_Risk_View;
        btnAuditView.Visible = true;
        btnBackToSearch.Visible = true;
        // create object for the executive risk record
        Executive_Risk objRisk = new Executive_Risk(PK_Executive_Risk);
        // set the values 
        lblClaimNumberView.Text = objRisk.Claim_Number;
        //lblEntity.Text = new Entity(objRisk.FK_Entity).Description;
        LU_Location objLocation = new LU_Location(objRisk.FK_Entity);

        lblSonicLocationCode.Text = objLocation.Sonic_Location_Code + "-" + objLocation.dba;
        lblLegalEntity.Text = objLocation.legal_entity;
        lblLocationDBA.Text = objLocation.dba;
        lblEntity.Text = "SLC:" + objLocation.Sonic_Location_Code.ToString().Trim() + "|RMLC:" + objLocation.RM_Location_Number;
        lblTypeOfClaim.Text = new Type_Of_ER_Claim(objRisk.FK_Type_Of_ER_Claim).Fld_Desc;
        if (lblTypeOfClaim.Text == "Other") lblOtherClaimType.Text = objRisk.Claim_Type_Other;
        //lblTypeOfAllegation.Text = new Type_Of_ER_Allegation(objRisk.FK_Type_Of_ER_Allegation).Fld_Desc;
        lblLegalFileNumber.Text = objRisk.Legal_File_Number;
        lblComplaintant.Text = objRisk.Complainant_Plaintiff;
        lblDefendant.Text = objRisk.Defendant;
        lblClaimDescription.Text = objRisk.Claim_Description;
        lblDateClaimOpened.Text = clsGeneral.FormatDateToDisplay(objRisk.Claim_Open_Date);
        lblDateClaimClosed.Text = clsGeneral.FormatDateToDisplay(objRisk.Claim_Close_Date);
        lblDateClaimReopened.Text = clsGeneral.FormatDateToDisplay(objRisk.Claim_Reopen_Date);
        lblBordereauReport.Text = objRisk.Bordereau_Report == "Y" ? "YES" : "NO";
        lblClaimStatus.Text = objRisk.Claim_Status_Comments;
        lblEEOC.Text = objRisk.EEOC == "Y" ? "YES" : "NO";
        lblStateEmploymentComission.Text = objRisk.State_Employment_Commission;
        lblLetterReceived.Text = objRisk.Representation_Letter_Received == "Y" ? "YES" : "NO";
        lblDateLetterReceived.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Representation_Letter_Received);
        lblSecurityLitigation.Text = objRisk.Security_Litigation == "Y" ? "YES" : "NO";
        lblOtherLitigation.Text = objRisk.Other_Litigation == "Y" ? "YES" : "NO";
        lblJuridiction.Text = objRisk.Jurisdiction;
        lblDateComplaintFiled.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Complaint_Suit_Filed);
        lblDateSuitServed.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Suite_Served);
        lblCaseNumber.Text = objRisk.Case_Number;
        lblPrimaryClaimNumber.Text = objRisk.Primary_Insurance_Claim_Number;
        lblPrimaryPolicyNumber.Text = objRisk.Primary_Insurance_Policy_Number;
        lblPrimaryPolicyEffectiveDate.Text = clsGeneral.FormatDateToDisplay(objRisk.Primary_Policy_Effective_Date);
        lblPrimaryPolicyExpirationDate.Text = clsGeneral.FormatDateToDisplay(objRisk.Primary_Policy_Expiration_Date);
        lblTotalProgramLimit.Text = clsGeneral.GetStringValue(objRisk.Total_Program_Limit).Replace(".00", "");
        lblPrimaryDeductable.Text = clsGeneral.GetStringValue(objRisk.Primary_Deductable).Replace(".00", "");
        lblAllocation.Text = clsGeneral.GetStringValue(objRisk.Allocation).Replace(".00", "");
        lblDateAllegedWrongfulAct.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Alleged_Wrongful_Act);
        lblDateComplaintReceived.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Complaint_Received);
        lblDateLegalReceivedComplaint.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Legal_Received_Complaint);
        lblDateRiskMgmtReceivedComplaint.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Risk_Management_Received_Complaint);
        lblDateBrokerReceivedComplaint.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Broker_Received_Complaint);
        lblDateCarrierNotified.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Carrier_Notified);
        lblDateAcknowledgementByPrimaryCarrier.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_Acknowledgement_Primary_Carrier);
        lblInternalCounsel.Text = objRisk.Internal_Counsel;
        lblTelephone.Text = objRisk.Legal_Telephone;
        lblPanelCounselRequired.Text = objRisk.Panel_Counsel_Required == "Y" ? "YES" : "NO";
        lblPrimaryDefenseFileNumber.Text = objRisk.Primary_Defense_File_Number;
        lblSecondaryDefenseFileNumber.Text = objRisk.Secondary_Defense_File_Number;
        lblCourt.Text = objRisk.Court;
        lblJudge.Text = objRisk.Judge_Arbitrator;
        lblLegalStatus.Text = objRisk.Legal_Status;
        lblEstimatedDemandExposure.Text = clsGeneral.GetStringValue(objRisk.Estimated_Demand_Exposure).Replace(".00", "");
        lblEstimatedDefenseExpense.Text = clsGeneral.GetStringValue(objRisk.Estimated_Defense_Expense).Replace(".00", "");
        lblDemandExposureDate.Text = clsGeneral.FormatDateToDisplay(objRisk.Demand_Exposure_Date);
        lblEstimatedDefenseExpenseDate.Text = clsGeneral.FormatDateToDisplay(objRisk.Estimated_Defense_Expense_Date);
        lblActualSettlement.Text = clsGeneral.GetStringValue(objRisk.Actual_Settlement);
        lblActualSettlementDate.Text = clsGeneral.FormatDateToDisplay(objRisk.Actual_Settlement_Date);
        lblActualDefenseExpense.Text = clsGeneral.GetStringValue(objRisk.Actual_Defense_Expense);
        lblActualDefenseExpenseDate.Text = clsGeneral.FormatDateToDisplay(objRisk.Actual_Defense_Expense_Date);
        lblComments.Text = objRisk.Comments;
        lblLegalComplaintRecipient.Text = objRisk.Legal_Complaint_Recipient;
        lblDateHRReceivedComplaint.Text = clsGeneral.FormatDateToDisplay(objRisk.Date_HR_Received_Compliant);
        lblHRComplaintRecipient.Text = objRisk.HR_Complaint_Recipient;

        DataTable dtAllegation = clsExecutive_Risk_Allegation.SelectByFK_Executive_Risk(PK_Executive_Risk).Tables[0];
        if (dtAllegation != null && dtAllegation.Rows.Count > 0)
        {
            for (int i = 0; i < dtAllegation.Rows.Count; i++)
            {
                ListItem lst;
                lst = lstFK_Type_Of_ER_AllegationView.Items.FindByValue(dtAllegation.Rows[i]["FK_Type_Of_ER_Allegation"].ToString());
                if (lst != null)
                    lst.Selected = true;
            }
        }
        
        // bind grids
        BindGrids();
        //lnkContactAddView.Style["display"] = Module_Access_Mode == AccessType.Administrative_Access ? "block" : "none";
        lnkContactAdd.Style["display"] = "none";
        //lnkInvestigatorNotesAddView.Style["display"] = Module_Access_Mode == AccessType.Administrative_Access ? "block" : "none";
        lnkInvestigatorNotesAdd.Style["display"] = "none";
    }

    #endregion

    #region "Save"

    /// <summary>
    /// Saves the data
    /// </summary>
    private void SaveData()
    {
        if (Page.IsValid)
        {
            // create object for the executive risk record
            Executive_Risk objRisk = new Executive_Risk(PK_Executive_Risk);

            // get the values from the page controls
            objRisk.Claim_Number = lblClaimNumber.Text;
            if (drpTypeOfClaim.SelectedItem.Text == "Other") objRisk.Claim_Type_Other = txtOtherClaimType.Text.Trim();
            //objRisk.FK_Type_Of_ER_Allegation = drpTypeOfAllegation.SelectedIndex > 0 ? Convert.ToDecimal(drpTypeOfAllegation.SelectedValue) : -1;
            objRisk.Legal_File_Number = txtLegalFileNumber.Text.Trim();
            objRisk.FK_Entity = Convert.ToDecimal(ddlEntity.SelectedValue);            
            objRisk.FK_Type_Of_ER_Claim = Convert.ToDecimal(drpTypeOfClaim.SelectedValue);
            objRisk.Complainant_Plaintiff = txtComplaintant.Text.Trim();
            objRisk.Defendant = txtDefendant.Text.Trim();
            objRisk.Claim_Description = txtClaimDescription.Text.Trim();
            objRisk.Claim_Open_Date = clsGeneral.FormatDateToStore(txtDateClaimOpened);
            objRisk.Claim_Close_Date = clsGeneral.FormatDateToStore(txtDateClaimClosed);
            objRisk.Claim_Reopen_Date = clsGeneral.FormatDateToStore(txtDateClaimReopened);
            objRisk.Bordereau_Report = rdoBordereauReport.SelectedValue;
            objRisk.Claim_Status_Comments = txtClaimStatus.Text.Trim();
            objRisk.EEOC = rdoEEOC.SelectedValue;
            objRisk.State_Employment_Commission = txtStateEmploymentComission.Text.Trim();
            objRisk.Representation_Letter_Received = rdoLetterReceived.SelectedValue;
            objRisk.Date_Representation_Letter_Received = clsGeneral.FormatDateToStore(txtDateLetterReceived);
            objRisk.Security_Litigation = rdoSecurityLitigation.SelectedValue;
            objRisk.Other_Litigation = rdoOtherLitigation.SelectedValue;
            objRisk.Jurisdiction = txtJuridiction.Text.Trim();
            objRisk.Date_Complaint_Suit_Filed = clsGeneral.FormatDateToStore(txtDateComplaintFiled);
            objRisk.Date_Suite_Served = clsGeneral.FormatDateToStore(txtDateSuitServed);
            objRisk.Case_Number = txtCaseNumber.Text.Trim();
            objRisk.Primary_Insurance_Claim_Number = txtPrimaryClaimNumber.Text.Trim();
            objRisk.Primary_Insurance_Policy_Number = txtPrimaryPolicyNumber.Text.Trim();
            objRisk.Primary_Policy_Effective_Date = clsGeneral.FormatDateToStore(txtPrimaryPolicyEffectiveDate);
            objRisk.Primary_Policy_Expiration_Date = clsGeneral.FormatDateToStore(txtPrimaryPolicyExpirationDate);
            objRisk.Total_Program_Limit = clsGeneral.GetDecimalValue(txtTotalProgramLimit);
            objRisk.Primary_Deductable = clsGeneral.GetDecimalValue(txtPrimaryDeductable);
            objRisk.Allocation = clsGeneral.GetDecimalValue(txtAllocation);
            objRisk.Date_Alleged_Wrongful_Act = clsGeneral.FormatDateToStore(txtDateAllegedWrongfulAct);
            objRisk.Date_Complaint_Received = clsGeneral.FormatDateToStore(txtDateComplaintReceived);
            objRisk.Date_Legal_Received_Complaint = clsGeneral.FormatDateToStore(txtDateLegalReceivedComplaint);
            objRisk.Date_Risk_Management_Received_Complaint = clsGeneral.FormatDateToStore(txtDateRiskMgmtReceivedComplaint);
            objRisk.Date_Broker_Received_Complaint = clsGeneral.FormatDateToStore(txtDateBrokerReceivedComplaint);
            objRisk.Date_Carrier_Notified = clsGeneral.FormatDateToStore(txtDateCarrierNotified);
            objRisk.Date_Acknowledgement_Primary_Carrier = clsGeneral.FormatDateToStore(txtDateAcknowledgementByPrimaryCarrier);
            objRisk.Internal_Counsel = txtInternalCounsel.Text.Trim();
            objRisk.Legal_Telephone = txtTelephone.Text.Trim();
            objRisk.Panel_Counsel_Required = rdoPanelCounselRequired.SelectedValue;
            objRisk.Primary_Defense_File_Number = txtPrimaryDefenseFileNumber.Text.Trim();
            objRisk.Secondary_Defense_File_Number = txtSecondaryDefenseFileNumber.Text.Trim();
            objRisk.Court = txtCourt.Text.Trim();
            objRisk.Judge_Arbitrator = txtJudge.Text.Trim();
            objRisk.Legal_Status = txtLegalStatus.Text.Trim();
            objRisk.Estimated_Demand_Exposure = clsGeneral.GetDecimalValue(txtEstimatedDemandExposure);
            objRisk.Estimated_Defense_Expense = clsGeneral.GetDecimalValue(txtEstimatedDefenseExpense);
            objRisk.Demand_Exposure_Date = clsGeneral.FormatDateToStore(txtDemandExposureDate);
            objRisk.Estimated_Defense_Expense = clsGeneral.GetDecimalValue(txtEstimatedDefenseExpense);
            objRisk.Estimated_Defense_Expense_Date = clsGeneral.FormatDateToStore(txtEstimatedDefenseExpenseDate);
            objRisk.Actual_Settlement = clsGeneral.GetDecimalValue(txtActualSettlement);
            objRisk.Actual_Settlement_Date = clsGeneral.FormatDateToStore(txtActualSettlementDate);
            objRisk.Actual_Defense_Expense = clsGeneral.GetDecimalValue(txtActualDefenseExpense);
            objRisk.Actual_Defense_Expense_Date = clsGeneral.FormatDateToStore(txtActualDefenseExpenseDate);
            objRisk.Comments = txtComments.Text.Trim();
            objRisk.Update_Date = DateTime.Now;
            objRisk.Updated_By = clsSession.UserID;
            objRisk.Legal_Complaint_Recipient = txtLegalComplaintRecipient.Text.Trim();
            objRisk.Date_HR_Received_Compliant = clsGeneral.FormatDateToStore(txtDateHRReceivedComplaint);
            objRisk.HR_Complaint_Recipient = txtHRComplaintRecipient.Text.Trim();

            // update or insert the data according to the primary key
            if (PK_Executive_Risk > 0)
                objRisk.Update();
            else
                PK_Executive_Risk = objRisk.Insert();

            clsExecutive_Risk_Allegation.DeleteByFK_Executive_Risk(PK_Executive_Risk);

            for (int i = 0; i < lstFK_Type_Of_ER_Allegation.Items.Count; i++)
            {
                if (lstFK_Type_Of_ER_Allegation.Items[i].Selected == true)
                {
                    clsExecutive_Risk_Allegation objExecutive_Risk_Allegation = new clsExecutive_Risk_Allegation();
                    objExecutive_Risk_Allegation.FK_Executive_Risk = PK_Executive_Risk;
                    objExecutive_Risk_Allegation.FK_Type_Of_ER_Allegation = Convert.ToDecimal(lstFK_Type_Of_ER_Allegation.Items[i].Value);
                    objExecutive_Risk_Allegation.Insert();
                }
            }



            clsSession.Current_Executive_Risk_ID = PK_Executive_Risk;
            // add attachment if any.
            Attachment.Add(clsGeneral.Tables.Executive_Risk, PK_Executive_Risk);

            // insert the same record in Liability_claim record.
            RIMS_Base.Biz.CLiabilityClaim_FCI objliability = new RIMS_Base.Biz.CLiabilityClaim_FCI();
            if (!bAddTo)
            {
                if (ViewState["PK_Liability_Claim"] != null && ViewState["PK_Liability_Claim"].ToString() != String.Empty)
                {
                    objliability.PK_Liability_Claim = Convert.ToInt32(ViewState["PK_Liability_Claim"].ToString());
                }
            }

            //Claim Identification          
            objliability.Claim_Number = lblClaimNumber.Text;
            objliability.FK_Entity = Convert.ToDecimal(ddlEntity.SelectedValue);
            objliability.FK_Liability_Major_Claim_Type = 4;
            objliability.Date_Of_Loss = clsGeneral.FormatDateToStore(txtDateClaimOpened);
            //objliability.ADDTO = "AddTo";
            int m_intRetval = objliability.InsertUpdate_PropertyClaim(objliability);
            ViewState["PK_Liability_Claim"] = m_intRetval.ToString();
            Session["WorkerCompID"] = ViewState["PK_Liability_Claim"].ToString();

        }
    }

    /// <summary>
    /// Handles the save and view button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        //save data
        SaveData();
        // update the session variable for operation for view
        clsSession.Str_Executive_Operation = "view";
        // open the page in view mode
        Response.Redirect("ExecutiveRisk.aspx?id=" + PK_Executive_Risk);
    }

    #endregion

    #region "Attachments Management"

    /// <summary>
    /// Binds the attachment details
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["Display"] = "block";
        AttachDetails.Bind();
    }

    /// <summary>
    /// Handles Add Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        if (PK_Executive_Risk > 0)
        {
            // add the attachment 
            Attachment.Add(clsGeneral.Tables.Executive_Risk, PK_Executive_Risk);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(11);", true);
        }
    }

    /// <summary>
    /// Upload File
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {
        if (PK_Executive_Risk > 0)
        {
            // add the attachment 
            Attachment.Add(clsGeneral.Tables.Executive_Risk, PK_Executive_Risk);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(11);", true);
        }
    }

    #endregion

    #region "Other controls events"

    /// <summary>
    /// Handles Back button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // set the session operation as edit and redirect to the same page 
        // so page is in edit mode
        clsSession.Str_Executive_Operation = "edit";
        Response.Redirect("ExecutiveRisk.aspx?id=" + PK_Executive_Risk);
    }

    /// <summary>
    /// Handles carrier grid add link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCarrierAdd_Click(object sender, EventArgs e)
    {
        // saves data
        SaveData();
        clsSession.Str_Executive_Operation = "edit";
        //redirect to Executive risk carrier page
        Response.Redirect(AppConfig.SiteURL + "ExecutiveRisk/ExecutiveRiskCarrier.aspx?eid=" + PK_Executive_Risk);
    }

    /// <summary>
    /// Handles Contact Grid add link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkContactAdd_Click(object sender, EventArgs e)
    {
        // saves data
        SaveData();
        clsSession.Str_Executive_Operation = "edit";
        //redirect to Executive risk carrier page
        Response.Redirect(AppConfig.SiteURL + "ExecutiveRisk/ContactInfo.aspx?eid=" + PK_Executive_Risk);
    }

    /// <summary>
    /// Handles Defense Attorney grid add link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkDefenseAttorneyAdd_Click(object sender, EventArgs e)
    {
        // saves data
        SaveData();
        clsSession.Str_Executive_Operation = "edit";
        //redirect to Executive risk carrier page
        Response.Redirect(AppConfig.SiteURL + "ExecutiveRisk/DefenseAttorney.aspx?eid=" + PK_Executive_Risk);
    }

    /// <summary>
    /// Handles Plaintiff Attorney grid add link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkPlaintiffAttorneyAdd_Click(object sender, EventArgs e)
    {
        // saves data
        SaveData();
        clsSession.Str_Executive_Operation = "edit";
        //redirect to Executive risk carrier page
        Response.Redirect(AppConfig.SiteURL + "ExecutiveRisk/PlaintiffAttorney.aspx?eid=" + PK_Executive_Risk);
    }

    /// <summary>
    /// Handles Expense Grid Add link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExpenseAdd_Click(object sender, EventArgs e)
    {
        // saves data
        SaveData();
        clsSession.Str_Executive_Operation = "edit";
        //redirect to Executive risk carrier page
        Response.Redirect(AppConfig.SiteURL + "ExecutiveRisk/ExecutiveRiskExpenses.aspx?eid=" + PK_Executive_Risk);
    }

    /// <summary>
    /// Handles Investigator Notes add link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkInvestigatorNotesAdd_Click(object sender, EventArgs e)
    {
        // saves data
        SaveData();
        clsSession.Str_Executive_Operation = "edit";
        //redirect to Executive risk carrier page
        Response.Redirect(AppConfig.SiteURL + "ExecutiveRisk/InvestigatorNotes.aspx?eid=" + PK_Executive_Risk);
    }

    /// <summary>
    /// Button Click Event - Next button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNextStep_Click(object sender, EventArgs e)
    {
        if (Session["ViewAll"] != null)
            Response.Redirect("MainDiary.aspx");
        else
        {
            // save data
            SaveData();
            clsSession.Str_Executive_Operation = "edit";
            // redirect to contact page after saving the data        
            if (PK_Executive_Risk > 0)
            {
                Response.Redirect("MainDiary.aspx");
            }
        }
    }

    /// <summary>
    /// BUtton CLick Event - next Step in view mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNextStepView_Click(object sender, EventArgs e)
    {
        Response.Redirect("MainDiary.aspx");
    }

    /// <summary>
    /// Button Click Event - back to Seach
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBackToSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeSearch.aspx?p=result");
    }

    /// <summary>
    /// Dropdown legal Entity Selected Index change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlLegalEntity_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to entity selected
        ddlRMLocationNumber.SelectedValue = ddlLegalEntity.SelectedValue;
        ddlLocationdba.SelectedValue = ddlLegalEntity.SelectedValue;
        ddlEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
        //SetEntity(Convert.ToDecimal(ddlLegalEntity.SelectedValue));
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "ShowPanel(1);", true);
    }

    /// <summary>
    /// Drodown Liast Location DBa selected index change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlLocationdba_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to dba selected
        ddlRMLocationNumber.SelectedValue = ddlLocationdba.SelectedValue;
        ddlLegalEntity.SelectedValue = ddlLocationdba.SelectedValue;
        ddlEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
        //SetEntity(Convert.ToDecimal(ddlLegalEntity.SelectedValue));
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "ShowPanel(1);", true);
    }

    /// <summary>
    /// Dropdown RM location Number Selected index change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRMLocationNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to RM location number selected
        ddlLegalEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
        ddlLocationdba.SelectedValue = ddlRMLocationNumber.SelectedValue;
        ListItem lstItm = ddlEntity.Items.FindByValue(ddlLocationdba.SelectedValue);
        if (lstItm != null)
            ddlEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
        else
            ddlEntity.SelectedValue = "0";
        // SetEntity(Convert.ToDecimal(ddlLegalEntity.SelectedValue));
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "ShowPanel(1);", true);
    }

    /// <summary>
    /// Dropdown Entity Selected index change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlEntity_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to dba selected
        ddlRMLocationNumber.SelectedValue = ddlEntity.SelectedValue;
        ddlLegalEntity.SelectedValue = ddlEntity.SelectedValue;
        ddlLocationdba.SelectedValue = ddlEntity.SelectedValue;

        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "ShowPanel(1);", true);
    }

    #endregion

    #region "Other Methods"

    /// <summary>
    /// Binds all grids in page
    /// </summary>
    private void BindGrids()
    {
        BindCarrierGrid();
        BindDefenseGrid();
        BindPlaintiffGrid();
        BindExpensesGrid();
        BindContactsGrid();
        BindNotesGrid();
    }

    /// <summary>
    /// Binds the carrier grid
    /// </summary>
    private void BindCarrierGrid()
    {
        // get the carrier records as per the executive risk primary key
        DataTable dtCarrier = Executive_Risk_Carrier.SelectByFK_Executive_Risk(PK_Executive_Risk).Tables[0];

        // check for the operation and bind the grid accordingly
        if (StrOperation == "view")
        {
            gvCarrierView.DataSource = dtCarrier;
            gvCarrierView.DataBind();
            lnkCarrierAdd.Visible = false;
        }
        else
        {
            gvCarrier.DataSource = dtCarrier;
            gvCarrier.DataBind();
        }

    }

    /// <summary>
    /// Binds the defense grid
    /// </summary>
    private void BindDefenseGrid()
    {
        // get the defense attorney records as per the executive risk primary key 
        DataTable dtDefense = Defense_Attorney.SelectByFK_Executive_Risk(PK_Executive_Risk).Tables[0];

        // check for the operation and bind the grid accordingly
        if (StrOperation == "view")
        {
            gvDefenseAttorneyView.DataSource = dtDefense;
            gvDefenseAttorneyView.DataBind();
            lnkExpenseAdd.Visible = false;
        }
        else
        {
            gvDefenseAttorney.DataSource = dtDefense;
            gvDefenseAttorney.DataBind();
        }

    }

    /// <summary>
    /// Binds the plaintiff grid
    /// </summary>
    private void BindPlaintiffGrid()
    {
        // get the plaintiff attorney records as per the executive risk primary key
        DataTable dtAttorney = Plaintiff_Attorney.SelectByFK_Executive_Risk(PK_Executive_Risk).Tables[0];

        // check for the operation and bind the grid accordingly
        if (StrOperation == "view")
        {
            gvPlaintiffAttorneyView.DataSource = dtAttorney;
            gvPlaintiffAttorneyView.DataBind();
            lnkPlaintiffAttorneyAdd.Visible = false;
        }
        else
        {
            gvPlaintiffAttorney.DataSource = dtAttorney;
            gvPlaintiffAttorney.DataBind();
        }

    }

    /// <summary>
    /// Bind the expense grid
    /// </summary>
    private void BindExpensesGrid()
    {
        // get the expense records as per the executive risk primary key
        DataTable dtAttorney = Executive_Risk_Expenses.SelectByFK_Executive_Risk(PK_Executive_Risk).Tables[0];

        // check for the operation and bind the grid accordingly
        if (StrOperation == "view")
        {
            gvExpenseView.DataSource = dtAttorney;
            gvExpenseView.DataBind();
            lnkExpenseAdd.Visible = false;
        }
        else
        {
            gvExpense.DataSource = dtAttorney;
            gvExpense.DataBind();
        }
    }

    /// <summary>
    /// Bind Contact Grid
    /// </summary>
    private void BindContactsGrid()
    {
        DataTable dtContacts = Executive_Risk_Contacts.SelectByFK(PK_Executive_Risk).Tables[0];
        gvContactInfo.DataSource = dtContacts;
        gvContactInfo.DataBind();
        if (StrOperation == "view") gvContactInfo.Columns[3].Visible = false;
        lnkContactAdd.Visible = (StrOperation != "view");

    }

    /// <summary>
    /// Bind Notes grid
    /// </summary>
    private void BindNotesGrid()
    {
        DataTable dtNotes = Investigator_Notes.SelectByFK(PK_Executive_Risk).Tables[0];
        gvInvestigatorNotes.DataSource = dtNotes;
        gvInvestigatorNotes.DataBind();
        if (StrOperation == "view") gvInvestigatorNotes.Columns[3].Visible = false;
        lnkInvestigatorNotesAdd.Visible = (StrOperation != "view");
    }

    /// <summary>
    /// Binds the dropdowns in page
    /// </summary>
    private void BindDropDowns()
    {
        //// Binds the entity dropdown       
        //used to fill RM Location Number Dropdown
        ComboHelper.FillLocationdba(new DropDownList[] { ddlRMLocationNumber }, 0, true);
        ddlRMLocationNumber.Style.Remove("font-size");
        //used to fill Legal Entity Dropdown
        ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, 0, true);
        //used to fill dba Dropdown
        ComboHelper.FillLocationdbaOnly(new DropDownList[] { ddlLocationdba }, 0, true);
        ddlLocationdba.Style.Remove("font-size");
        // Binds the ER Allegation dropdown
        //DataTable dtAllegation = Type_Of_ER_Allegation.SelectAll().Tables[0];
        //drpTypeOfAllegation.DataSource = dtAllegation;
        //drpTypeOfAllegation.DataTextField = "Fld_Desc";
        //drpTypeOfAllegation.DataValueField = "PK_Type_Of_ER_Allegation";
        //drpTypeOfAllegation.DataBind();
        //drpTypeOfAllegation.Items.Insert(0, "--Select Type Of Allegation--");

        ComboHelper.FillType_Of_ER_Allegation(new ListBox[] { lstFK_Type_Of_ER_Allegation, lstFK_Type_Of_ER_AllegationView }, true);

        DataTable dtEntity = Entity.SelectForExecutiveRisk().Tables[0];
        ddlEntity.DataSource = dtEntity;
        ddlEntity.DataTextField = "Entity";
        ddlEntity.DataValueField = "PK_LU_Location_ID";
        ddlEntity.DataBind();
        ddlEntity.Items.Insert(0, new ListItem("--Select Entity--", "0"));

        // Binds the type dropdown
        DataTable dtType = Type_Of_ER_Claim.SelectAll().Tables[0];
        dtType.DefaultView.RowFilter = "Active = 'Y'";
        dtType.DefaultView.Sort = "Fld_Desc ASC";

        drpTypeOfClaim.DataSource = dtType.DefaultView;
        drpTypeOfClaim.DataTextField = "Fld_Desc";
        drpTypeOfClaim.DataValueField = "PK_Type_Of_ER_Claim";
        drpTypeOfClaim.DataBind();
        drpTypeOfClaim.Items.Insert(0, new ListItem("--Select Type of Claim--","0"));
    }

    /// <summary>
    /// set user Rights
    /// </summary>
    /// <returns></returns>
    protected bool SetUserRights()
    {
        try
        {
            m_objRightDetails = new CRolePermission();
            if (Session["UserRoleId"] != null)
            {
                lstRightDetails = m_objRightDetails.GetRights(5, Convert.ToInt32(Session["UserRoleId"].ToString()));
                ViewState["PAdd"] = lstRightDetails[0].PAdd.ToString();

                ViewState["PEdit"] = lstRightDetails[0].PEdit.ToString();
                ViewState["PDelete"] = lstRightDetails[0].PDelete.ToString();
                ViewState["PView"] = lstRightDetails[0].PView.ToString();
                return true;
            }
            else
            {
                Response.Redirect("../Signin.aspx", false);
                return false;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    #endregion

    #region "GridView Events"

    /// <summary>
    /// Grid view Carrier Row command
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCarrier_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveCarrier")
        {
            // delete the carrier record by primary key passed in argument
            Executive_Risk_Carrier.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            // bind the carrier grid
            BindCarrierGrid();

            // show the panel in which the carrier grid exists as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
        }
    }

    /// <summary>
    /// Gridview RowCoammand Event - DefenseAtorney
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDefenseAttorney_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveAttorney")
        {
            // delete the defense attorney record by primary key passed in argument
            Defense_Attorney.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            // bind the grid
            BindDefenseGrid();

            // show the panel in which the defense attorney grid exists as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(8);", true);
        }
    }

    /// <summary>
    /// Gridview Plaintiff Attorney Row Command
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPlaintiffAttorney_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveAttorney")
        {
            // delete the plaintiff attorney record by primary key passed in argument
            Plaintiff_Attorney.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            // bind the plaintiff grid
            BindPlaintiffGrid();

            // show the panel in which the Plaintiff attorney grid exists as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(8);", true);
        }
    }

    /// <summary>
    /// Gridview Expense Row Command
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvExpense_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveExpense")
        {
            // delete the expense record by primary key passed in argument
            Executive_Risk_Expenses.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            // bind the expense grid
            BindExpensesGrid();

            // show the panel in which the expense grid exists as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(10);", true);
        }
    }

    /// <summary>
    /// Gridview Contact Info Row Command
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvContactInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewContact")
        {
            Response.Redirect("ContactInfo.aspx?id=" + e.CommandArgument.ToString() + "&op=" + StrOperation + "&eid=" + PK_Executive_Risk);
        }
        else if (e.CommandName == "RemoveContact")
        {
            Executive_Risk_Contacts.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindContactsGrid();
            // show the panel in which the expense grid exists as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
        }
    }

    /// <summary>
    /// Grid Executivenotes Row Command
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvExecutiveNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewNote")
        {
            Response.Redirect("InvestigatorNotes.aspx?id=" + e.CommandArgument.ToString() + "&op=" + StrOperation + "&eid=" + PK_Executive_Risk);
        }
        else if (e.CommandName == "RemoveNote")
        {
            Investigator_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindNotesGrid();
            // show the panel in which the expense grid exists as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(7);", true);
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

        #region "Claim Identification"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(77).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        Label MenuAsterisk1 = (Label)mnuExecutiveRisk.Controls[0].FindControl("MenuAsterisk");
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Sonic Location Code":
                    strCtrlsIDs += ddlRMLocationNumber.ClientID + ",";
                    strMessages += "Please select [Claim Identification]/Sonic Location Code" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Type Of Claim If Other, please specify":
                    strCtrlsIDs += drpTypeOfClaim.ClientID + ",";
                    strMessages += "Please select [Claim Identification]/Type Of Claim" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Legal Entity":
                    strCtrlsIDs += ddlLegalEntity.ClientID + ",";
                    strMessages += "Please select [Claim Identification]/Legal Entity" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Location d/b/a":
                    strCtrlsIDs += ddlLocationdba.ClientID + ",";
                    strMessages += "Please select [Claim Identification]/Location d/b/a" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Type of Allegation":
                    //strCtrlsIDs += drpTypeOfAllegation.ClientID + ",";
                    strCtrlsIDs += lstFK_Type_Of_ER_Allegation.ClientID + ",";
                    strMessages += "Please select [Claim Identification]/Type of Allegation" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Entity":
                    strCtrlsIDs += ddlEntity.ClientID + ",";
                    strMessages += "Please select [Claim Identification]/Entity" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Legal File Number":
                    strCtrlsIDs += txtLegalFileNumber.ClientID + ",";
                    strMessages += "Please enter [Claim Identification]/Legal File Number" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Complainant/Plaintiff":
                    strCtrlsIDs += txtComplaintant.ClientID + ",";
                    strMessages += "Please enter [Claim Identification]/Complainant/Plaintiff" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Defendant":
                    strCtrlsIDs += txtDefendant.ClientID + ",";
                    strMessages += "Please enter [Claim Identification]/Defendant" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Claim Description":
                    strCtrlsIDs += txtClaimDescription.ClientID + ",";
                    strMessages += "Please enter [Claim Identification]/Claim Description" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Claim Status"
        dtFields = clsScreen_Validators.SelectByScreen(78).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        Label MenuAsterisk2 = (Label)mnuExecutiveRisk.Controls[1].FindControl("MenuAsterisk");
        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date Claim Opened":
                    strCtrlsIDs += txtDateClaimOpened.ClientID + ",";
                    strMessages += "Please enter [Claim Status]/Date Claim Opened" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Date Claim Closed":
                    strCtrlsIDs += txtDateClaimClosed.ClientID + ",";
                    strMessages += "Please enter [Claim Status]/Date Claim Closed" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "Date Claim Reopened":
                    strCtrlsIDs += txtDateClaimReopened.ClientID + ",";
                    strMessages += "Please enter [Claim Status]/Date Claim Reopened" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "Claim Status/Comments":
                    strCtrlsIDs += txtClaimStatus.ClientID + ",";
                    strMessages += "Please enter [Claim Status]/Claim Status/Comments" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Filing"
        dtFields = clsScreen_Validators.SelectByScreen(79).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        Label MenuAsterisk3 = (Label)mnuExecutiveRisk.Controls[2].FindControl("MenuAsterisk");
        MenuAsterisk3.Style["display"] = (dtFields.Select("LeftMenuIndex = 3").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "State Employment Commission":
                    strCtrlsIDs += txtStateEmploymentComission.ClientID + ",";
                    strMessages += "Please enter [Filing]/State Employment Commission" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                case "Date Letter of Representation Received":
                    strCtrlsIDs += txtDateLetterReceived.ClientID + ",";
                    strMessages += "Please enter [Filing]/Date Letter of Representation Received" + ",";
                    Span17.Style["display"] = "inline-block";
                    break;
                case "Jurisdiction":
                    strCtrlsIDs += txtJuridiction.ClientID + ",";
                    strMessages += "Please enter [Filing]/Jurisdiction" + ",";
                    Span18.Style["display"] = "inline-block";
                    break;
                case "Date Complaint/Suit Filed":
                    strCtrlsIDs += txtDateComplaintFiled.ClientID + ",";
                    strMessages += "Please enter [Filing]/Date Complaint/Suit Filed" + ",";
                    Span19.Style["display"] = "inline-block";
                    break;
                case "Date Suit Served":
                    strCtrlsIDs += txtDateSuitServed.ClientID + ",";
                    strMessages += "Please enter [Filing]/Date Suit Served" + ",";
                    Span20.Style["display"] = "inline-block";
                    break;
                case "Case Number":
                    strCtrlsIDs += txtCaseNumber.ClientID + ",";
                    strMessages += "Please enter [Filing]/Case Number" + ",";
                    Span21.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Insurance Profile"
        dtFields = clsScreen_Validators.SelectByScreen(80).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        Label MenuAsterisk4 = (Label)mnuExecutiveRisk.Controls[3].FindControl("MenuAsterisk");
        MenuAsterisk4.Style["display"] = (dtFields.Select("LeftMenuIndex = 4").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Primary Insurance Claim Number":
                    strCtrlsIDs += txtPrimaryClaimNumber.ClientID + ",";
                    strMessages += "Please enter [Insurance Profile]/Primary Insurance Claim Number" + ",";
                    Span22.Style["display"] = "inline-block";
                    break;
                case "Primary Insurance Policy Number":
                    strCtrlsIDs += txtPrimaryPolicyNumber.ClientID + ",";
                    strMessages += "Please enter [Insurance Profile]/Primary Insurance Policy Number" + ",";
                    Span23.Style["display"] = "inline-block";
                    break;
                case "Primary Policy Effective Date":
                    strCtrlsIDs += txtPrimaryPolicyEffectiveDate.ClientID + ",";
                    strMessages += "Please enter [Insurance Profile]/Primary Policy Effective Date" + ",";
                    Span24.Style["display"] = "inline-block";
                    break;
                case "Primary Policy Expiration Date":
                    strCtrlsIDs += txtPrimaryPolicyExpirationDate.ClientID + ",";
                    strMessages += "Please enter [Insurance Profile]/Primary Policy Expiration Date" + ",";
                    Span25.Style["display"] = "inline-block";
                    break;
                case "Total Program Limit":
                    strCtrlsIDs += txtTotalProgramLimit.ClientID + ",";
                    strMessages += "Please enter [Insurance Profile]/Total Program Limit" + ",";
                    Span26.Style["display"] = "inline-block";
                    break;
                case "Primary Deductable":
                    strCtrlsIDs += txtPrimaryDeductable.ClientID + ",";
                    strMessages += "Please enter [Insurance Profile]/Primary Deductable" + ",";
                    Span27.Style["display"] = "inline-block";
                    break;
                case "Allocation":
                    strCtrlsIDs += txtAllocation.ClientID + ",";
                    strMessages += "Please enter [Insurance Profile]/Allocation" + ",";
                    Span28.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Key Dates"
        dtFields = clsScreen_Validators.SelectByScreen(81).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        Label MenuAsterisk5 = (Label)mnuExecutiveRisk.Controls[4].FindControl("MenuAsterisk");
        MenuAsterisk5.Style["display"] = (dtFields.Select("LeftMenuIndex = 5").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date of Alleged Wrongful Act":
                    strCtrlsIDs += txtDateAllegedWrongfulAct.ClientID + ",";
                    strMessages += "Please enter [Key Dates]/Date of Alleged Wrongful Act" + ",";
                    Span29.Style["display"] = "inline-block";
                    break;
                case "Date Complaint Received":
                    strCtrlsIDs += txtDateComplaintReceived.ClientID + ",";
                    strMessages += "Please enter [Key Dates]/Date Complaint Received" + ",";
                    Span30.Style["display"] = "inline-block";
                    break;
                case "Date Legal Received Complaint":
                    strCtrlsIDs += txtDateLegalReceivedComplaint.ClientID + ",";
                    strMessages += "Please enter [Key Dates]/Date Legal Received Complaint" + ",";
                    Span31.Style["display"] = "inline-block";
                    break;
                case "Date Risk Management Received Complaint":
                    strCtrlsIDs += txtDateRiskMgmtReceivedComplaint.ClientID + ",";
                    strMessages += "Please enter [Key Dates]/Date Risk Management Received Complaint" + ",";
                    Span32.Style["display"] = "inline-block";
                    break;
                case "Person Who Received Complaint in Legal":
                    strCtrlsIDs += txtLegalComplaintRecipient.ClientID + ",";
                    strMessages += "Please enter [Key Dates]/Person Who Received Complaint in Legal" + ",";
                    Span33.Style["display"] = "inline-block";
                    break;
                case "Date Carrier(s) Notified":
                    strCtrlsIDs += txtDateCarrierNotified.ClientID + ",";
                    strMessages += "Please enter [Key Dates]/Date Carrier(s) Notified" + ",";
                    Span34.Style["display"] = "inline-block";
                    break;
                case "Date Broker Received Complaint":
                    strCtrlsIDs += txtDateBrokerReceivedComplaint.ClientID + ",";
                    strMessages += "Please enter [Key Dates]/Date Broker Received Complaint" + ",";
                    Span35.Style["display"] = "inline-block";
                    break;
                case "Date HR Received Complaint":
                    strCtrlsIDs += txtDateHRReceivedComplaint.ClientID + ",";
                    strMessages += "Please enter [Key Dates]/Date HR Received Complaint" + ",";
                    Span36.Style["display"] = "inline-block";
                    break;
                case "Date Acknowledgement By Primary Carrier":
                    strCtrlsIDs += txtDateAcknowledgementByPrimaryCarrier.ClientID + ",";
                    strMessages += "Please enter [Key Dates]/Date Acknowledgement By Primary Carrier" + ",";
                    Span37.Style["display"] = "inline-block";
                    break;
                case "Person Who Received Compliant in HR":
                    strCtrlsIDs += txtHRComplaintRecipient.ClientID + ",";
                    strMessages += "Please enter [Key Dates]/Person Who Received Compliant in HR" + ",";
                    Span38.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Legal"
        dtFields = clsScreen_Validators.SelectByScreen(84).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        Label MenuAsterisk8 = (Label)mnuExecutiveRisk.Controls[7].FindControl("MenuAsterisk");
        MenuAsterisk8.Style["display"] = (dtFields.Select("LeftMenuIndex = 8").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Internal Counsel":
                    strCtrlsIDs += txtInternalCounsel.ClientID + ",";
                    strMessages += "Please enter [Legal]/Internal Counsel" + ",";
                    Span39.Style["display"] = "inline-block";
                    break;
                case "Telephone":
                    strCtrlsIDs += txtTelephone.ClientID + ",";
                    strMessages += "Please enter [Legal]/Telephone" + ",";
                    Span40.Style["display"] = "inline-block";
                    break;
                case "Primary Defense File Number":
                    strCtrlsIDs += txtPrimaryDefenseFileNumber.ClientID + ",";
                    strMessages += "Please enter [Legal]/Primary Defense File Number" + ",";
                    Span41.Style["display"] = "inline-block";
                    break;
                case "Secondary Defense File Number":
                    strCtrlsIDs += txtSecondaryDefenseFileNumber.ClientID + ",";
                    strMessages += "Please enter [Legal]/Secondary Defense File Number" + ",";
                    Span42.Style["display"] = "inline-block";
                    break;
                case "Court":
                    strCtrlsIDs += txtCourt.ClientID + ",";
                    strMessages += "Please enter [Legal]/Court" + ",";
                    Span43.Style["display"] = "inline-block";
                    break;
                case "Judge/Arbitrator":
                    strCtrlsIDs += txtJudge.ClientID + ",";
                    strMessages += "Please enter [Legal]/Judge/Arbitrator" + ",";
                    Span44.Style["display"] = "inline-block";
                    break;
                case "Legal Status":
                    strCtrlsIDs += txtLegalStatus.ClientID + ",";
                    strMessages += "Please enter [Legal]/Legal Status" + ",";
                    Span45.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Exposure Analysis"
        dtFields = clsScreen_Validators.SelectByScreen(85).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        Label MenuAsterisk9 = (Label)mnuExecutiveRisk.Controls[8].FindControl("MenuAsterisk");
        MenuAsterisk9.Style["display"] = (dtFields.Select("LeftMenuIndex = 9").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Estimated Demand Exposure": strCtrlsIDs += txtEstimatedDemandExposure.ClientID + ","; strMessages += "Please enter [Exposure Analysis]/Estimated Demand Exposure" + ","; Span46.Style["display"] = "inline-block"; break;
                case "Demand Exposure Date": strCtrlsIDs += txtDemandExposureDate.ClientID + ","; strMessages += "Please enter [Exposure Analysis]/Demand Exposure Date" + ","; Span47.Style["display"] = "inline-block"; break;
                case "Estimated Defense Expense": strCtrlsIDs += txtEstimatedDefenseExpense.ClientID + ","; strMessages += "Please enter [Exposure Analysis]/Estimated Defense Expense" + ","; Span48.Style["display"] = "inline-block"; break;
                case "Estimated Defense Expense Date": strCtrlsIDs += txtEstimatedDefenseExpenseDate.ClientID + ","; strMessages += "Please enter [Exposure Analysis]/Estimated Defense Expense Date" + ","; Span49.Style["display"] = "inline-block"; break;
                case "Actual Settlement": strCtrlsIDs += txtActualSettlement.ClientID + ","; strMessages += "Please enter [Exposure Analysis]/Actual Settlement" + ","; Span50.Style["display"] = "inline-block"; break;
                case "Actual Settlement Date": strCtrlsIDs += txtActualSettlementDate.ClientID + ","; strMessages += "Please enter [Exposure Analysis]/Actual Settlement Date" + ","; Span51.Style["display"] = "inline-block"; break;
                case "Actual Defense Expense": strCtrlsIDs += txtActualDefenseExpense.ClientID + ","; strMessages += "Please enter [Exposure Analysis]/Actual Defense Expense" + ","; Span52.Style["display"] = "inline-block"; break;
                case "Actual Defense Expense Date": strCtrlsIDs += txtActualDefenseExpenseDate.ClientID + ","; strMessages += "Please enter [Exposure Analysis]/Actual Defense Expense Date" + ","; Span53.Style["display"] = "inline-block"; break;
                case "Comments": strCtrlsIDs += txtComments.ClientID + ","; strMessages += "Please enter [Exposure Analysis]/Comments" + ","; Span54.Style["display"] = "inline-block"; break;
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
