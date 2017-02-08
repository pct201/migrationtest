using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Management_Task_Process table.
	/// </summary>
	public sealed class clsLU_Management_Task_Process
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Management_Task_Process;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Management_Task_Process value.
		/// </summary>
		public decimal? PK_LU_Management_Task_Process
		{
			get { return _PK_LU_Management_Task_Process; }
			set { _PK_LU_Management_Task_Process = value; }
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
		/// Initializes a new instance of the clsLU_Management_Task_Process class with default value.
		/// </summary>
		public clsLU_Management_Task_Process() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Management_Task_Process class based on Primary Key.
		/// </summary>
		public clsLU_Management_Task_Process(decimal pK_LU_Management_Task_Process) 
		{
			DataTable dtLU_Management_Task_Process = SelectByPK(pK_LU_Management_Task_Process).Tables[0];

			if (dtLU_Management_Task_Process.Rows.Count == 1)
			{
				 SetValue(dtLU_Management_Task_Process.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Management_Task_Process class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Management_Task_Process) 
		{
				if (drLU_Management_Task_Process["PK_LU_Management_Task_Process"] == DBNull.Value)
					this._PK_LU_Management_Task_Process = null;
				else
					this._PK_LU_Management_Task_Process = (decimal?)drLU_Management_Task_Process["PK_LU_Management_Task_Process"];

				if (drLU_Management_Task_Process["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Management_Task_Process["Fld_Desc"];

				if (drLU_Management_Task_Process["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Management_Task_Process["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Management_Task_Process table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Management_Task_ProcessInsert");

			
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
		/// Selects a single record from the LU_Management_Task_Process table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Management_Task_Process)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Management_Task_ProcessSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Management_Task_Process", DbType.Decimal, pK_LU_Management_Task_Process);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Management_Task_Process table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Management_Task_ProcessSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Management_Task_Process table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Management_Task_ProcessUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Management_Task_Process", DbType.Decimal, this._PK_LU_Management_Task_Process);
			
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
		/// Deletes a record from the LU_Management_Task_Process table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Management_Task_Process)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Management_Task_ProcessDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Management_Task_Process", DbType.Decimal, pK_LU_Management_Task_Process);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
