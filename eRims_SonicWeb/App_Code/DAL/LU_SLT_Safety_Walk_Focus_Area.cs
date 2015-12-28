using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table LU_SLT_Safety_Walk_Focus_Area
	/// </summary>
	public sealed class LU_SLT_Safety_Walk_Focus_Area
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_SLT_Safety_Walk_Focus_Area;
		private int? _Year;
		private string _Month;
		private string _Focus_Area;
		private int? _Sort_Order;
		private string _Question;
		private string _Guidance;
		private string _Reference;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_SLT_Safety_Walk_Focus_Area value.
		/// </summary>
		public decimal? PK_LU_SLT_Safety_Walk_Focus_Area
		{
			get { return _PK_LU_SLT_Safety_Walk_Focus_Area; }
			set { _PK_LU_SLT_Safety_Walk_Focus_Area = value; }
		}

		/// <summary>
		/// Gets or sets the Year value.
		/// </summary>
		public int? Year
		{
			get { return _Year; }
			set { _Year = value; }
		}

		/// <summary>
		/// Gets or sets the Month value.
		/// </summary>
		public string Month
		{
			get { return _Month; }
			set { _Month = value; }
		}

		/// <summary>
		/// Gets or sets the Focus_Area value.
		/// </summary>
		public string Focus_Area
		{
			get { return _Focus_Area; }
			set { _Focus_Area = value; }
		}

		/// <summary>
		/// Gets or sets the Sort_Order value.
		/// </summary>
		public int? Sort_Order
		{
			get { return _Sort_Order; }
			set { _Sort_Order = value; }
		}

		/// <summary>
		/// Gets or sets the Question value.
		/// </summary>
		public string Question
		{
			get { return _Question; }
			set { _Question = value; }
		}

		/// <summary>
		/// Gets or sets the Guidance value.
		/// </summary>
		public string Guidance
		{
			get { return _Guidance; }
			set { _Guidance = value; }
		}

		/// <summary>
		/// Gets or sets the Reference value.
		/// </summary>
		public string Reference
		{
			get { return _Reference; }
			set { _Reference = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_SLT_Safety_Walk_Focus_Area class with default value.
		/// </summary>
		public LU_SLT_Safety_Walk_Focus_Area() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_SLT_Safety_Walk_Focus_Area class based on Primary Key.
		/// </summary>
		public LU_SLT_Safety_Walk_Focus_Area(decimal pK_LU_SLT_Safety_Walk_Focus_Area) 
		{
			DataTable dtLU_SLT_Safety_Walk_Focus_Area = Select(pK_LU_SLT_Safety_Walk_Focus_Area).Tables[0];

			if (dtLU_SLT_Safety_Walk_Focus_Area.Rows.Count == 1)
			{
				 SetValue(dtLU_SLT_Safety_Walk_Focus_Area.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_SLT_Safety_Walk_Focus_Area class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_SLT_Safety_Walk_Focus_Area) 
		{
				if (drLU_SLT_Safety_Walk_Focus_Area["PK_LU_SLT_Safety_Walk_Focus_Area"] == DBNull.Value)
					this._PK_LU_SLT_Safety_Walk_Focus_Area = null;
				else
					this._PK_LU_SLT_Safety_Walk_Focus_Area = (decimal?)drLU_SLT_Safety_Walk_Focus_Area["PK_LU_SLT_Safety_Walk_Focus_Area"];

				if (drLU_SLT_Safety_Walk_Focus_Area["Year"] == DBNull.Value)
					this._Year = null;
				else
					this._Year = (int?)drLU_SLT_Safety_Walk_Focus_Area["Year"];

				if (drLU_SLT_Safety_Walk_Focus_Area["Month"] == DBNull.Value)
					this._Month = null;
				else
					this._Month = (string)drLU_SLT_Safety_Walk_Focus_Area["Month"];

				if (drLU_SLT_Safety_Walk_Focus_Area["Focus_Area"] == DBNull.Value)
					this._Focus_Area = null;
				else
					this._Focus_Area = (string)drLU_SLT_Safety_Walk_Focus_Area["Focus_Area"];

				if (drLU_SLT_Safety_Walk_Focus_Area["Sort_Order"] == DBNull.Value)
					this._Sort_Order = null;
				else
					this._Sort_Order = (int?)drLU_SLT_Safety_Walk_Focus_Area["Sort_Order"];

				if (drLU_SLT_Safety_Walk_Focus_Area["Question"] == DBNull.Value)
					this._Question = null;
				else
					this._Question = (string)drLU_SLT_Safety_Walk_Focus_Area["Question"];

				if (drLU_SLT_Safety_Walk_Focus_Area["Guidance"] == DBNull.Value)
					this._Guidance = null;
				else
					this._Guidance = (string)drLU_SLT_Safety_Walk_Focus_Area["Guidance"];

				if (drLU_SLT_Safety_Walk_Focus_Area["Reference"] == DBNull.Value)
					this._Reference = null;
				else
					this._Reference = (string)drLU_SLT_Safety_Walk_Focus_Area["Reference"];

				if (drLU_SLT_Safety_Walk_Focus_Area["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_SLT_Safety_Walk_Focus_Area["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_SLT_Safety_Walk_Focus_Area table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_Focus_AreaInsert");

			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			if (string.IsNullOrEmpty(this._Month))
				db.AddInParameter(dbCommand, "Month", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Month", DbType.String, this._Month);
			
			if (string.IsNullOrEmpty(this._Focus_Area))
				db.AddInParameter(dbCommand, "Focus_Area", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Focus_Area", DbType.String, this._Focus_Area);
			
			db.AddInParameter(dbCommand, "Sort_Order", DbType.Int32, this._Sort_Order);
			
			if (string.IsNullOrEmpty(this._Question))
				db.AddInParameter(dbCommand, "Question", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Question", DbType.String, this._Question);
			
			if (string.IsNullOrEmpty(this._Guidance))
				db.AddInParameter(dbCommand, "Guidance", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Guidance", DbType.String, this._Guidance);
			
			if (string.IsNullOrEmpty(this._Reference))
				db.AddInParameter(dbCommand, "Reference", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Reference", DbType.String, this._Reference);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

        /// <summary>
        /// Inserts Annual a record into the LU_SLT_Safety_Walk_Focus_Area table.
        /// </summary>
        /// <returns></returns>
        public int InsertAnnual()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_Focus_Area_Annual_Insert");


            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);

            if (string.IsNullOrEmpty(this._Focus_Area))
                db.AddInParameter(dbCommand, "Focus_Area", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Focus_Area", DbType.String, this._Focus_Area);

            if (string.IsNullOrEmpty(this._Question))
                db.AddInParameter(dbCommand, "Question", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Question", DbType.String, this._Question);

            if (string.IsNullOrEmpty(this._Guidance))
                db.AddInParameter(dbCommand, "Guidance", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guidance", DbType.String, this._Guidance);

            if (string.IsNullOrEmpty(this._Reference))
                db.AddInParameter(dbCommand, "Reference", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Reference", DbType.String, this._Reference);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

		/// <summary>
		/// Selects a single record from the LU_SLT_Safety_Walk_Focus_Area table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_SLT_Safety_Walk_Focus_Area)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_Focus_AreaSelect");

			db.AddInParameter(dbCommand, "PK_LU_SLT_Safety_Walk_Focus_Area", DbType.Decimal, pK_LU_SLT_Safety_Walk_Focus_Area);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Search a single record from the LU_SLT_Safety_Walk_Focus_Area table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet Search(Int32 Year, string Month, bool IsAnnual, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_Focus_Area_Search");

            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "Month", DbType.String, Month);
            db.AddInParameter(dbCommand, "IsAnnual", DbType.Boolean, IsAnnual);
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the LU_SLT_Safety_Walk_Focus_Area table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_Focus_AreaSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_SLT_Safety_Walk_Focus_Area table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_Focus_AreaUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_SLT_Safety_Walk_Focus_Area", DbType.Decimal, this._PK_LU_SLT_Safety_Walk_Focus_Area);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			if (string.IsNullOrEmpty(this._Month))
				db.AddInParameter(dbCommand, "Month", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Month", DbType.String, this._Month);
			
			if (string.IsNullOrEmpty(this._Focus_Area))
				db.AddInParameter(dbCommand, "Focus_Area", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Focus_Area", DbType.String, this._Focus_Area);
			
			db.AddInParameter(dbCommand, "Sort_Order", DbType.Int32, this._Sort_Order);
			
			if (string.IsNullOrEmpty(this._Question))
				db.AddInParameter(dbCommand, "Question", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Question", DbType.String, this._Question);
			
			if (string.IsNullOrEmpty(this._Guidance))
				db.AddInParameter(dbCommand, "Guidance", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Guidance", DbType.String, this._Guidance);
			
			if (string.IsNullOrEmpty(this._Reference))
				db.AddInParameter(dbCommand, "Reference", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Reference", DbType.String, this._Reference);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
			//db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Updates Annual a record in the LU_SLT_Safety_Walk_Focus_Area table.
        /// </summary>
        public int UpdateAnnual()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_Focus_Area_Annual_Update");


            db.AddInParameter(dbCommand, "PK_LU_SLT_Safety_Walk_Focus_Area", DbType.Decimal, this._PK_LU_SLT_Safety_Walk_Focus_Area);

            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);

            if (string.IsNullOrEmpty(this._Focus_Area))
                db.AddInParameter(dbCommand, "Focus_Area", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Focus_Area", DbType.String, this._Focus_Area);

            if (string.IsNullOrEmpty(this._Question))
                db.AddInParameter(dbCommand, "Question", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Question", DbType.String, this._Question);

            if (string.IsNullOrEmpty(this._Guidance))
                db.AddInParameter(dbCommand, "Guidance", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Guidance", DbType.String, this._Guidance);

            if (string.IsNullOrEmpty(this._Reference))
                db.AddInParameter(dbCommand, "Reference", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Reference", DbType.String, this._Reference);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
            //db.ExecuteNonQuery(dbCommand);
        }

		/// <summary>
		/// Deletes a record from the LU_SLT_Safety_Walk_Focus_Area table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_SLT_Safety_Walk_Focus_Area)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_Focus_AreaDelete");

			db.AddInParameter(dbCommand, "PK_LU_SLT_Safety_Walk_Focus_Area", DbType.Decimal, pK_LU_SLT_Safety_Walk_Focus_Area);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Update Sort Order a record from the LU_SLT_Safety_Walk_Focus_Area table by a composite primary key.
        /// </summary>
        public static void UpdateSortOrder_Monthly(decimal pK_LU_SLT_Safety_Walk_Focus_Area,string Sort_Order)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_Focus_Area_UpdateSortOrder_Monthly");

            db.AddInParameter(dbCommand, "PK_LU_SLT_Safety_Walk_Focus_Area", DbType.Decimal, pK_LU_SLT_Safety_Walk_Focus_Area);
            db.AddInParameter(dbCommand, "Sort_Order", DbType.String, Sort_Order);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Update Sort Order a record from the LU_SLT_Safety_Walk_Focus_Area table by a composite primary key.
        /// </summary>
        public static void UpdateSortOrder_Annual(decimal pK_LU_SLT_Safety_Walk_Focus_Area, string Sort_Order)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_Focus_Area_UpdateSortOrder_Annual");

            db.AddInParameter(dbCommand, "PK_LU_SLT_Safety_Walk_Focus_Area", DbType.Decimal, pK_LU_SLT_Safety_Walk_Focus_Area);
            db.AddInParameter(dbCommand, "Sort_Order", DbType.String, Sort_Order);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Search records from the LU_SLT_Safety_Walk_Focus_Area table by Month and year.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByMonthAndYear(Int32 Year, string Month, decimal pK_LU_SLT_Safety_Walk_Focus_Area, decimal FK_SLT_Meeting_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_Focus_Area_SelectByMonth_Year");

            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "Month", DbType.String, Month);
            db.AddInParameter(dbCommand, "PK_LU_SLT_Safety_Walk_Focus_Area", DbType.Decimal, pK_LU_SLT_Safety_Walk_Focus_Area);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting_Schedule);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select records for SLT_Meeting_minutesPrint_New letter
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectSafteyWalkLetterData(Int32 Year, string Month,  decimal FK_SLT_Meeting_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_SLT_Safety_Walk_Data_for_Letter");

            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "Month", DbType.String, Month);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting_Schedule);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetMonthlySLTSafetyWalkGrid(decimal FK_SLT_Meeting, int Month, decimal FK_SLT_Meeting_Schedule,Int32 Year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetMonthlySLTSafetyWalkGrid");
            db.AddInParameter(dbCommand, "Month", DbType.String, Month);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting_Schedule);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetSLTSafetyWalkOpenObservation(decimal FK_SLT_Meeting, int Month, decimal FK_SLT_Meeting_Schedule, int Year, bool IsForPriorMonths)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetSLTSafetyWalkOpenObservation");
            db.AddInParameter(dbCommand, "Month", DbType.String, Month);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting_Schedule);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "IsForPriorMonths", DbType.Boolean, IsForPriorMonths);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetQuestions_OfOpenObservation(int Month, decimal FK_SLT_Meeting_Schedule, int Year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetQuestions_OfOpenObservation");
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting_Schedule);
            db.AddInParameter(dbCommand, "Month", DbType.String, Month);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Update Sort Order a record from the EditFocusArea table by a composite primary key.
        /// </summary>
        public static void EditFocusArea(Int32 Year, string Month, string Focus_Area, bool IsAnnual)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EditFocusArea");

            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "Month", DbType.String, Month);
            db.AddInParameter(dbCommand, "Focus_Area", DbType.String, Focus_Area);
            db.AddInParameter(dbCommand, "IsAnnual", DbType.Boolean, IsAnnual);
            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet GetSLTQuestions_OfNextMeeting(decimal FK_SLT_Meeting, decimal FK_SLT_Meeting_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetSLTQuestions_OfNextMeeting");
            db.AddInParameter(dbCommand, "PK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting_Schedule);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
