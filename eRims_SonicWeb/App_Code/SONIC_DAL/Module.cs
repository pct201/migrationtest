using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Module table.
	/// </summary>
	public sealed class Module
    {
        #region Fields


        private decimal _ModuleId;
        private string _ModuleName;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the ModuleId value.
        /// </summary>
        public decimal ModuleId
        {
            get { return _ModuleId; }
            set { _ModuleId = value; }
        }


        /// <summary> 
        /// Gets or sets the ModuleName value.
        /// </summary>
        public string ModuleName
        {
            get { return _ModuleName; }
            set { _ModuleName = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Module class. with the default value.

        /// </summary>
        public Module()
        {

            this._ModuleId = -1;
            this._ModuleName = "";

        }



        /// <summary> 

        /// Initializes a new instance of the Module class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Module(decimal PK)
        {

            DataTable dtModule = SelectByPK(PK).Tables[0];

            if (dtModule.Rows.Count > 0)
            {

                DataRow drModule = dtModule.Rows[0];

                this._ModuleId = drModule["ModuleId"] != DBNull.Value ? Convert.ToDecimal(drModule["ModuleId"]) : 0;
                this._ModuleName = Convert.ToString(drModule["ModuleName"]);

            }

            else
            {

                this._ModuleId = -1;
                this._ModuleName = "";

            }

        }



        #endregion


        #region Methods
        /// <summary>
		/// Inserts a record into the Module table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ModuleInsert");

			db.AddInParameter(dbCommand, "ModuleName", DbType.String, this._ModuleName);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Module table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal moduleId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ModuleSelectByPK");

			db.AddInParameter(dbCommand, "ModuleId", DbType.Decimal, moduleId);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Module table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ModuleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Module table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ModuleUpdate");

			db.AddInParameter(dbCommand, "ModuleId", DbType.Decimal, this._ModuleId);
			db.AddInParameter(dbCommand, "ModuleName", DbType.String, this._ModuleName);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Module table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal moduleId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ModuleDeleteByPK");

			db.AddInParameter(dbCommand, "ModuleId", DbType.Decimal, moduleId);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion


    }
}
