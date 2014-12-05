using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace BAL
{
	/// <summary>
	/// Data access class for table Sedgwick_Claim_Action_Plan
	/// </summary>
	public sealed class Sedgwick_Claim_Action_Plan
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Sedgwick_Claim_Action_Plan;
		private decimal? _FK_Sedgwick_Claim_Review;
		private string _Management_Section;
		private decimal? _Sort_Order;
		private string _RLCM_Sedgwick;
		private string _Action_Item;
		private DateTime? _Target_Date;
		private DateTime? _Actual_Date;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private string _Completed;
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Sedgwick_Claim_Action_Plan value.
		/// </summary>
		public decimal? PK_Sedgwick_Claim_Action_Plan
		{
			get { return _PK_Sedgwick_Claim_Action_Plan; }
			set { _PK_Sedgwick_Claim_Action_Plan = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Sedgwick_Claim_Review value.
		/// </summary>
		public decimal? FK_Sedgwick_Claim_Review
		{
			get { return _FK_Sedgwick_Claim_Review; }
			set { _FK_Sedgwick_Claim_Review = value; }
		}

		/// <summary>
		/// Gets or sets the Management_Section value.
		/// </summary>
		public string Management_Section
		{
			get { return _Management_Section; }
			set { _Management_Section = value; }
		}

		/// <summary>
		/// Gets or sets the Sort_Order value.
		/// </summary>
		public decimal? Sort_Order
		{
			get { return _Sort_Order; }
			set { _Sort_Order = value; }
		}

		/// <summary>
		/// Gets or sets the RLCM_Sedgwick value.
		/// </summary>
		public string RLCM_Sedgwick
		{
			get { return _RLCM_Sedgwick; }
			set { _RLCM_Sedgwick = value; }
		}

		/// <summary>
		/// Gets or sets the Action_Item value.
		/// </summary>
		public string Action_Item
		{
			get { return _Action_Item; }
			set { _Action_Item = value; }
		}

		/// <summary>
		/// Gets or sets the Target_Date value.
		/// </summary>
		public DateTime? Target_Date
		{
			get { return _Target_Date; }
			set { _Target_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Actual_Date value.
		/// </summary>
		public DateTime? Actual_Date
		{
			get { return _Actual_Date; }
			set { _Actual_Date = value; }
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
        /// Gets or sets the Completed value.
        /// </summary>
        public string Completed
        {
            get { return _Completed; }
            set { _Completed = value; }
        }

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Sedgwick_Claim_Action_Plan class with default value.
		/// </summary>
		public Sedgwick_Claim_Action_Plan() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Sedgwick_Claim_Action_Plan class based on Primary Key.
		/// </summary>
		public Sedgwick_Claim_Action_Plan(decimal pK_Sedgwick_Claim_Action_Plan) 
		{
			DataTable dtSedgwick_Claim_Action_Plan = Select(pK_Sedgwick_Claim_Action_Plan).Tables[0];

			if (dtSedgwick_Claim_Action_Plan.Rows.Count == 1)
			{
				 SetValue(dtSedgwick_Claim_Action_Plan.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Sedgwick_Claim_Action_Plan class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSedgwick_Claim_Action_Plan) 
		{
				if (drSedgwick_Claim_Action_Plan["PK_Sedgwick_Claim_Action_Plan"] == DBNull.Value)
					this._PK_Sedgwick_Claim_Action_Plan = null;
				else
					this._PK_Sedgwick_Claim_Action_Plan = (decimal?)drSedgwick_Claim_Action_Plan["PK_Sedgwick_Claim_Action_Plan"];

				if (drSedgwick_Claim_Action_Plan["FK_Sedgwick_Claim_Review"] == DBNull.Value)
					this._FK_Sedgwick_Claim_Review = null;
				else
					this._FK_Sedgwick_Claim_Review = (decimal?)drSedgwick_Claim_Action_Plan["FK_Sedgwick_Claim_Review"];

				if (drSedgwick_Claim_Action_Plan["Management_Section"] == DBNull.Value)
					this._Management_Section = null;
				else
					this._Management_Section = (string)drSedgwick_Claim_Action_Plan["Management_Section"];

				if (drSedgwick_Claim_Action_Plan["Sort_Order"] == DBNull.Value)
					this._Sort_Order = null;
				else
					this._Sort_Order = (decimal?)drSedgwick_Claim_Action_Plan["Sort_Order"];

				if (drSedgwick_Claim_Action_Plan["RLCM_Sedgwick"] == DBNull.Value)
					this._RLCM_Sedgwick = null;
				else
					this._RLCM_Sedgwick = (string)drSedgwick_Claim_Action_Plan["RLCM_Sedgwick"];

				if (drSedgwick_Claim_Action_Plan["Action_Item"] == DBNull.Value)
					this._Action_Item = null;
				else
					this._Action_Item = (string)drSedgwick_Claim_Action_Plan["Action_Item"];

				if (drSedgwick_Claim_Action_Plan["Target_Date"] == DBNull.Value)
					this._Target_Date = null;
				else
					this._Target_Date = (DateTime?)drSedgwick_Claim_Action_Plan["Target_Date"];

				if (drSedgwick_Claim_Action_Plan["Actual_Date"] == DBNull.Value)
					this._Actual_Date = null;
				else
					this._Actual_Date = (DateTime?)drSedgwick_Claim_Action_Plan["Actual_Date"];

				if (drSedgwick_Claim_Action_Plan["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drSedgwick_Claim_Action_Plan["Updated_By"];

				if (drSedgwick_Claim_Action_Plan["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drSedgwick_Claim_Action_Plan["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Sedgwick_Claim_Action_Plan table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_Action_PlanInsert");

			
			db.AddInParameter(dbCommand, "FK_Sedgwick_Claim_Review", DbType.Decimal, this._FK_Sedgwick_Claim_Review);
			
			if (string.IsNullOrEmpty(this._Management_Section))
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, this._Management_Section);
			
			db.AddInParameter(dbCommand, "Sort_Order", DbType.Decimal, this._Sort_Order);
			
			if (string.IsNullOrEmpty(this._RLCM_Sedgwick))
				db.AddInParameter(dbCommand, "RLCM_Sedgwick", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "RLCM_Sedgwick", DbType.String, this._RLCM_Sedgwick);
			
			if (string.IsNullOrEmpty(this._Action_Item))
				db.AddInParameter(dbCommand, "Action_Item", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Action_Item", DbType.String, this._Action_Item);
			
			db.AddInParameter(dbCommand, "Target_Date", DbType.DateTime, this._Target_Date);
			
			db.AddInParameter(dbCommand, "Actual_Date", DbType.DateTime, this._Actual_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "Completed", DbType.String, this._Completed);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Sedgwick_Claim_Action_Plan table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_Sedgwick_Claim_Action_Plan)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_Action_PlanSelect");

			db.AddInParameter(dbCommand, "PK_Sedgwick_Claim_Action_Plan", DbType.Decimal, pK_Sedgwick_Claim_Action_Plan);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Sedgwick_Claim_Action_Plan table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_Action_PlanSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects by Management Section records from the Sedgwick_Claim_Action_Plan table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBy_MgtSection(string MgtSection, decimal FK_Sedgwick_Claim_Review)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_Action_PlanSelect_ByMgtSection");
            db.AddInParameter(dbCommand, "@MgtSection", DbType.String, MgtSection);
            db.AddInParameter(dbCommand, "@FK_Sedgwick_Claim_Review", DbType.Decimal, FK_Sedgwick_Claim_Review);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Updates a record in the Sedgwick_Claim_Action_Plan table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_Action_PlanUpdate");

			
			db.AddInParameter(dbCommand, "PK_Sedgwick_Claim_Action_Plan", DbType.Decimal, this._PK_Sedgwick_Claim_Action_Plan);
			
			db.AddInParameter(dbCommand, "FK_Sedgwick_Claim_Review", DbType.Decimal, this._FK_Sedgwick_Claim_Review);
			
			if (string.IsNullOrEmpty(this._Management_Section))
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, this._Management_Section);
			
			db.AddInParameter(dbCommand, "Sort_Order", DbType.Decimal, this._Sort_Order);
			
			if (string.IsNullOrEmpty(this._RLCM_Sedgwick))
				db.AddInParameter(dbCommand, "RLCM_Sedgwick", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "RLCM_Sedgwick", DbType.String, this._RLCM_Sedgwick);
			
			if (string.IsNullOrEmpty(this._Action_Item))
				db.AddInParameter(dbCommand, "Action_Item", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Action_Item", DbType.String, this._Action_Item);
			
			db.AddInParameter(dbCommand, "Target_Date", DbType.DateTime, this._Target_Date);
			
			db.AddInParameter(dbCommand, "Actual_Date", DbType.DateTime, this._Actual_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "Completed", DbType.String, this._Completed);

			db.ExecuteNonQuery(dbCommand);
		}
        /// <summary>
        /// Updates a record in the Sedgwick_Claim_Action_Plan_Update_ActionItem table.
        /// </summary>
        public void UpdateActionItem()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_Action_Plan_Update_ActionItem");


            db.AddInParameter(dbCommand, "PK_Sedgwick_Claim_Action_Plan", DbType.Decimal, this._PK_Sedgwick_Claim_Action_Plan);

            if (string.IsNullOrEmpty(this._Action_Item))
                db.AddInParameter(dbCommand, "Action_Item", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Action_Item", DbType.String, this._Action_Item);

            db.ExecuteNonQuery(dbCommand);
        }
		/// <summary>
		/// Deletes a record from the Sedgwick_Claim_Action_Plan table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_Sedgwick_Claim_Action_Plan)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_Action_PlanDelete");

			db.AddInParameter(dbCommand, "PK_Sedgwick_Claim_Action_Plan", DbType.Decimal, pK_Sedgwick_Claim_Action_Plan);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
