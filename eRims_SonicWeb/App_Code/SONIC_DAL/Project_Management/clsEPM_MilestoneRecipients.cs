using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for EPM_MilestoneRecipients table.
    /// </summary>
    public sealed class clsEPM_MilestoneRecipients
    {

        #region Private variables used to hold the property values

        private decimal? _PK_EPM_MilestoneRecipients;
        private string _Name;
        private string _EMail;
        private DateTime? _Update_Date;
        private string _Updated_By;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_EPM_MilestoneRecipients value.
        /// </summary>
        public decimal? PK_EPM_MilestoneRecipients
        {
            get { return _PK_EPM_MilestoneRecipients; }
            set { _PK_EPM_MilestoneRecipients = value; }
        }

        /// <summary>
        /// Gets or sets the Name value.
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Gets or sets the EMail value.
        /// </summary>
        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
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
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_MilestoneRecipients class with default value.
        /// </summary>
        public clsEPM_MilestoneRecipients()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_MilestoneRecipients class based on Primary Key.
        /// </summary>
        public clsEPM_MilestoneRecipients(decimal pK_EPM_MilestoneRecipients)
        {
            DataTable dtEPM_MilestoneRecipients = SelectByPK(pK_EPM_MilestoneRecipients).Tables[0];

            if (dtEPM_MilestoneRecipients.Rows.Count == 1)
            {
                SetValue(dtEPM_MilestoneRecipients.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsEPM_MilestoneRecipients class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drEPM_MilestoneRecipients)
        {
            if (drEPM_MilestoneRecipients["PK_EPM_MilestoneRecipients"] == DBNull.Value)
                this._PK_EPM_MilestoneRecipients = null;
            else
                this._PK_EPM_MilestoneRecipients = (decimal?)drEPM_MilestoneRecipients["PK_EPM_MilestoneRecipients"];

            if (drEPM_MilestoneRecipients["Name"] == DBNull.Value)
                this._Name = null;
            else
                this._Name = (string)drEPM_MilestoneRecipients["Name"];

            if (drEPM_MilestoneRecipients["EMail"] == DBNull.Value)
                this._EMail = null;
            else
                this._EMail = (string)drEPM_MilestoneRecipients["EMail"];

            if (drEPM_MilestoneRecipients["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drEPM_MilestoneRecipients["Update_Date"];

            if (drEPM_MilestoneRecipients["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drEPM_MilestoneRecipients["Updated_By"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the EPM_MilestoneRecipients table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_MilestoneRecipientsInsert");


            if (string.IsNullOrEmpty(this._Name))
                db.AddInParameter(dbCommand, "Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);

            if (string.IsNullOrEmpty(this._EMail))
                db.AddInParameter(dbCommand, "EMail", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EMail", DbType.String, this._EMail);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the EPM_MilestoneRecipients table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_EPM_MilestoneRecipients)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_MilestoneRecipientsSelectByPK");

            db.AddInParameter(dbCommand, "PK_EPM_MilestoneRecipients", DbType.Decimal, pK_EPM_MilestoneRecipients);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the EPM_MilestoneRecipients table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_MilestoneRecipientsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the EPM_MilestoneRecipients table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_MilestoneRecipientsUpdate");


            db.AddInParameter(dbCommand, "PK_EPM_MilestoneRecipients", DbType.Decimal, this._PK_EPM_MilestoneRecipients);

            if (string.IsNullOrEmpty(this._Name))
                db.AddInParameter(dbCommand, "Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);

            if (string.IsNullOrEmpty(this._EMail))
                db.AddInParameter(dbCommand, "EMail", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EMail", DbType.String, this._EMail);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the EPM_MilestoneRecipients table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_EPM_MilestoneRecipients)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_MilestoneRecipientsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_EPM_MilestoneRecipients", DbType.Decimal, pK_EPM_MilestoneRecipients);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet GetMilestoneRecipientsEmailId(string strPK_EPM_MilestoneRecipients, decimal FK_EPM_Milestone)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_MilestoneRecipientsEmailId");

            db.AddInParameter(dbCommand, "PK_EPM_MilestoneRecipients", DbType.String, strPK_EPM_MilestoneRecipients);
            db.AddInParameter(dbCommand, "FK_EPM_Milestone", DbType.Decimal, FK_EPM_Milestone);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetMilestoneRecipients_ForMileston_Date(string strPK_EPM_MilestoneRecipients)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_MilestoneRecipients_ForMileston_Date");

            db.AddInParameter(dbCommand, "PK_EPM_MilestoneRecipients", DbType.String, strPK_EPM_MilestoneRecipients);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
