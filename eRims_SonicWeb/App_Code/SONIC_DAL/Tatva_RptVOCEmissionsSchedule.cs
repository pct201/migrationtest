using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptVOCEmissionsSchedule table.
	/// </summary>
    public sealed class Tatva_RptVOCEmissionsSchedule : Tatva_ReportSchedule
	{

		#region Private variables used to hold the property values

		private decimal? _PK_ID;
		private decimal? _FK_Schedule;
		private string _Location;
        private DateTime _Start_Date;
        private DateTime _End_Date;

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
		/// Gets or sets the Location value.
		/// </summary>
		public string Location
		{
			get { return _Location; }
			set { _Location = value; }
		}

        /// <summary> 
        /// Gets or sets the Start_Date value.
        /// </summary>
        public DateTime Start_Date
        {
            get { return _Start_Date; }
            set { _Start_Date = value; }
        }

        /// <summary> 
        /// Gets or sets the End_Date value.
        /// </summary>
        public DateTime End_Date
        {
            get { return _End_Date; }
            set { _End_Date = value; }
        }


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Tatva_RptVOCEmissionsSchedule class with default value.
		/// </summary>
		public Tatva_RptVOCEmissionsSchedule() 
		{
            this._FK_Schedule = -1;
            this._Location = null;
            this._PK_ID = -1;
            this._Start_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._End_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Tatva_RptVOCEmissionsSchedule class based on Primary Key.
		/// </summary>
		public Tatva_RptVOCEmissionsSchedule(decimal pK_ID) 
		{
			DataTable dtTatva_RptVOCEmissionsSchedule = SelectByPK(pK_ID).Tables[0];

            if (dtTatva_RptVOCEmissionsSchedule.Rows.Count == 1)
            {
                SetValue(dtTatva_RptVOCEmissionsSchedule.Rows[0]);

            }
            else
            {
                this._FK_Schedule = -1;
                this._Location = null;
                this._PK_ID = -1;
                this._Start_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._End_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }
		}


		/// <summary>
		/// Initializes a new instance of the Tatva_RptVOCEmissionsSchedule class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drTatva_RptVOCEmissionsSchedule) 
		{
				if (drTatva_RptVOCEmissionsSchedule["PK_ID"] == DBNull.Value)
					this._PK_ID = null;
				else
					this._PK_ID = (decimal?)drTatva_RptVOCEmissionsSchedule["PK_ID"];

				if (drTatva_RptVOCEmissionsSchedule["FK_Schedule"] == DBNull.Value)
					this._FK_Schedule = null;
				else
					this._FK_Schedule = (decimal?)drTatva_RptVOCEmissionsSchedule["FK_Schedule"];

				if (drTatva_RptVOCEmissionsSchedule["Location"] == DBNull.Value)
					this._Location = null;
				else
					this._Location = (string)drTatva_RptVOCEmissionsSchedule["Location"];

                if (drTatva_RptVOCEmissionsSchedule["Start_Date"] == DBNull.Value)
                    this._Start_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                else
                    this._Start_Date = (DateTime)drTatva_RptVOCEmissionsSchedule["Start_Date"];

                if (drTatva_RptVOCEmissionsSchedule["End_Date"] == DBNull.Value)
                    this._End_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                else
                    this._End_Date = (DateTime)drTatva_RptVOCEmissionsSchedule["End_Date"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the Tatva_RptVOCEmissionsSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptVOCEmissionsScheduleInsert");

            this._FK_Schedule = base.Insert();
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			if (string.IsNullOrEmpty(this._Location))
				db.AddInParameter(dbCommand, "Location", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);

            db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);
            db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptVOCEmissionsSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptVOCEmissionsScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptVOCEmissionsSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptVOCEmissionsScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptVOCEmissionsSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptVOCEmissionsScheduleUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			if (string.IsNullOrEmpty(this._Location))
				db.AddInParameter(dbCommand, "Location", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);

            db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);
            db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptVOCEmissionsSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptVOCEmissionsScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
