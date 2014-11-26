using System;
using System.Collections.Generic;
using System.Text;

namespace RIMS_Base
{
    
    [Serializable]
public abstract class CPolicyCoverage
{

	#region Constructor
	public CPolicyCoverage()
	{
        this._pK_Policy_Coverage_Id = -1;
        this._fK_Policy = -1;
        this._policy_Coverage = string.Empty;
        //this._policy_Deductible = -1;
        //this._occurrence_Limit = -1;
        //this._aggregate_Limit = -1;
        //this._gL_Rent_Damage = -1;
        //this._gL_Medical = -1;
        //this._gL_Products = -1;
        //this._aL_PIP = -1;
        //this._aL_Medical = -1;
        //this._aL_Uninsured = string.Empty;
        //this._aL_Underinsured = string.Empty;
        //this._umbrella = -1;
        this._other_Policy_Type = string.Empty;
        //this._fK_Policy_Feature_1 = -1;
        //this._deductible_1 = -1;
        //this._limit_1 = -1;
        //this._fK_Policy_Feature_2 = -1;
        //this._deductible_2 = -1;
        //this._limit_2 = -1;
        //this._fK_Policy_Feature_3 = -1;
        //this._deductible_3 = -1;
        //this._limit_3 = -1;
        //this._fK_Policy_Feature_4 = -1;
        //this._deductible_4 = -1;
        //this._limit_4 = -1;
        //this._fK_Policy_Feature_5 = -1;
        //this._deductible_5 = -1;
        //this._limit_5 = -1;
        //this._fK_Policy_Feature_6 = -1;
        //this._deductible_6 = -1;
        //this._limit_6 = -1;
        this._updated_By = string.Empty;
        this._update_Date = DateTime.Now;
        this._PolPolicy_Number = string.Empty;
        this.m_strPolicyFeature1 = string.Empty;
        this.m_strPolicyFeature2 = string.Empty;
        this.m_strPolicyFeature3 = string.Empty;
        this.m_strPolicyFeature4 = string.Empty;
        this.m_strPolicyFeature5 = string.Empty;
        this.m_strPolicyFeature6 = string.Empty;
        this.PolicyFeature = string.Empty;
        this.PolicyFeature_Pk_Id = -1;
	}
	#endregion

	#region Private Variables 
	private System.Int32 _pK_Policy_Coverage_Id;
	private System.Decimal _fK_Policy;
	private System.String _policy_Coverage;
	private System.Decimal? _policy_Deductible;
	private System.Decimal? _occurrence_Limit;
	private System.Decimal? _aggregate_Limit;
	private System.Decimal? _gL_Rent_Damage;
	private System.Decimal? _gL_Medical;
	private System.Decimal? _gL_Products;
	private System.Decimal? _aL_PIP;
	private System.Decimal? _aL_Medical;
	private System.String _aL_Uninsured;
	private System.String _aL_Underinsured;
	private System.Decimal? _umbrella;
	private System.String _other_Policy_Type;
	private System.Decimal? _fK_Policy_Feature_1;
	private System.Decimal? _deductible_1;
	private System.Decimal? _limit_1;
	private System.Decimal? _fK_Policy_Feature_2;
	private System.Decimal? _deductible_2;
	private System.Decimal? _limit_2;
	private System.Decimal? _fK_Policy_Feature_3;
	private System.Decimal? _deductible_3;
	private System.Decimal? _limit_3;
	private System.Decimal? _fK_Policy_Feature_4;
	private System.Decimal? _deductible_4;
	private System.Decimal? _limit_4;
	private System.Decimal? _fK_Policy_Feature_5;
	private System.Decimal? _deductible_5;
	private System.Decimal? _limit_5;
	private System.Decimal? _fK_Policy_Feature_6;
	private System.Decimal? _deductible_6;
	private System.Decimal? _limit_6;
	private System.String _updated_By;
	private System.DateTime _update_Date;
    private System.String _PolPolicy_Number;

    private System.String m_strPolicyFeature1;
    private System.String m_strPolicyFeature2;
    private System.String m_strPolicyFeature3;
    private System.String m_strPolicyFeature4;
    private System.String m_strPolicyFeature5;
    private System.String m_strPolicyFeature6;

    private System.Decimal _PolicyFeature_Pk_Id;
    private System.String _PolicyFeature;
	#endregion

	#region Public Properties
    public System.String PolicyNumber
    {
        get { return _PolPolicy_Number;}
        set { _PolPolicy_Number = value; }
    }
	public System.Int32 PK_Policy_Coverage_Id
	{
		get { return  _pK_Policy_Coverage_Id; }
		set { _pK_Policy_Coverage_Id = value; }
	}

	public System.Decimal FK_Policy
	{
		get { return  _fK_Policy; }
		set { _fK_Policy = value; }
	}

	public System.String Policy_Coverage
	{
		get { return  _policy_Coverage; }
		set { _policy_Coverage = value; }
	}

	public System.Decimal? Policy_Deductible
	{
		get { return  _policy_Deductible; }
		set { _policy_Deductible = value; }
	}

	public System.Decimal? Occurrence_Limit
	{
		get { return  _occurrence_Limit; }
		set { _occurrence_Limit = value; }
	}

	public System.Decimal? Aggregate_Limit
	{
		get { return  _aggregate_Limit; }
		set { _aggregate_Limit = value; }
	}

	public System.Decimal? GL_Rent_Damage
	{
		get { return  _gL_Rent_Damage; }
		set { _gL_Rent_Damage = value; }
	}

	public System.Decimal? GL_Medical
	{
		get { return  _gL_Medical; }
		set { _gL_Medical = value; }
	}

	public System.Decimal? GL_Products
	{
		get { return  _gL_Products; }
		set { _gL_Products = value; }
	}

	public System.Decimal? AL_PIP
	{
		get { return  _aL_PIP; }
		set { _aL_PIP = value; }
	}

	public System.Decimal? AL_Medical
	{
		get { return  _aL_Medical; }
		set { _aL_Medical = value; }
	}

	public System.String AL_Uninsured
	{
		get { return  _aL_Uninsured; }
		set { _aL_Uninsured = value; }
	}

	public System.String AL_Underinsured
	{
		get { return  _aL_Underinsured; }
		set { _aL_Underinsured = value; }
	}

	public System.Decimal? Umbrella
	{
		get { return  _umbrella; }
		set { _umbrella = value; }
	}

	public System.String Other_Policy_Type
	{
		get { return  _other_Policy_Type; }
		set { _other_Policy_Type = value; }
	}

	public System.Decimal? FK_Policy_Feature_1
	{
		get { return  _fK_Policy_Feature_1; }
		set { _fK_Policy_Feature_1 = value; }
	}

	public System.Decimal? Deductible_1
	{
		get { return  _deductible_1; }
		set { _deductible_1 = value; }
	}

	public System.Decimal? Limit_1
	{
		get { return  _limit_1; }
		set { _limit_1 = value; }
	}

	public System.Decimal? FK_Policy_Feature_2
	{
		get { return  _fK_Policy_Feature_2; }
		set { _fK_Policy_Feature_2 = value; }
	}

	public System.Decimal? Deductible_2
	{
		get { return  _deductible_2; }
		set { _deductible_2 = value; }
	}

	public System.Decimal? Limit_2
	{
		get { return  _limit_2; }
		set { _limit_2 = value; }
	}

	public System.Decimal? FK_Policy_Feature_3
	{
		get { return  _fK_Policy_Feature_3; }
		set { _fK_Policy_Feature_3 = value; }
	}

	public System.Decimal? Deductible_3
	{
		get { return  _deductible_3; }
		set { _deductible_3 = value; }
	}

	public System.Decimal? Limit_3
	{
		get { return  _limit_3; }
		set { _limit_3 = value; }
	}

	public System.Decimal? FK_Policy_Feature_4
	{
		get { return  _fK_Policy_Feature_4; }
		set { _fK_Policy_Feature_4 = value; }
	}

	public System.Decimal? Deductible_4
	{
		get { return  _deductible_4; }
		set { _deductible_4 = value; }
	}

	public System.Decimal? Limit_4
	{
		get { return  _limit_4; }
		set { _limit_4 = value; }
	}

	public System.Decimal? FK_Policy_Feature_5
	{
		get { return  _fK_Policy_Feature_5; }
		set { _fK_Policy_Feature_5 = value; }
	}

	public System.Decimal? Deductible_5
	{
		get { return  _deductible_5; }
		set { _deductible_5 = value; }
	}

	public System.Decimal? Limit_5
	{
		get { return  _limit_5; }
		set { _limit_5 = value; }
	}

	public System.Decimal? FK_Policy_Feature_6
	{
		get { return  _fK_Policy_Feature_6; }
		set { _fK_Policy_Feature_6 = value; }
	}

	public System.Decimal? Deductible_6
	{
		get { return  _deductible_6; }
		set { _deductible_6 = value; }
	}

	public System.Decimal? Limit_6
	{
		get { return  _limit_6; }
		set { _limit_6 = value; }
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

    public System.String PolFeature1
    {
        get { return m_strPolicyFeature1; }
        set { m_strPolicyFeature1 = value; }
    }
    public System.String PolFeature2
    {
        get { return m_strPolicyFeature2; }
        set { m_strPolicyFeature2 = value; }
    }
    public System.String PolFeature3
    {
        get { return m_strPolicyFeature3; }
        set { m_strPolicyFeature3 = value; }
    }
    public System.String PolFeature4
    {
        get { return m_strPolicyFeature4; }
        set { m_strPolicyFeature4 = value; }
    }
    public System.String PolFeature5
    {
        get { return m_strPolicyFeature5; }
        set { m_strPolicyFeature5 = value; }
    }
    public System.String PolFeature6
    {
        get { return m_strPolicyFeature6; }
        set { m_strPolicyFeature6 = value; }
    }

    public System.Decimal PolicyFeature_Pk_Id
    {
        get { return _PolicyFeature_Pk_Id; }
        set { _PolicyFeature_Pk_Id = value; }
    }

    public System.String PolicyFeature
    {
        get { return _PolicyFeature; }
        set { _PolicyFeature = value; }
    }
	#endregion

	#region Abstract Methods
    public abstract List<CPolicyCoverage> GetAll();
    public abstract List<CPolicyCoverage> GetPolicy_CoverageByID(System.Decimal lPK_Policy_Coverage_Id);
    public abstract int InsertUpdatePolicy_Coverage(RIMS_Base.CPolicyCoverage obj);
	public abstract int DeletePolicy_Coverage(System.Decimal lPK_Policy_Coverage_Id);
    public abstract List<CPolicyCoverage> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria);
    public abstract List<CPolicyCoverage> GetPolicyFeatures();
	#endregion

}
}
