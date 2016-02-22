using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for table Property_Claims_Building
    /// </summary>
    public sealed class Property_Claims_Building
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Property_Claims_Building_ID;
        private decimal? _FK_Property_Claims_ID;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private string _State;
        private string _Zip;
        private string _Occupancy;
        private decimal? _Updated_By;
        private DateTime? _Updated_Date;
        private DateTime? _Created_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Property_Claims_Building_ID value.
        /// </summary>
        public decimal? PK_Property_Claims_Building_ID
        {
            get { return _PK_Property_Claims_Building_ID; }
            set { _PK_Property_Claims_Building_ID = value; }
        }
        
        /// <summary>
        /// Gets or sets the FK_Property_Claims_ID value.
        /// </summary>
        public decimal? FK_Property_Claims_ID
        {
            get { return _FK_Property_Claims_ID; }
            set { _FK_Property_Claims_ID = value; }
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
        public decimal? Updated_By
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

        /// <summary>
        /// Gets or sets the Created_Date value.
        /// </summary>
        public DateTime? Created_Date
        {
            get { return _Created_Date; }
            set { _Created_Date = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Property_Claims_Building class with default value.
        /// </summary>
        public Property_Claims_Building()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary> 
        /// Initializes a new instance of the Property_FR_Building class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Property_Claims_Building(decimal PK)
        {
            DataTable dtProperty_FR_Building = SelectByPK(PK).Tables[0];
            if (dtProperty_FR_Building.Rows.Count > 0)
            {
                DataRow drProperty_FR_Building = dtProperty_FR_Building.Rows[0];
                this._PK_Property_Claims_Building_ID = drProperty_FR_Building["PK_Property_Claims_Building_ID"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR_Building["PK_Property_Claims_Building_ID"]) : 0;
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
                this._PK_Property_Claims_Building_ID = -1;
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

        /// <summary>
        /// Selects a single record from the Property_Claims_Building table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Property_Claims_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_BuildingSelect");
            db.AddInParameter(dbCommand, "PK_Property_Claims_Building_ID", DbType.Decimal, pK_Property_Claims_Building_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Initializes a new instance of the Property_Claims_Building class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drProperty_Claims_Building)
        {
            if (drProperty_Claims_Building["PK_Property_Claims_Building_ID"] == DBNull.Value)
                this._PK_Property_Claims_Building_ID = null;
            else
                this._PK_Property_Claims_Building_ID = (decimal?)drProperty_Claims_Building["PK_Property_Claims_Building_ID"];

            if (drProperty_Claims_Building["FK_Property_Claims_ID"] == DBNull.Value)
                this._FK_Property_Claims_ID = null;
            else
                this._FK_Property_Claims_ID = (decimal?)drProperty_Claims_Building["FK_Property_Claims_ID"];

            if (drProperty_Claims_Building["Address_1"] == DBNull.Value)
                this._Address_1 = null;
            else
                this._Address_1 = (string)drProperty_Claims_Building["Address_1"];

            if (drProperty_Claims_Building["Address_2"] == DBNull.Value)
                this._Address_2 = null;
            else
                this._Address_2 = (string)drProperty_Claims_Building["Address_2"];

            if (drProperty_Claims_Building["City"] == DBNull.Value)
                this._City = null;
            else
                this._City = (string)drProperty_Claims_Building["City"];

            if (drProperty_Claims_Building["State"] == DBNull.Value)
                this._State = null;
            else
                this._State = (string)drProperty_Claims_Building["State"];

            if (drProperty_Claims_Building["Zip"] == DBNull.Value)
                this._Zip = null;
            else
                this._Zip = (string)drProperty_Claims_Building["Zip"];

            if (drProperty_Claims_Building["Occupancy"] == DBNull.Value)
                this._Occupancy = null;
            else
                this._Occupancy = (string)drProperty_Claims_Building["Occupancy"];

            if (drProperty_Claims_Building["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (decimal?)drProperty_Claims_Building["Updated_By"];

            if (drProperty_Claims_Building["Updated_Date"] == DBNull.Value)
                this._Updated_Date = null;
            else
                this._Updated_Date = (DateTime?)drProperty_Claims_Building["Updated_Date"];

            if (drProperty_Claims_Building["Created_Date"] == DBNull.Value)
                this._Created_Date = null;
            else
                this._Created_Date = (DateTime?)drProperty_Claims_Building["Created_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Property_Claims_Building table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_BuildingInsert");

            db.AddInParameter(dbCommand, "FK_Property_Claims_ID", DbType.Decimal, this._FK_Property_Claims_ID);

            if (string.IsNullOrEmpty(this._Address_1))
                db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);

            if (string.IsNullOrEmpty(this._Address_2))
                db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);

            if (string.IsNullOrEmpty(this._City))
                db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "City", DbType.String, this._City);

            if (string.IsNullOrEmpty(this._State))
                db.AddInParameter(dbCommand, "State", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "State", DbType.String, this._State);

            if (string.IsNullOrEmpty(this._Zip))
                db.AddInParameter(dbCommand, "Zip", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Zip", DbType.String, this._Zip);

            if (string.IsNullOrEmpty(this._Occupancy))
                db.AddInParameter(dbCommand, "Occupancy", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Occupancy", DbType.String, this._Occupancy);

            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);

            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);

            db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, DateTime.Now);

            return db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Property_Claims_Building table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_BuildingUpdate");

            db.AddInParameter(dbCommand, "PK_Property_Claims_Building_ID", DbType.Decimal, this._PK_Property_Claims_Building_ID);
            db.AddInParameter(dbCommand, "FK_Property_Claims_ID", DbType.Decimal, this._FK_Property_Claims_ID);
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
        /// Selects all records from the Property_Claims_Building table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_BuildingSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a All records from the Property_Building_Building table by a FK Property ID
        /// </summary>
        /// <returns>Datatable</returns>
        public static DataTable GetBuildingResultByPropertyID(decimal fK_Property_Claims_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_BuildingSelectByPropertyID");
            db.AddInParameter(dbCommand, "FK_Property_Claims_ID", DbType.Decimal, fK_Property_Claims_ID);
            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// Deletes a record from the Property_Claims_Witness table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Property_Claims_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_BuildingDelete");

            db.AddInParameter(dbCommand, "PK_Property_Claims_Building_ID", DbType.Decimal, pK_Property_Claims_Building_ID);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
