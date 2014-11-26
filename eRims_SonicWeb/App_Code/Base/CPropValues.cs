#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
using System.Data;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CPropValues
{

	#region Constructor
    public CPropValues()
	{
		this._pK_Property_Values = 0;
		//this._fK_Property_COPE = -1;
        //this._property_Valuation = DateTime.Now;
        //this._building = -1;
        //this._mobile_Equipment = -1;
        //this._contents = -1;
        //this._inventory = -1;
        //this._system_Equipment = -1;
        //this._transmission_Above_Ground = -1;
        //this._transmission_Below_Ground = -1;
        //this._transmission_Other = -1;
        //this._towers = -1;
        //this._other_Structures = -1;
        //this._other_Structures_Description = string.Empty;
        //this._total = -1;
		this._updated_By = -1;
		this._update_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
	private System.Decimal _pK_Property_Values;
	private System.Decimal _fK_Property_COPE;
	private System.DateTime? _property_Valuation;
	private System.Decimal? _building;
	private System.Decimal? _mobile_Equipment;
	private System.Decimal? _contents;
	private System.Decimal? _inventory;
	private System.Decimal? _system_Equipment;
	private System.Decimal? _transmission_Above_Ground;
	private System.Decimal? _transmission_Below_Ground;
	private System.Decimal? _transmission_Other;
	private System.Decimal? _towers;
	private System.Decimal? _other_Structures;
	private System.String _other_Structures_Description;
	private System.Decimal? _total;
	private System.Decimal _updated_By;
	private System.DateTime _update_Date;
	#endregion

	#region Public Properties
	public System.Decimal PK_Property_Values
	{
		get { return  _pK_Property_Values; }
		set { _pK_Property_Values = value; }
	}

	public System.Decimal FK_Property_COPE
	{
		get { return  _fK_Property_COPE; }
		set { _fK_Property_COPE = value; }
	}

	public System.DateTime? Property_Valuation
	{
		get { return  _property_Valuation; }
		set { _property_Valuation = value; }
	}

	public System.Decimal? Building
	{
		get { return  _building; }
		set { _building = value; }
	}

	public System.Decimal? Mobile_Equipment
	{
		get { return  _mobile_Equipment; }
		set { _mobile_Equipment = value; }
	}

	public System.Decimal? Contents
	{
		get { return  _contents; }
		set { _contents = value; }
	}

	public System.Decimal? Inventory
	{
		get { return  _inventory; }
		set { _inventory = value; }
	}

	public System.Decimal? System_Equipment
	{
		get { return  _system_Equipment; }
		set { _system_Equipment = value; }
	}

	public System.Decimal? Transmission_Above_Ground
	{
		get { return  _transmission_Above_Ground; }
		set { _transmission_Above_Ground = value; }
	}

	public System.Decimal? Transmission_Below_Ground
	{
		get { return  _transmission_Below_Ground; }
		set { _transmission_Below_Ground = value; }
	}

	public System.Decimal? Transmission_Other
	{
		get { return  _transmission_Other; }
		set { _transmission_Other = value; }
	}

	public System.Decimal? Towers
	{
		get { return  _towers; }
		set { _towers = value; }
	}

	public System.Decimal? Other_Structures
	{
		get { return  _other_Structures; }
		set { _other_Structures = value; }
	}

	public System.String Other_Structures_Description
	{
		get { return  _other_Structures_Description; }
		set { _other_Structures_Description = value; }
	}

	public System.Decimal? Total
	{
		get { return  _total; }
		set { _total = value; }
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
	public abstract DataSet PropValues_GetById(System.Decimal lPK_Property_Values);
	public abstract int PropValues_InsertUpdate(RIMS_Base.CPropValues obj);
	
	#endregion

}

}
