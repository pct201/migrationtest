using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for AP_FE_PA_Notes table.
    /// </summary>
    public sealed class AP_FE_PA_Notes
    {

        #region Private variables used to hold the property values

        private decimal? _PK_AP_FE_PA_Notes;
        private decimal? _FK_AP_Fraud_Events;
        private DateTime? _Note_Date;
        private string _Note;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_AP_FE_PA_Notes value.
        /// </summary>
        public decimal? PK_AP_FE_PA_Notes
        {
            get { return _PK_AP_FE_PA_Notes; }
            set { _PK_AP_FE_PA_Notes = value; }
        }

        /// <summary>
        /// Gets or sets the FK_AP_Fraud_Events value.
        /// </summary>
        public decimal? FK_AP_Fraud_Events
        {
            get { return _FK_AP_Fraud_Events; }
            set { _FK_AP_Fraud_Events = value; }
        }

        /// <summary>
        /// Gets or sets the Note_Date value.
        /// </summary>
        public DateTime? Note_Date
        {
            get { return _Note_Date; }
            set { _Note_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Note value.
        /// </summary>
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
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
        /// Initializes a new instance of the AP_FE_PA_Notes class with default value.
        /// </summary>
        public AP_FE_PA_Notes()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the AP_FE_PA_Notes class based on Primary Key.
        /// </summary>
        public AP_FE_PA_Notes(decimal pK_AP_FE_PA_Notes)
        {
            DataTable dtAP_FE_PA_Notes = SelectByPK(pK_AP_FE_PA_Notes).Tables[0];

            if (dtAP_FE_PA_Notes.Rows.Count == 1)
            {
                SetValue(dtAP_FE_PA_Notes.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the AP_FE_PA_Notes class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drAP_FE_PA_Notes)
        {
            if (drAP_FE_PA_Notes["PK_AP_FE_PA_Notes"] == DBNull.Value)
                this._PK_AP_FE_PA_Notes = null;
            else
                this._PK_AP_FE_PA_Notes = (decimal?)drAP_FE_PA_Notes["PK_AP_FE_PA_Notes"];

            if (drAP_FE_PA_Notes["FK_AP_Fraud_Events"] == DBNull.Value)
                this._FK_AP_Fraud_Events = null;
            else
                this._FK_AP_Fraud_Events = (decimal?)drAP_FE_PA_Notes["FK_AP_Fraud_Events"];

            if (drAP_FE_PA_Notes["Note_Date"] == DBNull.Value)
                this._Note_Date = null;
            else
                this._Note_Date = (DateTime?)drAP_FE_PA_Notes["Note_Date"];

            if (drAP_FE_PA_Notes["Note"] == DBNull.Value)
                this._Note = null;
            else
                this._Note = (string)drAP_FE_PA_Notes["Note"];

            if (drAP_FE_PA_Notes["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drAP_FE_PA_Notes["Updated_By"];

            if (drAP_FE_PA_Notes["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drAP_FE_PA_Notes["Update_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the AP_FE_PA_Notes table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_FE_PA_NotesInsert");


            db.AddInParameter(dbCommand, "FK_AP_Fraud_Events", DbType.Decimal, this._FK_AP_Fraud_Events);

            db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);

            if (string.IsNullOrEmpty(this._Note))
                db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);

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
        /// Selects a single record from the AP_FE_PA_Notes table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_AP_FE_PA_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_FE_PA_NotesSelectByPK");

            db.AddInParameter(dbCommand, "PK_AP_FE_PA_Notes", DbType.Decimal, pK_AP_FE_PA_Notes);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the AP_FE_PA_Notes table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_FE_PA_NotesSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the AP_FE_PA_Notes table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_FE_PA_NotesUpdate");


            db.AddInParameter(dbCommand, "PK_AP_FE_PA_Notes", DbType.Decimal, this._PK_AP_FE_PA_Notes);

            db.AddInParameter(dbCommand, "FK_AP_Fraud_Events", DbType.Decimal, this._FK_AP_Fraud_Events);

            db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);

            if (string.IsNullOrEmpty(this._Note))
                db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the AP_FE_PA_Notes table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_AP_FE_PA_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_FE_PA_NotesDeleteByPK");

            db.AddInParameter(dbCommand, "PK_AP_FE_PA_Notes", DbType.Decimal, pK_AP_FE_PA_Notes);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SeleteByFK(decimal fK_AP_Fraud_Events)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_FE_PA_NotesSelectByFK");
            db.AddInParameter(dbCommand, "FK_AP_Fraud_Events", DbType.Decimal, fK_AP_Fraud_Events);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Notes Record by FK_FraudEvent
        /// </summary>
        public static DataSet SelectNotesByFKFraudEvent(decimal fK_AP_Fraud_Events, string strOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectPANotesByFKFraudEvent");

            db.AddInParameter(dbCommand, "FK_AP_Fraud_Events", DbType.Decimal, fK_AP_Fraud_Events);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
