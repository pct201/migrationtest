using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_EPM_Outcome table.
	/// </summary>
	public sealed class LU_EPM_Outcome
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_EPM_Outcome;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_EPM_Outcome value.
		/// </summary>
		public decimal? PK_LU_EPM_Outcome
		{
			get { return _PK_LU_EPM_Outcome; }
			set { _PK_LU_EPM_Outcome = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Desc value.
		/// </summary>
		public string Fld_Desc
		{
			get { return _Fld_Desc; }
			set { _Fld_Desc = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_EPM_Outcome class with default value.
		/// </summary>
		public LU_EPM_Outcome() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_EPM_Outcome class based on Primary Key.
		/// </summary>
		public LU_EPM_Outcome(decimal pK_LU_EPM_Outcome) 
		{
			DataTable dtLU_EPM_Outcome = SelectByPK(pK_LU_EPM_Outcome).Tables[0];

			if (dtLU_EPM_Outcome.Rows.Count == 1)
			{
				 SetValue(dtLU_EPM_Outcome.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_EPM_Outcome class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_EPM_Outcome) 
		{
				if (drLU_EPM_Outcome["PK_LU_EPM_Outcome"] == DBNull.Value)
					this._PK_LU_EPM_Outcome = null;
				else
					this._PK_LU_EPM_Outcome = (decimal?)drLU_EPM_Outcome["PK_LU_EPM_Outcome"];

				if (drLU_EPM_Outcome["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_EPM_Outcome["Fld_Desc"];

				if (drLU_EPM_Outcome["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_EPM_Outcome["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_EPM_Outcome table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_OutcomeInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_EPM_Outcome table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_EPM_Outcome)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_OutcomeSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_EPM_Outcome", DbType.Decimal, pK_LU_EPM_Outcome);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_EPM_Outcome table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_OutcomeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_EPM_Outcome table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_OutcomeUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_EPM_Outcome", DbType.Decimal, this._PK_LU_EPM_Outcome);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Deletes a record from the LU_EPM_Outcome table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_EPM_Outcome)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_OutcomeDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_EPM_Outcome", DbType.Decimal, pK_LU_EPM_Outcome);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
