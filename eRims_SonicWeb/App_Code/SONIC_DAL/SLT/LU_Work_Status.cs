using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Work_Status table.
	/// </summary>
	public sealed class LU_Work_Status
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Work_Status;
		private string _Fld_Code;
		private string _Fld_Desc;
		private bool? _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Work_Status value.
		/// </summary>
		public decimal? PK_LU_Work_Status
		{
			get { return _PK_LU_Work_Status; }
			set { _PK_LU_Work_Status = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Code value.
		/// </summary>
		public string Fld_Code
		{
			get { return _Fld_Code; }
			set { _Fld_Code = value; }
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
		public bool? Active
		{
			get { return _Active; }
			set { _Active = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Work_Status class with default value.
		/// </summary>
		public LU_Work_Status() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Work_Status class based on Primary Key.
		/// </summary>
		public LU_Work_Status(decimal pK_LU_Work_Status) 
		{
			DataTable dtLU_Work_Status = SelectByPK(pK_LU_Work_Status).Tables[0];

			if (dtLU_Work_Status.Rows.Count == 1)
			{
				 SetValue(dtLU_Work_Status.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Work_Status class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Work_Status) 
		{
				if (drLU_Work_Status["PK_LU_Work_Status"] == DBNull.Value)
					this._PK_LU_Work_Status = null;
				else
					this._PK_LU_Work_Status = (decimal?)drLU_Work_Status["PK_LU_Work_Status"];

				if (drLU_Work_Status["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drLU_Work_Status["Fld_Code"];

				if (drLU_Work_Status["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Work_Status["Fld_Desc"];

				if (drLU_Work_Status["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (bool?)drLU_Work_Status["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Work_Status table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_StatusInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			db.AddInParameter(dbCommand, "Active", DbType.Boolean, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Work_Status table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Work_Status)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_StatusSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Work_Status", DbType.Decimal, pK_LU_Work_Status);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Work_Status table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_StatusSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Work_Status table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_StatusUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Work_Status", DbType.Decimal, this._PK_LU_Work_Status);
			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			db.AddInParameter(dbCommand, "Active", DbType.Boolean, this._Active);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_Work_Status table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Work_Status)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_StatusDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Work_Status", DbType.Decimal, pK_LU_Work_Status);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
