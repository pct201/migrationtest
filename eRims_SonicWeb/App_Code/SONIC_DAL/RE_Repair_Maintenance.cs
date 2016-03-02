using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for RE_Repair_Maintenance table.
    /// </summary>
    public sealed class RE_Repair_Maintenance
    {

        #region Private variables used to hold the property values

        private decimal? _PK_RE_Repair_Maintenance;
        private decimal? _FK_RE_Information;
        private decimal? _FK_LU_Repair_Type;
        private DateTime? _Date_PCA_Ordered;
        private DateTime? _Date_PCA_Conducted;
        private string _PCA_Conducted_By;
        private string _Damage_Description;
        private decimal? _FK_LU_Work_Scope;
        private string _Detailed_Description;
        private decimal? _FK_RE_Contractor;
        private decimal? _Estimate_Amount;
        private decimal? _Proposal_Amount;
        private decimal? _Actual_Amount;
        private DateTime? _Estaimted_Start_Date;
        private DateTime? _Actual_Start_Date;
        private DateTime? _End_Date;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_RE_Repair_Maintenance value.
        /// </summary>
        public decimal? PK_RE_Repair_Maintenance
        {
            get { return _PK_RE_Repair_Maintenance; }
            set { _PK_RE_Repair_Maintenance = value; }
        }

        /// <summary>
        /// Gets or sets the FK_RE_Information value.
        /// </summary>
        public decimal? FK_RE_Information
        {
            get { return _FK_RE_Information; }
            set { _FK_RE_Information = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Repair_Type value.
        /// </summary>
        public decimal? FK_LU_Repair_Type
        {
            get { return _FK_LU_Repair_Type; }
            set { _FK_LU_Repair_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Date_PCA_Ordered value.
        /// </summary>
        public DateTime? Date_PCA_Ordered
        {
            get { return _Date_PCA_Ordered; }
            set { _Date_PCA_Ordered = value; }
        }

        /// <summary>
        /// Gets or sets the Date_PCA_Conducted value.
        /// </summary>
        public DateTime? Date_PCA_Conducted
        {
            get { return _Date_PCA_Conducted; }
            set { _Date_PCA_Conducted = value; }
        }

        /// <summary>
        /// Gets or sets the PCA_Conducted_By value.
        /// </summary>
        public string PCA_Conducted_By
        {
            get { return _PCA_Conducted_By; }
            set { _PCA_Conducted_By = value; }
        }

        /// <summary>
        /// Gets or sets the Detailed_Description value.
        /// </summary>
        public string Damage_Description
        {
            get { return _Damage_Description; }
            set { _Damage_Description = value; }
        }


        /// <summary>
        /// Gets or sets the FK_LU_Work_Scope value.
        /// </summary>
        public decimal? FK_LU_Work_Scope
        {
            get { return _FK_LU_Work_Scope; }
            set { _FK_LU_Work_Scope = value; }
        }

        /// <summary>
        /// Gets or sets the Detailed_Description value.
        /// </summary>
        public string Detailed_Description
        {
            get { return _Detailed_Description; }
            set { _Detailed_Description = value; }
        }

        /// <summary>
        /// Gets or sets the FK_RE_Contractor value.
        /// </summary>
        public decimal? FK_RE_Contractor
        {
            get { return _FK_RE_Contractor; }
            set { _FK_RE_Contractor = value; }
        }

        /// <summary>
        /// Gets or sets the Estimate_Amount value.
        /// </summary>
        public decimal? Estimate_Amount
        {
            get { return _Estimate_Amount; }
            set { _Estimate_Amount = value; }
        }

        /// <summary>
        /// Gets or sets the Proposal_Amount value.
        /// </summary>
        public decimal? Proposal_Amount
        {
            get { return _Proposal_Amount; }
            set { _Proposal_Amount = value; }
        }

        /// <summary>
        /// Gets or sets the Actual_Amount value.
        /// </summary>
        public decimal? Actual_Amount
        {
            get { return _Actual_Amount; }
            set { _Actual_Amount = value; }
        }

        /// <summary>
        /// Gets or sets the Estaimted_Start_Date value.
        /// </summary>
        public DateTime? Estaimted_Start_Date
        {
            get { return _Estaimted_Start_Date; }
            set { _Estaimted_Start_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Actual_Start_Date value.
        /// </summary>
        public DateTime? Actual_Start_Date
        {
            get { return _Actual_Start_Date; }
            set { _Actual_Start_Date = value; }
        }

        /// <summary>
        /// Gets or sets the End_Date value.
        /// </summary>
        public DateTime? End_Date
        {
            get { return _End_Date; }
            set { _End_Date = value; }
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
        /// Initializes a new instance of the RE_Repair_Maintenance class with default value.
        /// </summary>
        public RE_Repair_Maintenance()
        {

            this._PK_RE_Repair_Maintenance = null;
            this._FK_RE_Information = null;
            this._FK_LU_Repair_Type = null;
            this._Date_PCA_Ordered = null;
            this._Date_PCA_Conducted = null;
            this._PCA_Conducted_By = null;
            this._FK_LU_Work_Scope = null;
            this._Detailed_Description = null;
            this._Damage_Description = null;
            this._FK_RE_Contractor = null;
            this._Estimate_Amount = null;
            this._Proposal_Amount = null;
            this._Actual_Amount = null;
            this._Estaimted_Start_Date = null;
            this._Actual_Start_Date = null;
            this._End_Date = null;
            this._Updated_By = null;
            this._Update_Date = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the RE_Repair_Maintenance class based on Primary Key.
        /// </summary>
        public RE_Repair_Maintenance(decimal pK_RE_Repair_Maintenance)
        {
            DataTable dtRE_Repair_Maintenance = SelectByPK(pK_RE_Repair_Maintenance).Tables[0];

            if (dtRE_Repair_Maintenance.Rows.Count == 1)
            {
                DataRow drRE_Repair_Maintenance = dtRE_Repair_Maintenance.Rows[0];
                if (drRE_Repair_Maintenance["PK_RE_Repair_Maintenance"] == DBNull.Value)
                    this._PK_RE_Repair_Maintenance = null;
                else
                    this._PK_RE_Repair_Maintenance = (decimal?)drRE_Repair_Maintenance["PK_RE_Repair_Maintenance"];

                if (drRE_Repair_Maintenance["FK_RE_Information"] == DBNull.Value)
                    this._FK_RE_Information = null;
                else
                    this._FK_RE_Information = (decimal?)drRE_Repair_Maintenance["FK_RE_Information"];

                if (drRE_Repair_Maintenance["FK_LU_Repair_Type"] == DBNull.Value)
                    this._FK_LU_Repair_Type = null;
                else
                    this._FK_LU_Repair_Type = (decimal?)drRE_Repair_Maintenance["FK_LU_Repair_Type"];

                if (drRE_Repair_Maintenance["Date_PCA_Ordered"] == DBNull.Value)
                    this._Date_PCA_Ordered = null;
                else
                    this._Date_PCA_Ordered = (DateTime?)drRE_Repair_Maintenance["Date_PCA_Ordered"];

                if (drRE_Repair_Maintenance["Date_PCA_Conducted"] == DBNull.Value)
                    this._Date_PCA_Conducted = null;
                else
                    this._Date_PCA_Conducted = (DateTime?)drRE_Repair_Maintenance["Date_PCA_Conducted"];

                if (drRE_Repair_Maintenance["PCA_Conducted_By"] == DBNull.Value)
                    this._PCA_Conducted_By = null;
                else
                    this._PCA_Conducted_By = (string)drRE_Repair_Maintenance["PCA_Conducted_By"];

                if (drRE_Repair_Maintenance["Damage_Description"] == DBNull.Value)
                    this._Damage_Description = null;
                else
                    this._Damage_Description = (string)drRE_Repair_Maintenance["Damage_Description"];


                if (drRE_Repair_Maintenance["FK_LU_Work_Scope"] == DBNull.Value)
                    this._FK_LU_Work_Scope = null;
                else
                    this._FK_LU_Work_Scope = (decimal?)drRE_Repair_Maintenance["FK_LU_Work_Scope"];

                if (drRE_Repair_Maintenance["Detailed_Description"] == DBNull.Value)
                    this._Detailed_Description = null;
                else
                    this._Detailed_Description = (string)drRE_Repair_Maintenance["Detailed_Description"];

                if (drRE_Repair_Maintenance["FK_RE_Contractor"] == DBNull.Value)
                    this._FK_RE_Contractor = null;
                else
                    this._FK_RE_Contractor = (decimal?)drRE_Repair_Maintenance["FK_RE_Contractor"];

                if (drRE_Repair_Maintenance["Estimate_Amount"] == DBNull.Value)
                    this._Estimate_Amount = null;
                else
                    this._Estimate_Amount = (decimal?)drRE_Repair_Maintenance["Estimate_Amount"];

                if (drRE_Repair_Maintenance["Proposal_Amount"] == DBNull.Value)
                    this._Proposal_Amount = null;
                else
                    this._Proposal_Amount = (decimal?)drRE_Repair_Maintenance["Proposal_Amount"];

                if (drRE_Repair_Maintenance["Actual_Amount"] == DBNull.Value)
                    this._Actual_Amount = null;
                else
                    this._Actual_Amount = (decimal?)drRE_Repair_Maintenance["Actual_Amount"];

                if (drRE_Repair_Maintenance["Estaimted_Start_Date"] == DBNull.Value)
                    this._Estaimted_Start_Date = null;
                else
                    this._Estaimted_Start_Date = (DateTime?)drRE_Repair_Maintenance["Estaimted_Start_Date"];

                if (drRE_Repair_Maintenance["Actual_Start_Date"] == DBNull.Value)
                    this._Actual_Start_Date = null;
                else
                    this._Actual_Start_Date = (DateTime?)drRE_Repair_Maintenance["Actual_Start_Date"];

                if (drRE_Repair_Maintenance["End_Date"] == DBNull.Value)
                    this._End_Date = null;
                else
                    this._End_Date = (DateTime?)drRE_Repair_Maintenance["End_Date"];

                if (drRE_Repair_Maintenance["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drRE_Repair_Maintenance["Updated_By"];

                if (drRE_Repair_Maintenance["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drRE_Repair_Maintenance["Update_Date"];

            }
            else
            {
                this._PK_RE_Repair_Maintenance = null;
                this._FK_RE_Information = null;
                this._FK_LU_Repair_Type = null;
                this._Date_PCA_Ordered = null;
                this._Date_PCA_Conducted = null;
                this._PCA_Conducted_By = null;
                this._FK_LU_Work_Scope = null;
                this._Detailed_Description = null;
                this._Damage_Description = null;
                this._FK_RE_Contractor = null;
                this._Estimate_Amount = null;
                this._Proposal_Amount = null;
                this._Actual_Amount = null;
                this._Estaimted_Start_Date = null;
                this._Actual_Start_Date = null;
                this._End_Date = null;
                this._Updated_By = null;
                this._Update_Date = null;
            }
        }

        #endregion

        /// <summary>
        /// Inserts a record into the RE_Repair_Maintenance table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Repair_Maintenance_OldInsert");


            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);

            db.AddInParameter(dbCommand, "FK_LU_Repair_Type", DbType.Decimal, this._FK_LU_Repair_Type);

            db.AddInParameter(dbCommand, "Date_PCA_Ordered", DbType.DateTime, this._Date_PCA_Ordered);

            db.AddInParameter(dbCommand, "Date_PCA_Conducted", DbType.DateTime, this._Date_PCA_Conducted);

            if (string.IsNullOrEmpty(this._PCA_Conducted_By))
                db.AddInParameter(dbCommand, "PCA_Conducted_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "PCA_Conducted_By", DbType.String, this._PCA_Conducted_By);           

            db.AddInParameter(dbCommand, "FK_LU_Work_Scope", DbType.Decimal, this._FK_LU_Work_Scope);

            if (string.IsNullOrEmpty(this._Damage_Description))
                db.AddInParameter(dbCommand, "Damage_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Damage_Description", DbType.String, this._Damage_Description);

            if (string.IsNullOrEmpty(this._Detailed_Description))
                db.AddInParameter(dbCommand, "Detailed_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Detailed_Description", DbType.String, this._Detailed_Description);

            db.AddInParameter(dbCommand, "FK_RE_Contractor", DbType.Decimal, this._FK_RE_Contractor);

            db.AddInParameter(dbCommand, "Estimate_Amount", DbType.Decimal, this._Estimate_Amount);

            db.AddInParameter(dbCommand, "Proposal_Amount", DbType.Decimal, this._Proposal_Amount);

            db.AddInParameter(dbCommand, "Actual_Amount", DbType.Decimal, this._Actual_Amount);

            db.AddInParameter(dbCommand, "Estaimted_Start_Date", DbType.DateTime, this._Estaimted_Start_Date);

            db.AddInParameter(dbCommand, "Actual_Start_Date", DbType.DateTime, this._Actual_Start_Date);

            db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);

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
        /// Selects a single record from the RE_Repair_Maintenance table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_RE_Repair_Maintenance)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Repair_Maintenance_OldSelectByPK");

            db.AddInParameter(dbCommand, "PK_RE_Repair_Maintenance", DbType.Decimal, pK_RE_Repair_Maintenance);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the RE_Repair_Maintenance table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Repair_Maintenance_OldSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the RE_Repair_Maintenance table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Repair_Maintenance_OldUpdate");


            db.AddInParameter(dbCommand, "PK_RE_Repair_Maintenance", DbType.Decimal, this._PK_RE_Repair_Maintenance);

            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);

            db.AddInParameter(dbCommand, "FK_LU_Repair_Type", DbType.Decimal, this._FK_LU_Repair_Type);

            db.AddInParameter(dbCommand, "Date_PCA_Ordered", DbType.DateTime, this._Date_PCA_Ordered);

            db.AddInParameter(dbCommand, "Date_PCA_Conducted", DbType.DateTime, this._Date_PCA_Conducted);

            if (string.IsNullOrEmpty(this._PCA_Conducted_By))
                db.AddInParameter(dbCommand, "PCA_Conducted_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "PCA_Conducted_By", DbType.String, this._PCA_Conducted_By);
                    

            db.AddInParameter(dbCommand, "FK_LU_Work_Scope", DbType.Decimal, this._FK_LU_Work_Scope);

            if (string.IsNullOrEmpty(this._Damage_Description))
                db.AddInParameter(dbCommand, "Damage_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Damage_Description", DbType.String, this._Damage_Description);

            if (string.IsNullOrEmpty(this._Detailed_Description))
                db.AddInParameter(dbCommand, "Detailed_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Detailed_Description", DbType.String, this._Detailed_Description);

            db.AddInParameter(dbCommand, "FK_RE_Contractor", DbType.Decimal, this._FK_RE_Contractor);

            db.AddInParameter(dbCommand, "Estimate_Amount", DbType.Decimal, this._Estimate_Amount);

            db.AddInParameter(dbCommand, "Proposal_Amount", DbType.Decimal, this._Proposal_Amount);

            db.AddInParameter(dbCommand, "Actual_Amount", DbType.Decimal, this._Actual_Amount);

            db.AddInParameter(dbCommand, "Estaimted_Start_Date", DbType.DateTime, this._Estaimted_Start_Date);

            db.AddInParameter(dbCommand, "Actual_Start_Date", DbType.DateTime, this._Actual_Start_Date);

            db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the RE_Repair_Maintenance table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_RE_Repair_Maintenance)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Repair_Maintenance_OldDeleteByPK");

            db.AddInParameter(dbCommand, "PK_RE_Repair_Maintenance", DbType.Decimal, pK_RE_Repair_Maintenance);

            db.ExecuteNonQuery(dbCommand);
        }

        //RE_Repair_MaintenanceSelectByFK
        public static DataSet SelectByFK(decimal fK_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Repair_Maintenance_OldSelectByFK");

            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, fK_RE_Information);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
