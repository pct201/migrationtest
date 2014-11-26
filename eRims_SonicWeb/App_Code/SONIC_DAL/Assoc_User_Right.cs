using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Assoc_User_Right table.
	/// </summary>
	public sealed class Assoc_User_Right
    {
        #region Fields


        private int _PK_Assoc_User_Right_ID;
        private int _FK_User_ID;
        private int _FK_Right_ID;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Assoc_User_Right_ID value.
        /// </summary>
        public int PK_Assoc_User_Right_ID
        {
            get { return _PK_Assoc_User_Right_ID; }
            set { _PK_Assoc_User_Right_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_User_ID value.
        /// </summary>
        public int FK_User_ID
        {
            get { return _FK_User_ID; }
            set { _FK_User_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Right_ID value.
        /// </summary>
        public int FK_Right_ID
        {
            get { return _FK_Right_ID; }
            set { _FK_Right_ID = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Assoc_User_Right class. with the default value.

        /// </summary>
        public Assoc_User_Right()
        {

            this._PK_Assoc_User_Right_ID = -1;
            this._FK_User_ID = -1;
            this._FK_Right_ID = -1;

        }



        /// <summary> 

        /// Initializes a new instance of the Assoc_User_Right class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Assoc_User_Right(int PK)
        {

            DataTable dtAssoc_User_Right = SelectByPK(PK).Tables[0];

            if (dtAssoc_User_Right.Rows.Count > 0)
            {

                DataRow drAssoc_User_Right = dtAssoc_User_Right.Rows[0];

                this._PK_Assoc_User_Right_ID = drAssoc_User_Right["PK_Assoc_User_Right_ID"] != DBNull.Value ? Convert.ToInt32(drAssoc_User_Right["PK_Assoc_User_Right_ID"]) : 0;
                this._FK_User_ID = drAssoc_User_Right["FK_User_ID"] != DBNull.Value ? Convert.ToInt32(drAssoc_User_Right["FK_User_ID"]) : 0;
                this._FK_Right_ID = drAssoc_User_Right["FK_Right_ID"] != DBNull.Value ? Convert.ToInt32(drAssoc_User_Right["FK_Right_ID"]) : 0;

            }

            else
            {

                this._PK_Assoc_User_Right_ID = -1;
                this._FK_User_ID = -1;
                this._FK_Right_ID = -1;

            }

        }



        #endregion


        #region Methods

        /// <summary>
		/// Inserts a record into the Assoc_User_Right table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_User_RightInsert");

			db.AddInParameter(dbCommand, "FK_User_ID", DbType.Int32, this._FK_User_ID);
			db.AddInParameter(dbCommand, "FK_Right_ID", DbType.Int32, this._FK_Right_ID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Assoc_User_Right table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(int pK_Assoc_User_Right_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_User_RightSelectByPK");

			db.AddInParameter(dbCommand, "PK_Assoc_User_Right_ID", DbType.Int32, pK_Assoc_User_Right_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Assoc_User_Right table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_User_RightSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Assoc_User_Right table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_User_RightUpdate");

			db.AddInParameter(dbCommand, "PK_Assoc_User_Right_ID", DbType.Int32, this._PK_Assoc_User_Right_ID);
			db.AddInParameter(dbCommand, "FK_User_ID", DbType.Int32, this._FK_User_ID);
			db.AddInParameter(dbCommand, "FK_Right_ID", DbType.Int32, this._FK_Right_ID);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Assoc_User_Right table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(int pK_Assoc_User_Right_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_User_RightDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Assoc_User_Right_ID", DbType.Int32, pK_Assoc_User_Right_ID);

			db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Assoc_User_Right table by a User ID.
        /// </summary>
        public static void DeleteByUserID(int FK_User_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_User_RightDeleteByUserID");

            db.AddInParameter(dbCommand, "FK_User_ID", DbType.Int32, FK_User_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Assoc_User_Right table by User ID.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByUserID(int FK_User_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_User_RightSelectByUserID");
            db.AddInParameter(dbCommand, "FK_User_ID", DbType.Int32, FK_User_ID);
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
