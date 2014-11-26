#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
using System.Data;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CPropRec
{

	#region Constructor
    public CPropRec()
	{
        this._pK_Property_Recommendations = 0;
        //this._fK_Property_COPE = -1;
        //this._updated_By = -1;
        this._update_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
	private System.Decimal _pK_Property_Recommendations;
	private System.Decimal _fK_Property_COPE;
	private System.Decimal _updated_By;
	private System.DateTime _update_Date;
	#endregion

	#region Public Properties
	public System.Decimal PK_Property_Recommendations
	{
		get { return  _pK_Property_Recommendations; }
		set { _pK_Property_Recommendations = value; }
	}

	public System.Decimal FK_Property_COPE
	{
		get { return  _fK_Property_COPE; }
		set { _fK_Property_COPE = value; }
	}

	public System.Decimal Updated_By
	{
		get { return  _updated_By; }
		set { _updated_By = value; }
	}

	public System.DateTime Update_Date
	{
		get { return  _update_Date; }
		set { _update_Date = value; }
	}

	#endregion

	#region Abstract Methods
	public abstract DataSet GetAll();
	public abstract DataSet PropRecommend_ById(System.Decimal lpk_Prop_Cope);
	public abstract int PropRecommend_InsertUpdate(RIMS_Base.CPropRec obj);
	
	#endregion

}

}
