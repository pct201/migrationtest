using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Policy_Type table.
	/// </summary>
	public sealed class Policy_Type
    {
        #region Fields


        private decimal _PK_ID;
        private string _FLD_desc;
        private string _FLD_code;
        private decimal _Program_ID;
        private string _Active;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_ID value.
        /// </summary>
        public decimal PK_ID
        {
            get { return _PK_ID; }
            set { _PK_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FLD_desc value.
        /// </summary>
        public string FLD_desc
        {
            get { return _FLD_desc; }
            set { _FLD_desc = value; }
        }


        /// <summary> 
        /// Gets or sets the FLD_code value.
        /// </summary>
        public string FLD_code
        {
            get { return _FLD_code; }
            set { _FLD_code = value; }
        }


        /// <summary> 
        /// Gets or sets the Program_ID value.
        /// </summary>
        public decimal Program_ID
        {
            get { return _Program_ID; }
            set { _Program_ID = value; }
        }

        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        #endregion


        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Policy_Type class. with the default value.
        /// </summary>
        public Policy_Type()
        {

            this._PK_ID = -1;
            this._FLD_desc = "";
            this._FLD_code = "";
            this._Program_ID = -1;
            this._Active = "";
        }



        /// <summary> 
        /// Initializes a new instance of the Policy_Type class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Policy_Type(decimal PK)
        {

            DataTable dtPolicy_Type = SelectByPK(PK).Tables[0];

            if (dtPolicy_Type.Rows.Count > 0)
            {

                DataRow drPolicy_Type = dtPolicy_Type.Rows[0];

                this._PK_ID = drPolicy_Type["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drPolicy_Type["PK_ID"]) : 0;
                this._FLD_desc = Convert.ToString(drPolicy_Type["FLD_desc"]);
                this._FLD_code = Convert.ToString(drPolicy_Type["FLD_code"]);
                this._Program_ID = drPolicy_Type["Program_ID"] != DBNull.Value ? Convert.ToDecimal(drPolicy_Type["Program_ID"]) : 0;
                this._Active = Convert.ToString(drPolicy_Type["Active"]);

            }

            else
            {

                this._PK_ID = -1;
                this._FLD_desc = "";
                this._FLD_code = "";
                this._Program_ID = -1;
                this._Active = "";
            }

        }



        #endregion


        #region Methods

        /// <summary>
		/// Inserts a record into the Policy_Type table.
		/// </summary>
		/// <returns></returns>
		public decimal Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Policy_TypeInsert");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FLD_desc", DbType.String, this._FLD_desc);
			db.AddInParameter(dbCommand, "FLD_code", DbType.String, this._FLD_code);
			db.AddInParameter(dbCommand, "Program_ID", DbType.Decimal, this._Program_ID);
            db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
			decimal returnValue = Convert.ToDecimal(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Policy_Type table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Policy_TypeSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Policy_Type table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Policy_TypeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Policy_Type table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Policy_TypeUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FLD_desc", DbType.String, this._FLD_desc);
			db.AddInParameter(dbCommand, "FLD_code", DbType.String, this._FLD_code);
			db.AddInParameter(dbCommand, "Program_ID", DbType.Decimal, this._Program_ID);
            db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
            decimal returnValue = Convert.ToDecimal(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the Policy_Type table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Policy_TypeDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
