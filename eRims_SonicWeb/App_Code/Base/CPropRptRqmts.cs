#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
using System.Data;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CPropRptRqmts
{

	#region Constructor
    public CPropRptRqmts()
	{
		this._pK_Tanks_Other_Reporting_Rqmts = -1;
		this._fK_Environmental_Tanks = -1;
		this._type = string.Empty;
		this._due = DateTime.Now;
		this._filing = DateTime.Now;
		this._expiration = DateTime.Now;
		this._notes = string.Empty;
		this._updated_By = -1;
		this._update_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
	private System.Decimal _pK_Tanks_Other_Reporting_Rqmts;
	private System.Decimal _fK_Environmental_Tanks;
	private System.String _type;
	private System.DateTime? _due;
	private System.DateTime? _filing;
	private System.DateTime? _expiration;
	private System.String _notes;
	private System.Decimal _updated_By;
	private System.DateTime _update_Date;
	#endregion

	#region Public Properties
	public System.Decimal PK_Tanks_Other_Reporting_Rqmts
	{
		get { return  _pK_Tanks_Other_Reporting_Rqmts; }
		set { _pK_Tanks_Other_Reporting_Rqmts = value; }
	}

	public System.Decimal FK_Environmental_Tanks
	{
		get { return  _fK_Environmental_Tanks; }
		set { _fK_Environmental_Tanks = value; }
	}

	public System.String Type
	{
		get { return  _type; }
		set { _type = value; }
	}

	public System.DateTime? Due
	{
		get { return  _due; }
		set { _due = value; }
	}

	public System.DateTime? Filing
	{
		get { return  _filing; }
		set { _filing = value; }
	}

	public System.DateTime? Expiration
	{
		get { return  _expiration; }
		set { _expiration = value; }
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

	public System.DateTime Update_Date
	{
		get { return  _update_Date; }
		set { _update_Date = value; }
	}

	#endregion

	#region Abstract Methods
	public abstract DataSet GetAll( );
	public abstract DataSet PropRptRqmts_GetByID(System.Decimal lPK_Tanks_Other_Reporting_Rqmts);
    public abstract int PropRptRqmts_InsertUpdate(RIMS_Base.CPropRptRqmts obj);
    public abstract int PropRptRqmts_Delete(System.String lPK_Tanks_Other_Reporting_Rqmts);
	#endregion

}

}
