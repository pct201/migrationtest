using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Owners table.
	/// </summary>
	public sealed class COI_Owners
    {
        #region Fields

        private decimal _PK_COI_Owners;
        private decimal _FK_COIs;
        private string _Last_Name;
        private string _First_Name;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private decimal _FK_State;
        private string _Zip_Code;
        private string _Phone;
        private string _Fax;
        private string _EMail;
        private string _Notes;
        private DateTime _Update_Date;
        private string _Updated_By;

        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_COI_Owners value.
        /// </summary>
        public decimal PK_COI_Owners
        {
            get { return _PK_COI_Owners; }
            set { _PK_COI_Owners = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COIs value.
        /// </summary>
        public decimal FK_COIs
        {
            get { return _FK_COIs; }
            set { _FK_COIs = value; }
        }


        /// <summary> 
        /// Gets or sets the Last_Name value.
        /// </summary>
        public string Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the First_Name value.
        /// </summary>
        public string First_Name
        {
            get { return _First_Name; }
            set { _First_Name = value; }
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
        /// Gets or sets the FK_State value.
        /// </summary>
        public decimal FK_State
        {
            get { return _FK_State; }
            set { _FK_State = value; }
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
        /// Gets or sets the Phone value.
        /// </summary>
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Fax value.
        /// </summary>
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }


        /// <summary> 
        /// Gets or sets the EMail value.
        /// </summary>
        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
        }


        /// <summary> 
        /// Gets or sets the Notes value.
        /// </summary>
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
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

        /// Initializes a new instance of the COI_Owners class. with the default value.

        /// </summary>
        public COI_Owners()
        {
            this._PK_COI_Owners = -1;
            this._FK_COIs = -1;
            this._Last_Name = "";
            this._First_Name = "";
            this._Address_1 = "";
            this._Address_2 = "";
            this._City = "";
            this._FK_State = -1;
            this._Zip_Code = "";
            this._Phone = "";
            this._Fax = "";
            this._EMail = "";
            this._Notes = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; 
            this._Updated_By = "";

        }



        /// <summary> 

        /// Initializes a new instance of the COI_Owners class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Owners(decimal PK)
        {
            DataTable dtCOI_Owners = Select(PK).Tables[0];

            if (dtCOI_Owners.Rows.Count > 0)
            {

                DataRow drCOI_Owners = dtCOI_Owners.Rows[0];
                this._PK_COI_Owners = drCOI_Owners["PK_COI_Owners"] != DBNull.Value ? Convert.ToDecimal(drCOI_Owners["PK_COI_Owners"]) : 0;
                this._FK_COIs = drCOI_Owners["FK_COIs"] != DBNull.Value ? Convert.ToDecimal(drCOI_Owners["FK_COIs"]) : 0;
                this._Last_Name = Convert.ToString(drCOI_Owners["Last_Name"]);
                this._First_Name = Convert.ToString(drCOI_Owners["First_Name"]);
                this._Address_1 = Convert.ToString(drCOI_Owners["Address_1"]);
                this._Address_2 = Convert.ToString(drCOI_Owners["Address_2"]);
                this._City = Convert.ToString(drCOI_Owners["City"]);
                this._FK_State = drCOI_Owners["FK_State"] != DBNull.Value ? Convert.ToDecimal(drCOI_Owners["FK_State"]) : 0;
                this._Zip_Code = Convert.ToString(drCOI_Owners["Zip_Code"]);
                this._Phone = Convert.ToString(drCOI_Owners["Phone"]);
                this._Fax = Convert.ToString(drCOI_Owners["Fax"]);
                this._EMail = Convert.ToString(drCOI_Owners["EMail"]);
                this._Notes = Convert.ToString(drCOI_Owners["Notes"]);
                this._Update_Date = drCOI_Owners["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Owners["Update_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Updated_By = Convert.ToString(drCOI_Owners["Updated_By"]);

            }

            else
            {

                new COI_Owners();
            }

        }



        #endregion

        #region "Methods"
        /// <summary>
		/// Inserts a record into the COI_Owners table.
		/// <summary>
		/// <param name="fK_COIs"></param>
		/// <param name="last_Name"></param>
		/// <param name="first_Name"></param>
		/// <param name="address_1"></param>
		/// <param name="address_2"></param>
		/// <param name="city"></param>
		/// <param name="fK_State"></param>
		/// <param name="zip_Code"></param>
		/// <param name="phone"></param>
		/// <param name="fax"></param>
		/// <param name="eMail"></param>
		/// <param name="notes"></param>
		/// <param name="update_Date"></param>
		/// <param name="updated_By"></param>
		/// <returns></returns>
		public static int Insert(decimal fK_COIs, string last_Name, string first_Name, string address_1, string address_2, string city, decimal fK_State, string zip_Code, string phone, string fax, string eMail, string notes, DateTime update_Date, string updated_By)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_OwnersInsert");

			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
			db.AddInParameter(dbCommand, "Last_Name", DbType.String, last_Name);
			db.AddInParameter(dbCommand, "First_Name", DbType.String, first_Name);
			db.AddInParameter(dbCommand, "Address_1", DbType.String, address_1);
			db.AddInParameter(dbCommand, "Address_2", DbType.String, address_2);
			db.AddInParameter(dbCommand, "City", DbType.String, city);
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, fK_State);
			db.AddInParameter(dbCommand, "Zip_Code", DbType.String, zip_Code);
			db.AddInParameter(dbCommand, "Phone", DbType.String, phone);
			db.AddInParameter(dbCommand, "Fax", DbType.String, fax);
			db.AddInParameter(dbCommand, "EMail", DbType.String, eMail);
			db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the COI_Owners table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_COI_Owners)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_OwnersSelect");

			db.AddInParameter(dbCommand, "PK_COI_Owners", DbType.Decimal, pK_COI_Owners);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects records from the COI_Owners table by a foreign key.
		/// <summary>
		/// <param name="fK_COIs"></param>
		/// <returns>DataSet</returns>
		public static DataSet SelectByFK_COIs(decimal fK_COIs)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_OwnersSelectByFK_COIs");

			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);

			return db.ExecuteDataSet(dbCommand);
		}

        
		/// <summary>
		/// Selects all records from the COI_Owners table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_OwnersSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the COI_Owners table.
		/// <summary>
		/// <param name="pK_COI_Owners"></param>
		/// <param name="fK_COIs"></param>
		/// <param name="last_Name"></param>
		/// <param name="first_Name"></param>
		/// <param name="address_1"></param>
		/// <param name="address_2"></param>
		/// <param name="city"></param>
		/// <param name="fK_State"></param>
		/// <param name="zip_Code"></param>
		/// <param name="phone"></param>
		/// <param name="fax"></param>
		/// <param name="eMail"></param>
		/// <param name="notes"></param>
		/// <param name="update_Date"></param>
		/// <param name="updated_By"></param>
		public static void Update(decimal pK_COI_Owners, decimal fK_COIs, string last_Name, string first_Name, string address_1, string address_2, string city, decimal fK_State, string zip_Code, string phone, string fax, string eMail, string notes, DateTime update_Date, string updated_By)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_OwnersUpdate");

			db.AddInParameter(dbCommand, "PK_COI_Owners", DbType.Decimal, pK_COI_Owners);
			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
			db.AddInParameter(dbCommand, "Last_Name", DbType.String, last_Name);
			db.AddInParameter(dbCommand, "First_Name", DbType.String, first_Name);
			db.AddInParameter(dbCommand, "Address_1", DbType.String, address_1);
			db.AddInParameter(dbCommand, "Address_2", DbType.String, address_2);
			db.AddInParameter(dbCommand, "City", DbType.String, city);
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, fK_State);
			db.AddInParameter(dbCommand, "Zip_Code", DbType.String, zip_Code);
			db.AddInParameter(dbCommand, "Phone", DbType.String, phone);
			db.AddInParameter(dbCommand, "Fax", DbType.String, fax);
			db.AddInParameter(dbCommand, "EMail", DbType.String, eMail);
			db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the COI_Owners table by a composite primary key.
		/// <summary>
		public static void Delete(decimal pK_COI_Owners)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_OwnersDelete");

			db.AddInParameter(dbCommand, "PK_COI_Owners", DbType.Decimal, pK_COI_Owners);

			db.ExecuteNonQuery(dbCommand);
		}

        

        /// <summary>
        /// Calls parameterized Insert method to Insert the record
        /// </summary>
        /// <returns>The primary key value for newly Inserted record</returns>
        public int Insert()
        {
            return Insert(_FK_COIs, _Last_Name, _First_Name, _Address_1, _Address_2, _City, _FK_State, _Zip_Code, _Phone, _Fax, _EMail, _Notes, _Update_Date, _Updated_By);
        }

        /// <summary>
        /// Calls parameterized Update method to Update the record
        /// </summary>
        public void Update()
        {
            Update(_PK_COI_Owners, _FK_COIs, _Last_Name, _First_Name, _Address_1, _Address_2, _City, _FK_State, _Zip_Code, _Phone, _Fax, _EMail, _Notes, _Update_Date, _Updated_By);
        }
        
        /// <summary>
        /// Returns all records that matches the search crieteria
        /// </summary>
        /// <param name="fk_COIs"></param>
        /// <param name="last_name"></param>
        /// <param name="first_name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipcode"></param>
        /// <returns>DataSet</returns>
        public static DataSet Search(int fk_COIs, string last_name, string first_name, string address, string city, int state, string zipcode)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_OwnersSearch");

            db.AddInParameter(dbCommand, "FK_COIs", DbType.Int32, fk_COIs);            
            db.AddInParameter(dbCommand, "LastName", DbType.String, last_name);
            db.AddInParameter(dbCommand, "FirstName", DbType.String, first_name);
            db.AddInParameter(dbCommand, "Address", DbType.String, address);
            db.AddInParameter(dbCommand, "City", DbType.String, city);
            db.AddInParameter(dbCommand, "State", DbType.Int32, state);
            db.AddInParameter(dbCommand, "ZipCode", DbType.String, zipcode);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
