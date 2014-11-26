using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
    /// Data access class for PM_Equipment_Prep_Station table.
	/// </summary>
	public sealed class clsPM_Equipment_Prep_Station
	{

		#region Private variables used to hold the property values

        private decimal? _PK_PM_Equipment_Prep_Station;
		private string _Description;
		private DateTime? _Installation_Date;
		private string _Manufacturer_Name;
		private string _Configured_For_Water_Borne_Application;
		private string _Direct_Indirect_Burners;
		private decimal? _BTU_Rating;
		private decimal? _Height_In_Feet;
		private decimal? _Width_In_Feet;
		private decimal? _Depth_In_Feet;
		private string _Filter_System;
		private decimal? _Capture_Efficiency;
		private decimal? _Control_Efficiency;
		private decimal? _Stack_Height_In_Feet;
		private decimal? _Exit_Flow_Rate_CFM;
		private decimal? _Exit_Temperature_Low;
		private decimal? _Exit_Temperature_High;
		private string _Notes;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private decimal? _PK_PM_Equipment;
        private string _Manual_6H_Binder;
        private DateTime? _Capture_Efficieicny_Date;
        private DateTime? _Control_Efficiency_Date;
		#endregion

		#region Public Property

		/// <summary>
        /// Gets or sets the PK_PM_Equipment_Prep_Station value.
		/// </summary>
        public decimal? PK_PM_Equipment_Prep_Station
		{
            get { return _PK_PM_Equipment_Prep_Station; }
            set { _PK_PM_Equipment_Prep_Station = value; }
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
		/// Gets or sets the Configured_For_Water_Borne_Application value.
		/// </summary>
		public string Configured_For_Water_Borne_Application
		{
			get { return _Configured_For_Water_Borne_Application; }
			set { _Configured_For_Water_Borne_Application = value; }
		}

		/// <summary>
		/// Gets or sets the Direct_Indirect_Burners value.
		/// </summary>
		public string Direct_Indirect_Burners
		{
			get { return _Direct_Indirect_Burners; }
			set { _Direct_Indirect_Burners = value; }
		}

		/// <summary>
		/// Gets or sets the BTU_Rating value.
		/// </summary>
		public decimal? BTU_Rating
		{
			get { return _BTU_Rating; }
			set { _BTU_Rating = value; }
		}

		/// <summary>
		/// Gets or sets the Height_In_Feet value.
		/// </summary>
		public decimal? Height_In_Feet
		{
			get { return _Height_In_Feet; }
			set { _Height_In_Feet = value; }
		}

		/// <summary>
		/// Gets or sets the Width_In_Feet value.
		/// </summary>
		public decimal? Width_In_Feet
		{
			get { return _Width_In_Feet; }
			set { _Width_In_Feet = value; }
		}

		/// <summary>
		/// Gets or sets the Depth_In_Feet value.
		/// </summary>
		public decimal? Depth_In_Feet
		{
			get { return _Depth_In_Feet; }
			set { _Depth_In_Feet = value; }
		}

		/// <summary>
		/// Gets or sets the Filter_System value.
		/// </summary>
		public string Filter_System
		{
			get { return _Filter_System; }
			set { _Filter_System = value; }
		}

		/// <summary>
		/// Gets or sets the Capture_Efficiency value.
		/// </summary>
		public decimal? Capture_Efficiency
		{
			get { return _Capture_Efficiency; }
			set { _Capture_Efficiency = value; }
		}

		/// <summary>
		/// Gets or sets the Control_Efficiency value.
		/// </summary>
		public decimal? Control_Efficiency
		{
			get { return _Control_Efficiency; }
			set { _Control_Efficiency = value; }
		}

		/// <summary>
		/// Gets or sets the Stack_Height_In_Feet value.
		/// </summary>
		public decimal? Stack_Height_In_Feet
		{
			get { return _Stack_Height_In_Feet; }
			set { _Stack_Height_In_Feet = value; }
		}

		/// <summary>
		/// Gets or sets the Exit_Flow_Rate_CFM value.
		/// </summary>
		public decimal? Exit_Flow_Rate_CFM
		{
			get { return _Exit_Flow_Rate_CFM; }
			set { _Exit_Flow_Rate_CFM = value; }
		}

		/// <summary>
		/// Gets or sets the Exit_Temperature_Low value.
		/// </summary>
		public decimal? Exit_Temperature_Low
		{
			get { return _Exit_Temperature_Low; }
			set { _Exit_Temperature_Low = value; }
		}

		/// <summary>
		/// Gets or sets the Exit_Temperature_High value.
		/// </summary>
		public decimal? Exit_Temperature_High
		{
			get { return _Exit_Temperature_High; }
			set { _Exit_Temperature_High = value; }
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
        /// Gets or sets the PM_Equipment value.
        /// </summary>
        public decimal? PK_PM_Equipment
        {
            get { return _PK_PM_Equipment; }
            set { _PK_PM_Equipment = value; }
        }

        /// <summary>
        /// Gets or sets the Capture_Efficieicny_Date value.
        /// </summary>
        public DateTime? Capture_Efficieicny_Date
        {
            get { return _Capture_Efficieicny_Date; }
            set { _Capture_Efficieicny_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Control_Efficiency_Date value.
        /// </summary>
        public DateTime? Control_Efficiency_Date
        {
            get { return _Control_Efficiency_Date; }
            set { _Control_Efficiency_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Manual_6H_Binder
        {
            get { return _Manual_6H_Binder; }
            set { _Manual_6H_Binder = value; }
        }

		#endregion

		#region Default Constructors

		/// <summary>
        /// Initializes a new instance of the clsPM_Equipment_Prep_Station class with default value.
		/// </summary>
		public clsPM_Equipment_Prep_Station() 
		{
		}

		#endregion

		#region Primary Constructors

		/// <summary>
        /// Initializes a new instance of the clsPM_Equipment_Prep_Station class based on Primary Key.
		/// </summary>
        public clsPM_Equipment_Prep_Station(decimal pK_PM_Equipment_Prep_Station) 
		{
            DataTable dtPM_Equipment_Prep_Station = SelectByPK(pK_PM_Equipment_Prep_Station).Tables[0];

            if (dtPM_Equipment_Prep_Station.Rows.Count == 1)
			{
                SetValue(dtPM_Equipment_Prep_Station.Rows[0]);
			}
		}

		/// <summary>
        /// Initializes a new instance of the clsPM_Equipment_Prep_Station class based on Datarow passed.
		/// </summary>
        private void SetValue(DataRow drPM_Equipment_Prep_Station) 
		{
            if (drPM_Equipment_Prep_Station["PK_PM_Equipment_Prep_Station"] == DBNull.Value)
                this._PK_PM_Equipment_Prep_Station = null;
				else
                this._PK_PM_Equipment_Prep_Station = (decimal?)drPM_Equipment_Prep_Station["PK_PM_Equipment_Prep_Station"];

				if (drPM_Equipment_Prep_Station["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drPM_Equipment_Prep_Station["Description"];

				if (drPM_Equipment_Prep_Station["Installation_Date"] == DBNull.Value)
					this._Installation_Date = null;
				else
					this._Installation_Date = (DateTime?)drPM_Equipment_Prep_Station["Installation_Date"];


                if (drPM_Equipment_Prep_Station["Capture_Efficieicny_Date"] == DBNull.Value)
                    this._Capture_Efficieicny_Date = null;
                else
                    this._Capture_Efficieicny_Date = (DateTime?)drPM_Equipment_Prep_Station["Capture_Efficieicny_Date"];

                if (drPM_Equipment_Prep_Station["Control_Efficiency_Date"] == DBNull.Value)
                    this._Control_Efficiency_Date = null;
                else
                    this._Control_Efficiency_Date = (DateTime?)drPM_Equipment_Prep_Station["Control_Efficiency_Date"];


				if (drPM_Equipment_Prep_Station["Manufacturer_Name"] == DBNull.Value)
					this._Manufacturer_Name = null;
				else
					this._Manufacturer_Name = (string)drPM_Equipment_Prep_Station["Manufacturer_Name"];

				if (drPM_Equipment_Prep_Station["Configured_For_Water_Borne_Application"] == DBNull.Value)
					this._Configured_For_Water_Borne_Application = null;
				else
					this._Configured_For_Water_Borne_Application = (string)drPM_Equipment_Prep_Station["Configured_For_Water_Borne_Application"];

				if (drPM_Equipment_Prep_Station["Direct_Indirect_Burners"] == DBNull.Value)
					this._Direct_Indirect_Burners = null;
				else
					this._Direct_Indirect_Burners = (string)drPM_Equipment_Prep_Station["Direct_Indirect_Burners"];

                if (drPM_Equipment_Prep_Station["Manual_6H_Binder"] == DBNull.Value)
                    this._Manual_6H_Binder= null;
                else
                    this._Manual_6H_Binder = (string)drPM_Equipment_Prep_Station["Manual_6H_Binder"];

				if (drPM_Equipment_Prep_Station["BTU_Rating"] == DBNull.Value)
					this._BTU_Rating = null;
				else
					this._BTU_Rating = (decimal?)drPM_Equipment_Prep_Station["BTU_Rating"];

				if (drPM_Equipment_Prep_Station["Height_In_Feet"] == DBNull.Value)
					this._Height_In_Feet = null;
				else
					this._Height_In_Feet = (decimal?)drPM_Equipment_Prep_Station["Height_In_Feet"];

				if (drPM_Equipment_Prep_Station["Width_In_Feet"] == DBNull.Value)
					this._Width_In_Feet = null;
				else
					this._Width_In_Feet = (decimal?)drPM_Equipment_Prep_Station["Width_In_Feet"];

				if (drPM_Equipment_Prep_Station["Depth_In_Feet"] == DBNull.Value)
					this._Depth_In_Feet = null;
				else
					this._Depth_In_Feet = (decimal?)drPM_Equipment_Prep_Station["Depth_In_Feet"];

				if (drPM_Equipment_Prep_Station["Filter_System"] == DBNull.Value)
					this._Filter_System = null;
				else
					this._Filter_System = (string)drPM_Equipment_Prep_Station["Filter_System"];

				if (drPM_Equipment_Prep_Station["Capture_Efficiency"] == DBNull.Value)
					this._Capture_Efficiency = null;
				else
					this._Capture_Efficiency = (decimal?)drPM_Equipment_Prep_Station["Capture_Efficiency"];

				if (drPM_Equipment_Prep_Station["Control_Efficiency"] == DBNull.Value)
					this._Control_Efficiency = null;
				else
					this._Control_Efficiency = (decimal?)drPM_Equipment_Prep_Station["Control_Efficiency"];

				if (drPM_Equipment_Prep_Station["Stack_Height_In_Feet"] == DBNull.Value)
					this._Stack_Height_In_Feet = null;
				else
					this._Stack_Height_In_Feet = (decimal?)drPM_Equipment_Prep_Station["Stack_Height_In_Feet"];

				if (drPM_Equipment_Prep_Station["Exit_Flow_Rate_CFM"] == DBNull.Value)
					this._Exit_Flow_Rate_CFM = null;
				else
					this._Exit_Flow_Rate_CFM = (decimal?)drPM_Equipment_Prep_Station["Exit_Flow_Rate_CFM"];

				if (drPM_Equipment_Prep_Station["Exit_Temperature_Low"] == DBNull.Value)
					this._Exit_Temperature_Low = null;
				else
					this._Exit_Temperature_Low = (decimal?)drPM_Equipment_Prep_Station["Exit_Temperature_Low"];

				if (drPM_Equipment_Prep_Station["Exit_Temperature_High"] == DBNull.Value)
					this._Exit_Temperature_High = null;
				else
					this._Exit_Temperature_High = (decimal?)drPM_Equipment_Prep_Station["Exit_Temperature_High"];

				if (drPM_Equipment_Prep_Station["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drPM_Equipment_Prep_Station["Notes"];

				if (drPM_Equipment_Prep_Station["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Equipment_Prep_Station["Updated_By"];

				if (drPM_Equipment_Prep_Station["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Equipment_Prep_Station["Update_Date"];

                if (drPM_Equipment_Prep_Station["PK_PM_Equipment"] == DBNull.Value)
                    this._PK_PM_Equipment = null;
                else
                    this._PK_PM_Equipment = (decimal?)drPM_Equipment_Prep_Station["PK_PM_Equipment"];

		}

		#endregion

		/// <summary>
        /// Inserts a record into the PM_Equipment_Prep_Station table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Prep_StationInsert");
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			db.AddInParameter(dbCommand, "Installation_Date", DbType.DateTime, this._Installation_Date);
			
			if (string.IsNullOrEmpty(this._Manufacturer_Name))
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, this._Manufacturer_Name);
			
			if (string.IsNullOrEmpty(this._Configured_For_Water_Borne_Application))
				db.AddInParameter(dbCommand, "Configured_For_Water_Borne_Application", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Configured_For_Water_Borne_Application", DbType.String, this._Configured_For_Water_Borne_Application);
			
			if (string.IsNullOrEmpty(this._Direct_Indirect_Burners))
				db.AddInParameter(dbCommand, "Direct_Indirect_Burners", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Direct_Indirect_Burners", DbType.String, this._Direct_Indirect_Burners);
			
			db.AddInParameter(dbCommand, "BTU_Rating", DbType.Decimal, this._BTU_Rating);
			
			db.AddInParameter(dbCommand, "Height_In_Feet", DbType.Decimal, this._Height_In_Feet);
			
			db.AddInParameter(dbCommand, "Width_In_Feet", DbType.Decimal, this._Width_In_Feet);
			
			db.AddInParameter(dbCommand, "Depth_In_Feet", DbType.Decimal, this._Depth_In_Feet);
			
			if (string.IsNullOrEmpty(this._Filter_System))
				db.AddInParameter(dbCommand, "Filter_System", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Filter_System", DbType.String, this._Filter_System);
			
			db.AddInParameter(dbCommand, "Capture_Efficiency", DbType.Decimal, this._Capture_Efficiency);
			
			db.AddInParameter(dbCommand, "Control_Efficiency", DbType.Decimal, this._Control_Efficiency);
			
			db.AddInParameter(dbCommand, "Stack_Height_In_Feet", DbType.Decimal, this._Stack_Height_In_Feet);
			
			db.AddInParameter(dbCommand, "Exit_Flow_Rate_CFM", DbType.Decimal, this._Exit_Flow_Rate_CFM);
			
			db.AddInParameter(dbCommand, "Exit_Temperature_Low", DbType.Decimal, this._Exit_Temperature_Low);
			
			db.AddInParameter(dbCommand, "Exit_Temperature_High", DbType.Decimal, this._Exit_Temperature_High);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            if (string.IsNullOrEmpty(this._Manual_6H_Binder))
                db.AddInParameter(dbCommand, "Manual_6H_Binder", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Manual_6H_Binder", DbType.String, this._Manual_6H_Binder);
            db.AddInParameter(dbCommand, "Capture_Efficieicny_Date", DbType.DateTime, this._Capture_Efficieicny_Date);
            db.AddInParameter(dbCommand, "Control_Efficiency_Date", DbType.DateTime, this._Control_Efficiency_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
        /// Selects a single record from the PM_Equipment_Prep_Station table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_PM_Equipment_Prep_Station)
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Prep_StationSelectByPK");

            db.AddInParameter(dbCommand, "PK_PM_Equipment_Prep_Station", DbType.Decimal, pK_PM_Equipment_Prep_Station);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
        /// Selects all records from the PM_Equipment_Prep_Station table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Prep_StationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
        /// Updates a record in the PM_Equipment_Prep_Station table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Prep_StationUpdate");


            db.AddInParameter(dbCommand, "PK_PM_Equipment_Prep_Station", DbType.Decimal, this._PK_PM_Equipment_Prep_Station);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			db.AddInParameter(dbCommand, "Installation_Date", DbType.DateTime, this._Installation_Date);
			
			if (string.IsNullOrEmpty(this._Manufacturer_Name))
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, this._Manufacturer_Name);
			
			if (string.IsNullOrEmpty(this._Configured_For_Water_Borne_Application))
				db.AddInParameter(dbCommand, "Configured_For_Water_Borne_Application", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Configured_For_Water_Borne_Application", DbType.String, this._Configured_For_Water_Borne_Application);
			
			if (string.IsNullOrEmpty(this._Direct_Indirect_Burners))
				db.AddInParameter(dbCommand, "Direct_Indirect_Burners", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Direct_Indirect_Burners", DbType.String, this._Direct_Indirect_Burners);
			
			db.AddInParameter(dbCommand, "BTU_Rating", DbType.Decimal, this._BTU_Rating);
			
			db.AddInParameter(dbCommand, "Height_In_Feet", DbType.Decimal, this._Height_In_Feet);
			
			db.AddInParameter(dbCommand, "Width_In_Feet", DbType.Decimal, this._Width_In_Feet);
			
			db.AddInParameter(dbCommand, "Depth_In_Feet", DbType.Decimal, this._Depth_In_Feet);
			
			if (string.IsNullOrEmpty(this._Filter_System))
				db.AddInParameter(dbCommand, "Filter_System", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Filter_System", DbType.String, this._Filter_System);
			
			db.AddInParameter(dbCommand, "Capture_Efficiency", DbType.Decimal, this._Capture_Efficiency);
			
			db.AddInParameter(dbCommand, "Control_Efficiency", DbType.Decimal, this._Control_Efficiency);
			
			db.AddInParameter(dbCommand, "Stack_Height_In_Feet", DbType.Decimal, this._Stack_Height_In_Feet);
			
			db.AddInParameter(dbCommand, "Exit_Flow_Rate_CFM", DbType.Decimal, this._Exit_Flow_Rate_CFM);
			
			db.AddInParameter(dbCommand, "Exit_Temperature_Low", DbType.Decimal, this._Exit_Temperature_Low);
			
			db.AddInParameter(dbCommand, "Exit_Temperature_High", DbType.Decimal, this._Exit_Temperature_High);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            if (string.IsNullOrEmpty(this._Manual_6H_Binder))
                db.AddInParameter(dbCommand, "Manual_6H_Binder", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Manual_6H_Binder", DbType.String, this._Manual_6H_Binder);
            db.AddInParameter(dbCommand, "Capture_Efficieicny_Date", DbType.DateTime, this._Capture_Efficieicny_Date);
            db.AddInParameter(dbCommand, "Control_Efficiency_Date", DbType.DateTime, this._Control_Efficiency_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
        /// Deletes a record from the PM_Equipment_Prep_Station table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Equipment_Prep_Station)
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Prep_StationDeleteByPK");

            db.AddInParameter(dbCommand, "PK_PM_Equipment_Prep_Station", DbType.Decimal, pK_PM_Equipment_Prep_Station);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_Equipment_Prep_Station)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Prep_Station_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_Equipment_Prep_Station", DbType.Decimal, pK_PM_Equipment_Prep_Station);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
