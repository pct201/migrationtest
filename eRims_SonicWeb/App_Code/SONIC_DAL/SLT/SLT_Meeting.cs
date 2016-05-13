using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for SLT_Meeting table.
	/// </summary>
	public sealed class SLT_Meeting
	{

		#region Private variables used to hold the property values

		private decimal? _PK_SLT_Meeting;
		private decimal? _FK_LU_Location_ID;		
		private string _Updated_By;
		private DateTime? _Update_Date;
        private string _UniqueVal;
        
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_SLT_Meeting value.
		/// </summary>
		public decimal? PK_SLT_Meeting
		{
			get { return _PK_SLT_Meeting; }
			set { _PK_SLT_Meeting = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Location_ID value.
		/// </summary>
		public decimal? FK_LU_Location_ID
		{
			get { return _FK_LU_Location_ID; }
			set { _FK_LU_Location_ID = value; }
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
        
		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_Meeting class with default value.
		/// </summary>
		public SLT_Meeting() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_Meeting class based on Primary Key.
		/// </summary>
		public SLT_Meeting(decimal pK_SLT_Meeting) 
		{
			DataTable dtSLT_Meeting = SelectByPK(pK_SLT_Meeting).Tables[0];

			if (dtSLT_Meeting.Rows.Count == 1)
			{
				 SetValue(dtSLT_Meeting.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsSLT_Meeting class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSLT_Meeting) 
		{
				if (drSLT_Meeting["PK_SLT_Meeting"] == DBNull.Value)
					this._PK_SLT_Meeting = null;
				else
					this._PK_SLT_Meeting = (decimal?)drSLT_Meeting["PK_SLT_Meeting"];

				if (drSLT_Meeting["FK_LU_Location_ID"] == DBNull.Value)
					this._FK_LU_Location_ID = null;
				else
					this._FK_LU_Location_ID = (decimal?)drSLT_Meeting["FK_LU_Location_ID"];

				

				if (drSLT_Meeting["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drSLT_Meeting["Updated_By"];

				if (drSLT_Meeting["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drSLT_Meeting["Update_Date"];

               
               
		}

		#endregion

		/// <summary>
		/// Inserts a record into the SLT_Meeting table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_MeetingInsert");

			
			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
			
			
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._UniqueVal))
                db.AddInParameter(dbCommand, "UniqueVal", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "UniqueVal", DbType.String, this._UniqueVal);
            
            
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the SLT_Meeting table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_SLT_Meeting)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_MeetingSelectByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Meeting", DbType.Decimal, pK_SLT_Meeting);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the SLT_Meeting table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_MeetingSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the SLT_Meeting table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_MeetingUpdate");

			
			db.AddInParameter(dbCommand, "PK_SLT_Meeting", DbType.Decimal, this._PK_SLT_Meeting);
			
			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
			
			
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._UniqueVal))
                db.AddInParameter(dbCommand, "UniqueVal", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "UniqueVal", DbType.String, this._UniqueVal);
            
            
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the SLT_Meeting table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_SLT_Meeting)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_MeetingDeleteByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Meeting", DbType.Decimal, pK_SLT_Meeting);

			db.ExecuteNonQuery(dbCommand);
		}
        public static DataSet SelectByLocationID(decimal FK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_MeetingBYLocationID");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, FK_LU_Location_ID);
            return(db.ExecuteDataSet(dbCommand));
        }
        public static DataSet Get_SLT_Meeting_Scores(decimal FK_LU_Location_ID, decimal PK_SLT_Meeting_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_GetScores_New");
            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "PK_SLT_Meeting_Schedule", DbType.Decimal, PK_SLT_Meeting_Schedule);
            dbCommand.CommandTimeout = 1000;
            return (db.ExecuteDataSet(dbCommand));
        }

        public static void RecalculateScores(decimal FK_SLT_Meeting, decimal PK_SLT_Meeting_Schedule, decimal? Full_Participation, decimal? Full_SW_Participation, decimal? Incident_Review, decimal? RLCM_Score)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Recalculate_Score");
            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);
            db.AddInParameter(dbCommand, "PK_SLT_Meeting_Schedule", DbType.Decimal, PK_SLT_Meeting_Schedule);
            db.AddInParameter(dbCommand, "Full_Participation", DbType.Decimal, Full_Participation);
            db.AddInParameter(dbCommand, "Full_SW_Participation", DbType.Decimal, Full_SW_Participation);
            db.AddInParameter(dbCommand, "Incident_Review", DbType.Decimal, Incident_Review);
            db.AddInParameter(dbCommand, "RLCM_Score", DbType.Decimal, RLCM_Score);
            db.ExecuteNonQuery(dbCommand);
        }

        public static void RecalculateAllScoreByYear(decimal FK_SLT_Meeting, int intYear)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_RecalculateAllScoreByYear");
            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);
            db.AddInParameter(dbCommand, "Year", DbType.Decimal, intYear);
            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet GetSLT_ScoringReport(string strRegion,string strMarket, int intYear)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptSLT_Scoring");
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
