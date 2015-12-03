using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_OSHA_Incident table.
	/// </summary>
	public sealed class clsLU_OSHA_Incident
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_OSHA_Incident;
		private string _Description;
		private string _OSHA_Code;
		private string _Active;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_OSHA_Incident value.
		/// </summary>
		public decimal? PK_LU_OSHA_Incident
		{
			get { return _PK_LU_OSHA_Incident; }
			set { _PK_LU_OSHA_Incident = value; }
		}

		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		/// <summary>
		/// Gets or sets the OSHA_Code value.
		/// </summary>
		public string OSHA_Code
		{
			get { return _OSHA_Code; }
			set { _OSHA_Code = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}

		/// <summary>
		/// Gets or sets the Update_Date value.
		/// </summary>
		public DateTime? Update_Date
		{
			get { return _Update_Date; }
			set { _Update_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_OSHA_Incident class with default value.
		/// </summary>
		public clsLU_OSHA_Incident() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_OSHA_Incident class based on Primary Key.
		/// </summary>
		public clsLU_OSHA_Incident(decimal pK_LU_OSHA_Incident) 
		{
			DataTable dtLU_OSHA_Incident = SelectByPK(pK_LU_OSHA_Incident).Tables[0];

			if (dtLU_OSHA_Incident.Rows.Count == 1)
			{
				 SetValue(dtLU_OSHA_Incident.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_OSHA_Incident class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_OSHA_Incident) 
		{
				if (drLU_OSHA_Incident["PK_LU_OSHA_Incident"] == DBNull.Value)
					this._PK_LU_OSHA_Incident = null;
				else
					this._PK_LU_OSHA_Incident = (decimal?)drLU_OSHA_Incident["PK_LU_OSHA_Incident"];

				if (drLU_OSHA_Incident["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_OSHA_Incident["Description"];

				if (drLU_OSHA_Incident["OSHA_Code"] == DBNull.Value)
					this._OSHA_Code = null;
				else
					this._OSHA_Code = (string)drLU_OSHA_Incident["OSHA_Code"];

				if (drLU_OSHA_Incident["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_OSHA_Incident["Active"];

				if (drLU_OSHA_Incident["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drLU_OSHA_Incident["Update_Date"];

				if (drLU_OSHA_Incident["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drLU_OSHA_Incident["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_OSHA_Incident table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_OSHA_IncidentInsert");

			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._OSHA_Code))
				db.AddInParameter(dbCommand, "OSHA_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "OSHA_Code", DbType.String, this._OSHA_Code);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_OSHA_Incident table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_OSHA_Incident)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_OSHA_IncidentSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_OSHA_Incident", DbType.Decimal, pK_LU_OSHA_Incident);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_OSHA_Incident table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_OSHA_IncidentSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_OSHA_Incident table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_OSHA_IncidentUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_OSHA_Incident", DbType.Decimal, this._PK_LU_OSHA_Incident);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._OSHA_Code))
				db.AddInParameter(dbCommand, "OSHA_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "OSHA_Code", DbType.String, this._OSHA_Code);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_OSHA_Incident table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_OSHA_Incident)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_OSHA_IncidentDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_OSHA_Incident", DbType.Decimal, pK_LU_OSHA_Incident);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
