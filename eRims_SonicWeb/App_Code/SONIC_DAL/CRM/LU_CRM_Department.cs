using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

/// <summary>
/// Summary description for LU_CRM_Department
/// </summary>
namespace ERIMS.DAL
{
    public sealed class LU_CRM_Department
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_CRM_Department;
        private string _Fld_Desc;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_CRM_Department value.
        /// </summary>
        public decimal? PK_LU_CRM_Department
        {
            get { return _PK_LU_CRM_Department; }
            set { _PK_LU_CRM_Department = value; }
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
        /// Gets or sets the Active value.
        /// </summary>
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the LU_CRM_Department class with default value.
        /// </summary>
        public LU_CRM_Department()
        {


        }
        public LU_CRM_Department(decimal pK_LU_CRM_Department)
        {
            DataTable dtLU_CRM_Department = SelectByPK(pK_LU_CRM_Department).Tables[0];

            if (dtLU_CRM_Department.Rows.Count == 1)
            {
                DataRow drLU_CRM_Department = dtLU_CRM_Department.Rows[0];
                if (drLU_CRM_Department["PK_LU_CRM_Department"] == DBNull.Value)
                    this._PK_LU_CRM_Department = null;
                else
                    this._PK_LU_CRM_Department = (decimal?)drLU_CRM_Department["PK_LU_CRM_Department"];

                if (drLU_CRM_Department["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drLU_CRM_Department["Fld_Desc"];

                if (drLU_CRM_Department["Active"] == DBNull.Value)
                    this._Active = null;
                else
                    this._Active = (string)drLU_CRM_Department["Active"];

            }
            else
            {
                this._PK_LU_CRM_Department = null;
                this._Fld_Desc = null;
                this._Active = null;
            }

        }
        #endregion

        #region Primary Constructors
        
      
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_DepartmentInsert");


            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Franchise_Additional_Land table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_CRM_Department)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_DepartmentSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_Department", DbType.Decimal, pK_LU_CRM_Department);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Franchise_Additional_Land table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_DepartmentSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Franchise_Additional_Land table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_DepartmentUpdate");


            db.AddInParameter(dbCommand, "PK_LU_CRM_Department", DbType.Decimal, this._PK_LU_CRM_Department);

            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
        }

        /// <summary>
        /// Deletes a record from the LU_Franchise_Additional_Land table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_CRM_Department)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_DepartmentDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_Department", DbType.Decimal, pK_LU_CRM_Department);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}