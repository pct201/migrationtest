using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptAssestDetailSchedule table.
	/// </summary>
    public sealed class Tatva_RptAssestDetailSchedule : Tatva_ReportSchedule
    {
        #region Fields


        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private string _Region;
        private string _Location;
        private string _Type;
        private string _Manufacutrer;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_ID value.
        /// </summary>
        public decimal PK_ID
        {
            get { return _PK_ID; }
            set { _PK_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Schedule value.
        /// </summary>
        public decimal FK_Schedule
        {
            get { return _FK_Schedule; }
            set { _FK_Schedule = value; }
        }


        /// <summary> 
        /// Gets or sets the Region value.
        /// </summary>
        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
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
        /// Gets or sets the Type value.
        /// </summary>
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Manufacutrer value.
        /// </summary>
        public string Manufacutrer
        {
            get { return _Manufacutrer; }
            set { _Manufacutrer = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Tatva_RptAssestDetailSchedule class. with the default value.
        /// </summary>
        public Tatva_RptAssestDetailSchedule()
        {

            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Region = "";
            this._Location = "";
            this._Type = "";
            this._Manufacutrer = "";

        }



        /// <summary> 
        /// Initializes a new instance of the Tatva_RptAssestDetailSchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptAssestDetailSchedule(decimal PK)
        {

            DataTable dtTatva_RptAssestDetailSchedule = SelectByPK(PK).Tables[0];

            if (dtTatva_RptAssestDetailSchedule.Rows.Count > 0)
            {

                DataRow drTatva_RptAssestDetailSchedule = dtTatva_RptAssestDetailSchedule.Rows[0];

                this._PK_ID = drTatva_RptAssestDetailSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptAssestDetailSchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptAssestDetailSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptAssestDetailSchedule["FK_Schedule"]) : 0;
                this._Region = Convert.ToString(drTatva_RptAssestDetailSchedule["Region"]);
                this._Location = Convert.ToString(drTatva_RptAssestDetailSchedule["Location"]);
                this._Type = Convert.ToString(drTatva_RptAssestDetailSchedule["Type"]);
                this._Manufacutrer = Convert.ToString(drTatva_RptAssestDetailSchedule["Manufacutrer"]);

            }

            else
            {

                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Region = "";
                this._Location = "";
                this._Type = "";
                this._Manufacutrer = "";

            }

        }



        #endregion


        #region Methods

        /// <summary>
		/// Inserts a record into the Tatva_RptAssestDetailSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            this._FK_Schedule = base.Insert();
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptAssestDetailScheduleInsert");

			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
			db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);
			db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
			db.AddInParameter(dbCommand, "Manufacutrer", DbType.String, this._Manufacutrer);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptAssestDetailSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptAssestDetailScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptAssestDetailSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptAssestDetailScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptAssestDetailSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptAssestDetailScheduleUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
			db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);
			db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
			db.AddInParameter(dbCommand, "Manufacutrer", DbType.String, this._Manufacutrer);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptAssestDetailSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptAssestDetailScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
		}

#endregion
    }
       
}
