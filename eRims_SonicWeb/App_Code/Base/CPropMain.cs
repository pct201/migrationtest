#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CPropMain
{

	#region Constructor
    public CPropMain()
	{
		this._pK_Property_Maintenance_ID = -1;
		this._property_FK = -1;
		this._requestor = string.Empty;
		this._type = string.Empty;
		this._subject = string.Empty;
		this._equipment_FK = -1;
		this._performed_By = string.Empty;
		this._description = string.Empty;
		this._severity = string.Empty;
		this._expected_Date = DateTime.Now;
		this._expected_Time = string.Empty;
		this._date = DateTime.Now;
		this._status = string.Empty;
		this._regions_Work_Order = string.Empty;
		this._vendor_Work_Order = string.Empty;
		this._vendor = string.Empty;
		this._vendor_Contact = string.Empty;
		this._vendor_Address_1 = string.Empty;
		this._vendor_Address_2 = string.Empty;
		this._vendor_City = string.Empty;
		this._vendor_State = string.Empty;
		this._vendor_Zip_Code = string.Empty;
		this._vendor_Phone = string.Empty;
		this._vendor_Facsmilie = string.Empty;
		this._vendor_E_Mail = string.Empty;
		this._credit_Card = string.Empty;
		this._amount_Approved = -1;
		this._date_Approved = DateTime.Now;
		this._approved_By = string.Empty;
		this._updated_By = string.Empty;
		this._update_Date = DateTime.Now;
		this._date_Of_Request = DateTime.Now;
		this._time_Of_Request = string.Empty;
		this._branch_FK = -1;
		this._aSO = string.Empty;
        
	}
	#endregion

	#region Private Variables 
	private System.Int32 _pK_Property_Maintenance_ID;
	private System.Decimal _property_FK;
	private System.String _requestor;
	private System.String _type;
	private System.String _subject;
	private System.Decimal _equipment_FK;
	private System.String _performed_By;
	private System.String _description;
	private System.String _severity;
	private System.DateTime _expected_Date;
	private System.String _expected_Time;
	private System.DateTime _date;
	private System.String _status;
	private System.String _regions_Work_Order;
	private System.String _vendor_Work_Order;
	private System.String _vendor;
	private System.String _vendor_Contact;
	private System.String _vendor_Address_1;
	private System.String _vendor_Address_2;
	private System.String _vendor_City;
	private System.String _vendor_State;
	private System.String _vendor_Zip_Code;
	private System.String _vendor_Phone;
	private System.String _vendor_Facsmilie;
	private System.String _vendor_E_Mail;
	private System.String _credit_Card;
	private System.Decimal _amount_Approved;
	private System.DateTime _date_Approved;
	private System.String _approved_By;
	private System.String _updated_By;
	private System.DateTime _update_Date;
	private System.DateTime _date_Of_Request;
	private System.String _time_Of_Request;
	private System.Decimal _branch_FK;
	private System.String _aSO;
    private System.Decimal _fk_mtype;
    private System.Decimal _fk_po;
    private System.Decimal _fk_severity;
    private System.String _strfk_mtype;
    private System.String _strfk_po;
    private System.String _strfk_severity;
    private System.String _property;
	#endregion

	#region Public Properties
	public System.Int32 PK_Property_Maintenance_ID
	{
		get { return  _pK_Property_Maintenance_ID; }
		set { _pK_Property_Maintenance_ID = value; }
	}

	public System.Decimal Property_FK
	{
		get { return  _property_FK; }
		set { _property_FK = value; }
	}

	public System.String Requestor
	{
		get { return  _requestor; }
		set { _requestor = value; }
	}

	public System.String Type
	{
		get { return  _type; }
		set { _type = value; }
	}

	public System.String Subject
	{
		get { return  _subject; }
		set { _subject = value; }
	}

	public System.Decimal Equipment_FK
	{
		get { return  _equipment_FK; }
		set { _equipment_FK = value; }
	}

	public System.String Performed_By
	{
		get { return  _performed_By; }
		set { _performed_By = value; }
	}

	public System.String Description
	{
		get { return  _description; }
		set { _description = value; }
	}

	public System.String Severity
	{
		get { return  _severity; }
		set { _severity = value; }
	}

	public System.DateTime Expected_Date
	{
		get { return  _expected_Date; }
		set { _expected_Date = value; }
	}

	public System.String Expected_Time
	{
		get { return  _expected_Time; }
		set { _expected_Time = value; }
	}

	public System.DateTime Date
	{
		get { return  _date; }
		set { _date = value; }
	}

	public System.String Status
	{
		get { return  _status; }
		set { _status = value; }
	}

	public System.String Regions_Work_Order
	{
		get { return  _regions_Work_Order; }
		set { _regions_Work_Order = value; }
	}

	public System.String Vendor_Work_Order
	{
		get { return  _vendor_Work_Order; }
		set { _vendor_Work_Order = value; }
	}

	public System.String Vendor
	{
		get { return  _vendor; }
		set { _vendor = value; }
	}

	public System.String Vendor_Contact
	{
		get { return  _vendor_Contact; }
		set { _vendor_Contact = value; }
	}

	public System.String Vendor_Address_1
	{
		get { return  _vendor_Address_1; }
		set { _vendor_Address_1 = value; }
	}

	public System.String Vendor_Address_2
	{
		get { return  _vendor_Address_2; }
		set { _vendor_Address_2 = value; }
	}

	public System.String Vendor_City
	{
		get { return  _vendor_City; }
		set { _vendor_City = value; }
	}

	public System.String Vendor_State
	{
		get { return  _vendor_State; }
		set { _vendor_State = value; }
	}

	public System.String Vendor_Zip_Code
	{
		get { return  _vendor_Zip_Code; }
		set { _vendor_Zip_Code = value; }
	}

	public System.String Vendor_Phone
	{
		get { return  _vendor_Phone; }
		set { _vendor_Phone = value; }
	}

	public System.String Vendor_Facsmilie
	{
		get { return  _vendor_Facsmilie; }
		set { _vendor_Facsmilie = value; }
	}

	public System.String Vendor_E_Mail
	{
		get { return  _vendor_E_Mail; }
		set { _vendor_E_Mail = value; }
	}

	public System.String Credit_Card
	{
		get { return  _credit_Card; }
		set { _credit_Card = value; }
	}

	public System.Decimal Amount_Approved
	{
		get { return  _amount_Approved; }
		set { _amount_Approved = value; }
	}

	public System.DateTime Date_Approved
	{
		get { return  _date_Approved; }
		set { _date_Approved = value; }
	}

	public System.String Approved_By
	{
		get { return  _approved_By; }
		set { _approved_By = value; }
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

	public System.DateTime Date_Of_Request
	{
		get { return  _date_Of_Request; }
		set { _date_Of_Request = value; }
	}

	public System.String Time_Of_Request
	{
		get { return  _time_Of_Request; }
		set { _time_Of_Request = value; }
	}

	public System.Decimal Branch_FK
	{
		get { return  _branch_FK; }
		set { _branch_FK = value; }
	}

	public System.String ASO
	{
		get { return  _aSO; }
		set { _aSO = value; }
	}

    public System.Decimal FK_Mtype
    {
        get { return _fk_mtype; }
        set { _fk_mtype = value; }
    }
    public System.Decimal FK_PO
    {
        get { return _fk_po; }
        set { _fk_po = value; }
    }
    public System.Decimal FK_Severity
    {
        get { return _fk_severity; }
        set { _fk_severity = value; }
    }
    public System.String Str_Mtype
    {
        get { return _strfk_mtype; }
        set { _strfk_mtype = value; }
    }
    public System.String Str_PO
    {
        get { return _strfk_po; }
        set { _strfk_po = value; }
    }
    public System.String Str_Severity
    {
        get { return _strfk_severity; }
        set { _strfk_severity = value; }
    }
    public System.String Property
    {
        get { return _property; }
        set { _property = value; }
    }
	#endregion

	#region Abstract Methods
    public abstract List<CPropMain> GetAll();
    public abstract List<CPropMain> PropMain_GetByID(System.Decimal lPK_Property_Maintenance_ID);
    public abstract int PropMain_InsertUpdate(RIMS_Base.CPropMain obj);
	public abstract int PropMain_Delete(System.String lPK_Property_Maintenance_ID);
	public abstract string ActivateInactivateerty_Maintenance(string strIDs, int intModifiedBy, bool bIsActive);
    public abstract List<RIMS_Base.CPropMain> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria);
    public abstract List<CPropMain> GetPO();
    public abstract List<CPropMain> GetMType();
    public abstract List<CPropMain> GetSeverity();
	#endregion

}

}

