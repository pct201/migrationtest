using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Alarm_Vehicle table.
	/// </summary>
	public sealed class LU_Alarm_Vehicle
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Alarm_Vehicle;
		private string _Fld_Code;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Alarm_Vehicle value.
		/// </summary>
		public decimal? PK_LU_Alarm_Vehicle
		{
			get { return _PK_LU_Alarm_Vehicle; }
			set { _PK_LU_Alarm_Vehicle = value; }
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
		/// Initializes a new instance of the clsLU_Alarm_Vehicle class with default value.
		/// </summary>
		public LU_Alarm_Vehicle() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Alarm_Vehicle class based on Primary Key.
		/// </summary>
		public LU_Alarm_Vehicle(decimal pK_LU_Alarm_Vehicle) 
		{
			DataTable dtLU_Alarm_Vehicle = SelectByPK(pK_LU_Alarm_Vehicle).Tables[0];

			if (dtLU_Alarm_Vehicle.Rows.Count == 1)
			{
				 SetValue(dtLU_Alarm_Vehicle.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Alarm_Vehicle class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Alarm_Vehicle) 
		{
				if (drLU_Alarm_Vehicle["PK_LU_Alarm_Vehicle"] == DBNull.Value)
					this._PK_LU_Alarm_Vehicle = null;
				else
					this._PK_LU_Alarm_Vehicle = (decimal?)drLU_Alarm_Vehicle["PK_LU_Alarm_Vehicle"];

				if (drLU_Alarm_Vehicle["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drLU_Alarm_Vehicle["Fld_Code"];

				if (drLU_Alarm_Vehicle["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Alarm_Vehicle["Fld_Desc"];

				if (drLU_Alarm_Vehicle["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Alarm_Vehicle["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Alarm_Vehicle table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Alarm_VehicleInsert");

			
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
		/// Selects a single record from the LU_Alarm_Vehicle table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Alarm_Vehicle)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Alarm_VehicleSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Alarm_Vehicle", DbType.Decimal, pK_LU_Alarm_Vehicle);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Alarm_Vehicle table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Alarm_VehicleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Alarm_Vehicle table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Alarm_VehicleUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Alarm_Vehicle", DbType.Decimal, this._PK_LU_Alarm_Vehicle);
			
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
		/// Deletes a record from the LU_Alarm_Vehicle table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Alarm_Vehicle)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Alarm_VehicleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Alarm_Vehicle", DbType.Decimal, pK_LU_Alarm_Vehicle);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
