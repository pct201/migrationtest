using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Group table.
	/// </summary>
	public sealed class Group
    {
        #region Fields


        private int _PK_Group_ID;
        private string _Group_Name;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Group_ID value.
        /// </summary>
        public int PK_Group_ID
        {
            get { return _PK_Group_ID; }
            set { _PK_Group_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Group_Name value.
        /// </summary>
        public string Group_Name
        {
            get { return _Group_Name; }
            set { _Group_Name = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Group class. with the default value.

        /// </summary>
        public Group()
        {

            this._PK_Group_ID = -1;
            this._Group_Name = "";

        }



        /// <summary> 

        /// Initializes a new instance of the Group class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Group(int PK)
        {

            DataTable dtGroup = SelectByPK(PK).Tables[0];

            if (dtGroup.Rows.Count > 0)
            {

                DataRow drGroup = dtGroup.Rows[0];

                this._PK_Group_ID = drGroup["PK_Group_ID"] != DBNull.Value ? Convert.ToInt32(drGroup["PK_Group_ID"]) : 0;
                this._Group_Name = Convert.ToString(drGroup["Group_Name"]);

            }

            else
            {

                this._PK_Group_ID = -1;
                this._Group_Name = "";

            }

        }



        #endregion

        #region Methods

        /// <summary>
		/// Inserts a record into the Group table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("GroupInsert");

			db.AddInParameter(dbCommand, "Group_Name", DbType.String, this._Group_Name);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Group table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(int pK_Group_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("GroupSelectByPK");

			db.AddInParameter(dbCommand, "PK_Group_ID", DbType.Int32, pK_Group_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Group table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("GroupSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Group table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("GroupUpdate");

			db.AddInParameter(dbCommand, "PK_Group_ID", DbType.Int32, this._PK_Group_ID);
			db.AddInParameter(dbCommand, "Group_Name", DbType.String, this._Group_Name);
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the Group table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(int pK_Group_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("GroupDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Group_ID", DbType.Int32, pK_Group_ID);

			db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
