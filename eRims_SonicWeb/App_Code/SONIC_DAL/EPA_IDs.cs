using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for EPA_IDs table.
	/// </summary>
	public sealed class EPA_IDs
    {
        #region Fields


        private int _PK_Enviro_Permit_ID;
        private int _FK_LU_Location_ID;
        private string _type;
        private string _ID_Number;
        private DateTime _Update_Date;
        private string _Updated_By;
        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Enviro_Permit_ID value.
        /// </summary>
        public int PK_Enviro_Permit_ID
        {
            get { return _PK_Enviro_Permit_ID; }
            set { _PK_Enviro_Permit_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_LU_Location_ID value.
        /// </summary>
        public int FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the type value.
        /// </summary>
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }


        /// <summary> 
        /// Gets or sets the ID_Number value.
        /// </summary>
        public string ID_Number
        {
            get { return _ID_Number; }
            set { _ID_Number = value; }
        }

        /// <summary> 
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }


        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the EPA_IDs class. with the default value.

        /// </summary>
        public EPA_IDs()
        {

            this._PK_Enviro_Permit_ID = -1;
            this._FK_LU_Location_ID = -1;
            this._type = "";
            this._ID_Number = "";
            this._Updated_By = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }



        /// <summary> 

        /// Initializes a new instance of the EPA_IDs class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public EPA_IDs(int PK)
        {

            DataTable dtEPA_IDs = SelectByPK(PK).Tables[0];

            if (dtEPA_IDs.Rows.Count > 0)
            {

                DataRow drEPA_IDs = dtEPA_IDs.Rows[0];

                this._PK_Enviro_Permit_ID = drEPA_IDs["PK_Enviro_Permit_ID"] != DBNull.Value ? Convert.ToInt32(drEPA_IDs["PK_Enviro_Permit_ID"]) : 0;
                this._FK_LU_Location_ID = drEPA_IDs["FK_LU_Location_ID"] != DBNull.Value ? Convert.ToInt32(drEPA_IDs["FK_LU_Location_ID"]) : 0;
                this._type = Convert.ToString(drEPA_IDs["type"]);
                this._ID_Number = Convert.ToString(drEPA_IDs["ID_Number"]);
                this._Updated_By = drEPA_IDs["Updated_By"].ToString();
                this._Update_Date = drEPA_IDs["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drEPA_IDs["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

            else
            {

                this._PK_Enviro_Permit_ID = -1;
                this._FK_LU_Location_ID = -1;
                this._type = "";
                this._ID_Number = "";
                this._Updated_By = "";
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

        }



        #endregion


        #region Methods

        /// <summary>
		/// Inserts a record into the EPA_IDs table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPA_IDsInsert");

			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);
			db.AddInParameter(dbCommand, "type", DbType.String, this._type);
			db.AddInParameter(dbCommand, "ID_Number", DbType.String, this._ID_Number);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, clsSession.UserID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the EPA_IDs table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(int pK_Enviro_Permit_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPA_IDsSelectByPK");

			db.AddInParameter(dbCommand, "PK_Enviro_Permit_ID", DbType.Int32, pK_Enviro_Permit_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the EPA_IDs table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPA_IDsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects records from the EPA_IDs table by a Foreign Key LocationID.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByLocationID(int Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPA_IDsSelectByLU_Location_ID");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Updates a record in the EPA_IDs table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPA_IDsUpdate");

			db.AddInParameter(dbCommand, "PK_Enviro_Permit_ID", DbType.Int32, this._PK_Enviro_Permit_ID);
			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);
			db.AddInParameter(dbCommand, "type", DbType.String, this._type);
			db.AddInParameter(dbCommand, "ID_Number", DbType.String, this._ID_Number);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, clsSession.UserID);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the EPA_IDs table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(int pK_Enviro_Permit_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPA_IDsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Enviro_Permit_ID", DbType.Int32, pK_Enviro_Permit_ID);

			db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
