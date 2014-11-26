using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_CR_Paint_Inventory table.
	/// </summary>
	public sealed class PM_CR_Paint_Inventory
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_CR_Paint_Inventory;
		private decimal? _FK_PM_Compliance_Reporting;
		private decimal? _FK_LU_Paint_Type;
		private string _CAS_Number;
		private string _Pure_Mixture;
		private string _Mixture_Components;
		private string _Product_Identification_Number;
		private string _Product_Name;
		private string _Manufacturer;
		private string _Synonyms;
		private DateTime? _Issue_Date;
		private string _Edition_Number;
		private decimal? _FK_LU_Chemical_Family;
		private string _MSDS_Number;
		private string _Emergency_Overview;
		private string _Composition_Information;
		private decimal? _FK_LU_Storage_Type;
		private decimal? _FK_LU_Storage_Location;
		private string _Supplier;
		private DateTime? _Date_Purchased;
		private decimal? _Amount_Purchased;
		private decimal? _FK_LU_Units;
		private DateTime? _Start_Date;
		private DateTime? _End_Date;
		private decimal? _Ammount_Used;
		private decimal? _Ending_Inventory;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private string _Paint_Color;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_CR_Paint_Inventory value.
		/// </summary>
		public decimal? PK_PM_CR_Paint_Inventory
		{
			get { return _PK_PM_CR_Paint_Inventory; }
			set { _PK_PM_CR_Paint_Inventory = value; }
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
		/// Gets or sets the FK_LU_Paint_Type value.
		/// </summary>
		public decimal? FK_LU_Paint_Type
		{
			get { return _FK_LU_Paint_Type; }
			set { _FK_LU_Paint_Type = value; }
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
		/// Gets or sets the Product_Identification_Number value.
		/// </summary>
		public string Product_Identification_Number
		{
			get { return _Product_Identification_Number; }
			set { _Product_Identification_Number = value; }
		}

		/// <summary>
		/// Gets or sets the Product_Name value.
		/// </summary>
		public string Product_Name
		{
			get { return _Product_Name; }
			set { _Product_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Manufacturer value.
		/// </summary>
		public string Manufacturer
		{
			get { return _Manufacturer; }
			set { _Manufacturer = value; }
		}

		/// <summary>
		/// Gets or sets the Synonyms value.
		/// </summary>
		public string Synonyms
		{
			get { return _Synonyms; }
			set { _Synonyms = value; }
		}

		/// <summary>
		/// Gets or sets the Issue_Date value.
		/// </summary>
		public DateTime? Issue_Date
		{
			get { return _Issue_Date; }
			set { _Issue_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Edition_Number value.
		/// </summary>
		public string Edition_Number
		{
			get { return _Edition_Number; }
			set { _Edition_Number = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Chemical_Family value.
		/// </summary>
		public decimal? FK_LU_Chemical_Family
		{
			get { return _FK_LU_Chemical_Family; }
			set { _FK_LU_Chemical_Family = value; }
		}

		/// <summary>
		/// Gets or sets the MSDS_Number value.
		/// </summary>
		public string MSDS_Number
		{
			get { return _MSDS_Number; }
			set { _MSDS_Number = value; }
		}

		/// <summary>
		/// Gets or sets the Emergency_Overview value.
		/// </summary>
		public string Emergency_Overview
		{
			get { return _Emergency_Overview; }
			set { _Emergency_Overview = value; }
		}

		/// <summary>
		/// Gets or sets the Composition_Information value.
		/// </summary>
		public string Composition_Information
		{
			get { return _Composition_Information; }
			set { _Composition_Information = value; }
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
		/// Gets or sets the Supplier value.
		/// </summary>
		public string Supplier
		{
			get { return _Supplier; }
			set { _Supplier = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Purchased value.
		/// </summary>
		public DateTime? Date_Purchased
		{
			get { return _Date_Purchased; }
			set { _Date_Purchased = value; }
		}

		/// <summary>
		/// Gets or sets the Amount_Purchased value.
		/// </summary>
		public decimal? Amount_Purchased
		{
			get { return _Amount_Purchased; }
			set { _Amount_Purchased = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Units value.
		/// </summary>
		public decimal? FK_LU_Units
		{
			get { return _FK_LU_Units; }
			set { _FK_LU_Units = value; }
		}

		/// <summary>
		/// Gets or sets the Start_Date value.
		/// </summary>
		public DateTime? Start_Date
		{
			get { return _Start_Date; }
			set { _Start_Date = value; }
		}

		/// <summary>
		/// Gets or sets the End_Date value.
		/// </summary>
		public DateTime? End_Date
		{
			get { return _End_Date; }
			set { _End_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Ammount_Used value.
		/// </summary>
		public decimal? Ammount_Used
		{
			get { return _Ammount_Used; }
			set { _Ammount_Used = value; }
		}

		/// <summary>
		/// Gets or sets the Ending_Inventory value.
		/// </summary>
		public decimal? Ending_Inventory
		{
			get { return _Ending_Inventory; }
			set { _Ending_Inventory = value; }
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
        /// Gets or sets the Paint_Color value.
        /// </summary>
        public string Paint_Color
        {
            get { return _Paint_Color; }
            set { _Paint_Color = value; }
        }


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_CR_Paint_Inventory class with default value.
		/// </summary>
		public PM_CR_Paint_Inventory() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_CR_Paint_Inventory class based on Primary Key.
		/// </summary>
		public PM_CR_Paint_Inventory(decimal pK_PM_CR_Paint_Inventory) 
		{
			DataTable dtPM_CR_Paint_Inventory = SelectByPK(pK_PM_CR_Paint_Inventory).Tables[0];

			if (dtPM_CR_Paint_Inventory.Rows.Count == 1)
			{
				 SetValue(dtPM_CR_Paint_Inventory.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_CR_Paint_Inventory class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_CR_Paint_Inventory) 
		{
				if (drPM_CR_Paint_Inventory["PK_PM_CR_Paint_Inventory"] == DBNull.Value)
					this._PK_PM_CR_Paint_Inventory = null;
				else
					this._PK_PM_CR_Paint_Inventory = (decimal?)drPM_CR_Paint_Inventory["PK_PM_CR_Paint_Inventory"];

				if (drPM_CR_Paint_Inventory["FK_PM_Compliance_Reporting"] == DBNull.Value)
					this._FK_PM_Compliance_Reporting = null;
				else
					this._FK_PM_Compliance_Reporting = (decimal?)drPM_CR_Paint_Inventory["FK_PM_Compliance_Reporting"];

				if (drPM_CR_Paint_Inventory["FK_LU_Paint_Type"] == DBNull.Value)
					this._FK_LU_Paint_Type = null;
				else
					this._FK_LU_Paint_Type = (decimal?)drPM_CR_Paint_Inventory["FK_LU_Paint_Type"];

				if (drPM_CR_Paint_Inventory["CAS_Number"] == DBNull.Value)
					this._CAS_Number = null;
				else
					this._CAS_Number = (string)drPM_CR_Paint_Inventory["CAS_Number"];

				if (drPM_CR_Paint_Inventory["Pure_Mixture"] == DBNull.Value)
					this._Pure_Mixture = null;
				else
					this._Pure_Mixture = (string)drPM_CR_Paint_Inventory["Pure_Mixture"];

				if (drPM_CR_Paint_Inventory["Mixture_Components"] == DBNull.Value)
					this._Mixture_Components = null;
				else
					this._Mixture_Components = (string)drPM_CR_Paint_Inventory["Mixture_Components"];

				if (drPM_CR_Paint_Inventory["Product_Identification_Number"] == DBNull.Value)
					this._Product_Identification_Number = null;
				else
					this._Product_Identification_Number = (string)drPM_CR_Paint_Inventory["Product_Identification_Number"];

				if (drPM_CR_Paint_Inventory["Product_Name"] == DBNull.Value)
					this._Product_Name = null;
				else
					this._Product_Name = (string)drPM_CR_Paint_Inventory["Product_Name"];

				if (drPM_CR_Paint_Inventory["Manufacturer"] == DBNull.Value)
					this._Manufacturer = null;
				else
					this._Manufacturer = (string)drPM_CR_Paint_Inventory["Manufacturer"];

				if (drPM_CR_Paint_Inventory["Synonyms"] == DBNull.Value)
					this._Synonyms = null;
				else
					this._Synonyms = (string)drPM_CR_Paint_Inventory["Synonyms"];

				if (drPM_CR_Paint_Inventory["Issue_Date"] == DBNull.Value)
					this._Issue_Date = null;
				else
					this._Issue_Date = (DateTime?)drPM_CR_Paint_Inventory["Issue_Date"];

				if (drPM_CR_Paint_Inventory["Edition_Number"] == DBNull.Value)
					this._Edition_Number = null;
				else
					this._Edition_Number = (string)drPM_CR_Paint_Inventory["Edition_Number"];

				if (drPM_CR_Paint_Inventory["FK_LU_Chemical_Family"] == DBNull.Value)
					this._FK_LU_Chemical_Family = null;
				else
					this._FK_LU_Chemical_Family = (decimal?)drPM_CR_Paint_Inventory["FK_LU_Chemical_Family"];

				if (drPM_CR_Paint_Inventory["MSDS_Number"] == DBNull.Value)
					this._MSDS_Number = null;
				else
					this._MSDS_Number = (string)drPM_CR_Paint_Inventory["MSDS_Number"];

				if (drPM_CR_Paint_Inventory["Emergency_Overview"] == DBNull.Value)
					this._Emergency_Overview = null;
				else
					this._Emergency_Overview = (string)drPM_CR_Paint_Inventory["Emergency_Overview"];

				if (drPM_CR_Paint_Inventory["Composition_Information"] == DBNull.Value)
					this._Composition_Information = null;
				else
					this._Composition_Information = (string)drPM_CR_Paint_Inventory["Composition_Information"];

				if (drPM_CR_Paint_Inventory["FK_LU_Storage_Type"] == DBNull.Value)
					this._FK_LU_Storage_Type = null;
				else
					this._FK_LU_Storage_Type = (decimal?)drPM_CR_Paint_Inventory["FK_LU_Storage_Type"];

				if (drPM_CR_Paint_Inventory["FK_LU_Storage_Location"] == DBNull.Value)
					this._FK_LU_Storage_Location = null;
				else
					this._FK_LU_Storage_Location = (decimal?)drPM_CR_Paint_Inventory["FK_LU_Storage_Location"];

				if (drPM_CR_Paint_Inventory["Supplier"] == DBNull.Value)
					this._Supplier = null;
				else
					this._Supplier = (string)drPM_CR_Paint_Inventory["Supplier"];

				if (drPM_CR_Paint_Inventory["Date_Purchased"] == DBNull.Value)
					this._Date_Purchased = null;
				else
					this._Date_Purchased = (DateTime?)drPM_CR_Paint_Inventory["Date_Purchased"];

				if (drPM_CR_Paint_Inventory["Amount_Purchased"] == DBNull.Value)
					this._Amount_Purchased = null;
				else
					this._Amount_Purchased = (decimal?)drPM_CR_Paint_Inventory["Amount_Purchased"];

				if (drPM_CR_Paint_Inventory["FK_LU_Units"] == DBNull.Value)
					this._FK_LU_Units = null;
				else
					this._FK_LU_Units = (decimal?)drPM_CR_Paint_Inventory["FK_LU_Units"];

				if (drPM_CR_Paint_Inventory["Start_Date"] == DBNull.Value)
					this._Start_Date = null;
				else
					this._Start_Date = (DateTime?)drPM_CR_Paint_Inventory["Start_Date"];

				if (drPM_CR_Paint_Inventory["End_Date"] == DBNull.Value)
					this._End_Date = null;
				else
					this._End_Date = (DateTime?)drPM_CR_Paint_Inventory["End_Date"];

				if (drPM_CR_Paint_Inventory["Ammount_Used"] == DBNull.Value)
					this._Ammount_Used = null;
				else
					this._Ammount_Used = (decimal?)drPM_CR_Paint_Inventory["Ammount_Used"];

				if (drPM_CR_Paint_Inventory["Ending_Inventory"] == DBNull.Value)
					this._Ending_Inventory = null;
				else
					this._Ending_Inventory = (decimal?)drPM_CR_Paint_Inventory["Ending_Inventory"];

				if (drPM_CR_Paint_Inventory["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_CR_Paint_Inventory["Updated_By"];

				if (drPM_CR_Paint_Inventory["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_CR_Paint_Inventory["Update_Date"];

                if (drPM_CR_Paint_Inventory["Paint_Color"] == DBNull.Value)
                    this._Paint_Color = null;
                else
                    this._Paint_Color = (string)drPM_CR_Paint_Inventory["Paint_Color"];

		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_CR_Paint_Inventory table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_Paint_InventoryInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Compliance_Reporting", DbType.Decimal, this._FK_PM_Compliance_Reporting);
			
			db.AddInParameter(dbCommand, "FK_LU_Paint_Type", DbType.Decimal, this._FK_LU_Paint_Type);
			
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
			
			if (string.IsNullOrEmpty(this._Product_Identification_Number))
				db.AddInParameter(dbCommand, "Product_Identification_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Product_Identification_Number", DbType.String, this._Product_Identification_Number);
			
			if (string.IsNullOrEmpty(this._Product_Name))
				db.AddInParameter(dbCommand, "Product_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Product_Name", DbType.String, this._Product_Name);
			
			if (string.IsNullOrEmpty(this._Manufacturer))
				db.AddInParameter(dbCommand, "Manufacturer", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Manufacturer", DbType.String, this._Manufacturer);
			
			if (string.IsNullOrEmpty(this._Synonyms))
				db.AddInParameter(dbCommand, "Synonyms", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Synonyms", DbType.String, this._Synonyms);
			
			db.AddInParameter(dbCommand, "Issue_Date", DbType.DateTime, this._Issue_Date);
			
			if (string.IsNullOrEmpty(this._Edition_Number))
				db.AddInParameter(dbCommand, "Edition_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Edition_Number", DbType.String, this._Edition_Number);
			
			db.AddInParameter(dbCommand, "FK_LU_Chemical_Family", DbType.Decimal, this._FK_LU_Chemical_Family);
			
			if (string.IsNullOrEmpty(this._MSDS_Number))
				db.AddInParameter(dbCommand, "MSDS_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "MSDS_Number", DbType.String, this._MSDS_Number);
			
			if (string.IsNullOrEmpty(this._Emergency_Overview))
				db.AddInParameter(dbCommand, "Emergency_Overview", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Emergency_Overview", DbType.String, this._Emergency_Overview);
			
			if (string.IsNullOrEmpty(this._Composition_Information))
				db.AddInParameter(dbCommand, "Composition_Information", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Composition_Information", DbType.String, this._Composition_Information);
			
			db.AddInParameter(dbCommand, "FK_LU_Storage_Type", DbType.Decimal, this._FK_LU_Storage_Type);
			
			db.AddInParameter(dbCommand, "FK_LU_Storage_Location", DbType.Decimal, this._FK_LU_Storage_Location);
			
			if (string.IsNullOrEmpty(this._Supplier))
				db.AddInParameter(dbCommand, "Supplier", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Supplier", DbType.String, this._Supplier);
			
			db.AddInParameter(dbCommand, "Date_Purchased", DbType.DateTime, this._Date_Purchased);
			
			db.AddInParameter(dbCommand, "Amount_Purchased", DbType.Decimal, this._Amount_Purchased);
			
			db.AddInParameter(dbCommand, "FK_LU_Units", DbType.Decimal, this._FK_LU_Units);
			
			db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);
			
			db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);
			
			db.AddInParameter(dbCommand, "Ammount_Used", DbType.Decimal, this._Ammount_Used);
			
			db.AddInParameter(dbCommand, "Ending_Inventory", DbType.Decimal, this._Ending_Inventory);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Paint_Color))
                db.AddInParameter(dbCommand, "Paint_Color", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Paint_Color", DbType.String, this._Paint_Color);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_CR_Paint_Inventory table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_CR_Paint_Inventory)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_Paint_InventorySelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_CR_Paint_Inventory", DbType.Decimal, pK_PM_CR_Paint_Inventory);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_CR_Paint_Inventory table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_Paint_InventorySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_CR_Paint_Inventory table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_Paint_InventoryUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_CR_Paint_Inventory", DbType.Decimal, this._PK_PM_CR_Paint_Inventory);
			
			db.AddInParameter(dbCommand, "FK_PM_Compliance_Reporting", DbType.Decimal, this._FK_PM_Compliance_Reporting);
			
			db.AddInParameter(dbCommand, "FK_LU_Paint_Type", DbType.Decimal, this._FK_LU_Paint_Type);
			
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
			
			if (string.IsNullOrEmpty(this._Product_Identification_Number))
				db.AddInParameter(dbCommand, "Product_Identification_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Product_Identification_Number", DbType.String, this._Product_Identification_Number);
			
			if (string.IsNullOrEmpty(this._Product_Name))
				db.AddInParameter(dbCommand, "Product_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Product_Name", DbType.String, this._Product_Name);
			
			if (string.IsNullOrEmpty(this._Manufacturer))
				db.AddInParameter(dbCommand, "Manufacturer", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Manufacturer", DbType.String, this._Manufacturer);
			
			if (string.IsNullOrEmpty(this._Synonyms))
				db.AddInParameter(dbCommand, "Synonyms", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Synonyms", DbType.String, this._Synonyms);
			
			db.AddInParameter(dbCommand, "Issue_Date", DbType.DateTime, this._Issue_Date);
			
			if (string.IsNullOrEmpty(this._Edition_Number))
				db.AddInParameter(dbCommand, "Edition_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Edition_Number", DbType.String, this._Edition_Number);
			
			db.AddInParameter(dbCommand, "FK_LU_Chemical_Family", DbType.Decimal, this._FK_LU_Chemical_Family);
			
			if (string.IsNullOrEmpty(this._MSDS_Number))
				db.AddInParameter(dbCommand, "MSDS_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "MSDS_Number", DbType.String, this._MSDS_Number);
			
			if (string.IsNullOrEmpty(this._Emergency_Overview))
				db.AddInParameter(dbCommand, "Emergency_Overview", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Emergency_Overview", DbType.String, this._Emergency_Overview);
			
			if (string.IsNullOrEmpty(this._Composition_Information))
				db.AddInParameter(dbCommand, "Composition_Information", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Composition_Information", DbType.String, this._Composition_Information);
			
			db.AddInParameter(dbCommand, "FK_LU_Storage_Type", DbType.Decimal, this._FK_LU_Storage_Type);
			
			db.AddInParameter(dbCommand, "FK_LU_Storage_Location", DbType.Decimal, this._FK_LU_Storage_Location);
			
			if (string.IsNullOrEmpty(this._Supplier))
				db.AddInParameter(dbCommand, "Supplier", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Supplier", DbType.String, this._Supplier);
			
			db.AddInParameter(dbCommand, "Date_Purchased", DbType.DateTime, this._Date_Purchased);
			
			db.AddInParameter(dbCommand, "Amount_Purchased", DbType.Decimal, this._Amount_Purchased);
			
			db.AddInParameter(dbCommand, "FK_LU_Units", DbType.Decimal, this._FK_LU_Units);
			
			db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);
			
			db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);
			
			db.AddInParameter(dbCommand, "Ammount_Used", DbType.Decimal, this._Ammount_Used);
			
			db.AddInParameter(dbCommand, "Ending_Inventory", DbType.Decimal, this._Ending_Inventory);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Paint_Color))
                db.AddInParameter(dbCommand, "Paint_Color", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Paint_Color", DbType.String, this._Paint_Color);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the PM_CR_Paint_Inventory table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_CR_Paint_Inventory)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_Paint_InventoryDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_CR_Paint_Inventory", DbType.Decimal, pK_PM_CR_Paint_Inventory);

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
            DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_Paint_InventorySelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_CR_Paint_Inventory)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Paint_Inventory_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_CR_Paint_Inventory", DbType.Decimal, pK_PM_CR_Paint_Inventory);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
