using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for table Facility_Construction_Inspection
    /// </summary>
    public sealed class Facility_Construction_Inspection
    {
        #region Private variables used to hold the property values

        private decimal? _PK_Facility_Construction_Inspection;
        private decimal? _FK_Facility_Construction_Project;
        private decimal? _FK_Building;
        private DateTime? _Inspection_Date;
        private decimal? _FK_Inspector;
        private string _Inspector_Table;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Facility_Construction_Inspection value.
        /// </summary>
        public decimal? PK_Facility_Construction_Inspection
        {
            get { return _PK_Facility_Construction_Inspection; }
            set { _PK_Facility_Construction_Inspection = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Facility_Construction_Project value.
        /// </summary>
        public decimal? FK_Facility_Construction_Project
        {
            get { return _FK_Facility_Construction_Project; }
            set { _FK_Facility_Construction_Project = value; }
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
        /// Gets or sets the Inspection_Date value.
        /// </summary>
        public DateTime? Inspection_Date
        {
            get { return _Inspection_Date; }
            set { _Inspection_Date = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Inspector value.
        /// </summary>
        public decimal? FK_Inspector
        {
            get { return _FK_Inspector; }
            set { _FK_Inspector = value; }
        }

        /// <summary>
        /// Gets or sets the Inspector_Table value.
        /// </summary>
        public string Inspector_Table
        {
            get { return _Inspector_Table; }
            set { _Inspector_Table = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Facility_Construction_Inspection class with default value.
        /// </summary>
        public Facility_Construction_Inspection()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Facility_Construction_Inspection class based on Primary Key.
        /// </summary>
        public Facility_Construction_Inspection(decimal pK_Facility_Construction_Inspection)
        {
            DataTable dtFacility_Construction_Inspection = Select(pK_Facility_Construction_Inspection).Tables[0];

            if (dtFacility_Construction_Inspection.Rows.Count == 1)
            {
                SetValue(dtFacility_Construction_Inspection.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the Facility_Construction_Inspection class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drFacility_Construction_Inspection)
        {
            if (drFacility_Construction_Inspection["PK_Facility_Construction_Inspection"] == DBNull.Value)
                this._PK_Facility_Construction_Inspection = null;
            else
                this._PK_Facility_Construction_Inspection = (decimal?)drFacility_Construction_Inspection["PK_Facility_Construction_Inspection"];

            if (drFacility_Construction_Inspection["FK_Facility_Construction_Project"] == DBNull.Value)
                this._FK_Facility_Construction_Project = null;
            else
                this._FK_Facility_Construction_Project = (decimal?)drFacility_Construction_Inspection["FK_Facility_Construction_Project"];

            if (drFacility_Construction_Inspection["FK_Building"] == DBNull.Value)
                this._FK_Building = null;
            else
                this._FK_Building = (decimal?)drFacility_Construction_Inspection["FK_Building"];

            if (drFacility_Construction_Inspection["Inspection_Date"] == DBNull.Value)
                this._Inspection_Date = null;
            else
                this._Inspection_Date = (DateTime?)drFacility_Construction_Inspection["Inspection_Date"];

            if (drFacility_Construction_Inspection["FK_Inspector"] == DBNull.Value)
                this._FK_Inspector = null;
            else
                this._FK_Inspector = (decimal?)drFacility_Construction_Inspection["FK_Inspector"];

            if (drFacility_Construction_Inspection["Inspector_Table"] == DBNull.Value)
                this._Inspector_Table = null;
            else
                this._Inspector_Table = (string)drFacility_Construction_Inspection["Inspector_Table"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Facility_Construction_Inspection table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_InspectionInsert");


            db.AddInParameter(dbCommand, "FK_Facility_Construction_Project", DbType.Decimal, this._FK_Facility_Construction_Project);

            db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, this._FK_Building);

            if (this._Inspection_Date.HasValue && this._Inspection_Date.Value == DateTime.MinValue)
                db.AddInParameter(dbCommand, "Inspection_Date", DbType.DateTime, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Inspection_Date", DbType.DateTime, this._Inspection_Date);

            db.AddInParameter(dbCommand, "FK_Inspector", DbType.Decimal, this._FK_Inspector);

            if (string.IsNullOrEmpty(this._Inspector_Table))
                db.AddInParameter(dbCommand, "Inspector_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Inspector_Table", DbType.String, this._Inspector_Table);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Facility_Construction_Inspection table.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet Select(decimal pK_Facility_Construction_Inspection)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_InspectionSelect");

            db.AddInParameter(dbCommand, "PK_Facility_Construction_Inspection", DbType.Decimal, pK_Facility_Construction_Inspection);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Facility_Construction_Inspection table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_InspectionSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Facility_Construction_Inspection table By Project Number.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByLocation(Int32 fK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_InspectionSelectByLocation");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, fK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Facility_Construction_Inspection table By Primary Key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPkInpsection(Int32 pK_Facility_Construction_Inspection)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_InspectionSelectByPKInspection");

            db.AddInParameter(dbCommand, "PK_Facility_Construction_Inspection", DbType.Decimal, pK_Facility_Construction_Inspection);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Facility_Construction_Inspection table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_InspectionUpdate");


            db.AddInParameter(dbCommand, "PK_Facility_Construction_Inspection", DbType.Decimal, this._PK_Facility_Construction_Inspection);

            db.AddInParameter(dbCommand, "FK_Facility_Construction_Project", DbType.Decimal, this._FK_Facility_Construction_Project);

            db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, this._FK_Building);

            if (this._Inspection_Date.HasValue && this._Inspection_Date.Value == DateTime.MinValue)
                db.AddInParameter(dbCommand, "Inspection_Date", DbType.DateTime, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Inspection_Date", DbType.DateTime, this._Inspection_Date);

            db.AddInParameter(dbCommand, "FK_Inspector", DbType.Decimal, this._FK_Inspector);

            if (string.IsNullOrEmpty(this._Inspector_Table))
                db.AddInParameter(dbCommand, "Inspector_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Inspector_Table", DbType.String, this._Inspector_Table);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Facility_Construction_Inspection table by a composite primary key.
        /// </summary>
        public static void Delete(decimal pK_Facility_Construction_Inspection)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_InspectionDelete");

            db.AddInParameter(dbCommand, "PK_Facility_Construction_Inspection", DbType.Decimal, pK_Facility_Construction_Inspection);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
