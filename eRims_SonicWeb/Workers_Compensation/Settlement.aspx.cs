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


public partial class WorkerCompensation_Settlement : System.Web.UI.Page
{
    #region variable

    RIMS_Base.Biz.cSettlement objSettlement;
    List<RIMS_Base.cSettlement> lstSettlement;
    List<RIMS_Base.CCheckRegister> lstCheckRegister = null;
    public RIMS_Base.Biz.CCheckRegister objCheckRegister;
    int settlement_RetVal = -1;
    public RIMS_Base.Biz.CGeneral objGeneral;

    // -- Attachment
    public string m_strCustomFileName = string.Empty;
    public string m_strFileName = string.Empty;
    public string m_strGlobalPath = string.Empty;
    public string m_strPath = string.Empty;
    public string m_strFolderName = "Worker_Comp_Settlement";
    public RIMS_Base.Biz.CAttachment m_objAttachment;
    List<RIMS_Base.CAttachment> lstAttachment = null;
    int Attach_Retval = -1;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserRoleId"] != null)
        {
            m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/Worker_Comp_Settlement/");
            hdnDisplay.Value = String.Empty;
            if (!IsPostBack)
            {
                btnRemove.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAttachmentDetails','Delete');");

                BindCombo();
                ViewState["YComment"] = null;
                ViewState["NComment"] = null;

                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();

                //Session["WorkerCompID"] =1;
                if (Session["WorkerCompID"] != null && Session["WorkerCompID"].ToString() != String.Empty)
                {
                    if (Session["ViewAll"] != null && Session["ViewAll"].ToString() != String.Empty)
                    {
                        DisplayDynamicLabelsForViewALL();
                        BindSettlemetDetails();
                        DisplaySinglePage();
                        btnBack.Visible = false;
                        btnSave.Visible = false;
                        btnRemove.Visible = false;
                        btnMail.Visible = false;
                    }
                    else
                    {
                        DisplayDynamicLabels();
                        BindSettlemetDetails();
                        btnBack.Visible = false;
                    }
                }
                else
                {
                    DisplayDynamicLabels();
                }
            }
        }
        else
        {
            Response.Redirect("../Signin.aspx", false);
        }
    }

    #region Bind Combos
    private void BindCombo()
    {
        objGeneral = new RIMS_Base.Biz.CGeneral();
        ddlAttachType.DataSource = objGeneral.GetAttachamentType();
        ddlAttachType.DataTextField = "FLD_Desc";
        ddlAttachType.DataValueField = "FLD_Code";
        ddlAttachType.DataBind();
        ddlAttachType.Items.Insert(0, "--Select Attachment Type--");
        ddlAttachType.SelectedIndex = 1;
    }

    #endregion

    #region Retrive Data
    private void BindSettlemetDetails()
    {
        objSettlement = new RIMS_Base.Biz.cSettlement();
        lstSettlement = new List<RIMS_Base.cSettlement>();

        try
        {
            lstSettlement = objSettlement.GetsettlementByID(Convert.ToDecimal(Session["WorkerCompID"].ToString()));

            if (lstSettlement.Count > 0)
            {
                // -- WC
                ViewState["Pk_Settlement"] = lstSettlement[0].Pk_Settlement;
                lblClaimNum.Text = lstSettlement[0].Claim_Number;
                lblFName.Text = lstSettlement[0].First_Name.Replace("''","'");
                lblLName.Text = lstSettlement[0].Last_Name.Replace("''", "'");
                if (lstSettlement[0].DOB != null)
                    lblDOB.Text = String.Format("{0:MM/dd/yyyy}", lstSettlement[0].DOB).ToString();
                if (lstSettlement[0].DOH != null)
                    lblDOH.Text = String.Format("{0:MM/dd/yyyy}", lstSettlement[0].DOH).ToString();

                lblSubid.Text = lstSettlement[0].Subsid;
                lblLoc.Text = lstSettlement[0].Location;
                lblDept.Text = lstSettlement[0].Dept;
                lblJob.Text = lstSettlement[0].JOB;
                lblCoverageState.Text = lstSettlement[0].Fk_State_of_Coverage;
                lblAcciState.Text = lstSettlement[0].FK_State_of_Accident;
                if (lstSettlement[0].DOI != null)
                    lblDOI.Text = String.Format("{0:MM/dd/yyyy}", lstSettlement[0].DOI).ToString();
                lblBodyPart.Text = lstSettlement[0].FK_Body_Parts;
                lblInjury.Text = lstSettlement[0].FK_Injury;
                lblDescription.Text = lstSettlement[0].Description;

                // -- Status
                lblTreatPhysician.Text = lstSettlement[0].Treating_Physician;
                lblDiagnosis.Text = lstSettlement[0].Diagnosis;
                if (lstSettlement[0].Last_Office_Visit_Date != null)
                    lblLastVisit.Text = String.Format("{0:MM/dd/yyyy}", lstSettlement[0].Last_Office_Visit_Date).ToString();
                if (lstSettlement[0].Next_Scheduled_Visit != null)
                    lblNextVisit.Text = String.Format("{0:MM/dd/yyyy}", lstSettlement[0].Next_Scheduled_Visit).ToString();
                if (lstSettlement[0].Referral == "Y")
                    lblReferral.Text = "Yes";
                if (lstSettlement[0].Referral == "N")
                    lblReferral.Text = "No";
                lblNewPhysician.Text = lstSettlement[0].Treating_Physician_New;
                if (lstSettlement[0].Physical_Therapy == "Y")
                    lblPhyTheraphy.Text = "Yes";
                if (lstSettlement[0].Physical_Therapy == "N")
                    lblPhyTheraphy.Text = "No";
                if (lstSettlement[0].Surgery == "Y")
                    lblSurgery.Text = "Yes";
                if (lstSettlement[0].Surgery == "N")
                    lblSurgery.Text = "No";
                if (lstSettlement[0].Off_Work == "Y")
                    lblOffWork.Text = "Yes";
                if (lstSettlement[0].Off_Work == "N")
                    lblOffWork.Text = "No";
                lblRTW.Text = lstSettlement[0].Estimated_RTW;
                lblFullDuty.Text = lstSettlement[0].Return_to_Work_Ful_Duty;
                if (lstSettlement[0].RTW_Date != null)
                    lblRTWDate.Text = String.Format("{0:MM/dd/yyyy}", lstSettlement[0].RTW_Date).ToString();
                lblRestrictedDuty.Text = lstSettlement[0].Return_Work_Restricted_Duty;
                if (lstSettlement[0].Temporary_From != null)
                    lblTempFrom.Text = String.Format("{0:MM/dd/yyyy}", lstSettlement[0].Temporary_From).ToString();
                if (lstSettlement[0].Temporary_to != null)
                    lblTempTo.Text = String.Format("{0:MM/dd/yyyy}", lstSettlement[0].Temporary_to).ToString();
                lblExplain.Text = lstSettlement[0].Explain;
                lblPermanent.Text = lstSettlement[0].Permanent_Fld;
                if (lstSettlement[0].Estimated_MMI != null)
                    lblEstiMMI.Text = String.Format("{0:MM/dd/yyyy}", lstSettlement[0].Estimated_MMI).ToString();
                if (lstSettlement[0].MMI != null)
                    lblMMI.Text = String.Format("{0:MM/dd/yyyy}", lstSettlement[0].MMI).ToString();
                if (lstSettlement[0].Estimated_Impairment != null)
                    lblEstImpair.Text = lstSettlement[0].Estimated_Impairment.ToString();
                if (lstSettlement[0].Actual_Impairment != null)
                    lblActEmpair.Text = lstSettlement[0].Actual_Impairment.ToString();
                if (lstSettlement[0].Physicians_Panel_Requested == "Y")
                    lblPanelReq.Text = "Yes";
                if (lstSettlement[0].Physicians_Panel_Requested == "N")
                    lblPanelReq.Text = "No";

                // --- Retrive the Data From the Check Register
                objCheckRegister = new RIMS_Base.Biz.CCheckRegister();

                lstCheckRegister = objCheckRegister.GetCheckRegisterByID(Convert.ToDecimal(Session["WorkerCompID"].ToString()), "Workers_Comp");

                if (lstCheckRegister.Count != 0)
                {
                    if (lstCheckRegister[0].Indemnity_Incurred != null)
                        lblIndemReserve.Text = lstCheckRegister[0].Indemnity_Incurred.ToString();
                    else
                        lblIndemReserve.Text = "0.0";
                    if (lstCheckRegister[0].Indemnity_Paid != null)
                        lblIndemPaid.Text = lstCheckRegister[0].Indemnity_Paid.ToString();
                    else
                        lblIndemPaid.Text = "0.0";
                    //if (lstCheckRegister[0].Indemnity_Outstanding != null)
                    if (lstCheckRegister[0].Indemnity_Incurred != null && lstCheckRegister[0].Indemnity_Paid != null)
                    {
                        decimal? Temp = lstCheckRegister[0].Indemnity_Incurred - lstCheckRegister[0].Indemnity_Paid;
                        lblIndemOS.Text = Temp.ToString();
                    }
                    else if (lstCheckRegister[0].Indemnity_Incurred != null && lstCheckRegister[0].Indemnity_Paid == null)
                    {
                        lblIndemOS.Text = lstCheckRegister[0].Indemnity_Incurred.ToString();
                    }
                    else if (lstCheckRegister[0].Indemnity_Incurred == null && lstCheckRegister[0].Indemnity_Paid == null)
                    {
                        lblIndemOS.Text = "0.0";
                    }
                    if (lstCheckRegister[0].Medical_Incurred != null)
                        lblMedicalReserve.Text = lstCheckRegister[0].Medical_Incurred.ToString();
                    else
                        lblMedicalReserve.Text = "0.0";
                    if (lstCheckRegister[0].Medical_Paid != null)
                        lblMedicalPaid.Text = lstCheckRegister[0].Medical_Paid.ToString();
                    else
                        lblMedicalPaid.Text = "0.0";
                    //if (lstCheckRegister[0].Medical_Outstanding != null)
                    if (lstCheckRegister[0].Medical_Incurred != null && lstCheckRegister[0].Medical_Paid != null)
                    {
                        decimal? Temp = lstCheckRegister[0].Medical_Incurred - lstCheckRegister[0].Medical_Paid;
                        lblMedicalOS.Text = Temp.ToString();
                    }
                    else if (lstCheckRegister[0].Medical_Incurred != null && lstCheckRegister[0].Medical_Paid == null)
                    {
                        lblMedicalOS.Text = lstCheckRegister[0].Medical_Incurred.ToString();
                    }
                    else if (lstCheckRegister[0].Medical_Incurred == null && lstCheckRegister[0].Medical_Paid == null)
                    {
                        lblMedicalOS.Text = "0.0";
                    }
                    if (lstCheckRegister[0].Expense_Incurred != null)
                        lblExpensesReserve.Text = lstCheckRegister[0].Expense_Incurred.ToString();
                    else
                        lblExpensesReserve.Text = "0.0";
                    if (lstCheckRegister[0].Expense_Paid != null)
                        lblExpensesPaid.Text = lstCheckRegister[0].Expense_Paid.ToString();
                    else
                        lblExpensesPaid.Text = "0.0";
                    //if (lstCheckRegister[0].Expense_Outstanding != null)
                    if (lstCheckRegister[0].Expense_Incurred != null && lstCheckRegister[0].Expense_Paid != null)
                    {
                        decimal? Temp = lstCheckRegister[0].Expense_Incurred - lstCheckRegister[0].Expense_Paid;
                        lblExpensesOS.Text = Temp.ToString();
                    }
                    else if (lstCheckRegister[0].Expense_Incurred != null && lstCheckRegister[0].Expense_Paid == null)
                    {
                        lblExpensesOS.Text = lstCheckRegister[0].Expense_Incurred.ToString();
                    }
                    else if (lstCheckRegister[0].Expense_Incurred == null && lstCheckRegister[0].Expense_Paid == null)
                    {
                        lblExpensesOS.Text = "0.0";
                    }
                    decimal? ReserveTot = 0;
                    if (lstCheckRegister[0].Indemnity_Incurred != null)
                        ReserveTot = ReserveTot + lstCheckRegister[0].Indemnity_Incurred;
                    if (lstCheckRegister[0].Medical_Incurred != null)
                        ReserveTot = ReserveTot + lstCheckRegister[0].Medical_Incurred;
                    if (lstCheckRegister[0].Expense_Incurred != null)
                        ReserveTot = ReserveTot + lstCheckRegister[0].Expense_Incurred;
                    lblTotalReserve.Text = ReserveTot.ToString();


                    decimal? PaidTot = 0;
                    if (lstCheckRegister[0].Indemnity_Paid != null)
                        PaidTot = PaidTot + lstCheckRegister[0].Indemnity_Paid;
                    if (lstCheckRegister[0].Medical_Paid != null)
                        PaidTot = PaidTot + lstCheckRegister[0].Medical_Paid;
                    if (lstCheckRegister[0].Expense_Paid != null)
                        PaidTot = PaidTot + lstCheckRegister[0].Expense_Paid;
                    lblTotalPaid.Text = PaidTot.ToString();

                    decimal? OSTot = 0;
                    OSTot = Convert.ToDecimal(lblIndemOS.Text) + Convert.ToDecimal(lblMedicalOS.Text) + Convert.ToDecimal(lblExpensesOS.Text);
                    lblTotalOS.Text = OSTot.ToString();

                }

                // -- Settlement Request
                //if(lstSettlement[0].FK_Method_Of_Settlement !=null)
                lblMethodOfSettle.Text = lstSettlement[0].FK_Method_Of_Settlement;
                lblSettleMethod.Text = lstSettlement[0].Settlement_Method;


                // -- Classification

                // -- Legal
                lblDefenseName.Text = lstSettlement[0].Defence_councils_Name;
                lblDefensePhone.Text = lstSettlement[0].Phone;
                lblClaimant.Text = lstSettlement[0].Claimant_Attorney;
                lblClaimantPhone.Text = lstSettlement[0].Phone1;

                /// --- View only
                if (lstSettlement[0].Status_Only == "Y")
                {
                    rbtnActionPaln.SelectedIndex = 0;
                    lblHStatusOnly.Text = "Yes";
                    if (lstSettlement[0].YComments != null)
                    {
                        lblHComments.Text = lstSettlement[0].YComments.Replace("~^", "<br/>");
                        txtComments.Text = lstSettlement[0].YComments.Replace("~^", "\n");
                    }
                    if (lstSettlement[0].YComments != null)
                        ViewState["YComment"] = lstSettlement[0].YComments.Replace("~^", "\n");
                    if (lstSettlement[0].NComments != null)
                        ViewState["NComment"] = lstSettlement[0].NComments.Replace("~^", "\n");

                }
                //else if (lstSettlement[0].Status_Only == "N")   //  -- Comment due to default NO is selected.
                else
                {
                    rbtnActionPaln.SelectedIndex = 1;
                    lblHStatusOnly.Text = "No";
                    if (lstSettlement[0].NComments != null)
                    {
                        lblHComments.Text = lstSettlement[0].NComments.Replace("~^", "<br/>");
                        txtComments.Text = lstSettlement[0].NComments.Replace("~^", "\n");
                    }
                    if (lstSettlement[0].YComments != null)
                        ViewState["YComment"] = lstSettlement[0].YComments.Replace("~^", "\n");
                    if (lstSettlement[0].NComments != null)
                        ViewState["NComment"] = lstSettlement[0].NComments.Replace("~^", "\n");

                }

                if (lstSettlement[0].Compensatiton == "Y")
                {
                    rbtnCompensatiton.SelectedIndex = 0;
                    lblHCompensationDenied.Text = "Yes";
                }
                else if (lstSettlement[0].Compensatiton == "N")
                {
                    rbtnCompensatiton.SelectedIndex = 1;
                    lblHCompensationDenied.Text = "No";
                }
                if (lstSettlement[0].Reimbursement == "Y")
                {
                    rbtnReimbursement.SelectedIndex = 0;
                    lblHReimburseCost.Text = "Yes";
                }
                else if (lstSettlement[0].Reimbursement == "N")
                {
                    rbtnReimbursement.SelectedIndex = 1;
                    lblHReimburseCost.Text = "No";
                }
                if (lstSettlement[0].Waive == "Y")
                {
                    rbtnWaive.SelectedIndex = 0;
                    lblHWaive.Text = "Yes";
                }
                else if (lstSettlement[0].Waive == "N")
                {
                    rbtnWaive.SelectedIndex = 1;
                    lblHWaive.Text = "No";
                }
                if (lstSettlement[0].CloseMedicals == "Y")
                {
                    rbtnCloseMedical.SelectedIndex = 0;
                    lblHCloseMedical.Text = "Yes";
                }
                else if (lstSettlement[0].CloseMedicals == "N")
                {
                    rbtnCloseMedical.SelectedIndex = 1;
                    lblHCloseMedical.Text = "No";
                }
                if (lstSettlement[0].Confidentiality == "Y")
                {
                    rbtnConfident.SelectedIndex = 0;
                    lblHConfident.Text = "Yes";
                }
                else if (lstSettlement[0].Confidentiality == "N")
                {
                    rbtnConfident.SelectedIndex = 1;
                    lblHConfident.Text = "No";
                }
                if (lstSettlement[0].OtherMedicals == "Y")
                {
                    rbtnOtherMedi.SelectedIndex = 0;
                    lblHOtherMedi.Text = "Yes";
                }
                else if (lstSettlement[0].OtherMedicals == "N")
                {
                    rbtnOtherMedi.SelectedIndex = 1;
                    lblHOtherMedi.Text = "No";
                }
                if (lstSettlement[0].PermanentTotal == "Y")
                {
                    rbtnSettlement.SelectedIndex = 0;
                    lblHSettlement.Text = "Yes";
                }
                else if (lstSettlement[0].PermanentTotal == "N")
                {
                    rbtnSettlement.SelectedIndex = 1;
                    lblHSettlement.Text = "No";
                }
                if (lstSettlement[0].Resignation == "Y")
                {
                    rbtnResignation.SelectedIndex = 0;
                    lblHResignation.Text = "Yes";
                }
                else if (lstSettlement[0].Resignation == "N")
                {
                    rbtnResignation.SelectedIndex = 1;
                    lblHResignation.Text = "No";
                }
                if (lstSettlement[0].Other == "Y")
                {
                    rbtnOther.SelectedIndex = 0;
                    lblHOther.Text = "Yes";
                }
                else if (lstSettlement[0].Other == "N")
                {
                    rbtnOther.SelectedIndex = 1;
                    lblHOther.Text = "No";
                }
                if (lstSettlement[0].ResignationDate != null)
                {
                    txtResignationDate.Text = lstSettlement[0].ResignationDate.ToString();
                    lblHResignationDate.Text = Convert.ToDateTime(lstSettlement[0].ResignationDate.ToString()).ToShortDateString();
                }
                if (lstSettlement[0].Requested_Amount != null)
                {
                    txtReqAmt.Text = lstSettlement[0].Requested_Amount.ToString();
                    lblHReqAmt.Text = String.Format("{0:c}", lstSettlement[0].Requested_Amount);
                }
                if (lstSettlement[0].Potential_Total_Exposure != null)
                {
                    txtPotential.Text = lstSettlement[0].Potential_Total_Exposure.ToString();
                    lblHPotential.Text = String.Format("{0:c}", lstSettlement[0].Potential_Total_Exposure);
                }
                if (lstSettlement[0].Settled == "Y")
                {
                    rbtnSettled.SelectedIndex = 0;
                    lblHSettled.Text = "Yes";
                }
                else if (lstSettlement[0].Settled == "N")
                {
                    rbtnSettled.SelectedIndex = 1;
                    lblHSettled.Text = "No";
                }
                if (lstSettlement[0].Amount != null)
                {
                    txtAmt.Text = lstSettlement[0].Amount.ToString();
                    lblHAmt.Text = String.Format("{0:c}", lstSettlement[0].Amount);
                }

                if (lstSettlement[0].Location_Representative != null)
                {
                    txtLocRepresent.Text = lstSettlement[0].Location_Representative.ToString();
                    lblHLocRepresent.Text = Convert.ToDateTime(lstSettlement[0].Location_Representative.ToString()).ToShortDateString();
                }
                if (lstSettlement[0].Claims_Manager != null)
                {
                    txtClaimManager.Text = lstSettlement[0].Claims_Manager.ToString();
                    lblHClaimManager.Text = Convert.ToDateTime(lstSettlement[0].Claims_Manager.ToString()).ToShortDateString();
                }
                if (lstSettlement[0].Risk_Manager != null)
                {
                    txtRiskManager.Text = lstSettlement[0].Risk_Manager.ToString();
                    lblHRiskManager.Text = Convert.ToDateTime(lstSettlement[0].Risk_Manager.ToString()).ToShortDateString(); ;
                }
                if (lstSettlement[0].Treasury != null)
                {
                    txtTreasury.Text = lstSettlement[0].Treasury.ToString();
                    lblHTreasury.Text = Convert.ToDateTime(lstSettlement[0].Treasury).ToShortDateString();
                }
                if (lstSettlement[0].CFO != null)
                {
                    txtCFO.Text = lstSettlement[0].CFO.ToString();
                    lblHCFO.Text = Convert.ToDateTime(lstSettlement[0].CFO.ToString()).ToShortDateString();
                }

                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            lstSettlement = null;
            objSettlement = null;
        }
    }
    #endregion

    #region UpdateDATA

    private void UpdateSettlement()
    {
        lstSettlement = new List<RIMS_Base.cSettlement>();
        objSettlement = new RIMS_Base.Biz.cSettlement();

        try
        {
            if (ViewState["Pk_Settlement"] != null && ViewState["Pk_Settlement"].ToString() != String.Empty)
            {
                objSettlement.Pk_Settlement = Convert.ToDecimal(ViewState["Pk_Settlement"].ToString());
                if (rbtnActionPaln.SelectedIndex == 0)
                {
                    objSettlement.Status_Only = "Y";
                    lblHStatusOnly.Text = "Yes";
                }
                else if (rbtnActionPaln.SelectedIndex == 1)
                {
                    objSettlement.Status_Only = "N";
                    lblHStatusOnly.Text = "No";
                }
                if (rbtnCompensatiton.SelectedIndex == 0)
                {
                    objSettlement.Compensatiton = "Y";
                    lblHCompensationDenied.Text = "Yes";
                }
                else if (rbtnCompensatiton.SelectedIndex == 1)
                {
                    objSettlement.Compensatiton = "N";
                    lblHCompensationDenied.Text = "No";
                }
                if (rbtnReimbursement.SelectedIndex == 0)
                {
                    objSettlement.Reimbursement = "Y";
                    lblHReimburseCost.Text = "Yes";
                }
                else if (rbtnReimbursement.SelectedIndex == 1)
                {
                    objSettlement.Reimbursement = "N";
                    lblHReimburseCost.Text = "No";
                }
                if (rbtnWaive.SelectedIndex == 0)
                {
                    objSettlement.Waive = "Y";
                    lblHWaive.Text = "Yes";
                }
                else if (rbtnWaive.SelectedIndex == 1)
                {
                    objSettlement.Waive = "N";
                    lblHWaive.Text = "No";
                }
                if (rbtnCloseMedical.SelectedIndex == 0)
                {
                    objSettlement.CloseMedicals = "Y";
                    lblHCloseMedical.Text = "Yes";
                }
                else if (rbtnCloseMedical.SelectedIndex == 1)
                {
                    objSettlement.CloseMedicals = "N";
                    lblHCloseMedical.Text = "No";
                }
                if (rbtnConfident.SelectedIndex == 0)
                {
                    objSettlement.Confidentiality = "Y";
                    lblHConfident.Text = "Yes";
                }
                else if (rbtnConfident.SelectedIndex == 1)
                {
                    objSettlement.Confidentiality = "N";
                    lblHConfident.Text = "No";
                }
                if (rbtnOtherMedi.SelectedIndex == 0)
                {
                    objSettlement.OtherMedicals = "Y";
                    lblHOtherMedi.Text = "Yes";
                }
                else if (rbtnOtherMedi.SelectedIndex == 1)
                {
                    objSettlement.OtherMedicals = "N";
                    lblHOtherMedi.Text = "No";
                }
                if (rbtnSettlement.SelectedIndex == 0)
                {
                    objSettlement.PermanentTotal = "Y";
                    lblHSettlement.Text = "Yes";
                }
                else if (rbtnSettlement.SelectedIndex == 1)
                {
                    objSettlement.PermanentTotal = "N";
                    lblHSettlement.Text = "No";
                }
                if (rbtnResignation.SelectedIndex == 0)
                {
                    objSettlement.Resignation = "Y";
                    lblHResignation.Text = "Yes";
                }
                else if (rbtnResignation.SelectedIndex == 1)
                {
                    objSettlement.Resignation = "N";
                    lblHResignation.Text = "No";
                }
                if (rbtnOther.SelectedIndex == 0)
                {
                    objSettlement.Other = "Y";
                    lblHOther.Text = "Yes";
                }
                else if (rbtnOther.SelectedIndex == 1)
                {
                    objSettlement.Other = "N";
                    lblHOther.Text = "No";
                }

                if (txtResignationDate.Text != String.Empty)
                {
                    objSettlement.ResignationDate = Convert.ToDateTime(txtResignationDate.Text);
                    lblHResignationDate.Text = Convert.ToDateTime(txtResignationDate.Text).ToShortDateString();
                }
                else
                    lblHResignationDate.Text = "";
                if (txtReqAmt.Text != String.Empty)
                {
                    objSettlement.Requested_Amount = Convert.ToDecimal(txtReqAmt.Text);
                    lblHReqAmt.Text = String.Format("{0:c}", objSettlement.Requested_Amount);
                }
                else
                    lblHReqAmt.Text = "";
                if (txtPotential.Text != String.Empty)
                {
                    objSettlement.Potential_Total_Exposure = Convert.ToDecimal(txtPotential.Text);
                    lblHPotential.Text = String.Format("{0:c}", objSettlement.Potential_Total_Exposure);
                }
                else
                    lblHPotential.Text = "";
                if (rbtnSettlement.SelectedIndex == 0)
                {
                    objSettlement.Settled = "Y";
                    lblHSettled.Text = "Yes";
                }
                else if (rbtnSettlement.SelectedIndex == 1)
                {
                    objSettlement.Settled = "N";
                    lblHSettled.Text = "No";
                }
                if (txtAmt.Text != String.Empty)
                {
                    objSettlement.Amount = Convert.ToDecimal(txtAmt.Text);
                    lblHAmt.Text = String.Format("{0:c}", objSettlement.Amount);
                }
                else
                    lblHAmt.Text = "";
                if (txtLocRepresent.Text != String.Empty)
                {
                    objSettlement.Location_Representative = Convert.ToDateTime(txtLocRepresent.Text);
                    lblHLocRepresent.Text = Convert.ToDateTime(txtLocRepresent.Text).ToShortDateString();
                }
                else
                    lblHLocRepresent.Text = "";
                if (txtClaimManager.Text != String.Empty)
                {
                    objSettlement.Claims_Manager = Convert.ToDateTime(txtClaimManager.Text);
                    lblHClaimManager.Text = Convert.ToDateTime(txtClaimManager.Text).ToShortDateString();
                }
                lblHClaimManager.Text = "";
                if (txtRiskManager.Text != String.Empty)
                {
                    objSettlement.Risk_Manager = Convert.ToDateTime(txtRiskManager.Text);
                    lblHRiskManager.Text = Convert.ToDateTime(txtRiskManager.Text).ToShortDateString();
                }
                else
                    lblHRiskManager.Text = "";
                if (txtTreasury.Text != String.Empty)
                {
                    objSettlement.Treasury = Convert.ToDateTime(txtTreasury.Text);
                    lblHTreasury.Text = Convert.ToDateTime(txtTreasury.Text).ToShortDateString();
                }
                else
                    lblHTreasury.Text = "";
                if (txtCFO.Text != String.Empty)
                {
                    objSettlement.CFO = Convert.ToDateTime(txtCFO.Text);
                    lblHCFO.Text = Convert.ToDateTime(txtCFO.Text).ToShortDateString();
                }
                lblHCFO.Text = "";
                objSettlement.Update_Date = DateTime.Now;
                objSettlement.Updated_By = "1";

                settlement_RetVal = objSettlement.InsertUpdate_settlement(objSettlement);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            lstSettlement = null;
            objSettlement = null;
        }
    }

    #endregion

    protected void rbtnResignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnResignation.SelectedIndex == 0)
        {
            txtResignationDate.Enabled = true;
            imgResignationDate.Disabled = false;
        }
        else if (rbtnResignation.SelectedIndex == 1)
        {
            txtResignationDate.Text = "";
            txtResignationDate.Enabled = false;
            imgResignationDate.Disabled = true;
        }
        divfourth.Style["display"] = "none";
        divfifth.Style["display"] = "block";
    }
    protected void rbtnActionPaln_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnActionPaln.SelectedIndex == 0)
        {
            if (ViewState["YComment"] != null && ViewState["YComment"].ToString() != String.Empty)
            {
                txtComments.Text = "";
                lblHComments.Text = "";
                txtComments.Text = ViewState["YComment"].ToString();
                lblHComments.Text = ViewState["YComment"].ToString().Replace("\n", "<br/>");
            }
            else
            {
                txtComments.Text = "";
                lblHComments.Text = "";
            }
        }
        else
        {
            if (ViewState["NComment"] != null && ViewState["NComment"].ToString() != String.Empty)
            {
                txtComments.Text = ViewState["NComment"].ToString();
                lblHComments.Text = ViewState["NComment"].ToString().Replace("\n", "<br/>");
            }
            else
            {
                txtComments.Text = "";
                lblHComments.Text = "";
            }
        }
        hdnDisplay.Value = "divfour";
        divfirst.Style["display"] = "none";
        divfourth.Style["display"] = "block";
        divfifth.Style["display"] = "none";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Settlement_View.aspx");
        UpdateSettlement();
        DisplaySinglePage();
        btnBack.Visible = true;
        btnSave.Visible = false;
        btnPDF.Visible = false;
        btnRemove.Visible = false;
        btnMail.Visible = false;
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        DisplayEditControl();
        btnBack.Visible = false;
        btnSave.Visible = true;
        btnPDF.Visible = true;
        if (gvAttachmentDetails.Rows.Count > 0)
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

    #region Attachment

    protected void gvAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
                //((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=Worker_Comp_Settlement&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
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
            UpdateSettlement();
            UploadDocuments();
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            m_objAttachment.Attachment_Table = "Settlement";
            m_objAttachment.Foreign_Key = Convert.ToInt32(ViewState["Pk_Settlement"].ToString());
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
        AddAttachment();
        if (Attach_Retval > 0)
        {
            gvAttachmentDetails.DataSource = BindAttachmentDetails();
            gvAttachmentDetails.DataBind();
        }

        // --- highlight the third menu of the Left side.
        hdnDisplay.Value = "diveight";
        txtDescription.Text = "";
        ddlAttachType.SelectedIndex = 1;

    }
    private List<RIMS_Base.CAttachment> BindAttachmentDetails()
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            lstAttachment = new List<RIMS_Base.CAttachment>();

            if (ViewState["Pk_Settlement"] != null && ViewState["Pk_Settlement"].ToString() != "")
                lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(ViewState["Pk_Settlement"].ToString()), "Settlement");
            else
                lstAttachment = m_objAttachment.GetAll(0, 0, "Settlement");

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
            Attach_Retval = m_objAttachment.DeleteAttachment(Request.Form["chkItem"].ToString());
            if (Attach_Retval <= 0)
            {

                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
            }
            // --- highlight the third menu of the Left side.
            hdnDisplay.Value = "diveight";

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region Enabled/Disabled Controls

    private void EnabledDisabled()
    {
        rbtnActionPaln.Enabled = false;
        rbtnCompensatiton.Enabled = false;
        rbtnReimbursement.Enabled = false;
        rbtnWaive.Enabled = false;
        rbtnCloseMedical.Enabled = false;
        rbtnConfident.Enabled = false;
        rbtnOtherMedi.Enabled = false;
        rbtnSettlement.Enabled = false;
        rbtnResignation.Enabled = false;
        rbtnOther.Enabled = false;
        rbtnSettled.Enabled = false;

        imgResignationDate.Disabled = true;
        txtResignationDate.Enabled = false;
        txtReqAmt.Enabled = false;
        txtPotential.Enabled = false;
        txtAmt.Enabled = false;
        txtLocRepresent.Enabled = false;
        imgLocRepresent.Disabled = true;
        txtClaimManager.Enabled = false;
        imgClaimManager.Disabled = true;
        txtRiskManager.Enabled = false;
        imgRiskManager.Disabled = true;
        txtTreasury.Enabled = false;
        imgTreasury.Disabled = true;
        txtCFO.Enabled = false;
        imgCFO.Disabled = true;

        ddlAttachType.Enabled = false;
        txtDescription.Enabled = false;
        uplCommon.Enabled = false;
        btnAddAttachment.Enabled = false;
        btnRemove.Enabled = false;
        btnMail.Enabled = false;
        divAttachment.Style["display"] = "none";

        Span1.Visible = false;
        Span2.Visible = false;
        Span3.Visible = false;
    }

    #endregion

    #region Display Single Page For the Both View

    private void DisplaySinglePage()
    {
        leftdiv.Visible = false;
        mainContent.Style["width"] = "97%";
        divsecond.Style["display"] = "block";
        divthird.Style["display"] = "block";
        divfourth.Style["display"] = "block";
        divfifth.Style["display"] = "block";
        divsix.Style["display"] = "block";
        divseven.Style["display"] = "block";
        diveight.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        divAttachment.Style["display"] = "none";


        lblHStatusOnly.Visible = true;
        rbtnActionPaln.Visible = false;
        lblHCompensationDenied.Visible = true;
        rbtnCompensatiton.Visible = false;
        lblHReimburseCost.Visible = true;
        rbtnReimbursement.Visible = false;
        lblHWaive.Visible = true;
        rbtnWaive.Visible = false;
        lblHCloseMedical.Visible = true;
        rbtnCloseMedical.Visible = false;
        lblHConfident.Visible = true;
        rbtnConfident.Visible = false;
        lblHOtherMedi.Visible = true;
        rbtnOtherMedi.Visible = false;
        lblHSettlement.Visible = true;
        rbtnSettlement.Visible = false;
        lblHResignation.Visible = true;
        rbtnResignation.Visible = false;
        lblHOther.Visible = true;
        rbtnOther.Visible = false;
        lblHResignationDate.Visible = true;
        txtResignationDate.Visible = false;
        lblHReqAmt.Visible = true;
        txtReqAmt.Visible = false;
        lblHPotential.Visible = true;
        txtPotential.Visible = false;
        lblHSettled.Visible = true;
        rbtnSettled.Visible = false;
        lblHAmt.Visible = true;
        txtAmt.Visible = false;
        lblHLocRepresent.Visible = true;
        txtLocRepresent.Visible = false;
        lblHClaimManager.Visible = true;
        txtClaimManager.Visible = false;
        lblHRiskManager.Visible = true;
        txtRiskManager.Visible = false;
        lblHTreasury.Visible = true;
        txtTreasury.Visible = false;
        lblHCFO.Visible = true;
        txtCFO.Visible = false;
        lblHComments.Visible = true;
        txtComments.Visible = false;
        ibtnComment.Visible = false;

        imgCFO.Visible = false;
        imgClaimManager.Visible = false;
        imgLocRepresent.Visible = false;
        imgResignationDate.Visible = false;
        imgRiskManager.Visible = false;
        imgTreasury.Visible = false;

        gvAttachmentDetails.Columns[0].Visible = false;

        Span1.Visible = false;
        Span2.Visible = false;
        Span3.Visible = false;
    }

    #endregion

    #region Back To Edit Page

    private void DisplayEditControl()
    {
        leftdiv.Visible = true;
        mainContent.Style["width"] = "79%";
        divfifth.Style["display"] = "block";
        divsecond.Style["display"] = "none";
        divthird.Style["display"] = "none";
        divfourth.Style["display"] = "none";
        divfifth.Style["display"] = "none";
        divsix.Style["display"] = "none";
        divseven.Style["display"] = "none";
        diveight.Style["display"] = "none";
        divbtn.Style["display"] = "block";
        divfirst.Style["display"] = "block";
        divAttachment.Style["display"] = "block";

        lblHStatusOnly.Visible = false;
        rbtnActionPaln.Visible = true;
        lblHCompensationDenied.Visible = false;
        rbtnCompensatiton.Visible = true;
        lblHReimburseCost.Visible = false;
        rbtnReimbursement.Visible = true;
        lblHWaive.Visible = false;
        rbtnWaive.Visible = true;
        lblHCloseMedical.Visible = false;
        rbtnCloseMedical.Visible = true;
        lblHConfident.Visible = false;
        rbtnConfident.Visible = true;
        lblHOtherMedi.Visible = false;
        rbtnOtherMedi.Visible = true;
        lblHSettlement.Visible = false;
        rbtnSettlement.Visible = true;
        lblHResignation.Visible = false;
        rbtnResignation.Visible = true;
        lblHOther.Visible = false;
        rbtnOther.Visible = true;
        lblHResignationDate.Visible = false;
        txtResignationDate.Visible = true;
        lblHReqAmt.Visible = false;
        txtReqAmt.Visible = true;
        lblHPotential.Visible = false;
        txtPotential.Visible = true;
        lblHSettled.Visible = false;
        rbtnSettled.Visible = true;
        lblHAmt.Visible = false;
        txtAmt.Visible = true;
        lblHLocRepresent.Visible = false;
        txtLocRepresent.Visible = true;
        lblHClaimManager.Visible = false;
        txtClaimManager.Visible = true;
        lblHRiskManager.Visible = false;
        txtRiskManager.Visible = true;
        lblHTreasury.Visible = false;
        txtTreasury.Visible = true;
        lblHCFO.Visible = false;
        txtCFO.Visible = true;
        lblHComments.Visible = false;
        txtComments.Visible = true;
        ibtnComment.Visible = true;

        imgCFO.Visible = true;
        imgClaimManager.Visible = true;
        imgLocRepresent.Visible = true;
        imgResignationDate.Visible = true;
        imgRiskManager.Visible = true;
        imgTreasury.Visible = true;

        gvAttachmentDetails.Columns[0].Visible = true;

        Span1.Visible = true;
        Span2.Visible = true;
        Span3.Visible = true;
    }

    #endregion

    #region Display Dynamic Labels
    // -- This lables for the EDIT and ADD 
    private void DisplayDynamicLabels()
    {
        try
        {
            DataSet dstSettlement = new DataSet();
            objSettlement = new RIMS_Base.Biz.cSettlement();
            dstSettlement = objSettlement.GetSettlementLabel();
            for (int i = 0; i < dstSettlement.Tables[0].Rows.Count; i++)
            {

                if (dstSettlement.Tables[0].Rows[i]["Control_Type"].ToString() == "Label")
                {
                    if (dstSettlement.Tables[0].Rows[i]["Control_Name"].ToString() == "Worker's Compensation")
                    {
                        if (dstSettlement.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                            ((Label)divfirst.FindControl(dstSettlement.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstSettlement.Tables[0].Rows[i]["Caption"].ToString();
                    }
                    if (dstSettlement.Tables[0].Rows[i]["Control_Name"].ToString() == "Status")
                    {
                        if (dstSettlement.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                            ((Label)divsecond.FindControl(dstSettlement.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstSettlement.Tables[0].Rows[i]["Caption"].ToString();
                    }
                    if (dstSettlement.Tables[0].Rows[i]["Control_Name"].ToString() == "Settlement Request")
                    {
                        if (dstSettlement.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                            ((Label)divfourth.FindControl(dstSettlement.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstSettlement.Tables[0].Rows[i]["Caption"].ToString();
                    }
                    if (dstSettlement.Tables[0].Rows[i]["Control_Name"].ToString() == "Classification")
                    {
                        if (dstSettlement.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                            ((Label)divfifth.FindControl(dstSettlement.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstSettlement.Tables[0].Rows[i]["Caption"].ToString();
                    }
                    if (dstSettlement.Tables[0].Rows[i]["Control_Name"].ToString() == "Legal")
                    {
                        if (dstSettlement.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                            ((Label)divsix.FindControl(dstSettlement.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstSettlement.Tables[0].Rows[i]["Caption"].ToString();
                    }

                }
            }

        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }
    public void DisplayDynamicLabelsForViewALL()
    {
        try
        {
            DataSet dstSettlement = new DataSet();
            objSettlement = new RIMS_Base.Biz.cSettlement();
            dstSettlement = objSettlement.GetSettlementLabel();
            for (int i = 0; i < dstSettlement.Tables[0].Rows.Count; i++)
            {
                if (dstSettlement.Tables[0].Rows[i]["Control_Name"].ToString() == "Worker's Compensation")
                {
                    if (dstSettlement.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                        ((Label)divfirst.FindControl(dstSettlement.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstSettlement.Tables[0].Rows[i]["Caption"].ToString();
                }
                if (dstSettlement.Tables[0].Rows[i]["Control_Name"].ToString() == "Status")
                {
                    if (dstSettlement.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                        ((Label)divsecond.FindControl(dstSettlement.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstSettlement.Tables[0].Rows[i]["Caption"].ToString();
                }
                if (dstSettlement.Tables[0].Rows[i]["Control_Name"].ToString() == "Settlement Request")
                {
                    if (dstSettlement.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                        ((Label)divfourth.FindControl(dstSettlement.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstSettlement.Tables[0].Rows[i]["Caption"].ToString();
                }
                if (dstSettlement.Tables[0].Rows[i]["Control_Name"].ToString() == "Classification")
                {
                    if (dstSettlement.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                        ((Label)divfifth.FindControl(dstSettlement.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstSettlement.Tables[0].Rows[i]["Caption"].ToString();
                }
                if (dstSettlement.Tables[0].Rows[i]["Control_Name"].ToString() == "Legal")
                {
                    if (dstSettlement.Tables[0].Rows[i]["caption"].ToString().Trim() != String.Empty)
                        ((Label)divsix.FindControl(dstSettlement.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstSettlement.Tables[0].Rows[i]["Caption"].ToString();
                }
            }

        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }
    #endregion

    #region Generate PDF

    public void btnPDF_Click(object sender, EventArgs e)
    {
        try
        {

            rptViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            rptViewer.ServerReport.ReportServerUrl = new System.Uri(System.Configuration.ConfigurationSettings.AppSettings["ReportingService.reportservice"]);
            rptViewer.ServerReport.ReportPath = System.Configuration.ConfigurationSettings.AppSettings["ReportPath"] + Request["Path"] + "/rpt_FCISettlement";
            rptViewer.AsyncRendering = false;
            Microsoft.Reporting.WebForms.ReportParameter p1 = new Microsoft.Reporting.WebForms.ReportParameter("FK_Table_name", Session["WorkerCompID"].ToString());
            rptViewer.ServerReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter[] { p1 });
            rptViewer.ServerReport.Refresh();


            string mimeType, encoding, extension, deviceInfo;
            string[] streamids;
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string format = "PDF"; //Desired format goes here (PDF, Excel, or Image)
            deviceInfo =
            "<DeviceInfo>" +
            "<SimplePageHeaders>True</SimplePageHeaders>" +
            "</DeviceInfo>";
            byte[] bytes = rptViewer.ServerReport.Render(format, deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
            //Response.Clear();

            if (format == "PDF")
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-disposition", "attachment;filename=settlement.pdf");
            }
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.Flush();
            Response.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion
}
