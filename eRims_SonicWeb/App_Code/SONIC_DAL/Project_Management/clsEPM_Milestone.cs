using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for EPM_Milestone table.
    /// </summary>
    public sealed class clsEPM_Milestone
    {

        #region Private variables used to hold the property values

        private decimal? _PK_EPM_Milestone;
        private decimal? _FK_EPM_Identification;
        private decimal? _FK_LU_EPM_Milestone;
        private string _Description;
        private DateTime? _Milestone_Date;
        private bool? _Email_Reminder;
        private decimal? _FK_EPM_Milestone;
        private string _Additional_Recipients;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_EPM_Milestone value.
        /// </summary>
        public decimal? PK_EPM_Milestone
        {
            get { return _PK_EPM_Milestone; }
            set { _PK_EPM_Milestone = value; }
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
        /// Gets or sets the FK_LU_EPM_Milestone value.
        /// </summary>
        public decimal? FK_LU_EPM_Milestone
        {
            get { return _FK_LU_EPM_Milestone; }
            set { _FK_LU_EPM_Milestone = value; }
        }

        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        /// <summary>
        /// Gets or sets the Milestone_Date value.
        /// </summary>
        public DateTime? Milestone_Date
        {
            get { return _Milestone_Date; }
            set { _Milestone_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Email_Reminder value.
        /// </summary>
        public bool? Email_Reminder
        {
            get { return _Email_Reminder; }
            set { _Email_Reminder = value; }
        }

        /// <summary>
        /// Gets or sets the FK_EPM_Milestone value.
        /// </summary>
        public decimal? FK_EPM_Milestone
        {
            get { return _FK_EPM_Milestone; }
            set { _FK_EPM_Milestone = value; }
        }

        /// <summary>
        /// Gets or sets the Additional_Recipients value.
        /// </summary>
        public string Additional_Recipients
        {
            get { return _Additional_Recipients; }
            set { _Additional_Recipients = value; }
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
        /// Initializes a new instance of the clsEPM_Milestone class with default value.
        /// </summary>
        public clsEPM_Milestone()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_Milestone class based on Primary Key.
        /// </summary>
        public clsEPM_Milestone(decimal pK_EPM_Milestone)
        {
            DataTable dtEPM_Milestone = SelectByPK(pK_EPM_Milestone).Tables[0];

            if (dtEPM_Milestone.Rows.Count == 1)
            {
                SetValue(dtEPM_Milestone.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsEPM_Milestone class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drEPM_Milestone)
        {
            if (drEPM_Milestone["PK_EPM_Milestone"] == DBNull.Value)
                this._PK_EPM_Milestone = null;
            else
                this._PK_EPM_Milestone = (decimal?)drEPM_Milestone["PK_EPM_Milestone"];

            if (drEPM_Milestone["FK_EPM_Identification"] == DBNull.Value)
                this._FK_EPM_Identification = null;
            else
                this._FK_EPM_Identification = (decimal?)drEPM_Milestone["FK_EPM_Identification"];

            if (drEPM_Milestone["FK_LU_EPM_Milestone"] == DBNull.Value)
                this._FK_LU_EPM_Milestone = null;
            else
                this._FK_LU_EPM_Milestone = (decimal?)drEPM_Milestone["FK_LU_EPM_Milestone"];

            if (drEPM_Milestone["Description"] == DBNull.Value)
                this._Description = null;
            else
                this._Description = (string)drEPM_Milestone["Description"];

            if (drEPM_Milestone["Milestone_Date"] == DBNull.Value)
                this._Milestone_Date = null;
            else
                this._Milestone_Date = (DateTime?)drEPM_Milestone["Milestone_Date"];

            if (drEPM_Milestone["Email_Reminder"] == DBNull.Value)
                this._Email_Reminder = null;
            else
                this._Email_Reminder = (bool?)drEPM_Milestone["Email_Reminder"];

            if (drEPM_Milestone["FK_EPM_Milestone"] == DBNull.Value)
                this._FK_EPM_Milestone = null;
            else
                this._FK_EPM_Milestone = (decimal?)drEPM_Milestone["FK_EPM_Milestone"];

            if (drEPM_Milestone["Additional_Recipients"] == DBNull.Value)
                this._Additional_Recipients = null;
            else
                this._Additional_Recipients = (string)drEPM_Milestone["Additional_Recipients"];

            if (drEPM_Milestone["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drEPM_Milestone["Updated_By"];

            if (drEPM_Milestone["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drEPM_Milestone["Update_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the EPM_Milestone table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_MilestoneInsert");

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            db.AddInParameter(dbCommand, "FK_LU_EPM_Milestone", DbType.Decimal, this._FK_LU_EPM_Milestone);

            if (string.IsNullOrEmpty(this._Description))
                db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            db.AddInParameter(dbCommand, "Milestone_Date", DbType.DateTime, this._Milestone_Date);

            db.AddInParameter(dbCommand, "Email_Reminder", DbType.Boolean, this._Email_Reminder);

            db.AddInParameter(dbCommand, "FK_EPM_Milestone", DbType.Decimal, this._FK_EPM_Milestone);

            if (string.IsNullOrEmpty(this._Additional_Recipients))
                db.AddInParameter(dbCommand, "Additional_Recipients", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Additional_Recipients", DbType.String, this._Additional_Recipients);

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
        /// Selects a single record from the EPM_Milestone table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_EPM_Milestone)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_MilestoneSelectByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Milestone", DbType.Decimal, pK_EPM_Milestone);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the EPM_Milestone table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_MilestoneSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the EPM_Milestone table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_MilestoneUpdate");


            db.AddInParameter(dbCommand, "PK_EPM_Milestone", DbType.Decimal, this._PK_EPM_Milestone);

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            db.AddInParameter(dbCommand, "FK_LU_EPM_Milestone", DbType.Decimal, this._FK_LU_EPM_Milestone);

            if (string.IsNullOrEmpty(this._Description))
                db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            db.AddInParameter(dbCommand, "Milestone_Date", DbType.DateTime, this._Milestone_Date);

            db.AddInParameter(dbCommand, "Email_Reminder", DbType.Boolean, this._Email_Reminder);

            db.AddInParameter(dbCommand, "FK_EPM_Milestone", DbType.Decimal, this._FK_EPM_Milestone);

            if (string.IsNullOrEmpty(this._Additional_Recipients))
                db.AddInParameter(dbCommand, "Additional_Recipients", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Additional_Recipients", DbType.String, this._Additional_Recipients);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the EPM_Milestone table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_EPM_Milestone)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_MilestoneDeleteByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Milestone", DbType.Decimal, pK_EPM_Milestone);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the EPM_Milestone table by a Foreign key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal FK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_MilestoneSelectByFK");

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, FK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the EPM_Milestone table by a Foreign key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPkForDropdown(decimal PK_EPM_Milestone, decimal FK_LU_Location_Id, decimal FK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_MilestoneSelectByPkForDropdown");

            db.AddInParameter(dbCommand, "PK_EPM_Milestone", DbType.Decimal, PK_EPM_Milestone);
            db.AddInParameter(dbCommand, "FK_LU_Location_Id", DbType.Decimal, FK_LU_Location_Id);
            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, FK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
