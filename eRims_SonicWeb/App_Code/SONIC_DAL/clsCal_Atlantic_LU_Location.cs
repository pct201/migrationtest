using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Cal_Atlantic_LU_Location table.
	/// </summary>
	public sealed class clsCal_Atlantic_LU_Location
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Cal_Atlantic_LU_Location;
		private string _Fld_Code;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Cal_Atlantic_LU_Location value.
		/// </summary>
		public decimal? PK_Cal_Atlantic_LU_Location
		{
			get { return _PK_Cal_Atlantic_LU_Location; }
			set { _PK_Cal_Atlantic_LU_Location = value; }
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
		/// Initializes a new instance of the clsCal_Atlantic_LU_Location class with default value.
		/// </summary>
		public clsCal_Atlantic_LU_Location() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsCal_Atlantic_LU_Location class based on Primary Key.
		/// </summary>
		public clsCal_Atlantic_LU_Location(decimal pK_Cal_Atlantic_LU_Location) 
		{
			DataTable dtCal_Atlantic_LU_Location = SelectByPK(pK_Cal_Atlantic_LU_Location).Tables[0];

			if (dtCal_Atlantic_LU_Location.Rows.Count == 1)
			{
				 SetValue(dtCal_Atlantic_LU_Location.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsCal_Atlantic_LU_Location class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drCal_Atlantic_LU_Location) 
		{
				if (drCal_Atlantic_LU_Location["PK_Cal_Atlantic_LU_Location"] == DBNull.Value)
					this._PK_Cal_Atlantic_LU_Location = null;
				else
					this._PK_Cal_Atlantic_LU_Location = (decimal?)drCal_Atlantic_LU_Location["PK_Cal_Atlantic_LU_Location"];

				if (drCal_Atlantic_LU_Location["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drCal_Atlantic_LU_Location["Fld_Code"];

				if (drCal_Atlantic_LU_Location["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drCal_Atlantic_LU_Location["Fld_Desc"];

				if (drCal_Atlantic_LU_Location["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drCal_Atlantic_LU_Location["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Cal_Atlantic_LU_Location table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Cal_Atlantic_LU_LocationInsert");

			
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
		/// Selects a single record from the Cal_Atlantic_LU_Location table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Cal_Atlantic_LU_Location)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Cal_Atlantic_LU_LocationSelectByPK");

			db.AddInParameter(dbCommand, "PK_Cal_Atlantic_LU_Location", DbType.Decimal, pK_Cal_Atlantic_LU_Location);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Cal_Atlantic_LU_Location table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Cal_Atlantic_LU_LocationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Cal_Atlantic_LU_Location table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Cal_Atlantic_LU_LocationUpdate");

			
			db.AddInParameter(dbCommand, "PK_Cal_Atlantic_LU_Location", DbType.Decimal, this._PK_Cal_Atlantic_LU_Location);
			
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

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Cal_Atlantic_LU_Location table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Cal_Atlantic_LU_Location)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Cal_Atlantic_LU_LocationDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Cal_Atlantic_LU_Location", DbType.Decimal, pK_Cal_Atlantic_LU_Location);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
