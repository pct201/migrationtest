using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Approval_Submission table.
	/// </summary>
	public sealed class clsLU_Approval_Submission
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Approval_Submission;
		private string _Fld_Code;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Approval_Submission value.
		/// </summary>
		public decimal? PK_LU_Approval_Submission
		{
			get { return _PK_LU_Approval_Submission; }
			set { _PK_LU_Approval_Submission = value; }
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
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Approval_Submission class with default value.
		/// </summary>
		public clsLU_Approval_Submission() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Approval_Submission class based on Primary Key.
		/// </summary>
		public clsLU_Approval_Submission(decimal pK_LU_Approval_Submission) 
		{
			DataTable dtLU_Approval_Submission = SelectByPK(pK_LU_Approval_Submission).Tables[0];

			if (dtLU_Approval_Submission.Rows.Count == 1)
			{
				 SetValue(dtLU_Approval_Submission.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Approval_Submission class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Approval_Submission) 
		{
				if (drLU_Approval_Submission["PK_LU_Approval_Submission"] == DBNull.Value)
					this._PK_LU_Approval_Submission = null;
				else
					this._PK_LU_Approval_Submission = (decimal?)drLU_Approval_Submission["PK_LU_Approval_Submission"];

				if (drLU_Approval_Submission["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drLU_Approval_Submission["Fld_Code"];

				if (drLU_Approval_Submission["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Approval_Submission["Fld_Desc"];

				if (drLU_Approval_Submission["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Approval_Submission["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Approval_Submission table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Approval_SubmissionInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
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
		/// Selects a single record from the LU_Approval_Submission table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Approval_Submission)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Approval_SubmissionSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Approval_Submission", DbType.Decimal, pK_LU_Approval_Submission);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Approval_Submission table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Approval_SubmissionSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Approval_Submission table.
		/// </summary>
        public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Approval_SubmissionUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Approval_Submission", DbType.Decimal, this._PK_LU_Approval_Submission);
			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return Convert.ToDecimal(db.ExecuteNonQuery(dbCommand));
		}

		/// <summary>
		/// Deletes a record from the LU_Approval_Submission table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Approval_Submission)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Approval_SubmissionDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Approval_Submission", DbType.Decimal, pK_LU_Approval_Submission);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
