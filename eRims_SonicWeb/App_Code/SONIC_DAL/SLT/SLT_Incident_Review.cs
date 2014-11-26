using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for SLT_Incident_Review table.
	/// </summary>
	public sealed class SLT_Incident_Review
	{

		#region Private variables used to hold the property values

		private decimal? _PK_SLT_Incident_Review;
		private decimal? _FK_SLT_Meeting;
		private decimal? _FK_WC_FR_ID;
		private decimal? _FK_Investigation_ID;
		private decimal? _FK_LU_Incident_Type;
		private string _Root_Cause;
		private string _Conclusions;
		private string _Confirmation_Assigned_To;
		private DateTime? _Target_Comp_Date;
		private DateTime? _Status_Due_On;
        private string _Incident_Investigation;
        private DateTime? _DateReviewed;
		private string _Comments;
		private decimal? _FK_LU_Item_Status;
		private string _Updated_By;
		private DateTime? _Update_Date;
		private decimal? _FK_AL_FR_ID;
		private decimal? _FK_PL_FR_ID;
		private decimal? _FK_DPD_FR_ID;
		private decimal? _FK_Property_FR_ID;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_SLT_Incident_Review value.
		/// </summary>
		public decimal? PK_SLT_Incident_Review
		{
			get { return _PK_SLT_Incident_Review; }
			set { _PK_SLT_Incident_Review = value; }
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
		/// Gets or sets the FK_WC_FR_ID value.
		/// </summary>
		public decimal? FK_WC_FR_ID
		{
			get { return _FK_WC_FR_ID; }
			set { _FK_WC_FR_ID = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Investigation_ID value.
		/// </summary>
		public decimal? FK_Investigation_ID
		{
			get { return _FK_Investigation_ID; }
			set { _FK_Investigation_ID = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Incident_Type value.
		/// </summary>
		public decimal? FK_LU_Incident_Type
		{
			get { return _FK_LU_Incident_Type; }
			set { _FK_LU_Incident_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Root_Cause value.
		/// </summary>
		public string Root_Cause
		{
			get { return _Root_Cause; }
			set { _Root_Cause = value; }
		}

		/// <summary>
		/// Gets or sets the Conclusions value.
		/// </summary>
		public string Conclusions
		{
			get { return _Conclusions; }
			set { _Conclusions = value; }
		}

		/// <summary>
		/// Gets or sets the Confirmation_Assigned_To value.
		/// </summary>
		public string Confirmation_Assigned_To
		{
			get { return _Confirmation_Assigned_To; }
			set { _Confirmation_Assigned_To = value; }
		}

		/// <summary>
		/// Gets or sets the Target_Comp_Date value.
		/// </summary>
		public DateTime? Target_Comp_Date
		{
			get { return _Target_Comp_Date; }
			set { _Target_Comp_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Status_Due_On value.
		/// </summary>
		public DateTime? Status_Due_On
		{
			get { return _Status_Due_On; }
			set { _Status_Due_On = value; }
		}

        /// <summary>
        /// Gets or sets the Incident_Investigation value.
        /// </summary>
        public string Incident_Investigation
        {
            get { return _Incident_Investigation; }
            set { _Incident_Investigation = value; }
        }

        /// <summary>
        /// Gets or sets the Status_Due_On value.
        /// </summary>
        public DateTime? DateReviewed
        {
            get { return _DateReviewed; }
            set { _DateReviewed = value; }
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
		/// Gets or sets the FK_AL_FR_ID value.
		/// </summary>
		public decimal? FK_AL_FR_ID
		{
			get { return _FK_AL_FR_ID; }
			set { _FK_AL_FR_ID = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PL_FR_ID value.
		/// </summary>
		public decimal? FK_PL_FR_ID
		{
			get { return _FK_PL_FR_ID; }
			set { _FK_PL_FR_ID = value; }
		}

		/// <summary>
		/// Gets or sets the FK_DPD_FR_ID value.
		/// </summary>
		public decimal? FK_DPD_FR_ID
		{
			get { return _FK_DPD_FR_ID; }
			set { _FK_DPD_FR_ID = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Property_FR_ID value.
		/// </summary>
		public decimal? FK_Property_FR_ID
		{
			get { return _FK_Property_FR_ID; }
			set { _FK_Property_FR_ID = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_Incident_Review class with default value.
		/// </summary>
		public SLT_Incident_Review() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSLT_Incident_Review class based on Primary Key.
		/// </summary>
		public SLT_Incident_Review(decimal pK_SLT_Incident_Review) 
		{
			DataTable dtSLT_Incident_Review = SelectByPK(pK_SLT_Incident_Review).Tables[0];

			if (dtSLT_Incident_Review.Rows.Count == 1)
			{
				 SetValue(dtSLT_Incident_Review.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsSLT_Incident_Review class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSLT_Incident_Review) 
		{
				if (drSLT_Incident_Review["PK_SLT_Incident_Review"] == DBNull.Value)
					this._PK_SLT_Incident_Review = null;
				else
					this._PK_SLT_Incident_Review = (decimal?)drSLT_Incident_Review["PK_SLT_Incident_Review"];

				if (drSLT_Incident_Review["FK_SLT_Meeting"] == DBNull.Value)
					this._FK_SLT_Meeting = null;
				else
					this._FK_SLT_Meeting = (decimal?)drSLT_Incident_Review["FK_SLT_Meeting"];

				if (drSLT_Incident_Review["FK_WC_FR_ID"] == DBNull.Value)
					this._FK_WC_FR_ID = null;
				else
					this._FK_WC_FR_ID = (decimal?)drSLT_Incident_Review["FK_WC_FR_ID"];

				if (drSLT_Incident_Review["FK_Investigation_ID"] == DBNull.Value)
					this._FK_Investigation_ID = null;
				else
					this._FK_Investigation_ID = (decimal?)drSLT_Incident_Review["FK_Investigation_ID"];

				if (drSLT_Incident_Review["FK_LU_Incident_Type"] == DBNull.Value)
					this._FK_LU_Incident_Type = null;
				else
					this._FK_LU_Incident_Type = (decimal?)drSLT_Incident_Review["FK_LU_Incident_Type"];

				if (drSLT_Incident_Review["Root_Cause"] == DBNull.Value)
					this._Root_Cause = null;
				else
					this._Root_Cause = (string)drSLT_Incident_Review["Root_Cause"];

				if (drSLT_Incident_Review["Conclusions"] == DBNull.Value)
					this._Conclusions = null;
				else
					this._Conclusions = (string)drSLT_Incident_Review["Conclusions"];

				if (drSLT_Incident_Review["Confirmation_Assigned_To"] == DBNull.Value)
					this._Confirmation_Assigned_To = null;
				else
					this._Confirmation_Assigned_To = (string)drSLT_Incident_Review["Confirmation_Assigned_To"];

				if (drSLT_Incident_Review["Target_Comp_Date"] == DBNull.Value)
					this._Target_Comp_Date = null;
				else
					this._Target_Comp_Date = (DateTime?)drSLT_Incident_Review["Target_Comp_Date"];

				if (drSLT_Incident_Review["Status_Due_On"] == DBNull.Value)
					this._Status_Due_On = null;
				else
					this._Status_Due_On = (DateTime?)drSLT_Incident_Review["Status_Due_On"];

                if (drSLT_Incident_Review["Incident_Investigation"] == DBNull.Value)
                    this._Incident_Investigation = null;
                else
                    this._Incident_Investigation = (string)drSLT_Incident_Review["Incident_Investigation"];


                if (drSLT_Incident_Review["DateReviewed"] == DBNull.Value)
                    this._DateReviewed = null;
                else
                    this._DateReviewed = (DateTime?)drSLT_Incident_Review["DateReviewed"];

				if (drSLT_Incident_Review["Comments"] == DBNull.Value)
					this._Comments = null;
				else
					this._Comments = (string)drSLT_Incident_Review["Comments"];

				if (drSLT_Incident_Review["FK_LU_Item_Status"] == DBNull.Value)
					this._FK_LU_Item_Status = null;
				else
					this._FK_LU_Item_Status = (decimal?)drSLT_Incident_Review["FK_LU_Item_Status"];

				if (drSLT_Incident_Review["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drSLT_Incident_Review["Updated_By"];

				if (drSLT_Incident_Review["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drSLT_Incident_Review["Update_Date"];

				if (drSLT_Incident_Review["FK_AL_FR_ID"] == DBNull.Value)
					this._FK_AL_FR_ID = null;
				else
					this._FK_AL_FR_ID = (decimal?)drSLT_Incident_Review["FK_AL_FR_ID"];

				if (drSLT_Incident_Review["FK_PL_FR_ID"] == DBNull.Value)
					this._FK_PL_FR_ID = null;
				else
					this._FK_PL_FR_ID = (decimal?)drSLT_Incident_Review["FK_PL_FR_ID"];

				if (drSLT_Incident_Review["FK_DPD_FR_ID"] == DBNull.Value)
					this._FK_DPD_FR_ID = null;
				else
					this._FK_DPD_FR_ID = (decimal?)drSLT_Incident_Review["FK_DPD_FR_ID"];

				if (drSLT_Incident_Review["FK_Property_FR_ID"] == DBNull.Value)
					this._FK_Property_FR_ID = null;
				else
					this._FK_Property_FR_ID = (decimal?)drSLT_Incident_Review["FK_Property_FR_ID"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the SLT_Incident_Review table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Incident_ReviewInsert");

			
			db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);
			
			db.AddInParameter(dbCommand, "FK_WC_FR_ID", DbType.Decimal, this._FK_WC_FR_ID);
			
			db.AddInParameter(dbCommand, "FK_Investigation_ID", DbType.Decimal, this._FK_Investigation_ID);
			
			db.AddInParameter(dbCommand, "FK_LU_Incident_Type", DbType.Decimal, this._FK_LU_Incident_Type);
			
			if (string.IsNullOrEmpty(this._Root_Cause))
				db.AddInParameter(dbCommand, "Root_Cause", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Root_Cause", DbType.String, this._Root_Cause);
			
			if (string.IsNullOrEmpty(this._Conclusions))
				db.AddInParameter(dbCommand, "Conclusions", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Conclusions", DbType.String, this._Conclusions);
			
			if (string.IsNullOrEmpty(this._Confirmation_Assigned_To))
				db.AddInParameter(dbCommand, "Confirmation_Assigned_To", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Confirmation_Assigned_To", DbType.String, this._Confirmation_Assigned_To);
			
			db.AddInParameter(dbCommand, "Target_Comp_Date", DbType.DateTime, this._Target_Comp_Date);
			
			db.AddInParameter(dbCommand, "Status_Due_On", DbType.DateTime, this._Status_Due_On);

            if (string.IsNullOrEmpty(this._Incident_Investigation))
                db.AddInParameter(dbCommand, "Incident_Investigation", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Incident_Investigation", DbType.String, this._Incident_Investigation);

            db.AddInParameter(dbCommand, "DateReviewed", DbType.DateTime, this._DateReviewed);

			if (string.IsNullOrEmpty(this._Comments))
				db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
			
			db.AddInParameter(dbCommand, "FK_LU_Item_Status", DbType.Decimal, this._FK_LU_Item_Status);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			db.AddInParameter(dbCommand, "FK_AL_FR_ID", DbType.Decimal, this._FK_AL_FR_ID);
			
			db.AddInParameter(dbCommand, "FK_PL_FR_ID", DbType.Decimal, this._FK_PL_FR_ID);
			
			db.AddInParameter(dbCommand, "FK_DPD_FR_ID", DbType.Decimal, this._FK_DPD_FR_ID);
			
			db.AddInParameter(dbCommand, "FK_Property_FR_ID", DbType.Decimal, this._FK_Property_FR_ID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the SLT_Incident_Review table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_SLT_Incident_Review)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Incident_ReviewSelectByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Incident_Review", DbType.Decimal, pK_SLT_Incident_Review);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the SLT_Incident_Review table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Incident_ReviewSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the SLT_Incident_Review table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Incident_ReviewUpdate");

			
			db.AddInParameter(dbCommand, "PK_SLT_Incident_Review", DbType.Decimal, this._PK_SLT_Incident_Review);
			
			db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);
			
			db.AddInParameter(dbCommand, "FK_WC_FR_ID", DbType.Decimal, this._FK_WC_FR_ID);
			
			db.AddInParameter(dbCommand, "FK_Investigation_ID", DbType.Decimal, this._FK_Investigation_ID);
			
			db.AddInParameter(dbCommand, "FK_LU_Incident_Type", DbType.Decimal, this._FK_LU_Incident_Type);
			
			if (string.IsNullOrEmpty(this._Root_Cause))
				db.AddInParameter(dbCommand, "Root_Cause", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Root_Cause", DbType.String, this._Root_Cause);
			
			if (string.IsNullOrEmpty(this._Conclusions))
				db.AddInParameter(dbCommand, "Conclusions", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Conclusions", DbType.String, this._Conclusions);
			
			if (string.IsNullOrEmpty(this._Confirmation_Assigned_To))
				db.AddInParameter(dbCommand, "Confirmation_Assigned_To", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Confirmation_Assigned_To", DbType.String, this._Confirmation_Assigned_To);
			
			db.AddInParameter(dbCommand, "Target_Comp_Date", DbType.DateTime, this._Target_Comp_Date);
			
			db.AddInParameter(dbCommand, "Status_Due_On", DbType.DateTime, this._Status_Due_On);

            if (string.IsNullOrEmpty(this._Incident_Investigation))
                db.AddInParameter(dbCommand, "Incident_Investigation", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Incident_Investigation", DbType.String, this._Incident_Investigation);

            db.AddInParameter(dbCommand, "DateReviewed", DbType.DateTime, this._DateReviewed);

			if (string.IsNullOrEmpty(this._Comments))
				db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
			
			db.AddInParameter(dbCommand, "FK_LU_Item_Status", DbType.Decimal, this._FK_LU_Item_Status);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			db.AddInParameter(dbCommand, "FK_AL_FR_ID", DbType.Decimal, this._FK_AL_FR_ID);
			
			db.AddInParameter(dbCommand, "FK_PL_FR_ID", DbType.Decimal, this._FK_PL_FR_ID);
			
			db.AddInParameter(dbCommand, "FK_DPD_FR_ID", DbType.Decimal, this._FK_DPD_FR_ID);
			
			db.AddInParameter(dbCommand, "FK_Property_FR_ID", DbType.Decimal, this._FK_Property_FR_ID);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the SLT_Incident_Review table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_SLT_Incident_Review)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SLT_Incident_ReviewDeleteByPK");

			db.AddInParameter(dbCommand, "PK_SLT_Incident_Review", DbType.Decimal, pK_SLT_Incident_Review);

			db.ExecuteNonQuery(dbCommand);
		}
        /// <summary>
        /// Get Records For Incident Review Grid
        /// </summary>
        public static DataSet GetIncident_Review(string strYear, decimal FK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sp_Incident_ReviewNew");

            db.AddInParameter(dbCommand, "Year", DbType.String, strYear);
            //db.AddInParameter(dbCommand, "month", DbType.String, strMonth);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Get Records For Incident Review Grid
        /// </summary>
        public static DataSet GetIncident_Review_FirstReport(string strYear, string strMonth, string strFR, decimal FK_LU_Location, decimal PK_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sp_Incident_Review_FirstReport");

            db.AddInParameter(dbCommand, "Year", DbType.String, strYear);
            db.AddInParameter(dbCommand, "month", DbType.String, strMonth);
            db.AddInParameter(dbCommand, "FR_Name", DbType.String, strFR);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            db.AddInParameter(dbCommand, "PK_FR_ID", DbType.Decimal, PK_FR_ID);
            return db.ExecuteDataSet(dbCommand);
        } 
        /// <summary>
        /// Get Records For Incident Review Grid BY PK_WC_FR_ID
        /// </summary>
        public static DataSet GetIncidentReviewByPK_WF_FR( decimal FK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SP_GetIncidentReviewByPK_WF_FR");
            db.AddInParameter(dbCommand, "PK_WC_FR_ID", DbType.Decimal, FK_LU_Location);
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
