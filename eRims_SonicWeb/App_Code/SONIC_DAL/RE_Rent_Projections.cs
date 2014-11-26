using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for RE_Rent_Projections table.
	/// </summary>
	public sealed class RE_Rent_Projections
	{

		#region Private variables used to hold the property values

		private decimal? _PK_RE_Rent_Projections;
		private decimal? _FK_RE_Information;
		private string _Responsible_Party;
		private string _Cancel_Options;
		private string _Renew_Options;
		private string _Option_Notification;
		private DateTime? _Notification_Due_Date;
		private decimal? _Subtenant_Base_Rent;
		private decimal? _Subtenant_Monthly_Rent;
		private decimal? _FK_LU_Escalation;
		private decimal? _Percentage_Rate;
		private decimal? _Increase;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_RE_Rent_Projections value.
		/// </summary>
		public decimal? PK_RE_Rent_Projections
		{
			get { return _PK_RE_Rent_Projections; }
			set { _PK_RE_Rent_Projections = value; }
		}

		/// <summary>
		/// Gets or sets the FK_RE_Information value.
		/// </summary>
		public decimal? FK_RE_Information
		{
			get { return _FK_RE_Information; }
			set { _FK_RE_Information = value; }
		}

		/// <summary>
		/// Gets or sets the Responsible_Party value.
		/// </summary>
		public string Responsible_Party
		{
			get { return _Responsible_Party; }
			set { _Responsible_Party = value; }
		}

		/// <summary>
		/// Gets or sets the Cancel_Options value.
		/// </summary>
		public string Cancel_Options
		{
			get { return _Cancel_Options; }
			set { _Cancel_Options = value; }
		}

		/// <summary>
		/// Gets or sets the Renew_Options value.
		/// </summary>
		public string Renew_Options
		{
			get { return _Renew_Options; }
			set { _Renew_Options = value; }
		}

		/// <summary>
		/// Gets or sets the Option_Notification value.
		/// </summary>
		public string Option_Notification
		{
			get { return _Option_Notification; }
			set { _Option_Notification = value; }
		}

		/// <summary>
		/// Gets or sets the Notification_Due_Date value.
		/// </summary>
		public DateTime? Notification_Due_Date
		{
			get { return _Notification_Due_Date; }
			set { _Notification_Due_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Base_Rent value.
		/// </summary>
		public decimal? Subtenant_Base_Rent
		{
			get { return _Subtenant_Base_Rent; }
			set { _Subtenant_Base_Rent = value; }
		}

		/// <summary>
		/// Gets or sets the Subtenant_Monthly_Rent value.
		/// </summary>
		public decimal? Subtenant_Monthly_Rent
		{
			get { return _Subtenant_Monthly_Rent; }
			set { _Subtenant_Monthly_Rent = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Escalation value.
		/// </summary>
		public decimal? FK_LU_Escalation
		{
			get { return _FK_LU_Escalation; }
			set { _FK_LU_Escalation = value; }
		}

		/// <summary>
		/// Gets or sets the Percentage_Rate value.
		/// </summary>
		public decimal? Percentage_Rate
		{
			get { return _Percentage_Rate; }
			set { _Percentage_Rate = value; }
		}

		/// <summary>
		/// Gets or sets the Increase value.
		/// </summary>
		public decimal? Increase
		{
			get { return _Increase; }
			set { _Increase = value; }
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


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the RE_Rent_Projections class with default value.
		/// </summary>
		public RE_Rent_Projections() 
		{
            setDefaultValues();
		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the RE_Rent_Projections class based on Primary Key.
		/// </summary>
		public RE_Rent_Projections(decimal pK_RE_Rent_Projections) 
		{
			DataTable dtRE_Rent_Projections = SelectByPK(pK_RE_Rent_Projections).Tables[0];

			if (dtRE_Rent_Projections.Rows.Count == 1)
			{
				DataRow drRE_Rent_Projections = dtRE_Rent_Projections.Rows[0];
				if (drRE_Rent_Projections["PK_RE_Rent_Projections"] == DBNull.Value)
					this._PK_RE_Rent_Projections = null;
				else
					this._PK_RE_Rent_Projections = (decimal?)drRE_Rent_Projections["PK_RE_Rent_Projections"];

				if (drRE_Rent_Projections["FK_RE_Information"] == DBNull.Value)
					this._FK_RE_Information = null;
				else
					this._FK_RE_Information = (decimal?)drRE_Rent_Projections["FK_RE_Information"];

				if (drRE_Rent_Projections["Responsible_Party"] == DBNull.Value)
					this._Responsible_Party = null;
				else
					this._Responsible_Party = (string)drRE_Rent_Projections["Responsible_Party"];

				if (drRE_Rent_Projections["Cancel_Options"] == DBNull.Value)
					this._Cancel_Options = null;
				else
					this._Cancel_Options = (string)drRE_Rent_Projections["Cancel_Options"];

				if (drRE_Rent_Projections["Renew_Options"] == DBNull.Value)
					this._Renew_Options = null;
				else
					this._Renew_Options = (string)drRE_Rent_Projections["Renew_Options"];

				if (drRE_Rent_Projections["Option_Notification"] == DBNull.Value)
					this._Option_Notification = null;
				else
					this._Option_Notification = (string)drRE_Rent_Projections["Option_Notification"];

				if (drRE_Rent_Projections["Notification_Due_Date"] == DBNull.Value)
					this._Notification_Due_Date = null;
				else
					this._Notification_Due_Date = (DateTime?)drRE_Rent_Projections["Notification_Due_Date"];

				if (drRE_Rent_Projections["Subtenant_Base_Rent"] == DBNull.Value)
					this._Subtenant_Base_Rent = null;
				else
					this._Subtenant_Base_Rent = (decimal?)drRE_Rent_Projections["Subtenant_Base_Rent"];

				if (drRE_Rent_Projections["Subtenant_Monthly_Rent"] == DBNull.Value)
					this._Subtenant_Monthly_Rent = null;
				else
					this._Subtenant_Monthly_Rent = (decimal?)drRE_Rent_Projections["Subtenant_Monthly_Rent"];

				if (drRE_Rent_Projections["FK_LU_Escalation"] == DBNull.Value)
					this._FK_LU_Escalation = null;
				else
					this._FK_LU_Escalation = (decimal?)drRE_Rent_Projections["FK_LU_Escalation"];

				if (drRE_Rent_Projections["Percentage_Rate"] == DBNull.Value)
					this._Percentage_Rate = null;
				else
					this._Percentage_Rate = (decimal?)drRE_Rent_Projections["Percentage_Rate"];

				if (drRE_Rent_Projections["Increase"] == DBNull.Value)
					this._Increase = null;
				else
					this._Increase = (decimal?)drRE_Rent_Projections["Increase"];

				if (drRE_Rent_Projections["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drRE_Rent_Projections["Updated_By"];

				if (drRE_Rent_Projections["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drRE_Rent_Projections["Update_Date"];

			}
			else
			{
                setDefaultValues();
			}

		}

        /// <summary>
        /// Initializes a new instance of the RE_Rent_Projections class based on Primary Key.
        /// </summary>
        public RE_Rent_Projections(decimal FK_RE_Information,bool status)
        {
            DataTable dtRE_Rent_Projections = SelectByFK(FK_RE_Information).Tables[0];

            if (dtRE_Rent_Projections.Rows.Count == 1)
            {
                DataRow drRE_Rent_Projections = dtRE_Rent_Projections.Rows[0];
                if (drRE_Rent_Projections["PK_RE_Rent_Projections"] == DBNull.Value)
                    this._PK_RE_Rent_Projections = null;
                else
                    this._PK_RE_Rent_Projections = (decimal?)drRE_Rent_Projections["PK_RE_Rent_Projections"];

                if (drRE_Rent_Projections["FK_RE_Information"] == DBNull.Value)
                    this._FK_RE_Information = null;
                else
                    this._FK_RE_Information = (decimal?)drRE_Rent_Projections["FK_RE_Information"];

                if (drRE_Rent_Projections["Responsible_Party"] == DBNull.Value)
                    this._Responsible_Party = null;
                else
                    this._Responsible_Party = (string)drRE_Rent_Projections["Responsible_Party"];

                if (drRE_Rent_Projections["Cancel_Options"] == DBNull.Value)
                    this._Cancel_Options = null;
                else
                    this._Cancel_Options = (string)drRE_Rent_Projections["Cancel_Options"];

                if (drRE_Rent_Projections["Renew_Options"] == DBNull.Value)
                    this._Renew_Options = null;
                else
                    this._Renew_Options = (string)drRE_Rent_Projections["Renew_Options"];

                if (drRE_Rent_Projections["Option_Notification"] == DBNull.Value)
                    this._Option_Notification = null;
                else
                    this._Option_Notification = (string)drRE_Rent_Projections["Option_Notification"];

                if (drRE_Rent_Projections["Notification_Due_Date"] == DBNull.Value)
                    this._Notification_Due_Date = null;
                else
                    this._Notification_Due_Date = (DateTime?)drRE_Rent_Projections["Notification_Due_Date"];

                if (drRE_Rent_Projections["Subtenant_Base_Rent"] == DBNull.Value)
                    this._Subtenant_Base_Rent = null;
                else
                    this._Subtenant_Base_Rent = (decimal?)drRE_Rent_Projections["Subtenant_Base_Rent"];

                if (drRE_Rent_Projections["Subtenant_Monthly_Rent"] == DBNull.Value)
                    this._Subtenant_Monthly_Rent = null;
                else
                    this._Subtenant_Monthly_Rent = (decimal?)drRE_Rent_Projections["Subtenant_Monthly_Rent"];

                if (drRE_Rent_Projections["FK_LU_Escalation"] == DBNull.Value)
                    this._FK_LU_Escalation = null;
                else
                    this._FK_LU_Escalation = (decimal?)drRE_Rent_Projections["FK_LU_Escalation"];

                if (drRE_Rent_Projections["Percentage_Rate"] == DBNull.Value)
                    this._Percentage_Rate = null;
                else
                    this._Percentage_Rate = (decimal?)drRE_Rent_Projections["Percentage_Rate"];

                if (drRE_Rent_Projections["Increase"] == DBNull.Value)
                    this._Increase = null;
                else
                    this._Increase = (decimal?)drRE_Rent_Projections["Increase"];

                if (drRE_Rent_Projections["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drRE_Rent_Projections["Updated_By"];

                if (drRE_Rent_Projections["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drRE_Rent_Projections["Update_Date"];

            }
            else
            {
                setDefaultValues();
            }
        }

		#endregion

        private void setDefaultValues()
        {
            this._PK_RE_Rent_Projections = null;
            this._FK_RE_Information = null;
            this._Responsible_Party = null;
            this._Cancel_Options = null;
            this._Renew_Options = null;
            this._Option_Notification = null;
            this._Notification_Due_Date = null;
            this._Subtenant_Base_Rent = null;
            this._Subtenant_Monthly_Rent = null;
            this._FK_LU_Escalation = null;
            this._Percentage_Rate = null;
            this._Increase = null;
            this._Updated_By = null;
            this._Update_Date = null;
        }


		/// <summary>
		/// Inserts a record into the RE_Rent_Projections table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_ProjectionsInsert");

			
			db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);
			
			if (string.IsNullOrEmpty(this._Responsible_Party))
				db.AddInParameter(dbCommand, "Responsible_Party", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Responsible_Party", DbType.String, this._Responsible_Party);
			
			if (string.IsNullOrEmpty(this._Cancel_Options))
				db.AddInParameter(dbCommand, "Cancel_Options", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Cancel_Options", DbType.String, this._Cancel_Options);
			
			if (string.IsNullOrEmpty(this._Renew_Options))
				db.AddInParameter(dbCommand, "Renew_Options", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Renew_Options", DbType.String, this._Renew_Options);
			
			if (string.IsNullOrEmpty(this._Option_Notification))
				db.AddInParameter(dbCommand, "Option_Notification", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Option_Notification", DbType.String, this._Option_Notification);
			
			db.AddInParameter(dbCommand, "Notification_Due_Date", DbType.DateTime, this._Notification_Due_Date);
			
			db.AddInParameter(dbCommand, "Subtenant_Base_Rent", DbType.Decimal, this._Subtenant_Base_Rent);
			
			db.AddInParameter(dbCommand, "Subtenant_Monthly_Rent", DbType.Decimal, this._Subtenant_Monthly_Rent);
			
			db.AddInParameter(dbCommand, "FK_LU_Escalation", DbType.Decimal, this._FK_LU_Escalation);
			
			db.AddInParameter(dbCommand, "Percentage_Rate", DbType.Decimal, this._Percentage_Rate);
			
			db.AddInParameter(dbCommand, "Increase", DbType.Decimal, this._Increase);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the RE_Rent_Projections table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_RE_Rent_Projections)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_ProjectionsSelectByPK");

			db.AddInParameter(dbCommand, "PK_RE_Rent_Projections", DbType.Decimal, pK_RE_Rent_Projections);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the RE_Rent_Projections table by a foriegn key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByFK(decimal FK_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_ProjectionsSelectByFK");

            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, FK_RE_Information);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the RE_Rent_Projections table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_ProjectionsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the RE_Rent_Projections table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_ProjectionsUpdate");

			
			db.AddInParameter(dbCommand, "PK_RE_Rent_Projections", DbType.Decimal, this._PK_RE_Rent_Projections);
			
			db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);
			
			if (string.IsNullOrEmpty(this._Responsible_Party))
				db.AddInParameter(dbCommand, "Responsible_Party", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Responsible_Party", DbType.String, this._Responsible_Party);
			
			if (string.IsNullOrEmpty(this._Cancel_Options))
				db.AddInParameter(dbCommand, "Cancel_Options", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Cancel_Options", DbType.String, this._Cancel_Options);
			
			if (string.IsNullOrEmpty(this._Renew_Options))
				db.AddInParameter(dbCommand, "Renew_Options", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Renew_Options", DbType.String, this._Renew_Options);
			
			if (string.IsNullOrEmpty(this._Option_Notification))
				db.AddInParameter(dbCommand, "Option_Notification", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Option_Notification", DbType.String, this._Option_Notification);
			
			db.AddInParameter(dbCommand, "Notification_Due_Date", DbType.DateTime, this._Notification_Due_Date);
			
			db.AddInParameter(dbCommand, "Subtenant_Base_Rent", DbType.Decimal, this._Subtenant_Base_Rent);
			
			db.AddInParameter(dbCommand, "Subtenant_Monthly_Rent", DbType.Decimal, this._Subtenant_Monthly_Rent);
			
			db.AddInParameter(dbCommand, "FK_LU_Escalation", DbType.Decimal, this._FK_LU_Escalation);
			
			db.AddInParameter(dbCommand, "Percentage_Rate", DbType.Decimal, this._Percentage_Rate);
			
			db.AddInParameter(dbCommand, "Increase", DbType.Decimal, this._Increase);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the RE_Rent_Projections table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_RE_Rent_Projections)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_ProjectionsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_RE_Rent_Projections", DbType.Decimal, pK_RE_Rent_Projections);

			db.ExecuteNonQuery(dbCommand);
		}        
	}
}
