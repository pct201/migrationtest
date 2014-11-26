using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Equipment_Hydraulic_Lift table.
	/// </summary>
	public sealed class clsPM_Equipment_Hydraulic_Lift
	{
		#region Private variables used to hold the property values

		private decimal? _PK_PM_Equipment_Hydraulic_Lift;		
		private string _Any_Inground_Lifts_Been_Removed;
		private string _Documentation_Related_To_Removed_Lifts;	
		private string _Updated_By;
		private DateTime? _Update_Date;
        private decimal? _PK_PM_Equipment;
        private string _Use_Same_Dates;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Equipment_Hydraulic_Lift value.
		/// </summary>
		public decimal? PK_PM_Equipment_Hydraulic_Lift
		{
			get { return _PK_PM_Equipment_Hydraulic_Lift; }
			set { _PK_PM_Equipment_Hydraulic_Lift = value; }
		}
		
		/// <summary>
		/// Gets or sets the Any_Inground_Lifts_Been_Removed value.
		/// </summary>
		public string Any_Inground_Lifts_Been_Removed
		{
			get { return _Any_Inground_Lifts_Been_Removed; }
			set { _Any_Inground_Lifts_Been_Removed = value; }
		}

		/// <summary>
		/// Gets or sets the Documentation_Related_To_Removed_Lifts value.
		/// </summary>
		public string Documentation_Related_To_Removed_Lifts
		{
			get { return _Documentation_Related_To_Removed_Lifts; }
			set { _Documentation_Related_To_Removed_Lifts = value; }
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

        public string Use_Same_Dates
        {
            get{return _Use_Same_Dates;}
            set { _Use_Same_Dates = value; }
        }

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_Hydraulic_Lift class with default value.
		/// </summary>
		public clsPM_Equipment_Hydraulic_Lift() 
		{
		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_Hydraulic_Lift class based on Primary Key.
		/// </summary>
		public clsPM_Equipment_Hydraulic_Lift(decimal pK_PM_Equipment_Hydraulic_Lift) 
		{
			DataTable dtPM_Equipment_Hydraulic_Lift = SelectByPK(pK_PM_Equipment_Hydraulic_Lift).Tables[0];

			if (dtPM_Equipment_Hydraulic_Lift.Rows.Count == 1)
			{
				 SetValue(dtPM_Equipment_Hydraulic_Lift.Rows[0]);
			}
		}


		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_Hydraulic_Lift class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Equipment_Hydraulic_Lift) 
		{
				if (drPM_Equipment_Hydraulic_Lift["PK_PM_Equipment_Hydraulic_Lift"] == DBNull.Value)
					this._PK_PM_Equipment_Hydraulic_Lift = null;
				else
					this._PK_PM_Equipment_Hydraulic_Lift = (decimal?)drPM_Equipment_Hydraulic_Lift["PK_PM_Equipment_Hydraulic_Lift"];

				if (drPM_Equipment_Hydraulic_Lift["Any_Inground_Lifts_Been_Removed"] == DBNull.Value)
					this._Any_Inground_Lifts_Been_Removed = null;
				else
					this._Any_Inground_Lifts_Been_Removed = (string)drPM_Equipment_Hydraulic_Lift["Any_Inground_Lifts_Been_Removed"];

				if (drPM_Equipment_Hydraulic_Lift["Documentation_Related_To_Removed_Lifts"] == DBNull.Value)
					this._Documentation_Related_To_Removed_Lifts = null;
				else
					this._Documentation_Related_To_Removed_Lifts = (string)drPM_Equipment_Hydraulic_Lift["Documentation_Related_To_Removed_Lifts"];				

				if (drPM_Equipment_Hydraulic_Lift["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Equipment_Hydraulic_Lift["Updated_By"];

				if (drPM_Equipment_Hydraulic_Lift["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Equipment_Hydraulic_Lift["Update_Date"];

                if (drPM_Equipment_Hydraulic_Lift["PK_PM_Equipment"] == DBNull.Value)
                    this._PK_PM_Equipment = null;
                else
                    this._PK_PM_Equipment = (decimal?)drPM_Equipment_Hydraulic_Lift["PK_PM_Equipment"];

                if (drPM_Equipment_Hydraulic_Lift["Use_Same_Dates"] == DBNull.Value)
                    this._Use_Same_Dates = null;
                else
                    this._Use_Same_Dates = (string)drPM_Equipment_Hydraulic_Lift["Use_Same_Dates"];			
		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Equipment_Hydraulic_Lift table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Hydraulic_LiftInsert");
			
			if (string.IsNullOrEmpty(this._Any_Inground_Lifts_Been_Removed))
				db.AddInParameter(dbCommand, "Any_Inground_Lifts_Been_Removed", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Any_Inground_Lifts_Been_Removed", DbType.String, this._Any_Inground_Lifts_Been_Removed);
			
			if (string.IsNullOrEmpty(this._Documentation_Related_To_Removed_Lifts))
				db.AddInParameter(dbCommand, "Documentation_Related_To_Removed_Lifts", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Documentation_Related_To_Removed_Lifts", DbType.String, this._Documentation_Related_To_Removed_Lifts);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Use_Same_Dates))
                db.AddInParameter(dbCommand, "Use_Same_Dates", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Use_Same_Dates", DbType.String, this._Use_Same_Dates);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_Equipment_Hydraulic_Lift table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Equipment_Hydraulic_Lift)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Hydraulic_LiftSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Equipment_Hydraulic_Lift", DbType.Decimal, pK_PM_Equipment_Hydraulic_Lift);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Equipment_Hydraulic_Lift table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Hydraulic_LiftSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Equipment_Hydraulic_Lift table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Hydraulic_LiftUpdate");
			
			db.AddInParameter(dbCommand, "PK_PM_Equipment_Hydraulic_Lift", DbType.Decimal, this._PK_PM_Equipment_Hydraulic_Lift);
			
			if (string.IsNullOrEmpty(this._Any_Inground_Lifts_Been_Removed))
				db.AddInParameter(dbCommand, "Any_Inground_Lifts_Been_Removed", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Any_Inground_Lifts_Been_Removed", DbType.String, this._Any_Inground_Lifts_Been_Removed);
			
			if (string.IsNullOrEmpty(this._Documentation_Related_To_Removed_Lifts))
				db.AddInParameter(dbCommand, "Documentation_Related_To_Removed_Lifts", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Documentation_Related_To_Removed_Lifts", DbType.String, this._Documentation_Related_To_Removed_Lifts);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Use_Same_Dates))
                db.AddInParameter(dbCommand, "Use_Same_Dates", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Use_Same_Dates", DbType.String, this._Use_Same_Dates);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Equipment_Hydraulic_Lift table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Equipment_Hydraulic_Lift)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Hydraulic_LiftDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Equipment_Hydraulic_Lift", DbType.Decimal, pK_PM_Equipment_Hydraulic_Lift);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_Equipment_Hydraulic_Lift)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Hydraulic_Lift_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_Equipment_Hydraulic_Lift", DbType.Decimal, pK_PM_Equipment_Hydraulic_Lift);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
