#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
#endregion

namespace RIMS_Base
{

    [Serializable]
    public abstract class cSettlement
    {

        #region Constructor
        public cSettlement()
        {
            this._pk_Settlement = -1;
            //this._claim_Number = string.Empty;
            //this._table_Name = string.Empty;
            //this._fK_Table_Name = string.Empty;
            //this._dOB = DateTime.Now;
            //this._dOH = DateTime.Now;
            //this._subsid = string.Empty;
            //this._location = string.Empty;
            //this._dept = string.Empty;
            //this._jOB = string.Empty;
            //this._fk_State_of_Coverage = -1;
            //this._fK_State_of_Accident = -1;
            //this._dOI = DateTime.Now;
            //this._fK_Body_Parts = -1;
            //this._fK_Injury = -1;
            //this._description = string.Empty;
            //this._treating_Physician = string.Empty;
            //this._diagnosis = string.Empty;
            //this._last_Office_Visit_Date = DateTime.Now;
            //this._next_Scheduled_Visit = DateTime.Now;
            //this._referral = string.Empty;
            //this._treating_Physician_New = string.Empty;
            //this._physical_Therapy = string.Empty;
            //this._surgery = string.Empty;
            //this._off_Work = string.Empty;
            //this._estimated_RTW = string.Empty;
            //this._return_to_Work_Ful_Duty = string.Empty;
            //this._rTW_Date = DateTime.Now;
            //this._return_Work_Restricted_Duty = string.Empty;
            //this._temporary_From = DateTime.Now;
            //this._temporary_to = DateTime.Now;
            //this._explain = string.Empty;
            //this._permanent_Fld = string.Empty;
            //this._estimated_MMI = DateTime.Now;
            //this._mMI = DateTime.Now;
            //this._estimated_Impairment = -1;
            //this._actual_Impairment = -1;
            //this._physicians_Panel_Requested = string.Empty;
            //this._new_TReating_Physician = string.Empty;
            //this._petition_Settlement = string.Empty;
            //this._decree_and_Order = string.Empty;
            //this._compromise = string.Empty;
            //this._not_Applicable = string.Empty;
            //this._no_Dispute = string.Empty;
            //this._status_Only = string.Empty;
            //this._classification = string.Empty;
            //this._defence_councils_Name = string.Empty;
            //this._phone = string.Empty;
            //this._claimant_Attorney = string.Empty;
            //this._phone1 = string.Empty;
            //this._requested_Amount = -1;
            //this._potential_Total_Exposure = -1;
            //this._settled = string.Empty;
            //this._amount = -1;
            //this._location_Representative = DateTime.Now;
            //this._claims_Manager = DateTime.Now;
            //this._risk_Manager = DateTime.Now;
            //this._treasury = DateTime.Now;
            //this._cFO = DateTime.Now;
            //this._comments = string.Empty;
            //this._updated_By = string.Empty;
            //this._update_Date = DateTime.Now;
            //this._compensatiton = string.Empty;
            //this._reimbursement = string.Empty;
            //this._waive = string.Empty;
            //this._closeMedicals = string.Empty;
            //this._confidentiality = string.Empty;
            //this._otherMedicals = string.Empty;
            //this._permanentTotal = string.Empty;
            //this._resignation = string.Empty;
            //this._other = string.Empty;
            //this._settlement_Method = string.Empty;
            //this._fK_Method_Of_Settlement = -1;
            //this._resignationDate = DateTime.Now;
        }
        #endregion

        #region Private Variables
        private System.Decimal _pk_Settlement;
        private System.String _claim_Number;
        private System.String _table_Name;
        private System.Decimal _fK_Table_Name;
        private System.String _first_Name;
        private System.String _last_Name;
        private System.DateTime? _dOB;
        private System.DateTime? _dOH;
        private System.String _subsid;
        private System.String _location;
        private System.String _dept;
        private System.String _jOB;
        private System.String _fk_State_of_Coverage;
        private System.String _fK_State_of_Accident;
        private System.DateTime? _dOI;
        private System.String _fK_Body_Parts;
        private System.String _fK_Injury;
        private System.String _description;
        private System.String _treating_Physician;
        private System.String _diagnosis;
        private System.DateTime? _last_Office_Visit_Date;
        private System.DateTime? _next_Scheduled_Visit;
        private System.String _referral;
        private System.String _treating_Physician_New;
        private System.String _physical_Therapy;
        private System.String _surgery;
        private System.String _off_Work;
        private System.String _estimated_RTW;
        private System.String _return_to_Work_Ful_Duty;
        private System.DateTime? _rTW_Date;
        private System.String _return_Work_Restricted_Duty;
        private System.DateTime? _temporary_From;
        private System.DateTime? _temporary_to;
        private System.String _explain;
        private System.String _permanent_Fld;
        private System.DateTime? _estimated_MMI;
        private System.DateTime? _mMI;
        private System.Decimal? _estimated_Impairment;
        private System.Decimal? _actual_Impairment;
        private System.String _physicians_Panel_Requested;
        private System.String _new_TReating_Physician;
        private System.String _petition_Settlement;
        private System.String _decree_and_Order;
        private System.String _compromise;
        private System.String _not_Applicable;
        private System.String _no_Dispute;
        private System.String _status_Only;
        private System.String _classification;
        private System.String _defence_councils_Name;
        private System.String _phone;
        private System.String _claimant_Attorney;
        private System.String _phone1;
        private System.Decimal? _requested_Amount;
        private System.Decimal? _potential_Total_Exposure;
        private System.String _settled;
        private System.Decimal? _amount;
        private System.DateTime? _location_Representative;
        private System.DateTime? _claims_Manager;
        private System.DateTime? _risk_Manager;
        private System.DateTime? _treasury;
        private System.DateTime? _cFO;
        private System.String _ycomments;
        private System.String _ncomments;
        private System.String _updated_By;
        private System.DateTime? _update_Date;
        private System.String _compensatiton;
        private System.String _reimbursement;
        private System.String _waive;
        private System.String _closeMedicals;
        private System.String _confidentiality;
        private System.String _otherMedicals;
        private System.String _permanentTotal;
        private System.String _resignation;
        private System.String _other;
        private System.String _settlement_Method;
        private System.String _fK_Method_Of_Settlement;
        private System.DateTime? _resignationDate;
        #endregion

        #region Public Properties
        public System.Decimal Pk_Settlement
        {
            get { return _pk_Settlement; }
            set { _pk_Settlement = value; }
        }

        public System.String Claim_Number
        {
            get { return _claim_Number; }
            set { _claim_Number = value; }
        }

        public System.String Table_Name
        {
            get { return _table_Name; }
            set { _table_Name = value; }
        }
        public System.String First_Name
        {
            get { return _first_Name; }
            set { _first_Name = value; }
        }
        public System.String Last_Name
        {
            get { return _last_Name; }
            set { _last_Name = value; }
        }
        public System.Decimal FK_Table_Name
        {
            get { return _fK_Table_Name; }
            set { _fK_Table_Name = value; }
        }

        public System.DateTime? DOB
        {
            get { return _dOB; }
            set { _dOB = value; }
        }

        public System.DateTime? DOH
        {
            get { return _dOH; }
            set { _dOH = value; }
        }

        public System.String Subsid
        {
            get { return _subsid; }
            set { _subsid = value; }
        }

        public System.String Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public System.String Dept
        {
            get { return _dept; }
            set { _dept = value; }
        }

        public System.String JOB
        {
            get { return _jOB; }
            set { _jOB = value; }
        }

        public System.String Fk_State_of_Coverage
        {
            get { return _fk_State_of_Coverage; }
            set { _fk_State_of_Coverage = value; }
        }

        public System.String FK_State_of_Accident
        {
            get { return _fK_State_of_Accident; }
            set { _fK_State_of_Accident = value; }
        }

        public System.DateTime? DOI
        {
            get { return _dOI; }
            set { _dOI = value; }
        }

        public System.String FK_Body_Parts
        {
            get { return _fK_Body_Parts; }
            set { _fK_Body_Parts = value; }
        }

        public System.String FK_Injury
        {
            get { return _fK_Injury; }
            set { _fK_Injury = value; }
        }

        public System.String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public System.String Treating_Physician
        {
            get { return _treating_Physician; }
            set { _treating_Physician = value; }
        }

        public System.String Diagnosis
        {
            get { return _diagnosis; }
            set { _diagnosis = value; }
        }

        public System.DateTime? Last_Office_Visit_Date
        {
            get { return _last_Office_Visit_Date; }
            set { _last_Office_Visit_Date = value; }
        }

        public System.DateTime? Next_Scheduled_Visit
        {
            get { return _next_Scheduled_Visit; }
            set { _next_Scheduled_Visit = value; }
        }

        public System.String Referral
        {
            get { return _referral; }
            set { _referral = value; }
        }

        public System.String Treating_Physician_New
        {
            get { return _treating_Physician_New; }
            set { _treating_Physician_New = value; }
        }

        public System.String Physical_Therapy
        {
            get { return _physical_Therapy; }
            set { _physical_Therapy = value; }
        }

        public System.String Surgery
        {
            get { return _surgery; }
            set { _surgery = value; }
        }

        public System.String Off_Work
        {
            get { return _off_Work; }
            set { _off_Work = value; }
        }

        public System.String Estimated_RTW
        {
            get { return _estimated_RTW; }
            set { _estimated_RTW = value; }
        }

        public System.String Return_to_Work_Ful_Duty
        {
            get { return _return_to_Work_Ful_Duty; }
            set { _return_to_Work_Ful_Duty = value; }
        }

        public System.DateTime? RTW_Date
        {
            get { return _rTW_Date; }
            set { _rTW_Date = value; }
        }

        public System.String Return_Work_Restricted_Duty
        {
            get { return _return_Work_Restricted_Duty; }
            set { _return_Work_Restricted_Duty = value; }
        }

        public System.DateTime? Temporary_From
        {
            get { return _temporary_From; }
            set { _temporary_From = value; }
        }

        public System.DateTime? Temporary_to
        {
            get { return _temporary_to; }
            set { _temporary_to = value; }
        }

        public System.String Explain
        {
            get { return _explain; }
            set { _explain = value; }
        }

        public System.String Permanent_Fld
        {
            get { return _permanent_Fld; }
            set { _permanent_Fld = value; }
        }

        public System.DateTime? Estimated_MMI
        {
            get { return _estimated_MMI; }
            set { _estimated_MMI = value; }
        }

        public System.DateTime? MMI
        {
            get { return _mMI; }
            set { _mMI = value; }
        }

        public System.Decimal? Estimated_Impairment
        {
            get { return _estimated_Impairment; }
            set { _estimated_Impairment = value; }
        }

        public System.Decimal? Actual_Impairment
        {
            get { return _actual_Impairment; }
            set { _actual_Impairment = value; }
        }

        public System.String Physicians_Panel_Requested
        {
            get { return _physicians_Panel_Requested; }
            set { _physicians_Panel_Requested = value; }
        }

        public System.String New_TReating_Physician
        {
            get { return _new_TReating_Physician; }
            set { _new_TReating_Physician = value; }
        }

        public System.String Petition_Settlement
        {
            get { return _petition_Settlement; }
            set { _petition_Settlement = value; }
        }

        public System.String Decree_and_Order
        {
            get { return _decree_and_Order; }
            set { _decree_and_Order = value; }
        }

        public System.String Compromise
        {
            get { return _compromise; }
            set { _compromise = value; }
        }

        public System.String Not_Applicable
        {
            get { return _not_Applicable; }
            set { _not_Applicable = value; }
        }

        public System.String No_Dispute
        {
            get { return _no_Dispute; }
            set { _no_Dispute = value; }
        }

        public System.String Status_Only
        {
            get { return _status_Only; }
            set { _status_Only = value; }
        }

        public System.String Classification
        {
            get { return _classification; }
            set { _classification = value; }
        }

        public System.String Defence_councils_Name
        {
            get { return _defence_councils_Name; }
            set { _defence_councils_Name = value; }
        }

        public System.String Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public System.String Claimant_Attorney
        {
            get { return _claimant_Attorney; }
            set { _claimant_Attorney = value; }
        }

        public System.String Phone1
        {
            get { return _phone1; }
            set { _phone1 = value; }
        }

        public System.Decimal? Requested_Amount
        {
            get { return _requested_Amount; }
            set { _requested_Amount = value; }
        }

        public System.Decimal? Potential_Total_Exposure
        {
            get { return _potential_Total_Exposure; }
            set { _potential_Total_Exposure = value; }
        }

        public System.String Settled
        {
            get { return _settled; }
            set { _settled = value; }
        }

        public System.Decimal? Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public System.DateTime? Location_Representative
        {
            get { return _location_Representative; }
            set { _location_Representative = value; }
        }

        public System.DateTime? Claims_Manager
        {
            get { return _claims_Manager; }
            set { _claims_Manager = value; }
        }

        public System.DateTime? Risk_Manager
        {
            get { return _risk_Manager; }
            set { _risk_Manager = value; }
        }

        public System.DateTime? Treasury
        {
            get { return _treasury; }
            set { _treasury = value; }
        }

        public System.DateTime? CFO
        {
            get { return _cFO; }
            set { _cFO = value; }
        }

        public System.String YComments
        {
            get { return _ycomments; }
            set { _ycomments = value; }
        }
        public System.String NComments
        {
            get { return _ncomments; }
            set { _ncomments = value; }
        }
        public System.String Updated_By
        {
            get { return _updated_By; }
            set { _updated_By = value; }
        }

        public System.DateTime? Update_Date
        {
            get { return _update_Date; }
            set { _update_Date = value; }
        }

        public System.String Compensatiton
        {
            get { return _compensatiton; }
            set { _compensatiton = value; }
        }

        public System.String Reimbursement
        {
            get { return _reimbursement; }
            set { _reimbursement = value; }
        }

        public System.String Waive
        {
            get { return _waive; }
            set { _waive = value; }
        }

        public System.String CloseMedicals
        {
            get { return _closeMedicals; }
            set { _closeMedicals = value; }
        }

        public System.String Confidentiality
        {
            get { return _confidentiality; }
            set { _confidentiality = value; }
        }

        public System.String OtherMedicals
        {
            get { return _otherMedicals; }
            set { _otherMedicals = value; }
        }

        public System.String PermanentTotal
        {
            get { return _permanentTotal; }
            set { _permanentTotal = value; }
        }

        public System.String Resignation
        {
            get { return _resignation; }
            set { _resignation = value; }
        }

        public System.String Other
        {
            get { return _other; }
            set { _other = value; }
        }

        public System.String Settlement_Method
        {
            get { return _settlement_Method; }
            set { _settlement_Method = value; }
        }

        public System.String FK_Method_Of_Settlement
        {
            get { return _fK_Method_Of_Settlement; }
            set { _fK_Method_Of_Settlement = value; }
        }

        public System.DateTime? ResignationDate
        {
            get { return _resignationDate; }
            set { _resignationDate = value; }
        }

        #endregion

        #region Abstract Methods
        public abstract List<cSettlement> GetAll(Boolean blnIsActive);
        public abstract List<cSettlement> GetsettlementByID(System.Decimal lPk_Settlement);
        public abstract int InsertUpdate_settlement(RIMS_Base.cSettlement obj);
        public abstract int Delete_settlement(System.Decimal lPk_Settlement);
        public abstract string ActivateInactivate_settlement(string strIDs, int intModifiedBy, bool bIsActive);
        public abstract DataSet GetSettlementLabel();
        #endregion

    }

}
