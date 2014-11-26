using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for AP_Property_Security_Monitor_Grids table.
	/// </summary>
	public sealed class clsAP_Property_Security_Monitor_Grids
	{

		#region Private variables used to hold the property values

		private decimal? _PK_AP_Property_Security_Monitor_Grids;
		private decimal? _FK_AP_Property_Security;
		private string _Grid_Type;
		private decimal? _Start_Day;
		private string _Start_Time;
		private decimal? _End_Day;
		private string _End_Time;
		private string _Hours;
		private string _Updated_By;
		private DateTime? _Updated_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_AP_Property_Security_Monitor_Grids value.
		/// </summary>
		public decimal? PK_AP_Property_Security_Monitor_Grids
		{
			get { return _PK_AP_Property_Security_Monitor_Grids; }
			set { _PK_AP_Property_Security_Monitor_Grids = value; }
		}

		/// <summary>
		/// Gets or sets the FK_AP_Property_Security value.
		/// </summary>
		public decimal? FK_AP_Property_Security
		{
			get { return _FK_AP_Property_Security; }
			set { _FK_AP_Property_Security = value; }
		}

		/// <summary>
		/// Gets or sets the Grid_Type value.
		/// </summary>
		public string Grid_Type
		{
			get { return _Grid_Type; }
			set { _Grid_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Start_Day value.
		/// </summary>
		public decimal? Start_Day
		{
			get { return _Start_Day; }
			set { _Start_Day = value; }
		}

		/// <summary>
		/// Gets or sets the Start_Time value.
		/// </summary>
		public string Start_Time
		{
			get { return _Start_Time; }
			set { _Start_Time = value; }
		}

		/// <summary>
		/// Gets or sets the End_Day value.
		/// </summary>
		public decimal? End_Day
		{
			get { return _End_Day; }
			set { _End_Day = value; }
		}

		/// <summary>
		/// Gets or sets the End_Time value.
		/// </summary>
		public string End_Time
		{
			get { return _End_Time; }
			set { _End_Time = value; }
		}

		/// <summary>
		/// Gets or sets the Hours value.
		/// </summary>
		public string Hours
		{
			get { return _Hours; }
			set { _Hours = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_Date value.
		/// </summary>
		public DateTime? Updated_Date
		{
			get { return _Updated_Date; }
			set { _Updated_Date = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsAP_Property_Security_Monitor_Grids class with default value.
		/// </summary>
		public clsAP_Property_Security_Monitor_Grids() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsAP_Property_Security_Monitor_Grids class based on Primary Key.
		/// </summary>
		public clsAP_Property_Security_Monitor_Grids(decimal pK_AP_Property_Security_Monitor_Grids) 
		{
			DataTable dtAP_Property_Security_Monitor_Grids = SelectByPK(pK_AP_Property_Security_Monitor_Grids).Tables[0];

			if (dtAP_Property_Security_Monitor_Grids.Rows.Count == 1)
			{
				 SetValue(dtAP_Property_Security_Monitor_Grids.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsAP_Property_Security_Monitor_Grids class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drAP_Property_Security_Monitor_Grids) 
		{
				if (drAP_Property_Security_Monitor_Grids["PK_AP_Property_Security_Monitor_Grids"] == DBNull.Value)
					this._PK_AP_Property_Security_Monitor_Grids = null;
				else
					this._PK_AP_Property_Security_Monitor_Grids = (decimal?)drAP_Property_Security_Monitor_Grids["PK_AP_Property_Security_Monitor_Grids"];

				if (drAP_Property_Security_Monitor_Grids["FK_AP_Property_Security"] == DBNull.Value)
					this._FK_AP_Property_Security = null;
				else
					this._FK_AP_Property_Security = (decimal?)drAP_Property_Security_Monitor_Grids["FK_AP_Property_Security"];

				if (drAP_Property_Security_Monitor_Grids["Grid_Type"] == DBNull.Value)
					this._Grid_Type = null;
				else
					this._Grid_Type = (string)drAP_Property_Security_Monitor_Grids["Grid_Type"];

				if (drAP_Property_Security_Monitor_Grids["Start_Day"] == DBNull.Value)
					this._Start_Day = null;
				else
					this._Start_Day = (decimal?)drAP_Property_Security_Monitor_Grids["Start_Day"];

				if (drAP_Property_Security_Monitor_Grids["Start_Time"] == DBNull.Value)
					this._Start_Time = null;
				else
					this._Start_Time = (string)drAP_Property_Security_Monitor_Grids["Start_Time"];

				if (drAP_Property_Security_Monitor_Grids["End_Day"] == DBNull.Value)
					this._End_Day = null;
				else
					this._End_Day = (decimal?)drAP_Property_Security_Monitor_Grids["End_Day"];

				if (drAP_Property_Security_Monitor_Grids["End_Time"] == DBNull.Value)
					this._End_Time = null;
				else
					this._End_Time = (string)drAP_Property_Security_Monitor_Grids["End_Time"];

				if (drAP_Property_Security_Monitor_Grids["Hours"] == DBNull.Value)
					this._Hours = null;
				else
					this._Hours = (string)drAP_Property_Security_Monitor_Grids["Hours"];

				if (drAP_Property_Security_Monitor_Grids["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drAP_Property_Security_Monitor_Grids["Updated_By"];

				if (drAP_Property_Security_Monitor_Grids["Updated_Date"] == DBNull.Value)
					this._Updated_Date = null;
				else
					this._Updated_Date = (DateTime?)drAP_Property_Security_Monitor_Grids["Updated_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the AP_Property_Security_Monitor_Grids table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_Security_Monitor_GridsInsert");

			
			db.AddInParameter(dbCommand, "FK_AP_Property_Security", DbType.Decimal, this._FK_AP_Property_Security);
			
			if (string.IsNullOrEmpty(this._Grid_Type))
				db.AddInParameter(dbCommand, "Grid_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Grid_Type", DbType.String, this._Grid_Type);
			
			db.AddInParameter(dbCommand, "Start_Day", DbType.Decimal, this._Start_Day);
			
			if (string.IsNullOrEmpty(this._Start_Time))
				db.AddInParameter(dbCommand, "Start_Time", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Start_Time", DbType.String, this._Start_Time);
			
			db.AddInParameter(dbCommand, "End_Day", DbType.Decimal, this._End_Day);
			
			if (string.IsNullOrEmpty(this._End_Time))
				db.AddInParameter(dbCommand, "End_Time", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "End_Time", DbType.String, this._End_Time);
			
			if (string.IsNullOrEmpty(this._Hours))
				db.AddInParameter(dbCommand, "Hours", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Hours", DbType.String, this._Hours);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the AP_Property_Security_Monitor_Grids table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_AP_Property_Security_Monitor_Grids)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_Security_Monitor_GridsSelectByPK");

			db.AddInParameter(dbCommand, "PK_AP_Property_Security_Monitor_Grids", DbType.Decimal, pK_AP_Property_Security_Monitor_Grids);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the AP_Property_Security_Monitor_Grids table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_Security_Monitor_GridsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the AP_Property_Security_Monitor_Grids table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_Security_Monitor_GridsUpdate");

			
			db.AddInParameter(dbCommand, "PK_AP_Property_Security_Monitor_Grids", DbType.Decimal, this._PK_AP_Property_Security_Monitor_Grids);
			
			db.AddInParameter(dbCommand, "FK_AP_Property_Security", DbType.Decimal, this._FK_AP_Property_Security);
			
			if (string.IsNullOrEmpty(this._Grid_Type))
				db.AddInParameter(dbCommand, "Grid_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Grid_Type", DbType.String, this._Grid_Type);
			
			db.AddInParameter(dbCommand, "Start_Day", DbType.Decimal, this._Start_Day);
			
			if (string.IsNullOrEmpty(this._Start_Time))
				db.AddInParameter(dbCommand, "Start_Time", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Start_Time", DbType.String, this._Start_Time);
			
			db.AddInParameter(dbCommand, "End_Day", DbType.Decimal, this._End_Day);
			
			if (string.IsNullOrEmpty(this._End_Time))
				db.AddInParameter(dbCommand, "End_Time", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "End_Time", DbType.String, this._End_Time);
			
			if (string.IsNullOrEmpty(this._Hours))
				db.AddInParameter(dbCommand, "Hours", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Hours", DbType.String, this._Hours);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the AP_Property_Security_Monitor_Grids table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_AP_Property_Security_Monitor_Grids)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_Security_Monitor_GridsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_AP_Property_Security_Monitor_Grids", DbType.Decimal, pK_AP_Property_Security_Monitor_Grids);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects all records from the AP_Property_Security_Monitor_Grids table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllForMonitoringGrid(decimal fK_AP_Property_Security)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_Security_Monitor_GridsSelectAllForMonitoringGrid");
            db.AddInParameter(dbCommand, "FK_AP_Property_Security", DbType.Decimal, fK_AP_Property_Security);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
