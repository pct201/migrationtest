#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CSecEq
{

	#region Constructor
    public CSecEq()
	{
        //this._pK_Security_Equipment_ID = -1;
        ////this._property_FK = -1;
        //this._type = string.Empty;
        this._general_Location = string.Empty;
        //this._specific_Location = string.Empty;
        ////this._floor = -1;
        //this._internal_Number = string.Empty;
        this._usage = string.Empty;
        //this._manufacturer = string.Empty;
        //this._model = string.Empty;
        //this._serial_Number = string.Empty;
        //this._resolution = string.Empty;
        this._color = string.Empty;
        //this._iPAddress = string.Empty;
        ////this._date_Purchased = DateTime.Now;
        ////this._warranty_Expiration = DateTime.Now;
        //this._installer = string.Empty;
        //this._monitor = string.Empty;
        this._backup_System_Access = string.Empty;
        //this._backup_Cell = string.Empty;
        ////this._backup_Cell_Cost = -1;
        //this._updated_By = string.Empty;
        //this._update_Date = DateTime.Now;
        //this._fk_backup = -1;
        //this._fk_color = -1;
        //this._fk_location = -1;
        //this._fk_usage = -1;
        //this._fk_eqtype = -1;

	}
	#endregion

	#region Private Variables 
	private System.Int32 _pK_Security_Equipment_ID;
	private System.Decimal _property_FK;
	private System.String _type;
	private System.String _general_Location;
	private System.String _specific_Location;
	private System.Decimal? _floor;
	private System.String _internal_Number;
	private System.String _usage;
	private System.String _manufacturer;
	private System.String _model;
	private System.String _serial_Number;
	private System.String _resolution;
	private System.String _color;
	private System.String _iPAddress;
	private System.DateTime? _date_Purchased;
	private System.DateTime? _warranty_Expiration;
	private System.String _installer;
	private System.String _monitor;
	private System.String _backup_System_Access;
	private System.String _backup_Cell;
	private System.Decimal? _backup_Cell_Cost;
	private System.String _updated_By;
	private System.DateTime _update_Date;
    private System.Decimal _fk_backup;
    private System.Decimal _fk_color;
    private System.Decimal _fk_usage;
    private System.Decimal _fk_location;
    private System.Decimal _fk_eqtype;
    private System.String _strfk_backup;
    private System.String _strfk_color;
    private System.String _strfk_usage;
    private System.String _strfk_location;
    private System.String _strfk_eqtype;
    private System.String _property;
	#endregion

	#region Public Properties
	public System.Int32 PK_Security_Equipment_ID
	{
		get { return  _pK_Security_Equipment_ID; }
		set { _pK_Security_Equipment_ID = value; }
	}

	public System.Decimal Property_FK
	{
		get { return  _property_FK; }
		set { _property_FK = value; }
	}

	public System.String Type
	{
		get { return  _type; }
		set { _type = value; }
	}
    public System.String Property
    {
        get { return _property; }
        set { _property = value; }
    }
	public System.String General_Location
	{
		get { return  _general_Location; }
		set { _general_Location = value; }
	}

	public System.String Specific_Location
	{
		get { return  _specific_Location; }
		set { _specific_Location = value; }
	}

	public System.Decimal? Floor
	{
		get { return  _floor; }
		set { _floor = value; }
	}

	public System.String Internal_Number
	{
		get { return  _internal_Number; }
		set { _internal_Number = value; }
	}

	public System.String Usage
	{
		get { return  _usage; }
		set { _usage = value; }
	}

	public System.String Manufacturer
	{
		get { return  _manufacturer; }
		set { _manufacturer = value; }
	}

	public System.String Model
	{
		get { return  _model; }
		set { _model = value; }
	}

	public System.String Serial_Number
	{
		get { return  _serial_Number; }
		set { _serial_Number = value; }
	}

	public System.String Resolution
	{
		get { return  _resolution; }
		set { _resolution = value; }
	}

	public System.String Color
	{
		get { return  _color; }
		set { _color = value; }
	}

	public System.String IPAddress
	{
		get { return  _iPAddress; }
		set { _iPAddress = value; }
	}

	public System.DateTime? Date_Purchased
	{
		get { return  _date_Purchased; }
		set { _date_Purchased = value; }
	}

	public System.DateTime? Warranty_Expiration
	{
		get { return  _warranty_Expiration; }
		set { _warranty_Expiration = value; }
	}

	public System.String Installer
	{
		get { return  _installer; }
		set { _installer = value; }
	}

	public System.String Monitor
	{
		get { return  _monitor; }
		set { _monitor = value; }
	}

	public System.String Backup_System_Access
	{
		get { return  _backup_System_Access; }
		set { _backup_System_Access = value; }
	}

	public System.String Backup_Cell
	{
		get { return  _backup_Cell; }
		set { _backup_Cell = value; }
	}

	public System.Decimal? Backup_Cell_Cost
	{
		get { return  _backup_Cell_Cost; }
		set { _backup_Cell_Cost = value; }
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
    public System.Decimal FK_Backup
    {
        get { return _fk_backup; }
        set { _fk_backup = value; }
    }
    public System.Decimal FK_Color
    {
        get { return _fk_color; }
        set { _fk_color = value; }
    }
    public System.Decimal FK_EqType
    {
        get { return _fk_eqtype; }
        set { _fk_eqtype = value; }
    }
    public System.Decimal FK_Usage
    {
        get { return _fk_usage; }
        set { _fk_usage = value; }
    }
    public System.Decimal FK_Location
    {
        get { return _fk_location; }
        set { _fk_location = value; }
    }

    public System.String SFK_Backup
    {
        get { return _strfk_backup; }
        set { _strfk_backup = value; }
    }
    public System.String SFK_Color
    {
        get { return _strfk_color; }
        set { _strfk_color = value; }
    }
    public System.String SFK_EqType
    {
        get { return _strfk_eqtype; }
        set { _strfk_eqtype = value; }
    }
    public System.String SFK_Usage
    {
        get { return _strfk_usage; }
        set { _strfk_usage = value; }
    }
    public System.String SFK_Location
    {
        get { return _strfk_location; }
        set { _strfk_location = value; }
    }
	#endregion

	#region Abstract Methods
    public abstract List<CSecEq> GetAll();
    public abstract List<CSecEq> GetSec_EquipmentByID(System.Decimal lPK_Security_Equipment_ID);
    public abstract int Sec_Equipment_InsertUpdate(RIMS_Base.CSecEq obj);
    public abstract int Sec_Equipment_Delete(System.String lPK_Security_Equipment_ID);
	public abstract string ActivateInactivaterity_Equipment(string strIDs, int intModifiedBy, bool bIsActive);
    public abstract List<CSecEq> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria);
    public abstract List<CSecEq> GetBSA();
    public abstract List<CSecEq> GetColor();
    public abstract List<CSecEq> GetUsage();
    public abstract List<CSecEq> GetEqType();
    public abstract List<CSecEq> GetLocation();
	#endregion

}

}

