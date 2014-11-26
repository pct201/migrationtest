using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for SLT_Suggestion table.
	/// </summary>
	public sealed class SLT_Suggestion
	{

		#region Private variables used to hold the property values

		private decimal? _PK_SLT_Suggestion;
		private decimal? _FK_SLT_Meeting;
		private decimal? _FK_LU_Suggestion_Source;
		private decimal? _FK_LU_Importance;
		private string _Suggestion_Description;
		private string _Action_Item;
		private decimal? _Assigned_To;
		private DateTime? _Target_Completion_Date;
		private DateTime? _Date_Completed;
		private decimal? _FK_LU_Item_Status;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private decimal? _FK_SLT_Meeting_Schedule;
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_SLT_Suggestion value.
		/// </summary>
		public decimal? PK_SLT_Suggestion
		{
			get { return _PK_SLT_Suggestion; }
			set { _PK_SLT_Suggestion = value; }
		}

		/// <summary>
		/// Gets or sets the FK_SLT_Meeting value.
		/// </summary>
		public decimal? FK_SLT_Meeting
		{
			get { return _FK_SLT_Meeting; }
			set { _FK_SLT_Meeting = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Suggestion_Source value.
		/// </summary>
		public decimal? FK_LU_Suggestion_Source
		{
			get { return _FK_LU_Suggestion_Source; }
			set { _FK_LU_Suggestion_Source = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Importance value.
		/// </summary>
		public decimal? FK_LU_Importance
		{
			get { return _FK_LU_Importance; }
			set { _FK_LU_Importance = value; }
		}

		/// <summary>
		/// Gets or sets the Suggestion_Description value.
		/// </summary>
		public string Suggestion_Description
		{
			get { return _Suggestion_Description; }
			set { _Suggestion_Description = value; }
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
		/// Gets or sets the Assigned_To value.
		/// </summary>
		public decimal? Assigned_To
		{
			get { return _Assigned_To; }
			set { _Assigned_To = value; }
		}

		/// <summary>
		/// Gets or sets the Target_Completion_Date value.
		/// </summary>
		public DateTime? Target_Completion_Date
		{
			get { return _Target_Completion_Date; }
			set { _Target_Completion_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Completed value.
		/// </summary>
		public DateTime? Date_Completed
		{
			get { return _Date_Completed; }
			set { _Date_Completed = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Item_Status value.
		/// </summary>
		public decimal? FK_LU_Item_Status
		{
			get { return _FK_LU_Item_Status; }
			set { _FK_LU_Item_Status = value; }
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
        /// Gets or sets the FK_SLT_Meeting_Schedule value.
        /// </summary>
        public decimal? FK_SLT_Meeting_Schedule
        {
            get { return _FK_SLT_Meeting_Schedule; }
            set { _FK_SLT_Meeting_Schedule = value; }
        }

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_Suggestion class with default value.
		/// </summary>
		public SLT_Suggestion() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_Suggestion class based on Primary Key.
		/// </summary>
		public SLT_Suggestion(decimal pK_SLT_Suggestion) 
		{
			DataTable dtSLT_Suggestion = SelectByPK(pK_SLT_Suggestion).Tables[0];

			if (dtSLT_Suggestion.Rows.Count == 1)
			{
				 SetValue(dtSLT_Suggestion.Rows[0]);

			}

		}
        /// <summary>
        /// Initializes a new instance of the clsSLT_Suggestion class based on foreign Key.
        /// </summary>
        public SLT_Suggestion(decimal FK_SLT_Meeting_Schedule,bool status)
        {
            DataTable dtSLT_Suggestion = SelectByFK(FK_SLT_Meeting_Schedule).Tables[0];

            if (dtSLT_Suggestion.Rows.Count == 1)
            {
                SetValue(dtSLT_Suggestion.Rows[0]);

            }

        }


		/// <summary>
		/// Initializes a new instance of the clsSLT_Suggestion class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSLT_Suggestion) 
		{
				if (drSLT_Suggestion["PK_SLT_Suggestion"] == DBNull.Value)
					this._PK_SLT_Suggestion = null;
				else
					this._PK_SLT_Suggestion = (decimal?)drSLT_Suggestion["PK_SLT_Suggestion"];

				if (drSLT_Suggestion["FK_SLT_Meeting"] == DBNull.Value)
					this._FK_SLT_Meeting = null;
				else
					this._FK_SLT_Meeting = (decimal?)drSLT_Suggestion["FK_SLT_Meeting"];

				if (drSLT_Suggestion["FK_LU_Suggestion_Source"] == DBNull.Value)
					this._FK_LU_Suggestion_Source = null;
				else
					this._FK_LU_Suggestion_Source = (decimal?)drSLT_Suggestion["FK_LU_Suggestion_Source"];

				if (drSLT_Suggestion["FK_LU_Importance"] == DBNull.Value)
					this._FK_LU_Importance = null;
				else
					this._FK_LU_Importance = (decimal?)drSLT_Suggestion["FK_LU_Importance"];

				if (drSLT_Suggestion["Suggestion_Description"] == DBNull.Value)
					this._Suggestion_Description = null;
				else
					this._Suggestion_Description = (string)drSLT_Suggestion["Suggestion_Description"];

				if (drSLT_Suggestion["Action_Item"] == DBNull.Value)
					this._Action_Item = null;
				else
					this._Action_Item = (string)drSLT_Suggestion["Action_Item"];

				if (drSLT_Suggestion["Assigned_To"] == DBNull.Value)
					this._Assigned_To = null;
				else
					this._Assigned_To = (decimal?)drSLT_Suggestion["Assigned_To"];

				if (drSLT_Suggestion["Target_Completion_Date"] == DBNull.Value)
					this._Target_Completion_Date = null;
				else
					this._Target_Completion_Date = (DateTime?)drSLT_Suggestion["Target_Completion_Date"];

				if (drSLT_Suggestion["Date_Completed"] == DBNull.Value)
					this._Date_Completed = null;
				else
					this._Date_Completed = (DateTime?)drSLT_Suggestion["Date_Completed"];

				if (drSLT_Suggestion["FK_LU_Item_Status"] == DBNull.Value)
					this._FK_LU_Item_Status = null;
				else
					this._FK_LU_Item_Status = (decimal?)drSLT_Suggestion["FK_LU_Item_Status"];

				if (drSLT_Suggestion["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drSLT_Suggestion["Updated_By"];

				if (drSLT_Suggestion["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drSLT_Suggestion["Update_Date"];

                if (drSLT_Suggestion["FK_SLT_Meeting_Schedule"] == DBNull.Value)
                    this._FK_SLT_Meeting_Schedule = null;
                else
                    this._FK_SLT_Meeting_Schedule = (decimal?)drSLT_Suggestion["FK_SLT_Meeting_Schedule"];

		}

		#endregion

		/// <summary>
		/// Inserts a record into the SLT_Suggestion table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_SuggestionInsert");

			
			db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);
			
			db.AddInParameter(dbCommand, "FK_LU_Suggestion_Source", DbType.Decimal, this._FK_LU_Suggestion_Source);
			
			db.AddInParameter(dbCommand, "FK_LU_Importance", DbType.Decimal, this._FK_LU_Importance);
			
			if (string.IsNullOrEmpty(this._Suggestion_Description))
				db.AddInParameter(dbCommand, "Suggestion_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Suggestion_Description", DbType.String, this._Suggestion_Description);
			
			if (string.IsNullOrEmpty(this._Action_Item))
				db.AddInParameter(dbCommand, "Action_Item", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Action_Item", DbType.String, this._Action_Item);
			
			db.AddInParameter(dbCommand, "Assigned_To", DbType.Decimal, this._Assigned_To);
			
			db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, this._Target_Completion_Date);
			
			db.AddInParameter(dbCommand, "Date_Completed", DbType.DateTime, this._Date_Completed);
			
			db.AddInParameter(dbCommand, "FK_LU_Item_Status", DbType.Decimal, this._FK_LU_Item_Status);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, this._FK_SLT_Meeting_Schedule);
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the SLT_Suggestion table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_SLT_Suggestion)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_SuggestionSelectByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Suggestion", DbType.Decimal, pK_SLT_Suggestion);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the SLT_Suggestion table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_SuggestionSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the SLT_Suggestion table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_SuggestionUpdate");

			
			db.AddInParameter(dbCommand, "PK_SLT_Suggestion", DbType.Decimal, this._PK_SLT_Suggestion);
			
			db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);
			
			db.AddInParameter(dbCommand, "FK_LU_Suggestion_Source", DbType.Decimal, this._FK_LU_Suggestion_Source);
			
			db.AddInParameter(dbCommand, "FK_LU_Importance", DbType.Decimal, this._FK_LU_Importance);
			
			if (string.IsNullOrEmpty(this._Suggestion_Description))
				db.AddInParameter(dbCommand, "Suggestion_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Suggestion_Description", DbType.String, this._Suggestion_Description);
			
			if (string.IsNullOrEmpty(this._Action_Item))
				db.AddInParameter(dbCommand, "Action_Item", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Action_Item", DbType.String, this._Action_Item);

            db.AddInParameter(dbCommand, "Assigned_To", DbType.Decimal, this._Assigned_To);
			
			db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, this._Target_Completion_Date);
			
			db.AddInParameter(dbCommand, "Date_Completed", DbType.DateTime, this._Date_Completed);
			
			db.AddInParameter(dbCommand, "FK_LU_Item_Status", DbType.Decimal, this._FK_LU_Item_Status);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, this._FK_SLT_Meeting_Schedule);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the SLT_Suggestion table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_SLT_Suggestion)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_SuggestionDeleteByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Suggestion", DbType.Decimal, pK_SLT_Suggestion);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectByFK(decimal FK_SLT_Meeting_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_SuggestionSelectByFK");

            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting_Schedule);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
