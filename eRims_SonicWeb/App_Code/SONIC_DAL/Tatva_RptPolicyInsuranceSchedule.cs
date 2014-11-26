using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptPolicyInsuranceSchedule table.
	/// </summary>
	public sealed class Tatva_RptPolicyInsuranceSchedule : Tatva_ReportSchedule
	{

		#region Private variables used to hold the property values

		private decimal? _PK_ID;
		private decimal? _FK_Schedule;
		private int? _Policy_Year;
		private string _ProgramID;
		private string _PolicyType;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_ID value.
		/// </summary>
		public decimal? PK_ID
		{
			get { return _PK_ID; }
			set { _PK_ID = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Schedule value.
		/// </summary>
		public decimal? FK_Schedule
		{
			get { return _FK_Schedule; }
			set { _FK_Schedule = value; }
		}

		/// <summary>
		/// Gets or sets the Policy_Year value.
		/// </summary>
		public int? Policy_Year
		{
			get { return _Policy_Year; }
			set { _Policy_Year = value; }
		}

		/// <summary>
		/// Gets or sets the ProgramID value.
		/// </summary>
		public string ProgramID
		{
			get { return _ProgramID; }
			set { _ProgramID = value; }
		}

		/// <summary>
		/// Gets or sets the PolicyType value.
		/// </summary>
		public string PolicyType
		{
			get { return _PolicyType; }
			set { _PolicyType = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Tatva_RptPolicyInsuranceSchedule class with default value.
		/// </summary>
		public Tatva_RptPolicyInsuranceSchedule() 
		{

			this._PK_ID = null;
			this._FK_Schedule = null;
			this._Policy_Year = null;
			this._ProgramID = null;
			this._PolicyType = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Tatva_RptPolicyInsuranceSchedule class based on Primary Key.
		/// </summary>
		public Tatva_RptPolicyInsuranceSchedule(decimal pK_ID) 
		{
			DataTable dtTatva_RptPolicyInsuranceSchedule = SelectByPK(pK_ID).Tables[0];

			if (dtTatva_RptPolicyInsuranceSchedule.Rows.Count == 1)
			{
				DataRow drTatva_RptPolicyInsuranceSchedule = dtTatva_RptPolicyInsuranceSchedule.Rows[0];
				if (drTatva_RptPolicyInsuranceSchedule["PK_ID"] == DBNull.Value)
					this._PK_ID = null;
				else
					this._PK_ID = (decimal?)drTatva_RptPolicyInsuranceSchedule["PK_ID"];

				if (drTatva_RptPolicyInsuranceSchedule["FK_Schedule"] == DBNull.Value)
					this._FK_Schedule = null;
				else
					this._FK_Schedule = (decimal?)drTatva_RptPolicyInsuranceSchedule["FK_Schedule"];

				if (drTatva_RptPolicyInsuranceSchedule["Policy_Year"] == DBNull.Value)
					this._Policy_Year = null;
				else
					this._Policy_Year = (int?)drTatva_RptPolicyInsuranceSchedule["Policy_Year"];

				if (drTatva_RptPolicyInsuranceSchedule["ProgramID"] == DBNull.Value)
					this._ProgramID = null;
				else
					this._ProgramID = (string)drTatva_RptPolicyInsuranceSchedule["ProgramID"];

				if (drTatva_RptPolicyInsuranceSchedule["PolicyType"] == DBNull.Value)
					this._PolicyType = null;
				else
					this._PolicyType = (string)drTatva_RptPolicyInsuranceSchedule["PolicyType"];

			}
			else
			{
				this._PK_ID = null;
				this._FK_Schedule = null;
				this._Policy_Year = null;
				this._ProgramID = null;
				this._PolicyType = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the Tatva_RptPolicyInsuranceSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptPolicyInsuranceScheduleInsert");

            this._FK_Schedule = base.Insert();

			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			db.AddInParameter(dbCommand, "Policy_Year", DbType.Int32, this._Policy_Year);
			
			if (string.IsNullOrEmpty(this._ProgramID))
				db.AddInParameter(dbCommand, "ProgramID", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ProgramID", DbType.String, this._ProgramID);
			
			if (string.IsNullOrEmpty(this._PolicyType))
				db.AddInParameter(dbCommand, "PolicyType", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "PolicyType", DbType.String, this._PolicyType);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptPolicyInsuranceSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptPolicyInsuranceScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptPolicyInsuranceSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptPolicyInsuranceScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptPolicyInsuranceSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptPolicyInsuranceScheduleUpdate");

			
			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			db.AddInParameter(dbCommand, "Policy_Year", DbType.Int32, this._Policy_Year);
			
			if (string.IsNullOrEmpty(this._ProgramID))
				db.AddInParameter(dbCommand, "ProgramID", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ProgramID", DbType.String, this._ProgramID);
			
			if (string.IsNullOrEmpty(this._PolicyType))
				db.AddInParameter(dbCommand, "PolicyType", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "PolicyType", DbType.String, this._PolicyType);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptPolicyInsuranceSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptPolicyInsuranceScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
