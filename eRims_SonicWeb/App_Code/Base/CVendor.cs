#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CVendor
{

	#region Constructor
    public CVendor()
	{
		this._pK_Vendor_ID = 0;
		this._vendor_Tax_Id = string.Empty;
		this._vendor_Name = string.Empty;
		this._address_1 = string.Empty;
		this._address_2 = string.Empty;
		this._city = string.Empty;
		this._state = string.Empty;
		this._zip_Code = string.Empty;
		this._phone = string.Empty;
		this._facsimile = string.Empty;
		this._vendor_Type = string.Empty;
		this._updated_By = string.Empty;
		this._update_Date = DateTime.Now;
        this._pK_ID = -1;
        this._fLD_Desc = string.Empty;
        this._fLD_DescO = string.Empty;
	}
	#endregion

	#region Private Variables 
	private System.Int32 _pK_Vendor_ID;
	private System.String _vendor_Tax_Id;
	private System.String _vendor_Name;
	private System.String _address_1;
	private System.String _address_2;
	private System.String _city;
	private System.String _state;
	private System.String _zip_Code;
	private System.String _phone;
	private System.String _facsimile;
	private System.String _vendor_Type;
	private System.String _updated_By;
	private System.DateTime _update_Date;
    private System.Decimal _pK_ID;
    private System.String _fLD_Desc;
    private System.String _fLD_DescO;
	#endregion

	#region Public Properties
	public System.Int32 PK_Vendor_ID
	{
		get { return  _pK_Vendor_ID; }
		set { _pK_Vendor_ID = value; }
	}

	public System.String Vendor_Tax_Id
	{
		get { return  _vendor_Tax_Id; }
		set { _vendor_Tax_Id = value; }
	}

	public System.String Vendor_Name
	{
		get { return  _vendor_Name; }
		set { _vendor_Name = value; }
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

	public System.String Vendor_Type
	{
		get { return  _vendor_Type; }
		set { _vendor_Type = value; }
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

    public System.Decimal PK_ID
    {
        get { return _pK_ID; }
        set { _pK_ID = value; }
    }

    public System.String FLD_Desc
    {
        get { return _fLD_Desc; }
        set { _fLD_Desc = value; }
    }
    public System.String FLD_DescO
    {
        get { return _fLD_DescO; }
        set { _fLD_DescO = value; }
    }

	#endregion

	#region Abstract Methods
    public abstract List<CVendor> GetAll();
    public abstract List<CVendor> GetAllVendorType();
    public abstract List<CVendor> GetorByID(System.Decimal lPK_Vendor_ID);
    public abstract int InsertUpdateVendor(RIMS_Base.CVendor obj);
	public abstract int DeleteVendor(System.String lPK_Vendor_ID);
	public abstract string ActivateInactivateVendor(string strIDs, int intModifiedBy, bool bIsActive);
    public abstract List<CVendor> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria);
	#endregion

}

}

