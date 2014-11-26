using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Configuration;

namespace SonicInspectioniPhone
{
    /// <summary>
    /// Data access class for Inspection_Responses table.
    /// </summary>
    public sealed class Inspection_Responses
    {
        #region Fields

        public string strConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["SonicConnection"].ConnectionString);
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

        #endregion

        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Inspection_Responses class. with the default value.
        /// </summary>
        public Inspection_Responses()
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
        }      

        #endregion

        #region Methods

        /// <summary>
        /// Inserts a record into the Inspection_Responses table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_ResponsesInsert");

            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, this._FK_Inspection_ID);
            db.AddInParameter(dbCommand, "FK_Inspection_Question_ID", DbType.Int32, this._FK_Inspection_Question_ID);
            db.AddInParameter(dbCommand, "Deficiency_Noted", DbType.String, this._Deficiency_Noted);
            db.AddInParameter(dbCommand, "Department", DbType.String, this._Department);

            if (this._Date_Opened!=null && this._Date_Opened != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, this._Date_Opened);
            else
                db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Recommended_Action", DbType.String, this._Recommended_Action);

            if (this._Date_Opened != null && this._Target_Completion_Date != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, this._Target_Completion_Date);
            else
                db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, DBNull.Value);

            if (this._Date_Opened != null && this._Actual_Completion_Date != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
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
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }
      
       /// <summary>
        /// Updates a record in the Inspection_Responses table.
        /// </summary>
        public void Update()
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_ResponsesUpdate");

            db.AddInParameter(dbCommand, "PK_Inspection_Responses_ID", DbType.Int32, this._PK_Inspection_Responses_ID);
            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, this._FK_Inspection_ID);
            db.AddInParameter(dbCommand, "FK_Inspection_Question_ID", DbType.Int32, this._FK_Inspection_Question_ID);
            db.AddInParameter(dbCommand, "Deficiency_Noted", DbType.String, this._Deficiency_Noted);
            db.AddInParameter(dbCommand, "Department", DbType.String, this._Department);

            if (this._Date_Opened != null && this._Date_Opened != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, this._Date_Opened);
            else
                db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Recommended_Action", DbType.String, this._Recommended_Action);

            if (this._Date_Opened != null && this._Target_Completion_Date != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, this._Target_Completion_Date);
            else
                db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, DBNull.Value);

            if (this._Date_Opened != null && this._Actual_Completion_Date != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
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
            db.ExecuteNonQuery(dbCommand);
        }       

        #endregion
    }
}
