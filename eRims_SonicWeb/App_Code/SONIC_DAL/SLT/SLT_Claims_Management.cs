using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for SLT_Claims_Management table.
	/// </summary>
	public sealed class SLT_Claims_Management
	{

		#region Private variables used to hold the property values

		private decimal? _PK_SLT_Claims_Mangement;
		private decimal? _FK_SLT_Meeting;
		private string _Lag_Explaination;
		private decimal? _FK_LU_Work_Status;
		private string _Light_Duty_Explaination;
		private string _Comments;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private string _UniqueVal;
        private decimal? _FK_Claim;
        private decimal? _FK_SLT_Meeting_Schedule;
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_SLT_Claims_Mangement value.
		/// </summary>
		public decimal? PK_SLT_Claims_Mangement
		{
			get { return _PK_SLT_Claims_Mangement; }
			set { _PK_SLT_Claims_Mangement = value; }
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
		/// Gets or sets the Lag_Explaination value.
		/// </summary>
		public string Lag_Explaination
		{
			get { return _Lag_Explaination; }
			set { _Lag_Explaination = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Work_Status value.
		/// </summary>
		public decimal? FK_LU_Work_Status
		{
			get { return _FK_LU_Work_Status; }
			set { _FK_LU_Work_Status = value; }
		}

		/// <summary>
		/// Gets or sets the Light_Duty_Explaination value.
		/// </summary>
		public string Light_Duty_Explaination
		{
			get { return _Light_Duty_Explaination; }
			set { _Light_Duty_Explaination = value; }
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
        /// Gets or sets the UniqueVal value.
        /// </summary>
        public string UniqueVal
        {
            get { return _UniqueVal; }
            set { _UniqueVal = value; }
        }

        /// <summary>
        /// gets or sets the FK_Claim value
        /// </summary>
        public decimal? FK_Claim
        {
            get { return _FK_Claim; }
            set { _FK_Claim = value; }
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
		/// Initializes a new instance of the clsSLT_Claims_Management class with default value.
		/// </summary>
		public SLT_Claims_Management() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_Claims_Management class based on Primary Key.
		/// </summary>
		public SLT_Claims_Management(decimal pK_SLT_Claims_Mangement) 
		{
			DataTable dtSLT_Claims_Management = SelectByPK(pK_SLT_Claims_Mangement).Tables[0];

			if (dtSLT_Claims_Management.Rows.Count == 1)
			{
				 SetValue(dtSLT_Claims_Management.Rows[0]);

			}

		}
        /// <summary>
        /// Initializes a new instance of the clsSLT_Claims_Management class based on Foreign Key.
        /// </summary>
        public SLT_Claims_Management(decimal FK_SLT_Meeting, decimal FK_Claim, bool Status)
        {
            DataTable dtSLT_Claims_Management = SelectByFK(FK_SLT_Meeting, FK_Claim).Tables[0];

            if (dtSLT_Claims_Management.Rows.Count == 1)
            {
                SetValue(dtSLT_Claims_Management.Rows[0]);

            }

        }

		/// <summary>
		/// Initializes a new instance of the clsSLT_Claims_Management class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSLT_Claims_Management) 
		{
				if (drSLT_Claims_Management["PK_SLT_Claims_Mangement"] == DBNull.Value)
					this._PK_SLT_Claims_Mangement = null;
				else
					this._PK_SLT_Claims_Mangement = (decimal?)drSLT_Claims_Management["PK_SLT_Claims_Mangement"];

				if (drSLT_Claims_Management["FK_SLT_Meeting"] == DBNull.Value)
					this._FK_SLT_Meeting = null;
				else
					this._FK_SLT_Meeting = (decimal?)drSLT_Claims_Management["FK_SLT_Meeting"];

				if (drSLT_Claims_Management["Lag_Explaination"] == DBNull.Value)
					this._Lag_Explaination = null;
				else
					this._Lag_Explaination = (string)drSLT_Claims_Management["Lag_Explaination"];

				if (drSLT_Claims_Management["FK_LU_Work_Status"] == DBNull.Value)
					this._FK_LU_Work_Status = null;
				else
					this._FK_LU_Work_Status = (decimal?)drSLT_Claims_Management["FK_LU_Work_Status"];

				if (drSLT_Claims_Management["Light_Duty_Explaination"] == DBNull.Value)
					this._Light_Duty_Explaination = null;
				else
					this._Light_Duty_Explaination = (string)drSLT_Claims_Management["Light_Duty_Explaination"];

				if (drSLT_Claims_Management["Comments"] == DBNull.Value)
					this._Comments = null;
				else
					this._Comments = (string)drSLT_Claims_Management["Comments"];

				if (drSLT_Claims_Management["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drSLT_Claims_Management["Updated_By"];

				if (drSLT_Claims_Management["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drSLT_Claims_Management["Update_Date"];

                if (drSLT_Claims_Management["FK_Claim"] == DBNull.Value)
                    this._FK_Claim = null;
                else
                    this._FK_Claim = (decimal?)drSLT_Claims_Management["FK_Claim"];

                if (drSLT_Claims_Management["FK_SLT_Meeting_Schedule"] == DBNull.Value)
                    this._FK_SLT_Meeting_Schedule = null;
                else
                    this._FK_SLT_Meeting_Schedule = (decimal?)drSLT_Claims_Management["FK_SLT_Meeting_Schedule"];
                
		}

		#endregion

		/// <summary>
		/// Inserts a record into the SLT_Claims_Management table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Claims_ManagementInsert");

			
			db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);
			
			if (string.IsNullOrEmpty(this._Lag_Explaination))
				db.AddInParameter(dbCommand, "Lag_Explaination", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Lag_Explaination", DbType.String, this._Lag_Explaination);
			
			db.AddInParameter(dbCommand, "FK_LU_Work_Status", DbType.Decimal, this._FK_LU_Work_Status);
			
			if (string.IsNullOrEmpty(this._Light_Duty_Explaination))
				db.AddInParameter(dbCommand, "Light_Duty_Explaination", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Light_Duty_Explaination", DbType.String, this._Light_Duty_Explaination);
			
			if (string.IsNullOrEmpty(this._Comments))
				db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._UniqueVal))
                db.AddInParameter(dbCommand, "UniqueVal", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "UniqueVal", DbType.String, this._UniqueVal);
            db.AddInParameter(dbCommand, "FK_Claim", DbType.Decimal, this._FK_Claim);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, this._FK_SLT_Meeting_Schedule);
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the SLT_Claims_Management table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_SLT_Claims_Mangement)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Claims_ManagementSelectByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Claims_Mangement", DbType.Decimal, pK_SLT_Claims_Mangement);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the SLT_Claims_Management table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Claims_ManagementSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the SLT_Claims_Management table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Claims_ManagementUpdate");

			
			db.AddInParameter(dbCommand, "PK_SLT_Claims_Mangement", DbType.Decimal, this._PK_SLT_Claims_Mangement);
			
			db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);
			
			if (string.IsNullOrEmpty(this._Lag_Explaination))
				db.AddInParameter(dbCommand, "Lag_Explaination", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Lag_Explaination", DbType.String, this._Lag_Explaination);
			
			db.AddInParameter(dbCommand, "FK_LU_Work_Status", DbType.Decimal, this._FK_LU_Work_Status);
			
			if (string.IsNullOrEmpty(this._Light_Duty_Explaination))
				db.AddInParameter(dbCommand, "Light_Duty_Explaination", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Light_Duty_Explaination", DbType.String, this._Light_Duty_Explaination);
			
			if (string.IsNullOrEmpty(this._Comments))
				db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._UniqueVal))
                db.AddInParameter(dbCommand, "UniqueVal", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "UniqueVal", DbType.String, this._UniqueVal);
            db.AddInParameter(dbCommand, "FK_Claim", DbType.Decimal, this._FK_Claim);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, this._FK_SLT_Meeting_Schedule);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the SLT_Claims_Management table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_SLT_Claims_Mangement)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Claims_ManagementDeleteByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Claims_Mangement", DbType.Decimal, pK_SLT_Claims_Mangement);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectWCClaims(int FK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_ClaimsSelectForSLT");

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Int32, FK_LU_Location);
            //db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            //db.AddInParameter(dbCommand, "Month", DbType.Int32, Month);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByFK(decimal FK_SLT_Meeting, decimal FK_Claim)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectSLT_Claims_ManagementBYFK");
            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);
            db.AddInParameter(dbCommand, "FK_Claim", DbType.Decimal,FK_Claim);
            return(db.ExecuteDataSet(dbCommand));
        }
	}
}
