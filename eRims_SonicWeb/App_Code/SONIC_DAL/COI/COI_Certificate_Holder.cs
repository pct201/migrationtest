using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Certificate_Holder table.
	/// </summary>
	public sealed class COI_Certificate_Holder
    {
        #region Fields


        private decimal _PK_COI_Certificate_Holder;
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
        /// Gets or sets the PK_COI_Certificate_Holder value.
        /// </summary>
        public decimal PK_COI_Certificate_Holder
        {
            get { return _PK_COI_Certificate_Holder; }
            set { _PK_COI_Certificate_Holder = value; }
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

        /// Initializes a new instance of the COI_Certificate_Holder class. with the default value.

        /// </summary>
        public COI_Certificate_Holder()
        {

            this._PK_COI_Certificate_Holder = -1;
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

        /// Initializes a new instance of the COI_Certificate_Holder class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public COI_Certificate_Holder(decimal PK)
        {

            DataTable dtCOI_Certificate_Holder =  SelectByPK(PK).Tables[0];

            if (dtCOI_Certificate_Holder.Rows.Count > 0)
            {

                DataRow drCOI_Certificate_Holder = dtCOI_Certificate_Holder.Rows[0];

                this._PK_COI_Certificate_Holder = drCOI_Certificate_Holder["PK_COI_Certificate_Holder"] != DBNull.Value ? Convert.ToDecimal(drCOI_Certificate_Holder["PK_COI_Certificate_Holder"]) : 0;
                this._Company = Convert.ToString(drCOI_Certificate_Holder["Company"]);
                this._Address_1 = Convert.ToString(drCOI_Certificate_Holder["Address_1"]);
                this._Address_2 = Convert.ToString(drCOI_Certificate_Holder["Address_2"]);
                this._City = Convert.ToString(drCOI_Certificate_Holder["City"]);
                this._FK_State = drCOI_Certificate_Holder["FK_State"] != DBNull.Value ? Convert.ToDecimal(drCOI_Certificate_Holder["FK_State"]) : 0;
                this._Zip_Code = Convert.ToString(drCOI_Certificate_Holder["Zip_Code"]);
                this._Contact_Last_Name = Convert.ToString(drCOI_Certificate_Holder["Contact_Last_Name"]);
                this._Contact_First_Name = Convert.ToString(drCOI_Certificate_Holder["Contact_First_Name"]);
                this._Contact_Title = Convert.ToString(drCOI_Certificate_Holder["Contact_Title"]);
                this._Contact_Phone = Convert.ToString(drCOI_Certificate_Holder["Contact_Phone"]);
                this._Contact_Fax = Convert.ToString(drCOI_Certificate_Holder["Contact_Fax"]);
                this._Contact_EMail = Convert.ToString(drCOI_Certificate_Holder["Contact_EMail"]);
                this._Notes = Convert.ToString(drCOI_Certificate_Holder["Notes"]);
                this._Update_Date = drCOI_Certificate_Holder["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Certificate_Holder["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Updated_By = Convert.ToString(drCOI_Certificate_Holder["Updated_By"]);

            }

            else
            {

                this._PK_COI_Certificate_Holder = -1;
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

        }



        #endregion


        #region "Methods"
        /// <summary>
		/// Inserts a record into the COI_Certificate_Holder table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Certificate_HolderInsert");

			db.AddInParameter(dbCommand, "Company", DbType.String, this._Company);
			db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);
			db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
			db.AddInParameter(dbCommand, "Contact_Last_Name", DbType.String, this._Contact_Last_Name);
			db.AddInParameter(dbCommand, "Contact_First_Name", DbType.String, this._Contact_First_Name);
			db.AddInParameter(dbCommand, "Contact_Title", DbType.String, this._Contact_Title);
			db.AddInParameter(dbCommand, "Contact_Phone", DbType.String, this._Contact_Phone);
			db.AddInParameter(dbCommand, "Contact_Fax", DbType.String, this._Contact_Fax);
			db.AddInParameter(dbCommand, "Contact_EMail", DbType.String, this._Contact_EMail);
			db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the COI_Certificate_Holder table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_COI_Certificate_Holder)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Certificate_HolderSelectByPK");

			db.AddInParameter(dbCommand, "PK_COI_Certificate_Holder", DbType.Decimal, pK_COI_Certificate_Holder);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the COI_Certificate_Holder table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Certificate_HolderSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the COI_Certificate_Holder table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Certificate_HolderUpdate");

			db.AddInParameter(dbCommand, "PK_COI_Certificate_Holder", DbType.Decimal, this._PK_COI_Certificate_Holder);
			db.AddInParameter(dbCommand, "Company", DbType.String, this._Company);
			db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);
			db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
			db.AddInParameter(dbCommand, "Contact_Last_Name", DbType.String, this._Contact_Last_Name);
			db.AddInParameter(dbCommand, "Contact_First_Name", DbType.String, this._Contact_First_Name);
			db.AddInParameter(dbCommand, "Contact_Title", DbType.String, this._Contact_Title);
			db.AddInParameter(dbCommand, "Contact_Phone", DbType.String, this._Contact_Phone);
			db.AddInParameter(dbCommand, "Contact_Fax", DbType.String, this._Contact_Fax);
			db.AddInParameter(dbCommand, "Contact_EMail", DbType.String, this._Contact_EMail);
			db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the COI_Certificate_Holder table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_COI_Certificate_Holder)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Certificate_HolderDeleteByPK");

			db.AddInParameter(dbCommand, "PK_COI_Certificate_Holder", DbType.Decimal, pK_COI_Certificate_Holder);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
    
}
