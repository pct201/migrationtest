using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Executive_Risk_Contacts table.
	/// </summary>
	public sealed class Executive_Risk_Contacts
	{
        #region Fields

        private string _Address2;
        private string _Addtess1;
        private string _Cell_Phone;
        private string _City;
        private string _Contact_Name;
        private string _Contact_Type;
        private string _Email;
        private decimal _FK_Executive_Risk;
        private decimal _FK_State;
        private decimal _PK_Executive_Risk_Contacts;
        private string _Tel_Number;
        private string _Zip_Code;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        #endregion


        #region Properties
        /// <summary> 
        /// Gets or sets the Address2 value.
        /// </summary>
        public string Address2
        {
            get { return _Address2; }
            set { _Address2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Addtess1 value.
        /// </summary>
        public string Addtess1
        {
            get { return _Addtess1; }
            set { _Addtess1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cell_Phone value.
        /// </summary>
        public string Cell_Phone
        {
            get { return _Cell_Phone; }
            set { _Cell_Phone = value; }
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
        /// Gets or sets the Contact_Name value.
        /// </summary>
        public string Contact_Name
        {
            get { return _Contact_Name; }
            set { _Contact_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_Type value.
        /// </summary>
        public string Contact_Type
        {
            get { return _Contact_Type; }
            set { _Contact_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Email value.
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Executive_Risk value.
        /// </summary>
        public decimal FK_Executive_Risk
        {
            get { return _FK_Executive_Risk; }
            set { _FK_Executive_Risk = value; }
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
        /// Gets or sets the PK_Executive_Risk_Contacts value.
        /// </summary>
        public decimal PK_Executive_Risk_Contacts
        {
            get { return _PK_Executive_Risk_Contacts; }
            set { _PK_Executive_Risk_Contacts = value; }
        }


        /// <summary> 
        /// Gets or sets the Tel_Number value.
        /// </summary>
        public string Tel_Number
        {
            get { return _Tel_Number; }
            set { _Tel_Number = value; }
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

        /// Initializes a new instance of the Executive_Risk_Contacts class. with the default value.

        /// </summary>
        public Executive_Risk_Contacts()
        {

            this._Address2 = "";
            this._Addtess1 = "";
            this._Cell_Phone = "";
            this._City = "";
            this._Contact_Name = "";
            this._Contact_Type = "";
            this._Email = "";
            this._FK_Executive_Risk = -1;
            this._FK_State = -1;
            this._PK_Executive_Risk_Contacts = -1;
            this._Tel_Number = "";
            this._Zip_Code = "";
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 
        /// Initializes a new instance of the Executive_Risk_Contacts class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Executive_Risk_Contacts(decimal PK)
        {

            DataTable dtExecutive_Risk_Contacts = SelectByPK(PK).Tables[0];

            if (dtExecutive_Risk_Contacts.Rows.Count > 0)
            {

                DataRow drExecutive_Risk_Contacts = dtExecutive_Risk_Contacts.Rows[0];

                this._Address2 = Convert.ToString(drExecutive_Risk_Contacts["Address2"]);
                this._Addtess1 = Convert.ToString(drExecutive_Risk_Contacts["Addtess1"]);
                this._Cell_Phone = Convert.ToString(drExecutive_Risk_Contacts["Cell_Phone"]);
                this._City = Convert.ToString(drExecutive_Risk_Contacts["City"]);
                this._Contact_Name = Convert.ToString(drExecutive_Risk_Contacts["Contact_Name"]);
                this._Contact_Type = Convert.ToString(drExecutive_Risk_Contacts["Contact_Type"]);
                this._Email = Convert.ToString(drExecutive_Risk_Contacts["Email"]);
                this._FK_Executive_Risk = drExecutive_Risk_Contacts["FK_Executive_Risk"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk_Contacts["FK_Executive_Risk"]) : 0;
                this._FK_State = drExecutive_Risk_Contacts["FK_State"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk_Contacts["FK_State"]) : 0;
                this._PK_Executive_Risk_Contacts = drExecutive_Risk_Contacts["PK_Executive_Risk_Contacts"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk_Contacts["PK_Executive_Risk_Contacts"]) : 0;
                this._Tel_Number = Convert.ToString(drExecutive_Risk_Contacts["Tel_Number"]);
                this._Zip_Code = Convert.ToString(drExecutive_Risk_Contacts["Zip_Code"]);
                this._Updated_By = drExecutive_Risk_Contacts["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk_Contacts["Updated_By"]) : 0;
                this._Updated_Date = drExecutive_Risk_Contacts["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk_Contacts["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._Address2 = "";
                this._Addtess1 = "";
                this._Cell_Phone = "";
                this._City = "";
                this._Contact_Name = "";
                this._Contact_Type = "";
                this._Email = "";
                this._FK_Executive_Risk = -1;
                this._FK_State = -1;
                this._PK_Executive_Risk_Contacts = -1;
                this._Tel_Number = "";
                this._Zip_Code = "";
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

        }

        #endregion

        #region "Methods"

        /// <summary>
		/// Inserts a record into the Executive_Risk_Contacts table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_ContactsInsert");

			db.AddInParameter(dbCommand, "Address2", DbType.String, this._Address2);
			db.AddInParameter(dbCommand, "Addtess1", DbType.String, this._Addtess1);
			db.AddInParameter(dbCommand, "Cell_Phone", DbType.String, this._Cell_Phone);
			db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
			db.AddInParameter(dbCommand, "Contact_Type", DbType.String, this._Contact_Type);
			db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);
			db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, this._FK_Executive_Risk);
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);
			db.AddInParameter(dbCommand, "Tel_Number", DbType.String, this._Tel_Number);
			db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Executive_Risk_Contacts table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_Executive_Risk_Contacts)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_ContactsSelectByPK");

			db.AddInParameter(dbCommand, "PK_Executive_Risk_Contacts", DbType.Decimal, pK_Executive_Risk_Contacts);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Executive_Risk_Contacts table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_ContactsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Executive_Risk_Contacts table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_ContactsUpdate");

			db.AddInParameter(dbCommand, "Address2", DbType.String, this._Address2);
			db.AddInParameter(dbCommand, "Addtess1", DbType.String, this._Addtess1);
			db.AddInParameter(dbCommand, "Cell_Phone", DbType.String, this._Cell_Phone);
			db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
			db.AddInParameter(dbCommand, "Contact_Type", DbType.String, this._Contact_Type);
			db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);
			db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, this._FK_Executive_Risk);
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);
			db.AddInParameter(dbCommand, "PK_Executive_Risk_Contacts", DbType.Decimal, this._PK_Executive_Risk_Contacts);
			db.AddInParameter(dbCommand, "Tel_Number", DbType.String, this._Tel_Number);
			db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Executive_Risk_Contacts table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Executive_Risk_Contacts)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_ContactsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Executive_Risk_Contacts", DbType.Decimal, pK_Executive_Risk_Contacts);

			db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByFK(decimal fK_Executive_Risk)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_ContactsSelectByFK");

            db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, fK_Executive_Risk);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
