using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Inspection_Responses table.
    /// </summary>
    public sealed class Inspection_Responses
    {
        #region Fields


        private int _PK_Inspection_Responses_ID;
        private int _FK_Inspection_ID;
        private int _FK_Inspection_Question_ID;
        private string _Deficiency_Noted;
        private string _Department;
        private DateTime _Date_Opened;
        private string _Recommended_Action;
        private DateTime _Target_Completion_Date;
        private DateTime _Actual_Completion_Date;
        private string _Notes;
        private string _UniqueVal;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        private string _Repeat_Deficiency;
        private string _Problem_Description;
        private string _Title;
        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Inspection_Responses_ID value.
        /// </summary>
        public int PK_Inspection_Responses_ID
        {
            get { return _PK_Inspection_Responses_ID; }
            set { _PK_Inspection_Responses_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Inspection_ID value.
        /// </summary>
        public int FK_Inspection_ID
        {
            get { return _FK_Inspection_ID; }
            set { _FK_Inspection_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Inspection_Question_ID value.
        /// </summary>
        public int FK_Inspection_Question_ID
        {
            get { return _FK_Inspection_Question_ID; }
            set { _FK_Inspection_Question_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Deficiency_Noted value.
        /// </summary>
        public string Deficiency_Noted
        {
            get { return _Deficiency_Noted; }
            set { _Deficiency_Noted = value; }
        }


        /// <summary> 
        /// Gets or sets the Department value.
        /// </summary>
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Opened value.
        /// </summary>
        public DateTime Date_Opened
        {
            get { return _Date_Opened; }
            set { _Date_Opened = value; }
        }


        /// <summary> 
        /// Gets or sets the Recommended_Action value.
        /// </summary>
        public string Recommended_Action
        {
            get { return _Recommended_Action; }
            set { _Recommended_Action = value; }
        }


        /// <summary> 
        /// Gets or sets the Target_Completion_Date value.
        /// </summary>
        public DateTime Target_Completion_Date
        {
            get { return _Target_Completion_Date; }
            set { _Target_Completion_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Actual_Completion_Date value.
        /// </summary>
        public DateTime Actual_Completion_Date
        {
            get { return _Actual_Completion_Date; }
            set { _Actual_Completion_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Notes value.
        /// </summary>
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        /// <summary> 
        /// Gets or sets the UniqueVal value.
        /// </summary>
        public string UniqueVal
        {
            get { return _UniqueVal; }
            set { _UniqueVal = value; }
        }


        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public decimal Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }


        /// <summary> 
        /// Gets or sets the Updated_Date value.
        /// </summary>
        public DateTime Updated_Date
        {
            get { return _Updated_Date; }
            set { _Updated_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Repeat_Deficiency value.
        /// </summary>
        public string Repeat_Deficiency
        {
            get { return _Repeat_Deficiency; }
            set { _Repeat_Deficiency = value; }
        }

        /// <summary> 
        /// Gets or sets the Problem_Description value.
        /// </summary>
        public string Problem_Description
        {
            get { return _Problem_Description; }
            set { _Problem_Description = value; }
        }

        /// <summary> 
        /// Gets or sets the Title value.
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        
        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Inspection_Responses class. with the default value.

        /// </summary>
        public Inspection_Responses()
        {

            this._PK_Inspection_Responses_ID = -1;
            this._FK_Inspection_Question_ID = -1;
            this._Deficiency_Noted = "";
            this._Department = "";
            this._Date_Opened = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Recommended_Action = "";
            this._Target_Completion_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Actual_Completion_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Notes = "";
            this._UniqueVal = "";
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Repeat_Deficiency = null;
            this._Title = "";
            this._Problem_Description = "";
        }



        /// <summary> 

        /// Initializes a new instance of the Inspection_Responses class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Inspection_Responses(int PK)
        {

            DataTable dtInspection_Responses = SelectByPK(PK).Tables[0];

            if (dtInspection_Responses.Rows.Count > 0)
            {

                DataRow drInspection_Responses = dtInspection_Responses.Rows[0];

                this._PK_Inspection_Responses_ID = drInspection_Responses["PK_Inspection_Responses_ID"] != DBNull.Value ? Convert.ToInt32(drInspection_Responses["PK_Inspection_Responses_ID"]) : 0;
                this._FK_Inspection_ID = drInspection_Responses["FK_Inspection_ID"] != DBNull.Value ? Convert.ToInt32(drInspection_Responses["FK_Inspection_ID"]) : 0;
                this._FK_Inspection_Question_ID = drInspection_Responses["FK_Inspection_Question_ID"] != DBNull.Value ? Convert.ToInt32(drInspection_Responses["FK_Inspection_Question_ID"]) : 0;
                this._Deficiency_Noted = Convert.ToString(drInspection_Responses["Deficiency_Noted"]);
                this._Department = Convert.ToString(drInspection_Responses["Department"]);
                this._Date_Opened = drInspection_Responses["Date_Opened"] != DBNull.Value ? Convert.ToDateTime(drInspection_Responses["Date_Opened"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Recommended_Action = Convert.ToString(drInspection_Responses["Recommended_Action"]);
                this._Target_Completion_Date = drInspection_Responses["Target_Completion_Date"] != DBNull.Value ? Convert.ToDateTime(drInspection_Responses["Target_Completion_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Actual_Completion_Date = drInspection_Responses["Actual_Completion_Date"] != DBNull.Value ? Convert.ToDateTime(drInspection_Responses["Actual_Completion_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Notes = Convert.ToString(drInspection_Responses["Notes"]);
                this._UniqueVal = Convert.ToString(drInspection_Responses["UniqueVal"]);
                this._Updated_By = drInspection_Responses["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drInspection_Responses["Updated_By"]) : 0;
                this._Updated_Date = drInspection_Responses["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drInspection_Responses["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drInspection_Responses["Repeat_Deficiency"] == DBNull.Value)
                    this._Repeat_Deficiency = null;
                else
                    this._Repeat_Deficiency = (string)drInspection_Responses["Repeat_Deficiency"];
                this._Title = Convert.ToString(drInspection_Responses["Title"]);
                this._Problem_Description = Convert.ToString(drInspection_Responses["Problem_Description"]);
            }

            else
            {

                this._PK_Inspection_Responses_ID = -1;
                this._FK_Inspection_ID = -1;
                this._FK_Inspection_Question_ID = -1;
                this._Deficiency_Noted = "";
                this._Department = "";
                this._Date_Opened = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Recommended_Action = "";
                this._Target_Completion_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Actual_Completion_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Notes = "";
                this._UniqueVal = "";
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Repeat_Deficiency = null;
                this._Title = "";
                this._Problem_Description = "";
            }

        }

        /// </summary>
        public Inspection_Responses(int FK, int PK_Inspection_ID)
        {

            DataTable dtInspection_Responses = SelectByFK(FK, PK_Inspection_ID).Tables[0];

            if (dtInspection_Responses.Rows.Count > 0)
            {
                DataRow drInspection_Responses = dtInspection_Responses.Rows[0];

                this._PK_Inspection_Responses_ID = drInspection_Responses["PK_Inspection_Responses_ID"] != DBNull.Value ? Convert.ToInt32(drInspection_Responses["PK_Inspection_Responses_ID"]) : 0;
                this._FK_Inspection_ID = drInspection_Responses["FK_Inspection_ID"] != DBNull.Value ? Convert.ToInt32(drInspection_Responses["FK_Inspection_ID"]) : 0;
                this._FK_Inspection_Question_ID = drInspection_Responses["FK_Inspection_Question_ID"] != DBNull.Value ? Convert.ToInt32(drInspection_Responses["FK_Inspection_Question_ID"]) : 0;
                this._Deficiency_Noted = Convert.ToString(drInspection_Responses["Deficiency_Noted"]);
                this._Department = Convert.ToString(drInspection_Responses["Department"]);
                this._Date_Opened = drInspection_Responses["Date_Opened"] != DBNull.Value ? Convert.ToDateTime(drInspection_Responses["Date_Opened"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Recommended_Action = Convert.ToString(drInspection_Responses["Recommended_Action"]);
                this._Target_Completion_Date = drInspection_Responses["Target_Completion_Date"] != DBNull.Value ? Convert.ToDateTime(drInspection_Responses["Target_Completion_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Actual_Completion_Date = drInspection_Responses["Actual_Completion_Date"] != DBNull.Value ? Convert.ToDateTime(drInspection_Responses["Actual_Completion_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Notes = Convert.ToString(drInspection_Responses["Notes"]);
                this._UniqueVal = Convert.ToString(drInspection_Responses["UniqueVal"]);
                this._Updated_By = drInspection_Responses["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drInspection_Responses["Updated_By"]) : 0;
                this._Updated_Date = drInspection_Responses["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drInspection_Responses["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Title = Convert.ToString(drInspection_Responses["Title"]);
                this._Problem_Description = Convert.ToString(drInspection_Responses["Problem_Description"]);
            }

            else
            {

                this._PK_Inspection_Responses_ID = -1;
                this._FK_Inspection_ID = -1;
                this._FK_Inspection_Question_ID = -1;
                this._Deficiency_Noted = "";
                this._Department = "";
                this._Date_Opened = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Recommended_Action = "";
                this._Target_Completion_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Actual_Completion_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Notes = "";
                this._UniqueVal = "";
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Problem_Description = "";
                this._Title = "";
            }

        }

        #endregion


        #region Methods

        /// <summary>
        /// Inserts a record into the Inspection_Responses table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_ResponsesInsert");

            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, this._FK_Inspection_ID);
            db.AddInParameter(dbCommand, "FK_Inspection_Question_ID", DbType.Int32, this._FK_Inspection_Question_ID);
            db.AddInParameter(dbCommand, "Deficiency_Noted", DbType.String, this._Deficiency_Noted);
            db.AddInParameter(dbCommand, "Department", DbType.String, this._Department);

            if (this._Date_Opened != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, this._Date_Opened);
            else
                db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Recommended_Action", DbType.String, this._Recommended_Action);

            if (this._Target_Completion_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, this._Target_Completion_Date);
            else
                db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, DBNull.Value);

            if (this._Actual_Completion_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Actual_Completion_Date", DbType.DateTime, this._Actual_Completion_Date);
            else
                db.AddInParameter(dbCommand, "Actual_Completion_Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
            db.AddInParameter(dbCommand, "UniqueVal", DbType.String, this._UniqueVal);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
            if (string.IsNullOrEmpty(this._Repeat_Deficiency))
                db.AddInParameter(dbCommand, "Repeat_Deficiency", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Repeat_Deficiency", DbType.String, this._Repeat_Deficiency);

            db.AddInParameter(dbCommand, "Title", DbType.String, this._Title);
            db.AddInParameter(dbCommand, "Problem_Description", DbType.String, this._Problem_Description);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Inspection_Responses table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Inspection_Responses_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_ResponsesSelectByPK");

            db.AddInParameter(dbCommand, "PK_Inspection_Responses_ID", DbType.Int32, pK_Inspection_Responses_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Inspection_Responses table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(int FK_Inspection_Question_ID, int PK_Inspection_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_ResponsesSelectByFK");

            db.AddInParameter(dbCommand, "FK_Inspection_Question_ID", DbType.Int32, FK_Inspection_Question_ID);
            db.AddInParameter(dbCommand, "PK_Inspection_ID", DbType.Int32, PK_Inspection_ID);

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Selects all records from the Inspection_Responses table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_ResponsesSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Inspection_Responses table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_ResponsesUpdate");

            db.AddInParameter(dbCommand, "PK_Inspection_Responses_ID", DbType.Int32, this._PK_Inspection_Responses_ID);
            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, this._FK_Inspection_ID);
            db.AddInParameter(dbCommand, "FK_Inspection_Question_ID", DbType.Int32, this._FK_Inspection_Question_ID);
            db.AddInParameter(dbCommand, "Deficiency_Noted", DbType.String, this._Deficiency_Noted);
            db.AddInParameter(dbCommand, "Department", DbType.String, this._Department);

            if (this._Date_Opened != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, this._Date_Opened);
            else
                db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Recommended_Action", DbType.String, this._Recommended_Action);

            if (this._Target_Completion_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, this._Target_Completion_Date);
            else
                db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, DBNull.Value);

            if (this._Actual_Completion_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Actual_Completion_Date", DbType.DateTime, this._Actual_Completion_Date);
            else
                db.AddInParameter(dbCommand, "Actual_Completion_Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
            db.AddInParameter(dbCommand, "UniqueVal", DbType.String, this._UniqueVal);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
            if (string.IsNullOrEmpty(this._Repeat_Deficiency))
                db.AddInParameter(dbCommand, "Repeat_Deficiency", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Repeat_Deficiency", DbType.String, this._Repeat_Deficiency);

            db.AddInParameter(dbCommand, "Title", DbType.String, this._Title);
            db.AddInParameter(dbCommand, "Problem_Description", DbType.String, this._Problem_Description);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Inspection_Responses table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Inspection_Responses_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_ResponsesDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Inspection_Responses_ID", DbType.Int32, pK_Inspection_Responses_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
