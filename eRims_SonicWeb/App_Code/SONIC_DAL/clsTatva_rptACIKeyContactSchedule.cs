using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_rptACIKeyContactSchedule table.
	/// </summary>
    public sealed class clsTatva_rptACIKeyContactSchedule : Tatva_ReportSchedule
	{

		#region Private variables used to hold the property values

		private decimal? _PK_ID;
		private decimal? _FK_Schedule;
		private string _DBA;
		private string _Job_Title;

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
		/// Gets or sets the DBA value.
		/// </summary>
		public string DBA
		{
			get { return _DBA; }
			set { _DBA = value; }
		}

		/// <summary>
		/// Gets or sets the Job_Title value.
		/// </summary>
		public string Job_Title
		{
			get { return _Job_Title; }
			set { _Job_Title = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsTatva_rptACIKeyContactSchedule class with default value.
		/// </summary>
		public clsTatva_rptACIKeyContactSchedule() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsTatva_rptACIKeyContactSchedule class based on Primary Key.
		/// </summary>
		public clsTatva_rptACIKeyContactSchedule(decimal pK_ID) 
		{
			DataTable dtTatva_rptACIKeyContactSchedule = SelectByPK(pK_ID).Tables[0];

			if (dtTatva_rptACIKeyContactSchedule.Rows.Count == 1)
			{
				 SetValue(dtTatva_rptACIKeyContactSchedule.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsTatva_rptACIKeyContactSchedule class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drTatva_rptACIKeyContactSchedule) 
		{
				if (drTatva_rptACIKeyContactSchedule["PK_ID"] == DBNull.Value)
					this._PK_ID = null;
				else
					this._PK_ID = (decimal?)drTatva_rptACIKeyContactSchedule["PK_ID"];

				if (drTatva_rptACIKeyContactSchedule["FK_Schedule"] == DBNull.Value)
					this._FK_Schedule = null;
				else
					this._FK_Schedule = (decimal?)drTatva_rptACIKeyContactSchedule["FK_Schedule"];

				if (drTatva_rptACIKeyContactSchedule["DBA"] == DBNull.Value)
					this._DBA = null;
				else
					this._DBA = (string)drTatva_rptACIKeyContactSchedule["DBA"];

				if (drTatva_rptACIKeyContactSchedule["Job_Title"] == DBNull.Value)
					this._Job_Title = null;
				else
					this._Job_Title = (string)drTatva_rptACIKeyContactSchedule["Job_Title"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Tatva_rptACIKeyContactSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptACIKeyContactScheduleInsert");

            this._FK_Schedule = base.Insert();
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			if (string.IsNullOrEmpty(this._DBA))
				db.AddInParameter(dbCommand, "DBA", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "DBA", DbType.String, this._DBA);
			
			if (string.IsNullOrEmpty(this._Job_Title))
				db.AddInParameter(dbCommand, "Job_Title", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Job_Title", DbType.String, this._Job_Title);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_rptACIKeyContactSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptACIKeyContactScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_rptACIKeyContactSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptACIKeyContactScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_rptACIKeyContactSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptACIKeyContactScheduleUpdate");

			
			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			if (string.IsNullOrEmpty(this._DBA))
				db.AddInParameter(dbCommand, "DBA", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "DBA", DbType.String, this._DBA);
			
			if (string.IsNullOrEmpty(this._Job_Title))
				db.AddInParameter(dbCommand, "Job_Title", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Job_Title", DbType.String, this._Job_Title);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_rptACIKeyContactSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptACIKeyContactScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
