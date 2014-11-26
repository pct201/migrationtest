using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Tank_Contents table.
	/// </summary>
	public sealed class LU_Tank_Contents
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Tank_Contents;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Tank_Contents value.
		/// </summary>
		public decimal? PK_LU_Tank_Contents
		{
			get { return _PK_LU_Tank_Contents; }
			set { _PK_LU_Tank_Contents = value; }
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
		/// Initializes a new instance of the clsLU_Tank_Contents class with default value.
		/// </summary>
		public LU_Tank_Contents() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Tank_Contents class based on Primary Key.
		/// </summary>
		public LU_Tank_Contents(decimal pK_LU_Tank_Contents) 
		{
			DataTable dtLU_Tank_Contents = SelectByPK(pK_LU_Tank_Contents).Tables[0];

			if (dtLU_Tank_Contents.Rows.Count == 1)
			{
				 SetValue(dtLU_Tank_Contents.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Tank_Contents class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Tank_Contents) 
		{
				if (drLU_Tank_Contents["PK_LU_Tank_Contents"] == DBNull.Value)
					this._PK_LU_Tank_Contents = null;
				else
					this._PK_LU_Tank_Contents = (decimal?)drLU_Tank_Contents["PK_LU_Tank_Contents"];

				if (drLU_Tank_Contents["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Tank_Contents["Fld_Desc"];

				if (drLU_Tank_Contents["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Tank_Contents["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Tank_Contents table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Tank_ContentsInsert");

			
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
		/// Selects a single record from the LU_Tank_Contents table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Tank_Contents)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Tank_ContentsSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Tank_Contents", DbType.Decimal, pK_LU_Tank_Contents);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Tank_Contents table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Tank_ContentsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Tank_Contents table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Tank_ContentsUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Tank_Contents", DbType.Decimal, this._PK_LU_Tank_Contents);
			
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
		/// Deletes a record from the LU_Tank_Contents table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Tank_Contents)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Tank_ContentsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Tank_Contents", DbType.Decimal, pK_LU_Tank_Contents);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
