using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Purchasing_Contacts table.
    /// </summary>
    public sealed class Purchasing_Contacts
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Purchasing_Contacts;
        private decimal? _FK_Contact_Type;
        private string _Contact_Name;
        private string _Title;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private decimal? _FK_State;
        private string _ZIP_Code;
        private string _Work_Telephone;
        private string _Cell_Telephone;
        private string _Facsimile;
        private string _Email;
        private string _Notes;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Purchasing_Contacts value.
        /// </summary>
        public decimal? PK_Purchasing_Contacts
        {
            get { return _PK_Purchasing_Contacts; }
            set { _PK_Purchasing_Contacts = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Contact_Type value.
        /// </summary>
        public decimal? FK_Contact_Type
        {
            get { return _FK_Contact_Type; }
            set { _FK_Contact_Type = value; }
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
        /// Gets or sets the Title value.
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
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
        public decimal? FK_State
        {
            get { return _FK_State; }
            set { _FK_State = value; }
        }

        /// <summary>
        /// Gets or sets the ZIP_Code value.
        /// </summary>
        public string ZIP_Code
        {
            get { return _ZIP_Code; }
            set { _ZIP_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Work_Telephone value.
        /// </summary>
        public string Work_Telephone
        {
            get { return _Work_Telephone; }
            set { _Work_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Cell_Telephone value.
        /// </summary>
        public string Cell_Telephone
        {
            get { return _Cell_Telephone; }
            set { _Cell_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Facsimile value.
        /// </summary>
        public string Facsimile
        {
            get { return _Facsimile; }
            set { _Facsimile = value; }
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
        /// Gets or sets the Notes value.
        /// </summary>
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        /// <summary>
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        /// <summary>
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime? Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Purchasing_Contacts class with default value.
        /// </summary>
        public Purchasing_Contacts()
        {

            this._PK_Purchasing_Contacts = null;
            this._FK_Contact_Type = null;
            this._Contact_Name = null;
            this._Title = null;
            this._Address_1 = null;
            this._Address_2 = null;
            this._City = null;
            this._FK_State = null;
            this._ZIP_Code = null;
            this._Work_Telephone = null;
            this._Cell_Telephone = null;
            this._Facsimile = null;
            this._Email = null;
            this._Notes = null;
            this._Updated_By = null;
            this._Update_Date = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Purchasing_Contacts class based on Primary Key.
        /// </summary>
        public Purchasing_Contacts(decimal pK_Purchasing_Contacts)
        {
            DataTable dtPurchasing_Contacts = SelectByPK(pK_Purchasing_Contacts).Tables[0];

            if (dtPurchasing_Contacts.Rows.Count == 1)
            {
                DataRow drPurchasing_Contacts = dtPurchasing_Contacts.Rows[0];
                if (drPurchasing_Contacts["PK_Purchasing_Contacts"] == DBNull.Value)
                    this._PK_Purchasing_Contacts = null;
                else
                    this._PK_Purchasing_Contacts = (decimal?)drPurchasing_Contacts["PK_Purchasing_Contacts"];

                if (drPurchasing_Contacts["FK_Contact_Type"] == DBNull.Value)
                    this._FK_Contact_Type = null;
                else
                    this._FK_Contact_Type = (decimal?)drPurchasing_Contacts["FK_Contact_Type"];

                if (drPurchasing_Contacts["Contact_Name"] == DBNull.Value)
                    this._Contact_Name = null;
                else
                    this._Contact_Name = (string)drPurchasing_Contacts["Contact_Name"];

                if (drPurchasing_Contacts["Title"] == DBNull.Value)
                    this._Title = null;
                else
                    this._Title = (string)drPurchasing_Contacts["Title"];

                if (drPurchasing_Contacts["Address_1"] == DBNull.Value)
                    this._Address_1 = null;
                else
                    this._Address_1 = (string)drPurchasing_Contacts["Address_1"];

                if (drPurchasing_Contacts["Address_2"] == DBNull.Value)
                    this._Address_2 = null;
                else
                    this._Address_2 = (string)drPurchasing_Contacts["Address_2"];

                if (drPurchasing_Contacts["City"] == DBNull.Value)
                    this._City = null;
                else
                    this._City = (string)drPurchasing_Contacts["City"];

                if (drPurchasing_Contacts["FK_State"] == DBNull.Value)
                    this._FK_State = null;
                else
                    this._FK_State = (decimal?)drPurchasing_Contacts["FK_State"];

                if (drPurchasing_Contacts["ZIP_Code"] == DBNull.Value)
                    this._ZIP_Code = null;
                else
                    this._ZIP_Code = (string)drPurchasing_Contacts["ZIP_Code"];

                if (drPurchasing_Contacts["Work_Telephone"] == DBNull.Value)
                    this._Work_Telephone = null;
                else
                    this._Work_Telephone = (string)drPurchasing_Contacts["Work_Telephone"];

                if (drPurchasing_Contacts["Cell_Telephone"] == DBNull.Value)
                    this._Cell_Telephone = null;
                else
                    this._Cell_Telephone = (string)drPurchasing_Contacts["Cell_Telephone"];

                if (drPurchasing_Contacts["Facsimile"] == DBNull.Value)
                    this._Facsimile = null;
                else
                    this._Facsimile = (string)drPurchasing_Contacts["Facsimile"];

                if (drPurchasing_Contacts["Email"] == DBNull.Value)
                    this._Email = null;
                else
                    this._Email = (string)drPurchasing_Contacts["Email"];

                if (drPurchasing_Contacts["Notes"] == DBNull.Value)
                    this._Notes = null;
                else
                    this._Notes = (string)drPurchasing_Contacts["Notes"];

                if (drPurchasing_Contacts["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drPurchasing_Contacts["Updated_By"];

                if (drPurchasing_Contacts["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drPurchasing_Contacts["Update_Date"];

            }
            else
            {
                this._PK_Purchasing_Contacts = null;
                this._FK_Contact_Type = null;
                this._Contact_Name = null;
                this._Title = null;
                this._Address_1 = null;
                this._Address_2 = null;
                this._City = null;
                this._FK_State = null;
                this._ZIP_Code = null;
                this._Work_Telephone = null;
                this._Cell_Telephone = null;
                this._Facsimile = null;
                this._Email = null;
                this._Notes = null;
                this._Updated_By = null;
                this._Update_Date = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Purchasing_Contacts table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_ContactsInsert");


            db.AddInParameter(dbCommand, "FK_Contact_Type", DbType.Decimal, this._FK_Contact_Type);

            if (string.IsNullOrEmpty(this._Contact_Name))
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);

            if (string.IsNullOrEmpty(this._Title))
                db.AddInParameter(dbCommand, "Title", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Title", DbType.String, this._Title);

            if (string.IsNullOrEmpty(this._Address_1))
                db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);

            if (string.IsNullOrEmpty(this._Address_2))
                db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);

            if (string.IsNullOrEmpty(this._City))
                db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "City", DbType.String, this._City);

            db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);

            if (string.IsNullOrEmpty(this._ZIP_Code))
                db.AddInParameter(dbCommand, "ZIP_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZIP_Code", DbType.String, this._ZIP_Code);

            if (string.IsNullOrEmpty(this._Work_Telephone))
                db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, this._Work_Telephone);

            if (string.IsNullOrEmpty(this._Cell_Telephone))
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, this._Cell_Telephone);

            if (string.IsNullOrEmpty(this._Facsimile))
                db.AddInParameter(dbCommand, "Facsimile", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Facsimile", DbType.String, this._Facsimile);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            if (string.IsNullOrEmpty(this._Notes))
                db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Purchasing_Contacts table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_Purchasing_Contacts)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_ContactsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_Contacts", DbType.Decimal, pK_Purchasing_Contacts);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Purchasing_Contacts table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_ContactsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Purchasing_Contacts table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_ContactsUpdate");


            db.AddInParameter(dbCommand, "PK_Purchasing_Contacts", DbType.Decimal, this._PK_Purchasing_Contacts);

            db.AddInParameter(dbCommand, "FK_Contact_Type", DbType.Decimal, this._FK_Contact_Type);

            if (string.IsNullOrEmpty(this._Contact_Name))
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);

            if (string.IsNullOrEmpty(this._Title))
                db.AddInParameter(dbCommand, "Title", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Title", DbType.String, this._Title);

            if (string.IsNullOrEmpty(this._Address_1))
                db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);

            if (string.IsNullOrEmpty(this._Address_2))
                db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);

            if (string.IsNullOrEmpty(this._City))
                db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "City", DbType.String, this._City);

            db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);

            if (string.IsNullOrEmpty(this._ZIP_Code))
                db.AddInParameter(dbCommand, "ZIP_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZIP_Code", DbType.String, this._ZIP_Code);

            if (string.IsNullOrEmpty(this._Work_Telephone))
                db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Work_Telephone", DbType.String, this._Work_Telephone);

            if (string.IsNullOrEmpty(this._Cell_Telephone))
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, this._Cell_Telephone);

            if (string.IsNullOrEmpty(this._Facsimile))
                db.AddInParameter(dbCommand, "Facsimile", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Facsimile", DbType.String, this._Facsimile);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            if (string.IsNullOrEmpty(this._Notes))
                db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Purchasing_Contacts table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Purchasing_Contacts)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_ContactsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_Contacts", DbType.Decimal, pK_Purchasing_Contacts);

            db.ExecuteNonQuery(dbCommand);
        }

        public static bool CheckManageContact_IDExists(decimal pK_Purchasing_Contacts)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_ContactsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_Contacts", DbType.Decimal, pK_Purchasing_Contacts);           

            return Convert.ToBoolean(db.ExecuteScalar(dbCommand));
        }
    }
}
