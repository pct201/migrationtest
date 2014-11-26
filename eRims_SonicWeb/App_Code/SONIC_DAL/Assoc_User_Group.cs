using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Assoc_User_Group table.
	/// </summary>
	public sealed class Assoc_User_Group
    {
        #region Fields


        private int _PK_Assoc_User_Group_ID;
        private int _FK_User_ID;
        private int _FK_Group_ID;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Assoc_User_Group_ID value.
        /// </summary>
        public int PK_Assoc_User_Group_ID
        {
            get { return _PK_Assoc_User_Group_ID; }
            set { _PK_Assoc_User_Group_ID = value; }
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
        /// Gets or sets the FK_Group_ID value.
        /// </summary>
        public int FK_Group_ID
        {
            get { return _FK_Group_ID; }
            set { _FK_Group_ID = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Assoc_User_Group class. with the default value.

        /// </summary>
        public Assoc_User_Group()
        {

            this._PK_Assoc_User_Group_ID = -1;
            this._FK_User_ID = -1;
            this._FK_Group_ID = -1;

        }



        /// <summary> 

        /// Initializes a new instance of the Assoc_User_Group class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Assoc_User_Group(int PK)
        {

            DataTable dtAssoc_User_Group = SelectByPK(PK).Tables[0];

            if (dtAssoc_User_Group.Rows.Count > 0)
            {

                DataRow drAssoc_User_Group = dtAssoc_User_Group.Rows[0];

                this._PK_Assoc_User_Group_ID = drAssoc_User_Group["PK_Assoc_User_Group_ID"] != DBNull.Value ? Convert.ToInt32(drAssoc_User_Group["PK_Assoc_User_Group_ID"]) : 0;
                this._FK_User_ID = drAssoc_User_Group["FK_User_ID"] != DBNull.Value ? Convert.ToInt32(drAssoc_User_Group["FK_User_ID"]) : 0;
                this._FK_Group_ID = drAssoc_User_Group["FK_Group_ID"] != DBNull.Value ? Convert.ToInt32(drAssoc_User_Group["FK_Group_ID"]) : 0;

            }

            else
            {

                this._PK_Assoc_User_Group_ID = -1;
                this._FK_User_ID = -1;
                this._FK_Group_ID = -1;

            }

        }



        #endregion

        #region Methods
        /// <summary>
		/// Inserts a record into the Assoc_User_Group table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_User_GroupInsert");

			db.AddInParameter(dbCommand, "FK_User_ID", DbType.Int32, this._FK_User_ID);
			db.AddInParameter(dbCommand, "FK_Group_ID", DbType.Int32, this._FK_Group_ID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Assoc_User_Group table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(int pK_Assoc_User_Group_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_User_GroupSelectByPK");

			db.AddInParameter(dbCommand, "PK_Assoc_User_Group_ID", DbType.Int32, pK_Assoc_User_Group_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Assoc_User_Group table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_User_GroupSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Assoc_User_Group table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_User_GroupUpdate");

			db.AddInParameter(dbCommand, "PK_Assoc_User_Group_ID", DbType.Int32, this._PK_Assoc_User_Group_ID);
			db.AddInParameter(dbCommand, "FK_User_ID", DbType.Int32, this._FK_User_ID);
			db.AddInParameter(dbCommand, "FK_Group_ID", DbType.Int32, this._FK_Group_ID);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Assoc_User_Group table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(int pK_Assoc_User_Group_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_User_GroupDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Assoc_User_Group_ID", DbType.Int32, pK_Assoc_User_Group_ID);

			db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Assoc_User_Group table by a User ID.
        /// </summary>
        public static void DeleteByUserID(int FK_User_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_User_GroupDeleteByUser");

            db.AddInParameter(dbCommand, "FK_User_ID", DbType.Int32, FK_User_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Assoc_User_Group table by User ID.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByUserID(int FK_User_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_User_GroupSelectByUserID");
            db.AddInParameter(dbCommand, "FK_User_ID", DbType.Int32, FK_User_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Inserts a record into the Assoc_User_Group table.
        /// </summary>
        /// <returns></returns>
        public int GetUserAssociateWithGroup(int FK_Group_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetUserAssociateWithGroup");

            db.AddInParameter(dbCommand, "FK_Group_ID", DbType.Int32, FK_Group_ID);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }
        #endregion
    }
}
