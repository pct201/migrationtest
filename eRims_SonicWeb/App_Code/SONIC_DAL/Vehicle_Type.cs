using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Vehicle_Type table.
	/// </summary>
	public sealed class Vehicle_Type
    {
        #region Fields


        private decimal _PK_Vehicle_Type;
        private string _Fld_Desc;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Vehicle_Type value.
        /// </summary>
        public decimal PK_Vehicle_Type
        {
            get { return _PK_Vehicle_Type; }
            set { _PK_Vehicle_Type = value; }
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

        /// Initializes a new instance of the Vehicle_Type class. with the default value.

        /// </summary>
        public Vehicle_Type()
        {

            this._PK_Vehicle_Type = -1;
            this._Fld_Desc = "";

        }



        /// <summary> 

        /// Initializes a new instance of the Vehicle_Type class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Vehicle_Type(decimal PK)
        {

            DataTable dtVehicle_Type = SelectByPK(PK).Tables[0];

            if (dtVehicle_Type.Rows.Count > 0)
            {

                DataRow drVehicle_Type = dtVehicle_Type.Rows[0];

                this._PK_Vehicle_Type = drVehicle_Type["PK_Vehicle_Type"] != DBNull.Value ? Convert.ToDecimal(drVehicle_Type["PK_Vehicle_Type"]) : 0;
                this._Fld_Desc = Convert.ToString(drVehicle_Type["Fld_Desc"]);

            }

            else
            {

                this._PK_Vehicle_Type = -1;
                this._Fld_Desc = "";

            }

        }



        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the Vehicle_Type table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Vehicle_TypeInsert");

            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Vehicle_Type table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Vehicle_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Vehicle_TypeSelectByPK");

            db.AddInParameter(dbCommand, "PK_Vehicle_Type", DbType.Decimal, pK_Vehicle_Type);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Vehicle_Type table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Vehicle_TypeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Vehicle_Type table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Vehicle_TypeUpdate");

            db.AddInParameter(dbCommand, "PK_Vehicle_Type", DbType.Decimal, this._PK_Vehicle_Type);
            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Vehicle_Type table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Vehicle_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Vehicle_TypeDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Vehicle_Type", DbType.Decimal, pK_Vehicle_Type);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion
	}
}
