using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_AP_Cap_Index_Risk_Category table.
    /// </summary>
    public sealed class clsLU_AP_Cap_Index_Risk_Category
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_AP_Cap_Index_Risk_Category;
        private string _Fld_Desc;
        private decimal? _Sort_Order;
        private int? _Minimum_Score;
        private int? _Maximum_Score;
        private string _Active;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_AP_Cap_Index_Risk_Category value.
        /// </summary>
        public decimal? PK_LU_AP_Cap_Index_Risk_Category
        {
            get { return _PK_LU_AP_Cap_Index_Risk_Category; }
            set { _PK_LU_AP_Cap_Index_Risk_Category = value; }
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
        /// Gets or sets the Sort_Order value.
        /// </summary>
        public decimal? Sort_Order
        {
            get { return _Sort_Order; }
            set { _Sort_Order = value; }
        }

        /// <summary>
        /// Gets or sets the Minimum_Score value.
        /// </summary>
        public int? Minimum_Score
        {
            get { return _Minimum_Score; }
            set { _Minimum_Score = value; }
        }

        /// <summary>
        /// Gets or sets the Maximum_Score value.
        /// </summary>
        public int? Maximum_Score
        {
            get { return _Maximum_Score; }
            set { _Maximum_Score = value; }
        }

        /// <summary>
        /// Gets or sets the Active value.
        /// </summary>
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
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
        /// Initializes a new instance of the clsLU_AP_Cap_Index_Risk_Category class with default value.
        /// </summary>
        public clsLU_AP_Cap_Index_Risk_Category()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsLU_AP_Cap_Index_Risk_Category class based on Primary Key.
        /// </summary>
        public clsLU_AP_Cap_Index_Risk_Category(decimal pK_LU_AP_Cap_Index_Risk_Category)
        {
            DataTable dtLU_AP_Cap_Index_Risk_Category = SelectByPK(pK_LU_AP_Cap_Index_Risk_Category).Tables[0];

            if (dtLU_AP_Cap_Index_Risk_Category.Rows.Count == 1)
            {
                SetValue(dtLU_AP_Cap_Index_Risk_Category.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsLU_AP_Cap_Index_Risk_Category class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drLU_AP_Cap_Index_Risk_Category)
        {
            if (drLU_AP_Cap_Index_Risk_Category["PK_LU_AP_Cap_Index_Risk_Category"] == DBNull.Value)
                this._PK_LU_AP_Cap_Index_Risk_Category = null;
            else
                this._PK_LU_AP_Cap_Index_Risk_Category = (decimal?)drLU_AP_Cap_Index_Risk_Category["PK_LU_AP_Cap_Index_Risk_Category"];

            if (drLU_AP_Cap_Index_Risk_Category["Fld_Desc"] == DBNull.Value)
                this._Fld_Desc = null;
            else
                this._Fld_Desc = (string)drLU_AP_Cap_Index_Risk_Category["Fld_Desc"];

            if (drLU_AP_Cap_Index_Risk_Category["Sort_Order"] == DBNull.Value)
                this._Sort_Order = null;
            else
                this._Sort_Order = (decimal?)drLU_AP_Cap_Index_Risk_Category["Sort_Order"];

            if (drLU_AP_Cap_Index_Risk_Category["Minimum_Score"] == DBNull.Value)
                this._Minimum_Score = null;
            else
                this._Minimum_Score = (int?)drLU_AP_Cap_Index_Risk_Category["Minimum_Score"];

            if (drLU_AP_Cap_Index_Risk_Category["Maximum_Score"] == DBNull.Value)
                this._Maximum_Score = null;
            else
                this._Maximum_Score = (int?)drLU_AP_Cap_Index_Risk_Category["Maximum_Score"];

            if (drLU_AP_Cap_Index_Risk_Category["Active"] == DBNull.Value)
                this._Active = null;
            else
                this._Active = (string)drLU_AP_Cap_Index_Risk_Category["Active"];

            if (drLU_AP_Cap_Index_Risk_Category["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drLU_AP_Cap_Index_Risk_Category["Updated_By"];

            if (drLU_AP_Cap_Index_Risk_Category["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drLU_AP_Cap_Index_Risk_Category["Update_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_AP_Cap_Index_Risk_Category table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_AP_Cap_Index_Risk_CategoryInsert");


            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            db.AddInParameter(dbCommand, "Sort_Order", DbType.Decimal, this._Sort_Order);

            db.AddInParameter(dbCommand, "Minimum_Score", DbType.Int32, this._Minimum_Score);

            db.AddInParameter(dbCommand, "Maximum_Score", DbType.Int32, this._Maximum_Score);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

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
        /// Selects a single record from the LU_AP_Cap_Index_Risk_Category table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_LU_AP_Cap_Index_Risk_Category)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_AP_Cap_Index_Risk_CategorySelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_AP_Cap_Index_Risk_Category", DbType.Decimal, pK_LU_AP_Cap_Index_Risk_Category);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_AP_Cap_Index_Risk_Category table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll(decimal Sort_Order)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_AP_Cap_Index_Risk_CategorySelectAll");

            db.AddInParameter(dbCommand, "Sort_Order", DbType.Decimal, Sort_Order);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_AP_Cap_Index_Risk_Category table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_AP_Cap_Index_Risk_CategoryUpdate");


            db.AddInParameter(dbCommand, "PK_LU_AP_Cap_Index_Risk_Category", DbType.Decimal, this._PK_LU_AP_Cap_Index_Risk_Category);

            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            db.AddInParameter(dbCommand, "Sort_Order", DbType.Decimal, this._Sort_Order);

            db.AddInParameter(dbCommand, "Minimum_Score", DbType.Int32, this._Minimum_Score);

            db.AddInParameter(dbCommand, "Maximum_Score", DbType.Int32, this._Maximum_Score);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        /// Deletes a record from the LU_AP_Cap_Index_Risk_Category table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_AP_Cap_Index_Risk_Category)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_AP_Cap_Index_Risk_CategoryDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_AP_Cap_Index_Risk_Category", DbType.Decimal, pK_LU_AP_Cap_Index_Risk_Category);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
