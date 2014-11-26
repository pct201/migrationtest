#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class cEmployee
{

	#region Constructor
    public cEmployee()
	{
		this._pK_Employee_ID = -1;
		this._employee_Id = string.Empty;
		this._last_Name = string.Empty;
		this._first_Name = string.Empty;
		this._middle_Name = string.Empty;
		this._employee_Address_1 = string.Empty;
		this._employee_Address_2 = string.Empty;
		this._employee_City = string.Empty;
		//this._employee_State = -1;
		this._employee_Zip_Code = string.Empty;
		this._employee_Home_Phone = string.Empty;
		this._employee_Cell_Phone = string.Empty;
		this._social_Security_Number = string.Empty;
		//this._fK_Marital_Status = -1;
		this._sex = string.Empty;
		//this._number_Of_Dependents = -1;
		//this._date_Of_Birth = DateTime.Now;
		//this._date_Of_Death = DateTime.Now;
		this._drivers_License_State = string.Empty;
		this._drivers_License_Number = string.Empty;
		this._drivers_License_Type = string.Empty;
		this._drivers_License_Class = string.Empty;
		this._drivers_License_Restrictions = string.Empty;
		this._drivers_License_Endorsements = string.Empty;
		//this._drivers_License_Issued = DateTime.Now;
		//this._drivers_License_Expires = DateTime.Now;
		//this._fK_Bank_Number = -1;
		this._job_Title = string.Empty;
		this._occupation_Description = string.Empty;
		//this._salary = -1;
		//this._supervisor = -1;
		//this._hire_Date = DateTime.Now;
		this._work_Phone = string.Empty;
		this._inactive = string.Empty;
		this._updated_By = string.Empty;
		this._update_Date = DateTime.Now;
		//this._fK_Job_Classification = -1;
		//this._fK_Cost_Center = -1;
		this._email = string.Empty;
        this._marital_status = string.Empty;
        this._jobclass = string.Empty;
        this._license_type = string.Empty;
        this._fldstate = string.Empty;

      //  this._pK_licenseType_ID = -1;
	}
	#endregion

	#region Private Variables 
	private System.Decimal _pK_Employee_ID;
	private System.String _employee_Id;
	private System.String _last_Name;
	private System.String _first_Name;
	private System.String _middle_Name;
	private System.String _employee_Address_1;
	private System.String _employee_Address_2;
	private System.String _employee_City;
	private System.Decimal _employee_State;
	private System.String _employee_Zip_Code;
	private System.String _employee_Home_Phone;
	private System.String _employee_Cell_Phone;
	private System.String _social_Security_Number;
	private System.Decimal? _fK_Marital_Status;
	private System.String _sex;
	private System.Decimal? _number_Of_Dependents;
	private System.DateTime? _date_Of_Birth;
	private System.DateTime? _date_Of_Death;
	private System.String _drivers_License_State;
	private System.String _drivers_License_Number;
	private System.String _drivers_License_Type;
	private System.String _drivers_License_Class;
	private System.String _drivers_License_Restrictions;
	private System.String _drivers_License_Endorsements;
	private System.DateTime? _drivers_License_Issued;
	private System.DateTime? _drivers_License_Expires;
	private System.Decimal? _fK_Bank_Number;
	private System.String _job_Title;
	private System.String _occupation_Description;
	private System.Decimal? _salary;
	private System.Decimal? _supervisor;
	private System.DateTime? _hire_Date;
	private System.String _work_Phone;
	private System.String _inactive;
	private System.String _updated_By;
	private System.DateTime _update_Date;
	private System.Decimal? _fK_Job_Classification;
	private System.Decimal? _fK_Cost_Center;
	private System.String _email;
    private System.String _marital_status;
    private System.String _license_type;
    private System.String _jobclass;
    private System.String _cost_center;
    private System.String _ccaddress;
    private System.String _supfirstname;
    private System.String _suplastname;
    private System.String _supmiddlename;
    private System.String _fldstate;
    private System.String _StateName;

    private System.Decimal? _pK_licenseType_ID;
	#endregion

	#region Public Properties

   

	public System.Decimal PK_Employee_ID
	{
		get { return  _pK_Employee_ID; }
		set { _pK_Employee_ID = value; }
	}

    public System.String StateName
    {
        get { return _StateName; }
        set { _StateName = value; }
    }

	public System.String Employee_Id
	{
		get { return  _employee_Id; }
		set { _employee_Id = value; }
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

	public System.String Employee_Address_1
	{
		get { return  _employee_Address_1; }
		set { _employee_Address_1 = value; }
	}

	public System.String Employee_Address_2
	{
		get { return  _employee_Address_2; }
		set { _employee_Address_2 = value; }
	}

	public System.String Employee_City
	{
		get { return  _employee_City; }
		set { _employee_City = value; }
	}

	public System.Decimal Employee_State
	{
		get { return  _employee_State; }
		set { _employee_State = value; }
	}

	public System.String Employee_Zip_Code
	{
		get { return  _employee_Zip_Code; }
		set { _employee_Zip_Code = value; }
	}

	public System.String Employee_Home_Phone
	{
		get { return  _employee_Home_Phone; }
		set { _employee_Home_Phone = value; }
	}

	public System.String Employee_Cell_Phone
	{
		get { return  _employee_Cell_Phone; }
		set { _employee_Cell_Phone = value; }
	}

	public System.String Social_Security_Number
	{
		get { return  _social_Security_Number; }
		set { _social_Security_Number = value; }
	}

	public System.Decimal? FK_Marital_Status
	{
		get { return  _fK_Marital_Status; }
		set { _fK_Marital_Status = value; }
	}

	public System.String Sex
	{
		get { return  _sex; }
		set { _sex = value; }
	}

	public System.Decimal? Number_Of_Dependents
	{
		get { return  _number_Of_Dependents; }
		set { _number_Of_Dependents = value; }
	}

	public System.DateTime? Date_Of_Birth
	{
		get { return  _date_Of_Birth; }
		set { _date_Of_Birth = value; }
	}

	public System.DateTime? Date_Of_Death
	{
		get { return  _date_Of_Death; }
		set { _date_Of_Death = value; }
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

     public System.Decimal ? PK_ID
    {
        get { return _pK_licenseType_ID; }
        set { _pK_licenseType_ID = value; }
    }



	public System.String Drivers_License_Type
	{
		get { return  _drivers_License_Type; }
		set { _drivers_License_Type = value; }
	}

	public System.String Drivers_License_Class
	{
		get { return  _drivers_License_Class; }
		set { _drivers_License_Class = value; }
	}

	public System.String Drivers_License_Restrictions
	{
		get { return  _drivers_License_Restrictions; }
		set { _drivers_License_Restrictions = value; }
	}

	public System.String Drivers_License_Endorsements
	{
		get { return  _drivers_License_Endorsements; }
		set { _drivers_License_Endorsements = value; }
	}

	public System.DateTime? Drivers_License_Issued
	{
		get { return  _drivers_License_Issued; }
		set { _drivers_License_Issued = value; }
	}

	public System.DateTime? Drivers_License_Expires
	{
		get { return  _drivers_License_Expires; }
		set { _drivers_License_Expires = value; }
	}

	public System.Decimal? FK_Bank_Number
	{
		get { return  _fK_Bank_Number; }
		set { _fK_Bank_Number = value; }
	}

	public System.String Job_Title
	{
		get { return  _job_Title; }
		set { _job_Title = value; }
	}

	public System.String Occupation_Description
	{
		get { return  _occupation_Description; }
		set { _occupation_Description = value; }
	}

	public System.Decimal? Salary
	{
		get { return  _salary; }
		set { _salary = value; }
	}

	public System.Decimal? Supervisor
	{
		get { return  _supervisor; }
		set { _supervisor = value; }
	}

	public System.DateTime? Hire_Date
	{
		get { return  _hire_Date; }
		set { _hire_Date = value; }
	}

	public System.String Work_Phone
	{
		get { return  _work_Phone; }
		set { _work_Phone = value; }
	}

	public System.String Inactive
	{
		get { return  _inactive; }
		set { _inactive = value; }
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

	public System.Decimal? FK_Job_Classification
	{
		get { return  _fK_Job_Classification; }
		set { _fK_Job_Classification = value; }
	}

	public System.Decimal? FK_Cost_Center
	{
		get { return  _fK_Cost_Center; }
		set { _fK_Cost_Center = value; }
	}

	public System.String Email
	{
		get { return  _email; }
		set { _email = value; }
	}
    public System.String MaritalStatus
    {
        get { return _marital_status; }
        set { _marital_status = value; }
    }
    public System.String JobClassfication
    {
        get { return _jobclass; }
        set { _jobclass = value; }
    }
    public System.String LicenseType
    {
        get { return _license_type; }
        set { _license_type = value; }
    }
    public System.String Cost_Center
    {
        get { return _cost_center; }
        set { _cost_center = value; }
    }
    public System.String CCAddress
    {
        get { return _ccaddress; }
        set { _ccaddress = value; }
    }
    public System.String SupFirstName
    {
        get { return _supfirstname; }
        set { _supfirstname = value; }
    }
    public System.String SupLastName
    {
        get { return _suplastname; }
        set { _suplastname = value; }
    }
    public System.String SupMiddleName
    {
        get { return _supmiddlename; }
        set { _supmiddlename = value; }
    }
    public System.String FldState
    {
        get { return _fldstate; }
        set { _fldstate = value; }
    }
	#endregion

	#region Abstract Methods
    public abstract List<cEmployee> GetAll();
    public abstract List<cEmployee> GetAll_State();
    public abstract List<cEmployee> GetEmployeeByID(System.Decimal lPK_Claimant_Id);    
    public abstract List<cEmployee> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria);
    public abstract List<cEmployee> Get_Search_Data_State(System.String m_strColumn, System.String m_strCriteria);
    public abstract List<cEmployee> Get_AdvanceSearch_Data(System.String LastName , System.String FirstName, System.String Address,System.String City,System.String State,System.String Zipcode,Decimal Entity);
    public abstract int Employee_InsertUpdate(RIMS_Base.cEmployee obj);
	public abstract int Employee_Delete(System.String lPK_Employee_ID);
	public abstract string ActivateInactivateoyee(string strIDs, int intModifiedBy, bool bIsActive);
    public abstract List<cEmployee> GetMaritalStatus();
    public abstract List<cEmployee> GetLicenseType();
    public abstract List<cEmployee> GetJobClassfication();
    public abstract List<cEmployee> GetAutoPopulateEmployeeId();
	#endregion

}

}
