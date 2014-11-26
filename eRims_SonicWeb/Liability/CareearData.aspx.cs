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
using System.Collections.Generic;
using System.IO;

public partial class Liability_CareearData : System.Web.UI.Page
{
    #region public variable

    public RIMS_Base.Biz.CCheckWriting m_objClaimReservesInfo;
    List<RIMS_Base.CCheckWriting> lstClaimReservesInfo = null;
    List<RIMS_Base.CCarrier> lstBaseCarrier;
    public RIMS_Base.Biz.CGeneral objGeneral;
    public RIMS_Base.Biz.CCarrier objCarrier;
    int intRetval = -1;

    // -- Attachment
    public string m_strCustomFileName = string.Empty;
    public string m_strFileName = string.Empty;
    public string m_strGlobalPath = string.Empty;
    public string m_strPath = string.Empty;
    public string m_strFolderName = "Liability_Carrier";
    public RIMS_Base.Biz.CAttachment m_objAttachment;
    List<RIMS_Base.CAttachment> lstAttachment = null;
    RIMS_Base.Biz.CLiabilityClaim objLiability;
    List<RIMS_Base.CLiabilityClaim> lstLiability;
    int Attach_Retval = -1;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserRoleId"] != null)
        {
            m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/" + m_strFolderName + "/");
            if (!IsPostBack)
            {
                btnRemove.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAttachmentDetails','Delete');");

                ViewState.Clear();
                //dispTagName.Value = "";
                // Session["WorkerCompID"] = "43";
                BindCombos();

                btnRemove.Visible = false;
                btnMail.Visible = false;
                //btnViewMail.Visible = false;
                gvAttachmentDetails.DataSource = lstAttachment;
                gvAttachmentDetails.DataBind();


                if (Session["WorkerCompID"] != null && Session["WorkerCompID"].ToString() != String.Empty)
                {

                    objLiability = new RIMS_Base.Biz.CLiabilityClaim();
                    lstLiability = new List<RIMS_Base.CLiabilityClaim>();
                    try
                    {
                        lstLiability = objLiability.Getility_ClaimByID(Convert.ToInt32(Session["WorkerCompID"].ToString()));
                        string Claim_No = lstLiability[0].Claim_Number;
                        DisplayEmployeeInfo(Claim_No);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        objLiability = null;
                        lstLiability = null;
                    }

                    //ViewAllFromSearchGrid();
                    if (Session["ViewAll"] != null && Session["ViewAll"].ToString() != String.Empty)
                    {
                        //DisplayDynamicLabelsForViewALL();
                        ViewAllFromSearchGrid();
                    }
                    else
                    {
                       // DisplayDynamicLabels();
                        RetriveDataByID(Convert.ToDecimal(Session["WorkerCompID"].ToString()));
                    }
                }
                else
                {
                    //DisplayDynamicLabels();
                }
            }
        }
        else
        {
            Response.Redirect("../Signin.aspx", false);
        }
    }
    private void DisplayEmployeeInfo(string claimNO)
    {
        m_objClaimReservesInfo = new RIMS_Base.Biz.CCheckWriting();
        lstClaimReservesInfo = new List<RIMS_Base.CCheckWriting>();
        lstClaimReservesInfo = m_objClaimReservesInfo.GetClaimInfoByClaimNo(claimNO);
        lblClaimNo.Text = lstClaimReservesInfo[0].Claim_Number.ToString();
        ViewState["TableName"] = lstClaimReservesInfo[0].TableName.ToString();
        ViewState["TableFK"] = lstClaimReservesInfo[0].TableFK.ToString();
        if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
            rbtnEmployee.Items[0].Selected = true;
        else if (lstClaimReservesInfo[0].Employee.ToUpper() == "N")
            rbtnEmployee.Items[1].Selected = true;
        lblLName.Text = lstClaimReservesInfo[0].LastName.ToString().Replace("''", "'");
        lblFName.Text = lstClaimReservesInfo[0].FirstName.ToString().Replace("''", "'");
        lblMName.Text = lstClaimReservesInfo[0].MiddleName.ToString().Replace("''", "'");
        lblDateIncident.Text = lstClaimReservesInfo[0].IncidentDate.ToString();

        // --- For the View Page
        if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
            lblEmp.Text = "Yes";
        else if (lstClaimReservesInfo[0].Employee.ToUpper() == "N")
            lblEmp.Text = "No";
        lblLastName.Text = lstClaimReservesInfo[0].LastName.ToString().Replace("''", "'");
        lblFirName.Text = lstClaimReservesInfo[0].FirstName.ToString().Replace("''", "'");
        lblMiddleName.Text = lstClaimReservesInfo[0].MiddleName.ToString().Replace("''", "'");
        lblDOIncident.Text = lstClaimReservesInfo[0].IncidentDate.ToString();
        lblClaim_No.Text = lstClaimReservesInfo[0].Claim_Number.ToString();
    }
    #region Bind All Combos
    private void BindCombos()
    {
        objGeneral = new RIMS_Base.Biz.CGeneral();
        dwEmpPayroll.DataSource = objGeneral.GetPayroll();
        dwEmpPayroll.DataTextField = "Payroll_FLD_desc";
        dwEmpPayroll.DataValueField = "Payroll_PK_ID";
        dwEmpPayroll.DataBind();
        dwEmpPayroll.Items.Insert(0, "--Select Employer Payroll--");

        dwMajorClassCode.DataSource = objGeneral.GetMajorClassCode();
        dwMajorClassCode.DataTextField = "Major_class_code_FLD_desc";
        dwMajorClassCode.DataValueField = "Major_class_code_pK_ID";
        dwMajorClassCode.DataBind();
        dwMajorClassCode.Items.Insert(0, "--Select Major Class Code--");

        dwLossCondAct.DataSource = objGeneral.GetLossCondtionAct();
        dwLossCondAct.DataTextField = "Loss_cond_act_FLD_desc";
        dwLossCondAct.DataValueField = "Loss_cond_act_PK_ID";
        dwLossCondAct.DataBind();
        dwLossCondAct.Items.Insert(0, "--Select Loss Condition Act--");

        dwLossCondRecovery.DataSource = objGeneral.GetLossCondtionRecovery();
        dwLossCondRecovery.DataTextField = "Loss_cond_recovery_FLD_desc";
        dwLossCondRecovery.DataValueField = "Loss_cond_recovery_PK_ID";
        dwLossCondRecovery.DataBind();
        dwLossCondRecovery.Items.Insert(0, "--Select Loss Condition Type Recovery--");

        dwLossCoverageCode.DataSource = objGeneral.GetLossCoverageCode();
        dwLossCoverageCode.DataTextField = "Loss_coverage_code_FLD_desc";
        dwLossCoverageCode.DataValueField = "Loss_coverage_code_PK_ID";
        dwLossCoverageCode.DataBind();
        dwLossCoverageCode.Items.Insert(0, "--Select Loss Coverage Code--");

        dwGarageState.DataSource = objGeneral.GetAllState();
        dwGarageState.DataTextField = "FLD_state";
        dwGarageState.DataValueField = "PK_ID";
        dwGarageState.DataBind();
        dwGarageState.Items.Insert(0, "--Select State--");

        dwInjurytype.DataSource = objGeneral.GetInjuryType();
        dwInjurytype.DataTextField = "Injury_type_FLD_desc";
        dwInjurytype.DataValueField = "Injury_type_PK_ID";
        dwInjurytype.DataBind();
        dwInjurytype.Items.Insert(0, "--Select Injury Type--");

        dwPropertyDamageType.DataSource = objGeneral.GetPropertyDamage();
        dwPropertyDamageType.DataTextField = "Property_Damage_FLD_desc";
        dwPropertyDamageType.DataValueField = "Property_Damage_PK_ID";
        dwPropertyDamageType.DataBind();
        dwPropertyDamageType.Items.Insert(0, "--Select Property Damage--");

        dwTaxState.DataSource = objGeneral.GetAllState();
        dwTaxState.DataTextField = "FLD_state";
        dwTaxState.DataValueField = "PK_ID";
        dwTaxState.DataBind();
        dwTaxState.Items.Insert(0, "--Select State--");

        dwLossCondLoss.DataSource = objGeneral.GetLossConditionLoss();
        dwLossCondLoss.DataTextField = "Loss_cond_loss_FLD_desc";
        dwLossCondLoss.DataValueField = "Loss_cond_loss_PK_ID";
        dwLossCondLoss.DataBind();
        dwLossCondLoss.Items.Insert(0, "--Select Loss Condition Loss--");

        dwLossCondSettlement.DataSource = objGeneral.GetLossCondSettlement();
        dwLossCondSettlement.DataTextField = "Loss_cond_settlement_FLD_desc";
        dwLossCondSettlement.DataValueField = "Loss_cond_settlement_PK_ID";
        dwLossCondSettlement.DataBind();
        dwLossCondSettlement.Items.Insert(0, "--Select Condition Settlement--");

        dwSettlementMethod.DataSource = objGeneral.GetSettlementMethod();
        dwSettlementMethod.DataTextField = "Settlement_method_FLD_desc";
        dwSettlementMethod.DataValueField = "Settlement_method_PK_ID";
        dwSettlementMethod.DataBind();
        dwSettlementMethod.Items.Insert(0, "--Select Settlement Method--");

        dwAttorneyForm.DataSource = objGeneral.GetAttornyForm();
        dwAttorneyForm.DataTextField = "Attorney_form_FLD_desc";
        dwAttorneyForm.DataValueField = "Attorney_form_PK_ID";
        dwAttorneyForm.DataBind();
        dwAttorneyForm.Items.Insert(0, "--Select Loss Attorney--");

        ddlAttachType.DataSource = objGeneral.GetAttachamentType();
        ddlAttachType.DataTextField = "FLD_Desc";
        ddlAttachType.DataValueField = "FLD_Code";
        ddlAttachType.DataBind();
        ddlAttachType.Items.Insert(0, "--Select Attachment Type--");
        ddlAttachType.SelectedIndex = 1;
    }
    #endregion
    protected void Next_Click(object sender, EventArgs e)
    {
        InsertUpdateData();
        Response.Redirect("Subrogation.aspx");
    }

    #region InsertUpdate Data
    private void InsertUpdateData()
    {
        try
        {
            objCarrier = new RIMS_Base.Biz.CCarrier();
            if (ViewState["Pk_Carrier"] != null && ViewState["Pk_Carrier"].ToString() != String.Empty)
            {
                objCarrier.PK_Carrier = Convert.ToInt32(ViewState["Pk_Carrier"].ToString());
                objCarrier.Update_Date = DateTime.Now;
                // ---- need to insert
                objCarrier.Updated_By = "1";
            }
            objCarrier.Table_Name = ViewState["TableName"].ToString();
            objCarrier.FK_Table_Name = Convert.ToDecimal(ViewState["TableFK"].ToString());
            if (rbtnClaimMode.SelectedIndex == 0)
                objCarrier.Claims_Made_Indicator = "Y";
            else if (rbtnClaimMode.SelectedIndex == 1)
                objCarrier.Claims_Made_Indicator = "N";
            if (txtDefenseMedicalEva.Text != String.Empty)
                objCarrier.Defense_Medical_Eval_PTD = Convert.ToDecimal(txtDefenseMedicalEva.Text.ToString().Trim());

            if (txtEmpLegalExp.Text != String.Empty)
                objCarrier.Employer_Legal_Expense_To_Date = Convert.ToDecimal(txtEmpLegalExp.Text.ToString().Trim());
            if (dwEmpPayroll.SelectedIndex != 0)
                objCarrier.FK_Employer_Payroll_Table = Convert.ToDecimal(dwEmpPayroll.SelectedItem.Value.ToString());
            if (txtEmpLiability.Text != String.Empty)
                objCarrier.Employer_Liability = Convert.ToDecimal(txtEmpLiability.Text.Trim());
            if (txtEmpLiabilityPaid.Text != String.Empty)
                objCarrier.Employer_Liability_PTD = Convert.ToDecimal(txtEmpLiabilityPaid.Text.Trim());
            if (txtExpertWitnessPaid.Text != String.Empty)
                objCarrier.Expert_Witness_PTD = Convert.ToDecimal(txtExpertWitnessPaid.Text.Trim());
            if (txtFuneralExpPaid.Text != String.Empty)
                objCarrier.Funeral_Expense_PTD = Convert.ToDecimal(txtFuneralExpPaid.Text.Trim());
            if (txtHospitalCostPaid.Text != String.Empty)
                objCarrier.Hospital_Cost_PTD = Convert.ToDecimal(txtHospitalCostPaid.Text.Trim());
            objCarrier.Independent_Subcontractor_No = txtIndependentSubContractNo.Text.Trim();
            if (dwMajorClassCode.SelectedIndex != 0)
                objCarrier.FK_Major_Class_Code = Convert.ToDecimal(dwMajorClassCode.SelectedItem.Value.ToString());
            if (txtProducerCode.Text != String.Empty)
                objCarrier.Producer_Code = Convert.ToDecimal(txtProducerCode.Text.Trim());
            if (txtProductRecovery.Text != String.Empty)
                objCarrier.Product_Liability_Recovery = Convert.ToDecimal(txtProductRecovery.Text.Trim());
            objCarrier.Product_Name = txtProductName.Text.ToString().Trim().Replace("'", "''");
            if (dwLossCondAct.SelectedIndex != 0)
                objCarrier.FK_Loss_Conditions_Act = Convert.ToDecimal(dwLossCondAct.SelectedItem.Value.ToString());
            if (dwLossCondRecovery.SelectedIndex != 0)
                objCarrier.FK_Loss_Conditions_Recovery = Convert.ToDecimal(dwLossCondRecovery.SelectedItem.Value.ToString());
            if (dwLossCoverageCode.SelectedIndex != 0)
                objCarrier.FK_Loss_Coverage_Code = Convert.ToDecimal(dwLossCoverageCode.SelectedItem.Value.ToString());
            if (txtLumpSumRemarriage.Text != String.Empty)
                objCarrier.Lump_Sum_Remarriage_Payment = Convert.ToDecimal(txtLumpSumRemarriage.Text.Trim());
            if (txtIncurredLoss.Text != String.Empty)
                objCarrier.Incurred_Loss = Convert.ToDecimal(txtIncurredLoss.Text.Trim());

            if (rbtnOtherBenefit.SelectedIndex == 0)
                objCarrier.Other_Benefit_Offset = "Y";
            else if (rbtnOtherBenefit.SelectedIndex == 1)
                objCarrier.Other_Benefit_Offset = "N";

            if (txtOtherMedicalPaid.Text != String.Empty)
                objCarrier.Other_Medical_PTD = Convert.ToDecimal(txtOtherMedicalPaid.Text.Trim());
            if (txtOtherVocationRehap.Text != String.Empty)
                objCarrier.Other_Voc_Rehab_PTD = Convert.ToDecimal(txtOtherVocationRehap.Text.Trim());
            if (txtPenaltyPaid.Text != String.Empty)
                objCarrier.Penalties_PTD = Convert.ToDecimal(txtPenaltyPaid.Text.Trim());
            if (txtPensionIndem.Text != String.Empty)
                objCarrier.Pension_Indem_PTVD = Convert.ToDecimal(txtPensionIndem.Text.Trim());
            if (txtPensionIndemNotPaid.Text != String.Empty)
                objCarrier.Pension_Reserved = Convert.ToDecimal(txtPensionIndemNotPaid.Text.Trim());
            if (rbtnPensionPlan.SelectedIndex == 0)
                objCarrier.Pension_Offset = "Y";
            else if (rbtnPensionPlan.SelectedIndex == 1)
                objCarrier.Pension_Offset = "N";
            if (dwGarageState.SelectedIndex != 0)
                objCarrier.FK_State_Garage = Convert.ToDecimal(dwGarageState.SelectedItem.Value.ToString());
            if (dwInjurytype.SelectedIndex != 0)
                objCarrier.FK_Injury_Code = Convert.ToDecimal(dwInjurytype.SelectedItem.Value);
            if (dwPropertyDamageType.SelectedIndex != 0)
                objCarrier.FK_Property_Damage = Convert.ToDecimal(dwPropertyDamageType.SelectedItem.Value);
            if (txtRecoveryCurrMonth.Text != String.Empty)
                objCarrier.Recovery_Current_Month = Convert.ToDecimal(txtRecoveryCurrMonth.Text.Trim());
            if (txtRecoveryDate.Text != String.Empty)
                objCarrier.Recovery_To_Date = Convert.ToDecimal(txtRecoveryDate.Text.Trim());
            if (txtReserveTypeCode.Text != String.Empty)
                objCarrier.Reserve_Type_Code = Convert.ToDecimal(txtReserveTypeCode.Text.Trim());
            if (txtSingleSumPaidDate.Text != String.Empty)
                objCarrier.Single_Sum_Paid_Date = Convert.ToDateTime(txtSingleSumPaidDate.Text);
            if (txtSingleSum.Text != String.Empty)
                objCarrier.Single_Sum_Paid = Convert.ToDecimal(txtSingleSum.Text.Trim());
            if (rbtnSocialSecBenifit.SelectedIndex == 0)
                objCarrier.SS_Benefit_Offset = "Y";
            else if (rbtnSocialSecBenifit.SelectedIndex == 1)
                objCarrier.SS_Benefit_Offset = "N";
            if (txtSSOffsetAmt.Text != String.Empty)
                objCarrier.SS_Other_Amount = Convert.ToDecimal(txtSSOffsetAmt.Text.Trim());
            if (rbtnSpecialFundBeni.SelectedIndex == 0)
                objCarrier.Special_Fund_Offset = "Y";
            else if (rbtnSpecialFundBeni.SelectedIndex == 1)
                objCarrier.Special_Fund_Offset = "N";
            if (txtSymbol.Text != String.Empty)
                objCarrier.Symbol = Convert.ToDecimal(txtSymbol.Text.Trim());
            if (dwTaxState.SelectedIndex != 0)
                objCarrier.FK_State_Tax = Convert.ToDecimal(dwTaxState.SelectedItem.Value.ToString());
            objCarrier.TPA_Internal_Claim_Code = txtTpa.Text.ToString().Trim().Replace("'", "''");
            if (txtTempIndemIncurred.Text != String.Empty)
                objCarrier.Temp_Indem_Incurred = Convert.ToDecimal(txtTempIndemIncurred.Text.Trim());
            if (txtTempIndemNoOfWeeks.Text != String.Empty)
                objCarrier.Temp_Indem_No_Weeks = Convert.ToDecimal(txtTempIndemNoOfWeeks.Text.Trim());
            if (txtTimeExpCurrMonth.Text != String.Empty)
                objCarrier.T_E_Current_Month = Convert.ToDecimal(txtTimeExpCurrMonth.Text.Trim());
            if (txtTimeExpDate.Text != String.Empty)
                objCarrier.T_E_To_Date = Convert.ToDecimal(txtTimeExpDate.Text.Trim());
            if (txtTotalGrossIncurred.Text != String.Empty)
                objCarrier.Total_Gross_Incurred = Convert.ToDecimal(txtTotalGrossIncurred.Text.Trim());
            if (txtTotIncVocRehab.Text != String.Empty)
                objCarrier.Total_Incurred_Voc_Rehab = Convert.ToDecimal(txtTotIncVocRehab.Text.Trim());
            if (txtTotIncVocRehabEduBeni.Text != String.Empty)
                objCarrier.Total_Incurred_Voc_Rehab_Edu = Convert.ToDecimal(txtTotIncVocRehabEduBeni.Text.Trim());
            if (txtTotIncuocationRehabExp.Text != String.Empty)
                objCarrier.Total_Incurred_Voc_Rehab_Eval = Convert.ToDecimal(txtTotIncuocationRehabExp.Text.Trim());
            if (txtTotIncVocRehabMaintBen.Text != String.Empty)
                objCarrier.Total_Incurred_Voc_Rehab_Main = Convert.ToDecimal(txtTotIncVocRehabMaintBen.Text.Trim());
            if (txtTotPayToPhysician.Text != String.Empty)
                objCarrier.Total_Payments_Phys = Convert.ToDecimal(txtTotPayToPhysician.Text.Trim());
            if (txtTransactCode.Text != String.Empty)
                objCarrier.Trans_Type = Convert.ToDecimal(txtTransactCode.Text.Trim());
            if (rbtnUnEmpBenifit.SelectedIndex == 0)
                objCarrier.Unemp_Benefit_Offset = "Y";
            else if (rbtnUnEmpBenifit.SelectedIndex == 1)
                objCarrier.Unemp_Benefit_Offset = "N";
            objCarrier.Unique_Occur_Claim = txtUniqueOccurrence.Text.Trim().Replace("'", "''");
            if (txtLumpSumSettleAmt.Text != String.Empty)
                objCarrier.Lump_Sum_Settlement = Convert.ToDecimal(txtLumpSumSettleAmt.Text.Trim());
            if (txtOtherRecovery.Text != String.Empty)
                objCarrier.Other_Recovery = Convert.ToDecimal(txtOtherRecovery.Text.Trim());
            if (txtOtherWeekPayment.Text != String.Empty)
                objCarrier.Other_Weekly_Pymnts = Convert.ToDecimal(txtOtherWeekPayment.Text.Trim());
            if (txtCatastropheNo.Text != String.Empty)
                objCarrier.WC_Cat_Number = Convert.ToDecimal(txtCatastropheNo.Text.Trim());
            if (txtWorkCompIndemPay.Text != String.Empty)
                objCarrier.WC_Indemnity_Payment = Convert.ToDecimal(txtWorkCompIndemPay.Text.Trim());
            if (txtIndemIncurred.Text != String.Empty)
                objCarrier.Indemnity_Incurred = Convert.ToDecimal(txtIndemIncurred.Text.Trim());
            if (txtIndemIncuCurrMonth.Text != String.Empty)
                objCarrier.Indemnity_Paid_Current = Convert.ToDecimal(txtIndemIncuCurrMonth.Text.Trim());
            if (txtIndemPaid.Text != String.Empty)
                objCarrier.Indemnity_PTD = Convert.ToDecimal(txtIndemPaid.Text.Trim());
            if (txtMediIncurToDate.Text != String.Empty)
                objCarrier.Medical_Incurred = Convert.ToDecimal(txtMediIncurToDate.Text.Trim());
            if (txtMedicalIncuCurrMonth.Text != String.Empty)
                objCarrier.Medical_Paid_Current = Convert.ToDecimal(txtMedicalIncuCurrMonth.Text.Trim());
            if (txtMediPaidToDate.Text != String.Empty)
                objCarrier.Medical_PTD = Convert.ToDecimal(txtMediPaidToDate.Text.Trim());
            if (txtExpIncurred.Text != String.Empty)
                objCarrier.Expense_Incurred = Convert.ToDecimal(txtExpIncurred.Text.Trim());
            if (txtExpIncuCurrMonth.Text != String.Empty)
                objCarrier.Expense_Paid_Current = Convert.ToDecimal(txtExpIncuCurrMonth.Text.Trim());
            if (txtExpPaid.Text != String.Empty)
                objCarrier.Expense_PTD = Convert.ToDecimal(txtExpPaid.Text.Trim());
            if (rbtnContovertedcase.SelectedIndex == 0)
                objCarrier.Controverted_Case = "Y";
            else if (rbtnContovertedcase.SelectedIndex == 1)
                objCarrier.Controverted_Case = "N";
            //--- Field Not Found
            if (rbtnInsurerRaimbursed.SelectedIndex == 0)
                objCarrier.Insurer_Reimbursed_Benifi_Payable_Claimant = "Y";
            else if (rbtnInsurerRaimbursed.SelectedIndex == 1)
                objCarrier.Insurer_Reimbursed_Benifi_Payable_Claimant = "N";
            objCarrier.AIG_Policy_Prefix = txtAIGPolicyPrefix.Text.ToString().Trim().Replace("'", "''");
            if (dwLossCondLoss.SelectedIndex != 0)
                objCarrier.FK_Loss_Conditions_Loss = Convert.ToDecimal(dwLossCondLoss.SelectedItem.Value.ToString());
            if (dwLossCondSettlement.SelectedIndex != 0)
                objCarrier.FK_Loss_Conditions_Settlement = Convert.ToDecimal(dwLossCondSettlement.SelectedItem.Value.ToString());
            if (rbtnDeductibleIndicator.SelectedIndex == 0)
                objCarrier.Deductible_Indicator = "Y";
            else if (rbtnDeductibleIndicator.SelectedIndex == 1)
                objCarrier.Deductible_Indicator = "N";
            if (dwSettlementMethod.SelectedIndex != 0)
                objCarrier.FK_Settlement_Method = Convert.ToDecimal(dwSettlementMethod.SelectedItem.Value.ToString());
            if (rbtnLegalRepresant.SelectedIndex == 0)
                objCarrier.Legal_Representation = "Y";
            else if (rbtnLegalRepresant.SelectedIndex == 1)
                objCarrier.Legal_Representation = "N";
            if (dwAttorneyForm.SelectedIndex != 0)
                objCarrier.FK_Attorney_Form = Convert.ToDecimal(dwAttorneyForm.SelectedItem.Value.ToString());
            if (txtDeductRaimbursh.Text != String.Empty)
                objCarrier.Deductible_Reimbursement = Convert.ToDecimal(txtDeductRaimbursh.Text.Trim());

            intRetval = Convert.ToInt32(objCarrier.InsertUpdateCarrier(objCarrier));
            ViewState["Pk_Carrier"] = intRetval.ToString();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region RetriveData

    private void RetriveDataByID(decimal WorkCompID)
    {
        objCarrier = new RIMS_Base.Biz.CCarrier();
        lstBaseCarrier = new List<RIMS_Base.CCarrier>();
        lstBaseCarrier = objCarrier.GetCarrierByID(WorkCompID, ViewState["TableName"].ToString());
        if (lstBaseCarrier.Count != 0)
        {
            ViewState["Pk_Carrier"] = lstBaseCarrier[0].PK_Carrier.ToString();
            if (lstBaseCarrier[0].Claims_Made_Indicator == "Y")
                rbtnClaimMode.SelectedIndex = 0;
            else if (lstBaseCarrier[0].Claims_Made_Indicator == "N")
                rbtnClaimMode.SelectedIndex = 1;
            txtDefenseMedicalEva.Text = lstBaseCarrier[0].Defense_Medical_Eval_PTD.ToString();
            txtEmpLegalExp.Text = lstBaseCarrier[0].Employer_Legal_Expense_To_Date.ToString();
            dwEmpPayroll.SelectedIndex = dwEmpPayroll.Items.IndexOf(dwEmpPayroll.Items.FindByValue(lstBaseCarrier[0].FK_Employer_Payroll_Table.ToString()));
            txtDefenseMedicalEva.Text = lstBaseCarrier[0].Defense_Medical_Eval_PTD.ToString();
            txtEmpLiability.Text = lstBaseCarrier[0].Employer_Liability.ToString();
            txtEmpLiabilityPaid.Text = lstBaseCarrier[0].Employer_Liability_PTD.ToString();
            txtExpertWitnessPaid.Text = lstBaseCarrier[0].Expert_Witness_PTD.ToString();
            txtFuneralExpPaid.Text = lstBaseCarrier[0].Funeral_Expense_PTD.ToString();
            txtHospitalCostPaid.Text = lstBaseCarrier[0].Hospital_Cost_PTD.ToString();
            txtIndependentSubContractNo.Text = lstBaseCarrier[0].Independent_Subcontractor_No;
            dwMajorClassCode.SelectedIndex = dwMajorClassCode.Items.IndexOf(dwMajorClassCode.Items.FindByValue(lstBaseCarrier[0].FK_Major_Class_Code.ToString()));
            txtProducerCode.Text = lstBaseCarrier[0].Producer_Code.ToString();
            txtProductRecovery.Text = lstBaseCarrier[0].Product_Liability_Recovery.ToString();
            txtProductName.Text = lstBaseCarrier[0].Product_Name;
            dwLossCondAct.SelectedIndex = dwLossCondAct.Items.IndexOf(dwLossCondAct.Items.FindByValue(lstBaseCarrier[0].FK_Loss_Conditions_Act.ToString()));
            dwLossCondRecovery.SelectedIndex = dwLossCondRecovery.Items.IndexOf(dwLossCondRecovery.Items.FindByValue(lstBaseCarrier[0].FK_Loss_Conditions_Recovery.ToString()));
            dwLossCoverageCode.SelectedIndex = dwLossCoverageCode.Items.IndexOf(dwLossCoverageCode.Items.FindByValue(lstBaseCarrier[0].FK_Loss_Coverage_Code.ToString()));
            txtLumpSumRemarriage.Text = lstBaseCarrier[0].Lump_Sum_Remarriage_Payment.ToString();
            txtIncurredLoss.Text = lstBaseCarrier[0].Incurred_Loss.ToString();
            if (lstBaseCarrier[0].Other_Benefit_Offset == "Y")
                rbtnOtherBenefit.SelectedIndex = 0;
            else if (lstBaseCarrier[0].Other_Benefit_Offset == "N")
                rbtnOtherBenefit.SelectedIndex = 1;
            txtOtherMedicalPaid.Text = lstBaseCarrier[0].Other_Medical_PTD.ToString();
            txtOtherVocationRehap.Text = lstBaseCarrier[0].Other_Voc_Rehab_PTD.ToString();
            txtPenaltyPaid.Text = lstBaseCarrier[0].Penalties_PTD.ToString();
            txtPensionIndem.Text = lstBaseCarrier[0].Pension_Indem_PTVD.ToString();
            txtPensionIndemNotPaid.Text = lstBaseCarrier[0].Pension_Reserved.ToString();
            if (lstBaseCarrier[0].Pension_Offset == "Y")
                rbtnPensionPlan.SelectedIndex = 0;
            else if (lstBaseCarrier[0].Pension_Offset == "N")
                rbtnPensionPlan.SelectedIndex = 1;
            dwGarageState.SelectedIndex = dwGarageState.Items.IndexOf(dwGarageState.Items.FindByValue(lstBaseCarrier[0].FK_State_Garage.ToString()));

            //if(dwGarageState.Items.Contains((ListItem)lstBaseCarrier[0].FK_State_Garage.ToString()) == true)
            //  dwGarageState.Items.FindByValue(lstBaseCarrier[0].FK_State_Garage.ToString()).Selected = true;
            dwInjurytype.SelectedIndex = dwInjurytype.Items.IndexOf(dwInjurytype.Items.FindByValue(lstBaseCarrier[0].FK_Injury_Code.ToString()));
            dwPropertyDamageType.SelectedIndex = dwPropertyDamageType.Items.IndexOf(dwPropertyDamageType.Items.FindByValue(lstBaseCarrier[0].FK_Property_Damage.ToString()));
            txtRecoveryCurrMonth.Text = lstBaseCarrier[0].Recovery_Current_Month.ToString();
            txtRecoveryDate.Text = lstBaseCarrier[0].Recovery_To_Date.ToString();
            txtReserveTypeCode.Text = lstBaseCarrier[0].Reserve_Type_Code.ToString();
            if (lstBaseCarrier[0].Single_Sum_Paid_Date.ToString() != String.Empty)
                txtSingleSumPaidDate.Text = Convert.ToDateTime(lstBaseCarrier[0].Single_Sum_Paid_Date.ToString()).ToShortDateString();
            txtSingleSum.Text = lstBaseCarrier[0].Single_Sum_Paid.ToString();
            if (lstBaseCarrier[0].SS_Benefit_Offset == "Y")
                rbtnSocialSecBenifit.SelectedIndex = 0;
            else if (lstBaseCarrier[0].SS_Benefit_Offset == "N")
                rbtnSocialSecBenifit.SelectedIndex = 1;
            txtSSOffsetAmt.Text = lstBaseCarrier[0].SS_Other_Amount.ToString();
            if (lstBaseCarrier[0].SS_Benefit_Offset == "Y")
                rbtnSpecialFundBeni.SelectedIndex = 0;
            else if (lstBaseCarrier[0].SS_Benefit_Offset == "N")
                rbtnSpecialFundBeni.SelectedIndex = 1;
            txtSymbol.Text = lstBaseCarrier[0].Symbol.ToString();
            dwTaxState.SelectedIndex = dwTaxState.Items.IndexOf(dwTaxState.Items.FindByValue(lstBaseCarrier[0].FK_State_Tax.ToString()));
            txtTpa.Text = lstBaseCarrier[0].TPA_Internal_Claim_Code;
            txtTempIndemIncurred.Text = lstBaseCarrier[0].Temp_Indem_Incurred.ToString();
            txtTempIndemNoOfWeeks.Text = lstBaseCarrier[0].Temp_Indem_No_Weeks.ToString();
            txtTimeExpCurrMonth.Text = lstBaseCarrier[0].T_E_Current_Month.ToString();
            txtTimeExpDate.Text = lstBaseCarrier[0].T_E_To_Date.ToString();
            txtTotalGrossIncurred.Text = lstBaseCarrier[0].Total_Gross_Incurred.ToString();
            txtTotIncVocRehab.Text = lstBaseCarrier[0].Total_Incurred_Voc_Rehab.ToString();
            txtTotIncVocRehabEduBeni.Text = lstBaseCarrier[0].Total_Incurred_Voc_Rehab_Edu.ToString();
            txtTotIncuocationRehabExp.Text = lstBaseCarrier[0].Total_Incurred_Voc_Rehab_Eval.ToString();
            txtTotIncVocRehabMaintBen.Text = lstBaseCarrier[0].Total_Incurred_Voc_Rehab_Main.ToString();
            txtTotPayToPhysician.Text = lstBaseCarrier[0].Total_Payments_Phys.ToString();
            txtTransactCode.Text = lstBaseCarrier[0].Trans_Type.ToString();
            if (lstBaseCarrier[0].Unemp_Benefit_Offset == "Y")
                rbtnUnEmpBenifit.SelectedIndex = 0;
            else if (lstBaseCarrier[0].Unemp_Benefit_Offset == "N")
                rbtnUnEmpBenifit.SelectedIndex = 1;
            txtUniqueOccurrence.Text = lstBaseCarrier[0].Unique_Occur_Claim;
            txtLumpSumSettleAmt.Text = lstBaseCarrier[0].Lump_Sum_Settlement.ToString();
            txtOtherRecovery.Text = lstBaseCarrier[0].Other_Recovery.ToString();
            txtOtherWeekPayment.Text = lstBaseCarrier[0].Other_Weekly_Pymnts.ToString();
            txtCatastropheNo.Text = lstBaseCarrier[0].WC_Cat_Number.ToString();
            txtWorkCompIndemPay.Text = lstBaseCarrier[0].WC_Indemnity_Payment.ToString();
            txtIndemIncurred.Text = lstBaseCarrier[0].Indemnity_Incurred.ToString();
            txtIndemIncuCurrMonth.Text = lstBaseCarrier[0].Indemnity_Paid_Current.ToString();
            txtIndemPaid.Text = lstBaseCarrier[0].Indemnity_PTD.ToString();
            txtMediIncurToDate.Text = lstBaseCarrier[0].Medical_Incurred.ToString();
            txtMedicalIncuCurrMonth.Text = lstBaseCarrier[0].Medical_Paid_Current.ToString();
            txtMediPaidToDate.Text = lstBaseCarrier[0].Medical_PTD.ToString();
            txtExpIncurred.Text = lstBaseCarrier[0].Expense_Incurred.ToString();
            txtExpIncuCurrMonth.Text = lstBaseCarrier[0].Expense_Paid_Current.ToString();
            txtExpPaid.Text = lstBaseCarrier[0].Expense_PTD.ToString();
            if (lstBaseCarrier[0].Controverted_Case == "Y")
                rbtnContovertedcase.SelectedIndex = 0;
            else if (lstBaseCarrier[0].Controverted_Case == "N")
                rbtnContovertedcase.SelectedIndex = 1;
            //  --- No filed In the Database... Need to discuss.
            if (lstBaseCarrier[0].Insurer_Reimbursed_Benifi_Payable_Claimant == "Y")
                rbtnInsurerRaimbursed.SelectedIndex = 0;
            else if (lstBaseCarrier[0].Insurer_Reimbursed_Benifi_Payable_Claimant == "N")
                rbtnInsurerRaimbursed.SelectedIndex = 1;

            txtAIGPolicyPrefix.Text = lstBaseCarrier[0].AIG_Policy_Prefix;
            dwLossCondLoss.SelectedIndex = dwLossCondLoss.Items.IndexOf(dwLossCondLoss.Items.FindByValue(lstBaseCarrier[0].FK_Loss_Conditions_Loss.ToString()));
            dwLossCondSettlement.SelectedIndex = dwLossCondSettlement.Items.IndexOf(dwLossCondSettlement.Items.FindByValue(lstBaseCarrier[0].FK_Loss_Conditions_Settlement.ToString()));
            if (lstBaseCarrier[0].Deductible_Indicator == "Y")
                rbtnDeductibleIndicator.SelectedIndex = 0;
            else if (lstBaseCarrier[0].Deductible_Indicator == "N")
                rbtnDeductibleIndicator.SelectedIndex = 1;
            dwSettlementMethod.SelectedIndex = dwSettlementMethod.Items.IndexOf(dwSettlementMethod.Items.FindByValue(lstBaseCarrier[0].FK_Settlement_Method.ToString()));
            if (lstBaseCarrier[0].Legal_Representation == "Y")
                rbtnLegalRepresant.SelectedIndex = 0;
            else if (lstBaseCarrier[0].Legal_Representation == "N")
                rbtnLegalRepresant.SelectedIndex = 1;
            dwAttorneyForm.SelectedIndex = dwAttorneyForm.Items.IndexOf(dwAttorneyForm.Items.FindByValue(lstBaseCarrier[0].FK_Attorney_Form.ToString()));
            txtDeductRaimbursh.Text = lstBaseCarrier[0].Deductible_Reimbursement.ToString();

            // -- retirve Attachment Details.
            lstAttachment = BindAttachmentDetails();
            if (lstAttachment.Count > 0)
            {
                gvAttachmentDetails.DataSource = lstAttachment;
                gvAttachmentDetails.DataBind();
                //dispTagName.Value = "dvAttachDetails";
                btnRemove.Visible = true;
                btnMail.Visible = true;
            }
            else
            {
                btnRemove.Visible = false;
                btnMail.Visible = false;
            }
        }
        else
        {
            btnRemove.Visible = false;
            btnMail.Visible = false;
        }
    }

    #region View Page
    private void DisplayDataInView(decimal Fk_Table_Name)
    {
        objCarrier = new RIMS_Base.Biz.CCarrier();
        lstBaseCarrier = new List<RIMS_Base.CCarrier>();
        lstBaseCarrier = objCarrier.GetCarrierByID(Fk_Table_Name, "Liability_Claim");
        try
        {
            if (lstBaseCarrier.Count > 0)
            {
                ViewState["Pk_Carrier"] = lstBaseCarrier[0].PK_Carrier;
                if (lstBaseCarrier[0].Claims_Made_Indicator == "Y")
                    lblClaimMode.Text = "Yes";
                else if (lstBaseCarrier[0].Claims_Made_Indicator == "N")
                    lblClaimMode.Text = "No";
                //lblDefenseMEdiEvaPTD.Text = lstBaseCarrier[0].Defense_Medical_Eval_PTD.ToString();
                lblDefenseMEdiEvaPTD.Text = String.Format("{0:c}", lstBaseCarrier[0].Defense_Medical_Eval_PTD);
                lblempLegalExp.Text = String.Format("{0:c}", lstBaseCarrier[0].Employer_Legal_Expense_To_Date);
                if (lstBaseCarrier[0].FK_Employer_Payroll_Table != null)
                    lblEmpPayroll.Text = dwEmpPayroll.Items.FindByValue(lstBaseCarrier[0].FK_Employer_Payroll_Table.ToString()).Text;
                lblMediIncuDate.Text = String.Format("{0:c}", lstBaseCarrier[0].Defense_Medical_Eval_PTD);
                lblempLiability.Text = String.Format("{0:c}", lstBaseCarrier[0].Employer_Liability);
                lblEmpLiaPTD.Text = String.Format("{0:c}", lstBaseCarrier[0].Employer_Liability_PTD);
                lblExprtWitPTD.Text = String.Format("{0:c}", lstBaseCarrier[0].Expert_Witness_PTD);
                lblFuneralExp.Text = String.Format("{0:c}", lstBaseCarrier[0].Funeral_Expense_PTD);
                lblHospitalCostPTD.Text = String.Format("{0:c}", lstBaseCarrier[0].Hospital_Cost_PTD);
                lblIndependentSubNo.Text = lstBaseCarrier[0].Independent_Subcontractor_No;
                if (lstBaseCarrier[0].FK_Major_Class_Code != null)
                    lblMajorClassCode.Text = dwMajorClassCode.Items.FindByValue(lstBaseCarrier[0].FK_Major_Class_Code.ToString()).Text;
                lblProducerCode.Text = lstBaseCarrier[0].Producer_Code.ToString();
                lblProductLiaRecover.Text = String.Format("{0:c}", lstBaseCarrier[0].Product_Liability_Recovery);
                lblProductName.Text = lstBaseCarrier[0].Product_Name;
                if (lstBaseCarrier[0].FK_Loss_Conditions_Act != null)
                    lblLossCondAct.Text = dwLossCondAct.Items.FindByValue(lstBaseCarrier[0].FK_Loss_Conditions_Act.ToString()).Text;
                if (lstBaseCarrier[0].FK_Loss_Conditions_Recovery != null)
                    lblLossCondRecover.Text = dwLossCondRecovery.Items.FindByValue(lstBaseCarrier[0].FK_Loss_Conditions_Recovery.ToString()).Text;
                if (lstBaseCarrier[0].FK_Loss_Coverage_Code != null)
                    lblLossCovCode.Text = dwLossCoverageCode.Items.FindByValue(lstBaseCarrier[0].FK_Loss_Coverage_Code.ToString()).Text;
                lblLumpSumRemarriage.Text = String.Format("{0:c}", lstBaseCarrier[0].Lump_Sum_Remarriage_Payment);
                lblIncuLoss.Text = String.Format("{0:c}", lstBaseCarrier[0].Incurred_Loss);
                if (lstBaseCarrier[0].Other_Benefit_Offset == "Y")
                    lblOtherBenefitOffset.Text = "Yes";
                else if (lstBaseCarrier[0].Other_Benefit_Offset == "N")
                    lblOtherBenefitOffset.Text = "No";
                lblOtherMediPTD.Text = String.Format("{0:c}", lstBaseCarrier[0].Other_Medical_PTD);
                lblOtherVRExpDate.Text = String.Format("{0:c}", lstBaseCarrier[0].Other_Voc_Rehab_PTD);
                lblPenaltyPTD.Text = String.Format("{0:c}", lstBaseCarrier[0].Penalties_PTD);
                lblPensionIndemBenePTD.Text = String.Format("{0:c}", lstBaseCarrier[0].Pension_Indem_PTVD);
                lblPensionResNotPaid.Text = String.Format("{0:c}", lstBaseCarrier[0].Pension_Reserved);
                if (lstBaseCarrier[0].Pension_Offset == "Y")
                    lblPensionBeniOffset.Text = "Yes";
                else if (lstBaseCarrier[0].Pension_Offset == "N")
                    lblPensionBeniOffset.Text = "No";
                if (lstBaseCarrier[0].FK_State_Garage != null)
                    lblGarrageState.Text = dwGarageState.Items.FindByValue(lstBaseCarrier[0].FK_State_Garage.ToString()).Text;

                if (lstBaseCarrier[0].FK_Injury_Code != null)
                    lblInjuryType.Text = dwInjurytype.Items.FindByValue(lstBaseCarrier[0].FK_Injury_Code.ToString()).Text;
                if (lstBaseCarrier[0].FK_Property_Damage != null)
                    lblPropertyDamange.Text = dwPropertyDamageType.Items.FindByValue(lstBaseCarrier[0].FK_Property_Damage.ToString()).Text;
                lblRecocurrMth.Text = String.Format("{0:c}", lstBaseCarrier[0].Recovery_Current_Month);
                lblRecoveryDate.Text = String.Format("{0:c}", lstBaseCarrier[0].Recovery_To_Date);
                if (lstBaseCarrier[0].Reserve_Type_Code != null)
                    lblTypeCode.Text = lstBaseCarrier[0].Reserve_Type_Code.ToString();
                if (lstBaseCarrier[0].Single_Sum_Paid_Date.ToString() != String.Empty)
                    lblSingleSumPaidDate.Text = Convert.ToDateTime(lstBaseCarrier[0].Single_Sum_Paid_Date.ToString()).ToShortDateString();
                lblSingleSumPaid.Text = String.Format("{0:c}", lstBaseCarrier[0].Single_Sum_Paid);
                if (lstBaseCarrier[0].SS_Benefit_Offset == "Y")
                    lblSSbeneOffset.Text = "Yes";
                else if (lstBaseCarrier[0].SS_Benefit_Offset == "N")
                    lblSSbeneOffset.Text = "No";
                lblSSAmt.Text = String.Format("{0:c}", lstBaseCarrier[0].SS_Other_Amount);
                if (lstBaseCarrier[0].SS_Benefit_Offset == "Y")
                    lblSpecBeneOff.Text = "Yes";
                else if (lstBaseCarrier[0].SS_Benefit_Offset == "N")
                    lblSpecBeneOff.Text = "No";
                lblSymbol.Text = lstBaseCarrier[0].Symbol.ToString();
                if (lstBaseCarrier[0].FK_State_Tax != null)
                    lblTaxState.Text = dwTaxState.Items.FindByValue(lstBaseCarrier[0].FK_State_Tax.ToString()).Text;
                lblTPA.Text = lstBaseCarrier[0].TPA_Internal_Claim_Code;
                lblTempIndemIncu.Text = String.Format("{0:c}", lstBaseCarrier[0].Temp_Indem_Incurred);
                lblTempIndemNoWeek.Text = lstBaseCarrier[0].Temp_Indem_No_Weeks.ToString();
                lblTECurrMonth.Text = String.Format("{0:c}", lstBaseCarrier[0].T_E_Current_Month);
                lblTEDate.Text = String.Format("{0:c}", lstBaseCarrier[0].T_E_To_Date);
                lblTotGrossIncu.Text = String.Format("{0:c}", lstBaseCarrier[0].Total_Gross_Incurred);
                lblTotIVR.Text = String.Format("{0:c}", lstBaseCarrier[0].Total_Incurred_Voc_Rehab);
                lblTotIVREdu.Text = String.Format("{0:c}", lstBaseCarrier[0].Total_Incurred_Voc_Rehab_Edu);
                lblTotIVRExp.Text = String.Format("{0:c}", lstBaseCarrier[0].Total_Incurred_Voc_Rehab_Eval);
                lblTotalIVRMaintain.Text = String.Format("{0:c}", lstBaseCarrier[0].Total_Incurred_Voc_Rehab_Main);
                lblTotPayPhysician.Text = String.Format("{0:c}", lstBaseCarrier[0].Total_Payments_Phys);
                lblTransCode.Text = lstBaseCarrier[0].Trans_Type.ToString();
                if (lstBaseCarrier[0].Unemp_Benefit_Offset == "Y")
                    lblUnEmpBeniOffset.Text = "Yes";
                else if (lstBaseCarrier[0].Unemp_Benefit_Offset == "N")
                    lblUnEmpBeniOffset.Text = "No";
                lblUniqueOcc.Text = lstBaseCarrier[0].Unique_Occur_Claim;
                lblLumpSumSettleAmt.Text = String.Format("{0:c}", lstBaseCarrier[0].Lump_Sum_Settlement);
                lblOtherRecovery.Text = String.Format("{0:c}", lstBaseCarrier[0].Other_Recovery);
                lblOtherWeekPay.Text = String.Format("{0:c}", lstBaseCarrier[0].Other_Weekly_Pymnts);
                lblCatastropheNo.Text = lstBaseCarrier[0].WC_Cat_Number.ToString();
                lblWorkCompIndemPay.Text = String.Format("{0:c}", lstBaseCarrier[0].WC_Indemnity_Payment);
                lblIndemIncuDate.Text = String.Format("{0:c}", lstBaseCarrier[0].Indemnity_Incurred);
                lblIndemIncuCurrMonth.Text = String.Format("{0:c}", lstBaseCarrier[0].Indemnity_Paid_Current);
                lblIndemPTD.Text = String.Format("{0:c}", lstBaseCarrier[0].Indemnity_PTD);
                lblMediIncuDate.Text = String.Format("{0:c}", lstBaseCarrier[0].Medical_Incurred);
                lblMediIncuCurrMonth.Text = String.Format("{0:c}", lstBaseCarrier[0].Medical_Paid_Current);
                lblMediPTD.Text = String.Format("{0:c}", lstBaseCarrier[0].Medical_PTD);
                lblExpIncuDate.Text = String.Format("{0:c}", lstBaseCarrier[0].Expense_Incurred);
                lblExpIncuCurrMonth.Text = String.Format("{0:c}", lstBaseCarrier[0].Expense_Paid_Current);
                lblExpPTD.Text = String.Format("{0:c}", lstBaseCarrier[0].Expense_PTD);
                if (lstBaseCarrier[0].Controverted_Case == "Y")
                    lblControverted.Text = "Yes";
                else if (lstBaseCarrier[0].Controverted_Case == "N")
                    lblControverted.Text = "No";
                //  --- No filed In the Database... Need to discuss.
                if (lstBaseCarrier[0].Insurer_Reimbursed_Benifi_Payable_Claimant == "Y")
                    lblInsurerReimburse.Text = "Yes";
                else if (lstBaseCarrier[0].Insurer_Reimbursed_Benifi_Payable_Claimant == "N")
                    lblInsurerReimburse.Text = "No";

                lblAIGPolicyPrefix.Text = lstBaseCarrier[0].AIG_Policy_Prefix;
                if (lstBaseCarrier[0].FK_Loss_Conditions_Loss != null)
                    lblLossCondLoss.Text = dwLossCondLoss.Items.FindByValue(lstBaseCarrier[0].FK_Loss_Conditions_Loss.ToString()).Text;
                if (lstBaseCarrier[0].FK_Loss_Conditions_Settlement != null)
                    lblLossCondSettle.Text = dwLossCondSettlement.Items.FindByValue(lstBaseCarrier[0].FK_Loss_Conditions_Settlement.ToString()).Text;
                if (lstBaseCarrier[0].Deductible_Indicator == "Y")
                    lblDeductIndi.Text = "Yes";
                else if (lstBaseCarrier[0].Deductible_Indicator == "N")
                    lblDeductIndi.Text = "No";
                if (lstBaseCarrier[0].FK_Settlement_Method != null)
                    lblSettleMethod.Text = dwSettlementMethod.Items.FindByValue(lstBaseCarrier[0].FK_Settlement_Method.ToString()).Text;
                if (lstBaseCarrier[0].Legal_Representation == "Y")
                    lblLegalRepresent.Text = "Yes";
                else if (lstBaseCarrier[0].Legal_Representation == "N")
                    lblLegalRepresent.Text = "No";
                if (lstBaseCarrier[0].FK_Attorney_Form != null)
                    lblAttorney.Text = dwAttorneyForm.Items.FindByValue(lstBaseCarrier[0].FK_Attorney_Form.ToString()).Text;
                lblDeductReimburse.Text = String.Format("{0:c}", lstBaseCarrier[0].Deductible_Reimbursement);

                // -- retirve Attachment Details.
                lstAttachment = new List<RIMS_Base.CAttachment>();
                lstAttachment = BindAttachmentDetails();
                gvAttachView.DataSource = lstAttachment;
                gvAttachView.DataBind();
                gvAttachView.Columns[0].Visible = false;
                //if (lstAttachment.Count > 0)
                //    btnViewMail.Visible = true;
                //else
                //    btnViewMail.Visible = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void gvAttachView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
                //((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=Carrier&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #endregion
    protected void btnView_Click(object sender, EventArgs e)
    {
        //dispTagName.Value =  "divSaveView";

        dvAttachDetails.Style["display"] = "none";
        divfirst.Style["display"] = "none";
        divsecond.Style["display"] = "none";
        divthird.Style["display"] = "none";
        leftDiv.Style["display"] = "none";
        divSaveView.Style["display"] = "block";
        divbtn.Style["display"] = "none";
        mainContent.Style["display"] = "none";


        InsertUpdateData();
        DisplayDataInView(Convert.ToDecimal(Session["WorkerCompID"].ToString()));
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        //dispTagName.Value = "contmain";
        dvAttachDetails.Style["display"] = "none";
        divfirst.Style["display"] = "block";
        divsecond.Style["display"] = "none";
        divthird.Style["display"] = "none";
        divSaveView.Style["display"] = "none";
        leftDiv.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        mainContent.Style["display"] = "block";

        RetriveDataByID(Convert.ToDecimal(ViewState["TableFK"].ToString()));
    }

    #region Attachment

    protected void gvAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
                //((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=Carrier&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void UploadDocuments()
    {
        try
        {
            m_strPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"]);

            if (!(Directory.Exists(m_strPath + "\\" + m_strFolderName)))
            {
                Directory.CreateDirectory(m_strPath + "\\" + m_strFolderName);
            }
            m_strFileName = GetCustomFileName() + uplCommon.FileName.ToString();
            m_strPath = m_strPath + "\\" + m_strFolderName + "\\" + m_strFileName;
            uplCommon.SaveAs(m_strPath);

        }
        catch (Exception ex)
        {
            //Log.Append("Error in UploadPhotoImages Method of ConditionAssessment's PhotoGraphs:" + ex.Message);
            //Common.reportError("Error in UploadPhotoImages Method of ConditionAssessment's PhotoGraphs:", ex.Message);
            throw ex;
        }
    }

    private string GetCustomFileName()
    {
        try
        {
            m_strCustomFileName = System.DateTime.Now.ToString("MMddyyhhmmss");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return m_strCustomFileName;
    }
    /// <summary>
    /// Insert Attachment in Database.
    /// </summary>
    /// <returns>Integer</returns>
    private int AddAttachment()
    {
        try
        {
            InsertUpdateData();
            UploadDocuments();
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            m_objAttachment.Attachment_Table = "Carrier";
            m_objAttachment.Foreign_Key = Convert.ToInt32(ViewState["Pk_Carrier"].ToString());
            m_objAttachment.FK_Attachment_Type = Convert.ToInt32(ddlAttachType.SelectedValue);
            m_objAttachment.Attachment_Description = txtDescription.Text.Replace("'", "''");
            m_objAttachment.Attachment_Name = m_strFileName;
            m_objAttachment.Updated_By = "1";
            m_objAttachment.Update_Date = System.DateTime.Now.Date;
            Attach_Retval = m_objAttachment.InsertUpdateAttachment(m_objAttachment);


        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Attach_Retval;
    }
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        dvAttachDetails.Style["display"] = "block";
        divfirst.Style["display"] = "none";
        divsecond.Style["display"] = "none";
        divthird.Style["display"] = "block";
        divSaveView.Style["display"] = "none";
        leftDiv.Style["display"] = "block";

        btnRemove.Visible = true;
        btnMail.Visible = true;
        AddAttachment();
        if (Attach_Retval > 0)
        {
            gvAttachmentDetails.DataSource = BindAttachmentDetails();
            gvAttachmentDetails.DataBind();
        }
        // --- highlight the third menu of the Left side.
        dispTagName.Value = "divthird";
        txtDescription.Text = "";
        ddlAttachType.SelectedIndex = 1;

    }
    private List<RIMS_Base.CAttachment> BindAttachmentDetails()
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            lstAttachment = new List<RIMS_Base.CAttachment>();
            if (ViewState["Pk_Carrier"] != null && ViewState["Pk_Carrier"].ToString() != "")
                lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(ViewState["Pk_Carrier"].ToString()), "Carrier");
            else
                lstAttachment = m_objAttachment.GetAll(0, 0, "Carrier");
            return lstAttachment;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            intRetval = m_objAttachment.DeleteAttachment(Request.Form["chkItem"].ToString());
            if (intRetval <= 0)
            {

                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                if (lstAttachment.Count > 0)
                {
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                }
            }
            dvAttachDetails.Visible = true;
            dvAttachDetails.Style["display"] = "block";
            divfirst.Style["display"] = "none";
            divsecond.Style["display"] = "none";
            divthird.Style["display"] = "block";
            divSaveView.Style["display"] = "none";
            leftDiv.Style["display"] = "block";

            // --- highlight the third menu of the Left side.
            dispTagName.Value = "divthird";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region View All Main Serch Grid Functionality

    private void ViewAllFromSearchGrid()
    {
        //dispTagName.Value = "divSaveView";

        dvAttachDetails.Style["display"] = "none";
        divfirst.Style["display"] = "none";
        divsecond.Style["display"] = "none";
        divthird.Style["display"] = "none";
        divSaveView.Style["display"] = "block";
        leftDiv.Style["display"] = "none";
        divbtn.Style["display"] = "none";
        mainContent.Style["display"] = "none";

        DisplayDataInView(Convert.ToDecimal(Session["WorkerCompID"].ToString()));
        btnViewNext.Visible = true;
        btnBack.Visible = false;
    }

    protected void btnViewNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("Subrogation.aspx");
    }

    #endregion
    //#region Display Dynamic Labels
    //// -- This lables for the EDIT and ADD 
    //private void DisplayDynamicLabels()
    //{
    //    try
    //    {
    //        DataSet dstCarrier = new DataSet();
    //        objCarrier = new RIMS_Base.Biz.CCarrier();
    //        dstCarrier = objCarrier.GetCarrierLabel();
    //        for (int i = 0; i < dstCarrier.Tables[0].Rows.Count; i++)
    //        {

    //            if (dstCarrier.Tables[0].Rows[i]["Control_Type"].ToString() == "Label")
    //            {
    //                if (dstCarrier.Tables[0].Rows[i]["Control_Name"].ToString() == "Carrier Data")
    //                {
    //                    if (dstCarrier.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
    //                        ((Label)divsecond.FindControl(dstCarrier.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstCarrier.Tables[0].Rows[i]["Caption"].ToString();
    //                }
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        //throw ex;
    //    }
    //}
    //public void DisplayDynamicLabelsForViewALL()
    //{
    //    try
    //    {
    //        DataSet dstCarrier = new DataSet();
    //        objCarrier = new RIMS_Base.Biz.CCarrier();
    //        dstCarrier = objCarrier.GetCarrierLabel();
    //        for (int i = 0; i < dstCarrier.Tables[0].Rows.Count; i++)
    //        {
    //            if (dstCarrier.Tables[0].Rows[i]["Control_Type"].ToString() == "Label" && dstCarrier.Tables[0].Rows[i]["ViewAll_Label"].ToString() != String.Empty)
    //            {
    //                if (dstCarrier.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
    //                    ((Label)divSaveView.FindControl(dstCarrier.Tables[0].Rows[i]["ViewAll_Label"].ToString())).Text = dstCarrier.Tables[0].Rows[i]["caption"].ToString();
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        //throw ex;
    //    }
    //}
    //#endregion
}
