using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Property_FR_Building table.
	/// </summary>
	public sealed class Property_FR_Building
    {

        #region Fields


        private decimal _PK_Property_FR_Building_ID;
        private decimal _FK_Property_FR_ID;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private string _State;
        private string _Zip;
        private string _Occupancy;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_Property_FR_Building_ID value.
        /// </summary>
        public decimal PK_Property_FR_Building_ID
        {
            get { return _PK_Property_FR_Building_ID; }
            set { _PK_Property_FR_Building_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Property_FR_ID value.
        /// </summary>
        public decimal FK_Property_FR_ID
        {
            get { return _FK_Property_FR_ID; }
            set { _FK_Property_FR_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Address_1 value.
        /// </summary>
        public string Address_1
        {
            get { return _Address_1; }
            set { _Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Address_2 value.
        /// </summary>
        public string Address_2
        {
            get { return _Address_2; }
            set { _Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the City value.
        /// </summary>
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }


        /// <summary> 
        /// Gets or sets the State value.
        /// </summary>
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }


        /// <summary> 
        /// Gets or sets the Zip value.
        /// </summary>
        public string Zip
        {
            get { return _Zip; }
            set { _Zip = value; }
        }


        /// <summary> 
        /// Gets or sets the Occupancy value.
        /// </summary>
        public string Occupancy
        {
            get { return _Occupancy; }
            set { _Occupancy = value; }
        }

        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public decimal Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        /// <summary> 
        /// Gets or sets the Updated_Date value.
        /// </summary>
        public DateTime Updated_Date
        {
            get { return _Updated_Date; }
            set { _Updated_Date = value; }
        }


        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Property_FR_Building class. with the default value.

        /// </summary>
        public Property_FR_Building()
        {

            this._PK_Property_FR_Building_ID = -1;
            this._FK_Property_FR_ID = -1;
            this._Address_1 = "";
            this._Address_2 = "";
            this._City = "";
            this._State = "";
            this._Zip = "";
            this._Occupancy = "";
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 
        /// Initializes a new instance of the Property_FR_Building class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Property_FR_Building(decimal PK)
        {

            DataTable dtProperty_FR_Building = SelectByPK(PK).Tables[0];

            if (dtProperty_FR_Building.Rows.Count > 0)
            {

                DataRow drProperty_FR_Building = dtProperty_FR_Building.Rows[0];

                this._PK_Property_FR_Building_ID = drProperty_FR_Building["PK_Property_FR_Building_ID"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR_Building["PK_Property_FR_Building_ID"]) : 0;
                this._FK_Property_FR_ID = drProperty_FR_Building["FK_Property_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR_Building["FK_Property_FR_ID"]) : 0;
                this._Address_1 = Convert.ToString(drProperty_FR_Building["Address_1"]);
                this._Address_2 = Convert.ToString(drProperty_FR_Building["Address_2"]);
                this._City = Convert.ToString(drProperty_FR_Building["City"]);
                this._State = Convert.ToString(drProperty_FR_Building["State"]);
                this._Zip = Convert.ToString(drProperty_FR_Building["Zip"]);
                this._Occupancy = Convert.ToString(drProperty_FR_Building["Occupancy"]);
                this._Updated_By = drProperty_FR_Building["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR_Building["Updated_By"]) : 0;
                this._Updated_Date = drProperty_FR_Building["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drProperty_FR_Building["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._PK_Property_FR_Building_ID = -1;
                this._FK_Property_FR_ID = -1;
                this._Address_1 = "";
                this._Address_2 = "";
                this._City = "";
                this._State = "";
                this._Zip = "";
                this._Occupancy = "";
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

        }



        #endregion

        #region Methods

        /// <summary>
		/// Inserts a record into the Property_FR_Building table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_FR_BuildingInsert");

			db.AddInParameter(dbCommand, "FK_Property_FR_ID", DbType.Decimal, this._FK_Property_FR_ID);
			db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			db.AddInParameter(dbCommand, "State", DbType.String, this._State);
			db.AddInParameter(dbCommand, "Zip", DbType.String, this._Zip);
			db.AddInParameter(dbCommand, "Occupancy", DbType.String, this._Occupancy);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Property_FR_Building table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_Property_FR_Building_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_FR_BuildingSelectByPK");

			db.AddInParameter(dbCommand, "PK_Property_FR_Building_ID", DbType.Decimal, pK_Property_FR_Building_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Property_FR_Building table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_FR_BuildingSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Property_FR_Building table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_FR_BuildingUpdate");

			db.AddInParameter(dbCommand, "PK_Property_FR_Building_ID", DbType.Decimal, this._PK_Property_FR_Building_ID);
			db.AddInParameter(dbCommand, "FK_Property_FR_ID", DbType.Decimal, this._FK_Property_FR_ID);
			db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			db.AddInParameter(dbCommand, "State", DbType.String, this._State);
			db.AddInParameter(dbCommand, "Zip", DbType.String, this._Zip);
			db.AddInParameter(dbCommand, "Occupancy", DbType.String, this._Occupancy);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Property_FR_Building table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Property_FR_Building_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_FR_BuildingDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Property_FR_Building_ID", DbType.Decimal, pK_Property_FR_Building_ID);

			db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a All record from the Property_FR_Building table by a FK Property ID
        /// </summary>
        /// <returns>Datatable</returns>
        public static DataTable GetBuildingResultByPropertyID(decimal FK_Property_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetBuildingResultByPropertyID");

            db.AddInParameter(dbCommand, "FK_Property_FR_ID", DbType.Decimal, FK_Property_FR_ID);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }
        #endregion
    }
}
