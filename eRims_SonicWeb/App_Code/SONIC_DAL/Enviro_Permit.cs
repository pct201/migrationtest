using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Enviro_Permit table.
    /// </summary>
    public sealed class Enviro_Permit
    {

        #region Fields


        private int _PK_Enviro_Permit_ID;
        private int _FK_LU_Location_ID;
        private string _type;
        private Nullable<bool> _required;
        private string _Application_number;
        private string _Certificate_number;
        private Nullable<DateTime> _Filing_date;
        private Nullable<DateTime> _Begin_date;
        private Nullable<DateTime> _End_date;
        private Nullable<DateTime> _Last_Inspection_date;
        private Nullable<DateTime> _Next_Inspection_Date;
        private Nullable<DateTime> _Next_Report_Date;
        private string _Notes;
        private DateTime _Update_Date;
        private string _Updated_By;
        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Enviro_Permit_ID value.
        /// </summary>
        public int PK_Enviro_Permit_ID
        {
            get { return _PK_Enviro_Permit_ID; }
            set { _PK_Enviro_Permit_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_LU_Location_ID value.
        /// </summary>
        public int FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the type value.
        /// </summary>
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }


        /// <summary> 
        /// Gets or sets the required value.
        /// </summary>
        public Nullable<bool> required
        {
            get { return _required; }
            set { _required = value; }
        }


        /// <summary> 
        /// Gets or sets the Application_number value.
        /// </summary>
        public string Application_number
        {
            get { return _Application_number; }
            set { _Application_number = value; }
        }


        /// <summary> 
        /// Gets or sets the Certificate_number value.
        /// </summary>
        public string Certificate_number
        {
            get { return _Certificate_number; }
            set { _Certificate_number = value; }
        }


        /// <summary> 
        /// Gets or sets the Filing_date value.
        /// </summary>
        public Nullable<DateTime> Filing_date
        {
            get { return _Filing_date; }
            set { _Filing_date = value; }
        }


        /// <summary> 
        /// Gets or sets the Begin_date value.
        /// </summary>
        public Nullable<DateTime> Begin_date
        {
            get { return _Begin_date; }
            set { _Begin_date = value; }
        }


        /// <summary> 
        /// Gets or sets the End_date value.
        /// </summary>
        public Nullable<DateTime> End_date
        {
            get { return _End_date; }
            set { _End_date = value; }
        }


        /// <summary> 
        /// Gets or sets the Last_Inspection_date value.
        /// </summary>
        public Nullable<DateTime> Last_Inspection_date
        {
            get { return _Last_Inspection_date; }
            set { _Last_Inspection_date = value; }
        }


        /// <summary> 
        /// Gets or sets the Next_Inspection_Date value.
        /// </summary>
        public Nullable<DateTime> Next_Inspection_Date
        {
            get { return _Next_Inspection_Date; }
            set { _Next_Inspection_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Next_Report_Date value.
        /// </summary>
        public Nullable<DateTime> Next_Report_Date
        {
            get { return _Next_Report_Date; }
            set { _Next_Report_Date = value; }
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
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
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


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Enviro_Permit class. with the default value.

        /// </summary>
        public Enviro_Permit()
        {

            this._PK_Enviro_Permit_ID = -1;
            this._FK_LU_Location_ID = -1;
            this._type = "";
            this._required = null;
            this._Application_number = "";
            this._Certificate_number = "";
            this._Filing_date = null;
            this._Begin_date = null;
            this._End_date = null;
            this._Last_Inspection_date = null;
            this._Next_Inspection_Date = null;
            this._Next_Report_Date = null;
            this._Notes = "";
            this._Updated_By = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 

        /// Initializes a new instance of the Enviro_Permit class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Enviro_Permit(int PK)
        {

            DataTable dtEnviro_Permit = SelectByPK(PK).Tables[0];

            if (dtEnviro_Permit.Rows.Count > 0)
            {

                DataRow drEnviro_Permit = dtEnviro_Permit.Rows[0];

                this._PK_Enviro_Permit_ID = drEnviro_Permit["PK_Enviro_Permit_ID"] != DBNull.Value ? Convert.ToInt32(drEnviro_Permit["PK_Enviro_Permit_ID"]) : 0;
                this._FK_LU_Location_ID = drEnviro_Permit["FK_LU_Location_ID"] != DBNull.Value ? Convert.ToInt32(drEnviro_Permit["FK_LU_Location_ID"]) : 0;
                this._type = Convert.ToString(drEnviro_Permit["type"]);
                this._required = clsGeneral.GetNullBooleanValue(drEnviro_Permit["required"]);
                this._Application_number = Convert.ToString(drEnviro_Permit["Application_number"].ToString());
                this._Certificate_number = Convert.ToString(drEnviro_Permit["Certificate_number"].ToString());
                this._Filing_date = clsGeneral.FormatNullDateToStore(drEnviro_Permit["Filing_date"].ToString());
                this._Begin_date = clsGeneral.FormatNullDateToStore(drEnviro_Permit["Begin_date"].ToString());
                this._End_date = clsGeneral.FormatNullDateToStore(drEnviro_Permit["End_date"].ToString());
                this._Last_Inspection_date = clsGeneral.FormatNullDateToStore(drEnviro_Permit["Last_Inspection_date"].ToString());
                this._Next_Inspection_Date = clsGeneral.FormatNullDateToStore(drEnviro_Permit["Next_Inspection_Date"].ToString());
                this._Next_Report_Date = clsGeneral.FormatNullDateToStore(drEnviro_Permit["Next_Report_Date"].ToString());
                this._Notes = Convert.ToString(drEnviro_Permit["Notes"]);
                this._Updated_By = drEnviro_Permit["Updated_By"].ToString();
                this._Update_Date = drEnviro_Permit["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Permit["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._PK_Enviro_Permit_ID = -1;
                this._FK_LU_Location_ID = -1;
                this._type = "";
                this._required = null;
                this._Application_number = "";
                this._Certificate_number = "";
                this._Filing_date = null;
                this._Begin_date = null;
                this._End_date = null;
                this._Last_Inspection_date = null;
                this._Next_Inspection_Date = null;
                this._Next_Report_Date = null;
                this._Notes = "";
                this._Updated_By = "";
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }



        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the Enviro_Permit table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_PermitInsert");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "type", DbType.String, this._type);
            db.AddInParameter(dbCommand, "required", DbType.Boolean, this._required);
            db.AddInParameter(dbCommand, "Application_number", DbType.String, this._Application_number);
            db.AddInParameter(dbCommand, "Certificate_number", DbType.String, this._Certificate_number);
            db.AddInParameter(dbCommand, "Filing_date", DbType.DateTime, this._Filing_date);
            db.AddInParameter(dbCommand, "Begin_date", DbType.DateTime, this._Begin_date);
            db.AddInParameter(dbCommand, "End_date", DbType.DateTime, this._End_date);
            db.AddInParameter(dbCommand, "Last_Inspection_date", DbType.DateTime, this._Last_Inspection_date);
            db.AddInParameter(dbCommand, "Next_Inspection_Date", DbType.DateTime, this._Next_Inspection_Date);
            db.AddInParameter(dbCommand, "Next_Report_Date", DbType.DateTime, this._Next_Report_Date);
            db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, clsSession.UserID);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Enviro_Permit table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Enviro_Permit_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_PermitSelectByPK");

            db.AddInParameter(dbCommand, "PK_Enviro_Permit_ID", DbType.Int32, pK_Enviro_Permit_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Enviro_Permit table by a Foreign Key LocationID.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByLocationID(int Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_PermitSelectByLU_Location_ID");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Enviro_Permit table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_PermitSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Enviro_Permit table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_PermitUpdate");

            db.AddInParameter(dbCommand, "PK_Enviro_Permit_ID", DbType.Int32, this._PK_Enviro_Permit_ID);
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "type", DbType.String, this._type);
            db.AddInParameter(dbCommand, "required", DbType.Boolean, this._required);
            db.AddInParameter(dbCommand, "Application_number", DbType.String, this._Application_number);
            db.AddInParameter(dbCommand, "Certificate_number", DbType.String, this._Certificate_number);
            db.AddInParameter(dbCommand, "Filing_date", DbType.DateTime, this._Filing_date);
            db.AddInParameter(dbCommand, "Begin_date", DbType.DateTime, this._Begin_date);
            db.AddInParameter(dbCommand, "End_date", DbType.DateTime, this._End_date);
            db.AddInParameter(dbCommand, "Last_Inspection_date", DbType.DateTime, this._Last_Inspection_date);
            db.AddInParameter(dbCommand, "Next_Inspection_Date", DbType.DateTime, this._Next_Inspection_Date);
            db.AddInParameter(dbCommand, "Next_Report_Date", DbType.DateTime, this._Next_Report_Date);
            db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, clsSession.UserID);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Enviro_Permit table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Enviro_Permit_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_PermitDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Enviro_Permit_ID", DbType.Int32, pK_Enviro_Permit_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
