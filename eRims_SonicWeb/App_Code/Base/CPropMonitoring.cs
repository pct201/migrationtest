#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
using System.Data;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CPropMonitoring
{

	#region Constructor
    public CPropMonitoring()
	{
		this._pK_Property_Monitoring = 0;
		this._fK_Property_COPE = -1;
		this._system = string.Empty;
		this._vendor_Name = string.Empty;
		this._contact_Name = string.Empty;
		this._contract_Epiration_Date = DateTime.Now;
		this._address_1 = string.Empty;
		this._address_2 = string.Empty;
		this._city = string.Empty;
		this._fK_State = -1;
		this._zip_Code = string.Empty;
		this._telephone_Number = string.Empty;
		this._e_Mail = string.Empty;
		this._alternate_Telephone_Number = string.Empty;
		this._comments = string.Empty;
		this._updated_By = -1;
		this._update_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
	private System.Int32 _pK_Property_Monitoring;
	private System.Decimal _fK_Property_COPE;
	private System.String _system;
	private System.String _vendor_Name;
	private System.String _contact_Name;
	private System.DateTime? _contract_Epiration_Date;
	private System.String _address_1;
	private System.String _address_2;
	private System.String _city;
	private System.Decimal _fK_State;
	private System.String _zip_Code;
	private System.String _telephone_Number;
	private System.String _e_Mail;
	private System.String _alternate_Telephone_Number;
	private System.String _comments;
	private System.Decimal _updated_By;
	private System.DateTime _update_Date;
	#endregion

	#region Public Properties
	public System.Int32 PK_Property_Monitoring
	{
		get { return  _pK_Property_Monitoring; }
		set { _pK_Property_Monitoring = value; }
	}

	public System.Decimal FK_Property_COPE
	{
		get { return  _fK_Property_COPE; }
		set { _fK_Property_COPE = value; }
	}

	public System.String System
	{
		get { return  _system; }
		set { _system = value; }
	}

	public System.String Vendor_Name
	{
		get { return  _vendor_Name; }
		set { _vendor_Name = value; }
	}

	public System.String Contact_Name
	{
		get { return  _contact_Name; }
		set { _contact_Name = value; }
	}

	public System.DateTime? Contract_Epiration_Date
	{
		get { return  _contract_Epiration_Date; }
		set { _contract_Epiration_Date = value; }
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

	public System.Decimal FK_State
	{
		get { return  _fK_State; }
		set { _fK_State = value; }
	}

	public System.String Zip_Code
	{
		get { return  _zip_Code; }
		set { _zip_Code = value; }
	}

	public System.String Telephone_Number
	{
		get { return  _telephone_Number; }
		set { _telephone_Number = value; }
	}

	public System.String E_Mail
	{
		get { return  _e_Mail; }
		set { _e_Mail = value; }
	}

	public System.String Alternate_Telephone_Number
	{
		get { return  _alternate_Telephone_Number; }
		set { _alternate_Telephone_Number = value; }
	}

	public System.String Comments
	{
		get { return  _comments; }
		set { _comments = value; }
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
    public abstract DataSet PropMonitoring_GetByID(System.Decimal lPK_Property_Monitoring);
    public abstract int PropMonitoring_InsertUpdate(RIMS_Base.CPropMonitoring obj);
    public abstract int PropMonitoring_Delete(System.String lPK_Property_Monitoring);
	
	#endregion

}

}
