using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for RE_Rent_RRS table.
	/// </summary>
	public sealed class RE_Rent_RRS
	{

		#region Private variables used to hold the property values

		private decimal? _PK_RE_Rent_RRS;
		private decimal? _FK_RE_Rent;
		private decimal? _Option_Period;
		private DateTime? _From_Date;
		private DateTime? _To_Date;
		private decimal? _Months;
		private decimal? _Monthly_Rent;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_RE_Rent_RRS value.
		/// </summary>
		public decimal? PK_RE_Rent_RRS
		{
			get { return _PK_RE_Rent_RRS; }
			set { _PK_RE_Rent_RRS = value; }
		}

		/// <summary>
		/// Gets or sets the FK_RE_Rent value.
		/// </summary>
		public decimal? FK_RE_Rent
		{
			get { return _FK_RE_Rent; }
			set { _FK_RE_Rent = value; }
		}

		/// <summary>
		/// Gets or sets the Option_Period value.
		/// </summary>
		public decimal? Option_Period
		{
			get { return _Option_Period; }
			set { _Option_Period = value; }
		}

		/// <summary>
		/// Gets or sets the From_Date value.
		/// </summary>
		public DateTime? From_Date
		{
			get { return _From_Date; }
			set { _From_Date = value; }
		}

		/// <summary>
		/// Gets or sets the To_Date value.
		/// </summary>
		public DateTime? To_Date
		{
			get { return _To_Date; }
			set { _To_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Months value.
		/// </summary>
		public decimal? Months
		{
			get { return _Months; }
			set { _Months = value; }
		}

		/// <summary>
		/// Gets or sets the Monthly_Rent value.
		/// </summary>
		public decimal? Monthly_Rent
		{
			get { return _Monthly_Rent; }
			set { _Monthly_Rent = value; }
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
		/// Initializes a new instance of the RE_Rent_RRS class with default value.
		/// </summary>
		public RE_Rent_RRS() 
		{

			this._PK_RE_Rent_RRS = null;
			this._FK_RE_Rent = null;
			this._Option_Period = null;
			this._From_Date = null;
			this._To_Date = null;
			this._Months = null;
			this._Monthly_Rent = null;
			this._Updated_By = null;
			this._Update_Date = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the RE_Rent_RRS class based on Primary Key.
		/// </summary>
		public RE_Rent_RRS(decimal pK_RE_Rent_RRS) 
		{
			DataTable dtRE_Rent_RRS = SelectByPK(pK_RE_Rent_RRS).Tables[0];

			if (dtRE_Rent_RRS.Rows.Count == 1)
			{
				DataRow drRE_Rent_RRS = dtRE_Rent_RRS.Rows[0];
				if (drRE_Rent_RRS["PK_RE_Rent_RRS"] == DBNull.Value)
					this._PK_RE_Rent_RRS = null;
				else
					this._PK_RE_Rent_RRS = (decimal?)drRE_Rent_RRS["PK_RE_Rent_RRS"];

				if (drRE_Rent_RRS["FK_RE_Rent"] == DBNull.Value)
					this._FK_RE_Rent = null;
				else
					this._FK_RE_Rent = (decimal?)drRE_Rent_RRS["FK_RE_Rent"];

				if (drRE_Rent_RRS["Option_Period"] == DBNull.Value)
					this._Option_Period = null;
				else
					this._Option_Period = (decimal?)drRE_Rent_RRS["Option_Period"];

				if (drRE_Rent_RRS["From_Date"] == DBNull.Value)
					this._From_Date = null;
				else
					this._From_Date = (DateTime?)drRE_Rent_RRS["From_Date"];

				if (drRE_Rent_RRS["To_Date"] == DBNull.Value)
					this._To_Date = null;
				else
					this._To_Date = (DateTime?)drRE_Rent_RRS["To_Date"];

				if (drRE_Rent_RRS["Months"] == DBNull.Value)
					this._Months = null;
				else
					this._Months = (decimal?)drRE_Rent_RRS["Months"];

				if (drRE_Rent_RRS["Monthly_Rent"] == DBNull.Value)
					this._Monthly_Rent = null;
				else
					this._Monthly_Rent = (decimal?)drRE_Rent_RRS["Monthly_Rent"];

				if (drRE_Rent_RRS["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drRE_Rent_RRS["Updated_By"];

				if (drRE_Rent_RRS["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drRE_Rent_RRS["Update_Date"];

			}
			else
			{
				this._PK_RE_Rent_RRS = null;
				this._FK_RE_Rent = null;
				this._Option_Period = null;
				this._From_Date = null;
				this._To_Date = null;
				this._Months = null;
				this._Monthly_Rent = null;
				this._Updated_By = null;
				this._Update_Date = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the RE_Rent_RRS table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_RRSInsert");

			
			db.AddInParameter(dbCommand, "FK_RE_Rent", DbType.Decimal, this._FK_RE_Rent);
			
			db.AddInParameter(dbCommand, "Option_Period", DbType.Decimal, this._Option_Period);
			
			db.AddInParameter(dbCommand, "From_Date", DbType.DateTime, this._From_Date);
			
			db.AddInParameter(dbCommand, "To_Date", DbType.DateTime, this._To_Date);
			
			db.AddInParameter(dbCommand, "Months", DbType.Decimal, this._Months);
			
			db.AddInParameter(dbCommand, "Monthly_Rent", DbType.Decimal, this._Monthly_Rent);
			
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
		/// Selects a single record from the RE_Rent_RRS table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_RE_Rent_RRS)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_RRSSelectByPK");

			db.AddInParameter(dbCommand, "PK_RE_Rent_RRS", DbType.Decimal, pK_RE_Rent_RRS);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the RE_Rent_RRS table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_RRSSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the RE_Rent_RRS table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_RRSUpdate");

			
			db.AddInParameter(dbCommand, "PK_RE_Rent_RRS", DbType.Decimal, this._PK_RE_Rent_RRS);
			
			db.AddInParameter(dbCommand, "FK_RE_Rent", DbType.Decimal, this._FK_RE_Rent);
			
			db.AddInParameter(dbCommand, "Option_Period", DbType.Decimal, this._Option_Period);
			
			db.AddInParameter(dbCommand, "From_Date", DbType.DateTime, this._From_Date);
			
			db.AddInParameter(dbCommand, "To_Date", DbType.DateTime, this._To_Date);
			
			db.AddInParameter(dbCommand, "Months", DbType.Decimal, this._Months);
			
			db.AddInParameter(dbCommand, "Monthly_Rent", DbType.Decimal, this._Monthly_Rent);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the RE_Rent_RRS table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_RE_Rent_RRS)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_RRSDeleteByPK");

			db.AddInParameter(dbCommand, "PK_RE_Rent_RRS", DbType.Decimal, pK_RE_Rent_RRS);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectByFK(decimal fK_RE_Rent)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_RRSSelectByFK");

            db.AddInParameter(dbCommand, "FK_RE_Rent", DbType.Decimal, fK_RE_Rent);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select  Monthlyrent details
        /// </summary>
        /// <returns>DataSet</returns>
        public static Decimal SelectMonthlyRent(decimal fK_RE_Rent, int intStartYear, int intEndYear)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_RentORS_MonthlyRent");

            db.AddInParameter(dbCommand, "FK_RE_Rent", DbType.Decimal, fK_RE_Rent);
            db.AddInParameter(dbCommand, "StartYear", DbType.Decimal, intStartYear);
            db.AddInParameter(dbCommand, "EndYear", DbType.Decimal, intEndYear);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        /// Select Max Year and Monthlyrent details
        /// </summary>
        /// <returns>DataSet</returns>
        public static int SelectOptionPeriodByPK(decimal fK_RE_Rent)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_RRS_OptionPeriodByPK");

            db.AddInParameter(dbCommand, "FK_RE_Rent", DbType.Decimal, fK_RE_Rent);

            return Convert.ToInt32(db.ExecuteScalar(dbCommand));
        }

        public static void UpdateRents(decimal pK_RE_Rent_RRS, decimal monthly_Rent)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_RRS_UpdateRents");

            db.AddInParameter(dbCommand, "PK_RE_Rent_RRS", DbType.Decimal, pK_RE_Rent_RRS);
            db.AddInParameter(dbCommand, "Monthly_Rent", DbType.Decimal, monthly_Rent);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}
