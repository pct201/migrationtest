using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for EPM_Project_Cost table.
    /// </summary>
    public sealed class clsEPM_Project_Cost
    {

        #region Private variables used to hold the property values

        private decimal? _PK_EPM_Project_Cost;
        private decimal? _FK_EPM_Identification;
        private decimal? _FK_LU_EPM_Project_Phase;
        private string _Comments_Description;
        private decimal? _Budget;
        private DateTime? _Date_Budget_Established;
        private decimal? _Estimated_Cost;
        private DateTime? _Date_Estimated_Cost_Derived;
        private decimal? _Original_Estimated_Cost;
        private DateTime? _Date_Original_Estimated_Cost_Derived;
        private decimal? _Actual_Cost;
        private DateTime? _Date_Actual_Cost_Incurred;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_EPM_Project_Cost value.
        /// </summary>
        public decimal? PK_EPM_Project_Cost
        {
            get { return _PK_EPM_Project_Cost; }
            set { _PK_EPM_Project_Cost = value; }
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
        /// Gets or sets the FK_LU_EPM_Project_Phase value.
        /// </summary>
        public decimal? FK_LU_EPM_Project_Phase
        {
            get { return _FK_LU_EPM_Project_Phase; }
            set { _FK_LU_EPM_Project_Phase = value; }
        }

        /// <summary>
        /// Gets or sets the Comments_Description value.
        /// </summary>
        public string Comments_Description
        {
            get { return _Comments_Description; }
            set { _Comments_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Budget value.
        /// </summary>
        public decimal? Budget
        {
            get { return _Budget; }
            set { _Budget = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Budget_Established value.
        /// </summary>
        public DateTime? Date_Budget_Established
        {
            get { return _Date_Budget_Established; }
            set { _Date_Budget_Established = value; }
        }

        /// <summary>
        /// Gets or sets the Estimated_Cost value.
        /// </summary>
        public decimal? Estimated_Cost
        {
            get { return _Estimated_Cost; }
            set { _Estimated_Cost = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Estimated_Cost_Derived value.
        /// </summary>
        public DateTime? Date_Estimated_Cost_Derived
        {
            get { return _Date_Estimated_Cost_Derived; }
            set { _Date_Estimated_Cost_Derived = value; }
        }

        /// <summary>
        /// Gets or sets the Original_Estimated_Cost value.
        /// </summary>
        public decimal? Original_Estimated_Cost
        {
            get { return _Original_Estimated_Cost; }
            set { _Original_Estimated_Cost = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Original_Estimated_Cost_Derived value.
        /// </summary>
        public DateTime? Date_Original_Estimated_Cost_Derived
        {
            get { return _Date_Original_Estimated_Cost_Derived; }
            set { _Date_Original_Estimated_Cost_Derived = value; }
        }

        /// <summary>
        /// Gets or sets the Actual_Cost value.
        /// </summary>
        public decimal? Actual_Cost
        {
            get { return _Actual_Cost; }
            set { _Actual_Cost = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Actual_Cost_Incurred value.
        /// </summary>
        public DateTime? Date_Actual_Cost_Incurred
        {
            get { return _Date_Actual_Cost_Incurred; }
            set { _Date_Actual_Cost_Incurred = value; }
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
        /// Initializes a new instance of the clsEPM_Project_Cost class with default value.
        /// </summary>
        public clsEPM_Project_Cost()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_Project_Cost class based on Primary Key.
        /// </summary>
        public clsEPM_Project_Cost(decimal pK_EPM_Project_Cost)
        {
            DataTable dtEPM_Project_Cost = SelectByPK(pK_EPM_Project_Cost).Tables[0];

            if (dtEPM_Project_Cost.Rows.Count == 1)
            {
                SetValue(dtEPM_Project_Cost.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsEPM_Project_Cost class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drEPM_Project_Cost)
        {
            if (drEPM_Project_Cost["PK_EPM_Project_Cost"] == DBNull.Value)
                this._PK_EPM_Project_Cost = null;
            else
                this._PK_EPM_Project_Cost = (decimal?)drEPM_Project_Cost["PK_EPM_Project_Cost"];

            if (drEPM_Project_Cost["FK_EPM_Identification"] == DBNull.Value)
                this._FK_EPM_Identification = null;
            else
                this._FK_EPM_Identification = (decimal?)drEPM_Project_Cost["FK_EPM_Identification"];

            if (drEPM_Project_Cost["FK_LU_EPM_Project_Phase"] == DBNull.Value)
                this._FK_LU_EPM_Project_Phase = null;
            else
                this._FK_LU_EPM_Project_Phase = (decimal?)drEPM_Project_Cost["FK_LU_EPM_Project_Phase"];

            if (drEPM_Project_Cost["Comments_Description"] == DBNull.Value)
                this._Comments_Description = null;
            else
                this._Comments_Description = (string)drEPM_Project_Cost["Comments_Description"];

            if (drEPM_Project_Cost["Budget"] == DBNull.Value)
                this._Budget = null;
            else
                this._Budget = (decimal?)drEPM_Project_Cost["Budget"];

            if (drEPM_Project_Cost["Date_Budget_Established"] == DBNull.Value)
                this._Date_Budget_Established = null;
            else
                this._Date_Budget_Established = (DateTime?)drEPM_Project_Cost["Date_Budget_Established"];

            if (drEPM_Project_Cost["Estimated_Cost"] == DBNull.Value)
                this._Estimated_Cost = null;
            else
                this._Estimated_Cost = (decimal?)drEPM_Project_Cost["Estimated_Cost"];

            if (drEPM_Project_Cost["Date_Estimated_Cost_Derived"] == DBNull.Value)
                this._Date_Estimated_Cost_Derived = null;
            else
                this._Date_Estimated_Cost_Derived = (DateTime?)drEPM_Project_Cost["Date_Estimated_Cost_Derived"];

            if (drEPM_Project_Cost["Original_Estimated_Cost"] == DBNull.Value)
                this._Original_Estimated_Cost = null;
            else
                this._Original_Estimated_Cost = (decimal?)drEPM_Project_Cost["Original_Estimated_Cost"];

            if (drEPM_Project_Cost["Date_Original_Estimated_Cost_Derived"] == DBNull.Value)
                this._Date_Original_Estimated_Cost_Derived = null;
            else
                this._Date_Original_Estimated_Cost_Derived = (DateTime?)drEPM_Project_Cost["Date_Original_Estimated_Cost_Derived"];

            if (drEPM_Project_Cost["Actual_Cost"] == DBNull.Value)
                this._Actual_Cost = null;
            else
                this._Actual_Cost = (decimal?)drEPM_Project_Cost["Actual_Cost"];

            if (drEPM_Project_Cost["Date_Actual_Cost_Incurred"] == DBNull.Value)
                this._Date_Actual_Cost_Incurred = null;
            else
                this._Date_Actual_Cost_Incurred = (DateTime?)drEPM_Project_Cost["Date_Actual_Cost_Incurred"];

            if (drEPM_Project_Cost["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drEPM_Project_Cost["Updated_By"];

            if (drEPM_Project_Cost["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drEPM_Project_Cost["Update_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the EPM_Project_Cost table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Project_CostInsert");


            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            db.AddInParameter(dbCommand, "FK_LU_EPM_Project_Phase", DbType.Decimal, this._FK_LU_EPM_Project_Phase);

            if (string.IsNullOrEmpty(this._Comments_Description))
                db.AddInParameter(dbCommand, "Comments_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments_Description", DbType.String, this._Comments_Description);

            db.AddInParameter(dbCommand, "Budget", DbType.Decimal, this._Budget);

            db.AddInParameter(dbCommand, "Date_Budget_Established", DbType.DateTime, this._Date_Budget_Established);

            db.AddInParameter(dbCommand, "Estimated_Cost", DbType.Decimal, this._Estimated_Cost);

            db.AddInParameter(dbCommand, "Date_Estimated_Cost_Derived", DbType.DateTime, this._Date_Estimated_Cost_Derived);

            db.AddInParameter(dbCommand, "Original_Estimated_Cost", DbType.Decimal, this._Original_Estimated_Cost);

            db.AddInParameter(dbCommand, "Date_Original_Estimated_Cost_Derived", DbType.DateTime, this._Date_Original_Estimated_Cost_Derived);

            db.AddInParameter(dbCommand, "Actual_Cost", DbType.Decimal, this._Actual_Cost);

            db.AddInParameter(dbCommand, "Date_Actual_Cost_Incurred", DbType.DateTime, this._Date_Actual_Cost_Incurred);

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
        /// Selects a single record from the EPM_Project_Cost table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_EPM_Project_Cost)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Project_CostSelectByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Project_Cost", DbType.Decimal, pK_EPM_Project_Cost);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the EPM_Project_Cost table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Project_CostSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the EPM_Project_Cost table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Project_CostUpdate");


            db.AddInParameter(dbCommand, "PK_EPM_Project_Cost", DbType.Decimal, this._PK_EPM_Project_Cost);

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            db.AddInParameter(dbCommand, "FK_LU_EPM_Project_Phase", DbType.Decimal, this._FK_LU_EPM_Project_Phase);

            if (string.IsNullOrEmpty(this._Comments_Description))
                db.AddInParameter(dbCommand, "Comments_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments_Description", DbType.String, this._Comments_Description);

            db.AddInParameter(dbCommand, "Budget", DbType.Decimal, this._Budget);

            db.AddInParameter(dbCommand, "Date_Budget_Established", DbType.DateTime, this._Date_Budget_Established);

            db.AddInParameter(dbCommand, "Estimated_Cost", DbType.Decimal, this._Estimated_Cost);

            db.AddInParameter(dbCommand, "Date_Estimated_Cost_Derived", DbType.DateTime, this._Date_Estimated_Cost_Derived);

            db.AddInParameter(dbCommand, "Original_Estimated_Cost", DbType.Decimal, this._Original_Estimated_Cost);

            db.AddInParameter(dbCommand, "Date_Original_Estimated_Cost_Derived", DbType.DateTime, this._Date_Original_Estimated_Cost_Derived);

            db.AddInParameter(dbCommand, "Actual_Cost", DbType.Decimal, this._Actual_Cost);

            db.AddInParameter(dbCommand, "Date_Actual_Cost_Incurred", DbType.DateTime, this._Date_Actual_Cost_Incurred);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the EPM_Project_Cost table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_EPM_Project_Cost)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Project_CostDeleteByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Project_Cost", DbType.Decimal, pK_EPM_Project_Cost);

            db.ExecuteNonQuery(dbCommand);
        }


        public static DataSet SelectByFK(decimal FK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Project_CostSelectByFK");

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, FK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetCompanionProjectCost(decimal PK_EPM_Identification, decimal FK_LU_Location_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Project_Cost_GetCompanionProjectCost");

            db.AddInParameter(dbCommand, "PK_EPM_Identification", DbType.Decimal, PK_EPM_Identification);
            db.AddInParameter(dbCommand, "FK_LU_Location_Id", DbType.Decimal, FK_LU_Location_Id);

            return db.ExecuteDataSet(dbCommand);
        }

        public static int GetCostPercentage(decimal PK_EPM_Project_Cost)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Project_Cost_GetCostPercentage");

            db.AddInParameter(dbCommand, "PK_EPM_Project_Cost", DbType.Decimal, PK_EPM_Project_Cost);

            return Convert.ToInt32(db.ExecuteScalar(dbCommand));
        }
    }
}
