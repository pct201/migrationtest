using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Waste_Removal table.
	/// </summary>
	public sealed class PM_Waste_Removal
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Waste_Removal;
		private decimal? _FK_PM_Site_Information;
		private decimal? _FK_LU_Waste_Type;
		private decimal? _FK_PM_Waste_Hauler;
		private decimal? _FK_Receiving_TSDF;
		private decimal? _Amount_HW_Generated_Per_Month;
		private string _Units;
		private DateTime? _Date;
		private string _Constituents_Of_Concern;
		private string _Removal_Limits;
		private string _HW_Profile_Complete_And_Maintained;
		private decimal? _FK_LU_Facility_Generator_Status;
		private string _Discharge_Limits;
		private string _California_Business_Plan;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private decimal? _FK_LU_PM_Hazardous_Waste_Codes;
        private DateTime? _HW_Accumulation_Start;
        private DateTime? _Last_HW_Removal;
        private string _Apply_To_Location;
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Waste_Removal value.
		/// </summary>
		public decimal? PK_PM_Waste_Removal
		{
			get { return _PK_PM_Waste_Removal; }
			set { _PK_PM_Waste_Removal = value; }
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
		/// Gets or sets the FK_LU_Waste_Type value.
		/// </summary>
		public decimal? FK_LU_Waste_Type
		{
			get { return _FK_LU_Waste_Type; }
			set { _FK_LU_Waste_Type = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_Waste_Hauler value.
		/// </summary>
		public decimal? FK_PM_Waste_Hauler
		{
			get { return _FK_PM_Waste_Hauler; }
			set { _FK_PM_Waste_Hauler = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Receiving_TSDF value.
		/// </summary>
		public decimal? FK_Receiving_TSDF
		{
			get { return _FK_Receiving_TSDF; }
			set { _FK_Receiving_TSDF = value; }
		}

		/// <summary>
		/// Gets or sets the Amount_HW_Generated_Per_Month value.
		/// </summary>
		public decimal? Amount_HW_Generated_Per_Month
		{
			get { return _Amount_HW_Generated_Per_Month; }
			set { _Amount_HW_Generated_Per_Month = value; }
		}

		/// <summary>
		/// Gets or sets the Units value.
		/// </summary>
		public string Units
		{
			get { return _Units; }
			set { _Units = value; }
		}

		/// <summary>
		/// Gets or sets the Date value.
		/// </summary>
		public DateTime? Date
		{
			get { return _Date; }
			set { _Date = value; }
		}

		/// <summary>
		/// Gets or sets the Constituents_Of_Concern value.
		/// </summary>
		public string Constituents_Of_Concern
		{
			get { return _Constituents_Of_Concern; }
			set { _Constituents_Of_Concern = value; }
		}

		/// <summary>
		/// Gets or sets the Removal_Limits value.
		/// </summary>
		public string Removal_Limits
		{
			get { return _Removal_Limits; }
			set { _Removal_Limits = value; }
		}

		/// <summary>
		/// Gets or sets the HW_Profile_Complete_And_Maintained value.
		/// </summary>
		public string HW_Profile_Complete_And_Maintained
		{
			get { return _HW_Profile_Complete_And_Maintained; }
			set { _HW_Profile_Complete_And_Maintained = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Facility_Generator_Status value.
		/// </summary>
		public decimal? FK_LU_Facility_Generator_Status
		{
			get { return _FK_LU_Facility_Generator_Status; }
			set { _FK_LU_Facility_Generator_Status = value; }
		}

		/// <summary>
		/// Gets or sets the Discharge_Limits value.
		/// </summary>
		public string Discharge_Limits
		{
			get { return _Discharge_Limits; }
			set { _Discharge_Limits = value; }
		}

		/// <summary>
		/// Gets or sets the California_Business_Plan value.
		/// </summary>
		public string California_Business_Plan
		{
			get { return _California_Business_Plan; }
			set { _California_Business_Plan = value; }
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

        public decimal? FK_LU_PM_Hazardous_Waste_Codes
        {
            get { return _FK_LU_PM_Hazardous_Waste_Codes; }
            set { _FK_LU_PM_Hazardous_Waste_Codes = value; }
        }

        public DateTime? HW_Accumulation_Start
        {
            get { return _HW_Accumulation_Start; }
            set { _HW_Accumulation_Start = value; }
        }

        public DateTime? Last_HW_Removal
        {
            get { return _Last_HW_Removal; }
            set { _Last_HW_Removal = value; }
        }

        public string Apply_To_Location
        {
            get { return _Apply_To_Location; }
            set { _Apply_To_Location = value; }
        }
		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Waste_Removal class with default value.
		/// </summary>
		public PM_Waste_Removal() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Waste_Removal class based on Primary Key.
		/// </summary>
		public PM_Waste_Removal(decimal pK_PM_Waste_Removal) 
		{
			DataTable dtPM_Waste_Removal = SelectByPK(pK_PM_Waste_Removal).Tables[0];

			if (dtPM_Waste_Removal.Rows.Count == 1)
			{
				 SetValue(dtPM_Waste_Removal.Rows[0]);
			}
		}

		/// <summary>
		/// Initializes a new instance of the clsPM_Waste_Removal class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Waste_Removal) 
		{
				if (drPM_Waste_Removal["PK_PM_Waste_Removal"] == DBNull.Value)
					this._PK_PM_Waste_Removal = null;
				else
					this._PK_PM_Waste_Removal = (decimal?)drPM_Waste_Removal["PK_PM_Waste_Removal"];

				if (drPM_Waste_Removal["FK_PM_Site_Information"] == DBNull.Value)
					this._FK_PM_Site_Information = null;
				else
					this._FK_PM_Site_Information = (decimal?)drPM_Waste_Removal["FK_PM_Site_Information"];

				if (drPM_Waste_Removal["FK_LU_Waste_Type"] == DBNull.Value)
					this._FK_LU_Waste_Type = null;
				else
					this._FK_LU_Waste_Type = (decimal?)drPM_Waste_Removal["FK_LU_Waste_Type"];

				if (drPM_Waste_Removal["FK_PM_Waste_Hauler"] == DBNull.Value)
					this._FK_PM_Waste_Hauler = null;
				else
					this._FK_PM_Waste_Hauler = (decimal?)drPM_Waste_Removal["FK_PM_Waste_Hauler"];

				if (drPM_Waste_Removal["FK_Receiving_TSDF"] == DBNull.Value)
					this._FK_Receiving_TSDF = null;
				else
					this._FK_Receiving_TSDF = (decimal?)drPM_Waste_Removal["FK_Receiving_TSDF"];

				if (drPM_Waste_Removal["Amount_HW_Generated_Per_Month"] == DBNull.Value)
					this._Amount_HW_Generated_Per_Month = null;
				else
					this._Amount_HW_Generated_Per_Month = (decimal?)drPM_Waste_Removal["Amount_HW_Generated_Per_Month"];

				if (drPM_Waste_Removal["Units"] == DBNull.Value)
					this._Units = null;
				else
					this._Units = (string)drPM_Waste_Removal["Units"];

				if (drPM_Waste_Removal["Date"] == DBNull.Value)
					this._Date = null;
				else
					this._Date = (DateTime?)drPM_Waste_Removal["Date"];

				if (drPM_Waste_Removal["Constituents_Of_Concern"] == DBNull.Value)
					this._Constituents_Of_Concern = null;
				else
					this._Constituents_Of_Concern = (string)drPM_Waste_Removal["Constituents_Of_Concern"];

				if (drPM_Waste_Removal["Removal_Limits"] == DBNull.Value)
					this._Removal_Limits = null;
				else
					this._Removal_Limits = (string)drPM_Waste_Removal["Removal_Limits"];

				if (drPM_Waste_Removal["HW_Profile_Complete_And_Maintained"] == DBNull.Value)
					this._HW_Profile_Complete_And_Maintained = null;
				else
					this._HW_Profile_Complete_And_Maintained = (string)drPM_Waste_Removal["HW_Profile_Complete_And_Maintained"];

				if (drPM_Waste_Removal["FK_LU_Facility_Generator_Status"] == DBNull.Value)
					this._FK_LU_Facility_Generator_Status = null;
				else
					this._FK_LU_Facility_Generator_Status = (decimal?)drPM_Waste_Removal["FK_LU_Facility_Generator_Status"];

				if (drPM_Waste_Removal["Discharge_Limits"] == DBNull.Value)
					this._Discharge_Limits = null;
				else
					this._Discharge_Limits = (string)drPM_Waste_Removal["Discharge_Limits"];

				if (drPM_Waste_Removal["California_Business_Plan"] == DBNull.Value)
					this._California_Business_Plan = null;
				else
					this._California_Business_Plan = (string)drPM_Waste_Removal["California_Business_Plan"];

				if (drPM_Waste_Removal["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Waste_Removal["Updated_By"];

				if (drPM_Waste_Removal["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Waste_Removal["Update_Date"];

                if (drPM_Waste_Removal["HW_Accumulation_Start"] == DBNull.Value)
                    this._HW_Accumulation_Start = null;
                else
                    this._HW_Accumulation_Start = (DateTime?)drPM_Waste_Removal["HW_Accumulation_Start"];

                if (drPM_Waste_Removal["Last_HW_Removal"] == DBNull.Value)
                    this._Last_HW_Removal = null;
                else
                    this._Last_HW_Removal = (DateTime?)drPM_Waste_Removal["Last_HW_Removal"];

                if (drPM_Waste_Removal["FK_LU_PM_Hazardous_Waste_Codes"] == DBNull.Value)
                    this._FK_LU_PM_Hazardous_Waste_Codes = null;
                else
                    this._FK_LU_PM_Hazardous_Waste_Codes = (decimal?)drPM_Waste_Removal["FK_LU_PM_Hazardous_Waste_Codes"];

                if (drPM_Waste_Removal["Apply_To_Location"] == DBNull.Value)
                    this._Apply_To_Location = null;
                else
                    this._Apply_To_Location = (string)drPM_Waste_Removal["Apply_To_Location"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Waste_Removal table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Waste_RemovalInsert");
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "FK_LU_Waste_Type", DbType.Decimal, this._FK_LU_Waste_Type);
			
			db.AddInParameter(dbCommand, "FK_PM_Waste_Hauler", DbType.Decimal, this._FK_PM_Waste_Hauler);
			
			db.AddInParameter(dbCommand, "FK_Receiving_TSDF", DbType.Decimal, this._FK_Receiving_TSDF);
			
			db.AddInParameter(dbCommand, "Amount_HW_Generated_Per_Month", DbType.Decimal, this._Amount_HW_Generated_Per_Month);
			
			if (string.IsNullOrEmpty(this._Units))
				db.AddInParameter(dbCommand, "Units", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Units", DbType.String, this._Units);
			
			db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
			
			if (string.IsNullOrEmpty(this._Constituents_Of_Concern))
				db.AddInParameter(dbCommand, "Constituents_Of_Concern", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Constituents_Of_Concern", DbType.String, this._Constituents_Of_Concern);
			
			if (string.IsNullOrEmpty(this._Removal_Limits))
				db.AddInParameter(dbCommand, "Removal_Limits", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Removal_Limits", DbType.String, this._Removal_Limits);
			
			if (string.IsNullOrEmpty(this._HW_Profile_Complete_And_Maintained))
				db.AddInParameter(dbCommand, "HW_Profile_Complete_And_Maintained", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "HW_Profile_Complete_And_Maintained", DbType.String, this._HW_Profile_Complete_And_Maintained);
			
			db.AddInParameter(dbCommand, "FK_LU_Facility_Generator_Status", DbType.Decimal, this._FK_LU_Facility_Generator_Status);
			
			if (string.IsNullOrEmpty(this._Discharge_Limits))
				db.AddInParameter(dbCommand, "Discharge_Limits", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Discharge_Limits", DbType.String, this._Discharge_Limits);
			
			if (string.IsNullOrEmpty(this._California_Business_Plan))
				db.AddInParameter(dbCommand, "California_Business_Plan", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "California_Business_Plan", DbType.String, this._California_Business_Plan);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "FK_LU_PM_Hazardous_Waste_Codes", DbType.Decimal, this._FK_LU_PM_Hazardous_Waste_Codes);
            db.AddInParameter(dbCommand, "HW_Accumulation_Start", DbType.DateTime, this._HW_Accumulation_Start);
            db.AddInParameter(dbCommand, "Last_HW_Removal", DbType.DateTime, this._Last_HW_Removal);

            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_Waste_Removal table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Waste_Removal)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Waste_RemovalSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Waste_Removal", DbType.Decimal, pK_PM_Waste_Removal);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Waste_Removal table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Waste_RemovalSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Waste_Removal table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Waste_RemovalUpdate");
			
			db.AddInParameter(dbCommand, "PK_PM_Waste_Removal", DbType.Decimal, this._PK_PM_Waste_Removal);
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "FK_LU_Waste_Type", DbType.Decimal, this._FK_LU_Waste_Type);
			
			db.AddInParameter(dbCommand, "FK_PM_Waste_Hauler", DbType.Decimal, this._FK_PM_Waste_Hauler);
			
			db.AddInParameter(dbCommand, "FK_Receiving_TSDF", DbType.Decimal, this._FK_Receiving_TSDF);
			
			db.AddInParameter(dbCommand, "Amount_HW_Generated_Per_Month", DbType.Decimal, this._Amount_HW_Generated_Per_Month);
			
			if (string.IsNullOrEmpty(this._Units))
				db.AddInParameter(dbCommand, "Units", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Units", DbType.String, this._Units);
			
			db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
			
			if (string.IsNullOrEmpty(this._Constituents_Of_Concern))
				db.AddInParameter(dbCommand, "Constituents_Of_Concern", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Constituents_Of_Concern", DbType.String, this._Constituents_Of_Concern);
			
			if (string.IsNullOrEmpty(this._Removal_Limits))
				db.AddInParameter(dbCommand, "Removal_Limits", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Removal_Limits", DbType.String, this._Removal_Limits);
			
			if (string.IsNullOrEmpty(this._HW_Profile_Complete_And_Maintained))
				db.AddInParameter(dbCommand, "HW_Profile_Complete_And_Maintained", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "HW_Profile_Complete_And_Maintained", DbType.String, this._HW_Profile_Complete_And_Maintained);
			
			db.AddInParameter(dbCommand, "FK_LU_Facility_Generator_Status", DbType.Decimal, this._FK_LU_Facility_Generator_Status);
			
			if (string.IsNullOrEmpty(this._Discharge_Limits))
				db.AddInParameter(dbCommand, "Discharge_Limits", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Discharge_Limits", DbType.String, this._Discharge_Limits);
			
			if (string.IsNullOrEmpty(this._California_Business_Plan))
				db.AddInParameter(dbCommand, "California_Business_Plan", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "California_Business_Plan", DbType.String, this._California_Business_Plan);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "FK_LU_PM_Hazardous_Waste_Codes", DbType.Decimal, this._FK_LU_PM_Hazardous_Waste_Codes);
            db.AddInParameter(dbCommand, "HW_Accumulation_Start", DbType.DateTime, this._HW_Accumulation_Start);
            db.AddInParameter(dbCommand, "Last_HW_Removal", DbType.DateTime, this._Last_HW_Removal);
            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Waste_Removal table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Waste_Removal)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Waste_RemovalDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Waste_Removal", DbType.Decimal, pK_PM_Waste_Removal);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectByFK_SiteInfo(decimal fK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Waste_RemovalSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal PK_PM_Waste_Removal)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Waste_Removal_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_Waste_Removal", DbType.Decimal, PK_PM_Waste_Removal);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
