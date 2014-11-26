#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CProvider
{

	#region Constructor
    public CProvider()
	{
		this._pK_Provider_ID = -1;
		this._name = string.Empty;
		this._tax_Id = string.Empty;
		this._address_1 = string.Empty;
		this._address_2 = string.Empty;
		this._city = string.Empty;
		this._state = string.Empty;
		this._zip_Code = string.Empty;
		this._phone = string.Empty;
		this._facsimile = string.Empty;
		this._updated_By = string.Empty;
		this._update_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
	private System.Int32 _pK_Provider_ID;
	private System.String _name;
	private System.String _tax_Id;
	private System.String _address_1;
	private System.String _address_2;
	private System.String _city;
	private System.String _state;
	private System.String _zip_Code;
	private System.String _phone;
	private System.String _facsimile;
	private System.String _updated_By;
	private System.DateTime _update_Date;
	#endregion

	#region Public Properties
	public System.Int32 PK_Provider_ID
	{
		get { return  _pK_Provider_ID; }
		set { _pK_Provider_ID = value; }
	}

	public System.String Name
	{
		get { return  _name; }
		set { _name = value; }
	}

	public System.String Tax_Id
	{
		get { return  _tax_Id; }
		set { _tax_Id = value; }
	}

	public System.String Address_1
	{
		get { return  _address_1; }
		set { _address_1 = value; }
	}

	public System.String Address_2
	{
		get { return  _address_2; }
		set { _address_2 = value; }
	}

	public System.String City
	{
		get { return  _city; }
		set { _city = value; }
	}

	public System.String State
	{
		get { return  _state; }
		set { _state = value; }
	}

	public System.String Zip_Code
	{
		get { return  _zip_Code; }
		set { _zip_Code = value; }
	}

	public System.String Phone
	{
		get { return  _phone; }
		set { _phone = value; }
	}

	public System.String Facsimile
	{
		get { return  _facsimile; }
		set { _facsimile = value; }
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

	#endregion

	#region Abstract Methods
	public abstract List<CProvider> GetAll();
    public abstract List<CProvider> Provider_GetByID(System.Decimal lPK_Provider_ID);
	public abstract int Provider_InsertUpdate(RIMS_Base.CProvider obj);
    public abstract int Provider_Delete(System.String lPK_Provider_ID);
	public abstract string ActivateInactivateider(string strIDs, int intModifiedBy, bool bIsActive);
    public abstract List<RIMS_Base.CProvider> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria);
	#endregion

}

}
