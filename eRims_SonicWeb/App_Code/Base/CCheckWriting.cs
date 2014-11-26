#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CCheckWriting
{

	#region Constructor
    public CCheckWriting()
	{
        this._pk_check_no = -1;
        this._table_Name = string.Empty;
        this._fK_Table_Name = -1;
        this._check_Number = -1;
        this._input_Date = DateTime.Now;
        this._issue_date = DateTime.Now;
        this._Date_Of_Loss = DateTime.Now;
        
        this._claimant_Vendor = string.Empty;
        this._c_V_FK = -1;
        this._payment_Id = string.Empty;
        this._paycode = string.Empty;
        this._payment_Amount = -1;
        this._service_Begin = DateTime.Now;
        this._service_End = DateTime.Now;
        this._recurring_Payments = string.Empty;
        this._recurring_Number = -1;
        this._recurring_Period = -1;
        this._recurring_Begin_Date = DateTime.Now;
        this._recurring_End_Date = DateTime.Now;
        this._stop_Recurring = DateTime.Now;
        this._updated_By = string.Empty;
        this._updated_Date = DateTime.Now;
        this._current_Recurring_Number = -1;
        this._next_due_date = DateTime.Now;
        this._payment_Type = -1;
        this._fK_Supp_Doc_Type = -1;
        this._doc_Date = DateTime.Now;
        this._document_Number = string.Empty;
        this._invoice_Number = string.Empty;
        this._fK_Bank = -1;
        this._fK_Payee = -1;
        this._fK_Table_Payee = string.Empty;
        this._fK_Payer = -1;
        this._fK_Table_Payer = string.Empty;
        this._comments = string.Empty;
        //For Claim Info
        this._tblName = string.Empty;
        this._tblFk = 0;
        this._claim_Number = string.Empty;
        this._employee = string.Empty;
        this._last_Name = string.Empty;
        this._first_Name = string.Empty;
        this._middle_Name = string.Empty;
        this._incident_Date = string.Empty;
        this._fk_Employee_Claimant = 0;
        this._Employee_SSN = string.Empty;
        //For Reserves
        this._incurred_Indemnity = -1;
        this._pAID_INDEMNITY = -1;
        this._outstanding_INDEMNITY = -1;
        this._incurred_Medical = -1;
        this._pAID_Medical = -1;
        this._outstanding_Medical = -1;
        this._incurred_Expense = -1;
        this._pAID_Expense = -1;
        this._outstanding_Expense = -1;
        this._fK_Table_Name = -1;
        this._table_Name = string.Empty;
        //PaymentType Variables
        this._pK_Payment_Type_ID = -1;
        this._fLD_Desc = string.Empty;
        //For Check Edit Delete Functionality
        this._CEDPkChkNo=0;
        this._CEDChckPayment=-1;
        //For Id of Claimant,Employee,Vendor.
        this._FK_ECD = 0;
        this._FK_Claimant = 0;
	}
	#endregion

	#region Private Variables 
    private System.Int64 _pk_check_no;
    private System.String _table_Name;
    private System.Decimal _fK_Table_Name;
    private System.Decimal _check_Number;
    private System.DateTime _input_Date;
    private System.DateTime _issue_date;
    private System.String _claimant_Vendor;
    private System.Decimal _c_V_FK;
    private System.String _payment_Id;
    private System.String _paycode;
    private System.Decimal _payment_Amount;
    private System.DateTime _service_Begin;
    private System.DateTime _service_End;
    private System.String _recurring_Payments;
    private System.Decimal _recurring_Number;
    private System.Decimal _recurring_Period;
    private System.DateTime _recurring_Begin_Date;
    private System.DateTime _recurring_End_Date;
    private System.DateTime _stop_Recurring;
    private System.String _updated_By;
    private System.DateTime _updated_Date;
    private System.Decimal _current_Recurring_Number;
    private System.DateTime _next_due_date;
    private System.Decimal _payment_Type;
    private System.Decimal _fK_Supp_Doc_Type;
    private System.DateTime _doc_Date;
    private System.String _document_Number;
    private System.String _invoice_Number;
    private System.Decimal _fK_Bank;
    private System.Decimal _fK_Payee;
    private System.String _fK_Table_Payee;
    private System.Decimal _fK_Payer;
    private System.String _fK_Table_Payer;
    private System.String _comments;
    //For Claim Info
    private System.String _tblName;
    private System.Int32 _tblFk;
    private System.String _claim_Number;
    private System.String _employee;
    private System.String _last_Name;
    private System.String _first_Name;
    private System.String _middle_Name;
    private System.String _incident_Date;
    private System.Int32 _fk_Employee_Claimant;
    private System.String _Employee_SSN;
    //For Reserves
    private System.Decimal _incurred_Indemnity;
    private System.Decimal _pAID_INDEMNITY;
    private System.Decimal _outstanding_INDEMNITY;
    private System.Decimal _incurred_Medical;
    private System.Decimal _pAID_Medical;
    private System.Decimal _outstanding_Medical;
    private System.Decimal _incurred_Expense;
    private System.Decimal _pAID_Expense;
    private System.Decimal _outstanding_Expense;
    private System.Int32 _table_Fk;
    //private System.String _table_Name;

    //Payment Type Table Variables
    private System.Decimal _pK_Payment_Type_ID;
    private System.String _fLD_Desc;
    //For Check Edit Delete Functionality
    private System.Int64 _CEDPkChkNo;
    private System.Decimal _CEDChckPayment;
    private System.DateTime _Date_Of_Loss;
    private System.Decimal _FK_Claimant_id;
    private System.Decimal _FK_ECD;
    private System.Decimal _FK_Claimant;

	#endregion

	#region Public Properties
    public System.Decimal FK_Claimant
    {
        get { return _FK_Claimant; }
        set { _FK_Claimant = value; }
    }
    public System.Decimal FK_ECD_Id
    {
        get { return _FK_ECD; }
        set { _FK_ECD = value; }
    }

    public System.Decimal FK_Claimant_id
    {
        get { return _FK_Claimant_id; }
        set { _FK_Claimant_id = value; }
    }


    public System.DateTime Date_Of_Loss

    {
                
        get{return _Date_Of_Loss;}
        set { _Date_Of_Loss = value; }
    }

    public System.Int64 Pk_check_no
    {
        get { return _pk_check_no; }
        set { _pk_check_no = value; }
    }

    public System.String Table_Name
    {
        get { return _table_Name; }
        set { _table_Name = value; }
    }

    public System.Decimal FK_Table_Name
    {
        get { return _fK_Table_Name; }
        set { _fK_Table_Name = value; }
    }

    public System.Decimal Check_Number
    {
        get { return _check_Number; }
        set { _check_Number = value; }
    }

    public System.DateTime Input_Date
    {
        get { return _input_Date; }
        set { _input_Date = value; }
    }

    public System.DateTime Issue_date
    {
        get { return _issue_date; }
        set { _issue_date = value; }
    }

    public System.String Claimant_Vendor
    {
        get { return _claimant_Vendor; }
        set { _claimant_Vendor = value; }
    }

    public System.Decimal C_V_FK
    {
        get { return _c_V_FK; }
        set { _c_V_FK = value; }
    }

    public System.String Payment_Id
    {
        get { return _payment_Id; }
        set { _payment_Id = value; }
    }

    public System.String Paycode
    {
        get { return _paycode; }
        set { _paycode = value; }
    }

    public System.Decimal Payment_Amount
    {
        get { return _payment_Amount; }
        set { _payment_Amount = value; }
    }

    public System.DateTime Service_Begin
    {
        get { return _service_Begin; }
        set { _service_Begin = value; }
    }

    public System.DateTime Service_End
    {
        get { return _service_End; }
        set { _service_End = value; }
    }

    public System.String Recurring_Payments
    {
        get { return _recurring_Payments; }
        set { _recurring_Payments = value; }
    }

    public System.Decimal Recurring_Number
    {
        get { return _recurring_Number; }
        set { _recurring_Number = value; }
    }

    public System.Decimal Recurring_Period
    {
        get { return _recurring_Period; }
        set { _recurring_Period = value; }
    }

    public System.DateTime Recurring_Begin_Date
    {
        get { return _recurring_Begin_Date; }
        set { _recurring_Begin_Date = value; }
    }

    public System.DateTime Recurring_End_Date
    {
        get { return _recurring_End_Date; }
        set { _recurring_End_Date = value; }
    }

    public System.DateTime Stop_Recurring
    {
        get { return _stop_Recurring; }
        set { _stop_Recurring = value; }
    }

    public System.String Updated_By
    {
        get { return _updated_By; }
        set { _updated_By = value; }
    }

    public System.DateTime Updated_Date
    {
        get { return _updated_Date; }
        set { _updated_Date = value; }
    }

    public System.Decimal Current_Recurring_Number
    {
        get { return _current_Recurring_Number; }
        set { _current_Recurring_Number = value; }
    }

    public System.DateTime Next_due_date
    {
        get { return _next_due_date; }
        set { _next_due_date = value; }
    }

    public System.Decimal Payment_Type
    {
        get { return _payment_Type; }
        set { _payment_Type = value; }
    }

    public System.Decimal FK_Supp_Doc_Type
    {
        get { return _fK_Supp_Doc_Type; }
        set { _fK_Supp_Doc_Type = value; }
    }

    public System.DateTime Doc_Date
    {
        get { return _doc_Date; }
        set { _doc_Date = value; }
    }

    public System.String Document_Number
    {
        get { return _document_Number; }
        set { _document_Number = value; }
    }

    public System.String Invoice_Number
    {
        get { return _invoice_Number; }
        set { _invoice_Number = value; }
    }

    public System.Decimal FK_Bank
    {
        get { return _fK_Bank; }
        set { _fK_Bank = value; }
    }

    public System.Decimal FK_Payee
    {
        get { return _fK_Payee; }
        set { _fK_Payee = value; }
    }

    public System.String FK_Table_Payee
    {
        get { return _fK_Table_Payee; }
        set { _fK_Table_Payee = value; }
    }

    public System.Decimal FK_Payer
    {
        get { return _fK_Payer; }
        set { _fK_Payer = value; }
    }

    public System.String FK_Table_Payer
    {
        get { return _fK_Table_Payer; }
        set { _fK_Table_Payer = value; }
    }

    public System.String Comments
    {
        get { return _comments; }
        set { _comments = value; }
    }
    //Claim Info
    public System.String TableName
    {
        get { return _tblName; }
        set { _tblName = value; }
    }
    public System.Int32 TableFK
    {
        get { return _tblFk; }
        set { _tblFk = value; }
    }
    public System.String Claim_Number
    {
        get { return _claim_Number; }
        set { _claim_Number = value; }
    }
    public System.String Employee
    {
        get { return _employee; }
        set { _employee = value; }
    }
    public System.String LastName
    {
        get { return _last_Name; }
        set { _last_Name = value; }
    }
    public System.String FirstName
    {
        get { return _first_Name; }
        set { _first_Name = value; }
    }
    public System.String MiddleName
    {
        get { return _middle_Name; }
        set { _middle_Name = value; }
    }
    public System.String IncidentDate
    {
        get { return _incident_Date; }
        set { _incident_Date = value; }
    }
    public System.Int32 Employee_Claimant
    {
        get { return _fk_Employee_Claimant; }
        set { _fk_Employee_Claimant = value; }
    }
    public System.String EmployeeSSN
    {
        get { return _Employee_SSN; }
        set { _Employee_SSN = value; }
    }

    //For Reserves
    public System.Decimal Incurred_Indemnity
    {
        get { return _incurred_Indemnity; }
        set { _incurred_Indemnity = value; }
    }
    public System.Decimal PAID_INDEMNITY
    {
        get { return _pAID_INDEMNITY; }
        set { _pAID_INDEMNITY = value; }
    }
    public System.Decimal Outstanding_INDEMNITY
    {
        get { return _outstanding_INDEMNITY; }
        set { _outstanding_INDEMNITY = value; }
    }
    public System.Decimal Incurred_Medical
    {
        get { return _incurred_Medical; }
        set { _incurred_Medical = value; }
    }
    public System.Decimal PAID_Medical
    {
        get { return _pAID_Medical; }
        set { _pAID_Medical = value; }
    }
    public System.Decimal Outstanding_Medical
    {
        get { return _outstanding_Medical; }
        set { _outstanding_Medical = value; }
    }
    public System.Decimal Incurred_Expense
    {
        get { return _incurred_Expense; }
        set { _incurred_Expense = value; }
    }
    public System.Decimal PAID_Expense
    {
        get { return _pAID_Expense; }
        set { _pAID_Expense = value; }
    }
    public System.Decimal Outstanding_Expense
    {
        get { return _outstanding_Expense; }
        set { _outstanding_Expense = value; }
    }
    public System.Int32 TableFkReserves
    {
        get { return _table_Fk; }
        set { _table_Fk = value; }
    }
    /*
    public System.String Table_Name
    {
        get { return _table_Name; }
        set { _table_Name = value; }
    }*/
    //Payment Type Properties
    public System.Decimal PK_Payment_Type_ID
    {
        get { return _pK_Payment_Type_ID; }
        set { _pK_Payment_Type_ID = value; }
    }

    public System.String FLD_Desc
    {
        get { return _fLD_Desc; }
        set { _fLD_Desc = value; }
    }
    //For Check Edit Delete Functionality
    public System.Int64 CEDPK_Chk_No
    {
        get { return _CEDPkChkNo; }
        set { _CEDPkChkNo = value; }
    }
    public System.Decimal CEDChkPayment
    {
        get { return _CEDChckPayment; }
        set { _CEDChckPayment = value; }
    }
    #endregion

    #region Abstract Methods
    public abstract List<CCheckWriting> GetAll(Boolean blnIsActive);
    public abstract CCheckWriting GetCheckWritingByID(System.Decimal lpk_check_no);
    public abstract int InsertUpdate_CheckWriting(RIMS_Base.CCheckWriting obj);
	public abstract int Delete_CheckWriting(System.Decimal lpk_check_no);
	public abstract string ActivateInactivate_CheckWriting(string strIDs, int intModifiedBy, bool bIsActive);
    //For Claim info
    public abstract List<CCheckWriting> GetClaimInfoByClaimNo(string m_strClaimNo);
    //For Reserves
    public abstract List<CCheckWriting> GetReserves(System.String m_strTblName,System.Int32 m_intTblFk);
    //FOr Payment Type
    public abstract List<CCheckWriting> GetAllPaymentType();
    //For Check Edit Delete Functionality
    public abstract int Update_CEDCheckEditDel(RIMS_Base.CCheckWriting obj);

    //For worker Comp Claim info
    public abstract List<CCheckWriting> GetWorkerCompClaimInfoByClaimNo(string m_strClaimNo);
    public abstract string GetClaimType(string ClaimNumber);
	#endregion

}

}
