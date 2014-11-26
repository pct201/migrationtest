#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
using System.Data;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CPropEnvironmental
{

	#region Constructor
    public CPropEnvironmental()
	{
		this._pK_Property_Environmental = 0;
		//this._fK_Property_COPE = -1;
		this._air = string.Empty;
		this._water = string.Empty;
		this._waste = string.Empty;
		this._fINDS = string.Empty;
		this._updated_By = 0;
		this._update_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
	private System.Decimal _pK_Property_Environmental;
	private System.Decimal _fK_Property_COPE;
	private System.String _air;
	private System.String _water;
	private System.String _waste;
	private System.String _fINDS;
	private System.Decimal _updated_By;
	private System.DateTime _update_Date;
	#endregion

	#region Public Properties
	public System.Decimal PK_Property_Environmental
	{
		get { return  _pK_Property_Environmental; }
		set { _pK_Property_Environmental = value; }
	}

	public System.Decimal FK_Property_COPE
	{
		get { return  _fK_Property_COPE; }
		set { _fK_Property_COPE = value; }
	}

	public System.String Air
	{
		get { return  _air; }
		set { _air = value; }
	}

	public System.String Water
	{
		get { return  _water; }
		set { _water = value; }
	}

	public System.String Waste
	{
		get { return  _waste; }
		set { _waste = value; }
	}

	public System.String FINDS
	{
		get { return  _fINDS; }
		set { _fINDS = value; }
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
	public abstract DataSet  PropEnvironmental_GetByID(System.Decimal lPK_Property_Environmental);
    public abstract int PropEnvironmental_InsertUpdate(RIMS_Base.CPropEnvironmental obj);
	
	#endregion

}

}
