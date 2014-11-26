#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
#endregion

namespace RIMS_Base
{

    [Serializable]
    public abstract class CCheckDetails
    {

        #region Constructor
        public CCheckDetails()
        {
            this._pk_check_no = -1;
            this._check_Amount = -1;
            this._current_Recurring_Number = -1;
            this._original_Recurring = string.Empty;
            this._check_FK = -1;
            this._updated_By = string.Empty;
            this._updated_Date = DateTime.Now;
            this._due_Date = DateTime.Now;
            this._check_status = string.Empty;
            this._printed_check = string.Empty;
            this._stop_Delete_Date = DateTime.Now;
            this._printed_date = DateTime.Now;
            this._printed_by = string.Empty;
            this._void_Status = string.Empty;
            this._stop_Payment = string.Empty;
            this._Rec_Issue_Date = DateTime.Now;
            this._CD_Check_Number = -1;
            //Check Details to Show After Enter Payment
            this._AEPPaymentID = string.Empty;
            this._AEPServiceDTBegin = DateTime.Now;
            this._AEPServiceDTEnd = DateTime.Now;
            this._AEPInvoiceNo = string.Empty;
            this._AEPPayee = string.Empty;
            this._AEPPayer = string.Empty;
            //Check Edit delete
            this._CEDClaimNo = string.Empty;
            this._CEDPayCode = string.Empty;
            this._CEDComments = string.Empty;
            this._CEDIoutStand = 0;
            this._CEDMoutStand = 0;
            this._CEDEoutStand = 0;
            this._TotalAmount = string.Empty;

        }
        #endregion

        #region Private Variables
        private System.Int64 _pk_check_no;
        private System.Decimal _CD_Check_Number;
        private System.Decimal _check_Amount;
        private System.Decimal _current_Recurring_Number;
        private System.String _original_Recurring;
        private System.Decimal _check_FK;
        private System.String _updated_By;
        private System.DateTime _updated_Date;
        private System.DateTime _due_Date;
        private System.String _check_status;
        private System.String _printed_check;
        private System.DateTime _stop_Delete_Date;
        private System.DateTime _printed_date;
        private System.String _printed_by;
        private System.String _void_Status;
        private System.String _stop_Payment;
        private System.DateTime _Rec_Issue_Date;
        //Check Details to Show After Enter Payment
        private System.String _AEPPaymentID;
        private System.DateTime _AEPServiceDTBegin;
        private System.DateTime _AEPServiceDTEnd;
        private System.String _AEPInvoiceNo;
        private System.String _AEPPayee;
        private System.String _AEPPayer;
        //Check Edit delete
        private System.String _CEDClaimNo;
        private System.String _CEDPayCode;
        private System.String _CEDComments;
        private System.Decimal _CEDIoutStand;
        private System.Decimal _CEDMoutStand;
        private System.Decimal _CEDEoutStand;
        private System.String _TotalAmount;

        #endregion

        #region Public Properties
        public System.Int64 Pk_check_no
        {
            get { return _pk_check_no; }
            set { _pk_check_no = value; }
        }

        public System.Decimal Check_Amount
        {
            get { return _check_Amount; }
            set { _check_Amount = value; }
        }

        public System.Decimal Current_Recurring_Number
        {
            get { return _current_Recurring_Number; }
            set { _current_Recurring_Number = value; }
        }

        public System.String Original_Recurring
        {
            get { return _original_Recurring; }
            set { _original_Recurring = value; }
        }

        public System.Decimal Check_FK
        {
            get { return _check_FK; }
            set { _check_FK = value; }
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

        public System.DateTime Due_Date
        {
            get { return _due_Date; }
            set { _due_Date = value; }
        }

        public System.String Check_status
        {
            get { return _check_status; }
            set { _check_status = value; }
        }

        public System.String Printed_check
        {
            get { return _printed_check; }
            set { _printed_check = value; }
        }

        public System.DateTime Stop_Delete_Date
        {
            get { return _stop_Delete_Date; }
            set { _stop_Delete_Date = value; }
        }

        public System.DateTime Printed_date
        {
            get { return _printed_date; }
            set { _printed_date = value; }
        }

        public System.String Printed_by
        {
            get { return _printed_by; }
            set { _printed_by = value; }
        }

        public System.String Void_Status
        {
            get { return _void_Status; }
            set { _void_Status = value; }
        }

        public System.String Stop_Payment
        {
            get { return _stop_Payment; }
            set { _stop_Payment = value; }
        }
        public System.DateTime RecIssueDate
        {
            get { return _Rec_Issue_Date; }
            set { _Rec_Issue_Date = value; }
        }
        public System.Decimal CDCheckNumber
        {
            get { return _CD_Check_Number; }
            set { _CD_Check_Number = value; }
        }
        public System.String AEPPaymentID
        {
            get { return _AEPPaymentID; }
            set { _AEPPaymentID = value; }
        }
        public System.String AEPInvoiceNo
        {
            get { return _AEPInvoiceNo; }
            set { _AEPInvoiceNo = value; }
        }
        public System.String AEPPayee
        {
            get { return _AEPPayee; }
            set { _AEPPayee = value; }
        }
        public System.String AEPPayer
        {
            get { return _AEPPayer; }
            set { _AEPPayer = value; }
        }
        public System.DateTime AEPDtServiceBegin
        {
            get { return _AEPServiceDTBegin; }
            set { _AEPServiceDTBegin = value; }
        }
        public System.DateTime AEPDtServiceEnd
        {
            get { return _AEPServiceDTEnd; }
            set { _AEPServiceDTEnd = value; }
        }
        //For Check Edit Delete
        public System.String CEDClaimNo
        {
            get { return _CEDClaimNo; }
            set { _CEDClaimNo = value; }
        }
        public System.String CEDPayCode
        {
            get { return _CEDPayCode; }
            set { _CEDPayCode = value; }
        }
        public System.String CEDComments
        {
            get { return _CEDComments; }
            set { _CEDComments = value; }
        }
        public System.Decimal CEDIOutStand
        {
            get { return _CEDIoutStand; }
            set { _CEDIoutStand = value; }
        }
        public System.Decimal CEDMOutStand
        {
            get { return _CEDMoutStand; }
            set { _CEDMoutStand = value; }
        }
        public System.Decimal CEDEOutStand
        {
            get { return _CEDEoutStand; }
            set { _CEDEoutStand = value; }
        }
        public System.String TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }
        #endregion

        #region Abstract Methods
        public abstract List<CCheckDetails> GetAll();
        public abstract CCheckDetails GetCheckDetailsByID(System.Decimal lpk_check_no);
        public abstract int InsertUpdate_CheckDetails(RIMS_Base.CCheckDetails obj);
        public abstract int Delete_CheckDetails(System.String lpk_check_no);
        public abstract string ActivateInactivate_CheckDetails(string strIDs, int intModifiedBy, bool bIsActive);
        //Get Data After Enter Payment.
        public abstract List<CCheckDetails> GetCDAEP(System.Decimal pk_check_no);
        //Get Data for Edit/Delete
        public abstract List<CCheckDetails> GetChkDetailEditDel(System.Int64 chkNo);
        //Get All Check to make them Print
        public abstract List<CCheckDetails> GetChecksForPrint();
        //Make Check Status to Printed Means 1
        public abstract int Chek_MakePrinted(System.String lpk_check_no, System.String m_strUserName);
        //Make Check Status Reprinted Mans 2
        public abstract int Chek_MakeRePrinted(System.String lpk_check_no, System.String m_strUserName);
        //Make Check Status to Stop Means 3
        public abstract int Chek_MakeStop(System.String lpk_check_no, System.String m_strUserName);
        //Make Check Status to Void Means 4
        public abstract int Chek_MakeVoid(System.String lpk_check_no, System.String m_strUserName);

        //Get check which are printed
        public abstract List<CCheckDetails> GetPostCheckRegister(System.Int64 m_intType);
        //Here if m_intType is 2 means Post Check with Given Date Range.
        public abstract List<CCheckDetails> GetPostCheckRegisterForDateLimit(System.Int64 m_intType, System.DateTime m_DtStart, System.DateTime m_DtEnd);
        //Get Stop Voided Check for Display
        public abstract List<RIMS_Base.CCheckDetails> GetStoppedVoidedCheck(System.Int64 m_intType);
        //Get Non-Stop Non-Voiud Check to Makle then Stop/Void
        public abstract List<RIMS_Base.CCheckDetails> GetStoppedVoidedCheckForDateLimit(System.Int64 m_intType, System.DateTime m_DtStart, System.DateTime m_DtEnd);
        //Get Search Check Datail.
        public abstract DataSet GetCheckDetailsForSearch(System.String m_strClaimType1, System.String m_strClaimType2, System.String m_strClaimType3, System.String m_strClaimType4, System.String m_strClaimType5, System.String m_strClaimNo, System.String m_strOpenFrom, System.String m_strOpenTo, System.String m_strCloseFrom, System.String m_strCloseTo, System.String m_strCheckNo);
        public abstract DataSet GetCheckDetailsForSearch1(System.String m_strClaimType1, System.String m_strClaimType2, System.String m_strClaimType3, System.String m_strClaimType4, System.String m_strClaimType5, System.String m_strClaimNo, System.String m_strOpenFrom, System.String m_strOpenTo, System.String m_strCloseFrom, System.String m_strCloseTo, System.String m_strCheckNo);
        public abstract DataSet GetCheckDetailsForSearch2(System.String m_strClaimType1, System.String m_strClaimType2, System.String m_strClaimType3, System.String m_strClaimType4, System.String m_strClaimType5, System.String m_strClaimNo, System.String m_strOpenFrom, System.String m_strOpenTo, System.String m_strCloseFrom, System.String m_strCloseTo, System.String m_strCheckNo);
        public abstract DataSet GetCheckDetailsForSearch3(System.String m_strClaimType1, System.String m_strClaimType2, System.String m_strClaimType3, System.String m_strClaimType4, System.String m_strClaimType5, System.String m_strClaimNo, System.String m_strOpenFrom, System.String m_strOpenTo, System.String m_strCloseFrom, System.String m_strCloseTo, System.String m_strCheckNo);

        public abstract DataSet GetCheckDetailsForSearchByChk(System.String m_strCheckNo);

        //Generate PDF
        public abstract DataSet GetDataForPDF(System.String m_strChkNo);

        #endregion

    }

}
