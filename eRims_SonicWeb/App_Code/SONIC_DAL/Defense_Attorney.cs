using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Defense_Attorney table.
	/// </summary>
	public sealed class Defense_Attorney
    {
        #region Fields


        private decimal _PK_Defense_Attorney;
        private decimal _FK_Executive_Risk;
        private string _Firm;
        private string _Name;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private decimal _FK_State;
        private string _Zip_Code;
        private string _Telephone;
        private string _E_Mail;
        private string _Panel;
        private string _Notes;
        private string _Updated_By;
        private DateTime _Update_Date;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Defense_Attorney value.
        /// </summary>
        public decimal PK_Defense_Attorney
        {
            get { return _PK_Defense_Attorney; }
            set { _PK_Defense_Attorney = value; }
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
        /// Gets or sets the Firm value.
        /// </summary>
        public string Firm
        {
            get { return _Firm; }
            set { _Firm = value; }
        }


        /// <summary> 
        /// Gets or sets the Name value.
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
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
        /// Gets or sets the Telephone value.
        /// </summary>
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }


        /// <summary> 
        /// Gets or sets the E_Mail value.
        /// </summary>
        public string E_Mail
        {
            get { return _E_Mail; }
            set { _E_Mail = value; }
        }


        /// <summary> 
        /// Gets or sets the Panel value.
        /// </summary>
        public string Panel
        {
            get { return _Panel; }
            set { _Panel = value; }
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
        public DateTime Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Defense_Attorney class. with the default value.

        /// </summary>
        public Defense_Attorney()
        {

            this._PK_Defense_Attorney = -1;
            this._FK_Executive_Risk = -1;
            this._Firm = "";
            this._Name = "";
            this._Address_1 = "";
            this._Address_2 = "";
            this._City = "";
            this._FK_State = -1;
            this._Zip_Code = "";
            this._Telephone = "";
            this._E_Mail = "";
            this._Panel = "";
            this._Notes = "";
            this._Updated_By = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 

        /// Initializes a new instance of the Defense_Attorney class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Defense_Attorney(decimal PK)
        {

            DataTable dtDefense_Attorney = SelectByPK(PK).Tables[0];

            if (dtDefense_Attorney.Rows.Count > 0)
            {

                DataRow drDefense_Attorney = dtDefense_Attorney.Rows[0];

                this._PK_Defense_Attorney = drDefense_Attorney["PK_Defense_Attorney"] != DBNull.Value ? Convert.ToDecimal(drDefense_Attorney["PK_Defense_Attorney"]) : 0;
                this._FK_Executive_Risk = drDefense_Attorney["FK_Executive_Risk"] != DBNull.Value ? Convert.ToDecimal(drDefense_Attorney["FK_Executive_Risk"]) : 0;
                this._Firm = Convert.ToString(drDefense_Attorney["Firm"]);
                this._Name = Convert.ToString(drDefense_Attorney["Name"]);
                this._Address_1 = Convert.ToString(drDefense_Attorney["Address_1"]);
                this._Address_2 = Convert.ToString(drDefense_Attorney["Address_2"]);
                this._City = Convert.ToString(drDefense_Attorney["City"]);
                this._FK_State = drDefense_Attorney["FK_State"] != DBNull.Value ? Convert.ToDecimal(drDefense_Attorney["FK_State"]) : 0;
                this._Zip_Code = Convert.ToString(drDefense_Attorney["Zip_Code"]);
                this._Telephone = Convert.ToString(drDefense_Attorney["Telephone"]);
                this._E_Mail = Convert.ToString(drDefense_Attorney["E_Mail"]);
                this._Panel = Convert.ToString(drDefense_Attorney["Panel"]);
                this._Notes = Convert.ToString(drDefense_Attorney["Notes"]);
                this._Updated_By = Convert.ToString(drDefense_Attorney["Updated_By"]);
                this._Update_Date = drDefense_Attorney["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drDefense_Attorney["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._PK_Defense_Attorney = -1;
                this._FK_Executive_Risk = -1;
                this._Firm = "";
                this._Name = "";
                this._Address_1 = "";
                this._Address_2 = "";
                this._City = "";
                this._FK_State = -1;
                this._Zip_Code = "";
                this._Telephone = "";
                this._E_Mail = "";
                this._Panel = "";
                this._Notes = "";
                this._Updated_By = "";
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }



        #endregion

        #region "Methods"
        /// <summary>
		/// Inserts a record into the Defense_Attorney table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Defense_AttorneyInsert");

			db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, this._FK_Executive_Risk);
			db.AddInParameter(dbCommand, "Firm", DbType.String, this._Firm);
			db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);
			db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);
			db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
			db.AddInParameter(dbCommand, "Telephone", DbType.String, this._Telephone);
			db.AddInParameter(dbCommand, "E_Mail", DbType.String, this._E_Mail);
			db.AddInParameter(dbCommand, "Panel", DbType.String, this._Panel);
			db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Defense_Attorney table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_Defense_Attorney)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Defense_AttorneySelectByPK");

			db.AddInParameter(dbCommand, "PK_Defense_Attorney", DbType.Decimal, pK_Defense_Attorney);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects records from the Defense_Attorney table by a foreign key.
		/// </summary>
		/// <param name="fK_Executive_Risk"></param>
		/// <returns>DataSet</returns>
		public static DataSet SelectByFK_Executive_Risk(decimal fK_Executive_Risk)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Defense_AttorneySelectByFK_Executive_Risk");

			db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, fK_Executive_Risk);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Defense_Attorney table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Defense_AttorneySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Defense_Attorney table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Defense_AttorneyUpdate");

			db.AddInParameter(dbCommand, "PK_Defense_Attorney", DbType.Decimal, this._PK_Defense_Attorney);
			db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, this._FK_Executive_Risk);
			db.AddInParameter(dbCommand, "Firm", DbType.String, this._Firm);
			db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);
			db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);
			db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
			db.AddInParameter(dbCommand, "Telephone", DbType.String, this._Telephone);
			db.AddInParameter(dbCommand, "E_Mail", DbType.String, this._E_Mail);
			db.AddInParameter(dbCommand, "Panel", DbType.String, this._Panel);
			db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Defense_Attorney table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Defense_Attorney)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Defense_AttorneyDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Defense_Attorney", DbType.Decimal, pK_Defense_Attorney);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Defense_Attorney table by a foreign key.
		/// </summary>
		public static void DeleteByFK_Executive_Risk(decimal fK_Executive_Risk)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Defense_AttorneyDeleteByFK_Executive_Risk");

			db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, fK_Executive_Risk);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
