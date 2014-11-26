using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_SI_Facility_Id table.
	/// </summary>
	public sealed class PM_SI_Facility_Id
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_SI_Faciltiy_ID;
		private decimal? _FK_PM_Site_Information;
		private decimal? _FK_LU_Agency;
		private decimal? _FK_LU_Media;
		private string _Identification_Number;
		private string _Contact_Name;
		private string _Address_1;
		private string _Address_2;
		private string _City;
		private decimal? _FK_State;
		private string _Zip_Code;
		private string _Telephone;
		private string _Updated_By;
		private DateTime? _Updated_Date;
        private decimal? _FK_LU_Location_ID;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_SI_Faciltiy_ID value.
		/// </summary>
		public decimal? PK_PM_SI_Faciltiy_ID
		{
			get { return _PK_PM_SI_Faciltiy_ID; }
			set { _PK_PM_SI_Faciltiy_ID = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_Site_Information value.
		/// </summary>
		public decimal? FK_PM_Site_Information
		{
			get { return _FK_PM_Site_Information; }
			set { _FK_PM_Site_Information = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Agency value.
		/// </summary>
		public decimal? FK_LU_Agency
		{
			get { return _FK_LU_Agency; }
			set { _FK_LU_Agency = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Media value.
		/// </summary>
		public decimal? FK_LU_Media
		{
			get { return _FK_LU_Media; }
			set { _FK_LU_Media = value; }
		}

		/// <summary>
		/// Gets or sets the Identification_Number value.
		/// </summary>
		public string Identification_Number
		{
			get { return _Identification_Number; }
			set { _Identification_Number = value; }
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
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_Date value.
		/// </summary>
		public DateTime? Updated_Date
		{
			get { return _Updated_Date; }
			set { _Updated_Date = value; }
		}

        /// <summary>
        /// Gets or sets the FK_LU_Location_ID value.
        /// </summary>
        public decimal? FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
        }


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_SI_Facility_Id class with default value.
		/// </summary>
		public PM_SI_Facility_Id() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_SI_Facility_Id class based on Primary Key.
		/// </summary>
		public PM_SI_Facility_Id(decimal pK_PM_SI_Faciltiy_ID) 
		{
			DataTable dtPM_SI_Facility_Id = SelectByPK(pK_PM_SI_Faciltiy_ID).Tables[0];

			if (dtPM_SI_Facility_Id.Rows.Count == 1)
			{
				 SetValue(dtPM_SI_Facility_Id.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_SI_Facility_Id class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_SI_Facility_Id) 
		{
				if (drPM_SI_Facility_Id["PK_PM_SI_Faciltiy_ID"] == DBNull.Value)
					this._PK_PM_SI_Faciltiy_ID = null;
				else
					this._PK_PM_SI_Faciltiy_ID = (decimal?)drPM_SI_Facility_Id["PK_PM_SI_Faciltiy_ID"];

				if (drPM_SI_Facility_Id["FK_PM_Site_Information"] == DBNull.Value)
					this._FK_PM_Site_Information = null;
				else
					this._FK_PM_Site_Information = (decimal?)drPM_SI_Facility_Id["FK_PM_Site_Information"];

				if (drPM_SI_Facility_Id["FK_LU_Agency"] == DBNull.Value)
					this._FK_LU_Agency = null;
				else
					this._FK_LU_Agency = (decimal?)drPM_SI_Facility_Id["FK_LU_Agency"];

				if (drPM_SI_Facility_Id["FK_LU_Media"] == DBNull.Value)
					this._FK_LU_Media = null;
				else
					this._FK_LU_Media = (decimal?)drPM_SI_Facility_Id["FK_LU_Media"];

				if (drPM_SI_Facility_Id["Identification_Number"] == DBNull.Value)
					this._Identification_Number = null;
				else
					this._Identification_Number = (string)drPM_SI_Facility_Id["Identification_Number"];

				if (drPM_SI_Facility_Id["Contact_Name"] == DBNull.Value)
					this._Contact_Name = null;
				else
					this._Contact_Name = (string)drPM_SI_Facility_Id["Contact_Name"];

				if (drPM_SI_Facility_Id["Address_1"] == DBNull.Value)
					this._Address_1 = null;
				else
					this._Address_1 = (string)drPM_SI_Facility_Id["Address_1"];

				if (drPM_SI_Facility_Id["Address_2"] == DBNull.Value)
					this._Address_2 = null;
				else
					this._Address_2 = (string)drPM_SI_Facility_Id["Address_2"];

				if (drPM_SI_Facility_Id["City"] == DBNull.Value)
					this._City = null;
				else
					this._City = (string)drPM_SI_Facility_Id["City"];

				if (drPM_SI_Facility_Id["FK_State"] == DBNull.Value)
					this._FK_State = null;
				else
					this._FK_State = (decimal?)drPM_SI_Facility_Id["FK_State"];

				if (drPM_SI_Facility_Id["Zip_Code"] == DBNull.Value)
					this._Zip_Code = null;
				else
					this._Zip_Code = (string)drPM_SI_Facility_Id["Zip_Code"];

				if (drPM_SI_Facility_Id["Telephone"] == DBNull.Value)
					this._Telephone = null;
				else
					this._Telephone = (string)drPM_SI_Facility_Id["Telephone"];

				if (drPM_SI_Facility_Id["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_SI_Facility_Id["Updated_By"];

				if (drPM_SI_Facility_Id["Updated_Date"] == DBNull.Value)
					this._Updated_Date = null;
				else
					this._Updated_Date = (DateTime?)drPM_SI_Facility_Id["Updated_Date"];

                this._FK_LU_Location_ID = null;
		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_SI_Facility_Id table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_SI_Facility_IdInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "FK_LU_Agency", DbType.Decimal, this._FK_LU_Agency);
			
			db.AddInParameter(dbCommand, "FK_LU_Media", DbType.Decimal, this._FK_LU_Media);
			
			if (string.IsNullOrEmpty(this._Identification_Number))
				db.AddInParameter(dbCommand, "Identification_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Identification_Number", DbType.String, this._Identification_Number);
			
			if (string.IsNullOrEmpty(this._Contact_Name))
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
			
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
			
			if (string.IsNullOrEmpty(this._Zip_Code))
				db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
			
			if (string.IsNullOrEmpty(this._Telephone))
				db.AddInParameter(dbCommand, "Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Telephone", DbType.String, this._Telephone);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_SI_Facility_Id table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_SI_Faciltiy_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_SI_Facility_IdSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_SI_Faciltiy_ID", DbType.Decimal, pK_PM_SI_Faciltiy_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_SI_Facility_Id table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_SI_Facility_IdSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_SI_Facility_Id table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_SI_Facility_IdUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_SI_Faciltiy_ID", DbType.Decimal, this._PK_PM_SI_Faciltiy_ID);
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "FK_LU_Agency", DbType.Decimal, this._FK_LU_Agency);
			
			db.AddInParameter(dbCommand, "FK_LU_Media", DbType.Decimal, this._FK_LU_Media);
			
			if (string.IsNullOrEmpty(this._Identification_Number))
				db.AddInParameter(dbCommand, "Identification_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Identification_Number", DbType.String, this._Identification_Number);
			
			if (string.IsNullOrEmpty(this._Contact_Name))
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
			
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
			
			if (string.IsNullOrEmpty(this._Zip_Code))
				db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
			
			if (string.IsNullOrEmpty(this._Telephone))
				db.AddInParameter(dbCommand, "Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Telephone", DbType.String, this._Telephone);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the PM_SI_Facility_Id table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_SI_Faciltiy_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_SI_Facility_IdDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_SI_Faciltiy_ID", DbType.Decimal, pK_PM_SI_Faciltiy_ID);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects records by FK
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet SelectByFK_SiteInfo(decimal fK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_SI_Facility_IdSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the PM_SI_Utility_Provider table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetAuditView(decimal pK_PM_SI_Faciltiy_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_SI_Faciltiy_ID_AuditView");

            db.AddInParameter(dbCommand, "pK_PM_SI_Faciltiy_ID", DbType.Decimal, pK_PM_SI_Faciltiy_ID);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
