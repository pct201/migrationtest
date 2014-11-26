#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CClaimant
{

	#region Constructor
    public CClaimant()
	{
		this._pK_Claimant_Id = -1;
		this._claimant_Id = string.Empty;
		this._last_Name = string.Empty;
		this._first_Name = string.Empty;
		this._middle_Name = string.Empty;
		this._claimant_Address_1 = string.Empty;
		this._claimant_Address_2 = string.Empty;
		this._claimant_City = string.Empty;
		this._claimant_State = string.Empty;
		this._claimant_Zip_Code = string.Empty;
		this._claimant_Home_Phone = string.Empty;
		this._claimant_Cell_Phone = string.Empty;
		this._social_Security_Number = string.Empty;
		//this._fK_Cost_Center = -1;
		this._updated_By = string.Empty;
		this._update_Date = DateTime.Now;
		//this._date_Of_Birth = DateTime.Now;
		this._drivers_License_State = string.Empty;
		this._drivers_License_Number = string.Empty;
	}
	#endregion

	#region Private Variables 
	private System.Int32 _pK_Claimant_Id;
	private System.String _claimant_Id;
	private System.String _last_Name;
	private System.String _first_Name;
	private System.String _middle_Name;
	private System.String _claimant_Address_1;
	private System.String _claimant_Address_2;
	private System.String _claimant_City;
	private System.String _claimant_State;
	private System.String _claimant_Zip_Code;
	private System.String _claimant_Home_Phone;
	private System.String _claimant_Cell_Phone;
	private System.String _social_Security_Number;
	private System.Decimal _fK_Cost_Center;
	private System.String _updated_By;
	private System.DateTime _update_Date;
	private System.DateTime? _date_Of_Birth;
	private System.String _drivers_License_State;
	private System.String _drivers_License_Number;
	#endregion

	#region Public Properties
	public System.Int32 PK_Claimant_Id
	{
		get { return  _pK_Claimant_Id; }
		set { _pK_Claimant_Id = value; }
	}

	public System.String Claimant_Id
	{
		get { return  _claimant_Id; }
		set { _claimant_Id = value; }
	}

	public System.String Last_Name
	{
		get { return  _last_Name; }
		set { _last_Name = value; }
	}

	public System.String First_Name
	{
		get { return  _first_Name; }
		set { _first_Name = value; }
	}

	public System.String Middle_Name
	{
		get { return  _middle_Name; }
		set { _middle_Name = value; }
	}

	public System.String Claimant_Address_1
	{
		get { return  _claimant_Address_1; }
		set { _claimant_Address_1 = value; }
	}

	public System.String Claimant_Address_2
	{
		get { return  _claimant_Address_2; }
		set { _claimant_Address_2 = value; }
	}

	public System.String Claimant_City
	{
		get { return  _claimant_City; }
		set { _claimant_City = value; }
	}

	public System.String Claimant_State
	{
		get { return  _claimant_State; }
		set { _claimant_State = value; }
	}

	public System.String Claimant_Zip_Code
	{
		get { return  _claimant_Zip_Code; }
		set { _claimant_Zip_Code = value; }
	}

	public System.String Claimant_Home_Phone
	{
		get { return  _claimant_Home_Phone; }
		set { _claimant_Home_Phone = value; }
	}

	public System.String Claimant_Cell_Phone
	{
		get { return  _claimant_Cell_Phone; }
		set { _claimant_Cell_Phone = value; }
	}

	public System.String Social_Security_Number
	{
		get { return  _social_Security_Number; }
		set { _social_Security_Number = value; }
	}

	public System.Decimal FK_Cost_Center
	{
		get { return  _fK_Cost_Center; }
		set { _fK_Cost_Center = value; }
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

	public System.DateTime? Date_Of_Birth
	{
		get { return  _date_Of_Birth; }
		set { _date_Of_Birth = value; }
	}

	public System.String Drivers_License_State
	{
		get { return  _drivers_License_State; }
		set { _drivers_License_State = value; }
	}

	public System.String Drivers_License_Number
	{
		get { return  _drivers_License_Number; }
		set { _drivers_License_Number = value; }
	}

	#endregion

	#region Abstract Methods
    public abstract List<CClaimant> GetAll();
    public abstract List<CClaimant> GetClaimantByID(System.Decimal lPK_Claimant_Id);
    public abstract int InsertUpdateClaimant(RIMS_Base.CClaimant obj);
	public abstract int DeleteClaimant(System.String lPK_Claimant_Id);
	public abstract string ActivateInactivateClaimant(string strIDs, int intModifiedBy, bool bIsActive);
    public abstract List<CClaimant> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria);
    public abstract List<CClaimant> Get_AdvanceSearch_Data(System.String LastName, System.String FirstName, System.String Address, System.String City, System.String State, System.String Zipcode);
    public abstract List<CClaimant> GetClaimantAutopopulate();
	#endregion

}

}
