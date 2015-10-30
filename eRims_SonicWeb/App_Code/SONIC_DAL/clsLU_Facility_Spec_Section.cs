using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for table LU_Facility_Spec_Section
    /// </summary>
    public sealed class clsLU_Facility_Spec_Section
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Facility_Spec_Section;
        private string _Description;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Facility_Spec_Section value.
        /// </summary>
        public decimal? PK_LU_Facility_Spec_Section
        {
            get { return _PK_LU_Facility_Spec_Section; }
            set { _PK_LU_Facility_Spec_Section = value; }
        }

        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Facility_Spec_Section class with default value.
        /// </summary>
        public clsLU_Facility_Spec_Section()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Facility_Spec_Section class based on Primary Key.
        /// </summary>
        public clsLU_Facility_Spec_Section(decimal pK_LU_Facility_Spec_Section)
        {
            DataTable dtLU_Facility_Spec_Section = Select(pK_LU_Facility_Spec_Section).Tables[0];

            if (dtLU_Facility_Spec_Section.Rows.Count == 1)
            {
                SetValue(dtLU_Facility_Spec_Section.Rows[0]);

            }
        }

        /// <summary>
        /// Initializes a new instance of the LU_Facility_Spec_Section class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drLU_Facility_Spec_Section)
        {
            if (drLU_Facility_Spec_Section["PK_LU_Facility_Spec_Section"] == DBNull.Value)
                this._PK_LU_Facility_Spec_Section = null;
            else
                this._PK_LU_Facility_Spec_Section = (decimal?)drLU_Facility_Spec_Section["PK_LU_Facility_Spec_Section"];

            if (drLU_Facility_Spec_Section["Description"] == DBNull.Value)
                this._Description = null;
            else
                this._Description = (string)drLU_Facility_Spec_Section["Description"];
        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Facility_Spec_Section table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Spec_SectionInsert");


            if (string.IsNullOrEmpty(this._Description))
                db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Facility_Spec_Section table.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet Select(decimal pK_LU_Facility_Spec_Section)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Spec_SectionSelect");

            db.AddInParameter(dbCommand, "PK_LU_Facility_Spec_Section", DbType.Decimal, pK_LU_Facility_Spec_Section);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Facility_Spec_Section table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Spec_SectionSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Facility_Spec_Section table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Spec_SectionUpdate");

            db.AddInParameter(dbCommand, "PK_LU_Facility_Spec_Section", DbType.Decimal, this._PK_LU_Facility_Spec_Section);

            if (string.IsNullOrEmpty(this._Description))
                db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
        }

        /// <summary>
        /// Deletes a record from the LU_Facility_Spec_Section table by a composite primary key.
        /// </summary>
        public static void Delete(decimal pK_LU_Facility_Spec_Section)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Spec_SectionDelete");

            db.AddInParameter(dbCommand, "PK_LU_Facility_Spec_Section", DbType.Decimal, pK_LU_Facility_Spec_Section);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
