using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Assoc_Right_Group table.
	/// </summary>
	public sealed class Assoc_Right_Group
    {
        #region Fields


        private int _Assoc_Right_Group_ID;
        private int _FK_Group_ID;
        private int _FK_Right_ID;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the Assoc_Right_Group_ID value.
        /// </summary>
        public int Assoc_Right_Group_ID
        {
            get { return _Assoc_Right_Group_ID; }
            set { _Assoc_Right_Group_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Group_ID value.
        /// </summary>
        public int FK_Group_ID
        {
            get { return _FK_Group_ID; }
            set { _FK_Group_ID = value; }
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

        /// Initializes a new instance of the Assoc_Right_Group class. with the default value.

        /// </summary>
        public Assoc_Right_Group()
        {

            this._Assoc_Right_Group_ID = -1;
            this._FK_Group_ID = -1;
            this._FK_Right_ID = -1;

        }



        /// <summary> 

        /// Initializes a new instance of the Assoc_Right_Group class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Assoc_Right_Group(int PK)
        {

            DataTable dtAssoc_Right_Group = SelectByPK(PK).Tables[0];

            if (dtAssoc_Right_Group.Rows.Count > 0)
            {

                DataRow drAssoc_Right_Group = dtAssoc_Right_Group.Rows[0];

                this._Assoc_Right_Group_ID = drAssoc_Right_Group["Assoc_Right_Group_ID"] != DBNull.Value ? Convert.ToInt32(drAssoc_Right_Group["Assoc_Right_Group_ID"]) : 0;
                this._FK_Group_ID = drAssoc_Right_Group["FK_Group_ID"] != DBNull.Value ? Convert.ToInt32(drAssoc_Right_Group["FK_Group_ID"]) : 0;
                this._FK_Right_ID = drAssoc_Right_Group["FK_Right_ID"] != DBNull.Value ? Convert.ToInt32(drAssoc_Right_Group["FK_Right_ID"]) : 0;

            }

            else
            {

                this._Assoc_Right_Group_ID = -1;
                this._FK_Group_ID = -1;
                this._FK_Right_ID = -1;

            }

        }



        #endregion

        #region Methods
        /// <summary>
		/// Inserts a record into the Assoc_Right_Group table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Right_GroupInsert");

			db.AddInParameter(dbCommand, "FK_Group_ID", DbType.Int32, this._FK_Group_ID);
			db.AddInParameter(dbCommand, "FK_Right_ID", DbType.Int32, this._FK_Right_ID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Assoc_Right_Group table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(int assoc_Right_Group_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Right_GroupSelectByPK");

			db.AddInParameter(dbCommand, "Assoc_Right_Group_ID", DbType.Int32, assoc_Right_Group_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Assoc_Right_Group table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Right_GroupSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Assoc_Right_Group table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Right_GroupUpdate");

			db.AddInParameter(dbCommand, "Assoc_Right_Group_ID", DbType.Int32, this._Assoc_Right_Group_ID);
			db.AddInParameter(dbCommand, "FK_Group_ID", DbType.Int32, this._FK_Group_ID);
			db.AddInParameter(dbCommand, "FK_Right_ID", DbType.Int32, this._FK_Right_ID);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Assoc_Right_Group table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(int assoc_Right_Group_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Right_GroupDeleteByPK");

			db.AddInParameter(dbCommand, "Assoc_Right_Group_ID", DbType.Int32, assoc_Right_Group_ID);

			db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Assoc_Right_Group table by a Group ID.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByGroupID(int @FK_Group_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("selectByGroupID");

            db.AddInParameter(dbCommand, "FK_Group_ID", DbType.Int32, FK_Group_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Deletes a record from the Assoc_Right_Group table by a Group ID.
        /// </summary>
        public static void DeleteByGroupID(int FK_Group_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Right_GroupDeleteByGroup");

            db.AddInParameter(dbCommand, "FK_Group_ID", DbType.Int32, FK_Group_ID);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
