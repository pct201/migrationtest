using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Producers table.
	/// </summary>
	public sealed class COI_Producers
    {
        #region Fields

        private decimal _PK_COI_Producers;
        private decimal _FK_COIs;
        private string _Company;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private decimal _FK_State;
        private string _Zip_Code;
        private string _Contact_Last_Name;
        private string _Contact_First_Name;
        private string _Contact_Title;
        private string _Contact_Phone;
        private string _Contact_Fax;
        private string _Contact_EMail;
        private string _Notes;
        private DateTime _Update_Date;
        private string _Updated_By;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_COI_Producers value.
        /// </summary>
        public decimal PK_COI_Producers
        {
            get { return _PK_COI_Producers; }
            set { _PK_COI_Producers = value; }
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
        /// Gets or sets the Company value.
        /// </summary>
        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
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
        /// Gets or sets the Contact_Last_Name value.
        /// </summary>
        public string Contact_Last_Name
        {
            get { return _Contact_Last_Name; }
            set { _Contact_Last_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_First_Name value.
        /// </summary>
        public string Contact_First_Name
        {
            get { return _Contact_First_Name; }
            set { _Contact_First_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_Title value.
        /// </summary>
        public string Contact_Title
        {
            get { return _Contact_Title; }
            set { _Contact_Title = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_Phone value.
        /// </summary>
        public string Contact_Phone
        {
            get { return _Contact_Phone; }
            set { _Contact_Phone = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_Fax value.
        /// </summary>
        public string Contact_Fax
        {
            get { return _Contact_Fax; }
            set { _Contact_Fax = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_EMail value.
        /// </summary>
        public string Contact_EMail
        {
            get { return _Contact_EMail; }
            set { _Contact_EMail = value; }
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

        /// Initializes a new instance of the COI_Producers class. with the default value.

        /// </summary>
        public COI_Producers()
        {

            this._PK_COI_Producers = -1;
            this._FK_COIs = -1;
            this._Company = "";
            this._Address_1 = "";
            this._Address_2 = "";
            this._City = "";
            this._FK_State = -1;
            this._Zip_Code = "";
            this._Contact_Last_Name = "";
            this._Contact_First_Name = "";
            this._Contact_Title = "";
            this._Contact_Phone = "";
            this._Contact_Fax = "";
            this._Contact_EMail = "";
            this._Notes = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; 
            this._Updated_By = "";

        }



        /// <summary> 

        /// Initializes a new instance of the COI_Producers class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Producers(decimal PK)
        {
            DataTable dtCOI_Producers = Select(PK).Tables[0];

            if (dtCOI_Producers.Rows.Count > 0)
            {

                DataRow drCOI_Producers = dtCOI_Producers.Rows[0];

                this._PK_COI_Producers = drCOI_Producers["PK_COI_Producers"] != DBNull.Value ? Convert.ToDecimal(drCOI_Producers["PK_COI_Producers"]) : 0;
                this._FK_COIs = drCOI_Producers["FK_COIs"] != DBNull.Value ? Convert.ToDecimal(drCOI_Producers["FK_COIs"]) : 0;
                this._Company = Convert.ToString(drCOI_Producers["Company"]);
                this._Address_1 = Convert.ToString(drCOI_Producers["Address_1"]);
                this._Address_2 = Convert.ToString(drCOI_Producers["Address_2"]);
                this._City = Convert.ToString(drCOI_Producers["City"]);
                this._FK_State = drCOI_Producers["FK_State"] != DBNull.Value ? Convert.ToDecimal(drCOI_Producers["FK_State"]) : 0;
                this._Zip_Code = Convert.ToString(drCOI_Producers["Zip_Code"]);
                this._Contact_Last_Name = Convert.ToString(drCOI_Producers["Contact_Last_Name"]);
                this._Contact_First_Name = Convert.ToString(drCOI_Producers["Contact_First_Name"]);
                this._Contact_Title = Convert.ToString(drCOI_Producers["Contact_Title"]);
                this._Contact_Phone = Convert.ToString(drCOI_Producers["Contact_Phone"]);
                this._Contact_Fax = Convert.ToString(drCOI_Producers["Contact_Fax"]);
                this._Contact_EMail = Convert.ToString(drCOI_Producers["Contact_EMail"]);
                this._Notes = Convert.ToString(drCOI_Producers["Notes"]);
                this._Update_Date = drCOI_Producers["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Producers["Update_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Updated_By = Convert.ToString(drCOI_Producers["Updated_By"]);

            }

            else
            {

                new COI_Producers();
            }

        }



        #endregion

        #region "Methods"
        /// <summary>
		/// Inserts a record into the COI_Producers table.
		/// <summary>
		/// <param name="fK_COIs"></param>
		/// <param name="company"></param>
		/// <param name="address_1"></param>
		/// <param name="address_2"></param>
		/// <param name="city"></param>
		/// <param name="fK_State"></param>
		/// <param name="zip_Code"></param>
		/// <param name="contact_Last_Name"></param>
		/// <param name="contact_First_Name"></param>
		/// <param name="contact_Title"></param>
		/// <param name="contact_Phone"></param>
		/// <param name="contact_Fax"></param>
		/// <param name="contact_EMail"></param>
		/// <param name="notes"></param>
		/// <param name="update_Date"></param>
		/// <param name="updated_By"></param>
		/// <returns></returns>
		public static int Insert(decimal fK_COIs, string company, string address_1, string address_2, string city, decimal fK_State, string zip_Code, string contact_Last_Name, string contact_First_Name, string contact_Title, string contact_Phone, string contact_Fax, string contact_EMail, string notes, DateTime update_Date, string updated_By)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_ProducersInsert");

			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
			db.AddInParameter(dbCommand, "Company", DbType.String, company);
			db.AddInParameter(dbCommand, "Address_1", DbType.String, address_1);
			db.AddInParameter(dbCommand, "Address_2", DbType.String, address_2);
			db.AddInParameter(dbCommand, "City", DbType.String, city);
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, fK_State);
			db.AddInParameter(dbCommand, "Zip_Code", DbType.String, zip_Code);
			db.AddInParameter(dbCommand, "Contact_Last_Name", DbType.String, contact_Last_Name);
			db.AddInParameter(dbCommand, "Contact_First_Name", DbType.String, contact_First_Name);
			db.AddInParameter(dbCommand, "Contact_Title", DbType.String, contact_Title);
			db.AddInParameter(dbCommand, "Contact_Phone", DbType.String, contact_Phone);
			db.AddInParameter(dbCommand, "Contact_Fax", DbType.String, contact_Fax);
			db.AddInParameter(dbCommand, "Contact_EMail", DbType.String, contact_EMail);
			db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the COI_Producers table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_COI_Producers)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_ProducersSelect");

			db.AddInParameter(dbCommand, "PK_COI_Producers", DbType.Decimal, pK_COI_Producers);

			return db.ExecuteDataSet(dbCommand);
		}

        

		/// <summary>
		/// Selects records from the COI_Producers table by a foreign key.
		/// <summary>
		/// <param name="fK_COIs"></param>
		/// <returns>DataSet</returns>
		public static DataSet SelectByFK_COIs(decimal fK_COIs)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_ProducersSelectByFK_COIs");

			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);

			return db.ExecuteDataSet(dbCommand);
		}

        
		/// <summary>
		/// Updates a record in the COI_Producers table.
		/// <summary>
		/// <param name="pK_COI_Producers"></param>
		/// <param name="fK_COIs"></param>
		/// <param name="company"></param>
		/// <param name="address_1"></param>
		/// <param name="address_2"></param>
		/// <param name="city"></param>
		/// <param name="fK_State"></param>
		/// <param name="zip_Code"></param>
		/// <param name="contact_Last_Name"></param>
		/// <param name="contact_First_Name"></param>
		/// <param name="contact_Title"></param>
		/// <param name="contact_Phone"></param>
		/// <param name="contact_Fax"></param>
		/// <param name="contact_EMail"></param>
		/// <param name="notes"></param>
		/// <param name="update_Date"></param>
		/// <param name="updated_By"></param>
		public static void Update(decimal pK_COI_Producers, decimal fK_COIs, string company, string address_1, string address_2, string city, decimal fK_State, string zip_Code, string contact_Last_Name, string contact_First_Name, string contact_Title, string contact_Phone, string contact_Fax, string contact_EMail, string notes, DateTime update_Date, string updated_By)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_ProducersUpdate");

			db.AddInParameter(dbCommand, "PK_COI_Producers", DbType.Decimal, pK_COI_Producers);
			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
			db.AddInParameter(dbCommand, "Company", DbType.String, company);
			db.AddInParameter(dbCommand, "Address_1", DbType.String, address_1);
			db.AddInParameter(dbCommand, "Address_2", DbType.String, address_2);
			db.AddInParameter(dbCommand, "City", DbType.String, city);
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, fK_State);
			db.AddInParameter(dbCommand, "Zip_Code", DbType.String, zip_Code);
			db.AddInParameter(dbCommand, "Contact_Last_Name", DbType.String, contact_Last_Name);
			db.AddInParameter(dbCommand, "Contact_First_Name", DbType.String, contact_First_Name);
			db.AddInParameter(dbCommand, "Contact_Title", DbType.String, contact_Title);
			db.AddInParameter(dbCommand, "Contact_Phone", DbType.String, contact_Phone);
			db.AddInParameter(dbCommand, "Contact_Fax", DbType.String, contact_Fax);
			db.AddInParameter(dbCommand, "Contact_EMail", DbType.String, contact_EMail);
			db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the COI_Producers table by a composite primary key.
		/// <summary>
		public static void Delete(decimal pK_COI_Producers)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_ProducersDelete");

			db.AddInParameter(dbCommand, "PK_COI_Producers", DbType.Decimal, pK_COI_Producers);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
		/// Deletes a record from the COI_Producers table by a foreign key.
		/// <summary>
		public static void DeleteByFK_COIs(decimal fK_COIs)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_ProducersDeleteByFK_COIs");

			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);

			db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Calls parameterized Insert method to Insert the record
        /// </summary>
        /// <returns>The primary key value for newly Inserted record</returns>
        public int Insert()
        {
           return Insert(_FK_COIs, _Company, _Address_1,_Address_2,_City, _FK_State, _Zip_Code, _Contact_Last_Name, _Contact_First_Name, _Contact_Title, _Contact_Phone, _Contact_Fax, _Contact_EMail, _Notes, _Update_Date, _Updated_By);
        }

        /// <summary>
        /// Calls parameterized Update method to Update the record
        /// </summary>
        public void Update()
        {
            Update(_PK_COI_Producers, _FK_COIs, _Company, _Address_1, _Address_2, _City, _FK_State, _Zip_Code, _Contact_Last_Name, _Contact_First_Name, _Contact_Title, _Contact_Phone, _Contact_Fax, _Contact_EMail, _Notes, _Update_Date, _Updated_By);
        }
        
        /// <summary>
        /// Returns all records that matches the search crieteria
        /// </summary>
        /// <param name="fk_COIs"></param>
        /// <param name="company"></param>
        /// <param name="last_name"></param>
        /// <param name="first_name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipcode"></param>
        /// <returns>DataSet</returns>
        public static DataSet Search(int fk_COIs,string company, string last_name,string first_name,string address,string city,int state,string zipcode)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_ProducerSearch");

            db.AddInParameter(dbCommand, "FK_COIs", DbType.Int32, fk_COIs);
            db.AddInParameter(dbCommand, "Company", DbType.String, company);
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
