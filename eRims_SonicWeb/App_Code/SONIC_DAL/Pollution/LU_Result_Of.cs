using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Result_Of table.
	/// </summary>
	public sealed class LU_Result_Of
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Result_Of;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Result_Of value.
		/// </summary>
		public decimal? PK_LU_Result_Of
		{
			get { return _PK_LU_Result_Of; }
			set { _PK_LU_Result_Of = value; }
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
		/// Initializes a new instance of the clsLU_Result_Of class with default value.
		/// </summary>
		public LU_Result_Of() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Result_Of class based on Primary Key.
		/// </summary>
		public LU_Result_Of(decimal pK_LU_Result_Of) 
		{
			DataTable dtLU_Result_Of = SelectByPK(pK_LU_Result_Of).Tables[0];

			if (dtLU_Result_Of.Rows.Count == 1)
			{
				 SetValue(dtLU_Result_Of.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Result_Of class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Result_Of) 
		{
				if (drLU_Result_Of["PK_LU_Result_Of"] == DBNull.Value)
					this._PK_LU_Result_Of = null;
				else
					this._PK_LU_Result_Of = (decimal?)drLU_Result_Of["PK_LU_Result_Of"];

				if (drLU_Result_Of["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Result_Of["Fld_Desc"];

				if (drLU_Result_Of["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Result_Of["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Result_Of table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Result_OfInsert");

			
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
		/// Selects a single record from the LU_Result_Of table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Result_Of)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Result_OfSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Result_Of", DbType.Decimal, pK_LU_Result_Of);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Result_Of table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Result_OfSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Result_Of table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Result_OfUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Result_Of", DbType.Decimal, this._PK_LU_Result_Of);
			
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
		/// Deletes a record from the LU_Result_Of table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Result_Of)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Result_OfDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Result_Of", DbType.Decimal, pK_LU_Result_Of);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
