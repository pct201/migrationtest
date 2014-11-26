using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for DPD_Witness table.
	/// </summary>
	public sealed class DPD_Witness
    {

        #region Fields
        private decimal _PK_DPD_Witness_ID;
        private decimal _FK_DPD_FR_ID;
        private string _Name;
        private string _Address;
        private string _Phone;
        private decimal _Updated_By;
        private DateTime _Updated_Date;

        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_DPD_Witness_ID value.
        /// </summary>
        public decimal PK_DPD_Witness_ID
        {
            get { return _PK_DPD_Witness_ID; }
            set { _PK_DPD_Witness_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_DPD_FR_ID value.
        /// </summary>
        public decimal FK_DPD_FR_ID
        {
            get { return _FK_DPD_FR_ID; }
            set { _FK_DPD_FR_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Name value.
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Address value.
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }


        /// <summary> 
        /// Gets or sets the Phone value.
        /// </summary>
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public decimal Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }


        /// <summary> 
        /// Gets or sets the Updated_Date value.
        /// </summary>
        public DateTime Updated_Date
        {
            get { return _Updated_Date; }
            set { _Updated_Date = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the DPD_Witness class. with the default value.

        /// </summary>
        public DPD_Witness()
        {

            this._PK_DPD_Witness_ID = -1;
            this._FK_DPD_FR_ID = -1;
            this._Name = "";
            this._Address = "";
            this._Phone = "";
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 
        /// Initializes a new instance of the DPD_Witness class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public DPD_Witness(decimal PK)
        {

            DataTable dtDPD_Witness = SelectByPK(PK).Tables[0];

            if (dtDPD_Witness.Rows.Count > 0)
            {

                DataRow drDPD_Witness = dtDPD_Witness.Rows[0];

                this._PK_DPD_Witness_ID = drDPD_Witness["PK_DPD_Witness_ID"] != DBNull.Value ? Convert.ToDecimal(drDPD_Witness["PK_DPD_Witness_ID"]) : 0;
                this._FK_DPD_FR_ID = drDPD_Witness["FK_DPD_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drDPD_Witness["FK_DPD_FR_ID"]) : 0;
                this._Name = Convert.ToString(drDPD_Witness["Name"]);
                this._Address = Convert.ToString(drDPD_Witness["Address"]);
                this._Phone = Convert.ToString(drDPD_Witness["Phone"]);
                this._Updated_By = drDPD_Witness["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drDPD_Witness["Updated_By"]) : 0;
                this._Updated_Date = drDPD_Witness["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drDPD_Witness["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._PK_DPD_Witness_ID = -1;
                this._FK_DPD_FR_ID = -1;
                this._Name = "";
                this._Address = "";
                this._Phone = "";
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }



        #endregion


        #region MEthods
        /// <summary>
		/// Inserts a record into the DPD_Witness table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("DPD_WitnessInsert");

			db.AddInParameter(dbCommand, "FK_DPD_FR_ID", DbType.Decimal, this._FK_DPD_FR_ID);
			db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);
			db.AddInParameter(dbCommand, "Address", DbType.String, this._Address);
			db.AddInParameter(dbCommand, "Phone", DbType.String, this._Phone);
			db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the DPD_Witness table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_DPD_Witness_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("DPD_WitnessSelectByPK");

			db.AddInParameter(dbCommand, "PK_DPD_Witness_ID", DbType.Decimal, pK_DPD_Witness_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the DPD_Witness table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("DPD_WitnessSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the DPD_Witness table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("DPD_WitnessUpdate");

			db.AddInParameter(dbCommand, "PK_DPD_Witness_ID", DbType.Decimal, this._PK_DPD_Witness_ID);
			db.AddInParameter(dbCommand, "FK_DPD_FR_ID", DbType.Decimal, this._FK_DPD_FR_ID);
			db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);
			db.AddInParameter(dbCommand, "Address", DbType.String, this._Address);
			db.AddInParameter(dbCommand, "Phone", DbType.String, this._Phone);
			db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the DPD_Witness table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_DPD_Witness_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("DPD_WitnessDeleteByPK");

			db.AddInParameter(dbCommand, "PK_DPD_Witness_ID", DbType.Decimal, pK_DPD_Witness_ID);

			db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the DPD_Witness table by a FK.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal FK_DPD_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_WitnessSelectByFK");

            db.AddInParameter(dbCommand, "FK_DPD_FR_ID", DbType.Decimal, FK_DPD_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        
        #endregion
    }
}
