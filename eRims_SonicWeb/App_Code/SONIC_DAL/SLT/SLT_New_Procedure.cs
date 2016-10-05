using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for SLT_New_Procedure table.
    /// </summary>
    public sealed class SLT_New_Procedure
    {

        #region Private variables used to hold the property values

        private decimal? _PK_SLT_New_Procedure;
        private decimal? _FK_SLT_Meeting;
        private decimal? _FK_LU_Procedure_Source;
        private decimal? _FK_LU_Importance;
        private string _Procedure_Description;
        private string _Action_Item;
        private decimal? _Assigned_To;
        private DateTime? _Target_Completion_Date;
        private DateTime? _Date_Completed;
        private decimal? _FK_LU_Item_Status;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private int? _Year;
        private decimal? _FK_SLT_Meeting_Schedule;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_SLT_New_Procedure value.
        /// </summary>
        public decimal? PK_SLT_New_Procedure
        {
            get { return _PK_SLT_New_Procedure; }
            set { _PK_SLT_New_Procedure = value; }
        }

        /// <summary>
        /// Gets or sets the FK_SLT_Meeting value.
        /// </summary>
        public decimal? FK_SLT_Meeting
        {
            get { return _FK_SLT_Meeting; }
            set { _FK_SLT_Meeting = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Procedure_Source value.
        /// </summary>
        public decimal? FK_LU_Procedure_Source
        {
            get { return _FK_LU_Procedure_Source; }
            set { _FK_LU_Procedure_Source = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Importance value.
        /// </summary>
        public decimal? FK_LU_Importance
        {
            get { return _FK_LU_Importance; }
            set { _FK_LU_Importance = value; }
        }

        /// <summary>
        /// Gets or sets the Procedure_Description value.
        /// </summary>
        public string Procedure_Description
        {
            get { return _Procedure_Description; }
            set { _Procedure_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Action_Item value.
        /// </summary>
        public string Action_Item
        {
            get { return _Action_Item; }
            set { _Action_Item = value; }
        }

        /// <summary>
        /// Gets or sets the Assigned_To value.
        /// </summary>
        public decimal? Assigned_To
        {
            get { return _Assigned_To; }
            set { _Assigned_To = value; }
        }

        /// <summary>
        /// Gets or sets the Target_Completion_Date value.
        /// </summary>
        public DateTime? Target_Completion_Date
        {
            get { return _Target_Completion_Date; }
            set { _Target_Completion_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Completed value.
        /// </summary>
        public DateTime? Date_Completed
        {
            get { return _Date_Completed; }
            set { _Date_Completed = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Item_Status value.
        /// </summary>
        public decimal? FK_LU_Item_Status
        {
            get { return _FK_LU_Item_Status; }
            set { _FK_LU_Item_Status = value; }
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

        public int? Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        /// <summary>
        /// Gets or sets the FK_SLT_Meeting_Schedule value.
        /// </summary>
        public decimal? FK_SLT_Meeting_Schedule
        {
            get { return _FK_SLT_Meeting_Schedule; }
            set { _FK_SLT_Meeting_Schedule = value; }
        }
        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsSLT_New_Procedure class with default value.
        /// </summary>
        public SLT_New_Procedure()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsSLT_New_Procedure class based on Primary Key.
        /// </summary>
        public SLT_New_Procedure(decimal pK_SLT_New_Procedure)
        {
            DataTable dtSLT_New_Procedure = SelectByPK(pK_SLT_New_Procedure).Tables[0];

            if (dtSLT_New_Procedure.Rows.Count == 1)
            {
                SetValue(dtSLT_New_Procedure.Rows[0]);

            }

        }
        /// <summary>
        /// Initializes a new instance of the clsSLT_New_Procedure class based on foreign Key.
        /// </summary>
        public SLT_New_Procedure(decimal FK_SLT_Meeting_Schedule,int Year)
        {
            DataTable dtSLT_New_Procedure = SelectByFK(FK_SLT_Meeting_Schedule,Year).Tables[0];

            if (dtSLT_New_Procedure.Rows.Count == 1)
            {
                SetValue(dtSLT_New_Procedure.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsSLT_New_Procedure class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drSLT_New_Procedure)
        {
            if (drSLT_New_Procedure["PK_SLT_New_Procedure"] == DBNull.Value)
                this._PK_SLT_New_Procedure = null;
            else
                this._PK_SLT_New_Procedure = (decimal?)drSLT_New_Procedure["PK_SLT_New_Procedure"];

            if (drSLT_New_Procedure["FK_SLT_Meeting"] == DBNull.Value)
                this._FK_SLT_Meeting = null;
            else
                this._FK_SLT_Meeting = (decimal?)drSLT_New_Procedure["FK_SLT_Meeting"];

            if (drSLT_New_Procedure["FK_LU_Procedure_Source"] == DBNull.Value)
                this._FK_LU_Procedure_Source = null;
            else
                this._FK_LU_Procedure_Source = (decimal?)drSLT_New_Procedure["FK_LU_Procedure_Source"];

            if (drSLT_New_Procedure["FK_LU_Importance"] == DBNull.Value)
                this._FK_LU_Importance = null;
            else
                this._FK_LU_Importance = (decimal?)drSLT_New_Procedure["FK_LU_Importance"];

            if (drSLT_New_Procedure["Procedure_Description"] == DBNull.Value)
                this._Procedure_Description = null;
            else
                this._Procedure_Description = (string)drSLT_New_Procedure["Procedure_Description"];

            if (drSLT_New_Procedure["Action_Item"] == DBNull.Value)
                this._Action_Item = null;
            else
                this._Action_Item = (string)drSLT_New_Procedure["Action_Item"];

            if (drSLT_New_Procedure["Assigned_To"] == DBNull.Value)
                this._Assigned_To = null;
            else
                this._Assigned_To = (decimal?)drSLT_New_Procedure["Assigned_To"];

            if (drSLT_New_Procedure["Target_Completion_Date"] == DBNull.Value)
                this._Target_Completion_Date = null;
            else
                this._Target_Completion_Date = (DateTime?)drSLT_New_Procedure["Target_Completion_Date"];

            if (drSLT_New_Procedure["Date_Completed"] == DBNull.Value)
                this._Date_Completed = null;
            else
                this._Date_Completed = (DateTime?)drSLT_New_Procedure["Date_Completed"];

            if (drSLT_New_Procedure["FK_LU_Item_Status"] == DBNull.Value)
                this._FK_LU_Item_Status = null;
            else
                this._FK_LU_Item_Status = (decimal?)drSLT_New_Procedure["FK_LU_Item_Status"];

            if (drSLT_New_Procedure["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drSLT_New_Procedure["Updated_By"];

            if (drSLT_New_Procedure["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drSLT_New_Procedure["Update_Date"];

            if (drSLT_New_Procedure["Year"] == DBNull.Value)
                this._Year = null;
            else
                this._Year = (Int32)drSLT_New_Procedure["Year"];
            
            if (drSLT_New_Procedure["FK_SLT_Meeting_Schedule"] == DBNull.Value)
                this._FK_SLT_Meeting_Schedule = null;
            else
                this._FK_SLT_Meeting_Schedule = (decimal?)drSLT_New_Procedure["FK_SLT_Meeting_Schedule"];
        }

        #endregion

        /// <summary>
        /// Inserts a record into the SLT_New_Procedure table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_New_ProcedureInsert");


            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);

            db.AddInParameter(dbCommand, "FK_LU_Procedure_Source", DbType.Decimal, this._FK_LU_Procedure_Source);

            db.AddInParameter(dbCommand, "FK_LU_Importance", DbType.Decimal, this._FK_LU_Importance);

            if (string.IsNullOrEmpty(this._Procedure_Description))
                db.AddInParameter(dbCommand, "Procedure_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Procedure_Description", DbType.String, this._Procedure_Description);

            if (string.IsNullOrEmpty(this._Action_Item))
                db.AddInParameter(dbCommand, "Action_Item", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Action_Item", DbType.String, this._Action_Item);

            db.AddInParameter(dbCommand, "Assigned_To", DbType.Decimal, this._Assigned_To);

            db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, this._Target_Completion_Date);

            db.AddInParameter(dbCommand, "Date_Completed", DbType.DateTime, this._Date_Completed);

            db.AddInParameter(dbCommand, "FK_LU_Item_Status", DbType.Decimal, this._FK_LU_Item_Status);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, this._FK_SLT_Meeting_Schedule);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the SLT_New_Procedure table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_SLT_New_Procedure)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_New_ProcedureSelectByPK");

            db.AddInParameter(dbCommand, "PK_SLT_New_Procedure", DbType.Decimal, pK_SLT_New_Procedure);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the SLT_New_Procedure table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_New_ProcedureSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the SLT_New_Procedure table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_New_ProcedureUpdate");


            db.AddInParameter(dbCommand, "PK_SLT_New_Procedure", DbType.Decimal, this._PK_SLT_New_Procedure);

            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);

            db.AddInParameter(dbCommand, "FK_LU_Procedure_Source", DbType.Decimal, this._FK_LU_Procedure_Source);

            db.AddInParameter(dbCommand, "FK_LU_Importance", DbType.Decimal, this._FK_LU_Importance);

            if (string.IsNullOrEmpty(this._Procedure_Description))
                db.AddInParameter(dbCommand, "Procedure_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Procedure_Description", DbType.String, this._Procedure_Description);

            if (string.IsNullOrEmpty(this._Action_Item))
                db.AddInParameter(dbCommand, "Action_Item", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Action_Item", DbType.String, this._Action_Item);

            db.AddInParameter(dbCommand, "Assigned_To", DbType.Decimal, this._Assigned_To);

            db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, this._Target_Completion_Date);

            db.AddInParameter(dbCommand, "Date_Completed", DbType.DateTime, this._Date_Completed);

            db.AddInParameter(dbCommand, "FK_LU_Item_Status", DbType.Decimal, this._FK_LU_Item_Status);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, this._FK_SLT_Meeting_Schedule);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the SLT_New_Procedure table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_SLT_New_Procedure)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_New_ProcedureDeleteByPK");

            db.AddInParameter(dbCommand, "PK_SLT_New_Procedure", DbType.Decimal, pK_SLT_New_Procedure);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByFK(decimal FK_SLT_Meeting_Schedule, int intYear)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_New_ProcedureSelectByFK");

            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting_Schedule);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select By FK_Location_ID and FK_Schedule
        /// </summary>
        /// <param name="FK_SLT_Meeting_Schedule"></param>
        /// <param name="intYear"></param>
        /// <param name="FK_LU_Location_ID"></param>
        /// <returns></returns>
        public static DataSet SelectByFKBuildingAndFKSchedule(decimal FK_SLT_Meeting_Schedule, int intYear, decimal FK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_New_ProcedureSelectByFKLocationAndFKSchedule");

            db.AddInParameter(dbCommand, "PK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting_Schedule);
            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
