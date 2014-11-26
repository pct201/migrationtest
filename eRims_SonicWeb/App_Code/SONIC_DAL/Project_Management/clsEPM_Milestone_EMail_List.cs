using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for EPM_Milestone_EMail_List table.
    /// </summary>
    public sealed class clsEPM_Milestone_EMail_List
    {

        #region Private variables used to hold the property values

        private decimal? _PK_EPM_Milestone_Email_List;
        private decimal? _FK_EPM_Milestone;
        private decimal? _FK_Security_Id;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_EPM_Milestone_Email_List value.
        /// </summary>
        public decimal? PK_EPM_Milestone_Email_List
        {
            get { return _PK_EPM_Milestone_Email_List; }
            set { _PK_EPM_Milestone_Email_List = value; }
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
        /// Gets or sets the FK_Security_Id value.
        /// </summary>
        public decimal? FK_Security_Id
        {
            get { return _FK_Security_Id; }
            set { _FK_Security_Id = value; }
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
        /// Initializes a new instance of the clsEPM_Milestone_EMail_List class with default value.
        /// </summary>
        public clsEPM_Milestone_EMail_List()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_Milestone_EMail_List class based on Primary Key.
        /// </summary>
        public clsEPM_Milestone_EMail_List(decimal pK_EPM_Milestone_Email_List)
        {
            DataTable dtEPM_Milestone_EMail_List = SelectByPK(pK_EPM_Milestone_Email_List).Tables[0];

            if (dtEPM_Milestone_EMail_List.Rows.Count == 1)
            {
                SetValue(dtEPM_Milestone_EMail_List.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsEPM_Milestone_EMail_List class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drEPM_Milestone_EMail_List)
        {
            if (drEPM_Milestone_EMail_List["PK_EPM_Milestone_Email_List"] == DBNull.Value)
                this._PK_EPM_Milestone_Email_List = null;
            else
                this._PK_EPM_Milestone_Email_List = (decimal?)drEPM_Milestone_EMail_List["PK_EPM_Milestone_Email_List"];

            if (drEPM_Milestone_EMail_List["FK_EPM_Milestone"] == DBNull.Value)
                this._FK_EPM_Milestone = null;
            else
                this._FK_EPM_Milestone = (decimal?)drEPM_Milestone_EMail_List["FK_EPM_Milestone"];

            if (drEPM_Milestone_EMail_List["FK_Security_Id"] == DBNull.Value)
                this._FK_Security_Id = null;
            else
                this._FK_Security_Id = (decimal?)drEPM_Milestone_EMail_List["FK_Security_Id"];

            if (drEPM_Milestone_EMail_List["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drEPM_Milestone_EMail_List["Updated_By"];

            if (drEPM_Milestone_EMail_List["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drEPM_Milestone_EMail_List["Update_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the EPM_Milestone_EMail_List table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Milestone_EMail_ListInsert");


            db.AddInParameter(dbCommand, "FK_EPM_Milestone", DbType.Decimal, this._FK_EPM_Milestone);

            db.AddInParameter(dbCommand, "FK_Security_Id", DbType.Decimal, this._FK_Security_Id);

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
        /// Selects a single record from the EPM_Milestone_EMail_List table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_EPM_Milestone_Email_List)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Milestone_EMail_ListSelectByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Milestone_Email_List", DbType.Decimal, pK_EPM_Milestone_Email_List);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the EPM_Milestone_EMail_List table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Milestone_EMail_ListSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the EPM_Milestone_EMail_List table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Milestone_EMail_ListUpdate");


            db.AddInParameter(dbCommand, "PK_EPM_Milestone_Email_List", DbType.Decimal, this._PK_EPM_Milestone_Email_List);

            db.AddInParameter(dbCommand, "FK_EPM_Milestone", DbType.Decimal, this._FK_EPM_Milestone);

            db.AddInParameter(dbCommand, "FK_Security_Id", DbType.Decimal, this._FK_Security_Id);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the EPM_Milestone_EMail_List table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_EPM_Milestone_Email_List)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Milestone_EMail_ListDeleteByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Milestone_Email_List", DbType.Decimal, pK_EPM_Milestone_Email_List);

            db.ExecuteNonQuery(dbCommand);
        }

        public static void DeleteByFK(decimal FK_EPM_Milestone)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Milestone_EMail_ListDeleteByFK");

            db.AddInParameter(dbCommand, "FK_EPM_Milestone", DbType.Decimal, FK_EPM_Milestone);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the EPM_Milestone_EMail_List table by a foreign key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal FK_EPM_Milestone, decimal PK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Milestone_EMail_ListSelectByFK");

            db.AddInParameter(dbCommand, "FK_EPM_Milestone", DbType.Decimal, FK_EPM_Milestone);
            db.AddInParameter(dbCommand, "PK_EPM_Identification", DbType.Decimal, PK_EPM_Identification);
            

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetMilestoneEmailId(string FK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Mileston_GetEmailId");

            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.String, FK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SetEmailRecipients(decimal FK_EPM_Identification, decimal FK_LU_EPM_Milestone)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Milestone_EMail_SetEmailRecipients");

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, FK_EPM_Identification);
            db.AddInParameter(dbCommand, "FK_LU_EPM_Milestone", DbType.Decimal, FK_LU_EPM_Milestone);
            
            return db.ExecuteDataSet(dbCommand);
        }
        

    }
}
