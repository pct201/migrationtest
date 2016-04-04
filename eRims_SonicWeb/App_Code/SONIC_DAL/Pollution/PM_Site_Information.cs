using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for PM_Site_Information table.
    /// </summary>
    public sealed class PM_Site_Information
    {

        #region Private variables used to hold the property values

        private decimal? _PK_PM_Site_Information;
        private decimal? _FK_LU_Location;
        private decimal? _FK_Building;
        private decimal? _FK_County;
        private decimal? _FK_LU_SIC;
        private decimal? _FK_LU_NAICS;
        private decimal? _Number_Of_Employees;
        private decimal? _Number_Of_Shift;
        private int? _Days_Per_Week;
        private int? _Weeks_Per_Year;
        private int? _Facility_Construction_Completion_Year;
        private string _Owner_Of_Facility;
        private string _Latitude;
        private string _Longitude;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private Guid _AuditID;
        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_PM_Site_Information value.
        /// </summary>
        public decimal? PK_PM_Site_Information
        {
            get { return _PK_PM_Site_Information; }
            set { _PK_PM_Site_Information = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Location value.
        /// </summary>
        public decimal? FK_LU_Location
        {
            get { return _FK_LU_Location; }
            set { _FK_LU_Location = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Building value.
        /// </summary>
        public decimal? FK_Building
        {
            get { return _FK_Building; }
            set { _FK_Building = value; }
        }

        /// <summary>
        /// Gets or sets the FK_County value.
        /// </summary>
        public decimal? FK_County
        {
            get { return _FK_County; }
            set { _FK_County = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_SIC value.
        /// </summary>
        public decimal? FK_LU_SIC
        {
            get { return _FK_LU_SIC; }
            set { _FK_LU_SIC = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_NAICS value.
        /// </summary>
        public decimal? FK_LU_NAICS
        {
            get { return _FK_LU_NAICS; }
            set { _FK_LU_NAICS = value; }
        }

        /// <summary>
        /// Gets or sets the Number_Of_Employees value.
        /// </summary>
        public decimal? Number_Of_Employees
        {
            get { return _Number_Of_Employees; }
            set { _Number_Of_Employees = value; }
        }

        /// <summary>
        /// Gets or sets the Number_Of_Shift value.
        /// </summary>
        public decimal? Number_Of_Shift
        {
            get { return _Number_Of_Shift; }
            set { _Number_Of_Shift = value; }
        }

        /// <summary>
        /// Gets or sets the Days_Per_Week value.
        /// </summary>
        public int? Days_Per_Week
        {
            get { return _Days_Per_Week; }
            set { _Days_Per_Week = value; }
        }

        /// <summary>
        /// Gets or sets the Weeks_Per_Year value.
        /// </summary>
        public int? Weeks_Per_Year
        {
            get { return _Weeks_Per_Year; }
            set { _Weeks_Per_Year = value; }
        }

        /// <summary>
        /// Gets or sets the Facility_Construction_Completion_Year value.
        /// </summary>
        public int? Facility_Construction_Completion_Year
        {
            get { return _Facility_Construction_Completion_Year; }
            set { _Facility_Construction_Completion_Year = value; }
        }

        /// <summary>
        /// Gets or sets the Owner_Of_Facility value.
        /// </summary>
        public string Owner_Of_Facility
        {
            get { return _Owner_Of_Facility; }
            set { _Owner_Of_Facility = value; }
        }

        /// <summary>
        /// Gets or sets the Latitude value.
        /// </summary>
        public string Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }

        /// <summary>
        /// Gets or sets the Longitude value.
        /// </summary>
        public string Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
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
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime? Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }

        /// <summary>
        /// Gets or sets the AuditID value.
        /// </summary>
        public Guid AuditID
        {
            get { return _AuditID; }
            set { _AuditID = value; }
        }
        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the PM_Site_Information class with default value.
        /// </summary>
        public PM_Site_Information()
        {

            this._PK_PM_Site_Information = null;
            this._FK_LU_Location = null;
            this._FK_Building = null;
            this._FK_County = null;
            this._FK_LU_SIC = null;
            this._FK_LU_NAICS = null;
            this._Number_Of_Employees = null;
            this._Number_Of_Shift = null;
            this._Days_Per_Week = null;
            this._Weeks_Per_Year = null;
            this._Facility_Construction_Completion_Year = null;
            this._Owner_Of_Facility = null;
            this._Latitude = null;
            this._Longitude = null;
            this._Updated_By = null;
            this._Update_Date = null;
            this._AuditID = Guid.NewGuid();
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the PM_Site_Information class based on Primary Key.
        /// </summary>
        public PM_Site_Information(decimal pK_PM_Site_Information, bool SelectByLocation)
        {
            DataTable dtPM_Site_Information = null;

            if (SelectByLocation)
                dtPM_Site_Information = SelectByFKLocation(pK_PM_Site_Information).Tables[0];
            else
                dtPM_Site_Information = SelectByPK(pK_PM_Site_Information).Tables[0];

            if (dtPM_Site_Information.Rows.Count == 1)
            {
                DataRow drPM_Site_Information = dtPM_Site_Information.Rows[0];
                if (drPM_Site_Information["PK_PM_Site_Information"] == DBNull.Value)
                    this._PK_PM_Site_Information = null;
                else
                    this._PK_PM_Site_Information = (decimal?)drPM_Site_Information["PK_PM_Site_Information"];

                if (drPM_Site_Information["FK_LU_Location"] == DBNull.Value)
                    this._FK_LU_Location = null;
                else
                    this._FK_LU_Location = (decimal?)drPM_Site_Information["FK_LU_Location"];

                if (drPM_Site_Information["FK_Building"] == DBNull.Value)
                    this._FK_Building = null;
                else
                    this._FK_Building = (decimal?)drPM_Site_Information["FK_Building"];

                if (drPM_Site_Information["FK_County"] == DBNull.Value)
                    this._FK_County = null;
                else
                    this._FK_County = (decimal?)drPM_Site_Information["FK_County"];

                if (drPM_Site_Information["FK_LU_SIC"] == DBNull.Value)
                    this._FK_LU_SIC = null;
                else
                    this._FK_LU_SIC = (decimal?)drPM_Site_Information["FK_LU_SIC"];

                if (drPM_Site_Information["FK_LU_NAICS"] == DBNull.Value)
                    this._FK_LU_NAICS = null;
                else
                    this._FK_LU_NAICS = (decimal?)drPM_Site_Information["FK_LU_NAICS"];

                if (drPM_Site_Information["Number_Of_Employees"] == DBNull.Value)
                    this._Number_Of_Employees = null;
                else
                    this._Number_Of_Employees = (decimal?)drPM_Site_Information["Number_Of_Employees"];

                if (drPM_Site_Information["Number_Of_Shift"] == DBNull.Value)
                    this._Number_Of_Shift = null;
                else
                    this._Number_Of_Shift = (decimal?)drPM_Site_Information["Number_Of_Shift"];

                if (drPM_Site_Information["Days_Per_Week"] == DBNull.Value)
                    this._Days_Per_Week = null;
                else
                    this._Days_Per_Week = (int?)drPM_Site_Information["Days_Per_Week"];

                if (drPM_Site_Information["Weeks_Per_Year"] == DBNull.Value)
                    this._Weeks_Per_Year = null;
                else
                    this._Weeks_Per_Year = (int?)drPM_Site_Information["Weeks_Per_Year"];

                if (drPM_Site_Information["Facility_Construction_Completion_Year"] == DBNull.Value)
                    this._Facility_Construction_Completion_Year = null;
                else
                    this._Facility_Construction_Completion_Year = (int?)drPM_Site_Information["Facility_Construction_Completion_Year"];

                if (drPM_Site_Information["Owner_Of_Facility"] == DBNull.Value)
                    this._Owner_Of_Facility = null;
                else
                    this._Owner_Of_Facility = (string)drPM_Site_Information["Owner_Of_Facility"];

                if (drPM_Site_Information["Latitude"] == DBNull.Value)
                    this._Latitude = null;
                else
                    this._Latitude = (string)drPM_Site_Information["Latitude"];

                if (drPM_Site_Information["Longitude"] == DBNull.Value)
                    this._Longitude = null;
                else
                    this._Longitude = (string)drPM_Site_Information["Longitude"];

                if (drPM_Site_Information["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drPM_Site_Information["Updated_By"];

                if (drPM_Site_Information["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drPM_Site_Information["Update_Date"];

            }
            else
            {
                this._PK_PM_Site_Information = null;
                this._FK_LU_Location = null;
                this._FK_Building = null;
                this._FK_County = null;
                this._FK_LU_SIC = null;
                this._FK_LU_NAICS = null;
                this._Number_Of_Employees = null;
                this._Number_Of_Shift = null;
                this._Days_Per_Week = null;
                this._Weeks_Per_Year = null;
                this._Facility_Construction_Completion_Year = null;
                this._Owner_Of_Facility = null;
                this._Latitude = null;
                this._Longitude = null;
                this._Updated_By = null;
                this._Update_Date = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the PM_Site_Information table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Site_InformationInsert");


            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

            db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, this._FK_Building);

            db.AddInParameter(dbCommand, "FK_County", DbType.Decimal, this._FK_County);

            db.AddInParameter(dbCommand, "FK_LU_SIC", DbType.Decimal, this._FK_LU_SIC);

            db.AddInParameter(dbCommand, "FK_LU_NAICS", DbType.Decimal, this._FK_LU_NAICS);

            db.AddInParameter(dbCommand, "Number_Of_Employees", DbType.Decimal, this._Number_Of_Employees);

            db.AddInParameter(dbCommand, "Number_Of_Shift", DbType.Decimal, this._Number_Of_Shift);

            db.AddInParameter(dbCommand, "Days_Per_Week", DbType.Int32, this._Days_Per_Week);

            db.AddInParameter(dbCommand, "Weeks_Per_Year", DbType.Int32, this._Weeks_Per_Year);

            db.AddInParameter(dbCommand, "Facility_Construction_Completion_Year", DbType.Int16, this._Facility_Construction_Completion_Year);

            if (string.IsNullOrEmpty(this._Owner_Of_Facility))
                db.AddInParameter(dbCommand, "Owner_Of_Facility", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Owner_Of_Facility", DbType.String, this._Owner_Of_Facility);

            if (string.IsNullOrEmpty(this._Latitude))
                db.AddInParameter(dbCommand, "Latitude", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Latitude", DbType.String, this._Latitude);

            if (string.IsNullOrEmpty(this._Longitude))
                db.AddInParameter(dbCommand, "Longitude", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Longitude", DbType.String, this._Longitude);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "AuditID", DbType.Guid, this._AuditID);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the PM_Site_Information table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Site_InformationSelectByPK");

            db.AddInParameter(dbCommand, "PK_PM_Site_Information", DbType.Decimal, pK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the PM_Site_Information table by a FK Location.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByFKLocation(decimal fK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Site_InformationSelectByFK");

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, fK_LU_Location);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the PM_Site_Information table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Site_InformationSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the PM_Site_Information table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Site_InformationUpdate");


            db.AddInParameter(dbCommand, "PK_PM_Site_Information", DbType.Decimal, this._PK_PM_Site_Information);

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

            db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, this._FK_Building);

            db.AddInParameter(dbCommand, "FK_County", DbType.Decimal, this._FK_County);

            db.AddInParameter(dbCommand, "FK_LU_SIC", DbType.Decimal, this._FK_LU_SIC);

            db.AddInParameter(dbCommand, "FK_LU_NAICS", DbType.Decimal, this._FK_LU_NAICS);

            db.AddInParameter(dbCommand, "Number_Of_Employees", DbType.Decimal, this._Number_Of_Employees);

            db.AddInParameter(dbCommand, "Number_Of_Shift", DbType.Decimal, this._Number_Of_Shift);

            db.AddInParameter(dbCommand, "Days_Per_Week", DbType.Int32, this._Days_Per_Week);

            db.AddInParameter(dbCommand, "Weeks_Per_Year", DbType.Int32, this._Weeks_Per_Year);

            db.AddInParameter(dbCommand, "Facility_Construction_Completion_Year", DbType.Int16, this._Facility_Construction_Completion_Year);

            if (string.IsNullOrEmpty(this._Owner_Of_Facility))
                db.AddInParameter(dbCommand, "Owner_Of_Facility", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Owner_Of_Facility", DbType.String, this._Owner_Of_Facility);

            if (string.IsNullOrEmpty(this._Latitude))
                db.AddInParameter(dbCommand, "Latitude", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Latitude", DbType.String, this._Latitude);

            if (string.IsNullOrEmpty(this._Longitude))
                db.AddInParameter(dbCommand, "Longitude", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Longitude", DbType.String, this._Longitude);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "AuditID", DbType.Guid, this._AuditID);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the PM_Site_Information table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Site_InformationDeleteByPK");

            db.AddInParameter(dbCommand, "PK_PM_Site_Information", DbType.Decimal, pK_PM_Site_Information);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects all grids for site information
        /// </summary>
        /// <param name="pK_PM_Site_Information"></param>
        /// <returns></returns>
        public static DataSet SelectAllGrids(decimal pK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Site_InformationSelectAllGrids");

            db.AddInParameter(dbCommand, "PK_PM_Site_Information", DbType.Decimal, pK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Site_Information_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_Site_Information", DbType.Decimal, pK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByBuildLoc(decimal fK_LU_Location, decimal fK_Building)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Site_InfoSelectByBuildLoc");

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, fK_LU_Location);
            db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, fK_Building);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Pk of EPM_Identification For Insert data in EPM_Attachment from Attachment of PM_Site_Info
        /// </summary>
        /// <param name="FK_Building"></param>
        /// <returns></returns>
        public static DataSet GetPK_EPM_Identification(decimal FK_Building)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetPK_EPM_IdentificationForPM_Site_Info");

            db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, FK_Building);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Pk of EPM_Identification For Insert data in EPM_Attachment from Attachment of PM_Site_Info
        /// </summary>
        /// <param name="FK_Building"></param>
        /// <returns></returns>
        public static int SelectByLocationAndBuilding(decimal FK_LU_Location , decimal  FK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Site_InformationSelectByLocationAndBuilding");

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Decimal, FK_Building_ID);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

    }
}
