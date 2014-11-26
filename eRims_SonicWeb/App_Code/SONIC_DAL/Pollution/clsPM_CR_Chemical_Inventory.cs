using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_CR_Chemical_Inventory table.
	/// </summary>
	public sealed class clsPM_CR_Chemical_Inventory
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_CR_Chemical_Inventory;
		private decimal? _FK_PM_Compliance_Reporting;
		private decimal? _FK_LU_Chemical_Type;
		private string _CAS_Number;
		private string _Pure_Mixture;
		private string _Mixture_Components;
        private string _Chemical_Name;
		private string _Physical_State;
		private decimal? _Maximum_Pounds_On_Site;
		private decimal? _Daily_maximum_Pounds_On_Site;
		private decimal? _Average_Pounds_On_Site;
		private decimal? _Daily_Average_Pounds_On_Site;
		private decimal? _FK_LU_Storage_Type;
		private decimal? _FK_LU_Storage_Location;
		private decimal? _State_Local_Fees;
		private string _Method;
		private string _Description;
		private string _Initial_6H_Notification_Submitted;
		private string _SixH_Compliance_Verification_Submitted;
		private string _Notifications_6H_Changes_Reports_Submitted;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_CR_Chemical_Inventory value.
		/// </summary>
		public decimal? PK_PM_CR_Chemical_Inventory
		{
			get { return _PK_PM_CR_Chemical_Inventory; }
			set { _PK_PM_CR_Chemical_Inventory = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_Compliance_Reporting value.
		/// </summary>
		public decimal? FK_PM_Compliance_Reporting
		{
			get { return _FK_PM_Compliance_Reporting; }
			set { _FK_PM_Compliance_Reporting = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Chemical_Type value.
		/// </summary>
		public decimal? FK_LU_Chemical_Type
		{
			get { return _FK_LU_Chemical_Type; }
			set { _FK_LU_Chemical_Type = value; }
		}

		/// <summary>
		/// Gets or sets the CAS_Number value.
		/// </summary>
		public string CAS_Number
		{
			get { return _CAS_Number; }
			set { _CAS_Number = value; }
		}

		/// <summary>
		/// Gets or sets the Pure_Mixture value.
		/// </summary>
		public string Pure_Mixture
		{
			get { return _Pure_Mixture; }
			set { _Pure_Mixture = value; }
		}

		/// <summary>
		/// Gets or sets the Mixture_Components value.
		/// </summary>
		public string Mixture_Components
		{
			get { return _Mixture_Components; }
			set { _Mixture_Components = value; }
		}

        /// <summary>
        /// Gets or sets the Chemical_Name value.
        /// </summary>
        public string Chemical_Name
        {
            get { return _Chemical_Name; }
            set { _Chemical_Name = value; }
        }

		/// <summary>
		/// Gets or sets the Physical_State value.
		/// </summary>
		public string Physical_State
		{
			get { return _Physical_State; }
			set { _Physical_State = value; }
		}

		/// <summary>
		/// Gets or sets the Maximum_Pounds_On_Site value.
		/// </summary>
		public decimal? Maximum_Pounds_On_Site
		{
			get { return _Maximum_Pounds_On_Site; }
			set { _Maximum_Pounds_On_Site = value; }
		}

		/// <summary>
		/// Gets or sets the Daily_maximum_Pounds_On_Site value.
		/// </summary>
		public decimal? Daily_maximum_Pounds_On_Site
		{
			get { return _Daily_maximum_Pounds_On_Site; }
			set { _Daily_maximum_Pounds_On_Site = value; }
		}

		/// <summary>
		/// Gets or sets the Average_Pounds_On_Site value.
		/// </summary>
		public decimal? Average_Pounds_On_Site
		{
			get { return _Average_Pounds_On_Site; }
			set { _Average_Pounds_On_Site = value; }
		}

		/// <summary>
		/// Gets or sets the Daily_Average_Pounds_On_Site value.
		/// </summary>
		public decimal? Daily_Average_Pounds_On_Site
		{
			get { return _Daily_Average_Pounds_On_Site; }
			set { _Daily_Average_Pounds_On_Site = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Storage_Type value.
		/// </summary>
		public decimal? FK_LU_Storage_Type
		{
			get { return _FK_LU_Storage_Type; }
			set { _FK_LU_Storage_Type = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Storage_Location value.
		/// </summary>
		public decimal? FK_LU_Storage_Location
		{
			get { return _FK_LU_Storage_Location; }
			set { _FK_LU_Storage_Location = value; }
		}

		/// <summary>
		/// Gets or sets the State_Local_Fees value.
		/// </summary>
		public decimal? State_Local_Fees
		{
			get { return _State_Local_Fees; }
			set { _State_Local_Fees = value; }
		}

		/// <summary>
		/// Gets or sets the Method value.
		/// </summary>
		public string Method
		{
			get { return _Method; }
			set { _Method = value; }
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
		/// Gets or sets the Initial_6H_Notification_Submitted value.
		/// </summary>
		public string Initial_6H_Notification_Submitted
		{
			get { return _Initial_6H_Notification_Submitted; }
			set { _Initial_6H_Notification_Submitted = value; }
		}

		/// <summary>
		/// Gets or sets the SixH_Compliance_Verification_Submitted value.
		/// </summary>
		public string SixH_Compliance_Verification_Submitted
		{
			get { return _SixH_Compliance_Verification_Submitted; }
			set { _SixH_Compliance_Verification_Submitted = value; }
		}

		/// <summary>
		/// Gets or sets the Notifications_6H_Changes_Reports_Submitted value.
		/// </summary>
		public string Notifications_6H_Changes_Reports_Submitted
		{
			get { return _Notifications_6H_Changes_Reports_Submitted; }
			set { _Notifications_6H_Changes_Reports_Submitted = value; }
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
		/// Initializes a new instance of the clsPM_CR_Chemical_Inventory class with default value.
		/// </summary>
		public clsPM_CR_Chemical_Inventory() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_CR_Chemical_Inventory class based on Primary Key.
		/// </summary>
		public clsPM_CR_Chemical_Inventory(decimal pK_PM_CR_Chemical_Inventory) 
		{
			DataTable dtPM_CR_Chemical_Inventory = SelectByPK(pK_PM_CR_Chemical_Inventory).Tables[0];

			if (dtPM_CR_Chemical_Inventory.Rows.Count == 1)
			{
				 SetValue(dtPM_CR_Chemical_Inventory.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_CR_Chemical_Inventory class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_CR_Chemical_Inventory) 
		{
				if (drPM_CR_Chemical_Inventory["PK_PM_CR_Chemical_Inventory"] == DBNull.Value)
					this._PK_PM_CR_Chemical_Inventory = null;
				else
					this._PK_PM_CR_Chemical_Inventory = (decimal?)drPM_CR_Chemical_Inventory["PK_PM_CR_Chemical_Inventory"];

				if (drPM_CR_Chemical_Inventory["FK_PM_Compliance_Reporting"] == DBNull.Value)
					this._FK_PM_Compliance_Reporting = null;
				else
					this._FK_PM_Compliance_Reporting = (decimal?)drPM_CR_Chemical_Inventory["FK_PM_Compliance_Reporting"];

				if (drPM_CR_Chemical_Inventory["FK_LU_Chemical_Type"] == DBNull.Value)
					this._FK_LU_Chemical_Type = null;
				else
					this._FK_LU_Chemical_Type = (decimal?)drPM_CR_Chemical_Inventory["FK_LU_Chemical_Type"];

				if (drPM_CR_Chemical_Inventory["CAS_Number"] == DBNull.Value)
					this._CAS_Number = null;
				else
					this._CAS_Number = (string)drPM_CR_Chemical_Inventory["CAS_Number"];

				if (drPM_CR_Chemical_Inventory["Pure_Mixture"] == DBNull.Value)
					this._Pure_Mixture = null;
				else
					this._Pure_Mixture = (string)drPM_CR_Chemical_Inventory["Pure_Mixture"];

				if (drPM_CR_Chemical_Inventory["Mixture_Components"] == DBNull.Value)
					this._Mixture_Components = null;
				else
					this._Mixture_Components = (string)drPM_CR_Chemical_Inventory["Mixture_Components"];

                if (drPM_CR_Chemical_Inventory["Chemical_Name"] == DBNull.Value)
                    this._Chemical_Name = null;
                else
                    this._Chemical_Name = (string)drPM_CR_Chemical_Inventory["Chemical_Name"];

				if (drPM_CR_Chemical_Inventory["Physical_State"] == DBNull.Value)
					this._Physical_State = null;
				else
					this._Physical_State = (string)drPM_CR_Chemical_Inventory["Physical_State"];

				if (drPM_CR_Chemical_Inventory["Maximum_Pounds_On_Site"] == DBNull.Value)
					this._Maximum_Pounds_On_Site = null;
				else
					this._Maximum_Pounds_On_Site = (decimal?)drPM_CR_Chemical_Inventory["Maximum_Pounds_On_Site"];

				if (drPM_CR_Chemical_Inventory["Daily_maximum_Pounds_On_Site"] == DBNull.Value)
					this._Daily_maximum_Pounds_On_Site = null;
				else
					this._Daily_maximum_Pounds_On_Site = (decimal?)drPM_CR_Chemical_Inventory["Daily_maximum_Pounds_On_Site"];

				if (drPM_CR_Chemical_Inventory["Average_Pounds_On_Site"] == DBNull.Value)
					this._Average_Pounds_On_Site = null;
				else
					this._Average_Pounds_On_Site = (decimal?)drPM_CR_Chemical_Inventory["Average_Pounds_On_Site"];

				if (drPM_CR_Chemical_Inventory["Daily_Average_Pounds_On_Site"] == DBNull.Value)
					this._Daily_Average_Pounds_On_Site = null;
				else
					this._Daily_Average_Pounds_On_Site = (decimal?)drPM_CR_Chemical_Inventory["Daily_Average_Pounds_On_Site"];

				if (drPM_CR_Chemical_Inventory["FK_LU_Storage_Type"] == DBNull.Value)
					this._FK_LU_Storage_Type = null;
				else
					this._FK_LU_Storage_Type = (decimal?)drPM_CR_Chemical_Inventory["FK_LU_Storage_Type"];

				if (drPM_CR_Chemical_Inventory["FK_LU_Storage_Location"] == DBNull.Value)
					this._FK_LU_Storage_Location = null;
				else
					this._FK_LU_Storage_Location = (decimal?)drPM_CR_Chemical_Inventory["FK_LU_Storage_Location"];

				if (drPM_CR_Chemical_Inventory["State_Local_Fees"] == DBNull.Value)
					this._State_Local_Fees = null;
				else
					this._State_Local_Fees = (decimal?)drPM_CR_Chemical_Inventory["State_Local_Fees"];

				if (drPM_CR_Chemical_Inventory["Method"] == DBNull.Value)
					this._Method = null;
				else
					this._Method = (string)drPM_CR_Chemical_Inventory["Method"];

				if (drPM_CR_Chemical_Inventory["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drPM_CR_Chemical_Inventory["Description"];

				if (drPM_CR_Chemical_Inventory["Initial_6H_Notification_Submitted"] == DBNull.Value)
					this._Initial_6H_Notification_Submitted = null;
				else
					this._Initial_6H_Notification_Submitted = (string)drPM_CR_Chemical_Inventory["Initial_6H_Notification_Submitted"];

				if (drPM_CR_Chemical_Inventory["SixH_Compliance_Verification_Submitted"] == DBNull.Value)
					this._SixH_Compliance_Verification_Submitted = null;
				else
					this._SixH_Compliance_Verification_Submitted = (string)drPM_CR_Chemical_Inventory["SixH_Compliance_Verification_Submitted"];

				if (drPM_CR_Chemical_Inventory["Notifications_6H_Changes_Reports_Submitted"] == DBNull.Value)
					this._Notifications_6H_Changes_Reports_Submitted = null;
				else
					this._Notifications_6H_Changes_Reports_Submitted = (string)drPM_CR_Chemical_Inventory["Notifications_6H_Changes_Reports_Submitted"];

				if (drPM_CR_Chemical_Inventory["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_CR_Chemical_Inventory["Updated_By"];

				if (drPM_CR_Chemical_Inventory["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_CR_Chemical_Inventory["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_CR_Chemical_Inventory table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_Chemical_InventoryInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Compliance_Reporting", DbType.Decimal, this._FK_PM_Compliance_Reporting);
			
			db.AddInParameter(dbCommand, "FK_LU_Chemical_Type", DbType.Decimal, this._FK_LU_Chemical_Type);
			
			if (string.IsNullOrEmpty(this._CAS_Number))
				db.AddInParameter(dbCommand, "CAS_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "CAS_Number", DbType.String, this._CAS_Number);
			
			if (string.IsNullOrEmpty(this._Pure_Mixture))
				db.AddInParameter(dbCommand, "Pure_Mixture", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Pure_Mixture", DbType.String, this._Pure_Mixture);
			
			if (string.IsNullOrEmpty(this._Mixture_Components))
				db.AddInParameter(dbCommand, "Mixture_Components", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Mixture_Components", DbType.String, this._Mixture_Components);

            if (string.IsNullOrEmpty(this._Chemical_Name))
                db.AddInParameter(dbCommand, "Chemical_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Chemical_Name", DbType.String, this._Chemical_Name);
			
			if (string.IsNullOrEmpty(this._Physical_State))
				db.AddInParameter(dbCommand, "Physical_State", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Physical_State", DbType.String, this._Physical_State);
			
			db.AddInParameter(dbCommand, "Maximum_Pounds_On_Site", DbType.Decimal, this._Maximum_Pounds_On_Site);
			
			db.AddInParameter(dbCommand, "Daily_maximum_Pounds_On_Site", DbType.Decimal, this._Daily_maximum_Pounds_On_Site);
			
			db.AddInParameter(dbCommand, "Average_Pounds_On_Site", DbType.Decimal, this._Average_Pounds_On_Site);
			
			db.AddInParameter(dbCommand, "Daily_Average_Pounds_On_Site", DbType.Decimal, this._Daily_Average_Pounds_On_Site);
			
			db.AddInParameter(dbCommand, "FK_LU_Storage_Type", DbType.Decimal, this._FK_LU_Storage_Type);
			
			db.AddInParameter(dbCommand, "FK_LU_Storage_Location", DbType.Decimal, this._FK_LU_Storage_Location);
			
			db.AddInParameter(dbCommand, "State_Local_Fees", DbType.Decimal, this._State_Local_Fees);
			
			if (string.IsNullOrEmpty(this._Method))
				db.AddInParameter(dbCommand, "Method", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Method", DbType.String, this._Method);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._Initial_6H_Notification_Submitted))
				db.AddInParameter(dbCommand, "Initial_6H_Notification_Submitted", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Initial_6H_Notification_Submitted", DbType.String, this._Initial_6H_Notification_Submitted);
			
			if (string.IsNullOrEmpty(this._SixH_Compliance_Verification_Submitted))
				db.AddInParameter(dbCommand, "SixH_Compliance_Verification_Submitted", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "SixH_Compliance_Verification_Submitted", DbType.String, this._SixH_Compliance_Verification_Submitted);
			
			if (string.IsNullOrEmpty(this._Notifications_6H_Changes_Reports_Submitted))
				db.AddInParameter(dbCommand, "Notifications_6H_Changes_Reports_Submitted", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notifications_6H_Changes_Reports_Submitted", DbType.String, this._Notifications_6H_Changes_Reports_Submitted);
			
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
		/// Selects a single record from the PM_CR_Chemical_Inventory table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_CR_Chemical_Inventory)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_Chemical_InventorySelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_CR_Chemical_Inventory", DbType.Decimal, pK_PM_CR_Chemical_Inventory);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_CR_Chemical_Inventory table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_Chemical_InventorySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_CR_Chemical_Inventory table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_Chemical_InventoryUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_CR_Chemical_Inventory", DbType.Decimal, this._PK_PM_CR_Chemical_Inventory);
			
			db.AddInParameter(dbCommand, "FK_PM_Compliance_Reporting", DbType.Decimal, this._FK_PM_Compliance_Reporting);
			
			db.AddInParameter(dbCommand, "FK_LU_Chemical_Type", DbType.Decimal, this._FK_LU_Chemical_Type);
			
			if (string.IsNullOrEmpty(this._CAS_Number))
				db.AddInParameter(dbCommand, "CAS_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "CAS_Number", DbType.String, this._CAS_Number);
			
			if (string.IsNullOrEmpty(this._Pure_Mixture))
				db.AddInParameter(dbCommand, "Pure_Mixture", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Pure_Mixture", DbType.String, this._Pure_Mixture);
			
			if (string.IsNullOrEmpty(this._Mixture_Components))
				db.AddInParameter(dbCommand, "Mixture_Components", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Mixture_Components", DbType.String, this._Mixture_Components);

            if (string.IsNullOrEmpty(this._Chemical_Name))
                db.AddInParameter(dbCommand, "Chemical_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Chemical_Name", DbType.String, this._Chemical_Name);
			
			if (string.IsNullOrEmpty(this._Physical_State))
				db.AddInParameter(dbCommand, "Physical_State", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Physical_State", DbType.String, this._Physical_State);
			
			db.AddInParameter(dbCommand, "Maximum_Pounds_On_Site", DbType.Decimal, this._Maximum_Pounds_On_Site);
			
			db.AddInParameter(dbCommand, "Daily_maximum_Pounds_On_Site", DbType.Decimal, this._Daily_maximum_Pounds_On_Site);
			
			db.AddInParameter(dbCommand, "Average_Pounds_On_Site", DbType.Decimal, this._Average_Pounds_On_Site);
			
			db.AddInParameter(dbCommand, "Daily_Average_Pounds_On_Site", DbType.Decimal, this._Daily_Average_Pounds_On_Site);
			
			db.AddInParameter(dbCommand, "FK_LU_Storage_Type", DbType.Decimal, this._FK_LU_Storage_Type);
			
			db.AddInParameter(dbCommand, "FK_LU_Storage_Location", DbType.Decimal, this._FK_LU_Storage_Location);
			
			db.AddInParameter(dbCommand, "State_Local_Fees", DbType.Decimal, this._State_Local_Fees);
			
			if (string.IsNullOrEmpty(this._Method))
				db.AddInParameter(dbCommand, "Method", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Method", DbType.String, this._Method);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._Initial_6H_Notification_Submitted))
				db.AddInParameter(dbCommand, "Initial_6H_Notification_Submitted", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Initial_6H_Notification_Submitted", DbType.String, this._Initial_6H_Notification_Submitted);
			
			if (string.IsNullOrEmpty(this._SixH_Compliance_Verification_Submitted))
				db.AddInParameter(dbCommand, "SixH_Compliance_Verification_Submitted", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "SixH_Compliance_Verification_Submitted", DbType.String, this._SixH_Compliance_Verification_Submitted);
			
			if (string.IsNullOrEmpty(this._Notifications_6H_Changes_Reports_Submitted))
				db.AddInParameter(dbCommand, "Notifications_6H_Changes_Reports_Submitted", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notifications_6H_Changes_Reports_Submitted", DbType.String, this._Notifications_6H_Changes_Reports_Submitted);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_CR_Chemical_Inventory table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_CR_Chemical_Inventory)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_Chemical_InventoryDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_CR_Chemical_Inventory", DbType.Decimal, pK_PM_CR_Chemical_Inventory);

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
            DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_Chemical_InventorySelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_CR_Chemical_Inventory)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Chemical_Inventory_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_CR_Chemical_Inventory", DbType.Decimal, pK_PM_CR_Chemical_Inventory);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
