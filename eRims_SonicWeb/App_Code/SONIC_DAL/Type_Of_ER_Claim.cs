using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Type_Of_ER_Claim table.
	/// </summary>
	public sealed class Type_Of_ER_Claim
    {
        #region Fields


        private decimal _PK_Type_Of_ER_Claim;
        private string _Fld_Desc;
        private string _Active;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Type_Of_ER_Claim value.
        /// </summary>
        public decimal PK_Type_Of_ER_Claim
        {
            get { return _PK_Type_Of_ER_Claim; }
            set { _PK_Type_Of_ER_Claim = value; }
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
        /// Gets or sets the Fld_Desc value.
        /// </summary>
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Type_Of_ER_Claim class. with the default value.

        /// </summary>
        public Type_Of_ER_Claim()
        {

            this._PK_Type_Of_ER_Claim = -1;
            this._Fld_Desc = "";
            this._Active = "";

        }



        /// <summary> 

        /// Initializes a new instance of the Type_Of_ER_Claim class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Type_Of_ER_Claim(decimal PK)
        {

            DataTable dtType_Of_ER_Claim = SelectByPK(PK).Tables[0];

            if (dtType_Of_ER_Claim.Rows.Count > 0)
            {

                DataRow drType_Of_ER_Claim = dtType_Of_ER_Claim.Rows[0];

                this._PK_Type_Of_ER_Claim = drType_Of_ER_Claim["PK_Type_Of_ER_Claim"] != DBNull.Value ? Convert.ToDecimal(drType_Of_ER_Claim["PK_Type_Of_ER_Claim"]) : 0;
                this._Fld_Desc = Convert.ToString(drType_Of_ER_Claim["Fld_Desc"]);
                this._Active = Convert.ToString(drType_Of_ER_Claim["Active"]);

            }

            else
            {

                this._PK_Type_Of_ER_Claim = -1;
                this._Fld_Desc = "";
                this._Active = "";

            }

        }



        #endregion

        #region "Methods"
        /// <summary>
        /// Inserts a record into the Type_Of_ER_Claim table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            //Database db = DatabaseFactory.CreateDatabase();
            //DbCommand dbCommand = db.GetStoredProcCommand("Type_Of_ER_ClaimInsert");

            //db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
            //db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            //// Execute the query and return the new identity value
            //int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            //return returnValue;
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Type_Of_ER_ClaimInsert");


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
		/// Selects a single record from the Type_Of_ER_Claim table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_Type_Of_ER_Claim)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Type_Of_ER_ClaimSelectByPK");

			db.AddInParameter(dbCommand, "PK_Type_Of_ER_Claim", DbType.Decimal, pK_Type_Of_ER_Claim);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Type_Of_ER_Claim table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Type_Of_ER_ClaimSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        ///// <summary>
        ///// Updates a record in the Type_Of_ER_Claim table.
        ///// </summary>
        //public void Update()
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("Type_Of_ER_ClaimUpdate");

        //    db.AddInParameter(dbCommand, "PK_Type_Of_ER_Claim", DbType.Decimal, this._PK_Type_Of_ER_Claim);
        //    db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
        //    db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        /// <summary>
        /// Updates a record in the Type_Of_ER_Claim table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Type_Of_ER_ClaimUpdate");


            db.AddInParameter(dbCommand, "PK_Type_Of_ER_Claim", DbType.Decimal, this._PK_Type_Of_ER_Claim);

            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            db.ExecuteNonQuery(dbCommand);
            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
        }

		/// <summary>
		/// Deletes a record from the Type_Of_ER_Claim table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Type_Of_ER_Claim)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Type_Of_ER_ClaimDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Type_Of_ER_Claim", DbType.Decimal, pK_Type_Of_ER_Claim);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
