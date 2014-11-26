#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CPolicy
{

	#region Constructor
    public CPolicy()
	{
		this._pK_Policy_Id = -1;
		this._fK_Policy_Type = -1;
		this._policy_Number = string.Empty;
        this._carrier = string.Empty;
        //this._underwriter = string.Empty;
        ////this._policy_Begin_Date = DateTime.Now;
        ////this._policy_Expiration_Date = DateTime.Now;
        //this._fK_Policy_Status = -1;
        //this._annual_Premium = -1;
        //this._client_Id = -1;
        //this._client_Location_Code = string.Empty;
        ////this._contract_End_Date = DateTime.Now;
        //this._contract_Number = -1;
        ////this._contract_Start_Date = DateTime.Now;
        //this._employer_Fed_ID_No = -1;
        //this._employer_SIC = -1;
        //this._deductible = string.Empty;
        //this._division_AIG = -1;
        //this._policy_Prefix = string.Empty;
        //this._insured_ISO_Cat = -1;
        //this._updated_By = string.Empty;
        //this._update_Date = DateTime.Now;
        //this._coverage_Description = string.Empty;
        //this._layer_Number = -1;
        //this._states_Covered = string.Empty;
        //this._nCCI_Classification_Code = string.Empty;
        //this._fK_Coverage_Code = -1;
        //this._PolicyType=string.Empty;
        //this._PolicyStatus=string.Empty;
        //this._Cov_Code = string.Empty;

        this.PolType_pK_ID = -1;
        this.PolType_fLD_desc = string.Empty;
        this.PolType_fLD_code = string.Empty;

        this.PolStatus_pK_ID = -1;
        this.PolStatus_fLD_desc = string.Empty;
        this.PolStatus_fLD_code = string.Empty;

        this.CovCode_pK_Coverage_Code = -1;
        this.CovCode_fLD_desc = string.Empty;
        this.CovCode_fLD_code = string.Empty;
        this.CovCode_fK_Policy_type = -1;
	}
	#endregion

	#region Private Variables 
	private System.Int64 _pK_Policy_Id;
	private System.Decimal? _fK_Policy_Type;
	private System.String _policy_Number;
	private System.String _carrier;
	private System.String _underwriter;
	private System.DateTime? _policy_Begin_Date;
	private System.DateTime? _policy_Expiration_Date;
	private System.Decimal? _fK_Policy_Status;
	private System.Decimal? _annual_Premium;
	private System.Decimal? _client_Id;
	private System.String _client_Location_Code;
	private System.DateTime? _contract_End_Date;
	private System.Decimal? _contract_Number;
	private System.DateTime? _contract_Start_Date;
	private System.Decimal? _employer_Fed_ID_No;
	private System.Decimal? _employer_SIC;
	private System.String _deductible;
	private System.Decimal? _division_AIG;
	private System.String _policy_Prefix;
	private System.Decimal? _insured_ISO_Cat;
	private System.String _updated_By;
	private System.DateTime _update_Date;
	private System.String _coverage_Description;
	private System.Decimal _layer_Number;
	private System.String _states_Covered;
	private System.String _nCCI_Classification_Code;
	private System.Decimal _fK_Coverage_Code;
    private System.String _PolicyType;
    private System.String _PolicyStatus;
    private System.String _Cov_Code;

    private System.Decimal PolType_pK_ID;
    private System.String PolType_fLD_desc;
    private System.String PolType_fLD_code;

    private System.Decimal PolStatus_pK_ID;
    private System.String PolStatus_fLD_desc;
    private System.String PolStatus_fLD_code;

    private System.Decimal CovCode_pK_Coverage_Code;
    private System.String CovCode_fLD_desc;
    private System.String CovCode_fLD_code;
    private System.Decimal CovCode_fK_Policy_type;

	#endregion

	#region Public Properties
    public System.Int64 PK_Policy_Id
	{
		get { return  _pK_Policy_Id; }
		set { _pK_Policy_Id = value; }
	}

	public System.Decimal? FK_Policy_Type
	{
		get { return  _fK_Policy_Type; }
		set { _fK_Policy_Type = value; }
	}

	public System.String Policy_Number
	{
		get { return  _policy_Number; }
		set { _policy_Number = value; }
	}

	public System.String Carrier
	{
		get { return  _carrier; }
		set { _carrier = value; }
	}

	public System.String Underwriter
	{
		get { return  _underwriter; }
		set { _underwriter = value; }
	}

	public System.DateTime? Policy_Begin_Date
	{
		get { return  _policy_Begin_Date; }
		set { _policy_Begin_Date = value; }
	}

	public System.DateTime? Policy_Expiration_Date
	{
		get { return  _policy_Expiration_Date; }
		set { _policy_Expiration_Date = value; }
	}

	public System.Decimal? FK_Policy_Status
	{
		get { return  _fK_Policy_Status; }
		set { _fK_Policy_Status = value; }
	}

	public System.Decimal? Annual_Premium
	{
		get { return  _annual_Premium; }
		set { _annual_Premium = value; }
	}

	public System.Decimal? Client_Id
	{
		get { return  _client_Id; }
		set { _client_Id = value; }
	}

	public System.String Client_Location_Code
	{
		get { return  _client_Location_Code; }
		set { _client_Location_Code = value; }
	}

	public System.DateTime? Contract_End_Date
	{
		get { return  _contract_End_Date; }
		set { _contract_End_Date = value; }
	}

	public System.Decimal? Contract_Number
	{
		get { return  _contract_Number; }
		set { _contract_Number = value; }
	}

	public System.DateTime? Contract_Start_Date
	{
		get { return  _contract_Start_Date; }
		set { _contract_Start_Date = value; }
	}

	public System.Decimal? Employer_Fed_ID_No
	{
		get { return  _employer_Fed_ID_No; }
		set { _employer_Fed_ID_No = value; }
	}

	public System.Decimal? Employer_SIC
	{
		get { return  _employer_SIC; }
		set { _employer_SIC = value; }
	}

	public System.String Deductible
	{
		get { return  _deductible; }
		set { _deductible = value; }
	}

	public System.Decimal? Division_AIG
	{
		get { return  _division_AIG; }
		set { _division_AIG = value; }
	}

	public System.String Policy_Prefix
	{
		get { return  _policy_Prefix; }
		set { _policy_Prefix = value; }
	}

	public System.Decimal? Insured_ISO_Cat
	{
		get { return  _insured_ISO_Cat; }
		set { _insured_ISO_Cat = value; }
	}

	public System.String Updated_By
	{
		get { return  _updated_By; }
		set { _updated_By = value; }
	}

	public System.DateTime Update_Date
	{
		get { return  _update_Date; }
		set { _update_Date = value; }
	}

	public System.String Coverage_Description
	{
		get { return  _coverage_Description; }
		set { _coverage_Description = value; }
	}

	public System.Decimal Layer_Number
	{
		get { return  _layer_Number; }
		set { _layer_Number = value; }
	}

	public System.String States_Covered
	{
		get { return  _states_Covered; }
		set { _states_Covered = value; }
	}

	public System.String NCCI_Classification_Code
	{
		get { return  _nCCI_Classification_Code; }
		set { _nCCI_Classification_Code = value; }
	}

	public System.Decimal FK_Coverage_Code
	{
		get { return  _fK_Coverage_Code; }
		set { _fK_Coverage_Code = value; }
	}

    public System.String PolicyType
    {
        get
        {
            return _PolicyType;
        }
        set
        {
            _PolicyType = value;
        }
    }
    public System.String PolicyStatus
    {
        get
        {
            return _PolicyStatus;
        }
        set
        {
            _PolicyStatus = value;
        }
    }
    public System.String CovCode
    {
        get { return _Cov_Code; }
        set { _Cov_Code = value; }
    }

    public System.Decimal PolicyTypePK_ID
    {
        get { return PolType_pK_ID; }
        set { PolType_pK_ID = value; }
    }
    public System.String PolicyTypeFLD_desc
    {
        get { return PolType_fLD_desc; }
        set { PolType_fLD_desc = value; }
    }
    public System.String PolicyTypeFLD_code
    {
        get { return PolType_fLD_code; }
        set { PolType_fLD_code = value; }
    }

    public System.Decimal PolicyStatusPK_ID
    {
        get { return PolStatus_pK_ID; }
        set { PolStatus_pK_ID = value; }
    }
    public System.String PolicyStatusFLD_desc
    {
        get { return PolStatus_fLD_desc; }
        set { PolStatus_fLD_desc = value; }
    }
    public System.String PolicyStatusFLD_code
    {
        get { return PolType_fLD_code; }
        set { PolStatus_fLD_code = value; }
    }

    public System.Decimal CovCode_PK_Id
    {
        get { return CovCode_pK_Coverage_Code; }
        set { CovCode_pK_Coverage_Code = value; }
    }
    public System.String CovCode_FLD_Desc
    {
        get { return CovCode_fLD_desc; }
        set { CovCode_fLD_desc = value; }
    }
    public System.String CovCode_FLD_Code
    {
        get { return CovCode_fLD_code; }
        set { CovCode_fLD_code = value; }
    }
    public System.Decimal CovCode_FK_PolType
    {
        get { return CovCode_fK_Policy_type; }
        set { CovCode_fK_Policy_type = value; }
    }

	#endregion

	#region Abstract Methods
	public abstract List<CPolicy> GetAll();
    public abstract List<CPolicy> GetPolicyByID(System.Decimal lPK_Policy_Id);
	public abstract int InsertUpdate_Policy(RIMS_Base.CPolicy obj);
	public abstract int Delete_Policy(System.String Policy_Ids);
	public abstract string ActivateInactivate_Policy(string strIDs, int intModifiedBy, bool bIsActive);
    public abstract List<CPolicy> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria);
    public abstract List<CPolicy> GetAllPolicyType();
    public abstract List<CPolicy> GetAllPolicyStatus();
    public abstract List<CPolicy> GetCovCodeByPolType(System.Decimal pK_PolicyType_Id);

	#endregion

}

}
