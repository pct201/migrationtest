using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for EPM_Identification_Building table.
    /// </summary>
    public sealed class clsEPM_Identification_Building
    {

        #region Private variables used to hold the property values

        private decimal? _PK_EPM_Identification_Building;
        private decimal? _FK_EPM_Identification;
        private decimal? _FK_Building;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_EPM_Identification_Building value.
        /// </summary>
        public decimal? PK_EPM_Identification_Building
        {
            get { return _PK_EPM_Identification_Building; }
            set { _PK_EPM_Identification_Building = value; }
        }

        /// <summary>
        /// Gets or sets the FK_EPM_Identification value.
        /// </summary>
        public decimal? FK_EPM_Identification
        {
            get { return _FK_EPM_Identification; }
            set { _FK_EPM_Identification = value; }
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


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_Identification_Building class with default value.
        /// </summary>
        public clsEPM_Identification_Building()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_Identification_Building class based on Primary Key.
        /// </summary>
        public clsEPM_Identification_Building(decimal pK_EPM_Identification_Building)
        {
            DataTable dtEPM_Identification_Building = SelectByPK(pK_EPM_Identification_Building).Tables[0];

            if (dtEPM_Identification_Building.Rows.Count == 1)
            {
                SetValue(dtEPM_Identification_Building.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsEPM_Identification_Building class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drEPM_Identification_Building)
        {
            if (drEPM_Identification_Building["PK_EPM_Identification_Building"] == DBNull.Value)
                this._PK_EPM_Identification_Building = null;
            else
                this._PK_EPM_Identification_Building = (decimal?)drEPM_Identification_Building["PK_EPM_Identification_Building"];

            if (drEPM_Identification_Building["FK_EPM_Identification"] == DBNull.Value)
                this._FK_EPM_Identification = null;
            else
                this._FK_EPM_Identification = (decimal?)drEPM_Identification_Building["FK_EPM_Identification"];

            if (drEPM_Identification_Building["FK_Building"] == DBNull.Value)
                this._FK_Building = null;
            else
                this._FK_Building = (decimal?)drEPM_Identification_Building["FK_Building"];

            if (drEPM_Identification_Building["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drEPM_Identification_Building["Updated_By"];

            if (drEPM_Identification_Building["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drEPM_Identification_Building["Update_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the EPM_Identification_Building table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Identification_BuildingInsert");


            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, this._FK_Building);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the EPM_Identification_Building table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_EPM_Identification_Building)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Identification_BuildingSelectByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Identification_Building", DbType.Decimal, pK_EPM_Identification_Building);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the EPM_Identification_Building table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Identification_BuildingSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the EPM_Identification_Building table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Identification_BuildingUpdate");


            db.AddInParameter(dbCommand, "PK_EPM_Identification_Building", DbType.Decimal, this._PK_EPM_Identification_Building);

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, this._FK_Building);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the EPM_Identification_Building table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_EPM_Identification_Building)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Identification_BuildingDeleteByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Identification_Building", DbType.Decimal, pK_EPM_Identification_Building);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the EPM_Identification_Building table by a composite Foreign key.
        /// </summary>
        public static void DeleteByFK(decimal FK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Identification_BuildingDeleteByFK");

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, FK_EPM_Identification);

            db.ExecuteNonQuery(dbCommand);
        }


        /// <summary>
        /// Selects a single record from the EPM_Identification_Building table by a Foreign key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal FK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Identification_BuildingSelectByFK");

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, FK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetDistinctEquipments(string FK_Building)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetEquipmentForProjectmanagement");

            db.AddInParameter(dbCommand, "FK_Building", DbType.String, FK_Building);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
