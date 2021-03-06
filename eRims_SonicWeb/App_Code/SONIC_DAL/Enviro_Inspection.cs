using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Enviro_Inspection table.
    /// </summary>
    public sealed class Enviro_Inspection
    {
        #region Fields


        private int _PK_Enviro_Inspection_ID;
        private int _FK_LU_Location_ID;
        private string _Frequency;
        private Nullable<DateTime> _Last_Date;
        private Nullable<DateTime> _Next_Date;
        private Nullable<DateTime> _Next_Report_Date;
        private Nullable<decimal> _Cost;
        private string _Notes;
        private DateTime _Update_Date;
        private string _Updated_By;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Enviro_Inspection_ID value.
        /// </summary>
        public int PK_Enviro_Inspection_ID
        {
            get { return _PK_Enviro_Inspection_ID; }
            set { _PK_Enviro_Inspection_ID = value; }
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
        /// Gets or sets the Frequency value.
        /// </summary>
        public string Frequency
        {
            get { return _Frequency; }
            set { _Frequency = value; }
        }


        /// <summary> 
        /// Gets or sets the Last_Date value.
        /// </summary>
        public Nullable<DateTime> Last_Date
        {
            get { return _Last_Date; }
            set { _Last_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Next_Date value.
        /// </summary>
        public Nullable<DateTime> Next_Date
        {
            get { return _Next_Date; }
            set { _Next_Date = value; }
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
        /// Gets or sets the Cost value.
        /// </summary>
        public Nullable<decimal> Cost
        {
            get { return _Cost; }
            set { _Cost = value; }
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

        /// Initializes a new instance of the Enviro_Inspection class. with the default value.

        /// </summary>
        public Enviro_Inspection()
        {

            this._PK_Enviro_Inspection_ID = -1;
            this._FK_LU_Location_ID = -1;
            this._Frequency = "";
            this._Last_Date = null;
            this._Next_Date = null;
            this._Next_Report_Date = null;
            this._Cost = null;
            this._Notes = "";
            this._Updated_By = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }



        /// <summary> 

        /// Initializes a new instance of the Enviro_Inspection class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Enviro_Inspection(int PK)
        {

            DataTable dtEnviro_Inspection = SelectByPK(PK).Tables[0];

            if (dtEnviro_Inspection.Rows.Count > 0)
            {

                DataRow drEnviro_Inspection = dtEnviro_Inspection.Rows[0];

                this._PK_Enviro_Inspection_ID = drEnviro_Inspection["PK_Enviro_Inspection_ID"] != DBNull.Value ? Convert.ToInt32(drEnviro_Inspection["PK_Enviro_Inspection_ID"]) : 0;
                this._FK_LU_Location_ID = drEnviro_Inspection["FK_LU_Location_ID"] != DBNull.Value ? Convert.ToInt32(drEnviro_Inspection["FK_LU_Location_ID"]) : 0;
                this._Frequency = Convert.ToString(drEnviro_Inspection["Frequency"]);
                this._Last_Date = clsGeneral.FormatNullDateToStore(drEnviro_Inspection["Last_Date"].ToString());
                this._Next_Date = clsGeneral.FormatNullDateToStore(drEnviro_Inspection["Next_Date"].ToString());
                this._Next_Report_Date = clsGeneral.FormatNullDateToStore(drEnviro_Inspection["Next_Report_Date"].ToString());

                if (drEnviro_Inspection["Cost"] == null || drEnviro_Inspection["Cost"] == DBNull.Value)
                    this._Cost = null;
                else
                    this._Cost = Convert.ToDecimal(drEnviro_Inspection["Cost"]);

                this._Notes = Convert.ToString(drEnviro_Inspection["Notes"]);
                this._Updated_By = drEnviro_Inspection["Updated_By"].ToString();
                this._Update_Date = drEnviro_Inspection["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Inspection["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

            else
            {
                this._PK_Enviro_Inspection_ID = -1;
                this._FK_LU_Location_ID = -1;
                this._Frequency = "";
                this._Last_Date = null;
                this._Next_Date = null;
                this._Next_Report_Date = null;
                this._Cost = null;
                this._Notes = "";
                this._Updated_By = "";
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

        }



        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the Enviro_Inspection table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_InspectionInsert");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Frequency", DbType.String, this._Frequency);
            db.AddInParameter(dbCommand, "Last_Date", DbType.DateTime, this._Last_Date);
            db.AddInParameter(dbCommand, "Next_Date", DbType.DateTime, this._Next_Date);
            db.AddInParameter(dbCommand, "Next_Report_Date", DbType.DateTime, this._Next_Report_Date);
            db.AddInParameter(dbCommand, "Cost", DbType.Decimal, this._Cost);
            db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, clsSession.UserID);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Enviro_Inspection table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Enviro_Inspection_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_InspectionSelectByPK");

            db.AddInParameter(dbCommand, "PK_Enviro_Inspection_ID", DbType.Int32, pK_Enviro_Inspection_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Enviro_Inspection table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_InspectionSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Enviro_Inspection table by a Foreign Key LocationID.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByLocationID(int Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_InspectionSelectByLU_Location_ID");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Enviro_Inspection table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_InspectionUpdate");

            db.AddInParameter(dbCommand, "PK_Enviro_Inspection_ID", DbType.Int32, this._PK_Enviro_Inspection_ID);
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Frequency", DbType.String, this._Frequency);
            db.AddInParameter(dbCommand, "Last_Date", DbType.DateTime, this._Last_Date);
            db.AddInParameter(dbCommand, "Next_Date", DbType.DateTime, this._Next_Date);
            db.AddInParameter(dbCommand, "Next_Report_Date", DbType.DateTime, this._Next_Report_Date);
            db.AddInParameter(dbCommand, "Cost", DbType.Decimal, this._Cost);
            db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, clsSession.UserID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Enviro_Inspection table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Enviro_Inspection_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_InspectionDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Enviro_Inspection_ID", DbType.Int32, pK_Enviro_Inspection_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
