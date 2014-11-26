#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
using System.Data;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CPropIndRec
{

	#region Constructor
    public CPropIndRec()
	{
        //this._pK_Individual_Recommendations = -1;
        //this._fK_Property_Recommendations = -1;
        //this._visit = DateTime.Now;
        //this._recommendation_Number = string.Empty;
        //this._fK_Recommendation_Type = -1;
        //this._fK_Recommended_By = -1;
        //this._fK_Recommendation_Status = -1;
        //this._title = string.Empty;
        //this._recommendation_Description = string.Empty;
        //this._assigned_To = string.Empty;
        //this._due = DateTime.Now;
        //this._assigned_To_Telephone_Number = string.Empty;
        //this._assigned_To_E_Mail = string.Empty;
        //this._resolution = string.Empty;
        //this._closed = DateTime.Now;
        //this._updated_By = -1;
		this._update_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
	private System.Decimal _pK_Individual_Recommendations;
	private System.Decimal _fK_Property_Recommendations;
	private System.DateTime? _visit;
	private System.String _recommendation_Number;
	private System.Decimal? _fK_Recommendation_Type;
	private System.Decimal? _fK_Recommended_By;
	private System.Decimal? _fK_Recommendation_Status;
	private System.String _title;
	private System.String _recommendation_Description;
	private System.String _assigned_To;
	private System.DateTime? _due;
	private System.String _assigned_To_Telephone_Number;
	private System.String _assigned_To_E_Mail;
	private System.String _resolution;
	private System.DateTime? _closed;
	private System.Decimal _updated_By;
	private System.DateTime _update_Date;

	#endregion

	#region Public Properties
	public System.Decimal PK_Individual_Recommendations
	{
		get { return  _pK_Individual_Recommendations; }
		set { _pK_Individual_Recommendations = value; }
	}

	public System.Decimal FK_Property_Recommendations
	{
		get { return  _fK_Property_Recommendations; }
		set { _fK_Property_Recommendations = value; }
	}

	public System.DateTime? Visit
	{
		get { return  _visit; }
		set { _visit = value; }
	}

	public System.String Recommendation_Number
	{
		get { return  _recommendation_Number; }
		set { _recommendation_Number = value; }
	}

	public System.Decimal? FK_Recommendation_Type
	{
		get { return  _fK_Recommendation_Type; }
		set { _fK_Recommendation_Type = value; }
	}

	public System.Decimal? FK_Recommended_By
	{
		get { return  _fK_Recommended_By; }
		set { _fK_Recommended_By = value; }
	}

	public System.Decimal? FK_Recommendation_Status
	{
		get { return  _fK_Recommendation_Status; }
		set { _fK_Recommendation_Status = value; }
	}

	public System.String Title
	{
		get { return  _title; }
		set { _title = value; }
	}

	public System.String Recommendation_Description
	{
		get { return  _recommendation_Description; }
		set { _recommendation_Description = value; }
	}

	public System.String Assigned_To
	{
		get { return  _assigned_To; }
		set { _assigned_To = value; }
	}

	public System.DateTime? Due
	{
		get { return  _due; }
		set { _due = value; }
	}

	public System.String Assigned_To_Telephone_Number
	{
		get { return  _assigned_To_Telephone_Number; }
		set { _assigned_To_Telephone_Number = value; }
	}

	public System.String Assigned_To_E_Mail
	{
		get { return  _assigned_To_E_Mail; }
		set { _assigned_To_E_Mail = value; }
	}

	public System.String Resolution
	{
		get { return  _resolution; }
		set { _resolution = value; }
	}

	public System.DateTime? Closed
	{
		get { return  _closed; }
		set { _closed = value; }
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
    public abstract DataSet PropIndRec_GetByID(System.Decimal lPK_Individual_Recommendations);
    public abstract int PropIndRec_InsertUpdate(RIMS_Base.CPropIndRec obj);
    public abstract int PropIndRec_Delete(System.String lPK_Individual_Recommendations);
    public abstract DataSet GetRecType();
    public abstract DataSet GetRecStatus();
    public abstract DataSet GetRecBy();
    public abstract DataSet GetAssignedTo();
    public abstract DataSet GetDataAssignTo(System.Decimal UserID);
    public abstract DataSet PropIndRec_GetByRecID(System.Decimal RecID);
	#endregion

}

}
