using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Complaince_Reporting_OSHA table.
	/// </summary>
	public sealed class clsPM_Complaince_Reporting_OSHA
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Compliance_Reporting_OSHA;
		private decimal? _FK_PM_Complaince_Reporting;
		private DateTime? _Date_Completed;
		private string _Log_Posted_Feb_1;
		private int? _OSHA_Recordable;
		private int? _Lost_Work_Days;
		private int? _Restsricted_Work_Days;
		private int? _Total_Associates;
		private string _Comments;
		private string _Updated_By;
		private DateTime? _Updated_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Compliance_Reporting_OSHA value.
		/// </summary>
		public decimal? PK_PM_Compliance_Reporting_OSHA
		{
			get { return _PK_PM_Compliance_Reporting_OSHA; }
			set { _PK_PM_Compliance_Reporting_OSHA = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_Complaince_Reporting value.
		/// </summary>
		public decimal? FK_PM_Complaince_Reporting
		{
			get { return _FK_PM_Complaince_Reporting; }
			set { _FK_PM_Complaince_Reporting = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Completed value.
		/// </summary>
		public DateTime? Date_Completed
		{
			get { return _Date_Completed; }
			set { _Date_Completed = value; }
		}

		/// <summary>
		/// Gets or sets the Log_Posted_Feb_1 value.
		/// </summary>
		public string Log_Posted_Feb_1
		{
			get { return _Log_Posted_Feb_1; }
			set { _Log_Posted_Feb_1 = value; }
		}

		/// <summary>
		/// Gets or sets the OSHA_Recordable value.
		/// </summary>
		public int? OSHA_Recordable
		{
			get { return _OSHA_Recordable; }
			set { _OSHA_Recordable = value; }
		}

		/// <summary>
		/// Gets or sets the Lost_Work_Days value.
		/// </summary>
		public int? Lost_Work_Days
		{
			get { return _Lost_Work_Days; }
			set { _Lost_Work_Days = value; }
		}

		/// <summary>
		/// Gets or sets the Restsricted_Work_Days value.
		/// </summary>
		public int? Restsricted_Work_Days
		{
			get { return _Restsricted_Work_Days; }
			set { _Restsricted_Work_Days = value; }
		}

		/// <summary>
		/// Gets or sets the Total_Associates value.
		/// </summary>
		public int? Total_Associates
		{
			get { return _Total_Associates; }
			set { _Total_Associates = value; }
		}

		/// <summary>
		/// Gets or sets the Comments value.
		/// </summary>
		public string Comments
		{
			get { return _Comments; }
			set { _Comments = value; }
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
		/// Initializes a new instance of the clsPM_Complaince_Reporting_OSHA class with default value.
		/// </summary>
		public clsPM_Complaince_Reporting_OSHA() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Complaince_Reporting_OSHA class based on Primary Key.
		/// </summary>
		public clsPM_Complaince_Reporting_OSHA(decimal pK_PM_Compliance_Reporting_OSHA) 
		{
			DataTable dtPM_Complaince_Reporting_OSHA = SelectByPK(pK_PM_Compliance_Reporting_OSHA).Tables[0];

			if (dtPM_Complaince_Reporting_OSHA.Rows.Count == 1)
			{
				 SetValue(dtPM_Complaince_Reporting_OSHA.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_Complaince_Reporting_OSHA class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Complaince_Reporting_OSHA) 
		{
				if (drPM_Complaince_Reporting_OSHA["PK_PM_Compliance_Reporting_OSHA"] == DBNull.Value)
					this._PK_PM_Compliance_Reporting_OSHA = null;
				else
					this._PK_PM_Compliance_Reporting_OSHA = (decimal?)drPM_Complaince_Reporting_OSHA["PK_PM_Compliance_Reporting_OSHA"];

				if (drPM_Complaince_Reporting_OSHA["FK_PM_Complaince_Reporting"] == DBNull.Value)
					this._FK_PM_Complaince_Reporting = null;
				else
					this._FK_PM_Complaince_Reporting = (decimal?)drPM_Complaince_Reporting_OSHA["FK_PM_Complaince_Reporting"];

				if (drPM_Complaince_Reporting_OSHA["Date_Completed"] == DBNull.Value)
					this._Date_Completed = null;
				else
					this._Date_Completed = (DateTime?)drPM_Complaince_Reporting_OSHA["Date_Completed"];

				if (drPM_Complaince_Reporting_OSHA["Log_Posted_Feb_1"] == DBNull.Value)
					this._Log_Posted_Feb_1 = null;
				else
					this._Log_Posted_Feb_1 = (string)drPM_Complaince_Reporting_OSHA["Log_Posted_Feb_1"];

				if (drPM_Complaince_Reporting_OSHA["OSHA_Recordable"] == DBNull.Value)
					this._OSHA_Recordable = null;
				else
					this._OSHA_Recordable = (int?)drPM_Complaince_Reporting_OSHA["OSHA_Recordable"];

				if (drPM_Complaince_Reporting_OSHA["Lost_Work_Days"] == DBNull.Value)
					this._Lost_Work_Days = null;
				else
					this._Lost_Work_Days = (int?)drPM_Complaince_Reporting_OSHA["Lost_Work_Days"];

				if (drPM_Complaince_Reporting_OSHA["Restsricted_Work_Days"] == DBNull.Value)
					this._Restsricted_Work_Days = null;
				else
					this._Restsricted_Work_Days = (int?)drPM_Complaince_Reporting_OSHA["Restsricted_Work_Days"];

				if (drPM_Complaince_Reporting_OSHA["Total_Associates"] == DBNull.Value)
					this._Total_Associates = null;
				else
					this._Total_Associates = (int?)drPM_Complaince_Reporting_OSHA["Total_Associates"];

				if (drPM_Complaince_Reporting_OSHA["Comments"] == DBNull.Value)
					this._Comments = null;
				else
					this._Comments = (string)drPM_Complaince_Reporting_OSHA["Comments"];

				if (drPM_Complaince_Reporting_OSHA["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Complaince_Reporting_OSHA["Updated_By"];

				if (drPM_Complaince_Reporting_OSHA["Updated_Date"] == DBNull.Value)
					this._Updated_Date = null;
				else
					this._Updated_Date = (DateTime?)drPM_Complaince_Reporting_OSHA["Updated_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Complaince_Reporting_OSHA table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Complaince_Reporting_OSHAInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Complaince_Reporting", DbType.Decimal, this._FK_PM_Complaince_Reporting);
			
			db.AddInParameter(dbCommand, "Date_Completed", DbType.DateTime, this._Date_Completed);
			
			if (string.IsNullOrEmpty(this._Log_Posted_Feb_1))
				db.AddInParameter(dbCommand, "Log_Posted_Feb_1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Log_Posted_Feb_1", DbType.String, this._Log_Posted_Feb_1);
			
			db.AddInParameter(dbCommand, "OSHA_Recordable", DbType.Int32, this._OSHA_Recordable);
			
			db.AddInParameter(dbCommand, "Lost_Work_Days", DbType.Int32, this._Lost_Work_Days);
			
			db.AddInParameter(dbCommand, "Restsricted_Work_Days", DbType.Int32, this._Restsricted_Work_Days);
			
			db.AddInParameter(dbCommand, "Total_Associates", DbType.Int32, this._Total_Associates);
			
			if (string.IsNullOrEmpty(this._Comments))
				db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
			
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
		/// Selects a single record from the PM_Complaince_Reporting_OSHA table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Compliance_Reporting_OSHA)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Complaince_Reporting_OSHASelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Compliance_Reporting_OSHA", DbType.Decimal, pK_PM_Compliance_Reporting_OSHA);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Complaince_Reporting_OSHA table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Complaince_Reporting_OSHASelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Complaince_Reporting_OSHA table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Complaince_Reporting_OSHAUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Compliance_Reporting_OSHA", DbType.Decimal, this._PK_PM_Compliance_Reporting_OSHA);
			
			db.AddInParameter(dbCommand, "FK_PM_Complaince_Reporting", DbType.Decimal, this._FK_PM_Complaince_Reporting);
			
			db.AddInParameter(dbCommand, "Date_Completed", DbType.DateTime, this._Date_Completed);
			
			if (string.IsNullOrEmpty(this._Log_Posted_Feb_1))
				db.AddInParameter(dbCommand, "Log_Posted_Feb_1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Log_Posted_Feb_1", DbType.String, this._Log_Posted_Feb_1);
			
			db.AddInParameter(dbCommand, "OSHA_Recordable", DbType.Int32, this._OSHA_Recordable);
			
			db.AddInParameter(dbCommand, "Lost_Work_Days", DbType.Int32, this._Lost_Work_Days);
			
			db.AddInParameter(dbCommand, "Restsricted_Work_Days", DbType.Int32, this._Restsricted_Work_Days);
			
			db.AddInParameter(dbCommand, "Total_Associates", DbType.Int32, this._Total_Associates);
			
			if (string.IsNullOrEmpty(this._Comments))
				db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Complaince_Reporting_OSHA table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Compliance_Reporting_OSHA)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Complaince_Reporting_OSHADeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Compliance_Reporting_OSHA", DbType.Decimal, pK_PM_Compliance_Reporting_OSHA);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the PM_Complaince_Reporting_OSHA table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal fK_PM_Complaince_Reporting)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Complaince_Reporting_OSHASelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Complaince_Reporting", DbType.Decimal, fK_PM_Complaince_Reporting);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
