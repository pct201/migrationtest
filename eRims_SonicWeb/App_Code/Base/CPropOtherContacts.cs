#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
using System.Data;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CPropOtherContacts
{

	#region Constructor
    public CPropOtherContacts()
	{
		this._pK_Other_Contacts = -1;
		this._fK_Property_Contacts = -1;
		this._type = string.Empty;
		this._company_Name = string.Empty;
		this._contact_Name = string.Empty;
		this._telephone_Number = string.Empty;
		this._e_Mail = string.Empty;
		this._alternate_Telephone = string.Empty;
		this._description = string.Empty;
		this._updated_By = -1;
		this._update_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
	private System.Decimal _pK_Other_Contacts;
	private System.Decimal _fK_Property_Contacts;
	private System.String _type;
	private System.String _company_Name;
	private System.String _contact_Name;
	private System.String _telephone_Number;
	private System.String _e_Mail;
	private System.String _alternate_Telephone;
	private System.String _description;
	private System.Decimal _updated_By;
	private System.DateTime _update_Date;
	#endregion

	#region Public Properties
	public System.Decimal PK_Other_Contacts
	{
		get { return  _pK_Other_Contacts; }
		set { _pK_Other_Contacts = value; }
	}

	public System.Decimal FK_Property_Contacts
	{
		get { return  _fK_Property_Contacts; }
		set { _fK_Property_Contacts = value; }
	}

	public System.String Type
	{
		get { return  _type; }
		set { _type = value; }
	}

	public System.String Company_Name
	{
		get { return  _company_Name; }
		set { _company_Name = value; }
	}

	public System.String Contact_Name
	{
		get { return  _contact_Name; }
		set { _contact_Name = value; }
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

	public System.String Alternate_Telephone
	{
		get { return  _alternate_Telephone; }
		set { _alternate_Telephone = value; }
	}

	public System.String Description
	{
		get { return  _description; }
		set { _description = value; }
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
	public abstract DataSet  GetAll( );
    public abstract DataSet PropOtherContacts_GetByID(System.Decimal lPK_Other_Contacts);
    public abstract int PropOtherContacts_InsertUpdate(RIMS_Base.CPropOtherContacts obj);
    public abstract int PropOtherContacts_Delete(System.String lPK_Other_Contacts);
    public abstract DataSet OtherContacts_ByContactID(System.Decimal PK_Contacts);
	#endregion

}

}
