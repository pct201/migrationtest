using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Equipment_OWS_SR table.
	/// </summary>
	public sealed class clsPM_Equipment_OWS_SR
	{
		#region Private variables used to hold the property values

		private decimal? _PK_PM_Equipment_OWS_SR;
		private decimal? _FK_PM_Equipment_OWS;
		private DateTime? _Sludge_Removal_Date;
		private string _Sludge_Removed_By;
		private string _Notes;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private string _TCLP;
        private string _TCLP_On_File;
        private DateTime? _TCLP_Conducted;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Equipment_OWS_SR value.
		/// </summary>
		public decimal? PK_PM_Equipment_OWS_SR
		{
			get { return _PK_PM_Equipment_OWS_SR; }
			set { _PK_PM_Equipment_OWS_SR = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_Equipment_OWS value.
		/// </summary>
		public decimal? FK_PM_Equipment_OWS
		{
			get { return _FK_PM_Equipment_OWS; }
			set { _FK_PM_Equipment_OWS = value; }
		}

		/// <summary>
		/// Gets or sets the Sludge_Removal_Date value.
		/// </summary>
		public DateTime? Sludge_Removal_Date
		{
			get { return _Sludge_Removal_Date; }
			set { _Sludge_Removal_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Sludge_Removed_By value.
		/// </summary>
		public string Sludge_Removed_By
		{
			get { return _Sludge_Removed_By; }
			set { _Sludge_Removed_By = value; }
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

        public string TCLP
        {
            get { return _TCLP; }
            set { _TCLP = value; }
        }

        public string TCLP_On_File
        {
            get { return _TCLP_On_File; }
            set { _TCLP_On_File = value; }
        }

        public DateTime? TCLP_Conducted
        {
            get { return _TCLP_Conducted; }
            set { _TCLP_Conducted = value; }
        }


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_OWS_SR class with default value.
		/// </summary>
		public clsPM_Equipment_OWS_SR() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_OWS_SR class based on Primary Key.
		/// </summary>
		public clsPM_Equipment_OWS_SR(decimal pK_PM_Equipment_OWS_SR) 
		{
			DataTable dtPM_Equipment_OWS_SR = SelectByPK(pK_PM_Equipment_OWS_SR).Tables[0];

			if (dtPM_Equipment_OWS_SR.Rows.Count == 1)
			{
				 SetValue(dtPM_Equipment_OWS_SR.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_OWS_SR class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Equipment_OWS_SR) 
		{
				if (drPM_Equipment_OWS_SR["PK_PM_Equipment_OWS_SR"] == DBNull.Value)
					this._PK_PM_Equipment_OWS_SR = null;
				else
					this._PK_PM_Equipment_OWS_SR = (decimal?)drPM_Equipment_OWS_SR["PK_PM_Equipment_OWS_SR"];

				if (drPM_Equipment_OWS_SR["FK_PM_Equipment_OWS"] == DBNull.Value)
					this._FK_PM_Equipment_OWS = null;
				else
					this._FK_PM_Equipment_OWS = (decimal?)drPM_Equipment_OWS_SR["FK_PM_Equipment_OWS"];

				if (drPM_Equipment_OWS_SR["Sludge_Removal_Date"] == DBNull.Value)
					this._Sludge_Removal_Date = null;
				else
					this._Sludge_Removal_Date = (DateTime?)drPM_Equipment_OWS_SR["Sludge_Removal_Date"];

				if (drPM_Equipment_OWS_SR["Sludge_Removed_By"] == DBNull.Value)
					this._Sludge_Removed_By = null;
				else
					this._Sludge_Removed_By = (string)drPM_Equipment_OWS_SR["Sludge_Removed_By"];

				if (drPM_Equipment_OWS_SR["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drPM_Equipment_OWS_SR["Notes"];

				if (drPM_Equipment_OWS_SR["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Equipment_OWS_SR["Updated_By"];

				if (drPM_Equipment_OWS_SR["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Equipment_OWS_SR["Update_Date"];

                if (drPM_Equipment_OWS_SR["TCLP_On_File"] == DBNull.Value)
                    this._TCLP_On_File = null;
                else
                    this._TCLP_On_File = (string)drPM_Equipment_OWS_SR["TCLP_On_File"];

                if (drPM_Equipment_OWS_SR["TCLP"] == DBNull.Value)
                    this._TCLP = null;
                else
                    this._TCLP = (string)drPM_Equipment_OWS_SR["TCLP"];

                if (drPM_Equipment_OWS_SR["TCLP_Conducted"] == DBNull.Value)
                    this._TCLP_Conducted = null;
                else
                    this._TCLP_Conducted = (DateTime?)drPM_Equipment_OWS_SR["TCLP_Conducted"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Equipment_OWS_SR table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_OWS_SRInsert");
			
			db.AddInParameter(dbCommand, "FK_PM_Equipment_OWS", DbType.Decimal, this._FK_PM_Equipment_OWS);
			
			db.AddInParameter(dbCommand, "Sludge_Removal_Date", DbType.DateTime, this._Sludge_Removal_Date);
			
			if (string.IsNullOrEmpty(this._Sludge_Removed_By))
				db.AddInParameter(dbCommand, "Sludge_Removed_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sludge_Removed_By", DbType.String, this._Sludge_Removed_By);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._TCLP))
                db.AddInParameter(dbCommand, "TCLP", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "TCLP", DbType.String, this._TCLP);

            if (string.IsNullOrEmpty(this._TCLP_On_File))
                db.AddInParameter(dbCommand, "TCLP_On_File", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "TCLP_On_File", DbType.String, this._TCLP_On_File);

            db.AddInParameter(dbCommand, "TCLP_Conducted", DbType.DateTime, this._TCLP_Conducted);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_Equipment_OWS_SR table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Equipment_OWS_SR)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_OWS_SRSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Equipment_OWS_SR", DbType.Decimal, pK_PM_Equipment_OWS_SR);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Equipment_OWS_SR table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_OWS_SRSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Equipment_OWS_SR table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_OWS_SRUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Equipment_OWS_SR", DbType.Decimal, this._PK_PM_Equipment_OWS_SR);
			
			db.AddInParameter(dbCommand, "FK_PM_Equipment_OWS", DbType.Decimal, this._FK_PM_Equipment_OWS);
			
			db.AddInParameter(dbCommand, "Sludge_Removal_Date", DbType.DateTime, this._Sludge_Removal_Date);
			
			if (string.IsNullOrEmpty(this._Sludge_Removed_By))
				db.AddInParameter(dbCommand, "Sludge_Removed_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sludge_Removed_By", DbType.String, this._Sludge_Removed_By);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._TCLP))
                db.AddInParameter(dbCommand, "TCLP", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "TCLP", DbType.String, this._TCLP);

            if (string.IsNullOrEmpty(this._TCLP_On_File))
                db.AddInParameter(dbCommand, "TCLP_On_File", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "TCLP_On_File", DbType.String, this._TCLP_On_File);

            db.AddInParameter(dbCommand, "TCLP_Conducted", DbType.DateTime, this._TCLP_Conducted);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Equipment_OWS_SR table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Equipment_OWS_SR)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_OWS_SRDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Equipment_OWS_SR", DbType.Decimal, pK_PM_Equipment_OWS_SR);

			db.ExecuteNonQuery(dbCommand);
		}
        /// <summary>
        /// Selects all records from the PM_CR_CI_Hazards table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllByFK(decimal _FK_PM_Equipment_OWS)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_OWS_SRSelectByFK");
            db.AddInParameter(dbCommand, "FK_PM_Equipment_OWS", DbType.Decimal, _FK_PM_Equipment_OWS);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_Equipment_OWS_SR)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_OWS_SR_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_Equipment_OWS_SR", DbType.Decimal, pK_PM_Equipment_OWS_SR);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
