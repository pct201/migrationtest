using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Screen_Validators table.
    /// </summary>
    public sealed class clsScreen_Validators
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Screen_Validator;
        private decimal? _ScreenId;
        private string _Field_Name;
        private string _IsRequired;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Screen_Validator value.
        /// </summary>
        public decimal? PK_Screen_Validator
        {
            get { return _PK_Screen_Validator; }
            set { _PK_Screen_Validator = value; }
        }

        /// <summary>
        /// Gets or sets the ScreenId value.
        /// </summary>
        public decimal? ScreenId
        {
            get { return _ScreenId; }
            set { _ScreenId = value; }
        }

        /// <summary>
        /// Gets or sets the Field_Name value.
        /// </summary>
        public string Field_Name
        {
            get { return _Field_Name; }
            set { _Field_Name = value; }
        }

        /// <summary>
        /// Gets or sets the IsRequired value.
        /// </summary>
        public string IsRequired
        {
            get { return _IsRequired; }
            set { _IsRequired = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsScreen_Validators class with default value.
        /// </summary>
        public clsScreen_Validators()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsScreen_Validators class based on Primary Key.
        /// </summary>
        public clsScreen_Validators(decimal pK_Screen_Validator)
        {
            DataTable dtScreen_Validators = SelectByPK(pK_Screen_Validator).Tables[0];

            if (dtScreen_Validators.Rows.Count == 1)
            {
                SetValue(dtScreen_Validators.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsScreen_Validators class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drScreen_Validators)
        {
            if (drScreen_Validators["PK_Screen_Validator"] == DBNull.Value)
                this._PK_Screen_Validator = null;
            else
                this._PK_Screen_Validator = (decimal?)drScreen_Validators["PK_Screen_Validator"];

            if (drScreen_Validators["ScreenId"] == DBNull.Value)
                this._ScreenId = null;
            else
                this._ScreenId = (decimal?)drScreen_Validators["ScreenId"];

            if (drScreen_Validators["Field_Name"] == DBNull.Value)
                this._Field_Name = null;
            else
                this._Field_Name = (string)drScreen_Validators["Field_Name"];

            if (drScreen_Validators["IsRequired"] == DBNull.Value)
                this._IsRequired = null;
            else
                this._IsRequired = (string)drScreen_Validators["IsRequired"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Screen_Validators table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Screen_ValidatorsInsert");


            db.AddInParameter(dbCommand, "ScreenId", DbType.Decimal, this._ScreenId);

            if (string.IsNullOrEmpty(this._Field_Name))
                db.AddInParameter(dbCommand, "Field_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Field_Name", DbType.String, this._Field_Name);

            if (string.IsNullOrEmpty(this._IsRequired))
                db.AddInParameter(dbCommand, "IsRequired", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "IsRequired", DbType.String, this._IsRequired);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Screen_Validators table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_Screen_Validator)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Screen_ValidatorsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Screen_Validator", DbType.Decimal, pK_Screen_Validator);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Screen_Validators table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Screen_ValidatorsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Screen_Validators table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Screen_ValidatorsUpdate");


            db.AddInParameter(dbCommand, "PK_Screen_Validator", DbType.Decimal, this._PK_Screen_Validator);

            db.AddInParameter(dbCommand, "ScreenId", DbType.Decimal, this._ScreenId);

            if (string.IsNullOrEmpty(this._Field_Name))
                db.AddInParameter(dbCommand, "Field_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Field_Name", DbType.String, this._Field_Name);

            if (string.IsNullOrEmpty(this._IsRequired))
                db.AddInParameter(dbCommand, "IsRequired", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "IsRequired", DbType.String, this._IsRequired);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Screen_Validators table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Screen_Validator)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Screen_ValidatorsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Screen_Validator", DbType.Decimal, pK_Screen_Validator);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByScreen(int ScreenId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Screen_ValidatorsSelectByFKScreen");
            db.AddInParameter(dbCommand, "ScreenId", DbType.Int32, (int)ScreenId);
            return db.ExecuteDataSet(dbCommand);
        }

        public static void DeleteByScreen(int ScreenId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Screen_ValidatorsDeleteByFKScreen");
            db.AddInParameter(dbCommand, "ScreenId", DbType.Int32, ScreenId);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// updates a record from the Screen_Validators table by a composite primary key.
        /// </summary>
        public static void UpdateByPK(decimal pK_Screen_Validator, string IsRequired)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Screen_ValidatorsUpdateByPK");
            db.AddInParameter(dbCommand, "PK_Screen_Validator", DbType.Decimal, pK_Screen_Validator);
            db.AddInParameter(dbCommand, "IsRequired", DbType.String, IsRequired);
            db.ExecuteNonQuery(dbCommand);
        }
    }
}
