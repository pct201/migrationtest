#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base
{

    [Serializable]
    public abstract class CAppliedPayment
    {

        #region Constructor
        public CAppliedPayment()
        {
            this._pk_applied_id = -1;
            this._bank_name = string.Empty;
            this._bank_address1 = string.Empty;
            this._bank_address2 = string.Empty;
            this._bank_city = string.Empty;
            this._bank_state_code = string.Empty;
            this._bank_zip = string.Empty;
            this._bank_state = string.Empty;
            this._fld_Bank_No1 = string.Empty;
            this._fld_Bank_No2 = string.Empty;
            this._issue_date = DateTime.Now;
            this._amount = -1;
            this._payee_name = string.Empty;
            this._payee_address1 = string.Empty;
            this._payee_address2 = string.Empty;
            this._employeer = string.Empty;
            this._employee_name = string.Empty;
            this._employee_ssn = string.Empty;
            this._claim_no = string.Empty;
            this._date_of_loss = string.Empty;
            this._adjuster = string.Empty;
            this._payment_type = string.Empty;
            this._service_date_from = DateTime.Now;
            this._service_date_to = DateTime.Now;
            this._comments = string.Empty;
            this._timeofloss = string.Empty;
            this._check_no = string.Empty;
            this._fld_AccountNo = string.Empty;
            this._fld_RoutingNo = string.Empty;
            this._check_fk = -1;
            this._check_Writting_FK = -1;
            this._check_Status = string.Empty;
            this._stop_Delete_Date = DateTime.Now;
            this._invoice_Number = string.Empty;
            this._void_Status = -1;
            this._cleared_Bank = string.Empty;
        }
        #endregion

        #region Private Variables
        private System.Int64 _pk_applied_id;
        private System.String _bank_name;
        private System.String _bank_address1;
        private System.String _bank_address2;
        private System.String _bank_city;
        private System.String _bank_state_code;
        private System.String _bank_zip;
        private System.String _bank_state;
        private System.String _fld_Bank_No1;
        private System.String _fld_Bank_No2;
        private System.DateTime _issue_date;
        private System.Decimal _amount;
        private System.String _payee_name;
        private System.String _payee_address1;
        private System.String _payee_address2;
        private System.String _employeer;
        private System.String _employee_name;
        private System.String _employee_ssn;
        private System.String _claim_no;
        private System.String _date_of_loss;
        private System.String _adjuster;
        private System.String _payment_type;
        private System.DateTime _service_date_from;
        private System.DateTime _service_date_to;
        private System.String _comments;
        private System.String _timeofloss;
        private System.String _check_no;
        private System.String _fld_AccountNo;
        private System.String _fld_RoutingNo;
        private System.Decimal _check_fk;
        private System.Decimal _check_Writting_FK;
        private System.String _check_Status;
        private System.DateTime _stop_Delete_Date;
        private System.String _invoice_Number;
        private System.Int32 _void_Status;
        private System.String _cleared_Bank;
        #endregion

        #region Public Properties
        public System.Int64 Pk_applied_id
        {
            get { return _pk_applied_id; }
            set { _pk_applied_id = value; }
        }

        public System.String Bank_name
        {
            get { return _bank_name; }
            set { _bank_name = value; }
        }

        public System.String Bank_address1
        {
            get { return _bank_address1; }
            set { _bank_address1 = value; }
        }

        public System.String Bank_address2
        {
            get { return _bank_address2; }
            set { _bank_address2 = value; }
        }

        public System.String Bank_city
        {
            get { return _bank_city; }
            set { _bank_city = value; }
        }

        public System.String Bank_state_code
        {
            get { return _bank_state_code; }
            set { _bank_state_code = value; }
        }

        public System.String Bank_zip
        {
            get { return _bank_zip; }
            set { _bank_zip = value; }
        }

        public System.String Bank_state
        {
            get { return _bank_state; }
            set { _bank_state = value; }
        }

        public System.String Fld_Bank_No1
        {
            get { return _fld_Bank_No1; }
            set { _fld_Bank_No1 = value; }
        }

        public System.String Fld_Bank_No2
        {
            get { return _fld_Bank_No2; }
            set { _fld_Bank_No2 = value; }
        }

        public System.DateTime Issue_date
        {
            get { return _issue_date; }
            set { _issue_date = value; }
        }

        public System.Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public System.String Payee_name
        {
            get { return _payee_name; }
            set { _payee_name = value; }
        }

        public System.String Payee_address1
        {
            get { return _payee_address1; }
            set { _payee_address1 = value; }
        }

        public System.String Payee_address2
        {
            get { return _payee_address2; }
            set { _payee_address2 = value; }
        }

        public System.String Employeer
        {
            get { return _employeer; }
            set { _employeer = value; }
        }

        public System.String Employee_name
        {
            get { return _employee_name; }
            set { _employee_name = value; }
        }

        public System.String Employee_ssn
        {
            get { return _employee_ssn; }
            set { _employee_ssn = value; }
        }

        public System.String Claim_no
        {
            get { return _claim_no; }
            set { _claim_no = value; }
        }

        public System.String Date_of_loss
        {
            get { return _date_of_loss; }
            set { _date_of_loss = value; }
        }

        public System.String Adjuster
        {
            get { return _adjuster; }
            set { _adjuster = value; }
        }

        public System.String Payment_type
        {
            get { return _payment_type; }
            set { _payment_type = value; }
        }

        public System.DateTime Service_date_from
        {
            get { return _service_date_from; }
            set { _service_date_from = value; }
        }

        public System.DateTime Service_date_to
        {
            get { return _service_date_to; }
            set { _service_date_to = value; }
        }

        public System.String Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public System.String Timeofloss
        {
            get { return _timeofloss; }
            set { _timeofloss = value; }
        }

        public System.String Check_no
        {
            get { return _check_no; }
            set { _check_no = value; }
        }

        public System.String Fld_AccountNo
        {
            get { return _fld_AccountNo; }
            set { _fld_AccountNo = value; }
        }

        public System.String Fld_RoutingNo
        {
            get { return _fld_RoutingNo; }
            set { _fld_RoutingNo = value; }
        }

        public System.Decimal Check_fk
        {
            get { return _check_fk; }
            set { _check_fk = value; }
        }

        public System.Decimal Check_Writting_FK
        {
            get { return _check_Writting_FK; }
            set { _check_Writting_FK = value; }
        }

        public System.String Check_Status
        {
            get { return _check_Status; }
            set { _check_Status = value; }
        }

        public System.DateTime Stop_Delete_Date
        {
            get { return _stop_Delete_Date; }
            set { _stop_Delete_Date = value; }
        }

        public System.String Invoice_Number
        {
            get { return _invoice_Number; }
            set { _invoice_Number = value; }
        }

        public System.Int32 Void_Status
        {
            get { return _void_Status; }
            set { _void_Status = value; }
        }

        public System.String Cleared_Bank
        {
            get { return _cleared_Bank; }
            set { _cleared_Bank = value; }
        }

        #endregion

        #region Abstract Methods
        public abstract List<CAppliedPayment> GetAll();
        public abstract CAppliedPayment GetApp_PaymentByID(System.Decimal lpk_applied_id);
        public abstract int InsertUpdateApp_Payment(RIMS_Base.CAppliedPayment obj);
        public abstract int DeleteApp_Payment(System.Decimal lpk_applied_id);
        public abstract string ActivateInactivateApp_Payment(string strIDs, int intModifiedBy, bool bIsActive);
        #endregion

    }

}
