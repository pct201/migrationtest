using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Waste_Hauler table.
	/// </summary>
	public sealed class PM_Waste_Hauler
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Waste_Hauler;
		private decimal? _FK_PM_Site_Information;
		private string _Waste_Hauler_Name;
		private string _Address_1;
		private string _Address_2;
		private string _City;
		private decimal? _FK_State;
		private string _Zip_Code;
		private string _Contact_Name;
		private string _Contact_Telephone;
		private string _EPA_ID_Number;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private string _State_Registration;
        private string _Certification_On_File;
        private string _Apply_To_Location;
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Waste_Hauler value.
		/// </summary>
		public decimal? PK_PM_Waste_Hauler
		{
			get { return _PK_PM_Waste_Hauler; }
			set { _PK_PM_Waste_Hauler = value; }
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
		/// Gets or sets the Waste_Hauler_Name value.
		/// </summary>
		public string Waste_Hauler_Name
		{
			get { return _Waste_Hauler_Name; }
			set { _Waste_Hauler_Name = value; }
		}

        public string State_Registration
        {
            get { return _State_Registration; }
            set { _State_Registration = value; }
        }

        public string Certification_On_File
        {
            get { return _Certification_On_File; }
            set { _Certification_On_File = value; }
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
		/// Gets or sets the Contact_Name value.
		/// </summary>
		public string Contact_Name
		{
			get { return _Contact_Name; }
			set { _Contact_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Contact_Telephone value.
		/// </summary>
		public string Contact_Telephone
		{
			get { return _Contact_Telephone; }
			set { _Contact_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the EPA_ID_Number value.
		/// </summary>
		public string EPA_ID_Number
		{
			get { return _EPA_ID_Number; }
			set { _EPA_ID_Number = value; }
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

        public string Apply_To_Location
        {
            get { return _Apply_To_Location; }
            set { _Apply_To_Location = value; }
        }
		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Waste_Hauler class with default value.
		/// </summary>
		public PM_Waste_Hauler() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Waste_Hauler class based on Primary Key.
		/// </summary>
        public PM_Waste_Hauler(decimal pK_PM_Waste_Hauler) 
		{
			DataTable dtPM_Waste_Hauler = SelectByPK(pK_PM_Waste_Hauler).Tables[0];

			if (dtPM_Waste_Hauler.Rows.Count == 1)
			{
				 SetValue(dtPM_Waste_Hauler.Rows[0]);
			}
		}


		/// <summary>
		/// Initializes a new instance of the clsPM_Waste_Hauler class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Waste_Hauler) 
		{
				if (drPM_Waste_Hauler["PK_PM_Waste_Hauler"] == DBNull.Value)
					this._PK_PM_Waste_Hauler = null;
				else
					this._PK_PM_Waste_Hauler = (decimal?)drPM_Waste_Hauler["PK_PM_Waste_Hauler"];

				if (drPM_Waste_Hauler["FK_PM_Site_Information"] == DBNull.Value)
					this._FK_PM_Site_Information = null;
				else
					this._FK_PM_Site_Information = (decimal?)drPM_Waste_Hauler["FK_PM_Site_Information"];

				if (drPM_Waste_Hauler["Waste_Hauler_Name"] == DBNull.Value)
					this._Waste_Hauler_Name = null;
				else
					this._Waste_Hauler_Name = (string)drPM_Waste_Hauler["Waste_Hauler_Name"];

				if (drPM_Waste_Hauler["Address_1"] == DBNull.Value)
					this._Address_1 = null;
				else
					this._Address_1 = (string)drPM_Waste_Hauler["Address_1"];

				if (drPM_Waste_Hauler["Address_2"] == DBNull.Value)
					this._Address_2 = null;
				else
					this._Address_2 = (string)drPM_Waste_Hauler["Address_2"];

				if (drPM_Waste_Hauler["City"] == DBNull.Value)
					this._City = null;
				else
					this._City = (string)drPM_Waste_Hauler["City"];

				if (drPM_Waste_Hauler["FK_State"] == DBNull.Value)
					this._FK_State = null;
				else
					this._FK_State = (decimal?)drPM_Waste_Hauler["FK_State"];

				if (drPM_Waste_Hauler["Zip_Code"] == DBNull.Value)
					this._Zip_Code = null;
				else
					this._Zip_Code = (string)drPM_Waste_Hauler["Zip_Code"];

				if (drPM_Waste_Hauler["Contact_Name"] == DBNull.Value)
					this._Contact_Name = null;
				else
					this._Contact_Name = (string)drPM_Waste_Hauler["Contact_Name"];

				if (drPM_Waste_Hauler["Contact_Telephone"] == DBNull.Value)
					this._Contact_Telephone = null;
				else
					this._Contact_Telephone = (string)drPM_Waste_Hauler["Contact_Telephone"];

				if (drPM_Waste_Hauler["EPA_ID_Number"] == DBNull.Value)
					this._EPA_ID_Number = null;
				else
					this._EPA_ID_Number = (string)drPM_Waste_Hauler["EPA_ID_Number"];

				if (drPM_Waste_Hauler["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Waste_Hauler["Updated_By"];

				if (drPM_Waste_Hauler["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Waste_Hauler["Update_Date"];

                if (drPM_Waste_Hauler["State_Registration"] == DBNull.Value)
                    this._State_Registration = null;
                else
                    this._State_Registration = (string)drPM_Waste_Hauler["State_Registration"];

                if (drPM_Waste_Hauler["Certification_On_File"] == DBNull.Value)
                    this._Certification_On_File = null;
                else
                    this._Certification_On_File = (string)drPM_Waste_Hauler["Certification_On_File"];

                if (drPM_Waste_Hauler["Apply_To_Location"] == DBNull.Value)
                    this._Apply_To_Location = null;
                else
                    this._Apply_To_Location = (string)drPM_Waste_Hauler["Apply_To_Location"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Waste_Hauler table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Waste_HaulerInsert");
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			if (string.IsNullOrEmpty(this._Waste_Hauler_Name))
				db.AddInParameter(dbCommand, "Waste_Hauler_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Waste_Hauler_Name", DbType.String, this._Waste_Hauler_Name);
			
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
			
			if (string.IsNullOrEmpty(this._Contact_Name))
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
			
			if (string.IsNullOrEmpty(this._Contact_Telephone))
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, this._Contact_Telephone);
			
			if (string.IsNullOrEmpty(this._EPA_ID_Number))
				db.AddInParameter(dbCommand, "EPA_ID_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "EPA_ID_Number", DbType.String, this._EPA_ID_Number);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._State_Registration))
                db.AddInParameter(dbCommand, "State_Registration", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "State_Registration", DbType.String, this._State_Registration);

            if (string.IsNullOrEmpty(this._Certification_On_File))
                db.AddInParameter(dbCommand, "Certification_On_File", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Certification_On_File", DbType.String, this._Certification_On_File);

            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_Waste_Hauler table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Waste_Hauler)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Waste_HaulerSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Waste_Hauler", DbType.Decimal, pK_PM_Waste_Hauler);

			return db.ExecuteDataSet(dbCommand);
		}

        public static DataSet SelectByFK_SiteInfo(decimal fK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Waste_HaulerSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the PM_Waste_Hauler table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Waste_HaulerSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Waste_Hauler table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Waste_HaulerUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Waste_Hauler", DbType.Decimal, this._PK_PM_Waste_Hauler);
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			if (string.IsNullOrEmpty(this._Waste_Hauler_Name))
				db.AddInParameter(dbCommand, "Waste_Hauler_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Waste_Hauler_Name", DbType.String, this._Waste_Hauler_Name);
			
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
			
			if (string.IsNullOrEmpty(this._Contact_Name))
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
			
			if (string.IsNullOrEmpty(this._Contact_Telephone))
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, this._Contact_Telephone);
			
			if (string.IsNullOrEmpty(this._EPA_ID_Number))
				db.AddInParameter(dbCommand, "EPA_ID_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "EPA_ID_Number", DbType.String, this._EPA_ID_Number);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._State_Registration))
                db.AddInParameter(dbCommand, "State_Registration", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "State_Registration", DbType.String, this._State_Registration);

            if (string.IsNullOrEmpty(this._Certification_On_File))
                db.AddInParameter(dbCommand, "Certification_On_File", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Certification_On_File", DbType.String, this._Certification_On_File);

            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the PM_Waste_Hauler table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Waste_Hauler)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Waste_HaulerDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Waste_Hauler", DbType.Decimal, pK_PM_Waste_Hauler);

			db.ExecuteNonQuery(dbCommand);
		}
        
        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_Waste_Hauler)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Waste_Hauler_AuditView");

            db.AddInParameter(dbCommand, "pK_PM_Waste_Hauler", DbType.Decimal, pK_PM_Waste_Hauler);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
