using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table LU_Maintenance_Status
	/// </summary>
	public sealed class LU_Maintenance_Status
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Maintenance_Status;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Maintenance_Status value.
		/// </summary>
		public decimal? PK_LU_Maintenance_Status
		{
			get { return _PK_LU_Maintenance_Status; }
			set { _PK_LU_Maintenance_Status = value; }
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
		/// Initializes a new instance of the LU_Maintenance_Status class with default value.
		/// </summary>
		public LU_Maintenance_Status() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Maintenance_Status class based on Primary Key.
		/// </summary>
		public LU_Maintenance_Status(decimal pK_LU_Maintenance_Status) 
		{
			DataTable dtLU_Maintenance_Status = Select(pK_LU_Maintenance_Status).Tables[0];

			if (dtLU_Maintenance_Status.Rows.Count == 1)
			{
				 SetValue(dtLU_Maintenance_Status.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_Maintenance_Status class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Maintenance_Status) 
		{
				if (drLU_Maintenance_Status["PK_LU_Maintenance_Status"] == DBNull.Value)
					this._PK_LU_Maintenance_Status = null;
				else
					this._PK_LU_Maintenance_Status = (decimal?)drLU_Maintenance_Status["PK_LU_Maintenance_Status"];

				if (drLU_Maintenance_Status["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Maintenance_Status["Fld_Desc"];

				if (drLU_Maintenance_Status["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Maintenance_Status["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Maintenance_Status table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Maintenance_StatusInsert");

			
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
		/// Selects a single record from the LU_Maintenance_Status table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_Maintenance_Status)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Maintenance_StatusSelect");

			db.AddInParameter(dbCommand, "PK_LU_Maintenance_Status", DbType.Decimal, pK_LU_Maintenance_Status);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Maintenance_Status table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Maintenance_StatusSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Maintenance_Status table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Maintenance_StatusUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Maintenance_Status", DbType.Decimal, this._PK_LU_Maintenance_Status);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			return db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_Maintenance_Status table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_Maintenance_Status)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Maintenance_StatusDelete");

			db.AddInParameter(dbCommand, "PK_LU_Maintenance_Status", DbType.Decimal, pK_LU_Maintenance_Status);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
