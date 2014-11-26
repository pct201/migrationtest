using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{

    /// <summary>
	/// Data access class for Regional_Access table.
	/// </summary>
	public sealed class Regional_Access
	{
        #region Fields


        private int _PK_Regional_access_id;
        private string _Region;
        private int _FK_Security_ID;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Regional_access_id value.
        /// </summary>
        public int PK_Regional_access_id
        {
            get { return _PK_Regional_access_id; }
            set { _PK_Regional_access_id = value; }
        }


        /// <summary> 
        /// Gets or sets the Region value.
        /// </summary>
        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Security_ID value.
        /// </summary>
        public int FK_Security_ID
        {
            get { return _FK_Security_ID; }
            set { _FK_Security_ID = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Regional_Access class. with the default value.

        /// </summary>
        public Regional_Access()
        {

            this._PK_Regional_access_id = -1;
            this._Region = "";
            this._FK_Security_ID = -1;

        }



        /// <summary> 

        /// Initializes a new instance of the Regional_Access class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Regional_Access(int PK)
        {

            DataTable dtRegional_Access = SelectByPK(PK).Tables[0];

            if (dtRegional_Access.Rows.Count > 0)
            {

                DataRow drRegional_Access = dtRegional_Access.Rows[0];

                this._PK_Regional_access_id = drRegional_Access["PK_Regional_access_id"] != DBNull.Value ? Convert.ToInt32(drRegional_Access["PK_Regional_access_id"]) : 0;
                this._Region = Convert.ToString(drRegional_Access["Region"]);
                this._FK_Security_ID = drRegional_Access["FK_Security_ID"] != DBNull.Value ? Convert.ToInt32(drRegional_Access["FK_Security_ID"]) : 0;

            }

            else
            {

                this._PK_Regional_access_id = -1;
                this._Region = "";
                this._FK_Security_ID = -1;

            }

        }



        #endregion


    #region Methods

		/// <summary>
		/// Inserts a record into the Regional_Access table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Regional_AccessInsert");

			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
			db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Int32, this._FK_Security_ID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Regional_Access table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(int pK_Regional_access_id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Regional_AccessSelectByPK");

			db.AddInParameter(dbCommand, "PK_Regional_access_id", DbType.Int32, pK_Regional_access_id);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Regional_Access table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Regional_AccessSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Regional_Access table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Regional_AccessUpdate");

			db.AddInParameter(dbCommand, "PK_Regional_access_id", DbType.Int32, this._PK_Regional_access_id);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
			db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Int32, this._FK_Security_ID);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Regional_Access table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(int pK_Regional_access_id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Regional_AccessDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Regional_access_id", DbType.Int32, pK_Regional_access_id);

			db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Regional_Access table by a composite primary key.
        /// </summary>
        public static void DeleteBySecurityID(int FK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Regional_AccessDeleteBySecurityID");

            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Int32, FK_Security_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Regional_Access table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBySecurityID(int FK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Regional_AccessSelectBySecurity");

            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Int32, FK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }

    #endregion
    }
    
}
