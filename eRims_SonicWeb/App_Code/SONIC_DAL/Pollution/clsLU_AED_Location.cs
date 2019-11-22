using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_AED_Location table.
	/// </summary>
	public sealed class clsLU_AED_Location
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_AED_Location;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_AED_Location value.
		/// </summary>
		public decimal? PK_LU_AED_Location
		{
			get { return _PK_LU_AED_Location; }
			set { _PK_LU_AED_Location = value; }
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
		/// Initializes a new instance of the clsLU_AED_Location class with default value.
		/// </summary>
		public clsLU_AED_Location() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_AED_Location class based on Primary Key.
		/// </summary>
		public clsLU_AED_Location(decimal pK_LU_AED_Location) 
		{
			DataTable dtLU_AED_Location = SelectByPK(pK_LU_AED_Location).Tables[0];

			if (dtLU_AED_Location.Rows.Count == 1)
			{
				 SetValue(dtLU_AED_Location.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_AED_Location class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_AED_Location) 
		{
				if (drLU_AED_Location["PK_LU_AED_Location"] == DBNull.Value)
					this._PK_LU_AED_Location = null;
				else
					this._PK_LU_AED_Location = (decimal?)drLU_AED_Location["PK_LU_AED_Location"];

				if (drLU_AED_Location["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_AED_Location["Fld_Desc"];

				if (drLU_AED_Location["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_AED_Location["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_AED_Location table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_AED_LocationInsert");

			
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
		/// Selects a single record from the LU_AED_Location table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_AED_Location)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_AED_LocationSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_AED_Location", DbType.Decimal, pK_LU_AED_Location);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_AED_Location table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_AED_LocationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_AED_Location table.
		/// </summary>
        public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_AED_LocationUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_AED_Location", DbType.Decimal, this._PK_LU_AED_Location);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_AED_Location table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_AED_Location)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_AED_LocationDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_AED_Location", DbType.Decimal, pK_LU_AED_Location);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
