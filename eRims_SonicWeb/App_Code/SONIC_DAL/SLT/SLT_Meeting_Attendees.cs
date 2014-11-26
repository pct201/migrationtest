using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for SLT_Meeting_Attendees table.
	/// </summary>
	public sealed class SLT_Meeting_Attendees
	{

		#region Private variables used to hold the property values

		private decimal? _PK_SLT_Meeting_Attendees;
		private decimal? _FK_SLT_Meeting;
		private bool? _Present;
		private decimal? _FK_LU_Explain;
		private string _Explain;
		private string _Updated_By;
		private DateTime? _Update_Date;
		private decimal? _FK_SLT_Members;
        private decimal? _FK_SLT_Meeting_Schedule;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_SLT_Meeting_Attendees value.
		/// </summary>
		public decimal? PK_SLT_Meeting_Attendees
		{
			get { return _PK_SLT_Meeting_Attendees; }
			set { _PK_SLT_Meeting_Attendees = value; }
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
		/// Gets or sets the Present value.
		/// </summary>
		public bool? Present
		{
			get { return _Present; }
			set { _Present = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Explain value.
		/// </summary>
		public decimal? FK_LU_Explain
		{
			get { return _FK_LU_Explain; }
			set { _FK_LU_Explain = value; }
		}

		/// <summary>
		/// Gets or sets the Explain value.
		/// </summary>
		public string Explain
		{
			get { return _Explain; }
			set { _Explain = value; }
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
		/// Gets or sets the FK_SLT_Members value.
		/// </summary>
		public decimal? FK_SLT_Members
		{
			get { return _FK_SLT_Members; }
			set { _FK_SLT_Members = value; }
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
		/// Initializes a new instance of the clsSLT_Meeting_Attendees class with default value.
		/// </summary>
		public SLT_Meeting_Attendees() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_Meeting_Attendees class based on Primary Key.
		/// </summary>
		public SLT_Meeting_Attendees(decimal pK_SLT_Meeting_Attendees) 
		{
			DataTable dtSLT_Meeting_Attendees = SelectByPK(pK_SLT_Meeting_Attendees).Tables[0];

			if (dtSLT_Meeting_Attendees.Rows.Count == 1)
			{
				 SetValue(dtSLT_Meeting_Attendees.Rows[0]);

			}

		}
        /// <summary>
        /// Initializes a new instance of the clsSLT_Meeting_Attendees class based on Primary Key.
        /// </summary>
        public SLT_Meeting_Attendees(decimal FK_SLT_Members, decimal FK_SLT_Meeting_Schedule)
        {
            DataTable dtSLT_Meeting_Attendees = SelectBYSLT_Members(FK_SLT_Members,FK_SLT_Meeting_Schedule).Tables[0];

            if (dtSLT_Meeting_Attendees.Rows.Count == 1)
            {
                SetValue(dtSLT_Meeting_Attendees.Rows[0]);

            }

        }

		/// <summary>
		/// Initializes a new instance of the clsSLT_Meeting_Attendees class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSLT_Meeting_Attendees) 
		{
				if (drSLT_Meeting_Attendees["PK_SLT_Meeting_Attendees"] == DBNull.Value)
					this._PK_SLT_Meeting_Attendees = null;
				else
					this._PK_SLT_Meeting_Attendees = (decimal?)drSLT_Meeting_Attendees["PK_SLT_Meeting_Attendees"];

				if (drSLT_Meeting_Attendees["FK_SLT_Meeting"] == DBNull.Value)
					this._FK_SLT_Meeting = null;
				else
					this._FK_SLT_Meeting = (decimal?)drSLT_Meeting_Attendees["FK_SLT_Meeting"];

				if (drSLT_Meeting_Attendees["Present"] == DBNull.Value)
					this._Present = null;
				else
					this._Present = (bool?)drSLT_Meeting_Attendees["Present"];

				if (drSLT_Meeting_Attendees["FK_LU_Explain"] == DBNull.Value)
					this._FK_LU_Explain = null;
				else
					this._FK_LU_Explain = (decimal?)drSLT_Meeting_Attendees["FK_LU_Explain"];

				if (drSLT_Meeting_Attendees["Explain"] == DBNull.Value)
					this._Explain = null;
				else
					this._Explain = (string)drSLT_Meeting_Attendees["Explain"];

				if (drSLT_Meeting_Attendees["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drSLT_Meeting_Attendees["Updated_By"];

				if (drSLT_Meeting_Attendees["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drSLT_Meeting_Attendees["Update_Date"];

				if (drSLT_Meeting_Attendees["FK_SLT_Members"] == DBNull.Value)
					this._FK_SLT_Members = null;
				else
					this._FK_SLT_Members = (decimal?)drSLT_Meeting_Attendees["FK_SLT_Members"];

                if (drSLT_Meeting_Attendees["FK_SLT_Meeting_Schedule"] == DBNull.Value)
                    this._FK_SLT_Meeting_Schedule = null;
                else
                    this._FK_SLT_Meeting_Schedule = (decimal?)drSLT_Meeting_Attendees["FK_SLT_Meeting_Schedule"];

		}

		#endregion

		/// <summary>
		/// Inserts a record into the SLT_Meeting_Attendees table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_AttendeesInsert");

			
			db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);
			
			db.AddInParameter(dbCommand, "Present", DbType.Boolean, this._Present);
			
			db.AddInParameter(dbCommand, "FK_LU_Explain", DbType.Decimal, this._FK_LU_Explain);
			
			if (string.IsNullOrEmpty(this._Explain))
				db.AddInParameter(dbCommand, "Explain", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Explain", DbType.String, this._Explain);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			db.AddInParameter(dbCommand, "FK_SLT_Members", DbType.Decimal, this._FK_SLT_Members);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, this._FK_SLT_Meeting_Schedule);
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the SLT_Meeting_Attendees table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_SLT_Meeting_Attendees)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_AttendeesSelectByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Meeting_Attendees", DbType.Decimal, pK_SLT_Meeting_Attendees);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the SLT_Meeting_Attendees table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_AttendeesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the SLT_Meeting_Attendees table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_AttendeesUpdate");

			
			db.AddInParameter(dbCommand, "PK_SLT_Meeting_Attendees", DbType.Decimal, this._PK_SLT_Meeting_Attendees);
			
			db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);
			
			db.AddInParameter(dbCommand, "Present", DbType.Boolean, this._Present);
			
			db.AddInParameter(dbCommand, "FK_LU_Explain", DbType.Decimal, this._FK_LU_Explain);
			
			if (string.IsNullOrEmpty(this._Explain))
				db.AddInParameter(dbCommand, "Explain", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Explain", DbType.String, this._Explain);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			db.AddInParameter(dbCommand, "FK_SLT_Members", DbType.Decimal, this._FK_SLT_Members);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, this._FK_SLT_Meeting_Schedule);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the SLT_Meeting_Attendees table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_SLT_Meeting_Attendees)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_AttendeesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Meeting_Attendees", DbType.Decimal, pK_SLT_Meeting_Attendees);

			db.ExecuteNonQuery(dbCommand);
		}
        /// <summary>
        /// Selects all records from the SLT_Meeting_Attendees table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBYFK(decimal FK_SLT_Meeting_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectSLT_Meeting_AttendeesbyFK");
            //db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting_Schedule);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the SLT_Meeting_Attendees table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBYSLT_Members(decimal FK_SLT_Members, decimal FK_SLT_Meeting_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_AttendeesBYSLT_Members");
            db.AddInParameter(dbCommand, "FK_SLT_Members", DbType.Decimal, FK_SLT_Members);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting_Schedule);
            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Deletes a record from the SLT_Meeting_Attendees table by a composite primary key.
        /// </summary>
        public static void DeleteByFK(decimal PK_SLT_Meeting_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_AttendeesDeleteByFK");

            db.AddInParameter(dbCommand, "PK_SLT_Meeting_Schedule", DbType.Decimal, PK_SLT_Meeting_Schedule);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}
