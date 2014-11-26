using System;
using System.Collections.Generic;
using System.Text;

namespace RIMS_Base
{
    [Serializable]
   public abstract class CWorkersComp
    {
#region Constructor
       public CWorkersComp()
	{
        this._pK_Workers_Comp = -1;
		this._claim_Number = string.Empty;
		this._carrier_Claim_Number = string.Empty;
		this._status = string.Empty;
		//this._claimant_Last_Name = string.Empty;
		//this._date_Reported_To_FairPoint = DateTime.Now;
        //this._fK_claimant = -1;
		//this._date_Claim_Opened = DateTime.Now;
		this._union_Member = string.Empty;
		//this._date_Claim_Closed = DateTime.Now;
		this._fK_Entity = -1;
		//this._date_Claim_Reopened = DateTime.Now;
		//this._date_Of_Incident = DateTime.Now;
		//this._date_Reported_To_Carrier = DateTime.Now;
        //this._benefit_State = -1;
        //this._fK_Policy = -1;
        //this._comp_Rate = -1;
		this._tPA = string.Empty;
		this._time_Of_Loss = string.Empty;
		//this._last_Date_Worked = DateTime.Now;
		//this._date_RTW = DateTime.Now;
		this._transitional_Duty = string.Empty;
		this._transitional_Duty_Refused = string.Empty;
		this._claim_Type = string.Empty;
        //this._fK_Injury_Code = -1;
        //this._fK_Cause_Code = -1;
        //this._fK_Body_Part = -1;
		this._accident_Description = string.Empty;
		this._fatility = string.Empty;
		//this._dOB = DateTime.Now;
		//this._date_Of_Hire = DateTime.Now;
		this._legal_Representation = string.Empty;
		this._attorney_Name = string.Empty;
		this._attorney_Telephone = string.Empty;
		this._cR_Name_Internal = string.Empty;
		this._cR_Telephone_Internal = string.Empty;
		this._cR_E_Mail_Internal = string.Empty;
		this._cR_Name_Other = string.Empty;
		this._cR_Telephone_Other = string.Empty;
		this._cR_E_Mail_Other = string.Empty;
		this._updated_By = string.Empty;
		this._update_Date = DateTime.Now;

        this._last_Name = string.Empty;
        this._first_Name = string.Empty;

   
	}
	#endregion

	#region Private Variables 
	private System.Int32 _pK_Workers_Comp;
	private System.String _claim_Number;
	private System.String _carrier_Claim_Number;
	private System.String _status;
//	private System.String _claimant_Last_Name;
	private System.DateTime ? _date_Reported_To_FairPoint;
    private System.Decimal ? _fK_claimant;
	private System.DateTime ? _date_Claim_Opened;
	private System.String _union_Member;
	private System.DateTime ? _date_Claim_Closed;
	private System.Decimal ? _fK_Entity;
	private System.DateTime ? _date_Claim_Reopened;
	private System.DateTime ? _date_Of_Incident;
	private System.DateTime ? _date_Reported_To_Carrier;
	private System.Decimal ? _benefit_State;
	private System.Decimal ? _fK_Policy;
	private System.Decimal ? _comp_Rate;
	private System.String _tPA;
	private System.String _time_Of_Loss;
	private System.DateTime ? _last_Date_Worked;
	private System.DateTime ? _date_RTW;
	private System.String _transitional_Duty;
	private System.String _transitional_Duty_Refused;
	private System.String _claim_Type;
	private System.Decimal ? _fK_Injury_Code;
	private System.Decimal ? _fK_Cause_Code;
	private System.Decimal ? _fK_Body_Part;
	private System.String _accident_Description;
	private System.String _fatility;
	private System.DateTime ? _dOB;
	private System.DateTime ? _date_Of_Hire;
	private System.String _legal_Representation;
	private System.String _attorney_Name;
	private System.String _attorney_Telephone;
	private System.String _cR_Name_Internal;
	private System.String _cR_Telephone_Internal;
	private System.String _cR_E_Mail_Internal;
	private System.String _cR_Name_Other;
	private System.String _cR_Telephone_Other;
	private System.String _cR_E_Mail_Other;
	private System.String _updated_By;
	private System.DateTime ? _update_Date;

    private System.String _last_Name;
    private System.String _first_Name;

    private System.String _policy_Number_Claim;
    private System.DateTime? _effective_Policy_Date;
    private System.DateTime? _expiration_Policy_Date;
    private System.String _Carrier;
	#endregion

	#region Public Properties
	public System.Int32 PK_Workers_Comp
	{
		get { return  _pK_Workers_Comp; }
		set { _pK_Workers_Comp = value; }
	}

	public System.String Claim_Number
	{
		get { return  _claim_Number; }
		set { _claim_Number = value; }
	}

    public System.String Last_Name
    {
        get { return _last_Name; }
        set { _last_Name = value; }
    }

    public System.String First_Name
    {
        get { return _first_Name; }
        set { _first_Name = value; }
    }

	public System.String Carrier_Claim_Number
	{
		get { return  _carrier_Claim_Number; }
		set { _carrier_Claim_Number = value; }
	}

	public System.String Status
	{
		get { return  _status; }
		set { _status = value; }
	}

    //public System.String Claimant_Last_Name
    //{
    //    get { return  _claimant_Last_Name; }
    //    set { _claimant_Last_Name = value; }
    //}

	public System.DateTime ? Date_Reported_To_FairPoint
	{
		get { return  _date_Reported_To_FairPoint; }
		set { _date_Reported_To_FairPoint = value; }
	}

       public System.Decimal? FK_Claimant
	{
        get { return _fK_claimant; }
        set { _fK_claimant = value; }
	}

       public System.DateTime? Date_Claim_Opened
	{
		get { return  _date_Claim_Opened; }
		set { _date_Claim_Opened = value; }
	}

	public System.String Union_Member
	{
		get { return  _union_Member; }
		set { _union_Member = value; }
	}

       public System.DateTime ? Date_Claim_Closed
	{
		get { return  _date_Claim_Closed; }
		set { _date_Claim_Closed = value; }
	}

       public System.Decimal ? FK_Entity
	{
		get { return  _fK_Entity; }
		set { _fK_Entity = value; }
	}

       public System.DateTime ? Date_Claim_Reopened
	{
		get { return  _date_Claim_Reopened; }
		set { _date_Claim_Reopened = value; }
	}

       public System.DateTime ? Date_Of_Incident
	{
		get { return  _date_Of_Incident; }
		set { _date_Of_Incident = value; }
	}

       public System.DateTime ? Date_Reported_To_Carrier
	{
		get { return  _date_Reported_To_Carrier; }
		set { _date_Reported_To_Carrier = value; }
	}

       public System.Decimal ? Benefit_State
	{
		get { return  _benefit_State; }
		set { _benefit_State = value; }
	}

       public System.Decimal ? FK_Policy
	{
		get { return  _fK_Policy; }
		set { _fK_Policy = value; }
	}

       public System.Decimal ? Comp_Rate
	{
		get { return  _comp_Rate; }
		set { _comp_Rate = value; }
	}

	public System.String TPA
	{
		get { return  _tPA; }
		set { _tPA = value; }
	}

	public System.String Time_Of_Loss
	{
		get { return  _time_Of_Loss; }
		set { _time_Of_Loss = value; }
	}

       public System.DateTime? Last_Date_Worked
	{
		get { return  _last_Date_Worked; }
		set { _last_Date_Worked = value; }
	}

       public System.DateTime? Date_RTW
	{
		get { return  _date_RTW; }
		set { _date_RTW = value; }
	}

	public System.String Transitional_Duty
	{
		get { return  _transitional_Duty; }
		set { _transitional_Duty = value; }
	}

	public System.String Transitional_Duty_Refused
	{
		get { return  _transitional_Duty_Refused; }
		set { _transitional_Duty_Refused = value; }
	}

	public System.String Claim_Type
	{
		get { return  _claim_Type; }
		set { _claim_Type = value; }
	}

       public System.Decimal? FK_Injury_Code
	{
		get { return  _fK_Injury_Code; }
		set { _fK_Injury_Code = value; }
	}

       public System.Decimal? FK_Cause_Code
	{
		get { return  _fK_Cause_Code; }
		set { _fK_Cause_Code = value; }
	}

       public System.Decimal? FK_Body_Part
	{
		get { return  _fK_Body_Part; }
		set { _fK_Body_Part = value; }
	}

	public System.String Accident_Description
	{
		get { return  _accident_Description; }
		set { _accident_Description = value; }
	}

	public System.String Fatility
	{
		get { return  _fatility; }
		set { _fatility = value; }
	}

       public System.DateTime? DOB
	{
		get { return  _dOB; }
		set { _dOB = value; }
	}

       public System.DateTime? Date_Of_Hire
	{
		get { return  _date_Of_Hire; }
		set { _date_Of_Hire = value; }
	}

	public System.String Legal_Representation
	{
		get { return  _legal_Representation; }
		set { _legal_Representation = value; }
	}

	public System.String Attorney_Name
	{
		get { return  _attorney_Name; }
		set { _attorney_Name = value; }
	}

	public System.String Attorney_Telephone
	{
		get { return  _attorney_Telephone; }
		set { _attorney_Telephone = value; }
	}

	public System.String CR_Name_Internal
	{
		get { return  _cR_Name_Internal; }
		set { _cR_Name_Internal = value; }
	}

	public System.String CR_Telephone_Internal
	{
		get { return  _cR_Telephone_Internal; }
		set { _cR_Telephone_Internal = value; }
	}

	public System.String CR_E_Mail_Internal
	{
		get { return  _cR_E_Mail_Internal; }
		set { _cR_E_Mail_Internal = value; }
	}

	public System.String CR_Name_Other
	{
		get { return  _cR_Name_Other; }
		set { _cR_Name_Other = value; }
	}

	public System.String CR_Telephone_Other
	{
		get { return  _cR_Telephone_Other; }
		set { _cR_Telephone_Other = value; }
	}

	public System.String CR_E_Mail_Other
	{
		get { return  _cR_E_Mail_Other; }
		set { _cR_E_Mail_Other = value; }
	}

	public System.String Updated_By
	{
		get { return  _updated_By; }
		set { _updated_By = value; }
	}

       public System.DateTime? Update_Date
	{
		get { return  _update_Date; }
		set { _update_Date = value; }
	}



    public System.String Policy_Number_Claim
    {
        get { return _policy_Number_Claim; }
        set { _policy_Number_Claim = value; }
    }

    public System.DateTime? Effective_Policy_Date
    {
        get { return _effective_Policy_Date; }
        set { _effective_Policy_Date = value; }
    }

    public System.DateTime? Expiration_Policy_Date
    {
        get { return _expiration_Policy_Date; }
        set { _expiration_Policy_Date = value; }
    }

       public System.String Carrier
       {
           get { return _Carrier; }
           set { _Carrier = value; }
       }
	#endregion

	#region Abstract Methods
       public abstract List<CWorkersComp> GetAll(Boolean blnIsActive);
       public abstract List<CWorkersComp> Get_Worker_CompensationByID(System.Int32 lPK_Workers_Comp);

       public abstract List<CWorkersComp> GetCliamant_ByID(System.Int32 pK_Workers_Comp, System.Decimal pK_Claimant_Id);
       public abstract List<CWorkersComp> GetCarrier_ByID(System.Int32 pK_Workers_Comp, System.Decimal pK_Policy_Id);

       public abstract int InsertUpdateers_Compensation(RIMS_Base.CWorkersComp obj);
       public abstract int Deleteers_Compensation(System.Int32 lPK_Workers_Comp);
	public abstract string ActivateInactivateers_Compensation(string strIDs, int intModifiedBy, bool bIsActive);
	#endregion

    }
}
