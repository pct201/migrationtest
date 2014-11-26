using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_EPA_Assessor table.
	/// </summary>
	public sealed class LU_EPA_Assessor
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_EPA_Assessor;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_EPA_Assessor value.
		/// </summary>
		public decimal? PK_LU_EPA_Assessor
		{
			get { return _PK_LU_EPA_Assessor; }
			set { _PK_LU_EPA_Assessor = value; }
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
		/// Initializes a new instance of the clsLU_EPA_Assessor class with default value.
		/// </summary>
		public LU_EPA_Assessor() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_EPA_Assessor class based on Primary Key.
		/// </summary>
		public LU_EPA_Assessor(decimal pK_LU_EPA_Assessor) 
		{
			DataTable dtLU_EPA_Assessor = SelectByPK(pK_LU_EPA_Assessor).Tables[0];

			if (dtLU_EPA_Assessor.Rows.Count == 1)
			{
				 SetValue(dtLU_EPA_Assessor.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_EPA_Assessor class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_EPA_Assessor) 
		{
				if (drLU_EPA_Assessor["PK_LU_EPA_Assessor"] == DBNull.Value)
					this._PK_LU_EPA_Assessor = null;
				else
					this._PK_LU_EPA_Assessor = (decimal?)drLU_EPA_Assessor["PK_LU_EPA_Assessor"];

				if (drLU_EPA_Assessor["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_EPA_Assessor["Fld_Desc"];

				if (drLU_EPA_Assessor["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_EPA_Assessor["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_EPA_Assessor table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPA_AssessorInsert");

			
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
		/// Selects a single record from the LU_EPA_Assessor table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_EPA_Assessor)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPA_AssessorSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_EPA_Assessor", DbType.Decimal, pK_LU_EPA_Assessor);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_EPA_Assessor table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPA_AssessorSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_EPA_Assessor table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPA_AssessorUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_EPA_Assessor", DbType.Decimal, this._PK_LU_EPA_Assessor);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the LU_EPA_Assessor table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_EPA_Assessor)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPA_AssessorDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_EPA_Assessor", DbType.Decimal, pK_LU_EPA_Assessor);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
