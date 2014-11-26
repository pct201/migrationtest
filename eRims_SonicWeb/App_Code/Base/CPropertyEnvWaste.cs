#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
using System.Data;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CPropertyEnvWaste
{

	#region Constructor
    public CPropertyEnvWaste()
	{
		this._pK_Environmental_Waste = -1;
		this._fK_Property_Environmental = -1;
		this._type = string.Empty;
		this._permit_Required = string.Empty;
		this._regulation_Number = string.Empty;
		this._certificate_Number = string.Empty;
		this._filing = DateTime.Now;
		this._permit_Begin = DateTime.Now;
		this._permit_End = DateTime.Now;
		this._last_Inspection = DateTime.Now;
		this._next_Inspection = DateTime.Now;
		this._next_Report = DateTime.Now;
		this._notes = string.Empty;
		this._updated_By = -1;
		this._update_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
	private System.Decimal _pK_Environmental_Waste;
	private System.Decimal _fK_Property_Environmental;
	private System.String _type;
	private System.String _permit_Required;
	private System.String _regulation_Number;
	private System.String _certificate_Number;
	private System.DateTime? _filing;
	private System.DateTime? _permit_Begin;
	private System.DateTime? _permit_End;
	private System.DateTime? _last_Inspection;
	private System.DateTime? _next_Inspection;
	private System.DateTime _next_Report;
	private System.String _notes;
	private System.Decimal _updated_By;
	private System.DateTime _update_Date;
	#endregion

	#region Public Properties
	public System.Decimal PK_Environmental_Waste
	{
		get { return  _pK_Environmental_Waste; }
		set { _pK_Environmental_Waste = value; }
	}

	public System.Decimal FK_Property_Environmental
	{
		get { return  _fK_Property_Environmental; }
		set { _fK_Property_Environmental = value; }
	}

	public System.String Type
	{
		get { return  _type; }
		set { _type = value; }
	}

	public System.String Permit_Required
	{
		get { return  _permit_Required; }
		set { _permit_Required = value; }
	}

	public System.String Regulation_Number
	{
		get { return  _regulation_Number; }
		set { _regulation_Number = value; }
	}

	public System.String Certificate_Number
	{
		get { return  _certificate_Number; }
		set { _certificate_Number = value; }
	}

	public System.DateTime? Filing
	{
		get { return  _filing; }
		set { _filing = value; }
	}

	public System.DateTime? Permit_Begin
	{
		get { return  _permit_Begin; }
		set { _permit_Begin = value; }
	}

	public System.DateTime? Permit_End
	{
		get { return  _permit_End; }
		set { _permit_End = value; }
	}

	public System.DateTime? Last_Inspection
	{
		get { return  _last_Inspection; }
		set { _last_Inspection = value; }
	}

	public System.DateTime? Next_Inspection
	{
		get { return  _next_Inspection; }
		set { _next_Inspection = value; }
	}

	public System.DateTime Next_Report
	{
		get { return  _next_Report; }
		set { _next_Report = value; }
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
    public abstract DataSet GetAll();
    public abstract DataSet GetPropEnvWasteByID(System.Decimal lPK_Environmental_Waste);
    public abstract int PropEnvWaste_InsertUpdate(RIMS_Base.CPropertyEnvWaste obj);
    public abstract int PropEnvWaste_Delete(System.String lPK_Environmental_Waste);
	
	#endregion

}

}
