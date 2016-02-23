using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table PM_Hearing_Conservation
	/// </summary>
	public sealed class PM_Hearing_Conservation
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Hearing_Conservation;
		private decimal? _FK_PM_Site_Information;
		private DateTime? _Date_Of_Test;
		private decimal? _FK_LU_Employee;
		private decimal? _FK_LU_Hearing_Conservation_Test_Type;
		private string _Location_Exceed_Noise_Level;
		private string _STS_Shift;
		private string _Retest_Scheduled;
		private DateTime? _Rested_Date;
		private string _Notes;
		private string _Vendor;
		private string _Vendor_Representative;
		private string _Vendor_Address;
		private string _Vendor_City;
		private decimal? _FK_Vendor_State;
		private string _Vendor_Zip_Code;
		private string _Vendor_Telephone;
		private string _Vendor_EMail;
		private DateTime? _Update_Date;
		private string _Updated_By;
        private string _BuildingId;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Hearing_Conservation value.
		/// </summary>
		public decimal? PK_PM_Hearing_Conservation
		{
			get { return _PK_PM_Hearing_Conservation; }
			set { _PK_PM_Hearing_Conservation = value; }
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
		/// Gets or sets the Date_Of_Test value.
		/// </summary>
		public DateTime? Date_Of_Test
		{
			get { return _Date_Of_Test; }
			set { _Date_Of_Test = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Employee value.
		/// </summary>
		public decimal? FK_LU_Employee
		{
			get { return _FK_LU_Employee; }
			set { _FK_LU_Employee = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Hearing_Conservation_Test_Type value.
		/// </summary>
		public decimal? FK_LU_Hearing_Conservation_Test_Type
		{
			get { return _FK_LU_Hearing_Conservation_Test_Type; }
			set { _FK_LU_Hearing_Conservation_Test_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Location_Exceed_Noise_Level value.
		/// </summary>
		public string Location_Exceed_Noise_Level
		{
			get { return _Location_Exceed_Noise_Level; }
			set { _Location_Exceed_Noise_Level = value; }
		}

		/// <summary>
		/// Gets or sets the STS_Shift value.
		/// </summary>
		public string STS_Shift
		{
			get { return _STS_Shift; }
			set { _STS_Shift = value; }
		}

		/// <summary>
		/// Gets or sets the Retest_Scheduled value.
		/// </summary>
		public string Retest_Scheduled
		{
			get { return _Retest_Scheduled; }
			set { _Retest_Scheduled = value; }
		}

		/// <summary>
		/// Gets or sets the Rested_Date value.
		/// </summary>
		public DateTime? Rested_Date
		{
			get { return _Rested_Date; }
			set { _Rested_Date = value; }
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
		/// Gets or sets the Vendor value.
		/// </summary>
		public string Vendor
		{
			get { return _Vendor; }
			set { _Vendor = value; }
		}

		/// <summary>
		/// Gets or sets the Vendor_Representative value.
		/// </summary>
		public string Vendor_Representative
		{
			get { return _Vendor_Representative; }
			set { _Vendor_Representative = value; }
		}

		/// <summary>
		/// Gets or sets the Vendor_Address value.
		/// </summary>
		public string Vendor_Address
		{
			get { return _Vendor_Address; }
			set { _Vendor_Address = value; }
		}

		/// <summary>
		/// Gets or sets the Vendor_City value.
		/// </summary>
		public string Vendor_City
		{
			get { return _Vendor_City; }
			set { _Vendor_City = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Vendor_State value.
		/// </summary>
		public decimal? FK_Vendor_State
		{
			get { return _FK_Vendor_State; }
			set { _FK_Vendor_State = value; }
		}

		/// <summary>
		/// Gets or sets the Vendor_Zip_Code value.
		/// </summary>
		public string Vendor_Zip_Code
		{
			get { return _Vendor_Zip_Code; }
			set { _Vendor_Zip_Code = value; }
		}

		/// <summary>
		/// Gets or sets the Vendor_Telephone value.
		/// </summary>
		public string Vendor_Telephone
		{
			get { return _Vendor_Telephone; }
			set { _Vendor_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the Vendor_EMail value.
		/// </summary>
		public string Vendor_EMail
		{
			get { return _Vendor_EMail; }
			set { _Vendor_EMail = value; }
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
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}

        public string BuildingId
        {
            get { return _BuildingId;}
            set { _BuildingId = value; }
        }


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the PM_Hearing_Conservation class with default value.
		/// </summary>
		public PM_Hearing_Conservation() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the PM_Hearing_Conservation class based on Primary Key.
		/// </summary>
		public PM_Hearing_Conservation(decimal pK_PM_Hearing_Conservation) 
		{
			DataTable dtPM_Hearing_Conservation = Select(pK_PM_Hearing_Conservation).Tables[0];

			if (dtPM_Hearing_Conservation.Rows.Count == 1)
			{
				 SetValue(dtPM_Hearing_Conservation.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the PM_Hearing_Conservation class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Hearing_Conservation) 
		{
				if (drPM_Hearing_Conservation["PK_PM_Hearing_Conservation"] == DBNull.Value)
					this._PK_PM_Hearing_Conservation = null;
				else
					this._PK_PM_Hearing_Conservation = (decimal?)drPM_Hearing_Conservation["PK_PM_Hearing_Conservation"];

				if (drPM_Hearing_Conservation["FK_PM_Site_Information"] == DBNull.Value)
					this._FK_PM_Site_Information = null;
				else
					this._FK_PM_Site_Information = (decimal?)drPM_Hearing_Conservation["FK_PM_Site_Information"];

				if (drPM_Hearing_Conservation["Date_Of_Test"] == DBNull.Value)
					this._Date_Of_Test = null;
				else
					this._Date_Of_Test = (DateTime?)drPM_Hearing_Conservation["Date_Of_Test"];

				if (drPM_Hearing_Conservation["FK_LU_Employee"] == DBNull.Value)
					this._FK_LU_Employee = null;
				else
					this._FK_LU_Employee = (decimal?)drPM_Hearing_Conservation["FK_LU_Employee"];

				if (drPM_Hearing_Conservation["FK_LU_Hearing_Conservation_Test_Type"] == DBNull.Value)
					this._FK_LU_Hearing_Conservation_Test_Type = null;
				else
					this._FK_LU_Hearing_Conservation_Test_Type = (decimal?)drPM_Hearing_Conservation["FK_LU_Hearing_Conservation_Test_Type"];

				if (drPM_Hearing_Conservation["Location_Exceed_Noise_Level"] == DBNull.Value)
					this._Location_Exceed_Noise_Level = null;
				else
					this._Location_Exceed_Noise_Level = (string)drPM_Hearing_Conservation["Location_Exceed_Noise_Level"];

				if (drPM_Hearing_Conservation["STS_Shift"] == DBNull.Value)
					this._STS_Shift = null;
				else
					this._STS_Shift = (string)drPM_Hearing_Conservation["STS_Shift"];

				if (drPM_Hearing_Conservation["Retest_Scheduled"] == DBNull.Value)
					this._Retest_Scheduled = null;
				else
					this._Retest_Scheduled = (string)drPM_Hearing_Conservation["Retest_Scheduled"];

				if (drPM_Hearing_Conservation["Rested_Date"] == DBNull.Value)
					this._Rested_Date = null;
				else
					this._Rested_Date = (DateTime?)drPM_Hearing_Conservation["Rested_Date"];

				if (drPM_Hearing_Conservation["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drPM_Hearing_Conservation["Notes"];

				if (drPM_Hearing_Conservation["Vendor"] == DBNull.Value)
					this._Vendor = null;
				else
					this._Vendor = (string)drPM_Hearing_Conservation["Vendor"];

				if (drPM_Hearing_Conservation["Vendor_Representative"] == DBNull.Value)
					this._Vendor_Representative = null;
				else
					this._Vendor_Representative = (string)drPM_Hearing_Conservation["Vendor_Representative"];

				if (drPM_Hearing_Conservation["Vendor_Address"] == DBNull.Value)
					this._Vendor_Address = null;
				else
					this._Vendor_Address = (string)drPM_Hearing_Conservation["Vendor_Address"];

				if (drPM_Hearing_Conservation["Vendor_City"] == DBNull.Value)
					this._Vendor_City = null;
				else
					this._Vendor_City = (string)drPM_Hearing_Conservation["Vendor_City"];

				if (drPM_Hearing_Conservation["FK_Vendor_State"] == DBNull.Value)
					this._FK_Vendor_State = null;
				else
					this._FK_Vendor_State = (decimal?)drPM_Hearing_Conservation["FK_Vendor_State"];

				if (drPM_Hearing_Conservation["Vendor_Zip_Code"] == DBNull.Value)
					this._Vendor_Zip_Code = null;
				else
					this._Vendor_Zip_Code = (string)drPM_Hearing_Conservation["Vendor_Zip_Code"];

				if (drPM_Hearing_Conservation["Vendor_Telephone"] == DBNull.Value)
					this._Vendor_Telephone = null;
				else
					this._Vendor_Telephone = (string)drPM_Hearing_Conservation["Vendor_Telephone"];

				if (drPM_Hearing_Conservation["Vendor_EMail"] == DBNull.Value)
					this._Vendor_EMail = null;
				else
					this._Vendor_EMail = (string)drPM_Hearing_Conservation["Vendor_EMail"];

				if (drPM_Hearing_Conservation["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Hearing_Conservation["Update_Date"];

				if (drPM_Hearing_Conservation["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Hearing_Conservation["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Hearing_Conservation table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Hearing_ConservationInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "Date_Of_Test", DbType.DateTime, this._Date_Of_Test);
			
			db.AddInParameter(dbCommand, "FK_LU_Employee", DbType.Decimal, this._FK_LU_Employee);
			
			db.AddInParameter(dbCommand, "FK_LU_Hearing_Conservation_Test_Type", DbType.Decimal, this._FK_LU_Hearing_Conservation_Test_Type);
			
			if (string.IsNullOrEmpty(this._Location_Exceed_Noise_Level))
				db.AddInParameter(dbCommand, "Location_Exceed_Noise_Level", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Location_Exceed_Noise_Level", DbType.String, this._Location_Exceed_Noise_Level);
			
			if (string.IsNullOrEmpty(this._STS_Shift))
				db.AddInParameter(dbCommand, "STS_Shift", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "STS_Shift", DbType.String, this._STS_Shift);
			
			if (string.IsNullOrEmpty(this._Retest_Scheduled))
				db.AddInParameter(dbCommand, "Retest_Scheduled", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Retest_Scheduled", DbType.String, this._Retest_Scheduled);
			
			db.AddInParameter(dbCommand, "Rested_Date", DbType.DateTime, this._Rested_Date);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Vendor))
				db.AddInParameter(dbCommand, "Vendor", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor", DbType.String, this._Vendor);
			
			if (string.IsNullOrEmpty(this._Vendor_Representative))
				db.AddInParameter(dbCommand, "Vendor_Representative", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Representative", DbType.String, this._Vendor_Representative);
			
			if (string.IsNullOrEmpty(this._Vendor_Address))
				db.AddInParameter(dbCommand, "Vendor_Address", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Address", DbType.String, this._Vendor_Address);
			
			if (string.IsNullOrEmpty(this._Vendor_City))
				db.AddInParameter(dbCommand, "Vendor_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_City", DbType.String, this._Vendor_City);
			
			db.AddInParameter(dbCommand, "FK_Vendor_State", DbType.Decimal, this._FK_Vendor_State);
			
			if (string.IsNullOrEmpty(this._Vendor_Zip_Code))
				db.AddInParameter(dbCommand, "Vendor_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Zip_Code", DbType.String, this._Vendor_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Vendor_Telephone))
				db.AddInParameter(dbCommand, "Vendor_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Telephone", DbType.String, this._Vendor_Telephone);
			
			if (string.IsNullOrEmpty(this._Vendor_EMail))
				db.AddInParameter(dbCommand, "Vendor_EMail", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_EMail", DbType.String, this._Vendor_EMail);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_Hearing_Conservation table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_PM_Hearing_Conservation)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Hearing_ConservationSelect");

			db.AddInParameter(dbCommand, "PK_PM_Hearing_Conservation", DbType.Decimal, pK_PM_Hearing_Conservation);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Hearing_Conservation table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Hearing_ConservationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Hearing_Conservation table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Hearing_ConservationUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Hearing_Conservation", DbType.Decimal, this._PK_PM_Hearing_Conservation);
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "Date_Of_Test", DbType.DateTime, this._Date_Of_Test);
			
			db.AddInParameter(dbCommand, "FK_LU_Employee", DbType.Decimal, this._FK_LU_Employee);
			
			db.AddInParameter(dbCommand, "FK_LU_Hearing_Conservation_Test_Type", DbType.Decimal, this._FK_LU_Hearing_Conservation_Test_Type);
			
			if (string.IsNullOrEmpty(this._Location_Exceed_Noise_Level))
				db.AddInParameter(dbCommand, "Location_Exceed_Noise_Level", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Location_Exceed_Noise_Level", DbType.String, this._Location_Exceed_Noise_Level);
			
			if (string.IsNullOrEmpty(this._STS_Shift))
				db.AddInParameter(dbCommand, "STS_Shift", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "STS_Shift", DbType.String, this._STS_Shift);
			
			if (string.IsNullOrEmpty(this._Retest_Scheduled))
				db.AddInParameter(dbCommand, "Retest_Scheduled", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Retest_Scheduled", DbType.String, this._Retest_Scheduled);
			
			db.AddInParameter(dbCommand, "Rested_Date", DbType.DateTime, this._Rested_Date);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Vendor))
				db.AddInParameter(dbCommand, "Vendor", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor", DbType.String, this._Vendor);
			
			if (string.IsNullOrEmpty(this._Vendor_Representative))
				db.AddInParameter(dbCommand, "Vendor_Representative", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Representative", DbType.String, this._Vendor_Representative);
			
			if (string.IsNullOrEmpty(this._Vendor_Address))
				db.AddInParameter(dbCommand, "Vendor_Address", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Address", DbType.String, this._Vendor_Address);
			
			if (string.IsNullOrEmpty(this._Vendor_City))
				db.AddInParameter(dbCommand, "Vendor_City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_City", DbType.String, this._Vendor_City);
			
			db.AddInParameter(dbCommand, "FK_Vendor_State", DbType.Decimal, this._FK_Vendor_State);
			
			if (string.IsNullOrEmpty(this._Vendor_Zip_Code))
				db.AddInParameter(dbCommand, "Vendor_Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Zip_Code", DbType.String, this._Vendor_Zip_Code);
			
			if (string.IsNullOrEmpty(this._Vendor_Telephone))
				db.AddInParameter(dbCommand, "Vendor_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Telephone", DbType.String, this._Vendor_Telephone);

            //if (string.IsNullOrEmpty(this._BuildingId))
            //    db.AddInParameter(dbCommand, "BuildingId", DbType.String, DBNull.Value);
            //else
            //    db.AddInParameter(dbCommand, "BuildingId", DbType.String, this._BuildingId);
			
			if (string.IsNullOrEmpty(this._Vendor_EMail))
				db.AddInParameter(dbCommand, "Vendor_EMail", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_EMail", DbType.String, this._Vendor_EMail);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the PM_Hearing_Conservation table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_PM_Hearing_Conservation)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Hearing_ConservationDelete");

			db.AddInParameter(dbCommand, "PK_PM_Hearing_Conservation", DbType.Decimal, pK_PM_Hearing_Conservation);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the PM_Complaince_Reporting_OSHA table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal fK_PM_Complaince_Reporting)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Hearing_ConservationSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Complaince_Reporting);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
