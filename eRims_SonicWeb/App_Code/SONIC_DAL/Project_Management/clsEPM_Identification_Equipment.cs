using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for EPM_Identification_Equipment table.
    /// </summary>
    public sealed class clsEPM_Identification_Equipment
    {

        #region Private variables used to hold the property values

        private decimal? _PK_EPM_Identification_Equipment;
        private decimal? _FK_EPM_Identification;
        private decimal? _FK_LU_Eqipment_Type_Pollution;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_EPM_Identification_Equipment value.
        /// </summary>
        public decimal? PK_EPM_Identification_Equipment
        {
            get { return _PK_EPM_Identification_Equipment; }
            set { _PK_EPM_Identification_Equipment = value; }
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
        /// Gets or sets the FK_LU_Eqipment_Type_Pollution value.
        /// </summary>
        public decimal? FK_LU_Eqipment_Type_Pollution
        {
            get { return _FK_LU_Eqipment_Type_Pollution; }
            set { _FK_LU_Eqipment_Type_Pollution = value; }
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
        /// Initializes a new instance of the clsEPM_Identification_Equipment class with default value.
        /// </summary>
        public clsEPM_Identification_Equipment()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_Identification_Equipment class based on Primary Key.
        /// </summary>
        public clsEPM_Identification_Equipment(decimal pK_EPM_Identification_Equipment)
        {
            DataTable dtEPM_Identification_Equipment = SelectByPK(pK_EPM_Identification_Equipment).Tables[0];

            if (dtEPM_Identification_Equipment.Rows.Count == 1)
            {
                SetValue(dtEPM_Identification_Equipment.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsEPM_Identification_Equipment class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drEPM_Identification_Equipment)
        {
            if (drEPM_Identification_Equipment["PK_EPM_Identification_Equipment"] == DBNull.Value)
                this._PK_EPM_Identification_Equipment = null;
            else
                this._PK_EPM_Identification_Equipment = (decimal?)drEPM_Identification_Equipment["PK_EPM_Identification_Equipment"];

            if (drEPM_Identification_Equipment["FK_EPM_Identification"] == DBNull.Value)
                this._FK_EPM_Identification = null;
            else
                this._FK_EPM_Identification = (decimal?)drEPM_Identification_Equipment["FK_EPM_Identification"];

            if (drEPM_Identification_Equipment["FK_LU_Eqipment_Type_Pollution"] == DBNull.Value)
                this._FK_LU_Eqipment_Type_Pollution = null;
            else
                this._FK_LU_Eqipment_Type_Pollution = (decimal?)drEPM_Identification_Equipment["FK_LU_Eqipment_Type_Pollution"];

            if (drEPM_Identification_Equipment["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drEPM_Identification_Equipment["Updated_By"];

            if (drEPM_Identification_Equipment["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drEPM_Identification_Equipment["Update_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the EPM_Identification_Equipment table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Identification_EquipmentInsert");


            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            db.AddInParameter(dbCommand, "FK_LU_Eqipment_Type_Pollution", DbType.Decimal, this._FK_LU_Eqipment_Type_Pollution);

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
        /// Selects a single record from the EPM_Identification_Equipment table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_EPM_Identification_Equipment)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Identification_EquipmentSelectByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Identification_Equipment", DbType.Decimal, pK_EPM_Identification_Equipment);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the EPM_Identification_Equipment table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Identification_EquipmentSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the EPM_Identification_Equipment table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Identification_EquipmentUpdate");


            db.AddInParameter(dbCommand, "PK_EPM_Identification_Equipment", DbType.Decimal, this._PK_EPM_Identification_Equipment);

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            db.AddInParameter(dbCommand, "FK_LU_Eqipment_Type_Pollution", DbType.Decimal, this._FK_LU_Eqipment_Type_Pollution);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the EPM_Identification_Equipment table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_EPM_Identification_Equipment)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Identification_EquipmentDeleteByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Identification_Equipment", DbType.Decimal, pK_EPM_Identification_Equipment);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the EPM_Identification_Equipment table by a composite foreign key.
        /// </summary>
        public static void DeleteByFK(decimal FK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Identification_EquipmentDeleteByFK");

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, FK_EPM_Identification);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the EPM_Identification_Equipment table by a Foreign key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal FK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Identification_EquipmentSelectByFK");

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, FK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
