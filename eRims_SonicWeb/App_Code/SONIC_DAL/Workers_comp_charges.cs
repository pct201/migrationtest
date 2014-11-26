using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for workers_comp_charges table.
	/// </summary>
	public sealed class Workers_comp_charges
    {
        #region Fields
 
        private string _Cause;
        private decimal _Charge;
        private string _Region;
        private decimal _Worker_Comp_id;
        private int _Year;

        #endregion
         
         
         #region Properties 
         

        /// <summary> 
        /// Gets or sets the Cause value.
        /// </summary>
        public string Cause
        {
	        get { return _Cause; }
	        set { _Cause = value; }
        }


        /// <summary> 
        /// Gets or sets the Charge value.
        /// </summary>
        public decimal Charge
        {
	        get { return _Charge; }
	        set { _Charge = value; }
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
        /// Gets or sets the Worker_Comp_id value.
        /// </summary>
        public decimal Worker_Comp_id
        {
	        get { return _Worker_Comp_id; }
	        set { _Worker_Comp_id = value; }
        }


        /// <summary> 
        /// Gets or sets the Year value.
        /// </summary>
        public int Year
        {
	        get { return _Year; }
	        set { _Year = value; }
        }



        #endregion
         
         
         #region Constructors 
         
        /// <summary> 

        /// Initializes a new instance of the workers_comp_charges class. with the default value.

        /// </summary>
        public Workers_comp_charges()
        {

	        this._Cause = "";
	        this._Charge = -1;
	        this._Region = "";
	        this._Worker_Comp_id = -1;
	        this._Year = -1;

        }
         


        /// <summary> 

        /// Initializes a new instance of the workers_comp_charges class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public Workers_comp_charges(decimal PK)
        {

	        DataTable dtworkers_comp_charges = SelectByPK(PK).Tables[0];

	        if (dtworkers_comp_charges.Rows.Count > 0)

	        {

		        DataRow drworkers_comp_charges = dtworkers_comp_charges.Rows[0];

		        this._Cause = Convert.ToString(drworkers_comp_charges["Cause"]);
		        this._Charge = drworkers_comp_charges["Charge"] != DBNull.Value ? Convert.ToDecimal(drworkers_comp_charges["Charge"]) : 0;
		        this._Region = Convert.ToString(drworkers_comp_charges["Region"]);
		        this._Worker_Comp_id = drworkers_comp_charges["Worker_Comp_id"] != DBNull.Value ? Convert.ToDecimal(drworkers_comp_charges["Worker_Comp_id"]) : 0;
		        this._Year = drworkers_comp_charges["Year"] != DBNull.Value ? Convert.ToInt32(drworkers_comp_charges["Year"]) : 0;

	        }

	        else

	        {

		        this._Cause = "";
		        this._Charge = -1;
		        this._Region = "";
		        this._Worker_Comp_id = -1;
		        this._Year = -1;

	        }

        }
         


        #endregion



        #region Methods
        /// <summary>
        /// Inserts a record into the workers_comp_charges table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("workers_comp_chargesInsert");

            db.AddInParameter(dbCommand, "Cause", DbType.String, this._Cause);
            db.AddInParameter(dbCommand, "Charge", DbType.Decimal, this._Charge);
            db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the workers_comp_charges table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal worker_Comp_id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("workers_comp_chargesSelectByPK");

            db.AddInParameter(dbCommand, "Worker_Comp_id", DbType.Decimal, worker_Comp_id);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the workers_comp_charges table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll(string strOrderBy)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("workers_comp_chargesSelectAll");
                      
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
          
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the workers_comp_charges table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("workers_comp_chargesUpdate");

            db.AddInParameter(dbCommand, "Cause", DbType.String, this._Cause);
            db.AddInParameter(dbCommand, "Charge", DbType.Decimal, this._Charge);
            db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Worker_Comp_id", DbType.Decimal, this._Worker_Comp_id);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the workers_comp_charges table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal worker_Comp_id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("workers_comp_chargesDeleteByPK");

            db.AddInParameter(dbCommand, "Worker_Comp_id", DbType.Decimal, worker_Comp_id);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the workers_comp_charges table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetDistinctYear()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("workers_comp_charges_GetDistinctYear");

            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
       
	}
}
