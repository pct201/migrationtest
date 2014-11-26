using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Equipment_OWS table.
	/// </summary>
	public sealed class clsPM_Equipment_OWS
	{
		#region Private variables used to hold the property values

		private decimal? _PK_PM_Equipment_OWS;
		private string _Description;
        private string _Connected_to_Public_Water_Application;
		private DateTime? _Installation_Date;
		private string _Manufacturer_Name;
		private string _Inspection_Company;
		private string _Inspection_Company_Contact_Name;
		private string _Inspection_Company_Contact_Telephone;
		private string _Notes;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private decimal? _PK_PM_Equipment;
       
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Equipment_OWS value.
		/// </summary>
		public decimal? PK_PM_Equipment_OWS
		{
			get { return _PK_PM_Equipment_OWS; }
			set { _PK_PM_Equipment_OWS = value; }
		}

		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		/// <summary>
		/// Gets or sets the Installation_Date value.
		/// </summary>
		public DateTime? Installation_Date
		{
			get { return _Installation_Date; }
			set { _Installation_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Manufacturer_Name value.
		/// </summary>
		public string Manufacturer_Name
		{
			get { return _Manufacturer_Name; }
			set { _Manufacturer_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Inspection_Company value.
		/// </summary>
		public string Inspection_Company
		{
			get { return _Inspection_Company; }
			set { _Inspection_Company = value; }
		}

		/// <summary>
		/// Gets or sets the Inspection_Company_Contact_Name value.
		/// </summary>
		public string Inspection_Company_Contact_Name
		{
			get { return _Inspection_Company_Contact_Name; }
			set { _Inspection_Company_Contact_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Inspection_Company_Contact_Telephone value.
		/// </summary>
		public string Inspection_Company_Contact_Telephone
		{
			get { return _Inspection_Company_Contact_Telephone; }
			set { _Inspection_Company_Contact_Telephone = value; }
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

        /// <summary>
        /// Gets or sets the Manufacturer_Name value.
        /// </summary>
        public string Connected_to_Public_Water_Application
        {
            get { return _Connected_to_Public_Water_Application; }
            set { _Connected_to_Public_Water_Application = value; }
        }
        /// <summary>
        /// Gets or sets the PM_Equipment value.
        /// </summary>
        public decimal? PK_PM_Equipment
        {
            get { return _PK_PM_Equipment; }
            set { _PK_PM_Equipment = value; }
        }

       
      
		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_OWS class with default value.
		/// </summary>
		public clsPM_Equipment_OWS() 
		{
		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_OWS class based on Primary Key.
		/// </summary>
		public clsPM_Equipment_OWS(decimal pK_PM_Equipment_OWS) 
		{
			DataTable dtPM_Equipment_OWS = SelectByPK(pK_PM_Equipment_OWS).Tables[0];

			if (dtPM_Equipment_OWS.Rows.Count == 1)
			{
				 SetValue(dtPM_Equipment_OWS.Rows[0]);
			}
		}

		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_OWS class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Equipment_OWS) 
		{
				if (drPM_Equipment_OWS["PK_PM_Equipment_OWS"] == DBNull.Value)
					this._PK_PM_Equipment_OWS = null;
				else
					this._PK_PM_Equipment_OWS = (decimal?)drPM_Equipment_OWS["PK_PM_Equipment_OWS"];

				if (drPM_Equipment_OWS["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drPM_Equipment_OWS["Description"];

				if (drPM_Equipment_OWS["Installation_Date"] == DBNull.Value)
					this._Installation_Date = null;
				else
					this._Installation_Date = (DateTime?)drPM_Equipment_OWS["Installation_Date"];

				if (drPM_Equipment_OWS["Manufacturer_Name"] == DBNull.Value)
					this._Manufacturer_Name = null;
				else
					this._Manufacturer_Name = (string)drPM_Equipment_OWS["Manufacturer_Name"];

				if (drPM_Equipment_OWS["Inspection_Company"] == DBNull.Value)
					this._Inspection_Company = null;
				else
					this._Inspection_Company = (string)drPM_Equipment_OWS["Inspection_Company"];

				if (drPM_Equipment_OWS["Inspection_Company_Contact_Name"] == DBNull.Value)
					this._Inspection_Company_Contact_Name = null;
				else
					this._Inspection_Company_Contact_Name = (string)drPM_Equipment_OWS["Inspection_Company_Contact_Name"];

				if (drPM_Equipment_OWS["Inspection_Company_Contact_Telephone"] == DBNull.Value)
					this._Inspection_Company_Contact_Telephone = null;
				else
					this._Inspection_Company_Contact_Telephone = (string)drPM_Equipment_OWS["Inspection_Company_Contact_Telephone"];

				if (drPM_Equipment_OWS["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drPM_Equipment_OWS["Notes"];

                if (drPM_Equipment_OWS["Connected_to_Public_Water_Application"] == DBNull.Value)
                    this._Connected_to_Public_Water_Application = null;
                else
                    this._Connected_to_Public_Water_Application = (string)drPM_Equipment_OWS["Connected_to_Public_Water_Application"];

				if (drPM_Equipment_OWS["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Equipment_OWS["Updated_By"];

				if (drPM_Equipment_OWS["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Equipment_OWS["Update_Date"];

                if (drPM_Equipment_OWS["PK_PM_Equipment"] == DBNull.Value)
                    this._PK_PM_Equipment = null;
                else
                    this._PK_PM_Equipment = (decimal?)drPM_Equipment_OWS["PK_PM_Equipment"];               
		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Equipment_OWS table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_OWSInsert");
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			db.AddInParameter(dbCommand, "Installation_Date", DbType.DateTime, this._Installation_Date);
			
			if (string.IsNullOrEmpty(this._Manufacturer_Name))
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, this._Manufacturer_Name);
			
			if (string.IsNullOrEmpty(this._Inspection_Company))
				db.AddInParameter(dbCommand, "Inspection_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Inspection_Company", DbType.String, this._Inspection_Company);
			
			if (string.IsNullOrEmpty(this._Inspection_Company_Contact_Name))
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Name", DbType.String, this._Inspection_Company_Contact_Name);
			
			if (string.IsNullOrEmpty(this._Inspection_Company_Contact_Telephone))
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Telephone", DbType.String, this._Inspection_Company_Contact_Telephone);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);

            if (string.IsNullOrEmpty(this._Connected_to_Public_Water_Application))
                db.AddInParameter(dbCommand, "Connected_to_Public_Water_Application", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Connected_to_Public_Water_Application", DbType.String, this._Connected_to_Public_Water_Application);

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
		/// Selects a single record from the PM_Equipment_OWS table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Equipment_OWS)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_OWSSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Equipment_OWS", DbType.Decimal, pK_PM_Equipment_OWS);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Equipment_OWS table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_OWSSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Equipment_OWS table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_OWSUpdate");
			
			db.AddInParameter(dbCommand, "PK_PM_Equipment_OWS", DbType.Decimal, this._PK_PM_Equipment_OWS);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			db.AddInParameter(dbCommand, "Installation_Date", DbType.DateTime, this._Installation_Date);
			
			if (string.IsNullOrEmpty(this._Manufacturer_Name))
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, this._Manufacturer_Name);
			
			if (string.IsNullOrEmpty(this._Inspection_Company))
				db.AddInParameter(dbCommand, "Inspection_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Inspection_Company", DbType.String, this._Inspection_Company);
			
			if (string.IsNullOrEmpty(this._Inspection_Company_Contact_Name))
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Name", DbType.String, this._Inspection_Company_Contact_Name);
			
			if (string.IsNullOrEmpty(this._Inspection_Company_Contact_Telephone))
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Telephone", DbType.String, this._Inspection_Company_Contact_Telephone);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            if (string.IsNullOrEmpty(this._Connected_to_Public_Water_Application))
                db.AddInParameter(dbCommand, "Connected_to_Public_Water_Application", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Connected_to_Public_Water_Application", DbType.String, this._Connected_to_Public_Water_Application);

			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
                        
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Equipment_OWS table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Equipment_OWS)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_OWSDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Equipment_OWS", DbType.Decimal, pK_PM_Equipment_OWS);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_Equipment_OWS)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_OWS_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_Equipment_OWS", DbType.Decimal, pK_PM_Equipment_OWS);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
