using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Type_Of_ER_Allegation table.
	/// </summary>
	public sealed class Type_Of_ER_Allegation
	{
        #region Fields

        private string _Fld_Desc;
        private decimal _PK_Type_Of_ER_Allegation;
        private string _Active;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the Fld_Desc value.
        /// </summary>
        public string Fld_Desc
        {
            get { return _Fld_Desc; }
            set { _Fld_Desc = value; }
        }


        /// <summary> 
        /// Gets or sets the PK_Type_Of_ER_Allegation value.
        /// </summary>
        public decimal PK_Type_Of_ER_Allegation
        {
            get { return _PK_Type_Of_ER_Allegation; }
            set { _PK_Type_Of_ER_Allegation = value; }
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


        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Type_Of_ER_Allegation class. with the default value.
        /// </summary>
        public Type_Of_ER_Allegation()
        {
            this._Fld_Desc = "";
            this._PK_Type_Of_ER_Allegation = -1;
            this._Active = "";

        }



        /// <summary> 
        /// Initializes a new instance of the Type_Of_ER_Allegation class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Type_Of_ER_Allegation(decimal PK)
        {

            DataTable dtType_Of_ER_Allegation = SelectByPK(PK).Tables[0];

            if (dtType_Of_ER_Allegation.Rows.Count > 0)
            {

                DataRow drType_Of_ER_Allegation = dtType_Of_ER_Allegation.Rows[0];
                this._Fld_Desc = Convert.ToString(drType_Of_ER_Allegation["Fld_Desc"]);
                this._PK_Type_Of_ER_Allegation = drType_Of_ER_Allegation["PK_Type_Of_ER_Allegation"] != DBNull.Value ? Convert.ToDecimal(drType_Of_ER_Allegation["PK_Type_Of_ER_Allegation"]) : 0;
                this._Active = Convert.ToString(drType_Of_ER_Allegation["Active"]);
            }

            else
            {
                this._Fld_Desc = "";
                this._PK_Type_Of_ER_Allegation = -1;
                this._Active = "";

            }

        }



        #endregion

        #region "Methods"
        /// <summary>
		/// Inserts a record into the Type_Of_ER_Allegation table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            //Database db = DatabaseFactory.CreateDatabase();
            //DbCommand dbCommand = db.GetStoredProcCommand("Type_Of_ER_AllegationInsert");

            //db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
            //db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);


            //// Execute the query and return the new identity value
            //int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            //return returnValue;
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Type_Of_ER_AllegationInsert");


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
		/// Selects a single record from the Type_Of_ER_Allegation table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_Type_Of_ER_Allegation)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Type_Of_ER_AllegationSelectByPK");

			db.AddInParameter(dbCommand, "PK_Type_Of_ER_Allegation", DbType.Decimal, pK_Type_Of_ER_Allegation);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Type_Of_ER_Allegation table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Type_Of_ER_AllegationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Type_Of_ER_Allegation table.
		/// </summary>
        public decimal Update()
		{
            //Database db = DatabaseFactory.CreateDatabase();
            //DbCommand dbCommand = db.GetStoredProcCommand("Type_Of_ER_AllegationUpdate");

            //db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
            //db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
            //db.AddInParameter(dbCommand, "PK_Type_Of_ER_Allegation", DbType.Decimal, this._PK_Type_Of_ER_Allegation);

            //db.ExecuteNonQuery(dbCommand);
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Type_Of_ER_AllegationUpdate");


            db.AddInParameter(dbCommand, "PK_Type_Of_ER_Allegation", DbType.Decimal, this._PK_Type_Of_ER_Allegation);

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
		/// Deletes a record from the Type_Of_ER_Allegation table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Type_Of_ER_Allegation)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Type_Of_ER_AllegationDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Type_Of_ER_Allegation", DbType.Decimal, pK_Type_Of_ER_Allegation);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
