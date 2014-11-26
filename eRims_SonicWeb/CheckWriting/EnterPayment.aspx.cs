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
using System.Globalization;
/* 0=Initial
 * 1=Printed
 * 2=Reprint
 * 3=Stopped Payment
 * 4=Void
 * 5=OtherType of Payment
 * This Detail will ve stored in Check_Status field and based on that
 * appropriate change will be done in other suppose check_status is 1
 * then also Printed_Check will become 1 same if 4 then Void Status
 * will become 1 from 0 so we can track from both Way.
*/
public partial class CheckWriting_EnterPayment : System.Web.UI.Page
{
    #region Public Variables
    public RIMS_Base.Biz.CAppliedPayment m_objAppliedPayment;
    public List<RIMS_Base.CAppliedPayment> lstAppliedPayment;
    public RIMS_Base.Biz.CBankDetails m_objBankDetails;
    public List<RIMS_Base.CBankDetails> lstBankDetails;
    public RIMS_Base.Biz.CCheckWriting m_objCheckWriting;
    public RIMS_Base.Biz.CCheckDetails m_objCheckDetails;
    public RIMS_Base.Biz.CCheckWriting m_objClaimReservesInfo;
    List<RIMS_Base.CCheckWriting> lstClaimReservesInfo = null;
    public RIMS_Base.Biz.CVendor m_objVendorType;
    List<RIMS_Base.CVendor> lstVendorType = null;
    public RIMS_Base.Biz.CGeneral m_objSuppDocs;
    List<RIMS_Base.CGeneral> lstSuppDocs = null;
    public RIMS_Base.Biz.CGeneral m_objPayCode;
    List<RIMS_Base.CGeneral> lstPayCode = null;
    public RIMS_Base.Biz.CCheckWriting m_objPaymentType;
    List<RIMS_Base.CCheckWriting> lstPaymentType = null;
    public RIMS_Base.Biz.CCheckDetails m_objCDAEP;
    public List<RIMS_Base.CCheckDetails> lstCDAEP;
    ListItem m_lstCommon;
    public string m_strTableName = string.Empty;
    IFormatProvider format = new CultureInfo("en-US");
    int m_intRetval = -1;
    int m_intRetvalCD = -1;
    //int m_intRetvalAP = -1;
    public string m_strJScipt;
    public int m_intCounter = 0;
    public decimal m_dExistAmt;
    public decimal m_dCurrAmt;
    public string ClaimType = string.Empty;
    #endregion
    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        //m_strJScipt="<script type=text/javascript>MadeReadOnly();</script>";

        dvchkDetails.Visible = false;
        if (!IsPostBack)
        {
            if (Session["LastClaimNumber"] != null)
                txtSearchClaimNo.Text = Session["LastClaimNumber"].ToString();
            if (Request.QueryString.Count > 0)
            {

                btnPayTo.Attributes.Add("onclick", "javascript:return openWindow();");
                rdbLstPayee.Attributes.Add("onclick", "javascript:return btnClaimVendor();");
                if (BindClaimAndReservesData())
                {
                    dventerPayment.Visible = true;
                    dvSearch.Visible = false;
                    BindClaimData();
                    BindDropDown();
                }
                else
                {
                    lblSearchMsg.Text = "The claim entered was not found. Please re-enter another claim number";
                }
            }
            else
            {
                dvSearch.Visible = true;
                dventerPayment.Visible = false;
                btnPayTo.Attributes.Add("onclick", "javascript:return openWindow();");
                //ddlPaymentType.Attributes.Add("onchange", "javascript:return  onChangePayment();");

                //btnSave.Attributes.Add("onclick", "javascript:return checkPayment();");
                //rdblstRecPayment.Attributes.Add("onclick", "javascript:return recDisable();");
                rdbLstPayee.Attributes.Add("onclick", "javascript:return btnClaimVendor();");
                //rdbLstPrintCheck.Attributes.Add("onclick", "javascript:return OkayChkPrint();");

            }
        }
        if (rdbLstPayee.SelectedValue == "V")
            btnPayTo.Enabled = true;
        else
            btnPayTo.Enabled = false;
        if (rdblstRecPayment.SelectedValue == "Y")
        {
            rfvDtRecBegin.Visible = true;
            rfvNoRecPayment.Visible = true;
            rfvRecPeriod.Visible = true;
        }
        else
        {
            rfvDtRecBegin.Visible = false;
            rfvNoRecPayment.Visible = false;
            rfvRecPeriod.Visible = false;
        }
        if (rdblstRecPayment.SelectedValue == "Y")
        {
            txtNoOfRecPayment.ReadOnly = false;
            txtReccPeriod.ReadOnly = false;
            imgRecBegin.Disabled = false;
            txtDtRecBegin.ReadOnly = false;
            rdbLstChkType.SelectedValue = "R";
            rfvDtRecBegin.Visible = true;
            rfvNoRecPayment.Visible = true;
            rfvRecPeriod.Visible = true;

        }
        else
        {
            txtNoOfRecPayment.ReadOnly = true;
            txtReccPeriod.ReadOnly = true;
            imgRecBegin.Disabled = true;
            txtDtRecBegin.ReadOnly = true;
            rdbLstChkType.SelectedValue = "O";
            rfvDtRecBegin.Visible = false;
            rfvNoRecPayment.Visible = false;
            rfvRecPeriod.Visible = false;
        }
        //lblScript.Text = m_strJScipt;
        lblScript.Text = string.Empty;
        lblSearchMsg.Text = string.Empty;
        lblDtRecEnd.Text = string.Empty;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //if (ValidateAmount())
            {
                m_objClaimReservesInfo = new RIMS_Base.Biz.CCheckWriting();
                lstClaimReservesInfo = new List<RIMS_Base.CCheckWriting>();
                if (txtSearchClaimNo.Text != string.Empty)
                {
                    lstClaimReservesInfo = m_objClaimReservesInfo.GetClaimInfoByClaimNo(txtSearchClaimNo.Text);
                }
                else
                {
                    lstClaimReservesInfo = m_objClaimReservesInfo.GetClaimInfoByClaimNo(lblClaimNo.Text);
                }
                //if (ddlPaymentType.SelectedValue == "1")
                //{
                if (rdblstRecPayment.SelectedValue == "Y")
                {
                    InsertRecCheck();
                }
                else
                {
                    InsertOrignalCheck();
                }
                //}
                //else
                //{
                //    InsertOtherPayment();
                //}
                if (rdblstRecPayment.SelectedValue == "Y")
                {
                    trRec.Visible = true;
                    SetRecEndDate();
                }
                else
                {
                    trRec.Visible = false;

                }
            }
            //else
            //{
            //    lblScript.Text = "Entered Amount is Greater than "+ ddlPayId.SelectedValue +" Outstanding Amount";
            //}
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void ddlPayId_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPayCode.DataSource = GetPayCode();
        ddlPayCode.DataTextField = "Trans_Code_Description";
        ddlPayCode.DataValueField = "Trans_Code_Description";
        ddlPayCode.DataBind();
        m_lstCommon = new ListItem("--Select Paycode--", "0");
        ddlPayCode.Items.Insert(0, m_lstCommon);
    }
    protected void ddlPaymentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtdtChkInput.Text = string.Empty;
            txtDtChkIssue.Text = string.Empty;
            txtNoOfRecPayment.Text = "1";
            txtReccPeriod.Text = string.Empty;
            txtDtRecBegin.Text = string.Empty;
            lblDtRecEnd.Text = string.Empty;
            rdblstRecPayment.SelectedValue = "N";

            if (ddlPaymentType.SelectedValue == "1")
            {
                imgChkInput.Disabled = false;
                txtdtChkInput.ReadOnly = false;
                rfvDtInput.Enabled = true;

                imgChkIssue.Disabled = false;
                txtDtChkIssue.ReadOnly = false;
                rfvDtIssue.Enabled = true;

                rdblstRecPayment.Enabled = true;
                //Make them Read Only bcz will be editable on tick rec payment yes. 
                txtNoOfRecPayment.ReadOnly = true;
                txtReccPeriod.ReadOnly = true;
                imgRecBegin.Disabled = true;
                txtDtRecBegin.ReadOnly = true;



                rdbLstChkType.Enabled = true;
            }
            else
            {
                imgChkInput.Disabled = true;
                txtdtChkInput.ReadOnly = true;
                rfvDtInput.Enabled = false;

                imgChkIssue.Disabled = true;
                txtDtChkIssue.ReadOnly = true;
                rfvDtIssue.Enabled = false;

                rdblstRecPayment.Enabled = false;

                txtNoOfRecPayment.ReadOnly = true;
                txtReccPeriod.ReadOnly = true;
                imgRecBegin.Disabled = true;
                txtDtRecBegin.ReadOnly = true;

                rdbLstChkType.Enabled = false;
            }
            if (rdbLstPayee.SelectedValue == "V")
            {
                btnPayTo.Enabled = true;
                //txtPayTo.Text = string.Empty;
            }
            else
            {
                btnPayTo.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void rdblstRecPayment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdblstRecPayment.SelectedValue == "Y")
        {
            txtNoOfRecPayment.ReadOnly = false;
            txtReccPeriod.ReadOnly = false;
            imgRecBegin.Disabled = false;
            txtDtRecBegin.ReadOnly = false;
            rdbLstChkType.SelectedValue = "R";
            rfvDtRecBegin.Visible = true;
            rfvNoRecPayment.Visible = true;
            rfvRecPeriod.Visible = true;

        }
        else
        {
            txtNoOfRecPayment.ReadOnly = true;
            txtReccPeriod.ReadOnly = true;
            imgRecBegin.Disabled = true;
            txtDtRecBegin.ReadOnly = true;
            rdbLstChkType.SelectedValue = "O";
            rfvDtRecBegin.Visible = false;
            rfvNoRecPayment.Visible = false;
            rfvRecPeriod.Visible = false;
        }
    }
    #endregion
    #region Private Method
    private void InsertOtherPayment()
    {
        m_objCheckWriting = new RIMS_Base.Biz.CCheckWriting();
        m_objCheckWriting.Pk_check_no = 0;
        m_objCheckWriting.Table_Name = lstClaimReservesInfo[0].TableName;
        m_objCheckWriting.TableFK = lstClaimReservesInfo[0].TableFK;
        m_objCheckWriting.Check_Number = 0;
        m_objCheckWriting.Claimant_Vendor = rdbLstPayee.SelectedValue;
        if (rdbLstPayee.SelectedValue == "V")
            m_objCheckWriting.C_V_FK = Convert.ToDecimal(Request.Form[txtVendorId.UniqueID].ToString());
        else
            m_objCheckWriting.C_V_FK = lstClaimReservesInfo[0].Employee_Claimant;

        m_objCheckWriting.Payment_Id = ddlPayId.SelectedValue;
        m_objCheckWriting.Paycode = ddlPayCode.SelectedValue;
        m_objCheckWriting.Payment_Amount = Convert.ToDecimal(txtPayAmount.Text);
        m_objCheckWriting.Service_Begin = Convert.ToDateTime(txtDtSBegin.Text);
        m_objCheckWriting.Service_End = Convert.ToDateTime(txtDtSEnd.Text); ;
        m_objCheckWriting.Recurring_Payments = "N";
        m_objCheckWriting.Recurring_Number = 0;//txtNoOfRecPayment.Text == string.Empty ? 0 : Convert.ToDecimal(txtNoOfRecPayment.Text);
        m_objCheckWriting.Recurring_Period = 0;// txtReccPeriod.Text == string.Empty ? 0 : Convert.ToDecimal(txtReccPeriod.Text);
        m_objCheckWriting.Updated_By = "1";
        m_objCheckWriting.Updated_Date = System.DateTime.Now.Date;
        m_objCheckWriting.Payment_Type = 1; //Convert.ToDecimal(ddlPaymentType.SelectedValue);
        m_objCheckWriting.FK_Supp_Doc_Type = Convert.ToDecimal(ddlPaySuppType.SelectedValue);
        if (txtDtDoc.Text != string.Empty)
            m_objCheckWriting.Doc_Date = Convert.ToDateTime(txtDtDoc.Text, format).Date;

        m_objCheckWriting.Document_Number = txtDocNo.Text;
        m_objCheckWriting.Invoice_Number = txtInvoiceNo.Text;
        m_objCheckWriting.FK_Bank = Convert.ToDecimal(ddlBank.SelectedValue);
        //Is vendor or claimant based on checkbox or vendor popup.
        if (rdbLstPayee.SelectedValue == "V")
        {
            m_objCheckWriting.FK_Payee = Convert.ToDecimal(Request.Form[txtVendorId.UniqueID].ToString());
            m_objCheckWriting.FK_Table_Payee = "Vendor";
        }
        else
        {
            m_objCheckWriting.FK_Payee = lstClaimReservesInfo[0].Employee_Claimant;
            if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
            {

                m_objCheckWriting.FK_Table_Payee = "Employee";
            }
            else
            {

                m_objCheckWriting.FK_Table_Payee = "Claimant";
            }
        }
        m_objCheckWriting.FK_Payer = lstClaimReservesInfo[0].Employee_Claimant;
        if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
        {
            m_objCheckWriting.FK_Table_Payer = "Employee";
        }
        else
        {
            m_objCheckWriting.FK_Table_Payer = "Claimant";
        }
        //Employee
        m_objCheckWriting.Comments = txtComment.Text;
        m_intRetval = m_objCheckWriting.InsertUpdate_CheckWriting(m_objCheckWriting);
        if (m_intRetval > 0)
        {

            m_objCheckDetails = new RIMS_Base.Biz.CCheckDetails();
            m_objCheckDetails.Pk_check_no = 0;
            m_objCheckDetails.Check_status = "5";
            m_objCheckDetails.Current_Recurring_Number = 0;
            m_objCheckDetails.Original_Recurring = "0";
            m_objCheckDetails.Check_Amount = Convert.ToDecimal(txtPayAmount.Text);
            m_objCheckDetails.Check_FK = m_intRetval;
            m_objCheckDetails.Updated_By = "1";
            m_objCheckDetails.Updated_Date = System.DateTime.Now.Date;
            m_intRetvalCD = m_objCheckDetails.InsertUpdate_CheckDetails(m_objCheckDetails);

        }
        if (m_intRetval > 0 && m_intRetvalCD > 0)
        {

            dvchkDetails.Visible = true;
            BindCDAEPData(m_intRetval);
            dventerPayment.Visible = false;
            dvSearch.Visible = false;
        }
    }
    /// <summary>
    /// Insert Recurring Check.
    /// </summary>
    private void InsertRecCheck()
    {
        /* 0=Initial
        * 1=Printed
        * 2=Reprint
        * 3=Stopped Payment
        * 4=Void
        * 5=OtherType of Payment wire etc.
        * This Detail will ve stored in Check_Status field and based on that
        * appropriate change will be done in other suppose check_status is 1
        * then also Printed_Check will become 1 same if 4 then Void Status
        * will become 1 from 0 so we can track from both Way.
       */
        m_objCheckWriting = new RIMS_Base.Biz.CCheckWriting();
        m_objCheckWriting.Pk_check_no = 0;
        m_objCheckWriting.Table_Name = lstClaimReservesInfo[0].TableName;
        m_objCheckWriting.TableFK = lstClaimReservesInfo[0].TableFK;
        m_objCheckWriting.Check_Number = 1;
        m_objCheckWriting.Input_Date = Convert.ToDateTime(txtdtChkInput.Text, format).Date;
        m_objCheckWriting.Issue_date = Convert.ToDateTime(txtDtChkIssue.Text, format).Date;
        m_objCheckWriting.Claimant_Vendor = rdbLstPayee.SelectedValue;
        if (rdbLstPayee.SelectedValue == "V")
            m_objCheckWriting.C_V_FK = Convert.ToDecimal(Request.Form[txtVendorId.UniqueID].ToString());
        else
            m_objCheckWriting.C_V_FK = lstClaimReservesInfo[0].Employee_Claimant;

        m_objCheckWriting.Payment_Id = ddlPayId.SelectedValue;
        m_objCheckWriting.Paycode = ddlPayCode.SelectedValue;
        m_objCheckWriting.Payment_Amount = Convert.ToDecimal(txtPayAmount.Text);
        m_objCheckWriting.Service_Begin = Convert.ToDateTime(txtDtSBegin.Text);
        m_objCheckWriting.Service_End = Convert.ToDateTime(txtDtSEnd.Text); ;
        m_objCheckWriting.Recurring_Payments = rdblstRecPayment.SelectedValue;
        m_objCheckWriting.Recurring_Number = txtNoOfRecPayment.Text == string.Empty ? 0 : Convert.ToDecimal(txtNoOfRecPayment.Text);
        m_objCheckWriting.Recurring_Period = txtReccPeriod.Text == string.Empty ? 0 : Convert.ToDecimal(txtReccPeriod.Text);
        m_objCheckWriting.Recurring_Begin_Date = Convert.ToDateTime(txtDtRecBegin.Text, format).Date;
        //m_objCheckWriting.Recurring_End_Date = Convert.ToDateTime(txtDtRecEnd.Text, format).Date;
        m_objCheckWriting.Recurring_End_Date = Convert.ToDateTime(txtDtRecBegin.Text).AddDays(txtReccPeriod.Text == "" ? 0 : Convert.ToDouble(txtReccPeriod.Text) * Convert.ToDouble(m_objCheckWriting.Recurring_Number));
        //m_objCheckWriting.Stop_Recurring="";
        m_objCheckWriting.Updated_By = "1";
        m_objCheckWriting.Updated_Date = System.DateTime.Now.Date;
        //m_objCheckWriting.Current_Recurring_Number=0;
        //m_objCheckWriting.Next_due_date="";
        m_objCheckWriting.Payment_Type = 1;//Convert.ToDecimal(ddlPaymentType.SelectedValue);
        m_objCheckWriting.FK_Supp_Doc_Type = Convert.ToDecimal(ddlPaySuppType.SelectedValue);
        if (txtDtDoc.Text != string.Empty)
            m_objCheckWriting.Doc_Date = Convert.ToDateTime(txtDtDoc.Text, format).Date;

        m_objCheckWriting.Document_Number = txtDocNo.Text;
        m_objCheckWriting.Invoice_Number = txtInvoiceNo.Text;
        m_objCheckWriting.FK_Bank = Convert.ToDecimal(ddlBank.SelectedValue);
        //Is vendor or claimant based on checkbox or vendor popup.
        if (rdbLstPayee.SelectedValue == "V")
        {
            m_objCheckWriting.FK_Payee = Convert.ToDecimal(Request.Form[txtVendorId.UniqueID].ToString());
            m_objCheckWriting.FK_Table_Payee = "Vendor";
        }
        else
        {
            if (lstClaimReservesInfo[0].TableName == "Workers_Comp")
            {
                m_objCheckWriting.FK_Payee = lstClaimReservesInfo[0].FK_Claimant;
            }
            else
            {

                m_objCheckWriting.FK_Payee = lstClaimReservesInfo[0].FK_ECD_Id;
            }
            if (lstClaimReservesInfo[0].FK_Claimant_id.ToString() == "1")
            {

                m_objCheckWriting.FK_Table_Payee = "Employee";
            }
            else
            {

                m_objCheckWriting.FK_Table_Payee = "Claimant";
            }
        }
        m_objCheckWriting.FK_Payer = lstClaimReservesInfo[0].FK_Claimant;
        if (lstClaimReservesInfo[0].FK_Claimant_id.ToString() == "1")
        {
            m_objCheckWriting.FK_Table_Payer = "Employee";
        }
        else
        {
            m_objCheckWriting.FK_Table_Payer = "Claimant";
        }
        //Employee

        m_objCheckWriting.Comments = txtComment.Text;
        m_intRetval = m_objCheckWriting.InsertUpdate_CheckWriting(m_objCheckWriting);
        if (m_intRetval > 0)
        {

            m_intCounter = txtNoOfRecPayment.Text == string.Empty ? 0 : Convert.ToInt32(txtNoOfRecPayment.Text);
            for (int m_intTemp = 0; m_intTemp < m_intCounter; m_intTemp++)
            {
                m_objCheckDetails = new RIMS_Base.Biz.CCheckDetails();
                m_objCheckDetails.Pk_check_no = 0;
                m_objCheckDetails.Check_Amount = Convert.ToDecimal(txtPayAmount.Text);
                m_objCheckDetails.Current_Recurring_Number = m_intTemp + 1;
                m_objCheckDetails.Original_Recurring = "R";
                m_objCheckDetails.Check_FK = m_intRetval;
                m_objCheckDetails.Updated_By = "1";
                m_objCheckDetails.Updated_Date = System.DateTime.Now.Date;
                //m_objCheckDetails.Due_Date="";
                m_objCheckDetails.Check_status = "0";
                m_objCheckDetails.Printed_check = "0";
                //m_objCheckDetails.Stop_Delete_Date="";
                //m_objCheckDetails.Printed_date = System.DateTime.Now.Date;
                //m_objCheckDetails.Printed_by = "1";
                m_objCheckDetails.Void_Status = "0";
                m_objCheckDetails.Stop_Payment = "0";
                m_objCheckDetails.RecIssueDate = Convert.ToDateTime(txtDtRecBegin.Text).AddDays(txtReccPeriod.Text == string.Empty ? 0 : Convert.ToDouble(txtReccPeriod.Text) * (m_intTemp + 1));
                m_intRetvalCD = m_objCheckDetails.InsertUpdate_CheckDetails(m_objCheckDetails);
            }


        }
        if (m_intRetval > 0 && m_intRetvalCD > 0)
        {
            dvchkDetails.Visible = true;
            BindCDAEPData(m_intRetval);
            dventerPayment.Visible = false;
            dvSearch.Visible = false;
        }
    }
    /// <summary>
    /// Insert Only original check not Reccurring.
    /// </summary>
    private void InsertOrignalCheck()
    {
        m_objCheckWriting = new RIMS_Base.Biz.CCheckWriting();
        m_objCheckWriting.Pk_check_no = 0;
        m_objCheckWriting.Table_Name = lstClaimReservesInfo[0].TableName;
        m_objCheckWriting.TableFK = lstClaimReservesInfo[0].TableFK;
        m_objCheckWriting.Check_Number = 1;
        m_objCheckWriting.Input_Date = Convert.ToDateTime(txtdtChkInput.Text, format).Date;
        m_objCheckWriting.Issue_date = Convert.ToDateTime(txtDtChkIssue.Text, format).Date;
        m_objCheckWriting.Claimant_Vendor = rdbLstPayee.SelectedValue;
        if (rdbLstPayee.SelectedValue == "V")
            m_objCheckWriting.C_V_FK = Convert.ToDecimal(Request.Form[txtVendorId.UniqueID].ToString());
        else
            m_objCheckWriting.C_V_FK = lstClaimReservesInfo[0].Employee_Claimant;

        m_objCheckWriting.Payment_Id = ddlPayId.SelectedValue;
        m_objCheckWriting.Paycode = ddlPayCode.SelectedValue;
        m_objCheckWriting.Payment_Amount = Convert.ToDecimal(txtPayAmount.Text);
        m_objCheckWriting.Service_Begin = Convert.ToDateTime(txtDtSBegin.Text);
        m_objCheckWriting.Service_End = Convert.ToDateTime(txtDtSEnd.Text); ;
        m_objCheckWriting.Recurring_Payments = "N";
        m_objCheckWriting.Recurring_Number = 0;//txtNoOfRecPayment.Text == string.Empty ? 0 : Convert.ToDecimal(txtNoOfRecPayment.Text);
        m_objCheckWriting.Recurring_Period = 0;// txtReccPeriod.Text == string.Empty ? 0 : Convert.ToDecimal(txtReccPeriod.Text);
        //m_objCheckWriting.Recurring_Begin_Date = Convert.ToDateTime(txtDtRecBegin.Text, format).Date;
        //m_objCheckWriting.Recurring_End_Date = Convert.ToDateTime(txtDtRecEnd.Text, format).Date;
        //m_objCheckWriting.Recurring_End_Date = Convert.ToDateTime(txtDtRecBegin.Text).AddDays(txtReccPeriod.Text == "" ? 0 : Convert.ToDouble(txtReccPeriod.Text) * Convert.ToDouble(m_objCheckWriting.Recurring_Number));
        //m_objCheckWriting.Stop_Recurring="";
        m_objCheckWriting.Updated_By = "1";
        m_objCheckWriting.Updated_Date = System.DateTime.Now.Date;
        //m_objCheckWriting.Current_Recurring_Number=0;
        //m_objCheckWriting.Next_due_date="";
        m_objCheckWriting.Payment_Type = 1;//Convert.ToDecimal(ddlPaymentType.SelectedValue);
        m_objCheckWriting.FK_Supp_Doc_Type = Convert.ToDecimal(ddlPaySuppType.SelectedValue);
        if (txtDtDoc.Text != string.Empty)
            m_objCheckWriting.Doc_Date = Convert.ToDateTime(txtDtDoc.Text, format).Date;

        m_objCheckWriting.Document_Number = txtDocNo.Text;
        m_objCheckWriting.Invoice_Number = txtInvoiceNo.Text;
        m_objCheckWriting.FK_Bank = Convert.ToDecimal(ddlBank.SelectedValue);
        //Is vendor or claimant based on checkbox or vendor popup.
        if (rdbLstPayee.SelectedValue == "V")
        {
            m_objCheckWriting.FK_Payee = Convert.ToDecimal(Request.Form[txtVendorId.UniqueID].ToString());
            m_objCheckWriting.FK_Table_Payee = "Vendor";
        }
        else
        {
            if (lstClaimReservesInfo[0].TableName == "Workers_Comp")
            {
                m_objCheckWriting.FK_Payee = lstClaimReservesInfo[0].FK_Claimant;
            }
            else
            {

                m_objCheckWriting.FK_Payee = lstClaimReservesInfo[0].FK_ECD_Id;
            }
            if (lstClaimReservesInfo[0].FK_Claimant_id.ToString() == "1")
            {

                m_objCheckWriting.FK_Table_Payee = "Employee";
            }
            else
            {

                m_objCheckWriting.FK_Table_Payee = "Claimant";
            }

        }
        m_objCheckWriting.FK_Payer = lstClaimReservesInfo[0].FK_Claimant;
        if (lstClaimReservesInfo[0].FK_Claimant_id.ToString() == "1")
        {
            m_objCheckWriting.FK_Table_Payer = "Employee";
        }
        else
        {
            m_objCheckWriting.FK_Table_Payer = "Claimant";
        }
        //Employee

        m_objCheckWriting.Comments = txtComment.Text;
        m_intRetval = m_objCheckWriting.InsertUpdate_CheckWriting(m_objCheckWriting);
        if (m_intRetval > 0)
        {
            m_objCheckDetails = new RIMS_Base.Biz.CCheckDetails();
            m_objCheckDetails.Pk_check_no = 0;
            m_objCheckDetails.Check_Amount = Convert.ToDecimal(txtPayAmount.Text);
            m_objCheckDetails.Current_Recurring_Number = 0;
            m_objCheckDetails.Original_Recurring = "O";
            m_objCheckDetails.Check_FK = m_intRetval;
            m_objCheckDetails.Updated_By = "1";
            m_objCheckDetails.Updated_Date = System.DateTime.Now.Date;
            //m_objCheckDetails.Due_Date="";
            m_objCheckDetails.Check_status = "0";
            m_objCheckDetails.Printed_check = "0";
            //m_objCheckDetails.Stop_Delete_Date="";
            //m_objCheckDetails.Printed_date = System.DateTime.Now.Date;
            //m_objCheckDetails.Printed_by = "1";
            m_objCheckDetails.Void_Status = "0";
            m_objCheckDetails.Stop_Payment = "0";
            m_objCheckDetails.RecIssueDate = Convert.ToDateTime(txtDtChkIssue.Text);//Convert.ToDateTime(txtDtRecBegin.Text).AddDays(txtReccPeriod.Text == string.Empty ? 0 : Convert.ToDouble(txtReccPeriod.Text) * (m_intTemp + 1));
            m_intRetvalCD = m_objCheckDetails.InsertUpdate_CheckDetails(m_objCheckDetails);
        }
        if (m_intRetval > 0 && m_intRetvalCD > 0)
        {
            dvchkDetails.Visible = true;
            BindCDAEPData(m_intRetval);
            dventerPayment.Visible = false;
            dvSearch.Visible = false;
        }
    }

    /// <summary>
    /// Grid and Other lable binding.
    /// </summary>
    private void BindCDAEPData(int Chk_FK)
    {
        try
        {
            lblGrdClaimNo.Text = lblClaimNo.Text; //Request.QueryString[0].ToString();//"08-00028-01";
            lblGrdEmployee.Text = lblFirstName.Text.Replace("''", "'") + " " + lblLastName.Text.Replace("''", "'");
            DateTime dt = Convert.ToDateTime(lblDtOfIncident.Text);
            lblGrdDtIncident.Text = dt.ToString("MM/dd/yyyy");
            //if (ddlPaymentType.SelectedValue =="1")
            //{
            lblHeader.Text = "Generated Check Details";
            grdAfterChkGenerated.DataSource = GetCDAEPData(Convert.ToDecimal(Chk_FK));
            grdAfterChkGenerated.DataBind();
            //}
            //else
            //{
            //    lblHeader.Text = "Payment Details";
            //    grdOther.DataSource = GetCDAEPData(Convert.ToDecimal(Chk_FK));
            //    grdOther.DataBind();
            //}
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Get Data After Enter Payment
    /// </summary>
    /// <param name="Chk_FK">Check Writing Table Primary Key</param>
    /// <returns>List</returns>
    private List<RIMS_Base.CCheckDetails> GetCDAEPData(System.Decimal Chk_FK)
    {
        try
        {
            m_objCDAEP = new RIMS_Base.Biz.CCheckDetails();
            lstCDAEP = new List<RIMS_Base.CCheckDetails>();
            lstCDAEP = m_objCDAEP.GetCDAEP(Chk_FK);
            return lstCDAEP;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    /// <summary>
    /// Get Paycode.
    /// </summary>
    /// <returns></returns>
    private List<RIMS_Base.CGeneral> GetPayCode()
    {
        try
        {
            m_objPayCode = new RIMS_Base.Biz.CGeneral();
            lstPayCode = new List<RIMS_Base.CGeneral>();
            lstPayCode = m_objPayCode.GetPayCode(ddlPayId.SelectedValue);
            return lstPayCode;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    /// <summary>
    /// Bank Details by ID.
    /// </summary>
    /// <returns></returns>
    private List<RIMS_Base.CBankDetails> GetBankDetailsById()
    {
        try
        {
            m_objBankDetails = new RIMS_Base.Biz.CBankDetails();
            lstBankDetails = new List<RIMS_Base.CBankDetails>();
            lstBankDetails = m_objBankDetails.Get_DetailsByID(Convert.ToDecimal(ddlBank.SelectedValue));
            return lstBankDetails;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }

    /// <summary>
    /// Get the All Bank's Details
    /// </summary>
    private List<RIMS_Base.CBankDetails> BindBankDetails()
    {
        try
        {
            m_objBankDetails = new RIMS_Base.Biz.CBankDetails();
            lstBankDetails = new List<RIMS_Base.CBankDetails>();
            lstBankDetails = m_objBankDetails.GetAll();
            return lstBankDetails;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    /// <summary>
    /// Bind the Claim information and Reserves information
    /// </summary>
    private bool BindClaimAndReservesData()
    {
        try
        {
            m_objClaimReservesInfo = new RIMS_Base.Biz.CCheckWriting();
            lstClaimReservesInfo = new List<RIMS_Base.CCheckWriting>();
            
            if (Request.QueryString.Count > 0)
            {
                lstClaimReservesInfo = m_objClaimReservesInfo.GetClaimInfoByClaimNo(Request.QueryString[0].ToString());
               ClaimType= m_objClaimReservesInfo.GetClaimType(Request.QueryString[0].ToString());
            }
            else
            {
                lstClaimReservesInfo = m_objClaimReservesInfo.GetClaimInfoByClaimNo(txtSearchClaimNo.Text);
               ClaimType= m_objClaimReservesInfo.GetClaimType(txtSearchClaimNo.Text);
            }
            if (lstClaimReservesInfo.Count > 0)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Bind Claim and Reserves information.
    /// </summary>
    private void BindClaimData()
    {
        try
        {
            lblClaimNo.Text = lstClaimReservesInfo[0].Claim_Number;
            lblEmployeeSSN.Text = lstClaimReservesInfo[0].EmployeeSSN;
            //lblEmployee.Text = //lstClaimReservesInfo[0].Employee;
            if (lstClaimReservesInfo[0].FK_Claimant_id == 1)
                lblEmployee.Text = "Yes";
            else if (lstClaimReservesInfo[0].FK_Claimant_id == 2)
                lblEmployee.Text = "No";
            else if (lstClaimReservesInfo[0].FK_Claimant_id == 3)
                lblEmployee.Text = "No";
            lblLastName.Text = lstClaimReservesInfo[0].LastName.Replace("''", "'");
            lblFirstName.Text = lstClaimReservesInfo[0].FirstName.Replace("''", "'");
            lblMiddleName.Text = lstClaimReservesInfo[0].MiddleName.Replace("''", "'");
            lblDtOfIncident.Text = lstClaimReservesInfo[0].Date_Of_Loss.ToShortDateString();
            lblIInccured.Text = lstClaimReservesInfo[0].Incurred_Indemnity.ToString() == "-1" ? "0.00" : lstClaimReservesInfo[0].Incurred_Indemnity.ToString();
            lblIPaid.Text = lstClaimReservesInfo[0].PAID_INDEMNITY.ToString() == "-1" ? "0.00" : lstClaimReservesInfo[0].PAID_INDEMNITY.ToString();
            lblIOutStand.Text = lstClaimReservesInfo[0].Outstanding_INDEMNITY.ToString() == "-1" ? "0.00" : lstClaimReservesInfo[0].Outstanding_INDEMNITY.ToString();
            lblMInccured.Text = lstClaimReservesInfo[0].Incurred_Medical.ToString() == "-1" ? "0.00" : lstClaimReservesInfo[0].Incurred_Medical.ToString();
            lblMPaid.Text = lstClaimReservesInfo[0].PAID_Medical.ToString() == "-1" ? "0.00" : lstClaimReservesInfo[0].PAID_Medical.ToString();
            lblMOutStand.Text = lstClaimReservesInfo[0].Outstanding_Medical.ToString() == "-1" ? "0.00" : lstClaimReservesInfo[0].Outstanding_Medical.ToString();
            lblEInccured.Text = lstClaimReservesInfo[0].Incurred_Expense.ToString() == "-1" ? "0.00" : lstClaimReservesInfo[0].Incurred_Expense.ToString();
            lblEPaid.Text = lstClaimReservesInfo[0].PAID_Expense.ToString() == "-1" ? "0.00" : lstClaimReservesInfo[0].PAID_Expense.ToString();
            lblEOutStand.Text = lstClaimReservesInfo[0].Outstanding_Expense.ToString() == "-1" ? "0.00" : lstClaimReservesInfo[0].Outstanding_Expense.ToString();
            txtPayTo.Text = lblFirstName.Text.Replace("''", "'") + " " + lblLastName.Text.Replace("''", "'");
            if (ClaimType == "Workers_Comp")
            {
                lblBodilyMed.Text = "Medical";
                lblPropInd.Text = "Indemnity";
            }
            else
            {
                lblBodilyMed.Text = "Bodily Injury";
                lblPropInd.Text = "Property Damage";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void BindDropDown()
    {
        try
        {
            ddlPayId.DataSource = GetVendorType();
            if (ClaimType == "Workers_Comp")
            {
                ddlPayId.DataTextField = "FLD_DescO";
                ddlPayId.DataValueField = "FLD_Desc";
            }
            else
            {
                ddlPayId.DataTextField = "FLD_Desc";
                ddlPayId.DataValueField = "FLD_Desc";
            }
            ddlPayId.DataBind();
            m_lstCommon = new ListItem("--Select Payment ID--", "0");
            ddlPayId.Items.Insert(0, m_lstCommon);

            ddlPaySuppType.DataSource = GetSupportedDocType();
            ddlPaySuppType.DataTextField = "Description";
            ddlPaySuppType.DataValueField = "PK_Supp_Doc_Type";
            ddlPaySuppType.DataBind();
            m_lstCommon = new ListItem("--Select Document Type--", "0");
            ddlPaySuppType.Items.Insert(0, m_lstCommon);

            ddlBank.DataSource = BindBankDetails();
            ddlBank.DataTextField = "Fld_Bank_Name";
            ddlBank.DataValueField = "PK_Bank_Details_ID";
            ddlBank.DataBind();
            m_lstCommon = new ListItem("--Select Bank--", "0");
            ddlBank.Items.Insert(0, m_lstCommon);

            ddlPaymentType.DataSource = GetPaymentType();
            ddlPaymentType.DataTextField = "FLD_Desc";
            ddlPaymentType.DataValueField = "PK_Payment_Type_Id";
            ddlPaymentType.DataBind();
            m_lstCommon = new ListItem("--Select Payment Type--", "0");
            ddlPaymentType.Items.Insert(0, m_lstCommon);



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Get All State.
    /// </summary>
    private List<RIMS_Base.CGeneral> GetSupportedDocType()
    {
        try
        {
            m_objSuppDocs = new RIMS_Base.Biz.CGeneral();
            lstSuppDocs = new List<RIMS_Base.CGeneral>();
            lstSuppDocs = m_objSuppDocs.GetSupportedDocumentType();
            return lstSuppDocs;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }
    /// <summary>
    /// Get All Vendor Type.
    /// </summary>
    private List<RIMS_Base.CVendor> GetVendorType()
    {
        try
        {
            m_objVendorType = new RIMS_Base.Biz.CVendor();
            lstVendorType = new List<RIMS_Base.CVendor>();
            lstVendorType = m_objVendorType.GetAllVendorType();
            return lstVendorType;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }
    /// <summary>
    /// Get All Vendor Type.
    /// </summary>
    private List<RIMS_Base.CCheckWriting> GetPaymentType()
    {
        try
        {
            m_objPaymentType = new RIMS_Base.Biz.CCheckWriting();
            lstPaymentType = new List<RIMS_Base.CCheckWriting>();
            lstPaymentType = m_objPaymentType.GetAllPaymentType();
            return lstPaymentType;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }
    //
    private bool ValidateAmount()
    {

        if (ddlPayId.SelectedValue == "Expense")
        {
            m_dExistAmt = Convert.ToDecimal(lblEOutStand.Text == string.Empty ? "0" : lblEOutStand.Text);
        }
        else if (ddlPayId.SelectedValue == "Indemnity")
        {
            m_dExistAmt = Convert.ToDecimal(lblIOutStand.Text == string.Empty ? "0" : lblIOutStand.Text);
        }
        else if (ddlPayId.SelectedValue == "Medical")
        {
            m_dExistAmt = Convert.ToDecimal(lblMOutStand.Text == string.Empty ? "0" : lblMOutStand.Text);
        }
        if (rdblstRecPayment.SelectedValue == "Y")
        {
            m_dCurrAmt = Convert.ToDecimal(txtPayAmount.Text == string.Empty ? "0" : txtPayAmount.Text) * Convert.ToDecimal(txtNoOfRecPayment.Text == string.Empty ? "0" : txtNoOfRecPayment.Text);
        }
        else
        {
            m_dCurrAmt = Convert.ToDecimal(txtPayAmount.Text == string.Empty ? "0" : txtPayAmount.Text);
        }
        if (m_dCurrAmt > m_dExistAmt)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
    #endregion
    #region Commented Code
    //  if (m_intRetvalCD > 0)
    //    {
    //        GetBankDetailsById();
    //        m_objAppliedPayment = new RIMS_Base.Biz.CAppliedPayment();
    //        m_objAppliedPayment.Pk_applied_id = 0;
    //        m_objAppliedPayment.Bank_name = lstBankDetails[0].Fld_Bank_Name;
    //        m_objAppliedPayment.Bank_address1 = lstBankDetails[0].Fld_Address_1;
    //        m_objAppliedPayment.Bank_address2 = lstBankDetails[0].Fld_Address_2;
    //        m_objAppliedPayment.Bank_state_code = lstBankDetails[0].Fld_Bank_State;
    //        m_objAppliedPayment.Bank_zip = lstBankDetails[0].Fld_Zip;
    //        m_objAppliedPayment.Bank_state = lstBankDetails[0].Fld_State;
    //        m_objAppliedPayment.Bank_city = lstBankDetails[0].Fld_City;
    //        m_objAppliedPayment.Fld_Bank_No1 = lstBankDetails[0].Fld_Bank_No1;
    //        m_objAppliedPayment.Fld_Bank_No2 = lstBankDetails[0].Fld_Bank_No2;
    //        m_objAppliedPayment.Fld_AccountNo = lstBankDetails[0].Fld_AccountNo;
    //        m_objAppliedPayment.Fld_RoutingNo = lstBankDetails[0].Fld_RoutingNo;
    //        m_objAppliedPayment.Issue_date = Convert.ToDateTime(((TextBox)(fvEnterPayment.FindControl("txtDtChkIssue"))).Text, format).Date;
    //        m_objAppliedPayment.Amount = Convert.ToDecimal(((TextBox)(fvEnterPayment.FindControl("txtPayAmount"))).Text);
    //        m_objAppliedPayment.Claim_no = ((Label)(fvEnterPayment.FindControl("lblClaimNo"))).Text;

    //        //m_objAppliedPayment.payee_name="";
    //        //m_objAppliedPayment.payee_address1="";
    //        ///m_objAppliedPayment.payee_address2="";
    //        //m_objAppliedPayment.employeer="";
    //        m_objAppliedPayment.Employee_name = ((Label)(fvEnterPayment.FindControl("lblFirstName"))).Text + " " + ((Label)(fvEnterPayment.FindControl("lblLastName"))).Text;
    //        m_objAppliedPayment.Employee_ssn = ((Label)(fvEnterPayment.FindControl("lblEmployeeSSN"))).Text;

    //        //m_objAppliedPayment.date_of_loss="";
    //        //m_objAppliedPayment.adjuster="";
    //        m_objAppliedPayment.Payment_type = ((DropDownList)fvEnterPayment.FindControl("ddlPayId")).SelectedValue;
    //        m_objAppliedPayment.Service_date_from = Convert.ToDateTime(((TextBox)(fvEnterPayment.FindControl("txtDtSBegin"))).Text, format).Date;
    //        m_objAppliedPayment.Service_date_to = Convert.ToDateTime(((TextBox)(fvEnterPayment.FindControl("txtDtSEnd"))).Text, format).Date;
    //        m_objAppliedPayment.Comments = ((TextBox)(fvEnterPayment.FindControl("txtComment"))).Text;
    //        //m_objAppliedPayment.timeofloss="";
    //        m_objAppliedPayment.Check_no = m_objCheckWriting.Check_Number.ToString();
    //        m_objAppliedPayment.Check_fk = m_intRetvalCD;
    //        m_objAppliedPayment.Check_Writting_FK = m_intRetval;
    //        //m_objAppliedPayment.Check_Status="";
    //        //m_objAppliedPayment.Stop_Delete_Date="";
    //        m_objAppliedPayment.Invoice_Number = ((TextBox)(fvEnterPayment.FindControl("txtInvoiceNo"))).Text;
    //        //m_objAppliedPayment.Void_Status="";
    //        //m_objAppliedPayment.Cleared_Bank="";
    //        m_intRetvalAP = m_objAppliedPayment.InsertUpdateApp_Payment(m_objAppliedPayment);

    //    }
    #endregion



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (BindClaimAndReservesData())
            {
                dventerPayment.Visible = true;
                dvSearch.Visible = false;
                BindClaimData();
                BindDropDown();
            }
            else
            {
                lblSearchMsg.Text = "The claim entered was not found. Please re-enter another claim number";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void txtNoOfRecPayment_TextChanged(object sender, EventArgs e)
    {
        SetRecEndDate();
    }
    protected void txtReccPeriod_TextChanged(object sender, EventArgs e)
    {
        SetRecEndDate();
    }
    protected void txtDtRecBegin_TextChanged(object sender, EventArgs e)
    {
        SetRecEndDate();
    }
    private void SetRecEndDate()
    {
        if (txtDtRecBegin.Text != string.Empty && txtDtRecBegin.Text != "__/__/____")
        {
            lblDtShowRecEnd.Text = Convert.ToDateTime(txtDtRecBegin.Text).AddDays(Convert.ToDouble(txtReccPeriod.Text == string.Empty ? "0" : txtReccPeriod.Text) * Convert.ToDouble(txtNoOfRecPayment.Text == string.Empty ? "0" : txtNoOfRecPayment.Text)).Date.ToString("MM/dd/yyyy");
        }


    }
}
