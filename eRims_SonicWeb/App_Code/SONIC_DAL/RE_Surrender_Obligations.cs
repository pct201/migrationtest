using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for RE_Surrender_Obligations table.
    /// </summary>
    public sealed class RE_Surrender_Obligations
    {

        #region Private variables used to hold the property values

        private decimal? _PK_RE_Surrender_Obligations;
        private decimal? _FK_RE_Information;
        private string _Condition_At_Commencement;
        private string _Permitted_Use;
        private string _Alterations;
        private string _Tenants_Obligations;
        private string _Environmental_Matters;
        private string _Landlords_Obligations;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_RE_Surrender_Obligations value.
        /// </summary>
        public decimal? PK_RE_Surrender_Obligations
        {
            get { return _PK_RE_Surrender_Obligations; }
            set { _PK_RE_Surrender_Obligations = value; }
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
        /// Gets or sets the Condition_At_Commencement value.
        /// </summary>
        public string Condition_At_Commencement
        {
            get { return _Condition_At_Commencement; }
            set { _Condition_At_Commencement = value; }
        }

        /// <summary>
        /// Gets or sets the Permitted_Use value.
        /// </summary>
        public string Permitted_Use
        {
            get { return _Permitted_Use; }
            set { _Permitted_Use = value; }
        }

        /// <summary>
        /// Gets or sets the Alterations value.
        /// </summary>
        public string Alterations
        {
            get { return _Alterations; }
            set { _Alterations = value; }
        }

        /// <summary>
        /// Gets or sets the Tenants_Obligations value.
        /// </summary>
        public string Tenants_Obligations
        {
            get { return _Tenants_Obligations; }
            set { _Tenants_Obligations = value; }
        }

        /// <summary>
        /// Gets or sets the Environmental_Matters value.
        /// </summary>
        public string Environmental_Matters
        {
            get { return _Environmental_Matters; }
            set { _Environmental_Matters = value; }
        }

        /// <summary>
        /// Gets or sets the Landlords_Obligations value.
        /// </summary>
        public string Landlords_Obligations
        {
            get { return _Landlords_Obligations; }
            set { _Landlords_Obligations = value; }
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
        /// Initializes a new instance of the RE_Surrender_Obligations class with default value.
        /// </summary>
        public RE_Surrender_Obligations()
        {
            setDefaultValues();
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the RE_Surrender_Obligations class based on Primary Key.
        /// </summary>
        public RE_Surrender_Obligations(decimal pK_RE_Surrender_Obligations)
        {
            DataTable dtRE_Surrender_Obligations = SelectByPK(pK_RE_Surrender_Obligations).Tables[0];

            if (dtRE_Surrender_Obligations.Rows.Count == 1)
            {
                DataRow drRE_Surrender_Obligations = dtRE_Surrender_Obligations.Rows[0];
                if (drRE_Surrender_Obligations["PK_RE_Surrender_Obligations"] == DBNull.Value)
                    this._PK_RE_Surrender_Obligations = null;
                else
                    this._PK_RE_Surrender_Obligations = (decimal?)drRE_Surrender_Obligations["PK_RE_Surrender_Obligations"];

                if (drRE_Surrender_Obligations["FK_RE_Information"] == DBNull.Value)
                    this._FK_RE_Information = null;
                else
                    this._FK_RE_Information = (decimal?)drRE_Surrender_Obligations["FK_RE_Information"];

                if (drRE_Surrender_Obligations["Condition_At_Commencement"] == DBNull.Value)
                    this._Condition_At_Commencement = null;
                else
                    this._Condition_At_Commencement = (string)drRE_Surrender_Obligations["Condition_At_Commencement"];

                if (drRE_Surrender_Obligations["Permitted_Use"] == DBNull.Value)
                    this._Permitted_Use = null;
                else
                    this._Permitted_Use = (string)drRE_Surrender_Obligations["Permitted_Use"];

                if (drRE_Surrender_Obligations["Alterations"] == DBNull.Value)
                    this._Alterations = null;
                else
                    this._Alterations = (string)drRE_Surrender_Obligations["Alterations"];

                if (drRE_Surrender_Obligations["Tenants_Obligations"] == DBNull.Value)
                    this._Tenants_Obligations = null;
                else
                    this._Tenants_Obligations = (string)drRE_Surrender_Obligations["Tenants_Obligations"];

                if (drRE_Surrender_Obligations["Environmental_Matters"] == DBNull.Value)
                    this._Environmental_Matters = null;
                else
                    this._Environmental_Matters = (string)drRE_Surrender_Obligations["Environmental_Matters"];

                if (drRE_Surrender_Obligations["Landlords_Obligations"] == DBNull.Value)
                    this._Landlords_Obligations = null;
                else
                    this._Landlords_Obligations = (string)drRE_Surrender_Obligations["Landlords_Obligations"];

                if (drRE_Surrender_Obligations["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drRE_Surrender_Obligations["Updated_By"];

                if (drRE_Surrender_Obligations["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drRE_Surrender_Obligations["Update_Date"];

            }
            else
            {
                setDefaultValues();
            }
        }

        /// <summary>
        /// Initializes a new instance of the RE_Surrender_Obligations class based on Primary Key.
        /// </summary>
        public RE_Surrender_Obligations(decimal FK_RE_Information, bool isFK)
        {
            DataTable dtRE_Surrender_Obligations = SelectByFK(FK_RE_Information).Tables[0];

            if (dtRE_Surrender_Obligations.Rows.Count == 1)
            {
                DataRow drRE_Surrender_Obligations = dtRE_Surrender_Obligations.Rows[0];
                if (drRE_Surrender_Obligations["PK_RE_Surrender_Obligations"] == DBNull.Value)
                    this._PK_RE_Surrender_Obligations = null;
                else
                    this._PK_RE_Surrender_Obligations = (decimal?)drRE_Surrender_Obligations["PK_RE_Surrender_Obligations"];

                if (drRE_Surrender_Obligations["FK_RE_Information"] == DBNull.Value)
                    this._FK_RE_Information = null;
                else
                    this._FK_RE_Information = (decimal?)drRE_Surrender_Obligations["FK_RE_Information"];

                if (drRE_Surrender_Obligations["Condition_At_Commencement"] == DBNull.Value)
                    this._Condition_At_Commencement = null;
                else
                    this._Condition_At_Commencement = (string)drRE_Surrender_Obligations["Condition_At_Commencement"];

                if (drRE_Surrender_Obligations["Permitted_Use"] == DBNull.Value)
                    this._Permitted_Use = null;
                else
                    this._Permitted_Use = (string)drRE_Surrender_Obligations["Permitted_Use"];

                if (drRE_Surrender_Obligations["Alterations"] == DBNull.Value)
                    this._Alterations = null;
                else
                    this._Alterations = (string)drRE_Surrender_Obligations["Alterations"];

                if (drRE_Surrender_Obligations["Tenants_Obligations"] == DBNull.Value)
                    this._Tenants_Obligations = null;
                else
                    this._Tenants_Obligations = (string)drRE_Surrender_Obligations["Tenants_Obligations"];

                if (drRE_Surrender_Obligations["Environmental_Matters"] == DBNull.Value)
                    this._Environmental_Matters = null;
                else
                    this._Environmental_Matters = (string)drRE_Surrender_Obligations["Environmental_Matters"];

                if (drRE_Surrender_Obligations["Landlords_Obligations"] == DBNull.Value)
                    this._Landlords_Obligations = null;
                else
                    this._Landlords_Obligations = (string)drRE_Surrender_Obligations["Landlords_Obligations"];

                if (drRE_Surrender_Obligations["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drRE_Surrender_Obligations["Updated_By"];

                if (drRE_Surrender_Obligations["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drRE_Surrender_Obligations["Update_Date"];

            }
            else
            {
                setDefaultValues();
            }
        }

        #endregion

        private void setDefaultValues()
        {
            this._PK_RE_Surrender_Obligations = null;
            this._FK_RE_Information = null;
            this._Condition_At_Commencement = null;
            this._Permitted_Use = null;
            this._Alterations = null;
            this._Tenants_Obligations = null;
            this._Environmental_Matters = null;
            this._Landlords_Obligations = null;
            this._Updated_By = null;
            this._Update_Date = null;
        }

        /// <summary>
        /// Inserts a record into the RE_Surrender_Obligations table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Surrender_ObligationsInsert");


            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);

            if (string.IsNullOrEmpty(this._Condition_At_Commencement))
                db.AddInParameter(dbCommand, "Condition_At_Commencement", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Condition_At_Commencement", DbType.String, this._Condition_At_Commencement);

            if (string.IsNullOrEmpty(this._Permitted_Use))
                db.AddInParameter(dbCommand, "Permitted_Use", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Permitted_Use", DbType.String, this._Permitted_Use);

            if (string.IsNullOrEmpty(this._Alterations))
                db.AddInParameter(dbCommand, "Alterations", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Alterations", DbType.String, this._Alterations);

            if (string.IsNullOrEmpty(this._Tenants_Obligations))
                db.AddInParameter(dbCommand, "Tenants_Obligations", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Tenants_Obligations", DbType.String, this._Tenants_Obligations);

            if (string.IsNullOrEmpty(this._Environmental_Matters))
                db.AddInParameter(dbCommand, "Environmental_Matters", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Environmental_Matters", DbType.String, this._Environmental_Matters);

            if (string.IsNullOrEmpty(this._Landlords_Obligations))
                db.AddInParameter(dbCommand, "Landlords_Obligations", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlords_Obligations", DbType.String, this._Landlords_Obligations);

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
        /// Selects a single record from the RE_Surrender_Obligations table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_RE_Surrender_Obligations)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Surrender_ObligationsSelectByPK");

            db.AddInParameter(dbCommand, "PK_RE_Surrender_Obligations", DbType.Decimal, pK_RE_Surrender_Obligations);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the RE_Surrender_Obligations table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByFK(decimal FK_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Surrender_ObligationsSelectByFK");

            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, FK_RE_Information);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the RE_Surrender_Obligations table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Surrender_ObligationsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the RE_Surrender_Obligations table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Surrender_ObligationsUpdate");


            db.AddInParameter(dbCommand, "PK_RE_Surrender_Obligations", DbType.Decimal, this._PK_RE_Surrender_Obligations);

            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);

            if (string.IsNullOrEmpty(this._Condition_At_Commencement))
                db.AddInParameter(dbCommand, "Condition_At_Commencement", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Condition_At_Commencement", DbType.String, this._Condition_At_Commencement);

            if (string.IsNullOrEmpty(this._Permitted_Use))
                db.AddInParameter(dbCommand, "Permitted_Use", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Permitted_Use", DbType.String, this._Permitted_Use);

            if (string.IsNullOrEmpty(this._Alterations))
                db.AddInParameter(dbCommand, "Alterations", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Alterations", DbType.String, this._Alterations);

            if (string.IsNullOrEmpty(this._Tenants_Obligations))
                db.AddInParameter(dbCommand, "Tenants_Obligations", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Tenants_Obligations", DbType.String, this._Tenants_Obligations);

            if (string.IsNullOrEmpty(this._Environmental_Matters))
                db.AddInParameter(dbCommand, "Environmental_Matters", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Environmental_Matters", DbType.String, this._Environmental_Matters);

            if (string.IsNullOrEmpty(this._Landlords_Obligations))
                db.AddInParameter(dbCommand, "Landlords_Obligations", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlords_Obligations", DbType.String, this._Landlords_Obligations);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the RE_Surrender_Obligations table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_RE_Surrender_Obligations)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Surrender_ObligationsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_RE_Surrender_Obligations", DbType.Decimal, pK_RE_Surrender_Obligations);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
