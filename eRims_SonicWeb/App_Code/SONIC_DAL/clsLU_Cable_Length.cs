using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Cable_Length table.
	/// </summary>
	public sealed class clsLU_Cable_Length
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Cable_Length;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Cable_Length value.
		/// </summary>
		public decimal? PK_LU_Cable_Length
		{
			get { return _PK_LU_Cable_Length; }
			set { _PK_LU_Cable_Length = value; }
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
		/// Initializes a new instance of the clsLU_Cable_Length class with default value.
		/// </summary>
		public clsLU_Cable_Length() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Cable_Length class based on Primary Key.
		/// </summary>
		public clsLU_Cable_Length(decimal pK_LU_Cable_Length) 
		{
			DataTable dtLU_Cable_Length = SelectByPK(pK_LU_Cable_Length).Tables[0];

			if (dtLU_Cable_Length.Rows.Count == 1)
			{
				 SetValue(dtLU_Cable_Length.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Cable_Length class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Cable_Length) 
		{
				if (drLU_Cable_Length["PK_LU_Cable_Length"] == DBNull.Value)
					this._PK_LU_Cable_Length = null;
				else
					this._PK_LU_Cable_Length = (decimal?)drLU_Cable_Length["PK_LU_Cable_Length"];

				if (drLU_Cable_Length["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Cable_Length["Fld_Desc"];

				if (drLU_Cable_Length["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Cable_Length["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Cable_Length table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Cable_LengthInsert");

			
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
		/// Selects a single record from the LU_Cable_Length table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Cable_Length)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Cable_LengthSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Cable_Length", DbType.Decimal, pK_LU_Cable_Length);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Cable_Length table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Cable_LengthSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects all records from the LU_Cable_Length table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllByActive()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Cable_LengthSelectAllByActive");

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Updates a record in the LU_Cable_Length table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Cable_LengthUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Cable_Length", DbType.Decimal, this._PK_LU_Cable_Length);
			
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
		/// Deletes a record from the LU_Cable_Length table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Cable_Length)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Cable_LengthDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Cable_Length", DbType.Decimal, pK_LU_Cable_Length);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
