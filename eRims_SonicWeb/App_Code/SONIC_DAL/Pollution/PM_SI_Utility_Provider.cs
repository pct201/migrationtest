using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_SI_Utility_Provider table.
	/// </summary>
	public sealed class PM_SI_Utility_Provider
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_SI_Utility_Provider;
		private decimal? _FK_PM_Site_Information;
		private decimal? _FK_LU_Utility_Type;
		private string _Utility_Name;
		private string _Telephone;
		private string _Contact_Name;
		private string _Address_1;
		private string _Address_2;
		private string _City;
		private decimal? _FK_State;
		private string _Zip_Code;
		private DateTime? _Contact_Start_Date;
		private DateTime? _Contact_End_Date;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private decimal? _FK_LU_Location_ID;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_SI_Utility_Provider value.
		/// </summary>
		public decimal? PK_PM_SI_Utility_Provider
		{
			get { return _PK_PM_SI_Utility_Provider; }
			set { _PK_PM_SI_Utility_Provider = value; }
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
		/// Gets or sets the FK_LU_Utility_Type value.
		/// </summary>
		public decimal? FK_LU_Utility_Type
		{
			get { return _FK_LU_Utility_Type; }
			set { _FK_LU_Utility_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Utility_Name value.
		/// </summary>
		public string Utility_Name
		{
			get { return _Utility_Name; }
			set { _Utility_Name = value; }
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
		/// Gets or sets the Contact_Start_Date value.
		/// </summary>
		public DateTime? Contact_Start_Date
		{
			get { return _Contact_Start_Date; }
			set { _Contact_Start_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Contact_End_Date value.
		/// </summary>
		public DateTime? Contact_End_Date
		{
			get { return _Contact_End_Date; }
			set { _Contact_End_Date = value; }
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
		/// Initializes a new instance of the clsPM_SI_Utility_Provider class with default value.
		/// </summary>
		public PM_SI_Utility_Provider() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_SI_Utility_Provider class based on Primary Key.
		/// </summary>
		public PM_SI_Utility_Provider(decimal pK_PM_SI_Utility_Provider) 
		{
			DataTable dtPM_SI_Utility_Provider = SelectByPK(pK_PM_SI_Utility_Provider).Tables[0];

			if (dtPM_SI_Utility_Provider.Rows.Count == 1)
			{
				 SetValue(dtPM_SI_Utility_Provider.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_SI_Utility_Provider class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_SI_Utility_Provider) 
		{
				if (drPM_SI_Utility_Provider["PK_PM_SI_Utility_Provider"] == DBNull.Value)
					this._PK_PM_SI_Utility_Provider = null;
				else
					this._PK_PM_SI_Utility_Provider = (decimal?)drPM_SI_Utility_Provider["PK_PM_SI_Utility_Provider"];

				if (drPM_SI_Utility_Provider["FK_PM_Site_Information"] == DBNull.Value)
					this._FK_PM_Site_Information = null;
				else
					this._FK_PM_Site_Information = (decimal?)drPM_SI_Utility_Provider["FK_PM_Site_Information"];

				if (drPM_SI_Utility_Provider["FK_LU_Utility_Type"] == DBNull.Value)
					this._FK_LU_Utility_Type = null;
				else
					this._FK_LU_Utility_Type = (decimal?)drPM_SI_Utility_Provider["FK_LU_Utility_Type"];

				if (drPM_SI_Utility_Provider["Utility_Name"] == DBNull.Value)
					this._Utility_Name = null;
				else
					this._Utility_Name = (string)drPM_SI_Utility_Provider["Utility_Name"];

				if (drPM_SI_Utility_Provider["Telephone"] == DBNull.Value)
					this._Telephone = null;
				else
					this._Telephone = (string)drPM_SI_Utility_Provider["Telephone"];

				if (drPM_SI_Utility_Provider["Contact_Name"] == DBNull.Value)
					this._Contact_Name = null;
				else
					this._Contact_Name = (string)drPM_SI_Utility_Provider["Contact_Name"];

				if (drPM_SI_Utility_Provider["Address_1"] == DBNull.Value)
					this._Address_1 = null;
				else
					this._Address_1 = (string)drPM_SI_Utility_Provider["Address_1"];

				if (drPM_SI_Utility_Provider["Address_2"] == DBNull.Value)
					this._Address_2 = null;
				else
					this._Address_2 = (string)drPM_SI_Utility_Provider["Address_2"];

				if (drPM_SI_Utility_Provider["City"] == DBNull.Value)
					this._City = null;
				else
					this._City = (string)drPM_SI_Utility_Provider["City"];

				if (drPM_SI_Utility_Provider["FK_State"] == DBNull.Value)
					this._FK_State = null;
				else
					this._FK_State = (decimal?)drPM_SI_Utility_Provider["FK_State"];

				if (drPM_SI_Utility_Provider["Zip_Code"] == DBNull.Value)
					this._Zip_Code = null;
				else
					this._Zip_Code = (string)drPM_SI_Utility_Provider["Zip_Code"];

				if (drPM_SI_Utility_Provider["Contact_Start_Date"] == DBNull.Value)
					this._Contact_Start_Date = null;
				else
					this._Contact_Start_Date = (DateTime?)drPM_SI_Utility_Provider["Contact_Start_Date"];

				if (drPM_SI_Utility_Provider["Contact_End_Date"] == DBNull.Value)
					this._Contact_End_Date = null;
				else
					this._Contact_End_Date = (DateTime?)drPM_SI_Utility_Provider["Contact_End_Date"];

				if (drPM_SI_Utility_Provider["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_SI_Utility_Provider["Updated_By"];

				if (drPM_SI_Utility_Provider["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_SI_Utility_Provider["Update_Date"];
                
            this._FK_LU_Location_ID = null;


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_SI_Utility_Provider table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_SI_Utility_ProviderInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "FK_LU_Utility_Type", DbType.Decimal, this._FK_LU_Utility_Type);
			
			if (string.IsNullOrEmpty(this._Utility_Name))
				db.AddInParameter(dbCommand, "Utility_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Utility_Name", DbType.String, this._Utility_Name);
			
			if (string.IsNullOrEmpty(this._Telephone))
				db.AddInParameter(dbCommand, "Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Telephone", DbType.String, this._Telephone);
			
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
			
			db.AddInParameter(dbCommand, "Contact_Start_Date", DbType.DateTime, this._Contact_Start_Date);
			
			db.AddInParameter(dbCommand, "Contact_End_Date", DbType.DateTime, this._Contact_End_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_SI_Utility_Provider table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_SI_Utility_Provider)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_SI_Utility_ProviderSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_SI_Utility_Provider", DbType.Decimal, pK_PM_SI_Utility_Provider);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_SI_Utility_Provider table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_SI_Utility_ProviderSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_SI_Utility_Provider table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_SI_Utility_ProviderUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_SI_Utility_Provider", DbType.Decimal, this._PK_PM_SI_Utility_Provider);
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "FK_LU_Utility_Type", DbType.Decimal, this._FK_LU_Utility_Type);
			
			if (string.IsNullOrEmpty(this._Utility_Name))
				db.AddInParameter(dbCommand, "Utility_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Utility_Name", DbType.String, this._Utility_Name);
			
			if (string.IsNullOrEmpty(this._Telephone))
				db.AddInParameter(dbCommand, "Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Telephone", DbType.String, this._Telephone);
			
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
			
			db.AddInParameter(dbCommand, "Contact_Start_Date", DbType.DateTime, this._Contact_Start_Date);
			
			db.AddInParameter(dbCommand, "Contact_End_Date", DbType.DateTime, this._Contact_End_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the PM_SI_Utility_Provider table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_SI_Utility_Provider)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_SI_Utility_ProviderDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_SI_Utility_Provider", DbType.Decimal, pK_PM_SI_Utility_Provider);

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
            DbCommand dbCommand = db.GetStoredProcCommand("PM_SI_Utility_ProviderSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the PM_SI_Utility_Provider table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetAuditView(decimal pK_PM_SI_Utility_Provider)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_SI_Utility_Provider_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_SI_Utility_Provider", DbType.Decimal, pK_PM_SI_Utility_Provider);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
