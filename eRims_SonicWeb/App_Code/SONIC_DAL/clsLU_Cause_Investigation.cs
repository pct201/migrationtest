using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Cause_Investigation table.
	/// </summary>
	public sealed class clsLU_Cause_Investigation
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Cause_Investigation;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Cause_Investigation value.
		/// </summary>
		public decimal? PK_LU_Cause_Investigation
		{
			get { return _PK_LU_Cause_Investigation; }
			set { _PK_LU_Cause_Investigation = value; }
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
		/// Initializes a new instance of the clsLU_Cause_Investigation class with default value.
		/// </summary>
		public clsLU_Cause_Investigation() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Cause_Investigation class based on Primary Key.
		/// </summary>
		public clsLU_Cause_Investigation(decimal pK_LU_Cause_Investigation) 
		{
			DataTable dtLU_Cause_Investigation = SelectByPK(pK_LU_Cause_Investigation).Tables[0];

			if (dtLU_Cause_Investigation.Rows.Count == 1)
			{
				 SetValue(dtLU_Cause_Investigation.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Cause_Investigation class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Cause_Investigation) 
		{
				if (drLU_Cause_Investigation["PK_LU_Cause_Investigation"] == DBNull.Value)
					this._PK_LU_Cause_Investigation = null;
				else
					this._PK_LU_Cause_Investigation = (decimal?)drLU_Cause_Investigation["PK_LU_Cause_Investigation"];

				if (drLU_Cause_Investigation["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Cause_Investigation["Fld_Desc"];

				if (drLU_Cause_Investigation["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Cause_Investigation["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Cause_Investigation table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_InvestigationInsert");

			
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
		/// Selects a single record from the LU_Cause_Investigation table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Cause_Investigation)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_InvestigationSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Cause_Investigation", DbType.Decimal, pK_LU_Cause_Investigation);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Cause_Investigation table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_InvestigationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Cause_Investigation table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_InvestigationUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Cause_Investigation", DbType.Decimal, this._PK_LU_Cause_Investigation);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_Cause_Investigation table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Cause_Investigation)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_InvestigationDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Cause_Investigation", DbType.Decimal, pK_LU_Cause_Investigation);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
