using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for EPM_Action_Notes table.
    /// </summary>
    public sealed class clsEPM_Action_Notes
    {

        #region Private variables used to hold the property values

        private decimal? _PK_EPM_Action_Notes;
        private decimal? _FK_EMP_Identification;
        private decimal? _FK_LU_EPM_Required_Activity;
        private string _Requied_Activity_Description;
        private DateTime? _Date_Required_Activity_Initially_Entered;
        private DateTime? _Date_Required_Activity_Last_Edited;
        private string _Action;
        private DateTime? _Date_Action_Initially_Entered;
        private DateTime? _Date_Action_Last_Edited;
        private string _Status;
        private DateTime? _Date_Status_Initially_Entered;
        private DateTime? _Date_Status_Last_Edited;
        private string _Issues;
        private DateTime? _Date_Issues_Initially_Entered;
        private DateTime? _Date_Issues_Last_Edited;
        private decimal? _Outcome;
        private string _Comments;
        private DateTime? _Date_Comments_Initially_Entered;
        private DateTime? _Date_Comments_Last_Edited;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_EPM_Action_Notes value.
        /// </summary>
        public decimal? PK_EPM_Action_Notes
        {
            get { return _PK_EPM_Action_Notes; }
            set { _PK_EPM_Action_Notes = value; }
        }

        /// <summary>
        /// Gets or sets the FK_EMP_Identification value.
        /// </summary>
        public decimal? FK_EMP_Identification
        {
            get { return _FK_EMP_Identification; }
            set { _FK_EMP_Identification = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_EPM_Required_Activity value.
        /// </summary>
        public decimal? FK_LU_EPM_Required_Activity
        {
            get { return _FK_LU_EPM_Required_Activity; }
            set { _FK_LU_EPM_Required_Activity = value; }
        }

        /// <summary>
        /// Gets or sets the Requied_Activity_Description value.
        /// </summary>
        public string Requied_Activity_Description
        {
            get { return _Requied_Activity_Description; }
            set { _Requied_Activity_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Required_Activity_Initially_Entered value.
        /// </summary>
        public DateTime? Date_Required_Activity_Initially_Entered
        {
            get { return _Date_Required_Activity_Initially_Entered; }
            set { _Date_Required_Activity_Initially_Entered = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Required_Activity_Last_Edited value.
        /// </summary>
        public DateTime? Date_Required_Activity_Last_Edited
        {
            get { return _Date_Required_Activity_Last_Edited; }
            set { _Date_Required_Activity_Last_Edited = value; }
        }

        /// <summary>
        /// Gets or sets the Action value.
        /// </summary>
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Action_Initially_Entered value.
        /// </summary>
        public DateTime? Date_Action_Initially_Entered
        {
            get { return _Date_Action_Initially_Entered; }
            set { _Date_Action_Initially_Entered = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Action_Last_Edited value.
        /// </summary>
        public DateTime? Date_Action_Last_Edited
        {
            get { return _Date_Action_Last_Edited; }
            set { _Date_Action_Last_Edited = value; }
        }

        /// <summary>
        /// Gets or sets the Status value.
        /// </summary>
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Status_Initially_Entered value.
        /// </summary>
        public DateTime? Date_Status_Initially_Entered
        {
            get { return _Date_Status_Initially_Entered; }
            set { _Date_Status_Initially_Entered = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Status_Last_Edited value.
        /// </summary>
        public DateTime? Date_Status_Last_Edited
        {
            get { return _Date_Status_Last_Edited; }
            set { _Date_Status_Last_Edited = value; }
        }

        /// <summary>
        /// Gets or sets the Issues value.
        /// </summary>
        public string Issues
        {
            get { return _Issues; }
            set { _Issues = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Issues_Initially_Entered value.
        /// </summary>
        public DateTime? Date_Issues_Initially_Entered
        {
            get { return _Date_Issues_Initially_Entered; }
            set { _Date_Issues_Initially_Entered = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Issues_Last_Edited value.
        /// </summary>
        public DateTime? Date_Issues_Last_Edited
        {
            get { return _Date_Issues_Last_Edited; }
            set { _Date_Issues_Last_Edited = value; }
        }

        /// <summary>
        /// Gets or sets the Outcome value.
        /// </summary>
        public decimal? Outcome
        {
            get { return _Outcome; }
            set { _Outcome = value; }
        }

        /// <summary>
        /// Gets or sets the Comments value.
        /// </summary>
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Comments_Initially_Entered value.
        /// </summary>
        public DateTime? Date_Comments_Initially_Entered
        {
            get { return _Date_Comments_Initially_Entered; }
            set { _Date_Comments_Initially_Entered = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Comments_Last_Edited value.
        /// </summary>
        public DateTime? Date_Comments_Last_Edited
        {
            get { return _Date_Comments_Last_Edited; }
            set { _Date_Comments_Last_Edited = value; }
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
        /// Initializes a new instance of the clsEPM_Action_Notes class with default value.
        /// </summary>
        public clsEPM_Action_Notes()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_Action_Notes class based on Primary Key.
        /// </summary>
        public clsEPM_Action_Notes(decimal pK_EPM_Action_Notes)
        {
            DataTable dtEPM_Action_Notes = SelectByPK(pK_EPM_Action_Notes).Tables[0];

            if (dtEPM_Action_Notes.Rows.Count == 1)
            {
                SetValue(dtEPM_Action_Notes.Rows[0]);

            }

        }

        /// <summary>
        /// Initializes a new instance of the clsEPM_Action_Notes class based on Foreign Key.
        /// </summary>
        public clsEPM_Action_Notes(int FK_EPM_Identification)
        {
            DataTable dtEPM_Action_Notes = SelectByFK(FK_EPM_Identification).Tables[0];

            if (dtEPM_Action_Notes.Rows.Count == 1)
            {
                SetValue(dtEPM_Action_Notes.Rows[0]);
            }
        }


        /// <summary>
        /// Initializes a new instance of the clsEPM_Action_Notes class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drEPM_Action_Notes)
        {
            if (drEPM_Action_Notes["PK_EPM_Action_Notes"] == DBNull.Value)
                this._PK_EPM_Action_Notes = null;
            else
                this._PK_EPM_Action_Notes = (decimal?)drEPM_Action_Notes["PK_EPM_Action_Notes"];

            if (drEPM_Action_Notes["FK_EMP_Identification"] == DBNull.Value)
                this._FK_EMP_Identification = null;
            else
                this._FK_EMP_Identification = (decimal?)drEPM_Action_Notes["FK_EMP_Identification"];

            if (drEPM_Action_Notes["FK_LU_EPM_Required_Activity"] == DBNull.Value)
                this._FK_LU_EPM_Required_Activity = null;
            else
                this._FK_LU_EPM_Required_Activity = (decimal?)drEPM_Action_Notes["FK_LU_EPM_Required_Activity"];

            if (drEPM_Action_Notes["Requied_Activity_Description"] == DBNull.Value)
                this._Requied_Activity_Description = null;
            else
                this._Requied_Activity_Description = (string)drEPM_Action_Notes["Requied_Activity_Description"];

            if (drEPM_Action_Notes["Date_Required_Activity_Initially_Entered"] == DBNull.Value)
                this._Date_Required_Activity_Initially_Entered = null;
            else
                this._Date_Required_Activity_Initially_Entered = (DateTime?)drEPM_Action_Notes["Date_Required_Activity_Initially_Entered"];

            if (drEPM_Action_Notes["Date_Required_Activity_Last_Edited"] == DBNull.Value)
                this._Date_Required_Activity_Last_Edited = null;
            else
                this._Date_Required_Activity_Last_Edited = (DateTime?)drEPM_Action_Notes["Date_Required_Activity_Last_Edited"];

            if (drEPM_Action_Notes["Action"] == DBNull.Value)
                this._Action = null;
            else
                this._Action = (string)drEPM_Action_Notes["Action"];

            if (drEPM_Action_Notes["Date_Action_Initially_Entered"] == DBNull.Value)
                this._Date_Action_Initially_Entered = null;
            else
                this._Date_Action_Initially_Entered = (DateTime?)drEPM_Action_Notes["Date_Action_Initially_Entered"];

            if (drEPM_Action_Notes["Date_Action_Last_Edited"] == DBNull.Value)
                this._Date_Action_Last_Edited = null;
            else
                this._Date_Action_Last_Edited = (DateTime?)drEPM_Action_Notes["Date_Action_Last_Edited"];

            if (drEPM_Action_Notes["Status"] == DBNull.Value)
                this._Status = null;
            else
                this._Status = (string)drEPM_Action_Notes["Status"];

            if (drEPM_Action_Notes["Date_Status_Initially_Entered"] == DBNull.Value)
                this._Date_Status_Initially_Entered = null;
            else
                this._Date_Status_Initially_Entered = (DateTime?)drEPM_Action_Notes["Date_Status_Initially_Entered"];

            if (drEPM_Action_Notes["Date_Status_Last_Edited"] == DBNull.Value)
                this._Date_Status_Last_Edited = null;
            else
                this._Date_Status_Last_Edited = (DateTime?)drEPM_Action_Notes["Date_Status_Last_Edited"];

            if (drEPM_Action_Notes["Issues"] == DBNull.Value)
                this._Issues = null;
            else
                this._Issues = (string)drEPM_Action_Notes["Issues"];

            if (drEPM_Action_Notes["Date_Issues_Initially_Entered"] == DBNull.Value)
                this._Date_Issues_Initially_Entered = null;
            else
                this._Date_Issues_Initially_Entered = (DateTime?)drEPM_Action_Notes["Date_Issues_Initially_Entered"];

            if (drEPM_Action_Notes["Date_Issues_Last_Edited"] == DBNull.Value)
                this._Date_Issues_Last_Edited = null;
            else
                this._Date_Issues_Last_Edited = (DateTime?)drEPM_Action_Notes["Date_Issues_Last_Edited"];

            if (drEPM_Action_Notes["Outcome"] == DBNull.Value)
                this._Outcome = null;
            else
                this._Outcome = (decimal?)drEPM_Action_Notes["Outcome"];

            if (drEPM_Action_Notes["Comments"] == DBNull.Value)
                this._Comments = null;
            else
                this._Comments = (string)drEPM_Action_Notes["Comments"];

            if (drEPM_Action_Notes["Date_Comments_Initially_Entered"] == DBNull.Value)
                this._Date_Comments_Initially_Entered = null;
            else
                this._Date_Comments_Initially_Entered = (DateTime?)drEPM_Action_Notes["Date_Comments_Initially_Entered"];

            if (drEPM_Action_Notes["Date_Comments_Last_Edited"] == DBNull.Value)
                this._Date_Comments_Last_Edited = null;
            else
                this._Date_Comments_Last_Edited = (DateTime?)drEPM_Action_Notes["Date_Comments_Last_Edited"];

            if (drEPM_Action_Notes["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drEPM_Action_Notes["Updated_By"];

            if (drEPM_Action_Notes["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drEPM_Action_Notes["Update_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the EPM_Action_Notes table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Action_NotesInsert");


            db.AddInParameter(dbCommand, "PK_EPM_Action_Notes", DbType.Decimal, this._PK_EPM_Action_Notes);

            db.AddInParameter(dbCommand, "FK_EMP_Identification", DbType.Decimal, this._FK_EMP_Identification);

            db.AddInParameter(dbCommand, "FK_LU_EPM_Required_Activity", DbType.Decimal, this._FK_LU_EPM_Required_Activity);

            if (string.IsNullOrEmpty(this._Requied_Activity_Description))
                db.AddInParameter(dbCommand, "Requied_Activity_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Requied_Activity_Description", DbType.String, this._Requied_Activity_Description);

            db.AddInParameter(dbCommand, "Date_Required_Activity_Initially_Entered", DbType.DateTime, this._Date_Required_Activity_Initially_Entered);

            db.AddInParameter(dbCommand, "Date_Required_Activity_Last_Edited", DbType.DateTime, this._Date_Required_Activity_Last_Edited);

            if (string.IsNullOrEmpty(this._Action))
                db.AddInParameter(dbCommand, "Action", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Action", DbType.String, this._Action);

            db.AddInParameter(dbCommand, "Date_Action_Initially_Entered", DbType.DateTime, this._Date_Action_Initially_Entered);

            db.AddInParameter(dbCommand, "Date_Action_Last_Edited", DbType.DateTime, this._Date_Action_Last_Edited);

            if (string.IsNullOrEmpty(this._Status))
                db.AddInParameter(dbCommand, "Status", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Status", DbType.String, this._Status);

            db.AddInParameter(dbCommand, "Date_Status_Initially_Entered", DbType.DateTime, this._Date_Status_Initially_Entered);

            db.AddInParameter(dbCommand, "Date_Status_Last_Edited", DbType.DateTime, this._Date_Status_Last_Edited);

            if (string.IsNullOrEmpty(this._Issues))
                db.AddInParameter(dbCommand, "Issues", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Issues", DbType.String, this._Issues);

            db.AddInParameter(dbCommand, "Date_Issues_Initially_Entered", DbType.DateTime, this._Date_Issues_Initially_Entered);

            db.AddInParameter(dbCommand, "Date_Issues_Last_Edited", DbType.DateTime, this._Date_Issues_Last_Edited);

            db.AddInParameter(dbCommand, "Outcome", DbType.Decimal, this._Outcome);

            if (string.IsNullOrEmpty(this._Comments))
                db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

            db.AddInParameter(dbCommand, "Date_Comments_Initially_Entered", DbType.DateTime, this._Date_Comments_Initially_Entered);

            db.AddInParameter(dbCommand, "Date_Comments_Last_Edited", DbType.DateTime, this._Date_Comments_Last_Edited);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the EPM_Action_Notes table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_EPM_Action_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Action_NotesSelectByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Action_Notes", DbType.Decimal, pK_EPM_Action_Notes);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the EPM_Action_Notes table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Action_NotesSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the EPM_Action_Notes table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Action_NotesUpdate");


            db.AddInParameter(dbCommand, "PK_EPM_Action_Notes", DbType.Decimal, this._PK_EPM_Action_Notes);

            db.AddInParameter(dbCommand, "FK_EMP_Identification", DbType.Decimal, this._FK_EMP_Identification);

            db.AddInParameter(dbCommand, "FK_LU_EPM_Required_Activity", DbType.Decimal, this._FK_LU_EPM_Required_Activity);

            if (string.IsNullOrEmpty(this._Requied_Activity_Description))
                db.AddInParameter(dbCommand, "Requied_Activity_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Requied_Activity_Description", DbType.String, this._Requied_Activity_Description);

            db.AddInParameter(dbCommand, "Date_Required_Activity_Initially_Entered", DbType.DateTime, this._Date_Required_Activity_Initially_Entered);

            db.AddInParameter(dbCommand, "Date_Required_Activity_Last_Edited", DbType.DateTime, this._Date_Required_Activity_Last_Edited);

            if (string.IsNullOrEmpty(this._Action))
                db.AddInParameter(dbCommand, "Action", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Action", DbType.String, this._Action);

            db.AddInParameter(dbCommand, "Date_Action_Initially_Entered", DbType.DateTime, this._Date_Action_Initially_Entered);

            db.AddInParameter(dbCommand, "Date_Action_Last_Edited", DbType.DateTime, this._Date_Action_Last_Edited);

            if (string.IsNullOrEmpty(this._Status))
                db.AddInParameter(dbCommand, "Status", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Status", DbType.String, this._Status);

            db.AddInParameter(dbCommand, "Date_Status_Initially_Entered", DbType.DateTime, this._Date_Status_Initially_Entered);

            db.AddInParameter(dbCommand, "Date_Status_Last_Edited", DbType.DateTime, this._Date_Status_Last_Edited);

            if (string.IsNullOrEmpty(this._Issues))
                db.AddInParameter(dbCommand, "Issues", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Issues", DbType.String, this._Issues);

            db.AddInParameter(dbCommand, "Date_Issues_Initially_Entered", DbType.DateTime, this._Date_Issues_Initially_Entered);

            db.AddInParameter(dbCommand, "Date_Issues_Last_Edited", DbType.DateTime, this._Date_Issues_Last_Edited);

            db.AddInParameter(dbCommand, "Outcome", DbType.Decimal, this._Outcome);

            if (string.IsNullOrEmpty(this._Comments))
                db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

            db.AddInParameter(dbCommand, "Date_Comments_Initially_Entered", DbType.DateTime, this._Date_Comments_Initially_Entered);

            db.AddInParameter(dbCommand, "Date_Comments_Last_Edited", DbType.DateTime, this._Date_Comments_Last_Edited);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Deletes a record from the EPM_Action_Notes table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_EPM_Action_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Action_NotesDeleteByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Action_Notes", DbType.Decimal, pK_EPM_Action_Notes);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the EPM_Action_Notes table by a Foreign key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByFK(decimal FK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Action_NotesSelectByFK");

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, FK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
