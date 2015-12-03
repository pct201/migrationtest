using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_OSHA_Injury table.
	/// </summary>
	public sealed class clsLU_OSHA_Injury
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_OSHA_Injury;
		private string _Description;
		private string _OSHA_Code;
		private string _Active;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_OSHA_Injury value.
		/// </summary>
		public decimal? PK_LU_OSHA_Injury
		{
			get { return _PK_LU_OSHA_Injury; }
			set { _PK_LU_OSHA_Injury = value; }
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
		/// Initializes a new instance of the clsLU_OSHA_Injury class with default value.
		/// </summary>
		public clsLU_OSHA_Injury() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_OSHA_Injury class based on Primary Key.
		/// </summary>
		public clsLU_OSHA_Injury(decimal pK_LU_OSHA_Injury) 
		{
			DataTable dtLU_OSHA_Injury = SelectByPK(pK_LU_OSHA_Injury).Tables[0];

			if (dtLU_OSHA_Injury.Rows.Count == 1)
			{
				 SetValue(dtLU_OSHA_Injury.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_OSHA_Injury class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_OSHA_Injury) 
		{
				if (drLU_OSHA_Injury["PK_LU_OSHA_Injury"] == DBNull.Value)
					this._PK_LU_OSHA_Injury = null;
				else
					this._PK_LU_OSHA_Injury = (decimal?)drLU_OSHA_Injury["PK_LU_OSHA_Injury"];

				if (drLU_OSHA_Injury["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_OSHA_Injury["Description"];

				if (drLU_OSHA_Injury["OSHA_Code"] == DBNull.Value)
					this._OSHA_Code = null;
				else
					this._OSHA_Code = (string)drLU_OSHA_Injury["OSHA_Code"];

				if (drLU_OSHA_Injury["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_OSHA_Injury["Active"];

				if (drLU_OSHA_Injury["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drLU_OSHA_Injury["Update_Date"];

				if (drLU_OSHA_Injury["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drLU_OSHA_Injury["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_OSHA_Injury table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_OSHA_InjuryInsert");

			
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
		/// Selects a single record from the LU_OSHA_Injury table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_OSHA_Injury)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_OSHA_InjurySelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_OSHA_Injury", DbType.Decimal, pK_LU_OSHA_Injury);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_OSHA_Injury table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_OSHA_InjurySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_OSHA_Injury table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_OSHA_InjuryUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_OSHA_Injury", DbType.Decimal, this._PK_LU_OSHA_Injury);
			
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
		/// Deletes a record from the LU_OSHA_Injury table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_OSHA_Injury)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_OSHA_InjuryDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_OSHA_Injury", DbType.Decimal, pK_LU_OSHA_Injury);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
