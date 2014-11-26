using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for DPD_FR_Injured_Passenger table.
	/// </summary>
	public sealed class DPD_FR_Injured_Passenger
    {
        #region Fields


        private decimal _PK_DPD_FR_Injured_Passenger_id;
        private decimal _FK_DPD_FR_ID;
        private decimal _FK_DPD_FR_Vehicle_ID;
        private string _name;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private string _State;
        private string _Zip_Code;
        private string _phone;
        private Nullable<bool> _injured;
        private decimal _Updated_By;
        private DateTime _Update_Date;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_DPD_FR_Injured_Passenger_id value.
        /// </summary>
        public decimal PK_DPD_FR_Injured_Passenger_id
        {
            get { return _PK_DPD_FR_Injured_Passenger_id; }
            set { _PK_DPD_FR_Injured_Passenger_id = value; }
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
        /// Gets or sets the FK_DPD_FR_Vehicle_ID value.
        /// </summary>
        public decimal FK_DPD_FR_Vehicle_ID
        {
            get { return _FK_DPD_FR_Vehicle_ID; }
            set { _FK_DPD_FR_Vehicle_ID = value; }
        }

        /// <summary> 
        /// Gets or sets the name value.
        /// </summary>
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }


        /// <summary> 
        /// Gets or sets the Address_1 value.
        /// </summary>
        public string Address_1
        {
            get { return _Address_1; }
            set { _Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Address_2 value.
        /// </summary>
        public string Address_2
        {
            get { return _Address_2; }
            set { _Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the City value.
        /// </summary>
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }


        /// <summary> 
        /// Gets or sets the State value.
        /// </summary>
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }


        /// <summary> 
        /// Gets or sets the Zip_Code value.
        /// </summary>
        public string Zip_Code
        {
            get { return _Zip_Code; }
            set { _Zip_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the phone value.
        /// </summary>
        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }


        /// <summary> 
        /// Gets or sets the injured value.
        /// </summary>
        public Nullable<bool> injured
        {
            get { return _injured; }
            set { _injured = value; }
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
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the DPD_FR_Injured_Passenger class. with the default value.
        /// </summary>
        public DPD_FR_Injured_Passenger()
        {

            this._PK_DPD_FR_Injured_Passenger_id = -1;
            this._FK_DPD_FR_ID = -1;
            this._FK_DPD_FR_Vehicle_ID = -1;
            this._name = "";
            this._Address_1 = "";
            this._Address_2 = "";
            this._City = "";
            this._State = "";
            this._Zip_Code = "";
            this._phone = "";
            this._injured = false;
            this._Updated_By = -1;
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 
        /// Initializes a new instance of the DPD_FR_Injured_Passenger class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public DPD_FR_Injured_Passenger(decimal PK)
        {

            DataTable dtDPD_FR_Injured_Passenger = SelectByPK(PK).Tables[0];

            if (dtDPD_FR_Injured_Passenger.Rows.Count > 0)
            {

                DataRow drDPD_FR_Injured_Passenger = dtDPD_FR_Injured_Passenger.Rows[0];

                this._PK_DPD_FR_Injured_Passenger_id = drDPD_FR_Injured_Passenger["PK_DPD_FR_Injured_Passenger_id"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR_Injured_Passenger["PK_DPD_FR_Injured_Passenger_id"]) : 0;
                this._FK_DPD_FR_ID = drDPD_FR_Injured_Passenger["FK_DPD_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR_Injured_Passenger["FK_DPD_FR_ID"]) : 0;
                this._FK_DPD_FR_Vehicle_ID = drDPD_FR_Injured_Passenger["FK_DPD_FR_Vehicle_ID"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR_Injured_Passenger["FK_DPD_FR_Vehicle_ID"]) : 0;
                this._name = Convert.ToString(drDPD_FR_Injured_Passenger["name"]);
                this._Address_1 = Convert.ToString(drDPD_FR_Injured_Passenger["Address_1"]);
                this._Address_2 = Convert.ToString(drDPD_FR_Injured_Passenger["Address_2"]);
                this._City = Convert.ToString(drDPD_FR_Injured_Passenger["City"]);
                this._State = Convert.ToString(drDPD_FR_Injured_Passenger["State"]);
                this._Zip_Code = Convert.ToString(drDPD_FR_Injured_Passenger["Zip_Code"]);
                this._phone = Convert.ToString(drDPD_FR_Injured_Passenger["phone"]);
                if(drDPD_FR_Injured_Passenger["injured"] != DBNull.Value)
                    this._injured = Convert.ToBoolean(drDPD_FR_Injured_Passenger["injured"]);
                this._Updated_By = drDPD_FR_Injured_Passenger["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drDPD_FR_Injured_Passenger["Updated_By"]) : 0;
                this._Update_Date = drDPD_FR_Injured_Passenger["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drDPD_FR_Injured_Passenger["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._PK_DPD_FR_Injured_Passenger_id = -1;
                this._FK_DPD_FR_ID = -1;
                this._FK_DPD_FR_Vehicle_ID = -1;
                this._name = "";
                this._Address_1 = "";
                this._Address_2 = "";
                this._City = "";
                this._State = "";
                this._Zip_Code = "";
                this._phone = "";
                this._injured = false;
                this._Updated_By = -1;
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }



        #endregion


        #region Methods
        /// <summary>
		/// Inserts a record into the DPD_FR_Injured_Passenger table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_Injured_PassengerInsert");

			db.AddInParameter(dbCommand, "FK_DPD_FR_ID", DbType.Decimal, this._FK_DPD_FR_ID);
            db.AddInParameter(dbCommand, "FK_DPD_FR_Vehicle_ID", DbType.Decimal, this._FK_DPD_FR_Vehicle_ID);
			db.AddInParameter(dbCommand, "name", DbType.String, this._name);
			db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			db.AddInParameter(dbCommand, "State", DbType.String, this._State);
			db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
			db.AddInParameter(dbCommand, "phone", DbType.String, this._phone);
            if(this._injured != true && this._injured != false)
                db.AddInParameter(dbCommand, "injured", DbType.Boolean, DBNull.Value);
            else
			    db.AddInParameter(dbCommand, "injured", DbType.Boolean, this._injured);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, DateTime.Now);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the DPD_FR_Injured_Passenger table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_DPD_FR_Injured_Passenger_id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_Injured_PassengerSelectByPK");

			db.AddInParameter(dbCommand, "PK_DPD_FR_Injured_Passenger_id", DbType.Decimal, pK_DPD_FR_Injured_Passenger_id);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the DPD_FR_Injured_Passenger table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_Injured_PassengerSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the DPD_FR_Injured_Passenger table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_Injured_PassengerUpdate");

			db.AddInParameter(dbCommand, "PK_DPD_FR_Injured_Passenger_id", DbType.Decimal, this._PK_DPD_FR_Injured_Passenger_id);
			db.AddInParameter(dbCommand, "FK_DPD_FR_ID", DbType.Decimal, this._FK_DPD_FR_ID);
            db.AddInParameter(dbCommand, "FK_DPD_FR_Vehicle_ID", DbType.Decimal, this._FK_DPD_FR_Vehicle_ID);
			db.AddInParameter(dbCommand, "name", DbType.String, this._name);
			db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			db.AddInParameter(dbCommand, "State", DbType.String, this._State);
			db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
			db.AddInParameter(dbCommand, "phone", DbType.String, this._phone);
            if (this._injured != true && this._injured != false)
                db.AddInParameter(dbCommand, "injured", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "injured", DbType.Boolean, this._injured);
			db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, DateTime.Now);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the DPD_FR_Injured_Passenger table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_DPD_FR_Injured_Passenger_id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_Injured_PassengerDeleteByPK");

			db.AddInParameter(dbCommand, "PK_DPD_FR_Injured_Passenger_id", DbType.Decimal, pK_DPD_FR_Injured_Passenger_id);

			db.ExecuteNonQuery(dbCommand);
        }


        /// <summary>
        /// Selects a single record from the DPD_FR_Injured_Passenger table by a Vehicle ID key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByVehicleID(decimal FK_DPD_FR_Vehicle_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_Injured_PassengerSelectByVehicleID");

            db.AddInParameter(dbCommand, "FK_DPD_FR_Vehicle_ID", DbType.Decimal, FK_DPD_FR_Vehicle_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Delete All record from the DPD_FR_Injured_Passenger table by a Vehicle ID key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static void DeleteByVehicleID(decimal FK_DPD_FR_Vehicle_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_Injured_PassengerDeleteByVehicleID");

            db.AddInParameter(dbCommand, "FK_DPD_FR_Vehicle_ID", DbType.Decimal, FK_DPD_FR_Vehicle_ID);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
