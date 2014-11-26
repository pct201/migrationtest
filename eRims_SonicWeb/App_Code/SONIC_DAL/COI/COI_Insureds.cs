using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for COI_Insureds table.
    /// </summary>
    public sealed class COI_Insureds
    {
        #region Fields
        private decimal _PK_COI_Insureds;
        private string _Insured_Name;
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
        private decimal _FK_COI_Type;
        private string  _FK_COI_Region;
        private DateTime _Date_Activiated;
        private DateTime _Date_Closed;
        private string _Active;
        private string _AM_Best_Required;
        private string _Sublease_Agreement;
        private string _Notes;
        private DateTime _Update_Date;
        private string _Updated_By;
        private decimal _Building_TIV;
        private decimal _FK_Building_Ownership_ID;
        private string _Building_Number;
        private bool _AllowEditTIV;
        private string _Fld_State;
        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_COI_Insureds value.
        /// </summary>
        public decimal PK_COI_Insureds
        {
            get { return _PK_COI_Insureds; }
            set { _PK_COI_Insureds = value; }
        }


        /// <summary> 
        /// Gets or sets the Insured_Name value.
        /// </summary>
        public string Insured_Name
        {
            get { return _Insured_Name; }
            set { _Insured_Name = value; }
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
        /// Gets or sets the FK_COI_Type value.
        /// </summary>
        public decimal FK_COI_Type
        {
            get { return _FK_COI_Type; }
            set { _FK_COI_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COI_Region value.
        /// </summary>
        public string FK_COI_Region
        {
            get { return _FK_COI_Region; }
            set { _FK_COI_Region = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Activiated value.
        /// </summary>
        public DateTime Date_Activiated
        {
            get { return _Date_Activiated; }
            set { _Date_Activiated = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Closed value.
        /// </summary>
        public DateTime Date_Closed
        {
            get { return _Date_Closed; }
            set { _Date_Closed = value; }
        }


        /// <summary> 
        /// Gets or sets the Active value.
        /// </summary>
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        /// <summary> 
        /// Gets or sets the AM_Best_Required value.
        /// </summary>
        public string AM_Best_Required
        {
            get { return _AM_Best_Required; }
            set { _AM_Best_Required = value; }
        }

        /// <summary> 
        /// Gets or sets the AM_Best_Required value.
        /// </summary>
        public string Sublease_Agreement
        {
            get { return _Sublease_Agreement; }
            set { _Sublease_Agreement = value; }
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

        public decimal Building_TIV
        {
            get { return _Building_TIV; }
            set { _Building_TIV = value; }
        }

        /// <summary> 
        /// Gets or sets the PK_COI_Insureds value.
        /// </summary>
        public decimal FK_Building_Ownership_ID
        {
            get { return _FK_Building_Ownership_ID; }
            set { _FK_Building_Ownership_ID = value; }
        }
        /// <summary> 
        /// Gets or sets the Building_Number value.
        /// </summary>
        public string Building_Number
        {
            get { return _Building_Number; }
            set { _Building_Number = value; }
        }

        public bool AllowEditTIV
        {
            get { return _AllowEditTIV; }
            set { _AllowEditTIV = value; }
        }

        public string Fld_State
        {
            get { return _Fld_State; }
            set { _Fld_State = value; }
        }

        #endregion


        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the COI_Insureds class. with the default value.
        /// </summary>
        public COI_Insureds()
        {

            this._PK_COI_Insureds = -1;
            this._Insured_Name = "";
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
            this._FK_COI_Type = -1;
            this._FK_COI_Region = "";
            this._Date_Activiated = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
            this._Date_Closed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
            this._Active = "";
            this._AM_Best_Required = "";
            this._Sublease_Agreement = "";
            this._Notes = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Updated_By = "";
            this._Building_TIV = 0;
            this._FK_Building_Ownership_ID = 0;
            this.Building_Number = "";
            this._Fld_State = "";
        }

        /// <summary> 
        /// Initializes a new instance of the COI_Insureds class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public COI_Insureds(decimal PK)
        {
            DataTable dtCOI_Insureds = Select(PK).Tables[0];

            if (dtCOI_Insureds.Rows.Count > 0)
            {

                DataRow drCOI_Insureds = dtCOI_Insureds.Rows[0];

                this._PK_COI_Insureds = drCOI_Insureds["PK_COI_Insureds"] != DBNull.Value ? Convert.ToDecimal(drCOI_Insureds["PK_COI_Insureds"]) : 0;
                this._Insured_Name = Convert.ToString(drCOI_Insureds["Insured_Name"]);
                this._Address_1 = Convert.ToString(drCOI_Insureds["Address_1"]);
                this._Address_2 = Convert.ToString(drCOI_Insureds["Address_2"]);
                this._City = Convert.ToString(drCOI_Insureds["City"]);
                this._FK_State = drCOI_Insureds["FK_State"] != DBNull.Value ? Convert.ToDecimal(drCOI_Insureds["FK_State"]) : 0;
                this._Zip_Code = Convert.ToString(drCOI_Insureds["Zip_Code"]);
                this._Contact_Last_Name = Convert.ToString(drCOI_Insureds["Contact_Last_Name"]);
                this._Contact_First_Name = Convert.ToString(drCOI_Insureds["Contact_First_Name"]);
                this._Contact_Title = Convert.ToString(drCOI_Insureds["Contact_Title"]);
                this._Contact_Phone = Convert.ToString(drCOI_Insureds["Contact_Phone"]);
                this._Contact_Fax = Convert.ToString(drCOI_Insureds["Contact_Fax"]);
                this._Contact_EMail = Convert.ToString(drCOI_Insureds["Contact_EMail"]);
                this._FK_COI_Type = drCOI_Insureds["FK_COI_Type"] != DBNull.Value ? Convert.ToDecimal(drCOI_Insureds["FK_COI_Type"]) : 0;
                this._FK_COI_Region = Convert.ToString(drCOI_Insureds["FK_COI_Region"]); //drCOI_Insureds["FK_COI_Region"] != DBNull.Value ? Convert.ToDecimal(drCOI_Insureds["FK_COI_Region"]) : 0;
                this._Date_Activiated = drCOI_Insureds["Date_Activiated"] != DBNull.Value ? Convert.ToDateTime(drCOI_Insureds["Date_Activiated"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Date_Closed = drCOI_Insureds["Date_Closed"] != DBNull.Value ? Convert.ToDateTime(drCOI_Insureds["Date_Closed"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Active = Convert.ToString(drCOI_Insureds["Active"]);
                this._AM_Best_Required = Convert.ToString(drCOI_Insureds["AM_Best_Required"]);
                this._Sublease_Agreement = Convert.ToString(drCOI_Insureds["Sublease_Agreement"]);
                this._Notes = Convert.ToString(drCOI_Insureds["Notes"]);
                this._Update_Date = drCOI_Insureds["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Insureds["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Updated_By = Convert.ToString(drCOI_Insureds["Updated_By"]);
                this._Building_TIV = drCOI_Insureds["Building_TIV"] != DBNull.Value ? Convert.ToDecimal(drCOI_Insureds["Building_TIV"]) : 0;
                this._FK_Building_Ownership_ID = drCOI_Insureds["FK_Building_Ownership_ID"] != DBNull.Value ? Convert.ToDecimal(drCOI_Insureds["FK_Building_Ownership_ID"]) : 0;
                this._Building_Number = Convert.ToString(drCOI_Insureds["Building_Number"]);
                this._AllowEditTIV = Convert.ToBoolean(drCOI_Insureds["AllowEditTIV"]);
                this._Fld_State = Convert.ToString(drCOI_Insureds["Fld_State"]);
            }
            else
            {
                new COI_Insureds();
            }
        }

        public COI_Insureds(decimal PK,decimal Pk_Coi)
        {
            DataTable dtCOI_Insureds = Select(PK, Pk_Coi).Tables[0];

            if (dtCOI_Insureds.Rows.Count > 0)
            {

                DataRow drCOI_Insureds = dtCOI_Insureds.Rows[0];

                this._PK_COI_Insureds = drCOI_Insureds["PK_COI_Insureds"] != DBNull.Value ? Convert.ToDecimal(drCOI_Insureds["PK_COI_Insureds"]) : 0;
                this._Insured_Name = Convert.ToString(drCOI_Insureds["Insured_Name"]);
                this._Address_1 = Convert.ToString(drCOI_Insureds["Address_1"]);
                this._Address_2 = Convert.ToString(drCOI_Insureds["Address_2"]);
                this._City = Convert.ToString(drCOI_Insureds["City"]);
                this._FK_State = drCOI_Insureds["FK_State"] != DBNull.Value ? Convert.ToDecimal(drCOI_Insureds["FK_State"]) : 0;
                this._Zip_Code = Convert.ToString(drCOI_Insureds["Zip_Code"]);
                this._Contact_Last_Name = Convert.ToString(drCOI_Insureds["Contact_Last_Name"]);
                this._Contact_First_Name = Convert.ToString(drCOI_Insureds["Contact_First_Name"]);
                this._Contact_Title = Convert.ToString(drCOI_Insureds["Contact_Title"]);
                this._Contact_Phone = Convert.ToString(drCOI_Insureds["Contact_Phone"]);
                this._Contact_Fax = Convert.ToString(drCOI_Insureds["Contact_Fax"]);
                this._Contact_EMail = Convert.ToString(drCOI_Insureds["Contact_EMail"]);
                this._FK_COI_Type = drCOI_Insureds["FK_COI_Type"] != DBNull.Value ? Convert.ToDecimal(drCOI_Insureds["FK_COI_Type"]) : 0;
                this._FK_COI_Region = Convert.ToString(drCOI_Insureds["FK_COI_Region"]); //drCOI_Insureds["FK_COI_Region"] != DBNull.Value ? Convert.ToDecimal(drCOI_Insureds["FK_COI_Region"]) : 0;
                this._Date_Activiated = drCOI_Insureds["Date_Activiated"] != DBNull.Value ? Convert.ToDateTime(drCOI_Insureds["Date_Activiated"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Date_Closed = drCOI_Insureds["Date_Closed"] != DBNull.Value ? Convert.ToDateTime(drCOI_Insureds["Date_Closed"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Active = Convert.ToString(drCOI_Insureds["Active"]);
                this._AM_Best_Required = Convert.ToString(drCOI_Insureds["AM_Best_Required"]);
                this._Sublease_Agreement = Convert.ToString(drCOI_Insureds["Sublease_Agreement"]);
                this._Notes = Convert.ToString(drCOI_Insureds["Notes"]);
                this._Update_Date = drCOI_Insureds["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Insureds["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Updated_By = Convert.ToString(drCOI_Insureds["Updated_By"]);
                this._Building_TIV = drCOI_Insureds["Building_TIV"] != DBNull.Value ? Convert.ToDecimal(drCOI_Insureds["Building_TIV"]) : 0;
                this._FK_Building_Ownership_ID = drCOI_Insureds["FK_Building_Ownership_ID"] != DBNull.Value ? Convert.ToDecimal(drCOI_Insureds["FK_Building_Ownership_ID"]) : 0;
                this._Building_Number = Convert.ToString(drCOI_Insureds["Building_Number"]);
                this._AllowEditTIV = Convert.ToBoolean(drCOI_Insureds["AllowEditTIV"]);
                this._Fld_State = Convert.ToString(drCOI_Insureds["Fld_State"]);
            }
            else
            {
                new COI_Insureds();
            }
        }
        #endregion


        #region "Methods"
        /// <summary>
        /// Inserts a record into the COI_Insureds table.
        /// <summary>
        /// <param name="insured_Name"></param>
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
        /// <param name="fK_COI_Type"></param>
        /// <param name="fK_COI_Region"></param>
        /// <param name="date_Activiated"></param>
        /// <param name="date_Closed"></param>
        /// <param name="active"></param>
        /// <param name="aM_Best_Required"></param>
        /// <param name="notes"></param>
        /// <param name="update_Date"></param>
        /// <param name="updated_By"></param>
        /// <returns></returns>
        public static int Insert(string insured_Name, string address_1, string address_2, string city, decimal fK_State, string zip_Code, string contact_Last_Name, string contact_First_Name, string contact_Title, string contact_Phone, string contact_Fax, string contact_EMail, decimal fK_COI_Type, string fK_COI_Region, DateTime date_Activiated, DateTime date_Closed, string active, string aM_Best_Required, string sublease_Agreement, string notes, DateTime update_Date, string updated_By, decimal fK_Building_Ownership_ID, string building_Number)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_InsuredsInsert");

            db.AddInParameter(dbCommand, "Insured_Name", DbType.String, insured_Name);
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
            db.AddInParameter(dbCommand, "FK_COI_Type", DbType.Decimal, fK_COI_Type);
            db.AddInParameter(dbCommand, "FK_COI_Region", DbType.String, fK_COI_Region);
            db.AddInParameter(dbCommand, "Date_Activiated", DbType.DateTime, date_Activiated);
            db.AddInParameter(dbCommand, "Date_Closed", DbType.DateTime, date_Closed);
            db.AddInParameter(dbCommand, "Active", DbType.String, active);
            db.AddInParameter(dbCommand, "AM_Best_Required", DbType.String, aM_Best_Required);
            db.AddInParameter(dbCommand, "Sublease_Agreement", DbType.String, sublease_Agreement);
            db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "FK_Building_Ownership_ID", DbType.Decimal, fK_Building_Ownership_ID);
            db.AddInParameter(dbCommand, "Building_Number", DbType.String, building_Number);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the COI_Insureds table.
        /// <summary>
        /// <returns>DataSet</returns>
        public static DataSet Select(decimal pK_COI_Insureds)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_InsuredsSelect");

            db.AddInParameter(dbCommand, "PK_COI_Insureds", DbType.Decimal, pK_COI_Insureds);
            db.AddInParameter(dbCommand, "Pk_COI", DbType.Decimal, 0);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the COI_Insureds table.
        /// <summary>
        /// <returns>DataSet</returns>
        public static DataSet Select(decimal pK_COI_Insureds, decimal Pk_COI)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_InsuredsSelect");
            db.AddInParameter(dbCommand, "PK_COI_Insureds", DbType.Decimal, pK_COI_Insureds);
            db.AddInParameter(dbCommand, "Pk_COI", DbType.Decimal, Pk_COI);

            return db.ExecuteDataSet(dbCommand);
        }



        /// <summary>
        /// Updates a record in the COI_Insureds table.
        /// <summary>
        /// <param name="pK_COI_Insureds"></param>
        /// <param name="insured_Name"></param>
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
        /// <param name="fK_COI_Type"></param>
        /// <param name="fK_COI_Region"></param>
        /// <param name="date_Activiated"></param>
        /// <param name="date_Closed"></param>
        /// <param name="active"></param>
        /// <param name="aM_Best_Required"></param>
        /// <param name="notes"></param>
        /// <param name="update_Date"></param>
        /// <param name="updated_By"></param>
        public static void Update(decimal pK_COI_Insureds, string insured_Name, string address_1, string address_2, string city, decimal fK_State, string zip_Code, string contact_Last_Name, string contact_First_Name, string contact_Title, string contact_Phone, string contact_Fax, string contact_EMail, decimal fK_COI_Type, string fK_COI_Region, DateTime date_Activiated, DateTime date_Closed, string active, string aM_Best_Required, string sublease_Agreement, string notes, DateTime update_Date, string updated_By, decimal fK_Building_Ownership_ID, string building_Number)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_InsuredsUpdate");

            db.AddInParameter(dbCommand, "PK_COI_Insureds", DbType.Decimal, pK_COI_Insureds);
            db.AddInParameter(dbCommand, "Insured_Name", DbType.String, insured_Name);
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
            db.AddInParameter(dbCommand, "FK_COI_Type", DbType.Decimal, fK_COI_Type);
            db.AddInParameter(dbCommand, "FK_COI_Region", DbType.String, fK_COI_Region);
            db.AddInParameter(dbCommand, "Date_Activiated", DbType.DateTime, date_Activiated);
            db.AddInParameter(dbCommand, "Date_Closed", DbType.DateTime, date_Closed);
            db.AddInParameter(dbCommand, "Active", DbType.String, active);
            db.AddInParameter(dbCommand, "AM_Best_Required", DbType.String, aM_Best_Required);
            db.AddInParameter(dbCommand, "Sublease_Agreement", DbType.String, sublease_Agreement);
            db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "FK_Building_Ownership_ID", DbType.Decimal, fK_Building_Ownership_ID);
            db.AddInParameter(dbCommand, "Building_Number", DbType.String, building_Number);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the COI_Insureds table by a composite primary key.
        /// <summary>
        public static void Delete(decimal pK_COI_Insureds)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_InsuredsDelete");

            db.AddInParameter(dbCommand, "PK_COI_Insureds", DbType.Decimal, pK_COI_Insureds);

            db.ExecuteNonQuery(dbCommand);
        }



        /// <summary>
        /// Calls parameterized Insert method to Insert the record
        /// </summary>
        /// <returns>The primary key value for newly Inserted record</returns>
        public int Insert()
        {
            return Insert(_Insured_Name, _Address_1, _Address_2, _City, _FK_State, _Zip_Code, _Contact_Last_Name, _Contact_First_Name,
                _Contact_Title, _Contact_Phone, _Contact_Fax, _Contact_EMail, _FK_COI_Type, _FK_COI_Region, _Date_Activiated,
                _Date_Closed, _Active, _AM_Best_Required, _Sublease_Agreement, _Notes, _Update_Date, _Updated_By,_FK_Building_Ownership_ID,_Building_Number);
        }

        /// <summary>
        /// Calls parameterized Update method to Update the record
        /// </summary>
        public void Update()
        {
            Update(_PK_COI_Insureds, _Insured_Name, _Address_1, _Address_2, _City, _FK_State, _Zip_Code, _Contact_Last_Name, _Contact_First_Name,
                _Contact_Title, _Contact_Phone, _Contact_Fax, _Contact_EMail, _FK_COI_Type, _FK_COI_Region, _Date_Activiated,
                _Date_Closed, _Active, _AM_Best_Required, _Sublease_Agreement, _Notes, _Update_Date, _Updated_By, _FK_Building_Ownership_ID,_Building_Number);
        }

        /// <summary>
        /// Returns all records that matches the search crieteria
        /// </summary>
        /// <param name="strInsured_Name"></param>
        /// <returns>DataSet</returns>
        public static DataSet Search(string strInsured_Name)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_InsuredsSearch");
            db.AddInParameter(dbCommand, "Insured_Name", DbType.String, strInsured_Name);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetBuildingTIV(decimal Fk_Lu_Location_Id, decimal FK_COI)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetBuildingTIV");
            //db.AddInParameter(dbCommand, "Building_Numbers", DbType.String, strBuilding_Numbers);
            db.AddInParameter(dbCommand, "Fk_Lu_Location_Id", DbType.Decimal, Fk_Lu_Location_Id);
            db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, FK_COI);
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
