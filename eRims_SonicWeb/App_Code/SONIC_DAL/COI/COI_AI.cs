using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for COI_AI table.
    /// </summary>
    public sealed class COI_AI
    {

        #region Fields


        private decimal _PK_COI_AI;
        private decimal _FK_Table_Name;
        private string _Table_Name;
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
        private decimal _FK_COI_Interest;
        private string _Notes;
        private DateTime _Update_Date;
        private string _Updated_By;
        private string _Shown_On_COI;

        #endregion

        #region Properties


        /// <summary> 
        /// Gets or sets the PK_COI_AI value.
        /// </summary>
        public decimal PK_COI_AI
        {
            get { return _PK_COI_AI; }
            set { _PK_COI_AI = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Table_Name value.
        /// </summary>
        public decimal FK_Table_Name
        {
            get { return _FK_Table_Name; }
            set { _FK_Table_Name = value; }
        }

        /// <summary> 
        /// Gets or sets the Last_Name value.
        /// </summary>
        public string Table_Name
        {
            get { return _Table_Name; }
            set { _Table_Name = value; }
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
        /// Gets or sets the FK_COI_Interest value.
        /// </summary>
        public decimal FK_COI_Interest
        {
            get { return _FK_COI_Interest; }
            set { _FK_COI_Interest = value; }
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

        public string Shown_On_COI
        {
            get { return _Shown_On_COI; }
            set { _Shown_On_COI = value; }
        }

        #endregion

        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the COI_AI class. with the default value.

        /// </summary>
        public COI_AI()
        {

            this._PK_COI_AI = -1;
            this._FK_Table_Name = -1;
            this._Table_Name = "";
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
            this._FK_COI_Interest = -1;
            this._Notes = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; 
            this._Updated_By = "";
            this._Shown_On_COI = "";
        }



        /// <summary> 

        /// Initializes a new instance of the COI_AI class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_AI(decimal PK)
        {
            DataTable dtCOI_AI = Select(PK).Tables[0];

            if (dtCOI_AI.Rows.Count > 0)
            {

                DataRow drCOI_AI = dtCOI_AI.Rows[0];

                this._PK_COI_AI = drCOI_AI["PK_COI_AI"] != DBNull.Value ? Convert.ToDecimal(drCOI_AI["PK_COI_AI"]) : 0;
                this._FK_Table_Name = drCOI_AI["FK_Table_Name"] != DBNull.Value ? Convert.ToDecimal(drCOI_AI["FK_Table_Name"]) : 0;
                this._Table_Name = Convert.ToString(drCOI_AI["Table_Name"]);
                this._Last_Name = Convert.ToString(drCOI_AI["Last_Name"]);
                this._First_Name = Convert.ToString(drCOI_AI["First_Name"]);
                this._Address_1 = Convert.ToString(drCOI_AI["Address_1"]);
                this._Address_2 = Convert.ToString(drCOI_AI["Address_2"]);
                this._City = Convert.ToString(drCOI_AI["City"]);
                this._FK_State = drCOI_AI["FK_State"] != DBNull.Value ? Convert.ToDecimal(drCOI_AI["FK_State"]) : 0;
                this._Zip_Code = Convert.ToString(drCOI_AI["Zip_Code"]);
                this._Phone = Convert.ToString(drCOI_AI["Phone"]);
                this._Fax = Convert.ToString(drCOI_AI["Fax"]);
                this._EMail = Convert.ToString(drCOI_AI["EMail"]);
                this._FK_COI_Interest = drCOI_AI["FK_COI_Interest"] != DBNull.Value ? Convert.ToDecimal(drCOI_AI["FK_COI_Interest"]) : 0;
                this._Notes = Convert.ToString(drCOI_AI["Notes"]);
                this._Update_Date = drCOI_AI["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_AI["Update_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Updated_By = Convert.ToString(drCOI_AI["Updated_By"]);
                this._Shown_On_COI = drCOI_AI["Shown_On_COI"] != DBNull.Value ? Convert.ToString(drCOI_AI["Shown_On_COI"]) : string.Empty;
            }

            else
            {

                new COI_AI();
            }

        }



        #endregion

        #region "Methods"

        /// <summary>
        /// Inserts a record into the COI_AI table.
        /// <summary>
        /// <param name="fK_Table_Name"></param>
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
        /// <param name="fK_COI_Interest"></param>
        /// <param name="notes"></param>
        /// <param name="update_Date"></param>
        /// <param name="updated_By"></param>
        /// <returns></returns>
        public static int Insert(decimal fK_Table_Name, string tableName, string last_Name, string first_Name, string address_1, string address_2, string city, decimal fK_State, string zip_Code, string phone, string fax, string eMail, decimal fK_COI_Interest, string notes, DateTime update_Date, string updated_By, string shown_On_COI)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_AIInsert");

            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, tableName);
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
            db.AddInParameter(dbCommand, "FK_COI_Interest", DbType.Decimal, fK_COI_Interest);
            db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Shown_On_COI", DbType.String, shown_On_COI); 
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the COI_AI table.
        /// <summary>
        /// <returns>DataSet</returns>
        public static DataSet Select(decimal pK_COI_AI)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_AISelect");

            db.AddInParameter(dbCommand, "PK_COI_AI", DbType.Decimal, pK_COI_AI);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the COI_AI table by a foreign key.
        /// <summary>
        /// <param name="fK_Table_Name"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_COI_Locations(decimal fK_Table_Name, string tableName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_AISelectByFK_COI_Locations");

            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, tableName);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the COI_AI table by a foreign key.
        /// <summary>
        /// <param name="fK_State"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_State(decimal fK_State)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_AISelectByFK_State");

            db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, fK_State);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the COI_AI table.
        /// <summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_AISelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the COI_AI table.
        /// <summary>
        /// <param name="pK_COI_AI"></param>
        /// <param name="fK_Table_Name"></param>
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
        /// <param name="fK_COI_Interest"></param>
        /// <param name="notes"></param>
        /// <param name="update_Date"></param>
        /// <param name="updated_By"></param>
        public static void Update(decimal pK_COI_AI, decimal fK_Table_Name, string tableName, string last_Name, string first_Name, string address_1, string address_2, string city, decimal fK_State, string zip_Code, string phone, string fax, string eMail, decimal fK_COI_Interest, string notes, DateTime update_Date, string updated_By, string shown_On_COI)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_AIUpdate");

            db.AddInParameter(dbCommand, "PK_COI_AI", DbType.Decimal, pK_COI_AI);
            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, tableName);
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
            db.AddInParameter(dbCommand, "FK_COI_Interest", DbType.Decimal, fK_COI_Interest);
            db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Shown_On_COI", DbType.String, shown_On_COI); 
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the COI_AI table by a composite primary key.
        /// <summary>
        public static void Delete(decimal pK_COI_AI)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_AIDelete");

            db.AddInParameter(dbCommand, "PK_COI_AI", DbType.Decimal, pK_COI_AI);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Calls parameterized Insert method to Insert the record
        /// </summary>
        /// <returns>The primary key value for newly Inserted record</returns>
        public int Insert()
        {
            return Insert(_FK_Table_Name,_Table_Name, _Last_Name, _First_Name, _Address_1, _Address_2, _City, _FK_State,
                _Zip_Code, _Phone, _Fax, _EMail, _FK_COI_Interest, _Notes, _Update_Date, _Updated_By,_Shown_On_COI);
        }

        /// <summary>
        /// Calls parameterized Update method to Update the record
        /// </summary>
        public void Update()
        {
            Update(_PK_COI_AI, _FK_Table_Name, _Table_Name, _Last_Name, _First_Name, _Address_1, _Address_2, _City, _FK_State,
                _Zip_Code, _Phone, _Fax, _EMail, _FK_COI_Interest, _Notes, _Update_Date, _Updated_By, _Shown_On_COI);
        }
        
        /// <summary>
        /// Returns all records that matches the search crieteria
        /// </summary>
        /// <param name="fk_COI_Locations"></param>
        /// <param name="last_name"></param>
        /// <param name="first_name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipcode"></param>
        /// <returns>DataSet</returns>
        public static DataSet Search(int fk_COI_Locations, string last_name, string first_name, string address, string city, int state, string zipcode)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_AISearch");

            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Int32, fk_COI_Locations);            
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
