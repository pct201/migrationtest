using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Equipment_Hydraulic_Lift_Grid table.
	/// </summary>
	public sealed class clsPM_Equipment_Hydraulic_Lift_Grid
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Equipment_Hydraulic_Lift_Grid;
		private decimal? _FK_PM_Equipment_Hydraulic_Lift;
		private string _Is_Number_Of_Lifts_At_Location;
		private string _Description;
		private string _Oil_Type;
		private string _Above_Ground;
		private string _Manufacturer_Name;
		private DateTime? _As_Of_Date_Number;
		private DateTime? _Installation_Date;
		private DateTime? _Last_Inspection_Date;
		private string _Notes;
		private DateTime? _Removal_Date;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
        /// Gets or sets the PK_PM_Equipment_Hydraulic_Lift_Grid value.
		/// </summary>
        public decimal? PK_PM_Equipment_Hydraulic_Lift_Grid
		{
            get { return _PK_PM_Equipment_Hydraulic_Lift_Grid; }
            set { _PK_PM_Equipment_Hydraulic_Lift_Grid = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_Equipment_Hydraulic_Lift value.
		/// </summary>
		public decimal? FK_PM_Equipment_Hydraulic_Lift
		{
			get { return _FK_PM_Equipment_Hydraulic_Lift; }
			set { _FK_PM_Equipment_Hydraulic_Lift = value; }
		}

		/// <summary>
		/// Gets or sets the Is_Number_Of_Lifts_At_Location value.
		/// </summary>
		public string Is_Number_Of_Lifts_At_Location
		{
			get { return _Is_Number_Of_Lifts_At_Location; }
			set { _Is_Number_Of_Lifts_At_Location = value; }
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
		/// Gets or sets the Oil_Type value.
		/// </summary>
		public string Oil_Type
		{
			get { return _Oil_Type; }
			set { _Oil_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Above_Ground value.
		/// </summary>
		public string Above_Ground
		{
			get { return _Above_Ground; }
			set { _Above_Ground = value; }
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
		/// Gets or sets the As_Of_Date_Number value.
		/// </summary>
		public DateTime? As_Of_Date_Number
		{
			get { return _As_Of_Date_Number; }
			set { _As_Of_Date_Number = value; }
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
		/// Gets or sets the Last_Inspection_Date value.
		/// </summary>
		public DateTime? Last_Inspection_Date
		{
			get { return _Last_Inspection_Date; }
			set { _Last_Inspection_Date = value; }
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
		/// Gets or sets the Removal_Date value.
		/// </summary>
		public DateTime? Removal_Date
		{
			get { return _Removal_Date; }
			set { _Removal_Date = value; }
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


		#endregion

		#region Default Constructors

		/// <summary>
        /// Initializes a new instance of the clsPK_PM_Equipment_Hydraulic_Lift_Grid class with default value.
		/// </summary>
		public clsPM_Equipment_Hydraulic_Lift_Grid() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_Hydraulic_Lift_Grid class based on Primary Key.
		/// </summary>
        public clsPM_Equipment_Hydraulic_Lift_Grid(decimal pK_PM_Equipment_Hydraulic_Lift_Grid) 
		{
            DataTable dtPM_Equipment_Hydraulic_Lift_Grid = SelectByPK(pK_PM_Equipment_Hydraulic_Lift_Grid).Tables[0];

			if (dtPM_Equipment_Hydraulic_Lift_Grid.Rows.Count == 1)
			{
				 SetValue(dtPM_Equipment_Hydraulic_Lift_Grid.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_Hydraulic_Lift_Grid class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Equipment_Hydraulic_Lift_Grid) 
		{
            if (drPM_Equipment_Hydraulic_Lift_Grid["PK_PM_Equipment_Hydraulic_Lift_Grid"] == DBNull.Value)
                this._PK_PM_Equipment_Hydraulic_Lift_Grid = null;
				else
                this._PK_PM_Equipment_Hydraulic_Lift_Grid = (decimal?)drPM_Equipment_Hydraulic_Lift_Grid["PK_PM_Equipment_Hydraulic_Lift_Grid"];

				if (drPM_Equipment_Hydraulic_Lift_Grid["FK_PM_Equipment_Hydraulic_Lift"] == DBNull.Value)
					this._FK_PM_Equipment_Hydraulic_Lift = null;
				else
					this._FK_PM_Equipment_Hydraulic_Lift = (decimal?)drPM_Equipment_Hydraulic_Lift_Grid["FK_PM_Equipment_Hydraulic_Lift"];

				if (drPM_Equipment_Hydraulic_Lift_Grid["Is_Number_Of_Lifts_At_Location"] == DBNull.Value)
					this._Is_Number_Of_Lifts_At_Location = null;
				else
					this._Is_Number_Of_Lifts_At_Location = (string)drPM_Equipment_Hydraulic_Lift_Grid["Is_Number_Of_Lifts_At_Location"];

				if (drPM_Equipment_Hydraulic_Lift_Grid["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drPM_Equipment_Hydraulic_Lift_Grid["Description"];

				if (drPM_Equipment_Hydraulic_Lift_Grid["Oil_Type"] == DBNull.Value)
					this._Oil_Type = null;
				else
					this._Oil_Type = (string)drPM_Equipment_Hydraulic_Lift_Grid["Oil_Type"];

				if (drPM_Equipment_Hydraulic_Lift_Grid["Above_Ground"] == DBNull.Value)
					this._Above_Ground = null;
				else
					this._Above_Ground = (string)drPM_Equipment_Hydraulic_Lift_Grid["Above_Ground"];

				if (drPM_Equipment_Hydraulic_Lift_Grid["Manufacturer_Name"] == DBNull.Value)
					this._Manufacturer_Name = null;
				else
					this._Manufacturer_Name = (string)drPM_Equipment_Hydraulic_Lift_Grid["Manufacturer_Name"];

				if (drPM_Equipment_Hydraulic_Lift_Grid["As_Of_Date_Number"] == DBNull.Value)
					this._As_Of_Date_Number = null;
				else
					this._As_Of_Date_Number = (DateTime?)drPM_Equipment_Hydraulic_Lift_Grid["As_Of_Date_Number"];

				if (drPM_Equipment_Hydraulic_Lift_Grid["Installation_Date"] == DBNull.Value)
					this._Installation_Date = null;
				else
					this._Installation_Date = (DateTime?)drPM_Equipment_Hydraulic_Lift_Grid["Installation_Date"];

				if (drPM_Equipment_Hydraulic_Lift_Grid["Last_Inspection_Date"] == DBNull.Value)
					this._Last_Inspection_Date = null;
				else
					this._Last_Inspection_Date = (DateTime?)drPM_Equipment_Hydraulic_Lift_Grid["Last_Inspection_Date"];

				if (drPM_Equipment_Hydraulic_Lift_Grid["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drPM_Equipment_Hydraulic_Lift_Grid["Notes"];

				if (drPM_Equipment_Hydraulic_Lift_Grid["Removal_Date"] == DBNull.Value)
					this._Removal_Date = null;
				else
					this._Removal_Date = (DateTime?)drPM_Equipment_Hydraulic_Lift_Grid["Removal_Date"];

				if (drPM_Equipment_Hydraulic_Lift_Grid["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Equipment_Hydraulic_Lift_Grid["Updated_By"];

				if (drPM_Equipment_Hydraulic_Lift_Grid["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Equipment_Hydraulic_Lift_Grid["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Equipment_Hydraulic_Lift_Grid table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Hydraulic_Lift_GridInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Equipment_Hydraulic_Lift", DbType.Decimal, this._FK_PM_Equipment_Hydraulic_Lift);
			
			if (string.IsNullOrEmpty(this._Is_Number_Of_Lifts_At_Location))
				db.AddInParameter(dbCommand, "Is_Number_Of_Lifts_At_Location", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Is_Number_Of_Lifts_At_Location", DbType.String, this._Is_Number_Of_Lifts_At_Location);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._Oil_Type))
				db.AddInParameter(dbCommand, "Oil_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Oil_Type", DbType.String, this._Oil_Type);
			
			if (string.IsNullOrEmpty(this._Above_Ground))
				db.AddInParameter(dbCommand, "Above_Ground", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Above_Ground", DbType.String, this._Above_Ground);
			
			if (string.IsNullOrEmpty(this._Manufacturer_Name))
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, this._Manufacturer_Name);
			
			db.AddInParameter(dbCommand, "As_Of_Date_Number", DbType.DateTime, this._As_Of_Date_Number);
			
			db.AddInParameter(dbCommand, "Installation_Date", DbType.DateTime, this._Installation_Date);
			
			db.AddInParameter(dbCommand, "Last_Inspection_Date", DbType.DateTime, this._Last_Inspection_Date);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			db.AddInParameter(dbCommand, "Removal_Date", DbType.DateTime, this._Removal_Date);
			
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
		/// Selects a single record from the PM_Equipment_Hydraulic_Lift_Grid table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_PM_Equipment_Hydraulic_Lift_Grid)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Hydraulic_Lift_GridSelectByPK");

            db.AddInParameter(dbCommand, "PK_PM_Equipment_Hydraulic_Lift_Grid", DbType.Decimal, pK_PM_Equipment_Hydraulic_Lift_Grid);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the PM_Equipment_Hydraulic_Lift_Grid table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal fK_PM_Equipment_Hydraulic_Lift)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Hydraulic_Lift_GridSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Equipment_Hydraulic_Lift", DbType.Decimal, fK_PM_Equipment_Hydraulic_Lift);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the PM_Equipment_Hydraulic_Lift_Grid table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet Select_UseSameDates_ByFK(decimal fK_PM_Equipment_Hydraulic_Lift,bool type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Check_UseSameDates_Hydraulic_Lift_Grid");

            db.AddInParameter(dbCommand, "FK_PM_Equipment_Hydraulic_Lift", DbType.Decimal, fK_PM_Equipment_Hydraulic_Lift);
            db.AddInParameter(dbCommand, "Type", DbType.Boolean, type);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the PM_Equipment_Hydraulic_Lift_Grid table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Hydraulic_Lift_GridSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Equipment_Hydraulic_Lift_Grid table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Hydraulic_Lift_GridUpdate");


            db.AddInParameter(dbCommand, "PK_PM_Equipment_Hydraulic_Lift_Grid", DbType.Decimal, this._PK_PM_Equipment_Hydraulic_Lift_Grid);
			
			db.AddInParameter(dbCommand, "FK_PM_Equipment_Hydraulic_Lift", DbType.Decimal, this._FK_PM_Equipment_Hydraulic_Lift);
			
			if (string.IsNullOrEmpty(this._Is_Number_Of_Lifts_At_Location))
				db.AddInParameter(dbCommand, "Is_Number_Of_Lifts_At_Location", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Is_Number_Of_Lifts_At_Location", DbType.String, this._Is_Number_Of_Lifts_At_Location);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._Oil_Type))
				db.AddInParameter(dbCommand, "Oil_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Oil_Type", DbType.String, this._Oil_Type);
			
			if (string.IsNullOrEmpty(this._Above_Ground))
				db.AddInParameter(dbCommand, "Above_Ground", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Above_Ground", DbType.String, this._Above_Ground);
			
			if (string.IsNullOrEmpty(this._Manufacturer_Name))
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, this._Manufacturer_Name);
			
			db.AddInParameter(dbCommand, "As_Of_Date_Number", DbType.DateTime, this._As_Of_Date_Number);
			
			db.AddInParameter(dbCommand, "Installation_Date", DbType.DateTime, this._Installation_Date);
			
			db.AddInParameter(dbCommand, "Last_Inspection_Date", DbType.DateTime, this._Last_Inspection_Date);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			db.AddInParameter(dbCommand, "Removal_Date", DbType.DateTime, this._Removal_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Equipment_Hydraulic_Lift_Grid table by a composite primary key.
		/// </summary>
        public static void DeleteByPK(decimal pK_PM_Equipment_Hydraulic_Lift_Grid)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Hydraulic_Lift_GridDeleteByPK");

            db.AddInParameter(dbCommand, "PK_PM_Equipment_Hydraulic_Lift_Grid", DbType.Decimal, pK_PM_Equipment_Hydraulic_Lift_Grid);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_Equipment_Hydraulic_Lift_Grid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Hydraulic_Lift_Grid_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_Equipment_Hydraulic_Lift_Grid", DbType.Decimal, pK_PM_Equipment_Hydraulic_Lift_Grid);

            return db.ExecuteDataSet(dbCommand);
        }

        public static void UpdateBYFK(decimal FK_PM_Equipment_Hydraulic_Lift, string Updated_By, DateTime Update_Date)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Hydraulic_Lift_GridUpdateBYFK");

            db.AddInParameter(dbCommand, "FK_PM_Equipment_Hydraulic_Lift", DbType.Decimal, FK_PM_Equipment_Hydraulic_Lift);
            //db.AddInParameter(dbCommand, "Installation_Date", DbType.DateTime, Installation_Date);

            //db.AddInParameter(dbCommand, "Last_Inspection_Date", DbType.DateTime, Last_Inspection_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, Updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, Update_Date);
            db.ExecuteNonQuery(dbCommand);
        }
	}
}
