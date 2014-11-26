#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CEmployeeTraining
{

	#region Constructor
    public CEmployeeTraining()
	{
		this._pK_Employee_Training_Id = -1;
		this._employee_FK = -1;
		this._training_Description = string.Empty;
		this._training_Date = DateTime.Now;
		this._training_Status = 0;
		this._retrain_Date = DateTime.Now;
		this._training_Type = 0;
		this._training_Grade = 0;
		this._updated_By = string.Empty;
		this._update_Date = DateTime.Now;
        this._training_gradetext = string.Empty;
        this._training_statustext = string.Empty;
        this._training_typetext = string.Empty;
	}
	#endregion

	#region Private Variables 
	private System.Int32 _pK_Employee_Training_Id;
	private System.Decimal _employee_FK;
	private System.String _training_Description;
	private System.DateTime _training_Date;
	private System.Int32 _training_Status;
	private System.DateTime _retrain_Date;
    private System.Int32 _training_Type;
    private System.Int32 _training_Grade;
	private System.String _updated_By;
	private System.DateTime _update_Date;
    private System.String _training_gradetext;
    private System.String _training_typetext;
    private System.String _training_statustext;
    private System.String _first_name;
    private System.String _middle_name;
    private System.String _last_name;
	#endregion

	#region Public Properties
	public System.Int32 PK_Employee_Training_Id
	{
		get { return  _pK_Employee_Training_Id; }
		set { _pK_Employee_Training_Id = value; }
	}

	public System.Decimal Employee_FK
	{
		get { return  _employee_FK; }
		set { _employee_FK = value; }
	}

	public System.String Training_Description
	{
		get { return  _training_Description; }
		set { _training_Description = value; }
	}

	public System.DateTime Training_Date
	{
		get { return  _training_Date; }
		set { _training_Date = value; }
	}

    public System.Int32 Training_Status
	{
		get { return  _training_Status; }
		set { _training_Status = value; }
	}

	public System.DateTime Retrain_Date
	{
		get { return  _retrain_Date; }
		set { _retrain_Date = value; }
	}

    public System.Int32 Training_Type
	{
		get { return  _training_Type; }
		set { _training_Type = value; }
	}

    public System.Int32 Training_Grade
	{
		get { return  _training_Grade; }
		set { _training_Grade = value; }
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

    public System.String Training_GradeText
    {
        get { return _training_gradetext; }
        set { _training_gradetext = value; }
    }
    public System.String Training_TypeText
    {
        get { return _training_typetext; }
        set { _training_typetext = value; }
    }
    public System.String Training_StatusText
    {
        get { return _training_statustext; }
        set { _training_statustext = value; }
    }
    public System.String First_Name
    {
        get { return _first_name; }
        set { _first_name = value; }
    }
    public System.String Middle_Name
    {
        get { return _middle_name; }
        set { _middle_name = value; }
    }
    public System.String Last_Name
    {
        get { return _last_name; }
        set { _last_name = value; }
    }
	#endregion

	#region Abstract Methods
    public abstract List<CEmployeeTraining> GetAll();
    public abstract List<CEmployeeTraining> GetEmployee_TrainingByID(System.Decimal lPK_Employee_Training_Id);
    public abstract int InsertUpdate_Employee_Training(RIMS_Base.CEmployeeTraining obj);
	public abstract int DeleteEmployee_Training(System.String lPK_Employee_Training_Id);
	public abstract string ActivateInactivateEmployee_Training(string strIDs, int intModifiedBy, bool bIsActive);
    public abstract List<CEmployeeTraining> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria);
    public abstract List<CEmployeeTraining> GetTrainingGrade();
    public abstract List<CEmployeeTraining> GetTrainingStatus();
    public abstract List<CEmployeeTraining> GetTrainingType();
	#endregion

}

}
