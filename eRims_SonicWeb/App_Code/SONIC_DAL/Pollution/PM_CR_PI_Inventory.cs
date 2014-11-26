using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_CR_PI_Inventory table.
	/// </summary>
	public sealed class PM_CR_PI_Inventory
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_CR_PI_Inventory;
		private decimal? _FK_PM_CR_Paint_Inventory;
		private string _Supplier;
		private DateTime? _Date_Purchased;
		private decimal? _Amount_Purchased;
		private decimal? _FK_LU_Units;
		private DateTime? _Start_Date;
		private DateTime? _End_Date;
		private decimal? _Amount_Used;
		private decimal? _Ending_Inventory;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_CR_PI_Inventory value.
		/// </summary>
		public decimal? PK_PM_CR_PI_Inventory
		{
			get { return _PK_PM_CR_PI_Inventory; }
			set { _PK_PM_CR_PI_Inventory = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_CR_Paint_Inventory value.
		/// </summary>
		public decimal? FK_PM_CR_Paint_Inventory
		{
			get { return _FK_PM_CR_Paint_Inventory; }
			set { _FK_PM_CR_Paint_Inventory = value; }
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
		/// Gets or sets the Amount_Used value.
		/// </summary>
		public decimal? Amount_Used
		{
			get { return _Amount_Used; }
			set { _Amount_Used = value; }
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


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_CR_PI_Inventory class with default value.
		/// </summary>
        public PM_CR_PI_Inventory() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_CR_PI_Inventory class based on Primary Key.
		/// </summary>
		public PM_CR_PI_Inventory(decimal pK_PM_CR_PI_Inventory) 
		{
			DataTable dtPM_CR_PI_Inventory = SelectByPK(pK_PM_CR_PI_Inventory).Tables[0];

			if (dtPM_CR_PI_Inventory.Rows.Count == 1)
			{
				 SetValue(dtPM_CR_PI_Inventory.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_CR_PI_Inventory class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_CR_PI_Inventory) 
		{
				if (drPM_CR_PI_Inventory["PK_PM_CR_PI_Inventory"] == DBNull.Value)
					this._PK_PM_CR_PI_Inventory = null;
				else
					this._PK_PM_CR_PI_Inventory = (decimal?)drPM_CR_PI_Inventory["PK_PM_CR_PI_Inventory"];

				if (drPM_CR_PI_Inventory["FK_PM_CR_Paint_Inventory"] == DBNull.Value)
					this._FK_PM_CR_Paint_Inventory = null;
				else
					this._FK_PM_CR_Paint_Inventory = (decimal?)drPM_CR_PI_Inventory["FK_PM_CR_Paint_Inventory"];

				if (drPM_CR_PI_Inventory["Supplier"] == DBNull.Value)
					this._Supplier = null;
				else
					this._Supplier = (string)drPM_CR_PI_Inventory["Supplier"];

				if (drPM_CR_PI_Inventory["Date_Purchased"] == DBNull.Value)
					this._Date_Purchased = null;
				else
					this._Date_Purchased = (DateTime?)drPM_CR_PI_Inventory["Date_Purchased"];

				if (drPM_CR_PI_Inventory["Amount_Purchased"] == DBNull.Value)
					this._Amount_Purchased = null;
				else
					this._Amount_Purchased = (decimal?)drPM_CR_PI_Inventory["Amount_Purchased"];

				if (drPM_CR_PI_Inventory["FK_LU_Units"] == DBNull.Value)
					this._FK_LU_Units = null;
				else
					this._FK_LU_Units = (decimal?)drPM_CR_PI_Inventory["FK_LU_Units"];

				if (drPM_CR_PI_Inventory["Start_Date"] == DBNull.Value)
					this._Start_Date = null;
				else
					this._Start_Date = (DateTime?)drPM_CR_PI_Inventory["Start_Date"];

				if (drPM_CR_PI_Inventory["End_Date"] == DBNull.Value)
					this._End_Date = null;
				else
					this._End_Date = (DateTime?)drPM_CR_PI_Inventory["End_Date"];

				if (drPM_CR_PI_Inventory["Amount_Used"] == DBNull.Value)
					this._Amount_Used = null;
				else
					this._Amount_Used = (decimal?)drPM_CR_PI_Inventory["Amount_Used"];

				if (drPM_CR_PI_Inventory["Ending_Inventory"] == DBNull.Value)
					this._Ending_Inventory = null;
				else
					this._Ending_Inventory = (decimal?)drPM_CR_PI_Inventory["Ending_Inventory"];

				if (drPM_CR_PI_Inventory["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_CR_PI_Inventory["Updated_By"];

				if (drPM_CR_PI_Inventory["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_CR_PI_Inventory["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_CR_PI_Inventory table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_PI_InventoryInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_CR_Paint_Inventory", DbType.Decimal, this._FK_PM_CR_Paint_Inventory);
			
			if (string.IsNullOrEmpty(this._Supplier))
				db.AddInParameter(dbCommand, "Supplier", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Supplier", DbType.String, this._Supplier);
			
			db.AddInParameter(dbCommand, "Date_Purchased", DbType.DateTime, this._Date_Purchased);
			
			db.AddInParameter(dbCommand, "Amount_Purchased", DbType.Decimal, this._Amount_Purchased);
			
			db.AddInParameter(dbCommand, "FK_LU_Units", DbType.Decimal, this._FK_LU_Units);
			
			db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);
			
			db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);
			
			db.AddInParameter(dbCommand, "Amount_Used", DbType.Decimal, this._Amount_Used);
			
			db.AddInParameter(dbCommand, "Ending_Inventory", DbType.Decimal, this._Ending_Inventory);
			
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
		/// Selects a single record from the PM_CR_PI_Inventory table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_CR_PI_Inventory)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_PI_InventorySelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_CR_PI_Inventory", DbType.Decimal, pK_PM_CR_PI_Inventory);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the PM_CR_PI_Inventory table by a foreign key.
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet SelectByFK(decimal fK_PM_CR_Paint_Inventory)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_PI_InventorySelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_CR_Paint_Inventory", DbType.Decimal, fK_PM_CR_Paint_Inventory);

            return db.ExecuteDataSet(dbCommand);
        }


		/// <summary>
		/// Selects all records from the PM_CR_PI_Inventory table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_PI_InventorySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_CR_PI_Inventory table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_PI_InventoryUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_CR_PI_Inventory", DbType.Decimal, this._PK_PM_CR_PI_Inventory);
			
			db.AddInParameter(dbCommand, "FK_PM_CR_Paint_Inventory", DbType.Decimal, this._FK_PM_CR_Paint_Inventory);
			
			if (string.IsNullOrEmpty(this._Supplier))
				db.AddInParameter(dbCommand, "Supplier", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Supplier", DbType.String, this._Supplier);
			
			db.AddInParameter(dbCommand, "Date_Purchased", DbType.DateTime, this._Date_Purchased);
			
			db.AddInParameter(dbCommand, "Amount_Purchased", DbType.Decimal, this._Amount_Purchased);
			
			db.AddInParameter(dbCommand, "FK_LU_Units", DbType.Decimal, this._FK_LU_Units);
			
			db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);
			
			db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);
			
			db.AddInParameter(dbCommand, "Amount_Used", DbType.Decimal, this._Amount_Used);
			
			db.AddInParameter(dbCommand, "Ending_Inventory", DbType.Decimal, this._Ending_Inventory);
			
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
		/// Deletes a record from the PM_CR_PI_Inventory table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_CR_PI_Inventory)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_PI_InventoryDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_CR_PI_Inventory", DbType.Decimal, pK_PM_CR_PI_Inventory);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_CR_PI_Inventory)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_PI_Inventory_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_CR_PI_Inventory", DbType.Decimal, pK_PM_CR_PI_Inventory);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
