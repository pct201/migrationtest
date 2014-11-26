using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Flood_Zone table.
	/// </summary>
	public sealed class Flood_Zone
	{

        #region Fields

        private decimal _PK_Flood_Zone;
        private string _Fld_Desc;

        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_Flood_Zone value.
        /// </summary>
        public decimal PK_Flood_Zone
        {
            get { return _PK_Flood_Zone; }
            set { _PK_Flood_Zone = value; }
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
        /// Initializes a new instance of the Flood_Zone class. with the default value.
        /// </summary>
        public Flood_Zone()
        {
            this._PK_Flood_Zone = -1;
            this._Fld_Desc = "";
        }



        /// <summary> 
        /// Initializes a new instance of the Flood_Zone class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Flood_Zone(decimal PK)
        {

            DataTable dtFlood_Zone = SelectByPK(PK).Tables[0];

            if (dtFlood_Zone.Rows.Count > 0)
            {

                DataRow drFlood_Zone = dtFlood_Zone.Rows[0];

                this._PK_Flood_Zone = drFlood_Zone["PK_Flood_Zone"] != DBNull.Value ? Convert.ToDecimal(drFlood_Zone["PK_Flood_Zone"]) : 0;
                this._Fld_Desc = Convert.ToString(drFlood_Zone["Fld_Desc"]);

            }

            else
            {

                this._PK_Flood_Zone = -1;
                this._Fld_Desc = "";

            }

        }
        #endregion

        #region "Methods"
        /// <summary>
		/// Inserts a record into the Flood_Zone table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Flood_ZoneInsert");

			db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Flood_Zone table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_Flood_Zone)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Flood_ZoneSelectByPK");

			db.AddInParameter(dbCommand, "PK_Flood_Zone", DbType.Decimal, pK_Flood_Zone);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Flood_Zone table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Flood_ZoneSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Flood_Zone table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Flood_ZoneUpdate");

			db.AddInParameter(dbCommand, "PK_Flood_Zone", DbType.Decimal, this._PK_Flood_Zone);
			db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Flood_Zone table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Flood_Zone)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Flood_ZoneDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Flood_Zone", DbType.Decimal, pK_Flood_Zone);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
       
}
