using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table LU_SLT_Safety_Walk_Department
	/// </summary>
	public sealed class LU_SLT_Safety_Walk_Department
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_SLT_Safety_Walk_Department;
		private string _Department;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_SLT_Safety_Walk_Department value.
		/// </summary>
		public decimal? PK_LU_SLT_Safety_Walk_Department
		{
			get { return _PK_LU_SLT_Safety_Walk_Department; }
			set { _PK_LU_SLT_Safety_Walk_Department = value; }
		}

		/// <summary>
		/// Gets or sets the Department value.
		/// </summary>
		public string Department
		{
			get { return _Department; }
			set { _Department = value; }
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
		/// Initializes a new instance of the LU_SLT_Safety_Walk_Department class with default value.
		/// </summary>
		public LU_SLT_Safety_Walk_Department() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_SLT_Safety_Walk_Department class based on Primary Key.
		/// </summary>
		public LU_SLT_Safety_Walk_Department(decimal pK_LU_SLT_Safety_Walk_Department) 
		{
			DataTable dtLU_SLT_Safety_Walk_Department = Select(pK_LU_SLT_Safety_Walk_Department).Tables[0];

			if (dtLU_SLT_Safety_Walk_Department.Rows.Count == 1)
			{
				 SetValue(dtLU_SLT_Safety_Walk_Department.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_SLT_Safety_Walk_Department class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_SLT_Safety_Walk_Department) 
		{
				if (drLU_SLT_Safety_Walk_Department["PK_LU_SLT_Safety_Walk_Department"] == DBNull.Value)
					this._PK_LU_SLT_Safety_Walk_Department = null;
				else
					this._PK_LU_SLT_Safety_Walk_Department = (decimal?)drLU_SLT_Safety_Walk_Department["PK_LU_SLT_Safety_Walk_Department"];

				if (drLU_SLT_Safety_Walk_Department["Department"] == DBNull.Value)
					this._Department = null;
				else
					this._Department = (string)drLU_SLT_Safety_Walk_Department["Department"];

				if (drLU_SLT_Safety_Walk_Department["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_SLT_Safety_Walk_Department["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_SLT_Safety_Walk_Department table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_DepartmentInsert");

			
			if (string.IsNullOrEmpty(this._Department))
				db.AddInParameter(dbCommand, "Department", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Department", DbType.String, this._Department);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_SLT_Safety_Walk_Department table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_SLT_Safety_Walk_Department)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_DepartmentSelect");

			db.AddInParameter(dbCommand, "PK_LU_SLT_Safety_Walk_Department", DbType.Decimal, pK_LU_SLT_Safety_Walk_Department);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_SLT_Safety_Walk_Department table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_DepartmentSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_SLT_Safety_Walk_Department table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_DepartmentUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_SLT_Safety_Walk_Department", DbType.Decimal, this._PK_LU_SLT_Safety_Walk_Department);
			
			if (string.IsNullOrEmpty(this._Department))
				db.AddInParameter(dbCommand, "Department", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Department", DbType.String, this._Department);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_SLT_Safety_Walk_Department table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_SLT_Safety_Walk_Department)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_DepartmentDelete");

			db.AddInParameter(dbCommand, "PK_LU_SLT_Safety_Walk_Department", DbType.Decimal, pK_LU_SLT_Safety_Walk_Department);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
