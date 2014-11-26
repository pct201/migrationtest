using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for SLT_Training table.
	/// </summary>
	public sealed class SLT_Training
	{

		#region Private variables used to hold the property values

		private decimal? _PK_SLT_Training;
		private decimal? _FK_SLT_Meeting;
		private string _Training_Description;
		private DateTime? _Desired_Comp_Date;
		private bool? _Completed;
		private DateTime? _Date_Completed;
		private string _Comments;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private decimal? _FK_SLT_Meeting_Schedule;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_SLT_Training value.
		/// </summary>
		public decimal? PK_SLT_Training
		{
			get { return _PK_SLT_Training; }
			set { _PK_SLT_Training = value; }
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
		/// Gets or sets the Training_Description value.
		/// </summary>
		public string Training_Description
		{
			get { return _Training_Description; }
			set { _Training_Description = value; }
		}

		/// <summary>
		/// Gets or sets the Desired_Comp_Date value.
		/// </summary>
		public DateTime? Desired_Comp_Date
		{
			get { return _Desired_Comp_Date; }
			set { _Desired_Comp_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Completed value.
		/// </summary>
		public bool? Completed
		{
			get { return _Completed; }
			set { _Completed = value; }
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
		/// Gets or sets the Comments value.
		/// </summary>
		public string Comments
		{
			get { return _Comments; }
			set { _Comments = value; }
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
		/// Initializes a new instance of the clsSLT_Training class with default value.
		/// </summary>
		public SLT_Training() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_Training class based on Primary Key.
		/// </summary>
		public SLT_Training(decimal pK_SLT_Training) 
		{
			DataTable dtSLT_Training = SelectByPK(pK_SLT_Training).Tables[0];

			if (dtSLT_Training.Rows.Count == 1)
			{
				 SetValue(dtSLT_Training.Rows[0]);

			}

		}
        /// <summary>
        /// Initializes a new instance of the clsSLT_Training class based on foreign Key.
        /// </summary>
        public SLT_Training(decimal FK_SLT_Meeting_Schedule,bool status)
        {
            DataTable dtSLT_Training = SelectByFK(FK_SLT_Meeting_Schedule).Tables[0];

            if (dtSLT_Training.Rows.Count == 1)
            {
                SetValue(dtSLT_Training.Rows[0]);

            }

        }

		/// <summary>
		/// Initializes a new instance of the clsSLT_Training class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSLT_Training) 
		{
				if (drSLT_Training["PK_SLT_Training"] == DBNull.Value)
					this._PK_SLT_Training = null;
				else
					this._PK_SLT_Training = (decimal?)drSLT_Training["PK_SLT_Training"];

				if (drSLT_Training["FK_SLT_Meeting"] == DBNull.Value)
					this._FK_SLT_Meeting = null;
				else
					this._FK_SLT_Meeting = (decimal?)drSLT_Training["FK_SLT_Meeting"];

				if (drSLT_Training["Training_Description"] == DBNull.Value)
					this._Training_Description = null;
				else
					this._Training_Description = (string)drSLT_Training["Training_Description"];

				if (drSLT_Training["Desired_Comp_Date"] == DBNull.Value)
					this._Desired_Comp_Date = null;
				else
					this._Desired_Comp_Date = (DateTime?)drSLT_Training["Desired_Comp_Date"];

				if (drSLT_Training["Completed"] == DBNull.Value)
					this._Completed = null;
				else
					this._Completed = (bool?)drSLT_Training["Completed"];

				if (drSLT_Training["Date_Completed"] == DBNull.Value)
					this._Date_Completed = null;
				else
					this._Date_Completed = (DateTime?)drSLT_Training["Date_Completed"];

				if (drSLT_Training["Comments"] == DBNull.Value)
					this._Comments = null;
				else
					this._Comments = (string)drSLT_Training["Comments"];

				if (drSLT_Training["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drSLT_Training["Updated_By"];

				if (drSLT_Training["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drSLT_Training["Update_Date"];

                if (drSLT_Training["FK_SLT_Meeting_Schedule"] == DBNull.Value)
                    this._FK_SLT_Meeting_Schedule = null;
                else
                    this._FK_SLT_Meeting_Schedule = (decimal?)drSLT_Training["FK_SLT_Meeting_Schedule"];

		}

		#endregion

		/// <summary>
		/// Inserts a record into the SLT_Training table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_TrainingInsert");

			
			db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);
			
			if (string.IsNullOrEmpty(this._Training_Description))
				db.AddInParameter(dbCommand, "Training_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Training_Description", DbType.String, this._Training_Description);
			
			db.AddInParameter(dbCommand, "Desired_Comp_Date", DbType.DateTime, this._Desired_Comp_Date);
			
			db.AddInParameter(dbCommand, "Completed", DbType.Boolean, this._Completed);
			
			db.AddInParameter(dbCommand, "Date_Completed", DbType.DateTime, this._Date_Completed);
			
			if (string.IsNullOrEmpty(this._Comments))
				db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
			
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
		/// Selects a single record from the SLT_Training table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_SLT_Training)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_TrainingSelectByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Training", DbType.Decimal, pK_SLT_Training);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the SLT_Training table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_TrainingSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the SLT_Training table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_TrainingUpdate");

			
			db.AddInParameter(dbCommand, "PK_SLT_Training", DbType.Decimal, this._PK_SLT_Training);
			
			db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);
			
			if (string.IsNullOrEmpty(this._Training_Description))
				db.AddInParameter(dbCommand, "Training_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Training_Description", DbType.String, this._Training_Description);
			
			db.AddInParameter(dbCommand, "Desired_Comp_Date", DbType.DateTime, this._Desired_Comp_Date);
			
			db.AddInParameter(dbCommand, "Completed", DbType.Boolean, this._Completed);
			
			db.AddInParameter(dbCommand, "Date_Completed", DbType.DateTime, this._Date_Completed);
			
			if (string.IsNullOrEmpty(this._Comments))
				db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, this._FK_SLT_Meeting_Schedule);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the SLT_Training table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_SLT_Training)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_TrainingDeleteByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Training", DbType.Decimal, pK_SLT_Training);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectByFK(decimal FK_SLT_Meeting_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_TrainingSelectByFK");
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting_Schedule);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectQuarterResults(decimal PK_LU_Location_ID, int Year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_TrainingSelectQuarterResults");
            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, PK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
