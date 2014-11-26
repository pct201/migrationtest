using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Equipment_PGCC table.
	/// </summary>
	public sealed class clsPM_Equipment_PGCC
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Equipment_PGCC;
		private string _Description;
		private string _Manufacturer_Name;
		private DateTime? _Installation_Date;
		private string _Water_Borne;
		private string _Solvent_Based;
		private string _Combination_Water_Solvent;
		private string _Notes;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private decimal? _PK_PM_Equipment;
        private string _SixH_Compliant;
        private string _Manual_6H_Binder;
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Equipment_PGCC value.
		/// </summary>
		public decimal? PK_PM_Equipment_PGCC
		{
			get { return _PK_PM_Equipment_PGCC; }
			set { _PK_PM_Equipment_PGCC = value; }
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
		/// Gets or sets the Manufacturer_Name value.
		/// </summary>
		public string Manufacturer_Name
		{
			get { return _Manufacturer_Name; }
			set { _Manufacturer_Name = value; }
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
		/// Gets or sets the Water_Borne value.
		/// </summary>
		public string Water_Borne
		{
			get { return _Water_Borne; }
			set { _Water_Borne = value; }
		}

		/// <summary>
		/// Gets or sets the Solvent_Based value.
		/// </summary>
		public string Solvent_Based
		{
			get { return _Solvent_Based; }
			set { _Solvent_Based = value; }
		}

		/// <summary>
		/// Gets or sets the Combination_Water_Solvent value.
		/// </summary>
		public string Combination_Water_Solvent
		{
			get { return _Combination_Water_Solvent; }
			set { _Combination_Water_Solvent = value; }
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
        /// Gets or sets the Solvent_Based value.
        /// </summary>
        public string SixH_Compliant
        {
            get { return _SixH_Compliant; }
            set { _SixH_Compliant = value; }
        }

        /// <summary>
        /// Gets or sets the Solvent_Based value.
        /// </summary>
        public string Manual_6H_Binder
        {
            get { return _Manual_6H_Binder; }
            set { _Manual_6H_Binder = value; }
        }


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_PGCC class with default value.
		/// </summary>
		public clsPM_Equipment_PGCC() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_PGCC class based on Primary Key.
		/// </summary>
		public clsPM_Equipment_PGCC(decimal pK_PM_Equipment_PGCC) 
		{
			DataTable dtPM_Equipment_PGCC = SelectByPK(pK_PM_Equipment_PGCC).Tables[0];

			if (dtPM_Equipment_PGCC.Rows.Count == 1)
			{
				 SetValue(dtPM_Equipment_PGCC.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_PGCC class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Equipment_PGCC) 
		{
				if (drPM_Equipment_PGCC["PK_PM_Equipment_PGCC"] == DBNull.Value)
					this._PK_PM_Equipment_PGCC = null;
				else
					this._PK_PM_Equipment_PGCC = (decimal?)drPM_Equipment_PGCC["PK_PM_Equipment_PGCC"];

				if (drPM_Equipment_PGCC["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drPM_Equipment_PGCC["Description"];

				if (drPM_Equipment_PGCC["Manufacturer_Name"] == DBNull.Value)
					this._Manufacturer_Name = null;
				else
					this._Manufacturer_Name = (string)drPM_Equipment_PGCC["Manufacturer_Name"];

				if (drPM_Equipment_PGCC["Installation_Date"] == DBNull.Value)
					this._Installation_Date = null;
				else
					this._Installation_Date = (DateTime?)drPM_Equipment_PGCC["Installation_Date"];

				if (drPM_Equipment_PGCC["Water_Borne"] == DBNull.Value)
					this._Water_Borne = null;
				else
					this._Water_Borne = (string)drPM_Equipment_PGCC["Water_Borne"];

				if (drPM_Equipment_PGCC["Solvent_Based"] == DBNull.Value)
					this._Solvent_Based = null;
				else
					this._Solvent_Based = (string)drPM_Equipment_PGCC["Solvent_Based"];

				if (drPM_Equipment_PGCC["Combination_Water_Solvent"] == DBNull.Value)
					this._Combination_Water_Solvent = null;
				else
					this._Combination_Water_Solvent = (string)drPM_Equipment_PGCC["Combination_Water_Solvent"];

				if (drPM_Equipment_PGCC["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drPM_Equipment_PGCC["Notes"];

				if (drPM_Equipment_PGCC["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Equipment_PGCC["Updated_By"];

				if (drPM_Equipment_PGCC["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Equipment_PGCC["Update_Date"];

                if (drPM_Equipment_PGCC["PK_PM_Equipment"] == DBNull.Value)
                    this._PK_PM_Equipment = null;
                else
                    this._PK_PM_Equipment = (decimal?)drPM_Equipment_PGCC["PK_PM_Equipment"];

                if (drPM_Equipment_PGCC["SixH_Compliant"] == DBNull.Value)
                    this._SixH_Compliant = null;
                else
                    this._SixH_Compliant = (string)drPM_Equipment_PGCC["SixH_Compliant"];

                if (drPM_Equipment_PGCC["Manual_6H_Binder"] == DBNull.Value)
                    this._Manual_6H_Binder = null;
                else
                    this._Manual_6H_Binder = (string)drPM_Equipment_PGCC["Manual_6H_Binder"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Equipment_PGCC table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_PGCCInsert");

			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._Manufacturer_Name))
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, this._Manufacturer_Name);
			
			db.AddInParameter(dbCommand, "Installation_Date", DbType.DateTime, this._Installation_Date);
			
			if (string.IsNullOrEmpty(this._Water_Borne))
				db.AddInParameter(dbCommand, "Water_Borne", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Water_Borne", DbType.String, this._Water_Borne);
			
			if (string.IsNullOrEmpty(this._Solvent_Based))
				db.AddInParameter(dbCommand, "Solvent_Based", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Solvent_Based", DbType.String, this._Solvent_Based);
			
			if (string.IsNullOrEmpty(this._Combination_Water_Solvent))
				db.AddInParameter(dbCommand, "Combination_Water_Solvent", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Combination_Water_Solvent", DbType.String, this._Combination_Water_Solvent);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._SixH_Compliant))
                db.AddInParameter(dbCommand, "SixH_Compliant", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SixH_Compliant", DbType.String, this._SixH_Compliant);

            if (string.IsNullOrEmpty(this._Manual_6H_Binder))
                db.AddInParameter(dbCommand, "Manual_6H_Binder", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Manual_6H_Binder", DbType.String, this._Manual_6H_Binder);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_Equipment_PGCC table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Equipment_PGCC)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_PGCCSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Equipment_PGCC", DbType.Decimal, pK_PM_Equipment_PGCC);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Equipment_PGCC table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_PGCCSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Equipment_PGCC table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_PGCCUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Equipment_PGCC", DbType.Decimal, this._PK_PM_Equipment_PGCC);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._Manufacturer_Name))
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Manufacturer_Name", DbType.String, this._Manufacturer_Name);
			
			db.AddInParameter(dbCommand, "Installation_Date", DbType.DateTime, this._Installation_Date);
			
			if (string.IsNullOrEmpty(this._Water_Borne))
				db.AddInParameter(dbCommand, "Water_Borne", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Water_Borne", DbType.String, this._Water_Borne);
			
			if (string.IsNullOrEmpty(this._Solvent_Based))
				db.AddInParameter(dbCommand, "Solvent_Based", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Solvent_Based", DbType.String, this._Solvent_Based);
			
			if (string.IsNullOrEmpty(this._Combination_Water_Solvent))
				db.AddInParameter(dbCommand, "Combination_Water_Solvent", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Combination_Water_Solvent", DbType.String, this._Combination_Water_Solvent);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._SixH_Compliant))
                db.AddInParameter(dbCommand, "SixH_Compliant", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SixH_Compliant", DbType.String, this._SixH_Compliant);

            if (string.IsNullOrEmpty(this._Manual_6H_Binder))
                db.AddInParameter(dbCommand, "Manual_6H_Binder", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Manual_6H_Binder", DbType.String, this._Manual_6H_Binder);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Equipment_PGCC table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Equipment_PGCC)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_PGCCDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Equipment_PGCC", DbType.Decimal, pK_PM_Equipment_PGCC);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_Equipment_PGCC)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_PGCC_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_Equipment_PGCC", DbType.Decimal, pK_PM_Equipment_PGCC);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
