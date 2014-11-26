using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_Program table.
	/// </summary>
	public sealed class Tatva_Program
	{
        #region Fields


        private decimal _PK_ID;
        private string _Fld_Desc;

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
        /// Gets or sets the Fld_Desc value.
        /// </summary>
        public string Fld_Desc
        {
            get { return _Fld_Desc; }
            set { _Fld_Desc = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Tatva_Program class. with the default value.
        /// </summary>
        public Tatva_Program()
        {

            this._PK_ID = -1;
            this._Fld_Desc = "";

        }



        /// <summary> 
        /// Initializes a new instance of the Tatva_Program class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_Program(decimal PK)
        {

            DataTable dtTatva_Program = SelectByPK(PK).Tables[0];

            if (dtTatva_Program.Rows.Count > 0)
            {

                DataRow drTatva_Program = dtTatva_Program.Rows[0];

                this._PK_ID = drTatva_Program["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_Program["PK_ID"]) : 0;
                this._Fld_Desc = Convert.ToString(drTatva_Program["Fld_Desc"]);

            }

            else
            {

                this._PK_ID = -1;
                this._Fld_Desc = "";

            }

        }



        #endregion

        #region Methods
        /// <summary>
		/// Inserts a record into the Tatva_Program table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ProgramInsert");

			db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_Program table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ProgramSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_Program table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ProgramSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_Program table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ProgramUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_Program table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ProgramDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
