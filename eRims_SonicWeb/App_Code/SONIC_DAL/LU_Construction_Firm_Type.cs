using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Lu_Construction_Firm_Type table.
	/// </summary>
	public sealed class LU_Construction_Firm_Type
	{

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Construction_Firm_Type;
        private string _CFT_Desc;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Construction_Firm_Type value.
        /// </summary>
        public decimal? PK_LU_Construction_Firm_Type
        {
            get { return _PK_LU_Construction_Firm_Type; }
            set { _PK_LU_Construction_Firm_Type = value; }
        }

        /// <summary>
        /// Gets or sets the CFT_Desc value.
        /// </summary>
        public string CFT_Desc
        {
            get { return _CFT_Desc; }
            set { _CFT_Desc = value; }
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
        /// Initializes a new instance of the LU_Construction_Firm_Type class with default value.
        /// </summary>
        public LU_Construction_Firm_Type()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Construction_Firm_Type class based on Primary Key.
        /// </summary>
        public LU_Construction_Firm_Type(decimal pK_LU_Construction_Firm_Type)
        {
            DataTable dtLU_Construction_Firm_Type = Select(pK_LU_Construction_Firm_Type).Tables[0];

            if (dtLU_Construction_Firm_Type.Rows.Count == 1)
            {
                SetValue(dtLU_Construction_Firm_Type.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the LU_Construction_Firm_Type class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drLU_Construction_Firm_Type)
        {
            if (drLU_Construction_Firm_Type["PK_LU_Construction_Firm_Type"] == DBNull.Value)
                this._PK_LU_Construction_Firm_Type = null;
            else
                this._PK_LU_Construction_Firm_Type = (decimal?)drLU_Construction_Firm_Type["PK_LU_Construction_Firm_Type"];

            if (drLU_Construction_Firm_Type["CFT_Desc"] == DBNull.Value)
                this._CFT_Desc = null;
            else
                this._CFT_Desc = (string)drLU_Construction_Firm_Type["CFT_Desc"];

            if (drLU_Construction_Firm_Type["Active"] == DBNull.Value)
                this._Active = null;
            else
                this._Active = (string)drLU_Construction_Firm_Type["Active"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Construction_Firm_Type table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Construction_Firm_TypeInsert");


            if (string.IsNullOrEmpty(this._CFT_Desc))
                db.AddInParameter(dbCommand, "CFT_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CFT_Desc", DbType.String, this._CFT_Desc);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Construction_Firm_Type table.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet Select(decimal pK_LU_Construction_Firm_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Construction_Firm_TypeSelect");

            db.AddInParameter(dbCommand, "PK_LU_Construction_Firm_Type", DbType.Decimal, pK_LU_Construction_Firm_Type);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Construction_Firm_Type table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Construction_Firm_TypeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Construction_Firm_Type table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Construction_Firm_TypeUpdate");


            db.AddInParameter(dbCommand, "PK_LU_Construction_Firm_Type", DbType.Decimal, this._PK_LU_Construction_Firm_Type);

            if (string.IsNullOrEmpty(this._CFT_Desc))
                db.AddInParameter(dbCommand, "CFT_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CFT_Desc", DbType.String, this._CFT_Desc);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the LU_Construction_Firm_Type table by a composite primary key.
        /// </summary>
        public static void Delete(decimal pK_LU_Construction_Firm_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Construction_Firm_TypeDelete");

            db.AddInParameter(dbCommand, "PK_LU_Construction_Firm_Type", DbType.Decimal, pK_LU_Construction_Firm_Type);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Check Firm Type Duplication
        /// </summary>
        /// <returns>Count</returns>
        public int CheckFirmTypeDuplication(decimal pk_LU_Construction_Firm_Type, string type_Description)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Construction_Firm_TypeCheck");

            db.AddInParameter(dbCommand, "PK_LU_Construction_Firm_Type", DbType.Decimal, pk_LU_Construction_Firm_Type);
            db.AddInParameter(dbCommand, "CFT_Desc", DbType.String, type_Description);

            return Convert.ToInt32(db.ExecuteScalar(dbCommand));
        }
	}
}
