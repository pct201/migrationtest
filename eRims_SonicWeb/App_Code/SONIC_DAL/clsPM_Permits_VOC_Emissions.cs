using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Permits_VOC_Emissions table.
	/// </summary>
	public sealed class clsPM_Permits_VOC_Emissions
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Permits_VOC_Emissions;
		private decimal? _FK_PM_Permits;
		private int? _Year;
		private int? _Month;
		private decimal? _FK_LU_VOC_Category;
		private string _SubTotal_Text;
		private string _Part_Number;
		private string _Unit;
		private string _Quantity;
		private decimal? _Gallons;
		private decimal? _VOC_Emissions;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Permits_VOC_Emissions value.
		/// </summary>
		public decimal? PK_PM_Permits_VOC_Emissions
		{
			get { return _PK_PM_Permits_VOC_Emissions; }
			set { _PK_PM_Permits_VOC_Emissions = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_Permits value.
		/// </summary>
		public decimal? FK_PM_Permits
		{
			get { return _FK_PM_Permits; }
			set { _FK_PM_Permits = value; }
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
		public int? Month
		{
			get { return _Month; }
			set { _Month = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_VOC_Category value.
		/// </summary>
		public decimal? FK_LU_VOC_Category
		{
			get { return _FK_LU_VOC_Category; }
			set { _FK_LU_VOC_Category = value; }
		}

		/// <summary>
		/// Gets or sets the SubTotal_Text value.
		/// </summary>
		public string SubTotal_Text
		{
			get { return _SubTotal_Text; }
			set { _SubTotal_Text = value; }
		}

		/// <summary>
		/// Gets or sets the Part_Number value.
		/// </summary>
		public string Part_Number
		{
			get { return _Part_Number; }
			set { _Part_Number = value; }
		}

		/// <summary>
		/// Gets or sets the Unit value.
		/// </summary>
		public string Unit
		{
			get { return _Unit; }
			set { _Unit = value; }
		}

		/// <summary>
		/// Gets or sets the Quantity value.
		/// </summary>
		public string Quantity
		{
			get { return _Quantity; }
			set { _Quantity = value; }
		}

		/// <summary>
		/// Gets or sets the Gallons value.
		/// </summary>
		public decimal? Gallons
		{
			get { return _Gallons; }
			set { _Gallons = value; }
		}

		/// <summary>
		/// Gets or sets the VOC_Emissions value.
		/// </summary>
		public decimal? VOC_Emissions
		{
			get { return _VOC_Emissions; }
			set { _VOC_Emissions = value; }
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
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Permits_VOC_Emissions class with default value.
		/// </summary>
		public clsPM_Permits_VOC_Emissions() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Permits_VOC_Emissions class based on Primary Key.
		/// </summary>
		public clsPM_Permits_VOC_Emissions(decimal pK_PM_Permits_VOC_Emissions) 
		{
			DataTable dtPM_Permits_VOC_Emissions = SelectByPK(pK_PM_Permits_VOC_Emissions).Tables[0];

			if (dtPM_Permits_VOC_Emissions.Rows.Count == 1)
			{
				 SetValue(dtPM_Permits_VOC_Emissions.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_Permits_VOC_Emissions class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Permits_VOC_Emissions) 
		{
				if (drPM_Permits_VOC_Emissions["PK_PM_Permits_VOC_Emissions"] == DBNull.Value)
					this._PK_PM_Permits_VOC_Emissions = null;
				else
					this._PK_PM_Permits_VOC_Emissions = (decimal?)drPM_Permits_VOC_Emissions["PK_PM_Permits_VOC_Emissions"];

				if (drPM_Permits_VOC_Emissions["FK_PM_Permits"] == DBNull.Value)
					this._FK_PM_Permits = null;
				else
					this._FK_PM_Permits = (decimal?)drPM_Permits_VOC_Emissions["FK_PM_Permits"];

				if (drPM_Permits_VOC_Emissions["Year"] == DBNull.Value)
					this._Year = null;
				else
					this._Year = (int?)drPM_Permits_VOC_Emissions["Year"];

				if (drPM_Permits_VOC_Emissions["Month"] == DBNull.Value)
					this._Month = null;
				else
					this._Month = (int?)drPM_Permits_VOC_Emissions["Month"];

				if (drPM_Permits_VOC_Emissions["FK_LU_VOC_Category"] == DBNull.Value)
					this._FK_LU_VOC_Category = null;
				else
					this._FK_LU_VOC_Category = (decimal?)drPM_Permits_VOC_Emissions["FK_LU_VOC_Category"];

				if (drPM_Permits_VOC_Emissions["SubTotal_Text"] == DBNull.Value)
					this._SubTotal_Text = null;
				else
					this._SubTotal_Text = (string)drPM_Permits_VOC_Emissions["SubTotal_Text"];

				if (drPM_Permits_VOC_Emissions["Part_Number"] == DBNull.Value)
					this._Part_Number = null;
				else
					this._Part_Number = (string)drPM_Permits_VOC_Emissions["Part_Number"];

				if (drPM_Permits_VOC_Emissions["Unit"] == DBNull.Value)
					this._Unit = null;
				else
					this._Unit = (string)drPM_Permits_VOC_Emissions["Unit"];

				if (drPM_Permits_VOC_Emissions["Quantity"] == DBNull.Value)
					this._Quantity = null;
				else
					this._Quantity = (string)drPM_Permits_VOC_Emissions["Quantity"];

				if (drPM_Permits_VOC_Emissions["Gallons"] == DBNull.Value)
					this._Gallons = null;
				else
					this._Gallons = (decimal?)drPM_Permits_VOC_Emissions["Gallons"];

				if (drPM_Permits_VOC_Emissions["VOC_Emissions"] == DBNull.Value)
					this._VOC_Emissions = null;
				else
					this._VOC_Emissions = (decimal?)drPM_Permits_VOC_Emissions["VOC_Emissions"];

				if (drPM_Permits_VOC_Emissions["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Permits_VOC_Emissions["Update_Date"];

				if (drPM_Permits_VOC_Emissions["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Permits_VOC_Emissions["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Permits_VOC_Emissions table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Permits_VOC_EmissionsInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Permits", DbType.Decimal, this._FK_PM_Permits);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "Month", DbType.Int32, this._Month);
			
			db.AddInParameter(dbCommand, "FK_LU_VOC_Category", DbType.Decimal, this._FK_LU_VOC_Category);
			
			if (string.IsNullOrEmpty(this._SubTotal_Text))
				db.AddInParameter(dbCommand, "SubTotal_Text", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "SubTotal_Text", DbType.String, this._SubTotal_Text);
			
			if (string.IsNullOrEmpty(this._Part_Number))
				db.AddInParameter(dbCommand, "Part_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Part_Number", DbType.String, this._Part_Number);
			
			if (string.IsNullOrEmpty(this._Unit))
				db.AddInParameter(dbCommand, "Unit", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Unit", DbType.String, this._Unit);
			
			if (string.IsNullOrEmpty(this._Quantity))
				db.AddInParameter(dbCommand, "Quantity", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Quantity", DbType.String, this._Quantity);
			
			db.AddInParameter(dbCommand, "Gallons", DbType.Decimal, this._Gallons);
			
			db.AddInParameter(dbCommand, "VOC_Emissions", DbType.Decimal, this._VOC_Emissions);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_Permits_VOC_Emissions table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Permits_VOC_Emissions)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Permits_VOC_EmissionsSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Permits_VOC_Emissions", DbType.Decimal, pK_PM_Permits_VOC_Emissions);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Permits_VOC_Emissions table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Permits_VOC_EmissionsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Permits_VOC_Emissions table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Permits_VOC_EmissionsUpdate");
			
			db.AddInParameter(dbCommand, "PK_PM_Permits_VOC_Emissions", DbType.Decimal, this._PK_PM_Permits_VOC_Emissions);
			
			db.AddInParameter(dbCommand, "FK_PM_Permits", DbType.Decimal, this._FK_PM_Permits);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "Month", DbType.Int32, this._Month);
			
			db.AddInParameter(dbCommand, "FK_LU_VOC_Category", DbType.Decimal, this._FK_LU_VOC_Category);
			
			if (string.IsNullOrEmpty(this._SubTotal_Text))
				db.AddInParameter(dbCommand, "SubTotal_Text", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "SubTotal_Text", DbType.String, this._SubTotal_Text);
			
			if (string.IsNullOrEmpty(this._Part_Number))
				db.AddInParameter(dbCommand, "Part_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Part_Number", DbType.String, this._Part_Number);
			
			if (string.IsNullOrEmpty(this._Unit))
				db.AddInParameter(dbCommand, "Unit", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Unit", DbType.String, this._Unit);
			
			if (string.IsNullOrEmpty(this._Quantity))
				db.AddInParameter(dbCommand, "Quantity", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Quantity", DbType.String, this._Quantity);
			
			db.AddInParameter(dbCommand, "Gallons", DbType.Decimal, this._Gallons);
			
			db.AddInParameter(dbCommand, "VOC_Emissions", DbType.Decimal, this._VOC_Emissions);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the PM_Permits_VOC_Emissions table by a composite primary key.
		/// </summary>
		public void DeleteByPK(decimal pK_PM_Permits_VOC_Emissions)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Permits_VOC_EmissionsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Permits_VOC_Emissions", DbType.Decimal, pK_PM_Permits_VOC_Emissions);

            db.AddInParameter(dbCommand, "FK_PM_Permits", DbType.Decimal, this._FK_PM_Permits);

            db.AddInParameter(dbCommand, "FK_LU_VOC_Category", DbType.Decimal, this._FK_LU_VOC_Category);

            db.AddInParameter(dbCommand, "Month", DbType.Decimal, this._Month);

            db.AddInParameter(dbCommand, "Year", DbType.Decimal, this._Year);

            if (string.IsNullOrEmpty(this._SubTotal_Text))
                db.AddInParameter(dbCommand, "SubTotal_Text", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SubTotal_Text", DbType.String, this._SubTotal_Text);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

        public DataSet SelectByFK(decimal FK_PM_Permits)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Permits_VOC_EmissionsSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Permits", DbType.Decimal, FK_PM_Permits);
            db.AddInParameter(dbCommand, "FK_LU_VOC_Category", DbType.Decimal, FK_LU_VOC_Category);
            db.AddInParameter(dbCommand, "PK_PM_Permits_VOC_Emissions", DbType.Decimal, PK_PM_Permits_VOC_Emissions);
            db.AddInParameter(dbCommand, "Month", DbType.Int16, Month);
            db.AddInParameter(dbCommand, "Year", DbType.Int16, Year);

            return db.ExecuteDataSet(dbCommand);
        }

        public DataSet SelectByFKPermit(decimal FK_PM_Permits,int Month,int Year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Permits_VOC_EmissionsSelectByFKPermit");

            db.AddInParameter(dbCommand, "FK_PM_Permits", DbType.Decimal, FK_PM_Permits);
            db.AddInParameter(dbCommand, "Month", DbType.Int16, Month);
            db.AddInParameter(dbCommand, "Year", DbType.Int16, Year);
           
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Insert Events from csv file
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public DataSet InsertData(string FilePath)
        {
            Database db = null;
            DbCommand dbCommand = null;
            DataSet ds = new DataSet();
            try
            {
                db = DatabaseFactory.CreateDatabase();
                dbCommand = db.GetStoredProcCommand("VOC_Import");
                dbCommand.CommandTimeout = 1000000;
                db.AddInParameter(dbCommand, "FilePath", DbType.String, FilePath);
                ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (Exception ex)
            {
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                    dbCommand = null;
                }
                if (db != null)
                {
                    db = null;
                }
                throw ex;
            }
        }

        /// <summary>
        /// Check if Record Exist for corresponding Month,Year and Category
        /// </summary>
        /// <param name="Month"></param>
        /// <param name="Year"></param>
        /// <param name="FK_LU_VOC_Category"></param>
        /// <returns></returns>
        public static int CheckRecord(int Month, int Year, decimal FK_LU_VOC_Category, decimal FK_LU_Location,decimal FK_PM_Permits, string Part_Number)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Permits_VOC_EmissionsSelectPermit");

            db.AddInParameter(dbCommand, "Month", DbType.Int16, Month);
            db.AddInParameter(dbCommand, "Year", DbType.Int16, Year);
            db.AddInParameter(dbCommand, "FK_LU_VOC_Category", DbType.Decimal, FK_LU_VOC_Category);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            db.AddInParameter(dbCommand, "FK_PM_Permits", DbType.Decimal, FK_PM_Permits);
            db.AddInParameter(dbCommand, "Part_Number", DbType.String, Part_Number);

            return Convert.ToInt32(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        /// Import XML 
        /// </summary>
        /// <param name="xml"></param>
        public static void ImportXML(string xml,string xmlUpdate)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InsertXML");

            db.AddInParameter(dbCommand, "xml", DbType.Xml, xml);
            db.AddInParameter(dbCommand, "xmlUpdate", DbType.Xml, xmlUpdate);

            db.ExecuteNonQuery(dbCommand);
        }

        public static void UpdateSubTotal(string SubTotal_Text, decimal FK_LU_VOC_Category, decimal FK_PM_Permits, int Month, int Year, string Update_Date, string Updated_By)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Permits_VOC_EmissionsUpdateSubTotal");

            db.AddInParameter(dbCommand, "SubTotal_Text", DbType.String, SubTotal_Text);
            db.AddInParameter(dbCommand, "FK_LU_VOC_Category", DbType.Decimal, FK_LU_VOC_Category);
            db.AddInParameter(dbCommand, "FK_PM_Permits", DbType.Decimal, FK_PM_Permits);
            db.AddInParameter(dbCommand, "Month", DbType.Int16, Month);
            db.AddInParameter(dbCommand, "Year", DbType.Int16, Year);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, Update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, Updated_By);

            db.ExecuteNonQuery(dbCommand);
        }


        public static DataSet GetVOCGraphReport(int StartYear, int EndYear, int StartMonth, int EndMonth, string Locations)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("VOC_Graph_Report");
            db.AddInParameter(dbCommand, "StartYear", DbType.Int16, StartYear);
            db.AddInParameter(dbCommand, "EndYear", DbType.Int16, EndYear);
            db.AddInParameter(dbCommand, "StartMonth", DbType.Int16, StartMonth);
            db.AddInParameter(dbCommand, "EndMonth", DbType.Int16, EndMonth);
            db.AddInParameter(dbCommand, "Location", DbType.String, Locations);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_Permits_VOC_Emission)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Permits_VOC_Emissions_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_Permits_VOC_Emissions", DbType.Decimal, pK_PM_Permits_VOC_Emission);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
