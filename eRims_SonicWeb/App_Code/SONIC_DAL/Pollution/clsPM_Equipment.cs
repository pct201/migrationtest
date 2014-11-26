using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Equipment table.
	/// </summary>
	public sealed class clsPM_Equipment
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Equipment;
		private decimal? _FK_PM_Site_Information;
		private string _Table_Name;
		private decimal? _FK_Table_Name;
		private decimal? _FK_LU_Equipment_Type;
        private string _Description;
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Equipment value.
		/// </summary>
		public decimal? PK_PM_Equipment
		{
			get { return _PK_PM_Equipment; }
			set { _PK_PM_Equipment = value; }
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
		/// Gets or sets the Table_Name value.
		/// </summary>
		public string Table_Name
		{
			get { return _Table_Name; }
			set { _Table_Name = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Table_Name value.
		/// </summary>
		public decimal? FK_Table_Name
		{
			get { return _FK_Table_Name; }
			set { _FK_Table_Name = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Equipment_Type value.
		/// </summary>
		public decimal? FK_LU_Equipment_Type
		{
			get { return _FK_LU_Equipment_Type; }
			set { _FK_LU_Equipment_Type = value; }
		}
        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment class with default value.
		/// </summary>
		public clsPM_Equipment() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment class based on Primary Key.
		/// </summary>
		public clsPM_Equipment(decimal pK_PM_Equipment) 
		{
			DataTable dtPM_Equipment = SelectByPK(pK_PM_Equipment).Tables[0];

			if (dtPM_Equipment.Rows.Count == 1)
			{
				 SetValue(dtPM_Equipment.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Equipment) 
		{
				if (drPM_Equipment["PK_PM_Equipment"] == DBNull.Value)
					this._PK_PM_Equipment = null;
				else
					this._PK_PM_Equipment = (decimal?)drPM_Equipment["PK_PM_Equipment"];

				if (drPM_Equipment["FK_PM_Site_Information"] == DBNull.Value)
					this._FK_PM_Site_Information = null;
				else
					this._FK_PM_Site_Information = (decimal?)drPM_Equipment["FK_PM_Site_Information"];

				if (drPM_Equipment["Table_Name"] == DBNull.Value)
					this._Table_Name = null;
				else
					this._Table_Name = (string)drPM_Equipment["Table_Name"];

				if (drPM_Equipment["FK_Table_Name"] == DBNull.Value)
					this._FK_Table_Name = null;
				else
					this._FK_Table_Name = (decimal?)drPM_Equipment["FK_Table_Name"];

				if (drPM_Equipment["FK_LU_Equipment_Type"] == DBNull.Value)
					this._FK_LU_Equipment_Type = null;
				else
					this._FK_LU_Equipment_Type = (decimal?)drPM_Equipment["FK_LU_Equipment_Type"];

                if (drPM_Equipment["Description"] == DBNull.Value)
                    this._Description = null;
                else
                    this._Description = (string)drPM_Equipment["Description"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Equipment table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_EquipmentInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			if (string.IsNullOrEmpty(this._Table_Name))
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);
			
			db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, this._FK_Table_Name);
			
			db.AddInParameter(dbCommand, "FK_LU_Equipment_Type", DbType.Decimal, this._FK_LU_Equipment_Type);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}
        /// <summary>
        /// Inserts a record into the PM_Equipment table.
        /// </summary>
        /// <returns></returns>
        public int InsertUpdate()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_EquipmentInsertUpdate");

            db.AddInParameter(dbCommand, "PK_PM_Equipment", DbType.Decimal, this._PK_PM_Equipment);
            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);

            if (string.IsNullOrEmpty(this._Table_Name))
                db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);

            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, this._FK_Table_Name);

            db.AddInParameter(dbCommand, "FK_LU_Equipment_Type", DbType.Decimal, this._FK_LU_Equipment_Type);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }
		/// <summary>
		/// Selects a single record from the PM_Equipment table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Equipment)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_EquipmentSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Equipment", DbType.Decimal, pK_PM_Equipment);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Equipment table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_EquipmentSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Equipment table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_EquipmentUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Equipment", DbType.Decimal, this._PK_PM_Equipment);
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			if (string.IsNullOrEmpty(this._Table_Name))
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);
			
			db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, this._FK_Table_Name);
			
			db.AddInParameter(dbCommand, "FK_LU_Equipment_Type", DbType.Decimal, this._FK_LU_Equipment_Type);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Equipment table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Equipment)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_EquipmentDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Equipment", DbType.Decimal, pK_PM_Equipment);

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
            DbCommand dbCommand = db.GetStoredProcCommand("PM_EquipmentSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }

    }
}
