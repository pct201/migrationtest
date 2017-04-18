using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Job_Code table.
	/// </summary>
	public sealed class clsLU_Job_Code
	{

		#region Private variables used to hold the property values

		private decimal? _pk_lu_job_code;
		private string _Code;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the pk_lu_job_code value.
		/// </summary>
		public decimal? pk_lu_job_code
		{
			get { return _pk_lu_job_code; }
			set { _pk_lu_job_code = value; }
		}

		/// <summary>
		/// Gets or sets the Code value.
		/// </summary>
		public string Code
		{
			get { return _Code; }
			set { _Code = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Job_Code class with default value.
		/// </summary>
		public clsLU_Job_Code() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Job_Code class based on Primary Key.
		/// </summary>
		public clsLU_Job_Code(decimal pk_lu_job_code) 
		{
			DataTable dtLU_Job_Code = SelectByPK(pk_lu_job_code).Tables[0];

			if (dtLU_Job_Code.Rows.Count == 1)
			{
				 SetValue(dtLU_Job_Code.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Job_Code class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Job_Code) 
		{
				if (drLU_Job_Code["pk_lu_job_code"] == DBNull.Value)
					this._pk_lu_job_code = null;
				else
					this._pk_lu_job_code = (decimal?)drLU_Job_Code["pk_lu_job_code"];

				if (drLU_Job_Code["Code"] == DBNull.Value)
					this._Code = null;
				else
					this._Code = (string)drLU_Job_Code["Code"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Job_Code table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Job_CodeInsert");

			
			if (string.IsNullOrEmpty(this._Code))
				db.AddInParameter(dbCommand, "Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Job_Code table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pk_lu_job_code)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Job_CodeSelectByPK");

			db.AddInParameter(dbCommand, "pk_lu_job_code", DbType.Decimal, pk_lu_job_code);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Job_Code table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Job_CodeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Job_Code table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Job_CodeUpdate");

			
			db.AddInParameter(dbCommand, "pk_lu_job_code", DbType.Decimal, this._pk_lu_job_code);
			
			if (string.IsNullOrEmpty(this._Code))
				db.AddInParameter(dbCommand, "Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_Job_Code table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pk_lu_job_code)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Job_CodeDeleteByPK");

			db.AddInParameter(dbCommand, "pk_lu_job_code", DbType.Decimal, pk_lu_job_code);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
