#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
using System.Data;

#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CPolicy_Features
{

	#region Constructor
    public CPolicy_Features()
	{
		this._pK_Policy_Features = 0;
		//this._fK_Policy = -1;
		this._feature = string.Empty;
        //this._limit = -1;
        //this._deductible = -1;
		this._notes = string.Empty;
		this._updated_By = -1;
		this._updated_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
	private System.Int32 _pK_Policy_Features;
	private System.Decimal _fK_Policy;
	private System.String _feature;
	private System.Decimal? _limit;
	private System.Decimal? _deductible;
	private System.String _notes;
	private System.Decimal _updated_By;
	private System.DateTime _updated_Date;
	#endregion

	#region Public Properties
	public System.Int32 PK_Policy_Features
	{
		get { return  _pK_Policy_Features; }
		set { _pK_Policy_Features = value; }
	}

	public System.Decimal FK_Policy
	{
		get { return  _fK_Policy; }
		set { _fK_Policy = value; }
	}

	public System.String Feature
	{
		get { return  _feature; }
		set { _feature = value; }
	}

	public System.Decimal? Limit
	{
		get { return  _limit; }
		set { _limit = value; }
	}

	public System.Decimal? Deductible
	{
		get { return  _deductible; }
		set { _deductible = value; }
	}

	public System.String Notes
	{
		get { return  _notes; }
		set { _notes = value; }
	}

	public System.Decimal Updated_By
	{
		get { return  _updated_By; }
		set { _updated_By = value; }
	}

	public System.DateTime Updated_Date
	{
		get { return  _updated_Date; }
		set { _updated_Date = value; }
	}

	#endregion

	#region Abstract Methods
	public abstract DataSet GetAll();
    public abstract DataSet PolicyFeatures_GetByID(System.Decimal lPK_Policy_Features,System.Decimal m_dPolicyID);
    public abstract int PolicyFeatures_InsertUpdate(RIMS_Base.CPolicy_Features obj);
    public abstract int PolicyFeatures_Delete(System.Decimal lPK_Policy_Features);
    public abstract DataSet PolicyFeatures_ByPolicyID(System.Decimal m_dPolicyID);
    
	#endregion

}

}
