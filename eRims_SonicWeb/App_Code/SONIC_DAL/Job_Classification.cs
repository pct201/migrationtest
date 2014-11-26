using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Job_Classification table.
    /// </summary>
    public sealed class Job_Classification
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Id;
        private string _Fld_Code;
        private string _Fld_Desc;
        private string _Remarks;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Id value.
        /// </summary>
        public decimal? PK_Id
        {
            get { return _PK_Id; }
            set { _PK_Id = value; }
        }

        /// <summary>
        /// Gets or sets the Fld_Code value.
        /// </summary>
        public string Fld_Code
        {
            get { return _Fld_Code; }
            set { _Fld_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Fld_Desc value.
        /// </summary>
        public string Fld_Desc
        {
            get { return _Fld_Desc; }
            set { _Fld_Desc = value; }
        }

        /// <summary>
        /// Gets or sets the Remarks value.
        /// </summary>
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Job_Classification class with default value.
        /// </summary>
        public Job_Classification()
        {

            this._PK_Id = null;
            this._Fld_Code = null;
            this._Fld_Desc = null;
            this._Remarks = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Job_Classification class based on Primary Key.
        /// </summary>
        public Job_Classification(decimal pK_Id)
        {
            DataTable dtJob_Classification = SelectByPK(pK_Id).Tables[0];

            if (dtJob_Classification.Rows.Count == 1)
            {
                DataRow drJob_Classification = dtJob_Classification.Rows[0];
                if (drJob_Classification["PK_Id"] == DBNull.Value)
                    this._PK_Id = null;
                else
                    this._PK_Id = (decimal?)drJob_Classification["PK_Id"];

                if (drJob_Classification["Fld_Code"] == DBNull.Value)
                    this._Fld_Code = null;
                else
                    this._Fld_Code = (string)drJob_Classification["Fld_Code"];

                if (drJob_Classification["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drJob_Classification["Fld_Desc"];

                if (drJob_Classification["Remarks"] == DBNull.Value)
                    this._Remarks = null;
                else
                    this._Remarks = (string)drJob_Classification["Remarks"];

            }
            else
            {
                this._PK_Id = null;
                this._Fld_Code = null;
                this._Fld_Desc = null;
                this._Remarks = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Job_Classification table.
        /// </summary>
        /// <returns></returns>
        public void Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Job_ClassificationInsert");


            db.AddInParameter(dbCommand, "PK_Id", DbType.Decimal, this._PK_Id);

            if (string.IsNullOrEmpty(this._Fld_Code))
                db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);

            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            if (string.IsNullOrEmpty(this._Remarks))
                db.AddInParameter(dbCommand, "Remarks", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Remarks", DbType.String, this._Remarks);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Job_Classification table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Job_ClassificationSelectByPK");

            db.AddInParameter(dbCommand, "PK_Id", DbType.Decimal, pK_Id);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Job_Classification table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Job_ClassificationSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Job_Classification table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Job_ClassificationUpdate");


            db.AddInParameter(dbCommand, "PK_Id", DbType.Decimal, this._PK_Id);

            if (string.IsNullOrEmpty(this._Fld_Code))
                db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);

            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            if (string.IsNullOrEmpty(this._Remarks))
                db.AddInParameter(dbCommand, "Remarks", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Remarks", DbType.String, this._Remarks);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Job_Classification table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Job_ClassificationDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Id", DbType.Decimal, pK_Id);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
